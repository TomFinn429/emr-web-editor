namespace System.Text.Json.Serialization.Converters;

internal sealed class VersionConverter : JsonConverter<Version>
{
	public override Version Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType != JsonTokenType.String)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(P_0.TokenType);
		}
		if (!JsonHelpers.IsInRangeInclusive(P_0.ValueLength, 3, 258))
		{
			ThrowHelper.ThrowFormatException(DataType.TimeSpan);
		}
		Span<char> span = stackalloc char[258];
		int num = P_0.CopyString(span);
		ReadOnlySpan<char> readOnlySpan = span.Slice(0, num);
		if (char.IsDigit(readOnlySpan[0]))
		{
			if (char.IsDigit(readOnlySpan[readOnlySpan.Length - 1]))
			{
				goto IL_0088;
			}
		}
		ThrowHelper.ThrowFormatException(DataType.Version);
		goto IL_0088;
		IL_0088:
		if (Version.TryParse(readOnlySpan, out Version result))
		{
			return result;
		}
		ThrowHelper.ThrowJsonException();
		return null;
	}

	public override void Write(Utf8JsonWriter P_0, Version P_1, JsonSerializerOptions P_2)
	{
		Span<char> span = stackalloc char[43];
		int num;
		bool flag = P_1.TryFormat(span, out num);
		P_0.WriteStringValue(span.Slice(0, num));
	}
}
