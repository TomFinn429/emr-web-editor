using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace System.Text.Json;

[DefaultMember("Item")]
public readonly struct JsonElement
{
	public struct ArrayEnumerator : IEnumerable<JsonElement>, IEnumerable, IEnumerator<JsonElement>, IEnumerator, IDisposable
	{
		private readonly JsonElement _target;

		private int _curIdx;

		private readonly int _endIdxOrVersion;

		public JsonElement Current
		{
			get
			{
				if (_curIdx < 0)
				{
					return default(JsonElement);
				}
				return new JsonElement(_target._parent, _curIdx);
			}
		}

		object IEnumerator.Current => Current;

		internal ArrayEnumerator(JsonElement P_0)
		{
			_target = P_0;
			_curIdx = -1;
			_endIdxOrVersion = P_0._parent.GetEndIndex(_target._idx, false);
		}

		public ArrayEnumerator GetEnumerator()
		{
			ArrayEnumerator result = this;
			result._curIdx = -1;
			return result;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator<JsonElement> IEnumerable<JsonElement>.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Dispose()
		{
			_curIdx = _endIdxOrVersion;
		}

		public void Reset()
		{
			_curIdx = -1;
		}

		public bool MoveNext()
		{
			if (_curIdx >= _endIdxOrVersion)
			{
				return false;
			}
			if (_curIdx < 0)
			{
				_curIdx = _target._idx + 12;
			}
			else
			{
				_curIdx = _target._parent.GetEndIndex(_curIdx, true);
			}
			return _curIdx < _endIdxOrVersion;
		}
	}

	public struct ObjectEnumerator : IEnumerable<JsonProperty>, IEnumerable, IEnumerator<JsonProperty>, IEnumerator, IDisposable
	{
		private readonly JsonElement _target;

		private int _curIdx;

		private readonly int _endIdxOrVersion;

		public JsonProperty Current
		{
			get
			{
				if (_curIdx < 0)
				{
					return default(JsonProperty);
				}
				return new JsonProperty(new JsonElement(_target._parent, _curIdx));
			}
		}

		object IEnumerator.Current => Current;

		internal ObjectEnumerator(JsonElement P_0)
		{
			_target = P_0;
			_curIdx = -1;
			_endIdxOrVersion = P_0._parent.GetEndIndex(_target._idx, false);
		}

		public ObjectEnumerator GetEnumerator()
		{
			ObjectEnumerator result = this;
			result._curIdx = -1;
			return result;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator<JsonProperty> IEnumerable<JsonProperty>.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Dispose()
		{
			_curIdx = _endIdxOrVersion;
		}

		public void Reset()
		{
			_curIdx = -1;
		}

		public bool MoveNext()
		{
			if (_curIdx >= _endIdxOrVersion)
			{
				return false;
			}
			if (_curIdx < 0)
			{
				_curIdx = _target._idx + 12;
			}
			else
			{
				_curIdx = _target._parent.GetEndIndex(_curIdx, true);
			}
			_curIdx += 12;
			return _curIdx < _endIdxOrVersion;
		}
	}

	private readonly JsonDocument _parent;

	private readonly int _idx;

	private JsonTokenType TokenType => _parent?.GetJsonTokenType(_idx) ?? JsonTokenType.None;

	public JsonValueKind ValueKind => TokenType.ToValueKind();

	internal JsonElement(JsonDocument P_0, int P_1)
	{
		_parent = P_0;
		_idx = P_1;
	}

	public int GetArrayLength()
	{
		CheckValidInstance();
		return _parent.GetArrayLength(_idx);
	}

	public JsonElement GetProperty(string P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		if (TryGetProperty(P_0, out var result))
		{
			return result;
		}
		throw new KeyNotFoundException();
	}

	public bool TryGetProperty(string P_0, out JsonElement P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		return TryGetProperty(P_0.AsSpan(), out P_1);
	}

	public bool TryGetProperty(ReadOnlySpan<char> P_0, out JsonElement P_1)
	{
		CheckValidInstance();
		return _parent.TryGetNamedPropertyValue(_idx, P_0, out P_1);
	}

	public bool GetBoolean()
	{
		JsonTokenType tokenType = TokenType;
		return tokenType switch
		{
			JsonTokenType.False => false, 
			JsonTokenType.True => true, 
			_ => ThrowJsonElementWrongTypeException(tokenType), 
		};
		static bool ThrowJsonElementWrongTypeException(JsonTokenType P_0)
		{
			throw ThrowHelper.GetJsonElementWrongTypeException("Boolean", P_0.ToValueKind());
		}
	}

	public string? GetString()
	{
		CheckValidInstance();
		return _parent.GetString(_idx, JsonTokenType.String);
	}

	[CLSCompliant(false)]
	public bool TryGetSByte(out sbyte P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	[CLSCompliant(false)]
	public sbyte GetSByte()
	{
		if (TryGetSByte(out var result))
		{
			return result;
		}
		throw new FormatException();
	}

	public bool TryGetByte(out byte P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	public byte GetByte()
	{
		if (TryGetByte(out var result))
		{
			return result;
		}
		throw new FormatException();
	}

	public bool TryGetInt16(out short P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	public short GetInt16()
	{
		if (TryGetInt16(out var result))
		{
			return result;
		}
		throw new FormatException();
	}

	[CLSCompliant(false)]
	public bool TryGetUInt16(out ushort P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	[CLSCompliant(false)]
	public ushort GetUInt16()
	{
		if (TryGetUInt16(out var result))
		{
			return result;
		}
		throw new FormatException();
	}

	public bool TryGetInt32(out int P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	public int GetInt32()
	{
		if (!TryGetInt32(out var result))
		{
			ThrowHelper.ThrowFormatException();
		}
		return result;
	}

	[CLSCompliant(false)]
	public bool TryGetUInt32(out uint P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	[CLSCompliant(false)]
	public uint GetUInt32()
	{
		if (!TryGetUInt32(out var result))
		{
			ThrowHelper.ThrowFormatException();
		}
		return result;
	}

	public bool TryGetInt64(out long P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	public long GetInt64()
	{
		if (!TryGetInt64(out var result))
		{
			ThrowHelper.ThrowFormatException();
		}
		return result;
	}

	[CLSCompliant(false)]
	public bool TryGetUInt64(out ulong P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	[CLSCompliant(false)]
	public ulong GetUInt64()
	{
		if (!TryGetUInt64(out var result))
		{
			ThrowHelper.ThrowFormatException();
		}
		return result;
	}

	public bool TryGetDouble(out double P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	public double GetDouble()
	{
		if (!TryGetDouble(out var result))
		{
			ThrowHelper.ThrowFormatException();
		}
		return result;
	}

	public bool TryGetSingle(out float P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	public float GetSingle()
	{
		if (!TryGetSingle(out var result))
		{
			ThrowHelper.ThrowFormatException();
		}
		return result;
	}

	public bool TryGetDecimal(out decimal P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	public decimal GetDecimal()
	{
		if (!TryGetDecimal(out var result))
		{
			ThrowHelper.ThrowFormatException();
		}
		return result;
	}

	public bool TryGetDateTime(out DateTime P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	public DateTime GetDateTime()
	{
		if (!TryGetDateTime(out var result))
		{
			ThrowHelper.ThrowFormatException();
		}
		return result;
	}

	public bool TryGetDateTimeOffset(out DateTimeOffset P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	public DateTimeOffset GetDateTimeOffset()
	{
		if (!TryGetDateTimeOffset(out var result))
		{
			ThrowHelper.ThrowFormatException();
		}
		return result;
	}

	public bool TryGetGuid(out Guid P_0)
	{
		CheckValidInstance();
		return _parent.TryGetValue(_idx, out P_0);
	}

	public Guid GetGuid()
	{
		if (!TryGetGuid(out var result))
		{
			ThrowHelper.ThrowFormatException();
		}
		return result;
	}

	internal string GetPropertyName()
	{
		CheckValidInstance();
		return _parent.GetNameOfPropertyValue(_idx);
	}

	internal string GetPropertyRawText()
	{
		CheckValidInstance();
		return _parent.GetPropertyRawValueAsString(_idx);
	}

	internal bool TextEqualsHelper(ReadOnlySpan<byte> P_0, bool P_1, bool P_2)
	{
		CheckValidInstance();
		return _parent.TextEquals(_idx, P_0, P_1, P_2);
	}

	internal bool TextEqualsHelper(ReadOnlySpan<char> P_0, bool P_1)
	{
		CheckValidInstance();
		return _parent.TextEquals(_idx, P_0, P_1);
	}

	public void WriteTo(Utf8JsonWriter P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("writer");
		}
		CheckValidInstance();
		_parent.WriteElementTo(_idx, P_0);
	}

	public ArrayEnumerator EnumerateArray()
	{
		CheckValidInstance();
		JsonTokenType tokenType = TokenType;
		if (tokenType != JsonTokenType.StartArray)
		{
			ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartArray, tokenType);
		}
		return new ArrayEnumerator(this);
	}

	public ObjectEnumerator EnumerateObject()
	{
		CheckValidInstance();
		JsonTokenType tokenType = TokenType;
		if (tokenType != JsonTokenType.StartObject)
		{
			ThrowHelper.ThrowJsonElementWrongTypeException(JsonTokenType.StartObject, tokenType);
		}
		return new ObjectEnumerator(this);
	}

	public override string ToString()
	{
		switch (TokenType)
		{
		case JsonTokenType.None:
		case JsonTokenType.Null:
			return string.Empty;
		case JsonTokenType.True:
			return bool.TrueString;
		case JsonTokenType.False:
			return bool.FalseString;
		case JsonTokenType.StartObject:
		case JsonTokenType.StartArray:
		case JsonTokenType.Number:
			return _parent.GetRawValueAsString(_idx);
		case JsonTokenType.String:
			return GetString();
		default:
			return string.Empty;
		}
	}

	private void CheckValidInstance()
	{
		if (_parent == null)
		{
			throw new InvalidOperationException();
		}
	}

	public static JsonElement ParseValue(ref Utf8JsonReader P_0)
	{
		JsonDocument jsonDocument;
		bool flag = JsonDocument.TryParseValue(ref P_0, out jsonDocument, true, false);
		return jsonDocument.RootElement;
	}

	internal static JsonElement ParseValue(ReadOnlySpan<byte> P_0, JsonDocumentOptions P_1)
	{
		JsonDocument jsonDocument = JsonDocument.ParseValue(P_0, P_1);
		return jsonDocument.RootElement;
	}

	internal static JsonElement ParseValue(string P_0, JsonDocumentOptions P_1)
	{
		JsonDocument jsonDocument = JsonDocument.ParseValue(P_0, P_1);
		return jsonDocument.RootElement;
	}
}
