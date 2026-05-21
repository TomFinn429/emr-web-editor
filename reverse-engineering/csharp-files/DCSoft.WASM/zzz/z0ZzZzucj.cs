using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzucj
{
	internal XTextParagraphFlagElement z0mek;

	private string z0nek;

	private string z0bek;

	private z0ZzZzicj z0vek;

	private z0ZzZzucj z0cek;

	public z0ZzZzicj z0eek()
	{
		if (z0vek == null)
		{
			z0vek = new z0ZzZzicj();
		}
		return z0vek;
	}

	public bool z0rek()
	{
		if (z0mek != null)
		{
			return z0mek.z0aek().z0syk;
		}
		return false;
	}

	public int z0tek()
	{
		int num = 0;
		z0ZzZzucj z0ZzZzucj2 = z0cek;
		while (z0ZzZzucj2 != null)
		{
			z0ZzZzucj2 = z0ZzZzucj2.z0cek;
			num++;
		}
		return num;
	}

	public string z0yek()
	{
		return z0nek;
	}

	public void z0eek(string p0)
	{
		z0nek = p0;
	}

	public XTextElement z0uek()
	{
		if (z0mek == null)
		{
			return null;
		}
		return z0mek.z0iek();
	}

	public void z0eek(z0ZzZzucj p0)
	{
		z0cek = p0;
	}

	public z0ZzZzucj z0iek()
	{
		return z0cek;
	}

	public string z0oek()
	{
		return z0bek;
	}

	public void z0rek(string p0)
	{
		z0bek = p0;
	}

	public XTextParagraphFlagElement z0pek()
	{
		return z0mek;
	}
}
