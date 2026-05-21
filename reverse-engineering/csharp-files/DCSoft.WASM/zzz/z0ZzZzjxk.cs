namespace zzz;

internal class z0ZzZzjxk<T1, T2, T3, T4>
{
	private readonly T3 z0eek;

	private readonly T4 z0rek;

	private readonly T1 z0tek;

	private readonly T2 z0yek;

	public override bool Equals(object obj)
	{
		if (!(obj is zzz.z0ZzZzjxk<T1, T2, T3, T4> z0ZzZzjxk2))
		{
			return false;
		}
		if (z0ZzZzhxk.z0rek.Equals(z0tek, z0ZzZzjxk2.z0tek) && z0ZzZzhxk.z0rek.Equals(z0yek, z0ZzZzjxk2.z0yek) && z0ZzZzhxk.z0rek.Equals(z0eek, z0ZzZzjxk2.z0eek) && z0ZzZzhxk.z0rek.Equals(z0rek, z0ZzZzjxk2.z0rek))
		{
			return true;
		}
		return false;
	}

	public z0ZzZzjxk(T1 p0, T2 p1, T3 p2, T4 p3)
	{
		z0tek = p0;
		z0yek = p1;
		z0eek = p2;
		z0rek = p3;
	}

	public override int GetHashCode()
	{
		return z0ZzZzhxk.z0eek(z0ZzZzhxk.z0rek.GetHashCode(z0tek), z0ZzZzhxk.z0rek.GetHashCode(z0yek), z0ZzZzhxk.z0rek.GetHashCode(z0eek), z0ZzZzhxk.z0rek.GetHashCode(z0rek));
	}
}
