using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZznjj
{
	private readonly z0ZzZzugj z0rek;

	private readonly IDictionary<ulong, z0ZzZzyaj> z0tek = new Dictionary<ulong, z0ZzZzyaj>();

	private static readonly z0ZzZzuwj z0yek = new z0ZzZzuwj(0.0, 1.0);

	internal z0ZzZzyaj z0eek(Color p0, Color p1)
	{
		ulong num = (ulong)(((long)p0.ToArgb() << 32) + p1.ToArgb());
		if (!z0tek.TryGetValue(num, out var z0ZzZzyaj2))
		{
			zzz.z0ZzZzasj<z0ZzZzlqj> z0ZzZzasj2 = new zzz.z0ZzZzasj<z0ZzZzlqj>(z0rek.z0uek());
			z0ZzZzasj2.Add(new z0ZzZzdqj(z0ZzZznlj.z0eek(p0).z0rek(), z0ZzZznlj.z0eek(p1).z0rek(), 1.0, new z0ZzZzuwj[1] { z0yek }, new z0ZzZzuwj[3] { z0yek, z0yek, z0yek }));
			z0ZzZzyaj2 = new z0ZzZzyaj(new z0ZzZzywj(0.0, 0.0), new z0ZzZzywj(1.0, 0.0), z0ZzZzasj2);
			z0tek.Add(num, z0ZzZzyaj2);
		}
		return z0ZzZzyaj2;
	}

	internal z0ZzZznjj(z0ZzZzugj p0)
	{
		z0rek = p0;
	}
}
