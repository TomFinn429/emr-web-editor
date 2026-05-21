using System;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzajh
{
	private XTextDocument z0pek;

	private z0ZzZzkbk z0mek;

	private z0ZzZzhbk z0nek;

	private string z0bek;

	private z0ZzZzevk z0vek;

	private bool z0cek;

	public z0ZzZzkbk z0rek()
	{
		return z0mek;
	}

	public bool z0rek(string p0, out string p1)
	{
		return z0nek.z0eek(p0, out p1);
	}

	public T z0eek<T>(string p0)
	{
		string text = z0nek.z0rek(p0);
		if (text == null || text.Length == 0)
		{
			return default(T);
		}
		return (T)Enum.Parse(typeof(T), text);
	}

	public z0ZzZzevk z0tek()
	{
		return z0vek;
	}

	public z0ZzZzhbk z0yek()
	{
		return z0nek;
	}

	internal z0ZzZzajh(z0ZzZzajh p0, z0ZzZzhbk p1, XTextDocument p2, z0ZzZzevk p3)
	{
		if (p0 != null)
		{
			z0cek = p0.z0cek;
		}
		z0nek = p1;
		z0mek = p1.z0tek();
		z0pek = p2;
		z0vek = p3;
		z0bek = p1.z0cak();
	}

	public z0ZzZzgbk z0uek()
	{
		return z0nek.z0oqk();
	}

	public bool z0rek(string p0)
	{
		return z0nek.z0tek(p0);
	}

	public string z0tek(string p0)
	{
		return z0nek.z0rek(p0);
	}

	public XTextDocument z0iek()
	{
		return z0pek;
	}

	public string z0oek()
	{
		return z0bek;
	}
}
