namespace zzz;

internal abstract class z0ZzZzpzk
{
	private readonly z0ZzZzjej z0yek;

	private readonly z0ZzZzjej z0uek;

	private readonly z0ZzZzmwj z0iek;

	protected abstract z0ZzZzrwj z0qak(z0ZzZzugj p0);

	protected z0ZzZzjej z0eek()
	{
		return z0yek;
	}

	protected z0ZzZzmwj z0rek()
	{
		return z0iek;
	}

	internal static z0ZzZzrwj z0eek(z0ZzZzddh p0, z0ZzZzjej p1, z0ZzZziwj p2, z0ZzZzmwj p3, z0ZzZzmwj p4, z0ZzZzugj p5, z0ZzZzjej p6)
	{
		return p0 switch
		{
			(z0ZzZzddh)4 => new z0ZzZzmzk(p3, p1, p6).z0qak(p5), 
			(z0ZzZzddh)1 => new z0ZzZzizk(p2, p3, p4, p1, p6).z0qak(p5), 
			(z0ZzZzddh)3 => new z0ZzZzuzk(p2, p3, p4, p1, p6).z0qak(p5), 
			(z0ZzZzddh)2 => new z0ZzZzbzk(p2, p3, p4, p1, p6).z0qak(p5), 
			_ => new z0ZzZzozk(p2, p3, p4, p1, p6).z0qak(p5), 
		};
	}

	protected z0ZzZzpzk(z0ZzZzmwj p0, z0ZzZzjej p1, z0ZzZzjej p2)
	{
		z0iek = p0;
		z0yek = p1;
		z0uek = p2;
	}

	protected z0ZzZzjej z0tek()
	{
		return z0uek;
	}
}
