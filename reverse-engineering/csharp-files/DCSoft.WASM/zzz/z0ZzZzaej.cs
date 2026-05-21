using System;
using System.IO;

namespace zzz;

public class z0ZzZzaej : z0ZzZzygj
{
	private bool z0iek;

	private z0ZzZzgwj z0oek;

	private int z0pek = 96;

	private z0ZzZzgqj z0mek;

	private z0ZzZzblj z0nek;

	internal void z0eek(z0ZzZzmlj p0)
	{
		if (p0 != null)
		{
			z0oek.z0eek(p0.z0xek());
		}
	}

	internal z0ZzZzohj z0eek(z0ZzZzedh p0, byte[] p1)
	{
		return z0nek.z0eek().z0rek(p0, z0pek, p1);
	}

	internal z0ZzZzaej(Stream p0, z0ZzZzazk p1, bool p2)
	{
		z0mek = new z0ZzZzgqj(p0, z0eek(p1, p2), p2: true);
		z0pek = p1.z0iek();
		z0nek = new z0ZzZzblj(z0mek.z0uek());
		z0ZzZzmhj obj = z0nek.z0eek();
		obj.z0rek(p1.z0eek());
		obj.z0rek((long)p1.z0yek_jiejie20260327142557());
		z0ZzZzszk z0ZzZzszk2 = p1.z0tek();
		if (z0ZzZzszk2 != null)
		{
			z0mek.z0yek(z0ZzZzszk2.z0eek());
			z0mek.z0tek(z0ZzZzszk2.z0yek());
			z0mek.z0rek(z0ZzZzszk2.z0oek());
			z0mek.z0iek(z0ZzZzszk2.z0uek());
			z0mek.z0eek(z0ZzZzszk2.z0rek());
			z0mek.z0uek(z0ZzZzszk2.z0tek());
		}
		z0iek = p1.z0rek() != (z0ZzZzdzk)1;
	}

	internal bool z0eek()
	{
		return z0iek;
	}

	internal z0ZzZzmlj z0eek(z0ZzZzxdh p0, int p1, float p2, bool p3)
	{
		double num = p0.z0rek() * 72f / p2;
		double num2 = p0.z0tek() * 72f / p2;
		z0ZzZziwj z0ZzZziwj2 = new z0ZzZziwj(0.0, 0.0, p3 ? ((double)(int)Math.Round(num, MidpointRounding.AwayFromZero)) : num, p3 ? ((double)(int)Math.Round(num2, MidpointRounding.AwayFromZero)) : num2);
		if (p1 > z0mek.z0yek().Count)
		{
			p1 = z0mek.z0yek().Count;
		}
		z0oek = z0mek.z0eek(p1 + 1, z0ZzZziwj2);
		return new z0ZzZzmlj(z0ZzZziwj2, ((z0ZzZzswj)z0oek).z0rek(), z0nek, p2, p2);
	}

	internal z0ZzZzddj z0eek(z0ZzZzpej p0)
	{
		return z0nek.z0uek().z0eek(p0);
	}

	private static z0ZzZzxaj z0eek(z0ZzZzazk p0, bool p1)
	{
		z0ZzZzxaj z0ZzZzxaj2 = new z0ZzZzxaj();
		switch (p0.z0rek())
		{
		case (z0ZzZzdzk)1:
			z0ZzZzxaj2.z0rek((z0ZzZzbaj)1);
			break;
		case (z0ZzZzdzk)2:
			z0ZzZzxaj2.z0rek((z0ZzZzbaj)2);
			break;
		case (z0ZzZzdzk)3:
			z0ZzZzxaj2.z0rek((z0ZzZzbaj)3);
			break;
		default:
			z0ZzZzxaj2.z0rek((z0ZzZzbaj)0);
			break;
		}
		z0ZzZzxaj2.z0eek(p0.z0uek().Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries));
		z0ZzZzxaj2.z0rek(p1);
		return z0ZzZzxaj2;
	}

	protected override void z0ygk(bool p0)
	{
		if (p0)
		{
			z0eek(p0: false);
			z0nek.Dispose();
		}
	}

	internal void z0eek(bool p0 = false)
	{
		if (z0mek != null)
		{
			if (p0)
			{
				z0nek.z0uek().Dispose();
				z0mek.z0eek(p0: true);
				z0oek = null;
			}
			else
			{
				z0nek.z0uek().z0tek();
				z0mek.z0eek(p0);
			}
			z0mek = null;
		}
	}

	internal bool z0rek()
	{
		return z0nek.z0eek().z0rek();
	}

	internal void z0tek()
	{
		if (z0mek != null)
		{
			z0nek.z0uek().Dispose();
			z0nek.Dispose();
			z0nek = null;
			z0mek.z0oek();
			z0oek = null;
			z0mek = null;
		}
	}

	public z0ZzZzgqj z0yek()
	{
		return z0mek;
	}

	internal void z0uek()
	{
		if (z0oek != null)
		{
			z0oek.z0cgk(z0yek().z0uek().z0uek());
		}
	}
}
