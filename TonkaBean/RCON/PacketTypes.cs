using System;

namespace Resumere.TonkaBean.RCON
{
	[Serializable]
	public enum RequestPacketType
	{
		AUTH = 3,
		COMMAND = 2,
		NONE = 255
	}

	[Serializable]
	public enum ResponsePacketType
	{
		RESPONSE_VALUE = 0,
		AUTH_RESPONSE = 2,
		NONE = 255
	}

}
