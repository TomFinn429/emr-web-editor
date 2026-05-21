using System.Globalization;

namespace System.Text.Json.Serialization.Converters;

internal sealed class DateOnlyConverter : JsonConverter<DateOnly>
{
	public override DateOnly Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType != JsonTokenType.String)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(P_0.TokenType);
		}
		return ReadCore(ref P_0);
	}

	internal override DateOnly ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return ReadCore(ref P_0);
	}

	private DateOnly ReadCore(ref Utf8JsonReader P_0)
	{
		if (!JsonHelpers.IsInRangeInclusive(P_0.ValueLength, 10, 60))
		{
			ThrowHelper.ThrowFormatException(DataType.DateOnly);
		}
		ReadOnlySpan<byte> readOnlySpan;
		if (!P_0.HasValueSequence && !P_0.ValueIsEscaped)
		{
			readOnlySpan = P_0.ValueSpan;
		}
		else
		{
			Span<byte> span = stackalloc byte[60];
			int num = P_0.CopyString(span);
			readOnlySpan = span.Slice(0, num);
		}
		if (!JsonHelpers.TryParseAsIso(readOnlySpan, out var result))
		{
			ThrowHelper.ThrowFormatException(DataType.DateOnly);
		}
		return result;
	}

	public override void Write(Utf8JsonWriter P_0, DateOnly P_1, JsonSerializerOptions P_2)
	{
		Span<char> span = stackalloc char[10];
		int num;
		bool flag = P_1.TryFormat(span, out num, "O", CultureInfo.InvariantCulture);
		P_0.WriteStringValue(span);
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, DateOnly P_1, JsonSerializerOptions P_2, bool P_3)
	{
		Span<char> span = stackalloc char[10];
		int num;
		bool flag = P_1.TryFormat(span, out num, "O", CultureInfo.InvariantCulture);
		P_0.WritePropertyName(span);
	}
}
