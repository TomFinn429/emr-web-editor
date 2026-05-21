using System;
using DCSoft.Writer.Dom;
using DCSoft.Writer.HtmlForms;

namespace zzz;

public sealed class z0ZzZzujh
{
	private int z0vek;

	private bool z0cek;

	private string z0xek;

	private string z0zek;

	private string z0lrk;

	private bool z0krk;

	[NonSerialized]
	internal XTextCheckBoxElementBase z0jrk;

	private string z0hrk;

	internal string z0grk;

	private string z0frk;

	private string z0drk;

	public string z0eek()
	{
		return z0drk;
	}

	internal bool z0rek()
	{
		if (z0krk)
		{
			return !string.IsNullOrEmpty(z0lrk);
		}
		return false;
	}

	public string z0tek()
	{
		return z0grk;
	}

	internal z0ZzZzujh(XTextCheckBoxElementBase p0, DCFormDocument p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		z0jrk = p0;
		z0tek(p0.ID);
		z0iek(p0.Caption);
		z0rek(p0.Checked);
		z0yek(p0.CheckedValue);
		z0eek(p0.ToolTip);
		z0uek(p0.z0ztk());
		z0rek(p0.ValueExpression);
		z0eek(p0.z0wtk());
	}

	public void z0eek(string p0)
	{
		z0zek = p0;
	}

	public void z0rek(string p0)
	{
		z0drk = p0;
	}

	public void z0tek(string p0)
	{
		z0xek = p0;
	}

	public string z0yek()
	{
		return z0lrk;
	}

	public void z0eek(bool p0)
	{
		z0cek = p0;
	}

	public void z0yek(string p0)
	{
		z0lrk = p0;
	}

	internal bool z0eek(bool p0, XTextDocument p1)
	{
		z0rek(p0);
		XTextCheckBoxElementBase xTextCheckBoxElementBase = z0jrk;
		if (xTextCheckBoxElementBase != null && xTextCheckBoxElementBase.Checked != p0)
		{
			xTextCheckBoxElementBase.Checked = p0;
			return true;
		}
		return false;
	}

	public void z0uek(string p0)
	{
		z0hrk = p0;
	}

	public void z0iek(string p0)
	{
		z0frk = p0;
	}

	public void z0rek(bool p0)
	{
		z0krk = p0;
	}

	internal void z0eek(DCFormDocument p0)
	{
		string text = z0xek;
		if (string.IsNullOrEmpty(text))
		{
			text = "id" + z0vek;
		}
		z0grk = p0.z0yek(text, p1: true);
	}

	public string z0uek()
	{
		return z0xek;
	}

	public int z0iek()
	{
		return z0vek;
	}

	public bool z0oek()
	{
		return z0cek;
	}

	public bool z0pek()
	{
		return z0krk;
	}

	public string z0mek()
	{
		return z0hrk;
	}

	public z0ZzZzujh()
	{
	}

	public string z0nek()
	{
		return z0zek;
	}

	public string z0bek()
	{
		return z0frk;
	}

	public void z0eek(int p0)
	{
		z0vek = p0;
	}
}
