namespace zzz;

internal static class z0ZzZzugh
{
	public static bool z0eek(char p0)
	{
		if ('ༀ' <= p0)
		{
			return p0 <= '\u0fff';
		}
		return false;
	}

	public static bool z0rek(char p0)
	{
		if (p0 >= '\u0f71' && p0 <= '\u0f84')
		{
			return true;
		}
		if (p0 >= '\u0f90' && p0 <= '\u0fbc')
		{
			return true;
		}
		if (p0 != '\u0f19' && p0 != '\u0f35' && p0 != '\u0f37' && p0 != '\u0f39' && p0 != '\u0f86')
		{
			return p0 == '\u0f87';
		}
		return true;
	}

	public static bool z0tek(char p0)
	{
		if (p0 == '་' || p0 == '།')
		{
			return true;
		}
		return false;
	}
}
