using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzlkj
{
	private readonly z0ZzZzugj z0rek;

	private readonly IDictionary<zzz.z0ZzZzjxk<int, int, z0ZzZzcfh, z0ZzZziwj>, z0ZzZzrwj> z0tek = new Dictionary<zzz.z0ZzZzjxk<int, int, z0ZzZzcfh, z0ZzZziwj>, z0ZzZzrwj>();

	internal z0ZzZzrwj z0eek(z0ZzZzsxk p0, z0ZzZziwj p1)
	{
		zzz.z0ZzZzjxk<int, int, z0ZzZzcfh, z0ZzZziwj> z0ZzZzjxk2 = new zzz.z0ZzZzjxk<int, int, z0ZzZzcfh, z0ZzZziwj>(p0.z0rek().ToArgb(), p0.z0tek().ToArgb(), p0.z0eek_jiejie20260327142557(), p1);
		if (!z0tek.TryGetValue(z0ZzZzjxk2, out var z0ZzZzrwj2))
		{
			z0ZzZzrwj2 = z0ZzZzkkj.z0eek(p0).z0eek(p1, z0rek);
			z0tek.Add(z0ZzZzjxk2, z0ZzZzrwj2);
		}
		return z0ZzZzrwj2;
	}

	internal z0ZzZzlkj(z0ZzZzugj p0)
	{
		z0rek = p0;
	}
}
