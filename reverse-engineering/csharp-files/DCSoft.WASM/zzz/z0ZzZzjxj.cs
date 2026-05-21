using System;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzjxj
{
	private XTextElement[] z0oek;

	private int z0pek;

	private int z0mek;

	public void z0eek(XTextElement p0)
	{
		_ = z0oek[z0pek + 1];
		z0oek[++z0pek] = p0;
	}

	public XTextElement z0eek()
	{
		if (z0pek < z0mek - 1 && z0pek >= 0)
		{
			return z0oek[z0pek + 1];
		}
		return null;
	}

	public void z0rek()
	{
		z0pek = 0;
	}

	public void z0eek(XTextElementList p0, int p1, int p2)
	{
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException("index:" + p1);
		}
		if (p2 <= 0)
		{
			throw new ArgumentOutOfRangeException("length:" + p2);
		}
		if (p1 + p2 > p0.Count)
		{
			throw new ArgumentOutOfRangeException("index+length:" + Convert.ToString(p1 + p2));
		}
		if (z0oek == null || z0oek.Length < p2)
		{
			if (z0oek != null)
			{
				Array.Clear(z0oek);
			}
			z0oek = new XTextElement[p2];
		}
		XTextElement[] array = z0oek;
		z0mek = p2;
		XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)p0).z0krk();
		for (int num = p2 - 1; num >= 0; num--)
		{
			array[p2 - num - 1] = array2[p1 + num];
		}
		z0pek = z0mek - 1;
	}

	public XTextElement z0tek()
	{
		if (z0pek >= 0)
		{
			return z0oek[z0pek--];
		}
		return null;
	}

	public int z0yek()
	{
		return z0pek + 1;
	}

	public XTextElement z0uek()
	{
		if (z0pek >= 0)
		{
			return z0oek[z0pek];
		}
		return null;
	}

	public void z0iek()
	{
		if (z0oek != null)
		{
			Array.Clear(z0oek);
			z0oek = null;
		}
	}
}
