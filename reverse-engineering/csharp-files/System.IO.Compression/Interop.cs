using System.IO.Compression;
using System.Runtime.InteropServices;

internal static class Interop
{
	internal static class ZLib
	{
		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_DeflateInit2_", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_DeflateInit2_")]
		internal unsafe static extern ZLibNative.ErrorCode DeflateInit2_(ZLibNative.ZStream* P_0, ZLibNative.CompressionLevel P_1, ZLibNative.CompressionMethod P_2, int P_3, int P_4, ZLibNative.CompressionStrategy P_5);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_Deflate", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_Deflate")]
		internal unsafe static extern ZLibNative.ErrorCode Deflate(ZLibNative.ZStream* P_0, ZLibNative.FlushCode P_1);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_DeflateEnd", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_DeflateEnd")]
		internal unsafe static extern ZLibNative.ErrorCode DeflateEnd(ZLibNative.ZStream* P_0);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_InflateInit2_", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_InflateInit2_")]
		internal unsafe static extern ZLibNative.ErrorCode InflateInit2_(ZLibNative.ZStream* P_0, int P_1);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_Inflate", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_Inflate")]
		internal unsafe static extern ZLibNative.ErrorCode Inflate(ZLibNative.ZStream* P_0, ZLibNative.FlushCode P_1);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_InflateEnd", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_InflateEnd")]
		internal unsafe static extern ZLibNative.ErrorCode InflateEnd(ZLibNative.ZStream* P_0);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_Crc32", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_Crc32")]
		internal unsafe static extern uint crc32(uint P_0, byte* P_1, int P_2);
	}
}
