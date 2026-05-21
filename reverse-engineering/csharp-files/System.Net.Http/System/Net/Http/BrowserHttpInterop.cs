using System.CodeDom.Compiler;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.JavaScript;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal static class BrowserHttpInterop
{
	[ThreadStatic]
	private static JSFunctionBinding __signature_SupportsStreamingResponse_2027315285;

	[ThreadStatic]
	private static JSFunctionBinding __signature_CreateAbortController_1418463301;

	[ThreadStatic]
	private static JSFunctionBinding __signature_AbortRequest_836767582;

	[ThreadStatic]
	private static JSFunctionBinding __signature_AbortResponse_836767582;

	[ThreadStatic]
	private static JSFunctionBinding __signature__GetResponseHeaderNames_233969578;

	[ThreadStatic]
	private static JSFunctionBinding __signature__GetResponseHeaderValues_233969578;

	[ThreadStatic]
	private static JSFunctionBinding __signature_Fetch_1370326087;

	[ThreadStatic]
	private static JSFunctionBinding __signature_FetchBytes_962814470;

	[ThreadStatic]
	private static JSFunctionBinding __signature_GetStreamedResponseBytes_1115100455;

	[ThreadStatic]
	private static JSFunctionBinding __signature_GetResponseLength_634701616;

	[ThreadStatic]
	private static JSFunctionBinding __signature_GetResponseBytes_1598674696;

	[JSImport("INTERNAL.http_wasm_supports_streaming_response")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static bool SupportsStreamingResponse()
	{
		if (__signature_SupportsStreamingResponse_2027315285 == null)
		{
			__signature_SupportsStreamingResponse_2027315285 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_supports_streaming_response", null, new JSMarshalerType[1] { JSMarshalerType.Boolean });
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[2];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		JSFunctionBinding.InvokeJS(__signature_SupportsStreamingResponse_2027315285, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[JSImport("INTERNAL.http_wasm_create_abort_controler")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static JSObject CreateAbortController()
	{
		if (__signature_CreateAbortController_1418463301 == null)
		{
			__signature_CreateAbortController_1418463301 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_create_abort_controler", null, new JSMarshalerType[1] { JSMarshalerType.JSObject });
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[2];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		JSFunctionBinding.InvokeJS(__signature_CreateAbortController_1418463301, arguments);
		reference.ToManaged(out JSObject result);
		return result;
	}

	[JSImport("INTERNAL.http_wasm_abort_request")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static void AbortRequest(JSObject P_0)
	{
		if (__signature_AbortRequest_836767582 == null)
		{
			__signature_AbortRequest_836767582 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_abort_request", null, new JSMarshalerType[2]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.JSObject
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		arguments[1].Initialize();
		arguments[2].ToJS(P_0);
		JSFunctionBinding.InvokeJS(__signature_AbortRequest_836767582, arguments);
	}

	[JSImport("INTERNAL.http_wasm_abort_response")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static void AbortResponse(JSObject P_0)
	{
		if (__signature_AbortResponse_836767582 == null)
		{
			__signature_AbortResponse_836767582 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_abort_response", null, new JSMarshalerType[2]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.JSObject
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		arguments[1].Initialize();
		arguments[2].ToJS(P_0);
		JSFunctionBinding.InvokeJS(__signature_AbortResponse_836767582, arguments);
	}

	[JSImport("INTERNAL.http_wasm_get_response_header_names")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	private static string[] _GetResponseHeaderNames(JSObject P_0)
	{
		if (__signature__GetResponseHeaderNames_233969578 == null)
		{
			__signature__GetResponseHeaderNames_233969578 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_get_response_header_names", null, new JSMarshalerType[2]
			{
				JSMarshalerType.Array(JSMarshalerType.String),
				JSMarshalerType.JSObject
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(P_0);
		JSFunctionBinding.InvokeJS(__signature__GetResponseHeaderNames_233969578, arguments);
		reference.ToManaged(out string[] result);
		return result;
	}

	[JSImport("INTERNAL.http_wasm_get_response_header_values")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	private static string[] _GetResponseHeaderValues(JSObject P_0)
	{
		if (__signature__GetResponseHeaderValues_233969578 == null)
		{
			__signature__GetResponseHeaderValues_233969578 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_get_response_header_values", null, new JSMarshalerType[2]
			{
				JSMarshalerType.Array(JSMarshalerType.String),
				JSMarshalerType.JSObject
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(P_0);
		JSFunctionBinding.InvokeJS(__signature__GetResponseHeaderValues_233969578, arguments);
		reference.ToManaged(out string[] result);
		return result;
	}

	public static void GetResponseHeaders(JSObject P_0, HttpHeaders P_1, HttpHeaders P_2)
	{
		string[] array = _GetResponseHeaderNames(P_0);
		string[] array2 = _GetResponseHeaderValues(P_0);
		for (int i = 0; i < array.Length; i++)
		{
			if (!P_1.TryAddWithoutValidation(array[i], array2[i]))
			{
				P_2.TryAddWithoutValidation(array[i], array2[i]);
			}
		}
	}

	[JSImport("INTERNAL.http_wasm_fetch")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static Task<JSObject> Fetch(string P_0, string[] P_1, string[] P_2, string[] P_3, [JSMarshalAs<JSType.Array<JSType.Any>>] object[] P_4, JSObject P_5, string P_6 = null)
	{
		if (__signature_Fetch_1370326087 == null)
		{
			__signature_Fetch_1370326087 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_fetch", null, new JSMarshalerType[8]
			{
				JSMarshalerType.Task(JSMarshalerType.JSObject),
				JSMarshalerType.String,
				JSMarshalerType.Array(JSMarshalerType.String),
				JSMarshalerType.Array(JSMarshalerType.String),
				JSMarshalerType.Array(JSMarshalerType.String),
				JSMarshalerType.Array(JSMarshalerType.Object),
				JSMarshalerType.JSObject,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[9];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		ref JSMarshalerArgument reference4 = ref arguments[4];
		ref JSMarshalerArgument reference5 = ref arguments[5];
		ref JSMarshalerArgument reference6 = ref arguments[6];
		ref JSMarshalerArgument reference7 = ref arguments[7];
		ref JSMarshalerArgument reference8 = ref arguments[8];
		reference2.ToJS(P_0);
		reference3.ToJS(P_1);
		reference4.ToJS(P_2);
		reference5.ToJS(P_3);
		reference6.ToJS(P_4);
		reference7.ToJS(P_5);
		reference8.ToJS(P_6);
		JSFunctionBinding.InvokeJS(__signature_Fetch_1370326087, arguments);
		reference.ToManaged(out Task<JSObject> result, delegate(ref JSMarshalerArgument reference9, out JSObject reference10)
		{
			reference9.ToManaged(out reference10);
		});
		return result;
	}

	[JSImport("INTERNAL.http_wasm_fetch_bytes")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	private static Task<JSObject> FetchBytes(string P_0, string[] P_1, string[] P_2, string[] P_3, [JSMarshalAs<JSType.Array<JSType.Any>>] object[] P_4, JSObject P_5, nint P_6, int P_7)
	{
		if (__signature_FetchBytes_962814470 == null)
		{
			__signature_FetchBytes_962814470 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_fetch_bytes", null, new JSMarshalerType[9]
			{
				JSMarshalerType.Task(JSMarshalerType.JSObject),
				JSMarshalerType.String,
				JSMarshalerType.Array(JSMarshalerType.String),
				JSMarshalerType.Array(JSMarshalerType.String),
				JSMarshalerType.Array(JSMarshalerType.String),
				JSMarshalerType.Array(JSMarshalerType.Object),
				JSMarshalerType.JSObject,
				JSMarshalerType.IntPtr,
				JSMarshalerType.Int32
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[10];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		ref JSMarshalerArgument reference4 = ref arguments[4];
		ref JSMarshalerArgument reference5 = ref arguments[5];
		ref JSMarshalerArgument reference6 = ref arguments[6];
		ref JSMarshalerArgument reference7 = ref arguments[7];
		ref JSMarshalerArgument reference8 = ref arguments[8];
		ref JSMarshalerArgument reference9 = ref arguments[9];
		reference2.ToJS(P_0);
		reference3.ToJS(P_1);
		reference4.ToJS(P_2);
		reference5.ToJS(P_3);
		reference6.ToJS(P_4);
		reference7.ToJS(P_5);
		reference8.ToJS(P_6);
		reference9.ToJS(P_7);
		JSFunctionBinding.InvokeJS(__signature_FetchBytes_962814470, arguments);
		reference.ToManaged(out Task<JSObject> result, delegate(ref JSMarshalerArgument reference10, out JSObject reference11)
		{
			reference10.ToManaged(out reference11);
		});
		return result;
	}

	public unsafe static Task<JSObject> Fetch(string P_0, string[] P_1, string[] P_2, string[] P_3, object[] P_4, JSObject P_5, byte[] P_6)
	{
		fixed (byte* ptr = P_6)
		{
			return FetchBytes(P_0, P_1, P_2, P_3, P_4, P_5, (nint)ptr, P_6.Length);
		}
	}

	[JSImport("INTERNAL.http_wasm_get_streamed_response_bytes")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static Task<int> GetStreamedResponseBytes(JSObject P_0, nint P_1, int P_2)
	{
		if (__signature_GetStreamedResponseBytes_1115100455 == null)
		{
			__signature_GetStreamedResponseBytes_1115100455 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_get_streamed_response_bytes", null, new JSMarshalerType[4]
			{
				JSMarshalerType.Task(JSMarshalerType.Int32),
				JSMarshalerType.JSObject,
				JSMarshalerType.IntPtr,
				JSMarshalerType.Int32
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[5];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		ref JSMarshalerArgument reference4 = ref arguments[4];
		reference2.ToJS(P_0);
		reference3.ToJS(P_1);
		reference4.ToJS(P_2);
		JSFunctionBinding.InvokeJS(__signature_GetStreamedResponseBytes_1115100455, arguments);
		reference.ToManaged(out Task<int> result, delegate(ref JSMarshalerArgument reference5, out int reference6)
		{
			reference5.ToManaged(out reference6);
		});
		return result;
	}

	[JSImport("INTERNAL.http_wasm_get_response_length")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static Task<int> GetResponseLength(JSObject P_0)
	{
		if (__signature_GetResponseLength_634701616 == null)
		{
			__signature_GetResponseLength_634701616 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_get_response_length", null, new JSMarshalerType[2]
			{
				JSMarshalerType.Task(JSMarshalerType.Int32),
				JSMarshalerType.JSObject
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(P_0);
		JSFunctionBinding.InvokeJS(__signature_GetResponseLength_634701616, arguments);
		reference.ToManaged(out Task<int> result, delegate(ref JSMarshalerArgument reference2, out int reference3)
		{
			reference2.ToManaged(out reference3);
		});
		return result;
	}

	[JSImport("INTERNAL.http_wasm_get_response_bytes")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static int GetResponseBytes(JSObject P_0, [JSMarshalAs<JSType.MemoryView>] Span<byte> P_1)
	{
		if (__signature_GetResponseBytes_1598674696 == null)
		{
			__signature_GetResponseBytes_1598674696 = JSFunctionBinding.BindJSFunction("INTERNAL.http_wasm_get_response_bytes", null, new JSMarshalerType[3]
			{
				JSMarshalerType.Int32,
				JSMarshalerType.JSObject,
				JSMarshalerType.Span(JSMarshalerType.Byte)
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[4];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		reference2.ToJS(P_0);
		reference3.ToJS(P_1);
		JSFunctionBinding.InvokeJS(__signature_GetResponseBytes_1598674696, arguments);
		reference.ToManaged(out int result);
		return result;
	}

	public static async ValueTask<T> CancelationHelper<T>(Task<T> P_0, CancellationToken P_1, JSObject P_2 = null, JSObject P_3 = null)
	{
		if (P_0.IsCompletedSuccessfully)
		{
			return P_0.Result;
		}
		try
		{
			using (P_1.Register(delegate
			{
				System.Runtime.InteropServices.JavaScript.CancelablePromise.CancelPromise(P_0);
				if (P_2 != null)
				{
					AbortRequest(P_2);
				}
				if (P_3 != null)
				{
					AbortResponse(P_3);
				}
			}))
			{
				return await P_0.ConfigureAwait(true);
			}
		}
		catch (OperationCanceledException ex) when (P_1.IsCancellationRequested)
		{
			throw CancellationHelper.CreateOperationCanceledException(ex, P_1);
		}
		catch (JSException ex2)
		{
			if (ex2.Message.StartsWith("AbortError", StringComparison.Ordinal))
			{
				throw CancellationHelper.CreateOperationCanceledException(ex2, CancellationToken.None);
			}
			if (P_1.IsCancellationRequested)
			{
				throw CancellationHelper.CreateOperationCanceledException(ex2, P_1);
			}
			throw new HttpRequestException(ex2.Message, ex2);
		}
	}
}
