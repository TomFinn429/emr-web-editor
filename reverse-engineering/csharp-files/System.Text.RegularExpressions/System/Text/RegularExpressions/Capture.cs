using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions;

public class Capture
{
	[CompilerGenerated]
	private int _003CIndex_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CLength_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CText_003Ek__BackingField;

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return _003CIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		private protected set
		{
			_003CIndex_003Ek__BackingField = num;
		}
	}

	public int Length
	{
		[CompilerGenerated]
		get
		{
			return _003CLength_003Ek__BackingField;
		}
		[CompilerGenerated]
		private protected set
		{
			_003CLength_003Ek__BackingField = num;
		}
	}

	internal string? Text
	{
		[CompilerGenerated]
		get
		{
			return _003CText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CText_003Ek__BackingField = text;
		}
	}

	public string Value
	{
		get
		{
			string text = Text;
			if (text == null)
			{
				return string.Empty;
			}
			return text.Substring(Index, Length);
		}
	}

	internal Capture(string P_0, int P_1, int P_2)
	{
		Text = P_0;
		Index = P_1;
		Length = P_2;
	}

	public override string ToString()
	{
		return Value;
	}
}
