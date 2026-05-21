using System.Runtime.CompilerServices;

namespace System.Text;

internal static class UnicodeUtility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsBmpCodePoint(uint P_0)
	{
		return P_0 <= 65535;
	}
}
