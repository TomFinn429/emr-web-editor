namespace zzz;

internal class z0ZzZzodj : z0ZzZzygj
{
	private z0ZzZzjgj z0pek;

	private readonly string z0nek;

	internal byte[] z0eek()
	{
		return z0pek.z0eek();
	}

	internal int z0eek(z0ZzZzjgj p0, int p1)
	{
		z0bfk();
		int num = z0iek();
		if (num == 0)
		{
			z0pek.z0oek(0);
			num = 4;
		}
		p0.z0eek(z0nek);
		int num2 = 0;
		byte[] array = z0tek();
		int num3 = array.Length / 4;
		int i = 0;
		int num4 = 0;
		for (; i < num3; i++)
		{
			int num5 = array[num4++] << 24;
			num5 += array[num4++] << 16;
			num5 += array[num4++] << 8;
			num5 += array[num4++];
			num2 += num5;
		}
		p0.z0oek(num2);
		p0.z0oek(p1);
		p0.z0oek(num);
		return array.Length;
	}

	internal string z0rek()
	{
		return z0nek;
	}

	protected override void z0ygk(bool p0)
	{
		if (z0pek != null)
		{
			z0pek.Dispose();
			z0pek = null;
		}
	}

	internal byte[] z0tek()
	{
		return z0pek.z0vek();
	}

	protected z0ZzZzjgj z0yek()
	{
		z0pek.Dispose();
		z0pek = new z0ZzZzjgj();
		return z0pek;
	}

	protected virtual void z0bfk()
	{
	}

	protected z0ZzZzjgj z0uek()
	{
		return z0pek;
	}

	internal z0ZzZzodj(string p0, z0ZzZzjgj p1)
	{
		z0nek = p0;
		z0pek = p1;
	}

	internal static z0ZzZzodj z0eek(string p0, z0ZzZzjgj p1)
	{
		if (p1.z0mek() == 0)
		{
			return new z0ZzZzodj(p0, p1);
		}
		if (p0 == z0ZzZzkdj.z0bek)
		{
			return new z0ZzZzkdj(p1);
		}
		if (p0 == z0ZzZzfaj.z0uek)
		{
			return new z0ZzZzfaj(p1);
		}
		if (p0 == z0ZzZzgaj.z0oek)
		{
			return new z0ZzZzgaj(p1);
		}
		if (p0 == "CFF ")
		{
			return new z0ZzZztsj(p1);
		}
		if (p0 == z0ZzZztdj.z0uek)
		{
			return new z0ZzZztdj(p1);
		}
		if (p0 == z0ZzZzyfj.z0yek)
		{
			return new z0ZzZzyfj(p1);
		}
		if (p0 == z0ZzZzqdj.z0tek)
		{
			return new z0ZzZzqdj(p1);
		}
		if (p0 == z0ZzZzydj.z0zek)
		{
			return new z0ZzZzydj(p1);
		}
		if (p0 == z0ZzZzidj.z0iek)
		{
			return new z0ZzZzidj(p1);
		}
		if (p0 == z0ZzZzsdj.z0tek)
		{
			return new z0ZzZzsdj(p1);
		}
		if (p0 == z0ZzZzgdj.z0cek)
		{
			return new z0ZzZzgdj(p1);
		}
		if (p0 == z0ZzZzfdj.z0tek)
		{
			return new z0ZzZzfdj(p1);
		}
		return new z0ZzZzodj(p0, p1);
	}

	internal int z0iek()
	{
		return z0pek.z0mek();
	}
}
