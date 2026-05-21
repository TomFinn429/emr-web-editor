namespace zzz;

internal class z0ZzZzyhj : z0ZzZztjj
{
	private new static z0ZzZzjkj[] z0eek;

	internal z0ZzZzyhj(z0ZzZzsxk p0)
		: base(p0, z0eek)
	{
	}

	static z0ZzZzyhj()
	{
		z0eek = new z0ZzZzjkj[19];
		int num = 0;
		for (int i = 0; i < 5; i++)
		{
			z0eek[num++] = new z0ZzZzjkj(i, 4 - i);
			z0eek[num++] = new z0ZzZzjkj(1 + i, 7 - i);
		}
		for (int j = 0; j < 3; j++)
		{
			z0eek[num++] = new z0ZzZzjkj(5 + j, 1 + j);
			z0eek[num++] = new z0ZzZzjkj(7 - j, 7 - j);
		}
		for (int k = 0; k < 2; k++)
		{
			z0eek[num++] = new z0ZzZzjkj(k, k);
		}
		z0eek[num] = new z0ZzZzjkj(3, 7);
	}
}
