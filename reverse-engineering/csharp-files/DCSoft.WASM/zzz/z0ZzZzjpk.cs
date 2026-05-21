using System;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzjpk : IDisposable
{
	private static readonly int z0drk = Color.White.ToArgb();

	private bool z0srk;

	private static readonly int z0ark = Color.LightGray.ToArgb();

	private static readonly int z0qrk = Color.AliceBlue.ToArgb();

	private z0ZzZzadh z0wrk;

	private int z0erk;

	private static readonly int z0rrk = Color.Yellow.ToArgb();

	private static readonly int z0trk = Color.White.ToArgb();

	private static readonly int z0yrk = Color.LightYellow.ToArgb();

	private z0ZzZzbpk z0urk;

	private static readonly int z0irk = Color.Black.ToArgb();

	private GraphicsUnit z0ork = GraphicsUnit.Document;

	private static z0ZzZzadh z0prk = null;

	private bool z0mrk = true;

	private static readonly int z0nrk = Color.Black.ToArgb();

	public void z0eek(z0ZzZznmk p0, float p1, float p2, float p3, float p4)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0.Value, p1, p2, p3, p4);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0.Value, p1, p2, p3, p4);
		}
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzpdh p1, z0ZzZzpdh p2)
	{
		z0eek(p0, p1.z0rek(), p1.z0tek(), p2.z0rek(), p2.z0tek());
	}

	public void z0eek(Color p0, z0ZzZzbdh p1)
	{
		if (p0 == Color.Black)
		{
			z0eek(z0ZzZzyfh.z0uek, p1);
			return;
		}
		if (p0 == Color.White)
		{
			z0eek(z0ZzZzyfh.z0iek, p1);
			return;
		}
		using z0ZzZzzdh p2 = new z0ZzZzzdh(p0);
		z0eek(p2, p1);
	}

	public bool z0eek()
	{
		return false;
	}

	public void z0eek(z0ZzZzvdh p0)
	{
		z0erk++;
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0);
		}
	}

	public virtual void z0rek()
	{
		z0wrk?.z0eek();
		z0urk?.z0eek(z0ZzZzbdh.z0xek);
	}

	public void z0eek(z0ZzZztfh p0, float p1, float p2, float p3, float p4, float p5, float p6)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2, p3, p4, p5, p6);
		}
		else if (z0urk?.z0iek() != null)
		{
			z0urk.z0iek().z0kgk(p0, p1, p2, p3, p4, p5, p6);
		}
	}

	public virtual void z0eek(z0ZzZzudh p0, float p1, float p2, float p3, float p4, float p5 = 0f)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1, p2, p3, p4, p5);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2, p3, p4, 0f);
		}
	}

	public virtual void z0eek(z0ZzZzudh p0, z0ZzZzbdh p1)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1);
		}
	}

	public z0ZzZzfdh z0tek()
	{
		if (z0wrk == null)
		{
			return (z0ZzZzfdh)0;
		}
		return z0wrk.z0yek();
	}

	public void z0eek(z0ZzZzedh p0, float p1, float p2, byte[] p3 = null)
	{
		if (z0urk != null)
		{
			float p4 = z0ZzZzrpk.z0eek(p0.z0iek(), GraphicsUnit.Pixel, z0urk.z0uek());
			float p5 = z0ZzZzrpk.z0eek(p0.z0yek(), GraphicsUnit.Pixel, z0urk.z0uek());
			p0 = z0ZzZzovj.z0eek(p0);
			z0urk.z0eek(p0, new z0ZzZzbdh(p1, p2, p4, p5), z0pek(), p3);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2);
		}
	}

	public virtual void z0eek(z0ZzZzpmk p0, z0ZzZzbdh p1, z0ZzZzbdh p2, GraphicsUnit p3)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0.Value, p1, z0pek(), p0.z0mek());
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0.Value, p1, p2, p3);
		}
	}

	public virtual void z0eek(z0ZzZzpmk p0, z0ZzZzbdh p1)
	{
		z0eek(p0.Value, p1, p0.z0mek());
	}

	public void z0eek(Color p0, float p1, z0ZzZznfh p2)
	{
		using z0ZzZzudh p3 = new z0ZzZzudh(p0, p1);
		z0eek(p3, p2);
	}

	public void z0eek(Color p0, z0ZzZzbdh p1, float p2)
	{
		if (z0lrk() != null)
		{
			z0lrk().z0eek(new z0ZzZzzdh(p0), p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), p2);
		}
		else if (z0urk != null)
		{
			z0urk.z0eek(new z0ZzZzzdh(p0), p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), p2);
		}
		else if (z0wrk != null)
		{
			z0wrk.z0rek(z0ZzZzyfh.z0eek(p0), p1);
		}
	}

	public virtual void z0eek(GraphicsUnit p0)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0);
		}
		z0ork = p0;
	}

	public int z0yek()
	{
		return z0erk;
	}

	public z0ZzZzbpk z0uek()
	{
		return z0urk;
	}

	public z0ZzZzjpk(z0ZzZzadh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("g");
		}
		z0wrk = p0;
		z0ork = p0.z0jrk();
	}

	public void z0eek(string p0, z0ZzZzsdh p1, z0ZzZztfh p2, float p3, float p4, z0ZzZzlsh p5)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1, p2, new z0ZzZzbdh(p3, p4, 10000f, 1000f), p5);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2, p3, p4, p5);
		}
	}

	public virtual void z0eek(Color p0, float p1, float p2, float p3, float p4)
	{
		if (z0wrk != null)
		{
			int num = p0.ToArgb();
			if (num == z0qrk)
			{
				z0wrk.z0eek(z0ZzZzyfh.z0pek, p1, p2, p3, p4, 0f);
			}
			else if (num == z0ark)
			{
				z0wrk.z0eek(z0ZzZzyfh.z0zek, p1, p2, p3, p4, 0f);
			}
			else if (num == z0yrk)
			{
				z0wrk.z0eek(z0ZzZzyfh.z0jrk, p1, p2, p3, p4, 0f);
			}
			else if (num == z0rrk)
			{
				z0wrk.z0eek(z0ZzZzyfh.z0vek, p1, p2, p3, p4, 0f);
			}
			else if (num == z0irk)
			{
				z0wrk.z0eek(z0ZzZzyfh.z0uek, p1, p2, p3, p4, 0f);
			}
			else if (num == z0trk)
			{
				z0wrk.z0eek(z0ZzZzyfh.z0iek, p1, p2, p3, p4, 0f);
			}
			else
			{
				z0wrk.z0eek(new z0ZzZzzdh(p0), p1, p2, p3, p4, 0f);
			}
		}
		else if (z0urk != null)
		{
			z0urk.z0eek(new z0ZzZzzdh(p0), p1, p2, p3, p4, 0f);
		}
	}

	public void z0eek(Color p0, float p1, DashStyle p2, float p3, float p4, float p5, float p6)
	{
		if (p1 == 1f && p2 == DashStyle.Solid)
		{
			z0tek(p0, p3, p4, p5, p6);
			return;
		}
		using z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(p0, p1);
		z0ZzZzudh2.z0eek(p2);
		z0eek(z0ZzZzudh2, p3, p4, p5, p6);
	}

	public virtual void z0eek(z0ZzZzjdh p0)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0);
		}
	}

	public void z0eek(z0ZzZznmk p0, z0ZzZznfh p1)
	{
		if (z0wrk != null)
		{
			using (z0ZzZzudh p2 = p0.z0yek())
			{
				z0wrk.z0eek(p2, p1);
			}
		}
	}

	public void z0eek(z0ZzZzudh p0, int p1, int p2, int p3, int p4)
	{
		z0eek(p0, (float)p1, (float)p2, (float)p3, (float)p4);
	}

	public void z0eek(Color p0, float p1, float p2, float p3, float p4, float p5)
	{
		z0eek(p0, new z0ZzZzbdh(p1, p2, p3, p4), p5);
	}

	public void z0eek(z0ZzZzudh p0, float p1, float p2, float p3, float p4, float p5, float p6)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2, p3, p4, p5, p6);
		}
		else if (z0urk?.z0iek() != null)
		{
			z0urk.z0iek().z0fgk(p0, p1, p2, p3, p4, p5, p6);
		}
	}

	public virtual void z0eek(string p0, z0ZzZzimk p1, Color p2, z0ZzZzbdh p3, z0ZzZzlsh p4)
	{
		z0wrk?.z0eek(p0, p1.Value, z0ZzZzyfh.z0eek(p2), p3, p4);
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1.Name, p1.Size, p1.Style, z0ZzZzyfh.z0eek(p2), p3, p4);
		}
	}

	public void DrawString(string s, z0ZzZzsdh font, z0ZzZztfh brush, z0ZzZzbdh layoutRectangle, z0ZzZzlsh format)
	{
		z0wrk?.z0eek(s, font, brush, layoutRectangle, format);
		if (z0urk != null)
		{
			z0urk.z0eek(s, font, brush, layoutRectangle, format);
		}
	}

	public static z0ZzZzjpk z0eek(z0ZzZzedh p0)
	{
		z0ZzZzjpk obj = new z0ZzZzjpk(z0ZzZzadh.z0eek(p0));
		obj.z0eek(p0: true);
		return obj;
	}

	public void z0eek(Color p0, z0ZzZzpdh[] p1)
	{
		z0rek(z0ZzZzidh.z0eek(p0), p1);
	}

	public void z0eek(z0ZzZznmk p0, int p1, int p2, int p3, int p4)
	{
		z0eek(p0, (float)p1, (float)p2, (float)p3, (float)p4);
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzndh p1)
	{
		z0eek(p0, p1.z0pek(), p1.z0mek(), p1.z0iek(), p1.z0oek(), 0f);
	}

	public virtual void z0eek(float p0)
	{
		if (z0wrk != null)
		{
			z0wrk.z0rek(p0);
		}
		else if (z0urk != null && z0urk.z0iek() != null)
		{
			z0urk.z0iek().z0ggk(p0);
		}
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZznfh p1)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1);
		}
		else if (z0urk?.z0iek() != null)
		{
			z0urk.z0iek().z0hgk(p0, p1);
		}
	}

	public void z0eek(z0ZzZztfh p0, z0ZzZzvdh p1)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1);
		}
	}

	public virtual void z0eek(object p0)
	{
		if (p0 != null)
		{
			z0erk++;
			if (z0urk != null)
			{
				z0urk.z0eek(p0);
			}
			else if (z0wrk != null && p0 is z0ZzZzbfh)
			{
				z0wrk.z0eek((z0ZzZzbfh)p0);
			}
		}
	}

	public GraphicsUnit z0iek()
	{
		return z0ork;
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzndh p1, float p2, float p3)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2, p3);
		}
	}

	public void z0eek(string p0, z0ZzZzimk p1, Color p2, float p3, float p4)
	{
		z0eek(p0, p1, p2, p3, p4, z0ZzZzlsh.z0rek());
	}

	public virtual float z0eek(z0ZzZzimk p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("font");
		}
		bool flag = false;
		try
		{
			if (z0wrk != null)
			{
				return p0.GetHeight(z0wrk);
			}
			if (z0oek() != null)
			{
				return p0.GetHeight(z0oek());
			}
			return p0.GetHeight();
		}
		catch (Exception ex)
		{
			if (!p0.z0tek())
			{
				z0ZzZzqok.z0rek.z0sh("GetFontHeight报错。" + Environment.NewLine + ex.ToString());
				throw;
			}
			flag = true;
		}
		if (flag)
		{
			if (z0wrk != null)
			{
				return p0.GetHeight(z0wrk);
			}
			if (z0oek() != null)
			{
				return p0.GetHeight(z0oek());
			}
			return p0.GetHeight();
		}
		return p0.Size;
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzodh p1, z0ZzZzodh p2)
	{
		z0eek(p0, p1.z0rek(), p1.z0tek(), p2.z0rek(), p2.z0tek());
	}

	public void z0eek(bool p0)
	{
		z0srk = p0;
	}

	public float z0eek(z0ZzZzsdh p0)
	{
		if (z0wrk != null)
		{
			return p0.z0eek(z0wrk);
		}
		if (z0oek() != null)
		{
			return p0.z0eek(z0oek());
		}
		return p0.z0oek();
	}

	public void z0rek(Color p0, float p1, float p2, float p3, float p4, float p5)
	{
		if (p1 == 1f)
		{
			z0tek(p0, p2, p3, p4, p5);
			return;
		}
		using z0ZzZzudh p6 = new z0ZzZzudh(p0, p1);
		z0eek(p6, p2, p3, p4, p5);
	}

	public void z0eek(z0ZzZzfdh p0)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0);
		}
	}

	protected z0ZzZzjpk()
	{
	}

	public virtual void z0eek(z0ZzZztfh p0, z0ZzZzbdh p1)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1);
		}
	}

	public void z0eek(SmoothingMode p0)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0);
		}
	}

	public void z0eek(z0ZzZznmk p0, z0ZzZzbdh p1, float p2)
	{
		z0eek(p0, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), p2);
	}

	public z0ZzZzadh z0oek()
	{
		if (z0wrk != null)
		{
			return z0wrk;
		}
		if (z0urk != null)
		{
			if (z0prk == null)
			{
				z0prk = z0ZzZzadh.z0eek(new z0ZzZzrfh(1, 1));
			}
			z0prk.z0eek(z0urk.z0uek());
			return z0prk;
		}
		return null;
	}

	public void z0eek(InterpolationMode p0)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0);
		}
	}

	public bool z0pek()
	{
		return z0mrk;
	}

	public virtual z0ZzZzxdh z0eek(string p0, z0ZzZzimk p1, int p2, z0ZzZzlsh p3)
	{
		return z0oek().z0eek(p0, p1.Value, p2, p3);
	}

	public virtual void z0eek(float p0, float p1)
	{
		z0wrk?.z0yek(p0, p1);
		z0urk?.z0rek().z0rek(p0, p1);
	}

	public void z0eek(Color p0, z0ZzZzndh p1)
	{
		z0eek(p0, p1.z0pek(), p1.z0mek(), p1.z0iek(), p1.z0oek());
	}

	public virtual void z0eek(z0ZzZzudh p0, float p1, float p2, float p3, float p4)
	{
		z0wrk?.z0eek(p0, p1, p2, p3, p4);
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1, p2, p3, p4);
		}
	}

	public virtual void Dispose()
	{
		if (z0xek() && z0wrk != null)
		{
			z0ZzZzadh obj = z0wrk;
			z0wrk = null;
			obj.Dispose();
		}
	}

	public void z0eek(Color p0, float p1, DashStyle p2, z0ZzZzpdh[] p3)
	{
		using z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(p0, p1);
		z0ZzZzudh2.z0eek(p2);
		z0rek(z0ZzZzudh2, p3);
	}

	public virtual void z0eek(z0ZzZztfh p0, float p1, float p2, float p3, float p4, float p5 = 0f)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1, p2, p3, p4, p5);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2, p3, p4, 0f);
		}
	}

	public virtual void z0eek(z0ZzZzpdh[] p0)
	{
		z0jrk().z0eek(p0);
	}

	public virtual void z0eek(z0ZzZzudh p0, z0ZzZzpdh[] p1)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1);
		}
	}

	public z0ZzZzxdh z0eek(string p0, z0ZzZzimk p1, int p2)
	{
		return z0eek(p0, p1, p2, null);
	}

	public SmoothingMode z0mek()
	{
		if (z0wrk == null)
		{
			return SmoothingMode.Default;
		}
		return z0wrk.z0xek();
	}

	public void z0rek(bool p0)
	{
		z0mrk = p0;
	}

	public void z0eek(Color p0)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0);
		}
	}

	public InterpolationMode z0nek_jiejie20260327142557()
	{
		if (z0wrk == null)
		{
			return InterpolationMode.Default;
		}
		return z0wrk.z0oek();
	}

	public void z0eek(Color p0, float p1, DashStyle p2, z0ZzZzbdh p3)
	{
		if (p1 == 1f && p2 == DashStyle.Solid)
		{
			z0tek(p0, p3);
			return;
		}
		using z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(p0, p1);
		z0ZzZzudh2.z0eek(p2);
		z0eek(z0ZzZzudh2, p3);
	}

	public void z0rek(z0ZzZzudh p0, z0ZzZzpdh[] p1)
	{
		if (z0wrk != null)
		{
			z0wrk.z0rek(p0, p1);
		}
	}

	public void z0eek(z0ZzZznmk p0, z0ZzZzndh p1)
	{
		z0eek(p0.Value, p1.z0pek(), p1.z0mek(), p1.z0iek(), p1.z0oek(), 0f);
	}

	public virtual object z0bek()
	{
		if (z0urk != null)
		{
			return z0urk.z0oek();
		}
		if (z0wrk != null)
		{
			return z0wrk.z0rek();
		}
		return null;
	}

	public virtual void z0rek(float p0, float p1)
	{
		z0wrk?.z0eek(p0, p1);
		if (z0urk != null)
		{
			z0urk.z0rek().z0eek(p0, p1);
		}
	}

	public void z0eek(z0ZzZzemk p0, z0ZzZzndh p1)
	{
		using z0ZzZztfh p2 = p0.z0uek();
		z0eek(p2, p1.z0pek(), p1.z0mek(), p1.z0iek(), p1.z0oek());
	}

	public void z0eek(z0ZzZzfsh p0)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0);
		}
	}

	public static float z0eek(float p0, GraphicsUnit p1, GraphicsUnit p2)
	{
		return z0ZzZzrpk.z0eek(p0, p1, p2);
	}

	public void z0eek(Color p0, float p1, DashStyle p2, z0ZzZznfh p3)
	{
		using z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(p0, p1);
		z0ZzZzudh2.z0eek(p2);
		z0eek(z0ZzZzudh2, p3);
	}

	public void z0eek(Color p0, z0ZzZznfh p1)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(z0ZzZzyfh.z0eek(p0), p1);
		}
		else if (z0urk?.z0iek() != null)
		{
			z0urk.z0iek().z0jgk(z0ZzZzyfh.z0eek(p0), p1);
		}
	}

	public void z0rek(z0ZzZznmk p0, float p1, float p2, float p3, float p4)
	{
		z0eek(p0.Value, p1, p2, p3, p4, 0f);
	}

	public void z0eek(z0ZzZzemk p0, z0ZzZzbdh p1)
	{
		using z0ZzZztfh p2 = p0.z0uek();
		z0eek(p2, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek());
	}

	public void z0eek(z0ZzZztfh p0, z0ZzZznfh p1)
	{
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1);
		}
		else if (z0urk?.z0iek() != null)
		{
			z0urk.z0iek().z0jgk(p0, p1);
		}
	}

	public void z0eek(z0ZzZzedh p0, z0ZzZzbdh p1, byte[] p2 = null)
	{
		z0wrk?.z0eek(p0, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek());
		z0urk?.z0eek(p0, p1, z0pek(), p2);
	}

	public virtual void z0eek(z0ZzZzudh p0, z0ZzZzbdh p1, float p2)
	{
		if (z0lrk() != null)
		{
			z0lrk().z0eek(p0, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), p2);
		}
		else if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), 0f);
		}
		else if (z0urk != null)
		{
			z0urk.z0eek(p0, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), p2);
		}
	}

	public void z0rek(Color p0, z0ZzZznfh p1)
	{
		z0eek(z0ZzZzidh.z0eek(p0), p1);
	}

	public void z0eek(string p0, z0ZzZzsdh p1, z0ZzZztfh p2, float p3, float p4)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1, p2, new z0ZzZzbdh(p3, p4, 10000f, 1000f), z0ZzZzlsh.z0rek());
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2, p3, p4);
		}
	}

	public void z0rek(string p0, z0ZzZzimk p1, Color p2, z0ZzZzbdh p3, z0ZzZzlsh p4)
	{
		if (string.IsNullOrEmpty(p0) || p2.A == 0)
		{
			return;
		}
		z0ZzZzxdh z0ZzZzxdh2 = z0eek(p0, p1, 100000, p4);
		z0ZzZzbdh p5 = z0ZzZzjmk.z0eek(p3, z0ZzZzxdh2.z0rek(), z0ZzZzxdh2.z0tek(), p4.z0pek(), p4.z0tek());
		p5 = z0ZzZzbdh.z0tek(p5, p3);
		using z0ZzZzzdh p6 = new z0ZzZzzdh(p2);
		z0rek(p6, p5);
	}

	public z0ZzZzxdh z0eek(string p0, z0ZzZzsdh p1, int p2, z0ZzZzlsh p3)
	{
		return z0oek().z0eek(p0, p1, p2, p3);
	}

	public void z0rek(Color p0, z0ZzZzbdh p1)
	{
		z0eek(p0, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek());
	}

	public virtual GraphicsUnit z0vek()
	{
		if (z0urk != null)
		{
			return z0urk.z0uek();
		}
		if (z0wrk == null)
		{
			return GraphicsUnit.Pixel;
		}
		return z0wrk.z0jrk();
	}

	public bool z0cek()
	{
		if (z0urk != null)
		{
			return z0urk.z0iek() != null;
		}
		return false;
	}

	public virtual void z0tek(Color p0, z0ZzZzbdh p1)
	{
		if (p0 == Color.Black)
		{
			z0eek(z0ZzZzidh.z0iek, p1);
			return;
		}
		if (p0 == Color.White)
		{
			z0eek(z0ZzZzidh.z0uek, p1);
			return;
		}
		using z0ZzZzudh p2 = new z0ZzZzudh(p0);
		z0eek(p2, p1);
	}

	public virtual void z0eek(string p0, z0ZzZzimk p1, Color p2, float p3, float p4, z0ZzZzlsh p5)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1.Name, p1.Size, p1.Style, z0ZzZzyfh.z0eek(p2), new z0ZzZzbdh(p3, p4, 10000f, 1000f), p5);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1.Value, z0ZzZzyfh.z0eek(p2), p3, p4, p5);
		}
	}

	public bool z0xek()
	{
		return z0srk;
	}

	public virtual void z0zek()
	{
		z0wrk?.z0krk();
		if (z0urk != null)
		{
			z0urk.z0rek(0f, 0f);
			z0jrk().z0tek_jiejie20260327142557();
		}
	}

	public void z0eek(z0ZzZznmk p0, z0ZzZzpdh p1, z0ZzZzpdh p2)
	{
		z0eek(p0, p1.z0rek(), p1.z0tek(), p2.z0rek(), p2.z0tek());
	}

	public void z0eek(z0ZzZztfh p0, z0ZzZzpdh[] p1)
	{
		_ = z0urk;
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1);
		}
	}

	public z0ZzZzadh z0lrk()
	{
		return z0wrk;
	}

	public bool z0krk()
	{
		return z0urk != null;
	}

	public z0ZzZzxdh z0eek(string p0, z0ZzZzimk p1)
	{
		return z0eek(p0, p1, 100000, null);
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		z0erk++;
		z0wrk?.z0rek(p0);
		if (z0urk != null)
		{
			z0urk.z0eek(p0);
		}
	}

	public void z0eek(z0ZzZznmk p0, z0ZzZzbdh p1)
	{
		z0eek(p0.Value, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), 0f);
	}

	public void z0eek(z0ZzZztfh p0, z0ZzZzndh p1)
	{
		z0eek(p0, p1.z0pek(), p1.z0mek(), p1.z0iek(), p1.z0oek());
	}

	public virtual z0ZzZzjdh z0jrk()
	{
		if (z0wrk != null)
		{
			return z0wrk.z0vek();
		}
		if (z0urk != null)
		{
			return z0urk.z0rek();
		}
		return null;
	}

	public void z0rek(z0ZzZztfh p0, z0ZzZzbdh p1)
	{
		z0eek(p0, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek());
	}

	public void z0eek(z0ZzZzedh p0, int p1, int p2)
	{
		if (z0urk != null)
		{
			z0eek(p0, p1, p2, null);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2);
		}
	}

	public void z0eek(z0ZzZznmk p0, float p1, float p2, float p3, float p4, float p5)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("p");
		}
		using z0ZzZznfh p6 = z0ZzZzfmk.z0eek(new z0ZzZzbdh(p1, p2, p3, p4), p5);
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0.Value, p6);
		}
	}

	public z0ZzZzxdh z0eek(string p0, z0ZzZzsdh p1)
	{
		return z0oek().z0eek(p0, p1);
	}

	public void z0hrk()
	{
	}

	public z0ZzZzfsh z0grk()
	{
		if (z0wrk == null)
		{
			return (z0ZzZzfsh)0;
		}
		return z0wrk.z0lrk();
	}

	public virtual void z0rek(Color p0, float p1, float p2, float p3, float p4)
	{
		if (p0.A == 0)
		{
			return;
		}
		if (p0.ToArgb() == z0nrk)
		{
			z0eek(z0ZzZzidh.z0iek, p1, p2, p3, p4, 0f);
			return;
		}
		if (p0.ToArgb() == z0drk)
		{
			z0eek(z0ZzZzidh.z0uek, p1, p2, p3, p4, 0f);
			return;
		}
		using z0ZzZzudh p5 = new z0ZzZzudh(p0);
		z0eek(p5, p1, p2, p3, p4, 0f);
	}

	public void z0eek(Color p0, float p1, z0ZzZzpdh[] p2)
	{
		using z0ZzZzudh p3 = new z0ZzZzudh(p0, p1);
		z0rek(p3, p2);
	}

	public void z0tek(Color p0, float p1, float p2, float p3, float p4)
	{
		if (p0 == Color.Black)
		{
			z0eek(z0ZzZzidh.z0iek, p1, p2, p3, p4);
			return;
		}
		if (p0 == Color.White)
		{
			z0eek(z0ZzZzidh.z0uek, p1, p2, p3, p4);
			return;
		}
		using z0ZzZzudh p5 = new z0ZzZzudh(p0);
		z0eek(p5, p1, p2, p3, p4);
	}

	public static z0ZzZzjpk z0eek(z0ZzZzbpk p0)
	{
		return new z0ZzZzjpk
		{
			z0urk = p0,
			z0ork = p0.z0uek()
		};
	}

	public void z0eek(z0ZzZzedh p0, float p1, float p2, float p3, float p4)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0, new z0ZzZzbdh(p1, p2, p3, p4), z0pek(), null);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2, p3, p4);
		}
	}

	public void z0eek(z0ZzZzedh p0, z0ZzZzbdh p1, z0ZzZzbdh p2, GraphicsUnit p3)
	{
		if (z0urk != null)
		{
			z0urk.z0eek(p0, p1, z0pek(), null);
		}
		if (z0wrk != null)
		{
			z0wrk.z0eek(p0, p1, p2, p3);
		}
	}

	public void z0rek(z0ZzZzudh p0, z0ZzZzbdh p1)
	{
		z0eek(p0, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), 0f);
	}

	public z0ZzZzbej z0frk()
	{
		return z0urk?.z0iek();
	}
}
