using System;
using System.Collections.Generic;
using System.Reflection;

namespace zzz;

public static class z0ZzZzcyk<ET> where ET : Enum
{
	private class z0pmk
	{
		public readonly ET z0eek;

		public readonly string z0rek;

		public readonly long z0tek;

		public z0pmk(long p0, ET p1, string p2)
		{
			z0tek = p0;
			z0eek = p1;
			z0rek = p2;
		}
	}

	private static readonly z0pmk[] z0tek;

	private static readonly bool z0yek;

	private static readonly z0pmk[] z0uek;

	private static readonly ET z0iek;

	private static readonly bool z0pek;

	private static readonly Type z0mek;

	private static readonly Dictionary<string, ET> z0nek;

	private static readonly string z0bek;

	private static readonly z0pmk z0vek;

	static z0ZzZzcyk()
	{
		z0mek = typeof(ET);
		z0yek = Attribute.GetCustomAttribute(z0mek, typeof(FlagsAttribute), false) != null;
		z0nek = new Dictionary<string, ET>();
		List<z0pmk> list = new List<z0pmk>();
		long num = 0L;
		FieldInfo[] fields = z0mek.GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			string name = fieldInfo.Name;
			z0pmk z0pmk = new z0pmk(Convert.ToInt64(fieldInfo.GetValue(null)), (ET)fieldInfo.GetValue(null), name);
			if (string.Compare(fieldInfo.Name, "all", true) == 0)
			{
				z0vek = z0pmk;
			}
			list.Add(z0pmk);
			z0nek[name] = (ET)fieldInfo.GetValue(null);
			if (z0yek)
			{
				num |= z0pmk.z0tek;
			}
			else if (z0pmk.z0tek > num)
			{
				num = z0pmk.z0tek;
			}
		}
		z0pek = list.Count == 0;
		if (list.Count > 0)
		{
			z0iek = list[0].z0eek;
			z0bek = list[0].z0rek;
		}
		z0tek = list.ToArray();
		if (list.Count <= 0)
		{
			return;
		}
		int num2 = Math.Min((int)num + 1, 257);
		if (num2 < 0)
		{
			num2 = 257;
		}
		z0uek = new z0pmk[num2];
		foreach (z0pmk item in list)
		{
			if (item.z0tek >= 0 && item.z0tek < num2)
			{
				z0uek[item.z0tek] = item;
			}
		}
	}

	public static ET z0eek(string p0)
	{
		if (z0pek)
		{
			return default(ET);
		}
		if (string.IsNullOrEmpty(p0) || z0bek == p0)
		{
			return z0iek;
		}
		ET result = default(ET);
		if (z0nek.TryGetValue(p0, out result))
		{
			return result;
		}
		result = (ET)Enum.Parse(z0mek, p0, true);
		z0nek[p0] = result;
		return result;
	}

	public static string z0rek(ET p0)
	{
		if (z0pek)
		{
			return string.Empty;
		}
		object obj = z0iek;
		if (p0.CompareTo(obj) == 0)
		{
			return z0bek;
		}
		if (z0vek != null)
		{
			object obj2 = z0vek.z0eek;
			if (p0.CompareTo(obj2) == 0)
			{
				return z0vek.z0rek;
			}
		}
		if (z0uek != null)
		{
			long num = ((IConvertible)p0).ToInt64((IFormatProvider?)null);
			if (num >= 0 && num < z0uek.Length)
			{
				if (z0uek[num] != null)
				{
					return z0uek[num].z0rek;
				}
				string text = p0.ToString();
				z0uek[num] = new z0pmk(num, p0, text);
				z0nek[text] = p0;
				return text;
			}
		}
		return p0.ToString();
	}
}
