using System;

namespace zzz;

public class z0ZzZzsah : z0ZzZztah
{
	private new z0ZzZzyah z0iek;

	private new z0ZzZztah z0oek;

	private z0ZzZzvsh z0pek;

	public override string z0tg()
	{
		return z0iek.z0oek();
	}

	internal override void z0gg(z0ZzZzoah p0)
	{
		base.z0oek = p0;
	}

	public override string z0ph()
	{
		return z0iek.z0yek();
	}

	public new virtual string z0eek(string p0)
	{
		z0ZzZzbsh z0ZzZzbsh2 = z0tek(p0);
		if (z0ZzZzbsh2 != null)
		{
			return z0ZzZzbsh2.z0rh();
		}
		return string.Empty;
	}

	public override z0ZzZzoah z0qf()
	{
		if (base.z0oek != null && base.z0oek.z0jg() != this)
		{
			return base.z0eek;
		}
		return null;
	}

	protected internal z0ZzZzsah(string p0, string p1, string p2, z0ZzZzfah p3)
		: this(p3.z0rek(p0, p1, p2, null), p1: true, p3)
	{
	}

	public virtual bool z0rek(string p0)
	{
		return z0tek(p0) != null;
	}

	internal new void z0eek(z0ZzZzyah p0)
	{
		z0iek = p0;
	}

	public override void z0rg(string p0)
	{
		z0ZzZztah z0ZzZztah2 = z0jg();
		if (z0ZzZztah2 != null && z0ZzZztah2.z0mh() == (z0ZzZzbah)3 && z0ZzZztah2.z0eek == z0ZzZztah2)
		{
			z0ZzZztah2.z0oh(p0);
			return;
		}
		z0uek();
		z0if(z0wg().z0yek(p0));
	}

	public new void z0eek(bool p0)
	{
		if (p0)
		{
			if (z0oek != this)
			{
				z0uek();
				z0oek = this;
			}
		}
		else if (z0oek == this)
		{
			z0oek = null;
		}
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

	public new virtual bool z0eek()
	{
		if (z0pek == null)
		{
			return false;
		}
		return z0pek.Count > 0;
	}

	public new virtual void z0eek(string p0, string p1)
	{
		z0ZzZzbsh z0ZzZzbsh2 = z0tek(p0);
		if (z0ZzZzbsh2 == null)
		{
			z0ZzZzbsh2 = z0wg().z0uek(p0);
			z0ZzZzbsh2.z0oh(p1);
			z0sg().z0rek(z0ZzZzbsh2);
		}
		else
		{
			z0ZzZzbsh2.z0oh(p1);
		}
	}

	public virtual z0ZzZzbsh z0tek(string p0)
	{
		if (z0eek())
		{
			return z0sg().z0eek_jiejie20260327142557(p0);
		}
		return null;
	}

	private new static void z0eek(z0ZzZzdqh p0, z0ZzZzsah p1)
	{
		z0ZzZzoah z0ZzZzoah2 = p1;
		while (true)
		{
			if (z0ZzZzoah2 is z0ZzZzsah z0ZzZzsah2 && z0ZzZzsah2.GetType() == typeof(z0ZzZzsah))
			{
				z0ZzZzsah2.z0eek(p0);
				if (z0ZzZzsah2.z0rek())
				{
					p0.z0bg();
				}
				else
				{
					if (z0ZzZzsah2.z0oek != null)
					{
						z0ZzZzoah2 = z0ZzZzsah2.z0iek();
						continue;
					}
					p0.z0mg();
				}
			}
			else
			{
				z0ZzZzoah2.z0eh(p0);
			}
			while (z0ZzZzoah2 != p1 && z0ZzZzoah2 == z0ZzZzoah2.z0ih().z0eek())
			{
				z0ZzZzoah2 = z0ZzZzoah2.z0ih();
				p0.z0mg();
			}
			if (z0ZzZzoah2 != p1)
			{
				z0ZzZzoah2 = z0ZzZzoah2.z0qf();
				continue;
			}
			break;
		}
	}

	public override string z0eg()
	{
		return base.z0eg();
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

	public override z0ZzZzbah z0mh()
	{
		return (z0ZzZzbah)1;
	}

	public new bool z0rek()
	{
		return z0oek == this;
	}

	public override z0ZzZzfah z0wg()
	{
		return z0iek.z0iek();
	}

	public override z0ZzZzoah z0ih()
	{
		return base.z0oek;
	}

	public override void z0qg_jiejie20260327142557()
	{
		base.z0qg_jiejie20260327142557();
		z0tek();
	}

	private new void z0eek(z0ZzZzdqh p0)
	{
		p0.z0hf(z0tg(), z0ph(), z0ag());
		if (z0eek())
		{
			z0ZzZzvsh z0ZzZzvsh2 = z0sg();
			for (int i = 0; i < z0ZzZzvsh2.Count; i++)
			{
				z0ZzZzvsh2.z0rek(i).z0eh(p0);
			}
		}
	}

	public override z0ZzZzaqh z0uf()
	{
		return z0iek;
	}

	public new virtual void z0tek()
	{
		if (z0eek())
		{
			z0pek.z0rek();
		}
	}

	internal override z0ZzZztah z0jg()
	{
		if (z0oek != this)
		{
			return z0oek;
		}
		return null;
	}

	internal override void z0lg(z0ZzZztah p0)
	{
		z0oek = p0;
	}

	public virtual void z0yek(string p0)
	{
		if (z0eek())
		{
			z0sg().z0rek(p0);
		}
	}

	internal z0ZzZzyah z0yek()
	{
		return z0iek;
	}

	public override string z0th()
	{
		return z0iek.z0eek();
	}

	public virtual z0ZzZzbsh z0rek(string p0, string p1)
	{
		if (z0eek())
		{
			return z0sg().z0eek_jiejie20260327142557(p0, p1);
		}
		return null;
	}

	public override void z0eh(z0ZzZzdqh p0)
	{
		if (GetType() == typeof(z0ZzZzsah))
		{
			z0eek(p0, this);
			return;
		}
		z0eek(p0);
		if (z0rek())
		{
			p0.z0bg();
			return;
		}
		z0uh(p0);
		p0.z0mg();
	}

	public override string z0ag()
	{
		return z0iek.z0rek();
	}

	public override z0ZzZzvsh z0sg()
	{
		if (z0pek == null && z0pek == null)
		{
			z0pek = new z0ZzZzvsh(this);
		}
		return z0pek;
	}

	internal new void z0uek()
	{
		base.z0qg_jiejie20260327142557();
	}

	internal z0ZzZzsah(z0ZzZzyah p0, bool p1, z0ZzZzfah p2)
		: base(p2)
	{
		base.z0oek = null;
		if (!p2.z0yek())
		{
			z0ZzZzfah.z0tek(p0.z0oek());
			z0ZzZzfah.z0tek(p0.z0yek());
		}
		if (p0.z0yek().Length == 0)
		{
			throw new ArgumentException();
		}
		z0iek = p0;
		if (p1)
		{
			z0oek = this;
		}
	}
}
