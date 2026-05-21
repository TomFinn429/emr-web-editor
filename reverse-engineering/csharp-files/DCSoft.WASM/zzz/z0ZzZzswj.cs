using System;

namespace zzz;

internal abstract class z0ZzZzswj : z0ZzZzfsj
{
	private readonly z0ZzZzugj z0pek;

	private int z0nek;

	private z0ZzZziwj z0vek;

	private z0ZzZziwj z0cek;

	private z0ZzZzmsj z0xek;

	private z0ZzZzusj z0zek;

	private z0ZzZzwsj z0krk;

	internal new z0ZzZzusj z0eek()
	{
		return z0zek;
	}

	protected z0ZzZzswj(z0ZzZzugj p0, z0ZzZziwj p1, z0ZzZziwj p2, int p3)
	{
		z0pek = p0;
		z0vek = p1;
		z0cek = p2;
		z0eek(p3);
		z0eek(p2, "IncorrectPageCropBox");
		z0xek = new z0ZzZzmsj(p0, p1: true);
	}

	internal virtual void z0cgk(z0ZzZzdsj p0)
	{
		z0krk = p0.z0oek(z0xek);
		z0xek = null;
	}

	internal new void z0eek(int p0)
	{
		p0 = z0rek(p0);
		if (!z0tek(p0))
		{
			throw new ArgumentOutOfRangeException("Rotate", "IncorrectPageRotate");
		}
		z0nek = p0;
	}

	protected virtual void z0xgk()
	{
		z0ZzZziwj z0ZzZziwj2 = z0yek();
		if (z0vek != null && z0ZzZziwj2 != null && !z0vek.z0eek(z0ZzZziwj2))
		{
			z0cek = z0vek.z0rek(z0ZzZziwj2);
		}
	}

	internal new z0ZzZzmsj z0rek()
	{
		if (z0xek == null)
		{
			z0xek = new z0ZzZzmsj(z0pek, p1: false);
		}
		return z0xek;
	}

	internal static int z0rek(int p0)
	{
		int num = -360;
		if (p0 < 0)
		{
			num = 360;
		}
		while ((p0 < 0 && num > 0) || (p0 > 270 && num < 0))
		{
			p0 += num;
		}
		return p0;
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(p0);
		if (z0zek == null)
		{
			z0ZzZzeaj2.z0tek_jiejie20260327142557("MediaBox", z0vek);
			z0ZzZzeaj2.z0tek_jiejie20260327142557("CropBox", z0cek, z0vek);
			z0ZzZzeaj2.z0tek_jiejie20260327142557("Rotate", z0nek, 0);
		}
		else
		{
			z0ZzZzusj z0ZzZzusj2 = p0.z0mek().z0rek().z0eek(p0, p1: false);
			z0ZzZzeaj2.Add("Parent", new z0ZzZzwsj(((z0ZzZzogj)z0ZzZzusj2).z0rek()));
			z0ZzZzeaj2.z0tek_jiejie20260327142557("MediaBox", z0vek, z0ZzZzusj2.z0vek);
			z0ZzZzeaj2.z0tek_jiejie20260327142557("CropBox", z0yek(), z0ZzZzusj2.z0yek());
			z0ZzZzeaj2.z0tek_jiejie20260327142557("Rotate", z0nek, z0ZzZzusj2.z0uek());
		}
		if (z0krk == null)
		{
			z0ZzZzeaj2.z0tek_jiejie20260327142557("Resources", z0xek);
		}
		else
		{
			z0ZzZzeaj2.Add("Resources", z0krk);
		}
		return z0ZzZzeaj2;
	}

	internal z0ZzZziwj z0tek()
	{
		return z0vek;
	}

	internal z0ZzZziwj z0yek()
	{
		return z0cek ?? z0vek;
	}

	internal int z0uek()
	{
		return z0nek;
	}

	internal void z0eek(z0ZzZzusj p0)
	{
		z0zek = p0;
	}

	internal static bool z0tek(int p0)
	{
		if (p0 != 0 && p0 != 90 && p0 != 180)
		{
			return p0 == 270;
		}
		return true;
	}

	protected void z0eek(z0ZzZziwj p0, string p1)
	{
		if (p0 != null && !z0vek.z0eek(p0))
		{
			throw new ArgumentOutOfRangeException(p1);
		}
	}
}
