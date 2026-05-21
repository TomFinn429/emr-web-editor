using System;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzvgh
{
	private string z0cek;

	private int z0xek;

	internal int z0zek = -1;

	private string z0lrk;

	private string z0krk;

	private string z0jrk;

	private XTextElementList z0hrk = new XTextElementList();

	private DateTime z0grk = z0ZzZzkfh.z0wrk;

	internal int z0frk = -1;

	private UserTrackType z0drk;

	private string z0srk;

	private string z0ark;

	internal int z0qrk = -1;

	private string z0wrk;

	private string z0erk;

	internal int z0rrk = -1;

	public DateTime z0eek()
	{
		return z0grk;
	}

	public string z0rek()
	{
		return z0ark;
	}

	public void z0eek(string p0)
	{
		z0lrk = p0;
	}

	public string z0tek()
	{
		return z0srk;
	}

	public void z0eek(int p0)
	{
		z0xek = p0;
	}

	public int z0yek()
	{
		return z0xek;
	}

	public void z0rek(string p0)
	{
		z0wrk = p0;
	}

	public void z0eek(UserTrackType p0)
	{
		z0drk = p0;
	}

	public void z0eek(DateTime p0)
	{
		z0grk = p0;
	}

	public void z0tek(string p0)
	{
		z0ark = p0;
	}

	public string z0uek()
	{
		return z0krk;
	}

	public void z0yek(string p0)
	{
		z0srk = p0;
	}

	public void z0uek(string p0)
	{
		z0krk = p0;
	}

	public string z0iek()
	{
		if (z0erk == null)
		{
			z0erk = z0hrk.z0hrk();
		}
		return z0erk;
	}

	public void z0iek(string p0)
	{
		z0cek = p0;
	}

	public string z0oek()
	{
		if (z0lrk == null)
		{
			string text = string.Empty;
			if (z0eek() != z0ZzZzkfh.z0wrk)
			{
				text = z0eek().ToString(z0ZzZzkfh.z0qrk);
			}
			text = text + z0ZzZziok.z0aik() + z0mek();
			if (z0pek() == UserTrackType.Create)
			{
				return text + z0ZzZziok.z0nuk();
			}
			if (z0pek() == UserTrackType.Comment)
			{
				return text + z0ZzZziok.z0zok();
			}
			if (z0pek() == UserTrackType.Checked)
			{
				return text + "勾选";
			}
			if (z0pek() == UserTrackType.UnChecked)
			{
				return text + "去掉勾选";
			}
			return text + z0ZzZziok.z0btk();
		}
		return z0lrk;
	}

	public void z0oek(string p0)
	{
	}

	public UserTrackType z0pek()
	{
		return z0drk;
	}

	public string z0mek()
	{
		return z0wrk;
	}

	public void z0eek(XTextElementList p0)
	{
		z0hrk = p0;
	}

	public XTextElementList z0nek()
	{
		return z0hrk;
	}

	public string z0bek()
	{
		return z0jrk;
	}

	public string z0vek()
	{
		return z0cek;
	}

	public void z0pek(string p0)
	{
		z0jrk = p0;
	}
}
