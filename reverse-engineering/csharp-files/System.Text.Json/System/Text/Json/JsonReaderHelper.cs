using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Text.Json;

internal static class JsonReaderHelper
{
	public static readonly UTF8Encoding s_utf8Encoding = new UTF8Encoding(false, true);

	public static (int, int) CountNewLines(ReadOnlySpan<byte> P_0)
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i] == 10)
			{
				num = i;
				num2++;
			}
		}
		return (num2, num);
	}

	internal static JsonValueKind ToValueKind(this JsonTokenType P_0)
	{
		switch (P_0)
		{
		case JsonTokenType.None:
			return JsonValueKind.Undefined;
		case JsonTokenType.StartArray:
			return JsonValueKind.Array;
		case JsonTokenType.StartObject:
			return JsonValueKind.Object;
		case JsonTokenType.String:
		case JsonTokenType.Number:
		case JsonTokenType.True:
		case JsonTokenType.False:
		case JsonTokenType.Null:
			return (JsonValueKind)(P_0 - 4);
		default:
			return JsonValueKind.Undefined;
		}
	}

	public static bool IsTokenTypePrimitive(JsonTokenType P_0)
	{
		return (int)(P_0 - 7) <= 4;
	}

	public static bool IsHexDigit(byte P_0)
	{
		return System.HexConverter.IsHexChar(P_0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int IndexOfQuoteOrAnyControlOrBackSlash(this ReadOnlySpan<byte> P_0)
	{
		return IndexOfOrLessThan(ref MemoryMarshal.GetReference(P_0), 34, 92, 32, P_0.Length);
	}

	private static int IndexOfOrLessThan(ref byte P_0, byte P_1, byte P_2, byte P_3, int P_4)
	{
		nint num = 0;
		nint num2 = P_4;
		if (false)
		{
			goto IL_0014;
		}
		goto IL_0145;
		IL_0014:
		num2 -= 8;
		uint num3 = Unsafe.AddByteOffset(ref P_0, num);
		if (P_1 == num3 || P_2 == num3 || P_3 > num3)
		{
			goto IL_0232;
		}
		num3 = Unsafe.AddByteOffset(ref P_0, num + 1);
		if (P_1 == num3 || P_2 == num3 || P_3 > num3)
		{
			goto IL_0235;
		}
		num3 = Unsafe.AddByteOffset(ref P_0, num + 2);
		if (P_1 == num3 || P_2 == num3 || P_3 > num3)
		{
			goto IL_023b;
		}
		num3 = Unsafe.AddByteOffset(ref P_0, num + 3);
		if (P_1 != num3 && P_2 != num3 && P_3 <= num3)
		{
			num3 = Unsafe.AddByteOffset(ref P_0, num + 4);
			if (P_1 != num3 && P_2 != num3 && P_3 <= num3)
			{
				num3 = Unsafe.AddByteOffset(ref P_0, num + 5);
				if (P_1 != num3 && P_2 != num3 && P_3 <= num3)
				{
					num3 = Unsafe.AddByteOffset(ref P_0, num + 6);
					if (P_1 != num3 && P_2 != num3 && P_3 <= num3)
					{
						num3 = Unsafe.AddByteOffset(ref P_0, num + 7);
						if (P_1 != num3 && P_2 != num3 && P_3 <= num3)
						{
							num += 8;
							goto IL_0145;
						}
						return (int)(num + 7);
					}
					return (int)(num + 6);
				}
				return (int)(num + 5);
			}
			return (int)(num + 4);
		}
		goto IL_0241;
		IL_0145:
		if ((nuint)num2 >= (nuint)8u)
		{
			goto IL_0014;
		}
		if ((nuint)num2 >= (nuint)4u)
		{
			num2 -= 4;
			num3 = Unsafe.AddByteOffset(ref P_0, num);
			if (P_1 == num3 || P_2 == num3 || P_3 > num3)
			{
				goto IL_0232;
			}
			num3 = Unsafe.AddByteOffset(ref P_0, num + 1);
			if (P_1 == num3 || P_2 == num3 || P_3 > num3)
			{
				goto IL_0235;
			}
			num3 = Unsafe.AddByteOffset(ref P_0, num + 2);
			if (P_1 == num3 || P_2 == num3 || P_3 > num3)
			{
				goto IL_023b;
			}
			num3 = Unsafe.AddByteOffset(ref P_0, num + 3);
			if (P_1 == num3 || P_2 == num3 || P_3 > num3)
			{
				goto IL_0241;
			}
			num += 4;
		}
		while (true)
		{
			if (num2 != 0)
			{
				num2--;
				num3 = Unsafe.AddByteOffset(ref P_0, num);
				if (P_1 == num3 || P_2 == num3 || P_3 > num3)
				{
					break;
				}
				num++;
				continue;
			}
			if (false)
			{
			}
			return -1;
		}
		goto IL_0232;
		IL_0241:
		return (int)(num + 3);
		IL_023b:
		return (int)(num + 2);
		IL_0235:
		return (int)(num + 1);
		IL_0232:
		return (int)num;
	}

	public static bool TryGetEscapedDateTime(ReadOnlySpan<byte> P_0, out DateTime P_1)
	{
		Span<byte> span = stackalloc byte[252];
		Unescape(P_0, span, out var num);
		span = span.Slice(0, num);
		if (JsonHelpers.IsValidUnescapedDateTimeOffsetParseLength(span.Length) && JsonHelpers.TryParseAsISO((ReadOnlySpan<byte>)span, out DateTime dateTime))
		{
			P_1 = dateTime;
			return true;
		}
		P_1 = default(DateTime);
		return false;
	}

	public static bool TryGetEscapedDateTimeOffset(ReadOnlySpan<byte> P_0, out DateTimeOffset P_1)
	{
		Span<byte> span = stackalloc byte[252];
		Unescape(P_0, span, out var num);
		span = span.Slice(0, num);
		if (JsonHelpers.IsValidUnescapedDateTimeOffsetParseLength(span.Length) && JsonHelpers.TryParseAsISO((ReadOnlySpan<byte>)span, out DateTimeOffset dateTimeOffset))
		{
			P_1 = dateTimeOffset;
			return true;
		}
		P_1 = default(DateTimeOffset);
		return false;
	}

	public static bool TryGetEscapedGuid(ReadOnlySpan<byte> P_0, out Guid P_1)
	{
		Span<byte> span = stackalloc byte[216];
		Unescape(P_0, span, out var num);
		span = span.Slice(0, num);
		if (span.Length == 36 && Utf8Parser.TryParse((ReadOnlySpan<byte>)span, out Guid guid, out int _, 'D'))
		{
			P_1 = guid;
			return true;
		}
		P_1 = default(Guid);
		return false;
	}

	public static bool TryGetFloatingPointConstant(ReadOnlySpan<byte> P_0, out float P_1)
	{
		if (P_0.Length == 3)
		{
			if (P_0.SequenceEqual(JsonConstants.NaNValue))
			{
				P_1 = 0f / 0f;
				return true;
			}
		}
		else if (P_0.Length == 8)
		{
			if (P_0.SequenceEqual(JsonConstants.PositiveInfinityValue))
			{
				P_1 = 1f / 0f;
				return true;
			}
		}
		else if (P_0.Length == 9 && P_0.SequenceEqual(JsonConstants.NegativeInfinityValue))
		{
			P_1 = -1f / 0f;
			return true;
		}
		P_1 = 0f;
		return false;
	}

	public static bool TryGetFloatingPointConstant(ReadOnlySpan<byte> P_0, out double P_1)
	{
		if (P_0.Length == 3)
		{
			if (P_0.SequenceEqual(JsonConstants.NaNValue))
			{
				P_1 = 0.0 / 0.0;
				return true;
			}
		}
		else if (P_0.Length == 8)
		{
			if (P_0.SequenceEqual(JsonConstants.PositiveInfinityValue))
			{
				P_1 = 1.0 / 0.0;
				return true;
			}
		}
		else if (P_0.Length == 9 && P_0.SequenceEqual(JsonConstants.NegativeInfinityValue))
		{
			P_1 = -1.0 / 0.0;
			return true;
		}
		P_1 = 0.0;
		return false;
	}

	public static bool TryGetUnescapedBase64Bytes(ReadOnlySpan<byte> P_0, [NotNullWhen(true)] out byte[] P_1)
	{
		byte[] array = null;
		Span<byte> span = ((P_0.Length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(P_0.Length))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		Unescape(P_0, span2, out var num);
		span2 = span2.Slice(0, num);
		bool result = TryDecodeBase64InPlace(span2, out P_1);
		if (array != null)
		{
			span2.Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	public static string GetUnescapedString(ReadOnlySpan<byte> P_0)
	{
		int length = P_0.Length;
		byte[] array = null;
		Span<byte> span = ((length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(length))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		Unescape(P_0, span2, out var num);
		span2 = span2.Slice(0, num);
		string result = TranscodeHelper(span2);
		if (array != null)
		{
			span2.Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	public static ReadOnlySpan<byte> GetUnescapedSpan(ReadOnlySpan<byte> P_0)
	{
		int length = P_0.Length;
		byte[] array = null;
		Span<byte> span = ((length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(length))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		Unescape(P_0, span2, out var num);
		ReadOnlySpan<byte> result = span2.Slice(0, num).ToArray();
		if (array != null)
		{
			new Span<byte>(array, 0, num).Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	public static bool UnescapeAndCompare(ReadOnlySpan<byte> P_0, ReadOnlySpan<byte> P_1)
	{
		byte[] array = null;
		Span<byte> span = ((P_0.Length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(P_0.Length))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		Unescape(P_0, span2, 0, out var num);
		span2 = span2.Slice(0, num);
		bool result = P_1.SequenceEqual(span2);
		if (array != null)
		{
			span2.Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	public static bool UnescapeAndCompare(ReadOnlySequence<byte> P_0, ReadOnlySpan<byte> P_1)
	{
		byte[] array = null;
		byte[] array2 = null;
		int num = checked((int)P_0.Length);
		Span<byte> span = ((num > 256) ? ((Span<byte>)(array2 = ArrayPool<byte>.Shared.Rent(num))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		Span<byte> span3 = ((num > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(num))) : stackalloc byte[256]);
		Span<byte> span4 = span3;
		P_0.CopyTo(span4);
		span4 = span4.Slice(0, num);
		Unescape(span4, span2, 0, out var num2);
		span2 = span2.Slice(0, num2);
		bool result = P_1.SequenceEqual(span2);
		if (array2 != null)
		{
			span2.Clear();
			ArrayPool<byte>.Shared.Return(array2);
			span4.Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return result;
	}

	public static bool TryDecodeBase64InPlace(Span<byte> P_0, [NotNullWhen(true)] out byte[] P_1)
	{
		if (Base64.DecodeFromUtf8InPlace(P_0, out var num) != OperationStatus.Done)
		{
			P_1 = null;
			return false;
		}
		P_1 = P_0.Slice(0, num).ToArray();
		return true;
	}

	public static bool TryDecodeBase64(ReadOnlySpan<byte> P_0, [NotNullWhen(true)] out byte[] P_1)
	{
		byte[] array = null;
		Span<byte> span = ((P_0.Length > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(P_0.Length))) : stackalloc byte[256]);
		Span<byte> span2 = span;
		if (Base64.DecodeFromUtf8(P_0, span2, out var _, out var num2) != OperationStatus.Done)
		{
			P_1 = null;
			if (array != null)
			{
				span2.Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
			return false;
		}
		P_1 = span2.Slice(0, num2).ToArray();
		if (array != null)
		{
			span2.Clear();
			ArrayPool<byte>.Shared.Return(array);
		}
		return true;
	}

	public static string TranscodeHelper(ReadOnlySpan<byte> P_0)
	{
		try
		{
			return s_utf8Encoding.GetString(P_0);
		}
		catch (DecoderFallbackException ex)
		{
			throw ThrowHelper.GetInvalidOperationException_ReadInvalidUTF8(ex);
		}
	}

	public static int TranscodeHelper(ReadOnlySpan<byte> P_0, Span<char> P_1)
	{
		try
		{
			return s_utf8Encoding.GetChars(P_0, P_1);
		}
		catch (DecoderFallbackException ex)
		{
			throw ThrowHelper.GetInvalidOperationException_ReadInvalidUTF8(ex);
		}
		catch (ArgumentException)
		{
			P_1.Clear();
			throw;
		}
	}

	public static void ValidateUtf8(ReadOnlySpan<byte> P_0)
	{
		try
		{
			s_utf8Encoding.GetCharCount(P_0);
		}
		catch (DecoderFallbackException ex)
		{
			throw ThrowHelper.GetInvalidOperationException_ReadInvalidUTF8(ex);
		}
	}

	internal static int GetUtf8ByteCount(ReadOnlySpan<char> P_0)
	{
		try
		{
			return s_utf8Encoding.GetByteCount(P_0);
		}
		catch (EncoderFallbackException ex)
		{
			throw ThrowHelper.GetArgumentException_ReadInvalidUTF16(ex);
		}
	}

	internal static int GetUtf8FromText(ReadOnlySpan<char> P_0, Span<byte> P_1)
	{
		try
		{
			return s_utf8Encoding.GetBytes(P_0, P_1);
		}
		catch (EncoderFallbackException ex)
		{
			throw ThrowHelper.GetArgumentException_ReadInvalidUTF16(ex);
		}
	}

	internal static string GetTextFromUtf8(ReadOnlySpan<byte> P_0)
	{
		return s_utf8Encoding.GetString(P_0);
	}

	internal static void Unescape(ReadOnlySpan<byte> P_0, Span<byte> P_1, out int P_2)
	{
		int num = P_0.IndexOf<byte>(92);
		bool flag = TryUnescape(P_0, P_1, num, out P_2);
	}

	internal static void Unescape(ReadOnlySpan<byte> P_0, Span<byte> P_1, int P_2, out int P_3)
	{
		bool flag = TryUnescape(P_0, P_1, P_2, out P_3);
	}

	internal static bool TryUnescape(ReadOnlySpan<byte> P_0, Span<byte> P_1, out int P_2)
	{
		int num = P_0.IndexOf<byte>(92);
		return TryUnescape(P_0, P_1, num, out P_2);
	}

	private static bool TryUnescape(ReadOnlySpan<byte> P_0, Span<byte> P_1, int P_2, out int P_3)
	{
		if (!P_0.Slice(0, P_2).TryCopyTo(P_1))
		{
			P_3 = 0;
		}
		else
		{
			P_3 = P_2;
			while (P_3 != P_1.Length)
			{
				byte b = P_0[++P_2];
				if ((uint)b <= 98u)
				{
					if ((uint)b <= 47u)
					{
						if (b != 34)
						{
							if (b != 47)
							{
								goto IL_0179;
							}
							P_1[P_3++] = 47;
						}
						else
						{
							P_1[P_3++] = 34;
						}
					}
					else if (b != 92)
					{
						if (b != 98)
						{
							goto IL_0179;
						}
						P_1[P_3++] = 8;
					}
					else
					{
						P_1[P_3++] = 92;
					}
				}
				else if ((uint)b <= 110u)
				{
					if (b != 102)
					{
						if (b != 110)
						{
							goto IL_0179;
						}
						P_1[P_3++] = 10;
					}
					else
					{
						P_1[P_3++] = 12;
					}
				}
				else if (b != 114)
				{
					if (b != 116)
					{
						goto IL_0179;
					}
					P_1[P_3++] = 9;
				}
				else
				{
					P_1[P_3++] = 13;
				}
				goto IL_0264;
				IL_0264:
				if (++P_2 != P_0.Length)
				{
					if (P_0[P_2] == 92)
					{
						continue;
					}
					ReadOnlySpan<byte> readOnlySpan = P_0.Slice(P_2);
					int num = readOnlySpan.IndexOf<byte>(92);
					if (num < 0)
					{
						num = readOnlySpan.Length;
					}
					if ((uint)(P_3 + num) >= (uint)P_1.Length)
					{
						break;
					}
					switch (num)
					{
					case 1:
						P_1[P_3++] = P_0[P_2++];
						break;
					case 2:
						P_1[P_3++] = P_0[P_2++];
						P_1[P_3++] = P_0[P_2++];
						break;
					case 3:
						P_1[P_3++] = P_0[P_2++];
						P_1[P_3++] = P_0[P_2++];
						P_1[P_3++] = P_0[P_2++];
						break;
					default:
						readOnlySpan.Slice(0, num).CopyTo(P_1.Slice(P_3));
						P_3 += num;
						P_2 += num;
						break;
					}
					if (P_2 != P_0.Length)
					{
						continue;
					}
				}
				return true;
				IL_0179:
				bool flag = Utf8Parser.TryParse(P_0.Slice(P_2 + 1, 4), out int num2, out int num3, 'x');
				P_2 += 4;
				if (JsonHelpers.IsInRangeInclusive((uint)num2, 55296u, 57343u))
				{
					if (num2 >= 56320)
					{
						ThrowHelper.ThrowInvalidOperationException_ReadInvalidUTF16(num2);
					}
					if (P_0.Length < P_2 + 7 || P_0[P_2 + 1] != 92 || P_0[P_2 + 2] != 117)
					{
						ThrowHelper.ThrowInvalidOperationException_ReadIncompleteUTF16();
					}
					flag = Utf8Parser.TryParse(P_0.Slice(P_2 + 3, 4), out int num4, out num3, 'x');
					P_2 += 6;
					if (!JsonHelpers.IsInRangeInclusive((uint)num4, 56320u, 57343u))
					{
						ThrowHelper.ThrowInvalidOperationException_ReadInvalidUTF16(num4);
					}
					num2 = 1024 * (num2 - 55296) + (num4 - 56320) + 65536;
				}
				if (!new Rune(num2).TryEncodeToUtf8(P_1.Slice(P_3), out var num5))
				{
					break;
				}
				P_3 += num5;
				goto IL_0264;
			}
		}
		return false;
	}
}
