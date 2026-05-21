using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Net.Http.Headers;

public class TransferCodingHeaderValue : ICloneable
{
	private UnvalidatedObjectCollection<NameValueHeaderValue> _parameters;

	private string _value;

	public ICollection<NameValueHeaderValue> Parameters => _parameters ?? (_parameters = new UnvalidatedObjectCollection<NameValueHeaderValue>());

	internal TransferCodingHeaderValue()
	{
	}

	protected TransferCodingHeaderValue(TransferCodingHeaderValue P_0)
	{
		_value = P_0._value;
		_parameters = P_0._parameters.Clone();
	}

	public TransferCodingHeaderValue(string P_0)
	{
		HeaderUtilities.CheckValidToken(P_0, "value");
		_value = P_0;
	}

	internal static int GetTransferCodingLength(string P_0, int P_1, Func<TransferCodingHeaderValue> P_2, out TransferCodingHeaderValue P_3)
	{
		P_3 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int tokenLength = HttpRuleParser.GetTokenLength(P_0, P_1);
		if (tokenLength == 0)
		{
			return 0;
		}
		string value = P_0.Substring(P_1, tokenLength);
		int num = P_1 + tokenLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		TransferCodingHeaderValue transferCodingHeaderValue;
		if (num < P_0.Length && P_0[num] == ';')
		{
			transferCodingHeaderValue = P_2();
			transferCodingHeaderValue._value = value;
			num++;
			int nameValueListLength = NameValueHeaderValue.GetNameValueListLength(P_0, num, ';', (UnvalidatedObjectCollection<NameValueHeaderValue>)transferCodingHeaderValue.Parameters);
			if (nameValueListLength == 0)
			{
				return 0;
			}
			P_3 = transferCodingHeaderValue;
			return num + nameValueListLength - P_1;
		}
		transferCodingHeaderValue = P_2();
		transferCodingHeaderValue._value = value;
		P_3 = transferCodingHeaderValue;
		return num - P_1;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = System.Text.StringBuilderCache.Acquire();
		stringBuilder.Append(_value);
		NameValueHeaderValue.ToString(_parameters, ';', true, stringBuilder);
		return System.Text.StringBuilderCache.GetStringAndRelease(stringBuilder);
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is TransferCodingHeaderValue transferCodingHeaderValue))
		{
			return false;
		}
		if (string.Equals(_value, transferCodingHeaderValue._value, StringComparison.OrdinalIgnoreCase))
		{
			return HeaderUtilities.AreEqualCollections(_parameters, transferCodingHeaderValue._parameters);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return StringComparer.OrdinalIgnoreCase.GetHashCode(_value) ^ NameValueHeaderValue.GetHashCode(_parameters);
	}

	object ICloneable.Clone()
	{
		return new TransferCodingHeaderValue(this);
	}
}
