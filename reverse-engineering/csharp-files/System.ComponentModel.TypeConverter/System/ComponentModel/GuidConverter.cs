using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace System.ComponentModel;

public class GuidConverter : TypeConverter
{
	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string g)
		{
			return new Guid(g);
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		if (P_3 == typeof(InstanceDescriptor) && P_2 is Guid)
		{
			ConstructorInfo constructor = typeof(Guid).GetConstructor(new Type[1] { typeof(string) });
			return new InstanceDescriptor(constructor, new object[1] { P_2.ToString() });
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}
}
