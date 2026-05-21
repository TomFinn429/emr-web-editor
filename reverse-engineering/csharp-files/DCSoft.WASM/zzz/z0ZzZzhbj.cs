using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

public static class z0ZzZzhbj
{
	private class z0yck : Encoding
	{
		private string z0eek;

		public override string GetString(byte[] bytes)
		{
			if (z0rek == null)
			{
				return Encoding.UTF8.GetString(bytes);
			}
			return z0rek.z0flk(z0eek, bytes);
		}

		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new NotImplementedException();
		}

		public override string GetString(byte[] bytes, int index, int count)
		{
			if (index == 0 && count == bytes.Length)
			{
				return GetString(bytes);
			}
			byte[] array = new byte[count];
			Array.Copy(bytes, index, array, 0, count);
			return GetString(array);
		}

		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new NotImplementedException();
		}

		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new NotImplementedException();
		}

		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new NotImplementedException();
		}

		public override int GetMaxByteCount(int charCount)
		{
			throw new NotImplementedException();
		}

		public override int GetMaxCharCount(int byteCount)
		{
			throw new NotImplementedException();
		}

		public z0yck(string p0)
		{
			z0eek = p0;
		}
	}

	public delegate Encoding z0fnk();

	private static z0ZzZzbnj z0rek;

	public static z0fnk z0tek;

	private static Dictionary<string, Encoding> z0yek;

	private static Dictionary<int, string> z0uek;

	public static z0ZzZzbnj JSProvider => z0rek;

	public static void SetJSProivder(z0ZzZzbnj p)
	{
		if (p != null)
		{
			z0rek = p;
		}
	}

	public static Encoding z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return Encoding.UTF8;
		}
		p0 = p0.Trim().ToLower();
		if (p0 == "gb2312")
		{
			if (z0tek != null)
			{
				return z0tek();
			}
			return null;
		}
		if (z0yek == null)
		{
			z0yek = new Dictionary<string, Encoding>();
			EncodingInfo[] encodings = Encoding.GetEncodings();
			foreach (EncodingInfo encodingInfo in encodings)
			{
				z0yek[encodingInfo.Name.ToLower()] = encodingInfo.GetEncoding();
			}
		}
		Encoding result = null;
		if (z0yek.TryGetValue(p0, out result))
		{
			return result;
		}
		result = new z0yck(p0);
		z0yek[p0] = result;
		return result;
	}

	public static Encoding z0eek(int p0)
	{
		if (p0 == 936)
		{
			if (z0tek != null)
			{
				return z0tek();
			}
			return null;
		}
		if (z0uek == null)
		{
			z0uek = new Dictionary<int, string>
			{
				[37] = "IBM037",
				[437] = "IBM437",
				[500] = "IBM500",
				[708] = "ASMO-708",
				[720] = "DOS-720",
				[737] = "ibm737",
				[775] = "ibm775",
				[850] = "ibm850",
				[852] = "ibm852",
				[855] = "IBM855",
				[857] = "ibm857",
				[858] = "IBM00858",
				[860] = "IBM860",
				[861] = "ibm861",
				[862] = "DOS-862",
				[863] = "IBM863",
				[864] = "IBM864",
				[865] = "IBM865",
				[866] = "cp866",
				[869] = "ibm869",
				[870] = "IBM870",
				[874] = "windows-874",
				[875] = "cp875",
				[932] = "shift_jis",
				[936] = "gb2312",
				[949] = "ks_c_5601-1987",
				[950] = "big5",
				[1026] = "IBM1026",
				[1047] = "IBM01047",
				[1140] = "IBM01140",
				[1141] = "IBM01141",
				[1142] = "IBM01142",
				[1143] = "IBM01143",
				[1144] = "IBM01144",
				[1145] = "IBM01145",
				[1146] = "IBM01146",
				[1147] = "IBM01147",
				[1148] = "IBM01148",
				[1149] = "IBM01149",
				[1200] = "utf-16",
				[1201] = "unicodeFFFE",
				[1250] = "windows-1250",
				[1251] = "windows-1251",
				[1252] = "Windows-1252",
				[1253] = "windows-1253",
				[1254] = "windows-1254",
				[1255] = "windows-1255",
				[1256] = "windows-1256",
				[1257] = "windows-1257",
				[1258] = "windows-1258",
				[1361] = "Johab",
				[10000] = "macintosh",
				[10001] = "x-mac-japanese",
				[10002] = "x-mac-chinesetrad",
				[10003] = "x-mac-korean",
				[10004] = "x-mac-arabic",
				[10005] = "x-mac-hebrew",
				[10006] = "x-mac-greek",
				[10007] = "x-mac-cyrillic",
				[10008] = "x-mac-chinesesimp",
				[10010] = "x-mac-romanian",
				[10017] = "x-mac-ukrainian",
				[10021] = "x-mac-thai",
				[10029] = "x-mac-ce",
				[10079] = "x-mac-icelandic",
				[10081] = "x-mac-turkish",
				[10082] = "x-mac-croatian",
				[12000] = "utf-32",
				[12001] = "utf-32BE",
				[20000] = "x-Chinese-CNS",
				[20001] = "x-cp20001",
				[20002] = "x-Chinese-Eten",
				[20003] = "x-cp20003",
				[20004] = "x-cp20004",
				[20005] = "x-cp20005",
				[20105] = "x-IA5",
				[20106] = "x-IA5-German",
				[20107] = "x-IA5-Swedish",
				[20108] = "x-IA5-Norwegian",
				[20127] = "us-ascii",
				[20261] = "x-cp20261",
				[20269] = "x-cp20269",
				[20273] = "IBM273",
				[20277] = "IBM277",
				[20278] = "IBM278",
				[20280] = "IBM280",
				[20284] = "IBM284",
				[20285] = "IBM285",
				[20290] = "IBM290",
				[20297] = "IBM297",
				[20420] = "IBM420",
				[20423] = "IBM423",
				[20424] = "IBM424",
				[20833] = "x-EBCDIC-KoreanExtended",
				[20838] = "IBM-Thai",
				[20866] = "koi8-r",
				[20871] = "IBM871",
				[20880] = "IBM880",
				[20905] = "IBM905",
				[20924] = "IBM00924",
				[20932] = "EUC-JP",
				[20936] = "x-cp20936",
				[20949] = "x-cp20949",
				[21025] = "cp1025",
				[21866] = "koi8-u",
				[28591] = "iso-8859-1",
				[28592] = "iso-8859-2",
				[28593] = "iso-8859-3",
				[28594] = "iso-8859-4",
				[28595] = "iso-8859-5",
				[28596] = "iso-8859-6",
				[28597] = "iso-8859-7",
				[28598] = "iso-8859-8",
				[28599] = "iso-8859-9",
				[28603] = "iso-8859-13",
				[28605] = "iso-8859-15",
				[29001] = "x-Europa",
				[38598] = "iso-8859-8-i",
				[50220] = "iso-2022-jp",
				[50221] = "csISO2022JP",
				[50222] = "iso-2022-jp",
				[50225] = "iso-2022-kr",
				[50227] = "x-cp50227",
				[51932] = "euc-jp",
				[51936] = "EUC-CN",
				[51949] = "euc-kr",
				[52936] = "hz-gb-2312",
				[54936] = "GB18030",
				[57002] = "x-iscii-de",
				[57003] = "x-iscii-be",
				[57004] = "x-iscii-ta",
				[57005] = "x-iscii-te",
				[57006] = "x-iscii-as",
				[57007] = "x-iscii-or",
				[57008] = "x-iscii-ka",
				[57009] = "x-iscii-ma",
				[57010] = "x-iscii-gu",
				[57011] = "x-iscii-pa",
				[65000] = "utf-7",
				[65001] = "utf-8"
			};
		}
		string p1 = null;
		if (z0uek.TryGetValue(p0, out p1))
		{
			return z0eek(p1);
		}
		return Encoding.UTF8;
	}
}
