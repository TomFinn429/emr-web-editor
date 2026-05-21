using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System.Runtime.InteropServices.JavaScript;

internal static class JavaScriptImports
{
	[ThreadStatic]
	private static JSFunctionBinding __signature_GetPropertyAsInt32_1348462531;

	[ThreadStatic]
	private static JSFunctionBinding __signature_GetPropertyAsString_1640752517;

	[ThreadStatic]
	private static JSFunctionBinding __signature_GetPropertyAsJSObject_509012229;

	[ThreadStatic]
	private static JSFunctionBinding __signature_SetPropertyBytes_1690373342;

	[ThreadStatic]
	private static JSFunctionBinding __signature_GetDotnetInstance_1418463301;

	[ThreadStatic]
	private static JSFunctionBinding __signature_DynamicImport_1581025222;

	[JSImport("INTERNAL.get_property")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static int GetPropertyAsInt32(JSObject P_0, string P_1)
	{
		if (__signature_GetPropertyAsInt32_1348462531 == null)
		{
			__signature_GetPropertyAsInt32_1348462531 = JSFunctionBinding.BindJSFunction("INTERNAL.get_property", null, new JSMarshalerType[3]
			{
				JSMarshalerType.Int32,
				JSMarshalerType.JSObject,
				JSMarshalerType.String
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
		JSFunctionBinding.InvokeJS(__signature_GetPropertyAsInt32_1348462531, arguments);
		reference.ToManaged(out int result);
		return result;
	}

	[JSImport("INTERNAL.get_property")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static string GetPropertyAsString(JSObject P_0, string P_1)
	{
		if (__signature_GetPropertyAsString_1640752517 == null)
		{
			__signature_GetPropertyAsString_1640752517 = JSFunctionBinding.BindJSFunction("INTERNAL.get_property", null, new JSMarshalerType[3]
			{
				JSMarshalerType.String,
				JSMarshalerType.JSObject,
				JSMarshalerType.String
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
		JSFunctionBinding.InvokeJS(__signature_GetPropertyAsString_1640752517, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[JSImport("INTERNAL.get_property")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static JSObject GetPropertyAsJSObject(JSObject P_0, string P_1)
	{
		if (__signature_GetPropertyAsJSObject_509012229 == null)
		{
			__signature_GetPropertyAsJSObject_509012229 = JSFunctionBinding.BindJSFunction("INTERNAL.get_property", null, new JSMarshalerType[3]
			{
				JSMarshalerType.JSObject,
				JSMarshalerType.JSObject,
				JSMarshalerType.String
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
		JSFunctionBinding.InvokeJS(__signature_GetPropertyAsJSObject_509012229, arguments);
		reference.ToManaged(out JSObject result);
		return result;
	}

	[JSImport("INTERNAL.set_property")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static void SetPropertyBytes(JSObject P_0, string P_1, byte[] P_2)
	{
		if (__signature_SetPropertyBytes_1690373342 == null)
		{
			__signature_SetPropertyBytes_1690373342 = JSFunctionBinding.BindJSFunction("INTERNAL.set_property", null, new JSMarshalerType[4]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.JSObject,
				JSMarshalerType.String,
				JSMarshalerType.Array(JSMarshalerType.Byte)
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[5];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		ref JSMarshalerArgument reference3 = ref arguments[4];
		reference.ToJS(P_0);
		reference2.ToJS(P_1);
		reference3.ToJS(P_2);
		JSFunctionBinding.InvokeJS(__signature_SetPropertyBytes_1690373342, arguments);
	}

	[JSImport("INTERNAL.get_dotnet_instance")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static JSObject GetDotnetInstance()
	{
		if (__signature_GetDotnetInstance_1418463301 == null)
		{
			__signature_GetDotnetInstance_1418463301 = JSFunctionBinding.BindJSFunction("INTERNAL.get_dotnet_instance", null, new JSMarshalerType[1] { JSMarshalerType.JSObject });
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[2];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		JSFunctionBinding.InvokeJS(__signature_GetDotnetInstance_1418463301, arguments);
		reference.ToManaged(out JSObject result);
		return result;
	}

	[JSImport("INTERNAL.dynamic_import")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	public static Task<JSObject> DynamicImport(string P_0, string P_1)
	{
		if (__signature_DynamicImport_1581025222 == null)
		{
			__signature_DynamicImport_1581025222 = JSFunctionBinding.BindJSFunction("INTERNAL.dynamic_import", null, new JSMarshalerType[3]
			{
				JSMarshalerType.Task(JSMarshalerType.JSObject),
				JSMarshalerType.String,
				JSMarshalerType.String
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
		JSFunctionBinding.InvokeJS(__signature_DynamicImport_1581025222, arguments);
		reference.ToManaged(out Task<JSObject> result, delegate(ref JSMarshalerArgument reference4, out JSObject reference5)
		{
			reference4.ToManaged(out reference5);
		});
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe static void MarshalPromise(Span<JSMarshalerArgument> P_0)
	{
		fixed (JSMarshalerArgument* ptr = P_0)
		{
			global::Interop.Runtime.MarshalPromise(ptr);
			ref JSMarshalerArgument reference = ref P_0[0];
			if (reference.slot.Type != MarshalerType.None)
			{
				JSHostImplementation.ThrowException(ref reference);
			}
		}
	}
}
