using System.Buffers;
using System.Text;

namespace System;

internal static class PercentEncodingHelper
{
	public unsafe static int UnescapePercentEncodedUTF8Sequence(char* P_0, int P_1, ref System.Text.ValueStringBuilder P_2, bool P_3, bool P_4)
	{
		uint num = 0u;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		while (true)
		{
			int num6 = num3 + num2 * 3;
			while (true)
			{
				if ((uint)(P_1 - num6) > 2u && P_0[num6] == '%')
				{
					uint num7 = P_0[num6 + 1];
					if ((uint)((num7 - 65) & -33) <= 5)
					{
						num7 = (num7 | 0x20) - 97 + 10;
					}
					else
					{
						if (num7 - 56 > 1)
						{
							goto IL_012d;
						}
						num7 -= 48;
					}
					uint num8 = (uint)(P_0[num6 + 2] - 48);
					if (num8 > 9)
					{
						if ((uint)((num8 - 17) & -33) > 5)
						{
							goto IL_012d;
						}
						num8 = ((num8 + 48) | 0x20) - 97 + 10;
					}
					num7 = (num7 << 4) | num8;
					_ = BitConverter.IsLittleEndian;
					num = (num >> 8) | (num7 << 24);
					if (++num2 == 4)
					{
						break;
					}
					num6 += 3;
					continue;
				}
				goto IL_012d;
				IL_012d:
				if (num2 > 1)
				{
					if (num5 == 1)
					{
						_ = BitConverter.IsLittleEndian;
						num >>= 8;
					}
					else
					{
						_ = BitConverter.IsLittleEndian;
						num >>= 32 - (num2 << 3);
					}
					break;
				}
				if ((num2 | num4) == 0)
				{
					return num3;
				}
				num2 *= 3;
				P_2.Append(P_0 + num3 - num4, num4 + num2);
				return num3 + num2;
			}
			uint num9 = num;
			if (Rune.DecodeFromUtf8(new ReadOnlySpan<byte>(&num9, num2), out var rune, out num5) == OperationStatus.Done && (!P_4 || System.IriHelper.CheckIriUnicodeRange((uint)rune.Value, P_3)))
			{
				if (num4 != 0)
				{
					P_2.Append(P_0 + num3 - num4, num4);
					num4 = 0;
				}
				P_2.Append(rune);
			}
			else
			{
				num4 += num5 * 3;
			}
			num2 -= num5;
			num3 += num5 * 3;
		}
	}
}
