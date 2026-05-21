namespace zzz;

internal class z0ZzZzvjj : z0ZzZztjj
{
	private new static z0ZzZzjkj[] z0eek;

	internal z0ZzZzvjj(z0ZzZzsxk p0)
		: base(p0, z0eek)
	{
	}

	static z0ZzZzvjj()
	{
		z0eek = new z0ZzZzjkj[10];
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			z0eek[num++] = new z0ZzZzjkj(5 - i, i + 1);
			z0eek[num++] = new z0ZzZzjkj(i, i + 1);
		}
		z0eek[num++] = new z0ZzZzjkj(6, 0, 2, 1);
		z0eek[num++] = new z0ZzZzjkj(4, 4, 2, 1);
		z0eek[num++] = new z0ZzZzjkj(6, 5);
		z0eek[num] = new z0ZzZzjkj(7, 6, 1, 2);
	}
}
