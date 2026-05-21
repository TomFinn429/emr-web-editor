using System;

namespace zzz;

public class z0ZzZzysh : z0ZzZziah
{
	private sealed class z0imk
	{
		internal string z0eek;

		internal z0imk? z0rek_jiejie20260327142557;

		internal int z0tek;

		internal z0imk(string p0, int p1, z0imk? p2)
		{
			z0eek = p0;
			z0tek = p1;
			z0rek_jiejie20260327142557 = p2;
		}
	}

	private int z0tek;

	private int z0yek;

	private z0imk?[] z0uek;

	internal string z0eek(string p0, int p1)
	{
		for (z0imk z0imk = z0uek[p1 & z0yek]; z0imk != null; z0imk = z0imk.z0rek_jiejie20260327142557)
		{
			if (z0imk.z0tek == p1 && z0imk.z0eek.Equals(p0))
			{
				return z0imk.z0eek;
			}
		}
		return z0rek(p0, p1);
	}

	private void z0eek()
	{
		int num = z0yek * 2 + 1;
		z0imk[] array = z0uek;
		z0imk[] array2 = new z0imk[num + 1];
		for (int i = 0; i < array.Length; i++)
		{
			z0imk z0imk = array[i];
			while (z0imk != null)
			{
				int num2 = z0imk.z0tek & num;
				z0imk? z0rek_jiejie20260327142557 = z0imk.z0rek_jiejie20260327142557;
				z0imk.z0rek_jiejie20260327142557 = array2[num2];
				array2[num2] = z0imk;
				z0imk = z0rek_jiejie20260327142557;
			}
		}
		z0uek = array2;
		z0yek = num;
	}

	private string z0rek(string p0, int p1)
	{
		int num = p1 & z0yek;
		z0imk z0imk = new z0imk(p0, p1, z0uek[num]);
		z0uek[num] = z0imk;
		if (z0tek++ == z0yek)
		{
			z0eek();
		}
		return z0imk.z0eek;
	}

	internal static int z0eek(string p0)
	{
		return string.GetHashCode(p0.AsSpan());
	}

	public z0ZzZzysh()
	{
		z0yek = 31;
		z0uek = new z0imk[z0yek + 1];
	}

	public void z0rek()
	{
		if (z0uek != null && z0uek.Length != 0)
		{
			z0imk[] array = z0uek;
			foreach (z0imk z0imk in array)
			{
				if (z0imk != null)
				{
					z0imk.z0eek = null;
					z0imk.z0rek_jiejie20260327142557 = null;
				}
			}
			Array.Clear(z0uek);
			z0uek = null;
		}
		z0tek = 0;
	}

	public override string z0nf(string p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0.Length == 0)
		{
			return string.Empty;
		}
		int num = z0eek(p0);
		for (z0imk z0imk = z0uek[num & z0yek]; z0imk != null; z0imk = z0imk.z0rek_jiejie20260327142557)
		{
			if (z0imk.z0tek == num && z0imk.z0eek.Equals(p0))
			{
				return z0imk.z0eek;
			}
		}
		return z0rek(p0, num);
	}
}
