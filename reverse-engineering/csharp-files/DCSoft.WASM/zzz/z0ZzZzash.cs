namespace zzz;

internal sealed class z0ZzZzash
{
	private readonly z0ZzZzfah z0tek;

	private readonly z0ZzZziah z0uek;

	private int z0iek;

	private int z0oek;

	private z0ZzZzyah[] z0pek;

	private void z0eek()
	{
		int num = z0oek * 2 + 1;
		z0ZzZzyah[] array = z0pek;
		z0ZzZzyah[] array2 = new z0ZzZzyah[num + 1];
		for (int i = 0; i < array.Length; i++)
		{
			z0ZzZzyah z0ZzZzyah2 = array[i];
			while (z0ZzZzyah2 != null)
			{
				int num2 = z0ZzZzyah2.z0uek_jiejie20260327142557() & num;
				z0ZzZzyah obj = z0ZzZzyah2.z0pek;
				z0ZzZzyah2.z0pek = array2[num2];
				array2[num2] = z0ZzZzyah2;
				z0ZzZzyah2 = obj;
			}
		}
		z0pek = array2;
		z0oek = num;
	}

	public z0ZzZzyah z0eek(string p0, string p1, string p2, z0ZzZzaqh p3)
	{
		if (p0 == null)
		{
			p0 = string.Empty;
		}
		if (p2 == null)
		{
			p2 = string.Empty;
		}
		int num = z0ZzZzyah.z0eek(p1);
		for (z0ZzZzyah z0ZzZzyah2 = z0pek[num & z0oek]; z0ZzZzyah2 != null; z0ZzZzyah2 = z0ZzZzyah2.z0pek)
		{
			if (z0ZzZzyah2.z0uek_jiejie20260327142557() == num && ((object)z0ZzZzyah2.z0yek() == p1 || z0ZzZzyah2.z0yek().Equals(p1)) && ((object)z0ZzZzyah2.z0oek() == p0 || z0ZzZzyah2.z0oek().Equals(p0)) && ((object)z0ZzZzyah2.z0rek() == p2 || z0ZzZzyah2.z0rek().Equals(p2)) && z0ZzZzyah2.z0eek(p3))
			{
				return z0ZzZzyah2;
			}
		}
		return null;
	}

	public z0ZzZzyah z0rek(string p0, string p1, string p2, z0ZzZzaqh p3)
	{
		if (p0 == null)
		{
			p0 = string.Empty;
		}
		if (p2 == null)
		{
			p2 = string.Empty;
		}
		int num = z0ZzZzyah.z0eek(p1);
		for (z0ZzZzyah z0ZzZzyah2 = z0pek[num & z0oek]; z0ZzZzyah2 != null; z0ZzZzyah2 = z0ZzZzyah2.z0pek)
		{
			if (z0ZzZzyah2.z0uek_jiejie20260327142557() == num && ((object)z0ZzZzyah2.z0yek() == p1 || z0ZzZzyah2.z0yek().Equals(p1)) && ((object)z0ZzZzyah2.z0oek() == p0 || z0ZzZzyah2.z0oek().Equals(p0)) && ((object)z0ZzZzyah2.z0rek() == p2 || z0ZzZzyah2.z0rek().Equals(p2)) && z0ZzZzyah2.z0eek(p3))
			{
				return z0ZzZzyah2;
			}
		}
		p0 = z0uek.z0nf(p0);
		p1 = z0uek.z0nf(p1);
		p2 = z0uek.z0nf(p2);
		int num2 = num & z0oek;
		z0ZzZzyah z0ZzZzyah3 = z0ZzZzyah.z0eek(p0, p1, p2, num, z0tek, z0pek[num2], p3);
		z0pek[num2] = z0ZzZzyah3;
		if (z0iek++ == z0oek)
		{
			z0eek();
		}
		return z0ZzZzyah3;
	}

	public z0ZzZzash(z0ZzZzfah p0)
	{
		z0tek = p0;
		z0uek = p0.z0tek();
		z0pek = new z0ZzZzyah[64];
		z0oek = 63;
	}
}
