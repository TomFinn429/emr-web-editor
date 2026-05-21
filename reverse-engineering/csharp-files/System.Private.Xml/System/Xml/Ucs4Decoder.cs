using System.Text;

namespace System.Xml;

internal abstract class Ucs4Decoder : Decoder
{
	internal byte[] lastBytes = new byte[4];

	internal int lastBytesCount;

	public override int GetCharCount(byte[] P_0, int P_1, int P_2)
	{
		return (P_2 + lastBytesCount) / 4;
	}

	internal abstract int GetFullChars(byte[] P_0, int P_1, int P_2, char[] P_3, int P_4);

	public override int GetChars(byte[] P_0, int P_1, int P_2, char[] P_3, int P_4)
	{
		int num;
		if (lastBytesCount > 0)
		{
			while (lastBytesCount < 4 && P_2 > 0)
			{
				lastBytes[lastBytesCount] = P_0[P_1];
				P_1++;
				P_2--;
				lastBytesCount++;
			}
			if (lastBytesCount < 4)
			{
				return 0;
			}
			num = GetFullChars(lastBytes, 0, 4, P_3, P_4);
			P_4 += num;
			lastBytesCount = 0;
		}
		else
		{
			num = 0;
		}
		num = GetFullChars(P_0, P_1, P_2, P_3, P_4) + num;
		int num2 = P_2 & 3;
		if (num2 >= 0)
		{
			for (int i = 0; i < num2; i++)
			{
				lastBytes[i] = P_0[P_1 + P_2 - num2 + i];
			}
			lastBytesCount = num2;
		}
		return num;
	}

	public override void Convert(byte[] P_0, int P_1, int P_2, char[] P_3, int P_4, int P_5, bool P_6, out int P_7, out int P_8, out bool P_9)
	{
		P_7 = 0;
		P_8 = 0;
		int i = lastBytesCount;
		int num;
		if (i > 0)
		{
			for (; i < 4; i++)
			{
				if (P_2 <= 0)
				{
					break;
				}
				lastBytes[i] = P_0[P_1];
				P_1++;
				P_2--;
				P_7++;
			}
			if (i < 4)
			{
				lastBytesCount = i;
				P_9 = true;
				return;
			}
			num = GetFullChars(lastBytes, 0, 4, P_3, P_4);
			P_4 += num;
			P_5 -= num;
			lastBytesCount = 0;
		}
		else
		{
			num = 0;
		}
		if (P_5 * 4 < P_2)
		{
			P_2 = P_5 * 4;
			P_9 = false;
		}
		else
		{
			P_9 = true;
		}
		P_7 += P_2;
		P_8 = GetFullChars(P_0, P_1, P_2, P_3, P_4) + num;
		int num2 = P_2 & 3;
		if (num2 >= 0)
		{
			for (int j = 0; j < num2; j++)
			{
				lastBytes[j] = P_0[P_1 + P_2 - num2 + j];
			}
			lastBytesCount = num2;
		}
	}

	internal static void Ucs4ToUTF16(uint P_0, char[] P_1, int P_2)
	{
		P_1[P_2] = (char)(55296 + (ushort)((P_0 >> 16) - 1) + (ushort)((P_0 >> 10) & 0x3F));
		P_1[P_2 + 1] = (char)(56320 + (ushort)(P_0 & 0x3FF));
	}
}
