using System.ComponentModel;
using zzz;

namespace DCSoft.Writer.Dom;

public class DataSourceBindingDescription
{
	private string z0eek;

	private string z0rek;

	private bool z0tek;

	private bool z0yek;

	private XTextElement z0uek;

	private string z0iek;

	private string z0oek;

	[DefaultValue(false)]
	public bool Readonly
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
	[z0ZzZzuqh]
	public XTextElement Element
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
	public string ElementID
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

	[DefaultValue(false)]
	public bool AutoUpdate
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
	public string FormatString
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
	public string DataSource
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

	[DefaultValue(null)]
	public string BindingPath
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
}
