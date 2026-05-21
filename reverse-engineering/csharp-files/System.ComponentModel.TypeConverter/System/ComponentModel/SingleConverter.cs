using System.Globalization;

namespace System.ComponentModel;

public class SingleConverter : BaseNumberConverter
{
	internal override bool AllowHex => false;

	internal override Type TargetType => typeof(float);

	internal override object FromString(string P_0, int P_1)
	{
		return Convert.ToSingle(P_0, CultureInfo.CurrentCulture);
	}

	internal override object FromString(string P_0, NumberFormatInfo P_1)
	{
		return float.Parse(P_0, NumberStyles.Float, P_1);
	}

	internal override string ToString(object P_0, NumberFormatInfo P_1)
	{
		return ((float)P_0).ToString("R", P_1);
	}
}
