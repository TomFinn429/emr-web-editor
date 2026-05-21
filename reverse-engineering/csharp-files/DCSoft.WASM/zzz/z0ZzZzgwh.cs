using System;

namespace zzz;

internal struct z0ZzZzgwh
{
	public int z0yek;

	public int z0uek;

	public int z0iek;

	public int z0oek;

	public int z0pek;

	public int z0mek;

	public int z0nek;

	public int z0bek;

	public int z0vek;

	public z0ZzZzawh z0cek;

	private string z0xek;

	private int z0zek;

	private static readonly int[] z0lrk;

	private static readonly int z0krk_jiejie20260327142557;

	private static readonly int z0jrk;

	private static readonly int z0hrk;

	private static readonly int z0grk;

	private static readonly int z0frk;

	private static readonly int z0drk;

	private static readonly int z0srk;

	private static readonly int z0ark;

	private static readonly int z0qrk;

	private static readonly int z0wrk;

	private static readonly int z0erk;

	private static readonly int z0rrk;

	private static readonly int z0trk;

	static z0ZzZzgwh()
	{
		z0lrk = new int[7] { -1, 10, 100, 1000, 10000, 100000, 1000000 };
		z0krk_jiejie20260327142557 = "yyyy".Length;
		z0jrk = "yyyy-".Length;
		z0hrk = "yyyy-MM".Length;
		z0grk = "yyyy-MM-".Length;
		z0frk = "yyyy-MM-dd".Length;
		z0drk = "yyyy-MM-ddT".Length;
		z0srk = "HH".Length;
		z0ark = "HH:".Length;
		z0qrk = "HH:mm".Length;
		z0wrk = "HH:mm:".Length;
		z0erk = "HH:mm:ss".Length;
		z0rrk = "-".Length;
		z0trk = "-zz".Length;
	}

	public bool z0eek(string p0)
	{
		z0xek = p0;
		z0zek = p0.Length;
		if (z0eek(0) && z0eek(z0frk, 'T') && z0rek(z0drk))
		{
			return true;
		}
		return false;
	}

	private bool z0eek(int p0)
	{
		if (z0eek(p0, out z0yek) && 1 <= z0yek && z0eek(p0 + z0krk_jiejie20260327142557, '-') && z0rek(p0 + z0jrk, out z0uek) && 1 <= z0uek && z0uek <= 12 && z0eek(p0 + z0hrk, '-') && z0rek(p0 + z0grk, out z0iek) && 1 <= z0iek)
		{
			return z0iek <= DateTime.DaysInMonth(z0yek, z0uek);
		}
		return false;
	}

	private bool z0rek(int p0)
	{
		if (z0eek(ref p0))
		{
			return z0tek(p0);
		}
		return false;
	}

	private bool z0eek(ref int p0)
	{
		if (!z0rek(p0, out z0oek) || z0oek >= 24 || !z0eek(p0 + z0srk, ':') || !z0rek(p0 + z0ark, out z0pek) || z0pek >= 60 || !z0eek(p0 + z0qrk, ':') || !z0rek(p0 + z0wrk, out z0mek) || z0mek >= 60)
		{
			return false;
		}
		p0 += z0erk;
		if (z0eek(p0, '.'))
		{
			z0nek = 0;
			int num = 0;
			while (++p0 < z0zek && num < 7)
			{
				int num2 = z0xek[p0] - 48;
				if (num2 < 0 || num2 > 9)
				{
					break;
				}
				z0nek = z0nek * 10 + num2;
				num++;
			}
			if (num < 7)
			{
				if (num == 0)
				{
					return false;
				}
				z0nek *= z0lrk[7 - num];
			}
		}
		return true;
	}

	private bool z0tek(int p0)
	{
		if (p0 < z0zek)
		{
			char c = z0xek[p0];
			if (c == 'Z' || c == 'z')
			{
				z0cek = (z0ZzZzawh)1;
				p0++;
			}
			else
			{
				if (p0 + 2 < z0zek && z0rek(p0 + z0rrk, out z0bek) && z0bek <= 99)
				{
					switch (c)
					{
					case '-':
						z0cek = (z0ZzZzawh)2;
						p0 += z0trk;
						break;
					case '+':
						z0cek = (z0ZzZzawh)3;
						p0 += z0trk;
						break;
					}
				}
				if (p0 < z0zek)
				{
					if (z0eek(p0, ':'))
					{
						p0++;
						if (p0 + 1 < z0zek && z0rek(p0, out z0vek) && z0vek <= 99)
						{
							p0 += 2;
						}
					}
					else if (p0 + 1 < z0zek && z0rek(p0, out z0vek) && z0vek <= 99)
					{
						p0 += 2;
					}
				}
			}
		}
		return p0 == z0zek;
	}

	private bool z0eek(int p0, out int p1)
	{
		if (p0 + 3 < z0zek)
		{
			int num = z0xek[p0] - 48;
			int num2 = z0xek[p0 + 1] - 48;
			int num3 = z0xek[p0 + 2] - 48;
			int num4 = z0xek[p0 + 3] - 48;
			if (0 <= num && num < 10 && 0 <= num2 && num2 < 10 && 0 <= num3 && num3 < 10 && 0 <= num4 && num4 < 10)
			{
				p1 = ((num * 10 + num2) * 10 + num3) * 10 + num4;
				return true;
			}
		}
		p1 = 0;
		return false;
	}

	private bool z0rek(int p0, out int p1)
	{
		if (p0 + 1 < z0zek)
		{
			int num = z0xek[p0] - 48;
			int num2 = z0xek[p0 + 1] - 48;
			if (0 <= num && num < 10 && 0 <= num2 && num2 < 10)
			{
				p1 = num * 10 + num2;
				return true;
			}
		}
		p1 = 0;
		return false;
	}

	private bool z0eek(int p0, char p1)
	{
		if (p0 < z0zek)
		{
			return z0xek[p0] == p1;
		}
		return false;
	}
}
