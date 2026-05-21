using System;
using System.ComponentModel;
using System.Diagnostics;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Column {Index}:{Width}")]
[z0ZzZziqh("XTextTableColumn")]
public sealed class XTextTableColumnElement : XTextElement
{
	[NonSerialized]
	private new bool z0oek;

	private new z0ZzZzevj z0pek;

	[NonSerialized]
	internal new XTextElementList z0mek;

	private new XAttributeList z0nek;

	[NonSerialized]
	private new int z0bek;

	private new bool z0vek = true;

	[DefaultValue(null)]
	public z0ZzZzevj ValueBinding
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzrqh("Attribute", typeof(XAttribute))]
	public override XAttributeList Attributes
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

	[DefaultValue(true)]
	[z0ZzZzbjh(MemberEffectLevel.ContentElementLayout)]
	public override bool Visible
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

	[z0ZzZzuqh]
	public override bool Modified
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

	public XTextElementList z0eek()
	{
		XTextElementList xTextElementList = new XTextElementList();
		XTextTableElement xTextTableElement = z0gr();
		if (xTextTableElement != null)
		{
			int num = xTextTableElement.z0srk().IndexOf(this);
			if (num >= 0)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0stk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(xTextTableRowElement.z0rek()[num]);
				}
			}
		}
		return xTextElementList;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)base.z0lr(p0);
		if (z0nek != null)
		{
			xTextTableColumnElement.z0nek = z0nek.z0eek();
		}
		if (z0pek != null)
		{
			xTextTableColumnElement.z0pek = z0pek.Clone();
		}
		xTextTableColumnElement.z0mek = null;
		return xTextTableColumnElement;
	}

	public int z0rek()
	{
		return ((XTextTableElement)z0ji())?.z0srk().IndexOf(this) ?? (-1);
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(Width);
		p0.z0eek(z0nek);
	}

	private string z0tek()
	{
		return base.FormulaValue;
	}

	private void z0eek(string p0)
	{
		base.FormulaValue = p0;
	}

	public override string z0ge()
	{
		return "Col:" + z0rek();
	}

	public float z0yek_jiejie20260327142557()
	{
		if (z0gr() == null)
		{
			return 0f;
		}
		return z0gr().Height;
	}

	public override bool z0qr(string p0)
	{
		if (z0nek != null)
		{
			return z0nek.z0tek(p0);
		}
		return false;
	}

	public void z0eek(float p0)
	{
	}

	public override bool z0hr()
	{
		XTextTableElement xTextTableElement = z0gr();
		if (xTextTableElement == null || xTextTableElement.z0stk().Count == 0)
		{
			return false;
		}
		if (xTextTableElement.z0srk().IndexOf(this) >= 0)
		{
			XTextDocumentContentElement xTextDocumentContentElement = z0qek();
			if (xTextDocumentContentElement == null)
			{
				return false;
			}
			if (z0jr().z0jrk() != xTextDocumentContentElement)
			{
				xTextDocumentContentElement.z0sr();
			}
			XTextElementList xTextElementList = z0eek();
			xTextDocumentContentElement.z0rek((XTextTableCellElement)xTextElementList.z0krk(), (XTextTableCellElement)xTextElementList.LastElement);
			return true;
		}
		return false;
	}

	public override bool z0ar(XTextDocument p0, bool p1)
	{
		if (z0ji() == null)
		{
			return false;
		}
		return z0ji().z0ar(p0, p1);
	}

	public override string z0zwk(string p0)
	{
		if (z0nek != null)
		{
			return z0nek.z0yek(p0);
		}
		return null;
	}

	public void z0eek(float p0, bool p1, bool p2)
	{
		float minTableColumnWidth = z0iu().MinTableColumnWidth;
		if (p0 < minTableColumnWidth)
		{
			p0 = minTableColumnWidth;
		}
		XTextTableElement xTextTableElement = z0gr();
		XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)xTextTableElement.z0srk().z0xek(this);
		float num = Width;
		if (p2 && xTextTableColumnElement != null)
		{
			num = Width + xTextTableColumnElement.Width;
			if (num - p0 < minTableColumnWidth)
			{
				p0 = num - minTableColumnWidth;
			}
		}
		if (Width != p0)
		{
			float height = xTextTableElement.Height;
			xTextTableElement.z0jo();
			float width = Width;
			Width = p0;
			Modified = true;
			if (p2 && xTextTableColumnElement != null)
			{
				xTextTableColumnElement.Width = num - p0;
			}
			if (p1 && z0jr().z0ytk())
			{
				z0ZzZzwlh p3 = new z0ZzZzwlh(this, width, Width, p2);
				z0jr().z0bek(p3);
				z0jr().z0nuk();
			}
			z0jr().Modified = true;
			xTextTableElement.z0ct();
			xTextTableElement.z0jo();
			if (xTextTableElement.Height != height)
			{
				xTextTableElement.z0mek(p0: true);
			}
			if (z0jr().z0yyk() != null)
			{
				z0jr().z0yyk().z0puk_jiejie20260327142557();
			}
		}
	}

	public override XTextDocument z0ee_jiejie20260327142557(bool p0)
	{
		XTextTableElement xTextTableElement = z0gr();
		if (xTextTableElement == null)
		{
			return null;
		}
		int index = xTextTableElement.z0srk().IndexOf(this);
		XTextElementList xTextElementList = new XTextElementList();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0stk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)((XTextTableRowElement)z0bpk.Current).z0rek()[index];
				if (!xTextTableCellElement.z0bek())
				{
					xTextElementList.Add(xTextTableCellElement);
				}
			}
		}
		if (xTextElementList.Count > 0)
		{
			XTextTableElement xTextTableElement2 = (XTextTableElement)xTextTableElement.z0lr(p0: false);
			xTextTableElement2.z0pek(new XTextElementList());
			xTextTableElement2.z0mek(new XTextElementList());
			xTextTableElement2.z0srk().Add(z0lr(p0: true));
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement obj = (XTextTableCellElement)z0bpk.Current;
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)obj.z0krk().z0lr(p0: false);
					xTextTableRowElement.z0eek(new XTextElementList());
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)obj.z0lr(p0: true);
					xTextTableCellElement2.z0tek(1);
					xTextTableCellElement2.z0yek(1);
					xTextTableRowElement.z0rek().Add(xTextTableCellElement2);
					xTextTableElement2.z0stk().Add(xTextTableRowElement);
				}
			}
			XTextDocument result = xTextTableElement2.z0ee_jiejie20260327142557(p0: true);
			xTextTableElement2.Dispose();
			return result;
		}
		return null;
	}

	internal new bool z0uek()
	{
		return (double)Math.Abs(Width) < 0.01;
	}

	public override void z0sr()
	{
		XTextTableElement xTextTableElement = z0gr();
		if (xTextTableElement == null || xTextTableElement.z0stk().Count == 0)
		{
			return;
		}
		int num = xTextTableElement.z0srk().IndexOf(this);
		if (num < 0)
		{
			return;
		}
		XTextTableCellElement xTextTableCellElement = xTextTableElement.z0nek(0, num, p2: false);
		if (xTextTableCellElement != null)
		{
			if (xTextTableCellElement.z0hrk() != null)
			{
				xTextTableCellElement = xTextTableCellElement.z0hrk();
			}
			xTextTableCellElement.z0sr();
		}
	}

	public override string z0pe()
	{
		return "col";
	}

	public void z0eek(int p0)
	{
		z0bek = p0;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0nek != null)
		{
			z0nek.Clear();
			z0nek = null;
		}
		z0pek = null;
	}

	public new int z0iek()
	{
		return z0bek;
	}

	public override bool z0dr(string p0, string p1)
	{
		if (z0nek == null)
		{
			z0nek = new XAttributeList();
		}
		z0nek.z0eek(p0, p1);
		return true;
	}

	public override void z0fr()
	{
		if (z0uik is XTextTableElement xTextTableElement)
		{
			xTextTableElement.z0srk().z0cek(this);
		}
		z0uik = null;
		z0rik = null;
		z0mek = null;
	}

	public override XTextTableElement z0gr()
	{
		return (XTextTableElement)z0ji();
	}
}
