namespace zzz;

internal static class z0ZzZzmsh
{
	internal static bool z0eek(string p0)
	{
		int num = z0tek(p0, 0);
		if (num > 0)
		{
			return num == p0.Length;
		}
		return false;
	}

	internal static int z0rek(string p0)
	{
		return z0eek(p0, 0);
	}

	internal static int z0eek(string p0, int p1)
	{
		int i = p1;
		if (i < p0.Length)
		{
			if (!z0ZzZzzsh.z0oek(p0[i]))
			{
				return 0;
			}
			for (i++; i < p0.Length && z0ZzZzzsh.z0yek(p0[i]); i++)
			{
			}
		}
		return i - p1;
	}

	internal static int z0rek(string p0, int p1)
	{
		int i;
		for (i = p1; i < p0.Length && z0ZzZzzsh.z0yek(p0[i]); i++)
		{
		}
		return i - p1;
	}

	internal static int z0tek(string p0, int p1)
	{
		int i = p1;
		if (i < p0.Length)
		{
			if (!z0ZzZzzsh.z0oek(p0[i]) && p0[i] != ':')
			{
				return 0;
			}
			for (i++; i < p0.Length && (z0ZzZzzsh.z0yek(p0[i]) || p0[i] == ':'); i++)
			{
			}
		}
		return i - p1;
	}
}
