using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Reflection;
using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Serialization;

[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
internal sealed class IAsyncEnumerableConverterFactory : JsonConverterFactory
{
	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	public IAsyncEnumerableConverterFactory()
	{
	}

	public override bool CanConvert(Type P_0)
	{
		return (object)GetAsyncEnumerableInterface(P_0) != null;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The ctor is marked RequiresUnreferencedCode.")]
	public override JsonConverter CreateConverter(Type P_0, JsonSerializerOptions P_1)
	{
		Type asyncEnumerableInterface = GetAsyncEnumerableInterface(P_0);
		Type type = asyncEnumerableInterface.GetGenericArguments()[0];
		Type type2 = typeof(IAsyncEnumerableOfTConverter<, >).MakeGenericType(P_0, type);
		return (JsonConverter)Activator.CreateInstance(type2);
	}

	private static Type GetAsyncEnumerableInterface(Type P_0)
	{
		return P_0.GetCompatibleGenericInterface(typeof(IAsyncEnumerable<>));
	}
}
