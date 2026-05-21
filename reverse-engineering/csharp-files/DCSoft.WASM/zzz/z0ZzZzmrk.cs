namespace zzz;

internal class z0ZzZzmrk : z0ZzZzerk
{
	private new static readonly string[] z0rek = new string[10] { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };

	private new static readonly string[] z0tek = new string[10] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };

	private string z0eek()
	{
		base.z0rek = null;
		if (base.z0tek.Length != 8 && base.z0tek.Length != 7)
		{
			base.z0rek = z0ZzZziok.z0ruk();
			return null;
		}
		if (!z0eek(base.z0tek))
		{
			base.z0rek = z0ZzZziok.z0ruk();
			return null;
		}
		int num = 0;
		if (base.z0tek.Length == 7)
		{
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i <= 6; i += 2)
			{
				num3 += int.Parse(base.z0tek.Substring(i, 1)) * 3;
			}
			for (int j = 1; j <= 5; j += 2)
			{
				num2 += int.Parse(base.z0tek.Substring(j, 1));
			}
			num = (num2 + num3) % 10;
			num = 10 - num;
			if (num == 10)
			{
				num = 0;
			}
			base.z0tek += num;
		}
		string text = "101";
		for (int k = 0; k < base.z0tek.Length / 2; k++)
		{
			text += z0tek[int.Parse(base.z0tek[k].ToString())];
		}
		text += "01010";
		for (int l = base.z0tek.Length / 2; l < base.z0tek.Length; l++)
		{
			text += z0rek[int.Parse(base.z0tek[l].ToString())];
		}
		return text + "101";
	}

	public z0ZzZzmrk(string p0)
	{
		base.z0tek = p0;
	}

	public override string z0nwk()
	{
		return z0eek();
	}
}
