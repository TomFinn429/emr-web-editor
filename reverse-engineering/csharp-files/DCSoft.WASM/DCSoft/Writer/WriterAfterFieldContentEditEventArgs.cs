using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer;

public class WriterAfterFieldContentEditEventArgs
{
	private string z0eek;

	private z0ZzZzdvj z0rek;

	private string z0tek;

	private string z0yek;

	private string z0uek;

	private string z0iek;

	private string z0oek;

	private string z0pek;

	private XTextInputFieldElement z0mek;

	private string z0nek;

	[JsonIgnore]
	[z0ZzZzuqh]
	public z0ZzZzdbj WriterControl => Element.z0cu();

	[DefaultValue(null)]
	public string NewValue
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

	[z0ZzZzuqh]
	[JsonIgnore]
	public XTextDocument Document => Element.z0jr();

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
	public string OldValue
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

	[DefaultValue(null)]
	[z0ZzZzrqh("Item", typeof(ListItem))]
	public z0ZzZzdvj SelectedItems
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

	[DefaultValue(null)]
	public string EditorTypeName
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

	[z0ZzZzuqh]
	[JsonIgnore]
	public XTextInputFieldElement Element => z0mek;

	[DefaultValue(null)]
	public string NewText
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
	public string ElementID
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

	[DefaultValue(null)]
	public string OldText
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

	[DefaultValue(null)]
	public string ElementName
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

	public WriterAfterFieldContentEditEventArgs(XTextInputFieldElement field, string selectedIndexs, z0ZzZzdvj selectedItems, string editorTypeName, string oldText, string oldValue)
	{
		if (field == null)
		{
			throw new ArgumentNullException("field");
		}
		z0mek = field;
		z0iek = selectedIndexs;
		z0eek = field.ID;
		z0rek = selectedItems;
		z0uek = editorTypeName;
		z0tek = oldText;
		z0nek = oldValue;
		z0yek = field.Text;
		z0oek = field.InnerValue;
		z0pek = field.Name;
	}
}
