using System.Collections.Generic;

namespace zzz;

public class z0ZzZzjyj
{
	private List<z0ZzZzhyj> z0iek = new List<z0ZzZzhyj>();

	private bool z0oek;

	private int z0pek;

	private int z0mek;

	public void z0rek(bool p0)
	{
		z0oek = p0;
	}

	public int z0rek()
	{
		return z0mek;
	}

	public void z0rek(int p0)
	{
		z0mek = p0;
	}

	public List<z0ZzZzhyj> z0tek()
	{
		if (z0iek == null)
		{
			z0iek = new List<z0ZzZzhyj>();
		}
		return z0iek;
	}

	public void z0tek(int p0)
	{
		z0pek = p0;
	}

	public bool z0yek()
	{
		return z0oek;
	}

	public void z0eek(List<z0ZzZzhyj> p0)
	{
		z0iek = p0;
	}

	public z0ZzZzhyj z0yek(int p0)
	{
		if (z0tek().Count <= p0)
		{
			for (int i = z0tek().Count; i <= p0; i++)
			{
				z0tek().Add(new z0ZzZzhyj());
			}
		}
		if (p0 < 0)
		{
			if (z0tek().Count == 0)
			{
				z0tek().Add(new z0ZzZzhyj());
			}
			return z0tek()[0];
		}
		return z0tek()[p0];
	}

	public z0ZzZzhyj z0uek(int p0)
	{
		if (p0 >= 0 && p0 < z0tek().Count)
		{
			return z0tek()[p0];
		}
		if (z0tek().Count > 0)
		{
			return z0tek()[0];
		}
		return null;
	}

	public int z0uek()
	{
		return z0pek;
	}
}
