using System;
using System.ComponentModel;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

public abstract class XTextObjectElement : XTextElement, z0ZzZzixj, z0ZzZzbxj
{
	private new string z0nek;

	private new string z0bek;

	private new ContentReadonlyState z0vek = ContentReadonlyState.Inherit;

	private new static z0ZzZzndh z0cek = z0ZzZzndh.z0cek;

	public new static int z0xek = 20;

	private new ElementVisibility z0zek;

	public new static float z0lrk = 3f;

	private new float z0krk;

	[NonSerialized]
	private new int z0jrk;

	[NonSerialized]
	internal new int z0hrk;

	[NonSerialized]
	private new object z0grk;

	internal new float z0frk;

	private new float z0drk;

	internal new PropertyExpressionInfoList z0srk;

	private new string z0ark;

	internal new XAttributeList z0qrk;

	private new z0ZzZzbuk z0wrk;

	private new string z0erk;

	private new ElementZOrderStyle z0rrk;

	[DefaultValue(null)]
	public string ToolTip
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	[DefaultValue(ContentReadonlyState.Inherit)]
	[z0ZzZzbjh]
	public virtual ContentReadonlyState ContentReadonly
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	[DefaultValue(null)]
	public string ValueExpression
	{
		get
		{
			return z0srk?.GetValue(z0ZzZzkfh.z0ftk);
		}
		set
		{
			if (z0srk == null)
			{
				z0srk = new PropertyExpressionInfoList(this);
			}
			z0srk.SetValue(z0ZzZzkfh.z0ftk, value);
		}
	}

	[DefaultValue(ElementVisibility.Visible)]
	[z0ZzZzbjh]
	public virtual ElementVisibility PrintVisibility
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	[z0ZzZzuqh]
	public z0ZzZzpdh InnerEditorOffset
	{
		get
		{
			return new z0ZzZzpdh(OffsetX, OffsetY);
		}
		set
		{
			if (z0ZzZzpdh.z0rek(new z0ZzZzpdh(OffsetX, OffsetY), value))
			{
				z0jo();
				OffsetX = value.z0rek();
				OffsetY = value.z0tek();
				z0jo();
				z0rrk();
			}
		}
	}

	[DefaultValue(true)]
	[z0ZzZzbjh]
	public bool Enabled
	{
		get
		{
			return z0yrk();
		}
		set
		{
			z0yrk(value);
		}
	}

	[z0ZzZzuqh]
	public override z0ZzZzxdh EditorSize
	{
		get
		{
			return new z0ZzZzxdh(Width, Height);
		}
		set
		{
			float num = value.z0rek();
			float num2 = value.z0tek();
			if (z0jr() != null && num > z0jr().Width)
			{
				num = z0jr().Width;
			}
			double num3 = z0xy();
			if (num3 > 0.1)
			{
				num2 = (int)((double)num / num3);
			}
			if (z0jr() != null && num2 > z0jr().PageSettings.z0qrk())
			{
				num2 = z0jr().PageSettings.z0qrk();
				if (num3 > 0.1)
				{
					num = (int)((double)num2 * num3);
				}
			}
			Width = num;
			Height = num2;
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(null)]
	public string StringTag
	{
		get
		{
			return z0ark;
		}
		set
		{
			z0ark = value;
		}
	}

	[DefaultValue(0f)]
	public float OffsetX
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	[DefaultValue(true)]
	[z0ZzZzbjh]
	public bool Deleteable
	{
		get
		{
			return z0grk();
		}
		set
		{
			z0bek(value);
		}
	}

	[DefaultValue(null)]
	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	public string Name
	{
		get
		{
			return z0erk;
		}
		set
		{
			if (!(z0erk != value))
			{
				return;
			}
			z0erk = value;
			for (XTextContainerElement xTextContainerElement = z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
			{
				if (xTextContainerElement is XTextSectionElement)
				{
					((XTextSectionElement)xTextContainerElement).z0yek().z0rek();
				}
				else if (xTextContainerElement is XTextDocument)
				{
					((XTextDocument)xTextContainerElement).z0mok().z0rek();
					break;
				}
			}
		}
	}

	public override string ID
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

	[DefaultValue(null)]
	public override XAttributeList Attributes
	{
		get
		{
			return z0qrk;
		}
		set
		{
			z0qrk = value;
		}
	}

	[DefaultValue(true)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public override bool Visible
	{
		get
		{
			return z0duk();
		}
		set
		{
			z0zrk(value);
			z0ktk();
		}
	}

	[DefaultValue(0f)]
	public float OffsetY
	{
		get
		{
			return z0drk;
		}
		set
		{
			z0drk = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzrqh("Item", typeof(PropertyExpressionInfo))]
	public PropertyExpressionInfoList PropertyExpressions
	{
		get
		{
			return z0srk;
		}
		set
		{
			z0srk = value;
		}
	}

	[DefaultValue(ElementZOrderStyle.Normal)]
	public ElementZOrderStyle ZOrderStyle
	{
		get
		{
			return z0rrk;
		}
		set
		{
			z0rrk = value;
		}
	}

	public override float z0ut()
	{
		return z0fik + z0frk;
	}

	public bool z0eek()
	{
		return PrintVisibility == ElementVisibility.Visible;
	}

	public override z0ZzZzpdh z0zw()
	{
		return new z0ZzZzpdh(z0zrk(), z0ltk());
	}

	public override bool z0hek(bool p0)
	{
		if (z0rik == null)
		{
			return z0cuk;
		}
		if (z0zek == ElementVisibility.None && p0)
		{
			return false;
		}
		return z0cuk;
	}

	public override string z0zwk(string p0)
	{
		if (z0qrk != null)
		{
			return z0qrk.z0yek(p0);
		}
		return null;
	}

	public void z0eek(object p0)
	{
		z0grk = p0;
	}

	public virtual z0ZzZzapj z0eek(int p0, int p1)
	{
		return z0tek()?.z0eek(p0, p1) ?? ((z0ZzZzapj)(-2));
	}

	public bool z0rek()
	{
		if (z0wt() == ResizeableType.FixSize)
		{
			return false;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement.z0rek(this))
		{
			return xTextDocumentContentElement.z0oek().z0tek() == 1;
		}
		return false;
	}

	public virtual float z0xy()
	{
		return 0f;
	}

	public virtual z0ZzZzqpj z0tek()
	{
		z0ZzZzqpj.z0jrk = z0xek;
		z0ZzZzqpj z0ZzZzqpj = new z0ZzZzqpj(new z0ZzZzndh(0, 0, (int)Width, (int)Height), p1: true);
		z0ZzZzqpj.z0rek(p0: true);
		z0ZzZzqpj.z0eek(DashStyle.Solid);
		if (z0jr().z0xek().z0pm(this, (z0ZzZzbcj)255))
		{
			z0ZzZzqpj.z0eek(z0wt());
		}
		else
		{
			z0ZzZzqpj.z0eek(ResizeableType.FixSize);
			z0ZzZzqpj.z0rek(p0: false);
		}
		z0ZzZzqpj.z0eek(p0: true);
		if (z0ZzZzqpj.z0uek() != ResizeableType.FixSize && z0ji().z0brk())
		{
			if (z0aek().z0jyk >= 0)
			{
				z0ZzZzqpj.z0eek(ResizeableType.FixSize);
			}
			else if (z0ntk() > z0jr().z0syk().z0oek())
			{
				z0ZzZzqpj.z0eek(ResizeableType.FixSize);
			}
		}
		return z0ZzZzqpj;
	}

	public virtual bool z0ui()
	{
		return true;
	}

	public override string z0iy()
	{
		return z0iu().DefaultAdornTextType switch
		{
			InputFieldAdornTextType.Default => null, 
			InputFieldAdornTextType.ToolTip => z0qt()?.z0yek(), 
			InputFieldAdornTextType.ID => ID, 
			InputFieldAdornTextType.Name => Name, 
			_ => null, 
		};
	}

	public new virtual bool z0yek()
	{
		ContentReadonlyState contentReadonly = ContentReadonly;
		if (contentReadonly == ContentReadonlyState.Inherit)
		{
			for (XTextContainerElement xTextContainerElement = z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
			{
				switch (xTextContainerElement.ContentReadonly)
				{
				case ContentReadonlyState.True:
					return true;
				case ContentReadonlyState.False:
					return false;
				}
			}
			return false;
		}
		return contentReadonly == ContentReadonlyState.True;
	}

	public void z0eek(bool p0)
	{
		if (p0)
		{
			PrintVisibility = ElementVisibility.Visible;
		}
		else
		{
			PrintVisibility = ElementVisibility.None;
		}
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0xi(p0: false);
	}

	public virtual z0ZzZzpmk z0by()
	{
		return null;
	}

	public override bool z0gek()
	{
		if (z0qrk != null)
		{
			return z0qrk.Count > 0;
		}
		return false;
	}

	public virtual ResizeableType z0wt()
	{
		if (z0yek())
		{
			return ResizeableType.FixSize;
		}
		return ResizeableType.WidthAndHeight;
	}

	public virtual void z0eek(z0ZzZzbuk p0)
	{
		z0wrk = p0;
	}

	internal override z0ZzZznwh z0ni()
	{
		return z0ZzZzbwh.z0krk;
	}

	public override bool z0dr(string p0, string p1)
	{
		if (z0qrk == null)
		{
			z0qrk = new XAttributeList();
		}
		z0qrk.z0eek(p0, p1);
		return true;
	}

	public override void z0tt(z0ZzZzvxj p0)
	{
		if (z0qek() == null)
		{
			return;
		}
		try
		{
			p0.z0yyk.z0eek(this, p0);
			if (z0mek())
			{
				using z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
				z0ZzZzlsh.z0rek(StringAlignment.Near);
				z0ZzZzlsh.z0eek(StringAlignment.Center);
				p0.z0gyk.DrawString(string.Format(z0ZzZziok.z0wik(), GetType().Name), z0ZzZzimk.z0oek, z0ZzZzyfh.z0uek, p0.z0gtk, z0ZzZzlsh);
			}
			else if (p0.z0duk != null && z0ZzZzbej.z0iek)
			{
				p0.z0duk.z0qhk(z0qt()?.z0yek());
				z0vw(p0);
				p0.z0duk.z0qhk(null);
			}
			else
			{
				z0vw(p0);
			}
			if (p0.z0byk == (z0ZzZzcxj)0 && p0.z0eyk && z0rek() && Enabled)
			{
				z0ZzZzqpj z0ZzZzqpj = z0tek();
				z0ZzZzqpj.z0eek(new z0ZzZzndh((int)z0zrk(), (int)z0ltk(), z0ZzZzqpj.z0yek().z0iek(), z0ZzZzqpj.z0yek().z0oek()));
				z0ZzZzqpj.z0eek(p0.z0gyk);
			}
			z0ZzZzbdh p1 = p0.z0gtk;
			p1.z0tek(p1.z0uek() - 1f);
			p1.z0yek(p1.z0iek() - 1f);
			p0.z0yyk.z0rek(this, p0, p1);
		}
		catch (Exception ex)
		{
			using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
			z0ZzZzlsh2.z0rek(StringAlignment.Near);
			z0ZzZzlsh2.z0eek(StringAlignment.Near);
			p0.z0gyk.z0rek();
			string p2 = ex.ToString();
			z0ZzZzqok.z0rek.z0sh(p2);
			p0.z0gyk.z0eek(p2, new z0ZzZzimk(), Color.Red, p0.z0gtk, z0ZzZzlsh2);
		}
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(z0erk);
		p0.z0eek(z0nek);
		p0.z0eek(z0qrk);
	}

	public new object z0uek()
	{
		return z0grk;
	}

	public new virtual z0ZzZzbuk z0iek()
	{
		return z0wrk;
	}

	public override ElementZOrderStyle z0ci()
	{
		return z0rrk;
	}

	public void z0eek(int p0)
	{
		z0jrk = p0;
	}

	public override PropertyExpressionInfoList z0jek()
	{
		return z0srk;
	}

	public override z0ZzZzonj z0qt()
	{
		z0ZzZzonj z0ZzZzonj = base.z0qt();
		if (z0ZzZzonj == null)
		{
			if (z0iek() != null && !z0iek().IsEmpty)
			{
				z0ZzZzonj = new z0ZzZzonj(this, null);
				if (!string.IsNullOrEmpty(z0iek().Title))
				{
					z0ZzZzonj.z0rek(z0iek().Title);
				}
				else if (z0iek().Reference.StartsWith("#"))
				{
					z0ZzZzonj.z0rek(z0ZzZziok.z0crk());
				}
				else
				{
					z0ZzZzonj.z0rek(z0iek().Reference);
				}
				z0ZzZzonj.z0eek(z0ZzZziok.z0gik());
			}
			if (z0ZzZzonj == null && ToolTip != null && ToolTip.Length > 0)
			{
				z0ZzZzonj = new z0ZzZzonj(this, ToolTip);
			}
		}
		return z0ZzZzonj;
	}

	public new z0ZzZzndh z0oek()
	{
		return z0cek;
	}

	public virtual VerticalAlignStyle z0ay()
	{
		return VerticalAlignStyle.Top;
	}

	public override int z0kek()
	{
		return z0hrk;
	}

	public override float z0bi()
	{
		if (z0rrk != ElementZOrderStyle.Normal)
		{
			return z0lrk;
		}
		return z0fik;
	}

	public virtual void z0et(ResizeableType p0)
	{
	}

	protected XTextObjectElement()
	{
		Deleteable = true;
		Enabled = true;
		Visible = true;
	}

	public void z0eek(z0ZzZzndh p0)
	{
		z0cek = p0;
	}

	public override void z0mt(float p0)
	{
		z0frk = p0;
	}

	public override float z0cw()
	{
		float num = base.z0cw();
		if (z0ci() != ElementZOrderStyle.Normal)
		{
			num += OffsetY;
		}
		return num;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextObjectElement xTextObjectElement = (XTextObjectElement)base.z0lr(p0);
		xTextObjectElement.z0hrk = 0;
		if (z0qrk != null && z0qrk.Count > 0)
		{
			xTextObjectElement.z0qrk = z0qrk.z0eek();
		}
		else
		{
			xTextObjectElement.z0qrk = null;
		}
		if (z0wrk != null)
		{
			xTextObjectElement.z0wrk = z0wrk.z0eek();
		}
		if (z0srk != null)
		{
			xTextObjectElement.z0srk = z0srk.Clone();
		}
		return xTextObjectElement;
	}

	public new int z0pek()
	{
		return z0jrk;
	}

	public override float z0vi()
	{
		if (z0rrk != ElementZOrderStyle.Normal)
		{
			return z0lrk;
		}
		return z0aik;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0bek = null;
		if (z0qrk != null)
		{
			z0qrk.Clear();
			z0qrk.Capacity = 0;
			z0qrk = null;
		}
		z0wrk = null;
		z0erk = null;
		if (z0srk != null)
		{
			z0srk.Clear();
			z0srk.Capacity = 0;
			z0srk = null;
		}
		z0ark = null;
		z0grk = null;
		z0nek = null;
	}

	public virtual void z0cy()
	{
	}

	public override bool z0qr(string p0)
	{
		if (z0qrk != null)
		{
			return z0qrk.z0tek(p0);
		}
		return false;
	}

	public override float z0he()
	{
		float num = base.z0he();
		if (z0ci() != ElementZOrderStyle.Normal)
		{
			num += OffsetX;
		}
		return num;
	}

	public override float z0pt()
	{
		return z0frk;
	}

	protected new virtual bool z0mek()
	{
		return false;
	}
}
