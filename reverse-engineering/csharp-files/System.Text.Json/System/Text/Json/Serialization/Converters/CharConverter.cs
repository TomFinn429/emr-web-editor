using System.Runtime.InteropServices;

namespace System.Text.Json.Serialization.Converters;

internal sealed class CharConverter : JsonConverter<char>
{
	public override char Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (!JsonHelpers.IsInRangeInclusive(P_0.ValueLength, 1, 6))
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedChar(P_0.TokenType);
		}
		Span<char> span = stackalloc char[6];
		int num = P_0.CopyString(span);
		if (num != 1)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedChar(P_0.TokenType);
		}
		return span[0];
	}

	public override void Write(Utf8JsonWriter P_0, char P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteStringValue(MemoryMarshal.CreateSpan(ref P_1, 1));
	}

	internal override char ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return Read(ref P_0, P_1, P_2);
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, char P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(MemoryMarshal.CreateSpan(ref P_1, 1));
	}
}
