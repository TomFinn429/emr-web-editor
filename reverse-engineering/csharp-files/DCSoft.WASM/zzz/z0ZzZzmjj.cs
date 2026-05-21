namespace zzz;

internal class z0ZzZzmjj : z0ZzZzukj
{
	private readonly z0ZzZziwj z0eek;

	internal z0ZzZzmjj(double p0)
	{
		z0eek = z0psk(p0);
	}

	protected override void z0osk(z0ZzZzsgj p0, z0ZzZzjej p1)
	{
		p0.z0mek();
		p0.z0rek(p1);
		p0.z0tek(z0eek);
		p0.z0tek();
	}

	protected virtual z0ZzZziwj z0psk(double p0)
	{
		double num = p0 / 2.0;
		return new z0ZzZziwj(0.0 - num, 0.0 - num, num, num);
	}
}
