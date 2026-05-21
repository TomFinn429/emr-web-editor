using System.Text;

namespace System.Xml;

internal sealed class UTF16Decoder : Decoder
{
	private readonly bool _bigEndian;

	private int _lastByte;

	public UTF16Decoder(bool P_0)
	{
		_lastByte = -1;
		_bigEndian = P_0;
	}

	public override int GetCharCount(byte[] P_0, int P_1, int P_2)
	{
		return GetCharCount(P_0, P_1, P_2, false);
	}

	public override int GetCharCount(byte[] P_0, int P_1, int P_2, bool P_3)
	{
		int num = P_2 + ((_lastByte >= 0) ? 1 : 0);
		if (P_3 && num % 2 != 0)
		{
			throw new ArgumentException(System.SR.Format("Enc_InvalidByteInEncoding", -1), (string?)null);
		}
		return num / 2;
	}

	public override int GetChars(byte[] P_0, int P_1, int P_2, char[] P_3, int P_4)
	{
		int charCount = GetCharCount(P_0, P_1, P_2);
		if (_lastByte >= 0)
		{
			if (P_2 == 0)
			{
				return charCount;
			}
			int num = P_0[P_1++];
			P_2--;
			P_3[P_4++] = (_bigEndian ? ((char)((_lastByte << 8) | num)) : ((char)((num << 8) | _lastByte)));
			_lastByte = -1;
		}
		if ((P_2 & 1) != 0)
		{
			_lastByte = P_0[P_1 + --P_2];
		}
		if (_bigEndian == BitConverter.IsLittleEndian)
		{
			int num2 = P_1 + P_2;
			if (_bigEndian)
			{
				while (P_1 < num2)
				{
					int num3 = P_0[P_1++];
					int num4 = P_0[P_1++];
					P_3[P_4++] = (char)((num3 << 8) | num4);
				}
			}
			else
			{
				while (P_1 < num2)
				{
					int num5 = P_0[P_1++];
					int num6 = P_0[P_1++];
					P_3[P_4++] = (char)((num6 << 8) | num5);
				}
			}
		}
		else
		{
			Buffer.BlockCopy(P_0, P_1, P_3, P_4 * 2, P_2);
		}
		return charCount;
	}

	public override void Convert(byte[] P_0, int P_1, int P_2, char[] P_3, int P_4, int P_5, bool P_6, out int P_7, out int P_8, out bool P_9)
	{
		P_8 = 0;
		P_7 = 0;
		if (_lastByte >= 0)
		{
			if (P_2 == 0)
			{
				P_9 = true;
				return;
			}
			int num = P_0[P_1++];
			P_2--;
			P_7++;
			P_3[P_4++] = (_bigEndian ? ((char)((_lastByte << 8) | num)) : ((char)((num << 8) | _lastByte)));
			P_5--;
			P_8++;
			_lastByte = -1;
		}
		if (P_5 * 2 < P_2)
		{
			P_2 = P_5 * 2;
			P_9 = false;
		}
		else
		{
			P_9 = true;
		}
		if (_bigEndian == BitConverter.IsLittleEndian)
		{
			int num2 = P_1;
			int num3 = num2 + (P_2 & -2);
			if (_bigEndian)
			{
				while (num2 < num3)
				{
					int num4 = P_0[num2++];
					int num5 = P_0[num2++];
					P_3[P_4++] = (char)((num4 << 8) | num5);
				}
			}
			else
			{
				while (num2 < num3)
				{
					int num6 = P_0[num2++];
					int num7 = P_0[num2++];
					P_3[P_4++] = (char)((num7 << 8) | num6);
				}
			}
		}
		else
		{
			Buffer.BlockCopy(P_0, P_1, P_3, P_4 * 2, P_2 & -2);
		}
		P_8 += P_2 / 2;
		P_7 += P_2;
		if ((P_2 & 1) != 0)
		{
			_lastByte = P_0[P_1 + P_2 - 1];
		}
	}
}
