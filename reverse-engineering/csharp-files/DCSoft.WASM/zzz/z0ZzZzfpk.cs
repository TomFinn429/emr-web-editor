using System;
using System.Text;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzfpk
{
	private string z0cek;

	private z0ZzZzimk z0xek;

	private string z0zek;

	private Color z0lrk = Color.Black;

	private float z0krk = 2f;

	public static z0ZzZzimk z0jrk = new z0ZzZzimk(z0ZzZzimk.DefaultFontName, 20f);

	public void z0eek(string p0)
	{
		z0zek = p0;
	}

	public Color z0eek()
	{
		return z0lrk;
	}

	public string z0rek()
	{
		return z0cek;
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, z0ZzZzbdh p2)
	{
		z0eek(z0rek(), p0, p1, p2);
	}

	public bool z0tek()
	{
		string text = "line:s";
		if (string.Compare(z0mek(), text, true) != 0)
		{
			return string.Compare(z0rek(), text, true) == 0;
		}
		return true;
	}

	public void z0eek(z0ZzZzimk p0)
	{
		z0xek = p0;
	}

	public void z0eek(Color p0)
	{
		z0lrk = p0;
	}

	public void z0rek(z0ZzZzjpk p0, z0ZzZzbdh p1, z0ZzZzbdh p2)
	{
		z0eek(z0mek(), p0, p1, p2);
	}

	public z0ZzZzimk z0yek()
	{
		z0ZzZzimk z0ZzZzimk2 = z0xek;
		if (z0ZzZzimk2 == null)
		{
			z0ZzZzimk2 = z0jrk;
		}
		if (z0ZzZzimk2 == null)
		{
			z0ZzZzimk2 = new z0ZzZzimk(z0ZzZzimk.DefaultFontName, 20f);
		}
		return z0ZzZzimk2;
	}

	public z0ZzZzimk z0uek()
	{
		return z0xek;
	}

	public void z0eek(float p0)
	{
		z0krk = p0;
	}

	public void z0rek(string p0)
	{
		z0eek(z0ZzZzlok.z0eek(p0, Color.Black));
	}

	public void z0tek(string p0)
	{
		z0cek = p0;
	}

	public bool z0iek()
	{
		string text = "line:\\";
		if (string.Compare(z0mek(), text, true) != 0)
		{
			return string.Compare(z0rek(), text, true) == 0;
		}
		return true;
	}

	public bool z0oek_jiejie20260327142557()
	{
		string text = "line:/";
		if (string.Compare(z0mek(), text, true) != 0)
		{
			return string.Compare(z0rek(), text, true) == 0;
		}
		return true;
	}

	public string z0pek()
	{
		return z0ZzZzlok.z0eek(z0eek(), Color.Black);
	}

	public string z0mek()
	{
		return z0zek;
	}

	public bool z0nek()
	{
		if (!string.IsNullOrEmpty(z0mek()) || !string.IsNullOrEmpty(z0rek()))
		{
			if (!z0oek_jiejie20260327142557() && !z0iek())
			{
				return !z0tek();
			}
			return false;
		}
		return false;
	}

	private void z0eek(string p0, z0ZzZzjpk p1, z0ZzZzbdh p2, z0ZzZzbdh p3)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return;
		}
		float num = z0ZzZzrpk.z0tek(z0bek(), p1.z0vek());
		if (p2.z0iek() < num)
		{
			return;
		}
		p2.z0tek(0f, 10f);
		p2.z0yek(p2.z0iek() - 20f);
		z0ZzZzsdh value = z0yek().Value;
		float num2 = Math.Max(1f, value.z0yek() / 5f);
		if (value.z0eek())
		{
			num2 *= 2f;
		}
		string text = "2NzY0oLK";
		byte[] array = Convert.FromBase64String(text);
		for (int i = 0; i < 6; i++)
		{
			array[i] = (byte)(array[i] ^ (180 + i));
		}
		text = Encoding.UTF8.GetString(array);
		string text2 = "nJicls7a";
		byte[] array2 = Convert.FromBase64String(text2);
		for (int j = 0; j < 6; j++)
		{
			array2[j] = (byte)(array2[j] ^ (240 + j));
		}
		text2 = Encoding.UTF8.GetString(array2);
		string text3 = "q6Gnr/GQ";
		byte[] array3 = Convert.FromBase64String(text3);
		for (int k = 0; k < 6; k++)
		{
			array3[k] = (byte)(array3[k] ^ (199 + k));
		}
		text3 = Encoding.UTF8.GetString(array3);
		if (string.Compare(p0, text2, true) == 0)
		{
			using (z0ZzZzudh p4 = new z0ZzZzudh(z0eek(), num2))
			{
				p1.z0eek(p4, p2.z0mek(), p2.z0pek(), p2.z0oek(), p2.z0nek());
				return;
			}
		}
		if (string.Compare(p0, text3, true) == 0)
		{
			using (z0ZzZzudh p5 = new z0ZzZzudh(z0eek(), num2))
			{
				p1.z0eek(p5, p2.z0oek(), p2.z0pek(), p2.z0mek(), p2.z0nek());
				return;
			}
		}
		if (string.Compare(p0, text, true) == 0)
		{
			using (z0ZzZzudh p6 = new z0ZzZzudh(z0eek(), num2))
			{
				z0ZzZznfh z0ZzZznfh2 = new z0ZzZznfh();
				z0ZzZznfh2.z0eek(p2.z0oek() + p2.z0uek() / 2f, p2.z0pek(), p2.z0oek() - p2.z0uek() / 2f, p2.z0pek() + p2.z0iek() / 2f, p2.z0mek() + p2.z0uek() / 2f, p2.z0pek() + p2.z0iek() / 2f, p2.z0oek() + p2.z0uek() / 2f, p2.z0nek());
				p1.z0eek(p6, z0ZzZznfh2);
				z0ZzZznfh2.Dispose();
				return;
			}
		}
		z0ZzZzxdh z0ZzZzxdh2 = p1.z0eek("HH", value, 10000, z0ZzZzlsh.z0rek());
		z0ZzZzzdh brush = z0ZzZzyfh.z0eek(z0eek());
		if (p0.StartsWith("--"))
		{
			p0 = p0.Substring(2);
			if (!p3.z0bek() && !p3.z0tek(p2))
			{
				return;
			}
			using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek(StringAlignment.Near);
			p1.DrawString(p0, value, brush, p2, z0ZzZzlsh2);
			return;
		}
		float num3 = 0f;
		if (p0.Length > 0)
		{
			num3 = z0ZzZzxdh2.z0tek() + (p2.z0iek() - z0ZzZzxdh2.z0tek() * (float)p0.Length) / (float)(p0.Length - 1);
		}
		using z0ZzZzlsh z0ZzZzlsh3 = new z0ZzZzlsh();
		z0ZzZzlsh3.z0rek(StringAlignment.Center);
		z0ZzZzlsh3.z0eek(StringAlignment.Near);
		z0ZzZzlsh3.z0eek(z0ZzZzlsh3.z0yek() | (z0ZzZzksh)4096);
		for (int l = 0; l < p0.Length; l++)
		{
			z0ZzZzbdh layoutRectangle = new z0ZzZzbdh(p2.z0oek() + (p2.z0uek() - z0ZzZzxdh2.z0rek()) / 2f, p2.z0pek() + num3 * (float)l, z0ZzZzxdh2.z0rek(), z0ZzZzxdh2.z0tek());
			if (p3.z0bek() || layoutRectangle.z0tek(p3))
			{
				p1.DrawString(p0[l].ToString(), value, brush, layoutRectangle, z0ZzZzlsh3);
			}
		}
	}

	public float z0bek()
	{
		return z0krk;
	}

	public z0ZzZzfpk z0vek()
	{
		z0ZzZzfpk z0ZzZzfpk2 = (z0ZzZzfpk)MemberwiseClone();
		if (z0xek != null)
		{
			z0ZzZzfpk2.z0xek = z0xek.Clone();
		}
		return z0ZzZzfpk2;
	}
}
