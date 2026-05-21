namespace System.Net.Http.Headers;

public sealed class HttpContentHeaders : HttpHeaders
{
	private readonly HttpContent _parent;

	private bool _contentLengthSet;

	public long? ContentLength
	{
		get
		{
			object singleParsedValue = GetSingleParsedValue(KnownHeaders.ContentLength.Descriptor);
			if (!_contentLengthSet && singleParsedValue == null)
			{
				long? computedOrBufferLength = _parent.GetComputedOrBufferLength();
				if (computedOrBufferLength.HasValue)
				{
					SetParsedValue(KnownHeaders.ContentLength.Descriptor, computedOrBufferLength.Value);
				}
				return computedOrBufferLength;
			}
			if (singleParsedValue == null)
			{
				return null;
			}
			return (long)singleParsedValue;
		}
	}

	public MediaTypeHeaderValue? ContentType => (MediaTypeHeaderValue)GetSingleParsedValue(KnownHeaders.ContentType.Descriptor);

	internal HttpContentHeaders(HttpContent P_0)
		: base(HttpHeaderType.Content | HttpHeaderType.Custom, HttpHeaderType.None)
	{
		_parent = P_0;
	}
}
