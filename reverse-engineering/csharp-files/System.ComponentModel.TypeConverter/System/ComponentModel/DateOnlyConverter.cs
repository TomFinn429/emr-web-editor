using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace System.ComponentModel;

public class DateOnlyConverter : TypeConverter
{
	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string text)
		{
			string text2 = text.Trim();
			if (text2.Length == 0)
			{
				return DateOnly.MinValue;
			}
			try
			{
				DateTimeFormatInfo dateTimeFormatInfo = null;
				if (P_1 != null)
				{
					dateTimeFormatInfo = (DateTimeFormatInfo)P_1.GetFormat(typeof(DateTimeFormatInfo));
				}
				if (dateTimeFormatInfo != null)
				{
					return DateOnly.Parse(text2, dateTimeFormatInfo);
				}
				return DateOnly.Parse(text2, P_1);
			}
			catch (FormatException ex)
			{
				throw new FormatException(System.SR.Format("ConvertInvalidPrimitive", (string)P_2, "DateOnly"), ex);
			}
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		if (P_3 == typeof(string) && P_2 is DateOnly dateOnly)
		{
			if (dateOnly == DateOnly.MinValue)
			{
				return string.Empty;
			}
			if (P_1 == null)
			{
				P_1 = CultureInfo.CurrentCulture;
			}
			DateTimeFormatInfo dateTimeFormatInfo = (DateTimeFormatInfo)P_1.GetFormat(typeof(DateTimeFormatInfo));
			if (P_1 == CultureInfo.InvariantCulture)
			{
				return dateOnly.ToString("yyyy-MM-dd", P_1);
			}
			string shortDatePattern = dateTimeFormatInfo.ShortDatePattern;
			return dateOnly.ToString(shortDatePattern, CultureInfo.CurrentCulture);
		}
		if (P_3 == typeof(InstanceDescriptor) && P_2 is DateOnly dateOnly2)
		{
			return new InstanceDescriptor(typeof(DateOnly).GetConstructor(new Type[3]
			{
				typeof(int),
				typeof(int),
				typeof(int)
			}), new object[3] { dateOnly2.Year, dateOnly2.Month, dateOnly2.Day });
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}
}
