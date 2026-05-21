using System;
using System.Collections.Generic;
using System.IO;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzbpk : IDisposable
{
	internal List<z0ZzZzrfh> z0pek;

	private z0ZzZzbej z0mek;

	private z0ZzZzrej z0nek;

	internal Dictionary<byte[], z0ZzZzedh> z0bek;

	private bool z0vek;

	private z0ZzZzcxk z0cek;

	public void z0eek(string p0, z0ZzZzsdh p1, z0ZzZztfh p2, z0ZzZzbdh p3, z0ZzZzlsh p4)
	{
		if (z0pek != null)
		{
			return;
		}
		if (z0vek)
		{
			if (z0mek != null)
			{
				z0mek.z0ihk(p0, p1.z0pek(), p1.z0yek(), p1.z0mek(), Color.Black, p3, p4);
			}
			else
			{
				z0nek.z0rek(p0, p1, z0ZzZzyfh.z0uek, p3, p4, z0cek);
			}
		}
		else if (z0mek != null)
		{
			z0mek.z0ihk(p0, p1.z0pek(), p1.z0yek(), p1.z0mek(), (p2 is z0ZzZzzdh) ? ((z0ZzZzzdh)p2).z0eek : Color.Black, p3, p4);
		}
		else
		{
			z0nek.z0rek(p0, p1, p2, p3, p4, z0cek);
		}
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzbdh p1)
	{
		if (z0pek == null)
		{
			if (z0mek != null)
			{
				z0mek.z0yhk(p0, p1.z0tek(), p1.z0yek(), p1.z0uek(), p1.z0iek());
			}
			else
			{
				z0nek.z0rek(p0, p1);
			}
		}
	}

	public string z0eek()
	{
		if (z0nek == null)
		{
			return null;
		}
		return z0nek.z0xek().z0yek().z0tek();
	}

	public void z0eek(string p0)
	{
		if (z0nek != null)
		{
			z0nek.z0xek().z0yek().z0uek(p0);
		}
	}

	public void z0rek(z0ZzZzudh p0, z0ZzZzbdh p1)
	{
		if (z0pek == null)
		{
			if (z0mek != null)
			{
				z0mek.z0nhk(p0, p1.z0tek(), p1.z0yek(), p1.z0uek(), p1.z0iek(), 0f);
			}
			else
			{
				z0nek.z0eek(p0, p1);
			}
		}
	}

	public void z0eek(z0ZzZzudh p0, float p1, float p2, float p3, float p4, float p5)
	{
		if (z0pek == null)
		{
			if (z0mek != null)
			{
				z0mek.z0nhk(p0, p1, p2, p3, p4, p5);
			}
			else
			{
				z0nek.z0eek(p0, new z0ZzZzbdh(p1, p2, p3, p4));
			}
		}
	}

	public void z0eek(object p0)
	{
		if (z0mek != null)
		{
			z0mek.z0ehk(p0);
		}
		else
		{
			z0nek.z0eek(p0);
		}
	}

	public void z0eek(GraphicsUnit p0)
	{
		if (z0mek != null)
		{
			z0mek.z0vhk(p0);
		}
		else
		{
			z0nek.z0rek(p0);
		}
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzpdh[] p1)
	{
		if (z0pek == null)
		{
			if (z0mek != null)
			{
				z0mek.z0egk(p0, p1);
			}
			else
			{
				z0nek.z0eek(p0, p1);
			}
		}
	}

	public void z0eek(z0ZzZztfh p0, z0ZzZzbdh p1)
	{
		if (z0pek == null)
		{
			if (z0mek != null)
			{
				z0mek.z0rgk(p0, p1.z0tek(), p1.z0yek(), p1.z0uek(), p1.z0iek());
			}
			else
			{
				z0nek.z0rek(p0, p1);
			}
		}
	}

	public z0ZzZzjdh z0rek()
	{
		if (z0mek != null)
		{
			return z0mek.z0wgk();
		}
		return z0nek.z0oek();
	}

	public void z0eek(float p0, float p1)
	{
		if (z0mek != null)
		{
			z0mek.z0phk(p0, p1);
		}
		else
		{
			z0nek.z0eek(new z0ZzZzxdh(p0, p1), 10000);
		}
	}

	public void z0eek(bool p0)
	{
		z0vek = p0;
	}

	public void z0eek(string p0, string p1, float p2, FontStyle p3, z0ZzZztfh p4, z0ZzZzbdh p5, z0ZzZzlsh p6)
	{
		if (z0pek != null)
		{
			return;
		}
		if (z0vek)
		{
			if (z0mek != null)
			{
				z0mek.z0ihk(p0, p1, p2, p3, Color.Black, p5, p6);
			}
			else
			{
				z0nek.z0rek(p0, new z0ZzZzpej(p1, p2, p3), z0ZzZzyfh.z0uek, p5, p6, z0cek);
			}
		}
		else if (z0mek != null)
		{
			z0mek.z0ihk(p0, p1, p2, p3, (p4 is z0ZzZzzdh) ? ((z0ZzZzzdh)p4).z0eek : Color.Black, p5, p6);
		}
		else
		{
			z0nek.z0rek(p0, new z0ZzZzpej(p1, p2, p3), p4, p5, p6, z0cek);
		}
	}

	public void z0rek(string p0)
	{
		if (z0nek != null)
		{
			z0nek.z0xek().z0yek().z0iek(p0);
		}
	}

	public void z0eek(z0ZzZztfh p0, float p1, float p2, float p3, float p4, float p5)
	{
		if (z0pek == null)
		{
			if (z0mek != null)
			{
				z0mek.z0lgk(p0, p1, p2, p3, p4, p5);
			}
			else
			{
				z0nek.z0eek(p0, p1, p2, p3, p4);
			}
		}
	}

	public bool z0tek()
	{
		return z0vek;
	}

	public z0ZzZzbpk(Stream p0, bool p1 = false)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (p1)
		{
			z0mek = z0ZzZzbej.z0eek(p0, p1: false);
			return;
		}
		z0nek = new z0ZzZzrej(p0, new z0ZzZzazk(), p2: false);
		z0cek = z0nek.z0rek();
	}

	public void z0eek(z0ZzZzedh p0, z0ZzZzbdh p1, bool p2, byte[] p3)
	{
		if (z0mek != null)
		{
			z0mek.z0ahk(p0, p1.z0tek(), p1.z0yek(), p1.z0uek(), p1.z0iek(), p3);
		}
		else if (z0pek != null)
		{
			if (!(p0 is z0ZzZzrfh))
			{
				return;
			}
			z0ZzZzrfh z0ZzZzrfh2 = (z0ZzZzrfh)p0;
			if (z0ZzZzrfh2.z0eek() == null || z0ZzZzrfh2.z0eek().Length == 0)
			{
				return;
			}
			foreach (z0ZzZzrfh item in z0pek)
			{
				if (z0ZzZzeyk.z0rek(item.z0eek(), z0ZzZzrfh2.z0eek()))
				{
					return;
				}
			}
			z0pek.Add(z0ZzZzrfh2);
		}
		else
		{
			if (z0bek != null && p0 is z0ZzZzrfh z0ZzZzrfh3 && z0ZzZzrfh3.z0eek() != null && z0bek.TryGetValue(z0ZzZzrfh3.z0eek(), out var z0ZzZzedh2) && z0ZzZzedh2 is z0ZzZzrfh z0ZzZzrfh4 && z0ZzZzrfh4.z0eek() != null)
			{
				p3 = z0ZzZzrfh4.z0eek();
			}
			z0nek.z0eek(p0, p1, p3);
		}
	}

	public void z0eek(z0ZzZzudh p0, float p1, float p2, float p3, float p4)
	{
		if (z0pek == null)
		{
			if (z0mek != null)
			{
				z0mek.z0uhk(p0, p1, p2, p3, p4);
			}
			else
			{
				z0nek.z0eek(p0, p1, p2, p3, p4);
			}
		}
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		if (z0mek != null)
		{
			z0mek.z0sgk(p0);
		}
		else
		{
			z0nek.z0eek(p0);
		}
	}

	public void Dispose()
	{
		if (z0mek != null)
		{
			z0mek.Dispose();
			z0mek = null;
		}
		if (z0cek != null)
		{
			z0cek.Dispose();
			z0cek = null;
		}
		if (z0nek != null)
		{
			if (z0pek == null)
			{
				z0nek.Dispose();
			}
			else
			{
				z0pek.Clear();
				z0pek = null;
				z0nek.z0tgk();
				z0nek = null;
			}
			z0nek = null;
		}
	}

	public void z0eek(z0ZzZzjdh p0)
	{
		if (z0mek != null)
		{
			z0mek.z0qgk_jiejie20260327142557(p0);
		}
		else
		{
			z0nek.z0eek(p0);
		}
	}

	public z0ZzZzbpk(z0ZzZzbej p0)
	{
		z0mek = p0;
		z0cek = new z0ZzZzvxk();
	}

	public string z0yek()
	{
		if (z0nek == null)
		{
			return null;
		}
		return z0nek.z0xek().z0yek().z0mek();
	}

	public GraphicsUnit z0uek()
	{
		if (z0mek != null)
		{
			return z0mek.z0ohk();
		}
		return z0nek.z0zek();
	}

	public z0ZzZzbej z0iek()
	{
		return z0mek;
	}

	public object z0oek()
	{
		if (z0mek != null)
		{
			return z0mek.z0agk();
		}
		return z0nek.z0mek();
	}

	public void z0rek(float p0, float p1)
	{
		if (z0mek != null)
		{
			z0mek.z0dhk(p0, p1);
			return;
		}
		z0nek.z0oek().z0tek_jiejie20260327142557();
		z0nek.z0oek().z0eek(p0, p1);
	}

	public void z0eek(z0ZzZzedh p0, z0ZzZzbdh p1, byte[] p2)
	{
		if (z0mek != null)
		{
			z0mek.z0ahk(p0, p1.z0tek(), p1.z0yek(), p1.z0uek(), p1.z0iek(), p2);
		}
		else if (z0pek != null)
		{
			if (!(p0 is z0ZzZzrfh))
			{
				return;
			}
			z0ZzZzrfh z0ZzZzrfh2 = (z0ZzZzrfh)p0;
			if (z0ZzZzrfh2.z0eek() == null || z0ZzZzrfh2.z0eek().Length == 0)
			{
				return;
			}
			foreach (z0ZzZzrfh item in z0pek)
			{
				if (z0ZzZzeyk.z0rek(item.z0eek(), z0ZzZzrfh2.z0eek()))
				{
					return;
				}
			}
			z0pek.Add(z0ZzZzrfh2);
		}
		else
		{
			if (z0bek != null && p0 is z0ZzZzrfh z0ZzZzrfh3 && z0ZzZzrfh3.z0eek() != null && z0bek.TryGetValue(z0ZzZzrfh3.z0eek(), out var z0ZzZzedh2) && z0ZzZzedh2 is z0ZzZzrfh z0ZzZzrfh4 && z0ZzZzrfh4.z0eek() != null)
			{
				p2 = z0ZzZzrfh4.z0eek();
			}
			z0nek.z0eek(p0, p1, p2);
		}
	}
}
