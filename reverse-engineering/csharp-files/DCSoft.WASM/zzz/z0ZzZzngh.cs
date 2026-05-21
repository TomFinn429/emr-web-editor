using System;
using System.Collections.Generic;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
[Obfuscation(Exclude = true, ApplyToMembers = false)]
public class z0ZzZzngh : IDisposable
{
	private List<z0ZzZzogh> z0mek = new List<z0ZzZzogh>();

	public EventHandler z0nek;

	private bool z0bek;

	protected int z0vek;

	private List<z0ZzZzogh> z0cek;

	protected int z0xek = 100;

	public int Count => z0mek.Count;

	public void z0eek(bool p0)
	{
		z0bek = p0;
	}

	public virtual void Clear()
	{
		if (z0mek != null)
		{
			z0mek.Clear();
		}
		z0vek = 0;
		z0bek = false;
		z0cek = null;
		z0rek();
	}

	public void Add(z0ZzZzogh undo)
	{
		if (undo != null && z0cek != null && !z0cek.Contains(undo) && z0cek != null)
		{
			z0cek.Add(undo);
		}
	}

	public virtual void Dispose()
	{
		if (z0mek != null)
		{
			foreach (z0ZzZzogh item in z0mek)
			{
				item.Dispose();
			}
			z0mek.Clear();
			z0mek = null;
		}
		if (z0cek == null)
		{
			return;
		}
		foreach (z0ZzZzogh item2 in z0cek)
		{
			item2.Dispose();
		}
		z0cek.Clear();
		z0cek = null;
	}

	protected List<z0ZzZzogh> z0eek()
	{
		return z0cek;
	}

	protected virtual void z0rek()
	{
		if (z0nek != null)
		{
			z0nek(this, null);
		}
	}

	public bool z0eek(z0ZzZzpgh p0)
	{
		if (z0vek >= Count)
		{
			return false;
		}
		bool flag = z0bek;
		z0bek = true;
		try
		{
			z0vek++;
			z0ZzZzogh z0ZzZzogh2 = z0oek();
			if (z0ZzZzogh2 != null)
			{
				z0ZzZzogh2.z0yo(p0);
				z0rek();
				return true;
			}
		}
		finally
		{
			z0bek = flag;
		}
		return false;
	}

	public virtual void z0bo()
	{
		z0cek = null;
	}

	public bool z0tek()
	{
		return z0bek;
	}

	protected virtual z0ZzZzmgh z0vo()
	{
		return new z0ZzZzmgh();
	}

	public void z0eek(int p0)
	{
		z0xek = p0;
	}

	public virtual bool z0po()
	{
		if (z0bek)
		{
			z0cek = null;
			return false;
		}
		bool flag = false;
		if (z0cek != null && z0cek.Count > 0)
		{
			flag = true;
			int num = Count - 1;
			while (num > z0vek && num >= 0)
			{
				z0rek(num);
				num--;
			}
			if (z0cek.Count == 1 && !z0no())
			{
				z0mek.Add(z0cek[0]);
			}
			else
			{
				z0ZzZzmgh z0ZzZzmgh2 = z0vo();
				foreach (z0ZzZzogh item in z0cek)
				{
					z0ZzZzmgh2.z0eek(item);
				}
				z0mek.Add(z0ZzZzmgh2);
			}
			z0vek = Count - 1;
		}
		z0cek = null;
		if (z0xek > 0)
		{
			while (Count > z0xek)
			{
				flag = true;
				z0mek.RemoveAt(0);
				z0vek = Count - 1;
			}
		}
		if (flag)
		{
			z0rek();
		}
		return flag;
	}

	public bool z0yek()
	{
		if (z0vek + 1 >= 0)
		{
			return z0vek + 1 < Count;
		}
		return false;
	}

	protected virtual bool z0no()
	{
		return false;
	}

	public bool z0rek(z0ZzZzpgh p0)
	{
		if (z0vek < 0)
		{
			return false;
		}
		bool flag = z0bek;
		z0bek = true;
		try
		{
			z0ZzZzogh z0ZzZzogh2 = z0oek();
			z0vek--;
			if (z0ZzZzogh2 != null)
			{
				z0ZzZzogh2.z0to(p0);
				z0rek();
				return true;
			}
		}
		finally
		{
			z0bek = flag;
		}
		return false;
	}

	public int z0uek()
	{
		return z0xek;
	}

	public bool z0iek()
	{
		if (!z0bek)
		{
			return z0cek != null;
		}
		return false;
	}

	public virtual bool z0mo()
	{
		if (z0bek)
		{
			z0cek = null;
			return false;
		}
		z0cek = new List<z0ZzZzogh>();
		return true;
	}

	public z0ZzZzogh z0oek()
	{
		if (z0vek >= 0 && z0vek < Count)
		{
			return z0mek[z0vek];
		}
		return null;
	}

	public bool z0pek()
	{
		return z0oek() != null;
	}

	public void z0rek(int p0)
	{
		z0mek.RemoveAt(p0);
	}

	public z0ZzZzogh z0tek(int p0)
	{
		return z0mek[p0];
	}
}
