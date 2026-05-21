using System;
using System.ComponentModel;
using System.Diagnostics;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer.MedicalExpression;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("New medical expression:{Name}")]
[z0ZzZziqh("XNewMedicalExpression")]
public class XTextNewMedicalExpressionElement : XTextObjectElement, z0ZzZznxj
{
	private new bool z0rek;

	private new VerticalAlignStyle z0tek = VerticalAlignStyle.Middle;

	private new ResizeableType z0yek = ResizeableType.WidthAndHeight;

	[NonSerialized]
	private new z0ZzZznjh z0uek;

	private new bool z0iek;

	private new MedicalExpressionValueList z0oek = new MedicalExpressionValueList();

	private new DCMedicalExpressionStyle z0pek = DCMedicalExpressionStyle.FourValues;

	public override string Text
	{
		get
		{
			if (z0oek != null && z0oek.Count > 0)
			{
				return z0oek.ToString();
			}
			return null;
		}
		set
		{
			base.Text = value;
		}
	}

	[z0ZzZzrqh("Value", typeof(z0ZzZzjuk))]
	[DefaultValue(null)]
	public MedicalExpressionValueList Values
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

	[DefaultValue(DCMedicalExpressionStyle.FourValues)]
	public DCMedicalExpressionStyle ExpressionStyle
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
			z0uek = null;
		}
	}

	[DefaultValue(VerticalAlignStyle.Middle)]
	public virtual VerticalAlignStyle VAlign
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

	[z0ZzZzuqh]
	[DefaultValue(false)]
	public override bool Modified
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	public bool AutoSize
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

	public override ResizeableType z0wt()
	{
		if (z0yek())
		{
			return ResizeableType.FixSize;
		}
		return z0yek;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0xi(p0: true);
		z0eek(p0: true);
		base.z0mr(p0);
	}

	public new bool z0eek()
	{
		if (z0oek != null)
		{
			return z0oek.Count > 0;
		}
		return false;
	}

	public override void z0et(ResizeableType p0)
	{
		z0yek = p0;
	}

	public void SetItemValue(string name, string newValue)
	{
		if (z0oek == null)
		{
			z0oek = new MedicalExpressionValueList();
		}
		z0oek.z0eek(name, newValue);
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0eek(p0: true);
		z0uek.z0eek(p0.z0gyk, z0myk_jiejie20260327142557());
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement = (XTextNewMedicalExpressionElement)base.z0lr(p0);
		if (z0oek != null)
		{
			xTextNewMedicalExpressionElement.z0oek = z0oek.Clone();
		}
		z0uek = null;
		return xTextNewMedicalExpressionElement;
	}

	public void z0qy()
	{
		if (z0oek != null)
		{
			z0oek.Clear();
		}
	}

	public new void z0eek(bool p0)
	{
		if (z0uek == null)
		{
			z0uek = new z0ZzZznjh(this);
			z0uek.z0eek(z0kek() - 1);
		}
		if (z0uek.z0eek() != z0kek())
		{
			z0uek.z0eek(z0kek());
			z0uek.z0eek(ExpressionStyle);
			z0xi(p0: true);
		}
		z0uek.z0eek(Values);
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (p0)
		{
			z0uek.z0eek(z0ZzZzrzj.z0pek);
			z0uek.z0eek(z0ZzZzrzj.z0bek);
		}
		if (!p0 || !z0ao())
		{
			return;
		}
		using z0ZzZzjpk p1 = z0ru();
		z0uek.z0eek(z0ZzZzrzj.z0pek);
		z0uek.z0eek(z0ZzZzrzj.z0bek);
		z0ZzZzxdh z0ZzZzxdh = z0uek.z0eek(p1);
		base.z0xi(p0: false);
		if (Width == 0f || AutoSize)
		{
			Width = z0ZzZzxdh.z0rek();
			Height = z0ZzZzxdh.z0tek();
		}
	}

	public string GetItemValue(string name)
	{
		if (z0oek != null)
		{
			return z0oek.z0eek(name);
		}
		return null;
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		if (z0oek != null && z0oek.Count > 0)
		{
			z0oek.z0eek(p0.z0rek_jiejie20260327142557());
		}
	}

	public override VerticalAlignStyle z0ay()
	{
		return VAlign;
	}
}
