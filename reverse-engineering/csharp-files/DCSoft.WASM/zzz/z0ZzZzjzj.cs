using DCSoft.Writer.Dom;

namespace zzz;

internal static class z0ZzZzjzj
{
	private static string z0uek = "([{·‘“〈《「『【〔〖（．［｛￡￥";

	private static readonly bool[] z0iek = z0eek();

	private static string z0oek = "!),.:;?]}\u00a8·ˇˉ―‖’”…∶、。〃々〉》」』】〕〗！＂＇），．：；？］\uff40｜｝～￠";

	public static bool z0eek(XTextElement p0)
	{
		if (p0 is XTextCharElement)
		{
			return z0rek(((XTextCharElement)p0).z0mek());
		}
		if (p0 is XTextFieldBorderElement)
		{
			XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)p0;
			XTextFieldElementBase xTextFieldElementBase = xTextFieldBorderElement.z0rek();
			if (xTextFieldElementBase.z0jrk() == xTextFieldBorderElement)
			{
				return true;
			}
			if (xTextFieldElementBase is XTextInputFieldElementBase)
			{
				string text = ((XTextInputFieldElementBase)xTextFieldElementBase).z0jrk();
				if (text != null && text.Length > 0)
				{
					return true;
				}
			}
			return false;
		}
		if (p0 is XTextLineBreakElement)
		{
			return false;
		}
		return true;
	}

	public static bool z0eek(char p0)
	{
		if (z0uek == null)
		{
			return true;
		}
		return z0uek.IndexOf(p0) < 0;
	}

	public static bool z0rek(XTextElement p0)
	{
		if (p0 is XTextCharElement)
		{
			return z0eek(((XTextCharElement)p0).z0mek());
		}
		if (p0 is XTextFieldBorderElement)
		{
			XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)p0;
			if (xTextFieldBorderElement.z0rek().z0tek() == xTextFieldBorderElement)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public static bool z0rek(char p0)
	{
		if (z0oek == null)
		{
			return true;
		}
		return z0oek.IndexOf(p0) < 0;
	}

	public static bool z0tek(XTextElement p0)
	{
		if (p0 is XTextCharElement)
		{
			return false;
		}
		if (p0 is XTextParagraphFlagElement)
		{
			return true;
		}
		if (p0 is XTextLineBreakElement)
		{
			return true;
		}
		if (p0 is XTextPageBreakElement)
		{
			return true;
		}
		if (p0 is z0ZzZzfkh)
		{
			return true;
		}
		if (p0 is XTextSectionElement)
		{
			return true;
		}
		if (p0 is XTextHorizontalLineElement)
		{
			return true;
		}
		if (p0 is XTextFieldBorderElement)
		{
			XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)p0.z0ji();
			if (xTextFieldElementBase != null && xTextFieldElementBase.EndingLineBreak && xTextFieldElementBase.z0tek() == p0)
			{
				return true;
			}
		}
		return false;
	}

	public static bool z0yek(XTextElement p0)
	{
		if (p0 is XTextCharElement || p0 is XTextParagraphFlagElement)
		{
			return false;
		}
		if (p0 is XTextTableElement)
		{
			return true;
		}
		if (p0 is XTextPageBreakElement)
		{
			return true;
		}
		if (p0 is XTextSectionElement)
		{
			return true;
		}
		if (p0 is XTextHorizontalLineElement)
		{
			return true;
		}
		return false;
	}

	public static bool z0tek(char p0)
	{
		if (p0 < '\u007f')
		{
			return z0iek[(uint)p0];
		}
		if ('一' <= p0)
		{
			_ = 40869;
			return false;
		}
		return false;
	}

	private static bool[] z0eek()
	{
		bool[] array = new bool[127];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = false;
			if (i >= 97 && i <= 122)
			{
				array[i] = true;
			}
			else if (i >= 65 && i <= 90)
			{
				array[i] = true;
			}
			else if (i >= 48 && i <= 57)
			{
				array[i] = true;
			}
			else if (i == 46)
			{
				array[i] = true;
			}
		}
		return array;
	}
}
