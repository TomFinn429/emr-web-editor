using System;
using System.Text;

namespace zzz;

public sealed class z0ZzZzayk
{
	private readonly char z0tek = ';';

	private readonly char z0yek_jiejie20260327142557 = ':';

	private readonly StringBuilder z0uek = new StringBuilder();

	public override string ToString()
	{
		return z0uek.ToString();
	}

	public z0ZzZzayk(char p0, char p1)
	{
		if (p0 == '\0')
		{
			throw new ArgumentNullException("valueSpliter");
		}
		if (p1 == '\0')
		{
			throw new ArgumentNullException("itemSpliter");
		}
		z0yek_jiejie20260327142557 = p0;
		z0tek = p1;
	}

	public char z0eek()
	{
		return z0yek_jiejie20260327142557;
	}

	public void z0eek(string p0, string p1)
	{
		if (z0uek.Length > 0)
		{
			z0uek.Append(z0tek);
		}
		z0uek.Append(p0);
		z0uek.Append(z0yek_jiejie20260327142557);
		if (p1 == null || p1.Length <= 0)
		{
			return;
		}
		foreach (char c in p1)
		{
			if (c == '\'' || c == z0tek || c == z0yek_jiejie20260327142557)
			{
				z0uek.Append('"');
				z0uek.Append(p1);
				z0uek.Append('"');
				return;
			}
		}
		z0uek.Append(p1);
	}

	public char z0rek()
	{
		return z0tek;
	}

	public z0ZzZzayk()
	{
	}
}
