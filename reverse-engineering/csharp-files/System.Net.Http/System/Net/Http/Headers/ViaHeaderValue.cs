using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace System.Net.Http.Headers;

public class ViaHeaderValue : ICloneable
{
	private readonly string _protocolName;

	private readonly string _protocolVersion;

	private readonly string _receivedBy;

	private readonly string _comment;

	public ViaHeaderValue(string P_0, string P_1, string? P_2, string? P_3)
	{
		HeaderUtilities.CheckValidToken(P_0, "protocolVersion");
		CheckReceivedBy(P_1);
		if (!string.IsNullOrEmpty(P_2))
		{
			HeaderUtilities.CheckValidToken(P_2, "protocolName");
			_protocolName = P_2;
		}
		if (!string.IsNullOrEmpty(P_3))
		{
			HeaderUtilities.CheckValidComment(P_3, "comment");
			_comment = P_3;
		}
		_protocolVersion = P_0;
		_receivedBy = P_1;
	}

	private ViaHeaderValue(ViaHeaderValue P_0)
	{
		_protocolName = P_0._protocolName;
		_protocolVersion = P_0._protocolVersion;
		_receivedBy = P_0._receivedBy;
		_comment = P_0._comment;
	}

	public override string ToString()
	{
		Span<char> span = stackalloc char[256];
		System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
		if (!string.IsNullOrEmpty(_protocolName))
		{
			valueStringBuilder.Append(_protocolName);
			valueStringBuilder.Append('/');
		}
		valueStringBuilder.Append(_protocolVersion);
		valueStringBuilder.Append(' ');
		valueStringBuilder.Append(_receivedBy);
		if (!string.IsNullOrEmpty(_comment))
		{
			valueStringBuilder.Append(' ');
			valueStringBuilder.Append(_comment);
		}
		return valueStringBuilder.ToString();
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is ViaHeaderValue viaHeaderValue))
		{
			return false;
		}
		if (string.Equals(_protocolVersion, viaHeaderValue._protocolVersion, StringComparison.OrdinalIgnoreCase) && string.Equals(_receivedBy, viaHeaderValue._receivedBy, StringComparison.OrdinalIgnoreCase) && string.Equals(_protocolName, viaHeaderValue._protocolName, StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(_comment, viaHeaderValue._comment, StringComparison.Ordinal);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_protocolVersion) ^ StringComparer.OrdinalIgnoreCase.GetHashCode(_receivedBy);
		if (!string.IsNullOrEmpty(_protocolName))
		{
			num ^= StringComparer.OrdinalIgnoreCase.GetHashCode(_protocolName);
		}
		if (!string.IsNullOrEmpty(_comment))
		{
			num ^= _comment.GetHashCode();
		}
		return num;
	}

	internal static int GetViaLength(string P_0, int P_1, out object P_2)
	{
		P_2 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int protocolEndIndex = GetProtocolEndIndex(P_0, P_1, out var text, out var text2);
		if (protocolEndIndex == 0 || protocolEndIndex == P_0.Length)
		{
			return 0;
		}
		int hostLength = HttpRuleParser.GetHostLength(P_0, protocolEndIndex, true);
		if (hostLength == 0)
		{
			return 0;
		}
		string text3 = P_0.Substring(protocolEndIndex, hostLength);
		protocolEndIndex += hostLength;
		protocolEndIndex += HttpRuleParser.GetWhitespaceLength(P_0, protocolEndIndex);
		string text4 = null;
		if (protocolEndIndex < P_0.Length && P_0[protocolEndIndex] == '(')
		{
			if (HttpRuleParser.GetCommentLength(P_0, protocolEndIndex, out var num) != HttpParseResult.Parsed)
			{
				return 0;
			}
			text4 = P_0.Substring(protocolEndIndex, num);
			protocolEndIndex += num;
			protocolEndIndex += HttpRuleParser.GetWhitespaceLength(P_0, protocolEndIndex);
		}
		P_2 = new ViaHeaderValue(text2, text3, text, text4);
		return protocolEndIndex - P_1;
	}

	private static int GetProtocolEndIndex(string P_0, int P_1, out string P_2, out string P_3)
	{
		P_2 = null;
		P_3 = null;
		int num = P_1;
		int tokenLength = HttpRuleParser.GetTokenLength(P_0, num);
		if (tokenLength == 0)
		{
			return 0;
		}
		num = P_1 + tokenLength;
		int whitespaceLength = HttpRuleParser.GetWhitespaceLength(P_0, num);
		num += whitespaceLength;
		if (num == P_0.Length)
		{
			return 0;
		}
		if (P_0[num] == '/')
		{
			P_2 = P_0.Substring(P_1, tokenLength);
			num++;
			num += HttpRuleParser.GetWhitespaceLength(P_0, num);
			tokenLength = HttpRuleParser.GetTokenLength(P_0, num);
			if (tokenLength == 0)
			{
				return 0;
			}
			P_3 = P_0.Substring(num, tokenLength);
			num += tokenLength;
			whitespaceLength = HttpRuleParser.GetWhitespaceLength(P_0, num);
			num += whitespaceLength;
		}
		else
		{
			P_3 = P_0.Substring(P_1, tokenLength);
		}
		if (whitespaceLength == 0)
		{
			return 0;
		}
		return num;
	}

	object ICloneable.Clone()
	{
		return new ViaHeaderValue(this);
	}

	private static void CheckReceivedBy(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentException("net_http_argument_empty_string", "receivedBy");
		}
		if (HttpRuleParser.GetHostLength(P_0, 0, true) != P_0.Length)
		{
			throw new FormatException(System.SR.Format(CultureInfo.InvariantCulture, "net_http_headers_invalid_value", P_0));
		}
	}
}
