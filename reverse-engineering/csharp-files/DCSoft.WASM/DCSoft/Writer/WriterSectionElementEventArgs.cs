using System;
using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class WriterSectionElementEventArgs : EventArgs
{
	private XTextSectionElement z0eek;

	private z0ZzZzdbj z0rek;

	private XTextDocument z0tek;

	public string ElementName
	{
		[JSInvokable]
		get
		{
			return z0eek.Name;
		}
	}

	[JsonIgnore]
	public XTextDocument Document => z0tek;

	public string ElementID
	{
		[JSInvokable]
		get
		{
			return z0eek.ID;
		}
	}

	[JsonIgnore]
	public z0ZzZzdbj WriterControl => z0rek;

	[JsonIgnore]
	public XTextSectionElement SectionElement => z0eek;

	public WriterSectionElementEventArgs(z0ZzZzdbj ctl, XTextDocument doc, XTextSectionElement sec)
	{
		if (sec == null)
		{
			throw new ArgumentNullException("sec");
		}
		z0rek = ctl;
		z0tek = doc;
		z0eek = sec;
	}
}
