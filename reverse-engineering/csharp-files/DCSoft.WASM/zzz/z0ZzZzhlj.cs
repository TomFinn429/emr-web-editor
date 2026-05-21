namespace zzz;

internal class z0ZzZzhlj : z0ZzZzkkj
{
	internal z0ZzZzhlj(z0ZzZzsxk p0)
		: base(p0)
	{
	}

	protected override void z0msk(z0ZzZzsgj p0)
	{
		base.z0msk(p0);
		p0.z0rek((z0ZzZzxqj)0);
		double num = z0isk() / 2.0;
		p0.z0rek(z0ZzZzkwj.z0eek(num, num, 0.0));
		double num2 = z0rsk() / 2.0;
		p0.z0rek(new z0ZzZzywj(0.0, num2), new z0ZzZzywj(z0isk(), num2));
		p0.z0rek(z0ZzZzkwj.z0eek(num, num, num));
		double p1 = num2 + num;
		p0.z0rek(new z0ZzZzywj(0.0, p1), new z0ZzZzywj(z0isk(), p1));
	}

	protected override z0ZzZzxqj z0sak()
	{
		return (z0ZzZzxqj)0;
	}
}
