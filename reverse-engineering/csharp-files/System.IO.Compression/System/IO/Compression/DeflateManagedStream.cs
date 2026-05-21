using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Compression;

internal sealed class DeflateManagedStream : Stream
{
	private Stream _stream;

	private InflaterManaged _inflater;

	private readonly byte[] _buffer;

	private int _asyncOperations;

	public override bool CanRead
	{
		get
		{
			if (_stream == null)
			{
				return false;
			}
			return _stream.CanRead;
		}
	}

	public override bool CanWrite => false;

	public override bool CanSeek => false;

	public override long Length
	{
		get
		{
			throw new NotSupportedException("NotSupported");
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException("NotSupported");
		}
		set
		{
			throw new NotSupportedException("NotSupported");
		}
	}

	internal DeflateManagedStream(Stream P_0, ZipArchiveEntry.CompressionMethodValues P_1, long P_2 = -1L)
	{
		ArgumentNullException.ThrowIfNull(P_0, "stream");
		if (!P_0.CanRead)
		{
			throw new ArgumentException("NotSupported_UnreadableStream", "stream");
		}
		_inflater = new InflaterManaged(P_1 == ZipArchiveEntry.CompressionMethodValues.Deflate64, P_2);
		_stream = P_0;
		_buffer = new byte[8192];
	}

	public override void Flush()
	{
		EnsureNotDisposed();
	}

	public override Task FlushAsync(CancellationToken P_0)
	{
		EnsureNotDisposed();
		if (!P_0.IsCancellationRequested)
		{
			return Task.CompletedTask;
		}
		return Task.FromCanceled(P_0);
	}

	public override long Seek(long P_0, SeekOrigin P_1)
	{
		throw new NotSupportedException("NotSupported");
	}

	public override void SetLength(long P_0)
	{
		throw new NotSupportedException("NotSupported");
	}

	public override int Read(byte[] P_0, int P_1, int P_2)
	{
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		return Read(new Span<byte>(P_0, P_1, P_2));
	}

	public override int Read(Span<byte> P_0)
	{
		EnsureNotDisposed();
		int length = P_0.Length;
		while (true)
		{
			int num = _inflater.Inflate(P_0);
			P_0 = P_0.Slice(num);
			if (P_0.Length == 0 || _inflater.Finished())
			{
				break;
			}
			int num2 = _stream.Read(_buffer, 0, _buffer.Length);
			if (num2 <= 0)
			{
				break;
			}
			if (num2 > _buffer.Length)
			{
				throw new InvalidDataException("GenericInvalidData");
			}
			_inflater.SetInput(_buffer, 0, num2);
		}
		return length - P_0.Length;
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

	private void EnsureNotDisposed()
	{
		if (_stream == null)
		{
			ThrowStreamClosedException();
		}
	}

	private static void ThrowStreamClosedException()
	{
		throw new ObjectDisposedException("DeflateStream", "ObjectDisposed_StreamClosed");
	}

	public override IAsyncResult BeginRead(byte[] P_0, int P_1, int P_2, AsyncCallback P_3, object P_4)
	{
		return System.Threading.Tasks.TaskToApm.Begin(ReadAsync(P_0, P_1, P_2, CancellationToken.None), P_3, P_4);
	}

	public override int EndRead(IAsyncResult P_0)
	{
		return System.Threading.Tasks.TaskToApm.End<int>(P_0);
	}

	private ValueTask<int> ReadAsyncInternal(Memory<byte> P_0, CancellationToken P_1)
	{
		if (P_1.IsCancellationRequested)
		{
			return ValueTask.FromCanceled<int>(P_1);
		}
		Interlocked.Increment(ref _asyncOperations);
		bool flag = false;
		try
		{
			int num = _inflater.Inflate(P_0.Span);
			if (num != 0)
			{
				return ValueTask.FromResult(num);
			}
			if (_inflater.Finished())
			{
				return ValueTask.FromResult(0);
			}
			ValueTask<int> valueTask = _stream.ReadAsync(_buffer.AsMemory(), P_1);
			flag = true;
			return ReadAsyncCore(valueTask, P_0, P_1);
		}
		finally
		{
			if (!flag)
			{
				Interlocked.Decrement(ref _asyncOperations);
			}
		}
	}

	private async ValueTask<int> ReadAsyncCore(ValueTask<int> P_0, Memory<byte> P_1, CancellationToken P_2)
	{
		try
		{
			int num;
			while (true)
			{
				num = await P_0.ConfigureAwait(false);
				EnsureNotDisposed();
				if (num <= 0)
				{
					return 0;
				}
				if (num > _buffer.Length)
				{
					throw new InvalidDataException("GenericInvalidData");
				}
				P_2.ThrowIfCancellationRequested();
				_inflater.SetInput(_buffer, 0, num);
				num = _inflater.Inflate(P_1.Span);
				if (num != 0 || _inflater.Finished())
				{
					break;
				}
				P_0 = _stream.ReadAsync(_buffer.AsMemory(), P_2);
			}
			return num;
		}
		finally
		{
			Interlocked.Decrement(ref _asyncOperations);
		}
	}

	public override Task<int> ReadAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		if (_asyncOperations != 0)
		{
			throw new InvalidOperationException("InvalidBeginCall");
		}
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		EnsureNotDisposed();
		return ReadAsyncInternal(P_0.AsMemory(P_1, P_2), P_3).AsTask();
	}

	public override ValueTask<int> ReadAsync(Memory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
	{
		if (_asyncOperations != 0)
		{
			throw new InvalidOperationException("InvalidBeginCall");
		}
		EnsureNotDisposed();
		return ReadAsyncInternal(P_0, P_1);
	}

	public override void Write(byte[] P_0, int P_1, int P_2)
	{
		throw new InvalidOperationException("CannotWriteToDeflateStream");
	}

	private void PurgeBuffers(bool P_0)
	{
		if (P_0 && _stream != null)
		{
			Flush();
		}
	}

	protected override void Dispose(bool P_0)
	{
		try
		{
			PurgeBuffers(P_0);
		}
		finally
		{
			try
			{
				if (P_0 && _stream != null)
				{
					_stream.Dispose();
				}
			}
			finally
			{
				_stream = null;
				_inflater = null;
				base.Dispose(P_0);
			}
		}
	}
}
