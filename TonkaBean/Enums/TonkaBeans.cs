using System;
using System.ComponentModel;

namespace Resumere.TonkaBean.Enums
{

	[AttributeUsage(AttributeTargets.All)]
	public class EnchantmentAttribute : System.Attribute
	{
		private int minLevel;
		private int maxLevel;

		public int MinLevel
		{
			get
			{
				return minLevel;
			}
			set
			{
				this.minLevel = value;
			}
		}

		public int MaxLevel
		{
			get
			{
				return maxLevel;
			}
			set
			{
				this.maxLevel = value;
			}
		}

		public EnchantmentAttribute(int minLevel, int maxLevel)  // url is a positional parameter
		{
			this.minLevel = minLevel;
			this.maxLevel = maxLevel;
		}

	}


	public enum GameMode
	{
		[Description("Survival"), DefaultValue("survival")]
		Survival = 0,
		[Description("Creative"), DefaultValue("creative")]
		Creative = 1,
		[Description("Adventure"), DefaultValue("adventure")]
		Adventure = 2
	}

	[Serializable]
	public enum Difficulty
	{
		[Description("Peaceful"), DefaultValue("0")]
		Peaceful = 0,
		[Description("Easy"), DefaultValue("1")]
		Easy = 1,
		[Description("Normal"), DefaultValue("2")]
		Normal = 2,
		[Description("Hard"), DefaultValue("3")]
		Hard = 3
	}

	[Serializable]
	public enum GameRules
	{
		[Description("Command Block Output"), DefaultValue("commandBlockOutput")]
		CommandBlockOutput,
		[Description("Fire Spreading"), DefaultValue("doFireTick")]
		DoFireTick,
		[Description("Mobs Drop Items"), DefaultValue("doMobLoot")]
		DoMobLoot,
		[Description("Mob Spawning"), DefaultValue("doMobSpawning")]
		DoMobSpawning,
		[Description("Tile Drops"), DefaultValue("doTileDrops")]
		DoTileDrops,
		[Description("Keep Inventory"), DefaultValue("keepInventory")]
		KeepInventory,
		[Description("Mob Griefing"), DefaultValue("mobGriefing")]
		MobGriefing,
		[Description("Natural Regeneration"), DefaultValue("naturalRegeneration")]
		NaturalRegeneration,
		[Description("Daylight Cycle"), DefaultValue("doDaylightCycle")]
		DoDaylightCycle
	}

	[Serializable]
	public enum GameTime
	{
		[Description("Dawn"), DefaultValue("0")]
		Dawn = 0,
		[Description("Mid-Day"), DefaultValue("6000")]
		MidDay = 6000,
		[Description("Dusk"), DefaultValue("12000")]
		Dusk = 12000,
		[Description("Midnight"), DefaultValue("18000")]
		Midnight = 18000
	}

	[Serializable]
	public enum Weather
	{
		[Description("Clear"), DefaultValue("clear")]
		Clear,
		[Description("Rain"), DefaultValue("rain")]
		Rain,
		[Description("Rain & Thunder"), DefaultValue("thunder")]
		Thunder
	}

	[Serializable]
	public enum Limits
	{
		[Description("Min Time"), DefaultValue("0")]
		MinTime = 0,
		[Description("Max Time"), DefaultValue("24000")]
		MaxTime = 24000,
		[Description("Min Weather Time"), DefaultValue("0")]
		MinWeatherTime = 0,
		[Description("Max Weather Time"), DefaultValue("1000000")]
		MaxWeatherTime = 1000000,
		[Description("Max Level Per Command"), DefaultValue("2147483647")]
		MaxLevelPerCommand = 2147483647,
		[Description("Max Experience Per Command"), DefaultValue("2147483647")]
		MaxExpPerCommand = 2147483647
	}

	[Serializable]
	public enum Enchantments
	{
		[Description("Protection"), DefaultValue("0"), Enchantment(1, 4)]
		Protection = 0,
		[Description("Fire Protection"), DefaultValue("1"), Enchantment(1, 1)]
		FireProtection = 1,
		[Description("Feather Falling"), DefaultValue("2"), Enchantment(1, 4)]
		FeatherFalling = 2,
		[Description("Blast Protection"), DefaultValue("3"), Enchantment(1, 4)]
		BlastProtection = 3,
		[Description("Projectile Protection"), DefaultValue("4"), Enchantment(1, 4)]
		ProjectileProtection = 4,
		[Description("Respiration"), DefaultValue("5"), Enchantment(1, 3)]
		Respiration = 5,
		[Description("Aqua Affinity"), DefaultValue("6"), Enchantment(1, 1)]
		AquaAffinity = 6,
		[Description("Sharpness"), DefaultValue("16"), Enchantment(1, 5)]
		Sharpness = 16,
		[Description("Smite"), DefaultValue("17"), Enchantment(1, 5)]
		Smite = 17,
		[Description("Bane of Arthropods"), DefaultValue("18"), Enchantment(1, 5)]
		BaneOfArthropods = 18,
		[Description("Knockback"), DefaultValue("19"), Enchantment(1, 2)]
		Knockback = 19,
		[Description("Fire Aspect"), DefaultValue("20"), Enchantment(1, 2)]
		FireAspect = 20,
		[Description("Looting"), DefaultValue("21"), Enchantment(1, 3)]
		Looting = 21,
		[Description("Efficiency"), DefaultValue("32"), Enchantment(1, 5)]
		Efficiency = 32,
		[Description("Silk Touch"), DefaultValue("33"), Enchantment(1, 1)]
		SilkTouch = 33,
		[Description("Unbreaking"), DefaultValue("34"), Enchantment(1, 3)]
		Unbreaking = 34,
		[Description("Fortune"), DefaultValue("35"), Enchantment(1, 3)]
		Fortune = 35,
		[Description("Power"), DefaultValue("48"), Enchantment(1, 5)]
		Power = 48,
		[Description("Punch"), DefaultValue("49"), Enchantment(1, 2)]
		Punch = 49,
		[Description("Flame"), DefaultValue("50"), Enchantment(1, 1)]
		Flame = 50,
		[Description("Infinity"), DefaultValue("51"), Enchantment(1, 1)]
		Infinity = 51
	}

	[Serializable]
	public enum PotionEffects
	{
		[Description("Speed"), DefaultValue("1")]
		Speed = 1,
		[Description("Slowness"), DefaultValue("2")]
		Slowness = 2,
		[Description("Haste"), DefaultValue("3")]
		Haste = 3,
		[Description("Mining Fatigue"), DefaultValue("4")]
		MiningFatigue = 4,
		[Description("Strength"), DefaultValue("5")]
		Strength = 5,
		[Description("Instant Health"), DefaultValue("6")]
		InstantHealth = 6,
		[Description("Instant Damage"), DefaultValue("7")]
		InstantDamage = 7,
		[Description("Jump Boost"), DefaultValue("8")]
		JumpBoost = 8,
		[Description("Nausea"), DefaultValue("9")]
		Nausea = 9,
		[Description("Regeneration"), DefaultValue("10")]
		Regeneration = 10,
		[Description("Resistance"), DefaultValue("11")]
		Resistance = 11,
		[Description("Fire Resistance"), DefaultValue("12")]
		FireResistance = 12,
		[Description("Water Breathing"), DefaultValue("13")]
		WaterBreathing = 13,
		[Description("Invisibility"), DefaultValue("14")]
		Invisibility = 14,
		[Description("Blindness"), DefaultValue("15")]
		Blindness = 15,
		[Description("Night Vision"), DefaultValue("16")]
		NightVision = 16,
		[Description("Hunger"), DefaultValue("17")]
		Hunger = 17,
		[Description("Weakness"), DefaultValue("18")]
		Weakness = 18,
		[Description("Poison"), DefaultValue("19")]
		Poison = 19,
		[Description("Wither"), DefaultValue("20")]
		Wither = 20
	}


	[Serializable]
	public enum ScoreboardSlots
	{
		[Description("List"), DefaultValue("list")]
		List,
		[Description("Sidebar"), DefaultValue("sidebar")]
		Sidebar,
		[Description("Below Name"), DefaultValue("belowName")]
		BelowName
	}

	[Serializable]
	public enum ScoreboardTeamColors
	{
		[Description("Black"), DefaultValue("black")]
		Black,
		[Description("Dark Blue"), DefaultValue("dark_blue")]
		DarkBlue,
		[Description("Dark Green"), DefaultValue("dark_green")]
		DarkGreen,
		[Description("Dark Aqua"), DefaultValue("dark_aqua")]
		DarkAqua,
		[Description("Dark Red"), DefaultValue("dark_red")]
		DarkRed,
		[Description("Dark Purple"), DefaultValue("dark_purple")]
		DarkPurple,
		[Description("Gold"), DefaultValue("gold")]
		Gold,
		[Description("Gray"), DefaultValue("gray")]
		Gray,
		[Description("Dark Gray"), DefaultValue("dark_gray")]
		DarkGray,
		[Description("Blue"), DefaultValue("blue")]
		Blue,
		[Description("Green"), DefaultValue("green")]
		Green,
		[Description("Aqua"), DefaultValue("aqua")]
		Aqua,
		[Description("Red"), DefaultValue("red")]
		Red,
		[Description("Light Purple"), DefaultValue("light_purple")]
		LightPurple,
		[Description("Yellow"), DefaultValue("yellow")]
		Yellow,
		[Description("White"), DefaultValue("white")]
		White,
		[Description("Reset"), DefaultValue("reset")]
		Reset,
		[Description("Obfuscated"), DefaultValue("obfuscated")]
		Obfuscated,
		[Description("Bold"), DefaultValue("bold")]
		Bold,
		[Description("Strikethrough"), DefaultValue("strikethrough")]
		Strikethrough,
		[Description("Underline"), DefaultValue("underline")]
		Underline,
		[Description("Italic"), DefaultValue("italic")]
		Italic
	}

	[Serializable]
	public enum ScoreboardCriteria
	{
		[Description("Dummy"), DefaultValue("dummy")]
		Dummy,
		[Description("Death Count"), DefaultValue("deathCount")]
		DeathCount,
		[Description("Player Kill Count"), DefaultValue("playerKillCount")]
		PlayerKillCount,
		[Description("Total Kill Count"), DefaultValue("totalKillCount")]
		TotalKillCount,
		[Description("Health"), DefaultValue("health")]
		Health
	}


	[Serializable]
	public enum OldBlockHandling
	{
		[Description("Replace"), DefaultValue("replace")]
		Replace,
		[Description("Keep"), DefaultValue("keep")]
		Keep,
		[Description("Destroy"), DefaultValue("destroy")]
		Destroy
	}


}
