using System.Globalization;

namespace System.ComponentModel;

public abstract class BaseNumberConverter : TypeConverter
{
	internal virtual bool AllowHex => true;

	internal abstract Type TargetType { get; }

	internal BaseNumberConverter()
	{
	}

	internal abstract object FromString(string P_0, int P_1);

	internal abstract object FromString(string P_0, NumberFormatInfo P_1);

	internal abstract string ToString(object P_0, NumberFormatInfo P_1);

	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string text)
		{
			string text2 = text.Trim();
			try
			{
				if (AllowHex && text2[0] == '#')
				{
					return FromString(text2.Substring(1), 16);
				}
				if (AllowHex && (text2.StartsWith("0x", StringComparison.OrdinalIgnoreCase) || text2.StartsWith("&h", StringComparison.OrdinalIgnoreCase)))
				{
					return FromString(text2.Substring(2), 16);
				}
				if (P_1 == null)
				{
					P_1 = CultureInfo.CurrentCulture;
				}
				NumberFormatInfo numberFormatInfo = (NumberFormatInfo)P_1.GetFormat(typeof(NumberFormatInfo));
				return FromString(text2, numberFormatInfo);
			}
			catch (Exception ex)
			{
				throw new ArgumentException(System.SR.Format("ConvertInvalidPrimitive", text2, TargetType.Name), "value", ex);
			}
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		ArgumentNullException.ThrowIfNull(P_3, "destinationType");
		if (P_3 == typeof(string) && P_2 != null && TargetType.IsInstanceOfType(P_2))
		{
			if (P_1 == null)
			{
				P_1 = CultureInfo.CurrentCulture;
			}
			NumberFormatInfo numberFormatInfo = (NumberFormatInfo)P_1.GetFormat(typeof(NumberFormatInfo));
			return ToString(P_2, numberFormatInfo);
		}
		if (P_3.IsPrimitive)
		{
			return Convert.ChangeType(P_2, P_3, P_1);
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}
}
