using System;
using System.Text;

namespace zzz;

internal class z0ZzZzprj
{
	protected byte[] z0tek = new byte[16];

	protected int z0yek;

	public void z0eek(byte[] p0)
	{
		z0eek(z0yek + p0.Length);
		for (int i = 0; i < p0.Length; i++)
		{
			z0tek[z0yek + i] = p0[i];
		}
		z0yek += p0.Length;
	}

	protected void z0eek(int p0)
	{
		if (p0 > z0tek.Length)
		{
			if (p0 < (int)((double)z0tek.Length * 1.5))
			{
				p0 = (int)((double)z0tek.Length * 1.5);
			}
			byte[] array = new byte[p0];
			Buffer.BlockCopy(z0tek, 0, array, 0, z0tek.Length);
			z0tek = array;
		}
	}

	public virtual void z0eek()
	{
		z0tek = new byte[16];
		z0yek = 0;
	}

	public virtual int z0rek()
	{
		return z0yek;
	}

	public string z0eek(Encoding p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("encoding");
		}
		if (z0yek > 0)
		{
			return p0.GetString(z0tek, 0, z0yek);
		}
		return string.Empty;
	}

	public void z0eek(byte p0)
	{
		z0eek(z0yek + 1);
		z0tek[z0yek] = p0;
		z0yek++;
	}
}
