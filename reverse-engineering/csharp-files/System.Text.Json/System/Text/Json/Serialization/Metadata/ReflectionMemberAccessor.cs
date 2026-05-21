using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace System.Text.Json.Serialization.Metadata;

internal sealed class ReflectionMemberAccessor : MemberAccessor
{
	private sealed class ConstructorContext
	{
		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
		private readonly Type _type;

		public ConstructorContext([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type P_0)
		{
			_type = P_0;
		}

		public object CreateInstance()
		{
			return Activator.CreateInstance(_type, false);
		}
	}

	public override Func<object> CreateConstructor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type P_0)
	{
		ConstructorInfo constructor = P_0.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, Type.EmptyTypes, null);
		if (P_0.IsAbstract)
		{
			return null;
		}
		if (constructor == null && !P_0.IsValueType)
		{
			return null;
		}
		return new ConstructorContext(P_0).CreateInstance;
	}

	public override Func<object[], T> CreateParameterizedConstructor<T>(ConstructorInfo P_0)
	{
		Type typeFromHandle = typeof(T);
		int parameterCount = P_0.GetParameters().Length;
		if (parameterCount > 64)
		{
			return null;
		}
		return delegate(object[] array2)
		{
			object[] array = new object[parameterCount];
			for (int i = 0; i < parameterCount; i++)
			{
				array[i] = array2[i];
			}
			try
			{
				return (T)P_0.Invoke(array);
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException ?? ex;
			}
		};
	}

	public override JsonTypeInfo.ParameterizedConstructorDelegate<T, TArg0, TArg1, TArg2, TArg3> CreateParameterizedConstructor<T, TArg0, TArg1, TArg2, TArg3>(ConstructorInfo P_0)
	{
		Type typeFromHandle = typeof(T);
		int parameterCount = P_0.GetParameters().Length;
		return delegate(TArg0 val4, TArg1 val3, TArg2 val2, TArg3 val)
		{
			object[] array = new object[parameterCount];
			for (int i = 0; i < parameterCount; i++)
			{
				switch (i)
				{
				case 0:
					array[0] = val4;
					break;
				case 1:
					array[1] = val3;
					break;
				case 2:
					array[2] = val2;
					break;
				case 3:
					array[3] = val;
					break;
				default:
					throw new InvalidOperationException();
				}
			}
			return (T)P_0.Invoke(array);
		};
	}

	public override Action<TCollection, object> CreateAddMethodDelegate<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TCollection>()
	{
		Type typeFromHandle = typeof(TCollection);
		Type objectType = JsonTypeInfo.ObjectType;
		MethodInfo addMethod = typeFromHandle.GetMethod("Push") ?? typeFromHandle.GetMethod("Enqueue");
		return delegate(TCollection P_0, object P_1)
		{
			addMethod.Invoke(P_0, new object[1] { P_1 });
		};
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	[RequiresDynamicCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	public override Func<IEnumerable<TElement>, TCollection> CreateImmutableEnumerableCreateRangeDelegate<TCollection, TElement>()
	{
		MethodInfo immutableEnumerableCreateRangeMethod = typeof(TCollection).GetImmutableEnumerableCreateRangeMethod(typeof(TElement));
		return (Func<IEnumerable<TElement>, TCollection>)immutableEnumerableCreateRangeMethod.CreateDelegate(typeof(Func<IEnumerable<TElement>, TCollection>));
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	[RequiresDynamicCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	public override Func<IEnumerable<KeyValuePair<TKey, TValue>>, TCollection> CreateImmutableDictionaryCreateRangeDelegate<TCollection, TKey, TValue>()
	{
		MethodInfo immutableDictionaryCreateRangeMethod = typeof(TCollection).GetImmutableDictionaryCreateRangeMethod(typeof(TKey), typeof(TValue));
		return (Func<IEnumerable<KeyValuePair<TKey, TValue>>, TCollection>)immutableDictionaryCreateRangeMethod.CreateDelegate(typeof(Func<IEnumerable<KeyValuePair<TKey, TValue>>, TCollection>));
	}

	public override Func<object, TProperty> CreatePropertyGetter<TProperty>(PropertyInfo P_0)
	{
		MethodInfo getMethodInfo = P_0.GetMethod;
		return (object obj) => (TProperty)getMethodInfo.Invoke(obj, null);
	}

	public override Action<object, TProperty> CreatePropertySetter<TProperty>(PropertyInfo P_0)
	{
		MethodInfo setMethodInfo = P_0.SetMethod;
		return delegate(object obj, TProperty val)
		{
			setMethodInfo.Invoke(obj, new object[1] { val });
		};
	}

	public override Func<object, TProperty> CreateFieldGetter<TProperty>(FieldInfo P_0)
	{
		return (object obj) => (TProperty)P_0.GetValue(obj);
	}

	public override Action<object, TProperty> CreateFieldSetter<TProperty>(FieldInfo P_0)
	{
		return delegate(object obj, TProperty val)
		{
			P_0.SetValue(obj, val);
		};
	}
}
