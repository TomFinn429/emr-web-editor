using System;

namespace Microsoft.JSInterop.Infrastructure;

internal interface IDotNetObjectReference : IDisposable
{
	object Value { get; }
}
