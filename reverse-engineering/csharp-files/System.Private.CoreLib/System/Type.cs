using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System;

public abstract class Type : MemberInfo
{
	internal RuntimeTypeHandle _impl;

	private static volatile Binder s_defaultBinder;

	public static readonly char Delimiter = '.';

	public static readonly Type[] EmptyTypes = Array.Empty<Type>();

	public static readonly object Missing = System.Reflection.Missing.Value;

	public static readonly MemberFilter FilterAttribute = FilterAttributeImpl;

	public static readonly MemberFilter FilterName = (MemberInfo P_0, object P_1) => FilterNameImpl(P_0, P_1, StringComparison.Ordinal);

	public static readonly MemberFilter FilterNameIgnoreCase = (MemberInfo P_0, object P_1) => FilterNameImpl(P_0, P_1, StringComparison.OrdinalIgnoreCase);

	public bool IsInterface
	{
		get
		{
			if (this is RuntimeType runtimeType)
			{
				return RuntimeTypeHandle.IsInterface(runtimeType);
			}
			return (GetAttributeFlagsImpl() & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask;
		}
	}

	internal virtual bool IsUserType => true;

	public override MemberTypes MemberType => MemberTypes.TypeInfo;

	public abstract string? Namespace { get; }

	public abstract string? AssemblyQualifiedName { get; }

	public abstract string? FullName { get; }

	public abstract Assembly Assembly { get; }

	public new abstract Module Module { get; }

	public bool IsNested => DeclaringType != null;

	public override Type? DeclaringType => null;

	public virtual MethodBase? DeclaringMethod => null;

	public override Type? ReflectedType => null;

	public abstract Type UnderlyingSystemType { get; }

	public bool IsArray => IsArrayImpl();

	public bool IsByRef => IsByRefImpl();

	public bool IsPointer => IsPointerImpl();

	public virtual bool IsConstructedGenericType
	{
		get
		{
			throw NotImplemented.ByDesign;
		}
	}

	public virtual bool IsGenericParameter => false;

	public virtual bool IsGenericMethodParameter
	{
		get
		{
			if (IsGenericParameter)
			{
				return DeclaringMethod != null;
			}
			return false;
		}
	}

	public virtual bool IsGenericType => false;

	public virtual bool IsGenericTypeDefinition => false;

	public virtual bool IsSZArray
	{
		get
		{
			throw NotImplemented.ByDesign;
		}
	}

	public virtual bool IsVariableBoundArray
	{
		get
		{
			if (IsArray)
			{
				return !IsSZArray;
			}
			return false;
		}
	}

	public virtual bool IsByRefLike
	{
		[Intrinsic]
		get
		{
			throw new NotSupportedException("NotSupported_SubclassOverride");
		}
	}

	public bool HasElementType => HasElementTypeImpl();

	public virtual Type[] GenericTypeArguments
	{
		get
		{
			if (!IsGenericType || IsGenericTypeDefinition)
			{
				return EmptyTypes;
			}
			return GetGenericArguments();
		}
	}

	public virtual int GenericParameterPosition
	{
		get
		{
			throw new InvalidOperationException("Arg_NotGenericParameter");
		}
	}

	public virtual GenericParameterAttributes GenericParameterAttributes
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public TypeAttributes Attributes => GetAttributeFlagsImpl();

	public bool IsAbstract => (GetAttributeFlagsImpl() & TypeAttributes.Abstract) != 0;

	public bool IsSealed => (GetAttributeFlagsImpl() & TypeAttributes.Sealed) != 0;

	public bool IsClass
	{
		get
		{
			if ((GetAttributeFlagsImpl() & TypeAttributes.ClassSemanticsMask) == 0)
			{
				return !IsValueType;
			}
			return false;
		}
	}

	public bool IsNestedAssembly => (GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.NestedAssembly;

	public bool IsNestedPrivate => (GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPrivate;

	public bool IsNestedPublic => (GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPublic;

	public bool IsNotPublic => (GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == 0;

	public bool IsPublic => (GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.Public;

	public bool IsExplicitLayout => (GetAttributeFlagsImpl() & TypeAttributes.LayoutMask) == TypeAttributes.ExplicitLayout;

	public bool IsCOMObject => IsCOMObjectImpl();

	public virtual bool IsEnum => IsSubclassOf(typeof(Enum));

	public bool IsPrimitive => IsPrimitiveImpl();

	public bool IsValueType
	{
		[Intrinsic]
		get
		{
			return IsValueTypeImpl();
		}
	}

	public virtual bool IsSignatureType => false;

	public virtual RuntimeTypeHandle TypeHandle
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public abstract Type? BaseType { get; }

	public static Binder DefaultBinder
	{
		get
		{
			if (s_defaultBinder == null)
			{
				DefaultBinder defaultBinder = new DefaultBinder();
				Interlocked.CompareExchange(ref s_defaultBinder, defaultBinder, null);
			}
			return s_defaultBinder;
		}
	}

	public virtual bool ContainsGenericParameters
	{
		get
		{
			if (HasElementType)
			{
				return GetRootElementType().ContainsGenericParameters;
			}
			if (IsGenericParameter)
			{
				return true;
			}
			if (!IsGenericType)
			{
				return false;
			}
			Type[] genericArguments = GetGenericArguments();
			for (int i = 0; i < genericArguments.Length; i++)
			{
				if (genericArguments[i].ContainsGenericParameters)
				{
					return true;
				}
			}
			return false;
		}
	}

	internal nint GetUnderlyingNativeHandle()
	{
		return _impl.Value;
	}

	internal virtual bool IsTypeBuilder()
	{
		return false;
	}

	[RequiresUnreferencedCode("The type might be removed")]
	public static Type? GetType(string P_0, bool P_1, bool P_2)
	{
		StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
		return RuntimeType.GetType(P_0, P_1, P_2, ref stackCrawlMark);
	}

	[RequiresUnreferencedCode("The type might be removed")]
	public static Type? GetType(string P_0, bool P_1)
	{
		StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
		return RuntimeType.GetType(P_0, P_1, false, ref stackCrawlMark);
	}

	[RequiresUnreferencedCode("The type might be removed")]
	public static Type? GetType(string P_0)
	{
		StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
		return RuntimeType.GetType(P_0, false, false, ref stackCrawlMark);
	}

	public static Type? GetTypeFromHandle(RuntimeTypeHandle P_0)
	{
		if (P_0.Value == IntPtr.Zero)
		{
			return null;
		}
		return internal_from_handle(P_0.Value);
	}

	internal virtual Type InternalResolve()
	{
		return UnderlyingSystemType;
	}

	internal virtual Type RuntimeResolve()
	{
		throw new NotImplementedException();
	}

	internal virtual MethodInfo GetMethod(MethodInfo P_0)
	{
		throw new InvalidOperationException("can only be called in generic type");
	}

	internal virtual ConstructorInfo GetConstructor(ConstructorInfo P_0)
	{
		throw new InvalidOperationException("can only be called in generic type");
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern Type internal_from_handle(nint P_0);

	public new Type GetType()
	{
		return base.GetType();
	}

	protected abstract bool IsArrayImpl();

	protected abstract bool IsByRefImpl();

	protected abstract bool IsPointerImpl();

	protected abstract bool HasElementTypeImpl();

	public abstract Type? GetElementType();

	public virtual int GetArrayRank()
	{
		throw new NotSupportedException("NotSupported_SubclassOverride");
	}

	public virtual Type GetGenericTypeDefinition()
	{
		throw new NotSupportedException("NotSupported_SubclassOverride");
	}

	public virtual Type[] GetGenericArguments()
	{
		throw new NotSupportedException("NotSupported_SubclassOverride");
	}

	public virtual Type[] GetGenericParameterConstraints()
	{
		if (!IsGenericParameter)
		{
			throw new InvalidOperationException("Arg_NotGenericParameter");
		}
		throw new InvalidOperationException();
	}

	protected abstract TypeAttributes GetAttributeFlagsImpl();

	protected abstract bool IsCOMObjectImpl();

	protected abstract bool IsPrimitiveImpl();

	protected virtual bool IsValueTypeImpl()
	{
		return IsSubclassOf(typeof(ValueType));
	}

	[Intrinsic]
	public bool IsAssignableTo([NotNullWhen(true)] Type? P_0)
	{
		return P_0?.IsAssignableFrom(this) ?? false;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	public ConstructorInfo? GetConstructor(Type[] P_0)
	{
		return GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, P_0, null);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	public ConstructorInfo? GetConstructor(BindingFlags P_0, Binder? P_1, Type[] P_2, ParameterModifier[]? P_3)
	{
		return GetConstructor(P_0, P_1, CallingConventions.Any, P_2, P_3);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	public ConstructorInfo? GetConstructor(BindingFlags P_0, Binder? P_1, CallingConventions P_2, Type[] P_3, ParameterModifier[]? P_4)
	{
		ArgumentNullException.ThrowIfNull(P_3, "types");
		for (int i = 0; i < P_3.Length; i++)
		{
			ArgumentNullException.ThrowIfNull(P_3[i], "types");
		}
		return GetConstructorImpl(P_0, P_1, P_2, P_3, P_4);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	protected abstract ConstructorInfo? GetConstructorImpl(BindingFlags P_0, Binder? P_1, CallingConventions P_2, Type[] P_3, ParameterModifier[]? P_4);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	public abstract ConstructorInfo[] GetConstructors(BindingFlags P_0);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public abstract EventInfo? GetEvent(string P_0, BindingFlags P_1);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)]
	public FieldInfo? GetField(string P_0)
	{
		return GetField(P_0, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public abstract FieldInfo? GetField(string P_0, BindingFlags P_1);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public abstract FieldInfo[] GetFields(BindingFlags P_0);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicEvents)]
	public MemberInfo[] GetMember(string P_0)
	{
		return GetMember(P_0, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public virtual MemberInfo[] GetMember(string P_0, BindingFlags P_1)
	{
		return GetMember(P_0, MemberTypes.All, P_1);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public virtual MemberInfo[] GetMember(string P_0, MemberTypes P_1, BindingFlags P_2)
	{
		throw new NotSupportedException("NotSupported_SubclassOverride");
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2085:UnrecognizedReflectionPattern", Justification = "This is finding the MemberInfo with the same MetadataToken as specified MemberInfo. If the specified MemberInfo exists and wasn't trimmed, then the current Type's MemberInfo couldn't have been trimmed.")]
	public virtual MemberInfo GetMemberWithSameMetadataDefinitionAs(MemberInfo P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "member");
		MemberInfo[] members = GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (MemberInfo memberInfo in members)
		{
			if (memberInfo.HasSameMetadataDefinitionAs(P_0))
			{
				return memberInfo;
			}
		}
		throw CreateGetMemberWithSameMetadataDefinitionAsNotFoundException(P_0);
	}

	private protected static ArgumentException CreateGetMemberWithSameMetadataDefinitionAsNotFoundException(MemberInfo P_0)
	{
		return new ArgumentException(SR.Format("Arg_MemberInfoNotFound", P_0.Name), "member");
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public abstract MemberInfo[] GetMembers(BindingFlags P_0);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
	public MethodInfo? GetMethod(string P_0)
	{
		return GetMethod(P_0, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	public MethodInfo? GetMethod(string P_0, BindingFlags P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		return GetMethodImpl(P_0, P_1, null, CallingConventions.Any, null, null);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
	public MethodInfo? GetMethod(string P_0, Type[] P_1)
	{
		return GetMethod(P_0, P_1, null);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
	public MethodInfo? GetMethod(string P_0, Type[] P_1, ParameterModifier[]? P_2)
	{
		return GetMethod(P_0, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, P_1, P_2);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	public MethodInfo? GetMethod(string P_0, BindingFlags P_1, Binder? P_2, Type[] P_3, ParameterModifier[]? P_4)
	{
		return GetMethod(P_0, P_1, P_2, CallingConventions.Any, P_3, P_4);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	public MethodInfo? GetMethod(string P_0, BindingFlags P_1, Binder? P_2, CallingConventions P_3, Type[] P_4, ParameterModifier[]? P_5)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		ArgumentNullException.ThrowIfNull(P_4, "types");
		for (int i = 0; i < P_4.Length; i++)
		{
			ArgumentNullException.ThrowIfNull(P_4[i], "types");
		}
		return GetMethodImpl(P_0, P_1, P_2, P_3, P_4, P_5);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	protected abstract MethodInfo? GetMethodImpl(string P_0, BindingFlags P_1, Binder? P_2, CallingConventions P_3, Type[]? P_4, ParameterModifier[]? P_5);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	protected virtual MethodInfo? GetMethodImpl(string P_0, int P_1, BindingFlags P_2, Binder? P_3, CallingConventions P_4, Type[]? P_5, ParameterModifier[]? P_6)
	{
		throw new NotSupportedException();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
	public MethodInfo[] GetMethods()
	{
		return GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	public abstract MethodInfo[] GetMethods(BindingFlags P_0);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public PropertyInfo? GetProperty(string P_0, BindingFlags P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		return GetPropertyImpl(P_0, P_1, null, null, null, null);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2085:UnrecognizedReflectionPattern", Justification = "Linker doesn't recognize GetPropertyImpl(BindingFlags.Public) but this is what the body is doing")]
	public PropertyInfo? GetProperty(string P_0, Type? P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		return GetPropertyImpl(P_0, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, P_1, null, null);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)]
	public PropertyInfo? GetProperty(string P_0, Type? P_1, Type[] P_2)
	{
		return GetProperty(P_0, P_1, P_2, null);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)]
	public PropertyInfo? GetProperty(string P_0, Type? P_1, Type[] P_2, ParameterModifier[]? P_3)
	{
		return GetProperty(P_0, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, P_1, P_2, P_3);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public PropertyInfo? GetProperty(string P_0, BindingFlags P_1, Binder? P_2, Type? P_3, Type[] P_4, ParameterModifier[]? P_5)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		ArgumentNullException.ThrowIfNull(P_4, "types");
		return GetPropertyImpl(P_0, P_1, P_2, P_3, P_4, P_5);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	protected abstract PropertyInfo? GetPropertyImpl(string P_0, BindingFlags P_1, Binder? P_2, Type? P_3, Type[]? P_4, ParameterModifier[]? P_5);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public abstract PropertyInfo[] GetProperties(BindingFlags P_0);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicEvents)]
	public virtual MemberInfo[] GetDefaultMembers()
	{
		throw NotImplemented.ByDesign;
	}

	public static RuntimeTypeHandle GetTypeHandle(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "o");
		return P_0.GetType().TypeHandle;
	}

	public static TypeCode GetTypeCode(Type? P_0)
	{
		return P_0?.GetTypeCodeImpl() ?? TypeCode.Empty;
	}

	protected virtual TypeCode GetTypeCodeImpl()
	{
		Type underlyingSystemType = UnderlyingSystemType;
		if ((object)this != underlyingSystemType && (object)underlyingSystemType != null)
		{
			return GetTypeCode(underlyingSystemType);
		}
		return TypeCode.Object;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	public abstract Type[] GetInterfaces();

	public virtual bool IsInstanceOfType([NotNullWhen(true)] object? P_0)
	{
		if (P_0 != null)
		{
			return IsAssignableFrom(P_0.GetType());
		}
		return false;
	}

	public virtual bool IsEquivalentTo([NotNullWhen(true)] Type? P_0)
	{
		return this == P_0;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2085:UnrecognizedReflectionPattern", Justification = "The single instance field on enum types is never trimmed")]
	public virtual Type GetEnumUnderlyingType()
	{
		if (!IsEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "enumType");
		}
		FieldInfo[] fields = GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (fields == null || fields.Length != 1)
		{
			throw new ArgumentException("Argument_InvalidEnum", "enumType");
		}
		return fields[0].FieldType;
	}

	[RequiresDynamicCode("It might not be possible to create an array of the enum type at runtime. Use the GetEnumValues<TEnum> overload or the GetEnumValuesAsUnderlyingType method instead.")]
	public virtual Array GetEnumValues()
	{
		if (!IsEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "enumType");
		}
		throw NotImplemented.ByDesign;
	}

	public virtual Array GetEnumValuesAsUnderlyingType()
	{
		throw new NotSupportedException("NotSupported_SubclassOverride");
	}

	[RequiresDynamicCode("The code for an array of the specified type might not be available.")]
	public virtual Type MakeArrayType()
	{
		throw new NotSupportedException();
	}

	[RequiresDynamicCode("The code for an array of the specified type might not be available.")]
	public virtual Type MakeArrayType(int P_0)
	{
		throw new NotSupportedException();
	}

	public virtual Type MakeByRefType()
	{
		throw new NotSupportedException();
	}

	[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public virtual Type MakeGenericType(params Type[] P_0)
	{
		throw new NotSupportedException("NotSupported_SubclassOverride");
	}

	public virtual Type MakePointerType()
	{
		throw new NotSupportedException();
	}

	public static Type MakeGenericSignatureType(Type P_0, params Type[] P_1)
	{
		return new SignatureConstructedGenericType(P_0, P_1);
	}

	internal string FormatTypeName()
	{
		Type rootElementType = GetRootElementType();
		if (rootElementType.IsPrimitive || rootElementType.IsNested || rootElementType == typeof(void) || rootElementType == typeof(TypedReference))
		{
			return Name;
		}
		return ToString();
	}

	public override string ToString()
	{
		return "Type: " + Name;
	}

	public override bool Equals(object? P_0)
	{
		if (P_0 != null)
		{
			return Equals(P_0 as Type);
		}
		return false;
	}

	public override int GetHashCode()
	{
		Type underlyingSystemType = UnderlyingSystemType;
		if ((object)underlyingSystemType != this)
		{
			return underlyingSystemType.GetHashCode();
		}
		return base.GetHashCode();
	}

	public virtual bool Equals(Type? P_0)
	{
		if (!(P_0 == null))
		{
			return (object)UnderlyingSystemType == P_0.UnderlyingSystemType;
		}
		return false;
	}

	[Intrinsic]
	public static bool operator ==(Type? P_0, Type? P_1)
	{
		if ((object)P_0 == P_1)
		{
			return true;
		}
		if ((object)P_0 == null || (object)P_1 == null || P_0 is RuntimeType || P_1 is RuntimeType)
		{
			return false;
		}
		return P_0.Equals(P_1);
	}

	[Intrinsic]
	public static bool operator !=(Type? P_0, Type? P_1)
	{
		return !(P_0 == P_1);
	}

	public virtual bool IsEnumDefined(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if (!IsEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "value");
		}
		Type type = P_0.GetType();
		if (type.IsEnum)
		{
			if (!type.IsEquivalentTo(this))
			{
				throw new ArgumentException(SR.Format("Arg_EnumAndObjectMustBeSameType", type, this));
			}
			type = type.GetEnumUnderlyingType();
		}
		if (type == typeof(string))
		{
			string[] enumNames = GetEnumNames();
			object[] array = enumNames;
			if (Array.IndexOf(array, P_0) >= 0)
			{
				return true;
			}
			return false;
		}
		if (IsIntegerType(type))
		{
			Type enumUnderlyingType = GetEnumUnderlyingType();
			if (enumUnderlyingType.GetTypeCodeImpl() != type.GetTypeCodeImpl())
			{
				throw new ArgumentException(SR.Format("Arg_EnumUnderlyingTypeAndObjectMustBeSameType", type, enumUnderlyingType));
			}
			Array enumRawConstantValues = GetEnumRawConstantValues();
			return BinarySearch(enumRawConstantValues, P_0) >= 0;
		}
		throw new InvalidOperationException("InvalidOperation_UnknownEnumType");
	}

	public virtual string? GetEnumName(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if (!IsEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "value");
		}
		Type type = P_0.GetType();
		if (!type.IsEnum && !IsIntegerType(type))
		{
			throw new ArgumentException("Arg_MustBeEnumBaseTypeOrEnum", "value");
		}
		Array enumRawConstantValues = GetEnumRawConstantValues();
		int num = BinarySearch(enumRawConstantValues, P_0);
		if (num >= 0)
		{
			string[] enumNames = GetEnumNames();
			return enumNames[num];
		}
		return null;
	}

	public virtual string[] GetEnumNames()
	{
		if (!IsEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "enumType");
		}
		GetEnumData(out var result, out var _);
		return result;
	}

	private Array GetEnumRawConstantValues()
	{
		GetEnumData(out var _, out var result);
		return result;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2085:UnrecognizedReflectionPattern", Justification = "Literal fields on enums can never be trimmed")]
	private void GetEnumData(out string[] P_0, out Array P_1)
	{
		FieldInfo[] fields = GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		object[] array = new object[fields.Length];
		string[] array2 = new string[fields.Length];
		for (int i = 0; i < fields.Length; i++)
		{
			array2[i] = fields[i].Name;
			array[i] = fields[i].GetRawConstantValue();
		}
		Comparer comparer = Comparer.Default;
		for (int j = 1; j < array.Length; j++)
		{
			int num = j;
			string text = array2[j];
			object obj = array[j];
			bool flag = false;
			while (comparer.Compare(array[num - 1], obj) > 0)
			{
				array2[num] = array2[num - 1];
				array[num] = array[num - 1];
				num--;
				flag = true;
				if (num == 0)
				{
					break;
				}
			}
			if (flag)
			{
				array2[num] = text;
				array[num] = obj;
			}
		}
		P_0 = array2;
		P_1 = array;
	}

	private static int BinarySearch(Array P_0, object P_1)
	{
		ulong[] array = new ulong[P_0.Length];
		for (int i = 0; i < P_0.Length; i++)
		{
			array[i] = Enum.ToUInt64(P_0.GetValue(i));
		}
		ulong num = Enum.ToUInt64(P_1);
		return Array.BinarySearch(array, num);
	}

	internal static bool IsIntegerType(Type P_0)
	{
		if (!(P_0 == typeof(int)) && !(P_0 == typeof(short)) && !(P_0 == typeof(ushort)) && !(P_0 == typeof(byte)) && !(P_0 == typeof(sbyte)) && !(P_0 == typeof(uint)) && !(P_0 == typeof(long)) && !(P_0 == typeof(ulong)) && !(P_0 == typeof(char)))
		{
			return P_0 == typeof(bool);
		}
		return true;
	}

	internal Type GetRootElementType()
	{
		Type type = this;
		while (type.HasElementType)
		{
			type = type.GetElementType();
		}
		return type;
	}

	public virtual bool IsSubclassOf(Type P_0)
	{
		Type type = this;
		if (type == P_0)
		{
			return false;
		}
		while (type != null)
		{
			if (type == P_0)
			{
				return true;
			}
			type = type.BaseType;
		}
		return false;
	}

	[Intrinsic]
	public virtual bool IsAssignableFrom([NotNullWhen(true)] Type? P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (this == P_0)
		{
			return true;
		}
		Type underlyingSystemType = UnderlyingSystemType;
		if (underlyingSystemType is RuntimeType)
		{
			return underlyingSystemType.IsAssignableFrom(P_0);
		}
		if (P_0.IsSubclassOf(this))
		{
			return true;
		}
		if (IsInterface)
		{
			return P_0.ImplementInterface(this);
		}
		if (IsGenericParameter)
		{
			Type[] genericParameterConstraints = GetGenericParameterConstraints();
			for (int i = 0; i < genericParameterConstraints.Length; i++)
			{
				if (!genericParameterConstraints[i].IsAssignableFrom(P_0))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2085:UnrecognizedReflectionPattern", Justification = "The GetInterfaces technically requires all interfaces to be preservedBut this method only compares the result against the passed in ifaceType.So if ifaceType exists, then trimming should have kept it implemented on any type.")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075:UnrecognizedReflectionPattern", Justification = "The GetInterfaces technically requires all interfaces to be preservedBut this method only compares the result against the passed in ifaceType.So if ifaceType exists, then trimming should have kept it implemented on any type.")]
	internal bool ImplementInterface(Type P_0)
	{
		Type type = this;
		while (type != null)
		{
			Type[] interfaces = type.GetInterfaces();
			if (interfaces != null)
			{
				for (int i = 0; i < interfaces.Length; i++)
				{
					if (interfaces[i] == P_0 || (interfaces[i] != null && interfaces[i].ImplementInterface(P_0)))
					{
						return true;
					}
				}
			}
			type = type.BaseType;
		}
		return false;
	}

	private static bool FilterAttributeImpl(MemberInfo P_0, object P_1)
	{
		if (P_1 == null)
		{
			throw new InvalidFilterCriteriaException("InvalidFilterCriteriaException_CritInt");
		}
		switch (P_0.MemberType)
		{
		case MemberTypes.Constructor:
		case MemberTypes.Method:
		{
			MethodAttributes methodAttributes;
			try
			{
				int num2 = (int)P_1;
				methodAttributes = (MethodAttributes)num2;
			}
			catch
			{
				throw new InvalidFilterCriteriaException("InvalidFilterCriteriaException_CritInt");
			}
			MethodAttributes methodAttributes2 = ((P_0.MemberType != MemberTypes.Method) ? ((ConstructorInfo)P_0).Attributes : ((MethodInfo)P_0).Attributes);
			if ((methodAttributes & MethodAttributes.MemberAccessMask) != MethodAttributes.PrivateScope && (methodAttributes2 & MethodAttributes.MemberAccessMask) != (methodAttributes & MethodAttributes.MemberAccessMask))
			{
				return false;
			}
			if ((methodAttributes & MethodAttributes.Static) != MethodAttributes.PrivateScope && (methodAttributes2 & MethodAttributes.Static) == 0)
			{
				return false;
			}
			if ((methodAttributes & MethodAttributes.Final) != MethodAttributes.PrivateScope && (methodAttributes2 & MethodAttributes.Final) == 0)
			{
				return false;
			}
			if ((methodAttributes & MethodAttributes.Virtual) != MethodAttributes.PrivateScope && (methodAttributes2 & MethodAttributes.Virtual) == 0)
			{
				return false;
			}
			if ((methodAttributes & MethodAttributes.Abstract) != MethodAttributes.PrivateScope && (methodAttributes2 & MethodAttributes.Abstract) == 0)
			{
				return false;
			}
			if ((methodAttributes & MethodAttributes.SpecialName) != MethodAttributes.PrivateScope && (methodAttributes2 & MethodAttributes.SpecialName) == 0)
			{
				return false;
			}
			return true;
		}
		case MemberTypes.Field:
		{
			FieldAttributes fieldAttributes;
			try
			{
				int num = (int)P_1;
				fieldAttributes = (FieldAttributes)num;
			}
			catch
			{
				throw new InvalidFilterCriteriaException("InvalidFilterCriteriaException_CritInt");
			}
			FieldAttributes attributes = ((FieldInfo)P_0).Attributes;
			if ((fieldAttributes & FieldAttributes.FieldAccessMask) != FieldAttributes.PrivateScope && (attributes & FieldAttributes.FieldAccessMask) != (fieldAttributes & FieldAttributes.FieldAccessMask))
			{
				return false;
			}
			if ((fieldAttributes & FieldAttributes.Static) != FieldAttributes.PrivateScope && (attributes & FieldAttributes.Static) == 0)
			{
				return false;
			}
			if ((fieldAttributes & FieldAttributes.InitOnly) != FieldAttributes.PrivateScope && (attributes & FieldAttributes.InitOnly) == 0)
			{
				return false;
			}
			if ((fieldAttributes & FieldAttributes.Literal) != FieldAttributes.PrivateScope && (attributes & FieldAttributes.Literal) == 0)
			{
				return false;
			}
			if ((fieldAttributes & FieldAttributes.NotSerialized) != FieldAttributes.PrivateScope && (attributes & FieldAttributes.NotSerialized) == 0)
			{
				return false;
			}
			if ((fieldAttributes & FieldAttributes.PinvokeImpl) != FieldAttributes.PrivateScope && (attributes & FieldAttributes.PinvokeImpl) == 0)
			{
				return false;
			}
			return true;
		}
		default:
			return false;
		}
	}

	private static bool FilterNameImpl(MemberInfo P_0, object P_1, StringComparison P_2)
	{
		if (!(P_1 is string text))
		{
			throw new InvalidFilterCriteriaException("InvalidFilterCriteriaException_CritString");
		}
		ReadOnlySpan<char> readOnlySpan = text.AsSpan().Trim();
		ReadOnlySpan<char> readOnlySpan2 = P_0.Name;
		if (P_0.MemberType == MemberTypes.NestedType)
		{
			readOnlySpan2 = readOnlySpan2.Slice(readOnlySpan2.LastIndexOf('+') + 1);
		}
		if (readOnlySpan.Length > 0 && readOnlySpan[readOnlySpan.Length - 1] == '*')
		{
			readOnlySpan = readOnlySpan.Slice(0, readOnlySpan.Length - 1);
			return readOnlySpan2.StartsWith(readOnlySpan, P_2);
		}
		return MemoryExtensions.Equals(readOnlySpan2, readOnlySpan, P_2);
	}
}
