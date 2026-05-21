using DCSoft.Drawing;

namespace zzz;

public class z0ZzZzsmk : z0ZzZzqmk
{
	private bool z0jrk = true;

	private bool z0hrk = true;

	internal z0ZzZzbdh z0grk = z0ZzZzbdh.z0xek;

	private object z0frk;

	internal z0ZzZzndh z0drk = z0ZzZzndh.z0cek;

	internal z0ZzZzbdh z0srk = z0ZzZzbdh.z0xek;

	private int z0ark;

	internal PageContentPartyStyle z0qrk = PageContentPartyStyle.Body;

	private z0ZzZzpdh z0wrk = new z0ZzZzpdh(0f, 0f);

	private bool z0erk = true;

	private z0ZzZzbdh z0rrk = z0ZzZzbdh.z0xek;

	private object z0trk;

	public new void z0eek(z0ZzZzbdh p0)
	{
		z0srk = p0;
	}

	public new void z0rek(z0ZzZzbdh p0)
	{
		z0grk = p0;
	}

	public object z0eek()
	{
		return z0trk;
	}

	public new void z0eek(z0ZzZzpdh p0)
	{
		z0wrk = p0;
	}

	public void z0eek(int p0)
	{
		z0ark = p0;
	}

	public void z0eek(bool p0)
	{
		z0erk = p0;
	}

	public z0ZzZzbdh z0rek()
	{
		return z0srk;
	}

	public z0ZzZzndh z0tek_jiejie20260327142557()
	{
		return new z0ZzZzndh((int)z0grk.z0oek(), (int)z0grk.z0pek(), (int)z0grk.z0uek(), (int)z0grk.z0iek());
	}

	public int z0yek()
	{
		return z0ark;
	}

	public void z0tek_jiejie20260327142557(z0ZzZzbdh p0)
	{
		z0rrk = p0;
	}

	public override z0ZzZzodh z0gwk(int p0, int p1)
	{
		z0ZzZzpdh z0ZzZzpdh2 = z0bqk(p0, p1);
		return new z0ZzZzodh((int)z0ZzZzpdh2.z0rek(), (int)z0ZzZzpdh2.z0tek());
	}

	public z0ZzZzndh z0uek()
	{
		return new z0ZzZzndh((int)z0srk.z0oek(), (int)z0srk.z0pek(), (int)z0srk.z0uek(), (int)z0srk.z0iek());
	}

	public void z0eek(object p0)
	{
		z0frk = p0;
	}

	public override bool z0hwk(int p0, int p1)
	{
		return z0grk.z0eek((float)p0 - z0wrk.z0rek(), (float)p1 - z0wrk.z0tek());
	}

	public z0ZzZzbdh z0iek()
	{
		return z0rrk;
	}

	public bool z0oek()
	{
		return z0jrk;
	}

	public float z0pek()
	{
		return z0srk.z0pek();
	}

	public void z0rek(bool p0)
	{
		z0jrk = p0;
	}

	public override z0ZzZzodh z0jwk(int p0, int p1)
	{
		z0ZzZzpdh z0ZzZzpdh2 = z0xqk(p0, p1);
		return new z0ZzZzodh((int)z0ZzZzpdh2.z0rek(), (int)z0ZzZzpdh2.z0tek());
	}

	public override z0ZzZzcdh z0kwk(int p0, int p1)
	{
		if (z0grk.z0uek() != z0srk.z0uek() && z0srk.z0uek() != 0f)
		{
			p0 = (int)((float)p0 * z0grk.z0uek() / z0srk.z0uek());
		}
		if (z0grk.z0iek() != z0srk.z0iek() && z0srk.z0iek() != 0f)
		{
			p1 = (int)((float)p1 * z0grk.z0iek() / z0srk.z0iek());
		}
		return new z0ZzZzcdh(p0, p1);
	}

	public z0ZzZzbdh z0mek()
	{
		return z0grk;
	}

	public bool z0nek()
	{
		return z0hrk;
	}

	public override z0ZzZzxdh z0lwk(float p0, float p1)
	{
		if (z0grk.z0uek() != z0srk.z0uek() && z0srk.z0uek() != 0f)
		{
			p0 = p0 * z0grk.z0uek() / z0srk.z0uek();
		}
		if (z0grk.z0iek() != z0srk.z0iek() && z0srk.z0iek() != 0f)
		{
			p1 = p1 * z0grk.z0iek() / z0srk.z0iek();
		}
		return new z0ZzZzxdh(p0, p1);
	}

	public float z0bek()
	{
		return z0srk.z0uek() / z0grk.z0uek();
	}

	public PageContentPartyStyle z0vek()
	{
		return z0qrk;
	}

	public object z0cek()
	{
		return z0frk;
	}

	public bool z0xek()
	{
		return z0erk;
	}

	public void z0eek(float p0, float p1)
	{
		z0grk.z0tek(p0, p1);
	}

	public void z0tek_jiejie20260327142557(bool p0)
	{
		z0hrk = p0;
	}

	public override z0ZzZzxdh z0zqk(float p0, float p1)
	{
		if (z0grk.z0uek() != z0srk.z0uek() && z0grk.z0uek() != 0f)
		{
			p0 = p0 * z0srk.z0uek() / z0grk.z0uek();
		}
		if (z0grk.z0iek() != z0srk.z0iek() && z0grk.z0iek() != 0f)
		{
			p1 = p1 * z0srk.z0iek() / z0grk.z0iek();
		}
		return new z0ZzZzxdh(p0, p1);
	}

	public new void z0eek(z0ZzZzndh p0)
	{
		z0srk = new z0ZzZzbdh(p0.z0pek(), p0.z0mek(), p0.z0iek(), p0.z0oek());
	}

	public override z0ZzZzpdh z0xqk(float p0, float p1)
	{
		p0 -= z0srk.z0oek();
		p1 -= z0srk.z0pek();
		if (z0grk.z0uek() != z0srk.z0uek() && z0srk.z0uek() != 0f)
		{
			p0 = p0 * z0grk.z0uek() / z0srk.z0uek();
		}
		if (z0grk.z0iek() != z0srk.z0iek() && z0srk.z0iek() != 0f)
		{
			p1 = p1 * z0grk.z0iek() / z0srk.z0iek();
		}
		return new z0ZzZzpdh(p0 + z0grk.z0oek() + z0wrk.z0rek(), p1 + z0grk.z0pek() + z0wrk.z0tek());
	}

	public void z0eek(PageContentPartyStyle p0)
	{
		z0qrk = p0;
	}

	public z0ZzZzpdh z0zek()
	{
		return z0wrk;
	}

	public void z0rek(z0ZzZzndh p0)
	{
		z0grk = new z0ZzZzbdh(p0.z0pek(), p0.z0mek(), p0.z0iek(), p0.z0oek());
	}

	public bool z0yek(z0ZzZzbdh p0)
	{
		return z0srk.z0tek(p0);
	}

	public void z0tek_jiejie20260327142557(z0ZzZzndh p0)
	{
		z0drk = p0;
	}

	public override z0ZzZzodh z0cqk(z0ZzZzodh p0)
	{
		z0ZzZzpdh z0ZzZzpdh2 = z0xqk(p0.z0rek(), p0.z0tek());
		return new z0ZzZzodh((int)z0ZzZzpdh2.z0rek(), (int)z0ZzZzpdh2.z0tek());
	}

	public override void z0vqk()
	{
		z0trk = null;
		z0frk = null;
	}

	public z0ZzZzndh z0lrk()
	{
		if (z0drk.z0vek())
		{
			return z0tek_jiejie20260327142557();
		}
		return z0drk;
	}

	public float z0krk()
	{
		return z0srk.z0iek() / z0grk.z0iek();
	}

	public void z0rek(object p0)
	{
		z0trk = p0;
	}

	public override z0ZzZzpdh z0bqk(float p0, float p1)
	{
		p0 = p0 - z0grk.z0oek() - z0wrk.z0rek();
		p1 = p1 - z0grk.z0pek() - z0wrk.z0tek();
		if (z0grk.z0uek() != z0srk.z0uek() && z0grk.z0uek() != 0f)
		{
			p0 = p0 * z0srk.z0uek() / z0grk.z0uek();
		}
		if (z0grk.z0iek() != z0srk.z0iek() && z0grk.z0iek() != 0f)
		{
			p1 = p1 * z0srk.z0iek() / z0grk.z0iek();
		}
		return new z0ZzZzpdh(p0 + z0srk.z0oek(), p1 + z0srk.z0pek());
	}
}
