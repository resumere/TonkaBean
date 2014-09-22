using System;
using System.Text;

namespace Resumere.TonkaBean.RCON
{

	public class RequestPacket : IRequestPacket
	{
		public int PacketId { get; set; }
		public RequestPacketType RequestType { get; set; }
		public string DataString1 { get; set; }
		public string DataString2 { get; set; }

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

		
		public RequestPacket()
		{
			PacketId = 0;
			RequestType = RequestPacketType.NONE;
			DataString1 = string.Empty;
			DataString2 = string.Empty;
		}

		public RequestPacket(int packetId, RequestPacketType requestType, string dataString1, string datastring2 = "")
		{
			PacketId = packetId;
			RequestType = requestType;
			DataString1 = dataString1;
			DataString2 = datastring2;
		}


		public byte[] GetBytes()
		{
			byte[] packetSize;
			byte[] packetId;
			byte[] packetType;
			byte[] dataString1;
			byte[] dataString2;

			
			UTF8Encoding utf8 = new UTF8Encoding();
			// Convert data to byte arrays
			packetId = BitConverter.GetBytes(PacketId);
			packetType = BitConverter.GetBytes((int)RequestType);
			dataString1 = utf8.GetBytes(DataString1);
			dataString2 = utf8.GetBytes(DataString2);

			byte[] returnPacket = new byte[14 + dataString1.Length + dataString2.Length];
			packetSize = BitConverter.GetBytes(returnPacket.Length - 4);

			int pos = 0;
			packetSize.CopyTo(returnPacket, pos);
			pos += 4;

			packetId.CopyTo(returnPacket, pos);
			pos += 4;

			packetType.CopyTo(returnPacket, pos);
			pos += 4;

			if (!string.IsNullOrEmpty(DataString1))
			{
				dataString1.CopyTo(returnPacket, pos);
				pos += dataString1.Length;
			}

			returnPacket[pos] = (byte)0;
			pos++;

			if (!string.IsNullOrEmpty(DataString2))
			{
				dataString2.CopyTo(returnPacket, pos);
				pos += dataString2.Length;
			}

			returnPacket[pos] = (byte)0;
			pos++;

			return returnPacket;
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder();
			result.AppendLine(string.Format("PacketId: {0}", PacketId));
			result.AppendLine(string.Format("RequestType: {0}", RequestType));
			result.AppendLine(string.Format("Data 1: {0}", DataString1));
			result.AppendLine(string.Format("Data 2: {0}", DataString2));
			return result.ToString();
		}


	}


}
