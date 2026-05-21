using System;
using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class ContentChangedEventArgs : EventArgs
{
	private XTextElementList z0eek;

	private bool z0rek;

	private ContentChangedEventSource z0tek;

	private int z0yek;

	private bool z0uek;

	private XTextElementList z0iek;

	private bool z0oek;

	private XTextElement z0pek;

	private bool z0mek;

	private XTextDocument z0nek;

	private object z0bek;

	public ContentChangedEventSource EventSource
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

	public string PreviewElementText
	{
		[JSInvokable]
		get
		{
			return z0ZzZzafh.z0mek(z0pek);
		}
	}

	[JsonIgnore]
	public XTextElement Element
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	[JsonIgnore]
	public XTextDocument Document
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	public int ElementHashCode
	{
		[JSInvokable]
		get
		{
			if (z0pek == null)
			{
				return 0;
			}
			return z0pek.GetHashCode();
		}
	}

	[JsonIgnore]
	public object Tag
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	public string ElementTypeName
	{
		[JSInvokable]
		get
		{
			if (z0pek != null)
			{
				return z0pek.GetType().Name;
			}
			return null;
		}
	}

	public bool ElementChecked
	{
		[JSInvokable]
		get
		{
			if (z0pek is XTextCheckBoxElementBase)
			{
				return ((XTextCheckBoxElementBase)z0pek).Checked;
			}
			return false;
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

	[JsonIgnore]
	public XTextElementList DeletedElements
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
			if (z0pek is XTextTableCellElement xTextTableCellElement)
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

	public bool OnlyStyleChanged
	{
		[JSInvokable]
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	public string ElementName
	{
		[JSInvokable]
		get
		{
			return z0ZzZzafh.z0uek(z0pek);
		}
	}

	public bool UndoRedoCause
	{
		[JSInvokable]
		get
		{
			return EventSource == ContentChangedEventSource.UndoRedo;
		}
	}

	[JsonIgnore]
	public XTextElementList InsertedElements
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	public string ElementID
	{
		[JSInvokable]
		get
		{
			return z0pek?.ID;
		}
	}

	public int ElementIndex
	{
		[JSInvokable]
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public bool Handled
	{
		[JSInvokable]
		get
		{
			return z0mek;
		}
		[JSInvokable]
		set
		{
			z0mek = value;
		}
	}

	public bool LoadingDocument
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	public ContentChangedEventArgs()
	{
	}

	public ContentChangedEventArgs(XTextDocument doc, XTextElement element, ContentChangedEventSource src)
	{
		z0nek = doc;
		z0pek = element;
		z0tek = src;
	}
}
