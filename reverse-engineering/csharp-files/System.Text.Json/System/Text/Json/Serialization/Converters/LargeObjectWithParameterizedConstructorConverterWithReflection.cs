using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class LargeObjectWithParameterizedConstructorConverterWithReflection<T> : LargeObjectWithParameterizedConstructorConverter<T>
{
	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public LargeObjectWithParameterizedConstructorConverterWithReflection()
	{
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	internal override void ConfigureJsonTypeInfoUsingReflection(JsonTypeInfo P_0, JsonSerializerOptions P_1)
	{
		P_0.CreateObjectWithArgs = P_1.MemberAccessorStrategy.CreateParameterizedConstructor<T>(base.ConstructorInfo);
	}
}
