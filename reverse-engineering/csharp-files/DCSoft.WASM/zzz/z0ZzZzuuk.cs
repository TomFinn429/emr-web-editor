namespace zzz;

public class z0ZzZzuuk<TValue> : zzz.z0ZzZzyuk<string, string, TValue>
{
	protected override int z0owk(string p0, string p1)
	{
		int num = 0;
		if (p0 != null)
		{
			num = p0.GetHashCode();
		}
		if (p1 != null)
		{
			num += p1.GetHashCode();
		}
		return num;
	}

	protected override bool z0iwk(string p0, string p1, string p2, string p3)
	{
		if (p0 == p2)
		{
			return p1 == p3;
		}
		return false;
	}
}
