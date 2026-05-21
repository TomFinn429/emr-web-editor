using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal sealed class BrowserHttpHandler : HttpMessageHandler
{
	private static readonly HttpRequestOptionsKey<bool> EnableStreamingResponse = new HttpRequestOptionsKey<bool>("WebAssemblyEnableStreamingResponse");

	private static readonly HttpRequestOptionsKey<IDictionary<string, object>> FetchOptions = new HttpRequestOptionsKey<IDictionary<string, object>>("WebAssemblyFetchOptions");

	private bool _allowAutoRedirect = true;

	private bool _isAllowAutoRedirectTouched;

	private static bool StreamingSupported { get; } = BrowserHttpInterop.SupportsStreamingResponse();

	public IWebProxy Proxy
	{
		set
		{
			throw new PlatformNotSupportedException();
		}
	}

	public ICredentials Credentials
	{
		set
		{
			throw new PlatformNotSupportedException();
		}
	}

	public bool AllowAutoRedirect => _allowAutoRedirect;

	private static async Task<WasmFetchResponse> CallFetch(HttpRequestMessage P_0, CancellationToken P_1, bool? P_2)
	{
		int valueOrDefault = (P_0.Headers.Count + P_0.Content?.Headers.Count).GetValueOrDefault();
		List<string> headerNames = new List<string>(valueOrDefault);
		List<string> headerValues = new List<string>(valueOrDefault);
		JSObject abortController = BrowserHttpInterop.CreateAbortController();
		CancellationTokenRegistration? abortRegistration = P_1.Register(delegate
		{
			if (!abortController.IsDisposed)
			{
				BrowserHttpInterop.AbortRequest(abortController);
			}
			abortController.Dispose();
		});
		try
		{
			if (P_0.RequestUri == null)
			{
				throw new ArgumentNullException("RequestUri");
			}
			string uri = (P_0.RequestUri.IsAbsoluteUri ? P_0.RequestUri.AbsoluteUri : P_0.RequestUri.ToString());
			IDictionary<string, object> dictionary;
			bool flag = P_0.Options.TryGetValue(FetchOptions, out dictionary);
			int num = 1 + (P_2.HasValue ? 1 : 0) + ((flag && dictionary != null) ? dictionary.Count : 0);
			int num2 = 0;
			string[] optionNames = new string[num];
			object[] optionValues = new object[num];
			optionNames[num2] = "method";
			optionValues[num2] = P_0.Method.Method;
			num2++;
			if (P_2.HasValue)
			{
				optionNames[num2] = "redirect";
				optionValues[num2] = (P_2.Value ? "follow" : "manual");
				num2++;
			}
			foreach (KeyValuePair<string, IEnumerable<string>> header in P_0.Headers)
			{
				foreach (string item in header.Value)
				{
					headerNames.Add(header.Key);
					headerValues.Add(item);
				}
			}
			if (P_0.Content != null)
			{
				foreach (KeyValuePair<string, IEnumerable<string>> header2 in P_0.Content.Headers)
				{
					foreach (string item2 in header2.Value)
					{
						headerNames.Add(header2.Key);
						headerValues.Add(item2);
					}
				}
			}
			if (flag && dictionary != null)
			{
				foreach (KeyValuePair<string, object> item3 in dictionary)
				{
					optionNames[num2] = item3.Key;
					optionValues[num2] = item3.Value;
					num2++;
				}
			}
			P_1.ThrowIfCancellationRequested();
			Task<JSObject> task;
			if (P_0.Content != null)
			{
				_ = P_0.Content;
				if ((object)null != null)
				{
					string text = await P_0.Content.ReadAsStringAsync(P_1).ConfigureAwait(true);
					P_1.ThrowIfCancellationRequested();
					task = BrowserHttpInterop.Fetch(uri, headerNames.ToArray(), headerValues.ToArray(), optionNames, optionValues, abortController, text);
				}
				else
				{
					byte[] array = await P_0.Content.ReadAsByteArrayAsync(P_1).ConfigureAwait(true);
					P_1.ThrowIfCancellationRequested();
					task = BrowserHttpInterop.Fetch(uri, headerNames.ToArray(), headerValues.ToArray(), optionNames, optionValues, abortController, array);
				}
			}
			else
			{
				task = BrowserHttpInterop.Fetch(uri, headerNames.ToArray(), headerValues.ToArray(), optionNames, optionValues, abortController);
			}
			P_1.ThrowIfCancellationRequested();
			return new WasmFetchResponse(await BrowserHttpInterop.CancelationHelper(task, P_1, abortController).ConfigureAwait(true), abortRegistration.Value);
		}
		catch (Exception)
		{
			abortRegistration?.Dispose();
			throw;
		}
	}

	private static HttpResponseMessage ConvertResponse(HttpRequestMessage P_0, WasmFetchResponse P_1)
	{
		string responseType = P_1.ResponseType;
		HttpResponseMessage httpResponseMessage = new HttpResponseMessage((HttpStatusCode)P_1.Status);
		httpResponseMessage.RequestMessage = P_0;
		if (responseType == "opaqueredirect")
		{
			httpResponseMessage.SetReasonPhraseWithoutValidation(P_1.ResponseType);
		}
		bool flag = false;
		if (StreamingSupported)
		{
			P_0.Options.TryGetValue(EnableStreamingResponse, out flag);
		}
		httpResponseMessage.Content = (flag ? ((HttpContent)new StreamContent(new WasmHttpReadStream(P_1))) : ((HttpContent)new BrowserHttpContent(P_1)));
		BrowserHttpInterop.GetResponseHeaders(P_1.FetchResponse, httpResponseMessage.Headers, httpResponseMessage.Content.Headers);
		return httpResponseMessage;
	}

	protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage P_0, CancellationToken P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "request");
		return Impl(P_0, P_1, _isAllowAutoRedirectTouched ? new bool?(AllowAutoRedirect) : ((bool?)null));
		static async Task<HttpResponseMessage> Impl(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken, bool? flag)
		{
			return ConvertResponse(httpRequestMessage, await CallFetch(httpRequestMessage, cancellationToken, flag).ConfigureAwait(true));
		}
	}
}
