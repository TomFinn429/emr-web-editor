using System;

namespace zzz;

internal class z0ZzZzfaj : z0ZzZzodj
{
	private new bool z0rek;

	private new int[] z0tek;

	private bool z0yek_jiejie20260327142557;

	internal new static readonly string z0uek = "loca";

	internal void z0eek(z0ZzZzzfj p0)
	{
		z0ZzZzkdj z0ZzZzkdj2 = p0.z0lrk();
		z0yek_jiejie20260327142557 = z0ZzZzkdj2 != null && z0ZzZzkdj2.z0tek() == (z0ZzZzlsj)0;
		int num = (z0yek_jiejie20260327142557 ? (z0iek() / 2) : (z0iek() / 4));
		if (num > 1)
		{
			z0ZzZzqdj z0ZzZzqdj2 = p0.z0xek();
			if (z0ZzZzqdj2 != null)
			{
				int num2 = z0ZzZzqdj2.z0eek() + 1;
				if (num > num2)
				{
					num = num2;
				}
				else if (num < num2)
				{
					z0ZzZzqdj2.z0eek(num - 1);
				}
			}
			z0ZzZzjgj z0ZzZzjgj2 = z0uek();
			z0ZzZzjgj2.z0eek(0L);
			z0tek = new int[num];
			if (z0yek_jiejie20260327142557)
			{
				for (int i = 0; i < num; i++)
				{
					z0tek[i] = z0ZzZzjgj2.z0rek() * 2;
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					z0tek[j] = z0ZzZzjgj2.z0nek();
				}
			}
		}
		else
		{
			z0tek = Array.Empty<int>();
		}
	}

	internal z0ZzZzfaj(z0ZzZzjgj p0)
		: base(z0uek, p0)
	{
	}

	internal void z0eek(int[] p0)
	{
		z0tek = p0;
		z0rek = true;
	}

	protected override void z0bfk()
	{
		base.z0bfk();
		if (!z0rek)
		{
			return;
		}
		z0ZzZzuxk z0ZzZzuxk2 = z0yek().z0pek();
		int num = z0tek.Length;
		if (z0yek_jiejie20260327142557)
		{
			for (int i = 0; i < num; i++)
			{
				z0ZzZzuxk2.z0eek((short)(z0tek[i] / 2));
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				z0ZzZzuxk2.z0yek(z0tek[j]);
			}
		}
	}

	internal new int[] z0eek()
	{
		return z0tek;
	}
}
