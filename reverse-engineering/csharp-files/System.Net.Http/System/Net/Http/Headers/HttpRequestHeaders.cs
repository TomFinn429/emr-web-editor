namespace System.Net.Http.Headers;

public sealed class HttpRequestHeaders : HttpHeaders
{
	private HttpGeneralHeaders _generalHeaders;

	private bool _expectContinueSet;

	public bool? ExpectContinue
	{
		get
		{
			if (ContainsParsedValue(KnownHeaders.Expect.Descriptor, HeaderUtilities.ExpectContinue))
			{
				return true;
			}
			if (_expectContinueSet)
			{
				return false;
			}
			return null;
		}
		set
		{
			if (flag == true)
			{
				_expectContinueSet = true;
				if (!ContainsParsedValue(KnownHeaders.Expect.Descriptor, HeaderUtilities.ExpectContinue))
				{
					AddParsedValue(KnownHeaders.Expect.Descriptor, HeaderUtilities.ExpectContinue);
				}
			}
			else
			{
				_expectContinueSet = flag.HasValue;
				RemoveParsedValue(KnownHeaders.Expect.Descriptor, HeaderUtilities.ExpectContinue);
			}
		}
	}

	private HttpGeneralHeaders GeneralHeaders => _generalHeaders ?? (_generalHeaders = new HttpGeneralHeaders(this));

	internal HttpRequestHeaders()
		: base(HttpHeaderType.General | HttpHeaderType.Request | HttpHeaderType.Custom, HttpHeaderType.Response)
	{
	}

	internal override void AddHeaders(HttpHeaders P_0)
	{
		base.AddHeaders(P_0);
		HttpRequestHeaders httpRequestHeaders = P_0 as HttpRequestHeaders;
		if (httpRequestHeaders._generalHeaders != null)
		{
			GeneralHeaders.AddSpecialsFrom(httpRequestHeaders._generalHeaders);
		}
		if (!ExpectContinue.HasValue)
		{
			ExpectContinue = httpRequestHeaders.ExpectContinue;
		}
	}
}
