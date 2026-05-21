using System.Runtime.CompilerServices;
using DCSystem_Drawing;

namespace zzz;

public sealed class z0ZzZzpfh
{
	[CompilerGenerated]
	private float[] z0yek;

	[CompilerGenerated]
	private Color[] z0uek;

	[CompilerGenerated]
	public Color[] z0eek()
	{
		return z0uek;
	}

	[CompilerGenerated]
	public float[] z0rek()
	{
		return z0yek;
	}

	public bool z0eek(z0ZzZzpfh p0)
	{
		if (p0 == this)
		{
			return true;
		}
		if (p0 == null)
		{
			return false;
		}
		if (p0.z0eek() == z0eek() && p0.z0rek() == z0rek())
		{
			return true;
		}
		int num = ((z0eek() != null) ? z0eek().Length : 0);
		int num2 = ((p0.z0eek() != null) ? p0.z0eek().Length : 0);
		if (num != num2)
		{
			return false;
		}
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				if (z0eek()[i] != p0.z0eek()[i])
				{
					return false;
				}
			}
		}
		num = ((z0rek() != null) ? z0rek().Length : 0);
		num2 = ((p0.z0rek() != null) ? p0.z0rek().Length : 0);
		if (num != num2)
		{
			return false;
		}
		if (num > 0)
		{
			for (int j = 0; j < num; j++)
			{
				if (z0rek()[j] != p0.z0rek()[j])
				{
					return false;
				}
			}
		}
		return true;
	}

	public bool z0tek()
	{
		if (z0eek() == null || z0eek().Length == 0 || z0rek() == null || z0rek().Length == 0)
		{
			return true;
		}
		return false;
	}

	[CompilerGenerated]
	public void z0eek(Color[] p0)
	{
		z0uek = p0;
	}

	[CompilerGenerated]
	public void z0eek(float[] p0)
	{
		z0yek = p0;
	}
}
