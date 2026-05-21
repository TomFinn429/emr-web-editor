using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Net.Http.Headers;

public class NameValueWithParametersHeaderValue : NameValueHeaderValue, ICloneable
{
	private static readonly Func<NameValueHeaderValue> s_nameValueCreator = CreateNameValue;

	private UnvalidatedObjectCollection<NameValueHeaderValue> _parameters;

	public ICollection<NameValueHeaderValue> Parameters => _parameters ?? (_parameters = new UnvalidatedObjectCollection<NameValueHeaderValue>());

	public NameValueWithParametersHeaderValue(string P_0)
		: base(P_0)
	{
	}

	internal NameValueWithParametersHeaderValue()
	{
	}

	protected NameValueWithParametersHeaderValue(NameValueWithParametersHeaderValue P_0)
		: base(P_0)
	{
		_parameters = P_0._parameters.Clone();
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (base.Equals(P_0))
		{
			if (!(P_0 is NameValueWithParametersHeaderValue nameValueWithParametersHeaderValue))
			{
				return false;
			}
			return HeaderUtilities.AreEqualCollections(_parameters, nameValueWithParametersHeaderValue._parameters);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode() ^ NameValueHeaderValue.GetHashCode(_parameters);
	}

	public override string ToString()
	{
		string text = base.ToString();
		StringBuilder stringBuilder = System.Text.StringBuilderCache.Acquire();
		stringBuilder.Append(text);
		NameValueHeaderValue.ToString(_parameters, ';', true, stringBuilder);
		return System.Text.StringBuilderCache.GetStringAndRelease(stringBuilder);
	}

	internal static int GetNameValueWithParametersLength(string P_0, int P_1, out object P_2)
	{
		P_2 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		NameValueHeaderValue nameValueHeaderValue;
		int nameValueLength = NameValueHeaderValue.GetNameValueLength(P_0, P_1, s_nameValueCreator, out nameValueHeaderValue);
		if (nameValueLength == 0)
		{
			return 0;
		}
		int num = P_1 + nameValueLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		NameValueWithParametersHeaderValue nameValueWithParametersHeaderValue = nameValueHeaderValue as NameValueWithParametersHeaderValue;
		if (num < P_0.Length && P_0[num] == ';')
		{
			num++;
			int nameValueListLength = NameValueHeaderValue.GetNameValueListLength(P_0, num, ';', (UnvalidatedObjectCollection<NameValueHeaderValue>)nameValueWithParametersHeaderValue.Parameters);
			if (nameValueListLength == 0)
			{
				return 0;
			}
			P_2 = nameValueWithParametersHeaderValue;
			return num + nameValueListLength - P_1;
		}
		P_2 = nameValueWithParametersHeaderValue;
		return num - P_1;
	}

	private static NameValueHeaderValue CreateNameValue()
	{
		return new NameValueWithParametersHeaderValue();
	}

	object ICloneable.Clone()
	{
		return new NameValueWithParametersHeaderValue(this);
	}
}
