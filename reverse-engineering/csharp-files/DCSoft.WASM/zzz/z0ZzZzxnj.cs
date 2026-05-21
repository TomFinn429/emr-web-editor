using System;
using DCSoft.Drawing;

namespace zzz;

public class z0ZzZzxnj : z0ZzZzqrj
{
	private new bool z0mek;

	public new static int z0nek = 2;

	public new static int z0bek = 6;

	protected new bool z0vek = true;

	protected new bool z0cek = true;

	private new bool z0xek;

	private new bool z0zek = true;

	public new void z0eek(bool p0)
	{
		z0cek = p0;
	}

	public new void z0rek(bool p0)
	{
		z0mek = p0;
	}

	public new void z0tek(bool p0)
	{
		z0vek = p0;
	}

	public new bool z0eek()
	{
		return z0mek;
	}

	protected new void z0rek()
	{
		if (this is z0ZzZzqbj)
		{
			((z0ZzZzqbj)this).z0ayk().z0vz(0, 0, 0, 0, 0, p5: false, p6: false, p7: false);
		}
	}

	public new virtual void z0yek(bool p0)
	{
		z0zek = p0;
	}

	public bool z0eek(int p0, int p1, int p2, int p3, int p4, bool p5)
	{
		if (((z0ZzZzspj)this).z0hrk() || !((z0ZzZzmwh)this).z0eek())
		{
			return false;
		}
		if (!z0eek() && !z0oc())
		{
			z0rek();
			if (z0uek())
			{
				z0eek(p0, p1, Math.Max(p2, p4), p3);
			}
			return false;
		}
		if (p2 > 0 && p3 > 0)
		{
			if (z0uek())
			{
				z0eek(p0, p1, Math.Max(p2, p4), p3);
			}
			if (this is z0ZzZzqbj)
			{
				z0ZzZzqbj z0ZzZzqbj2 = (z0ZzZzqbj)this;
				if (!z0ZzZzqbj2.z0apk)
				{
					z0ZzZzqbj.z0dgj z0dgj = z0ZzZzqbj2.z0tek(PageContentPartyStyle.Body, p0, p1);
					if (z0dgj != null)
					{
						int p6 = (int)((float)p2 * z0ZzZzqbj2.z0kyk());
						int p7 = (int)((float)z0ZzZzqbj2.z0qtk().z0grk(p3) * z0ZzZzqbj2.z0kyk());
						z0ZzZzqbj2.z0ayk()?.z0vz(z0dgj.z0iek, z0dgj.z0eek, z0dgj.z0yek, p6, p7, p5: true, p5, z0uek());
					}
				}
			}
			return z0uek();
		}
		return false;
	}

	public new bool z0tek()
	{
		return z0cek;
	}

	public new void z0yek()
	{
	}

	public new bool z0uek()
	{
		return z0vek;
	}

	public new virtual bool z0iek()
	{
		return z0zek;
	}

	public bool z0eek(int p0, int p1, int p2, int p3, bool p4)
	{
		return z0eek(p0, p1 - p2, z0zek ? z0nek : z0bek, p2, p3, p4);
	}

	public new void z0oek()
	{
		z0rek();
	}

	public new bool z0pek()
	{
		return z0xek;
	}

	protected override void z0nx(EventArgs p0)
	{
		z0rek();
		base.z0nx(p0);
	}
}
