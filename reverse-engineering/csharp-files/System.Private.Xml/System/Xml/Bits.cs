namespace System.Xml;

internal static class Bits
{
	public static int Count(uint P_0)
	{
		P_0 = (P_0 & 0x55555555) + ((P_0 >> 1) & 0x55555555);
		P_0 = (P_0 & 0x33333333) + ((P_0 >> 2) & 0x33333333);
		P_0 = (P_0 & 0xF0F0F0F) + ((P_0 >> 4) & 0xF0F0F0F);
		P_0 = (P_0 & 0xFF00FF) + ((P_0 >> 8) & 0xFF00FF);
		P_0 = (P_0 & 0xFFFF) + (P_0 >> 16);
		return (int)P_0;
	}

	public static int LeastPosition(uint P_0)
	{
		if (P_0 == 0)
		{
			return 0;
		}
		return Count(P_0 ^ (P_0 - 1));
	}
}
