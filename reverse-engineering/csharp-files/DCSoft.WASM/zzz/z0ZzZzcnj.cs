using System;
using System.Text;
using System.Windows.Forms;

namespace zzz;

internal class z0ZzZzcnj : ICloneable
{
	private bool z0iek;

	private Keys z0oek;

	private bool z0pek;

	private bool z0mek;

	public bool z0eek()
	{
		return z0mek;
	}

	public z0ZzZzcnj()
	{
	}

	public void z0eek(bool p0)
	{
		z0mek = p0;
	}

	public void z0rek(bool p0)
	{
		z0iek = p0;
	}

	public bool z0rek()
	{
		return z0iek;
	}

	public bool z0tek()
	{
		return z0pek;
	}

	private object z0yek()
	{
		return new z0ZzZzcnj
		{
			z0iek = z0iek,
			z0mek = z0mek,
			z0oek = z0oek,
			z0pek = z0pek
		};
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yek
		return this.z0yek();
	}

	public Keys z0uek()
	{
		return z0oek;
	}

	public z0ZzZzcnj(Keys p0)
	{
		z0mek = (p0 & Keys.Control) == Keys.Control;
		z0iek = (p0 & Keys.Alt) == Keys.Alt;
		z0pek = (p0 & Keys.Shift) == Keys.Shift;
		z0oek = p0 & Keys.KeyCode;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (z0mek)
		{
			stringBuilder.Append("Control ");
		}
		if (z0pek)
		{
			stringBuilder.Append("Shift ");
		}
		if (z0iek)
		{
			stringBuilder.Append("Alt ");
		}
		stringBuilder.Append(z0oek.ToString());
		return stringBuilder.ToString();
	}

	public void z0eek(Keys p0)
	{
		z0oek = p0;
	}

	public void z0tek(bool p0)
	{
		z0pek = p0;
	}
}
