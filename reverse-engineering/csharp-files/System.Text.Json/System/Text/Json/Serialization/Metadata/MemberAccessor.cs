using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace System.Text.Json.Serialization.Metadata;

internal abstract class MemberAccessor
{
	public abstract Func<object> CreateConstructor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type P_0);

	public abstract Func<object[], T> CreateParameterizedConstructor<T>(ConstructorInfo P_0);

	public abstract JsonTypeInfo.ParameterizedConstructorDelegate<T, TArg0, TArg1, TArg2, TArg3> CreateParameterizedConstructor<T, TArg0, TArg1, TArg2, TArg3>(ConstructorInfo P_0);

	public abstract Action<TCollection, object> CreateAddMethodDelegate<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TCollection>();

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	[RequiresDynamicCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	public abstract Func<IEnumerable<TElement>, TCollection> CreateImmutableEnumerableCreateRangeDelegate<TCollection, TElement>();

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	[RequiresDynamicCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	public abstract Func<IEnumerable<KeyValuePair<TKey, TValue>>, TCollection> CreateImmutableDictionaryCreateRangeDelegate<TCollection, TKey, TValue>();

	public abstract Func<object, TProperty> CreatePropertyGetter<TProperty>(PropertyInfo P_0);

	public abstract Action<object, TProperty> CreatePropertySetter<TProperty>(PropertyInfo P_0);

	public abstract Func<object, TProperty> CreateFieldGetter<TProperty>(FieldInfo P_0);

	public abstract Action<object, TProperty> CreateFieldSetter<TProperty>(FieldInfo P_0);
}
