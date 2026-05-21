using System.Buffers;
using System.Text.Unicode;

namespace System.Text.Encodings.Web;

internal sealed class DefaultJavaScriptEncoder : JavaScriptEncoder
{
	private sealed class EscaperImplementation : ScalarEscaperBase
	{
		internal static readonly EscaperImplementation Singleton = new EscaperImplementation(false);

		internal static readonly EscaperImplementation SingletonMinimallyEscaped = new EscaperImplementation(true);

		private readonly AsciiByteMap _preescapedMap;

		private EscaperImplementation(bool P_0)
		{
			_preescapedMap.InsertAsciiChar('\b', 98);
			_preescapedMap.InsertAsciiChar('\t', 116);
			_preescapedMap.InsertAsciiChar('\n', 110);
			_preescapedMap.InsertAsciiChar('\f', 102);
			_preescapedMap.InsertAsciiChar('\r', 114);
			_preescapedMap.InsertAsciiChar('\\', 92);
			if (P_0)
			{
				_preescapedMap.InsertAsciiChar('"', 34);
			}
		}

		internal override int EncodeUtf8(Rune P_0, Span<byte> P_1)
		{
			if (_preescapedMap.TryLookup(P_0, out var b))
			{
				if (SpanUtility.IsValidIndex(P_1, 1))
				{
					P_1[0] = 92;
					P_1[1] = b;
					return 2;
				}
				return -1;
			}
			return TryEncodeScalarAsHex(this, P_0, P_1);
			static int TryEncodeScalarAsHex(object obj, Rune rune, Span<byte> span)
			{
				if (rune.IsBmp)
				{
					if (SpanUtility.IsValidIndex(span, 5))
					{
						span[0] = 92;
						span[1] = 117;
						System.HexConverter.ToBytesBuffer((byte)rune.Value, span, 4);
						System.HexConverter.ToBytesBuffer((byte)((uint)rune.Value >> 8), span, 2);
						return 6;
					}
				}
				else
				{
					UnicodeHelpers.GetUtf16SurrogatePairFromAstralScalarValue((uint)rune.Value, out var c, out var c2);
					if (SpanUtility.IsValidIndex(span, 11))
					{
						span[0] = 92;
						span[1] = 117;
						System.HexConverter.ToBytesBuffer((byte)c, span, 4);
						System.HexConverter.ToBytesBuffer((byte)((uint)c >> 8), span, 2);
						span[6] = 92;
						span[7] = 117;
						System.HexConverter.ToBytesBuffer((byte)c2, span, 10);
						System.HexConverter.ToBytesBuffer((byte)((uint)c2 >> 8), span, 8);
						return 12;
					}
				}
				return -1;
			}
		}

		internal override int EncodeUtf16(Rune P_0, Span<char> P_1)
		{
			if (_preescapedMap.TryLookup(P_0, out var b))
			{
				if (SpanUtility.IsValidIndex(P_1, 1))
				{
					P_1[0] = '\\';
					P_1[1] = (char)b;
					return 2;
				}
				return -1;
			}
			return TryEncodeScalarAsHex(this, P_0, P_1);
			static int TryEncodeScalarAsHex(object obj, Rune rune, Span<char> span)
			{
				if (rune.IsBmp)
				{
					if (SpanUtility.IsValidIndex(span, 5))
					{
						span[0] = '\\';
						span[1] = 'u';
						System.HexConverter.ToCharsBuffer((byte)rune.Value, span, 4);
						System.HexConverter.ToCharsBuffer((byte)((uint)rune.Value >> 8), span, 2);
						return 6;
					}
				}
				else
				{
					UnicodeHelpers.GetUtf16SurrogatePairFromAstralScalarValue((uint)rune.Value, out var c, out var c2);
					if (SpanUtility.IsValidIndex(span, 11))
					{
						span[0] = '\\';
						span[1] = 'u';
						System.HexConverter.ToCharsBuffer((byte)c, span, 4);
						System.HexConverter.ToCharsBuffer((byte)((uint)c >> 8), span, 2);
						span[6] = '\\';
						span[7] = 'u';
						System.HexConverter.ToCharsBuffer((byte)c2, span, 10);
						System.HexConverter.ToCharsBuffer((byte)((uint)c2 >> 8), span, 8);
						return 12;
					}
				}
				return -1;
			}
		}
	}

	internal static readonly DefaultJavaScriptEncoder BasicLatinSingleton = new DefaultJavaScriptEncoder(new TextEncoderSettings(UnicodeRanges.BasicLatin));

	internal static readonly DefaultJavaScriptEncoder UnsafeRelaxedEscapingSingleton = new DefaultJavaScriptEncoder(new TextEncoderSettings(UnicodeRanges.All), true);

	private readonly OptimizedInboxTextEncoder _innerEncoder;

	internal DefaultJavaScriptEncoder(TextEncoderSettings P_0)
		: this(P_0, false)
	{
	}

	private DefaultJavaScriptEncoder(TextEncoderSettings P_0, bool P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.settings);
		}
		OptimizedInboxTextEncoder innerEncoder;
		if (P_1)
		{
			ScalarEscaperBase singletonMinimallyEscaped = EscaperImplementation.SingletonMinimallyEscaped;
			ref readonly AllowedBmpCodePointsBitmap allowedCodePointsBitmap = ref P_0.GetAllowedCodePointsBitmap();
			Span<char> span = stackalloc char[2] { '"', '\\' };
			innerEncoder = new OptimizedInboxTextEncoder(singletonMinimallyEscaped, in allowedCodePointsBitmap, false, span);
		}
		else
		{
			ScalarEscaperBase singleton = EscaperImplementation.Singleton;
			ref readonly AllowedBmpCodePointsBitmap allowedCodePointsBitmap2 = ref P_0.GetAllowedCodePointsBitmap();
			Span<char> span = stackalloc char[2] { '\\', '`' };
			innerEncoder = new OptimizedInboxTextEncoder(singleton, in allowedCodePointsBitmap2, true, span);
		}
		_innerEncoder = innerEncoder;
	}

	private protected override OperationStatus EncodeCore(ReadOnlySpan<char> P_0, Span<char> P_1, out int P_2, out int P_3, bool P_4)
	{
		return _innerEncoder.Encode(P_0, P_1, out P_2, out P_3, P_4);
	}

	private protected override OperationStatus EncodeUtf8Core(ReadOnlySpan<byte> P_0, Span<byte> P_1, out int P_2, out int P_3, bool P_4)
	{
		return _innerEncoder.EncodeUtf8(P_0, P_1, out P_2, out P_3, P_4);
	}

	private protected override int FindFirstCharacterToEncode(ReadOnlySpan<char> P_0)
	{
		return _innerEncoder.GetIndexOfFirstCharToEncode(P_0);
	}

	public unsafe override int FindFirstCharacterToEncode(char* P_0, int P_1)
	{
		return _innerEncoder.FindFirstCharacterToEncode(P_0, P_1);
	}

	public override int FindFirstCharacterToEncodeUtf8(ReadOnlySpan<byte> P_0)
	{
		return _innerEncoder.GetIndexOfFirstByteToEncode(P_0);
	}

	public unsafe override bool TryEncodeUnicodeScalar(int P_0, char* P_1, int P_2, out int P_3)
	{
		return _innerEncoder.TryEncodeUnicodeScalar(P_0, P_1, P_2, out P_3);
	}

	public override bool WillEncode(int P_0)
	{
		return !_innerEncoder.IsScalarValueAllowed(new Rune(P_0));
	}
}
