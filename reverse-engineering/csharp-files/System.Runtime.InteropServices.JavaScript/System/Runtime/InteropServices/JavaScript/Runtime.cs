using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices.JavaScript;

[Obsolete]
public static class Runtime
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object Invoke(this JSObject P_0, string P_1, params object?[] P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "self");
		ObjectDisposedException.ThrowIf(P_0.IsDisposed, P_0);
		global::Interop.Runtime.InvokeJSWithArgsRef(P_0.JSHandle, in P_1, in P_2, out var num, out var obj);
		if (num != 0)
		{
			throw new JSException((string)obj);
		}
		JSHostImplementation.ReleaseInFlight(obj);
		return obj;
	}

	public static void AssertNotDisposed(this JSObject P_0)
	{
		ObjectDisposedException.ThrowIf(P_0.IsDisposed, P_0);
	}
}
