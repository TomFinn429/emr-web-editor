using System;

namespace Microsoft.JSInterop;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class JSInvokableAttribute : Attribute
{
	public string? Identifier { get; }
}
