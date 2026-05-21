using System.Collections.Generic;

namespace System.Net.Http.Headers;

internal sealed class CacheControlHeaderParser : BaseHeaderParser
{
	internal static readonly CacheControlHeaderParser Parser = new CacheControlHeaderParser();

	private CacheControlHeaderParser()
		: base(true)
	{
	}

	protected override int GetParsedValueLength(string P_0, int P_1, object P_2, out object P_3)
	{
		CacheControlHeaderValue cacheControlHeaderValue = null;
		bool flag = true;
		if (P_2 is List<object> list)
		{
			foreach (object item in list)
			{
				if (!(item is HttpHeaders.InvalidValue))
				{
					flag = false;
					cacheControlHeaderValue = item as CacheControlHeaderValue;
					break;
				}
			}
		}
		else if (!(P_2 is HttpHeaders.InvalidValue))
		{
			flag = false;
			cacheControlHeaderValue = P_2 as CacheControlHeaderValue;
		}
		int cacheControlLength = CacheControlHeaderValue.GetCacheControlLength(P_0, P_1, cacheControlHeaderValue, out cacheControlHeaderValue);
		P_3 = cacheControlHeaderValue;
		return cacheControlLength;
	}
}
