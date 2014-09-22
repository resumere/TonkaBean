
namespace Resumere.TonkaBean.RCON
{
	public interface IPacket
	{
		int PacketId { get; set; }
		string DataString1 { get; set; }
		string DataString2 { get; set; }
		string Data { get; }
		byte[] GetBytes();
	}

	public interface IRequestPacket : IPacket
	{
		RequestPacketType RequestType { get; set; }
	}

	public interface IResponsePacket : IPacket
	{
		ResponsePacketType ResponseType { get; set; }
		IRequestPacket RequestPacket { get; set; }
	}

}
