using System;
using System.Collections.Generic;
using Resumere.TonkaBean.Enums;
using Resumere.TonkaBean.RCON;

namespace Resumere.TonkaBean.Client
{
	[Serializable]
	public class TonkaClient : RemoteClient
	{

		public TonkaClient()
			: base()
		{
		}

		public TonkaClient(string hostname, ushort portNumber, string password)
			: base(hostname, portNumber, password)
		{
		}

		public IEnumerable<string> GetCurrentUsers()
		{
			List<string> currentUsers = new List<string>();
			try
			{
				string listCommand = SendCommand(TonkaCommands.CMD_LIST);

				if (listCommand.Contains(":") || listCommand.Contains("\r\n") || listCommand.Contains("\n"))
				{
					string userList = listCommand.Split(new string[] { ":", "\r\n", "\n" }, 2, StringSplitOptions.None)[1];
					foreach (string user in userList.Split(new string[] { ",", " and " }, StringSplitOptions.RemoveEmptyEntries))
					{
						if (!string.IsNullOrWhiteSpace(user))
						{
							currentUsers.Add(user.Trim());
						}
					}
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			currentUsers.Sort();
			return currentUsers;
		}

		public string SetTime(int time)
		{
			if (!(time >= (int)Limits.MinTime && time <= (int)Limits.MaxTime))
			{
				throw new ArgumentOutOfRangeException("time", string.Format("The value must be between {0} and {1}.", (int)Limits.MinTime, (int)Limits.MaxTime));
			}

			string cmd = string.Format(TonkaCommands.CMD_SET_TIME, time);
			string result = SendCommand(cmd);
			return result;
		}

		public string SetTime(GameTime time)
		{
			if (!((int)time >= (int)Limits.MinTime && (int)time <= (int)Limits.MaxTime))
			{
				throw new ArgumentOutOfRangeException("time", string.Format("The value must be between {0} and {1}.", (int)Limits.MinTime, (int)Limits.MaxTime));
			}
			string cmd = string.Format(TonkaCommands.CMD_SET_TIME, EnumUtils.GetEnumDefaultValue(time));
			string result = SendCommand(cmd);
			return result;
		}

		public string AddTime(int time)
		{
			if (!(time >= (int)Limits.MinTime && time <= (int)Limits.MaxTime))
			{
				throw new ArgumentOutOfRangeException("time", string.Format("The value must be between {0} and {1}.", (int)Limits.MinTime, (int)Limits.MaxTime));
			}

			string cmd = string.Format(TonkaCommands.CMD_ADD_TIME, time);
			string result = SendCommand(cmd);
			return result;
		}

		public string BanUser(string userid, string reason = "")
		{
			if (string.IsNullOrWhiteSpace(userid))
			{
				throw new ArgumentOutOfRangeException("userid", "The user must be provided.");
			}

			string cmd = string.Empty;
			if (string.IsNullOrWhiteSpace(reason))
			{
				cmd = string.Format(TonkaCommands.CMD_BAN_USER, userid);
			}
			else
			{
				cmd = string.Format(TonkaCommands.CMD_BAN_USER_REASON, userid, reason);
			}
			string result = SendCommand(cmd);
			return result;
		}

		public string BanIP(string ipAddress, string reason = "")
		{
			if (string.IsNullOrWhiteSpace(ipAddress))
			{
				throw new ArgumentOutOfRangeException("ipAddress", "The ip address must be provided.");
			}

			string cmd = string.Empty;
			if (string.IsNullOrWhiteSpace(reason))
			{
				cmd = string.Format(TonkaCommands.CMD_BAN_IP, ipAddress);
			}
			else
			{
				cmd = string.Format(TonkaCommands.CMD_BAN_IP_REASON, ipAddress, reason);
			}
			string result = SendCommand(cmd);
			return result;
		}

		public string SetDefaultGameMode(GameMode mode)
		{
			string cmd = string.Format(TonkaCommands.CMD_DEFAULT_GAME_MODE, EnumUtils.GetEnumDefaultValue(mode));
			string result = SendCommand(cmd);
			return result;
		}

		public string SetPlayerGameMode(string userid, GameMode mode)
		{
			if (string.IsNullOrWhiteSpace(userid))
			{
				throw new ArgumentOutOfRangeException("userid", "The user must be provided.");
			}

			string cmd = string.Format(TonkaCommands.CMD_GAME_MODE, EnumUtils.GetEnumDefaultValue(mode), userid);
			string result = SendCommand(cmd);
			return result;
		}

		public string SetDifficulty(Difficulty difficulty)
		{
			string cmd = string.Format(TonkaCommands.CMD_SET_DIFFICULTY, EnumUtils.GetEnumDefaultValue(difficulty));
			string result = SendCommand(cmd);
			return result;
		}

		public string SetGameRule(GameRules rule, bool flag)
		{
			string cmd = string.Format(TonkaCommands.CMD_SET_GAME_RULE, EnumUtils.GetEnumDefaultValue(rule), flag);
			string result = SendCommand(cmd);
			return result;
		}

		public void Say(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				throw new ArgumentOutOfRangeException("message", "You must provide a message. Cat got your tounge?");
			}
			else if (message.Length > 110)
			{
				throw new ArgumentOutOfRangeException("message", "Your message was too long. Your message must be 110 characters or less.");
			}
			string cmd = string.Format(TonkaCommands.CMD_SAY, message);
			string result = SendCommand(cmd);
		}

		public string TeleportPlayer(string fromUser, string toUser)
		{
			if (string.IsNullOrWhiteSpace(fromUser))
			{
				throw new ArgumentOutOfRangeException("fromUser", "You must provide the user you're teleporting.");
			}
			if (string.IsNullOrWhiteSpace(toUser))
			{
				throw new ArgumentOutOfRangeException("toUser", "You must provide the user you're teleporting to.");
			}
			string cmd = string.Format(TonkaCommands.CMD_TP_PLAYER, fromUser, toUser);
			string result = SendCommand(cmd);
			return result;
		}

		public string TeleportPlayer(string user, long x, long y, long z)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're teleporting.");
			}
			string cmd = string.Format(TonkaCommands.CMD_TP_PLAYER_LOC, user, x, y, z);
			string result = SendCommand(cmd);
			return result;
		}

		public string TeleportPlayer(string user, double x, double y, double z)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're teleporting.");
			}
			string cmd = string.Format(TonkaCommands.CMD_TP_PLAYER_LOC, user, x, y, z);
			string result = SendCommand(cmd);
			return result;
		}

		public string SetWeather(Weather weather)
		{
			string cmd = string.Format(TonkaCommands.CMD_WEATHER, EnumUtils.GetEnumDefaultValue(weather));
			string result = SendCommand(cmd);
			return result;
		}

		public string SetWeather(Weather weather, int duration)
		{
			if (duration < (int)Limits.MinWeatherTime || duration > (int)Limits.MaxWeatherTime)
			{
				throw new ArgumentOutOfRangeException("duration", string.Format("The duration must be between {0} and {1}.", 0, (int)Limits.MaxWeatherTime));
			}

			string cmd = string.Format(TonkaCommands.CMD_WEATHER_DURATION, EnumUtils.GetEnumDefaultValue(weather), duration);
			string result = SendCommand(cmd);
			return result;
		}

		public IEnumerable<string> GetBannedUsers()
		{
			List<string> bannedUsers = new List<string>();
			try
			{
				string listCommand = SendCommand(TonkaCommands.CMD_BAN_LIST);

				if (listCommand.Contains(":") || listCommand.Contains("\r\n") || listCommand.Contains("\n"))
				{
					string userList = listCommand.Split(new string[] { ":", "\r\n", "\n" }, 2, StringSplitOptions.None)[1];
					foreach (string user in userList.Split(new string[] { ",", " and " }, StringSplitOptions.RemoveEmptyEntries))
					{
						if (!string.IsNullOrWhiteSpace(user))
						{
							bannedUsers.Add(user.Trim());
						}
					}
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			bannedUsers.Sort();
			return bannedUsers;
		}

		public IEnumerable<string> GetBannedIPs()
		{
			List<string> bannedIPs = new List<string>();
			try
			{
				string listCommand = SendCommand(TonkaCommands.CMD_BAN_LIST_IPS);

				if (listCommand.Contains(":") || listCommand.Contains("\r\n") || listCommand.Contains("\n"))
				{
					string userList = listCommand.Split(new string[] { ":", "\r\n", "\n" }, 2, StringSplitOptions.None)[1];
					foreach (string user in userList.Split(new string[] { ",", " and " }, StringSplitOptions.RemoveEmptyEntries))
					{
						if (!string.IsNullOrWhiteSpace(user))
						{
							bannedIPs.Add(user.Trim());
						}
					}
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			bannedIPs.Sort();
			return bannedIPs;
		}

		public string DeOP(string user)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're revoking operator status from.");
			}
			string cmd = string.Format(TonkaCommands.CMD_DEOP_USER, user);
			string result = SendCommand(cmd);
			return result;
		}

		public string OP(string user)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're granting operator status to.");
			}
			string cmd = string.Format(TonkaCommands.CMD_OP_USER, user);
			string result = SendCommand(cmd);
			return result;
		}

		public string Kick(string user, string reason = "")
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're granting operator status to.");
			}
			string cmd = string.Empty;
			if (!string.IsNullOrWhiteSpace(reason))
			{
				cmd = string.Format(TonkaCommands.CMD_KICK_USER_REASON, user, reason);
			}
			else
			{
				cmd = string.Format(TonkaCommands.CMD_KICK_USER, user);
			}
			string result = SendCommand(cmd);
			return result;
		}

		public string PardonUser(string user)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're pardoning.");
			}
			string cmd = string.Format(TonkaCommands.CMD_PARDON, user);
			string result = SendCommand(cmd);
			return result;
		}

		public string PardonIP(string ipAddress)
		{
			if (string.IsNullOrWhiteSpace(ipAddress))
			{
				throw new ArgumentOutOfRangeException("ipAddress", "You must provide the IP Address you're pardoning.");
			}
			string cmd = string.Format(TonkaCommands.CMD_PARDON_IP, ipAddress);
			string result = SendCommand(cmd);
			return result;
		}

		public string SaveAll()
		{
			string cmd = TonkaCommands.CMD_SAVE_ALL;
			string result = SendCommand(cmd);
			return result;
		}

		public string WhitelistAdd(string user)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're adding to the whitelist.");
			}
			string cmd = string.Format(TonkaCommands.CMD_WHITELIST_ADD, user);
			string result = SendCommand(cmd);
			return result;
		}

		public string WhitelistRemove(string user)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're removing from the whitelist.");
			}
			string cmd = string.Format(TonkaCommands.CMD_WHITELIST_REMOVE, user);
			string result = SendCommand(cmd);
			return result;
		}

		public IEnumerable<string> GetWhitelist()
		{
			List<string> whitelistUsers = new List<string>();
			try
			{
				string listCommand = SendCommand(TonkaCommands.CMD_WHITELIST_LIST);

				if (listCommand.Contains(":") || listCommand.Contains("\r\n") || listCommand.Contains("\n"))
				{
					string userList = listCommand.Split(new string[] { ":", "\r\n", "\n" }, 2, StringSplitOptions.None)[1];
					foreach (string user in userList.Split(new string[] { ",", " and " }, StringSplitOptions.RemoveEmptyEntries))
					{
						if (!string.IsNullOrWhiteSpace(user))
						{
							whitelistUsers.Add(user.Trim());
						}
					}
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			whitelistUsers.Sort();
			return whitelistUsers;
		}

		public string SetWhitelist(bool enabled)
		{
			if (enabled)
			{
				string cmd = TonkaCommands.CMD_WHITELIST_ON;
				string result = SendCommand(cmd);
				return result;
			}
			else
			{
				string cmd = TonkaCommands.CMD_WHITELIST_OFF;
				string result = SendCommand(cmd);
				return result;
			}
		}

		public string ReloadWhitelist()
		{
			string cmd = TonkaCommands.CMD_WHITELIST_RELOAD;
			string result = SendCommand(cmd);
			return result;
		}

		public string ToggleDownfall()
		{
			string cmd = TonkaCommands.CMD_TOGGLE_DOWNFALL;
			string result = SendCommand(cmd);
			return result;
		}

		public string Give(string user, int dataValue, int amount = 1, int damageValue = 0)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're giving items to.");
			}
			if (dataValue <= 0)
			{
				throw new ArgumentOutOfRangeException("dataValue", "You must provide a valid data value for the block/item id.");
			}
			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException("amount", "You must provide an amount that is greater than or equal to 1.");
			}
			if (damageValue < 0)
			{
				throw new ArgumentOutOfRangeException("damageValue", "You must provide a damage value that is greater than or equal to 0.");
			}
			string cmd = string.Format(TonkaCommands.CMD_GIVE, user, dataValue, amount, damageValue);
			string result = SendCommand(cmd);
			return result;
		}

		public string Enchant(string user, Enchantments enchantmentId, int enchantmentLevel = 1)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're enchanting.");
			}
			if (enchantmentLevel < 1 || enchantmentLevel > 5)
			{
				throw new ArgumentOutOfRangeException("dataValue", "You must provide an enchantment level between 1 and 5.");
			}
			string cmd = string.Format(TonkaCommands.CMD_ENCHANT, user, EnumUtils.GetEnumDefaultValue(enchantmentId), enchantmentLevel);
			string result = SendCommand(cmd);
			return result;
		}

		public string Effect(string user, PotionEffects effectId, int duration = 30, int amplifier = 0)
		{
			string cmd = string.Empty;
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user you're effecting.");
			}
			if (duration <= 0 || duration > 1000000)
			{
				throw new ArgumentOutOfRangeException("duration", "You must provide a duration value between 1 and 1,000,000.");
			}
			if (amplifier < 0)
			{
				throw new ArgumentOutOfRangeException("amplifier", "You must provide an amplifier value greater than 0.");
			}
			else if (amplifier == 0)
			{
				cmd = string.Format(TonkaCommands.CMD_EFFECT_SECONDS, user, EnumUtils.GetEnumDefaultValue(effectId), duration);
			}
			else
			{
				cmd = string.Format(TonkaCommands.CMD_EFFECT_SECONDS_AMPD, user, EnumUtils.GetEnumDefaultValue(effectId), duration, amplifier);
			}
			string result = SendCommand(cmd);
			return result;
		}


		public IEnumerable<string> ScoreboardObjectivesList()
		{
			List<string> results = new List<string>();
			string cmd = TonkaCommands.CMD_SCOREBOARD_OBJ_LIST;
			string listCommand = SendCommand(cmd);

			if (listCommand.Contains(":") || listCommand.Contains("\r\n") || listCommand.Contains("\n"))
			{
				string resultList = listCommand.Split(new string[] { ":", "\r\n", "\n" }, 2, StringSplitOptions.None)[1];
				foreach (string result in resultList.Split(new string[] { ",", " and " }, StringSplitOptions.RemoveEmptyEntries))
				{
					if (!string.IsNullOrWhiteSpace(result))
					{
						results.Add(result.Trim());
					}
				}
			}

			return results;
		}

		public string ScoreboardObjectivesAdd(string objectiveName, ScoreboardCriteria criteria, string displayName = "")
		{
			if (string.IsNullOrWhiteSpace(objectiveName))
			{
				throw new ArgumentNullException("objectiveName", "You must provide the objective name.");
			}

			string cmd = string.Empty;
			if (!string.IsNullOrWhiteSpace(displayName))
			{
				cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_OBJ_ADD_2, objectiveName, EnumUtils.GetEnumDefaultValue(criteria), displayName);
			}
			else
			{
				cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_OBJ_ADD, objectiveName, EnumUtils.GetEnumDefaultValue(criteria));
			}
			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardObjectivesRemove(string objectiveName)
		{
			if (string.IsNullOrWhiteSpace(objectiveName))
			{
				throw new ArgumentNullException("objectiveName", "You must provide the objective name.");
			}

			string cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_OBJ_REMOVE, objectiveName);
			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardObjectivesSetDisplay(ScoreboardSlots slot, string objectiveName = "")
		{
			string cmd = string.Empty;
			if (!string.IsNullOrWhiteSpace(objectiveName))
			{
				cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_OBJ_SETDISPLAY_2, EnumUtils.GetEnumDefaultValue(slot), objectiveName);
			}
			else
			{
				cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_OBJ_SETDISPLAY, EnumUtils.GetEnumDefaultValue(slot));
			}
			string result = SendCommand(cmd);
			return result;
		}


		public IEnumerable<string> ScoreboardPlayersList(string user = "")
		{
			List<string> results = new List<string>();
			string cmd = string.Empty;
			if (!string.IsNullOrWhiteSpace(user))
			{
				cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_PLAYERS_LIST_2, user);
			}
			else
			{
				cmd = TonkaCommands.CMD_SCOREBOARD_PLAYERS_LIST;
			}
			string listCommand = SendCommand(cmd);

			if (listCommand.Contains(":") || listCommand.Contains("\r\n") || listCommand.Contains("\n"))
			{
				string resultList = listCommand.Split(new string[] { ":", "\r\n", "\n" }, 2, StringSplitOptions.None)[1];
				foreach (string result in resultList.Split(new string[] { ",", " and " }, StringSplitOptions.RemoveEmptyEntries))
				{
					if (!string.IsNullOrWhiteSpace(result))
					{
						results.Add(result.Trim());
					}
				}
			}
			return results;
		}

		public string ScoreboardPlayersSet(string user, string objectiveName, int score)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user.");
			}
			if (string.IsNullOrWhiteSpace(objectiveName))
			{
				throw new ArgumentNullException("objectiveName", "You must provide the objective name.");
			}

			string cmd = string.Empty;

			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_PLAYERS_SET, user, objectiveName, score);

			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardPlayersAdd(string user, string objectiveName, int count)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user.");
			}
			if (string.IsNullOrWhiteSpace(objectiveName))
			{
				throw new ArgumentNullException("objectiveName", "You must provide the objective name.");
			}
			if (count < 1)
			{
				throw new ArgumentOutOfRangeException("count", "You must provide a value greater than or equal to 1.");
			}

			string cmd = string.Empty;
			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_PLAYERS_ADD, user, objectiveName, count);
			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardPlayersRemove(string user, string objectiveName, int count)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user.");
			}
			if (string.IsNullOrWhiteSpace(objectiveName))
			{
				throw new ArgumentNullException("objectiveName", "You must provide the objective name.");
			}
			if (count < 1)
			{
				throw new ArgumentOutOfRangeException("count", "You must provide a value greater than or equal to 1.");
			}

			string cmd = string.Empty;
			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_PLAYERS_REMOVE, user, objectiveName, count);
			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardPlayersReset(string user)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user.");
			}

			string cmd = string.Empty;
			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_PLAYERS_REMOVE, user);
			string result = SendCommand(cmd);
			return result;
		}

		public IEnumerable<string> ScoreboardTeamsList(string teamName = "")
		{
			List<string> results = new List<string>();
			string cmd = string.Empty;

			if (string.IsNullOrWhiteSpace(teamName))
			{
				cmd = TonkaCommands.CMD_SCOREBOARD_TEAMS_LIST;
			}
			else
			{
				cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_TEAMS_LIST_2, teamName);
			}

			string listCommand = SendCommand(cmd);

			if (listCommand.Contains(":") || listCommand.Contains("\r\n") || listCommand.Contains("\n"))
			{
				string resultList = listCommand.Split(new string[] { ":", "\r\n", "\n" }, 2, StringSplitOptions.None)[1];
				foreach (string result in resultList.Split(new string[] { ",", " and " }, StringSplitOptions.RemoveEmptyEntries))
				{
					if (!string.IsNullOrWhiteSpace(result))
					{
						results.Add(result.Trim());
					}
				}
			}

			return results;
		}

		public string ScoreboardTeamsAdd(string teamName, string displayName = "")
		{
			if (string.IsNullOrWhiteSpace(teamName))
			{
				throw new ArgumentNullException("teamName", "You must provide the team name.");
			}

			string cmd = string.Empty;

			if (!string.IsNullOrWhiteSpace(displayName))
			{
				cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_TEAMS_ADD_2, teamName, displayName);
			}
			else
			{
				cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_TEAMS_ADD, teamName);
			}

			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardTeamsRemove(string teamName)
		{
			if (string.IsNullOrWhiteSpace(teamName))
			{
				throw new ArgumentNullException("teamName", "You must provide the team name.");
			}

			string cmd = string.Empty;
			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_TEAMS_REMOVE, teamName);
			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardTeamsEmpty(string teamName)
		{
			if (string.IsNullOrWhiteSpace(teamName))
			{
				throw new ArgumentNullException("teamName", "You must provide the team name.");
			}

			string cmd = string.Empty;
			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_TEAMS_EMPTY, teamName);
			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardTeamsJoin(string teamName, string user)
		{
			if (string.IsNullOrWhiteSpace(teamName))
			{
				throw new ArgumentNullException("teamName", "You must provide the team name.");
			}
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user.");
			}

			string cmd = string.Empty;
			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_TEAMS_JOIN, teamName, user);
			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardTeamsLeave(string user)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user.");
			}

			string cmd = string.Empty;
			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_TEAMS_LEAVE, user);
			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardTeamsOptionColor(string teamName, ScoreboardTeamColors color)
		{
			if (string.IsNullOrWhiteSpace(teamName))
			{
				throw new ArgumentNullException("teamName", "You must provide the team name.");
			}

			string cmd = string.Empty;
			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_TEAMS_OPT_COLOR, teamName, EnumUtils.GetEnumDefaultValue(color));
			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardTeamsOptionFriendlyFire(string teamName, bool friendlyFire)
		{
			if (string.IsNullOrWhiteSpace(teamName))
			{
				throw new ArgumentNullException("teamName", "You must provide the team name.");
			}

			string cmd = string.Empty;
			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_TEAMS_OPT_FRIENDLYFIRE, teamName, friendlyFire.ToString().ToLower());
			string result = SendCommand(cmd);
			return result;
		}

		public string ScoreboardTeamsOptionSeeFriendlyInvisibles(string teamName, bool seeFriendlyInvisibles)
		{
			if (string.IsNullOrWhiteSpace(teamName))
			{
				throw new ArgumentNullException("teamName", "You must provide the team name.");
			}

			string cmd = string.Empty;
			cmd = string.Format(TonkaCommands.CMD_SCOREBOARD_TEAMS_OPT_SEEFRIENDLYINVISIBLES, teamName, seeFriendlyInvisibles.ToString().ToLower());
			string result = SendCommand(cmd);
			return result;
		}


		public string Clear(string user)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user.");
			}
			string cmd = string.Format(TonkaCommands.CMD_CLEAR_PLAYER, user);
			string result = SendCommand(cmd);
			return result;
		}

		public string Clear(string user, int dataValue)
		{
			if (string.IsNullOrWhiteSpace(user))
			{
				throw new ArgumentNullException("user", "You must provide the user.");
			}
			if (dataValue <= 0)
			{
				throw new ArgumentOutOfRangeException("dataValue", "You must provide a valid data value for the block/item id.");
			}
			string cmd = string.Format(TonkaCommands.CMD_CLEAR_PLAYER_ITEM, user, dataValue);
			string result = SendCommand(cmd);
			return result;
		}




	}
}
