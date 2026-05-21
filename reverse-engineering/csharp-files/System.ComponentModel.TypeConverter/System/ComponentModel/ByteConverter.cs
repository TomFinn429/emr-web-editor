using System.Globalization;

namespace System.ComponentModel;

public class ByteConverter : BaseNumberConverter
{
	internal override Type TargetType => typeof(byte);

	internal override object FromString(string P_0, int P_1)
	{
		return Convert.ToByte(P_0, P_1);
	}

	internal override object FromString(string P_0, NumberFormatInfo P_1)
	{
		return byte.Parse(P_0, NumberStyles.Integer, P_1);
	}

	internal override string ToString(object P_0, NumberFormatInfo P_1)
	{
		return ((byte)P_0).ToString("G", P_1);
	}
}
