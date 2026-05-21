using System;
using System.Text;

namespace zzz;

public static class z0ZzZzeik
{
	public static string z0eek(string p0, params object[] p1)
	{
		if (string.IsNullOrEmpty(p0) || p1 == null || p1.Length == 0)
		{
			return p0;
		}
		string[] array = z0ZzZznik.AnalyseVariableString(p0, "{", "}");
		StringBuilder stringBuilder = new StringBuilder(p0.Length);
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			if (i % 2 == 0)
			{
				stringBuilder.Append(text);
				continue;
			}
			int num = text.IndexOf(':');
			string text2 = null;
			if (num > 0)
			{
				text2 = text.Substring(num + 1);
				text = text.Substring(0, num).Trim();
			}
			int num2 = 0;
			if (int.TryParse(text, out num2))
			{
				if (num2 < 0 || num2 >= p1.Length)
				{
					continue;
				}
				object obj = p1[num2];
				if (obj != null)
				{
					if (!string.IsNullOrEmpty(text2) || obj is IFormattable)
					{
						stringBuilder.Append(((IFormattable)obj).ToString(text2, null));
					}
					else
					{
						stringBuilder.Append(Convert.ToString(obj));
					}
				}
				continue;
			}
			object obj2 = null;
			if (p1[0] is z0ZzZzlik)
			{
				obj2 = ((z0ZzZzlik)p1[0]).z0ca(text);
			}
			if (obj2 != null)
			{
				if (text2 != null && text2.Length > 0 && obj2 is IFormattable)
				{
					string text3 = ((IFormattable)obj2).ToString(text2, null);
					stringBuilder.Append(text3);
				}
				else
				{
					stringBuilder.Append(Convert.ToString(obj2));
				}
			}
		}
		return stringBuilder.ToString();
	}

	public static string z0eek(string p0, int p1, int p2)
	{
		if (string.IsNullOrEmpty(p0) || (p1 <= 0 && p2 <= 0))
		{
			return p0;
		}
		StringBuilder stringBuilder = new StringBuilder((int)((double)p0.Length * 1.1));
		int length = p0.Length;
		int num = 0;
		p2 *= p1;
		while (true)
		{
			stringBuilder.Append(' ');
			if (num + p1 >= length)
			{
				break;
			}
			stringBuilder.Append(p0, num, p1);
			num += p1;
			if (num % p2 == 0)
			{
				stringBuilder.AppendLine();
			}
		}
		stringBuilder.Append(p0, num, length - num);
		return stringBuilder.ToString();
	}

	public static bool z0eek(char p0)
	{
		if (p0 < 'a' || p0 > 'z')
		{
			if (p0 >= 'A')
			{
				return p0 <= 'Z';
			}
			return false;
		}
		return true;
	}
}
