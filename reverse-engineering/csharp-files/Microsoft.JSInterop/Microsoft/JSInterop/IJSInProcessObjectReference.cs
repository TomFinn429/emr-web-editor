using System;

namespace Microsoft.JSInterop;

public interface IJSInProcessObjectReference : IJSObjectReference, IAsyncDisposable, IDisposable
{
}
