using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzbdj
{
	private readonly bool z0uek;

	private readonly z0ZzZzzck z0iek;

	private readonly short z0pek;

	private readonly List<int> z0cek;

	internal int z0eek()
	{
		return z0iek.z0tek + 2;
	}

	internal void z0eek(z0ZzZzjgj p0)
	{
		p0.z0eek(z0pek);
		p0.z0pek().z0eek(z0iek);
	}

	internal z0ZzZzbdj(z0ZzZzuxk p0, int p1, int p2)
	{
		int num = p0.z0uek();
		z0pek = p0.z0iek();
		z0iek = p0.z0tek(p1 - 2);
		if (z0pek >= 0)
		{
			return;
		}
		z0cek = new List<int>();
		p0.z0rek(num + 10);
		ushort num2 = 0;
		do
		{
			num2 = (ushort)p0.z0pek();
			int num3 = p0.z0pek();
			if (num3 >= p2)
			{
				z0uek = true;
			}
			z0cek.Add(num3);
			if ((num2 & 1) != 0)
			{
				p0.z0eek(4);
			}
			else
			{
				p0.z0eek(2);
			}
			if ((num2 & 8) != 0)
			{
				p0.z0eek(2);
			}
			else if ((num2 & 0x40) != 0)
			{
				p0.z0eek(4);
			}
			else if ((num2 & 0x80) != 0)
			{
				p0.z0eek(8);
			}
		}
		while ((num2 & 0x20) != 0);
	}

	internal IEnumerable<int> z0rek()
	{
		return z0cek;
	}

	internal bool z0tek()
	{
		if (z0pek != 0)
		{
			return z0uek;
		}
		return true;
	}
}
