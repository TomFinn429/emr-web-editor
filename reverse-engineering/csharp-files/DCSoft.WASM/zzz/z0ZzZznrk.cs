using System;

namespace zzz;

internal class z0ZzZznrk : z0ZzZzerk
{
	private new static readonly string[] z0rek = new string[10] { "NNWWN", "WNNNW", "NWNNW", "WWNNN", "NNWNW", "WNWNN", "NWWNN", "NNNWW", "WNNWN", "NWNWN" };

	public override string z0nwk()
	{
		return z0eek();
	}

	public z0ZzZznrk(string p0)
	{
		z0tek = p0;
	}

	private string z0eek()
	{
		base.z0rek = null;
		if (z0tek.Length % 2 != 0)
		{
			base.z0rek = z0ZzZziok.z0zik();
			return null;
		}
		if (!z0eek(z0tek))
		{
			base.z0rek = z0ZzZziok.z0zik();
			return null;
		}
		string text = "1010";
		for (int i = 0; i < z0tek.Length; i += 2)
		{
			bool flag = true;
			string[] array = z0rek;
			char c = z0tek[i];
			string text2 = array[int.Parse(c.ToString())];
			string[] array2 = z0rek;
			c = z0tek[i + 1];
			string text3 = array2[int.Parse(c.ToString())];
			string text4 = string.Empty;
			while (text2.Length > 0)
			{
				ReadOnlySpan<char> readOnlySpan = text4;
				c = text2[0];
				text4 = string.Concat(readOnlySpan, new ReadOnlySpan<char>(in c), new ReadOnlySpan<char>(text3[0]));
				text2 = text2.Substring(1);
				text3 = text3.Substring(1);
			}
			string text5 = text4;
			foreach (char c2 in text5)
			{
				text = ((!flag) ? ((c2 != 'N') ? (text + "00") : (text + "0")) : ((c2 != 'N') ? (text + "11") : (text + "1")));
				flag = !flag;
			}
		}
		return text + "1101";
	}
}
