using System.Globalization;

namespace System.ComponentModel;

public class Int16Converter : BaseNumberConverter
{
	internal override Type TargetType => typeof(short);

	internal override object FromString(string P_0, int P_1)
	{
		return Convert.ToInt16(P_0, P_1);
	}

	internal override object FromString(string P_0, NumberFormatInfo P_1)
	{
		return short.Parse(P_0, NumberStyles.Integer, P_1);
	}

	internal override string ToString(object P_0, NumberFormatInfo P_1)
	{
		return ((short)P_0).ToString("G", P_1);
	}
}
