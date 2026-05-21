using System.Buffers.Text;

namespace System.Text.Json.Serialization.Converters;

internal sealed class BooleanConverter : JsonConverter<bool>
{
	public override bool Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetBoolean();
	}

	public override void Write(Utf8JsonWriter P_0, bool P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteBooleanValue(P_1);
	}

	internal override bool ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		ReadOnlySpan<byte> span = P_0.GetSpan();
		if (!Utf8Parser.TryParse(span, out bool result, out int num, '\0') || span.Length != num)
		{
			ThrowHelper.ThrowFormatException(DataType.Boolean);
		}
		return result;
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, bool P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}
}
