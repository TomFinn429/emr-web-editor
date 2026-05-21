using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZziuj : z0ZzZzeuj
{
	private new bool z0tek;

	private new float z0yek = 2f;

	public void z0eek_jiejie20260327142557(float p0)
	{
		z0yek = p0;
	}

	public override void z0fjk(z0ZzZztuj p0)
	{
		if (!(((z0ZzZzhuj)this).z0iek() is z0ZzZzkuj z0ZzZzkuj2))
		{
			return;
		}
		z0ZzZzpmk z0ZzZzpmk2 = z0ZzZzkuj2.z0eek();
		if (z0ZzZzpmk2 == null || z0ZzZzpmk2.Value == null)
		{
			return;
		}
		z0ZzZzbdh z0ZzZzbdh2 = ((z0ZzZzhuj)z0ZzZzkuj2).z0uek();
		z0ZzZzbdh z0ZzZzbdh3 = ((z0ZzZzhuj)this).z0uek();
		z0ZzZzbdh p1 = z0ZzZzbdh.z0tek(z0ZzZzbdh3, z0ZzZzbdh2);
		if (p1.z0bek())
		{
			return;
		}
		z0ZzZzbdh p2 = z0ZzZzbdh3;
		if (z0rek() >= 1f)
		{
			p2.z0tek(z0ZzZzbdh3.z0uek() / z0rek());
			p2.z0yek(z0ZzZzbdh3.z0iek() / z0rek());
			p2.z0eek(z0ZzZzbdh3.z0oek() + z0ZzZzbdh3.z0uek() / 2f - p2.z0uek() / 2f);
			p2.z0rek(z0ZzZzbdh3.z0pek() + z0ZzZzbdh3.z0iek() / 2f - p2.z0iek() / 2f);
		}
		p2 = z0ZzZzbdh.z0tek(z0ZzZzbdh2, p2);
		if (!p2.z0bek())
		{
			p2 = z0ZzZzjmk.z0eek(p2, z0ZzZzbdh2.z0tek(), z0ZzZzbdh2.z0yek(), (float)z0ZzZzpmk2.Width / z0ZzZzbdh2.z0uek(), (float)z0ZzZzpmk2.Height / z0ZzZzbdh2.z0iek());
			p2.z0tek(0f - z0ZzZzbdh2.z0tek(), 0f - z0ZzZzbdh2.z0yek());
			if (z0eek_jiejie20260327142557())
			{
				p0.z0iek().z0eek(z0ZzZzpmk2, p1, p2, GraphicsUnit.Pixel);
				return;
			}
			z0ZzZzfdh p3 = p0.z0iek().z0tek();
			InterpolationMode p4 = p0.z0iek().z0nek_jiejie20260327142557();
			p0.z0iek().z0eek(InterpolationMode.NearestNeighbor);
			p0.z0iek().z0eek((z0ZzZzfdh)4);
			p0.z0iek().z0eek(z0ZzZzpmk2, p1, p2, GraphicsUnit.Pixel);
			p0.z0iek().z0eek(p4);
			p0.z0iek().z0eek(p3);
		}
	}

	public bool z0eek_jiejie20260327142557()
	{
		return z0tek;
	}

	public void z0eek_jiejie20260327142557(bool p0)
	{
		z0tek = p0;
	}

	public new float z0rek()
	{
		return z0yek;
	}
}
