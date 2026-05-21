using System;

namespace zzz;

internal static class z0ZzZzdyk
{
	public static z0ZzZzpdh z0eek(z0ZzZzndh p0, double p1)
	{
		double num = p1 * Math.PI / 180.0;
		float num2 = p0.z0pek() + p0.z0iek() / 2;
		float num3 = p0.z0mek() + p0.z0oek() / 2;
		float num4 = p0.z0iek() / 2;
		float num5 = p0.z0oek() / 2;
		double num6 = Math.Tan(num);
		double num7 = (double)(num4 * num5) / Math.Sqrt((double)(num5 * num5) + (double)(num4 * num4) * num6 * num6);
		double num8 = num7 * num6;
		if (p1 > 90.0 && p1 < 270.0)
		{
			return new z0ZzZzpdh(num2 - (float)num7, num3 - (float)num8);
		}
		return new z0ZzZzpdh(num2 + (float)num7, num3 + (float)num8);
	}
}
