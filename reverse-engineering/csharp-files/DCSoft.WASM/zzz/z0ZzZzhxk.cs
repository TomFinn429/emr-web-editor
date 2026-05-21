using System.Collections.Generic;

namespace zzz;

internal static class z0ZzZzhxk
{
	internal static EqualityComparer<object> z0rek = EqualityComparer<object>.Default;

	internal static int z0eek(int p0, int p1, int p2, int p3)
	{
		return z0eek(z0eek(p0, p1), z0eek(p2, p3));
	}

	internal static int z0eek(int p0, int p1, int p2)
	{
		return z0eek(z0eek(p0, p1), p2);
	}

	internal static int z0eek(int p0, int p1)
	{
		return ((p0 << 5) + p0) ^ p1;
	}
}
