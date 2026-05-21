using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace zzz;

internal sealed class z0ZzZzjqh
{
	private readonly TextWriter z0iek;

	internal bool z0oek;

	private bool z0pek;

	private StringBuilder z0mek;

	private char z0nek;

	public static bool z0rek(char p0)
	{
		if (z0ZzZzzsh.z0tek(p0))
		{
			return false;
		}
		return true;
	}

	internal void z0rek(bool p0)
	{
		z0pek = true;
		z0oek = p0;
		if (p0)
		{
			if (z0mek == null)
			{
				z0mek = new StringBuilder();
			}
			else
			{
				z0mek.Length = 0;
			}
		}
	}

	internal void z0tek(char p0)
	{
		z0nek = p0;
	}

	private void z0rek(string p0)
	{
		z0iek.Write('&');
		z0iek.Write(p0);
		z0iek.Write(';');
	}

	internal void z0yek(char p0)
	{
		if (z0ZzZzzsh.z0tek((int)p0))
		{
			throw new ArgumentException();
		}
		int num = p0;
		string text = num.ToString("X", NumberFormatInfo.InvariantInfo);
		if (z0oek)
		{
			z0mek.Append("&#x");
			z0mek.Append(text);
			z0mek.Append(';');
		}
		z0uek(text);
	}

	internal void z0rek(char p0, char p1)
	{
		if (!z0ZzZzzsh.z0rek((int)p0) || !z0ZzZzzsh.z0eek((int)p1))
		{
			throw z0ZzZzhah.z0eek(p0, p1);
		}
		z0iek.Write(p1);
		z0iek.Write(p0);
	}

	internal void z0tek(string p0)
	{
		if (z0oek)
		{
			z0mek.Append('&');
			z0mek.Append(p0);
			z0mek.Append(';');
		}
		z0rek(p0);
	}

	internal void z0yek(string p0)
	{
		if (p0 == null)
		{
			return;
		}
		if (z0oek)
		{
			z0mek.Append(p0);
		}
		int length = p0.Length;
		int num = 0;
		char c = '\0';
		while (true)
		{
			if (num < length && (z0ZzZzzsh.z0rek(c = p0[num]) || c < ' '))
			{
				num++;
				continue;
			}
			if (num == length)
			{
				break;
			}
			if (z0ZzZzzsh.z0eek((int)c))
			{
				if (num + 1 >= length)
				{
					throw new ArgumentException();
				}
				char p1 = p0[num + 1];
				if (!z0ZzZzzsh.z0rek((int)p1))
				{
					throw z0ZzZzhah.z0eek(p1, c);
				}
				num += 2;
			}
			else
			{
				if (z0ZzZzzsh.z0rek((int)c))
				{
					throw z0ZzZzhah.z0eek(c);
				}
				num++;
			}
		}
		z0iek.Write(p0);
	}

	private void z0uek(string p0)
	{
		z0iek.Write("&#x");
		z0iek.Write(p0);
		z0iek.Write(';');
	}

	internal z0ZzZzjqh(TextWriter p0)
	{
		z0iek = p0;
		z0nek = '"';
	}

	private void z0uek(char p0)
	{
		int num = p0;
		z0uek(num.ToString("X", NumberFormatInfo.InvariantInfo));
	}

	internal void z0rek()
	{
		if (z0oek)
		{
			z0mek.Length = 0;
		}
		z0pek = false;
		z0oek = false;
	}

	internal void z0eek(ReadOnlySpan<char> p0)
	{
		if (p0.IsEmpty)
		{
			return;
		}
		if (z0oek)
		{
			z0mek.Append(p0);
		}
		int length = p0.Length;
		int i = 0;
		int num = 0;
		char c = '\0';
		while (true)
		{
			if (i < length && z0ZzZzzsh.z0tek(c = p0[i]))
			{
				i++;
				continue;
			}
			if (i == length)
			{
				z0iek.Write(p0);
				return;
			}
			if (z0pek)
			{
				if (c != '\t')
				{
					break;
				}
				i++;
			}
			else
			{
				if (c != '\t' && c != '\n' && c != '\r' && c != '"' && c != '\'')
				{
					break;
				}
				i++;
			}
		}
		while (true)
		{
			if (num < i)
			{
				z0iek.Write(p0.Slice(num, i - num));
			}
			if (i == length)
			{
				break;
			}
			switch (c)
			{
			case '\t':
				z0iek.Write(c);
				break;
			case '\n':
			case '\r':
				if (z0pek)
				{
					z0uek(c);
				}
				else
				{
					z0iek.Write(c);
				}
				break;
			case '<':
				z0rek("lt");
				break;
			case '>':
				z0rek("gt");
				break;
			case '&':
				z0rek("amp");
				break;
			case '\'':
				if (z0pek && z0nek == c)
				{
					z0rek("apos");
				}
				else
				{
					z0iek.Write('\'');
				}
				break;
			case '"':
				if (z0pek && z0nek == c)
				{
					z0rek("quot");
				}
				else
				{
					z0iek.Write('"');
				}
				break;
			default:
				if (z0ZzZzzsh.z0eek((int)c))
				{
					if (i + 1 >= length)
					{
						throw z0ZzZzhah.z0eek(p0[i], c);
					}
					z0rek(p0[++i], c);
				}
				else
				{
					if (z0ZzZzzsh.z0rek((int)c))
					{
						throw z0ZzZzhah.z0eek(c);
					}
					z0uek(c);
				}
				break;
			}
			i++;
			num = i;
			for (; i < length; i++)
			{
				if (!z0ZzZzzsh.z0tek(c = p0[i]))
				{
					break;
				}
			}
		}
	}

	internal string z0tek()
	{
		if (z0oek)
		{
			return z0mek.ToString();
		}
		return string.Empty;
	}
}
