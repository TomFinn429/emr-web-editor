using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace System.ComponentModel;

public class DateTimeConverter : TypeConverter
{
	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string text)
		{
			string text2 = text.Trim();
			if (text2.Length == 0)
			{
				return DateTime.MinValue;
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
					return DateTime.Parse(text2, dateTimeFormatInfo);
				}
				return DateTime.Parse(text2, P_1);
			}
			catch (FormatException ex)
			{
				throw new FormatException(System.SR.Format("ConvertInvalidPrimitive", (string)P_2, "DateTime"), ex);
			}
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		if (P_3 == typeof(string) && P_2 is DateTime dateTime)
		{
			if (dateTime == DateTime.MinValue)
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
				if (dateTime.TimeOfDay.TotalSeconds == 0.0)
				{
					return dateTime.ToString("yyyy-MM-dd", P_1);
				}
				return dateTime.ToString(P_1);
			}
			string text = ((dateTime.TimeOfDay.TotalSeconds != 0.0) ? (dateTimeFormatInfo.ShortDatePattern + " " + dateTimeFormatInfo.ShortTimePattern) : dateTimeFormatInfo.ShortDatePattern);
			return dateTime.ToString(text, CultureInfo.CurrentCulture);
		}
		if (P_3 == typeof(InstanceDescriptor) && P_2 is DateTime dateTime2)
		{
			if (dateTime2.Ticks == 0L)
			{
				return new InstanceDescriptor(typeof(DateTime).GetConstructor(new Type[1] { typeof(long) }), new object[1] { dateTime2.Ticks });
			}
			return new InstanceDescriptor(typeof(DateTime).GetConstructor(new Type[7]
			{
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int)
			}), new object[7] { dateTime2.Year, dateTime2.Month, dateTime2.Day, dateTime2.Hour, dateTime2.Minute, dateTime2.Second, dateTime2.Millisecond });
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}
}
