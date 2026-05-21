namespace zzz;

internal class z0ZzZzdej : z0ZzZzqej
{
	internal new readonly z0ZzZzbdh z0eek;

	internal override void z0pgk(z0ZzZzmlj p0)
	{
		p0.z0oek(z0eek);
	}

	internal override z0ZzZzqej z0igk(z0ZzZzjdh p0)
	{
		z0ZzZzpdh[] p1 = z0ZzZzqej.z0eek(z0eek);
		p0.z0eek(p1);
		return new z0ZzZzdej(z0ZzZzqej.z0eek(p1));
	}

	internal z0ZzZzdej(z0ZzZzbdh p0)
	{
		z0eek = p0;
	}

	internal override z0ZzZzqej z0mgk(z0ZzZzqej p0)
	{
		if (p0 is z0ZzZzdej z0ZzZzdej2)
		{
			return new z0ZzZzdej(z0ZzZzbdh.z0tek(z0eek, z0ZzZzdej2.z0eek));
		}
		return new z0ZzZzsej(this, p0);
	}

	internal override z0ZzZzqej z0ugk()
	{
		return new z0ZzZzdej(z0eek);
	}

	internal override z0ZzZzbdh z0ogk(z0ZzZzjdh p0)
	{
		if (p0.z0iek())
		{
			return z0eek;
		}
		z0ZzZzpdh[] p1 = z0ZzZzqej.z0eek(z0eek);
		using (z0ZzZzjdh z0ZzZzjdh2 = p0.z0uek())
		{
			z0ZzZzjdh2.z0oek();
			z0ZzZzjdh2.z0eek(p1);
		}
		return z0ZzZzqej.z0eek(p1);
	}
}
