using System;
using System.Collections.Generic;
using System.IO;

namespace zzz;

public class z0ZzZzgqj
{
	private readonly z0ZzZzigj z0nek;

	private z0ZzZzmgj z0bek;

	private byte[][] z0vek;

	private readonly z0ZzZzugj z0cek;

	public void z0eek()
	{
		z0cek.z0eek(z0nek.z0tek(z0cek.z0yek().z0rek()));
	}

	private void z0eek(z0ZzZzxaj p0)
	{
		if (p0 != null && p0.z0rek() != 0 && (p0.z0yek() || (p0.z0tek() != null && p0.z0tek().Count != 0)))
		{
			throw new NotSupportedException("ShouldEmbedFonts");
		}
	}

	internal z0ZzZzgqj(Stream p0, z0ZzZzxaj p1, bool p2)
	{
		z0eek(p1);
		z0ZzZzsqj p3 = ((!p2) ? ((z0ZzZzsqj)7) : ((z0ZzZzsqj)4));
		z0ZzZzuxk z0ZzZzuxk2 = new z0ZzZzuxk();
		z0ZzZzuxk2.z0eek(p0);
		z0bek = new z0ZzZzmgj(z0ZzZzuxk2, this, p3);
		z0nek = new z0ZzZzigj();
		z0ZzZzdsj p4 = z0bek.z0oek();
		z0cek = new z0ZzZzugj(p4, p1);
		z0rek(p4);
	}

	public string z0rek()
	{
		return z0nek.z0tek();
	}

	public string z0tek()
	{
		return z0nek.z0iek();
	}

	internal z0ZzZzwsj[] z0eek(z0ZzZzdsj p0)
	{
		DateTimeOffset now = DateTimeOffset.Now;
		z0nek.z0eek(now);
		z0nek.z0rek(now);
		z0eek();
		return new z0ZzZzwsj[2]
		{
			p0.z0oek(z0nek),
			p0.z0oek(z0cek)
		};
	}

	internal IList<z0ZzZzgwj> z0yek()
	{
		return z0cek.z0rek();
	}

	internal void z0rek(z0ZzZzdsj p0)
	{
	}

	internal z0ZzZzugj z0uek()
	{
		return z0cek;
	}

	public string z0iek()
	{
		return z0nek.z0uek();
	}

	internal void z0oek()
	{
		if (z0bek != null)
		{
			z0bek.z0iek();
			z0bek = null;
		}
	}

	internal byte[][] z0pek()
	{
		if (z0vek == null)
		{
			byte[] array = Guid.NewGuid().ToByteArray();
			z0vek = new byte[2][] { array, array };
		}
		return z0vek;
	}

	internal void z0eek(string p0)
	{
		z0nek.z0oek(p0);
	}

	internal z0ZzZzgwj z0eek(int p0, z0ZzZziwj p1)
	{
		return z0eek(p0, p1, null, 0);
	}

	internal void z0rek(string p0)
	{
		z0nek.z0uek(p0);
	}

	public void z0tek(string p0)
	{
		z0nek.z0yek(p0);
	}

	public string z0mek()
	{
		return z0nek.z0mek();
	}

	public void z0yek(string p0)
	{
		z0nek.z0tek(p0);
	}

	public void z0uek(string p0)
	{
		z0nek.z0iek(p0);
	}

	internal void z0eek(bool p0)
	{
		if (z0bek != null)
		{
			if (p0)
			{
				z0bek.z0tek();
			}
			else
			{
				z0bek.z0uek();
			}
			z0bek = null;
		}
	}

	internal z0ZzZzgwj z0eek(int p0, z0ZzZziwj p1, z0ZzZziwj p2, int p3)
	{
		return z0cek.z0eek(p0, p1, p2, p3);
	}

	public void z0iek(string p0)
	{
		z0nek.z0pek(p0);
	}
}
