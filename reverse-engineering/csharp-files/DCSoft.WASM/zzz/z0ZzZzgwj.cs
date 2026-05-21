using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace zzz;

internal class z0ZzZzgwj : z0ZzZzswj
{
	[CompilerGenerated]
	private sealed class z0iuk
	{
		public z0ZzZzdsj z0rek;

		internal object z0eek(z0ZzZzkgj p0)
		{
			return z0rek.z0uek(p0.z0eek(new z0ZzZzeaj(z0rek)));
		}
	}

	private z0ZzZzwsj z0oek;

	private IList<z0ZzZzkgj> z0pek = new List<z0ZzZzkgj>();

	private z0ZzZziwj z0mek;

	private readonly double z0nek = 1.0;

	private double z0bek = -1.0;

	private z0ZzZziwj z0cek;

	private z0ZzZziwj z0xek;

	private zzz.z0ZzZzaaj<z0ZzZzkgj> z0eek(z0ZzZzdsj p0)
	{
		return new zzz.z0ZzZzaaj<z0ZzZzkgj>(z0pek, (z0ZzZzkgj z0ZzZzkgj2) => p0.z0uek(z0ZzZzkgj2.z0eek(new z0ZzZzeaj(p0))));
	}

	internal void z0eek(z0ZzZziwj p0)
	{
		z0eek(p0, "IncorrectPageArtBox");
		z0mek = p0;
	}

	internal void z0rek(z0ZzZziwj p0)
	{
		z0eek(p0, "IncorrectPageTrimBox");
		z0xek = p0;
	}

	internal z0ZzZzgwj(z0ZzZzugj p0, z0ZzZziwj p1, z0ZzZziwj p2, int p3)
		: base(p0, p1, p2, p3)
	{
		z0eek(p0.z0rek().z0eek(p0.z0uek(), p1: false));
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		z0eek();
		object obj = base.z0ngk(p0);
		if (obj is z0ZzZzeaj z0ZzZzeaj2)
		{
			z0ZzZzeaj2.Add("Type", new z0ZzZzhwj("Page"));
			z0ZzZziwj p1 = base.z0yek();
			z0ZzZzeaj2.z0tek_jiejie20260327142557("BleedBox", z0tek(), p1);
			z0ZzZzeaj2.z0tek_jiejie20260327142557("TrimBox", z0yek(), p1);
			z0ZzZzeaj2.z0tek_jiejie20260327142557("ArtBox", z0rek(), p1);
			if (z0pek != null)
			{
				int count = z0pek.Count;
				if (count > 1)
				{
					z0ZzZzeaj2.Add("Contents", z0eek(p0));
				}
				else if (count == 1)
				{
					z0ZzZzeaj2.z0tek_jiejie20260327142557("Contents", z0pek[0].z0eek(new z0ZzZzeaj(p0)));
				}
			}
			else
			{
				z0ZzZzeaj2.Add("Contents", z0oek);
			}
			z0ZzZzeaj2.z0tek_jiejie20260327142557("Dur", z0bek, -1.0);
			z0ZzZzeaj2.z0tek_jiejie20260327142557("UserUnit", z0nek, 1.0);
		}
		return obj;
	}

	private new void z0eek()
	{
	}

	protected override void z0xgk()
	{
		base.z0xgk();
		z0ZzZziwj z0ZzZziwj2 = base.z0tek();
		if (z0ZzZziwj2 != null)
		{
			z0ZzZziwj p = z0tek();
			if (!z0ZzZziwj2.z0eek(p))
			{
				z0tek(z0ZzZziwj2.z0rek(p));
			}
			z0ZzZziwj p2 = z0yek();
			if (!z0ZzZziwj2.z0eek(p2))
			{
				z0rek(z0ZzZziwj2.z0rek(p2));
			}
			z0ZzZziwj p3 = z0rek();
			if (!z0ZzZziwj2.z0eek(p3))
			{
				z0eek(z0ZzZziwj2.z0rek(p3));
			}
		}
	}

	internal void z0eek(byte[] p0)
	{
		z0eek();
		z0pek.Clear();
		z0eek(p0, 0);
	}

	private void z0eek(byte[] p0, int p1)
	{
		z0pek.Insert(p1, new z0ZzZzkgj(p0));
	}

	internal new z0ZzZziwj z0rek()
	{
		return z0mek ?? base.z0yek();
	}

	internal override void z0cgk(z0ZzZzdsj p0)
	{
		base.z0cgk(p0);
		int count = z0pek.Count;
		if (count > 1)
		{
			int p1 = p0.z0cek();
			p0.z0uek(new z0ZzZzssj(p1, 0, z0eek(p0)), p1: false);
			z0oek = new z0ZzZzwsj(p1);
		}
		else if (count == 1)
		{
			z0oek = p0.z0uek(z0pek[0].z0eek(new z0ZzZzeaj(p0)));
		}
		z0pek = null;
	}

	internal new z0ZzZziwj z0tek()
	{
		return z0cek ?? base.z0yek();
	}

	internal void z0tek(z0ZzZziwj p0)
	{
		z0eek(p0, "IncorrectPageBleedBox");
		z0cek = p0;
	}

	internal new z0ZzZziwj z0yek()
	{
		return z0xek ?? base.z0yek();
	}
}
