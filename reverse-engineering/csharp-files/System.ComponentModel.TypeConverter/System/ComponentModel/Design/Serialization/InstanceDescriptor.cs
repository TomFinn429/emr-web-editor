using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.ComponentModel.Design.Serialization;

public sealed class InstanceDescriptor
{
	[CompilerGenerated]
	private readonly bool _003CIsComplete_003Ek__BackingField;

	public ICollection Arguments { get; }

	public MemberInfo? MemberInfo { get; }

	public InstanceDescriptor(MemberInfo? P_0, ICollection? P_1)
		: this(P_0, P_1, true)
	{
	}

	public InstanceDescriptor(MemberInfo? P_0, ICollection? P_1, bool P_2)
	{
		MemberInfo = P_0;
		_003CIsComplete_003Ek__BackingField = P_2;
		if (P_1 == null)
		{
			Arguments = Array.Empty<object>();
		}
		else
		{
			object[] array = new object[P_1.Count];
			P_1.CopyTo(array, 0);
			Arguments = array;
		}
		if (P_0 is FieldInfo fieldInfo)
		{
			if (!fieldInfo.IsStatic)
			{
				throw new ArgumentException("InstanceDescriptorMustBeStatic");
			}
			if (Arguments.Count != 0)
			{
				throw new ArgumentException("InstanceDescriptorLengthMismatch");
			}
		}
		else if (P_0 is ConstructorInfo constructorInfo)
		{
			if (constructorInfo.IsStatic)
			{
				throw new ArgumentException("InstanceDescriptorCannotBeStatic");
			}
			if (Arguments.Count != constructorInfo.GetParameters().Length)
			{
				throw new ArgumentException("InstanceDescriptorLengthMismatch");
			}
		}
		else if (P_0 is MethodInfo methodInfo)
		{
			if (!methodInfo.IsStatic)
			{
				throw new ArgumentException("InstanceDescriptorMustBeStatic");
			}
			if (Arguments.Count != methodInfo.GetParameters().Length)
			{
				throw new ArgumentException("InstanceDescriptorLengthMismatch");
			}
		}
		else if (P_0 is PropertyInfo propertyInfo)
		{
			if (!propertyInfo.CanRead)
			{
				throw new ArgumentException("InstanceDescriptorMustBeReadable");
			}
			MethodInfo getMethod = propertyInfo.GetGetMethod();
			if (getMethod != null && !getMethod.IsStatic)
			{
				throw new ArgumentException("InstanceDescriptorMustBeStatic");
			}
		}
	}

	public object? Invoke()
	{
		object[] array = new object[Arguments.Count];
		Arguments.CopyTo(array, 0);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] is InstanceDescriptor instanceDescriptor)
			{
				array[i] = instanceDescriptor.Invoke();
			}
		}
		if (MemberInfo is ConstructorInfo)
		{
			return ((ConstructorInfo)MemberInfo).Invoke(array);
		}
		if (MemberInfo is MethodInfo)
		{
			return ((MethodInfo)MemberInfo).Invoke(null, array);
		}
		if (MemberInfo is PropertyInfo)
		{
			return ((PropertyInfo)MemberInfo).GetValue(null, array);
		}
		if (MemberInfo is FieldInfo)
		{
			return ((FieldInfo)MemberInfo).GetValue(null);
		}
		return null;
	}
}
