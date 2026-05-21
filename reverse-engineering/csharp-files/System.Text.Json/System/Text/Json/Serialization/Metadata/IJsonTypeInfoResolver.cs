namespace System.Text.Json.Serialization.Metadata;

public interface IJsonTypeInfoResolver
{
	JsonTypeInfo? GetTypeInfo(Type P_0, JsonSerializerOptions P_1);
}
