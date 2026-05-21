namespace zzz;

internal abstract class z0ZzZzykj
{
	private static readonly z0ZzZzuwj[] z0yek = new z0ZzZzuwj[3]
	{
		new z0ZzZzuwj(0.0, 1.0),
		new z0ZzZzuwj(0.0, 1.0),
		new z0ZzZzuwj(0.0, 1.0)
	};

	private readonly double[] z0uek;

	private static readonly z0ZzZzuwj[] z0iek = new z0ZzZzuwj[1]
	{
		new z0ZzZzuwj(0.0, 1.0)
	};

	internal z0ZzZzyaj z0eek(z0ZzZzugj p0, z0ZzZziwj p1)
	{
		z0ZzZzlqj item = z0eek(p0);
		double p2 = p1.z0yek() + p1.z0rek() / 2.0;
		z0ZzZzywj p3 = new z0ZzZzywj(p1.z0oek(), p2);
		z0ZzZzywj p4 = new z0ZzZzywj(p1.z0iek(), p2);
		return new z0ZzZzyaj(p3, p4, new zzz.z0ZzZzasj<z0ZzZzlqj>(p0.z0uek()) { item });
	}

	protected abstract zzz.z0ZzZzasj<z0ZzZzlqj> z0bsk(z0ZzZzugj p0);

	protected double[] z0eek()
	{
		return z0uek;
	}

	protected z0ZzZzykj(double[] p0)
	{
		z0uek = p0;
	}

	private z0ZzZzlqj z0eek(z0ZzZzugj p0)
	{
		zzz.z0ZzZzasj<z0ZzZzlqj> z0ZzZzasj2 = z0bsk(p0);
		if (z0ZzZzasj2.Count == 1)
		{
			return z0ZzZzasj2[0];
		}
		double[] array = new double[z0eek().Length - 1];
		for (int i = 0; i < z0eek().Length - 1; i++)
		{
			array[i] = z0eek()[i];
		}
		return new z0ZzZzbwj(array, z0vsk_jiejie20260327142557(), z0ZzZzasj2, z0iek, z0yek);
	}

	protected abstract z0ZzZzuwj[] z0vsk_jiejie20260327142557();

	protected static z0ZzZzuwj[] z0rek()
	{
		return z0yek;
	}

	protected static z0ZzZzuwj[] z0tek()
	{
		return z0iek;
	}
}
