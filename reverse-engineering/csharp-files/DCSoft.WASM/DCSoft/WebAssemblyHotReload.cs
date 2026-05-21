using Microsoft.JSInterop;

namespace DCSoft;

public static class WebAssemblyHotReload
{
	[JSInvokable]
	public static string GetApplyUpdateCapabilities()
	{
		return null;
	}

	[JSInvokable]
	public static void ApplyHotReloadDelta(string moduleIdString, byte[] metadataDelta, byte[] ilDelta, byte[] pdbBytes)
	{
	}
}
