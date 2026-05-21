using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

[DebuggerDisplay("StartIndex={StartIndex},Length={Length}")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class z0ZzZzhkh : IEnumerable, IDisposable
{
	private class z0fhj
	{
		public XTextElement z0eek;

		public XTextElement z0rek;

		public z0ZzZzhkh z0tek;
	}

	private int z0mrk;

	internal static bool z0nrk;

	private XTextElement z0brk;

	private ContentRangeMode z0vrk;

	private XTextElementList z0crk = new XTextElementList();

	private int z0xrk;

	private int z0zrk;

	private int z0ltk;

	private XTextElementList z0ktk = new XTextElementList();

	private XTextElement z0jtk;

	private bool z0htk;

	private int z0gtk;

	private XTextElementList z0ftk;

	private int z0dtk;

	private XTextElementList z0stk = new XTextElementList();

	private int z0atk;

	private XTextDocumentContentElement z0qtk;

	private z0ZzZzblh z0wtk;

	public void z0rek()
	{
		z0mrk++;
	}

	public bool z0rek(XTextElement p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0 is XTextTableCellElement)
		{
			if (z0crk != null && z0crk.Count > 0)
			{
				return z0rek(z0crk, (XTextTableCellElement)p0);
			}
			return false;
		}
		if (z0stk != null && z0stk.Count > 0)
		{
			if (p0 is XTextContainerElement || z0oek().SafeGet(p0.z0tuk) != p0)
			{
				return z0stk.Contains(p0);
			}
			int z0tuk = p0.z0tuk;
			int num = z0tuk - z0stk.z0krk().z0jrk();
			if (num >= 0)
			{
				if (z0stk.SafeGet(num) == p0)
				{
					return true;
				}
				if (z0tuk <= z0stk.LastElement.z0jrk())
				{
					return z0stk.Contains(p0);
				}
			}
		}
		return false;
	}

	public int z0tek()
	{
		return Math.Abs(z0atk);
	}

	public ContentRangeMode z0yek()
	{
		return z0vrk;
	}

	public XTextElement z0uek()
	{
		if (z0stk == null)
		{
			return null;
		}
		return z0stk.z0krk();
	}

	public XTextElement z0iek()
	{
		if (z0stk == null)
		{
			return null;
		}
		return z0stk.LastElement;
	}

	private z0ZzZzplh z0oek()
	{
		return z0qtk.z0frk();
	}

	public int z0pek()
	{
		return z0dtk;
	}

	public string z0rek(bool p0)
	{
		if (z0atk == 0)
		{
			return string.Empty;
		}
		XTextDocument xTextDocument = z0qtk.z0jr();
		StringWriter stringWriter = new StringWriter();
		z0ZzZzjgh z0ZzZzjgh2 = z0ZzZzuok.z0eek<z0ZzZzjgh>();
		if (z0ZzZzjgh2 == null)
		{
			return null;
		}
		z0ZzZzjgh2.z0rs(stringWriter);
		z0ZzZzjgh2.z0eek(xTextDocument);
		z0ZzZzjgh2.z0os();
		z0ZzZzjgh2.z0ds(p0);
		z0ZzZzjgh2.z0ws(xTextDocument);
		if (z0yek() == ContentRangeMode.Content)
		{
			z0ZzZzjgh2.z0gs(p0: false);
			XTextElementList xTextElementList = xTextDocument.z0bek(this);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					z0ZzZzafh.z0uek(((XTextParagraphElement)z0bpk.Current).z0be());
				}
			}
			if (xTextElementList == null || xTextElementList.Count == 0)
			{
				return string.Empty;
			}
			z0ZzZzjgh2.z0eek(xTextElementList);
		}
		else
		{
			z0ZzZzjgh2.z0gs(p0: true);
			z0ZzZzjgh2.z0is(z0cek());
		}
		z0ZzZzjgh2.z0as();
		z0ZzZzjgh2.z0ts();
		return stringWriter.ToString();
	}

	public int z0mek()
	{
		return z0xrk;
	}

	public int z0nek()
	{
		return z0ltk;
	}

	private void z0eek(XTextElementList p0, XTextElementList p1, List<XTextTableElement> p2, bool p3)
	{
		int count = p1.Count;
		bool flag = true;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = p1[i];
			if (xTextElement is XTextCharElement || xTextElement is XTextParagraphFlagElement || xTextElement is XTextFieldBorderElement)
			{
				continue;
			}
			flag = false;
			if (i > 0)
			{
				p0.z0tek(new zzz.z0ZzZzyik<XTextElement>(p1, 0, i));
			}
			for (int j = i; j < count; j++)
			{
				xTextElement = p1[j];
				if (xTextElement is XTextCharElement || xTextElement is XTextParagraphFlagElement || xTextElement is XTextFieldBorderElement)
				{
					((zzz.z0ZzZzkuk<XTextElement>)p0).z0pek(xTextElement);
				}
				else if (xTextElement is XTextTableElement)
				{
					XTextTableElement xTextTableElement = (XTextTableElement)xTextElement;
					if (p2 != null && p2.Contains(xTextTableElement))
					{
						continue;
					}
					p2?.Add(xTextTableElement);
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0zek().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
						if (!xTextTableCellElement.z0bek())
						{
							z0eek(p0, xTextTableCellElement.z0trk(), p2, p3);
						}
					}
				}
				else
				{
					if (p3 && p0.Contains(xTextElement))
					{
						return;
					}
					((zzz.z0ZzZzkuk<XTextElement>)p0).z0pek(xTextElement);
				}
			}
			break;
		}
		if (flag)
		{
			((zzz.z0ZzZzkuk<XTextElement>)p0).z0tek((zzz.z0ZzZzkuk<XTextElement>)p1);
		}
	}

	internal bool z0rek(XTextTableCellElement p0)
	{
		if (z0crk != null && z0crk.Contains(p0))
		{
			return true;
		}
		return false;
	}

	internal bool z0rek(XTextTableCellElement p0, XTextTableCellElement p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("firstCell");
		}
		if (p1 == null)
		{
			p1 = p0;
		}
		XTextTableElement xTextTableElement = p0.z0gr();
		if (xTextTableElement == null)
		{
			throw new ArgumentNullException("firstCell.OwnerTable");
		}
		if (p1.z0gr() != xTextTableElement)
		{
			throw new ArgumentException("不是同一个表格");
		}
		z0stk = new XTextElementList();
		z0crk = new XTextElementList();
		z0vrk = ContentRangeMode.Cell;
		z0crk = xTextTableElement.z0pek(p0.z0pek(), p0.z0xek(), p1.z0pek(), p1.z0xek());
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0crk.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (!xTextTableCellElement.z0bek())
				{
					z0eek(z0stk, xTextTableCellElement.z0trk(), null, p3: false);
				}
			}
		}
		if (z0stk.Count > 0)
		{
			z0ltk = z0stk[0].z0jrk();
			z0atk = z0stk.Count;
			z0xrk = z0ltk;
			z0gtk = z0atk;
			z0zrk = z0cek().z0jr().z0kek();
			z0htk = false;
			z0ftk = null;
			z0dtk++;
			return true;
		}
		return false;
	}

	public z0ZzZzblh z0bek()
	{
		if (z0wtk == null)
		{
			z0wtk = new z0ZzZzblh(z0stk);
		}
		return z0wtk;
	}

	public bool z0vek()
	{
		if (z0crk != null && z0crk.Count > 100)
		{
			return true;
		}
		if (z0stk != null && z0stk.Count > 1000)
		{
			return true;
		}
		return false;
	}

	public XTextDocumentContentElement z0cek()
	{
		return z0qtk;
	}

	private void z0xek()
	{
		z0jtk = z0oek().SafeGet(z0ltk);
		z0brk = z0oek().SafeGet(z0ltk + z0atk);
	}

	public override string ToString()
	{
		return z0xrk + "=>" + z0gtk + " Ver:" + z0mrk;
	}

	public bool z0tek(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (z0stk.Count == 0)
		{
			return false;
		}
		if (z0vrk == ContentRangeMode.Content)
		{
			int num = p0.z0jrk() - z0stk[0].z0jrk();
			if (num >= 0 && num < z0stk.Count && z0stk[num] == p0)
			{
				return true;
			}
			return false;
		}
		if (z0vrk == ContentRangeMode.Cell)
		{
			for (XTextElement xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				if (xTextElement is XTextTableCellElement && z0tek((XTextTableCellElement)xTextElement))
				{
					return true;
				}
			}
			return false;
		}
		if (z0vrk == ContentRangeMode.Mixed)
		{
			for (XTextElement xTextElement2 = p0; xTextElement2 != null; xTextElement2 = xTextElement2.z0ji())
			{
				if (xTextElement2 is XTextTableCellElement && z0tek((XTextTableCellElement)xTextElement2))
				{
					return true;
				}
			}
			return z0stk.Contains(p0);
		}
		return false;
	}

	public string z0zek()
	{
		return z0rek(z0ZzZzkfh.z0uek);
	}

	public int z0lrk()
	{
		if (z0atk >= 0)
		{
			return z0ltk;
		}
		return z0ltk + z0atk;
	}

	public XTextElementList z0krk()
	{
		if (z0ftk == null)
		{
			z0ftk = new XTextElementList();
			if (z0stk != null && z0stk.Count > 0)
			{
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						if (current is XTextParagraphFlagElement)
						{
							z0ftk.Add(current);
						}
					}
				}
				XTextElement lastElement = z0stk.LastElement;
				if (!(lastElement is XTextParagraphFlagElement))
				{
					XTextElementList xTextElementList = lastElement.z0jy().z0trk();
					for (int i = xTextElementList.IndexOf(lastElement) + 1; i < xTextElementList.Count; i++)
					{
						if (xTextElementList[i] is XTextParagraphFlagElement)
						{
							z0ftk.Add(xTextElementList[i]);
							break;
						}
					}
				}
			}
		}
		return z0ftk;
	}

	public XTextDocument z0tek(bool p0)
	{
		XTextDocument xTextDocument = (XTextDocument)z0rrk().z0lr(p0: false);
		xTextDocument.z0bek((z0ZzZzkvj)null);
		xTextDocument.z0bek(new DocumentInfo());
		xTextDocument.z0ipk().z0pek(z0rrk().z0ipk().z0grk());
		xTextDocument.z0bek((DocumentContentStyleContainer)((z0ZzZzxok)z0rrk().z0gnk()).z0eek());
		XTextContainerElement p1 = xTextDocument.z0xyk();
		if (z0grk() == null || z0grk().Count == 0)
		{
			return xTextDocument;
		}
		p1.z0be().Clear();
		XTextElementList xTextElementList = z0ZzZzafh.z0iek(z0grk().z0krk());
		XTextElementList xTextElementList2 = z0ZzZzafh.z0iek(z0grk().LastElement);
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)z0bpk.Current;
				if (xTextElementList2.Contains(xTextContainerElement) && !(xTextContainerElement is XTextTableRowElement) && !(xTextContainerElement is XTextTableElement))
				{
					z0rek(xTextContainerElement, ref p1);
					break;
				}
			}
		}
		if (p0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocument.z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				z0ZzZzafh.z0uek(z0bpk.Current.z0be());
			}
		}
		if (z0rrk().z0pu_jiejie20260327142557().CloneWithoutElementBorderStyle)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocument.z0nek<XTextElement>().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextCharElement || current is XTextObjectElement || current is XTextFieldElementBase || current is XTextParagraphFlagElement)
				{
					current.z0bt(xTextDocument);
					((z0ZzZzcok)current.z0xrk()).z0tek();
				}
			}
		}
		using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk2 = xTextDocument.z0gnk().Styles.z0ltk())
		{
			while (z0bpk2.MoveNext())
			{
				DocumentContentStyle obj = (DocumentContentStyle)z0bpk2.Current;
				obj.CreatorIndex = -1;
				obj.DeleterIndex = -1;
			}
		}
		xTextDocument.z0syk().Clear();
		if (z0rrk().Comments != null)
		{
			xTextDocument.Comments = z0rrk().Comments.z0eek(p0: true);
		}
		xTextDocument.z0prk();
		xTextDocument.z0bek((z0ZzZzdbj)null);
		xTextDocument.z0bek((z0ZzZzpxj)null);
		xTextDocument.z0bek((z0ZzZzdcj)null);
		xTextDocument.z0hrk((XTextElement)null);
		xTextDocument.z0bek((z0ZzZzmxj)null);
		if (xTextDocument.z0imk() != null)
		{
			xTextDocument.z0nuk();
			xTextDocument.z0imk().Clear();
		}
		xTextDocument.z0li();
		return xTextDocument;
	}

	internal bool z0jrk()
	{
		XTextDocument p = z0rrk();
		z0ZzZzplh z0ZzZzplh2 = z0oek();
		if (z0stk != null && z0stk.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (z0ZzZzplh2.z0bek(current) < 0)
				{
					return false;
				}
			}
		}
		if (z0crk != null && z0crk.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0crk.z0ltk();
			while (z0bpk.MoveNext())
			{
				if (!((XTextTableCellElement)z0bpk.Current).z0ar(p, p1: false))
				{
					return false;
				}
			}
		}
		return true;
	}

	public int z0hrk()
	{
		return z0gtk;
	}

	public XTextElementList z0grk()
	{
		return z0stk;
	}

	public XTextElementList z0frk()
	{
		if (z0crk != null && z0crk.Count > 0)
		{
			XTextElementList xTextElementList = new XTextElementList();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0irk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (!xTextTableCellElement.z0bek())
				{
					xTextElementList.Add(xTextTableCellElement);
				}
			}
			return xTextElementList;
		}
		return null;
	}

	public int z0drk()
	{
		if (z0atk >= 0)
		{
			return z0ltk + z0atk;
		}
		return z0ltk;
	}

	public string z0srk()
	{
		if (z0stk == null)
		{
			return string.Empty;
		}
		bool selectionTextIncludeBackgroundText = z0rrk().z0vtk().BehaviorOptions.SelectionTextIncludeBackgroundText;
		StringBuilder stringBuilder = new StringBuilder();
		if (z0yek() == ContentRangeMode.Cell)
		{
			XTextTableRowElement xTextTableRowElement = null;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0irk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (!xTextTableCellElement.z0bek())
				{
					if (xTextTableRowElement != null && xTextTableCellElement.z0krk() != xTextTableRowElement)
					{
						stringBuilder.AppendLine();
					}
					if (xTextTableCellElement.z0krk() == xTextTableRowElement)
					{
						stringBuilder.Append("   ");
					}
					XTextElement.z0ygj z0ygj = new XTextElement.z0ygj(z0rrk(), p1: true);
					z0ygj.z0yek = selectionTextIncludeBackgroundText;
					z0ygj.z0uek = false;
					xTextTableCellElement.z0bw_jiejie20260327142557(z0ygj);
					stringBuilder.Append(z0ygj.ToString());
					xTextTableRowElement = xTextTableCellElement.z0krk();
				}
			}
		}
		else
		{
			int num = 0;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current.z0wtk() || (!selectionTextIncludeBackgroundText && current is XTextCharElement && ((XTextCharElement)current).z0oek()))
				{
					continue;
				}
				if (current is XTextParagraphFlagElement)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)current;
					if (xTextParagraphFlagElement.z0lrk() != null)
					{
						stringBuilder.Insert(num, xTextParagraphFlagElement.z0lrk().Text);
					}
					if (current.z0ji() is XTextTableCellElement)
					{
						XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)current.z0ji();
						if (((XTextContainerElement)xTextTableCellElement2).z0zek() == current)
						{
							XTextElement xTextElement = z0stk.z0xek(current);
							if (xTextElement != null)
							{
								XTextTableCellElement xTextTableCellElement3 = xTextElement.z0brk();
								if (xTextTableCellElement3 != null && xTextTableCellElement3.z0krk() == xTextTableCellElement2.z0krk())
								{
									stringBuilder.Append('\t');
									num = stringBuilder.Length;
									continue;
								}
							}
						}
					}
					stringBuilder.Append(Environment.NewLine);
					num = stringBuilder.Length;
				}
				else if (current is XTextFieldBorderElement)
				{
					string text = ((XTextFieldBorderElement)current).z0pek();
					if (text != null && text.Length > 0)
					{
						stringBuilder.Append(text);
					}
				}
				else if (current is XTextCharElement)
				{
					((XTextCharElement)current).z0rek(stringBuilder);
				}
				else
				{
					stringBuilder.Append(current.z0gy());
				}
			}
		}
		return stringBuilder.ToString();
	}

	public bool z0rek(DocumentContentStyle p0, bool p1, bool p2, string p3)
	{
		XTextElementList xTextElementList = new XTextElementList();
		if (z0grk() != null)
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)z0grk());
		}
		if (z0oek().z0ktk && !xTextElementList.Contains(z0oek().LastElement))
		{
			xTextElementList.Add(z0oek().LastElement);
		}
		if (p2 && z0irk() != null)
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)z0irk());
		}
		for (int num = xTextElementList.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = xTextElementList[num];
			if (xTextElement is XTextFieldBorderElement)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement.z0ji();
				if (!xTextElementList.Contains(xTextFieldElementBase))
				{
					xTextElementList.Insert(num, xTextFieldElementBase);
				}
			}
		}
		if (xTextElementList.Count == 0)
		{
			return false;
		}
		return z0rek(p0, p0, p0, z0qtk.z0jr(), xTextElementList, p1, p3, p7: true);
	}

	private bool z0rek(XTextElementList p0, XTextTableCellElement p1)
	{
		if (p0 != null && p0.Count > 0)
		{
			int num = p1.z0ork;
			if (num >= 0 && num < p0.Count && p0[num] == p1)
			{
				return true;
			}
			return p0.Contains(p1);
		}
		return false;
	}

	internal void z0ark()
	{
		if (z0ktk != null)
		{
			z0ktk.Clear();
			z0ktk = null;
		}
		z0crk = new XTextElementList();
		z0stk = new XTextElementList();
		z0zrk = z0rrk().z0kek();
		z0brk = null;
		z0atk = 0;
		z0vrk = ContentRangeMode.Content;
		z0gtk = 0;
		z0xrk = 0;
		z0ftk = null;
		z0dtk = 0;
		z0jtk = null;
		z0ltk = 0;
		z0wtk = null;
		z0mrk++;
	}

	public int z0qrk()
	{
		return z0atk;
	}

	public string z0wrk()
	{
		if (z0stk == null)
		{
			return string.Empty;
		}
		bool selectionTextIncludeBackgroundText = z0rrk().z0vtk().BehaviorOptions.SelectionTextIncludeBackgroundText;
		StringBuilder stringBuilder = new StringBuilder();
		if (z0yek() == ContentRangeMode.Cell)
		{
			XTextTableRowElement xTextTableRowElement = null;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0irk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (!xTextTableCellElement.z0bek())
				{
					if (xTextTableRowElement != null && xTextTableCellElement.z0krk() != xTextTableRowElement)
					{
						stringBuilder.AppendLine();
					}
					if (xTextTableCellElement.z0krk() == xTextTableRowElement)
					{
						stringBuilder.Append("   ");
					}
					XTextElement.z0ygj z0ygj = new XTextElement.z0ygj(z0rrk(), p1: true);
					z0ygj.z0yek = selectionTextIncludeBackgroundText;
					z0ygj.z0uek = false;
					xTextTableCellElement.z0bw_jiejie20260327142557(z0ygj);
					stringBuilder.Append(z0ygj.ToString());
					xTextTableRowElement = xTextTableCellElement.z0krk();
				}
			}
		}
		else
		{
			int num = 0;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextParagraphFlagElement xTextParagraphFlagElement && xTextParagraphFlagElement.z0lrk() != null)
				{
					stringBuilder.Insert(num, xTextParagraphFlagElement.z0lrk().Text);
				}
				if (current is XTextCharElement xTextCharElement)
				{
					if (!xTextCharElement.z0oek() || selectionTextIncludeBackgroundText)
					{
						xTextCharElement.z0rek(stringBuilder);
					}
				}
				else if (current is XTextFieldBorderElement xTextFieldBorderElement)
				{
					string text = xTextFieldBorderElement.z0pek();
					if (text != null && text.Length > 0)
					{
						stringBuilder.Append(text);
					}
				}
				else
				{
					stringBuilder.Append(current.z0gy());
					if (current is XTextParagraphFlagElement)
					{
						num = stringBuilder.Length;
					}
				}
			}
		}
		return stringBuilder.ToString();
	}

	public void z0erk()
	{
		z0rek(z0xrk, z0gtk, p2: true);
	}

	internal bool z0tek(XTextTableCellElement p0)
	{
		if (z0crk != null && z0crk.Count > 0 && z0crk.z0pek(p0, p0.z0ork))
		{
			return true;
		}
		return false;
	}

	public void z0rek(int p0)
	{
		z0mrk = p0;
	}

	public bool z0rek(object p0)
	{
		if (!(p0 is z0fhj z0fhj) || z0fhj.z0tek != this || z0fhj.z0rek == null || z0fhj.z0eek == null)
		{
			if (z0ltk < 0 || z0ltk + z0atk < 0)
			{
				z0ltk = 0;
				z0atk = 0;
				z0xrk = z0ltk;
				z0gtk = z0atk;
			}
			return false;
		}
		int num = z0oek().z0bek(z0fhj.z0rek);
		int num2 = z0oek().z0bek(z0fhj.z0eek);
		if (num >= 0 && num2 >= 0)
		{
			z0ltk = num;
			z0atk = num2 - num;
			z0xrk = z0ltk;
			z0gtk = z0atk;
			return true;
		}
		return false;
	}

	public XTextDocument z0rrk()
	{
		return z0qtk.z0jr();
	}

	public string z0trk()
	{
		return z0rek(p0: false);
	}

	internal bool z0yek(XTextElement p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0 is XTextTableCellElement)
		{
			if (z0crk != null && z0crk.Contains(p0))
			{
				return true;
			}
		}
		else if (p0 is XTextTableElement)
		{
			if (z0crk != null)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0crk.z0ltk();
				while (z0bpk.MoveNext())
				{
					if (((XTextTableCellElement)z0bpk.Current).z0gr() == p0)
					{
						return true;
					}
				}
			}
			for (XTextElement xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				if (z0stk.Contains(xTextElement))
				{
					return true;
				}
				if (z0crk != null && z0crk.Contains(xTextElement))
				{
					return true;
				}
			}
		}
		else if (z0stk.Contains(p0))
		{
			return true;
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				if (z0bpk.Current.z0zu(p0))
				{
					return true;
				}
			}
		}
		if (z0crk != null && z0crk.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0crk.z0ltk();
			while (z0bpk.MoveNext())
			{
				if (z0bpk.Current.z0zu(p0))
				{
					return true;
				}
			}
		}
		return false;
	}

	public XTextElementList z0rek(DocumentContentStyle p0)
	{
		XTextDocument xTextDocument = z0qtk.z0jr();
		Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
		if (z0rrk().z0hi().EnablePermission)
		{
			p0.z0eek(p0: true);
			p0.CreatorIndex = z0rrk().z0syk().z0yek();
			p0.DeleterIndex = -1;
		}
		else
		{
			p0.z0eek(p0: true);
			p0.CreatorIndex = -1;
			p0.DeleterIndex = -1;
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ork().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)z0bpk.Current;
				if (!xTextDocument.z0xek().z0np(xTextParagraphFlagElement))
				{
					continue;
				}
				DocumentContentStyle documentContentStyle = xTextParagraphFlagElement.z0aek().z0yek();
				if (z0ZzZzvik.z0eek(p0, documentContentStyle, p2: true) > 0)
				{
					int styleIndex = xTextDocument.z0gnk().GetStyleIndex(documentContentStyle);
					if (styleIndex != ((XTextElement)xTextParagraphFlagElement).z0pek())
					{
						dictionary[xTextParagraphFlagElement] = styleIndex;
					}
				}
			}
		}
		if (dictionary.Count > 0)
		{
			return xTextDocument.z0eek(dictionary, p1: true);
		}
		return null;
	}

	internal bool z0rek(int p0, int p1)
	{
		if (z0xrk == p0 && z0gtk == p1 && z0cek().z0jr().z0kek() == z0zrk && z0oek().z0frk() == z0htk)
		{
			return false;
		}
		return true;
	}

	internal void z0rek(z0ZzZzplh p0)
	{
		if (p0 != null)
		{
			if (z0ltk < 0)
			{
				z0ltk = 0;
			}
			if (p0.Count > 0 && z0ltk > p0.Count - 1)
			{
				z0ltk = p0.Count - 1;
			}
			if (z0xrk < 0)
			{
				z0xrk = 0;
			}
			if (z0xrk > p0.Count - 1)
			{
				z0xrk = p0.Count - 1;
			}
		}
	}

	private int z0rek(XTextContainerElement p0, ref XTextContainerElement p1)
	{
		int num = 0;
		if (p0 is XTextFieldElementBase)
		{
			XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)p0;
			if (z0grk().Contains(xTextFieldElementBase.z0jrk()) && z0grk().Contains(xTextFieldElementBase.z0tek()))
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)p0.z0lr(p0: true);
				if (p1 == null)
				{
					p1 = xTextContainerElement;
				}
				else
				{
					p1.z0ou(xTextContainerElement);
				}
				return 1;
			}
		}
		Dictionary<XTextContentElement, XTextElement> dictionary = new Dictionary<XTextContentElement, XTextElement>();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current.z0aek().z0jyk >= 0)
				{
					continue;
				}
				if (z0grk().Contains(current) || z0irk().Contains(current))
				{
					if (p1 == null)
					{
						p1 = (XTextContainerElement)p0.z0lr(p0: false);
						p1.z0yek((z0ZzZzzlh)null);
						num++;
					}
					num++;
					XTextElement p2 = current.z0lr(p0: true);
					p1.z0ou(p2);
					if (p1 is XTextContentElement)
					{
						dictionary[(XTextContentElement)p1] = current;
					}
				}
				else
				{
					if (!(current is XTextContainerElement))
					{
						continue;
					}
					XTextContainerElement xTextContainerElement2 = (XTextContainerElement)current;
					XTextContainerElement p3 = null;
					if (z0rek(xTextContainerElement2, ref p3) == 0 && current is XTextContainerElement)
					{
						XTextContainerElement xTextContainerElement3 = (XTextContainerElement)current;
						if (xTextContainerElement2.z0be().Count == 0)
						{
							XTextElementList xTextElementList = new XTextElementList();
							XTextContainerElement.z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new XTextContainerElement.z0eok_jiejie20260327142557(xTextContainerElement3.z0jr(), xTextElementList, p2: true);
							xTextContainerElement3.z0ue(z0eok_jiejie20260327142557);
							z0eok_jiejie20260327142557.Dispose();
							using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList.z0ltk();
							while (z0bpk2.MoveNext())
							{
								XTextElement current2 = z0bpk2.Current;
								if (z0grk().Contains(current2) && p3 == null)
								{
									p3 = (XTextContainerElement)xTextContainerElement2.z0lr(p0: false);
									p3.z0yek((z0ZzZzzlh)null);
									break;
								}
							}
						}
					}
					if (p3 == null)
					{
						continue;
					}
					if (p1 == null)
					{
						num++;
						p1 = (XTextContainerElement)p0.z0lr(p0: false);
						p1.z0yek((z0ZzZzzlh)null);
						if (p0 is XTextTableElement && xTextContainerElement2 is XTextTableRowElement)
						{
							XTextTableElement xTextTableElement = (XTextTableElement)p0;
							XTextTableElement xTextTableElement2 = (XTextTableElement)p1;
							int num2 = 2147483647;
							int num3 = -1;
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = z0crk.z0ltk())
							{
								while (z0bpk2.MoveNext())
								{
									XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk2.Current;
									if (xTextTableCellElement.z0gr() == xTextTableElement)
									{
										XTextTableCellElement xTextTableCellElement2 = ((xTextTableCellElement.z0hrk() == null) ? xTextTableCellElement : xTextTableCellElement.z0hrk());
										if (xTextTableCellElement2.z0xek() < num2)
										{
											num2 = xTextTableCellElement2.z0xek();
										}
										if (xTextTableCellElement2.z0xek() + xTextTableCellElement2.ColSpan > num3)
										{
											num3 = xTextTableCellElement2.z0xek() + xTextTableCellElement2.ColSpan;
										}
									}
								}
							}
							if (num2 < num3 && num3 <= xTextTableElement.z0srk().Count)
							{
								xTextTableElement2.z0srk().Clear();
								for (int i = num2; i < num3; i++)
								{
									xTextTableElement2.z0srk().Add(xTextTableElement.z0srk()[i].z0lr(p0: false));
								}
							}
						}
					}
					p1.z0ou(p3);
				}
			}
		}
		if (dictionary.Count > 0)
		{
			foreach (XTextContentElement key in dictionary.Keys)
			{
				XTextElement xTextElement = dictionary[key];
				if (!(xTextElement is XTextParagraphFlagElement))
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = xTextElement.z0dy();
					if (xTextParagraphFlagElement != null && !xTextParagraphFlagElement.z0vek() && ((XTextElement)xTextParagraphFlagElement).z0pek() >= 0)
					{
						key.z0ou(xTextParagraphFlagElement.z0lr(p0: true));
					}
				}
			}
		}
		if (p1 != null && p1 is XTextTableElement)
		{
			XTextTableElement xTextTableElement3 = (XTextTableElement)p1;
			XTextTableElement xTextTableElement4 = (XTextTableElement)p0;
			int num4 = 10000;
			int num5 = 0;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0irk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)z0bpk.Current;
					if (xTextTableCellElement3.z0gr() == xTextTableElement4 && !xTextTableCellElement3.z0bek())
					{
						if (xTextTableCellElement3.z0xek() < num4)
						{
							num4 = xTextTableCellElement3.z0xek();
						}
						if (xTextTableCellElement3.z0xek() + xTextTableCellElement3.ColSpan > num5)
						{
							num5 = xTextTableCellElement3.z0xek() + xTextTableCellElement3.ColSpan;
						}
					}
				}
			}
			num5 = Math.Min(num5, xTextTableElement4.z0srk().Count);
			for (int j = num4; j < num5; j++)
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)xTextTableElement4.z0srk()[j].z0lr(p0: false);
				xTextTableColumnElement.z0nu(xTextTableElement3);
				xTextTableElement3.z0srk().Add(xTextTableColumnElement);
			}
			xTextTableElement3.z0cek(p0: true);
			xTextTableElement3.z0krk();
		}
		return num;
	}

	public string z0rek(string p0)
	{
		XTextDocument xTextDocument = z0prk();
		StringWriter stringWriter = new StringWriter();
		xTextDocument.z0vek(stringWriter, p0);
		xTextDocument.Dispose();
		return stringWriter.ToString();
	}

	public object z0yrk()
	{
		return new z0fhj
		{
			z0tek = this,
			z0rek = z0jtk,
			z0eek = z0brk
		};
	}

	public int z0urk()
	{
		return z0mrk;
	}

	public void Dispose()
	{
		if (z0ktk != null)
		{
			z0ktk.z0vrk();
			z0ktk = null;
		}
		if (z0crk != null)
		{
			z0crk.Clear();
			z0crk = null;
		}
		if (z0stk != null)
		{
			z0stk.z0vrk();
			z0stk = null;
		}
		if (z0ftk != null)
		{
			z0ftk.z0vrk();
			z0ftk = null;
		}
		if (z0wtk != null)
		{
			z0wtk.z0rek();
			z0wtk = null;
		}
		z0qtk = null;
		z0jtk = null;
		z0brk = null;
	}

	public XTextElementList z0irk()
	{
		return z0crk;
	}

	public bool z0tek(int p0, int p1)
	{
		return z0rek(p0, p1, p2: false);
	}

	public XTextElementList z0ork()
	{
		XTextElementList xTextElementList = z0ktk;
		if (xTextElementList == null)
		{
			xTextElementList = (z0ktk = new XTextElementList());
		}
		if (z0qrk() != 0)
		{
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0stk.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (current is XTextParagraphFlagElement)
					{
						xTextElementList.Add(current);
					}
				}
			}
			if (!(z0stk.LastElement is XTextParagraphFlagElement))
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = z0stk.LastElement.z0dy();
				if (xTextParagraphFlagElement != null)
				{
					xTextElementList.Add(xTextParagraphFlagElement);
				}
			}
		}
		else
		{
			XTextElement xTextElement = z0oek().SafeGet(z0nek());
			if (xTextElement != null)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement2 = xTextElement.z0dy();
				if (xTextParagraphFlagElement2 != null)
				{
					xTextElementList.Add(xTextParagraphFlagElement2);
				}
			}
		}
		return xTextElementList;
	}

	internal bool z0rek(int p0, int p1, bool p2)
	{
		XTextDocument xTextDocument = z0rrk();
		if (xTextDocument == null)
		{
			return false;
		}
		z0ZzZzplh z0ZzZzplh2 = z0oek();
		z0ZzZzplh2.z0ktk = false;
		if (!p2 && z0xrk == p0 && z0gtk == p1 && xTextDocument.z0kek() == z0zrk && z0ZzZzplh2.z0frk() == z0htk)
		{
			return false;
		}
		if (xTextDocument.z0xu())
		{
			return false;
		}
		if (z0ktk != null)
		{
			z0ktk.Clear();
		}
		xTextDocument.z0bik();
		z0wtk = null;
		if (xTextDocument != null && xTextDocument.z0yyk() != null)
		{
			xTextDocument.z0yyk().z0gik();
			xTextDocument.z0yyk().z0iek(p0: true);
		}
		z0mrk++;
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex=" + p0);
		}
		int count = z0ZzZzplh2.Count;
		if (p0 >= count)
		{
			p0 = count - 1;
		}
		if (p0 + p1 >= count)
		{
			p1 = count - p0;
		}
		if (p0 + p1 < 0)
		{
			p1 = -p0;
		}
		z0dtk++;
		if (((XTextElement)xTextDocument).z0uyk() != null && !((XTextElement)xTextDocument).z0uyk().z0aok)
		{
			((XTextElement)xTextDocument).z0uyk().z0qrk();
		}
		xTextDocument.z0bek((z0ZzZzdcj)null);
		XTextElementList xTextElementList = null;
		if (z0stk.Count > 0)
		{
			xTextElementList = z0stk.z0pek();
		}
		z0stk = new XTextElementList();
		z0ftk = null;
		XTextElementList xTextElementList2 = z0crk.z0pek();
		z0crk = new XTextElementList();
		z0zrk = xTextDocument.z0kek();
		if (p0 == 0 && p1 == 0)
		{
			z0xrk = 0;
			z0gtk = 0;
			z0ltk = 0;
			z0atk = 0;
			z0xek();
			z0htk = z0ZzZzplh2.z0frk();
			z0vrk = ContentRangeMode.Content;
			z0stk = new XTextElementList();
			z0crk = new XTextElementList();
			z0jtk = z0ZzZzplh2.SafeGet(z0xrk);
			z0brk = z0ZzZzplh2.SafeGet(z0xrk + z0gtk);
		}
		else
		{
			z0xrk = p0;
			z0gtk = p1;
			z0htk = z0ZzZzplh2.z0frk();
			if (z0ZzZzplh2.z0htk)
			{
				z0ZzZzplh2.SafeGet(z0xrk)?.z0yek(p0: true, p1: true);
			}
			z0vrk = ContentRangeMode.Content;
			XTextTableCellElement xTextTableCellElement = null;
			XTextTableCellElement xTextTableCellElement2 = null;
			int num = 0;
			bool flag = false;
			int num2 = ((p1 > 0) ? p0 : (p0 + p1));
			int num3 = Math.Abs(p1);
			int num4 = 1;
			num4 = ((!z0ZzZzplh2.z0frk() || p1 >= 0) ? 0 : 0);
			int num5 = num3 + num4;
			List<XTextElement> list = new List<XTextElement>(num5);
			XTextElement xTextElement = null;
			XTextTableCellElement xTextTableCellElement3 = null;
			for (int i = 0; i < num5 && num2 + i < count; i++)
			{
				XTextElement xTextElement2 = z0ZzZzplh2[num2 + i];
				XTextContainerElement xTextContainerElement = xTextElement2.z0ji();
				if (xTextContainerElement == z0qtk)
				{
					list.Add(xTextElement2);
					flag = true;
					continue;
				}
				if (xTextContainerElement != xTextElement)
				{
					xTextElement = xTextContainerElement;
					xTextTableCellElement3 = xTextElement2.z0brk();
				}
				if (xTextTableCellElement3 != null)
				{
					if (xTextTableCellElement3 != xTextTableCellElement2)
					{
						list.Add(xTextTableCellElement3);
						num++;
					}
					if (xTextTableCellElement == null)
					{
						xTextTableCellElement = xTextTableCellElement3;
					}
					xTextTableCellElement2 = xTextTableCellElement3;
				}
				else
				{
					list.Add(xTextElement2);
					flag = true;
				}
			}
			XTextTableCellElement xTextTableCellElement4 = z0ZzZzplh2[p0].z0brk();
			if (xTextTableCellElement4 != null && !list.Contains(xTextTableCellElement4))
			{
				if (xTextTableCellElement == null)
				{
					xTextTableCellElement = xTextTableCellElement4;
				}
				if (p1 < 0 || xTextTableCellElement2 == null)
				{
					xTextTableCellElement2 = xTextTableCellElement4;
				}
				list.Add(xTextTableCellElement4);
				num++;
			}
			z0vrk = ContentRangeMode.Content;
			if (!flag && num == 1)
			{
				if (num2 == xTextTableCellElement.z0trk()[0].z0jrk() && num3 == xTextTableCellElement.z0trk().Count)
				{
					z0vrk = ContentRangeMode.Cell;
				}
				else
				{
					z0vrk = ContentRangeMode.Content;
				}
			}
			else if ((flag && num > 0) || num > 1)
			{
				XTextTableElement xTextTableElement = xTextTableCellElement.z0gr();
				if (flag)
				{
					z0vrk = ContentRangeMode.Mixed;
				}
				else
				{
					z0vrk = ContentRangeMode.Cell;
					foreach (XTextElement item in list)
					{
						if (item is XTextTableCellElement)
						{
							XTextTableElement xTextTableElement2 = ((XTextTableCellElement)item).z0gr();
							if (xTextTableElement2 != xTextTableElement && !xTextTableElement2.z0zu(xTextTableElement) && !xTextTableElement.z0zu(xTextTableElement2))
							{
								z0vrk = ContentRangeMode.Mixed;
								break;
							}
						}
					}
				}
			}
			if (z0vrk == ContentRangeMode.Content)
			{
				z0stk = z0ZzZzplh2.z0mek(num2, num3);
				z0ltk = p0;
				z0atk = p1;
				z0xek();
			}
			else
			{
				z0stk = new XTextElementList();
				XTextTableElement xTextTableElement3 = xTextTableCellElement.z0gr();
				if (z0vrk == ContentRangeMode.Cell)
				{
					if (xTextTableCellElement2.z0gr() != xTextTableCellElement.z0gr())
					{
						if (xTextTableCellElement.z0zu(xTextTableCellElement2.z0gr()))
						{
							xTextTableCellElement = xTextTableCellElement2;
							xTextTableElement3 = xTextTableCellElement2.z0gr();
						}
						else
						{
							XTextContainerElement xTextContainerElement2 = xTextTableCellElement2.z0gr();
							xTextTableCellElement2 = xTextTableCellElement;
							while (xTextContainerElement2 != null)
							{
								if (xTextContainerElement2 is XTextTableCellElement && ((XTextTableCellElement)xTextContainerElement2).z0gr() == xTextTableCellElement.z0gr())
								{
									xTextTableCellElement2 = (XTextTableCellElement)xTextContainerElement2;
									break;
								}
								xTextContainerElement2 = xTextContainerElement2.z0ji();
							}
						}
					}
					z0crk = xTextTableElement3.z0pek(xTextTableCellElement.z0pek(), xTextTableCellElement.z0xek(), xTextTableCellElement2.z0pek(), xTextTableCellElement2.z0xek());
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0crk.z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement5 = (XTextTableCellElement)z0bpk.Current;
						if (!xTextTableCellElement5.z0bek())
						{
							z0eek(z0stk, xTextTableCellElement5.z0trk(), null, p3: false);
						}
					}
				}
				else if (z0vrk == ContentRangeMode.Mixed)
				{
					z0crk = new XTextElementList();
					XTextTableRowElement xTextTableRowElement = null;
					XTextTableRowElement xTextTableRowElement2 = null;
					List<XTextTableElement> list2 = new List<XTextTableElement>();
					for (int j = 0; j < list.Count; j++)
					{
						XTextElement xTextElement3 = list[j];
						if (xTextElement3 is XTextTableCellElement)
						{
							XTextTableCellElement xTextTableCellElement6 = (XTextTableCellElement)xTextElement3;
							if (xTextTableRowElement == null)
							{
								xTextTableRowElement = xTextTableCellElement6.z0krk();
							}
							if (xTextTableCellElement6.z0gr() == xTextTableRowElement.z0gr())
							{
								xTextTableRowElement2 = xTextTableCellElement6.z0krk();
							}
							else
							{
								if (list2.Contains(xTextTableRowElement.z0gr()))
								{
									continue;
								}
								list2.Add(xTextTableRowElement.z0gr());
								XTextElementList xTextElementList3 = xTextTableRowElement.z0gr().z0pek(xTextTableRowElement.z0drk(), 0, xTextTableRowElement2.z0drk(), xTextTableRowElement2.z0rek().Count - 1);
								using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList3.z0ltk())
								{
									while (z0bpk.MoveNext())
									{
										XTextTableCellElement xTextTableCellElement7 = (XTextTableCellElement)z0bpk.Current;
										if (!xTextTableCellElement7.z0bek())
										{
											z0eek(z0stk, xTextTableCellElement7.z0trk(), list2, p3: false);
										}
									}
								}
								((zzz.z0ZzZzkuk<XTextElement>)z0crk).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList3);
								xTextTableRowElement = xTextTableCellElement6.z0krk();
								xTextTableRowElement2 = xTextTableCellElement6.z0krk();
							}
							continue;
						}
						if (xTextTableRowElement != null && !list2.Contains(xTextTableRowElement.z0gr()))
						{
							list2.Add(xTextTableRowElement.z0gr());
							XTextElementList xTextElementList4 = xTextTableRowElement.z0gr().z0pek(xTextTableRowElement.z0drk(), 0, xTextTableRowElement2.z0drk(), xTextTableRowElement2.z0rek().Count - 1);
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList4.z0ltk())
							{
								while (z0bpk.MoveNext())
								{
									XTextTableCellElement xTextTableCellElement8 = (XTextTableCellElement)z0bpk.Current;
									if (!xTextTableCellElement8.z0bek())
									{
										z0eek(z0stk, xTextTableCellElement8.z0trk(), list2, p3: false);
									}
								}
							}
							((zzz.z0ZzZzkuk<XTextElement>)z0crk).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList4);
							xTextTableRowElement = null;
							xTextTableRowElement2 = null;
						}
						((zzz.z0ZzZzkuk<XTextElement>)z0stk).z0pek(xTextElement3);
					}
					if (xTextTableRowElement != null && !list2.Contains(xTextTableRowElement.z0gr()))
					{
						list2.Add(xTextTableRowElement.z0gr());
						XTextElementList xTextElementList5 = xTextTableRowElement.z0gr().z0pek(xTextTableRowElement.z0drk(), 0, xTextTableRowElement2.z0drk(), xTextTableRowElement2.z0rek().Count - 1);
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList5.z0ltk())
						{
							while (z0bpk.MoveNext())
							{
								XTextTableCellElement xTextTableCellElement9 = (XTextTableCellElement)z0bpk.Current;
								if (!xTextTableCellElement9.z0bek())
								{
									z0eek(z0stk, xTextTableCellElement9.z0trk(), list2, p3: false);
								}
							}
						}
						((zzz.z0ZzZzkuk<XTextElement>)z0crk).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList5);
					}
				}
			}
			if (p1 == 0 || z0stk.Count == 0)
			{
				z0ltk = p0;
				z0atk = p1;
				z0xek();
			}
			else
			{
				if (p1 > 0)
				{
					z0ltk = z0stk[0].z0jrk();
					z0atk = z0stk.Count;
					z0xek();
					z0ZzZzplh2.z0tek(p0: false);
					XTextElement lastElement = z0stk.LastElement;
					if (z0vrk != ContentRangeMode.Cell && lastElement.z0ptk() != null && lastElement.z0ptk().z0urk().LastElement == lastElement)
					{
						z0ZzZzplh2.z0tek(p0: true);
					}
				}
				else
				{
					z0ltk = z0stk.LastElement.z0jrk() + 1;
					z0atk = -z0stk.Count;
					z0xek();
					if (!z0nrk && z0stk.LastElement.z0brk() != null)
					{
						z0htk = true;
					}
					else
					{
						z0nrk = false;
					}
					if (z0vrk == ContentRangeMode.Cell)
					{
						z0htk = false;
						z0cek().z0frk().z0tek(p0: false);
					}
				}
				z0htk = z0ZzZzplh2.z0frk();
			}
		}
		z0ZzZzhmk z0ZzZzhmk2 = new z0ZzZzhmk();
		if (xTextElementList2 != null && xTextElementList2.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement10 = (XTextTableCellElement)z0bpk.Current;
				xTextTableCellElement10.z0ork = -1;
				if (z0crk == null || !z0crk.Contains(xTextTableCellElement10))
				{
					z0ZzZzbdh p3 = xTextDocument.z0zek(xTextTableCellElement10);
					if (!p3.z0bek())
					{
						z0ZzZzhmk2.z0eek(p3);
					}
				}
			}
		}
		if (z0crk != null && z0crk.Count > 0)
		{
			int count2 = z0crk.Count;
			for (int k = 0; k < count2; k++)
			{
				XTextTableCellElement xTextTableCellElement11 = (XTextTableCellElement)z0crk[k];
				if (!z0rek(xTextElementList2, xTextTableCellElement11))
				{
					z0ZzZzbdh p4 = xTextDocument.z0zek(xTextTableCellElement11);
					if (!p4.z0bek())
					{
						z0ZzZzhmk2.z0eek(p4);
					}
				}
				xTextTableCellElement11.z0ork = k;
			}
		}
		if (z0yek() == ContentRangeMode.Content || z0yek() == ContentRangeMode.Mixed)
		{
			int num6 = -1;
			int num7 = -1;
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				num6 = xTextElementList[0].z0jrk();
				num7 = xTextElementList.LastElement.z0jrk();
			}
			if (z0stk != null && z0stk.Count > 0)
			{
				if (num6 == -1 || num6 > z0stk[0].z0jrk())
				{
					num6 = z0stk[0].z0jrk();
				}
				if (num7 == -1 || num7 < z0stk.LastElement.z0jrk())
				{
					num7 = z0stk.LastElement.z0jrk();
				}
			}
			if (num6 >= 0 && num6 >= z0ZzZzplh2.Count)
			{
				num6 = z0ZzZzplh2.Count - 1;
			}
			if (num7 >= 0 && num7 >= z0ZzZzplh2.Count)
			{
				num7 = z0ZzZzplh2.Count - 1;
			}
			if (num6 >= 0 && num7 >= num6)
			{
				z0ZzZzzlh z0ZzZzzlh2 = null;
				for (int l = num6; l <= num7; l++)
				{
					XTextElement xTextElement4 = z0ZzZzplh2[l];
					if (xTextElement4 is XTextCharElement || xTextElement4 is XTextParagraphFlagElement || xTextElement4 is XTextFieldBorderElement)
					{
						z0ZzZzzlh z0kik = xTextElement4.z0kik;
						if (z0ZzZzzlh2 == null || z0ZzZzzlh2 != z0kik)
						{
							z0ZzZzzlh2 = z0kik;
							if (z0ZzZzzlh2 != null)
							{
								z0ZzZzhmk2.z0eek(z0ZzZzzlh2.z0krk());
							}
						}
					}
					else
					{
						z0ZzZzbdh p5 = xTextDocument.z0zek(xTextElement4);
						if (!p5.z0bek())
						{
							z0ZzZzhmk2.z0eek(p5);
						}
					}
				}
			}
			else
			{
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					XTextElement xTextElement5 = z0stk?.z0krk();
					XTextElement xTextElement6 = z0stk?.LastElement;
					foreach (XTextElement item2 in xTextElementList.z0xrk())
					{
						if (!z0stk.Contains(item2) || xTextElement5 == item2 || xTextElement6 == item2)
						{
							z0ZzZzbdh p6 = xTextDocument.z0zek(item2);
							if (!p6.z0bek())
							{
								z0ZzZzhmk2.z0eek(p6);
							}
						}
					}
				}
				if (z0stk.Count > 0)
				{
					XTextElement xTextElement7 = xTextElementList?.z0krk();
					XTextElement xTextElement8 = xTextElementList?.LastElement;
					foreach (XTextElement item3 in z0stk.z0xrk())
					{
						if (xTextElementList == null || !xTextElementList.Contains(item3) || xTextElement7 == item3 || xTextElement8 == item3)
						{
							z0ZzZzbdh p7 = xTextDocument.z0zek(item3);
							if (!p7.z0bek())
							{
								z0ZzZzhmk2.z0eek(p7);
							}
						}
					}
				}
			}
		}
		if (!z0ZzZzhmk2.z0rek() && xTextDocument.z0yyk() != null)
		{
			z0ZzZzbdh p8 = z0ZzZzhmk2.z0eek();
			xTextDocument.z0yyk().z0eek(p8, z0cek().z0fu());
		}
		xTextDocument.z0aok();
		return true;
	}

	public z0ZzZzhkh(XTextDocumentContentElement p0)
	{
		z0qtk = p0;
	}

	public XTextDocument z0prk()
	{
		return z0tek(z0rrk().z0pu_jiejie20260327142557().CloneWithoutLogicDeletedContent);
	}

	public IEnumerator GetEnumerator()
	{
		if (z0stk == null)
		{
			return null;
		}
		return z0stk.z0ltk();
	}

	public static bool z0rek(DocumentContentStyle p0, DocumentContentStyle p1, DocumentContentStyle p2, XTextDocument p3, IEnumerable p4, bool p5, string p6, bool p7)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("newStyle");
		}
		if (p3 == null)
		{
			throw new ArgumentNullException("document");
		}
		if (p4 == null)
		{
			throw new ArgumentNullException("elements");
		}
		if (p1 == null)
		{
			p1 = p0;
		}
		if (p2 == null)
		{
			p2 = p0;
		}
		p0.z0rek(p0: false);
		if (p3.z0hi().EnablePermission)
		{
			bool flag = true;
			if (!p3.z0bu().InsertCommentBindingUserTrack && z0ZzZzafh.z0oek(p6))
			{
				flag = false;
			}
			if (flag)
			{
				z0ZzZzvik.z0eek(p0, "DeleterIndex");
				p0.CreatorIndex = p3.z0syk().z0yek();
				z0ZzZzvik.z0eek(p1, "DeleterIndex");
				p1.CreatorIndex = p3.z0syk().z0yek();
				z0ZzZzvik.z0eek(p2, "DeleterIndex");
				p2.CreatorIndex = p3.z0syk().z0yek();
			}
		}
		else
		{
			z0ZzZzvik.z0eek(p0, "CreatorIndex");
			z0ZzZzvik.z0eek(p0, "DeleterIndex");
			z0ZzZzvik.z0eek(p1, "CreatorIndex");
			z0ZzZzvik.z0eek(p1, "DeleterIndex");
			z0ZzZzvik.z0eek(p2, "CreatorIndex");
			z0ZzZzvik.z0eek(p2, "DeleterIndex");
		}
		Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
		XTextElementList xTextElementList = new XTextElementList();
		z0ZzZzpij z0ZzZzpij2 = null;
		switch (p6)
		{
		case "FontName":
		case "Font":
		case "FormatBrush":
			z0ZzZzpij2 = z0ZzZzpij.z0eek(p0.FontName, p0.FontStyle);
			break;
		}
		foreach (XTextElement item in p4)
		{
			bool flag2 = false;
			if (item.z0ji() is XTextFieldElementBase xTextFieldElementBase && (xTextFieldElementBase.z0eek(item) || item is XTextFieldBorderElement))
			{
				flag2 = true;
			}
			if (flag2 && !xTextElementList.Contains(item.z0ji()))
			{
				xTextElementList.Add(item.z0ji());
			}
			if (item is XTextCharElement && z0ZzZzpij2 != null && !z0ZzZzpij2.z0eek(((XTextCharElement)item).CharValue))
			{
				continue;
			}
			DocumentContentStyle documentContentStyle = p0;
			if (item is XTextParagraphFlagElement)
			{
				documentContentStyle = p1;
			}
			else if (item is XTextTableCellElement)
			{
				documentContentStyle = p2;
			}
			if (documentContentStyle == null)
			{
				documentContentStyle = p0;
			}
			bool flag3 = false;
			DocumentContentStyle documentContentStyle2 = item.z0aek().z0yek();
			if (p6 == "ClearFormat" || p6 == "FormatBrush")
			{
				flag3 = item.z0pek() != p3.z0gnk().GetStyleIndex(documentContentStyle);
				if (flag3)
				{
					documentContentStyle2 = (DocumentContentStyle)documentContentStyle.Clone();
				}
			}
			else if (z0ZzZzvik.z0eek(documentContentStyle, documentContentStyle2, p2: true) > 0)
			{
				flag3 = true;
			}
			if (flag3)
			{
				if (documentContentStyle2.HasTitleLevel)
				{
					p3.z0jzk = true;
				}
				int styleIndex = p3.z0gnk().GetStyleIndex(documentContentStyle2);
				if (styleIndex != item.z0pek())
				{
					dictionary[item] = styleIndex;
				}
				XTextElement xTextElement2 = item.z0ku();
				if (xTextElement2 != null && styleIndex != xTextElement2.z0pek())
				{
					dictionary[xTextElement2] = styleIndex;
				}
			}
		}
		if (xTextElementList.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				DocumentContentStyle documentContentStyle3 = current.z0aek().z0yek();
				if (z0ZzZzvik.z0eek(p0, documentContentStyle3, p2: true) > 0)
				{
					if (documentContentStyle3.HasTitleLevel)
					{
						p3.z0jzk = true;
					}
					int styleIndex2 = p3.z0gnk().GetStyleIndex(documentContentStyle3);
					if (styleIndex2 != current.z0pek())
					{
						dictionary[current] = styleIndex2;
					}
				}
			}
		}
		if (dictionary.Count > 0)
		{
			XTextElementList xTextElementList2 = p3.z0rek(dictionary, p7, p5, p6);
			if (xTextElementList2 != null && xTextElementList2.Count > 0)
			{
				return true;
			}
		}
		return false;
	}
}
