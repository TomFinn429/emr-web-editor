using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace System.Net.Http.Headers;

public class CacheControlHeaderValue : ICloneable
{
	private sealed class TokenObjectCollection : ObjectCollection<string>
	{
		public override void Validate(string P_0)
		{
			HeaderUtilities.CheckValidToken(P_0, "item");
		}
	}

	private static readonly HttpHeaderParser s_nameValueListParser = GenericHeaderParser.MultipleValueNameValueParser;

	private bool _noCache;

	private TokenObjectCollection _noCacheHeaders;

	private bool _noStore;

	private TimeSpan? _maxAge;

	private TimeSpan? _sharedMaxAge;

	private bool _maxStale;

	private TimeSpan? _maxStaleLimit;

	private TimeSpan? _minFresh;

	private bool _noTransform;

	private bool _onlyIfCached;

	private bool _publicField;

	private bool _privateField;

	private TokenObjectCollection _privateHeaders;

	private bool _mustRevalidate;

	private bool _proxyRevalidate;

	private UnvalidatedObjectCollection<NameValueHeaderValue> _extensions;

	public ICollection<string> NoCacheHeaders => _noCacheHeaders ?? (_noCacheHeaders = new TokenObjectCollection());

	public ICollection<string> PrivateHeaders => _privateHeaders ?? (_privateHeaders = new TokenObjectCollection());

	public ICollection<NameValueHeaderValue> Extensions => _extensions ?? (_extensions = new UnvalidatedObjectCollection<NameValueHeaderValue>());

	public CacheControlHeaderValue()
	{
	}

	private CacheControlHeaderValue(CacheControlHeaderValue P_0)
	{
		_noCache = P_0._noCache;
		_noStore = P_0._noStore;
		_maxAge = P_0._maxAge;
		_sharedMaxAge = P_0._sharedMaxAge;
		_maxStale = P_0._maxStale;
		_maxStaleLimit = P_0._maxStaleLimit;
		_minFresh = P_0._minFresh;
		_noTransform = P_0._noTransform;
		_onlyIfCached = P_0._onlyIfCached;
		_publicField = P_0._publicField;
		_privateField = P_0._privateField;
		_mustRevalidate = P_0._mustRevalidate;
		_proxyRevalidate = P_0._proxyRevalidate;
		if (P_0._noCacheHeaders != null)
		{
			foreach (string noCacheHeader in P_0._noCacheHeaders)
			{
				NoCacheHeaders.Add(noCacheHeader);
			}
		}
		if (P_0._privateHeaders != null)
		{
			foreach (string privateHeader in P_0._privateHeaders)
			{
				PrivateHeaders.Add(privateHeader);
			}
		}
		_extensions = P_0._extensions.Clone();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = System.Text.StringBuilderCache.Acquire();
		AppendValueIfRequired(stringBuilder, _noStore, "no-store");
		AppendValueIfRequired(stringBuilder, _noTransform, "no-transform");
		AppendValueIfRequired(stringBuilder, _onlyIfCached, "only-if-cached");
		AppendValueIfRequired(stringBuilder, _publicField, "public");
		AppendValueIfRequired(stringBuilder, _mustRevalidate, "must-revalidate");
		AppendValueIfRequired(stringBuilder, _proxyRevalidate, "proxy-revalidate");
		if (_noCache)
		{
			AppendValueWithSeparatorIfRequired(stringBuilder, "no-cache");
			if (_noCacheHeaders != null && _noCacheHeaders.Count > 0)
			{
				stringBuilder.Append("=\"");
				AppendValues(stringBuilder, _noCacheHeaders);
				stringBuilder.Append('"');
			}
		}
		if (_maxAge.HasValue)
		{
			AppendValueWithSeparatorIfRequired(stringBuilder, "max-age");
			stringBuilder.Append('=');
			int num = (int)_maxAge.GetValueOrDefault().TotalSeconds;
			if (num >= 0)
			{
				stringBuilder.Append(num);
			}
			else
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder3 = stringBuilder2;
				IFormatProvider invariantInfo = NumberFormatInfo.InvariantInfo;
				IFormatProvider formatProvider = invariantInfo;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2, invariantInfo);
				appendInterpolatedStringHandler.AppendFormatted(num);
				stringBuilder3.Append(formatProvider, ref appendInterpolatedStringHandler);
			}
		}
		if (_sharedMaxAge.HasValue)
		{
			AppendValueWithSeparatorIfRequired(stringBuilder, "s-maxage");
			stringBuilder.Append('=');
			int num2 = (int)_sharedMaxAge.GetValueOrDefault().TotalSeconds;
			if (num2 >= 0)
			{
				stringBuilder.Append(num2);
			}
			else
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder4 = stringBuilder2;
				IFormatProvider invariantInfo = NumberFormatInfo.InvariantInfo;
				IFormatProvider formatProvider2 = invariantInfo;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2, invariantInfo);
				appendInterpolatedStringHandler.AppendFormatted(num2);
				stringBuilder4.Append(formatProvider2, ref appendInterpolatedStringHandler);
			}
		}
		if (_maxStale)
		{
			AppendValueWithSeparatorIfRequired(stringBuilder, "max-stale");
			if (_maxStaleLimit.HasValue)
			{
				stringBuilder.Append('=');
				int num3 = (int)_maxStaleLimit.GetValueOrDefault().TotalSeconds;
				if (num3 >= 0)
				{
					stringBuilder.Append(num3);
				}
				else
				{
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder5 = stringBuilder2;
					IFormatProvider invariantInfo = NumberFormatInfo.InvariantInfo;
					IFormatProvider formatProvider3 = invariantInfo;
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2, invariantInfo);
					appendInterpolatedStringHandler.AppendFormatted(num3);
					stringBuilder5.Append(formatProvider3, ref appendInterpolatedStringHandler);
				}
			}
		}
		if (_minFresh.HasValue)
		{
			AppendValueWithSeparatorIfRequired(stringBuilder, "min-fresh");
			stringBuilder.Append('=');
			int num4 = (int)_minFresh.GetValueOrDefault().TotalSeconds;
			if (num4 >= 0)
			{
				stringBuilder.Append(num4);
			}
			else
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder6 = stringBuilder2;
				IFormatProvider invariantInfo = NumberFormatInfo.InvariantInfo;
				IFormatProvider formatProvider4 = invariantInfo;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2, invariantInfo);
				appendInterpolatedStringHandler.AppendFormatted(num4);
				stringBuilder6.Append(formatProvider4, ref appendInterpolatedStringHandler);
			}
		}
		if (_privateField)
		{
			AppendValueWithSeparatorIfRequired(stringBuilder, "private");
			if (_privateHeaders != null && _privateHeaders.Count > 0)
			{
				stringBuilder.Append("=\"");
				AppendValues(stringBuilder, _privateHeaders);
				stringBuilder.Append('"');
			}
		}
		NameValueHeaderValue.ToString(_extensions, ',', false, stringBuilder);
		return System.Text.StringBuilderCache.GetStringAndRelease(stringBuilder);
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is CacheControlHeaderValue cacheControlHeaderValue))
		{
			return false;
		}
		if (_noCache == cacheControlHeaderValue._noCache && _noStore == cacheControlHeaderValue._noStore && !(_maxAge != cacheControlHeaderValue._maxAge))
		{
			TimeSpan? sharedMaxAge = _sharedMaxAge;
			TimeSpan? sharedMaxAge2 = cacheControlHeaderValue._sharedMaxAge;
			if (sharedMaxAge.HasValue == sharedMaxAge2.HasValue && (!sharedMaxAge.HasValue || !(sharedMaxAge.GetValueOrDefault() != sharedMaxAge2.GetValueOrDefault())) && _maxStale == cacheControlHeaderValue._maxStale && !(_maxStaleLimit != cacheControlHeaderValue._maxStaleLimit))
			{
				sharedMaxAge = _minFresh;
				sharedMaxAge2 = cacheControlHeaderValue._minFresh;
				if (sharedMaxAge.HasValue == sharedMaxAge2.HasValue && (!sharedMaxAge.HasValue || !(sharedMaxAge.GetValueOrDefault() != sharedMaxAge2.GetValueOrDefault())) && _noTransform == cacheControlHeaderValue._noTransform && _onlyIfCached == cacheControlHeaderValue._onlyIfCached && _publicField == cacheControlHeaderValue._publicField && _privateField == cacheControlHeaderValue._privateField && _mustRevalidate == cacheControlHeaderValue._mustRevalidate && _proxyRevalidate == cacheControlHeaderValue._proxyRevalidate)
				{
					if (!HeaderUtilities.AreEqualCollections(_noCacheHeaders, cacheControlHeaderValue._noCacheHeaders, StringComparer.OrdinalIgnoreCase))
					{
						return false;
					}
					if (!HeaderUtilities.AreEqualCollections(_privateHeaders, cacheControlHeaderValue._privateHeaders, StringComparer.OrdinalIgnoreCase))
					{
						return false;
					}
					if (!HeaderUtilities.AreEqualCollections(_extensions, cacheControlHeaderValue._extensions))
					{
						return false;
					}
					return true;
				}
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = _noCache.GetHashCode() ^ (_noStore.GetHashCode() << 1) ^ (_maxStale.GetHashCode() << 2) ^ (_noTransform.GetHashCode() << 3) ^ (_onlyIfCached.GetHashCode() << 4) ^ (_publicField.GetHashCode() << 5) ^ (_privateField.GetHashCode() << 6) ^ (_mustRevalidate.GetHashCode() << 7) ^ (_proxyRevalidate.GetHashCode() << 8);
		num = num ^ (_maxAge.HasValue ? (_maxAge.Value.GetHashCode() ^ 1) : 0) ^ (_sharedMaxAge.HasValue ? (_sharedMaxAge.Value.GetHashCode() ^ 2) : 0) ^ (_maxStaleLimit.HasValue ? (_maxStaleLimit.Value.GetHashCode() ^ 4) : 0) ^ (_minFresh.HasValue ? (_minFresh.Value.GetHashCode() ^ 8) : 0);
		if (_noCacheHeaders != null && _noCacheHeaders.Count > 0)
		{
			foreach (string noCacheHeader in _noCacheHeaders)
			{
				num ^= StringComparer.OrdinalIgnoreCase.GetHashCode(noCacheHeader);
			}
		}
		if (_privateHeaders != null && _privateHeaders.Count > 0)
		{
			foreach (string privateHeader in _privateHeaders)
			{
				num ^= StringComparer.OrdinalIgnoreCase.GetHashCode(privateHeader);
			}
		}
		if (_extensions != null && _extensions.Count > 0)
		{
			foreach (NameValueHeaderValue extension in _extensions)
			{
				num ^= extension.GetHashCode();
			}
		}
		return num;
	}

	internal static int GetCacheControlLength(string P_0, int P_1, CacheControlHeaderValue P_2, out CacheControlHeaderValue P_3)
	{
		P_3 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int num = P_1;
		List<NameValueHeaderValue> list = new List<NameValueHeaderValue>();
		while (num < P_0.Length)
		{
			if (!s_nameValueListParser.TryParseValue(P_0, null, ref num, out var obj))
			{
				return 0;
			}
			list.Add((NameValueHeaderValue)obj);
		}
		CacheControlHeaderValue cacheControlHeaderValue = P_2 ?? new CacheControlHeaderValue();
		if (!TrySetCacheControlValues(cacheControlHeaderValue, list))
		{
			return 0;
		}
		if (P_2 == null)
		{
			P_3 = cacheControlHeaderValue;
		}
		return P_0.Length - P_1;
	}

	private static bool TrySetCacheControlValues(CacheControlHeaderValue P_0, List<NameValueHeaderValue> P_1)
	{
		foreach (NameValueHeaderValue item in P_1)
		{
			bool flag = true;
			switch (item.Name.ToLowerInvariant())
			{
			case "no-cache":
				flag = TrySetOptionalTokenList(item, ref P_0._noCache, ref P_0._noCacheHeaders);
				break;
			case "no-store":
				flag = TrySetTokenOnlyValue(item, ref P_0._noStore);
				break;
			case "max-age":
				flag = TrySetTimeSpan(item, ref P_0._maxAge);
				break;
			case "max-stale":
				flag = item.Value == null || TrySetTimeSpan(item, ref P_0._maxStaleLimit);
				if (flag)
				{
					P_0._maxStale = true;
				}
				break;
			case "min-fresh":
				flag = TrySetTimeSpan(item, ref P_0._minFresh);
				break;
			case "no-transform":
				flag = TrySetTokenOnlyValue(item, ref P_0._noTransform);
				break;
			case "only-if-cached":
				flag = TrySetTokenOnlyValue(item, ref P_0._onlyIfCached);
				break;
			case "public":
				flag = TrySetTokenOnlyValue(item, ref P_0._publicField);
				break;
			case "private":
				flag = TrySetOptionalTokenList(item, ref P_0._privateField, ref P_0._privateHeaders);
				break;
			case "must-revalidate":
				flag = TrySetTokenOnlyValue(item, ref P_0._mustRevalidate);
				break;
			case "proxy-revalidate":
				flag = TrySetTokenOnlyValue(item, ref P_0._proxyRevalidate);
				break;
			case "s-maxage":
				flag = TrySetTimeSpan(item, ref P_0._sharedMaxAge);
				break;
			default:
				P_0.Extensions.Add(item);
				break;
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	private static bool TrySetTokenOnlyValue(NameValueHeaderValue P_0, ref bool P_1)
	{
		if (P_0.Value != null)
		{
			return false;
		}
		P_1 = true;
		return true;
	}

	private static bool TrySetOptionalTokenList(NameValueHeaderValue P_0, ref bool P_1, ref TokenObjectCollection P_2)
	{
		if (P_0.Value == null)
		{
			P_1 = true;
			return true;
		}
		string value = P_0.Value;
		if (value.Length < 3 || !value.StartsWith('"') || !value.EndsWith('"'))
		{
			return false;
		}
		int num = 1;
		int num2 = value.Length - 1;
		int num3 = ((P_2 != null) ? P_2.Count : 0);
		while (num < num2)
		{
			num = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(value, num, true, out var _);
			if (num == num2)
			{
				break;
			}
			int tokenLength = HttpRuleParser.GetTokenLength(value, num);
			if (tokenLength == 0)
			{
				return false;
			}
			if (P_2 == null)
			{
				P_2 = new TokenObjectCollection();
			}
			P_2.Add(value.Substring(num, tokenLength));
			num += tokenLength;
		}
		if (P_2 != null && P_2.Count > num3)
		{
			P_1 = true;
			return true;
		}
		return false;
	}

	private static bool TrySetTimeSpan(NameValueHeaderValue P_0, ref TimeSpan? P_1)
	{
		if (P_0.Value == null)
		{
			return false;
		}
		if (!HeaderUtilities.TryParseInt32(P_0.Value, out var num))
		{
			return false;
		}
		P_1 = new TimeSpan(0, 0, num);
		return true;
	}

	private static void AppendValueIfRequired(StringBuilder P_0, bool P_1, string P_2)
	{
		if (P_1)
		{
			AppendValueWithSeparatorIfRequired(P_0, P_2);
		}
	}

	private static void AppendValueWithSeparatorIfRequired(StringBuilder P_0, string P_1)
	{
		if (P_0.Length > 0)
		{
			P_0.Append(", ");
		}
		P_0.Append(P_1);
	}

	private static void AppendValues(StringBuilder P_0, TokenObjectCollection P_1)
	{
		bool flag = true;
		foreach (string item in P_1)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				P_0.Append(", ");
			}
			P_0.Append(item);
		}
	}

	object ICloneable.Clone()
	{
		return new CacheControlHeaderValue(this);
	}
}
