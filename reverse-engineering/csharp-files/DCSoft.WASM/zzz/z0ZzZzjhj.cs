namespace zzz;

internal class z0ZzZzjhj : z0ZzZztjj
{
	private new static z0ZzZzjkj[] z0eek;

	internal z0ZzZzjhj(z0ZzZzsxk p0)
		: base(p0, z0eek)
	{
	}

	static z0ZzZzjhj()
	{
		z0eek = new z0ZzZzjkj[12];
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			int num2 = i * 4;
			for (int j = 0; j < 2; j++)
			{
				int num3 = 1 + 4 * j;
				z0eek[num++] = new z0ZzZzjkj(num2, num3, 1, 3);
				z0eek[num++] = new z0ZzZzjkj(num3, num2, 3, 1);
			}
		}
		z0eek[num++] = new z0ZzZzjkj(1, 6, 2, 2);
		z0eek[num++] = new z0ZzZzjkj(3, 5, 1, 3);
		z0eek[num++] = new z0ZzZzjkj(4, 2, 3, 2);
		z0eek[num++] = new z0ZzZzjkj(7, 1, 1, 3);
	}
}
