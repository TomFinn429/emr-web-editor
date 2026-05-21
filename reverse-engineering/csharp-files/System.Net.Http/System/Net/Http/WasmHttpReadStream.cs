using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal sealed class WasmHttpReadStream : Stream
{
	private WasmFetchResponse _fetchResponse;

	public override bool CanRead => true;

	public override bool CanSeek => false;

	public override bool CanWrite => false;

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

	public WasmHttpReadStream(WasmFetchResponse P_0)
	{
		_fetchResponse = P_0;
	}

	public override async ValueTask<int> ReadAsync(Memory<byte> P_0, CancellationToken P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "buffer");
		_fetchResponse.ThrowIfDisposed();
		P_1.ThrowIfCancellationRequested();
		using (MemoryHandle handle = P_0.Pin())
		{
			Task<int> task = GetStreamedResponseBytesUnsafe(_fetchResponse, P_0, handle);
			return await BrowserHttpInterop.CancelationHelper(task, P_1, null, _fetchResponse.FetchResponse).ConfigureAwait(true);
		}
		unsafe static Task<int> GetStreamedResponseBytesUnsafe(WasmFetchResponse wasmFetchResponse, Memory<byte> memory, MemoryHandle memoryHandle)
		{
			return BrowserHttpInterop.GetStreamedResponseBytes(wasmFetchResponse.FetchResponse, (nint)memoryHandle.Pointer, memory.Length);
		}
	}

	public override Task<int> ReadAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		return ReadAsync(new Memory<byte>(P_0, P_1, P_2), P_3).AsTask();
	}

	protected override void Dispose(bool P_0)
	{
		_fetchResponse?.Dispose();
	}

	public override void Flush()
	{
	}

	public override int Read(byte[] P_0, int P_1, int P_2)
	{
		throw new NotSupportedException("net_http_synchronous_reads_not_supported");
	}

	public override long Seek(long P_0, SeekOrigin P_1)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long P_0)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] P_0, int P_1, int P_2)
	{
		throw new NotSupportedException();
	}
}
