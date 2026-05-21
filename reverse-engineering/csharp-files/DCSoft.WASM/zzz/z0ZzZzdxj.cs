using System;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzdxj : IDisposable
{
	private bool z0mek;

	private bool z0nek;

	private bool z0bek = true;

	private bool z0vek;

	private bool[] z0cek;

	private bool z0xek;

	private StringBuilder z0zek = new StringBuilder();

	private bool z0lrk;

	internal int z0eek()
	{
		return z0zek.Length;
	}

	internal void z0rek()
	{
		z0zek.AppendLine();
	}

	public void z0eek(bool p0)
	{
		z0mek = p0;
	}

	public void z0rek(bool p0)
	{
		z0bek = p0;
	}

	internal bool z0eek(int p0)
	{
		if (p0 < 0 || z0cek == null)
		{
			return true;
		}
		if (p0 < z0cek.Length)
		{
			return z0cek[p0];
		}
		return true;
	}

	public void z0tek(bool p0)
	{
		z0xek = p0;
	}

	public void z0yek(bool p0)
	{
		z0lrk = p0;
	}

	internal void z0eek(char p0)
	{
		z0zek.Append(p0);
	}

	public void Dispose()
	{
		if (z0zek != null)
		{
			z0zek.Clear();
			z0zek = null;
		}
		z0cek = null;
		z0nek = false;
	}

	internal void z0eek(XTextDocument p0)
	{
		if (z0zek == null)
		{
			z0zek = new StringBuilder();
		}
		else
		{
			z0zek.Clear();
		}
		if (z0nek)
		{
			return;
		}
		z0cek = p0.z0gnk().z0eek(z0uek());
		if (z0cek != null)
		{
			bool flag = true;
			for (int num = z0cek.Length - 1; num >= 0; num--)
			{
				if (!z0cek[num])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				z0cek = null;
			}
		}
		z0nek = true;
	}

	public override string ToString()
	{
		if (z0zek == null)
		{
			return null;
		}
		return z0zek.ToString();
	}

	public bool z0tek()
	{
		return z0mek;
	}

	public bool z0yek()
	{
		return z0lrk;
	}

	public bool z0uek()
	{
		return z0vek;
	}

	internal void z0eek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			z0zek.Append(p0);
		}
	}

	internal void z0iek()
	{
		if (z0zek.Length > 0)
		{
			char c = z0zek[z0zek.Length - 1];
			if (c != '\r' && c != '\n')
			{
				z0zek.AppendLine();
			}
		}
	}

	public void z0uek(bool p0)
	{
		z0vek = p0;
	}

	public bool z0oek()
	{
		return z0xek;
	}

	public bool z0pek()
	{
		return z0bek;
	}
}
