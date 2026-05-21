using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using DCSoft.Writer.Dom;

namespace zzz;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DefaultMember("Item")]
public class z0ZzZzwxj : List<z0ZzZzqxj>
{
	private z0ZzZzqxj z0rek;

	private XTextElement z0tek;

	public z0ZzZzqxj z0eek(XTextElement p0)
	{
		if (p0.z0jrk() < 0)
		{
			return null;
		}
		if (z0tek == p0)
		{
			return z0rek;
		}
		z0tek = p0;
		z0rek = null;
		XTextElement xTextElement = p0.z0yek(typeof(XTextInputFieldElement), p1: false);
		if (xTextElement != null)
		{
			for (int num = base.Count - 1; num >= 0; num--)
			{
				z0ZzZzqxj z0ZzZzqxj2 = base[num];
				if (z0ZzZzqxj2.z0bek == xTextElement && z0ZzZzqxj2.z0eek(p0))
				{
					z0rek = z0ZzZzqxj2;
					return z0ZzZzqxj2;
				}
			}
		}
		XTextElementList xTextElementList = new XTextElementList();
		XTextElement xTextElement2 = p0;
		if (p0 is XTextCharElement || p0 is XTextParagraphFlagElement)
		{
			xTextElement2 = p0.z0ji();
		}
		while (xTextElement2 != null && !(xTextElement2 is XTextDocumentContentElement))
		{
			xTextElementList.Add(xTextElement2);
			xTextElement2 = xTextElement2.z0ji();
		}
		if (xTextElementList.Count == 0)
		{
			return null;
		}
		for (int num2 = base.Count - 1; num2 >= 0; num2--)
		{
			z0ZzZzqxj z0ZzZzqxj3 = base[num2];
			if (z0ZzZzqxj3.z0iek() != null && xTextElementList.Contains(z0ZzZzqxj3.z0iek()) && z0ZzZzqxj3.z0iek() == p0.z0ji() && z0ZzZzqxj3.z0eek(p0))
			{
				z0rek = z0ZzZzqxj3;
				return z0ZzZzqxj3;
			}
		}
		for (int num3 = base.Count - 1; num3 >= 0; num3--)
		{
			if (base[num3].z0iek() == null && base[num3].z0eek(p0))
			{
				z0rek = base[num3];
				return base[num3];
			}
		}
		return null;
	}

	public z0ZzZzwxj(int p0)
		: base(p0)
	{
	}

	public z0ZzZzwxj()
	{
	}
}
