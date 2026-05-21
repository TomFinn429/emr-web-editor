using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace System.ComponentModel;

public class TimeOnlyConverter : TypeConverter
{
	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string text)
		{
			string text2 = text.Trim();
			if (text2.Length == 0)
			{
				return TimeOnly.MinValue;
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
					return TimeOnly.Parse(text2, dateTimeFormatInfo);
				}
				return TimeOnly.Parse(text2, P_1);
			}
			catch (FormatException ex)
			{
				throw new FormatException(System.SR.Format("ConvertInvalidPrimitive", (string)P_2, "TimeOnly"), ex);
			}
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		if (P_3 == typeof(string) && P_2 is TimeOnly timeOnly)
		{
			if (timeOnly == TimeOnly.MinValue)
			{
				return string.Empty;
			}
			if (P_1 == null)
			{
				P_1 = CultureInfo.CurrentCulture;
			}
			DateTimeFormatInfo dateTimeFormatInfo = (DateTimeFormatInfo)P_1.GetFormat(typeof(DateTimeFormatInfo));
			return timeOnly.ToString(dateTimeFormatInfo.ShortTimePattern, CultureInfo.CurrentCulture);
		}
		if (P_3 == typeof(InstanceDescriptor) && P_2 is TimeOnly timeOnly2)
		{
			if (timeOnly2.Ticks == 0L)
			{
				return new InstanceDescriptor(typeof(TimeOnly).GetConstructor(new Type[1] { typeof(long) }), new object[1] { timeOnly2.Ticks });
			}
			return new InstanceDescriptor(typeof(TimeOnly).GetConstructor(new Type[5]
			{
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int),
				typeof(int)
			}), new object[5] { timeOnly2.Hour, timeOnly2.Minute, timeOnly2.Second, timeOnly2.Millisecond, timeOnly2.Microsecond });
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}
}
