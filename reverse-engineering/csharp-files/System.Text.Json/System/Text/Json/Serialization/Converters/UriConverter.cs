namespace System.Text.Json.Serialization.Converters;

internal sealed class UriConverter : JsonConverter<Uri>
{
	public override Uri Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		string text = P_0.GetString();
		if (Uri.TryCreate(text, UriKind.RelativeOrAbsolute, out Uri result))
		{
			return result;
		}
		ThrowHelper.ThrowJsonException();
		return null;
	}

	public override void Write(Utf8JsonWriter P_0, Uri P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteStringValue(P_1.OriginalString);
	}
}
