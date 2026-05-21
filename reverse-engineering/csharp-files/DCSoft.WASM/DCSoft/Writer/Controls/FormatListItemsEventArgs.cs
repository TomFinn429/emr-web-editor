using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.Controls;

public class FormatListItemsEventArgs
{
	private string z0eek = ",";

	private string z0rek;

	private string[] z0tek;

	private XTextDocument z0yek;

	private z0ZzZzdbj z0uek;

	private string[] z0iek;

	private string z0oek_jiejie20260327142557;

	private XTextElement z0pek;

	public string FormatString => z0rek;

	public z0ZzZzdbj WriterControl => z0uek;

	public XTextDocument Document => z0yek;

	public XTextElement Element => z0pek;

	public string[] UnselectedItems => z0tek;

	public string Separator => z0eek;

	public string Result
	{
		get
		{
			return z0oek_jiejie20260327142557;
		}
		set
		{
			z0oek_jiejie20260327142557 = value;
		}
	}

	public string[] SelectedItems => z0iek;

	public char SeparatorChar
	{
		get
		{
			if (z0eek != null && z0eek.Length > 0)
			{
				return z0eek[0];
			}
			return '\0';
		}
	}

	public FormatListItemsEventArgs(z0ZzZzdbj ctl, string formatString, XTextDocument document, XTextElement element, string[] selectedItems, string[] unSelectedItems, string separator)
	{
		z0uek = ctl;
		z0rek = formatString;
		z0yek = document;
		z0pek = element;
		z0iek = selectedItems;
		z0tek = unSelectedItems;
		z0eek = separator;
	}
}
