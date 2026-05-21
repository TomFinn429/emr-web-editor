using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace zzz;

public abstract class z0ZzZzxqh : IDisposable
{
	protected internal enum z0thj
	{
		z0eek,
		z0rek,
		z0tek,
		z0yek,
		z0uek,
		z0iek,
		z0oek,
		z0pek,
		z0mek,
		z0nek,
		z0bek,
		z0vek,
		z0cek
	}

	private readonly List<z0ZzZzcqh> z0lrk;

	internal char z0krk;

	private bool z0jrk;

	private object z0hrk;

	private string z0grk;

	internal z0ZzZzjwh z0frk;

	private z0ZzZzcqh z0drk;

	[CompilerGenerated]
	private bool z0srk;

	private int? z0ark;

	private CultureInfo z0qrk;

	internal z0thj z0wrk;

	[CompilerGenerated]
	private bool z0erk;

	private z0ZzZzkwh z0rrk;

	private void z0eek(z0ZzZzkwh p0)
	{
		z0ZzZznqh z0ZzZznqh2 = z0pek();
		if (z0tek(p0) != z0ZzZznqh2)
		{
			throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("JsonToken {0} is not valid for closing JsonType {1}.", CultureInfo.InvariantCulture, p0, z0ZzZznqh2));
		}
		if (z0xek() != 0)
		{
			z0wrk = z0thj.z0mek;
		}
		else
		{
			z0nek();
		}
	}

	private void z0eek()
	{
		if (z0drk.z0uek)
		{
			z0drk.z0tek++;
		}
	}

	public virtual int z0rek()
	{
		int count = z0lrk.Count;
		if (z0ZzZzdwh.z0eek(z0uek()) || z0drk.z0rek == (z0ZzZznqh)0)
		{
			return count;
		}
		return count + 1;
	}

	protected void z0tek()
	{
		z0ZzZznqh z0ZzZznqh2 = z0xek();
		switch (z0ZzZznqh2)
		{
		case (z0ZzZznqh)1:
			z0wrk = z0thj.z0uek;
			break;
		case (z0ZzZznqh)2:
			z0wrk = z0thj.z0oek;
			break;
		case (z0ZzZznqh)3:
			z0wrk = z0thj.z0bek;
			break;
		case (z0ZzZznqh)0:
			z0nek();
			break;
		default:
			throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("While setting the reader state back to current object an unexpected JsonType was encountered: {0}", CultureInfo.InvariantCulture, z0ZzZznqh2));
		}
	}

	[CompilerGenerated]
	public void z0eek(bool p0)
	{
		z0erk = p0;
	}

	[CompilerGenerated]
	public bool z0yek()
	{
		return z0erk;
	}

	internal void z0eek(z0ZzZzkwh p0, object p1)
	{
		z0eek(p0, p1, p2: true);
	}

	internal virtual z0ZzZzkwh z0uek()
	{
		return z0rrk;
	}

	public virtual object z0iek()
	{
		return z0hrk;
	}

	public void z0eek(string p0)
	{
		z0grk = p0;
	}

	protected z0ZzZzxqh()
	{
		z0wrk = z0thj.z0eek;
		z0lrk = new List<z0ZzZzcqh>(4);
		z0tek(p0: true);
	}

	internal void z0rek(bool p0)
	{
		if (z0xek() != 0)
		{
			z0wrk = z0thj.z0mek;
		}
		else
		{
			z0nek();
		}
		if (p0)
		{
			z0eek();
		}
	}

	protected z0thj z0oek()
	{
		return z0wrk;
	}

	internal virtual bool z0yq()
	{
		throw new NotImplementedException();
	}

	private z0ZzZznqh z0pek()
	{
		z0ZzZzcqh z0ZzZzcqh2;
		if (z0lrk.Count > 0)
		{
			z0ZzZzcqh2 = z0drk;
			z0drk = z0lrk[z0lrk.Count - 1];
			z0lrk.RemoveAt(z0lrk.Count - 1);
		}
		else
		{
			z0ZzZzcqh2 = z0drk;
			z0drk = default(z0ZzZzcqh);
		}
		if (z0ark.HasValue && z0rek() <= z0ark)
		{
			z0jrk = false;
		}
		return z0ZzZzcqh2.z0rek;
	}

	private void z0eek(z0ZzZznqh p0)
	{
		z0eek();
		if (z0drk.z0rek == (z0ZzZznqh)0)
		{
			z0drk = new z0ZzZzcqh(p0);
			return;
		}
		z0lrk.Add(z0drk);
		z0drk = new z0ZzZzcqh(p0);
		if (!z0ark.HasValue || !(z0rek() + 1 > z0ark) || z0jrk)
		{
			return;
		}
		z0jrk = true;
		throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("The reader's MaxDepth of {0} has been exceeded.", CultureInfo.InvariantCulture, z0ark));
	}

	public string z0mek()
	{
		return z0grk;
	}

	public void z0eek(CultureInfo p0)
	{
		z0qrk = p0;
	}

	private void z0nek()
	{
		if (z0yek())
		{
			z0wrk = z0thj.z0eek;
		}
		else
		{
			z0wrk = z0thj.z0cek;
		}
	}

	[CompilerGenerated]
	public void z0tek(bool p0)
	{
		z0srk = p0;
	}

	public virtual string z0bek()
	{
		return null;
	}

	[CompilerGenerated]
	public bool z0vek()
	{
		return z0srk;
	}

	internal void z0rek(z0ZzZzkwh p0)
	{
		z0eek(p0, null, p2: true);
	}

	private void z0cek()
	{
		z0yek(p0: true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0cek
		this.z0cek();
	}

	internal void z0eek(z0ZzZzkwh p0, object p1, bool p2)
	{
		z0rrk = p0;
		z0hrk = p1;
		switch (p0)
		{
		case (z0ZzZzkwh)1:
			z0wrk = z0thj.z0yek;
			z0eek((z0ZzZznqh)1);
			break;
		case (z0ZzZzkwh)2:
			z0wrk = z0thj.z0iek;
			z0eek((z0ZzZznqh)2);
			break;
		case (z0ZzZzkwh)3:
			z0wrk = z0thj.z0nek;
			z0eek((z0ZzZznqh)3);
			break;
		case (z0ZzZzkwh)13:
			z0eek((z0ZzZzkwh)13);
			break;
		case (z0ZzZzkwh)14:
			z0eek((z0ZzZzkwh)14);
			break;
		case (z0ZzZzkwh)15:
			z0eek((z0ZzZzkwh)15);
			break;
		case (z0ZzZzkwh)4:
			z0wrk = z0thj.z0tek;
			z0drk.z0yek = (string)p1;
			break;
		case (z0ZzZzkwh)6:
		case (z0ZzZzkwh)7:
		case (z0ZzZzkwh)8:
		case (z0ZzZzkwh)9:
		case (z0ZzZzkwh)10:
		case (z0ZzZzkwh)11:
		case (z0ZzZzkwh)12:
		case (z0ZzZzkwh)16:
		case (z0ZzZzkwh)17:
			z0rek(p2);
			break;
		case (z0ZzZzkwh)5:
			break;
		}
	}

	public virtual void z0eq()
	{
		z0wrk = z0thj.z0pek;
		z0rrk = (z0ZzZzkwh)0;
		z0hrk = null;
	}

	private z0ZzZznqh z0tek(z0ZzZzkwh p0)
	{
		return p0 switch
		{
			(z0ZzZzkwh)13 => (z0ZzZznqh)1, 
			(z0ZzZzkwh)14 => (z0ZzZznqh)2, 
			(z0ZzZzkwh)15 => (z0ZzZznqh)3, 
			_ => throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Not a valid close JsonToken: {0}", CultureInfo.InvariantCulture, p0)), 
		};
	}

	protected virtual void z0yek(bool p0)
	{
		if (z0wrk != z0thj.z0pek && p0)
		{
			z0eq();
		}
	}

	private z0ZzZznqh z0xek()
	{
		return z0drk.z0rek;
	}

	public CultureInfo z0zek()
	{
		return z0qrk ?? CultureInfo.InvariantCulture;
	}

	public abstract bool z0uq();
}
