using System;

namespace zzz;

public class z0ZzZzbsh : z0ZzZzoah
{
	private new z0ZzZztah z0uek;

	private new z0ZzZzyah z0iek;

	protected internal z0ZzZzbsh(string p0, string p1, string p2, z0ZzZzfah p3)
		: this(p3.z0eek(p0, p1, p2, null), p3)
	{
	}

	internal void z0eek(z0ZzZzyah p0)
	{
		z0iek = p0;
	}

	public override z0ZzZzoah z0mf(z0ZzZzoah p0)
	{
		z0ZzZzoah result;
		if (z0eek())
		{
			string p1 = z0eg();
			result = base.z0mf(p0);
			z0eek(p1);
		}
		else
		{
			result = base.z0mf(p0);
		}
		return result;
	}

	internal new bool z0eek()
	{
		return false;
	}

	public override z0ZzZzoah z0pf(z0ZzZzoah p0)
	{
		z0ZzZzoah result;
		if (z0eek())
		{
			string p1 = z0eg();
			result = base.z0pf(p0);
			z0eek(p1);
		}
		else
		{
			result = base.z0pf(p0);
		}
		return result;
	}

	public override z0ZzZzbah z0mh()
	{
		return (z0ZzZzbah)2;
	}

	public override z0ZzZzoah z0of(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		z0ZzZzoah result;
		if (z0eek())
		{
			string p2 = z0eg();
			result = base.z0of(p0, p1);
			z0eek(p2);
		}
		else
		{
			result = base.z0of(p0, p1);
		}
		return result;
	}

	public override void z0eh(z0ZzZzdqh p0)
	{
		p0.z0ig(z0ph());
		z0uh(p0);
		p0.z0cg();
	}

	internal void z0eek(string p0)
	{
		z0tek()?.z0sg().z0rek(p0, z0eg());
	}

	public override z0ZzZzoah z0if(z0ZzZzoah p0)
	{
		z0ZzZzoah result;
		if (z0eek())
		{
			string p1 = z0eg();
			result = base.z0if(p0);
			z0eek(p1);
		}
		else
		{
			result = base.z0if(p0);
		}
		return result;
	}

	internal override bool z0fg()
	{
		return true;
	}

	public override void z0uh(z0ZzZzdqh p0)
	{
		for (z0ZzZzoah z0ZzZzoah2 = z0iek(); z0ZzZzoah2 != null; z0ZzZzoah2 = z0ZzZzoah2.z0qf())
		{
			z0ZzZzoah2.z0eh(p0);
		}
	}

	internal new z0ZzZzyah z0rek()
	{
		return z0iek;
	}

	public override string z0ag()
	{
		return z0iek.z0rek();
	}

	public override z0ZzZzaqh z0uf()
	{
		return z0iek;
	}

	internal override z0ZzZztah z0jg()
	{
		return z0uek;
	}

	public override z0ZzZzoah z0yf(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		z0ZzZzoah result;
		if (z0eek())
		{
			string p2 = z0eg();
			result = base.z0yf(p0, p1);
			z0eek(p2);
		}
		else
		{
			result = base.z0yf(p0, p1);
		}
		return result;
	}

	internal z0ZzZzbsh(z0ZzZzyah p0, z0ZzZzfah p1)
		: base(p1)
	{
		z0oek = null;
		if (!p1.z0yek())
		{
			z0ZzZzfah.z0tek(p0.z0oek());
			z0ZzZzfah.z0tek(p0.z0yek());
		}
		if (p0.z0yek().Length == 0)
		{
			throw new ArgumentException();
		}
		z0iek = p0;
	}

	public override z0ZzZzoah z0ih()
	{
		return null;
	}

	public override string z0ph()
	{
		return z0iek.z0yek();
	}

	public override z0ZzZzoah z0tf(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		z0ZzZzoah result;
		if (z0eek())
		{
			string p2 = z0eg();
			result = base.z0tf(p0, p1);
			z0eek(p2);
		}
		else
		{
			result = base.z0tf(p0, p1);
		}
		return result;
	}

	public override string z0tg()
	{
		return z0iek.z0oek();
	}

	internal override void z0lg(z0ZzZztah p0)
	{
		z0uek = p0;
	}

	public override void z0rg(string p0)
	{
		if (z0eek())
		{
			string p1 = base.z0eg();
			base.z0rg(p0);
			z0eek(p1);
		}
		else
		{
			base.z0rg(p0);
		}
	}

	public override string z0rh()
	{
		return z0eg();
	}

	internal override void z0gg(z0ZzZzoah p0)
	{
		z0oek = p0;
	}

	public new virtual z0ZzZzsah z0tek()
	{
		return z0oek as z0ZzZzsah;
	}

	public override z0ZzZzfah z0wg()
	{
		return z0iek.z0iek();
	}

	public override void z0oh(string p0)
	{
		z0rg(p0);
	}

	internal int z0yek()
	{
		return z0iek.z0uek_jiejie20260327142557();
	}

	public override string z0th()
	{
		return z0iek.z0eek();
	}

	internal override bool z0hg(z0ZzZzbah p0)
	{
		if (p0 != (z0ZzZzbah)3)
		{
			return p0 == (z0ZzZzbah)5;
		}
		return true;
	}

	public virtual bool z0wh()
	{
		return true;
	}
}
