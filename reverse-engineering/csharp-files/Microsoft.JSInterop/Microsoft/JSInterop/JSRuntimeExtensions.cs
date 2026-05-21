using System;
using System.Threading.Tasks;
using Microsoft.JSInterop.Infrastructure;

namespace Microsoft.JSInterop;

public static class JSRuntimeExtensions
{
	public static async ValueTask InvokeVoidAsync(this IJSRuntime P_0, string P_1, params object?[]? P_2)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("jsRuntime");
		}
		await P_0.InvokeAsync<IJSVoidResult>(P_1, P_2);
	}
}
