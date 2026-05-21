namespace System.Net.Http.Headers;

public sealed class TransferCodingWithQualityHeaderValue : TransferCodingHeaderValue, ICloneable
{
	internal TransferCodingWithQualityHeaderValue()
	{
	}

	private TransferCodingWithQualityHeaderValue(TransferCodingWithQualityHeaderValue P_0)
		: base(P_0)
	{
	}

	object ICloneable.Clone()
	{
		return new TransferCodingWithQualityHeaderValue(this);
	}
}
