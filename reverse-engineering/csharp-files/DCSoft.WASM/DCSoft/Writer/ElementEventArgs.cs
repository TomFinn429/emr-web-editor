using System;
using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class ElementEventArgs : EventArgs, IDisposable
{
	private z0ZzZzdbj z0eek;

	private bool z0rek;

	private XTextDocument z0tek;

	private XTextElement z0yek;

	private bool z0uek;

	[JsonIgnore]
	public z0ZzZzdbj WriterControl
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

	public string CellID
	{
		[JSInvokable]
		get
		{
			if (z0yek is XTextTableCellElement xTextTableCellElement)
			{
				XTextTableElement xTextTableElement = xTextTableCellElement.z0gr();
				if (xTextTableElement != null && !string.IsNullOrEmpty(xTextTableElement.ID))
				{
					return xTextTableElement.ID + "!" + xTextTableCellElement.z0oek();
				}
				return xTextTableCellElement.z0oek();
			}
			return null;
		}
	}

	public bool Handled
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

	public bool CancelBubble
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

	public int ElementHashCode
	{
		[JSInvokable]
		get
		{
			if (z0yek == null)
			{
				return 0;
			}
			return z0yek.GetHashCode();
		}
	}

	public string ElementTypeName
	{
		[JSInvokable]
		get
		{
			return z0yek?.GetType().Name;
		}
	}

	public string ElementName
	{
		[JSInvokable]
		get
		{
			return z0ZzZzafh.z0uek(z0yek);
		}
	}

	public string ElementID
	{
		[JSInvokable]
		get
		{
			return z0yek?.ID;
		}
	}

	[JsonIgnore]
	public XTextDocument Document
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	[JsonIgnore]
	public XTextElement Element
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public ElementEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextElement element)
	{
		z0eek = ctl;
		z0tek = document;
		z0yek = element;
	}

	public virtual void Dispose()
	{
		z0yek = null;
		z0eek = null;
	}

	public ElementEventArgs()
	{
	}

	public ElementEventArgs(XTextElement element)
	{
		z0tek = element.z0jr();
		z0yek = element;
		if (z0tek != null)
		{
			z0eek = z0tek.z0yyk();
		}
	}
}
