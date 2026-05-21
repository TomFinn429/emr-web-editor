using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Emit;

namespace System.Text.Json.Serialization.Metadata;

[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
internal sealed class ReflectionEmitMemberAccessor : MemberAccessor
{
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
		DynamicMethod dynamicMethod = new DynamicMethod(ConstructorInfo.ConstructorName, JsonTypeInfo.ObjectType, Type.EmptyTypes, typeof(ReflectionEmitMemberAccessor).Module, true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		if (constructor == null)
		{
			LocalBuilder localBuilder = iLGenerator.DeclareLocal(P_0);
			iLGenerator.Emit(OpCodes.Ldloca_S, localBuilder);
			iLGenerator.Emit(OpCodes.Initobj, P_0);
			iLGenerator.Emit(OpCodes.Ldloc, localBuilder);
			iLGenerator.Emit(OpCodes.Box, P_0);
		}
		else
		{
			iLGenerator.Emit(OpCodes.Newobj, constructor);
			if (P_0.IsValueType)
			{
				iLGenerator.Emit(OpCodes.Box, P_0);
			}
		}
		iLGenerator.Emit(OpCodes.Ret);
		return (Func<object>)dynamicMethod.CreateDelegate(typeof(Func<object>));
	}

	public override Func<object[], T> CreateParameterizedConstructor<T>(ConstructorInfo P_0)
	{
		return CreateDelegate<Func<object[], T>>(CreateParameterizedConstructor(P_0));
	}

	private static DynamicMethod CreateParameterizedConstructor(ConstructorInfo P_0)
	{
		Type declaringType = P_0.DeclaringType;
		ParameterInfo[] parameters = P_0.GetParameters();
		int num = parameters.Length;
		if (num > 64)
		{
			return null;
		}
		DynamicMethod dynamicMethod = new DynamicMethod(ConstructorInfo.ConstructorName, declaringType, new Type[1] { typeof(object[]) }, typeof(ReflectionEmitMemberAccessor).Module, true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		for (int i = 0; i < num; i++)
		{
			Type parameterType = parameters[i].ParameterType;
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldc_I4_S, i);
			iLGenerator.Emit(OpCodes.Ldelem_Ref);
			iLGenerator.Emit(OpCodes.Unbox_Any, parameterType);
		}
		iLGenerator.Emit(OpCodes.Newobj, P_0);
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod;
	}

	public override JsonTypeInfo.ParameterizedConstructorDelegate<T, TArg0, TArg1, TArg2, TArg3> CreateParameterizedConstructor<T, TArg0, TArg1, TArg2, TArg3>(ConstructorInfo P_0)
	{
		return CreateDelegate<JsonTypeInfo.ParameterizedConstructorDelegate<T, TArg0, TArg1, TArg2, TArg3>>(CreateParameterizedConstructor(P_0, typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3)));
	}

	private static DynamicMethod CreateParameterizedConstructor(ConstructorInfo P_0, Type P_1, Type P_2, Type P_3, Type P_4)
	{
		Type declaringType = P_0.DeclaringType;
		ParameterInfo[] parameters = P_0.GetParameters();
		int num = parameters.Length;
		DynamicMethod dynamicMethod = new DynamicMethod(ConstructorInfo.ConstructorName, declaringType, new Type[4] { P_1, P_2, P_3, P_4 }, typeof(ReflectionEmitMemberAccessor).Module, true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		for (int i = 0; i < num; i++)
		{
			ILGenerator iLGenerator2 = iLGenerator;
			iLGenerator2.Emit(i switch
			{
				0 => OpCodes.Ldarg_0, 
				1 => OpCodes.Ldarg_1, 
				2 => OpCodes.Ldarg_2, 
				3 => OpCodes.Ldarg_3, 
				_ => throw new InvalidOperationException(), 
			});
		}
		iLGenerator.Emit(OpCodes.Newobj, P_0);
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod;
	}

	public override Action<TCollection, object> CreateAddMethodDelegate<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TCollection>()
	{
		return CreateDelegate<Action<TCollection, object>>(CreateAddMethodDelegate(typeof(TCollection)));
	}

	private static DynamicMethod CreateAddMethodDelegate([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type P_0)
	{
		MethodInfo methodInfo = P_0.GetMethod("Push") ?? P_0.GetMethod("Enqueue");
		DynamicMethod dynamicMethod = new DynamicMethod(methodInfo.Name, typeof(void), new Type[2]
		{
			P_0,
			JsonTypeInfo.ObjectType
		}, typeof(ReflectionEmitMemberAccessor).Module, true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldarg_1);
		iLGenerator.Emit(OpCodes.Callvirt, methodInfo);
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod;
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	[RequiresDynamicCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	public override Func<IEnumerable<TElement>, TCollection> CreateImmutableEnumerableCreateRangeDelegate<TCollection, TElement>()
	{
		return CreateDelegate<Func<IEnumerable<TElement>, TCollection>>(CreateImmutableEnumerableCreateRangeDelegate(typeof(TCollection), typeof(TElement), typeof(IEnumerable<TElement>)));
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	private static DynamicMethod CreateImmutableEnumerableCreateRangeDelegate(Type P_0, Type P_1, Type P_2)
	{
		MethodInfo immutableEnumerableCreateRangeMethod = P_0.GetImmutableEnumerableCreateRangeMethod(P_1);
		DynamicMethod dynamicMethod = new DynamicMethod(immutableEnumerableCreateRangeMethod.Name, P_0, new Type[1] { P_2 }, typeof(ReflectionEmitMemberAccessor).Module, true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Call, immutableEnumerableCreateRangeMethod);
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod;
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	[RequiresDynamicCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	public override Func<IEnumerable<KeyValuePair<TKey, TValue>>, TCollection> CreateImmutableDictionaryCreateRangeDelegate<TCollection, TKey, TValue>()
	{
		return CreateDelegate<Func<IEnumerable<KeyValuePair<TKey, TValue>>, TCollection>>(CreateImmutableDictionaryCreateRangeDelegate(typeof(TCollection), typeof(TKey), typeof(TValue), typeof(IEnumerable<KeyValuePair<TKey, TValue>>)));
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	private static DynamicMethod CreateImmutableDictionaryCreateRangeDelegate(Type P_0, Type P_1, Type P_2, Type P_3)
	{
		MethodInfo immutableDictionaryCreateRangeMethod = P_0.GetImmutableDictionaryCreateRangeMethod(P_1, P_2);
		DynamicMethod dynamicMethod = new DynamicMethod(immutableDictionaryCreateRangeMethod.Name, P_0, new Type[1] { P_3 }, typeof(ReflectionEmitMemberAccessor).Module, true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Call, immutableDictionaryCreateRangeMethod);
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod;
	}

	public override Func<object, TProperty> CreatePropertyGetter<TProperty>(PropertyInfo P_0)
	{
		return CreateDelegate<Func<object, TProperty>>(CreatePropertyGetter(P_0, typeof(TProperty)));
	}

	private static DynamicMethod CreatePropertyGetter(PropertyInfo P_0, Type P_1)
	{
		MethodInfo getMethod = P_0.GetMethod;
		Type declaringType = P_0.DeclaringType;
		Type propertyType = P_0.PropertyType;
		DynamicMethod dynamicMethod = CreateGetterMethod(P_0.Name, P_1);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		if (declaringType.IsValueType)
		{
			iLGenerator.Emit(OpCodes.Unbox, declaringType);
			iLGenerator.Emit(OpCodes.Call, getMethod);
		}
		else
		{
			iLGenerator.Emit(OpCodes.Castclass, declaringType);
			iLGenerator.Emit(OpCodes.Callvirt, getMethod);
		}
		if (propertyType != P_1 && propertyType.IsValueType)
		{
			iLGenerator.Emit(OpCodes.Box, propertyType);
		}
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod;
	}

	public override Action<object, TProperty> CreatePropertySetter<TProperty>(PropertyInfo P_0)
	{
		return CreateDelegate<Action<object, TProperty>>(CreatePropertySetter(P_0, typeof(TProperty)));
	}

	private static DynamicMethod CreatePropertySetter(PropertyInfo P_0, Type P_1)
	{
		MethodInfo setMethod = P_0.SetMethod;
		Type declaringType = P_0.DeclaringType;
		Type propertyType = P_0.PropertyType;
		DynamicMethod dynamicMethod = CreateSetterMethod(P_0.Name, P_1);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(declaringType.IsValueType ? OpCodes.Unbox : OpCodes.Castclass, declaringType);
		iLGenerator.Emit(OpCodes.Ldarg_1);
		if (propertyType != P_1 && propertyType.IsValueType)
		{
			iLGenerator.Emit(OpCodes.Unbox_Any, propertyType);
		}
		iLGenerator.Emit(declaringType.IsValueType ? OpCodes.Call : OpCodes.Callvirt, setMethod);
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod;
	}

	public override Func<object, TProperty> CreateFieldGetter<TProperty>(FieldInfo P_0)
	{
		return CreateDelegate<Func<object, TProperty>>(CreateFieldGetter(P_0, typeof(TProperty)));
	}

	private static DynamicMethod CreateFieldGetter(FieldInfo P_0, Type P_1)
	{
		Type declaringType = P_0.DeclaringType;
		Type fieldType = P_0.FieldType;
		DynamicMethod dynamicMethod = CreateGetterMethod(P_0.Name, P_1);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(declaringType.IsValueType ? OpCodes.Unbox : OpCodes.Castclass, declaringType);
		iLGenerator.Emit(OpCodes.Ldfld, P_0);
		if (fieldType.IsValueType && fieldType != P_1)
		{
			iLGenerator.Emit(OpCodes.Box, fieldType);
		}
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod;
	}

	public override Action<object, TProperty> CreateFieldSetter<TProperty>(FieldInfo P_0)
	{
		return CreateDelegate<Action<object, TProperty>>(CreateFieldSetter(P_0, typeof(TProperty)));
	}

	private static DynamicMethod CreateFieldSetter(FieldInfo P_0, Type P_1)
	{
		Type declaringType = P_0.DeclaringType;
		Type fieldType = P_0.FieldType;
		DynamicMethod dynamicMethod = CreateSetterMethod(P_0.Name, P_1);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(declaringType.IsValueType ? OpCodes.Unbox : OpCodes.Castclass, declaringType);
		iLGenerator.Emit(OpCodes.Ldarg_1);
		if (fieldType != P_1 && fieldType.IsValueType)
		{
			iLGenerator.Emit(OpCodes.Unbox_Any, fieldType);
		}
		iLGenerator.Emit(OpCodes.Stfld, P_0);
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod;
	}

	private static DynamicMethod CreateGetterMethod(string P_0, Type P_1)
	{
		return new DynamicMethod(P_0 + "Getter", P_1, new Type[1] { JsonTypeInfo.ObjectType }, typeof(ReflectionEmitMemberAccessor).Module, true);
	}

	private static DynamicMethod CreateSetterMethod(string P_0, Type P_1)
	{
		return new DynamicMethod(P_0 + "Setter", typeof(void), new Type[2]
		{
			JsonTypeInfo.ObjectType,
			P_1
		}, typeof(ReflectionEmitMemberAccessor).Module, true);
	}

	[return: NotNullIfNotNull("method")]
	private static T CreateDelegate<T>(DynamicMethod P_0) where T : Delegate
	{
		return (T)(P_0?.CreateDelegate(typeof(T)));
	}
}
