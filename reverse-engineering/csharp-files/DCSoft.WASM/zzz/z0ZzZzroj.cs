using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace zzz;

[SupportedOSPlatform("browser")]
internal class z0ZzZzroj
{
	private class z0qck : z0ZzZzqok
	{
		public override void z0sh(string p0)
		{
			if (p0 != null && p0.Length > 0)
			{
				z0frk(p0);
			}
		}

		public override void z0dh(string p0)
		{
			if (p0 != null && p0.Length > 0)
			{
				z0ZzZzroj.z0eek(p0);
			}
		}
	}

	[ThreadStatic]
	private static JSFunctionBinding z0drk;

	[ThreadStatic]
	private static JSFunctionBinding z0srk;

	[ThreadStatic]
	private static JSFunctionBinding z0ark;

	[ThreadStatic]
	private static JSFunctionBinding z0qrk;

	[ThreadStatic]
	private static JSFunctionBinding z0wrk;

	[ThreadStatic]
	private static JSFunctionBinding z0trk;

	[ThreadStatic]
	private static JSFunctionBinding z0yrk;

	[ThreadStatic]
	private static JSFunctionBinding z0urk;

	[ThreadStatic]
	private static JSFunctionBinding z0irk;

	[ThreadStatic]
	private static JSFunctionBinding z0ork;

	[ThreadStatic]
	private static JSFunctionBinding z0mrk;

	[ThreadStatic]
	private static JSFunctionBinding z0nrk;

	[ThreadStatic]
	private static JSFunctionBinding z0brk;

	[ThreadStatic]
	private static JSFunctionBinding z0vrk;

	[ThreadStatic]
	private static JSFunctionBinding z0xrk;

	private static readonly Dictionary<string, MethodInfo> z0zrk = new Dictionary<string, MethodInfo>();

	[ThreadStatic]
	private static JSFunctionBinding z0ltk;

	[ThreadStatic]
	private static JSFunctionBinding z0ktk;

	[ThreadStatic]
	private static JSFunctionBinding z0jtk;

	[ThreadStatic]
	private static JSFunctionBinding z0htk;

	[ThreadStatic]
	private static JSFunctionBinding z0gtk;

	[ThreadStatic]
	private static JSFunctionBinding z0ftk;

	[ThreadStatic]
	private static JSFunctionBinding z0dtk;

	[ThreadStatic]
	private static JSFunctionBinding z0stk;

	[ThreadStatic]
	private static JSFunctionBinding z0atk;

	[ThreadStatic]
	private static JSFunctionBinding z0qtk;

	[ThreadStatic]
	private static JSFunctionBinding z0wtk;

	[ThreadStatic]
	private static JSFunctionBinding z0ttk;

	[ThreadStatic]
	private static JSFunctionBinding z0ytk;

	[ThreadStatic]
	private static JSFunctionBinding z0utk;

	[ThreadStatic]
	private static JSFunctionBinding z0itk;

	[ThreadStatic]
	private static JSFunctionBinding z0otk;

	[ThreadStatic]
	private static JSFunctionBinding z0ptk;

	[ThreadStatic]
	private static JSFunctionBinding z0mtk;

	[ThreadStatic]
	private static JSFunctionBinding z0ntk;

	[ThreadStatic]
	private static JSFunctionBinding z0vtk;

	[ThreadStatic]
	private static JSFunctionBinding z0xtk;

	[ThreadStatic]
	private static JSFunctionBinding z0lyk;

	[ThreadStatic]
	private static JSFunctionBinding z0hyk_jiejie20260327142557;

	[ThreadStatic]
	private static JSFunctionBinding z0gyk;

	[ThreadStatic]
	private static JSFunctionBinding z0dyk;

	[ThreadStatic]
	private static JSFunctionBinding z0ayk_jiejie20260327142557;

	[ThreadStatic]
	private static JSFunctionBinding z0qyk;

	[ThreadStatic]
	private static JSFunctionBinding z0wyk;

	[ThreadStatic]
	private static JSFunctionBinding z0eyk;

	[ThreadStatic]
	private static JSFunctionBinding z0tyk;

	[ThreadStatic]
	private static JSFunctionBinding z0uyk;

	[ThreadStatic]
	private static JSFunctionBinding z0iyk;

	[ThreadStatic]
	private static JSFunctionBinding z0oyk;

	[ThreadStatic]
	private static JSFunctionBinding z0pyk;

	[ThreadStatic]
	private static JSFunctionBinding z0myk;

	[ThreadStatic]
	private static JSFunctionBinding z0nyk;

	internal static string z0vyk = "./";

	[ThreadStatic]
	private static JSFunctionBinding z0cyk;

	[ThreadStatic]
	private static JSFunctionBinding z0xyk;

	[ThreadStatic]
	private static JSFunctionBinding z0zyk;

	[ThreadStatic]
	private static JSFunctionBinding z0luk;

	[ThreadStatic]
	private static JSFunctionBinding z0huk;

	[ThreadStatic]
	private static JSFunctionBinding z0guk;

	[JSImport("DCTools20221228.DESEncrypt", "DCTools20221228")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static byte[] z0eek(byte[] p0, byte[] p1, byte[] p2)
	{
		if (z0otk == null)
		{
			z0otk = JSFunctionBinding.BindJSFunction("DCTools20221228.DESEncrypt", "DCTools20221228", new JSMarshalerType[4]
			{
				JSMarshalerType.Array(JSMarshalerType.Byte),
				JSMarshalerType.Array(JSMarshalerType.Byte),
				JSMarshalerType.Array(JSMarshalerType.Byte),
				JSMarshalerType.Array(JSMarshalerType.Byte)
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[5];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		ref JSMarshalerArgument reference4 = ref arguments[4];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		reference4.ToJS(p2);
		JSFunctionBinding.InvokeJS(z0otk, arguments);
		reference.ToManaged(out byte[] result);
		return result;
	}

	[JSImport("DCTools20221228.ConsoleWarring", "DCTools20221228")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0eek(string p0)
	{
		if (z0yrk == null)
		{
			z0yrk = JSFunctionBinding.BindJSFunction("DCTools20221228.ConsoleWarring", "DCTools20221228", new JSMarshalerType[2]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		arguments[1].Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0yrk, arguments);
	}

	[JSImport("DCTools20221228.UnPackageStringValue", "DCTools20221228")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static string z0rek(string p0)
	{
		if (z0gtk == null)
		{
			z0gtk = JSFunctionBinding.BindJSFunction("DCTools20221228.UnPackageStringValue", "DCTools20221228", new JSMarshalerType[2]
			{
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0gtk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[JSImport("WriterControl_UI.ShowMessageBox", "WriterControl_UI")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static string z0eek(string p0, string p1, string p2, string p3, string p4)
	{
		if (z0qyk == null)
		{
			z0qyk = JSFunctionBinding.BindJSFunction("WriterControl_UI.ShowMessageBox", "WriterControl_UI", new JSMarshalerType[6]
			{
				JSMarshalerType.String,
				JSMarshalerType.String,
				JSMarshalerType.String,
				JSMarshalerType.String,
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[7];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		ref JSMarshalerArgument reference4 = ref arguments[4];
		ref JSMarshalerArgument reference5 = ref arguments[5];
		ref JSMarshalerArgument reference6 = ref arguments[6];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		reference4.ToJS(p2);
		reference5.ToJS(p3);
		reference6.ToJS(p4);
		JSFunctionBinding.InvokeJS(z0qyk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[JSImport("WriterControl_UI.ShowCaret", "WriterControl_UI")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0eek(string p0, int p1, int p2, int p3, int p4, int p5, bool p6, bool p7, bool p8)
	{
		if (z0trk == null)
		{
			z0trk = JSFunctionBinding.BindJSFunction("WriterControl_UI.ShowCaret", "WriterControl_UI", new JSMarshalerType[10]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Boolean,
				JSMarshalerType.Boolean,
				JSMarshalerType.Boolean
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[11];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		ref JSMarshalerArgument reference3 = ref arguments[4];
		ref JSMarshalerArgument reference4 = ref arguments[5];
		ref JSMarshalerArgument reference5 = ref arguments[6];
		ref JSMarshalerArgument reference6 = ref arguments[7];
		ref JSMarshalerArgument reference7 = ref arguments[8];
		ref JSMarshalerArgument reference8 = ref arguments[9];
		ref JSMarshalerArgument reference9 = ref arguments[10];
		reference.ToJS(p0);
		reference2.ToJS(p1);
		reference3.ToJS(p2);
		reference4.ToJS(p3);
		reference5.ToJS(p4);
		reference6.ToJS(p5);
		reference7.ToJS(p6);
		reference8.ToJS(p7);
		reference9.ToJS(p8);
		JSFunctionBinding.InvokeJS(z0trk, arguments);
	}

	[JSImport("WriterControl_UI.IsAPILogRecord", "WriterControl_UI")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static bool z0tek(string p0)
	{
		if (z0dyk == null)
		{
			z0dyk = JSFunctionBinding.BindJSFunction("WriterControl_UI.IsAPILogRecord", "WriterControl_UI", new JSMarshalerType[2]
			{
				JSMarshalerType.Boolean,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0dyk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[JSImport("WriterControl_UI.JSShowColorControl", "WriterControl_UI")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0eek(string p0, string p1)
	{
		if (z0urk == null)
		{
			z0urk = JSFunctionBinding.BindJSFunction("WriterControl_UI.JSShowColorControl", "WriterControl_UI", new JSMarshalerType[3]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[4];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		reference.ToJS(p0);
		reference2.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0urk, arguments);
	}

	[JSImport("WriterControl_UI.ShowCalculateControl", "WriterControl_UI")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0eek(string p0, int p1, int p2, int p3, int p4, double p5)
	{
		if (z0drk == null)
		{
			z0drk = JSFunctionBinding.BindJSFunction("WriterControl_UI.ShowCalculateControl", "WriterControl_UI", new JSMarshalerType[7]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Double
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[8];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		ref JSMarshalerArgument reference3 = ref arguments[4];
		ref JSMarshalerArgument reference4 = ref arguments[5];
		ref JSMarshalerArgument reference5 = ref arguments[6];
		ref JSMarshalerArgument reference6 = ref arguments[7];
		reference.ToJS(p0);
		reference2.ToJS(p1);
		reference3.ToJS(p2);
		reference4.ToJS(p3);
		reference5.ToJS(p4);
		reference6.ToJS(p5);
		JSFunctionBinding.InvokeJS(z0drk, arguments);
	}

	[JSImport("WriterControl_Main.StartGlobal", "WriterControl_Main")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0eek()
	{
		if (z0huk == null)
		{
			z0huk = JSFunctionBinding.BindJSFunction("WriterControl_Main.StartGlobal", "WriterControl_Main", new JSMarshalerType[1] { JSMarshalerType.Discard });
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[2];
		arguments[0].Initialize();
		arguments[1].Initialize();
		JSFunctionBinding.InvokeJS(z0huk, arguments);
	}

	[JSImport("WriterControl_IO.CloseDCXmlReader", "WriterControl_IO")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0rek()
	{
		if (z0luk == null)
		{
			z0luk = JSFunctionBinding.BindJSFunction("WriterControl_IO.CloseDCXmlReader", "WriterControl_IO", new JSMarshalerType[1] { JSMarshalerType.Discard });
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[2];
		arguments[0].Initialize();
		arguments[1].Initialize();
		JSFunctionBinding.InvokeJS(z0luk, arguments);
	}

	[JSImport("WriterControl_FontList.GetFontFileName", "WriterControl_FontList")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static string z0yek(string p0)
	{
		if (z0ltk == null)
		{
			z0ltk = JSFunctionBinding.BindJSFunction("WriterControl_FontList.GetFontFileName", "WriterControl_FontList", new JSMarshalerType[2]
			{
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0ltk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[JSImport("WriterControl_Main.InitDefaultResourceStrings", "WriterControl_Main")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0tek()
	{
		if (z0irk == null)
		{
			z0irk = JSFunctionBinding.BindJSFunction("WriterControl_Main.InitDefaultResourceStrings", "WriterControl_Main", new JSMarshalerType[1] { JSMarshalerType.Discard });
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[2];
		arguments[0].Initialize();
		arguments[1].Initialize();
		JSFunctionBinding.InvokeJS(z0irk, arguments);
	}

	[JSImport("DCTools20221228.DecodeString", "DCTools20221228")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static string z0eek(string p0, byte[] p1)
	{
		if (z0ork == null)
		{
			z0ork = JSFunctionBinding.BindJSFunction("DCTools20221228.DecodeString", "DCTools20221228", new JSMarshalerType[3]
			{
				JSMarshalerType.String,
				JSMarshalerType.String,
				JSMarshalerType.Array(JSMarshalerType.Byte)
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[4];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0ork, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[JSImport("WriterControl_IO.PrepareInnerXmlReader", "WriterControl_IO")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static bool z0eek(string p0, string p1, bool p2)
	{
		if (z0uyk == null)
		{
			z0uyk = JSFunctionBinding.BindJSFunction("WriterControl_IO.PrepareInnerXmlReader", "WriterControl_IO", new JSMarshalerType[4]
			{
				JSMarshalerType.Boolean,
				JSMarshalerType.String,
				JSMarshalerType.String,
				JSMarshalerType.Boolean
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[5];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		ref JSMarshalerArgument reference4 = ref arguments[4];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		reference4.ToJS(p2);
		JSFunctionBinding.InvokeJS(z0uyk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	public static object z0eek(object p0, string p1)
	{
		if (p0 == null || p1 == null)
		{
			return null;
		}
		MethodInfo methodInfo = null;
		if (!z0zrk.TryGetValue(p1, out methodInfo))
		{
			methodInfo = typeof(DotNetObjectReference).GetMethod("Create").MakeGenericMethod(p0.GetType());
			z0zrk[p1] = methodInfo;
		}
		if (methodInfo != null)
		{
			return methodInfo.Invoke(null, new object[1] { p0 });
		}
		return null;
	}

	[JSImport("WriterControl_Event.HasControlEvent", "WriterControl_Event")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static bool z0rek(string p0, string p1)
	{
		if (z0qtk == null)
		{
			z0qtk = JSFunctionBinding.BindJSFunction("WriterControl_Event.HasControlEvent", "WriterControl_Event", new JSMarshalerType[3]
			{
				JSMarshalerType.Boolean,
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
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0qtk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_UI.APILogRecordDebugPrint", "WriterControl_UI")]
	internal static void z0tek(string p0, string p1)
	{
		if (z0itk == null)
		{
			z0itk = JSFunctionBinding.BindJSFunction("WriterControl_UI.APILogRecordDebugPrint", "WriterControl_UI", new JSMarshalerType[3]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[4];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		reference.ToJS(p0);
		reference2.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0itk, arguments);
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_Paint.NeedUpdateView", "WriterControl_Paint")]
	internal static bool z0eek(string p0, bool p1)
	{
		if (z0pyk == null)
		{
			z0pyk = JSFunctionBinding.BindJSFunction("WriterControl_Paint.NeedUpdateView", "WriterControl_Paint", new JSMarshalerType[3]
			{
				JSMarshalerType.Boolean,
				JSMarshalerType.String,
				JSMarshalerType.Boolean
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[4];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0pyk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("DCTools20221228.GetImageSize", "DCTools20221228")]
	internal static string z0eek(int p0, byte[] p1)
	{
		if (z0ktk == null)
		{
			z0ktk = JSFunctionBinding.BindJSFunction("DCTools20221228.GetImageSize", "DCTools20221228", new JSMarshalerType[3]
			{
				JSMarshalerType.String,
				JSMarshalerType.Int32,
				JSMarshalerType.Array(JSMarshalerType.Byte)
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[4];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0ktk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	public static async Task z0uek(string p0)
	{
		if (p0 != null && p0.StartsWith("blob:"))
		{
			string[] array = new string[10] { "DCTools20221228", "WriterControl_Dialog", "WriterControl_DOMPackage", "WriterControl_Event", "WriterControl_FontList", "WriterControl_IO", "WriterControl_Main", "WriterControl_Paint", "WriterControl_Rule", "WriterControl_UI" };
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				await JSHost.ImportAsync(array2[i], p0);
			}
			z0ZzZzqok.z0rek = new z0qck();
		}
		else
		{
			if (p0 != null && p0.Length > 0 && p0.IndexOf('?') > 0 && p0.IndexOf("wasmres=") > 0)
			{
				z0vyk = p0;
			}
			await z0krk_jiejie20260327142557("WriterControl_Main");
			await z0krk_jiejie20260327142557("WriterControl_UI");
			await z0krk_jiejie20260327142557("WriterControl_Paint");
			await z0krk_jiejie20260327142557("WriterControl_Rule");
			await z0krk_jiejie20260327142557("WriterControl_Event");
			await z0krk_jiejie20260327142557("WriterControl_Dialog");
			await z0krk_jiejie20260327142557("DCTools20221228");
			await z0krk_jiejie20260327142557("WriterControl_DOMPackage");
			await z0krk_jiejie20260327142557("WriterControl_IO");
			await z0krk_jiejie20260327142557("WriterControl_FontList");
			z0ZzZzqok.z0rek = new z0qck();
		}
	}

	[JSImport("WriterControl_DOMPackage.IsSupport", "WriterControl_DOMPackage")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static bool z0iek(string p0)
	{
		if (z0atk == null)
		{
			z0atk = JSFunctionBinding.BindJSFunction("WriterControl_DOMPackage.IsSupport", "WriterControl_DOMPackage", new JSMarshalerType[2]
			{
				JSMarshalerType.Boolean,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0atk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[JSImport("DCTools20221228.DESDecrypt", "DCTools20221228")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static byte[] z0rek(byte[] p0, byte[] p1, byte[] p2)
	{
		if (z0xtk == null)
		{
			z0xtk = JSFunctionBinding.BindJSFunction("DCTools20221228.DESDecrypt", "DCTools20221228", new JSMarshalerType[4]
			{
				JSMarshalerType.Array(JSMarshalerType.Byte),
				JSMarshalerType.Array(JSMarshalerType.Byte),
				JSMarshalerType.Array(JSMarshalerType.Byte),
				JSMarshalerType.Array(JSMarshalerType.Byte)
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[5];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		ref JSMarshalerArgument reference4 = ref arguments[4];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		reference4.ToJS(p2);
		JSFunctionBinding.InvokeJS(z0xtk, arguments);
		reference.ToManaged(out byte[] result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_UI.ReloadHostControls", "WriterControl_UI")]
	internal static string z0oek(string p0)
	{
		if (z0tyk == null)
		{
			z0tyk = JSFunctionBinding.BindJSFunction("WriterControl_UI.ReloadHostControls", "WriterControl_UI", new JSMarshalerType[2]
			{
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0tyk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_Paint.BuildBitmapSrc", "WriterControl_Paint")]
	internal static string z0eek(byte[] p0)
	{
		if (z0eyk == null)
		{
			z0eyk = JSFunctionBinding.BindJSFunction("WriterControl_Paint.BuildBitmapSrc", "WriterControl_Paint", new JSMarshalerType[2]
			{
				JSMarshalerType.String,
				JSMarshalerType.Array(JSMarshalerType.Byte)
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0eyk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[JSImport("WriterControl_Paint.IsStandardImageListReady", "WriterControl_Paint")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static bool z0yek()
	{
		if (z0ptk == null)
		{
			z0ptk = JSFunctionBinding.BindJSFunction("WriterControl_Paint.IsStandardImageListReady", "WriterControl_Paint", new JSMarshalerType[1] { JSMarshalerType.Boolean });
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[2];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		JSFunctionBinding.InvokeJS(z0ptk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[JSImport("DCTools20221228.DownloadAsFile", "DCTools20221228")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0eek(byte[] p0, string p1, string p2)
	{
		if (z0stk == null)
		{
			z0stk = JSFunctionBinding.BindJSFunction("DCTools20221228.DownloadAsFile", "DCTools20221228", new JSMarshalerType[4]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.Array(JSMarshalerType.Byte),
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[5];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		ref JSMarshalerArgument reference3 = ref arguments[4];
		reference.ToJS(p0);
		reference2.ToJS(p1);
		reference3.ToJS(p2);
		JSFunctionBinding.InvokeJS(z0stk, arguments);
	}

	[JSImport("WriterControl_UI.SetToolTip", "WriterControl_UI")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0yek(string p0, string p1)
	{
		if (z0nrk == null)
		{
			z0nrk = JSFunctionBinding.BindJSFunction("WriterControl_UI.SetToolTip", "WriterControl_UI", new JSMarshalerType[3]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[4];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		reference.ToJS(p0);
		reference2.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0nrk, arguments);
	}

	[JSImport("WriterControl_UI.CloseDropdownControl", "WriterControl_UI")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0pek(string p0)
	{
		if (z0mrk == null)
		{
			z0mrk = JSFunctionBinding.BindJSFunction("WriterControl_UI.CloseDropdownControl", "WriterControl_UI", new JSMarshalerType[2]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		arguments[1].Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0mrk, arguments);
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_UI.IsDropdownControlVisible", "WriterControl_UI")]
	internal static bool z0mek(string p0)
	{
		if (z0vtk == null)
		{
			z0vtk = JSFunctionBinding.BindJSFunction("WriterControl_UI.IsDropdownControlVisible", "WriterControl_UI", new JSMarshalerType[2]
			{
				JSMarshalerType.Boolean,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0vtk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[JSImport("WriterControl_IO.HttpDownloadFile", "WriterControl_IO")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static bool z0uek(string p0, string p1)
	{
		if (z0hyk_jiejie20260327142557 == null)
		{
			z0hyk_jiejie20260327142557 = JSFunctionBinding.BindJSFunction("WriterControl_IO.HttpDownloadFile", "WriterControl_IO", new JSMarshalerType[3]
			{
				JSMarshalerType.Boolean,
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
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0hyk_jiejie20260327142557, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[JSImport("WriterControl_Rule.SetRuleVisible", "WriterControl_Rule")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static bool z0rek(string p0, bool p1)
	{
		if (z0jtk == null)
		{
			z0jtk = JSFunctionBinding.BindJSFunction("WriterControl_Rule.SetRuleVisible", "WriterControl_Rule", new JSMarshalerType[3]
			{
				JSMarshalerType.Boolean,
				JSMarshalerType.String,
				JSMarshalerType.Boolean
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[4];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0jtk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_UI.FlashArea", "WriterControl_UI")]
	internal static bool z0iek(string p0, string p1)
	{
		if (z0zyk == null)
		{
			z0zyk = JSFunctionBinding.BindJSFunction("WriterControl_UI.FlashArea", "WriterControl_UI", new JSMarshalerType[3]
			{
				JSMarshalerType.Boolean,
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
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0zyk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_UI.ScrollToView", "WriterControl_UI")]
	internal static void z0eek(string p0, int p1, int p2, int p3, int p4, int p5, string p6)
	{
		if (z0wtk == null)
		{
			z0wtk = JSFunctionBinding.BindJSFunction("WriterControl_UI.ScrollToView", "WriterControl_UI", new JSMarshalerType[8]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[9];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		ref JSMarshalerArgument reference3 = ref arguments[4];
		ref JSMarshalerArgument reference4 = ref arguments[5];
		ref JSMarshalerArgument reference5 = ref arguments[6];
		ref JSMarshalerArgument reference6 = ref arguments[7];
		ref JSMarshalerArgument reference7 = ref arguments[8];
		reference.ToJS(p0);
		reference2.ToJS(p1);
		reference3.ToJS(p2);
		reference4.ToJS(p3);
		reference5.ToJS(p4);
		reference6.ToJS(p5);
		reference7.ToJS(p6);
		JSFunctionBinding.InvokeJS(z0wtk, arguments);
	}

	[JSImport("WriterControl_Rule.InvalidateView", "WriterControl_Rule")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static bool z0oek(string p0, string p1)
	{
		if (z0wyk == null)
		{
			z0wyk = JSFunctionBinding.BindJSFunction("WriterControl_Rule.InvalidateView", "WriterControl_Rule", new JSMarshalerType[3]
			{
				JSMarshalerType.Boolean,
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
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0wyk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("DCTools20221228.PackageBigStringValue", "DCTools20221228")]
	internal static string z0nek(string p0)
	{
		if (z0vrk == null)
		{
			z0vrk = JSFunctionBinding.BindJSFunction("DCTools20221228.PackageBigStringValue", "DCTools20221228", new JSMarshalerType[2]
			{
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0vrk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[JSImport("WriterControl_Paint.GetMatrixElements", "WriterControl_Paint")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static string z0eek(float p0, float p1, float p2, float p3, float p4, float p5, int p6, float p7, float p8)
	{
		if (z0oyk == null)
		{
			z0oyk = JSFunctionBinding.BindJSFunction("WriterControl_Paint.GetMatrixElements", "WriterControl_Paint", new JSMarshalerType[10]
			{
				JSMarshalerType.String,
				JSMarshalerType.Single,
				JSMarshalerType.Single,
				JSMarshalerType.Single,
				JSMarshalerType.Single,
				JSMarshalerType.Single,
				JSMarshalerType.Single,
				JSMarshalerType.Int32,
				JSMarshalerType.Single,
				JSMarshalerType.Single
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[11];
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
		ref JSMarshalerArgument reference10 = ref arguments[10];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		reference4.ToJS(p2);
		reference5.ToJS(p3);
		reference6.ToJS(p4);
		reference7.ToJS(p5);
		reference8.ToJS(p6);
		reference9.ToJS(p7);
		reference10.ToJS(p8);
		JSFunctionBinding.InvokeJS(z0oyk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_FontList.GetFontInfoKeyName", "WriterControl_FontList")]
	internal static string z0eek(string p0, bool p1, bool p2)
	{
		if (z0utk == null)
		{
			z0utk = JSFunctionBinding.BindJSFunction("WriterControl_FontList.GetFontInfoKeyName", "WriterControl_FontList", new JSMarshalerType[4]
			{
				JSMarshalerType.String,
				JSMarshalerType.String,
				JSMarshalerType.Boolean,
				JSMarshalerType.Boolean
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[5];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		ref JSMarshalerArgument reference4 = ref arguments[4];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		reference4.ToJS(p2);
		JSFunctionBinding.InvokeJS(z0utk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_Paint.UpdatePages", "WriterControl_Paint")]
	internal static bool z0pek(string p0, string p1)
	{
		if (z0dtk == null)
		{
			z0dtk = JSFunctionBinding.BindJSFunction("WriterControl_Paint.UpdatePages", "WriterControl_Paint", new JSMarshalerType[3]
			{
				JSMarshalerType.Boolean,
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
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0dtk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[JSImport("WriterControl_Paint.GetCellDiagonalBase64Image", "WriterControl_Paint")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static string z0eek(string p0, float p1, float p2, string p3)
	{
		if (z0ftk == null)
		{
			z0ftk = JSFunctionBinding.BindJSFunction("WriterControl_Paint.GetCellDiagonalBase64Image", "WriterControl_Paint", new JSMarshalerType[5]
			{
				JSMarshalerType.String,
				JSMarshalerType.String,
				JSMarshalerType.Single,
				JSMarshalerType.Single,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[6];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		ref JSMarshalerArgument reference2 = ref arguments[2];
		ref JSMarshalerArgument reference3 = ref arguments[3];
		ref JSMarshalerArgument reference4 = ref arguments[4];
		ref JSMarshalerArgument reference5 = ref arguments[5];
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		reference4.ToJS(p2);
		reference5.ToJS(p3);
		JSFunctionBinding.InvokeJS(z0ftk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_FontList.GetFontSnapshort", "WriterControl_FontList")]
	internal static string z0bek(string p0)
	{
		if (z0qrk == null)
		{
			z0qrk = JSFunctionBinding.BindJSFunction("WriterControl_FontList.GetFontSnapshort", "WriterControl_FontList", new JSMarshalerType[2]
			{
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0qrk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[JSImport("DCTools20221228.CollectBinaryData", "DCTools20221228")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0rek(byte[] p0)
	{
		if (z0wrk == null)
		{
			z0wrk = JSFunctionBinding.BindJSFunction("DCTools20221228.CollectBinaryData", "DCTools20221228", new JSMarshalerType[2]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.Array(JSMarshalerType.Byte)
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		arguments[1].Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0wrk, arguments);
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("DCTools20221228.ClearForCollectBinaryData", "DCTools20221228")]
	internal static void z0uek()
	{
		if (z0ayk_jiejie20260327142557 == null)
		{
			z0ayk_jiejie20260327142557 = JSFunctionBinding.BindJSFunction("DCTools20221228.ClearForCollectBinaryData", "DCTools20221228", new JSMarshalerType[1] { JSMarshalerType.Discard });
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[2];
		arguments[0].Initialize();
		arguments[1].Initialize();
		JSFunctionBinding.InvokeJS(z0ayk_jiejie20260327142557, arguments);
	}

	[JSImport("DCTools20221228.ReportException", "DCTools20221228")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0eek(string p0, string p1, string p2, int p3)
	{
		if (z0ark == null)
		{
			z0ark = JSFunctionBinding.BindJSFunction("DCTools20221228.ReportException", "DCTools20221228", new JSMarshalerType[5]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String,
				JSMarshalerType.String,
				JSMarshalerType.String,
				JSMarshalerType.Int32
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[6];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		ref JSMarshalerArgument reference3 = ref arguments[4];
		ref JSMarshalerArgument reference4 = ref arguments[5];
		reference.ToJS(p0);
		reference2.ToJS(p1);
		reference3.ToJS(p2);
		reference4.ToJS(p3);
		JSFunctionBinding.InvokeJS(z0ark, arguments);
	}

	public static DateTime z0iek()
	{
		return z0ZzZzdbj.z0pik();
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_FontList.GetFontNames", "WriterControl_FontList")]
	internal static string[] z0oek()
	{
		if (z0mtk == null)
		{
			z0mtk = JSFunctionBinding.BindJSFunction("WriterControl_FontList.GetFontNames", "WriterControl_FontList", new JSMarshalerType[1] { JSMarshalerType.Array(JSMarshalerType.String) });
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[2];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		JSFunctionBinding.InvokeJS(z0mtk, arguments);
		reference.ToManaged(out string[] result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_UI.QueryDeleteRowOfColumns", "WriterControl_UI")]
	internal static void z0vek(string p0)
	{
		if (z0guk == null)
		{
			z0guk = JSFunctionBinding.BindJSFunction("WriterControl_UI.QueryDeleteRowOfColumns", "WriterControl_UI", new JSMarshalerType[2]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		arguments[1].Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0guk, arguments);
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("DCTools20221228.HttpDownloadString", "DCTools20221228")]
	internal static string z0cek(string p0)
	{
		if (z0cyk == null)
		{
			z0cyk = JSFunctionBinding.BindJSFunction("DCTools20221228.HttpDownloadString", "DCTools20221228", new JSMarshalerType[2]
			{
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0cyk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_UI.WindowPrompt", "WriterControl_UI")]
	internal static string z0mek(string p0, string p1)
	{
		if (z0myk == null)
		{
			z0myk = JSFunctionBinding.BindJSFunction("WriterControl_UI.WindowPrompt", "WriterControl_UI", new JSMarshalerType[3]
			{
				JSMarshalerType.String,
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
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0myk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("DCTools20221228.GetResourceUrl", "DCTools20221228")]
	internal static string z0xek(string p0)
	{
		if (z0htk == null)
		{
			z0htk = JSFunctionBinding.BindJSFunction("DCTools20221228.GetResourceUrl", "DCTools20221228", new JSMarshalerType[2]
			{
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0htk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[JSImport("WriterControl_UI.IsPrintPreview", "WriterControl_UI")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static bool z0zek(string p0)
	{
		if (z0gyk == null)
		{
			z0gyk = JSFunctionBinding.BindJSFunction("WriterControl_UI.IsPrintPreview", "WriterControl_UI", new JSMarshalerType[2]
			{
				JSMarshalerType.Boolean,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0gyk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[JSImport("WriterControl_UI.RaiseEventUpdateToolarState", "WriterControl_UI")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0lrk(string p0)
	{
		if (z0lyk == null)
		{
			z0lyk = JSFunctionBinding.BindJSFunction("WriterControl_UI.RaiseEventUpdateToolarState", "WriterControl_UI", new JSMarshalerType[2]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		arguments[1].Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0lyk, arguments);
	}

	[JSImport("WriterControl_UI.ShowDateTimeControl", "WriterControl_UI")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static void z0eek(string p0, int p1, int p2, int p3, int p4, [JSMarshalAs<JSType.Date>] DateTime p5, int p6)
	{
		if (z0ntk == null)
		{
			z0ntk = JSFunctionBinding.BindJSFunction("WriterControl_UI.ShowDateTimeControl", "WriterControl_UI", new JSMarshalerType[8]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.DateTime,
				JSMarshalerType.Int32
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[9];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		ref JSMarshalerArgument reference3 = ref arguments[4];
		ref JSMarshalerArgument reference4 = ref arguments[5];
		ref JSMarshalerArgument reference5 = ref arguments[6];
		ref JSMarshalerArgument reference6 = ref arguments[7];
		ref JSMarshalerArgument reference7 = ref arguments[8];
		reference.ToJS(p0);
		reference2.ToJS(p1);
		reference3.ToJS(p2);
		reference4.ToJS(p3);
		reference5.ToJS(p4);
		reference6.ToJS(p5);
		reference7.ToJS(p6);
		JSFunctionBinding.InvokeJS(z0ntk, arguments);
	}

	private static async Task z0krk_jiejie20260327142557(string p0)
	{
		string text = ((z0vyk.IndexOf("{0}") <= 0) ? (z0vyk + p0 + ".js") : z0vyk.Replace("{0}", p0 + ".js"));
		await JSHost.ImportAsync(p0, text);
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("DCTools20221228.HtmlToJson", "DCTools20221228")]
	internal static string z0jrk(string p0)
	{
		if (z0iyk == null)
		{
			z0iyk = JSFunctionBinding.BindJSFunction("DCTools20221228.HtmlToJson", "DCTools20221228", new JSMarshalerType[2]
			{
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0iyk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[JSImport("DCTools20221228.JS_Eval", "DCTools20221228")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static string z0hrk(string p0)
	{
		if (z0srk == null)
		{
			z0srk = JSFunctionBinding.BindJSFunction("DCTools20221228.JS_Eval", "DCTools20221228", new JSMarshalerType[2]
			{
				JSMarshalerType.String,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0srk, arguments);
		reference.ToManaged(out string result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_IO.ReadDCXmlReaderInt32Indexs", "WriterControl_IO")]
	internal static byte[] z0eek(int p0)
	{
		if (z0xrk == null)
		{
			z0xrk = JSFunctionBinding.BindJSFunction("WriterControl_IO.ReadDCXmlReaderInt32Indexs", "WriterControl_IO", new JSMarshalerType[2]
			{
				JSMarshalerType.Array(JSMarshalerType.Byte),
				JSMarshalerType.Int32
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0xrk, arguments);
		reference.ToManaged(out byte[] result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_Paint.CloseReversibleShape", "WriterControl_Paint")]
	internal static bool z0grk(string p0)
	{
		if (z0nyk == null)
		{
			z0nyk = JSFunctionBinding.BindJSFunction("WriterControl_Paint.CloseReversibleShape", "WriterControl_Paint", new JSMarshalerType[2]
			{
				JSMarshalerType.Boolean,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		ref JSMarshalerArgument reference = ref arguments[1];
		reference.Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0nyk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[JSImport("DCTools20221228.IsMatchRegex", "DCTools20221228")]
	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	internal static bool z0nek(string p0, string p1)
	{
		if (z0ytk == null)
		{
			z0ytk = JSFunctionBinding.BindJSFunction("DCTools20221228.IsMatchRegex", "DCTools20221228", new JSMarshalerType[3]
			{
				JSMarshalerType.Boolean,
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
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		JSFunctionBinding.InvokeJS(z0ytk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_Paint.ReversibleDraw", "WriterControl_Paint")]
	internal static bool z0eek(string p0, int p1, int p2, int p3, int p4, int p5, int p6)
	{
		if (z0ttk == null)
		{
			z0ttk = JSFunctionBinding.BindJSFunction("WriterControl_Paint.ReversibleDraw", "WriterControl_Paint", new JSMarshalerType[8]
			{
				JSMarshalerType.Boolean,
				JSMarshalerType.String,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32,
				JSMarshalerType.Int32
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
		reference2.ToJS(p0);
		reference3.ToJS(p1);
		reference4.ToJS(p2);
		reference5.ToJS(p3);
		reference6.ToJS(p4);
		reference7.ToJS(p5);
		reference8.ToJS(p6);
		JSFunctionBinding.InvokeJS(z0ttk, arguments);
		reference.ToManaged(out bool result);
		return result;
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("DCTools20221228.ConsoleWriteLine", "DCTools20221228")]
	internal static void z0frk(string p0)
	{
		if (z0brk == null)
		{
			z0brk = JSFunctionBinding.BindJSFunction("DCTools20221228.ConsoleWriteLine", "DCTools20221228", new JSMarshalerType[2]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[3];
		arguments[0].Initialize();
		arguments[1].Initialize();
		arguments[2].ToJS(p0);
		JSFunctionBinding.InvokeJS(z0brk, arguments);
	}

	[GeneratedCode("Microsoft.Interop.JavaScript.JSImportGenerator", "7.0.10.26716")]
	[JSImport("WriterControl_UI.SetElementCursor", "WriterControl_UI")]
	internal static void z0eek(string p0, int p1, string p2)
	{
		if (z0xyk == null)
		{
			z0xyk = JSFunctionBinding.BindJSFunction("WriterControl_UI.SetElementCursor", "WriterControl_UI", new JSMarshalerType[4]
			{
				JSMarshalerType.Discard,
				JSMarshalerType.String,
				JSMarshalerType.Int32,
				JSMarshalerType.String
			});
		}
		Span<JSMarshalerArgument> arguments = stackalloc JSMarshalerArgument[5];
		arguments[0].Initialize();
		arguments[1].Initialize();
		ref JSMarshalerArgument reference = ref arguments[2];
		ref JSMarshalerArgument reference2 = ref arguments[3];
		ref JSMarshalerArgument reference3 = ref arguments[4];
		reference.ToJS(p0);
		reference2.ToJS(p1);
		reference3.ToJS(p2);
		JSFunctionBinding.InvokeJS(z0xyk, arguments);
	}
}
