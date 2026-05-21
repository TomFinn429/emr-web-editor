namespace zzz;

internal class z0ZzZzyrk : z0ZzZzerk
{
	private new static string[] z0rek = new string[12]
	{
		"101011", "1101011", "1001011", "1100101", "1011011", "1101101", "1001101", "1010011", "1101001", "110101",
		"101101", "1011001"
	};

	private string z0eek()
	{
		base.z0rek = null;
		if (!z0eek(z0tek.Replace("-", string.Empty)))
		{
			base.z0rek = z0ZzZziok.z0quk();
			return null;
		}
		int num = 1;
		int num2 = 0;
		string text = z0tek;
		for (int num3 = z0tek.Length - 1; num3 >= 0; num3--)
		{
			if (num == 10)
			{
				num = 1;
			}
			num2 = ((z0tek[num3] == '-') ? (num2 + 10 * num++) : (num2 + int.Parse(z0tek[num3].ToString()) * num++));
		}
		text += num2 % 11;
		if (z0tek.Length >= 1)
		{
			num = 1;
			int num4 = 0;
			for (int num5 = text.Length - 1; num5 >= 0; num5--)
			{
				if (num == 9)
				{
					num = 1;
				}
				num4 = ((text[num5] == '-') ? (num4 + 10 * num++) : (num4 + int.Parse(text[num5].ToString()) * num++));
			}
			text += num4 % 11;
		}
		string text2 = "0";
		string text3 = z0rek[11] + text2;
		string text4 = text;
		for (int i = 0; i < text4.Length; i++)
		{
			char c = text4[i];
			int num6 = ((c == '-') ? 10 : int.Parse(c.ToString()));
			text3 += z0rek[num6];
			text3 += text2;
		}
		return text3 + z0rek[11];
	}

	public override string z0nwk()
	{
		return z0eek();
	}

	public z0ZzZzyrk(string p0)
	{
		z0tek = p0;
	}
}
