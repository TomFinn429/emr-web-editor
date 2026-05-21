using System.Collections.Generic;

namespace System.IO.Compression;

internal struct Zip64ExtraField
{
	private ushort _size;

	private long? _uncompressedSize;

	private long? _compressedSize;

	private long? _localHeaderOffset;

	private int? _startDiskNumber;

	public ushort TotalSize => (ushort)(_size + 4);

	public long? UncompressedSize
	{
		get
		{
			return _uncompressedSize;
		}
		set
		{
			_uncompressedSize = uncompressedSize;
			UpdateSize();
		}
	}

	public long? CompressedSize
	{
		get
		{
			return _compressedSize;
		}
		set
		{
			_compressedSize = compressedSize;
			UpdateSize();
		}
	}

	public long? LocalHeaderOffset
	{
		get
		{
			return _localHeaderOffset;
		}
		set
		{
			_localHeaderOffset = localHeaderOffset;
			UpdateSize();
		}
	}

	public int? StartDiskNumber => _startDiskNumber;

	private void UpdateSize()
	{
		_size = 0;
		if (_uncompressedSize.HasValue)
		{
			_size += 8;
		}
		if (_compressedSize.HasValue)
		{
			_size += 8;
		}
		if (_localHeaderOffset.HasValue)
		{
			_size += 8;
		}
		if (_startDiskNumber.HasValue)
		{
			_size += 4;
		}
	}

	public static Zip64ExtraField GetJustZip64Block(Stream P_0, bool P_1, bool P_2, bool P_3, bool P_4)
	{
		using (BinaryReader binaryReader = new BinaryReader(P_0))
		{
			ZipGenericExtraField zipGenericExtraField;
			while (ZipGenericExtraField.TryReadBlock(binaryReader, P_0.Length, out zipGenericExtraField))
			{
				if (TryGetZip64BlockFromGenericExtraField(zipGenericExtraField, P_1, P_2, P_3, P_4, out var result))
				{
					return result;
				}
			}
		}
		return new Zip64ExtraField
		{
			_compressedSize = null,
			_uncompressedSize = null,
			_localHeaderOffset = null,
			_startDiskNumber = null
		};
	}

	private static bool TryGetZip64BlockFromGenericExtraField(ZipGenericExtraField P_0, bool P_1, bool P_2, bool P_3, bool P_4, out Zip64ExtraField P_5)
	{
		P_5 = default(Zip64ExtraField);
		P_5._compressedSize = null;
		P_5._uncompressedSize = null;
		P_5._localHeaderOffset = null;
		P_5._startDiskNumber = null;
		if (P_0.Tag != 1)
		{
			return false;
		}
		P_5._size = P_0.Size;
		using MemoryStream memoryStream = new MemoryStream(P_0.Data);
		using BinaryReader binaryReader = new BinaryReader(memoryStream);
		if (P_0.Size < 8)
		{
			return true;
		}
		bool flag = P_0.Size >= 28;
		if (P_1)
		{
			P_5._uncompressedSize = binaryReader.ReadInt64();
		}
		else if (flag)
		{
			binaryReader.ReadInt64();
		}
		if (memoryStream.Position > P_0.Size - 8)
		{
			return true;
		}
		if (P_2)
		{
			P_5._compressedSize = binaryReader.ReadInt64();
		}
		else if (flag)
		{
			binaryReader.ReadInt64();
		}
		if (memoryStream.Position > P_0.Size - 8)
		{
			return true;
		}
		if (P_3)
		{
			P_5._localHeaderOffset = binaryReader.ReadInt64();
		}
		else if (flag)
		{
			binaryReader.ReadInt64();
		}
		if (memoryStream.Position > P_0.Size - 4)
		{
			return true;
		}
		if (P_4)
		{
			P_5._startDiskNumber = binaryReader.ReadInt32();
		}
		else if (flag)
		{
			binaryReader.ReadInt32();
		}
		if (P_5._uncompressedSize < 0)
		{
			throw new InvalidDataException("FieldTooBigUncompressedSize");
		}
		if (P_5._compressedSize < 0)
		{
			throw new InvalidDataException("FieldTooBigCompressedSize");
		}
		if (P_5._localHeaderOffset < 0)
		{
			throw new InvalidDataException("FieldTooBigLocalHeaderOffset");
		}
		if (P_5._startDiskNumber < 0)
		{
			throw new InvalidDataException("FieldTooBigStartDiskNumber");
		}
		return true;
	}

	public static Zip64ExtraField GetAndRemoveZip64Block(List<ZipGenericExtraField> P_0, bool P_1, bool P_2, bool P_3, bool P_4)
	{
		Zip64ExtraField result = new Zip64ExtraField
		{
			_compressedSize = null,
			_uncompressedSize = null,
			_localHeaderOffset = null,
			_startDiskNumber = null
		};
		List<ZipGenericExtraField> list = new List<ZipGenericExtraField>();
		bool flag = false;
		foreach (ZipGenericExtraField item in P_0)
		{
			if (item.Tag == 1)
			{
				list.Add(item);
				if (!flag && TryGetZip64BlockFromGenericExtraField(item, P_1, P_2, P_3, P_4, out result))
				{
					flag = true;
				}
			}
		}
		foreach (ZipGenericExtraField item2 in list)
		{
			P_0.Remove(item2);
		}
		return result;
	}

	public static void RemoveZip64Blocks(List<ZipGenericExtraField> P_0)
	{
		List<ZipGenericExtraField> list = new List<ZipGenericExtraField>();
		foreach (ZipGenericExtraField item in P_0)
		{
			if (item.Tag == 1)
			{
				list.Add(item);
			}
		}
		foreach (ZipGenericExtraField item2 in list)
		{
			P_0.Remove(item2);
		}
	}

	public void WriteBlock(Stream P_0)
	{
		BinaryWriter binaryWriter = new BinaryWriter(P_0);
		binaryWriter.Write((ushort)1);
		binaryWriter.Write(_size);
		if (_uncompressedSize.HasValue)
		{
			binaryWriter.Write(_uncompressedSize.Value);
		}
		if (_compressedSize.HasValue)
		{
			binaryWriter.Write(_compressedSize.Value);
		}
		if (_localHeaderOffset.HasValue)
		{
			binaryWriter.Write(_localHeaderOffset.Value);
		}
		if (_startDiskNumber.HasValue)
		{
			binaryWriter.Write(_startDiskNumber.Value);
		}
	}
}
