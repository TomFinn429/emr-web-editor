using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzyfj : z0ZzZzodj
{
	private new readonly List<z0ZzZzjfj> z0rek = new List<z0ZzZzjfj>();

	private new readonly short z0tek;

	internal new static readonly string z0yek = "cmap";

	internal z0ZzZzyfj(z0ZzZzjgj p0)
		: base(z0yek, p0)
	{
		z0ZzZzjgj z0ZzZzjgj2 = z0uek();
		z0tek = z0ZzZzjgj2.z0yek();
		short num = z0ZzZzjgj2.z0yek();
		z0rek = new List<z0ZzZzjfj>(num);
		for (int i = 0; i < num; i++)
		{
			z0ZzZzudj p1 = (z0ZzZzudj)z0ZzZzjgj2.z0yek();
			z0ZzZzxfj p2 = (z0ZzZzxfj)z0ZzZzjgj2.z0yek();
			int num2 = z0ZzZzjgj2.z0nek();
			long p3 = z0ZzZzjgj2.z0uek();
			z0ZzZzjgj2.z0eek((long)num2);
			z0rek.Add(z0ZzZzjfj.z0eek(p1, p2, (z0ZzZzhfj)z0ZzZzjgj2.z0yek(), z0ZzZzjgj2));
			z0ZzZzjgj2.z0eek(p3);
		}
	}

	protected override void z0ygk(bool p0)
	{
		base.z0ygk(p0);
		z0rek.Clear();
	}

	internal new List<z0ZzZzjfj> z0eek()
	{
		return z0rek;
	}
}
