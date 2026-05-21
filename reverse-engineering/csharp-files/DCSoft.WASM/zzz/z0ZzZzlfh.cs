using System;
using System.Collections.Generic;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzlfh
{
	private z0ZzZzenj z0mek;

	private static Dictionary<string, Type> z0nek;

	private z0ZzZztmj z0bek = new z0ZzZztmj();

	private static z0ZzZzlfh z0vek;

	public z0ZzZzlfh()
	{
		z0tek().z0rek(typeof(z0ZzZzlfh), this);
	}

	public LinkListProviderList z0eek()
	{
		LinkListProviderList linkListProviderList = (LinkListProviderList)z0tek().z0eek(typeof(LinkListProviderList));
		if (linkListProviderList == null)
		{
			linkListProviderList = new LinkListProviderList();
			z0tek().z0rek(typeof(LinkListProviderList), linkListProviderList);
		}
		return linkListProviderList;
	}

	static z0ZzZzlfh()
	{
		z0vek = null;
		z0nek = new Dictionary<string, Type>();
	}

	public static void z0eek(Type p0, string p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		z0ZzZzqgh.z0eek(p0);
		z0ZzZzafh.z0yek(p0, p1);
	}

	public static Type z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("typeName");
		}
		Type type = null;
		if (!z0nek.TryGetValue(p0, out type))
		{
			Type[] array = z0ZzZzqgh.z0eek();
			foreach (Type type2 in array)
			{
				if (string.Compare(type2.Name, p0, true) == 0 || string.Compare(type2.FullName, p0, true) == 0)
				{
					type = type2;
					break;
				}
			}
			z0nek[p0] = type;
		}
		return type;
	}

	public z0ZzZzenj z0rek()
	{
		if (z0mek == null)
		{
			z0mek = new z0ZzZzenj();
		}
		return z0mek;
	}

	public z0ZzZzmvj z0tek()
	{
		return z0ZzZzmvj.z0eek();
	}

	public z0ZzZztmj z0yek()
	{
		if (z0bek == null)
		{
			z0bek = new z0ZzZztmj();
		}
		return z0bek;
	}

	public void z0eek(z0ZzZztmj p0)
	{
		z0bek = p0;
	}

	internal static z0ZzZzlfh z0uek()
	{
		return z0vek;
	}

	public static void z0eek(z0ZzZzlfh p0)
	{
		z0vek = p0;
	}

	public void z0eek(z0ZzZzenj p0)
	{
		z0mek = p0;
	}

	public static z0ZzZzlfh z0iek()
	{
		if (z0vek == null)
		{
			z0vek = new z0ZzZzlfh();
		}
		return z0vek;
	}

	public static void z0eek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		z0ZzZzqgh.z0eek(p0);
	}

	public z0ZzZzivj z0oek()
	{
		z0ZzZzivj z0ZzZzivj2 = (z0ZzZzivj)z0tek().z0eek(typeof(z0ZzZzivj));
		if (z0ZzZzivj2 == null)
		{
			z0ZzZzivj2 = new z0ZzZzivj();
			z0tek().z0rek(typeof(z0ZzZzivj), z0ZzZzivj2);
		}
		return z0ZzZzivj2;
	}

	public z0ZzZzmjh z0pek()
	{
		z0ZzZzmjh z0ZzZzmjh2 = (z0ZzZzmjh)z0tek().z0eek(typeof(z0ZzZzmjh));
		if (z0ZzZzmjh2 == null)
		{
			z0ZzZzmjh2 = new z0ZzZzbvj();
			z0tek().z0rek(typeof(z0ZzZzmjh), z0ZzZzmjh2);
		}
		return z0ZzZzmjh2;
	}

	public static bool z0eek(z0ZzZzomj p0, XTextElement p1, z0ZzZzakh p2)
	{
		return true;
	}
}
