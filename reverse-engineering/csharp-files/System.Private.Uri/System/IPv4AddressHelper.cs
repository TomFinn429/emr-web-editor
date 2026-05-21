using System.Buffers.Binary;

namespace System;

internal static class IPv4AddressHelper
{
	internal unsafe static string ParseCanonicalName(string P_0, int P_1, int P_2, ref bool P_3)
	{
		byte* ptr = stackalloc byte[4];
		P_3 = Parse(P_0, ptr, P_1, P_2);
		Span<char> span = stackalloc char[15];
		int num = 0;
		int num2;
		for (int i = 0; i < 3; i++)
		{
			ptr[i].TryFormat(span.Slice(num), out num2);
			int num3 = num + num2;
			span[num3] = '.';
			num = num3 + 1;
		}
		ptr[3].TryFormat(span.Slice(num), out num2);
		return new string(span.Slice(0, num + num2));
	}

	private unsafe static bool Parse(string P_0, byte* P_1, int P_2, int P_3)
	{
		fixed (char* ptr = P_0)
		{
			int num = P_3;
			long num2 = ParseNonCanonical(ptr, P_2, ref num, true);
			*P_1 = (byte)(num2 >> 24);
			P_1[1] = (byte)(num2 >> 16);
			P_1[2] = (byte)(num2 >> 8);
			P_1[3] = (byte)num2;
		}
		return *P_1 == 127;
	}

	internal static int ParseHostNumber(ReadOnlySpan<char> P_0, int P_1, int P_2)
	{
		Span<byte> span = stackalloc byte[4];
		for (int i = 0; i < span.Length; i++)
		{
			int num = 0;
			char c;
			while (P_1 < P_2 && (c = P_0[P_1]) != '.' && c != ':')
			{
				num = num * 10 + c - 48;
				P_1++;
			}
			span[i] = (byte)num;
			P_1++;
		}
		return BinaryPrimitives.ReadInt32BigEndian(span);
	}

	internal unsafe static bool IsValid(char* P_0, int P_1, ref int P_2, bool P_3, bool P_4, bool P_5)
	{
		if (P_3 || P_5)
		{
			return IsValidCanonical(P_0, P_1, ref P_2, P_3, P_4);
		}
		return ParseNonCanonical(P_0, P_1, ref P_2, P_4) != -1;
	}

	internal unsafe static bool IsValidCanonical(char* P_0, int P_1, ref int P_2, bool P_3, bool P_4)
	{
		int num = 0;
		int num2 = 0;
		bool flag = false;
		bool flag2 = false;
		while (P_1 < P_2)
		{
			char c = P_0[P_1];
			if (P_3)
			{
				if (c == ']' || c == '/' || c == '%')
				{
					break;
				}
			}
			else if (c == '/' || c == '\\' || (P_4 && (c == ':' || c == '?' || c == '#')))
			{
				break;
			}
			if (char.IsAsciiDigit(c))
			{
				if (!flag && c == '0')
				{
					if (P_1 + 1 < P_2 && P_0[P_1 + 1] == '0')
					{
						return false;
					}
					flag2 = true;
				}
				flag = true;
				num2 = num2 * 10 + (P_0[P_1] - 48);
				if (num2 > 255)
				{
					return false;
				}
			}
			else
			{
				if (c != '.')
				{
					return false;
				}
				if (!flag || (num2 > 0 && flag2))
				{
					return false;
				}
				num++;
				flag = false;
				num2 = 0;
				flag2 = false;
			}
			P_1++;
		}
		bool flag3 = num == 3 && flag;
		if (flag3)
		{
			P_2 = P_1;
		}
		return flag3;
	}

	internal unsafe static long ParseNonCanonical(char* P_0, int P_1, ref int P_2, bool P_3)
	{
		int num = 10;
		long* ptr = stackalloc long[4];
		long num2 = 0L;
		bool flag = false;
		int num3 = 0;
		int i;
		for (i = P_1; i < P_2; i++)
		{
			char c = P_0[i];
			num2 = 0L;
			num = 10;
			if (c == '0')
			{
				num = 8;
				i++;
				flag = true;
				if (i < P_2)
				{
					c = P_0[i];
					if (c == 'x' || c == 'X')
					{
						num = 16;
						i++;
						flag = false;
					}
				}
			}
			for (; i < P_2; i++)
			{
				c = P_0[i];
				int num4;
				if ((num == 10 || num == 16) && char.IsAsciiDigit(c))
				{
					num4 = c - 48;
				}
				else if (num == 8 && '0' <= c && c <= '7')
				{
					num4 = c - 48;
				}
				else if (num == 16 && 'a' <= c && c <= 'f')
				{
					num4 = c + 10 - 97;
				}
				else
				{
					if (num != 16 || 'A' > c || c > 'F')
					{
						break;
					}
					num4 = c + 10 - 65;
				}
				num2 = num2 * num + num4;
				if (num2 > 4294967295u)
				{
					return -1L;
				}
				flag = true;
			}
			if (i >= P_2 || P_0[i] != '.')
			{
				break;
			}
			if (num3 >= 3 || !flag || num2 > 255)
			{
				return -1L;
			}
			ptr[num3] = num2;
			num3++;
			flag = false;
		}
		if (!flag)
		{
			return -1L;
		}
		if (i < P_2)
		{
			char c;
			if ((c = P_0[i]) != '/' && c != '\\' && (!P_3 || (c != ':' && c != '?' && c != '#')))
			{
				return -1L;
			}
			P_2 = i;
		}
		ptr[num3] = num2;
		switch (num3)
		{
		case 0:
			if (*ptr > 4294967295u)
			{
				return -1L;
			}
			return *ptr;
		case 1:
			if (ptr[1] > 16777215)
			{
				return -1L;
			}
			return (*ptr << 24) | (ptr[1] & 0xFFFFFF);
		case 2:
			if (ptr[2] > 65535)
			{
				return -1L;
			}
			return (*ptr << 24) | ((ptr[1] & 0xFF) << 16) | (ptr[2] & 0xFFFF);
		case 3:
			if (ptr[3] > 255)
			{
				return -1L;
			}
			return (*ptr << 24) | ((ptr[1] & 0xFF) << 16) | ((ptr[2] & 0xFF) << 8) | (ptr[3] & 0xFF);
		default:
			return -1L;
		}
	}
}
