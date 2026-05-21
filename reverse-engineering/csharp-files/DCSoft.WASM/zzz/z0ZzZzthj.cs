namespace zzz;

internal class z0ZzZzthj : z0ZzZztjj
{
	private new static z0ZzZzjkj[] z0eek;

	internal z0ZzZzthj(z0ZzZzsxk p0)
		: base(p0, z0eek)
	{
	}

	static z0ZzZzthj()
	{
		z0eek = new z0ZzZzjkj[10];
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			int num2 = 4 * i;
			z0eek[num++] = new z0ZzZzjkj(3, 1 + num2, 2, 1);
			z0eek[num++] = new z0ZzZzjkj(0, 3 + num2, 2, 1);
			z0eek[num++] = new z0ZzZzjkj(2, 2 + num2, 1, 1);
			z0eek[num++] = new z0ZzZzjkj(5, 2 + num2, 1, 1);
			z0eek[num++] = new z0ZzZzjkj(7, 2 + num2, 1, 1);
		}
	}
}
