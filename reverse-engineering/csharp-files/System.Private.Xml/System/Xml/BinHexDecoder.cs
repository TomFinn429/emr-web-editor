using System.Runtime.CompilerServices;

namespace System.Xml;

internal sealed class BinHexDecoder : IncrementalReadDecoder
{
	internal override bool IsFull
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal override int Decode(char[] P_0, int P_1, int P_2)
	{
		throw new NotSupportedException("Linked away");
	}

	public static byte[] Decode(ReadOnlySpan<char> P_0, bool P_1)
	{
		int length = P_0.Length;
		if (length == 0)
		{
			return Array.Empty<byte>();
		}
		byte[] array = new byte[(length + 1) / 2];
		bool flag = false;
		byte b = 0;
		Decode(P_0, array, ref flag, ref b, out var _, out var num2);
		if (flag && !P_1)
		{
			throw new XmlException("Xml_InvalidBinHexValueOddCount", new string(P_0));
		}
		if (num2 < array.Length)
		{
			Array.Resize(ref array, num2);
		}
		return array;
	}

	private static void Decode(ReadOnlySpan<char> P_0, Span<byte> P_1, ref bool P_2, ref byte P_3, out int P_4, out int P_5)
	{
		int num = 0;
		int i;
		for (i = 0; i < P_0.Length; i++)
		{
			if ((uint)num >= (uint)P_1.Length)
			{
				break;
			}
			char c = P_0[i];
			int num2 = System.HexConverter.FromChar(c);
			if (num2 != 255)
			{
				byte b = (byte)num2;
				if (P_2)
				{
					P_1[num++] = (byte)((P_3 << 4) + b);
					P_2 = false;
				}
				else
				{
					P_3 = b;
					P_2 = true;
				}
			}
			else if (!XmlCharType.IsWhiteSpace(c))
			{
				throw new XmlException("Xml_InvalidBinHexValue", P_0.ToString());
			}
		}
		P_5 = num;
		P_4 = i;
	}
}
