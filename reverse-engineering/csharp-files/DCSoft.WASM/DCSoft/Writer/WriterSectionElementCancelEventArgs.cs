using System;
using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class WriterSectionElementCancelEventArgs
{
	private XTextSectionElement z0eek;

	private bool z0rek;

	private z0ZzZzdbj z0tek;

	private XTextDocument z0yek;

	public string ElementID
	{
		[JSInvokable]
		get
		{
			return z0eek.ID;
		}
	}

	public bool Cancel
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

	[JsonIgnore]
	public z0ZzZzdbj WriterControl => z0tek;

	[JsonIgnore]
	public XTextSectionElement SectionElement => z0eek;

	public string ElementName
	{
		[JSInvokable]
		get
		{
			return z0eek.Name;
		}
	}

	[JsonIgnore]
	public XTextDocument Document => z0yek;

	public WriterSectionElementCancelEventArgs(z0ZzZzdbj ctl, XTextDocument doc, XTextSectionElement sec)
	{
		if (sec == null)
		{
			throw new ArgumentNullException("sec");
		}
		z0tek = ctl;
		z0yek = doc;
		z0eek = sec;
		Cancel = false;
	}
}
