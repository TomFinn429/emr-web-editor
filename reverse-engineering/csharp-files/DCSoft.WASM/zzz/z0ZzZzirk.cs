using System;
using System.Collections;
using System.Text;

namespace zzz;

internal class z0ZzZzirk : z0ZzZzerk
{
	private bool z0yek;

	private static Hashtable z0uek;

	private static Hashtable z0iek;

	private void z0eek()
	{
		if (z0iek == null)
		{
			z0iek = new Hashtable();
			z0iek.Add(Convert.ToChar(0).ToString(), "%U");
			z0iek.Add(Convert.ToChar(1).ToString(), "$A");
			z0iek.Add(Convert.ToChar(2).ToString(), "$B");
			z0iek.Add(Convert.ToChar(3).ToString(), "$C");
			z0iek.Add(Convert.ToChar(4).ToString(), "$D");
			z0iek.Add(Convert.ToChar(5).ToString(), "$E");
			z0iek.Add(Convert.ToChar(6).ToString(), "$F");
			z0iek.Add(Convert.ToChar(7).ToString(), "$G");
			z0iek.Add(Convert.ToChar(8).ToString(), "$H");
			z0iek.Add(Convert.ToChar(9).ToString(), "$I");
			z0iek.Add(Convert.ToChar(10).ToString(), "$J");
			z0iek.Add(Convert.ToChar(11).ToString(), "$K");
			z0iek.Add(Convert.ToChar(12).ToString(), "$L");
			z0iek.Add(Convert.ToChar(13).ToString(), "$M");
			z0iek.Add(Convert.ToChar(14).ToString(), "$N");
			z0iek.Add(Convert.ToChar(15).ToString(), "$O");
			z0iek.Add(Convert.ToChar(16).ToString(), "$P");
			z0iek.Add(Convert.ToChar(17).ToString(), "$Q");
			z0iek.Add(Convert.ToChar(18).ToString(), "$R");
			z0iek.Add(Convert.ToChar(19).ToString(), "$S");
			z0iek.Add(Convert.ToChar(20).ToString(), "$T");
			z0iek.Add(Convert.ToChar(21).ToString(), "$U");
			z0iek.Add(Convert.ToChar(22).ToString(), "$V");
			z0iek.Add(Convert.ToChar(23).ToString(), "$W");
			z0iek.Add(Convert.ToChar(24).ToString(), "$X");
			z0iek.Add(Convert.ToChar(25).ToString(), "$Y");
			z0iek.Add(Convert.ToChar(26).ToString(), "$Z");
			z0iek.Add(Convert.ToChar(27).ToString(), "%A");
			z0iek.Add(Convert.ToChar(28).ToString(), "%B");
			z0iek.Add(Convert.ToChar(29).ToString(), "%C");
			z0iek.Add(Convert.ToChar(30).ToString(), "%D");
			z0iek.Add(Convert.ToChar(31).ToString(), "%E");
			z0iek.Add("!", "/A");
			z0iek.Add("\"", "/B");
			z0iek.Add("#", "/C");
			z0iek.Add("$", "/D");
			z0iek.Add("%", "/E");
			z0iek.Add("&", "/F");
			z0iek.Add("'", "/G");
			z0iek.Add("(", "/H");
			z0iek.Add(")", "/I");
			z0iek.Add("*", "/J");
			z0iek.Add("+", "/K");
			z0iek.Add(",", "/L");
			z0iek.Add("/", "/O");
			z0iek.Add(":", "/Z");
			z0iek.Add(";", "%F");
			z0iek.Add("<", "%G");
			z0iek.Add("=", "%H");
			z0iek.Add(">", "%I");
			z0iek.Add("?", "%J");
			z0iek.Add("[", "%K");
			z0iek.Add("\\", "%L");
			z0iek.Add("]", "%M");
			z0iek.Add("^", "%N");
			z0iek.Add("_", "%O");
			z0iek.Add("{", "%P");
			z0iek.Add("|", "%Q");
			z0iek.Add("}", "%R");
			z0iek.Add("~", "%S");
			z0iek.Add("`", "%W");
			z0iek.Add("@", "%V");
			z0iek.Add("a", "+A");
			z0iek.Add("b", "+B");
			z0iek.Add("c", "+C");
			z0iek.Add("d", "+D");
			z0iek.Add("e", "+E");
			z0iek.Add("f", "+F");
			z0iek.Add("g", "+G");
			z0iek.Add("h", "+H");
			z0iek.Add("i", "+I");
			z0iek.Add("j", "+J");
			z0iek.Add("k", "+K");
			z0iek.Add("l", "+L");
			z0iek.Add("m", "+M");
			z0iek.Add("n", "+N");
			z0iek.Add("o", "+O");
			z0iek.Add("p", "+P");
			z0iek.Add("q", "+Q");
			z0iek.Add("r", "+R");
			z0iek.Add("s", "+S");
			z0iek.Add("t", "+T");
			z0iek.Add("u", "+U");
			z0iek.Add("v", "+V");
			z0iek.Add("w", "+W");
			z0iek.Add("x", "+X");
			z0iek.Add("y", "+Y");
			z0iek.Add("z", "+Z");
			z0iek.Add(Convert.ToChar(127).ToString(), "%T");
		}
	}

	public z0ZzZzirk(string p0, bool p1)
	{
		base.z0tek = p0;
		z0yek = p1;
	}

	private new string z0rek()
	{
		base.z0rek = null;
		z0tek();
		z0eek();
		string text = base.z0tek;
		if (z0yek)
		{
			text = z0eek(text);
		}
		if (base.z0rek != null)
		{
			return null;
		}
		string text2 = z0uek['*'].ToString();
		text2 += "0";
		string text3 = text;
		foreach (char c in text3)
		{
			if (z0uek.ContainsKey(c))
			{
				text2 += z0uek[c].ToString();
				text2 += "0";
				continue;
			}
			base.z0rek = z0ZzZziok.z0xrk();
			return null;
		}
		return text2 + z0uek['*'].ToString();
	}

	public override string z0nwk()
	{
		return z0rek();
	}

	private new void z0tek()
	{
		if (z0uek == null)
		{
			z0uek = new Hashtable();
			z0uek.Add('0', "101001101101");
			z0uek.Add('1', "110100101011");
			z0uek.Add('2', "101100101011");
			z0uek.Add('3', "110110010101");
			z0uek.Add('4', "101001101011");
			z0uek.Add('5', "110100110101");
			z0uek.Add('6', "101100110101");
			z0uek.Add('7', "101001011011");
			z0uek.Add('8', "110100101101");
			z0uek.Add('9', "101100101101");
			z0uek.Add('A', "110101001011");
			z0uek.Add('B', "101101001011");
			z0uek.Add('C', "110110100101");
			z0uek.Add('D', "101011001011");
			z0uek.Add('E', "110101100101");
			z0uek.Add('F', "101101100101");
			z0uek.Add('G', "101010011011");
			z0uek.Add('H', "110101001101");
			z0uek.Add('I', "101101001101");
			z0uek.Add('J', "101011001101");
			z0uek.Add('K', "110101010011");
			z0uek.Add('L', "101101010011");
			z0uek.Add('M', "110110101001");
			z0uek.Add('N', "101011010011");
			z0uek.Add('O', "110101101001");
			z0uek.Add('P', "101101101001");
			z0uek.Add('Q', "101010110011");
			z0uek.Add('R', "110101011001");
			z0uek.Add('S', "101101011001");
			z0uek.Add('T', "101011011001");
			z0uek.Add('U', "110010101011");
			z0uek.Add('V', "100110101011");
			z0uek.Add('W', "110011010101");
			z0uek.Add('X', "100101101011");
			z0uek.Add('Y', "110010110101");
			z0uek.Add('Z', "100110110101");
			z0uek.Add('-', "100101011011");
			z0uek.Add('.', "110010101101");
			z0uek.Add(' ', "100110101101");
			z0uek.Add('$', "100100100101");
			z0uek.Add('/', "100100101001");
			z0uek.Add('+', "100101001001");
			z0uek.Add('%', "101001001001");
			z0uek.Add('*', "100101101101");
		}
	}

	private new string z0eek(string p0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = base.z0tek;
		for (int i = 0; i < text.Length; i++)
		{
			char c = text[i];
			if (z0uek.ContainsKey(c))
			{
				stringBuilder.Append(c.ToString());
				continue;
			}
			if (z0iek.ContainsKey(c.ToString()))
			{
				stringBuilder.Append(z0iek[c.ToString()].ToString());
				continue;
			}
			base.z0rek = z0ZzZziok.z0xrk();
			return null;
		}
		return stringBuilder.ToString();
	}

	public z0ZzZzirk(string p0)
	{
		base.z0tek = p0;
	}
}
