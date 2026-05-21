namespace System.Net.Http.Headers;

internal abstract class BaseHeaderParser : HttpHeaderParser
{
	protected BaseHeaderParser(bool P_0)
		: base(P_0)
	{
	}

	protected abstract int GetParsedValueLength(string P_0, int P_1, object P_2, out object P_3);

	public sealed override bool TryParseValue(string P_0, object P_1, ref int P_2, out object P_3)
	{
		P_3 = null;
		if (string.IsNullOrEmpty(P_0) || P_2 == P_0.Length)
		{
			return base.SupportsMultipleValues;
		}
		int nextNonEmptyOrWhitespaceIndex = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(P_0, P_2, base.SupportsMultipleValues, out var flag);
		if (flag && !base.SupportsMultipleValues)
		{
			return false;
		}
		if (nextNonEmptyOrWhitespaceIndex == P_0.Length)
		{
			if (base.SupportsMultipleValues)
			{
				P_2 = nextNonEmptyOrWhitespaceIndex;
			}
			return base.SupportsMultipleValues;
		}
		object obj;
		int parsedValueLength = GetParsedValueLength(P_0, nextNonEmptyOrWhitespaceIndex, P_1, out obj);
		if (parsedValueLength == 0)
		{
			return false;
		}
		nextNonEmptyOrWhitespaceIndex += parsedValueLength;
		nextNonEmptyOrWhitespaceIndex = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(P_0, nextNonEmptyOrWhitespaceIndex, base.SupportsMultipleValues, out flag);
		if ((flag && !base.SupportsMultipleValues) || (!flag && nextNonEmptyOrWhitespaceIndex < P_0.Length))
		{
			return false;
		}
		P_2 = nextNonEmptyOrWhitespaceIndex;
		P_3 = obj;
		return true;
	}
}
