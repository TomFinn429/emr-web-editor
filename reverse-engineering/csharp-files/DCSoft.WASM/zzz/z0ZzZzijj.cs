namespace zzz;

internal class z0ZzZzijj : z0ZzZzojj
{
	private readonly int z0eek;

	public override int GetHashCode()
	{
		return z0eek.GetHashCode() ^ base.GetHashCode();
	}

	internal z0ZzZzijj(object p0, int p1)
		: base(p0)
	{
		z0eek = p1;
	}

	public override bool Equals(object obj)
	{
		if (obj is z0ZzZzijj z0ZzZzijj2 && base.Equals(obj))
		{
			return z0ZzZzijj2.z0eek == z0eek;
		}
		return false;
	}
}
