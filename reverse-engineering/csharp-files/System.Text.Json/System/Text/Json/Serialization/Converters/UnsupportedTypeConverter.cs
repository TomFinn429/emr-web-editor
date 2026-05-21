namespace System.Text.Json.Serialization.Converters;

internal sealed class UnsupportedTypeConverter<T> : JsonConverter<T>
{
	public override T Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		throw new NotSupportedException(System.SR.Format("SerializeTypeInstanceNotSupported", typeof(T).FullName));
	}

	public override void Write(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2)
	{
		throw new NotSupportedException(System.SR.Format("SerializeTypeInstanceNotSupported", typeof(T).FullName));
	}
}
