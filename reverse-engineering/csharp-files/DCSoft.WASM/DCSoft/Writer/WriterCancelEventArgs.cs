using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer;

public class WriterCancelEventArgs
{
	private XTextDocument z0eek;

	private bool z0rek;

	private XTextElement z0tek;

	private z0ZzZzdbj z0yek;

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

	public XTextElement Element => z0tek;

	public XTextDocument Document => z0eek;

	public z0ZzZzdbj WriterControl => z0yek;

	public WriterCancelEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextElement element)
	{
		z0yek = ctl;
		z0eek = document;
		z0tek = element;
	}
}
