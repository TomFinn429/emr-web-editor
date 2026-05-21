using System;

namespace zzz;

internal sealed class z0ZzZzush
{
	private enum z0rhj
	{
		z0eek,
		z0rek,
		z0tek
	}

	private int z0uek;

	private z0ZzZzssh z0iek;

	private bool z0oek;

	private readonly char[] z0pek;

	private readonly bool z0nek;

	private int z0bek;

	private z0rhj z0vek;

	private z0ZzZzrsh z0cek;

	private readonly z0ZzZzcah z0xek;

	internal z0ZzZzush(z0ZzZzcah p0)
	{
		z0xek = p0;
		z0nek = p0.z0tek();
		if (z0nek)
		{
			z0pek = new char[256];
		}
	}

	internal int z0eek(byte[] p0, int p1, int p2)
	{
		ArgumentNullException.ThrowIfNull(p0, "buffer");
		if (p2 < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (p0.Length - p1 < p2)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		switch (z0vek)
		{
		case z0rhj.z0eek:
			if (z0xek.z0la() != (z0ZzZzbah)1)
			{
				throw z0xek.z0rek("ReadElementContentAsBase64");
			}
			if (!z0yek())
			{
				return 0;
			}
			break;
		case z0rhj.z0rek:
			throw new InvalidOperationException();
		case z0rhj.z0tek:
			if (z0cek == z0iek)
			{
				return z0rek(p0, p1, p2);
			}
			break;
		default:
			return 0;
		}
		z0tek();
		return z0rek(p0, p1, p2);
	}

	private int z0rek(byte[] p0, int p1, int p2)
	{
		if (p2 == 0)
		{
			return 0;
		}
		int num = z0tek(p0, p1, p2);
		if (num > 0)
		{
			return num;
		}
		if (z0xek.z0la() != (z0ZzZzbah)15)
		{
			throw new z0ZzZzeah();
		}
		z0xek.z0ua();
		z0vek = z0rhj.z0eek;
		return 0;
	}

	internal void z0eek()
	{
		z0vek = z0rhj.z0eek;
		z0oek = false;
		z0bek = 0;
	}

	internal void z0rek()
	{
		if (z0vek != z0rhj.z0eek)
		{
			while (z0eek(p0: true))
			{
			}
			if (z0vek == z0rhj.z0tek)
			{
				if (z0xek.z0la() != (z0ZzZzbah)15)
				{
					throw new z0ZzZzeah();
				}
				z0xek.z0ua();
			}
		}
		z0eek();
	}

	private bool z0eek(bool p0)
	{
		do
		{
			switch (z0xek.z0la())
			{
			case (z0ZzZzbah)2:
				return !p0;
			case (z0ZzZzbah)3:
			case (z0ZzZzbah)4:
			case (z0ZzZzbah)13:
			case (z0ZzZzbah)14:
				if (!p0)
				{
					return true;
				}
				goto IL_0078;
			case (z0ZzZzbah)5:
				if (!z0xek.z0zh())
				{
					break;
				}
				z0xek.z0sa();
				goto IL_0078;
			case (z0ZzZzbah)7:
			case (z0ZzZzbah)8:
			case (z0ZzZzbah)16:
				goto IL_0078;
			}
			return false;
			IL_0078:
			p0 = false;
		}
		while (z0xek.z0ua());
		return false;
	}

	private int z0tek(byte[] p0, int p1, int p2)
	{
		if (z0oek)
		{
			z0eek();
			return 0;
		}
		z0cek.z0ld(p0, p1, p2);
		do
		{
			if (z0nek)
			{
				while (true)
				{
					if (z0bek < z0uek)
					{
						int num = z0cek.z0vf(z0pek, z0bek, z0uek - z0bek);
						z0bek += num;
					}
					if (z0cek.z0bf())
					{
						return z0cek.z0zf();
					}
					if ((z0uek = z0xek.z0eek(z0pek, 0, 256)) == 0)
					{
						break;
					}
					z0bek = 0;
				}
			}
			else
			{
				string text = z0xek.z0fa();
				int num2 = z0cek.z0cf(text, z0bek, text.Length - z0bek);
				z0bek += num2;
				if (z0cek.z0bf())
				{
					return z0cek.z0zf();
				}
			}
			z0bek = 0;
		}
		while (z0eek(p0: true));
		z0oek = true;
		return z0cek.z0zf();
	}

	private void z0tek()
	{
		if (z0iek == null)
		{
			z0iek = new z0ZzZzssh();
		}
		else
		{
			z0iek.z0xf();
		}
		z0cek = z0iek;
	}

	internal static z0ZzZzush z0eek(z0ZzZzush p0, z0ZzZzcah p1)
	{
		if (p0 == null)
		{
			return new z0ZzZzush(p1);
		}
		p0.z0eek();
		return p0;
	}

	private bool z0yek()
	{
		bool num = z0xek.z0ya();
		z0xek.z0ua();
		if (num)
		{
			return false;
		}
		if (!z0eek(p0: false))
		{
			if (z0xek.z0la() != (z0ZzZzbah)15)
			{
				throw new z0ZzZzeah();
			}
			z0xek.z0ua();
			return false;
		}
		z0vek = z0rhj.z0tek;
		z0oek = false;
		return true;
	}
}
