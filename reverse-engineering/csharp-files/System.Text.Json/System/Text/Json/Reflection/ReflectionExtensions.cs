using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace System.Text.Json.Reflection;

internal static class ReflectionExtensions
{
	private static readonly Type s_nullableType = typeof(Nullable<>);

	public static Type GetCompatibleGenericBaseClass(this Type P_0, Type P_1, bool P_2 = false)
	{
		Type type = P_0;
		while (type != null && type != typeof(object))
		{
			if (type.IsGenericType)
			{
				Type genericTypeDefinition = type.GetGenericTypeDefinition();
				if (genericTypeDefinition == P_1 || (P_2 && OpenGenericTypesHaveSamePrefix(P_1, genericTypeDefinition)))
				{
					return type;
				}
			}
			type = type.BaseType;
		}
		return null;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "The 'interfaceType' must exist and so trimmer kept it. In which case It also kept it on any type which implements it. The below call to GetInterfaces may return fewer results when trimmed but it will return the 'interfaceType' if the type implemented it, even after trimming.")]
	public static Type GetCompatibleGenericInterface(this Type P_0, Type P_1)
	{
		if ((object)P_1 == null)
		{
			return null;
		}
		Type type = P_0;
		if (type.IsGenericType)
		{
			type = type.GetGenericTypeDefinition();
		}
		if (type == P_1)
		{
			return P_0;
		}
		Type[] interfaces = P_0.GetInterfaces();
		foreach (Type type2 in interfaces)
		{
			if (type2.IsGenericType)
			{
				Type genericTypeDefinition = type2.GetGenericTypeDefinition();
				if (genericTypeDefinition == P_1)
				{
					return type2;
				}
			}
		}
		return null;
	}

	public static bool IsImmutableDictionaryType(this Type P_0, bool P_1 = false)
	{
		if (!P_0.IsGenericType || !P_0.Assembly.FullName.StartsWith("System.Collections.Immutable", StringComparison.Ordinal))
		{
			return false;
		}
		switch (GetBaseNameFromGenericType(P_0, P_1))
		{
		case "System.Collections.Immutable.ImmutableDictionary`2":
		case "System.Collections.Immutable.IImmutableDictionary`2":
		case "System.Collections.Immutable.ImmutableSortedDictionary`2":
			return true;
		default:
			return false;
		}
	}

	public static bool IsImmutableEnumerableType(this Type P_0, bool P_1 = false)
	{
		if (!P_0.IsGenericType || !P_0.Assembly.FullName.StartsWith("System.Collections.Immutable", StringComparison.Ordinal))
		{
			return false;
		}
		switch (GetBaseNameFromGenericType(P_0, P_1))
		{
		case "System.Collections.Immutable.ImmutableArray`1":
		case "System.Collections.Immutable.ImmutableList`1":
		case "System.Collections.Immutable.IImmutableList`1":
		case "System.Collections.Immutable.ImmutableStack`1":
		case "System.Collections.Immutable.IImmutableStack`1":
		case "System.Collections.Immutable.ImmutableQueue`1":
		case "System.Collections.Immutable.IImmutableQueue`1":
		case "System.Collections.Immutable.ImmutableSortedSet`1":
		case "System.Collections.Immutable.ImmutableHashSet`1":
		case "System.Collections.Immutable.IImmutableSet`1":
			return true;
		default:
			return false;
		}
	}

	public static string GetImmutableDictionaryConstructingTypeName(this Type P_0, bool P_1 = false)
	{
		switch (GetBaseNameFromGenericType(P_0, P_1))
		{
		case "System.Collections.Immutable.ImmutableDictionary`2":
		case "System.Collections.Immutable.IImmutableDictionary`2":
			return "System.Collections.Immutable.ImmutableDictionary";
		case "System.Collections.Immutable.ImmutableSortedDictionary`2":
			return "System.Collections.Immutable.ImmutableSortedDictionary";
		default:
			return null;
		}
	}

	public static string GetImmutableEnumerableConstructingTypeName(this Type P_0, bool P_1 = false)
	{
		switch (GetBaseNameFromGenericType(P_0, P_1))
		{
		case "System.Collections.Immutable.ImmutableArray`1":
			return "System.Collections.Immutable.ImmutableArray";
		case "System.Collections.Immutable.ImmutableList`1":
		case "System.Collections.Immutable.IImmutableList`1":
			return "System.Collections.Immutable.ImmutableList";
		case "System.Collections.Immutable.ImmutableStack`1":
		case "System.Collections.Immutable.IImmutableStack`1":
			return "System.Collections.Immutable.ImmutableStack";
		case "System.Collections.Immutable.ImmutableQueue`1":
		case "System.Collections.Immutable.IImmutableQueue`1":
			return "System.Collections.Immutable.ImmutableQueue";
		case "System.Collections.Immutable.ImmutableSortedSet`1":
			return "System.Collections.Immutable.ImmutableSortedSet";
		case "System.Collections.Immutable.ImmutableHashSet`1":
		case "System.Collections.Immutable.IImmutableSet`1":
			return "System.Collections.Immutable.ImmutableHashSet";
		default:
			return null;
		}
	}

	private static bool OpenGenericTypesHaveSamePrefix(Type P_0, Type P_1)
	{
		return P_0.FullName == GetBaseNameFromGenericTypeDef(P_1);
	}

	private static string GetBaseNameFromGenericType(Type P_0, bool P_1)
	{
		Type genericTypeDefinition = P_0.GetGenericTypeDefinition();
		if (!P_1)
		{
			return genericTypeDefinition.FullName;
		}
		return GetBaseNameFromGenericTypeDef(genericTypeDefinition);
	}

	private static string GetBaseNameFromGenericTypeDef(Type P_0)
	{
		string fullName = P_0.FullName;
		int num = fullName.IndexOf("`") + 2;
		return fullName.Substring(0, num);
	}

	public static bool IsVirtual(this PropertyInfo P_0)
	{
		if (P_0 != null)
		{
			MethodInfo? getMethod = P_0.GetMethod;
			if ((object)getMethod == null || !getMethod.IsVirtual)
			{
				return P_0.SetMethod?.IsVirtual ?? false;
			}
			return true;
		}
		return false;
	}

	public static bool IsKeyValuePair(this Type P_0, Type P_1 = null)
	{
		if (!P_0.IsGenericType)
		{
			return false;
		}
		if ((object)P_1 == null)
		{
			P_1 = typeof(KeyValuePair<, >);
		}
		Type genericTypeDefinition = P_0.GetGenericTypeDefinition();
		return genericTypeDefinition == P_1;
	}

	public static bool TryGetDeserializationConstructor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] this Type P_0, bool P_1, out ConstructorInfo P_2)
	{
		ConstructorInfo constructorInfo = null;
		ConstructorInfo constructorInfo2 = null;
		ConstructorInfo constructorInfo3 = null;
		ConstructorInfo[] constructors = P_0.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
		if (constructors.Length == 1)
		{
			constructorInfo3 = constructors[0];
		}
		ConstructorInfo[] array = constructors;
		foreach (ConstructorInfo constructorInfo4 in array)
		{
			if (HasJsonConstructorAttribute(constructorInfo4))
			{
				if (constructorInfo != null)
				{
					P_2 = null;
					return false;
				}
				constructorInfo = constructorInfo4;
			}
			else if (constructorInfo4.GetParameters().Length == 0)
			{
				constructorInfo2 = constructorInfo4;
			}
		}
		ConstructorInfo constructorInfo5 = constructorInfo;
		constructors = P_0.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
		ConstructorInfo[] array2 = constructors;
		foreach (ConstructorInfo constructorInfo6 in array2)
		{
			if (HasJsonConstructorAttribute(constructorInfo6))
			{
				if (constructorInfo5 != null)
				{
					P_2 = null;
					return false;
				}
				constructorInfo5 = constructorInfo6;
			}
		}
		if (P_1 && P_0.IsValueType && constructorInfo == null)
		{
			P_2 = null;
			return true;
		}
		P_2 = constructorInfo ?? constructorInfo2 ?? constructorInfo3;
		return true;
	}

	public static object GetDefaultValue(this ParameterInfo P_0)
	{
		object defaultValue = P_0.DefaultValue;
		if (defaultValue == DBNull.Value && P_0.ParameterType != typeof(DBNull))
		{
			return null;
		}
		return defaultValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsNullableOfT(this Type P_0)
	{
		if (P_0.IsGenericType)
		{
			return P_0.GetGenericTypeDefinition() == s_nullableType;
		}
		return false;
	}

	public static bool IsAssignableFromInternal(this Type P_0, Type P_1)
	{
		if (P_1.IsNullableOfT() && P_0.IsInterface)
		{
			return P_0.IsAssignableFrom(P_1.GetGenericArguments()[0]);
		}
		return P_0.IsAssignableFrom(P_1);
	}

	public static bool IsInSubtypeRelationshipWith(this Type P_0, Type P_1)
	{
		if (!P_0.IsAssignableFromInternal(P_1))
		{
			return P_1.IsAssignableFromInternal(P_0);
		}
		return true;
	}

	private static bool HasJsonConstructorAttribute(ConstructorInfo P_0)
	{
		return P_0.GetCustomAttribute<JsonConstructorAttribute>() != null;
	}

	public static bool HasRequiredMemberAttribute(this ICustomAttributeProvider P_0)
	{
		return P_0.HasCustomAttributeWithName("System.Runtime.CompilerServices.RequiredMemberAttribute", true);
	}

	public static bool HasSetsRequiredMembersAttribute(this ICustomAttributeProvider P_0)
	{
		return P_0.HasCustomAttributeWithName("System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute", true);
	}

	private static bool HasCustomAttributeWithName(this ICustomAttributeProvider P_0, string P_1, bool P_2)
	{
		object[] customAttributes = P_0.GetCustomAttributes(P_2);
		foreach (object obj in customAttributes)
		{
			if (obj.GetType().FullName == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public static TAttribute GetUniqueCustomAttribute<TAttribute>(this MemberInfo P_0, bool P_1) where TAttribute : Attribute
	{
		object[] customAttributes = P_0.GetCustomAttributes(typeof(TAttribute), P_1);
		if (customAttributes.Length == 0)
		{
			return null;
		}
		if (customAttributes.Length == 1)
		{
			return (TAttribute)customAttributes[0];
		}
		ThrowHelper.ThrowInvalidOperationException_SerializationDuplicateAttribute(typeof(TAttribute), P_0);
		return null;
	}

	public static object CreateInstanceNoWrapExceptions([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicConstructors)] this Type P_0, Type[] P_1, object[] P_2)
	{
		ConstructorInfo constructor = P_0.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, P_1, null);
		return constructor.Invoke(BindingFlags.DoNotWrapExceptions, null, P_2, null);
	}
}
