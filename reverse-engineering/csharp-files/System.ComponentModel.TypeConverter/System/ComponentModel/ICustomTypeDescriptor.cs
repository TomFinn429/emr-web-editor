using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

public interface ICustomTypeDescriptor
{
	AttributeCollection GetAttributes();

	[RequiresUnreferencedCode("Generic TypeConverters may require the generic types to be annotated. For example, NullableConverter requires the underlying type to be DynamicallyAccessedMembers All.")]
	TypeConverter? GetConverter();
}
