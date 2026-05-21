using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace System;

public static class Activator
{
	public static object? CreateInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type P_0, BindingFlags P_1, Binder? P_2, object?[]? P_3, CultureInfo? P_4)
	{
		return CreateInstance(P_0, P_1, P_2, P_3, P_4, null);
	}

	public static object? CreateInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type P_0, params object?[]? P_1)
	{
		return CreateInstance(P_0, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, null, P_1, null, null);
	}

	public static object? CreateInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type P_0)
	{
		return CreateInstance(P_0, false);
	}

	public static object? CreateInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type P_0, BindingFlags P_1, Binder? P_2, object?[]? P_3, CultureInfo? P_4, object?[]? P_5)
	{
		ArgumentNullException.ThrowIfNull(P_0, "type");
		if (P_0 is TypeBuilder)
		{
			throw new NotSupportedException("NotSupported_CreateInstanceWithTypeBuilder");
		}
		if ((P_1 & (BindingFlags)255) == 0)
		{
			P_1 |= BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance;
		}
		if (P_5 != null && P_5.Length != 0)
		{
			throw new PlatformNotSupportedException("NotSupported_ActivAttr");
		}
		if (!(P_0.UnderlyingSystemType is RuntimeType runtimeType))
		{
			throw new ArgumentException("Arg_MustBeType", "type");
		}
		return runtimeType.CreateInstanceImpl(P_1, P_2, P_3, P_4);
	}

	public static object? CreateInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] Type P_0, bool P_1)
	{
		return CreateInstance(P_0, P_1, true);
	}

	internal static object CreateInstance(Type P_0, bool P_1, bool P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "type");
		if (!(P_0.UnderlyingSystemType is RuntimeType runtimeType))
		{
			throw new ArgumentException("Arg_MustBeType", "type");
		}
		return runtimeType.CreateInstanceDefaultCtor(!P_1, P_2);
	}

	[Intrinsic]
	public static T CreateInstance<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] T>()
	{
		return (T)((RuntimeType)typeof(T)).CreateInstanceOfT();
	}
}
