using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

[AttributeUsage(AttributeTargets.All)]
public sealed class ExtenderProvidedPropertyAttribute : Attribute
{
	public PropertyDescriptor? ExtenderProperty { get; }

	public IExtenderProvider? Provider { get; }

	public Type? ReceiverType { get; }

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (P_0 == this)
		{
			return true;
		}
		if (!(P_0 is ExtenderProvidedPropertyAttribute extenderProvidedPropertyAttribute))
		{
			return false;
		}
		if (extenderProvidedPropertyAttribute.ExtenderProperty == null)
		{
			return ExtenderProperty == null;
		}
		if (extenderProvidedPropertyAttribute.ExtenderProperty.Equals(ExtenderProperty) && extenderProvidedPropertyAttribute.Provider.Equals(Provider))
		{
			return extenderProvidedPropertyAttribute.ReceiverType.Equals(ReceiverType);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool IsDefaultAttribute()
	{
		return ReceiverType == null;
	}
}
