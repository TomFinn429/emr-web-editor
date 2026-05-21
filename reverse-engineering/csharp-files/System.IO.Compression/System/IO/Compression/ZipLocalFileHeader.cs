using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System.IO.Compression;

[StructLayout((LayoutKind)0, Size = 1)]
internal readonly struct ZipLocalFileHeader
{
	public static List<ZipGenericExtraField> GetExtraFields(BinaryReader P_0)
	{
		P_0.BaseStream.Seek(26L, SeekOrigin.Current);
		ushort num = P_0.ReadUInt16();
		ushort num2 = P_0.ReadUInt16();
		P_0.BaseStream.Seek(num, SeekOrigin.Current);
		List<ZipGenericExtraField> list;
		using (Stream stream = new SubReadStream(P_0.BaseStream, P_0.BaseStream.Position, num2))
		{
			list = ZipGenericExtraField.ParseExtraField(stream);
		}
		Zip64ExtraField.RemoveZip64Blocks(list);
		return list;
	}

	public static bool TrySkipBlock(BinaryReader P_0)
	{
		if (P_0.ReadUInt32() != 67324752)
		{
			return false;
		}
		if (P_0.BaseStream.Length < P_0.BaseStream.Position + 22)
		{
			return false;
		}
		P_0.BaseStream.Seek(22L, SeekOrigin.Current);
		ushort num = P_0.ReadUInt16();
		ushort num2 = P_0.ReadUInt16();
		if (P_0.BaseStream.Length < P_0.BaseStream.Position + num + num2)
		{
			return false;
		}
		P_0.BaseStream.Seek(num + num2, SeekOrigin.Current);
		return true;
	}
}
