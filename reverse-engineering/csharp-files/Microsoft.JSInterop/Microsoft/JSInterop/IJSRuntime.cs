using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Microsoft.JSInterop;

public interface IJSRuntime
{
	ValueTask<TValue> InvokeAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(string P_0, object?[]? P_1);
}
