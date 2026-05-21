using System;

namespace zzz;

internal class z0ZzZzngj : z0ZzZzygj
{
	private readonly z0ZzZzbfj z0mek;

	private readonly z0ZzZzvdj z0nek;

	private readonly z0ZzZzvhj z0bek;

	internal z0ZzZzrqj z0eek()
	{
		return z0bek.z0odk();
	}

	internal bool z0rek()
	{
		return z0mek.z0rek();
	}

	internal bool z0eek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			z0ZzZzvdj z0ZzZzvdj2 = z0nek;
			int length = p0.Length;
			for (int i = 0; i < length; i++)
			{
				if (char.IsHighSurrogate(p0[i]) && i < length - 1)
				{
					int p1 = char.ConvertToUtf32(p0[i], p0[i + 1]);
					if (z0ZzZzvdj2.z0edk(p1) == 0)
					{
						return true;
					}
					i++;
				}
				else if (z0ZzZzvdj2.z0edk(p0[i]) == 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	internal bool z0tek()
	{
		return z0mek.z0fdk();
	}

	internal int z0eek(char p0)
	{
		return z0nek.z0edk(p0);
	}

	protected override void z0ygk(bool p0)
	{
		if (p0)
		{
			z0mek.Dispose();
			z0nek.Dispose();
		}
	}

	internal void z0yek()
	{
		z0bek.z0idk();
	}

	internal bool z0uek()
	{
		return z0mek.z0oek();
	}

	internal z0ZzZzwdj z0iek()
	{
		return z0mek.z0eek();
	}

	internal int z0eek(string p0, int p1, out int p2)
	{
		if (p0 == null || p0.Length <= p1)
		{
			throw new ArgumentNullException("strText");
		}
		if (z0ZzZzmej.z0rek(p0[p1]) && p1 < p0.Length - 1)
		{
			int p3 = char.ConvertToUtf32(p0[p1], p0[p1 + 1]);
			p2 = p1 + 2;
			return z0nek.z0edk(p3);
		}
		p2 = p1 + 1;
		return z0nek.z0edk(p0[p1]);
	}

	internal bool z0oek()
	{
		return z0bek.z0pdk();
	}

	internal z0ZzZzngj(z0ZzZzvhj p0, z0ZzZzbfj p1, z0ZzZzvdj p2)
	{
		z0bek = p0;
		z0mek = p1;
		z0nek = p2;
	}

	internal bool z0pek()
	{
		return z0mek.z0ddk();
	}

	internal z0ZzZzzdj z0eek(string p0, z0ZzZzcdj p1)
	{
		z0ZzZzxdj z0ZzZzxdj2 = z0nek.z0rdk(p0, p1);
		z0bek.z0mdk(z0ZzZzxdj2.z0rek_jiejie20260327142557());
		return z0ZzZzxdj2.z0eek_jiejie20260327142557();
	}
}
