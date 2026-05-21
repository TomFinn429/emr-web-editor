using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json.Reflection;

namespace System.Text.Json.Serialization;

internal static class IEnumerableConverterFactoryHelpers
{
	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	[RequiresDynamicCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	public static MethodInfo GetImmutableEnumerableCreateRangeMethod(this Type P_0, Type P_1)
	{
		Type immutableEnumerableConstructingType = GetImmutableEnumerableConstructingType(P_0);
		if (immutableEnumerableConstructingType != null)
		{
			MethodInfo[] methods = immutableEnumerableConstructingType.GetMethods();
			MethodInfo[] array = methods;
			foreach (MethodInfo methodInfo in array)
			{
				if (methodInfo.Name == "CreateRange" && methodInfo.GetParameters().Length == 1 && methodInfo.IsGenericMethod && methodInfo.GetGenericArguments().Length == 1)
				{
					return methodInfo.MakeGenericMethod(P_1);
				}
			}
		}
		ThrowHelper.ThrowNotSupportedException_SerializationNotSupported(P_0);
		return null;
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	[RequiresDynamicCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	public static MethodInfo GetImmutableDictionaryCreateRangeMethod(this Type P_0, Type P_1, Type P_2)
	{
		Type immutableDictionaryConstructingType = GetImmutableDictionaryConstructingType(P_0);
		if (immutableDictionaryConstructingType != null)
		{
			MethodInfo[] methods = immutableDictionaryConstructingType.GetMethods();
			MethodInfo[] array = methods;
			foreach (MethodInfo methodInfo in array)
			{
				if (methodInfo.Name == "CreateRange" && methodInfo.GetParameters().Length == 1 && methodInfo.IsGenericMethod && methodInfo.GetGenericArguments().Length == 2)
				{
					return methodInfo.MakeGenericMethod(P_1, P_2);
				}
			}
		}
		ThrowHelper.ThrowNotSupportedException_SerializationNotSupported(P_0);
		return null;
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	[RequiresDynamicCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	private static Type GetImmutableEnumerableConstructingType(Type P_0)
	{
		string immutableEnumerableConstructingTypeName = P_0.GetImmutableEnumerableConstructingTypeName();
		if (immutableEnumerableConstructingTypeName != null)
		{
			return P_0.Assembly.GetType(immutableEnumerableConstructingTypeName);
		}
		return null;
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	[RequiresDynamicCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	private static Type GetImmutableDictionaryConstructingType(Type P_0)
	{
		string immutableDictionaryConstructingTypeName = P_0.GetImmutableDictionaryConstructingTypeName();
		if (immutableDictionaryConstructingTypeName != null)
		{
			return P_0.Assembly.GetType(immutableDictionaryConstructingTypeName);
		}
		return null;
	}

	public static bool IsNonGenericStackOrQueue(this Type P_0)
	{
		Type typeIfExists = GetTypeIfExists("System.Collections.Stack, System.Collections.NonGeneric");
		if ((object)typeIfExists != null && typeIfExists.IsAssignableFrom(P_0))
		{
			return true;
		}
		Type typeIfExists2 = GetTypeIfExists("System.Collections.Queue, System.Collections.NonGeneric");
		if ((object)typeIfExists2 != null && typeIfExists2.IsAssignableFrom(P_0))
		{
			return true;
		}
		return false;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2057:TypeGetType", Justification = "This method exists to allow for 'weak references' to the Stack and Queue types. If those types are used in the app, they will be preserved by the app and Type.GetType will return them. If those types are not used in the app, we don't want to preserve them here.")]
	private static Type GetTypeIfExists(string P_0)
	{
		return Type.GetType(P_0, false);
	}
}
