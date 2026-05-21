using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal sealed class EmptyContent : HttpContent
{
	protected internal override bool TryComputeLength(out long P_0)
	{
		P_0 = 0L;
		return true;
	}

	protected override Task SerializeToStreamAsync(Stream P_0, TransportContext P_1)
	{
		return Task.CompletedTask;
	}

	protected override Task SerializeToStreamAsync(Stream P_0, TransportContext P_1, CancellationToken P_2)
	{
		if (!P_2.IsCancellationRequested)
		{
			return SerializeToStreamAsync(P_0, P_1);
		}
		return Task.FromCanceled(P_2);
	}

	protected override Task<Stream> CreateContentReadStreamAsync()
	{
		return Task.FromResult((Stream)EmptyReadStream.Instance);
	}

	protected override Task<Stream> CreateContentReadStreamAsync(CancellationToken P_0)
	{
		if (!P_0.IsCancellationRequested)
		{
			return CreateContentReadStreamAsync();
		}
		return Task.FromCanceled<Stream>(P_0);
	}

	internal override Stream TryCreateContentReadStream()
	{
		return EmptyReadStream.Instance;
	}
}
