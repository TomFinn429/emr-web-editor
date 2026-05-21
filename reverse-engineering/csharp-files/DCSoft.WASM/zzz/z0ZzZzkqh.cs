namespace zzz;

public class z0ZzZzkqh : z0ZzZzxsh
{
	public override z0ZzZzoah z0ih()
	{
		switch (z0oek.z0mh())
		{
		case (z0ZzZzbah)9:
			return null;
		case (z0ZzZzbah)3:
		case (z0ZzZzbah)4:
		case (z0ZzZzbah)13:
		case (z0ZzZzbah)14:
		{
			z0ZzZzoah z0ZzZzoah2 = z0oek.z0oek;
			while (z0ZzZzoah2.z0yh())
			{
				z0ZzZzoah2 = z0ZzZzoah2.z0oek;
			}
			return z0ZzZzoah2;
		}
		default:
			return z0oek;
		}
	}

	protected internal z0ZzZzkqh(string? p0, z0ZzZzfah p1)
		: base(p0, p1)
	{
	}

	internal z0ZzZzkqh(string? p0)
		: this(p0, null)
	{
	}

	public override z0ZzZzbah z0mh()
	{
		return (z0ZzZzbah)3;
	}

	public override void z0uh(z0ZzZzdqh p0)
	{
	}

	public override void z0oh(string p0)
	{
		z0eek(p0);
		z0ZzZzoah z0ZzZzoah2 = z0oek;
		if (z0ZzZzoah2 != null && z0ZzZzoah2.z0mh() == (z0ZzZzbah)2 && z0ZzZzoah2 is z0ZzZzgqh z0ZzZzgqh2 && !z0ZzZzgqh2.z0wh())
		{
			z0ZzZzgqh2.z0eek(p0: true);
		}
	}

	internal override bool z0yh()
	{
		return true;
	}

	public override string z0ph()
	{
		return z0wg().z0lrk;
	}

	public override string z0th()
	{
		return z0wg().z0lrk;
	}

	public override string z0rh()
	{
		return z0eek();
	}

	public override void z0eh(z0ZzZzdqh p0)
	{
		p0.z0yg(z0eek());
	}
}
