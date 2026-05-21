using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer;

public class WriterDocumentPrintedEventArgs : WriterEventArgs
{
	private z0ZzZzyrj z0eek;

	public z0ZzZzyrj PrintResult => z0eek;

	public WriterDocumentPrintedEventArgs(z0ZzZzdbj ctl, XTextDocument document)
		: base(ctl, document, document)
	{
		z0eek = document.z0vrk();
		if (z0eek == null)
		{
			z0eek = new z0ZzZzyrj();
		}
	}
}
