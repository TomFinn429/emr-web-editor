using System;
using System.Collections;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzhok
{
	internal enum z0opk
	{
		z0eek,
		z0rek,
		z0tek,
		z0yek,
		z0uek
	}

	private IEnumerator z0pek;

	private string z0mek;

	private object z0nek;

	private z0ZzZzfok z0bek = new z0ZzZzfok();

	public object z0eek(string p0)
	{
		return z0ZzZzdok.z0eek(z0eek()).z0eek(p0);
	}

	public z0ZzZzhok()
	{
	}

	public void z0eek(z0ZzZzfok p0)
	{
		z0bek = p0;
	}

	public object z0eek()
	{
		if (z0pek == null)
		{
			return null;
		}
		return z0pek.Current;
	}

	public z0ZzZzhok(object p0)
	{
		z0nek = p0;
	}

	public void z0rek()
	{
		int num = 0;
		foreach (z0ZzZzgok item in z0uek())
		{
			item.z0pek = num++;
		}
		if (z0nek == null)
		{
			foreach (z0ZzZzgok item2 in z0uek())
			{
				item2.z0iek = true;
			}
			return;
		}
		if (z0nek is z0ZzZzoah)
		{
			z0ZzZzoah z0ZzZzoah2 = (z0ZzZzoah)z0nek;
			if (!string.IsNullOrEmpty(z0iek()))
			{
				List<z0ZzZzoah> list = z0ZzZzoah2.z0rek(z0iek());
				z0pek = list.GetEnumerator();
			}
			else
			{
				z0pek = z0ZzZzoah2.z0tek().GetEnumerator();
			}
			foreach (z0ZzZzgok item3 in z0uek())
			{
				item3.z0iek = false;
				item3.z0nek = z0opk.z0yek;
			}
		}
		else if (z0nek is z0ZzZzpah)
		{
			z0ZzZzpah z0ZzZzpah2 = (z0ZzZzpah)z0nek;
			z0pek = z0ZzZzpah2.GetEnumerator();
			foreach (z0ZzZzgok item4 in z0uek())
			{
				item4.z0iek = false;
				item4.z0nek = z0opk.z0yek;
			}
		}
		else if (z0nek is IEnumerable)
		{
			IEnumerable enumerable = (IEnumerable)z0nek;
			z0pek = enumerable.GetEnumerator();
			foreach (z0ZzZzgok item5 in z0uek())
			{
				item5.z0iek = false;
				item5.z0nek = z0opk.z0tek;
			}
		}
		foreach (z0ZzZzgok item6 in z0uek())
		{
			if (string.IsNullOrEmpty(item6.z0rek()))
			{
				item6.z0iek = true;
			}
		}
	}

	public bool z0tek()
	{
		if (z0pek == null)
		{
			return false;
		}
		return z0pek.MoveNext();
	}

	public void z0yek()
	{
		z0rek();
		if (z0pek != null)
		{
			z0pek.Reset();
		}
	}

	public object z0eek(int p0)
	{
		if (p0 < 0 || p0 >= z0uek().Count)
		{
			throw new ArgumentOutOfRangeException("fieldIndex=" + p0);
		}
		if (z0uek()[p0].z0yek())
		{
			return null;
		}
		string p1 = z0uek()[p0].z0rek();
		return z0eek(p1);
	}

	public z0ZzZzfok z0uek()
	{
		return z0bek;
	}

	public void z0rek(string p0)
	{
		z0mek = p0;
	}

	public string z0iek()
	{
		return z0mek;
	}

	public object z0oek()
	{
		return z0nek;
	}

	public void z0eek(object p0)
	{
		z0nek = p0;
	}
}
