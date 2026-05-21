using System;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzrlh
{
	private DetectResultForValueBindingModifiedList z0nek;

	private string[] z0bek;

	private object z0vek;

	private bool z0cek;

	private XTextElementList z0xek;

	private object z0zek;

	private bool z0lrk;

	private XTextElementList z0krk;

	public bool z0eek()
	{
		return z0cek;
	}

	public void z0eek(object p0)
	{
		z0zek = p0;
	}

	public XTextElementList z0rek()
	{
		return z0xek;
	}

	public bool z0tek_jiejie20260327142557()
	{
		return z0lrk;
	}

	public z0ZzZzrlh z0yek()
	{
		return (z0ZzZzrlh)MemberwiseClone();
	}

	public z0ZzZzrlh()
	{
	}

	public z0ZzZzrlh(object p0, bool p1)
	{
		z0zek = p0;
		z0cek = p1;
	}

	public object z0uek()
	{
		return z0vek;
	}

	public void z0rek(object p0)
	{
		z0vek = p0;
	}

	public void z0eek(XTextElementList p0)
	{
		z0krk = p0;
	}

	public void z0eek(string[] p0)
	{
		z0bek = p0;
	}

	public XTextElementList z0iek()
	{
		return z0krk;
	}

	public DetectResultForValueBindingModifiedList z0oek()
	{
		return z0nek;
	}

	public string[] z0pek()
	{
		return z0bek;
	}

	public void z0eek(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (z0xek == null)
		{
			z0xek = new XTextElementList();
		}
		z0xek.Add(p0);
	}

	public void z0eek(bool p0)
	{
		z0lrk = p0;
	}

	public void z0eek(DetectResultForValueBindingModified p0)
	{
		if (z0nek == null)
		{
			z0nek = new DetectResultForValueBindingModifiedList();
		}
		z0nek.Add(p0);
	}

	public void z0rek(bool p0)
	{
		z0cek = p0;
	}

	public object z0mek()
	{
		return z0zek;
	}
}
