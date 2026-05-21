using System.Buffers.Binary;

namespace System.Xml;

internal sealed class Ucs4Decoder4321 : Ucs4Decoder
{
	internal override int GetFullChars(byte[] P_0, int P_1, int P_2, char[] P_3, int P_4)
	{
		P_2 += P_1;
		int i = P_1;
		int num = P_4;
		for (; i + 3 < P_2; i += 4)
		{
			uint num2 = BinaryPrimitives.ReadUInt32LittleEndian(P_0.AsSpan(i));
			if (num2 > 1114111)
			{
				throw new ArgumentException(System.SR.Format("Enc_InvalidByteInEncoding", new object[1] { i }), (string?)null);
			}
			if (num2 > 65535)
			{
				Ucs4Decoder.Ucs4ToUTF16(num2, P_3, num);
				num++;
			}
			else
			{
				if (XmlCharType.IsSurrogate((int)num2))
				{
					throw new XmlException("Xml_InvalidCharInThisEncoding", string.Empty);
				}
				P_3[num] = (char)num2;
			}
			num++;
		}
		return num - P_4;
	}
}
