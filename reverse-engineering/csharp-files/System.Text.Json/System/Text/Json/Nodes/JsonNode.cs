using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Nodes;

public abstract class JsonNode
{
	private JsonNode _parent;

	private JsonNodeOptions? _options;

	private protected static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions();

	public JsonNodeOptions? Options
	{
		get
		{
			if (!_options.HasValue && Parent != null)
			{
				_options = Parent.Options;
			}
			return _options;
		}
	}

	public JsonNode? Parent
	{
		get
		{
			return _parent;
		}
		internal set
		{
			_parent = parent;
		}
	}

	public JsonNode? this[int P_0]
	{
		get
		{
			return AsArray().GetItem(P_0);
		}
		set
		{
			AsArray().SetItem(num, jsonNode);
		}
	}

	public JsonNode? this[string P_0]
	{
		get
		{
			return AsObject().GetItem(P_0);
		}
		set
		{
			AsObject().SetItem(text, jsonNode);
		}
	}

	internal JsonNode(JsonNodeOptions? P_0 = null)
	{
		_options = P_0;
	}

	public JsonArray AsArray()
	{
		if (this is JsonArray result)
		{
			return result;
		}
		throw new InvalidOperationException(System.SR.Format("NodeWrongType", "JsonArray"));
	}

	public JsonObject AsObject()
	{
		if (this is JsonObject result)
		{
			return result;
		}
		throw new InvalidOperationException(System.SR.Format("NodeWrongType", "JsonObject"));
	}

	public virtual T GetValue<T>()
	{
		throw new InvalidOperationException(System.SR.Format("NodeWrongType", "JsonValue"));
	}

	internal void AssignParent(JsonNode P_0)
	{
		if (Parent != null)
		{
			ThrowHelper.ThrowInvalidOperationException_NodeAlreadyHasParent();
		}
		for (JsonNode jsonNode = P_0; jsonNode != null; jsonNode = jsonNode.Parent)
		{
			if (jsonNode == this)
			{
				ThrowHelper.ThrowInvalidOperationException_NodeCycleDetected();
			}
		}
		Parent = P_0;
	}

	public static implicit operator JsonNode(bool P_0)
	{
		return JsonValue.Create(P_0);
	}

	public static implicit operator JsonNode(DateTime P_0)
	{
		return JsonValue.Create(P_0);
	}

	public static implicit operator JsonNode(double P_0)
	{
		return JsonValue.Create(P_0);
	}

	public static implicit operator JsonNode(int P_0)
	{
		return JsonValue.Create(P_0);
	}

	public static implicit operator JsonNode(float P_0)
	{
		return JsonValue.Create(P_0);
	}

	public static implicit operator JsonNode?(string? P_0)
	{
		return JsonValue.Create(P_0);
	}

	public static JsonNode? Parse([StringSyntax("Json")] string P_0, JsonNodeOptions? P_1 = null, JsonDocumentOptions P_2 = default(JsonDocumentOptions))
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("json");
		}
		JsonElement jsonElement = JsonElement.ParseValue(P_0, P_2);
		return JsonNodeConverter.Create(jsonElement, P_1);
	}

	public string ToJsonString(JsonSerializerOptions? P_0 = null)
	{
		using PooledByteBufferWriter pooledByteBufferWriter = new PooledByteBufferWriter(16384);
		using (Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(pooledByteBufferWriter, P_0?.GetWriterOptions() ?? default(JsonWriterOptions)))
		{
			WriteTo(utf8JsonWriter, P_0);
		}
		return JsonHelpers.Utf8GetString(pooledByteBufferWriter.WrittenMemory.ToArray());
	}

	public override string ToString()
	{
		if (this is JsonValue)
		{
			if (this is JsonValue<string> jsonValue)
			{
				return jsonValue.Value;
			}
			if (this is JsonValue<JsonElement> { Value: { ValueKind: JsonValueKind.String }, Value: var value2 })
			{
				return value2.GetString();
			}
		}
		using PooledByteBufferWriter pooledByteBufferWriter = new PooledByteBufferWriter(16384);
		using (Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(pooledByteBufferWriter, new JsonWriterOptions
		{
			Indented = true
		}))
		{
			WriteTo(utf8JsonWriter);
		}
		return JsonHelpers.Utf8GetString(pooledByteBufferWriter.WrittenMemory.ToArray());
	}

	public abstract void WriteTo(Utf8JsonWriter P_0, JsonSerializerOptions? P_1 = null);
}
