using System;
using System.Globalization;

namespace zzz;

public abstract class z0ZzZzcah : IDisposable
{
	public virtual string z0xh()
	{
		if (z0aa().Length != 0)
		{
			return z0oa().z0nf(z0aa() + ":" + z0ma());
		}
		return z0ma();
	}

	private bool z0eek()
	{
		z0ta();
		if (z0la() == (z0ZzZzbah)1 && !z0ya())
		{
			int num = z0ea();
			while (z0ua() && num < z0ea())
			{
			}
			if (z0la() == (z0ZzZzbah)15)
			{
				return z0ua();
			}
			return false;
		}
		return z0ua();
	}

	public abstract z0ZzZzish z0xs();

	public abstract bool z0ua();

	public virtual void z0rek()
	{
		if (z0da() != (z0ZzZzbah)15)
		{
			throw new z0ZzZzeah();
		}
		z0ua();
	}

	public abstract bool z0ta();

	public virtual bool z0bh()
	{
		return z0ka() > 0;
	}

	public virtual bool z0tek()
	{
		return false;
	}

	public abstract string z0wa(string p0);

	public virtual bool z0zh()
	{
		return false;
	}

	public abstract string z0zs();

	public abstract z0ZzZzbah z0la();

	public abstract string z0ma();

	public abstract z0ZzZziah z0oa();

	public abstract int z0ea();

	public abstract string z0fa();

	public virtual bool z0vh()
	{
		return false;
	}

	public abstract bool z0pa();

	public virtual void z0ia()
	{
		if (z0xs() == (z0ZzZzish)1)
		{
			z0eek();
		}
	}

	public abstract void z0sa();

	public virtual string z0ra()
	{
		if (z0xs() != (z0ZzZzish)1)
		{
			return string.Empty;
		}
		z0ta();
		if (z0la() == (z0ZzZzbah)1)
		{
			if (z0ya())
			{
				return string.Empty;
			}
			if (!z0ua())
			{
				throw new InvalidOperationException();
			}
			if (z0la() == (z0ZzZzbah)15)
			{
				return string.Empty;
			}
		}
		string text = string.Empty;
		while (z0eek(z0la()))
		{
			text += z0fa();
			if (!z0ua())
			{
				break;
			}
		}
		return text;
	}

	public abstract string z0aa();

	internal static Exception z0eek(string p0, z0ZzZzbah p1, z0ZzZztsh p2)
	{
		return new InvalidOperationException(z0eek("InvalidReadElementContentAs:" + p0 + " " + p1, p2));
	}

	public virtual z0ZzZzaqh z0nh()
	{
		return this as z0ZzZzaqh;
	}

	public virtual void z0ha()
	{
	}

	private static string z0eek(string p0, z0ZzZztsh p1)
	{
		if (p1 != null)
		{
			return p0 + " ErrorPosition:" + new object[2]
			{
				p1.z0rek().ToString(CultureInfo.InvariantCulture),
				p1.z0eek().ToString(CultureInfo.InvariantCulture)
			};
		}
		return p0;
	}

	public virtual void z0yek()
	{
		if (z0da() != (z0ZzZzbah)1)
		{
			throw new z0ZzZzeah();
		}
		z0ua();
	}

	internal static bool z0eek(z0ZzZzbah p0)
	{
		return (0x6018uL & (ulong)(1 << (int)p0)) != 0;
	}

	public virtual string z0qa_jiejie20260327142557()
	{
		string result = string.Empty;
		if (z0da() != (z0ZzZzbah)1)
		{
			throw new z0ZzZzeah();
		}
		if (!z0ya())
		{
			z0ua();
			result = z0ra();
			if (z0la() != (z0ZzZzbah)15)
			{
				throw new z0ZzZzeah();
			}
			z0ua();
		}
		else
		{
			z0ua();
		}
		return result;
	}

	public abstract bool z0ya();

	public static bool z0eek(string p0)
	{
		ArgumentNullException.ThrowIfNull(p0, "str");
		return z0ZzZzmsh.z0eek(p0);
	}

	internal Exception z0rek(string p0)
	{
		return z0eek(p0, z0la(), this as z0ZzZztsh);
	}

	public virtual int z0eek(char[] p0, int p1, int p2)
	{
		throw new NotSupportedException();
	}

	public virtual int z0va(byte[] p0, int p1, int p2)
	{
		throw new NotSupportedException();
	}

	public virtual z0ZzZzbah z0da()
	{
		do
		{
			switch (z0la())
			{
			case (z0ZzZzbah)2:
				z0ta();
				return z0la();
			case (z0ZzZzbah)1:
			case (z0ZzZzbah)3:
			case (z0ZzZzbah)4:
			case (z0ZzZzbah)5:
			case (z0ZzZzbah)15:
			case (z0ZzZzbah)16:
				return z0la();
			}
		}
		while (z0ua());
		return z0la();
	}

	public abstract bool z0ga();

	public abstract string z0ba(string p0, string p1);

	public abstract bool z0na_jiejie20260327142557(string p0);

	public virtual bool z0ch()
	{
		return false;
	}

	public abstract bool z0ja();

	public void Dispose()
	{
		z0ha();
	}

	public abstract int z0ka();

	public virtual bool z0eek(string p0, string p1)
	{
		if (z0da() == (z0ZzZzbah)1 && z0ma() == p0)
		{
			return z0zs() == p1;
		}
		return false;
	}
}
