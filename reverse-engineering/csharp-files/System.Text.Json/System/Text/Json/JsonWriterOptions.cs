using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;

namespace System.Text.Json;

public struct JsonWriterOptions
{
	private int _maxDepth;

	private int _optionsMask;

	[CompilerGenerated]
	private JavaScriptEncoder _003CEncoder_003Ek__BackingField;

	public JavaScriptEncoder? Encoder
	{
		[CompilerGenerated]
		readonly get
		{
			return _003CEncoder_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CEncoder_003Ek__BackingField = javaScriptEncoder;
		}
	}

	public bool Indented
	{
		get
		{
			return (_optionsMask & 1) != 0;
		}
		set
		{
			if (flag)
			{
				_optionsMask |= 1;
			}
			else
			{
				_optionsMask &= -2;
			}
		}
	}

	public int MaxDepth
	{
		readonly get
		{
			return _maxDepth;
		}
		set
		{
			if (num < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException_MaxDepthMustBePositive("value");
			}
			_maxDepth = num;
		}
	}

	public bool SkipValidation
	{
		get
		{
			return (_optionsMask & 2) != 0;
		}
		set
		{
			if (flag)
			{
				_optionsMask |= 2;
			}
			else
			{
				_optionsMask &= -3;
			}
		}
	}

	internal bool IndentedOrNotSkipValidation => _optionsMask != 2;
}
