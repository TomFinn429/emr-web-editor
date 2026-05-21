using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer;

public class WriterBeforeUIKeyboardInputStringEventArgs : WriterEventArgs
{
	private string z0eek;

	private bool z0rek;

	private string z0tek;

	public bool Cancel
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

	public string InputString => z0tek;

	public string OutputString
	{
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	public WriterBeforeUIKeyboardInputStringEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextElement element, string inputString, string outputString)
		: base(ctl, document, element)
	{
		z0tek = inputString;
		z0eek = outputString;
	}
}
