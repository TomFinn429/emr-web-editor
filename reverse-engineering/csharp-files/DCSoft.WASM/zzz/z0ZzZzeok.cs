using System;
using System.Text;

namespace zzz;

public class z0ZzZzeok : z0ZzZzvuk
{
	private enum z0kxk
	{
		z0eek,
		z0rek,
		z0tek,
		z0yek
	}

	public enum z0mjj
	{
		z0eek,
		z0rek,
		z0tek
	}

	private z0kxk[] z0tek = new z0kxk[200];

	private int z0uek;

	private StringBuilder z0iek;

	private int[] z0oek = new int[200];

	private int z0pek;

	public bool z0mek;

	public unsafe static void z0eek(string p0, StringBuilder p1)
	{
		if (p0 == null)
		{
			p1.Append("null");
			return;
		}
		bool flag = true;
		p1.Append('"');
		int length = p0.Length;
		if (length > 0)
		{
			fixed (char* ptr = p0)
			{
				char* ptr2 = ptr + length;
				for (char* ptr3 = ptr; ptr3 < ptr2; ptr3++)
				{
					switch (*ptr3)
					{
					case '\t':
					case '\n':
					case '\r':
					case '"':
					case '\\':
						flag = false;
						if (ptr3 > ptr)
						{
							p1.Append(p0, 0, (int)(ptr3 - ptr));
						}
						for (; ptr3 < ptr2; ptr3++)
						{
							char c = *ptr3;
							switch (c)
							{
							case '"':
								p1.Append("\\\"");
								break;
							case '\\':
								p1.Append("\\\\");
								break;
							case '\r':
								p1.Append("\\r");
								break;
							case '\n':
								p1.Append("\\n");
								break;
							case '\t':
								p1.Append("\\t");
								break;
							default:
								p1.Append(c);
								break;
							}
						}
						goto end_IL_0130;
					}
					continue;
					end_IL_0130:
					break;
				}
			}
			if (flag)
			{
				p1.Append(p0);
			}
		}
		p1.Append('"');
	}

	public void z0rwk(string p0)
	{
		int num = z0uek;
		z0rek(z0kxk.z0yek);
		z0eek(p0, z0iek);
		z0iek.Append(':');
		z0oek[num]++;
	}

	private void z0eek(bool p0 = true)
	{
		if (z0mek)
		{
			if (z0iek.Length > 0)
			{
				z0iek.AppendLine();
			}
			if (z0pek > 0)
			{
				z0iek.Append(' ', z0pek * 4);
			}
		}
	}

	public z0ZzZzeok(StringBuilder p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("w");
		}
		z0iek = p0;
	}

	public void z0ewk(string p0 = null)
	{
		z0rek(z0kxk.z0tek);
		z0iek.Append('{');
	}

	private void z0eek(z0kxk p0)
	{
		bool flag = true;
		if ((p0 == z0kxk.z0rek || p0 == z0kxk.z0tek) && z0uek > 0 && z0tek[z0uek - 1] == z0kxk.z0yek)
		{
			flag = false;
		}
		if (p0 == z0kxk.z0tek)
		{
			flag = true;
		}
		if (flag)
		{
			z0pek--;
		}
		while (z0uek >= 0)
		{
			z0kxk z0kxk = z0tek[z0uek];
			z0uek--;
			switch (z0kxk)
			{
			case z0kxk.z0rek:
				if (z0mek)
				{
					z0iek.AppendLine();
					z0eek();
				}
				z0iek.Append(']');
				break;
			case z0kxk.z0tek:
				if (z0mek)
				{
					z0iek.AppendLine();
					z0eek();
				}
				z0iek.Append('}');
				break;
			default:
				_ = 3;
				break;
			}
			if (z0kxk == p0)
			{
				break;
			}
		}
	}

	public void z0wwk()
	{
		z0eek(z0kxk.z0yek);
	}

	public z0ZzZzeok()
	{
		z0iek = new StringBuilder();
	}

	public void z0eek(string p0, bool p1)
	{
		if (z0tek[z0uek] == z0kxk.z0rek)
		{
			if (z0oek[z0uek] > 0)
			{
				z0iek.Append(',');
			}
			z0eek(p0: true);
			z0oek[z0uek]++;
			if (p1)
			{
				z0eek(p0, z0iek);
			}
			else
			{
				z0iek.Append(p0);
			}
			return;
		}
		throw new Exception("当前不是数组状态");
	}

	public void z0qwk()
	{
		z0eek(z0kxk.z0tek);
	}

	public void z0rek(string p0, bool p1)
	{
		if (p1)
		{
			z0rek(p0, "true", z0mjj.z0rek);
		}
		else
		{
			z0rek(p0, "false", z0mjj.z0rek);
		}
	}

	public void z0eek(string p0, string p1)
	{
		z0rek(p0, p1, z0mjj.z0eek);
	}

	public void z0awk()
	{
		z0eek(z0kxk.z0rek);
	}

	public void z0eek(string p0, string p1, z0mjj p2)
	{
		z0rek(p0, p1, p2);
	}

	private void z0rek(string p0, string p1, z0mjj p2)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("name");
		}
		if (z0oek[z0uek] > 0)
		{
			z0iek.Append(',');
		}
		if (z0mek && z0iek[z0iek.Length - 1] != '{')
		{
			z0eek(p0: true);
		}
		z0oek[z0uek]++;
		z0iek.Append('"');
		z0iek.Append(p0);
		z0iek.Append('"');
		z0iek.Append(':');
		switch (p2)
		{
		case z0mjj.z0rek:
			z0iek.Append(p1);
			return;
		case z0mjj.z0eek:
			z0eek(p1, z0iek);
			return;
		}
		z0iek.Append('"');
		z0iek.Append(p1);
		z0iek.Append('"');
	}

	public override string ToString()
	{
		return z0iek.ToString();
	}

	public void z0swk()
	{
		z0rek(z0kxk.z0rek);
		z0iek.Append('[');
	}

	private void z0eek()
	{
		if (z0mek && z0pek > 0)
		{
			z0iek.Append(new string(' ', z0pek * 4));
		}
	}

	private void z0rek(z0kxk p0)
	{
		if (z0uek >= 200)
		{
			throw new IndexOutOfRangeException("JSON数据套嵌过深，超过" + 200);
		}
		bool num = z0oek[z0uek] == 0;
		if (!num)
		{
			z0iek.Append(',');
		}
		_ = z0tek[z0uek];
		bool flag = true;
		if (p0 == z0kxk.z0rek)
		{
			if (z0uek > 0 && z0tek[z0uek] == z0kxk.z0yek)
			{
				flag = false;
			}
		}
		else
		{
			_ = 2;
		}
		if (!num || p0 != z0kxk.z0yek)
		{
			z0eek(p0: true);
		}
		if (flag)
		{
			z0pek++;
		}
		z0oek[z0uek]++;
		z0uek++;
		z0tek[z0uek] = p0;
		z0oek[z0uek] = 0;
	}
}
