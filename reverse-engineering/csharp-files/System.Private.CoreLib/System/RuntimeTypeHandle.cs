using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using Mono;

namespace System;

[Serializable]
public struct RuntimeTypeHandle : IEquatable<RuntimeTypeHandle>, ISerializable
{
	private readonly nint value;

	public nint Value => value;

	internal RuntimeTypeHandle(nint P_0)
	{
		value = P_0;
	}

	internal RuntimeTypeHandle(RuntimeType P_0)
		: this(P_0._impl.value)
	{
	}

	public void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		throw new PlatformNotSupportedException();
	}

	public override bool Equals(object? P_0)
	{
		if (P_0 == null || GetType() != P_0.GetType())
		{
			return false;
		}
		return value == ((RuntimeTypeHandle)P_0).Value;
	}

	public bool Equals(RuntimeTypeHandle P_0)
	{
		return value == P_0.Value;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)value).GetHashCode();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern TypeAttributes GetAttributes(QCallTypeHandle P_0);

	internal static TypeAttributes GetAttributes(RuntimeType P_0)
	{
		return GetAttributes(new QCallTypeHandle(ref P_0));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetMetadataToken(QCallTypeHandle P_0);

	internal static int GetToken(RuntimeType P_0)
	{
		return GetMetadataToken(new QCallTypeHandle(ref P_0));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGenericTypeDefinition_impl(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	internal static Type GetGenericTypeDefinition(RuntimeType P_0)
	{
		Type type = null;
		GetGenericTypeDefinition_impl(new QCallTypeHandle(ref P_0), ObjectHandleOnStack.Create(ref type));
		if (type == null)
		{
			return P_0;
		}
		return type;
	}

	internal static bool IsPrimitive(RuntimeType P_0)
	{
		CorElementType corElementType = GetCorElementType(P_0);
		if (((int)corElementType < 2 || (int)corElementType > 13) && corElementType != CorElementType.ELEMENT_TYPE_I)
		{
			return corElementType == CorElementType.ELEMENT_TYPE_U;
		}
		return true;
	}

	internal static bool IsByRef(RuntimeType P_0)
	{
		CorElementType corElementType = GetCorElementType(P_0);
		return corElementType == CorElementType.ELEMENT_TYPE_BYREF;
	}

	internal static bool IsPointer(RuntimeType P_0)
	{
		CorElementType corElementType = GetCorElementType(P_0);
		return corElementType == CorElementType.ELEMENT_TYPE_PTR;
	}

	internal static bool IsArray(RuntimeType P_0)
	{
		CorElementType corElementType = GetCorElementType(P_0);
		if (corElementType != CorElementType.ELEMENT_TYPE_ARRAY)
		{
			return corElementType == CorElementType.ELEMENT_TYPE_SZARRAY;
		}
		return true;
	}

	internal static bool IsSzArray(RuntimeType P_0)
	{
		CorElementType corElementType = GetCorElementType(P_0);
		return corElementType == CorElementType.ELEMENT_TYPE_SZARRAY;
	}

	internal static bool IsValueType(RuntimeType P_0)
	{
		return P_0.IsValueType;
	}

	internal static bool HasElementType(RuntimeType P_0)
	{
		CorElementType corElementType = GetCorElementType(P_0);
		if (corElementType != CorElementType.ELEMENT_TYPE_ARRAY && corElementType != CorElementType.ELEMENT_TYPE_SZARRAY && corElementType != CorElementType.ELEMENT_TYPE_PTR)
		{
			return corElementType == CorElementType.ELEMENT_TYPE_BYREF;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern CorElementType GetCorElementType(QCallTypeHandle P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool HasInstantiation(QCallTypeHandle P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsComObject(QCallTypeHandle P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsInstanceOfType(QCallTypeHandle P_0, [NotNullWhen(true)] object P_1);

	internal static bool IsInstanceOfType(RuntimeType P_0, [NotNullWhen(true)] object P_1)
	{
		return IsInstanceOfType(new QCallTypeHandle(ref P_0), P_1);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool HasReferences(QCallTypeHandle P_0);

	internal static bool HasReferences(RuntimeType P_0)
	{
		return HasReferences(new QCallTypeHandle(ref P_0));
	}

	internal static CorElementType GetCorElementType(RuntimeType P_0)
	{
		return GetCorElementType(new QCallTypeHandle(ref P_0));
	}

	internal static bool HasInstantiation(RuntimeType P_0)
	{
		return HasInstantiation(new QCallTypeHandle(ref P_0));
	}

	internal static bool IsComObject(RuntimeType P_0, bool P_1)
	{
		if (!P_1)
		{
			return IsComObject(new QCallTypeHandle(ref P_0));
		}
		return false;
	}

	internal static bool IsEquivalentTo(RuntimeType P_0, RuntimeType P_1)
	{
		return false;
	}

	internal static bool IsInterface(RuntimeType P_0)
	{
		return (P_0.Attributes & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern int GetArrayRank(QCallTypeHandle P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void GetAssembly(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void GetElementType(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void GetModule(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void GetBaseType(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	internal static int GetArrayRank(RuntimeType P_0)
	{
		return GetArrayRank(new QCallTypeHandle(ref P_0));
	}

	internal static RuntimeAssembly GetAssembly(RuntimeType P_0)
	{
		RuntimeAssembly result = null;
		GetAssembly(new QCallTypeHandle(ref P_0), ObjectHandleOnStack.Create(ref result));
		return result;
	}

	internal static RuntimeModule GetModule(RuntimeType P_0)
	{
		RuntimeModule result = null;
		GetModule(new QCallTypeHandle(ref P_0), ObjectHandleOnStack.Create(ref result));
		return result;
	}

	internal static RuntimeType GetElementType(RuntimeType P_0)
	{
		RuntimeType result = null;
		GetElementType(new QCallTypeHandle(ref P_0), ObjectHandleOnStack.Create(ref result));
		return result;
	}

	internal static RuntimeType GetBaseType(RuntimeType P_0)
	{
		RuntimeType result = null;
		GetBaseType(new QCallTypeHandle(ref P_0), ObjectHandleOnStack.Create(ref result));
		return result;
	}

	internal static bool CanCastTo(RuntimeType P_0, RuntimeType P_1)
	{
		return type_is_assignable_from(new QCallTypeHandle(ref P_1), new QCallTypeHandle(ref P_0));
	}

	internal static bool IsGenericVariable(RuntimeType P_0)
	{
		CorElementType corElementType = GetCorElementType(P_0);
		if (corElementType != CorElementType.ELEMENT_TYPE_VAR)
		{
			return corElementType == CorElementType.ELEMENT_TYPE_MVAR;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool type_is_assignable_from(QCallTypeHandle P_0, QCallTypeHandle P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsGenericTypeDefinition(QCallTypeHandle P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern nint GetGenericParameterInfo(QCallTypeHandle P_0);

	internal static bool IsGenericTypeDefinition(RuntimeType P_0)
	{
		return IsGenericTypeDefinition(new QCallTypeHandle(ref P_0));
	}

	internal static nint GetGenericParameterInfo(RuntimeType P_0)
	{
		return GetGenericParameterInfo(new QCallTypeHandle(ref P_0));
	}

	internal static bool IsSubclassOf(RuntimeType P_0, RuntimeType P_1)
	{
		return is_subclass_of(new QCallTypeHandle(ref P_0), new QCallTypeHandle(ref P_1));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool is_subclass_of(QCallTypeHandle P_0, QCallTypeHandle P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool IsByRefLike(QCallTypeHandle P_0);

	internal static bool IsByRefLike(RuntimeType P_0)
	{
		return IsByRefLike(new QCallTypeHandle(ref P_0));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void internal_from_name(nint P_0, ref StackCrawlMark P_1, ObjectHandleOnStack P_2, bool P_3, bool P_4);

	[RequiresUnreferencedCode("Types might be removed")]
	internal static RuntimeType GetTypeByName(string P_0, bool P_1, bool P_2, ref StackCrawlMark P_3)
	{
		ArgumentNullException.ThrowIfNull(P_0, "typeName");
		if (P_0.Length == 0)
		{
			if (P_1)
			{
				throw new TypeLoadException("A null or zero length string does not represent a valid Type.");
			}
			return null;
		}
		RuntimeType runtimeType = null;
		using (SafeStringMarshal safeStringMarshal = new SafeStringMarshal(P_0))
		{
			internal_from_name(safeStringMarshal.Value, ref P_3, ObjectHandleOnStack.Create(ref runtimeType), P_1, P_2);
			if (P_1 && runtimeType == null)
			{
				throw new TypeLoadException("Error loading '" + P_0 + "'");
			}
		}
		return runtimeType;
	}
}
