namespace zzz;

internal class z0ZzZznhj : z0ZzZzkkj
{
	protected override void z0msk(z0ZzZzsgj p0)
	{
		base.z0msk(p0);
		double num = z0rsk() / 2.0;
		double num2 = z0isk() / 2.0;
		for (int i = 0; i < 2; i++)
		{
			double p1 = num + num2 * (double)i;
			p0.z0rek(new z0ZzZzywj[3]
			{
				new z0ZzZzywj(0.0, p1),
				new z0ZzZzywj(num2, num2 * (double)(i + 1) - num),
				new z0ZzZzywj(z0isk(), p1)
			});
		}
	}

	internal z0ZzZznhj(z0ZzZzsxk p0)
		: base(p0)
	{
	}
}
