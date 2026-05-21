using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

internal abstract class HttpHeaderParser
{
	private readonly bool _supportsMultipleValues;

	private readonly string _separator;

	public bool SupportsMultipleValues => _supportsMultipleValues;

	public string Separator => _separator;

	public virtual IEqualityComparer Comparer => null;

	protected HttpHeaderParser(bool P_0)
	{
		_supportsMultipleValues = P_0;
		if (P_0)
		{
			_separator = ", ";
		}
	}

	protected HttpHeaderParser(bool P_0, string P_1)
	{
		_supportsMultipleValues = P_0;
		_separator = P_1;
	}

	public abstract bool TryParseValue(string P_0, object P_1, ref int P_2, [NotNullWhen(true)] out object P_3);

	public virtual string ToString(object P_0)
	{
		return P_0.ToString();
	}
}
