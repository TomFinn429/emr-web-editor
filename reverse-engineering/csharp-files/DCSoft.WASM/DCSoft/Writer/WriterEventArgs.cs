using System;
using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class WriterEventArgs : EventArgs, IDisposable
{
	[NonSerialized]
	private z0ZzZzdbj z0eek;

	[NonSerialized]
	private XTextElement z0rek;

	[NonSerialized]
	private XTextDocument z0tek;

	public string ElementID
	{
		[JSInvokable]
		get
		{
			return z0rek?.ID;
		}
	}

	public int ElementHashCode
	{
		[JSInvokable]
		get
		{
			if (z0rek == null)
			{
				return 0;
			}
			return z0rek.GetHashCode();
		}
	}

	[JsonIgnore]
	[z0ZzZzuqh]
	public XTextElement Element => z0rek;

	public string ElementName
	{
		[JSInvokable]
		get
		{
			return z0ZzZzafh.z0uek(z0rek);
		}
	}

	[z0ZzZzuqh]
	[JsonIgnore]
	public z0ZzZzdbj WriterControl => z0eek;

	public string ElementTypeName
	{
		[JSInvokable]
		get
		{
			return z0rek?.GetType().Name;
		}
	}

	[z0ZzZzuqh]
	[JsonIgnore]
	public XTextDocument Document => z0tek;

	public WriterEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextElement element)
	{
		z0eek = ctl;
		z0tek = document;
		z0rek = element;
	}

	public virtual void Dispose()
	{
		z0eek = null;
		z0tek = null;
		z0rek = null;
	}
}
