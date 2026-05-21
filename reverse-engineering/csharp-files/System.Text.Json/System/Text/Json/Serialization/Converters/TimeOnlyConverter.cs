using System.Buffers.Text;

namespace System.Text.Json.Serialization.Converters;

internal sealed class TimeOnlyConverter : JsonConverter<TimeOnly>
{
	public override TimeOnly Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType != JsonTokenType.String)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(P_0.TokenType);
		}
		if (!JsonHelpers.IsInRangeInclusive(P_0.ValueLength, 8, 96))
		{
			ThrowHelper.ThrowFormatException(DataType.TimeOnly);
		}
		ReadOnlySpan<byte> readOnlySpan;
		if (!P_0.HasValueSequence && !P_0.ValueIsEscaped)
		{
			readOnlySpan = P_0.ValueSpan;
		}
		else
		{
			Span<byte> span = stackalloc byte[96];
			int num = P_0.CopyString(span);
			readOnlySpan = span.Slice(0, num);
		}
		byte b = readOnlySpan[0];
		int num2 = readOnlySpan.IndexOfAny<byte>(46, 58);
		if (!JsonHelpers.IsDigit(b) || num2 < 0 || readOnlySpan[num2] == 46)
		{
			ThrowHelper.ThrowFormatException(DataType.TimeOnly);
		}
		if (!Utf8Parser.TryParse(readOnlySpan, out TimeSpan timeSpan, out int num3, 'c') || readOnlySpan.Length != num3)
		{
			ThrowHelper.ThrowFormatException(DataType.TimeOnly);
		}
		return TimeOnly.FromTimeSpan(timeSpan);
	}

	public override void Write(Utf8JsonWriter P_0, TimeOnly P_1, JsonSerializerOptions P_2)
	{
		Span<byte> span = stackalloc byte[16];
		int num;
		bool flag = Utf8Formatter.TryFormat(P_1.ToTimeSpan(), span, out num, 'c');
		P_0.WriteStringValue(span.Slice(0, num));
	}
}
