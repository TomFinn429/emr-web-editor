namespace zzz;

internal static class z0ZzZzjrk
{
	public static readonly string z0rek;

	public static readonly string z0tek;

	public static readonly string z0yek;

	public static readonly string z0uek;

	public static readonly string z0iek;

	public static readonly string z0oek;

	public static readonly string z0pek;

	static z0ZzZzjrk()
	{
		byte[] p = z0ZzZzxek.z0tek();
		z0rek = z0eek(p, 1310927L);
		z0tek = z0eek(p, 21990233232030L);
		z0yek = z0eek(p, 32985349676296L);
		z0uek = z0eek(p, 46179488945842L);
		z0iek = z0eek(p, 54975582835960L);
		z0oek = z0eek(p, 79164838193219L);
		z0pek = z0eek(p, 95657512484551L);
	}

	private static string z0eek(byte[] p0, long p1)
	{
		int num = (int)(p1 & 0xFFFF) ^ 0x6493;
		p1 >>= 16;
		int num2 = (int)(p1 & 0xFFFFF);
		p1 >>= 24;
		int num3 = (int)p1;
		char[] array = new char[num2];
		int num4 = 0;
		while (num4 < num2)
		{
			int num5 = num4 + num3 << 1;
			array[num4] = (char)(((p0[num5] << 8) + p0[num5 + 1]) ^ num);
			num4++;
			num++;
		}
		return new string(array);
	}
}
