using System;
using System.Collections.Generic;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZznzj
{
	private class z0uok : Dictionary<Type, XTextElementList>
	{
		public int z0eek;
	}

	private Dictionary<XTextContainerElement, z0uok> z0yek = new Dictionary<XTextContainerElement, z0uok>();

	private bool z0uek;

	private static void z0eek_jiejie20260327142557(XTextContainerElement p0, XTextElementList p1)
	{
		if (!p0.z0vek<XTextContainerElement>())
		{
			return;
		}
		IList<XTextElement> list = p0.z0xe();
		if (list == null)
		{
			return;
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (!(list[i] is XTextContainerElement xTextContainerElement))
			{
				continue;
			}
			if (xTextContainerElement is XTextTableElement)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)xTextContainerElement;
				p1.z0hrk(xTextTableElement);
				XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableElement.z0stk()).z0krk();
				int count2 = xTextTableElement.z0stk().Count;
				for (int j = 0; j < count2; j++)
				{
					XTextElement obj = array[j];
					XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)obj.z0be()).z0krk();
					int count3 = obj.z0be().Count;
					for (int k = 0; k < count3; k++)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array2[k];
						if (!xTextTableCellElement.z0jtk())
						{
							z0eek_jiejie20260327142557(xTextTableCellElement, p1);
						}
					}
				}
			}
			else
			{
				z0eek_jiejie20260327142557(xTextContainerElement, p1);
			}
		}
	}

	private static void z0rek(XTextContainerElement p0, XTextElementList p1)
	{
		if (!p0.z0vek<XTextSectionElement>())
		{
			return;
		}
		XTextElementList xTextElementList = p0.z0be();
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		int count = xTextElementList.Count;
		for (int i = 0; i < count; i++)
		{
			if (array[i] is XTextSectionElement)
			{
				p1.z0hrk(array[i]);
			}
		}
	}

	internal void z0eek_jiejie20260327142557()
	{
		if (z0yek == null)
		{
			return;
		}
		foreach (XTextContainerElement key in z0yek.Keys)
		{
			z0yek[key].z0eek = key.z0kek();
		}
	}

	internal void z0rek()
	{
		if (z0yek != null)
		{
			z0uek = false;
			z0tek();
			z0yek = null;
		}
	}

	internal void z0eek_jiejie20260327142557(bool p0)
	{
		z0uek = p0;
	}

	internal void z0tek()
	{
		if (z0uek)
		{
			return;
		}
		foreach (z0uok value in z0yek.Values)
		{
			foreach (XTextElementList value2 in value.Values)
			{
				value2.Clear();
			}
			value.Clear();
		}
		z0yek.Clear();
	}

	private static void z0tek(XTextContainerElement p0, XTextElementList p1)
	{
		if (!p0.z0vek<XTextContainerElement>())
		{
			return;
		}
		XTextElementList xTextElementList = p0.z0be();
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		int count = xTextElementList.Count;
		for (int i = 0; i < count; i++)
		{
			if (!(array[i] is XTextContainerElement))
			{
				continue;
			}
			XTextContainerElement xTextContainerElement = (XTextContainerElement)array[i];
			if (xTextContainerElement is XTextTableElement)
			{
				foreach (XTextTableRowElement item in ((XTextTableElement)xTextContainerElement).z0stk().z0xrk())
				{
					((zzz.z0ZzZzkuk<XTextElement>)p1).z0tek((zzz.z0ZzZzkuk<XTextElement>)item.z0rek());
					foreach (XTextTableCellElement item2 in item.z0rek().z0xrk())
					{
						z0tek(item2, p1);
					}
				}
			}
			else
			{
				z0tek(xTextContainerElement, p1);
			}
		}
	}

	public XTextElementList z0eek_jiejie20260327142557(XTextContainerElement p0, Type p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (p1 == typeof(XTextCharElement))
		{
			throw new ArgumentOutOfRangeException(p1.FullName);
		}
		z0uok z0uok = null;
		if (!z0yek.TryGetValue(p0, out z0uok))
		{
			z0uok = new z0uok();
			z0uok.z0eek = p0.z0kek();
			z0yek[p0] = z0uok;
		}
		if (z0uok.z0eek != p0.z0kek())
		{
			z0uok.z0eek = p0.z0kek();
			z0uok.Clear();
		}
		if (z0uok.ContainsKey(p1))
		{
			return z0uok[p1];
		}
		XTextElementList xTextElementList = null;
		if (p1 == typeof(XTextTableElement))
		{
			xTextElementList = new XTextElementList();
			z0eek_jiejie20260327142557(p0, xTextElementList);
		}
		else if (p1 == typeof(XTextContentElement))
		{
			xTextElementList = new XTextElementList();
			z0tek(p0, xTextElementList);
		}
		else if (p1 == typeof(XTextSectionElement))
		{
			xTextElementList = new XTextElementList();
			z0rek(p0, xTextElementList);
		}
		else
		{
			xTextElementList = p0.z0me(p1);
		}
		if (xTextElementList == null)
		{
			return null;
		}
		xTextElementList.Capacity = xTextElementList.Count;
		z0uok[p1] = xTextElementList;
		return xTextElementList;
	}
}
