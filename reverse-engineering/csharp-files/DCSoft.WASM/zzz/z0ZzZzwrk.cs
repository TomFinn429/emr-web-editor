using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzwrk
{
	private Color z0cek = Color.Black;

	private string z0xek = string.Empty;

	private z0ZzZzrrk z0zek = (z0ZzZzrrk)10;

	private bool z0lrk;

	private StringAlignment z0krk = StringAlignment.Center;

	private int z0jrk;

	private string z0hrk = string.Empty;

	private float z0grk = 2f;

	private z0ZzZzimk z0frk = new z0ZzZzimk();

	private bool z0drk = true;

	private float z0srk;

	private bool z0ark;

	private string z0qrk;

	public string z0eek()
	{
		return z0xek;
	}

	public float z0rek()
	{
		return z0grk;
	}

	public void z0eek(bool p0)
	{
		z0drk = p0;
	}

	public void z0eek(StringAlignment p0)
	{
		z0krk = p0;
	}

	public z0ZzZzimk z0tek_jiejie20260327142557()
	{
		return z0frk;
	}

	public int z0yek()
	{
		return z0jrk;
	}

	public void z0eek(Color p0)
	{
		z0cek = p0;
	}

	public bool z0uek()
	{
		return z0drk;
	}

	public bool z0iek()
	{
		return z0lrk;
	}

	public StringAlignment z0oek()
	{
		return z0krk;
	}

	public void z0eek(z0ZzZzimk p0)
	{
		z0frk = p0;
	}

	public float z0pek()
	{
		return z0srk;
	}

	public string z0mek()
	{
		return z0qrk;
	}

	public void z0eek(z0ZzZzrrk p0)
	{
		z0zek = p0;
	}

	public Color z0nek()
	{
		return z0cek;
	}

	public List<z0ZzZzbdh> z0eek(z0ZzZzbdh p0)
	{
		if (!z0ark)
		{
			z0vek();
		}
		if (z0hrk == null || z0hrk.Trim().Length == 0)
		{
			return null;
		}
		List<z0ZzZzbdh> list = new List<z0ZzZzbdh>();
		float num = 0f;
		switch (z0zek)
		{
		case (z0ZzZzrrk)1:
		case (z0ZzZzrrk)2:
		case (z0ZzZzrrk)3:
		case (z0ZzZzrrk)4:
		case (z0ZzZzrrk)5:
		case (z0ZzZzrrk)6:
		case (z0ZzZzrrk)7:
		case (z0ZzZzrrk)8:
		case (z0ZzZzrrk)9:
		case (z0ZzZzrrk)10:
		case (z0ZzZzrrk)11:
		case (z0ZzZzrrk)12:
		case (z0ZzZzrrk)13:
		case (z0ZzZzrrk)15:
		case (z0ZzZzrrk)16:
		case (z0ZzZzrrk)17:
		case (z0ZzZzrrk)18:
		case (z0ZzZzrrk)19:
		case (z0ZzZzrrk)20:
		case (z0ZzZzrrk)21:
		case (z0ZzZzrrk)22:
		case (z0ZzZzrrk)23:
		case (z0ZzZzrrk)24:
		case (z0ZzZzrrk)25:
		case (z0ZzZzrrk)26:
		case (z0ZzZzrrk)27:
		case (z0ZzZzrrk)28:
		case (z0ZzZzrrk)29:
		case (z0ZzZzrrk)30:
		{
			if (z0iek())
			{
				z0grk = p0.z0uek() / (float)z0hrk.Length;
				z0srk = p0.z0uek();
			}
			float num2 = p0.z0oek();
			for (int j = 0; j < z0hrk.Length; j++)
			{
				if (z0hrk[j] == '1')
				{
					list.Add(new z0ZzZzbdh(num2, p0.z0pek(), z0grk, p0.z0iek() - num));
				}
				num2 += z0grk;
			}
			break;
		}
		case (z0ZzZzrrk)14:
		{
			if (z0iek())
			{
				z0grk = 0.5f * p0.z0uek() / (float)z0hrk.Length;
				z0srk = p0.z0uek();
			}
			for (int i = 0; i < z0hrk.Length; i++)
			{
				if (z0hrk[i] == '1')
				{
					list.Add(new z0ZzZzbdh(p0.z0oek() + (float)i * z0grk * 2f, p0.z0pek(), z0grk, p0.z0iek() - num));
				}
				else
				{
					list.Add(new z0ZzZzbdh(p0.z0oek() + (float)i * z0grk * 2f, p0.z0pek(), z0grk, (p0.z0iek() - num) / 2f));
				}
			}
			break;
		}
		default:
			return null;
		}
		return list;
	}

	public void z0eek(float p0)
	{
		z0grk = p0;
		z0ark = false;
	}

	public void z0rek(bool p0)
	{
		z0lrk = p0;
	}

	public z0ZzZzrrk z0bek()
	{
		return z0zek;
	}

	public void z0eek(string p0)
	{
		z0xek = p0;
		z0ark = false;
	}

	public bool z0vek()
	{
		z0qrk = null;
		if (z0xek == null || z0xek.Trim().Length == 0)
		{
			z0qrk = z0ZzZziok.z0oyk();
			z0hrk = string.Empty;
			return false;
		}
		z0hrk = string.Empty;
		z0ZzZzerk z0ZzZzerk2;
		switch (z0zek)
		{
		case (z0ZzZzrrk)1:
		case (z0ZzZzrrk)25:
			z0ZzZzerk2 = new z0ZzZzltk(z0xek);
			break;
		case (z0ZzZzrrk)5:
		case (z0ZzZzrrk)26:
			z0ZzZzerk2 = new z0ZzZzprk(z0xek);
			break;
		case (z0ZzZzrrk)7:
			z0ZzZzerk2 = new z0ZzZznrk(z0xek);
			break;
		case (z0ZzZzrrk)8:
		case (z0ZzZzrrk)9:
			z0ZzZzerk2 = new z0ZzZzzrk(z0xek);
			break;
		case (z0ZzZzrrk)10:
		case (z0ZzZzrrk)27:
			z0ZzZzerk2 = new z0ZzZzirk(z0xek);
			break;
		case (z0ZzZzrrk)11:
			z0ZzZzerk2 = new z0ZzZzirk(z0xek, p1: true);
			break;
		case (z0ZzZzrrk)12:
			z0ZzZzerk2 = new z0ZzZzork(z0xek);
			break;
		case (z0ZzZzrrk)13:
			z0ZzZzerk2 = new z0ZzZztrk(z0xek);
			break;
		case (z0ZzZzrrk)14:
			z0ZzZzerk2 = new z0ZzZzxrk(z0xek);
			break;
		case (z0ZzZzrrk)15:
		case (z0ZzZzrrk)16:
			z0ZzZzerk2 = new z0ZzZzbrk(z0xek);
			break;
		case (z0ZzZzrrk)17:
			z0ZzZzerk2 = new z0ZzZzvrk(z0xek);
			break;
		case (z0ZzZzrrk)3:
			z0ZzZzerk2 = new z0ZzZzjtk(z0xek);
			break;
		case (z0ZzZzrrk)18:
		case (z0ZzZzrrk)19:
		case (z0ZzZzrrk)20:
		case (z0ZzZzrrk)21:
		case (z0ZzZzrrk)22:
			z0ZzZzerk2 = new z0ZzZzcrk(z0xek, z0zek);
			break;
		case (z0ZzZzrrk)4:
			z0ZzZzerk2 = new z0ZzZzhtk(z0xek);
			break;
		case (z0ZzZzrrk)2:
			z0ZzZzerk2 = new z0ZzZzktk(z0xek);
			break;
		case (z0ZzZzrrk)6:
			z0ZzZzerk2 = new z0ZzZzmrk(z0xek);
			break;
		case (z0ZzZzrrk)23:
		case (z0ZzZzrrk)24:
			z0ZzZzerk2 = new z0ZzZzyrk(z0xek);
			break;
		case (z0ZzZzrrk)28:
			z0ZzZzerk2 = new z0ZzZzurk(z0xek, z0ZzZzurk.z0zok.z0rek);
			break;
		case (z0ZzZzrrk)29:
			z0ZzZzerk2 = new z0ZzZzurk(z0xek, z0ZzZzurk.z0zok.z0tek);
			break;
		case (z0ZzZzrrk)30:
			z0ZzZzerk2 = new z0ZzZzurk(z0xek, z0ZzZzurk.z0zok.z0yek);
			break;
		default:
			z0qrk = z0ZzZziok.z0hyk();
			return false;
		}
		z0ZzZzerk2.z0rek = null;
		z0hrk = z0ZzZzerk2.z0nwk();
		z0qrk = z0ZzZzerk2.z0rek;
		z0ark = true;
		if (z0hrk != null)
		{
			switch (z0zek)
			{
			case (z0ZzZzrrk)1:
			case (z0ZzZzrrk)2:
			case (z0ZzZzrrk)3:
			case (z0ZzZzrrk)4:
			case (z0ZzZzrrk)5:
			case (z0ZzZzrrk)6:
			case (z0ZzZzrrk)7:
			case (z0ZzZzrrk)8:
			case (z0ZzZzrrk)9:
			case (z0ZzZzrrk)10:
			case (z0ZzZzrrk)11:
			case (z0ZzZzrrk)12:
			case (z0ZzZzrrk)13:
			case (z0ZzZzrrk)15:
			case (z0ZzZzrrk)16:
			case (z0ZzZzrrk)17:
			case (z0ZzZzrrk)18:
			case (z0ZzZzrrk)19:
			case (z0ZzZzrrk)20:
			case (z0ZzZzrrk)21:
			case (z0ZzZzrrk)22:
			case (z0ZzZzrrk)23:
			case (z0ZzZzrrk)24:
			case (z0ZzZzrrk)25:
			case (z0ZzZzrrk)26:
			case (z0ZzZzrrk)27:
			case (z0ZzZzrrk)28:
			case (z0ZzZzrrk)29:
			case (z0ZzZzrrk)30:
				z0srk = (float)z0hrk.Length * z0grk;
				break;
			case (z0ZzZzrrk)14:
				z0srk = (float)z0hrk.Length * z0grk * 2f;
				break;
			default:
				z0srk = 0f;
				return false;
			}
			return true;
		}
		return false;
	}

	public void z0eek(int p0)
	{
		z0jrk = p0;
	}
}
