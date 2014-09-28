using Resumere.TonkaBean.Utils;
using System;
using System.Net;
using System.Net.Sockets;
using System.Security;

namespace Resumere.TonkaBean.RCON
{
    public class RemoteClient : IRemoteClient
    {
        protected Int32 PacketId { get; set; }
        protected Socket ClientSocket { get; set; }

        //private SecureString _hostname = null;
        private SecureString _password = null;

        private bool _keepAlive = true;
        private int _sendTimeout = 15000;
        private int _receiveTimeout = 15000;

        protected string Hostname { get; set; }

        protected ushort PortNumber { get; set; }
        
        protected string Password
        {
            set
            {
                try
                {
                    _password = SecureUtils.CreateSecureString(value);
                }
                finally
                {
                    if (_password != null)
                    {
                        _password.MakeReadOnly();
                    }
                }
            }
        }


        public void SetProperties(string hostname, ushort portNumber, SecureString password)
        {
            Hostname = hostname;
            PortNumber = portNumber;
            _password = password;

            if (_password != null)
            {
                _password.MakeReadOnly();
            }
        }
        public void SetProperties(string hostname, ushort portNumber, string password)
        {
            Hostname = hostname;
            PortNumber = portNumber;
            Password = password;
        }

        public RemoteClient()
        {
            PacketId = 0;
        }

        public RemoteClient(string hostname, ushort portNumber, SecureString password)
        {
            PacketId = 0;
            SetProperties(hostname, portNumber, password);
        }

        public void Connect()
        {
            lock (ClientSocket)
            {
                if (ClientSocket == null || !ClientSocket.Connected)
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(Hostname);
                    foreach (IPAddress address in hostEntry.AddressList)
                    {
                        IPEndPoint ipe = new IPEndPoint(address, PortNumber);

                        ClientSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        ClientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, _keepAlive);
                        // 15 second timeout for sending
                        ClientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, _sendTimeout);
                        // 15 second timeout for receiving
                        ClientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, _receiveTimeout);

                        ClientSocket.Connect(ipe);

                        if (ClientSocket.Connected)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (!ClientSocket.Connected)
                    {
                        throw new ApplicationException("Failed to connect to server.");
                    }
                    else
                    {
                        bool authenticated = Authenticate();
                        if (!authenticated)
                        {
                            ClientSocket.Disconnect(false);
                        }
                    }
                }
            }
        }

        public void Disconnect()
        {
            lock (ClientSocket)
            {
                if (ClientSocket.Connected)
                {
                    ClientSocket.Disconnect(true);
                }
            }
        }

        protected bool Authenticate()
        {
            bool isAuthenticated = false;
            lock (ClientSocket)
            {
                if (ClientSocket.Connected)
                {
                    RequestPacket reqPacket = NewRequest(RequestPacketType.AUTH, SecureUtils.GetSecureStringValue(_password));
                    ResponsePacket respPacket = SendRequest(reqPacket);

                    if (respPacket.PacketId != -1)
                    {
                        isAuthenticated = true;
                    }
                }
                else
                {
                    throw new ApplicationException("You must be connected before you can authenticate!");
                }
            }
            return isAuthenticated;
        }


        protected RequestPacket NewRequest(RequestPacketType type, string data1, string data2 = "")
        {
            RequestPacket requestPacket = new RequestPacket(PacketId++, type, data1, data2);
            return requestPacket;
        }

        protected ResponsePacket SendRequest(RequestPacket requestPacket)
        {
            ResponsePacket result;
            lock (ClientSocket)
            {
                byte[] sendPacket = requestPacket.GetBytes();
                int bytesSent = ClientSocket.Send(sendPacket);

                byte[] bytesReceived = new byte[4096];
                int bytesReceiveSize = ClientSocket.Receive(bytesReceived);

                result = new ResponsePacket(bytesReceived, requestPacket);
            }
            return result;
        }

        protected string SendCommand(string command)
        {
            string result = string.Empty;
            lock (ClientSocket)
            {
                if (!ClientSocket.Connected)
                {
                    Connect();
                }
                if (ClientSocket.Connected)
                {
                    RequestPacket reqPacket = NewRequest(RequestPacketType.COMMAND, command);
                    ResponsePacket respPacket = SendRequest(reqPacket);
                    result = respPacket.Data;
                }
                else
                {
                    throw new ApplicationException("You must be connected to send a command!");
                }
            }
            return result;
        }


        protected void DebugPacket(byte[] packet)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Debugging Packet:");
            foreach (byte nom in packet)
            {
                Console.Write(string.Format("{0:X2} ", nom));
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }

        protected void DebugPacket(IPacket packet)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Debugging RCON Packet:");
            Console.WriteLine(packet.ToString());
            Console.WriteLine("--------------------------------------------------------------------------------");
        }

    }
}
