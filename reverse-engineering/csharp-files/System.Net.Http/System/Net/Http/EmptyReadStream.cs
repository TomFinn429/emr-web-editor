using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal sealed class EmptyReadStream : HttpBaseStream
{
	internal static EmptyReadStream Instance { get; } = new EmptyReadStream();

	public override bool CanRead => true;

	public override bool CanWrite => false;

	private EmptyReadStream()
	{
	}

	protected override void Dispose(bool P_0)
	{
	}

	public override void Close()
	{
	}

	public override int Read(Span<byte> P_0)
	{
		return 0;
	}

	public override ValueTask<int> ReadAsync(Memory<byte> P_0, CancellationToken P_1)
	{
		if (!P_1.IsCancellationRequested)
		{
			return new ValueTask<int>(0);
		}
		return ValueTask.FromCanceled<int>(P_1);
	}

	public override Task CopyToAsync(Stream P_0, int P_1, CancellationToken P_2)
	{
		Stream.ValidateCopyToArguments(P_0, P_1);
		return HttpBaseStream.NopAsync(P_2);
	}

	public override void Write(ReadOnlySpan<byte> P_0)
	{
		throw new NotSupportedException("net_http_content_readonly_stream");
	}

	public override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1)
	{
		throw new NotSupportedException();
	}
}
