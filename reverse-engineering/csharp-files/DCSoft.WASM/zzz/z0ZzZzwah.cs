using System;
using System.Collections;

namespace zzz;

public class z0ZzZzwah : z0ZzZztah
{
	private new z0ZzZztah? z0eek;

	private new readonly string z0rek;

	internal override bool z0fg()
	{
		return true;
	}

	internal override void z0gg(z0ZzZzoah? p0)
	{
		base.z0gg(p0);
		if (z0jg() == null && p0 != null)
		{
			z0wg();
		}
	}

	public override void z0eh(z0ZzZzdqh p0)
	{
		p0.z0ng(z0rek);
	}

	internal override bool z0hg(z0ZzZzbah p0)
	{
		switch (p0)
		{
		case (z0ZzZzbah)1:
		case (z0ZzZzbah)3:
		case (z0ZzZzbah)4:
		case (z0ZzZzbah)5:
		case (z0ZzZzbah)7:
		case (z0ZzZzbah)8:
		case (z0ZzZzbah)13:
		case (z0ZzZzbah)14:
			return true;
		default:
			return false;
		}
	}

	internal override z0ZzZztah? z0jg()
	{
		return z0eek;
	}

	public override string z0th()
	{
		return z0rek;
	}

	protected internal z0ZzZzwah(string p0, z0ZzZzfah p1)
		: base(p1)
	{
		if (!p1.z0yek() && p0.Length > 0 && p0[0] == '#')
		{
			throw new ArgumentException();
		}
		z0rek = p1.z0tek().z0nf(p0);
		p1.z0mtk = true;
	}

	internal override void z0kg(z0ZzZzoah p0)
	{
		z0gg(p0);
	}

	public override void z0uh(z0ZzZzdqh p0)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				((z0ZzZzoah)enumerator.Current).z0eh(p0);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public override string z0rh()
	{
		return null;
	}

	public override void z0oh(string p0)
	{
		throw new InvalidOperationException();
	}

	internal override void z0lg(z0ZzZztah? p0)
	{
		z0eek = p0;
	}

	public override z0ZzZzbah z0mh()
	{
		return (z0ZzZzbah)5;
	}

	public override string z0ph()
	{
		return z0rek;
	}
}
