using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Text.Encodings.Web;

internal static class SpanUtility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsValidIndex<T>(ReadOnlySpan<T> P_0, int P_1)
	{
		if ((uint)P_1 >= (uint)P_0.Length)
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsValidIndex<T>(Span<T> P_0, int P_1)
	{
		if ((uint)P_1 >= (uint)P_0.Length)
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteUInt64LittleEndian(Span<byte> P_0, int P_1, ulong P_2)
	{
		if (AreValidIndexAndLength(P_0.Length, P_1, 8))
		{
			if (!BitConverter.IsLittleEndian)
			{
			}
			Unsafe.WriteUnaligned(ref Unsafe.Add(ref MemoryMarshal.GetReference(P_0), (nint)(uint)P_1), P_2);
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool AreValidIndexAndLength(int P_0, int P_1, int P_2)
	{
		_ = 4;
		if ((uint)P_1 > (uint)P_0)
		{
			return false;
		}
		if ((uint)P_2 > (uint)(P_0 - P_1))
		{
			return false;
		}
		return true;
	}
}
