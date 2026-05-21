namespace zzz;

internal class z0ZzZzkzk
{
	private int z0uek;

	private string z0iek;

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	internal bool z0eek_jiejie20260327142557()
	{
		if (z0uek > 0)
		{
			return string.IsNullOrEmpty(z0iek);
		}
		return false;
	}

	internal string z0rek()
	{
		return z0iek;
	}

	internal z0ZzZzkzk(string p0, int p1)
	{
		z0iek = p0;
		z0uek = p1;
	}

	public override bool Equals(object obj)
	{
		if (obj is z0ZzZzkzk z0ZzZzkzk2 && z0ZzZzkzk2.z0rek() == z0rek())
		{
			return z0ZzZzkzk2.z0tek() == z0tek();
		}
		return false;
	}

	internal int z0tek()
	{
		return z0uek;
	}

	internal string z0yek()
	{
		return new string(' ', z0uek) + z0iek;
	}
}
