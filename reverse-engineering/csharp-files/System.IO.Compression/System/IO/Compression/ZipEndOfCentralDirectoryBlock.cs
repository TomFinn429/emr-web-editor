namespace System.IO.Compression;

internal struct ZipEndOfCentralDirectoryBlock
{
	public uint Signature;

	public ushort NumberOfThisDisk;

	public ushort NumberOfTheDiskWithTheStartOfTheCentralDirectory;

	public ushort NumberOfEntriesInTheCentralDirectoryOnThisDisk;

	public ushort NumberOfEntriesInTheCentralDirectory;

	public uint SizeOfCentralDirectory;

	public uint OffsetOfStartOfCentralDirectoryWithRespectToTheStartingDiskNumber;

	public byte[] ArchiveComment;

	public static void WriteBlock(Stream P_0, long P_1, long P_2, long P_3, byte[] P_4)
	{
		BinaryWriter binaryWriter = new BinaryWriter(P_0);
		ushort num = (ushort)((P_1 > 65535) ? 65535 : ((ushort)P_1));
		uint num2 = (uint)((P_2 > 4294967295u) ? 4294967295u : P_2);
		uint num3 = (uint)((P_3 > 4294967295u) ? 4294967295u : P_3);
		binaryWriter.Write(101010256u);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(num);
		binaryWriter.Write(num);
		binaryWriter.Write(num3);
		binaryWriter.Write(num2);
		binaryWriter.Write((ushort)P_4.Length);
		if (P_4.Length != 0)
		{
			binaryWriter.Write(P_4);
		}
	}

	public static bool TryReadBlock(BinaryReader P_0, out ZipEndOfCentralDirectoryBlock P_1)
	{
		P_1 = default(ZipEndOfCentralDirectoryBlock);
		if (P_0.ReadUInt32() != 101010256)
		{
			return false;
		}
		P_1.Signature = 101010256u;
		P_1.NumberOfThisDisk = P_0.ReadUInt16();
		P_1.NumberOfTheDiskWithTheStartOfTheCentralDirectory = P_0.ReadUInt16();
		P_1.NumberOfEntriesInTheCentralDirectoryOnThisDisk = P_0.ReadUInt16();
		P_1.NumberOfEntriesInTheCentralDirectory = P_0.ReadUInt16();
		P_1.SizeOfCentralDirectory = P_0.ReadUInt32();
		P_1.OffsetOfStartOfCentralDirectoryWithRespectToTheStartingDiskNumber = P_0.ReadUInt32();
		ushort num = P_0.ReadUInt16();
		P_1.ArchiveComment = P_0.ReadBytes(num);
		return true;
	}
}
