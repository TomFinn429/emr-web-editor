namespace zzz;

internal class z0ZzZzahj : z0ZzZztjj
{
	private new static z0ZzZzjkj[] z0eek;

	internal z0ZzZzahj(z0ZzZzsxk p0)
		: base(p0, z0eek)
	{
	}

	protected override z0ZzZzxqj z0sak()
	{
		return (z0ZzZzxqj)0;
	}

	static z0ZzZzahj()
	{
		z0eek = new z0ZzZzjkj[36];
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			z0eek[num++] = new z0ZzZzjkj(0, i * 2, 8, 1);
			for (int j = 0; j < 4; j++)
			{
				int num2 = j * 4;
				int num3 = i * 4;
				z0eek[num++] = new z0ZzZzjkj(num2 + 1, num3 + 1, 2, 1);
				z0eek[num++] = new z0ZzZzjkj(num2 - 1, num3 + 3, 2, 1);
			}
		}
	}
}
