using System.Buffers;
using System.Collections.Concurrent;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;

namespace System.Text.Json.Serialization.Converters;

internal sealed class EnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
	private static readonly TypeCode s_enumTypeCode = Type.GetTypeCode(typeof(T));

	private static readonly bool s_isSignedEnum = (int)s_enumTypeCode % 2 == 1;

	private readonly EnumConverterOptions _converterOptions;

	private readonly JsonNamingPolicy _namingPolicy;

	private readonly ConcurrentDictionary<ulong, JsonEncodedText> _nameCacheForWriting;

	private readonly ConcurrentDictionary<string, T> _nameCacheForReading;

	public override bool CanConvert(Type P_0)
	{
		return P_0.IsEnum;
	}

	public EnumConverter(EnumConverterOptions converterOptions, JsonSerializerOptions serializerOptions)
		: this(converterOptions, (JsonNamingPolicy)null, serializerOptions)
	{
	}

	public EnumConverter(EnumConverterOptions converterOptions, JsonNamingPolicy namingPolicy, JsonSerializerOptions serializerOptions)
	{
		_converterOptions = converterOptions;
		_namingPolicy = namingPolicy;
		_nameCacheForWriting = new ConcurrentDictionary<ulong, JsonEncodedText>();
		if (namingPolicy != null)
		{
			_nameCacheForReading = new ConcurrentDictionary<string, T>();
		}
		string[] names = Enum.GetNames<T>();
		T[] values = Enum.GetValues<T>();
		JavaScriptEncoder encoder = serializerOptions.Encoder;
		for (int i = 0; i < names.Length; i++)
		{
			T val = values[i];
			ulong num = ConvertToUInt64(val);
			string text = names[i];
			string text2 = FormatJsonName(text, namingPolicy);
			_nameCacheForWriting.TryAdd(num, JsonEncodedText.Encode(text2, encoder));
			_nameCacheForReading?.TryAdd(text2, val);
		}
	}

	public override T Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		switch (P_0.TokenType)
		{
		case JsonTokenType.String:
		{
			if (!_converterOptions.HasFlag(EnumConverterOptions.AllowStrings))
			{
				ThrowHelper.ThrowJsonException();
				return default(T);
			}
			if (TryParseEnumCore(ref P_0, P_2, out var result))
			{
				return result;
			}
			return ReadEnumUsingNamingPolicy(P_0.GetString());
		}
		case JsonTokenType.Number:
			if (_converterOptions.HasFlag(EnumConverterOptions.AllowNumbers))
			{
				switch (s_enumTypeCode)
				{
				case TypeCode.Int32:
				{
					if (P_0.TryGetInt32(out var num6))
					{
						return Unsafe.As<int, T>(ref num6);
					}
					break;
				}
				case TypeCode.UInt32:
				{
					if (P_0.TryGetUInt32(out var num4))
					{
						return Unsafe.As<uint, T>(ref num4);
					}
					break;
				}
				case TypeCode.UInt64:
				{
					if (P_0.TryGetUInt64(out var num5))
					{
						return Unsafe.As<ulong, T>(ref num5);
					}
					break;
				}
				case TypeCode.Int64:
				{
					if (P_0.TryGetInt64(out var num2))
					{
						return Unsafe.As<long, T>(ref num2);
					}
					break;
				}
				case TypeCode.SByte:
				{
					if (P_0.TryGetSByte(out var b2))
					{
						return Unsafe.As<sbyte, T>(ref b2);
					}
					break;
				}
				case TypeCode.Byte:
				{
					if (P_0.TryGetByte(out var b))
					{
						return Unsafe.As<byte, T>(ref b);
					}
					break;
				}
				case TypeCode.Int16:
				{
					if (P_0.TryGetInt16(out var num3))
					{
						return Unsafe.As<short, T>(ref num3);
					}
					break;
				}
				case TypeCode.UInt16:
				{
					if (P_0.TryGetUInt16(out var num))
					{
						return Unsafe.As<ushort, T>(ref num);
					}
					break;
				}
				}
				ThrowHelper.ThrowJsonException();
				return default(T);
			}
			goto default;
		default:
			ThrowHelper.ThrowJsonException();
			return default(T);
		}
	}

	public override void Write(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2)
	{
		if (_converterOptions.HasFlag(EnumConverterOptions.AllowStrings))
		{
			ulong num = ConvertToUInt64(P_1);
			if (_nameCacheForWriting.TryGetValue(num, out var jsonEncodedText))
			{
				P_0.WriteStringValue(jsonEncodedText);
				return;
			}
			string text = P_1.ToString();
			if (IsValidIdentifier(text))
			{
				text = FormatJsonName(text, _namingPolicy);
				if (_nameCacheForWriting.Count < 64)
				{
					jsonEncodedText = JsonEncodedText.Encode(text, P_2.Encoder);
					P_0.WriteStringValue(jsonEncodedText);
					_nameCacheForWriting.TryAdd(num, jsonEncodedText);
				}
				else
				{
					P_0.WriteStringValue(text);
				}
				return;
			}
		}
		if (!_converterOptions.HasFlag(EnumConverterOptions.AllowNumbers))
		{
			ThrowHelper.ThrowJsonException();
		}
		switch (s_enumTypeCode)
		{
		case TypeCode.Int32:
			P_0.WriteNumberValue(Unsafe.As<T, int>(ref P_1));
			break;
		case TypeCode.UInt32:
			P_0.WriteNumberValue(Unsafe.As<T, uint>(ref P_1));
			break;
		case TypeCode.UInt64:
			P_0.WriteNumberValue(Unsafe.As<T, ulong>(ref P_1));
			break;
		case TypeCode.Int64:
			P_0.WriteNumberValue(Unsafe.As<T, long>(ref P_1));
			break;
		case TypeCode.Int16:
			P_0.WriteNumberValue(Unsafe.As<T, short>(ref P_1));
			break;
		case TypeCode.UInt16:
			P_0.WriteNumberValue(Unsafe.As<T, ushort>(ref P_1));
			break;
		case TypeCode.Byte:
			P_0.WriteNumberValue(Unsafe.As<T, byte>(ref P_1));
			break;
		case TypeCode.SByte:
			P_0.WriteNumberValue(Unsafe.As<T, sbyte>(ref P_1));
			break;
		default:
			ThrowHelper.ThrowJsonException();
			break;
		}
	}

	internal override T ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (!TryParseEnumCore(ref P_0, P_2, out var result))
		{
			ThrowHelper.ThrowJsonException();
		}
		return result;
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2, bool P_3)
	{
		ulong num = ConvertToUInt64(P_1);
		if (P_2.DictionaryKeyPolicy == null && _nameCacheForWriting.TryGetValue(num, out var jsonEncodedText))
		{
			P_0.WritePropertyName(jsonEncodedText);
			return;
		}
		string text = P_1.ToString();
		if (IsValidIdentifier(text))
		{
			if (P_2.DictionaryKeyPolicy != null)
			{
				text = FormatJsonName(text, P_2.DictionaryKeyPolicy);
				P_0.WritePropertyName(text);
				return;
			}
			text = FormatJsonName(text, _namingPolicy);
			if (_nameCacheForWriting.Count < 64)
			{
				jsonEncodedText = JsonEncodedText.Encode(text, P_2.Encoder);
				P_0.WritePropertyName(jsonEncodedText);
				_nameCacheForWriting.TryAdd(num, jsonEncodedText);
			}
			else
			{
				P_0.WritePropertyName(text);
			}
			return;
		}
		switch (s_enumTypeCode)
		{
		case TypeCode.Int32:
			P_0.WritePropertyName(Unsafe.As<T, int>(ref P_1));
			break;
		case TypeCode.UInt32:
			P_0.WritePropertyName(Unsafe.As<T, uint>(ref P_1));
			break;
		case TypeCode.UInt64:
			P_0.WritePropertyName(Unsafe.As<T, ulong>(ref P_1));
			break;
		case TypeCode.Int64:
			P_0.WritePropertyName(Unsafe.As<T, long>(ref P_1));
			break;
		case TypeCode.Int16:
			P_0.WritePropertyName(Unsafe.As<T, short>(ref P_1));
			break;
		case TypeCode.UInt16:
			P_0.WritePropertyName(Unsafe.As<T, ushort>(ref P_1));
			break;
		case TypeCode.Byte:
			P_0.WritePropertyName(Unsafe.As<T, byte>(ref P_1));
			break;
		case TypeCode.SByte:
			P_0.WritePropertyName(Unsafe.As<T, sbyte>(ref P_1));
			break;
		default:
			ThrowHelper.ThrowJsonException();
			break;
		}
	}

	private static bool TryParseEnumCore(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, out T P_2)
	{
		char[] array = null;
		int valueLength = P_0.ValueLength;
		Span<char> span = ((valueLength > 128) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(valueLength))) : stackalloc char[128]);
		Span<char> span2 = span;
		int num = P_0.CopyString(span2);
		ReadOnlySpan<char> readOnlySpan = span2.Slice(0, num);
		T val;
		bool result = Enum.TryParse<T>(readOnlySpan, out val) || Enum.TryParse<T>(readOnlySpan, true, out val);
		if (array != null)
		{
			span2.Slice(0, num).Clear();
			ArrayPool<char>.Shared.Return(array);
		}
		P_2 = val;
		return result;
	}

	private T ReadEnumUsingNamingPolicy(string P_0)
	{
		if (_namingPolicy == null)
		{
			ThrowHelper.ThrowJsonException();
		}
		if (P_0 == null)
		{
			ThrowHelper.ThrowJsonException();
		}
		bool flag;
		if (!(flag = _nameCacheForReading.TryGetValue(P_0, out var val)) && P_0.Contains(", "))
		{
			string[] array = SplitFlagsEnum(P_0);
			ulong num = 0uL;
			for (int i = 0; i < array.Length; i++)
			{
				flag = _nameCacheForReading.TryGetValue(array[i], out val);
				if (!flag)
				{
					break;
				}
				num |= ConvertToUInt64(val);
			}
			val = (T)Enum.ToObject(typeof(T), num);
			if (flag && _nameCacheForReading.Count < 64)
			{
				_nameCacheForReading[P_0] = val;
			}
		}
		if (!flag)
		{
			ThrowHelper.ThrowJsonException();
		}
		return val;
	}

	private static ulong ConvertToUInt64(object P_0)
	{
		return s_enumTypeCode switch
		{
			TypeCode.Int32 => (ulong)(int)P_0, 
			TypeCode.UInt32 => (uint)P_0, 
			TypeCode.UInt64 => (ulong)P_0, 
			TypeCode.Int64 => (ulong)(long)P_0, 
			TypeCode.SByte => (ulong)(sbyte)P_0, 
			TypeCode.Byte => (byte)P_0, 
			TypeCode.Int16 => (ulong)(short)P_0, 
			TypeCode.UInt16 => (ushort)P_0, 
			_ => throw new InvalidOperationException(), 
		};
	}

	private static bool IsValidIdentifier(string P_0)
	{
		if (P_0[0] >= 'A')
		{
			if (s_isSignedEnum)
			{
				return !P_0.StartsWith(NumberFormatInfo.CurrentInfo.NegativeSign);
			}
			return true;
		}
		return false;
	}

	private static string FormatJsonName(string P_0, JsonNamingPolicy P_1)
	{
		if (P_1 == null)
		{
			return P_0;
		}
		if (!P_0.Contains(", "))
		{
			return P_1.ConvertName(P_0);
		}
		string[] array = SplitFlagsEnum(P_0);
		for (int i = 0; i < array.Length; i++)
		{
			string text = P_1.ConvertName(array[i]);
			if (text == null)
			{
				ThrowHelper.ThrowInvalidOperationException_NamingPolicyReturnNull(P_1);
			}
			array[i] = text;
		}
		return string.Join(", ", array);
	}

	private static string[] SplitFlagsEnum(string P_0)
	{
		return P_0.Split(", ");
	}
}
