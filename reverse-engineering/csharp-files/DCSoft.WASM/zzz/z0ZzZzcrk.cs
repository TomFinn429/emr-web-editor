using System;

namespace zzz;

internal class z0ZzZzcrk : z0ZzZzerk
{
	private new z0ZzZzrrk z0rek;

	private new static readonly string[] z0tek = new string[10] { "100100100100", "100100100110", "100100110100", "100100110110", "100110100100", "100110100110", "100110110100", "100110110110", "110100100100", "110100100110" };

	public z0ZzZzcrk(string p0, z0ZzZzrrk p1)
	{
		z0rek = p1;
		base.z0tek = p0;
	}

	private string z0eek()
	{
		base.z0rek = null;
		if (!z0eek(base.z0tek))
		{
			base.z0rek = z0ZzZziok.z0ytk();
			return null;
		}
		string text = base.z0tek;
		string text4;
		if (z0rek == (z0ZzZzrrk)18 || z0rek == (z0ZzZzrrk)19)
		{
			string text2 = string.Empty;
			string text3 = string.Empty;
			for (int num = text.Length - 1; num >= 0; num -= 2)
			{
				text2 = text[num] + text2;
				if (num - 1 >= 0)
				{
					text3 = text[num - 1] + text3;
				}
			}
			text2 = Convert.ToString(int.Parse(text2) * 2);
			int num2 = 0;
			int num3 = 0;
			text4 = text3;
			for (int i = 0; i < text4.Length; i++)
			{
				num2 += int.Parse(text4[i].ToString());
			}
			text4 = text2;
			for (int i = 0; i < text4.Length; i++)
			{
				num3 += int.Parse(text4[i].ToString());
			}
			text += 10 - (num3 + num2) % 10;
		}
		if (z0rek == (z0ZzZzrrk)20 || z0rek == (z0ZzZzrrk)21)
		{
			int num4 = 0;
			int num5 = 2;
			for (int num6 = text.Length - 1; num6 >= 0; num6--)
			{
				if (num5 > 7)
				{
					num5 = 2;
				}
				num4 += int.Parse(text[num6].ToString()) * num5++;
			}
			text += 11 - num4 % 11;
		}
		if (z0rek == (z0ZzZzrrk)19 || z0rek == (z0ZzZzrrk)21)
		{
			string text5 = string.Empty;
			string text6 = string.Empty;
			for (int num7 = text.Length - 1; num7 >= 0; num7 -= 2)
			{
				text5 = text[num7] + text5;
				if (num7 - 1 >= 0)
				{
					text6 = text[num7 - 1] + text6;
				}
			}
			text5 = Convert.ToString(int.Parse(text5) * 2);
			int num8 = 0;
			int num9 = 0;
			text4 = text6;
			for (int i = 0; i < text4.Length; i++)
			{
				num8 += int.Parse(text4[i].ToString());
			}
			text4 = text5;
			for (int i = 0; i < text4.Length; i++)
			{
				num9 += int.Parse(text4[i].ToString());
			}
			text += 10 - (num9 + num8) % 10;
		}
		string text7 = "110";
		text4 = text;
		foreach (char c in text4)
		{
			text7 += z0tek[int.Parse(c.ToString())];
		}
		return text7 + "1001";
	}

	public override string z0nwk()
	{
		return z0eek();
	}
}
