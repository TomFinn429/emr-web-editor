namespace zzz;

public static class z0ZzZzmej
{
	internal static string[] z0tek = new string[3] { "宋体", "SimSun-ExtB", "Calibri" };

	internal static bool z0eek(int p0)
	{
		if (p0 >= 56320)
		{
			return p0 <= 57343;
		}
		return false;
	}

	public static byte[] z0eek(string p0, string p1)
	{
		z0ZzZzzfj z0ZzZzzfj2 = z0ZzZztlj.z0eek(new z0ZzZzpej(p0, 1f));
		if (z0ZzZzzfj2 != null)
		{
			byte[] result = z0ZzZzzfj2.z0rek(new z0ZzZzzgj(z0ZzZzzfj2, null).z0rdk(p1, (z0ZzZzcdj)0).z0rek_jiejie20260327142557());
			if (!z0ZzZzzfj2.z0jrk)
			{
				z0ZzZzzfj2.Dispose();
			}
			return result;
		}
		return null;
	}

	internal static bool z0rek(int p0)
	{
		if (p0 >= 55296)
		{
			return p0 <= 56319;
		}
		return false;
	}
}
