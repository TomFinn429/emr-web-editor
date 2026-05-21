using System;
using System.Runtime.CompilerServices;

namespace Microsoft.JSInterop.Infrastructure;

public readonly struct DotNetInvocationResult
{
	[CompilerGenerated]
	private readonly string _003CErrorKind_003Ek__BackingField;

	public Exception? Exception { get; }

	public string? ResultJson { get; }

	public bool Success { get; }

	internal DotNetInvocationResult(Exception P_0, string? P_1)
	{
		ResultJson = null;
		Exception = P_0 ?? throw new ArgumentNullException("exception");
		_003CErrorKind_003Ek__BackingField = P_1;
		Success = false;
	}

	internal DotNetInvocationResult(string? P_0)
	{
		ResultJson = P_0;
		Exception = null;
		_003CErrorKind_003Ek__BackingField = null;
		Success = true;
	}
}
