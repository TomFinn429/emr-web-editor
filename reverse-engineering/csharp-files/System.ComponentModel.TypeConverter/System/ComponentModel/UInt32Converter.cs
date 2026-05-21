using System.Globalization;

namespace System.ComponentModel;

public class UInt32Converter : BaseNumberConverter
{
	internal override Type TargetType => typeof(uint);

	internal override object FromString(string P_0, int P_1)
	{
		return Convert.ToUInt32(P_0, P_1);
	}

	internal override object FromString(string P_0, NumberFormatInfo P_1)
	{
		return uint.Parse(P_0, NumberStyles.Integer, P_1);
	}

	internal override string ToString(object P_0, NumberFormatInfo P_1)
	{
		return ((uint)P_0).ToString("G", P_1);
	}
}
