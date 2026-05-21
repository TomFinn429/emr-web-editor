using System.Collections;
using System.Text;

namespace zzz;

internal class z0ZzZztrk : z0ZzZzerk
{
	private new static Hashtable z0tek;

	public override string z0nwk()
	{
		return z0eek();
	}

	public z0ZzZztrk(string p0)
	{
		base.z0tek = p0;
	}

	private string z0eek()
	{
		base.z0rek = null;
		if (base.z0tek.Length < 2)
		{
			base.z0rek = z0ZzZziok.z0frk();
			return null;
		}
		switch (base.z0tek[0].ToString().ToUpper().Trim())
		{
		default:
			base.z0rek = z0ZzZziok.z0frk();
			return null;
		case "A":
		case "B":
		case "C":
		case "D":
			switch (base.z0tek[base.z0tek.Trim().Length - 1].ToString().ToUpper().Trim())
			{
			default:
				base.z0rek = z0ZzZziok.z0frk();
				return null;
			case "A":
			case "B":
			case "C":
			case "D":
			{
				StringBuilder stringBuilder = new StringBuilder();
				z0rek();
				string text = base.z0tek;
				foreach (char c in text)
				{
					stringBuilder.Append(z0tek[c].ToString());
					stringBuilder.Append("0");
				}
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				return stringBuilder.ToString();
			}
			}
		}
	}

	private new void z0rek()
	{
		if (z0tek == null)
		{
			z0tek = new Hashtable();
			z0tek.Add('0', "101010011");
			z0tek.Add('1', "101011001");
			z0tek.Add('2', "101001011");
			z0tek.Add('3', "110010101");
			z0tek.Add('4', "101101001");
			z0tek.Add('5', "110101001");
			z0tek.Add('6', "100101011");
			z0tek.Add('7', "100101101");
			z0tek.Add('8', "100110101");
			z0tek.Add('9', "110100101");
			z0tek.Add('-', "101001101");
			z0tek.Add('$', "101100101");
			z0tek.Add(':', "1101011011");
			z0tek.Add('/', "1101101011");
			z0tek.Add('.', "1101101101");
			z0tek.Add('+', "101100110011");
			z0tek.Add('A', "1011001001");
			z0tek.Add('B', "1010010011");
			z0tek.Add('C', "1001001011");
			z0tek.Add('D', "1010011001");
			z0tek.Add('a', "1011001001");
			z0tek.Add('b', "1010010011");
			z0tek.Add('c', "1001001011");
			z0tek.Add('d', "1010011001");
		}
	}
}
