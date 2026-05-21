namespace zzz;

public abstract class z0ZzZzxsh : z0ZzZztah
{
	private new string z0tek;

	protected internal z0ZzZzxsh(string p0, z0ZzZzfah p1)
		: base(p1)
	{
		z0tek = p0;
	}

	public override void z0rg(string p0)
	{
		z0oh(p0);
	}

	public new virtual void z0eek(string p0)
	{
		z0tek = p0;
	}

	public new virtual string z0eek()
	{
		if (z0tek != null)
		{
			return z0tek;
		}
		return string.Empty;
	}

	public override string z0rh()
	{
		return z0eek();
	}

	public override string z0eg()
	{
		return z0rh();
	}

	internal static bool z0rek(string p0)
	{
		return z0ZzZzzsh.z0eek(p0);
	}

	public override void z0oh(string p0)
	{
		z0eek(p0);
	}
}
