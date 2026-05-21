using System.Globalization;

namespace System.ComponentModel;

public class StringConverter : TypeConverter
{
	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2)
	{
		if (P_2 is string)
		{
			return (string)P_2;
		}
		if (P_2 == null)
		{
			return string.Empty;
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}
}
