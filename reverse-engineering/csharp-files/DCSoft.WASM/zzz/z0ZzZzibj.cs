using System;
using System.Collections.Generic;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzibj : z0ZzZzyxj, IDisposable
{
	private int z0rek = -1;

	private int z0tek;

	private XTextDocument z0yek;

	private Dictionary<XTextContainerElement, CopySourceInfo> z0uek;

	private Dictionary<XTextContainerElement, CopySourceInfo> z0eek()
	{
		if (z0uek == null || z0yek.z0myk() != z0rek)
		{
			if (z0uek != null)
			{
				z0uek.Clear();
			}
			else
			{
				z0uek = new Dictionary<XTextContainerElement, CopySourceInfo>();
			}
			z0rek = z0yek.z0myk();
			z0eek(z0yek);
		}
		return z0uek;
	}

	private void z0eek(XTextContainerElement p0)
	{
		if (!p0.z0crk())
		{
			return;
		}
		XTextElementList xTextElementList = p0.z0be();
		int count = xTextElementList.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = xTextElementList.z0yek(i);
			if (!(xTextElement is XTextContainerElement))
			{
				continue;
			}
			if (xTextElement is XTextTableElement)
			{
				XTextElementList xTextElementList2 = xTextElement.z0be();
				if (xTextElementList2 == null)
				{
					continue;
				}
				int count2 = xTextElementList2.Count;
				for (int j = 0; j < count2; j++)
				{
					XTextElementList xTextElementList3 = xTextElementList2.z0yek(j)?.z0be();
					if (xTextElementList3 == null)
					{
						continue;
					}
					int count3 = xTextElementList3.Count;
					for (int k = 0; k < count3; k++)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElementList3.z0yek(k);
						if (xTextTableCellElement != null)
						{
							CopySourceInfo copySource = xTextTableCellElement.CopySource;
							if (copySource != null && !string.IsNullOrEmpty(copySource.z0tek()))
							{
								z0uek[xTextTableCellElement] = copySource;
							}
							z0eek(xTextTableCellElement);
						}
					}
				}
			}
			else
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
				CopySourceInfo copySource2 = xTextContainerElement.CopySource;
				if (copySource2 != null && !string.IsNullOrEmpty(copySource2.z0tek()))
				{
					z0uek[xTextContainerElement] = copySource2;
				}
				z0eek(xTextContainerElement);
			}
		}
	}

	public void z0zv(XTextDocument p0)
	{
		z0yek = p0;
	}

	public XTextDocument z0xv()
	{
		return z0yek;
	}

	public void z0cv()
	{
		if (z0uek != null)
		{
			z0uek.Clear();
			z0uek = null;
		}
	}

	public void Dispose()
	{
		if (z0uek != null)
		{
			z0uek.Clear();
			z0uek = null;
		}
		z0yek = null;
	}

	public int z0vv(XTextElement p0)
	{
		if (!z0xv().z0bu().EnableCopySource)
		{
			return 0;
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("sourceElement");
		}
		if (string.IsNullOrEmpty(p0.ID))
		{
			return 0;
		}
		if (z0tek > 0)
		{
			return 0;
		}
		z0tek++;
		try
		{
			Dictionary<XTextContainerElement, CopySourceInfo> dictionary = z0eek();
			if (dictionary == null || dictionary.Count == 0)
			{
				return 0;
			}
			int num = 0;
			bool flag = false;
			z0ZzZzabj z0ZzZzabj2 = null;
			if (!z0xv().z0snk() && z0xv().z0yyk() != null && !z0xv().z0yyk().z0jyk())
			{
				flag = true;
			}
			List<XTextContainerElement> list = new List<XTextContainerElement>();
			foreach (XTextContainerElement key in dictionary.Keys)
			{
				if (key.z0zu(p0))
				{
					continue;
				}
				z0ZzZzzuk obj = new z0ZzZzzuk(key.CopySource.z0tek());
				obj.z0eek(p0: true);
				if (obj.z0tek(p0.ID))
				{
					bool flag2 = true;
					XTextSectionElement xTextSectionElement = p0.z0iek();
					XTextSectionElement xTextSectionElement2 = key.z0iek();
					if (xTextSectionElement != null && xTextSectionElement2 != null && xTextSectionElement != xTextSectionElement2 && xTextSectionElement2.z0ki(p0.ID) != null)
					{
						flag2 = false;
					}
					if (flag2)
					{
						list.Add(key);
					}
				}
			}
			if (list.Count > 0)
			{
				List<XTextElement> list2 = new List<XTextElement>();
				foreach (XTextContainerElement item in list)
				{
					if (list2.Count > 0)
					{
						XTextContainerElement xTextContainerElement = item.z0ji();
						bool flag3 = false;
						while (xTextContainerElement != null)
						{
							if (list2.Contains(xTextContainerElement))
							{
								flag3 = true;
								break;
							}
							xTextContainerElement = xTextContainerElement.z0ji();
						}
						if (flag3)
						{
							continue;
						}
					}
					string text = item.CopySource.z0iek();
					string text2 = item.CopySource.z0eek();
					bool flag4 = false;
					object p1 = null;
					if (string.IsNullOrEmpty(text2))
					{
						flag4 = true;
						p1 = p0.z0yek(new z0ZzZzdxj());
					}
					else
					{
						flag4 = z0ZzZzdik.z0eek(p0, text2, out p1);
					}
					if (!flag4)
					{
						continue;
					}
					if (flag && z0ZzZzabj2 == null)
					{
						z0ZzZzabj2 = new z0ZzZzabj(z0xv().z0yyk());
					}
					bool flag5 = false;
					z0xv().z0vik();
					if (text == null || text.Length == 0)
					{
						item.z0krk(Convert.ToString(p1));
						flag5 = true;
					}
					else
					{
						flag5 = z0ZzZzdik.z0eek(item, text, p1, p3: false);
					}
					if (flag5)
					{
						num++;
						z0xv().z0wik();
						if (item.CopySource.z0yek())
						{
							list2.Add(item);
						}
					}
				}
			}
			if (z0ZzZzabj2 != null && num > 0)
			{
				z0ZzZzabj2.Restore();
			}
			return num;
		}
		finally
		{
			z0tek--;
		}
	}
}
