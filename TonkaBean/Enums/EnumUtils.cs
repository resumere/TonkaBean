using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Resumere.TonkaBean.Enums
{
	public class EnumUtils
	{
		public static object GetEnumDefaultValue<T>(string value, bool caseSensitive = false) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enumerated type");
			}

			Type enumType = typeof(T);

			Array enumValArray = Enum.GetValues(enumType);
			List<T> enumValList = new List<T>(enumValArray.Length);

			foreach (int val in enumValArray)
			{
				enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
			}

			try
			{
				T enumVal;
				if (!caseSensitive)
				{
					enumVal = enumValList.Where<T>(c => c.ToString().Equals(value, StringComparison.CurrentCultureIgnoreCase)).First<T>();
				}
				else
				{
					enumVal = enumValList.Where<T>(c => c.ToString().Equals(value)).First<T>();
				}

				FieldInfo fi = enumVal.GetType().GetField(enumVal.ToString());

				DefaultValueAttribute[] attributes = (DefaultValueAttribute[])fi.GetCustomAttributes(typeof(DefaultValueAttribute), false);
				if (attributes != null && attributes.Length > 0)
				{
					return attributes[0].Value;
				}
				else
				{
					return value.ToString();
				}
			}
			catch (Exception e)
			{
				throw new Exception(string.Format("{0} - {1}", enumValList.Count(), typeof(T)), e);
			}
		}

		public static string GetEnumDescription<T>(string value, bool caseSensitive = false) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enumerated type");
			}

			Type enumType = typeof(T);

			Array enumValArray = Enum.GetValues(enumType);
			List<T> enumValList = new List<T>(enumValArray.Length);

			foreach (int val in enumValArray)
			{
				enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
			}

			try
			{
				T enumVal;
				if (!caseSensitive)
				{
					enumVal = enumValList.Where<T>(c => c.ToString().Equals(value, StringComparison.CurrentCultureIgnoreCase)).First<T>();
				}
				else
				{
					enumVal = enumValList.Where<T>(c => c.ToString().Equals(value)).First<T>();
				}

				FieldInfo fi = enumVal.GetType().GetField(enumVal.ToString());

				DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

				if (attributes != null && attributes.Length > 0)
				{
					return attributes[0].Description;
				}
				else
				{
					return value.ToString();
				}
			}
			catch (Exception e)
			{
				throw new Exception(string.Format("{0} - {1}", enumValList.Count(), typeof(T)), e);
			}
		}

		public static string GetEnumDescription(Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

			if (attributes != null && attributes.Length > 0)
			{
				return attributes[0].Description;
			}
			else
			{
				return value.ToString();
			}
		}

		public static object GetEnumDefaultValue(Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			DefaultValueAttribute[] attributes = (DefaultValueAttribute[])fi.GetCustomAttributes(typeof(DefaultValueAttribute), false);

			if (attributes != null && attributes.Length > 0)
			{ return attributes[0].Value; }
			else
			{ return value.ToString(); }
		}


		public static object GetEnumEnchantmentMinLevel(Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			EnchantmentAttribute[] attributes = (EnchantmentAttribute[])fi.GetCustomAttributes(typeof(EnchantmentAttribute), false);

			if (attributes != null && attributes.Length > 0)
			{ return attributes[0].MinLevel; }
			else
			{ return 0; }
		}

		public static object GetEnumEnchantmentMaxLevel(Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			EnchantmentAttribute[] attributes = (EnchantmentAttribute[])fi.GetCustomAttributes(typeof(EnchantmentAttribute), false);

			if (attributes != null && attributes.Length > 0)
			{ return attributes[0].MaxLevel; }
			else
			{ return 0; }
		}


		public static IEnumerable<Enum> EnumToList(Enum enumType)
		{
			Type type = enumType.GetType();
			return EnumUtils.EnumToList(type);
		}

		public static IEnumerable<Enum> EnumToList(Type type)
		{
			//Type type = typeof(T);

			// Can't use generic type constraints on value types,
			// so have to do check like this
			if (!type.IsEnum)
			{
				throw new ArgumentException("T must be of type System.Enum");
			}

			Array enumValArray = Enum.GetValues(type);
			List<Enum> enumValList = new List<Enum>(enumValArray.Length);

			foreach (int val in enumValArray)
			{
				enumValList.Add((Enum)Enum.Parse(type, val.ToString()));
			}

			return enumValList;
		}

		public static IEnumerable<T> EnumToList<T>()
		{
			Type type = typeof(T);

			// Can't use generic type constraints on value types,
			// so have to do check like this
			if (!type.IsEnum)
			{
				throw new ArgumentException("T must be of type System.Enum");
			}

			Array enumValArray = Enum.GetValues(type);
			List<T> enumValList = new List<T>(enumValArray.Length);

			foreach (int val in enumValArray)
			{
				enumValList.Add((T)Enum.Parse(type, val.ToString()));
			}

			return enumValList;
		}

		public static T GetValueFromDescription<T>(string description)
		{
			var type = typeof(T);
			if (!type.IsEnum)
			{
				throw new ArgumentException("T must be of type System.Enum");
			}

			foreach (var field in type.GetFields())
			{
				var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
				if (attribute != null)
				{
					if (attribute.Description == description)
					{
						return (T)field.GetValue(null);
					}
				}
				else
				{
					if (field.Name == description)
					{
						return (T)field.GetValue(null);
					}
				}
			}
			throw new ArgumentException("Not found.", "description");
		}

		public static T GetValueFromDefaultValue<T>(string defaultValue)
		{
			var type = typeof(T);
			if (!type.IsEnum)
			{
				throw new ArgumentException("T must be of type System.Enum");
			}

			foreach (var field in type.GetFields())
			{
				var attribute = Attribute.GetCustomAttribute(field, typeof(DefaultValueAttribute)) as DefaultValueAttribute;
				if (attribute != null)
				{
					String attributeValue = attribute.Value.ToString();
					if (defaultValue.Equals(attributeValue))
					{
						return (T)field.GetValue(null);
					}
				}
				else
				{
					if (field.Name == defaultValue)
					{
						return (T)field.GetValue(null);
					}
				}
			}
			throw new ArgumentException("Not found.", "description");
		}
	}
}
