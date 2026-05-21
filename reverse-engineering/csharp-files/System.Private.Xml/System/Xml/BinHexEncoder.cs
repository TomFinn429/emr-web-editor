namespace System.Xml;

internal static class BinHexEncoder
{
	internal static string Encode(byte[] P_0, int P_1, int P_2)
	{
		return Convert.ToHexString(P_0, P_1, P_2);
	}
}
