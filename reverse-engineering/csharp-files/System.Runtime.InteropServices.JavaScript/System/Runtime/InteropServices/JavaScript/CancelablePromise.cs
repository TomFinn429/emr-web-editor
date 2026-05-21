using System.CodeDom.Compiler;
using System.Threading.Tasks;

namespace System.Runtime.InteropServices.JavaScript;

internal static class CancelablePromise
{
	[ThreadStatic]
	private static JSFunctionBinding __signature__CancelPromise_1923570313;

	[JSImport("INTERNAL.mono_wasm_cancel_promise")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	private static void _CancelPromise(nint P_0)
	{
		if (__signature__CancelPromise_1923570313 == null)
		{
			__signature__CancelPromise_1923570313 = JSFunctionBinding.BindJSFunction("INTERNAL.mono_wasm_cancel_promise", null, new JSMarshalerType[2]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.IntPtr
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		arguments[1].Initialize();
		arguments[2].ToJS(P_0);
		JSFunctionBinding.InvokeJS(__signature__CancelPromise_1923570313, arguments);
	}

	public static void CancelPromise(Task P_0)
	{
		if (!P_0.IsCompleted)
		{
			GCHandle? gCHandle = P_0.AsyncState as GCHandle?;
			if (!gCHandle.HasValue)
			{
				throw new InvalidOperationException("Expected Task converted from JS Promise");
			}
			_CancelPromise((nint)gCHandle.Value);
		}
	}
}
