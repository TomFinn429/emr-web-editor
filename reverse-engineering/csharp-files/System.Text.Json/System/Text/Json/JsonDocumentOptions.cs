using System.Runtime.CompilerServices;

namespace System.Text.Json;

public struct JsonDocumentOptions
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
			if ((int)jsonCommentHandling > 1)
			{
				throw new ArgumentOutOfRangeException("value", "JsonDocumentDoesNotSupportComments");
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

	internal JsonReaderOptions GetReaderOptions()
	{
		return new JsonReaderOptions
		{
			AllowTrailingCommas = AllowTrailingCommas,
			CommentHandling = CommentHandling,
			MaxDepth = MaxDepth
		};
	}
}
