using System.Runtime.CompilerServices;

namespace System.Text.Json;

public struct JsonReaderOptions
{
	private int _maxDepth;

	private JsonCommentHandling _commentHandling;

	[CompilerGenerated]
	private bool _003CAllowTrailingCommas_003Ek__BackingField;

	public JsonCommentHandling CommentHandling
	{
		readonly get
		{
			return _commentHandling;
		}
		set
		{
			if ((int)jsonCommentHandling > 2)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException_CommentEnumMustBeInRange("value");
			}
			_commentHandling = jsonCommentHandling;
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

	public bool AllowTrailingCommas
	{
		[CompilerGenerated]
		readonly get
		{
			return _003CAllowTrailingCommas_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CAllowTrailingCommas_003Ek__BackingField = flag;
		}
	}
}
