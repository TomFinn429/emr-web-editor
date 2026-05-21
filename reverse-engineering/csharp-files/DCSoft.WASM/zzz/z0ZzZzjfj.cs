namespace zzz;

internal abstract class z0ZzZzjfj
{
	private readonly z0ZzZzxfj z0yek;

	private readonly z0ZzZzudj z0uek;

	protected bool z0eek()
	{
		if (z0tek() == (z0ZzZzudj)3)
		{
			return z0rek() == (z0ZzZzxfj)0;
		}
		return false;
	}

	internal virtual void z0wdk(z0ZzZzjgj p0)
	{
		p0.z0eek((short)z0sdk());
	}

	internal z0ZzZzxfj z0rek()
	{
		return z0yek;
	}

	internal static z0ZzZzjfj z0eek(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzhfj p2, z0ZzZzjgj p3)
	{
		switch (p2)
		{
		case (z0ZzZzhfj)0:
			return new z0ZzZzkfj(p0, p1, p3);
		case (z0ZzZzhfj)2:
			return new z0ZzZzffj(p0, p1, p3);
		case (z0ZzZzhfj)4:
			return new z0ZzZzrfj(p0, p1, p3);
		case (z0ZzZzhfj)6:
			return new z0ZzZzifj(p0, p1, p3);
		case (z0ZzZzhfj)8:
			return new z0ZzZzqfj(p0, p1, p3);
		case (z0ZzZzhfj)10:
			return new z0ZzZzufj(p0, p1, p3);
		case (z0ZzZzhfj)12:
			return new z0ZzZzefj(p0, p1, p3);
		case (z0ZzZzhfj)13:
			return new z0ZzZzafj(p0, p1, p3);
		case (z0ZzZzhfj)14:
			return new z0ZzZznfj(p0, p1, p3);
		default:
			z0ZzZzlxk.z0yek();
			return null;
		}
	}

	protected abstract z0ZzZzhfj z0sdk();

	protected z0ZzZzjfj(z0ZzZzudj p0, z0ZzZzxfj p1)
	{
		z0uek = p0;
		z0yek = p1;
	}

	internal z0ZzZzudj z0tek()
	{
		return z0uek;
	}

	internal virtual int z0qdk(int p0)
	{
		return p0;
	}

	internal abstract int z0adk();
}
