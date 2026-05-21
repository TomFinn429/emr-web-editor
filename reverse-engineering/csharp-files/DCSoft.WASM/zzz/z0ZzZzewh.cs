using System;

namespace zzz;

internal static class z0ZzZzewh
{
	public static bool z0eek(string p0, char p1)
	{
		if (p0.Length > 0)
		{
			return p0[p0.Length - 1] == p1;
		}
		return false;
	}

	public static bool z0eek(char p0)
	{
		return char.IsHighSurrogate(p0);
	}

	public static bool z0rek(char p0)
	{
		return char.IsLowSurrogate(p0);
	}

	public static string z0eek(string p0, IFormatProvider p1, object p2, object p3)
	{
		return z0eek(p0, p1, new object[2] { p2, p3 });
	}

	public static string z0eek(string p0, IFormatProvider p1, object p2)
	{
		return z0eek(p0, p1, new object[1] { p2 });
	}

	private static string z0eek(string p0, IFormatProvider p1, params object[] p2)
	{
		z0ZzZzrwh.z0eek(p0, "format");
		return string.Format(p1, p0, p2);
	}
}
