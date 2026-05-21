using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Reflection;
using System.Text.Json.Serialization.Converters;
using System.Threading;

namespace System.Text.Json.Serialization.Metadata;

public class DefaultJsonTypeInfoResolver : IJsonTypeInfoResolver
{
	private sealed class ModifierCollection : ConfigurationList<Action<JsonTypeInfo>>
	{
		protected override bool IsImmutable
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw new NotSupportedException("Linked away");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void VerifyMutable()
		{
			throw new NotSupportedException("Linked away");
		}
	}

	private static Dictionary<Type, JsonConverter> s_defaultSimpleConverters;

	private static JsonConverterFactory[] s_defaultFactoryConverters;

	private bool _mutable;

	private ModifierCollection _modifiers;

	private static DefaultJsonTypeInfoResolver s_defaultInstance;

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	private static JsonConverterFactory[] GetDefaultFactoryConverters()
	{
		return new JsonConverterFactory[8]
		{
			new UnsupportedTypeConverterFactory(),
			new NullableConverterFactory(),
			new EnumConverterFactory(),
			new JsonNodeConverterFactory(),
			new FSharpTypeConverterFactory(),
			new IAsyncEnumerableConverterFactory(),
			new IEnumerableConverterFactory(),
			new ObjectConverterFactory()
		};
	}

	private static Dictionary<Type, JsonConverter> GetDefaultSimpleConverters()
	{
		Dictionary<Type, JsonConverter> converters = new Dictionary<Type, JsonConverter>(26);
		Add(JsonMetadataServices.BooleanConverter);
		Add(JsonMetadataServices.ByteConverter);
		Add(JsonMetadataServices.ByteArrayConverter);
		Add(JsonMetadataServices.CharConverter);
		Add(JsonMetadataServices.DateTimeConverter);
		Add(JsonMetadataServices.DateTimeOffsetConverter);
		Add(JsonMetadataServices.DateOnlyConverter);
		Add(JsonMetadataServices.TimeOnlyConverter);
		Add(JsonMetadataServices.DoubleConverter);
		Add(JsonMetadataServices.DecimalConverter);
		Add(JsonMetadataServices.GuidConverter);
		Add(JsonMetadataServices.Int16Converter);
		Add(JsonMetadataServices.Int32Converter);
		Add(JsonMetadataServices.Int64Converter);
		Add(JsonMetadataServices.JsonElementConverter);
		Add(JsonMetadataServices.JsonDocumentConverter);
		Add(JsonMetadataServices.ObjectConverter);
		Add(JsonMetadataServices.SByteConverter);
		Add(JsonMetadataServices.SingleConverter);
		Add(JsonMetadataServices.StringConverter);
		Add(JsonMetadataServices.TimeSpanConverter);
		Add(JsonMetadataServices.UInt16Converter);
		Add(JsonMetadataServices.UInt32Converter);
		Add(JsonMetadataServices.UInt64Converter);
		Add(JsonMetadataServices.UriConverter);
		Add(JsonMetadataServices.VersionConverter);
		return converters;
		void Add(JsonConverter P_0)
		{
			converters.Add(P_0.TypeToConvert, P_0);
		}
	}

	private static JsonConverter GetBuiltInConverter(Type P_0)
	{
		if (s_defaultSimpleConverters.TryGetValue(P_0, out var result))
		{
			return result;
		}
		JsonConverterFactory[] array = s_defaultFactoryConverters;
		foreach (JsonConverterFactory jsonConverterFactory in array)
		{
			if (jsonConverterFactory.CanConvert(P_0))
			{
				return jsonConverterFactory;
			}
		}
		return result;
	}

	internal static bool TryGetDefaultSimpleConverter(Type P_0, [NotNullWhen(true)] out JsonConverter P_1)
	{
		if (s_defaultSimpleConverters == null)
		{
			P_1 = null;
			return false;
		}
		return s_defaultSimpleConverters.TryGetValue(P_0, out P_1);
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	internal static JsonConverter GetCustomConverterForMember(Type P_0, MemberInfo P_1, JsonSerializerOptions P_2)
	{
		JsonConverterAttribute uniqueCustomAttribute = P_1.GetUniqueCustomAttribute<JsonConverterAttribute>(false);
		if (uniqueCustomAttribute != null)
		{
			return GetConverterFromAttribute(uniqueCustomAttribute, P_0, P_1, P_2);
		}
		return null;
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	internal static JsonConverter GetConverterForType(Type P_0, JsonSerializerOptions P_1, bool P_2 = true)
	{
		RootDefaultInstance();
		JsonConverter jsonConverter = P_1.GetConverterFromList(P_0);
		if (P_2 && jsonConverter == null)
		{
			JsonConverterAttribute uniqueCustomAttribute = P_0.GetUniqueCustomAttribute<JsonConverterAttribute>(false);
			if (uniqueCustomAttribute != null)
			{
				jsonConverter = GetConverterFromAttribute(uniqueCustomAttribute, P_0, null, P_1);
			}
		}
		if (jsonConverter == null)
		{
			jsonConverter = GetBuiltInConverter(P_0);
		}
		jsonConverter = P_1.ExpandConverterFactory(jsonConverter, P_0);
		if (!jsonConverter.TypeToConvert.IsInSubtypeRelationshipWith(P_0))
		{
			ThrowHelper.ThrowInvalidOperationException_SerializationConverterNotCompatible(jsonConverter.GetType(), jsonConverter.TypeToConvert);
		}
		JsonSerializerOptions.CheckConverterNullabilityIsSameAsPropertyType(jsonConverter, P_0);
		return jsonConverter;
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	private static JsonConverter GetConverterFromAttribute(JsonConverterAttribute P_0, Type P_1, MemberInfo P_2, JsonSerializerOptions P_3)
	{
		Type type = P_2?.DeclaringType ?? P_1;
		Type converterType = P_0.ConverterType;
		JsonConverter jsonConverter;
		if (converterType == null)
		{
			jsonConverter = P_0.CreateConverter(P_1);
			if (jsonConverter == null)
			{
				ThrowHelper.ThrowInvalidOperationException_SerializationConverterOnAttributeNotCompatible(type, P_2, P_1);
			}
		}
		else
		{
			ConstructorInfo constructor = converterType.GetConstructor(Type.EmptyTypes);
			if (!typeof(JsonConverter).IsAssignableFrom(converterType) || constructor == null || !constructor.IsPublic)
			{
				ThrowHelper.ThrowInvalidOperationException_SerializationConverterOnAttributeInvalid(type, P_2);
			}
			jsonConverter = (JsonConverter)Activator.CreateInstance(converterType);
		}
		if (!jsonConverter.CanConvert(P_1))
		{
			Type underlyingType = Nullable.GetUnderlyingType(P_1);
			if (underlyingType != null && jsonConverter.CanConvert(underlyingType))
			{
				if (jsonConverter is JsonConverterFactory jsonConverterFactory)
				{
					jsonConverter = jsonConverterFactory.GetConverterInternal(underlyingType, P_3);
				}
				return NullableConverterFactory.CreateValueConverter(underlyingType, jsonConverter);
			}
			ThrowHelper.ThrowInvalidOperationException_SerializationConverterOnAttributeNotCompatible(type, P_2, P_1);
		}
		return jsonConverter;
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	private DefaultJsonTypeInfoResolver(bool P_0)
	{
		_mutable = P_0;
		if (s_defaultFactoryConverters == null)
		{
			s_defaultFactoryConverters = GetDefaultFactoryConverters();
		}
		if (s_defaultSimpleConverters == null)
		{
			s_defaultSimpleConverters = GetDefaultSimpleConverters();
		}
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The ctor is marked RequiresUnreferencedCode.")]
	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "The ctor is marked RequiresDynamicCode.")]
	public virtual JsonTypeInfo GetTypeInfo(Type P_0, JsonSerializerOptions P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("type");
		}
		if (P_1 == null)
		{
			ThrowHelper.ThrowArgumentNullException("options");
		}
		_mutable = false;
		JsonTypeInfo.ValidateType(P_0);
		JsonTypeInfo jsonTypeInfo = CreateJsonTypeInfo(P_0, P_1);
		if (_modifiers != null)
		{
			foreach (Action<JsonTypeInfo> modifier in _modifiers)
			{
				modifier(jsonTypeInfo);
			}
		}
		return jsonTypeInfo;
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	private static JsonTypeInfo CreateJsonTypeInfo(Type P_0, JsonSerializerOptions P_1)
	{
		JsonConverter converterForType = GetConverterForType(P_0, P_1);
		if (converterForType.TypeToConvert == P_0)
		{
			return converterForType.CreateReflectionJsonTypeInfo(P_1);
		}
		Type type = typeof(ReflectionJsonTypeInfo<>).MakeGenericType(P_0);
		return (JsonTypeInfo)type.CreateInstanceNoWrapExceptions(new Type[2]
		{
			typeof(JsonConverter),
			typeof(JsonSerializerOptions)
		}, new object[2] { converterForType, P_1 });
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	internal static DefaultJsonTypeInfoResolver RootDefaultInstance()
	{
		DefaultJsonTypeInfoResolver defaultJsonTypeInfoResolver = s_defaultInstance;
		if (defaultJsonTypeInfoResolver != null)
		{
			return defaultJsonTypeInfoResolver;
		}
		DefaultJsonTypeInfoResolver defaultJsonTypeInfoResolver2 = new DefaultJsonTypeInfoResolver(false);
		DefaultJsonTypeInfoResolver defaultJsonTypeInfoResolver3 = Interlocked.CompareExchange(ref s_defaultInstance, defaultJsonTypeInfoResolver2, null);
		return defaultJsonTypeInfoResolver3 ?? defaultJsonTypeInfoResolver2;
	}
}
