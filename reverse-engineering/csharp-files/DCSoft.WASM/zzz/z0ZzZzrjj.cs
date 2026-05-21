namespace zzz;

internal abstract class z0ZzZzrjj : z0ZzZzukj
{
	private readonly z0ZzZzywj[] z0eek;

	protected abstract z0ZzZzywj[] z0ysk(double p0);

	protected override void z0osk(z0ZzZzsgj p0, z0ZzZzjej p1)
	{
		p0.z0rek(p1.z0eek(z0eek), p1: true);
	}

	protected override bool z0oak()
	{
		return z0eek.Length > 2;
	}

	protected z0ZzZzrjj(double p0)
	{
		z0eek = z0ysk(p0);
	}
}
