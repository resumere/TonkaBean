using System;
using System.Net;
using System.Net.Sockets;

namespace Resumere.TonkaBean.RCON
{
	public class RemoteClient : IRemoteClient
	{
		protected Int32 PacketId { get; set; }
		protected Socket ClientSocket { get; set; }

		protected string Hostname { get; set; }
		protected ushort PortNumber { get; set; }
		protected string Password { get; set; }


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

		public RemoteClient(string hostname, ushort portNumber, string password)
		{
			PacketId = 0;
			this.SetProperties(hostname, portNumber, password);
		}

		public void Connect()
		{
			if (ClientSocket == null || !ClientSocket.Connected)
			{
				IPHostEntry hostEntry = Dns.GetHostEntry(Hostname);
				foreach (IPAddress address in hostEntry.AddressList)
				{
					IPEndPoint ipe = new IPEndPoint(address, PortNumber);
					ClientSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
					ClientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
					// 15 second timeout for sending
					ClientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 15000);
					// 15 second timeout for receiving
					ClientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 15000);

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

		public void Disconnect()
		{
			if (ClientSocket.Connected)
			{
				ClientSocket.Disconnect(true);
			}
		}

		protected bool Authenticate()
		{
			bool isAuthenticated = false;
			if (ClientSocket.Connected)
			{
				RequestPacket reqPacket = NewRequest(RequestPacketType.AUTH, Password);
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
			lock (this)
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


			if (!ClientSocket.Connected)
			{
				this.Connect();
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
			return result;
		}


		protected void DebugPacket(byte[] packet)
		{
			lock (this)
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
		}

		protected void DebugPacket(IPacket packet)
		{
			lock (this)
			{
				Console.WriteLine("--------------------------------------------------------------------------------");
				Console.WriteLine("Debugging RCON Packet:");
				Console.WriteLine(packet.ToString());
				Console.WriteLine("--------------------------------------------------------------------------------");
			}
		}

	}
}
