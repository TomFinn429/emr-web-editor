using System;

namespace zzz;

internal static class z0ZzZzhwh
{
	public static bool z0eek(string p0, out Guid p1)
	{
		return Guid.TryParse(p0, out p1);
	}

	public static z0ZzZzswh z0eek(char[] p0, int p1, int p2, out int p3)
	{
		p3 = 0;
		if (p2 == 0)
		{
			return (z0ZzZzswh)3;
		}
		bool flag = p0[p1] == '-';
		if (flag)
		{
			if (p2 == 1)
			{
				return (z0ZzZzswh)3;
			}
			p1++;
			p2--;
		}
		int num = p1 + p2;
		for (int i = p1; i < num; i++)
		{
			int num2 = p0[i] - 48;
			if (num2 < 0 || num2 > 9)
			{
				return (z0ZzZzswh)3;
			}
			int num3 = 10 * p3 - num2;
			if (num3 > p3)
			{
				for (i++; i < num; i++)
				{
					num2 = p0[i] - 48;
					if (num2 < 0 || num2 > 9)
					{
						return (z0ZzZzswh)3;
					}
				}
				return (z0ZzZzswh)2;
			}
			p3 = num3;
		}
		if (!flag)
		{
			if (p3 == -2147483648)
			{
				return (z0ZzZzswh)2;
			}
			p3 = -p3;
		}
		return (z0ZzZzswh)1;
	}

	public static z0ZzZzswh z0eek(char[] p0, int p1, int p2, out long p3)
	{
		p3 = 0L;
		if (p2 == 0)
		{
			return (z0ZzZzswh)3;
		}
		bool flag = p0[p1] == '-';
		if (flag)
		{
			if (p2 == 1)
			{
				return (z0ZzZzswh)3;
			}
			p1++;
			p2--;
		}
		int num = p1 + p2;
		for (int i = p1; i < num; i++)
		{
			int num2 = p0[i] - 48;
			if (num2 < 0 || num2 > 9)
			{
				return (z0ZzZzswh)3;
			}
			long num3 = 10 * p3 - num2;
			if (num3 > p3)
			{
				for (i++; i < num; i++)
				{
					num2 = p0[i] - 48;
					if (num2 < 0 || num2 > 9)
					{
						return (z0ZzZzswh)3;
					}
				}
				return (z0ZzZzswh)2;
			}
			p3 = num3;
		}
		if (!flag)
		{
			if (p3 == -9223372036854775808L)
			{
				return (z0ZzZzswh)2;
			}
			p3 = -p3;
		}
		return (z0ZzZzswh)1;
	}
}
