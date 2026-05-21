using System.Buffers.Text;

namespace System.Text.Json.Serialization.Converters;

internal sealed class TimeSpanConverter : JsonConverter<TimeSpan>
{
	public override TimeSpan Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType != JsonTokenType.String)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(P_0.TokenType);
		}
		if (!JsonHelpers.IsInRangeInclusive(P_0.ValueLength, 8, 156))
		{
			ThrowHelper.ThrowFormatException(DataType.TimeSpan);
		}
		ReadOnlySpan<byte> readOnlySpan;
		if (!P_0.HasValueSequence && !P_0.ValueIsEscaped)
		{
			readOnlySpan = P_0.ValueSpan;
		}
		else
		{
			Span<byte> span = stackalloc byte[156];
			int num = P_0.CopyString(span);
			readOnlySpan = span.Slice(0, num);
		}
		byte b = readOnlySpan[0];
		if (!JsonHelpers.IsDigit(b) && b != 45)
		{
			ThrowHelper.ThrowFormatException(DataType.TimeSpan);
		}
		if (!Utf8Parser.TryParse(readOnlySpan, out TimeSpan result, out int num2, 'c') || readOnlySpan.Length != num2)
		{
			ThrowHelper.ThrowFormatException(DataType.TimeSpan);
		}
		return result;
	}

	public override void Write(Utf8JsonWriter P_0, TimeSpan P_1, JsonSerializerOptions P_2)
	{
		Span<byte> span = stackalloc byte[26];
		int num;
		bool flag = Utf8Formatter.TryFormat(P_1, span, out num, 'c');
		P_0.WriteStringValue(span.Slice(0, num));
	}
}
