using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.JSInterop.Infrastructure;

namespace Microsoft.JSInterop;

public static class JSInProcessRuntimeExtensions
{
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The method returns void, so nothing is deserialized.")]
	public static void InvokeVoid(this IJSInProcessRuntime P_0, string P_1, params object?[]? P_2)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("jsRuntime");
		}
		P_0.Invoke<IJSVoidResult>(P_1, P_2);
	}
}
