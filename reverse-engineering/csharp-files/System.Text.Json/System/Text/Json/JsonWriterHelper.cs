using System.Buffers;
using System.Buffers.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;

namespace System.Text.Json;

internal static class JsonWriterHelper
{
	private static readonly StandardFormat s_dateTimeStandardFormat = new StandardFormat('O', 255);

	private static readonly StandardFormat s_hexStandardFormat = new StandardFormat('X', 4);

	private static ReadOnlySpan<byte> AllowList => new byte[256]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 1, 1, 0, 1, 1, 1, 0, 0,
		1, 1, 1, 0, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		0, 1, 0, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 0, 1, 1, 1, 0, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0
	};

	public static void WriteIndentation(Span<byte> P_0, int P_1)
	{
		if (P_1 < 8)
		{
			int num = 0;
			while (num < P_1)
			{
				P_0[num++] = 32;
				P_0[num++] = 32;
			}
		}
		else
		{
			P_0.Slice(0, P_1).Fill(32);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateProperty(ReadOnlySpan<byte> P_0)
	{
		if (P_0.Length > 166666666)
		{
			ThrowHelper.ThrowArgumentException_PropertyNameTooLarge(P_0.Length);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateValue(ReadOnlySpan<byte> P_0)
	{
		if (P_0.Length > 166666666)
		{
			ThrowHelper.ThrowArgumentException_ValueTooLarge(P_0.Length);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateBytes(ReadOnlySpan<byte> P_0)
	{
		if (P_0.Length > 125000000)
		{
			ThrowHelper.ThrowArgumentException_ValueTooLarge(P_0.Length);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateDouble(double P_0)
	{
		if (!JsonHelpers.IsFinite(P_0))
		{
			ThrowHelper.ThrowArgumentException_ValueNotSupported();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateSingle(float P_0)
	{
		if (!JsonHelpers.IsFinite(P_0))
		{
			ThrowHelper.ThrowArgumentException_ValueNotSupported();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateProperty(ReadOnlySpan<char> P_0)
	{
		if (P_0.Length > 166666666)
		{
			ThrowHelper.ThrowArgumentException_PropertyNameTooLarge(P_0.Length);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidateValue(ReadOnlySpan<char> P_0)
	{
		if (P_0.Length > 166666666)
		{
			ThrowHelper.ThrowArgumentException_ValueTooLarge(P_0.Length);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ValidatePropertyAndValue(ReadOnlySpan<char> P_0, ReadOnlySpan<char> P_1)
	{
		if (P_0.Length > 166666666 || P_1.Length > 166666666)
		{
			ThrowHelper.ThrowArgumentException(P_0, P_1);
		}
	}

	internal static void ValidateNumber(ReadOnlySpan<byte> P_0)
	{
		int i = 0;
		if (P_0[i] == 45)
		{
			i++;
			if (P_0.Length <= i)
			{
				throw new ArgumentException("RequiredDigitNotFoundEndOfData", "utf8FormattedNumber");
			}
		}
		if (P_0[i] == 48)
		{
			i++;
		}
		else
		{
			for (; i < P_0.Length && JsonHelpers.IsDigit(P_0[i]); i++)
			{
			}
		}
		if (i == P_0.Length)
		{
			return;
		}
		byte b = P_0[i];
		if (b == 46)
		{
			i++;
			if (P_0.Length <= i)
			{
				throw new ArgumentException("RequiredDigitNotFoundEndOfData", "utf8FormattedNumber");
			}
			for (; i < P_0.Length && JsonHelpers.IsDigit(P_0[i]); i++)
			{
			}
			if (i == P_0.Length)
			{
				return;
			}
			b = P_0[i];
		}
		if (b == 101 || b == 69)
		{
			i++;
			if (P_0.Length <= i)
			{
				throw new ArgumentException("RequiredDigitNotFoundEndOfData", "utf8FormattedNumber");
			}
			b = P_0[i];
			if (b == 43 || b == 45)
			{
				i++;
			}
			if (P_0.Length <= i)
			{
				throw new ArgumentException("RequiredDigitNotFoundEndOfData", "utf8FormattedNumber");
			}
			for (; i < P_0.Length && JsonHelpers.IsDigit(P_0[i]); i++)
			{
			}
			if (i == P_0.Length)
			{
				return;
			}
			throw new ArgumentException(System.SR.Format("ExpectedEndOfDigitNotFound", ThrowHelper.GetPrintableString(P_0[i])), "utf8FormattedNumber");
		}
		throw new ArgumentException(System.SR.Format("ExpectedEndOfDigitNotFound", ThrowHelper.GetPrintableString(b)), "utf8FormattedNumber");
	}

	public static void WriteDateTimeTrimmed(Span<byte> P_0, DateTime P_1, out int P_2)
	{
		Span<byte> span = stackalloc byte[33];
		bool flag = Utf8Formatter.TryFormat(P_1, span, out P_2, s_dateTimeStandardFormat);
		TrimDateTimeOffset(span.Slice(0, P_2), out P_2);
		span.Slice(0, P_2).CopyTo(P_0);
	}

	public static void WriteDateTimeOffsetTrimmed(Span<byte> P_0, DateTimeOffset P_1, out int P_2)
	{
		Span<byte> span = stackalloc byte[33];
		bool flag = Utf8Formatter.TryFormat(P_1, span, out P_2, s_dateTimeStandardFormat);
		TrimDateTimeOffset(span.Slice(0, P_2), out P_2);
		span.Slice(0, P_2).CopyTo(P_0);
	}

	public static void TrimDateTimeOffset(Span<byte> P_0, out int P_1)
	{
		if (P_0[26] != 48)
		{
			P_1 = P_0.Length;
			return;
		}
		int num = ((P_0[25] != 48) ? 26 : ((P_0[24] != 48) ? 25 : ((P_0[23] != 48) ? 24 : ((P_0[22] != 48) ? 23 : ((P_0[21] != 48) ? 22 : ((P_0[20] != 48) ? 21 : 19))))));
		if (P_0.Length == 27)
		{
			P_1 = num;
		}
		else if (P_0.Length == 33)
		{
			P_0[num] = P_0[27];
			P_0[num + 1] = P_0[28];
			P_0[num + 2] = P_0[29];
			P_0[num + 3] = P_0[30];
			P_0[num + 4] = P_0[31];
			P_0[num + 5] = P_0[32];
			P_1 = num + 6;
		}
		else
		{
			P_0[num] = 90;
			P_1 = num + 1;
		}
	}

	private static bool NeedsEscaping(byte P_0)
	{
		return AllowList[P_0] == 0;
	}

	private static bool NeedsEscapingNoBoundsCheck(char P_0)
	{
		return AllowList[P_0] == 0;
	}

	public static int NeedsEscaping(ReadOnlySpan<byte> P_0, JavaScriptEncoder P_1)
	{
		return (P_1 ?? JavaScriptEncoder.Default).FindFirstCharacterToEncodeUtf8(P_0);
	}

	public unsafe static int NeedsEscaping(ReadOnlySpan<char> P_0, JavaScriptEncoder P_1)
	{
		if (P_0.IsEmpty)
		{
			return -1;
		}
		fixed (char* ptr = P_0)
		{
			return (P_1 ?? JavaScriptEncoder.Default).FindFirstCharacterToEncode(ptr, P_0.Length);
		}
	}

	public static int GetMaxEscapedLength(int P_0, int P_1)
	{
		return P_1 + 6 * (P_0 - P_1);
	}

	private static void EscapeString(ReadOnlySpan<byte> P_0, Span<byte> P_1, JavaScriptEncoder P_2, ref int P_3)
	{
		if (P_2.EncodeUtf8(P_0, P_1, out var _, out var num2) != OperationStatus.Done)
		{
			ThrowHelper.ThrowArgumentException_InvalidUTF8(P_0.Slice(num2));
		}
		P_3 += num2;
	}

	public static void EscapeString(ReadOnlySpan<byte> P_0, Span<byte> P_1, int P_2, JavaScriptEncoder P_3, out int P_4)
	{
		P_0.Slice(0, P_2).CopyTo(P_1);
		P_4 = P_2;
		if (P_3 != null)
		{
			P_1 = P_1.Slice(P_2);
			P_0 = P_0.Slice(P_2);
			EscapeString(P_0, P_1, P_3, ref P_4);
			return;
		}
		while (P_2 < P_0.Length)
		{
			byte b = P_0[P_2];
			if (IsAsciiValue(b))
			{
				if (NeedsEscaping(b))
				{
					EscapeNextBytes(b, P_1, ref P_4);
					P_2++;
				}
				else
				{
					P_1[P_4] = b;
					P_4++;
					P_2++;
				}
				continue;
			}
			P_1 = P_1.Slice(P_4);
			P_0 = P_0.Slice(P_2);
			EscapeString(P_0, P_1, JavaScriptEncoder.Default, ref P_4);
			break;
		}
	}

	private static void EscapeNextBytes(byte P_0, Span<byte> P_1, ref int P_2)
	{
		P_1[P_2++] = 92;
		switch (P_0)
		{
		case 34:
			P_1[P_2++] = 117;
			P_1[P_2++] = 48;
			P_1[P_2++] = 48;
			P_1[P_2++] = 50;
			P_1[P_2++] = 50;
			break;
		case 10:
			P_1[P_2++] = 110;
			break;
		case 13:
			P_1[P_2++] = 114;
			break;
		case 9:
			P_1[P_2++] = 116;
			break;
		case 92:
			P_1[P_2++] = 92;
			break;
		case 8:
			P_1[P_2++] = 98;
			break;
		case 12:
			P_1[P_2++] = 102;
			break;
		default:
		{
			P_1[P_2++] = 117;
			int num;
			bool flag = Utf8Formatter.TryFormat(P_0, P_1.Slice(P_2), out num, s_hexStandardFormat);
			P_2 += num;
			break;
		}
		}
	}

	private static bool IsAsciiValue(byte P_0)
	{
		return P_0 <= 127;
	}

	private static bool IsAsciiValue(char P_0)
	{
		return P_0 <= '\u007f';
	}

	private static void EscapeString(ReadOnlySpan<char> P_0, Span<char> P_1, JavaScriptEncoder P_2, ref int P_3)
	{
		if (P_2.Encode(P_0, P_1, out var _, out var num2) != OperationStatus.Done)
		{
			ThrowHelper.ThrowArgumentException_InvalidUTF16(P_0[num2]);
		}
		P_3 += num2;
	}

	public static void EscapeString(ReadOnlySpan<char> P_0, Span<char> P_1, int P_2, JavaScriptEncoder P_3, out int P_4)
	{
		P_0.Slice(0, P_2).CopyTo(P_1);
		P_4 = P_2;
		if (P_3 != null)
		{
			P_1 = P_1.Slice(P_2);
			P_0 = P_0.Slice(P_2);
			EscapeString(P_0, P_1, P_3, ref P_4);
			return;
		}
		while (P_2 < P_0.Length)
		{
			char c = P_0[P_2];
			if (IsAsciiValue(c))
			{
				if (NeedsEscapingNoBoundsCheck(c))
				{
					EscapeNextChars(c, P_1, ref P_4);
					P_2++;
				}
				else
				{
					P_1[P_4] = c;
					P_4++;
					P_2++;
				}
				continue;
			}
			P_1 = P_1.Slice(P_4);
			P_0 = P_0.Slice(P_2);
			EscapeString(P_0, P_1, JavaScriptEncoder.Default, ref P_4);
			break;
		}
	}

	private static void EscapeNextChars(char P_0, Span<char> P_1, ref int P_2)
	{
		P_1[P_2++] = '\\';
		switch ((byte)P_0)
		{
		case 34:
			P_1[P_2++] = 'u';
			P_1[P_2++] = '0';
			P_1[P_2++] = '0';
			P_1[P_2++] = '2';
			P_1[P_2++] = '2';
			break;
		case 10:
			P_1[P_2++] = 'n';
			break;
		case 13:
			P_1[P_2++] = 'r';
			break;
		case 9:
			P_1[P_2++] = 't';
			break;
		case 92:
			P_1[P_2++] = '\\';
			break;
		case 8:
			P_1[P_2++] = 'b';
			break;
		case 12:
			P_1[P_2++] = 'f';
			break;
		default:
		{
			P_1[P_2++] = 'u';
			int num = P_0;
			num.TryFormat(P_1.Slice(P_2), out var num2, "X4");
			P_2 += num2;
			break;
		}
		}
	}

	public unsafe static OperationStatus ToUtf8(ReadOnlySpan<byte> P_0, Span<byte> P_1, out int P_2, out int P_3)
	{
		fixed (byte* reference = &MemoryMarshal.GetReference(P_0))
		{
			fixed (byte* reference2 = &MemoryMarshal.GetReference(P_1))
			{
				char* ptr = (char*)reference;
				byte* ptr2 = reference2;
				char* ptr3 = (char*)(reference + P_0.Length);
				byte* ptr4 = ptr2 + P_1.Length;
				while (true)
				{
					IL_021c:
					if (ptr3 - ptr > 13)
					{
						int num = Math.Min(PtrDiff(ptr3, ptr), PtrDiff(ptr4, ptr2));
						char* ptr5 = ptr + num - 5;
						if (ptr < ptr5)
						{
							while (true)
							{
								int num2 = *ptr;
								ptr++;
								if (num2 > 127)
								{
									goto IL_0143;
								}
								*ptr2 = (byte)num2;
								ptr2++;
								if (((int)ptr & 2) != 0)
								{
									num2 = *ptr;
									ptr++;
									if (num2 > 127)
									{
										goto IL_0143;
									}
									*ptr2 = (byte)num2;
									ptr2++;
								}
								while (ptr < ptr5)
								{
									num2 = *(int*)ptr;
									int num3 = *(int*)(ptr + 2);
									if (((num2 | num3) & -8323200) == 0)
									{
										if (!BitConverter.IsLittleEndian)
										{
										}
										*ptr2 = (byte)num2;
										ptr2[1] = (byte)(num2 >> 16);
										ptr += 4;
										ptr2[2] = (byte)num3;
										ptr2[3] = (byte)(num3 >> 16);
										ptr2 += 4;
										continue;
									}
									goto IL_011a;
								}
								goto IL_0213;
								IL_011a:
								if (!BitConverter.IsLittleEndian)
								{
								}
								num2 = (ushort)num2;
								ptr++;
								if (num2 > 127)
								{
									goto IL_0143;
								}
								*ptr2 = (byte)num2;
								ptr2++;
								goto IL_0213;
								IL_0143:
								int num4;
								if (num2 <= 2047)
								{
									num4 = -64 | (num2 >> 6);
								}
								else
								{
									if (!JsonHelpers.IsInRangeInclusive(num2, 55296, 57343))
									{
										num4 = -32 | (num2 >> 12);
									}
									else
									{
										if (num2 > 56319)
										{
											break;
										}
										num4 = *ptr;
										if (!JsonHelpers.IsInRangeInclusive(num4, 56320, 57343))
										{
											break;
										}
										ptr++;
										num2 = num4 + (num2 << 10) + -56613888;
										*ptr2 = (byte)(-16 | (num2 >> 18));
										ptr2++;
										num4 = -128 | ((num2 >> 12) & 0x3F);
									}
									*ptr2 = (byte)num4;
									ptr5--;
									ptr2++;
									num4 = -128 | ((num2 >> 6) & 0x3F);
								}
								*ptr2 = (byte)num4;
								ptr5--;
								ptr2[1] = (byte)(-128 | (num2 & 0x3F));
								ptr2 += 2;
								goto IL_0213;
								IL_0213:
								if (ptr < ptr5)
								{
									continue;
								}
								goto IL_021c;
							}
							break;
						}
					}
					while (true)
					{
						int num5;
						int num6;
						if (ptr < ptr3)
						{
							num5 = *ptr;
							ptr++;
							if (num5 <= 127)
							{
								if (ptr4 - ptr2 > 0)
								{
									*ptr2 = (byte)num5;
									ptr2++;
									continue;
								}
							}
							else if (num5 <= 2047)
							{
								if (ptr4 - ptr2 > 1)
								{
									num6 = -64 | (num5 >> 6);
									goto IL_0342;
								}
							}
							else if (!JsonHelpers.IsInRangeInclusive(num5, 55296, 57343))
							{
								if (ptr4 - ptr2 > 2)
								{
									num6 = -32 | (num5 >> 12);
									goto IL_032a;
								}
							}
							else if (ptr4 - ptr2 > 3)
							{
								if (num5 > 56319)
								{
									break;
								}
								if (ptr < ptr3)
								{
									num6 = *ptr;
									if (!JsonHelpers.IsInRangeInclusive(num6, 56320, 57343))
									{
										break;
									}
									ptr++;
									num5 = num6 + (num5 << 10) + -56613888;
									*ptr2 = (byte)(-16 | (num5 >> 18));
									ptr2++;
									num6 = -128 | ((num5 >> 12) & 0x3F);
									goto IL_032a;
								}
								P_2 = (int)((byte*)(ptr - 1) - reference);
								P_3 = (int)(ptr2 - reference2);
								return OperationStatus.NeedMoreData;
							}
							P_2 = (int)((byte*)(ptr - 1) - reference);
							P_3 = (int)(ptr2 - reference2);
							return OperationStatus.DestinationTooSmall;
						}
						P_2 = (int)((byte*)ptr - reference);
						P_3 = (int)(ptr2 - reference2);
						return OperationStatus.Done;
						IL_032a:
						*ptr2 = (byte)num6;
						ptr2++;
						num6 = -128 | ((num5 >> 6) & 0x3F);
						goto IL_0342;
						IL_0342:
						*ptr2 = (byte)num6;
						ptr2[1] = (byte)(-128 | (num5 & 0x3F));
						ptr2 += 2;
					}
					break;
				}
				P_2 = (int)((byte*)(ptr - 1) - reference);
				P_3 = (int)(ptr2 - reference2);
				return OperationStatus.InvalidData;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static int PtrDiff(char* P_0, char* P_1)
	{
		return (int)((uint)((byte*)P_0 - (byte*)P_1) >> 1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe static int PtrDiff(byte* P_0, byte* P_1)
	{
		return (int)(P_0 - P_1);
	}
}
