using System;
using System.Windows.Forms;

namespace zzz;

public class z0ZzZzheh
{
	private bool z0pek;

	private readonly Keys z0mek;

	public Keys z0eek()
	{
		return z0mek;
	}

	public bool z0rek()
	{
		return z0pek;
	}

	public Keys z0tek()
	{
		return z0mek & Keys.Modifiers;
	}

	public virtual bool z0yek()
	{
		return (z0mek & Keys.Shift) == Keys.Shift;
	}

	public z0ZzZzheh(Keys p0)
	{
		z0mek = p0;
	}

	public Keys z0uek()
	{
		Keys keys = z0mek & Keys.KeyCode;
		if (!Enum.IsDefined(typeof(Keys), (int)keys))
		{
			return Keys.None;
		}
		return keys;
	}

	public void z0eek(bool p0)
	{
		z0pek = p0;
	}

	public bool z0iek()
	{
		return (z0mek & Keys.Control) == Keys.Control;
	}

	public virtual bool z0oek()
	{
		return (z0mek & Keys.Alt) == Keys.Alt;
	}
}
