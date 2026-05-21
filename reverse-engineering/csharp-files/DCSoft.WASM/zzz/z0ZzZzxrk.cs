using System;

namespace zzz;

internal class z0ZzZzxrk : z0ZzZzerk
{
	private new static readonly string[] z0rek = new string[10] { "11000", "00011", "00101", "00110", "01001", "01010", "01100", "10001", "10010", "10100" };

	public override string z0nwk()
	{
		return z0eek();
	}

	private string z0eek()
	{
		base.z0rek = null;
		z0tek = z0tek.Replace("-", string.Empty);
		switch (z0tek.Length)
		{
		default:
			base.z0rek = z0ZzZziok.z0ouk();
			return null;
		case 5:
		case 6:
		case 9:
		case 11:
		{
			string text = "1";
			int num = 0;
			string text2 = z0tek;
			foreach (char c in text2)
			{
				try
				{
					int num2 = "0123456789".IndexOf(c);
					if (num2 < 0)
					{
						base.z0rek = z0ZzZziok.z0ouk();
						return null;
					}
					text += z0rek[num2];
					num += num2;
				}
				catch (Exception ex)
				{
					base.z0rek = z0ZzZziok.z0ouk() + "->" + ex.Message;
					return null;
				}
			}
			int num3 = num % 10;
			int num4 = 10 - ((num3 == 0) ? 10 : num3);
			text += z0rek[num4];
			return text + "1";
		}
		}
	}

	public z0ZzZzxrk(string p0)
	{
		z0tek = p0;
	}
}
