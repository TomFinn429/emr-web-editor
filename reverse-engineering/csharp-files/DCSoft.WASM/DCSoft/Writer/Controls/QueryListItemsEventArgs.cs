using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer.Controls;

public class QueryListItemsEventArgs
{
	private string z0eek;

	private bool z0rek;

	private z0ZzZzdvj z0tek;

	[NonSerialized]
	private z0ZzZzdbj z0yek;

	private string z0uek;

	private bool z0iek = true;

	private string z0oek;

	[NonSerialized]
	private XTextDocument z0pek;

	private bool z0mek_jiejie20260327142557 = true;

	[NonSerialized]
	private XTextElement z0nek;

	private string z0bek;

	private string z0vek;

	private string z0cek;

	[z0ZzZzuqh]
	[JsonIgnore]
	public XTextElement Element => z0nek;

	[DefaultValue(false)]
	public bool Handled
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
	[z0ZzZzuqh]
	public XTextDocument Document => z0pek;

	public string ElementName
	{
		[JSInvokable]
		get
		{
			return z0ZzZzafh.z0uek(z0nek);
		}
	}

	[DefaultValue(null)]
	public string SpellCode
	{
		[JSInvokable]
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	[DefaultValue(null)]
	public string ListSourceName
	{
		[JSInvokable]
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	public string ControlName
	{
		get
		{
			if (z0yek != null)
			{
				return ((z0ZzZzmwh)z0yek).z0nek();
			}
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	public string ElementID
	{
		[JSInvokable]
		get
		{
			return z0nek?.ID;
		}
	}

	[DefaultValue(null)]
	public string PreText
	{
		[JSInvokable]
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	[DefaultValue(true)]
	public bool BufferItems
	{
		[JSInvokable]
		get
		{
			return z0mek_jiejie20260327142557;
		}
		set
		{
			z0mek_jiejie20260327142557 = value;
		}
	}

	[z0ZzZzuqh]
	[DefaultValue(null)]
	public z0ZzZzdvj Result
	{
		get
		{
			if (z0tek == null)
			{
				z0tek = new z0ZzZzdvj();
			}
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	public string PageName
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	[DefaultValue(true)]
	public bool RaiseEvent
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

	[z0ZzZzuqh]
	[JsonIgnore]
	public z0ZzZzdbj WriterControl => z0yek;

	[DefaultValue(null)]
	public string SpecifyValue
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

	public QueryListItemsEventArgs()
	{
	}

	[JSInvokable]
	public void AddResultItem(ListItem item)
	{
		if (z0tek == null)
		{
			z0tek = new z0ZzZzdvj();
		}
		z0tek.Add(item);
	}

	[JSInvokable]
	public void AddResultItemByTextValueTextInList(string strText, string strValue, string strTextInList)
	{
		ListItem listItem = new ListItem();
		listItem.Text = strText;
		listItem.Value = strValue;
		listItem.TextInList = strTextInList;
		if (z0tek == null)
		{
			z0tek = new z0ZzZzdvj();
		}
		z0tek.Add(listItem);
	}

	public QueryListItemsEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextElement element)
	{
		z0yek = ctl;
		z0pek = document;
		z0nek = element;
	}

	[JSInvokable]
	public void AddResultItemByTextValue(string strText, string strValue)
	{
		ListItem listItem = new ListItem();
		listItem.Text = strText;
		listItem.Value = strValue;
		if (z0tek == null)
		{
			z0tek = new z0ZzZzdvj();
		}
		z0tek.Add(listItem);
	}
}
