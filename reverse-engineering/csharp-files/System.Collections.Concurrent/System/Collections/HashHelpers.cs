using System.Runtime.CompilerServices;

namespace System.Collections;

internal static class HashHelpers
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint FastMod(uint P_0, uint P_1, ulong P_2)
	{
		return (uint)(((P_2 * P_0 >> 32) + 1) * P_1 >> 32);
	}
}
