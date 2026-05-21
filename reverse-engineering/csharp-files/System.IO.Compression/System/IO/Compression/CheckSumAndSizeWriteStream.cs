using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Compression;

internal sealed class CheckSumAndSizeWriteStream : Stream
{
	private readonly Stream _baseStream;

	private readonly Stream _baseBaseStream;

	private long _position;

	private uint _checksum;

	private readonly bool _leaveOpenOnClose;

	private readonly bool _canWrite;

	private bool _isDisposed;

	private bool _everWritten;

	private long _initialPosition;

	private readonly ZipArchiveEntry _zipArchiveEntry;

	private readonly EventHandler _onClose;

	private readonly Action<long, long, uint, Stream, ZipArchiveEntry, EventHandler> _saveCrcAndSizes;

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

	public CheckSumAndSizeWriteStream(Stream P_0, Stream P_1, bool P_2, ZipArchiveEntry P_3, EventHandler P_4, Action<long, long, uint, Stream, ZipArchiveEntry, EventHandler> P_5)
	{
		_baseStream = P_0;
		_baseBaseStream = P_1;
		_position = 0L;
		_checksum = 0u;
		_leaveOpenOnClose = P_2;
		_canWrite = true;
		_isDisposed = false;
		_initialPosition = 0L;
		_zipArchiveEntry = P_3;
		_onClose = P_4;
		_saveCrcAndSizes = P_5;
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
				_initialPosition = _baseBaseStream.Position;
				_everWritten = true;
			}
			_checksum = Crc32Helper.UpdateCrc32(_checksum, P_0, P_1, P_2);
			_baseStream.Write(P_0, P_1, P_2);
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
				_initialPosition = _baseBaseStream.Position;
				_everWritten = true;
			}
			_checksum = Crc32Helper.UpdateCrc32(_checksum, P_0);
			_baseStream.Write(P_0);
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
		async ValueTask Core(ReadOnlyMemory<byte> readOnlyMemory, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!_everWritten)
			{
				_initialPosition = _baseBaseStream.Position;
				_everWritten = true;
			}
			_checksum = Crc32Helper.UpdateCrc32(_checksum, readOnlyMemory.Span);
			await _baseStream.WriteAsync(readOnlyMemory, cancellationToken).ConfigureAwait(false);
			_position += readOnlyMemory.Length;
		}
	}

	public override void Flush()
	{
		ThrowIfDisposed();
		_baseStream.Flush();
	}

	public override Task FlushAsync(CancellationToken P_0)
	{
		ThrowIfDisposed();
		return _baseStream.FlushAsync(P_0);
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0 && !_isDisposed)
		{
			if (!_everWritten)
			{
				_initialPosition = _baseBaseStream.Position;
			}
			if (!_leaveOpenOnClose)
			{
				_baseStream.Dispose();
			}
			_saveCrcAndSizes?.Invoke(_initialPosition, Position, _checksum, _baseBaseStream, _zipArchiveEntry, _onClose);
			_isDisposed = true;
		}
		base.Dispose(P_0);
	}
}
