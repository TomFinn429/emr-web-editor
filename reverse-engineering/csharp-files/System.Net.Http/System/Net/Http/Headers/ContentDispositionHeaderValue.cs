using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Net.Http.Headers;

public class ContentDispositionHeaderValue : ICloneable
{
	private UnvalidatedObjectCollection<NameValueHeaderValue> _parameters;

	private string _dispositionType;

	public ICollection<NameValueHeaderValue> Parameters => _parameters ?? (_parameters = new UnvalidatedObjectCollection<NameValueHeaderValue>());

	internal ContentDispositionHeaderValue()
	{
	}

	protected ContentDispositionHeaderValue(ContentDispositionHeaderValue P_0)
	{
		_dispositionType = P_0._dispositionType;
		_parameters = P_0._parameters.Clone();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = System.Text.StringBuilderCache.Acquire();
		stringBuilder.Append(_dispositionType);
		NameValueHeaderValue.ToString(_parameters, ';', true, stringBuilder);
		return System.Text.StringBuilderCache.GetStringAndRelease(stringBuilder);
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is ContentDispositionHeaderValue contentDispositionHeaderValue))
		{
			return false;
		}
		if (string.Equals(_dispositionType, contentDispositionHeaderValue._dispositionType, StringComparison.OrdinalIgnoreCase))
		{
			return HeaderUtilities.AreEqualCollections(_parameters, contentDispositionHeaderValue._parameters);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return StringComparer.OrdinalIgnoreCase.GetHashCode(_dispositionType) ^ NameValueHeaderValue.GetHashCode(_parameters);
	}

	object ICloneable.Clone()
	{
		return new ContentDispositionHeaderValue(this);
	}

	internal static int GetDispositionTypeLength(string P_0, int P_1, out object P_2)
	{
		P_2 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		string dispositionType;
		int dispositionTypeExpressionLength = GetDispositionTypeExpressionLength(P_0, P_1, out dispositionType);
		if (dispositionTypeExpressionLength == 0)
		{
			return 0;
		}
		int num = P_1 + dispositionTypeExpressionLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		ContentDispositionHeaderValue contentDispositionHeaderValue = new ContentDispositionHeaderValue();
		contentDispositionHeaderValue._dispositionType = dispositionType;
		if (num < P_0.Length && P_0[num] == ';')
		{
			num++;
			int nameValueListLength = NameValueHeaderValue.GetNameValueListLength(P_0, num, ';', (UnvalidatedObjectCollection<NameValueHeaderValue>)contentDispositionHeaderValue.Parameters);
			if (nameValueListLength == 0)
			{
				return 0;
			}
			P_2 = contentDispositionHeaderValue;
			return num + nameValueListLength - P_1;
		}
		P_2 = contentDispositionHeaderValue;
		return num - P_1;
	}

	private static int GetDispositionTypeExpressionLength(string P_0, int P_1, out string P_2)
	{
		P_2 = null;
		int tokenLength = HttpRuleParser.GetTokenLength(P_0, P_1);
		if (tokenLength == 0)
		{
			return 0;
		}
		P_2 = P_0.Substring(P_1, tokenLength);
		return tokenLength;
	}
}
