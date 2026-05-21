using System;
using System.Text;

namespace zzz;

public static class z0ZzZzeyk
{
	public class z0xvk
	{
		private static string z0eek(string p0)
		{
			string text = "";
			for (int num = p0.Length - 2; num >= 0; num -= 2)
			{
				text = ((num != -1) ? (text + p0[num] + p0[num + 1]) : (text + "0" + p0[num + 1]));
			}
			return text;
		}

		private static uint z0eek(uint p0, uint p1, uint p2)
		{
			return p0 ^ p1 ^ p2;
		}

		public static string z0eek(uint[] p0)
		{
			uint p1 = 1732584193u;
			uint p2 = 4023233417u;
			uint p3 = 2562383102u;
			uint p4 = 271733878u;
			for (int i = 0; i < p0.Length; i += 16)
			{
				uint num = p1;
				uint num2 = p2;
				uint num3 = p3;
				uint num4 = p4;
				z0rek(ref p1, p2, p3, p4, p0[i], 7, 3614090360u);
				z0rek(ref p4, p1, p2, p3, p0[i + 1], 12, 3905402710u);
				z0rek(ref p3, p4, p1, p2, p0[i + 2], 17, 606105819u);
				z0rek(ref p2, p3, p4, p1, p0[i + 3], 22, 3250441966u);
				z0rek(ref p1, p2, p3, p4, p0[i + 4], 7, 4118548399u);
				z0rek(ref p4, p1, p2, p3, p0[i + 5], 12, 1200080426u);
				z0rek(ref p3, p4, p1, p2, p0[i + 6], 17, 2821735955u);
				z0rek(ref p2, p3, p4, p1, p0[i + 7], 22, 4249261313u);
				z0rek(ref p1, p2, p3, p4, p0[i + 8], 7, 1770035416u);
				z0rek(ref p4, p1, p2, p3, p0[i + 9], 12, 2336552879u);
				z0rek(ref p3, p4, p1, p2, p0[i + 10], 17, 4294925233u);
				z0rek(ref p2, p3, p4, p1, p0[i + 11], 22, 2304563134u);
				z0rek(ref p1, p2, p3, p4, p0[i + 12], 7, 1804603682u);
				z0rek(ref p4, p1, p2, p3, p0[i + 13], 12, 4254626195u);
				z0rek(ref p3, p4, p1, p2, p0[i + 14], 17, 2792965006u);
				z0rek(ref p2, p3, p4, p1, p0[i + 15], 22, 1236535329u);
				z0tek(ref p1, p2, p3, p4, p0[i + 1], 5, 4129170786u);
				z0tek(ref p4, p1, p2, p3, p0[i + 6], 9, 3225465664u);
				z0tek(ref p3, p4, p1, p2, p0[i + 11], 14, 643717713u);
				z0tek(ref p2, p3, p4, p1, p0[i], 20, 3921069994u);
				z0tek(ref p1, p2, p3, p4, p0[i + 5], 5, 3593408605u);
				z0tek(ref p4, p1, p2, p3, p0[i + 10], 9, 38016083u);
				z0tek(ref p3, p4, p1, p2, p0[i + 15], 14, 3634488961u);
				z0tek(ref p2, p3, p4, p1, p0[i + 4], 20, 3889429448u);
				z0tek(ref p1, p2, p3, p4, p0[i + 9], 5, 568446438u);
				z0tek(ref p4, p1, p2, p3, p0[i + 14], 9, 3275163606u);
				z0tek(ref p3, p4, p1, p2, p0[i + 3], 14, 4107603335u);
				z0tek(ref p2, p3, p4, p1, p0[i + 8], 20, 1163531501u);
				z0tek(ref p1, p2, p3, p4, p0[i + 13], 5, 2850285829u);
				z0tek(ref p4, p1, p2, p3, p0[i + 2], 9, 4243563512u);
				z0tek(ref p3, p4, p1, p2, p0[i + 7], 14, 1735328473u);
				z0tek(ref p2, p3, p4, p1, p0[i + 12], 20, 2368359562u);
				z0eek(ref p1, p2, p3, p4, p0[i + 5], 4, 4294588738u);
				z0eek(ref p4, p1, p2, p3, p0[i + 8], 11, 2272392833u);
				z0eek(ref p3, p4, p1, p2, p0[i + 11], 16, 1839030562u);
				z0eek(ref p2, p3, p4, p1, p0[i + 14], 23, 4259657740u);
				z0eek(ref p1, p2, p3, p4, p0[i + 1], 4, 2763975236u);
				z0eek(ref p4, p1, p2, p3, p0[i + 4], 11, 1272893353u);
				z0eek(ref p3, p4, p1, p2, p0[i + 7], 16, 4139469664u);
				z0eek(ref p2, p3, p4, p1, p0[i + 10], 23, 3200236656u);
				z0eek(ref p1, p2, p3, p4, p0[i + 13], 4, 681279174u);
				z0eek(ref p4, p1, p2, p3, p0[i], 11, 3936430074u);
				z0eek(ref p3, p4, p1, p2, p0[i + 3], 16, 3572445317u);
				z0eek(ref p2, p3, p4, p1, p0[i + 6], 23, 76029189u);
				z0eek(ref p1, p2, p3, p4, p0[i + 9], 4, 3654602809u);
				z0eek(ref p4, p1, p2, p3, p0[i + 12], 11, 3873151461u);
				z0eek(ref p3, p4, p1, p2, p0[i + 15], 16, 530742520u);
				z0eek(ref p2, p3, p4, p1, p0[i + 2], 23, 3299628645u);
				z0yek(ref p1, p2, p3, p4, p0[i], 6, 4096336452u);
				z0yek(ref p4, p1, p2, p3, p0[i + 7], 10, 1126891415u);
				z0yek(ref p3, p4, p1, p2, p0[i + 14], 15, 2878612391u);
				z0yek(ref p2, p3, p4, p1, p0[i + 5], 21, 4237533241u);
				z0yek(ref p1, p2, p3, p4, p0[i + 12], 6, 1700485571u);
				z0yek(ref p4, p1, p2, p3, p0[i + 3], 10, 2399980690u);
				z0yek(ref p3, p4, p1, p2, p0[i + 10], 15, 4293915773u);
				z0yek(ref p2, p3, p4, p1, p0[i + 1], 21, 2240044497u);
				z0yek(ref p1, p2, p3, p4, p0[i + 8], 6, 1873313359u);
				z0yek(ref p4, p1, p2, p3, p0[i + 15], 10, 4264355552u);
				z0yek(ref p3, p4, p1, p2, p0[i + 6], 15, 2734768916u);
				z0yek(ref p2, p3, p4, p1, p0[i + 13], 21, 1309151649u);
				z0yek(ref p1, p2, p3, p4, p0[i + 4], 6, 4149444226u);
				z0yek(ref p4, p1, p2, p3, p0[i + 11], 10, 3174756917u);
				z0yek(ref p3, p4, p1, p2, p0[i + 2], 15, 718787259u);
				z0yek(ref p2, p3, p4, p1, p0[i + 9], 21, 3951481745u);
				p1 += num;
				p2 += num2;
				p3 += num3;
				p4 += num4;
			}
			return z0eek(p1) + z0eek(p2) + z0eek(p3) + z0eek(p4);
		}

		private static uint z0rek(uint p0, uint p1, uint p2)
		{
			return p1 ^ (p0 | ~p2);
		}

		public static byte[] z0eek(byte[] p0)
		{
			string text = z0eek(z0rek(p0)).Replace(" ", "");
			if (text.Length % 2 != 0)
			{
				text += " ";
			}
			byte[] array = new byte[text.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = text.Substring(i * 2, 2).Trim();
				array[i] = Convert.ToByte(text2, 16);
			}
			return array;
		}

		private static void z0eek(ref uint p0, uint p1, uint p2, uint p3, uint p4, int p5, uint p6)
		{
			uint num = z0eek(p1, p2, p3);
			p0 = p4 + p6 + p0 + num;
			p0 = z0eek(p0, p5);
			p0 += p1;
		}

		private static uint z0tek(uint p0, uint p1, uint p2)
		{
			return (p0 & p1) | (~p0 & p2);
		}

		private static void z0rek(ref uint p0, uint p1, uint p2, uint p3, uint p4, int p5, uint p6)
		{
			uint num = z0tek(p1, p2, p3);
			p0 = p4 + p6 + p0 + num;
			p0 = z0eek(p0, p5);
			p0 += p1;
		}

		public static uint[] z0rek(string p0)
		{
			return z0rek(Encoding.Default.GetBytes(p0));
		}

		private static string z0eek(uint p0)
		{
			return z0eek(Convert.ToString(p0, 16));
		}

		private static uint z0eek(uint p0, int p1)
		{
			p1 %= 32;
			return (p0 << p1) | (p0 >> 32 - p1);
		}

		private static uint z0yek(uint p0, uint p1, uint p2)
		{
			return (p0 & p2) | (p1 & ~p2);
		}

		public static uint[] z0rek(byte[] p0)
		{
			uint num = (uint)p0.Length;
			uint num2 = ((num + 8) / 64 + 1) * 16;
			uint[] array = new uint[num2];
			uint num3 = 0u;
			int num4 = 0;
			uint num5 = 0u;
			for (num5 = 0u; num5 < num; num5++)
			{
				num3 = num5 / 4;
				num4 = (int)(num5 % 4 * 8);
				array[num3] |= (uint)(p0[num5] << num4);
			}
			num3 = num5 / 4;
			num4 = (int)(num5 % 4 * 8);
			array[num3] |= (uint)(128 << num4);
			array[num2 - 2] = num << 3;
			array[num2 - 1] = num >> 29;
			return array;
		}

		private static void z0tek(ref uint p0, uint p1, uint p2, uint p3, uint p4, int p5, uint p6)
		{
			uint num = z0yek(p1, p2, p3);
			p0 = p4 + p6 + p0 + num;
			p0 = z0eek(p0, p5);
			p0 += p1;
		}

		private static void z0yek(ref uint p0, uint p1, uint p2, uint p3, uint p4, int p5, uint p6)
		{
			uint num = z0rek(p1, p2, p3);
			p0 = p4 + p6 + p0 + num;
			p0 = z0eek(p0, p5);
			p0 += p1;
		}

		public static string z0tek(byte[] p0)
		{
			return z0eek(z0rek(p0));
		}

		public static string z0tek(string p0)
		{
			return z0eek(z0rek(p0));
		}
	}

	public static byte[] z0eek(byte[] p0, int p1, int p2)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("bs");
		}
		if (p1 == 0 && p2 == p0.Length)
		{
			return z0xvk.z0eek(p0);
		}
		byte[] array = new byte[p2];
		Array.Copy(p0, p1, array, 0, p2);
		return z0xvk.z0eek(array);
	}

	public static void z0eek(byte[] p0, int p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return;
		}
		int num = p0.Length;
		if (p1 > 0)
		{
			int num2 = 8 - p1;
			byte b = (byte)(p0[num - 1] << num2);
			for (int i = 0; i < num; i++)
			{
				byte b2 = p0[i];
				byte num3 = (byte)(b2 << num2);
				b2 = (byte)(b2 >> p1);
				p0[i] = (byte)(b2 + b);
				b = num3;
			}
			return;
		}
		p1 = -p1;
		int num4 = 8 - p1;
		byte b3 = (byte)(p0[0] >> num4);
		for (int num5 = num - 1; num5 >= 0; num5--)
		{
			byte b4 = p0[num5];
			byte num6 = (byte)(b4 >> num4);
			b4 = (byte)(b4 << p1);
			p0[num5] = (byte)(b4 + b3);
			b3 = num6;
		}
	}

	public static byte[] z0eek(byte[] p0)
	{
		return z0eek(p0, 0, p0.Length);
	}

	public static byte[] z0eek(byte[] p0, byte[] p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return p1;
		}
		if (p1 == null || p1.Length == 0)
		{
			return p0;
		}
		byte[] array = new byte[p0.Length + p1.Length];
		Array.Copy(p0, 0, array, 0, p0.Length);
		Array.Copy(p1, 0, array, p0.Length, p1.Length);
		return array;
	}

	public unsafe static void z0eek(byte[] p0, byte p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return;
		}
		_ = p0.Length;
		fixed (byte* ptr = p0)
		{
			for (byte* ptr2 = ptr + p0.Length - 1; ptr2 >= ptr; ptr2--)
			{
				*ptr2 ^= p1;
			}
		}
	}

	public static bool z0rek(byte[] p0, byte[] p1)
	{
		if (p0 == p1)
		{
			return true;
		}
		int num = ((p0 != null) ? p0.Length : 0);
		int num2 = ((p1 != null) ? p1.Length : 0);
		if (num != num2)
		{
			return false;
		}
		if (p0 == null || p1 == null)
		{
			return false;
		}
		_ = p0.Length;
		for (int num3 = p0.Length - 1; num3 >= 0; num3--)
		{
			if (p0[num3] != p1[num3])
			{
				return false;
			}
		}
		return true;
	}
}
