using System.Reflection;
using Microsoft.JSInterop.Infrastructure;

namespace Microsoft.JSInterop;

internal static class JSCallResultTypeHelper
{
	private static readonly Assembly _currentAssembly = typeof(JSCallResultType).Assembly;

	public static JSCallResultType FromGeneric<TResult>()
	{
		if (typeof(TResult).Assembly == _currentAssembly)
		{
			if (typeof(TResult) == typeof(IJSObjectReference) || typeof(TResult) == typeof(IJSInProcessObjectReference) || typeof(TResult) == typeof(IJSUnmarshalledObjectReference))
			{
				return JSCallResultType.JSObjectReference;
			}
			if (typeof(TResult) == typeof(IJSStreamReference))
			{
				return JSCallResultType.JSStreamReference;
			}
			if (typeof(TResult) == typeof(IJSVoidResult))
			{
				return JSCallResultType.JSVoidResult;
			}
		}
		return JSCallResultType.Default;
	}
}
