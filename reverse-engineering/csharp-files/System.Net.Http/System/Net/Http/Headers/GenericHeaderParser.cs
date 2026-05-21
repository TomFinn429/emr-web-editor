using System.Collections;

namespace System.Net.Http.Headers;

internal sealed class GenericHeaderParser : BaseHeaderParser
{
	private delegate int GetParsedValueLengthDelegate(string P_0, int P_1, out object P_2);

	internal static readonly GenericHeaderParser HostParser = new GenericHeaderParser(false, ParseHost, StringComparer.OrdinalIgnoreCase);

	internal static readonly GenericHeaderParser TokenListParser = new GenericHeaderParser(true, ParseTokenList, StringComparer.OrdinalIgnoreCase);

	internal static readonly GenericHeaderParser SingleValueNameValueWithParametersParser = new GenericHeaderParser(false, NameValueWithParametersHeaderValue.GetNameValueWithParametersLength);

	internal static readonly GenericHeaderParser MultipleValueNameValueWithParametersParser = new GenericHeaderParser(true, NameValueWithParametersHeaderValue.GetNameValueWithParametersLength);

	internal static readonly GenericHeaderParser SingleValueNameValueParser = new GenericHeaderParser(false, ParseNameValue);

	internal static readonly GenericHeaderParser MultipleValueNameValueParser = new GenericHeaderParser(true, ParseNameValue);

	internal static readonly GenericHeaderParser SingleValueParserWithoutValidation = new GenericHeaderParser(false, ParseWithoutValidation);

	internal static readonly GenericHeaderParser SingleValueProductParser = new GenericHeaderParser(false, ParseProduct);

	internal static readonly GenericHeaderParser MultipleValueProductParser = new GenericHeaderParser(true, ParseProduct);

	internal static readonly GenericHeaderParser RangeConditionParser = new GenericHeaderParser(false, RangeConditionHeaderValue.GetRangeConditionLength);

	internal static readonly GenericHeaderParser SingleValueAuthenticationParser = new GenericHeaderParser(false, AuthenticationHeaderValue.GetAuthenticationLength);

	internal static readonly GenericHeaderParser MultipleValueAuthenticationParser = new GenericHeaderParser(true, AuthenticationHeaderValue.GetAuthenticationLength);

	internal static readonly GenericHeaderParser RangeParser = new GenericHeaderParser(false, RangeHeaderValue.GetRangeLength);

	internal static readonly GenericHeaderParser RetryConditionParser = new GenericHeaderParser(false, RetryConditionHeaderValue.GetRetryConditionLength);

	internal static readonly GenericHeaderParser ContentRangeParser = new GenericHeaderParser(false, ContentRangeHeaderValue.GetContentRangeLength);

	internal static readonly GenericHeaderParser ContentDispositionParser = new GenericHeaderParser(false, ContentDispositionHeaderValue.GetDispositionTypeLength);

	internal static readonly GenericHeaderParser SingleValueStringWithQualityParser = new GenericHeaderParser(false, StringWithQualityHeaderValue.GetStringWithQualityLength);

	internal static readonly GenericHeaderParser MultipleValueStringWithQualityParser = new GenericHeaderParser(true, StringWithQualityHeaderValue.GetStringWithQualityLength);

	internal static readonly GenericHeaderParser SingleValueEntityTagParser = new GenericHeaderParser(false, ParseSingleEntityTag);

	internal static readonly GenericHeaderParser MultipleValueEntityTagParser = new GenericHeaderParser(true, ParseMultipleEntityTags);

	internal static readonly GenericHeaderParser SingleValueViaParser = new GenericHeaderParser(false, ViaHeaderValue.GetViaLength);

	internal static readonly GenericHeaderParser MultipleValueViaParser = new GenericHeaderParser(true, ViaHeaderValue.GetViaLength);

	internal static readonly GenericHeaderParser SingleValueWarningParser = new GenericHeaderParser(false, WarningHeaderValue.GetWarningLength);

	internal static readonly GenericHeaderParser MultipleValueWarningParser = new GenericHeaderParser(true, WarningHeaderValue.GetWarningLength);

	private readonly GetParsedValueLengthDelegate _getParsedValueLength;

	private readonly IEqualityComparer _comparer;

	public override IEqualityComparer Comparer => _comparer;

	private GenericHeaderParser(bool P_0, GetParsedValueLengthDelegate P_1)
		: this(P_0, P_1, null)
	{
	}

	private GenericHeaderParser(bool P_0, GetParsedValueLengthDelegate P_1, IEqualityComparer P_2)
		: base(P_0)
	{
		_getParsedValueLength = P_1;
		_comparer = P_2;
	}

	protected override int GetParsedValueLength(string P_0, int P_1, object P_2, out object P_3)
	{
		return _getParsedValueLength(P_0, P_1, out P_3);
	}

	private static int ParseNameValue(string P_0, int P_1, out object P_2)
	{
		NameValueHeaderValue nameValueHeaderValue;
		int nameValueLength = NameValueHeaderValue.GetNameValueLength(P_0, P_1, out nameValueHeaderValue);
		P_2 = nameValueHeaderValue;
		return nameValueLength;
	}

	private static int ParseProduct(string P_0, int P_1, out object P_2)
	{
		ProductHeaderValue productHeaderValue;
		int productLength = ProductHeaderValue.GetProductLength(P_0, P_1, out productHeaderValue);
		P_2 = productHeaderValue;
		return productLength;
	}

	private static int ParseSingleEntityTag(string P_0, int P_1, out object P_2)
	{
		P_2 = null;
		EntityTagHeaderValue entityTagHeaderValue;
		int entityTagLength = EntityTagHeaderValue.GetEntityTagLength(P_0, P_1, out entityTagHeaderValue);
		if (entityTagHeaderValue == EntityTagHeaderValue.Any)
		{
			return 0;
		}
		P_2 = entityTagHeaderValue;
		return entityTagLength;
	}

	private static int ParseMultipleEntityTags(string P_0, int P_1, out object P_2)
	{
		EntityTagHeaderValue entityTagHeaderValue;
		int entityTagLength = EntityTagHeaderValue.GetEntityTagLength(P_0, P_1, out entityTagHeaderValue);
		P_2 = entityTagHeaderValue;
		return entityTagLength;
	}

	private static int ParseWithoutValidation(string P_0, int P_1, out object P_2)
	{
		if (HttpRuleParser.ContainsNewLine(P_0, P_1))
		{
			P_2 = null;
			return 0;
		}
		return ((string)(P_2 = P_0.Substring(P_1))).Length;
	}

	private static int ParseHost(string P_0, int P_1, out object P_2)
	{
		int hostLength = HttpRuleParser.GetHostLength(P_0, P_1, false);
		P_2 = P_0.Substring(P_1, hostLength);
		return hostLength;
	}

	private static int ParseTokenList(string P_0, int P_1, out object P_2)
	{
		int tokenLength = HttpRuleParser.GetTokenLength(P_0, P_1);
		P_2 = P_0.Substring(P_1, tokenLength);
		return tokenLength;
	}
}
