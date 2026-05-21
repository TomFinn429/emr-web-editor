using System;
using System.Text;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzzjh
{
	private string z0bek;

	private z0ZzZzeok z0vek;

	public void z0rek(byte[] p0)
	{
		if (p0 == null)
		{
			z0vek.z0eek("null", p1: false);
		}
		else
		{
			z0vek.z0eek("\"" + Convert.ToBase64String(p0) + "\"", p1: false);
		}
	}

	public virtual void z0eek<EnumType>(string p0, EnumType p1) where EnumType : Enum
	{
		z0oek();
		z0vek.z0eek(p0, zzz.z0ZzZzcyk<EnumType>.z0rek(p1), z0ZzZzeok.z0mjj.z0tek);
	}

	public void z0rek()
	{
	}

	public void z0rek(string p0, char p1)
	{
		z0oek();
		z0vek.z0eek(p0, z0ZzZzqik.z0yek(p1), z0ZzZzeok.z0mjj.z0tek);
	}

	public void z0rek(string p0, string p1, z0ZzZzeok.z0mjj p2)
	{
		if (p1 != null && p1.Length > 0)
		{
			z0oek();
			z0vek.z0eek(p0, p1, p2);
		}
	}

	public void z0tek()
	{
		z0oek();
		z0vek.z0ewk();
	}

	public void z0rek(string p0, DateTime p1)
	{
		z0oek();
		z0vek.z0eek(p0, z0ZzZzuyk.z0rek(p1), z0ZzZzeok.z0mjj.z0tek);
	}

	public void z0rek(string p0)
	{
		z0vek.z0ewk();
		z0vek.z0eek("Type", p0);
	}

	public void z0tek(string p0)
	{
		z0vek.z0eek(p0, p1: true);
	}

	public void z0rek(string p0, float p1)
	{
		z0oek();
		z0vek.z0eek(p0, z0ZzZzqik.z0eek(p1, 10), z0ZzZzeok.z0mjj.z0rek);
	}

	public z0ZzZzzjh(StringBuilder p0, bool p1)
	{
		z0vek = new z0ZzZzeok(p0);
		z0vek.z0mek = p1;
	}

	public void z0rek(string p0, bool p1)
	{
		z0oek();
		z0vek.z0eek(p0, p1 ? "true" : "false", z0ZzZzeok.z0mjj.z0rek);
	}

	public void z0rek(string p0, double p1)
	{
		z0oek();
		z0vek.z0eek(p0, p1.ToString(), z0ZzZzeok.z0mjj.z0rek);
	}

	public void z0yek()
	{
		z0vek.z0wwk();
	}

	public virtual void z0uek()
	{
		if (z0bek == null)
		{
			z0vek.z0qwk();
			z0vek.z0wwk();
		}
		else
		{
			z0bek = null;
		}
	}

	public virtual void z0yek(string p0)
	{
		z0oek();
		z0bek = p0;
	}

	public void z0iek()
	{
		z0oek();
		z0vek.z0swk();
	}

	public void z0rek(string p0, Color p1)
	{
		z0oek();
		z0vek.z0eek(p0, z0ZzZzlok.z0eek(p1), z0ZzZzeok.z0mjj.z0tek);
	}

	private void z0oek()
	{
		if (z0bek != null)
		{
			z0vek.z0rwk(z0bek);
			z0bek = null;
			z0vek.z0ewk();
		}
	}

	public void z0rek(bool p0)
	{
		z0vek.z0mek = p0;
	}

	public bool z0pek()
	{
		return z0vek.z0mek;
	}

	public void z0rek(string p0, string p1)
	{
		if (p1 != null && p1.Length > 0)
		{
			z0oek();
			z0vek.z0eek(p0, p1);
		}
	}

	public void z0rek(string p0, int p1)
	{
		z0oek();
		z0vek.z0eek(p0, z0ZzZzqik.z0rek(p1), z0ZzZzeok.z0mjj.z0rek);
	}

	public void z0mek()
	{
		z0vek.z0qwk();
	}

	public void z0uek(string p0)
	{
		z0oek();
		z0vek.z0rwk(p0);
	}

	public void z0rek(string p0, byte[] p1)
	{
		if (p1 != null && p1.Length != 0)
		{
			z0oek();
			z0vek.z0eek(p0, Convert.ToBase64String(p1), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	public void z0nek()
	{
		z0vek.z0awk();
	}
}
