using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

public abstract class CustomTypeDescriptor : ICustomTypeDescriptor
{
	private readonly ICustomTypeDescriptor _parent;

	public virtual AttributeCollection GetAttributes()
	{
		if (_parent != null)
		{
			return _parent.GetAttributes();
		}
		return AttributeCollection.Empty;
	}

	[RequiresUnreferencedCode("Generic TypeConverters may require the generic types to be annotated. For example, NullableConverter requires the underlying type to be DynamicallyAccessedMembers All.")]
	public virtual TypeConverter? GetConverter()
	{
		if (_parent != null)
		{
			return _parent.GetConverter();
		}
		return new TypeConverter();
	}
}
