using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer;

public class QueryUserHistoryDisplayTextEventArgs : WriterEventArgs
{
	private z0ZzZzyhh z0eek;

	private string z0rek;

	private bool z0tek;

	public bool ForLogicDelete => z0tek;

	public string Result
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

	public z0ZzZzyhh Info => z0eek;

	public QueryUserHistoryDisplayTextEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextElement element, z0ZzZzyhh info, bool forLogicDelete)
		: base(ctl, document, element)
	{
		z0eek = info;
		z0tek = forLogicDelete;
	}
}
