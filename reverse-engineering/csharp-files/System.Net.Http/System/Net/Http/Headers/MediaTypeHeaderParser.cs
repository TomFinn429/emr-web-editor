namespace System.Net.Http.Headers;

internal sealed class MediaTypeHeaderParser : BaseHeaderParser
{
	private readonly Func<MediaTypeHeaderValue> _mediaTypeCreator;

	internal static readonly MediaTypeHeaderParser SingleValueParser = new MediaTypeHeaderParser(false, CreateMediaType);

	internal static readonly MediaTypeHeaderParser SingleValueWithQualityParser = new MediaTypeHeaderParser(false, CreateMediaTypeWithQuality);

	internal static readonly MediaTypeHeaderParser MultipleValuesParser = new MediaTypeHeaderParser(true, CreateMediaTypeWithQuality);

	private MediaTypeHeaderParser(bool P_0, Func<MediaTypeHeaderValue> P_1)
		: base(P_0)
	{
		_mediaTypeCreator = P_1;
	}

	protected override int GetParsedValueLength(string P_0, int P_1, object P_2, out object P_3)
	{
		MediaTypeHeaderValue mediaTypeHeaderValue;
		int mediaTypeLength = MediaTypeHeaderValue.GetMediaTypeLength(P_0, P_1, _mediaTypeCreator, out mediaTypeHeaderValue);
		P_3 = mediaTypeHeaderValue;
		return mediaTypeLength;
	}

	private static MediaTypeHeaderValue CreateMediaType()
	{
		return new MediaTypeHeaderValue();
	}

	private static MediaTypeHeaderValue CreateMediaTypeWithQuality()
	{
		return new MediaTypeWithQualityHeaderValue();
	}
}
