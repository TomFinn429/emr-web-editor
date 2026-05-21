using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization.Metadata;

internal sealed class PolymorphicTypeResolver
{
	private sealed class DerivedJsonTypeInfo
	{
		private volatile JsonTypeInfo _jsonTypeInfo;

		public Type DerivedType { get; }

		public object TypeDiscriminator { get; }

		public DerivedJsonTypeInfo(Type P_0, object P_1)
		{
			DerivedType = P_0;
			TypeDiscriminator = P_1;
		}

		public JsonTypeInfo GetJsonTypeInfo(JsonSerializerOptions P_0)
		{
			return _jsonTypeInfo ?? (_jsonTypeInfo = P_0.GetTypeInfoInternal(DerivedType));
		}
	}

	private readonly JsonTypeInfo _declaringTypeInfo;

	private readonly ConcurrentDictionary<Type, DerivedJsonTypeInfo> _typeToDiscriminatorId = new ConcurrentDictionary<Type, DerivedJsonTypeInfo>();

	private readonly Dictionary<object, DerivedJsonTypeInfo> _discriminatorIdtoType;

	[CompilerGenerated]
	private readonly string _003CTypeDiscriminatorPropertyName_003Ek__BackingField;

	public Type BaseType => _declaringTypeInfo.Type;

	public JsonUnknownDerivedTypeHandling UnknownDerivedTypeHandling { get; }

	public bool UsesTypeDiscriminators { get; }

	public bool IgnoreUnrecognizedTypeDiscriminators { get; }

	public byte[] TypeDiscriminatorPropertyNameUtf8 { get; }

	public JsonEncodedText? CustomTypeDiscriminatorPropertyNameJsonEncoded { get; }

	public PolymorphicTypeResolver(JsonTypeInfo P_0)
	{
		JsonPolymorphismOptions polymorphismOptions = P_0.PolymorphismOptions;
		UnknownDerivedTypeHandling = polymorphismOptions.UnknownDerivedTypeHandling;
		IgnoreUnrecognizedTypeDiscriminators = polymorphismOptions.IgnoreUnrecognizedTypeDiscriminators;
		_declaringTypeInfo = P_0;
		if (!IsSupportedPolymorphicBaseType(BaseType))
		{
			ThrowHelper.ThrowInvalidOperationException_TypeDoesNotSupportPolymorphism(BaseType);
		}
		bool flag = false;
		foreach (var (type2, obj2) in polymorphismOptions.DerivedTypes)
		{
			if (!IsSupportedDerivedType(BaseType, type2) || (type2.IsAbstract && UnknownDerivedTypeHandling != JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor))
			{
				ThrowHelper.ThrowInvalidOperationException_DerivedTypeNotSupported(BaseType, type2);
			}
			DerivedJsonTypeInfo derivedJsonTypeInfo = new DerivedJsonTypeInfo(type2, obj2);
			if (!_typeToDiscriminatorId.TryAdd(type2, derivedJsonTypeInfo))
			{
				ThrowHelper.ThrowInvalidOperationException_DerivedTypeIsAlreadySpecified(BaseType, type2);
			}
			if (obj2 != null)
			{
				if (!(_discriminatorIdtoType ?? (_discriminatorIdtoType = new Dictionary<object, DerivedJsonTypeInfo>())).TryAdd(obj2, derivedJsonTypeInfo))
				{
					ThrowHelper.ThrowInvalidOperationException_TypeDicriminatorIdIsAlreadySpecified(BaseType, obj2);
				}
				UsesTypeDiscriminators = true;
			}
			flag = true;
		}
		if (!flag)
		{
			ThrowHelper.ThrowInvalidOperationException_PolymorphicTypeConfigurationDoesNotSpecifyDerivedTypes(BaseType);
		}
		if (UsesTypeDiscriminators)
		{
			if (!P_0.Converter.CanHaveMetadata)
			{
				ThrowHelper.ThrowNotSupportedException_BaseConverterDoesNotSupportMetadata(BaseType);
			}
			string typeDiscriminatorPropertyName = P_0.PolymorphismOptions.TypeDiscriminatorPropertyName;
			JsonEncodedText value = ((typeDiscriminatorPropertyName == "$type") ? JsonSerializer.s_metadataType : JsonEncodedText.Encode(typeDiscriminatorPropertyName, P_0.Options.Encoder));
			if ((JsonSerializer.GetMetadataPropertyName(value.EncodedUtf8Bytes, null) & ~MetadataPropertyName.Type) != MetadataPropertyName.None)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidCustomTypeDiscriminatorPropertyName();
			}
			_003CTypeDiscriminatorPropertyName_003Ek__BackingField = typeDiscriminatorPropertyName;
			TypeDiscriminatorPropertyNameUtf8 = value.EncodedUtf8Bytes.ToArray();
			CustomTypeDiscriminatorPropertyNameJsonEncoded = value;
		}
	}

	public bool TryGetDerivedJsonTypeInfo(Type P_0, [NotNullWhen(true)] out JsonTypeInfo P_1, out object P_2)
	{
		if (!_typeToDiscriminatorId.TryGetValue(P_0, out var derivedJsonTypeInfo))
		{
			switch (UnknownDerivedTypeHandling)
			{
			case JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor:
				derivedJsonTypeInfo = CalculateNearestAncestor(P_0);
				_typeToDiscriminatorId[P_0] = derivedJsonTypeInfo;
				break;
			case JsonUnknownDerivedTypeHandling.FallBackToBaseType:
				_typeToDiscriminatorId.TryGetValue(BaseType, out derivedJsonTypeInfo);
				_typeToDiscriminatorId[P_0] = derivedJsonTypeInfo;
				break;
			default:
				if (P_0 != BaseType)
				{
					ThrowHelper.ThrowNotSupportedException_RuntimeTypeNotSupported(BaseType, P_0);
				}
				break;
			}
		}
		if (derivedJsonTypeInfo == null)
		{
			P_1 = null;
			P_2 = null;
			return false;
		}
		P_1 = derivedJsonTypeInfo.GetJsonTypeInfo(_declaringTypeInfo.Options);
		P_2 = derivedJsonTypeInfo.TypeDiscriminator;
		return true;
	}

	public bool TryGetDerivedJsonTypeInfo(object P_0, [NotNullWhen(true)] out JsonTypeInfo P_1)
	{
		if (_discriminatorIdtoType.TryGetValue(P_0, out var derivedJsonTypeInfo))
		{
			P_1 = derivedJsonTypeInfo.GetJsonTypeInfo(_declaringTypeInfo.Options);
			return true;
		}
		if (!IgnoreUnrecognizedTypeDiscriminators)
		{
			ThrowHelper.ThrowJsonException_UnrecognizedTypeDiscriminator(P_0);
		}
		P_1 = null;
		return false;
	}

	public static bool IsSupportedPolymorphicBaseType(Type P_0)
	{
		if (P_0 != null && (P_0.IsClass || P_0.IsInterface) && !P_0.IsSealed && !P_0.IsGenericTypeDefinition && !P_0.IsPointer)
		{
			return P_0 != JsonTypeInfo.ObjectType;
		}
		return false;
	}

	public static bool IsSupportedDerivedType(Type P_0, Type P_1)
	{
		if (P_0.IsAssignableFrom(P_1))
		{
			return !P_1.IsGenericTypeDefinition;
		}
		return false;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "The call to GetInterfaces will cross-reference results with interface types already declared as derived types of the polymorphic base type.")]
	private DerivedJsonTypeInfo CalculateNearestAncestor(Type P_0)
	{
		if (P_0 == BaseType)
		{
			return null;
		}
		DerivedJsonTypeInfo derivedJsonTypeInfo = null;
		Type baseType = P_0.BaseType;
		while (BaseType.IsAssignableFrom(baseType) && !_typeToDiscriminatorId.TryGetValue(baseType, out derivedJsonTypeInfo))
		{
			baseType = baseType.BaseType;
		}
		if (BaseType.IsInterface)
		{
			Type[] interfaces = P_0.GetInterfaces();
			foreach (Type type in interfaces)
			{
				if (type != BaseType && BaseType.IsAssignableFrom(type) && _typeToDiscriminatorId.TryGetValue(type, out var derivedJsonTypeInfo2) && derivedJsonTypeInfo2 != null)
				{
					if (derivedJsonTypeInfo == null)
					{
						derivedJsonTypeInfo = derivedJsonTypeInfo2;
					}
					else
					{
						ThrowHelper.ThrowNotSupportedException_RuntimeTypeDiamondAmbiguity(BaseType, P_0, derivedJsonTypeInfo.DerivedType, derivedJsonTypeInfo2.DerivedType);
					}
				}
			}
		}
		return derivedJsonTypeInfo;
	}
}
