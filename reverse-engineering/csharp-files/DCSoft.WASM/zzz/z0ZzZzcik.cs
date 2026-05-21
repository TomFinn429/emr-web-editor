using System;
using System.Collections.Generic;

namespace zzz;

public sealed class z0ZzZzcik
{
	private readonly int z0iek;

	private readonly string z0oek;

	public static readonly object z0pek = new object();

	internal readonly Type z0mek;

	private readonly object z0nek;

	private readonly Type z0bek;

	private static readonly Dictionary<Type, Dictionary<string, z0ZzZzcik>> z0vek = new Dictionary<Type, Dictionary<string, z0ZzZzcik>>();

	public int z0eek()
	{
		return z0iek;
	}

	public Type z0rek()
	{
		return z0mek;
	}

	public Type z0tek()
	{
		return z0bek;
	}

	public string z0yek()
	{
		return z0oek;
	}

	public static z0ZzZzcik z0eek(Type p0, string p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ownerType");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("name");
		}
		foreach (Type key in z0vek.Keys)
		{
			if ((key == p0 || p0.IsSubclassOf(key)) && z0vek[key].TryGetValue(p1, out var result))
			{
				return result;
			}
		}
		return null;
	}

	public static z0ZzZzcik[] z0eek(Type p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ownerType");
		}
		List<z0ZzZzcik> list = new List<z0ZzZzcik>();
		if (p1)
		{
			if (z0vek.TryGetValue(p0, out var dictionary))
			{
				foreach (z0ZzZzcik value in dictionary.Values)
				{
					list.Add(value);
				}
			}
		}
		else
		{
			foreach (Type key in z0vek.Keys)
			{
				if (!(key == p0) && !p0.IsSubclassOf(key))
				{
					continue;
				}
				foreach (z0ZzZzcik value2 in z0vek[key].Values)
				{
					list.Add(value2);
				}
			}
		}
		return list.ToArray();
	}

	public object z0uek()
	{
		return z0nek;
	}

	public bool z0eek(object p0)
	{
		if (z0nek == z0pek)
		{
			return false;
		}
		if (z0nek is IComparable)
		{
			return ((IComparable)z0nek).CompareTo(p0) == 0;
		}
		return object.Equals(z0nek, p0);
	}

	private z0ZzZzcik(int p0, Type p1, string p2, Type p3, object p4)
	{
		z0iek = p0;
		z0mek = p1;
		z0oek = p2;
		z0bek = p3;
		z0nek = p4;
	}

	public static z0ZzZzcik z0eek(int p0, string p1, Type p2, Type p3, object p4)
	{
		if (p1 == null || p1.Trim().Length == 0)
		{
			throw new ArgumentNullException("name");
		}
		p1 = p1.Trim();
		if (p2 == null)
		{
			throw new ArgumentNullException("propertyType");
		}
		if (p3 == null)
		{
			throw new ArgumentNullException("ownerType");
		}
		if (p4 != null && !p2.IsInstanceOfType(p4))
		{
			throw new ArgumentException("bad defaultValue:" + p4);
		}
		Dictionary<string, z0ZzZzcik> dictionary = null;
		if (!z0vek.TryGetValue(p3, out dictionary))
		{
			dictionary = new Dictionary<string, z0ZzZzcik>();
			z0vek[p3] = dictionary;
		}
		if (dictionary.ContainsKey(p1))
		{
			throw new ArgumentException("Multi " + p1);
		}
		return dictionary[p1] = new z0ZzZzcik(p0, p3, p1, p2, p4);
	}
}
