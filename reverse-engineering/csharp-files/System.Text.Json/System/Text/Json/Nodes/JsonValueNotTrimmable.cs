using System.Diagnostics.CodeAnalysis;

namespace System.Text.Json.Nodes;

[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
internal sealed class JsonValueNotTrimmable<TValue> : JsonValue<TValue>
{
	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	public JsonValueNotTrimmable(TValue P_0, JsonNodeOptions? P_1 = null)
		: base(P_0, P_1)
	{
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The ctor is marked RequiresUnreferencedCode.")]
	public override void WriteTo(Utf8JsonWriter P_0, JsonSerializerOptions P_1 = null)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("writer");
		}
		JsonSerializer.Serialize(P_0, _value, P_1);
	}
}
