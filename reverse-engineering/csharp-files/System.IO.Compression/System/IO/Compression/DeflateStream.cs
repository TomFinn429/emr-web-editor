using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Compression;

public class DeflateStream : Stream
{
	private sealed class CopyToStream : Stream
	{
		private readonly DeflateStream _deflateStream;

		private readonly Stream _destination;

		private readonly CancellationToken _cancellationToken;

		private byte[] _arrayPoolBuffer;

		public override bool CanWrite => true;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public CopyToStream(DeflateStream P_0, Stream P_1, int P_2)
			: this(P_0, P_1, P_2, CancellationToken.None)
		{
		}

		public CopyToStream(DeflateStream P_0, Stream P_1, int P_2, CancellationToken P_3)
		{
			_deflateStream = P_0;
			_destination = P_1;
			_cancellationToken = P_3;
			_arrayPoolBuffer = ArrayPool<byte>.Shared.Rent(P_2);
		}

		public async Task CopyFromSourceToDestinationAsync()
		{
			_deflateStream.AsyncOperationStarting();
			try
			{
				while (!_deflateStream._inflater.Finished())
				{
					int num = _deflateStream._inflater.Inflate(_arrayPoolBuffer, 0, _arrayPoolBuffer.Length);
					if (num > 0)
					{
						await _destination.WriteAsync(new ReadOnlyMemory<byte>(_arrayPoolBuffer, 0, num), _cancellationToken).ConfigureAwait(false);
					}
					else if (_deflateStream._inflater.NeedsInput())
					{
						break;
					}
				}
				await _deflateStream._stream.CopyToAsync(this, _arrayPoolBuffer.Length, _cancellationToken).ConfigureAwait(false);
			}
			finally
			{
				_deflateStream.AsyncOperationCompleting();
				ArrayPool<byte>.Shared.Return(_arrayPoolBuffer);
				_arrayPoolBuffer = null;
			}
		}

		public void CopyFromSourceToDestination()
		{
			try
			{
				while (!_deflateStream._inflater.Finished())
				{
					int num = _deflateStream._inflater.Inflate(_arrayPoolBuffer, 0, _arrayPoolBuffer.Length);
					if (num > 0)
					{
						_destination.Write(_arrayPoolBuffer, 0, num);
					}
					else if (_deflateStream._inflater.NeedsInput())
					{
						break;
					}
				}
				_deflateStream._stream.CopyTo(this, _arrayPoolBuffer.Length);
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(_arrayPoolBuffer);
				_arrayPoolBuffer = null;
			}
		}

		public override Task WriteAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
		{
			_deflateStream.EnsureNotDisposed();
			if (P_2 <= 0)
			{
				return Task.CompletedTask;
			}
			if (P_2 > P_0.Length - P_1)
			{
				return Task.FromException(new InvalidDataException("GenericInvalidData"));
			}
			return WriteAsyncCore(P_0.AsMemory(P_1, P_2), P_3).AsTask();
		}

		public override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
		{
			_deflateStream.EnsureNotDisposed();
			return WriteAsyncCore(P_0, P_1);
		}

		private async ValueTask WriteAsyncCore(ReadOnlyMemory<byte> P_0, CancellationToken P_1)
		{
			_deflateStream._inflater.SetInput(P_0);
			while (!_deflateStream._inflater.Finished())
			{
				int num = _deflateStream._inflater.Inflate(new Span<byte>(_arrayPoolBuffer));
				if (num > 0)
				{
					await _destination.WriteAsync(new ReadOnlyMemory<byte>(_arrayPoolBuffer, 0, num), P_1).ConfigureAwait(false);
				}
				else if (_deflateStream._inflater.NeedsInput())
				{
					break;
				}
			}
		}

		public override void Write(byte[] P_0, int P_1, int P_2)
		{
			_deflateStream.EnsureNotDisposed();
			if (P_2 <= 0)
			{
				return;
			}
			if (P_2 > P_0.Length - P_1)
			{
				throw new InvalidDataException("GenericInvalidData");
			}
			_deflateStream._inflater.SetInput(P_0, P_1, P_2);
			while (!_deflateStream._inflater.Finished())
			{
				int num = _deflateStream._inflater.Inflate(new Span<byte>(_arrayPoolBuffer));
				if (num > 0)
				{
					_destination.Write(_arrayPoolBuffer, 0, num);
				}
				else if (_deflateStream._inflater.NeedsInput())
				{
					break;
				}
			}
		}

		public override void Flush()
		{
		}

		public override int Read(byte[] P_0, int P_1, int P_2)
		{
			throw new NotSupportedException();
		}

		public override long Seek(long P_0, SeekOrigin P_1)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long P_0)
		{
			throw new NotSupportedException();
		}
	}

	private Stream _stream;

	private CompressionMode _mode;

	private bool _leaveOpen;

	private Inflater _inflater;

	private Deflater _deflater;

	private byte[] _buffer;

	private int _activeAsyncOperation;

	private bool _wroteBytes;

	public override bool CanRead
	{
		get
		{
			if (_stream == null)
			{
				return false;
			}
			if (_mode == CompressionMode.Decompress)
			{
				return _stream.CanRead;
			}
			return false;
		}
	}

	public override bool CanWrite
	{
		get
		{
			if (_stream == null)
			{
				return false;
			}
			if (_mode == CompressionMode.Compress)
			{
				return _stream.CanWrite;
			}
			return false;
		}
	}

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

	private bool InflatorIsFinished
	{
		get
		{
			if (_inflater.Finished())
			{
				if (_inflater.IsGzipStream())
				{
					return !_inflater.NeedsInput();
				}
				return true;
			}
			return false;
		}
	}

	private bool AsyncOperationIsActive => _activeAsyncOperation != 0;

	internal DeflateStream(Stream P_0, CompressionMode P_1, long P_2)
		: this(P_0, P_1, false, -15, P_2)
	{
	}

	public DeflateStream(Stream P_0, CompressionMode P_1, bool P_2)
		: this(P_0, P_1, P_2, -15, -1L)
	{
	}

	public DeflateStream(Stream P_0, CompressionLevel P_1, bool P_2)
		: this(P_0, P_1, P_2, -15)
	{
	}

	internal DeflateStream(Stream P_0, CompressionMode P_1, bool P_2, int P_3, long P_4 = -1L)
	{
		ArgumentNullException.ThrowIfNull(P_0, "stream");
		switch (P_1)
		{
		case CompressionMode.Decompress:
			if (!P_0.CanRead)
			{
				throw new ArgumentException("NotSupported_UnreadableStream", "stream");
			}
			_inflater = new Inflater(P_3, P_4);
			_stream = P_0;
			_mode = CompressionMode.Decompress;
			_leaveOpen = P_2;
			break;
		case CompressionMode.Compress:
			InitializeDeflater(P_0, P_2, P_3, CompressionLevel.Optimal);
			break;
		default:
			throw new ArgumentException("ArgumentOutOfRange_Enum", "mode");
		}
	}

	internal DeflateStream(Stream P_0, CompressionLevel P_1, bool P_2, int P_3)
	{
		ArgumentNullException.ThrowIfNull(P_0, "stream");
		InitializeDeflater(P_0, P_2, P_3, P_1);
	}

	[MemberNotNull("_stream")]
	internal void InitializeDeflater(Stream P_0, bool P_1, int P_2, CompressionLevel P_3)
	{
		if (!P_0.CanWrite)
		{
			throw new ArgumentException("NotSupported_UnwritableStream", "stream");
		}
		_deflater = new Deflater(P_3, P_2);
		_stream = P_0;
		_mode = CompressionMode.Compress;
		_leaveOpen = P_1;
		InitializeBuffer();
	}

	[MemberNotNull("_buffer")]
	private void InitializeBuffer()
	{
		_buffer = ArrayPool<byte>.Shared.Rent(8192);
	}

	[MemberNotNull("_buffer")]
	private void EnsureBufferInitialized()
	{
		if (_buffer == null)
		{
			InitializeBuffer();
		}
	}

	public override void Flush()
	{
		EnsureNotDisposed();
		if (_mode == CompressionMode.Compress)
		{
			FlushBuffers();
		}
	}

	public override Task FlushAsync(CancellationToken P_0)
	{
		EnsureNoActiveAsyncOperation();
		EnsureNotDisposed();
		if (P_0.IsCancellationRequested)
		{
			return Task.FromCanceled(P_0);
		}
		if (_mode == CompressionMode.Compress)
		{
			return Core(P_0);
		}
		return Task.CompletedTask;
		async Task Core(CancellationToken cancellationToken)
		{
			AsyncOperationStarting();
			try
			{
				await WriteDeflaterOutputAsync(cancellationToken).ConfigureAwait(false);
				bool flushSuccessful;
				do
				{
					flushSuccessful = _deflater.Flush(_buffer, out var num);
					if (flushSuccessful)
					{
						await _stream.WriteAsync(new ReadOnlyMemory<byte>(_buffer, 0, num), cancellationToken).ConfigureAwait(false);
					}
				}
				while (flushSuccessful);
				await _stream.FlushAsync(cancellationToken).ConfigureAwait(false);
			}
			finally
			{
				AsyncOperationCompleting();
			}
		}
	}

	public override long Seek(long P_0, SeekOrigin P_1)
	{
		throw new NotSupportedException("NotSupported");
	}

	public override void SetLength(long P_0)
	{
		throw new NotSupportedException("NotSupported");
	}

	public override int ReadByte()
	{
		EnsureDecompressionMode();
		EnsureNotDisposed();
		if (!_inflater.Inflate(out var result))
		{
			return base.ReadByte();
		}
		return result;
	}

	public override int Read(byte[] P_0, int P_1, int P_2)
	{
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		return ReadCore(new Span<byte>(P_0, P_1, P_2));
	}

	public override int Read(Span<byte> P_0)
	{
		if (GetType() != typeof(DeflateStream))
		{
			return base.Read(P_0);
		}
		return ReadCore(P_0);
	}

	internal int ReadCore(Span<byte> P_0)
	{
		EnsureDecompressionMode();
		EnsureNotDisposed();
		EnsureBufferInitialized();
		int num;
		do
		{
			num = _inflater.Inflate(P_0);
			if (num != 0 || InflatorIsFinished)
			{
				break;
			}
			if (_inflater.NeedsInput())
			{
				int num2 = _stream.Read(_buffer, 0, _buffer.Length);
				if (num2 <= 0)
				{
					break;
				}
				if (num2 > _buffer.Length)
				{
					ThrowGenericInvalidData();
				}
				else
				{
					_inflater.SetInput(_buffer, 0, num2);
				}
			}
		}
		while (!P_0.IsEmpty);
		return num;
	}

	private void EnsureNotDisposed()
	{
		if (_stream == null)
		{
			ThrowStreamClosedException();
		}
		static void ThrowStreamClosedException()
		{
			throw new ObjectDisposedException("DeflateStream", "ObjectDisposed_StreamClosed");
		}
	}

	private void EnsureDecompressionMode()
	{
		if (_mode != CompressionMode.Decompress)
		{
			ThrowCannotReadFromDeflateStreamException();
		}
		static void ThrowCannotReadFromDeflateStreamException()
		{
			throw new InvalidOperationException("CannotReadFromDeflateStream");
		}
	}

	private void EnsureCompressionMode()
	{
		if (_mode != CompressionMode.Compress)
		{
			ThrowCannotWriteToDeflateStreamException();
		}
		static void ThrowCannotWriteToDeflateStreamException()
		{
			throw new InvalidOperationException("CannotWriteToDeflateStream");
		}
	}

	private static void ThrowGenericInvalidData()
	{
		throw new InvalidDataException("GenericInvalidData");
	}

	public override IAsyncResult BeginRead(byte[] P_0, int P_1, int P_2, AsyncCallback? P_3, object? P_4)
	{
		return System.Threading.Tasks.TaskToApm.Begin(ReadAsync(P_0, P_1, P_2, CancellationToken.None), P_3, P_4);
	}

	public override int EndRead(IAsyncResult P_0)
	{
		EnsureDecompressionMode();
		EnsureNotDisposed();
		return System.Threading.Tasks.TaskToApm.End<int>(P_0);
	}

	public override Task<int> ReadAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		return ReadAsyncMemory(new Memory<byte>(P_0, P_1, P_2), P_3).AsTask();
	}

	public override ValueTask<int> ReadAsync(Memory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
	{
		if (GetType() != typeof(DeflateStream))
		{
			return base.ReadAsync(P_0, P_1);
		}
		return ReadAsyncMemory(P_0, P_1);
	}

	internal ValueTask<int> ReadAsyncMemory(Memory<byte> P_0, CancellationToken P_1)
	{
		EnsureDecompressionMode();
		EnsureNoActiveAsyncOperation();
		EnsureNotDisposed();
		if (P_1.IsCancellationRequested)
		{
			return ValueTask.FromCanceled<int>(P_1);
		}
		EnsureBufferInitialized();
		return Core(P_0, P_1);
		async ValueTask<int> Core(Memory<byte> memory, CancellationToken cancellationToken)
		{
			AsyncOperationStarting();
			try
			{
				int bytesRead;
				do
				{
					bytesRead = _inflater.Inflate(memory.Span);
					if (bytesRead != 0 || InflatorIsFinished)
					{
						break;
					}
					if (_inflater.NeedsInput())
					{
						int num = await _stream.ReadAsync(new Memory<byte>(_buffer, 0, _buffer.Length), cancellationToken).ConfigureAwait(false);
						if (num <= 0)
						{
							break;
						}
						if (num > _buffer.Length)
						{
							ThrowGenericInvalidData();
						}
						else
						{
							_inflater.SetInput(_buffer, 0, num);
						}
					}
				}
				while (!memory.IsEmpty);
				return bytesRead;
			}
			finally
			{
				AsyncOperationCompleting();
			}
		}
	}

	public override void Write(byte[] P_0, int P_1, int P_2)
	{
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		WriteCore(new ReadOnlySpan<byte>(P_0, P_1, P_2));
	}

	public override void WriteByte(byte P_0)
	{
		if (GetType() != typeof(DeflateStream))
		{
			base.WriteByte(P_0);
		}
		else
		{
			WriteCore(new ReadOnlySpan<byte>(in P_0));
		}
	}

	public override void Write(ReadOnlySpan<byte> P_0)
	{
		if (GetType() != typeof(DeflateStream))
		{
			base.Write(P_0);
		}
		else
		{
			WriteCore(P_0);
		}
	}

	internal unsafe void WriteCore(ReadOnlySpan<byte> P_0)
	{
		EnsureCompressionMode();
		EnsureNotDisposed();
		WriteDeflaterOutput();
		fixed (byte* reference = &MemoryMarshal.GetReference(P_0))
		{
			_deflater.SetInput(reference, P_0.Length);
			WriteDeflaterOutput();
			_wroteBytes = true;
		}
	}

	private void WriteDeflaterOutput()
	{
		while (!_deflater.NeedsInput())
		{
			int deflateOutput = _deflater.GetDeflateOutput(_buffer);
			if (deflateOutput > 0)
			{
				_stream.Write(_buffer, 0, deflateOutput);
			}
		}
	}

	private void FlushBuffers()
	{
		if (_wroteBytes)
		{
			WriteDeflaterOutput();
			bool flag;
			do
			{
				flag = _deflater.Flush(_buffer, out var num);
				if (flag)
				{
					_stream.Write(_buffer, 0, num);
				}
			}
			while (flag);
		}
		_stream.Flush();
	}

	private void PurgeBuffers(bool P_0)
	{
		if (!P_0 || _stream == null || _mode != CompressionMode.Compress)
		{
			return;
		}
		if (_wroteBytes)
		{
			WriteDeflaterOutput();
			bool flag;
			do
			{
				flag = _deflater.Finish(_buffer, out var num);
				if (num > 0)
				{
					_stream.Write(_buffer, 0, num);
				}
			}
			while (!flag);
		}
		else
		{
			int num2;
			while (!_deflater.Finish(_buffer, out num2))
			{
			}
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
				if (P_0 && !_leaveOpen)
				{
					_stream?.Dispose();
				}
			}
			finally
			{
				_stream = null;
				try
				{
					_deflater?.Dispose();
					_inflater?.Dispose();
				}
				finally
				{
					_deflater = null;
					_inflater = null;
					byte[] buffer = _buffer;
					if (buffer != null)
					{
						_buffer = null;
						if (!AsyncOperationIsActive)
						{
							ArrayPool<byte>.Shared.Return(buffer);
						}
					}
					base.Dispose(P_0);
				}
			}
		}
	}

	public override IAsyncResult BeginWrite(byte[] P_0, int P_1, int P_2, AsyncCallback? P_3, object? P_4)
	{
		return System.Threading.Tasks.TaskToApm.Begin(WriteAsync(P_0, P_1, P_2, CancellationToken.None), P_3, P_4);
	}

	public override void EndWrite(IAsyncResult P_0)
	{
		EnsureCompressionMode();
		EnsureNotDisposed();
		System.Threading.Tasks.TaskToApm.End(P_0);
	}

	public override Task WriteAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		return WriteAsyncMemory(new ReadOnlyMemory<byte>(P_0, P_1, P_2), P_3).AsTask();
	}

	public override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1)
	{
		if (GetType() != typeof(DeflateStream))
		{
			return base.WriteAsync(P_0, P_1);
		}
		return WriteAsyncMemory(P_0, P_1);
	}

	internal ValueTask WriteAsyncMemory(ReadOnlyMemory<byte> P_0, CancellationToken P_1)
	{
		EnsureCompressionMode();
		EnsureNoActiveAsyncOperation();
		EnsureNotDisposed();
		if (!P_1.IsCancellationRequested)
		{
			return Core(P_0, P_1);
		}
		return ValueTask.FromCanceled(P_1);
		async ValueTask Core(ReadOnlyMemory<byte> input, CancellationToken cancellationToken)
		{
			AsyncOperationStarting();
			try
			{
				await WriteDeflaterOutputAsync(cancellationToken).ConfigureAwait(false);
				_deflater.SetInput(input);
				await WriteDeflaterOutputAsync(cancellationToken).ConfigureAwait(false);
				_wroteBytes = true;
			}
			finally
			{
				AsyncOperationCompleting();
			}
		}
	}

	private async ValueTask WriteDeflaterOutputAsync(CancellationToken P_0)
	{
		while (!_deflater.NeedsInput())
		{
			int deflateOutput = _deflater.GetDeflateOutput(_buffer);
			if (deflateOutput > 0)
			{
				await _stream.WriteAsync(new ReadOnlyMemory<byte>(_buffer, 0, deflateOutput), P_0).ConfigureAwait(false);
			}
		}
	}

	public override void CopyTo(Stream P_0, int P_1)
	{
		Stream.ValidateCopyToArguments(P_0, P_1);
		EnsureNotDisposed();
		if (!CanRead)
		{
			throw new NotSupportedException();
		}
		new CopyToStream(this, P_0, P_1).CopyFromSourceToDestination();
	}

	public override Task CopyToAsync(Stream P_0, int P_1, CancellationToken P_2)
	{
		Stream.ValidateCopyToArguments(P_0, P_1);
		EnsureNotDisposed();
		if (!CanRead)
		{
			throw new NotSupportedException();
		}
		EnsureNoActiveAsyncOperation();
		if (P_2.IsCancellationRequested)
		{
			return Task.FromCanceled<int>(P_2);
		}
		return new CopyToStream(this, P_0, P_1, P_2).CopyFromSourceToDestinationAsync();
	}

	private void EnsureNoActiveAsyncOperation()
	{
		if (AsyncOperationIsActive)
		{
			ThrowInvalidBeginCall();
		}
	}

	private void AsyncOperationStarting()
	{
		if (Interlocked.Exchange(ref _activeAsyncOperation, 1) != 0)
		{
			ThrowInvalidBeginCall();
		}
	}

	private void AsyncOperationCompleting()
	{
		Volatile.Write(ref _activeAsyncOperation, 0);
	}

	private static void ThrowInvalidBeginCall()
	{
		throw new InvalidOperationException("InvalidBeginCall");
	}
}
