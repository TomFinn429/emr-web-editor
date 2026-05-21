using System.Text.Json.Serialization;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzskh
{
	private bool z0eek = true;

	private XTextDocument z0rek;

	private z0ZzZzjeh z0tek;

	private ContentEffects z0yek;

	private XTextElementList z0uek = new XTextElementList();

	private z0ZzZzakh z0iek;

	private bool z0oek;

	private z0ZzZzdbj z0pek;

	private bool z0mek;

	private z0ZzZzlfh z0nek;

	public bool LogUndo
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

	public ContentEffects ContentEffect
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

	public bool SimpleElementProperties
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

	[JsonIgnore]
	public z0ZzZzjeh ParentWindow
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

	public bool UpdateExpressionResult
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

	[JsonIgnore]
	public z0ZzZzlfh Host
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

	[JsonIgnore]
	public XTextElement Element
	{
		get
		{
			if (z0uek != null && z0uek.Count > 0)
			{
				return z0uek[0];
			}
			return null;
		}
		set
		{
			z0uek = new XTextElementList();
			if (value != null)
			{
				z0uek.Add(value);
			}
		}
	}

	[JsonIgnore]
	public XTextElementList Elements
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

	public z0ZzZzakh Method
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

	[JsonIgnore]
	public XTextDocument Document
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
	public z0ZzZzdbj WriterControl
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

	public void SetContentEffect(ContentEffects efc)
	{
		if (efc > z0yek)
		{
			z0yek = efc;
		}
	}
}
