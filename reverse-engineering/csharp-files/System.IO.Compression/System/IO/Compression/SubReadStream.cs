using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Compression;

internal sealed class SubReadStream : Stream
{
	private readonly long _startInSuperStream;

	private long _positionInSuperStream;

	private readonly long _endInSuperStream;

	private readonly Stream _superStream;

	private bool _canRead;

	private bool _isDisposed;

	public override long Length
	{
		get
		{
			ThrowIfDisposed();
			return _endInSuperStream - _startInSuperStream;
		}
	}

	public override long Position
	{
		get
		{
			ThrowIfDisposed();
			return _positionInSuperStream - _startInSuperStream;
		}
		set
		{
			ThrowIfDisposed();
			throw new NotSupportedException("SeekingNotSupported");
		}
	}

	public override bool CanRead
	{
		get
		{
			if (_superStream.CanRead)
			{
				return _canRead;
			}
			return false;
		}
	}

	public override bool CanSeek => false;

	public override bool CanWrite => false;

	public SubReadStream(Stream P_0, long P_1, long P_2)
	{
		_startInSuperStream = P_1;
		_positionInSuperStream = P_1;
		_endInSuperStream = P_1 + P_2;
		_superStream = P_0;
		_canRead = true;
		_isDisposed = false;
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

	public override int Read(byte[] P_0, int P_1, int P_2)
	{
		int num = P_2;
		ThrowIfDisposed();
		ThrowIfCantRead();
		if (_superStream.Position != _positionInSuperStream)
		{
			_superStream.Seek(_positionInSuperStream, SeekOrigin.Begin);
		}
		if (_positionInSuperStream + P_2 > _endInSuperStream)
		{
			P_2 = (int)(_endInSuperStream - _positionInSuperStream);
		}
		int num2 = _superStream.Read(P_0, P_1, P_2);
		_positionInSuperStream += num2;
		return num2;
	}

	public override int Read(Span<byte> P_0)
	{
		int length = P_0.Length;
		int num = P_0.Length;
		ThrowIfDisposed();
		ThrowIfCantRead();
		if (_superStream.Position != _positionInSuperStream)
		{
			_superStream.Seek(_positionInSuperStream, SeekOrigin.Begin);
		}
		if (_positionInSuperStream + num > _endInSuperStream)
		{
			num = (int)(_endInSuperStream - _positionInSuperStream);
		}
		int num2 = _superStream.Read(P_0.Slice(0, num));
		_positionInSuperStream += num2;
		return num2;
	}

	public override int ReadByte()
	{
		byte result = 0;
		if (Read(new Span<byte>(ref result)) != 1)
		{
			return -1;
		}
		return result;
	}

	public override Task<int> ReadAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		return ReadAsync(new Memory<byte>(P_0, P_1, P_2), P_3).AsTask();
	}

	public override ValueTask<int> ReadAsync(Memory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
	{
		ThrowIfDisposed();
		ThrowIfCantRead();
		return Core(P_0, P_1);
		async ValueTask<int> Core(Memory<byte> memory, CancellationToken cancellationToken)
		{
			if (_superStream.Position != _positionInSuperStream)
			{
				_superStream.Seek(_positionInSuperStream, SeekOrigin.Begin);
			}
			if (_positionInSuperStream > _endInSuperStream - memory.Length)
			{
				memory = memory.Slice(0, (int)(_endInSuperStream - _positionInSuperStream));
			}
			int num = await _superStream.ReadAsync(memory, cancellationToken).ConfigureAwait(false);
			_positionInSuperStream += num;
			return num;
		}
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
		ThrowIfDisposed();
		throw new NotSupportedException("WritingNotSupported");
	}

	public override void Flush()
	{
		ThrowIfDisposed();
		throw new NotSupportedException("WritingNotSupported");
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0 && !_isDisposed)
		{
			_canRead = false;
			_isDisposed = true;
		}
		base.Dispose(P_0);
	}
}
