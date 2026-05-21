using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Nodes;

public sealed class JsonArray : JsonNode, IList<JsonNode?>, ICollection<JsonNode?>, IEnumerable<JsonNode?>, IEnumerable
{
	private JsonElement? _jsonElement;

	private List<JsonNode> _list;

	internal List<JsonNode?> List
	{
		get
		{
			CreateNodes();
			return _list;
		}
	}

	public int Count => List.Count;

	bool ICollection<JsonNode>.IsReadOnly => false;

	public JsonArray(JsonNodeOptions? P_0 = null)
		: base(P_0)
	{
	}

	public JsonArray(params JsonNode?[] P_0)
	{
		InitializeFromArray(P_0);
	}

	private void InitializeFromArray(JsonNode[] P_0)
	{
		List<JsonNode> list = new List<JsonNode>(P_0);
		for (int i = 0; i < P_0.Length; i++)
		{
			P_0[i]?.AssignParent(this);
		}
		_list = list;
	}

	internal JsonArray(JsonElement P_0, JsonNodeOptions? P_1 = null)
		: base(P_1)
	{
		_jsonElement = P_0;
	}

	[RequiresUnreferencedCode("Creating JsonValue instances with non-primitive types is not compatible with trimming. It can result in non-primitive types being serialized, which may have their members trimmed.")]
	[RequiresDynamicCode("Creating JsonValue instances with non-primitive types requires generating code at runtime.")]
	public void Add<T>(T? P_0)
	{
		if (P_0 == null)
		{
			Add(null);
			return;
		}
		JsonNode jsonNode = (P_0 as JsonNode) ?? new JsonValueNotTrimmable<T>(P_0);
		Add(jsonNode);
	}

	internal JsonNode GetItem(int P_0)
	{
		return List[P_0];
	}

	internal void SetItem(int P_0, JsonNode P_1)
	{
		P_1?.AssignParent(this);
		DetachParent(List[P_0]);
		List[P_0] = P_1;
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
		CreateNodes();
		if (P_1 == null)
		{
			P_1 = JsonNode.s_defaultOptions;
		}
		P_0.WriteStartArray();
		for (int i = 0; i < _list.Count; i++)
		{
			JsonNodeConverter.Instance.Write(P_0, _list[i], P_1);
		}
		P_0.WriteEndArray();
	}

	private void CreateNodes()
	{
		if (_list != null)
		{
			return;
		}
		List<JsonNode> list;
		if (!_jsonElement.HasValue)
		{
			list = new List<JsonNode>();
		}
		else
		{
			JsonElement value = _jsonElement.Value;
			list = new List<JsonNode>(value.GetArrayLength());
			foreach (JsonElement item in value.EnumerateArray())
			{
				JsonNode jsonNode = JsonNodeConverter.Create(item, base.Options);
				jsonNode?.AssignParent(this);
				list.Add(jsonNode);
			}
			_jsonElement = null;
		}
		_list = list;
	}

	public void Add(JsonNode? P_0)
	{
		P_0?.AssignParent(this);
		List.Add(P_0);
	}

	public void Clear()
	{
		for (int i = 0; i < List.Count; i++)
		{
			DetachParent(List[i]);
		}
		List.Clear();
	}

	public bool Contains(JsonNode? P_0)
	{
		return List.Contains(P_0);
	}

	public int IndexOf(JsonNode? P_0)
	{
		return List.IndexOf(P_0);
	}

	public void Insert(int P_0, JsonNode? P_1)
	{
		P_1?.AssignParent(this);
		List.Insert(P_0, P_1);
	}

	public bool Remove(JsonNode? P_0)
	{
		if (List.Remove(P_0))
		{
			DetachParent(P_0);
			return true;
		}
		return false;
	}

	public void RemoveAt(int P_0)
	{
		JsonNode jsonNode = List[P_0];
		List.RemoveAt(P_0);
		DetachParent(jsonNode);
	}

	void ICollection<JsonNode>.CopyTo(JsonNode[] P_0, int P_1)
	{
		List.CopyTo(P_0, P_1);
	}

	public IEnumerator<JsonNode?> GetEnumerator()
	{
		return List.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)List).GetEnumerator();
	}

	private static void DetachParent(JsonNode P_0)
	{
		if (P_0 != null)
		{
			P_0.Parent = null;
		}
	}
}
