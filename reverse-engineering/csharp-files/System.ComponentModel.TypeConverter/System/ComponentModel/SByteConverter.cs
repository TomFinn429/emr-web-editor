using System.Globalization;

namespace System.ComponentModel;

public class SByteConverter : BaseNumberConverter
{
	internal override Type TargetType => typeof(sbyte);

	internal override object FromString(string P_0, int P_1)
	{
		return Convert.ToSByte(P_0, P_1);
	}

	internal override object FromString(string P_0, NumberFormatInfo P_1)
	{
		return sbyte.Parse(P_0, NumberStyles.Integer, P_1);
	}

	internal override string ToString(object P_0, NumberFormatInfo P_1)
	{
		return ((sbyte)P_0).ToString("G", P_1);
	}
}
