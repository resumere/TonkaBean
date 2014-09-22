
using System;
using System.Collections;
using System.Text;

namespace Resumere.TonkaBean.RCON
{
	public class ResponsePacket : IResponsePacket
	{
		public int PacketId { get; set; }
		public ResponsePacketType ResponseType { get; set; }
		public string DataString1 { get; set; }
		public string DataString2 { get; set; }
		public IRequestPacket RequestPacket { get; set; }

		public string Data
		{
			get
			{
				StringBuilder data = new StringBuilder();
				if (!string.IsNullOrEmpty(DataString1))
				{
					data.AppendLine(DataString1);
				}
				if (!string.IsNullOrEmpty(DataString2))
				{
					data.AppendLine(DataString2);
				}
				return data.ToString();
			}
		}

		private UTF8Encoding utf8 = new UTF8Encoding();

		public ResponsePacket()
		{
			PacketId = 0;
			ResponseType = ResponsePacketType.NONE;
			DataString1 = string.Empty;
			DataString2 = string.Empty;
		}

		public ResponsePacket(byte[] responseData, RequestPacket requestPacket)
		{
			RequestPacket = requestPacket;

			switch (requestPacket.RequestType)
			{
				case RequestPacketType.AUTH:
					ResponseType = ResponsePacketType.AUTH_RESPONSE;
					break;
				case RequestPacketType.COMMAND:
					ResponseType = ResponsePacketType.RESPONSE_VALUE;
					break;
				default:
					ResponseType = ResponsePacketType.NONE;
					break;
			}

			ArrayList dataCache;
			// Start at 4
			int pos = 4;
			// Read the Packet ID
			PacketId = BitConverter.ToInt32(responseData, pos);
			pos += 4;
			// Read the Response Type
			ResponseType = (ResponsePacketType)BitConverter.ToInt32(responseData, pos);
			pos += 4;
			// Read the first result string
			dataCache = new ArrayList();
			while (responseData[pos] != 0)
			{
				dataCache.Add(responseData[pos]);
				pos++;
			}
			DataString1 = utf8.GetString((byte[])dataCache.ToArray(typeof(byte)));
			pos++;
			// Read the second result string
			dataCache = new ArrayList();
			while (responseData[pos] != 0)
			{
				dataCache.Add(responseData[pos]);
				pos++;
			}
			DataString2 = utf8.GetString((byte[])dataCache.ToArray(typeof(byte)));
			pos++;
		}

		public byte[] GetBytes()
		{
			byte[] packetSize;
			byte[] packetId;
			byte[] packetType;
			byte[] dataString1;
			byte[] dataString2;

			// Convert data to byte arrays
			packetId = BitConverter.GetBytes(PacketId);
			packetType = BitConverter.GetBytes((int)ResponseType);
			dataString1 = utf8.GetBytes(DataString1);
			dataString2 = utf8.GetBytes(DataString2);

			byte[] returnPacket = new byte[14 + dataString1.Length + dataString2.Length];
			packetSize = BitConverter.GetBytes(returnPacket.Length - 4);

			int pos = 0;
			// Copy the packet size to the return packet
			packetSize.CopyTo(returnPacket, pos);
			pos += 4;
			// Copy the packet ID to the return packet
			packetId.CopyTo(returnPacket, pos);
			pos += 4;
			// Copy the packet type to the return packet
			packetType.CopyTo(returnPacket, pos);
			pos += 4;
			// Copy the first data string to the return packet
			if (!string.IsNullOrEmpty(DataString1))
			{
				dataString1.CopyTo(returnPacket, pos);
				pos += dataString1.Length;
			}
			// Add a null/zero byte to the return packet
			returnPacket[pos] = (byte)0;
			pos++;
			// Copy the second data string to the return packet
			if (!string.IsNullOrEmpty(DataString2))
			{
				dataString2.CopyTo(returnPacket, pos);
				pos += dataString2.Length;
			}
			// Add a null/zero byte to the return packet
			returnPacket[pos] = (byte)0;
			pos++;

			return returnPacket;
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder();
			result.AppendLine(string.Format("PacketId: {0}", PacketId));
			result.AppendLine(string.Format("ResponseType: {0}", ResponseType));
			result.AppendLine(string.Format("Data 1: {0}", DataString1));
			result.AppendLine(string.Format("Data 2: {0}", DataString2));
			return result.ToString();
		}

	}
}
