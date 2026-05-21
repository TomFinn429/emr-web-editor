using System;
using System.Collections;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzulh
{
	private int z0pek;

	private int z0mek;

	private int z0nek;

	private int z0bek;

	private int z0vek;

	private int z0cek;

	private int z0xek;

	public int z0eek()
	{
		return z0bek;
	}

	public void z0eek(int p0)
	{
		z0nek = p0;
	}

	public void z0rek(int p0)
	{
		z0xek = p0;
	}

	public void z0tek(int p0)
	{
		z0cek = p0;
	}

	public int z0rek()
	{
		return z0vek;
	}

	public int z0tek()
	{
		return z0nek;
	}

	public int z0yek()
	{
		return z0pek;
	}

	public int z0uek()
	{
		return z0xek;
	}

	public z0ZzZzulh()
	{
	}

	public void z0yek(int p0)
	{
		z0bek = p0;
	}

	public z0ZzZzulh(XTextDocument p0, IEnumerable p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("content");
		}
		z0mek = p0.z0suk().Count;
		bool flag = false;
		z0ZzZzzlh z0ZzZzzlh2 = null;
		foreach (XTextElement item in p1)
		{
			if (z0ZzZzzlh2 != item.z0ptk())
			{
				z0ZzZzzlh2 = item.z0ptk();
				z0bek++;
			}
			if (item is XTextParagraphFlagElement)
			{
				z0pek++;
			}
			if (item is XTextCharElement)
			{
				char c = ((XTextCharElement)item).z0mek();
				z0cek++;
				if (!char.IsWhiteSpace(c))
				{
					z0xek++;
				}
				if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
				{
					if (!flag)
					{
						z0vek++;
					}
					flag = true;
				}
				else
				{
					if (!char.IsWhiteSpace(c))
					{
						z0vek++;
					}
					flag = false;
				}
			}
			else
			{
				flag = false;
				if (item is XTextImageElement)
				{
					z0nek++;
				}
			}
		}
	}

	public int z0iek()
	{
		return z0cek;
	}

	public void z0uek(int p0)
	{
		z0mek = p0;
	}

	public void z0iek(int p0)
	{
		z0pek = p0;
	}

	public int z0oek()
	{
		return z0mek;
	}

	public void z0oek(int p0)
	{
		z0vek = p0;
	}
}
