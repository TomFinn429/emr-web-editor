using System.Collections;

namespace zzz;

internal class z0ZzZzprk : z0ZzZzerk
{
	private new static readonly string[] z0tek = new string[10] { "aaaaaa", "aababb", "aabbab", "aabbba", "abaabb", "abbaab", "abbbaa", "ababab", "ababba", "abbaba" };

	private static readonly string[] z0yek = new string[10] { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };

	private static readonly string[] z0uek = new string[10] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };

	private static Hashtable z0iek = null;

	private string z0oek = "N/A";

	private static readonly string[] z0pek = new string[10] { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };

	public z0ZzZzprk(string p0)
	{
		base.z0tek = p0;
	}

	private void z0eek()
	{
		if (z0iek == null)
		{
			z0iek = new Hashtable();
			z0iek.Add("00", "US / CANADA");
			z0iek.Add("01", "US / CANADA");
			z0iek.Add("02", "US / CANADA");
			z0iek.Add("03", "US / CANADA");
			z0iek.Add("04", "US / CANADA");
			z0iek.Add("05", "US / CANADA");
			z0iek.Add("06", "US / CANADA");
			z0iek.Add("07", "US / CANADA");
			z0iek.Add("08", "US / CANADA");
			z0iek.Add("09", "US / CANADA");
			z0iek.Add("10", "US / CANADA");
			z0iek.Add("11", "US / CANADA");
			z0iek.Add("12", "US / CANADA");
			z0iek.Add("13", "US / CANADA");
			z0iek.Add("20", "IN STORE");
			z0iek.Add("21", "IN STORE");
			z0iek.Add("22", "IN STORE");
			z0iek.Add("23", "IN STORE");
			z0iek.Add("24", "IN STORE");
			z0iek.Add("25", "IN STORE");
			z0iek.Add("26", "IN STORE");
			z0iek.Add("27", "IN STORE");
			z0iek.Add("28", "IN STORE");
			z0iek.Add("29", "IN STORE");
			z0iek.Add("30", "FRANCE");
			z0iek.Add("31", "FRANCE");
			z0iek.Add("32", "FRANCE");
			z0iek.Add("33", "FRANCE");
			z0iek.Add("34", "FRANCE");
			z0iek.Add("35", "FRANCE");
			z0iek.Add("36", "FRANCE");
			z0iek.Add("37", "FRANCE");
			z0iek.Add("40", "GERMANY");
			z0iek.Add("41", "GERMANY");
			z0iek.Add("42", "GERMANY");
			z0iek.Add("43", "GERMANY");
			z0iek.Add("44", "GERMANY");
			z0iek.Add("45", "JAPAN");
			z0iek.Add("46", "RUSSIAN FEDERATION");
			z0iek.Add("49", "JAPAN (JAN-13)");
			z0iek.Add("50", "UNITED KINGDOM");
			z0iek.Add("54", "BELGIUM / LUXEMBOURG");
			z0iek.Add("57", "DENMARK");
			z0iek.Add("64", "FINLAND");
			z0iek.Add("70", "NORWAY");
			z0iek.Add("73", "SWEDEN");
			z0iek.Add("76", "SWITZERLAND");
			z0iek.Add("80", "ITALY");
			z0iek.Add("81", "ITALY");
			z0iek.Add("82", "ITALY");
			z0iek.Add("83", "ITALY");
			z0iek.Add("84", "SPAIN");
			z0iek.Add("87", "NETHERLANDS");
			z0iek.Add("90", "AUSTRIA");
			z0iek.Add("91", "AUSTRIA");
			z0iek.Add("93", "AUSTRALIA");
			z0iek.Add("94", "NEW ZEALAND");
			z0iek.Add("99", "COUPONS");
			z0iek.Add("380", "BULGARIA");
			z0iek.Add("383", "SLOVENIJA");
			z0iek.Add("385", "CROATIA");
			z0iek.Add("387", "BOSNIA-HERZEGOVINA");
			z0iek.Add("460", "RUSSIA");
			z0iek.Add("461", "RUSSIA");
			z0iek.Add("462", "RUSSIA");
			z0iek.Add("463", "RUSSIA");
			z0iek.Add("464", "RUSSIA");
			z0iek.Add("465", "RUSSIA");
			z0iek.Add("466", "RUSSIA");
			z0iek.Add("467", "RUSSIA");
			z0iek.Add("468", "RUSSIA");
			z0iek.Add("469", "RUSSIA");
			z0iek.Add("471", "TAIWAN");
			z0iek.Add("474", "ESTONIA");
			z0iek.Add("475", "LATVIA");
			z0iek.Add("477", "LITHUANIA");
			z0iek.Add("479", "SRI LANKA");
			z0iek.Add("480", "PHILIPPINES");
			z0iek.Add("482", "UKRAINE");
			z0iek.Add("484", "MOLDOVA");
			z0iek.Add("485", "ARMENIA");
			z0iek.Add("486", "GEORGIA");
			z0iek.Add("487", "KAZAKHSTAN");
			z0iek.Add("489", "HONG KONG");
			z0iek.Add("520", "GREECE");
			z0iek.Add("528", "LEBANON");
			z0iek.Add("529", "CYPRUS");
			z0iek.Add("531", "MACEDONIA");
			z0iek.Add("535", "MALTA");
			z0iek.Add("539", "IRELAND");
			z0iek.Add("560", "PORTUGAL");
			z0iek.Add("569", "ICELAND");
			z0iek.Add("590", "POLAND");
			z0iek.Add("594", "ROMANIA");
			z0iek.Add("599", "HUNGARY");
			z0iek.Add("600", "SOUTH AFRICA");
			z0iek.Add("601", "SOUTH AFRICA");
			z0iek.Add("609", "MAURITIUS");
			z0iek.Add("611", "MOROCCO");
			z0iek.Add("613", "ALGERIA");
			z0iek.Add("619", "TUNISIA");
			z0iek.Add("622", "EGYPT");
			z0iek.Add("625", "JORDAN");
			z0iek.Add("626", "IRAN");
			z0iek.Add("627", "KUWAIT");
			z0iek.Add("628", "SAUDI ARABIA");
			z0iek.Add("629", "EMIRATES");
			z0iek.Add("690", "CHINA");
			z0iek.Add("691", "CHINA");
			z0iek.Add("692", "CHINA");
			z0iek.Add("693", "CHINA");
			z0iek.Add("694", "CHINA");
			z0iek.Add("695", "CHINA");
			z0iek.Add("729", "ISRAEL");
			z0iek.Add("740", "GUATEMALA");
			z0iek.Add("741", "EL SALVADOR");
			z0iek.Add("742", "HONDURAS");
			z0iek.Add("743", "NICARAGUA");
			z0iek.Add("744", "COSTA RICA");
			z0iek.Add("746", "DOMINICAN REPUBLIC");
			z0iek.Add("750", "MEXICO");
			z0iek.Add("759", "VENEZUELA");
			z0iek.Add("770", "COLOMBIA");
			z0iek.Add("773", "URUGUAY");
			z0iek.Add("775", "PERU");
			z0iek.Add("777", "BOLIVIA");
			z0iek.Add("779", "ARGENTINA");
			z0iek.Add("780", "CHILE");
			z0iek.Add("784", "PARAGUAY");
			z0iek.Add("785", "PERU");
			z0iek.Add("786", "ECUADOR");
			z0iek.Add("789", "BRAZIL");
			z0iek.Add("850", "CUBA");
			z0iek.Add("858", "SLOVAKIA");
			z0iek.Add("859", "CZECH REPUBLIC");
			z0iek.Add("860", "YUGLOSLAVIA");
			z0iek.Add("867", "NORTH KOREA");
			z0iek.Add("869", "TURKEY");
			z0iek.Add("880", "SOUTH KOREA");
			z0iek.Add("885", "THAILAND");
			z0iek.Add("888", "SINGAPORE");
			z0iek.Add("890", "INDIA");
			z0iek.Add("893", "VIETNAM");
			z0iek.Add("899", "INDONESIA");
			z0iek.Add("955", "MALAYSIA");
			z0iek.Add("958", "MACAU");
			z0iek.Add("977", "INTERNATIONAL STANDARD SERIAL NUMBER FOR PERIODICALS (ISSN)");
			z0iek.Add("978", "INTERNATIONAL STANDARD BOOK NUMBERING (ISBN)");
			z0iek.Add("979", "INTERNATIONAL STANDARD MUSIC NUMBER (ISMN)");
			z0iek.Add("980", "REFUND RECEIPTS");
			z0iek.Add("981", "COMMON CURRENCY COUPONS");
			z0iek.Add("982", "COMMON CURRENCY COUPONS");
		}
	}

	private new string z0rek()
	{
		base.z0rek = null;
		if (base.z0tek.Length < 12 || base.z0tek.Length > 13)
		{
			base.z0rek = z0ZzZziok.z0cek();
			return null;
		}
		if (!z0eek(base.z0tek))
		{
			base.z0rek = z0ZzZziok.z0cek();
			return null;
		}
		string text = z0tek[int.Parse(base.z0tek[0].ToString())];
		string text2 = "101";
		int i;
		for (i = 0; i < 6; i++)
		{
			if (text[i] == 'a')
			{
				text2 += z0uek[int.Parse(base.z0tek[i + 1].ToString())];
			}
			if (text[i] == 'b')
			{
				text2 += z0yek[int.Parse(base.z0tek[i + 1].ToString())];
			}
		}
		text2 += "01010";
		i = 1;
		while (i <= 5)
		{
			text2 += z0pek[int.Parse(base.z0tek[i++ + 6].ToString())];
		}
		int num = int.Parse(base.z0tek[base.z0tek.Length - 1].ToString());
		if (base.z0tek.Length == 12)
		{
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j <= 10; j += 2)
			{
				num3 += int.Parse(base.z0tek.Substring(j, 1));
			}
			for (int k = 1; k <= 11; k += 2)
			{
				num2 += int.Parse(base.z0tek.Substring(k, 1)) * 3;
			}
			num = (num2 + num3) % 10;
			num = 10 - num;
			if (num == 10)
			{
				num = 0;
			}
			base.z0tek += num;
		}
		text2 += z0pek[num];
		text2 += "101";
		z0eek();
		z0oek = "N/A";
		string text3 = base.z0tek.Substring(0, 2);
		string text4 = base.z0tek.Substring(0, 3);
		if (z0iek.ContainsKey(text4))
		{
			z0oek = z0iek[text4].ToString();
		}
		else
		{
			if (!z0iek.ContainsKey(text3))
			{
				base.z0rek = z0ZzZziok.z0trk();
				return null;
			}
			z0oek = z0iek[text3].ToString();
		}
		return text2;
	}

	public override string z0nwk()
	{
		return z0rek();
	}
}
