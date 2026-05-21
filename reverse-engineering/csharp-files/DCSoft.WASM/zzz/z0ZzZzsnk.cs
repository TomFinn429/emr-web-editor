using System;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzsnk : List<z0ZzZzdnk>
{
	private int z0yek = -1;

	public z0ZzZzdnk z0eek()
	{
		if (z0yek >= 0 && z0yek < base.Count - 1)
		{
			return base[z0yek + 1];
		}
		return null;
	}

	public bool z0rek()
	{
		z0yek++;
		if (z0yek >= 0 && z0yek < base.Count)
		{
			return true;
		}
		return false;
	}

	public z0ZzZzsnk(string p0)
	{
		z0eek(p0);
	}

	public z0ZzZzdnk z0tek()
	{
		if (z0yek >= 0 && z0yek < base.Count)
		{
			return base[z0yek];
		}
		return null;
	}

	private char z0eek(string p0, int p1)
	{
		if (p1 < p0.Length - 1)
		{
			return p0[p1 + 1];
		}
		return '\0';
	}

	private z0ZzZzvmk z0eek(char p0)
	{
		switch (p0)
		{
		case '$':
			return (z0ZzZzvmk)1;
		case '(':
			return (z0ZzZzvmk)4;
		case ')':
			return (z0ZzZzvmk)5;
		case ',':
			return (z0ZzZzvmk)9;
		case '%':
		case '*':
		case '+':
		case '-':
		case '/':
		case '\\':
			return (z0ZzZzvmk)2;
		case '!':
		case '&':
		case '<':
		case '=':
		case '>':
		case '^':
		case '|':
			return (z0ZzZzvmk)3;
		default:
			if (char.IsWhiteSpace(p0))
			{
				return (z0ZzZzvmk)8;
			}
			if (p0 != ':' && p0 != '.' && !char.IsLetterOrDigit(p0) && !char.IsSymbol(p0) && p0 != '[')
			{
				_ = 93;
			}
			return (z0ZzZzvmk)1;
		}
	}

	public void z0eek(string p0)
	{
		Clear();
		if (p0 == null || p0.Length == 0)
		{
			return;
		}
		z0ZzZzdnk z0ZzZzdnk2 = null;
		z0ZzZzenk z0ZzZzenk2 = (z0ZzZzenk)0;
		for (int i = 0; i < p0.Length; i++)
		{
			char c = p0[i];
			if (z0ZzZzenk2 == (z0ZzZzenk)1 || z0ZzZzenk2 == (z0ZzZzenk)2)
			{
				if (c == '\\')
				{
					string text = "01234567";
					string p1 = "0123456789ABCDEF";
					char c2 = z0eek(p0, i);
					if (text.Contains(c2))
					{
						string text2 = z0eek(p0, i, 3);
						if (text2 != null && text2.Length == 3)
						{
							i += 3;
							int num = z0eek(text2, text);
							z0ZzZzdnk2.z0eek.Append((char)num);
							continue;
						}
						throw new Exception("长度不够:" + p0);
					}
					switch (c2)
					{
					case 'x':
					{
						i++;
						string text3 = z0eek(p0, i, 2);
						if (text3 != null && text3.Length == 2)
						{
							text3 = text3.ToUpper();
							i += 2;
							int num2 = z0eek(text3, p1);
							z0ZzZzdnk2.z0eek.Append((char)num2);
							break;
						}
						throw new Exception("长度不够:" + p0);
					}
					case 'a':
						z0ZzZzdnk2.z0eek.Append('\a');
						break;
					case 'b':
						z0ZzZzdnk2.z0eek.Append('\b');
						break;
					case 'n':
						z0ZzZzdnk2.z0eek.Append('\n');
						break;
					case 'r':
						z0ZzZzdnk2.z0eek.Append('\r');
						break;
					case 'v':
						z0ZzZzdnk2.z0eek.Append('\v');
						break;
					case '"':
						z0ZzZzdnk2.z0eek.Append('"');
						break;
					case '\'':
						z0ZzZzdnk2.z0eek.Append('\'');
						break;
					default:
						throw new Exception("不支持的转移:" + c2);
					}
				}
				else if (z0ZzZzenk2 == (z0ZzZzenk)1 && c == '\'')
				{
					z0ZzZzdnk2.z0eek.Append(c);
					z0ZzZzdnk2 = null;
					z0ZzZzenk2 = (z0ZzZzenk)0;
				}
				else if (z0ZzZzenk2 == (z0ZzZzenk)2 && c == '"')
				{
					z0ZzZzdnk2.z0eek.Append(c);
					z0ZzZzdnk2 = null;
					z0ZzZzenk2 = (z0ZzZzenk)0;
				}
				else
				{
					z0ZzZzdnk2.z0eek.Append(c);
				}
				continue;
			}
			switch (c)
			{
			case '\'':
				z0ZzZzdnk2 = new z0ZzZzdnk();
				z0ZzZzdnk2.z0tek = (z0ZzZzvmk)10;
				z0ZzZzdnk2.z0eek.Append(c);
				z0ZzZzenk2 = (z0ZzZzenk)1;
				Add(z0ZzZzdnk2);
				continue;
			case '"':
				z0ZzZzdnk2 = new z0ZzZzdnk();
				z0ZzZzdnk2.z0tek = (z0ZzZzvmk)10;
				z0ZzZzdnk2.z0eek.Append(c);
				z0ZzZzenk2 = (z0ZzZzenk)2;
				Add(z0ZzZzdnk2);
				continue;
			}
			if (char.IsWhiteSpace(c))
			{
				z0ZzZzdnk2 = null;
				for (; i < p0.Length; i++)
				{
					if (!char.IsWhiteSpace(p0[i]))
					{
						i--;
						break;
					}
				}
				continue;
			}
			switch (c)
			{
			case '(':
				z0ZzZzdnk2 = new z0ZzZzdnk();
				z0ZzZzdnk2.z0eek.Append(c);
				z0ZzZzdnk2.z0tek = (z0ZzZzvmk)4;
				Add(z0ZzZzdnk2);
				z0ZzZzdnk2 = null;
				continue;
			case ')':
				z0ZzZzdnk2 = new z0ZzZzdnk();
				z0ZzZzdnk2.z0eek.Append(c);
				z0ZzZzdnk2.z0tek = (z0ZzZzvmk)5;
				Add(z0ZzZzdnk2);
				z0ZzZzdnk2 = null;
				continue;
			}
			z0ZzZzvmk z0ZzZzvmk2 = z0eek(c);
			if (z0ZzZzdnk2 == null || z0ZzZzdnk2.z0tek != z0ZzZzvmk2)
			{
				z0ZzZzdnk2 = new z0ZzZzdnk();
				z0ZzZzdnk2.z0tek = z0ZzZzvmk2;
				Add(z0ZzZzdnk2);
			}
			z0ZzZzdnk2.z0eek.Append(c);
		}
		if (z0ZzZzdnk2 != null && z0ZzZzdnk2.z0eek.Length > 0 && !Contains(z0ZzZzdnk2))
		{
			Add(z0ZzZzdnk2);
		}
		using List<z0ZzZzdnk>.Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzdnk current = enumerator.Current;
			if (current.z0eek != null)
			{
				current.z0rek = current.z0eek.ToString();
				current.z0eek = null;
			}
		}
	}

	private int z0eek(string p0, string p1)
	{
		int num = 0;
		for (int i = 0; i < p0.Length; i++)
		{
			int num2 = p1.IndexOf(p0[i]);
			if (num2 < 0)
			{
				throw new InvalidCastException(p1 + ":" + p0);
			}
			num = num * p1.Length + num2;
		}
		return num;
	}

	private string z0eek(string p0, int p1, int p2)
	{
		if (p1 < p0.Length - p2)
		{
			return p0.Substring(p1, p2);
		}
		return null;
	}
}
