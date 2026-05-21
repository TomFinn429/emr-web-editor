using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzjej
{
	private readonly double z0vek;

	private readonly double z0cek;

	private readonly double z0xek;

	private readonly double z0zek;

	private static z0ZzZzjej z0lrk = new z0ZzZzjej();

	private readonly double z0krk;

	private readonly double z0jrk;

	internal double z0rek()
	{
		return z0jrk;
	}

	internal bool z0tek()
	{
		if (z0cek == 1.0 && z0zek == 0.0 && z0vek == 0.0 && z0krk == 1.0 && z0jrk == 0.0)
		{
			return z0xek == 0.0;
		}
		return false;
	}

	internal double z0yek()
	{
		return z0zek;
	}

	private double z0uek()
	{
		return z0cek * z0krk - z0zek * z0vek;
	}

	internal z0ZzZzywj z0rek(z0ZzZzywj p0)
	{
		return z0rek(p0.z0eek(), p0.z0rek());
	}

	internal double z0iek()
	{
		return z0xek;
	}

	internal z0ZzZziwj z0rek(z0ZzZziwj p0)
	{
		return z0ZzZzgsj.z0rek(z0eek(new z0ZzZzywj[4]
		{
			p0.z0pek(),
			p0.z0tek(),
			p0.z0nek(),
			p0.z0bek()
		}));
	}

	internal z0ZzZzywj[] z0eek(IList<z0ZzZzywj> p0)
	{
		int count = p0.Count;
		z0ZzZzywj[] array = new z0ZzZzywj[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = z0rek(p0[i]);
		}
		return array;
	}

	internal static z0ZzZzjej z0rek(z0ZzZzjej p0)
	{
		double num = p0.z0uek();
		return new z0ZzZzjej(p0.z0krk / num, (0.0 - p0.z0zek) / num, (0.0 - p0.z0vek) / num, p0.z0cek / num, (p0.z0vek * p0.z0xek - p0.z0jrk * p0.z0krk) / num, (p0.z0zek * p0.z0jrk - p0.z0xek * p0.z0cek) / num);
	}

	internal static z0ZzZzjej z0rek(z0ZzZzjej p0, z0ZzZzjej p1)
	{
		double num = p0.z0cek;
		double num2 = p0.z0zek;
		double num3 = p0.z0vek;
		double num4 = p0.z0krk;
		double num5 = p0.z0jrk;
		double num6 = p0.z0xek;
		double num7 = p1.z0cek;
		double num8 = p1.z0zek;
		double num9 = p1.z0vek;
		double num10 = p1.z0krk;
		return new z0ZzZzjej(num * num7 + num2 * num9, num * num8 + num2 * num10, num3 * num7 + num4 * num9, num3 * num8 + num4 * num10, num5 * num7 + num6 * num9 + p1.z0jrk, num5 * num8 + num6 * num10 + p1.z0xek);
	}

	internal z0ZzZzjej(double p0, double p1, double p2, double p3, double p4, double p5)
	{
		z0cek = p0;
		z0zek = p1;
		z0vek = p2;
		z0krk = p3;
		z0jrk = p4;
		z0xek = p5;
	}

	internal double z0oek()
	{
		return z0krk;
	}

	internal double z0pek()
	{
		return z0cek;
	}

	internal z0ZzZzywj z0rek(double p0, double p1)
	{
		return new z0ZzZzywj(p0 * z0cek + p1 * z0vek + z0jrk, p0 * z0zek + p1 * z0krk + z0xek);
	}

	internal static z0ZzZzjej z0mek()
	{
		return z0lrk;
	}

	internal double z0nek()
	{
		return z0vek;
	}

	internal z0ZzZzjej()
		: this(1.0, 0.0, 0.0, 1.0, 0.0, 0.0)
	{
	}

	internal IList<object> z0bek()
	{
		return new List<object> { z0cek, z0zek, z0vek, z0krk, z0jrk, z0xek };
	}
}
