using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzbwj : z0ZzZzlqj
{
	private readonly IList<z0ZzZzuwj> z0tek;

	private readonly zzz.z0ZzZzasj<z0ZzZzlqj> z0iek;

	private readonly IList<double> z0oek;

	protected internal override int z0hfk()
	{
		return z0yek()?.Count ?? z0iek[0].z0hfk();
	}

	protected override int z0sfk()
	{
		return 3;
	}

	internal z0ZzZzbwj(IList<double> p0, IList<z0ZzZzuwj> p1, zzz.z0ZzZzasj<z0ZzZzlqj> p2, IList<z0ZzZzuwj> p3, IList<z0ZzZzuwj> p4)
		: base(p3, p4)
	{
		z0oek = p0;
		z0tek = p1;
		z0iek = p2;
	}

	protected override z0ZzZzeaj z0dfk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj obj = base.z0dfk(p0);
		obj.z0tek_jiejie20260327142557("Functions", z0iek);
		obj.z0rek("Bounds", z0oek);
		obj.Add("Encode", z0ZzZzuwj.z0eek(z0tek));
		return obj;
	}

	protected override double[] z0ffk(double[] p0)
	{
		if (p0.Length != 1)
		{
			return p0;
		}
		z0ZzZzuwj z0ZzZzuwj2 = z0uek()[0];
		double num = p0[0];
		z0ZzZzoqj z0ZzZzoqj2 = null;
		double p1 = z0ZzZzuwj2.z0tek();
		double num2 = z0ZzZzuwj2.z0rek();
		z0ZzZzuwj p2 = null;
		bool flag = false;
		int count = z0oek.Count;
		for (int i = 0; i < count; i++)
		{
			num2 = z0oek[i];
			if (num < num2)
			{
				z0ZzZzoqj2 = z0iek[i];
				p2 = z0tek[i];
				flag = true;
				break;
			}
			p1 = num2;
		}
		if (!flag)
		{
			z0ZzZzoqj2 = z0iek[count];
			p2 = z0tek[count];
			num2 = z0ZzZzuwj2.z0rek();
		}
		return z0ZzZzoqj2.z0tfk(new double[1] { z0ZzZzlqj.z0yek(num, p1, num2, p2) });
	}

	protected override bool z0gfk()
	{
		return false;
	}
}
