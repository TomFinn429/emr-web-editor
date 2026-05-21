using System.Runtime.CompilerServices;

namespace System.Text.Encodings.Web;

internal struct AsciiByteMap
{
	private unsafe fixed byte Buffer[128];

	internal unsafe void InsertAsciiChar(char P_0, byte P_1)
	{
		if (P_0 < '\u0080')
		{
			Buffer[(uint)P_0] = P_1;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe readonly bool TryLookup(Rune P_0, out byte P_1)
	{
		if (P_0.IsAscii)
		{
			byte b = Buffer[(uint)P_0.Value];
			if (b != 0)
			{
				P_1 = b;
				return true;
			}
		}
		P_1 = 0;
		return false;
	}
}
