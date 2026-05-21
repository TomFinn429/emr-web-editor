using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.InteropServices.JavaScript;

[SupportedOSPlatform("browser")]
public static class JSHost
{
	public static JSObject DotnetInstance => JavaScriptImports.GetDotnetInstance();

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Task<JSObject> ImportAsync(string P_0, string P_1, CancellationToken P_2 = default(CancellationToken))
	{
		return JSHostImplementation.ImportAsync(P_0, P_1, P_2);
	}
}
