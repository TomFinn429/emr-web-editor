using System;

namespace zzz;

internal class z0ZzZzgfj
{
	private readonly int z0yek;

	private readonly int z0uek;

	private readonly int z0iek;

	internal static z0ZzZzgfj[] z0eek(z0ZzZzjgj p0, int p1)
	{
		z0ZzZzgfj[] array = new z0ZzZzgfj[p1];
		for (int i = 0; i < p1; i++)
		{
			int p2 = p0.z0nek();
			int p3 = p0.z0nek();
			int p4 = p0.z0nek();
			array[i] = new z0ZzZzgfj(p2, p3, p4);
		}
		return array;
	}

	public override string ToString()
	{
		return z0uek + "->" + z0iek + " LEN:" + Convert.ToString(z0iek - z0uek + 1);
	}

	internal int z0eek()
	{
		return z0yek;
	}

	internal int z0rek()
	{
		return z0uek;
	}

	internal z0ZzZzgfj(int p0, int p1, int p2)
	{
		z0uek = p0;
		z0iek = p1;
		z0yek = p2;
	}

	internal int z0tek()
	{
		return z0iek;
	}

	internal static void z0eek(z0ZzZzgfj[] p0, z0ZzZzjgj p1)
	{
		foreach (z0ZzZzgfj z0ZzZzgfj2 in p0)
		{
			p1.z0oek(z0ZzZzgfj2.z0uek);
			p1.z0oek(z0ZzZzgfj2.z0iek);
			p1.z0oek(z0ZzZzgfj2.z0yek);
		}
	}
}
