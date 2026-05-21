using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

public class EntityTagHeaderValue : ICloneable
{
	private readonly string _tag;

	private readonly bool _isWeak;

	public static EntityTagHeaderValue Any { get; } = new EntityTagHeaderValue();

	private EntityTagHeaderValue()
	{
		_tag = "*";
	}

	public EntityTagHeaderValue(string P_0)
		: this(P_0, false)
	{
	}

	public EntityTagHeaderValue(string P_0, bool P_1)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentException("net_http_argument_empty_string", "tag");
		}
		if (HttpRuleParser.GetQuotedStringLength(P_0, 0, out var num) != HttpParseResult.Parsed || num != P_0.Length)
		{
			throw new FormatException("net_http_headers_invalid_etag_name");
		}
		_tag = P_0;
		_isWeak = P_1;
	}

	private EntityTagHeaderValue(EntityTagHeaderValue P_0)
	{
		_tag = P_0._tag;
		_isWeak = P_0._isWeak;
	}

	public override string ToString()
	{
		if (_isWeak)
		{
			return "W/" + _tag;
		}
		return _tag;
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is EntityTagHeaderValue entityTagHeaderValue))
		{
			return false;
		}
		if (_isWeak == entityTagHeaderValue._isWeak)
		{
			return string.Equals(_tag, entityTagHeaderValue._tag, StringComparison.Ordinal);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _tag.GetHashCode() ^ _isWeak.GetHashCode();
	}

	internal static int GetEntityTagLength(string P_0, int P_1, out EntityTagHeaderValue P_2)
	{
		P_2 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		bool flag = false;
		int num = P_1;
		char c = P_0[P_1];
		if (c == '*')
		{
			P_2 = Any;
			num++;
		}
		else
		{
			if (c == 'W' || c == 'w')
			{
				num++;
				if (num + 2 >= P_0.Length || P_0[num] != '/')
				{
					return 0;
				}
				flag = true;
				num++;
				num += HttpRuleParser.GetWhitespaceLength(P_0, num);
			}
			int num2 = num;
			if (HttpRuleParser.GetQuotedStringLength(P_0, num, out var num3) != HttpParseResult.Parsed)
			{
				return 0;
			}
			if (num3 == P_0.Length)
			{
				P_2 = new EntityTagHeaderValue(P_0);
			}
			else
			{
				P_2 = new EntityTagHeaderValue(P_0.Substring(num2, num3), flag);
			}
			num += num3;
		}
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		return num - P_1;
	}

	object ICloneable.Clone()
	{
		if (this != Any)
		{
			return new EntityTagHeaderValue(this);
		}
		return Any;
	}
}
