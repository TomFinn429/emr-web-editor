using System;

namespace zzz;

internal class z0ZzZziwj
{
	private readonly double z0vek;

	private readonly double z0cek;

	private readonly double z0xek;

	private readonly double z0zek;

	internal double z0eek()
	{
		return z0cek - z0zek;
	}

	private z0ZzZziwj(double p0, double p1, double p2, double p3, bool p4)
	{
		if (p4)
		{
			if (p0 > p2)
			{
				throw new ArgumentOutOfRangeException("IncorrectRectangleWidth");
			}
			if (p1 > p3)
			{
				throw new ArgumentOutOfRangeException("IncorrectRectangleHeight");
			}
		}
		z0zek = p0;
		z0xek = p1;
		z0cek = p2;
		z0vek = p3;
	}

	internal double z0rek()
	{
		return z0vek - z0xek;
	}

	internal z0ZzZzywj z0tek()
	{
		return new z0ZzZzywj(z0zek, z0vek);
	}

	internal z0ZzZziwj(z0ZzZzywj p0, z0ZzZzywj p1)
	{
		double num = p0.z0eek();
		double num2 = p1.z0eek();
		if (num < num2)
		{
			z0zek = num;
			z0cek = num2;
		}
		else
		{
			z0zek = num2;
			z0cek = num;
		}
		double num3 = p0.z0rek();
		double num4 = p1.z0rek();
		if (num3 < num4)
		{
			z0xek = num3;
			z0vek = num4;
		}
		else
		{
			z0xek = num4;
			z0vek = num3;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj is z0ZzZziwj z0ZzZziwj2 && z0zek == z0ZzZziwj2.z0zek && z0cek == z0ZzZziwj2.z0cek && z0vek == z0ZzZziwj2.z0vek)
		{
			return z0xek == z0ZzZziwj2.z0xek;
		}
		return false;
	}

	internal bool z0eek(z0ZzZziwj p0)
	{
		if (z0zek <= p0.z0zek && z0cek >= p0.z0cek && z0xek <= p0.z0xek)
		{
			return z0vek >= p0.z0vek;
		}
		return false;
	}

	internal z0ZzZziwj z0rek(z0ZzZziwj p0)
	{
		double num = Math.Max(z0zek, p0.z0zek);
		double num2 = Math.Max(z0xek, p0.z0xek);
		double num3 = Math.Min(z0cek, p0.z0cek);
		double num4 = Math.Min(z0vek, p0.z0vek);
		if (num > num3 || num2 > num4)
		{
			return null;
		}
		return new z0ZzZziwj(num, num2, num3, num4);
	}

	internal z0ZzZziwj(double p0, double p1, double p2, double p3)
		: this(p0, p1, p2, p3, p4: true)
	{
	}

	internal double z0yek()
	{
		return z0xek;
	}

	protected internal z0ZzZzqaj z0uek()
	{
		return new z0ZzZzqaj(z0zek, z0xek, z0cek, z0vek);
	}

	internal double z0iek()
	{
		return z0cek;
	}

	internal double z0oek()
	{
		return z0zek;
	}

	public override int GetHashCode()
	{
		return (((-1064806749 * -1521134295 + z0zek.GetHashCode()) * -1521134295 + z0xek.GetHashCode()) * -1521134295 + z0cek.GetHashCode()) * -1521134295 + z0vek.GetHashCode();
	}

	internal z0ZzZzywj z0pek()
	{
		return new z0ZzZzywj(z0zek, z0xek);
	}

	internal double z0mek()
	{
		return z0vek;
	}

	internal z0ZzZzywj z0nek()
	{
		return new z0ZzZzywj(z0cek, z0vek);
	}

	internal z0ZzZzywj z0bek()
	{
		return new z0ZzZzywj(z0cek, z0xek);
	}
}
