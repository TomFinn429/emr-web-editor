using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class WriterStartEditEventArgs : WriterEventArgs
{
	private XTextContainerElement z0eek;

	private bool z0rek;

	private string z0tek;

	private bool z0yek = true;

	private bool z0uek;

	public bool ReloadDocument
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

	public string ContainerElementName
	{
		[JSInvokable]
		get
		{
			return z0ZzZzafh.z0uek(z0eek);
		}
	}

	public string ContainerElementID
	{
		[JSInvokable]
		get
		{
			return z0eek.ID;
		}
	}

	public string DocumentID
	{
		[JSInvokable]
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	public bool Readonly
	{
		[JSInvokable]
		get
		{
			return z0uek;
		}
		[JSInvokable]
		set
		{
			z0uek = value;
		}
	}

	[JsonIgnore]
	public XTextContainerElement ContainerElement
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

	public bool CanDetectAgain
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

	internal WriterStartEditEventArgs(z0ZzZzdbj ctl, XTextDocument doc)
		: base(ctl, doc, null)
	{
		if (doc != null)
		{
			DocumentID = doc.ID;
		}
	}
}
