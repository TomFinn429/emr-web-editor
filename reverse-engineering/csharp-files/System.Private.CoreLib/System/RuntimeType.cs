using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading;
using Mono;

namespace System;

internal sealed class RuntimeType : TypeInfo, ICloneable
{
	internal enum MemberListType
	{
		All,
		CaseSensitive,
		CaseInsensitive,
		HandleToInfo
	}

	private struct ListBuilder<T> where T : class
	{
		private T[] _items;

		private T _item;

		private int _count;

		private int _capacity;

		public T this[int P_0]
		{
			get
			{
				if (_items == null)
				{
					return _item;
				}
				return _items[P_0];
			}
		}

		public int Count => _count;

		public ListBuilder(int P_0)
		{
			_items = null;
			_item = null;
			_count = 0;
			_capacity = P_0;
		}

		public T[] ToArray()
		{
			if (_count == 0)
			{
				return Array.Empty<T>();
			}
			if (_count == 1)
			{
				return new T[1] { _item };
			}
			Array.Resize(ref _items, _count);
			_capacity = _count;
			return _items;
		}

		public void CopyTo(object[] P_0, int P_1)
		{
			if (_count != 0)
			{
				if (_count == 1)
				{
					P_0[P_1] = _item;
				}
				else
				{
					Array.Copy(_items, 0, P_0, P_1, _count);
				}
			}
		}

		public void Add(T P_0)
		{
			if (_count == 0)
			{
				_item = P_0;
			}
			else
			{
				if (_count == 1)
				{
					if (_capacity < 2)
					{
						_capacity = 4;
					}
					_items = new T[_capacity];
					_items[0] = _item;
				}
				else if (_capacity == _count)
				{
					int num = 2 * _capacity;
					Array.Resize(ref _items, num);
					_capacity = num;
				}
				_items[_count] = P_0;
			}
			_count++;
		}
	}

	internal sealed class TypeCache
	{
		public Enum.EnumInfo EnumInfo;

		public TypeCode TypeCode;

		public string full_name;

		public bool default_ctor_cached;

		public RuntimeConstructorInfo default_ctor;
	}

	private enum CheckValueStatus
	{
		Success,
		ArgumentException,
		NotSupported_ByRefLike
	}

	internal static readonly RuntimeType ValueType = (RuntimeType)typeof(ValueType);

	internal static readonly RuntimeType EnumType = (RuntimeType)typeof(Enum);

	private static readonly RuntimeType ObjectType = (RuntimeType)typeof(object);

	private static readonly RuntimeType StringType = (RuntimeType)typeof(string);

	private TypeCache cache;

	public override bool IsEnum => GetBaseType() == EnumType;

	internal bool IsActualEnum => RuntimeTypeHandle.GetBaseType(this) == EnumType;

	public override GenericParameterAttributes GenericParameterAttributes
	{
		get
		{
			if (!IsGenericParameter)
			{
				throw new InvalidOperationException("Arg_NotGenericParameter");
			}
			return GetGenericParameterAttributes();
		}
	}

	public override int GenericParameterPosition
	{
		get
		{
			if (!IsGenericParameter)
			{
				throw new InvalidOperationException("Arg_NotGenericParameter");
			}
			RuntimeType runtimeType = this;
			return GetGenericParameterPosition(new QCallTypeHandle(ref runtimeType));
		}
	}

	internal TypeCache Cache => Volatile.Read(ref cache) ?? Interlocked.CompareExchange(ref cache, new TypeCache(), null) ?? cache;

	public override bool ContainsGenericParameters
	{
		get
		{
			if (IsGenericParameter)
			{
				return true;
			}
			if (IsGenericType)
			{
				Type[] genericArguments = GetGenericArguments();
				foreach (Type type in genericArguments)
				{
					if (type.ContainsGenericParameters)
					{
						return true;
					}
				}
			}
			if (base.HasElementType)
			{
				return GetElementType().ContainsGenericParameters;
			}
			return false;
		}
	}

	public override MethodBase DeclaringMethod
	{
		get
		{
			RuntimeType runtimeType = this;
			MethodBase result = null;
			GetDeclaringMethod(new QCallTypeHandle(ref runtimeType), ObjectHandleOnStack.Create(ref result));
			return result;
		}
	}

	public override string AssemblyQualifiedName => getFullName(true, true);

	public override Type DeclaringType
	{
		get
		{
			RuntimeType runtimeType = this;
			Type result = null;
			GetDeclaringType(new QCallTypeHandle(ref runtimeType), ObjectHandleOnStack.Create(ref result));
			return result;
		}
	}

	public override string Name
	{
		get
		{
			RuntimeType runtimeType = this;
			string result = null;
			GetName(new QCallTypeHandle(ref runtimeType), ObjectHandleOnStack.Create(ref result));
			return result;
		}
	}

	public override string Namespace
	{
		get
		{
			RuntimeType runtimeType = this;
			string result = null;
			GetNamespace(new QCallTypeHandle(ref runtimeType), ObjectHandleOnStack.Create(ref result));
			return result;
		}
	}

	public override string FullName
	{
		get
		{
			if (ContainsGenericParameters && !GetRootElementType().IsGenericTypeDefinition)
			{
				return null;
			}
			TypeCache typeCache = Cache;
			string result;
			if ((result = typeCache.full_name) == null)
			{
				result = (typeCache.full_name = getFullName(true, false));
			}
			return result;
		}
	}

	internal bool IsNullableOfT => Nullable.GetUnderlyingType(this) != null;

	public override bool IsSZArray => RuntimeTypeHandle.IsSzArray(this);

	internal override bool IsUserType => false;

	public override Assembly Assembly => RuntimeTypeHandle.GetAssembly(this);

	public override Type BaseType => GetBaseType();

	public override bool IsByRefLike => RuntimeTypeHandle.IsByRefLike(this);

	public override bool IsConstructedGenericType
	{
		get
		{
			if (IsGenericType)
			{
				return !IsGenericTypeDefinition;
			}
			return false;
		}
	}

	public override bool IsGenericType => RuntimeTypeHandle.HasInstantiation(this);

	public override bool IsGenericTypeDefinition => RuntimeTypeHandle.IsGenericTypeDefinition(this);

	public override bool IsGenericParameter => RuntimeTypeHandle.IsGenericVariable(this);

	public override MemberTypes MemberType
	{
		get
		{
			if (!base.IsPublic && !base.IsNotPublic)
			{
				return MemberTypes.NestedType;
			}
			return MemberTypes.TypeInfo;
		}
	}

	public override int MetadataToken => RuntimeTypeHandle.GetToken(this);

	public override Module Module => GetRuntimeModule();

	public override Type ReflectedType => DeclaringType;

	public override RuntimeTypeHandle TypeHandle => new RuntimeTypeHandle(this);

	public override Type UnderlyingSystemType => this;

	[RequiresUnreferencedCode("Types might be removed")]
	internal static RuntimeType GetType(string P_0, bool P_1, bool P_2, ref StackCrawlMark P_3)
	{
		ArgumentNullException.ThrowIfNull(P_0, "typeName");
		return RuntimeTypeHandle.GetTypeByName(P_0, P_1, P_2, ref P_3);
	}

	private static void SplitName(string P_0, out string P_1, out string P_2)
	{
		P_1 = null;
		P_2 = null;
		if (P_0 == null)
		{
			return;
		}
		int num = P_0.LastIndexOf(".", StringComparison.Ordinal);
		if (num != -1)
		{
			P_2 = P_0.Substring(0, num);
			int num2 = P_0.Length - P_2.Length - 1;
			if (num2 != 0)
			{
				P_1 = P_0.Substring(num + 1, num2);
			}
			else
			{
				P_1 = "";
			}
		}
		else
		{
			P_1 = P_0;
		}
	}

	internal static BindingFlags FilterPreCalculate(bool P_0, bool P_1, bool P_2)
	{
		BindingFlags bindingFlags = (P_0 ? BindingFlags.Public : BindingFlags.NonPublic);
		if (P_1)
		{
			bindingFlags |= BindingFlags.DeclaredOnly;
			if (P_2)
			{
				return bindingFlags | (BindingFlags.Static | BindingFlags.FlattenHierarchy);
			}
			return bindingFlags | BindingFlags.Instance;
		}
		if (P_2)
		{
			return bindingFlags | BindingFlags.Static;
		}
		return bindingFlags | BindingFlags.Instance;
	}

	private static void FilterHelper(BindingFlags P_0, ref string P_1, bool P_2, out bool P_3, out bool P_4, out MemberListType P_5)
	{
		P_3 = false;
		P_4 = false;
		if (P_1 != null)
		{
			if ((P_0 & BindingFlags.IgnoreCase) != BindingFlags.Default)
			{
				P_1 = P_1.ToLowerInvariant();
				P_4 = true;
				P_5 = MemberListType.CaseInsensitive;
			}
			else
			{
				P_5 = MemberListType.CaseSensitive;
			}
			if (P_2 && P_1.EndsWith("*", StringComparison.Ordinal))
			{
				P_1 = P_1.Substring(0, P_1.Length - 1);
				P_3 = true;
				P_5 = MemberListType.All;
			}
		}
		else
		{
			P_5 = MemberListType.All;
		}
	}

	private static void FilterHelper(BindingFlags P_0, ref string P_1, out bool P_2, out MemberListType P_3)
	{
		FilterHelper(P_0, ref P_1, false, out var _, out P_2, out P_3);
	}

	private static bool FilterApplyPrefixLookup(MemberInfo P_0, string P_1, bool P_2)
	{
		if (P_2)
		{
			if (!P_0.Name.StartsWith(P_1, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
		}
		else if (!P_0.Name.StartsWith(P_1, StringComparison.Ordinal))
		{
			return false;
		}
		return true;
	}

	private static bool FilterApplyBase(MemberInfo P_0, BindingFlags P_1, bool P_2, bool P_3, bool P_4, string P_5, bool P_6)
	{
		if (P_2)
		{
			if ((P_1 & BindingFlags.Public) == 0)
			{
				return false;
			}
		}
		else if ((P_1 & BindingFlags.NonPublic) == 0)
		{
			return false;
		}
		bool flag = (object)P_0.DeclaringType != P_0.ReflectedType;
		if ((P_1 & BindingFlags.DeclaredOnly) != 0 && flag)
		{
			return false;
		}
		if (P_0.MemberType != MemberTypes.TypeInfo && P_0.MemberType != MemberTypes.NestedType)
		{
			if (P_4)
			{
				if ((P_1 & BindingFlags.FlattenHierarchy) == 0 && flag)
				{
					return false;
				}
				if ((P_1 & BindingFlags.Static) == 0)
				{
					return false;
				}
			}
			else if ((P_1 & BindingFlags.Instance) == 0)
			{
				return false;
			}
		}
		if (P_6 && !FilterApplyPrefixLookup(P_0, P_5, (P_1 & BindingFlags.IgnoreCase) != 0))
		{
			return false;
		}
		if ((P_1 & BindingFlags.DeclaredOnly) == 0 && flag && P_3 && (P_1 & BindingFlags.NonPublic) != BindingFlags.Default && !P_4 && (P_1 & BindingFlags.Instance) != BindingFlags.Default)
		{
			MethodInfo methodInfo = P_0 as MethodInfo;
			if (methodInfo == null)
			{
				return false;
			}
			if (!methodInfo.IsVirtual && !methodInfo.IsAbstract)
			{
				return false;
			}
		}
		return true;
	}

	private static bool FilterApplyType(Type P_0, BindingFlags P_1, string P_2, bool P_3, string P_4)
	{
		bool flag = P_0.IsNestedPublic || P_0.IsPublic;
		bool flag2 = false;
		if (!FilterApplyBase(P_0, P_1, flag, P_0.IsNestedAssembly, flag2, P_2, P_3))
		{
			return false;
		}
		if (P_4 != null && P_4 != P_0.Namespace)
		{
			return false;
		}
		return true;
	}

	private static bool FilterApplyMethodInfo(RuntimeMethodInfo P_0, BindingFlags P_1, CallingConventions P_2, Type[] P_3)
	{
		return FilterApplyMethodBase(P_0, P_1, P_2, P_3);
	}

	private static bool FilterApplyConstructorInfo(RuntimeConstructorInfo P_0, BindingFlags P_1, CallingConventions P_2, Type[] P_3)
	{
		return FilterApplyMethodBase(P_0, P_1, P_2, P_3);
	}

	private static bool FilterApplyMethodBase(MethodBase P_0, BindingFlags P_1, CallingConventions P_2, Type[] P_3)
	{
		P_1 ^= BindingFlags.DeclaredOnly;
		if ((P_2 & CallingConventions.Any) == 0)
		{
			if ((P_2 & CallingConventions.VarArgs) != 0 && (P_0.CallingConvention & CallingConventions.VarArgs) == 0)
			{
				return false;
			}
			if ((P_2 & CallingConventions.Standard) != 0 && (P_0.CallingConvention & CallingConventions.Standard) == 0)
			{
				return false;
			}
		}
		if (P_3 != null)
		{
			ParameterInfo[] parametersNoCopy = P_0.GetParametersNoCopy();
			if (P_3.Length != parametersNoCopy.Length)
			{
				if ((P_1 & (BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetProperty | BindingFlags.SetProperty)) == 0)
				{
					return false;
				}
				bool flag = false;
				if (P_3.Length > parametersNoCopy.Length)
				{
					if ((P_0.CallingConvention & CallingConventions.VarArgs) == 0)
					{
						flag = true;
					}
				}
				else if ((P_1 & BindingFlags.OptionalParamBinding) == 0)
				{
					flag = true;
				}
				else if (!parametersNoCopy[P_3.Length].IsOptional)
				{
					flag = true;
				}
				if (flag)
				{
					if (parametersNoCopy.Length == 0)
					{
						return false;
					}
					if (P_3.Length < parametersNoCopy.Length - 1)
					{
						return false;
					}
					ParameterInfo parameterInfo = parametersNoCopy[parametersNoCopy.Length - 1];
					if (!parameterInfo.ParameterType.IsArray)
					{
						return false;
					}
					if (!parameterInfo.IsDefined(typeof(ParamArrayAttribute), false))
					{
						return false;
					}
				}
			}
			else if ((P_1 & BindingFlags.ExactBinding) != BindingFlags.Default && (P_1 & BindingFlags.InvokeMethod) == 0)
			{
				for (int i = 0; i < parametersNoCopy.Length; i++)
				{
					if ((object)P_3[i] != null && !P_3[i].MatchesParameterTypeExactly(parametersNoCopy[i]))
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	internal RuntimeType()
	{
		throw new NotSupportedException();
	}

	private ListBuilder<MethodInfo> GetMethodCandidates(string P_0, BindingFlags P_1, CallingConventions P_2, Type[] P_3, int P_4, bool P_5)
	{
		FilterHelper(P_1, ref P_0, P_5, out var flag, out var flag2, out var memberListType);
		RuntimeMethodInfo[] methodsByName = GetMethodsByName(P_0, P_1, memberListType, this);
		ListBuilder<MethodInfo> result = new ListBuilder<MethodInfo>(methodsByName.Length);
		foreach (RuntimeMethodInfo runtimeMethodInfo in methodsByName)
		{
			if (P_4 != -1)
			{
				bool isGenericMethod = runtimeMethodInfo.IsGenericMethod;
				if ((P_4 == 0 && isGenericMethod) || (P_4 > 0 && !isGenericMethod))
				{
					continue;
				}
				Type[] genericArguments = runtimeMethodInfo.GetGenericArguments();
				if (genericArguments.Length != P_4)
				{
					continue;
				}
			}
			if (FilterApplyMethodInfo(runtimeMethodInfo, P_1, P_2, P_3) && (!flag || FilterApplyPrefixLookup(runtimeMethodInfo, P_0, flag2)))
			{
				result.Add(runtimeMethodInfo);
			}
		}
		return result;
	}

	private ListBuilder<ConstructorInfo> GetConstructorCandidates(string P_0, BindingFlags P_1, CallingConventions P_2, Type[] P_3, bool P_4)
	{
		FilterHelper(P_1, ref P_0, P_4, out var flag, out var flag2, out var _);
		if (!string.IsNullOrEmpty(P_0) && P_0 != ConstructorInfo.ConstructorName && P_0 != ConstructorInfo.TypeConstructorName)
		{
			return new ListBuilder<ConstructorInfo>(0);
		}
		RuntimeConstructorInfo[] constructors_internal = GetConstructors_internal(P_1, this);
		ListBuilder<ConstructorInfo> result = new ListBuilder<ConstructorInfo>(constructors_internal.Length);
		foreach (RuntimeConstructorInfo runtimeConstructorInfo in constructors_internal)
		{
			if (FilterApplyConstructorInfo(runtimeConstructorInfo, P_1, P_2, P_3) && (!flag || FilterApplyPrefixLookup(runtimeConstructorInfo, P_0, flag2)))
			{
				result.Add(runtimeConstructorInfo);
			}
		}
		return result;
	}

	private ListBuilder<PropertyInfo> GetPropertyCandidates(string P_0, BindingFlags P_1, Type[] P_2, bool P_3)
	{
		FilterHelper(P_1, ref P_0, P_3, out var flag, out var flag2, out var memberListType);
		RuntimePropertyInfo[] propertiesByName = GetPropertiesByName(P_0, P_1, memberListType, this);
		P_1 ^= BindingFlags.DeclaredOnly;
		ListBuilder<PropertyInfo> result = new ListBuilder<PropertyInfo>(propertiesByName.Length);
		foreach (RuntimePropertyInfo runtimePropertyInfo in propertiesByName)
		{
			if ((P_1 & runtimePropertyInfo.BindingFlags) == runtimePropertyInfo.BindingFlags && (!flag || FilterApplyPrefixLookup(runtimePropertyInfo, P_0, flag2)) && (P_2 == null || runtimePropertyInfo.GetIndexParameters().Length == P_2.Length))
			{
				result.Add(runtimePropertyInfo);
			}
		}
		return result;
	}

	private ListBuilder<EventInfo> GetEventCandidates(string P_0, BindingFlags P_1, bool P_2)
	{
		FilterHelper(P_1, ref P_0, P_2, out var flag, out var flag2, out var memberListType);
		RuntimeEventInfo[] events_internal = GetEvents_internal(P_0, memberListType, this);
		P_1 ^= BindingFlags.DeclaredOnly;
		ListBuilder<EventInfo> result = new ListBuilder<EventInfo>(events_internal.Length);
		foreach (RuntimeEventInfo runtimeEventInfo in events_internal)
		{
			if ((P_1 & runtimeEventInfo.BindingFlags) == runtimeEventInfo.BindingFlags && (!flag || FilterApplyPrefixLookup(runtimeEventInfo, P_0, flag2)))
			{
				result.Add(runtimeEventInfo);
			}
		}
		return result;
	}

	private ListBuilder<FieldInfo> GetFieldCandidates(string P_0, BindingFlags P_1, bool P_2)
	{
		FilterHelper(P_1, ref P_0, P_2, out var flag, out var flag2, out var memberListType);
		RuntimeFieldInfo[] fields_internal = GetFields_internal(P_0, P_1, memberListType, this);
		ListBuilder<FieldInfo> result = new ListBuilder<FieldInfo>(fields_internal.Length);
		foreach (RuntimeFieldInfo runtimeFieldInfo in fields_internal)
		{
			if (!flag || FilterApplyPrefixLookup(runtimeFieldInfo, P_0, flag2))
			{
				result.Add(runtimeFieldInfo);
			}
		}
		return result;
	}

	private ListBuilder<Type> GetNestedTypeCandidates(string P_0, BindingFlags P_1, bool P_2)
	{
		P_1 &= ~BindingFlags.Static;
		SplitName(P_0, out var text, out var text2);
		FilterHelper(P_1, ref text, P_2, out var flag, out var _, out var memberListType);
		RuntimeType[] nestedTypes_internal = GetNestedTypes_internal(text, P_1, memberListType);
		ListBuilder<Type> result = new ListBuilder<Type>(nestedTypes_internal.Length);
		foreach (RuntimeType runtimeType in nestedTypes_internal)
		{
			if (FilterApplyType(runtimeType, P_1, text, flag, text2))
			{
				result.Add(runtimeType);
			}
		}
		return result;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	public override MethodInfo[] GetMethods(BindingFlags P_0)
	{
		return GetMethodCandidates(null, P_0, CallingConventions.Any, null, -1, false).ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	public override ConstructorInfo[] GetConstructors(BindingFlags P_0)
	{
		return GetConstructorCandidates(null, P_0, CallingConventions.Any, null, false).ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	public override PropertyInfo[] GetProperties(BindingFlags P_0)
	{
		return GetPropertyCandidates(null, P_0, null, false).ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public override FieldInfo[] GetFields(BindingFlags P_0)
	{
		return GetFieldCandidates(null, P_0, false).ToArray();
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override MemberInfo[] GetMembers(BindingFlags P_0)
	{
		ListBuilder<MethodInfo> methodCandidates = GetMethodCandidates(null, P_0, CallingConventions.Any, null, -1, false);
		ListBuilder<ConstructorInfo> constructorCandidates = GetConstructorCandidates(null, P_0, CallingConventions.Any, null, false);
		ListBuilder<PropertyInfo> propertyCandidates = GetPropertyCandidates(null, P_0, null, false);
		ListBuilder<EventInfo> eventCandidates = GetEventCandidates(null, P_0, false);
		ListBuilder<FieldInfo> fieldCandidates = GetFieldCandidates(null, P_0, false);
		ListBuilder<Type> nestedTypeCandidates = GetNestedTypeCandidates(null, P_0, false);
		MemberInfo[] array = new MemberInfo[methodCandidates.Count + constructorCandidates.Count + propertyCandidates.Count + eventCandidates.Count + fieldCandidates.Count + nestedTypeCandidates.Count];
		int num = 0;
		object[] array2 = array;
		methodCandidates.CopyTo(array2, num);
		num += methodCandidates.Count;
		array2 = array;
		constructorCandidates.CopyTo(array2, num);
		num += constructorCandidates.Count;
		array2 = array;
		propertyCandidates.CopyTo(array2, num);
		num += propertyCandidates.Count;
		array2 = array;
		eventCandidates.CopyTo(array2, num);
		num += eventCandidates.Count;
		array2 = array;
		fieldCandidates.CopyTo(array2, num);
		num += fieldCandidates.Count;
		array2 = array;
		nestedTypeCandidates.CopyTo(array2, num);
		num += nestedTypeCandidates.Count;
		return array;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	protected override MethodInfo GetMethodImpl(string P_0, BindingFlags P_1, Binder P_2, CallingConventions P_3, Type[] P_4, ParameterModifier[] P_5)
	{
		return GetMethodImpl(P_0, -1, P_1, P_2, P_3, P_4, P_5);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods)]
	protected override MethodInfo GetMethodImpl(string P_0, int P_1, BindingFlags P_2, Binder P_3, CallingConventions P_4, Type[] P_5, ParameterModifier[] P_6)
	{
		ListBuilder<MethodInfo> methodCandidates = GetMethodCandidates(P_0, P_2, P_4, P_5, P_1, false);
		if (methodCandidates.Count == 0)
		{
			return null;
		}
		MethodBase[] array;
		if (P_5 == null || P_5.Length == 0)
		{
			MethodInfo methodInfo = methodCandidates[0];
			if (methodCandidates.Count == 1)
			{
				return methodInfo;
			}
			if (P_5 == null)
			{
				for (int i = 1; i < methodCandidates.Count; i++)
				{
					MethodInfo methodInfo2 = methodCandidates[i];
					if (!System.DefaultBinder.CompareMethodSig(methodInfo2, methodInfo))
					{
						throw new AmbiguousMatchException();
					}
				}
				array = methodCandidates.ToArray();
				return System.DefaultBinder.FindMostDerivedNewSlotMeth(array, methodCandidates.Count) as MethodInfo;
			}
		}
		if (P_3 == null)
		{
			P_3 = Type.DefaultBinder;
		}
		Binder binder = P_3;
		array = methodCandidates.ToArray();
		return binder.SelectMethod(P_2, array, P_5, P_6) as MethodInfo;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
	protected override ConstructorInfo GetConstructorImpl(BindingFlags P_0, Binder P_1, CallingConventions P_2, Type[] P_3, ParameterModifier[] P_4)
	{
		ListBuilder<ConstructorInfo> constructorCandidates = GetConstructorCandidates(null, P_0, CallingConventions.Any, P_3, false);
		if (constructorCandidates.Count == 0)
		{
			return null;
		}
		if (P_3.Length == 0 && constructorCandidates.Count == 1)
		{
			ConstructorInfo constructorInfo = constructorCandidates[0];
			ParameterInfo[] parametersNoCopy = constructorInfo.GetParametersNoCopy();
			if (parametersNoCopy == null || parametersNoCopy.Length == 0)
			{
				return constructorInfo;
			}
		}
		MethodBase[] array;
		if ((P_0 & BindingFlags.ExactBinding) != BindingFlags.Default)
		{
			array = constructorCandidates.ToArray();
			return System.DefaultBinder.ExactBinding(array, P_3) as ConstructorInfo;
		}
		if (P_1 == null)
		{
			P_1 = Type.DefaultBinder;
		}
		Binder binder = P_1;
		array = constructorCandidates.ToArray();
		return binder.SelectMethod(P_0, array, P_3, P_4) as ConstructorInfo;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
	protected override PropertyInfo GetPropertyImpl(string P_0, BindingFlags P_1, Binder P_2, Type P_3, Type[] P_4, ParameterModifier[] P_5)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		ListBuilder<PropertyInfo> propertyCandidates = GetPropertyCandidates(P_0, P_1, P_4, false);
		if (propertyCandidates.Count == 0)
		{
			return null;
		}
		if (P_4 == null || P_4.Length == 0)
		{
			if (propertyCandidates.Count == 1)
			{
				PropertyInfo propertyInfo = propertyCandidates[0];
				if ((object)P_3 != null && !P_3.IsEquivalentTo(propertyInfo.PropertyType))
				{
					return null;
				}
				return propertyInfo;
			}
			if ((object)P_3 == null)
			{
				throw new AmbiguousMatchException();
			}
		}
		if ((P_1 & BindingFlags.ExactBinding) != BindingFlags.Default)
		{
			return System.DefaultBinder.ExactPropertyBinding(propertyCandidates.ToArray(), P_3, P_4);
		}
		if (P_2 == null)
		{
			P_2 = Type.DefaultBinder;
		}
		return P_2.SelectProperty(P_1, propertyCandidates.ToArray(), P_3, P_4, P_5);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override EventInfo GetEvent(string P_0, BindingFlags P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		FilterHelper(P_1, ref P_0, out var _, out var memberListType);
		RuntimeEventInfo[] events_internal = GetEvents_internal(P_0, memberListType, this);
		EventInfo eventInfo = null;
		P_1 ^= BindingFlags.DeclaredOnly;
		foreach (RuntimeEventInfo runtimeEventInfo in events_internal)
		{
			if ((P_1 & runtimeEventInfo.BindingFlags) == runtimeEventInfo.BindingFlags)
			{
				if (eventInfo != null)
				{
					throw new AmbiguousMatchException();
				}
				eventInfo = runtimeEventInfo;
			}
		}
		return eventInfo;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)]
	public override FieldInfo GetField(string P_0, BindingFlags P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		FilterHelper(P_1, ref P_0, out var _, out var memberListType);
		RuntimeFieldInfo[] fields_internal = GetFields_internal(P_0, P_1, memberListType, this);
		FieldInfo fieldInfo = null;
		bool flag2 = false;
		foreach (RuntimeFieldInfo runtimeFieldInfo in fields_internal)
		{
			if (fieldInfo != null)
			{
				if ((object)runtimeFieldInfo.DeclaringType == fieldInfo.DeclaringType)
				{
					throw new AmbiguousMatchException();
				}
				if (fieldInfo.DeclaringType.IsInterface && runtimeFieldInfo.DeclaringType.IsInterface)
				{
					flag2 = true;
				}
			}
			if (fieldInfo == null || runtimeFieldInfo.DeclaringType.IsSubclassOf(fieldInfo.DeclaringType) || fieldInfo.DeclaringType.IsInterface)
			{
				fieldInfo = runtimeFieldInfo;
			}
		}
		if (flag2 && fieldInfo.DeclaringType.IsInterface)
		{
			throw new AmbiguousMatchException();
		}
		return fieldInfo;
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties | DynamicallyAccessedMemberTypes.PublicEvents | DynamicallyAccessedMemberTypes.NonPublicEvents)]
	public override MemberInfo[] GetMember(string P_0, MemberTypes P_1, BindingFlags P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		ListBuilder<MethodInfo> listBuilder = default(ListBuilder<MethodInfo>);
		ListBuilder<ConstructorInfo> listBuilder2 = default(ListBuilder<ConstructorInfo>);
		ListBuilder<PropertyInfo> listBuilder3 = default(ListBuilder<PropertyInfo>);
		ListBuilder<EventInfo> listBuilder4 = default(ListBuilder<EventInfo>);
		ListBuilder<FieldInfo> listBuilder5 = default(ListBuilder<FieldInfo>);
		ListBuilder<Type> listBuilder6 = default(ListBuilder<Type>);
		int num = 0;
		if ((P_1 & MemberTypes.Method) != 0)
		{
			listBuilder = GetMethodCandidates(P_0, P_2, CallingConventions.Any, null, -1, true);
			if (P_1 == MemberTypes.Method)
			{
				return listBuilder.ToArray();
			}
			num += listBuilder.Count;
		}
		if ((P_1 & MemberTypes.Constructor) != 0)
		{
			listBuilder2 = GetConstructorCandidates(P_0, P_2, CallingConventions.Any, null, true);
			if (P_1 == MemberTypes.Constructor)
			{
				return listBuilder2.ToArray();
			}
			num += listBuilder2.Count;
		}
		if ((P_1 & MemberTypes.Property) != 0)
		{
			listBuilder3 = GetPropertyCandidates(P_0, P_2, null, true);
			if (P_1 == MemberTypes.Property)
			{
				return listBuilder3.ToArray();
			}
			num += listBuilder3.Count;
		}
		if ((P_1 & MemberTypes.Event) != 0)
		{
			listBuilder4 = GetEventCandidates(P_0, P_2, true);
			if (P_1 == MemberTypes.Event)
			{
				return listBuilder4.ToArray();
			}
			num += listBuilder4.Count;
		}
		if ((P_1 & MemberTypes.Field) != 0)
		{
			listBuilder5 = GetFieldCandidates(P_0, P_2, true);
			if (P_1 == MemberTypes.Field)
			{
				return listBuilder5.ToArray();
			}
			num += listBuilder5.Count;
		}
		if ((P_1 & (MemberTypes.TypeInfo | MemberTypes.NestedType)) != 0)
		{
			listBuilder6 = GetNestedTypeCandidates(P_0, P_2, true);
			if (P_1 == MemberTypes.NestedType || P_1 == MemberTypes.TypeInfo)
			{
				return listBuilder6.ToArray();
			}
			num += listBuilder6.Count;
		}
		MemberInfo[] array;
		if (P_1 != (MemberTypes.Constructor | MemberTypes.Method))
		{
			array = new MemberInfo[num];
		}
		else
		{
			MemberInfo[] array2 = new MethodBase[num];
			array = array2;
		}
		MemberInfo[] array3 = array;
		int num2 = 0;
		object[] array4 = array3;
		listBuilder.CopyTo(array4, num2);
		num2 += listBuilder.Count;
		array4 = array3;
		listBuilder2.CopyTo(array4, num2);
		num2 += listBuilder2.Count;
		array4 = array3;
		listBuilder3.CopyTo(array4, num2);
		num2 += listBuilder3.Count;
		array4 = array3;
		listBuilder4.CopyTo(array4, num2);
		num2 += listBuilder4.Count;
		array4 = array3;
		listBuilder5.CopyTo(array4, num2);
		num2 += listBuilder5.Count;
		array4 = array3;
		listBuilder6.CopyTo(array4, num2);
		num2 += listBuilder6.Count;
		return array3;
	}

	public override MemberInfo GetMemberWithSameMetadataDefinitionAs(MemberInfo P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "member");
		RuntimeType runtimeType = this;
		while (runtimeType != null)
		{
			MemberInfo memberInfo = P_0.MemberType switch
			{
				MemberTypes.Method => GetMethodWithSameMetadataDefinitionAs(runtimeType, P_0), 
				MemberTypes.Constructor => GetConstructorWithSameMetadataDefinitionAs(runtimeType, P_0), 
				MemberTypes.Property => GetPropertyWithSameMetadataDefinitionAs(runtimeType, P_0), 
				MemberTypes.Field => GetFieldWithSameMetadataDefinitionAs(runtimeType, P_0), 
				MemberTypes.Event => GetEventWithSameMetadataDefinitionAs(runtimeType, P_0), 
				MemberTypes.NestedType => GetNestedTypeWithSameMetadataDefinitionAs(runtimeType, P_0), 
				_ => null, 
			};
			if (memberInfo != null)
			{
				return memberInfo;
			}
			runtimeType = runtimeType.GetBaseType();
		}
		throw Type.CreateGetMemberWithSameMetadataDefinitionAsNotFoundException(P_0);
	}

	private static MemberInfo GetMethodWithSameMetadataDefinitionAs(RuntimeType P_0, MemberInfo P_1)
	{
		ListBuilder<MethodInfo> methodCandidates = P_0.GetMethodCandidates(P_1.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, CallingConventions.Any, null, -1, false);
		for (int i = 0; i < methodCandidates.Count; i++)
		{
			MethodInfo methodInfo = methodCandidates[i];
			if (methodInfo.HasSameMetadataDefinitionAs(P_1))
			{
				return methodInfo;
			}
		}
		return null;
	}

	private static MemberInfo GetConstructorWithSameMetadataDefinitionAs(RuntimeType P_0, MemberInfo P_1)
	{
		ListBuilder<ConstructorInfo> constructorCandidates = P_0.GetConstructorCandidates(null, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, CallingConventions.Any, null, false);
		for (int i = 0; i < constructorCandidates.Count; i++)
		{
			ConstructorInfo constructorInfo = constructorCandidates[i];
			if (constructorInfo.HasSameMetadataDefinitionAs(P_1))
			{
				return constructorInfo;
			}
		}
		return null;
	}

	private static MemberInfo GetPropertyWithSameMetadataDefinitionAs(RuntimeType P_0, MemberInfo P_1)
	{
		ListBuilder<PropertyInfo> propertyCandidates = P_0.GetPropertyCandidates(P_1.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, false);
		for (int i = 0; i < propertyCandidates.Count; i++)
		{
			PropertyInfo propertyInfo = propertyCandidates[i];
			if (propertyInfo.HasSameMetadataDefinitionAs(P_1))
			{
				return propertyInfo;
			}
		}
		return null;
	}

	private static MemberInfo GetFieldWithSameMetadataDefinitionAs(RuntimeType P_0, MemberInfo P_1)
	{
		ListBuilder<FieldInfo> fieldCandidates = P_0.GetFieldCandidates(P_1.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, false);
		for (int i = 0; i < fieldCandidates.Count; i++)
		{
			FieldInfo fieldInfo = fieldCandidates[i];
			if (fieldInfo.HasSameMetadataDefinitionAs(P_1))
			{
				return fieldInfo;
			}
		}
		return null;
	}

	private static MemberInfo GetEventWithSameMetadataDefinitionAs(RuntimeType P_0, MemberInfo P_1)
	{
		ListBuilder<EventInfo> eventCandidates = P_0.GetEventCandidates(null, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, false);
		for (int i = 0; i < eventCandidates.Count; i++)
		{
			EventInfo eventInfo = eventCandidates[i];
			if (eventInfo.HasSameMetadataDefinitionAs(P_1))
			{
				return eventInfo;
			}
		}
		return null;
	}

	private static MemberInfo GetNestedTypeWithSameMetadataDefinitionAs(RuntimeType P_0, MemberInfo P_1)
	{
		ListBuilder<Type> nestedTypeCandidates = P_0.GetNestedTypeCandidates(P_1.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, false);
		for (int i = 0; i < nestedTypeCandidates.Count; i++)
		{
			Type type = nestedTypeCandidates[i];
			if (type.HasSameMetadataDefinitionAs(P_1))
			{
				return type;
			}
		}
		return null;
	}

	public override bool IsEquivalentTo(Type P_0)
	{
		if (!(P_0 is RuntimeType runtimeType))
		{
			return false;
		}
		if (runtimeType == this)
		{
			return true;
		}
		return RuntimeTypeHandle.IsEquivalentTo(this, runtimeType);
	}

	internal bool IsDelegate()
	{
		return GetBaseType() == typeof(MulticastDelegate);
	}

	protected override bool IsValueTypeImpl()
	{
		if (this == typeof(ValueType) || this == typeof(Enum))
		{
			return false;
		}
		return IsSubclassOf(typeof(ValueType));
	}

	internal RuntimeType[] GetGenericArgumentsInternal()
	{
		RuntimeType[] result = null;
		RuntimeType runtimeType = this;
		GetGenericArgumentsInternal(new QCallTypeHandle(ref runtimeType), ObjectHandleOnStack.Create(ref result), true);
		return result;
	}

	public override Type[] GetGenericArguments()
	{
		Type[] array = null;
		RuntimeType runtimeType = this;
		GetGenericArgumentsInternal(new QCallTypeHandle(ref runtimeType), ObjectHandleOnStack.Create(ref array), false);
		return array ?? Type.EmptyTypes;
	}

	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public override Type MakeGenericType(params Type[] P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "instantiation");
		RuntimeType[] array = new RuntimeType[P_0.Length];
		if (!IsGenericTypeDefinition)
		{
			throw new InvalidOperationException(SR.Format("Arg_NotGenericTypeDefinition", this));
		}
		RuntimeType[] genericArgumentsInternal = GetGenericArgumentsInternal();
		if (genericArgumentsInternal.Length != P_0.Length)
		{
			throw new ArgumentException("Argument_GenericArgsCount", "instantiation");
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			Type type = P_0[i];
			if (type == null)
			{
				throw new ArgumentNullException();
			}
			RuntimeType runtimeType = type as RuntimeType;
			if (runtimeType == null)
			{
				if (type.IsSignatureType)
				{
					return Type.MakeGenericSignatureType(this, P_0);
				}
				Type[] array2 = new Type[P_0.Length];
				for (int j = 0; j < P_0.Length; j++)
				{
					array2[j] = P_0[j];
				}
				P_0 = array2;
				if (!RuntimeFeature.IsDynamicCodeSupported)
				{
					throw new PlatformNotSupportedException();
				}
				return TypeBuilderInstantiation.MakeGenericType(this, P_0);
			}
			array[i] = runtimeType;
		}
		SanityCheckGenericArguments(array, genericArgumentsInternal);
		Type type2 = null;
		Type[] array3 = array;
		MakeGenericType(this, array3, ObjectHandleOnStack.Create(ref type2));
		if (type2 == null)
		{
			throw new TypeLoadException();
		}
		return type2;
	}

	public static bool operator ==(RuntimeType P_0, RuntimeType P_1)
	{
		return (object)P_0 == P_1;
	}

	public static bool operator !=(RuntimeType P_0, RuntimeType P_1)
	{
		return (object)P_0 != P_1;
	}

	private void CreateInstanceCheckThis()
	{
		if (ContainsGenericParameters)
		{
			throw new ArgumentException(SR.Format("Acc_CreateGenericEx", this));
		}
		Type rootElementType = GetRootElementType();
		if ((object)rootElementType == typeof(ArgIterator))
		{
			throw new NotSupportedException("Acc_CreateArgIterator");
		}
		if ((object)rootElementType == typeof(void))
		{
			throw new NotSupportedException("Acc_CreateVoid");
		}
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2082:UnrecognizedReflectionPattern", Justification = "Implementation detail of Activator that linker intrinsically recognizes")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2085:UnrecognizedReflectionPattern", Justification = "Implementation detail of Activator that linker intrinsically recognizes")]
	internal object CreateInstanceImpl(BindingFlags P_0, Binder P_1, object[] P_2, CultureInfo P_3)
	{
		CreateInstanceCheckThis();
		object result;
		try
		{
			if (P_2 == null)
			{
				P_2 = Array.Empty<object>();
			}
			int num = P_2.Length;
			if (P_1 == null)
			{
				P_1 = Type.DefaultBinder;
			}
			bool flag = (P_0 & BindingFlags.NonPublic) == 0;
			bool flag2 = (P_0 & BindingFlags.DoNotWrapExceptions) == 0;
			if (num == 0 && (P_0 & BindingFlags.Public) != BindingFlags.Default && (P_0 & BindingFlags.Instance) != BindingFlags.Default && base.IsValueType)
			{
				result = CreateInstanceDefaultCtor(flag, flag2);
			}
			else
			{
				ConstructorInfo[] constructors = GetConstructors(P_0);
				List<MethodBase> list = new List<MethodBase>(constructors.Length);
				Type[] array = new Type[num];
				for (int i = 0; i < num; i++)
				{
					if (P_2[i] != null)
					{
						array[i] = P_2[i].GetType();
					}
				}
				for (int j = 0; j < constructors.Length; j++)
				{
					if (FilterApplyConstructorInfo((RuntimeConstructorInfo)constructors[j], P_0, CallingConventions.Any, array))
					{
						list.Add(constructors[j]);
					}
				}
				MethodBase[] array2 = new MethodBase[list.Count];
				list.CopyTo(array2);
				if (array2 != null && array2.Length == 0)
				{
					array2 = null;
				}
				if (array2 == null)
				{
					throw new MissingMethodException(SR.Format("MissingConstructor_Name", FullName));
				}
				object obj = null;
				MethodBase methodBase;
				try
				{
					methodBase = P_1.BindToMethod(P_0, array2, ref P_2, null, P_3, null, out obj);
				}
				catch (MissingMethodException)
				{
					methodBase = null;
				}
				if (methodBase == null)
				{
					throw new MissingMethodException(SR.Format("MissingConstructor_Name", FullName));
				}
				if (methodBase.GetParametersNoCopy().Length == 0)
				{
					if (P_2.Length != 0)
					{
						throw new NotSupportedException("NotSupported_CallToVarArg");
					}
					result = Activator.CreateInstance(this, true, flag2);
				}
				else
				{
					result = ((ConstructorInfo)methodBase).Invoke(P_0, P_1, P_2, P_3);
					if (obj != null)
					{
						P_1.ReorderArgumentArray(ref P_2, obj);
					}
				}
			}
		}
		catch (Exception)
		{
			throw;
		}
		return result;
	}

	internal object CreateInstanceDefaultCtor(bool P_0, bool P_1)
	{
		if (IsByRefLike)
		{
			throw new NotSupportedException("NotSupported_ByRefLike");
		}
		CreateInstanceCheckThis();
		return CreateInstanceMono(!P_0, P_1);
	}

	internal object CreateInstanceOfT()
	{
		return CreateInstanceMono(false, true);
	}

	internal RuntimeConstructorInfo GetDefaultConstructor()
	{
		TypeCache typeCache = Cache;
		RuntimeConstructorInfo result = null;
		if (Volatile.Read(ref typeCache.default_ctor_cached))
		{
			return typeCache.default_ctor;
		}
		ListBuilder<ConstructorInfo> constructorCandidates = GetConstructorCandidates(null, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, CallingConventions.Any, Type.EmptyTypes, false);
		if (constructorCandidates.Count == 1)
		{
			result = (typeCache.default_ctor = (RuntimeConstructorInfo)constructorCandidates[0]);
		}
		Volatile.Write(ref typeCache.default_ctor_cached, true);
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern MemberInfo GetCorrespondingInflatedMethod(QCallTypeHandle P_0, MemberInfo P_1);

	internal override MethodInfo GetMethod(MethodInfo P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "fromNoninstanciated");
		RuntimeType runtimeType = this;
		return (MethodInfo)GetCorrespondingInflatedMethod(new QCallTypeHandle(ref runtimeType), P_0);
	}

	internal override ConstructorInfo GetConstructor(ConstructorInfo P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "fromNoninstanciated");
		RuntimeType runtimeType = this;
		return (ConstructorInfo)GetCorrespondingInflatedMethod(new QCallTypeHandle(ref runtimeType), P_0);
	}

	private string GetDefaultMemberName()
	{
		object[] customAttributes = GetCustomAttributes(typeof(DefaultMemberAttribute), true);
		if (customAttributes.Length == 0)
		{
			return null;
		}
		return ((DefaultMemberAttribute)customAttributes[0]).MemberName;
	}

	private object CreateInstanceMono(bool P_0, bool P_1)
	{
		RuntimeConstructorInfo defaultConstructor = GetDefaultConstructor();
		if (!P_0 && defaultConstructor != null && !defaultConstructor.IsPublic)
		{
			throw new MissingMethodException(SR.Format("Arg_NoDefCTor", this));
		}
		if (defaultConstructor == null)
		{
			Type rootElementType = GetRootElementType();
			if ((object)rootElementType == typeof(TypedReference) || (object)rootElementType == typeof(RuntimeArgumentHandle))
			{
				throw new NotSupportedException("NotSupported_ContainsStackPtr");
			}
			if (base.IsValueType)
			{
				RuntimeType runtimeType = this;
				return CreateInstanceInternal(new QCallTypeHandle(ref runtimeType));
			}
			throw new MissingMethodException(SR.Format("Arg_NoDefCTor", this));
		}
		if (base.IsAbstract)
		{
			throw new MissingMethodException("Cannot create an abstract class '{0}'.", FullName);
		}
		return defaultConstructor.Invoker.InlinedInvoke(null, default(Span<object>), (!P_1) ? BindingFlags.DoNotWrapExceptions : BindingFlags.Default);
	}

	internal bool CheckValue(ref object P_0, ref ParameterCopyBackAction P_1, Binder P_2, CultureInfo P_3, BindingFlags P_4)
	{
		P_1 = ParameterCopyBackAction.Copy;
		switch (TryConvertToType(ref P_0))
		{
		case CheckValueStatus.Success:
			return true;
		case CheckValueStatus.NotSupported_ByRefLike:
			throw new NotSupportedException(SR.Format("NotSupported_ByRefLike", P_0?.GetType(), this));
		default:
			if ((P_4 & BindingFlags.ExactBinding) == BindingFlags.ExactBinding)
			{
				throw new ArgumentException(SR.Format("Arg_ObjObjEx", P_0?.GetType(), this));
			}
			if (P_2 != null && P_2 != Type.DefaultBinder)
			{
				P_0 = P_2.ChangeType(P_0, this, P_3);
				return true;
			}
			throw new ArgumentException(SR.Format("Arg_ObjObjEx", P_0?.GetType(), this));
		}
	}

	private CheckValueStatus TryConvertToType(ref object P_0)
	{
		if (IsInstanceOfType(P_0))
		{
			return CheckValueStatus.Success;
		}
		if (base.IsByRef)
		{
			Type elementType = GetElementType();
			if (elementType.IsByRefLike)
			{
				return CheckValueStatus.NotSupported_ByRefLike;
			}
			if (P_0 == null || elementType.IsInstanceOfType(P_0))
			{
				return CheckValueStatus.Success;
			}
		}
		if (P_0 == null)
		{
			if (IsByRefLike)
			{
				return CheckValueStatus.NotSupported_ByRefLike;
			}
			return CheckValueStatus.Success;
		}
		if (IsEnum)
		{
			Type underlyingType = Enum.GetUnderlyingType(this);
			if (underlyingType == P_0.GetType())
			{
				return CheckValueStatus.Success;
			}
			object obj = IsConvertibleToPrimitiveType(P_0, underlyingType);
			if (obj != null)
			{
				P_0 = obj;
				return CheckValueStatus.Success;
			}
		}
		else if (base.IsPrimitive)
		{
			object obj2 = IsConvertibleToPrimitiveType(P_0, this);
			if (obj2 != null)
			{
				P_0 = obj2;
				return CheckValueStatus.Success;
			}
		}
		else if (base.IsPointer)
		{
			Type type = P_0.GetType();
			if (type == typeof(nint) || type == typeof(nuint))
			{
				return CheckValueStatus.Success;
			}
			if (P_0 is Pointer pointer)
			{
				Type pointerType = pointer.GetPointerType();
				if (pointerType == this)
				{
					P_0 = pointer.GetPointerValue();
					return CheckValueStatus.Success;
				}
			}
		}
		return CheckValueStatus.ArgumentException;
	}

	internal bool TryByRefFastPath(ref object P_0, ref bool P_1)
	{
		return false;
	}

	private static object IsConvertibleToPrimitiveType(object P_0, Type P_1)
	{
		Type type = P_0.GetType();
		if (type.IsEnum)
		{
			type = Enum.GetUnderlyingType(type);
			if (type == P_1)
			{
				return P_0;
			}
		}
		TypeCode typeCode = Type.GetTypeCode(type);
		switch (Type.GetTypeCode(P_1))
		{
		case TypeCode.Char:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (char)(byte)P_0;
			case TypeCode.UInt16:
				return P_0;
			}
			break;
		case TypeCode.Int16:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (short)(byte)P_0;
			case TypeCode.SByte:
				return (short)(sbyte)P_0;
			}
			break;
		case TypeCode.UInt16:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (ushort)(byte)P_0;
			case TypeCode.Char:
				return P_0;
			}
			break;
		case TypeCode.Int32:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (int)(byte)P_0;
			case TypeCode.SByte:
				return (int)(sbyte)P_0;
			case TypeCode.Char:
				return (int)(char)P_0;
			case TypeCode.Int16:
				return (int)(short)P_0;
			case TypeCode.UInt16:
				return (int)(ushort)P_0;
			}
			break;
		case TypeCode.UInt32:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (uint)(byte)P_0;
			case TypeCode.Char:
				return (uint)(char)P_0;
			case TypeCode.UInt16:
				return (uint)(ushort)P_0;
			}
			break;
		case TypeCode.Int64:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (long)(byte)P_0;
			case TypeCode.SByte:
				return (long)(sbyte)P_0;
			case TypeCode.Int16:
				return (long)(short)P_0;
			case TypeCode.Char:
				return (long)(char)P_0;
			case TypeCode.UInt16:
				return (long)(ushort)P_0;
			case TypeCode.Int32:
				return (long)(int)P_0;
			case TypeCode.UInt32:
				return (long)(uint)P_0;
			}
			break;
		case TypeCode.UInt64:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (ulong)(byte)P_0;
			case TypeCode.Char:
				return (ulong)(char)P_0;
			case TypeCode.UInt16:
				return (ulong)(ushort)P_0;
			case TypeCode.UInt32:
				return (ulong)(uint)P_0;
			}
			break;
		case TypeCode.Single:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (float)(int)(byte)P_0;
			case TypeCode.SByte:
				return (float)(sbyte)P_0;
			case TypeCode.Int16:
				return (float)(short)P_0;
			case TypeCode.Char:
				return (float)(int)(char)P_0;
			case TypeCode.UInt16:
				return (float)(int)(ushort)P_0;
			case TypeCode.Int32:
				return (float)(int)P_0;
			case TypeCode.UInt32:
				return (float)(uint)P_0;
			case TypeCode.Int64:
				return (float)(long)P_0;
			case TypeCode.UInt64:
				return (float)(ulong)P_0;
			}
			break;
		case TypeCode.Double:
			switch (typeCode)
			{
			case TypeCode.Byte:
				return (double)(int)(byte)P_0;
			case TypeCode.SByte:
				return (double)(sbyte)P_0;
			case TypeCode.Char:
				return (double)(int)(char)P_0;
			case TypeCode.Int16:
				return (double)(short)P_0;
			case TypeCode.UInt16:
				return (double)(int)(ushort)P_0;
			case TypeCode.Int32:
				return (double)(int)P_0;
			case TypeCode.UInt32:
				return (double)(uint)P_0;
			case TypeCode.Int64:
				return (double)(long)P_0;
			case TypeCode.UInt64:
				return (double)(ulong)P_0;
			case TypeCode.Single:
				return (double)(float)P_0;
			}
			break;
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void make_array_type(QCallTypeHandle P_0, int P_1, ObjectHandleOnStack P_2);

	public override Type MakeArrayType()
	{
		Type result = null;
		RuntimeType runtimeType = this;
		make_array_type(new QCallTypeHandle(ref runtimeType), 0, ObjectHandleOnStack.Create(ref result));
		return result;
	}

	public override Type MakeArrayType(int P_0)
	{
		if (P_0 < 1)
		{
			throw new IndexOutOfRangeException();
		}
		Type result = null;
		RuntimeType runtimeType = this;
		make_array_type(new QCallTypeHandle(ref runtimeType), P_0, ObjectHandleOnStack.Create(ref result));
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void make_byref_type(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	public override Type MakeByRefType()
	{
		if (base.IsByRef)
		{
			throw new TypeLoadException("Can not call MakeByRefType on a ByRef type");
		}
		Type result = null;
		RuntimeType runtimeType = this;
		make_byref_type(new QCallTypeHandle(ref runtimeType), ObjectHandleOnStack.Create(ref result));
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void make_pointer_type(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	public override Type MakePointerType()
	{
		if (base.IsByRef)
		{
			throw new TypeLoadException($"Could not load type '{GetType()}' from assembly '{AssemblyQualifiedName}");
		}
		Type result = null;
		RuntimeType runtimeType = this;
		make_pointer_type(new QCallTypeHandle(ref runtimeType), ObjectHandleOnStack.Create(ref result));
		return result;
	}

	public override Type[] GetGenericParameterConstraints()
	{
		if (!IsGenericParameter)
		{
			throw new InvalidOperationException("Arg_NotGenericParameter");
		}
		Type[] constraints = new RuntimeGenericParamInfoHandle(RuntimeTypeHandle.GetGenericParameterInfo(this)).Constraints;
		return constraints ?? Type.EmptyTypes;
	}

	internal static object CreateInstanceForAnotherGenericParameter([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type P_0, RuntimeType P_1, RuntimeType P_2 = null)
	{
		RuntimeType runtimeType = null;
		if (P_2 != null)
		{
			MakeGenericType(P_0, new Type[2] { P_1, P_2 }, ObjectHandleOnStack.Create(ref runtimeType));
		}
		else
		{
			MakeGenericType(P_0, new Type[1] { P_1 }, ObjectHandleOnStack.Create(ref runtimeType));
		}
		RuntimeConstructorInfo defaultConstructor = runtimeType.GetDefaultConstructor();
		if ((object)defaultConstructor == null || !defaultConstructor.IsPublic)
		{
			throw new MissingMethodException(SR.Format("Arg_NoDefCTor", runtimeType));
		}
		return defaultConstructor.Invoker.InlinedInvoke(null, default(Span<object>), BindingFlags.Default);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MakeGenericType(Type P_0, Type[] P_1, ObjectHandleOnStack P_2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern nint GetMethodsByName_native(QCallTypeHandle P_0, nint P_1, BindingFlags P_2, MemberListType P_3);

	internal RuntimeMethodInfo[] GetMethodsByName(string P_0, BindingFlags P_1, MemberListType P_2, RuntimeType P_3)
	{
		RuntimeType runtimeType = this;
		RuntimeTypeHandle runtimeTypeHandle = new RuntimeTypeHandle(P_3);
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(P_0);
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetMethodsByName_native(new QCallTypeHandle(ref runtimeType), safeStringMarshal.Value, P_1, P_2));
		int length = safeGPtrArrayHandle.Length;
		RuntimeMethodInfo[] array = new RuntimeMethodInfo[length];
		for (int i = 0; i < length; i++)
		{
			RuntimeMethodHandle runtimeMethodHandle = new RuntimeMethodHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimeMethodInfo)RuntimeMethodInfo.GetMethodFromHandleNoGenericCheck(runtimeMethodHandle, runtimeTypeHandle);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetPropertiesByName_native(QCallTypeHandle P_0, nint P_1, BindingFlags P_2, MemberListType P_3);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetConstructors_native(QCallTypeHandle P_0, BindingFlags P_1);

	private RuntimeConstructorInfo[] GetConstructors_internal(BindingFlags P_0, RuntimeType P_1)
	{
		RuntimeTypeHandle runtimeTypeHandle = new RuntimeTypeHandle(P_1);
		RuntimeType runtimeType = this;
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetConstructors_native(new QCallTypeHandle(ref runtimeType), P_0));
		int length = safeGPtrArrayHandle.Length;
		RuntimeConstructorInfo[] array = new RuntimeConstructorInfo[length];
		for (int i = 0; i < length; i++)
		{
			RuntimeMethodHandle runtimeMethodHandle = new RuntimeMethodHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimeConstructorInfo)RuntimeMethodInfo.GetMethodFromHandleNoGenericCheck(runtimeMethodHandle, runtimeTypeHandle);
		}
		return array;
	}

	private RuntimePropertyInfo[] GetPropertiesByName(string P_0, BindingFlags P_1, MemberListType P_2, RuntimeType P_3)
	{
		RuntimeTypeHandle runtimeTypeHandle = new RuntimeTypeHandle(P_3);
		RuntimeType runtimeType = this;
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(P_0);
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetPropertiesByName_native(new QCallTypeHandle(ref runtimeType), safeStringMarshal.Value, P_1, P_2));
		int length = safeGPtrArrayHandle.Length;
		RuntimePropertyInfo[] array = new RuntimePropertyInfo[length];
		for (int i = 0; i < length; i++)
		{
			RuntimePropertyHandle runtimePropertyHandle = new RuntimePropertyHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimePropertyInfo)RuntimePropertyInfo.GetPropertyFromHandle(runtimePropertyHandle, runtimeTypeHandle);
		}
		return array;
	}

	public override string ToString()
	{
		return getFullName(false, false);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern object CreateInstanceInternal(QCallTypeHandle P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetDeclaringMethod(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void getFullName(QCallTypeHandle P_0, ObjectHandleOnStack P_1, bool P_2, bool P_3);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGenericArgumentsInternal(QCallTypeHandle P_0, ObjectHandleOnStack P_1, bool P_2);

	internal string getFullName(bool P_0, bool P_1)
	{
		RuntimeType runtimeType = this;
		string result = null;
		getFullName(new QCallTypeHandle(ref runtimeType), ObjectHandleOnStack.Create(ref result), P_0, P_1);
		return result;
	}

	private GenericParameterAttributes GetGenericParameterAttributes()
	{
		return new RuntimeGenericParamInfoHandle(RuntimeTypeHandle.GetGenericParameterInfo(this)).Attributes;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetGenericParameterPosition(QCallTypeHandle P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetEvents_native(QCallTypeHandle P_0, nint P_1, MemberListType P_2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetFields_native(QCallTypeHandle P_0, nint P_1, BindingFlags P_2, MemberListType P_3);

	private RuntimeFieldInfo[] GetFields_internal(string P_0, BindingFlags P_1, MemberListType P_2, RuntimeType P_3)
	{
		RuntimeTypeHandle runtimeTypeHandle = new RuntimeTypeHandle(P_3);
		RuntimeType runtimeType = this;
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(P_0);
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetFields_native(new QCallTypeHandle(ref runtimeType), safeStringMarshal.Value, P_1, P_2));
		int length = safeGPtrArrayHandle.Length;
		RuntimeFieldInfo[] array = new RuntimeFieldInfo[length];
		for (int i = 0; i < length; i++)
		{
			RuntimeFieldHandle runtimeFieldHandle = new RuntimeFieldHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimeFieldInfo)FieldInfo.GetFieldFromHandle(runtimeFieldHandle, runtimeTypeHandle);
		}
		return array;
	}

	private RuntimeEventInfo[] GetEvents_internal(string P_0, MemberListType P_1, RuntimeType P_2)
	{
		RuntimeTypeHandle runtimeTypeHandle = new RuntimeTypeHandle(P_2);
		RuntimeType runtimeType = this;
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(P_0);
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetEvents_native(new QCallTypeHandle(ref runtimeType), safeStringMarshal.Value, P_1));
		int length = safeGPtrArrayHandle.Length;
		RuntimeEventInfo[] array = new RuntimeEventInfo[length];
		for (int i = 0; i < length; i++)
		{
			RuntimeEventHandle runtimeEventHandle = new RuntimeEventHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimeEventInfo)RuntimeEventInfo.GetEventFromHandle(runtimeEventHandle, runtimeTypeHandle);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetInterfaces(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
	public override Type[] GetInterfaces()
	{
		RuntimeType runtimeType = this;
		Type[] result = null;
		GetInterfaces(new QCallTypeHandle(ref runtimeType), ObjectHandleOnStack.Create(ref result));
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern nint GetNestedTypes_native(QCallTypeHandle P_0, nint P_1, BindingFlags P_2, MemberListType P_3);

	private RuntimeType[] GetNestedTypes_internal(string P_0, BindingFlags P_1, MemberListType P_2)
	{
		string text = null;
		if (P_0 != null)
		{
			text = P_0;
		}
		RuntimeType runtimeType = this;
		using SafeStringMarshal safeStringMarshal = new SafeStringMarshal(text);
		using SafeGPtrArrayHandle safeGPtrArrayHandle = new SafeGPtrArrayHandle(GetNestedTypes_native(new QCallTypeHandle(ref runtimeType), safeStringMarshal.Value, P_1, P_2));
		int length = safeGPtrArrayHandle.Length;
		RuntimeType[] array = new RuntimeType[length];
		for (int i = 0; i < length; i++)
		{
			RuntimeTypeHandle runtimeTypeHandle = new RuntimeTypeHandle(safeGPtrArrayHandle[i]);
			array[i] = (RuntimeType)Type.GetTypeFromHandle(runtimeTypeHandle);
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetDeclaringType(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetName(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetNamespace(QCallTypeHandle P_0, ObjectHandleOnStack P_1);

	public sealed override bool HasSameMetadataDefinitionAs(MemberInfo P_0)
	{
		return HasSameMetadataDefinitionAsCore<RuntimeType>(P_0);
	}

	public override bool IsSubclassOf(Type P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "type");
		RuntimeType runtimeType = P_0 as RuntimeType;
		if (runtimeType == null)
		{
			return false;
		}
		return RuntimeTypeHandle.IsSubclassOf(this, runtimeType);
	}

	public object Clone()
	{
		return this;
	}

	public override bool Equals(object P_0)
	{
		return P_0 == this;
	}

	public override int GetArrayRank()
	{
		if (!IsArrayImpl())
		{
			throw new ArgumentException("Argument_HasToBeArrayClass");
		}
		return RuntimeTypeHandle.GetArrayRank(this);
	}

	protected override TypeAttributes GetAttributeFlagsImpl()
	{
		return RuntimeTypeHandle.GetAttributes(this);
	}

	public override object[] GetCustomAttributes(bool P_0)
	{
		return CustomAttribute.GetCustomAttributes(this, ObjectType, P_0);
	}

	public override object[] GetCustomAttributes(Type P_0, bool P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "attributeType");
		if (!(P_0.UnderlyingSystemType is RuntimeType runtimeType))
		{
			throw new ArgumentException("Arg_MustBeType", "attributeType");
		}
		return CustomAttribute.GetCustomAttributes(this, runtimeType, P_1);
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicEvents)]
	public override MemberInfo[] GetDefaultMembers()
	{
		MemberInfo[] array = null;
		string defaultMemberName = GetDefaultMemberName();
		if (defaultMemberName != null)
		{
			array = GetMember(defaultMemberName);
		}
		return array ?? Array.Empty<MemberInfo>();
	}

	public override Type GetElementType()
	{
		return RuntimeTypeHandle.GetElementType(this);
	}

	public override string GetEnumName(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		RuntimeType runtimeType = (RuntimeType)P_0.GetType();
		if (!runtimeType.IsActualEnum && !Type.IsIntegerType(runtimeType))
		{
			throw new ArgumentException("Arg_MustBeEnumBaseTypeOrEnum", "value");
		}
		ulong num = Enum.ToUInt64(P_0);
		return Enum.GetEnumName(this, num);
	}

	public override string[] GetEnumNames()
	{
		if (!IsActualEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "enumType");
		}
		string[] array = Enum.InternalGetNames(this);
		return new ReadOnlySpan<string>(array).ToArray();
	}

	[RequiresDynamicCode("It might not be possible to create an array of the enum type at runtime. Use the GetEnumValues<TEnum> overload or the GetEnumValuesAsUnderlyingType method instead.")]
	public override Array GetEnumValues()
	{
		if (!IsActualEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "enumType");
		}
		ulong[] array = Enum.InternalGetValues(this);
		Array array2 = Array.CreateInstance(this, array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			object obj = Enum.ToObject(this, array[i]);
			array2.SetValue(obj, i);
		}
		return array2;
	}

	public override Array GetEnumValuesAsUnderlyingType()
	{
		if (!IsActualEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "enumType");
		}
		ulong[] array = Enum.InternalGetValues(this);
		switch (RuntimeTypeHandle.GetCorElementType(Enum.InternalGetUnderlyingType(this)))
		{
		case CorElementType.ELEMENT_TYPE_U1:
		{
			byte[] array7 = new byte[array.Length];
			for (int n = 0; n < array.Length; n++)
			{
				array7[n] = (byte)array[n];
			}
			return array7;
		}
		case CorElementType.ELEMENT_TYPE_U2:
		{
			ushort[] array6 = new ushort[array.Length];
			for (int m = 0; m < array.Length; m++)
			{
				array6[m] = (ushort)array[m];
			}
			return array6;
		}
		case CorElementType.ELEMENT_TYPE_U4:
		{
			uint[] array3 = new uint[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				array3[j] = (uint)array[j];
			}
			return array3;
		}
		case CorElementType.ELEMENT_TYPE_U8:
			return (Array)array.Clone();
		case CorElementType.ELEMENT_TYPE_I1:
		{
			sbyte[] array4 = new sbyte[array.Length];
			for (int k = 0; k < array.Length; k++)
			{
				array4[k] = (sbyte)array[k];
			}
			return array4;
		}
		case CorElementType.ELEMENT_TYPE_I2:
		{
			short[] array8 = new short[array.Length];
			for (int num = 0; num < array.Length; num++)
			{
				array8[num] = (short)array[num];
			}
			return array8;
		}
		case CorElementType.ELEMENT_TYPE_I4:
		{
			int[] array5 = new int[array.Length];
			for (int l = 0; l < array.Length; l++)
			{
				array5[l] = (int)array[l];
			}
			return array5;
		}
		case CorElementType.ELEMENT_TYPE_I8:
		{
			long[] array2 = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (long)array[i];
			}
			return array2;
		}
		default:
			throw new InvalidOperationException("InvalidOperation_UnknownEnumType");
		}
	}

	public override Type GetEnumUnderlyingType()
	{
		if (!IsActualEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "enumType");
		}
		return Enum.InternalGetUnderlyingType(this);
	}

	public override Type GetGenericTypeDefinition()
	{
		if (!IsGenericType)
		{
			throw new InvalidOperationException("InvalidOperation_NotGenericType");
		}
		return RuntimeTypeHandle.GetGenericTypeDefinition(this);
	}

	public override int GetHashCode()
	{
		return RuntimeHelpers.GetHashCode(this);
	}

	internal RuntimeModule GetRuntimeModule()
	{
		return RuntimeTypeHandle.GetModule(this);
	}

	protected override TypeCode GetTypeCodeImpl()
	{
		TypeCode typeCode = Cache.TypeCode;
		if (typeCode != TypeCode.Empty)
		{
			return typeCode;
		}
		typeCode = RuntimeTypeHandle.GetCorElementType(this) switch
		{
			CorElementType.ELEMENT_TYPE_BOOLEAN => TypeCode.Boolean, 
			CorElementType.ELEMENT_TYPE_CHAR => TypeCode.Char, 
			CorElementType.ELEMENT_TYPE_I1 => TypeCode.SByte, 
			CorElementType.ELEMENT_TYPE_U1 => TypeCode.Byte, 
			CorElementType.ELEMENT_TYPE_I2 => TypeCode.Int16, 
			CorElementType.ELEMENT_TYPE_U2 => TypeCode.UInt16, 
			CorElementType.ELEMENT_TYPE_I4 => TypeCode.Int32, 
			CorElementType.ELEMENT_TYPE_U4 => TypeCode.UInt32, 
			CorElementType.ELEMENT_TYPE_I8 => TypeCode.Int64, 
			CorElementType.ELEMENT_TYPE_U8 => TypeCode.UInt64, 
			CorElementType.ELEMENT_TYPE_R4 => TypeCode.Single, 
			CorElementType.ELEMENT_TYPE_R8 => TypeCode.Double, 
			CorElementType.ELEMENT_TYPE_STRING => TypeCode.String, 
			CorElementType.ELEMENT_TYPE_VALUETYPE => ((object)this != typeof(decimal)) ? (((object)this != typeof(DateTime)) ? ((!IsActualEnum) ? TypeCode.Object : Type.GetTypeCode(Enum.InternalGetUnderlyingType(this))) : TypeCode.DateTime) : TypeCode.Decimal, 
			_ => ((object)this != typeof(DBNull)) ? TypeCode.Object : TypeCode.DBNull, 
		};
		Cache.TypeCode = typeCode;
		return typeCode;
	}

	protected override bool HasElementTypeImpl()
	{
		return RuntimeTypeHandle.HasElementType(this);
	}

	protected override bool IsArrayImpl()
	{
		return RuntimeTypeHandle.IsArray(this);
	}

	public override bool IsDefined(Type P_0, bool P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "attributeType");
		if (!(P_0.UnderlyingSystemType is RuntimeType runtimeType))
		{
			throw new ArgumentException("Arg_MustBeType", "attributeType");
		}
		return CustomAttribute.IsDefined(this, runtimeType, P_1);
	}

	public override bool IsEnumDefined(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if (!IsActualEnum)
		{
			throw new ArgumentException("Arg_MustBeEnum", "enumType");
		}
		RuntimeType runtimeType = (RuntimeType)P_0.GetType();
		if (runtimeType.IsActualEnum)
		{
			if (!runtimeType.IsEquivalentTo(this))
			{
				throw new ArgumentException(SR.Format("Arg_EnumAndObjectMustBeSameType", runtimeType, this));
			}
			runtimeType = (RuntimeType)runtimeType.GetEnumUnderlyingType();
		}
		if (runtimeType == StringType)
		{
			string[] array = Enum.InternalGetNames(this);
			object[] array2 = array;
			return Array.IndexOf(array2, P_0) >= 0;
		}
		if (Type.IsIntegerType(runtimeType))
		{
			RuntimeType runtimeType2 = Enum.InternalGetUnderlyingType(this);
			if (runtimeType2 != runtimeType)
			{
				throw new ArgumentException(SR.Format("Arg_EnumUnderlyingTypeAndObjectMustBeSameType", runtimeType, runtimeType2));
			}
			ulong[] array3 = Enum.InternalGetValues(this);
			ulong num = Enum.ToUInt64(P_0);
			return Array.BinarySearch(array3, num) >= 0;
		}
		throw new InvalidOperationException("InvalidOperation_UnknownEnumType");
	}

	protected override bool IsByRefImpl()
	{
		return RuntimeTypeHandle.IsByRef(this);
	}

	protected override bool IsPrimitiveImpl()
	{
		return RuntimeTypeHandle.IsPrimitive(this);
	}

	protected override bool IsPointerImpl()
	{
		return RuntimeTypeHandle.IsPointer(this);
	}

	protected override bool IsCOMObjectImpl()
	{
		return RuntimeTypeHandle.IsComObject(this, false);
	}

	public override bool IsInstanceOfType([NotNullWhen(true)] object P_0)
	{
		return RuntimeTypeHandle.IsInstanceOfType(this, P_0);
	}

	public override bool IsAssignableFrom([NotNullWhen(true)] Type P_0)
	{
		if ((object)P_0 == null)
		{
			return false;
		}
		if ((object)P_0 == this)
		{
			return true;
		}
		if (P_0.UnderlyingSystemType is RuntimeType runtimeType)
		{
			return RuntimeTypeHandle.CanCastTo(runtimeType, this);
		}
		if (P_0 is TypeBuilder)
		{
			if (P_0.IsSubclassOf(this))
			{
				return true;
			}
			if (base.IsInterface)
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
		}
		return false;
	}

	private RuntimeType GetBaseType()
	{
		if (base.IsInterface)
		{
			return null;
		}
		if (RuntimeTypeHandle.IsGenericVariable(this))
		{
			Type[] genericParameterConstraints = GetGenericParameterConstraints();
			RuntimeType runtimeType = ObjectType;
			for (int i = 0; i < genericParameterConstraints.Length; i++)
			{
				RuntimeType runtimeType2 = (RuntimeType)genericParameterConstraints[i];
				if (runtimeType2.IsInterface)
				{
					continue;
				}
				if (runtimeType2.IsGenericParameter)
				{
					GenericParameterAttributes genericParameterAttributes = runtimeType2.GenericParameterAttributes & GenericParameterAttributes.SpecialConstraintMask;
					if ((genericParameterAttributes & GenericParameterAttributes.ReferenceTypeConstraint) == 0 && (genericParameterAttributes & GenericParameterAttributes.NotNullableValueTypeConstraint) == 0)
					{
						continue;
					}
				}
				runtimeType = runtimeType2;
			}
			if (runtimeType == ObjectType)
			{
				GenericParameterAttributes genericParameterAttributes2 = GenericParameterAttributes & GenericParameterAttributes.SpecialConstraintMask;
				if ((genericParameterAttributes2 & GenericParameterAttributes.NotNullableValueTypeConstraint) != GenericParameterAttributes.None)
				{
					runtimeType = ValueType;
				}
			}
			return runtimeType;
		}
		return RuntimeTypeHandle.GetBaseType(this);
	}

	private static void ThrowIfTypeNeverValidGenericArgument(RuntimeType P_0)
	{
		if (P_0.IsPointer || P_0.IsByRef || P_0 == typeof(void))
		{
			throw new ArgumentException(SR.Format("Argument_NeverValidGenericArgument", P_0));
		}
	}

	internal static void SanityCheckGenericArguments(RuntimeType[] P_0, RuntimeType[] P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "genericArguments");
		for (int i = 0; i < P_0.Length; i++)
		{
			ArgumentNullException.ThrowIfNull(P_0[i]);
			ThrowIfTypeNeverValidGenericArgument(P_0[i]);
		}
		if (P_0.Length != P_1.Length)
		{
			throw new ArgumentException(SR.Format("Argument_NotEnoughGenArguments", P_0.Length, P_1.Length));
		}
	}
}
