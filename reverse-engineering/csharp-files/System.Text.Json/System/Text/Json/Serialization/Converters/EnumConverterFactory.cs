using System.Diagnostics.CodeAnalysis;

namespace System.Text.Json.Serialization.Converters;

[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
internal sealed class EnumConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type P_0)
	{
		return P_0.IsEnum;
	}

	public override JsonConverter CreateConverter(Type P_0, JsonSerializerOptions P_1)
	{
		return Create(P_0, EnumConverterOptions.AllowNumbers, null, P_1);
	}

	internal static JsonConverter Create(Type P_0, EnumConverterOptions P_1, JsonNamingPolicy P_2, JsonSerializerOptions P_3)
	{
		return (JsonConverter)Activator.CreateInstance(GetEnumConverterType(P_0), P_1, P_2, P_3);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "'EnumConverter<T> where T : struct' implies 'T : new()', so the trimmer is warning calling MakeGenericType here because enumType's constructors are not annotated. But EnumConverter doesn't call new T(), so this is safe.")]
	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	private static Type GetEnumConverterType(Type P_0)
	{
		return typeof(EnumConverter<>).MakeGenericType(P_0);
	}
}
