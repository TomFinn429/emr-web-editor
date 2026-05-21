using System.Runtime.InteropServices;
using System.Text;

namespace System;

internal static class UriHelper
{
	internal static readonly char[] s_WSchars = new char[4] { ' ', '\n', '\r', '\t' };

	internal static ReadOnlySpan<bool> UnreservedReservedTable => new bool[128]
	{
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, true, false, true, true, false, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		false, true, false, true, true, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, false, true, false, true, false, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, true, false, false, false, true, false
	};

	internal static ReadOnlySpan<bool> UnreservedTable => new bool[128]
	{
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, false, false, false, false, false,
		false, false, false, false, false, true, true, false, true, true,
		true, true, true, true, true, true, true, true, false, false,
		false, false, false, false, false, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, false, false, false, false, true, false, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, true, true, true, true, true, true, true, true,
		true, true, true, false, false, false, true, false
	};

	internal static string EscapeString(string P_0, bool P_1, ReadOnlySpan<bool> P_2, char P_3 = '\0', char P_4 = '\0')
	{
		ArgumentNullException.ThrowIfNull(P_0, "stringToEscape");
		if (P_0.Length == 0)
		{
			return string.Empty;
		}
		ReadOnlySpan<bool> readOnlySpan;
		if ((P_3 | P_4) == 0)
		{
			readOnlySpan = P_2;
		}
		else
		{
			Span<bool> span = stackalloc bool[128];
			P_2.CopyTo(span);
			span[P_3] = false;
			span[P_4] = false;
			readOnlySpan = span;
		}
		int i;
		for (i = 0; i < P_0.Length; i++)
		{
			char c;
			if ((c = P_0[i]) > '\u007f')
			{
				break;
			}
			if (!readOnlySpan[c])
			{
				break;
			}
		}
		if (i == P_0.Length)
		{
			return P_0;
		}
		Span<char> span2 = stackalloc char[512];
		System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span2);
		valueStringBuilder.Append(P_0.AsSpan(0, i));
		EscapeStringToBuilder(P_0.AsSpan(i), ref valueStringBuilder, readOnlySpan, P_1);
		return valueStringBuilder.ToString();
	}

	internal static void EscapeString(ReadOnlySpan<char> P_0, ref System.Text.ValueStringBuilder P_1, bool P_2, char P_3 = '\0', char P_4 = '\0')
	{
		ReadOnlySpan<bool> readOnlySpan;
		if ((P_3 | P_4) == 0)
		{
			readOnlySpan = UnreservedReservedTable;
		}
		else
		{
			Span<bool> span = stackalloc bool[128];
			UnreservedReservedTable.CopyTo(span);
			span[P_3] = false;
			span[P_4] = false;
			readOnlySpan = span;
		}
		int i;
		for (i = 0; i < P_0.Length; i++)
		{
			char c;
			if ((c = P_0[i]) > '\u007f')
			{
				break;
			}
			if (!readOnlySpan[c])
			{
				break;
			}
		}
		if (i == P_0.Length)
		{
			P_1.Append(P_0);
			return;
		}
		P_1.Append(P_0.Slice(0, i));
		ReadOnlySpan<bool> readOnlySpan2 = MemoryMarshal.CreateReadOnlySpan(ref MemoryMarshal.GetReference(readOnlySpan), readOnlySpan.Length);
		EscapeStringToBuilder(P_0.Slice(i), ref P_1, readOnlySpan2, P_2);
	}

	private static void EscapeStringToBuilder(ReadOnlySpan<char> P_0, ref System.Text.ValueStringBuilder P_1, ReadOnlySpan<bool> P_2, bool P_3)
	{
		Span<byte> span = stackalloc byte[4];
		SpanRuneEnumerator spanRuneEnumerator = P_0.EnumerateRunes();
		while (spanRuneEnumerator.MoveNext())
		{
			Rune current = spanRuneEnumerator.Current;
			if (!current.IsAscii)
			{
				current.TryEncodeToUtf8(span, out var num);
				Span<byte> span2 = span.Slice(0, num);
				for (int i = 0; i < span2.Length; i++)
				{
					byte b = span2[i];
					P_1.Append('%');
					System.HexConverter.ToCharsBuffer(b, P_1.AppendSpan(2));
				}
				continue;
			}
			byte b2 = (byte)current.Value;
			if (P_2[b2])
			{
				P_1.Append((char)b2);
				continue;
			}
			if (P_3 && b2 == 37)
			{
				SpanRuneEnumerator spanRuneEnumerator2 = spanRuneEnumerator;
				if (spanRuneEnumerator2.MoveNext())
				{
					Rune current2 = spanRuneEnumerator2.Current;
					if (current2.IsAscii && char.IsAsciiHexDigit((char)current2.Value) && spanRuneEnumerator2.MoveNext())
					{
						Rune current3 = spanRuneEnumerator2.Current;
						if (current3.IsAscii && char.IsAsciiHexDigit((char)current3.Value))
						{
							P_1.Append('%');
							P_1.Append((char)current2.Value);
							P_1.Append((char)current3.Value);
							spanRuneEnumerator = spanRuneEnumerator2;
							continue;
						}
					}
				}
			}
			P_1.Append('%');
			System.HexConverter.ToCharsBuffer(b2, P_1.AppendSpan(2));
		}
	}

	internal unsafe static char[] UnescapeString(string P_0, int P_1, int P_2, char[] P_3, ref int P_4, char P_5, char P_6, char P_7, System.UnescapeMode P_8, UriParser P_9, bool P_10)
	{
		fixed (char* ptr = P_0)
		{
			return UnescapeString(ptr, P_1, P_2, P_3, ref P_4, P_5, P_6, P_7, P_8, P_9, P_10);
		}
	}

	internal unsafe static char[] UnescapeString(char* P_0, int P_1, int P_2, char[] P_3, ref int P_4, char P_5, char P_6, char P_7, System.UnescapeMode P_8, UriParser P_9, bool P_10)
	{
		System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(P_3.Length);
		valueStringBuilder.Append(P_3.AsSpan(0, P_4));
		UnescapeString(P_0, P_1, P_2, ref valueStringBuilder, P_5, P_6, P_7, P_8, P_9, P_10);
		if (valueStringBuilder.Length > P_3.Length)
		{
			P_3 = valueStringBuilder.AsSpan().ToArray();
		}
		else
		{
			valueStringBuilder.AsSpan(P_4).TryCopyTo(P_3.AsSpan(P_4));
		}
		P_4 = valueStringBuilder.Length;
		valueStringBuilder.Dispose();
		return P_3;
	}

	internal unsafe static void UnescapeString(string P_0, int P_1, int P_2, ref System.Text.ValueStringBuilder P_3, char P_4, char P_5, char P_6, System.UnescapeMode P_7, UriParser P_8, bool P_9)
	{
		fixed (char* ptr = P_0)
		{
			UnescapeString(ptr, P_1, P_2, ref P_3, P_4, P_5, P_6, P_7, P_8, P_9);
		}
	}

	internal unsafe static void UnescapeString(ReadOnlySpan<char> P_0, ref System.Text.ValueStringBuilder P_1, char P_2, char P_3, char P_4, System.UnescapeMode P_5, UriParser P_6, bool P_7)
	{
		fixed (char* reference = &MemoryMarshal.GetReference(P_0))
		{
			UnescapeString(reference, 0, P_0.Length, ref P_1, P_2, P_3, P_4, P_5, P_6, P_7);
		}
	}

	internal unsafe static void UnescapeString(char* P_0, int P_1, int P_2, ref System.Text.ValueStringBuilder P_3, char P_4, char P_5, char P_6, System.UnescapeMode P_7, UriParser P_8, bool P_9)
	{
		if ((P_7 & System.UnescapeMode.EscapeUnescape) == 0)
		{
			P_3.Append(P_0 + P_1, P_2 - P_1);
			return;
		}
		bool flag = false;
		bool flag2 = Uri.IriParsingStatic(P_8) && (P_7 & System.UnescapeMode.EscapeUnescape) == System.UnescapeMode.EscapeUnescape;
		int i = P_1;
		while (i < P_2)
		{
			char c = '\0';
			for (; i < P_2; i++)
			{
				if ((c = P_0[i]) == '%')
				{
					if ((P_7 & System.UnescapeMode.Unescape) == 0)
					{
						flag = true;
						break;
					}
					if (i + 2 < P_2)
					{
						c = DecodeHexChars(P_0[i + 1], P_0[i + 2]);
						if (P_7 < System.UnescapeMode.UnescapeAll)
						{
							switch (c)
							{
							case '\uffff':
								if ((P_7 & System.UnescapeMode.Escape) == 0)
								{
									continue;
								}
								flag = true;
								break;
							case '%':
								i += 2;
								continue;
							default:
								if (c == P_4 || c == P_5 || c == P_6)
								{
									i += 2;
									continue;
								}
								if ((P_7 & System.UnescapeMode.V1ToStringFlag) == 0 && IsNotSafeForUnescape(c))
								{
									i += 2;
									continue;
								}
								if (flag2 && ((c <= '\u009f' && IsNotSafeForUnescape(c)) || (c > '\u009f' && !System.IriHelper.CheckIriUnicodeRange(c, P_9))))
								{
									i += 2;
									continue;
								}
								break;
							}
							break;
						}
						if (c != '\uffff')
						{
							break;
						}
						if (P_7 >= System.UnescapeMode.UnescapeAllOrThrow)
						{
							throw new UriFormatException("net_uri_BadString");
						}
					}
					else
					{
						if (P_7 < System.UnescapeMode.UnescapeAll)
						{
							flag = true;
							break;
						}
						if (P_7 >= System.UnescapeMode.UnescapeAllOrThrow)
						{
							throw new UriFormatException("net_uri_BadString");
						}
					}
				}
				else if ((P_7 & (System.UnescapeMode.Unescape | System.UnescapeMode.UnescapeAll)) != (System.UnescapeMode.Unescape | System.UnescapeMode.UnescapeAll) && (P_7 & System.UnescapeMode.Escape) != System.UnescapeMode.CopyOnly)
				{
					if (c == P_4 || c == P_5 || c == P_6)
					{
						flag = true;
						break;
					}
					if ((P_7 & System.UnescapeMode.V1ToStringFlag) == 0 && (c <= '\u001f' || (c >= '\u007f' && c <= '\u009f')))
					{
						flag = true;
						break;
					}
				}
			}
			while (P_1 < i)
			{
				P_3.Append(P_0[P_1++]);
			}
			if (i != P_2)
			{
				if (flag)
				{
					EscapeAsciiChar((byte)P_0[i], ref P_3);
					flag = false;
					i++;
				}
				else if (c <= '\u007f')
				{
					P_3.Append(c);
					i += 3;
				}
				else
				{
					int num = System.PercentEncodingHelper.UnescapePercentEncodedUTF8Sequence(P_0 + i, P_2 - i, ref P_3, P_9, flag2);
					i += num;
				}
				P_1 = i;
			}
		}
	}

	internal static void EscapeAsciiChar(byte P_0, ref System.Text.ValueStringBuilder P_1)
	{
		P_1.Append('%');
		System.HexConverter.ToCharsBuffer(P_0, P_1.AppendSpan(2));
	}

	internal static char DecodeHexChars(int P_0, int P_1)
	{
		int num = System.HexConverter.FromChar(P_0);
		int num2 = System.HexConverter.FromChar(P_1);
		if ((num | num2) == 255)
		{
			return '\uffff';
		}
		return (char)((num << 4) | num2);
	}

	internal static bool IsNotSafeForUnescape(char P_0)
	{
		if (P_0 <= '\u001f' || (P_0 >= '\u007f' && P_0 <= '\u009f'))
		{
			return true;
		}
		return ";/?:@&=+$,#[]!'()*%\\#".Contains(P_0);
	}

	internal static bool IsGenDelim(char P_0)
	{
		if (P_0 != ':' && P_0 != '/' && P_0 != '?' && P_0 != '#' && P_0 != '[' && P_0 != ']')
		{
			return P_0 == '@';
		}
		return true;
	}

	internal static bool IsLWS(char P_0)
	{
		if (P_0 <= ' ')
		{
			if (P_0 != ' ' && P_0 != '\n' && P_0 != '\r')
			{
				return P_0 == '\t';
			}
			return true;
		}
		return false;
	}

	internal static bool IsBidiControlCharacter(char P_0)
	{
		if (P_0 != '\u200e' && P_0 != '\u200f' && P_0 != '\u202a' && P_0 != '\u202b' && P_0 != '\u202c' && P_0 != '\u202d')
		{
			return P_0 == '\u202e';
		}
		return true;
	}

	internal unsafe static string StripBidiControlCharacters(ReadOnlySpan<char> P_0, string P_1 = null)
	{
		int num = 0;
		ReadOnlySpan<char> readOnlySpan = P_0;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			char c = readOnlySpan[i];
			if ((uint)(c - 8206) <= 32u && IsBidiControlCharacter(c))
			{
				num++;
			}
		}
		if (num == 0)
		{
			return P_1 ?? new string(P_0);
		}
		if (num == P_0.Length)
		{
			return string.Empty;
		}
		fixed (char* reference = &MemoryMarshal.GetReference(P_0))
		{
			return string.Create(P_0.Length - num, ((nint)reference, P_0.Length), delegate(Span<char> span, (nint StrToClean, int Length) tuple)
			{
				ReadOnlySpan<char> readOnlySpan2 = new ReadOnlySpan<char>((void*)tuple.StrToClean, tuple.Length);
				int num2 = 0;
				ReadOnlySpan<char> readOnlySpan3 = readOnlySpan2;
				for (int j = 0; j < readOnlySpan3.Length; j++)
				{
					char c2 = readOnlySpan3[j];
					if ((uint)(c2 - 8206) > 32u || !IsBidiControlCharacter(c2))
					{
						span[num2++] = c2;
					}
				}
			});
		}
	}
}
