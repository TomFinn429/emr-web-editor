using System.Runtime.CompilerServices;
using System.Text;

namespace System;

internal static class IriHelper
{
	internal static bool CheckIriUnicodeRange(char P_0, bool P_1)
	{
		if (!IsInInclusiveRange(P_0, 160u, 55295u) && !IsInInclusiveRange(P_0, 63744u, 64975u) && !IsInInclusiveRange(P_0, 65008u, 65519u))
		{
			if (P_1)
			{
				return IsInInclusiveRange(P_0, 57344u, 63743u);
			}
			return false;
		}
		return true;
	}

	internal static bool CheckIriUnicodeRange(char P_0, char P_1, out bool P_2, bool P_3)
	{
		if (Rune.TryCreate(P_0, P_1, out var rune))
		{
			P_2 = true;
			if ((rune.Value & 0xFFFF) < 65534 && (uint)(rune.Value - 917504) >= 4096u)
			{
				if (!P_3)
				{
					return rune.Value < 983040;
				}
				return true;
			}
			return false;
		}
		P_2 = false;
		return false;
	}

	internal static bool CheckIriUnicodeRange(uint P_0, bool P_1)
	{
		if (P_0 <= 65535)
		{
			if (!IsInInclusiveRange(P_0, 160u, 55295u) && !IsInInclusiveRange(P_0, 63744u, 64975u) && !IsInInclusiveRange(P_0, 65008u, 65519u))
			{
				if (P_1)
				{
					return IsInInclusiveRange(P_0, 57344u, 63743u);
				}
				return false;
			}
			return true;
		}
		if ((P_0 & 0xFFFF) < 65534 && !IsInInclusiveRange(P_0, 917504u, 921599u))
		{
			if (!P_1)
			{
				return P_0 < 983040;
			}
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsInInclusiveRange(uint P_0, uint P_1, uint P_2)
	{
		return P_0 - P_1 <= P_2 - P_1;
	}

	internal static bool CheckIsReserved(char P_0, UriComponents P_1)
	{
		if ((UriComponents.AbsoluteUri & P_1) == 0)
		{
			if (P_1 == (UriComponents)0)
			{
				return System.UriHelper.IsGenDelim(P_0);
			}
			return false;
		}
		return ";/?:@&=+$,#[]!'()*".Contains(P_0);
	}

	internal unsafe static string EscapeUnescapeIri(char* P_0, int P_1, int P_2, UriComponents P_3)
	{
		int num = P_2 - P_1;
		System.Text.ValueStringBuilder valueStringBuilder;
		if (num <= 512)
		{
			Span<char> span = stackalloc char[512];
			valueStringBuilder = new System.Text.ValueStringBuilder(span);
		}
		else
		{
			valueStringBuilder = new System.Text.ValueStringBuilder(num);
		}
		System.Text.ValueStringBuilder valueStringBuilder2 = valueStringBuilder;
		Span<byte> span2 = stackalloc byte[4];
		for (int i = P_1; i < P_2; i++)
		{
			char c = P_0[i];
			if (c == '%')
			{
				if (P_2 - i > 2)
				{
					c = System.UriHelper.DecodeHexChars(P_0[i + 1], P_0[i + 2]);
					if (c == '\uffff' || c == '%' || CheckIsReserved(c, P_3) || System.UriHelper.IsNotSafeForUnescape(c))
					{
						valueStringBuilder2.Append(P_0[i++]);
						valueStringBuilder2.Append(P_0[i++]);
						valueStringBuilder2.Append(P_0[i]);
					}
					else if (c <= '\u007f')
					{
						valueStringBuilder2.Append(c);
						i += 2;
					}
					else
					{
						int num2 = System.PercentEncodingHelper.UnescapePercentEncodedUTF8Sequence(P_0 + i, P_2 - i, ref valueStringBuilder2, P_3 == UriComponents.Query, true);
						i += num2 - 1;
					}
				}
				else
				{
					valueStringBuilder2.Append(P_0[i]);
				}
			}
			else if (c > '\u007f')
			{
				bool flag = false;
				char c2 = '\0';
				bool flag2;
				if (char.IsHighSurrogate(c) && i + 1 < P_2)
				{
					c2 = P_0[i + 1];
					flag2 = CheckIriUnicodeRange(c, c2, out flag, P_3 == UriComponents.Query);
				}
				else
				{
					flag2 = CheckIriUnicodeRange(c, P_3 == UriComponents.Query);
				}
				if (flag2)
				{
					valueStringBuilder2.Append(c);
					if (flag)
					{
						valueStringBuilder2.Append(c2);
					}
				}
				else
				{
					Rune rune;
					if (flag)
					{
						rune = new Rune(c, c2);
					}
					else if (!Rune.TryCreate(c, out rune))
					{
						rune = Rune.ReplacementChar;
					}
					int num3 = rune.EncodeToUtf8(span2);
					Span<byte> span3 = span2.Slice(0, num3);
					Span<byte> span4 = span3;
					for (int j = 0; j < span4.Length; j++)
					{
						byte b = span4[j];
						System.UriHelper.EscapeAsciiChar(b, ref valueStringBuilder2);
					}
				}
				if (flag)
				{
					i++;
				}
			}
			else
			{
				valueStringBuilder2.Append(P_0[i]);
			}
		}
		return valueStringBuilder2.ToString();
	}
}
