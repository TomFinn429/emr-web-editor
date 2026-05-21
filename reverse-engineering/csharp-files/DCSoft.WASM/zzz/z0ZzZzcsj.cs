namespace zzz;

internal class z0ZzZzcsj
{
	private readonly z0ZzZzxhj z0yek;

	private readonly double z0uek;

	private readonly z0ZzZzwdj z0iek;

	private readonly double z0oek;

	private readonly double z0pek;

	private readonly z0ZzZzcwj z0mek;

	private readonly double z0nek;

	internal double z0eek()
	{
		return z0nek;
	}

	internal z0ZzZzcsj(z0ZzZzddj p0, z0ZzZzcwj p1)
		: this(p0, p1, new z0ZzZzhsj(p0.z0tek().z0iek()))
	{
	}

	internal z0ZzZzcwj z0rek()
	{
		return z0mek;
	}

	internal double z0tek()
	{
		return z0oek;
	}

	internal virtual double z0eek(z0ZzZzzdj p0)
	{
		return p0.z0yek() * z0pek;
	}

	internal double z0eek(int p0)
	{
		double result = 0.0;
		if (p0 > 0)
		{
			double num = z0yek.z0ldk(z0uek);
			result = ((p0 == 1) ? (z0iek.z0rek(z0uek) + z0iek.z0tek(z0uek)) : ((double)p0 * num));
			result += z0oek * 3.0 / 4.0;
		}
		return result;
	}

	internal z0ZzZzcsj(z0ZzZzddj p0, z0ZzZzcwj p1, z0ZzZzxhj p2)
	{
		z0iek = p0.z0tek().z0iek();
		z0uek = p0.z0eek();
		z0yek = p2;
		z0nek = p1.z0pek() * z0uek;
		z0oek = p1.z0mek() * z0uek;
		z0mek = new z0ZzZzcwj(p1);
		z0pek = z0uek / 1000.0;
	}
}
