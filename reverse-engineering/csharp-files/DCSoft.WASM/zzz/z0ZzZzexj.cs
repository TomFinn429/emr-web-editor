using System;
using System.Collections.Generic;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzexj : z0ZzZzmxj, IDisposable
{
	private XTextDocument z0rek;

	private XTextDocumentBodyElement z0tek;

	[NonSerialized]
	private XTextElementList z0yek = new XTextElementList();

	private readonly XTextElement[] z0uek = new XTextElement[20];

	[NonSerialized]
	private z0ZzZzqxj z0iek;

	private Dictionary<XTextElement, z0ZzZzqxj> z0oek_jiejie20260327142557 = new Dictionary<XTextElement, z0ZzZzqxj>();

	[NonSerialized]
	private z0ZzZzwxj z0pek;

	private Dictionary<XTextInputFieldElement, z0ZzZzqxj> z0mek = new Dictionary<XTextInputFieldElement, z0ZzZzqxj>();

	public virtual void z0qp(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (z0fp().z0snk())
		{
			return;
		}
		z0tek = null;
		if (z0oek_jiejie20260327142557 != null)
		{
			bool flag = z0fp().z0kyk();
			for (XTextElement xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				if (flag)
				{
					z0ZzZzqxj z0ZzZzqxj2 = null;
					if (z0oek_jiejie20260327142557.TryGetValue(xTextElement, out z0ZzZzqxj2))
					{
						if (flag && z0ZzZzqxj2 != null && z0ZzZzqxj2.z0rek() != null)
						{
							z0rek.z0bek(z0ZzZzqxj2.z0rek());
						}
						z0oek_jiejie20260327142557.Remove(xTextElement);
					}
				}
				else
				{
					z0oek_jiejie20260327142557.Remove(xTextElement);
				}
			}
		}
		if (z0pek != null && z0pek.Count > 0)
		{
			z0eek(z0pek, p0);
		}
		if (z0yek == null || z0yek.Count <= 0)
		{
			return;
		}
		for (int num = z0yek.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement2 = z0yek[num];
			if (xTextElement2 == p0 || xTextElement2.z0zu(p0))
			{
				z0yek.RemoveAt(num);
			}
		}
	}

	public z0ZzZzqxj z0ap()
	{
		return z0iek;
	}

	public void z0sp()
	{
		Array.Clear(z0uek, 0, z0uek.Length);
		z0tek = null;
		if (z0mek != null)
		{
			foreach (z0ZzZzqxj value in z0mek.Values)
			{
				value.z0eek();
			}
			z0mek.Clear();
			z0mek = null;
		}
		z0pek = null;
		z0iek = null;
		if (z0oek_jiejie20260327142557 != null)
		{
			foreach (z0ZzZzqxj value2 in z0oek_jiejie20260327142557.Values)
			{
				value2?.z0eek();
			}
			z0oek_jiejie20260327142557.Clear();
			z0oek_jiejie20260327142557 = null;
		}
		z0yek = null;
	}

	public void z0dp(z0ZzZzwxj p0)
	{
		z0pek = p0;
	}

	public XTextDocument z0fp()
	{
		return z0rek;
	}

	public void z0gp()
	{
	}

	public z0ZzZzqxj z0hp()
	{
		if (z0pek == null || z0pek.Count == 0)
		{
			return null;
		}
		return z0pek[0];
	}

	public void Dispose()
	{
		z0rek = null;
		z0sp();
	}

	private z0ZzZzqxj z0eek(XTextElement p0)
	{
		if (z0tek == null)
		{
			z0tek = z0fp().z0xyk();
		}
		XTextElement xTextElement = null;
		if (p0 is XTextCharElement)
		{
			xTextElement = p0.z0ji();
			if (xTextElement == z0tek)
			{
				return null;
			}
			if (xTextElement is XTextTableCellElement)
			{
				xTextElement = xTextElement.z0ji()?.z0ji();
			}
			else if (XTextCheckBoxElementBase.z0cok.z0tek && xTextElement is XTextCheckBoxElementBase.z0cok)
			{
				xTextElement = ((XTextCheckBoxElementBase.z0cok)xTextElement).z0yek;
			}
			if (xTextElement == null)
			{
				return null;
			}
		}
		else if (p0 is XTextFieldBorderElement)
		{
			xTextElement = p0.z0ji();
		}
		else if (p0 is XTextContainerElement || p0 is XTextCheckBoxElementBase)
		{
			xTextElement = p0;
			if (xTextElement == z0tek)
			{
				return null;
			}
			if (p0 is XTextTableCellElement)
			{
				xTextElement = p0.z0ji()?.z0ji();
				if (xTextElement == null)
				{
					return null;
				}
			}
		}
		else
		{
			if (p0 is XTextObjectElement && ((XTextObjectElement)p0).ZOrderStyle == ElementZOrderStyle.InFrontOfText)
			{
				return null;
			}
			xTextElement = p0.z0ji();
			if (xTextElement is XTextTableCellElement)
			{
				xTextElement = xTextElement.z0ji()?.z0ji();
			}
			if (xTextElement == null)
			{
				return null;
			}
			if (xTextElement == z0tek)
			{
				return null;
			}
		}
		z0ZzZzqxj z0ZzZzqxj2 = null;
		if (z0oek_jiejie20260327142557 == null)
		{
			z0oek_jiejie20260327142557 = new Dictionary<XTextElement, z0ZzZzqxj>();
		}
		if (z0oek_jiejie20260327142557.TryGetValue(xTextElement, out z0ZzZzqxj2))
		{
			return z0ZzZzqxj2;
		}
		if (xTextElement is XTextCheckBoxElementBase)
		{
			z0ZzZzwxj z0ZzZzwxj2 = (z0ZzZzwxj)xTextElement.z0lek();
			if (z0ZzZzwxj2 != null && z0ZzZzwxj2.Count > 0)
			{
				foreach (z0ZzZzqxj item in z0ZzZzwxj2)
				{
					if (item.z0iek() != null && item.z0rek() != null && item.z0rek().z0eek(p0: false))
					{
						z0oek_jiejie20260327142557[item.z0iek()] = item;
						if (item.z0iek() == xTextElement)
						{
							z0ZzZzqxj2 = item;
						}
					}
				}
			}
			return z0ZzZzqxj2;
		}
		XTextElement[] array = z0uek;
		XTextElement xTextElement2 = xTextElement;
		int num = 0;
		while (xTextElement2 != null)
		{
			array[num++] = xTextElement2;
			xTextElement2 = xTextElement2.z0ji();
			if (xTextElement2 == z0tek || xTextElement2 is XTextDocumentContentElement || num > 15)
			{
				break;
			}
		}
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			XTextElement xTextElement3 = array[num2];
			if (xTextElement3 is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextElement3;
				if (!z0oek_jiejie20260327142557.TryGetValue(xTextInputFieldElement, out z0ZzZzqxj2))
				{
					z0ZzZzqxj z0ZzZzqxj3 = (z0ZzZzqxj)xTextInputFieldElement.z0lek();
					if (z0ZzZzqxj3 != null && z0ZzZzqxj3.z0rek().z0eek(p0: false))
					{
						z0oek_jiejie20260327142557[xTextInputFieldElement] = z0ZzZzqxj3;
						z0ZzZzqxj2 = z0ZzZzqxj3;
					}
				}
				if (z0ZzZzqxj2 != null)
				{
					for (int num3 = num2 - 1; num3 >= 0; num3--)
					{
						XTextElement xTextElement4 = array[num3];
						z0ZzZzqxj z0ZzZzqxj4 = (z0ZzZzqxj)xTextElement4.z0lek();
						if (z0ZzZzqxj4 != null && z0ZzZzqxj4.z0rek().z0eek(p0: false) && z0ZzZzqxj4.HeightClass)
						{
							z0oek_jiejie20260327142557[xTextElement4] = z0ZzZzqxj4;
							z0ZzZzqxj2 = z0ZzZzqxj4;
						}
						else
						{
							z0oek_jiejie20260327142557[xTextElement4] = z0ZzZzqxj2;
						}
					}
					break;
				}
			}
		}
		z0oek_jiejie20260327142557[xTextElement] = z0ZzZzqxj2;
		return z0ZzZzqxj2;
	}

	public void z0jp(z0ZzZzqxj p0)
	{
		if (z0pek == null)
		{
			z0pek = new z0ZzZzwxj();
		}
		z0pek.Clear();
		if (p0 != null)
		{
			z0pek.Add(p0);
		}
	}

	public void z0kp(XTextDocument p0)
	{
		z0rek = p0;
	}

	public z0ZzZzwxj z0lp()
	{
		return z0pek;
	}

	public virtual z0ZzZzqxj z0zo(XTextElement p0, z0ZzZzvxj p1)
	{
		if (p0 == null)
		{
			return null;
		}
		if (z0iek != null && z0iek.z0eek(p0))
		{
			return z0iek;
		}
		z0ZzZzwxj z0ZzZzwxj2 = z0pek;
		if (z0ZzZzwxj2 != null && z0ZzZzwxj2.Count > 0)
		{
			z0ZzZzqxj z0ZzZzqxj2 = z0ZzZzwxj2.z0eek(p0);
			if (z0ZzZzqxj2 != null)
			{
				return z0ZzZzqxj2;
			}
		}
		if (p1 != null && p1.z0vrk == p0.z0uik)
		{
			return p1.z0irk;
		}
		z0ZzZzqxj z0ZzZzqxj3 = z0eek(p0);
		if (p1 != null)
		{
			p1.z0vrk = p0.z0uik;
			p1.z0irk = z0ZzZzqxj3;
		}
		return z0ZzZzqxj3;
	}

	private void z0eek(z0ZzZzwxj p0, XTextElement p1)
	{
		bool flag = z0fp().z0kyk();
		for (int num = p0.Count - 1; num >= 0; num--)
		{
			z0ZzZzqxj z0ZzZzqxj2 = p0[num];
			bool flag2 = false;
			if (z0ZzZzqxj2.z0iek() == p1)
			{
				flag2 = true;
			}
			else if (z0ZzZzqxj2.z0iek() != null && z0ZzZzqxj2.z0iek().z0zu(p1))
			{
				flag2 = true;
			}
			if (flag2)
			{
				if (z0ZzZzqxj2.z0rek() != null && flag)
				{
					z0fp().z0bek(z0ZzZzqxj2.z0rek());
				}
				p0.RemoveAt(num);
			}
		}
	}

	private void z0eek(XTextContainerElement p0)
	{
		p0.z0kr();
		if (p0.z0ytk == null)
		{
			return;
		}
		foreach (XTextElement item in p0.z0ytk)
		{
			if (item is XTextContainerElement)
			{
				z0oek_jiejie20260327142557.Remove(item);
				z0eek((XTextContainerElement)item);
			}
		}
	}

	public void z0xo(z0ZzZzqxj p0)
	{
		z0iek = p0;
	}

	public void z0co(XTextElement p0)
	{
		if (!z0fp().z0snk() && !(p0 is XTextCharElement) && z0oek_jiejie20260327142557 != null)
		{
			z0tek = null;
			if (p0 is XTextContainerElement)
			{
				z0eek((XTextContainerElement)p0);
			}
			for (XTextElement xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				z0oek_jiejie20260327142557.Remove(xTextElement);
			}
		}
	}
}
