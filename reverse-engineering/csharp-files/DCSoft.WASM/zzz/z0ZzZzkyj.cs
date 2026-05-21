using System;
using System.IO;
using System.Text;

namespace zzz;

internal class z0ZzZzkyj
{
	private readonly TextReader z0uek;

	private int z0eek()
	{
		int num = z0uek.Peek();
		while (num == 13 || num == 10 || num == 9 || num == 0)
		{
			z0uek.Read();
			num = z0uek.Peek();
		}
		return num;
	}

	public z0ZzZzoyj z0rek()
	{
		int num = 0;
		z0ZzZzoyj z0ZzZzoyj2 = new z0ZzZzoyj();
		num = z0uek.Read();
		if (num == 34)
		{
			z0ZzZzoyj2.z0eek((z0ZzZzpyj)4);
			z0ZzZzoyj2.z0eek("\"");
			return z0ZzZzoyj2;
		}
		while (true)
		{
			switch (num)
			{
			case 0:
			case 9:
			case 10:
			case 13:
				goto IL_002d;
			case 123:
				z0ZzZzoyj2.z0eek((z0ZzZzpyj)6);
				break;
			case 125:
				z0ZzZzoyj2.z0eek((z0ZzZzpyj)7);
				break;
			case 92:
				z0eek(z0ZzZzoyj2);
				break;
			default:
				z0ZzZzoyj2.z0eek((z0ZzZzpyj)4);
				z0eek(num, z0ZzZzoyj2);
				break;
			case -1:
				z0ZzZzoyj2.z0eek((z0ZzZzpyj)5);
				break;
			}
			break;
			IL_002d:
			num = z0uek.Read();
		}
		return z0ZzZzoyj2;
	}

	public z0ZzZzkyj(TextReader p0)
	{
		z0uek = p0;
	}

	private void z0eek(int p0, z0ZzZzoyj p1)
	{
		StringBuilder stringBuilder = new StringBuilder(((char)p0).ToString());
		p0 = z0eek();
		while (p0 != 92 && p0 != 125 && p0 != 123 && p0 != -1)
		{
			z0uek.Read();
			stringBuilder.Append((char)p0);
			p0 = z0eek();
		}
		p1.z0eek(stringBuilder.ToString());
	}

	public z0ZzZzpyj z0tek()
	{
		int num = z0uek.Peek();
		while (true)
		{
			switch (num)
			{
			case 0:
			case 9:
			case 10:
			case 13:
				break;
			case -1:
				return (z0ZzZzpyj)5;
			case 123:
				return (z0ZzZzpyj)6;
			case 125:
				return (z0ZzZzpyj)7;
			case 92:
				return (z0ZzZzpyj)3;
			default:
				return (z0ZzZzpyj)4;
			}
			num = z0uek.Read();
			num = z0uek.Peek();
		}
	}

	private void z0eek(z0ZzZzoyj p0)
	{
		int num = 0;
		bool flag = false;
		num = z0uek.Peek();
		if (!char.IsLetter((char)num))
		{
			z0uek.Read();
			switch (num)
			{
			case 42:
				break;
			case 92:
			case 123:
			case 125:
				p0.z0eek((z0ZzZzpyj)4);
				p0.z0eek(((char)num).ToString());
				return;
			default:
				p0.z0eek((z0ZzZzpyj)3);
				p0.z0eek(((char)num).ToString());
				if (p0.z0rek() == "'")
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append((char)z0uek.Read());
					stringBuilder.Append((char)z0uek.Read());
					p0.z0eek(p0: true);
					p0.z0eek(Convert.ToInt32(stringBuilder.ToString().ToLower(), 16));
					if (p0.z0eek() == 0)
					{
						p0.z0eek(0);
					}
				}
				return;
			}
			p0.z0eek((z0ZzZzpyj)1);
			z0uek.Read();
			flag = true;
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		num = z0uek.Peek();
		while (char.IsLetter((char)num))
		{
			z0uek.Read();
			stringBuilder2.Append((char)num);
			num = z0uek.Peek();
		}
		if (flag)
		{
			p0.z0eek((z0ZzZzpyj)2);
		}
		else
		{
			p0.z0eek((z0ZzZzpyj)1);
		}
		p0.z0eek(stringBuilder2.ToString());
		if (char.IsDigit((char)num) || num == 45)
		{
			p0.z0eek(p0: true);
			bool flag2 = false;
			if (num == 45)
			{
				flag2 = true;
				z0uek.Read();
			}
			num = z0uek.Peek();
			StringBuilder stringBuilder3 = new StringBuilder();
			while (char.IsDigit((char)num))
			{
				z0uek.Read();
				stringBuilder3.Append((char)num);
				num = z0uek.Peek();
			}
			int num2 = Convert.ToInt32(stringBuilder3.ToString());
			if (flag2)
			{
				num2 = -num2;
			}
			p0.z0eek(num2);
		}
		if (num == 32)
		{
			z0uek.Read();
		}
	}
}
