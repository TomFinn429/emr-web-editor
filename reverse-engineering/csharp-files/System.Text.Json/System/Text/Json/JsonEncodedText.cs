using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Text.Encodings.Web;

namespace System.Text.Json;

public readonly struct JsonEncodedText : IEquatable<JsonEncodedText>
{
	internal readonly byte[] _utf8Value;

	internal readonly string _value;

	public ReadOnlySpan<byte> EncodedUtf8Bytes => _utf8Value;

	private JsonEncodedText(byte[] P_0)
	{
		_value = JsonReaderHelper.GetTextFromUtf8(P_0);
		_utf8Value = P_0;
	}

	public static JsonEncodedText Encode(string P_0, JavaScriptEncoder? P_1 = null)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("value");
		}
		return Encode(P_0.AsSpan(), P_1);
	}

	public static JsonEncodedText Encode(ReadOnlySpan<char> P_0, JavaScriptEncoder? P_1 = null)
	{
		if (P_0.Length == 0)
		{
			return new JsonEncodedText(Array.Empty<byte>());
		}
		return TranscodeAndEncode(P_0, P_1);
	}

	private static JsonEncodedText TranscodeAndEncode(ReadOnlySpan<char> P_0, JavaScriptEncoder P_1)
	{
		JsonWriterHelper.ValidateValue(P_0);
		int utf8ByteCount = JsonReaderHelper.GetUtf8ByteCount(P_0);
		byte[] array = ArrayPool<byte>.Shared.Rent(utf8ByteCount);
		int utf8FromText = JsonReaderHelper.GetUtf8FromText(P_0, array);
		JsonEncodedText result = EncodeHelper(array.AsSpan(0, utf8FromText), P_1);
		array.AsSpan(0, utf8ByteCount).Clear();
		ArrayPool<byte>.Shared.Return(array);
		return result;
	}

	private static JsonEncodedText EncodeHelper(ReadOnlySpan<byte> P_0, JavaScriptEncoder P_1)
	{
		int num = JsonWriterHelper.NeedsEscaping(P_0, P_1);
		if (num != -1)
		{
			return new JsonEncodedText(JsonHelpers.EscapeValue(P_0, num, P_1));
		}
		return new JsonEncodedText(P_0.ToArray());
	}

	public bool Equals(JsonEncodedText P_0)
	{
		if (_value == null)
		{
			return P_0._value == null;
		}
		return _value.Equals(P_0._value);
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (P_0 is JsonEncodedText jsonEncodedText)
		{
			return Equals(jsonEncodedText);
		}
		return false;
	}

	public override string ToString()
	{
		return _value ?? string.Empty;
	}

	public override int GetHashCode()
	{
		if (_value != null)
		{
			return _value.GetHashCode();
		}
		return 0;
	}
}
