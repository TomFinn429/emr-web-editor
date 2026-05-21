namespace zzz;

internal class z0ZzZzktk : z0ZzZzerk
{
	private new static readonly string[] z0rek = new string[10] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };

	private new static readonly string[] z0tek = new string[10] { "aaabbb", "aababb", "aabbab", "aabbba", "abaabb", "abbaab", "abbbaa", "ababab", "ababba", "abbaba" };

	private static readonly string[] z0yek = new string[10] { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };

	private static readonly string[] z0uek = new string[10] { "bbbaaa", "bbabaa", "bbaaba", "bbaaab", "babbaa", "baabba", "baaabb", "bababa", "babaab", "baabab" };

	public override string z0nwk()
	{
		return z0eek();
	}

	public z0ZzZzktk(string p0)
	{
		base.z0tek = p0;
	}

	private string z0eek()
	{
		base.z0rek = null;
		if (base.z0tek.Length != 8 && base.z0tek.Length != 12)
		{
			base.z0rek = z0ZzZziok.z0nrk();
			return null;
		}
		if (!z0eek(base.z0tek))
		{
			base.z0rek = z0ZzZziok.z0nrk();
			return null;
		}
		int num = int.Parse(base.z0tek[base.z0tek.Length - 1].ToString());
		int num2 = int.Parse(base.z0tek[0].ToString());
		if (base.z0tek.Length == 12)
		{
			string empty = string.Empty;
			string text = base.z0tek.Substring(1, 5);
			string text2 = base.z0tek.Substring(6, 5);
			if (num2 != 0 && num2 != 1)
			{
				base.z0rek = z0ZzZziok.z0nrk();
				return null;
			}
			if (text.EndsWith("000") || text.EndsWith("100") || (text.EndsWith("200") && int.Parse(text2) <= 999))
			{
				empty += text.Substring(0, 2);
				empty += text2.Substring(2, 3);
				empty += text[2];
			}
			else if (text.EndsWith("00") && int.Parse(text2) <= 99)
			{
				empty += text.Substring(0, 3);
				empty += text2.Substring(3, 2);
				empty += "3";
			}
			else if (text.EndsWith("0") && int.Parse(text2) <= 9)
			{
				empty += text.Substring(0, 4);
				empty += text2[4];
				empty += "4";
			}
			else
			{
				if (text.EndsWith("0") || int.Parse(text2) > 9 || int.Parse(text2) < 5)
				{
					base.z0rek = z0ZzZziok.z0nrk();
					return null;
				}
				empty += text;
				empty += text2[4];
			}
			base.z0tek = empty;
		}
		string empty2 = string.Empty;
		empty2 = ((num2 != 0) ? z0tek[num] : z0uek[num]);
		string text3 = "101";
		int num3 = 0;
		string text4 = empty2;
		foreach (char c in text4)
		{
			int num4 = int.Parse(base.z0tek[num3++].ToString());
			switch (c)
			{
			case 'a':
				text3 += z0rek[num4];
				break;
			case 'b':
				text3 += z0yek[num4];
				break;
			}
		}
		text3 += "01010";
		return text3 + "1";
	}
}
