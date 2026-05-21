using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal sealed class BrowserHttpContent : HttpContent
{
	private byte[] _data;

	private int _length = -1;

	private readonly WasmFetchResponse _fetchResponse;

	public BrowserHttpContent(WasmFetchResponse P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "fetchResponse");
		_fetchResponse = P_0;
	}

	private async ValueTask<byte[]> GetResponseData(CancellationToken P_0)
	{
		if (_data != null)
		{
			return _data;
		}
		_fetchResponse.ThrowIfDisposed();
		Task<int> responseLength = BrowserHttpInterop.GetResponseLength(_fetchResponse.FetchResponse);
		_length = await BrowserHttpInterop.CancelationHelper(responseLength, P_0, null, _fetchResponse.FetchResponse).ConfigureAwait(true);
		_data = new byte[_length];
		BrowserHttpInterop.GetResponseBytes(_fetchResponse.FetchResponse, new Span<byte>(_data));
		return _data;
	}

	protected override async Task<Stream> CreateContentReadStreamAsync()
	{
		return new MemoryStream(await GetResponseData(CancellationToken.None).ConfigureAwait(true), false);
	}

	protected override Task SerializeToStreamAsync(Stream P_0, TransportContext P_1)
	{
		return SerializeToStreamAsync(P_0, P_1, CancellationToken.None);
	}

	protected override async Task SerializeToStreamAsync(Stream P_0, TransportContext P_1, CancellationToken P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "stream");
		await P_0.WriteAsync(await GetResponseData(P_2).ConfigureAwait(true), P_2).ConfigureAwait(true);
	}

	protected internal override bool TryComputeLength(out long P_0)
	{
		if (_length != -1)
		{
			P_0 = _length;
			return true;
		}
		P_0 = 0L;
		return false;
	}

	protected override void Dispose(bool P_0)
	{
		_fetchResponse?.Dispose();
		base.Dispose(P_0);
	}
}
