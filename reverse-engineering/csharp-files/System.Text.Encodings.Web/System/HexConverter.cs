using System.Runtime.CompilerServices;

namespace System;

internal static class HexConverter
{
	public enum Casing : uint
	{
		Upper = 0u,
		Lower = 8224u
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ToBytesBuffer(byte P_0, Span<byte> P_1, int P_2 = 0, Casing P_3 = Casing.Upper)
	{
		uint num = (uint)(((P_0 & 0xF0) << 4) + (P_0 & 0xF) - 35209);
		uint num2 = ((((0 - num) & 0x7070) >> 4) + num + 47545) | (uint)P_3;
		P_1[P_2 + 1] = (byte)num2;
		P_1[P_2] = (byte)(num2 >> 8);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ToCharsBuffer(byte P_0, Span<char> P_1, int P_2 = 0, Casing P_3 = Casing.Upper)
	{
		uint num = (uint)(((P_0 & 0xF0) << 4) + (P_0 & 0xF) - 35209);
		uint num2 = ((((0 - num) & 0x7070) >> 4) + num + 47545) | (uint)P_3;
		P_1[P_2 + 1] = (char)(num2 & 0xFF);
		P_1[P_2] = (char)(num2 >> 8);
	}
}
