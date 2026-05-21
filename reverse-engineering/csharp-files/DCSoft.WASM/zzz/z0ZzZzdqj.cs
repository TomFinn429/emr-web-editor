using System;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzdqj : z0ZzZzlqj
{
	private new readonly double z0yek;

	private readonly IList<double> z0iek;

	private readonly IList<double> z0pek;

	private static IList<object> z0eek(IList<double> p0)
	{
		List<object> list = new List<object>(p0.Count);
		foreach (double item in p0)
		{
			list.Add(item);
		}
		return list;
	}

	protected internal override bool z0rfk(z0ZzZzoqj p0)
	{
		if (!base.z0rfk(p0))
		{
			return false;
		}
		z0ZzZzdqj z0ZzZzdqj2 = (z0ZzZzdqj)p0;
		if (z0yek == z0ZzZzdqj2.z0yek && z0rek(z0pek, z0ZzZzdqj2.z0pek))
		{
			return z0rek(z0iek, z0ZzZzdqj2.z0iek);
		}
		return false;
	}

	protected override int z0sfk()
	{
		return 2;
	}

	protected override z0ZzZzeaj z0dfk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = base.z0dfk(p0);
		if (z0pek.Count != 1 || z0pek[0] != 0.0)
		{
			z0ZzZzeaj2.Add("C0", z0eek(z0pek));
		}
		if (z0iek.Count != 1 || z0iek[0] != 1.0)
		{
			z0ZzZzeaj2.Add("C1", z0eek(z0iek));
		}
		z0ZzZzeaj2.Add("N", z0yek);
		return z0ZzZzeaj2;
	}

	protected override double[] z0ffk(double[] p0)
	{
		int num = z0hfk();
		if (p0.Length != 1)
		{
			return p0;
		}
		double num2 = Math.Pow(p0[0], z0yek);
		double[] array = new double[num];
		for (int i = 0; i < num; i++)
		{
			double num3 = z0pek[i];
			array[i] = num3 + num2 * (z0iek[i] - num3);
		}
		return array;
	}

	internal z0ZzZzdqj(IList<double> p0, IList<double> p1, double p2, IList<z0ZzZzuwj> p3, IList<z0ZzZzuwj> p4)
		: base(p3, p4)
	{
		z0pek = p0;
		z0iek = p1;
		z0yek = p2;
	}

	protected override bool z0gfk()
	{
		return false;
	}

	private static bool z0rek(IList<double> p0, IList<double> p1)
	{
		int count = p0.Count;
		if (p1.Count != count)
		{
			return false;
		}
		for (int i = 0; i < count; i++)
		{
			if (p0[i] != p1[i])
			{
				return false;
			}
		}
		return true;
	}

	protected internal override int z0hfk()
	{
		return z0pek.Count;
	}
}
