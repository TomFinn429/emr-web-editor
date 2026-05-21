using System;
using System.Collections.Generic;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzqgh
{
	private class z0ogj
	{
		public Type z0eek;

		public int z0rek;
	}

	private static Dictionary<Type, z0ogj> z0rek;

	private static List<Type> z0tek;

	private static int z0yek;

	public static Type[] z0eek()
	{
		return z0tek.ToArray();
	}

	public static void z0eek(Type p0)
	{
		z0yek++;
		if (p0 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (typeof(XTextElement).IsAssignableFrom(p0))
		{
			if (!z0tek.Contains(p0))
			{
				z0tek.Add(p0);
			}
			return;
		}
		throw new ArgumentOutOfRangeException(p0.FullName + "<> XTextElement");
	}

	public static void z0eek(Type p0, Type p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootType");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("serType");
		}
		z0ogj z0ogj = new z0ogj();
		z0ogj.z0rek = z0yek;
		z0ogj.z0eek = p1;
		z0rek[p0] = z0ogj;
	}

	static z0ZzZzqgh()
	{
		z0tek = new List<Type>();
		z0yek = 0;
		z0rek = new Dictionary<Type, z0ogj>();
		z0tek.Add(typeof(XTextDocument));
		z0tek.Add(typeof(XTextParagraphFlagElement));
		z0tek.Add(typeof(XTextImageElement));
		z0tek.Add(typeof(XTextLineBreakElement));
		z0tek.Add(typeof(XTextDocumentHeaderElement));
		z0tek.Add(typeof(XTextDocumentBodyElement));
		z0tek.Add(typeof(XTextDocumentFooterElement));
		z0tek.Add(typeof(XTextDocumentHeaderForFirstPageElement));
		z0tek.Add(typeof(XTextDocumentFooterForFirstPageElement));
		z0tek.Add(typeof(XTextTableElement));
		z0tek.Add(typeof(XTextTableRowElement));
		z0tek.Add(typeof(XTextTableColumnElement));
		z0tek.Add(typeof(XTextTableCellElement));
		z0tek.Add(typeof(XTextPageBreakElement));
		z0tek.Add(typeof(XTextInputFieldElement));
		z0tek.Add(typeof(XTextCheckBoxElement));
		z0tek.Add(typeof(XTextRadioBoxElement));
		z0tek.Add(typeof(XTextSignElement));
		z0tek.Add(typeof(XTextPageInfoElement));
		z0tek.Add(typeof(XTextSectionElement));
		z0tek.Add(typeof(XTextHorizontalLineElement));
		z0tek.Add(typeof(XTextLabelElement));
		z0tek.Add(typeof(XTextCustomShapeElement));
		z0tek.Add(typeof(XTextTextElement));
	}
}
