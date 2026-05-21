namespace zzz;

public class z0ZzZziik
{
	private int z0tek;

	private readonly string z0yek;

	private readonly int z0uek = -1;

	public string z0eek()
	{
		if (z0tek < z0yek.Length)
		{
			string result = z0yek.Substring(z0tek);
			z0tek = z0yek.Length;
			return result;
		}
		return null;
	}

	public string z0eek(char p0)
	{
		if (z0tek < z0uek)
		{
			int num = z0yek.IndexOf(p0, z0tek);
			if (num == -1)
			{
				num = z0yek.Length;
			}
			string result = z0yek.Substring(z0tek, num - z0tek);
			z0tek = num + 1;
			return result;
		}
		return null;
	}

	public z0ZzZziik(string p0)
	{
		z0yek = p0;
		z0tek = 0;
		if (p0 != null)
		{
			z0uek = p0.Length;
		}
	}

	public string z0rek()
	{
		for (int i = z0tek; i < z0yek.Length; i++)
		{
			if (!z0ZzZzqik.z0uek(z0yek[i]))
			{
				if (i <= z0tek)
				{
					break;
				}
				string result = z0yek.Substring(z0tek, i - z0tek);
				z0tek = i;
				return result;
			}
		}
		return null;
	}
}
