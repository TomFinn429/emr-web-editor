using System;
using System.Collections;
using System.Text;

namespace zzz;

public sealed class z0ZzZzwik
{
	public static DateTime z0eek(string p0, DateTime p1)
	{
		try
		{
			if (!z0tek(p0))
			{
				return p1;
			}
			if (p0.Length < 4)
			{
				return p1;
			}
			int num = 1;
			int num2 = 1;
			int num3 = 1;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			num = Convert.ToInt32(p0.Substring(0, 4));
			if (p0.Length >= 6)
			{
				num2 = Convert.ToInt32(p0.Substring(4, 2));
				if (num2 <= 0 || num2 > 12)
				{
					return p1;
				}
			}
			if (p0.Length >= 8)
			{
				num3 = Convert.ToInt32(p0.Substring(6, 2));
				if (num3 <= 0 || num3 > DateTime.DaysInMonth(num, num2))
				{
					return p1;
				}
			}
			if (p0.Length >= 10)
			{
				num4 = Convert.ToInt32(p0.Substring(8, 2));
				if (num4 > 60)
				{
					return p1;
				}
			}
			if (p0.Length >= 12)
			{
				num5 = Convert.ToInt32(p0.Substring(10, 2));
				if (num5 > 60)
				{
					return p1;
				}
			}
			if (p0.Length >= 14)
			{
				num6 = Convert.ToInt32(p0.Substring(12, 2));
				if (num6 > 60)
				{
					return p1;
				}
			}
			return new DateTime(num, num2, num3, num4, num5, num6);
		}
		catch
		{
			return p1;
		}
	}

	public static string z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p0;
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		for (int i = 0; i < p0.Length; i++)
		{
			char c = p0[i];
			if (flag)
			{
				flag = false;
				switch (c)
				{
				case 'a':
					stringBuilder.Append('\a');
					continue;
				case 'b':
					stringBuilder.Append('\b');
					continue;
				case 'f':
					stringBuilder.Append('\f');
					continue;
				case 'n':
					stringBuilder.Append('\n');
					continue;
				case 'r':
					stringBuilder.Append('\r');
					continue;
				case 't':
					stringBuilder.Append('\t');
					continue;
				case 'v':
					stringBuilder.Append('\v');
					continue;
				case '\\':
					stringBuilder.Append('\\');
					continue;
				case '\'':
					stringBuilder.Append('\'');
					continue;
				case '"':
					stringBuilder.Append('"');
					continue;
				case '?':
					stringBuilder.Append('?');
					continue;
				case '0':
					stringBuilder.Append('\0');
					continue;
				case 'x':
				{
					i++;
					if (i >= p0.Length)
					{
						continue;
					}
					int num = z0ZzZzqik.z0rek(p0[i]);
					if (num >= 0)
					{
						int num2 = num;
						i++;
						if (i < p0.Length)
						{
							num = z0ZzZzqik.z0rek(p0[i]);
							if (num >= 0)
							{
								num2 = num2 * 16 + num;
							}
							else
							{
								i--;
							}
						}
						stringBuilder.Append((char)num2);
					}
					else
					{
						i--;
					}
					continue;
				}
				}
				if (i >= p0.Length)
				{
					continue;
				}
				int num3 = z0ZzZzqik.z0tek(p0[i]);
				if (num3 >= 0)
				{
					int num4 = num3;
					i++;
					if (i < p0.Length)
					{
						num3 = z0ZzZzqik.z0tek(p0[i]);
						if (num3 >= 0)
						{
							num4 = num4 * 8 + num3;
							i++;
							if (i < p0.Length)
							{
								num3 = z0ZzZzqik.z0tek(p0[i]);
								if (num3 >= 0)
								{
									num4 = num4 * 8 + num3;
								}
								else
								{
									i--;
								}
							}
						}
						else
						{
							i--;
						}
					}
					stringBuilder.Append((char)num4);
				}
				else
				{
					i--;
				}
			}
			else if (c == '\\')
			{
				flag = true;
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public static string z0eek(int p0)
	{
		int[] array = new int[13];
		string[] array2 = new string[13];
		int num = 0;
		array[0] = 1000;
		array[1] = 900;
		array[2] = 500;
		array[3] = 400;
		array[4] = 100;
		array[5] = 90;
		array[6] = 50;
		array[7] = 40;
		array[8] = 10;
		array[9] = 9;
		array[10] = 5;
		array[11] = 4;
		array[12] = 1;
		array2[0] = "M";
		array2[1] = "CM";
		array2[2] = "D";
		array2[3] = "CD";
		array2[4] = "C";
		array2[5] = "XC";
		array2[6] = "L";
		array2[7] = "XL";
		array2[8] = "X";
		array2[9] = "IX";
		array2[10] = "V";
		array2[11] = "IV";
		array2[12] = "I";
		StringBuilder stringBuilder = new StringBuilder();
		while (p0 > 0)
		{
			while (p0 >= array[num])
			{
				p0 -= array[num];
				stringBuilder.Append(array2[num]);
			}
			num++;
		}
		return stringBuilder.ToString();
	}

	public static DateTime z0rek(string p0, DateTime p1)
	{
		try
		{
			if (!z0tek(p0))
			{
				return p1;
			}
			int hour = 0;
			int minute = 0;
			int second = 0;
			if (p0.Length >= 2)
			{
				hour = Convert.ToInt32(p0.Substring(0, 2));
			}
			if (p0.Length >= 4)
			{
				minute = Convert.ToInt32(p0.Substring(2, 2));
			}
			if (p0.Length >= 6)
			{
				second = Convert.ToInt32(p0.Substring(4, 2));
			}
			return new DateTime(1900, 1, 1, hour, minute, second);
		}
		catch
		{
			return p1;
		}
	}

	public static string z0eek(int p0, string p1)
	{
		if (string.IsNullOrEmpty(p1))
		{
			throw new ArgumentNullException("letters");
		}
		if (p0 <= 0)
		{
			return p1[0].ToString();
		}
		StringBuilder stringBuilder = new StringBuilder();
		int length = p1.Length;
		while (p0 > 0)
		{
			int num = p0 % length;
			stringBuilder.Insert(0, p1[num]);
			p0 = (p0 - num) / length;
		}
		return stringBuilder.ToString();
	}

	public static int[] z0rek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < p0.Length; i++)
		{
			bool flag3 = i == p0.Length - 1;
			char c = p0[i];
			if (c >= '0' && c <= '9')
			{
				num = num * 10 + c - 48;
				flag = true;
			}
			else if (c == '-')
			{
				if (flag)
				{
					flag3 = true;
					i--;
				}
				else
				{
					flag2 = true;
				}
			}
			else
			{
				flag3 = true;
			}
			if (!flag3)
			{
				continue;
			}
			if (flag)
			{
				if (flag2)
				{
					num = -num;
				}
				arrayList.Add(num);
				num = 0;
			}
			flag2 = false;
			flag = false;
		}
		if (arrayList.Count > 0)
		{
			return (int[])arrayList.ToArray(typeof(int));
		}
		return null;
	}

	public static bool z0eek(char p0)
	{
		if (p0 >= '一')
		{
			return p0 <= '龥';
		}
		return false;
	}

	public static string z0eek(double p0, bool p1)
	{
		bool flag = p0 < 0.0;
		if (flag)
		{
			p0 = 0.0 - p0;
		}
		int num = (int)Math.Truncate(p0);
		double num2 = p0 - (double)num;
		StringBuilder stringBuilder = new StringBuilder();
		int num3 = -1;
		string text = null;
		string[] array = null;
		if (p1)
		{
			text = "零一二三四五六七八九";
			array = new string[22]
			{
				"", "十", "百", "千", "万", "十万", "百万", "千万", "亿", "十亿",
				"百亿", "千亿", "万亿", "兆", "十兆", "百兆", "千兆", "万兆", "十万兆", "百万兆",
				"千万兆", "亿兆"
			};
		}
		else
		{
			text = "零壹贰叁肆伍陆柒捌玖";
			array = new string[22]
			{
				"", "拾", "佰", "仟", "万", "拾万", "佰万", "仟万", "亿", "拾亿",
				"佰亿", "仟亿", "万亿", "兆", "拾兆", "佰兆", "仟兆", "万兆", "拾万兆", "佰万兆",
				"仟万兆", "亿兆"
			};
		}
		int num4 = -1;
		while (num > 0)
		{
			num3++;
			if (num3 > array.Length)
			{
				throw new ArgumentOutOfRangeException(p0.ToString());
			}
			int num5 = num % 10;
			num = (num - num5) / 10;
			if (num5 > 0)
			{
				stringBuilder.Insert(0, array[num3]);
			}
			if (num5 != 0 || num4 != 0)
			{
				stringBuilder.Insert(0, text[num5]);
			}
			num4 = num5;
		}
		if (stringBuilder.Length > 0)
		{
			while (stringBuilder[stringBuilder.Length - 1] == text[0])
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
			}
		}
		if (stringBuilder.Length >= 2 && stringBuilder[0] == text[1] && stringBuilder[1].ToString() == array[1])
		{
			stringBuilder.Remove(0, 1);
		}
		if (stringBuilder.Length == 0)
		{
			stringBuilder.Append(text[0]);
		}
		if (num2 > 1E-05)
		{
			stringBuilder.Append("点");
			for (num3 = 0; num3 < 4; num3++)
			{
				num2 *= 10.0;
				stringBuilder.Append(text[(int)Math.Truncate(num2) % 10]);
			}
			int num6 = stringBuilder.Length - 1;
			while (num6 >= 0 && stringBuilder[num6] == text[0])
			{
				stringBuilder.Remove(num6, 1);
				num6--;
			}
		}
		if (flag)
		{
			stringBuilder.Insert(0, "负");
		}
		return stringBuilder.ToString();
	}

	public static bool z0tek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			int length = p0.Length;
			for (int i = 0; i < length; i++)
			{
				char c = p0[i];
				if (c > '9' || c < '0')
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}
}
