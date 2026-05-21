using System.Text;

namespace zzz;

internal class z0ZzZziyj
{
	private readonly z0ZzZzgtj z0iek;

	private int z0oek;

	private readonly z0ZzZzprj z0pek = new z0ZzZzprj();

	private StringBuilder z0mek = new StringBuilder();

	public z0ZzZziyj(z0ZzZzgtj p0)
	{
		z0iek = p0;
	}

	public void z0eek(int p0)
	{
		z0oek = p0;
	}

	public bool z0eek(z0ZzZzoyj p0, z0ZzZzuyj p1)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0.z0uek() == (z0ZzZzpyj)4)
		{
			if (p1 != null && p0.z0rek()[0] == '?' && p1.z0mek() != null && p1.z0mek().z0uek() == (z0ZzZzpyj)1 && p1.z0mek().z0rek() == "u" && p1.z0mek().z0tek())
			{
				if (p0.z0rek().Length > 0)
				{
					p1.z0eek().z0rek(0);
					z0yek();
					if (p0.z0rek().Length > 1)
					{
						z0mek.Append(p0.z0rek().Substring(1));
					}
				}
				return true;
			}
			if (z0pek.z0rek() > 0 && z0pek.z0rek() % 2 != 0)
			{
				byte[] bytes = z0iek.z0vek().GetBytes(p0.z0rek());
				z0pek.z0eek(bytes);
				z0yek();
			}
			else
			{
				z0yek();
				z0mek.Append(p0.z0rek());
			}
			return true;
		}
		if (p0.z0uek() == (z0ZzZzpyj)3 && p0.z0rek() == "'" && p0.z0tek())
		{
			if (p1.z0eek().z0tek())
			{
				z0pek.z0eek((byte)p0.z0eek());
			}
			return true;
		}
		if (p0.z0rek() == "u" && p0.z0tek())
		{
			z0yek();
			z0mek.Append((char)p0.z0eek());
			p1.z0eek().z0rek(p1.z0eek().z0eek());
			return true;
		}
		if (p0.z0rek() == "tab")
		{
			z0yek();
			z0mek.Append("\t");
			return true;
		}
		if (p0.z0rek() == "emdash")
		{
			z0yek();
			z0mek.Append('—');
			return true;
		}
		if (p0.z0rek() == string.Empty)
		{
			z0yek();
			z0mek.Append('-');
			return true;
		}
		return false;
	}

	public void z0eek(string p0)
	{
		if (!string.IsNullOrEmpty(p0))
		{
			z0yek();
			z0mek.Append(p0);
		}
	}

	public void z0eek()
	{
		z0pek.z0eek();
		z0mek = new StringBuilder();
	}

	public int z0rek()
	{
		return z0oek;
	}

	public bool z0tek()
	{
		z0yek();
		return z0mek.Length > 0;
	}

	private void z0yek()
	{
		if (z0pek.z0rek() > 0)
		{
			Encoding p = z0iek.z0vek();
			string text = z0pek.z0eek(p);
			z0mek.Append(text);
			z0pek.z0eek();
		}
	}

	public string z0uek()
	{
		z0yek();
		return z0mek.ToString();
	}
}
