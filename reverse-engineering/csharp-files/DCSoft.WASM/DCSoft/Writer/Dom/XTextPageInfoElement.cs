using System.ComponentModel;
using System.Diagnostics;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XPageInfo")]
[DebuggerDisplay("PageInfo:{ValueType}")]
public sealed class XTextPageInfoElement : XTextObjectElement
{
	public delegate string z0gnk(XTextPageInfoElement element);

	private new static z0ZzZzlsh z0tek;

	private new SpecifyPageIndexInfoList z0yek;

	private new string z0uek;

	private new int z0iek;

	private new bool z0oek = true;

	public new static z0gnk z0pek;

	private new string z0mek;

	private new PageInfoValueType z0nek;

	private new ParagraphListStyle z0bek = ParagraphListStyle.ListNumberStyle;

	private new bool z0vek;

	[DefaultValue(0)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public int PageIndexFix
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(null)]
	public string FormatString
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

	[DefaultValue(ParagraphListStyle.ListNumberStyle)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public ParagraphListStyle DisplayFormat
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[DefaultValue(false)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public bool AutoHeight
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
			z0ktk();
		}
	}

	[DefaultValue(PageInfoValueType.PageIndex)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public PageInfoValueType ValueType
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
			z0ktk();
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(true)]
	public bool ChangePageIndexMidway
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public string SpecifyPageIndexTextList
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	[z0ZzZzrqh("Index", typeof(SpecifyPageIndexInfo))]
	[DefaultValue(null)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public SpecifyPageIndexInfoList SpecifyPageIndexs
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

	public override string z0gy()
	{
		if (z0jr() != null)
		{
			return z0rek();
		}
		return string.Empty;
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek((byte)z0bek);
		p0.z0eek(z0uek);
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		if (z0eek())
		{
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			if (z0ZzZzrzj != null)
			{
				Height = p0.z0eek(z0ZzZzrzj) * 1.1f;
			}
		}
		z0xi(p0: false);
	}

	public override void z0et(ResizeableType p0)
	{
	}

	public override string z0pe()
	{
		return "pi";
	}

	public override ResizeableType z0wt()
	{
		if (z0eek())
		{
			return ResizeableType.Width;
		}
		return ResizeableType.WidthAndHeight;
	}

	public XTextPageInfoElement()
	{
		Width = 100f;
		Height = 100f;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextPageInfoElement xTextPageInfoElement = (XTextPageInfoElement)base.z0lr(p0);
		if (z0yek != null && z0yek.Count > 0)
		{
			xTextPageInfoElement.z0yek = z0yek.z0eek();
		}
		else
		{
			xTextPageInfoElement.z0yek = null;
		}
		return xTextPageInfoElement;
	}

	public new bool z0eek()
	{
		return z0vek;
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		p0.z0eek(z0rek());
	}

	public override string z0xr()
	{
		return "PageIndex:" + z0gy();
	}

	public override void z0sy(ElementMouseEventArgs p0)
	{
		base.z0sy(p0);
		if (p0.Button == (z0ZzZzqeh)1 && !z0yek() && z0ZzZzxcj.z0eek(201))
		{
			object obj = z0jr().z0yyk().z0eek("SpecifyPageIndex", p1: true, this);
			if (obj is bool && (bool)obj)
			{
				p0.Handled = true;
			}
		}
	}

	public override string z0ge()
	{
		if (string.IsNullOrEmpty(FormatString))
		{
			return "PageInfo:" + ValueType;
		}
		return "PageInfo:" + FormatString;
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		if (z0tek == null)
		{
			z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
			z0ZzZzlsh.z0rek(StringAlignment.Center);
			z0ZzZzlsh.z0eek(StringAlignment.Center);
			z0ZzZzlsh.z0eek((z0ZzZzksh)4096);
			z0tek = z0ZzZzlsh;
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		z0ZzZzbdh p1 = z0qyk();
		p1.z0rek(p1.z0yek());
		string p2 = z0rek();
		p0.z0gyk.z0eek(p2, z0ZzZzrzj.z0pek, z0yek(z0ZzZzrzj.z0bek), p1, z0tek);
	}

	public new string z0rek()
	{
		return z0pek(this);
	}
}
