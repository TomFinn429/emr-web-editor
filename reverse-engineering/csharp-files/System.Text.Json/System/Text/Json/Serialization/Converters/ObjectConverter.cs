using System.Text.Json.Nodes;

namespace System.Text.Json.Serialization.Converters;

internal sealed class ObjectConverter : JsonConverter<object>
{
	internal override ConverterStrategy ConverterStrategy => ConverterStrategy.Object;

	public ObjectConverter()
	{
		base.CanBePolymorphic = true;
		base.RequiresReadAhead = true;
	}

	public override object Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (P_2.UnknownTypeHandling == JsonUnknownTypeHandling.JsonElement)
		{
			return JsonElement.ParseValue(ref P_0);
		}
		return JsonNodeConverter.Instance.Read(ref P_0, P_1, P_2);
	}

	public override void Write(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteStartObject();
		P_0.WriteEndObject();
	}

	internal override bool OnTryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, out object P_4)
	{
		object obj;
		if (P_2.UnknownTypeHandling == JsonUnknownTypeHandling.JsonElement)
		{
			JsonElement jsonElement = JsonElement.ParseValue(ref P_0);
			if (P_2.ReferenceHandlingStrategy == ReferenceHandlingStrategy.Preserve && JsonSerializer.TryHandleReferenceFromJsonElement(ref P_0, ref P_3, jsonElement, out obj))
			{
				P_4 = obj;
			}
			else
			{
				P_4 = jsonElement;
			}
			return true;
		}
		JsonNode jsonNode = JsonNodeConverter.Instance.Read(ref P_0, P_1, P_2);
		if (P_2.ReferenceHandlingStrategy == ReferenceHandlingStrategy.Preserve && JsonSerializer.TryHandleReferenceFromJsonNode(ref P_0, ref P_3, jsonNode, out obj))
		{
			P_4 = obj;
		}
		else
		{
			P_4 = jsonNode;
		}
		return true;
	}

	internal override object ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		ThrowHelper.ThrowNotSupportedException_DictionaryKeyTypeNotSupported(TypeToConvert, this);
		return null;
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, bool P_3)
	{
		Type type = P_1.GetType();
		JsonConverter converterInternal = P_2.GetConverterInternal(type);
		if (converterInternal == this)
		{
			ThrowHelper.ThrowNotSupportedException_DictionaryKeyTypeNotSupported(type, this);
		}
		converterInternal.WriteAsPropertyNameCoreAsObject(P_0, P_1, P_2, P_3);
	}
}
