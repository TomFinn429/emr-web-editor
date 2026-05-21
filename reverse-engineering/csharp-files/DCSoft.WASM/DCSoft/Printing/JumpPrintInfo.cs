using System.ComponentModel;
using zzz;

namespace DCSoft.Printing;

public class JumpPrintInfo
{
	private JumpPrintPositionMode z0iek;

	private JumpPrintMode z0oek;

	private float z0pek;

	private object z0mek;

	private int z0nek = -1;

	private JumpPrintPositionMode z0bek;

	private float z0vek;

	private object z0cek;

	private float z0xek;

	private float z0zek;

	private float z0lrk;

	private int z0krk = -1;

	private z0ZzZzwrj z0jrk;

	[DefaultValue(0f)]
	public float Position
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	[DefaultValue(0f)]
	public float AbsPosition
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	[DefaultValue(0f)]
	public float NativePosition
	{
		get
		{
			return z0xek;
		}
		set
		{
			z0xek = value;
		}
	}

	[DefaultValue(-1)]
	public int PageIndex
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	public bool HasValidateInfo
	{
		get
		{
			if (!Enabled)
			{
				return false;
			}
			if (PageIndex == 0 && Position > 0f)
			{
				return true;
			}
			if (PageIndex >= 0 && Position >= 0f)
			{
				return true;
			}
			if (EndPageIndex >= 0 && EndPosition >= 0f)
			{
				return true;
			}
			return false;
		}
	}

	[DefaultValue(0f)]
	public float NativeEndPosition
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	[DefaultValue(JumpPrintPositionMode.Position)]
	public JumpPrintPositionMode StartPositionMode
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	[DefaultValue(-1)]
	public int EndPageIndex
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	[DefaultValue(JumpPrintPositionMode.Position)]
	public JumpPrintPositionMode EndPositionMode
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[DefaultValue(false)]
	public bool Enabled
	{
		get
		{
			if (z0oek != JumpPrintMode.Normal && z0oek != JumpPrintMode.Append)
			{
				return z0oek == JumpPrintMode.Offset;
			}
			return true;
		}
		set
		{
			if (value)
			{
				z0oek = JumpPrintMode.Normal;
			}
			else
			{
				z0oek = JumpPrintMode.Disable;
			}
		}
	}

	[DefaultValue(JumpPrintMode.Disable)]
	public JumpPrintMode Mode
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[DefaultValue(0f)]
	public float EndPosition
	{
		get
		{
			return z0lrk;
		}
		set
		{
			z0lrk = value;
		}
	}

	public JumpPrintInfo z0eek()
	{
		return (JumpPrintInfo)MemberwiseClone();
	}

	public void z0eek(float p0)
	{
		z0xek = p0;
		z0pek = p0;
	}

	public object z0rek()
	{
		return z0cek;
	}

	public object z0tek()
	{
		return z0mek;
	}

	public void z0eek(object p0)
	{
		z0cek = p0;
	}

	public void z0rek(object p0)
	{
		z0mek = p0;
	}

	public void z0eek(z0ZzZzwrj p0)
	{
		z0jrk = p0;
	}

	public z0ZzZzwrj z0yek()
	{
		return z0jrk;
	}

	public void z0uek()
	{
		z0krk = -1;
		z0jrk = null;
		z0nek = -1;
		z0oek = JumpPrintMode.Disable;
		z0lrk = 0f;
		z0zek = 0f;
		z0xek = 0f;
		z0pek = 0f;
	}

	public void z0rek(float p0)
	{
		z0zek = p0;
		z0lrk = p0;
	}
}
