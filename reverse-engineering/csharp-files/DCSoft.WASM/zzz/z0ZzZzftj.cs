using System;
using System.Text;

namespace zzz;

public abstract class z0ZzZzftj
{
	private readonly z0ZzZzstj z0pek = new z0ZzZzstj();

	[NonSerialized]
	internal int z0mek = -1;

	private z0ZzZzxrj z0nek = new z0ZzZzxrj();

	private bool z0bek;

	private z0ZzZzftj z0vek;

	private z0ZzZzgtj z0cek;

	public z0ZzZzftj z0eek()
	{
		return z0vek;
	}

	public void z0eek(z0ZzZzxrj p0)
	{
		z0nek = p0;
	}

	public z0ZzZzxrj z0rek()
	{
		return z0nek;
	}

	public int z0eek(string p0, int p1)
	{
		if (z0nek.z0eek(p0))
		{
			return z0nek.z0rek(p0);
		}
		return p1;
	}

	public virtual string z0bjk()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (z0pek != null)
		{
			foreach (z0ZzZzftj item in z0pek)
			{
				stringBuilder.Append(item.z0bjk());
			}
		}
		return stringBuilder.ToString();
	}

	public void z0eek(bool p0)
	{
		if (z0bek != p0)
		{
			z0bek = p0;
			_ = this is z0ZzZzgtj;
		}
	}

	internal void z0tek()
	{
		if (z0uek().Count > 0 && z0uek().z0eek() is z0ZzZzitj)
		{
			z0ZzZzitj z0ZzZzitj2 = (z0ZzZzitj)z0uek().z0eek();
			if (z0ZzZzitj2.z0rek() && z0ZzZzitj2.z0uek().Count == 0)
			{
				z0uek().Remove(z0ZzZzitj2);
			}
		}
	}

	private void z0yek()
	{
		if (z0bek)
		{
			throw new InvalidOperationException("Element locked");
		}
	}

	public z0ZzZzstj z0uek()
	{
		return z0pek;
	}

	public void z0eek(z0ZzZzgtj p0)
	{
		z0cek = p0;
		foreach (z0ZzZzftj item in z0uek())
		{
			item.z0eek(p0);
		}
	}

	public z0ZzZzgtj z0iek()
	{
		return z0cek;
	}

	public int z0eek(z0ZzZzftj p0)
	{
		z0yek();
		p0.z0vek = this;
		p0.z0eek(z0cek);
		z0pek.Add(p0);
		return z0pek.Count - 1;
	}

	public bool z0oek()
	{
		return z0bek;
	}

	public bool z0eek(string p0)
	{
		return z0nek.z0eek(p0);
	}
}
