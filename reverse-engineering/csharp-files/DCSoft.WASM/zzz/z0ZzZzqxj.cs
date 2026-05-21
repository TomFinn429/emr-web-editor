using System;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzqxj
{
	private bool z0oek;

	private Color z0pek = z0vek;

	private z0ZzZzkkh z0mek;

	private HighlightActiveStyle z0nek;

	internal XTextElement z0bek;

	private static readonly Color z0vek = z0ZzZzhsh.z0pek;

	private Color z0cek = z0ZzZzhsh.z0oek;

	public bool HeightClass
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	public static bool z0eek(z0ZzZzqxj p0, z0ZzZzqxj p1)
	{
		if (p0 == p1)
		{
			return true;
		}
		if (p0 == null || p1 == null)
		{
			return false;
		}
		if (!z0ZzZzkkh.z0eek(p0.z0rek(), p1.z0rek()) || p0.z0nek != p1.z0nek || p0.z0pek != p1.z0pek || p0.z0cek != p1.z0cek)
		{
			return false;
		}
		return true;
	}

	public void z0eek(Color p0)
	{
		z0cek = p0;
	}

	public void z0rek(Color p0)
	{
		z0pek = p0;
	}

	public void z0eek()
	{
		z0bek = null;
		if (z0mek != null)
		{
			z0mek.z0yek();
			z0mek = null;
		}
	}

	public z0ZzZzqxj()
	{
	}

	public z0ZzZzqxj(z0ZzZzkkh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("range");
		}
		z0mek = p0;
	}

	public z0ZzZzqxj(XTextElement p0, z0ZzZzkkh p1, Color p2)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("range");
		}
		z0mek = p1;
		z0pek = p2;
		z0bek = p0;
	}

	public z0ZzZzkkh z0rek()
	{
		return z0mek;
	}

	public HighlightActiveStyle z0tek()
	{
		return z0nek;
	}

	public Color z0yek()
	{
		return z0pek;
	}

	public bool z0eek(XTextElement p0)
	{
		return z0mek.z0eek(p0);
	}

	public Color z0uek()
	{
		return z0cek;
	}

	public XTextElement z0iek()
	{
		return z0bek;
	}

	public z0ZzZzqxj(XTextElement p0, z0ZzZzkkh p1, Color p2, Color p3, HighlightActiveStyle p4)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("range");
		}
		z0mek = p1;
		z0pek = p2;
		z0cek = p3;
		z0bek = p0;
		z0nek = p4;
	}
}
