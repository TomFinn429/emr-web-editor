using System;
using System.Diagnostics;
using DCSoft.Writer.Dom;

namespace zzz;

[DebuggerDisplay("Shadow:{EntryElementTypeName}")]
public class z0ZzZzgkh : XTextElement
{
	private new XTextElement z0tek;

	internal new float z0yek;

	public override float Width
	{
		get
		{
			if (z0tek == null)
			{
				return base.Width;
			}
			return z0tek.Width;
		}
		set
		{
			base.Width = value;
		}
	}

	public override float Height
	{
		get
		{
			if (z0tek == null)
			{
				return base.Height;
			}
			return z0tek.Height;
		}
		set
		{
			base.Height = value;
		}
	}

	public string z0eek()
	{
		if (z0tek == null)
		{
			return "null";
		}
		return z0tek.GetType().Name;
	}

	public override float z0bi()
	{
		return Width;
	}

	public override void z0bt(XTextDocument p0)
	{
		base.z0bt(p0);
	}

	public override z0ZzZzrzj z0aek()
	{
		return z0tek.z0aek();
	}

	public override void z0nt(float p0)
	{
		base.z0nt(p0);
	}

	public override void z0mt(float p0)
	{
		z0yek = p0;
	}

	public override float z0pt()
	{
		return z0yek;
	}

	public override string z0ge()
	{
		if (z0tek == null)
		{
			return "Shadow";
		}
		return "Shadow:" + z0tek.z0ge();
	}

	public override void z0ot(float p0)
	{
		base.z0ot(p0);
	}

	public override XTextDocument z0jr()
	{
		if (z0tek == null)
		{
			return base.z0jr();
		}
		return z0tek.z0jr();
	}

	public override float z0it()
	{
		if (z0tek == null)
		{
			return base.z0it();
		}
		return z0tek.z0it();
	}

	public void z0eek(XTextElement p0)
	{
		z0tek = p0;
	}

	public override float z0ut()
	{
		return Width + z0yek;
	}

	internal z0ZzZzgkh(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("entryElement");
		}
		z0tek = p0;
	}

	public XTextElement z0rek()
	{
		return z0tek;
	}

	public override float z0yt()
	{
		if (z0tek == null)
		{
			return base.z0yt();
		}
		return z0tek.z0yt();
	}

	public override XTextContainerElement z0ji()
	{
		if (z0tek == null)
		{
			return base.z0ji();
		}
		return z0tek.z0ji();
	}

	public override void z0nu(XTextContainerElement p0)
	{
		base.z0nu(p0);
	}
}
