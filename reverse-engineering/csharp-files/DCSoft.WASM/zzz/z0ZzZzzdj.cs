using System.Collections.Generic;

namespace zzz;

internal abstract class z0ZzZzzdj
{
	private double z0uek;

	private readonly IList<z0ZzZzndj> z0iek;

	protected z0ZzZzzdj(IList<z0ZzZzndj> p0)
	{
		z0iek = p0;
		foreach (z0ZzZzndj item in p0)
		{
			z0uek += item.z0yek();
		}
	}

	internal IList<z0ZzZzndj> z0eek()
	{
		return z0iek;
	}

	internal void z0eek(z0ZzZzzdj p0)
	{
		IList<z0ZzZzndj> list = p0.z0eek();
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			z0eek(list[i]);
		}
	}

	internal bool z0rek()
	{
		return z0iek.Count == 0;
	}

	internal void z0eek(z0ZzZzndj p0)
	{
		z0iek.Add(p0);
		z0uek += p0.z0yek();
	}

	protected z0ZzZzzdj()
	{
		z0iek = new List<z0ZzZzndj>();
		z0uek = 0.0;
	}

	internal double[] z0tek()
	{
		int count = z0iek.Count;
		if (count < 1)
		{
			return new double[0];
		}
		int num = z0fsk();
		double[] array = new double[(count + 1) * num];
		int num2 = 0;
		int num3 = 0;
		while (num2 < count)
		{
			array[num3] = z0iek[num2].z0rek();
			num2++;
			num3 += num;
		}
		return array;
	}

	internal abstract byte[] z0dsk();

	internal double z0yek()
	{
		return z0uek;
	}

	protected abstract int z0fsk();
}
