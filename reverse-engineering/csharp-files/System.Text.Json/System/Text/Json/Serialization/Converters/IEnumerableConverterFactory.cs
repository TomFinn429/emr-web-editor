using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json.Reflection;

namespace System.Text.Json.Serialization.Converters;

[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
internal sealed class IEnumerableConverterFactory : JsonConverterFactory
{
	private static readonly IDictionaryConverter<IDictionary> s_converterForIDictionary = new IDictionaryConverter<IDictionary>();

	private static readonly IEnumerableConverter<IEnumerable> s_converterForIEnumerable = new IEnumerableConverter<IEnumerable>();

	private static readonly IListConverter<IList> s_converterForIList = new IListConverter<IList>();

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	public IEnumerableConverterFactory()
	{
	}

	public override bool CanConvert(Type P_0)
	{
		return typeof(IEnumerable).IsAssignableFrom(P_0);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The ctor is marked RequiresUnreferencedCode.")]
	public override JsonConverter CreateConverter(Type P_0, JsonSerializerOptions P_1)
	{
		Type type = null;
		Type type2 = null;
		Type typeFromHandle;
		Type compatibleGenericBaseClass;
		if (P_0.IsArray)
		{
			if (P_0.GetArrayRank() > 1)
			{
				ThrowHelper.ThrowNotSupportedException_SerializationNotSupported(P_0);
			}
			typeFromHandle = typeof(ArrayConverter<, >);
			type = P_0.GetElementType();
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericBaseClass(typeof(List<>))) != null)
		{
			typeFromHandle = typeof(ListOfTConverter<, >);
			type = compatibleGenericBaseClass.GetGenericArguments()[0];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericBaseClass(typeof(Dictionary<, >))) != null)
		{
			Type[] genericArguments = compatibleGenericBaseClass.GetGenericArguments();
			typeFromHandle = typeof(DictionaryOfTKeyTValueConverter<, , >);
			type2 = genericArguments[0];
			type = genericArguments[1];
		}
		else if (P_0.IsImmutableDictionaryType())
		{
			Type[] genericArguments = P_0.GetGenericArguments();
			typeFromHandle = typeof(ImmutableDictionaryOfTKeyTValueConverterWithReflection<, , >);
			type2 = genericArguments[0];
			type = genericArguments[1];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericInterface(typeof(IDictionary<, >))) != null)
		{
			Type[] genericArguments = compatibleGenericBaseClass.GetGenericArguments();
			typeFromHandle = typeof(IDictionaryOfTKeyTValueConverter<, , >);
			type2 = genericArguments[0];
			type = genericArguments[1];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericInterface(typeof(IReadOnlyDictionary<, >))) != null)
		{
			Type[] genericArguments = compatibleGenericBaseClass.GetGenericArguments();
			typeFromHandle = typeof(IReadOnlyDictionaryOfTKeyTValueConverter<, , >);
			type2 = genericArguments[0];
			type = genericArguments[1];
		}
		else if (P_0.IsImmutableEnumerableType())
		{
			typeFromHandle = typeof(ImmutableEnumerableOfTConverterWithReflection<, >);
			type = P_0.GetGenericArguments()[0];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericInterface(typeof(IList<>))) != null)
		{
			typeFromHandle = typeof(IListOfTConverter<, >);
			type = compatibleGenericBaseClass.GetGenericArguments()[0];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericInterface(typeof(ISet<>))) != null)
		{
			typeFromHandle = typeof(ISetOfTConverter<, >);
			type = compatibleGenericBaseClass.GetGenericArguments()[0];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericInterface(typeof(ICollection<>))) != null)
		{
			typeFromHandle = typeof(ICollectionOfTConverter<, >);
			type = compatibleGenericBaseClass.GetGenericArguments()[0];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericBaseClass(typeof(Stack<>))) != null)
		{
			typeFromHandle = typeof(StackOfTConverter<, >);
			type = compatibleGenericBaseClass.GetGenericArguments()[0];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericBaseClass(typeof(Queue<>))) != null)
		{
			typeFromHandle = typeof(QueueOfTConverter<, >);
			type = compatibleGenericBaseClass.GetGenericArguments()[0];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericBaseClass(typeof(ConcurrentStack<>))) != null)
		{
			typeFromHandle = typeof(ConcurrentStackOfTConverter<, >);
			type = compatibleGenericBaseClass.GetGenericArguments()[0];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericBaseClass(typeof(ConcurrentQueue<>))) != null)
		{
			typeFromHandle = typeof(ConcurrentQueueOfTConverter<, >);
			type = compatibleGenericBaseClass.GetGenericArguments()[0];
		}
		else if ((compatibleGenericBaseClass = P_0.GetCompatibleGenericInterface(typeof(IEnumerable<>))) != null)
		{
			typeFromHandle = typeof(IEnumerableOfTConverter<, >);
			type = compatibleGenericBaseClass.GetGenericArguments()[0];
		}
		else if (typeof(IDictionary).IsAssignableFrom(P_0))
		{
			if (P_0 == typeof(IDictionary))
			{
				return s_converterForIDictionary;
			}
			typeFromHandle = typeof(IDictionaryConverter<>);
		}
		else if (typeof(IList).IsAssignableFrom(P_0))
		{
			if (P_0 == typeof(IList))
			{
				return s_converterForIList;
			}
			typeFromHandle = typeof(IListConverter<>);
		}
		else if (P_0.IsNonGenericStackOrQueue())
		{
			typeFromHandle = typeof(StackOrQueueConverterWithReflection<>);
		}
		else
		{
			if (P_0 == typeof(IEnumerable))
			{
				return s_converterForIEnumerable;
			}
			typeFromHandle = typeof(IEnumerableConverter<>);
		}
		return (JsonConverter)Activator.CreateInstance(typeFromHandle.GetGenericArguments().Length switch
		{
			1 => typeFromHandle.MakeGenericType(P_0), 
			2 => typeFromHandle.MakeGenericType(P_0, type), 
			_ => typeFromHandle.MakeGenericType(P_0, type2, type), 
		}, BindingFlags.Instance | BindingFlags.Public, null, null, null);
	}
}
