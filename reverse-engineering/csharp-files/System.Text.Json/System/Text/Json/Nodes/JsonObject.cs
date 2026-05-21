using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Nodes;

public sealed class JsonObject : JsonNode, IDictionary<string, JsonNode?>, ICollection<KeyValuePair<string, JsonNode?>>, IEnumerable<KeyValuePair<string, JsonNode?>>, IEnumerable
{
	private JsonElement? _jsonElement;

	private JsonPropertyDictionary<JsonNode> _dictionary;

	public int Count
	{
		get
		{
			InitializeIfRequired();
			return _dictionary.Count;
		}
	}

	ICollection<string> IDictionary<string, JsonNode>.Keys
	{
		get
		{
			InitializeIfRequired();
			return _dictionary.Keys;
		}
	}

	ICollection<JsonNode?> IDictionary<string, JsonNode>.Values
	{
		get
		{
			InitializeIfRequired();
			return _dictionary.Values;
		}
	}

	bool ICollection<KeyValuePair<string, JsonNode>>.IsReadOnly => false;

	public JsonObject(JsonNodeOptions? P_0 = null)
		: base(P_0)
	{
	}

	internal JsonObject(JsonElement P_0, JsonNodeOptions? P_1 = null)
		: this(P_1)
	{
		_jsonElement = P_0;
	}

	public bool TryGetPropertyValue(string P_0, out JsonNode? P_1)
	{
		return ((IDictionary<string, JsonNode>)this).TryGetValue(P_0, out P_1);
	}

	public override void WriteTo(Utf8JsonWriter P_0, JsonSerializerOptions? P_1 = null)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("writer");
		}
		if (_jsonElement.HasValue)
		{
			_jsonElement.Value.WriteTo(P_0);
			return;
		}
		if (P_1 == null)
		{
			P_1 = JsonNode.s_defaultOptions;
		}
		P_0.WriteStartObject();
		using (IEnumerator<KeyValuePair<string, JsonNode>> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, JsonNode> current = enumerator.Current;
				P_0.WritePropertyName(current.Key);
				JsonNodeConverter.Instance.Write(P_0, current.Value, P_1);
			}
		}
		P_0.WriteEndObject();
	}

	internal JsonNode GetItem(string P_0)
	{
		if (TryGetPropertyValue(P_0, out JsonNode result))
		{
			return result;
		}
		return null;
	}

	internal void SetItem(string P_0, JsonNode P_1)
	{
		InitializeIfRequired();
		JsonNode jsonNode = _dictionary.SetValue(P_0, P_1, delegate
		{
			P_1?.AssignParent(this);
		});
		DetachParent(jsonNode);
	}

	private void DetachParent(JsonNode P_0)
	{
		InitializeIfRequired();
		if (P_0 != null)
		{
			P_0.Parent = null;
		}
	}

	public void Add(string P_0, JsonNode? P_1)
	{
		InitializeIfRequired();
		_dictionary.Add(P_0, P_1);
		P_1?.AssignParent(this);
	}

	public void Add(KeyValuePair<string, JsonNode?> P_0)
	{
		Add(P_0.Key, P_0.Value);
	}

	public void Clear()
	{
		if (_jsonElement.HasValue)
		{
			_jsonElement = null;
		}
		else
		{
			if (_dictionary == null)
			{
				return;
			}
			foreach (JsonNode item in _dictionary.GetValueCollection())
			{
				DetachParent(item);
			}
			_dictionary.Clear();
		}
	}

	public bool ContainsKey(string P_0)
	{
		InitializeIfRequired();
		return _dictionary.ContainsKey(P_0);
	}

	public bool Remove(string P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		InitializeIfRequired();
		JsonNode jsonNode;
		bool flag = _dictionary.TryRemoveProperty(P_0, out jsonNode);
		if (flag)
		{
			DetachParent(jsonNode);
		}
		return flag;
	}

	bool ICollection<KeyValuePair<string, JsonNode>>.Contains(KeyValuePair<string, JsonNode> P_0)
	{
		InitializeIfRequired();
		return _dictionary.Contains(P_0);
	}

	void ICollection<KeyValuePair<string, JsonNode>>.CopyTo(KeyValuePair<string, JsonNode>[] P_0, int P_1)
	{
		InitializeIfRequired();
		_dictionary.CopyTo(P_0, P_1);
	}

	public IEnumerator<KeyValuePair<string, JsonNode?>> GetEnumerator()
	{
		InitializeIfRequired();
		return _dictionary.GetEnumerator();
	}

	bool ICollection<KeyValuePair<string, JsonNode>>.Remove(KeyValuePair<string, JsonNode> P_0)
	{
		return Remove(P_0.Key);
	}

	bool IDictionary<string, JsonNode>.TryGetValue(string P_0, out JsonNode P_1)
	{
		InitializeIfRequired();
		return _dictionary.TryGetValue(P_0, out P_1);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		InitializeIfRequired();
		return _dictionary.GetEnumerator();
	}

	private void InitializeIfRequired()
	{
		if (_dictionary != null)
		{
			return;
		}
		bool flag = base.Options.HasValue && base.Options.Value.PropertyNameCaseInsensitive;
		JsonPropertyDictionary<JsonNode> jsonPropertyDictionary = new JsonPropertyDictionary<JsonNode>(flag);
		if (_jsonElement.HasValue)
		{
			foreach (JsonProperty item in _jsonElement.Value.EnumerateObject())
			{
				JsonNode jsonNode = JsonNodeConverter.Create(item.Value, base.Options);
				if (jsonNode != null)
				{
					jsonNode.Parent = this;
				}
				jsonPropertyDictionary.Add(new KeyValuePair<string, JsonNode>(item.Name, jsonNode));
			}
			_jsonElement = null;
		}
		_dictionary = jsonPropertyDictionary;
	}
}
