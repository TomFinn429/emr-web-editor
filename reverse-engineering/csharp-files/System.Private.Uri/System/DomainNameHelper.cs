using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace System;

internal static class DomainNameHelper
{
	private static readonly IdnMapping s_idnMapping = new IdnMapping();

	internal static string ParseCanonicalName(string P_0, int P_1, int P_2, ref bool P_3)
	{
		string text = null;
		for (int num = P_2 - 1; num >= P_1; num--)
		{
			if (char.IsAsciiLetterUpper(P_0[num]))
			{
				text = P_0.Substring(P_1, P_2 - P_1).ToLowerInvariant();
				break;
			}
			if (P_0[num] == ':')
			{
				P_2 = num;
			}
		}
		if (text == null)
		{
			text = P_0.Substring(P_1, P_2 - P_1);
		}
		if (text == "localhost" || text == "loopback")
		{
			P_3 = true;
			return "localhost";
		}
		return text;
	}

	internal unsafe static bool IsValid(char* P_0, int P_1, ref int P_2, ref bool P_3, bool P_4)
	{
		char* ptr = P_0 + P_1;
		char* ptr2 = ptr;
		char* ptr3;
		for (ptr3 = P_0 + P_2; ptr2 < ptr3; ptr2++)
		{
			char c = *ptr2;
			if (c > '\u007f')
			{
				return false;
			}
			if (c < 'a' && (c == '/' || c == '\\' || (P_4 && (c == ':' || c == '?' || c == '#'))))
			{
				ptr3 = ptr2;
				break;
			}
		}
		if (ptr3 == ptr)
		{
			return false;
		}
		do
		{
			for (ptr2 = ptr; ptr2 < ptr3 && *ptr2 != '.'; ptr2++)
			{
			}
			if (ptr == ptr2 || ptr2 - ptr > 63 || !IsASCIILetterOrDigit(*(ptr++), ref P_3))
			{
				return false;
			}
			while (ptr < ptr2)
			{
				if (!IsValidDomainLabelCharacter(*(ptr++), ref P_3))
				{
					return false;
				}
			}
			ptr++;
		}
		while (ptr < ptr3);
		P_2 = (int)(ptr3 - P_0);
		return true;
	}

	internal unsafe static bool IsValidByIri(char* P_0, int P_1, ref int P_2, ref bool P_3, bool P_4)
	{
		char* ptr = P_0 + P_1;
		char* ptr2 = ptr;
		char* ptr3 = P_0 + P_2;
		int num = 0;
		for (; ptr2 < ptr3; ptr2++)
		{
			char c = *ptr2;
			if (c == '/' || c == '\\' || (P_4 && (c == ':' || c == '?' || c == '#')))
			{
				ptr3 = ptr2;
				break;
			}
		}
		if (ptr3 == ptr)
		{
			return false;
		}
		do
		{
			ptr2 = ptr;
			num = 0;
			bool flag = false;
			for (; ptr2 < ptr3 && *ptr2 != '.' && *ptr2 != '。' && *ptr2 != '．' && *ptr2 != '｡'; ptr2++)
			{
				num++;
				if (*ptr2 > 'ÿ')
				{
					num++;
				}
				if (*ptr2 >= '\u00a0')
				{
					flag = true;
				}
			}
			if (ptr == ptr2 || (flag ? (num + 4) : num) > 63 || (*(ptr++) < '\u00a0' && !IsASCIILetterOrDigit(*(ptr - 1), ref P_3)))
			{
				return false;
			}
			while (ptr < ptr2)
			{
				if (*(ptr++) < '\u00a0' && !IsValidDomainLabelCharacter(*(ptr - 1), ref P_3))
				{
					return false;
				}
			}
			ptr++;
		}
		while (ptr < ptr3);
		P_2 = (int)(ptr3 - P_0);
		return true;
	}

	internal static string IdnEquivalent(string P_0)
	{
		if (P_0.Length == 0)
		{
			return P_0;
		}
		bool flag = true;
		foreach (char c in P_0)
		{
			if (c > '\u007f')
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			return P_0.ToLowerInvariant();
		}
		string text = System.UriHelper.StripBidiControlCharacters(P_0, P_0);
		try
		{
			string ascii = s_idnMapping.GetAscii(text);
			if (ContainsCharactersUnsafeForNormalizedHost(ascii))
			{
				throw new UriFormatException("net_uri_BadUnicodeHostForIdn");
			}
			return ascii;
		}
		catch (ArgumentException)
		{
			throw new UriFormatException("net_uri_BadUnicodeHostForIdn");
		}
	}

	internal static bool TryGetUnicodeEquivalent(string P_0, ref System.Text.ValueStringBuilder P_1)
	{
		int num = 0;
		do
		{
			if (num != 0)
			{
				P_1.Append('.');
			}
			bool flag = true;
			int i;
			for (i = num; (uint)i < (uint)P_0.Length; i++)
			{
				char c = P_0[i];
				if (c == '.')
				{
					break;
				}
				if (c > '\u007f')
				{
					flag = false;
					if (c == '。' || c == '．' || c == '｡')
					{
						break;
					}
				}
			}
			if (!flag)
			{
				try
				{
					string ascii = s_idnMapping.GetAscii(P_0, num, i - num);
					P_1.Append(s_idnMapping.GetUnicode(ascii));
				}
				catch (ArgumentException)
				{
					return false;
				}
			}
			else
			{
				bool flag2 = false;
				if ((uint)(num + 3) < (uint)P_0.Length && P_0[num] == 'x' && P_0[num + 1] == 'n' && P_0[num + 2] == '-' && P_0[num + 3] == '-')
				{
					try
					{
						P_1.Append(s_idnMapping.GetUnicode(P_0, num, i - num));
						flag2 = true;
					}
					catch (ArgumentException)
					{
					}
				}
				if (!flag2)
				{
					ReadOnlySpan<char> readOnlySpan = P_0.AsSpan(num, i - num);
					int num2 = readOnlySpan.ToLowerInvariant(P_1.AppendSpan(readOnlySpan.Length));
				}
			}
			num = i + 1;
		}
		while (num < P_0.Length);
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsASCIILetterOrDigit(char P_0, ref bool P_1)
	{
		if (char.IsAsciiLetterLower(P_0) || char.IsAsciiDigit(P_0))
		{
			return true;
		}
		if (char.IsAsciiLetterUpper(P_0))
		{
			P_1 = true;
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsValidDomainLabelCharacter(char P_0, ref bool P_1)
	{
		if (char.IsAsciiLetterLower(P_0) || char.IsAsciiDigit(P_0) || P_0 == '-' || P_0 == '_')
		{
			return true;
		}
		if (char.IsAsciiLetterUpper(P_0))
		{
			P_1 = true;
			return true;
		}
		return false;
	}

	internal static bool ContainsCharactersUnsafeForNormalizedHost(string P_0)
	{
		return P_0.AsSpan().IndexOfAny("\\/?@#:[]") >= 0;
	}
}
