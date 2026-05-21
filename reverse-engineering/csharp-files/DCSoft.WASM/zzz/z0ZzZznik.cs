using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZznik
{
	public static string[] z0eek(string p0, char p1, char p2, bool p3)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0.Length == 0)
		{
			return new string[1] { p0 };
		}
		List<string> list = new List<string>();
		int length = p0.Length;
		int num = 0;
		for (int i = 0; i < length; i++)
		{
			if (p0[i] != p1)
			{
				continue;
			}
			for (int j = i + 1; j < length; j++)
			{
				char c = p0[j];
				if (c == p2)
				{
					if (j != i + 1 || p3)
					{
						if (i == num)
						{
							list.Add(string.Empty);
						}
						else
						{
							list.Add(p0.Substring(num, i - num));
						}
						list.Add(p0.Substring(i + 1, j - i - 1));
						num = j + 1;
						i = num;
					}
					break;
				}
				if (c == p1)
				{
					i = j - 1;
					break;
				}
			}
		}
		if (num == 0)
		{
			return new string[1] { p0 };
		}
		if (num < length)
		{
			list.Add(p0.Substring(num, length - num));
		}
		return list.ToArray();
	}

	private static int z0eek(string p0, string p1, int p2, int p3)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("strText");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("strSearch");
		}
		int num = p0.IndexOf(p1, p2, StringComparison.Ordinal);
		if (num == -1)
		{
			return -1;
		}
		p2 += p1.Length;
		while (true)
		{
			int num2 = p0.IndexOf(p1, p2, StringComparison.Ordinal);
			if (num2 == -1 || num2 >= p3)
			{
				break;
			}
			num = num2;
			p2 += p1.Length;
		}
		return num;
	}

	public static string[] AnalyseVariableString(string strText, string strHead, string strEnd)
	{
		return z0eek(strText, strHead, strEnd, p3: false);
	}

	public static string[] z0eek(string p0, string p1, string p2, bool p3)
	{
		if (p0 == null || p1 == null || p2 == null || p1.Length == 0 || p2.Length == 0 || p0.Length == 0)
		{
			return new string[1] { p0 };
		}
		if (p1.Length == 1 && p2.Length == 1)
		{
			return z0eek(p0, p1[0], p2[0], p3);
		}
		int num = p0.IndexOf(p1, StringComparison.Ordinal);
		if (num < 0)
		{
			return new string[1] { p0 };
		}
		List<string> list = new List<string>();
		int num2 = 0;
		do
		{
			int num3 = p0.IndexOf(p2, num + 1, StringComparison.Ordinal);
			if (num3 <= num)
			{
				break;
			}
			num = z0eek(p0, p1, num2, num3);
			if (num == -1)
			{
				break;
			}
			int num4 = num3 - num - p1.Length;
			if (num4 < 0 || (num4 == 0 && !p3))
			{
				break;
			}
			string text = p0.Substring(num + p1.Length, num4);
			if (num2 < num)
			{
				string text2 = p0.Substring(num2, num - num2);
				list.Add(text2);
			}
			else
			{
				list.Add(string.Empty);
			}
			list.Add(text);
			num = num3 + p2.Length;
			num2 = num;
		}
		while (num >= 0 && num < p0.Length);
		if (num2 < p0.Length)
		{
			list.Add(p0.Substring(num2));
		}
		string[] array = list.ToArray();
		if (p1.Length == 1 && p2.Length == 1)
		{
			string[] array2 = z0eek(p0, p1[0], p2[0], p3);
			if (array.Length != array2.Length)
			{
				throw new Exception("AnalyseVariableString2");
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != array2[i])
				{
					throw new Exception("AnalyseVariableString2");
				}
			}
		}
		return array;
	}
}
