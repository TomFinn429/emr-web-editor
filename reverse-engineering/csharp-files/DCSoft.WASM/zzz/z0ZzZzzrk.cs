namespace zzz;

internal class z0ZzZzzrk : z0ZzZzerk
{
	private new static readonly string[] z0rek = new string[10] { "11101010101110", "10111010101110", "11101110101010", "10101110101110", "11101011101010", "10111011101010", "10101011101110", "10101110111010", "11101010111010", "10111010111010" };

	public z0ZzZzzrk(string p0)
	{
		z0tek = p0;
	}

	public override string z0nwk()
	{
		return z0eek();
	}

	private string z0eek()
	{
		base.z0rek = null;
		if (!z0eek(z0tek))
		{
			base.z0rek = z0ZzZziok.z0wtk();
			return null;
		}
		string text = "11011010";
		string text2 = z0tek;
		foreach (char c in text2)
		{
			text += z0rek[int.Parse(c.ToString())];
		}
		return text + "1101011";
	}
}
