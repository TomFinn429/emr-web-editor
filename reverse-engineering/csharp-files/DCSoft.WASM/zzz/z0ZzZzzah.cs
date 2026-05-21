using System;

namespace zzz;

public class z0ZzZzzah : z0ZzZzxsh
{
	public override string z0th()
	{
		return z0wg().z0qrk;
	}

	public override z0ZzZzbah z0mh()
	{
		return (z0ZzZzbah)14;
	}

	internal override bool z0yh()
	{
		return true;
	}

	public override void z0uh(z0ZzZzdqh p0)
	{
	}

	public override string z0ph()
	{
		return z0wg().z0qrk;
	}

	public override string? z0rh()
	{
		return z0eek();
	}

	public override void z0eh(z0ZzZzdqh p0)
	{
		p0.z0yg(z0eek());
	}

	protected internal z0ZzZzzah(string? p0, z0ZzZzfah p1)
		: base(p0, p1)
	{
		if (!p1.z0yek() && !z0ZzZzxsh.z0rek(p0))
		{
			throw new ArgumentException();
		}
	}

	public override void z0oh(string? p0)
	{
		if (z0ZzZzxsh.z0rek(p0))
		{
			z0eek(p0);
			return;
		}
		throw new ArgumentException();
	}

	public override z0ZzZzoah? z0ih()
	{
		switch (z0oek.z0mh())
		{
		case (z0ZzZzbah)9:
			return base.z0ih();
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
}
