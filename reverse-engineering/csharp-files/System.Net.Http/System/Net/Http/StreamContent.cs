using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public class StreamContent : HttpContent
{
	private sealed class ReadOnlyStream : DelegatingStream
	{
		public override bool CanWrite => false;

		public ReadOnlyStream(Stream P_0)
			: base(P_0)
		{
		}

		public override void Flush()
		{
		}

		public override Task FlushAsync(CancellationToken P_0)
		{
			return Task.CompletedTask;
		}

		public override void SetLength(long P_0)
		{
			throw new NotSupportedException("net_http_content_readonly_stream");
		}

		public override IAsyncResult BeginWrite(byte[] P_0, int P_1, int P_2, AsyncCallback P_3, object P_4)
		{
			throw new NotSupportedException("net_http_content_readonly_stream");
		}

		public override void EndWrite(IAsyncResult P_0)
		{
			throw new NotSupportedException("net_http_content_readonly_stream");
		}

		public override void Write(byte[] P_0, int P_1, int P_2)
		{
			throw new NotSupportedException("net_http_content_readonly_stream");
		}

		public override void Write(ReadOnlySpan<byte> P_0)
		{
			throw new NotSupportedException("net_http_content_readonly_stream");
		}

		public override void WriteByte(byte P_0)
		{
			throw new NotSupportedException("net_http_content_readonly_stream");
		}

		public override Task WriteAsync(byte[] P_0, int P_1, int P_2, CancellationToken P_3)
		{
			throw new NotSupportedException("net_http_content_readonly_stream");
		}

		public override ValueTask WriteAsync(ReadOnlyMemory<byte> P_0, CancellationToken P_1 = default(CancellationToken))
		{
			throw new NotSupportedException("net_http_content_readonly_stream");
		}
	}

	private Stream _content;

	private int _bufferSize;

	private bool _contentConsumed;

	private long _start;

	public StreamContent(Stream P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "content");
		InitializeContent(P_0, 0);
	}

	[MemberNotNull("_content")]
	private void InitializeContent(Stream P_0, int P_1)
	{
		_content = P_0;
		_bufferSize = P_1;
		if (P_0.CanSeek)
		{
			_start = P_0.Position;
		}
		if (!NetEventSource.Log.IsEnabled())
		{
		}
	}

	protected override Task SerializeToStreamAsync(Stream P_0, TransportContext? P_1)
	{
		return SerializeToStreamAsyncCore(P_0, default(CancellationToken));
	}

	protected override Task SerializeToStreamAsync(Stream P_0, TransportContext? P_1, CancellationToken P_2)
	{
		if (!(GetType() == typeof(StreamContent)))
		{
			return base.SerializeToStreamAsync(P_0, P_1, P_2);
		}
		return SerializeToStreamAsyncCore(P_0, P_2);
	}

	private Task SerializeToStreamAsyncCore(Stream P_0, CancellationToken P_1)
	{
		PrepareContent();
		return StreamToStreamCopy.CopyAsync(_content, P_0, _bufferSize, !_content.CanSeek, P_1);
	}

	protected internal override bool TryComputeLength(out long P_0)
	{
		if (_content.CanSeek)
		{
			P_0 = _content.Length - _start;
			return true;
		}
		P_0 = 0L;
		return false;
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0)
		{
			_content.Dispose();
		}
		base.Dispose(P_0);
	}

	protected override Task<Stream> CreateContentReadStreamAsync()
	{
		return Task.FromResult((Stream)new ReadOnlyStream(_content));
	}

	internal override Stream TryCreateContentReadStream()
	{
		if (!(GetType() == typeof(StreamContent)))
		{
			return null;
		}
		return new ReadOnlyStream(_content);
	}

	private void PrepareContent()
	{
		if (_contentConsumed)
		{
			if (!_content.CanSeek)
			{
				throw new InvalidOperationException("net_http_content_stream_already_read");
			}
			_content.Position = _start;
		}
		_contentConsumed = true;
	}
}
