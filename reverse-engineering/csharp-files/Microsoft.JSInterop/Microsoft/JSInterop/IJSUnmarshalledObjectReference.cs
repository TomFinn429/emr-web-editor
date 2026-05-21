using System;

namespace Microsoft.JSInterop;

public interface IJSUnmarshalledObjectReference : IJSInProcessObjectReference, IJSObjectReference, IAsyncDisposable, IDisposable
{
}
