using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json.Reflection;

namespace System.Text.Json.Serialization.Converters;

[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
internal sealed class NullableConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type P_0)
	{
		return P_0.IsNullableOfT();
	}

	public override JsonConverter CreateConverter(Type P_0, JsonSerializerOptions P_1)
	{
		Type type = P_0.GetGenericArguments()[0];
		JsonConverter converterInternal = P_1.GetConverterInternal(type);
		if (!converterInternal.TypeToConvert.IsValueType && type.IsValueType)
		{
			return converterInternal;
		}
		return CreateValueConverter(type, converterInternal);
	}

	public static JsonConverter CreateValueConverter(Type P_0, JsonConverter P_1)
	{
		return (JsonConverter)Activator.CreateInstance(GetNullableConverterType(P_0), BindingFlags.Instance | BindingFlags.Public, null, new object[1] { P_1 }, null);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "'NullableConverter<T> where T : struct' implies 'T : new()', so the trimmer is warning calling MakeGenericType here because valueTypeToConvert's constructors are not annotated. But NullableConverter doesn't call new T(), so this is safe.")]
	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	private static Type GetNullableConverterType(Type P_0)
	{
		return typeof(NullableConverter<>).MakeGenericType(P_0);
	}
}
