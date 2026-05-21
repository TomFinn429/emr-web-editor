using System;
using System.Collections.Generic;

namespace zzz;

internal abstract class z0ZzZzlqj : z0ZzZzoqj
{
	private double[] z0iek;

	private readonly IList<z0ZzZzuwj> z0oek;

	private readonly IList<z0ZzZzuwj> z0pek;

	protected static bool z0eek(IList<z0ZzZzuwj> p0, IList<z0ZzZzuwj> p1)
	{
		if (p0 == null)
		{
			return p1 == null;
		}
		int count = p0.Count;
		if (p1 == null || p1.Count != count)
		{
			return false;
		}
		for (int i = 0; i < count; i++)
		{
			z0ZzZzuwj z0ZzZzuwj2 = p0[i];
			z0ZzZzuwj z0ZzZzuwj3 = p1[i];
			if (z0ZzZzuwj2.z0tek() != z0ZzZzuwj3.z0tek() || z0ZzZzuwj2.z0rek() != z0ZzZzuwj3.z0rek())
			{
				return false;
			}
		}
		return true;
	}

	protected z0ZzZzlqj(IList<z0ZzZzuwj> p0, IList<z0ZzZzuwj> p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("domain");
		}
		if (p0.Count == 0)
		{
			throw new ArgumentException("IncorrectListSize", "domain");
		}
		if (p1 == null && z0gfk())
		{
			throw new ArgumentNullException("range");
		}
		if (p1.Count == 0)
		{
			throw new ArgumentException("IncorrectListSize", "range");
		}
		z0pek = p0;
		z0oek = p1;
	}

	protected static double z0yek(double p0, double p1, double p2, z0ZzZzuwj p3)
	{
		double num = p3.z0tek();
		double num2 = (p0 - p1) * (p3.z0rek() - num);
		double num3 = p2 - p1;
		if (num2 + num3 != num2)
		{
			return num + num2 / num3;
		}
		return num;
	}

	protected static IList<object> z0rek(IList<z0ZzZzuwj> p0)
	{
		List<object> list = new List<object>(p0.Count * 2);
		foreach (z0ZzZzuwj item in p0)
		{
			list.Add(item.z0tek());
			list.Add(item.z0rek());
		}
		return list;
	}

	protected internal override double[] z0tfk(double[] p0)
	{
		if (z0iek == null || z0iek.Length != p0.Length)
		{
			z0iek = (double[])p0.Clone();
		}
		else
		{
			Array.Copy(p0, z0iek, p0.Length);
		}
		z0tek(z0iek, z0uek());
		double[] array = z0ffk(z0iek);
		IList<z0ZzZzuwj> list = z0yek();
		if (list != null)
		{
			z0tek(array, list);
		}
		return array;
	}

	protected abstract double[] z0ffk(double[] p0);

	internal IList<z0ZzZzuwj> z0yek()
	{
		return z0oek;
	}

	protected virtual z0ZzZzeaj z0dfk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(p0);
		z0ZzZzeaj2.Add("FunctionType", z0sfk());
		z0ZzZzeaj2.Add("Domain", z0rek(z0pek));
		if (z0oek != null)
		{
			z0ZzZzeaj2.Add("Range", z0rek(z0oek));
		}
		return z0ZzZzeaj2;
	}

	protected virtual bool z0gfk()
	{
		return true;
	}

	protected internal override bool z0rfk(z0ZzZzoqj p0)
	{
		if (p0 is z0ZzZzlqj z0ZzZzlqj2 && GetType() == z0ZzZzlqj2.GetType() && z0eek(z0pek, z0ZzZzlqj2.z0pek))
		{
			return z0eek(z0oek, z0ZzZzlqj2.z0oek);
		}
		return false;
	}

	protected internal virtual int z0hfk()
	{
		return z0oek.Count;
	}

	protected abstract int z0sfk();

	private static void z0tek(double[] p0, IList<z0ZzZzuwj> p1)
	{
		int count = p1.Count;
		if (p0.Length != count)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			double num = p0[i];
			z0ZzZzuwj z0ZzZzuwj2 = p1[i];
			double num2 = z0ZzZzuwj2.z0tek();
			if (num < num2)
			{
				p0[i] = num2;
				continue;
			}
			double num3 = z0ZzZzuwj2.z0rek();
			if (num > num3)
			{
				p0[i] = num3;
			}
		}
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		return z0dfk(p0);
	}

	internal IList<z0ZzZzuwj> z0uek()
	{
		return z0pek;
	}
}
