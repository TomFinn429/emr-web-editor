using System.Collections.Generic;
using System.ComponentModel;
using DCSoft.Printing;
using DCSystem_Drawing.Printing;

namespace zzz;

public class z0ZzZzlrj
{
	private JumpPrintInfo z0xek;

	private bool z0zek;

	private bool z0lrk;

	private PrintRange z0krk;

	private bool z0jrk;

	private string z0hrk;

	private string z0grk;

	private List<int> z0frk;

	private z0ZzZzvej z0drk;

	private int z0srk;

	private bool z0ark;

	private int z0qrk = -1;

	private string z0wrk;

	private int z0erk;

	[DefaultValue(null)]
	public string PaperSourceName
	{
		get
		{
			return z0wrk;
		}
		set
		{
			z0wrk = value;
		}
	}

	public z0ZzZzvej BoundsSelection
	{
		get
		{
			if (z0drk == null)
			{
				z0drk = new z0ZzZzvej();
			}
			return z0drk;
		}
		set
		{
			z0drk = value;
		}
	}

	public bool HasBoundSelection
	{
		get
		{
			if (z0drk != null && z0drk.z0rek())
			{
				return z0drk.Count > 0;
			}
			return false;
		}
	}

	public void z0rek(bool p0)
	{
		z0jrk = p0;
	}

	public List<int> z0rek()
	{
		return z0frk;
	}

	public void z0rek(JumpPrintInfo p0)
	{
		z0xek = p0;
	}

	public string z0tek()
	{
		return z0hrk;
	}

	public void z0rek(string p0)
	{
		z0hrk = p0;
	}

	public void z0rek(PrintRange p0)
	{
		z0krk = p0;
	}

	public void z0tek(bool p0)
	{
		z0lrk = p0;
	}

	public bool z0yek()
	{
		return z0jrk;
	}

	public void z0rek(int p0)
	{
		z0srk = p0;
	}

	public bool z0uek()
	{
		return z0lrk;
	}

	public string z0iek()
	{
		return z0grk;
	}

	public bool z0oek()
	{
		return z0ark;
	}

	public JumpPrintInfo z0pek()
	{
		if (z0xek == null)
		{
			z0xek = new JumpPrintInfo();
		}
		return z0xek;
	}

	public void z0tek(int p0)
	{
		z0qrk = p0;
	}

	public void z0eek(List<int> p0)
	{
		z0frk = p0;
	}

	public void z0yek(bool p0)
	{
		z0ark = p0;
	}

	public void z0tek(string p0)
	{
		z0grk = p0;
	}

	public void z0uek(bool p0)
	{
		z0zek = p0;
	}

	public int z0mek()
	{
		return z0srk;
	}

	public int z0nek()
	{
		return z0qrk;
	}

	public bool z0bek()
	{
		return z0zek;
	}

	public PrintRange z0vek()
	{
		return z0krk;
	}

	public void z0yek(int p0)
	{
		z0erk = p0;
	}

	public int z0cek()
	{
		return z0erk;
	}
}
