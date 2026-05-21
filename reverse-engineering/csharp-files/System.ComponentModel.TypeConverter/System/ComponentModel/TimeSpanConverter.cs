using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace System.ComponentModel;

public class TimeSpanConverter : TypeConverter
{
	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string text)
		{
			string input = text.Trim();
			try
			{
				return TimeSpan.Parse(input, P_1);
			}
			catch (FormatException ex)
			{
				throw new FormatException(System.SR.Format("ConvertInvalidPrimitive", (string)P_2, "TimeSpan"), ex);
			}
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		if (P_3 == typeof(InstanceDescriptor) && P_2 is TimeSpan)
		{
			return new InstanceDescriptor(typeof(TimeSpan).GetMethod("Parse", new Type[1] { typeof(string) }), new object[1] { P_2.ToString() });
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}
}
