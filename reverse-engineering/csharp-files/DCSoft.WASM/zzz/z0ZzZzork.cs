using System.Text;

namespace zzz;

internal class z0ZzZzork : z0ZzZzerk
{
	private new static string[] z0rek = new string[49]
	{
		"bsssbsbss", "bsbssbsss", "bsbsssbss", "bsbssssbs", "bssbsbsss", "bssbssbss", "bssbsssbs", "bsbsbssss", "bsssbssbs", "bssssbsbs",
		"bbsbsbsss", "bbsbssbss", "bbsbsssbs", "bbssbsbss", "bbssbssbs", "bbsssbsbs", "bsbbsbsss", "bsbbssbss", "bsbbsssbs", "bssbbsbss",
		"bsssbbsbs", "bsbsbbsss", "bsbssbbss", "bsbsssbbs", "bssbsbbss", "bsssbsbbs", "bbsbbsbss", "bbsbbssbs", "bbsbsbbss", "bbsbssbbs",
		"bbssbsbbs", "bbssbbsbs", "bsbbsbbss", "bsbbssbbs", "bssbbsbbs", "bssbbbsbs", "bssbsbbbs", "bbbsbsbss", "bbbsbssbs", "bbbssbsbs",
		"bsbbsbbbs", "bsbbbsbbs", "bbsbsbbbs", "bssbssbbs", "bbbsbbsbs", "bbbsbsbbs", "bssbbssbs", "bsbsbbbbs", "bsbsbbbbsb"
	};

	private new static readonly string z0tek = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%!@#$";

	private void z0eek(string p0, StringBuilder p1)
	{
		bool flag = true;
		for (int i = 0; i < p0.Length; i++)
		{
			if (p0[i] == 'b')
			{
				p1.Append("1");
			}
			else
			{
				p1.Append("0");
			}
			flag = !flag;
		}
	}

	public z0ZzZzork(string p0)
	{
		base.z0tek = p0;
	}

	public override string z0nwk()
	{
		base.z0rek = null;
		StringBuilder stringBuilder = new StringBuilder();
		string text = base.z0tek;
		text = text.ToUpper();
		z0eek(z0rek[47], stringBuilder);
		string text2 = text;
		foreach (char c in text2)
		{
			int num = z0tek.IndexOf(c);
			if (num < 0)
			{
				base.z0rek = z0ZzZziok.z0xok();
				return null;
			}
			z0eek(z0rek[num], stringBuilder);
		}
		int num2 = 0;
		int num3 = text.Length;
		text2 = text;
		foreach (char c2 in text2)
		{
			num2 += z0tek.IndexOf(c2) * num3;
			num3--;
		}
		num2 %= 47;
		z0eek(z0rek[num2], stringBuilder);
		num3 = text.Length + 1;
		text2 = text;
		foreach (char c3 in text2)
		{
			num2 += z0tek.IndexOf(c3) * num3;
			num3--;
		}
		num2 %= 47;
		z0eek(z0rek[num2], stringBuilder);
		z0eek(z0rek[48], stringBuilder);
		return stringBuilder.ToString();
	}
}
