using System;
using System.Collections.Generic;
using System.IO;

namespace zzz;

internal class z0ZzZzuyj : IDisposable
{
	private z0ZzZzkyj z0jrk;

	private z0ZzZzoyj z0hrk;

	private bool z0grk;

	private int z0frk;

	private bool z0drk = true;

	private int z0srk;

	public bool z0ark;

	private z0ZzZzoyj z0qrk_jiejie20260327142557;

	private TextReader z0wrk;

	private Stack<z0ZzZzyyj> z0erk = new Stack<z0ZzZzyyj>();

	public z0ZzZzyyj z0eek()
	{
		if (z0erk.Count == 0)
		{
			z0erk.Push(new z0ZzZzyyj());
		}
		return z0erk.Peek();
	}

	public z0ZzZzoyj z0rek()
	{
		if (z0ark)
		{
			z0ark = false;
			return z0hrk;
		}
		z0grk = false;
		z0qrk_jiejie20260327142557 = z0hrk;
		if (z0qrk_jiejie20260327142557 != null && z0qrk_jiejie20260327142557.z0uek() == (z0ZzZzpyj)6)
		{
			z0grk = true;
		}
		z0hrk = z0jrk.z0rek();
		if (z0hrk == null || z0hrk.z0uek() == (z0ZzZzpyj)5)
		{
			z0hrk = null;
			return null;
		}
		z0frk++;
		if (z0hrk.z0uek() == (z0ZzZzpyj)6)
		{
			if (z0erk.Count == 0)
			{
				z0erk.Push(new z0ZzZzyyj());
			}
			else
			{
				z0ZzZzyyj z0ZzZzyyj2 = z0erk.Peek();
				z0erk.Push(z0ZzZzyyj2.z0rek());
			}
			z0srk++;
		}
		else if (z0hrk.z0uek() == (z0ZzZzpyj)7)
		{
			if (z0erk.Count > 0)
			{
				z0erk.Pop();
			}
			z0srk--;
		}
		if (z0nek())
		{
			z0tek();
		}
		return z0hrk;
	}

	public void z0tek()
	{
		if (z0cek() != null && z0cek().z0rek() == "uc")
		{
			z0eek().z0eek(z0xek());
		}
	}

	public bool z0yek_jiejie20260327142557()
	{
		return z0grk;
	}

	public bool z0uek()
	{
		if (z0hrk == null)
		{
			return false;
		}
		return z0hrk.z0tek();
	}

	public z0ZzZzpyj z0iek()
	{
		if (z0hrk == null)
		{
			return (z0ZzZzpyj)0;
		}
		return z0hrk.z0uek();
	}

	public TextReader z0oek()
	{
		return z0wrk;
	}

	public z0ZzZzpyj z0pek()
	{
		return z0jrk.z0tek();
	}

	public z0ZzZzoyj z0mek()
	{
		return z0qrk_jiejie20260327142557;
	}

	public bool z0nek()
	{
		return z0drk;
	}

	public void z0bek()
	{
		if (z0wrk != null)
		{
			z0wrk.Close();
			z0wrk = null;
		}
	}

	public z0ZzZzuyj(TextReader p0)
	{
		z0eek(p0);
	}

	public string z0vek()
	{
		if (z0hrk == null)
		{
			return null;
		}
		return z0hrk.z0rek();
	}

	public z0ZzZzoyj z0cek()
	{
		return z0hrk;
	}

	public bool z0eek(TextReader p0)
	{
		z0hrk = null;
		if (p0 != null)
		{
			z0wrk = p0;
			z0jrk = new z0ZzZzkyj(z0wrk);
			return true;
		}
		return false;
	}

	public int z0xek()
	{
		if (z0hrk == null)
		{
			return 0;
		}
		return z0hrk.z0eek();
	}

	public int z0zek()
	{
		return z0frk;
	}

	public void Dispose()
	{
		z0bek();
	}

	public int z0lrk()
	{
		return z0srk;
	}

	public void z0krk()
	{
		int num = 0;
		while (true)
		{
			switch (z0wrk.Peek())
			{
			case 123:
				num++;
				break;
			case 125:
				num--;
				if (num < 0)
				{
					return;
				}
				break;
			case -1:
				return;
			}
			int num2 = z0wrk.Read();
		}
	}
}
