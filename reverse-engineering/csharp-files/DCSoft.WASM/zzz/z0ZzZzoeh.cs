using System;
using System.Text;

namespace zzz;

public class z0ZzZzoeh
{
	public enum z0chj_jiejie20260327142557
	{
		z0eek,
		z0rek,
		z0tek,
		z0yek,
		z0uek,
		z0iek,
		z0oek,
		z0pek,
		z0mek,
		z0nek_jiejie20260327142557,
		z0bek
	}

	private z0chj_jiejie20260327142557 z0iek;

	private StringBuilder z0oek;

	private int z0pek;

	private int z0mek;

	private object z0nek;

	public void z0eek(z0ZzZzgeh p0)
	{
		z0eek(z0chj_jiejie20260327142557.z0pek);
		z0oek.Append(',');
		z0eek((int)z0ZzZzmwh.z0oek());
		z0oek.Append(',');
		z0eek(p0.z0eek());
	}

	public void z0eek(z0ZzZzweh p0)
	{
		z0eek(z0chj_jiejie20260327142557.z0uek, p0);
	}

	private z0ZzZzoeh()
	{
	}

	public z0chj_jiejie20260327142557 z0eek()
	{
		return z0iek;
	}

	public void z0eek(z0ZzZzheh p0)
	{
		z0eek(z0chj_jiejie20260327142557.z0oek);
		z0oek.Append(',');
		z0eek((int)z0ZzZzmwh.z0oek());
		z0oek.Append(',');
		z0eek((int)p0.z0eek());
	}

	public void z0eek(string[] p0)
	{
		z0eek(z0chj_jiejie20260327142557.z0bek);
		z0oek.Append(',');
		z0oek.Append(p0.Length.ToString());
		for (int i = 0; i < p0.Length; i++)
		{
			z0oek.Append(',');
			if (string.IsNullOrEmpty(p0[i]))
			{
				z0oek.Append("[null]");
			}
			else
			{
				z0oek.Append(Convert.ToBase64String(Encoding.UTF8.GetBytes(p0[i])));
			}
		}
	}

	private void z0eek(z0chj_jiejie20260327142557 p0)
	{
		if (z0oek.Length > 0)
		{
			z0oek.Append(',');
		}
		z0eek((int)p0);
		z0pek++;
	}

	private void z0eek(int p0)
	{
		z0oek.Append(z0ZzZzqik.z0rek(p0));
	}

	public int z0rek()
	{
		return z0pek;
	}

	public void z0rek(z0ZzZzweh p0)
	{
		z0eek(z0chj_jiejie20260327142557.z0rek, p0);
	}

	public void z0rek(z0ZzZzheh p0)
	{
		z0eek(z0chj_jiejie20260327142557.z0mek);
		z0oek.Append(',');
		z0eek((int)z0ZzZzmwh.z0oek());
		z0oek.Append(',');
		z0eek((int)p0.z0eek());
	}

	public object z0tek()
	{
		return z0nek;
	}

	private void z0eek(z0chj_jiejie20260327142557 p0, z0ZzZzweh p1)
	{
		z0eek(p0);
		z0oek.Append(',');
		z0eek((int)z0ZzZzmwh.z0oek());
		z0oek.Append(',');
		z0eek((int)p1.z0yek());
		z0oek.Append(',');
		z0eek(p1.z0uek());
		z0oek.Append(',');
		z0eek(p1.z0rek());
		z0oek.Append(',');
		z0eek(p1.z0tek());
		z0oek.Append(',');
		z0eek(p1.z0eek());
	}

	public string z0yek()
	{
		return z0oek.ToString();
	}

	public void z0tek(z0ZzZzweh p0)
	{
		z0eek(z0chj_jiejie20260327142557.z0tek, p0);
	}

	public void z0eek(z0ZzZzndh p0)
	{
		z0eek(z0chj_jiejie20260327142557.z0nek_jiejie20260327142557);
		z0oek.Append(',');
		z0eek((int)z0ZzZzmwh.z0oek());
		z0oek.Append(',');
		z0eek(p0.z0pek());
		z0oek.Append(',');
		z0eek(p0.z0mek());
		z0oek.Append(',');
		z0eek(p0.z0iek());
		z0oek.Append(',');
		z0eek(p0.z0oek());
	}

	public static z0ZzZzoeh z0uek()
	{
		return new z0ZzZzoeh
		{
			z0oek = new StringBuilder()
		};
	}

	public void z0yek(z0ZzZzweh p0)
	{
		z0eek(z0chj_jiejie20260327142557.z0iek, p0);
	}

	public void z0uek(z0ZzZzweh p0)
	{
		z0eek(z0chj_jiejie20260327142557.z0yek, p0);
	}
}
