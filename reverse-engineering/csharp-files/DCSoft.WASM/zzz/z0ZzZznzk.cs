namespace zzz;

internal abstract class z0ZzZznzk : z0ZzZzpzk
{
	private new readonly z0ZzZziwj z0tek;

	private readonly z0ZzZzmwj z0yek;

	private readonly z0ZzZziwj z0uek;

	protected abstract void z0wak(z0ZzZzsgj p0);

	protected new z0ZzZziwj z0eek()
	{
		return z0tek;
	}

	protected override z0ZzZzrwj z0qak(z0ZzZzugj p0)
	{
		z0ZzZziwj z0ZzZziwj2 = z0eek();
		z0ZzZzlej z0ZzZzlej2 = new z0ZzZzlej(base.z0eek(), z0ZzZziwj2, z0ZzZziwj2.z0eek(), z0ZzZziwj2.z0rek(), p0);
		using z0ZzZzsgj z0ZzZzsgj2 = new z0ZzZzsgj(z0ZzZzlej2.z0rek());
		z0wak(z0ZzZzsgj2);
		z0ZzZzlej2.z0eek(z0ZzZzsgj2.z0oek());
		return z0ZzZzlej2;
	}

	protected new z0ZzZziwj z0rek()
	{
		return z0uek;
	}

	protected void z0eek(z0ZzZzsgj p0, z0ZzZziwj p1, z0ZzZzjej p2)
	{
		p0.z0mek();
		p0.z0rek(z0ZzZzjej.z0rek(z0tek(), p2));
		p0.z0rek(base.z0rek());
		p0.z0tek();
	}

	protected z0ZzZznzk(z0ZzZziwj p0, z0ZzZzmwj p1, z0ZzZzmwj p2, z0ZzZzjej p3, z0ZzZziwj p4, z0ZzZzjej p5)
		: base(p1, p3, p5)
	{
		z0uek = p0;
		z0tek = p4;
		z0yek = p2;
	}
}
