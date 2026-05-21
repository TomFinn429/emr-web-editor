using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DCSoft;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;

namespace zzz;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class z0ZzZzplh : XTextElementList
{
	private enum z0ghj
	{
		z0eek,
		z0rek,
		z0tek,
		z0yek
	}

	private bool z0mrk;

	private new bool z0nrk;

	private int z0brk = z0gtk++;

	private new readonly XTextDocumentContentElement z0vrk;

	private float z0crk = -1f;

	private new bool z0xrk = true;

	private new bool z0zrk = true;

	private new int z0ltk = -2147483648;

	internal new bool z0ktk;

	private WeakReference z0jtk;

	internal new bool z0htk;

	private new static volatile int z0gtk;

	public void z0tek()
	{
		if (z0pek())
		{
			return;
		}
		z0rrk();
		z0crk = -1f;
		if (z0cek() && z0prk() != 0)
		{
			int num = z0pek(p0: false);
			if (num >= base.Count)
			{
				num = base.Count - 1;
			}
			num = z0tek(num, (z0ZzZzfxj)1, p2: true);
			z0tek(num, p1: false);
			return;
		}
		XTextElement p = base[z0erk()];
		XTextElement xTextElement = z0mek(p);
		if (xTextElement != null)
		{
			int num2 = z0lrk(xTextElement);
			if (num2 >= 0)
			{
				num2 = z0tek(num2, (z0ZzZzfxj)1, p2: true);
				z0tek(num2, p1: false);
			}
		}
	}

	public bool z0yek()
	{
		if (base.Count == 0)
		{
			return false;
		}
		XTextDocument xTextDocument = z0drk();
		if (xTextDocument == null || xTextDocument.z0xek() == null)
		{
			return false;
		}
		bool flag = xTextDocument.z0xek().z0bp() == FormViewMode.Strict;
		XTextElement xTextElement = z0ork();
		if (xTextElement != null)
		{
			int num = z0lrk(xTextElement);
			int num2 = 0;
			int num3 = base.Count - 1;
			for (int num4 = num - 1; num4 >= 0; num4--)
			{
				if (base[num4] is XTextParagraphFlagElement)
				{
					num2 = num4 + 1;
					break;
				}
				if (flag && base[num4] is XTextFieldBorderElement)
				{
					num2 = num4 + 1;
					break;
				}
			}
			for (int i = num; i < base.Count; i++)
			{
				if (base[i] is XTextParagraphFlagElement)
				{
					num3 = i;
					break;
				}
				if (flag && base[i] is XTextFieldBorderElement)
				{
					num3 = i;
					break;
				}
			}
			if (flag && num2 == num3 && base[num3] is XTextFieldBorderElement)
			{
				return false;
			}
			z0nrk = false;
			z0tek(num2, num3 - num2 + 1);
			z0zrk = true;
			return true;
		}
		return false;
	}

	public void z0tek(float p0, float p1)
	{
		z0yek(p0, p1);
	}

	public int z0uek()
	{
		if (z0ltk == -2147483648)
		{
			z0ltk = -1;
			if (XTextSignElement.z0eek)
			{
				for (int num = base.Count - 1; num >= 0; num--)
				{
					if (base[num] is XTextSignElement)
					{
						XTextDocument xTextDocument = z0drk();
						int num2 = xTextDocument.z0syk().z0oek();
						bool powerfulSignDocument = xTextDocument.z0hi().PowerfulSignDocument;
						int num3 = base[num].z0ntk();
						if (powerfulSignDocument)
						{
							z0ltk = num;
							break;
						}
						if (num3 >= num2)
						{
							z0ltk = num;
							break;
						}
					}
				}
			}
		}
		return z0ltk;
	}

	private void z0tek(XTextContainerElement p0, int p1, int p2)
	{
		XTextDocument xTextDocument = z0drk();
		for (int i = p1; i <= p2; i++)
		{
			XTextElement xTextElement = p0.z0be()[i];
			if (XTextDocumentContentElement.z0xrk && !(xTextElement is XTextCharElement))
			{
				XTextDocumentContentElement.z0xrk = false;
			}
			DocumentContentStyle documentContentStyle = xTextElement.z0aek().z0yek();
			documentContentStyle.z0eek(p0: true);
			documentContentStyle.DeleterIndex = xTextDocument.z0syk().z0yek();
			int styleIndex = xTextDocument.z0gnk().GetStyleIndex(documentContentStyle);
			if (xTextDocument.z0uik())
			{
				xTextDocument.z0imk().z0eek(xTextElement, xTextElement.z0pek(), styleIndex);
			}
			xTextElement.z0oek(styleIndex);
			if (xTextElement is XTextContainerElement)
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
				z0tek(xTextContainerElement, 0, xTextContainerElement.z0be().Count - 1);
			}
		}
	}

	public void z0tek(XTextElement p0)
	{
		int num = z0lrk(p0);
		if (num >= 0)
		{
			z0tek(num, p1: false);
		}
	}

	private z0ghj z0tek(XTextContainerElement p0, z0ZzZzhkh p1)
	{
		if (p1 == null)
		{
			p1 = z0zek();
		}
		bool flag = false;
		bool flag2 = false;
		if ((p0 is XTextTableElement || p0 is XTextTableRowElement) && p1.z0yek() == ContentRangeMode.Cell)
		{
			if (p0 is XTextTableElement)
			{
				using z0bpk z0bpk = ((XTextTableElement)p0).z0gtk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement p2 = (XTextTableCellElement)z0bpk.Current;
					if (p1.z0tek(p2))
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
					if (flag && flag2)
					{
						break;
					}
				}
			}
			else if (p0 is XTextTableRowElement)
			{
				using z0bpk z0bpk = ((XTextTableRowElement)p0).z0rek().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement p3 = (XTextTableCellElement)z0bpk.Current;
					if (p1.z0tek(p3))
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
					if (flag && flag2)
					{
						break;
					}
				}
			}
		}
		else
		{
			int tickCount = Environment.TickCount;
			XTextElementList xTextElementList = new XTextElementList();
			XTextContainerElement.z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new XTextContainerElement.z0eok_jiejie20260327142557(p0.z0jr(), xTextElementList, p2: true);
			p0.z0ue(z0eok_jiejie20260327142557);
			z0eok_jiejie20260327142557.Dispose();
			if (xTextElementList.Count == 0)
			{
				return z0ghj.z0yek;
			}
			using (z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (p1.z0tek(current))
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
					if (flag && flag2)
					{
						break;
					}
				}
			}
			tickCount = Math.Abs(Environment.TickCount - tickCount);
		}
		z0ghj result = z0ghj.z0tek;
		if (flag && flag2)
		{
			result = z0ghj.z0rek;
		}
		else if (flag && !flag2)
		{
			result = z0ghj.z0eek;
			if (p0 is XTextTableCellElement)
			{
				if (!p1.z0tek((XTextTableCellElement)p0))
				{
					result = z0ghj.z0rek;
				}
			}
			else if (p0 is XTextTableRowElement)
			{
				using z0bpk z0bpk = p0.z0be().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
					if (!p1.z0tek((xTextTableCellElement.z0hrk() == null) ? xTextTableCellElement : xTextTableCellElement.z0hrk()))
					{
						result = z0ghj.z0rek;
						break;
					}
				}
			}
		}
		else if (!flag && flag2)
		{
			result = z0ghj.z0tek;
		}
		return result;
	}

	public int z0tek(bool p0, bool p1, bool p2)
	{
		return z0tek(p0, p1, p2, null);
	}

	public void z0tek(int p0, out XTextContainerElement p1, out int p2, bool p3)
	{
		if (base.Count == 0)
		{
			p1 = null;
			p2 = 0;
			return;
		}
		if (p0 < 0)
		{
			p0 = 0;
		}
		if (p0 >= base.Count)
		{
			p0 = base.Count - 1;
		}
		if (p0 < 0 || p0 > base.Count)
		{
			throw new ArgumentOutOfRangeException("contentIndex=" + p0);
		}
		if (p0 >= base.Count)
		{
			p1 = z0vek();
			p2 = z0vek().z0be().Count;
			return;
		}
		XTextElement xTextElement = base[p0];
		p1 = xTextElement.z0ji();
		p2 = p1.z0be().z0vek(xTextElement);
		if (p1 is XTextCheckBoxElementBase.z0cok && p2 == 0)
		{
			xTextElement = ((XTextCheckBoxElementBase.z0cok)p1).z0yek;
			p1 = xTextElement.z0ji();
			p2 = p1.z0be().z0vek(xTextElement);
		}
		if (p1 is XTextFieldElementBase)
		{
			XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)p1;
			XTextElement xTextElement2 = xTextFieldElementBase.z0jrk();
			XTextElement xTextElement3 = xTextFieldElementBase.z0tek();
			if (xTextElement2.z0ctk() > xTextElement3.z0ctk())
			{
				xTextElement2 = xTextFieldElementBase.z0tek();
				xTextElement3 = xTextFieldElementBase.z0jrk();
			}
			if (xTextElement2 == xTextElement)
			{
				p1 = xTextFieldElementBase.z0ji();
				xTextElement = xTextFieldElementBase;
				p2 = p1.z0be().z0vek(xTextFieldElementBase);
			}
			else if (xTextElement3 == xTextElement)
			{
				p1 = xTextFieldElementBase;
				p2 = xTextFieldElementBase.z0be().Count;
				if (p0 > 0)
				{
					XTextElement item = base[p0 - 1];
					int num = xTextFieldElementBase.z0be().IndexOf(item);
					if (num >= 0 && num < xTextFieldElementBase.z0be().Count)
					{
						p2 = num + 1;
					}
				}
			}
			else if (p2 < 0)
			{
				p2 = 0;
			}
		}
		else
		{
			if (!p3)
			{
				return;
			}
			if (p0 == 0)
			{
				p0 = 1;
			}
			XTextElement xTextElement4 = base[p0 - 1];
			p1 = xTextElement4.z0ji();
			if (p1 is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase2 = (XTextFieldElementBase)p1;
				XTextFieldBorderElement xTextFieldBorderElement = xTextFieldElementBase2.z0jrk();
				XTextElement xTextElement5 = xTextFieldElementBase2.z0tek();
				if (xTextFieldBorderElement.z0ctk() > xTextElement5.z0ctk())
				{
					xTextFieldElementBase2.z0tek();
					xTextElement5 = xTextFieldElementBase2.z0jrk();
				}
				if (xTextElement5 == xTextElement4)
				{
					p1 = xTextFieldElementBase2.z0ji();
					p2 = p1.z0be().z0vek(xTextFieldElementBase2) + 1;
					return;
				}
				if (p2 < 0)
				{
					p2 = 0;
				}
			}
			p2 = p1.z0be().z0vek(xTextElement4) + 1;
		}
	}

	public void z0iek()
	{
		if (z0pek())
		{
			return;
		}
		z0rrk();
		z0ZzZzzlh z0ZzZzzlh2 = z0yek(p0: true);
		if (z0ZzZzzlh2 == null)
		{
			return;
		}
		if (z0crk <= 0f || z0drk().z0cu().z0ook() == FormViewMode.Strict)
		{
			XTextElement xTextElement = base[z0nek(z0erk())];
			z0crk = xTextElement.z0zrk();
		}
		XTextElement xTextElement2 = null;
		using (z0bpk z0bpk = ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh2).z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current.z0zrk() >= z0crk)
				{
					xTextElement2 = current;
					break;
				}
			}
		}
		if (xTextElement2 == null)
		{
			xTextElement2 = z0ZzZzzlh2.LastElement;
		}
		if (xTextElement2 is XTextParagraphListItemElement)
		{
			xTextElement2 = z0ZzZzzlh2.z0xek(xTextElement2);
		}
		int num = z0lrk(xTextElement2.z0hy());
		if (num >= 0)
		{
			num = z0tek(num, (z0ZzZzfxj)0, p2: true);
			z0tek(num, p1: false);
		}
	}

	public void z0tek(bool p0)
	{
		z0nrk = p0;
		_ = z0nrk;
	}

	public z0ZzZzzlh z0oek()
	{
		if (z0pek())
		{
			return null;
		}
		z0ZzZzzlh z0ZzZzzlh2 = z0lrk();
		if (z0ZzZzzlh2[0].z0brk() != null)
		{
			XTextTableCellElement xTextTableCellElement = z0ZzZzzlh2[0].z0brk();
			if (((XTextContentElement)xTextTableCellElement).z0zek().z0uek() == z0ZzZzzlh2)
			{
				XTextTableCellElement xTextTableCellElement2 = null;
				XTextTableElement xTextTableElement = xTextTableCellElement.z0gr();
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextTableElement.z0crk().z0mek(xTextTableCellElement.z0krk(), xTextTableCellElement.RowSpan);
				if (xTextTableRowElement != null)
				{
					xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement.z0rek().SafeGet(xTextTableCellElement.z0xek());
				}
				if (xTextTableCellElement2 == null)
				{
					XTextTableCellElement xTextTableCellElement3 = null;
					XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)xTextTableElement.z0crk().LastElement;
					if (xTextTableRowElement2 != null)
					{
						xTextTableCellElement3 = (XTextTableCellElement)xTextTableRowElement2.z0rek().LastElement;
					}
					if (xTextTableCellElement3 == null)
					{
						throw new IndexOutOfRangeException("RowInde:" + xTextTableCellElement.z0pek() + " ColIndex:" + xTextTableCellElement.z0xek());
					}
					if (xTextTableCellElement3.z0bek())
					{
						xTextTableCellElement3 = xTextTableCellElement3.z0hrk();
						if (xTextTableCellElement3.RowSpan > 1)
						{
							XTextElementList xTextElementList = xTextTableElement.z0zek();
							for (int num = xTextElementList.Count - 1; num >= 0; num--)
							{
								XTextTableCellElement xTextTableCellElement4 = (XTextTableCellElement)xTextElementList[num];
								if (!xTextTableCellElement4.z0bek())
								{
									xTextTableCellElement3 = xTextTableCellElement4;
									break;
								}
							}
						}
					}
					int index = z0vek().z0frk().IndexOf(xTextTableCellElement3.z0trk().LastElement) + 1;
					z0ZzZzzlh z0ZzZzzlh3 = z0vek().z0frk()[index].z0ptk();
					if (z0ZzZzzlh3.Contains(xTextTableCellElement3.z0gr()))
					{
						int num2 = z0vek().z0frk().IndexOf(z0ZzZzzlh3.LastElement);
						if (num2 > 0 && num2 < z0vek().z0frk().Count - 1)
						{
							z0ZzZzzlh3 = z0vek().z0frk()[num2 + 1].z0ptk();
						}
					}
					return z0ZzZzzlh3;
				}
				if (xTextTableCellElement2.z0hrk() != null)
				{
					xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
				}
				z0ZzZzzlh z0ZzZzzlh4 = ((XTextContentElement)xTextTableCellElement2).z0zek()[0];
				while (z0ZzZzzlh4.z0jrk_jiejie20260327142557())
				{
					XTextTableCellElement xTextTableCellElement5 = z0ZzZzzlh4.z0ntk().z0nek(0, 0, p2: false);
					if (xTextTableCellElement5 != null)
					{
						z0ZzZzzlh4 = ((XTextContentElement)xTextTableCellElement5).z0zek()[0];
					}
				}
				return z0ZzZzzlh4;
			}
		}
		if (z0vek().z0rrk().IndexOf(z0ZzZzzlh2) < z0vek().z0rrk().Count - 1)
		{
			for (int i = z0erk() + 1; i < base.Count; i++)
			{
				z0ZzZzzlh z0ZzZzzlh5 = base[i].z0ptk();
				if (z0ZzZzzlh5 != z0ZzZzzlh2 && !z0ZzZzzlh5.z0jrk_jiejie20260327142557() && !z0ZzZzzlh5.z0brk())
				{
					return z0ZzZzzlh5;
				}
			}
			return null;
		}
		return z0ZzZzzlh2;
	}

	private new bool z0pek()
	{
		XTextDocument xTextDocument = z0drk();
		if (xTextDocument != null && xTextDocument.z0xu())
		{
			return true;
		}
		return false;
	}

	private bool z0yek(XTextElement p0)
	{
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		XTextDocument xTextDocument = p0.z0jr();
		bool result = false;
		DocumentSecurityOptions documentSecurityOptions = xTextDocument.z0hi();
		if (p0.z0ji().z0brk() && documentSecurityOptions.EnableLogicDelete)
		{
			if (z0ZzZzrzj2.z0nrk == xTextDocument.z0syk().z0yek())
			{
				result = false;
			}
			else
			{
				result = true;
				if (documentSecurityOptions.RealDeleteOwnerContent)
				{
					z0ZzZzyhh z0ZzZzyhh2 = xTextDocument.z0syk().z0tek(z0ZzZzrzj2.z0nrk);
					z0ZzZzyhh z0ZzZzyhh3 = xTextDocument.z0syk().z0eek();
					if (z0ZzZzyhh2 != null && z0ZzZzyhh3 != null && z0ZzZzyhh2.z0zek() == z0ZzZzyhh3.z0zek())
					{
						result = false;
					}
				}
			}
		}
		return result;
	}

	public new int z0mek()
	{
		return z0brk;
	}

	private int z0uek(XTextElement p0)
	{
		XTextElementList xTextElementList = z0jrk();
		int num = -1;
		if (xTextElementList == this)
		{
			if (xTextElementList.SafeGet(p0.z0jrk()) == p0)
			{
				return p0.z0jrk();
			}
			return xTextElementList.IndexOf(p0);
		}
		if (xTextElementList.SafeGet(p0.z0ctk()) == p0)
		{
			return p0.z0ctk();
		}
		return xTextElementList.IndexOf(p0);
	}

	public new void z0nek()
	{
		if (z0pek())
		{
			return;
		}
		try
		{
			z0ZzZzzlh z0ZzZzzlh2 = z0lrk();
			if (z0ZzZzzlh2 == null || z0nrk)
			{
				return;
			}
			z0crk = -1f;
			XTextElementList xTextElementList = z0ZzZzzlh2.z0urk();
			z0tek(xTextElementList.LastElement);
			if (z0ZzZzjzj.z0tek(xTextElementList.LastElement))
			{
				int num = z0lrk(xTextElementList.LastElement);
				if (num >= 0)
				{
					num = z0tek(num, (z0ZzZzfxj)0, p2: true);
					z0tek(num, p1: false);
				}
				return;
			}
			int num2 = z0lrk(xTextElementList.LastElement) + 1;
			int num3 = z0tek(num2, (z0ZzZzfxj)0, p2: true);
			if (num2 != num3)
			{
				z0tek(num3, p1: false);
				return;
			}
			z0tek(num2, p1: false);
			z0nrk = true;
		}
		catch
		{
		}
	}

	private void z0tek(XTextParagraphFlagElement p0, XTextParagraphFlagElement p1, bool p2 = true)
	{
		if (p0 != p1 && p0 != null && p1 != null && (!p2 || (p0.z0aek().z0nrk < 0 && p0.z0aek().z0jyk < 0)))
		{
			if (z0drk().z0uik())
			{
				z0drk().z0imk().z0eek(p1, ((XTextElement)p1).z0pek(), ((XTextElement)p0).z0pek());
			}
			p1.z0oek(((XTextElement)p0).z0pek());
		}
	}

	internal z0ZzZzplh(XTextDocumentContentElement p0, int p1)
		: base(p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("dce");
		}
		z0vrk = p0;
	}

	public new void z0bek()
	{
		if (z0pek())
		{
			return;
		}
		z0rrk();
		z0ZzZzzlh z0ZzZzzlh2 = z0lrk();
		if (z0ZzZzzlh2 == null)
		{
			return;
		}
		z0crk = -1f;
		int num = z0lrk(z0ZzZzzlh2.z0urk().z0krk());
		int num2 = 0;
		using (z0bpk z0bpk = z0ZzZzzlh2.z0urk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (!(current is XTextCharElement xTextCharElement) || !char.IsWhiteSpace(xTextCharElement.z0mek()))
				{
					num2 = z0ZzZzzlh2.z0urk().IndexOf(current);
					break;
				}
			}
		}
		if (num2 == 0 || z0zek().z0nek() == num + num2)
		{
			num = z0tek(num, (z0ZzZzfxj)1, p2: true);
			z0tek(num, p1: false);
		}
		else
		{
			int p = num + num2;
			p = z0tek(p, (z0ZzZzfxj)1, p2: true);
			z0tek(p, p1: false);
		}
	}

	public z0ZzZzplh(XTextDocumentContentElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("dce");
		}
		z0vrk = p0;
	}

	public new XTextDocumentContentElement z0vek()
	{
		return z0vrk;
	}

	public new bool z0cek()
	{
		return z0zrk;
	}

	public void z0tek(float p0)
	{
		if (!z0pek())
		{
			z0rrk();
			z0nrk = false;
			XTextElement xTextElement = z0ork();
			if (xTextElement != null)
			{
				z0tek(xTextElement.z0zrk(), xTextElement.z0ltk() + p0);
			}
		}
	}

	public z0ZzZzzlh z0yek(bool p0)
	{
		z0ZzZzzlh z0ZzZzzlh2 = z0lrk();
		if (z0ZzZzzlh2[0].z0brk() != null)
		{
			XTextTableCellElement xTextTableCellElement = z0ZzZzzlh2[0].z0brk();
			if (((XTextContentElement)xTextTableCellElement).z0zek()[0] == z0ZzZzzlh2)
			{
				XTextTableElement xTextTableElement = xTextTableCellElement.z0gr();
				if (xTextTableCellElement.z0pek() == 0)
				{
					XTextTableCellElement xTextTableCellElement2 = xTextTableElement.z0nek(0, 0, p2: true);
					int num = z0vek().z0frk().IndexOf(xTextTableCellElement2.z0trk()[0]) - 1;
					if (num >= 0)
					{
						z0ZzZzzlh z0ZzZzzlh3 = z0vek().z0frk()[num].z0ptk();
						if (z0ZzZzzlh3.Contains(xTextTableElement))
						{
							int num2 = z0vek().z0frk().IndexOf(z0ZzZzzlh3[0]);
							if (num2 > 0)
							{
								z0ZzZzzlh3 = z0vek().z0frk()[num2 - 1].z0ptk();
							}
						}
						return z0ZzZzzlh3;
					}
					return null;
				}
				XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)((XTextTableRowElement)xTextTableElement.z0crk().z0pek(xTextTableCellElement.z0krk())).z0rek().SafeGet(xTextTableCellElement.z0xek());
				if (xTextTableCellElement3 == null)
				{
					throw new Exception("RowIndex:" + xTextTableCellElement.z0pek() + " ColIndex:" + xTextTableCellElement.z0xek());
				}
				if (xTextTableCellElement3.z0bek())
				{
					xTextTableCellElement3 = xTextTableCellElement3.z0hrk();
				}
				return ((XTextContentElement)xTextTableCellElement3).z0zek().z0uek();
			}
		}
		if (z0vek().z0rrk().IndexOf(z0ZzZzzlh2) > 0)
		{
			for (int num3 = z0erk() - 1; num3 >= 0; num3--)
			{
				z0ZzZzzlh z0ZzZzzlh4 = base[num3].z0ptk();
				if (z0ZzZzzlh4 != z0ZzZzzlh2 && !z0ZzZzzlh4.z0jrk_jiejie20260327142557() && !z0ZzZzzlh4.z0brk())
				{
					return z0ZzZzzlh4;
				}
			}
			return null;
		}
		for (int num4 = z0erk() - 1; num4 >= 0; num4--)
		{
			z0ZzZzzlh z0ZzZzzlh5 = base[num4].z0ptk();
			if (z0ZzZzzlh5 != z0ZzZzzlh2 && !z0ZzZzzlh5.z0jrk_jiejie20260327142557() && !z0ZzZzzlh5.z0brk())
			{
				return z0ZzZzzlh5;
			}
		}
		return z0ZzZzzlh2;
	}

	public new bool z0xek()
	{
		if (z0pek())
		{
			return false;
		}
		if (base.Count == 0)
		{
			return false;
		}
		XTextContainerElement xTextContainerElement = null;
		int num = -1;
		for (int num2 = Math.Min(z0erk(), base.Count - 1); num2 >= 0; num2--)
		{
			if (xTextContainerElement == null)
			{
				xTextContainerElement = base[num2].z0ji();
			}
			if (!(base[num2] is XTextCharElement xTextCharElement) || xTextCharElement.z0ji() != xTextContainerElement || (!char.IsLetter(xTextCharElement.z0mek()) && !char.IsDigit(xTextCharElement.z0mek())))
			{
				break;
			}
			num = num2;
		}
		if (num >= 0)
		{
			int num3 = -1;
			for (int i = z0erk(); i < base.Count; i++)
			{
				if (xTextContainerElement == null)
				{
					xTextContainerElement = base[i].z0ji();
				}
				if (!(base[i] is XTextCharElement xTextCharElement2) || xTextCharElement2.z0ji() != xTextContainerElement || (!char.IsLetter(xTextCharElement2.z0mek()) && !char.IsDigit(xTextCharElement2.z0mek())))
				{
					break;
				}
				num3 = i;
			}
			if (num3 != -1)
			{
				z0nrk = false;
				z0tek(num, num3 - num + 1);
				return true;
			}
		}
		return false;
	}

	public void z0uek(bool p0)
	{
		z0zrk = p0;
	}

	internal bool z0iek(XTextElement p0)
	{
		if (p0 != null)
		{
			if (SafeGet(p0.z0tuk) == p0)
			{
				return true;
			}
			return Contains(p0);
		}
		return false;
	}

	public int z0tek(XTextContainerElement p0, int p1, bool p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("container");
		}
		if (p1 <= 0)
		{
			p1 = p0.z0ie().z0jrk();
		}
		else if (p1 >= p0.z0be().Count)
		{
			p1 = p0.z0dek().z0jrk();
		}
		else
		{
			XTextElement xTextElement = p0.z0be()[p1];
			p1 = ((!(xTextElement is XTextParagraphFlagElement)) ? xTextElement.z0ie().z0jrk() : z0lrk(xTextElement));
		}
		return p1;
	}

	[DevLog("2024-9-24", "袁永福", "", "改进字符串查找算法")]
	internal void z0tek(z0ZzZzxxj p0)
	{
		int count = base.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)this).z0krk();
		char p1 = p0.z0tek[0];
		int length = p0.z0tek.Length;
		for (int i = 0; i < count; i++)
		{
			if (!(array[i] is XTextCharElement xTextCharElement) || !z0tek(xTextCharElement.CharValue, p1, p0.z0yek))
			{
				continue;
			}
			bool flag = true;
			int num = 0;
			int num2 = 0;
			for (int j = i; j < count; j++)
			{
				if (num >= p0.z0tek.Length)
				{
					break;
				}
				XTextCharElement xTextCharElement2 = base[j] as XTextCharElement;
				num2++;
				if (xTextCharElement2 == null)
				{
					flag = false;
					break;
				}
				if (xTextCharElement2.z0oek())
				{
					flag = false;
					break;
				}
				if (!z0tek(xTextCharElement2.CharValue, p0.z0tek[num], p0.z0yek))
				{
					flag = false;
					break;
				}
				if (XTextCharElement.z0tek((int)xTextCharElement2.CharValue))
				{
					num++;
					if (xTextCharElement2.z0iek() != p0.z0tek[num])
					{
						flag = false;
						break;
					}
				}
				num++;
			}
			if (!flag)
			{
				continue;
			}
			if (p0.z0yek)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int k = 0; k < length; k++)
				{
					stringBuilder.Append(base[i + k].Text);
				}
				SearchStringResult result = new SearchStringResult(xTextCharElement.z0ji(), xTextCharElement, num2, stringBuilder.ToString());
				p0.z0rek.InnerAdd(result);
			}
			else
			{
				p0.z0rek.InnerAdd(new SearchStringResult(xTextCharElement.z0ji(), xTextCharElement, num2, p0.z0tek));
			}
			if (p0.z0eek > 0 && p0.z0rek.Count == p0.z0eek)
			{
				break;
			}
			i += length - 1;
		}
	}

	private int z0eek(XTextContainerElement p0, XTextElement p1, XTextElement p2, bool p3, List<ContentChangedEventArgs> p4)
	{
		if (z0pek())
		{
			return 0;
		}
		XTextDocument xTextDocument = z0drk();
		int num = p0.z0be().IndexOf(p1);
		int num2 = p0.z0be().IndexOf(p2);
		XTextParagraphFlagElement xTextParagraphFlagElement = z0pek(p1);
		XTextParagraphFlagElement xTextParagraphFlagElement2 = null;
		if (p0.z0be().LastElement != p2)
		{
			xTextParagraphFlagElement2 = z0pek(p0.z0be().z0xek(p2));
		}
		XTextElementList xTextElementList = p0.z0be().z0mek(num, num2 - num + 1);
		if (xTextElementList.Count == 0)
		{
			return 0;
		}
		using (z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextParagraphFlagElement && current.z0aek().z0ruk)
				{
					z0vek().z0rek(p0: true);
					if (xTextDocument.z0uik())
					{
						xTextDocument.z0imk().z0eek((z0ZzZzbzj)7);
					}
					break;
				}
			}
		}
		if (p3)
		{
			ContentChangingEventArgs e = new ContentChangingEventArgs();
			e.Document = xTextDocument;
			e.Element = p0;
			e.ElementIndex = num;
			e.DeletingElements = xTextElementList;
			p0.z0cek(e);
			if (e.Cancel)
			{
				return 0;
			}
		}
		bool flag = z0yek(p0.z0be()[num]);
		if (flag)
		{
			z0tek(p0, num, num2);
		}
		else
		{
			z0mrk = false;
			if (p0 is XTextTableElement)
			{
				((XTextTableElement)p0).z0mek(num, num2 - num + 1, p2: true);
			}
			else
			{
				p0.z0we();
				XTextElementList xTextElementList2 = p0.z0be();
				if (xTextDocument.z0uik())
				{
					xTextDocument.z0imk().z0eek(p0, xTextElementList2.IndexOf(p1), xTextElementList);
				}
				if (XTextDocumentContentElement.z0xrk)
				{
					for (int i = num; i <= num2; i++)
					{
						if (xTextElementList2[i] is XTextCharElement)
						{
							XTextDocumentContentElement.z0xrk = false;
							break;
						}
					}
				}
				XTextParagraphFlagElement xTextParagraphFlagElement3 = xTextElementList2[num].z0dy();
				XTextParagraphFlagElement xTextParagraphFlagElement4 = xTextElementList2[num2].z0dy();
				if (xTextParagraphFlagElement3 == null || xTextParagraphFlagElement4 == null || xTextParagraphFlagElement3 == xTextParagraphFlagElement4 || ((XTextElement)xTextParagraphFlagElement3).z0pek() == ((XTextElement)xTextParagraphFlagElement4).z0pek())
				{
					xTextParagraphFlagElement3 = null;
					xTextParagraphFlagElement4 = null;
				}
				xTextElementList2.z0irk(num, num2 - num + 1);
				if (xTextParagraphFlagElement3 != null && xTextParagraphFlagElement4 != null && !xTextElementList2.Contains(xTextParagraphFlagElement3))
				{
					if (xTextDocument.z0uik())
					{
						xTextDocument.z0imk().z0eek(xTextParagraphFlagElement4, ((XTextElement)xTextParagraphFlagElement4).z0pek(), ((XTextElement)xTextParagraphFlagElement3).z0pek());
					}
					xTextParagraphFlagElement4.z0oek(((XTextElement)xTextParagraphFlagElement3).z0pek());
				}
			}
		}
		if (xTextDocument.z0htk() != null)
		{
			using z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current2 = z0bpk.Current;
				if (!(current2 is XTextCharElement))
				{
					xTextDocument.z0htk().z0qp(current2);
				}
			}
		}
		((XTextElement)p0).z0rrk();
		if (xTextDocument.z0ank() != null)
		{
			xTextDocument.z0ank().z0gb(p0: true);
		}
		using (z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current3 = z0bpk.Current;
				if (current3.z0ptk() != null)
				{
					current3.z0ptk().z0tek(p0: true);
				}
				else
				{
					if (!(current3 is XTextContainerElement))
					{
						continue;
					}
					XTextContainerElement obj = (XTextContainerElement)current3;
					XTextElementList xTextElementList3 = new XTextElementList();
					XTextContainerElement.z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new XTextContainerElement.z0eok_jiejie20260327142557(obj.z0jr(), xTextElementList3, p2: false);
					obj.z0ue(z0eok_jiejie20260327142557);
					z0eok_jiejie20260327142557.Dispose();
					if (xTextElementList3.Count <= 0)
					{
						continue;
					}
					using z0bpk z0bpk2 = xTextElementList3.z0ltk();
					while (z0bpk2.MoveNext())
					{
						XTextElement current4 = z0bpk2.Current;
						if (current4.z0ptk() != null)
						{
							current4.z0ptk().z0tek(p0: true);
						}
					}
				}
			}
		}
		if (p3)
		{
			ContentChangedEventArgs e2 = new ContentChangedEventArgs();
			e2.Document = xTextDocument;
			e2.Element = p0;
			e2.ElementIndex = num;
			e2.DeletedElements = xTextElementList;
			p4.Add(e2);
		}
		if (xTextParagraphFlagElement != xTextParagraphFlagElement2 && xTextParagraphFlagElement2 != null)
		{
			z0tek(xTextParagraphFlagElement, xTextParagraphFlagElement2);
		}
		if (flag)
		{
			return -xTextElementList.Count;
		}
		return xTextElementList.Count;
	}

	public new z0ZzZzhkh z0zek()
	{
		return z0vrk.z0oek();
	}

	public bool z0tek(int p0, bool p1 = false)
	{
		if (z0pek())
		{
			return false;
		}
		z0nrk = p1;
		p0 = z0nek(p0);
		p0 = z0tek(p0, (z0ZzZzfxj)2, p2: true);
		int p2 = 0;
		if (!z0zrk)
		{
			p2 = z0prk() + (z0erk() - p0);
			z0prk();
		}
		z0iek(p0: true);
		return z0tek(p0, p2);
	}

	public new z0ZzZzzlh z0lrk()
	{
		if (base.Count == 0)
		{
			return null;
		}
		XTextElement xTextElement = z0ork();
		if (xTextElement != null)
		{
			z0ZzZzzlh z0ZzZzzlh2 = xTextElement.z0ptk();
			if (z0ZzZzzlh2 != null)
			{
				if (z0nrk)
				{
					int num = z0vrk.z0rrk().z0rek(z0ZzZzzlh2);
					if (num > 0)
					{
						return z0vrk.z0rrk()[num - 1];
					}
				}
				return z0ZzZzzlh2;
			}
		}
		int num2 = z0erk();
		if (num2 >= 0 && num2 < base.Count)
		{
			z0ZzZzzlh z0ZzZzzlh3 = base[num2].z0ptk();
			if (z0nrk && z0vrk.z0rrk().z0rek(z0ZzZzzlh3) > 0)
			{
				return z0vrk.z0rrk()[z0vrk.z0rrk().z0rek(z0ZzZzzlh3) - 1];
			}
			return z0ZzZzzlh3;
		}
		return base.LastElement.z0ptk();
	}

	public int z0tek(bool p0, bool p1, bool p2, z0ZzZzhkh p3)
	{
		if (z0pek())
		{
			return -1;
		}
		if (base.Count == 0)
		{
			return -1;
		}
		if (p3 == null)
		{
			p3 = z0zek();
		}
		if (p3.z0qrk() == 0)
		{
			return -1;
		}
		XTextContainerElement xTextContainerElement = null;
		XTextElementList xTextElementList = z0ZzZzafh.z0iek(p3.z0grk().z0krk());
		XTextElementList xTextElementList2 = z0ZzZzafh.z0iek(p3.z0grk().LastElement);
		for (int i = 0; i < xTextElementList.Count; i++)
		{
			if (!xTextElementList2.Contains(xTextElementList[i]))
			{
				continue;
			}
			xTextContainerElement = (XTextContainerElement)xTextElementList[i];
			if (xTextContainerElement is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextContainerElement;
				if (p3.z0grk().z0krk() == xTextFieldElementBase.z0jrk() && p3.z0grk().LastElement == xTextFieldElementBase.z0tek())
				{
					xTextContainerElement = xTextContainerElement.z0ji();
				}
			}
			break;
		}
		if (!(xTextContainerElement is XTextContentElement) && xTextContainerElement.z0ji() != null && z0tek(xTextContainerElement, p3) == z0ghj.z0eek)
		{
			xTextContainerElement = xTextContainerElement.z0ji();
		}
		Dictionary<XTextContentElement, int> dictionary = new Dictionary<XTextContentElement, int>();
		int p4 = z0lrk(p3.z0grk()[0]);
		XTextElement xTextElement = SafeGet(p3.z0drk());
		XTextTableCellElement xTextTableCellElement = null;
		if (p3.z0yek() == ContentRangeMode.Cell && p3.z0irk() != null && p3.z0irk().Count == 1)
		{
			xTextTableCellElement = (XTextTableCellElement)p3.z0irk()[0];
		}
		if (xTextElement == null)
		{
			xTextElement = base.LastElement;
		}
		List<ContentChangedEventArgs> list = new List<ContentChangedEventArgs>();
		int num = 0;
		XTextTableCellElement xTextTableCellElement2 = null;
		z0mrk = true;
		if ((xTextContainerElement is XTextTableElement || xTextContainerElement is XTextTableRowElement) && p3.z0yek() == ContentRangeMode.Cell)
		{
			using z0bpk z0bpk = p3.z0irk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement3.z0yi() && !xTextTableCellElement3.z0bek())
				{
					if (xTextTableCellElement2 == null)
					{
						xTextTableCellElement2 = xTextTableCellElement3;
					}
					num += z0rek(xTextTableCellElement3, dictionary, p1, p3, list);
				}
			}
		}
		else
		{
			num = z0rek(xTextContainerElement, dictionary, p1, p3, list);
		}
		if (p1)
		{
			return num;
		}
		if (num > 0 && !p2)
		{
			XTextDocument xTextDocument = z0drk();
			xTextDocument.z0dbk = true;
			foreach (ContentChangedEventArgs item in list)
			{
				if (item.DeletedElements != null && item.DeletedElements.Count > 0)
				{
					using z0bpk z0bpk = item.DeletedElements.z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextElement current2 = z0bpk.Current;
						if (!(current2 is XTextCharElement) && !(current2 is XTextParagraphFlagElement))
						{
							xTextDocument.z0dbk = false;
							break;
						}
					}
				}
				if (!xTextDocument.z0dbk)
				{
					break;
				}
			}
			bool flag = false;
			try
			{
				XTextContainerElement.z0btk = false;
				z0tek(p0: false);
				xTextDocument.Modified = true;
				foreach (XTextContentElement key in dictionary.Keys)
				{
					int p5 = dictionary[key];
					key.z0bek(p0: false);
					key.z0eek(p5, -1, p2: true);
					if (key.z0pek())
					{
						flag = true;
					}
				}
				z0vek().z0bek(p0: false);
				z0vek().z0lrk();
				if (z0vek().z0xek())
				{
					z0vek().z0rek(p0: true, p1: true);
				}
				if (xTextDocument.z0ank() != null && xTextDocument.z0ank().z0gb(p0: true))
				{
					flag = true;
				}
			}
			finally
			{
				XTextContainerElement.z0btk = true;
				xTextDocument.z0dbk = false;
			}
			if (list.Count > 0)
			{
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					ContentChangedEventArgs e = list[num2];
					if (e.Element is XTextContainerElement xTextContainerElement2)
					{
						xTextContainerElement2.z0zi(e);
					}
				}
			}
			if (flag)
			{
				xTextDocument.z0krk();
				if (xTextDocument.z0yyk() != null)
				{
					xTextDocument.z0yyk().z0fpk();
					if (p3 != z0zek())
					{
						xTextDocument.z0yyk().z0vik();
					}
					xTextDocument.z0yyk().z0ypk().z0hz();
				}
			}
			else if (xTextDocument.z0yyk() != null)
			{
				xTextDocument.z0yyk().z0vik();
				((z0ZzZzmwh)xTextDocument.z0yyk()).z0jrk();
			}
			if (p3 == z0zek() && (!z0mrk || !xTextDocument.z0vtk().SecurityOptions.ShowLogicDeletedContent))
			{
				if (xTextTableCellElement2 != null)
				{
					z0tek(z0lrk(xTextTableCellElement2.z0hy()), 0);
				}
				else if (xTextTableCellElement != null && !xTextElement.z0zu(xTextTableCellElement))
				{
					z0tek(xTextTableCellElement.z0ie().z0jrk(), 0);
				}
				else if (xTextElement != null && Contains(xTextElement))
				{
					z0tek(z0lrk(xTextElement), 0);
				}
				else
				{
					z0tek(p4, 0);
				}
			}
		}
		return num;
	}

	public void z0tek(XTextElement p0, out XTextContainerElement p1, out int p2, bool p3)
	{
		if (base.Count == 0)
		{
			p1 = null;
			p2 = 0;
			return;
		}
		if (p0 == null)
		{
			p1 = null;
			p2 = 0;
			return;
		}
		if (p0 == base.LastElement)
		{
			p1 = z0vek();
			p2 = z0vek().z0be().Count;
			return;
		}
		p1 = p0.z0ji();
		p2 = p1.z0be().z0vek(p0);
		if (p1 is XTextFieldElementBase)
		{
			XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)p1;
			XTextElement xTextElement = xTextFieldElementBase.z0jrk();
			XTextElement xTextElement2 = xTextFieldElementBase.z0tek();
			if (xTextElement.z0ctk() > xTextElement2.z0ctk())
			{
				xTextElement = xTextFieldElementBase.z0tek();
				xTextElement2 = xTextFieldElementBase.z0jrk();
			}
			if (xTextElement == p0)
			{
				p1 = xTextFieldElementBase.z0ji();
				p0 = xTextFieldElementBase;
				p2 = p1.z0be().z0vek(xTextFieldElementBase);
			}
			else if (xTextElement2 == p0)
			{
				p1 = xTextFieldElementBase;
				p2 = xTextFieldElementBase.z0be().Count;
			}
			else if (p2 < 0)
			{
				p2 = 0;
			}
		}
		else
		{
			if (!p3)
			{
				return;
			}
			int num = z0lrk(p0);
			if (num == 0)
			{
				num = 1;
			}
			XTextElement xTextElement3 = base[num - 1];
			p1 = xTextElement3.z0ji();
			if (p1 is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase2 = (XTextFieldElementBase)p1;
				if (xTextFieldElementBase2.z0tek() == xTextElement3)
				{
					p1 = xTextFieldElementBase2.z0ji();
					p2 = p1.z0be().z0vek(xTextFieldElementBase2) + 1;
					return;
				}
				if (p2 < 0)
				{
					p2 = 0;
				}
			}
			p2 = p1.z0be().z0vek(xTextElement3) + 1;
		}
	}

	public XTextElement z0krk_jiejie20260327142557()
	{
		int num = z0erk();
		if (base.Count > 0 && num > 0 && num < base.Count)
		{
			return base[num - 1];
		}
		return null;
	}

	internal new XTextElementList z0jrk()
	{
		return this;
	}

	public new bool z0hrk()
	{
		XTextDocument xTextDocument = z0drk();
		if (xTextDocument != null && xTextDocument.z0xek() != null && xTextDocument.z0xek().z0bp() == FormViewMode.Strict)
		{
			int num = z0tek(z0erk(), (z0ZzZzfxj)2, p2: true);
			if (num != z0erk())
			{
				z0tek(num, 0);
				return true;
			}
		}
		return false;
	}

	public XTextElement z0tek(float p0, float p1, bool p2)
	{
		if (z0drk() == null)
		{
			return null;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0vek();
		if (xTextDocumentContentElement.z0iek())
		{
			XTextElement xTextElement = xTextDocumentContentElement.z0rek(p0, p1, ElementZOrderStyle.InFrontOfText);
			if (xTextElement != null)
			{
				return xTextElement;
			}
		}
		z0ZzZzzlh z0ZzZzzlh2 = z0yek(p0, p1, p2);
		if (z0jtk != null && z0jtk.IsAlive)
		{
			XTextElement result = (XTextElement)z0jtk.Target;
			z0jtk = null;
			return result;
		}
		if (z0ZzZzzlh2 == null)
		{
			return xTextDocumentContentElement.z0rek(p0, p1, ElementZOrderStyle.UnderText);
		}
		p0 -= z0ZzZzzlh2.z0xtk();
		if (p2)
		{
			if (p0 >= 0f && p0 <= z0ZzZzzlh2.z0jyk_jiejie20260327142557())
			{
				foreach (XTextElement item in ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh2).z0xrk())
				{
					if (!(item is XTextParagraphListItemElement) && p0 >= item.z0it() && p0 <= item.z0it() + item.z0bi() + item.z0pt())
					{
						return item;
					}
				}
			}
			return xTextDocumentContentElement.z0rek(p0, p1, ElementZOrderStyle.UnderText);
		}
		if (p0 < 0f)
		{
			return ((XTextElementList)z0ZzZzzlh2).z0krk();
		}
		foreach (XTextElement item2 in ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh2).z0xrk())
		{
			if (!(item2 is XTextParagraphListItemElement) && p0 < item2.z0it() + item2.z0bi())
			{
				return item2;
			}
		}
		return z0ZzZzzlh2.LastElement;
	}

	internal void z0iek(bool p0)
	{
		z0xrk = p0;
	}

	public new bool z0oek(XTextElement p0)
	{
		if (z0pek())
		{
			return false;
		}
		int num = z0lrk(p0);
		if (num >= 0)
		{
			return z0tek(num, p1: false);
		}
		return false;
	}

	public void z0tek(out XTextContainerElement p0, out int p1)
	{
		if (z0zek() == null)
		{
			p0 = null;
			p1 = 0;
		}
		else
		{
			z0tek(z0zek().z0nek(), out p0, out p1, z0frk());
		}
	}

	public new XTextParagraphFlagElement z0pek(XTextElement p0)
	{
		if (z0pek())
		{
			return null;
		}
		if (p0 == null)
		{
			return null;
		}
		if (p0 is XTextParagraphFlagElement)
		{
			return (XTextParagraphFlagElement)p0;
		}
		int num = z0lrk(p0);
		if (num >= 0)
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = p0.z0kik?.z0grk();
			if (xTextParagraphFlagElement != null && SafeGet(xTextParagraphFlagElement.z0tuk) == xTextParagraphFlagElement && xTextParagraphFlagElement.z0tuk > num)
			{
				return xTextParagraphFlagElement;
			}
			return z0vek<XTextParagraphFlagElement>(num);
		}
		return null;
	}

	private int z0rek(XTextContainerElement p0, Dictionary<XTextContentElement, int> p1, bool p2, z0ZzZzhkh p3, List<ContentChangedEventArgs> p4)
	{
		XTextContentElement xTextContentElement = p0.z0jy();
		if (p0 is XTextContentElement)
		{
			xTextContentElement = (XTextContentElement)p0;
		}
		XTextDocument xTextDocument = z0drk();
		XTextElementList xTextElementList = xTextContentElement.z0trk();
		XTextElementList xTextElementList2 = p3.z0grk();
		z0ZzZzpxj z0ZzZzpxj2 = xTextDocument.z0xek();
		z0ghj[] array = new z0ghj[p0.z0be().Count];
		int num = 0;
		for (XTextElement xTextElement = xTextElementList2[0]; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement.z0ji() == p0)
			{
				num = p0.z0be().IndexOf(xTextElement);
				if (num < 0)
				{
					num = 0;
				}
				break;
			}
		}
		int num2 = p0.z0be().Count - 1;
		for (XTextElement xTextElement = xTextElementList2.LastElement; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement.z0ji() == p0)
			{
				num2 = p0.z0be().IndexOf(xTextElement);
				if (num2 < 0)
				{
					num2 = p0.z0be().Count - 1;
				}
				break;
			}
		}
		for (int i = num; i <= num2; i++)
		{
			XTextElement xTextElement2 = p0.z0be()[i];
			bool flag = z0ZzZzpxj2.z0lm(xTextElement2);
			if (flag)
			{
				if (xTextElement2 is XTextContainerElement && ((XTextContainerElement)xTextElement2).z0wo(xTextDocument.z0cek(), 100))
				{
					flag = false;
				}
			}
			else
			{
				z0ZzZzpxj2.z0ym(xTextDocument.z0cek());
			}
			if (flag)
			{
				if (xTextElementList2.Contains(xTextElement2))
				{
					array[i] = z0ghj.z0eek;
				}
				else if (xTextElement2 is XTextContainerElement)
				{
					array[i] = z0tek((XTextContainerElement)xTextElement2, p3);
				}
				else
				{
					array[i] = z0ghj.z0tek;
				}
				if (p2 && (array[i] == z0ghj.z0eek || array[i] == z0ghj.z0rek))
				{
					z0ZzZzpxj2.z0ym(null);
					z0drk().z0cek().Clear();
					return 1;
				}
			}
			else
			{
				array[i] = z0ghj.z0tek;
			}
		}
		if (p2)
		{
			z0ZzZzpxj2.z0ym(null);
			xTextDocument.z0cek().Clear();
			return 0;
		}
		for (int j = num; j <= num2; j++)
		{
			if (array[j] != z0ghj.z0yek)
			{
				continue;
			}
			bool flag2 = false;
			z0ghj z0ghj = z0ghj.z0tek;
			for (int num3 = j - 1; num3 >= num2; num3--)
			{
				if (array[num3] != z0ghj.z0yek)
				{
					z0ghj = array[num3];
					flag2 = true;
					break;
				}
			}
			bool flag3 = false;
			z0ghj z0ghj2 = z0ghj.z0tek;
			for (int k = j + 1; k <= num2; k++)
			{
				if (array[k] != z0ghj.z0yek)
				{
					z0ghj2 = array[k];
					flag3 = true;
					break;
				}
			}
			if (z0ghj != z0ghj.z0tek && z0ghj2 != z0ghj.z0tek)
			{
				array[j] = z0ghj.z0eek;
			}
			if (!flag2)
			{
				array[j] = z0ghj2;
			}
			else if (!flag3)
			{
				array[j] = z0ghj;
			}
			else
			{
				array[j] = z0ghj.z0tek;
			}
		}
		int num4 = 0;
		int num5 = xTextElementList.Count;
		XTextElement xTextElement3 = null;
		XTextElement xTextElement4 = null;
		Dictionary<XTextElement, z0ghj> dictionary = new Dictionary<XTextElement, z0ghj>();
		for (int l = num; l <= num2; l++)
		{
			dictionary[p0.z0be()[l]] = array[l];
		}
		bool flag4 = p0.z0brk() && xTextDocument.z0hi().EnableLogicDelete;
		int num6 = -1;
		for (int m = num; m < p0.z0be().Count && m <= num2; m++)
		{
			XTextElement xTextElement5 = p0.z0be()[m];
			if (!xTextElement5.z0yi())
			{
				continue;
			}
			if (dictionary[xTextElement5] == z0ghj.z0eek)
			{
				xTextElement4 = p0.z0be()[m];
				if (xTextElement3 == null)
				{
					xTextElement3 = xTextElement4;
				}
				int num7 = xTextElementList.z0vek(xTextElement3.z0ie());
				if (num7 >= 0 && num5 > num7)
				{
					num5 = num7;
				}
				if (!flag4)
				{
					continue;
				}
				int num8 = xTextElement4.z0ie().z0aek().z0nrk;
				if (num8 == num6)
				{
					continue;
				}
				XTextElement xTextElement6 = p0.z0be().z0pek(xTextElement4);
				if (xTextElement3 == xTextElement4)
				{
					xTextElement6 = xTextElement4;
				}
				else if (xTextElement6 == null)
				{
					xTextElement6 = xTextElement4;
				}
				int num9 = z0eek(p0, xTextElement3, xTextElement6, p3: true, p4);
				num4 += Math.Abs(num9);
				if (num9 > 0)
				{
					num2 -= num9;
					m = Math.Max(-1, m - num9);
					xTextElement3 = ((!p0.z0be().Contains(xTextElement4)) ? null : xTextElement4);
				}
				if (num9 < 0)
				{
					xTextElement4 = p0.z0be().SafeGet(m);
					xTextElement3 = xTextElement5;
					num6 = num8;
				}
				else if (m >= p0.z0xek() || m >= num2)
				{
					xTextElement3 = null;
					if (p0.z0be().Contains(xTextElement4))
					{
						z0eek(p0, xTextElement4, xTextElement4, p3: true, p4);
					}
				}
				continue;
			}
			if (xTextElement3 != null)
			{
				int num10 = z0eek(p0, xTextElement3, xTextElement4, p3: true, p4);
				if (num10 > 0)
				{
					num2 -= num10;
					m -= num10;
				}
				xTextElement3 = null;
				xTextElement4 = null;
				num4 += Math.Abs(num10);
			}
			if (dictionary[xTextElement5] == z0ghj.z0rek)
			{
				num4 += z0rek((XTextContainerElement)xTextElement5, p1, p2, p3, p4);
			}
			else if (dictionary[xTextElement5] == z0ghj.z0tek && xTextElement5 is XTextContainerElement)
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement5;
				if (!xTextContainerElement.z0sek())
				{
					num4 += z0rek(xTextContainerElement, p1, p2, p3, p4);
				}
			}
		}
		if (xTextElement3 != null)
		{
			int num11 = xTextElementList.z0vek(xTextElement3);
			if (num11 >= 0 && num5 > num11)
			{
				num5 = num11;
			}
			int num12 = z0eek(p0, xTextElement3, xTextElement4, p3: true, p4);
			num4 += Math.Abs(num12);
		}
		if (p1.ContainsKey(xTextContentElement))
		{
			p1[xTextContentElement] = Math.Min(p1[xTextContentElement], num5);
		}
		else
		{
			p1[xTextContentElement] = num5;
		}
		return num4;
	}

	public new void z0grk()
	{
		if (z0pek())
		{
			return;
		}
		try
		{
			z0ZzZzhkh.z0nrk = true;
			if (z0frk())
			{
				z0tek(p0: false);
				z0tek(z0erk(), p1: false);
				z0tek(p0: false);
				return;
			}
			z0rrk();
			z0crk = -1f;
			if (z0cek() && z0prk() != 0)
			{
				int num = z0pek(p0: true);
				if (num < 0)
				{
					num = 0;
				}
				num = z0tek(num, (z0ZzZzfxj)0, p2: true);
				z0tek(num, p1: false);
				return;
			}
			XTextElement p = base[z0erk()];
			XTextElement xTextElement = z0nek(p);
			if (xTextElement == null)
			{
				return;
			}
			int num2 = z0lrk(xTextElement);
			if (num2 >= 0)
			{
				num2 = z0tek(num2, (z0ZzZzfxj)0, p2: true);
				if (num2 < base.Count - 1)
				{
					z0tek(num2, p1: false);
				}
			}
		}
		finally
		{
			z0ZzZzhkh.z0nrk = false;
		}
	}

	public new bool z0frk()
	{
		return z0nrk;
	}

	public new int z0oek(bool p0)
	{
		if (z0pek())
		{
			return -1;
		}
		if (base.Count == 0)
		{
			return -1;
		}
		XTextElement xTextElement = z0ork();
		XTextFieldBorderElement xTextFieldBorderElement = xTextElement as XTextFieldBorderElement;
		if (xTextElement.z0jy().z0trk().z0krk() == xTextElement && !z0frk())
		{
			return -1;
		}
		xTextElement = XTextCheckBoxElementBase.z0eek(z0nek(xTextElement));
		if (xTextElement == null)
		{
			return -1;
		}
		xTextElement = XTextCheckBoxElementBase.z0eek(xTextElement);
		XTextContentElement xTextContentElement = xTextElement.z0jy();
		XTextDocument xTextDocument = z0drk();
		if (!xTextDocument.z0xek().z0lm(xTextElement))
		{
			xTextDocument.z0xek().z0ym(xTextDocument.z0cek());
			return -1;
		}
		XTextParagraphFlagElement xTextParagraphFlagElement = z0pek(xTextElement);
		XTextParagraphFlagElement xTextParagraphFlagElement2 = z0pek(z0ork());
		XTextContainerElement xTextContainerElement = xTextElement.z0ji();
		int num = z0zek().z0nek() - 1;
		int p1 = xTextContentElement.z0trk().z0vek(xTextElement);
		if (xTextElement is XTextCheckBoxElementBase)
		{
			XTextElement xTextElement2 = xTextElement.z0hy();
			if (xTextElement2 != xTextElement)
			{
				p1 = xTextContentElement.z0trk().z0vek(xTextElement2);
				num = xTextElement2.z0jrk();
			}
		}
		XTextElement xTextElement3 = z0ork();
		ContentChangedEventArgs p2 = new ContentChangedEventArgs();
		bool p3 = false;
		int num2 = z0zek().z0nek();
		if (z0tek(xTextContainerElement, xTextElement, p0, ref p2, ref p3))
		{
			XTextDocumentContentElement.z0xrk = xTextElement is XTextCharElement;
			if (xTextElement is XTextCharElement || xTextElement is XTextParagraphFlagElement)
			{
				xTextDocument.z0dbk = true;
			}
			try
			{
				xTextDocument.z0bik();
				z0tek(p0: false);
				xTextDocument.Modified = true;
				if (!p3 && xTextParagraphFlagElement != xTextParagraphFlagElement2)
				{
					z0tek(xTextParagraphFlagElement, xTextParagraphFlagElement2, p2: false);
				}
				XTextContentElement.z0lgj z0lgj = new XTextContentElement.z0lgj();
				z0lgj.z0tek(p0: true);
				z0lgj.z0uek(p0: false);
				z0lgj.z0eek(p0: false);
				z0lgj.z0rek(xTextElement is XTextCharElement);
				if (!(xTextElement is XTextContainerElement))
				{
					xTextDocument.z0xck = xTextContainerElement;
				}
				xTextContentElement.z0au(z0lgj);
				xTextContentElement.z0wu(p1, -1, p2: false, p3: false);
				z0vek().z0frk();
				if (xTextElement is XTextParagraphFlagElement)
				{
					z0vek().z0uek(num2 - 1, 0);
				}
				else if (p3 && z0lrk(xTextElement) >= 0)
				{
					int p4 = z0lrk(xTextElement);
					z0vek().z0uek(p4, 0);
				}
				else if (xTextElement3 != null && z0lrk(xTextElement3) >= 0)
				{
					int p5 = z0lrk(xTextElement3);
					xTextDocument.z0kxk = true;
					z0vek().z0uek(p5, 0);
					xTextDocument.z0kxk = false;
				}
				else
				{
					if (xTextFieldBorderElement != null && xTextFieldBorderElement.z0mek() == (z0ZzZzzvj)1)
					{
						z0vek().z0frk();
						if (SafeGet(xTextFieldBorderElement.z0jrk()) == xTextFieldBorderElement)
						{
							XTextElement xTextElement4 = SafeGet(num);
							if (xTextElement4 is XTextCharElement && ((XTextCharElement)xTextElement4).z0oek() && xTextElement4.z0ji() == xTextFieldBorderElement.z0ji())
							{
								num = xTextFieldBorderElement.z0jrk();
							}
						}
					}
					z0vek().z0uek(num, 0);
				}
				xTextDocument.z0ank()?.z0gb(p0: true);
				xTextContainerElement.z0zi(p2);
				if (base[z0zek().z0nek()] is XTextFieldBorderElement)
				{
					XTextFieldBorderElement xTextFieldBorderElement2 = (XTextFieldBorderElement)base[z0zek().z0nek()];
					if (xTextFieldBorderElement2.z0ji() is XTextInputFieldElementBase xTextInputFieldElementBase && ((XTextFieldElementBase)xTextInputFieldElementBase).z0tek() == xTextFieldBorderElement2)
					{
						xTextInputFieldElementBase.z0rek(p0: true, p1: true);
					}
				}
			}
			finally
			{
				XTextDocumentContentElement.z0xrk = false;
				xTextDocument.z0xck = null;
				xTextDocument.z0aok();
				xTextDocument.z0dbk = false;
			}
			return z0zek().z0nek();
		}
		xTextDocument.z0dbk = false;
		return -1;
	}

	public XTextElement z0tek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("containerType");
		}
		XTextContainerElement p1 = null;
		int p2 = -1;
		z0tek(out p1, out p2);
		while (p1 != null)
		{
			if (p0.IsInstanceOfType(p1))
			{
				return p1;
			}
			p1 = p1.z0ji();
		}
		return null;
	}

	public new virtual XTextDocument z0drk()
	{
		return z0vrk.z0jr();
	}

	internal new XTextElement z0mek(XTextElement p0)
	{
		if (!z0htk && p0.z0ptk() != null)
		{
			XTextElement xTextElement = p0.z0ptk().z0urk().z0xek(p0);
			if (xTextElement != null)
			{
				return xTextElement;
			}
		}
		XTextElementList xTextElementList = z0jrk();
		int num = z0uek(p0);
		if (num >= 0 && num < xTextElementList.Count - 1)
		{
			return xTextElementList[num + 1];
		}
		return null;
	}

	internal void z0srk()
	{
		Clear();
	}

	private new int z0pek(bool p0)
	{
		int num = z0erk();
		int num2 = z0erk() + z0prk();
		if (p0)
		{
			return Math.Min(num, num2);
		}
		return Math.Max(num, num2);
	}

	public new XTextElement z0nek(XTextElement p0)
	{
		if (!z0htk && p0.z0ptk() != null)
		{
			XTextElement xTextElement = p0.z0ptk().z0urk().z0pek(p0);
			if (xTextElement != null && (!(xTextElement is XTextSectionElement) || ((XTextSectionElement)xTextElement).IsCollapsed) && !(xTextElement is XTextTableElement))
			{
				return xTextElement;
			}
		}
		XTextElementList xTextElementList = z0jrk();
		int num = z0uek(p0);
		if (num > 0)
		{
			return xTextElementList[num - 1];
		}
		return null;
	}

	internal new void z0ark()
	{
		z0brk = z0gtk++;
	}

	public new int z0mek(bool p0)
	{
		if (z0pek())
		{
			return -1;
		}
		if (base.Count == 0)
		{
			return -1;
		}
		XTextElement xTextElement = z0ork();
		if (xTextElement == null)
		{
			return -1;
		}
		xTextElement = XTextCheckBoxElementBase.z0eek(xTextElement);
		XTextContentElement xTextContentElement = xTextElement.z0jy();
		XTextDocument xTextDocument = z0drk();
		if (!xTextDocument.z0xek().z0lm(xTextElement))
		{
			xTextDocument.z0xek().z0ym(xTextDocument.z0cek());
			return -1;
		}
		if (xTextContentElement.z0trk().LastElement == xTextElement)
		{
			return -1;
		}
		XTextParagraphFlagElement p1 = xTextElement.z0dy();
		XTextContainerElement xTextContainerElement = xTextElement.z0ji();
		int p2 = xTextContentElement.z0trk().z0vek(xTextElement);
		XTextElement xTextElement2 = xTextElement.z0ptk().z0xek(xTextElement);
		xTextElement2 = z0mek(xTextElement);
		if (xTextElement2 == null)
		{
			xTextElement2 = z0xek(xTextElement);
		}
		if (xTextElement2 == null)
		{
			xTextElement2 = base.LastElement;
		}
		ContentChangedEventArgs p3 = new ContentChangedEventArgs();
		bool p4 = false;
		XTextParagraphFlagElement xTextParagraphFlagElement = null;
		if (xTextElement is XTextParagraphFlagElement)
		{
			int count = base.Count;
			for (int i = z0bek(xTextElement) + 1; i < count; i++)
			{
				if (base[i] is XTextParagraphFlagElement)
				{
					xTextParagraphFlagElement = (XTextParagraphFlagElement)base[i];
					break;
				}
			}
		}
		if (z0tek(xTextContainerElement, xTextElement, p0, ref p3, ref p4))
		{
			if (xTextParagraphFlagElement != null && xTextParagraphFlagElement.z0aek().z0ruk)
			{
				z0vek().z0rek(p0: true);
			}
			XTextDocumentContentElement.z0xrk = xTextElement is XTextCharElement;
			if (xTextElement is XTextCharElement || xTextElement is XTextParagraphFlagElement)
			{
				xTextDocument.z0dbk = true;
			}
			try
			{
				xTextDocument.z0bik();
				z0tek(p0: false);
				XTextElement xTextElement3 = SafeGet(z0zek().z0nek() + 1);
				if (xTextElement3 != null)
				{
					z0tek(p1, xTextElement3.z0dy());
				}
				xTextDocument.Modified = true;
				XTextContentElement.z0lgj z0lgj = new XTextContentElement.z0lgj();
				z0lgj.z0tek(p0: true);
				z0lgj.z0uek(p0: false);
				z0lgj.z0eek(p0: false);
				z0lgj.z0rek(xTextElement is XTextCharElement);
				xTextContentElement.z0au(z0lgj);
				if (xTextDocument.z0ank() != null)
				{
					xTextDocument.z0ank().z0gb(p0: true);
				}
				if (!(xTextElement is XTextContainerElement))
				{
					xTextDocument.z0xck = xTextContainerElement;
				}
				xTextContentElement.z0eek(p2);
				if (p0)
				{
					xTextContainerElement.z0zi(p3);
				}
				if (xTextElement2 != null && Contains(xTextElement2))
				{
					z0vek().z0uek(z0lrk(xTextElement2), 0);
				}
				else
				{
					z0vek().z0uek(z0zek().z0nek(), 0);
				}
			}
			finally
			{
				XTextDocumentContentElement.z0xrk = false;
				xTextDocument.z0xck = null;
				xTextDocument.z0aok();
				xTextDocument.z0dbk = false;
			}
			return z0zek().z0nek();
		}
		return -1;
	}

	internal new bool z0qrk()
	{
		return z0xrk;
	}

	public void z0yek(float p0, float p1)
	{
		if (z0pek())
		{
			return;
		}
		XTextDocument xTextDocument = z0drk();
		if (xTextDocument == null)
		{
			return;
		}
		z0crk = -1f;
		z0ZzZzzlh z0ZzZzzlh2 = z0yek(p0, p1, p2: false);
		if (z0ZzZzzlh2 == null)
		{
			return;
		}
		bool flag = false;
		int num = 0;
		p0 -= z0ZzZzzlh2.z0xtk();
		XTextElement xTextElement = null;
		using (z0bpk z0bpk = z0ZzZzzlh2.z0urk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextParagraphListItemElement || !(p0 < current.z0it() + current.z0bi()))
				{
					continue;
				}
				if (current is XTextFieldBorderElement)
				{
					if (((XTextFieldBorderElement)current).z0mek() == (z0ZzZzzvj)0)
					{
						if (p0 >= current.z0it())
						{
							xTextElement = z0ZzZzzlh2.z0xek(current);
						}
					}
					else
					{
						xTextElement = current;
					}
					if (xTextElement != null)
					{
						break;
					}
				}
				float num2 = current.z0it() + current.z0bi() / 2f;
				if (!(p0 > num2))
				{
					xTextElement = current;
					break;
				}
			}
		}
		if (xTextElement == null)
		{
			XTextElement xTextElement2 = z0ZzZzzlh2.z0urk().z0krk();
			if (p0 < xTextElement2.z0it())
			{
				if (xTextElement2 is z0ZzZzgkh)
				{
					xTextElement2 = ((z0ZzZzgkh)xTextElement2).z0rek();
				}
				if (xTextElement2 is XTextParagraphFlagElement || xTextElement2 is XTextLineBreakElement)
				{
					num = z0lrk(xTextElement2);
					flag = false;
				}
				else
				{
					num = z0lrk(xTextElement2);
				}
			}
			else if (p0 > z0ZzZzzlh2.z0urk().LastElement.z0it())
			{
				xTextElement2 = z0ZzZzzlh2.z0urk().LastElement;
				if (xTextElement2 is z0ZzZzgkh)
				{
					xTextElement2 = ((z0ZzZzgkh)xTextElement2).z0rek();
				}
				if (xTextElement2 is XTextParagraphFlagElement || xTextElement2 is XTextLineBreakElement)
				{
					num = z0lrk(xTextElement2);
					flag = false;
				}
				else
				{
					num = z0lrk(xTextElement2) + 1;
					flag = true;
				}
			}
			if (base.Count == 1)
			{
				num = 0;
				flag = false;
			}
			else if (z0ZzZzzlh2.z0ptk().z0trk().Count == 1)
			{
				num = z0lrk(z0ZzZzzlh2.z0urk().LastElement);
				flag = false;
			}
		}
		else
		{
			if (xTextElement is z0ZzZzgkh)
			{
				xTextElement = ((z0ZzZzgkh)xTextElement).z0rek();
			}
			num = z0lrk(xTextElement);
			flag = false;
		}
		if (num < 0)
		{
			return;
		}
		if (num > base.Count)
		{
			num = base.Count - 1;
			flag = false;
		}
		if (num < 0)
		{
			num = 0;
			flag = false;
		}
		num = z0nek(num);
		int num3 = 0;
		if (!z0cek())
		{
			XTextContentElement xTextContentElement = base[z0zek().z0mek()].z0jy();
			XTextContentElement xTextContentElement2 = z0ZzZzzlh2.z0ptk();
			z0iek(p0: false);
			num3 = num - z0zek().z0mek();
			num = z0zek().z0mek();
			if (xTextContentElement != xTextContentElement2 && (xTextContentElement is XTextTableCellElement || xTextContentElement2 is XTextTableCellElement) && num3 > 0)
			{
				num3++;
			}
		}
		int num4 = z0tek(num, (z0ZzZzfxj)2, p2: true);
		if (num4 != num)
		{
			num = num4;
			num3 = 0;
		}
		if (num3 != 0 && xTextDocument.z0xek().z0bp() == FormViewMode.Strict)
		{
			XTextContainerElement p2 = null;
			int p3 = 0;
			z0tek(num, out p2, out p3, p3: false);
			for (XTextElement xTextElement3 = p2; xTextElement3 != null; xTextElement3 = xTextElement3.z0ji())
			{
				if (xTextElement3 is XTextInputFieldElementBase)
				{
					p2 = (XTextInputFieldElementBase)xTextElement3;
				}
			}
			XTextContainerElement p4 = null;
			int p5 = 0;
			z0tek(num + num3, out p4, out p5, p3: false);
			for (XTextElement xTextElement3 = p4; xTextElement3 != null; xTextElement3 = xTextElement3.z0ji())
			{
				if (xTextElement3 is XTextInputFieldElementBase)
				{
					p4 = (XTextInputFieldElementBase)xTextElement3;
				}
			}
			if (z0ZzZzafh.z0yek(p2, p4).z0yek(typeof(XTextInputFieldElementBase), p1: true) == null)
			{
				if (num3 > 0)
				{
					num3 = p2.z0dek().z0jrk() - num;
				}
				else if (num3 < 0)
				{
					num3 = p2.z0ie().z0jrk() - num + 1;
				}
				if (num == 0)
				{
					num3 = 0;
				}
			}
		}
		if (flag && num3 == 0 && num > 1 && base[num - 1] is XTextParagraphFlagElement)
		{
			flag = false;
		}
		z0tek(flag);
		if (!z0tek(num, num3))
		{
			z0drk().z0yyk().z0puk_jiejie20260327142557();
		}
	}

	public void z0tek(MoveTarget p0)
	{
		if (z0pek())
		{
			return;
		}
		switch (p0)
		{
		case MoveTarget.None:
			break;
		case MoveTarget.PageHome:
		{
			int num4 = z0erk();
			int num5 = 0;
			z0ZzZzwrj z0ZzZzwrj2 = z0ork().z0ptk().z0dtk();
			for (int num6 = num4 - 1; num6 >= 0; num6--)
			{
				if (base[num6].z0ptk().z0dtk() != z0ZzZzwrj2)
				{
					num5 = num6 + 1;
					break;
				}
			}
			if (num5 != num4)
			{
				z0tek(z0tek(num5, (z0ZzZzfxj)1, p2: true), p1: false);
				z0trk();
			}
			break;
		}
		case MoveTarget.PageEnd:
		{
			int num11 = z0erk();
			int num12 = base.Count - 1;
			z0ZzZzwrj z0ZzZzwrj3 = z0ork().z0ptk().z0dtk();
			for (int i = num11 + 1; i < base.Count; i++)
			{
				if (base[i].z0ptk().z0dtk() != z0ZzZzwrj3)
				{
					num12 = i - 1;
					break;
				}
			}
			if (num12 != num11)
			{
				z0tek(z0tek(num12, (z0ZzZzfxj)0, p2: true), p1: false);
				z0trk();
			}
			break;
		}
		case MoveTarget.DocumentHome:
			z0tek(z0tek(0, (z0ZzZzfxj)2, p2: true), p1: false);
			z0trk();
			break;
		case MoveTarget.CellHome:
		{
			XTextTableCellElement xTextTableCellElement = z0ork().z0brk();
			if (xTextTableCellElement != null)
			{
				int p1 = z0lrk(xTextTableCellElement.z0ie());
				z0tek(z0tek(p1, (z0ZzZzfxj)2, p2: true), p1: false);
				z0trk();
			}
			break;
		}
		case MoveTarget.ParagraphHome:
		{
			int p3 = 0;
			for (int num9 = z0erk() - 1; num9 >= 0; num9--)
			{
				if (base[num9] is XTextParagraphFlagElement)
				{
					p3 = num9 + 1;
					break;
				}
			}
			z0tek(z0tek(p3, (z0ZzZzfxj)2, p2: true), p1: false);
			z0trk();
			break;
		}
		case MoveTarget.Home:
			z0bek();
			z0trk();
			break;
		case MoveTarget.End:
			z0nek();
			z0trk();
			break;
		case MoveTarget.PreLine:
			z0iek();
			z0trk();
			break;
		case MoveTarget.NextLine:
			z0wrk();
			z0trk();
			break;
		case MoveTarget.ParagraphEnd:
		{
			int p5 = z0erk();
			for (int j = z0erk(); j < base.Count; j++)
			{
				if (base[j] is XTextParagraphFlagElement)
				{
					p5 = j;
					break;
				}
			}
			z0tek(z0tek(p5, (z0ZzZzfxj)2, p2: true), p1: false);
			z0trk();
			break;
		}
		case MoveTarget.CellEnd:
		{
			XTextTableCellElement xTextTableCellElement4 = z0ork().z0brk();
			if (xTextTableCellElement4 != null)
			{
				int p4 = z0lrk(xTextTableCellElement4.z0dek());
				z0tek(z0tek(p4, (z0ZzZzfxj)2, p2: true), p1: false);
				z0trk();
			}
			break;
		}
		case MoveTarget.PreCell:
		{
			XTextTableCellElement xTextTableCellElement3 = z0ork().z0brk();
			if (xTextTableCellElement3 != null)
			{
				((XTextTableCellElement)xTextTableCellElement3.z0gr().z0gtk().z0pek(xTextTableCellElement3))?.z0sr();
			}
			break;
		}
		case MoveTarget.NextCell:
		{
			XTextTableCellElement xTextTableCellElement2 = z0ork().z0brk();
			if (xTextTableCellElement2 != null)
			{
				((XTextTableCellElement)xTextTableCellElement2.z0gr().z0gtk().z0xek(xTextTableCellElement2))?.z0sr();
			}
			break;
		}
		case MoveTarget.BeforeField:
		{
			XTextFieldElementBase xTextFieldElementBase2 = (XTextFieldElementBase)z0tek(typeof(XTextInputFieldElementBase));
			if (xTextFieldElementBase2 != null)
			{
				int num2 = z0lrk(xTextFieldElementBase2.z0jrk());
				if (num2 < 0)
				{
					num2 = z0lrk(xTextFieldElementBase2);
				}
				if (num2 >= 0)
				{
					z0tek(z0tek(num2, (z0ZzZzfxj)2, p2: true), p1: false);
					z0trk();
				}
			}
			break;
		}
		case MoveTarget.AfterField:
		{
			XTextFieldElementBase xTextFieldElementBase4 = (XTextFieldElementBase)z0tek(typeof(XTextInputFieldElementBase));
			if (xTextFieldElementBase4 != null)
			{
				int num10 = z0lrk(xTextFieldElementBase4.z0tek());
				if (num10 < 0)
				{
					num10 = z0lrk(xTextFieldElementBase4);
				}
				if (num10 >= 0)
				{
					z0tek(z0tek(num10 + 1, (z0ZzZzfxj)2, p2: true), p1: false);
					z0trk();
				}
			}
			break;
		}
		case MoveTarget.BeforeTable:
		{
			XTextTableElement xTextTableElement2 = (XTextTableElement)z0tek(typeof(XTextTableElement));
			if (xTextTableElement2 != null && xTextTableElement2.z0zrk() != null)
			{
				int num8 = z0lrk(xTextTableElement2.z0zrk().z0ie());
				if (num8 > 0)
				{
					z0tek(z0tek(num8 - 1, (z0ZzZzfxj)2, p2: true), p1: false);
					z0trk();
				}
			}
			break;
		}
		case MoveTarget.AfterTable:
		{
			XTextTableElement xTextTableElement = (XTextTableElement)z0tek(typeof(XTextTableElement));
			if (xTextTableElement != null && xTextTableElement.z0erk() != null)
			{
				int num7 = z0lrk(xTextTableElement.z0erk().z0dek());
				if (num7 > 0)
				{
					z0tek(z0tek(num7 + 1, (z0ZzZzfxj)2, p2: true), p1: false);
					z0trk();
				}
			}
			break;
		}
		case MoveTarget.DocumentEnd:
		{
			int p2 = base.Count - 1;
			p2 = z0nek(p2);
			z0tek(z0tek(p2, (z0ZzZzfxj)2, p2: true), p1: false);
			z0trk();
			break;
		}
		case MoveTarget.FieldHome:
		{
			XTextFieldElementBase xTextFieldElementBase3 = (XTextFieldElementBase)z0tek(typeof(XTextInputFieldElementBase));
			if (xTextFieldElementBase3 != null)
			{
				int num3 = z0lrk(xTextFieldElementBase3.z0jrk());
				if (num3 >= 0)
				{
					z0tek(z0tek(num3 + 1, (z0ZzZzfxj)0, p2: true), p1: false);
					z0trk();
				}
			}
			break;
		}
		case MoveTarget.FieldEnd:
		{
			XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)z0tek(typeof(XTextInputFieldElementBase));
			if (xTextFieldElementBase != null)
			{
				int num = z0lrk(xTextFieldElementBase.z0tek());
				if (num >= 0)
				{
					z0tek(z0tek(num, (z0ZzZzfxj)0, p2: true), p1: false);
					z0trk();
				}
			}
			break;
		}
		}
	}

	public new void z0wrk()
	{
		if (z0pek())
		{
			return;
		}
		z0rrk();
		z0ZzZzzlh z0ZzZzzlh2 = z0lrk();
		if (z0ZzZzzlh2 == null || z0ZzZzzlh2.Count == 0)
		{
			return;
		}
		z0ZzZzzlh z0ZzZzzlh3 = z0oek();
		bool flag = z0drk().z0cu().z0ook() == FormViewMode.Strict;
		if (z0ZzZzzlh3 == null)
		{
			return;
		}
		if (z0crk <= 0f || flag)
		{
			XTextElement xTextElement = base[z0nek(z0erk())];
			z0crk = xTextElement.z0zrk();
		}
		XTextElement xTextElement2 = null;
		using (z0bpk z0bpk = ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh3).z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (!(current is XTextParagraphListItemElement) && current.z0zrk() >= z0crk)
				{
					xTextElement2 = current;
					break;
				}
			}
		}
		z0ZzZzfxj z0ZzZzfxj2 = (z0ZzZzfxj)1;
		if (xTextElement2 == null)
		{
			z0ZzZzfxj2 = (z0ZzZzfxj)0;
			xTextElement2 = z0ZzZzzlh3.LastElement;
		}
		int num = z0lrk(xTextElement2.z0hy());
		if (xTextElement2 is XTextParagraphFlagElement)
		{
			num = z0lrk(xTextElement2);
		}
		if (num < 0)
		{
			return;
		}
		int num2 = z0tek(num, z0ZzZzfxj2, p2: true);
		if (num2 <= z0erk() && z0ZzZzfxj2 == (z0ZzZzfxj)0)
		{
			num2 = z0tek(num2 + 1, (z0ZzZzfxj)1, p2: true);
		}
		else if (SafeGet(num2).z0ptk() == z0ZzZzzlh2 && z0ZzZzfxj2 == (z0ZzZzfxj)0)
		{
			num2 = z0tek(num2 + 1, (z0ZzZzfxj)1, p2: true);
		}
		XTextTableCellElement xTextTableCellElement = z0ZzZzzlh3[0].z0brk();
		if (num2 != num && flag && xTextTableCellElement != null)
		{
			XTextElement xTextElement3 = SafeGet(num2);
			if (xTextElement3 != null && xTextElement3.z0brk() != xTextTableCellElement)
			{
				int num3 = z0tek(num, (num2 <= num) ? ((z0ZzZzfxj)1) : ((z0ZzZzfxj)0), p2: true);
				if (SafeGet(num3)?.z0brk() == xTextTableCellElement)
				{
					num2 = num3;
				}
			}
		}
		z0tek(num2, p1: false);
	}

	private XTextInputFieldElementBase z0tek(XTextElement p0, bool p1)
	{
		XTextContainerElement p2 = null;
		int p3 = 0;
		z0tek(p0, out p2, out p3, p1);
		return z0ZzZzafh.z0yek((XTextElement)p2);
	}

	public int z0erk()
	{
		return z0vrk.z0oek().z0nek();
	}

	private void z0rrk()
	{
		if (z0nrk)
		{
			z0nrk = false;
		}
	}

	private static bool z0tek(char p0, char p1, bool p2)
	{
		if (p0 == p1)
		{
			return true;
		}
		if (p2)
		{
			if (p0 >= 'A' && p0 <= 'Z')
			{
				return p0 - 65 + 97 == p1;
			}
			if (p0 >= 'a' && p0 <= 'z')
			{
				return p0 - 97 + 65 == p1;
			}
		}
		return false;
	}

	public int z0tek(int p0, z0ZzZzfxj p1, bool p2)
	{
		if (base.Count == 0)
		{
			return 0;
		}
		XTextDocument xTextDocument = z0drk();
		if (xTextDocument == null || xTextDocument.z0yyk() == null)
		{
			return p0;
		}
		if (p0 < 0)
		{
			p0 = 0;
		}
		if (p0 > base.Count - 1)
		{
			p0 = base.Count - 1;
		}
		if (xTextDocument.z0yyk().z0ook() == FormViewMode.Strict)
		{
			XTextElement p3 = base[p0];
			if (z0tek(p3, z0frk()) == null)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = null;
				XTextElementList xTextElementList = z0jrk();
				int num = z0uek(p3);
				for (int num2 = num; num2 >= 0; num2--)
				{
					xTextInputFieldElementBase = z0tek(xTextElementList[num2], p1: false);
					if (xTextInputFieldElementBase != null)
					{
						break;
					}
				}
				XTextInputFieldElementBase xTextInputFieldElementBase2 = null;
				if (p1 != 0 || xTextInputFieldElementBase == null)
				{
					for (int i = num; i < base.Count; i++)
					{
						xTextInputFieldElementBase2 = z0tek(xTextElementList[i], p1: false);
						if (xTextInputFieldElementBase2 != null)
						{
							break;
						}
					}
				}
				if (xTextInputFieldElementBase == null && xTextInputFieldElementBase2 == null)
				{
					return 0;
				}
				XTextInputFieldElementBase xTextInputFieldElementBase3 = null;
				switch (p1)
				{
				case (z0ZzZzfxj)0:
					xTextInputFieldElementBase3 = xTextInputFieldElementBase;
					break;
				case (z0ZzZzfxj)1:
					xTextInputFieldElementBase3 = xTextInputFieldElementBase2;
					break;
				case (z0ZzZzfxj)2:
					if (xTextInputFieldElementBase != null && xTextInputFieldElementBase2 != null)
					{
						z0ZzZzbdh p4 = xTextInputFieldElementBase.z0dek().z0qyk();
						z0ZzZzbdh p5 = xTextInputFieldElementBase2.z0ie().z0qyk();
						z0ZzZzbdh z0ZzZzbdh2 = base[p0].z0qyk();
						float num3 = z0ZzZzjmk.z0eek(z0ZzZzbdh2.z0tek(), z0ZzZzbdh2.z0yek(), p4);
						float num4 = z0ZzZzjmk.z0eek(z0ZzZzbdh2.z0mek(), z0ZzZzbdh2.z0nek(), p5);
						xTextInputFieldElementBase3 = ((!(num3 > num4)) ? xTextInputFieldElementBase : xTextInputFieldElementBase2);
					}
					break;
				}
				if (xTextInputFieldElementBase3 == null)
				{
					xTextInputFieldElementBase3 = ((xTextInputFieldElementBase == null) ? xTextInputFieldElementBase2 : xTextInputFieldElementBase);
				}
				if (xTextInputFieldElementBase3 != null)
				{
					if (xTextInputFieldElementBase3 == xTextInputFieldElementBase)
					{
						int num5 = ((xTextInputFieldElementBase.z0ie().z0ctk() >= 0) ? xTextInputFieldElementBase.z0ie().z0ctk() : xTextInputFieldElementBase.z0ie().z0jrk());
						int num6 = ((xTextInputFieldElementBase.z0dek().z0ctk() >= 0) ? xTextInputFieldElementBase.z0dek().z0ctk() : xTextInputFieldElementBase.z0dek().z0jrk());
						p0 = ((num5 >= num6) ? xTextInputFieldElementBase.z0ie().z0jrk() : xTextInputFieldElementBase.z0dek().z0jrk());
					}
					else
					{
						XTextElement xTextElement = null;
						int num7 = ((xTextInputFieldElementBase2.z0ie().z0ctk() >= 0) ? xTextInputFieldElementBase2.z0ie().z0ctk() : xTextInputFieldElementBase2.z0ie().z0jrk());
						int num8 = ((xTextInputFieldElementBase2.z0dek().z0ctk() >= 0) ? xTextInputFieldElementBase2.z0dek().z0ctk() : xTextInputFieldElementBase2.z0dek().z0jrk());
						xTextElement = ((num7 >= num8) ? z0mek(xTextInputFieldElementBase2.z0dek()) : z0mek(xTextInputFieldElementBase2.z0ie()));
						if (xTextElement == null)
						{
							return 0;
						}
						p0 = z0lrk(xTextElement);
					}
				}
				if (p2)
				{
					z0uek(p0: true);
				}
			}
		}
		return p0;
	}

	private void z0trk()
	{
		z0drk().z0yyk()?.z0syk();
	}

	public XTextParagraphFlagElement z0yrk()
	{
		return z0pek(z0ork());
	}

	public new void z0urk()
	{
		if (z0pek() || base.Count < 1)
		{
			return;
		}
		if (z0drk().z0xek().z0bp() == FormViewMode.Strict)
		{
			int index = z0tek(z0erk(), (z0ZzZzfxj)2, p2: true);
			XTextElement xTextElement = base[index];
			XTextInputFieldElementBase xTextInputFieldElementBase = null;
			while (xTextElement != null)
			{
				if (xTextElement is XTextInputFieldElementBase)
				{
					xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextElement;
				}
				xTextElement = xTextElement.z0ji();
			}
			if (xTextInputFieldElementBase != null)
			{
				int num = z0lrk(((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk());
				int num2 = z0lrk(((XTextFieldElementBase)xTextInputFieldElementBase).z0tek());
				z0tek(num + 1, num2 - num);
			}
		}
		else
		{
			z0tek(base.Count - 1, 1 - base.Count);
			z0ktk = true;
		}
	}

	public bool z0irk()
	{
		return false;
	}

	public z0ZzZzzlh z0yek(float p0, float p1, bool p2)
	{
		z0jtk = null;
		if (z0pek())
		{
			return null;
		}
		XTextDocument xTextDocument = z0drk();
		if (xTextDocument == null)
		{
			return null;
		}
		XTextContentElement xTextContentElement = z0vek();
		XTextTableElement xTextTableElement = null;
		if (z0vek() is XTextDocumentBodyElement xTextDocumentBodyElement && xTextDocumentBodyElement.z0cu().z0myk())
		{
			xTextTableElement = xTextDocumentBodyElement.z0uek();
		}
		if (xTextTableElement != null)
		{
			XTextTableCellElement xTextTableCellElement = xTextTableElement.z0pek(p0, p1);
			if (xTextTableCellElement != null)
			{
				xTextContentElement = xTextTableCellElement;
			}
		}
		else
		{
			XTextElementList xTextElementList = xTextDocument.z0unk().z0eek_jiejie20260327142557(z0vek(), typeof(XTextTableElement));
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				for (int num = xTextElementList.Count - 1; num >= 0; num--)
				{
					XTextTableCellElement xTextTableCellElement2 = ((XTextTableElement)xTextElementList[num]).z0pek(p0, p1);
					if (xTextTableCellElement2 != null)
					{
						xTextContentElement = xTextTableCellElement2;
						break;
					}
				}
			}
			if (xTextContentElement == z0vek())
			{
				XTextElementList xTextElementList2 = xTextDocument.z0unk().z0eek_jiejie20260327142557(z0vek(), typeof(XTextContentElement));
				for (int num2 = xTextElementList2.Count - 1; num2 >= 0; num2--)
				{
					XTextContentElement xTextContentElement2 = (XTextContentElement)xTextElementList2[num2];
					if (!(xTextContentElement2 is XTextTableCellElement) && !((XTextElement)xTextContentElement2).z0krk() && (!(xTextContentElement2 is XTextSectionElement) || !((XTextSectionElement)xTextContentElement2).z0rek()) && xTextContentElement2.z0qyk().z0eek(p0, p1))
					{
						xTextContentElement = xTextContentElement2;
						break;
					}
				}
			}
		}
		z0ZzZzzlh z0ZzZzzlh2 = xTextContentElement.z0eek(p0, p1, p2);
		if (z0ZzZzzlh2 == null && !(xTextContentElement is XTextDocumentContentElement))
		{
			z0jtk = new WeakReference(xTextContentElement);
		}
		if (z0ZzZzzlh2 != null && (z0ZzZzzlh2.z0brk() || z0ZzZzzlh2.z0jrk_jiejie20260327142557()) && z0ZzZzzlh2.LastElement is XTextParagraphFlagElement && p0 > z0ZzZzzlh2.z0xtk() + z0ZzZzzlh2.z0itk())
		{
			return z0ZzZzzlh2;
		}
		if (z0ZzZzzlh2 != null && z0ZzZzzlh2.z0brk())
		{
			XTextSectionElement xTextSectionElement = z0ZzZzzlh2.z0mek();
			z0ZzZzzlh2 = xTextSectionElement.z0eek(p0, p1, p2);
			if (z0ZzZzzlh2 == null)
			{
				z0ZzZzzlh2 = xTextSectionElement.z0zek().z0uek();
			}
		}
		if (z0ZzZzzlh2 != null && z0ZzZzzlh2.z0jrk_jiejie20260327142557())
		{
			XTextTableElement xTextTableElement2 = z0ZzZzzlh2.z0ntk();
			z0ZzZzbdh z0ZzZzbdh2 = xTextTableElement2.z0qyk();
			XTextTableRowElement xTextTableRowElement = null;
			using (z0bpk z0bpk = xTextTableElement2.z0crk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)z0bpk.Current;
					if (z0ZzZzbdh2.z0pek() + xTextTableRowElement2.z0yt() + xTextTableRowElement2.Height >= p1)
					{
						xTextTableRowElement = xTextTableRowElement2;
						break;
					}
				}
			}
			if (xTextTableRowElement == null)
			{
				xTextTableRowElement = (XTextTableRowElement)xTextTableElement2.z0crk().LastElement;
			}
			if (xTextTableRowElement == null || xTextTableRowElement.z0rek().Count == 0)
			{
				return null;
			}
			XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextTableRowElement.z0rek().LastElement;
			if (p0 <= z0ZzZzbdh2.z0oek())
			{
				xTextTableCellElement3 = (XTextTableCellElement)xTextTableRowElement.z0rek()[0];
			}
			else if (p0 >= z0ZzZzbdh2.z0mek())
			{
				xTextTableCellElement3 = (XTextTableCellElement)xTextTableRowElement.z0rek().LastElement;
			}
			if (xTextTableCellElement3.z0bek())
			{
				xTextTableCellElement3 = xTextTableCellElement3.z0hrk();
			}
			z0ZzZzzlh2 = xTextTableCellElement3.z0eek(p0, p1, p2);
			if (z0ZzZzzlh2 == null)
			{
				z0ZzZzzlh2 = ((XTextContentElement)xTextTableCellElement3).z0zek().z0uek();
			}
		}
		return z0ZzZzzlh2;
	}

	public new XTextElement z0ork()
	{
		if (base.Count > 0)
		{
			z0ZzZzhkh z0ZzZzhkh2 = z0vrk.z0oek();
			if (z0ZzZzhkh2 == null)
			{
				return base[base.Count - 1];
			}
			int num = z0ZzZzhkh2.z0lrk();
			if (num >= 0 && num < base.Count)
			{
				if (z0xrk)
				{
					return SafeGet(z0ZzZzhkh2.z0nek());
				}
				if (z0ZzZzhkh2.z0yek() == ContentRangeMode.Cell)
				{
					if (z0ZzZzhkh2.z0qrk() > 0)
					{
						return z0ZzZzhkh2.z0grk().LastElement;
					}
					return z0ZzZzhkh2.z0grk().z0krk();
				}
				return SafeGet(z0ZzZzhkh2.z0nek() + z0ZzZzhkh2.z0qrk());
			}
		}
		return null;
	}

	public bool z0tek(int p0, int p1)
	{
		if (z0pek())
		{
			return false;
		}
		z0tek(ref p0, ref p1);
		return z0vek().z0uek(p0, p1);
	}

	private bool z0tek(XTextContainerElement p0, XTextElement p1, bool p2, ref ContentChangedEventArgs p3, ref bool p4)
	{
		XTextDocument xTextDocument = z0drk();
		int num = p0.z0be().z0bek(p1);
		if (p2)
		{
			ContentChangingEventArgs e = new ContentChangingEventArgs();
			e.Document = xTextDocument;
			e.Element = p0;
			e.ElementIndex = num;
			e.DeletingElements = new XTextElementList();
			e.DeletingElements.Add(p1);
			p0.z0cek(e);
			if (e.Cancel)
			{
				return false;
			}
		}
		z0ZzZzglh z0ZzZzglh2 = null;
		bool flag = false;
		if (z0yek(p1))
		{
			DocumentContentStyle documentContentStyle = p1.z0aek().z0yek();
			documentContentStyle.z0eek(p0: true);
			documentContentStyle.DeleterIndex = xTextDocument.z0syk().z0yek();
			int styleIndex = xTextDocument.z0gnk().GetStyleIndex(documentContentStyle);
			if (xTextDocument.z0uik())
			{
				xTextDocument.z0imk().z0eek(p1, p1.z0pek(), styleIndex);
			}
			p1.z0oek(styleIndex);
			if (!xTextDocument.z0hi().ShowLogicDeletedContent)
			{
				p1.z0qi(p0: false);
			}
			flag = true;
			p4 = true;
		}
		else
		{
			if (xTextDocument.z0uik())
			{
				XTextElementList xTextElementList = new XTextElementList();
				xTextElementList.Add(p1);
				z0ZzZzglh2 = new z0ZzZzglh(p0, num, xTextElementList, null);
				z0ZzZzglh2.z0eek(xTextDocument);
				z0ZzZzglh2.z0io(p0: true);
			}
			flag = p0.z0ai(p1);
			p0.z0we();
			if (flag)
			{
				p4 = false;
			}
		}
		if (p0 is XTextContentElement)
		{
			((XTextContentElement)p0).z0vek();
		}
		if (flag)
		{
			if (p1 is XTextParagraphFlagElement && p1.z0aek().z0ruk)
			{
				p0.z0qek().z0rek(p0: true);
				if (xTextDocument.z0uik())
				{
					xTextDocument.z0imk().z0eek((z0ZzZzbzj)7);
				}
			}
			xTextDocument.z0htk()?.z0qp(p1);
			((XTextElement)p0).z0rrk();
			if (z0ZzZzglh2 != null && xTextDocument.z0uik())
			{
				xTextDocument.z0bek(z0ZzZzglh2);
			}
			if (p3 != null)
			{
				p3.Document = xTextDocument;
				p3.Element = p0;
				p3.ElementIndex = num;
				p3.DeletedElements = new XTextElementList();
				p3.DeletedElements.Add(p1);
			}
			return true;
		}
		return false;
	}

	internal void z0tek(ref int p0, ref int p1)
	{
		if (base.Count == 0)
		{
			p0 = 0;
			p1 = 0;
			return;
		}
		int num = p0 + p1;
		if (p0 >= base.Count)
		{
			p0 = base.Count - 1;
		}
		if (p0 < 0)
		{
			p0 = 0;
		}
		if (num >= base.Count)
		{
			num = base.Count - 1;
		}
		if (num < 0)
		{
			num = 0;
		}
		p1 = num - p0;
	}

	public bool z0tek(int p0)
	{
		if (z0ltk >= 0)
		{
			return p0 <= z0ltk;
		}
		return false;
	}

	public new void Clear()
	{
		z0jtk = null;
		z0ark();
		base.Clear();
		z0ltk = -2147483648;
		z0zrk = true;
		z0nrk = false;
		z0htk = false;
	}

	public new int z0prk()
	{
		return z0vrk.z0oek().z0qrk();
	}
}
