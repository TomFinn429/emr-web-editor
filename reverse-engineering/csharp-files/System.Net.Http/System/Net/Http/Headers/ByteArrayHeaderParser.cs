using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

internal sealed class ByteArrayHeaderParser : HttpHeaderParser
{
	internal static readonly ByteArrayHeaderParser Parser = new ByteArrayHeaderParser();

	private ByteArrayHeaderParser()
		: base(false)
	{
	}

	public override string ToString(object P_0)
	{
		return Convert.ToBase64String((byte[])P_0);
	}

	public override bool TryParseValue([NotNullWhen(true)] string P_0, object P_1, ref int P_2, [NotNullWhen(true)] out object P_3)
	{
		P_3 = null;
		if (string.IsNullOrEmpty(P_0) || P_2 == P_0.Length)
		{
			return false;
		}
		string text = P_0;
		if (P_2 > 0)
		{
			text = P_0.Substring(P_2);
		}
		try
		{
			P_3 = Convert.FromBase64String(text);
			P_2 = P_0.Length;
			return true;
		}
		catch (FormatException)
		{
			if (!NetEventSource.Log.IsEnabled())
			{
			}
		}
		return false;
	}
}
