using System.Globalization;

namespace System.ComponentModel;

public class BooleanConverter : TypeConverter
{
	private static volatile StandardValuesCollection s_values;

	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string text)
		{
			string text2 = text.Trim();
			try
			{
				return bool.Parse(text2);
			}
			catch (FormatException ex)
			{
				throw new FormatException(System.SR.Format("ConvertInvalidPrimitive", (string)P_2, "Boolean"), ex);
			}
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext? P_0)
	{
		return s_values ?? (s_values = new StandardValuesCollection(new object[2] { true, false }));
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext? P_0)
	{
		return true;
	}
}
