namespace System.Net.Http;

internal static class HttpRuleParser
{
	private static readonly bool[] s_tokenChars = CreateTokenChars();

	private static bool[] CreateTokenChars()
	{
		bool[] array = new bool[128];
		for (int i = 33; i < 127; i++)
		{
			array[i] = true;
		}
		array[40] = false;
		array[41] = false;
		array[60] = false;
		array[62] = false;
		array[64] = false;
		array[44] = false;
		array[59] = false;
		array[58] = false;
		array[92] = false;
		array[34] = false;
		array[47] = false;
		array[91] = false;
		array[93] = false;
		array[63] = false;
		array[61] = false;
		array[123] = false;
		array[125] = false;
		return array;
	}

	internal static bool IsTokenChar(char P_0)
	{
		if (P_0 > '\u007f')
		{
			return false;
		}
		return s_tokenChars[(uint)P_0];
	}

	internal static int GetTokenLength(string P_0, int P_1)
	{
		if (P_1 >= P_0.Length)
		{
			return 0;
		}
		for (int i = P_1; i < P_0.Length; i++)
		{
			if (!IsTokenChar(P_0[i]))
			{
				return i - P_1;
			}
		}
		return P_0.Length - P_1;
	}

	internal static bool IsToken(string P_0)
	{
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!IsTokenChar(P_0[i]))
			{
				return false;
			}
		}
		return true;
	}

	internal static int GetWhitespaceLength(string P_0, int P_1)
	{
		if (P_1 >= P_0.Length)
		{
			return 0;
		}
		for (int i = P_1; i < P_0.Length; i++)
		{
			char c = P_0[i];
			if (c != ' ' && c != '\t')
			{
				return i - P_1;
			}
		}
		return P_0.Length - P_1;
	}

	internal static bool ContainsNewLine(string P_0, int P_1 = 0)
	{
		return P_0.AsSpan(P_1).IndexOfAny('\r', '\n') != -1;
	}

	internal static int GetNumberLength(string P_0, int P_1, bool P_2)
	{
		int num = P_1;
		bool flag = !P_2;
		if (P_0[num] == '.')
		{
			return 0;
		}
		while (num < P_0.Length)
		{
			char c = P_0[num];
			if (char.IsAsciiDigit(c))
			{
				num++;
				continue;
			}
			if (flag || c != '.')
			{
				break;
			}
			flag = true;
			num++;
		}
		return num - P_1;
	}

	internal static int GetHostLength(string P_0, int P_1, bool P_2)
	{
		if (P_1 >= P_0.Length)
		{
			return 0;
		}
		int i = P_1;
		bool flag;
		bool num;
		for (flag = true; i < P_0.Length; flag = num, i++)
		{
			char c = P_0[i];
			switch (c)
			{
			case '/':
				return 0;
			default:
				num = flag && IsTokenChar(c);
				continue;
			case '\t':
			case '\r':
			case ' ':
			case ',':
				break;
			}
			break;
		}
		int num2 = i - P_1;
		if (num2 == 0)
		{
			return 0;
		}
		if ((!P_2 || !flag) && !IsValidHostName(P_0.AsSpan(P_1, num2)))
		{
			return 0;
		}
		return num2;
	}

	internal static HttpParseResult GetCommentLength(string P_0, int P_1, out int P_2)
	{
		return GetExpressionLength(P_0, P_1, '(', ')', true, 1, out P_2);
	}

	internal static HttpParseResult GetQuotedStringLength(string P_0, int P_1, out int P_2)
	{
		return GetExpressionLength(P_0, P_1, '"', '"', false, 1, out P_2);
	}

	internal static HttpParseResult GetQuotedPairLength(string P_0, int P_1, out int P_2)
	{
		P_2 = 0;
		if (P_0[P_1] != '\\')
		{
			return HttpParseResult.NotParsed;
		}
		if (P_1 + 2 > P_0.Length || P_0[P_1 + 1] > '\u007f')
		{
			return HttpParseResult.InvalidFormat;
		}
		P_2 = 2;
		return HttpParseResult.Parsed;
	}

	private static HttpParseResult GetExpressionLength(string P_0, int P_1, char P_2, char P_3, bool P_4, int P_5, out int P_6)
	{
		P_6 = 0;
		if (P_0[P_1] != P_2)
		{
			return HttpParseResult.NotParsed;
		}
		int num = P_1 + 1;
		while (num < P_0.Length)
		{
			if (num + 2 < P_0.Length && GetQuotedPairLength(P_0, num, out var num2) == HttpParseResult.Parsed)
			{
				num += num2;
				continue;
			}
			char c = P_0[num];
			if (c == '\r' || c == '\n')
			{
				return HttpParseResult.InvalidFormat;
			}
			if (P_4 && c == P_2)
			{
				if (P_5 > 5)
				{
					return HttpParseResult.InvalidFormat;
				}
				int num3;
				switch (GetExpressionLength(P_0, num, P_2, P_3, P_4, P_5 + 1, out num3))
				{
				case HttpParseResult.Parsed:
					num += num3;
					break;
				case HttpParseResult.InvalidFormat:
					return HttpParseResult.InvalidFormat;
				}
			}
			else
			{
				if (P_0[num] == P_3)
				{
					P_6 = num - P_1 + 1;
					return HttpParseResult.Parsed;
				}
				num++;
			}
		}
		return HttpParseResult.InvalidFormat;
	}

	private static bool IsValidHostName(ReadOnlySpan<char> P_0)
	{
		Uri uri;
		return Uri.TryCreate($"http://u@{P_0}/", UriKind.Absolute, out uri);
	}
}
