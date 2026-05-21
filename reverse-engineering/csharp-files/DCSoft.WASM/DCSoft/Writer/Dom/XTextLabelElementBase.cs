using System;
using System.ComponentModel;
using DCSoft.WinForms;
using zzz;

namespace DCSoft.Writer.Dom;

public abstract class XTextLabelElementBase : XTextObjectElement
{
	private new z0ZzZzevj z0tek;

	private new bool z0yek;

	private new string z0uek;

	private new PageLabelTextList z0iek;

	[NonSerialized]
	private new object z0oek;

	[DefaultValue(null)]
	public z0ZzZzevj ValueBinding
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public override string Text
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
			z0ktk();
		}
	}

	[z0ZzZzrqh("PageText", typeof(PageLabelText))]
	[DefaultValue(null)]
	public PageLabelTextList PageTexts
	{
		get
		{
			if (z0iek == null)
			{
				z0iek = new PageLabelTextList();
			}
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	[z0ZzZzuqh]
	public override string FormulaValue
	{
		get
		{
			return Text;
		}
		set
		{
			Text = z0uek(value);
			if (z0wy())
			{
				z0oe();
			}
			else
			{
				z0jo();
			}
		}
	}

	[DefaultValue(false)]
	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public bool StrictMatchPageIndex
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public virtual bool z0wy()
	{
		return true;
	}

	public override ResizeableType z0wt()
	{
		if (z0wy())
		{
			return ResizeableType.FixSize;
		}
		return ResizeableType.WidthAndHeight;
	}

	public new void z0eek(bool p0)
	{
		z0uek(p0);
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		p0.z0eek(z0uek);
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		base.z0rt(p0);
		if (ValueBinding != null && ValueBinding.z0yek())
		{
			XTextDocument.z0mpk()?.z0xb(this, new z0ZzZzrlh(null, p1: true));
		}
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(z0uek);
		if (z0iek != null && z0iek.Count > 0)
		{
			p0.z0eek((byte)z0iek.Count);
			{
				foreach (PageLabelText item in z0iek)
				{
					p0.z0eek((byte)item.PageIndex);
					p0.z0eek(item.Text);
				}
				return;
			}
		}
		p0.z0eek(0);
	}

	public new void z0eek(object p0)
	{
		z0oek = p0;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0oek = null;
		if (z0iek != null)
		{
			z0iek.Clear();
			z0iek.Capacity = 0;
			z0iek = null;
		}
		z0uek = null;
		z0tek = null;
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		p0.z0eek(z0uek);
	}

	public override string ToString()
	{
		return Text;
	}

	public void SetPageLabelText(int pageIndex, string text)
	{
		PageTexts.SetPageText(pageIndex, text);
	}

	public new object z0eek()
	{
		return z0oek;
	}

	public new string z0eek(int p0)
	{
		if (z0iek != null && z0iek.Count > 0)
		{
			string text = z0iek.z0eek(p0, StrictMatchPageIndex);
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
		}
		return Text;
	}

	public override void z0et(ResizeableType p0)
	{
	}

	public new bool z0rek()
	{
		return z0trk();
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextLabelElementBase xTextLabelElementBase = (XTextLabelElementBase)base.z0lr(p0);
		if (z0iek != null && z0iek.Count > 0)
		{
			xTextLabelElementBase.z0iek = z0iek.z0eek();
		}
		else
		{
			xTextLabelElementBase.z0iek = null;
		}
		return xTextLabelElementBase;
	}
}
