using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace System.IO.Compression;

public class ZipArchive : IDisposable
{
	private readonly Stream _archiveStream;

	private ZipArchiveEntry _archiveStreamOwner;

	private BinaryReader _archiveReader;

	private ZipArchiveMode _mode;

	private List<ZipArchiveEntry> _entries;

	private ReadOnlyCollection<ZipArchiveEntry> _entriesCollection;

	private Dictionary<string, ZipArchiveEntry> _entriesDictionary;

	private bool _readEntries;

	private bool _leaveOpen;

	private long _centralDirectoryStart;

	private bool _isDisposed;

	private uint _numberOfThisDisk;

	private long _expectedNumberOfEntries;

	private Stream _backingStream;

	private byte[] _archiveComment;

	private Encoding _entryNameAndCommentEncoding;

	public ReadOnlyCollection<ZipArchiveEntry> Entries
	{
		get
		{
			if (_mode == ZipArchiveMode.Create)
			{
				throw new NotSupportedException("EntriesInCreateMode");
			}
			ThrowIfDisposed();
			EnsureCentralDirectoryRead();
			return _entriesCollection;
		}
	}

	public ZipArchiveMode Mode => _mode;

	internal BinaryReader? ArchiveReader => _archiveReader;

	internal Stream ArchiveStream => _archiveStream;

	internal uint NumberOfThisDisk => _numberOfThisDisk;

	internal Encoding? EntryNameAndCommentEncoding
	{
		get
		{
			return _entryNameAndCommentEncoding;
		}
		private set
		{
			if (encoding != null && (encoding.Equals(Encoding.BigEndianUnicode) || encoding.Equals(Encoding.Unicode)))
			{
				throw new ArgumentException("EntryNameAndCommentEncodingNotSupported", "EntryNameAndCommentEncoding");
			}
			_entryNameAndCommentEncoding = encoding;
		}
	}

	public ZipArchive(Stream P_0)
		: this(P_0, ZipArchiveMode.Read, false, null)
	{
	}

	public ZipArchive(Stream P_0, ZipArchiveMode P_1)
		: this(P_0, P_1, false, null)
	{
	}

	public ZipArchive(Stream P_0, ZipArchiveMode P_1, bool P_2, Encoding? P_3)
	{
		ArgumentNullException.ThrowIfNull(P_0, "stream");
		EntryNameAndCommentEncoding = P_3;
		Stream stream = null;
		try
		{
			_backingStream = null;
			switch (P_1)
			{
			case ZipArchiveMode.Create:
				if (!P_0.CanWrite)
				{
					throw new ArgumentException("CreateModeCapabilities");
				}
				break;
			case ZipArchiveMode.Read:
				if (!P_0.CanRead)
				{
					throw new ArgumentException("ReadModeCapabilities");
				}
				if (!P_0.CanSeek)
				{
					_backingStream = P_0;
					stream = (P_0 = new MemoryStream());
					_backingStream.CopyTo(P_0);
					P_0.Seek(0L, SeekOrigin.Begin);
				}
				break;
			case ZipArchiveMode.Update:
				if (!P_0.CanRead || !P_0.CanWrite || !P_0.CanSeek)
				{
					throw new ArgumentException("UpdateModeCapabilities");
				}
				break;
			default:
				throw new ArgumentOutOfRangeException("mode");
			}
			_mode = P_1;
			if (P_1 == ZipArchiveMode.Create && !P_0.CanSeek)
			{
				_archiveStream = new PositionPreservingWriteOnlyStreamWrapper(P_0);
			}
			else
			{
				_archiveStream = P_0;
			}
			_archiveStreamOwner = null;
			if (P_1 == ZipArchiveMode.Create)
			{
				_archiveReader = null;
			}
			else
			{
				_archiveReader = new BinaryReader(_archiveStream);
			}
			_entries = new List<ZipArchiveEntry>();
			_entriesCollection = new ReadOnlyCollection<ZipArchiveEntry>(_entries);
			_entriesDictionary = new Dictionary<string, ZipArchiveEntry>();
			_readEntries = false;
			_leaveOpen = P_2;
			_centralDirectoryStart = 0L;
			_isDisposed = false;
			_numberOfThisDisk = 0u;
			_archiveComment = Array.Empty<byte>();
			switch (P_1)
			{
			case ZipArchiveMode.Create:
				_readEntries = true;
				return;
			case ZipArchiveMode.Read:
				ReadEndOfCentralDirectory();
				return;
			}
			if (_archiveStream.Length == 0L)
			{
				_readEntries = true;
				return;
			}
			ReadEndOfCentralDirectory();
			EnsureCentralDirectoryRead();
			foreach (ZipArchiveEntry entry in _entries)
			{
				entry.ThrowIfNotOpenable(false, true);
			}
		}
		catch
		{
			stream?.Dispose();
			throw;
		}
	}

	public ZipArchiveEntry CreateEntry(string P_0)
	{
		return DoCreateEntry(P_0, null);
	}

	protected virtual void Dispose(bool P_0)
	{
		if (!P_0 || _isDisposed)
		{
			return;
		}
		try
		{
			ZipArchiveMode mode = _mode;
			if (mode != ZipArchiveMode.Read)
			{
				_ = mode - 1;
				_ = 1;
				WriteFile();
			}
		}
		finally
		{
			CloseStreams();
			_isDisposed = true;
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	private ZipArchiveEntry DoCreateEntry(string P_0, CompressionLevel? P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "entryName");
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentException("CannotBeEmpty", "entryName");
		}
		if (_mode == ZipArchiveMode.Read)
		{
			throw new NotSupportedException("CreateInReadMode");
		}
		ThrowIfDisposed();
		ZipArchiveEntry zipArchiveEntry = (P_1.HasValue ? new ZipArchiveEntry(this, P_0, P_1.Value) : new ZipArchiveEntry(this, P_0));
		AddEntry(zipArchiveEntry);
		return zipArchiveEntry;
	}

	internal void AcquireArchiveStream(ZipArchiveEntry P_0)
	{
		if (_archiveStreamOwner != null)
		{
			if (_archiveStreamOwner.EverOpenedForWrite)
			{
				throw new IOException("CreateModeCreateEntryWhileOpen");
			}
			_archiveStreamOwner.WriteAndFinishLocalEntry();
		}
		_archiveStreamOwner = P_0;
	}

	private void AddEntry(ZipArchiveEntry P_0)
	{
		_entries.Add(P_0);
		_entriesDictionary.TryAdd(P_0.FullName, P_0);
	}

	internal void ReleaseArchiveStream(ZipArchiveEntry P_0)
	{
		_archiveStreamOwner = null;
	}

	internal void RemoveEntry(ZipArchiveEntry P_0)
	{
		_entries.Remove(P_0);
		_entriesDictionary.Remove(P_0.FullName);
	}

	internal void ThrowIfDisposed()
	{
		ObjectDisposedException.ThrowIf(_isDisposed, this);
	}

	private void CloseStreams()
	{
		if (!_leaveOpen)
		{
			_archiveStream.Dispose();
			_backingStream?.Dispose();
			_archiveReader?.Dispose();
		}
		else if (_backingStream != null)
		{
			_archiveStream.Dispose();
		}
	}

	private void EnsureCentralDirectoryRead()
	{
		if (!_readEntries)
		{
			ReadCentralDirectory();
			_readEntries = true;
		}
	}

	private void ReadCentralDirectory()
	{
		try
		{
			_archiveStream.Seek(_centralDirectoryStart, SeekOrigin.Begin);
			long num = 0L;
			bool flag = Mode == ZipArchiveMode.Update;
			ZipCentralDirectoryFileHeader zipCentralDirectoryFileHeader;
			while (ZipCentralDirectoryFileHeader.TryReadBlock(_archiveReader, flag, out zipCentralDirectoryFileHeader))
			{
				AddEntry(new ZipArchiveEntry(this, zipCentralDirectoryFileHeader));
				num++;
			}
			if (num != _expectedNumberOfEntries)
			{
				throw new InvalidDataException("NumEntriesWrong");
			}
		}
		catch (EndOfStreamException ex)
		{
			throw new InvalidDataException(System.SR.Format("CentralDirectoryInvalid", ex));
		}
	}

	private void ReadEndOfCentralDirectory()
	{
		try
		{
			_archiveStream.Seek(-18L, SeekOrigin.End);
			if (!ZipHelper.SeekBackwardsToSignature(_archiveStream, 101010256u, 65539))
			{
				throw new InvalidDataException("EOCDNotFound");
			}
			long position = _archiveStream.Position;
			ZipEndOfCentralDirectoryBlock zipEndOfCentralDirectoryBlock;
			bool flag = ZipEndOfCentralDirectoryBlock.TryReadBlock(_archiveReader, out zipEndOfCentralDirectoryBlock);
			if (zipEndOfCentralDirectoryBlock.NumberOfThisDisk != zipEndOfCentralDirectoryBlock.NumberOfTheDiskWithTheStartOfTheCentralDirectory)
			{
				throw new InvalidDataException("SplitSpanned");
			}
			_numberOfThisDisk = zipEndOfCentralDirectoryBlock.NumberOfThisDisk;
			_centralDirectoryStart = zipEndOfCentralDirectoryBlock.OffsetOfStartOfCentralDirectoryWithRespectToTheStartingDiskNumber;
			if (zipEndOfCentralDirectoryBlock.NumberOfEntriesInTheCentralDirectory != zipEndOfCentralDirectoryBlock.NumberOfEntriesInTheCentralDirectoryOnThisDisk)
			{
				throw new InvalidDataException("SplitSpanned");
			}
			_expectedNumberOfEntries = zipEndOfCentralDirectoryBlock.NumberOfEntriesInTheCentralDirectory;
			_archiveComment = zipEndOfCentralDirectoryBlock.ArchiveComment;
			TryReadZip64EndOfCentralDirectory(zipEndOfCentralDirectoryBlock, position);
			if (_centralDirectoryStart > _archiveStream.Length)
			{
				throw new InvalidDataException("FieldTooBigOffsetToCD");
			}
		}
		catch (EndOfStreamException ex)
		{
			throw new InvalidDataException("CDCorrupt", ex);
		}
		catch (IOException ex2)
		{
			throw new InvalidDataException("CDCorrupt", ex2);
		}
	}

	private void TryReadZip64EndOfCentralDirectory(ZipEndOfCentralDirectoryBlock P_0, long P_1)
	{
		if (P_0.NumberOfThisDisk != 65535 && P_0.OffsetOfStartOfCentralDirectoryWithRespectToTheStartingDiskNumber != 4294967295u && P_0.NumberOfEntriesInTheCentralDirectory != 65535)
		{
			return;
		}
		_archiveStream.Seek(P_1 - 16, SeekOrigin.Begin);
		if (ZipHelper.SeekBackwardsToSignature(_archiveStream, 117853008u, 4))
		{
			Zip64EndOfCentralDirectoryLocator zip64EndOfCentralDirectoryLocator;
			bool flag = Zip64EndOfCentralDirectoryLocator.TryReadBlock(_archiveReader, out zip64EndOfCentralDirectoryLocator);
			if (zip64EndOfCentralDirectoryLocator.OffsetOfZip64EOCD > 9223372036854775807L)
			{
				throw new InvalidDataException("FieldTooBigOffsetToZip64EOCD");
			}
			long offsetOfZip64EOCD = (long)zip64EndOfCentralDirectoryLocator.OffsetOfZip64EOCD;
			_archiveStream.Seek(offsetOfZip64EOCD, SeekOrigin.Begin);
			if (!Zip64EndOfCentralDirectoryRecord.TryReadBlock(_archiveReader, out var zip64EndOfCentralDirectoryRecord))
			{
				throw new InvalidDataException("Zip64EOCDNotWhereExpected");
			}
			_numberOfThisDisk = zip64EndOfCentralDirectoryRecord.NumberOfThisDisk;
			if (zip64EndOfCentralDirectoryRecord.NumberOfEntriesTotal > 9223372036854775807L)
			{
				throw new InvalidDataException("FieldTooBigNumEntries");
			}
			if (zip64EndOfCentralDirectoryRecord.OffsetOfCentralDirectory > 9223372036854775807L)
			{
				throw new InvalidDataException("FieldTooBigOffsetToCD");
			}
			if (zip64EndOfCentralDirectoryRecord.NumberOfEntriesTotal != zip64EndOfCentralDirectoryRecord.NumberOfEntriesOnThisDisk)
			{
				throw new InvalidDataException("SplitSpanned");
			}
			_expectedNumberOfEntries = (long)zip64EndOfCentralDirectoryRecord.NumberOfEntriesTotal;
			_centralDirectoryStart = (long)zip64EndOfCentralDirectoryRecord.OffsetOfCentralDirectory;
		}
	}

	private void WriteFile()
	{
		if (_mode == ZipArchiveMode.Update)
		{
			List<ZipArchiveEntry> list = new List<ZipArchiveEntry>();
			foreach (ZipArchiveEntry entry in _entries)
			{
				if (!entry.LoadLocalHeaderExtraFieldAndCompressedBytesIfNeeded())
				{
					list.Add(entry);
				}
			}
			foreach (ZipArchiveEntry item in list)
			{
				item.Delete();
			}
			_archiveStream.Seek(0L, SeekOrigin.Begin);
			_archiveStream.SetLength(0L);
		}
		foreach (ZipArchiveEntry entry2 in _entries)
		{
			entry2.WriteAndFinishLocalEntry();
		}
		long position = _archiveStream.Position;
		foreach (ZipArchiveEntry entry3 in _entries)
		{
			entry3.WriteCentralDirectoryFileHeader();
		}
		long num = _archiveStream.Position - position;
		WriteArchiveEpilogue(position, num);
	}

	private void WriteArchiveEpilogue(long P_0, long P_1)
	{
		if (P_0 >= 4294967295u || P_1 >= 4294967295u || _entries.Count >= 65535)
		{
			long position = _archiveStream.Position;
			Zip64EndOfCentralDirectoryRecord.WriteBlock(_archiveStream, _entries.Count, P_0, P_1);
			Zip64EndOfCentralDirectoryLocator.WriteBlock(_archiveStream, position);
		}
		ZipEndOfCentralDirectoryBlock.WriteBlock(_archiveStream, _entries.Count, P_0, P_1, _archiveComment);
	}
}
