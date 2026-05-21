using System;
using System.Collections;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzpvj : z0ZzZzpjh, IDisposable
{
	private class z0tck : z0ZzZzoik
	{
		public new bool z0eek;

		public override IEnumerable GetChildNodes(object instance)
		{
			XTextElementList xTextElementList = null;
			xTextElementList = ((!(instance is XTextFieldElementBase)) ? ((XTextElement)instance).z0be() : ((XTextFieldElementBase)instance).z0rek());
			if (z0eek && xTextElementList != null)
			{
				return new z0ZzZzhik(xTextElementList);
			}
			return xTextElementList;
		}

		public z0tck(ArrayList p0)
			: base(p0, p1: true)
		{
		}
	}

	private XTextDocument z0rek;

	public XTextElement z0bb(XTextElement p0, Keys p1, bool p2, z0ZzZzheh p3)
	{
		XTextContainerElement xTextContainerElement = p0.z0ji();
		if (p0 is XTextFieldBorderElement)
		{
			XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)p0;
			if (xTextFieldBorderElement.z0mek() == (z0ZzZzzvj)0)
			{
				xTextContainerElement = xTextFieldBorderElement.z0ji().z0ji();
			}
		}
		else
		{
			_ = p0 is XTextCharElement;
		}
		MoveFocusHotKeys moveFocusHotKeys = MoveFocusHotKeys.None;
		while (xTextContainerElement != null)
		{
			if (xTextContainerElement.AcceptTab && p1 == Keys.Tab && !p2)
			{
				return null;
			}
			moveFocusHotKeys = xTextContainerElement.z0wr();
			if (moveFocusHotKeys != MoveFocusHotKeys.None)
			{
				break;
			}
			xTextContainerElement = xTextContainerElement.z0ji();
		}
		if (moveFocusHotKeys == MoveFocusHotKeys.None)
		{
			return null;
		}
		z0ZzZzacj z0ZzZzacj2 = z0eek(moveFocusHotKeys, p1, p2);
		if (z0ZzZzacj2 == (z0ZzZzacj)2 || z0ZzZzacj2 == (z0ZzZzacj)1)
		{
			XTextElement xTextElement = z0pb(p0, z0ZzZzacj2 == (z0ZzZzacj)1);
			XTextTableCellElement xTextTableCellElement = p0.z0brk();
			if (xTextTableCellElement != null && !p2)
			{
				XTextTableCellElement xTextTableCellElement2 = null;
				if (xTextElement != null)
				{
					xTextTableCellElement2 = xTextElement.z0brk();
				}
				if (xTextTableCellElement != xTextTableCellElement2 && z0eek(xTextTableCellElement, p1) && p3 != null && z0eek(xTextTableCellElement))
				{
					p3.z0eek(p0: true);
					return null;
				}
			}
			if (xTextElement != null && p1 == Keys.Return)
			{
				z0ZzZzqbj.z0epk = z0ZzZzafh.z0uek();
			}
			return xTextElement;
		}
		return null;
	}

	private bool z0eek(XTextTableCellElement p0, Keys p1)
	{
		if (p0.AcceptTab && p1 == Keys.Tab)
		{
			return false;
		}
		if (p0.z0jr() != null && p0.z0pu_jiejie20260327142557().AutoInsertTableRowWhenMoveToNextCell)
		{
			XTextTableElement xTextTableElement = p0.z0gr();
			if (xTextTableElement.z0ktk())
			{
				if (p0.z0xek() + p0.ColSpan != xTextTableElement.z0drk())
				{
					return false;
				}
				XTextTableRowElement xTextTableRowElement = p0.z0krk();
				if (xTextTableRowElement.AllowInsertRowDownUseHotKey == DCInsertRowDownUseHotKeys.Disable)
				{
					return false;
				}
				if (xTextTableRowElement.AllowInsertRowDownUseHotKey == DCInsertRowDownUseHotKeys.EnableOnlyForLastRow)
				{
					if (p0 == xTextTableElement.z0erk())
					{
						return true;
					}
					return false;
				}
				return true;
			}
		}
		return false;
	}

	public void Dispose()
	{
		z0rek = null;
	}

	public XTextDocument z0nb()
	{
		return z0rek;
	}

	private bool z0eek(XTextTableCellElement p0)
	{
		XTextTableElement xTextTableElement = p0.z0gr();
		z0ZzZzdbj z0ZzZzdbj2 = p0.z0cu();
		if (!z0ZzZzdbj2.z0ork() && xTextTableElement.z0ktk() && z0ZzZzdbj2.z0erk().z0am(xTextTableElement, (z0ZzZzbcj)255))
		{
			XTextElementList xTextElementList = (XTextElementList)z0ZzZzdbj2.z0eek("Table_InsertRowDown", p1: false, null, p3: true);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)((XTextTableRowElement)xTextElementList[0]).z0rek()[0];
				if (xTextTableCellElement.z0bek())
				{
					xTextTableCellElement = xTextTableCellElement.z0hrk();
				}
				z0ZzZzdbj2.z0rek(new WriterEventArgs(z0ZzZzdbj2, z0rek, xTextTableElement));
				xTextTableCellElement.z0sr();
				return true;
			}
		}
		return false;
	}

	public void z0mb(XTextDocument p0)
	{
		z0rek = p0;
	}

	public XTextElement z0pb(XTextElement p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("srcElement");
		}
		if (p0 is XTextFieldBorderElement && !p1)
		{
			XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)p0;
			if (xTextFieldBorderElement.z0mek() == (z0ZzZzzvj)0 && xTextFieldBorderElement.z0rek() != null && xTextFieldBorderElement.z0rek().z0vr())
			{
				return xTextFieldBorderElement.z0rek();
			}
		}
		ArrayList arrayList = new ArrayList();
		for (XTextElement xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			arrayList.Insert(0, xTextElement);
			if (xTextElement is XTextDocumentContentElement)
			{
				break;
			}
		}
		if (arrayList.Count == 0)
		{
			return null;
		}
		foreach (XTextElement item in new z0tck(arrayList)
		{
			z0eek = p1
		})
		{
			if (item.z0yi() && !arrayList.Contains(item) && item is XTextContainerElement)
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
				if (xTextContainerElement.z0vr() && (z0rek.z0yyk().z0ook() != FormViewMode.Strict || xTextContainerElement.z0yek(typeof(XTextInputFieldElementBase), p1: true) != null))
				{
					return xTextContainerElement;
				}
			}
		}
		return null;
	}

	private z0ZzZzacj z0eek(MoveFocusHotKeys p0, Keys p1, bool p2)
	{
		if (p0 != MoveFocusHotKeys.None && p0 != MoveFocusHotKeys.Default)
		{
			if ((p0 & MoveFocusHotKeys.Enter) == MoveFocusHotKeys.Enter && p1 == Keys.Return)
			{
				if (p2)
				{
					return (z0ZzZzacj)1;
				}
				return (z0ZzZzacj)2;
			}
			if ((p0 & MoveFocusHotKeys.Tab) == MoveFocusHotKeys.Tab && p1 == Keys.Tab)
			{
				if (p2)
				{
					return (z0ZzZzacj)1;
				}
				return (z0ZzZzacj)2;
			}
		}
		return (z0ZzZzacj)0;
	}
}
