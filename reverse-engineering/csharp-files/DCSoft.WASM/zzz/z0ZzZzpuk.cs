using System.Reflection;
using System.Text;

namespace zzz;

[Obfuscation(Exclude = true, ApplyToMembers = true)]
public static class z0ZzZzpuk
{
	private static readonly byte[] z0iek = new byte[8] { 137, 80, 78, 71, 13, 10, 26, 10 };

	public static bool z0eek(byte[] p0)
	{
		if (p0 != null && p0.Length >= 6 && p0[0] == 71 && p0[1] == 73 && p0[2] == 70)
		{
			if (p0[3] == 56 && p0[4] == 55 && p0[5] == 97)
			{
				return true;
			}
			if (p0[3] == 56 && p0[4] == 57 && p0[5] == 97)
			{
				return true;
			}
		}
		return false;
	}

	public static bool z0rek(byte[] p0)
	{
		if (p0 != null && p0.Length >= 4 && p0[0] == 80 && p0[1] == 75 && p0[2] == 3 && p0[3] == 4)
		{
			return true;
		}
		return false;
	}

	public static bool z0tek(byte[] p0)
	{
		if (p0 != null && p0.Length >= 2 && p0[0] == 66 && p0[1] == 77)
		{
			return true;
		}
		return false;
	}

	public static int z0eek(byte[] p0, int p1, ref Encoding p2)
	{
		if (p0 == null || p0.Length <= p1)
		{
			return 0;
		}
		int num = p0.Length - p1;
		if (num < 2)
		{
			return 0;
		}
		if (p0[p1] == 254 && p0[p1 + 1] == 255)
		{
			p2 = Encoding.BigEndianUnicode;
			return 2;
		}
		if (p0[p1] == 255 && p0[p1 + 1] == 254)
		{
			if (num < 4 || p0[2] != 0 || p0[3] != 0)
			{
				p2 = Encoding.Unicode;
				return 2;
			}
			p2 = Encoding.Unicode;
			return 4;
		}
		if (num >= 3 && p0[p1] == 239 && p0[p1 + 1] == 187 && p0[p1 + 2] == 191)
		{
			p2 = Encoding.UTF8;
			return 3;
		}
		if (num >= 4 && p0[p1] == 0 && p0[p1 + 1] == 0 && p0[p1 + 2] == 254 && p0[p1 + 3] == 255)
		{
			p2 = Encoding.BigEndianUnicode;
			return 4;
		}
		_ = 2;
		return 0;
	}

	public static bool z0yek(byte[] p0)
	{
		if (p0 != null && p0.Length >= z0iek.Length)
		{
			for (int i = 0; i < z0iek.Length; i++)
			{
				if (p0[i] != z0iek[i])
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public static bool z0eek(byte[] p0, bool p1)
	{
		if (p0 != null && p0.Length >= 12)
		{
			int num = p0.Length;
			if (p1 && (p0[num - 2] != 255 || p0[num - 1] != 217))
			{
				return false;
			}
			if (p0[0] == 255 && p0[1] == 216 && p0[2] == 255)
			{
				return true;
			}
		}
		return false;
	}

	public static bool z0uek(byte[] p0)
	{
		return z0eek(p0, p1: false);
	}
}
