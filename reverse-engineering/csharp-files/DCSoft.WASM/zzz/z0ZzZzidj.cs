using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzidj : z0ZzZzodj
{
	private new readonly float z0tek;

	private new readonly string[] z0yek;

	private new static string[] z0uek = null;

	internal new static readonly string z0iek = "post";

	private new static void z0eek()
	{
		if (z0uek == null)
		{
			z0uek = new string[258]
			{
				".notdef", "Null", "nonmarkingreturn", "space", "exclam", "quotedbl", "numbersign", "dollar", "percent", "ampersand",
				"quotesingle", "parenleft", "parenright", "asterisk", "plus", "comma", "hyphen", "period", "slash", "zero",
				"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "colon",
				"semicolon", "less", "equal", "greater", "question", "at", "A", "B", "C", "D",
				"E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
				"O", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
				"Y", "Z", "bracketleft", "backslash", "bracketright", "asciicircum", "underscore", "grave", "a", "b",
				"c", "d", "e", "f", "g", "h", "i", "j", "k", "l",
				"m", "n", "o", "p", "q", "r", "s", "t", "u", "v",
				"w", "x", "y", "z", "braceleft", "bar", "braceright", "asciitilde", "Adieresis", "Aring",
				"Ccedilla", "Eacute", "Ntilde", "Odieresis", "Udieresis", "aacute", "agrave", "acircumflex", "adieresis", "atilde",
				"aring", "ccedilla", "eacute", "egrave", "ecircumflex", "edieresis", "iacute", "igrave", "icircumflex", "idieresis",
				"ntilde", "oacute", "ograve", "ocircumflex", "odieresis", "otilde", "uacute", "ugrave", "ucircumflex", "udieresis",
				"dagger", "degree", "cent", "sterling", "section", "bullet", "paragraph", "germandbls", "registered", "copyright",
				"trademark", "acute", "dieresis", "notequal", "AE", "Oslash", "infinity", "plusminus", "lessequal", "greaterequal",
				"yen", "mu", "partialdiff", "summation", "product", "pi", "integral", "ordfeminine", "ordmasculine", "Omega",
				"ae", "oslash", "questiondown", "exclamdown", "logicalnot", "radical", "florin", "approxequal", "increment", "guillemotleft",
				"guillemotright", "ellipsis", "nonbreakingspace", "Agrave", "Atilde", "Otilde", "OE", "oe", "endash", "emdash",
				"quotedblleft", "quotedblright", "quoteleft", "quoteright", "divide", "lozenge", "ydieresis", "Ydieresis", "fraction", "currency",
				"guilsinglleft", "guilsinglright", "fi", "fl", "daggerdbl", "periodcentered", "quotesinglbase", "quotedblbase", "perthousand", "Acircumflex",
				"Ecircumflex", "Aacute", "Edieresis", "Egrave", "Iacute", "Icircumflex", "Idieresis", "Igrave", "Oacute", "Ocircumflex",
				"apple", "Ograve", "Uacute", "Ucircumflex", "Ugrave", "dotlessi", "circumflex", "tilde", "macron", "breve",
				"dotaccent", "ring", "cedilla", "hungarumlaut", "ogonek", "caron", "Lslash", "lslash", "Scaron", "scaron",
				"Zcaron", "zcaron", "brokenbar", "Eth", "eth", "Yacute", "yacute", "Thorn", "thorn", "minus",
				"multiply", "onesuperior", "twosuperior", "threesuperior", "onehalf", "onequarter", "threequarters", "franc", "Gbreve", "gbreve",
				"Idotaccent", "Scedilla", "scedilla", "Cacute", "cacute", "Ccaron", "ccaron", "dcroat"
			};
		}
	}

	internal new float z0rek()
	{
		return z0tek;
	}

	internal z0ZzZzidj(z0ZzZzjgj p0)
		: base(z0iek, p0)
	{
		z0ZzZzjgj z0ZzZzjgj2 = z0uek();
		int num = z0ZzZzjgj2.z0nek();
		z0tek = z0ZzZzjgj2.z0iek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0yek();
		z0ZzZzjgj2.z0nek();
		z0ZzZzjgj2.z0nek();
		z0ZzZzjgj2.z0nek();
		z0ZzZzjgj2.z0nek();
		z0ZzZzjgj2.z0nek();
		switch (num)
		{
		case 65536:
			z0eek();
			z0yek = z0uek;
			break;
		case 131072:
		{
			z0eek();
			int num2 = p0.z0mek();
			if (p0.z0mek() <= 32)
			{
				break;
			}
			int num3 = z0ZzZzjgj2.z0rek();
			short[] array = z0ZzZzjgj2.z0uek(num3);
			List<string> list = new List<string>();
			while (z0ZzZzjgj2.z0uek() < num2)
			{
				list.Add(z0ZzZzjgj2.z0iek(z0ZzZzjgj2.z0tek()));
			}
			int count = list.Count;
			int num4 = z0uek.Length;
			z0yek = new string[num3];
			for (int i = 0; i < num3; i++)
			{
				short num5 = array[i];
				if (num5 >= 0 && num5 < num4)
				{
					z0yek[i] = z0uek[num5];
					continue;
				}
				short num6 = (short)(num5 - num4);
				z0yek[i] = ((num6 >= 0 && num6 < count) ? list[num6] : ".notdef");
			}
			break;
		}
		}
	}
}
