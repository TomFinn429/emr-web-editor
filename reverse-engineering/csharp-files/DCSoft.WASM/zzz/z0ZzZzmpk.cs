using System;
using System.Collections.Generic;

namespace zzz;

public static class z0ZzZzmpk
{
	public static int z0eek(int p0)
	{
		if (p0 <= 0)
		{
			return 0;
		}
		return (p0 + 2) / 3 * 4;
	}

	public static int[] z0rek(int p0)
	{
		List<int> list = new List<int>();
		for (int i = 1; i <= p0; i++)
		{
			if (p0 % i == 0)
			{
				list.Add(i);
			}
		}
		return list.ToArray();
	}

	public static z0ZzZzpdh z0eek(z0ZzZzpdh p0, z0ZzZzpdh p1, double p2)
	{
		if (p0.z0rek() == p1.z0rek() && p0.z0tek() == p1.z0tek())
		{
			return p1;
		}
		double num = (p1.z0rek() - p0.z0rek()) * (p1.z0rek() - p0.z0rek()) + (p1.z0tek() - p0.z0tek()) * (p1.z0tek() - p0.z0tek());
		num = Math.Sqrt(num);
		double num2 = Math.Atan2(p1.z0tek() - p0.z0tek(), p1.z0rek() - p0.z0rek());
		num2 -= p2;
		z0ZzZzpdh z0yek = z0ZzZzpdh.z0yek;
		z0yek.z0eek((float)((double)p0.z0rek() + num * Math.Cos(num2)));
		z0yek.z0rek((float)((double)p0.z0tek() + num * Math.Sin(num2)));
		return z0yek;
	}

	public static int z0eek(int p0, int p1, bool p2)
	{
		if (!p2)
		{
			return p0 & ~p1;
		}
		return p0 | p1;
	}

	public static z0ZzZzxdh z0eek(z0ZzZzxdh p0, z0ZzZzxdh p1, bool p2)
	{
		if (p1.z0rek() <= 0f || p1.z0tek() <= 0f)
		{
			if (p1.z0rek() <= 0f)
			{
				p1.z0eek(Math.Min(p0.z0rek(), p1.z0rek()));
			}
			if (p1.z0tek() <= 0f)
			{
				p1.z0rek(Math.Min(p0.z0tek(), p1.z0tek()));
			}
			return p1;
		}
		if (p1.z0rek() > p0.z0rek() || p1.z0tek() > p0.z0tek())
		{
			if (p2)
			{
				double num = Math.Min(p0.z0rek() / p1.z0rek(), p0.z0tek() / p1.z0tek());
				return new z0ZzZzxdh((float)((double)p1.z0rek() * num), (float)((double)p1.z0tek() * num));
			}
			return new z0ZzZzxdh(Math.Min(p1.z0rek(), p0.z0rek()), Math.Min(p1.z0tek(), p0.z0tek()));
		}
		return p1;
	}
}
