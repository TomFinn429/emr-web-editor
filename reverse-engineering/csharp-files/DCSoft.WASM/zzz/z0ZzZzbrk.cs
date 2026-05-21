namespace zzz;

internal class z0ZzZzbrk : z0ZzZzerk
{
	public override string z0nwk()
	{
		return z0eek();
	}

	private string z0eek()
	{
		z0rek = null;
		if (!z0eek(z0tek))
		{
			z0rek = z0ZzZziok.z0bok();
			return null;
		}
		if (z0tek.Length == 10 || z0tek.Length == 9)
		{
			if (z0tek.Length == 10)
			{
				z0tek = z0tek.Remove(9, 1);
			}
			z0tek = "978" + z0tek;
		}
		else if (z0tek.Length != 12 || !z0tek.StartsWith("978"))
		{
			if (z0tek.Length != 13 || !z0tek.StartsWith("978"))
			{
				z0rek = z0ZzZziok.z0bok();
				return null;
			}
			z0tek = z0tek.Remove(12, 1);
		}
		z0ZzZzprk z0ZzZzprk2 = new z0ZzZzprk(z0tek);
		string result = z0ZzZzprk2.z0nwk();
		z0rek = z0ZzZzprk2.z0rek;
		return result;
	}

	public z0ZzZzbrk(string p0)
	{
		z0tek = p0;
	}
}
