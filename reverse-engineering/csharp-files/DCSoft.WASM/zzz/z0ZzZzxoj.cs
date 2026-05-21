using System;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

internal static class z0ZzZzxoj
{
	[CompilerGenerated]
	private static class z0xik
	{
		public static XTextPageInfoElement.z0gnk z0eek;
	}

	public static void z0eek()
	{
		XTextPageInfoElement.z0pek = z0eek;
	}

	private static string z0eek(XTextPageInfoElement p0, PageInfoValueType p1)
	{
		XTextDocument xTextDocument = p0.z0jr();
		switch (p1)
		{
		case PageInfoValueType.NumOfPages:
			if (xTextDocument == null)
			{
				return z0eek(p0, 0);
			}
			if (xTextDocument.z0wck)
			{
				if (xTextDocument.z0byk() == null)
				{
					return z0eek(p0, 0);
				}
				return z0eek(p0, xTextDocument.z0byk().Count + xTextDocument.z0vyk());
			}
			if (xTextDocument.z0yrk() != null && xTextDocument.z0yrk().Count > 0)
			{
				return z0eek(p0, xTextDocument.z0yrk().Count + xTextDocument.z0vyk());
			}
			if (xTextDocument.z0ipk() != null)
			{
				return z0eek(p0, xTextDocument.z0ipk().z0irk() + xTextDocument.z0vyk());
			}
			return z0eek(p0, 0);
		case PageInfoValueType.LocalNumOfPages:
			if (xTextDocument == null)
			{
				return z0eek(p0, 0);
			}
			if (xTextDocument.z0wck)
			{
				if (xTextDocument.z0byk() == null)
				{
					return z0eek(p0, 0);
				}
				return z0eek(p0, xTextDocument.z0byk().Count + xTextDocument.z0vyk());
			}
			if (xTextDocument.z0suk() != null && xTextDocument.z0suk().Count > 0)
			{
				return z0eek(p0, xTextDocument.z0suk().Count + xTextDocument.z0vyk());
			}
			if (xTextDocument.z0ipk() != null)
			{
				return z0eek(p0, xTextDocument.z0ipk().z0irk() + xTextDocument.z0vyk());
			}
			return z0eek(p0, 0);
		case PageInfoValueType.PageIndex:
			if (xTextDocument == null || xTextDocument.z0wck)
			{
				return (((XTextElement)xTextDocument).z0uyk().z0etk() + 1).ToString();
			}
			return z0eek(p0, xTextDocument.z0zik() + 1 + p0.PageIndexFix + xTextDocument.z0vyk());
		case PageInfoValueType.LocalPageIndex:
			if (xTextDocument == null || xTextDocument.z0wck)
			{
				return (((XTextElement)xTextDocument).z0uyk().z0etk() + 1).ToString();
			}
			return z0eek(p0, xTextDocument.z0cmk() + 1 + p0.PageIndexFix + xTextDocument.z0vyk());
		default:
			return z0eek(p0, 0);
		}
	}

	private static string z0eek(XTextPageInfoElement p0)
	{
		XTextDocument xTextDocument = p0.z0jr();
		if (!string.IsNullOrEmpty(p0.FormatString))
		{
			string[] array = z0ZzZznik.AnalyseVariableString(p0.FormatString, "[%", "%]");
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 0)
				{
					stringBuilder.Append(array[i]);
					continue;
				}
				if (xTextDocument.z0bu().WeakMode)
				{
					PageInfoValueType p1 = (PageInfoValueType)Enum.Parse(typeof(PageInfoValueType), array[i], true);
					string text = z0eek(p0, p1);
					stringBuilder.Append(text);
					continue;
				}
				try
				{
					PageInfoValueType p2 = (PageInfoValueType)Enum.Parse(typeof(PageInfoValueType), array[i], true);
					string text2 = z0eek(p0, p2);
					stringBuilder.Append(text2);
				}
				catch (Exception ex)
				{
					z0ZzZzqok.z0rek.z0dh(ex.Message);
				}
			}
			return stringBuilder.ToString();
		}
		return z0eek(p0, p0.ValueType);
	}

	private static string z0eek(XTextPageInfoElement p0, int p1)
	{
		SpecifyPageIndexInfoList specifyPageIndexs = p0.SpecifyPageIndexs;
		if (specifyPageIndexs != null && specifyPageIndexs.Count > 0 && z0ZzZzxcj.z0eek(201))
		{
			specifyPageIndexs.z0rek();
			for (int num = specifyPageIndexs.Count - 1; num >= 0; num--)
			{
				SpecifyPageIndexInfo specifyPageIndexInfo = specifyPageIndexs[num];
				if (specifyPageIndexInfo.RawPageIndex <= p1 && specifyPageIndexInfo.SpecifyPageIndex >= 0)
				{
					p1 = specifyPageIndexInfo.SpecifyPageIndex + (p1 - specifyPageIndexInfo.RawPageIndex);
				}
			}
		}
		if (!string.IsNullOrEmpty(p0.SpecifyPageIndexTextList))
		{
			p1--;
			string[] array = p0.SpecifyPageIndexTextList.Split(',');
			if (p1 >= 0 && p1 < array.Length)
			{
				return array[p1];
			}
			return null;
		}
		return z0ZzZzlmk.z0eek(p1, p0.DisplayFormat);
	}
}
