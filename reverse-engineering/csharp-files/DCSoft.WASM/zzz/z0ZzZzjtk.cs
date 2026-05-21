namespace zzz;

internal class z0ZzZzjtk : z0ZzZzerk
{
	private new static readonly string[] z0rek = new string[10] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };

	private new static readonly string[] z0tek = new string[4] { "aa", "ab", "ba", "bb" };

	private static readonly string[] z0yek = new string[10] { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };

	public z0ZzZzjtk(string p0)
	{
		base.z0tek = p0;
	}

	public override string z0nwk()
	{
		return z0eek();
	}

	private string z0eek()
	{
		base.z0rek = null;
		if (base.z0tek.Length != 2 || !z0eek(base.z0tek))
		{
			base.z0rek = z0ZzZziok.z0mtk();
			return null;
		}
		string empty = string.Empty;
		try
		{
			empty = z0tek[int.Parse(base.z0tek.Trim()) % 4];
		}
		catch
		{
			base.z0rek = z0ZzZziok.z0mtk();
			return null;
		}
		string text = "1011";
		int num = 0;
		string text2 = empty;
		for (int i = 0; i < text2.Length; i++)
		{
			switch (text2[i])
			{
			case 'a':
				text += z0rek[int.Parse(base.z0tek[num].ToString())];
				break;
			case 'b':
				text += z0yek[int.Parse(base.z0tek[num].ToString())];
				break;
			}
			if (num++ == 0)
			{
				text += "01";
			}
		}
		return text;
	}
}
