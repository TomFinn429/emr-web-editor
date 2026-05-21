using System.Collections.Generic;

namespace zzz;

internal static class z0ZzZzgsj
{
	internal static double z0rek(double p0, double p1)
	{
		if (!(p0 > p1))
		{
			return p1;
		}
		return p0;
	}

	internal static z0ZzZziwj z0rek(params z0ZzZzywj[] p0)
	{
		return z0eek(p0);
	}

	internal static z0ZzZziwj z0eek(IList<z0ZzZzywj> p0)
	{
		int count = p0.Count;
		if (count == 0)
		{
			return null;
		}
		z0ZzZzywj z0ZzZzywj2 = p0[0];
		double num = z0ZzZzywj2.z0eek();
		double num2 = num;
		double num3 = z0ZzZzywj2.z0rek();
		double num4 = num3;
		for (int i = 1; i < count; i++)
		{
			z0ZzZzywj2 = p0[i];
			double num5 = z0ZzZzywj2.z0eek();
			if (num5 < num)
			{
				num = num5;
			}
			else if (num5 > num2)
			{
				num2 = num5;
			}
			double num6 = z0ZzZzywj2.z0rek();
			if (num6 < num3)
			{
				num3 = num6;
			}
			else if (num6 > num4)
			{
				num4 = num6;
			}
		}
		return new z0ZzZziwj(new z0ZzZzywj(num, num3), new z0ZzZzywj(num2, num4));
	}
}
