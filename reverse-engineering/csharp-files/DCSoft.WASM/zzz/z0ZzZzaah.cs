using System.Collections;

namespace zzz;

internal sealed class z0ZzZzaah : z0ZzZzpah
{
	private z0ZzZzoah z0uek;

	private int z0iek;

	private string z0oek;

	private int z0pek;

	private int z0mek;

	private readonly z0ZzZzoah z0nek;

	private string z0bek;

	private readonly string z0vek;

	private z0ZzZzoah z0eek(z0ZzZzoah p0, bool p1)
	{
		z0ZzZzoah z0ZzZzoah2 = p0;
		do
		{
			z0ZzZzoah2 = ((!p1) ? z0yek(z0ZzZzoah2) : z0rek(z0ZzZzoah2));
		}
		while (z0ZzZzoah2 != null && !z0tek(z0ZzZzoah2));
		return z0ZzZzoah2;
	}

	protected void z0eek()
	{
		try
		{
			z0eek(p0: false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void z0eek(bool p0)
	{
	}

	protected override void z0dg()
	{
		z0eek(p0: true);
	}

	public z0ZzZzoah z0eek(z0ZzZzoah p0)
	{
		z0ZzZzoah p1 = ((p0 == null) ? z0nek : p0);
		return z0eek(p1, p1: true);
	}

	private z0ZzZzoah z0eek(z0ZzZzoah p0, bool p1, int p2)
	{
		z0ZzZzoah z0ZzZzoah2 = p0;
		for (int i = 0; i < p2; i++)
		{
			z0ZzZzoah2 = z0eek(z0ZzZzoah2, p1);
			if (z0ZzZzoah2 == null)
			{
				return null;
			}
		}
		return z0ZzZzoah2;
	}

	public override int z0sf()
	{
		if (z0iek < 0)
		{
			int num = 0;
			int num2 = z0pek;
			z0ZzZzoah p = z0nek;
			while ((p = z0eek(p, p1: true)) != null)
			{
				num++;
			}
			if (num2 != z0pek)
			{
				return num;
			}
			z0iek = num;
		}
		return z0iek;
	}

	private z0ZzZzoah z0rek(z0ZzZzoah p0)
	{
		z0ZzZzoah z0ZzZzoah2 = p0.z0iek();
		if (z0ZzZzoah2 == null)
		{
			z0ZzZzoah2 = p0;
			while (z0ZzZzoah2 != null && z0ZzZzoah2 != z0nek && z0ZzZzoah2.z0qf() == null)
			{
				z0ZzZzoah2 = z0ZzZzoah2.z0ih();
			}
			if (z0ZzZzoah2 != null && z0ZzZzoah2 != z0nek)
			{
				z0ZzZzoah2 = z0ZzZzoah2.z0qf();
			}
		}
		if (z0ZzZzoah2 == z0nek)
		{
			z0ZzZzoah2 = null;
		}
		return z0ZzZzoah2;
	}

	internal int z0rek()
	{
		return z0pek;
	}

	public override z0ZzZzoah z0df(int p0)
	{
		if (z0nek == null || p0 < 0)
		{
			return null;
		}
		if (z0mek == p0)
		{
			return z0uek;
		}
		int num = p0 - z0mek;
		bool p1 = num > 0;
		if (num < 0)
		{
			num = -num;
		}
		z0ZzZzoah z0ZzZzoah2;
		if ((z0ZzZzoah2 = z0eek(z0uek, p1, num)) != null)
		{
			z0mek = p0;
			z0uek = z0ZzZzoah2;
			return z0uek;
		}
		return null;
	}

	private bool z0tek(z0ZzZzoah p0)
	{
		if (p0.z0mh() == (z0ZzZzbah)1 && (z0ZzZzosh.z0eek(z0bek, z0vek) || z0ZzZzosh.z0eek(p0.z0ph(), z0bek)) && (z0ZzZzosh.z0eek(z0oek, z0vek) || p0.z0ag() == z0oek))
		{
			return true;
		}
		return false;
	}

	public override IEnumerator GetEnumerator()
	{
		return new z0ZzZzqah(this);
	}

	private z0ZzZzoah z0yek(z0ZzZzoah p0)
	{
		z0ZzZzoah z0ZzZzoah2 = p0.z0af();
		while (z0ZzZzoah2 != null && z0ZzZzoah2.z0eek() != null)
		{
			z0ZzZzoah2 = z0ZzZzoah2.z0eek();
		}
		if (z0ZzZzoah2 == null)
		{
			z0ZzZzoah2 = p0.z0ih();
		}
		if (z0ZzZzoah2 == z0nek)
		{
			z0ZzZzoah2 = null;
		}
		return z0ZzZzoah2;
	}
}
