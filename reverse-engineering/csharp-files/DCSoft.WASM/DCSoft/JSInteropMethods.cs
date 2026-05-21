using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace DCSoft;

public static class JSInteropMethods
{
	[JSInvokable]
	public static async ValueTask<bool> NotifyLocationChangingAsync(string uri, string? state, bool isInterceptedLink)
	{
		return false;
	}

	[JSInvokable]
	public static void NotifyLocationChanged(string uri, string? state, bool isInterceptedLink)
	{
	}
}
