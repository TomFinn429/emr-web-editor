using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzyfh
{
	internal static readonly int z0rek = Color.Gray.ToArgb();

	public static readonly z0ZzZztfh z0tek = new z0ZzZzzdh(z0ZzZzhsh.z0eek, p1: true);

	internal static readonly int z0yek = Color.AliceBlue.ToArgb();

	public static readonly z0ZzZztfh z0uek = new z0ZzZzzdh(Color.Black, p1: true);

	public static readonly z0ZzZztfh z0iek = new z0ZzZzzdh(Color.White, p1: true);

	public static readonly z0ZzZztfh z0oek = new z0ZzZzzdh(Color.Red, p1: true);

	public static readonly z0ZzZztfh z0pek = new z0ZzZzzdh(Color.AliceBlue, p1: true);

	internal static readonly int z0mek = Color.Black.ToArgb();

	private static Dictionary<int, z0ZzZzzdh> z0nek = new Dictionary<int, z0ZzZzzdh>();

	public static readonly z0ZzZztfh z0bek = new z0ZzZzzdh(Color.Gray, p1: true);

	public static readonly z0ZzZztfh z0vek = new z0ZzZzzdh(Color.Yellow, p1: true);

	internal static readonly int z0cek = Color.Red.ToArgb();

	internal static readonly int z0xek = Color.White.ToArgb();

	public static readonly z0ZzZztfh z0zek = new z0ZzZzzdh(Color.LightGray, p1: true);

	internal static readonly int z0lrk = z0ZzZzhsh.z0eek.ToArgb();

	public static readonly z0ZzZztfh z0krk = new z0ZzZzzdh(Color.Blue, p1: true);

	public static readonly z0ZzZztfh z0jrk = new z0ZzZzzdh(Color.LightYellow, p1: true);

	public static z0ZzZzzdh z0eek(Color p0)
	{
		int num = p0.ToArgb();
		if (num == z0mek)
		{
			return (z0ZzZzzdh)z0uek;
		}
		if (num == z0xek)
		{
			return (z0ZzZzzdh)z0iek;
		}
		if (num == z0yek)
		{
			return (z0ZzZzzdh)z0pek;
		}
		if (num == z0cek)
		{
			return (z0ZzZzzdh)z0oek;
		}
		if (num == z0lrk)
		{
			return (z0ZzZzzdh)z0tek;
		}
		if (num == z0rek)
		{
			return (z0ZzZzzdh)z0bek;
		}
		if (z0nek == null)
		{
			z0nek = new Dictionary<int, z0ZzZzzdh>();
		}
		z0ZzZzzdh z0ZzZzzdh2 = null;
		if (!z0nek.TryGetValue(num, out z0ZzZzzdh2))
		{
			z0ZzZzzdh2 = new z0ZzZzzdh(p0);
			z0nek[num] = z0ZzZzzdh2;
		}
		return z0ZzZzzdh2;
	}
}
