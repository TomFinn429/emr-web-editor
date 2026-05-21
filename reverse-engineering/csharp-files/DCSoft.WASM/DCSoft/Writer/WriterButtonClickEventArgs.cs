using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class WriterButtonClickEventArgs : WriterEventArgs
{
	private bool z0eek;

	public string CommandName
	{
		[JSInvokable]
		get
		{
			if (base.Element is XTextButtonElement xTextButtonElement)
			{
				return xTextButtonElement.CommandName;
			}
			return null;
		}
	}

	[JsonIgnore]
	public XTextButtonElement ButtonElement => (XTextButtonElement)base.Element;

	public string ScriptTextForClick
	{
		[JSInvokable]
		get
		{
			if (base.Element is XTextButtonElement xTextButtonElement)
			{
				return xTextButtonElement.ScriptTextForClick;
			}
			return null;
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

	public string ButtonElementID
	{
		[JSInvokable]
		get
		{
			if (base.Element == null)
			{
				return null;
			}
			return base.Element.ID;
		}
	}

	public WriterButtonClickEventArgs(z0ZzZzdbj ctl, XTextButtonElement btn)
		: base(ctl, btn.z0jr(), btn)
	{
	}
}
