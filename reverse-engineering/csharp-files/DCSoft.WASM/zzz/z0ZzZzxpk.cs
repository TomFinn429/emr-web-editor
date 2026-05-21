using System;
using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzxpk
{
	public object z0rek;

	public int z0tek = 1;

	public bool z0yek;

	public int z0uek;

	public bool z0iek;

	public Color z0oek = Color.White;

	public string z0pek = z0ZzZzimk.DefaultFontName;

	internal static z0ZzZzsdh z0mek = null;

	public object z0nek;

	public object z0bek;

	public Color z0vek = Color.Black;

	public bool z0cek;

	private static z0ZzZzlsh z0xek = new z0ZzZzlsh();

	public bool z0zek;

	public bool z0lrk;

	public bool z0krk;

	public int z0jrk;

	public float z0hrk = z0ZzZzimk.DefaultFontSize;

	public bool z0grk;

	public object z0frk;

	public string z0eek()
	{
		return z0eek(z0nek);
	}

	private z0ZzZzbdh z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, bool p2, int p3, z0ZzZzbdh p4)
	{
		string text = z0eek();
		if (string.IsNullOrEmpty(text))
		{
			return z0ZzZzbdh.z0xek;
		}
		if (z0vek.A == 0)
		{
			return z0ZzZzbdh.z0xek;
		}
		using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
		if (!z0cek)
		{
			z0ZzZzlsh2.z0eek((z0ZzZzksh)4096);
		}
		if (z0yek)
		{
			switch (p3)
			{
			case 1:
				z0ZzZzlsh2.z0rek(StringAlignment.Near);
				z0ZzZzlsh2.z0eek(StringAlignment.Near);
				break;
			case 2:
				z0ZzZzlsh2.z0rek(StringAlignment.Center);
				z0ZzZzlsh2.z0eek(StringAlignment.Near);
				break;
			case 4:
				z0ZzZzlsh2.z0rek(StringAlignment.Far);
				z0ZzZzlsh2.z0eek(StringAlignment.Near);
				break;
			case 8:
				z0ZzZzlsh2.z0rek(StringAlignment.Near);
				z0ZzZzlsh2.z0eek(StringAlignment.Far);
				break;
			case 16:
				z0ZzZzlsh2.z0rek(StringAlignment.Center);
				z0ZzZzlsh2.z0eek(StringAlignment.Far);
				break;
			case 32:
				z0ZzZzlsh2.z0rek(StringAlignment.Far);
				z0ZzZzlsh2.z0eek(StringAlignment.Far);
				break;
			}
		}
		else
		{
			z0ZzZzlsh2.z0rek(StringAlignment.Near);
			z0ZzZzlsh2.z0eek(StringAlignment.Near);
			p2 = true;
		}
		z0ZzZzbdh p5 = p1;
		if (p2)
		{
			float num = z0ZzZzrpk.z0eek(5, GraphicsUnit.Pixel, p0.z0vek());
			p5.z0rek(0f - num, 0f - num);
		}
		z0ZzZzimk z0ZzZzimk2 = new z0ZzZzimk(z0pek, z0hrk);
		z0ZzZzimk2.Bold = z0krk;
		z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek(text, z0ZzZzimk2, (int)p1.z0uek(), z0ZzZzlsh2);
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzjmk.z0eek(p5, z0ZzZzxdh2.z0rek(), z0ZzZzxdh2.z0tek(), z0ZzZzlsh2.z0pek(), z0ZzZzlsh2.z0tek());
		if (!p4.z0bek() && !p4.z0tek(z0ZzZzbdh2))
		{
			return z0ZzZzbdh2;
		}
		if (z0oek.A != 0)
		{
			p0.z0eek(z0oek, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek());
		}
		p0.z0eek(text, z0ZzZzimk2, z0vek, z0ZzZzbdh2, z0ZzZzlsh.z0uek());
		return z0ZzZzbdh2;
	}

	private static string z0eek(object p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0 is string)
		{
			return (string)p0;
		}
		if (p0 is z0ZzZzwok)
		{
			return ((z0ZzZzwok)p0).z0tek();
		}
		return p0.ToString();
	}

	private z0ZzZzupk z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, bool p2, int p3)
	{
		string text = z0eek();
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		if (z0vek.A == 0)
		{
			return null;
		}
		z0ZzZzlsh z0ZzZzlsh2 = z0xek;
		if (!z0cek)
		{
			z0ZzZzlsh2.z0eek((z0ZzZzksh)4096);
		}
		if (z0yek)
		{
			switch (p3)
			{
			case 1:
				z0ZzZzlsh2.z0rek(StringAlignment.Near);
				z0ZzZzlsh2.z0eek(StringAlignment.Near);
				break;
			case 2:
				z0ZzZzlsh2.z0rek(StringAlignment.Center);
				z0ZzZzlsh2.z0eek(StringAlignment.Near);
				break;
			case 4:
				z0ZzZzlsh2.z0rek(StringAlignment.Far);
				z0ZzZzlsh2.z0eek(StringAlignment.Near);
				break;
			case 8:
				z0ZzZzlsh2.z0rek(StringAlignment.Near);
				z0ZzZzlsh2.z0eek(StringAlignment.Far);
				break;
			case 16:
				z0ZzZzlsh2.z0rek(StringAlignment.Center);
				z0ZzZzlsh2.z0eek(StringAlignment.Far);
				break;
			case 32:
				z0ZzZzlsh2.z0rek(StringAlignment.Far);
				z0ZzZzlsh2.z0eek(StringAlignment.Far);
				break;
			}
		}
		else
		{
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
		}
		z0ZzZzbdh p4 = p1;
		if (p2)
		{
			float num = z0ZzZzrpk.z0eek(5, GraphicsUnit.Pixel, p0.z0vek());
			p4.z0rek(0f - num, 0f - num);
		}
		z0ZzZzsdh z0ZzZzsdh2 = null;
		z0ZzZzsdh2 = ((z0mek != null && z0mek.z0pek() == z0pek && z0mek.z0yek() == z0hrk && z0mek.z0mek() == (FontStyle)(z0krk ? 1 : 0)) ? z0mek : (z0mek = new z0ZzZzsdh(z0pek, z0hrk, z0krk ? FontStyle.Bold : FontStyle.Regular)));
		z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek(text, z0ZzZzsdh2, (int)p1.z0uek(), z0ZzZzlsh2);
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzjmk.z0eek(p4, z0ZzZzxdh2.z0rek() + 4f, z0ZzZzxdh2.z0tek(), z0ZzZzlsh2.z0pek(), z0ZzZzlsh2.z0tek());
		z0ZzZzupk z0ZzZzupk2 = new z0ZzZzupk();
		z0ZzZzupk2.z0yek = text + z0eek(z0rek);
		z0ZzZzupk2.z0mek = z0vek;
		z0ZzZzupk2.z0nek = z0oek;
		z0ZzZzupk2.z0tek = z0ZzZzbdh2;
		z0ZzZzupk2.z0pek = z0ZzZzsdh2;
		if (!z0yek)
		{
			z0ZzZzupk2.z0oek = Color.Blue;
		}
		return z0ZzZzupk2;
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, bool p2, z0ZzZzipk p3)
	{
		if (p3 == null)
		{
			throw new ArgumentNullException("list");
		}
		if (string.IsNullOrEmpty(z0eek()) || z0vek.A == 0)
		{
			return;
		}
		int count = p3.Count;
		if ((z0tek & 1) == 1)
		{
			z0ZzZzupk z0ZzZzupk2 = z0eek(p0, p1, p2, 1);
			if (z0ZzZzupk2 == null)
			{
				return;
			}
			p3.Add(z0ZzZzupk2);
		}
		if ((z0tek & 2) == 2)
		{
			z0ZzZzupk z0ZzZzupk3 = z0eek(p0, p1, p2, 2);
			if (z0ZzZzupk3 == null)
			{
				return;
			}
			p3.Add(z0ZzZzupk3);
		}
		if ((z0tek & 4) == 4)
		{
			z0ZzZzupk z0ZzZzupk4 = z0eek(p0, p1, p2, 4);
			if (z0ZzZzupk4 == null)
			{
				return;
			}
			p3.Add(z0ZzZzupk4);
		}
		if ((z0tek & 8) == 8)
		{
			z0ZzZzupk z0ZzZzupk5 = z0eek(p0, p1, p2, 8);
			if (z0ZzZzupk5 == null)
			{
				return;
			}
			p3.Add(z0ZzZzupk5);
		}
		if ((z0tek & 0x10) == 16)
		{
			z0ZzZzupk z0ZzZzupk6 = z0eek(p0, p1, p2, 16);
			if (z0ZzZzupk6 == null)
			{
				return;
			}
			p3.Add(z0ZzZzupk6);
		}
		if ((z0tek & 0x20) == 32)
		{
			z0ZzZzupk z0ZzZzupk7 = z0eek(p0, p1, p2, 32);
			if (z0ZzZzupk7 == null)
			{
				return;
			}
			p3.Add(z0ZzZzupk7);
		}
		if (count == p3.Count)
		{
			z0ZzZzupk z0ZzZzupk8 = z0eek(p0, p1, p2, 1);
			if (z0ZzZzupk8 != null)
			{
				p3.Add(z0ZzZzupk8);
			}
		}
	}

	public z0ZzZzbdh[] z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, bool p2, z0ZzZzbdh p3)
	{
		if (string.IsNullOrEmpty(z0eek()))
		{
			return null;
		}
		if (z0vek.A == 0)
		{
			return null;
		}
		List<z0ZzZzbdh> list = new List<z0ZzZzbdh>();
		if (!z0yek)
		{
			z0eek(p0, p1, p2, 1, p3);
			return null;
		}
		if ((z0tek & 1) == 1)
		{
			z0ZzZzbdh z0ZzZzbdh2 = z0eek(p0, p1, p2, 1, p3);
			if (z0ZzZzbdh2.z0bek())
			{
				return null;
			}
			list.Add(z0ZzZzbdh2);
		}
		if ((z0tek & 2) == 2)
		{
			z0ZzZzbdh z0ZzZzbdh3 = z0eek(p0, p1, p2, 2, p3);
			if (z0ZzZzbdh3.z0bek())
			{
				return null;
			}
			list.Add(z0ZzZzbdh3);
		}
		if ((z0tek & 4) == 4)
		{
			z0ZzZzbdh z0ZzZzbdh4 = z0eek(p0, p1, p2, 4, p3);
			if (z0ZzZzbdh4.z0bek())
			{
				return null;
			}
			list.Add(z0ZzZzbdh4);
		}
		if ((z0tek & 8) == 8)
		{
			z0ZzZzbdh z0ZzZzbdh5 = z0eek(p0, p1, p2, 8, p3);
			if (z0ZzZzbdh5.z0bek())
			{
				return null;
			}
			list.Add(z0ZzZzbdh5);
		}
		if ((z0tek & 0x10) == 16)
		{
			z0ZzZzbdh z0ZzZzbdh6 = z0eek(p0, p1, p2, 16, p3);
			if (z0ZzZzbdh6.z0bek())
			{
				return null;
			}
			list.Add(z0ZzZzbdh6);
		}
		if ((z0tek & 0x20) == 32)
		{
			z0ZzZzbdh z0ZzZzbdh7 = z0eek(p0, p1, p2, 32, p3);
			if (z0ZzZzbdh7.z0bek())
			{
				return null;
			}
			list.Add(z0ZzZzbdh7);
		}
		return list.ToArray();
	}
}
