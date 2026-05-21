namespace zzz;

internal class z0ZzZzvzk : z0ZzZzkkj
{
	protected override void z0msk(z0ZzZzsgj p0)
	{
		base.z0msk(p0);
		double num = z0isk();
		double num2 = num / 2.0;
		for (double num3 = 0.0; num3 < 1.0; num3 += 0.5)
		{
			double num4 = num * num3;
			double num5 = num4 + num2;
			p0.z0rek(new z0ZzZzywj[4]
			{
				new z0ZzZzywj(num4, num4),
				new z0ZzZzywj(num4, num5),
				new z0ZzZzywj(num5, num5),
				new z0ZzZzywj(num5, num4)
			}, p1: true);
		}
	}

	internal z0ZzZzvzk(z0ZzZzsxk p0)
		: base(p0)
	{
		z0eek(90f);
	}
}
