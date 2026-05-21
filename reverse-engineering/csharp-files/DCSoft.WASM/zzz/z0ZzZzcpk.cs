using DCSoft.Drawing;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzcpk
{
	private float z0srk;

	private Color z0ark = Color.FromArgb(170, 170, 170);

	public static Color z0qrk = z0ZzZzhsh.z0rek;

	private int z0wrk = 30;

	private int z0erk = 1;

	private int z0rrk = 40;

	private bool z0trk = true;

	private z0ZzZzgpk z0yrk;

	private float z0urk;

	private int z0irk = 20;

	private float z0ork;

	private float z0prk = 1f;

	private z0ZzZzvpk z0mrk;

	private Color z0nrk = Color.White;

	private z0ZzZzndh z0brk = z0ZzZzndh.z0cek;

	private bool z0vrk = true;

	private int z0crk = 60;

	public int z0xrk;

	private Color z0zrk = Color.Black;

	private bool z0ltk;

	private int z0ktk = 20;

	private float z0jtk;

	private z0ZzZzndh z0htk = z0ZzZzndh.z0cek;

	public void z0eek(z0ZzZzmdh p0)
	{
		z0irk = p0.z0yek();
		z0wrk = p0.z0tek();
		z0ktk = p0.z0uek();
		z0rrk = p0.z0eek_jiejie20260327142557();
	}

	public Color z0eek()
	{
		return z0nrk;
	}

	public z0ZzZzvpk z0rek()
	{
		return z0mrk;
	}

	public bool z0tek()
	{
		return z0ltk;
	}

	public float z0yek()
	{
		return z0jtk;
	}

	public int z0uek()
	{
		return z0rrk;
	}

	public void z0eek(z0ZzZzgpk p0)
	{
		z0yrk = p0;
	}

	public int z0iek()
	{
		return z0irk;
	}

	public float z0oek()
	{
		return z0urk;
	}

	public void z0eek(z0ZzZzvpk p0)
	{
		z0mrk = p0;
	}

	public void z0eek(z0ZzZzndh p0)
	{
		z0brk = p0;
	}

	public void z0eek(float p0)
	{
		z0prk = p0;
	}

	public z0ZzZzgpk z0pek()
	{
		return z0yrk;
	}

	public bool z0mek()
	{
		return z0trk;
	}

	public void z0rek(float p0)
	{
		z0urk = p0;
	}

	public Color z0nek()
	{
		return z0zrk;
	}

	public void z0eek(int p0)
	{
		z0erk = p0;
	}

	public virtual void z0eek(z0ZzZzjpk p0, z0ZzZzndh p1)
	{
		if (p1.z0vek() || p1.z0rek(z0htk))
		{
			if (z0hrk() > 0f || z0oek() > 0f)
			{
				using z0ZzZzudh p2 = z0ZzZzdpk.z0eek(Color.Black, 1f, DashStyle.Dash);
				p0.z0eek(p2, z0hrk() + (float)z0htk.z0pek(), z0oek() + (float)z0htk.z0mek(), z0bek() + (float)z0htk.z0pek(), z0yek() + (float)z0htk.z0mek());
			}
			if (z0mek() && z0lrk().A != 0 && z0grk() > 0)
			{
				z0ZzZzndh z0ZzZzndh2 = new z0ZzZzndh(z0htk.z0pek() + z0iek() - 1, z0htk.z0mek() + z0zek(), z0htk.z0iek() - z0iek() - z0jrk() + 2, z0htk.z0oek() - z0zek() - z0uek());
				z0ZzZzodh[] array = new z0ZzZzodh[16]
				{
					z0ZzZzndh2.z0rek(),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh),
					default(z0ZzZzodh)
				};
				array[1].z0eek(z0ZzZzndh2.z0pek() - z0grk());
				array[1].z0rek(z0ZzZzndh2.z0mek());
				array[2] = array[0];
				array[3].z0eek(z0ZzZzndh2.z0pek());
				array[3].z0rek(z0ZzZzndh2.z0mek() - z0grk());
				array[4].z0eek(z0ZzZzndh2.z0nek());
				array[4].z0rek(z0ZzZzndh2.z0mek());
				array[5].z0eek(z0ZzZzndh2.z0nek() + z0grk());
				array[5].z0rek(z0ZzZzndh2.z0mek());
				array[6] = array[4];
				array[7].z0eek(z0ZzZzndh2.z0nek());
				array[7].z0rek(z0ZzZzndh2.z0mek() - z0grk());
				array[8].z0eek(z0ZzZzndh2.z0nek());
				array[8].z0rek(z0ZzZzndh2.z0bek());
				array[9].z0eek(z0ZzZzndh2.z0nek() + z0grk());
				array[9].z0rek(z0ZzZzndh2.z0bek());
				array[10] = array[8];
				array[11].z0eek(z0ZzZzndh2.z0nek());
				array[11].z0rek(z0ZzZzndh2.z0bek() + z0grk());
				array[12].z0eek(z0ZzZzndh2.z0pek());
				array[12].z0rek(z0ZzZzndh2.z0bek());
				array[13].z0eek(z0ZzZzndh2.z0pek());
				array[13].z0rek(z0ZzZzndh2.z0bek() + z0grk());
				array[14] = array[12];
				array[15].z0eek(z0ZzZzndh2.z0pek() - z0grk());
				array[15].z0rek(z0ZzZzndh2.z0bek());
				using z0ZzZzudh p3 = new z0ZzZzudh(z0lrk());
				for (int i = 0; i < array.Length; i += 2)
				{
					if (array[i].z0rek() != -2147483648)
					{
						z0ZzZzodh z0ZzZzodh2 = array[i];
						z0ZzZzodh z0ZzZzodh3 = array[i + 1];
						if (z0ZzZzdpk.z0eek(p1.z0eek(), z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek(), z0ZzZzodh3.z0rek(), z0ZzZzodh3.z0tek()))
						{
							p0.z0eek(p3, z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek(), z0ZzZzodh3.z0rek(), z0ZzZzodh3.z0tek());
						}
					}
				}
			}
		}
		if ((z0pek() == null || !z0pek().z0yek()) && z0rek() != null && z0rek().z0eek() != PageBorderRangeTypes.None)
		{
			z0ZzZzndh z0ZzZzndh3 = z0frk();
			if (z0rek().z0eek() == PageBorderRangeTypes.Page)
			{
				float num = z0rek().PaddingLeft;
				if (num <= 0f)
				{
					num = z0iek() / 2;
				}
				float num2 = z0rek().PaddingTop;
				if (num2 <= 0f)
				{
					num2 = z0zek() / 2;
				}
				float num3 = z0rek().PaddingRight;
				if (num3 <= 0f)
				{
					num3 = z0jrk() / 2;
				}
				float num4 = z0rek().PaddingBottom;
				if (num4 <= 0f)
				{
					num4 = z0uek() / 2;
				}
				z0ZzZzndh3.z0tek((int)((float)z0ZzZzndh3.z0iek() - num - num3));
				z0ZzZzndh3.z0yek((int)((float)z0ZzZzndh3.z0oek() - num2 - num4));
				z0ZzZzndh3.z0rek((int)num, (int)num2);
			}
			else if (z0rek().z0eek() == PageBorderRangeTypes.Body)
			{
				z0ZzZzndh3.z0rek(z0iek(), z0zek());
				z0ZzZzndh3.z0tek(z0ZzZzndh3.z0iek() - z0iek() - z0jrk());
				z0ZzZzndh3.z0yek(z0ZzZzndh3.z0oek() - z0zek() - z0uek());
				if (!z0vek().z0vek())
				{
					z0vek().z0mek();
					z0frk().z0mek();
					z0ZzZzndh3.z0bek();
					_ = z0vek().z0bek() - 3;
					z0ZzZzndh3.z0rek(z0vek().z0uek());
					z0ZzZzndh3.z0yek(z0vek().z0oek());
				}
			}
			if (z0rek().HasVisibleBorder)
			{
				z0rek().z0eek(p0, z0ZzZzndh3.z0eek());
			}
		}
		if (z0pek() == null || !z0pek().z0yek())
		{
			return;
		}
		z0ZzZzndh p4 = new z0ZzZzndh(z0htk.z0nek() - z0xrk, z0htk.z0mek(), (int)((float)z0jrk() - z0pek().z0uek()), z0htk.z0oek());
		if (!p1.z0vek())
		{
			p4 = z0ZzZzndh.z0tek(p4, p1);
			if (!p4.z0vek())
			{
				z0ZzZzzdh z0ZzZzzdh2 = new z0ZzZzzdh(z0qrk);
				p0.z0eek(z0ZzZzzdh2, p4);
				z0ZzZzzdh2.Dispose();
			}
		}
	}

	public float z0bek()
	{
		return z0ork;
	}

	public z0ZzZzndh z0vek()
	{
		return z0brk;
	}

	public void z0eek(bool p0)
	{
		z0ltk = p0;
	}

	public void z0rek(int p0)
	{
		z0crk = p0;
	}

	public int z0cek()
	{
		return z0erk;
	}

	public void z0eek(Color p0)
	{
		z0nrk = p0;
	}

	public float z0xek()
	{
		return z0prk;
	}

	public void z0rek(Color p0)
	{
		z0ark = p0;
	}

	public void z0tek(int p0)
	{
		z0ktk = p0;
	}

	public void z0yek(int p0)
	{
		z0irk = p0;
	}

	public void z0tek(float p0)
	{
		z0ork = p0;
	}

	public int z0zek()
	{
		return z0wrk;
	}

	public Color z0lrk()
	{
		return z0ark;
	}

	public void z0tek(Color p0)
	{
		z0zrk = p0;
	}

	public void z0yek(float p0)
	{
		z0jtk = p0;
	}

	public void z0rek(bool p0)
	{
		z0vrk = p0;
	}

	public void z0uek(int p0)
	{
		z0rrk = p0;
	}

	public void z0iek(int p0)
	{
		z0wrk = p0;
	}

	public void z0rek(z0ZzZzndh p0)
	{
		z0htk = p0;
	}

	public bool z0krk()
	{
		return z0vrk;
	}

	public int z0jrk()
	{
		return z0ktk;
	}

	public void z0uek(float p0)
	{
		z0srk = p0;
	}

	public float z0hrk()
	{
		return z0srk;
	}

	public int z0grk()
	{
		return z0crk;
	}

	public z0ZzZzndh z0frk()
	{
		return z0htk;
	}

	public void z0tek(bool p0)
	{
		z0trk = p0;
	}

	public z0ZzZzmdh z0drk()
	{
		return new z0ZzZzmdh(z0irk, z0ktk, z0wrk, z0rrk);
	}
}
