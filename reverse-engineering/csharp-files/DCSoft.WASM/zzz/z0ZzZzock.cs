using System;
using System.Collections.Generic;
using System.IO;

namespace zzz;

public sealed class z0ZzZzock
{
	internal static z0ZzZzuck[] z0eek(string p0, bool p1, object p2, string p3, int p4, string p5, string p6)
	{
		try
		{
			if (string.IsNullOrEmpty(p0))
			{
				return null;
			}
			List<z0ZzZzuck> list = new List<z0ZzZzuck>();
			string[] array = p0.Split(',', '\n', '\r', ' ', '\t', '|');
			foreach (string text in array)
			{
				if (text == null || text.Trim().Length <= 0)
				{
					continue;
				}
				byte[] array2 = z0eek(text.Trim());
				if (array2 == null)
				{
					continue;
				}
				object[] array3 = z0eek(array2, p1, text.Trim());
				if (array3 != null && array3.Length != 0)
				{
					z0ZzZzuck z0ZzZzuck2 = new z0ZzZzuck();
					if (z0ZzZzuck2.z0eek(array3, 0, 0, DateTime.MinValue, null))
					{
						list.Add(z0ZzZzuck2);
					}
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return list.ToArray();
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static byte[] z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		int num = 0;
		byte b = 0;
		MemoryStream memoryStream = new MemoryStream();
		for (int i = 0; i < p0.Length; i++)
		{
			int num2 = z0eek(p0[i]);
			if (num2 >= 0)
			{
				b = (byte)((b << 4) + num2);
				num++;
				if (num % 2 == 0)
				{
					memoryStream.WriteByte(b);
					b = 0;
				}
			}
		}
		memoryStream.Close();
		return memoryStream.ToArray();
	}

	private static object[] z0eek(z0ZzZzxck p0, byte[] p1, bool p2, string p3)
	{
		byte[] array = new byte[8];
		array[1] = 40;
		array[4] = 142;
		array[2] = 140;
		array[5] = 109;
		array[0] = 26;
		array[6] = 18;
		array[3] = 94;
		array[7] = 99;
		byte[] array2 = new byte[8];
		array2[4] = 1;
		array2[0] = 183;
		array2[1] = 245;
		array2[6] = 119;
		array2[5] = 98;
		array2[7] = 36;
		array2[3] = 194;
		array2[2] = 134;
		byte[] array3 = new byte[p1.Length - 1];
		Array.Copy(p1, 1, array3, 0, array3.Length);
		p1 = z0ZzZzeck.z0tek(array3, array, array2);
		if (p1 == null || p1.Length == 0)
		{
			return null;
		}
		p0 = new z0ZzZzxck(new MemoryStream(p1));
		int num = 0;
		int num2 = 0;
		long num3 = 0L;
		string text = null;
		string text2 = null;
		string text3 = null;
		bool flag = false;
		int num4 = 0;
		DateTime dateTime = DateTime.MaxValue;
		int num5 = 0;
		int num6 = 2147483647;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		long num10 = 0L;
		string text4 = null;
		string text5 = null;
		byte b = 0;
		string text6 = null;
		string text7 = null;
		string text8 = null;
		DateTime dateTime2 = new DateTime(3000, 1, 1);
		DateTime dateTime3 = new DateTime(3000, 1, 1);
		string text9 = null;
		string text10 = null;
		int num11 = 0;
		int num12 = 2;
		int num13 = 0;
		int num14 = 0;
		int num15 = 1;
		text7 = p3;
		num7 = 4;
		b = (byte)p0.z0iek();
		int num16 = 0;
		for (int i = 2; i < p1.Length; i++)
		{
			num16 += p1[i];
		}
		num16 ^= 0xD2;
		if (num16 != b)
		{
			return null;
		}
		num10 = p0.z0eek();
		if ((num10 & 0x10) == 16)
		{
			num3 = p0.z0yek();
		}
		if ((num10 & 0x8000) == 32768)
		{
			num3 = p0.z0eek();
		}
		if ((num10 & 2) == 2)
		{
			text10 = p0.z0rek();
		}
		if ((num10 & 8) == 8)
		{
			text3 = p0.z0rek();
		}
		if ((num10 & 4) == 4)
		{
			int num17 = p0.z0yek();
			dateTime2 = new DateTime(1980, 1, 1).AddDays(num17);
		}
		if ((num10 & 0x40) == 64)
		{
			text9 = p0.z0rek();
		}
		if ((num10 & 0x80) == 128)
		{
			num2 = p0.z0uek();
		}
		if ((num10 & 0x800) == 2048)
		{
			text2 = p0.z0rek();
		}
		if ((num10 & 0x100) == 256)
		{
			text = p0.z0rek();
		}
		if ((num10 & 0x400) == 1024)
		{
			dateTime3 = new DateTime(1980, 1, 1).AddDays(p0.z0yek());
		}
		if ((num10 & 0x800000) == 8388608)
		{
			text8 = p0.z0rek();
		}
		if ((num10 & 0x8000000) == 134217728)
		{
			text6 = p0.z0rek();
		}
		if ((num10 & 0x4000) == 16384)
		{
			text4 = p0.z0rek();
		}
		if ((num10 & 0x40000) == 262144)
		{
			text5 = p0.z0rek();
		}
		num4 = (((num10 & 0x400000) != 4194304) ? 1 : p0.z0yek());
		if ((num10 & 0x2000000) == 33554432)
		{
			int num18 = p0.z0yek();
			dateTime = new DateTime(1980, 1, 1).AddDays(num18);
		}
		int[] array4 = null;
		if ((num10 & 0x20000000) == 536870912)
		{
			num12 = p0.z0yek();
			if (num12 == 100)
			{
				int num19 = p0.z0uek();
				if (num19 > 0)
				{
					List<int> list = new List<int>();
					for (int j = 0; j < num19; j++)
					{
						list.Add(p0.z0uek());
					}
					array4 = list.ToArray();
				}
			}
		}
		if ((num10 & 0x40000000) == 1073741824)
		{
			num13 = p0.z0uek();
		}
		if ((num10 & -2147483648) == -2147483648)
		{
			num14 = p0.z0yek();
		}
		if ((num10 & 0x200000000L) == 8589934592L)
		{
			num15 = p0.z0yek();
		}
		num = p0.z0uek();
		num5 = p0.z0yek();
		num6 = num5 + 35;
		if (!p0.z0tek())
		{
			p1[0] = 0;
			num6 = BitConverter.ToInt32(z0ZzZzeyk.z0eek(p1, 0, p1.Length - 4), 0);
		}
		return new object[31]
		{
			num, b, text2, num5, text, dateTime3, text5, text4, text6, dateTime2,
			num9, num10, num4, dateTime, text7, text8, num2, num11, num6, num8,
			text9, num3, text10, text3, num7, flag, num12, array4, num13, num14,
			num15
		};
	}

	private static object[] z0eek(byte[] p0, bool p1, string p2)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		using MemoryStream memoryStream = new MemoryStream(p0);
		z0ZzZzxck z0ZzZzxck2 = new z0ZzZzxck(memoryStream);
		byte b = (byte)z0ZzZzxck2.z0iek();
		if (b < 2)
		{
			return null;
		}
		if (b == 5)
		{
			return z0eek(z0ZzZzxck2, p0, p1, p2);
		}
		memoryStream.Close();
		return null;
	}

	private static int z0eek(char p0)
	{
		int result = -1;
		if (p0 >= '0' && p0 <= '9')
		{
			result = p0 - 48;
		}
		else if (p0 >= 'a' && p0 <= 'f')
		{
			result = p0 - 97 + 10;
		}
		else if (p0 >= 'A' && p0 <= 'F')
		{
			result = p0 - 65 + 10;
		}
		return result;
	}
}
