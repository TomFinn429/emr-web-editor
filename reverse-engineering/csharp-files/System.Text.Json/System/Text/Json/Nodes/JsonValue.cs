using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Nodes;

public abstract class JsonValue : JsonNode
{
	public static JsonValue Create(bool P_0, JsonNodeOptions? P_1 = null)
	{
		return new JsonValueTrimmable<bool>(P_0, JsonMetadataServices.BooleanConverter);
	}

	public static JsonValue Create(DateTime P_0, JsonNodeOptions? P_1 = null)
	{
		return new JsonValueTrimmable<DateTime>(P_0, JsonMetadataServices.DateTimeConverter);
	}

	public static JsonValue Create(double P_0, JsonNodeOptions? P_1 = null)
	{
		return new JsonValueTrimmable<double>(P_0, JsonMetadataServices.DoubleConverter);
	}

	public static JsonValue Create(int P_0, JsonNodeOptions? P_1 = null)
	{
		return new JsonValueTrimmable<int>(P_0, JsonMetadataServices.Int32Converter);
	}

	public static JsonValue Create(float P_0, JsonNodeOptions? P_1 = null)
	{
		return new JsonValueTrimmable<float>(P_0, JsonMetadataServices.SingleConverter);
	}

	public static JsonValue? Create(string? P_0, JsonNodeOptions? P_1 = null)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new JsonValueTrimmable<string>(P_0, JsonMetadataServices.StringConverter);
	}

	private protected JsonValue(JsonNodeOptions? P_0 = null)
		: base(P_0)
	{
	}

	public abstract bool TryGetValue<T>([NotNullWhen(true)] out T? P_0);
}
internal abstract class JsonValue<TValue> : JsonValue
{
	public readonly TValue _value;

	public TValue Value => _value;

	public JsonValue(TValue P_0, JsonNodeOptions? P_1 = null)
		: base(P_1)
	{
		if (P_0 is JsonNode)
		{
			ThrowHelper.ThrowArgumentException_NodeValueNotAllowed("value");
		}
		_value = P_0;
	}

	public override T GetValue<T>()
	{
		TValue value = _value;
		if (value is T)
		{
			object obj = value;
			return (T)((obj is T) ? obj : null);
		}
		if (_value is JsonElement)
		{
			return ConvertJsonElement<T>();
		}
		throw new InvalidOperationException(System.SR.Format("NodeUnableToConvert", _value.GetType(), typeof(T)));
	}

	public override bool TryGetValue<T>([NotNullWhen(true)] out T P_0)
	{
		TValue value = _value;
		if (value is T val)
		{
			P_0 = val;
			return true;
		}
		if (_value is JsonElement)
		{
			return TryConvertJsonElement<T>(out P_0);
		}
		P_0 = default(T);
		return false;
	}

	internal TypeToConvert ConvertJsonElement<TypeToConvert>()
	{
		JsonElement jsonElement = (JsonElement)(object)_value;
		switch (jsonElement.ValueKind)
		{
		case JsonValueKind.Number:
			if (typeof(TypeToConvert) == typeof(int) || typeof(TypeToConvert) == typeof(int?))
			{
				return (TypeToConvert)(object)jsonElement.GetInt32();
			}
			if (typeof(TypeToConvert) == typeof(long) || typeof(TypeToConvert) == typeof(long?))
			{
				return (TypeToConvert)(object)jsonElement.GetInt64();
			}
			if (typeof(TypeToConvert) == typeof(double) || typeof(TypeToConvert) == typeof(double?))
			{
				return (TypeToConvert)(object)jsonElement.GetDouble();
			}
			if (typeof(TypeToConvert) == typeof(short) || typeof(TypeToConvert) == typeof(short?))
			{
				return (TypeToConvert)(object)jsonElement.GetInt16();
			}
			if (typeof(TypeToConvert) == typeof(decimal) || typeof(TypeToConvert) == typeof(decimal?))
			{
				return (TypeToConvert)(object)jsonElement.GetDecimal();
			}
			if (typeof(TypeToConvert) == typeof(byte) || typeof(TypeToConvert) == typeof(byte?))
			{
				return (TypeToConvert)(object)jsonElement.GetByte();
			}
			if (typeof(TypeToConvert) == typeof(float) || typeof(TypeToConvert) == typeof(float?))
			{
				return (TypeToConvert)(object)jsonElement.GetSingle();
			}
			if (typeof(TypeToConvert) == typeof(uint) || typeof(TypeToConvert) == typeof(uint?))
			{
				return (TypeToConvert)(object)jsonElement.GetUInt32();
			}
			if (typeof(TypeToConvert) == typeof(ushort) || typeof(TypeToConvert) == typeof(ushort?))
			{
				return (TypeToConvert)(object)jsonElement.GetUInt16();
			}
			if (typeof(TypeToConvert) == typeof(ulong) || typeof(TypeToConvert) == typeof(ulong?))
			{
				return (TypeToConvert)(object)jsonElement.GetUInt64();
			}
			if (typeof(TypeToConvert) == typeof(sbyte) || typeof(TypeToConvert) == typeof(sbyte?))
			{
				return (TypeToConvert)(object)jsonElement.GetSByte();
			}
			break;
		case JsonValueKind.String:
			if (typeof(TypeToConvert) == typeof(string))
			{
				return (TypeToConvert)(object)jsonElement.GetString();
			}
			if (typeof(TypeToConvert) == typeof(DateTime) || typeof(TypeToConvert) == typeof(DateTime?))
			{
				return (TypeToConvert)(object)jsonElement.GetDateTime();
			}
			if (typeof(TypeToConvert) == typeof(DateTimeOffset) || typeof(TypeToConvert) == typeof(DateTimeOffset?))
			{
				return (TypeToConvert)(object)jsonElement.GetDateTimeOffset();
			}
			if (typeof(TypeToConvert) == typeof(Guid) || typeof(TypeToConvert) == typeof(Guid?))
			{
				return (TypeToConvert)(object)jsonElement.GetGuid();
			}
			if (typeof(TypeToConvert) == typeof(char) || typeof(TypeToConvert) == typeof(char?))
			{
				string text = jsonElement.GetString();
				if (text.Length == 1)
				{
					return (TypeToConvert)(object)text[0];
				}
			}
			break;
		case JsonValueKind.True:
		case JsonValueKind.False:
			if (typeof(TypeToConvert) == typeof(bool) || typeof(TypeToConvert) == typeof(bool?))
			{
				return (TypeToConvert)(object)jsonElement.GetBoolean();
			}
			break;
		}
		throw new InvalidOperationException(System.SR.Format("NodeUnableToConvertElement", jsonElement.ValueKind, typeof(TypeToConvert)));
	}

	internal bool TryConvertJsonElement<TypeToConvert>([NotNullWhen(true)] out TypeToConvert P_0)
	{
		JsonElement jsonElement = (JsonElement)(object)_value;
		switch (jsonElement.ValueKind)
		{
		case JsonValueKind.Number:
			if (typeof(TypeToConvert) == typeof(int) || typeof(TypeToConvert) == typeof(int?))
			{
				int num;
				bool result = jsonElement.TryGetInt32(out num);
				P_0 = (TypeToConvert)(object)num;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(long) || typeof(TypeToConvert) == typeof(long?))
			{
				long num2;
				bool result = jsonElement.TryGetInt64(out num2);
				P_0 = (TypeToConvert)(object)num2;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(double) || typeof(TypeToConvert) == typeof(double?))
			{
				double num3;
				bool result = jsonElement.TryGetDouble(out num3);
				P_0 = (TypeToConvert)(object)num3;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(short) || typeof(TypeToConvert) == typeof(short?))
			{
				short num4;
				bool result = jsonElement.TryGetInt16(out num4);
				P_0 = (TypeToConvert)(object)num4;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(decimal) || typeof(TypeToConvert) == typeof(decimal?))
			{
				decimal num5;
				bool result = jsonElement.TryGetDecimal(out num5);
				P_0 = (TypeToConvert)(object)num5;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(byte) || typeof(TypeToConvert) == typeof(byte?))
			{
				byte b;
				bool result = jsonElement.TryGetByte(out b);
				P_0 = (TypeToConvert)(object)b;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(float) || typeof(TypeToConvert) == typeof(float?))
			{
				float num6;
				bool result = jsonElement.TryGetSingle(out num6);
				P_0 = (TypeToConvert)(object)num6;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(uint) || typeof(TypeToConvert) == typeof(uint?))
			{
				uint num7;
				bool result = jsonElement.TryGetUInt32(out num7);
				P_0 = (TypeToConvert)(object)num7;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(ushort) || typeof(TypeToConvert) == typeof(ushort?))
			{
				ushort num8;
				bool result = jsonElement.TryGetUInt16(out num8);
				P_0 = (TypeToConvert)(object)num8;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(ulong) || typeof(TypeToConvert) == typeof(ulong?))
			{
				ulong num9;
				bool result = jsonElement.TryGetUInt64(out num9);
				P_0 = (TypeToConvert)(object)num9;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(sbyte) || typeof(TypeToConvert) == typeof(sbyte?))
			{
				sbyte b2;
				bool result = jsonElement.TryGetSByte(out b2);
				P_0 = (TypeToConvert)(object)b2;
				return result;
			}
			break;
		case JsonValueKind.String:
			if (typeof(TypeToConvert) == typeof(string))
			{
				string text = jsonElement.GetString();
				P_0 = (TypeToConvert)(object)text;
				return true;
			}
			if (typeof(TypeToConvert) == typeof(DateTime) || typeof(TypeToConvert) == typeof(DateTime?))
			{
				DateTime dateTime;
				bool result = jsonElement.TryGetDateTime(out dateTime);
				P_0 = (TypeToConvert)(object)dateTime;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(DateTimeOffset) || typeof(TypeToConvert) == typeof(DateTimeOffset?))
			{
				DateTimeOffset dateTimeOffset;
				bool result = jsonElement.TryGetDateTimeOffset(out dateTimeOffset);
				P_0 = (TypeToConvert)(object)dateTimeOffset;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(Guid) || typeof(TypeToConvert) == typeof(Guid?))
			{
				Guid guid;
				bool result = jsonElement.TryGetGuid(out guid);
				P_0 = (TypeToConvert)(object)guid;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(char) || typeof(TypeToConvert) == typeof(char?))
			{
				string text2 = jsonElement.GetString();
				if (text2.Length == 1)
				{
					P_0 = (TypeToConvert)(object)text2[0];
					return true;
				}
			}
			break;
		case JsonValueKind.True:
		case JsonValueKind.False:
			if (typeof(TypeToConvert) == typeof(bool) || typeof(TypeToConvert) == typeof(bool?))
			{
				P_0 = (TypeToConvert)(object)jsonElement.GetBoolean();
				return true;
			}
			break;
		}
		P_0 = default(TypeToConvert);
		return false;
	}
}
