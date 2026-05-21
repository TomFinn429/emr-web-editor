using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Microsoft.JSInterop;

public abstract class JSInProcessRuntime : JSRuntime, IJSInProcessRuntime, IJSRuntime
{
	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed.")]
	internal TValue Invoke<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(string P_0, long P_1, params object?[]? P_2)
	{
		string text = InvokeJS(P_0, JsonSerializer.Serialize(P_2, base.JsonSerializerOptions), JSCallResultTypeHelper.FromGeneric<TValue>(), P_1);
		if (text == null)
		{
			return default(TValue);
		}
		TValue? result = JsonSerializer.Deserialize<TValue>(text, base.JsonSerializerOptions);
		ByteArraysToBeRevived.Clear();
		return result;
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed.")]
	public TValue Invoke<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(string P_0, params object?[]? P_1)
	{
		return Invoke<TValue>(P_0, 0L, P_1);
	}

	protected abstract string? InvokeJS(string P_0, string? P_1, JSCallResultType P_2, long P_3);
}
