using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json.Reflection;

namespace System.Text.Json.Serialization.Metadata;

internal sealed class ReflectionJsonTypeInfo<T> : JsonTypeInfo<T>
{
	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	internal ReflectionJsonTypeInfo(JsonConverter converter, JsonSerializerOptions options)
		: base(converter, options)
	{
		base.NumberHandling = GetNumberHandlingForType(base.Type);
		PopulatePolymorphismMetadata();
		MapInterfaceTypesToCallbacks();
		Func<object> func = base.Options.MemberAccessorStrategy.CreateConstructor(typeof(T));
		SetCreateObjectIfCompatible(func);
		base.CreateObjectForExtensionDataProperty = func;
		converter.ConfigureJsonTypeInfo(this, options);
		converter.ConfigureJsonTypeInfoUsingReflection(this, options);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075:RequiresUnreferencedCode", Justification = "The ctor is marked RequiresUnreferencedCode.")]
	internal override void LateAddProperties()
	{
		if (base.Kind != JsonTypeInfoKind.Object)
		{
			return;
		}
		Dictionary<string, JsonPropertyInfo> dictionary = null;
		bool flag = false;
		bool flag2 = typeof(T).HasRequiredMemberAttribute() && !(base.Converter.ConstructorInfo?.HasSetsRequiredMembersAttribute() ?? false);
		Type type = base.Type;
		while (type != null)
		{
			PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (base.PropertyCache == null)
			{
				JsonPropertyDictionary<JsonPropertyInfo> jsonPropertyDictionary = (base.PropertyCache = CreatePropertyCache(properties.Length));
			}
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				string name = propertyInfo.Name;
				if (propertyInfo.GetIndexParameters().Length != 0 || PropertyIsOverriddenAndIgnored(name, propertyInfo.PropertyType, propertyInfo.IsVirtual(), dictionary))
				{
					continue;
				}
				MethodInfo? getMethod = propertyInfo.GetMethod;
				if ((object)getMethod == null || !getMethod.IsPublic)
				{
					MethodInfo? setMethod = propertyInfo.SetMethod;
					if ((object)setMethod == null || !setMethod.IsPublic)
					{
						if (propertyInfo.GetCustomAttribute<JsonIncludeAttribute>(false) != null)
						{
							ThrowHelper.ThrowInvalidOperationException_JsonIncludeOnNonPublicInvalid(name, type);
						}
						continue;
					}
				}
				CacheMember(propertyInfo.PropertyType, propertyInfo, ref flag, ref dictionary, flag2);
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				string name2 = fieldInfo.Name;
				if (PropertyIsOverriddenAndIgnored(name2, fieldInfo.FieldType, false, dictionary))
				{
					continue;
				}
				bool flag3 = fieldInfo.GetCustomAttribute<JsonIncludeAttribute>(false) != null;
				if (fieldInfo.IsPublic)
				{
					if (flag3 || base.Options.IncludeFields)
					{
						CacheMember(fieldInfo.FieldType, fieldInfo, ref flag, ref dictionary, flag2);
					}
				}
				else if (flag3)
				{
					ThrowHelper.ThrowInvalidOperationException_JsonIncludeOnNonPublicInvalid(name2, type);
				}
			}
			type = type.BaseType;
		}
		if (flag)
		{
			base.PropertyCache.List.StableSortByKey<KeyValuePair<string, JsonPropertyInfo>, int>((KeyValuePair<string, JsonPropertyInfo> P_0) => P_0.Value.Order);
		}
	}

	private void CacheMember(Type P_0, MemberInfo P_1, ref bool P_2, ref Dictionary<string, JsonPropertyInfo> P_3, bool P_4)
	{
		JsonPropertyInfo jsonPropertyInfo = CreateProperty(P_0, P_1, base.Options, P_4);
		if (jsonPropertyInfo != null)
		{
			CacheMember(jsonPropertyInfo, base.PropertyCache, ref P_3);
			P_2 |= jsonPropertyInfo.Order != 0;
		}
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The ctor is marked as RequiresUnreferencedCode")]
	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "The ctor is marked RequiresDynamicCode.")]
	private JsonPropertyInfo CreateProperty(Type P_0, MemberInfo P_1, JsonSerializerOptions P_2, bool P_3)
	{
		JsonIgnoreCondition? jsonIgnoreCondition = P_1.GetCustomAttribute<JsonIgnoreAttribute>(false)?.Condition;
		if (JsonTypeInfo.IsInvalidForSerialization(P_0))
		{
			if (jsonIgnoreCondition == JsonIgnoreCondition.Always)
			{
				return null;
			}
			ThrowHelper.ThrowInvalidOperationException_CannotSerializeInvalidType(P_0, P_1.DeclaringType, P_1);
		}
		JsonConverter customConverterForMember;
		try
		{
			customConverterForMember = DefaultJsonTypeInfoResolver.GetCustomConverterForMember(P_0, P_1, P_2);
		}
		catch (InvalidOperationException) when (jsonIgnoreCondition == JsonIgnoreCondition.Always)
		{
			return null;
		}
		JsonPropertyInfo jsonPropertyInfo = CreatePropertyUsingReflection(P_0);
		jsonPropertyInfo.InitializeUsingMemberReflection(P_1, customConverterForMember, jsonIgnoreCondition, P_3);
		return jsonPropertyInfo;
	}

	private static JsonNumberHandling? GetNumberHandlingForType(Type P_0)
	{
		return P_0.GetUniqueCustomAttribute<JsonNumberHandlingAttribute>(false)?.Handling;
	}

	private static bool PropertyIsOverriddenAndIgnored(string P_0, Type P_1, bool P_2, Dictionary<string, JsonPropertyInfo> P_3)
	{
		if (P_3 == null || !P_3.TryGetValue(P_0, out var jsonPropertyInfo))
		{
			return false;
		}
		if (P_1 == jsonPropertyInfo.PropertyType && P_2)
		{
			return jsonPropertyInfo.IsVirtual;
		}
		return false;
	}

	internal override JsonParameterInfoValues[] GetParameterInfoValues()
	{
		ParameterInfo[] parameters = base.Converter.ConstructorInfo.GetParameters();
		int num = parameters.Length;
		JsonParameterInfoValues[] array = new JsonParameterInfoValues[num];
		for (int i = 0; i < num; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			if (string.IsNullOrEmpty(parameterInfo.Name))
			{
				ThrowHelper.ThrowNotSupportedException_ConstructorContainsNullParameterNames(base.Converter.ConstructorInfo.DeclaringType);
			}
			JsonParameterInfoValues jsonParameterInfoValues = new JsonParameterInfoValues
			{
				Name = parameterInfo.Name,
				ParameterType = parameterInfo.ParameterType,
				Position = parameterInfo.Position,
				HasDefaultValue = parameterInfo.HasDefaultValue,
				DefaultValue = parameterInfo.GetDefaultValue()
			};
			array[i] = jsonParameterInfoValues;
		}
		return array;
	}
}
