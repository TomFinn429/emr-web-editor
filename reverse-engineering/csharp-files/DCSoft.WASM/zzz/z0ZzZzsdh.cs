using System;
using DCSystem_Drawing;

namespace zzz;

public sealed class z0ZzZzsdh : IDisposable
{
	private float z0vek;

	private GraphicsUnit z0cek = GraphicsUnit.Point;

	private FontStyle z0xek;

	private bool z0zek;

	private string z0lrk;

	private bool z0eek(FontStyle p0)
	{
		z0bek();
		return (z0xek & p0) == p0;
	}

	public z0ZzZzsdh(string p0, FontStyle p1)
	{
		z0lrk = p0;
		z0vek = 9f;
		z0xek = p1;
	}

	public z0ZzZzsdh(string p0, float p1, FontStyle p2, GraphicsUnit p3)
	{
		z0lrk = p0;
		z0vek = p1;
		z0xek = p2;
		z0cek = p3;
	}

	public z0ZzZzsdh(string p0, float p1, GraphicsUnit p2)
	{
		z0lrk = p0;
		z0vek = p1;
		z0cek = p2;
	}

	public void Dispose()
	{
		z0lrk = null;
		z0zek = true;
	}

	public z0ZzZzsdh(z0ZzZzsdh p0, FontStyle p1)
	{
		z0lrk = p0.z0pek();
		z0vek = p0.z0yek();
		z0cek = p0.z0cek;
		z0xek = p1;
	}

	public bool z0eek()
	{
		z0bek();
		return z0eek(FontStyle.Bold);
	}

	public GraphicsUnit z0rek()
	{
		z0bek();
		return z0cek;
	}

	public bool z0tek()
	{
		z0bek();
		return z0eek(FontStyle.Italic);
	}

	public float z0yek()
	{
		z0bek();
		return z0vek;
	}

	public bool z0uek()
	{
		z0bek();
		return z0eek(FontStyle.Strikeout);
	}

	public bool z0iek()
	{
		z0bek();
		return z0eek(FontStyle.Underline);
	}

	public float z0eek(z0ZzZzadh p0)
	{
		return z0ZzZzpij.z0eek(z0lrk, z0xek)?.z0rek(z0vek, p0.z0jrk()) ?? z0ZzZzrpk.z0eek(z0vek, z0cek, p0.z0jrk());
	}

	public float z0oek()
	{
		return z0vek;
	}

	public z0ZzZzsdh(string p0, float p1)
	{
		z0lrk = p0;
		z0vek = p1;
	}

	public string z0pek()
	{
		z0bek();
		return z0lrk;
	}

	public FontStyle z0mek()
	{
		z0bek();
		return z0xek;
	}

	public bool z0eek(z0ZzZzsdh p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0 == this)
		{
			return true;
		}
		if (z0lrk == p0.z0lrk && z0vek == p0.z0vek && z0xek == p0.z0xek)
		{
			return z0cek == p0.z0cek;
		}
		return false;
	}

	public float z0nek()
	{
		return z0vek;
	}

	public float z0eek(GraphicsUnit p0)
	{
		return z0ZzZzpij.z0eek(z0lrk, z0xek)?.z0rek(z0vek, p0) ?? z0ZzZzrpk.z0eek(z0vek, z0cek, p0);
	}

	private void z0bek()
	{
		if (z0zek)
		{
			throw new ObjectDisposedException(" Font");
		}
	}

	public z0ZzZzsdh(string p0, float p1, FontStyle p2)
	{
		z0lrk = p0;
		z0vek = p1;
		z0xek = p2;
	}

	public void z0eek(bool p0)
	{
		z0bek();
		if (p0)
		{
			z0xek |= FontStyle.Bold;
		}
		else
		{
			z0xek &= ~FontStyle.Bold;
		}
	}
}
