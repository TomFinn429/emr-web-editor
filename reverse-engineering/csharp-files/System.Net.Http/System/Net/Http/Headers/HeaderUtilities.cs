using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace System.Net.Http.Headers;

internal static class HeaderUtilities
{
	internal static readonly TransferCodingHeaderValue TransferEncodingChunked = new TransferCodingHeaderValue("chunked");

	internal static readonly NameValueWithParametersHeaderValue ExpectContinue = new NameValueWithParametersHeaderValue("100-continue");

	internal static void CheckValidToken(string P_0, string P_1)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentException("net_http_argument_empty_string", P_1);
		}
		if (HttpRuleParser.GetTokenLength(P_0, 0) != P_0.Length)
		{
			throw new FormatException(System.SR.Format(CultureInfo.InvariantCulture, "net_http_headers_invalid_value", P_0));
		}
	}

	internal static void CheckValidComment(string P_0, string P_1)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentException("net_http_argument_empty_string", P_1);
		}
		if (HttpRuleParser.GetCommentLength(P_0, 0, out var num) != HttpParseResult.Parsed || num != P_0.Length)
		{
			throw new FormatException(System.SR.Format(CultureInfo.InvariantCulture, "net_http_headers_invalid_value", P_0));
		}
	}

	internal static void CheckValidQuotedString(string P_0, string P_1)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentException("net_http_argument_empty_string", P_1);
		}
		if (HttpRuleParser.GetQuotedStringLength(P_0, 0, out var num) != HttpParseResult.Parsed || num != P_0.Length)
		{
			throw new FormatException(System.SR.Format(CultureInfo.InvariantCulture, "net_http_headers_invalid_value", P_0));
		}
	}

	internal static bool AreEqualCollections<T>(ObjectCollection<T> P_0, ObjectCollection<T> P_1) where T : class
	{
		return AreEqualCollections(P_0, P_1, null);
	}

	internal static bool AreEqualCollections<T>(ObjectCollection<T> P_0, ObjectCollection<T> P_1, IEqualityComparer<T> P_2) where T : class
	{
		if (P_0 == null)
		{
			if (P_1 != null)
			{
				return P_1.Count == 0;
			}
			return true;
		}
		if (P_1 == null)
		{
			return P_0.Count == 0;
		}
		if (P_0.Count != P_1.Count)
		{
			return false;
		}
		if (P_0.Count == 0)
		{
			return true;
		}
		bool[] array = new bool[P_0.Count];
		int num = 0;
		foreach (T item in P_0)
		{
			num = 0;
			bool flag = false;
			foreach (T item2 in P_1)
			{
				if (!array[num] && ((P_2 == null && item.Equals(item2)) || (P_2 != null && P_2.Equals(item, item2))))
				{
					array[num] = true;
					flag = true;
					break;
				}
				num++;
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	internal static int GetNextNonEmptyOrWhitespaceIndex(string P_0, int P_1, bool P_2, out bool P_3)
	{
		P_3 = false;
		int num = P_1 + HttpRuleParser.GetWhitespaceLength(P_0, P_1);
		if (num == P_0.Length || P_0[num] != ',')
		{
			return num;
		}
		P_3 = true;
		num++;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (P_2)
		{
			while (num < P_0.Length && P_0[num] == ',')
			{
				num++;
				num += HttpRuleParser.GetWhitespaceLength(P_0, num);
			}
		}
		return num;
	}

	internal static bool TryParseInt32(string P_0, out int P_1)
	{
		return int.TryParse(P_0, NumberStyles.None, CultureInfo.InvariantCulture, out P_1);
	}

	internal static bool TryParseInt32(string P_0, int P_1, int P_2, out int P_3)
	{
		if (P_1 < 0 || P_2 < 0 || P_1 > P_0.Length - P_2)
		{
			P_3 = 0;
			return false;
		}
		return int.TryParse(P_0.AsSpan(P_1, P_2), NumberStyles.None, CultureInfo.InvariantCulture, out P_3);
	}

	internal static bool TryParseInt64(string P_0, int P_1, int P_2, out long P_3)
	{
		if (P_1 < 0 || P_2 < 0 || P_1 > P_0.Length - P_2)
		{
			P_3 = 0L;
			return false;
		}
		return long.TryParse(P_0.AsSpan(P_1, P_2), NumberStyles.None, CultureInfo.InvariantCulture, out P_3);
	}

	internal static void DumpHeaders(StringBuilder P_0, params HttpHeaders[] P_1)
	{
		P_0.AppendLine("{");
		foreach (HttpHeaders httpHeaders in P_1)
		{
			if (httpHeaders == null)
			{
				continue;
			}
			foreach (KeyValuePair<string, HeaderStringValues> item in httpHeaders.NonValidated)
			{
				foreach (string item2 in item.Value)
				{
					P_0.Append("  ");
					P_0.Append(item.Key);
					P_0.Append(": ");
					P_0.AppendLine(item2);
				}
			}
		}
		P_0.Append('}');
	}

	internal static UnvalidatedObjectCollection<NameValueHeaderValue> Clone(this UnvalidatedObjectCollection<NameValueHeaderValue> P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		UnvalidatedObjectCollection<NameValueHeaderValue> unvalidatedObjectCollection = new UnvalidatedObjectCollection<NameValueHeaderValue>();
		foreach (NameValueHeaderValue item in P_0)
		{
			unvalidatedObjectCollection.Add(new NameValueHeaderValue(item));
		}
		return unvalidatedObjectCollection;
	}
}
