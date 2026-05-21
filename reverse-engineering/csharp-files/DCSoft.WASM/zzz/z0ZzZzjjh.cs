using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WASM;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Medical;
using DCSoft.Writer.MedicalExpression;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal class z0ZzZzjjh : IDisposable
{
	private class z0nok : zzz.z0ZzZzkuk<char>
	{
		public string z0eek()
		{
			if (base.Count == 0)
			{
				return string.Empty;
			}
			return new string(z0atk, 0, base.Count);
		}
	}

	private class z0ynk : IEqualityComparer<z0ZzZzevk>
	{
		public bool Equals(z0ZzZzevk x, z0ZzZzevk y)
		{
			z0ZzZzink z0ZzZzink2 = x.z0iek();
			z0ZzZzink z0ZzZzink3 = y.z0iek();
			int num = z0ZzZzink2?.Count ?? 0;
			int num2 = z0ZzZzink3?.Count ?? 0;
			if (num != num2)
			{
				return false;
			}
			if (num == 0)
			{
				return true;
			}
			for (int num3 = num - 1; num3 >= 0; num3--)
			{
				z0ZzZzunk z0ZzZzunk2 = z0ZzZzink2[num3];
				z0ZzZzunk z0ZzZzunk3 = z0ZzZzink3[num3];
				if (z0ZzZzunk2 != z0ZzZzunk3 && !z0ZzZzunk2.z0eek(z0ZzZzunk3))
				{
					return false;
				}
			}
			return true;
		}

		public int GetHashCode(z0ZzZzevk obj)
		{
			int num = 0;
			if (obj.z0iek() != null)
			{
				foreach (z0ZzZzunk item in obj.z0iek().z0xrk())
				{
					num += item.z0tek();
				}
			}
			return num;
		}
	}

	private readonly bool z0cek;

	private Dictionary<string, string> z0xek = new Dictionary<string, string>();

	public static bool z0zek;

	private Dictionary<z0ZzZzevk, int> z0lrk = new Dictionary<z0ZzZzevk, int>(new z0ynk());

	private static readonly string z0krk;

	private XTextDocument z0jrk;

	private Dictionary<string, string> z0hrk = new Dictionary<string, string>();

	private z0ZzZzgbj z0grk;

	private static readonly int z0frk_jiejie20260327142557;

	private Dictionary<string, float[]> z0drk = new Dictionary<string, float[]>();

	private Dictionary<z0ZzZzevk, DocumentContentStyle> z0srk = new Dictionary<z0ZzZzevk, DocumentContentStyle>(new z0ynk());

	private static readonly string z0ark;

	private static bool z0qrk;

	private bool z0wrk = true;

	private z0ZzZzkbk z0erk;

	private static List<int> z0rrk;

	private static bool z0trk;

	private Dictionary<string, float> z0yrk = new Dictionary<string, float>();

	private static readonly string[] z0urk;

	private zzz.z0ZzZzuuk<XAttribute> z0irk = new zzz.z0ZzZzuuk<XAttribute>();

	private static readonly string z0ork;

	private int z0prk;

	private static bool z0mrk;

	private static readonly Dictionary<string, object[]> z0nrk;

	private Dictionary<string, z0ZzZzevk> z0brk = new Dictionary<string, z0ZzZzevk>();

	private Dictionary<string, z0ZzZzdjh> z0vrk = new Dictionary<string, z0ZzZzdjh>();

	private bool[] z0crk = new bool[100];

	private void z0tek(XTextPageInfoElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		foreach (z0ZzZzunk item in p1.z0yek().z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "dc_valuetype":
			{
				string text4 = item.z0yek();
				if (text4 != null && text4.Length > 0)
				{
					p0.ValueType = z0rek<PageInfoValueType>(text4);
				}
				break;
			}
			case "dc_formatstring":
			{
				string text7 = item.z0yek();
				if (text7 != null && text7.Length > 0)
				{
					p0.FormatString = text7;
				}
				break;
			}
			case "dc_specifypageindextextlist":
			{
				string text3 = item.z0yek();
				if (text3 != null && text3.Length > 0)
				{
					p0.SpecifyPageIndexTextList = text3;
				}
				break;
			}
			case "dc_visible":
			{
				string text6 = item.z0yek();
				if (text6 != null && text6.Length > 0)
				{
					p0.Visible = z0tek(text6, p1: false);
				}
				break;
			}
			case "dc_autoheight":
			{
				string text2 = item.z0yek();
				if (text2 != null && text2.Length > 0)
				{
					p0.AutoHeight = z0tek(text2, p1: false);
				}
				break;
			}
			case "dc_height":
			{
				string text5 = item.z0yek();
				if (text5 != null && text5.Length > 0)
				{
					float height = 0f / 0f;
					text5 = text5.Replace("px", string.Empty);
					if (float.TryParse(text5, out height))
					{
						p0.Height = height;
					}
				}
				break;
			}
			case "dc_width":
			{
				string text = item.z0yek();
				if (text != null && text.Length > 0)
				{
					float width = 0f / 0f;
					text = text.Replace("px", string.Empty);
					if (float.TryParse(text, out width))
					{
						p0.Width = width;
					}
				}
				break;
			}
			}
		}
		z0ZzZzevk z0ZzZzevk2 = z0yek(p1.z0yek());
		if (z0ZzZzevk2 != null)
		{
			for (int num = z0ZzZzevk2.z0iek().Count - 1; num >= 0; num--)
			{
				z0ZzZzunk z0ZzZzunk2 = z0ZzZzevk2.z0iek()[num];
				z0tek(p1, p0.z0xrk(), z0ZzZzunk2.z0rek(), z0ZzZzunk2.z0yek(), p0);
			}
		}
	}

	private void z0tek(XTextChartElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			p0 = new XTextChartElement();
		}
		using zzz.z0ZzZzkuk<z0ZzZzunk>.z0bpk z0bpk = p1.z0yek().z0oek().z0ltk();
		while (z0bpk.MoveNext())
		{
			z0ZzZzunk current = z0bpk.Current;
			switch (current.z0rek())
			{
			case "id":
				z0yek(p0, current.z0yek());
				break;
			case "name":
				p0.Name = current.z0yek();
				break;
			case "height":
				p0.Height = (float)z0ZzZzrpk.z0eek(current.z0yek(), GraphicsUnit.Document, 0.0);
				break;
			case "width":
				p0.Width = (float)z0ZzZzrpk.z0eek(current.z0yek(), GraphicsUnit.Document, 0.0);
				break;
			}
		}
	}

	internal XAttributeList z0tek(z0ZzZzunk p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (z0cek)
		{
			return null;
		}
		if (p0 != null && p0.z0uek is XAttributeList)
		{
			return (XAttributeList)p0.z0uek;
		}
		string text = p0.z0yek();
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		text = text.Trim();
		if (text.Length == 0)
		{
			return null;
		}
		XAttributeList xAttributeList = null;
		if (text[0] != '[')
		{
			string[] array = z0ZzZzqik.z0eek(text, ':', ';', p3: false);
			if (array != null && array.Length != 0)
			{
				xAttributeList = new XAttributeList();
				int num = array.Length;
				for (int i = 0; i < num; i += 2)
				{
					string text2 = z0oek(array[i]);
					string text3 = z0oek(array[i + 1]);
					XAttribute p1 = null;
					if (!z0irk.z0eek(text2, text3, out p1))
					{
						p1 = new XAttribute(text2, text3);
						z0irk.z0rek(text2, text3, p1);
					}
					xAttributeList.Add(p1);
				}
			}
		}
		if (p0 != null)
		{
			p0.z0uek = xAttributeList;
		}
		return xAttributeList;
	}

	private void z0tek(XTextBarcodeFieldElement p0, z0ZzZzajh p1)
	{
		if (p1.z0rek("height"))
		{
			p0.Height = z0tek(p1.z0tek("height"), p0.z0jr());
		}
		if (!string.IsNullOrEmpty(p0.z0eek()))
		{
			XTextStringElement xTextStringElement = new XTextStringElement();
			xTextStringElement.Text = p0.z0eek();
			p0.z0be().Clear();
			p0.z0be().Add(xTextStringElement);
			p0.z0eek(null);
		}
		else if (string.IsNullOrEmpty(p0.Text) && !string.IsNullOrEmpty(p0.InnerValue))
		{
			p0.z0be().Add(new XTextStringElement(p0.InnerValue));
		}
	}

	private static float z0tek(string p0, float p1)
	{
		if (p0 != null)
		{
			p0 = p0.Trim();
			if (p0.EndsWith("%"))
			{
				float num = 0f;
				if (float.TryParse(p0.Substring(0, p0.Length - 1), out num) && num > 0f)
				{
					return p1 * num / 100f;
				}
			}
			return (float)z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, 0.0);
		}
		return 0f;
	}

	public void z0tek(DocumentContentStyle p0, string p1)
	{
		if (!string.IsNullOrEmpty(p1))
		{
			z0ZzZzdjh z0ZzZzdjh2 = null;
			if (!z0vrk.TryGetValue(p1, out z0ZzZzdjh2))
			{
				z0ZzZzdjh2 = z0ZzZzdjh.z0eek(p1);
				z0vrk.Add(p1, z0ZzZzdjh2);
			}
			z0ZzZzdjh2?.z0eek(p0);
		}
	}

	private static float[] z0tek(z0ZzZzajh p0, string p1)
	{
		List<float> list = new List<float>();
		string[] array = z0tek(p1);
		if (array != null)
		{
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				double num = z0ZzZzrpk.z0eek(array2[i], GraphicsUnit.Document, z0ZzZzbok.z0rek);
				if (!z0ZzZzbok.z0eek(num))
				{
					list.Add((float)num);
				}
			}
		}
		return list.ToArray();
	}

	private z0ZzZzpmk z0tek(XTextElement p0, string p1)
	{
		bool debugMode = p0.z0jr().z0bu().DebugMode;
		try
		{
			z0ZzZzpmk z0ZzZzpmk2 = new z0ZzZzpmk();
			z0ZzZzpmk2.z0eek(p0: false);
			string p2 = string.Format(z0ZzZziok.z0lpk(), p1);
			if (debugMode)
			{
				z0ZzZzqok.z0rek.z0sh(p2);
			}
			int num = 0;
			if (num == 0)
			{
				num = z0ZzZzpmk2.Load(p1);
			}
			if (debugMode)
			{
				z0ZzZzqok.z0rek.z0sh(z0ZzZzafh.z0yek(num));
			}
			return z0ZzZzpmk2;
		}
		catch (Exception ex)
		{
			if (p0 is XTextImageElement)
			{
				XTextImageElement obj = (XTextImageElement)p0;
				obj.z0uek(p1 + ":" + ex.Message);
				obj.ToolTip = p1 + ":" + ex.Message;
			}
			else if (p0 is XTextSignImageElement)
			{
				((XTextSignImageElement)p0).Title = p1 + ":" + ex.Message;
			}
			if (debugMode)
			{
				z0ZzZzqok.z0rek.z0dh(z0ZzZziok.z0wok());
			}
		}
		return null;
	}

	private void z0tek(XTextPieElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			p0 = new XTextPieElement();
		}
		if (p1.z0rek("id"))
		{
			p0.ID = p1.z0tek("id");
		}
		if (p1.z0rek("name"))
		{
			p0.Name = p1.z0tek("name");
		}
		if (p1.z0rek("height"))
		{
			float num = float.Parse(p1.z0tek("height").Replace("px", string.Empty));
			if (num != 0f / 0f)
			{
				p0.Height = z0ZzZzrpk.z0eek(num, GraphicsUnit.Pixel, GraphicsUnit.Document);
			}
		}
		if (p1.z0rek("width"))
		{
			float num2 = float.Parse(p1.z0tek("width").Replace("px", string.Empty));
			if (num2 != 0f / 0f)
			{
				p0.Width = z0ZzZzrpk.z0eek(num2, GraphicsUnit.Pixel, GraphicsUnit.Document);
			}
		}
		p0.PieDocumentStyle = new z0ZzZzztk();
		p0.PieDocumentStyle.z0eek(new z0ZzZzhyk());
		p0.PieDocumentStyle.z0uek().Visible = false;
		p0.PieDocumentStyle.z0eek(new z0ZzZzptk());
		if (p1.z0rek("dc_showlegend"))
		{
			p0.PieDocumentStyle.z0vek().z0rek(z0tek(p1.z0tek("dc_showlegend"), p1: true));
		}
		if (p1.z0rek("dc_thickness"))
		{
			int p2 = -2147483648;
			if (int.TryParse(p1.z0tek("dc_thickness"), out p2))
			{
				p0.PieDocumentStyle.z0rek(p2);
			}
		}
	}

	private static string[] z0tek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		List<string> list = new List<string>();
		z0nok z0nok = new z0nok();
		bool flag = false;
		char c = '\0';
		int length = p0.Length;
		for (int i = 0; i < length; i++)
		{
			char c2 = p0[i];
			if (flag)
			{
				if (c2 == ')')
				{
					flag = false;
				}
				z0nok.Add(c2);
			}
			else if (c2 == '"' || c2 == '\'')
			{
				if (c2 == c)
				{
					list.Add(z0nok.z0eek());
					z0nok.Clear();
					c = '\0';
					continue;
				}
				if (z0nok.Count > 0)
				{
					list.Add(z0nok.z0eek());
					z0nok.Clear();
				}
				c = c2;
			}
			else if (char.IsWhiteSpace(c2) && c == '\0')
			{
				if (z0nok.Count > 0)
				{
					list.Add(z0nok.z0eek());
					z0nok.Clear();
				}
			}
			else
			{
				z0nok.Add(c2);
				if (c2 == '(')
				{
					flag = true;
				}
			}
		}
		if (z0nok.Count > 0)
		{
			list.Add(z0nok.z0eek());
		}
		return list.ToArray();
	}

	private static bool z0tek(string p0, out Color p1)
	{
		return z0ZzZzifh.z0eek(p0, out p1);
	}

	public static int z0tek(string p0, int p1, int p2 = 0)
	{
		int num = 0;
		if (p0 != null && p1 >= 0 && p0.Length > p1)
		{
			int length = p0.Length;
			bool flag = false;
			for (int i = p1; i < length; i++)
			{
				char c = p0[i];
				if (c >= '0' && c <= '9')
				{
					num = num * 10 + c - 48;
					continue;
				}
				if (c == '-')
				{
					flag = true;
					continue;
				}
				num = p2;
				break;
			}
			if (flag)
			{
				num = -num;
			}
			return num;
		}
		return p2;
	}

	private bool z0tek(z0ZzZzajh p0, string p1, out float p2)
	{
		if (string.IsNullOrEmpty(p1))
		{
			p2 = 0f;
			return false;
		}
		if (z0yrk.TryGetValue(p1, out p2))
		{
			return true;
		}
		if (z0tek(p1[0]))
		{
			double num = z0ZzZzrpk.z0eek(p1, GraphicsUnit.Document, z0ZzZzbok.z0rek);
			if (!z0ZzZzbok.z0eek(num))
			{
				p2 = (float)num;
				z0yrk[p1] = p2;
				return true;
			}
		}
		p2 = 0f;
		p1 = p1.Trim();
		if (p1.Length == 0)
		{
			return false;
		}
		if (z0tek(p1[0]))
		{
			double num2 = z0ZzZzrpk.z0eek(p1, GraphicsUnit.Document, z0ZzZzbok.z0rek);
			if (!z0ZzZzbok.z0eek(num2))
			{
				p2 = (float)num2;
				z0yrk[p1] = p2;
				return true;
			}
		}
		return false;
	}

	internal static float z0yek(string p0, float p1)
	{
		float result = 0f;
		if (float.TryParse(p0, out result))
		{
			return result;
		}
		return p1;
	}

	private static T z0eek<T>(string p0, T p1) where T : Enum
	{
		if (string.IsNullOrEmpty(p0) || p0 == "null")
		{
			return p1;
		}
		try
		{
			return zzz.z0ZzZzcyk<T>.z0eek(p0);
		}
		catch (Exception)
		{
			return p1;
		}
	}

	private static bool z0tek(z0ZzZzhbk p0)
	{
		bool result = false;
		for (z0ZzZzznk z0ZzZzznk2 = p0.z0eek(); z0ZzZzznk2 != null; z0ZzZzznk2 = z0ZzZzznk2.z0eek())
		{
			if (z0ZzZzznk2.z0cak() == "span" && ((z0ZzZzhbk)z0ZzZzznk2).z0eek("dctype") == "XTextInputFieldElement")
			{
				return true;
			}
		}
		return result;
	}

	public void Dispose()
	{
		if (z0yrk != null)
		{
			z0yrk.Clear();
			z0yrk = null;
		}
		if (z0brk != null)
		{
			foreach (KeyValuePair<string, z0ZzZzevk> item in z0brk)
			{
				if (item.Value != null)
				{
					item.Value.Dispose();
				}
			}
			z0brk.Clear();
			z0brk = null;
		}
		if (z0vrk != null)
		{
			z0vrk.Clear();
			z0vrk = null;
		}
		if (z0drk != null)
		{
			z0drk.Clear();
			z0drk = null;
		}
		if (z0srk != null)
		{
			z0srk.Clear();
			z0srk = null;
		}
		if (z0lrk != null)
		{
			z0lrk.Clear();
			z0lrk = null;
		}
		z0crk = null;
		if (z0irk != null)
		{
			z0irk.z0iek();
			z0irk = null;
		}
		if (z0xek != null)
		{
			z0xek.Clear();
			z0xek = null;
		}
	}

	private z0ZzZzevk z0tek(z0ZzZzhbk p0, string p1)
	{
		return z0tek(p0.z0eek("style"), p1);
	}

	private static float z0tek(string p0, string p1, string p2, XTextDocument p3, float p4)
	{
		float num = p4;
		if (!string.IsNullOrEmpty(p0))
		{
			num = z0tek(p0, p3);
		}
		else if (!string.IsNullOrEmpty(p1))
		{
			num = z0tek(p1, p3);
		}
		if (!string.IsNullOrEmpty(p2))
		{
			float num2 = 0f;
			if (float.TryParse(p2, out num2) && Math.Abs(num2 - num) < 5f)
			{
				num = num2;
			}
		}
		return num;
	}

	internal static bool z0tek(string p0, bool p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		if (p0 == "true")
		{
			return true;
		}
		if (p0 == "false")
		{
			return false;
		}
		if (string.Compare(p0, "true", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(p0, "on", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(p0, "yes", StringComparison.OrdinalIgnoreCase) == 0)
		{
			return true;
		}
		if (string.Compare(p0, "false", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(p0, "off", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(p0, "no", StringComparison.OrdinalIgnoreCase) == 0)
		{
			return false;
		}
		return p1;
	}

	private void z0tek(XTextImageElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		z0ZzZzhbk z0ZzZzhbk2 = p1.z0yek();
		p0.z0rek(p0: false);
		string text = "";
		string p2 = "";
		string p3 = "";
		string text2 = "";
		bool flag = z0ZzZzhbk2.z0rek("attachedcomment") == "DocumentComment";
		foreach (z0ZzZzunk item in z0ZzZzhbk2.z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "dc_printvisibility":
			{
				string text18 = item.z0yek();
				if (text18 != null && text18.Length > 0)
				{
					p0.PrintVisibility = z0rek<ElementVisibility>(text18);
				}
				break;
			}
			case "dc_enablerepeatedimage":
			{
				string text10 = item.z0yek();
				if (text10 != null && text10.Length > 0)
				{
					p0.z0pek_jiejie20260327142557(p0: true);
				}
				break;
			}
			case "dc_valueindexofrepeatedimage":
			{
				string text25 = item.z0yek();
				if (text25 != null && text25.Length > 0)
				{
					p0.z0rek(z0tek(text25, 0));
				}
				break;
			}
			case "dc_additionshapefixsize":
			{
				string text24 = item.z0yek();
				if (text24 != null && text24.Length > 0 && text24 != "false")
				{
					p0.z0uek(z0tek(text24, p1: false));
				}
				break;
			}
			case "alt":
			{
				string text5 = item.z0yek();
				if (text5 != null && text5.Length > 0)
				{
					p0.z0uek(text5);
				}
				break;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(item);
				break;
			case "dc_contentreadonly":
			{
				string text15 = item.z0yek();
				if (text15 != null && text15.Length > 0 && text15 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text15, ContentReadonlyState.Inherit);
				}
				break;
			}
			case "dc_customadditionshapecontent":
			{
				string text4 = item.z0yek();
				if (text4 != null && text4.Length > 0)
				{
					p0.z0iek(text4);
				}
				break;
			}
			case "dc_deleteable":
			{
				string text21 = item.z0yek();
				if (text21 != null && text21.Length > 0 && text21 != "true")
				{
					p0.Deleteable = z0tek(text21, p1: false);
				}
				break;
			}
			case "dc_enabled":
			{
				string text9 = item.z0yek();
				if (text9 != null && text9.Length > 0 && text9 != "true")
				{
					p0.Enabled = z0tek(text9, p1: false);
				}
				break;
			}
			case "dc_enableeditimageadditionshape":
			{
				string text29 = item.z0yek();
				if (text29 != null && text29.Length > 0 && text29 != "true")
				{
					p0.EnableEditImageAdditionShape = z0tek(text29, p1: false);
				}
				break;
			}
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "dc_innerhasnoimage":
			{
				string text19 = item.z0yek();
				if (text19 != null && text19.Length > 0 && text19 != "false")
				{
					p0.z0rek(z0tek(text19, p1: false));
				}
				break;
			}
			case "dc_innernativeimagesource":
			{
				string text13 = item.z0yek();
				if (text13 != null && text13.Length > 0)
				{
					p0.z0yek(text13);
				}
				break;
			}
			case "dc_linkinfo":
			{
				string text6 = item.z0yek();
				if (text6 != null && text6.Length > 0)
				{
					((XTextObjectElement)p0).z0eek(new z0ZzZzbuk());
					z0ZzZzmik.z0eek(((XTextObjectElement)p0).z0iek(), text6);
				}
				break;
			}
			case "dc_name":
			{
				string text30 = item.z0yek();
				if (text30 != null && text30.Length > 0)
				{
					p0.Name = text30;
				}
				break;
			}
			case "dc_propertyexpressions":
			{
				string text27 = item.z0yek();
				if (text27 != null && text27.Length > 0)
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text27);
				}
				break;
			}
			case "dc_savecontentinfile":
			{
				string text22 = item.z0yek();
				if (text22 != null && text22.Length > 0 && text22 != "true")
				{
					p0.SaveContentInFile = z0tek(text22, p1: true);
				}
				break;
			}
			case "dc_smoothzoom":
			{
				string text16 = item.z0yek();
				if (text16 != null && text16.Length > 0 && text16 != "true")
				{
					p0.SmoothZoom = z0tek(text16, p1: false);
				}
				break;
			}
			case "dc_stringtag":
			{
				string text12 = item.z0yek();
				if (text12 != null && text12.Length > 0)
				{
					p0.StringTag = text12;
				}
				break;
			}
			case "title":
			{
				string text8 = item.z0yek();
				if (text8 != null && text8.Length > 0)
				{
					p0.z0eek(text8);
				}
				break;
			}
			case "dc_transparentcolor":
			{
				string text31 = item.z0yek();
				if (text31 != null && text31.Length > 0 && text31 != "Color.Transparent")
				{
					p0.z0eek(z0ZzZzzij.z0eek(text31, Color.Black));
				}
				break;
			}
			case "dc_valign":
			{
				string text28 = item.z0yek();
				if (text28 != null && text28.Length > 0 && text28 != "Bottom")
				{
					p0.VAlign = z0rek<VerticalAlignStyle>(text28);
				}
				break;
			}
			case "dc_valueexpression":
			{
				string text26 = item.z0yek();
				if (text26 != null && text26.Length > 0)
				{
					p0.ValueExpression = text26;
				}
				break;
			}
			case "nativeimagedata":
			{
				string text23 = item.z0yek();
				if (text23 != null && text23.Length > 0)
				{
					text = text23;
				}
				break;
			}
			case "src":
			{
				string text20 = item.z0yek();
				if (text20 != null && text20.Length > 0)
				{
					p2 = text20;
				}
				break;
			}
			case "border":
			{
				string text17 = item.z0yek();
				if (text17 != null && text17.Length > 0)
				{
					p3 = text17;
				}
				break;
			}
			case "dc_surroundings":
			{
				string text14 = item.z0yek();
				if (text14 != null && text14.Length > 0)
				{
					text2 = text14;
				}
				break;
			}
			case "dc_zorderstyle":
			{
				string text11 = item.z0yek();
				if (text11 != null && text11.Length > 0)
				{
					p0.ZOrderStyle = z0eek(text11, ElementZOrderStyle.Normal);
				}
				break;
			}
			case "dc_offsetx":
			{
				float offsetX = 0f / 0f;
				string text7 = item.z0yek();
				if (text7 != null && text7.Length > 0 && float.TryParse(text7, out offsetX))
				{
					p0.OffsetX = offsetX;
				}
				break;
			}
			case "dc_offsety":
			{
				float offsetY = 0f / 0f;
				string text3 = item.z0yek();
				if (text3 != null && text3.Length > 0 && float.TryParse(text3, out offsetY))
				{
					p0.OffsetY = offsetY;
				}
				break;
			}
			}
		}
		if (p1.z0rek("border") || p1.z0rek("dc_surroundings"))
		{
			DocumentContentStyle documentContentStyle = z0yek(p1, p1.z0tek(), p0, p1.z0yek());
			if (p1.z0rek("border"))
			{
				documentContentStyle.BorderWidth = z0tek(p3, 0);
				documentContentStyle.BorderLeft = true;
				documentContentStyle.BorderTop = true;
				documentContentStyle.BorderRight = true;
				documentContentStyle.BorderBottom = true;
			}
			if (p1.z0rek("dc_surroundings") && text2 == "true")
			{
				string text32 = p1.z0tek().z0uek("float");
				if (text32 != null && text32.Trim() == "right")
				{
					documentContentStyle.Align = DocumentContentAlignment.Right;
				}
				documentContentStyle.LayoutAlign = ContentLayoutAlign.Surroundings;
			}
			p0.z0yek(documentContentStyle);
		}
		else
		{
			p0.z0buk = z0tek(p1, p1.z0tek(), p0, p1.z0yek());
		}
		if (flag)
		{
			DocumentComment documentComment = new DocumentComment();
			documentComment.z0pek(z0ZzZzhbk2.z0eek("commenttext"));
			DateTime result = z0ZzZzkfh.z0wrk;
			if (DateTime.TryParse(z0ZzZzhbk2.z0eek("commentcreationtime"), out result))
			{
				documentComment.z0eek(result);
			}
			documentComment.z0eek(z0ZzZzhbk2.z0eek("commentauthor"));
			documentComment.z0rek(z0ZzZzhbk2.z0eek("commentauthorid"));
			documentComment.z0rek(z0tek(z0ZzZzhbk2.z0eek("combk"), Color.White));
			if (p0.z0jr().Comments == null)
			{
				p0.z0jr().Comments = new z0ZzZzwcj();
			}
			documentComment.z0lrk().z0eek("dccommentbackcolor", z0ZzZzhbk2.z0eek("combk"));
			documentComment.z0lrk().z0eek("dccommentbackcolor2", z0ZzZzhbk2.z0eek("combk2"));
			string text33 = z0ZzZzhbk2.z0eek("refcommentindex");
			int p4 = 0;
			if (int.TryParse(text33, out p4))
			{
				documentComment.z0eek(p4);
			}
			else
			{
				documentComment.z0eek(p0.z0jr().Comments.Count);
			}
			if (p0.z0jr().Comments.z0eek(documentComment.z0tek()) == null)
			{
				p0.z0jr().Comments.Add(documentComment);
			}
			p0.z0xrk().CommentIndex = documentComment.z0tek();
		}
		z0ZzZzxdh z0ZzZzxdh2 = z0tek(p1.z0yek(), p0.z0jr());
		if (z0ZzZzxdh2.z0rek() > 0f)
		{
			p0.Width = z0ZzZzxdh2.z0rek();
		}
		if (z0ZzZzxdh2.z0tek() > 0f)
		{
			p0.Height = z0ZzZzxdh2.z0tek();
		}
		if (!p0.SaveContentInFile)
		{
			p0.z0tek(p2);
			return;
		}
		if (!p0.z0wrk())
		{
			z0ZzZzpmk z0ZzZzpmk2 = null;
			if (!string.IsNullOrEmpty(p0.z0srk()))
			{
				string p5 = p1.z0rek().z0tek(p0.z0srk());
				p0.z0yek(null);
				z0ZzZzpmk2 = z0tek(p0, p5);
			}
			if ((p0.z0frk() == null || !p0.z0frk().HasContent) && p1.z0rek("src"))
			{
				byte[] array = z0yek(p2);
				if (array != null)
				{
					z0ZzZzpmk2 = new z0ZzZzpmk(array, p1: false);
				}
				else
				{
					p2 = p1.z0rek().z0tek(p2);
					z0ZzZzpmk2 = z0tek(p0, p2);
				}
				if (text != null && text.Length > 0)
				{
					z0ZzZzpmk2.ImageDataBase64String = text;
				}
			}
			if (z0ZzZzpmk2 != null && !p0.z0mrk())
			{
				p0.z0rek(z0ZzZzpmk2);
			}
			else if (z0ZzZzpmk2 != null && p0.z0mrk())
			{
				XTextDocument xTextDocument = p0.z0jr();
				bool flag2 = true;
				foreach (RepeatedImageValue item2 in xTextDocument.z0nmk())
				{
					if (item2.ImageDataBase64String == z0ZzZzpmk2.ImageDataBase64String)
					{
						p0.z0rek(item2.ValueIndex);
						flag2 = false;
						break;
					}
				}
				if (flag2)
				{
					RepeatedImageValue repeatedImageValue = new RepeatedImageValue(z0ZzZzpmk2);
					repeatedImageValue.ValueIndex = xTextDocument.z0nmk().ItemCount;
					xTextDocument.z0nmk().Add(repeatedImageValue);
				}
			}
		}
		if (p0.Width == 0f || p0.Height == 0f)
		{
			p0.z0eek(p0: false);
		}
		if (p0.z0frk() != null && (p0.Width == 0f || p0.Height == 0f))
		{
			p0.Width = z0ZzZzrpk.z0eek(p0.z0frk().Width, GraphicsUnit.Pixel, GraphicsUnit.Document);
			p0.Height = z0ZzZzrpk.z0eek(p0.z0frk().Height, GraphicsUnit.Pixel, GraphicsUnit.Document);
		}
	}

	private void z0tek(XTextControlHostElement p0, z0ZzZzajh p1)
	{
		p0.Parameters = new ObjectParameterList();
		z0tek(p1.z0yek(), p0);
		z0ZzZzxdh z0ZzZzxdh2 = z0tek(p1.z0yek(), p0.z0jr());
		if (z0ZzZzxdh2.z0rek() > 0f)
		{
			p0.Width = z0ZzZzxdh2.z0rek();
		}
		if (z0ZzZzxdh2.z0tek() > 0f)
		{
			p0.Height = z0ZzZzxdh2.z0tek();
		}
		using zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = p1.z0uek().z0ltk();
		while (z0bpk.MoveNext())
		{
			z0ZzZzhbk current = z0bpk.Current;
			if (current.z0cak() == "param")
			{
				ObjectParameter objectParameter = new ObjectParameter();
				objectParameter.Name = current.z0eek("name");
				objectParameter.Value = current.z0eek("value");
				p0.Parameters.Add(objectParameter);
			}
		}
	}

	private static byte[] z0yek(string p0)
	{
		if (p0 != null && p0.Length > 255 && p0.StartsWith(z0krk, StringComparison.CurrentCultureIgnoreCase))
		{
			int num = p0.IndexOf(z0ork, StringComparison.CurrentCultureIgnoreCase);
			if (num > 0)
			{
				return Convert.FromBase64String(p0.Substring(num + 7).Trim());
			}
		}
		return null;
	}

	private static T z0rek<T>(string p0) where T : Enum
	{
		if (p0 == "null")
		{
			return default(T);
		}
		if (string.IsNullOrEmpty(p0))
		{
			return default(T);
		}
		try
		{
			return zzz.z0ZzZzcyk<T>.z0eek(p0);
		}
		catch (Exception)
		{
			return default(T);
		}
	}

	private static bool z0tek(string p0, ref float p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return false;
		}
		if (string.Equals(p0, "1px", StringComparison.OrdinalIgnoreCase))
		{
			p1 = 1f;
			return true;
		}
		p0 = p0.Trim().ToLower();
		switch (p0)
		{
		case "medium":
		case "thin":
			p1 = 1f;
			return true;
		case "thick":
			p1 = 2f;
			return true;
		default:
			p1 = z0uek(p0, 1f);
			return true;
		}
	}

	private void z0tek(XTextTDBarcodeElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		foreach (z0ZzZzunk item in p1.z0yek().z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "dc_printvisibility":
			{
				string text10 = item.z0yek();
				if (text10 != null && text10.Length > 0)
				{
					p0.PrintVisibility = z0rek<ElementVisibility>(text10);
				}
				break;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(item);
				break;
			case "dc_barcodetype":
			{
				string text4 = item.z0yek();
				if (text4 != null && text4.Length > 0 && text4 != "QR")
				{
					p0.BarcodeType = z0rek<DCTDBarcodeType>(text4);
				}
				break;
			}
			case "dc_contentreadonly":
			{
				string text17 = item.z0yek();
				if (text17 != null && text17.Length > 0 && text17 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text17, ContentReadonlyState.Inherit);
				}
				break;
			}
			case "dc_deleteable":
			{
				string text18 = item.z0yek();
				if (text18 != null && text18.Length > 0 && text18 != "true")
				{
					p0.Deleteable = z0tek(text18, p1: false);
				}
				break;
			}
			case "dc_enabled":
			{
				string text6 = item.z0yek();
				if (text6 != null && text6.Length > 0 && text6 != "true")
				{
					p0.Enabled = z0tek(text6, p1: false);
				}
				break;
			}
			case "dc_erroecorrectionlevel":
			{
				string text14 = item.z0yek();
				if (text14 != null && text14.Length > 0 && text14 != "M")
				{
					p0.ErroeCorrectionLevel = z0rek<DCTBErroeCorrectionLevelType>(text14);
				}
				break;
			}
			case "dc_height":
			{
				string text9 = item.z0yek();
				if (text9 != null && text9.Length > 0)
				{
					p0.Height = z0pek(text9);
				}
				break;
			}
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "dc_linkinfo":
			{
				string text2 = item.z0yek();
				if (text2 != null && text2.Length > 0)
				{
					((XTextObjectElement)p0).z0eek(new z0ZzZzbuk());
					z0ZzZzmik.z0eek(p0.z0iek(), text2);
				}
				break;
			}
			case "dc_name":
			{
				string text15 = item.z0yek();
				if (text15 != null && text15.Length > 0)
				{
					p0.Name = text15;
				}
				break;
			}
			case "dc_propertyexpressions":
			{
				string text12 = item.z0yek();
				if (text12 != null && text12.Length > 0)
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text12);
				}
				break;
			}
			case "dc_strictmatchpageindex":
			{
				string text7 = item.z0yek();
				if (text7 != null && text7.Length > 0 && text7 != "false")
				{
					p0.StrictMatchPageIndex = z0tek(text7, p1: false);
				}
				break;
			}
			case "dc_stringtag":
			{
				string text3 = item.z0yek();
				if (text3 != null && text3.Length > 0)
				{
					p0.StringTag = text3;
				}
				break;
			}
			case "dc_valign":
			{
				string text16 = item.z0yek();
				if (text16 != null && text16.Length > 0 && text16 != "Bottom")
				{
					p0.VAlign = z0rek<VerticalAlignStyle>(text16);
				}
				break;
			}
			case "dc_valuebinding":
			{
				string text13 = item.z0yek();
				if (text13 != null && text13.Length > 0)
				{
					p0.ValueBinding = new z0ZzZzevj();
					((z0ZzZzcuk)p0.ValueBinding).DCReadString(text13);
				}
				break;
			}
			case "dc_valueexpression":
			{
				string text11 = item.z0yek();
				if (text11 != null && text11.Length > 0)
				{
					p0.ValueExpression = text11;
				}
				break;
			}
			case "text":
			{
				string text8 = item.z0yek();
				if (text8 != null && text8.Length > 0)
				{
					p0.Text = text8;
				}
				break;
			}
			case "height":
			{
				string text5 = item.z0yek();
				if (text5 != null && text5.Length > 0)
				{
					float p3 = 0f / 0f;
					text5 = text5.Replace("px", string.Empty);
					if (float.TryParse(text5, out p3))
					{
						p0.Height = z0ZzZzrpk.z0eek(p3, GraphicsUnit.Pixel, GraphicsUnit.Document);
					}
				}
				break;
			}
			case "width":
			{
				string text = item.z0yek();
				if (text != null && text.Length > 0)
				{
					float p2 = 0f / 0f;
					text = text.Replace("px", string.Empty);
					if (float.TryParse(text, out p2))
					{
						p0.Width = z0ZzZzrpk.z0eek(p2, GraphicsUnit.Pixel, GraphicsUnit.Document);
					}
				}
				break;
			}
			}
		}
		z0tek(p1.z0yek(), p0);
	}

	private void z0tek(XTextInputFieldElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		p0.InnerValue = null;
		z0ZzZzhbk obj = p1.z0yek();
		string text = "";
		string text2 = "";
		string text3 = "";
		bool flag = false;
		z0ZzZzdvj z0ZzZzdvj2 = null;
		bool flag2 = false;
		foreach (z0ZzZzunk item in obj.z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "dc_printvisibility":
			{
				string text50 = item.z0yek();
				if (!string.IsNullOrEmpty(text50))
				{
					p0.PrintVisibility = z0rek<ElementVisibility>(text50);
				}
				continue;
			}
			case "dc_listvalueformatstring":
			{
				string text24 = item.z0yek();
				if (!string.IsNullOrEmpty(text24))
				{
					if (p0.FieldSettings == null)
					{
						p0.FieldSettings = new InputFieldSettings();
					}
					p0.FieldSettings.z0rek(text24);
				}
				continue;
			}
			case "dc_dynamiclistitems":
			{
				string text21 = item.z0yek();
				if (text21 != null && text21.ToLower() == "true")
				{
					if (p0.FieldSettings == null)
					{
						p0.FieldSettings = new InputFieldSettings();
					}
					p0.FieldSettings.z0uek(p0: true);
				}
				continue;
			}
			case "dc_getvalueorderbytime":
			{
				string text41 = item.z0yek();
				if (text41 != null && text41.ToLower() == "true")
				{
					if (p0.FieldSettings == null)
					{
						p0.FieldSettings = new InputFieldSettings();
					}
					p0.FieldSettings.z0tek(p0: true);
				}
				continue;
			}
			case "dc_accepttab":
			{
				string text10 = item.z0yek();
				if (!string.IsNullOrEmpty(text10) && text10 != "false")
				{
					p0.AcceptTab = z0tek(text10, p1: false);
				}
				continue;
			}
			case "dc_adorntexttype":
			{
				string text34 = item.z0yek();
				if (!string.IsNullOrEmpty(text34) && text34 != "Default")
				{
					p0.z0eek(z0rek<InputFieldAdornTextType>(text34));
				}
				continue;
			}
			case "dc_alignment":
			{
				string text67 = item.z0yek();
				if (!string.IsNullOrEmpty(text67))
				{
					if (text67 == "Near")
					{
						p0.Alignment = StringAlignment.Near;
					}
					else
					{
						p0.Alignment = z0rek<StringAlignment>(text67);
					}
				}
				continue;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(item);
				continue;
			case "dc_autosetspellcodeindropdownlist":
				p0.z0yek(z0tek(item.z0yek(), p1: false));
				continue;
			case "dc_backgroundtext":
			{
				string text47 = item.z0yek();
				if (!string.IsNullOrEmpty(text47))
				{
					p0.BackgroundText = text47;
				}
				continue;
			}
			case "dc_backgroundtextcolor":
			{
				string text32 = item.z0yek();
				if (!string.IsNullOrEmpty(text32) && text32 != "Color.Transparent")
				{
					p0.BackgroundTextColor = z0ZzZzzij.z0eek(text32, Color.Black);
				}
				continue;
			}
			case "dc_backgroundtextitalic":
			{
				string text15 = item.z0yek();
				if (!string.IsNullOrEmpty(text15) && text15 != "Default")
				{
					((XTextFieldElementBase)p0).z0eek(z0rek<DCBooleanValueHasDefault>(text15));
				}
				continue;
			}
			case "dc_borderelementcolor":
			{
				string text6 = item.z0yek();
				if (!string.IsNullOrEmpty(text6))
				{
					p0.BorderElementColor = z0ZzZzzij.z0eek(text6, Color.Black);
				}
				continue;
			}
			case "dc_bordertextposition":
			{
				string text58 = item.z0yek();
				if (!string.IsNullOrEmpty(text58) && text58 != "Middle")
				{
					p0.z0eek(z0rek<z0ZzZzscj>(text58));
				}
				continue;
			}
			case "dc_bordervisible":
			{
				string text48 = item.z0yek();
				if (!string.IsNullOrEmpty(text48) && text48 != "Default")
				{
					p0.BorderVisible = z0rek<DCVisibleState>(text48);
				}
				continue;
			}
			case "dc_bringouttosave":
			{
				string text38 = item.z0yek();
				if (!string.IsNullOrEmpty(text38) && text38 != "false")
				{
					p0.z0st(z0tek(text38, p1: false));
				}
				continue;
			}
			case "dc_canbereferenced":
			{
				string text27 = item.z0yek();
				if (!string.IsNullOrEmpty(text27) && text27 != "false")
				{
					p0.z0jt(z0tek(text27, p1: false));
				}
				continue;
			}
			case "dc_contentreadonly":
			{
				string text20 = item.z0yek();
				if (!string.IsNullOrEmpty(text20) && text20 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text20, ContentReadonlyState.Inherit);
				}
				continue;
			}
			case "dc_contentreadonlyexpression":
			{
				string text16 = item.z0yek();
				if (!string.IsNullOrEmpty(text16))
				{
					p0.ContentReadonlyExpression = text16;
				}
				continue;
			}
			case "dc_copysource":
			{
				string text8 = item.z0yek();
				if (!string.IsNullOrEmpty(text8))
				{
					p0.CopySource = new CopySourceInfo();
					((z0ZzZzcuk)p0.CopySource).DCReadString(text8);
				}
				continue;
			}
			case "dc_deleteable":
			{
				string text66 = item.z0yek();
				if (!string.IsNullOrEmpty(text66) && text66 != "true")
				{
					p0.Deleteable = z0tek(text66, p1: false);
				}
				continue;
			}
			case "dc_displayformat":
			{
				string text62 = item.z0yek();
				if (!string.IsNullOrEmpty(text62))
				{
					p0.DisplayFormat = new z0ZzZzsok();
					((z0ZzZzcuk)p0.DisplayFormat).DCReadString(text62);
				}
				continue;
			}
			case "dc_editoractivemode":
			{
				string text55 = item.z0yek();
				if (!string.IsNullOrEmpty(text55) && text55 != "Program, F2, MouseDblClick")
				{
					p0.EditorActiveMode = z0rek<ValueEditorActiveMode>(text55);
				}
				continue;
			}
			case "dc_editorcontroltypename":
			{
				string text52 = item.z0yek();
				if (!string.IsNullOrEmpty(text52))
				{
					p0.z0yek(text52);
				}
				continue;
			}
			case "dc_enablefieldtextcolor":
			{
				string text43 = item.z0yek();
				if (!string.IsNullOrEmpty(text43) && text43 != "true")
				{
					p0.z0iek(z0tek(text43, p1: false));
				}
				continue;
			}
			case "dc_enablehighlight":
			{
				string text36 = item.z0yek();
				if (!string.IsNullOrEmpty(text36) && text36 != "Enabled")
				{
					p0.EnableHighlight = z0rek<EnableState>(text36);
				}
				continue;
			}
			case "dc_enablepermission":
			{
				string text28 = item.z0yek();
				if (!string.IsNullOrEmpty(text28) && text28 != "Inherit")
				{
					p0.EnablePermission = z0rek<DCBooleanValue>(text28);
				}
				continue;
			}
			case "dc_enableusereditinnervalue":
			{
				string text22 = item.z0yek();
				if (!string.IsNullOrEmpty(text22) && text22 != "true")
				{
					p0.z0oek(z0tek(text22, p1: false));
				}
				continue;
			}
			case "dc_enablevalueeditor":
			{
				string text17 = item.z0yek();
				if (!string.IsNullOrEmpty(text17) && text17 != "true")
				{
					p0.z0uek(z0tek(text17, p1: false));
				}
				continue;
			}
			case "dc_enablevaluevalidate":
			{
				string text12 = item.z0yek();
				if (!string.IsNullOrEmpty(text12) && text12 != "false")
				{
					p0.EnableValueValidate = z0tek(text12, p1: false);
				}
				continue;
			}
			case "dc_endbordertext":
			{
				string text13 = item.z0yek();
				if (!string.IsNullOrEmpty(text13))
				{
					p0.EndBorderText = text13;
				}
				continue;
			}
			case "dc_fastinputmode":
			{
				string text5 = item.z0yek();
				if (!string.IsNullOrEmpty(text5) && text5 != "NextField")
				{
					p0.z0eek(z0rek<DCFastInputMode>(text5));
				}
				continue;
			}
			case "dc_formbuttonstyle":
			{
				string text64 = item.z0yek();
				if (!string.IsNullOrEmpty(text64) && text64 != "Auto")
				{
					p0.z0eek(z0rek<FormButtonStyle>(text64));
				}
				continue;
			}
			case "id":
				z0yek(p0, item.z0yek());
				continue;
			case "dc_innereditstyle":
			{
				string text60 = item.z0yek();
				if (!string.IsNullOrEmpty(text60) && text60 != "Text")
				{
					p0.z0eek(z0rek<InputFieldEditStyle>(text60));
				}
				continue;
			}
			case "dc_inneritemspliter":
			{
				string text56 = item.z0yek();
				if (!string.IsNullOrEmpty(text56) && text56 != ",")
				{
					p0.z0rek(text56);
				}
				continue;
			}
			case "dc_innerlistsourcename":
			{
				string text53 = item.z0yek();
				if (!string.IsNullOrEmpty(text53))
				{
					p0.z0uek(text53);
				}
				continue;
			}
			case "dc_repulsionforgroup":
			{
				string text45 = item.z0yek();
				if (!string.IsNullOrEmpty(text45) && text45 != "false")
				{
					if (p0.FieldSettings == null)
					{
						p0.FieldSettings = new InputFieldSettings();
					}
					p0.FieldSettings.z0yek(z0tek(text45, p1: false));
				}
				continue;
			}
			case "dc_innermultiselect":
			{
				string text40 = item.z0yek();
				if (!string.IsNullOrEmpty(text40) && text40 != "false")
				{
					p0.z0eek(z0tek(text40, p1: false));
				}
				continue;
			}
			case "ircr":
			{
				string text33 = item.z0yek();
				if (!string.IsNullOrEmpty(text33) && text33 != "false")
				{
					p0.z0xek(z0tek(text33, p1: false));
				}
				continue;
			}
			case "dc_innervalue":
			{
				string text31 = item.z0yek();
				if (!string.IsNullOrEmpty(text31))
				{
					p0.InnerValue = text31;
				}
				continue;
			}
			case "dc_labeltext":
			{
				string text29 = item.z0yek();
				if (!string.IsNullOrEmpty(text29))
				{
					p0.LabelText = text29;
				}
				continue;
			}
			case "dc_limitedinputchars":
			{
				string text30 = item.z0yek();
				if (!string.IsNullOrEmpty(text30))
				{
					p0.LimitedInputChars = text30;
				}
				continue;
			}
			case "dc_linklistbinding":
			{
				string text26 = item.z0yek();
				if (!string.IsNullOrEmpty(text26))
				{
					p0.z0eek(new z0ZzZzfvj());
					((z0ZzZzcuk)p0.z0nek()).DCReadString(text26);
				}
				continue;
			}
			case "dc_maxinputlength":
			{
				string text23 = item.z0yek();
				if (!string.IsNullOrEmpty(text23) && text23 != "0")
				{
					p0.MaxInputLength = z0tek(text23, 0);
				}
				continue;
			}
			case "dc_movefocushotkey":
			{
				string text19 = item.z0yek();
				if (!string.IsNullOrEmpty(text19) && text19 != "Default")
				{
					p0.MoveFocusHotKey = z0rek<MoveFocusHotKeys>(text19);
				}
				continue;
			}
			case "dc_name":
			{
				string text18 = item.z0yek();
				if (!string.IsNullOrEmpty(text18))
				{
					p0.Name = text18;
				}
				continue;
			}
			case "dc_printbackgroundtext":
			{
				string text14 = item.z0yek();
				if (!string.IsNullOrEmpty(text14) && text14 != "Inherit")
				{
					((XTextInputFieldElementBase)p0).z0eek(z0rek<DCBooleanValue>(text14));
				}
				continue;
			}
			case "dc_propertyexpressions":
			{
				string text11 = item.z0yek();
				if (!string.IsNullOrEmpty(text11))
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text11);
				}
				continue;
			}
			case "rbtc":
			{
				string text9 = item.z0yek();
				if (!string.IsNullOrEmpty(text9))
				{
					((XTextFieldElementBase)p0).z0eek(z0ZzZzzij.z0eek(text9, Color.Black));
				}
				continue;
			}
			case "rmfhk":
			{
				string text7 = item.z0yek();
				if (!string.IsNullOrEmpty(text7) && text7 != "None")
				{
					p0.z0yr(z0rek<MoveFocusHotKeys>(text7));
				}
				continue;
			}
			case "dc_showformbutton":
			{
				string text4 = item.z0yek();
				if (!string.IsNullOrEmpty(text4) && text4 != "Inherit")
				{
					p0.z0eek(z0rek<DCBooleanValue>(text4));
				}
				continue;
			}
			case "dc_showinputfieldstatetag":
			{
				string text65 = item.z0yek();
				if (!string.IsNullOrEmpty(text65) && text65 != "Inherit")
				{
					p0.z0rek(z0rek<DCBooleanValue>(text65));
				}
				continue;
			}
			case "dc_specifywidth":
			{
				string text63 = item.z0yek();
				if (!string.IsNullOrEmpty(text63) && text63 != "0f")
				{
					p0.SpecifyWidth = z0pek(text63);
				}
				continue;
			}
			case "dc_specifywidthinpixel":
			{
				string text61 = item.z0yek();
				if (!string.IsNullOrEmpty(text61) && text61 != "0f")
				{
					float p2 = z0pek(text61);
					p0.SpecifyWidth = z0ZzZzrpk.z0eek(p2, GraphicsUnit.Pixel, GraphicsUnit.Document);
				}
				continue;
			}
			case "dc_startbordertext":
			{
				string text59 = item.z0yek();
				if (!string.IsNullOrEmpty(text59))
				{
					p0.StartBorderText = text59;
				}
				continue;
			}
			case "dc_tabindex":
			{
				string text57 = item.z0yek();
				if (!string.IsNullOrEmpty(text57) && text57 != "0")
				{
					p0.TabIndex = z0tek(text57, 0);
				}
				continue;
			}
			case "dc_tabstop":
			{
				string text54 = item.z0yek();
				if (!string.IsNullOrEmpty(text54) && text54 != "true")
				{
					p0.TabStop = z0tek(text54, p1: false);
				}
				continue;
			}
			case "dc_textcolor":
			{
				string text51 = item.z0yek();
				if (!string.IsNullOrEmpty(text51) && text51 != "Color.Transparent")
				{
					p0.TextColor = z0ZzZzzij.z0eek(text51, Color.Black);
				}
				continue;
			}
			case "dc_unittext":
			{
				string text49 = item.z0yek();
				if (!string.IsNullOrEmpty(text49))
				{
					p0.UnitText = text49;
				}
				continue;
			}
			case "dc_usereditable":
			{
				string text46 = item.z0yek();
				if (!string.IsNullOrEmpty(text46) && text46 != "true")
				{
					p0.UserEditable = z0tek(text46, p1: false);
				}
				continue;
			}
			case "dc_validatestyle":
			{
				string text44 = item.z0yek();
				if (!string.IsNullOrEmpty(text44))
				{
					text44 = text44.Replace("'", "\"");
					p0.ValidateStyle = new ValueValidateStyle();
					((z0ZzZzcuk)p0.ValidateStyle).DCReadString(text44);
				}
				continue;
			}
			case "dc_valuebinding":
			{
				string text42 = item.z0yek();
				if (!string.IsNullOrEmpty(text42))
				{
					p0.ValueBinding = new z0ZzZzevj();
					((z0ZzZzcuk)p0.ValueBinding).DCReadString(text42);
				}
				continue;
			}
			case "dc_viewencrypttype":
				p0.ViewEncryptType = z0eek(item.z0yek(), ContentViewEncryptType.None);
				continue;
			case "dc_visible":
			{
				string text39 = item.z0yek();
				if (!string.IsNullOrEmpty(text39) && text39 != "true")
				{
					p0.Visible = z0tek(text39, p1: false);
				}
				continue;
			}
			case "dc_visibleexpression":
			{
				string text37 = item.z0yek();
				if (!string.IsNullOrEmpty(text37))
				{
					p0.VisibleExpression = text37;
				}
				continue;
			}
			case "class":
			{
				string text35 = item.z0yek();
				if (!string.IsNullOrEmpty(text35))
				{
					text = text35;
				}
				continue;
			}
			case "datasourcename":
				if (p0.ValueBinding == null)
				{
					p0.ValueBinding = new z0ZzZzevj();
				}
				p0.ValueBinding.DataSource = item.z0yek();
				continue;
			case "datasourcepath":
				if (p0.ValueBinding == null)
				{
					p0.ValueBinding = new z0ZzZzevj();
				}
				p0.ValueBinding.BindingPath = item.z0yek();
				continue;
			case "placeholder":
				p0.BackgroundText = item.z0yek();
				continue;
			case "name":
				p0.Name = item.z0yek()?.Trim();
				continue;
			case "type":
				if (item.z0yek() != null)
				{
					switch (item.z0yek().Trim().ToLower())
					{
					case "date":
						p0.FieldSettings = new InputFieldSettings();
						p0.FieldSettings.z0eek(InputFieldEditStyle.Date);
						break;
					case "datetime":
						p0.FieldSettings = new InputFieldSettings();
						p0.FieldSettings.z0eek(InputFieldEditStyle.DateTime);
						break;
					case "datetime-local":
						p0.FieldSettings = new InputFieldSettings();
						p0.FieldSettings.z0eek(InputFieldEditStyle.DateTime);
						break;
					case "time":
						p0.FieldSettings = new InputFieldSettings();
						p0.FieldSettings.z0eek(InputFieldEditStyle.Time);
						break;
					}
				}
				continue;
			case "dcselectedindex":
				text2 = item.z0yek();
				continue;
			case "title":
				p0.ToolTip = item.z0yek();
				continue;
			case "bd2019":
			{
				string text25 = item.z0yek();
				if (!string.IsNullOrEmpty(text25))
				{
					text3 = text25;
				}
				continue;
			}
			case "dclisitems":
				if (!z0cek && item.z0yek() != null && item.z0yek().Length > 0)
				{
					flag2 = true;
					if (z0ZzZzdvj2 == null)
					{
						z0ZzZzdvj2 = new z0ZzZzdvj();
					}
					string[] array = z0ZzZzqik.z0eek(item.z0yek(), ':', ';', p3: false);
					int num = array.Length;
					for (int i = 0; i < num; i += 2)
					{
						z0ZzZzdvj2.Add(new ListItem(array[i], array[i + 1]));
					}
				}
				continue;
			}
			if (item.z0yek() == null)
			{
				continue;
			}
			string text68 = item.z0eek();
			if (z0cek || text68[0] != 'l' || text68.Length <= 2 || !char.IsNumber(text68[2]))
			{
				continue;
			}
			char c = text68[1];
			if (c != 't' && c != 'v' && c != 's' && c != 'z' && c != 'g')
			{
				continue;
			}
			int num2 = z0tek(text68, 2, 0);
			if (num2 >= 0)
			{
				if (z0ZzZzdvj2 == null)
				{
					z0ZzZzdvj2 = new z0ZzZzdvj();
				}
				z0ZzZzdvj2.z0ork(num2 + 1);
				ListItem listItem = z0ZzZzdvj2[num2];
				if (listItem == null)
				{
					listItem = (z0ZzZzdvj2[num2] = new ListItem());
				}
				switch (c)
				{
				case 't':
					listItem.Text = item.z0yek();
					break;
				case 'v':
					listItem.Value = item.z0yek();
					break;
				case 'z':
					listItem.TextInList = item.z0yek();
					break;
				case 'g':
					listItem.Group = item.z0yek();
					break;
				}
			}
		}
		if (z0ZzZzdvj2 != null && z0ZzZzdvj2.Count > 0)
		{
			if (!flag2)
			{
				for (int num3 = z0ZzZzdvj2.Count - 1; num3 >= 0; num3--)
				{
					if (z0ZzZzdvj2[num3] == null)
					{
						z0ZzZzdvj2.RemoveAt(num3);
					}
				}
			}
			if (p0.FieldSettings == null)
			{
				p0.FieldSettings = new InputFieldSettings();
			}
			p0.FieldSettings.z0eek(InputFieldEditStyle.DropdownList);
			p0.FieldSettings.z0eek(new z0ZzZzsvj());
			p0.FieldSettings.z0zek().Items = z0ZzZzdvj2;
		}
		p0.ID = z0mek(p0.ID);
		if (text != null && text.Contains("InputFieldModified"))
		{
			p0.Modified = true;
		}
		z0ZzZzevk z0ZzZzevk2 = p1.z0tek();
		if (p1.z0oek() == "input")
		{
			z0ZzZzevk2 = z0ZzZzevk2.z0yek();
			z0ZzZzevk2.z0iek("border");
			z0ZzZzevk2.z0iek("border-left");
			z0ZzZzevk2.z0iek("border-right");
			z0ZzZzevk2.z0iek("border-top");
			z0ZzZzevk2.z0iek("border-bottom");
		}
		p0.z0buk = z0tek(p1, z0ZzZzevk2, p0, p1.z0yek());
		if (p1.z0oek() == "span")
		{
			z0tek((XTextContainerElement)p0, p1);
			if (flag && ((XTextContainerElement)p0).z0xek() == 1 && p0.z0dtk() is XTextCharElement xTextCharElement && XTextCharElement.z0tek(xTextCharElement.z0bek))
			{
				p0.z0be().Clear();
			}
		}
		else if (p1.z0oek() == "input")
		{
			string text69 = z0iek(p1.z0yek());
			if (!string.IsNullOrEmpty(text69))
			{
				XTextStringElement xTextStringElement = new XTextStringElement();
				xTextStringElement.Text = text69;
				xTextStringElement.z0bt(p0.z0jr());
				xTextStringElement.z0yek(z0tek(((XTextElement)p0).z0xrk()));
				p0.z0be().z0hrk(xTextStringElement);
			}
		}
		else if (p1.z0oek() == "textarea")
		{
			string text70 = z0iek(p1.z0yek());
			XTextStringElement xTextStringElement2 = new XTextStringElement();
			xTextStringElement2.Text = text70;
			xTextStringElement2.z0bt(p0.z0jr());
			xTextStringElement2.z0yek(z0tek(((XTextElement)p0).z0xrk()));
			p0.z0be().z0hrk(xTextStringElement2);
		}
		else if (p1.z0oek() == "select")
		{
			p0.z0lrk();
			p0.FieldSettings.z0eek(InputFieldEditStyle.DropdownList);
			string text71 = string.Empty;
			using (zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = p1.z0uek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					z0ZzZzhbk current2 = z0bpk.Current;
					if (!(current2.z0cak() == "option"))
					{
						continue;
					}
					ListItem listItem3 = new ListItem();
					listItem3.Value = current2.z0eek("value");
					listItem3.Text = current2.z0jqk();
					if (listItem3.Text != null)
					{
						listItem3.Text = listItem3.Text.Trim();
					}
					p0.FieldSettings.z0zek().Items.Add(listItem3);
					if (current2.z0eek("selected") == "true")
					{
						if (p0.Text == null || p0.Text.Length == 0)
						{
							p0.Text = listItem3.Text;
						}
						else
						{
							p0.Text = p0.Text + "," + listItem3.Text;
						}
						text71 = ((text71 != null && text71.Length != 0) ? (text71 + "," + listItem3.Value) : listItem3.Value);
					}
				}
			}
			p0.InnerValue = text71;
			if (text2 != null && text2.Length > 0 && !p1.z0rek("multiple"))
			{
				int num4 = 0;
				if (int.TryParse(text2, out num4) && num4 >= 0 && num4 < p0.FieldSettings.z0zek().Items.Count)
				{
					ListItem listItem4 = p0.FieldSettings.z0zek().Items[num4];
					p0.Text = listItem4.Text;
					p0.InnerValue = listItem4.Value;
				}
			}
		}
		else if (p1.z0oek() == "span" || p1.z0oek() == "div")
		{
			z0tek((XTextContainerElement)p0, p1);
		}
		if (text3 != null && text3.Length > 0)
		{
			z0tek(((XTextElement)p0).z0xrk(), text3);
		}
	}

	internal static string z0uek(string p0)
	{
		if (!string.IsNullOrEmpty(p0))
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (char c in p0)
			{
				if (flag && c != '\r')
				{
					stringBuilder.Append('\r');
				}
				flag = c == '\n';
				stringBuilder.Append(c);
			}
			return stringBuilder.ToString();
		}
		return p0;
	}

	private static object z0tek(string p0, object p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		try
		{
			return Enum.Parse(p1.GetType(), p0);
		}
		catch (Exception)
		{
			return p1;
		}
	}

	private static string z0iek(string p0)
	{
		if (p0 != null)
		{
			int num = p0.IndexOf("url(", StringComparison.CurrentCultureIgnoreCase);
			if (num >= 0)
			{
				p0 = p0.Substring(4);
				num = p0.IndexOf(')');
				if (num >= 0)
				{
					p0 = p0.Substring(0, num).Trim();
				}
				return p0;
			}
		}
		return null;
	}

	private void z0tek(XTextCheckBoxElementBase p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		p0.z0cek();
		z0ZzZzhbk z0ZzZzhbk2 = p1.z0yek();
		bool flag = z0ZzZzhbk2.z0rek("attachedcomment") == "DocumentComment";
		XTextDocument xTextDocument = p0.z0jr();
		string text = "";
		foreach (z0ZzZzunk item in z0ZzZzhbk2.z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "dc_captionflowlayout":
				p0.CaptionFlowLayout = z0tek(item.z0yek(), p1: false);
				break;
			case "dc_visible":
			{
				string text6 = item.z0yek();
				if (text6 != null && text6.Length > 0 && text6 != "true")
				{
					p0.Visible = z0tek(text6, p1: false);
				}
				break;
			}
			case "dc_height":
			{
				string text23 = item.z0yek();
				if (text23 != null && text23.Length > 0)
				{
					float num2 = float.Parse(text23);
					if (!float.IsNaN(num2))
					{
						p0.Height = z0ZzZzrpk.z0eek(num2, GraphicsUnit.Pixel, GraphicsUnit.Document);
					}
				}
				break;
			}
			case "dc_width":
			{
				string text15 = item.z0yek();
				if (text15 != null && text15.Length > 0)
				{
					float num = float.Parse(text15);
					if (!float.IsNaN(num))
					{
						p0.Width = z0ZzZzrpk.z0eek(num, GraphicsUnit.Pixel, GraphicsUnit.Document);
					}
				}
				break;
			}
			case "dc_printvisibility":
			{
				string text29 = item.z0yek();
				if (text29 != null && text29.Length > 0)
				{
					p0.PrintVisibility = z0rek<ElementVisibility>(text29);
				}
				break;
			}
			case "dc_printvisibilitywhenunchecked":
			{
				string text13 = item.z0yek();
				if (text13 != null && text13.Length > 0)
				{
					p0.PrintVisibilityWhenUnchecked = z0rek<PrintVisibilityModeWhenUnchecked>(text13);
				}
				break;
			}
			case "dc_printtextforchecked":
			{
				string text32 = item.z0yek();
				if (text32 != null && text32.Length > 0)
				{
					p0.PrintTextForChecked = text32;
				}
				break;
			}
			case "dc_printtextforunchecked":
			{
				string text22 = item.z0yek();
				if (text22 != null && text22.Length > 0)
				{
					p0.PrintTextForUnChecked = text22;
				}
				break;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(item);
				break;
			case "dc_bringouttosave":
			{
				string text4 = item.z0yek();
				if (text4 != null && text4.Length > 0 && text4 != "false")
				{
					p0.BringoutToSave = z0tek(text4, p1: false);
				}
				break;
			}
			case "dc_canbereferenced":
			{
				string text28 = item.z0yek();
				if (text28 != null && text28.Length > 0 && text28 != "false")
				{
					p0.CanBeReferenced = z0tek(text28, p1: false);
				}
				break;
			}
			case "dc_caption":
			{
				string text19 = item.z0yek();
				if (text19 != null && text19.Length > 0)
				{
					p0.Caption = text19;
				}
				break;
			}
			case "dc_captionalign":
			{
				string text9 = item.z0yek();
				if (text9 != null && text9.Length > 0 && text9 != "Center")
				{
					p0.CaptionAlign = z0rek<StringAlignment>(text9);
				}
				break;
			}
			case "dc_checkalignleft":
			{
				string text34 = item.z0yek();
				if (text34 != null && text34.Length > 0 && text34 != "true")
				{
					p0.CheckAlignLeft = z0tek(text34, p1: false);
				}
				break;
			}
			case "dc_checkboxvisibility":
			{
				string text26 = item.z0yek();
				if (text26 != null && text26.Length > 0 && text26 != "All")
				{
					p0.CheckboxVisibility = z0rek<RenderVisibility>(text26);
				}
				break;
			}
			case "dc_contentreadonly":
			{
				string text18 = item.z0yek();
				if (text18 != null && text18.Length > 0 && text18 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text18, ContentReadonlyState.Inherit);
				}
				break;
			}
			case "dc_controlstyle":
			{
				string text10 = item.z0yek();
				if (text10 != null && text10.Length > 0 && text10 != "CheckBox")
				{
					p0.z0ii(z0rek<CheckBoxControlStyle>(text10));
				}
				break;
			}
			case "dc_deleteable":
			{
				string text35 = item.z0yek();
				if (text35 != null && text35.Length > 0 && text35 != "true")
				{
					p0.Deleteable = z0tek(text35, p1: false);
				}
				break;
			}
			case "dc_enabled":
			{
				string text31 = item.z0yek();
				if (text31 != null && text31.Length > 0 && text31 != "true")
				{
					p0.Enabled = z0tek(text31, p1: false);
				}
				break;
			}
			case "dc_enablehighlight":
			{
				string text25 = item.z0yek();
				if (text25 != null && text25.Length > 0 && text25 != "Enabled")
				{
					p0.EnableHighlight = z0rek<EnableState>(text25);
				}
				break;
			}
			case "dc_id":
			{
				string text20 = item.z0yek();
				if (text20 != null && text20.Length > 0)
				{
					p0.ID = text20;
				}
				break;
			}
			case "dc_linkinfo":
			{
				string text16 = item.z0yek();
				if (text16 != null && text16.Length > 0)
				{
					((XTextObjectElement)p0).z0eek(new z0ZzZzbuk());
					z0ZzZzmik.z0eek(((XTextObjectElement)p0).z0iek(), text16);
				}
				break;
			}
			case "dc_multiline":
			{
				string text12 = item.z0yek();
				if (text12 != null && text12.Length > 0 && text12 != "false")
				{
					p0.Multiline = z0tek(text12, p1: false);
				}
				break;
			}
			case "dc_name":
			{
				string text7 = item.z0yek();
				if (text7 != null && text7.Length > 0)
				{
					p0.Name = text7;
				}
				break;
			}
			case "dc_propertyexpressions":
			{
				string text3 = item.z0yek();
				if (text3 != null && text3.Length > 0)
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text3);
				}
				break;
			}
			case "dc_requried":
			{
				string text33 = item.z0yek();
				if (text33 != null && text33.Length > 0 && text33 != "false")
				{
					p0.Requried = z0tek(text33, p1: false);
				}
				break;
			}
			case "dc_stringtag":
			{
				string text30 = item.z0yek();
				if (text30 != null && text30.Length > 0)
				{
					p0.StringTag = text30;
				}
				break;
			}
			case "dc_tooltip":
			{
				string text27 = item.z0yek();
				if (text27 != null && text27.Length > 0)
				{
					p0.ToolTip = text27;
				}
				break;
			}
			case "dc_valuebinding":
			{
				string text24 = item.z0yek();
				if (text24 != null && text24.Length > 0)
				{
					p0.ValueBinding = new z0ZzZzevj();
					((z0ZzZzcuk)p0.ValueBinding).DCReadString(text24);
				}
				break;
			}
			case "dc_valueexpression":
			{
				string text21 = item.z0yek();
				if (text21 != null && text21.Length > 0)
				{
					p0.ValueExpression = text21;
				}
				break;
			}
			case "dc_visualstyle":
			{
				string text17 = item.z0yek();
				if (text17 != null && text17.Length > 0 && text17 != "Default")
				{
					p0.VisualStyle = z0rek<CheckBoxVisualStyle>(text17);
				}
				break;
			}
			case "dc_autoheightformultiline":
			{
				string text14 = item.z0yek();
				if (text14 != null && text14.Length > 0 && text14 != "false")
				{
					p0.AutoHeightForMultiline = z0tek(text14, p1: false);
				}
				break;
			}
			case "name":
			{
				string text11 = item.z0yek();
				if (text11 != null && text11.Length > 0)
				{
					p0.Name = text11;
				}
				break;
			}
			case "title":
			{
				string text8 = item.z0yek();
				if (text8 != null && text8.Length > 0)
				{
					p0.ToolTip = text8;
				}
				break;
			}
			case "dc_checkedvalue":
			{
				string text5 = item.z0yek();
				if (text5 != null && text5.Length > 0)
				{
					p0.CheckedValue = text5;
				}
				break;
			}
			case "checked":
			{
				string text2 = item.z0yek();
				if (text2 != null && text2.Length > 0)
				{
					text = text2;
				}
				break;
			}
			}
		}
		z0tek(p1.z0yek(), p0);
		p0.z0buk = z0tek(p1, p1.z0tek(), p0, p1.z0yek());
		if (p1.z0rek("checked"))
		{
			if (text == "false")
			{
				p0.Checked = false;
			}
			else
			{
				p0.Checked = true;
			}
		}
		else
		{
			p0.Checked = false;
		}
		if (p1.z0rek("disabled"))
		{
			p0.Readonly = true;
		}
		if (flag)
		{
			DocumentComment documentComment = new DocumentComment();
			documentComment.z0pek(z0ZzZzhbk2.z0eek("commenttext"));
			DateTime result = z0ZzZzkfh.z0wrk;
			if (DateTime.TryParse(z0ZzZzhbk2.z0eek("commentcreationtime"), out result))
			{
				documentComment.z0eek(result);
			}
			documentComment.z0eek(z0ZzZzhbk2.z0eek("commentauthor"));
			documentComment.z0rek(z0ZzZzhbk2.z0eek("commentauthorid"));
			documentComment.z0rek(z0tek(z0ZzZzhbk2.z0eek("combk"), Color.White));
			if (xTextDocument.Comments == null)
			{
				xTextDocument.Comments = new z0ZzZzwcj();
			}
			documentComment.z0lrk().z0eek("dccommentbackcolor", z0ZzZzhbk2.z0eek("combk"));
			documentComment.z0lrk().z0eek("dccommentbackcolor2", z0ZzZzhbk2.z0eek("combk2"));
			string text36 = z0ZzZzhbk2.z0eek("refcommentindex");
			int p2 = 0;
			if (int.TryParse(text36, out p2))
			{
				documentComment.z0eek(p2);
			}
			else
			{
				documentComment.z0eek(xTextDocument.Comments.Count);
			}
			if (xTextDocument.Comments.z0eek(documentComment.z0tek()) == null)
			{
				xTextDocument.Comments.Add(documentComment);
			}
			p0.z0xrk().CommentIndex = documentComment.z0tek();
		}
	}

	private void z0tek(string p0, ref float p1, ref DashStyle p2, ref Color p3)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return;
		}
		if (string.Equals(p0, "none", StringComparison.OrdinalIgnoreCase))
		{
			p1 = 0f;
			p2 = DashStyle.Solid;
			p3 = Color.Black;
			return;
		}
		object[] array = null;
		if (z0nrk.TryGetValue(p0, out array))
		{
			p1 = (float)array[0];
			p2 = (DashStyle)array[1];
			p3 = (Color)array[2];
			return;
		}
		string[] array2 = z0tek(p0);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (array2 != null)
		{
			string[] array3 = array2;
			foreach (string p4 in array3)
			{
				if (!flag && z0tek(p4, ref p1))
				{
					flag = true;
				}
				else if (!flag2 && z0tek(p4, out p2))
				{
					if (p2 == DashStyle.Custom)
					{
						p2 = DashStyle.Solid;
						p1 = 0f;
						break;
					}
					flag2 = true;
				}
				else if (!flag3 && z0tek(p4, out p3))
				{
					flag3 = true;
				}
				if (flag3 && flag2 && flag3)
				{
					break;
				}
			}
		}
		z0nrk[p0] = new object[3] { p1, p2, p3 };
	}

	internal void z0tek(z0ZzZzajh p0, DocumentContentStyle p1, string p2, string p3, XTextElement p4)
	{
		switch (p2)
		{
		case "font-family":
			if (string.IsNullOrEmpty(p3))
			{
				return;
			}
			if (z0wrk)
			{
				string text2 = z0nek(p3);
				if (!string.IsNullOrEmpty(text2))
				{
					p1.z0eek(text2);
				}
			}
			else
			{
				p1.z0eek(p3.Trim());
			}
			return;
		case "font-size":
			if (!p1.z0grk)
			{
				float p5 = 0f;
				if (z0tek(p0, p3, out p5))
				{
					p1.FontSize = z0ZzZzrpk.z0eek(p5, GraphicsUnit.Document, GraphicsUnit.Point);
				}
			}
			return;
		case "font-style":
			if (!string.IsNullOrEmpty(p3) && p3 != "normal")
			{
				if (p3 == "italic" || p3 == "oblique")
				{
					p1.Italic = true;
				}
				else if (p3.Contains("italic", StringComparison.OrdinalIgnoreCase) || p3.Contains("oblique", StringComparison.OrdinalIgnoreCase))
				{
					p1.Italic = true;
				}
			}
			return;
		case "font-weight":
			if (!string.IsNullOrEmpty(p3) && p3 != "normal")
			{
				if (p3 == "bold" || p3 == "700")
				{
					p1.Bold = true;
				}
				else if (p3.Contains("bold", StringComparison.OrdinalIgnoreCase))
				{
					p1.Bold = true;
				}
				else if (p3.Contains("700", StringComparison.OrdinalIgnoreCase))
				{
					p1.Bold = true;
				}
			}
			return;
		case "text-decoration":
		{
			if (p3 == null || !(p3 != "none"))
			{
				return;
			}
			if (p3 == "underline")
			{
				p1.Underline = true;
				return;
			}
			if (p3 == "line-through")
			{
				p1.Strikeout = true;
				return;
			}
			string text = p3.Trim().ToLower();
			if (text == "underline")
			{
				p1.Underline = true;
			}
			else if (text == "line-through")
			{
				p1.Strikeout = true;
			}
			return;
		}
		case "word-wrap":
			return;
		case "word-break":
			return;
		case "direction":
			return;
		case null:
			return;
		}
		DashStyle p37;
		Color p38;
		float p39;
		switch (p2.Length)
		{
		case 12:
			switch (p2[7])
			{
			default:
				return;
			case 'l':
				if (p2 == "logicdeleted")
				{
					XTextDocument xTextDocument = p0.z0iek();
					if (xTextDocument.z0syk().Count == 0)
					{
						z0ZzZzyhh z0ZzZzyhh2 = new z0ZzZzyhh();
						z0ZzZzyhh2.z0tek(Environment.UserName);
						z0ZzZzyhh2.z0uek(Environment.UserName);
						xTextDocument.z0syk().Add(z0ZzZzyhh2);
					}
					p1.DeleterIndex = xTextDocument.z0syk().z0yek();
				}
				return;
			case 'i':
				if (p2 == "commentindex")
				{
					p1.CommentIndex = Convert.ToInt32(p3);
				}
				return;
			case 'r':
				break;
			case 'c':
				if (p2 == "border-color")
				{
					p1.BorderLeft = true;
					p1.BorderTop = true;
					p1.BorderRight = true;
					p1.BorderBottom = true;
					Color[] array2 = z0vek(p3);
					if (array2 != null && array2.Length == 1)
					{
						p1.BorderLeftColor = array2[0];
						p1.BorderTopColor = array2[0];
						p1.BorderRightColor = array2[0];
						p1.BorderBottomColor = array2[0];
					}
					else if (array2 != null && array2.Length == 2)
					{
						p1.BorderTopColor = array2[0];
						p1.BorderBottomColor = array2[0];
						p1.BorderLeftColor = array2[1];
						p1.BorderRightColor = array2[1];
					}
					else if (array2 != null && array2.Length == 3)
					{
						p1.BorderTopColor = array2[0];
						p1.BorderRightColor = array2[1];
						p1.BorderLeftColor = array2[1];
						p1.BorderBottomColor = array2[2];
					}
					else if (array2 != null && array2.Length >= 4)
					{
						p1.BorderTopColor = array2[0];
						p1.BorderRightColor = array2[1];
						p1.BorderBottomColor = array2[2];
						p1.BorderLeftColor = array2[3];
					}
				}
				return;
			case 'w':
				if (p2 == "border-width")
				{
					float p19 = 0f;
					if (z0tek(p3, ref p19))
					{
						p1.BorderWidth = p19;
						p1.BorderLeft = true;
						p1.BorderTop = true;
						p1.BorderRight = true;
						p1.BorderBottom = true;
					}
				}
				return;
			case 's':
			{
				if (!(p2 == "border-style"))
				{
					return;
				}
				DashStyle p18 = DashStyle.Solid;
				if (z0tek(p3, out p18))
				{
					p1.BorderStyle = p18;
					if (p18 == DashStyle.Custom)
					{
						p1.BorderStyle = DashStyle.Solid;
						p1.BorderWidth = 0f;
					}
					p1.BorderLeft = true;
					p1.BorderTop = true;
					p1.BorderRight = true;
					p1.BorderBottom = true;
				}
				return;
			}
			case '-':
				if (p2 == "padding-left")
				{
					float p17 = 0f;
					if (z0tek(p0, p3, out p17))
					{
						p1.PaddingLeft = p17;
					}
				}
				return;
			}
			if (!(p2 == "border-right"))
			{
				break;
			}
			goto IL_0ab4;
		case 6:
			switch (p2[5])
			{
			case 'p':
				if (p2 == "dc_sup")
				{
					p1.Superscript = true;
					p1.Subscript = false;
				}
				break;
			case 'b':
				if (p2 == "dc_sub")
				{
					p1.Superscript = false;
					p1.Subscript = true;
				}
				break;
			case 't':
				if (p2 == "height")
				{
					float p13 = 0f;
					if (z0tek(p0, p3, out p13))
					{
						p1.z0yrk = p13;
					}
				}
				break;
			case 'r':
				if (p2 == "border")
				{
					if (string.Equals(p3, "none", StringComparison.OrdinalIgnoreCase))
					{
						((z0ZzZzcok)p1).z0tek();
						break;
					}
					DashStyle p10 = DashStyle.Solid;
					Color p11 = Color.Empty;
					float p12 = 0f;
					z0tek(p3, ref p12, ref p10, ref p11);
					p1.z0eek(p12, p10, p11);
				}
				break;
			}
			break;
		case 5:
			switch (p2[0])
			{
			case 'w':
				if (p2 == "width")
				{
					float p42 = 0f;
					if (z0tek(p0, p3, out p42))
					{
						p1.z0zek = p42;
					}
				}
				break;
			case 'c':
				if (p2 == "color")
				{
					Color p41 = Color.Empty;
					if (z0tek(p3, out p41))
					{
						p1.Color = p41;
					}
				}
				break;
			}
			break;
		case 10:
		{
			switch (p2[0])
			{
			default:
				return;
			case 'b':
				break;
			case 'f':
				if (p2 == "font-style" && !string.IsNullOrEmpty(p3) && p3 != "normal")
				{
					if (p3 == "italic" || p3 == "oblique")
					{
						p1.Italic = true;
					}
					else if (p3.Contains("italic", StringComparison.OrdinalIgnoreCase) || p3.Contains("oblique", StringComparison.OrdinalIgnoreCase))
					{
						p1.Italic = true;
					}
				}
				return;
			case 't':
				if (!(p2 == "text-align") || string.IsNullOrEmpty(p3))
				{
					return;
				}
				switch (p3)
				{
				case "justify":
					p1.z0eek(DocumentContentAlignment.Justify);
					return;
				case "left":
					p1.z0eek(DocumentContentAlignment.Left);
					return;
				case "center":
					p1.z0eek(DocumentContentAlignment.Center);
					return;
				case "right":
					p1.z0eek(DocumentContentAlignment.Right);
					return;
				}
				if (p3.Contains("left", StringComparison.OrdinalIgnoreCase))
				{
					p1.z0eek(DocumentContentAlignment.Left);
				}
				else if (p3.Contains("right", StringComparison.OrdinalIgnoreCase))
				{
					p1.z0eek(DocumentContentAlignment.Right);
				}
				else if (p3.Contains("center", StringComparison.OrdinalIgnoreCase))
				{
					p1.z0eek(DocumentContentAlignment.Center);
				}
				else if (p3.Contains("justify", StringComparison.OrdinalIgnoreCase))
				{
					p1.z0eek(DocumentContentAlignment.Justify);
				}
				return;
			case 'm':
				if (p2 == "margin-top" && (p4 is XTextParagraphFlagElement || p4 is z0ZzZzwjh))
				{
					float p34 = 0f;
					if (z0tek(p0, p3, out p34))
					{
						p1.SpacingBeforeParagraph = p34;
					}
				}
				return;
			}
			if (!(p2 == "background"))
			{
				if (!(p2 == "border-top"))
				{
					break;
				}
				goto IL_0ab4;
			}
			string[] array3 = z0tek(p3);
			if (array3 == null)
			{
				break;
			}
			string[] array4 = array3;
			foreach (string p35 in array4)
			{
				Color p36 = Color.Empty;
				if (z0iek(p35) == null && z0tek(p35, out p36))
				{
					p1.BackgroundColor = p36;
				}
			}
			break;
		}
		case 16:
			switch (p2[11])
			{
			case 'c':
				if (!(p2 == "background-color"))
				{
					if (p2 == "border-top-color")
					{
						Color p32 = Color.Black;
						if (z0tek(p3, out p32))
						{
							p1.BorderTop = true;
							p1.BorderTopColor = p32;
						}
					}
				}
				else
				{
					Color p33 = Color.Empty;
					if (z0tek(p3, out p33))
					{
						p1.BackgroundColor = p33;
					}
				}
				break;
			case 's':
			{
				if (!(p2 == "border-top-style"))
				{
					break;
				}
				DashStyle p31 = DashStyle.Solid;
				if (z0tek(p3, out p31))
				{
					p1.BorderStyle = p31;
					if (p31 == DashStyle.Custom)
					{
						p1.BorderStyle = DashStyle.Solid;
						p1.BorderWidth = 0f;
					}
					p1.BorderTop = true;
				}
				break;
			}
			case 'w':
				if (p2 == "border-top-width")
				{
					float p30 = 0f;
					if (z0tek(p3, ref p30))
					{
						p1.BorderWidth = p30;
						p1.BorderTop = true;
					}
				}
				break;
			}
			break;
		case 17:
			switch (p2[12])
			{
			case 's':
			{
				if (!(p2 == "border-left-style"))
				{
					break;
				}
				DashStyle p28 = DashStyle.Solid;
				if (z0tek(p3, out p28))
				{
					p1.BorderStyle = p28;
					if (p28 == DashStyle.Custom)
					{
						p1.BorderStyle = DashStyle.Solid;
						p1.BorderWidth = 0f;
					}
					p1.BorderLeft = true;
				}
				break;
			}
			case 'c':
				if (p2 == "border-left-color")
				{
					Color p27 = Color.Black;
					if (z0tek(p3, out p27))
					{
						p1.BorderLeft = true;
						p1.BorderLeftColor = p27;
					}
				}
				break;
			case 'w':
				if (p2 == "border-left-width")
				{
					float p26 = 0f;
					if (z0tek(p3, ref p26))
					{
						p1.BorderWidth = p26;
						p1.BorderLeft = true;
					}
				}
				break;
			}
			break;
		case 18:
			switch (p2[13])
			{
			case 's':
			{
				if (!(p2 == "border-right-style"))
				{
					break;
				}
				DashStyle p25 = DashStyle.Solid;
				if (z0tek(p3, out p25))
				{
					p1.BorderStyle = p25;
					if (p25 == DashStyle.Custom)
					{
						p1.BorderStyle = DashStyle.Solid;
						p1.BorderWidth = 0f;
					}
					p1.BorderRight = true;
				}
				break;
			}
			case 'c':
				if (p2 == "border-right-color")
				{
					Color p24 = Color.Black;
					if (z0tek(p3, out p24))
					{
						p1.BorderRight = true;
						p1.BorderRightColor = p24;
					}
				}
				break;
			case 'w':
				if (p2 == "border-right-width")
				{
					float p23 = 0f;
					if (z0tek(p3, ref p23))
					{
						p1.BorderWidth = p23;
						p1.BorderRight = true;
					}
				}
				break;
			}
			break;
		case 19:
			switch (p2[14])
			{
			case 's':
			{
				if (!(p2 == "border-bottom-style"))
				{
					break;
				}
				DashStyle p22 = DashStyle.Solid;
				if (z0tek(p3, out p22))
				{
					p1.BorderStyle = p22;
					if (p22 == DashStyle.Custom)
					{
						p1.BorderStyle = DashStyle.Solid;
						p1.BorderWidth = 0f;
					}
					p1.BorderBottom = true;
				}
				break;
			}
			case 'c':
				if (p2 == "border-bottom-color")
				{
					Color p21 = Color.Black;
					if (z0tek(p3, out p21))
					{
						p1.BorderBottom = true;
						p1.BorderBottomColor = p21;
					}
				}
				break;
			case 'w':
				if (p2 == "border-bottom-width")
				{
					float p20 = 0f;
					if (z0tek(p3, ref p20))
					{
						p1.BorderWidth = p20;
						p1.BorderBottom = true;
					}
				}
				break;
			}
			break;
		case 11:
			switch (p2[0])
			{
			default:
				return;
			case 'b':
				break;
			case 'f':
				if (!(p2 == "font-family"))
				{
					if (p2 == "font-weight" && !string.IsNullOrEmpty(p3) && p3 != "normal")
					{
						if (p3 == "bold" || p3 == "700")
						{
							p1.Bold = true;
						}
						else if (p3.Contains("bold", StringComparison.OrdinalIgnoreCase))
						{
							p1.Bold = true;
						}
						else if (p3.Contains("700", StringComparison.OrdinalIgnoreCase))
						{
							p1.Bold = true;
						}
					}
				}
				else
				{
					string text6 = z0nek(p3);
					if (text6 != null)
					{
						p1.z0eek(text6);
					}
				}
				return;
			case 'l':
			{
				if (!(p2 == "line-height") || p3 == null)
				{
					return;
				}
				p3 = p3.Trim().ToLower();
				if (p3.EndsWith("%"))
				{
					string text4 = p3.Substring(0, p3.Length - 1);
					int num = 0;
					if (int.TryParse(text4, out num))
					{
						switch (num)
						{
						case 100:
							p1.LineSpacing = 0f;
							p1.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
							break;
						case 150:
							p1.LineSpacingStyle = LineSpacingStyle.Space1pt5;
							break;
						case 200:
							p1.LineSpacingStyle = LineSpacingStyle.SpaceDouble;
							break;
						default:
							p1.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
							p1.LineSpacing = (float)num / 100f;
							break;
						}
					}
					return;
				}
				if (p3.EndsWith("em"))
				{
					string text5 = p3.Substring(0, p3.Length - 2);
					float num2 = 0f;
					if (float.TryParse(text5, out num2))
					{
						if (num2 == 1f)
						{
							p1.LineSpacing = 0f;
							p1.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
						}
						else if ((double)num2 == 1.5)
						{
							p1.LineSpacingStyle = LineSpacingStyle.Space1pt5;
						}
						else if (num2 == 2f)
						{
							p1.LineSpacingStyle = LineSpacingStyle.SpaceDouble;
						}
						else
						{
							p1.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
							p1.LineSpacing = num2 / 1f;
						}
					}
					return;
				}
				float num3 = 0f;
				bool flag = !p3.Contains("px");
				if (float.TryParse(p3.Replace("px", ""), out num3))
				{
					if (num3 == 1f)
					{
						p1.LineSpacing = 0f;
						p1.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
					}
					else if ((double)num3 == 1.5)
					{
						p1.LineSpacingStyle = LineSpacingStyle.Space1pt5;
					}
					else if (num3 == 2f)
					{
						p1.LineSpacingStyle = LineSpacingStyle.SpaceDouble;
					}
					else if (flag)
					{
						p1.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
						p1.LineSpacing = num3;
					}
					else
					{
						p1.LineSpacingStyle = LineSpacingStyle.SpaceSpecify;
						p1.LineSpacing = z0ZzZzrpk.z0eek(num3, GraphicsUnit.Pixel, GraphicsUnit.Document);
					}
				}
				return;
			}
			case 't':
				if (p2 == "text-indent")
				{
					float p15 = 0f;
					if (z0tek(p0, p3, out p15))
					{
						p1.FirstLineIndent = p15;
					}
				}
				return;
			case 'm':
				if (p2 == "margin-left" && (p4 is XTextParagraphFlagElement || p4 is z0ZzZzwjh))
				{
					float p16 = 0f;
					if (z0tek(p0, p3, out p16))
					{
						p1.LeftIndent = p16;
					}
				}
				return;
			case 'p':
				if (p2 == "padding-top")
				{
					float p14 = 0f;
					if (z0tek(p0, p3, out p14))
					{
						p1.PaddingTop = p14;
					}
				}
				return;
			}
			if (!(p2 == "border-left"))
			{
				break;
			}
			goto IL_0ab4;
		case 13:
			switch (p2[0])
			{
			default:
				return;
			case 'b':
				break;
			case 'm':
				if (p2 == "margin-bottom" && (p4 is XTextParagraphFlagElement || p4 is z0ZzZzwjh))
				{
					float p9 = 0f;
					if (z0tek(p0, p3, out p9))
					{
						p1.SpacingAfterParagraph = p9;
					}
				}
				return;
			case 'p':
				if (p2 == "padding-right")
				{
					float p8 = 0f;
					if (z0tek(p0, p3, out p8))
					{
						p1.PaddingRight = p8;
					}
				}
				return;
			}
			if (!(p2 == "border-bottom"))
			{
				break;
			}
			goto IL_0ab4;
		case 14:
			switch (p2[0])
			{
			case 'p':
				if (p2 == "padding-bottom")
				{
					float p7 = 0f;
					if (z0tek(p0, p3, out p7))
					{
						p1.PaddingBottom = p7;
					}
				}
				break;
			case 'v':
				if (!(p2 == "vertical-align") || string.IsNullOrEmpty(p3))
				{
					break;
				}
				switch (p3)
				{
				case "top":
					p1.VerticalAlign = VerticalAlignStyle.Top;
					break;
				case "middle":
					p1.VerticalAlign = VerticalAlignStyle.Middle;
					break;
				case "bottom":
					p1.VerticalAlign = VerticalAlignStyle.Bottom;
					break;
				default:
					switch (p3.Trim().ToLower())
					{
					case "top":
						p1.VerticalAlign = VerticalAlignStyle.Top;
						break;
					case "middle":
						p1.VerticalAlign = VerticalAlignStyle.Middle;
						break;
					case "bottom":
						p1.VerticalAlign = VerticalAlignStyle.Bottom;
						break;
					}
					break;
				}
				break;
			case 'l':
				if (p2 == "letter-spacing")
				{
					float p6 = 0f;
					if (z0tek(p0, p3, out p6))
					{
						p1.LetterSpacing = p6;
					}
				}
				break;
			}
			break;
		case 15:
		{
			if (!(p2 == "text-decoration") || p3 == null || !(p3 != "none"))
			{
				break;
			}
			if (p3 == "underline")
			{
				p1.Underline = true;
				break;
			}
			if (p3 == "line-through")
			{
				p1.Strikeout = true;
				break;
			}
			string text3 = p3.Trim().ToLower();
			if (text3 == "underline")
			{
				p1.Underline = true;
			}
			else if (text3 == "line-through")
			{
				p1.Strikeout = true;
			}
			break;
		}
		case 4:
		{
			if (!(p2 == "font"))
			{
				break;
			}
			string[] array5 = z0tek(p3);
			if (array5 == null)
			{
				break;
			}
			foreach (string text7 in array5)
			{
				float p40 = 0f;
				if (string.Equals(text7, "italic", StringComparison.OrdinalIgnoreCase))
				{
					p1.Italic = true;
					continue;
				}
				if (string.Equals(text7, "oblique", StringComparison.OrdinalIgnoreCase))
				{
					p1.Italic = true;
					continue;
				}
				if (string.Equals(text7, "bold", StringComparison.OrdinalIgnoreCase))
				{
					p1.Bold = true;
					continue;
				}
				if (string.Equals(text7, "bolder", StringComparison.OrdinalIgnoreCase))
				{
					p1.Bold = true;
					continue;
				}
				if (z0tek(p0, text7, out p40))
				{
					p1.FontSize = z0ZzZzrpk.z0eek(p40, GraphicsUnit.Document, GraphicsUnit.Point);
					p1.z0grk = true;
					continue;
				}
				string text8 = z0nek(text7);
				if (text8 != null)
				{
					p1.z0eek(text8);
				}
			}
			break;
		}
		case 9:
			if (p2 == "font-size" && !p1.z0grk)
			{
				float p29 = 0f;
				if (z0tek(p0, p3, out p29))
				{
					p1.FontSize = z0ZzZzrpk.z0eek(p29, GraphicsUnit.Document, GraphicsUnit.Point);
				}
			}
			break;
		case 7:
		{
			if (!(p2 == "padding"))
			{
				break;
			}
			float[] array = z0tek(p0, p3);
			if (array != null)
			{
				if (array.Length >= 4)
				{
					p1.z0eek(array[3], array[0], array[1], array[2]);
				}
				else if (array.Length == 1)
				{
					p1.z0eek(array[0], array[0], array[0], array[0]);
				}
				else if (array.Length == 2)
				{
					p1.PaddingTop = array[0];
					p1.PaddingBottom = array[0];
					p1.PaddingLeft = array[1];
					p1.PaddingRight = array[1];
				}
				else if (array.Length == 3)
				{
					p1.PaddingTop = array[0];
					p1.PaddingRight = array[1];
					p1.PaddingLeft = array[1];
					p1.PaddingBottom = array[2];
				}
			}
			break;
		}
		case 8:
			break;
			IL_0ab4:
			if (string.Equals(p3, "none", StringComparison.OrdinalIgnoreCase))
			{
				switch (p2)
				{
				case "border-left":
					p1.BorderLeft = false;
					break;
				case "border-top":
					p1.BorderTop = false;
					break;
				case "border-right":
					p1.BorderRight = false;
					break;
				case "border-bottom":
					p1.BorderBottom = false;
					break;
				}
				break;
			}
			p37 = DashStyle.Solid;
			p38 = Color.Empty;
			p39 = 0f;
			z0tek(p3, ref p39, ref p37, ref p38);
			p1.BorderStyle = p37;
			p1.BorderWidth = p39;
			switch (p2)
			{
			case "border-left":
				p1.BorderLeft = true;
				p1.BorderLeftColor = p38;
				break;
			case "border-top":
				p1.BorderTop = true;
				p1.BorderTopColor = p38;
				break;
			case "border-right":
				p1.BorderRight = true;
				p1.BorderRightColor = p38;
				break;
			case "border-bottom":
				p1.BorderBottom = true;
				p1.BorderBottomColor = p38;
				break;
			}
			break;
		}
	}

	private z0ZzZzevk z0tek(string p0, string p1)
	{
		if (string.IsNullOrEmpty(p0) && string.IsNullOrEmpty(p1))
		{
			return new z0ZzZzevk();
		}
		string text = null;
		text = (string.IsNullOrEmpty(p1) ? p0 : ((!string.IsNullOrEmpty(p0)) ? (p1 + "#" + p0) : p1));
		z0ZzZzevk z0ZzZzevk2 = null;
		if (!z0brk.TryGetValue(text, out z0ZzZzevk2))
		{
			if (!string.IsNullOrEmpty(p0))
			{
				z0ZzZzevk2 = new z0ZzZzevk();
				z0ZzZzevk2.z0tek_jiejie20260327142557(p0);
			}
			if (!string.IsNullOrEmpty(p1))
			{
				z0ZzZzlvk z0ZzZzlvk2 = null;
				if (p1.IndexOf(' ') < 0)
				{
					if (z0erk.z0oek().TryGetValue("." + p1, out z0ZzZzlvk2))
					{
						if (z0ZzZzevk2 == null)
						{
							z0ZzZzevk2 = z0ZzZzlvk2;
						}
						else
						{
							z0ZzZzevk2.z0eek(z0ZzZzlvk2, p1: false);
						}
					}
				}
				else
				{
					if (z0ZzZzevk2 == null)
					{
						z0ZzZzevk2 = new z0ZzZzevk();
					}
					string[] array = p1.Split(' ');
					foreach (string text2 in array)
					{
						if (text2 == z0ZzZzhjh.z0krk)
						{
							z0ZzZzevk2.z0eek("logicdeleted", "1");
							continue;
						}
						bool flag = false;
						string[] array2 = z0urk;
						foreach (string text3 in array2)
						{
							if (text2 == text3)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							z0ZzZzlvk p2 = null;
							if (z0erk.z0oek().TryGetValue("." + text2, out p2))
							{
								z0ZzZzevk2.z0eek(p2, p1: false);
							}
						}
					}
				}
			}
			z0brk.Add(text, z0ZzZzevk2);
		}
		return z0ZzZzevk2;
	}

	private string z0oek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p0;
		}
		string result = p0;
		if (!z0xek.TryGetValue(p0, out result))
		{
			z0xek[p0] = p0;
			result = p0;
		}
		return result;
	}

	private void z0tek(XTextMediaElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		z0ZzZzhbk obj = p1.z0yek();
		string p2 = "";
		string p3 = "";
		string p4 = "";
		foreach (z0ZzZzunk item in obj.z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "dc_printvisibility":
			{
				string text24 = item.z0yek();
				if (text24 != null && text24.Length > 0)
				{
					p0.PrintVisibility = z0rek<ElementVisibility>(text24);
				}
				break;
			}
			case "dc_allowuserresize":
			{
				string text20 = item.z0yek();
				if (text20 != null && text20.Length > 0 && text20 != "WidthAndHeight")
				{
					p0.AllowUserResize = z0rek<ResizeableType>(text20);
				}
				break;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(item);
				break;
			case "dc_contentreadonly":
			{
				string text6 = item.z0yek();
				if (text6 != null && text6.Length > 0 && text6 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text6, ContentReadonlyState.Inherit);
				}
				break;
			}
			case "dc_controltype":
			{
				string text9 = item.z0yek();
				if (text9 != null && text9.Length > 0 && text9 != "AutoDetect")
				{
					p0.z0ey(z0rek<z0ZzZzrxj>(text9));
				}
				break;
			}
			case "dc_delayloadcontrol":
			{
				string text18 = item.z0yek();
				if (text18 != null && text18.Length > 0 && text18 != "false")
				{
					p0.DelayLoadControl = z0tek(text18, p1: false);
				}
				break;
			}
			case "dc_deleteable":
			{
				string text26 = item.z0yek();
				if (text26 != null && text26.Length > 0 && text26 != "true")
				{
					p0.Deleteable = z0tek(text26, p1: false);
				}
				break;
			}
			case "dc_enabled":
			{
				string text14 = item.z0yek();
				if (text14 != null && text14.Length > 0 && text14 != "true")
				{
					p0.Enabled = z0tek(text14, p1: false);
				}
				break;
			}
			case "dc_enablemediacontextmenu":
			{
				string text5 = item.z0yek();
				if (text5 != null && text5.Length > 0 && text5 != "true")
				{
					p0.EnableMediaContextMenu = z0tek(text5, p1: false);
				}
				break;
			}
			case "dc_filecontenttype":
			{
				string text21 = item.z0yek();
				if (text21 != null && text21.Length > 0)
				{
					p0.FileContentType = text21;
				}
				break;
			}
			case "dc_filename":
			{
				string text15 = item.z0yek();
				if (text15 != null && text15.Length > 0)
				{
					p0.FileName = text15;
				}
				break;
			}
			case "dc_filesystemname":
			{
				string text11 = item.z0yek();
				if (text11 != null && text11.Length > 0)
				{
					p0.FileSystemName = text11;
				}
				break;
			}
			case "dc_hostmode":
			{
				string text2 = item.z0yek();
				if (text2 != null && text2.Length > 0 && text2 != "Dynamic")
				{
					p0.z0eek(z0rek<z0ZzZzgzj>(text2));
				}
				break;
			}
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "dc_linkinfo":
			{
				string text23 = item.z0yek();
				if (text23 != null && text23.Length > 0)
				{
					p0.z0eek(new z0ZzZzbuk());
					z0ZzZzmik.z0eek(((XTextObjectElement)p0).z0iek(), text23);
				}
				break;
			}
			case "dc_loopplay":
			{
				string text17 = item.z0yek();
				if (text17 != null && text17.Length > 0 && text17 != "false")
				{
					p0.LoopPlay = z0tek(text17, p1: false);
				}
				break;
			}
			case "dc_name":
			{
				string text13 = item.z0yek();
				if (text13 != null && text13.Length > 0)
				{
					p0.Name = text13;
				}
				break;
			}
			case "dc_playeruimode":
			{
				string text8 = item.z0yek();
				if (text8 != null && text8.Length > 0 && text8 != "mini")
				{
					p0.PlayerUIMode = z0rek<WindowsMediaPlayerUIMode>(text8);
				}
				break;
			}
			case "dc_propertyexpressions":
			{
				string text3 = item.z0yek();
				if (text3 != null && text3.Length > 0)
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text3);
				}
				break;
			}
			case "dc_savepreviewimage":
			{
				string text25 = item.z0yek();
				if (text25 != null && text25.Length > 0 && text25 != "false")
				{
					((XTextControlHostElement)p0).z0eek(z0tek(text25, p1: false));
				}
				break;
			}
			case "dc_stringtag":
			{
				string text22 = item.z0yek();
				if (text22 != null && text22.Length > 0)
				{
					p0.StringTag = text22;
				}
				break;
			}
			case "dc_text":
			{
				string text19 = item.z0yek();
				if (text19 != null && text19.Length > 0)
				{
					p0.Text = text19;
				}
				break;
			}
			case "dc_typefullname":
			{
				string text16 = item.z0yek();
				if (text16 != null && text16.Length > 0)
				{
					p0.TypeFullName = text16;
				}
				break;
			}
			case "dc_valign":
			{
				string text12 = item.z0yek();
				if (text12 != null && text12.Length > 0 && text12 != "Bottom")
				{
					p0.VAlign = z0rek<VerticalAlignStyle>(text12);
				}
				break;
			}
			case "dc_valueexpression":
			{
				string text10 = item.z0yek();
				if (text10 != null && text10.Length > 0)
				{
					p0.ValueExpression = text10;
				}
				break;
			}
			case "uiMode":
			{
				string text7 = item.z0yek();
				if (text7 != null && text7.Length > 0)
				{
					p2 = text7;
				}
				break;
			}
			case "EnableContextMenu":
			{
				string text4 = item.z0yek();
				if (text4 != null && text4.Length > 0)
				{
					p3 = text4;
				}
				break;
			}
			case "loop":
			{
				string text = item.z0yek();
				if (text != null && text.Length > 0 && text != "false")
				{
					p4 = text;
				}
				break;
			}
			}
		}
		z0tek(p1.z0yek(), p0);
		z0ZzZzxdh z0ZzZzxdh2 = z0tek(p1.z0yek(), p0.z0jr());
		if (z0ZzZzxdh2.z0rek() > 0f)
		{
			p0.Width = z0ZzZzxdh2.z0rek();
		}
		if (z0ZzZzxdh2.z0tek() > 0f)
		{
			p0.Height = z0ZzZzxdh2.z0tek();
		}
		if (p1.z0oek() == "object")
		{
			p0.EnableMediaContextMenu = z0tek(p3, p1: true);
			p0.PlayerUIMode = (WindowsMediaPlayerUIMode)z0tek(p2, WindowsMediaPlayerUIMode.mini);
			using zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = p1.z0uek().z0ltk();
			while (z0bpk.MoveNext())
			{
				z0ZzZzhbk current2 = z0bpk.Current;
				if (!(current2.z0cak() == "param"))
				{
					continue;
				}
				string text27 = "";
				string text28 = "";
				using (zzz.z0ZzZzkuk<z0ZzZzunk>.z0bpk z0bpk2 = current2.z0oek().z0ltk())
				{
					while (z0bpk2.MoveNext())
					{
						z0ZzZzunk current3 = z0bpk2.Current;
						string text29 = current3.z0rek();
						if (!(text29 == "name"))
						{
							if (text29 == "value")
							{
								string text30 = current3.z0yek();
								if (text30 != null && text30.Length > 0)
								{
									text28 = text30;
								}
							}
						}
						else
						{
							string text31 = current3.z0yek();
							if (text31 != null && text31.Length > 0)
							{
								text27 = text31;
							}
						}
					}
				}
				if (string.Compare(text27, "PlayCount", true) == 0 && text28 == "0")
				{
					p0.LoopPlay = true;
				}
			}
			return;
		}
		if (!(p1.z0oek() == "video"))
		{
			return;
		}
		p0.LoopPlay = z0tek(p4, p1: false);
		using zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = p1.z0uek().z0ltk();
		while (z0bpk.MoveNext())
		{
			z0ZzZzhbk current4 = z0bpk.Current;
			if (!(current4.z0cak() == "source"))
			{
				continue;
			}
			using zzz.z0ZzZzkuk<z0ZzZzunk>.z0bpk z0bpk2 = current4.z0oek().z0ltk();
			while (z0bpk2.MoveNext())
			{
				z0ZzZzunk current5 = z0bpk2.Current;
				if (current5.z0rek() == "src")
				{
					string text32 = current5.z0yek();
					if (text32 != null && text32.Length > 0)
					{
						p0.FileName = text32;
					}
				}
			}
		}
	}

	internal static float z0pek(string p0)
	{
		float result = 0f;
		if (float.TryParse(p0, out result))
		{
			return result;
		}
		return 0f;
	}

	public void z0tek(XTextContainerElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (p1.z0yek() == null)
		{
			throw new ArgumentNullException("args.HtmlElemenet");
		}
		XTextDocument xTextDocument = z0jrk;
		z0ZzZzgbk z0ZzZzgbk2 = p1.z0uek();
		if (z0ZzZzgbk2 == null || z0ZzZzgbk2.Count == 0)
		{
			return;
		}
		z0ZzZzgbk z0ZzZzgbk3 = null;
		if (z0ZzZzgbk3 == null)
		{
			z0ZzZzgbk3 = z0ZzZzgbk2;
		}
		int count = z0ZzZzgbk3.Count;
		for (int i = 0; i < count; i++)
		{
			z0ZzZzhbk z0ZzZzhbk2 = z0ZzZzgbk3[i];
			if (z0ZzZzhbk2 is z0ZzZzxnk)
			{
				continue;
			}
			if (z0ZzZzhbk2 is z0ZzZzmvk)
			{
				z0tek((z0ZzZzmvk)z0ZzZzhbk2, p1, p0, p0.z0be());
				continue;
			}
			string text = null;
			string text2 = null;
			if (z0ZzZzhbk2.z0iek())
			{
				bool flag = false;
				foreach (z0ZzZzunk item in z0ZzZzhbk2.z0oek().z0xrk())
				{
					if (item.z0rek() == "dcignore")
					{
						flag = true;
						break;
					}
					if (item.z0rek() == "dctype")
					{
						text = item.z0yek();
						break;
					}
					if (item.z0rek() == "class")
					{
						text2 = item.z0yek();
					}
				}
				if (flag)
				{
					continue;
				}
			}
			if (text != null && text.Length > 0)
			{
				switch (text)
				{
				case "DocumentComment":
				{
					DocumentComment documentComment = new DocumentComment();
					documentComment.z0pek(z0ZzZzhbk2.z0eek("commenttext"));
					documentComment.z0mek(z0ZzZzhbk2.z0eek("id"));
					documentComment.z0eek(z0tek(z0ZzZzhbk2.z0oek().z0iek("dc_attributes")));
					DateTime result = z0ZzZzkfh.z0wrk;
					if (DateTime.TryParse(z0ZzZzhbk2.z0eek("commentcreationtime"), out result))
					{
						documentComment.z0eek(result);
					}
					documentComment.z0eek(z0ZzZzhbk2.z0eek("commentauthor"));
					documentComment.z0rek(z0ZzZzhbk2.z0eek("commentauthorid"));
					documentComment.z0rek(z0tek(z0ZzZzhbk2.z0eek("combk"), Color.White));
					if (xTextDocument.Comments == null)
					{
						xTextDocument.Comments = new z0ZzZzwcj();
					}
					documentComment.z0lrk().z0eek("dccommentbackcolor", z0ZzZzhbk2.z0eek("combk"));
					documentComment.z0lrk().z0eek("dccommentbackcolor2", z0ZzZzhbk2.z0eek("combk2"));
					string text3 = z0ZzZzhbk2.z0eek("refcommentindex");
					int p4 = 0;
					if (int.TryParse(text3, out p4))
					{
						documentComment.z0eek(p4);
					}
					else
					{
						documentComment.z0eek(xTextDocument.Comments.Count);
					}
					if (xTextDocument.Comments.z0eek(documentComment.z0tek()) == null)
					{
						xTextDocument.Comments.Add(documentComment);
					}
					z0ZzZzevk z0ZzZzevk2 = z0yek(z0ZzZzhbk2);
					if (p1.z0tek() != null)
					{
						z0ZzZzevk2.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
					}
					z0ZzZzevk2.z0eek("commentindex", documentComment.z0tek().ToString());
					z0ZzZzevk2.z0iek("background-color");
					z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk2));
					break;
				}
				case "XTextDocumentBodyElement":
					z0tek(xTextDocument.z0xyk(), new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, null));
					break;
				case "XTextDocumentFooterElement":
					z0tek(xTextDocument.z0lik(), new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, null));
					break;
				case "XTextDocumentFooterForFirstPageElement":
					z0tek(xTextDocument.z0guk(), new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, null));
					break;
				case "XTextDocumentHeaderElement":
					z0tek(xTextDocument.z0pyk(), new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, null));
					break;
				case "XTextDocumentHeaderForFirstPageElement":
					z0tek(xTextDocument.z0cyk(), new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, null));
					break;
				case "XTextInputFieldElement":
				{
					XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
					xTextInputFieldElement.z0yek(xTextDocument, p0);
					z0tek(xTextInputFieldElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextInputFieldElement);
					break;
				}
				case "XTextImageElement":
				{
					XTextImageElement xTextImageElement = new XTextImageElement();
					xTextImageElement.z0yek(xTextDocument, p0);
					z0tek(xTextImageElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextImageElement);
					break;
				}
				case "XTextTableElement":
				{
					XTextTableElement xTextTableElement = new XTextTableElement();
					xTextTableElement.z0yek(xTextDocument, p0);
					z0tek(xTextTableElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextTableElement);
					break;
				}
				case "XTextPageInfoElement":
				{
					XTextPageInfoElement xTextPageInfoElement = new XTextPageInfoElement();
					xTextPageInfoElement.z0yek(xTextDocument, p0);
					z0tek(xTextPageInfoElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextPageInfoElement);
					break;
				}
				case "XTextCheckBoxElement":
				{
					XTextCheckBoxElement xTextCheckBoxElement = new XTextCheckBoxElement();
					xTextCheckBoxElement.z0yek(xTextDocument, p0);
					z0tek(xTextCheckBoxElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextCheckBoxElement);
					break;
				}
				case "XTextRadioBoxElement":
				{
					XTextRadioBoxElement xTextRadioBoxElement = new XTextRadioBoxElement();
					xTextRadioBoxElement.z0yek(xTextDocument, p0);
					z0tek(xTextRadioBoxElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextRadioBoxElement);
					break;
				}
				case "XTextSectionElement":
				{
					XTextSectionElement xTextSectionElement = new XTextSectionElement();
					xTextSectionElement.z0yek(xTextDocument, p0);
					z0tek(xTextSectionElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextSectionElement);
					break;
				}
				case "XTextSubDocumentElement":
				{
					XTextSubDocumentElement xTextSubDocumentElement = new XTextSubDocumentElement();
					xTextSubDocumentElement.z0yek(xTextDocument, p0);
					z0tek(xTextSubDocumentElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextSubDocumentElement);
					break;
				}
				case "XTextLabelElement":
				{
					XTextLabelElement xTextLabelElement = new XTextLabelElement();
					xTextLabelElement.z0yek(xTextDocument, p0);
					z0tek(xTextLabelElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextLabelElement);
					break;
				}
				case "XTextChartElement":
				{
					XTextChartElement xTextChartElement = new XTextChartElement();
					xTextChartElement.z0yek(xTextDocument, p0);
					z0tek(xTextChartElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextChartElement);
					break;
				}
				case "XTextPieElement":
				{
					XTextPieElement xTextPieElement = new XTextPieElement();
					xTextPieElement.z0yek(xTextDocument, p0);
					z0tek(xTextPieElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextPieElement);
					break;
				}
				case "XTextSignImageElement":
				{
					XTextSignImageElement xTextSignImageElement = new XTextSignImageElement();
					xTextSignImageElement.z0yek(xTextDocument, p0);
					z0tek(xTextSignImageElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextSignImageElement);
					break;
				}
				case "XTextNewBarcodeElement":
				{
					XTextNewBarcodeElement xTextNewBarcodeElement2 = new XTextNewBarcodeElement();
					xTextNewBarcodeElement2.z0yek(xTextDocument, p0);
					z0tek(xTextNewBarcodeElement2, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextNewBarcodeElement2);
					break;
				}
				case "XTextTDBarcodeElement":
				{
					XTextTDBarcodeElement xTextTDBarcodeElement = new XTextTDBarcodeElement();
					xTextTDBarcodeElement.z0yek(xTextDocument, p0);
					z0tek(xTextTDBarcodeElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextTDBarcodeElement);
					break;
				}
				case "XTextMediaElement":
				{
					XTextMediaElement xTextMediaElement = new XTextMediaElement();
					xTextMediaElement.z0yek(xTextDocument, p0);
					z0tek(xTextMediaElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextMediaElement);
					break;
				}
				case "XTextNewMedicalExpressionElement":
				{
					XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement2 = new XTextNewMedicalExpressionElement();
					xTextNewMedicalExpressionElement2.z0yek(xTextDocument, p0);
					z0tek(xTextNewMedicalExpressionElement2, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextNewMedicalExpressionElement2);
					break;
				}
				case "XTextButtonElement":
				{
					XTextButtonElement xTextButtonElement = new XTextButtonElement();
					xTextButtonElement.z0yek(xTextDocument, p0);
					z0tek(xTextButtonElement, z0tek(p1, z0ZzZzhbk2));
					p0.z0be().Add(xTextButtonElement);
					break;
				}
				case "XTextBarcodeFieldElement":
				{
					XTextBarcodeFieldElement xTextBarcodeFieldElement = new XTextBarcodeFieldElement();
					xTextBarcodeFieldElement.z0yek(xTextDocument, p0);
					z0tek(xTextBarcodeFieldElement, z0tek(p1, z0ZzZzhbk2));
					XTextNewBarcodeElement xTextNewBarcodeElement = new XTextNewBarcodeElement();
					xTextNewBarcodeElement.Width = xTextBarcodeFieldElement.Width;
					xTextNewBarcodeElement.Height = xTextBarcodeFieldElement.Height;
					xTextNewBarcodeElement.BarcodeStyle2 = (DCBarcodeStyle)Enum.Parse(typeof(DCBarcodeStyle), xTextBarcodeFieldElement.BarcodeStyle.ToString());
					xTextNewBarcodeElement.Name = xTextBarcodeFieldElement.Name;
					xTextNewBarcodeElement.ID = xTextBarcodeFieldElement.ID;
					xTextNewBarcodeElement.ShowText = xTextBarcodeFieldElement.ShowText;
					xTextNewBarcodeElement.Enabled = xTextBarcodeFieldElement.Enabled;
					xTextNewBarcodeElement.Text = xTextBarcodeFieldElement.Text;
					xTextNewBarcodeElement.Attributes = ((xTextBarcodeFieldElement.Attributes != null) ? xTextBarcodeFieldElement.Attributes.z0eek() : null);
					xTextNewBarcodeElement.z0yek((DocumentContentStyle)((XTextElement)xTextBarcodeFieldElement).z0xrk().Clone());
					p0.z0be().Add(xTextNewBarcodeElement);
					break;
				}
				case "XTextMedicalExpressionFieldElement":
				{
					XTextMedicalExpressionFieldElement xTextMedicalExpressionFieldElement = new XTextMedicalExpressionFieldElement();
					xTextMedicalExpressionFieldElement.z0yek(xTextDocument, p0);
					z0tek((XTextElement)xTextMedicalExpressionFieldElement, z0tek(p1, z0ZzZzhbk2));
					XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement = new XTextNewMedicalExpressionElement();
					xTextNewMedicalExpressionElement.Width = xTextMedicalExpressionFieldElement.Width;
					xTextNewMedicalExpressionElement.Height = xTextMedicalExpressionFieldElement.Height;
					xTextNewMedicalExpressionElement.Enabled = xTextMedicalExpressionFieldElement.Enabled;
					xTextNewMedicalExpressionElement.ID = xTextMedicalExpressionFieldElement.ID;
					xTextNewMedicalExpressionElement.Name = xTextMedicalExpressionFieldElement.Name;
					xTextNewMedicalExpressionElement.ExpressionStyle = (DCMedicalExpressionStyle)Enum.Parse(typeof(DCMedicalExpressionStyle), xTextMedicalExpressionFieldElement.ExpressionStyle.ToString());
					xTextNewMedicalExpressionElement.z0bt(xTextMedicalExpressionFieldElement.z0jr());
					xTextNewMedicalExpressionElement.z0yek((DocumentContentStyle)((XTextElement)xTextMedicalExpressionFieldElement).z0xrk().Clone());
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					string[] array = xTextMedicalExpressionFieldElement.Text.Split(',');
					for (int j = 1; j <= array.Length; j++)
					{
						string p2 = "Value" + j;
						string p3 = array[j - 1];
						xTextNewMedicalExpressionElement.Values.Add(new z0ZzZzjuk(p2, p3));
					}
					p0.z0be().Add(xTextNewMedicalExpressionElement);
					break;
				}
				default:
				{
					Type type = z0ZzZzlfh.z0eek(text);
					if (type == null)
					{
						type = z0ZzZzwnj.GetControlType(text, typeof(XTextElement));
					}
					if (type != null)
					{
						XTextElement xTextElement = (XTextElement)Activator.CreateInstance(type);
						xTextElement.z0yek(xTextDocument, p0);
						z0tek(xTextElement, z0tek(p1, z0ZzZzhbk2));
						p0.z0be().Add(xTextElement);
					}
					break;
				}
				case "start":
				case "backgroundtext":
				case "end":
					break;
				}
				continue;
			}
			z0ZzZzevk z0ZzZzevk3 = null;
			if (!(z0ZzZzhbk2 is z0ZzZzdvk))
			{
				z0ZzZzevk3 = ((text2 == null) ? z0tek(z0ZzZzhbk2.z0eek("style"), z0ZzZzhbk2.z0eek("class")) : z0tek(z0ZzZzhbk2.z0eek("style"), text2));
			}
			else
			{
				string text4 = z0ZzZzhbk2.z0eek("style");
				string text5 = z0ZzZzhbk2.z0eek("gridlineheight");
				if (text5 != null && text5.Length > 0 && text4 != null && text4.Length > 0)
				{
					if (text4 == "line-height:" + text5)
					{
						text4 = null;
					}
					else
					{
						string[] array2 = z0ZzZzqik.z0eek(text4, ':', ';', p3: true);
						StringBuilder stringBuilder = null;
						for (int k = 0; k < array2.Length; k += 2)
						{
							if (!string.Equals(array2[k], "line-height", StringComparison.OrdinalIgnoreCase) || !string.Equals(array2[k + 1], text5, StringComparison.OrdinalIgnoreCase))
							{
								if (stringBuilder == null)
								{
									stringBuilder = new StringBuilder();
								}
								else
								{
									stringBuilder.Append(';');
								}
								stringBuilder.Append(array2[k] + ":" + array2[k + 1]);
							}
						}
						text4 = stringBuilder?.ToString();
					}
				}
				z0ZzZzevk3 = z0tek(text4, text2);
			}
			if (p0 is XTextInputFieldElement && ((XTextInputFieldElement)p0).TextColor.A > 0)
			{
				z0ZzZzevk3 = z0ZzZzevk3.z0yek();
				z0ZzZzevk3.z0iek("color");
			}
			switch (z0ZzZzhbk2.z0cak())
			{
			case "span":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				string[] array3 = z0ZzZzhbk2.z0rek("class")?.Split(' ');
				if (WriterControlForWASM.z0kyk && array3 != null && (array3.Contains("TC") || array3.Contains("LR") || array3.Contains("PS") || array3.Contains("PG") || array3.Contains("PI") || array3.Contains("SF") || array3.Contains("BS") || array3.Contains("PA") || array3.Contains("PH") || array3.Contains("tag-value") || array3.Contains("HN")))
				{
					if (array3.Contains("PH") && p0 is XTextInputFieldElement)
					{
						(p0 as XTextInputFieldElement).BackgroundText = z0ZzZzhbk2.z0jqk();
						break;
					}
					if (array3.Contains("tag-value") && p0 is XTextInputFieldElement)
					{
						if (p1.z0tek() != null)
						{
							z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
						}
						z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
						break;
					}
					XTextInputFieldElement xTextInputFieldElement5 = new XTextInputFieldElement();
					if (z0ZzZzhbk2.z0tek("sid"))
					{
						xTextInputFieldElement5.z0dr("sid", z0ZzZzhbk2.z0rek("sid"));
					}
					if (p1.z0tek() != null)
					{
						z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
					}
					xTextInputFieldElement5.z0yek(xTextDocument, p0);
					z0tek((XTextContainerElement)xTextInputFieldElement5, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
					p0.z0be().Add(xTextInputFieldElement5);
					break;
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
					string text13 = p1.z0oek();
					if (text13 != null && text13.Length == 1)
					{
						switch (text13[0])
						{
						case 'u':
							z0ZzZzevk3.z0eek("text-decoration", "underline");
							break;
						case 'b':
							z0ZzZzevk3.z0eek("font-weight", "bold");
							break;
						case 'i':
							z0ZzZzevk3.z0eek("font-style", "italic");
							break;
						case 's':
							z0ZzZzevk3.z0eek("text-decoration", "line-through");
							break;
						}
					}
				}
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				break;
			}
			case "hr":
			{
				if (WriterControlForWASM.z0kyk && z0ZzZzhbk2.z0rek("class") == "headerHR" && p0 is XTextDocumentHeaderElement)
				{
					p1.z0iek().z0vtk().ViewOptions.ShowHeaderBottomLine = true;
					break;
				}
				XTextHorizontalLineElement xTextHorizontalLineElement = new XTextHorizontalLineElement();
				xTextHorizontalLineElement.z0bt(xTextDocument);
				z0tek(z0ZzZzhbk2, xTextHorizontalLineElement);
				string p7 = null;
				if (z0ZzZzhbk2.z0eek("color", out p7))
				{
					xTextHorizontalLineElement.z0xrk().Color = z0tek(p7, Color.Black);
				}
				if (z0ZzZzhbk2.z0eek("size", out p7))
				{
					float num = 1f;
					if (float.TryParse(p7, out num))
					{
						if (num == 1f || num == 0f)
						{
							xTextHorizontalLineElement.LineSize = num;
						}
						else
						{
							xTextHorizontalLineElement.LineSize = z0ZzZzrpk.z0eek(num, GraphicsUnit.Pixel, GraphicsUnit.Document);
						}
					}
					else
					{
						xTextHorizontalLineElement.LineSize = 1f;
					}
				}
				p0.z0be().Add(xTextHorizontalLineElement);
				break;
			}
			case "div":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				string text7 = z0ZzZzhbk2.z0eek("align");
				if (text7 != null)
				{
					z0ZzZzevk3.z0eek("text-align", text7);
				}
				if (p0.z0be().Count > 0 && !(p0.z0zek() is XTextParagraphFlagElement) && !(p0.z0zek() is XTextLineBreakElement))
				{
					XTextParagraphFlagElement element = new XTextParagraphFlagElement();
					p0.z0be().Add(element);
				}
				int count2 = p0.z0be().Count;
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				bool flag2 = false;
				if (count2 > p0.z0be().Count)
				{
					flag2 = true;
					if (p0.z0zek() is XTextParagraphFlagElement)
					{
						flag2 = false;
					}
					else if (p0.z0zek() is XTextLineBreakElement)
					{
						flag2 = false;
					}
				}
				if (z0ZzZzhbk2.z0eek("ipp") == "ll")
				{
					flag2 = true;
				}
				if (text7 != null && text7.Length > 0)
				{
					flag2 = true;
				}
				if (flag2)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement3 = new XTextParagraphFlagElement();
					xTextParagraphFlagElement3.z0buk = z0tek(p1, z0ZzZzevk3, xTextParagraphFlagElement3, z0ZzZzhbk2);
					p0.z0be().Add(xTextParagraphFlagElement3);
				}
				break;
			}
			case "ul":
			case "ol":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				using (zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = z0ZzZzhbk2.z0oqk().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						z0ZzZzhbk current2 = z0bpk.Current;
						if (!(current2.z0cak() == "li"))
						{
							continue;
						}
						if (p1.z0tek() != null)
						{
							z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
						}
						z0tek(p0, new z0ZzZzajh(p1, current2, xTextDocument, z0ZzZzevk3));
						XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
						xTextParagraphFlagElement.z0buk = z0tek(p1, z0ZzZzevk3, xTextParagraphFlagElement, current2);
						string text6 = ((z0ZzZzhbk)current2.z0eek()).z0eek("dcparagraphlistformat");
						if (text6 != null && text6.Length > 0)
						{
							xTextParagraphFlagElement.z0xrk().ParagraphListStyle = (ParagraphListStyle)Enum.Parse(typeof(ParagraphListStyle), text6, true);
							string p5 = null;
							if (current2.z0eek("dc_leftindent", out p5))
							{
								xTextParagraphFlagElement.z0xrk().LeftIndent = float.Parse(p5);
							}
							if (current2.z0eek("dc_firstlineindent", out p5))
							{
								xTextParagraphFlagElement.z0xrk().FirstLineIndent = float.Parse(p5);
							}
						}
						p0.z0be().Add(xTextParagraphFlagElement);
					}
				}
				break;
			}
			case "pre":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				XTextStringElement xTextStringElement = new XTextStringElement();
				xTextStringElement.z0yek(xTextDocument, p0);
				xTextStringElement.z0buk = z0tek(p1, z0ZzZzevk3, xTextStringElement, z0ZzZzhbk2);
				xTextStringElement.Text = z0ZzZzhbk2.z0jqk();
				p0.z0be().Add(xTextStringElement);
				XTextParagraphFlagElement xTextParagraphFlagElement6 = new XTextParagraphFlagElement();
				xTextParagraphFlagElement6.z0buk = xTextStringElement.z0buk;
				p0.z0be().Add(xTextParagraphFlagElement6);
				break;
			}
			case "input":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (z0ZzZzhbk2.z0eek("dctype") == "XTextPageBreakElement")
				{
					p0.z0be().Add(new XTextPageBreakElement());
					break;
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				string text8 = z0ZzZzhbk2.z0eek("type");
				if (text8 != null)
				{
					text8 = text8.Trim().ToLower();
				}
				switch (text8)
				{
				case "checkbox":
				{
					XTextCheckBoxElement xTextCheckBoxElement2 = new XTextCheckBoxElement();
					z0tek(xTextCheckBoxElement2, p1);
					p0.z0be().Add(xTextCheckBoxElement2);
					break;
				}
				case "radio":
				{
					XTextRadioBoxElement xTextRadioBoxElement2 = new XTextRadioBoxElement();
					z0tek(xTextRadioBoxElement2, p1);
					p0.z0be().Add(xTextRadioBoxElement2);
					break;
				}
				case "button":
				case "submit":
				{
					XTextButtonElement xTextButtonElement2 = new XTextButtonElement();
					xTextButtonElement2.AutoSize = true;
					xTextButtonElement2.z0yek(xTextDocument, p0);
					z0tek(xTextButtonElement2, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
					string text9 = z0ZzZzhbk2.z0eek("alt");
					if (!string.IsNullOrEmpty(text9))
					{
						xTextButtonElement2.ToolTip = text9;
					}
					string text10 = z0ZzZzhbk2.z0eek("title");
					if (!string.IsNullOrEmpty(text10))
					{
						xTextButtonElement2.ToolTip = text10;
					}
					p0.z0be().Add(xTextButtonElement2);
					break;
				}
				case "password":
				{
					XTextInputFieldElement xTextInputFieldElement3 = new XTextInputFieldElement();
					xTextInputFieldElement3.z0yek(xTextDocument, p0);
					z0tek(xTextInputFieldElement3, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
					xTextInputFieldElement3.ViewEncryptType = ContentViewEncryptType.Both;
					p0.z0be().Add(xTextInputFieldElement3);
					break;
				}
				case "image":
				{
					XTextImageElement xTextImageElement3 = new XTextImageElement();
					xTextImageElement3.z0yek(xTextDocument, p0);
					z0tek(xTextImageElement3, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
					p0.z0be().Add(xTextImageElement3);
					break;
				}
				default:
				{
					XTextInputFieldElement xTextInputFieldElement2 = new XTextInputFieldElement();
					xTextInputFieldElement2.z0yek(xTextDocument, p0);
					z0tek(xTextInputFieldElement2, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
					p0.z0be().Add(xTextInputFieldElement2);
					break;
				}
				}
				break;
			}
			case "textarea":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				XTextInputFieldElement xTextInputFieldElement6 = new XTextInputFieldElement();
				xTextInputFieldElement6.z0yek(xTextDocument, p0);
				xTextInputFieldElement6.AcceptChildElementTypes2 |= ElementType.ParagraphFlag;
				z0tek(xTextInputFieldElement6, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				p0.z0be().Add(xTextInputFieldElement6);
				break;
			}
			case "select":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				XTextInputFieldElement xTextInputFieldElement4 = new XTextInputFieldElement();
				xTextInputFieldElement4.z0yek(xTextDocument, p0);
				z0tek(xTextInputFieldElement4, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				p0.z0be().Add(xTextInputFieldElement4);
				break;
			}
			case "img":
			{
				XTextImageElement xTextImageElement2 = new XTextImageElement();
				xTextImageElement2.z0yek(xTextDocument, p0);
				z0tek(xTextImageElement2, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0yek(z0ZzZzhbk2)));
				p0.z0be().Add(xTextImageElement2);
				break;
			}
			case "#text":
				z0tek((z0ZzZzmvk)z0ZzZzhbk2, p1, p0, p0.z0be());
				break;
			case "p":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (!z0ZzZzhbk2.z0yek())
				{
					break;
				}
				z0ZzZzwjh z0ZzZzwjh2 = new z0ZzZzwjh(p0);
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				z0ZzZzwjh2.z0yek(z0yek(p1, z0ZzZzevk3, z0ZzZzwjh2, z0ZzZzhbk2));
				string text11 = z0ZzZzhbk2.z0eek("align");
				if (text11 != null && text11.Length > 0 && text11 != "left")
				{
					switch (text11.Trim().ToLower())
					{
					case "left":
						((XTextElement)z0ZzZzwjh2).z0xrk().Align = DocumentContentAlignment.Left;
						break;
					case "center":
						((XTextElement)z0ZzZzwjh2).z0xrk().Align = DocumentContentAlignment.Center;
						break;
					case "right":
						((XTextElement)z0ZzZzwjh2).z0xrk().Align = DocumentContentAlignment.Right;
						break;
					case "justify":
						((XTextElement)z0ZzZzwjh2).z0xrk().Align = DocumentContentAlignment.Justify;
						break;
					default:
						((XTextElement)z0ZzZzwjh2).z0xrk().Align = DocumentContentAlignment.Left;
						break;
					}
				}
				if (z0ZzZzhbk2.z0yek())
				{
					bool flag4 = true;
					if (z0ZzZzhbk2.z0tek("empty") && z0ZzZzhbk2.z0oqk().Count == 1 && z0ZzZzhbk2.z0oqk()[0] is z0ZzZzmvk && z0ZzZzhbk2.z0oqk()[0].z0zak() == '\u2002'.ToString())
					{
						flag4 = false;
					}
					if (flag4)
					{
						z0tek(z0ZzZzwjh2, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
					}
				}
				if (z0ZzZzwjh2.z0be().Count > 0)
				{
					XTextElementList xTextElementList = z0ZzZzwjh2.z0be();
					XTextElement lastElement2 = xTextElementList.LastElement;
					if (!(lastElement2 is XTextTableElement) && !(lastElement2 is XTextSectionElement))
					{
						if (lastElement2 is XTextLineBreakElement)
						{
							if (((XTextLineBreakElement)lastElement2).z0eek() || xTextElementList.Count == 1)
							{
								xTextElementList.RemoveAt(xTextElementList.Count - 1);
							}
						}
						else if (lastElement2 is XTextParagraphFlagElement)
						{
							z0tek(z0ZzZzwjh2, lastElement2);
							xTextElementList.RemoveAt(xTextElementList.Count - 1);
						}
						else if (!(lastElement2 is XTextHorizontalLineElement) && !(lastElement2 is XTextPageBreakElement) && xTextElementList.Count == 1)
						{
							if (xTextElementList[0] is XTextLineBreakElement)
							{
								xTextElementList.Clear();
							}
							else if (xTextElementList[0] is XTextCharElement)
							{
								XTextCharElement xTextCharElement = (XTextCharElement)xTextElementList[0];
								if (xTextCharElement.z0bek == '\u00a0' || xTextCharElement.z0bek == '\u2002')
								{
									xTextElementList.Clear();
								}
							}
							else if (xTextElementList[0] is XTextStringElement)
							{
								string text12 = xTextElementList[0].Text;
								if (text12 != null && text12.Length == 1)
								{
									char c = text12[0];
									if ((c == '\u00a0' || c == '\u2002') && z0ZzZzhbk2.z0tek("empty"))
									{
										xTextElementList.Clear();
									}
								}
							}
						}
					}
					XTextElement lastElement3 = p0.z0be().LastElement;
					if (lastElement3 != null && !(lastElement3 is XTextLineBreakElement) && !(lastElement3 is XTextParagraphFlagElement))
					{
						XTextParagraphFlagElement xTextParagraphFlagElement11 = new XTextParagraphFlagElement();
						xTextParagraphFlagElement11.z0yek(p0.z0jr(), p0);
						xTextParagraphFlagElement11.z0uek((XTextElement)z0ZzZzwjh2);
						p0.z0be().Add(xTextParagraphFlagElement11);
					}
					if (xTextElementList.Count > 0)
					{
						((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList);
					}
				}
				XTextParagraphFlagElement xTextParagraphFlagElement12 = new XTextParagraphFlagElement();
				xTextParagraphFlagElement12.z0yek(p0.z0jr(), p0);
				xTextParagraphFlagElement12.z0uek((XTextElement)z0ZzZzwjh2);
				p0.z0be().z0hrk(xTextParagraphFlagElement12);
				break;
			}
			case "br":
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (z0ZzZzhbk2.z0tek("dcpf"))
				{
					XTextParagraphFlagElement xTextParagraphFlagElement8 = new XTextParagraphFlagElement();
					if (z0tek(z0ZzZzhbk2))
					{
						z0ZzZzhbk p8 = z0uek(z0ZzZzhbk2);
						z0ZzZzevk z0ZzZzevk4 = z0yek(p8);
						if (z0ZzZzevk4 != null)
						{
							z0ZzZzevk3.z0eek(z0ZzZzevk4, p1: false, new string[1] { "line-height" }, z0crk);
						}
						z0mrk = true;
					}
					bool flag3 = false;
					for (XTextContainerElement xTextContainerElement = p0; xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
					{
						if (xTextContainerElement is z0ZzZzwjh)
						{
							xTextParagraphFlagElement8.z0yek((DocumentContentStyle)((XTextElement)xTextContainerElement).z0xrk().Clone());
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						xTextParagraphFlagElement8.z0buk = z0tek(p1, z0ZzZzevk3, xTextParagraphFlagElement8, z0ZzZzhbk2);
					}
					p0.z0be().z0hrk(xTextParagraphFlagElement8);
				}
				else
				{
					XTextLineBreakElement xTextLineBreakElement = new XTextLineBreakElement();
					xTextLineBreakElement.z0eek(z0ZzZzhbk2.z0tek("dcautogen"));
					p0.z0be().z0hrk(xTextLineBreakElement);
				}
				break;
			case "table":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0cek, z0crk);
				}
				XTextTableElement xTextTableElement2 = new XTextTableElement();
				string p6 = null;
				if (z0ZzZzevk3.z0eek("text-align", out p6))
				{
					if (string.Compare(p6, "right", true) == 0)
					{
						xTextTableElement2.z0pek(DCTableAlignment.Right);
					}
					else if (string.Compare(p6, "center", true) == 0)
					{
						xTextTableElement2.z0pek(DCTableAlignment.Center);
					}
				}
				xTextTableElement2.z0yek(xTextDocument, p0);
				z0tek(xTextTableElement2, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				XTextElement lastElement = p0.z0be().LastElement;
				if (lastElement != null && !(lastElement is XTextParagraphFlagElement) && !(lastElement is XTextLineBreakElement) && !(lastElement is XTextTableElement))
				{
					p0.z0be().Add(new XTextLineBreakElement());
				}
				p0.z0be().Add(xTextTableElement2);
				break;
			}
			case "sub":
				z0qrk = true;
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				z0ZzZzevk3.z0eek("dc_sub", "true");
				z0ZzZzevk3.z0iek("dc_sup");
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				z0qrk = false;
				break;
			case "sup":
				z0trk = true;
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				z0ZzZzevk3.z0eek("dc_sup", "true");
				z0ZzZzevk3.z0iek("dc_sub");
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				z0trk = false;
				break;
			case "center":
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				z0ZzZzevk3.z0eek("text-align", "center");
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				break;
			case "em":
			case "i":
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				z0ZzZzevk3.z0eek("font-style", "italic");
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				break;
			case "strong":
			case "b":
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				z0ZzZzevk3.z0eek("font-weight", "bold");
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				break;
			case "strike":
			case "s":
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				z0ZzZzevk3.z0eek("text-decoration", "line-through");
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				break;
			case "u":
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				z0ZzZzevk3.z0eek("text-decoration", "underline");
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				break;
			case "font":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				string p9 = null;
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				if (z0ZzZzhbk2.z0eek("color", out p9))
				{
					z0ZzZzevk3.z0eek("color", p9);
				}
				if (z0ZzZzhbk2.z0eek("face", out p9))
				{
					z0ZzZzevk3.z0eek("font-family", p9);
				}
				if (z0ZzZzhbk2.z0eek("size", out p9))
				{
					int num2 = z0tek(p9, 0);
					int num3 = 0;
					switch (num2)
					{
					case 1:
						num3 = 7;
						break;
					case 2:
						num3 = 10;
						break;
					case 3:
						num3 = 12;
						break;
					case 4:
						num3 = 14;
						break;
					case 5:
						num3 = 18;
						break;
					case 6:
						num3 = 24;
						break;
					case 7:
						num3 = 35;
						break;
					}
					if (num3 > 0)
					{
						z0ZzZzevk3.z0eek("font-size", num3 + "pt");
					}
				}
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				break;
			}
			case "h1":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				z0ZzZzevk3.z0eek("font-size", z0ZzZzqik.z0rek(24));
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				XTextParagraphFlagElement xTextParagraphFlagElement10 = new XTextParagraphFlagElement();
				xTextParagraphFlagElement10.z0yek(xTextDocument, p0);
				xTextParagraphFlagElement10.z0yek(z0yek(p1, z0ZzZzevk3, xTextParagraphFlagElement10, z0ZzZzhbk2));
				xTextParagraphFlagElement10.z0xrk().ParagraphOutlineLevel = 0;
				p0.z0be().Add(xTextParagraphFlagElement10);
				break;
			}
			case "h2":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				z0ZzZzevk3.z0eek("font-size", z0ZzZzqik.z0rek(18));
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				XTextParagraphFlagElement xTextParagraphFlagElement9 = new XTextParagraphFlagElement();
				xTextParagraphFlagElement9.z0yek(xTextDocument, p0);
				xTextParagraphFlagElement9.z0yek(z0yek(p1, z0ZzZzevk3, xTextParagraphFlagElement9, z0ZzZzhbk2));
				xTextParagraphFlagElement9.z0xrk().ParagraphOutlineLevel = 1;
				p0.z0be().Add(xTextParagraphFlagElement9);
				break;
			}
			case "h3":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				z0ZzZzevk3.z0eek("font-size", z0ZzZzqik.z0rek(13));
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				XTextParagraphFlagElement xTextParagraphFlagElement7 = new XTextParagraphFlagElement();
				xTextParagraphFlagElement7.z0yek(xTextDocument, p0);
				xTextParagraphFlagElement7.z0yek(z0yek(p1, z0ZzZzevk3, xTextParagraphFlagElement7, z0ZzZzhbk2));
				xTextParagraphFlagElement7.z0xrk().ParagraphOutlineLevel = 2;
				p0.z0be().Add(xTextParagraphFlagElement7);
				break;
			}
			case "h4":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				z0ZzZzevk3.z0eek("font-size", z0ZzZzqik.z0rek(12));
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				XTextParagraphFlagElement xTextParagraphFlagElement5 = new XTextParagraphFlagElement();
				xTextParagraphFlagElement5.z0yek(xTextDocument, p0);
				xTextParagraphFlagElement5.z0yek(z0yek(p1, z0ZzZzevk3, xTextParagraphFlagElement5, z0ZzZzhbk2));
				xTextParagraphFlagElement5.z0xrk().ParagraphOutlineLevel = 3;
				p0.z0be().Add(xTextParagraphFlagElement5);
				break;
			}
			case "h5":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				z0ZzZzevk3.z0eek("font-size", z0ZzZzqik.z0rek(10));
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				XTextParagraphFlagElement xTextParagraphFlagElement4 = new XTextParagraphFlagElement();
				xTextParagraphFlagElement4.z0yek(xTextDocument, p0);
				xTextParagraphFlagElement4.z0yek(z0yek(p1, z0ZzZzevk3, xTextParagraphFlagElement4, z0ZzZzhbk2));
				xTextParagraphFlagElement4.z0xrk().ParagraphOutlineLevel = 4;
				p0.z0be().Add(xTextParagraphFlagElement4);
				break;
			}
			case "h6":
			{
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				z0ZzZzevk3.z0eek("font-size", z0ZzZzqik.z0rek(8));
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				XTextParagraphFlagElement xTextParagraphFlagElement2 = new XTextParagraphFlagElement();
				xTextParagraphFlagElement2.z0yek(xTextDocument, p0);
				xTextParagraphFlagElement2.z0yek(z0yek(p1, z0ZzZzevk3, xTextParagraphFlagElement2, z0ZzZzhbk2));
				xTextParagraphFlagElement2.z0xrk().ParagraphOutlineLevel = 5;
				p0.z0be().Add(xTextParagraphFlagElement2);
				break;
			}
			default:
				if (z0ZzZzevk3 == null)
				{
					z0ZzZzevk3 = new z0ZzZzevk();
				}
				if (p1.z0tek() != null)
				{
					z0ZzZzevk3.z0eek(p1.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
				}
				z0tek(p0, new z0ZzZzajh(p1, z0ZzZzhbk2, xTextDocument, z0ZzZzevk3));
				break;
			case "header":
			case "footer":
				break;
			}
		}
	}

	private int z0tek(z0ZzZzajh p0, z0ZzZzevk p1, XTextElement p2, z0ZzZzhbk p3)
	{
		z0prk++;
		int num = -1;
		if (p1 != null && !z0lrk.TryGetValue(p1, out num))
		{
			DocumentContentStyle style = z0yek(p0, p1, p2, p3);
			num = z0jrk.z0gnk().GetStyleIndex(style);
			z0lrk[p1] = num;
		}
		return num;
	}

	private void z0tek(XTextTableElement p0, z0ZzZzajh p1)
	{
		z0rrk = new List<int>();
		if (p0 == null)
		{
			throw new ArgumentNullException("table");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("args");
		}
		XTextDocument xTextDocument = p0.z0jr();
		string text = p1.z0tek().z0uek("display");
		if (text != null && (string.Compare(text, "none", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(text, "hidden", StringComparison.OrdinalIgnoreCase) == 0))
		{
			p0.Visible = false;
		}
		float p2 = 0f;
		z0tek(p1.z0yek(), p0);
		foreach (z0ZzZzunk item in p1.z0yek().z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "dc_printvisibility":
				p0.PrintVisibility = z0eek(item.z0yek(), ElementVisibility.Visible);
				break;
			case "dc_accepttab":
			{
				string text27 = item.z0yek();
				if (!string.IsNullOrEmpty(text27) && text27 != "false")
				{
					p0.AcceptTab = z0tek(text27, p1: false);
				}
				break;
			}
			case "dc_alignment":
			{
				string text12 = item.z0yek();
				if (!string.IsNullOrEmpty(text12) && text12 != "Default")
				{
					p0.z0pek(z0rek<DCTableAlignment>(text12));
				}
				break;
			}
			case "dc_allowrebindingdatasource":
			{
				string text23 = item.z0yek();
				if (!string.IsNullOrEmpty(text23) && text23 != "false")
				{
					p0.z0xek(z0tek(text23, p1: false));
				}
				break;
			}
			case "dc_allowuserdeleterow":
			{
				string text3 = item.z0yek();
				if (!string.IsNullOrEmpty(text3) && text3 != "true")
				{
					p0.AllowUserDeleteRow = z0tek(text3, p1: false);
				}
				break;
			}
			case "dc_allowuserinsertrow":
			{
				string text21 = item.z0yek();
				if (!string.IsNullOrEmpty(text21) && text21 != "true")
				{
					p0.AllowUserInsertRow = z0tek(text21, p1: false);
				}
				break;
			}
			case "dc_allowusertoresizecolumns":
			{
				string text5 = item.z0yek();
				if (!string.IsNullOrEmpty(text5) && text5 != "true")
				{
					p0.AllowUserToResizeColumns = z0tek(text5, p1: false);
				}
				break;
			}
			case "dc_allowusertoresizeeveninformviewmode":
			{
				string text26 = item.z0yek();
				if (!string.IsNullOrEmpty(text26) && text26 != "false")
				{
					p0.z0pek(z0tek(text26, p1: false));
				}
				break;
			}
			case "dc_allowusertoresizerows":
			{
				string text17 = item.z0yek();
				if (!string.IsNullOrEmpty(text17) && text17 != "true")
				{
					p0.AllowUserToResizeRows = z0tek(text17, p1: false);
				}
				break;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(item);
				break;
			case "dc_bringouttosave":
			{
				string text8 = item.z0yek();
				if (!string.IsNullOrEmpty(text8) && text8 != "false")
				{
					p0.z0st(z0tek(text8, p1: false));
				}
				break;
			}
			case "dc_canbereferenced":
			{
				string text29 = item.z0yek();
				if (!string.IsNullOrEmpty(text29) && text29 != "false")
				{
					p0.z0jt(z0tek(text29, p1: false));
				}
				break;
			}
			case "dc_compressownerlinespacing":
			{
				string text24 = item.z0yek();
				if (!string.IsNullOrEmpty(text24) && text24 != "false")
				{
					p0.CompressOwnerLineSpacing = z0tek(text24, p1: false);
				}
				break;
			}
			case "dc_contentreadonly":
			{
				string text19 = item.z0yek();
				if (!string.IsNullOrEmpty(text19) && text19 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text19, ContentReadonlyState.Inherit);
				}
				break;
			}
			case "dc_contentreadonlyexpression":
			{
				string text16 = item.z0yek();
				if (!string.IsNullOrEmpty(text16))
				{
					p0.ContentReadonlyExpression = text16;
				}
				break;
			}
			case "dc_copysource":
			{
				string text14 = item.z0yek();
				if (!string.IsNullOrEmpty(text14))
				{
					p0.CopySource = new CopySourceInfo();
					p0.CopySource.DCReadString(text14);
				}
				break;
			}
			case "dc_dataforrevaluebinding":
			{
				string text11 = item.z0yek();
				if (!string.IsNullOrEmpty(text11))
				{
					p0.z0pek(text11);
				}
				break;
			}
			case "dc_deleteable":
			{
				string text6 = item.z0yek();
				if (!string.IsNullOrEmpty(text6) && text6 != "true")
				{
					p0.Deleteable = z0tek(text6, p1: false);
				}
				break;
			}
			case "dc_enablepermission":
			{
				string text30 = item.z0yek();
				if (!string.IsNullOrEmpty(text30) && text30 != "Inherit")
				{
					p0.EnablePermission = z0rek<DCBooleanValue>(text30);
				}
				break;
			}
			case "dc_enablevaluevalidate":
			{
				string text28 = item.z0yek();
				if (!string.IsNullOrEmpty(text28))
				{
					p0.EnableValueValidate = z0tek(text28, p1: false);
				}
				break;
			}
			case "dc_holdwholeline":
			{
				string text25 = item.z0yek();
				if (!string.IsNullOrEmpty(text25) && text25 != "true")
				{
					p0.z0bek(z0tek(text25, p1: false));
				}
				break;
			}
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "ircr":
			{
				string text22 = item.z0yek();
				if (!string.IsNullOrEmpty(text22) && text22 != "false")
				{
					((XTextContainerElement)p0).z0xek(z0tek(text22, p1: false));
				}
				break;
			}
			case "dc_limitedinputchars":
			{
				string text20 = item.z0yek();
				if (!string.IsNullOrEmpty(text20))
				{
					p0.LimitedInputChars = text20;
				}
				break;
			}
			case "dc_propertyexpressions":
			{
				string text18 = item.z0yek();
				if (!string.IsNullOrEmpty(text18))
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text18);
				}
				break;
			}
			case "rmfhk":
			{
				string text15 = item.z0yek();
				if (!string.IsNullOrEmpty(text15) && text15 != "None")
				{
					p0.z0yr(z0rek<MoveFocusHotKeys>(text15));
				}
				break;
			}
			case "dc_subfieldmode":
			{
				string text13 = item.z0yek();
				if (!string.IsNullOrEmpty(text13) && text13 != "None")
				{
					p0.z0pek(z0rek<TableSubfieldMode>(text13));
				}
				break;
			}
			case "dc_subfieldnumber":
			{
				string text10 = item.z0yek();
				if (!string.IsNullOrEmpty(text10) && text10 != "1")
				{
					p0.z0mek(z0tek(text10, 0));
				}
				break;
			}
			case "dc_validatestyle":
			{
				string text9 = item.z0yek();
				if (!string.IsNullOrEmpty(text9))
				{
					text9 = text9.Replace("'", "\"");
					p0.ValidateStyle = new ValueValidateStyle();
					((z0ZzZzcuk)p0.ValidateStyle).DCReadString(text9);
				}
				break;
			}
			case "dc_valuebinding":
			{
				string text7 = item.z0yek();
				if (!string.IsNullOrEmpty(text7))
				{
					p0.ValueBinding = new z0ZzZzevj();
					((z0ZzZzcuk)p0.ValueBinding).DCReadString(text7);
				}
				break;
			}
			case "dc_visible":
			{
				string text4 = item.z0yek();
				if (!string.IsNullOrEmpty(text4) && text4 != "true")
				{
					p0.Visible = z0tek(text4, p1: false);
				}
				break;
			}
			case "dc_visibleexpression":
			{
				string text2 = item.z0yek();
				if (!string.IsNullOrEmpty(text2))
				{
					p0.VisibleExpression = text2;
				}
				break;
			}
			case "bd2019":
				z0tek(((XTextElement)p0).z0xrk(), item.z0yek());
				break;
			case "cmpols":
				p0.CompressOwnerLineSpacing = z0tek(item.z0yek(), p1: true);
				break;
			case "border":
				float.TryParse(item.z0yek(), out p2);
				break;
			}
		}
		z0ZzZzuvk z0ZzZzuvk2 = (z0ZzZzuvk)p1.z0yek();
		if (z0ZzZzuvk2.z0eek() != null && z0ZzZzuvk2.z0eek().Count > 0)
		{
			foreach (z0ZzZzhbk item2 in z0ZzZzuvk2.z0eek().z0xrk())
			{
				XTextTableColumnElement xTextTableColumnElement = p0.z0vek();
				z0ZzZzevk z0ZzZzevk2 = z0yek(item2);
				string p3 = null;
				string p4 = null;
				foreach (z0ZzZzunk item3 in item2.z0oek().z0xrk())
				{
					if (item3.z0rek() == "width")
					{
						p3 = item3.z0yek();
					}
					else if (item3.z0rek() == "dsw")
					{
						p4 = item3.z0yek();
					}
					else if (item3.z0rek() == "dc_attributes")
					{
						xTextTableColumnElement.Attributes = z0tek(item3);
					}
					else if (item3.z0rek() == "id")
					{
						xTextTableColumnElement.ID = item3.z0yek();
					}
					else if (item3.z0rek() == "dc_valuebinding")
					{
						z0ZzZzevj z0ZzZzevj2 = new z0ZzZzevj();
						z0ZzZzevj2.DCReadString(item3.z0yek());
						xTextTableColumnElement.ValueBinding = z0ZzZzevj2;
					}
				}
				xTextTableColumnElement.Width = z0tek(z0ZzZzevk2.z0yek("width"), p3, p4, xTextDocument, 0f);
				p0.z0srk().Add(xTextTableColumnElement);
			}
		}
		if (((XTextElement)xTextDocument.z0xyk()).z0ork() <= 0f)
		{
			xTextDocument.PageSettings.z0prk();
		}
		z0ZzZzhbk z0ZzZzhbk2 = p1.z0yek();
		foreach (z0ZzZzhbk item4 in p1.z0uek().z0xrk())
		{
			if (item4.z0cak() == "tr")
			{
				break;
			}
			if (item4.z0cak() == "tbody")
			{
				z0ZzZzhbk2 = item4;
				break;
			}
		}
		p0.z0stk().Capacity = z0ZzZzhbk2.z0oqk().Count;
		foreach (z0ZzZzhbk item5 in z0ZzZzhbk2.z0oqk().z0xrk())
		{
			if (item5.z0cak() == "tr")
			{
				XTextTableRowElement p5 = p0.z0nrk();
				p0.z0stk().z0hrk(p5);
				z0tek(p5, item5, p1, p2);
			}
		}
		z0tek(p0);
		z0yek(p0, p1);
		foreach (int item6 in z0rrk)
		{
			p0.z0srk()[item6].Visible = false;
		}
		p0.z0pek(p0: true, p1: false);
	}

	private z0ZzZzevk z0yek(z0ZzZzhbk p0)
	{
		if (p0 is z0ZzZzmvk)
		{
			return null;
		}
		return z0tek(p0, p0.z0eek("class"));
	}

	private void z0tek(XTextSignImageElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		foreach (z0ZzZzunk item in p1.z0yek().z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "title":
			{
				string text5 = item.z0yek();
				if (text5 != null && text5.Length > 0)
				{
					p0.Title = text5;
				}
				break;
			}
			case "dc_signuserid":
			{
				string text9 = item.z0yek();
				if (text9 != null && text9.Length > 0)
				{
					p0.SignUserID = text9;
				}
				break;
			}
			case "dc_signusername":
			{
				string text2 = item.z0yek();
				if (text2 != null && text2.Length > 0)
				{
					p0.SignUserName = text2;
				}
				break;
			}
			case "dc_signclientname":
			{
				string text4 = item.z0yek();
				if (text4 != null && text4.Length > 0)
				{
					p0.SignClientName = text4;
				}
				break;
			}
			case "dc_signtime":
			{
				string text12 = item.z0yek();
				if (text12 != null && text12.Length > 0)
				{
					p0.SignTime = DateTime.Parse(text12);
				}
				break;
			}
			case "dc_signrange":
			{
				string text7 = item.z0yek();
				if (text7 != null && text7.Length > 0)
				{
					p0.SignRange = z0rek<DCSignRange>(text7);
				}
				break;
			}
			case "dc_lastverifyresult":
			{
				string text3 = item.z0yek();
				if (text3 != null && text3.Length > 0)
				{
					p0.LastVerifyResult = Convert.FromBase64String(text3);
				}
				break;
			}
			case "dc_dataforselfcheck":
			{
				string text11 = item.z0yek();
				if (text11 != null && text11.Length > 0)
				{
					p0.DataForSelfCheck = Convert.FromBase64String(text11);
				}
				break;
			}
			case "dc_signprovidername":
			{
				string text8 = item.z0yek();
				if (text8 != null && text8.Length > 0)
				{
					p0.SignProviderName = text8;
				}
				break;
			}
			case "dc_imageinfrontoftext":
			{
				string text13 = item.z0yek();
				if (text13 != null && text13.Length > 0)
				{
					if (text13 == "true")
					{
						p0.ZOrderStyle = ElementZOrderStyle.InFrontOfText;
					}
					else if (text13 == "false")
					{
						p0.ZOrderStyle = ElementZOrderStyle.Normal;
					}
				}
				break;
			}
			case "dc_useinnersignprovider":
			{
				string text10 = item.z0yek();
				if (text10 != null && text10.Length > 0)
				{
					p0.UseInnerSignProvider = bool.Parse(text10);
				}
				break;
			}
			case "dc_bstrpfx":
			{
				string text6 = item.z0yek();
				if (text6 != null && text6.Length > 0)
				{
					if (p0.Attributes == null)
					{
						p0.Attributes = new XAttributeList();
					}
					p0.Attributes.z0eek("bstrpfx", text6);
				}
				break;
			}
			case "dc_bstrpwd":
			{
				string text = item.z0yek();
				if (text != null && text.Length > 0)
				{
					if (p0.Attributes == null)
					{
						p0.Attributes = new XAttributeList();
					}
					p0.Attributes.z0eek("bstrpwd", text);
				}
				break;
			}
			}
		}
		if (p1.z0rek("border"))
		{
			DocumentContentStyle documentContentStyle = z0yek(p1, p1.z0tek(), p0, p1.z0yek());
			documentContentStyle.BorderWidth = z0tek(p1.z0tek("border"), 0);
			documentContentStyle.BorderLeft = true;
			documentContentStyle.BorderTop = true;
			documentContentStyle.BorderRight = true;
			documentContentStyle.BorderBottom = true;
			p0.z0yek(documentContentStyle);
		}
		else
		{
			p0.z0buk = z0tek(p1, p1.z0tek(), p0, p1.z0yek());
		}
		z0ZzZzxdh z0ZzZzxdh2 = z0tek(p1.z0yek(), p0.z0jr());
		if (z0ZzZzxdh2.z0rek() > 0f)
		{
			p0.Width = z0ZzZzxdh2.z0rek();
		}
		if (z0ZzZzxdh2.z0tek() > 0f)
		{
			p0.Height = z0ZzZzxdh2.z0tek();
		}
		if (!p0.HasImageContent() && p1.z0rek("src"))
		{
			string p2 = p1.z0tek("src");
			string text14 = p1.z0tek("dc_nativesrc");
			if (text14 != null && text14.Length > 0)
			{
				p0.LoadImageBase64(text14);
			}
			else
			{
				byte[] array = z0yek(p2);
				if (array != null)
				{
					p0.LoadImageData(array);
				}
				else
				{
					p2 = p1.z0rek().z0tek(p2);
					z0ZzZzpmk z0ZzZzpmk2 = z0tek(p0, p2);
					p0.LoadImageBase64(z0ZzZzpmk2.ImageDataBase64String);
				}
			}
		}
		if (p0.Width == 0f || p0.Height == 0f)
		{
			p0.z0rek();
		}
	}

	private static string z0mek(string p0)
	{
		return p0;
	}

	private DocumentContentStyle z0yek(z0ZzZzajh p0, z0ZzZzevk p1, XTextElement p2, z0ZzZzhbk p3)
	{
		if (p1 == null)
		{
			return null;
		}
		if (!(p2 is z0ZzZzwjh) && p2 != null && p2.z0fyk() != null)
		{
			return p2.z0fyk();
		}
		DocumentContentStyle documentContentStyle = null;
		if (z0srk.TryGetValue(p1, out documentContentStyle))
		{
			documentContentStyle = (DocumentContentStyle)documentContentStyle.Clone();
		}
		documentContentStyle = new DocumentContentStyle();
		z0srk[p1] = documentContentStyle;
		for (int num = p1.z0iek().Count - 1; num >= 0; num--)
		{
			z0ZzZzunk z0ZzZzunk2 = p1.z0iek()[num];
			z0tek(p0, documentContentStyle, z0ZzZzunk2.z0rek(), z0ZzZzunk2.z0yek(), p2);
		}
		if (documentContentStyle.Color.ToArgb() == z0frk_jiejie20260327142557)
		{
			((z0ZzZzcok)documentContentStyle).z0oek();
		}
		if ((double)documentContentStyle.BorderWidth > 1.01 && p2 != null)
		{
			float num2 = z0ZzZzrpk.z0eek(documentContentStyle.BorderWidth, GraphicsUnit.Pixel, GraphicsUnit.Document);
			if (documentContentStyle.BorderLeft)
			{
				documentContentStyle.PaddingLeft += num2;
			}
			if (documentContentStyle.BorderTop)
			{
				documentContentStyle.PaddingTop += num2;
			}
			if (documentContentStyle.BorderRight)
			{
				documentContentStyle.PaddingRight += num2;
			}
			if (documentContentStyle.BorderBottom)
			{
				documentContentStyle.PaddingBottom += num2;
			}
		}
		if (p3 != null && p3 is z0ZzZzmvk && p3.z0eek().z0tek("dc_protecttype"))
		{
			string text = p3.z0eek().z0rek("dc_protecttype");
			try
			{
				documentContentStyle.ProtectType = (ContentProtectType)Enum.Parse(typeof(ContentProtectType), text, true);
			}
			catch (Exception)
			{
			}
		}
		return documentContentStyle;
	}

	public void z0tek(XTextDocument p0, z0ZzZzhbk p1)
	{
		if (p1 is z0ZzZzkbk)
		{
			z0ZzZzkbk z0ZzZzkbk2 = (z0ZzZzkbk)p1;
			z0ZzZzhbk z0ZzZzhbk2 = z0ZzZzkbk2.z0iek("divDocumentBody_0");
			if (z0ZzZzhbk2 != null && z0ZzZzhbk2.z0eek("dctype") == "XTextDocumentBodyElement")
			{
				z0ZzZzajh p2 = new z0ZzZzajh(null, z0ZzZzhbk2, p0, null);
				z0tek((XTextElement)p0.z0xyk(), p2);
				return;
			}
			z0ZzZzhbk z0ZzZzhbk3 = z0ZzZzkbk2.z0iek("header");
			if (z0ZzZzhbk3 != null && z0ZzZzhbk3.z0cak() == "header")
			{
				z0ZzZzajh p3 = new z0ZzZzajh(null, z0ZzZzhbk3, p0, null);
				z0tek((XTextElement)p0.z0pyk(), p3);
			}
			z0ZzZzhbk z0ZzZzhbk4 = z0ZzZzkbk2.z0iek("footer");
			if (z0ZzZzhbk4 != null && z0ZzZzhbk4.z0cak() == "footer")
			{
				z0ZzZzajh p4 = new z0ZzZzajh(null, z0ZzZzhbk4, p0, null);
				z0tek((XTextElement)p0.z0lik(), p4);
			}
		}
		z0tek((XTextElement)p0.z0xyk(), new z0ZzZzajh(null, p1, p0, null));
	}

	private static z0ZzZzhbk z0uek(z0ZzZzhbk p0)
	{
		z0ZzZzhbk z0ZzZzhbk2 = null;
		string text = ((z0ZzZzhbk)p0.z0eek()).z0eek("id");
		if (p0.z0eek().z0cak() == "div")
		{
			switch (text)
			{
			case "divDocumentBody_0":
			case "divXTextDocumentFooterElement":
			case "divXTextDocumentHeaderElement":
				return p0;
			}
		}
		return z0uek(p0.z0eek());
	}

	private void z0yek(XTextTableElement p0, z0ZzZzajh p1)
	{
		XTextDocument xTextDocument = p0.z0jr();
		List<XTextTableColumnElement> list = new List<XTextTableColumnElement>();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0srk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
				if (xTextTableColumnElement.Width == 0f)
				{
					list.Add(xTextTableColumnElement);
				}
			}
		}
		float num = xTextDocument.z0spk();
		float num2 = z0tek(p1.z0tek("width"), num);
		if (list.Count == 1)
		{
			float num3 = num2;
			if (num3 <= 0f)
			{
				num3 = num;
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0srk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableColumnElement xTextTableColumnElement2 = (XTextTableColumnElement)z0bpk.Current;
					num3 -= xTextTableColumnElement2.Width;
				}
			}
			list[0].Width = num3;
		}
		else if (list.Count > 0)
		{
			float[] array = new float[p0.z0srk().Count];
			float num4 = 0f;
			p0.z0cek(p0: true);
			p0.z0krk();
			float num5 = 0f;
			using (z0ZzZzjpk p2 = xTextDocument.z0ru())
			{
				z0ZzZzvxj p3 = new z0ZzZzvxj(xTextDocument, p2, z0ZzZzbdh.z0xek);
				for (int i = 0; i < p0.z0srk().Count; i++)
				{
					XTextElement xTextElement = p0.z0srk()[i];
					if (xTextElement.Width == 0f)
					{
						float num6 = 50f;
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0stk().z0ltk())
						{
							while (z0bpk.MoveNext())
							{
								XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
								if (i >= xTextTableRowElement.z0rek().Count)
								{
									continue;
								}
								XTextTableCellElement obj = (XTextTableCellElement)xTextTableRowElement.z0rek()[i];
								obj.z0rt(new ElementLoadEventArgs(obj, "html"));
								obj.z0mr(p3);
								float num7 = 0f;
								using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = obj.z0trk().z0ltk())
								{
									while (z0bpk2.MoveNext())
									{
										XTextElement current = z0bpk2.Current;
										num7 += current.Width;
									}
								}
								if (num7 > num6)
								{
									num6 = num7;
								}
							}
						}
						array[i] = num6;
						num4 += num6;
					}
					else
					{
						num4 += xTextElement.Width;
						num5 += xTextElement.Width;
					}
				}
			}
			do
			{
				float num8 = (num - num5) / (num4 - num5);
				if (num8 > 1f)
				{
					num8 = 1f;
				}
				num4 = 0f;
				for (int j = 0; j < p0.z0srk().Count; j++)
				{
					XTextTableColumnElement xTextTableColumnElement3 = (XTextTableColumnElement)p0.z0srk()[j];
					if (list.Contains(xTextTableColumnElement3))
					{
						xTextTableColumnElement3.Width = array[j] * num8;
					}
					num4 += xTextTableColumnElement3.Width;
				}
			}
			while (num4 > num + 1f);
		}
		if (num2 > 0f)
		{
			float num9 = 0f;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0srk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableColumnElement xTextTableColumnElement4 = (XTextTableColumnElement)z0bpk.Current;
					num9 += xTextTableColumnElement4.Width;
				}
			}
			if (num9 < num2)
			{
				float num10 = num2 / num9;
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0srk().z0ltk();
				while (z0bpk.MoveNext())
				{
					((XTextTableColumnElement)z0bpk.Current).Width *= num10;
				}
			}
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0zek().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableCellElement obj2 = (XTextTableCellElement)z0bpk.Current;
			obj2.Width = 0f;
			obj2.Height = 0f;
		}
	}

	private z0ZzZzxdh z0tek(z0ZzZzhbk p0, XTextDocument p1)
	{
		float p2 = -1f;
		z0ZzZzevk z0ZzZzevk2 = z0yek(p0);
		string p3 = null;
		if (z0ZzZzevk2 != null && z0ZzZzevk2.z0eek("width", out p3))
		{
			float num = z0tek(p3, p1);
			if (num > 0f)
			{
				p2 = num;
			}
		}
		else if (p0.z0eek("width", out p3))
		{
			p2 = z0tek(p3, p1);
		}
		float p4 = -1f;
		if (z0ZzZzevk2 != null && z0ZzZzevk2.z0eek("height", out p3))
		{
			float num2 = z0tek(p3, p1);
			if (num2 > 0f)
			{
				p4 = num2;
			}
		}
		else if (p0.z0eek("height", out p3))
		{
			p4 = z0tek(p3, p1);
		}
		return new z0ZzZzxdh(p2, p4);
	}

	private void z0tek(XTextHorizontalLineElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		foreach (z0ZzZzunk item in p1.z0yek().z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "dc_visible":
			{
				string text2 = item.z0yek();
				if (text2 != null && text2.Length > 0)
				{
					p0.Visible = z0tek(text2, p1: false);
				}
				break;
			}
			case "width":
			{
				string text = item.z0yek();
				if (text != null && text.Contains("px"))
				{
					text = text.Replace("px", "");
					float p2 = 0f / 0f;
					if (float.TryParse(text, out p2))
					{
						float num = z0ZzZzrpk.z0eek(p2, GraphicsUnit.Pixel, GraphicsUnit.Millimeter);
						p0.LineLengthInCM = (float)Math.Round(num / 10f, 2);
					}
				}
				break;
			}
			}
		}
		z0ZzZzevk z0ZzZzevk2 = z0yek(p1.z0yek());
		if (z0ZzZzevk2 == null)
		{
			return;
		}
		Color p3 = Color.Empty;
		float p4 = 0f / 0f;
		string text3 = z0ZzZzevk2.z0iek().z0uek("border-top");
		if (text3 != null && text3.Split(' ').Length >= 3)
		{
			string[] array = text3.Split(' ');
			z0ZzZzevk2.z0iek().z0eek("border-top-width", array[0]);
			z0ZzZzevk2.z0iek().z0eek("border-top-style", array[1]);
			if (array.Length == 3)
			{
				z0ZzZzevk2.z0iek().z0eek("border-top-color", array[2]);
			}
			else if (array.Length == 5)
			{
				z0ZzZzevk2.z0iek().z0eek("border-top-color", array[2] + array[3] + array[4]);
			}
		}
		for (int num2 = z0ZzZzevk2.z0iek().Count - 1; num2 >= 0; num2--)
		{
			z0ZzZzunk z0ZzZzunk2 = z0ZzZzevk2.z0iek()[num2];
			switch (z0ZzZzunk2.z0rek())
			{
			case "border-top-width":
				if (float.TryParse(z0ZzZzunk2.z0yek().Replace("px", ""), out p4))
				{
					p0.LineSize = z0ZzZzrpk.z0eek(p4, GraphicsUnit.Pixel, GraphicsUnit.Document);
				}
				break;
			case "border-top-color":
				if (z0tek(z0ZzZzunk2.z0yek(), out p3))
				{
					p0.z0xrk().Color = p3;
				}
				break;
			case "border-top-style":
				if (z0ZzZzunk2.z0yek() == "dotted")
				{
					p0.LineStyle = DashStyle.Dot;
				}
				else if (z0ZzZzunk2.z0yek() == "dashed")
				{
					p0.LineStyle = DashStyle.Dash;
				}
				else
				{
					p0.LineStyle = DashStyle.Solid;
				}
				break;
			}
		}
	}

	private void z0tek(XTextTableRowElement p0, z0ZzZzhbk p1, z0ZzZzajh p2, float p3)
	{
		XTextDocument xTextDocument = p0.z0jr();
		XTextTableElement xTextTableElement = p0.z0gr();
		z0ZzZzevk z0ZzZzevk2 = z0yek(p1);
		if (z0ZzZzevk2 == null)
		{
			z0ZzZzevk2 = p2.z0tek();
		}
		else if (p2.z0tek().z0tek_jiejie20260327142557())
		{
			z0ZzZzevk2.z0eek(p2.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
		}
		string p4 = null;
		string p5 = null;
		string p6 = null;
		string p7 = null;
		string p8 = null;
		for (int num = p1.z0oek().Count - 1; num >= 0; num--)
		{
			z0ZzZzunk z0ZzZzunk2 = p1.z0oek()[num];
			switch (z0ZzZzunk2.z0rek())
			{
			case "default_rmfhk":
				p6 = z0ZzZzunk2.z0yek();
				break;
			case "default_dspd":
				p7 = z0ZzZzunk2.z0yek();
				break;
			case "default_bd2019":
				p8 = z0ZzZzunk2.z0yek();
				break;
			case "dc_printvisibility":
			{
				string text22 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text22))
				{
					p0.PrintVisibility = z0rek<ElementVisibility>(text22);
				}
				break;
			}
			case "dc_allowinsertrowdownusehotkey":
			{
				string text3 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text3) && text3 != "EnableOnlyForLastRow")
				{
					p0.AllowInsertRowDownUseHotKey = z0rek<DCInsertRowDownUseHotKeys>(text3);
				}
				break;
			}
			case "dc_allowusertoresizeheight":
			{
				string text21 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text21) && text21 != "Inherit")
				{
					p0.AllowUserToResizeHeight = z0rek<DCBooleanValue>(text21);
				}
				break;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(z0ZzZzunk2);
				break;
			case "dc_bringouttosave":
			{
				string text8 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text8) && text8 != "false")
				{
					p0.z0st(z0tek(text8, p1: false));
				}
				break;
			}
			case "dc_canbereferenced":
			{
				string text26 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text26) && text26 != "false")
				{
					p0.z0jt(z0tek(text26, p1: false));
				}
				break;
			}
			case "dc_cansplitbypageline":
			{
				string text18 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text18) && text18 != "true")
				{
					p0.CanSplitByPageLine = z0tek(text18, p1: false);
				}
				break;
			}
			case "dc_clonemultiplebaseforbindingdatasource":
			{
				string text12 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text12) && text12 != "1")
				{
					p0.z0eek(z0tek(text12, 0));
				}
				break;
			}
			case "dc_clonetype":
			{
				string text6 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text6) && text6 != "Default")
				{
					p0.CloneType = z0rek<TableRowCloneType>(text6);
				}
				break;
			}
			case "dc_contentreadonly":
			{
				string text27 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text27) && text27 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text27, ContentReadonlyState.Inherit);
				}
				break;
			}
			case "dc_contentreadonlyexpression":
			{
				string text24 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text24))
				{
					p0.ContentReadonlyExpression = text24;
				}
				break;
			}
			case "dc_deleteable":
			{
				string text19 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text19) && text19 != "true")
				{
					p0.Deleteable = z0tek(text19, p1: false);
				}
				break;
			}
			case "dc_enablepermission":
			{
				string text16 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text16) && text16 != "Inherit")
				{
					p0.EnablePermission = z0rek<DCBooleanValue>(text16);
				}
				break;
			}
			case "dc_enablevaluevalidate":
			{
				string text13 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text13))
				{
					p0.EnableValueValidate = z0tek(text13, p1: false);
				}
				break;
			}
			case "dc_expendfordatabinding":
			{
				string text10 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text10) && text10 != "true")
				{
					p0.ExpendForDataBinding = z0tek(text10, p1: false);
				}
				break;
			}
			case "dc_generatebyvaluebingding":
			{
				string text4 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text4) && text4 != "false")
				{
					p0.z0rek(z0tek(text4, p1: false));
				}
				break;
			}
			case "dc_headerstyle":
			{
				string text28 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text28) && text28 != "false")
				{
					p0.HeaderStyle = z0tek(text28, p1: false);
				}
				break;
			}
			case "id":
				z0yek(p0, z0ZzZzunk2.z0yek());
				break;
			case "ircr":
			{
				string text25 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text25) && text25 != "false")
				{
					p0.z0xek(z0tek(text25, p1: false));
				}
				break;
			}
			case "dc_limitedinputchars":
			{
				string text23 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text23))
				{
					p0.LimitedInputChars = text23;
				}
				break;
			}
			case "dc_newpage":
			{
				string text20 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text20) && text20 != "false")
				{
					p0.NewPage = z0tek(text20, p1: false);
				}
				break;
			}
			case "dc_printcellbackground":
			{
				string text17 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text17) && text17 != "true")
				{
					p0.PrintCellBackground = z0tek(text17, p1: false);
				}
				break;
			}
			case "dc_printcellborder":
			{
				string text15 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text15) && text15 != "true")
				{
					p0.PrintCellBorder = z0tek(text15, p1: false);
				}
				break;
			}
			case "dc_propertyexpressions":
			{
				string text14 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text14))
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text14);
				}
				break;
			}
			case "rmfhk":
			{
				string text11 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text11) && text11 != "None")
				{
					p0.z0yr(z0rek<MoveFocusHotKeys>(text11));
				}
				break;
			}
			case "dc_specifyheight":
			{
				string text9 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text9) && text9 != "0f")
				{
					p0.SpecifyHeight = z0pek(text9);
				}
				break;
			}
			case "dc_validatestyle":
			{
				string text7 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text7))
				{
					text7 = text7.Replace("'", "\"");
					p0.ValidateStyle = new ValueValidateStyle();
					((z0ZzZzcuk)p0.ValidateStyle).DCReadString(text7);
				}
				break;
			}
			case "dc_valuebinding":
			{
				string text5 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text5))
				{
					p0.ValueBinding = new z0ZzZzevj();
					((z0ZzZzcuk)p0.ValueBinding).DCReadString(text5);
				}
				break;
			}
			case "dc_visible":
			{
				string text2 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text2) && text2 != "true")
				{
					p0.Visible = z0tek(text2, p1: false);
				}
				break;
			}
			case "dc_visibleexpression":
			{
				string text = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text))
				{
					p0.VisibleExpression = text;
				}
				break;
			}
			case "height":
				p4 = z0ZzZzunk2.z0yek();
				break;
			case "dsh":
				p5 = z0ZzZzunk2.z0yek();
				break;
			case "title":
				p0.ToolTip = z0ZzZzunk2.z0yek();
				break;
			}
		}
		float height = z0tek(z0ZzZzevk2.z0yek("height"), p4, p5, xTextDocument, 0f);
		p0.Height = height;
		XTextElementList xTextElementList = p0.z0rek();
		xTextElementList.Capacity = p1.z0oqk().Count;
		foreach (z0ZzZzhbk item in p1.z0oqk().z0xrk())
		{
			if (item.z0cak() == "td")
			{
				XTextTableCellElement xTextTableCellElement = xTextTableElement.z0urk();
				xTextTableCellElement.z0yek(xTextDocument, p0);
				xTextElementList.z0hrk(xTextTableCellElement);
				z0tek(xTextTableCellElement, item, p2, p3, z0ZzZzevk2, p6, p7, p8);
			}
		}
	}

	private static void z0yek(XTextElement p0, string p1)
	{
		if (p1 != null && p1.Length > 0 && !p1.StartsWith(XTextElement.z0lok, StringComparison.Ordinal))
		{
			p0.ID = p1;
		}
	}

	private static DocumentContentStyle z0tek(DocumentContentStyle p0)
	{
		return new DocumentContentStyle
		{
			FontName = p0.FontName,
			FontSize = p0.FontSize,
			Color = p0.Color,
			FontStyle = p0.FontStyle
		};
	}

	private void z0tek(XTextTableElement p0)
	{
		XTextElementList xTextElementList = p0.z0stk();
		int num = 0;
		foreach (XTextTableRowElement item in xTextElementList.z0xrk())
		{
			int num2 = 0;
			foreach (XTextTableCellElement item2 in item.z0rek().z0xrk())
			{
				if (item2.RowSpan < 1)
				{
					item2.z0yek(1);
				}
				if (item2.ColSpan < 1)
				{
					item2.z0tek(1);
				}
				num2 += item2.ColSpan;
			}
			if (num < num2)
			{
				num = num2;
			}
		}
		XTextTableCellElement xTextTableCellElement2 = new XTextTableCellElement();
		XTextTableCellElement[,] array = new XTextTableCellElement[p0.z0stk().Count, num];
		int count = xTextElementList.Count;
		for (int i = 0; i < count; i++)
		{
			foreach (XTextTableCellElement item3 in ((XTextTableRowElement)xTextElementList[i]).z0rek().z0xrk())
			{
				int num3 = 0;
				for (int j = 0; j < num; j++)
				{
					if (array[i, j] == null)
					{
						num3 = j;
						break;
					}
				}
				if (item3.RowSpan == 1 && item3.ColSpan == 1)
				{
					array[i, num3] = item3;
					continue;
				}
				for (int k = 0; k < item3.ColSpan; k++)
				{
					for (int l = 0; l < item3.RowSpan; l++)
					{
						if (k == 0 && l == 0)
						{
							array[i + l, num3 + k] = item3;
							continue;
						}
						if (i + l >= count || num3 + k >= num)
						{
							break;
						}
						if (array[i + l, num3 + k] == null)
						{
							array[i + l, num3 + k] = xTextTableCellElement2;
						}
					}
				}
			}
		}
		for (int m = 0; m < count; m++)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList[m];
			xTextTableRowElement.z0rek().Clear();
			int z0buk = -1;
			for (int n = 0; n < num; n++)
			{
				if (array[m, n] == null || array[m, n] == xTextTableCellElement2)
				{
					XTextTableCellElement xTextTableCellElement4 = p0.z0urk();
					xTextTableCellElement4.z0buk = z0buk;
					xTextTableRowElement.z0rek().Add(xTextTableCellElement4);
				}
				else
				{
					z0buk = array[m, n].z0buk;
					xTextTableRowElement.z0rek().Add(array[m, n]);
				}
			}
		}
		XTextElementList xTextElementList2 = p0.z0srk();
		for (int num4 = xTextElementList2.Count; num4 < num; num4++)
		{
			XTextTableColumnElement xTextTableColumnElement = p0.z0vek();
			xTextTableColumnElement.Width = 0f;
			xTextElementList2.Add(xTextTableColumnElement);
		}
		if (xTextElementList2.Count != num)
		{
			for (int num5 = xTextElementList2.Count; num5 < num; num5++)
			{
				XTextTableColumnElement xTextTableColumnElement2 = p0.z0vek();
				xTextElementList2.Add(xTextTableColumnElement2);
				xTextTableColumnElement2.Width = 0f;
			}
		}
		int count2 = xTextElementList2.Count;
		for (int num6 = 0; num6 < count2; num6++)
		{
			XTextTableColumnElement xTextTableColumnElement3 = (XTextTableColumnElement)xTextElementList2[num6];
			foreach (XTextTableRowElement item4 in xTextElementList.z0xrk())
			{
				if (num6 < item4.z0rek().Count)
				{
					XTextElement xTextElement = item4.z0rek()[num6];
					if (xTextElement.z0fik > 0f && xTextTableColumnElement3.Width < xTextElement.z0fik)
					{
						xTextTableColumnElement3.Width = xTextElement.Width;
					}
				}
			}
		}
	}

	private static Color z0tek(string p0, Color p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		Color p2 = p1;
		if (z0tek(p0, out p2))
		{
			return p2;
		}
		return p1;
	}

	private void z0tek(XTextNewBarcodeElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		z0ZzZzhbk z0ZzZzhbk2 = p1.z0yek();
		bool flag = p1.z0yek().z0rek("attachedcomment") == "DocumentComment";
		foreach (z0ZzZzunk item in z0ZzZzhbk2.z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "dc_printvisibility":
			{
				string text21 = item.z0yek();
				if (text21 != null && text21.Length > 0)
				{
					p0.PrintVisibility = z0rek<ElementVisibility>(text21);
				}
				break;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(item);
				break;
			case "dc_barcodestyle2":
			{
				string text16 = item.z0yek();
				if (text16 != null && text16.Length > 0 && text16 != "Code128C")
				{
					p0.BarcodeStyle2 = z0rek<DCBarcodeStyle>(text16);
				}
				break;
			}
			case "dc_contentreadonly":
			{
				string text10 = item.z0yek();
				if (text10 != null && text10.Length > 0 && text10 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text10, ContentReadonlyState.Inherit);
				}
				break;
			}
			case "dc_deleteable":
			{
				string text12 = item.z0yek();
				if (text12 != null && text12.Length > 0 && text12 != "true")
				{
					p0.Deleteable = z0tek(text12, p1: false);
				}
				break;
			}
			case "dc_enabled":
			{
				string text19 = item.z0yek();
				if (text19 != null && text19.Length > 0 && text19 != "true")
				{
					p0.Enabled = z0tek(text19, p1: false);
				}
				break;
			}
			case "dc_height":
			{
				string text6 = item.z0yek();
				if (text6 != null && text6.Length > 0 && text6 != "125f")
				{
					p0.Height = z0pek(text6);
				}
				break;
			}
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "dc_linkinfo":
			{
				string text20 = item.z0yek();
				if (text20 != null && text20.Length > 0)
				{
					((XTextObjectElement)p0).z0eek(new z0ZzZzbuk());
					z0ZzZzmik.z0eek(p0.z0iek(), text20);
				}
				break;
			}
			case "dc_name":
			{
				string text15 = item.z0yek();
				if (text15 != null && text15.Length > 0)
				{
					p0.Name = text15;
				}
				break;
			}
			case "dc_propertyexpressions":
			{
				string text9 = item.z0yek();
				if (text9 != null && text9.Length > 0)
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text9);
				}
				break;
			}
			case "dc_showtext":
			{
				string text2 = item.z0yek();
				if (text2 != null && text2.Length > 0 && text2 != "true")
				{
					p0.ShowText = z0tek(text2, p1: false);
				}
				break;
			}
			case "dc_strictmatchpageindex":
			{
				string text17 = item.z0yek();
				if (text17 != null && text17.Length > 0 && text17 != "false")
				{
					p0.StrictMatchPageIndex = z0tek(text17, p1: false);
				}
				break;
			}
			case "dc_stringtag":
			{
				string text13 = item.z0yek();
				if (text13 != null && text13.Length > 0)
				{
					p0.StringTag = text13;
				}
				break;
			}
			case "dc_textalignment":
			{
				string text7 = item.z0yek();
				if (text7 != null && text7.Length > 0 && text7 != "Center")
				{
					p0.TextAlignment = z0rek<StringAlignment>(text7);
				}
				break;
			}
			case "dc_valuebinding":
			{
				string text4 = item.z0yek();
				if (text4 != null && text4.Length > 0)
				{
					p0.ValueBinding = new z0ZzZzevj();
					((z0ZzZzcuk)p0.ValueBinding).DCReadString(text4);
				}
				break;
			}
			case "dc_valueexpression":
			{
				string text22 = item.z0yek();
				if (text22 != null && text22.Length > 0)
				{
					p0.ValueExpression = text22;
				}
				break;
			}
			case "height":
			{
				string text18 = item.z0yek();
				if (text18 != null && text18.Length > 0)
				{
					float p3 = 0f / 0f;
					text18 = text18.Replace("px", string.Empty);
					if (float.TryParse(text18, out p3))
					{
						p0.Height = z0ZzZzrpk.z0eek(p3, GraphicsUnit.Pixel, GraphicsUnit.Document);
					}
				}
				break;
			}
			case "width":
			{
				string text14 = item.z0yek();
				if (text14 != null && text14.Length > 0)
				{
					float p2 = 0f / 0f;
					text14 = text14.Replace("px", string.Empty);
					if (float.TryParse(text14, out p2))
					{
						p0.Width = z0ZzZzrpk.z0eek(p2, GraphicsUnit.Pixel, GraphicsUnit.Document);
					}
				}
				break;
			}
			case "name":
			{
				string text11 = item.z0yek();
				if (text11 != null && text11.Length > 0)
				{
					p0.Name = text11;
				}
				break;
			}
			case "text":
			{
				string text8 = item.z0yek();
				if (text8 != null && text8.Length > 0)
				{
					p0.Text = text8;
				}
				break;
			}
			case "barcodestyle":
			{
				string text5 = item.z0yek();
				if (text5 != null && text5.Length > 0)
				{
					p0.BarcodeStyle2 = (DCBarcodeStyle)Enum.Parse(typeof(DCBarcodeStyle), text5);
				}
				break;
			}
			case "textalignment":
			{
				string text3 = item.z0yek();
				if (text3 != null && text3.Length > 0)
				{
					p0.TextAlignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), text3);
				}
				break;
			}
			case "showtext":
			{
				string text = item.z0yek();
				if (text != null && text.Length > 0)
				{
					p0.ShowText = z0tek(text, p1: false);
				}
				break;
			}
			}
		}
		z0tek(p1.z0yek(), p0);
		if (flag)
		{
			DocumentComment documentComment = new DocumentComment();
			documentComment.z0pek(z0ZzZzhbk2.z0eek("commenttext"));
			DateTime result = z0ZzZzkfh.z0wrk;
			if (DateTime.TryParse(z0ZzZzhbk2.z0eek("commentcreationtime"), out result))
			{
				documentComment.z0eek(result);
			}
			documentComment.z0eek(z0ZzZzhbk2.z0eek("commentauthor"));
			documentComment.z0rek(z0ZzZzhbk2.z0eek("commentauthorid"));
			documentComment.z0rek(z0tek(z0ZzZzhbk2.z0eek("combk"), Color.White));
			if (p0.z0jr().Comments == null)
			{
				p0.z0jr().Comments = new z0ZzZzwcj();
			}
			documentComment.z0lrk().z0eek("dccommentbackcolor", z0ZzZzhbk2.z0eek("combk"));
			documentComment.z0lrk().z0eek("dccommentbackcolor2", z0ZzZzhbk2.z0eek("combk2"));
			string text23 = z0ZzZzhbk2.z0eek("refcommentindex");
			int p4 = 0;
			if (int.TryParse(text23, out p4))
			{
				documentComment.z0eek(p4);
			}
			else
			{
				documentComment.z0eek(p0.z0jr().Comments.Count);
			}
			if (p0.z0jr().Comments.z0eek(documentComment.z0tek()) == null)
			{
				p0.z0jr().Comments.Add(documentComment);
			}
			p0.z0xrk().CommentIndex = documentComment.z0tek();
		}
	}

	private void z0tek(XTextButtonElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		foreach (z0ZzZzunk item in p1.z0yek().z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "dc_printvisibility":
			{
				string text11 = item.z0yek();
				if (text11 != null && text11.Length > 0)
				{
					p0.PrintVisibility = z0rek<ElementVisibility>(text11);
				}
				break;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(item);
				break;
			case "dc_commandname":
			{
				string text2 = item.z0yek();
				if (text2 != null && text2.Length > 0)
				{
					p0.CommandName = text2;
				}
				break;
			}
			case "dc_contentreadonly":
			{
				string text12 = item.z0yek();
				if (text12 != null && text12.Length > 0 && text12 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text12, ContentReadonlyState.Inherit);
				}
				break;
			}
			case "dc_deleteable":
			{
				string text18 = item.z0yek();
				if (text18 != null && text18.Length > 0 && text18 != "true")
				{
					p0.Deleteable = z0tek(text18, p1: false);
				}
				break;
			}
			case "dc_enabled":
			{
				string text4 = item.z0yek();
				if (text4 != null && text4.Length > 0 && text4 != "true")
				{
					p0.Enabled = z0tek(text4, p1: false);
				}
				break;
			}
			case "dc_height":
			{
				string text15 = item.z0yek();
				if (text15 != null && text15.Length > 0)
				{
					p0.Height = z0pek(text15);
				}
				break;
			}
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "dc_linkinfo":
			{
				string text9 = item.z0yek();
				if (text9 != null && text9.Length > 0)
				{
					p0.z0eek(new z0ZzZzbuk());
					z0ZzZzmik.z0eek(p0.z0iek(), text9);
				}
				break;
			}
			case "dc_name":
			{
				string text5 = item.z0yek();
				if (text5 != null && text5.Length > 0)
				{
					p0.Name = text5;
				}
				break;
			}
			case "dc_propertyexpressions":
			{
				string text16 = item.z0yek();
				if (text16 != null && text16.Length > 0)
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text16);
				}
				break;
			}
			case "dc_scripttextforclick":
			{
				string text13 = item.z0yek();
				if (text13 != null && text13.Length > 0)
				{
					p0.ScriptTextForClick = text13;
				}
				break;
			}
			case "dc_stringtag":
			{
				string text8 = item.z0yek();
				if (text8 != null && text8.Length > 0)
				{
					p0.StringTag = text8;
				}
				break;
			}
			case "dc_text":
			{
				string text7 = item.z0yek();
				if (text7 != null && text7.Length > 0)
				{
					p0.Text = text7;
				}
				break;
			}
			case "dc_valueexpression":
			{
				string text3 = item.z0yek();
				if (text3 != null && text3.Length > 0)
				{
					p0.ValueExpression = text3;
				}
				break;
			}
			case "dc_width":
			{
				string text17 = item.z0yek();
				if (text17 != null && text17.Length > 0)
				{
					p0.Width = z0pek(text17);
				}
				break;
			}
			case "value":
			{
				string text14 = item.z0yek();
				if (text14 != null && text14.Length > 0)
				{
					p0.Text = text14;
				}
				break;
			}
			case "dc_imgbase64":
			{
				string text10 = item.z0yek();
				if (text10 != null && text10.Length > 0)
				{
					if (p0.Image == null)
					{
						p0.Image = new z0ZzZzpmk();
					}
					p0.Image.ImageDataBase64String = text10;
				}
				break;
			}
			case "dc_imgbase64forover":
			{
				string text6 = item.z0yek();
				if (text6 != null && text6.Length > 0)
				{
					if (p0.ImageForMouseOver == null)
					{
						p0.ImageForMouseOver = new z0ZzZzpmk();
					}
					p0.ImageForMouseOver.ImageDataBase64String = text6;
				}
				break;
			}
			case "dc_imgbase64fordown":
			{
				string text = item.z0yek();
				if (text != null && text.Length > 0)
				{
					if (p0.ImageForDown == null)
					{
						p0.ImageForDown = new z0ZzZzpmk();
					}
					p0.ImageForDown.ImageDataBase64String = text;
				}
				break;
			}
			}
		}
		z0tek(p1.z0yek(), p0);
		p0.z0buk = z0tek(p1, p1.z0tek(), p0, p1.z0yek());
		if (!string.IsNullOrEmpty(p1.z0tek().z0eek()))
		{
			p0.Width = z0tek(p1.z0tek().z0eek(), p0.z0jr());
		}
		if (!string.IsNullOrEmpty(p1.z0tek().z0uek()))
		{
			p0.Height = z0tek(p1.z0tek().z0uek(), p0.z0jr());
		}
	}

	private static float z0uek(string p0, float p1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in p0)
		{
			if (!z0tek(c))
			{
				break;
			}
			stringBuilder.Append(c);
		}
		float result = 0f;
		if (float.TryParse(stringBuilder.ToString(), out result))
		{
			return result;
		}
		return p1;
	}

	public void z0tek(XTextDocumentContentElement p0, z0ZzZzajh p1)
	{
		p0.z0yek(p0: true);
		using (zzz.z0ZzZzkuk<z0ZzZzunk>.z0bpk z0bpk = p1.z0yek().z0oek().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0ZzZzunk current = z0bpk.Current;
				if (current.z0rek() == "dc_attributes")
				{
					p0.Attributes = z0tek(current);
				}
			}
		}
		z0tek((XTextContainerElement)p0, p1);
		z0jrk.z0gnk().z0yek();
	}

	private string z0nek(string p0)
	{
		if (!string.IsNullOrEmpty(p0))
		{
			if (p0 == "system-ui")
			{
				return "宋体";
			}
			string result = null;
			if (z0hrk.TryGetValue(p0, out result))
			{
				return result;
			}
			p0 = p0.Trim();
			if (p0 != null && p0.Contains(","))
			{
				string[] array = p0.Split(',');
				foreach (string text in array)
				{
					string text2 = text;
					if (text2.Length > 2)
					{
						if (text2[0] == '"' && text2[text2.Length - 1] == '"')
						{
							text2 = text.Substring(1, text2.Length - 2);
						}
						if (text2[0] == '\'' && text2[p0.Length - 1] == '\'')
						{
							text2 = text2.Substring(1, text2.Length - 2);
						}
						text2 = text2.Trim();
						if (text2 == "system-ui")
						{
							text2 = "宋体";
						}
					}
					if (Array.IndexOf(z0ZzZzimk.z0krk, text2) >= 0)
					{
						p0 = text2;
						break;
					}
				}
			}
			else if (p0.Length > 2)
			{
				if (p0[0] == '"' && p0[p0.Length - 1] == '"')
				{
					p0 = p0.Substring(1, p0.Length - 2);
				}
				if (p0[0] == '\'' && p0[p0.Length - 1] == '\'')
				{
					p0 = p0.Substring(1, p0.Length - 2);
				}
				p0 = p0.Trim();
			}
			if (p0.Length > 0)
			{
				if (p0 == "system-ui")
				{
					return "宋体";
				}
				return p0;
			}
			return null;
		}
		return null;
	}

	public void z0tek(XTextElement p0, z0ZzZzajh p1)
	{
		if (p0 is XTextDocumentContentElement)
		{
			((XTextDocumentContentElement)p0).z0yek(p0: true);
		}
		if (p0 is XTextInputFieldElement)
		{
			z0tek((XTextInputFieldElement)p0, p1);
		}
		else if (p0 is XTextPieElement)
		{
			z0tek((XTextPieElement)p0, p1);
		}
		else if (p0 is XTextChartElement)
		{
			z0tek((XTextChartElement)p0, p1);
		}
		else if (p0 is XTextCheckBoxElementBase)
		{
			z0tek((XTextCheckBoxElementBase)p0, p1);
		}
		else if (p0 is XTextButtonElement)
		{
			z0tek((XTextButtonElement)p0, p1);
		}
		else if (p0 is XTextLabelElement)
		{
			z0tek((XTextLabelElement)p0, p1);
		}
		else if (p0 is XTextImageElement)
		{
			z0tek((XTextImageElement)p0, p1);
		}
		else if (p0 is XTextTableElement)
		{
			z0tek((XTextTableElement)p0, p1);
		}
		else if (p0 is XTextControlHostElement)
		{
			z0tek((XTextControlHostElement)p0, p1);
		}
		else if (p0 is XTextSignImageElement)
		{
			z0tek((XTextSignImageElement)p0, p1);
		}
		else if (p0 is XTextSectionElement)
		{
			z0tek((XTextSectionElement)p0, p1);
		}
		else if (p0 is XTextBarcodeFieldElement)
		{
			z0tek((XTextBarcodeFieldElement)p0, p1);
		}
		else if (p0 is XTextMediaElement)
		{
			z0tek((XTextMediaElement)p0, p1);
		}
		else if (p0 is XTextNewMedicalExpressionElement)
		{
			z0tek((XTextNewMedicalExpressionElement)p0, p1);
		}
		else if (p0 is XTextMedicalExpressionFieldElement)
		{
			z0tek((XTextMedicalExpressionFieldElement)p0, p1);
		}
		else if (p0 is XTextNewBarcodeElement)
		{
			z0tek((XTextNewBarcodeElement)p0, p1);
		}
		else if (p0 is XTextTDBarcodeElement)
		{
			z0tek((XTextTDBarcodeElement)p0, p1);
		}
		else if (p0 is XTextPageInfoElement)
		{
			z0tek((XTextPageInfoElement)p0, p1);
		}
		else if (p0 is XTextContainerElement)
		{
			z0tek((XTextContainerElement)p0, p1);
		}
		else if (p0 is XTextHorizontalLineElement)
		{
			z0tek((XTextHorizontalLineElement)p0, p1);
		}
		else
		{
			z0tek(p1.z0yek(), p0);
		}
	}

	private static float z0tek(string p0, XTextDocument p1)
	{
		return (float)z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, 0.0);
	}

	private static bool z0tek(char p0)
	{
		if ((p0 < '0' || p0 > '9') && p0 != '.')
		{
			return p0 == '-';
		}
		return true;
	}

	private static bool z0tek(z0ZzZzhbk p0, XTextElement p1)
	{
		if (p1.ID == null || p1.ID.Length == 0)
		{
			string text = p0.z0uek();
			if (!string.IsNullOrEmpty(text) && !text.StartsWith(XTextElement.z0lok))
			{
				p1.ID = text;
				return true;
			}
		}
		return false;
	}

	public static int z0tek(string p0, int p1 = 0)
	{
		int num = 0;
		if (!string.IsNullOrEmpty(p0))
		{
			int length = p0.Length;
			for (int i = 0; i < length; i++)
			{
				char c = p0[i];
				if (c >= '0' && c <= '9')
				{
					num = num * 10 + c - 48;
					continue;
				}
				num = ((c != '-') ? p1 : (-num));
				break;
			}
			return num;
		}
		return p1;
	}

	private static string z0bek(string p0)
	{
		return p0?.Trim();
	}

	private void z0tek(XTextTableCellElement p0, z0ZzZzhbk p1, z0ZzZzajh p2, float p3, z0ZzZzevk p4, string p5, string p6, string p7)
	{
		XTextDocument xTextDocument = p0.z0jr();
		XTextTableRowElement xTextTableRowElement = p0.z0krk();
		string text = null;
		string p8 = null;
		string p9 = null;
		for (int num = p1.z0oek().Count - 1; num >= 0; num--)
		{
			z0ZzZzunk z0ZzZzunk2 = p1.z0oek()[num];
			switch (z0ZzZzunk2.z0rek())
			{
			case "style":
				p9 = z0ZzZzunk2.z0yek();
				break;
			case "class":
				p8 = z0ZzZzunk2.z0yek();
				break;
			case "dc_accepttab":
				p0.AcceptTab = z0tek(z0ZzZzunk2.z0yek(), p1: false);
				break;
			case "dc_attributes":
				p0.Attributes = z0tek(z0ZzZzunk2);
				break;
			case "dc_autofixfontsizemode":
				p0.AutoFixFontSizeMode = z0eek(z0ZzZzunk2.z0yek(), ContentAutoFixFontSizeMode.None);
				break;
			case "dc_bringouttosave":
				p0.z0st(z0tek(z0ZzZzunk2.z0yek(), p1: false));
				break;
			case "dc_canbereferenced":
				p0.z0jt(z0tek(z0ZzZzunk2.z0yek(), p1: false));
				break;
			case "dc_clonetype":
				p0.CloneType = z0eek(z0ZzZzunk2.z0yek(), TableRowCloneType.Default);
				break;
			case "dc_contentreadonly":
				p0.ContentReadonly = z0eek(z0ZzZzunk2.z0yek(), ContentReadonlyState.Inherit);
				break;
			case "dc_contentreadonlyexpression":
				p0.ContentReadonlyExpression = z0ZzZzunk2.z0yek();
				break;
			case "dc_copysource":
			{
				string text6 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text6))
				{
					p0.CopySource = new CopySourceInfo();
					p0.CopySource.DCReadString(text6);
				}
				break;
			}
			case "dc_deleteable":
				p0.Deleteable = z0tek(z0ZzZzunk2.z0yek(), p1: false);
				break;
			case "dc_enablepermission":
				p0.EnablePermission = z0eek(z0ZzZzunk2.z0yek(), DCBooleanValue.Inherit);
				break;
			case "dc_enablevaluevalidate":
				p0.EnableValueValidate = z0tek(z0ZzZzunk2.z0yek(), p1: false);
				break;
			case "id":
				z0yek(p0, z0ZzZzunk2.z0yek());
				break;
			case "ircr":
				p0.z0xek(z0tek(z0ZzZzunk2.z0yek(), p1: false));
				break;
			case "dc_limitedinputchars":
				p0.LimitedInputChars = z0ZzZzunk2.z0yek();
				break;
			case "dc_maxinputlength":
				p0.MaxInputLength = z0tek(z0ZzZzunk2.z0yek(), 0);
				break;
			case "dc_mirrorviewforcrosspage":
				p0.MirrorViewForCrossPage = z0tek(z0ZzZzunk2.z0yek(), p1: false);
				break;
			case "dc_movefocushotkey":
				p0.MoveFocusHotKey = z0eek(z0ZzZzunk2.z0yek(), MoveFocusHotKeys.Tab);
				break;
			case "dc_propertyexpressions":
			{
				string text5 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text5))
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					p0.PropertyExpressions.DCReadString(text5);
				}
				break;
			}
			case "rmfhk":
				p5 = z0ZzZzunk2.z0yek();
				break;
			case "dc_slantsplitlinestyle":
				p0.SlantSplitLineStyle = z0eek(z0ZzZzunk2.z0yek(), RectangleSlantSplitStyle.None);
				break;
			case "dc_specifyfixedlineheight":
				p0.SpecifyFixedLineHeight = z0yek(z0ZzZzunk2.z0yek(), 0f);
				break;
			case "dc_stressborder":
				p0.z0uek(z0tek(z0ZzZzunk2.z0yek(), p1: false));
				break;
			case "dc_tabstop":
				p0.z0tek(z0tek(z0ZzZzunk2.z0yek(), p1: false));
				break;
			case "dc_validatestyle":
			{
				string text4 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text4))
				{
					text4 = text4.Replace("'", "\"");
					p0.ValidateStyle = new ValueValidateStyle();
					p0.ValidateStyle.DCReadString(text4);
				}
				break;
			}
			case "dc_valuebinding":
			{
				string text3 = z0ZzZzunk2.z0yek();
				if (!string.IsNullOrEmpty(text3))
				{
					p0.ValueBinding = new z0ZzZzevj();
					p0.ValueBinding.DCReadString(text3);
				}
				break;
			}
			case "dc_visible":
				p0.Visible = z0tek(z0ZzZzunk2.z0yek(), p1: false);
				break;
			case "dc_visibleexpression":
				p0.VisibleExpression = z0ZzZzunk2.z0yek();
				break;
			case "bd2019":
				p7 = z0ZzZzunk2.z0yek();
				break;
			case "invisiblecolumn":
			{
				int num2 = p1.z0eek("cid")[0] - 65;
				if (!z0rrk.Contains(num2))
				{
					z0rrk.Add(num2);
				}
				break;
			}
			case "dspd":
				p6 = z0ZzZzunk2.z0yek();
				break;
			case "width":
				p0.Width = z0tek(z0ZzZzunk2.z0yek(), xTextDocument.z0spk());
				break;
			case "dc_rowspan":
				p0.z0yek(z0tek(z0ZzZzunk2.z0yek(), 1));
				break;
			case "colspan":
				p0.z0tek(z0tek(z0ZzZzunk2.z0yek(), 1));
				break;
			case "rowspan":
				p0.z0yek(z0tek(z0ZzZzunk2.z0yek(), 1));
				break;
			case "title":
				p0.ToolTip = z0ZzZzunk2.z0yek();
				break;
			case "dc_cellgridline":
			{
				string text2 = z0ZzZzunk2.z0yek();
				if (text2 != null && text2.Length > 0)
				{
					p0.GridLine = new z0ZzZzzej();
					p0.GridLine.DCReadString(text2);
				}
				break;
			}
			}
		}
		z0ZzZzevk z0ZzZzevk2 = z0tek(p9, p8);
		if (z0ZzZzevk2 != null && p4.z0tek_jiejie20260327142557())
		{
			z0ZzZzevk2.z0eek(p4, p1: false, z0ZzZzevk.z0nek, z0crk);
		}
		DocumentContentStyle documentContentStyle = z0yek(p2, z0ZzZzevk2, p0, p1);
		if (documentContentStyle == null)
		{
			documentContentStyle = new DocumentContentStyle();
		}
		if (p3 > 0f)
		{
			documentContentStyle.BorderLeft = true;
			documentContentStyle.BorderTop = true;
			documentContentStyle.BorderRight = true;
			documentContentStyle.BorderBottom = true;
			documentContentStyle.BorderWidth = 1f;
			documentContentStyle.BorderStyle = DashStyle.Solid;
			documentContentStyle.BorderColor = Color.Black;
		}
		if (documentContentStyle.z0zek >= 0f)
		{
			p0.Width = documentContentStyle.z0zek;
		}
		if (documentContentStyle.z0yrk >= 0f)
		{
			p0.Height = documentContentStyle.z0yrk;
		}
		z0tek(documentContentStyle, p7);
		switch (text)
		{
		case "middle":
			documentContentStyle.VerticalAlign = VerticalAlignStyle.Middle;
			break;
		case "top":
			documentContentStyle.VerticalAlign = VerticalAlignStyle.Top;
			break;
		case "bottom":
			documentContentStyle.VerticalAlign = VerticalAlignStyle.Bottom;
			break;
		}
		if (p6 != null && p6.Length > 0)
		{
			float[] array = null;
			if (!z0drk.TryGetValue(p6, out array))
			{
				string[] array2 = p6.Split('|');
				List<float> list = new List<float>();
				string[] array3 = array2;
				foreach (string obj in array3)
				{
					float num3 = 0f;
					if (float.TryParse(obj, out num3))
					{
						list.Add(num3);
					}
				}
				array = list.ToArray();
				z0drk.Add(p6, array);
			}
			int num4 = array.Length;
			if (num4 > 0 && z0tek(documentContentStyle.PaddingLeft, array[0], 5f))
			{
				documentContentStyle.PaddingLeft = array[0];
			}
			if (num4 > 1 && z0tek(documentContentStyle.PaddingLeft, array[1], 10f))
			{
				documentContentStyle.PaddingTop = array[1];
			}
			if (num4 > 2 && z0tek(documentContentStyle.PaddingLeft, array[2], 5f))
			{
				documentContentStyle.PaddingRight = array[2];
			}
			if (num4 > 3)
			{
				float num5 = array[3];
				if (xTextTableRowElement.SpecifyHeight == 0f)
				{
					if (z0tek(documentContentStyle.PaddingBottom, num5, 10f))
					{
						documentContentStyle.PaddingBottom = num5;
					}
				}
				else if (z0tek(documentContentStyle.PaddingBottom, num5, 20f))
				{
					documentContentStyle.PaddingBottom = num5;
				}
			}
		}
		p0.z0buk = xTextDocument.z0gnk().z0eek(documentContentStyle);
		z0ZzZzevk z0ZzZzevk3 = new z0ZzZzevk();
		z0ZzZzevk3.z0eek(z0ZzZzevk2, p1: false, z0ZzZzevk.z0nek, z0crk);
		z0tek(p0, new z0ZzZzajh(p2, p1, xTextDocument, z0ZzZzevk3));
	}

	private void z0tek(XTextMedicalExpressionFieldElement p0, z0ZzZzajh p1)
	{
		if (!string.IsNullOrEmpty(p0.z0eek))
		{
			string p2 = p0.z0eek;
			p0.z0eek = null;
			p0.z0zek(p2);
		}
		z0ZzZzxdh z0ZzZzxdh2 = z0tek(p1.z0yek(), p0.z0jr());
		if (z0ZzZzxdh2.z0rek() > 0f)
		{
			p0.Width = z0ZzZzxdh2.z0rek();
		}
		if (z0ZzZzxdh2.z0tek() > 0f)
		{
			p0.Height = z0ZzZzxdh2.z0tek();
		}
		if (p1.z0rek("dcfontsize"))
		{
			float fontSize = 9f;
			if (float.TryParse(p1.z0tek("dcfontsize"), out fontSize))
			{
				((XTextElement)p0).z0xrk().FontSize = fontSize;
			}
		}
	}

	static z0ZzZzjjh()
	{
		z0zek = false;
		z0ark = "rgb(";
		z0urk = new string[9] { "InputFieldInvalidateValue", "InputFieldReadonly", "InputFieldModified", "InputFieldNormal", "FieldFocusedBackColor", "FieldHoverBackColor", "DCNew0", "DCNew1", "DCNew2" };
		z0frk_jiejie20260327142557 = Color.Black.ToArgb();
		z0nrk = new Dictionary<string, object[]>();
		z0mrk = false;
		z0trk = false;
		z0qrk = false;
		z0krk = "data:image";
		z0ork = "base64,";
		z0rrk = null;
	}

	private z0ZzZzajh z0tek(z0ZzZzajh p0, z0ZzZzhbk p1)
	{
		z0ZzZzevk z0ZzZzevk2 = z0yek(p1);
		if (z0ZzZzevk2 == null)
		{
			return new z0ZzZzajh(p0, p1, z0jrk, p0.z0tek());
		}
		if (p0.z0tek() != null)
		{
			z0ZzZzevk2.z0eek(p0.z0tek(), p1: false, z0ZzZzevk.z0nek, z0crk);
		}
		return new z0ZzZzajh(p0, p1, z0jrk, z0ZzZzevk2);
	}

	private void z0tek(XTextLabelElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		foreach (z0ZzZzunk item in p1.z0yek().z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "dc_printvisibility":
			{
				string text18 = item.z0yek();
				if (text18 != null && text18.Length > 0)
				{
					p0.PrintVisibility = z0rek<ElementVisibility>(text18);
				}
				break;
			}
			case "dc_alignment":
			{
				string text19 = item.z0yek();
				if (text19 != null && text19.Length > 0 && text19 != "MiddleCenter")
				{
					p0.Alignment = z0rek<DCContentAlignment>(text19);
				}
				break;
			}
			case "dc_allowusereditcurrentpagelabeltext":
			{
				string text25 = item.z0yek();
				if (text25 != null && text25.Length > 0 && text25 != "false")
				{
					p0.AllowUserEditCurrentPageLabelText = z0tek(text25, p1: false);
				}
				break;
			}
			case "dc_attributenameforcontactaction":
			{
				string text5 = item.z0yek();
				if (text5 != null && text5.Length > 0)
				{
					p0.AttributeNameForContactAction = text5;
				}
				break;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(item);
				break;
			case "dc_autosize":
			{
				string text13 = item.z0yek();
				if (text13 != null && text13.Length > 0 && text13 != "true")
				{
					p0.AutoSize = z0tek(text13, p1: false);
				}
				break;
			}
			case "dc_contactaction":
			{
				string text21 = item.z0yek();
				if (text21 != null && text21.Length > 0 && text21 != "Disable")
				{
					p0.ContactAction = z0rek<LabelTextContactActionMode>(text21);
				}
				break;
			}
			case "dc_contentreadonly":
			{
				string text10 = item.z0yek();
				if (text10 != null && text10.Length > 0 && text10 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text10, ContentReadonlyState.Inherit);
				}
				break;
			}
			case "dc_deleteable":
			{
				string text24 = item.z0yek();
				if (text24 != null && text24.Length > 0 && text24 != "true")
				{
					p0.Deleteable = z0tek(text24, p1: false);
				}
				break;
			}
			case "dc_enabled":
			{
				string text14 = item.z0yek();
				if (text14 != null && text14.Length > 0 && text14 != "true")
				{
					p0.Enabled = z0tek(text14, p1: false);
				}
				break;
			}
			case "dc_height":
			{
				string text8 = item.z0yek();
				if (text8 != null && text8.Length > 0)
				{
					p0.Height = z0pek(text8);
				}
				break;
			}
			case "dc_width":
			{
				string text2 = item.z0yek();
				if (text2 != null && text2.Length > 0)
				{
					p0.Width = z0pek(text2);
				}
				break;
			}
			case "dc_text":
			{
				string text22 = item.z0yek();
				if (text22 != null && text22.Length > 0)
				{
					p0.Text = text22;
				}
				break;
			}
			case "dc_pagetexts":
			{
				string text15 = item.z0yek();
				if (text15 == null || text15.Length <= 0)
				{
					break;
				}
				p0.PageTexts = new PageLabelTextList();
				string[] array = text15.Split('|');
				foreach (string text16 in array)
				{
					if (text16 != null && text16.Length > 0)
					{
						string[] array2 = text16.Split(',');
						PageLabelText pageLabelText = new PageLabelText();
						pageLabelText.PageIndex = int.Parse(array2[0]);
						pageLabelText.Text = array2[1];
						p0.PageTexts.Add(pageLabelText);
					}
				}
				break;
			}
			case "dc_titlelevel":
			{
				string text11 = item.z0yek();
				if (text11 != null && text11.Length > 0)
				{
					p0.z0xrk().TitleLevel = int.Parse(text11);
				}
				break;
			}
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "dc_linkinfo":
			{
				string text7 = item.z0yek();
				if (text7 != null && text7.Length > 0)
				{
					((XTextObjectElement)p0).z0eek(new z0ZzZzbuk());
					z0ZzZzmik.z0eek(p0.z0iek(), text7);
				}
				break;
			}
			case "dc_linktextforcontactaction":
			{
				string text3 = item.z0yek();
				if (text3 != null && text3.Length > 0)
				{
					p0.LinkTextForContactAction = text3;
				}
				break;
			}
			case "dc_multiline":
			{
				string text23 = item.z0yek();
				if (text23 != null && text23.Length > 0 && text23 != "true")
				{
					p0.Multiline = z0tek(text23, p1: false);
				}
				break;
			}
			case "dc_name":
			{
				string text20 = item.z0yek();
				if (text20 != null && text20.Length > 0)
				{
					p0.Name = text20;
				}
				break;
			}
			case "dc_propertyexpressions":
			{
				string text17 = item.z0yek();
				if (text17 != null && text17.Length > 0)
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text17);
				}
				break;
			}
			case "dc_referencedtopicid":
			{
				string text12 = item.z0yek();
				if (text12 != null && text12.Length > 0 && text12 != "-1")
				{
					p0.z0eek(z0tek(text12, 0));
				}
				break;
			}
			case "dc_strictmatchpageindex":
			{
				string text9 = item.z0yek();
				if (text9 != null && text9.Length > 0 && text9 != "false")
				{
					p0.StrictMatchPageIndex = z0tek(text9, p1: false);
				}
				break;
			}
			case "dc_stringtag":
			{
				string text6 = item.z0yek();
				if (text6 != null && text6.Length > 0)
				{
					p0.StringTag = text6;
				}
				break;
			}
			case "dc_valuebinding":
			{
				string text4 = item.z0yek();
				if (text4 != null && text4.Length > 0)
				{
					p0.ValueBinding = new z0ZzZzevj();
					((z0ZzZzcuk)p0.ValueBinding).DCReadString(text4);
				}
				break;
			}
			case "dc_valueexpression":
			{
				string text = item.z0yek();
				if (text != null && text.Length > 0)
				{
					p0.ValueExpression = text;
				}
				break;
			}
			}
		}
		z0tek(p1.z0yek(), p0);
		z0ZzZzevk z0ZzZzevk2 = z0yek(p1.z0yek());
		if (z0ZzZzevk2 != null)
		{
			for (int num = z0ZzZzevk2.z0iek().Count - 1; num >= 0; num--)
			{
				z0ZzZzunk z0ZzZzunk2 = z0ZzZzevk2.z0iek()[num];
				z0tek(p1, p0.z0xrk(), z0ZzZzunk2.z0rek(), z0ZzZzunk2.z0yek(), p0);
			}
		}
		p0.z0buk = z0tek(p1, p1.z0tek(), p0, p1.z0yek());
	}

	private static void z0tek(XTextContainerElement p0, XTextElement p1)
	{
		if (p1.z0ruk != null)
		{
			((XTextElement)p0).z0xrk().FirstLineIndent = p1.z0ruk.z0pyk;
		}
	}

	private void z0tek(XTextNewMedicalExpressionElement p0, z0ZzZzajh p1)
	{
		z0ZzZzxdh z0ZzZzxdh2 = z0tek(p1.z0yek(), p0.z0jr());
		if (z0ZzZzxdh2.z0rek() > 0f)
		{
			p0.Width = z0ZzZzxdh2.z0rek();
		}
		if (z0ZzZzxdh2.z0tek() > 0f)
		{
			p0.Height = z0ZzZzxdh2.z0tek();
		}
		if (p1.z0rek("dcfontsize"))
		{
			float fontSize = 9f;
			if (float.TryParse(p1.z0tek("dcfontsize"), out fontSize))
			{
				p0.z0xrk().FontSize = fontSize;
			}
		}
		if (p1.z0rek("id"))
		{
			z0tek(p1.z0yek(), p0);
		}
		if (p1.z0rek("dc_expressionstyle"))
		{
			p0.ExpressionStyle = p1.z0eek<DCMedicalExpressionStyle>("dc_expressionstyle");
		}
		if (p1.z0rek("dc_innerserializetext"))
		{
			string text = p1.z0tek("dc_innerserializetext");
			p0.Values.DCReadString(text);
		}
		z0ZzZzhbk z0ZzZzhbk2 = p1.z0yek();
		if (z0ZzZzhbk2.z0rek("attachedcomment") == "DocumentComment")
		{
			DocumentComment documentComment = new DocumentComment();
			documentComment.z0pek(z0ZzZzhbk2.z0eek("commenttext"));
			DateTime result = z0ZzZzkfh.z0wrk;
			if (DateTime.TryParse(z0ZzZzhbk2.z0eek("commentcreationtime"), out result))
			{
				documentComment.z0eek(result);
			}
			documentComment.z0eek(z0ZzZzhbk2.z0eek("commentauthor"));
			documentComment.z0rek(z0ZzZzhbk2.z0eek("commentauthorid"));
			documentComment.z0rek(z0tek(z0ZzZzhbk2.z0eek("combk"), Color.White));
			if (p0.z0jr().Comments == null)
			{
				p0.z0jr().Comments = new z0ZzZzwcj();
			}
			documentComment.z0lrk().z0eek("dccommentbackcolor", z0ZzZzhbk2.z0eek("combk"));
			documentComment.z0lrk().z0eek("dccommentbackcolor2", z0ZzZzhbk2.z0eek("combk2"));
			string text2 = z0ZzZzhbk2.z0eek("refcommentindex");
			int p2 = 0;
			if (int.TryParse(text2, out p2))
			{
				documentComment.z0eek(p2);
			}
			else
			{
				documentComment.z0eek(p0.z0jr().Comments.Count);
			}
			if (p0.z0jr().Comments.z0eek(documentComment.z0tek()) == null)
			{
				p0.z0jr().Comments.Add(documentComment);
			}
			p0.z0xrk().CommentIndex = documentComment.z0tek();
		}
	}

	internal static string z0iek(z0ZzZzhbk p0)
	{
		string text = p0.z0eek("dc_newvalue");
		text = ((!string.IsNullOrEmpty(text)) ? z0ZzZztwh.z0rek(text) : ((p0.z0cak() == "input") ? p0.z0hqk() : p0.z0jqk()));
		return z0uek(text);
	}

	private static bool z0tek(float p0, float p1, float p2)
	{
		if (p0 == p1)
		{
			return false;
		}
		return Math.Abs(p0 - p1) < p2;
	}

	private static bool z0tek(string p0, out DashStyle p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			p1 = DashStyle.Custom;
			return false;
		}
		p0 = p0.Trim();
		if (string.Equals(p0, "solid", StringComparison.CurrentCultureIgnoreCase))
		{
			p1 = DashStyle.Solid;
			return true;
		}
		if (string.Equals(p0, "dashed", StringComparison.CurrentCultureIgnoreCase))
		{
			p1 = DashStyle.Dash;
			return true;
		}
		if (string.Equals(p0, "dotted", StringComparison.CurrentCultureIgnoreCase))
		{
			p1 = DashStyle.Dot;
			return true;
		}
		if (string.Equals(p0, "none", StringComparison.CurrentCultureIgnoreCase))
		{
			p1 = DashStyle.Custom;
			return true;
		}
		p1 = DashStyle.Custom;
		return false;
	}

	private void z0tek(XTextSectionElement p0, z0ZzZzajh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p1 == null || p1.z0yek() == null)
		{
			throw new ArgumentNullException("args");
		}
		foreach (z0ZzZzunk item in p1.z0yek().z0oek().z0xrk())
		{
			switch (item.z0rek())
			{
			case "dc_printvisibility":
			{
				string text22 = item.z0yek();
				if (text22 != null && text22.Length > 0)
				{
					p0.PrintVisibility = z0rek<ElementVisibility>(text22);
				}
				break;
			}
			case "dc_newpage":
			{
				string text30 = item.z0yek();
				if (text30 != null && text30.Length > 0 && text30 != "false")
				{
					p0.NewPage = z0tek(text30, p1: true);
				}
				break;
			}
			case "dc_insertemptypagefornewpage":
			{
				string text16 = item.z0yek();
				if (text16 != null && text16.Length > 0 && text16 != "false")
				{
					p0.InsertEmptyPageForNewPage = z0tek(text16, p1: true);
				}
				break;
			}
			case "dc_accepttab":
			{
				string text6 = item.z0yek();
				if (text6 != null && text6.Length > 0 && text6 != "true")
				{
					p0.AcceptTab = z0tek(text6, p1: false);
				}
				break;
			}
			case "dc_attributes":
				p0.Attributes = z0tek(item);
				break;
			case "dc_bringouttosave":
			{
				string text15 = item.z0yek();
				if (text15 != null && text15.Length > 0 && text15 != "false")
				{
					p0.z0st(z0tek(text15, p1: false));
				}
				break;
			}
			case "dc_canbereferenced":
			{
				string text23 = item.z0yek();
				if (text23 != null && text23.Length > 0 && text23 != "false")
				{
					p0.z0jt(z0tek(text23, p1: false));
				}
				break;
			}
			case "dc_compressownerlinespacing":
			{
				string text7 = item.z0yek();
				if (text7 != null && text7.Length > 0 && text7 != "false")
				{
					p0.CompressOwnerLineSpacing = z0tek(text7, p1: false);
				}
				break;
			}
			case "dc_contentreadonly":
			{
				string text27 = item.z0yek();
				if (text27 != null && text27.Length > 0 && text27 != "Inherit")
				{
					p0.ContentReadonly = z0eek(text27, ContentReadonlyState.Inherit);
				}
				break;
			}
			case "dc_contentreadonlyexpression":
			{
				string text20 = item.z0yek();
				if (text20 != null && text20.Length > 0)
				{
					p0.ContentReadonlyExpression = text20;
				}
				break;
			}
			case "dc_titlelevel":
			{
				string text12 = item.z0yek();
				if (text12 != null && text12.Length > 0)
				{
					((XTextElement)p0).z0xrk().TitleLevel = int.Parse(text12);
				}
				break;
			}
			case "dc_copysource":
			{
				string text2 = item.z0yek();
				if (text2 != null && text2.Length > 0)
				{
					p0.CopySource = new CopySourceInfo();
					((z0ZzZzcuk)p0.CopySource).DCReadString(text2);
				}
				break;
			}
			case "dc_deleteable":
			{
				string text26 = item.z0yek();
				if (text26 != null && text26.Length > 0 && text26 != "true")
				{
					p0.Deleteable = z0tek(text26, p1: false);
				}
				break;
			}
			case "dc_enablecollapse":
			{
				string text18 = item.z0yek();
				if (text18 != null && text18.Length > 0 && text18 != "false")
				{
					p0.EnableCollapse = z0tek(text18, p1: false);
				}
				break;
			}
			case "dc_enablepermission":
			{
				string text10 = item.z0yek();
				if (text10 != null && text10.Length > 0 && text10 != "Inherit")
				{
					p0.EnablePermission = z0rek<DCBooleanValue>(text10);
				}
				break;
			}
			case "dc_enablevaluevalidate":
			{
				string text5 = item.z0yek();
				if (text5 != null && text5.Length > 0)
				{
					p0.EnableValueValidate = z0tek(text5, p1: false);
				}
				break;
			}
			case "dc_expendfordatabinding":
			{
				string text29 = item.z0yek();
				if (text29 != null && text29.Length > 0 && text29 != "true")
				{
					p0.ExpendForDataBinding = z0tek(text29, p1: false);
				}
				break;
			}
			case "dc_forecolorvalueforcollapsed":
			{
				string text25 = item.z0yek();
				if (text25 != null && text25.Length > 0)
				{
					p0.ForeColorValueForCollapsed = text25;
				}
				break;
			}
			case "id":
				z0yek(p0, item.z0yek());
				break;
			case "ircr":
			{
				string text19 = item.z0yek();
				if (text19 != null && text19.Length > 0 && text19 != "false")
				{
					((XTextContainerElement)p0).z0xek(z0tek(text19, p1: false));
				}
				break;
			}
			case "dc_iscollapsed":
			{
				string text13 = item.z0yek();
				if (text13 != null && text13.Length > 0 && text13 != "false")
				{
					p0.IsCollapsed = z0tek(text13, p1: false);
				}
				break;
			}
			case "dc_limitedinputchars":
			{
				string text9 = item.z0yek();
				if (text9 != null && text9.Length > 0)
				{
					p0.LimitedInputChars = text9;
				}
				break;
			}
			case "dc_maxinputlength":
			{
				string text3 = item.z0yek();
				if (text3 != null && text3.Length > 0 && text3 != "0")
				{
					p0.MaxInputLength = z0tek(text3, 0);
				}
				break;
			}
			case "dc_name":
			{
				string text31 = item.z0yek();
				if (text31 != null && text31.Length > 0)
				{
					p0.Name = text31;
				}
				break;
			}
			case "dc_propertyexpressions":
			{
				string text28 = item.z0yek();
				if (text28 != null && text28.Length > 0)
				{
					p0.PropertyExpressions = new PropertyExpressionInfoList();
					((z0ZzZzcuk)p0.PropertyExpressions).DCReadString(text28);
				}
				break;
			}
			case "rmfhk":
			{
				string text24 = item.z0yek();
				if (text24 != null && text24.Length > 0 && text24 != "None")
				{
					p0.z0yr(z0rek<MoveFocusHotKeys>(text24));
				}
				break;
			}
			case "dc_specifyfixedlineheight":
			{
				string text21 = item.z0yek();
				if (text21 != null && text21.Length > 0 && text21 != "0f")
				{
					p0.SpecifyFixedLineHeight = z0pek(text21);
				}
				break;
			}
			case "dc_specifyheight":
			{
				string text17 = item.z0yek();
				if (text17 != null && text17.Length > 0 && text17 != "0f")
				{
					p0.SpecifyHeight = z0pek(text17);
				}
				break;
			}
			case "dc_title":
			{
				string text14 = item.z0yek();
				if (text14 != null && text14.Length > 0)
				{
					p0.Title = text14;
				}
				break;
			}
			case "dc_validatestyle":
			{
				string text11 = item.z0yek();
				if (text11 != null && text11.Length > 0)
				{
					text11 = text11.Replace("'", "\"");
					p0.ValidateStyle = new ValueValidateStyle();
					((z0ZzZzcuk)p0.ValidateStyle).DCReadString(text11);
				}
				break;
			}
			case "dc_valuebinding":
			{
				string text8 = item.z0yek();
				if (text8 != null && text8.Length > 0)
				{
					p0.ValueBinding = new z0ZzZzevj();
					((z0ZzZzcuk)p0.ValueBinding).DCReadString(text8);
				}
				break;
			}
			case "dc_visible":
			{
				string text4 = item.z0yek();
				if (text4 != null && text4.Length > 0 && text4 != "true")
				{
					p0.Visible = z0tek(text4, p1: false);
				}
				break;
			}
			case "dc_visibleexpression":
			{
				string text = item.z0yek();
				if (text != null && text.Length > 0)
				{
					p0.VisibleExpression = text;
				}
				break;
			}
			}
		}
		p0.z0buk = z0tek(p1, p1.z0tek(), p0, p1.z0yek());
		z0tek((XTextContainerElement)p0, p1);
	}

	private static Color[] z0vek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		p0 = p0.Trim();
		List<Color> list = new List<Color>();
		while (p0.Length > 0)
		{
			p0 = p0.Trim();
			if (p0.StartsWith(z0ark, StringComparison.CurrentCultureIgnoreCase))
			{
				int num = p0.IndexOf(')', 4);
				if (num > 0)
				{
					string p1 = p0.Substring(0, num + 1);
					Color p2 = Color.Black;
					if (z0tek(p1, out p2))
					{
						list.Add(p2);
					}
					p0 = p0.Substring(num + 1, p0.Length - num - 1).Trim();
					continue;
				}
			}
			string text = string.Empty;
			while (p0.Length > 0 && !char.IsWhiteSpace(p0[0]))
			{
				text += p0[0];
				p0 = p0.Substring(1, p0.Length - 1);
			}
			Color p3 = Color.Black;
			if (z0tek(text, out p3))
			{
				list.Add(p3);
			}
		}
		return list.ToArray();
	}

	public z0ZzZzjjh(XTextDocument p0, z0ZzZzkbk p1, z0ZzZzgbj p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("doc");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("htmlDoc");
		}
		z0jrk = p0;
		z0erk = p1;
		z0grk = p2;
	}

	private void z0tek(z0ZzZzmvk p0, z0ZzZzajh p1, XTextContainerElement p2, XTextElementList p3)
	{
		string text = p0.z0zak();
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		if (text[0] == '\u200c')
		{
			if (text.Length <= 1)
			{
				return;
			}
			text = text.Substring(1);
		}
		if (text[0] == '\n' || (text.Length >= 2 && text[0] == '\r' && text[1] == '\n'))
		{
			bool flag = true;
			int num = 0;
			string text2 = text;
			foreach (char c in text2)
			{
				if (!z0ZzZzqik.z0uek(c))
				{
					flag = false;
					break;
				}
				if (c == '\n')
				{
					num++;
				}
			}
			if (flag && num == 1)
			{
				return;
			}
		}
		text = z0ZzZztwh.z0rek(text);
		StringBuilder stringBuilder = new StringBuilder();
		bool flag2 = false;
		int length = text.Length;
		for (int j = 0; j < length; j++)
		{
			char c2 = text[j];
			switch (c2)
			{
			case '\t':
			case '\n':
			case '\r':
			case ' ':
				if (!flag2)
				{
					stringBuilder.Append(' ');
				}
				flag2 = true;
				break;
			case '\u2002':
				flag2 = false;
				stringBuilder.Append(c2);
				break;
			default:
				flag2 = false;
				stringBuilder.Append(c2);
				break;
			}
		}
		text = stringBuilder.ToString();
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		DocumentContentStyle documentContentStyle = z0yek(p1, p1.z0tek(), null, p0);
		if (p2 is XTextInputFieldElement)
		{
			((z0ZzZzcok)documentContentStyle).z0tek();
		}
		string p4 = null;
		if (p1.z0yek().z0tek("dc_charactercircle"))
		{
			string text3 = p1.z0yek().z0rek("dc_charactercircle");
			if (text3 == "Rectangle")
			{
				documentContentStyle.CharacterCircle = CharacterCircleStyles.Rectangle;
			}
			else if (text3 == "Circle")
			{
				documentContentStyle.CharacterCircle = CharacterCircleStyles.Circle;
			}
		}
		if (p1.z0oek() == "sup" || z0trk)
		{
			documentContentStyle.Superscript = true;
		}
		else if (p1.z0oek() == "sub" || z0qrk)
		{
			documentContentStyle.Subscript = true;
		}
		if (p1.z0rek("dc_titlelevel", out p4) && !string.IsNullOrEmpty(p4))
		{
			documentContentStyle.TitleLevel = int.Parse(p4);
		}
		if (p1.z0rek("bd2019", out p4) && !p1.z0rek("dctype"))
		{
			z0tek(documentContentStyle, p4);
		}
		bool flag3 = p1.z0tek() != null && p1.z0tek().z0rek("font-family");
		int styleIndex = z0jrk.z0gnk().z0eek(documentContentStyle);
		int num2 = -2147483648;
		int length2 = text.Length;
		for (int k = 0; k < length2; k++)
		{
			char c3 = text[k];
			if (c3 == '\u00a0' && !flag3)
			{
				if (num2 == -2147483648)
				{
					DocumentContentStyle documentContentStyle2 = (DocumentContentStyle)documentContentStyle.Clone();
					documentContentStyle2.FontName = "Arial";
					num2 = z0jrk.z0gnk().z0eek(documentContentStyle2);
				}
				p3.z0hrk(new XTextCharElement(c3, p2, z0jrk, num2));
			}
			XTextCharElement xTextCharElement = new XTextCharElement(c3, p2, z0jrk, styleIndex);
			if (c3 == '\u2002')
			{
				if (z0jrk.z0wvk == null)
				{
					z0jrk.z0wvk = new List<XTextCharElement>();
				}
				z0jrk.z0wvk.Add(xTextCharElement);
			}
			p3.z0hrk(xTextCharElement);
			if (XTextCharElement.z0tek((int)c3) && k < length2 - 1)
			{
				xTextCharElement.z0rek((ushort)text[++k]);
			}
		}
	}
}
