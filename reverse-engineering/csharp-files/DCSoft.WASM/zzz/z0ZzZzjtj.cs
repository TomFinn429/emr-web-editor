using System;
using System.Collections;
using System.IO;
using System.Text;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzjtj
{
	private z0ZzZzbyj z0grk;

	private readonly Hashtable z0frk = new Hashtable();

	private z0ZzZzdyj z0drk = new z0ZzZzdyj();

	public static readonly Encoding z0srk = z0ZzZzltj.z0rik;

	private z0ZzZzfyj z0ark = new z0ZzZzfyj();

	private readonly z0ZzZzzrj z0qrk = new z0ZzZzzrj();

	private bool z0wrk = true;

	private bool z0erk = true;

	private readonly z0ZzZzztj z0rrk = new z0ZzZzztj();

	public void z0eek()
	{
		if (!z0wrk)
		{
			z0grk.z0uek();
		}
	}

	public void z0eek(bool p0)
	{
		z0wrk = p0;
	}

	public Hashtable z0rek()
	{
		return z0frk;
	}

	public void z0eek(z0ZzZzbyj p0)
	{
		z0grk = p0;
	}

	public void z0rek(bool p0)
	{
		z0erk = p0;
	}

	public z0ZzZzfyj z0tek()
	{
		return z0ark;
	}

	public void z0eek(z0ZzZzdyj p0)
	{
		z0drk = p0;
	}

	public void z0eek(string p0)
	{
		if (!z0wrk && p0 != null)
		{
			z0grk.z0yek(p0);
		}
	}

	public void z0eek(z0ZzZzfyj p0)
	{
		z0ark = p0;
	}

	public void z0yek()
	{
		if (!z0wrk)
		{
			z0grk.z0uek();
		}
		z0grk.z0rek();
	}

	public virtual bool z0eek(TextWriter p0, Encoding p1 = null)
	{
		z0grk = new z0ZzZzbyj(p0);
		if (p1 == null)
		{
			z0grk.z0eek(z0srk);
		}
		else
		{
			z0grk.z0eek(p1);
		}
		z0grk.z0eek(p0: false);
		return true;
	}

	public z0ZzZzzrj z0uek()
	{
		return z0qrk;
	}

	public void z0iek()
	{
		if (!z0wrk)
		{
			z0grk.z0uek();
		}
	}

	public z0ZzZzdyj z0oek()
	{
		return z0drk;
	}

	public z0ZzZzbyj z0pek()
	{
		return z0grk;
	}

	public void z0rek(string p0)
	{
		if (p0 != null && !z0wrk)
		{
			z0grk.z0uek(p0);
		}
	}

	public z0ZzZzjtj(TextWriter p0, Encoding p1 = null)
	{
		z0qrk.z0eek(p0: true);
		z0eek(p0, p1);
	}

	public z0ZzZzztj z0mek()
	{
		return z0rrk;
	}

	public void z0nek()
	{
		if (!z0wrk)
		{
			z0grk.z0oek();
			z0grk.z0tek("headerf");
		}
	}

	public void z0eek(string p0, bool p1)
	{
		if (!z0wrk)
		{
			z0grk.z0eek(p0, p1);
		}
	}

	public void z0tek(string p0)
	{
		if (!z0wrk)
		{
			z0grk.z0tek(p0);
		}
	}

	public bool z0bek()
	{
		return z0erk;
	}

	public void z0vek()
	{
		if (!z0wrk)
		{
			z0grk.z0oek();
			z0grk.z0tek("header");
		}
	}

	public bool z0cek()
	{
		return z0wrk;
	}

	public void z0xek()
	{
		if (!z0wrk)
		{
			z0grk.z0uek();
		}
	}

	public virtual void z0zek()
	{
		z0grk.z0yek();
	}

	public void z0lrk()
	{
		if (z0wrk)
		{
			z0frk.Clear();
			z0rrk.z0rek();
			z0qrk.z0eek();
			z0rrk.z0rek(z0ZzZzimk.DefaultFontName);
			return;
		}
		z0grk.z0oek();
		z0grk.z0tek("rtf");
		z0grk.z0tek("ansi");
		z0grk.z0tek("ansicpg" + z0grk.z0mek().CodePage);
		if (z0frk.Count > 0)
		{
			z0grk.z0oek();
			z0grk.z0tek("info");
			foreach (string key in z0frk.Keys)
			{
				z0grk.z0oek();
				object obj = z0frk[key];
				if (obj is string)
				{
					z0grk.z0tek(key);
					z0grk.z0uek((string)obj);
				}
				else if (obj is int)
				{
					z0grk.z0tek(key + obj);
				}
				else if (obj is DateTime dateTime)
				{
					z0grk.z0tek(key);
					z0grk.z0tek("yr" + dateTime.Year);
					z0grk.z0tek("mo" + dateTime.Month);
					z0grk.z0tek("dy" + dateTime.Day);
					z0grk.z0tek("hr" + dateTime.Hour);
					z0grk.z0tek("min" + dateTime.Minute);
					z0grk.z0tek("sec" + dateTime.Second);
				}
				else
				{
					z0grk.z0tek(key);
				}
				z0grk.z0uek();
			}
			z0grk.z0uek();
		}
		z0grk.z0oek();
		z0grk.z0tek("fonttbl");
		for (int i = 0; i < z0rrk.z0tek(); i++)
		{
			z0grk.z0oek();
			z0grk.z0tek("f" + i);
			z0ZzZzxtj z0ZzZzxtj2 = z0rrk.z0rek(i);
			if (z0ZzZzxtj2.z0tek() != 1)
			{
				z0grk.z0tek("fcharset" + z0ZzZzxtj2.z0tek());
			}
			z0grk.z0uek(z0ZzZzxtj2.z0iek());
			z0grk.z0uek();
		}
		z0grk.z0uek();
		z0grk.z0oek();
		z0grk.z0tek("colortbl");
		z0grk.z0yek(";");
		for (int j = 0; j < z0qrk.z0rek(); j++)
		{
			Color color = z0qrk.z0eek(j);
			z0grk.z0tek("red" + color.R);
			z0grk.z0tek("green" + color.G);
			z0grk.z0tek("blue" + color.B);
			z0grk.z0yek(";");
		}
		z0grk.z0uek();
		if (z0oek() != null && z0oek().Count > 0)
		{
			if (z0bek())
			{
				z0grk.z0yek(Environment.NewLine);
			}
			z0grk.z0oek();
			z0grk.z0eek("listtable", p1: true);
			foreach (z0ZzZzjyj item in z0oek())
			{
				if (z0bek())
				{
					z0grk.z0yek(Environment.NewLine);
				}
				z0grk.z0oek();
				z0grk.z0tek("list");
				z0grk.z0tek("listtemplateid" + item.z0rek());
				if (item.z0yek())
				{
					z0grk.z0tek("listhybrid");
				}
				if (z0bek())
				{
					z0grk.z0yek(Environment.NewLine);
				}
				foreach (z0ZzZzhyj item2 in item.z0tek())
				{
					z0grk.z0oek();
					z0grk.z0tek("listlevel");
					if (item2.z0eek() != (z0ZzZzbrj)(-10))
					{
						z0grk.z0tek("levelnfc" + Convert.ToInt32(item2.z0eek()));
						z0grk.z0tek("levelnfcn" + Convert.ToInt32(item2.z0eek()));
					}
					z0grk.z0tek("levelstartat" + item2.z0rek());
					z0grk.z0tek("levelfollow" + item2.z0uek());
					z0grk.z0tek("leveljc" + item2.z0yek());
					if (!string.IsNullOrEmpty(item2.z0iek()))
					{
						z0grk.z0oek();
						z0grk.z0tek("leveltext");
						z0grk.z0tek("'0" + item2.z0iek().Length);
						if (item2.z0eek() == (z0ZzZzbrj)23)
						{
							z0grk.z0rek(item2.z0iek());
						}
						else
						{
							z0grk.z0rek(item2.z0iek(), p1: false);
						}
						z0grk.z0uek();
						if (item2.z0eek() == (z0ZzZzbrj)23)
						{
							z0ZzZzxtj z0ZzZzxtj3 = z0mek().z0eek("Wingdings");
							if (z0ZzZzxtj3 != null)
							{
								z0grk.z0tek("f" + z0ZzZzxtj3.z0uek());
							}
						}
						else
						{
							z0grk.z0oek();
							z0grk.z0tek("levelnumbers");
							if (string.IsNullOrEmpty(item2.z0oek()))
							{
								z0grk.z0tek("'01");
							}
							else
							{
								z0grk.z0rek(item2.z0oek(), p1: false);
							}
							z0grk.z0uek();
						}
					}
					z0grk.z0uek();
				}
				z0grk.z0tek("listid" + item.z0uek());
				z0grk.z0uek();
			}
			z0grk.z0uek();
		}
		if (z0tek() != null && z0tek().Count > 0)
		{
			if (z0bek())
			{
				z0grk.z0yek(Environment.NewLine);
			}
			z0grk.z0oek();
			z0grk.z0tek("listoverridetable");
			foreach (z0ZzZzgyj item3 in z0tek())
			{
				if (z0bek())
				{
					z0grk.z0yek(Environment.NewLine);
				}
				z0grk.z0oek();
				z0grk.z0tek("listoverride");
				z0grk.z0tek("listid" + item3.z0eek());
				z0grk.z0tek("listoverridecount" + item3.z0rek_jiejie20260327142557());
				z0grk.z0tek("ls" + item3.z0tek());
				z0grk.z0uek();
			}
			z0grk.z0uek();
		}
		if (z0bek())
		{
			z0grk.z0yek(Environment.NewLine);
		}
		z0grk.z0tek("viewkind1");
	}

	public void z0krk()
	{
		if (!z0wrk)
		{
			z0grk.z0oek();
			z0grk.z0tek("footer");
		}
	}

	public void z0jrk()
	{
		if (!z0wrk)
		{
			z0grk.z0oek();
		}
	}

	public void z0hrk()
	{
		if (!z0wrk)
		{
			z0grk.z0oek();
			z0grk.z0tek("footerf");
		}
	}

	public void z0eek(DashStyle p0)
	{
		if (!z0wrk)
		{
			switch (p0)
			{
			case DashStyle.Dot:
				z0tek("brdrdot");
				break;
			case DashStyle.DashDot:
				z0tek("brdrdashd");
				break;
			case DashStyle.DashDotDot:
				z0tek("brdrdashdd");
				break;
			case DashStyle.Dash:
				z0tek("brdrdash");
				break;
			default:
				z0tek("brdrs");
				break;
			}
		}
	}
}
