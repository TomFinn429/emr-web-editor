using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonValueConverter : JsonConverter<JsonValue>
{
	public override void Write(Utf8JsonWriter P_0, JsonValue P_1, JsonSerializerOptions P_2)
	{
		P_1.WriteTo(P_0, P_2);
	}

	public override JsonValue Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		JsonElement jsonElement = JsonElement.ParseValue(ref P_0);
		return new JsonValueTrimmable<JsonElement>(jsonElement, JsonMetadataServices.JsonElementConverter, P_2.GetNodeOptions());
	}
}
