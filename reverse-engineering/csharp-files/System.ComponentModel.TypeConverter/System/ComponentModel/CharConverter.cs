using System.Globalization;

namespace System.ComponentModel;

public class CharConverter : TypeConverter
{
	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		if (P_3 == typeof(string) && P_2 is char && (char)P_2 == '\0')
		{
			return string.Empty;
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}

	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		string text = P_2 as string;
		if (text != null)
		{
			if (text.Length > 1)
			{
				text = text.Trim();
			}
			if (text.Length > 0)
			{
				if (text.Length != 1)
				{
					throw new FormatException(System.SR.Format("ConvertInvalidPrimitive", text, "Char"));
				}
				return text[0];
			}
			return '\0';
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}
}
