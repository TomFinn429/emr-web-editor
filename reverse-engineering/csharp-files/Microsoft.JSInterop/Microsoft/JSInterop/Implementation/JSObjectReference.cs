using System;
using System.Runtime.CompilerServices;

namespace Microsoft.JSInterop.Implementation;

public class JSObjectReference : IJSObjectReference, IAsyncDisposable
{
	private readonly JSRuntime _jsRuntime;

	[CompilerGenerated]
	private bool _003CDisposed_003Ek__BackingField;

	internal bool Disposed
	{
		[CompilerGenerated]
		get
		{
			return _003CDisposed_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CDisposed_003Ek__BackingField = flag;
		}
	}

	protected internal long Id { get; }

	protected internal JSObjectReference(JSRuntime P_0, long P_1)
	{
		_jsRuntime = P_0;
		Id = P_1;
	}
}
