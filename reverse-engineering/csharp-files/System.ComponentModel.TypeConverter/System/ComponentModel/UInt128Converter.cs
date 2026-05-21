using System.Globalization;

namespace System.ComponentModel;

public class UInt128Converter : BaseNumberConverter
{
	internal override Type TargetType => typeof(UInt128);

	internal override object FromString(string P_0, int P_1)
	{
		return UInt128.Parse(P_0, NumberStyles.HexNumber);
	}

	internal override object FromString(string P_0, NumberFormatInfo P_1)
	{
		return UInt128.Parse(P_0, P_1);
	}

	internal override string ToString(object P_0, NumberFormatInfo P_1)
	{
		return ((UInt128)P_0).ToString(P_1);
	}
}
