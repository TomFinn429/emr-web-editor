using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzhgj : z0ZzZzfgj
{
	private readonly Dictionary<byte, z0ZzZzfgj> z0eek = new Dictionary<byte, z0ZzZzfgj>();

	internal override void z0ask(byte[] p0, int p1, string p2)
	{
		int num = p0.Length - p1;
		if (num <= 0)
		{
			return;
		}
		byte b = p0[p1];
		if (z0eek.TryGetValue(b, out var z0ZzZzfgj2))
		{
			if (num == 1)
			{
				z0eek[b] = new z0ZzZzggj(p2);
			}
			else if (!z0ZzZzfgj2.z0ssk())
			{
				z0ZzZzfgj2.z0ask(p0, p1 + 1, p2);
			}
		}
		else if (num == 1)
		{
			z0eek[b] = new z0ZzZzggj(p2);
		}
		else
		{
			z0ZzZzhgj z0ZzZzhgj2 = new z0ZzZzhgj();
			z0ZzZzhgj2.z0ask(p0, p1 + 1, p2);
			z0eek[b] = z0ZzZzhgj2;
		}
	}

	internal override bool z0ssk()
	{
		return false;
	}

	internal z0ZzZzhgj()
	{
	}
}
