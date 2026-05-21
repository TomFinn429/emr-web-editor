using System;
using zzz;

namespace DCSoft.Writer.Dom;

public class InputFieldSettings : ICloneable
{
	private static readonly string z0lrk = ",";

	private string z0hrk;

	private int z0grk;

	private z0ZzZzsvj z0frk;

	private InputFieldEditStyle z0drk;

	private static string[] z0qrk = null;

	private string z0wrk = z0lrk;

	internal InputFieldEditStyle z0eek()
	{
		return z0drk;
	}

	public void z0eek(bool p0)
	{
		z0grk = (p0 ? (z0grk | 8) : (z0grk & -9));
	}

	public InputFieldSettings z0rek()
	{
		return (InputFieldSettings)((ICloneable)this).Clone();
	}

	public void z0rek(bool p0)
	{
		z0grk = (p0 ? (z0grk | 2) : (z0grk & -3));
	}

	public void z0eek(string p0)
	{
		z0wrk = p0;
	}

	public void z0tek(bool p0)
	{
		z0grk = (p0 ? (z0grk | 1) : (z0grk & -2));
	}

	public string z0tek()
	{
		return z0hrk;
	}

	public bool z0yek()
	{
		return (z0grk & 8) != 0;
	}

	public bool z0uek()
	{
		return (z0grk & 0x10) != 0;
	}

	public bool z0iek()
	{
		return (z0grk & 1) != 0;
	}

	public void z0yek(bool p0)
	{
		z0grk = (p0 ? (z0grk | 4) : (z0grk & -5));
	}

	public void z0uek(bool p0)
	{
		z0grk = (p0 ? (z0grk | 0x10) : (z0grk & -17));
	}

	public static void z0eek(string[] p0)
	{
		z0qrk = p0;
	}

	public string z0oek()
	{
		return z0wrk;
	}

	public void z0pek()
	{
		if (z0frk == null)
		{
			z0frk = new z0ZzZzsvj();
		}
		if (z0frk.IsEmpty)
		{
			z0frk = null;
		}
	}

	public void z0rek(string p0)
	{
		z0hrk = p0;
	}

	public static string[] z0mek()
	{
		return z0qrk;
	}

	public void z0eek(InputFieldEditStyle p0)
	{
		z0drk = p0;
	}

	public InputFieldEditStyle z0nek()
	{
		return z0drk;
	}

	public bool z0bek()
	{
		return (z0grk & 2) != 0;
	}

	public override string ToString()
	{
		if (z0nek() == InputFieldEditStyle.Text)
		{
			return "Text";
		}
		if (z0nek() == InputFieldEditStyle.DropdownList)
		{
			if (z0zek() == null)
			{
				return "None list item";
			}
			return "List:" + z0zek().ToString();
		}
		if (z0nek() == InputFieldEditStyle.Date)
		{
			return "DateTime ";
		}
		return string.Empty;
	}

	public void z0eek(z0ZzZzsvj p0)
	{
		z0frk = p0;
	}

	private object z0vek()
	{
		InputFieldSettings inputFieldSettings = (InputFieldSettings)MemberwiseClone();
		if (z0frk != null)
		{
			inputFieldSettings.z0frk = z0frk.Clone();
		}
		return inputFieldSettings;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0vek
		return this.z0vek();
	}

	public string z0cek()
	{
		return z0ZzZzwik.z0eek(z0oek());
	}

	public bool z0xek()
	{
		return (z0grk & 4) != 0;
	}

	public z0ZzZzsvj z0zek()
	{
		return z0frk;
	}
}
