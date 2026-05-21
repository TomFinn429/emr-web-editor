using System;
using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class ContentChangingEventArgs : EventArgs
{
	private bool z0eek;

	private XTextElementList z0rek;

	private int z0tek;

	private object z0yek;

	private XTextElementList z0uek;

	private bool z0iek;

	private bool z0oek;

	private XTextElement z0pek;

	private XTextDocument z0mek;

	[JsonIgnore]
	public XTextElementList DeletingElements
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

	public string ElementName
	{
		[JSInvokable]
		get
		{
			return z0ZzZzafh.z0uek(z0pek);
		}
	}

	public bool CancelBubble
	{
		[JSInvokable]
		get
		{
			return z0oek;
		}
		[JSInvokable]
		set
		{
			z0oek = value;
		}
	}

	public bool Handled
	{
		[JSInvokable]
		get
		{
			return z0iek;
		}
		[JSInvokable]
		set
		{
			z0iek = value;
		}
	}

	[JsonIgnore]
	public XTextElementList InsertingElements
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
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	public bool Cancel
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

	[JsonIgnore]
	public object Tag
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

	[JsonIgnore]
	public XTextDocument Document
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	[JSInvokable]
	public string GetContainerNewText()
	{
		if (!(Element is XTextContainerElement xTextContainerElement))
		{
			return null;
		}
		XTextElementList xTextElementList = xTextContainerElement.z0be().z0pek();
		if (DeletingElements != null)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = DeletingElements.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				int num = xTextElementList.IndexOf(current);
				if (num >= 0)
				{
					xTextElementList.RemoveAt(num);
				}
			}
		}
		if (InsertingElements != null)
		{
			int num2 = ElementIndex;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (xTextElementList.Count > 0)
			{
				if (num2 >= xTextElementList.Count)
				{
					num2 = xTextElementList.Count - 1;
				}
			}
			else
			{
				num2 = 0;
			}
			for (int i = 0; i < InsertingElements.Count; i++)
			{
				xTextElementList.Insert(num2 + i, InsertingElements[i]);
			}
		}
		return xTextElementList.z0hrk();
	}
}
