using System.Globalization;

namespace System.ComponentModel;

public class Int64Converter : BaseNumberConverter
{
	internal override Type TargetType => typeof(long);

	internal override object FromString(string P_0, int P_1)
	{
		return Convert.ToInt64(P_0, P_1);
	}

	internal override object FromString(string P_0, NumberFormatInfo P_1)
	{
		return long.Parse(P_0, NumberStyles.Integer, P_1);
	}

	internal override string ToString(object P_0, NumberFormatInfo P_1)
	{
		return ((long)P_0).ToString("G", P_1);
	}
}
