using System;

namespace zzz;

public class z0ZzZzypj
{
	private enum z0rck
	{
		z0eek,
		z0rek,
		z0tek
	}

	private bool z0grk;

	private z0ZzZzmwh z0frk;

	private z0ZzZzodh z0drk = z0ZzZzodh.z0yek;

	private z0ZzZzcdh z0srk = z0ZzZzcdh.z0yek_jiejie20260327142557;

	private object z0ark;

	private object z0qrk;

	private z0ZzZzodh z0wrk = z0ZzZzodh.z0yek;

	private z0ZzZzodh z0erk = z0ZzZzodh.z0yek;

	public z0ZzZztpj z0rrk;

	public EventHandler z0trk;

	private z0rck z0yrk;

	public z0ZzZztpj z0urk;

	private z0ZzZzndh z0irk = z0ZzZzndh.z0cek;

	private z0ZzZzodh z0ork = z0ZzZzodh.z0yek;

	private z0ZzZzupj z0prk = (z0ZzZzupj)4;

	private z0ZzZzodh z0mrk = z0ZzZzodh.z0yek;

	public void z0eek()
	{
		z0frk = null;
		z0ark = null;
		z0qrk = null;
	}

	public bool z0rek()
	{
		return z0grk;
	}

	public z0ZzZzodh z0tek()
	{
		return z0erk;
	}

	public z0ZzZzcdh z0yek()
	{
		return z0srk;
	}

	protected virtual void z0uek()
	{
		if (z0urk != null)
		{
			z0urk(this, z0ah());
		}
	}

	public z0ZzZzodh z0iek()
	{
		return z0drk;
	}

	internal static z0ZzZzndh z0eek(z0ZzZzodh p0, z0ZzZzodh p1)
	{
		z0ZzZzndh result = z0ZzZzndh.z0cek;
		result.z0eek(Math.Min(p0.z0rek(), p1.z0rek()));
		result.z0rek(Math.Min(p0.z0tek(), p1.z0tek()));
		result.z0tek(Math.Max(p0.z0rek(), p1.z0rek()) - result.z0pek());
		result.z0yek(Math.Max(p0.z0tek(), p1.z0tek()) - result.z0mek());
		return result;
	}

	public z0ZzZzmwh z0oek_jiejie20260327142557()
	{
		return z0frk;
	}

	public void z0eek(z0ZzZzmwh p0)
	{
		z0frk = p0;
		if (z0frk is z0ZzZzqbj)
		{
			((z0ZzZzqbj)z0frk).z0jpk = this;
		}
	}

	public void z0eek(object p0)
	{
		z0qrk = p0;
	}

	public void z0eek(z0ZzZzupj p0)
	{
		z0prk = p0;
	}

	public bool z0eek(z0ZzZzweh p0)
	{
		if (z0yrk == z0rck.z0eek)
		{
			z0ZzZzcdh z0ZzZzcdh2 = z0ZzZzyeh.z0rek();
			if (Math.Abs(p0.z0rek() - z0erk.z0rek()) >= z0ZzZzcdh2.z0rek() || Math.Abs(p0.z0tek() - z0erk.z0tek()) >= z0ZzZzcdh2.z0tek())
			{
				z0yrk = z0rck.z0rek;
				return true;
			}
		}
		else if (z0yrk == z0rck.z0rek)
		{
			if (p0.z0rek() != z0mrk.z0rek() || p0.z0tek() != z0mrk.z0tek())
			{
				z0mrk = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
				z0uek();
				z0tek(p0: true);
				z0drk = z0mrk;
				if (z0grk)
				{
					z0yrk = z0rck.z0tek;
				}
			}
			return true;
		}
		return false;
	}

	public object z0pek()
	{
		return z0qrk;
	}

	public z0ZzZzodh z0mek()
	{
		return z0wrk;
	}

	public z0ZzZzndh z0nek()
	{
		return z0irk;
	}

	public void z0rek(object p0)
	{
		z0ark = p0;
	}

	public void z0rek(z0ZzZzweh p0)
	{
		if (z0yrk == z0rck.z0rek)
		{
			z0ork = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
			z0srk = new z0ZzZzcdh(p0.z0rek() - z0erk.z0rek(), p0.z0tek() - z0erk.z0tek());
			if (z0trk != null)
			{
				z0trk(this, p0);
			}
		}
		z0yrk = z0rck.z0tek;
	}

	protected virtual z0ZzZzrpj z0ah()
	{
		return new z0ZzZzrpj(this, z0erk, z0mrk);
	}

	public z0ZzZzupj z0bek()
	{
		return z0prk;
	}

	public static bool z0eek(nint p0)
	{
		return false;
	}

	public z0ZzZzcdh z0vek()
	{
		return new z0ZzZzcdh(z0mrk.z0rek() - z0erk.z0rek(), z0mrk.z0tek() - z0erk.z0tek());
	}

	public z0ZzZzodh z0cek()
	{
		return z0mrk;
	}

	public void z0eek(bool p0)
	{
		z0grk = p0;
	}

	public void z0eek(z0ZzZzndh p0)
	{
		z0irk = p0;
	}

	public void z0eek(z0ZzZzcdh p0)
	{
		z0srk = p0;
	}

	public z0ZzZzndh z0xek()
	{
		return z0eek(z0erk, z0ork);
	}

	public void z0eek(z0ZzZzodh p0)
	{
		z0wrk = p0;
	}

	public int z0zek()
	{
		return z0ork.z0rek() - z0erk.z0rek();
	}

	public z0ZzZzypj(z0ZzZzmwh p0)
	{
		z0eek(p0);
	}

	public bool z0lrk()
	{
		return z0rek(p0: true);
	}

	public int z0krk()
	{
		return z0ork.z0tek() - z0erk.z0tek();
	}

	public bool z0rek(bool p0)
	{
		return false;
	}

	public void z0rek(z0ZzZzodh p0)
	{
		z0erk = p0;
	}

	protected virtual void z0tek(bool p0)
	{
		if (z0bek() == (z0ZzZzupj)4)
		{
			if (z0rrk != null)
			{
				z0ZzZzrpj z0ZzZzrpj2 = z0ah();
				z0ZzZzrpj2.z0rek(p0);
				z0rrk(this, z0ZzZzrpj2);
			}
		}
		else
		{
			z0ZzZzndh z0ZzZzndh2 = z0eek(z0tek(), z0cek());
			(z0oek_jiejie20260327142557() as z0ZzZzqbj).z0tek(z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek(), z0ZzZzndh2.z0nek(), z0ZzZzndh2.z0bek(), z0bek());
		}
	}

	public static z0ZzZzndh z0eek(z0ZzZzmwh p0, int p1, int p2)
	{
		if (p0 == null || p0.z0rek())
		{
			throw new ArgumentNullException("ctl");
		}
		if (p0.z0rek())
		{
			throw new ArgumentException("ctl Disposed");
		}
		if (z0ZzZzopj.DragDetect(p0.z0hhk()))
		{
			z0ZzZzypj z0ZzZzypj2 = new z0ZzZzypj(p0);
			z0ZzZzypj2.z0eek((z0ZzZzupj)1);
			z0ZzZzypj2.z0rek(new z0ZzZzodh(p1, p2));
			if (z0ZzZzypj2.z0lrk())
			{
				return z0ZzZzypj2.z0xek();
			}
		}
		return z0ZzZzndh.z0cek;
	}

	public void z0tek(z0ZzZzweh p0)
	{
		z0yrk = z0rck.z0eek;
		z0mrk = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
		z0wrk = z0mrk;
		z0erk = z0mrk;
	}

	public object z0jrk()
	{
		return z0ark;
	}

	public z0ZzZzodh z0hrk()
	{
		return z0ork;
	}
}
