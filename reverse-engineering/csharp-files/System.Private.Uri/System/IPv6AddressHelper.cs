namespace System;

internal static class IPv6AddressHelper
{
	internal static string ParseCanonicalName(string P_0, int P_1, ref bool P_2, ref string P_3)
	{
		Span<ushort> span = stackalloc ushort[8];
		span.Clear();
		Parse(P_0, span, P_1, ref P_3);
		P_2 = IsLoopback(span);
		(int longestSequenceStart, int longestSequenceLength) tuple = FindCompressionRange(span);
		int item = tuple.longestSequenceStart;
		int item2 = tuple.longestSequenceLength;
		bool flag = ShouldHaveIpv4Embedded(span);
		Span<char> span2 = stackalloc char[48];
		span2[0] = '[';
		int num = 1;
		for (int i = 0; i < 8; i++)
		{
			int num2;
			if (flag && i == 6)
			{
				span2[num++] = ':';
				bool flag2 = (span[i] >> 8).TryFormat(span2.Slice(num), out num2);
				num += num2;
				span2[num++] = '.';
				flag2 = (span[i] & 0xFF).TryFormat(span2.Slice(num), out num2);
				num += num2;
				span2[num++] = '.';
				flag2 = (span[i + 1] >> 8).TryFormat(span2.Slice(num), out num2);
				num += num2;
				span2[num++] = '.';
				flag2 = (span[i + 1] & 0xFF).TryFormat(span2.Slice(num), out num2);
				num += num2;
				break;
			}
			if (item == i)
			{
				span2[num++] = ':';
			}
			if (item <= i && item2 == 8)
			{
				span2[num++] = ':';
				break;
			}
			if (item > i || i >= item2)
			{
				if (i != 0)
				{
					span2[num++] = ':';
				}
				bool flag2 = span[i].TryFormat(span2.Slice(num), out num2, "x");
				num += num2;
			}
		}
		span2[num++] = ']';
		return new string(span2.Slice(0, num));
	}

	private static bool IsLoopback(ReadOnlySpan<ushort> P_0)
	{
		if (P_0[0] == 0 && P_0[1] == 0 && P_0[2] == 0 && P_0[3] == 0 && P_0[4] == 0)
		{
			if (P_0[5] != 0 || P_0[6] != 0 || P_0[7] != 1)
			{
				if (P_0[6] == 32512 && P_0[7] == 1)
				{
					if (P_0[5] != 0)
					{
						return P_0[5] == 65535;
					}
					return true;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private unsafe static bool InternalIsValid(char* P_0, int P_1, ref int P_2, bool P_3)
	{
		int num = 0;
		int num2 = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = true;
		int num3 = 1;
		if (P_0[P_1] == ':' && (P_1 + 1 >= P_2 || P_0[P_1 + 1] != ':'))
		{
			return false;
		}
		int i;
		for (i = P_1; i < P_2; i++)
		{
			if (flag3 ? char.IsAsciiDigit(P_0[i]) : char.IsAsciiHexDigit(P_0[i]))
			{
				num2++;
				flag4 = false;
				continue;
			}
			if (num2 > 4)
			{
				return false;
			}
			if (num2 != 0)
			{
				num++;
				num3 = i - num2;
			}
			char c = P_0[i];
			if ((uint)c <= 46u)
			{
				if (c == '%')
				{
					while (true)
					{
						if (++i == P_2)
						{
							return false;
						}
						if (P_0[i] == ']')
						{
							break;
						}
						if (P_0[i] != '/')
						{
							continue;
						}
						goto IL_010b;
					}
					goto IL_00dd;
				}
				if (c != '.')
				{
					goto IL_014b;
				}
				if (flag2)
				{
					return false;
				}
				i = P_2;
				if (!System.IPv4AddressHelper.IsValid(P_0, num3, ref i, true, false, false))
				{
					return false;
				}
				num++;
				flag2 = true;
				i--;
			}
			else
			{
				if (c == '/')
				{
					goto IL_010b;
				}
				if (c != ':')
				{
					if (c == ']')
					{
						goto IL_00dd;
					}
					goto IL_014b;
				}
				if (i > 0 && P_0[i - 1] == ':')
				{
					if (flag)
					{
						return false;
					}
					flag = true;
					flag4 = false;
				}
				else
				{
					flag4 = true;
				}
			}
			goto IL_014d;
			IL_00dd:
			P_1 = i;
			i = P_2;
			continue;
			IL_014b:
			return false;
			IL_014d:
			num2 = 0;
			continue;
			IL_010b:
			if (P_3)
			{
				return false;
			}
			if (num == 0 || flag3)
			{
				return false;
			}
			flag3 = true;
			flag4 = true;
			goto IL_014d;
		}
		if (flag3 && (num2 < 1 || num2 > 2))
		{
			return false;
		}
		int num4 = 8 + (flag3 ? 1 : 0);
		if (!flag4 && num2 <= 4 && (flag ? (num < num4) : (num == num4)))
		{
			if (i == P_2 + 1)
			{
				P_2 = P_1 + 1;
				return true;
			}
			return false;
		}
		return false;
	}

	internal unsafe static bool IsValid(char* P_0, int P_1, ref int P_2)
	{
		return InternalIsValid(P_0, P_1, ref P_2, false);
	}

	internal static (int longestSequenceStart, int longestSequenceLength) FindCompressionRange(ReadOnlySpan<ushort> P_0)
	{
		int num = 0;
		int num2 = -1;
		int num3 = 0;
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i] == 0)
			{
				num3++;
				if (num3 > num)
				{
					num = num3;
					num2 = i - num3 + 1;
				}
			}
			else
			{
				num3 = 0;
			}
		}
		if (num <= 1)
		{
			return (longestSequenceStart: -1, longestSequenceLength: -1);
		}
		return (longestSequenceStart: num2, longestSequenceLength: num2 + num);
	}

	internal static bool ShouldHaveIpv4Embedded(ReadOnlySpan<ushort> P_0)
	{
		if (P_0[0] == 0 && P_0[1] == 0 && P_0[2] == 0 && P_0[3] == 0 && P_0[6] != 0)
		{
			if (P_0[4] == 0 && (P_0[5] == 0 || P_0[5] == 65535))
			{
				return true;
			}
			if (P_0[4] == 65535 && P_0[5] == 0)
			{
				return true;
			}
		}
		if (P_0[4] == 0)
		{
			return P_0[5] == 24318;
		}
		return false;
	}

	internal static void Parse(ReadOnlySpan<char> P_0, Span<ushort> P_1, int P_2, ref string P_3)
	{
		int num = 0;
		int num2 = 0;
		int num3 = -1;
		bool flag = true;
		int num4 = 0;
		if (P_0[P_2] == '[')
		{
			P_2++;
		}
		int i = P_2;
		while (i < P_0.Length && P_0[i] != ']')
		{
			switch (P_0[i])
			{
			case '%':
				if (flag)
				{
					P_1[num2++] = (ushort)num;
					flag = false;
				}
				P_2 = i;
				for (i++; i < P_0.Length && P_0[i] != ']' && P_0[i] != '/'; i++)
				{
				}
				P_3 = new string(P_0.Slice(P_2, i - P_2));
				for (; i < P_0.Length && P_0[i] != ']'; i++)
				{
				}
				break;
			case ':':
			{
				P_1[num2++] = (ushort)num;
				num = 0;
				i++;
				if (P_0[i] == ':')
				{
					num3 = num2;
					i++;
				}
				else if (num3 < 0 && num2 < 6)
				{
					break;
				}
				for (int j = i; j < P_0.Length && P_0[j] != ']' && P_0[j] != ':' && P_0[j] != '%' && P_0[j] != '/' && j < i + 4; j++)
				{
					if (P_0[j] == '.')
					{
						for (; j < P_0.Length && P_0[j] != ']' && P_0[j] != '/' && P_0[j] != '%'; j++)
						{
						}
						num = System.IPv4AddressHelper.ParseHostNumber(P_0, i, j);
						P_1[num2++] = (ushort)(num >> 16);
						P_1[num2++] = (ushort)num;
						i = j;
						num = 0;
						flag = false;
						break;
					}
				}
				break;
			}
			case '/':
				if (flag)
				{
					P_1[num2++] = (ushort)num;
					flag = false;
				}
				for (i++; P_0[i] != ']'; i++)
				{
					num4 = num4 * 10 + (P_0[i] - 48);
				}
				break;
			default:
				num = num * 16 + Uri.FromHex(P_0[i++]);
				break;
			}
		}
		if (flag)
		{
			P_1[num2++] = (ushort)num;
		}
		if (num3 <= 0)
		{
			return;
		}
		int num5 = 7;
		int num6 = num2 - 1;
		if (num6 != num5)
		{
			for (int num7 = num2 - num3; num7 > 0; num7--)
			{
				P_1[num5--] = P_1[num6];
				P_1[num6--] = 0;
			}
		}
	}
}
