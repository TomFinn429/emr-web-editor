using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzuwj
{
	private readonly double z0yek;

	private readonly double z0uek;

	internal z0ZzZzuwj(double p0, double p1)
	{
		z0uek = p0;
		z0yek = p1;
	}

	internal double z0rek()
	{
		return z0yek;
	}

	internal double z0tek()
	{
		return z0uek;
	}

	internal static z0ZzZzqaj z0eek(IEnumerable<z0ZzZzuwj> p0)
	{
		List<double> list = new List<double>();
		foreach (z0ZzZzuwj item in p0)
		{
			list.Add(item.z0tek());
			list.Add(item.z0rek());
		}
		return new z0ZzZzqaj(list);
	}
}
