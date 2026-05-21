namespace System.Text.Json;

public readonly struct JsonProperty
{
	public JsonElement Value { get; }

	private string? _name { get; }

	public string Name => _name ?? Value.GetPropertyName();

	internal JsonProperty(JsonElement P_0, string P_1 = null)
	{
		Value = P_0;
		_name = P_1;
	}

	public bool NameEquals(string? P_0)
	{
		return NameEquals(P_0.AsSpan());
	}

	public bool NameEquals(ReadOnlySpan<char> P_0)
	{
		return Value.TextEqualsHelper(P_0, true);
	}

	internal bool EscapedNameEquals(ReadOnlySpan<byte> P_0)
	{
		return Value.TextEqualsHelper(P_0, true, false);
	}

	public override string ToString()
	{
		return Value.GetPropertyRawText();
	}
}
