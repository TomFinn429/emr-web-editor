namespace zzz;

internal class z0ZzZzhkj : z0ZzZzkkj
{
	protected override void z0msk(z0ZzZzsgj p0)
	{
		base.z0msk(p0);
		double num = z0isk();
		double num2 = z0rsk() / 2.0;
		double num3 = num / 2.0;
		double p1 = num2 + num3;
		p0.z0rek(new z0ZzZzywj[4]
		{
			new z0ZzZzywj(num, num2),
			new z0ZzZzywj(num2, num2),
			new z0ZzZzywj(num2, p1),
			new z0ZzZzywj(num, p1)
		});
		p0.z0rek(new z0ZzZzywj(num3, num3 + z0rsk() * 1.5), new z0ZzZzywj(num3, num));
	}

	internal z0ZzZzhkj(z0ZzZzsxk p0)
		: base(p0)
	{
	}
}
