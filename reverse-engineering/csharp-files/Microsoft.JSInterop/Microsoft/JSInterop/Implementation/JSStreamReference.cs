using System;
using System.Runtime.CompilerServices;

namespace Microsoft.JSInterop.Implementation;

public sealed class JSStreamReference : JSObjectReference, IJSStreamReference, IAsyncDisposable
{
	private readonly JSRuntime _jsRuntime;

	[CompilerGenerated]
	private readonly long _003CLength_003Ek__BackingField;

	internal JSStreamReference(JSRuntime P_0, long P_1, long P_2)
		: base(P_0, P_1)
	{
		if (P_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("totalLength", P_2, "Length must be a positive value.");
		}
		_jsRuntime = P_0;
		_003CLength_003Ek__BackingField = P_2;
	}
}
