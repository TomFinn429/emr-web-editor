namespace System.Net.Http.Headers;

public sealed class MediaTypeWithQualityHeaderValue : MediaTypeHeaderValue, ICloneable
{
	internal MediaTypeWithQualityHeaderValue()
	{
	}

	private MediaTypeWithQualityHeaderValue(MediaTypeWithQualityHeaderValue P_0)
		: base(P_0)
	{
	}

	object ICloneable.Clone()
	{
		return new MediaTypeWithQualityHeaderValue(this);
	}
}
