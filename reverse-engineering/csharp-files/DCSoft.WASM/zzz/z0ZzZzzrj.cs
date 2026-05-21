using System.Collections;
using System.Diagnostics;
using System.Reflection;
using DCSystem_Drawing;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzlyj))]
[DebuggerDisplay("Count={Count}")]
[DefaultMember("Item")]
public class z0ZzZzzrj
{
	private bool z0yek = true;

	private readonly ArrayList z0uek = new ArrayList();

	public void z0eek()
	{
		z0uek.Clear();
	}

	public Color z0eek(int p0, Color p1)
	{
		p0--;
		if (p0 >= 0 && p0 < z0uek.Count)
		{
			return (Color)z0uek[p0];
		}
		return p1;
	}

	public void z0eek(Color p0)
	{
		if (p0.IsEmpty || p0.A == 0)
		{
			return;
		}
		if (p0.A != 255)
		{
			p0 = Color.FromArgb(255, p0);
		}
		if (z0yek)
		{
			if (z0rek(p0) < 0)
			{
				z0uek.Add(p0);
			}
		}
		else
		{
			z0uek.Add(p0);
		}
	}

	public int z0rek()
	{
		return z0uek.Count;
	}

	public bool z0tek()
	{
		return z0yek;
	}

	public int z0rek(Color p0)
	{
		if (p0.A == 0)
		{
			return -1;
		}
		if (p0.A != 255)
		{
			p0 = Color.FromArgb(255, p0);
		}
		for (int i = 0; i < z0uek.Count; i++)
		{
			if (((Color)z0uek[i]).ToArgb() == p0.ToArgb())
			{
				return i;
			}
		}
		return -1;
	}

	public void z0eek(bool p0)
	{
		z0yek = p0;
	}

	public Color z0eek(int p0)
	{
		return (Color)z0uek[p0];
	}

	public int z0tek(Color p0)
	{
		return z0rek(p0) + 1;
	}
}
