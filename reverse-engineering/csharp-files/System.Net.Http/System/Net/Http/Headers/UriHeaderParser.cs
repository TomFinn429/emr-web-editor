using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Net.Http.Headers;

internal sealed class UriHeaderParser : HttpHeaderParser
{
	private readonly UriKind _uriKind;

	internal static readonly UriHeaderParser RelativeOrAbsoluteUriParser = new UriHeaderParser(UriKind.RelativeOrAbsolute);

	private UriHeaderParser(UriKind P_0)
		: base(false)
	{
		_uriKind = P_0;
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
		if (!Uri.TryCreate(text, _uriKind, out Uri uri))
		{
			text = DecodeUtf8FromString(text);
			if (!Uri.TryCreate(text, _uriKind, out uri))
			{
				return false;
			}
		}
		P_2 = P_0.Length;
		P_3 = uri;
		return true;
	}

	internal static string DecodeUtf8FromString(string P_0)
	{
		if (string.IsNullOrWhiteSpace(P_0))
		{
			return P_0;
		}
		bool flag = false;
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i] > 'ÿ')
			{
				return P_0;
			}
			if (P_0[i] > '\u007f')
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			byte[] array = new byte[P_0.Length];
			for (int j = 0; j < P_0.Length; j++)
			{
				if (P_0[j] > 'ÿ')
				{
					return P_0;
				}
				array[j] = (byte)P_0[j];
			}
			try
			{
				Encoding encoding = Encoding.GetEncoding("utf-8", EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
				return encoding.GetString(array, 0, array.Length);
			}
			catch (ArgumentException)
			{
			}
		}
		return P_0;
	}

	public override string ToString(object P_0)
	{
		Uri uri = (Uri)P_0;
		if (uri.IsAbsoluteUri)
		{
			return uri.AbsoluteUri;
		}
		return uri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped);
	}
}
