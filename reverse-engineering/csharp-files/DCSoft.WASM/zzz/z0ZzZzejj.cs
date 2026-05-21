namespace zzz;

internal class z0ZzZzejj : z0ZzZztjj
{
	private new static z0ZzZzjkj[] z0eek;

	internal z0ZzZzejj(z0ZzZzsxk p0)
		: base(p0, z0eek)
	{
	}

	static z0ZzZzejj()
	{
		z0eek = new z0ZzZzjkj[17];
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			for (int j = i % 2; j < 4; j += 2)
			{
				z0eek[num++] = new z0ZzZzjkj(i, j);
			}
		}
		z0eek[num] = new z0ZzZzjkj(0, 4, 4, 4);
	}
}
