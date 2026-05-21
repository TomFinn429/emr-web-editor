using System.Globalization;

namespace System.ComponentModel;

public class Int32Converter : BaseNumberConverter
{
	internal override Type TargetType => typeof(int);

	internal override object FromString(string P_0, int P_1)
	{
		return Convert.ToInt32(P_0, P_1);
	}

	internal override object FromString(string P_0, NumberFormatInfo P_1)
	{
		return int.Parse(P_0, NumberStyles.Integer, P_1);
	}

	internal override string ToString(object P_0, NumberFormatInfo P_1)
	{
		return ((int)P_0).ToString("G", P_1);
	}
}
