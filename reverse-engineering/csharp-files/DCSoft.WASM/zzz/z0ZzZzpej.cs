using System;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzpej : IDisposable
{
	public readonly GraphicsUnit z0uek;

	public readonly string z0iek;

	public string z0oek;

	private readonly int z0pek;

	public readonly FontStyle z0mek;

	private z0ZzZzoij z0nek;

	public readonly float z0bek;

	private z0ZzZzsdh z0vek;

	public bool z0eek()
	{
		return (z0mek & FontStyle.Bold) == FontStyle.Bold;
	}

	public bool z0eek(string p0, float p1, FontStyle p2)
	{
		if (z0iek == p0 && z0bek == p1)
		{
			return z0mek == p2;
		}
		return false;
	}

	public int z0eek(FontStyle p0)
	{
		return (int)z0tek().z0uek.z0ork.z0uek;
	}

	public z0ZzZzxdh z0eek(z0ZzZzadh p0, string p1, z0ZzZzxdh p2, z0ZzZzlsh p3)
	{
		return p0.z0eek(p1, z0yek(), p2, p3);
	}

	public float z0eek(float p0)
	{
		return z0tek().z0eek(z0bek, GraphicsUnit.Inch) * p0;
	}

	public int z0rek(FontStyle p0)
	{
		return (int)z0tek().z0uek.z0ork.z0tek(z0tek().z0uek.z0ork.z0uek);
	}

	public bool z0rek()
	{
		return (z0mek & FontStyle.Italic) == FontStyle.Italic;
	}

	private z0ZzZzoij z0tek()
	{
		if (z0nek == null)
		{
			z0nek = z0ZzZzoij.z0eek(z0iek, z0mek, z0uek);
		}
		return z0nek;
	}

	public void Dispose()
	{
		if (z0vek != null)
		{
			z0vek.Dispose();
			z0vek = null;
		}
		z0nek = null;
	}

	public int z0tek(FontStyle p0)
	{
		return (int)z0tek().z0uek.z0ork.z0rek(z0tek().z0uek.z0ork.z0uek);
	}

	public override int GetHashCode()
	{
		return z0pek;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		z0ZzZzpej z0ZzZzpej2 = (z0ZzZzpej)obj;
		if (z0iek == z0ZzZzpej2.z0iek && z0bek == z0ZzZzpej2.z0bek && z0mek == z0ZzZzpej2.z0mek)
		{
			return z0uek == z0ZzZzpej2.z0uek;
		}
		return false;
	}

	public override string ToString()
	{
		return z0iek + " " + z0bek + " " + z0mek;
	}

	public z0ZzZzpej(string p0, float p1, FontStyle p2 = FontStyle.Regular, GraphicsUnit p3 = GraphicsUnit.Point)
	{
		z0iek = p0;
		z0bek = p1;
		z0mek = p2;
		z0uek = p3;
		z0pek = p0.GetHashCode();
		z0pek += p1.GetHashCode();
		z0pek += (int)p2;
		z0pek += 10 * (int)p3;
	}

	public bool z0eek(z0ZzZzpej p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0 == this)
		{
			return true;
		}
		if (p0.z0pek == z0pek && z0iek == p0.z0iek && z0bek == p0.z0bek && z0mek == p0.z0mek)
		{
			return true;
		}
		return false;
	}

	public int z0yek(FontStyle p0)
	{
		return (int)z0tek().z0uek.z0ork.z0eek(z0tek().z0uek.z0ork.z0uek);
	}

	public z0ZzZzpej(z0ZzZzsdh p0)
		: this(p0.z0pek(), p0.z0yek(), p0.z0mek(), p0.z0rek())
	{
	}

	public z0ZzZzsdh z0yek()
	{
		if (z0vek == null)
		{
			z0vek = new z0ZzZzsdh(z0iek, z0bek, z0mek, z0uek);
		}
		return z0vek;
	}
}
