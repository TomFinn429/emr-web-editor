using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal abstract class HttpBaseStream : Stream
{
	public sealed override bool CanSeek => false;

	public sealed override long Length
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public sealed override long Position
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

	public sealed override IAsyncResult BeginRead(byte[] P_0, int P_1, int P_2, AsyncCallback P_3, object P_4)
	{
		return System.Threading.Tasks.TaskToApm.Begin(ReadAsync(P_0, P_1, P_2, default(CancellationToken)), P_3, P_4);
	}

	public sealed override int EndRead(IAsyncResult P_0)
	{
		return System.Threading.Tasks.TaskToApm.End<int>(P_0);
	}

	public sealed override IAsyncResult BeginWrite(byte[] P_0, int P_1, int P_2, AsyncCallback P_3, object P_4)
	{
		return System.Threading.Tasks.TaskToApm.Begin(WriteAsync(P_0, P_1, P_2, default(CancellationToken)), P_3, P_4);
	}

	public sealed override void EndWrite(IAsyncResult P_0)
	{
		System.Threading.Tasks.TaskToApm.End(P_0);
	}

	public sealed override long Seek(long P_0, SeekOrigin P_1)
	{
		throw new NotSupportedException();
	}

	public sealed override void SetLength(long P_0)
	{
		throw new NotSupportedException();
	}

	public sealed override int ReadByte()
	{
		byte result = 0;
		if (Read(new Span<byte>(ref result)) != 1)
		{
			return -1;
		}
		return result;
	}

	public sealed override int Read(byte[] P_0, int P_1, int P_2)
	{
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		return Read(P_0.AsSpan(P_1, P_2));
	}

	public sealed override Task<int> ReadAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		return ReadAsync(new Memory<byte>(P_0, P_1, P_2), P_3).AsTask();
	}

	public override void Write(byte[] P_0, int P_1, int P_2)
	{
		WriteAsync(P_0, P_1, P_2, CancellationToken.None).GetAwaiter().GetResult();
	}

	public sealed override void WriteByte(byte P_0)
	{
		Write(new ReadOnlySpan<byte>(in P_0));
	}

	public sealed override Task WriteAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
	{
		Stream.ValidateBufferArguments(P_0, P_1, P_2);
		return WriteAsync(new ReadOnlyMemory<byte>(P_0, P_1, P_2), P_3).AsTask();
	}

	public override void Flush()
	{
		FlushAsync(default(CancellationToken)).GetAwaiter().GetResult();
	}

	public override Task FlushAsync(CancellationToken P_0)
	{
		return NopAsync(P_0);
	}

	protected static Task NopAsync(CancellationToken P_0)
	{
		if (!P_0.IsCancellationRequested)
		{
			return Task.CompletedTask;
		}
		return Task.FromCanceled(P_0);
	}

	public abstract override int Read(Span<byte> P_0);

	public abstract override ValueTask<int> ReadAsync(Memory<byte> P_0, CancellationToken P_1);

	public abstract override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1);
}
