using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization.Metadata;

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class JsonParameterInfoValues
{
	[CompilerGenerated]
	private readonly string _003CName_003Ek__BackingField;

	[CompilerGenerated]
	private readonly Type _003CParameterType_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CPosition_003Ek__BackingField;

	[CompilerGenerated]
	private readonly bool _003CHasDefaultValue_003Ek__BackingField;

	[CompilerGenerated]
	private readonly object _003CDefaultValue_003Ek__BackingField;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return _003CName_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			_003CName_003Ek__BackingField = text;
		}
	}

	public Type ParameterType
	{
		[CompilerGenerated]
		get
		{
			return _003CParameterType_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			_003CParameterType_003Ek__BackingField = type;
		}
	}

	public int Position
	{
		[CompilerGenerated]
		get
		{
			return _003CPosition_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			_003CPosition_003Ek__BackingField = num;
		}
	}

	public bool HasDefaultValue
	{
		[CompilerGenerated]
		get
		{
			return _003CHasDefaultValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			_003CHasDefaultValue_003Ek__BackingField = flag;
		}
	}

	public object? DefaultValue
	{
		[CompilerGenerated]
		get
		{
			return _003CDefaultValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		init
		{
			_003CDefaultValue_003Ek__BackingField = obj;
		}
	}
}
