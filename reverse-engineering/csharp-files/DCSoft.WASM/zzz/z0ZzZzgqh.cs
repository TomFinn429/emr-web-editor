namespace zzz;

internal sealed class z0ZzZzgqh : z0ZzZzbsh
{
	private new bool z0rek;

	public override bool z0wh()
	{
		return z0rek;
	}

	public override z0ZzZzoah z0tf(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		z0ZzZzoah result = base.z0tf(p0, p1);
		z0rek = true;
		return result;
	}

	public override z0ZzZzoah z0yf(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		z0ZzZzoah result = base.z0yf(p0, p1);
		z0rek = true;
		return result;
	}

	public override void z0eh(z0ZzZzdqh p0)
	{
		if (z0rek)
		{
			base.z0eh(p0);
		}
	}

	public override z0ZzZzoah z0of(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		z0ZzZzoah result = base.z0of(p0, p1);
		z0rek = true;
		return result;
	}

	internal void z0eek(bool p0)
	{
		z0rek = p0;
	}

	public override z0ZzZzoah? z0if(z0ZzZzoah p0)
	{
		z0ZzZzoah result = base.z0if(p0);
		z0rek = true;
		return result;
	}

	public override void z0rg(string p0)
	{
		base.z0rg(p0);
		z0rek = true;
	}

	internal z0ZzZzgqh(string p0, string p1, string p2, z0ZzZzfah p3)
		: base(p0, p1, p2, p3)
	{
	}

	public override z0ZzZzoah z0pf(z0ZzZzoah p0)
	{
		z0ZzZzoah result = base.z0pf(p0);
		z0rek = true;
		return result;
	}
}
