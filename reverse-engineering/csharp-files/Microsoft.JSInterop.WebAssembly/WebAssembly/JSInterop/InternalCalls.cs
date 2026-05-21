using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace WebAssembly.JSInterop;

internal static class InternalCalls
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern TRes InvokeJS<T0, T1, T2, TRes>(out string P_0, ref JSCallInfo P_1, [AllowNull] T0 P_2, [AllowNull] T1 P_3, [AllowNull] T2 P_4);
}
