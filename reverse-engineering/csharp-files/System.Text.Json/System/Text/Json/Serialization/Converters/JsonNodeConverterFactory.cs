using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonNodeConverterFactory : JsonConverterFactory
{
	public override JsonConverter CreateConverter(Type P_0, JsonSerializerOptions P_1)
	{
		if (typeof(JsonValue).IsAssignableFrom(P_0))
		{
			return JsonNodeConverter.ValueConverter;
		}
		if (typeof(JsonObject) == P_0)
		{
			return JsonNodeConverter.ObjectConverter;
		}
		if (typeof(JsonArray) == P_0)
		{
			return JsonNodeConverter.ArrayConverter;
		}
		return JsonNodeConverter.Instance;
	}

	public override bool CanConvert(Type P_0)
	{
		if (P_0 != JsonTypeInfo.ObjectType)
		{
			return typeof(JsonNode).IsAssignableFrom(P_0);
		}
		return false;
	}
}
