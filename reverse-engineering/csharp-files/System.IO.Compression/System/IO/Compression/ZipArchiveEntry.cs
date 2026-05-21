using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Compression;

public class ZipArchiveEntry
{
	private sealed class DirectToArchiveWriterStream : Stream
	{
		private long _position;

		private readonly CheckSumAndSizeWriteStream _crcSizeStream;

		private bool _everWritten;

		private bool _isDisposed;

		private readonly ZipArchiveEntry _entry;

		private bool _usedZip64inLH;

		private bool _canWrite;

		public override long Length
		{
			get
			{
				ThrowIfDisposed();
				throw new NotSupportedException("SeekingNotSupported");
			}
		}

		public override long Position
		{
			get
			{
				ThrowIfDisposed();
				return _position;
			}
			set
			{
				ThrowIfDisposed();
				throw new NotSupportedException("SeekingNotSupported");
			}
		}

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => _canWrite;

		public DirectToArchiveWriterStream(CheckSumAndSizeWriteStream P_0, ZipArchiveEntry P_1)
		{
			_position = 0L;
			_crcSizeStream = P_0;
			_everWritten = false;
			_isDisposed = false;
			_entry = P_1;
			_usedZip64inLH = false;
			_canWrite = true;
		}

		private void ThrowIfDisposed()
		{
			if (_isDisposed)
			{
				throw new ObjectDisposedException(GetType().ToString(), "HiddenStreamName");
			}
		}

		public override int Read(byte[] P_0, int P_1, int P_2)
		{
			ThrowIfDisposed();
			throw new NotSupportedException("ReadingNotSupported");
		}

		public override long Seek(long P_0, SeekOrigin P_1)
		{
			ThrowIfDisposed();
			throw new NotSupportedException("SeekingNotSupported");
		}

		public override void SetLength(long P_0)
		{
			ThrowIfDisposed();
			throw new NotSupportedException("SetLengthRequiresSeekingAndWriting");
		}

		public override void Write(byte[] P_0, int P_1, int P_2)
		{
			Stream.ValidateBufferArguments(P_0, P_1, P_2);
			ThrowIfDisposed();
			if (P_2 != 0)
			{
				if (!_everWritten)
				{
					_everWritten = true;
					_usedZip64inLH = _entry.WriteLocalFileHeader(false);
				}
				_crcSizeStream.Write(P_0, P_1, P_2);
				_position += P_2;
			}
		}

		public override void Write(ReadOnlySpan<byte> P_0)
		{
			ThrowIfDisposed();
			if (P_0.Length != 0)
			{
				if (!_everWritten)
				{
					_everWritten = true;
					_usedZip64inLH = _entry.WriteLocalFileHeader(false);
				}
				_crcSizeStream.Write(P_0);
				_position += P_0.Length;
			}
		}

		public override void WriteByte(byte P_0)
		{
			Write(new ReadOnlySpan<byte>(in P_0));
		}

		public override Task WriteAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
		{
			Stream.ValidateBufferArguments(P_0, P_1, P_2);
			return WriteAsync(new ReadOnlyMemory<byte>(P_0, P_1, P_2), P_3).AsTask();
		}

		public override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
		{
			ThrowIfDisposed();
			if (P_0.IsEmpty)
			{
				return default(ValueTask);
			}
			return Core(P_0, P_1);
			async ValueTask Core(ReadOnlyMemory<byte> readOnlyMemory, CancellationToken cancellationToken)
			{
				if (!_everWritten)
				{
					_everWritten = true;
					_usedZip64inLH = _entry.WriteLocalFileHeader(false);
				}
				await _crcSizeStream.WriteAsync(readOnlyMemory, cancellationToken).ConfigureAwait(false);
				_position += readOnlyMemory.Length;
			}
		}

		public override void Flush()
		{
			ThrowIfDisposed();
			_crcSizeStream.Flush();
		}

		public override Task FlushAsync(CancellationToken P_0)
		{
			ThrowIfDisposed();
			return _crcSizeStream.FlushAsync(P_0);
		}

		protected override void Dispose(bool P_0)
		{
			if (P_0 && !_isDisposed)
			{
				_crcSizeStream.Dispose();
				if (!_everWritten)
				{
					_entry.WriteLocalFileHeader(true);
				}
				else if (_entry._archive.ArchiveStream.CanSeek)
				{
					_entry.WriteCrcAndSizesInLocalHeader(_usedZip64inLH);
				}
				else
				{
					_entry.WriteDataDescriptor();
				}
				_canWrite = false;
				_isDisposed = true;
			}
			base.Dispose(P_0);
		}
	}

	[Flags]
	internal enum BitFlagValues : ushort
	{
		IsEncrypted = 1,
		DataDescriptor = 8,
		UnicodeFileNameAndComment = 0x800
	}

	internal enum CompressionMethodValues : ushort
	{
		Stored = 0,
		Deflate = 8,
		Deflate64 = 9,
		BZip2 = 12,
		LZMA = 14
	}

	private ZipArchive _archive;

	private readonly bool _originallyInArchive;

	private readonly int _diskNumberStart;

	private readonly ZipVersionMadeByPlatform _versionMadeByPlatform;

	private ZipVersionNeededValues _versionMadeBySpecification;

	internal ZipVersionNeededValues _versionToExtract;

	private BitFlagValues _generalPurposeBitFlag;

	private bool _isEncrypted;

	private CompressionMethodValues _storedCompressionMethod;

	private DateTimeOffset _lastModified;

	private long _compressedSize;

	private long _uncompressedSize;

	private long _offsetOfLocalHeader;

	private long? _storedOffsetOfCompressedData;

	private uint _crc32;

	private byte[][] _compressedBytes;

	private MemoryStream _storedUncompressedData;

	private bool _currentlyOpenForWrite;

	private bool _everOpenedForWrite;

	private Stream _outstandingWriteStream;

	private uint _externalFileAttr;

	private string _storedEntryName;

	private byte[] _storedEntryNameBytes;

	private List<ZipGenericExtraField> _cdUnknownExtraFields;

	private List<ZipGenericExtraField> _lhUnknownExtraFields;

	private byte[] _fileComment;

	private readonly CompressionLevel? _compressionLevel;

	private static readonly bool s_allowLargeZipArchiveEntriesInUpdateMode = 4 > 4;

	public string FullName
	{
		get
		{
			return _storedEntryName;
		}
		[MemberNotNull("_storedEntryNameBytes")]
		[MemberNotNull("_storedEntryName")]
		private set
		{
			ArgumentNullException.ThrowIfNull(text, "FullName");
			_storedEntryNameBytes = ZipHelper.GetEncodedTruncatedBytesFromString(text, _archive.EntryNameAndCommentEncoding, 0, out var flag);
			_storedEntryName = text;
			if (flag)
			{
				_generalPurposeBitFlag |= BitFlagValues.UnicodeFileNameAndComment;
			}
			else
			{
				_generalPurposeBitFlag &= ~BitFlagValues.UnicodeFileNameAndComment;
			}
			DetectEntryNameVersion();
		}
	}

	public long Length
	{
		get
		{
			if (_everOpenedForWrite)
			{
				throw new InvalidOperationException("LengthAfterWrite");
			}
			return _uncompressedSize;
		}
	}

	public string Name => ParseFileName(FullName, _versionMadeByPlatform);

	internal bool EverOpenedForWrite => _everOpenedForWrite;

	private long OffsetOfCompressedData
	{
		get
		{
			if (!_storedOffsetOfCompressedData.HasValue)
			{
				_archive.ArchiveStream.Seek(_offsetOfLocalHeader, SeekOrigin.Begin);
				if (!ZipLocalFileHeader.TrySkipBlock(_archive.ArchiveReader))
				{
					throw new InvalidDataException("LocalFileHeaderCorrupt");
				}
				_storedOffsetOfCompressedData = _archive.ArchiveStream.Position;
			}
			return _storedOffsetOfCompressedData.Value;
		}
	}

	private MemoryStream UncompressedData
	{
		get
		{
			if (_storedUncompressedData == null)
			{
				_storedUncompressedData = new MemoryStream((int)_uncompressedSize);
				if (_originallyInArchive)
				{
					using Stream stream = OpenInReadMode(false);
					try
					{
						stream.CopyTo(_storedUncompressedData);
					}
					catch (InvalidDataException)
					{
						_storedUncompressedData.Dispose();
						_storedUncompressedData = null;
						_currentlyOpenForWrite = false;
						_everOpenedForWrite = false;
						throw;
					}
				}
				if (CompressionMethod != CompressionMethodValues.Stored)
				{
					CompressionMethod = CompressionMethodValues.Deflate;
				}
			}
			return _storedUncompressedData;
		}
	}

	private CompressionMethodValues CompressionMethod
	{
		get
		{
			return _storedCompressionMethod;
		}
		set
		{
			switch (compressionMethodValues)
			{
			case CompressionMethodValues.Deflate:
				VersionToExtractAtLeast(ZipVersionNeededValues.ExplicitDirectory);
				break;
			case CompressionMethodValues.Deflate64:
				VersionToExtractAtLeast(ZipVersionNeededValues.Deflate64);
				break;
			}
			_storedCompressionMethod = compressionMethodValues;
		}
	}

	internal ZipArchiveEntry(ZipArchive P_0, ZipCentralDirectoryFileHeader P_1)
	{
		_archive = P_0;
		_originallyInArchive = true;
		_diskNumberStart = P_1.DiskNumberStart;
		_versionMadeByPlatform = (ZipVersionMadeByPlatform)P_1.VersionMadeByCompatibility;
		_versionMadeBySpecification = (ZipVersionNeededValues)P_1.VersionMadeBySpecification;
		_versionToExtract = (ZipVersionNeededValues)P_1.VersionNeededToExtract;
		_generalPurposeBitFlag = (BitFlagValues)P_1.GeneralPurposeBitFlag;
		_isEncrypted = (_generalPurposeBitFlag & BitFlagValues.IsEncrypted) != 0;
		CompressionMethod = (CompressionMethodValues)P_1.CompressionMethod;
		_lastModified = new DateTimeOffset(ZipHelper.DosTimeToDateTime(P_1.LastModified));
		_compressedSize = P_1.CompressedSize;
		_uncompressedSize = P_1.UncompressedSize;
		_externalFileAttr = P_1.ExternalFileAttributes;
		_offsetOfLocalHeader = P_1.RelativeOffsetOfLocalHeader;
		_storedOffsetOfCompressedData = null;
		_crc32 = P_1.Crc32;
		_compressedBytes = null;
		_storedUncompressedData = null;
		_currentlyOpenForWrite = false;
		_everOpenedForWrite = false;
		_outstandingWriteStream = null;
		_storedEntryNameBytes = P_1.Filename;
		_storedEntryName = (_archive.EntryNameAndCommentEncoding ?? Encoding.UTF8).GetString(_storedEntryNameBytes);
		DetectEntryNameVersion();
		_lhUnknownExtraFields = null;
		_cdUnknownExtraFields = P_1.ExtraFields;
		_fileComment = P_1.FileComment;
		_compressionLevel = null;
	}

	internal ZipArchiveEntry(ZipArchive P_0, string P_1, CompressionLevel P_2)
		: this(P_0, P_1)
	{
		_compressionLevel = P_2;
		if (_compressionLevel == CompressionLevel.NoCompression)
		{
			CompressionMethod = CompressionMethodValues.Stored;
		}
	}

	internal ZipArchiveEntry(ZipArchive P_0, string P_1)
	{
		_archive = P_0;
		_originallyInArchive = false;
		_diskNumberStart = 0;
		_versionMadeByPlatform = ZipVersionMadeByPlatform.Unix;
		_versionMadeBySpecification = ZipVersionNeededValues.Default;
		_versionToExtract = ZipVersionNeededValues.Default;
		_generalPurposeBitFlag = (BitFlagValues)0;
		CompressionMethod = CompressionMethodValues.Deflate;
		_lastModified = DateTimeOffset.Now;
		_compressedSize = 0L;
		_uncompressedSize = 0L;
		_externalFileAttr = (uint)(((P_1.EndsWith(Path.DirectorySeparatorChar) || P_1.EndsWith(Path.AltDirectorySeparatorChar)) ? 493 : 420) << 16);
		_offsetOfLocalHeader = 0L;
		_storedOffsetOfCompressedData = null;
		_crc32 = 0u;
		_compressedBytes = null;
		_storedUncompressedData = null;
		_currentlyOpenForWrite = false;
		_everOpenedForWrite = false;
		_outstandingWriteStream = null;
		FullName = P_1;
		_cdUnknownExtraFields = null;
		_lhUnknownExtraFields = null;
		_fileComment = Array.Empty<byte>();
		_compressionLevel = null;
		if (_storedEntryNameBytes.Length > 65535)
		{
			throw new ArgumentException("EntryNamesTooLong");
		}
		if (_archive.Mode == ZipArchiveMode.Create)
		{
			_archive.AcquireArchiveStream(this);
		}
	}

	public void Delete()
	{
		if (_archive != null)
		{
			if (_currentlyOpenForWrite)
			{
				throw new IOException("DeleteOpenEntry");
			}
			if (_archive.Mode != ZipArchiveMode.Update)
			{
				throw new NotSupportedException("DeleteOnlyInUpdate");
			}
			_archive.ThrowIfDisposed();
			_archive.RemoveEntry(this);
			_archive = null;
			UnloadStreams();
		}
	}

	public Stream Open()
	{
		ThrowIfInvalidArchive();
		return _archive.Mode switch
		{
			ZipArchiveMode.Read => OpenInReadMode(true), 
			ZipArchiveMode.Create => OpenInWriteMode(), 
			_ => OpenInUpdateMode(), 
		};
	}

	public override string ToString()
	{
		return FullName;
	}

	internal void WriteAndFinishLocalEntry()
	{
		CloseStreams();
		WriteLocalFileHeaderAndDataIfNeeded();
		UnloadStreams();
	}

	internal void WriteCentralDirectoryFileHeader()
	{
		BinaryWriter binaryWriter = new BinaryWriter(_archive.ArchiveStream);
		Zip64ExtraField zip64ExtraField = default(Zip64ExtraField);
		bool flag = false;
		uint num;
		uint num2;
		if (SizesTooLarge())
		{
			flag = true;
			num = 4294967295u;
			num2 = 4294967295u;
			zip64ExtraField.CompressedSize = _compressedSize;
			zip64ExtraField.UncompressedSize = _uncompressedSize;
		}
		else
		{
			num = (uint)_compressedSize;
			num2 = (uint)_uncompressedSize;
		}
		uint num3;
		if (_offsetOfLocalHeader > 4294967295u)
		{
			flag = true;
			num3 = 4294967295u;
			zip64ExtraField.LocalHeaderOffset = _offsetOfLocalHeader;
		}
		else
		{
			num3 = (uint)_offsetOfLocalHeader;
		}
		if (flag)
		{
			VersionToExtractAtLeast(ZipVersionNeededValues.Zip64);
		}
		int num4 = (flag ? zip64ExtraField.TotalSize : 0) + ((_cdUnknownExtraFields != null) ? ZipGenericExtraField.TotalSize(_cdUnknownExtraFields) : 0);
		ushort num5;
		if (num4 > 65535)
		{
			num5 = (ushort)(flag ? zip64ExtraField.TotalSize : 0);
			_cdUnknownExtraFields = null;
		}
		else
		{
			num5 = (ushort)num4;
		}
		binaryWriter.Write(33639248u);
		binaryWriter.Write((byte)_versionMadeBySpecification);
		binaryWriter.Write((byte)3);
		binaryWriter.Write((ushort)_versionToExtract);
		binaryWriter.Write((ushort)_generalPurposeBitFlag);
		binaryWriter.Write((ushort)CompressionMethod);
		binaryWriter.Write(ZipHelper.DateTimeToDosTime(_lastModified.DateTime));
		binaryWriter.Write(_crc32);
		binaryWriter.Write(num);
		binaryWriter.Write(num2);
		binaryWriter.Write((ushort)_storedEntryNameBytes.Length);
		binaryWriter.Write(num5);
		binaryWriter.Write((ushort)_fileComment.Length);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write(_externalFileAttr);
		binaryWriter.Write(num3);
		binaryWriter.Write(_storedEntryNameBytes);
		if (flag)
		{
			zip64ExtraField.WriteBlock(_archive.ArchiveStream);
		}
		if (_cdUnknownExtraFields != null)
		{
			ZipGenericExtraField.WriteAllBlocks(_cdUnknownExtraFields, _archive.ArchiveStream);
		}
		if (_fileComment.Length != 0)
		{
			binaryWriter.Write(_fileComment);
		}
	}

	internal bool LoadLocalHeaderExtraFieldAndCompressedBytesIfNeeded()
	{
		if (_originallyInArchive)
		{
			_archive.ArchiveStream.Seek(_offsetOfLocalHeader, SeekOrigin.Begin);
			_lhUnknownExtraFields = ZipLocalFileHeader.GetExtraFields(_archive.ArchiveReader);
		}
		if (!_everOpenedForWrite && _originallyInArchive)
		{
			int num = 2147483591;
			_compressedBytes = new byte[_compressedSize / num + 1][];
			for (int i = 0; i < _compressedBytes.Length - 1; i++)
			{
				_compressedBytes[i] = new byte[num];
			}
			_compressedBytes[_compressedBytes.Length - 1] = new byte[_compressedSize % num];
			_archive.ArchiveStream.Seek(OffsetOfCompressedData, SeekOrigin.Begin);
			for (int j = 0; j < _compressedBytes.Length - 1; j++)
			{
				ZipHelper.ReadBytes(_archive.ArchiveStream, _compressedBytes[j], num);
			}
			ZipHelper.ReadBytes(_archive.ArchiveStream, _compressedBytes[_compressedBytes.Length - 1], (int)(_compressedSize % num));
		}
		return true;
	}

	internal void ThrowIfNotOpenable(bool P_0, bool P_1)
	{
		if (!IsOpenable(P_0, P_1, out var text))
		{
			throw new InvalidDataException(text);
		}
	}

	private void DetectEntryNameVersion()
	{
		if (ParseFileName(_storedEntryName, _versionMadeByPlatform) == "")
		{
			VersionToExtractAtLeast(ZipVersionNeededValues.ExplicitDirectory);
		}
	}

	private CheckSumAndSizeWriteStream GetDataCompressor(Stream P_0, bool P_1, EventHandler P_2)
	{
		bool flag = true;
		Stream stream;
		switch (CompressionMethod)
		{
		case CompressionMethodValues.Stored:
			stream = P_0;
			flag = false;
			break;
		default:
			stream = new DeflateStream(P_0, _compressionLevel.GetValueOrDefault(), P_1);
			break;
		}
		bool flag2 = P_1 && !flag;
		return new CheckSumAndSizeWriteStream(stream, P_0, flag2, this, P_2, delegate(long num, long uncompressedSize, uint crc, Stream stream2, ZipArchiveEntry zipArchiveEntry, EventHandler eventHandler)
		{
			zipArchiveEntry._crc32 = crc;
			zipArchiveEntry._uncompressedSize = uncompressedSize;
			zipArchiveEntry._compressedSize = stream2.Position - num;
			eventHandler?.Invoke(zipArchiveEntry, EventArgs.Empty);
		});
	}

	private Stream GetDataDecompressor(Stream P_0)
	{
		return CompressionMethod switch
		{
			CompressionMethodValues.Deflate => new DeflateStream(P_0, CompressionMode.Decompress, _uncompressedSize), 
			CompressionMethodValues.Deflate64 => new DeflateManagedStream(P_0, CompressionMethodValues.Deflate64, _uncompressedSize), 
			_ => P_0, 
		};
	}

	private Stream OpenInReadMode(bool P_0)
	{
		if (P_0)
		{
			ThrowIfNotOpenable(true, false);
		}
		Stream stream = new SubReadStream(_archive.ArchiveStream, OffsetOfCompressedData, _compressedSize);
		return GetDataDecompressor(stream);
	}

	private Stream OpenInWriteMode()
	{
		if (_everOpenedForWrite)
		{
			throw new IOException("CreateModeWriteOnceAndOneEntryAtATime");
		}
		_everOpenedForWrite = true;
		CheckSumAndSizeWriteStream dataCompressor = GetDataCompressor(_archive.ArchiveStream, true, delegate(object P_0, EventArgs P_1)
		{
			ZipArchiveEntry zipArchiveEntry = (ZipArchiveEntry)P_0;
			zipArchiveEntry._archive.ReleaseArchiveStream(zipArchiveEntry);
			zipArchiveEntry._outstandingWriteStream = null;
		});
		_outstandingWriteStream = new DirectToArchiveWriterStream(dataCompressor, this);
		return new WrappedStream(_outstandingWriteStream, true);
	}

	private Stream OpenInUpdateMode()
	{
		if (_currentlyOpenForWrite)
		{
			throw new IOException("UpdateModeOneStream");
		}
		ThrowIfNotOpenable(true, true);
		_everOpenedForWrite = true;
		_currentlyOpenForWrite = true;
		UncompressedData.Seek(0L, SeekOrigin.Begin);
		return new WrappedStream(UncompressedData, this, delegate(ZipArchiveEntry P_0)
		{
			P_0._currentlyOpenForWrite = false;
		});
	}

	private bool IsOpenable(bool P_0, bool P_1, out string P_2)
	{
		P_2 = null;
		if (_originallyInArchive)
		{
			if (P_0 && CompressionMethod != CompressionMethodValues.Stored && CompressionMethod != CompressionMethodValues.Deflate && CompressionMethod != CompressionMethodValues.Deflate64)
			{
				CompressionMethodValues compressionMethod = CompressionMethod;
				if (compressionMethod == CompressionMethodValues.BZip2 || compressionMethod == CompressionMethodValues.LZMA)
				{
					P_2 = System.SR.Format("UnsupportedCompressionMethod", CompressionMethod.ToString());
				}
				else
				{
					P_2 = "UnsupportedCompression";
				}
				return false;
			}
			if (_diskNumberStart != _archive.NumberOfThisDisk)
			{
				P_2 = "SplitSpanned";
				return false;
			}
			if (_offsetOfLocalHeader > _archive.ArchiveStream.Length)
			{
				P_2 = "LocalFileHeaderCorrupt";
				return false;
			}
			_archive.ArchiveStream.Seek(_offsetOfLocalHeader, SeekOrigin.Begin);
			if (!ZipLocalFileHeader.TrySkipBlock(_archive.ArchiveReader))
			{
				P_2 = "LocalFileHeaderCorrupt";
				return false;
			}
			if (OffsetOfCompressedData + _compressedSize > _archive.ArchiveStream.Length)
			{
				P_2 = "LocalFileHeaderCorrupt";
				return false;
			}
			if (P_1 && _compressedSize > 2147483647 && !s_allowLargeZipArchiveEntriesInUpdateMode)
			{
				P_2 = "EntryTooLarge";
				return false;
			}
		}
		return true;
	}

	private bool SizesTooLarge()
	{
		if (_compressedSize <= 4294967295u)
		{
			return _uncompressedSize > 4294967295u;
		}
		return true;
	}

	private bool WriteLocalFileHeader(bool P_0)
	{
		BinaryWriter binaryWriter = new BinaryWriter(_archive.ArchiveStream);
		Zip64ExtraField zip64ExtraField = default(Zip64ExtraField);
		bool flag = false;
		uint num;
		uint num2;
		if (P_0)
		{
			CompressionMethod = CompressionMethodValues.Stored;
			num = 0u;
			num2 = 0u;
		}
		else if (_archive.Mode == ZipArchiveMode.Create && !_archive.ArchiveStream.CanSeek)
		{
			_generalPurposeBitFlag |= BitFlagValues.DataDescriptor;
			flag = false;
			num = 0u;
			num2 = 0u;
		}
		else
		{
			_generalPurposeBitFlag &= ~BitFlagValues.DataDescriptor;
			if (SizesTooLarge())
			{
				flag = true;
				num = 4294967295u;
				num2 = 4294967295u;
				zip64ExtraField.CompressedSize = _compressedSize;
				zip64ExtraField.UncompressedSize = _uncompressedSize;
				VersionToExtractAtLeast(ZipVersionNeededValues.Zip64);
			}
			else
			{
				flag = false;
				num = (uint)_compressedSize;
				num2 = (uint)_uncompressedSize;
			}
		}
		_offsetOfLocalHeader = binaryWriter.BaseStream.Position;
		int num3 = (flag ? zip64ExtraField.TotalSize : 0) + ((_lhUnknownExtraFields != null) ? ZipGenericExtraField.TotalSize(_lhUnknownExtraFields) : 0);
		ushort num4;
		if (num3 > 65535)
		{
			num4 = (ushort)(flag ? zip64ExtraField.TotalSize : 0);
			_lhUnknownExtraFields = null;
		}
		else
		{
			num4 = (ushort)num3;
		}
		binaryWriter.Write(67324752u);
		binaryWriter.Write((ushort)_versionToExtract);
		binaryWriter.Write((ushort)_generalPurposeBitFlag);
		binaryWriter.Write((ushort)CompressionMethod);
		binaryWriter.Write(ZipHelper.DateTimeToDosTime(_lastModified.DateTime));
		binaryWriter.Write(_crc32);
		binaryWriter.Write(num);
		binaryWriter.Write(num2);
		binaryWriter.Write((ushort)_storedEntryNameBytes.Length);
		binaryWriter.Write(num4);
		binaryWriter.Write(_storedEntryNameBytes);
		if (flag)
		{
			zip64ExtraField.WriteBlock(_archive.ArchiveStream);
		}
		if (_lhUnknownExtraFields != null)
		{
			ZipGenericExtraField.WriteAllBlocks(_lhUnknownExtraFields, _archive.ArchiveStream);
		}
		return flag;
	}

	private void WriteLocalFileHeaderAndDataIfNeeded()
	{
		if (_storedUncompressedData != null || _compressedBytes != null)
		{
			if (_storedUncompressedData != null)
			{
				_uncompressedSize = _storedUncompressedData.Length;
				using Stream stream = new DirectToArchiveWriterStream(GetDataCompressor(_archive.ArchiveStream, true, null), this);
				_storedUncompressedData.Seek(0L, SeekOrigin.Begin);
				_storedUncompressedData.CopyTo(stream);
				_storedUncompressedData.Dispose();
				_storedUncompressedData = null;
				return;
			}
			if (_uncompressedSize == 0L)
			{
				_compressedSize = 0L;
			}
			WriteLocalFileHeader(_uncompressedSize == 0);
			if (_uncompressedSize != 0L)
			{
				byte[][] compressedBytes = _compressedBytes;
				foreach (byte[] array in compressedBytes)
				{
					_archive.ArchiveStream.Write(array, 0, array.Length);
				}
			}
		}
		else if (_archive.Mode == ZipArchiveMode.Update || !_everOpenedForWrite)
		{
			_everOpenedForWrite = true;
			WriteLocalFileHeader(true);
		}
	}

	private void WriteCrcAndSizesInLocalHeader(bool P_0)
	{
		long position = _archive.ArchiveStream.Position;
		BinaryWriter binaryWriter = new BinaryWriter(_archive.ArchiveStream);
		bool flag = SizesTooLarge();
		bool flag2 = flag && !P_0;
		uint num = (uint)(flag ? 4294967295u : _compressedSize);
		uint num2 = (uint)(flag ? 4294967295u : _uncompressedSize);
		if (flag2)
		{
			VersionToExtractAtLeast(ZipVersionNeededValues.Zip64);
			_generalPurposeBitFlag |= BitFlagValues.DataDescriptor;
			_archive.ArchiveStream.Seek(_offsetOfLocalHeader + 4, SeekOrigin.Begin);
			binaryWriter.Write((ushort)_versionToExtract);
			binaryWriter.Write((ushort)_generalPurposeBitFlag);
		}
		_archive.ArchiveStream.Seek(_offsetOfLocalHeader + 14, SeekOrigin.Begin);
		if (!flag2)
		{
			binaryWriter.Write(_crc32);
			binaryWriter.Write(num);
			binaryWriter.Write(num2);
		}
		else
		{
			binaryWriter.Write(0u);
			binaryWriter.Write(0u);
			binaryWriter.Write(0u);
		}
		if (P_0)
		{
			_archive.ArchiveStream.Seek(_offsetOfLocalHeader + 30 + _storedEntryNameBytes.Length + 4, SeekOrigin.Begin);
			binaryWriter.Write(_uncompressedSize);
			binaryWriter.Write(_compressedSize);
		}
		_archive.ArchiveStream.Seek(position, SeekOrigin.Begin);
		if (flag2)
		{
			binaryWriter.Write(_crc32);
			binaryWriter.Write(_compressedSize);
			binaryWriter.Write(_uncompressedSize);
		}
	}

	private void WriteDataDescriptor()
	{
		BinaryWriter binaryWriter = new BinaryWriter(_archive.ArchiveStream);
		binaryWriter.Write(134695760u);
		binaryWriter.Write(_crc32);
		if (SizesTooLarge())
		{
			binaryWriter.Write(_compressedSize);
			binaryWriter.Write(_uncompressedSize);
		}
		else
		{
			binaryWriter.Write((uint)_compressedSize);
			binaryWriter.Write((uint)_uncompressedSize);
		}
	}

	private void UnloadStreams()
	{
		_storedUncompressedData?.Dispose();
		_compressedBytes = null;
		_outstandingWriteStream = null;
	}

	private void CloseStreams()
	{
		_outstandingWriteStream?.Dispose();
	}

	private void VersionToExtractAtLeast(ZipVersionNeededValues P_0)
	{
		if ((int)_versionToExtract < (int)P_0)
		{
			_versionToExtract = P_0;
		}
		if ((int)_versionMadeBySpecification < (int)P_0)
		{
			_versionMadeBySpecification = P_0;
		}
	}

	private void ThrowIfInvalidArchive()
	{
		if (_archive == null)
		{
			throw new InvalidOperationException("DeletedEntry");
		}
		_archive.ThrowIfDisposed();
	}

	private static string GetFileName_Windows(string P_0)
	{
		int num = P_0.AsSpan().LastIndexOfAny('\\', '/', ':');
		if (num < 0)
		{
			return P_0;
		}
		return P_0.Substring(num + 1);
	}

	private static string GetFileName_Unix(string P_0)
	{
		int num = P_0.LastIndexOf('/');
		if (num < 0)
		{
			return P_0;
		}
		return P_0.Substring(num + 1);
	}

	internal static string ParseFileName(string P_0, ZipVersionMadeByPlatform P_1)
	{
		if (P_1 != ZipVersionMadeByPlatform.Windows)
		{
			return GetFileName_Unix(P_0);
		}
		return GetFileName_Windows(P_0);
	}
}
