using System;

namespace zzz;

internal class z0ZzZzpwj
{
	private double z0uek;

	private double z0iek;

	private double z0pek;

	internal z0ZzZzpwj(double p0, double p1, double p2)
	{
		z0tek(p0);
		z0rek(p1);
		z0eek(p2);
	}

	internal void z0eek(double p0)
	{
		z0eek(p0, "B");
		if (z0iek != p0)
		{
			z0iek = p0;
		}
	}

	internal double z0eek()
	{
		return z0pek;
	}

	private void z0eek(double p0, string p1)
	{
		if (p0 < 0.0 || p0 > 1.0)
		{
			throw new ArgumentOutOfRangeException(p1, "IncorrectColorComponentValue");
		}
	}

	internal double z0rek()
	{
		return z0iek;
	}

	internal void z0rek(double p0)
	{
		z0eek(p0, "G");
		if (z0uek != p0)
		{
			z0uek = p0;
		}
	}

	internal double z0tek()
	{
		return z0uek;
	}

	internal void z0tek(double p0)
	{
		z0eek(p0, "R");
		if (z0pek != p0)
		{
			z0pek = p0;
		}
	}
}
