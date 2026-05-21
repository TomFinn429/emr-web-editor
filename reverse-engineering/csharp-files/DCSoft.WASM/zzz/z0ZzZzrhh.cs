namespace zzz;

public class z0ZzZzrhh
{
	private string z0uek;

	private string z0iek;

	private string z0oek;

	public void z0eek(string p0)
	{
		z0iek = p0;
		if (z0iek != null)
		{
			z0iek = z0iek.Trim();
			if (z0iek.Length == 0)
			{
				z0iek = null;
			}
		}
		z0uek = null;
	}

	public void z0rek(string p0)
	{
		z0oek = p0;
	}

	public void z0tek(string p0)
	{
		z0uek = p0;
	}

	public string z0eek()
	{
		return z0uek;
	}

	public string z0rek()
	{
		return z0iek;
	}

	public z0ZzZzrhh z0tek()
	{
		return (z0ZzZzrhh)MemberwiseClone();
	}

	public string z0yek()
	{
		return z0oek;
	}
}
