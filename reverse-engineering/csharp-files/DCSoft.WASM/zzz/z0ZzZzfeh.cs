namespace zzz;

internal static class z0ZzZzfeh
{
	public static string z0rek = "南京都昌信息科技有限公司提示";

	public static z0ZzZzxwh z0eek(z0ZzZzjeh p0, string p1, string p2, z0ZzZzdeh p3, z0ZzZzaeh p4, z0ZzZzseh p5)
	{
		if (z0ZzZzhbj.JSProvider == null)
		{
			return (z0ZzZzxwh)7;
		}
		return z0ZzZzhbj.JSProvider.z0glk(p1, p2, p3, p4, p5);
	}

	public static z0ZzZzxwh z0eek(z0ZzZzjeh p0, string p1, string p2, z0ZzZzdeh p3, z0ZzZzaeh p4)
	{
		return z0eek(p0, p1, p2, p3, p4, (z0ZzZzseh)0);
	}

	public static z0ZzZzxwh z0eek(z0ZzZzjeh p0, string p1, string p2)
	{
		return z0eek(p0, p1, p2, (z0ZzZzdeh)0, (z0ZzZzaeh)8, (z0ZzZzseh)0);
	}

	public static z0ZzZzxwh z0eek(z0ZzZzjeh p0, string p1)
	{
		return z0eek(p0, p1, z0rek, (z0ZzZzdeh)0, (z0ZzZzaeh)8, (z0ZzZzseh)0);
	}

	public static z0ZzZzxwh z0eek(string p0)
	{
		return z0eek(null, p0, z0rek, (z0ZzZzdeh)0, (z0ZzZzaeh)8, (z0ZzZzseh)0);
	}
}
