namespace System.IO.Compression;

internal struct Zip64EndOfCentralDirectoryRecord
{
	public ulong SizeOfThisRecord;

	public ushort VersionMadeBy;

	public ushort VersionNeededToExtract;

	public uint NumberOfThisDisk;

	public uint NumberOfDiskWithStartOfCD;

	public ulong NumberOfEntriesOnThisDisk;

	public ulong NumberOfEntriesTotal;

	public ulong SizeOfCentralDirectory;

	public ulong OffsetOfCentralDirectory;

	public static bool TryReadBlock(BinaryReader P_0, out Zip64EndOfCentralDirectoryRecord P_1)
	{
		P_1 = default(Zip64EndOfCentralDirectoryRecord);
		if (P_0.ReadUInt32() != 101075792)
		{
			return false;
		}
		P_1.SizeOfThisRecord = P_0.ReadUInt64();
		P_1.VersionMadeBy = P_0.ReadUInt16();
		P_1.VersionNeededToExtract = P_0.ReadUInt16();
		P_1.NumberOfThisDisk = P_0.ReadUInt32();
		P_1.NumberOfDiskWithStartOfCD = P_0.ReadUInt32();
		P_1.NumberOfEntriesOnThisDisk = P_0.ReadUInt64();
		P_1.NumberOfEntriesTotal = P_0.ReadUInt64();
		P_1.SizeOfCentralDirectory = P_0.ReadUInt64();
		P_1.OffsetOfCentralDirectory = P_0.ReadUInt64();
		return true;
	}

	public static void WriteBlock(Stream P_0, long P_1, long P_2, long P_3)
	{
		BinaryWriter binaryWriter = new BinaryWriter(P_0);
		binaryWriter.Write(101075792u);
		binaryWriter.Write(44uL);
		binaryWriter.Write((ushort)45);
		binaryWriter.Write((ushort)45);
		binaryWriter.Write(0u);
		binaryWriter.Write(0u);
		binaryWriter.Write(P_1);
		binaryWriter.Write(P_1);
		binaryWriter.Write(P_3);
		binaryWriter.Write(P_2);
	}
}
