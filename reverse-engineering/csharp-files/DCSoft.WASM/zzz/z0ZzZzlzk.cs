using System.Collections.Generic;

namespace zzz;

internal struct z0ZzZzlzk
{
	private int z0tek;

	private int z0yek;

	private int z0uek;

	private string z0iek;

	private z0ZzZzlsh z0oek;

	private z0ZzZzkzk z0pek;

	internal z0ZzZzlzk(string p0, z0ZzZzlsh p1)
	{
		z0tek = (z0yek = 0);
		z0uek = 0;
		z0pek = null;
		z0iek = p0;
		z0oek = p1;
	}

	private z0ZzZzpxk z0eek(int p0)
	{
		char c = z0iek[p0];
		switch (c)
		{
		case ' ':
			return (z0ZzZzpxk)1;
		case '(':
		case '[':
		case '{':
			return (z0ZzZzpxk)2;
		case ')':
		case ']':
		case '}':
			return (z0ZzZzpxk)3;
		case '!':
		case '%':
		case '?':
			return (z0ZzZzpxk)4;
		case '\t':
		case '+':
		case '-':
			return (z0ZzZzpxk)5;
		case '\u00a0':
			return (z0ZzZzpxk)8;
		case '\\':
			return (z0ZzZzpxk)6;
		default:
			if (char.IsDigit(c))
			{
				return (z0ZzZzpxk)7;
			}
			return (z0ZzZzpxk)0;
		}
	}

	private static bool z0eek(string p0)
	{
		if (!string.IsNullOrEmpty(p0))
		{
			if (!p0.StartsWith(",") && !p0.StartsWith("."))
			{
				return !p0.StartsWith(";");
			}
			return false;
		}
		return true;
	}

	private bool z0eek(int p0, out z0ZzZzkzk p1)
	{
		p1 = z0pek;
		bool result = p1 != null && !string.IsNullOrEmpty(p1.z0rek());
		string p2 = z0iek.Substring(z0tek, p0 - z0tek);
		z0ZzZzkzk z0ZzZzkzk2 = new z0ZzZzkzk(p2, z0uek);
		if (!z0eek(p2) || (z0pek != null && z0pek.z0eek_jiejie20260327142557()))
		{
			z0ZzZzkzk2 = ((z0pek == null) ? new z0ZzZzkzk(z0ZzZzkzk2.z0yek(), 0) : new z0ZzZzkzk(z0pek.z0rek() + z0ZzZzkzk2.z0yek(), z0pek.z0tek()));
			result = false;
		}
		z0pek = z0ZzZzkzk2;
		z0tek = p0;
		z0uek = 0;
		return result;
	}

	private void z0rek(int p0)
	{
		z0uek++;
		z0tek = p0 + 1;
	}

	internal IEnumerable<z0ZzZzkzk> z0eek()
	{
		bool flag = false;
		z0ZzZzlzk z0ZzZzlzk2 = default(z0ZzZzlzk);
		z0ZzZzlzk2.z0yek = 0;
		z0ZzZzkzk p;
		for (; z0ZzZzlzk2.z0yek < ((z0ZzZzlzk2.z0iek != null) ? z0ZzZzlzk2.z0iek.Length : 0); z0ZzZzlzk2.z0yek++)
		{
			switch (z0ZzZzlzk2.z0eek(z0ZzZzlzk2.z0yek))
			{
			case (z0ZzZzpxk)1:
				if (flag)
				{
					if (z0ZzZzlzk2.z0eek(z0ZzZzlzk2.z0yek, out p))
					{
						yield return p;
					}
					flag = false;
				}
				z0ZzZzlzk2.z0rek(z0ZzZzlzk2.z0yek);
				continue;
			case (z0ZzZzpxk)6:
				if (z0ZzZzlzk2.z0yek > 0 && z0ZzZzlzk2.z0eek(z0ZzZzlzk2.z0yek - 1) == (z0ZzZzpxk)7 && z0ZzZzlzk2.z0eek(z0ZzZzlzk2.z0yek, out p))
				{
					yield return p;
				}
				break;
			case (z0ZzZzpxk)2:
				if (z0ZzZzlzk2.z0eek(z0ZzZzlzk2.z0yek, out p))
				{
					yield return p;
				}
				break;
			case (z0ZzZzpxk)3:
			case (z0ZzZzpxk)4:
				if (z0ZzZzlzk2.z0eek(z0ZzZzlzk2.z0yek + 1, out p))
				{
					yield return p;
				}
				break;
			case (z0ZzZzpxk)8:
			{
				int num = z0ZzZzlzk2.z0yek + 1;
				if (z0ZzZzlzk2.z0iek.Length > num && z0ZzZzlzk2.z0eek(num) == (z0ZzZzpxk)4)
				{
					continue;
				}
				if (z0ZzZzlzk2.z0eek(num, out p))
				{
					yield return p;
				}
				break;
			}
			case (z0ZzZzpxk)5:
				if (z0ZzZzlzk2.z0eek(z0ZzZzlzk2.z0yek, out p))
				{
					yield return p;
				}
				if (z0ZzZzlzk2.z0eek(z0ZzZzlzk2.z0yek + 1, out p))
				{
					yield return p;
				}
				break;
			}
			flag = true;
		}
		if (z0ZzZzlzk2.z0yek > z0ZzZzlzk2.z0tek && z0ZzZzlzk2.z0eek(z0ZzZzlzk2.z0yek, out p))
		{
			yield return p;
		}
		if (z0ZzZzlzk2.z0pek != null)
		{
			yield return z0ZzZzlzk2.z0pek;
		}
	}
}
