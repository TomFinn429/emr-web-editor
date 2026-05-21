namespace zzz;

internal class z0ZzZzwjj : z0ZzZzkkj
{
	private readonly int[] z0rek;

	private readonly int[] z0tek;

	protected override void z0msk(z0ZzZzsgj p0)
	{
		base.z0msk(p0);
		double num = z0eek();
		for (int i = 0; i < z0tek.Length; i++)
		{
			int num2 = z0tek[i];
			double num3 = (double)i * z0isk() / (double)z0tek.Length;
			for (int j = 0; j < num2; j++)
			{
				double num4 = (double)j * z0isk() / (double)num2 + (double)z0rek[i] * num;
				p0.z0oek(new z0ZzZziwj(num3, num4, num3 + num, num4 + num));
			}
		}
	}

	internal z0ZzZzwjj(z0ZzZzsxk p0, int[] p1, int[] p2)
		: base(p0)
	{
		z0tek = p1;
		z0rek = p2;
	}

	protected double z0eek()
	{
		return z0isk() / 8.0;
	}
}
