using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer.Controls;

public class PromptProtectedContentEventArgs : WriterEventArgs
{
	private bool z0eek;

	private PromptProtectedContentMode z0rek = PromptProtectedContentMode.Details;

	private string z0tek;

	public PromptProtectedContentMode PromptMode
	{
		[JSInvokable]
		get
		{
			return z0rek;
		}
	}

	public bool Handled
	{
		[JSInvokable]
		get
		{
			return z0eek;
		}
		[JSInvokable]
		set
		{
			z0eek = value;
		}
	}

	public string Message
	{
		[JSInvokable]
		get
		{
			return z0tek;
		}
	}

	public PromptProtectedContentEventArgs(z0ZzZzdbj ctl, XTextDocument doc, XTextElement ele, string msg, PromptProtectedContentMode mode)
		: base(ctl, doc, ele)
	{
		z0tek = msg;
		z0rek = mode;
	}
}
