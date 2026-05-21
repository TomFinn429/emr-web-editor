using System.ComponentModel;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer;

public class WriterLinkEventArgs : WriterEventArgs
{
	private string z0eek;

	private string z0rek;

	[DefaultValue(null)]
	public virtual string Target => z0eek;

	[DefaultValue(null)]
	public string Reference => z0rek;

	public WriterLinkEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextElement element, string reference, string target)
		: base(ctl, document, element)
	{
		z0rek = reference;
		z0eek = target;
	}
}
