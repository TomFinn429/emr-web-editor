namespace System.Net.Http.Headers;

internal sealed class TransferCodingHeaderParser : BaseHeaderParser
{
	private readonly Func<TransferCodingHeaderValue> _transferCodingCreator;

	internal static readonly TransferCodingHeaderParser SingleValueParser = new TransferCodingHeaderParser(false, CreateTransferCoding);

	internal static readonly TransferCodingHeaderParser MultipleValueParser = new TransferCodingHeaderParser(true, CreateTransferCoding);

	internal static readonly TransferCodingHeaderParser SingleValueWithQualityParser = new TransferCodingHeaderParser(false, CreateTransferCodingWithQuality);

	internal static readonly TransferCodingHeaderParser MultipleValueWithQualityParser = new TransferCodingHeaderParser(true, CreateTransferCodingWithQuality);

	private TransferCodingHeaderParser(bool P_0, Func<TransferCodingHeaderValue> P_1)
		: base(P_0)
	{
		_transferCodingCreator = P_1;
	}

	protected override int GetParsedValueLength(string P_0, int P_1, object P_2, out object P_3)
	{
		TransferCodingHeaderValue transferCodingHeaderValue;
		int transferCodingLength = TransferCodingHeaderValue.GetTransferCodingLength(P_0, P_1, _transferCodingCreator, out transferCodingHeaderValue);
		P_3 = transferCodingHeaderValue;
		return transferCodingLength;
	}

	private static TransferCodingHeaderValue CreateTransferCoding()
	{
		return new TransferCodingHeaderValue();
	}

	private static TransferCodingHeaderValue CreateTransferCodingWithQuality()
	{
		return new TransferCodingWithQualityHeaderValue();
	}
}
