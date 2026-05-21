using System;

namespace zzz;

public static class z0ZzZzbok
{
	public static double z0rek;

	public static bool z0eek(double p0)
	{
		return (BitConverter.DoubleToInt64Bits(p0) & 0x7FFFFFFFFFFFFFFFL) > 9218868437227405312L;
	}

	static z0ZzZzbok()
	{
		z0rek = BitConverter.ToDouble(new byte[8] { 0, 0, 0, 0, 0, 0, 248, 255 }, 0);
	}
}
