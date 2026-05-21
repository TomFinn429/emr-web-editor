using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzidh
{
	private static readonly int z0rek = Color.Red.ToArgb();

	private static readonly int z0tek_jiejie20260327142557 = Color.Black.ToArgb();

	public static readonly z0ZzZzudh z0yek = new z0ZzZzudh(Color.Blue, p1: true);

	public static readonly z0ZzZzudh z0uek = new z0ZzZzudh(Color.White, p1: true);

	public static readonly z0ZzZzudh z0iek = new z0ZzZzudh(Color.Black, p1: true);

	private static readonly int z0oek = Color.Gray.ToArgb();

	private static readonly int z0pek = Color.White.ToArgb();

	public static readonly z0ZzZzudh z0mek = new z0ZzZzudh(Color.Green, p1: true);

	public static readonly z0ZzZzudh z0nek = new z0ZzZzudh(Color.Yellow, p1: true);

	private static readonly Dictionary<int, z0ZzZzudh> z0bek = new Dictionary<int, z0ZzZzudh>();

	public static readonly z0ZzZzudh z0vek = new z0ZzZzudh(Color.Gray, p1: true);

	public static readonly z0ZzZzudh z0cek = new z0ZzZzudh(Color.Red, p1: true);

	public static z0ZzZzudh z0eek(Color p0)
	{
		int num = p0.ToArgb();
		if (num == z0tek_jiejie20260327142557)
		{
			return z0iek;
		}
		if (num == z0oek)
		{
			return z0vek;
		}
		if (num == z0pek)
		{
			return z0uek;
		}
		if (num == z0rek)
		{
			return z0cek;
		}
		z0ZzZzudh result = null;
		if (z0bek.TryGetValue(num, out result))
		{
			return result;
		}
		result = new z0ZzZzudh(p0);
		z0bek.Add(num, result);
		return result;
	}
}
