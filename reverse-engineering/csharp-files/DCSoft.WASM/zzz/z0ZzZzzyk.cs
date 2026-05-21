using System;
using System.Collections.Generic;
using System.Reflection;

namespace zzz;

public class z0ZzZzzyk
{
	private Type z0rek;

	private readonly z0ZzZzxyk z0tek;

	private static readonly Dictionary<Type, z0ZzZzzyk> z0yek = new Dictionary<Type, z0ZzZzzyk>();

	private readonly Dictionary<string, object> z0uek;

	private readonly bool z0oek;

	private readonly z0ZzZzxyk[] z0pek;

	private object z0mek;

	private readonly z0ZzZzxyk[] z0nek;

	public static z0ZzZzzyk z0eek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("t");
		}
		if (!p0.IsEnum)
		{
			throw new ArgumentException(p0.FullName);
		}
		z0ZzZzzyk z0ZzZzzyk2 = null;
		if (!z0yek.TryGetValue(p0, out z0ZzZzzyk2))
		{
			z0ZzZzzyk2 = new z0ZzZzzyk(p0);
			z0yek.Add(p0, z0ZzZzzyk2);
		}
		return z0ZzZzzyk2;
	}

	private z0ZzZzzyk(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("t");
		}
		z0rek = p0;
		if (Attribute.GetCustomAttribute(p0, typeof(FlagsAttribute), false) != null)
		{
			z0oek = true;
		}
		z0uek = new Dictionary<string, object>();
		List<z0ZzZzxyk> list = new List<z0ZzZzxyk>();
		long num = 0L;
		FieldInfo[] fields = p0.GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			z0ZzZzxyk z0ZzZzxyk2 = new z0ZzZzxyk(Convert.ToInt64(fieldInfo.GetValue(null)), fieldInfo.GetValue(null), fieldInfo.Name);
			if (string.Compare(fieldInfo.Name, "all", true) == 0)
			{
				z0tek = z0ZzZzxyk2;
			}
			list.Add(z0ZzZzxyk2);
			z0uek[fieldInfo.Name] = fieldInfo.GetValue(null);
			if (z0oek)
			{
				num |= z0ZzZzxyk2.z0tek();
			}
			else if (z0ZzZzxyk2.z0tek() > num)
			{
				num = z0ZzZzxyk2.z0tek();
			}
		}
		if (list.Count > 0)
		{
			z0mek = list[0].z0rek();
		}
		z0nek = list.ToArray();
		if (list.Count <= 0)
		{
			return;
		}
		int num2 = Math.Min((int)num + 1, 257);
		if (num2 < 0)
		{
			num2 = 257;
		}
		z0pek = new z0ZzZzxyk[num2];
		foreach (z0ZzZzxyk item in list)
		{
			if (item.z0tek() >= 0 && item.z0tek() < num2)
			{
				z0pek[item.z0tek()] = item;
			}
		}
	}

	public string z0eek(object p0)
	{
		if (z0tek != null && z0tek.z0rek().Equals(p0))
		{
			return z0tek.z0eek();
		}
		if (z0pek != null)
		{
			int num = (int)p0;
			if (num >= 0 && num < z0pek.Length)
			{
				if (z0pek[num] != null)
				{
					return z0pek[num].z0eek();
				}
				string text = p0.ToString();
				z0pek[num] = new z0ZzZzxyk(num, Enum.ToObject(z0rek, num), text);
				return text;
			}
		}
		return p0.ToString();
	}

	public object z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return z0mek;
		}
		if (z0uek != null)
		{
			object result = null;
			if (z0uek.TryGetValue(p0, out result))
			{
				return result;
			}
		}
		return Enum.Parse(z0rek, p0);
	}

	public bool z0eek()
	{
		return z0oek;
	}

	public static string z0eek(Type p0, object p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("enumType");
		}
		z0ZzZzzyk z0ZzZzzyk2 = z0eek(p0);
		if (z0ZzZzzyk2 == null)
		{
			throw new NotSupportedException(p0.FullName);
		}
		return z0ZzZzzyk2.z0eek(p1);
	}

	public static object z0eek(Type p0, string p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("enumType");
		}
		z0ZzZzzyk z0ZzZzzyk2 = z0eek(p0);
		if (z0ZzZzzyk2 == null)
		{
			throw new NotSupportedException(p0.FullName);
		}
		return z0ZzZzzyk2.z0eek(p1);
	}
}
