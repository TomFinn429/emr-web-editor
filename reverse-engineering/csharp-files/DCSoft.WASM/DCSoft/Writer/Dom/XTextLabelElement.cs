using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using DCSoft.Drawing;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Label:{Text}")]
public sealed class XTextLabelElement : XTextLabelElementBase
{
	public delegate bool z0zhj(XTextLabelElement element);

	private new string z0yek;

	private new LabelTextContactActionMode z0uek;

	private new string z0iek;

	private new DCContentAlignment z0oek = DCContentAlignment.MiddleCenter;

	private new int z0pek = -1;

	private new static z0ZzZzlsh z0mek;

	public new static z0zhj z0nek;

	[DefaultValue(null)]
	[z0ZzZzbjh]
	public string AttributeNameForContactAction
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

	[z0ZzZzbjh]
	[DefaultValue(false)]
	[z0ZzZzyqh]
	public bool AllowUserEditCurrentPageLabelText
	{
		get
		{
			return z0htk();
		}
		set
		{
			z0zek(value);
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(LabelTextContactActionMode.Disable)]
	public LabelTextContactActionMode ContactAction
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	[DefaultValue(null)]
	public string LinkTextForContactAction
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

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(true)]
	public bool AutoSize
	{
		get
		{
			return z0jtk();
		}
		set
		{
			z0irk(value);
		}
	}

	[DefaultValue(true)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public bool Multiline
	{
		get
		{
			return z0cyk();
		}
		set
		{
			z0erk(value);
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	[DefaultValue(DCContentAlignment.MiddleCenter)]
	public DCContentAlignment Alignment
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

	public new bool z0eek()
	{
		if (z0nek == null)
		{
			return false;
		}
		return z0nek(this);
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		if (z0wy())
		{
			if (z0mek == null)
			{
				z0mek = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
				z0mek.z0eek((z0ZzZzksh)4096);
			}
			z0jr();
			List<string> list = new List<string>();
			list.Add(Text);
			foreach (PageLabelText pageText in base.PageTexts)
			{
				list.Add(pageText.Text);
			}
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			z0ZzZzxdh z0ZzZzxdh = z0ZzZzrpk.z0eek(new z0ZzZzxdh(5f, 15f), GraphicsUnit.Pixel, GraphicsUnit.Document);
			foreach (string item in list)
			{
				if (!string.IsNullOrEmpty(item))
				{
					z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzrpk.z0eek(new z0ZzZzxdh(5f, 15f), GraphicsUnit.Pixel, GraphicsUnit.Document);
					z0ZzZzxdh z0ZzZzxdh3 = z0ZzZzxdh.z0yek;
					z0ZzZzxdh2.z0eek(p0.z0eek(item, z0ZzZzrzj, (int)(z0ZzZzrzj.z0jtk ? Width : 10000f), z0ZzZzrzj.z0jtk ? p0.z0yyk.z0pek() : z0mek).z0rek());
					z0ZzZzxdh2.z0rek(Math.Max(z0ZzZzxdh2.z0tek(), p0.z0eek(z0ZzZzrzj)));
					z0ZzZzxdh.z0eek(Math.Max(z0ZzZzxdh.z0rek(), z0ZzZzxdh2.z0rek()));
					z0ZzZzxdh.z0rek(Math.Max(z0ZzZzxdh.z0tek(), z0ZzZzxdh2.z0tek()));
				}
			}
			Width = z0ZzZzxdh.z0rek();
			Height = z0ZzZzxdh.z0tek();
		}
		z0xi(p0: false);
	}

	public override string z0ge()
	{
		return "Label:" + ID;
	}

	public new int z0rek()
	{
		return z0pek;
	}

	public XTextLabelElement()
	{
		Width = 100f;
		Height = 100f;
		AutoSize = true;
		Multiline = true;
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		base.z0rt(p0);
		z0jr()?.z0rik()?.z0mw_jiejie20260327142557(this, p0);
	}

	internal new bool z0tek()
	{
		return Multiline;
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		string text = base.z0eek(p0.z0kuk.z0cmk());
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		bool flag = false;
		if (p0.z0byk == (z0ZzZzcxj)5)
		{
			if (z0ZzZzafh.z0iek(text))
			{
				XTextCharElement.z0zek = true;
				flag = true;
			}
			if (p0.z0nrk)
			{
				return;
			}
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		z0ZzZzlsh z0ZzZzlsh = p0.z0yyk.z0oek().z0eek();
		z0ZzZzbdh z0ZzZzbdh = p0.z0drk();
		z0ZzZzbdh.z0rek(z0ZzZzbdh.z0yek() + p0.z0yyk.z0uek().z0tek());
		z0ZzZzbdh.z0eek(z0ZzZzbdh.z0tek() + 3f);
		z0ZzZzlsh.z0eek((ContentAlignment)Alignment);
		if (z0wy())
		{
			z0ZzZzlsh.z0eek(StringAlignment.Near);
			z0ZzZzlsh.z0rek(StringAlignment.Near);
		}
		else if (!z0tek())
		{
			z0ZzZzlsh.z0eek(z0ZzZzlsh.z0yek() | (z0ZzZzksh)4096);
		}
		if (p0.z0byk == (z0ZzZzcxj)0)
		{
			float num = p0.z0gyk.z0jrk().z0rek();
			float num2 = z0ZzZzrpk.z0eek(1f, GraphicsUnit.Pixel, GraphicsUnit.Document);
			z0ZzZzbdh.z0eek((float)(int)((z0ZzZzbdh.z0tek() + num) / num2) * num2 - num);
		}
		if (p0.z0byk == (z0ZzZzcxj)5)
		{
			z0ZzZzbdh.z0tek(z0ZzZzbdh.z0uek() + 5f);
		}
		if (!z0ZzZzrzj.z0uyk)
		{
			if (text.Length == 1 && p0.z0guk != null)
			{
				p0.z0guk.z0eek(text[0], z0ZzZzrzj.z0btk, z0yek(z0ZzZzrzj.z0bek), z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0pek(), z0ZzZzrzj.z0ytk);
			}
			else
			{
				p0.z0eek(text, z0ZzZzrzj, flag ? z0ZzZzafh.z0yek(z0ZzZzrzj.z0pek) : null, z0yek(z0ZzZzrzj.z0bek), z0ZzZzbdh, z0ZzZzlsh);
			}
		}
		else
		{
			z0ZzZzimk z0ZzZzimk = new z0ZzZzimk(z0ZzZzrzj.z0tyk, z0ZzZzrzj.z0wtk);
			z0ZzZzimk.Bold = z0ZzZzrzj.z0gyk;
			z0ZzZzimk.Italic = z0ZzZzrzj.z0vtk_jiejie20260327142557;
			z0ZzZzimk.Strikeout = z0ZzZzrzj.z0yyk;
			p0.z0gyk.z0eek(text, flag ? z0ZzZzafh.z0yek(z0ZzZzimk) : z0ZzZzimk, z0yek(z0ZzZzrzj.z0bek), z0ZzZzbdh, z0ZzZzlsh);
		}
		if (z0ZzZzrzj.z0uyk)
		{
			p0.z0yyk.z0eek(this, p0, z0yek(z0ZzZzrzj.z0bek), z0ZzZzbdh);
		}
	}

	public override void z0sy(ElementMouseEventArgs p0)
	{
		base.z0sy(p0);
		if (p0.Button == (z0ZzZzqeh)1 && !p0.Handled && AllowUserEditCurrentPageLabelText && !z0yek() && z0cu() != null && z0ZzZzdfh.z0rek().z0rek(z0cu(), this))
		{
			p0.Handled = true;
		}
	}

	public override bool z0wy()
	{
		return AutoSize;
	}

	public new void z0eek(int p0)
	{
		z0pek = p0;
	}

	public override string z0pe()
	{
		return "label";
	}
}
