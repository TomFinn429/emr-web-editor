using System;
using System.Diagnostics;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XParagraph")]
[DebuggerDisplay("<P>:{ PreviewString }")]
public class XTextParagraphElement : XTextContainerElement
{
	[NonSerialized]
	[z0ZzZzuqh]
	public new XTextTableCellElement z0tek;

	private new bool z0yek;

	public bool z0eek()
	{
		return z0yek;
	}

	public XTextParagraphFlagElement z0rek()
	{
		if (z0be() != null)
		{
			return z0be().LastElement as XTextParagraphFlagElement;
		}
		return null;
	}

	public XTextParagraphElement z0eek(bool p0)
	{
		XTextParagraphElement xTextParagraphElement = new XTextParagraphElement();
		xTextParagraphElement.z0bt(z0jr());
		xTextParagraphElement.z0oek(z0pek());
		XTextStringElement xTextStringElement = new XTextStringElement();
		xTextStringElement.z0bt(z0jr());
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (p0 && !z0jr().z0vek(current))
				{
					continue;
				}
				if (current is XTextCharElement)
				{
					XTextCharElement xTextCharElement = (XTextCharElement)current;
					if (xTextStringElement.z0eek(xTextCharElement))
					{
						xTextStringElement.z0eek(xTextCharElement, xTextCharElement.ToString());
						continue;
					}
					if (xTextStringElement.z0nek())
					{
						((zzz.z0ZzZzkuk<XTextElement>)xTextParagraphElement.z0be()).z0pek((XTextElement)xTextStringElement);
						xTextStringElement = new XTextStringElement();
					}
					xTextStringElement.z0bt(z0jr());
					xTextStringElement.z0eek(xTextCharElement, xTextCharElement.ToString());
				}
				else
				{
					if (xTextStringElement.z0nek())
					{
						((zzz.z0ZzZzkuk<XTextElement>)xTextParagraphElement.z0be()).z0pek((XTextElement)xTextStringElement);
						xTextStringElement = new XTextStringElement();
					}
					if (!(current is XTextParagraphFlagElement))
					{
						((zzz.z0ZzZzkuk<XTextElement>)xTextParagraphElement.z0be()).z0pek(current);
					}
				}
			}
		}
		if (xTextStringElement.z0nek())
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextParagraphElement.z0be()).z0pek((XTextElement)xTextStringElement);
		}
		return xTextParagraphElement;
	}

	public void z0rek(bool p0)
	{
		z0yek = p0;
	}
}
