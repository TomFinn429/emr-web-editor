using System.Collections.Generic;

namespace System.IO.Compression;

internal struct ZipGenericExtraField
{
	private ushort _tag;

	private ushort _size;

	private byte[] _data;

	public ushort Tag => _tag;

	public ushort Size => _size;

	public byte[] Data => _data;

	public void WriteBlock(Stream P_0)
	{
		BinaryWriter binaryWriter = new BinaryWriter(P_0);
		binaryWriter.Write(Tag);
		binaryWriter.Write(Size);
		binaryWriter.Write(Data);
	}

	public static bool TryReadBlock(BinaryReader P_0, long P_1, out ZipGenericExtraField P_2)
	{
		P_2 = default(ZipGenericExtraField);
		if (P_1 - P_0.BaseStream.Position < 4)
		{
			return false;
		}
		P_2._tag = P_0.ReadUInt16();
		P_2._size = P_0.ReadUInt16();
		if (P_1 - P_0.BaseStream.Position < P_2._size)
		{
			return false;
		}
		P_2._data = P_0.ReadBytes(P_2._size);
		return true;
	}

	public static List<ZipGenericExtraField> ParseExtraField(Stream P_0)
	{
		List<ZipGenericExtraField> list = new List<ZipGenericExtraField>();
		using BinaryReader binaryReader = new BinaryReader(P_0);
		ZipGenericExtraField zipGenericExtraField;
		while (TryReadBlock(binaryReader, P_0.Length, out zipGenericExtraField))
		{
			list.Add(zipGenericExtraField);
		}
		return list;
	}

	public static int TotalSize(List<ZipGenericExtraField> P_0)
	{
		int num = 0;
		foreach (ZipGenericExtraField item in P_0)
		{
			num += item.Size + 4;
		}
		return num;
	}

	public static void WriteAllBlocks(List<ZipGenericExtraField> P_0, Stream P_1)
	{
		foreach (ZipGenericExtraField item in P_0)
		{
			item.WriteBlock(P_1);
		}
	}
}
