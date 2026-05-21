using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

[AttributeUsage(AttributeTargets.All)]
public sealed class TypeConverterAttribute : Attribute
{
	public static readonly TypeConverterAttribute Default = new TypeConverterAttribute();

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	public string ConverterTypeName { get; }

	public TypeConverterAttribute()
	{
		ConverterTypeName = string.Empty;
	}

	public TypeConverterAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "typeName");
		ConverterTypeName = P_0;
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (P_0 is TypeConverterAttribute typeConverterAttribute)
		{
			return typeConverterAttribute.ConverterTypeName == ConverterTypeName;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ConverterTypeName.GetHashCode();
	}
}
