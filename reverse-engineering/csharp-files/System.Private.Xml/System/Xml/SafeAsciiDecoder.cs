using System.Text;

namespace System.Xml;

internal sealed class SafeAsciiDecoder : Decoder
{
	public override int GetCharCount(byte[] P_0, int P_1, int P_2)
	{
		return P_2;
	}

	public override int GetChars(byte[] P_0, int P_1, int P_2, char[] P_3, int P_4)
	{
		int num = P_1;
		int num2 = P_4;
		while (num < P_1 + P_2)
		{
			P_3[num2++] = (char)P_0[num++];
		}
		return P_2;
	}

	public override void Convert(byte[] P_0, int P_1, int P_2, char[] P_3, int P_4, int P_5, bool P_6, out int P_7, out int P_8, out bool P_9)
	{
		if (P_5 < P_2)
		{
			P_2 = P_5;
			P_9 = false;
		}
		else
		{
			P_9 = true;
		}
		int num = P_1;
		int num2 = P_4;
		int num3 = P_1 + P_2;
		while (num < num3)
		{
			P_3[num2++] = (char)P_0[num++];
		}
		P_8 = P_2;
		P_7 = P_2;
	}
}
