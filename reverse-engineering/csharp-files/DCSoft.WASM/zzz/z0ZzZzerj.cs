using System;
using System.Collections.Generic;
using System.Diagnostics;
using DCSystem_Drawing;

namespace zzz;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class z0ZzZzerj : List<z0ZzZzwrj>
{
	protected bool z0oek;

	private int z0pek = 50;

	private GraphicsUnit z0mek = GraphicsUnit.Document;

	private float z0nek;

	public void z0eek(int p0)
	{
		z0pek = p0;
	}

	public void z0eek(float p0)
	{
		z0nek = p0;
	}

	public z0ZzZzerj z0eek(int p0, int p1)
	{
		if (p0 < 0 && p1 < 0)
		{
			return this;
		}
		if (p0 <= 0 && p1 >= base.Count - 1)
		{
			return this;
		}
		int num = Math.Max(0, p0);
		int num2 = base.Count - 1;
		if (p1 >= 0)
		{
			num2 = Math.Min(p1, base.Count - 1);
		}
		z0ZzZzerj z0ZzZzerj2 = new z0ZzZzerj();
		for (int i = num; i <= num2; i++)
		{
			z0ZzZzerj2.Add(base[i]);
		}
		return z0ZzZzerj2;
	}

	public GraphicsUnit z0eek()
	{
		return z0mek;
	}

	public z0ZzZzwrj z0rek(int p0)
	{
		if (p0 >= 0 && p0 < base.Count)
		{
			return base[p0];
		}
		return null;
	}

	public int z0rek()
	{
		return z0pek;
	}

	public int z0eek(float p0, int p1)
	{
		if (base.Count == 0)
		{
			return -1;
		}
		if (p0 == 0f && base[0].z0irk() == 0f)
		{
			return 0;
		}
		int num = 0;
		int num2 = base.Count - 1;
		while (num2 - num > 10)
		{
			int num3 = (num + num2) / 2;
			if (p0 >= base[num3].z0irk())
			{
				num = num3;
			}
			else
			{
				num2 = num3;
			}
		}
		for (int num4 = num2; num4 >= num; num4--)
		{
			if (p0 >= base[num4].z0irk())
			{
				return num4;
			}
		}
		return p1;
	}

	public z0ZzZzwrj z0tek()
	{
		if (base.Count > 0)
		{
			return base[base.Count - 1];
		}
		return null;
	}

	public float z0yek()
	{
		float num = 0f;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzwrj current = enumerator.Current;
			num += current.z0xek();
		}
		return num;
	}

	public float z0uek()
	{
		return z0nek;
	}

	public void z0eek(GraphicsUnit p0)
	{
		z0mek = p0;
	}

	public z0ZzZzwrj z0iek()
	{
		if (base.Count > 0)
		{
			return base[0];
		}
		return null;
	}
}
