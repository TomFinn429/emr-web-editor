using System.Collections.Generic;
using DCSoft.Drawing;

namespace zzz;

public static class z0ZzZzlmk
{
	private static readonly string z0uek;

	public static readonly Dictionary<ParagraphListStyle, string> z0iek;

	public static bool z0eek(ParagraphListStyle p0)
	{
		if (p0 != ParagraphListStyle.BulletedList && p0 != ParagraphListStyle.BulletedListBlock && p0 != ParagraphListStyle.BulletedListCheck && p0 != ParagraphListStyle.BulletedListDiamond && p0 != ParagraphListStyle.BulletedListHollowStar)
		{
			return p0 == ParagraphListStyle.BulletedListRightArrow;
		}
		return true;
	}

	public static string z0rek(ParagraphListStyle p0)
	{
		if (p0 == ParagraphListStyle.None)
		{
			return z0uek;
		}
		string result = null;
		if (z0iek.TryGetValue(p0, out result))
		{
			return result;
		}
		return z0uek;
	}

	public static string z0eek(int p0, ParagraphListStyle p1)
	{
		string result = p0.ToString();
		switch (p1)
		{
		case ParagraphListStyle.ListNumberStyle:
			result = p0.ToString();
			break;
		case ParagraphListStyle.ListNumberStyleArabic1:
			result = p0.ToString();
			break;
		case ParagraphListStyle.ListNumberStyleArabic2:
			result = p0.ToString();
			break;
		case ParagraphListStyle.ListNumberStyleLowercaseLetter:
			result = z0ZzZzwik.z0eek(p0 - 1, "abcdefghijklmnopqrstuvwxyz");
			break;
		case ParagraphListStyle.ListNumberStyleLowercaseRoman:
			result = z0ZzZzwik.z0eek(p0).ToLower();
			break;
		case ParagraphListStyle.ListNumberStyleNumberInCircle:
		{
			string text3 = "_①②③④⑤⑥⑦⑧⑨⑩";
			result = text3[p0 % text3.Length].ToString();
			break;
		}
		case ParagraphListStyle.ListNumberStyleSimpChinNum1:
			result = z0ZzZzwik.z0eek(p0, p1: true);
			break;
		case ParagraphListStyle.ListNumberStyleSimpChinNum2:
			result = z0ZzZzwik.z0eek(p0, p1: true);
			break;
		case ParagraphListStyle.ListNumberStyleTradChinNum1:
			result = z0ZzZzwik.z0eek(p0, p1: false);
			break;
		case ParagraphListStyle.ListNumberStyleTradChinNum2:
			result = z0ZzZzwik.z0eek(p0, p1: false);
			break;
		case ParagraphListStyle.ListNumberStyleUppercaseLetter:
			result = z0ZzZzwik.z0eek(p0 - 1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
			break;
		case ParagraphListStyle.ListNumberStyleUppercaseRoman:
			result = z0ZzZzwik.z0eek(p0).ToUpper();
			break;
		case ParagraphListStyle.ListNumberStyleZodiac1:
		{
			string text2 = "_甲乙丙丁戊己庚辛壬癸";
			result = text2[p0 % text2.Length].ToString();
			break;
		}
		case ParagraphListStyle.ListNumberStyleZodiac2:
		{
			string text = "_子丑寅卯辰巳午未申酉戌亥";
			result = text[p0 % text.Length].ToString();
			break;
		}
		}
		return result;
	}

	public static string z0rek(int p0, ParagraphListStyle p1)
	{
		string text = "\0.";
		if (z0iek.ContainsKey(p1))
		{
			text = z0iek[p1];
		}
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		string text2 = z0eek(p0, p1);
		return text.Replace("\0", text2);
	}

	public static bool z0tek(ParagraphListStyle p0)
	{
		if (p0 != ParagraphListStyle.ListNumberStyle && p0 != ParagraphListStyle.ListNumberStyleArabic1 && p0 != ParagraphListStyle.ListNumberStyleArabic2 && p0 != ParagraphListStyle.ListNumberStyleLowercaseLetter && p0 != ParagraphListStyle.ListNumberStyleLowercaseRoman && p0 != ParagraphListStyle.ListNumberStyleNumberInCircle && p0 != ParagraphListStyle.ListNumberStyleSimpChinNum1 && p0 != ParagraphListStyle.ListNumberStyleSimpChinNum2 && p0 != ParagraphListStyle.ListNumberStyleTradChinNum1 && p0 != ParagraphListStyle.ListNumberStyleTradChinNum2 && p0 != ParagraphListStyle.ListNumberStyleUppercaseLetter && p0 != ParagraphListStyle.ListNumberStyleUppercaseRoman && p0 != ParagraphListStyle.ListNumberStyleZodiac1)
		{
			return p0 == ParagraphListStyle.ListNumberStyleZodiac2;
		}
		return true;
	}

	public static ParagraphListStyle z0eek(char p0)
	{
		foreach (ParagraphListStyle key in z0iek.Keys)
		{
			string text = z0iek[key];
			if (!string.IsNullOrEmpty(text) && (text[0] & 0xFF) == (p0 & 0xFF))
			{
				return key;
			}
		}
		return ParagraphListStyle.BulletedList;
	}

	public static string z0yek(ParagraphListStyle p0)
	{
		if (p0 == ParagraphListStyle.None)
		{
			return null;
		}
		string result = null;
		if (z0iek.TryGetValue(p0, out result))
		{
			return result;
		}
		return null;
	}

	static z0ZzZzlmk()
	{
		z0uek = new string('\uf06c', 1);
		z0iek = new Dictionary<ParagraphListStyle, string>
		{
			[ParagraphListStyle.ListNumberStyle] = "\0.",
			[ParagraphListStyle.ListNumberStyleArabic1] = "\0,",
			[ParagraphListStyle.ListNumberStyleArabic2] = "\0)",
			[ParagraphListStyle.ListNumberStyleArabic3] = "\0、",
			[ParagraphListStyle.ListNumberStyleLowercaseLetter] = "\0)",
			[ParagraphListStyle.ListNumberStyleLowercaseRoman] = "\0)",
			[ParagraphListStyle.ListNumberStyleNumberInCircle] = "\0",
			[ParagraphListStyle.ListNumberStyleSimpChinNum1] = "\0.",
			[ParagraphListStyle.ListNumberStyleSimpChinNum2] = "\0)",
			[ParagraphListStyle.ListNumberStyleTradChinNum1] = "\0.",
			[ParagraphListStyle.ListNumberStyleTradChinNum2] = "\0)",
			[ParagraphListStyle.ListNumberStyleUppercaseLetter] = "\0)",
			[ParagraphListStyle.ListNumberStyleUppercaseRoman] = "\0)",
			[ParagraphListStyle.ListNumberStyleZodiac1] = "\0,",
			[ParagraphListStyle.ListNumberStyleZodiac2] = "\0,",
			[ParagraphListStyle.None] = null,
			[ParagraphListStyle.BulletedList] = new string('\uf06c', 1),
			[ParagraphListStyle.BulletedListBlock] = new string('\uf06e', 1),
			[ParagraphListStyle.BulletedListCheck] = new string('\uf0fc', 1),
			[ParagraphListStyle.BulletedListDiamond] = new string('\uf075', 1),
			[ParagraphListStyle.BulletedListRightArrow] = new string('\uf0d8', 1),
			[ParagraphListStyle.BulletedListHollowStar] = new string('\uf0b2', 1)
		};
	}
}
