using System.Collections.Generic;
using System.Text;

namespace zzz;

public class z0ZzZzsrj
{
	private bool z0tek = true;

	private List<int> z0yek;

	private List<int> z0uek;

	public static int z0iek;

	private void z0eek(string p0)
	{
		z0tek = false;
		z0uek = null;
		z0yek = null;
		if (string.IsNullOrEmpty(p0))
		{
			z0tek = true;
			return;
		}
		p0 = p0.Trim();
		if (p0 == "*")
		{
			z0tek = true;
			return;
		}
		z0uek = new List<int>();
		z0yek = new List<int>();
		StringBuilder stringBuilder = new StringBuilder();
		string text = p0;
		foreach (char c in text)
		{
			if (char.IsWhiteSpace(c))
			{
				continue;
			}
			if ((c >= '0' && c <= '9') || c == '-' || c == 'X' || c == 'x')
			{
				stringBuilder.Append(c);
				continue;
			}
			if (stringBuilder.Length > 0)
			{
				z0rek(stringBuilder.ToString());
				stringBuilder = new StringBuilder();
			}
			stringBuilder = new StringBuilder();
		}
		if (stringBuilder.Length > 0)
		{
			z0rek(stringBuilder.ToString());
		}
		if (z0uek.Count == 0 && z0yek.Count == 0)
		{
			z0tek = true;
		}
	}

	public bool z0eek(int p0)
	{
		if (z0tek)
		{
			return true;
		}
		p0++;
		if (z0yek != null && z0yek.Contains(p0))
		{
			return false;
		}
		if (z0uek != null && z0uek.Count > 0)
		{
			return z0uek.Contains(p0);
		}
		if (p0 == 999999)
		{
			return true;
		}
		return false;
	}

	private void z0rek(string p0)
	{
		if (p0[0] == 'X' || p0[0] == 'x')
		{
			z0uek.Add(999999);
			return;
		}
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < p0.Length; i++)
		{
			char c = p0[i];
			if (c >= '0' && c <= '9')
			{
				if (flag || !flag2)
				{
					num = num * 10 + c - 48;
				}
				else
				{
					num2 = num2 * 10 + c - 48;
				}
			}
			else if (c == '-')
			{
				if (flag || flag2)
				{
					break;
				}
				if (i == 0)
				{
					flag = true;
				}
				else
				{
					flag2 = true;
				}
			}
		}
		if (flag)
		{
			z0yek.Add(num);
		}
		else if (flag2)
		{
			for (int j = num; j <= num2; j++)
			{
				z0uek.Add(j);
			}
		}
		else
		{
			z0uek.Add(num);
		}
	}

	public z0ZzZzsrj(string p0)
	{
		z0eek(p0);
		if (z0iek != 0)
		{
			z0rek(z0iek);
		}
	}

	public void z0eek()
	{
		z0tek = true;
		z0uek = null;
		z0yek = null;
	}

	public void z0rek(int p0)
	{
		if (z0tek)
		{
			return;
		}
		if (z0uek != null && z0uek.Count > 0)
		{
			for (int i = 0; i < z0uek.Count; i++)
			{
				if (z0uek[i] != 999999)
				{
					z0uek[i] += p0;
				}
			}
		}
		if (z0yek == null || z0yek.Count <= 0)
		{
			return;
		}
		for (int j = 0; j < z0yek.Count; j++)
		{
			if (z0yek[j] != 999999)
			{
				z0yek[j] += p0;
			}
		}
	}
}
