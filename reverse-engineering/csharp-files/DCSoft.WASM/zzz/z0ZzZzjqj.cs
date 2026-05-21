namespace zzz;

internal class z0ZzZzjqj : z0ZzZznaj
{
	private readonly z0ZzZzhqj z0tek;

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		return z0qfk(p0);
	}

	internal z0ZzZzjqj(z0ZzZzhqj p0)
	{
		z0tek = p0;
	}

	protected internal override object z0qfk(z0ZzZzdsj p0)
	{
		if (z0tek == (z0ZzZzhqj)2)
		{
			return new z0ZzZzhwj("DeviceCMYK");
		}
		if (z0tek == (z0ZzZzhqj)0)
		{
			return new z0ZzZzhwj("DeviceGray");
		}
		return new z0ZzZzhwj("DeviceRGB");
	}

	internal new z0ZzZzhqj z0eek()
	{
		return z0tek;
	}

	internal override int z0afk()
	{
		return z0tek switch
		{
			(z0ZzZzhqj)0 => 1, 
			(z0ZzZzhqj)2 => 4, 
			_ => 3, 
		};
	}
}
