using zzz;

namespace DCSoft.Writer.Dom;

public class CopySourceInfo : z0ZzZzcuk
{
	private bool z0oek = true;

	private string z0pek;

	private string z0mek;

	private string z0nek;

	public string z0eek()
	{
		return z0mek;
	}

	public void z0eek(bool p0)
	{
		z0oek = p0;
	}

	public void DCReadString(string text)
	{
		z0ZzZzmik.z0eek(this, text);
	}

	public CopySourceInfo z0rek()
	{
		return (CopySourceInfo)MemberwiseClone();
	}

	public void z0eek(string p0)
	{
		z0nek = p0;
	}

	public string z0tek()
	{
		return z0pek;
	}

	public bool z0yek()
	{
		return z0oek;
	}

	public bool z0uek()
	{
		if (string.IsNullOrEmpty(z0nek) && string.IsNullOrEmpty(z0pek) && string.IsNullOrEmpty(z0mek))
		{
			return z0oek;
		}
		return false;
	}

	public override string ToString()
	{
		return z0ZzZzmik.z0rek(this, p1: true);
	}

	public string z0iek()
	{
		return z0nek;
	}

	public void z0rek(string p0)
	{
		z0mek = p0;
	}

	public string DCWriteString()
	{
		return ToString();
	}

	public void z0tek(string p0)
	{
		z0pek = p0;
	}
}
