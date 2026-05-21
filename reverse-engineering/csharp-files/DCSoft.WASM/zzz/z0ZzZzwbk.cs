namespace zzz;

internal class z0ZzZzwbk : z0ZzZzznk
{
	private new static readonly string[] z0eek = new string[7] { null, "h1", "h2", "h3", "h4", "h5", "h6" };

	protected new int z0rek = 1;

	private new static readonly string[] z0tek = new string[7] { null, "H1", "H2", "H3", "H4", "H5", "H6" };

	public override string z0vak()
	{
		if (z0rek >= 1 && z0rek <= 6)
		{
			return z0tek[z0rek];
		}
		return "h" + z0rek;
	}

	public override string z0cak()
	{
		if (z0rek >= 1 && z0rek <= 6)
		{
			return z0eek[z0rek];
		}
		return "h" + z0rek;
	}

	public z0ZzZzwbk(int p0)
	{
		z0rek = p0;
	}
}
