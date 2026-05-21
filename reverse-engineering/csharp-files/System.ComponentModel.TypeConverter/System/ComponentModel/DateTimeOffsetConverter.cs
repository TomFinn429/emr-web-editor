using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace System.ComponentModel;

public class DateTimeOffsetConverter : TypeConverter
{
	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string text)
		{
			string text2 = text.Trim();
			if (text2.Length == 0)
			{
				return DateTimeOffset.MinValue;
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
					return DateTimeOffset.Parse(text2, dateTimeFormatInfo);
				}
				return DateTimeOffset.Parse(text2, P_1);
			}
			catch (FormatException ex)
			{
				throw new FormatException(System.SR.Format("ConvertInvalidPrimitive", (string)P_2, "DateTimeOffset"), ex);
			}
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		if (P_3 == typeof(string) && P_2 is DateTimeOffset dateTimeOffset)
		{
			if (dateTimeOffset == DateTimeOffset.MinValue)
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
				if (dateTimeOffset.TimeOfDay.TotalSeconds == 0.0)
				{
					return dateTimeOffset.ToString("yyyy-MM-dd zzz", P_1);
				}
				return dateTimeOffset.ToString(P_1);
			}
			string text = ((dateTimeOffset.TimeOfDay.TotalSeconds != 0.0) ? (dateTimeFormatInfo.ShortDatePattern + " " + dateTimeFormatInfo.ShortTimePattern + " zzz") : (dateTimeFormatInfo.ShortDatePattern + " zzz"));
			return dateTimeOffset.ToString(text, CultureInfo.CurrentCulture);
		}
		if (P_3 == typeof(InstanceDescriptor) && P_2 is DateTimeOffset dateTimeOffset2)
		{
			if (dateTimeOffset2.Ticks == 0L)
			{
				return new InstanceDescriptor(typeof(DateTimeOffset).GetConstructor(new Type[1] { typeof(long) }), new object[1] { dateTimeOffset2.Ticks });
			}
			return new InstanceDescriptor(typeof(DateTimeOffset).GetConstructor(new Type[8]
			{
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(TimeSpan)
			}), new object[8] { dateTimeOffset2.Year, dateTimeOffset2.Month, dateTimeOffset2.Day, dateTimeOffset2.Hour, dateTimeOffset2.Minute, dateTimeOffset2.Second, dateTimeOffset2.Millisecond, dateTimeOffset2.Offset });
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}
}
