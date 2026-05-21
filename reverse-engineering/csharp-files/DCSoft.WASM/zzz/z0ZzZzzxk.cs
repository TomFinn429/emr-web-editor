using System;
using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

internal sealed class z0ZzZzzxk
{
	private z0ZzZzcxk z0rek;

	private GraphicsUnit z0tek;

	private static string[] z0uek = new string[1] { string.Empty };

	private string[] z0eek(string p0, z0ZzZzpej p1, float p2, float p3, z0ZzZzlsh p4, int p5, int p6, bool p7)
	{
		List<z0ZzZzkzk> list = null;
		list = ((!p7) ? z0ZzZzlxk.z0tek(new z0ZzZzlzk(p0, p4).z0eek()) : new List<z0ZzZzkzk>(1)
		{
			new z0ZzZzkzk(p0, 0)
		});
		using z0ZzZzhzk z0ZzZzhzk2 = new z0ZzZzhzk(p2, p3, p1, p4, z0tek, z0rek, p5, p7: false);
		return z0ZzZzhzk2.z0eek(list, p6) ? z0ZzZzhzk2.z0yek() : null;
	}

	internal z0ZzZzzxk(GraphicsUnit p0, z0ZzZzcxk p1)
	{
		z0tek = p0;
		z0rek = p1;
	}

	internal static IEnumerable<string> z0eek(string p0)
	{
		int num = 0;
		int num2 = 0;
		string newLine = Environment.NewLine;
		while (num < p0.Length)
		{
			switch (p0[num])
			{
			case '\r':
				if (p0.Length - num > 1 && p0.IndexOf(newLine, num, newLine.Length) >= 0)
				{
					yield return p0.Substring(num2, num - num2);
					int num3;
					num = (num3 = num + newLine.Length);
					num2 = num3;
				}
				else
				{
					yield return p0.Substring(num2, num - num2);
					int num3;
					num = (num3 = num + 1);
					num2 = num3;
				}
				break;
			case '\n':
			{
				yield return p0.Substring(num2, num - num2);
				int num3;
				num = (num3 = num + 1);
				num2 = num3;
				break;
			}
			default:
				num++;
				break;
			}
		}
		if (num != num2 && num > num2)
		{
			yield return (num2 == 0) ? p0 : p0.Substring(num2, num - num2);
		}
	}

	internal static float z0eek(z0ZzZzpej p0, int p1, GraphicsUnit p2)
	{
		return new z0ZzZznxk(p0, p2).z0eek(p1);
	}

	internal static void z0eek(z0ZzZzlsh p0, ref float p1, ref float p2)
	{
		if ((p0.z0yek() & (z0ZzZzksh)2) != 0)
		{
			float num = p2;
			p2 = p1;
			p1 = num;
		}
	}

	internal string[] z0eek(string p0, z0ZzZzpej p1, float p2, float p3, z0ZzZzlsh p4)
	{
		if (p2 < 0f)
		{
			throw new ArgumentException("width");
		}
		z0eek(p4, ref p2, ref p3);
		List<string> list = new List<string>();
		bool flag = (p4.z0yek() & (z0ZzZzksh)4096) != 0;
		string[] array = z0ZzZzlxk.z0rek(z0eek(p0));
		float num = z0eek(p1, 1, z0tek);
		float num2 = 0f;
		string[] array2 = array;
		foreach (string text in array2)
		{
			string text2 = (string.IsNullOrEmpty(text) ? text : text.TrimEnd(' '));
			string[] array3;
			if (flag)
			{
				array3 = new string[1] { text2 };
			}
			else
			{
				array3 = z0eek(text2, p1, p2, p3, p4, list.Count, array.Length, p7: false);
				if (array3 == null)
				{
					break;
				}
				if (array3.Length == 0)
				{
					array3 = z0uek;
				}
			}
			if (array3 == null)
			{
				continue;
			}
			string[] array4 = array3;
			foreach (string text3 in array4)
			{
				num2 += num;
				if (num2 - p3 > 0.05f && list.Count > 0)
				{
					float num3 = 0.75f * num;
					if (num2 - num3 > p3)
					{
						break;
					}
				}
				list.Add(text3);
			}
		}
		return list.ToArray();
	}
}
