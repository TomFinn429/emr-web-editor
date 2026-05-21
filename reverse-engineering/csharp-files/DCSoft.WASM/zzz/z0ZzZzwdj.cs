using System;

namespace zzz;

internal class z0ZzZzwdj
{
	private readonly double z0yek;

	internal readonly double z0uek;

	private readonly z0ZzZziwj z0iek;

	private readonly double z0oek;

	private readonly double z0pek;

	internal z0ZzZziwj z0eek()
	{
		return z0iek;
	}

	internal z0ZzZzwdj(z0ZzZzzfj p0)
	{
		z0ZzZzkdj z0ZzZzkdj2 = p0.z0lrk();
		if (z0ZzZzkdj2 == null)
		{
			z0uek = 2048.0;
			z0iek = new z0ZzZziwj(0.0, 0.0, 0.0, 0.0);
		}
		else
		{
			z0uek = z0ZzZzkdj2.z0eek();
			double num = 1000.0 / z0uek;
			z0iek = new z0ZzZziwj(Math.Round((double)z0ZzZzkdj2.z0uek() * num), Math.Round((double)z0ZzZzkdj2.z0iek() * num), Math.Round((double)z0ZzZzkdj2.z0rek() * num), Math.Round((double)z0ZzZzkdj2.z0yek() * num));
		}
		z0ZzZzydj z0ZzZzydj2 = p0.z0uek();
		z0ZzZzgdj z0ZzZzgdj2 = p0.z0pek();
		if (z0ZzZzydj2 != null)
		{
			if (z0ZzZzydj2.z0yek())
			{
				z0pek = (double)z0ZzZzydj2.z0pek() / z0uek;
				z0yek = (double)(-z0ZzZzydj2.z0oek()) / z0uek;
				z0oek = z0pek + z0yek + (double)z0ZzZzydj2.z0eek() / z0uek;
				return;
			}
			z0pek = (double)z0ZzZzydj2.z0iek() / z0uek;
			z0yek = (double)z0ZzZzydj2.z0tek() / z0uek;
			z0oek = z0pek + z0yek;
			if (z0ZzZzgdj2 != null)
			{
				z0oek += z0ZzZzgsj.z0rek(0.0, (double)(z0ZzZzgdj2.z0rek() - (z0ZzZzydj2.z0iek() + z0ZzZzydj2.z0tek() - (z0ZzZzgdj2.z0eek() - z0ZzZzgdj2.z0yek()))) / z0uek);
			}
		}
		else if (z0ZzZzgdj2 != null)
		{
			z0pek = (double)z0ZzZzgdj2.z0eek() / z0uek;
			z0yek = (double)(-z0ZzZzgdj2.z0yek()) / z0uek;
			z0oek = z0pek + z0yek + (double)z0ZzZzgdj2.z0rek() / z0uek;
		}
	}

	internal double z0rek()
	{
		return z0yek * 1000.0;
	}

	internal double z0eek(double p0)
	{
		return z0oek * p0;
	}

	internal double z0tek()
	{
		return z0pek * 1000.0;
	}

	internal double z0rek(double p0)
	{
		return z0pek * p0;
	}

	internal double z0tek(double p0)
	{
		return z0yek * p0;
	}
}
