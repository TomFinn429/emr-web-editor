using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace System.ComponentModel;

public class DecimalConverter : BaseNumberConverter
{
	internal override bool AllowHex => false;

	internal override Type TargetType => typeof(decimal);

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		if (P_3 == typeof(InstanceDescriptor) && P_2 is decimal num)
		{
			ConstructorInfo constructor = typeof(decimal).GetConstructor(new Type[1] { typeof(int[]) });
			return new InstanceDescriptor(constructor, new object[1] { decimal.GetBits(num) });
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}

	internal override object FromString(string P_0, int P_1)
	{
		return Convert.ToDecimal(P_0, CultureInfo.CurrentCulture);
	}

	internal override object FromString(string P_0, NumberFormatInfo P_1)
	{
		return decimal.Parse(P_0, NumberStyles.Float, P_1);
	}

	internal override string ToString(object P_0, NumberFormatInfo P_1)
	{
		return ((decimal)P_0).ToString("G", P_1);
	}
}
