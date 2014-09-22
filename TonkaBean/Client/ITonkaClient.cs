using System.Collections.Generic;
using Resumere.TonkaBean.Enums;

namespace Resumere.TonkaBean.Client
{
	public interface ITonkaClient
	{

		IEnumerable<string> GetCurrentUsers();

		string SetTime(int time);

		string SetTime(GameTime time);

		string AddTime(int time);

		string BanUser(string userid, string reason = "");

		string BanIP(string userid, string reason = "");

		string SetDefaultGameMode(GameMode mode);

		string SetPlayerGameMode(string user, GameMode mode);

		string SetDifficulty(Difficulty difficulty);

		string SetGameRule(GameRules rule, bool flag);

		void Say(string message);

		string TeleportPlayer(string fromUser, string toUser);

		string TeleportPlayer(string user, long x, long y, long z);

		string TeleportPlayer(string user, double x, double y, double z);

		string ToggleDownfall();

		string SetWeather(Weather weather);

		string SetWeather(Weather weather, int duration);

		IEnumerable<string> GetBannedUsers();
		IEnumerable<string> GetBannedIPs();

		string DeOP(string user);

		string OP(string user);

		string Kick(string user, string reason = "");

		string PardonUser(string user);

		string PardonIP(string ipAddress);

		string SaveAll();

		string WhitelistAdd(string user);
		string WhitelistRemove(string user);

		IEnumerable<string> GetWhitelist();

		string SetWhitelist(bool enabled);

		string ReloadWhitelist();

		string Give(string user, int dataValue, int amount = 1, int damageValue = 0);

		string Enchant(string user, Enchantments enchantmentId, int enchantmentLevel = 1);

		string Effect(string user, PotionEffects effectId, int duration = 30, int amplifier = 0);

		string Clear(string user);

		string Clear(string user, int dataValue);

		IEnumerable<string> ScoreboardObjectivesList();

		string ScoreboardObjectivesAdd(string objectiveName, ScoreboardCriteria criteria, string displayName = "");

		string ScoreboardObjectivesRemove(string objectiveName);

		string ScoreboardObjectivesSetDisplay(ScoreboardSlots slot, string objectiveName = "");

		IEnumerable<string> ScoreboardPlayersList(string user = "");

		string ScoreboardPlayersSet(string user, string objectiveName, int score);

		string ScoreboardPlayersAdd(string user, string objectiveName, int count);

		string ScoreboardPlayersRemove(string user, string objectiveName, int count);

		string ScoreboardPlayersReset(string user);

		IEnumerable<string> ScoreboardTeamsList(string teamName = "");

		string ScoreboardTeamsAdd(string teamName, string displayName = "");

		string ScoreboardTeamsRemove(string teamName);

		string ScoreboardTeamsEmpty(string teamName);

		string ScoreboardTeamsJoin(string teamName, string user);

		string ScoreboardTeamsLeave(string user);

		string ScoreboardTeamsOptionColor(string teamName, ScoreboardTeamColors color);

		string ScoreboardTeamsOptionFriendlyFire(string teamName, bool friendlyFire);

		string ScoreboardTeamsOptionSeeFriendlyInvisibles(string teamName, bool seeFriendlyInvisibles);

	}
}
