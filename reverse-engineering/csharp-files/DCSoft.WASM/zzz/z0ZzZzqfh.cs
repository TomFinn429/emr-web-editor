using System.Collections.Generic;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzqfh
{
	private readonly List<z0ZzZzkkh> z0tek = new List<z0ZzZzkkh>();

	private XTextDocument z0yek;

	private int z0uek;

	protected void z0eek()
	{
		z0tek.Clear();
	}

	public void z0eek(XTextDocument p0)
	{
		if (z0yek != p0)
		{
			z0yek = p0;
			z0eek();
		}
	}

	public XTextDocument z0rek()
	{
		return z0yek;
	}

	public virtual z0ZzZzkkh z0eek(XTextElement p0)
	{
		XTextDocumentContentElement xTextDocumentContentElement = p0.z0qek();
		if (z0gw(p0, p0, p2: true) != 0)
		{
			return null;
		}
		int num = xTextDocumentContentElement.z0frk().z0lrk(p0);
		if (num < 0)
		{
			return null;
		}
		int num2 = num;
		for (int num3 = num - 1; num3 >= 0; num3--)
		{
			switch (z0gw(p0, xTextDocumentContentElement.z0frk()[num3], p2: true))
			{
			case (z0ZzZzvvj)3:
				return null;
			case (z0ZzZzvvj)0:
				num = num3;
				continue;
			case (z0ZzZzvvj)2:
				num = num3;
				break;
			default:
				continue;
			case (z0ZzZzvvj)1:
				break;
			}
			break;
		}
		for (int i = num2 + 1; i < xTextDocumentContentElement.z0frk().Count; i++)
		{
			switch (z0gw(p0, xTextDocumentContentElement.z0frk()[i], p2: false))
			{
			case (z0ZzZzvvj)3:
				return null;
			case (z0ZzZzvvj)0:
				num2 = i;
				continue;
			case (z0ZzZzvvj)2:
				num2 = i;
				break;
			default:
				continue;
			case (z0ZzZzvvj)1:
				break;
			}
			break;
		}
		z0ZzZzkkh z0ZzZzkkh2 = new z0ZzZzkkh(xTextDocumentContentElement, num, num2 - num + 1);
		z0tek.Add(z0ZzZzkkh2);
		return z0ZzZzkkh2;
	}

	protected virtual z0ZzZzvvj z0gw(XTextElement p0, XTextElement p1, bool p2)
	{
		return (z0ZzZzvvj)3;
	}

	public virtual z0ZzZzkkh z0rek(XTextElement p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (z0rek().z0kek() != z0uek)
		{
			z0tek.Clear();
		}
		z0uek = z0rek().z0kek();
		int p1 = p0.z0jrk();
		foreach (z0ZzZzkkh item in z0tek)
		{
			if (item.z0yek(p1))
			{
				return item;
			}
		}
		z0ZzZzkkh z0ZzZzkkh2 = z0eek(p0);
		if (z0ZzZzkkh2 != null)
		{
			z0tek.Add(z0ZzZzkkh2);
		}
		return z0ZzZzkkh2;
	}
}
