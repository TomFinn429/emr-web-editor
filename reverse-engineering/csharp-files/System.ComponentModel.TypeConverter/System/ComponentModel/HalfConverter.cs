using System.Globalization;

namespace System.ComponentModel;

public class HalfConverter : BaseNumberConverter
{
	internal override bool AllowHex => false;

	internal override Type TargetType => typeof(Half);

	internal override object FromString(string P_0, int P_1)
	{
		throw new NotImplementedException();
	}

	internal override object FromString(string P_0, NumberFormatInfo P_1)
	{
		return Half.Parse(P_0, P_1);
	}

	internal override string ToString(object P_0, NumberFormatInfo P_1)
	{
		return ((Half)P_0).ToString(P_1);
	}
}
