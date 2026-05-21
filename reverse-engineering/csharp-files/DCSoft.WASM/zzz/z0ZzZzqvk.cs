namespace zzz;

internal class z0ZzZzqvk : z0ZzZzznk, z0ZzZzlck
{
	protected new z0ZzZzdbk z0eek;

	internal override bool z0xak(string p0)
	{
		return p0 == "option";
	}

	public override string z0hqk()
	{
		using (zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = z0tek.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0ZzZzgvk z0ZzZzgvk2 = (z0ZzZzgvk)z0bpk.Current;
				if (z0ZzZzgvk2.z0eek())
				{
					return z0ZzZzgvk2.z0hqk();
				}
			}
		}
		return null;
	}

	public override string z0cak()
	{
		return "select";
	}

	public void z0qqk(z0ZzZzdbk p0)
	{
		z0eek = p0;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0eek = null;
	}

	public z0ZzZzdbk z0aqk()
	{
		return z0eek;
	}

	public override string z0vak()
	{
		return "select";
	}
}
