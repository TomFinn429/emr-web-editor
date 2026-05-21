using System.Globalization;

namespace System.ComponentModel;

public class ArrayConverter : CollectionConverter
{
	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		if (P_3 == typeof(string) && P_2 is Array)
		{
			return $"{P_2.GetType().Name} Array";
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}
}
