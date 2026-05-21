using System;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzpoj : IDisposable
{
	private bool[] z0nek;

	private bool z0bek;

	private bool z0vek = true;

	private bool z0cek;

	private bool z0xek;

	private bool z0zek;

	private StringBuilder z0lrk = new StringBuilder();

	private bool z0krk;

	private void z0eek()
	{
		if (z0lrk.Length > 0)
		{
			char c = z0lrk[z0lrk.Length - 1];
			if (c != '\r' && c != '\n')
			{
				z0lrk.AppendLine();
			}
		}
	}

	internal int z0rek()
	{
		return z0lrk.Length;
	}

	public override string ToString()
	{
		if (z0lrk == null)
		{
			return null;
		}
		return z0lrk.ToString();
	}

	public void z0eek(bool p0)
	{
		z0zek = p0;
	}

	private void z0eek(XTextElementList p0)
	{
		if (p0 == null || p0.Count <= 0)
		{
			return;
		}
		XTextElement xTextElement = p0.LastElement;
		if (!(xTextElement is XTextParagraphFlagElement))
		{
			xTextElement = null;
		}
		foreach (XTextElement item in p0.z0xrk())
		{
			if (item != xTextElement && (z0oek() || item.z0yi()) && z0eek(item.z0pek()))
			{
				z0eek(item);
			}
		}
	}

	internal void z0eek(XTextDocument p0)
	{
		if (z0lrk == null)
		{
			z0lrk = new StringBuilder();
		}
		else
		{
			z0lrk.Clear();
		}
		if (z0krk)
		{
			return;
		}
		z0nek = p0.z0gnk().z0eek(z0pek());
		if (z0nek != null)
		{
			bool flag = true;
			for (int num = z0nek.Length - 1; num >= 0; num--)
			{
				if (!z0nek[num])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				z0nek = null;
			}
		}
		z0krk = true;
	}

	public void z0tek()
	{
		z0lrk.Clear();
	}

	public void z0rek(bool p0)
	{
		z0cek = p0;
	}

	public void z0tek(bool p0)
	{
		z0bek = p0;
	}

	private void z0eek(XTextElement p0)
	{
		if (p0 is XTextCharElement)
		{
			((XTextCharElement)p0).z0rek(z0lrk);
			return;
		}
		if (p0 is XTextParagraphFlagElement || p0 is XTextLineBreakElement || p0 is XTextPageBreakElement)
		{
			z0yek();
			return;
		}
		if (p0 is XTextInputFieldElement xTextInputFieldElement)
		{
			z0rek();
			if (z0iek())
			{
				string startBorderText = xTextInputFieldElement.StartBorderText;
				if (!string.IsNullOrEmpty(startBorderText))
				{
					z0eek(startBorderText);
				}
				else
				{
					z0eek('[');
				}
			}
			if (z0uek())
			{
				z0eek(xTextInputFieldElement.LabelText);
			}
			int num = z0rek();
			if (xTextInputFieldElement.z0crk())
			{
				z0eek(xTextInputFieldElement.z0be());
			}
			if (num == z0rek() && z0mek())
			{
				z0eek(xTextInputFieldElement.BackgroundText);
			}
			if (z0uek())
			{
				z0eek(xTextInputFieldElement.UnitText);
			}
			if (z0iek())
			{
				string endBorderText = xTextInputFieldElement.EndBorderText;
				if (!string.IsNullOrEmpty(endBorderText))
				{
					z0eek(endBorderText);
				}
				else
				{
					z0eek(']');
				}
			}
			return;
		}
		if (p0 is XTextLabelElement)
		{
			z0eek(((XTextLabelElement)p0).Text);
			return;
		}
		if (p0 is XTextTableElement xTextTableElement)
		{
			z0eek();
			{
				foreach (XTextTableRowElement item in xTextTableElement.z0crk().z0xrk())
				{
					if (!z0oek() && !item.z0yi())
					{
						continue;
					}
					z0eek();
					foreach (XTextTableCellElement item2 in item.z0rek().z0xrk())
					{
						if (!item2.z0bek())
						{
							int num2 = z0rek();
							z0eek(item2.z0be());
							if (num2 == z0rek())
							{
								z0eek(' ');
							}
							z0eek(' ');
						}
					}
				}
				return;
			}
		}
		if (p0 is XTextPageInfoElement)
		{
			z0eek(((XTextPageInfoElement)p0).z0rek());
		}
		else if (p0 is XTextHorizontalLineElement)
		{
			z0eek();
			z0eek("---");
			z0yek();
		}
		else if (p0 is XTextLabelElementBase)
		{
			z0eek(p0.Text);
		}
		else if (p0 is XTextImageElement)
		{
			z0eek(((XTextImageElement)p0).z0tek());
		}
		else if (p0 is XTextSectionElement)
		{
			z0eek();
			z0eek(p0.z0be());
		}
		else if (p0 is XTextButtonElement)
		{
			z0eek(p0.Text);
		}
		else if (p0 is XTextContainerElement)
		{
			z0eek(p0.z0be());
		}
	}

	private void z0eek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			z0lrk.Append(p0);
		}
	}

	private void z0yek()
	{
		z0lrk.AppendLine();
	}

	public string z0rek(XTextElement p0)
	{
		z0tek();
		z0eek(p0);
		string result = z0lrk.ToString();
		z0tek();
		return result;
	}

	public bool z0uek()
	{
		return z0vek;
	}

	public bool z0iek()
	{
		return z0cek;
	}

	private bool z0eek(int p0)
	{
		if (p0 < 0 || z0nek == null)
		{
			return true;
		}
		if (p0 < z0nek.Length)
		{
			return z0nek[p0];
		}
		return true;
	}

	public bool z0oek()
	{
		return z0xek;
	}

	public bool z0pek()
	{
		return z0zek;
	}

	public void z0yek(bool p0)
	{
		z0xek = p0;
	}

	private void z0eek(char p0)
	{
		z0lrk.Append(p0);
	}

	public void z0uek(bool p0)
	{
		z0vek = p0;
	}

	public void Dispose()
	{
		if (z0lrk != null)
		{
			z0lrk.Clear();
			z0lrk = null;
		}
		z0nek = null;
		z0krk = false;
	}

	public bool z0mek()
	{
		return z0bek;
	}
}
