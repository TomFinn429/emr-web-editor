namespace System.IO.Compression;

internal struct Zip64EndOfCentralDirectoryLocator
{
	public uint NumberOfDiskWithZip64EOCD;

	public ulong OffsetOfZip64EOCD;

	public uint TotalNumberOfDisks;

	public static bool TryReadBlock(BinaryReader P_0, out Zip64EndOfCentralDirectoryLocator P_1)
	{
		P_1 = default(Zip64EndOfCentralDirectoryLocator);
		if (P_0.ReadUInt32() != 117853008)
		{
			return false;
		}
		P_1.NumberOfDiskWithZip64EOCD = P_0.ReadUInt32();
		P_1.OffsetOfZip64EOCD = P_0.ReadUInt64();
		P_1.TotalNumberOfDisks = P_0.ReadUInt32();
		return true;
	}

	public static void WriteBlock(Stream P_0, long P_1)
	{
		BinaryWriter binaryWriter = new BinaryWriter(P_0);
		binaryWriter.Write(117853008u);
		binaryWriter.Write(0u);
		binaryWriter.Write(P_1);
		binaryWriter.Write(1u);
	}
}
