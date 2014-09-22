
namespace Resumere.TonkaBean.RCON
{
	interface IRemoteClient
	{
		void SetProperties(string hostname, ushort portNumber, string password);

		void Connect();

		void Disconnect();

	}
}
