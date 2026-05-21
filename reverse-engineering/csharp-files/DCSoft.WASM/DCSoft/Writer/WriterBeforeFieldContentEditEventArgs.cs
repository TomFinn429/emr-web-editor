using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer;

public class WriterBeforeFieldContentEditEventArgs
{
	private XTextInputFieldElement z0eek;

	private string z0rek;

	private z0ZzZzdvj z0tek;

	private string z0yek;

	private string z0uek;

	private string z0iek;

	private string z0oek;

	private string z0pek;

	private string z0mek;

	private bool z0nek;

	private string z0bek;

	[DefaultValue(null)]
	public string OldText
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

	[DefaultValue(null)]
	public string SelectedIndexs
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

	[DefaultValue(null)]
	public string ElementID
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

	[DefaultValue(null)]
	public string NewValue
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

	[z0ZzZzuqh]
	[JsonIgnore]
	public z0ZzZzdbj WriterControl => Element.z0cu();

	[DefaultValue(null)]
	public string OldValue
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

	[DefaultValue(null)]
	public string EditorTypeName
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

	[z0ZzZzuqh]
	[JsonIgnore]
	public XTextInputFieldElement Element => z0eek;

	[DefaultValue(false)]
	public bool Cancel
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

	[z0ZzZzuqh]
	[JsonIgnore]
	public XTextDocument Document => Element.z0jr();

	[DefaultValue(null)]
	public string ElementName
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

	[DefaultValue(null)]
	public string NewText
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[z0ZzZzrqh("Item", typeof(ListItem))]
	[DefaultValue(null)]
	public z0ZzZzdvj SelectedItems
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

	public WriterBeforeFieldContentEditEventArgs()
	{
	}

	public WriterBeforeFieldContentEditEventArgs(XTextInputFieldElement field, string selectedIndexs, z0ZzZzdvj selectedItems, string editorTypeName)
	{
		if (field == null)
		{
			throw new ArgumentNullException("field");
		}
		z0eek = field;
		z0iek = selectedIndexs;
		z0bek = field.ID;
		z0tek = selectedItems;
		z0rek = editorTypeName;
		z0mek = field.Text;
		z0uek = field.InnerValue;
		z0yek = field.Name;
	}
}
