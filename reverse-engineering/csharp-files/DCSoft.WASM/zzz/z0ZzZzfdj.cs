using System;

namespace zzz;

internal class z0ZzZzfdj : z0ZzZzodj
{
	private new short[] z0rek;

	internal new static readonly string z0tek = "hmtx";

	internal z0ZzZzfdj(z0ZzZzjgj p0)
		: base(z0tek, p0)
	{
	}

	internal new short[] z0eek()
	{
		return z0rek;
	}

	internal short[] z0eek(int p0, int p1)
	{
		z0ZzZzuxk z0ZzZzuxk2 = z0uek().z0pek();
		z0ZzZzuxk2.z0rek(0);
		int num = Math.Max(p0, p1);
		z0rek = new short[num];
		if (z0ZzZzuxk2.z0tek() >= p0 * 4)
		{
			for (int i = 0; i < p0; i++)
			{
				z0rek[i] = z0ZzZzuxk2.z0iek();
				z0ZzZzuxk2.z0eek(2);
			}
			short num2 = z0rek[p0 - 1];
			for (int j = p0; j < num; j++)
			{
				z0rek[j] = num2;
			}
		}
		return z0rek;
	}
}
