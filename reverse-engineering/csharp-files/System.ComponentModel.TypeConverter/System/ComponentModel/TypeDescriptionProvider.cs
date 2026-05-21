using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

public abstract class TypeDescriptionProvider
{
	private sealed class EmptyCustomTypeDescriptor : CustomTypeDescriptor
	{
	}

	private readonly TypeDescriptionProvider _parent;

	private EmptyCustomTypeDescriptor _emptyDescriptor;

	public virtual IDictionary? GetCache(object P_0)
	{
		return _parent?.GetCache(P_0);
	}

	[RequiresUnreferencedCode("The Type of instance cannot be statically discovered.")]
	public virtual ICustomTypeDescriptor GetExtendedTypeDescriptor(object P_0)
	{
		if (_parent != null)
		{
			return _parent.GetExtendedTypeDescriptor(P_0);
		}
		return _emptyDescriptor ?? (_emptyDescriptor = new EmptyCustomTypeDescriptor());
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
	public Type GetReflectionType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type P_0)
	{
		return GetReflectionType(P_0, null);
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
	public virtual Type GetReflectionType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type P_0, object? P_1)
	{
		if (_parent != null)
		{
			return _parent.GetReflectionType(P_0, P_1);
		}
		return P_0;
	}

	[RequiresUnreferencedCode("The Type of instance cannot be statically discovered.")]
	public ICustomTypeDescriptor? GetTypeDescriptor(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "instance");
		return GetTypeDescriptor(P_0.GetType(), P_0);
	}

	public virtual ICustomTypeDescriptor? GetTypeDescriptor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0, object? P_1)
	{
		if (_parent != null)
		{
			return _parent.GetTypeDescriptor(P_0, P_1);
		}
		return _emptyDescriptor ?? (_emptyDescriptor = new EmptyCustomTypeDescriptor());
	}
}
