namespace zzz;

internal class z0ZzZzsyj
{
	protected z0ZzZztyj z0rek;

	protected z0ZzZzwyj z0tek = (z0ZzZzwyj)6;

	protected z0ZzZzayj z0yek;

	protected string z0uek;

	protected int z0iek;

	protected bool z0oek;

	public virtual void z0mjk(z0ZzZzbyj p0)
	{
		if (z0tek == (z0ZzZzwyj)3 || z0tek == (z0ZzZzwyj)1 || z0tek == (z0ZzZzwyj)2)
		{
			if (z0oek)
			{
				p0.z0eek(z0uek + z0iek, z0tek == (z0ZzZzwyj)2);
			}
			else
			{
				p0.z0eek(z0uek, z0tek == (z0ZzZzwyj)2);
			}
		}
		else if (z0tek == (z0ZzZzwyj)4)
		{
			p0.z0uek(z0uek);
		}
	}

	public virtual z0ZzZztyj z0tjk()
	{
		return z0rek;
	}

	public virtual z0ZzZzayj z0rjk()
	{
		return z0yek;
	}

	public z0ZzZzwyj z0eek()
	{
		return z0tek;
	}

	public virtual string z0ijk()
	{
		return z0uek;
	}

	public virtual void z0ejk(z0ZzZzayj p0)
	{
		z0yek = p0;
	}

	public virtual void z0ujk(bool p0)
	{
		z0oek = p0;
	}

	public virtual void z0pjk(string p0)
	{
		z0uek = p0;
	}

	public virtual z0ZzZzqyj z0yjk()
	{
		return null;
	}

	public virtual void z0wjk(z0ZzZztyj p0)
	{
		z0rek = p0;
		if (z0yjk() == null)
		{
			return;
		}
		foreach (z0ZzZzsyj item in z0yjk())
		{
			item.z0wjk(p0);
		}
	}

	public virtual int z0njk()
	{
		return z0iek;
	}

	public virtual bool z0ojk()
	{
		return z0oek;
	}
}
