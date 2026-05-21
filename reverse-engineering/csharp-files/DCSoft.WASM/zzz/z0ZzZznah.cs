using System;
using System.Text;

namespace zzz;

internal sealed class z0ZzZznah
{
	internal struct z0fgj
	{
		internal string z0eek;

		internal string z0rek;

		internal z0fgj(string p0, string p1)
		{
			z0eek = p0;
			z0rek = p1;
		}
	}

	internal z0fgj[] z0grk = new z0fgj[2]
	{
		new z0fgj(null, null),
		new z0fgj(null, null)
	};

	private int z0frk;

	private readonly bool z0srk;

	private int z0ark;

	private bool z0qrk;

	private z0ZzZzoah z0wrk;

	private z0ZzZzoah z0erk;

	private z0ZzZzoah z0rrk;

	private int z0trk;

	private bool z0yrk;

	internal z0fgj[] z0irk = new z0fgj[3]
	{
		new z0fgj(null, null),
		new z0fgj(null, null),
		new z0fgj(null, null)
	};

	private int z0ork;

	private int z0prk;

	private readonly z0ZzZziah z0mrk;

	private readonly z0ZzZzfah z0brk;

	private int z0vrk;

	public string z0eek()
	{
		return z0rrk.z0ag();
	}

	public bool z0eek(ref int p0, ref bool p1, ref z0ZzZzbah p2)
	{
		if (z0trk != -1)
		{
			if (!z0yrk)
			{
				z0yrk = true;
				p0++;
				p2 = (z0ZzZzbah)3;
				return true;
			}
			return false;
		}
		if (z0rrk.z0mh() == (z0ZzZzbah)2)
		{
			z0ZzZzoah z0ZzZzoah2 = z0rrk.z0iek();
			if (z0ZzZzoah2 != null)
			{
				z0rrk = z0ZzZzoah2;
				p2 = z0rrk.z0mh();
				p0++;
				z0yrk = true;
				return true;
			}
		}
		else if (z0yrk)
		{
			if ((z0rrk.z0mh() == (z0ZzZzbah)5) & p1)
			{
				z0rrk = z0rrk.z0iek();
				p2 = z0rrk.z0mh();
				p0++;
				p1 = false;
				return true;
			}
			z0ZzZzoah z0ZzZzoah3 = z0rrk.z0qf();
			if (z0ZzZzoah3 == null)
			{
				z0ZzZzoah z0ZzZzoah4 = z0rrk.z0ih();
				if (z0ZzZzoah4 != null && z0ZzZzoah4.z0mh() == (z0ZzZzbah)5)
				{
					z0rrk = z0ZzZzoah4;
					p2 = (z0ZzZzbah)16;
					p0--;
					return true;
				}
			}
			if (z0ZzZzoah3 != null)
			{
				z0rrk = z0ZzZzoah3;
				p2 = z0rrk.z0mh();
				return true;
			}
			return false;
		}
		return false;
	}

	public int z0eek(string p0)
	{
		if (z0frk == -1)
		{
			z0krk();
		}
		for (int i = 0; i < z0frk; i++)
		{
			if (z0irk[i].z0eek == p0)
			{
				return i;
			}
		}
		return -1;
	}

	private bool z0eek(z0ZzZzsah p0, string p1, string p2)
	{
		z0ZzZzbsh z0ZzZzbsh2 = ((p2.Length != 0) ? p0.z0rek(p1, p2) : p0.z0tek(p1));
		if (z0ZzZzbsh2 != null)
		{
			z0yrk = false;
			z0wrk = p0;
			z0rrk = z0ZzZzbsh2;
			z0ark = p0.z0sg().z0yek(z0ZzZzbsh2);
			if (z0ark != -1)
			{
				return true;
			}
		}
		return false;
	}

	public string z0rek()
	{
		z0ZzZzbah z0ZzZzbah2 = z0rrk.z0mh();
		if (z0trk != -1)
		{
			if (z0rrk.z0mh() == (z0ZzZzbah)17)
			{
				return z0irk[z0trk].z0rek;
			}
			return z0grk[z0trk].z0rek;
		}
		string text;
		if (z0ZzZzbah2 == (z0ZzZzbah)17)
		{
			StringBuilder stringBuilder = new StringBuilder(string.Empty);
			if (z0frk == -1)
			{
				z0krk();
			}
			for (int i = 0; i < z0frk; i++)
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(3, 2, stringBuilder2);
				appendInterpolatedStringHandler.AppendFormatted(z0irk[i].z0eek);
				appendInterpolatedStringHandler.AppendLiteral("=\"");
				appendInterpolatedStringHandler.AppendFormatted(z0irk[i].z0rek);
				appendInterpolatedStringHandler.AppendLiteral("\"");
				stringBuilder2.Append(ref appendInterpolatedStringHandler);
				if (i != z0frk - 1)
				{
					stringBuilder.Append(' ');
				}
			}
			text = stringBuilder.ToString();
		}
		else
		{
			text = z0rrk.z0rh();
		}
		if (text != null)
		{
			return text;
		}
		return string.Empty;
	}

	private static string z0rek(z0ZzZzsah p0, string p1, string p2)
	{
		return p0.z0rek(p1, p2)?.z0rh();
	}

	public void z0eek(int p0)
	{
		z0erk = z0rrk;
		z0vrk = p0;
		z0prk = z0trk;
		z0ork = z0ark;
		z0qrk = z0yrk;
	}

	internal bool z0tek()
	{
		return z0srk;
	}

	public void z0eek(ref int p0)
	{
		if (z0srk || !z0yrk)
		{
			return;
		}
		if (z0vek())
		{
			p0 -= 2;
		}
		else
		{
			while (z0rrk.z0mh() != (z0ZzZzbah)2 && (z0rrk = z0rrk.z0ih()) != null)
			{
				p0--;
			}
		}
		z0yrk = false;
	}

	public z0ZzZzbah z0yek()
	{
		z0ZzZzbah result = z0rrk.z0mh();
		if (z0trk != -1)
		{
			if (z0yrk)
			{
				return (z0ZzZzbah)3;
			}
			return (z0ZzZzbah)2;
		}
		return result;
	}

	public int z0uek()
	{
		if (z0srk)
		{
			return 0;
		}
		z0ZzZzbah z0ZzZzbah2 = z0rrk.z0mh();
		switch (z0ZzZzbah2)
		{
		case (z0ZzZzbah)1:
			return ((z0ZzZzsah)z0rrk).z0sg().Count;
		default:
			if (!z0yrk || z0ZzZzbah2 == (z0ZzZzbah)17 || z0ZzZzbah2 == (z0ZzZzbah)10)
			{
				break;
			}
			goto case (z0ZzZzbah)2;
		case (z0ZzZzbah)2:
			return z0wrk.z0sg().Count;
		}
		if (z0ZzZzbah2 == (z0ZzZzbah)17)
		{
			if (z0frk != -1)
			{
				return z0frk;
			}
			z0krk();
			return z0frk;
		}
		return 0;
	}

	public bool z0iek()
	{
		z0ZzZzoah z0ZzZzoah2 = z0rrk.z0ih();
		if (z0ZzZzoah2 != null)
		{
			z0rrk = z0ZzZzoah2;
			if (!z0yrk)
			{
				z0ark = 0;
			}
			return true;
		}
		return false;
	}

	public string z0oek_jiejie20260327142557()
	{
		if (z0trk != -1)
		{
			return z0bek();
		}
		if (z0eek(z0rrk.z0mh()))
		{
			return string.Empty;
		}
		return z0rrk.z0ph();
	}

	public bool z0rek(string p0)
	{
		return z0rek(p0, string.Empty);
	}

	public bool z0pek()
	{
		z0ZzZzoah z0ZzZzoah2 = z0rrk.z0iek();
		if (z0ZzZzoah2 != null)
		{
			z0rrk = z0ZzZzoah2;
			if (!z0yrk)
			{
				z0ark = -1;
			}
			return true;
		}
		return false;
	}

	public string z0mek()
	{
		return z0rrk.z0tg();
	}

	public void z0rek(ref int p0)
	{
		z0rrk = z0erk;
		p0 = z0vrk;
		z0trk = z0prk;
		z0ark = z0ork;
		z0yrk = z0qrk;
	}

	public string z0eek(string p0, string p1)
	{
		if (z0srk)
		{
			return null;
		}
		return z0rrk.z0mh() switch
		{
			(z0ZzZzbah)1 => z0rek((z0ZzZzsah)z0rrk, p0, p1), 
			(z0ZzZzbah)2 => z0rek((z0ZzZzsah)z0wrk, p0, p1), 
			(z0ZzZzbah)17 => (p1.Length == 0) ? z0eek((z0ZzZzgah)z0rrk, p0) : null, 
			_ => null, 
		};
	}

	public void z0rek(int p0)
	{
		if (z0srk)
		{
			return;
		}
		switch (z0rrk.z0mh())
		{
		case (z0ZzZzbah)1:
		{
			z0tek(p0);
			z0ZzZzbsh z0ZzZzbsh2 = ((z0ZzZzsah)z0rrk).z0sg().z0rek(p0);
			if (z0ZzZzbsh2 != null)
			{
				z0wrk = z0rrk;
				z0rrk = z0ZzZzbsh2;
				z0ark = p0;
			}
			break;
		}
		case (z0ZzZzbah)2:
		{
			z0tek(p0);
			z0ZzZzbsh z0ZzZzbsh2 = ((z0ZzZzsah)z0wrk).z0sg().z0rek(p0);
			if (z0ZzZzbsh2 != null)
			{
				z0rrk = z0ZzZzbsh2;
				z0ark = p0;
			}
			break;
		}
		case (z0ZzZzbah)10:
		case (z0ZzZzbah)17:
			z0tek(p0);
			z0trk = p0;
			break;
		}
	}

	private void z0tek(int p0)
	{
		if (p0 < 0 || p0 >= z0uek())
		{
			throw new ArgumentOutOfRangeException("attributeIndex");
		}
	}

	public z0ZzZzaqh z0nek()
	{
		return z0rrk.z0uf();
	}

	public string z0bek()
	{
		if (z0trk != -1)
		{
			if (z0yrk)
			{
				return string.Empty;
			}
			if (z0rrk.z0mh() == (z0ZzZzbah)17)
			{
				return z0irk[z0trk].z0eek;
			}
			return z0grk[z0trk].z0eek;
		}
		if (z0eek(z0rrk.z0mh()))
		{
			return string.Empty;
		}
		return z0rrk.z0th();
	}

	private bool z0vek()
	{
		z0ZzZzbah z0ZzZzbah2 = z0rrk.z0mh();
		if (z0ZzZzbah2 != (z0ZzZzbah)17)
		{
			return z0ZzZzbah2 == (z0ZzZzbah)10;
		}
		return true;
	}

	public void z0eek(ref int p0, ref z0ZzZzbah p1)
	{
		z0eek(p0);
		if (z0srk)
		{
			return;
		}
		if (z0trk != -1)
		{
			if (z0yrk)
			{
				p0--;
				z0yrk = false;
			}
			z0prk = z0trk;
			p0--;
			z0trk = -1;
			p1 = z0rrk.z0mh();
			return;
		}
		if (z0yrk && z0rrk.z0mh() != (z0ZzZzbah)2)
		{
			z0eek(ref p0);
		}
		if (z0rrk.z0mh() == (z0ZzZzbah)2)
		{
			z0rrk = ((z0ZzZzbsh)z0rrk).z0tek();
			z0ark = -1;
			p0--;
			p1 = (z0ZzZzbah)1;
		}
		if (z0rrk.z0mh() == (z0ZzZzbah)1)
		{
			z0wrk = z0rrk;
		}
	}

	public bool z0cek()
	{
		if (z0trk != -1)
		{
			return true;
		}
		if (z0rrk.z0rh() != null || z0rrk.z0mh() == (z0ZzZzbah)10)
		{
			return true;
		}
		return false;
	}

	public bool z0tek(ref int p0)
	{
		if (z0srk)
		{
			return false;
		}
		switch (z0rrk.z0mh())
		{
		case (z0ZzZzbah)2:
			if (z0ark >= z0wrk.z0sg().Count - 1)
			{
				return false;
			}
			z0rrk = z0wrk.z0sg().z0rek(++z0ark);
			return true;
		case (z0ZzZzbah)1:
			if (z0rrk.z0sg().Count > 0)
			{
				p0++;
				z0wrk = z0rrk;
				z0rrk = z0rrk.z0sg().z0rek(0);
				z0ark = 0;
				return true;
			}
			break;
		case (z0ZzZzbah)17:
			if (z0frk == -1)
			{
				z0krk();
			}
			z0trk++;
			if (z0trk < z0frk)
			{
				if (z0trk == 0)
				{
					p0++;
				}
				z0yrk = false;
				return true;
			}
			z0trk--;
			break;
		}
		return false;
	}

	public string z0tek(string p0)
	{
		if (z0srk)
		{
			return null;
		}
		if (p0 == "xmlns")
		{
			return z0mrk.z0nf("http://www.w3.org/2000/xmlns/");
		}
		if (p0 == "xml")
		{
			return z0mrk.z0nf("http://www.w3.org/XML/1998/namespace");
		}
		if (p0 == null)
		{
			p0 = string.Empty;
		}
		string p1 = ((p0.Length != 0) ? ("xmlns:" + p0) : "xmlns");
		z0ZzZzoah z0ZzZzoah2 = z0rrk;
		while (z0ZzZzoah2 != null)
		{
			if (z0ZzZzoah2.z0mh() == (z0ZzZzbah)1)
			{
				z0ZzZzsah z0ZzZzsah2 = (z0ZzZzsah)z0ZzZzoah2;
				if (z0ZzZzsah2.z0eek())
				{
					z0ZzZzbsh z0ZzZzbsh2 = z0ZzZzsah2.z0tek(p1);
					if (z0ZzZzbsh2 != null)
					{
						return z0ZzZzbsh2.z0rh();
					}
				}
			}
			else if (z0ZzZzoah2.z0mh() == (z0ZzZzbah)2)
			{
				z0ZzZzoah2 = ((z0ZzZzbsh)z0ZzZzoah2).z0tek();
				continue;
			}
			z0ZzZzoah2 = z0ZzZzoah2.z0ih();
		}
		if (p0.Length == 0)
		{
			return string.Empty;
		}
		return null;
	}

	private static bool z0eek(z0ZzZzbah p0)
	{
		switch (p0)
		{
		case (z0ZzZzbah)0:
		case (z0ZzZzbah)3:
		case (z0ZzZzbah)4:
		case (z0ZzZzbah)8:
		case (z0ZzZzbah)9:
		case (z0ZzZzbah)11:
		case (z0ZzZzbah)13:
		case (z0ZzZzbah)14:
		case (z0ZzZzbah)15:
		case (z0ZzZzbah)16:
			return true;
		case (z0ZzZzbah)1:
		case (z0ZzZzbah)2:
		case (z0ZzZzbah)5:
		case (z0ZzZzbah)6:
		case (z0ZzZzbah)7:
		case (z0ZzZzbah)10:
		case (z0ZzZzbah)12:
		case (z0ZzZzbah)17:
			return false;
		default:
			return true;
		}
	}

	public bool z0rek(string p0, string p1)
	{
		if (z0srk)
		{
			return false;
		}
		switch (z0rrk.z0mh())
		{
		case (z0ZzZzbah)1:
			return z0eek((z0ZzZzsah)z0rrk, p0, p1);
		case (z0ZzZzbah)2:
			return z0eek((z0ZzZzsah)z0wrk, p0, p1);
		case (z0ZzZzbah)17:
			if (p1.Length == 0 && (z0trk = z0eek(p0)) != -1)
			{
				z0yrk = false;
				return true;
			}
			break;
		}
		return false;
	}

	public bool z0xek()
	{
		if (z0srk)
		{
			return false;
		}
		switch (z0rrk.z0mh())
		{
		case (z0ZzZzbah)2:
			if (z0wrk != null)
			{
				z0rrk = z0wrk;
				z0ark = -1;
				return true;
			}
			break;
		case (z0ZzZzbah)10:
		case (z0ZzZzbah)17:
			if (z0trk != -1)
			{
				z0trk = -1;
				return true;
			}
			break;
		}
		return false;
	}

	public bool z0zek()
	{
		if (z0rrk.z0mh() != (z0ZzZzbah)2)
		{
			return z0eek(z0rrk);
		}
		return z0eek(z0wrk);
	}

	public z0ZzZziah z0lrk()
	{
		return z0mrk;
	}

	public static string z0eek(z0ZzZzgah p0, string p1)
	{
		return p1 switch
		{
			"version" => p0.z0tek(), 
			"encoding" => p0.z0rek(), 
			"standalone" => p0.z0eek(), 
			_ => null, 
		};
	}

	private bool z0eek(z0ZzZzoah p0)
	{
		z0ZzZzoah z0ZzZzoah2 = p0.z0qf();
		if (z0ZzZzoah2 != null)
		{
			z0rrk = z0ZzZzoah2;
			if (!z0yrk)
			{
				z0ark = -1;
			}
			return true;
		}
		return false;
	}

	private void z0krk()
	{
		int num = 0;
		string text = null;
		if (text != null && text.Length != 0)
		{
			z0irk[num].z0eek = "version";
			z0irk[num].z0rek = text;
			num++;
		}
		text = null;
		if (text != null && text.Length != 0)
		{
			z0irk[num].z0eek = "encoding";
			z0irk[num].z0rek = text;
			num++;
		}
		text = z0brk.z0rek();
		if (text != null && text.Length != 0)
		{
			z0irk[num].z0eek = "standalone";
			z0irk[num].z0rek = text;
			num++;
		}
		z0frk = num;
	}

	public bool z0jrk()
	{
		if (z0rrk.z0mh() == (z0ZzZzbah)2)
		{
			return !((z0ZzZzbsh)z0rrk).z0wh();
		}
		return false;
	}

	public z0ZzZznah(z0ZzZzoah p0)
	{
		z0rrk = p0;
		z0erk = p0;
		z0ZzZzbah num = z0rrk.z0mh();
		if (num == (z0ZzZzbah)2)
		{
			z0wrk = null;
			z0ark = -1;
			z0srk = true;
		}
		else
		{
			z0wrk = p0;
			z0ark = -1;
			z0srk = false;
		}
		if (num == (z0ZzZzbah)9)
		{
			z0brk = (z0ZzZzfah)z0rrk;
		}
		else
		{
			z0brk = p0.z0wg();
		}
		z0mrk = z0brk.z0tek();
		z0trk = -1;
		z0frk = -1;
		z0yrk = false;
		z0qrk = false;
	}

	public bool z0hrk()
	{
		if (z0rrk.z0mh() == (z0ZzZzbah)1)
		{
			return ((z0ZzZzsah)z0rrk).z0rek();
		}
		return false;
	}
}
