using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace System.Text.Json.Serialization.Metadata;

internal sealed class FSharpCoreReflectionProxy
{
	public enum FSharpKind
	{
		Unrecognized,
		Option,
		ValueOption,
		List,
		Set,
		Map,
		Record,
		Union
	}

	public delegate TResult StructGetter<TStruct, TResult>(ref TStruct P_0) where TStruct : struct;

	private enum SourceConstructFlags
	{
		None = 0,
		SumType = 1,
		RecordType = 2,
		ObjectType = 3,
		Field = 4,
		Exception = 5,
		Closure = 6,
		Module = 7,
		UnionCase = 8,
		Value = 9,
		KindMask = 31,
		NonPublicRepresentation = 32
	}

	private static FSharpCoreReflectionProxy s_singletonInstance;

	private readonly Type _compilationMappingAttributeType;

	private readonly MethodInfo _sourceConstructFlagsGetter;

	private readonly Type _fsharpOptionType;

	private readonly Type _fsharpValueOptionType;

	private readonly Type _fsharpListType;

	private readonly Type _fsharpSetType;

	private readonly Type _fsharpMapType;

	private readonly MethodInfo _fsharpListCtor;

	private readonly MethodInfo _fsharpSetCtor;

	private readonly MethodInfo _fsharpMapCtor;

	public static FSharpCoreReflectionProxy Instance => s_singletonInstance;

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public static bool IsFSharpType(Type P_0)
	{
		if (s_singletonInstance == null)
		{
			Assembly fSharpCoreAssembly = GetFSharpCoreAssembly(P_0);
			if ((object)fSharpCoreAssembly != null)
			{
				if (s_singletonInstance == null)
				{
					s_singletonInstance = new FSharpCoreReflectionProxy(fSharpCoreAssembly);
				}
				return true;
			}
			return false;
		}
		return s_singletonInstance.GetFSharpCompilationMappingAttribute(P_0) != null;
	}

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	private FSharpCoreReflectionProxy(Assembly P_0)
	{
		Type type = P_0.GetType("Microsoft.FSharp.Core.CompilationMappingAttribute");
		_sourceConstructFlagsGetter = type.GetMethod("get_SourceConstructFlags", BindingFlags.Instance | BindingFlags.Public);
		_compilationMappingAttributeType = type;
		_fsharpOptionType = P_0.GetType("Microsoft.FSharp.Core.FSharpOption`1");
		_fsharpValueOptionType = P_0.GetType("Microsoft.FSharp.Core.FSharpValueOption`1");
		_fsharpListType = P_0.GetType("Microsoft.FSharp.Collections.FSharpList`1");
		_fsharpSetType = P_0.GetType("Microsoft.FSharp.Collections.FSharpSet`1");
		_fsharpMapType = P_0.GetType("Microsoft.FSharp.Collections.FSharpMap`2");
		_fsharpListCtor = P_0.GetType("Microsoft.FSharp.Collections.ListModule")?.GetMethod("OfSeq", BindingFlags.Static | BindingFlags.Public);
		_fsharpSetCtor = P_0.GetType("Microsoft.FSharp.Collections.SetModule")?.GetMethod("OfSeq", BindingFlags.Static | BindingFlags.Public);
		_fsharpMapCtor = P_0.GetType("Microsoft.FSharp.Collections.MapModule")?.GetMethod("OfSeq", BindingFlags.Static | BindingFlags.Public);
	}

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public FSharpKind DetectFSharpKind(Type P_0)
	{
		Attribute fSharpCompilationMappingAttribute = GetFSharpCompilationMappingAttribute(P_0);
		if (fSharpCompilationMappingAttribute == null)
		{
			return FSharpKind.Unrecognized;
		}
		if (P_0.IsGenericType)
		{
			Type genericTypeDefinition = P_0.GetGenericTypeDefinition();
			if (genericTypeDefinition == _fsharpOptionType)
			{
				return FSharpKind.Option;
			}
			if (genericTypeDefinition == _fsharpValueOptionType)
			{
				return FSharpKind.ValueOption;
			}
			if (genericTypeDefinition == _fsharpListType)
			{
				return FSharpKind.List;
			}
			if (genericTypeDefinition == _fsharpSetType)
			{
				return FSharpKind.Set;
			}
			if (genericTypeDefinition == _fsharpMapType)
			{
				return FSharpKind.Map;
			}
		}
		return (GetSourceConstructFlags(fSharpCompilationMappingAttribute) & SourceConstructFlags.KindMask) switch
		{
			SourceConstructFlags.RecordType => FSharpKind.Record, 
			SourceConstructFlags.SumType => FSharpKind.Union, 
			_ => FSharpKind.Unrecognized, 
		};
	}

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public Func<TFSharpOption, T> CreateFSharpOptionValueGetter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TFSharpOption, T>()
	{
		MethodInfo methodInfo = EnsureMemberExists(typeof(TFSharpOption).GetMethod("get_Value", BindingFlags.Instance | BindingFlags.Public), "Microsoft.FSharp.Core.FSharpOption<T>.get_Value()");
		return CreateDelegate<Func<TFSharpOption, T>>(methodInfo);
	}

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public Func<TElement, TFSharpOption> CreateFSharpOptionSomeConstructor<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TFSharpOption, TElement>()
	{
		MethodInfo methodInfo = EnsureMemberExists(typeof(TFSharpOption).GetMethod("Some", BindingFlags.Static | BindingFlags.Public), "Microsoft.FSharp.Core.FSharpOption<T>.Some(T value)");
		return CreateDelegate<Func<TElement, TFSharpOption>>(methodInfo);
	}

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public StructGetter<TFSharpValueOption, TElement> CreateFSharpValueOptionValueGetter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TFSharpValueOption, TElement>() where TFSharpValueOption : struct
	{
		MethodInfo methodInfo = EnsureMemberExists(typeof(TFSharpValueOption).GetMethod("get_Value", BindingFlags.Instance | BindingFlags.Public), "Microsoft.FSharp.Core.FSharpValueOption<T>.get_Value()");
		return CreateDelegate<StructGetter<TFSharpValueOption, TElement>>(methodInfo);
	}

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public Func<TElement, TFSharpOption> CreateFSharpValueOptionSomeConstructor<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TFSharpOption, TElement>()
	{
		MethodInfo methodInfo = EnsureMemberExists(typeof(TFSharpOption).GetMethod("Some", BindingFlags.Static | BindingFlags.Public), "Microsoft.FSharp.Core.FSharpValueOption<T>.ValueSome(T value)");
		return CreateDelegate<Func<TElement, TFSharpOption>>(methodInfo);
	}

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public Func<IEnumerable<TElement>, TFSharpList> CreateFSharpListConstructor<TFSharpList, TElement>()
	{
		return CreateDelegate<Func<IEnumerable<TElement>, TFSharpList>>(EnsureMemberExists(_fsharpListCtor, "Microsoft.FSharp.Collections.ListModule.OfSeq<T>(IEnumerable<T> source)").MakeGenericMethod(typeof(TElement)));
	}

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public Func<IEnumerable<TElement>, TFSharpSet> CreateFSharpSetConstructor<TFSharpSet, TElement>()
	{
		return CreateDelegate<Func<IEnumerable<TElement>, TFSharpSet>>(EnsureMemberExists(_fsharpSetCtor, "Microsoft.FSharp.Collections.SetModule.OfSeq<T>(IEnumerable<T> source)").MakeGenericMethod(typeof(TElement)));
	}

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public Func<IEnumerable<Tuple<TKey, TValue>>, TFSharpMap> CreateFSharpMapConstructor<TFSharpMap, TKey, TValue>()
	{
		return CreateDelegate<Func<IEnumerable<Tuple<TKey, TValue>>, TFSharpMap>>(EnsureMemberExists(_fsharpMapCtor, "Microsoft.FSharp.Collections.MapModule.OfSeq<TKey, TValue>(IEnumerable<Tuple<TKey, TValue>> source)").MakeGenericMethod(typeof(TKey), typeof(TValue)));
	}

	private Attribute GetFSharpCompilationMappingAttribute(Type P_0)
	{
		return P_0.GetCustomAttribute(_compilationMappingAttributeType, true);
	}

	private SourceConstructFlags GetSourceConstructFlags(Attribute P_0)
	{
		if ((object)_sourceConstructFlagsGetter != null)
		{
			return (SourceConstructFlags)_sourceConstructFlagsGetter.Invoke(P_0, null);
		}
		return SourceConstructFlags.None;
	}

	private static Assembly GetFSharpCoreAssembly(Type P_0)
	{
		object[] customAttributes = P_0.GetCustomAttributes(true);
		for (int i = 0; i < customAttributes.Length; i++)
		{
			Attribute attribute = (Attribute)customAttributes[i];
			Type type = attribute.GetType();
			if (type.FullName == "Microsoft.FSharp.Core.CompilationMappingAttribute")
			{
				return type.Assembly;
			}
		}
		return null;
	}

	private static TDelegate CreateDelegate<TDelegate>(MethodInfo P_0) where TDelegate : Delegate
	{
		return (TDelegate)Delegate.CreateDelegate(typeof(TDelegate), P_0, true);
	}

	private static TMemberInfo EnsureMemberExists<TMemberInfo>(TMemberInfo P_0, string P_1) where TMemberInfo : MemberInfo
	{
		if ((object)P_0 == null)
		{
			ThrowHelper.ThrowMissingMemberException_MissingFSharpCoreMember(P_1);
		}
		return P_0;
	}
}
