using System.Collections.Generic;

namespace System.IO.Compression;

internal struct ZipCentralDirectoryFileHeader
{
	public byte VersionMadeByCompatibility;

	public byte VersionMadeBySpecification;

	public ushort VersionNeededToExtract;

	public ushort GeneralPurposeBitFlag;

	public ushort CompressionMethod;

	public uint LastModified;

	public uint Crc32;

	public long CompressedSize;

	public long UncompressedSize;

	public ushort FilenameLength;

	public ushort ExtraFieldLength;

	public ushort FileCommentLength;

	public int DiskNumberStart;

	public ushort InternalFileAttributes;

	public uint ExternalFileAttributes;

	public long RelativeOffsetOfLocalHeader;

	public byte[] Filename;

	public byte[] FileComment;

	public List<ZipGenericExtraField> ExtraFields;

	public static bool TryReadBlock(BinaryReader P_0, bool P_1, out ZipCentralDirectoryFileHeader P_2)
	{
		P_2 = default(ZipCentralDirectoryFileHeader);
		if (P_0.ReadUInt32() != 33639248)
		{
			return false;
		}
		P_2.VersionMadeBySpecification = P_0.ReadByte();
		P_2.VersionMadeByCompatibility = P_0.ReadByte();
		P_2.VersionNeededToExtract = P_0.ReadUInt16();
		P_2.GeneralPurposeBitFlag = P_0.ReadUInt16();
		P_2.CompressionMethod = P_0.ReadUInt16();
		P_2.LastModified = P_0.ReadUInt32();
		P_2.Crc32 = P_0.ReadUInt32();
		uint num = P_0.ReadUInt32();
		uint num2 = P_0.ReadUInt32();
		P_2.FilenameLength = P_0.ReadUInt16();
		P_2.ExtraFieldLength = P_0.ReadUInt16();
		P_2.FileCommentLength = P_0.ReadUInt16();
		ushort num3 = P_0.ReadUInt16();
		P_2.InternalFileAttributes = P_0.ReadUInt16();
		P_2.ExternalFileAttributes = P_0.ReadUInt32();
		uint num4 = P_0.ReadUInt32();
		P_2.Filename = P_0.ReadBytes(P_2.FilenameLength);
		bool flag = num2 == 4294967295u;
		bool flag2 = num == 4294967295u;
		bool flag3 = num4 == 4294967295u;
		bool flag4 = num3 == 65535;
		long num5 = P_0.BaseStream.Position + P_2.ExtraFieldLength;
		Zip64ExtraField zip64ExtraField;
		using (Stream stream = new SubReadStream(P_0.BaseStream, P_0.BaseStream.Position, P_2.ExtraFieldLength))
		{
			if (P_1)
			{
				P_2.ExtraFields = ZipGenericExtraField.ParseExtraField(stream);
				zip64ExtraField = Zip64ExtraField.GetAndRemoveZip64Block(P_2.ExtraFields, flag, flag2, flag3, flag4);
			}
			else
			{
				P_2.ExtraFields = null;
				zip64ExtraField = Zip64ExtraField.GetJustZip64Block(stream, flag, flag2, flag3, flag4);
			}
		}
		P_0.BaseStream.AdvanceToPosition(num5);
		P_2.FileComment = P_0.ReadBytes(P_2.FileCommentLength);
		P_2.UncompressedSize = ((!zip64ExtraField.UncompressedSize.HasValue) ? num2 : zip64ExtraField.UncompressedSize.Value);
		P_2.CompressedSize = ((!zip64ExtraField.CompressedSize.HasValue) ? num : zip64ExtraField.CompressedSize.Value);
		P_2.RelativeOffsetOfLocalHeader = ((!zip64ExtraField.LocalHeaderOffset.HasValue) ? num4 : zip64ExtraField.LocalHeaderOffset.Value);
		P_2.DiskNumberStart = ((!zip64ExtraField.StartDiskNumber.HasValue) ? num3 : zip64ExtraField.StartDiskNumber.Value);
		return true;
	}
}
