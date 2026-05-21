using System.Text;

namespace System.Xml;

internal class Ucs4Encoding : Encoding
{
	internal Ucs4Decoder ucs4Decoder;

	public override string WebName => EncodingName;

	public override int CodePage => 0;

	internal static Encoding UCS4_Littleendian => new Ucs4Encoding4321();

	internal static Encoding UCS4_Bigendian => new Ucs4Encoding1234();

	internal static Encoding UCS4_2143 => new Ucs4Encoding2143();

	internal static Encoding UCS4_3412 => new Ucs4Encoding3412();

	public override Decoder GetDecoder()
	{
		return ucs4Decoder;
	}

	public override int GetByteCount(char[] P_0, int P_1, int P_2)
	{
		return checked(P_2 * 4);
	}

	public override byte[] GetBytes(string P_0)
	{
		return null;
	}

	public override int GetBytes(char[] P_0, int P_1, int P_2, byte[] P_3, int P_4)
	{
		return 0;
	}

	public override int GetMaxByteCount(int P_0)
	{
		return 0;
	}

	public override int GetCharCount(byte[] P_0, int P_1, int P_2)
	{
		return ucs4Decoder.GetCharCount(P_0, P_1, P_2);
	}

	public override int GetChars(byte[] P_0, int P_1, int P_2, char[] P_3, int P_4)
	{
		return ucs4Decoder.GetChars(P_0, P_1, P_2, P_3, P_4);
	}

	public override int GetMaxCharCount(int P_0)
	{
		return (P_0 + 3) / 4;
	}

	public override Encoder GetEncoder()
	{
		return null;
	}
}
