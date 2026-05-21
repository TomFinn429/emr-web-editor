using System;
using System.Collections.Generic;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal sealed class z0ZzZzfnj : z0ZzZzcmj
{
	[z0ZzZzimj("AlignTopCenter")]
	private void z0eek(object p0, z0ZzZzomj p1)
	{
		z0eek(ContentAlignment.TopCenter, p1);
	}

	[z0ZzZzimj("Table_SplitRowsByContentLines", FunctionID = 92)]
	private void z0rek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextTableElement xTextTableElement = null;
			List<XTextTableRowElement> list = new List<XTextTableRowElement>();
			if (p1.Parameter is List<XTextTableRowElement>)
			{
				list = (List<XTextTableRowElement>)p1.Parameter;
			}
			else if (p1.Parameter is XTextTableRowElement)
			{
				list.Add((XTextTableRowElement)p1.Parameter);
			}
			else if (p1.Parameter is XTextTableElement)
			{
				xTextTableElement = (XTextTableElement)p1.Parameter;
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0stk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
					if (!xTextTableRowElement.HeaderStyle)
					{
						list.Add(xTextTableRowElement);
					}
				}
			}
			else if (p1.Parameter is string && !string.IsNullOrEmpty((string)p1.Parameter))
			{
				if (p1.Document.z0ki((string)p1.Parameter) is XTextTableElement xTextTableElement2)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement2.z0stk().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)z0bpk.Current;
						if (!xTextTableRowElement2.HeaderStyle)
						{
							list.Add(xTextTableRowElement2);
						}
					}
				}
			}
			else
			{
				XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)p1.Document.z0bek(typeof(XTextTableRowElement));
				if (xTextTableRowElement3 != null)
				{
					list.Add(xTextTableRowElement3);
				}
			}
			if (list == null || list.Count == 0)
			{
				return;
			}
			for (int num = list.Count - 1; num >= 0; num--)
			{
				XTextTableRowElement xTextTableRowElement4 = list[num];
				int num2 = 0;
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement4.z0rek().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
					if (num2 == 0)
					{
						num2 = xTextTableCellElement.RowSpan;
					}
					else if (num2 != xTextTableCellElement.RowSpan)
					{
						list.RemoveAt(num);
						break;
					}
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			XTextTableElement xTextTableElement3 = null;
			int p2 = -1;
			int num3 = 0;
			foreach (XTextTableRowElement item in list)
			{
				if (xTextTableElement3 == null)
				{
					xTextTableElement3 = item.z0gr();
					p2 = xTextTableElement3.z0stk().IndexOf(item);
					num3 = 1;
					continue;
				}
				if (item.z0gr() == xTextTableElement3)
				{
					num3++;
					continue;
				}
				break;
			}
			if (xTextTableElement3 != null && num3 >= 1)
			{
				bool flag = xTextTableElement3.z0pek(p2, num3, p2: true);
				p1.Result = flag;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	private XTextElementList z0eek(z0ZzZzomj p0, XTextDocument p1, bool p2)
	{
		if (p0.EditorControl == null)
		{
			return null;
		}
		_ = p0.Mode;
		_ = 5;
		XTextTableColumnElement xTextTableColumnElement = null;
		int num = 1;
		if (p0.Parameter is XTextTableColumnElement)
		{
			xTextTableColumnElement = (XTextTableColumnElement)p0.Parameter;
		}
		else if (p0.Parameter is z0ZzZzqmj)
		{
			z0ZzZzqmj z0ZzZzqmj2 = (z0ZzZzqmj)p0.Parameter;
			num = z0ZzZzqmj2.z0tek();
			XTextTableElement xTextTableElement = z0ZzZzqmj2.z0iek();
			if (xTextTableElement == null)
			{
				xTextTableElement = p0.Document.z0ki(z0ZzZzqmj2.z0uek()) as XTextTableElement;
			}
			if (xTextTableElement != null && xTextTableElement.z0srk().Count > 0)
			{
				int num2 = z0ZzZzqmj2.z0rek();
				xTextTableColumnElement = ((num2 < 0) ? ((XTextTableColumnElement)xTextTableElement.z0srk()[0]) : ((num2 < xTextTableElement.z0srk().Count) ? ((XTextTableColumnElement)xTextTableElement.z0srk()[num2]) : ((XTextTableColumnElement)xTextTableElement.z0srk().LastElement)));
			}
		}
		if (xTextTableColumnElement == null)
		{
			XTextElementList xTextElementList = z0tek(p1, p1: false);
			if (xTextElementList == null || xTextElementList.Count == 0)
			{
				if (p0.Mode == (z0ZzZzmmj)2)
				{
					p0.Enabled = false;
				}
				return null;
			}
			xTextTableColumnElement = ((!p2) ? ((XTextTableColumnElement)xTextElementList.LastElement) : ((XTextTableColumnElement)xTextElementList.z0krk()));
		}
		XTextTableElement xTextTableElement2 = xTextTableColumnElement.z0gr();
		if (!p0.DocumentControler.z0bm(xTextTableElement2, 0, typeof(XTextTableColumnElement)))
		{
			if (p0.Mode == (z0ZzZzmmj)2)
			{
				p0.Enabled = false;
			}
			return null;
		}
		if (p0.Mode == (z0ZzZzmmj)2)
		{
			p0.Enabled = true;
			return null;
		}
		XTextElementList xTextElementList2 = new XTextElementList();
		for (int i = 0; i < num; i++)
		{
			XTextTableColumnElement xTextTableColumnElement2 = xTextTableElement2.z0vek();
			xTextTableColumnElement2.Width = xTextTableColumnElement.Width;
			xTextElementList2.Add(xTextTableColumnElement2);
		}
		if (p2)
		{
			xTextTableElement2.z0iek(xTextTableColumnElement.z0rek(), xTextElementList2, null, p3: true, null, p1.z0pu_jiejie20260327142557().KeepTableWidthWhenInsertDeleteColumn, null);
		}
		else
		{
			xTextTableElement2.z0iek(xTextTableColumnElement.z0rek() + 1, xTextElementList2, null, p3: true, null, p1.z0pu_jiejie20260327142557().KeepTableWidthWhenInsertDeleteColumn, null);
		}
		if (xTextElementList2 != null && xTextElementList2.Count > 0 && p0.Parameter is z0ZzZzqmj)
		{
			((z0ZzZzqmj)p0.Parameter).z0eek(p0: true);
		}
		return xTextElementList2;
	}

	public static XTextTableCellElement z0eek(XTextDocument p0)
	{
		if (p0 == null)
		{
			return null;
		}
		z0ZzZzplh z0ZzZzplh2 = p0.z0ryk();
		if (z0ZzZzplh2.z0zek().z0irk() != null && z0ZzZzplh2.z0zek().z0irk().Count > 0)
		{
			return (XTextTableCellElement)z0ZzZzplh2.z0zek().z0irk()[0];
		}
		for (XTextElement xTextElement = p0.z0itk(); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is XTextTableCellElement)
			{
				return (XTextTableCellElement)xTextElement;
			}
		}
		return null;
	}

	[z0ZzZzimj("Table_InsertTable", FunctionID = 89)]
	private void z0tek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.DocumentControler != null)
			{
				p1.Enabled = p1.DocumentControler.z0an(typeof(XTextTableElement));
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextTableElement xTextTableElement = null;
			if (p1.Parameter is XTextTableElement)
			{
				xTextTableElement = (XTextTableElement)p1.Parameter;
			}
			else
			{
				z0ZzZzqnj z0ZzZzqnj2 = p1.Parameter as z0ZzZzqnj;
				if (z0ZzZzqnj2 == null)
				{
					z0ZzZzqnj2 = new z0ZzZzqnj();
				}
				if (z0ZzZzqnj2.z0pek() <= 0 || z0ZzZzqnj2.z0bek() <= 0)
				{
					return;
				}
				if (z0ZzZzqnj2.z0eek() == 0f && p1.Document.z0itk() != null)
				{
					XTextContentElement xTextContentElement = p1.Document.z0itk().z0jy();
					z0ZzZzqnj2.z0tek((((XTextElement)xTextContentElement).z0ork() - p1.Document.z0xek(2f)) / (float)z0ZzZzqnj2.z0pek());
				}
				xTextTableElement = (XTextTableElement)z0ZzZzqnj2.z0sz(p1.Document);
			}
			if (xTextTableElement == null)
			{
				return;
			}
			p1.Document.z0bek("table", xTextTableElement);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0stk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = ((XTextTableRowElement)z0bpk.Current).z0rek().z0ltk();
					while (z0bpk2.MoveNext())
					{
						((XTextTableCellElement)z0bpk2.Current).z0gu();
					}
				}
			}
			xTextTableElement.z0bt(p1.Document);
			xTextTableElement.z0li();
			xTextTableElement.z0xi(p0: true);
			p1.DocumentControler.z0em(new XTextElementList(xTextTableElement));
			p1.Document.z0srk(xTextTableElement);
			p1.Document.z0ytk();
			p1.Document.z0frk(xTextTableElement);
			p1.Document.z0nuk();
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Result = xTextTableElement;
		}
	}

	[z0ZzZzimj("Table_InsertRowDown", ReturnValueType = typeof(XTextTableRowElement), FunctionID = 92)]
	private void z0yek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = z0eek(p1, p1: false, p2: true);
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0eek(p1, p1: false, p2: false);
		}
	}

	[z0ZzZzimj("AlignBottomRight")]
	private void z0uek(object p0, z0ZzZzomj p1)
	{
		z0eek(ContentAlignment.BottomRight, p1);
	}

	public static XTextElementList z0eek(XTextDocument p0, bool p1)
	{
		XTextElementList xTextElementList = z0rek(p0, p1);
		XTextElementList xTextElementList2 = new XTextElementList();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (!xTextElementList2.Contains(xTextTableCellElement.z0krk()))
				{
					xTextElementList2.Add(xTextTableCellElement.z0krk());
				}
			}
		}
		return xTextElementList2;
	}

	public static XTextElementList z0rek(XTextDocument p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		XTextElementList xTextElementList = new XTextElementList();
		if (p0.z0cuk().z0qrk() == 0)
		{
			if (p0.z0itk() != null)
			{
				XTextTableCellElement xTextTableCellElement = p0.z0itk().z0brk();
				if (xTextTableCellElement != null)
				{
					xTextElementList.Add(xTextTableCellElement);
				}
			}
		}
		else if (p0.z0cuk().z0yek() == ContentRangeMode.Cell || p0.z0cuk().z0yek() == ContentRangeMode.Mixed)
		{
			xTextElementList = p0.z0cuk().z0irk().z0pek();
		}
		else
		{
			XTextTableCellElement xTextTableCellElement2 = p0.z0cuk().z0grk()[0].z0brk();
			if (xTextTableCellElement2 != null)
			{
				xTextElementList.Add(xTextTableCellElement2);
			}
		}
		z0ZzZzpxj z0ZzZzpxj2 = p0.z0xek();
		z0ZzZzpxj2.z0mp();
		try
		{
			if (p1)
			{
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)z0bpk.Current;
						if (!xTextTableCellElement3.z0bek() && z0ZzZzpxj2.z0np(xTextTableCellElement3))
						{
							return new XTextElementList(xTextTableCellElement3);
						}
					}
				}
				return new XTextElementList();
			}
			for (int num = xTextElementList.Count - 1; num >= 0; num--)
			{
				XTextTableCellElement xTextTableCellElement4 = (XTextTableCellElement)xTextElementList[num];
				if (xTextTableCellElement4.z0bek() || !z0ZzZzpxj2.z0np(xTextTableCellElement4))
				{
					xTextElementList.RemoveAt(num);
				}
			}
			return xTextElementList;
		}
		finally
		{
			z0ZzZzpxj2.z0on();
		}
	}

	[z0ZzZzimj("Table_DeleteColumn", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = 91)]
	private void z0iek_jiejie20260327142557(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode != (z0ZzZzmmj)5 && p1.Mode != (z0ZzZzmmj)2)
		{
			return;
		}
		_ = p1.Mode;
		_ = 2;
		if (p1.EditorControl == null)
		{
			return;
		}
		p1.Result = false;
		XTextElementList xTextElementList = new XTextElementList();
		if (p1.Parameter is XTextTableColumnElement)
		{
			xTextElementList.Add((XTextTableColumnElement)p1.Parameter);
		}
		else if (p1.Parameter is XTextElementList)
		{
			XTextElementList obj = (XTextElementList)p1.Parameter;
			XTextTableElement xTextTableElement = null;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = obj.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextTableColumnElement)
				{
					XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)current;
					if (xTextTableElement == null)
					{
						xTextTableElement = xTextTableColumnElement.z0gr();
					}
					else if (xTextTableElement != xTextTableColumnElement.z0gr())
					{
						throw new ArgumentOutOfRangeException("不是同表格的表格列");
					}
					xTextElementList.Add(xTextTableColumnElement);
				}
			}
		}
		else if (p1.Parameter is z0ZzZzqmj)
		{
			z0ZzZzqmj z0ZzZzqmj2 = (z0ZzZzqmj)p1.Parameter;
			XTextTableElement xTextTableElement2 = z0ZzZzqmj2.z0iek();
			if (xTextTableElement2 == null)
			{
				xTextTableElement2 = p1.Document.z0ki(z0ZzZzqmj2.z0uek()) as XTextTableElement;
			}
			if (xTextTableElement2 != null && xTextTableElement2.z0srk().Count > 0)
			{
				int num = z0ZzZzqmj2.z0rek();
				if (num < 0)
				{
					num = 0;
				}
				if (num > xTextTableElement2.z0srk().Count)
				{
					num = xTextTableElement2.z0srk().Count - 1;
				}
				for (int i = 0; i < z0ZzZzqmj2.z0tek(); i++)
				{
					int num2 = i + num;
					if (num2 >= 0 && num2 < xTextTableElement2.z0srk().Count)
					{
						xTextElementList.Add(xTextTableElement2.z0srk()[num2]);
					}
				}
			}
			if (xTextElementList.Count == 0)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement p2 = (XTextTableColumnElement)z0bpk.Current;
				if (!p1.DocumentControler.z0lm(p2))
				{
					return;
				}
			}
		}
		else
		{
			xTextElementList = z0tek(p1.Document, p1: false);
		}
		if (xTextElementList == null || xTextElementList.Count <= 0)
		{
			return;
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement2 = (XTextTableColumnElement)z0bpk.Current;
				if (!p1.DocumentControler.z0lm(xTextTableColumnElement2))
				{
					if (p1.Mode == (z0ZzZzmmj)2)
					{
						p1.Enabled = false;
					}
					return;
				}
				z0ZzZzgcj z0ZzZzgcj2 = new z0ZzZzgcj();
				bool flag = true;
				if (p1.Mode == (z0ZzZzmmj)2 && xTextTableColumnElement2.z0gr().z0stk().Count > 100)
				{
					flag = false;
				}
				if (!flag)
				{
					continue;
				}
				XTextElementList xTextElementList2 = xTextTableColumnElement2.z0eek();
				p1.DocumentControler.z0mp();
				try
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList2.z0ltk();
					while (z0bpk2.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk2.Current;
						if (p1.Mode == (z0ZzZzmmj)2)
						{
							if (xTextTableCellElement.z0wo(z0ZzZzgcj2, 1))
							{
								break;
							}
						}
						else if (xTextTableCellElement.z0wo(z0ZzZzgcj2, 10))
						{
							break;
						}
					}
				}
				finally
				{
					p1.DocumentControler.z0on();
				}
				if (z0ZzZzgcj2.Count > 0)
				{
					if (p1.Mode != (z0ZzZzmmj)2 && p1.ShowUI)
					{
						p1.Document.z0vek(z0ZzZzgcj2);
					}
					return;
				}
			}
		}
		XTextTableColumnElement xTextTableColumnElement3 = (XTextTableColumnElement)xTextElementList[0];
		XTextTableElement xTextTableElement3 = xTextTableColumnElement3.z0gr();
		if (xTextElementList.Count == xTextTableElement3.z0srk().Count)
		{
			if (p1.Mode == (z0ZzZzmmj)2)
			{
				p1.Enabled = true;
				return;
			}
			p1.Parameter = xTextTableElement3;
			z0rrk(p0, p1);
		}
		else
		{
			z0ZzZzgcj z0ZzZzgcj3 = new z0ZzZzgcj();
			if (z0ZzZzgcj3.Count > 0)
			{
				p1.DocumentControler.z0mp();
				try
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement3.z0stk().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
						for (int j = 0; j < xTextElementList.Count && !((XTextTableCellElement)xTextTableRowElement.z0rek()[xTextTableColumnElement3.z0rek() + j]).z0wo(z0ZzZzgcj3, 10); j++)
						{
						}
					}
				}
				finally
				{
					p1.DocumentControler.z0on();
				}
			}
			if (z0ZzZzgcj3 != null && z0ZzZzgcj3.Count > 0)
			{
				if (p1.Mode == (z0ZzZzmmj)2)
				{
					p1.Enabled = false;
					return;
				}
				if (p1.ShowUI)
				{
					p1.Document.z0vek(z0ZzZzgcj3);
				}
				p1.Result = false;
			}
			else
			{
				if (p1.Mode == (z0ZzZzmmj)2)
				{
					p1.Enabled = true;
					return;
				}
				p1.Result = xTextTableElement3.z0eek_jiejie20260327142557(xTextTableColumnElement3.z0rek(), xTextElementList.Count, p2: true, null, p1.Document.z0pu_jiejie20260327142557().KeepTableWidthWhenInsertDeleteColumn, null);
			}
		}
		if (p1.Parameter is z0ZzZzqmj)
		{
			((z0ZzZzqmj)p1.Parameter).z0eek((bool)p1.Result);
		}
		if (p1.Parameter is XTextTableElement)
		{
			if (p1.Result != null)
			{
				p1.Result = true;
			}
			else
			{
				p1.Result = false;
			}
		}
		if ((bool)p1.Result)
		{
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("Table_DeleteRow", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = 91)]
	private void z0oek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode != (z0ZzZzmmj)5 && p1.Mode != (z0ZzZzmmj)2)
		{
			return;
		}
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
		}
		if (p1.EditorControl == null)
		{
			return;
		}
		p1.Result = false;
		XTextElementList xTextElementList = new XTextElementList();
		if (p1.Parameter is XTextTableRowElement)
		{
			xTextElementList.Add((XTextTableRowElement)p1.Parameter);
		}
		else if (p1.Parameter is XTextElementList)
		{
			XTextTableElement xTextTableElement = null;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((XTextElementList)p1.Parameter).z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextTableRowElement)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)current;
					if (xTextTableElement == null)
					{
						xTextTableElement = xTextTableRowElement.z0gr();
					}
					else if (xTextTableRowElement.z0gr() != xTextTableElement)
					{
						throw new ArgumentOutOfRangeException("不是同一个表格的表格行");
					}
					xTextElementList.Add(xTextTableRowElement);
				}
			}
		}
		else if (p1.Parameter is z0ZzZzqmj)
		{
			z0ZzZzqmj z0ZzZzqmj2 = (z0ZzZzqmj)p1.Parameter;
			XTextTableElement xTextTableElement2 = z0ZzZzqmj2.z0iek();
			if (xTextTableElement2 == null)
			{
				xTextTableElement2 = p1.Document.z0ki(z0ZzZzqmj2.z0uek()) as XTextTableElement;
			}
			if (xTextTableElement2 != null && xTextTableElement2.z0stk().Count > 0)
			{
				int num = z0ZzZzqmj2.z0eek();
				if (num < 0)
				{
					num = 0;
				}
				if (num > xTextTableElement2.z0stk().Count)
				{
					num = xTextTableElement2.z0stk().Count - 1;
				}
				for (int i = 0; i < z0ZzZzqmj2.z0yek(); i++)
				{
					int num2 = num + i;
					if (num2 >= 0 && num2 < xTextTableElement2.z0stk().Count)
					{
						xTextElementList.Add(xTextTableElement2.z0stk()[num2]);
					}
				}
			}
			if (xTextElementList.Count == 0)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement p2 = (XTextTableRowElement)z0bpk.Current;
				if (!p1.DocumentControler.z0lm(p2))
				{
					return;
				}
			}
		}
		else
		{
			xTextElementList = z0tek(p1.Document, p1: true);
		}
		if (xTextElementList == null || xTextElementList.Count <= 0)
		{
			return;
		}
		XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)xTextElementList[0];
		if (!p1.DocumentControler.z0lm(xTextTableRowElement2))
		{
			if (p1.Mode == (z0ZzZzmmj)2)
			{
				p1.Enabled = false;
			}
			return;
		}
		XTextTableElement xTextTableElement3 = xTextTableRowElement2.z0gr();
		if (!xTextTableElement3.z0ftk())
		{
			p1.Enabled = false;
			return;
		}
		if (xTextElementList.Count == xTextTableElement3.z0stk().Count)
		{
			z0rrk(p0, p1);
			if (p1.Result != null)
			{
				p1.Result = true;
			}
		}
		else
		{
			z0ZzZzgcj z0ZzZzgcj2 = new z0ZzZzgcj();
			p1.DocumentControler.z0mp();
			try
			{
				if (p1.Mode == (z0ZzZzmmj)2)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
					while (z0bpk.MoveNext())
					{
						((XTextTableRowElement)z0bpk.Current).z0wo(z0ZzZzgcj2, 1);
						if (z0ZzZzgcj2.Count > 0)
						{
							break;
						}
					}
				}
				else
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
					while (z0bpk.MoveNext() && !((XTextTableRowElement)z0bpk.Current).z0wo(z0ZzZzgcj2, 10))
					{
					}
				}
			}
			finally
			{
				p1.DocumentControler.z0on();
			}
			if (z0ZzZzgcj2.Count > 0)
			{
				if (p1.Mode == (z0ZzZzmmj)2)
				{
					p1.Enabled = false;
				}
				else if (p1.ShowUI)
				{
					p1.Document.z0vek(z0ZzZzgcj2);
				}
				p1.Result = false;
			}
			else
			{
				if (p1.Mode == (z0ZzZzmmj)2)
				{
					p1.Enabled = true;
					return;
				}
				p1.Result = xTextTableElement3.z0oek(xTextTableElement3.z0stk().IndexOf(xTextTableRowElement2), xTextElementList.Count, p2: true, null);
			}
		}
		if (p1.Parameter is z0ZzZzqmj)
		{
			((z0ZzZzqmj)p1.Parameter).z0eek((bool)p1.Result);
		}
		if (p1.Result == null)
		{
			p1.Result = false;
		}
		if ((bool)p1.Result)
		{
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("Table_InsertRowsToPageBottom", FunctionID = 92)]
	private void z0pek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = true;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5 || p1.Document.z0oik() != PageContentPartyStyle.Body)
			{
				return;
			}
			XTextTableElement xTextTableElement = z0eek(p1, p1: true);
			if (xTextTableElement == null || ((XTextElement)xTextTableElement).z0atk() != PageContentPartyStyle.Body)
			{
				p1.Enabled = false;
				return;
			}
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextTableElement.z0stk().LastElement;
			float num = 0f;
			for (int num2 = p1.Document.z0suk().Count - 1; num2 >= 0; num2--)
			{
				z0ZzZzwrj z0ZzZzwrj2 = p1.Document.z0suk()[num2];
				float num3 = z0ZzZzwrj2.z0irk();
				if (((XTextElement)xTextTableRowElement).z0ltk() + xTextTableRowElement.Height >= num3 + 2f)
				{
					float num4 = z0ZzZzwrj2.z0urk();
					if (z0ZzZzwrj2.z0krk().z0iek() > 0f)
					{
						num4 -= z0ZzZzwrj2.z0krk().z0iek();
					}
					float num5 = num4 + num3 - (((XTextElement)xTextTableRowElement).z0ltk() + xTextTableRowElement.Height);
					XTextElementList xTextElementList = new XTextElementList();
					while ((double)num5 > (double)num * 1.1)
					{
						XTextTableRowElement xTextTableRowElement2 = xTextTableRowElement.z0zek();
						xTextTableRowElement2.NewPage = false;
						if (XTextTableElement.z0ttk != null && xTextTableRowElement2.z0qr("$DCADVISE$"))
						{
							xTextTableRowElement2.Attributes.z0rek("$DCADVISE$");
						}
						xTextTableRowElement2.z0nu(xTextTableElement);
						xTextTableRowElement2.z0bt(p1.Document);
						xTextTableRowElement2.z0nu(xTextTableElement);
						z0ZzZzafh.z0rek(p1.Document, xTextTableRowElement2.z0rek(), p2: false);
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement2.z0rek().z0ltk())
						{
							while (z0bpk.MoveNext())
							{
								((XTextTableCellElement)z0bpk.Current).z0ct();
							}
						}
						xTextTableRowElement2.z0hrk();
						num = xTextTableRowElement2.Height;
						if (num5 < num - 1f)
						{
							break;
						}
						xTextElementList.Add(xTextTableRowElement2);
						num5 -= num;
					}
					if (xTextElementList.Count > 0)
					{
						xTextTableElement.z0yek(xTextTableElement.z0stk().Count, xTextElementList, p2: true, null, p4: false);
						p1.Document.Modified = true;
						p1.RefreshLevel = (z0ZzZzwmj)2;
						p1.Result = xTextElementList;
					}
					break;
				}
			}
		}
	}

	private bool z0eek(z0ZzZzomj p0, bool p1, bool p2)
	{
		if (p0.EditorControl == null)
		{
			return false;
		}
		XTextTableRowElement xTextTableRowElement = null;
		int p3 = 1;
		if (p0.Parameter is XTextTableRowElement)
		{
			xTextTableRowElement = (XTextTableRowElement)p0.Parameter;
		}
		else if (p0.Parameter is z0ZzZzqmj)
		{
			z0ZzZzqmj z0ZzZzqmj2 = (z0ZzZzqmj)p0.Parameter;
			p3 = z0ZzZzqmj2.z0yek();
			XTextTableElement xTextTableElement = z0ZzZzqmj2.z0iek();
			if (xTextTableElement == null)
			{
				xTextTableElement = p0.Document.z0ki(z0ZzZzqmj2.z0uek()) as XTextTableElement;
			}
			if (xTextTableElement != null && xTextTableElement.z0stk().Count > 0)
			{
				int num = z0ZzZzqmj2.z0eek();
				xTextTableRowElement = ((num < 0) ? ((XTextTableRowElement)xTextTableElement.z0stk()[0]) : ((num < xTextTableElement.z0stk().Count) ? ((XTextTableRowElement)xTextTableElement.z0stk()[num]) : ((XTextTableRowElement)xTextTableElement.z0stk().LastElement)));
			}
		}
		if (xTextTableRowElement == null)
		{
			XTextElementList xTextElementList = z0tek(p0.Document, p1: true);
			if (xTextElementList == null || xTextElementList.Count == 0)
			{
				return false;
			}
			xTextTableRowElement = ((!p1) ? ((XTextTableRowElement)xTextElementList.LastElement) : ((XTextTableRowElement)xTextElementList.z0krk()));
		}
		if (xTextTableRowElement != null)
		{
			if (!p0.DocumentControler.z0bm(xTextTableRowElement.z0gr(), 0, typeof(XTextTableRowElement)))
			{
				return false;
			}
			if (xTextTableRowElement.HeaderStyle && p1)
			{
				return false;
			}
		}
		if (p2)
		{
			return xTextTableRowElement?.z0gr().z0ktk() ?? false;
		}
		XTextTableElement xTextTableElement2 = xTextTableRowElement.z0gr();
		if (!xTextTableElement2.z0ktk())
		{
			return false;
		}
		p0.Result = z0eek(xTextTableElement2, xTextTableRowElement, p1, p3: false, p3);
		if (p0.Result == null)
		{
			p0.RefreshLevel = (z0ZzZzwmj)0;
			return false;
		}
		if (p0.Parameter is z0ZzZzqmj)
		{
			((z0ZzZzqmj)p0.Parameter).z0eek(p0: true);
		}
		p0.RefreshLevel = (z0ZzZzwmj)2;
		return true;
	}

	[z0ZzZzimj("Table_CellGridLine")]
	private void z0mek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			p1.Checked = false;
			if (p1.Document == null)
			{
				return;
			}
			XTextElementList xTextElementList = z0rek(p1.Document, p1: true);
			if (xTextElementList == null || xTextElementList.Count <= 0)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			if (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				p1.Enabled = true;
				p1.Checked = xTextTableCellElement.z0aek().z0atk != ContentGridLineType.None;
			}
			return;
		}
		if (p1.Mode != (z0ZzZzmmj)5)
		{
			return;
		}
		p1.Result = false;
		p1.RefreshLevel = (z0ZzZzwmj)2;
		XTextElementList xTextElementList2 = z0rek(p1.Document, p1: false);
		if (xTextElementList2 == null || xTextElementList2.Count <= 0)
		{
			return;
		}
		ContentGridLineType contentGridLineType = ContentGridLineType.None;
		if (p1.Parameter is ContentGridLineType)
		{
			contentGridLineType = (ContentGridLineType)p1.Parameter;
		}
		else if (p1.Parameter is string)
		{
			try
			{
				contentGridLineType = (ContentGridLineType)Enum.Parse(typeof(ContentGridLineType), (string)p1.Parameter, true);
			}
			catch
			{
			}
		}
		else
		{
			contentGridLineType = xTextElementList2[0].z0aek().z0atk;
			if (!p1.ShowUI)
			{
				contentGridLineType = ((contentGridLineType == ContentGridLineType.None) ? ContentGridLineType.ExtentToBottom : ContentGridLineType.None);
			}
		}
		Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement2.z0aek().z0atk != contentGridLineType)
				{
					DocumentContentStyle documentContentStyle = xTextTableCellElement2.z0aek().z0yek();
					documentContentStyle.z0eek(p0: true);
					documentContentStyle.GridLineType = contentGridLineType;
					dictionary[xTextTableCellElement2] = p1.Document.z0gnk().GetStyleIndex(documentContentStyle);
				}
			}
		}
		if (dictionary.Count > 0)
		{
			p1.Result = true;
			p1.Document.z0rek(dictionary, p1: true, p2: false, p1.Name);
		}
	}

	[z0ZzZzimj("AlignBottomCenter")]
	private void z0nek(object p0, z0ZzZzomj p1)
	{
		z0eek(ContentAlignment.BottomCenter, p1);
	}

	[z0ZzZzimj("Table_SplitCellExt", ReturnValueType = typeof(XTextTableCellElement))]
	private void z0bek(object p0, z0ZzZzomj p1)
	{
		z0ZzZzamj z0ZzZzamj2 = null;
		if (p1.Mode == (z0ZzZzmmj)2 || p1.Mode == (z0ZzZzmmj)5)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			if (p1.Parameter is z0ZzZzamj)
			{
				z0ZzZzamj2 = (z0ZzZzamj)p1.Parameter;
				if (z0ZzZzamj2.z0tek() == null)
				{
					z0ZzZzamj2.z0eek(p1.Document.z0ki(z0ZzZzamj2.z0yek()) as XTextTableCellElement);
				}
			}
			else
			{
				z0ZzZzamj2 = new z0ZzZzamj();
				if (p1.Document.z0cuk().z0irk() != null && p1.Document.z0cuk().z0irk().Count > 1)
				{
					z0ZzZzamj2.z0eek((XTextTableCellElement)null);
				}
				else
				{
					z0ZzZzamj2.z0eek(z0eek(p1.Document));
				}
			}
			if (z0ZzZzamj2.z0tek() != null && !p1.DocumentControler.z0np(z0ZzZzamj2.z0tek()))
			{
				z0ZzZzamj2.z0eek((XTextTableCellElement)null);
			}
		}
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = z0ZzZzamj2 != null && z0ZzZzamj2.z0tek() != null;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = null;
			if (z0ZzZzamj2 == null || z0ZzZzamj2.z0tek() == null)
			{
				return;
			}
			if (p1.Parameter is string)
			{
				string text = (string)p1.Parameter;
				int num = text.IndexOf(',');
				if (num >= 0)
				{
					try
					{
						z0ZzZzamj2.z0rek(int.Parse(text.Substring(0, num)));
						z0ZzZzamj2.z0eek(int.Parse(text.Substring(num + 1)));
					}
					catch (Exception ex)
					{
						z0ZzZzqok.z0rek.z0sh("Table_SplitCellExt:" + ex.Message);
						z0ZzZzamj2.z0rek(z0ZzZzamj2.z0tek().RowSpan);
						z0ZzZzamj2.z0eek(z0ZzZzamj2.z0tek().ColSpan);
					}
				}
			}
			if (z0ZzZzamj2.z0eek() < 1)
			{
				z0ZzZzamj2.z0rek(z0ZzZzamj2.z0tek().RowSpan);
			}
			if (z0ZzZzamj2.z0rek() < 1)
			{
				z0ZzZzamj2.z0eek(z0ZzZzamj2.z0tek().ColSpan);
			}
			if (z0ZzZzamj2.z0tek().z0rek(z0ZzZzamj2.z0eek(), z0ZzZzamj2.z0rek(), p2: true))
			{
				p1.Result = z0ZzZzamj2.z0tek();
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("AlignBottomLeft")]
	private void z0vek(object p0, z0ZzZzomj p1)
	{
		z0eek(ContentAlignment.BottomLeft, p1);
	}

	public static XTextElementList z0eek(XTextTableElement p0, XTextTableRowElement p1, bool p2, bool p3, int p4)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("table");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("currentRow");
		}
		if (p1.z0gr() != p0)
		{
			throw new ArgumentOutOfRangeException("currentRow");
		}
		XTextElementList xTextElementList = new XTextElementList();
		XTextDocument xTextDocument = p0.z0jr();
		bool flag = xTextDocument.z0xu();
		bool autoFixElementIDWhenInsertElements = xTextDocument.z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements;
		if (autoFixElementIDWhenInsertElements)
		{
			xTextDocument.z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements = false;
		}
		try
		{
			z0ZzZzjpk z0ZzZzjpk2 = null;
			z0ZzZzvxj z0ZzZzvxj2 = null;
			if (!flag)
			{
				z0ZzZzjpk2 = xTextDocument.z0ru();
				z0ZzZzvxj2 = xTextDocument.z0bek(z0ZzZzjpk2, (z0ZzZzcxj)0);
			}
			XTextContainerElement.z0btk = false;
			int num = 1;
			for (int i = 0; i < p4; i++)
			{
				XTextTableRowElement xTextTableRowElement = p1.z0zek();
				if (XTextTableElement.z0ttk != null && xTextTableRowElement.z0qr("$DCADVISE$"))
				{
					xTextTableRowElement.Attributes.z0rek("$DCADVISE$");
				}
				if (autoFixElementIDWhenInsertElements)
				{
					z0ZzZzcoj.z0tek(xTextTableRowElement, xTextDocument, num);
					if (z0ZzZzcoj.z0vek != null)
					{
						z0ZzZzcoj.z0vek.Clear();
						z0ZzZzcoj.z0vek = null;
					}
				}
				xTextTableRowElement.z0li();
				if (z0ZzZzvxj2 != null)
				{
					z0ZzZzvxj2.z0hyk = xTextTableRowElement;
					xTextTableRowElement.z0mr(z0ZzZzvxj2);
				}
				xTextElementList.Add(xTextTableRowElement);
				num++;
			}
			z0ZzZzjpk2?.Dispose();
		}
		finally
		{
			XTextContainerElement.z0btk = true;
		}
		if (p2)
		{
			p0.z0yek(p0.z0stk().IndexOf(p1), xTextElementList, p2: true, null, p3);
		}
		else
		{
			p0.z0yek(p0.z0stk().IndexOf(p1) + 1, xTextElementList, p2: true, null, p3);
		}
		if (autoFixElementIDWhenInsertElements)
		{
			xTextDocument.z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements = true;
		}
		return xTextElementList;
	}

	[z0ZzZzimj("AlignTopLeft")]
	private void z0cek(object p0, z0ZzZzomj p1)
	{
		z0eek(ContentAlignment.TopLeft, p1);
	}

	[z0ZzZzimj("Table_InsertRowUp", ReturnValueType = typeof(XTextTableRowElement), FunctionID = 92)]
	private void z0xek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = z0eek(p1, p1: true, p2: true);
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0eek(p1, p1: true, p2: false);
		}
	}

	protected override z0ZzZzvmj z0qz()
	{
		z0ZzZzvmj obj = new z0ZzZzvmj();
		z0ZzZzcmj.z0rek(obj, "AlignBottomCenter", z0nek);
		z0ZzZzcmj.z0rek(obj, "AlignBottomLeft", z0vek);
		z0ZzZzcmj.z0rek(obj, "AlignBottomRight", z0uek);
		z0ZzZzcmj.z0rek(obj, "AlignMiddleCenter", z0lrk);
		z0ZzZzcmj.z0rek(obj, "AlignMiddleLeft", z0hrk);
		z0ZzZzcmj.z0rek(obj, "AlignMiddleRight", z0jrk);
		z0ZzZzcmj.z0rek(obj, "AlignTopCenter", z0eek);
		z0ZzZzcmj.z0rek(obj, "AlignTopLeft", z0cek);
		z0ZzZzcmj.z0rek(obj, "AlignTopRight", z0ark);
		z0ZzZzcmj.z0rek(obj, "Table_CellGridLine", z0mek);
		z0ZzZzcmj.z0rek(obj, "Table_DeleteColumn", z0iek_jiejie20260327142557);
		z0ZzZzcmj.z0rek(obj, "Table_DeleteRow", z0oek);
		z0ZzZzcmj.z0rek(obj, "Table_DeleteTable", z0rrk);
		z0ZzZzcmj.z0rek(obj, "Table_HeaderRow", z0qrk);
		z0ZzZzcmj.z0rek(obj, "Table_IncreaseRowHeightToPageBottom", z0srk);
		z0ZzZzcmj.z0rek(obj, "Table_InsertColumnLeft", z0krk);
		z0ZzZzcmj.z0rek(obj, "Table_InsertColumnRight", z0wrk);
		z0ZzZzcmj.z0rek(obj, "Table_InsertRowDown", z0yek);
		z0ZzZzcmj.z0rek(obj, "Table_InsertRowsToPageBottom", z0pek);
		z0ZzZzcmj.z0rek(obj, "Table_InsertRowUp", z0xek);
		z0ZzZzcmj.z0rek(obj, "Table_InsertTable", z0tek);
		z0ZzZzcmj.z0rek(obj, "Table_MergeCell", z0erk);
		z0ZzZzcmj.z0rek(obj, "Table_RemoveEmptyRowsInLastPage", z0drk);
		z0ZzZzcmj.z0rek(obj, "Table_ResetTableStyle", z0frk);
		z0ZzZzcmj.z0rek(obj, "Table_SetCellGridLine", z0grk_jiejie20260327142557);
		z0ZzZzcmj.z0rek(obj, "Table_SplitCell", z0zek);
		z0ZzZzcmj.z0rek(obj, "Table_SplitCellExt", z0bek);
		z0ZzZzcmj.z0rek(obj, "Table_SplitRowsByContentLines", z0rek);
		return obj;
	}

	[z0ZzZzimj("Table_SplitCell", ReturnValueType = typeof(XTextTableCellElement))]
	private void z0zek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = false;
			if (p1.Document == null)
			{
				return;
			}
			if (p1.Document.z0cuk().z0irk() != null && p1.Document.z0cuk().z0irk().Count > 1)
			{
				p1.Enabled = false;
				return;
			}
			XTextTableCellElement xTextTableCellElement = z0eek(p1.Document);
			if (xTextTableCellElement != null && (xTextTableCellElement.RowSpan > 1 || xTextTableCellElement.ColSpan > 1))
			{
				p1.Enabled = p1.DocumentControler.z0np(xTextTableCellElement);
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = null;
			p1.RefreshLevel = (z0ZzZzwmj)0;
			XTextTableCellElement xTextTableCellElement2 = z0eek(p1.Document);
			if (xTextTableCellElement2 != null && (xTextTableCellElement2.RowSpan > 1 || xTextTableCellElement2.ColSpan > 1) && xTextTableCellElement2.z0eek(1, 1, p2: true, null))
			{
				p1.Result = xTextTableCellElement2;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	private static void z0eek(ContentAlignment p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			p1.Checked = false;
			if (p1.EditorControl == null)
			{
				return;
			}
			XTextElementList xTextElementList = z0rek(p1.Document, p1: true);
			if (xTextElementList == null || xTextElementList.Count <= 0)
			{
				return;
			}
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElementList[0];
			XTextElementList xTextElementList2 = ((XTextContentElement)xTextTableCellElement).z0mek();
			if (xTextElementList2 == null || xTextElementList2.Count <= 0)
			{
				return;
			}
			{
				foreach (XTextElement item in xTextElementList2.z0xrk())
				{
					if (!(item is XTextParagraphFlagElement xTextParagraphFlagElement) || !p1.DocumentControler.z0np(xTextParagraphFlagElement))
					{
						continue;
					}
					p1.Enabled = true;
					switch (xTextTableCellElement.z0cr())
					{
					case VerticalAlignStyle.Top:
						switch (xTextParagraphFlagElement.z0aek().z0tuk)
						{
						case DocumentContentAlignment.Left:
							p1.Checked = p0 == ContentAlignment.TopLeft;
							break;
						case DocumentContentAlignment.Center:
							p1.Checked = p0 == ContentAlignment.TopCenter;
							break;
						case DocumentContentAlignment.Right:
							p1.Checked = p0 == ContentAlignment.TopRight;
							break;
						case DocumentContentAlignment.Justify:
							p1.Checked = p0 == ContentAlignment.TopCenter;
							break;
						}
						break;
					case VerticalAlignStyle.Middle:
						switch (xTextParagraphFlagElement.z0aek().z0tuk)
						{
						case DocumentContentAlignment.Left:
							p1.Checked = p0 == ContentAlignment.MiddleLeft;
							break;
						case DocumentContentAlignment.Center:
							p1.Checked = p0 == ContentAlignment.MiddleCenter;
							break;
						case DocumentContentAlignment.Right:
							p1.Checked = p0 == ContentAlignment.MiddleRight;
							break;
						case DocumentContentAlignment.Justify:
							p1.Checked = p0 == ContentAlignment.MiddleCenter;
							break;
						}
						break;
					case VerticalAlignStyle.Bottom:
						switch (xTextParagraphFlagElement.z0aek().z0tuk)
						{
						case DocumentContentAlignment.Left:
							p1.Checked = p0 == ContentAlignment.BottomLeft;
							break;
						case DocumentContentAlignment.Center:
							p1.Checked = p0 == ContentAlignment.BottomCenter;
							break;
						case DocumentContentAlignment.Right:
							p1.Checked = p0 == ContentAlignment.BottomRight;
							break;
						case DocumentContentAlignment.Justify:
							p1.Checked = p0 == ContentAlignment.BottomCenter;
							break;
						}
						break;
					}
					break;
				}
				return;
			}
		}
		if (p1.Mode != (z0ZzZzmmj)5)
		{
			return;
		}
		p1.Result = false;
		p1.RefreshLevel = (z0ZzZzwmj)2;
		XTextElementList xTextElementList3 = z0rek(p1.Document, p1: false);
		if (xTextElementList3 == null || xTextElementList3.Count <= 0)
		{
			return;
		}
		Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
		VerticalAlignStyle verticalAlignStyle = VerticalAlignStyle.Middle;
		DocumentContentAlignment documentContentAlignment = DocumentContentAlignment.Left;
		switch (p0)
		{
		case ContentAlignment.BottomCenter:
			verticalAlignStyle = VerticalAlignStyle.Bottom;
			documentContentAlignment = DocumentContentAlignment.Center;
			break;
		case ContentAlignment.BottomLeft:
			verticalAlignStyle = VerticalAlignStyle.Bottom;
			documentContentAlignment = DocumentContentAlignment.Left;
			break;
		case ContentAlignment.BottomRight:
			verticalAlignStyle = VerticalAlignStyle.Bottom;
			documentContentAlignment = DocumentContentAlignment.Right;
			break;
		case ContentAlignment.MiddleCenter:
			verticalAlignStyle = VerticalAlignStyle.Middle;
			documentContentAlignment = DocumentContentAlignment.Center;
			break;
		case ContentAlignment.MiddleLeft:
			verticalAlignStyle = VerticalAlignStyle.Middle;
			documentContentAlignment = DocumentContentAlignment.Left;
			break;
		case ContentAlignment.MiddleRight:
			verticalAlignStyle = VerticalAlignStyle.Middle;
			documentContentAlignment = DocumentContentAlignment.Right;
			break;
		case ContentAlignment.TopCenter:
			verticalAlignStyle = VerticalAlignStyle.Top;
			documentContentAlignment = DocumentContentAlignment.Center;
			break;
		case ContentAlignment.TopLeft:
			verticalAlignStyle = VerticalAlignStyle.Top;
			documentContentAlignment = DocumentContentAlignment.Left;
			break;
		case ContentAlignment.TopRight:
			verticalAlignStyle = VerticalAlignStyle.Top;
			documentContentAlignment = DocumentContentAlignment.Right;
			break;
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList3.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement2.z0bek() || !p1.DocumentControler.z0np(xTextTableCellElement2))
				{
					continue;
				}
				if (xTextTableCellElement2.z0cr() != verticalAlignStyle)
				{
					DocumentContentStyle documentContentStyle = xTextTableCellElement2.z0aek().z0yek();
					documentContentStyle.z0eek(p0: true);
					documentContentStyle.VerticalAlign = verticalAlignStyle;
					dictionary[xTextTableCellElement2] = p1.Document.z0gnk().GetStyleIndex(documentContentStyle);
				}
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = ((XTextContentElement)xTextTableCellElement2).z0krk().z0ltk();
				while (z0bpk2.MoveNext())
				{
					XTextParagraphFlagElement xTextParagraphFlagElement2 = (XTextParagraphFlagElement)z0bpk2.Current;
					xTextParagraphFlagElement2.z0ptk();
					if (p1.DocumentControler.z0np(xTextParagraphFlagElement2) && xTextParagraphFlagElement2.z0aek().z0tuk != documentContentAlignment)
					{
						DocumentContentStyle documentContentStyle2 = xTextParagraphFlagElement2.z0aek().z0yek();
						documentContentStyle2.z0eek(p0: true);
						documentContentStyle2.Align = documentContentAlignment;
						dictionary[xTextParagraphFlagElement2] = p1.Document.z0gnk().GetStyleIndex(documentContentStyle2);
					}
				}
			}
		}
		if (dictionary.Count > 0)
		{
			p1.Result = true;
			p1.Document.z0rek(dictionary, p1: true, p2: true, p1.Name);
		}
	}

	[z0ZzZzimj("AlignMiddleCenter")]
	private void z0lrk(object p0, z0ZzZzomj p1)
	{
		z0eek(ContentAlignment.MiddleCenter, p1);
	}

	[z0ZzZzimj("Table_InsertColumnLeft", ReturnValueType = typeof(XTextTableColumnElement), FunctionID = 92)]
	private void z0krk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			z0eek(p1, p1.Document, p2: true);
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = z0eek(p1, p1.Document, p2: true);
			if (p1.Result == null)
			{
				p1.RefreshLevel = (z0ZzZzwmj)0;
			}
			else
			{
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("AlignMiddleRight")]
	private void z0jrk(object p0, z0ZzZzomj p1)
	{
		z0eek(ContentAlignment.MiddleRight, p1);
	}

	[z0ZzZzimj("AlignMiddleLeft")]
	private void z0hrk(object p0, z0ZzZzomj p1)
	{
		z0eek(ContentAlignment.MiddleLeft, p1);
	}

	internal static int z0rek(XTextDocument p0)
	{
		XTextElementList xTextElementList = p0.z0xyk().z0be();
		XTextTableElement xTextTableElement = null;
		for (int num = xTextElementList.Count - 1; num >= 0; num--)
		{
			if (xTextElementList[num] is XTextTableElement)
			{
				xTextTableElement = (XTextTableElement)xTextElementList[num];
				break;
			}
		}
		if (xTextTableElement == null)
		{
			return 0;
		}
		XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextTableElement.z0stk().LastElement;
		float num2 = 0f;
		int num3 = 0;
		for (int num4 = p0.z0suk().Count - 1; num4 >= 0; num4--)
		{
			z0ZzZzwrj z0ZzZzwrj2 = p0.z0suk()[num4];
			float num5 = z0ZzZzwrj2.z0irk();
			if (((XTextElement)xTextTableRowElement).z0ltk() + xTextTableRowElement.Height >= num5 + 2f)
			{
				float num6 = z0ZzZzwrj2.z0urk();
				if (z0ZzZzwrj2.z0krk().z0iek() > 0f)
				{
					num6 -= z0ZzZzwrj2.z0krk().z0iek();
				}
				float num7 = num6 + num5 - (((XTextElement)xTextTableRowElement).z0ltk() + xTextTableRowElement.Height);
				XTextElementList xTextElementList2 = new XTextElementList();
				while ((double)num7 > (double)num2 * 1.1)
				{
					XTextTableRowElement xTextTableRowElement2 = xTextTableRowElement.z0eek(TableRowCloneType.Default);
					xTextTableRowElement2.NewPage = false;
					if (XTextTableElement.z0ttk != null && xTextTableRowElement2.z0qr("$DCADVISE$"))
					{
						xTextTableRowElement2.Attributes.z0rek("$DCADVISE$");
					}
					xTextTableRowElement2.z0nu(xTextTableElement);
					xTextTableRowElement2.z0bt(p0);
					xTextTableRowElement2.z0nu(xTextTableElement);
					z0ZzZzafh.z0rek(p0, xTextTableRowElement2.z0rek(), p2: false);
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement2.z0rek().z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							((XTextTableCellElement)z0bpk.Current).z0ct();
						}
					}
					xTextTableRowElement2.z0hrk();
					num2 = xTextTableRowElement2.Height;
					if (num7 < num2 - 1f)
					{
						break;
					}
					xTextElementList2.Add(xTextTableRowElement2);
					xTextTableElement.z0stk().Add(xTextTableRowElement2);
					num7 -= num2;
					num3++;
				}
				if (xTextElementList2.Count > 0)
				{
					p0.z0kzk = xTextElementList2;
				}
				xTextElementList2 = null;
				break;
			}
		}
		return num3;
	}

	[z0ZzZzimj("Table_SetCellGridLine")]
	private void z0grk_jiejie20260327142557(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			XTextElementList xTextElementList = z0eek(p1.Document, p1: true);
			p1.Enabled = xTextElementList != null && xTextElementList.Count > 0;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextElementList xTextElementList2 = z0eek(p1.Document, p1: true);
			if (xTextElementList2 != null && xTextElementList2.Count > 0)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList2[0];
				p1.Document.z0ytk();
				bool num = xTextTableRowElement.z0eek(0f / 0f, p1: true, p2: true);
				p1.Document.z0nuk();
				if (num)
				{
					p1.Document.Modified = true;
					p1.Document.OnDocumentContentChanged();
					p1.RefreshLevel = (z0ZzZzwmj)2;
					p1.Result = xTextTableRowElement;
				}
			}
		}
	}

	[z0ZzZzimj("Table_ResetTableStyle")]
	private void z0frk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextTableElement xTextTableElement = z0eek(p1, p1: false);
			if (xTextTableElement == null)
			{
				return;
			}
			DocumentContentStyle documentContentStyle = new DocumentContentStyle();
			documentContentStyle.BorderColor = Color.Black;
			documentContentStyle.BorderStyle = DashStyle.Solid;
			documentContentStyle.BorderWidth = 1f;
			documentContentStyle.BorderLeft = true;
			documentContentStyle.BorderTop = true;
			documentContentStyle.BorderRight = true;
			documentContentStyle.BorderBottom = true;
			int styleIndex = p1.Document.z0gnk().GetStyleIndex(documentContentStyle);
			xTextTableElement.z0oek(-1);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0zek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement obj = (XTextTableCellElement)z0bpk.Current;
					obj.z0cek(p1.Document.z0dik());
					obj.z0oek(styleIndex);
				}
			}
			if (xTextTableElement.z0srk().Count > 0)
			{
				float num = (((XTextElement)xTextTableElement.z0jy()).z0ork() - 3f) / (float)xTextTableElement.z0srk().Count;
				num = Math.Max(50f, num);
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0srk().z0ltk();
				while (z0bpk.MoveNext())
				{
					((XTextTableColumnElement)z0bpk.Current).Width = num;
				}
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0stk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					((XTextTableRowElement)z0bpk.Current).SpecifyHeight = 0f;
				}
			}
			p1.Document.z0imk().Clear();
			xTextTableElement.z0oe();
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Document.Modified = true;
			p1.Document.OnSelectionChanged();
			p1.Document.OnDocumentContentChanged();
		}
	}

	[z0ZzZzimj("Table_RemoveEmptyRowsInLastPage")]
	private void z0drk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5 || p1.Document == null)
			{
				return;
			}
			XTextTableElement xTextTableElement = (XTextTableElement)p1.Document.z0xyk().z0zek(typeof(XTextTableElement));
			if (xTextTableElement == null)
			{
				return;
			}
			float num = p1.Document.z0suk().z0tek().z0irk() - ((XTextElement)xTextTableElement).z0ltk();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0stk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
				if (xTextTableRowElement.z0yt() > num - 1f)
				{
					int num2 = xTextTableElement.z0stk().IndexOf(xTextTableRowElement);
					xTextTableElement.z0stk().z0irk(num2, xTextTableElement.z0stk().Count - num2);
					p1.Document.Modified = true;
					xTextTableElement.z0oe();
					p1.Document.z0imk().Clear();
					p1.RefreshLevel = (z0ZzZzwmj)2;
					p1.Result = xTextTableElement;
					break;
				}
			}
		}
	}

	[z0ZzZzimj("Table_IncreaseRowHeightToPageBottom")]
	private void z0srk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = true;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextTableElement xTextTableElement = z0eek(p1, p1: true);
			if (xTextTableElement == null || ((XTextElement)xTextTableElement).z0atk() != PageContentPartyStyle.Body)
			{
				p1.Enabled = false;
				return;
			}
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextTableElement.z0stk().LastElement;
			for (int num = p1.Document.z0suk().Count - 1; num >= 0; num--)
			{
				z0ZzZzwrj z0ZzZzwrj2 = p1.Document.z0suk()[num];
				float num2 = z0ZzZzwrj2.z0irk();
				if (((XTextElement)xTextTableRowElement).z0ltk() + xTextTableRowElement.Height >= num2 + 2f)
				{
					float num3 = z0ZzZzwrj2.z0urk();
					if (z0ZzZzwrj2.z0krk().z0iek() > 0f)
					{
						num3 = num3 - z0ZzZzwrj2.z0krk().z0iek() - 3f;
					}
					float num4 = z0ZzZzwrj2.z0irk() + num3 - ((XTextElement)xTextTableRowElement).z0ltk();
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
							if (!xTextTableCellElement.z0bek())
							{
								if (xTextTableCellElement.GridLine != null && xTextTableCellElement.GridLine.z0uek() && xTextTableCellElement.GridLine.z0zek() > 0f)
								{
									num4 = (float)(int)Math.Floor((num4 - xTextTableCellElement.z0aek().z0quk) / xTextTableCellElement.GridLine.z0zek()) * xTextTableCellElement.GridLine.z0zek();
									break;
								}
								float num5 = xTextTableCellElement.z0eek(z0ZzZzwrj2);
								if (xTextTableCellElement.z0aek().z0zrk.A != 0 && xTextTableCellElement.z0aek().z0atk == ContentGridLineType.ExtentToBottom && num5 > 0f)
								{
									num4 = (float)(int)Math.Floor((num4 - xTextTableCellElement.z0aek().z0quk) / num5) * num5;
									break;
								}
							}
						}
					}
					xTextTableRowElement.z0eek(num4 - 6f, p1: true);
					p1.Document.Modified = true;
					p1.Result = xTextTableRowElement;
					break;
				}
			}
		}
	}

	public static XTextElementList z0tek(XTextDocument p0, bool p1)
	{
		XTextElementList xTextElementList = new XTextElementList();
		z0ZzZzhkh z0ZzZzhkh2 = p0.z0cuk();
		if (z0ZzZzhkh2.z0irk() != null && z0ZzZzhkh2.z0irk().Count > 0)
		{
			XTextTableElement xTextTableElement = ((XTextTableCellElement)z0ZzZzhkh2.z0irk()[0]).z0gr();
			if (p1)
			{
				XTextElement xTextElement = null;
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzhkh2.z0irk().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableRowElement xTextTableRowElement = ((XTextTableCellElement)z0bpk.Current).z0krk();
						if (xTextTableRowElement != xTextElement)
						{
							xTextElement = xTextTableRowElement;
							if (xTextTableRowElement.z0gr() == xTextTableElement)
							{
								xTextElementList.Add(xTextTableRowElement);
							}
						}
					}
				}
				xTextElement = null;
			}
			else
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzhkh2.z0irk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableColumnElement xTextTableColumnElement = ((XTextTableCellElement)z0bpk.Current).z0drk();
					if (xTextTableColumnElement.z0gr() == xTextTableElement && !xTextElementList.Contains(xTextTableColumnElement))
					{
						xTextElementList.Add(xTextTableColumnElement);
					}
				}
			}
		}
		else
		{
			XTextTableCellElement xTextTableCellElement = z0eek(p0);
			if (xTextTableCellElement != null && xTextTableCellElement.z0pek() >= 0)
			{
				XTextTableElement xTextTableElement2 = xTextTableCellElement.z0gr();
				if (p1)
				{
					for (int i = 0; i < xTextTableCellElement.RowSpan; i++)
					{
						xTextElementList.Add(xTextTableElement2.z0stk()[xTextTableCellElement.z0pek() + i]);
					}
				}
				else
				{
					for (int j = 0; j < xTextTableCellElement.ColSpan; j++)
					{
						xTextElementList.Add(xTextTableElement2.z0srk()[xTextTableCellElement.z0xek() + j]);
					}
				}
			}
		}
		return xTextElementList;
	}

	[z0ZzZzimj("AlignTopRight")]
	private void z0ark(object p0, z0ZzZzomj p1)
	{
		z0eek(ContentAlignment.TopRight, p1);
	}

	[z0ZzZzimj("Table_HeaderRow")]
	private void z0qrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Checked = false;
			XTextElementList xTextElementList = z0eek(p1.Document, p1: true);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				p1.Enabled = true;
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
				while (z0bpk.MoveNext())
				{
					if (((XTextTableRowElement)z0bpk.Current).HeaderStyle)
					{
						p1.Checked = true;
						break;
					}
				}
				return;
			}
			p1.Enabled = false;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextElementList xTextElementList2 = z0eek(p1.Document, p1: false);
			if (xTextElementList2 == null || xTextElementList2.Count <= 0)
			{
				return;
			}
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList2.LastElement;
			XTextTableElement xTextTableElement = xTextTableRowElement.z0gr();
			xTextElementList2 = new XTextElementList();
			for (int i = 0; i <= xTextTableElement.z0stk().IndexOf(xTextTableRowElement); i++)
			{
				xTextElementList2.Add(xTextTableElement.z0stk()[i]);
			}
			bool flag = false;
			if (p1.Parameter is bool)
			{
				flag = (bool)p1.Parameter;
			}
			else
			{
				flag = true;
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
				while (z0bpk.MoveNext())
				{
					if (((XTextTableRowElement)z0bpk.Current).HeaderStyle)
					{
						flag = false;
						break;
					}
				}
			}
			Dictionary<XTextTableRowElement, bool> dictionary = new Dictionary<XTextTableRowElement, bool>();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)z0bpk.Current;
					if (xTextTableRowElement2.HeaderStyle != flag)
					{
						dictionary[xTextTableRowElement2] = flag;
					}
				}
			}
			p1.Document.z0ytk();
			if (dictionary.Count > 0)
			{
				((XTextTableRowElement)xTextElementList2[0]).z0gr().z0tek(dictionary, p1: true);
			}
			p1.Document.z0nuk();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("Table_InsertColumnRight", ReturnValueType = typeof(XTextTableColumnElement), FunctionID = 92)]
	private void z0wrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			z0eek(p1, p1.Document, p2: false);
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = z0eek(p1, p1.Document, p2: false);
			if (p1.Result == null)
			{
				p1.RefreshLevel = (z0ZzZzwmj)0;
			}
			else
			{
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("Table_MergeCell", ReturnValueType = typeof(XTextTableCellElement), FunctionID = 90)]
	private void z0erk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode != (z0ZzZzmmj)2 && p1.Mode != (z0ZzZzmmj)5)
		{
			return;
		}
		if (p1.EditorControl == null)
		{
			p1.Enabled = false;
			return;
		}
		z0ZzZzfmj z0ZzZzfmj2 = p1.Parameter as z0ZzZzfmj;
		if (z0ZzZzfmj2 == null)
		{
			XTextDocumentContentElement xTextDocumentContentElement = p1.Document.z0jrk();
			if (xTextDocumentContentElement.z0oek().z0yek() == ContentRangeMode.Cell)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextDocumentContentElement.z0oek().z0irk().z0krk();
				XTextTableElement xTextTableElement = xTextTableCellElement.z0gr();
				if (xTextTableCellElement.z0pek() < xTextTableElement.z0stk().Count - 1 || xTextTableCellElement.z0xek() < xTextTableElement.z0srk().Count - 1)
				{
					p1.Enabled = p1.DocumentControler.z0np(xTextTableCellElement);
					if (p1.Enabled && p1.Mode == (z0ZzZzmmj)5)
					{
						XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextDocumentContentElement.z0oek().z0irk().z0krk();
						XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextDocumentContentElement.z0oek().z0irk().LastElement;
						if (xTextTableCellElement3.z0bek())
						{
							xTextTableCellElement3 = xTextTableCellElement3.z0hrk();
						}
						z0ZzZzfmj2 = new z0ZzZzfmj();
						z0ZzZzfmj2.z0eek(xTextTableCellElement2);
						z0ZzZzfmj2.z0rek(xTextTableCellElement3.z0pek() + xTextTableCellElement3.RowSpan - xTextTableCellElement2.z0pek());
						z0ZzZzfmj2.z0tek(xTextTableCellElement3.z0xek() + xTextTableCellElement3.ColSpan - xTextTableCellElement2.z0xek());
						int num = 0;
						int num2 = 0;
						for (int i = xTextTableCellElement2.z0drk().z0rek(); i < xTextTableCellElement3.z0drk().z0rek(); i++)
						{
							if (!(xTextTableCellElement2.z0gr().z0srk()[i] as XTextTableColumnElement).Visible)
							{
								num++;
							}
						}
						for (int j = xTextTableCellElement2.z0krk().z0grk(); j < xTextTableCellElement3.z0krk().z0grk(); j++)
						{
							if (!(xTextTableCellElement2.z0gr().z0stk()[j] as XTextTableRowElement).Visible)
							{
								num2++;
							}
						}
						z0ZzZzfmj2.z0yek(num2);
						z0ZzZzfmj2.z0eek(num);
					}
				}
			}
			else
			{
				p1.Enabled = false;
			}
		}
		else
		{
			if (z0ZzZzfmj2.z0yek() == null && !string.IsNullOrEmpty(z0ZzZzfmj2.z0eek()))
			{
				z0ZzZzfmj2.z0eek(p1.Document.z0ki(z0ZzZzfmj2.z0eek()) as XTextTableCellElement);
			}
			if (z0ZzZzfmj2.z0yek() != null && !z0ZzZzfmj2.z0yek().z0bek() && p1.DocumentControler.z0np(z0ZzZzfmj2.z0yek()) && z0ZzZzfmj2.z0uek() >= z0ZzZzfmj2.z0yek().RowSpan && z0ZzZzfmj2.z0rek() >= z0ZzZzfmj2.z0yek().ColSpan)
			{
				p1.Enabled = true;
			}
		}
		if (p1.Mode == (z0ZzZzmmj)5 && p1.Enabled)
		{
			z0ZzZzfmj2.z0yek().z0eek(z0ZzZzfmj2.z0uek(), z0ZzZzfmj2.z0rek(), p2: true, null);
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Result = z0ZzZzfmj2;
		}
	}

	[z0ZzZzimj("Table_DeleteTable", FunctionID = 91)]
	private void z0rrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Parameter is XTextTableElement)
			{
				p1.Enabled = p1.DocumentControler.z0lm((XTextTableElement)p1.Parameter);
				return;
			}
			XTextTableCellElement xTextTableCellElement = z0eek(p1.Document);
			if (xTextTableCellElement != null)
			{
				p1.Enabled = p1.DocumentControler.z0lm(xTextTableCellElement);
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = null;
			XTextTableElement xTextTableElement = null;
			xTextTableElement = ((!(p1.Parameter is XTextTableElement)) ? z0eek(p1.Document).z0gr() : ((XTextTableElement)p1.Parameter));
			z0ZzZzgcj z0ZzZzgcj2 = new z0ZzZzgcj();
			p1.DocumentControler.z0mp();
			try
			{
				xTextTableElement.z0wo(z0ZzZzgcj2, 100);
			}
			finally
			{
				p1.DocumentControler.z0on();
			}
			if (z0ZzZzgcj2 != null && z0ZzZzgcj2.Count > 0)
			{
				if (p1.ShowUI)
				{
					p1.Document.z0vek(z0ZzZzgcj2);
				}
			}
			else if (xTextTableElement.z0le(p0: true))
			{
				p1.Result = xTextTableElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	private XTextTableElement z0eek(z0ZzZzomj p0, bool p1)
	{
		if (p0.Parameter is XTextTableElement)
		{
			return (XTextTableElement)p0.Parameter;
		}
		if (p0.Parameter is string)
		{
			string text = (string)p0.Parameter;
			if (!string.IsNullOrEmpty(text))
			{
				return p0.Document.z0ki(text) as XTextTableElement;
			}
		}
		if (p0.Parameter is z0ZzZzqmj)
		{
			z0ZzZzqmj z0ZzZzqmj2 = (z0ZzZzqmj)p0.Parameter;
			if (z0ZzZzqmj2.z0iek() != null)
			{
				return z0ZzZzqmj2.z0iek();
			}
			if (!string.IsNullOrEmpty(z0ZzZzqmj2.z0uek()) && p0.Document.z0ki(z0ZzZzqmj2.z0uek()) is XTextTableElement result)
			{
				return result;
			}
		}
		XTextTableElement xTextTableElement = (XTextTableElement)p0.Document.z0bek(typeof(XTextTableElement));
		if (xTextTableElement != null)
		{
			return xTextTableElement;
		}
		if (p1)
		{
			return (XTextTableElement)p0.Document.z0xyk().z0zek(typeof(XTextTableElement));
		}
		return null;
	}
}
