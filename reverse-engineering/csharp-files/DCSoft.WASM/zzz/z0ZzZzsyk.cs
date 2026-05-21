using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

public class z0ZzZzsyk : List<z0ZzZzqyk>
{
	public static int z0eek(object p0, string p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (string.IsNullOrEmpty(p1))
		{
			return 0;
		}
		return new z0ZzZzsyk(p1).z0eek(p0, p1: false);
	}

	public void z0eek(string p0, string p1)
	{
		z0ZzZzqyk z0ZzZzqyk2 = z0rek_jiejie20260327142557(p0);
		if (z0ZzZzqyk2 == null)
		{
			z0ZzZzqyk2 = new z0ZzZzqyk();
			z0ZzZzqyk2.z0eek(p0);
			z0ZzZzqyk2.z0rek(p1);
			Add(z0ZzZzqyk2);
		}
		else
		{
			z0ZzZzqyk2.z0rek(p1);
		}
	}

	public void z0eek(string p0)
	{
		Clear();
		if (string.IsNullOrEmpty(p0))
		{
			return;
		}
		while (p0.Length > 0)
		{
			string text = null;
			string p1 = null;
			int num = p0.IndexOf(':');
			if (num > 0)
			{
				text = p0.Substring(0, num);
				p0 = p0.Substring(num + 1);
				if (p0.StartsWith("'"))
				{
					int num2 = p0.IndexOf('\'', 1);
					if (num2 < 0)
					{
						num2 = p0.IndexOf(';');
					}
					if (num2 >= 0)
					{
						p1 = p0.Substring(1, num2 - 1);
						p0 = p0.Substring(num2 + 1);
						if (p0.StartsWith("'"))
						{
							p0 = p0.Substring(1);
						}
					}
					else
					{
						p1 = p0.Substring(1);
						p0 = string.Empty;
					}
				}
				else if (p0.StartsWith("\""))
				{
					int num3 = p0.IndexOf('"', 1);
					if (num3 < 0)
					{
						num3 = p0.IndexOf(';');
					}
					if (num3 >= 0)
					{
						p1 = p0.Substring(1, num3 - 1);
						p0 = p0.Substring(num3 + 1);
						if (p0.StartsWith("\""))
						{
							p0 = p0.Substring(1);
						}
						else if (p0.StartsWith(";"))
						{
							p0 = p0.Substring(1);
						}
					}
					else
					{
						p1 = p0.Substring(1);
						p0 = string.Empty;
					}
				}
				else
				{
					int num4 = p0.IndexOf(';');
					if (num4 >= 0)
					{
						p1 = p0.Substring(0, num4);
						p0 = p0.Substring(num4 + 1);
					}
					else
					{
						p1 = p0;
						p0 = string.Empty;
					}
				}
			}
			else
			{
				text = p0.Trim();
				p0 = string.Empty;
			}
			z0ZzZzqyk z0ZzZzqyk2 = new z0ZzZzqyk();
			z0ZzZzqyk2.z0eek(text);
			z0ZzZzqyk2.z0rek(p1);
			Add(z0ZzZzqyk2);
		}
	}

	public int z0eek(object p0, bool p1)
	{
		int num = 0;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzqyk current = enumerator.Current;
			if (z0ZzZzmik.z0eek(p0, current.z0eek(), current.z0rek(), p3: false))
			{
				num++;
			}
		}
		return num;
	}

	public z0ZzZzqyk z0rek_jiejie20260327142557(string p0)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzqyk current = enumerator.Current;
				if (string.Compare(current.z0eek(), p0, true) == 0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public z0ZzZzsyk(string p0)
	{
		z0eek(p0);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzqyk current = enumerator.Current;
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(';');
				}
				stringBuilder.Append(current.z0eek());
				stringBuilder.Append(':');
				string text = current.z0rek();
				if (text != null && text.Length > 0)
				{
					if (text.Contains(':') || text.Contains(';'))
					{
						text = "'" + text + "'";
					}
					stringBuilder.Append(text);
				}
			}
		}
		return stringBuilder.ToString();
	}

	public z0ZzZzsyk()
	{
	}
}
