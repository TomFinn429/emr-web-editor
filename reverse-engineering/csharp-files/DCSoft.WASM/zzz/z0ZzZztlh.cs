using System;
using DCSoft.Common;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZztlh
{
	private DocumentComment z0cek;

	private string z0xek;

	[NonSerialized]
	private XTextElement z0zek;

	private ValueValidateResultTypes z0lrk_jiejie20260327142557;

	private string z0krk;

	private string z0jrk;

	private ValueValidateLevel z0hrk;

	public void z0eek(string p0)
	{
		z0xek = p0;
	}

	public bool z0eek(z0ZzZztlh p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0 == this)
		{
			return true;
		}
		if (z0lrk_jiejie20260327142557 == p0.z0lrk_jiejie20260327142557 && z0zek == p0.z0zek && z0hrk == p0.z0hrk && z0krk == p0.z0krk)
		{
			return z0jrk == p0.z0jrk;
		}
		return false;
	}

	public void z0eek(DocumentComment p0)
	{
		z0cek = p0;
	}

	public string z0eek()
	{
		return z0xek;
	}

	public override string ToString()
	{
		if (z0yek() == null)
		{
			return z0uek();
		}
		return z0yek().ID + ":" + z0uek();
	}

	public int z0rek()
	{
		int num = 0;
		if (z0jrk != null)
		{
			num += z0jrk.GetHashCode();
		}
		if (z0krk != null)
		{
			num += z0krk.GetHashCode();
		}
		num = (int)(num + z0lrk_jiejie20260327142557);
		if (z0xek != null)
		{
			num += z0xek.GetHashCode();
		}
		return (int)(num + z0hrk);
	}

	public void z0eek(ValueValidateResultTypes p0)
	{
		z0lrk_jiejie20260327142557 = p0;
	}

	public ValueValidateResultTypes z0tek()
	{
		return z0lrk_jiejie20260327142557;
	}

	public void z0rek(string p0)
	{
		z0jrk = p0;
	}

	public XTextElement z0yek()
	{
		return z0zek;
	}

	public string z0uek()
	{
		return z0krk;
	}

	public string z0iek()
	{
		return z0jrk;
	}

	public void z0eek(ValueValidateLevel p0)
	{
		z0hrk = p0;
	}

	public DocumentComment z0oek()
	{
		return z0cek;
	}

	internal XTextElementList z0pek()
	{
		if (z0yek() == null)
		{
			return null;
		}
		if (z0tek() == ValueValidateResultTypes.ExcludeKeyword || z0tek() == ValueValidateResultTypes.InvalidateWord)
		{
			new XTextElementList();
			z0ZzZzplh z0ZzZzplh2 = z0yek().z0qek().z0frk();
			int num = z0ZzZzplh2.z0lrk(z0yek());
			if (num >= 0)
			{
				return z0ZzZzplh2.z0oek(num, z0eek().Length);
			}
			return null;
		}
		return new XTextElementList(z0yek());
	}

	public string z0mek()
	{
		if (z0zek == null)
		{
			return null;
		}
		return z0zek.ID;
	}

	public bool z0nek()
	{
		if (z0yek() == null)
		{
			return false;
		}
		XTextDocument xTextDocument = z0yek().z0jr();
		if (z0tek() == ValueValidateResultTypes.ExcludeKeyword)
		{
			return xTextDocument.z0ryk().z0tek(xTextDocument.z0ryk().IndexOf(z0yek()), z0eek().Length);
		}
		z0yek().z0sr();
		return true;
	}

	public void z0tek(string p0)
	{
		z0krk = p0;
	}

	public void z0yek(string p0)
	{
	}

	internal void z0bek()
	{
		z0zek = null;
		z0xek = null;
		z0krk = null;
	}

	public ValueValidateLevel z0vek()
	{
		return z0hrk;
	}

	public void z0eek(XTextElement p0)
	{
		z0zek = p0;
	}
}
