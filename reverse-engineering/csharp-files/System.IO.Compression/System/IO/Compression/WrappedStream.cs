using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Compression;

internal sealed class WrappedStream : Stream
{
	private readonly Stream _baseStream;

	private readonly bool _closeBaseStream;

	private readonly Action<ZipArchiveEntry> _onClosed;

	private readonly ZipArchiveEntry _zipArchiveEntry;

	private bool _isDisposed;

	public override long Length
	{
		get
		{
			ThrowIfDisposed();
			return _baseStream.Length;
		}
	}

	public override long Position
	{
		get
		{
			ThrowIfDisposed();
			return _baseStream.Position;
		}
		set
		{
			ThrowIfDisposed();
			ThrowIfCantSeek();
			_baseStream.Position = position;
		}
	}

	public override bool CanRead
	{
		get
		{
			if (!_isDisposed)
			{
				return _baseStream.CanRead;
			}
			return false;
		}
	}

	public override bool CanSeek
	{
		get
		{
			if (!_isDisposed)
			{
				return _baseStream.CanSeek;
			}
			return false;
		}
	}

	public override bool CanWrite
	{
		get
		{
			if (!_isDisposed)
			{
				return _baseStream.CanWrite;
			}
			return false;
		}
	}

	internal WrappedStream(Stream P_0, bool P_1)
		: this(P_0, P_1, null, null)
	{
	}

	private WrappedStream(Stream P_0, bool P_1, ZipArchiveEntry P_2, Action<ZipArchiveEntry> P_3)
	{
		_baseStream = P_0;
		_closeBaseStream = P_1;
		_onClosed = P_3;
		_zipArchiveEntry = P_2;
		_isDisposed = false;
	}

	internal WrappedStream(Stream P_0, ZipArchiveEntry P_1, Action<ZipArchiveEntry> P_2)
		: this(P_0, false, P_1, P_2)
	{
	}

	private void ThrowIfDisposed()
	{
		if (_isDisposed)
		{
			throw new ObjectDisposedException(GetType().ToString(), "HiddenStreamName");
		}
	}

	private void ThrowIfCantRead()
	{
		if (!CanRead)
		{
			throw new NotSupportedException("ReadingNotSupported");
		}
	}

	private void ThrowIfCantWrite()
	{
		if (!CanWrite)
		{
			throw new NotSupportedException("WritingNotSupported");
		}
	}

	private void ThrowIfCantSeek()
	{
		if (!CanSeek)
		{
			throw new NotSupportedException("SeekingNotSupported");
		}
	}

	public override int Read(byte[] P_0, int P_1, int P_2)
	{
		ThrowIfDisposed();
		ThrowIfCantRead();
		return _baseStream.Read(P_0, P_1, P_2);
	}

	public override int Read(Span<byte> P_0)
	{
		ThrowIfDisposed();
		ThrowIfCantRead();
		return _baseStream.Read(P_0);
	}

	public override int ReadByte()
	{
		ThrowIfDisposed();
		ThrowIfCantRead();
		return _baseStream.ReadByte();
	}

	public override Task<int> ReadAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		ThrowIfDisposed();
		ThrowIfCantRead();
		return _baseStream.ReadAsync(P_0, P_1, P_2, P_3);
	}

	public override ValueTask<int> ReadAsync(Memory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
	{
		ThrowIfDisposed();
		ThrowIfCantRead();
		return _baseStream.ReadAsync(P_0, P_1);
	}

	public override long Seek(long P_0, SeekOrigin P_1)
	{
		ThrowIfDisposed();
		ThrowIfCantSeek();
		return _baseStream.Seek(P_0, P_1);
	}

	public override void SetLength(long P_0)
	{
		ThrowIfDisposed();
		ThrowIfCantSeek();
		ThrowIfCantWrite();
		_baseStream.SetLength(P_0);
	}

	public override void Write(byte[] P_0, int P_1, int P_2)
	{
		ThrowIfDisposed();
		ThrowIfCantWrite();
		_baseStream.Write(P_0, P_1, P_2);
	}

	public override void Write(ReadOnlySpan<byte> P_0)
	{
		ThrowIfDisposed();
		ThrowIfCantWrite();
		_baseStream.Write(P_0);
	}

	public override void WriteByte(byte P_0)
	{
		ThrowIfDisposed();
		ThrowIfCantWrite();
		_baseStream.WriteByte(P_0);
	}

	public override Task WriteAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		ThrowIfDisposed();
		ThrowIfCantWrite();
		return _baseStream.WriteAsync(P_0, P_1, P_2, P_3);
	}

	public override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
	{
		ThrowIfDisposed();
		ThrowIfCantWrite();
		return _baseStream.WriteAsync(P_0, P_1);
	}

	public override void Flush()
	{
		ThrowIfDisposed();
		ThrowIfCantWrite();
		_baseStream.Flush();
	}

	public override Task FlushAsync(CancellationToken P_0)
	{
		ThrowIfDisposed();
		ThrowIfCantWrite();
		return _baseStream.FlushAsync(P_0);
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0 && !_isDisposed)
		{
			_onClosed?.Invoke(_zipArchiveEntry);
			if (_closeBaseStream)
			{
				_baseStream.Dispose();
			}
			_isDisposed = true;
		}
		base.Dispose(P_0);
	}
}
