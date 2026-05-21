using System.Runtime.CompilerServices;

namespace System.Text.Unicode;

public sealed class UnicodeRange
{
	[CompilerGenerated]
	private int _003CFirstCodePoint_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CLength_003Ek__BackingField;

	public int FirstCodePoint
	{
		[CompilerGenerated]
		get
		{
			return _003CFirstCodePoint_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CFirstCodePoint_003Ek__BackingField = num;
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
		private set
		{
			_003CLength_003Ek__BackingField = num;
		}
	}

	public UnicodeRange(int P_0, int P_1)
	{
		if (P_0 < 0 || P_0 > 65535)
		{
			throw new ArgumentOutOfRangeException("firstCodePoint");
		}
		if (P_1 < 0 || (long)P_0 + (long)P_1 > 65536)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		FirstCodePoint = P_0;
		Length = P_1;
	}

	public static UnicodeRange Create(char P_0, char P_1)
	{
		if (P_1 < P_0)
		{
			throw new ArgumentOutOfRangeException("lastCharacter");
		}
		return new UnicodeRange(P_0, 1 + (P_1 - P_0));
	}
}
