using DCSoft.Writer.Dom;

namespace zzz;

internal static class z0ZzZztnj
{
	internal static XTextElementList z0eek(XTextDocument p0, bool p1, bool p2, bool p3, z0ZzZzpxj p4)
	{
		if (p4 == null)
		{
			p4 = p0.z0xek();
		}
		XTextElementList xTextElementList = new XTextElementList();
		if (p1 && p0 != null && p0.z0cuk().z0qrk() != 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0cuk().z0grk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (p4.z0np(current))
				{
					xTextElementList.Add(current);
				}
			}
		}
		if (p2)
		{
			if (p0.z0cuk().z0qrk() == 0)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = p0.z0mtk();
				if (p4.z0np(xTextParagraphFlagElement))
				{
					xTextElementList.Add(xTextParagraphFlagElement);
				}
			}
			else
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0cuk().z0krk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current2 = z0bpk.Current;
					if (p4.z0np(current2))
					{
						xTextElementList.Add(current2);
					}
				}
			}
		}
		if (p3)
		{
			if (p0.z0cuk().z0irk() != null && p0.z0cuk().z0irk().Count > 0)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0cuk().z0irk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current3 = z0bpk.Current;
					if (p4.z0np(current3))
					{
						xTextElementList.Add(current3);
					}
				}
			}
			else
			{
				XTextTableCellElement xTextTableCellElement = p0.z0itk().z0brk();
				if (xTextTableCellElement != null && p4.z0np(xTextTableCellElement))
				{
					xTextElementList.Add(xTextTableCellElement);
				}
			}
		}
		if (xTextElementList.Count > 0)
		{
			return xTextElementList;
		}
		return null;
	}
}
