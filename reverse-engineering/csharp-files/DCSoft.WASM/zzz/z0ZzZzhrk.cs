using System;
using System.Reflection;

namespace zzz;

internal static class z0ZzZzhrk
{
	private static readonly object z0tek = null;

	private static readonly Assembly z0yek = typeof(z0ZzZzhrk).Assembly;

	public static bool z0eek(string p0, string p1)
	{
		return string.Equals(p0, p1);
	}

	public static string z0eek(object p0, object p1, object p2)
	{
		return string.Concat(p0, p1, p2);
	}

	public static string z0eek(string p0)
	{
		return p0.Trim();
	}

	public static string z0eek(ref int p0)
	{
		return p0.ToString();
	}

	public static Type z0eek(object p0)
	{
		return p0.GetType();
	}

	public static bool z0rek(string p0)
	{
		if (p0 != null)
		{
			return p0.Length == 0;
		}
		return true;
	}

	public static string z0eek(string p0, string p1, string p2)
	{
		return p0 + p1 + p2;
	}

	public static string z0rek(string p0, string p1)
	{
		return p0 + p1;
	}

	public static string z0eek(object p0, object p1)
	{
		return string.Concat(p0, p1);
	}

	public static string z0rek(object p0)
	{
		return p0.ToString();
	}
}
