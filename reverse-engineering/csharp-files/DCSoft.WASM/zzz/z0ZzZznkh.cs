using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZznkh : IDisposable
{
	private static readonly ArrayList z0bek = new ArrayList();

	private bool z0vek;

	private string[] z0cek;

	private string z0xek;

	private bool z0zek;

	private string z0lrk;

	private string z0krk;

	internal bool z0jrk;

	private XTextElement z0hrk;

	private object[] z0grk;

	private bool z0frk = true;

	private XTextElement z0drk_jiejie20260327142557;

	private z0ZzZztkh z0srk;

	public XTextElement z0eek()
	{
		return z0hrk;
	}

	public bool z0rek()
	{
		return z0zek;
	}

	[CompilerGenerated]
	internal static bool z0eek(string p0, char p1)
	{
		if (p0.Length > 0)
		{
			return p0[p0.Length - 1] == p1;
		}
		return false;
	}

	internal object z0eek(string p0)
	{
		z0xek = null;
		if (z0drk_jiejie20260327142557 == null)
		{
			throw new InvalidOperationException("Element is null");
		}
		bool flag = z0srk == null || z0srk.z0yek();
		XTextDocument xTextDocument = z0tek().z0jr();
		object obj = null;
		bool flag2 = false;
		bool flag3 = true;
		if (z0krk != null && (string.Compare(z0krk, z0ZzZzkfh.z0ork, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(z0krk, z0ZzZzkfh.z0lrk, StringComparison.OrdinalIgnoreCase) == 0))
		{
			flag3 = false;
		}
		if (z0yek(p0))
		{
			obj = z0eek();
		}
		else if (z0ZzZzryk.z0yek(p0))
		{
			z0ZzZzryk z0ZzZzryk2 = new z0ZzZzryk(p0);
			XTextTableElement xTextTableElement = null;
			if (string.IsNullOrEmpty(z0ZzZzryk2.z0rek()))
			{
				xTextTableElement = z0tek().z0tek<XTextTableElement>(p0: false);
			}
			else
			{
				xTextTableElement = z0srk.z0tek(z0ZzZzryk2.z0rek(), null) as XTextTableElement;
				if (xTextTableElement == null)
				{
					xTextTableElement = z0tek().z0tek<XTextTableElement>(p0: false);
				}
			}
			if (xTextTableElement != null)
			{
				if (z0ZzZzryk2.z0tek())
				{
					ArrayList arrayList = new ArrayList();
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0zek().z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
							if (!xTextTableCellElement.z0bek() && z0ZzZzryk2.z0eek(xTextTableCellElement.z0pek() + 1, xTextTableCellElement.z0xek() + 1))
							{
								if (flag3 && xTextTableCellElement == z0tek())
								{
									flag2 = true;
									break;
								}
								arrayList.Add(xTextTableCellElement);
							}
						}
					}
					obj = arrayList;
				}
				else
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0zek().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk.Current;
						if (!xTextTableCellElement2.z0bek() && z0ZzZzryk2.z0eek(xTextTableCellElement2.z0pek() + 1, xTextTableCellElement2.z0xek() + 1))
						{
							if (flag3 && xTextTableCellElement2 == z0tek())
							{
								flag2 = true;
							}
							else
							{
								obj = xTextTableCellElement2;
							}
							break;
						}
					}
				}
			}
		}
		if (obj == null && !flag2)
		{
			XTextElement xTextElement = null;
			if (z0tek().z0gr() != null)
			{
				xTextElement = z0tek().z0gr().z0ki(p0);
			}
			if (xTextElement == null && z0tek().z0iek() != null)
			{
				xTextElement = z0tek().z0iek().z0ki(p0);
			}
			if (xTextElement == null)
			{
				xTextElement = z0srk.z0tek(p0, z0tek());
			}
			if (xTextElement != null)
			{
				obj = ((!(xTextElement is XTextCheckBoxElementBase)) ? xTextElement : ((!(((XTextCheckBoxElementBase)xTextElement).Name == p0)) ? ((object)xTextElement) : ((object)new ArrayList(((XTextCheckBoxElementBase)xTextElement).z0eek()))));
			}
			if (xTextElement == null)
			{
				XTextElementList xTextElementList = z0srk.z0iek(p0);
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					if (xTextElementList.Count == 1)
					{
						obj = xTextElementList[0];
					}
					else if (xTextElementList.Count > 1)
					{
						Type type = xTextElementList[0].GetType();
						bool flag4 = false;
						if (!(xTextElementList[0] is XTextCheckBoxElementBase))
						{
							flag4 = true;
						}
						else
						{
							using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
							while (z0bpk.MoveNext())
							{
								if (z0bpk.Current.GetType() != type)
								{
									flag4 = true;
									break;
								}
							}
						}
						if (flag4)
						{
							z0xek = $"解析元素“{z0drk_jiejie20260327142557.ID}”的表达式“{z0lrk}”时查找名称为“{p0}”的元素时出现元素类型不匹配的警告。";
							if (z0drk_jiejie20260327142557 is XTextInputFieldElement)
							{
								((XTextInputFieldElement)z0drk_jiejie20260327142557).z0krk(xTextDocument.z0dtk() != (z0ZzZzzcj)3);
							}
							if (flag)
							{
								z0ZzZzqok.z0rek.z0sh(z0xek);
							}
						}
					}
					obj = new ArrayList(xTextElementList);
				}
			}
			else if (flag3 && (xTextElement.z0zu(z0drk_jiejie20260327142557) || z0drk_jiejie20260327142557.z0zu(xTextElement)))
			{
				flag2 = true;
			}
		}
		if (obj == null)
		{
			if (flag)
			{
				string p1 = $"对象“{z0rek(z0drk_jiejie20260327142557)}”的表达式“{z0nek()}”中的编号“{p0}”未找到对应元素。";
				z0ZzZzqok.z0rek.z0sh(p1);
			}
		}
		else
		{
			if ((obj == z0drk_jiejie20260327142557 || flag2) && flag)
			{
				string text = z0drk_jiejie20260327142557.ID;
				if (string.IsNullOrEmpty(text) && z0drk_jiejie20260327142557 is XTextTableCellElement)
				{
					text = ((XTextTableCellElement)z0drk_jiejie20260327142557).z0oek();
				}
				string p2 = $"元素“{text}”的数值表达式“{z0lrk}”中引用了元素自己。";
				z0ZzZzqok.z0rek.z0sh(p2);
			}
			if (obj is ArrayList arrayList2)
			{
				for (int num = arrayList2.Count - 1; num >= 0; num--)
				{
					if (z0eek(arrayList2[num], flag))
					{
						arrayList2.RemoveAt(num);
					}
				}
				if (arrayList2.Count == 0)
				{
					return null;
				}
				if (arrayList2.Count == 1)
				{
					return arrayList2[0];
				}
				return arrayList2.ToArray();
			}
			if (obj is XTextElement && z0srk.z0tek((XTextElement)obj))
			{
				return null;
			}
		}
		return obj;
	}

	public XTextElement z0tek()
	{
		return z0drk_jiejie20260327142557;
	}

	public void Dispose()
	{
		z0srk = null;
		z0krk = null;
		z0drk_jiejie20260327142557 = null;
		z0cek = null;
		z0xek = null;
		if (z0grk != null)
		{
			Array.Clear(z0grk, 0, z0grk.Length);
			z0grk = null;
		}
		z0hrk = null;
	}

	public void z0eek(XTextElement p0)
	{
		if (z0drk_jiejie20260327142557 != p0)
		{
			z0drk_jiejie20260327142557 = p0;
			z0vek = false;
		}
	}

	public void z0yek()
	{
		if (z0vek)
		{
			return;
		}
		if (z0krk != null)
		{
			if (z0oek(z0krk) || z0iek(z0krk))
			{
				z0jrk = true;
			}
			else
			{
				z0jrk = false;
			}
		}
		z0xek = null;
		if (z0drk_jiejie20260327142557 == null)
		{
			throw new InvalidOperationException("Element is null");
		}
		z0grk = Array.Empty<object>();
		z0cek = Array.Empty<string>();
		if (z0lrk == null || z0lrk.Trim().Length == 0 || z0drk_jiejie20260327142557.z0ji() == null)
		{
			return;
		}
		string[] array = z0srk.z0oek(z0lrk);
		if (array.Length == 3)
		{
			string text = array[1];
			if (text != null && text.Length > 0)
			{
				z0cek = new string[1] { text };
				z0grk = new object[1] { z0eek(text) };
			}
		}
		else
		{
			z0bek.Clear();
			List<string> list = z0srk.z0krk;
			if (list == null)
			{
				list = new List<string>();
				z0srk.z0krk = list;
			}
			else
			{
				list.Clear();
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 != 0)
				{
					string text2 = array[i];
					if (text2 != null && text2.Length > 0)
					{
						object obj = z0eek(text2);
						z0bek.Add(obj);
						list.Add(text2);
					}
				}
			}
			if (list.Count > 0)
			{
				z0cek = list.ToArray();
				z0grk = z0bek.ToArray();
			}
			else
			{
				z0cek = null;
				z0grk = Array.Empty<object>();
			}
			z0bek.Clear();
		}
		z0vek = true;
	}

	public object z0eek(XTextElement p0, int p1, bool p2)
	{
		z0yek();
		z0rek(p0: true);
		StringBuilder stringBuilder = new StringBuilder();
		string[] array = z0srk.z0oek(z0lrk);
		string text = null;
		char c = '\0';
		string p3 = null;
		string text2 = z0lrk.ToLower();
		bool flag = text2.IndexOf('+') > 0 || text2.IndexOf('-') > 0 || text2.IndexOf('*') > 0 || text2.IndexOf('/') > 0 || text2.StartsWith("sum", StringComparison.Ordinal) || text2.StartsWith("product", StringComparison.Ordinal) || text2.IndexOf('>') > 0 || text2.IndexOf('<') > 0;
		if (flag)
		{
			string[] obj = new string[4] { "DAYDIFF", "MINUTEDIFF", "HOURDIFF", "FIND" };
			string text3 = text2.ToUpper();
			string[] array2 = obj;
			foreach (string text4 in array2)
			{
				if (text3.Contains(text4))
				{
					flag = false;
				}
			}
		}
		for (int j = 0; j < array.Length; j++)
		{
			if (j % 2 == 0)
			{
				string text5 = array[j];
				if (text5.Length == 0)
				{
					continue;
				}
				int num = text5.IndexOf('(');
				if (num > 0)
				{
					p3 = text5.Substring(0, num);
				}
				else
				{
					num = text5.IndexOf(')');
					if (num >= 0)
					{
						p3 = null;
					}
				}
				stringBuilder.Append(text5);
				c = (z0eek(text5, '\'') ? '\'' : (z0eek(text5, '"') ? '"' : '\0'));
			}
			else
			{
				if ((j - 1) / 2 >= z0grk.Length)
				{
					stringBuilder.Append(2147439148.ToString());
					continue;
				}
				bool flag2 = false;
				bool flag3 = false;
				if (c != 0 && j < array.Length - 1)
				{
					string text6 = array[j + 1];
					if (text6.Length > 0 && text6[0] == c)
					{
						flag2 = true;
					}
				}
				if (!flag2)
				{
					if (text != null)
					{
						flag3 = z0rek(p3);
					}
				}
				else
				{
					flag3 = true;
				}
				object obj2 = z0grk[(j - 1) / 2];
				if (obj2 != null)
				{
					if (obj2 is XTextElement)
					{
						double p4 = 2147439148.0;
						string text7 = z0eek((XTextElement)obj2, p1: true, flag);
						if (flag2)
						{
							stringBuilder.Append(text7);
						}
						else if (flag3)
						{
							if (text != null && z0eek(text, '\''))
							{
								stringBuilder.Append(text7);
							}
							else
							{
								stringBuilder.Append("'" + text7 + "'");
							}
						}
						else
						{
							if (text7 != null && text7.Length > 0)
							{
								text7 = text7.Trim();
								if (text7.Length > 0 && text7.Length < 25)
								{
									p4 = z0ZzZzxmk.z0rek(text7, z0ZzZzbok.z0rek);
								}
							}
							if (z0ZzZzbok.z0eek(p4))
							{
								stringBuilder.Append("'" + text7 + "'");
							}
							else if (string.IsNullOrEmpty(text7))
							{
								stringBuilder.Append('0');
							}
							else
							{
								stringBuilder.Append(p4.ToString());
							}
						}
					}
					else if (obj2 is object[] array3)
					{
						if (array3.Length != 0 && array3[0] is XTextCheckBoxElementBase && !flag3)
						{
							double num2 = 0.0;
							object[] array4 = array3;
							for (int i = 0; i < array4.Length; i++)
							{
								if (!((XTextElement)array4[i] is XTextCheckBoxElementBase { Checked: not false } xTextCheckBoxElementBase))
								{
									continue;
								}
								string text8 = z0eek(xTextCheckBoxElementBase, p1: true, flag);
								if (flag3)
								{
									stringBuilder.Append(text8);
									continue;
								}
								double num3 = 0.0;
								if (double.TryParse(text8, out num3))
								{
									num2 += num3;
								}
							}
							stringBuilder.Append(num2.ToString());
						}
						else
						{
							int num4 = 0;
							if (flag3 && c == '\0')
							{
								stringBuilder.Append('\'');
							}
							for (int k = 0; k < array3.Length; k++)
							{
								string text9 = z0eek((XTextElement)array3[k], p1: true, flag);
								if (array3[k] is XTextCheckBoxElementBase && string.IsNullOrEmpty(text9))
								{
									continue;
								}
								if (num4 > 0)
								{
									stringBuilder.Append(',');
								}
								num4++;
								if (flag3)
								{
									stringBuilder.Append(text9);
									continue;
								}
								double p5 = 2147439148.0;
								if (text9 != null)
								{
									text9 = text9.Trim();
									if (text9.Length > 0 && text9.Length < 25)
									{
										p5 = z0ZzZzmkh.z0eek(text9);
									}
								}
								if (z0ZzZzbok.z0eek(p5))
								{
									stringBuilder.Append(2147439148.ToString());
								}
								else
								{
									stringBuilder.Append(p5.ToString());
								}
							}
							if (flag3 && c == '\0')
							{
								stringBuilder.Append('\'');
							}
						}
					}
				}
			}
			text = array[j];
		}
		string text10 = stringBuilder.ToString();
		DocumentBehaviorOptions documentBehaviorOptions = z0drk_jiejie20260327142557.z0bu();
		if (documentBehaviorOptions.NewExpressionExecuteMode)
		{
			text10 = z0nek();
		}
		object obj3 = null;
		string text11 = (p2 ? z0rek(z0drk_jiejie20260327142557) : null);
		string text12 = null;
		try
		{
			if (string.IsNullOrEmpty(text10))
			{
				obj3 = null;
			}
			else if (documentBehaviorOptions.UseNewValueExpressionEngine)
			{
				z0ZzZzmkh z0ZzZzmkh2 = new z0ZzZzmkh(text10, z0tek(), this, z0srk);
				obj3 = z0ZzZzmkh2.z0eek();
				if (p2)
				{
					text12 = z0ZzZzmkh2.z0uek();
				}
			}
			if (p2)
			{
				string text13 = z0rek(p0);
				string text14 = null;
				string text15 = z0lrk;
				if (!string.IsNullOrEmpty(z0krk) && !z0uek(z0krk))
				{
					text15 = "[" + z0krk + "]#" + text15;
				}
				text14 = ((!string.IsNullOrEmpty(text13)) ? string.Format("对象“{0}”触发对象“{1}”执行表达式“{2}”，结果为“{3}”。", text13, text11, text15 + " ==> " + text10.Replace(2147439148.ToString(), "NaN"), obj3) : string.Format("对象“{0}”执行表达式“{1}”，结果为“{2}”。", text11, text15 + " ==> " + text10.Replace(2147439148.ToString(), "NaN"), obj3));
				if (p1 > 0)
				{
					text14 = new string(' ', p1 * 2) + text14;
				}
				text12 = text12 + Environment.NewLine + text14;
				if (text12 != null)
				{
					z0ZzZzqok.z0rek.z0sh(text12);
				}
			}
		}
		catch (Exception ex)
		{
			if (p2)
			{
				z0ZzZzqok.z0rek.z0dh(z0lrk + ":" + ex.ToString());
			}
			else
			{
				string text16 = z0lrk;
				if (!string.IsNullOrEmpty(z0krk) && !z0uek(z0krk))
				{
					text16 = "[" + z0krk + "] " + text16;
				}
				z0ZzZzqok.z0rek.z0sh(string.Format("对象“{0}”执行表达式“{1}”，结果为“{2}”。", text11, text16 + " ==> " + text10.Replace(2147439148.ToString(), "NaN"), ex.ToString()));
			}
			throw ex;
		}
		return obj3;
	}

	public string z0uek()
	{
		return z0krk;
	}

	public string z0iek()
	{
		return z0xek;
	}

	internal static bool z0eek(object p0, bool p1)
	{
		if (p0 is XTextElement)
		{
			XTextElement xTextElement = (XTextElement)p0;
			if (xTextElement.z0tyk())
			{
				if (p1 && p1)
				{
					string p2 = $"文档元素“{z0rek(xTextElement)}”由于是隐藏的或者被逻辑删除的，无法参与表达式运算。";
					z0ZzZzqok.z0rek.z0sh(p2);
				}
				return true;
			}
		}
		return false;
	}

	internal static bool z0rek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return true;
		}
		p0 = p0.Trim().ToUpper();
		if (p0.EndsWith("LEN", StringComparison.Ordinal) || p0.EndsWith("PARAMETER", StringComparison.Ordinal) || p0.EndsWith("FIND", StringComparison.Ordinal) || p0.EndsWith("LOOKUP", StringComparison.Ordinal) || p0.EndsWith("AGE", StringComparison.Ordinal) || p0.EndsWith("AGEMONTH", StringComparison.Ordinal) || p0.EndsWith("AGEWEEK", StringComparison.Ordinal) || p0.EndsWith("AGEDAY", StringComparison.Ordinal) || p0.EndsWith("AGEHOUR", StringComparison.Ordinal) || p0.EndsWith("CINT", StringComparison.Ordinal) || p0.EndsWith("CDOUBLE", StringComparison.Ordinal))
		{
			return true;
		}
		if (p0.EndsWith("ABS", StringComparison.Ordinal) || p0.EndsWith("ACOS", StringComparison.Ordinal) || p0.EndsWith("ASIN", StringComparison.Ordinal) || p0.EndsWith("ATAN", StringComparison.Ordinal) || p0.EndsWith("ATAN2", StringComparison.Ordinal) || p0.EndsWith("AVERAGE", StringComparison.Ordinal) || p0.EndsWith("CEILING", StringComparison.Ordinal) || p0.EndsWith("COS", StringComparison.Ordinal) || p0.EndsWith("COUNT", StringComparison.Ordinal) || p0.EndsWith("EXP", StringComparison.Ordinal) || p0.EndsWith("FLOOR", StringComparison.Ordinal) || p0.EndsWith("INT", StringComparison.Ordinal) || p0.EndsWith("LOG", StringComparison.Ordinal) || p0.EndsWith("LOG10", StringComparison.Ordinal) || p0.EndsWith("MAX", StringComparison.Ordinal) || p0.EndsWith("MIN", StringComparison.Ordinal) || p0.EndsWith("MOD", StringComparison.Ordinal) || p0.EndsWith("ODD", StringComparison.Ordinal) || p0.EndsWith("POW", StringComparison.Ordinal) || p0.EndsWith("PRODUCT", StringComparison.Ordinal) || p0.EndsWith("RADIANS", StringComparison.Ordinal) || p0.EndsWith("ROUND", StringComparison.Ordinal) || p0.EndsWith("ROUNDDOWN", StringComparison.Ordinal) || p0.EndsWith("ROUNDUP", StringComparison.Ordinal) || p0.EndsWith("SIGN", StringComparison.Ordinal) || p0.EndsWith("SIN", StringComparison.Ordinal) || p0.EndsWith("SORT", StringComparison.Ordinal) || p0.EndsWith("SUM", StringComparison.Ordinal) || p0.EndsWith("TAN", StringComparison.Ordinal))
		{
			return false;
		}
		return true;
	}

	public void z0tek(string p0)
	{
		if (z0lrk != p0)
		{
			z0lrk = p0;
			z0vek = false;
		}
	}

	private static string z0eek(XTextElement p0, bool p1, bool p2 = false)
	{
		if (p2)
		{
			string text = null;
			if (p0 is XTextContainerElement)
			{
				StringBuilder stringBuilder = new StringBuilder();
				double num = z0ZzZzbok.z0rek;
				XTextContainerElement obj = (XTextContainerElement)p0;
				bool flag = false;
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = obj.z0be().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						if (current is XTextInputFieldElement)
						{
							XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)current;
							if (xTextInputFieldElement.z0oek() == InputFieldEditStyle.DropdownList && xTextInputFieldElement.z0my(xTextInputFieldElement.InnerValue, p1: false) != xTextInputFieldElement.Text)
							{
								text = xTextInputFieldElement.Text;
							}
							else
							{
								text = xTextInputFieldElement.InnerValue;
								if (string.IsNullOrEmpty(text))
								{
									text = xTextInputFieldElement.Text;
								}
							}
							return text;
						}
						if (current is XTextCheckBoxElement)
						{
							flag = true;
							XTextCheckBoxElement xTextCheckBoxElement = (XTextCheckBoxElement)current;
							if (xTextCheckBoxElement.Checked)
							{
								if (stringBuilder.Length > 0)
								{
									stringBuilder.Append(',');
								}
								if (string.IsNullOrEmpty(xTextCheckBoxElement.CheckedValue))
								{
									stringBuilder.Append(xTextCheckBoxElement.Caption);
								}
								else
								{
									stringBuilder.Append(xTextCheckBoxElement.CheckedValue);
								}
								double num2 = z0ZzZzbok.z0rek;
								if (double.TryParse(xTextCheckBoxElement.CheckedValue, out num2))
								{
									num = ((!z0ZzZzbok.z0eek(num)) ? (num + num2) : num2);
								}
							}
						}
						else if (current is XTextRadioBoxElement)
						{
							flag = true;
							XTextRadioBoxElement xTextRadioBoxElement = (XTextRadioBoxElement)current;
							if (xTextRadioBoxElement.Checked)
							{
								return xTextRadioBoxElement.CheckedValue;
							}
						}
					}
				}
				if (!z0ZzZzbok.z0eek(num))
				{
					return num.ToString();
				}
				if (stringBuilder.Length > 0)
				{
					return stringBuilder.ToString();
				}
				if (flag)
				{
					return null;
				}
			}
			else if (p0 is XTextCheckBoxElementBase)
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)p0;
				if (p1)
				{
					if (xTextCheckBoxElementBase.Checked)
					{
						if (!string.IsNullOrEmpty(xTextCheckBoxElementBase.CheckedValue))
						{
							return xTextCheckBoxElementBase.CheckedValue;
						}
						return xTextCheckBoxElementBase.Caption;
					}
					return null;
				}
				return xTextCheckBoxElementBase.z0eek(',');
			}
			if (string.IsNullOrEmpty(text))
			{
				if (p0 is XTextInputFieldElement)
				{
					XTextInputFieldElement xTextInputFieldElement2 = (XTextInputFieldElement)p0;
					if (xTextInputFieldElement2.z0be().Count == 0)
					{
						text = null;
					}
					else
					{
						text = xTextInputFieldElement2.InnerValue;
						if (string.IsNullOrEmpty(text))
						{
							text = xTextInputFieldElement2.Text;
						}
					}
				}
				else
				{
					text = p0.Text;
				}
			}
			return text;
		}
		string text2 = null;
		if (p0 is XTextTableElement)
		{
			z0ZzZzdxj z0ZzZzdxj2 = new z0ZzZzdxj();
			z0ZzZzdxj2.z0tek(p0: false);
			z0ZzZzdxj2.z0eek(p0: false);
			z0ZzZzdxj2.z0yek(!p0.z0yi());
			z0ZzZzdxj2.z0rek(p0: false);
			z0ZzZzdxj2.z0uek(p0: false);
			return p0.z0yek(z0ZzZzdxj2).TrimEnd();
		}
		if (p0 is XTextInputFieldElement)
		{
			XTextInputFieldElement xTextInputFieldElement3 = (XTextInputFieldElement)p0;
			XTextCheckBoxElementBase xTextCheckBoxElementBase2 = xTextInputFieldElement3.z0uek<XTextCheckBoxElementBase>();
			if (xTextInputFieldElement3.z0be().Count == 0)
			{
				text2 = null;
			}
			else
			{
				if (xTextCheckBoxElementBase2 != null)
				{
					return xTextCheckBoxElementBase2.z0eek(',');
				}
				text2 = xTextInputFieldElement3.InnerValue;
				if (string.IsNullOrEmpty(text2))
				{
					text2 = xTextInputFieldElement3.Text;
				}
			}
			if (string.IsNullOrEmpty(text2))
			{
				if (p0 is XTextInputFieldElement)
				{
					XTextInputFieldElement xTextInputFieldElement4 = (XTextInputFieldElement)p0;
					if (xTextInputFieldElement4.z0be().Count == 0)
					{
						text2 = null;
					}
					else
					{
						text2 = xTextInputFieldElement4.InnerValue;
						if (string.IsNullOrEmpty(text2))
						{
							text2 = xTextInputFieldElement4.Text;
						}
					}
				}
				else
				{
					text2 = p0.Text;
				}
			}
			return text2;
		}
		if (p0 is XTextContainerElement)
		{
			XTextContainerElement xTextContainerElement = p0 as XTextContainerElement;
			if (xTextContainerElement.z0uek<XTextContainerElement>() == null && xTextContainerElement.z0uek<XTextObjectElement>() == null)
			{
				z0ZzZzdxj z0ZzZzdxj3 = new z0ZzZzdxj();
				z0ZzZzdxj3.z0tek(p0: false);
				z0ZzZzdxj3.z0eek(p0: false);
				z0ZzZzdxj3.z0yek(!p0.z0yi());
				z0ZzZzdxj3.z0rek(p0: false);
				z0ZzZzdxj3.z0uek(p0: false);
				return p0.z0yek(z0ZzZzdxj3);
			}
			p1 = xTextContainerElement.z0be().Count > 0 && xTextContainerElement.z0be().Count <= 2 && xTextContainerElement.z0be()[0] is XTextCheckBoxElementBase;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextContainerElement.z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current2 = z0bpk.Current;
				text2 += z0eek(current2, p1, p2);
			}
			return text2;
		}
		if (p0 is XTextCheckBoxElementBase)
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase3 = (XTextCheckBoxElementBase)p0;
			if (p1)
			{
				if (xTextCheckBoxElementBase3.Checked)
				{
					if (!string.IsNullOrEmpty(xTextCheckBoxElementBase3.CheckedValue))
					{
						return xTextCheckBoxElementBase3.CheckedValue;
					}
					return xTextCheckBoxElementBase3.Caption;
				}
				return null;
			}
			return xTextCheckBoxElementBase3.z0eek(',');
		}
		return p0.Text;
	}

	internal static bool z0yek(string p0)
	{
		return string.Compare(p0, z0ZzZzkfh.z0xek, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public void z0eek(bool p0)
	{
		z0frk = p0;
	}

	internal static bool z0uek(string p0)
	{
		return string.Compare(p0, z0ZzZzkfh.z0ftk, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static string z0rek(XTextElement p0)
	{
		if (p0 == null)
		{
			return null;
		}
		string text = p0.ID;
		if (string.IsNullOrEmpty(text) && p0 is XTextTableCellElement)
		{
			text = ((XTextTableCellElement)p0).z0oek();
		}
		if (string.IsNullOrEmpty(text))
		{
			text = p0.GetType().Name;
		}
		return text;
	}

	public object[] z0oek()
	{
		z0yek();
		return z0grk;
	}

	public bool z0tek(XTextElement p0)
	{
		if (p0.z0iek() != z0tek().z0iek())
		{
			return false;
		}
		object[] array = z0oek();
		if (array != null)
		{
			object[] array2 = array;
			foreach (object obj in array2)
			{
				if (obj == p0)
				{
					return true;
				}
				if (obj is object[] array3 && Array.IndexOf(array3, p0) >= 0)
				{
					return true;
				}
			}
		}
		if (z0cek != null)
		{
			string iD = p0.ID;
			if (iD != null && iD.Length > 0 && Array.IndexOf(z0cek, iD) >= 0)
			{
				return true;
			}
			if (p0 is XTextInputFieldElementBase)
			{
				string name = ((XTextInputFieldElementBase)p0).Name;
				if (name != null && name.Length > 0 && Array.IndexOf(z0cek, name) >= 0)
				{
					return true;
				}
			}
			if (p0 is XTextCheckBoxElementBase)
			{
				string name2 = ((XTextCheckBoxElementBase)p0).Name;
				if (name2 != null && name2.Length > 0 && Array.IndexOf(z0cek, name2) >= 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	internal object z0eek(string p0, ref bool p1, bool p2 = false)
	{
		object obj = null;
		if (z0cek != null)
		{
			for (int num = z0cek.Length - 1; num >= 0; num--)
			{
				if (z0cek[num] == p0)
				{
					obj = z0grk[num];
					break;
				}
			}
		}
		if (obj == null)
		{
			obj = z0eek(p0);
		}
		if (obj == null)
		{
			p1 = false;
			return null;
		}
		if (obj is object[] array)
		{
			if (array.Length != 0)
			{
				ArrayList arrayList = new ArrayList();
				StringBuilder stringBuilder = new StringBuilder();
				object[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					XTextElement xTextElement = (XTextElement)array2[i];
					if (xTextElement is XTextCheckBoxElementBase)
					{
						if (!((XTextCheckBoxElementBase)xTextElement).Checked)
						{
							continue;
						}
						object obj2 = z0eek(xTextElement, p1: true, p2);
						if (obj2 != null)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(',');
							}
							stringBuilder.Append(obj2.ToString());
						}
					}
					else
					{
						object obj3 = z0eek(xTextElement, p1: true, p2);
						arrayList.Add(obj3);
					}
				}
				p1 = true;
				if (stringBuilder.Length > 0)
				{
					return stringBuilder.ToString();
				}
				if (arrayList.Count > 0)
				{
					return arrayList.ToArray();
				}
				return null;
			}
			return null;
		}
		p1 = true;
		return z0eek((XTextElement)obj, p1: true, p2);
	}

	public bool z0eek(object p0)
	{
		z0yek();
		if (z0grk != null)
		{
			if (z0grk.Length == 1)
			{
				return z0grk[0] == p0;
			}
			return Array.IndexOf(z0grk, p0) >= 0;
		}
		return false;
	}

	public void z0rek(bool p0)
	{
		z0zek = p0;
	}

	internal z0ZzZznkh(z0ZzZztkh p0)
	{
		z0srk = p0;
	}

	internal void z0pek()
	{
		z0vek = false;
	}

	internal static bool z0iek(string p0)
	{
		return string.Compare(p0, z0ZzZzkfh.z0lrk, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public bool z0mek()
	{
		return z0frk;
	}

	internal static bool z0oek(string p0)
	{
		return string.Compare(p0, z0ZzZzkfh.z0ork, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public void z0yek(XTextElement p0)
	{
		z0hrk = p0;
	}

	public void z0pek(string p0)
	{
		if (z0krk != p0)
		{
			z0krk = p0;
			z0vek = false;
		}
	}

	public string z0nek()
	{
		return z0lrk;
	}
}
