using System;

namespace zzz;

internal static class z0ZzZztej
{
	internal static int z0eek(double p0, double p1, double p2)
	{
		double num = p0 - p1;
		if (Math.Abs(num) <= p2)
		{
			return 0;
		}
		if (!(num > 0.0))
		{
			return -1;
		}
		return 1;
	}
}
