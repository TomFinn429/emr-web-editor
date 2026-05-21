using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

internal sealed class DelegatingTypeDescriptionProvider : TypeDescriptionProvider
{
	private readonly Type _type;

	internal TypeDescriptionProvider Provider => TypeDescriptor.GetProviderRecursive(_type);

	internal DelegatingTypeDescriptionProvider(Type P_0)
	{
		_type = P_0;
	}

	public override IDictionary GetCache(object P_0)
	{
		return Provider.GetCache(P_0);
	}

	[RequiresUnreferencedCode("The Type of instance cannot be statically discovered.")]
	public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object P_0)
	{
		return Provider.GetExtendedTypeDescriptor(P_0);
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
	public override Type GetReflectionType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type P_0, object P_1)
	{
		return Provider.GetReflectionType(P_0, P_1);
	}

	public override ICustomTypeDescriptor GetTypeDescriptor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0, object P_1)
	{
		return Provider.GetTypeDescriptor(P_0, P_1);
	}
}
