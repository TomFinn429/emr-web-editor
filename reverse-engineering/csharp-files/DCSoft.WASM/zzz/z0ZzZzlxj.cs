using System;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzlxj
{
	private bool z0oek = true;

	private bool z0pek_jiejie20260327142557;

	private int z0mek;

	private bool z0nek;

	private bool z0bek = true;

	private bool z0vek;

	private bool z0cek = true;

	public string z0eek(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		z0mek = 0;
		StringBuilder stringBuilder = new StringBuilder();
		z0eek(p0, stringBuilder);
		return stringBuilder.ToString();
	}

	public bool z0eek()
	{
		return z0bek;
	}

	public void z0eek(bool p0)
	{
		z0vek = p0;
	}

	public bool z0rek()
	{
		return z0nek;
	}

	public bool z0tek()
	{
		return z0oek;
	}

	public bool z0yek()
	{
		return z0vek;
	}

	public void z0rek(bool p0)
	{
		z0oek = p0;
	}

	public void z0tek(bool p0)
	{
		z0pek_jiejie20260327142557 = p0;
	}

	public void z0eek(XTextElement p0, StringBuilder p1)
	{
		if ((!z0nek && !p0.z0yi()) || (!z0pek_jiejie20260327142557 && p0.z0tyk()))
		{
			return;
		}
		if (p0 is XTextCharElement)
		{
			((XTextCharElement)p0).z0rek(p1);
		}
		else if (p0 is XTextParagraphFlagElement)
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)p0;
			if (xTextParagraphFlagElement.z0ji() is XTextTableCellElement)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextParagraphFlagElement.z0ji();
				if (((XTextContentElement)xTextTableCellElement).z0zek() == null || ((XTextContentElement)xTextTableCellElement).z0zek().Length != 1)
				{
					p1.AppendLine();
				}
			}
			else
			{
				p1.AppendLine();
			}
		}
		else if (p0 is XTextInputFieldElement)
		{
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p0;
			if (z0bek && xTextInputFieldElement.StartBorderText != null && xTextInputFieldElement.StartBorderText.Length > 0)
			{
				p1.Append(xTextInputFieldElement.StartBorderText);
			}
			if (z0cek && xTextInputFieldElement.LabelText != null && xTextInputFieldElement.LabelText.Length > 0)
			{
				p1.Append(xTextInputFieldElement.LabelText);
			}
			int length = p1.Length;
			if (xTextInputFieldElement.z0crk())
			{
				z0eek(xTextInputFieldElement.z0be(), p1);
			}
			if (length == p1.Length && z0vek && xTextInputFieldElement.BackgroundText != null)
			{
				p1.Append(xTextInputFieldElement.BackgroundText);
			}
			if (z0cek && xTextInputFieldElement.UnitText != null && xTextInputFieldElement.UnitText.Length > 0)
			{
				p1.Append(xTextInputFieldElement.UnitText);
			}
			if (z0bek && xTextInputFieldElement.EndBorderText != null && xTextInputFieldElement.EndBorderText.Length > 0)
			{
				p1.Append(xTextInputFieldElement.EndBorderText);
			}
		}
		else if (p0 is XTextTableElement)
		{
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((XTextTableElement)p0).z0stk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
					if ((!xTextTableRowElement.z0yi() && !z0nek) || (!z0pek_jiejie20260327142557 && xTextTableRowElement.z0tyk()))
					{
						continue;
					}
					p1.AppendLine();
					XTextTableCellElement xTextTableCellElement2 = null;
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableRowElement.z0rek().z0ltk();
					while (z0bpk2.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)z0bpk2.Current;
						if ((xTextTableCellElement3.z0yi() || z0nek) && (z0pek_jiejie20260327142557 || !xTextTableCellElement3.z0tyk()))
						{
							if (xTextTableCellElement2 != null)
							{
								p1.Append("   ");
							}
							z0eek(xTextTableCellElement3.z0be(), p1);
							xTextTableCellElement2 = xTextTableCellElement3;
						}
					}
				}
			}
			p1.AppendLine();
		}
		else if (p0 is XTextSectionElement)
		{
			p1.AppendLine();
			z0eek(p0.z0be(), p1);
		}
		else if (p0 is XTextTextElement || p0 is XTextStringElement)
		{
			p1.Append(p0.Text);
		}
		else if (p0 is XTextTDBarcodeElement || p0 is XTextNewBarcodeElement)
		{
			p1.Append(p0.Text);
		}
		else if (p0 is XTextContainerElement)
		{
			XTextContainerElement xTextContainerElement = (XTextContainerElement)p0;
			if (xTextContainerElement.z0crk())
			{
				z0eek(xTextContainerElement.z0be(), p1);
			}
		}
		else if (p0 is XTextLineBreakElement)
		{
			p1.AppendLine();
		}
		else if (p0 is XTextLabelElement)
		{
			p1.Append(p0.Text);
		}
		else if (p0 is XTextCheckBoxElementBase)
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)p0;
			p1.Append(xTextCheckBoxElementBase.z0ti());
		}
		else if (p0 is XTextPageInfoElement)
		{
			p1.Append(((XTextPageInfoElement)p0).z0rek());
		}
	}

	public bool z0uek()
	{
		return z0cek;
	}

	public void z0yek(bool p0)
	{
		z0bek = p0;
	}

	private void z0eek(XTextElementList p0, StringBuilder p1)
	{
		if ((!z0oek && z0mek >= 1) || p0 == null || p0.Count <= 0)
		{
			return;
		}
		z0mek++;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				z0eek(current, p1);
			}
		}
		z0mek--;
	}

	public void z0uek(bool p0)
	{
		z0cek = p0;
	}

	public bool z0iek()
	{
		return z0pek_jiejie20260327142557;
	}

	public void z0iek(bool p0)
	{
		z0nek = p0;
	}
}
