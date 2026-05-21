using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.Controls;

public class ParseSelectedItemsEventArgs
{
	private string z0eek = ",";

	private string[] z0rek;

	private string z0tek;

	private z0ZzZzdbj z0yek;

	private XTextElement z0uek;

	private string[] z0iek;

	private XTextDocument z0oek;

	private string z0pek;

	public string[] Items => z0iek;

	[JsonIgnore]
	public z0ZzZzdbj WriterControl => z0yek;

	[JsonIgnore]
	public XTextDocument Document => z0oek;

	public string Separator => z0eek;

	public string FormatString => z0tek;

	public string Text => z0pek;

	public string[] Result
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

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

	[JsonIgnore]
	public XTextElement Element => z0uek;

	public ParseSelectedItemsEventArgs(z0ZzZzdbj ctl, string formatString, XTextDocument document, XTextElement element, string text, string[] items, string separator)
	{
		z0yek = ctl;
		z0tek = formatString;
		z0oek = document;
		if (z0oek == null && element != null)
		{
			z0oek = element.z0jr();
		}
		z0uek = element;
		z0pek = text;
		z0iek = items;
		z0eek = separator;
		if (document == null && element != null)
		{
			document = element.z0jr();
		}
	}
}
