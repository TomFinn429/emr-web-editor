using System;
using System.Collections.Generic;
using System.ComponentModel;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

public sealed class XTextTableRowElement : XTextContainerElement
{
	private new int z0srk = 1;

	private new int z0ark = 1;

	private new DCInsertRowDownUseHotKeys z0qrk = DCInsertRowDownUseHotKeys.EnableOnlyForLastRow;

	private new string z0wrk;

	private new float z0erk;

	[NonSerialized]
	internal float z0rrk_jiejie20260327142557 = -1f;

	private new DCBooleanValue z0trk = DCBooleanValue.Inherit;

	[z0ZzZzbjh]
	[DefaultValue(DCInsertRowDownUseHotKeys.EnableOnlyForLastRow)]
	public DCInsertRowDownUseHotKeys AllowInsertRowDownUseHotKey
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
	[z0ZzZzbjh(MemberEffectLevel.DocumentLayout)]
	public bool CanSplitByPageLine
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

	[DefaultValue(true)]
	public bool PrintCellBorder
	{
		get
		{
			return z0syk();
		}
		set
		{
			z0cek(value);
		}
	}

	[DefaultValue(true)]
	public bool ExpendForDataBinding
	{
		get
		{
			return z0wrk();
		}
		set
		{
			z0mrk(value);
		}
	}

	[DefaultValue(TableRowCloneType.Default)]
	[z0ZzZzbjh]
	public TableRowCloneType CloneType
	{
		get
		{
			if (z0utk != null)
			{
				return z0utk.z0iek;
			}
			return TableRowCloneType.Default;
		}
		set
		{
			if (value == TableRowCloneType.Default)
			{
				if (z0utk != null)
				{
					z0utk.z0iek = value;
				}
			}
			else
			{
				z0prk().z0iek = value;
			}
		}
	}

	[z0ZzZzuqh]
	public override bool AcceptTab
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[DefaultValue(0f)]
	[z0ZzZzbjh(MemberEffectLevel.ContentElementLayout)]
	public float SpecifyHeight
	{
		get
		{
			return z0erk;
		}
		set
		{
			z0erk = value;
		}
	}

	[DefaultValue(false)]
	public bool NewPage
	{
		get
		{
			return z0vrk();
		}
		set
		{
			z0ork(value);
		}
	}

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			z0ygj z0ygj = new z0ygj(z0rik, p1: true);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
					if (xTextTableCellElement.z0yi())
					{
						if (z0ygj.z0eek() > 0)
						{
							z0ygj.z0eek(' ');
						}
						xTextTableCellElement.z0bw_jiejie20260327142557(z0ygj);
					}
				}
			}
			return z0ygj.ToString();
		}
		set
		{
		}
	}

	public override ElementType AcceptChildElementTypes2
	{
		get
		{
			return ElementType.TableCell;
		}
		set
		{
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(DCBooleanValue.Inherit)]
	public DCBooleanValue AllowUserToResizeHeight
	{
		get
		{
			return z0trk;
		}
		set
		{
			z0trk = value;
		}
	}

	[DefaultValue(false)]
	[z0ZzZzbjh(MemberEffectLevel.DocumentLayout)]
	public bool HeaderStyle
	{
		get
		{
			return z0yyk();
		}
		set
		{
			z0frk(value);
		}
	}

	[DefaultValue(true)]
	public bool PrintCellBackground
	{
		get
		{
			return z0ryk();
		}
		set
		{
			z0iek(value);
		}
	}

	internal bool z0eek()
	{
		return NewPage;
	}

	public void z0eek(bool p0)
	{
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(z0wrk);
	}

	public XTextElementList z0rek()
	{
		return z0be();
	}

	public override XTextElementList z0be()
	{
		return base.z0be();
	}

	public override string z0ge()
	{
		string text = "Row:" + Convert.ToString(z0drk() + 1);
		if (!string.IsNullOrEmpty(ID))
		{
			text = text + "-" + ID;
		}
		return text;
	}

	private void z0eek(string p0)
	{
		base.FormulaValue = p0;
	}

	public override XTextDocument z0ee_jiejie20260327142557(bool p0)
	{
		if (z0gr() == null)
		{
			return null;
		}
		XTextElementList xTextElementList = new XTextElementList();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (!xTextTableCellElement.z0bek())
				{
					xTextElementList.Add(xTextTableCellElement);
				}
			}
		}
		if (xTextElementList.Count == 0)
		{
			return null;
		}
		XTextTableElement xTextTableElement = (XTextTableElement)z0gr().z0lr(p0: false);
		xTextTableElement.z0mek(new XTextElementList());
		XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0lr(p0: false);
		xTextTableElement.z0pek(new XTextElementList());
		xTextTableElement.z0stk().Add(xTextTableRowElement);
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk.Current;
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)xTextTableCellElement2.z0drk().z0lr(p0: false);
				xTextTableColumnElement.Width = xTextTableCellElement2.Width;
				xTextTableElement.z0srk().Add(xTextTableColumnElement);
				XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextTableCellElement2.z0lr(p0: true);
				xTextTableCellElement3.z0yek(1);
				xTextTableCellElement3.z0tek(1);
				xTextTableRowElement.z0rek().Add(xTextTableCellElement3);
			}
		}
		xTextTableElement.z0bt(z0jr());
		XTextDocument result = xTextTableElement.z0ee_jiejie20260327142557(p0: true);
		xTextTableElement.Dispose();
		return result;
	}

	public override float z0he()
	{
		if (z0gr() == null)
		{
			return z0it();
		}
		return z0gr().z0he() + z0it();
	}

	public override int z0je()
	{
		if (z0jr() == null)
		{
			return -1;
		}
		float p = ((XTextElement)this).z0ltk() + 0.01f;
		return z0jr().z0suk().z0eek(p, 0);
	}

	internal void z0tek()
	{
		z0rrk_jiejie20260327142557 = -1f;
	}

	public XTextTableRowElement()
	{
		CanSplitByPageLine = true;
		ExpendForDataBinding = true;
		PrintCellBackground = true;
		PrintCellBorder = true;
	}

	internal override bool z0ae()
	{
		if (!z0frk() && z0eek())
		{
			return true;
		}
		return base.z0ae();
	}

	public XTextTableRowElement z0eek(TableRowCloneType p0)
	{
		XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0lr(p0: false);
		xTextTableRowElement.z0yek(z0rik, this);
		xTextTableRowElement.HeaderStyle = false;
		xTextTableRowElement.z0te(new XTextElementList());
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
			TableRowCloneType tableRowCloneType = xTextTableCellElement.CloneType;
			if (tableRowCloneType == TableRowCloneType.Default)
			{
				tableRowCloneType = p0;
			}
			XTextTableCellElement xTextTableCellElement2 = xTextTableCellElement.z0rek(tableRowCloneType);
			xTextTableCellElement2.z0yek(z0rik, xTextTableRowElement);
			if (xTextTableCellElement.z0bek())
			{
				XTextTableCellElement xTextTableCellElement3 = xTextTableCellElement.z0hrk();
				xTextTableCellElement2.z0oek(((XTextElement)xTextTableCellElement3).z0pek());
				if (((XTextContainerElement)xTextTableCellElement2).z0xek() == 1 && xTextTableCellElement2.z0dtk() is XTextParagraphFlagElement && ((XTextContainerElement)xTextTableCellElement3).z0zek() is XTextParagraphFlagElement xTextParagraphFlagElement)
				{
					xTextTableCellElement2.z0dtk().z0oek(((XTextElement)xTextParagraphFlagElement).z0pek());
				}
			}
			xTextTableRowElement.z0rek().Add(xTextTableCellElement2);
		}
		return xTextTableRowElement;
	}

	public new bool z0yek()
	{
		return z0rtk();
	}

	public void z0rek(bool p0)
	{
		z0ark(p0);
	}

	public override string ToString()
	{
		return z0ge();
	}

	public override int z0tr()
	{
		if (z0ji() != null)
		{
			XTextElementList xTextElementList = ((XTextTableElement)z0ji()).z0crk();
			if (z0muk >= 0 && z0muk < xTextElementList.Count && xTextElementList[z0muk] == this)
			{
				return z0muk;
			}
			return xTextElementList.IndexOf(this);
		}
		return -1;
	}

	public void z0eek(int p0)
	{
		z0ark = p0;
	}

	public override XTextElement z0ke()
	{
		return ((XTextTableElement)z0ji())?.z0crk().z0pek(this);
	}

	internal void z0tek(bool p0)
	{
		z0jrk(p0);
	}

	public new int z0uek()
	{
		return z0srk;
	}

	public override bool z0de()
	{
		if (z0jr().z0cuk().z0frk() != null)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0jr().z0cuk().z0frk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement item = (XTextTableCellElement)z0bpk.Current;
				if (z0rek().Contains(item))
				{
					return true;
				}
			}
		}
		return base.z0de();
	}

	public override XTextTableElement z0gr()
	{
		return (XTextTableElement)z0ji();
	}

	public void z0eek(float p0, bool p1)
	{
		XTextTableElement xTextTableElement = z0gr();
		xTextTableElement.z0jo();
		float height = xTextTableElement.Height;
		float specifyHeight = SpecifyHeight;
		if (SpecifyHeight < 0f)
		{
			p0 = 0f - p0;
		}
		if (SpecifyHeight == p0)
		{
			return;
		}
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument.z0yyk() != null)
		{
			WriterTableRowHeightChangingEventArgs e = new WriterTableRowHeightChangingEventArgs(xTextDocument.z0yyk(), xTextDocument, this, p0);
			xTextDocument.z0yyk().z0eek(e);
			if (e.Cancel)
			{
				return;
			}
			p0 = e.NewHeight;
		}
		float height2 = Height;
		SpecifyHeight = p0;
		if (p1 && xTextDocument.z0ytk())
		{
			xTextDocument.z0imk().z0eek(this, specifyHeight);
			xTextDocument.z0nuk();
		}
		xTextDocument.Modified = true;
		Modified = true;
		Height = 0f;
		XTextElementList xTextElementList = z0rek();
		for (int num = xTextElementList.Count - 1; num >= 0; num--)
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElementList[num];
			if (xTextTableCellElement.z0bek())
			{
				xTextTableCellElement = xTextTableCellElement.z0hrk();
			}
			xTextTableCellElement.z0nek(p0: true);
			xTextTableCellElement.Width = 0f;
			xTextTableCellElement.Height = 0f;
		}
		xTextTableElement.z0vek(p0: false);
		for (int num2 = xTextElementList.Count - 1; num2 >= 0; num2--)
		{
			XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextElementList[num2];
			if (xTextTableCellElement2.z0bek())
			{
				xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
			}
			xTextTableCellElement2.z0eek(-1f);
		}
		xTextTableElement.z0jo();
		if (xTextTableElement.Height != height)
		{
			xTextTableElement.z0mek(p0: false);
		}
		if (xTextDocument.z0yyk() != null)
		{
			WriterTableRowHeightChangedEventArgs p2 = new WriterTableRowHeightChangedEventArgs(xTextDocument.z0yyk(), xTextDocument, this, height2, Height);
			xTextDocument.z0yyk().z0eek(p2);
		}
	}

	public new bool z0iek()
	{
		if (z0trk == DCBooleanValue.True)
		{
			return true;
		}
		if (z0trk == DCBooleanValue.False)
		{
			return false;
		}
		if (z0uik is XTextTableElement && !((XTextTableElement)z0uik).AllowUserToResizeRows && z0ZzZzxcj.z0eek(93))
		{
			return false;
		}
		return true;
	}

	public new int z0oek()
	{
		return z0drk() + 1;
	}

	internal override IList<XTextElement> z0xe()
	{
		return z0ntk;
	}

	public bool z0eek(float p0, bool p1, bool p2)
	{
		bool flag = false;
		XTextDocument xTextDocument = z0jr();
		bool flag2 = p2 && xTextDocument.z0uik();
		if (float.IsNaN(p0))
		{
			float num = 0f;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					z0ZzZzzlh[] array = ((XTextContentElement)(XTextTableCellElement)z0bpk.Current).z0zek();
					foreach (z0ZzZzzlh z0ZzZzzlh in array)
					{
						num = Math.Max(num, z0ZzZzzlh.z0ytk());
					}
				}
			}
			p0 = num;
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement.SpecifyFixedLineHeight != p0)
				{
					if (flag2)
					{
						xTextDocument.z0imk().z0eek("SpecifyFixedLineHeight", xTextTableCellElement.SpecifyFixedLineHeight, p0, xTextTableCellElement);
					}
					xTextTableCellElement.SpecifyFixedLineHeight = p0;
					flag = true;
				}
				DocumentContentStyle documentContentStyle = xTextTableCellElement.z0aek().z0yek();
				if (p1)
				{
					documentContentStyle.GridLineStyle = DashStyle.Solid;
					documentContentStyle.GridLineType = ContentGridLineType.ExtentToBottom;
				}
				else
				{
					documentContentStyle.GridLineStyle = DashStyle.Solid;
					documentContentStyle.GridLineType = ContentGridLineType.None;
				}
				int styleIndex = xTextDocument.z0gnk().GetStyleIndex(documentContentStyle);
				if (((XTextElement)xTextTableCellElement).z0pek() != styleIndex)
				{
					xTextDocument.z0imk().z0eek(xTextTableCellElement, ((XTextElement)xTextTableCellElement).z0pek(), styleIndex);
					xTextTableCellElement.z0oek(styleIndex);
				}
			}
		}
		if (flag)
		{
			if (flag2)
			{
				xTextDocument.z0imk().z0eek((z0ZzZzbzj)2);
			}
			z0oe();
		}
		return flag;
	}

	public new bool z0pek()
	{
		return HeaderStyle;
	}

	internal new float z0mek()
	{
		if (z0rrk_jiejie20260327142557 < 0f)
		{
			z0rrk_jiejie20260327142557 = 0f;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (!xTextTableCellElement.z0bek() && z0rrk_jiejie20260327142557 < xTextTableCellElement.Height)
				{
					z0rrk_jiejie20260327142557 = xTextTableCellElement.Height;
				}
			}
		}
		return z0rrk_jiejie20260327142557;
	}

	internal new bool z0nek()
	{
		return CanSplitByPageLine;
	}

	public new bool z0bek()
	{
		if (AllowInsertRowDownUseHotKey == DCInsertRowDownUseHotKeys.EnableInAllCases)
		{
			return true;
		}
		return false;
	}

	public new int z0vek()
	{
		if (z0be() == null)
		{
			return 0;
		}
		return z0be().Count;
	}

	public override bool z0pr()
	{
		return true;
	}

	public XTextTableCellElement z0rek(int p0)
	{
		return (XTextTableCellElement)z0rek()[p0];
	}

	internal new float z0cek()
	{
		return z0erk;
	}

	public XTextTableCellElement z0xek_jiejie20260327142557()
	{
		for (int num = z0rek().Count - 1; num >= 0; num--)
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0rek()[num];
			if (!xTextTableCellElement.z0bek())
			{
				return xTextTableCellElement;
			}
		}
		return null;
	}

	public void z0eek(XTextElementList p0)
	{
		z0te(p0);
	}

	internal override void z0kr()
	{
		z0cek(p0: true);
		z0srk(p0: false);
		z0zek(p0: false);
		z0grk(p0: false);
		if (z0ntk != null && z0ntk.Count > 0)
		{
			z0ytk = z0ntk;
			z0lrk(p0: true);
		}
		else
		{
			z0ytk = null;
			z0lrk(p0: false);
		}
	}

	public new XTextTableRowElement z0zek()
	{
		return z0eek(CloneType);
	}

	public override void z0oe()
	{
		z0gr().z0oe();
	}

	public override bool z0le(bool p0)
	{
		XTextTableElement xTextTableElement = z0gr();
		return xTextTableElement?.z0oek(xTextTableElement.z0stk().IndexOf(this), 1, p0, null) ?? false;
	}

	public void z0tek(int p0)
	{
		z0srk = p0;
	}

	public override z0ZzZzpdh z0zw()
	{
		if (!(z0ji() is XTextTableElement xTextTableElement))
		{
			return new z0ZzZzpdh(z0it(), z0yt());
		}
		z0ZzZzpdh z0ZzZzpdh = xTextTableElement.z0zw();
		return new z0ZzZzpdh(z0ZzZzpdh.z0rek() + z0xik, z0ZzZzpdh.z0tek() + z0wik);
	}

	public void z0rek(string p0)
	{
		z0wrk = p0;
	}

	public override bool z0hr()
	{
		XTextTableElement xTextTableElement = z0gr();
		if (xTextTableElement == null)
		{
			return false;
		}
		if (z0rek().Count == 0)
		{
			return false;
		}
		XTextElementList xTextElementList = xTextTableElement.z0pek(xTextTableElement.z0crk().IndexOf(this), 0, xTextTableElement.z0crk().IndexOf(this), z0rek().Count - 1);
		int num = 2147483647;
		int num2 = 0;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (!xTextTableCellElement.z0bek())
				{
					num = Math.Min(num, xTextTableCellElement.z0be().z0grk().z0jrk());
					num2 = Math.Max(num2, xTextTableCellElement.z0be().LastElement.z0jrk());
				}
			}
		}
		if (num < 2147483647 && num >= 0 && num2 >= 0)
		{
			return z0qek().z0tek(num, num2);
		}
		return false;
	}

	public override string z0pe()
	{
		return "row";
	}

	public new string z0lrk()
	{
		return z0wrk;
	}

	public override XTextElement z0xw()
	{
		XTextTableElement xTextTableElement = (XTextTableElement)z0ji();
		if (xTextTableElement != null)
		{
			XTextElementList xTextElementList = xTextTableElement.z0crk();
			int num = z0grk();
			if (num >= 0 && num < xTextElementList.Count && xTextElementList[num] == this)
			{
				if (num + 1 == xTextElementList.Count)
				{
					return null;
				}
				return xTextElementList[num + 1];
			}
			return xTextElementList.z0xek(this);
		}
		return null;
	}

	public override bool z0or(bool p0, bool p1, bool p2)
	{
		return false;
	}

	public override void z0te(XTextElementList p0)
	{
		base.z0te(p0);
	}

	private new string z0krk()
	{
		return base.FormulaValue;
	}

	public new int z0jrk()
	{
		return z0ark;
	}

	public new void z0hrk()
	{
		XTextDocument xTextDocument = z0rik;
		z0ZzZzzej z0qxk = xTextDocument.z0qxk;
		float num = z0cek();
		if (z0qxk != null && z0qxk.z0cek())
		{
			num = 0f;
		}
		if (num < 0f)
		{
			Height = Math.Abs(num);
			return;
		}
		bool flag = false;
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		float z0quk = z0ZzZzrzj.z0quk;
		float num2 = z0ZzZzrzj.z0xrk;
		float num3 = num;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0rek()).z0krk();
		int count = z0rek().Count;
		for (int i = 0; i < count; i++)
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array[i];
			if (!xTextTableCellElement.z0bek() && xTextTableCellElement.RowSpan == 1 && xTextTableCellElement.AutoFixFontSizeMode == ContentAutoFixFontSizeMode.None)
			{
				float num4 = ((XTextContentElement)xTextTableCellElement).z0hrk() + z0quk + num2;
				if (num3 < num4)
				{
					num3 = num4;
				}
				flag = true;
			}
		}
		if (!flag)
		{
			float num5 = xTextDocument.z0dik().z0mek() + z0quk + num2;
			num3 = Math.Max(num, num5);
		}
		if (z0qxk != null && z0qxk.z0cek())
		{
			num3 = z0qxk.z0yek(num3);
		}
		if (Height != num3)
		{
			xTextDocument.z0bek(this, Height);
			Height = num3;
		}
	}

	public new int z0grk()
	{
		return z0muk;
	}

	internal new bool z0frk()
	{
		return z0guk();
	}

	public int z0eek(object p0)
	{
		return 0;
	}

	internal override void z0we()
	{
		z0ytk = null;
		z0cek(p0: false);
	}

	public new int z0drk()
	{
		if (z0gr() == null)
		{
			return 0;
		}
		return z0gr().z0crk().IndexOf(this);
	}

	public override float z0cw()
	{
		if (z0gr() == null)
		{
			return z0yt();
		}
		return z0gr().z0cw() + z0yt();
	}
}
