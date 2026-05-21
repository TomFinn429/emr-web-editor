namespace zzz;

internal class z0ZzZzhtk : z0ZzZzerk
{
	private new static readonly string[] z0rek = new string[10] { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };

	private new static readonly string[] z0tek = new string[10] { "bbaaa", "babaa", "baaba", "baaab", "abbaa", "aabba", "aaabb", "ababa", "abaab", "aabab" };

	private static readonly string[] z0yek = new string[10] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };

	private string z0eek()
	{
		base.z0rek = null;
		if (base.z0tek.Length != 5 || !z0eek(base.z0tek))
		{
			base.z0rek = z0ZzZziok.z0uuk();
			return null;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i <= 4; i += 2)
		{
			num2 += int.Parse(base.z0tek.Substring(i, 1)) * 3;
		}
		for (int j = 1; j < 4; j += 2)
		{
			num += int.Parse(base.z0tek.Substring(j, 1)) * 9;
		}
		int num3 = (num + num2) % 10;
		string obj = z0tek[num3];
		string text = string.Empty;
		int num4 = 0;
		string text2 = obj;
		foreach (char c in text2)
		{
			text = ((num4 != 0) ? (text + "01") : (text + "1011"));
			switch (c)
			{
			case 'a':
				text += z0yek[int.Parse(base.z0tek[num4].ToString())];
				break;
			case 'b':
				text += z0rek[int.Parse(base.z0tek[num4].ToString())];
				break;
			}
			num4++;
		}
		return text;
	}

	public override string z0nwk()
	{
		return z0eek();
	}

	public z0ZzZzhtk(string p0)
	{
		base.z0tek = p0;
	}
}
