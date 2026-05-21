using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json.Reflection;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
internal sealed class ObjectConverterFactory : JsonConverterFactory
{
	private readonly bool _useDefaultConstructorInUnannotatedStructs;

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	public ObjectConverterFactory(bool P_0 = true)
	{
		_useDefaultConstructorInUnannotatedStructs = P_0;
	}

	public override bool CanConvert(Type P_0)
	{
		return true;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The ctor is marked RequiresUnreferencedCode.")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2067:UnrecognizedReflectionPattern", Justification = "The ctor is marked RequiresUnreferencedCode.")]
	public override JsonConverter CreateConverter(Type P_0, JsonSerializerOptions P_1)
	{
		if (P_0.IsKeyValuePair())
		{
			return CreateKeyValuePairConverter(P_0);
		}
		if (!P_0.TryGetDeserializationConstructor(_useDefaultConstructorInUnannotatedStructs, out var constructorInfo))
		{
			ThrowHelper.ThrowInvalidOperationException_SerializationDuplicateTypeAttribute<JsonConstructorAttribute>(P_0);
		}
		ParameterInfo[] array = constructorInfo?.GetParameters();
		Type type;
		if (constructorInfo == null || P_0.IsAbstract || array.Length == 0)
		{
			type = typeof(ObjectDefaultConverter<>).MakeGenericType(P_0);
		}
		else
		{
			int num = array.Length;
			if (num <= 4)
			{
				Type objectType = JsonTypeInfo.ObjectType;
				Type[] array2 = new Type[5] { P_0, null, null, null, null };
				for (int i = 0; i < 4; i++)
				{
					if (i < num)
					{
						array2[i + 1] = array[i].ParameterType;
					}
					else
					{
						array2[i + 1] = objectType;
					}
				}
				type = typeof(SmallObjectWithParameterizedConstructorConverter<, , , , >).MakeGenericType(array2);
			}
			else
			{
				type = typeof(LargeObjectWithParameterizedConstructorConverterWithReflection<>).MakeGenericType(P_0);
			}
		}
		JsonConverter jsonConverter = (JsonConverter)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public, null, null, null);
		jsonConverter.ConstructorInfo = constructorInfo;
		return jsonConverter;
	}

	private static JsonConverter CreateKeyValuePairConverter(Type P_0)
	{
		Type type = P_0.GetGenericArguments()[0];
		Type type2 = P_0.GetGenericArguments()[1];
		return (JsonConverter)Activator.CreateInstance(typeof(KeyValuePairConverter<, >).MakeGenericType(type, type2), BindingFlags.Instance | BindingFlags.Public, null, null, null);
	}
}
