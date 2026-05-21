namespace zzz;

internal class z0ZzZzkxk<T1, T2, T3>
{
	private readonly T3 z0eek;

	private readonly T2 z0rek;

	private readonly T1 z0tek;

	public override bool Equals(object obj)
	{
		if (!(obj is zzz.z0ZzZzkxk<T1, T2, T3> z0ZzZzkxk2))
		{
			return false;
		}
		if (z0ZzZzhxk.z0rek.Equals(z0tek, z0ZzZzkxk2.z0tek) && z0ZzZzhxk.z0rek.Equals(z0rek, z0ZzZzkxk2.z0rek) && z0ZzZzhxk.z0rek.Equals(z0eek, z0ZzZzkxk2.z0eek))
		{
			return true;
		}
		return false;
	}

	public z0ZzZzkxk(T1 p0, T2 p1, T3 p2)
	{
		z0tek = p0;
		z0rek = p1;
		z0eek = p2;
	}

	public override int GetHashCode()
	{
		return z0ZzZzhxk.z0eek(z0ZzZzhxk.z0rek.GetHashCode(z0tek), z0ZzZzhxk.z0rek.GetHashCode(z0rek), z0ZzZzhxk.z0rek.GetHashCode(z0eek));
	}
}
