using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;

namespace DCSoft.Writer;

public class ElementValidatingEventArgs : ElementEventArgs
{
	private ElementValidatingState z0eek;

	private string z0rek;

	private bool z0tek;

	private ValueValidateLevel z0yek;

	public bool Cancel
	{
		[JSInvokable]
		get
		{
			return z0tek;
		}
		[JSInvokable]
		set
		{
			z0tek = value;
		}
	}

	public ValueValidateLevel ResultLevel
	{
		[JSInvokable]
		get
		{
			return z0yek;
		}
		[JSInvokable]
		set
		{
			z0yek = value;
		}
	}

	public ElementValidatingState ResultState
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
			return z0rek;
		}
		[JSInvokable]
		set
		{
			z0rek = value;
		}
	}

	public ElementValidatingEventArgs(XTextElement element)
		: base(element)
	{
	}
}
