using System.Text.Json.Serialization;

namespace DCSoft.Writer;

public class FilterValueEventArgs
{
	private bool z0eek;

	private object z0rek_jiejie20260327142557;

	private string z0tek;

	private InputValueType z0yek = InputValueType.Dom;

	private InputValueSource z0uek;

	public bool Cancel
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

	public InputValueSource Source
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

	public string SourceName
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
	public object Value
	{
		get
		{
			return z0rek_jiejie20260327142557;
		}
		set
		{
			z0rek_jiejie20260327142557 = value;
		}
	}

	public InputValueType Type
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

	public FilterValueEventArgs(InputValueSource source, InputValueType type, object Value)
	{
		z0uek = source;
		z0yek = type;
		z0rek_jiejie20260327142557 = Value;
	}
}
