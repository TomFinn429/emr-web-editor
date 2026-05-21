using System;

namespace zzz;

public class z0ZzZzmah : z0ZzZzcah
{
	private bool z0uek;

	private z0ZzZzbah z0iek;

	private bool z0oek;

	private readonly z0ZzZznah z0pek;

	private z0ZzZzush z0mek;

	private z0ZzZzish z0nek;

	private bool z0bek;

	private int z0vek;

	private bool z0cek;

	public override bool z0ua()
	{
		return z0tek(p0: false);
	}

	public override bool z0zh()
	{
		return true;
	}

	public override string z0zs()
	{
		if (!z0tek())
		{
			return string.Empty;
		}
		return z0pek.z0eek();
	}

	private void z0eek()
	{
		z0pek.z0eek(ref z0vek, ref z0iek);
	}

	private new void z0rek()
	{
		z0oek = false;
		z0mek.z0rek();
	}

	public override z0ZzZzbah z0la()
	{
		if (!z0tek())
		{
			return (z0ZzZzbah)0;
		}
		return z0iek;
	}

	public override string z0xh()
	{
		if (!z0tek())
		{
			return string.Empty;
		}
		return z0pek.z0bek();
	}

	public override bool z0ch()
	{
		if (!z0tek())
		{
			return false;
		}
		return z0pek.z0jrk();
	}

	public override int z0ea()
	{
		return z0vek;
	}

	private bool z0eek(bool p0)
	{
		if (z0nek == (z0ZzZzish)2)
		{
			return false;
		}
		if (!z0uek && z0vek == 0)
		{
			return z0rek(p0);
		}
		if (z0pek.z0zek())
		{
			z0iek = z0pek.z0yek();
			return true;
		}
		if (z0vek == 0)
		{
			return z0rek(p0);
		}
		if (z0pek.z0iek())
		{
			if (z0pek.z0yek() == (z0ZzZzbah)1)
			{
				z0vek--;
				z0iek = (z0ZzZzbah)15;
				return true;
			}
			if (z0pek.z0yek() == (z0ZzZzbah)5)
			{
				z0vek--;
				z0iek = (z0ZzZzbah)16;
				return true;
			}
			return true;
		}
		return false;
	}

	public override bool z0ta()
	{
		if (!z0tek())
		{
			return false;
		}
		z0pek.z0eek(z0vek);
		z0pek.z0eek(ref z0vek);
		if (z0pek.z0xek())
		{
			z0vek--;
			z0iek = z0pek.z0yek();
			if (z0oek)
			{
				z0rek();
			}
			return true;
		}
		z0pek.z0rek(ref z0vek);
		return false;
	}

	public override string z0ba(string p0, string p1)
	{
		if (!z0tek())
		{
			return null;
		}
		string p2 = ((p1 == null) ? string.Empty : p1);
		return z0pek.z0eek(p0, p2);
	}

	public override bool z0vh()
	{
		return true;
	}

	internal new bool z0tek()
	{
		return z0nek == (z0ZzZzish)1;
	}

	public override int z0va(byte[] p0, int p1, int p2)
	{
		if (z0nek != (z0ZzZzish)1)
		{
			return 0;
		}
		if (!z0oek)
		{
			z0mek = z0ZzZzush.z0eek(z0mek, this);
		}
		z0oek = false;
		int result = z0mek.z0eek(p0, p1, p2);
		z0oek = true;
		return result;
	}

	public override bool z0pa()
	{
		if (!z0tek() || z0iek == (z0ZzZzbah)15)
		{
			return false;
		}
		z0pek.z0eek(z0vek);
		z0pek.z0eek(ref z0vek);
		if (z0pek.z0tek(ref z0vek))
		{
			z0iek = z0pek.z0yek();
			if (z0oek)
			{
				z0rek();
			}
			return true;
		}
		z0pek.z0rek(ref z0vek);
		return false;
	}

	public override bool z0ja()
	{
		if (!z0tek())
		{
			return false;
		}
		z0pek.z0eek(ref z0vek, ref z0iek);
		if (z0ka() > 0)
		{
			z0pek.z0rek(0);
			z0vek++;
			z0iek = z0pek.z0yek();
			if (z0oek)
			{
				z0rek();
			}
			return true;
		}
		z0pek.z0rek(ref z0vek);
		return false;
	}

	public override bool z0bh()
	{
		return z0ka() > 0;
	}

	public override int z0ka()
	{
		if (!z0tek() || z0iek == (z0ZzZzbah)15)
		{
			return 0;
		}
		return z0pek.z0uek();
	}

	public override z0ZzZzish z0xs()
	{
		return z0nek;
	}

	public override bool z0na_jiejie20260327142557(string p0)
	{
		if (!z0tek())
		{
			return false;
		}
		z0pek.z0eek(ref z0vek, ref z0iek);
		if (z0pek.z0rek(p0))
		{
			z0vek++;
			z0iek = z0pek.z0yek();
			if (z0oek)
			{
				z0rek();
			}
			return true;
		}
		z0pek.z0rek(ref z0vek);
		return false;
	}

	public override string z0fa()
	{
		if (!z0tek())
		{
			return string.Empty;
		}
		return z0pek.z0rek();
	}

	public override bool z0ga()
	{
		if (z0nek != (z0ZzZzish)4)
		{
			return z0cek;
		}
		return false;
	}

	private bool z0rek(bool p0)
	{
		if (!p0 && z0iek != (z0ZzZzbah)15 && z0pek.z0yek() == (z0ZzZzbah)1 && !z0pek.z0hrk())
		{
			z0iek = (z0ZzZzbah)15;
			return true;
		}
		z0yek();
		return false;
	}

	public override string z0ma()
	{
		if (!z0tek())
		{
			return string.Empty;
		}
		return z0pek.z0oek_jiejie20260327142557();
	}

	public override void z0sa()
	{
		if (!z0tek() || z0iek != (z0ZzZzbah)5)
		{
			throw new InvalidOperationException();
		}
		z0bek = true;
	}

	private bool z0tek(bool p0)
	{
		if (z0cek)
		{
			return false;
		}
		if (z0nek == (z0ZzZzish)0)
		{
			if (z0pek.z0yek() == (z0ZzZzbah)9 || z0pek.z0yek() == (z0ZzZzbah)11)
			{
				z0uek = true;
				if (!z0yek(p0))
				{
					z0nek = (z0ZzZzish)2;
					return false;
				}
			}
			z0eek();
			z0nek = (z0ZzZzish)1;
			z0iek = z0pek.z0yek();
			z0vek = 0;
			return true;
		}
		if (z0oek)
		{
			z0rek();
		}
		if (z0pek.z0tek())
		{
			return false;
		}
		z0eek();
		if (z0yek(p0))
		{
			return true;
		}
		if (z0nek == (z0ZzZzish)0 || z0nek == (z0ZzZzish)1)
		{
			z0nek = (z0ZzZzish)2;
		}
		if (z0nek == (z0ZzZzish)3)
		{
			z0iek = (z0ZzZzbah)0;
		}
		return false;
	}

	public override void z0ha()
	{
		z0nek = (z0ZzZzish)4;
	}

	public override void z0ia()
	{
		z0tek(p0: true);
	}

	private new void z0yek()
	{
		z0cek = true;
		z0nek = (z0ZzZzish)3;
		z0iek = (z0ZzZzbah)0;
	}

	public override string z0ra()
	{
		if (z0la() == (z0ZzZzbah)5 && z0bek && !z0ua())
		{
			throw new InvalidOperationException();
		}
		return base.z0ra();
	}

	public override z0ZzZzaqh z0nh()
	{
		if (!z0tek())
		{
			return null;
		}
		return z0pek.z0nek();
	}

	public override string z0aa()
	{
		if (!z0tek())
		{
			return string.Empty;
		}
		return z0pek.z0mek();
	}

	public override string z0wa(string p0)
	{
		if (!z0tek())
		{
			return null;
		}
		string text = z0pek.z0tek(p0);
		if (text != null && text.Length == 0)
		{
			return null;
		}
		return text;
	}

	public override bool z0ya()
	{
		if (!z0tek())
		{
			return false;
		}
		return z0pek.z0hrk();
	}

	public z0ZzZzmah(z0ZzZzoah p0)
	{
		ArgumentNullException.ThrowIfNull(p0, "node");
		z0pek = new z0ZzZznah(p0);
		z0vek = 0;
		z0nek = (z0ZzZzish)0;
		z0cek = false;
		z0iek = (z0ZzZzbah)0;
		z0bek = false;
		z0uek = false;
	}

	public override z0ZzZziah z0oa()
	{
		return z0pek.z0lrk();
	}

	private bool z0yek(bool p0)
	{
		if (z0nek != (z0ZzZzish)1 && z0nek != 0)
		{
			z0iek = (z0ZzZzbah)0;
			return false;
		}
		bool num = !p0;
		z0ZzZzbah z0ZzZzbah2 = z0pek.z0yek();
		if (num && z0iek != (z0ZzZzbah)15 && z0iek != (z0ZzZzbah)16 && (z0ZzZzbah2 == (z0ZzZzbah)1 || (z0ZzZzbah2 == (z0ZzZzbah)5 && z0bek) || ((z0pek.z0yek() == (z0ZzZzbah)9 || z0pek.z0yek() == (z0ZzZzbah)11) && z0nek == (z0ZzZzish)0)))
		{
			if (z0pek.z0pek())
			{
				z0iek = z0pek.z0yek();
				z0vek++;
				if (z0bek)
				{
					z0bek = false;
				}
				return true;
			}
			if (z0pek.z0yek() == (z0ZzZzbah)1 && !z0pek.z0hrk())
			{
				z0iek = (z0ZzZzbah)15;
				return true;
			}
			if (z0pek.z0yek() == (z0ZzZzbah)5 && z0bek)
			{
				z0bek = false;
				z0iek = (z0ZzZzbah)16;
				return true;
			}
			return z0eek(p0);
		}
		if (z0pek.z0yek() == (z0ZzZzbah)5 && z0bek)
		{
			if (z0pek.z0pek())
			{
				z0iek = z0pek.z0yek();
				z0vek++;
			}
			else
			{
				z0iek = (z0ZzZzbah)16;
			}
			z0bek = false;
			return true;
		}
		return z0eek(p0);
	}
}
