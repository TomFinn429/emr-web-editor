using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzmik
{
	private class z0lxk : IComparer<PropertyInfo>
	{
		public int Compare(PropertyInfo x, PropertyInfo y)
		{
			return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
		}
	}

	private class z0xxk
	{
		private readonly bool z0rek;

		private readonly PropertyInfo z0tek;

		private readonly bool z0yek;

		private readonly bool z0uek;

		private static Dictionary<Type, Dictionary<string, z0xxk>> z0iek = new Dictionary<Type, Dictionary<string, z0xxk>>();

		private readonly bool z0oek;

		private readonly Type z0pek;

		private static bool z0mek = false;

		private readonly string z0nek;

		private readonly object z0bek;

		private readonly string z0vek;

		public bool z0eek(object p0, object p1, bool p2)
		{
			object obj = null;
			if (p1 == null || DBNull.Value.Equals(p1))
			{
				obj = ((!z0oek) ? z0ZzZzmik.z0eek(z0pek) : z0bek);
			}
			else if (z0rek && p1 is string)
			{
				if (p2)
				{
					obj = Enum.Parse(z0pek, (string)p1, true);
				}
				else
				{
					try
					{
						obj = Enum.Parse(z0pek, (string)p1, true);
					}
					catch (Exception)
					{
						return false;
					}
				}
			}
			else if (!z0pek.IsInstanceOfType(p1))
			{
				if (p2)
				{
					obj = Convert.ChangeType(p1, z0pek);
				}
				else
				{
					try
					{
						obj = ((!z0rek) ? Convert.ChangeType(p1, z0pek) : ((!(p1 is string)) ? Enum.ToObject(z0pek, p1) : Enum.Parse(z0pek, (string)p1)));
					}
					catch (Exception)
					{
						return false;
					}
				}
			}
			else
			{
				obj = p1;
			}
			if (p2)
			{
				z0tek.SetValue(p0, obj, null);
				return true;
			}
			try
			{
				z0tek.SetValue(p0, obj, null);
				return true;
			}
			catch (Exception)
			{
			}
			return false;
		}

		public z0xxk(PropertyInfo p0)
		{
			z0nek = p0.Name;
			z0vek = p0.Name.ToLower();
			z0tek = p0;
			z0uek = p0.CanRead;
			z0yek = p0.CanWrite;
			if (z0mek && p0.PropertyType == typeof(Color))
			{
				z0oek = false;
			}
			else
			{
				DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(p0, typeof(DefaultValueAttribute), true);
				if (defaultValueAttribute == null)
				{
					z0oek = false;
				}
				else if (defaultValueAttribute.Value == null && p0.PropertyType == typeof(Color))
				{
					z0oek = false;
					z0mek = true;
				}
				else
				{
					z0oek = true;
					z0bek = defaultValueAttribute.Value;
				}
			}
			z0rek = p0.PropertyType.IsEnum;
			z0pek = p0.PropertyType;
		}

		public static z0xxk z0eek(Type p0, string p1)
		{
			if (p0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (string.IsNullOrEmpty(p1))
			{
				throw new ArgumentNullException("name");
			}
			p1 = p1.Trim().ToLower();
			Dictionary<string, z0xxk> dictionary = z0eek(p0);
			z0xxk result = null;
			if (dictionary.TryGetValue(p1, out result))
			{
				return result;
			}
			return null;
		}

		private static Dictionary<string, z0xxk> z0eek(Type p0)
		{
			if (p0 == null)
			{
				throw new ArgumentNullException("t");
			}
			Dictionary<string, z0xxk> dictionary = null;
			if (!z0iek.TryGetValue(p0, out dictionary))
			{
				dictionary = new Dictionary<string, z0xxk>();
				z0iek[p0] = dictionary;
				PropertyInfo[] properties = p0.GetProperties(BindingFlags.Instance | BindingFlags.Public);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (!propertyInfo.IsSpecialName)
					{
						dictionary[propertyInfo.Name.ToLower()] = new z0xxk(propertyInfo);
					}
				}
			}
			return dictionary;
		}
	}

	private static readonly Dictionary<Type, PropertyInfo[]> z0tek = new Dictionary<Type, PropertyInfo[]>();

	private static readonly Hashtable z0yek = new Hashtable();

	private static readonly Dictionary<PropertyInfo, object> z0uek_jiejie20260327142557 = new Dictionary<PropertyInfo, object>();

	public static bool z0eek(object p0, string p1, object p2, bool p3)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (string.IsNullOrEmpty(p1))
		{
			throw new ArgumentNullException("propertyName");
		}
		z0xxk z0xxk = z0xxk.z0eek(p0.GetType(), p1);
		if (z0xxk == null)
		{
			if (p3)
			{
				throw new ArgumentException(p0.GetType().FullName + "." + p1);
			}
			return false;
		}
		return z0xxk.z0eek(p0, p2, p3);
	}

	public static int z0eek(object p0, string p1)
	{
		if (p0 == null || p1 == null || p1.Length == 0)
		{
			return 0;
		}
		z0ZzZzsyk obj = new z0ZzZzsyk(p1);
		int num = 0;
		foreach (z0ZzZzqyk item in obj)
		{
			if (z0eek(p0, item.z0eek(), item.z0rek(), p3: false))
			{
				num++;
			}
		}
		return num;
	}

	public static object z0eek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ValueType");
		}
		if (z0yek.ContainsKey(p0))
		{
			return z0yek[p0];
		}
		if (z0yek.Count == 0)
		{
			z0yek[typeof(object)] = null;
			z0yek[typeof(byte)] = (byte)0;
			z0yek[typeof(sbyte)] = (sbyte)0;
			z0yek[typeof(short)] = (short)0;
			z0yek[typeof(ushort)] = (ushort)0;
			z0yek[typeof(int)] = 0;
			z0yek[typeof(uint)] = 0u;
			z0yek[typeof(long)] = 0L;
			z0yek[typeof(ulong)] = 0uL;
			z0yek[typeof(char)] = '\0';
			z0yek[typeof(float)] = 0f;
			z0yek[typeof(double)] = 0.0;
			z0yek[typeof(decimal)] = 0m;
			z0yek[typeof(bool)] = false;
			z0yek[typeof(string)] = null;
			z0yek[typeof(DateTime)] = DateTime.MinValue;
			z0yek[typeof(z0ZzZzodh)] = z0ZzZzodh.z0yek;
			z0yek[typeof(z0ZzZzpdh)] = z0ZzZzpdh.z0yek;
			z0yek[typeof(z0ZzZzcdh)] = z0ZzZzcdh.z0yek_jiejie20260327142557;
			z0yek[typeof(z0ZzZzxdh)] = z0ZzZzxdh.z0yek;
			z0yek[typeof(z0ZzZzndh)] = z0ZzZzndh.z0cek;
			z0yek[typeof(z0ZzZzbdh)] = z0ZzZzbdh.z0xek;
			z0yek[typeof(Color)] = Color.Transparent;
			z0yek[typeof(nint)] = IntPtr.Zero;
			z0yek[typeof(nuint)] = UIntPtr.Zero;
		}
		if (p0.IsEnum)
		{
			Array values = Enum.GetValues(p0);
			if (values != null && values.Length > 0)
			{
				object value = values.GetValue(0);
				z0yek[p0] = value;
				return value;
			}
			object obj = Activator.CreateInstance(p0);
			z0yek[p0] = obj;
			return obj;
		}
		if (p0.IsValueType)
		{
			object obj2 = Activator.CreateInstance(p0);
			z0yek[p0] = obj2;
			return obj2;
		}
		return null;
	}

	public static bool z0eek(object p0, Type p1, ref object p2)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("NewType");
		}
		if (p0 == null || DBNull.Value.Equals(p0))
		{
			if (p1.IsClass)
			{
				p2 = null;
				return true;
			}
			return false;
		}
		Type type = p0.GetType();
		if (type == p1 || type.IsSubclassOf(p1))
		{
			p2 = p0;
			return true;
		}
		try
		{
			bool flag = type == typeof(string);
			if (p1 == typeof(string))
			{
				if (flag)
				{
					p2 = (string)p0;
				}
				else
				{
					p2 = Convert.ToString(p0);
				}
				return true;
			}
			if (p1 == typeof(bool))
			{
				if (flag)
				{
					bool p3 = false;
					if (z0eek((string)p0, out p3))
					{
						p2 = p3;
						return true;
					}
					return false;
				}
				p2 = Convert.ToBoolean(p0);
				return true;
			}
			if (p1 == typeof(char))
			{
				if (flag)
				{
					string text = (string)p0;
					if (text != null && text.Length > 0)
					{
						p2 = text[0];
						return true;
					}
					return false;
				}
				p2 = Convert.ToChar(p0);
				return true;
			}
			if (p1 == typeof(byte))
			{
				if (flag)
				{
					byte b = 0;
					if (byte.TryParse((string)p0, out b))
					{
						p2 = b;
						return true;
					}
					return false;
				}
				p2 = Convert.ToByte(p0);
				return true;
			}
			if (p1 == typeof(sbyte))
			{
				if (flag)
				{
					sbyte b2 = 0;
					if (sbyte.TryParse((string)p0, out b2))
					{
						p2 = b2;
						return true;
					}
					return false;
				}
				p2 = Convert.ToSByte(p0);
				return true;
			}
			if (p1 == typeof(short))
			{
				if (flag)
				{
					short num = 0;
					if (short.TryParse((string)p0, out num))
					{
						p2 = num;
						return true;
					}
					return false;
				}
				p2 = Convert.ToInt16(p0);
				return true;
			}
			if (p1 == typeof(ushort))
			{
				if (flag)
				{
					ushort num2 = 0;
					if (ushort.TryParse((string)p0, out num2))
					{
						p2 = num2;
						return true;
					}
					return false;
				}
				p2 = Convert.ToUInt16(p0);
				return true;
			}
			if (p1 == typeof(int))
			{
				if (flag)
				{
					int num3 = 0;
					if (int.TryParse((string)p0, out num3))
					{
						p2 = num3;
						return true;
					}
					return false;
				}
				p2 = Convert.ToInt32(p0);
				return true;
			}
			if (p1 == typeof(uint))
			{
				if (flag)
				{
					uint num4 = 0u;
					if (uint.TryParse((string)p0, out num4))
					{
						p2 = num4;
						return true;
					}
					return false;
				}
				p2 = Convert.ToUInt32(p0);
				return true;
			}
			if (p1 == typeof(long))
			{
				if (flag)
				{
					long num5 = 0L;
					if (long.TryParse((string)p0, out num5))
					{
						p2 = num5;
						return true;
					}
					return false;
				}
				p2 = Convert.ToInt64(p0);
				return true;
			}
			if (p1 == typeof(ulong))
			{
				if (flag)
				{
					ulong num6 = 0uL;
					if (ulong.TryParse((string)p0, out num6))
					{
						p2 = num6;
						return true;
					}
					return false;
				}
				p2 = Convert.ToUInt64(p0);
				return true;
			}
			if (p1 == typeof(float))
			{
				if (flag)
				{
					float num7 = 0f;
					if (float.TryParse((string)p0, out num7))
					{
						p2 = num7;
						return true;
					}
					return false;
				}
				p2 = Convert.ToSingle(p0);
				return true;
			}
			if (p1 == typeof(double))
			{
				if (flag)
				{
					double num8 = 0.0;
					if (double.TryParse((string)p0, out num8))
					{
						p2 = num8;
						return true;
					}
					return false;
				}
				p2 = Convert.ToDouble(p0);
				return true;
			}
			if (p1 == typeof(decimal))
			{
				if (flag)
				{
					decimal num9 = default(decimal);
					if (decimal.TryParse((string)p0, out num9))
					{
						p2 = num9;
						return true;
					}
					return false;
				}
				p2 = Convert.ToDecimal(Convert.ToSingle(p0));
				return true;
			}
			if (p1 == typeof(DateTime))
			{
				if (flag)
				{
					DateTime result = DateTime.MinValue;
					if (DateTime.TryParse((string)p0, out result))
					{
						p2 = result;
						return true;
					}
					return false;
				}
				p2 = Convert.ToDateTime(p0);
				return true;
			}
			if (p1 == typeof(TimeSpan))
			{
				if (flag)
				{
					TimeSpan zero = TimeSpan.Zero;
					if (TimeSpan.TryParse((string)p0, out zero))
					{
						p2 = zero;
						return true;
					}
					return false;
				}
				p2 = new TimeSpan(Convert.ToInt64(p0));
				return true;
			}
			if (p1 == typeof(byte[]))
			{
				if (flag)
				{
					try
					{
						byte[] array = Convert.FromBase64String((string)p0);
						p2 = array;
						return true;
					}
					catch
					{
						return false;
					}
				}
				return false;
			}
			if (p1.IsEnum)
			{
				if (Enum.IsDefined(type, p0))
				{
					if (flag)
					{
						p2 = Enum.Parse(p1, (string)p0, true);
					}
					else
					{
						p2 = Enum.ToObject(p1, p0);
					}
					return true;
				}
				return false;
			}
			if (p0 is IConvertible)
			{
				p2 = ((IConvertible)p0).ToType(p1, null);
				return true;
			}
			p2 = Convert.ChangeType(p0, p1);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static object z0eek(PropertyInfo p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("p");
		}
		if (z0uek_jiejie20260327142557.ContainsKey(p0))
		{
			return z0uek_jiejie20260327142557[p0];
		}
		object obj = null;
		DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(p0, typeof(DefaultValueAttribute), false);
		obj = ((defaultValueAttribute == null) ? z0eek(p0.PropertyType) : defaultValueAttribute.Value);
		z0uek_jiejie20260327142557[p0] = obj;
		return obj;
	}

	public static bool z0eek(object p0, bool p1)
	{
		if (p0 is bool)
		{
			return (bool)p0;
		}
		if (p0 is string)
		{
			return z0ZzZzqik.z0eek((string)p0, p1);
		}
		if (p0 is byte)
		{
			return (byte)p0 != 0;
		}
		if (p0 is short)
		{
			return (short)p0 != 0;
		}
		if (p0 is int)
		{
			return (int)p0 != 0;
		}
		if (p0 is float)
		{
			return (float)p0 != 0f;
		}
		if (p0 is double)
		{
			return (double)p0 != 0.0;
		}
		return p1;
	}

	public static string z0rek(object p0, bool p1)
	{
		if (p0 == null)
		{
			return null;
		}
		z0ZzZzayk z0ZzZzayk2 = new z0ZzZzayk();
		z0eek(p0, p1, z0ZzZzayk2);
		return z0ZzZzayk2.ToString();
	}

	public static bool z0eek(string p0, out bool p1)
	{
		p1 = false;
		if (p0 != null)
		{
			p0 = p0.Trim();
			if (p0 == "0")
			{
				p1 = false;
				return true;
			}
			if (p0 == "1")
			{
				p1 = true;
				return true;
			}
			if (string.Compare("True", p0, StringComparison.OrdinalIgnoreCase) == 0)
			{
				p1 = true;
				return true;
			}
			if (string.Compare("False", p0, StringComparison.OrdinalIgnoreCase) == 0)
			{
				p1 = false;
				return true;
			}
		}
		return false;
	}

	public static void z0eek(object p0, bool p1, z0ZzZzayk p2)
	{
		if (p0 == null)
		{
			return;
		}
		if (p2 == null)
		{
			throw new ArgumentNullException("str");
		}
		PropertyInfo[] array = null;
		Type type = p0.GetType();
		if (z0tek.ContainsKey(type))
		{
			array = z0tek[type];
		}
		else
		{
			array = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			List<PropertyInfo> list = new List<PropertyInfo>(array);
			for (int num = list.Count - 1; num >= 0; num--)
			{
				PropertyInfo propertyInfo = list[num];
				if (!propertyInfo.CanWrite || !propertyInfo.CanRead)
				{
					list.RemoveAt(num);
				}
				else if (z0ZzZzlok.z0eek(propertyInfo))
				{
					list.RemoveAt(num);
				}
				else
				{
					ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
					if (indexParameters != null && indexParameters.Length != 0)
					{
						list.RemoveAt(num);
					}
				}
			}
			list.Sort(new z0lxk());
			array = list.ToArray();
			z0tek[type] = array;
		}
		if (array.Length == 0)
		{
			return;
		}
		PropertyInfo[] array2 = array;
		foreach (PropertyInfo propertyInfo2 in array2)
		{
			object value = propertyInfo2.GetValue(p0, null);
			if (p1)
			{
				object obj = z0eek(propertyInfo2);
				if (obj == value || object.Equals(obj, value))
				{
					continue;
				}
			}
			if (value == null)
			{
				p2.z0eek(propertyInfo2.Name, null);
			}
			if (value is Color)
			{
				p2.z0eek(propertyInfo2.Name, z0ZzZzifh.z0eek((Color)value));
			}
			else if (value is DateTime)
			{
				p2.z0eek(propertyInfo2.Name, z0ZzZzuyk.z0rek((DateTime)value));
			}
			else
			{
				p2.z0eek(propertyInfo2.Name, value.ToString());
			}
		}
	}

	public static object z0eek(object p0, Type p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("NewType");
		}
		if (p1.IsInstanceOfType(p0))
		{
			return p0;
		}
		bool flag = false;
		if (p0 is string)
		{
			flag = string.IsNullOrWhiteSpace((string)p0);
		}
		if (p0 == null || DBNull.Value.Equals(p0))
		{
			if (p1.IsClass)
			{
				return null;
			}
			return z0eek(p1);
		}
		Type type = p0.GetType();
		if (type == p1 || type.IsSubclassOf(p1))
		{
			return p0;
		}
		if (p1 == typeof(string))
		{
			if (p0 is double && z0ZzZzbok.z0eek((double)p0))
			{
				return null;
			}
			if (p0 is float && float.IsNaN((float)p0))
			{
				return null;
			}
			return Convert.ToString(p0);
		}
		if (p1 == typeof(bool))
		{
			if (p0 is string)
			{
				if (flag)
				{
					return false;
				}
				return bool.Parse((string)p0);
			}
			if (flag)
			{
				return false;
			}
			return Convert.ToBoolean(p0);
		}
		if (p1 == typeof(char))
		{
			return Convert.ToChar(p0);
		}
		if (p1 == typeof(byte))
		{
			if (flag)
			{
				return (byte)0;
			}
			return Convert.ToByte(p0);
		}
		if (p1 == typeof(sbyte))
		{
			if (flag)
			{
				return (sbyte)0;
			}
			return Convert.ToSByte(p0);
		}
		if (p1 == typeof(short))
		{
			if (flag)
			{
				return (short)0;
			}
			return Convert.ToInt16(p0);
		}
		if (p1 == typeof(ushort))
		{
			if (flag)
			{
				return (ushort)0;
			}
			return Convert.ToUInt16(p0);
		}
		if (p1 == typeof(int))
		{
			if (flag)
			{
				return 0;
			}
			return Convert.ToInt32(p0);
		}
		if (p1 == typeof(uint))
		{
			if (flag)
			{
				return 0u;
			}
			return Convert.ToUInt32(p0);
		}
		if (p1 == typeof(long))
		{
			if (flag)
			{
				return 0L;
			}
			return Convert.ToInt64(p0);
		}
		if (p1 == typeof(ulong))
		{
			if (flag)
			{
				return 0uL;
			}
			return Convert.ToUInt64(p0);
		}
		if (p1 == typeof(float))
		{
			if (flag)
			{
				return 0f;
			}
			return Convert.ToSingle(p0);
		}
		if (p1 == typeof(double))
		{
			if (flag)
			{
				return 0.0;
			}
			return Convert.ToDouble(p0);
		}
		if (p1 == typeof(decimal))
		{
			if (flag)
			{
				return 0m;
			}
			return Convert.ToDecimal(Convert.ToSingle(p0));
		}
		if (p1 == typeof(DateTime))
		{
			if (flag)
			{
				return DateTime.MinValue;
			}
			DateTime minValue = DateTime.MinValue;
			minValue = ((!type.Equals(typeof(string))) ? Convert.ToDateTime(p0) : DateTime.Parse((string)p0));
			return minValue;
		}
		if (p1 == typeof(TimeSpan))
		{
			if (flag)
			{
				return TimeSpan.Zero;
			}
			TimeSpan zero = TimeSpan.Zero;
			zero = ((!type.Equals(typeof(string))) ? TimeSpan.Parse(Convert.ToString(p0)) : TimeSpan.Parse((string)p0));
			return zero;
		}
		if (p1.IsEnum)
		{
			if (p0 is string)
			{
				return z0ZzZzzyk.z0eek(p1, (string)p0);
			}
			return Enum.ToObject(p1, Convert.ToInt32(p0));
		}
		if (p0 is IConvertible)
		{
			return ((IConvertible)p0).ToType(p1, null);
		}
		return Convert.ChangeType(p0, p1);
	}
}
