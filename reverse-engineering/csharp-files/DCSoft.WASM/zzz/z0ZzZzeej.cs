namespace zzz;

internal class z0ZzZzeej : z0ZzZzqej
{
	private new readonly byte[] z0eek;

	private readonly bool z0rek;

	private readonly z0ZzZzpdh[] z0tek;

	internal override z0ZzZzbdh z0ogk(z0ZzZzjdh p0)
	{
		if (p0.z0iek())
		{
			return z0ZzZzqej.z0eek(z0tek);
		}
		z0ZzZzpdh[] p1 = (z0ZzZzpdh[])z0tek.Clone();
		using (z0ZzZzjdh z0ZzZzjdh2 = p0.z0uek())
		{
			z0ZzZzjdh2.z0oek();
			z0ZzZzjdh2.z0eek(p1);
		}
		return z0ZzZzqej.z0eek(p1);
	}

	internal z0ZzZzeej(z0ZzZzpdh[] p0, byte[] p1, bool p2)
	{
		z0tek = p0;
		z0eek = p1;
		z0rek = p2;
	}

	internal override z0ZzZzqej z0igk(z0ZzZzjdh p0)
	{
		z0ZzZzpdh[] p1 = (z0ZzZzpdh[])z0tek.Clone();
		p0.z0eek(p1);
		return new z0ZzZzeej(p1, z0eek, z0rek);
	}

	internal override void z0pgk(z0ZzZzmlj p0)
	{
		p0.z0rek(z0tek, z0eek, z0rek);
	}

	internal override z0ZzZzqej z0ugk()
	{
		return new z0ZzZzeej((z0ZzZzpdh[])z0tek.Clone(), z0eek, z0rek);
	}

	internal override z0ZzZzqej z0mgk(z0ZzZzqej p0)
	{
		return new z0ZzZzsej(this, p0);
	}
}
