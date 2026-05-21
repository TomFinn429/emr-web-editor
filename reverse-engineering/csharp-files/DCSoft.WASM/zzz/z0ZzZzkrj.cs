using DCSoft.Drawing;
using DCSoft.Printing;

namespace zzz;

public class z0ZzZzkrj
{
	private z0ZzZzndh z0lrk = z0ZzZzndh.z0cek;

	private z0ZzZzbdh z0krk = z0ZzZzbdh.z0xek;

	private z0ZzZzjpk z0jrk;

	private PageViewMode z0hrk;

	private bool z0grk;

	private readonly z0ZzZzjrj z0frk;

	private readonly PageContentPartyStyle z0drk = PageContentPartyStyle.Body;

	private readonly z0ZzZzwrj z0srk;

	private int z0ark;

	private z0ZzZzlrj z0qrk;

	private int z0wrk;

	private readonly z0ZzZzsmk z0erk;

	private z0ZzZzndh z0rrk = z0ZzZzndh.z0cek;

	private z0ZzZzxej z0trk;

	public void z0eek(PageViewMode p0)
	{
		z0hrk = p0;
	}

	public int z0eek()
	{
		return z0wrk;
	}

	public bool z0rek()
	{
		return z0grk;
	}

	public void z0eek(z0ZzZzxej p0)
	{
		z0trk = p0;
	}

	public PageViewMode z0tek()
	{
		return z0hrk;
	}

	public int z0yek()
	{
		return z0ark;
	}

	public z0ZzZzndh z0uek()
	{
		return z0lrk;
	}

	public void z0eek(z0ZzZzndh p0)
	{
		z0lrk = p0;
	}

	public z0ZzZzbdh z0iek()
	{
		return z0krk;
	}

	public void z0eek(bool p0)
	{
		z0grk = p0;
	}

	public z0ZzZzsmk z0oek()
	{
		return z0erk;
	}

	public z0ZzZzndh z0pek()
	{
		return z0rrk;
	}

	public void z0rek(z0ZzZzndh p0)
	{
		z0rrk = p0;
	}

	public void z0eek(int p0)
	{
		z0ark = p0;
	}

	public z0ZzZzjpk z0mek()
	{
		return z0jrk;
	}

	public z0ZzZzlrj z0nek()
	{
		return z0qrk;
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		z0krk = p0;
	}

	public z0ZzZzxej z0bek()
	{
		return z0trk;
	}

	public z0ZzZzkrj(z0ZzZzjpk p0, z0ZzZzndh p1, z0ZzZzjrj p2, z0ZzZzwrj p3, PageContentPartyStyle p4, z0ZzZzsmk p5)
	{
		z0jrk = p0;
		z0lrk = p1;
		z0frk = p2;
		z0srk = p3;
		z0drk = p4;
		if (p3 != null)
		{
			z0ark = p3.z0vek();
		}
		z0erk = p5;
	}

	public void z0rek(int p0)
	{
		z0wrk = p0;
	}

	public z0ZzZzjrj z0vek()
	{
		return z0frk;
	}

	public z0ZzZzwrj z0cek()
	{
		return z0srk;
	}

	public void z0eek(z0ZzZzlrj p0)
	{
		z0qrk = p0;
	}

	public PageContentPartyStyle z0xek()
	{
		return z0drk;
	}

	public z0ZzZzfrj z0zek()
	{
		z0ZzZzfrj obj = new z0ZzZzfrj(z0jrk, z0uek(), z0vek(), z0cek(), z0xek(), z0oek());
		obj.z0eek_jiejie20260327142557(z0uek());
		obj.z0rek(z0pek());
		obj.z0eek_jiejie20260327142557(z0eek());
		obj.z0eek_jiejie20260327142557(z0nek());
		obj.z0rek(z0yek());
		obj.z0eek_jiejie20260327142557(z0bek());
		obj.z0eek_jiejie20260327142557(z0tek());
		obj.z0eek_jiejie20260327142557(z0iek());
		return obj;
	}
}
