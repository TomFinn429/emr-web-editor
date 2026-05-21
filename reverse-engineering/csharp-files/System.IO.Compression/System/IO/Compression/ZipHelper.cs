using System.Text;

namespace System.IO.Compression;

internal static class ZipHelper
{
	private static readonly DateTime s_invalidDateIndicator = new DateTime(1980, 1, 1, 0, 0, 0);

	internal static Encoding GetEncoding(string P_0)
	{
		foreach (char c in P_0)
		{
			if (c > '~' || c < ' ')
			{
				return Encoding.UTF8;
			}
		}
		return Encoding.ASCII;
	}

	internal static void ReadBytes(Stream P_0, byte[] P_1, int P_2)
	{
		int num = P_0.ReadAtLeast(P_1.AsSpan(0, P_2), P_2, false);
		if (num < P_2)
		{
			throw new IOException("UnexpectedEndOfStream");
		}
	}

	internal static DateTime DosTimeToDateTime(uint P_0)
	{
		if (P_0 == 0)
		{
			return s_invalidDateIndicator;
		}
		int year = (int)(1980 + (P_0 >> 25));
		int month = (int)((P_0 >> 21) & 0xF);
		int day = (int)((P_0 >> 16) & 0x1F);
		int hour = (int)((P_0 >> 11) & 0x1F);
		int minute = (int)((P_0 >> 5) & 0x3F);
		int second = (int)((P_0 & 0x1F) * 2);
		try
		{
			return new DateTime(year, month, day, hour, minute, second, 0);
		}
		catch (ArgumentOutOfRangeException)
		{
			return s_invalidDateIndicator;
		}
		catch (ArgumentException)
		{
			return s_invalidDateIndicator;
		}
	}

	internal static uint DateTimeToDosTime(DateTime P_0)
	{
		int num = (P_0.Year - 1980) & 0x7F;
		num = (num << 4) + P_0.Month;
		num = (num << 5) + P_0.Day;
		num = (num << 5) + P_0.Hour;
		num = (num << 6) + P_0.Minute;
		return (uint)((num << 5) + P_0.Second / 2);
	}

	internal static bool SeekBackwardsToSignature(Stream P_0, uint P_1, int P_2)
	{
		int num = 0;
		uint num2 = 0u;
		byte[] array = new byte[32];
		bool flag = false;
		bool flag2 = false;
		int num3 = 0;
		while (!flag2 && !flag && num3 <= P_2)
		{
			flag = SeekBackwardsAndRead(P_0, array, out num);
			while (num >= 0 && !flag2)
			{
				num2 = (num2 << 8) | array[num];
				if (num2 == P_1)
				{
					flag2 = true;
				}
				else
				{
					num--;
				}
			}
			num3 += array.Length;
		}
		if (!flag2)
		{
			return false;
		}
		P_0.Seek(num, SeekOrigin.Current);
		return true;
	}

	internal static void AdvanceToPosition(this Stream P_0, long P_1)
	{
		long num = P_1 - P_0.Position;
		if (num <= 0)
		{
			return;
		}
		byte[] array = new byte[64];
		do
		{
			int num2 = (int)Math.Min(num, array.Length);
			int num3 = P_0.Read(array, 0, num2);
			if (num3 == 0)
			{
				throw new IOException("UnexpectedEndOfStream");
			}
			num -= num3;
		}
		while (num > 0);
	}

	private static bool SeekBackwardsAndRead(Stream P_0, byte[] P_1, out int P_2)
	{
		if (P_0.Position >= P_1.Length)
		{
			P_0.Seek(-P_1.Length, SeekOrigin.Current);
			ReadBytes(P_0, P_1, P_1.Length);
			P_0.Seek(-P_1.Length, SeekOrigin.Current);
			P_2 = P_1.Length - 1;
			return false;
		}
		int num = (int)P_0.Position;
		P_0.Seek(0L, SeekOrigin.Begin);
		ReadBytes(P_0, P_1, num);
		P_0.Seek(0L, SeekOrigin.Begin);
		P_2 = num - 1;
		return true;
	}

	internal static byte[] GetEncodedTruncatedBytesFromString(string P_0, Encoding P_1, int P_2, out bool P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			P_3 = false;
			return Array.Empty<byte>();
		}
		if (P_1 == null)
		{
			P_1 = GetEncoding(P_0);
		}
		P_3 = P_1.CodePage == 65001;
		if (P_2 == 0)
		{
			return P_1.GetBytes(P_0);
		}
		byte[] bytes;
		if (P_3)
		{
			int num = 0;
			foreach (Rune item in P_0.EnumerateRunes())
			{
				if (num + item.Utf8SequenceLength > P_2)
				{
					break;
				}
				num += item.Utf8SequenceLength;
			}
			bytes = P_1.GetBytes(P_0);
			return bytes[0..num];
		}
		bytes = P_1.GetBytes(P_0);
		if (P_2 >= bytes.Length)
		{
			return bytes;
		}
		return bytes[0..P_2];
	}
}
