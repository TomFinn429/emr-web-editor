using System;

namespace zzz;

internal sealed class z0ZzZzgij
{
	public static readonly z0ZzZzgij z0rek = new z0ZzZzgij(null, 7, "ECI");

	private int[] z0tek;

	public static readonly z0ZzZzgij z0yek = new z0ZzZzgij(new int[3] { 10, 12, 14 }, 1, "NUMERIC");

	private int z0uek;

	private string z0iek;

	public static readonly z0ZzZzgij z0oek = new z0ZzZzgij(new int[3] { 8, 10, 12 }, 8, "KANJI");

	public static readonly z0ZzZzgij z0pek = new z0ZzZzgij(new int[3] { 8, 16, 16 }, 4, "BYTE");

	public static readonly z0ZzZzgij z0mek = new z0ZzZzgij(new int[3] { 9, 11, 13 }, 2, "ALPHANUMERIC");

	private z0ZzZzgij(int[] p0, int p1, string p2)
	{
		z0tek = p0;
		z0uek = p1;
		z0iek = p2;
	}

	public override string ToString()
	{
		return z0iek;
	}

	public int z0eek()
	{
		return z0uek;
	}

	public int z0eek(z0ZzZzfij p0)
	{
		if (z0tek == null)
		{
			throw new ArgumentException("Character count doesn't apply to this mode");
		}
		int num = p0.z0rek();
		int num2 = ((num > 9) ? ((num <= 26) ? 1 : 2) : 0);
		return z0tek[num2];
	}
}
