using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace zzz;

[DebuggerDisplay("{debuggerDisplayProxy}")]
public abstract class z0ZzZzoah : IEnumerable
{
	internal z0ZzZzoah z0oek;

	public abstract string z0th();

	public virtual z0ZzZzvsh z0sg()
	{
		return null;
	}

	internal virtual void z0gg(z0ZzZzoah p0)
	{
		if (p0 == null)
		{
			z0oek = z0wg();
		}
		else
		{
			z0oek = p0;
		}
	}

	public virtual z0ZzZzoah z0mf(z0ZzZzoah p0)
	{
		return z0tf(p0, z0iek());
	}

	public virtual z0ZzZzoah z0pf(z0ZzZzoah p0)
	{
		if (!z0fg())
		{
			throw new InvalidOperationException("Remove_Contain");
		}
		if (p0.z0ih() != this)
		{
			throw new ArgumentException("Remove_Child");
		}
		z0ZzZztah z0ZzZztah2 = (z0ZzZztah)p0;
		z0ZzZztah z0ZzZztah3 = z0jg();
		if (z0ZzZztah2 == z0iek())
		{
			if (z0ZzZztah2 == z0ZzZztah3)
			{
				z0lg(null);
				z0ZzZztah2.z0eek = null;
				z0ZzZztah2.z0gg(null);
			}
			else
			{
				z0ZzZztah z0ZzZztah4 = z0ZzZztah2.z0eek;
				if (z0ZzZztah4.z0yh() && z0ZzZztah2.z0yh())
				{
					z0rek(z0ZzZztah2, z0ZzZztah4);
				}
				z0ZzZztah3.z0eek = z0ZzZztah4;
				z0ZzZztah2.z0eek = null;
				z0ZzZztah2.z0gg(null);
			}
		}
		else if (z0ZzZztah2 == z0ZzZztah3)
		{
			z0ZzZztah z0ZzZztah5 = (z0ZzZztah)z0ZzZztah2.z0af();
			z0ZzZztah5.z0eek = z0ZzZztah2.z0eek;
			z0lg(z0ZzZztah5);
			z0ZzZztah2.z0eek = null;
			z0ZzZztah2.z0gg(null);
		}
		else
		{
			z0ZzZztah z0ZzZztah6 = (z0ZzZztah)z0ZzZztah2.z0af();
			z0ZzZztah z0ZzZztah7 = z0ZzZztah2.z0eek;
			if (z0ZzZztah7.z0yh())
			{
				if (z0ZzZztah6.z0yh())
				{
					z0eek(z0ZzZztah6, z0ZzZztah7);
				}
				else if (z0ZzZztah2.z0yh())
				{
					z0rek(z0ZzZztah2, z0ZzZztah7);
				}
			}
			z0ZzZztah6.z0eek = z0ZzZztah7;
			z0ZzZztah2.z0eek = null;
			z0ZzZztah2.z0gg(null);
		}
		return p0;
	}

	internal bool z0eek(z0ZzZzoah p0)
	{
		z0ZzZzoah z0ZzZzoah2 = z0ih();
		while (z0ZzZzoah2 != null && z0ZzZzoah2 != this)
		{
			if (z0ZzZzoah2 == p0)
			{
				return true;
			}
			z0ZzZzoah2 = z0ZzZzoah2.z0ih();
		}
		return false;
	}

	public abstract string z0ph();

	public virtual string z0eg()
	{
		z0ZzZzoah z0ZzZzoah2 = z0iek();
		if (z0ZzZzoah2 == null)
		{
			return string.Empty;
		}
		if (z0ZzZzoah2.z0qf() == null)
		{
			z0ZzZzbah z0ZzZzbah2 = z0ZzZzoah2.z0mh();
			if ((uint)(z0ZzZzbah2 - 3) <= 1u || (uint)(z0ZzZzbah2 - 13) <= 1u)
			{
				return z0ZzZzoah2.z0rh();
			}
		}
		StringBuilder p = z0ZzZzwfh.z0eek();
		z0eek(p);
		return z0ZzZzwfh.z0eek(p);
	}

	private void z0eek(StringBuilder p0)
	{
		for (z0ZzZzoah z0ZzZzoah2 = z0iek(); z0ZzZzoah2 != null; z0ZzZzoah2 = z0ZzZzoah2.z0qf())
		{
			if (z0ZzZzoah2.z0iek() == null)
			{
				if (z0ZzZzoah2.z0mh() == (z0ZzZzbah)3 || z0ZzZzoah2.z0mh() == (z0ZzZzbah)4 || z0ZzZzoah2.z0mh() == (z0ZzZzbah)13 || z0ZzZzoah2.z0mh() == (z0ZzZzbah)14)
				{
					p0.Append(z0ZzZzoah2.z0eg());
				}
			}
			else
			{
				z0ZzZzoah2.z0eek(p0);
			}
		}
	}

	internal virtual bool z0hg(z0ZzZzbah p0)
	{
		return false;
	}

	public virtual z0ZzZzfah z0wg()
	{
		if (z0oek.z0mh() == (z0ZzZzbah)9)
		{
			return (z0ZzZzfah)z0oek;
		}
		return z0oek.z0wg();
	}

	public virtual z0ZzZzoah z0eek()
	{
		return z0jg();
	}

	internal static void z0eek(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		p1.z0oek = p0;
	}

	public abstract z0ZzZzbah z0mh();

	public virtual void z0qg_jiejie20260327142557()
	{
		z0ZzZzoah z0ZzZzoah2 = z0iek();
		while (z0ZzZzoah2 != null)
		{
			z0ZzZzoah obj = z0ZzZzoah2.z0qf();
			z0pf(z0ZzZzoah2);
			z0ZzZzoah2 = obj;
		}
	}

	public virtual string z0ag()
	{
		return string.Empty;
	}

	public virtual bool z0rek()
	{
		return z0jg() != null;
	}

	public IEnumerator GetEnumerator()
	{
		return new z0ZzZzlah(this);
	}

	internal virtual bool z0gf(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		return true;
	}

	public virtual z0ZzZzoah z0ih()
	{
		if (z0oek.z0mh() != (z0ZzZzbah)9)
		{
			return z0oek;
		}
		if (z0oek.z0iek() is z0ZzZztah z0ZzZztah2)
		{
			z0ZzZztah z0ZzZztah3 = z0ZzZztah2;
			do
			{
				if (z0ZzZztah3 == this)
				{
					return z0oek;
				}
				z0ZzZztah3 = z0ZzZztah3.z0eek;
			}
			while (z0ZzZztah3 != null && z0ZzZztah3 != z0ZzZztah2);
		}
		return null;
	}

	public virtual void z0rg(string p0)
	{
		z0ZzZzoah z0ZzZzoah2 = z0iek();
		if (z0ZzZzoah2 != null && z0ZzZzoah2.z0qf() == null && z0ZzZzoah2.z0mh() == (z0ZzZzbah)3)
		{
			z0ZzZzoah2.z0oh(p0);
			return;
		}
		z0qg_jiejie20260327142557();
		z0if(z0wg().z0yek(p0));
	}

	public virtual z0ZzZzpah z0tek()
	{
		return new z0ZzZzkah(this);
	}

	public virtual z0ZzZzoah z0if(z0ZzZzoah p0)
	{
		z0ZzZzfah z0ZzZzfah2 = z0wg();
		if (z0ZzZzfah2 == null)
		{
			z0ZzZzfah2 = this as z0ZzZzfah;
		}
		if (!z0fg())
		{
			throw new InvalidOperationException("Insert_Contain");
		}
		if (this == p0 || z0eek(p0))
		{
			throw new ArgumentException("Insert_Child");
		}
		if (p0.z0ih() != null)
		{
			p0.z0ih().z0pf(p0);
		}
		z0ZzZzfah z0ZzZzfah3 = p0.z0wg();
		if (z0ZzZzfah3 != null && z0ZzZzfah3 != z0ZzZzfah2 && z0ZzZzfah3 != this)
		{
			throw new ArgumentException("Insert_Context");
		}
		if (p0.z0mh() == (z0ZzZzbah)11)
		{
			z0ZzZzoah z0ZzZzoah2 = p0.z0iek();
			z0ZzZzoah z0ZzZzoah3 = z0ZzZzoah2;
			while (z0ZzZzoah3 != null)
			{
				z0ZzZzoah obj = z0ZzZzoah3.z0qf();
				p0.z0pf(z0ZzZzoah3);
				z0if(z0ZzZzoah3);
				z0ZzZzoah3 = obj;
			}
			return z0ZzZzoah2;
		}
		if (!(p0 is z0ZzZztah) || !z0hg(p0.z0mh()))
		{
			throw new InvalidOperationException("Insert_TypeConflict");
		}
		if (!z0gf(p0, z0eek()))
		{
			throw new InvalidOperationException("Insert_Location");
		}
		z0ZzZztah z0ZzZztah2 = z0jg();
		z0ZzZztah z0ZzZztah3 = (z0ZzZztah)p0;
		if (z0ZzZztah2 == null)
		{
			z0ZzZztah3.z0eek = z0ZzZztah3;
			z0lg(z0ZzZztah3);
			z0ZzZztah3.z0gg(this);
		}
		else
		{
			z0ZzZztah3.z0eek = z0ZzZztah2.z0eek;
			z0ZzZztah2.z0eek = z0ZzZztah3;
			z0lg(z0ZzZztah3);
			z0ZzZztah3.z0gg(this);
			if (z0ZzZztah2.z0yh() && z0ZzZztah3.z0yh())
			{
				z0eek(z0ZzZztah2, z0ZzZztah3);
			}
		}
		return z0ZzZztah3;
	}

	internal static void z0eek(string p0, out string p1, out string p2)
	{
		int num = p0.IndexOf(':');
		if (-1 == num || num == 0 || p0.Length - 1 == num)
		{
			p1 = string.Empty;
			p2 = p0;
		}
		else
		{
			p1 = p0.Substring(0, num);
			p2 = p0.Substring(num + 1);
		}
	}

	public virtual z0ZzZzoah z0of(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		z0ZzZzoah p2 = p1.z0qf();
		z0pf(p1);
		z0tf(p0, p2);
		return p1;
	}

	internal virtual void z0kg(z0ZzZzoah p0)
	{
		z0oek = p0;
	}

	public virtual z0ZzZzaqh z0uf()
	{
		return z0ZzZzfah.z0hrk;
	}

	internal virtual void z0lg(z0ZzZztah p0)
	{
	}

	public abstract void z0uh(z0ZzZzdqh p0);

	public abstract void z0eh(z0ZzZzdqh p0);

	public virtual string z0tg()
	{
		return string.Empty;
	}

	internal z0ZzZzoah(z0ZzZzfah p0)
	{
		if (p0 == null)
		{
			throw new ArgumentException("Null_Doc");
		}
		z0oek = p0;
	}

	internal virtual bool z0ff(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		return true;
	}

	internal virtual z0ZzZztah z0jg()
	{
		return null;
	}

	private IEnumerator z0yek()
	{
		return new z0ZzZzlah(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yek
		return this.z0yek();
	}

	public virtual string z0uek()
	{
		StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		z0ZzZzdah z0ZzZzdah2 = new z0ZzZzdah(stringWriter);
		try
		{
			z0eh(z0ZzZzdah2);
		}
		finally
		{
			z0ZzZzdah2.z0kf();
		}
		return stringWriter.ToString();
	}

	public virtual z0ZzZzoah z0yf(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		if (this == p0 || z0eek(p0))
		{
			throw new ArgumentException("Insert_Child");
		}
		if (p1 == null)
		{
			return z0mf(p0);
		}
		if (!z0fg())
		{
			throw new InvalidOperationException("Insert_Contain");
		}
		if (p1.z0ih() != this)
		{
			throw new ArgumentException("Insert_Path");
		}
		if (p0 == p1)
		{
			return p0;
		}
		z0ZzZzfah z0ZzZzfah2 = p0.z0wg();
		z0ZzZzfah z0ZzZzfah3 = z0wg();
		if (z0ZzZzfah2 != null && z0ZzZzfah2 != z0ZzZzfah3 && z0ZzZzfah2 != this)
		{
			throw new ArgumentException("Insert_Context");
		}
		if (!z0gf(p0, p1))
		{
			throw new InvalidOperationException("Insert_Location");
		}
		if (p0.z0ih() != null)
		{
			p0.z0ih().z0pf(p0);
		}
		if (p0.z0mh() == (z0ZzZzbah)11)
		{
			z0ZzZzoah p2 = p1;
			z0ZzZzoah z0ZzZzoah2 = p0.z0iek();
			z0ZzZzoah z0ZzZzoah3 = z0ZzZzoah2;
			while (z0ZzZzoah3 != null)
			{
				z0ZzZzoah obj = z0ZzZzoah3.z0qf();
				p0.z0pf(z0ZzZzoah3);
				z0yf(z0ZzZzoah3, p2);
				p2 = z0ZzZzoah3;
				z0ZzZzoah3 = obj;
			}
			return z0ZzZzoah2;
		}
		if (!(p0 is z0ZzZztah) || !z0hg(p0.z0mh()))
		{
			throw new InvalidOperationException("Insert_TypeConflict");
		}
		z0ZzZztah z0ZzZztah2 = (z0ZzZztah)p0;
		z0ZzZztah z0ZzZztah3 = (z0ZzZztah)p1;
		if (z0ZzZztah3 == z0jg())
		{
			z0ZzZztah2.z0eek = z0ZzZztah3.z0eek;
			z0ZzZztah3.z0eek = z0ZzZztah2;
			z0lg(z0ZzZztah2);
			z0ZzZztah2.z0gg(this);
			if (z0ZzZztah3.z0yh() && z0ZzZztah2.z0yh())
			{
				z0eek(z0ZzZztah3, z0ZzZztah2);
			}
		}
		else
		{
			z0ZzZztah z0ZzZztah4 = (z0ZzZztah2.z0eek = z0ZzZztah3.z0eek);
			z0ZzZztah3.z0eek = z0ZzZztah2;
			z0ZzZztah2.z0gg(this);
			if (z0ZzZztah3.z0yh())
			{
				if (z0ZzZztah2.z0yh())
				{
					z0eek(z0ZzZztah3, z0ZzZztah2);
					if (z0ZzZztah4.z0yh())
					{
						z0eek(z0ZzZztah2, z0ZzZztah4);
					}
				}
				else if (z0ZzZztah4.z0yh())
				{
					z0rek(z0ZzZztah3, z0ZzZztah4);
				}
			}
			else if (z0ZzZztah2.z0yh() && z0ZzZztah4.z0yh())
			{
				z0eek(z0ZzZztah2, z0ZzZztah4);
			}
		}
		return z0ZzZztah2;
	}

	internal static void z0rek(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		p1.z0oek = p0.z0ih();
	}

	public virtual z0ZzZzoah z0af()
	{
		return null;
	}

	internal virtual bool z0fg()
	{
		return false;
	}

	public virtual z0ZzZzoah z0tf(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		if (this == p0 || z0eek(p0))
		{
			throw new ArgumentException("Insert_Child");
		}
		if (p1 == null)
		{
			return z0if(p0);
		}
		if (!z0fg())
		{
			throw new InvalidOperationException("Insert_Contain");
		}
		if (p1.z0ih() != this)
		{
			throw new ArgumentException("Insert_Path");
		}
		if (p0 == p1)
		{
			return p0;
		}
		z0ZzZzfah z0ZzZzfah2 = p0.z0wg();
		z0ZzZzfah z0ZzZzfah3 = z0wg();
		if (z0ZzZzfah2 != null && z0ZzZzfah2 != z0ZzZzfah3 && z0ZzZzfah2 != this)
		{
			throw new ArgumentException("Insert_Context");
		}
		if (!z0ff(p0, p1))
		{
			throw new InvalidOperationException("Insert_Location");
		}
		if (p0.z0ih() != null)
		{
			p0.z0ih().z0pf(p0);
		}
		if (p0.z0mh() == (z0ZzZzbah)11)
		{
			z0ZzZzoah z0ZzZzoah2;
			z0ZzZzoah result = (z0ZzZzoah2 = p0.z0iek());
			if (z0ZzZzoah2 != null)
			{
				p0.z0pf(z0ZzZzoah2);
				z0tf(z0ZzZzoah2, p1);
				z0yf(p0, z0ZzZzoah2);
			}
			return result;
		}
		if (!(p0 is z0ZzZztah) || !z0hg(p0.z0mh()))
		{
			throw new InvalidOperationException("Insert_TypeConflict");
		}
		z0ZzZztah z0ZzZztah2 = (z0ZzZztah)p0;
		z0ZzZztah z0ZzZztah3 = (z0ZzZztah)p1;
		if (z0ZzZztah3 == z0iek())
		{
			z0ZzZztah2.z0eek = z0ZzZztah3;
			z0jg().z0eek = z0ZzZztah2;
			z0ZzZztah2.z0gg(this);
			if (z0ZzZztah2.z0yh() && z0ZzZztah3.z0yh())
			{
				z0eek(z0ZzZztah2, z0ZzZztah3);
			}
		}
		else
		{
			z0ZzZztah z0ZzZztah4 = (z0ZzZztah)z0ZzZztah3.z0af();
			z0ZzZztah2.z0eek = z0ZzZztah3;
			z0ZzZztah4.z0eek = z0ZzZztah2;
			z0ZzZztah2.z0gg(this);
			if (z0ZzZztah4.z0yh())
			{
				if (z0ZzZztah2.z0yh())
				{
					z0eek(z0ZzZztah4, z0ZzZztah2);
					if (z0ZzZztah3.z0yh())
					{
						z0eek(z0ZzZztah2, z0ZzZztah3);
					}
				}
				else if (z0ZzZztah3.z0yh())
				{
					z0rek(z0ZzZztah4, z0ZzZztah3);
				}
			}
			else if (z0ZzZztah2.z0yh() && z0ZzZztah3.z0yh())
			{
				z0eek(z0ZzZztah2, z0ZzZztah3);
			}
		}
		return z0ZzZztah2;
	}

	public virtual z0ZzZzoah z0iek()
	{
		return z0jg()?.z0eek;
	}

	internal z0ZzZzoah()
	{
	}

	public virtual z0ZzZzoah z0qf()
	{
		return null;
	}

	internal virtual z0ZzZzoah z0eek(z0ZzZzbah p0)
	{
		for (z0ZzZzoah z0ZzZzoah2 = z0iek(); z0ZzZzoah2 != null; z0ZzZzoah2 = z0ZzZzoah2.z0qf())
		{
			if (z0ZzZzoah2.z0mh() == p0)
			{
				return z0ZzZzoah2;
			}
		}
		return null;
	}

	internal virtual bool z0yh()
	{
		return false;
	}

	public virtual string z0rh()
	{
		return null;
	}

	public virtual void z0oh(string p0)
	{
		throw new NotSupportedException(z0mh().ToString());
	}
}
