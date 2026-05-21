using System.Collections.Generic;
using System.Text;

namespace zzz;

internal class z0ZzZzxaj
{
	private IList<string> z0iek;

	private bool z0oek;

	private z0ZzZzbaj z0pek;

	private static string z0rek(string p0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in p0)
		{
			if (c != ' ' && c != '\r' && c != '\n')
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	internal z0ZzZzbaj z0rek()
	{
		return z0pek;
	}

	internal void z0rek(bool p0)
	{
		z0oek = p0;
	}

	internal IList<string> z0tek()
	{
		return z0iek;
	}

	internal bool z0yek()
	{
		return false;
	}

	internal void z0eek(IList<string> p0)
	{
		int count = p0.Count;
		z0iek = new List<string>(count);
		for (int i = 0; i < count; i++)
		{
			z0iek.Add(z0rek(p0[i]));
		}
	}

	internal void z0rek(z0ZzZzbaj p0)
	{
		z0pek = p0;
	}

	internal bool z0rek(string p0, bool p1, bool p2)
	{
		if (z0iek == null || z0iek.Count == 0)
		{
			return true;
		}
		p0 = z0rek(p0);
		if (p1 || p2)
		{
			string text = string.Format("{0},{1}{2}", p0, p1 ? "Bold" : string.Empty, p2 ? "Italic" : string.Empty);
			if (!z0iek.Contains(p0))
			{
				return !z0iek.Contains(text);
			}
			return false;
		}
		return !z0iek.Contains(p0);
	}
}
