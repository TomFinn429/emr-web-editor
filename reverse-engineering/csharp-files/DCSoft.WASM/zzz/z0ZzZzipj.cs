using System;

namespace zzz;

public class z0ZzZzipj
{
	public EventHandler z0iek;

	private z0ZzZzmwh z0oek;

	private int z0pek;

	public void z0eek(z0ZzZzmwh p0)
	{
		z0oek = p0;
	}

	public z0ZzZzmwh z0eek()
	{
		return z0oek;
	}

	public void z0rek()
	{
		z0pek++;
	}

	public void z0tek()
	{
		z0pek = 0;
	}

	public void z0yek()
	{
		z0pek--;
		if (z0pek < 0)
		{
			z0pek = 0;
		}
		if (z0pek <= 0)
		{
			if (z0oek != null)
			{
				z0oek.z0jrk();
			}
			if (z0iek != null)
			{
				z0iek(this, null);
			}
		}
	}

	public bool z0uek()
	{
		return z0pek > 0;
	}
}
