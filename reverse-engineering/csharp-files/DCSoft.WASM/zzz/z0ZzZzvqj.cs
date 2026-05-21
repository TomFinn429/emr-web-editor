namespace zzz;

internal class z0ZzZzvqj : z0ZzZzcaj
{
	private static z0ZzZzvqj z0tek = new z0ZzZzvqj(p0: true);

	private static z0ZzZzvqj z0yek = new z0ZzZzvqj(p0: false);

	private readonly bool z0uek;

	internal new static z0ZzZzvqj z0eek()
	{
		return z0tek;
	}

	protected internal override object z0jfk(z0ZzZzdsj p0)
	{
		return new z0ZzZzhwj((this == z0eek()) ? "Identity-V" : "Identity-H");
	}

	internal new static z0ZzZzvqj z0rek()
	{
		return z0yek;
	}

	private z0ZzZzvqj(bool p0)
	{
		z0uek = p0;
	}

	internal override bool z0kfk()
	{
		return z0uek;
	}
}
