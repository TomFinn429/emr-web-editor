using System;

namespace Microsoft.JSInterop;

public interface IJSUnmarshalledRuntime
{
	[Obsolete("This method is obsolete. Use JSImportAttribute instead.")]
	TResult InvokeUnmarshalled<TResult>(string P_0);
}
