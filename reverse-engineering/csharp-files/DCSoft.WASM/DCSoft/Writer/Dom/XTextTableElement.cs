using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XTextTable")]
[DebuggerDisplay("表格{ID},{RowsCount}行,{ColumnsCount}列,宽{Width},高{Height}")]
public sealed class XTextTableElement : XTextContainerElement
{
	private class z0pnk : IComparer<XTextElement>
	{
		private readonly z0ZzZzuxj z0eek;

		public int Compare(XTextElement x, XTextElement y)
		{
			return z0eek.z0kh((XTextTableRowElement)x, (XTextTableRowElement)y);
		}

		public z0pnk(z0ZzZzuxj p0)
		{
			z0eek = p0;
		}
	}

	public delegate void z0amk(XTextTableRowElement row, z0ZzZzbdh rowBounds, z0ZzZzvxj args);

	private class z0xjj : IComparer<XTextElement>
	{
		private float z0eek;

		public int Compare(XTextElement x, XTextElement y)
		{
			float num = z0eek - x.z0yt();
			if (num < 0f)
			{
				return 1;
			}
			if (num < ((XTextTableRowElement)x).z0mek())
			{
				return 0;
			}
			return -1;
		}

		public z0xjj(z0ZzZzbdh p0, float p1)
		{
			z0eek = p1 - p0.z0pek();
		}
	}

	private class z0mhj : z0ZzZzhxj
	{
		private new static readonly z0ZzZzrfh z0eek = z0ZzZzpmk.z0eek((object)z0ZzZzgfh.z0yek);

		public override void z0lj(z0ZzZzvxj p0)
		{
			if (p0.z0eyk && p0.z0byk == (z0ZzZzcxj)0)
			{
				base.z0lj(p0);
			}
		}

		public override void z0dj(WriterMouseEventArgs p0)
		{
			if (z0yek().z0eek(p0.X, p0.Y) && p0.Button == (z0ZzZzqeh)1)
			{
				z0ZzZzqbj z0ZzZzqbj = z0nek().z0uyk();
				p0.Handled = true;
				z0nek().z0hr();
				z0nek().z0jr().z0krk(z0nek());
				((z0ZzZzmwh)z0ZzZzqbj).z0jrk();
			}
		}

		public z0mhj(XTextTableElement p0)
		{
			z0eek(z0ZzZzbwh.z0krk);
			z0eek(p0);
			z0eek(p0.z0jr().z0mnk().GetBitmap(DCStdImageKey.DragHandle));
			if (z0tek() == null)
			{
				z0eek(z0eek);
			}
			z0eek(z0ZzZzbwh.z0krk);
			z0ZzZzbdh z0ZzZzbdh = p0.z0qyk();
			z0tek(z0ZzZzrpk.z0eek(z0tek().z0iek(), GraphicsUnit.Pixel, GraphicsUnit.Document));
			z0eek(z0pek());
			z0rek(z0ZzZzbdh.z0oek() - z0pek() - 5f);
			z0yek(z0ZzZzbdh.z0pek());
		}
	}

	[CompilerGenerated]
	private new sealed class z0uyk
	{
		public static readonly z0uyk z0tek = new z0uyk();

		public static Action<XTextTableCellElement> z0yek;

		public static Action<XTextTableCellElement> z0uek;

		internal void z0eek(XTextTableCellElement p0)
		{
			p0.z0gu();
			((XTextElement)p0).z0drk(p0: false);
		}

		internal void z0rek(XTextTableCellElement p0)
		{
			p0.Width = 0f;
			p0.Height = 0f;
		}
	}

	[CompilerGenerated]
	private sealed class z0quk
	{
		public int z0tek;

		public zzz.z0ZzZzkuk<XTextElement> z0yek;

		public bool z0uek;

		public XTextTableElement z0iek;

		public int z0oek;

		public zzz.z0ZzZzkuk<XTextTableCellElement> z0pek;

		public int z0mek;

		internal void z0eek(XTextTableCellElement p0)
		{
			if (p0.z0irk != null)
			{
				return;
			}
			int num = p0.z0pek();
			int num2 = p0.z0xek();
			if (p0.RowSpan > 1 && num + p0.RowSpan > z0mek)
			{
				p0.z0yek(z0tek - num);
			}
			if (p0.ColSpan > 1 && num2 + p0.ColSpan > z0oek)
			{
				p0.z0tek(z0oek - num2);
			}
			int num3 = 0;
			while (true)
			{
				IL_0067:
				int num4 = p0.z0iek();
				if (num4 <= 1 && p0.ColSpan <= 1)
				{
					break;
				}
				z0pek.Clear();
				z0iek.z0rek(num, num2, num4, p0.ColSpan, p4: true, z0pek);
				if (z0pek.Count > 0)
				{
					using zzz.z0ZzZzkuk<XTextTableCellElement>.z0bpk z0bpk = z0pek.z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement current = z0bpk.Current;
						if (current.z0hrk() != null && current.z0hrk() != p0)
						{
							num3++;
							if (num3 > 20)
							{
								break;
							}
							p0.z0tek(current.z0xek() - num2);
							goto IL_0067;
						}
						current.z0rek(p0);
					}
				}
				p0.z0rek((XTextTableCellElement)null);
				break;
			}
		}

		internal void z0rek(XTextTableCellElement p0)
		{
			if (p0.z0irk != null)
			{
				z0yek.z0pek(p0);
				p0.z0rek((XTextTableCellElement)null);
			}
			if (p0.RowSpan > 1 || p0.ColSpan > 1)
			{
				z0uek = true;
			}
		}
	}

	internal new bool z0wtk;

	private new List<XTextTableCellElement> z0etk;

	private new string z0rtk;

	public new static z0amk z0ttk = null;

	private new RenderVisibility z0ytk = RenderVisibility.All;

	public new static float z0utk = -0.5f;

	private new XTextElementList z0itk = new XTextElementList();

	internal new static bool z0otk = true;

	private new int z0ptk = 1;

	[NonSerialized]
	private new XTextElementList z0mtk;

	internal new float z0ntk;

	private new float z0btk;

	private new DCBooleanValue z0vtk = DCBooleanValue.Inherit;

	private new RenderVisibility z0ctk = RenderVisibility.All;

	public new static bool z0xtk = false;

	private new static readonly int z0ztk = Color.White.ToArgb();

	private new TableSubfieldMode z0lyk;

	private DCTableAlignment z0kyk;

	[NonSerialized]
	internal new bool z0jyk = true;

	[DefaultValue(false)]
	public bool CompressOwnerLineSpacing
	{
		get
		{
			return z0dtk();
		}
		set
		{
			z0prk(value);
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(true)]
	public bool AllowUserToResizeRows
	{
		get
		{
			return z0zyk();
		}
		set
		{
			z0wrk(value);
		}
	}

	[DefaultValue(true)]
	[z0ZzZzbjh]
	public bool AllowUserInsertRow
	{
		get
		{
			return z0vtk();
		}
		set
		{
			z0oek(value);
		}
	}

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			z0ygj z0ygj = new z0ygj(z0rik);
			z0bw_jiejie20260327142557(z0ygj);
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
			return ElementType.TableRow | ElementType.TableColumn;
		}
		set
		{
		}
	}

	[DefaultValue(false)]
	public bool PrintBothBorderWhenJumpPrint
	{
		get
		{
			return z0ttk();
		}
		set
		{
			base.z0mek(value);
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

	[DefaultValue(true)]
	[z0ZzZzbjh]
	public bool AllowUserToResizeColumns
	{
		get
		{
			return z0otk();
		}
		set
		{
			z0lrk(value);
		}
	}

	[z0ZzZzuqh]
	public override string FormulaValue
	{
		get
		{
			return Text;
		}
		set
		{
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(true)]
	public bool AllowUserDeleteRow
	{
		get
		{
			return z0guk();
		}
		set
		{
			z0jrk(value);
		}
	}

	public override bool z0hr()
	{
		XTextTableCellElement xTextTableCellElement = null;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0crk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
				if (xTextTableRowElement.z0yi())
				{
					xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.z0dtk();
					if (xTextTableCellElement.z0bek())
					{
						xTextTableCellElement = xTextTableCellElement.z0hrk();
					}
					break;
				}
			}
		}
		XTextTableCellElement xTextTableCellElement2 = null;
		for (int num = z0crk().Count - 1; num >= 0; num--)
		{
			XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)z0crk()[num];
			if (xTextTableRowElement2.z0yi())
			{
				xTextTableCellElement2 = (XTextTableCellElement)((XTextContainerElement)xTextTableRowElement2).z0zek();
				if (xTextTableCellElement2.z0bek())
				{
					xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
				}
				break;
			}
		}
		if (xTextTableCellElement != null && xTextTableCellElement2 != null)
		{
			XTextElement xTextElement = xTextTableCellElement.z0ie();
			XTextElement xTextElement2 = xTextTableCellElement2.z0dek();
			if (xTextElement != null && xTextElement2 != null)
			{
				z0jr().z0btk();
				return z0qek().z0tek(xTextElement.z0jrk(), xTextElement2.z0jrk());
			}
		}
		return false;
	}

	public override XTextDocument z0jr()
	{
		return ((XTextElement)this).z0drk();
	}

	public void z0pek(out XTextElementList p0, out XTextElementList p1)
	{
		p0 = new XTextElementList();
		p1 = new XTextElementList();
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement.z0oek().z0irk() == null)
		{
			return;
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocumentContentElement.z0oek().z0irk().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
			if (xTextTableCellElement.z0gr() == this)
			{
				if (!p0.Contains(xTextTableCellElement.z0krk()))
				{
					p0.Add(xTextTableCellElement.z0krk());
				}
				p1.Add(xTextTableCellElement);
				if (xTextTableCellElement.RowSpan <= 1)
				{
					_ = xTextTableCellElement.ColSpan;
					_ = 1;
				}
			}
		}
	}

	public override XTextElement z0ki(string p0)
	{
		if (z0srk() != null)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
				if (xTextTableColumnElement.ID == p0)
				{
					return xTextTableColumnElement;
				}
			}
		}
		return base.z0ki(p0);
	}

	public override XTextElement z0dek()
	{
		return this;
	}

	public new void z0pek(bool p0)
	{
		z0qrk(p0);
	}

	public new void z0pek()
	{
		z0cek(p0: true);
		z0krk();
		z0mek(p0: false, p1: false);
	}

	public bool z0pek(float p0)
	{
		if (p0 <= 0f)
		{
			throw new ArgumentOutOfRangeException("NewWidth=" + p0);
		}
		float num = 0f;
		int num2 = 0;
		List<XTextTableColumnElement> list = new List<XTextTableColumnElement>();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
				if (xTextTableColumnElement.z0yi())
				{
					num += xTextTableColumnElement.Width;
					num2++;
					if (xTextTableColumnElement.z0uek())
					{
						list.Add(xTextTableColumnElement);
					}
				}
			}
		}
		bool result = false;
		if (list.Count == z0srk().Count)
		{
			foreach (XTextTableColumnElement item in list)
			{
				item.Width = p0 / (float)list.Count;
			}
			result = true;
			list.Clear();
		}
		else if (num != p0 && num > 0f)
		{
			if (list.Count > 0 && p0 > num)
			{
				float width = (p0 - num) / (float)list.Count;
				foreach (XTextTableColumnElement item2 in list)
				{
					item2.Width = width;
					result = true;
				}
				list.Clear();
			}
			else
			{
				float num3 = p0 / num;
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableColumnElement xTextTableColumnElement2 = (XTextTableColumnElement)z0bpk.Current;
					if (xTextTableColumnElement2.z0yi())
					{
						xTextTableColumnElement2.Width *= num3;
						result = true;
					}
				}
			}
		}
		if (list.Count > 0)
		{
			float minTableColumnWidth = z0iu().MinTableColumnWidth;
			using List<XTextTableColumnElement>.Enumerator enumerator = list.GetEnumerator();
			if (enumerator.MoveNext())
			{
				XTextTableColumnElement current = enumerator.Current;
				if (z0jr() == null)
				{
					current.Width = 50f;
				}
				else
				{
					current.Width = minTableColumnWidth;
				}
				return true;
			}
		}
		return result;
	}

	public void z0mek(float p0)
	{
		z0btk = p0;
	}

	public new bool z0mek()
	{
		return z0lyk();
	}

	internal override void z0kr()
	{
		base.z0cek(p0: true);
		z0srk(p0: false);
		z0zek(p0: false);
		z0grk(p0: false);
		if (base.z0ntk != null && base.z0ntk.Count > 0)
		{
			base.z0ytk = base.z0ntk;
			z0lrk(p0: true);
		}
		else
		{
			base.z0ytk = null;
			z0lrk(p0: false);
		}
	}

	public override void z0bt(XTextDocument p0)
	{
		base.z0bt(p0);
		if (z0itk != null && z0itk.Count > 0)
		{
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0itk).z0krk();
			for (int num = z0itk.Count - 1; num >= 0; num--)
			{
				array[num].z0bt(p0);
			}
		}
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextTableElement xTextTableElement = (XTextTableElement)base.z0lr(p0);
		xTextTableElement.z0mtk = null;
		if (z0srk() != null)
		{
			xTextTableElement.z0itk = new XTextElementList();
			z0itk.z0oek(xTextTableElement.z0itk, xTextTableElement, z0jr());
		}
		xTextTableElement.z0uek(delegate(XTextTableCellElement xTextTableCellElement)
		{
			xTextTableCellElement.Width = 0f;
			xTextTableCellElement.Height = 0f;
		});
		return xTextTableElement;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0jyk = true;
		int count = z0be().Count;
		for (int i = 0; i < count; i++)
		{
			base.z0ntk[i].z0be().z0oek(p0);
		}
	}

	public override string ToString()
	{
		return "表格" + ID;
	}

	public new RenderVisibility z0nek()
	{
		return z0ctk;
	}

	internal void z0pek(bool p0, bool p1)
	{
		XTextDocument p2 = z0rik;
		int num = 0;
		if (z0itk != null)
		{
			num = z0itk.Count;
			int count = z0stk().Count;
			foreach (XTextTableColumnElement item in z0itk.z0xrk())
			{
				item.z0muk = count++;
				item.z0yek(p2, this);
				item.z0mek = null;
			}
		}
		if (z0mtk != null && z0mtk != z0stk())
		{
			z0mtk.Clear();
			z0mtk = null;
		}
		int count2 = z0stk().Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0stk()).z0krk();
		XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)z0itk).z0krk();
		for (int i = 0; i < count2; i++)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)array[i];
			xTextTableRowElement.z0muk = i;
			xTextTableRowElement.z0yek(p2, this);
			xTextTableRowElement.z0tek();
			int num2 = 0;
			XTextElement[] array3 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement.z0rek()).z0krk();
			int count3 = xTextTableRowElement.z0rek().Count;
			for (int j = 0; j < count3; j++)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array3[j];
				xTextTableCellElement.z0nrk = i;
				xTextTableCellElement.z0muk = j;
				if (p0)
				{
					xTextTableCellElement.z0irk = null;
				}
				xTextTableCellElement.z0yek(p2, xTextTableRowElement);
				if (p1)
				{
					xTextTableCellElement.z0li();
				}
				if (num2 < num)
				{
					xTextTableCellElement.z0rek((XTextTableColumnElement)array2[num2]);
				}
				num2++;
			}
		}
		if (p0)
		{
			z0krk();
		}
	}

	public void z0pek(DCBooleanValue p0)
	{
		z0vtk = p0;
	}

	public new int z0bek()
	{
		if (z0be() == null)
		{
			return 0;
		}
		return z0be().Count;
	}

	public new XTextTableColumnElement z0vek()
	{
		XTextTableColumnElement xTextTableColumnElement = new XTextTableColumnElement();
		xTextTableColumnElement.z0yek(z0rik, this);
		return xTextTableColumnElement;
	}

	internal new void z0mek(bool p0)
	{
		if (z0xu())
		{
			return;
		}
		z0ZzZzzlh z0ZzZzzlh = z0ptk();
		if (z0ZzZzzlh == null)
		{
			return;
		}
		float num = z0ZzZzzlh.z0ytk();
		z0ZzZzzlh.z0jtk();
		z0ZzZzzlh.z0erk();
		if (z0ZzZzzlh.z0ytk() != num || p0)
		{
			for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				if (xTextElement is XTextTableCellElement)
				{
					XTextTableCellElement obj = (XTextTableCellElement)xTextElement;
					XTextTableElement xTextTableElement = obj.z0gr();
					float height = obj.Height;
					obj.Height = 0f;
					obj.z0xi(p0: true);
					xTextTableElement.z0ct();
					if (obj.Height != height)
					{
						xTextTableElement.z0ptk().z0jtk();
						xTextTableElement.z0ptk().z0tek(p0: true);
					}
				}
				else if (xTextElement is XTextSectionElement)
				{
					XTextSectionElement xTextSectionElement = (XTextSectionElement)xTextElement;
					float height2 = xTextSectionElement.Height;
					xTextSectionElement.z0eek(VerticalAlignStyle.Top, p1: true, p2: false);
					xTextSectionElement.z0ly();
					if (xTextSectionElement.Height != height2)
					{
						xTextSectionElement.z0ptk().z0jtk();
						xTextSectionElement.z0ptk().z0tek(p0: true);
					}
				}
			}
			XTextDocumentContentElement xTextDocumentContentElement = z0qek();
			xTextDocumentContentElement.z0eek(xTextDocumentContentElement.z0cr(), p1: false, p2: true);
			xTextDocumentContentElement.z0ly();
			z0jr().z0krk();
			if (z0jr().z0yyk() != null)
			{
				z0jr().z0yyk().z0fpk();
				z0jr().z0yyk().z0ypk().z0hz();
			}
		}
		if (z0jr().z0yyk() != null)
		{
			z0jr().z0yyk().z0puk_jiejie20260327142557();
		}
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		p0.z0iek();
		foreach (XTextTableRowElement item in z0crk().z0xrk())
		{
			if (!p0.z0yek() && !item.z0yi())
			{
				continue;
			}
			p0.z0iek();
			foreach (XTextTableCellElement item2 in item.z0rek().z0xrk())
			{
				if (!item2.z0bek())
				{
					int num = p0.z0eek();
					item2.z0fy(p0);
					if (num == p0.z0eek())
					{
						p0.z0eek(' ');
					}
					p0.z0eek(' ');
				}
			}
		}
	}

	public new bool z0cek()
	{
		return AllowUserToResizeColumns;
	}

	internal void z0pek(z0ZzZzszj p0)
	{
		float num = ((XTextElement)this).z0ltk();
		XTextTableRowElement xTextTableRowElement = null;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0crk()).z0krk();
		int count = z0crk().Count;
		for (int i = 0; i < count; i++)
		{
			XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)array[i];
			if (!(p0.z0grk >= num + xTextTableRowElement2.z0yt()))
			{
				break;
			}
			if (xTextTableRowElement2.z0eek() && !xTextTableRowElement2.z0frk() && !xTextTableRowElement2.z0pek())
			{
				if (!(num + xTextTableRowElement2.z0yt() < p0.z0ork + 100f))
				{
					xTextTableRowElement2.z0tek(p0: true);
					p0.z0rek((XTextElement)xTextTableRowElement2);
					p0.z0rek(((XTextElement)xTextTableRowElement2).z0ltk());
					p0.z0vek = true;
					if (i > 0)
					{
						z0mek(p0);
					}
					return;
				}
				continue;
			}
			if (xTextTableRowElement2.z0ae())
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement2.z0rek().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
					if (xTextTableCellElement.z0yi() && xTextTableCellElement.z0ae())
					{
						xTextTableCellElement.z0eek(p0);
						z0mek(p0);
						return;
					}
				}
			}
			xTextTableRowElement = xTextTableRowElement2;
			if (!xTextTableRowElement2.z0nek() && !p0.z0yrk && p0.z0oek() < num + xTextTableRowElement2.z0yt() + xTextTableRowElement2.z0mek())
			{
				break;
			}
		}
		if (xTextTableRowElement == null || p0.z0oek() >= num + Height - 1f)
		{
			return;
		}
		float num2 = num + xTextTableRowElement.z0yt();
		if (!xTextTableRowElement.z0nek() && !p0.z0yrk)
		{
			if ((double)((num2 - p0.z0ork) / p0.z0wrk) > 0.2)
			{
				p0.z0rek(num2);
			}
			if (z0jr().z0wpk() != null)
			{
				z0ZzZzzej z0ZzZzzej = z0jr().z0wpk();
				if (z0ZzZzzej.z0zek() > 0f)
				{
					p0.z0rek((float)Math.Round(p0.z0oek() / z0ZzZzzej.z0zek()) * z0ZzZzzej.z0zek());
				}
			}
			p0.z0rek(xTextTableRowElement);
			p0.z0tek().Add(xTextTableRowElement);
			p0.z0rek((XTextElement)xTextTableRowElement);
			z0mek(p0);
			return;
		}
		float num3 = p0.z0oek() - num2;
		float num4 = z0jr().z0xek(10f);
		if (p0.z0rek(this) != null)
		{
			num4 *= 2f;
		}
		if (num3 > num4)
		{
			zzz.z0ZzZzkuk<XTextElement> z0ZzZzkuk = new zzz.z0ZzZzkuk<XTextElement>(xTextTableRowElement.z0rek().Count);
			foreach (XTextTableCellElement item in xTextTableRowElement.z0rek().z0xrk())
			{
				if (item.z0yi())
				{
					if (((XTextContentElement)item).z0wrk() && !(((XTextContentElement)item).z0zek()[0].z0zrk() + num2 > p0.z0oek()))
					{
						z0ZzZzkuk.z0mek(item);
					}
				}
				else if (item.z0bek() && !z0ZzZzkuk.Contains(item.z0hrk()) && ((XTextContentElement)item.z0hrk()).z0wrk())
				{
					z0ZzZzkuk.z0mek(item.z0hrk());
				}
			}
			if (z0ZzZzkuk.Count == 0)
			{
				return;
			}
			XTextTableCellElement xTextTableCellElement3 = null;
			float num5 = 0f / 0f;
			foreach (XTextTableCellElement item2 in z0ZzZzkuk.z0xrk())
			{
				if (((XTextContentElement)item2).z0wrk())
				{
					z0ZzZzzlh z0ZzZzzlh = ((XTextContentElement)item2).z0zek().z0uek();
					float num6 = 0f;
					if (!item2.z0urk())
					{
						num6 = item2.z0aek().z0quk;
					}
					float num7 = Math.Max(0f, num6 + item2.z0si() - z0ZzZzzlh.z0ark());
					if (xTextTableCellElement3 == null || num7 < num5)
					{
						xTextTableCellElement3 = item2;
						num5 = num7;
					}
				}
			}
			p0.z0ark = false;
			xTextTableCellElement3.z0eek(p0);
			if (p0.z0ark)
			{
				if (!p0.z0yrk)
				{
					foreach (XTextTableCellElement item3 in z0ZzZzkuk.z0xrk())
					{
						if (item3 != xTextTableCellElement3 && ((XTextContentElement)item3).z0wrk() && item3.z0krk() == xTextTableRowElement)
						{
							float num8 = num2 + ((XTextContentElement)item3).z0zek()[0].z0zrk();
							float num9 = num2 + ((XTextContentElement)item3).z0zek().z0uek().z0ark();
							if (num8 <= p0.z0oek() && p0.z0oek() <= num9)
							{
								item3.z0eek(p0);
								break;
							}
						}
					}
				}
				z0mek(p0);
				p0.z0rek(xTextTableRowElement);
				return;
			}
			bool flag = false;
			if (p0.z0cek)
			{
				if (z0ZzZzkuk.Count == 1 && ((XTextContentElement)xTextTableCellElement3).z0zek().Length > 1)
				{
					z0ZzZzzlh z0ZzZzzlh2 = ((XTextContentElement)xTextTableCellElement3).z0zek().z0uek();
					float num10 = num2 + z0ZzZzzlh2.z0zrk();
					if (p0.z0oek() < num10 + 200f)
					{
						p0.z0rek(num10);
					}
					p0.z0rek((XTextElement)xTextTableRowElement);
					flag = true;
				}
				if (!flag && !p0.z0yrk && (double)xTextTableRowElement.Height < (double)p0.z0wrk * 0.08)
				{
					p0.z0rek(num2);
					p0.z0rek((XTextElement)xTextTableRowElement);
					flag = true;
				}
			}
			if (!flag && !p0.z0yrk)
			{
				XTextTableCellElement xTextTableCellElement6 = null;
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzkuk.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement7 = (XTextTableCellElement)z0bpk.Current;
						if (xTextTableCellElement7 != xTextTableCellElement3 && xTextTableCellElement7.z0ji() == xTextTableRowElement && ((XTextContentElement)xTextTableCellElement7).z0zek()[0].z0zrk() + num2 < p0.z0oek())
						{
							if (xTextTableCellElement6 != null)
							{
								xTextTableCellElement6 = null;
								break;
							}
							xTextTableCellElement6 = xTextTableCellElement7;
						}
					}
				}
				if (xTextTableCellElement6 != null)
				{
					z0ZzZzszj z0ZzZzszj = p0.z0yek();
					p0.z0rek((XTextElement)null);
					p0.z0rek(new XTextElementList());
					xTextTableCellElement6.z0eek(z0ZzZzszj);
					if (z0ZzZzszj.z0oek() < p0.z0oek() && z0ZzZzszj.z0oek() > p0.z0oek() - 300f)
					{
						if (p0.z0rrk)
						{
							if (z0ZzZzszj.z0oek() < p0.z0oek() - 10f)
							{
								p0.z0rek(z0ZzZzszj.z0oek());
							}
							flag = true;
						}
						if (!flag)
						{
							if (((XTextContentElement)xTextTableCellElement6).z0zek()[0].z0zrk() + num2 >= z0ZzZzszj.z0oek() - 1f)
							{
								if (xTextTableCellElement6 != xTextTableCellElement3 && xTextTableCellElement3 != null)
								{
									xTextTableCellElement3.z0eek(z0ZzZzszj);
									p0.z0rek(z0ZzZzszj.z0oek());
									p0.z0rek((XTextElement)xTextTableCellElement3);
								}
							}
							else
							{
								float num11 = p0.z0oek() - z0ZzZzszj.z0oek();
								z0ZzZzzlh z0ZzZzzlh3 = ((XTextContentElement)xTextTableCellElement6).z0zek().z0uek();
								if (xTextTableCellElement6.z0si() - z0ZzZzzlh3.z0ark() > num11)
								{
									z0ZzZzzlh[] array2 = ((XTextContentElement)xTextTableCellElement6).z0zek();
									for (int j = 0; j < array2.Length; j++)
									{
										array2[j].z0eek(0f, num11);
									}
								}
								else
								{
									p0.z0rek(z0ZzZzszj.z0oek());
									p0.z0rek((XTextElement)xTextTableCellElement6);
								}
							}
							flag = true;
						}
					}
				}
			}
			if (!flag && !p0.z0yrk && p0.z0cek)
			{
				float num12 = num2 + xTextTableRowElement.Height - p0.z0oek();
				if (num12 >= 2f && num12 < 20f)
				{
					p0.z0rek(((XTextContentElement)xTextTableCellElement3).z0zek().z0uek().z0lrk() - 2f);
					xTextTableCellElement3.z0eek(p0);
				}
			}
			if (!flag && p0.z0pek() == null)
			{
				p0.z0rek((XTextElement)xTextTableRowElement);
			}
			z0mek(p0);
			p0.z0rek(xTextTableRowElement);
			return;
		}
		for (int k = 0; k < xTextTableRowElement.z0rek().Count; k++)
		{
			XTextTableCellElement xTextTableCellElement8 = (XTextTableCellElement)xTextTableRowElement.z0rek()[k];
			if (xTextTableCellElement8.z0bek())
			{
				xTextTableCellElement8 = xTextTableCellElement8.z0hrk();
			}
			if (xTextTableCellElement8.z0krk() != xTextTableRowElement && !p0.z0tek().Contains(xTextTableCellElement8))
			{
				p0.z0tek().Add(xTextTableCellElement8);
			}
		}
		if (p0.z0oek() > num + xTextTableRowElement.z0yt() + xTextTableRowElement.Height)
		{
			p0.z0rek(num + xTextTableRowElement.z0yt() + xTextTableRowElement.Height);
			p0.z0rek(z0crk().z0xek(xTextTableRowElement));
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement9 = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement9.z0bek())
				{
					XTextTableCellElement xTextTableCellElement10 = xTextTableCellElement9.z0hrk();
					if (xTextTableCellElement10.z0yi() && xTextTableCellElement9.z0pek() + xTextTableCellElement9.RowSpan < xTextTableCellElement10.z0pek() + xTextTableCellElement10.RowSpan)
					{
						p0.z0rek(xTextTableCellElement10);
					}
				}
			}
		}
		else
		{
			p0.z0rek(num + xTextTableRowElement.z0yt());
			p0.z0rek((XTextElement)xTextTableRowElement);
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement11 = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement11.z0bek())
				{
					XTextTableCellElement xTextTableCellElement12 = xTextTableCellElement11.z0hrk();
					if (xTextTableCellElement12.z0yi() && xTextTableCellElement11.z0pek() > xTextTableCellElement12.z0pek())
					{
						p0.z0rek(xTextTableCellElement12);
					}
				}
			}
		}
		if (p0.z0pek() == null)
		{
			p0.z0rek((XTextElement)xTextTableRowElement);
		}
		z0mek(p0);
	}

	internal new void z0xek()
	{
		XTextElementList xTextElementList = z0stk();
		int count = xTextElementList.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		for (int i = 0; i < count; i++)
		{
			XTextTableRowElement obj = (XTextTableRowElement)array[i];
			obj.z0muk = i;
			XTextElementList xTextElementList2 = obj.z0rek();
			int count2 = xTextElementList2.Count;
			XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0krk();
			for (int j = 0; j < count2; j++)
			{
				XTextTableCellElement obj2 = (XTextTableCellElement)array2[j];
				obj2.z0nrk = i;
				obj2.z0muk = j;
			}
		}
	}

	public new XTextElementList z0zek()
	{
		XTextElementList xTextElementList = new XTextElementList(z0brk() * z0drk());
		XTextElementList xTextElementList2 = z0crk();
		int count = xTextElementList2.Count;
		for (int i = 0; i < count; i++)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList2[i];
			if (xTextTableRowElement.z0ntk != null)
			{
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement.z0ntk);
			}
		}
		return xTextElementList;
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		foreach (XTextTableColumnElement item in z0srk().z0xrk())
		{
			item.z0iek(this);
		}
		if (!z0jr().z0snk())
		{
			z0pek(p0: true, p1: false);
			if (z0cek(p0: false) > 0)
			{
				z0krk();
			}
		}
		if (!z0xtk)
		{
			return;
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0stk()).z0krk();
		int count = z0stk().Count;
		for (int i = 0; i < count; i++)
		{
			XTextTableRowElement obj = (XTextTableRowElement)array[i];
			XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)obj.z0rek()).z0krk();
			int count2 = obj.z0rek().Count;
			for (int j = 0; j < count2; j++)
			{
				((XTextTableCellElement)array2[j]).z0rt(p0);
			}
		}
	}

	public XTextTableElement(int rowsCount, int columnsCount)
	{
		AllowUserDeleteRow = true;
		AllowUserInsertRow = true;
		AllowUserToResizeColumns = true;
		AllowUserToResizeRows = true;
		z0bek(p0: true);
		z0pek(rowsCount, columnsCount);
	}

	public override void z0ct()
	{
		z0vek(p0: true);
	}

	public new bool z0nek(bool p0)
	{
		if ((z0hrk() == TableSubfieldMode.LeftRightAndUpDown || z0hrk() == TableSubfieldMode.UpDownAndLeftRight) && z0prk() > 1)
		{
			bool result = z0pek(z0hrk(), z0prk(), p0);
			z0pek(TableSubfieldMode.None);
			z0mek(1);
			return result;
		}
		return false;
	}

	public override void z0ze(z0kgj p0)
	{
		XTextDocument xTextDocument = ((XTextElement)this).z0drk();
		bool flag = p0.z0mek;
		z0cuk = z0ur(p0);
		if (z0itk == null)
		{
			z0itk = new XTextElementList();
		}
		if (z0cuk)
		{
			int count = z0itk.Count;
			bool[] array = new bool[z0itk.Count];
			for (int i = 0; i < count; i++)
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0itk[i];
				xTextTableColumnElement.z0qi(xTextTableColumnElement.Visible);
				array[i] = xTextTableColumnElement.Visible;
			}
			{
				foreach (XTextTableRowElement item in z0stk().z0xrk())
				{
					if (xTextDocument == null)
					{
						item.z0cuk = item.Visible;
					}
					else
					{
						item.z0cuk = item.z0ur(p0);
					}
					if (item.z0cuk)
					{
						XTextElementList xTextElementList = item.z0rek();
						int count2 = xTextElementList.Count;
						for (int j = 0; j < count2; j++)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElementList[j];
							xTextTableCellElement.z0cuk = true;
							if (xTextTableCellElement.z0bek())
							{
								xTextTableCellElement.z0cuk = false;
							}
							else if (j < count && !array[j])
							{
								xTextTableCellElement.z0cuk = false;
							}
							if (flag)
							{
								xTextTableCellElement.z0ze(p0);
							}
						}
					}
					else
					{
						item.z0ze(p0);
					}
				}
				return;
			}
		}
		foreach (XTextTableColumnElement item2 in z0srk().z0xrk())
		{
			item2.z0qi(p0: false);
		}
		if (flag)
		{
			base.z0urk();
		}
		else
		{
			base.z0ze(p0);
		}
	}

	public new RenderVisibility z0lrk()
	{
		return z0ytk;
	}

	public XTextTableRowElement z0pek(int p0)
	{
		return (XTextTableRowElement)z0stk()[p0];
	}

	public override void z0mt(float p0)
	{
		z0ntk = p0;
	}

	public bool z0pek(int p0, int p1, bool p2)
	{
		if (p0 < 0 || p0 >= z0stk().Count)
		{
			throw new ArgumentOutOfRangeException("startRowIndexBase0=" + p0);
		}
		if (p1 <= 0)
		{
			return false;
		}
		List<XTextElement> list = new List<XTextElement>();
		for (int i = 0; i < p1; i++)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0stk()[i + p0];
			if (!xTextTableRowElement.z0yi())
			{
				continue;
			}
			List<XTextTableRowElement> list2 = new List<XTextTableRowElement>();
			int num = 0;
			bool flag = true;
			foreach (XTextTableCellElement item in xTextTableRowElement.z0rek().z0xrk())
			{
				if (item.z0yi())
				{
					if (item.RowSpan > 1)
					{
						flag = false;
						break;
					}
					num = Math.Max(((XTextContentElement)item).z0zek().Length, num);
				}
				else if (item.z0hrk() != null && item.z0hrk().z0ji() != xTextTableRowElement)
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			if (num <= 1)
			{
				list.Add(xTextTableRowElement);
				continue;
			}
			float specifyHeight = xTextTableRowElement.z0cek() / (float)num;
			for (int j = 0; j < num; j++)
			{
				XTextTableRowElement xTextTableRowElement2 = xTextTableRowElement.z0eek(TableRowCloneType.Default);
				for (int k = 0; k < xTextTableRowElement.z0rek().Count; k++)
				{
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement.z0rek()[k];
					if (!xTextTableCellElement2.z0yi() || j >= ((XTextContentElement)xTextTableCellElement2).z0zek().Length)
					{
						continue;
					}
					XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextTableRowElement2.z0rek()[k];
					xTextTableCellElement3.z0bt(z0jr());
					xTextTableCellElement3.GridLine = null;
					((XTextElement)xTextTableCellElement3).z0xrk().GridLineType = ContentGridLineType.None;
					xTextTableCellElement3.SpecifyFixedLineHeight = 0f;
					xTextTableCellElement3.z0be().Clear();
					if (j >= ((XTextContentElement)xTextTableCellElement2).z0zek().Length)
					{
						continue;
					}
					z0ZzZzzlh z0ZzZzzlh = ((XTextContentElement)xTextTableCellElement2).z0zek()[j];
					if (((XTextContentElement)xTextTableCellElement2).z0zek().Length == 1)
					{
						((zzz.z0ZzZzkuk<XTextElement>)xTextTableCellElement3.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextTableCellElement2.z0be());
						continue;
					}
					XTextElement xTextElement = ((XTextElementList)z0ZzZzzlh).z0krk();
					while (xTextElement != null && xTextElement.z0ji() != xTextTableCellElement2)
					{
						xTextElement = xTextElement.z0ji();
					}
					XTextElement xTextElement2 = z0ZzZzzlh.LastElement;
					while (xTextElement2 != null && xTextElement2.z0ji() != xTextTableCellElement2)
					{
						xTextElement2 = xTextElement2.z0ji();
					}
					if (xTextElement != null && xTextElement2 != null)
					{
						int num2 = xTextTableCellElement2.z0be().IndexOf(xTextElement);
						int num3 = xTextTableCellElement2.z0be().IndexOf(xTextElement2);
						if (num2 >= 0 && num3 >= num2)
						{
							xTextTableCellElement3.z0be().z0iek(xTextTableCellElement2.z0be(), num2, num3 - num2 + 1);
						}
					}
				}
				xTextTableRowElement2.SpecifyHeight = specifyHeight;
				list2.Add(xTextTableRowElement2);
				list.Add(xTextTableRowElement2);
			}
			for (int l = 0; l < xTextTableRowElement.z0rek().Count; l++)
			{
				XTextTableCellElement xTextTableCellElement4 = (XTextTableCellElement)xTextTableRowElement.z0rek()[l];
				if (xTextTableCellElement4.z0aek().z0srk != VerticalAlignStyle.Bottom)
				{
					continue;
				}
				int num4 = list2.Count - ((XTextContentElement)xTextTableCellElement4).z0zek().Length;
				if (num4 > 0)
				{
					for (int num5 = list2.Count - 1; num5 >= num4; num5--)
					{
						XTextTableCellElement xTextTableCellElement5 = (XTextTableCellElement)list2[num5].z0rek()[l];
						XTextTableCellElement xTextTableCellElement6 = (XTextTableCellElement)list2[num5 - num4].z0rek()[l];
						xTextTableCellElement5.z0be().Clear();
						((zzz.z0ZzZzkuk<XTextElement>)xTextTableCellElement5.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextTableCellElement6.z0be());
						xTextTableCellElement6.z0be().Clear();
						xTextTableCellElement6.z0gu();
					}
				}
			}
		}
		if (list.Count == p1)
		{
			return false;
		}
		for (int m = 0; m < p1; m++)
		{
			XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)z0stk()[m + p0];
			if (list.Contains(xTextTableRowElement3))
			{
				continue;
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement3.z0rek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					current.z0be().Clear();
					current.Dispose();
				}
			}
			xTextTableRowElement3.z0be().Clear();
			xTextTableRowElement3.Dispose();
		}
		z0stk().z0irk(p0, p1);
		z0stk().z0yek(p0, list);
		z0oek();
		if (z0jr().z0imk() != null)
		{
			z0jr().z0imk().Clear();
		}
		if (p2)
		{
			z0oe();
		}
		else
		{
			z0li();
		}
		return true;
	}

	public void z0pek(RenderVisibility p0)
	{
		z0ytk = p0;
	}

	internal override IList<XTextElement> z0xe()
	{
		return base.z0ntk;
	}

	public override string z0ti()
	{
		z0ygj z0ygj = new z0ygj(z0rik, p1: true);
		z0bw_jiejie20260327142557(z0ygj);
		return z0ygj.ToString();
	}

	public new void z0krk()
	{
		bool z0uek = false;
		zzz.z0ZzZzkuk<XTextElement> z0yek = null;
		z0yek = new zzz.z0ZzZzkuk<XTextElement>();
		this.z0uek(delegate(XTextTableCellElement p0)
		{
			if (p0.z0irk != null)
			{
				z0yek.z0pek(p0);
				p0.z0rek((XTextTableCellElement)null);
			}
			if (p0.RowSpan > 1 || p0.ColSpan > 1)
			{
				z0uek = true;
			}
		});
		if (!z0uek)
		{
			if (z0yek.Count <= 0)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0yek.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement obj = (XTextTableCellElement)z0bpk.Current;
				obj.z0gu();
				obj.z0xi(p0: true);
			}
			return;
		}
		z0mtk = null;
		XTextElementList xTextElementList = z0crk();
		int z0tek = z0brk();
		int z0oek = z0drk();
		int z0mek = xTextElementList.Count;
		zzz.z0ZzZzkuk<XTextTableCellElement> z0pek = new zzz.z0ZzZzkuk<XTextTableCellElement>();
		this.z0uek(delegate(XTextTableCellElement p0)
		{
			if (p0.z0irk == null)
			{
				int num2 = p0.z0pek();
				int num3 = p0.z0xek();
				if (p0.RowSpan > 1 && num2 + p0.RowSpan > z0mek)
				{
					p0.z0yek(z0tek - num2);
				}
				if (p0.ColSpan > 1 && num3 + p0.ColSpan > z0oek)
				{
					p0.z0tek(z0oek - num3);
				}
				int num4 = 0;
				while (true)
				{
					IL_0067:
					int num5 = p0.z0iek();
					if (num5 > 1 || p0.ColSpan > 1)
					{
						z0pek.Clear();
						z0rek(num2, num3, num5, p0.ColSpan, p4: true, z0pek);
						if (z0pek.Count > 0)
						{
							using zzz.z0ZzZzkuk<XTextTableCellElement>.z0bpk z0bpk2 = z0pek.z0ltk();
							while (z0bpk2.MoveNext())
							{
								XTextTableCellElement current = z0bpk2.Current;
								if (current.z0hrk() != null && current.z0hrk() != p0)
								{
									num4++;
									if (num4 > 20)
									{
										break;
									}
									p0.z0tek(current.z0xek() - num3);
									goto IL_0067;
								}
								current.z0rek(p0);
							}
						}
						p0.z0rek((XTextTableCellElement)null);
					}
					break;
				}
			}
		});
		z0pek.Clear();
		z0pek = null;
		if (z0yek == null || z0yek.Count <= 0)
		{
			return;
		}
		XTextElement[] array = z0yek.z0krk();
		for (int num = z0yek.Count - 1; num >= 0; num--)
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array[num];
			if (xTextTableCellElement.z0irk == null)
			{
				xTextTableCellElement.z0gu();
				xTextTableCellElement.z0xi(p0: true);
			}
		}
		z0yek.Clear();
	}

	public override XTextElement z0ce(Type p0)
	{
		if (p0 == typeof(XTextTableColumnElement) && z0srk() != null && z0srk().Count > 0)
		{
			return z0srk()[0];
		}
		return base.z0ce(p0);
	}

	public XTextTableElement()
	{
		AllowUserDeleteRow = true;
		AllowUserInsertRow = true;
		AllowUserToResizeColumns = true;
		AllowUserToResizeRows = true;
		z0bek(p0: true);
	}

	private new bool z0jrk()
	{
		if (z0dtk() == DCBooleanValue.Inherit)
		{
			return z0iu().ShowCellNoneBorder;
		}
		if (z0dtk() == DCBooleanValue.True)
		{
			return true;
		}
		if (z0dtk() == DCBooleanValue.False)
		{
			return false;
		}
		return true;
	}

	public new TableSubfieldMode z0hrk()
	{
		return z0lyk;
	}

	internal new bool z0grk()
	{
		bool flag = false;
		for (int num = z0srk().Count - 1; num > 0; num--)
		{
			bool flag2 = true;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					if (!((XTextTableCellElement)((XTextTableRowElement)z0bpk.Current).z0rek()[num]).z0bek())
					{
						flag2 = false;
						break;
					}
				}
			}
			if (flag2)
			{
				flag = true;
				XTextElementList xTextElementList = new XTextElementList();
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableRowElement obj = (XTextTableRowElement)z0bpk.Current;
						XTextTableCellElement xTextTableCellElement = ((XTextTableCellElement)obj.z0rek()[num]).z0hrk();
						if (!xTextElementList.Contains(xTextTableCellElement))
						{
							xTextElementList.Add(xTextTableCellElement);
							xTextTableCellElement.z0tek(xTextTableCellElement.ColSpan - 1);
						}
						obj.z0rek().z0bek(num);
					}
				}
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0srk()[num];
				((XTextTableColumnElement)z0srk()[num - 1]).Width += xTextTableColumnElement.Width;
				z0srk().z0bek(num);
			}
		}
		for (int num2 = z0stk().Count - 1; num2 > 0; num2--)
		{
			bool flag3 = true;
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0stk()[num2];
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					if (!((XTextTableCellElement)z0bpk.Current).z0bek())
					{
						flag3 = false;
						break;
					}
				}
			}
			if (flag3)
			{
				flag = true;
				XTextElementList xTextElementList2 = new XTextElementList();
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement2 = ((XTextTableCellElement)z0bpk.Current).z0hrk();
						if (!xTextElementList2.Contains(xTextTableCellElement2))
						{
							xTextElementList2.Add(xTextTableCellElement2);
							xTextTableCellElement2.z0yek(xTextTableCellElement2.RowSpan - 1);
						}
					}
				}
				z0stk().z0bek(num2);
			}
		}
		if (flag)
		{
			for (int i = 0; i < z0stk().Count; i++)
			{
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)z0stk()[i];
				xTextTableRowElement2.z0muk = i;
				for (int j = 0; j < xTextTableRowElement2.z0rek().Count; j++)
				{
					XTextTableCellElement obj2 = (XTextTableCellElement)xTextTableRowElement2.z0rek()[j];
					obj2.z0nrk = i;
					obj2.z0muk = j;
				}
			}
		}
		return flag;
	}

	public override void z0li()
	{
		z0pek(p0: true, p1: true);
	}

	public XTextTableCellElement z0pek(float p0, float p1)
	{
		if (((XTextElement)this).z0krk() || !z0yi())
		{
			return null;
		}
		z0ZzZzbdh p2 = z0qyk();
		if (p2.z0eek(p0, p1))
		{
			XTextElementList xTextElementList = z0crk();
			if (xTextElementList.Count > 10 && xTextElementList == z0stk())
			{
				int num = xTextElementList.z0uek(null, new z0xjj(p2, p1));
				if (num >= 0)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList[num];
					float p3 = p2.z0pek() + xTextTableRowElement.z0yt();
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
						if (xTextTableCellElement.z0yi() && new z0ZzZzbdh(p2.z0oek() + xTextTableCellElement.z0it(), p3, xTextTableCellElement.Width, xTextTableCellElement.Height).z0eek(p0, p1))
						{
							return xTextTableCellElement;
						}
					}
				}
			}
			for (int num2 = xTextElementList.Count - 1; num2 >= 0; num2--)
			{
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)xTextElementList[num2];
				if (xTextTableRowElement2.z0cuk)
				{
					float num3 = p2.z0pek() + xTextTableRowElement2.z0yt();
					if (p1 >= num3 && p1 < num3 + xTextTableRowElement2.z0mek())
					{
						using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement2.z0rek().z0ltk();
						while (z0bpk.MoveNext())
						{
							XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk.Current;
							if (xTextTableCellElement2.z0yi() && new z0ZzZzbdh(p2.z0oek() + xTextTableCellElement2.z0it(), num3, xTextTableCellElement2.Width, xTextTableCellElement2.Height).z0eek(p0, p1))
							{
								return xTextTableCellElement2;
							}
						}
					}
				}
			}
		}
		return null;
	}

	public override XTextElementList z0ve()
	{
		XTextElementList xTextElementList = base.z0ve();
		((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)z0srk());
		return xTextElementList;
	}

	public override XTextElementList z0be()
	{
		return base.z0be();
	}

	public void z0mek(int p0)
	{
		z0ptk = p0;
	}

	public override bool z0ne(int p0, XTextElement p1)
	{
		if (p1 is XTextTableColumnElement)
		{
			z0srk().Insert(p0, p1);
			p1.z0nu(this);
			p1.z0bt(z0jr());
			return true;
		}
		return base.z0ne(p0, p1);
	}

	public new DCTableAlignment z0frk()
	{
		return z0kyk;
	}

	public new int z0drk()
	{
		if (z0itk == null)
		{
			return 0;
		}
		return z0itk.Count;
	}

	public new XTextElementList z0srk()
	{
		return z0itk;
	}

	public override XTextElementList z0me(Type p0)
	{
		if (p0 == typeof(XTextTableColumnElement) && z0srk() != null)
		{
			XTextElementList xTextElementList = new XTextElementList();
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)z0srk());
			return xTextElementList;
		}
		return base.z0me(p0);
	}

	public override bool z0ou(XTextElement p0)
	{
		if (p0 is XTextTableColumnElement)
		{
			z0srk().Add(p0);
			p0.z0nu(this);
			p0.z0bt(z0jr());
			return true;
		}
		return base.z0ou(p0);
	}

	public bool z0eek_jiejie20260327142557(int p0, int p1, bool p2, Dictionary<XTextTableCellElement, int> p3, bool p4, Dictionary<XTextTableColumnElement, float> p5)
	{
		if (p0 < 0 || p0 >= z0srk().Count)
		{
			throw new ArgumentOutOfRangeException(string.Format(z0ZzZziok.z0ryk(), "startColumnIndex", p0, z0srk().Count - 1, 0));
		}
		if (p1 <= 0)
		{
			throw new ArgumentOutOfRangeException("colCount=" + p1);
		}
		if (p0 + p1 > z0srk().Count)
		{
			throw new ArgumentOutOfRangeException(string.Format(z0ZzZziok.z0ryk(), "startIndex+Count", p0 + p1, z0srk().Count - 1, 0));
		}
		float num = 0f;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
				num += xTextTableColumnElement.Width;
			}
		}
		z0ZzZzelh z0ZzZzelh = null;
		if (p2)
		{
			z0ZzZzelh = new z0ZzZzelh();
			z0ZzZzelh.z0eek(new z0ZzZzmzj(this));
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		XTextDocument xTextDocument = z0jr();
		int p6 = 0;
		XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextDocumentContentElement.z0frk().z0tek(typeof(XTextTableCellElement));
		if (xTextTableCellElement != null && xTextTableCellElement.z0gr() == this)
		{
			p6 = xTextTableCellElement.z0pek();
		}
		z0srk().z0irk(p0, p1);
		if (xTextDocument.z0rik() != null)
		{
			xTextDocument.z0rik().z0ww(xTextDocument, this, p0, -p1);
		}
		((XTextElement)this).z0rrk();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
				if (xTextTableRowElement.z0rek().Count <= p0)
				{
					continue;
				}
				if (xTextDocument.z0htk() != null)
				{
					for (int i = 0; i < p1; i++)
					{
						XTextElement p7 = xTextTableRowElement.z0rek()[p0 + i];
						xTextDocument.z0htk().z0qp(p7);
					}
				}
				xTextTableRowElement.z0rek().z0irk(p0, p1);
				if (p3 != null && p3.Count > 0)
				{
					foreach (XTextTableCellElement key in p3.Keys)
					{
						key.z0tek(p3[key]);
					}
					continue;
				}
				for (int j = 0; j < p0; j++)
				{
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement.z0rek()[j];
					if (!xTextTableCellElement2.z0bek() && xTextTableCellElement2.ColSpan > 1 && xTextTableCellElement2.z0xek() + xTextTableCellElement2.ColSpan - 1 >= p0)
					{
						int num2 = xTextTableCellElement2.ColSpan - p1;
						if (num2 < p0 - j)
						{
							num2 = p0 - j;
						}
						xTextTableCellElement2.z0tek(num2);
						break;
					}
				}
			}
		}
		if (p5 != null && p5.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement2 = (XTextTableColumnElement)z0bpk.Current;
				if (p5.ContainsKey(xTextTableColumnElement2))
				{
					xTextTableColumnElement2.Width = p5[xTextTableColumnElement2];
				}
			}
		}
		else if (p4)
		{
			float num3 = 0f;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableColumnElement xTextTableColumnElement3 = (XTextTableColumnElement)z0bpk.Current;
					num3 += xTextTableColumnElement3.Width;
				}
			}
			float num4 = num / num3;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk();
			while (z0bpk.MoveNext())
			{
				((XTextTableColumnElement)z0bpk.Current).Width *= num4;
			}
		}
		float height = Height;
		try
		{
			XTextContainerElement.z0btk = false;
			z0jo();
			z0ct();
			z0jo();
			z0jy().z0bek(p0: true);
			xTextDocumentContentElement.z0ark();
			z0mek(height != Height);
			xTextDocument.Modified = true;
			XTextTableCellElement xTextTableCellElement3 = z0nek(p6, (p0 >= z0srk().Count) ? (p0 - 1) : p0, p2: false);
			if (xTextTableCellElement3 == null)
			{
				xTextTableCellElement3 = z0nek(0, (p0 >= z0srk().Count) ? (p0 - 1) : p0, p2: false);
			}
			if (xTextTableCellElement3.z0bek())
			{
				xTextTableCellElement3 = xTextTableCellElement3.z0hrk();
			}
			xTextDocumentContentElement.z0frk();
			xTextDocumentContentElement.z0uek(xTextTableCellElement3.z0trk()[0].z0jrk(), 0);
		}
		finally
		{
			XTextContainerElement.z0btk = true;
		}
		if (z0ZzZzelh != null && xTextDocument.z0ytk())
		{
			z0ZzZzelh.z0rek(new z0ZzZzmzj(this));
			xTextDocument.z0bek(z0ZzZzelh);
			xTextDocument.z0nuk();
			xTextDocument.OnSelectionChanged();
			xTextDocument.OnDocumentContentChanged();
		}
		return true;
	}

	public new int z0ark()
	{
		return z0srk().Count;
	}

	internal int z0pek(XTextTableRowElement p0)
	{
		if (base.z0ntk.SafeGet(p0.z0grk()) == p0)
		{
			return p0.z0grk();
		}
		return base.z0ntk.IndexOf(p0);
	}

	public new void z0qrk()
	{
		z0mtk = null;
	}

	public void z0mek(RenderVisibility p0)
	{
		z0ctk = p0;
	}

	internal new void z0wrk()
	{
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		float num = z0ZzZzrzj.z0quk;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0crk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
				xTextTableRowElement.z0nt(num);
				num += xTextTableRowElement.Height;
				xTextTableRowElement.z0ot(z0ZzZzrzj.z0ryk);
			}
		}
		Height = num + z0ZzZzrzj.z0xrk;
		if (z0ptk() != null)
		{
			z0ptk().z0jtk();
		}
	}

	public void z0pek(string p0)
	{
		z0rtk = p0;
	}

	private void z0rek(int p0, int p1, int p2, int p3, bool p4, zzz.z0ZzZzkuk<XTextTableCellElement> p5)
	{
		if (p2 < 0 || p3 < 0)
		{
			return;
		}
		int num = p0 + p2 - 1;
		int num2 = p1 + p3 - 1;
		if (p0 < 0)
		{
			p0 = 0;
		}
		if (p1 < 0)
		{
			p1 = 0;
		}
		XTextElementList xTextElementList = z0stk();
		if (p0 >= xTextElementList.Count || p1 >= z0srk().Count)
		{
			return;
		}
		if (num >= xTextElementList.Count)
		{
			num = xTextElementList.Count - 1;
		}
		if (num2 >= z0srk().Count)
		{
			num2 = z0srk().Count - 1;
		}
		for (int i = p0; i <= num; i++)
		{
			XTextElementList xTextElementList2 = ((XTextTableRowElement)xTextElementList[i]).z0rek();
			int count = xTextElementList2.Count;
			for (int j = p1; j <= num2 && j < count; j++)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElementList2[j];
				if (p4 || !xTextTableCellElement.z0bek())
				{
					p5.Add(xTextTableCellElement);
				}
			}
		}
	}

	public new XTextTableCellElement z0erk()
	{
		for (int num = z0stk().Count - 1; num >= 0; num--)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0stk()[num];
			if (xTextTableRowElement.z0yi())
			{
				for (int num2 = xTextTableRowElement.z0rek().Count - 1; num2 >= 0; num2--)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.z0rek()[num2];
					if (xTextTableCellElement.z0yi())
					{
						return xTextTableCellElement;
					}
				}
			}
		}
		return null;
	}

	internal new void z0rrk()
	{
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0be()).z0krk();
		for (int num = z0be().Count - 1; num >= 0; num--)
		{
			XTextElementList xTextElementList = array[num].z0be();
			XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
			for (int num2 = xTextElementList.Count - 1; num2 >= 0; num2--)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array2[num2];
				if (!xTextTableCellElement.z0bek())
				{
					((XTextContentElement)xTextTableCellElement).z0lrk();
				}
			}
		}
	}

	public override float z0ut()
	{
		return z0fik + z0ntk;
	}

	public override bool z0ky()
	{
		return true;
	}

	private void z0mek(z0ZzZzszj p0)
	{
		XTextElement[] array = p0.z0rek(this);
		if (array == null || p0.z0yrk || p0.z0irk != PageViewMode.Page)
		{
			return;
		}
		XTextElement xTextElement = p0.z0pek();
		while (xTextElement != null && xTextElement.z0ji() != this)
		{
			xTextElement = xTextElement.z0ji();
		}
		XTextElementList xTextElementList = z0crk();
		if (xTextElementList.Contains(xTextElement))
		{
			XTextTableRowElement item = (XTextTableRowElement)xTextElement;
			if (xTextElementList.IndexOf(item) > xTextElementList.IndexOf(array[array.Length - 1]))
			{
				p0.z0rek(array);
			}
		}
	}

	public new void z0bek(bool p0)
	{
		z0urk(p0);
	}

	public void z0pek(int p0, int p1)
	{
		if (p0 <= 0)
		{
			throw new ArgumentOutOfRangeException("rowsCount=" + p0);
		}
		if (p1 <= 0)
		{
			throw new ArgumentOutOfRangeException("columnsCount=" + p1);
		}
		z0stk().Clear();
		z0srk().Clear();
		for (int i = 0; i < p1; i++)
		{
			XTextTableColumnElement xTextTableColumnElement = z0vek();
			xTextTableColumnElement.z0nu(this);
			z0srk().Add(xTextTableColumnElement);
		}
		for (int j = 0; j < p0; j++)
		{
			XTextTableRowElement xTextTableRowElement = z0nrk();
			xTextTableRowElement.z0nu(this);
			z0stk().Add(xTextTableRowElement);
			for (int k = 0; k < p1; k++)
			{
				XTextTableCellElement xTextTableCellElement = z0urk();
				xTextTableCellElement.z0nu(xTextTableRowElement);
				xTextTableRowElement.z0rek().Add(xTextTableCellElement);
			}
		}
	}

	public new XTextTableCellElement z0trk()
	{
		if (z0stk().Count > 0)
		{
			foreach (XTextTableRowElement item in z0stk().z0xrk())
			{
				if (!item.z0yi())
				{
					continue;
				}
				foreach (XTextTableCellElement item2 in item.z0rek().z0xrk())
				{
					if (item2.z0yi())
					{
						return item2;
					}
				}
			}
		}
		return null;
	}

	public override void z0oy(ElementEventArgs p0)
	{
		z0jo();
		base.z0oy(p0);
	}

	public XTextTableCellElement z0pek(XTextTableCellElement p0)
	{
		XTextTableCellElement xTextTableCellElement = z0urk();
		if (p0 != null)
		{
			xTextTableCellElement.z0oek(((XTextElement)p0).z0pek());
			xTextTableCellElement.z0be().Clear();
			if (p0.z0be().LastElement is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
				xTextParagraphFlagElement.z0oek(p0.z0be().LastElement.z0pek());
				if (((XTextElement)xTextParagraphFlagElement).z0pek() < 0)
				{
					xTextParagraphFlagElement.z0rek(p0: true);
				}
				xTextTableCellElement.z0be().Add(xTextParagraphFlagElement);
			}
		}
		return xTextTableCellElement;
	}

	internal new void z0vek(bool p0)
	{
		if (z0xu() || z0jr() == null)
		{
			return;
		}
		z0wtk = false;
		float num = 0f;
		float num2 = 0f;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
				if (xTextTableColumnElement.Visible)
				{
					if (xTextTableColumnElement.Width < 5f)
					{
						num2 += 1f;
					}
					else
					{
						num += xTextTableColumnElement.Width;
					}
				}
			}
		}
		if (num2 > 0f)
		{
			float num3 = 50f;
			float num4 = ((XTextElement)z0ji()).z0ork() - num;
			if (num4 > 0f)
			{
				num3 = Math.Max(num3, num4 / num2);
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement2 = (XTextTableColumnElement)z0bpk.Current;
				if (xTextTableColumnElement2.Visible && xTextTableColumnElement2.Width < 5f)
				{
					xTextTableColumnElement2.Width = num3;
				}
			}
		}
		z0mtk = null;
		z0jyk = false;
		if (!z0jr().z0snk())
		{
			z0cek(p0: true);
			z0krk();
		}
		bool flag = XTextContentElement.z0ytk;
		XTextContentElement.z0ytk = false;
		try
		{
			z0mek(p0: true, p1: false);
		}
		finally
		{
			XTextContentElement.z0ytk = flag;
			XTextContentElement.z0dtk?.z0ktk();
		}
		if (z0kik != null && p0)
		{
			z0kik.z0erk();
			z0kik.z0jtk();
		}
	}

	internal bool z0mek(int p0, int p1, bool p2)
	{
		if (p0 < 0 || p0 > z0stk().Count)
		{
			throw new ArgumentOutOfRangeException("startRowIndex=" + p0);
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException(string.Format(z0ZzZziok.z0ryk(), "rowsCount", p1, z0stk().Count - 1, 0));
		}
		if (p0 + p1 > z0stk().Count)
		{
			throw new ArgumentOutOfRangeException(string.Format(z0ZzZziok.z0ryk(), "startRowIndex + rowsCount", p0 + p1, z0stk().Count - 1, 0));
		}
		z0ZzZzelh z0ZzZzelh = null;
		if (p2)
		{
			z0ZzZzelh = new z0ZzZzelh();
			z0ZzZzelh.z0eek(new z0ZzZzmzj(this));
		}
		z0jo();
		z0ZzZzmxj z0ZzZzmxj = z0jr().z0htk();
		if (z0ZzZzmxj != null)
		{
			for (int i = 0; i < p1; i++)
			{
				z0ZzZzmxj.z0qp(z0stk()[p0 + i]);
			}
		}
		z0stk().z0irk(p0, p1);
		if (z0jr().z0rik() != null)
		{
			z0jr().z0rik().z0ew(z0jr(), this, p0, -p1);
		}
		((XTextElement)this).z0rrk();
		z0mtk = null;
		z0xek();
		z0krk();
		z0mek(p0: true, p1: false);
		z0qek().z0ark();
		z0ZzZzelh?.z0rek(new z0ZzZzmzj(this));
		if (p2 && z0jr().z0uik())
		{
			z0jr().z0bek(z0ZzZzelh);
		}
		return true;
	}

	public void z0pek(XTextElementList p0)
	{
		base.z0ntk = p0;
	}

	public bool z0tek(Dictionary<XTextTableRowElement, bool> p0, bool p1)
	{
		if (p0 == null || p0.Count == 0)
		{
			return false;
		}
		bool flag = false;
		z0ZzZzllh z0ZzZzllh = new z0ZzZzllh();
		z0ZzZzllh.z0eek(this);
		foreach (XTextTableRowElement key in p0.Keys)
		{
			if (key.z0pek() != p0[key])
			{
				flag = true;
				z0ZzZzllh.z0eek()[key] = key.HeaderStyle;
				z0ZzZzllh.z0rek()[key] = p0[key];
				key.HeaderStyle = p0[key];
			}
		}
		if (flag)
		{
			((XTextElement)this).z0rrk();
			XTextDocument xTextDocument = z0jr();
			xTextDocument.Modified = true;
			if (p1 && xTextDocument.z0uik())
			{
				xTextDocument.z0bek(z0ZzZzllh);
			}
			z0mtk = null;
			z0wrk();
			z0mek(p0: true);
			ContentChangedEventArgs e = new ContentChangedEventArgs();
			e.Element = this;
			z0zi(e);
		}
		return flag;
	}

	public XTextTableCellElement z0pek(string p0, bool p1)
	{
		z0ZzZzryk z0ZzZzryk = new z0ZzZzryk(p0);
		return z0nek(z0ZzZzryk.z0oek() - 1, z0ZzZzryk.z0eek() - 1, p1);
	}

	public override string z0pe()
	{
		return "table";
	}

	private void z0pek(object p0, bool p1, bool p2, bool p3)
	{
		XTextDocument xTextDocument = z0jr();
		DocumentViewOptions documentViewOptions = xTextDocument.z0iu();
		z0ZzZzvxj z0ZzZzvxj = (z0ZzZzvxj)p0;
		bool p4 = z0ZzZzvxj.z0zrk;
		if (z0ZzZzvxj.z0nek().z0bek())
		{
			return;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement == null)
		{
			return;
		}
		if (z0ZzZzvxj.z0tek())
		{
			_ = PrintBothBorderWhenJumpPrint;
		}
		XTextContainerElement xTextContainerElement = z0cek(z0ZzZzvxj);
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		float p5 = ((XTextElement)this).z0zrk() + z0ZzZzrzj.z0ryk;
		float p6 = ((XTextElement)this).z0ltk() + z0ZzZzrzj.z0quk;
		z0ZzZzbdh p7 = z0ZzZzvxj.z0nek();
		z0ZzZzppk z0ZzZzppk = (z0ZzZzvxj.z0nrk ? null : new z0ZzZzppk());
		PageContentPartyStyle pageContentPartyStyle = xTextDocumentContentElement.z0du();
		bool flag = false;
		DocumentOptions documentOptions = xTextDocument.z0vu();
		if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3)
		{
			JumpPrintInfo jumpPrintInfo = z0ZzZzvxj.z0bek()?.z0pek();
			if (documentViewOptions.HiddenTableBorderJumpPrintPage && jumpPrintInfo != null && jumpPrintInfo.Enabled && jumpPrintInfo.Mode == JumpPrintMode.Normal && z0ZzZzvxj.z0oek() == jumpPrintInfo.PageIndex)
			{
				float position = jumpPrintInfo.Position;
				z0ZzZzbdh z0ZzZzbdh = z0qyk();
				if (z0ZzZzbdh.z0pek() < position && position < z0ZzZzbdh.z0nek() && z0ZzZzccj.z0rek(95))
				{
					flag = true;
				}
			}
		}
		if (z0ZzZzvxj.z0nrk)
		{
			flag = true;
		}
		bool flag2 = xTextDocument.z0qxk != null && !xTextDocument.z0qxk.z0bek();
		if (flag2 && !xTextDocument.z0iu().ShowGlobalGridLineInTableAndSection)
		{
			flag2 = false;
		}
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzvxj.z0hrk();
		bool flag3 = z0ZzZzvxj.z0hrk().z0bek();
		if (z0ZzZzrzj.z0wrk && !flag && p1)
		{
			z0ZzZzbdh p8 = z0qyk();
			if (!flag3)
			{
				p8 = z0ZzZzbdh.z0tek(p8, z0ZzZzbdh2);
			}
			if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 && z0ZzZzvxj.z0ytk && !xTextDocumentContentElement.z0oek().z0rek(this))
			{
				p8 = z0ZzZzbdh.z0xek;
			}
			if (z0ZzZzppk != null && !p8.z0bek())
			{
				if (flag2 && z0ZzZzrzj.z0rtk == Color.Black && z0ZzZzrzj.z0erk == 1f && z0ZzZzrzj.z0guk == DashStyle.Solid)
				{
					z0ZzZzppk.z0eek(p8, z0ZzZzrzj.z0rrk, p2: false, z0ZzZzrzj.z0etk, p4: false, z0ZzZzrzj.z0rtk, z0ZzZzrzj.z0erk, z0ZzZzrzj.z0guk, -1, p9: false);
				}
				else
				{
					z0ZzZzppk.z0eek(p8, z0ZzZzrzj.z0rrk, z0ZzZzrzj.z0wyk, z0ZzZzrzj.z0etk, z0ZzZzrzj.z0mrk, z0ZzZzrzj.z0rtk, z0ZzZzrzj.z0erk, z0ZzZzrzj.z0guk, -1, p9: false);
				}
			}
		}
		Color noneBorderColor = documentViewOptions.NoneBorderColor;
		z0ZzZzhkh z0ZzZzhkh = xTextDocumentContentElement.z0oek();
		bool flag4 = z0jrk();
		List<XTextTableCellElement> list = null;
		if (z0stk().Count * z0drk() > 2000)
		{
			if (z0etk == null)
			{
				z0etk = new List<XTextTableCellElement>(200);
			}
			list = z0etk;
		}
		else
		{
			list = new List<XTextTableCellElement>();
		}
		z0ZzZzqxj p9 = (z0ZzZzvxj.z0htk ? z0ZzZzvxj.z0vtk.z0zo(this, null) : null);
		z0ZzZzpdh z0ZzZzpdh = z0zw();
		XTextElementList xTextElementList = z0crk();
		int count = xTextElementList.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		for (int i = 0; i < count; i++)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)array[i];
			if (!xTextTableRowElement.z0yi() || xTextTableRowElement.Height <= 0f || (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 && xTextTableRowElement.PrintVisibility != ElementVisibility.Visible) || !z0ZzZzvxj.z0eek(xTextTableRowElement.z0aek().z0dyk))
			{
				continue;
			}
			z0ZzZzbdh z0ZzZzbdh3 = xTextTableRowElement.z0yek(p5, p6);
			bool flag5 = false;
			if (!flag3 && z0ZzZzbdh3.z0pek() <= z0ZzZzbdh2.z0pek() - 5f)
			{
				flag5 = true;
			}
			if (z0ZzZzbdh3.z0pek() > p7.z0nek())
			{
				break;
			}
			float num = z0ZzZzbdh3.z0pek() + xTextTableRowElement.z0mek() - p7.z0pek();
			if (((double)num < 1.5 && z0ZzZzvxj.z0byk == (z0ZzZzcxj)3) || num < -2f || (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 && p7.z0nek() - z0ZzZzbdh3.z0pek() < 2f))
			{
				continue;
			}
			z0ZzZzvxj.z0rek(p0: false);
			z0ZzZzvxj.z0gtk = z0ZzZzbdh3;
			z0ZzZzvxj.z0tek(xTextTableRowElement.z0aek().z0eek(z0ZzZzbdh3));
			z0ZzZzvxj.z0hyk = xTextTableRowElement;
			float p10 = z0ZzZzpdh.z0tek() + xTextTableRowElement.z0yt();
			XTextElementList xTextElementList2 = xTextTableRowElement.z0rek();
			int count2 = xTextElementList2.Count;
			XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0krk();
			bool flag6 = false;
			for (int j = 0; j < count2; j++)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array2[j];
				if (xTextTableCellElement.z0fik == 0f || !xTextTableCellElement.z0yi())
				{
					continue;
				}
				z0ZzZzrzj z0ZzZzrzj2 = xTextTableCellElement.z0aek();
				if (!z0ZzZzvxj.z0eek(z0ZzZzrzj2.z0dyk) || (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 && (xTextTableCellElement.PrintVisibility != ElementVisibility.Visible || (z0ZzZzvxj.z0ytk && !z0ZzZzhkh.z0yek(xTextTableCellElement)))))
				{
					continue;
				}
				z0ZzZzvxj.z0hyk = xTextTableCellElement;
				z0ZzZzvxj.z0luk = z0ZzZzrzj2;
				z0ZzZzbdh z0ZzZzbdh4 = xTextTableCellElement.z0yek(z0ZzZzpdh.z0rek(), p10);
				z0ZzZzbdh z0ZzZzbdh5 = z0ZzZzbdh4;
				z0ZzZzbdh p11 = z0ZzZzbdh5;
				z0ZzZzbdh z0ZzZzbdh6 = z0ZzZzbdh.z0tek(z0ZzZzbdh5, p7);
				if (z0ZzZzbdh6.z0uek() <= 0f || z0ZzZzbdh6.z0iek() <= 0f)
				{
					continue;
				}
				if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 && !z0ZzZzvxj.z0yek())
				{
					z0ZzZzbdh z0ZzZzbdh7 = z0ZzZzvxj.z0nek();
					if (z0ZzZzbdh5.z0nek() < z0ZzZzbdh7.z0pek() + 1f || z0ZzZzbdh5.z0pek() > z0ZzZzbdh7.z0nek() - 1f)
					{
						continue;
					}
					if (z0ZzZzbdh5.z0yek() < z0ZzZzbdh7.z0yek() + 1f)
					{
						z0ZzZzbdh5.z0yek(z0ZzZzbdh5.z0nek() - z0ZzZzbdh7.z0yek() - 1f);
						z0ZzZzbdh5.z0rek(z0ZzZzbdh7.z0yek() + 1f);
					}
					if (z0ZzZzbdh5.z0nek() > z0ZzZzbdh7.z0nek() - 1f)
					{
						z0ZzZzbdh5.z0yek(z0ZzZzbdh7.z0nek() - 1f - z0ZzZzbdh5.z0yek());
					}
					p11 = z0ZzZzbdh5;
				}
				else if ((pageContentPartyStyle == PageContentPartyStyle.Body || pageContentPartyStyle == PageContentPartyStyle.HeaderRows) && !flag3)
				{
					z0ZzZzbdh z0ZzZzbdh8 = z0ZzZzbdh2;
					float num2 = Math.Min(z0ZzZzbdh8.z0nek(), z0ZzZzvxj.z0stk);
					z0ZzZzbdh8.z0yek(num2 - z0ZzZzbdh8.z0pek());
					if (z0ZzZzbdh5.z0nek() < z0ZzZzbdh8.z0pek() + 1f || z0ZzZzbdh5.z0pek() > z0ZzZzbdh8.z0nek() - 1f)
					{
						continue;
					}
					if (z0ZzZzbdh5.z0yek() < z0ZzZzbdh8.z0yek() + 1f)
					{
						z0ZzZzbdh5.z0yek(z0ZzZzbdh5.z0nek() - z0ZzZzbdh8.z0yek() - 1f);
						z0ZzZzbdh5.z0rek(z0ZzZzbdh8.z0yek() + 1f);
					}
					if (z0ZzZzbdh5.z0nek() > z0ZzZzbdh8.z0nek() - 1f)
					{
						z0ZzZzbdh5.z0yek(z0ZzZzbdh8.z0nek() - 1f - z0ZzZzbdh5.z0yek());
					}
					p11 = z0ZzZzbdh5;
				}
				z0ZzZzvxj.z0gtk = z0ZzZzbdh4;
				z0ZzZzvxj.z0tek(z0ZzZzrzj2.z0eek(z0ZzZzbdh4));
				if (z0ZzZzvxj.z0nrk)
				{
					xTextTableCellElement.z0rek(z0ZzZzvxj, flag);
					continue;
				}
				if (z0ZzZzvxj.z0wyk)
				{
					xTextDocument.z0vek(z0ZzZzbdh5);
				}
				bool flag7 = true;
				if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 || z0ZzZzvxj.z0byk == (z0ZzZzcxj)2)
				{
					flag7 = xTextTableRowElement.PrintCellBackground;
				}
				if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 && z0ZzZzvxj.z0ytk && !z0ZzZzhkh.z0rek(xTextTableCellElement))
				{
					flag7 = false;
				}
				bool flag8 = false;
				bool flag9 = flag2;
				if (flag7 && !flag)
				{
					z0ZzZzvxj.z0gyk.z0rek();
					if (z0ZzZzvxj.z0pyk && z0ZzZzvxj.z0yyk.z0eek(xTextTableCellElement, z0ZzZzvxj, z0ZzZzbdh5, p9))
					{
						flag9 = false;
					}
					if (z0ZzZzvxj.z0wtk && (((XTextElement)xTextTableCellElement).z0mtk() || ((XTextElement)xTextTableRowElement).z0mtk()))
					{
						flag8 = true;
						xTextDocument.z0zok().z0eek(xTextTableCellElement, z0ZzZzvxj, p2: true, z0ZzZzvxj.z0fuk);
					}
				}
				if (xTextTableCellElement.z0prk())
				{
					z0ZzZzvxj.z0gyk.z0eek(new z0ZzZzbdh(z0ZzZzbdh5.z0oek() - 4f, z0ZzZzbdh5.z0pek() - 4f, z0ZzZzbdh5.z0uek() + 8f, z0ZzZzbdh5.z0iek() + 8f));
				}
				flag6 = true;
				if (z0ZzZzvxj.z0eek(xTextTableCellElement.ContentRenderVisibility))
				{
					bool p12 = z0ZzZzvxj.z0rek();
					z0ZzZzvxj.z0tek(z0ZzZzvxj.z0rek() && !flag);
					try
					{
						if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)0)
						{
							if (z0ZzZzbdh5.z0iek() > 3f)
							{
								xTextTableCellElement.z0rek(z0ZzZzvxj, flag);
							}
						}
						else
						{
							xTextTableCellElement.z0rek(z0ZzZzvxj, flag);
						}
					}
					finally
					{
						z0ZzZzvxj.z0tek(p12);
					}
				}
				if (flag8)
				{
					z0ZzZzvxj.z0gtk = z0ZzZzbdh4;
					xTextDocument.z0zok().z0eek(xTextTableCellElement, z0ZzZzvxj, p2: false, z0ZzZzvxj.z0fuk);
				}
				if (z0ZzZzvxj.z0eek(xTextTableCellElement.BorderRenderVisibility))
				{
					z0ZzZzvxj.z0luk = z0ZzZzrzj2;
					if (!flag)
					{
						if (z0ZzZzrzj2.z0atk == ContentGridLineType.Display)
						{
							z0ZzZzvxj.z0gtk = z0ZzZzbdh4;
							z0ZzZzvxj.z0tek(z0ZzZzrzj2.z0eek(z0ZzZzbdh4));
							xTextTableCellElement.z0eek(z0ZzZzvxj, z0pek(p4, z0ZzZzrzj2.z0zrk), p2: false, p3: false, p4: false, 0f, xTextTableCellElement.z0mrk(), z0ZzZzrzj2.z0eyk, z0ZzZzrzj2.z0mek, p9: false);
						}
						else if (z0ZzZzrzj2.z0atk == ContentGridLineType.ExtentToBottom)
						{
							z0ZzZzvxj.z0gtk = z0ZzZzbdh4;
							z0ZzZzvxj.z0tek(z0ZzZzrzj2.z0eek(z0ZzZzbdh4));
							xTextTableCellElement.z0eek(z0ZzZzvxj, z0pek(p4, z0ZzZzrzj2.z0zrk), p2: true, p3: true, p4: false, 0f, xTextTableCellElement.z0mrk(), z0ZzZzrzj2.z0eyk, z0ZzZzrzj2.z0mek, p9: false);
						}
					}
				}
				if (xTextTableCellElement.z0prk() && z0ZzZzvxj.z0byk != (z0ZzZzcxj)5)
				{
					z0ZzZzvxj.z0gyk.z0rek();
				}
				bool flag10 = true;
				if (p2)
				{
					if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 || z0ZzZzvxj.z0byk == (z0ZzZzcxj)2)
					{
						flag10 = xTextTableRowElement.PrintCellBorder;
					}
					if (flag10 && z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 && z0ZzZzvxj.z0ytk && !z0ZzZzhkh.z0rek(xTextTableCellElement))
					{
						flag10 = false;
					}
					if (flag10)
					{
						flag10 = z0ZzZzvxj.z0eek(xTextTableCellElement.BorderRenderVisibility);
					}
				}
				else
				{
					flag10 = false;
				}
				if (flag10 && !flag && z0ZzZzrzj2.z0erk > 0f)
				{
					int p13 = (xTextTableCellElement.z0rek() ? 1 : 0);
					if (z0ZzZzrzj2.z0rrk)
					{
						z0ZzZzppk.z0eek(z0ZzZzbdh5.z0oek(), z0ZzZzbdh5.z0pek(), z0ZzZzbdh5.z0oek(), z0ZzZzbdh5.z0nek(), z0pek(p4, z0ZzZzrzj2.z0nek), z0ZzZzrzj2.z0erk, z0ZzZzrzj2.z0guk, p13, p8: false);
					}
					if (z0ZzZzrzj2.z0wyk && (!flag9 || flag5 || xTextTableRowElement.HeaderStyle))
					{
						z0ZzZzppk.z0eek(z0ZzZzbdh5.z0oek(), z0ZzZzbdh5.z0pek(), z0ZzZzbdh5.z0mek(), z0ZzZzbdh5.z0pek(), z0pek(p4, z0ZzZzrzj2.z0myk), z0ZzZzrzj2.z0erk, z0ZzZzrzj2.z0guk, p13, p8: false);
					}
					if (z0ZzZzrzj2.z0etk)
					{
						z0ZzZzppk.z0eek(z0ZzZzbdh5.z0mek(), z0ZzZzbdh5.z0pek(), z0ZzZzbdh5.z0mek(), z0ZzZzbdh5.z0nek(), z0pek(p4, z0ZzZzrzj2.z0grk), z0ZzZzrzj2.z0erk, z0ZzZzrzj2.z0guk, p13, p8: false);
					}
					if (z0ZzZzrzj2.z0mrk && (!flag9 || xTextTableRowElement.HeaderStyle))
					{
						z0ZzZzppk.z0eek(z0ZzZzbdh5.z0oek(), z0ZzZzbdh5.z0nek(), z0ZzZzbdh5.z0mek(), z0ZzZzbdh5.z0nek(), z0pek(p4, z0ZzZzrzj2.z0trk), z0ZzZzrzj2.z0erk, z0ZzZzrzj2.z0guk, p13, p8: false);
					}
				}
				if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)0 && flag4 && !flag)
				{
					z0ZzZzrzj z0ZzZzrzj3 = z0ZzZzrzj2;
					if (!z0ZzZzrzj3.z0rrk || !z0ZzZzrzj3.z0wyk || !z0ZzZzrzj3.z0etk || !z0ZzZzrzj3.z0mrk || z0ZzZzrzj3.z0erk == 0f)
					{
						bool p14 = true;
						bool p15 = true;
						bool p16 = true;
						bool p17 = true;
						XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement.z0rek().z0pek(xTextTableCellElement);
						if (xTextTableCellElement2 != null && xTextTableCellElement2.z0hrk() != null)
						{
							xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
						}
						if (xTextTableCellElement2 != null && list.Contains(xTextTableCellElement2))
						{
							z0ZzZzrzj z0ZzZzrzj4 = xTextTableCellElement2.z0aek();
							if (z0ZzZzrzj4.z0etk && z0ZzZzrzj4.z0erk > 0f && z0ZzZzrzj4.z0nek.A != 0)
							{
								p14 = false;
							}
						}
						XTextTableCellElement xTextTableCellElement3 = z0nek(xTextTableCellElement.z0pek() - 1, xTextTableCellElement.z0xek(), p2: false);
						if (xTextTableCellElement3 != null && xTextTableCellElement3.z0hrk() != null)
						{
							xTextTableCellElement3 = xTextTableCellElement3.z0hrk();
						}
						if (xTextTableCellElement3 != null && list.Contains(xTextTableCellElement3))
						{
							z0ZzZzrzj z0ZzZzrzj5 = xTextTableCellElement3.z0aek();
							if (z0ZzZzrzj5.z0mrk && z0ZzZzrzj5.z0erk > 0f && z0ZzZzrzj5.z0myk.A != 0)
							{
								p15 = false;
							}
						}
						if (flag9 && !xTextTableRowElement.HeaderStyle)
						{
							if (!flag5)
							{
								p15 = false;
							}
							p17 = false;
						}
						z0ZzZzppk.z0eek(p11, p14, p15, p16, p17, noneBorderColor, 1f, DashStyle.Solid, 0, p9: true);
					}
				}
				if (z0ZzZzvxj.z0eyk && xTextDocument.z0yyk() != null && z0ZzZzvxj.z0eek(xTextTableCellElement))
				{
					xTextDocument.z0yyk().z0eek(z0ZzZzndh.z0eek(xTextTableCellElement.z0qyk()));
				}
				list.Add(xTextTableCellElement);
			}
			z0ZzZzvxj.z0gtk = z0ZzZzbdh3;
			z0ZzZzvxj.z0tek(xTextTableRowElement.z0aek().z0eek(z0ZzZzbdh3));
			if (z0ttk != null && flag6)
			{
				z0ZzZzbdh z0ZzZzbdh9 = z0ZzZzbdh3;
				if (!z0ZzZzvxj.z0hrk().z0bek())
				{
					z0ZzZzbdh9 = z0ZzZzbdh.z0tek(z0ZzZzbdh9, z0ZzZzvxj.z0hrk());
				}
				z0ttk(xTextTableRowElement, z0ZzZzbdh9, z0ZzZzvxj);
			}
			if (xTextContainerElement == xTextTableRowElement)
			{
				xTextTableRowElement.z0xek(z0ZzZzvxj);
			}
		}
		list.Clear();
		list = null;
		if (z0ZzZzppk != null)
		{
			int p18 = 0;
			z0ZzZzbdh z0ZzZzbdh10 = z0ZzZzvxj.z0nek();
			if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3)
			{
				z0ZzZzbdh10.z0eek(z0ZzZzbdh10.z0tek() - 1f);
				z0ZzZzbdh10.z0tek(z0ZzZzbdh10.z0uek() + 5f);
			}
			else
			{
				z0ZzZzbdh10.z0eek(z0ZzZzbdh10.z0tek() - 1f);
				z0ZzZzbdh10.z0tek(z0ZzZzbdh10.z0uek() + 3f);
			}
			z0ZzZzppk.z0mvk_jiejie20260327142557[] array3 = z0ZzZzppk.z0eek(ref p18, z0ZzZzbdh10);
			if (p18 > 0 && !flag)
			{
				bool flag11 = true;
				if (!z0ZzZzvxj.z0eek(documentViewOptions.TableCellBorderVisibility))
				{
					flag11 = false;
				}
				if (flag11)
				{
					z0ZzZzvxj.z0gyk.z0rek();
					z0ZzZzvxj.z0gyk.z0eek(z0ZzZzbdh10);
					for (int k = 0; k < p18; k++)
					{
						z0ZzZzppk.z0mvk_jiejie20260327142557 z0mvk_jiejie20260327142557 = array3[k];
						if (z0ZzZzvxj.z0gyk == null)
						{
							continue;
						}
						if (z0mvk_jiejie20260327142557.z0oek == Color.Black && z0mvk_jiejie20260327142557.z0tek == 1f && z0mvk_jiejie20260327142557.z0mek == DashStyle.Solid)
						{
							z0ZzZzvxj.z0gyk.z0eek(z0ZzZzidh.z0iek, z0mvk_jiejie20260327142557.z0uek, z0mvk_jiejie20260327142557.z0vek, z0mvk_jiejie20260327142557.z0yek, z0mvk_jiejie20260327142557.z0zek);
						}
						else
						{
							using z0ZzZzudh p19 = z0ZzZzdpk.z0eek(z0mvk_jiejie20260327142557.z0oek, z0mvk_jiejie20260327142557.z0tek, z0mvk_jiejie20260327142557.z0mek);
							z0ZzZzvxj.z0gyk.z0eek(p19, z0mvk_jiejie20260327142557.z0uek, z0mvk_jiejie20260327142557.z0vek, z0mvk_jiejie20260327142557.z0yek, z0mvk_jiejie20260327142557.z0zek);
						}
						if (!z0mvk_jiejie20260327142557.z0lrk && z0mvk_jiejie20260327142557.z0vek == z0mvk_jiejie20260327142557.z0zek)
						{
							xTextDocument.z0frk(z0mvk_jiejie20260327142557.z0vek);
						}
					}
				}
			}
			z0ZzZzppk.Dispose();
			z0ZzZzppk = null;
		}
		if (documentOptions.BehaviorOptions.DesignMode && z0ZzZzvxj.z0byk == (z0ZzZzcxj)0)
		{
			z0ZzZzudh z0ZzZzudh = new z0ZzZzudh(Color.FromArgb(150, Color.Red));
			z0ZzZzudh.z0rek(new z0ZzZzofh(4f, 4f));
			z0ZzZzudh.z0eek(z0ZzZzudh.z0rek());
			XTextElementList xTextElementList3 = z0crk();
			z0ZzZzbdh z0ZzZzbdh11 = z0qyk();
			for (int l = 0; l < xTextElementList3.Count; l++)
			{
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)xTextElementList3[l];
				if (xTextTableRowElement2.ValueBinding != null && !xTextTableRowElement2.ValueBinding.IsEmptyBinding && xTextTableRowElement2.ValueBinding.z0eek() && xTextTableRowElement2.ExpendForDataBinding && xTextTableRowElement2.z0uek() > 0)
				{
					int index = Math.Min(l + xTextTableRowElement2.z0uek() - 1, xTextElementList3.Count - 1);
					XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)xTextElementList3[index];
					z0ZzZzbdh z0ZzZzbdh12 = new z0ZzZzbdh(z0ZzZzbdh11.z0mek() - 30f, ((XTextElement)xTextTableRowElement2).z0ltk(), 20f, ((XTextElement)xTextTableRowElement3).z0ltk() + xTextTableRowElement3.Height - ((XTextElement)xTextTableRowElement2).z0ltk());
					if (z0ZzZzbdh12.z0tek(z0ZzZzvxj.z0nek()))
					{
						z0ZzZzvxj.z0gyk.z0eek(z0ZzZzudh, z0ZzZzbdh12.z0oek() + z0ZzZzbdh12.z0uek() / 2f, z0ZzZzbdh12.z0pek(), z0ZzZzbdh12.z0oek() + z0ZzZzbdh12.z0uek() / 2f, z0ZzZzbdh12.z0nek());
					}
					l += xTextTableRowElement2.z0uek() - 1;
				}
			}
			z0ZzZzudh.Dispose();
		}
		if (xTextContainerElement == this)
		{
			z0xek(z0ZzZzvxj);
		}
	}

	public void z0nek(int p0)
	{
	}

	public override void z0wi(string p0)
	{
	}

	internal void z0nek(z0ZzZzszj p0)
	{
		z0pek(p0);
	}

	public override void z0oe()
	{
		if (z0xu())
		{
			if (z0jr() != null)
			{
				z0jr().z0grk(this);
			}
			return;
		}
		((XTextElement)this).z0drk(p0: false);
		z0cek(p0: true);
		z0li();
		z0uek(delegate(XTextTableCellElement p0)
		{
			p0.z0gu();
			((XTextElement)p0).z0drk(p0: false);
		});
		z0jrk(p0: true);
		XTextDocument xTextDocument = z0jr();
		bool z0qzk = xTextDocument.z0qzk;
		xTextDocument.z0qzk = false;
		try
		{
			base.z0oe();
		}
		finally
		{
			xTextDocument.z0qzk = z0qzk;
		}
		z0jo();
		if (xTextDocument != null)
		{
			xTextDocument.z0krk();
			if (xTextDocument.z0yyk() != null && !xTextDocument.z0yyk().z0jyk())
			{
				xTextDocument.z0yyk().z0fpk();
				xTextDocument.z0yyk().z0vik();
				xTextDocument.z0yyk().z0ypk().z0hz();
			}
		}
	}

	public new string z0yrk()
	{
		return z0rtk;
	}

	public void z0yek(int p0, XTextElementList p1, bool p2, Dictionary<XTextTableCellElement, int> p3, bool p4)
	{
		if (p1 == null || p1.Count == 0)
		{
			throw new ArgumentNullException("newRows");
		}
		if (p0 < 0 || p0 > z0stk().Count)
		{
			throw new ArgumentOutOfRangeException(string.Format(z0ZzZziok.z0ryk(), "index", p0, z0stk().Count - 1, 0));
		}
		XTextElementList xTextElementList = z0stk();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement item = (XTextTableRowElement)z0bpk.Current;
				if (xTextElementList.Contains(item))
				{
					throw new ArgumentException(z0ZzZziok.z0yek());
				}
			}
		}
		z0ZzZzelh z0ZzZzelh = null;
		if (p2)
		{
			z0ZzZzelh = new z0ZzZzelh();
			z0ZzZzelh.z0eek(new z0ZzZzmzj(this));
		}
		bool flag = z0xu();
		XTextDocument xTextDocument = z0jr();
		xTextElementList.z0yrk(xTextElementList.Count + p1.Count);
		bool z0qzk = xTextDocument.z0qzk;
		xTextDocument.z0qzk = false;
		bool flag2 = XTextContentElement.z0ytk;
		XTextContentElement.z0ytk = false;
		XTextContainerElement.z0btk = false;
		try
		{
			for (int i = 0; i < p1.Count; i++)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)p1[i];
				xTextTableRowElement.z0yek(xTextDocument, this);
				xTextElementList.z0oek(p0 + i, xTextTableRowElement);
				if (flag)
				{
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextTableCellElement obj = (XTextTableCellElement)z0bpk.Current;
							obj.z0yek(xTextDocument, xTextTableRowElement);
							obj.z0gu();
						}
					}
					continue;
				}
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement obj2 = (XTextTableCellElement)z0bpk.Current;
					obj2.z0yek(xTextDocument, xTextTableRowElement);
					obj2.z0bek(p0: false);
					obj2.z0ct();
				}
			}
		}
		finally
		{
			XTextContainerElement.z0btk = true;
			xTextDocument.z0qzk = z0qzk;
			XTextContentElement.z0ytk = flag2;
		}
		z0jo();
		xTextDocument.z0zek(p1);
		if (xTextDocument.z0rik() != null)
		{
			xTextDocument.z0rik().z0ew(xTextDocument, this, p0, p1.Count);
		}
		((XTextElement)this).z0rrk();
		if (p3 != null && p3.Count > 0)
		{
			foreach (XTextTableCellElement key in p3.Keys)
			{
				int num = p3[key];
				if (key.RowSpan != num)
				{
					key.z0yek(num);
					((XTextElement)key).z0rrk();
				}
			}
		}
		else if (p4)
		{
			for (int j = 0; j < p0; j++)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((XTextTableRowElement)xTextElementList[j]).z0rek().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
					if (!xTextTableCellElement.z0bek() && xTextTableCellElement.RowSpan > 1 && xTextTableCellElement.z0pek() + xTextTableCellElement.RowSpan + 1 > p0)
					{
						int num2 = xTextTableCellElement.RowSpan + p1.Count;
						if (xTextTableCellElement.RowSpan != num2)
						{
							xTextTableCellElement.z0yek(num2);
							((XTextElement)xTextTableCellElement).z0rrk();
						}
					}
				}
			}
		}
		z0mtk = null;
		z0xek();
		try
		{
			XTextContainerElement.z0btk = false;
			XTextContentElement.z0ytk = false;
			z0ct();
			z0jy().z0bek(p0: true);
			z0qek().z0frk();
			XTextDocumentContentElement xTextDocumentContentElement = z0qek();
			xTextDocumentContentElement.z0ark();
			z0ri();
			z0jo();
			xTextDocument.Modified = true;
			z0mek(p0: true);
			XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)p1[0].z0be()[0];
			if (xTextTableCellElement2.z0bek())
			{
				xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
			}
			xTextDocumentContentElement.z0uek(xTextTableCellElement2.z0trk()[0].z0jrk(), 0);
		}
		finally
		{
			XTextContainerElement.z0btk = true;
			XTextContentElement.z0ytk = flag2;
		}
		z0ZzZzelh?.z0rek(new z0ZzZzmzj(this));
		if (p2 && xTextDocument.z0ytk())
		{
			xTextDocument.z0bek(z0ZzZzelh);
			xTextDocument.z0nuk();
			xTextDocument.OnSelectionChanged();
			xTextDocument.OnDocumentContentChanged();
		}
	}

	public override z0ZzZzhxj z0vt()
	{
		for (XTextElement xTextElement = z0rik.z0itk(); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is XTextTableElement)
			{
				if (xTextElement != this)
				{
					return null;
				}
				if (z0rik.z0xek().z0np(this))
				{
					return new z0mhj(this);
				}
			}
		}
		z0ZzZzhkh z0ZzZzhkh = z0rik.z0cuk();
		if (z0ZzZzhkh.z0yek() == ContentRangeMode.Cell)
		{
			bool flag = true;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzhkh.z0irk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					if (((XTextTableCellElement)z0bpk.Current).z0gr() != this)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				return new z0mhj(this);
			}
		}
		return null;
	}

	public void z0uek(Action<XTextTableCellElement> p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("handler");
		}
		if (base.z0ntk == null || base.z0ntk.Count == 0)
		{
			return;
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)base.z0ntk).z0krk();
		int count = base.z0ntk.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElementList xTextElementList = array[i].z0be();
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
				int count2 = xTextElementList.Count;
				for (int j = 0; j < count2; j++)
				{
					p0((XTextTableCellElement)array2[j]);
				}
			}
		}
	}

	public override string z0ge()
	{
		return "Table:" + ID;
	}

	public override XTextElement z0ie()
	{
		return this;
	}

	public new XTextTableCellElement z0urk()
	{
		XTextTableCellElement xTextTableCellElement = new XTextTableCellElement();
		xTextTableCellElement.z0yek(z0rik);
		return xTextTableCellElement;
	}

	public new int z0irk()
	{
		int num = 0;
		for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is XTextTableElement)
			{
				num++;
			}
		}
		return num;
	}

	public new int z0ork()
	{
		int num = 0;
		foreach (XTextTableRowElement item in z0stk().z0xrk())
		{
			num += item.z0xek();
		}
		return num;
	}

	public override float z0pt()
	{
		return z0ntk;
	}

	public XTextElementList z0pek(int p0, int p1, int p2, int p3)
	{
		if (p0 < 0 || p0 >= z0stk().Count)
		{
			throw new ArgumentOutOfRangeException("rowIndex1=" + p0);
		}
		if (p2 < 0 || p2 >= z0stk().Count)
		{
			throw new ArgumentOutOfRangeException("rowIndex2=" + p2);
		}
		if (p1 < 0 || p1 >= z0srk().Count)
		{
			throw new ArgumentOutOfRangeException("colIndex1=" + p1);
		}
		if (p3 < 0 || p3 >= z0srk().Count)
		{
			throw new ArgumentOutOfRangeException("colIndex2=" + p3);
		}
		XTextTableCellElement[] array = z0pek(Math.Min(p0, p2), Math.Min(p1, p3), Math.Abs(p0 - p2) + 1, Math.Abs(p1 - p3) + 1, p4: true);
		for (int i = 0; i < array.Length; i++)
		{
			XTextTableCellElement xTextTableCellElement = array[i];
			if (xTextTableCellElement.z0bek())
			{
				xTextTableCellElement = xTextTableCellElement.z0hrk();
			}
			p0 = Math.Min(p0, xTextTableCellElement.z0pek());
			p2 = Math.Max(p2, xTextTableCellElement.z0pek() + xTextTableCellElement.RowSpan - 1);
			p1 = Math.Min(p1, xTextTableCellElement.z0xek());
			p3 = Math.Max(p3, xTextTableCellElement.z0xek() + xTextTableCellElement.ColSpan - 1);
		}
		array = z0pek(p0, p1, p2 - p0 + 1, p3 - p1 + 1, p4: true);
		XTextElementList xTextElementList = new XTextElementList();
		XTextElement[] p4 = array;
		xTextElementList.z0zek(p4);
		return xTextElementList;
	}

	public new int z0prk()
	{
		return z0ptk;
	}

	public bool z0pek(int p0, int p1, z0ZzZzuxj p2, bool p3)
	{
		if (p0 < 0 || p0 >= z0stk().Count)
		{
			throw new ArgumentOutOfRangeException("startRowIndexBase0=" + p0);
		}
		if (p1 <= 1)
		{
			return false;
		}
		if (p2 == null)
		{
			throw new ArgumentNullException("comparer");
		}
		XTextElementList xTextElementList = new XTextElementList();
		((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)z0stk());
		z0stk().z0bek(p0, p1, new z0pnk(p2));
		bool flag = false;
		for (int i = 0; i < xTextElementList.Count; i++)
		{
			if (xTextElementList[i] != z0stk()[i])
			{
				flag = true;
				break;
			}
		}
		if (p3 && flag)
		{
			z0oek();
			z0oe();
		}
		return flag;
	}

	public new bool z0mrk()
	{
		return z0syk();
	}

	public override int z0ue(z0eok_jiejie20260327142557 p0)
	{
		int num = 0;
		foreach (XTextTableRowElement item in z0crk().z0xrk())
		{
			foreach (XTextTableCellElement item2 in item.z0rek().z0xrk())
			{
				if (item2.z0yi())
				{
					num += item2.z0ue(p0);
				}
			}
		}
		return num;
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0crk()).z0krk();
		int count = z0crk().Count;
		for (int i = 0; i < count; i++)
		{
			XTextTableRowElement obj = (XTextTableRowElement)array[i];
			if (p0.z0eek() > 0)
			{
				p0.z0tek();
			}
			XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)obj.z0rek()).z0krk();
			int count2 = obj.z0rek().Count;
			for (int j = 0; j < count2; j++)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array2[j];
				if (!xTextTableCellElement.z0bek())
				{
					int num = p0.z0eek();
					xTextTableCellElement.z0bw_jiejie20260327142557(p0);
					if (num == p0.z0eek())
					{
						p0.z0eek(' ');
					}
					p0.z0eek(' ');
				}
			}
		}
	}

	public void z0pek(DCTableAlignment p0)
	{
		z0kyk = p0;
	}

	internal void z0pek(z0ZzZzjpk p0)
	{
		z0ZzZzvxj z0ZzZzvxj = z0jr().z0bek(p0, (z0ZzZzcxj)0);
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0zek().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
			if (!xTextTableCellElement.z0bek() && xTextTableCellElement.z0ao())
			{
				z0ZzZzvxj.z0hyk = xTextTableCellElement;
				xTextTableCellElement.z0gu();
				xTextTableCellElement.z0mr(z0ZzZzvxj);
			}
		}
	}

	public new XTextTableRowElement z0nrk()
	{
		XTextTableRowElement xTextTableRowElement = new XTextTableRowElement();
		xTextTableRowElement.z0yek(z0rik, this);
		return xTextTableRowElement;
	}

	public new int z0brk()
	{
		if (base.z0ntk == null)
		{
			return 0;
		}
		return base.z0ntk.Count;
	}

	internal bool z0pek(z0ZzZzmzj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("tableInfo");
		}
		if (p0.z0yek() != this)
		{
			throw new ArgumentException("info 不属于该表格");
		}
		try
		{
			XTextContainerElement.z0btk = false;
			z0jo();
			p0.z0rek(this, p1: true);
			z0jo();
			z0jo();
			z0jy().z0bek(p0: true);
			z0qek().z0ark();
			z0mek(p0: false);
			z0qek().z0rek((z0ZzZzlkh)null);
			z0jr().Modified = true;
			if (p0.z0rek() >= 0)
			{
				z0qek().z0uek(p0.z0rek(), 0);
			}
			z0jr().OnSelectionChanged();
			z0jr().OnDocumentContentChanged();
		}
		finally
		{
			XTextContainerElement.z0btk = true;
		}
		return true;
	}

	private new static bool z0vrk()
	{
		return true;
	}

	public void z0iek(int p0, XTextElementList p1, XTextElementList p2, bool p3, Dictionary<XTextTableCellElement, int> p4, bool p5, Dictionary<XTextTableColumnElement, float> p6)
	{
		if (p0 < 0 || p0 > z0srk().Count)
		{
			throw new ArgumentOutOfRangeException(string.Format(z0ZzZziok.z0ryk(), "index", p0, z0srk().Count - 1, 0));
		}
		if (p1 == null || p1.Count == 0)
		{
			throw new ArgumentNullException("newColumns");
		}
		float num = 0f;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
				if (xTextTableColumnElement.z0yi())
				{
					num += xTextTableColumnElement.Width;
				}
			}
		}
		float minTableColumnWidth = z0iu().MinTableColumnWidth;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement2 = (XTextTableColumnElement)z0bpk.Current;
				if (z0srk().Contains(xTextTableColumnElement2))
				{
					throw new ArgumentException("col existed in table");
				}
				if (xTextTableColumnElement2.Width < minTableColumnWidth)
				{
					xTextTableColumnElement2.Width = minTableColumnWidth;
				}
				xTextTableColumnElement2.z0yek(z0rik, this);
			}
		}
		z0ZzZzelh z0ZzZzelh = null;
		if (p3)
		{
			z0ZzZzelh = new z0ZzZzelh();
			z0ZzZzelh.z0eek(new z0ZzZzmzj(this));
		}
		XTextElementList xTextElementList = new XTextElementList();
		z0cek(p0: true);
		z0srk().z0yek(p0, p1);
		if (z0jr().z0rik() != null)
		{
			z0jr().z0rik().z0ww(z0jr(), this, p0, p1.Count);
		}
		((XTextElement)this).z0rrk();
		if (p2 != null && p2.Count == z0stk().Count * p1.Count)
		{
			for (int i = 0; i < z0stk().Count; i++)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0stk()[i];
				for (int j = 0; j < p1.Count; j++)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)p2[i * p1.Count + j];
					xTextTableCellElement.z0yek(z0rik, xTextTableRowElement);
					xTextTableCellElement.z0gu();
					xTextTableRowElement.z0rek().Insert(p0 + j, xTextTableCellElement);
					xTextElementList.Add(xTextTableCellElement);
				}
			}
		}
		else
		{
			using z0ZzZzjpk p7 = z0ru();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)z0bpk.Current;
				XTextTableCellElement xTextTableCellElement2 = null;
				xTextTableCellElement2 = ((p0 != 0) ? ((XTextTableCellElement)xTextTableRowElement2.z0rek()[p0 - 1]) : ((XTextTableCellElement)xTextTableRowElement2.z0rek()[p0]));
				if (xTextTableCellElement2.z0bek())
				{
					xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
				}
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = p1.z0ltk();
				while (z0bpk2.MoveNext())
				{
					_ = (XTextTableColumnElement)z0bpk2.Current;
					XTextTableCellElement xTextTableCellElement3 = null;
					if (xTextTableCellElement2 != null)
					{
						xTextTableCellElement3 = xTextTableCellElement2.z0srk();
						xTextTableCellElement3.z0tek(1);
					}
					else
					{
						xTextTableCellElement3 = z0urk();
						XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
						xTextParagraphFlagElement.z0rek(p0: true);
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk3 = xTextTableCellElement2.z0be().z0ltk())
						{
							while (z0bpk3.MoveNext())
							{
								XTextElement current = z0bpk3.Current;
								if (current is XTextParagraphFlagElement)
								{
									xTextParagraphFlagElement.z0oek(current.z0pek());
									break;
								}
							}
						}
						xTextTableCellElement3.z0be().Clear();
						xTextParagraphFlagElement.z0yek(z0rik, xTextTableCellElement3);
						xTextTableCellElement3.z0be().Add(xTextParagraphFlagElement);
						xTextTableCellElement3.z0gu();
					}
					xTextTableCellElement3.z0yek(z0rik, xTextTableRowElement2);
					xTextTableCellElement3.z0buk = xTextTableCellElement2.z0buk;
					xTextTableRowElement2.z0rek().Insert(p0, xTextTableCellElement3);
					xTextElementList.Add(xTextTableCellElement3);
					z0ZzZzvxj z0ZzZzvxj = z0jr().z0bek(p7, (z0ZzZzcxj)0);
					z0ZzZzvxj.z0hyk = xTextTableCellElement3;
					xTextTableCellElement3.z0mr(z0ZzZzvxj);
				}
			}
		}
		if (p4 != null && p4.Count > 0)
		{
			foreach (XTextTableCellElement key in p4.Keys)
			{
				key.z0tek(p4[key]);
			}
		}
		else
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0gtk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement4 = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement4.ColSpan > 1 && xTextTableCellElement4.z0xek() + xTextTableCellElement4.ColSpan - 1 > p0 && xTextTableCellElement4.z0xek() < p0)
				{
					int p8 = xTextTableCellElement4.ColSpan + p1.Count;
					xTextTableCellElement4.z0tek(p8);
				}
			}
		}
		if (p6 != null && p6.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement3 = (XTextTableColumnElement)z0bpk.Current;
				if (p6.ContainsKey(xTextTableColumnElement3))
				{
					xTextTableColumnElement3.Width = p6[xTextTableColumnElement3];
				}
			}
		}
		else if (p5)
		{
			float num2 = 0f;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableColumnElement xTextTableColumnElement4 = (XTextTableColumnElement)z0bpk.Current;
					num2 += xTextTableColumnElement4.Width;
				}
			}
			float num3 = num / num2;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk();
			while (z0bpk.MoveNext())
			{
				((XTextTableColumnElement)z0bpk.Current).Width *= num3;
			}
		}
		if (xTextElementList.Count > 0)
		{
			z0jr().z0zek(xTextElementList);
		}
		float height = Height;
		try
		{
			XTextContainerElement.z0btk = false;
			z0mtk = null;
			z0ct();
			z0jy().z0bek(p0: true);
			z0qek().z0ark();
			z0ri();
			z0jo();
			z0jr().Modified = true;
			z0mek(height != Height);
		}
		finally
		{
			XTextContainerElement.z0btk = true;
		}
		XTextTableCellElement xTextTableCellElement5 = z0nek(0, p0, p2: false);
		if (xTextTableCellElement5.z0bek())
		{
			xTextTableCellElement5 = xTextTableCellElement5.z0hrk();
		}
		z0qek().z0frk();
		z0qek().z0uek(xTextTableCellElement5.z0trk()[0].z0jrk(), 0);
		if (p3 && z0jr().z0ytk())
		{
			z0ZzZzelh.z0rek(new z0ZzZzmzj(this));
			z0jr().z0bek(z0ZzZzelh);
			z0jr().z0nuk();
			z0jr().OnSelectionChanged();
			z0jr().OnDocumentContentChanged();
		}
	}

	public override void z0ye(ElementEventArgs p0)
	{
		z0jo();
		base.z0ye(p0);
	}

	private Color z0pek(bool p0, Color p1)
	{
		if (p0)
		{
			if (p1.A == 0 || p1.ToArgb() == z0ztk)
			{
				return p1;
			}
			return Color.Black;
		}
		return p1;
	}

	public override void z0te(XTextElementList p0)
	{
		base.z0te(p0);
	}

	internal override void z0re()
	{
		XTextDocument p = z0rik;
		if (z0itk != null)
		{
			for (int num = z0itk.Count - 1; num >= 0; num--)
			{
				XTextTableColumnElement obj = (XTextTableColumnElement)z0itk[num];
				obj.z0muk = num;
				obj.z0yek(p, this);
			}
		}
		if (base.z0ntk == null)
		{
			return;
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)base.z0ntk).z0krk();
		for (int num2 = base.z0ntk.Count - 1; num2 >= 0; num2--)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)array[num2];
			xTextTableRowElement.z0yek(p, this);
			xTextTableRowElement.z0muk = num2;
			if (xTextTableRowElement.z0ntk != null)
			{
				XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement.z0ntk).z0krk();
				for (int num3 = xTextTableRowElement.z0ntk.Count - 1; num3 >= 0; num3--)
				{
					XTextTableCellElement obj2 = (XTextTableCellElement)array2[num3];
					obj2.z0nrk = num2;
					obj2.z0muk = num3;
					obj2.z0yek(p, xTextTableRowElement);
					obj2.z0re();
				}
			}
		}
	}

	public XTextTableCellElement[] z0pek(int p0, int p1, int p2, int p3, bool p4)
	{
		if (p2 < 0 || p3 < 0)
		{
			return null;
		}
		int num = p0 + p2 - 1;
		int num2 = p1 + p3 - 1;
		if (p0 < 0)
		{
			p0 = 0;
		}
		if (p1 < 0)
		{
			p1 = 0;
		}
		XTextElementList xTextElementList = z0stk();
		if (p0 >= xTextElementList.Count || p1 >= z0srk().Count)
		{
			return null;
		}
		if (num >= xTextElementList.Count)
		{
			num = xTextElementList.Count - 1;
		}
		if (num2 >= z0srk().Count)
		{
			num2 = z0srk().Count - 1;
		}
		XTextTableCellElement[] array = new XTextTableCellElement[p2 * p3];
		int num3 = 0;
		for (int i = p0; i <= num; i++)
		{
			XTextElementList xTextElementList2 = ((XTextTableRowElement)xTextElementList[i]).z0rek();
			int count = xTextElementList2.Count;
			for (int j = p1; j <= num2 && j < count; j++)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElementList2[j];
				if (p4 || !xTextTableCellElement.z0bek())
				{
					array[num3++] = xTextTableCellElement;
				}
			}
		}
		if (num3 < array.Length)
		{
			XTextTableCellElement[] array2 = new XTextTableCellElement[num3];
			Array.Copy(array, 0, array2, 0, array2.Length);
			array = array2;
		}
		return array;
	}

	public void z0mek(XTextElementList p0)
	{
		z0itk = p0;
	}

	public new XTextElementList z0crk()
	{
		if (z0rik == null)
		{
			return z0stk();
		}
		if (z0mtk == null)
		{
			z0mtk = z0stk();
			bool p = false;
			z0ZzZzmcj z0ZzZzmcj = z0rik.z0qtk();
			if (z0ZzZzmcj.Printing || z0ZzZzmcj.PrintPreviewing || z0ZzZzmcj.RenderMode == DocumentRenderMode.Print || z0ZzZzmcj.RenderMode == DocumentRenderMode.Print || z0ZzZzmcj.RenderMode == DocumentRenderMode.PDF)
			{
				p = true;
			}
			else if (XTextSectionElement.z0eek(this))
			{
				p = true;
			}
			int count = z0stk().Count;
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0stk()).z0krk();
			for (int num = count - 1; num >= 0; num--)
			{
				if (!((XTextTableRowElement)array[num]).z0hek(p))
				{
					z0mtk = new XTextElementList(count);
					for (int i = 0; i < count; i++)
					{
						XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)array[i];
						if (xTextTableRowElement.z0hek(p))
						{
							((zzz.z0ZzZzkuk<XTextElement>)z0mtk).z0mek((XTextElement)xTextTableRowElement);
						}
					}
					break;
				}
			}
		}
		return z0mtk;
	}

	public XTextTableCellElement z0nek(int p0, int p1, bool p2)
	{
		XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0stk().SafeGet(p0);
		if (xTextTableRowElement != null)
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.z0rek().SafeGet(p1);
			if (xTextTableCellElement != null)
			{
				return xTextTableCellElement;
			}
		}
		if (p2)
		{
			throw new Exception("Bad RowIndex=" + p0 + ", ColIndex=" + p1);
		}
		return null;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0rtk = null;
		if (z0etk != null)
		{
			z0etk.Clear();
			z0etk = null;
		}
		if (z0itk != null)
		{
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0itk.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					((XTextTableColumnElement)z0bpk.Current).Dispose();
				}
			}
			z0itk.Clear();
			z0itk = null;
		}
		if (z0mtk != null)
		{
			z0mtk.Clear();
			z0mtk = null;
		}
	}

	public bool z0oek(int p0, int p1, bool p2, Dictionary<XTextTableCellElement, int> p3)
	{
		if (p0 < 0 || p0 > z0stk().Count)
		{
			throw new ArgumentOutOfRangeException("startRowIndex=" + p0);
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException(string.Format(z0ZzZziok.z0ryk(), "rowsCount", p1, z0stk().Count - 1, 0));
		}
		if (p0 + p1 > z0stk().Count)
		{
			throw new ArgumentOutOfRangeException(string.Format(z0ZzZziok.z0ryk(), "startRowIndex + rowsCount", p0 + p1, z0stk().Count - 1, 0));
		}
		z0ZzZzelh z0ZzZzelh = null;
		if (p2)
		{
			z0ZzZzelh = new z0ZzZzelh();
			z0ZzZzelh.z0eek(new z0ZzZzmzj(this));
		}
		z0jo();
		if (z0jr().z0htk() != null)
		{
			for (int i = 0; i < p1; i++)
			{
				z0jr().z0htk().z0qp(z0stk()[p0 + i]);
			}
		}
		z0stk().z0irk(p0, p1);
		if (z0jr().z0rik() != null)
		{
			z0jr().z0rik().z0ew(z0jr(), this, p0, -p1);
		}
		((XTextElement)this).z0rrk();
		if (p3 != null && p3.Count > 0)
		{
			foreach (XTextTableCellElement key in p3.Keys)
			{
				key.z0yek(p3[key]);
			}
		}
		else
		{
			for (int j = 0; j < p0; j++)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((XTextTableRowElement)z0stk()[j]).z0rek().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
					if (!xTextTableCellElement.z0bek() && xTextTableCellElement.RowSpan > 1 && xTextTableCellElement.z0pek() + xTextTableCellElement.RowSpan + 1 > p0)
					{
						int num = xTextTableCellElement.RowSpan - p1;
						if (num < p0 - j)
						{
							num = p0 - j;
						}
						xTextTableCellElement.z0yek(num);
					}
				}
			}
		}
		try
		{
			XTextContainerElement.z0btk = false;
			z0mtk = null;
			z0ct();
			z0jo();
			z0jr().Modified = true;
			z0jy().z0bek(p0: true);
			z0qek().z0ark();
			z0mek(p0: true);
		}
		finally
		{
			XTextContainerElement.z0btk = true;
		}
		if (p0 > z0stk().Count)
		{
			p0 = z0stk().Count - 1;
		}
		XTextTableCellElement xTextTableCellElement2 = z0nek(Math.Max(0, p0 - 1), 0, p2: false);
		if (xTextTableCellElement2.z0bek())
		{
			xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
		}
		z0qek().z0frk().z0tek(p0: false);
		z0qek().z0uek(xTextTableCellElement2.z0trk()[0].z0jrk(), 0);
		z0ZzZzelh?.z0rek(new z0ZzZzmzj(this));
		if (p2 && z0jr().z0ytk())
		{
			z0jr().z0bek(z0ZzZzelh);
			z0jr().z0nuk();
			z0jr().OnSelectionChanged();
			z0jr().OnDocumentContentChanged();
		}
		return true;
	}

	public new bool z0xrk()
	{
		return z0iyk();
	}

	public new XTextTableCellElement z0zrk()
	{
		if (z0stk().Count > 0)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0stk()[0];
			if (xTextTableRowElement.z0rek().Count > 0)
			{
				return (XTextTableCellElement)xTextTableRowElement.z0rek()[0];
			}
		}
		return null;
	}

	public override XTextDocument z0ee_jiejie20260327142557(bool p0)
	{
		return base.z0ee_jiejie20260327142557(p0: true);
	}

	public override void z0sr()
	{
		XTextTableCellElement xTextTableCellElement = z0zrk();
		if (xTextTableCellElement == null)
		{
			return;
		}
		if (xTextTableCellElement.z0hrk() != null)
		{
			xTextTableCellElement = xTextTableCellElement.z0hrk();
		}
		XTextElement xTextElement = xTextTableCellElement.z0trk().z0krk();
		if (xTextElement != null)
		{
			XTextDocumentContentElement xTextDocumentContentElement = z0qek();
			if (z0jr().z0jrk() != xTextDocumentContentElement)
			{
				xTextDocumentContentElement.z0sr();
			}
			xTextDocumentContentElement.z0uek(xTextElement.z0jrk(), 0);
			if (z0jr().z0yyk() != null)
			{
				z0jr().z0yyk().z0syk();
			}
		}
	}

	internal void z0mek(bool p0, bool p1 = false)
	{
		z0wtk = false;
		float num = z0aek().z0ryk;
		float num2 = 0f;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
				xTextTableColumnElement.z0ot(num);
				if (xTextTableColumnElement.z0yi())
				{
					num += xTextTableColumnElement.Width;
					num2 += xTextTableColumnElement.Width;
				}
			}
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0stk()).z0krk();
		for (int num3 = z0stk().Count - 1; num3 >= 0; num3--)
		{
			XTextTableRowElement obj = (XTextTableRowElement)array[num3];
			obj.z0rrk_jiejie20260327142557 = -1f;
			obj.z0fik = num2;
		}
		XTextElementList xTextElementList = z0crk();
		int count = xTextElementList.Count;
		XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		z0jr().z0gnk().z0uek();
		z0ZzZzazj z0ZzZzazj = new z0ZzZzazj(null, null, z0aek().z0srk);
		z0ZzZzazj.z0eek(p0: true);
		XTextElementList xTextElementList2 = z0srk();
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array2[i];
			xTextElement.z0nrk(p0: false);
			XTextElement[] array3 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElement.z0be()).z0krk();
			int count2 = xTextElement.z0be().Count;
			for (int j = 0; j < count2; j++)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array3[j];
				if (!xTextTableCellElement.z0bek() && xTextTableCellElement.RowSpan > 1)
				{
					xTextElement.z0nrk(p0: true);
				}
				int num4 = xTextTableCellElement.z0xek();
				xTextTableCellElement.z0gu();
				if (xTextTableCellElement.z0yi())
				{
					float num5 = 0f;
					if (xTextTableCellElement.ColSpan == 1)
					{
						num5 = xTextElementList2[num4].Width;
					}
					else
					{
						for (int k = 0; k < xTextTableCellElement.ColSpan; k++)
						{
							XTextElement xTextElement2 = xTextElementList2[num4 + k];
							if (xTextElement2.z0yi())
							{
								num5 += xTextElement2.Width;
							}
						}
					}
					if (xTextTableCellElement.Width != num5 || xTextTableCellElement.z0ao() || ((XTextContentElement)xTextTableCellElement).z0jrk())
					{
						xTextTableCellElement.Width = num5;
						if (p0)
						{
							xTextTableCellElement.z0rek(p0: true, z0ZzZzazj);
						}
					}
					float num6 = 0f;
					int num7 = xTextTableCellElement.z0iek();
					if (num7 == 1)
					{
						num6 = xTextTableCellElement.z0krk().Height;
					}
					else
					{
						for (int l = 0; l < num7; l++)
						{
							num6 += z0stk()[xTextTableCellElement.z0pek() + l].Height;
						}
					}
					if (p1)
					{
						VerticalAlignStyle p2 = xTextTableCellElement.z0cr();
						xTextTableCellElement.z0eek(p2, p1: false, p2: false);
					}
					else
					{
						if (!p0 || (xTextTableCellElement.Height != 0f && xTextTableCellElement.Height == num6 && !xTextTableCellElement.z0ao()))
						{
							continue;
						}
						VerticalAlignStyle verticalAlignStyle = xTextTableCellElement.z0cr();
						if (verticalAlignStyle != VerticalAlignStyle.Top)
						{
							if (((XTextContentElement)xTextTableCellElement).z0qrk())
							{
								xTextTableCellElement.z0iek(p0: false);
								z0wtk = true;
							}
							xTextTableCellElement.z0eek(verticalAlignStyle, p1: false, p2: false);
						}
					}
				}
				else
				{
					xTextTableCellElement.z0ot(xTextTableCellElement.z0drk().z0it());
					xTextTableCellElement.z0nt(0f);
					xTextTableCellElement.Width = xTextTableCellElement.z0drk().Width;
					xTextTableCellElement.Height = xTextTableCellElement.z0krk().Height;
				}
			}
		}
		z0ZzZzazj.z0tek();
		z0ZzZzazj = null;
		zzz.z0ZzZzguk<z0ZzZzzlh>.z0iek(0);
		XTextElementList xTextElementList3 = z0stk();
		for (int m = 0; m < count; m++)
		{
			((XTextTableRowElement)array2[m]).z0hrk();
		}
		for (int n = 0; n < count; n++)
		{
			XTextElement obj2 = array2[n];
			XTextElement[] array4 = ((zzz.z0ZzZzkuk<XTextElement>)obj2.z0be()).z0krk();
			int count3 = obj2.z0be().Count;
			for (int num8 = 0; num8 < count3; num8++)
			{
				XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)array4[num8];
				if (xTextTableCellElement2.z0bek() || xTextTableCellElement2.RowSpan <= 1)
				{
					continue;
				}
				float num9 = 0f;
				for (int num10 = 0; num10 < xTextTableCellElement2.RowSpan; num10++)
				{
					num9 += xTextElementList3[num10 + xTextTableCellElement2.z0nrk].Height;
				}
				z0ZzZzrzj z0ZzZzrzj = xTextTableCellElement2.z0krk().z0aek();
				float num11 = ((XTextContentElement)xTextTableCellElement2).z0hrk() + z0ZzZzrzj.z0quk + z0ZzZzrzj.z0xrk;
				if (num11 > num9)
				{
					for (int num12 = xTextTableCellElement2.RowSpan - 1; num12 >= 0; num12--)
					{
						XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList3[num12 + xTextTableCellElement2.z0nrk];
						if (xTextTableRowElement.z0cek() >= 0f)
						{
							xTextTableRowElement.Height = xTextTableRowElement.Height + num11 - num9;
							break;
						}
					}
				}
				else
				{
					xTextTableCellElement2.Height = num9;
				}
			}
		}
		z0ZzZzrzj z0ZzZzrzj2 = z0aek();
		bool flag = false;
		z0ZzZzzej z0qxk = z0jr().z0qxk;
		if (z0qxk != null && z0qxk.z0cek())
		{
			flag = true;
		}
		float num13 = (flag ? 0f : z0ZzZzrzj2.z0quk);
		for (int num14 = 0; num14 < count; num14++)
		{
			XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)array2[num14];
			xTextTableRowElement2.z0xik = z0ZzZzrzj2.z0ryk;
			xTextTableRowElement2.z0wik = num13;
			num13 += xTextTableRowElement2.Height;
			int count4 = xTextTableRowElement2.z0rek().Count;
			XTextElement[] array5 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement2.z0rek()).z0krk();
			for (int num15 = 0; num15 < count4; num15++)
			{
				XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)array5[num15];
				if (xTextTableCellElement3.z0uik != xTextTableRowElement2)
				{
					xTextTableCellElement3.z0iek(xTextTableRowElement2);
				}
				xTextTableCellElement3.z0xik = xTextTableCellElement3.z0drk().z0it();
				xTextTableCellElement3.z0wik = 0f;
				((XTextContentElement)xTextTableCellElement3).z0lrk();
				if (xTextTableCellElement3.RowSpan == 1 || xTextTableCellElement3.z0bek())
				{
					xTextTableCellElement3.Height = xTextTableRowElement2.Height;
				}
				else
				{
					float num16 = 0f;
					int num17 = xTextElementList3.z0oek(xTextTableRowElement2, xTextTableRowElement2.z0grk());
					for (int num18 = 0; num18 < xTextTableCellElement3.RowSpan; num18++)
					{
						num16 += xTextElementList3[num17 + num18].Height;
					}
					xTextTableCellElement3.Height = num16;
				}
				if (xTextTableCellElement3.AutoFixFontSizeMode == ContentAutoFixFontSizeMode.MultiLine || xTextTableCellElement3.AutoFixFontSizeMode == ContentAutoFixFontSizeMode.SingleLine)
				{
					xTextTableCellElement3.z0tek();
				}
				VerticalAlignStyle verticalAlignStyle2 = xTextTableCellElement3.z0aek().z0srk;
				if (verticalAlignStyle2 != VerticalAlignStyle.Top && xTextTableCellElement3.Height > 0f)
				{
					if (((XTextContentElement)xTextTableCellElement3).z0qrk())
					{
						xTextTableCellElement3.z0iek(p0: false);
						z0wtk = true;
					}
					xTextTableCellElement3.z0eek(verticalAlignStyle2, p1: false, p2: false);
				}
				xTextTableCellElement3.z0htk();
			}
		}
		if (flag)
		{
			Height = num13;
		}
		else
		{
			Height = num13 + z0ZzZzrzj2.z0quk + z0ZzZzrzj2.z0xrk;
		}
		Width = num2 + z0ZzZzrzj2.z0ryk + z0ZzZzrzj2.z0ptk;
	}

	public new XTextTableCellElement z0ltk()
	{
		if (z0stk().Count > 0)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0stk().LastElement;
			if (xTextTableRowElement.z0rek().Count > 0)
			{
				return (XTextTableCellElement)xTextTableRowElement.z0rek().LastElement;
			}
		}
		return null;
	}

	public new bool z0ktk()
	{
		return AllowUserInsertRow;
	}

	public void z0pek(TableSubfieldMode p0)
	{
		z0lyk = p0;
	}

	public new XTextElement[] z0jtk()
	{
		XTextElementList xTextElementList = z0crk();
		int count = xTextElementList.Count;
		for (int i = 0; i < count; i++)
		{
			if (!((XTextTableRowElement)xTextElementList[i]).HeaderStyle)
			{
				if (i > 0)
				{
					return xTextElementList.z0wrk(0, i);
				}
				return null;
			}
		}
		return null;
	}

	public new float z0htk()
	{
		float num = 0f;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
			if (xTextTableColumnElement.z0yi())
			{
				num += xTextTableColumnElement.Width;
			}
		}
		return num;
	}

	internal override void z0we()
	{
		base.z0ytk = null;
		base.z0cek(p0: false);
	}

	public new XTextElementList z0gtk()
	{
		XTextElementList xTextElementList = new XTextElementList();
		foreach (XTextTableRowElement item in z0crk().z0xrk())
		{
			if (!item.z0yi())
			{
				continue;
			}
			foreach (XTextTableCellElement item2 in item.z0rek().z0xrk())
			{
				if (item2.z0yi())
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)item2);
				}
			}
		}
		return xTextElementList;
	}

	public override void z0tt(z0ZzZzvxj p0)
	{
		if (p0.z0byk == (z0ZzZzcxj)3 && p0.z0ztk != null && !p0.z0ztk.z0vlk())
		{
			z0pek(p0, p1: false, p2: false, p3: true);
		}
		else
		{
			z0pek(p0, p1: true, p2: true, p3: true);
		}
	}

	public void z0bek(int p0)
	{
	}

	public new bool z0ftk()
	{
		return AllowUserDeleteRow;
	}

	public new DCBooleanValue z0dtk()
	{
		return z0vtk;
	}

	public override bool z0qe(XTextElement p0)
	{
		if (p0 is XTextTableRowElement)
		{
			return base.z0qe(p0);
		}
		if (p0 is XTextTableColumnElement && z0itk != null)
		{
			if (z0itk.z0pek(p0.z0muk, p0))
			{
				return true;
			}
			return z0itk.Contains(p0);
		}
		return false;
	}

	internal override bool z0ae()
	{
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0crk()).z0krk();
		for (int num = z0crk().Count - 1; num >= 0; num--)
		{
			if (((XTextTableRowElement)array[num]).z0ae())
			{
				return true;
			}
		}
		return base.z0ae();
	}

	public new XTextElementList z0stk()
	{
		return base.z0ntk;
	}

	public new bool z0atk()
	{
		if (!z0vrk())
		{
			return false;
		}
		foreach (XTextTableRowElement item in z0crk().z0xrk())
		{
			if (item.HeaderStyle)
			{
				return true;
			}
		}
		return false;
	}

	public new int z0cek(bool p0 = true)
	{
		int num = 0;
		int num2 = 0;
		bool flag = false;
		XTextElementList xTextElementList = z0srk();
		foreach (XTextTableRowElement item in z0stk().z0xrk())
		{
			XTextElementList xTextElementList2 = item.z0rek();
			if (num2 < xTextElementList2.Count)
			{
				num2 = xTextElementList2.Count;
			}
			if (xTextElementList2.Count <= xTextElementList.Count)
			{
				continue;
			}
			for (int i = xTextElementList.Count; i < xTextElementList2.Count; i++)
			{
				XTextTableColumnElement xTextTableColumnElement = z0vek();
				xTextTableColumnElement.Width = xTextElementList2[i].Width;
				if (xTextTableColumnElement.Width == 0f)
				{
					if (xTextElementList.Count == 0)
					{
						xTextTableColumnElement.Width = 100f;
					}
					else
					{
						xTextTableColumnElement.Width = xTextElementList.LastElement.Width;
					}
				}
				xTextTableColumnElement.z0iek(this);
				xTextElementList.Add(xTextTableColumnElement);
				flag = true;
			}
		}
		if (xTextElementList.Count > num2)
		{
			xTextElementList.z0vek(num2);
		}
		z0ZzZzryk z0ZzZzryk = new z0ZzZzryk();
		foreach (XTextTableRowElement item2 in z0be().z0xrk())
		{
			XTextElementList xTextElementList3 = item2.z0rek();
			if (xTextElementList3.Count == xTextElementList.Count)
			{
				continue;
			}
			xTextElementList3.z0vek(xTextElementList.Count);
			if (xTextElementList3.Count >= xTextElementList.Count)
			{
				continue;
			}
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElementList3.LastElement;
			for (int j = xTextElementList3.Count; j < xTextElementList.Count; j++)
			{
				XTextTableCellElement xTextTableCellElement2 = null;
				xTextTableCellElement2 = ((xTextTableCellElement != null) ? ((XTextTableCellElement)xTextTableCellElement.z0lr(p0: false)) : z0urk());
				num++;
				xTextElementList3.Add(xTextTableCellElement2);
				xTextTableCellElement2.z0iek(item2);
				xTextTableCellElement2.z0rek((XTextTableColumnElement)xTextElementList[xTextElementList3.Count - 1]);
				z0ZzZzryk.z0yek(item2.z0tr() + 1);
				z0ZzZzryk.z0tek(j + 1);
				if (p0)
				{
					xTextTableCellElement2.z0li();
				}
				flag = true;
			}
		}
		z0xek();
		return num;
	}

	internal override void z0se()
	{
		base.z0se();
		if (z0itk == null)
		{
			return;
		}
		foreach (XTextElement item in z0itk.z0xrk())
		{
			item.z0ruk = null;
		}
	}

	public override XTextElement z0xt()
	{
		return z0erk()?.z0xt();
	}

	public bool z0pek(TableSubfieldMode p0, int p1, bool p2)
	{
		if (p1 <= 1 || p0 == TableSubfieldMode.None || z0stk().Count == 0 || z0srk().Count == 0)
		{
			return false;
		}
		z0li();
		z0cek(p0: true);
		List<XTextTableRowElement> list = new List<XTextTableRowElement>();
		List<XTextTableRowElement> list2 = new List<XTextTableRowElement>();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
				if (xTextTableRowElement.z0pek())
				{
					list.Add(xTextTableRowElement);
				}
				else
				{
					list2.Add(xTextTableRowElement);
				}
			}
		}
		int num = (int)Math.Ceiling((double)list2.Count / (double)p1);
		XTextElementList xTextElementList = new XTextElementList();
		for (int i = 0; i < p1; i++)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0srk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
				xTextElementList.Add((XTextTableColumnElement)xTextTableColumnElement.z0lr(p0: false));
			}
		}
		List<XTextTableRowElement> list3 = new List<XTextTableRowElement>();
		if (list.Count > 0)
		{
			foreach (XTextTableRowElement item in list)
			{
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)item.z0lr(p0: false);
				list3.Add(xTextTableRowElement2);
				for (int j = 0; j < p1; j++)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = item.z0rek().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement element = (XTextTableCellElement)((XTextTableCellElement)z0bpk.Current).z0lr(p0: true);
						xTextTableRowElement2.z0rek().Add(element);
					}
				}
			}
		}
		List<XTextTableRowElement> list4 = new List<XTextTableRowElement>();
		if (list2.Count > 0)
		{
			switch (p0)
			{
			case TableSubfieldMode.LeftRightAndUpDown:
			{
				XTextTableRowElement xTextTableRowElement5 = null;
				int num3 = z0srk().Count * p1;
				foreach (XTextTableRowElement item2 in list2)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = item2.z0rek().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement element2 = (XTextTableCellElement)z0bpk.Current;
						if (xTextTableRowElement5 == null || xTextTableRowElement5.z0rek().Count == num3)
						{
							xTextTableRowElement5 = (XTextTableRowElement)item2.z0lr(p0: false);
							list4.Add(xTextTableRowElement5);
						}
						xTextTableRowElement5.z0rek().Add(element2);
					}
				}
				break;
			}
			case TableSubfieldMode.UpDownAndLeftRight:
			{
				for (int k = 0; k < num; k++)
				{
					XTextTableRowElement xTextTableRowElement3 = list2[k];
					list4.Add(xTextTableRowElement3);
					for (int l = k + num; l < list2.Count; l += num)
					{
						XTextTableRowElement xTextTableRowElement4 = list2[l];
						((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement3.z0rek()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement4.z0rek());
						xTextTableRowElement4.z0rek().Clear();
					}
				}
				for (int num2 = list2.Count - 1; num2 >= 0; num2--)
				{
					if (list2[num2].z0rek().Count == 0)
					{
						list2.RemoveAt(num2);
					}
				}
				break;
			}
			}
			z0stk().Clear();
			foreach (XTextTableRowElement item3 in list3)
			{
				item3.z0cek((object)null);
				item3.z0hrk(p0: false);
				item3.ValueBinding = null;
				z0stk().Add(item3);
			}
			foreach (XTextTableRowElement item4 in list4)
			{
				item4.z0cek((object)null);
				item4.z0hrk(p0: false);
				item4.ValueBinding = null;
				z0stk().Add(item4);
			}
		}
		z0srk().Clear();
		((zzz.z0ZzZzkuk<XTextElement>)z0srk()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList);
		z0mtk = null;
		z0li();
		z0cek(p0: true);
		if (p2)
		{
			z0oe();
		}
		return true;
	}

	public override bool z0de()
	{
		z0ZzZzhkh z0ZzZzhkh = z0qek()?.z0oek();
		if (z0ZzZzhkh == null)
		{
			return false;
		}
		if (z0ZzZzhkh.z0irk() != null && z0ZzZzhkh.z0irk().Count > 0)
		{
			foreach (XTextTableCellElement item in z0ZzZzhkh.z0irk().z0xrk())
			{
				if (item.z0gr() == this)
				{
					return true;
				}
			}
		}
		XTextTableCellElement xTextTableCellElement = z0trk();
		XTextTableCellElement xTextTableCellElement2 = z0erk();
		XTextElement xTextElement = xTextTableCellElement?.z0ie();
		XTextElement xTextElement2 = xTextTableCellElement2?.z0dek();
		if (xTextElement == null || xTextElement2 == null)
		{
			return false;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement != null && xTextDocumentContentElement.z0oek() != null)
		{
			int num = xTextDocumentContentElement.z0oek().z0lrk();
			int num2 = xTextDocumentContentElement.z0oek().z0drk();
			if (xTextElement.z0jrk() <= num2 && xTextElement2.z0jrk() >= num)
			{
				return true;
			}
		}
		return false;
	}

	public override XTextElement z0hy()
	{
		return z0zrk()?.z0hy();
	}

	public new void z0xek(bool p0)
	{
		z0cek(p0);
	}

	public new float z0qtk()
	{
		return z0btk;
	}

	public override XTextElement z0fe(int p0)
	{
		if (z0itk != null && z0itk.Count > 0)
		{
			XTextElement xTextElement = z0itk.z0lrk(p0);
			if (xTextElement != null)
			{
				return xTextElement;
			}
		}
		if (base.z0ntk != null && base.z0ntk.Count > 0)
		{
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)base.z0ntk).z0krk();
			for (int num = base.z0ntk.Count - 1; num >= 0; num--)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)array[num];
				if (xTextTableRowElement.GetHashCode() == p0)
				{
					return xTextTableRowElement;
				}
				if (xTextTableRowElement.z0ntk != null)
				{
					XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement.z0ntk).z0krk();
					for (int num2 = xTextTableRowElement.z0ntk.Count - 1; num2 >= 0; num2--)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array2[num2];
						if (xTextTableCellElement.GetHashCode() == p0)
						{
							return xTextTableCellElement;
						}
						XTextElement xTextElement2 = xTextTableCellElement.z0fe(p0);
						if (xTextElement2 != null)
						{
							return xTextElement2;
						}
					}
				}
			}
		}
		return null;
	}
}
