using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzvij
{
	private int z0tek;

	private readonly int z0yek;

	private string z0uek;

	private z0ZzZzvij(string p0)
	{
		z0uek = p0;
		z0yek = p0.Length;
	}

	private string z0eek(char p0)
	{
		for (int i = z0tek; i < z0yek; i++)
		{
			if (z0uek[i] == p0)
			{
				if (i == z0tek)
				{
					z0tek++;
					return null;
				}
				string result = z0uek.Substring(z0tek, i - z0tek);
				z0tek = i + 1;
				return result;
			}
		}
		string result2 = z0uek.Substring(z0tek, z0yek - z0tek);
		z0tek = z0yek;
		return result2;
	}

	public static string[] z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		z0ZzZzvij z0ZzZzvij2 = new z0ZzZzvij(p0);
		List<string> list = new List<string>(10);
		while (z0ZzZzvij2.z0tek < p0.Length)
		{
			z0ZzZzvij2.z0rek();
			string text = z0ZzZzvij2.z0eek(':');
			if (text == null)
			{
				break;
			}
			text = text.Trim();
			z0ZzZzvij2.z0rek();
			string text2 = null;
			if (z0ZzZzvij2.z0eek() == '"')
			{
				z0ZzZzvij2.z0tek++;
				text2 = z0ZzZzvij2.z0eek('"');
				z0ZzZzvij2.z0rek(';');
			}
			else if (z0ZzZzvij2.z0eek() == '\'')
			{
				z0ZzZzvij2.z0tek++;
				text2 = z0ZzZzvij2.z0eek('\'');
				z0ZzZzvij2.z0rek(';');
			}
			else
			{
				text2 = z0ZzZzvij2.z0eek(';');
				if (text2 != null)
				{
					text2 = text2.Trim();
				}
			}
			if (text2 != null && text2.Length == 0)
			{
				text2 = null;
			}
			if (text.Length > 0)
			{
				list.Add(text);
				list.Add(text2);
			}
		}
		z0ZzZzvij2.z0uek = null;
		if (list.Count > 0)
		{
			return list.ToArray();
		}
		return null;
	}

	private char z0eek()
	{
		if (z0tek < z0yek)
		{
			return z0uek[z0tek];
		}
		return '\0';
	}

	private void z0rek(char p0)
	{
		int num = z0uek.IndexOf(p0, z0tek);
		if (num >= 0)
		{
			z0tek = num + 1;
		}
		else
		{
			z0tek = z0yek;
		}
	}

	private void z0rek()
	{
		for (int i = z0tek; i < z0yek; i++)
		{
			char c = z0uek[i];
			if (c != ' ' && c != '\t' && c != '\r' && c != '\n')
			{
				z0tek = i;
				break;
			}
		}
	}
}
