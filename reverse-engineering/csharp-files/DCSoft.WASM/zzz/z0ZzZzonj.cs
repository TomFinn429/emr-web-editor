using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzonj
{
	private string z0pek;

	private z0ZzZzjbj z0mek;

	private XTextElement z0nek;

	private ToolTipContentType z0bek;

	private bool z0vek;

	private string z0cek;

	private z0ZzZzkbj z0xek;

	public ToolTipContentType z0eek()
	{
		return z0bek;
	}

	public void z0eek(string p0)
	{
		z0cek = p0;
	}

	public z0ZzZzonj()
	{
	}

	public void z0eek(bool p0)
	{
		z0vek = p0;
	}

	public z0ZzZzonj(XTextElement p0, string p1)
	{
		z0nek = p0;
		z0pek = p1;
	}

	public z0ZzZzjbj z0rek()
	{
		return z0mek;
	}

	public void z0eek(ToolTipContentType p0)
	{
		z0bek = p0;
	}

	public void z0eek(z0ZzZzjbj p0)
	{
		z0mek = p0;
	}

	public string z0tek()
	{
		return z0cek;
	}

	public string z0yek()
	{
		return z0pek;
	}

	public bool z0eek(z0ZzZzonj p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0 == this)
		{
			return true;
		}
		if (z0bek == p0.z0bek && z0vek == p0.z0vek && z0nek == p0.z0nek && z0xek == p0.z0xek && z0mek == p0.z0mek && z0pek == p0.z0pek)
		{
			return z0cek == p0.z0cek;
		}
		return false;
	}

	public z0ZzZzkbj z0uek()
	{
		return z0xek;
	}

	public void z0rek(string p0)
	{
		z0pek = p0;
	}

	public void z0eek(XTextElement p0)
	{
		z0nek = p0;
	}

	public bool z0iek()
	{
		return z0vek;
	}

	public void z0eek(z0ZzZzkbj p0)
	{
		z0xek = p0;
	}

	public XTextElement z0oek()
	{
		return z0nek;
	}
}
