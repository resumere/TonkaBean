
namespace Resumere.TonkaBean.Client
{
	public class TonkaCommands
	{
		/// <summary>
		/// <para>Parameters: </para>
		/// <para>{0} name</para>
		/// </summary>
		public static readonly string CMD_BAN_USER = "ban {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} name</para>
		/// <para>{1} reason</para>
		/// </summary>
		public static readonly string CMD_BAN_USER_REASON = "ban {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} address|name</para>
		/// </summary>
		public static readonly string CMD_BAN_IP = "ban-ip {0}";

		/// <summary>
		/// <para>Parameters: </para>
		/// <para>{0} address|name</para>
		/// <para>{1} reason</para>
		/// </summary>
		public static readonly string CMD_BAN_IP_REASON = "ban-ip {0} {1}";

		/// <summary>
		/// <para>Lists the banned players</para>
		/// </summary>
		public static readonly string CMD_BAN_LIST = "banlist players";

		/// <summary>
		/// <para>Lists the banned IP addresses</para>
		/// </summary>
		public static readonly string CMD_BAN_LIST_IPS = "banlist ips";

		/// <summary>
		/// <para>Lists the current players</para>
		/// </summary>
		public static readonly string CMD_LIST = "list";

		/// <summary>
		/// <para>Lists the current members of the whitelist</para>
		/// </summary>
		public static readonly string CMD_WHITELIST_LIST = "whitelist list";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} time value between Limits.MIN_TIME and Limits.MAX_TIME</para>
		/// </summary>
		public static readonly string CMD_SET_TIME = "time set {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} time value between Limits.MIN_TIME and Limits.MAX_TIME</para>
		/// </summary>
		public static readonly string CMD_ADD_TIME = "time add {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} The gamemode value, use the GameModes enum</para>
		/// </summary>
		public static readonly string CMD_DEFAULT_GAME_MODE = "defaultgamemode {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} The gamemode value, use the GameModes enum</para>
		/// <para>{1} The userid of the player</para>
		/// </summary>
		public static readonly string CMD_GAME_MODE = "gamemode {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} The difficulty value, use the Difficulty enum</para>
		/// </summary>
		public static readonly string CMD_SET_DIFFICULTY = "difficulty {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} The game rule value, use the GameRules enum</para>
		/// <para>{1} True or False</para>
		/// </summary>
		public static readonly string CMD_SET_GAME_RULE = "gamerule {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} The message</para>
		/// </summary>
		public static readonly string CMD_SAY = "say {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// <para>{1} Target player name</para>
		/// </summary>
		public static readonly string CMD_TP_PLAYER = "tp {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// <para>{1} X Location</para>
		/// <para>{2} Y Location</para>
		/// <para>{3} Z Location</para>
		/// </summary>
		public static readonly string CMD_TP_PLAYER_LOC = "tp {0} {1} {2} {3}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Weather type, user the Weather enum</para>
		/// </summary>
		public static readonly string CMD_WEATHER = "weather {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Weather type, user the Weather enum</para>
		/// <para>{1} Weather duration</para>
		/// </summary>
		public static readonly string CMD_WEATHER_DURATION = "weather {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// </summary>
		public static readonly string CMD_DEOP_USER = "deop {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// </summary>
		public static readonly string CMD_OP_USER = "op {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// </summary>
		public static readonly string CMD_KICK_USER = "kick {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// <para>{1} Reason</para>
		/// </summary>
		public static readonly string CMD_KICK_USER_REASON = "kick {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// </summary>
		public static readonly string CMD_PARDON = "pardon {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} IP Address</para>
		/// </summary>
		public static readonly string CMD_PARDON_IP = "pardon-ip {0}";

		/// <summary>
		/// <para>Saves the world.</para>
		/// </summary>
		public static readonly string CMD_SAVE_ALL = "save-all";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// </summary>
		public static readonly string CMD_WHITELIST_ADD = "whitelist add {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// </summary>
		public static readonly string CMD_WHITELIST_REMOVE = "whitelist remove {0}";

		/// <summary>
		/// <para>Enables the whitelist.</para>
		/// </summary>
		public static readonly string CMD_WHITELIST_ON = "whitelist on";

		/// <summary>
		/// <para>Disables the whitelist.</para>
		/// </summary>
		public static readonly string CMD_WHITELIST_OFF = "whitelist off";

		/// <summary>
		/// <para>Reloads the whitelist.</para>
		/// </summary>
		public static readonly string CMD_WHITELIST_RELOAD = "whitelist reload";

		/// <summary>
		/// <para>Toggles rain and snow.</para>
		/// </summary>
		public static readonly string CMD_TOGGLE_DOWNFALL = "toggledownfall";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// <para>{1} Data value of the item</para>
		/// <para>{2} Amount, defaults to 1</para>
		/// <para>{3} Metadata</para>
		/// <para>{4} DataTag</para>
		/// </summary>
		public static readonly string CMD_GIVE = "give {0} {1} {2} {3} {4}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// <para>{1} Enchantment ID</para>
		/// <para>{2} Enchantment Level. Defaults to 1, max 5.</para>
		/// </summary>
		public static readonly string CMD_ENCHANT = "enchant {0} {1} {2}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// </summary>
		public static readonly string CMD_CLEAR_PLAYER = "clear {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// <para>{1} Item ID</para>
		/// </summary>
		public static readonly string CMD_CLEAR_PLAYER_ITEM = "clear {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// <para>{1} Item ID</para>
		/// <para>{2} Data</para>
		/// </summary>
		public static readonly string CMD_CLEAR_PLAYER_ITEM_DATA = "clear {0} {1} {2}";


		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// <para>{1} Effect ID</para>
		/// <para>{2} Data</para>
		/// </summary>
		public static readonly string CMD_EFFECT = "effect {0} {1} ";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// <para>{1} Effect ID</para>
		/// <para>{2} Seconds</para>
		/// </summary>
		public static readonly string CMD_EFFECT_SECONDS = "effect {0} {1} {2}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player name</para>
		/// <para>{1} Effect ID</para>
		/// <para>{2} Seconds</para>
		/// <para>{3} Amplifier</para>
		/// </summary>
		public static readonly string CMD_EFFECT_SECONDS_AMPD = "effect {0} {1} {2} {3}";


		// Scoreboards!
		/// <summary>
		/// Scoreboard Objectives
		/// </summary>
		public static readonly string CMD_SCOREBOARD_OBJ_LIST = "scoreboard objectives list";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Name</para>
		/// <para>{1} Criteria</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_OBJ_ADD = "scoreboard objectives add {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Name</para>
		/// <para>{1} Criteria</para>
		/// <para>{2} Display Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_OBJ_ADD_2 = "scoreboard objectives add {0} {1} {2}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_OBJ_REMOVE = "scoreboard objectives remove {0}";


		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Slot</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_OBJ_SETDISPLAY = "scoreboard objectives setdisplay {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Slot</para>
		/// <para>{1} Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_OBJ_SETDISPLAY_2 = "scoreboard objectives setdisplay {0} {1}";

		/// <summary>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_PLAYERS_LIST = "scoreboard players list";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_PLAYERS_LIST_2 = "scoreboard players list {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player Name</para>
		/// <para>{1} Objective Name</para>
		/// <para>{2} Score</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_PLAYERS_SET = "scoreboard players set {0} {1} {2}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player Name</para>
		/// <para>{1} Objective Name</para>
		/// <para>{2} Count</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_PLAYERS_ADD = "scoreboard players add {0} {1} {2}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player Name</para>
		/// <para>{1} Objective Name</para>
		/// <para>{2} Count</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_PLAYERS_REMOVE = "scoreboard players remove {0} {1} {2}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_PLAYERS_RESET = "scoreboard players reset {0}";

		/// <summary>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_LIST = "scoreboard teams list";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Team Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_LIST_2 = "scoreboard teams list {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Team Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_ADD = "scoreboard teams add {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Team Name</para>
		/// <para>{1} Display Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_ADD_2 = "scoreboard teams add {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Team Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_REMOVE = "scoreboard teams remove {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Team Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_EMPTY = "scoreboard teams empty {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Team Name</para>
		/// <para>{1} Player Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_JOIN = "scoreboard teams join {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Player Name</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_LEAVE = "scoreboard teams leave {0}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Team Name</para>
		/// <para>{1} Color Value</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_OPT_COLOR = "scoreboard teams option {0} color {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Team Name</para>
		/// <para>{1} true|false</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_OPT_FRIENDLYFIRE = "scoreboard teams option {0} friendlyfire {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Team Name</para>
		/// <para>{1} true|false</para>
		/// </summary>
		public static readonly string CMD_SCOREBOARD_TEAMS_OPT_SEEFRIENDLYINVISIBLES = "scoreboard teams option {0} seeFriendlyInvisibles {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Achievement or Statistic</para>
		/// <para>{1} Player Name</para>
		/// </summary>
		public static readonly string CMD_ACHIEVEMENT_GIVE = "achievement give {0} {1}";

		/// <summary>
		/// 
		/// </summary>
		public static readonly string CMD_DEBUG_START = "debug start";

		/// <summary>
		/// 
		/// </summary>
		public static readonly string CMD_DEBUG_STOP = "debug stop";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Sound</para>
		/// <para>{1} Player Name</para>
		/// </summary>
		public static readonly string CMD_PLAYSOUND = "playsound {0} {1}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Sound</para>
		/// <para>{1} Player Name</para>
		/// <para>{2} X</para>
		/// <para>{3} Y</para>
		/// <para>{4} Z</para>
		/// </summary>
		public static readonly string CMD_PLAYSOUND_1 = "playsound {0} {1} {2} {3} {4}";

		/// <summary>
		/// <para>Parameters:</para>
		/// <para>{0} Sound</para>
		/// <para>{1} Player Name</para>
		/// <para>{2} X</para>
		/// <para>{3} Y</para>
		/// <para>{4} Z</para>
		/// <para>{5} Volume</para>
		/// <para>{6} Pitch</para>
		/// <para>{7} Minimum Volume</para>
		/// </summary>
		public static readonly string CMD_PLAYSOUND_2 = "playsound {0} {1} {2} {3} {4} {5} {6} {7}";

		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Y</para>
		/// <para>{2} Z</para>
		/// <para>{3} Tile Name</para>
		/// </summary>
		public static readonly string CMD_SETBLOCK = "setblock {0} {1} {2} {3}";

		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Y</para>
		/// <para>{2} Z</para>
		/// <para>{3} Tile Name</para>
		/// <para>{4} Data Value</para>
		/// </summary>
		public static readonly string CMD_SETBLOCK_1 = "setblock {0} {1} {2} {3} {4}";

		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Y</para>
		/// <para>{2} Z</para>
		/// <para>{3} Tile Name</para>
		/// <para>{4} Data Value</para>
		/// <para>{5} Oldblock Handling</para>
		/// </summary>
		public static readonly string CMD_SETBLOCK_2 = "setblock {0} {1} {2} {3} {4} {5}";

		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Y</para>
		/// <para>{2} Z</para>
		/// <para>{3} Tile Name</para>
		/// <para>{4} Data Value</para>
		/// <para>{5} Oldblock Handling</para>
		/// <para>{6} Data Tag</para>
		/// </summary>
		public static readonly string CMD_SETBLOCK_3 = "setblock {0} {1} {2} {3} {4} {5} {6}";


		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Y</para>
		/// <para>{2} Z</para>
		/// </summary>
		public static readonly string CMD_SETWORLDSPAWN = "setworldspawn {0} {1} {2}";


		/// <summary>
		/// <para>{0} Player</para>
		/// <para>{1} X</para>
		/// <para>{2} Y</para>
		/// <para>{3} Z</para>
		/// </summary>
		public static readonly string CMD_SPAWNPOINT = "spawnpoint {0} {1} {2} {3}";

		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Z</para>
		/// <para>{2} Spread Distance</para>
		/// </summary>
		public static readonly string CMD_SPREADPLAYERS = "spreadplayers {0} {1} {2}";

		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Z</para>
		/// <para>{2} Spread Distance</para>
		/// <para>{3} Max Range</para>
		/// </summary>
		public static readonly string CMD_SPREADPLAYERS_1 = "spreadplayers {0} {1} {2} {3}";

		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Z</para>
		/// <para>{2} Spread Distance</para>
		/// <para>{3} Max Range</para>
		/// <para>{4} Respect Teams</para>
		/// </summary>
		public static readonly string CMD_SPREADPLAYERS_2 = "spreadplayers {0} {1} {2} {3} {4}";

		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Z</para>
		/// <para>{2} Spread Distance</para>
		/// <para>{3} Max Range</para>
		/// <para>{4} Respect Teams</para>
		/// <para>{5} Player List</para>
		/// </summary>
		public static readonly string CMD_SPREADPLAYERS_3 = "spreadplayers {0} {1} {2} {3} {4} {5}";

		/// <summary>
		/// <para>{0} Entity Name</para>
		/// <para>{1} X</para>
		/// <para>{2} Y</para>
		/// <para>{3} Z</para>
		/// </summary>
		public static readonly string CMD_SUMMON = "summon {0} {1} {2} {3}";

		/// <summary>
		/// <para>{0} Entity Name</para>
		/// <para>{1} X</para>
		/// <para>{2} Y</para>
		/// <para>{3} Z</para>
		/// <para>{4} Data Tag</para>
		/// </summary>
		public static readonly string CMD_SUMMON_1 = "summon {0} {1} {2} {3} {4}";


		/// <summary>
		/// <para>{0} Player</para>
		/// <para>{1} Raw Message</para>
		/// </summary>
		public static readonly string CMD_TELLRAW = "tellraw {0} {1}";


		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Y</para>
		/// <para>{2} Z</para>
		/// <para>{3} Tile Name</para>
		/// </summary>
		public static readonly string CMD_TESTFORBLOCK = "setblock {0} {1} {2} {3}";

		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Y</para>
		/// <para>{2} Z</para>
		/// <para>{3} Tile Name</para>
		/// <para>{4} Data Value</para>
		/// </summary>
		public static readonly string CMD_TESTFORBLOCK_1 = "setblock {0} {1} {2} {3} {4}";

		/// <summary>
		/// <para>{0} X</para>
		/// <para>{1} Y</para>
		/// <para>{2} Z</para>
		/// <para>{3} Tile Name</para>
		/// <para>{4} Data Value</para>
		/// <para>{5} Data Tag</para>
		/// </summary>
		public static readonly string CMD_TESTFORBLOCK_2 = "setblock {0} {1} {2} {3} {4} {5}";


		/// <summary>
		/// <para>{0} Amount</para>
		/// <para>{1} Player Name</para>
		/// </summary>
		public static readonly string CMD_XP = "xp {0} {1}";

		/// <summary>
		/// <para>{0} Amount</para>
		/// <para>{1} Player Name</para>
		/// </summary>
		public static readonly string CMD_XP_LEVEL = "xp {0}L {1}";


		/// <summary>
		/// <para>{0} Minutes Until Kick</para>
		/// </summary>
		public static readonly string CMD_SETIDLETIMEOUT = "setidletimeout {0}";

	}
}
