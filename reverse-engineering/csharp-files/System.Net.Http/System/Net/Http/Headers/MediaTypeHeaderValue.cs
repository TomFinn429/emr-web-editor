using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Net.Http.Headers;

public class MediaTypeHeaderValue : ICloneable
{
	private UnvalidatedObjectCollection<NameValueHeaderValue> _parameters;

	private string _mediaType;

	public string? CharSet => NameValueHeaderValue.Find(_parameters, "charset")?.Value;

	public ICollection<NameValueHeaderValue> Parameters => _parameters ?? (_parameters = new UnvalidatedObjectCollection<NameValueHeaderValue>());

	internal MediaTypeHeaderValue()
	{
	}

	protected MediaTypeHeaderValue(MediaTypeHeaderValue P_0)
	{
		_mediaType = P_0._mediaType;
		_parameters = P_0._parameters.Clone();
	}

	public override string ToString()
	{
		if (_parameters == null || _parameters.Count == 0)
		{
			return _mediaType ?? string.Empty;
		}
		StringBuilder stringBuilder = System.Text.StringBuilderCache.Acquire();
		stringBuilder.Append(_mediaType);
		NameValueHeaderValue.ToString(_parameters, ';', true, stringBuilder);
		return System.Text.StringBuilderCache.GetStringAndRelease(stringBuilder);
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (P_0 is MediaTypeHeaderValue mediaTypeHeaderValue && string.Equals(_mediaType, mediaTypeHeaderValue._mediaType, StringComparison.OrdinalIgnoreCase))
		{
			return HeaderUtilities.AreEqualCollections(_parameters, mediaTypeHeaderValue._parameters);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return StringComparer.OrdinalIgnoreCase.GetHashCode(_mediaType) ^ NameValueHeaderValue.GetHashCode(_parameters);
	}

	internal static int GetMediaTypeLength(string P_0, int P_1, Func<MediaTypeHeaderValue> P_2, out MediaTypeHeaderValue P_3)
	{
		P_3 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		string mediaType;
		int mediaTypeExpressionLength = GetMediaTypeExpressionLength(P_0, P_1, out mediaType);
		if (mediaTypeExpressionLength == 0)
		{
			return 0;
		}
		int num = P_1 + mediaTypeExpressionLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		MediaTypeHeaderValue mediaTypeHeaderValue;
		if (num < P_0.Length && P_0[num] == ';')
		{
			mediaTypeHeaderValue = P_2();
			mediaTypeHeaderValue._mediaType = mediaType;
			num++;
			int nameValueListLength = NameValueHeaderValue.GetNameValueListLength(P_0, num, ';', (UnvalidatedObjectCollection<NameValueHeaderValue>)mediaTypeHeaderValue.Parameters);
			if (nameValueListLength == 0)
			{
				return 0;
			}
			P_3 = mediaTypeHeaderValue;
			return num + nameValueListLength - P_1;
		}
		mediaTypeHeaderValue = P_2();
		mediaTypeHeaderValue._mediaType = mediaType;
		P_3 = mediaTypeHeaderValue;
		return num - P_1;
	}

	private static int GetMediaTypeExpressionLength(string P_0, int P_1, out string P_2)
	{
		P_2 = null;
		int tokenLength = HttpRuleParser.GetTokenLength(P_0, P_1);
		if (tokenLength == 0)
		{
			return 0;
		}
		int num = P_1 + tokenLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (num >= P_0.Length || P_0[num] != '/')
		{
			return 0;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		int tokenLength2 = HttpRuleParser.GetTokenLength(P_0, num);
		if (tokenLength2 == 0)
		{
			return 0;
		}
		int num2 = num + tokenLength2 - P_1;
		if (tokenLength + tokenLength2 + 1 == num2)
		{
			P_2 = P_0.Substring(P_1, num2);
		}
		else
		{
			P_2 = string.Concat(P_0.AsSpan(P_1, tokenLength), "/", P_0.AsSpan(num, tokenLength2));
		}
		return num2;
	}

	object ICloneable.Clone()
	{
		return new MediaTypeHeaderValue(this);
	}
}
