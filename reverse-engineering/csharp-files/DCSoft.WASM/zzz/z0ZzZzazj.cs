using System;
using System.Collections.Generic;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzazj
{
	private readonly VerticalAlignStyle z0pek;

	private XTextElement z0mek;

	public z0ZzZzjxj z0nek = new z0ZzZzjxj();

	internal bool z0bek;

	private XTextElement[] z0vek;

	private bool z0cek;

	public bool z0xek = true;

	private List<z0ZzZzlkh> z0zek = new List<z0ZzZzlkh>();

	internal float z0lrk;

	internal int z0krk;

	private bool z0jrk;

	private XTextElement z0hrk;

	internal XTextParagraphFlagElement z0grk;

	internal bool z0frk;

	public z0ZzZzlkh z0eek()
	{
		if (z0zek.Count == 0)
		{
			return new z0ZzZzlkh();
		}
		z0ZzZzlkh result = z0zek[z0zek.Count - 1];
		z0zek.RemoveAt(z0zek.Count - 1);
		return result;
	}

	public VerticalAlignStyle z0rek()
	{
		return z0pek;
	}

	public void z0eek(z0ZzZzzlh p0)
	{
		if (z0vek != null)
		{
			p0.z0rek(z0vek, 0);
			z0vek = null;
		}
	}

	public void z0eek(bool p0)
	{
		z0jrk = p0;
	}

	public void z0tek()
	{
		if (z0nek != null)
		{
			z0nek.z0iek();
			z0nek = null;
		}
		if (z0vek != null)
		{
			Array.Clear(z0vek);
			z0vek = null;
		}
		if (z0zek != null)
		{
			foreach (z0ZzZzlkh item in z0zek)
			{
				item.z0ktk();
			}
			z0zek = null;
		}
		z0grk = null;
		z0hrk = null;
		z0mek = null;
	}

	public void z0rek(bool p0)
	{
		z0cek = p0;
	}

	public XTextElement z0yek()
	{
		return z0mek;
	}

	public z0ZzZzazj(XTextElement p0, XTextElement p1, VerticalAlignStyle p2)
	{
		z0hrk = p0;
		z0mek = p1;
		z0pek = p2;
	}

	public bool z0uek()
	{
		return z0jrk;
	}

	public XTextElement z0iek()
	{
		return z0hrk;
	}

	public bool z0oek()
	{
		return z0cek;
	}

	public void z0rek(z0ZzZzzlh p0)
	{
		if (p0.Capacity > p0.Count)
		{
			z0vek = ((zzz.z0ZzZzkuk<XTextElement>)p0).z0krk();
			XTextElement[] array = p0.ToArray();
			p0.z0rek(array, array.Length);
		}
	}

	public void z0eek(z0ZzZzlkh p0)
	{
		p0.z0nrk();
		z0zek.Add(p0);
	}
}
