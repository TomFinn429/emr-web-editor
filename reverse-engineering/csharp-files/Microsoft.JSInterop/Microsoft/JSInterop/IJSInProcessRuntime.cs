using System.Diagnostics.CodeAnalysis;

namespace Microsoft.JSInterop;

public interface IJSInProcessRuntime : IJSRuntime
{
	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed.")]
	TResult Invoke<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TResult>(string P_0, params object?[]? P_1);
}
