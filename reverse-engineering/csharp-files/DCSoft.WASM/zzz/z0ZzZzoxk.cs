namespace zzz;

internal static class z0ZzZzoxk
{
	internal static z0ZzZzxdh z0eek(z0ZzZzxdh p0, float p1, float p2)
	{
		if (p1 == p2)
		{
			return p0;
		}
		double p3 = z0eek(p1, p2);
		return new z0ZzZzxdh(z0eek(p0.z0rek(), p3), z0eek(p0.z0tek(), p3));
	}

	internal static float z0eek(float p0, float p1, float p2)
	{
		if (p1 == p2)
		{
			return p0;
		}
		double p3 = z0eek(p1, p2);
		return z0eek(p0, p3);
	}

	private static float z0eek(float p0, double p1)
	{
		return (float)((double)p0 * p1) + 0f;
	}

	private static double z0eek(float p0, float p1)
	{
		return (double)p1 / (double)p0;
	}
}
