using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Internal.Runtime.InteropServices;

public static class ComponentActivator
{
	[RequiresDynamicCode("The native code for the method requested might not be available at runtime.")]
	[UnmanagedCallersOnly]
	public static int GetFunctionPointer(nint P_0, nint P_1, nint P_2, nint P_3, nint P_4, nint P_5)
	{
		_ = 0;
		return -2147450713;
	}
}
