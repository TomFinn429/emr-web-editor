using System.Runtime.InteropServices;

namespace System.IO.Compression;

internal static class Crc32Helper
{
	public unsafe static uint UpdateCrc32(uint P_0, byte[] P_1, int P_2, int P_3)
	{
		fixed (byte* ptr = &P_1[P_2])
		{
			return global::Interop.ZLib.crc32(P_0, ptr, P_3);
		}
	}

	public unsafe static uint UpdateCrc32(uint P_0, ReadOnlySpan<byte> P_1)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference(P_1))
		{
			return global::Interop.ZLib.crc32(P_0, reference, P_1.Length);
		}
	}
}
