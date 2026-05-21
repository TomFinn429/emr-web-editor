using System;
using DCSoft.Printing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzarj
{
	private float z0krk;

	private float z0jrk;

	private float z0hrk;

	private DCGutterStyle z0grk;

	private float z0frk;

	private bool z0drk;

	private float z0srk;

	private float z0ark;

	private float z0qrk;

	private bool z0wrk;

	private float z0erk;

	private float z0rrk;

	private float z0trk;

	private float z0yrk;

	private float z0urk;

	private float z0irk;

	private float z0ork;

	public float z0eek()
	{
		return z0jrk;
	}

	public DCGutterStyle z0rek()
	{
		return z0grk;
	}

	public void z0eek(float p0)
	{
		z0srk *= p0;
		z0yrk *= p0;
		z0ark *= p0;
		z0frk *= p0;
		z0ork *= p0;
		z0krk *= p0;
		z0urk *= p0;
		z0trk *= p0;
		z0hrk *= p0;
		z0qrk *= p0;
		z0rrk *= p0;
		z0jrk *= p0;
		z0erk *= p0;
		z0irk *= p0;
	}

	public float z0tek()
	{
		return z0krk;
	}

	public float z0yek()
	{
		return z0erk;
	}

	public static bool z0eek(XPageSettings p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ps");
		}
		if (p0.z0ttk() > 0f && p0.z0nek())
		{
			return true;
		}
		if (p0.z0lrk())
		{
			return true;
		}
		return false;
	}

	public float z0uek()
	{
		return z0qrk;
	}

	public float z0iek()
	{
		return z0rrk;
	}

	public z0ZzZzarj(XPageSettings p0, bool p1, bool p2)
	{
		z0eek(null, p0, p1, p2);
	}

	public bool z0oek()
	{
		return z0wrk;
	}

	private void z0eek(z0ZzZzwrj p0, XPageSettings p1, bool p2, bool p3)
	{
		if (p1 == null && p0 != null)
		{
			p1 = p0.z0trk();
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("ps");
		}
		float num = (z0qrk = p1.z0ttk());
		z0grk = p1.z0xtk();
		z0ZzZzmdh z0ZzZzmdh2 = ((p0 == null) ? p1.z0htk_jiejie20260327142557() : p0.z0vrk());
		z0srk = z0ZzZzmdh2.z0yek();
		z0yrk = z0ZzZzmdh2.z0tek();
		z0ark = z0ZzZzmdh2.z0uek();
		z0frk = z0ZzZzmdh2.z0eek_jiejie20260327142557();
		if (p1.z0mek())
		{
			z0ork = p1.z0pek();
			z0krk = p1.z0utk();
		}
		z0ZzZzcdh z0ZzZzcdh2 = p1.z0ytk();
		if (p1.z0ork())
		{
			z0urk = z0ZzZzcdh2.z0tek();
			z0trk = z0ZzZzcdh2.z0rek();
		}
		else
		{
			z0urk = z0ZzZzcdh2.z0rek();
			z0trk = z0ZzZzcdh2.z0tek();
		}
		z0wrk = false;
		bool flag = p3 && p1.z0nek();
		if (num > 0f)
		{
			z0drk = true;
			z0wrk = true;
			if (flag)
			{
				if (z0rek() == DCGutterStyle.Left)
				{
					z0ark += num;
				}
				else if (z0rek() == DCGutterStyle.Top)
				{
					z0frk += num;
					z0krk += num;
				}
				else if (z0rek() == DCGutterStyle.Right)
				{
					z0srk += num;
				}
			}
			else if (z0rek() == DCGutterStyle.Left)
			{
				z0srk += num;
			}
			else if (z0rek() == DCGutterStyle.Top)
			{
				z0yrk += num;
				z0ork += num;
				z0hrk = num;
			}
			else if (z0rek() == DCGutterStyle.Right)
			{
				z0ark += num;
			}
			if (z0rek() == DCGutterStyle.Left)
			{
				if (flag)
				{
					z0rrk = z0xek() - num;
				}
				else
				{
					z0rrk = num;
				}
				z0jrk = z0pek();
				z0erk = z0iek();
				z0irk = z0nek() - z0mek();
			}
			else if (z0rek() == DCGutterStyle.Top)
			{
				z0rrk = z0bek();
				if (flag)
				{
					z0jrk = z0nek() - num;
				}
				else
				{
					z0jrk = num;
				}
				z0erk = z0xek() - z0cek();
				z0irk = z0eek();
			}
			else if (z0rek() == DCGutterStyle.Right)
			{
				if (flag)
				{
					z0rrk = num;
				}
				else
				{
					z0rrk = z0xek() - num;
				}
				z0jrk = z0pek();
				z0erk = z0iek();
				z0irk = z0nek() - z0mek();
			}
		}
		else if (p1.z0lrk())
		{
			z0wrk = true;
			if (flag)
			{
				float num2 = z0srk;
				z0srk = z0ark;
				z0ark = num2;
			}
		}
		if (p2)
		{
			z0eek(GraphicsUnit.Document);
		}
	}

	public float z0pek()
	{
		return z0yrk;
	}

	public float z0mek()
	{
		return z0frk;
	}

	public float z0nek()
	{
		return z0trk;
	}

	public float z0bek()
	{
		return z0srk;
	}

	public float z0vek()
	{
		return z0ork;
	}

	public float z0cek()
	{
		return z0ark;
	}

	public float z0xek()
	{
		return z0urk;
	}

	public z0ZzZzarj(z0ZzZzwrj p0, bool p1 = false)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("page");
		}
		z0eek(p0, null, p1, p0.z0cek());
	}

	public bool z0zek()
	{
		return z0drk;
	}

	public float z0lrk()
	{
		return z0irk;
	}

	public void z0eek(GraphicsUnit p0)
	{
		float p1 = (float)z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document) * 3f;
		z0eek(p1);
	}
}
