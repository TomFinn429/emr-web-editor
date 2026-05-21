using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Medical;
using DCSoft.Writer.MedicalExpression;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal class z0ZzZzrjh : z0ZzZzfjh, z0ZzZzzhh
{
	private class z0wpk
	{
		public int z0rek;

		public float z0tek;

		public int z0yek;

		public int z0uek;

		public float z0iek;

		public int z0oek;

		public float z0pek;

		public float z0mek;

		public int z0nek;

		public int z0bek;

		public float z0vek;

		public float z0cek;

		public int z0eek(z0ZzZzrjh p0, float p1, bool p2, int p3, int p4, bool p5)
		{
			z0oek++;
			z0vek += p1;
			if (p0.z0tek() != z0bek)
			{
				z0mek = z0yek;
				z0bek = p0.z0tek();
				z0nek = z0yek;
			}
			z0mek += p0.z0tek(p1);
			z0yek = p0.z0uek(p1);
			z0nek += z0yek;
			if (z0mek < (float)z0nek)
			{
				z0yek--;
				z0nek--;
			}
			else if (z0mek > (float)z0nek)
			{
				z0yek++;
				z0nek++;
			}
			if (p2)
			{
				z0yek -= p3;
			}
			if (p0.z0trk() != (z0ZzZzjok)6)
			{
				z0yek -= p4;
			}
			z0rek = p3;
			z0uek = p4;
			z0iek = p1;
			if (z0yek < 0)
			{
				z0yek = 0;
			}
			return z0yek;
		}
	}

	private class z0pok
	{
		public RectangleSlantSplitStyle z0rek;

		public bool z0tek = true;

		public bool z0yek;

		public int z0uek;

		public bool z0iek = true;

		public string z0oek;

		public bool z0pek;

		public bool z0mek = true;

		public bool z0nek = true;

		public int z0bek = -1;

		public float z0vek;

		public bool z0cek;

		public bool z0xek;

		public bool z0zek = true;

		public bool z0lrk = true;

		public bool z0krk = true;

		public bool z0eek(z0pok p0)
		{
			if (z0xek != p0.z0xek || z0pek != p0.z0pek)
			{
				return false;
			}
			if (z0bek != p0.z0bek)
			{
				return false;
			}
			if (z0yek != p0.z0yek)
			{
				return false;
			}
			if (z0vek != p0.z0vek)
			{
				return false;
			}
			if (z0krk != p0.z0krk)
			{
				return false;
			}
			if (z0krk)
			{
				if (z0cek != p0.z0cek)
				{
					return false;
				}
				if (!z0cek && (z0tek != p0.z0tek || z0iek != p0.z0iek || z0zek != p0.z0zek || z0mek != p0.z0mek))
				{
					return false;
				}
			}
			if (z0rek != p0.z0rek)
			{
				return false;
			}
			return true;
		}
	}

	private class z0tgj
	{
		public float z0eek;

		public List<z0pok> z0rek;

		public float z0tek;

		public float z0yek;

		public float z0uek;
	}

	[CompilerGenerated]
	private sealed class z0fuk
	{
		public XTextTableCellElement z0rek;

		public z0ZzZzrjh z0tek;

		internal void z0eek()
		{
			z0tek.z0rek(z0rek);
		}
	}

	private new Dictionary<string, string> z0lrk = new Dictionary<string, string>();

	[NonSerialized]
	private new z0ZzZzwrj z0krk;

	private new z0ZzZzndh z0jrk = z0ZzZzndh.z0cek;

	private new z0ZzZzgbj z0hrk;

	private new int z0grk;

	private new bool z0frk;

	internal new List<string> z0drk;

	private new XTextDocument z0srk;

	private int z0ark;

	private new List<XTextElement> z0qrk = new List<XTextElement>();

	private new static readonly XTextElementList z0wrk;

	private new DocumentViewOptions z0erk;

	private new bool z0rrk;

	private new Dictionary<float, string> z0trk = new Dictionary<float, string>();

	internal new JsonArray z0yrk;

	private static readonly string z0urk;

	private new bool z0irk;

	private readonly char[] z0ork = "|0000|".ToCharArray();

	private static readonly int z0prk;

	private Dictionary<XTextContentElement, z0wpk> z0mrk = new Dictionary<XTextContentElement, z0wpk>();

	private static Color z0nrk;

	protected bool z0brk;

	private bool z0vrk;

	private z0ZzZzbdh z0crk = z0ZzZzbdh.z0xek;

	private bool z0xrk;

	private int z0zrk;

	private int z0ltk;

	private int z0ktk;

	private z0ZzZzclh z0jtk = new z0ZzZzclh();

	public z0ZzZzgbj Options
	{
		get
		{
			z0ZzZzgbj z0ZzZzgbj2 = z0hrk;
			if (z0ZzZzgbj2 == null)
			{
				z0ZzZzgbj2 = (z0hrk = new z0ZzZzgbj());
			}
			return z0ZzZzgbj2;
		}
		set
		{
			z0hrk = value;
		}
	}

	private bool z0rek(z0ZzZzonj p0)
	{
		if (p0 != null)
		{
			string text = p0.z0yek();
			if (text != null && text.Length > 0)
			{
				if (p0.z0tek() != null && p0.z0tek().Length > 0)
				{
					text = p0.z0tek() + Environment.NewLine + text;
				}
				z0uek("title", text);
				return true;
			}
		}
		return false;
	}

	private void z0rek(z0ZzZzqjh p0)
	{
		z0cek("span");
		base.z0oek();
		z0yek("display", "none");
		((z0ZzZzfjh)this).z0zek();
		((z0ZzZzfjh)this).z0xek();
	}

	public override void z0hw()
	{
		z0nek();
		base.z0hw();
		z0irk = Options.ForPrint && Options.TidyHtmlForPrint;
		z0xrk = Options.ForPrint && Options.DocumentOptions != null && Options.DocumentOptions.ViewOptions.BothBlackWhenPrint;
		z0vrk = Options.ForPrint;
	}

	private bool z0rek(XTextElement p0, XTextDocument p1)
	{
		DocumentSecurityOptions documentSecurityOptions = p1.z0hi();
		if (Options.LogUserEditTrack)
		{
			if (!documentSecurityOptions.ShowNewContentMarkForFirstHistory && p0.z0aek().z0nrk <= 0 && p0.z0aek().z0jyk < 0)
			{
				return false;
			}
			int num = p0.z0gtk();
			if (num >= 0 && documentSecurityOptions.ShowPermissionMark)
			{
				if (num > 2)
				{
					num = 2;
				}
				if (z0drk())
				{
					z0nek(z0ZzZzejh.z0hrk + num);
				}
				else
				{
					z0lrk(z0ZzZzejh.z0hrk + num);
				}
				return true;
			}
			num = p0.z0ntk();
			if (num >= 0 && documentSecurityOptions.ShowPermissionMark)
			{
				if (z0drk())
				{
					z0nek(z0ZzZzejh.z0cek + num);
				}
				else
				{
					z0lrk(z0ZzZzejh.z0cek + num);
				}
				return true;
			}
		}
		return false;
	}

	private bool z0rek(XTextSignImageElement p0)
	{
		if (p0.ImageData == null || p0.ImageData.Length < 100)
		{
			return false;
		}
		if (p0.z0yek() == null)
		{
			return false;
		}
		DocumentSecurityOptions documentSecurityOptions = p0.z0hi();
		bool flag = documentSecurityOptions.CAMode == DCCAMode.Disabled;
		if (p0.SignState == DCSignValidateState.NotDetect && !flag)
		{
			return false;
		}
		if (p0.SignState == DCSignValidateState.ValidateBySoftOnly && documentSecurityOptions.ShowFlagForOnlySoftwareSign)
		{
			return false;
		}
		if (p0.SignState == DCSignValidateState.Invalidate || p0.SignState == DCSignValidateState.NotDetect || flag)
		{
			return false;
		}
		return true;
	}

	private void z0rek(XTextTDBarcodeElement p0)
	{
		if (z0irk)
		{
			z0eek(p0, null);
			return;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["text"] = p0.Text;
		z0eek(p0, dictionary);
	}

	public void z0rek(XTextDocument p0)
	{
		z0srk = p0;
		z0nek();
	}

	private void z0rek(XTextParagraphElement p0)
	{
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		if (p0.z0eek())
		{
			if (p0.z0be().Count > 1)
			{
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0eek(z0mek()).z0be().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						z0uek(current);
					}
					return;
				}
			}
			z0oek(" ");
			return;
		}
		if (z0ZzZzrzj2.z0brk != ParagraphListStyle.None)
		{
			z0cek("p");
		}
		else
		{
			z0cek("li");
			z0uek("id", "dc" + z0ZzZzrzj2.z0brk);
		}
		z0rek(p0.z0aek(), p0);
		if (z0ZzZzrzj2.z0kuk)
		{
			z0yek("list-style-type", "none");
		}
		z0yek("text-justify", "inter-ideograph");
		z0yek("margin-bottom", p0.z0jr().z0grk((int)z0ZzZzrzj2.z0irk) + " px");
		if (z0ZzZzrzj2.z0brk != ParagraphListStyle.None && z0ZzZzrzj2.z0pyk != 0f)
		{
			z0yek("margin-left", p0.z0jr().z0grk((int)z0ZzZzrzj2.z0pyk) + " px");
		}
		if (z0ZzZzrzj2.z0pek != null)
		{
			z0yek(z0ZzZzrzj2.z0pek, null);
		}
		((z0ZzZzfjh)this).z0zek();
		if (p0.z0be().Count > 1)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0eek(z0mek()).z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current2 = z0bpk.Current;
				z0uek(current2);
			}
		}
		else
		{
			z0oek(" ");
		}
		z0yrk();
	}

	public void z0rek(int p0)
	{
		z0ark = p0;
	}

	public z0ZzZzwrj z0rek()
	{
		return z0krk;
	}

	public void z0rek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("t");
		}
		if (!p0.IsSubclassOf(typeof(XTextElement)) && !p0.Equals(typeof(DocumentComment)))
		{
			throw new ArgumentException(p0.FullName + " <> XTextElement");
		}
		z0uek("dctype", p0.Name);
	}

	public int z0rek(float p0)
	{
		if (p0 <= 0f)
		{
			return 0;
		}
		if (p0 == 1f)
		{
			return 1;
		}
		int num = (int)Math.Round(z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, GraphicsUnit.Pixel));
		if (num < 1)
		{
			num = 1;
		}
		return num;
	}

	private void z0rek(XTextControlHostElement p0)
	{
		if (Options.ForPrint)
		{
			z0cek("table");
			base.z0oek();
			z0yek("width", z0uek(p0.Width) + "px");
			z0yek("height", z0uek(p0.Height) + "px");
			z0yek("border", "1px solid black");
			z0yek("background-color", "#dddddd");
			((z0ZzZzfjh)this).z0zek();
			z0cek("tr");
			z0cek("td");
			z0uek("align", "center");
			z0uek("valign", "middle");
			z0yek(p0.TypeFullName);
			((z0ZzZzfjh)this).z0xek();
			((z0ZzZzfjh)this).z0xek();
			((z0ZzZzfjh)this).z0xek();
		}
	}

	public override void z0jw(bool p0)
	{
	}

	public void z0rek(z0ZzZzrzj p0, XTextElement p1, bool p2 = true)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("style");
		}
		bool flag = Options.ForPrint && p1.z0jr().z0vtk().ViewOptions.BothBlackWhenPrint;
		if (p2)
		{
			if (p0.z0hrk && p0.z0erk > 0f)
			{
				z0yek(p0.z0rrk, p0.z0wyk, p0.z0etk, p0.z0mrk, p0.z0nek, Math.Max(1, p1.z0jr().z0grk((int)p0.z0erk)), p0.z0guk, flag);
			}
			else
			{
				if (p0.z0rrk && p0.z0nek.A != 0)
				{
					z0yek("left", p0.z0nek, z0uek(p0.z0erk), p0.z0guk, flag);
				}
				if (p0.z0wyk && p0.z0myk.A != 0)
				{
					z0yek("top", p0.z0myk, z0uek(p0.z0erk), p0.z0guk, flag);
				}
				if (p0.z0etk && p0.z0grk.A != 0)
				{
					z0yek("right", p0.z0grk, z0uek(p0.z0erk), p0.z0guk, flag);
				}
				if (p0.z0mrk && p0.z0trk.A != 0)
				{
					z0yek("bottom", p0.z0trk, z0uek(p0.z0erk), p0.z0guk, flag);
				}
			}
			if (p0.z0yrk == CharacterCircleStyles.Rectangle)
			{
				z0yek(p0: true, p1: true, p2: true, p3: true, Color.Black, 1, DashStyle.Solid, flag);
			}
		}
		if (p1 is XTextParagraphFlagElement || p1 is XTextParagraphElement)
		{
			if (z0vrk)
			{
				switch (p0.z0tuk)
				{
				case DocumentContentAlignment.Left:
					z0yek("text-align", "left");
					break;
				case DocumentContentAlignment.Center:
					z0yek("text-align", "center");
					break;
				case DocumentContentAlignment.Right:
					z0yek("text-align", "right");
					break;
				case DocumentContentAlignment.Justify:
					z0yek("text-align", "justify");
					break;
				default:
					z0yek("text-align", "left");
					break;
				}
			}
			if (p0.z0irk > 0f)
			{
				z0yek("margin-top", z0yek(p0.z0irk));
			}
			if (p0.z0zyk > 0f)
			{
				z0yek("margin-bottom", z0yek(p0.z0zyk));
			}
			if (p0.z0hyk > 0f && p0.z0brk == ParagraphListStyle.None)
			{
				z0yek("margin-left", z0yek(p0.z0hyk));
			}
			if (p0.z0hyk > 0f && p0.z0brk != ParagraphListStyle.None)
			{
				z0yek("margin-left", z0yek(p0.z0hyk + p0.z0pyk));
			}
			switch (p0.z0cyk)
			{
			case LineSpacingStyle.Space1pt5:
				z0yek("line-height", "1.5");
				break;
			case LineSpacingStyle.SpaceDouble:
				z0yek("line-height", "2");
				break;
			case LineSpacingStyle.SpaceMultiple:
				z0yek("line-height", Convert.ToString(p0.z0itk));
				break;
			case LineSpacingStyle.SpaceSpecify:
				z0yek("line-height", z0yek(p0.z0itk));
				break;
			}
		}
		else if (p1 is XTextContentElement)
		{
			float num = p0.z0ryk;
			float num2 = p0.z0quk;
			float num3 = p0.z0ptk;
			float num4 = p0.z0xrk;
			if (p1 is XTextContentElement)
			{
				if (num2 != 0f && num4 != 0f)
				{
					z0ZzZzzej z0ZzZzzej2 = ((XTextContentElement)p1).z0ju();
					if (z0ZzZzzej2 != null && z0ZzZzzej2.z0uek() && z0ZzZzzej2.z0cek())
					{
						num2 = 0f;
						num4 = 0f;
					}
				}
				if (z0vrk)
				{
					num = 0f;
					num3 = 0f;
				}
			}
			int p3 = ((num != 0f) ? ((int)Math.Floor(z0tek(num))) : 0);
			int num5 = ((num2 != 0f) ? ((int)Math.Floor(z0tek(num2))) : 0);
			int p4 = ((num3 != 0f) ? ((int)Math.Floor(z0tek(num3))) : 0);
			int num6 = ((num4 != 0f) ? ((int)Math.Floor(z0tek(num4))) : 0);
			if (z0bek() && base.z0pek() > 0)
			{
				int num7 = Math.Min(base.z0pek(), num6);
				if (num7 > 0)
				{
					base.z0uek(base.z0pek() - num7);
					num6 -= num7;
				}
				num7 = Math.Min(base.z0pek(), num5);
				if (num7 > 0)
				{
					base.z0uek(base.z0pek() - num7);
					num5 -= num7;
				}
			}
			if (p1 is XTextTableCellElement)
			{
				XTextTableCellElement xTextTableCellElement = p1 as XTextTableCellElement;
				if (Options.ForPrint && ((XTextContentElement)xTextTableCellElement).z0zek() != null && ((XTextContentElement)xTextTableCellElement).z0zek().Length == 1 && ((XTextContentElement)xTextTableCellElement).z0zek()[0].z0grk() != null && xTextTableCellElement.z0krk().SpecifyHeight <= 0f)
				{
					num5 = (num6 = 0);
				}
			}
			z0uek(p3, num5, p4, num6);
			if (p0.z0stk != 0f || p0.z0byk != 0f || p0.z0zek != 0f || p0.z0suk != 0f)
			{
				z0yek((int)Math.Floor(z0tek(p0.z0stk)), (int)Math.Floor(z0tek(p0.z0byk)), (int)Math.Floor(z0tek(p0.z0zek)), (int)Math.Floor(z0tek(p0.z0suk)));
			}
		}
		if (p0.z0utk)
		{
			Color p5 = p0.z0ark;
			if (p5.A > 0)
			{
				if (z0vrk)
				{
					z0yek("background-color", z0uek(p5) + "!important");
				}
				else
				{
					z0yek("background-color", z0uek(p5));
				}
			}
		}
		if (z0vrk && p0.z0dtk)
		{
			z0yek("background-color", z0uek(p0.z0crk) + "!important");
		}
		Color color = Color.Empty;
		if (p0.z0ztk.A != 0)
		{
			color = p0.z0ztk;
		}
		else if (p0.z0urk)
		{
			color = p0.z0bek;
		}
		if (z0xrk)
		{
			color = Color.Black;
		}
		if ((p1 is XTextLabelElement || p1 is XTextStringElement || p1 is XTextCharElement || p1 is XTextCheckBoxElementBase || p1 is XTextParagraphFlagElement) && ((color.A != 0 && color != Color.Black) || z0xrk))
		{
			z0yek("color", z0uek(color));
		}
		if (p1 is XTextParagraphFlagElement && (double)Math.Abs(p0.z0pyk) > 0.05)
		{
			float num8 = p0.z0pyk;
			if (p0.z0brk != ParagraphListStyle.None)
			{
				num8 += p0.z0hyk;
			}
			z0yek("text-indent", z0ZzZzrpk.z0eek(num8, GraphicsUnit.Document, (z0ZzZzkpk)5));
		}
		if (p1 is XTextParagraphFlagElement)
		{
			if (p0.z0qrk)
			{
				z0yek("direction", "rtl");
			}
			else
			{
				z0yek("direction", "ltr");
			}
		}
		if (p1 is XTextTableCellElement)
		{
			switch (p0.z0srk)
			{
			case VerticalAlignStyle.Top:
				z0yek("vertical-align", "top");
				break;
			case VerticalAlignStyle.Middle:
				z0yek("vertical-align", "middle");
				break;
			case VerticalAlignStyle.Bottom:
				z0yek("vertical-align", "bottom");
				break;
			}
		}
	}

	public int z0tek()
	{
		return z0grk;
	}

	private void z0rek(XTextContainerElement p0)
	{
		XTextElementList xTextElementList = z0rek(p0.z0be(), z0mek(), Options.ExcludeLogicDeleted);
		if (xTextElementList == null || xTextElementList.Count <= 0)
		{
			return;
		}
		XTextParagraphFlagElement xTextParagraphFlagElement = null;
		bool flag = false;
		Stack<int> stack = new Stack<int>();
		for (int i = 0; i < xTextElementList.Count; i++)
		{
			XTextElement xTextElement = xTextElementList[i];
			if (xTextElement is XTextParagraphFlagElement)
			{
				if (xTextParagraphFlagElement == null && xTextElement.z0aek().z0brk != ParagraphListStyle.None)
				{
					if (flag)
					{
						z0cek("li");
						stack.Push(1);
						if (xTextElement.z0aek().z0kuk)
						{
							base.z0oek();
							z0yek("list-style-type", "none");
							((z0ZzZzfjh)this).z0zek();
						}
						z0uek(z0urk);
						if (stack.Count > 0)
						{
							z0yrk();
							stack.Pop();
						}
					}
					else
					{
						if (xTextElement.z0aek().z0ruk)
						{
							z0cek("ol");
							stack.Push(1);
						}
						else if (xTextElement.z0aek().z0kuk)
						{
							z0cek("ul");
							stack.Push(1);
						}
						z0uek("dcparagraphlistformat", xTextElement.z0aek().z0brk.ToString());
						z0cek("li");
						stack.Push(1);
						if (xTextElement.z0aek().z0kuk)
						{
							base.z0oek();
							z0yek("list-style-type", "none");
							((z0ZzZzfjh)this).z0zek();
						}
						z0uek(z0urk);
						if (stack.Count > 0)
						{
							z0yrk();
							stack.Pop();
						}
						flag = true;
					}
				}
				else if (xTextParagraphFlagElement == null || xTextParagraphFlagElement.z0aek().z0brk == ParagraphListStyle.None)
				{
					z0cek("br");
					base.z0oek();
					z0rek(xTextElement, xTextElement.z0jr());
					((z0ZzZzfjh)this).z0zek();
					z0uek("dcpf", "1");
					z0yrk();
					flag = false;
				}
				else if (xTextParagraphFlagElement.z0aek().z0brk != ParagraphListStyle.None && stack.Count > 0)
				{
					z0yrk();
					stack.Pop();
				}
				if (xTextElement == xTextElement.z0ji().z0zek() && flag)
				{
					if (stack.Count > 0)
					{
						((z0ZzZzfjh)this).z0xek();
						stack.Pop();
					}
					flag = false;
				}
				xTextParagraphFlagElement = null;
				continue;
			}
			if (xTextParagraphFlagElement == null)
			{
				xTextParagraphFlagElement = xTextElement.z0dy();
				bool flag2 = !p0.z0be().Contains(xTextParagraphFlagElement);
				if (xTextParagraphFlagElement == null || xTextParagraphFlagElement.z0aek().z0brk == ParagraphListStyle.None || flag2)
				{
					if (flag && stack.Count > 0)
					{
						((z0ZzZzfjh)this).z0xek();
						stack.Pop();
					}
					flag = false;
					z0uek(xTextElement);
				}
				else if (flag)
				{
					z0cek("li");
					stack.Push(1);
					if (xTextParagraphFlagElement.z0aek().z0kuk)
					{
						base.z0oek();
						z0yek("list-style-type", "none");
						((z0ZzZzfjh)this).z0zek();
					}
					z0uek(z0urk);
					z0uek(xTextElement);
				}
				else
				{
					flag = true;
					if (xTextParagraphFlagElement.z0aek().z0ruk)
					{
						z0cek("ol");
						stack.Push(1);
					}
					else if (xTextParagraphFlagElement.z0aek().z0kuk)
					{
						z0cek("ul");
						stack.Push(1);
					}
					z0uek("dcparagraphlistformat", xTextParagraphFlagElement.z0aek().z0brk.ToString());
					z0cek("li");
					stack.Push(1);
					if (xTextParagraphFlagElement.z0aek().z0kuk)
					{
						base.z0oek();
						z0yek("list-style-type", "none");
						((z0ZzZzfjh)this).z0zek();
					}
					z0uek(z0urk);
					z0uek(xTextElement);
				}
			}
			else
			{
				z0uek(xTextElement);
			}
			if (i == xTextElementList.Count - 1 && xTextParagraphFlagElement != null && xTextParagraphFlagElement == p0.z0xw() && xTextParagraphFlagElement.z0aek().z0brk != ParagraphListStyle.None && flag)
			{
				if (stack.Count > 0)
				{
					z0yrk();
					stack.Pop();
				}
				if (stack.Count > 0)
				{
					z0yrk();
					stack.Pop();
				}
				flag = false;
			}
		}
		while (stack.Count > 0)
		{
			stack.Pop();
			((z0ZzZzfjh)this).z0xek();
		}
	}

	public void z0rek(XTextTableElement p0)
	{
		bool forPrint = Options.ForPrint;
		bool flag = false;
		if (p0.z0frk() == DCTableAlignment.Right && forPrint && !z0mek())
		{
			flag = true;
			z0cek("div");
			base.z0oek();
			z0yek("height", z0iek(p0.Height + 2f));
			((z0ZzZzfjh)this).z0zek();
		}
		z0cek("table");
		if (!z0irk)
		{
			z0tek((XTextElement)p0);
			z0uek("dctype", "XTextTableElement");
		}
		z0uek("cellpadding", "0");
		z0uek("cellspacing", "0");
		if (!forPrint)
		{
			z0yek(p0);
			z0yek("cmpols", p0.CompressOwnerLineSpacing);
		}
		if (Options.z0srk)
		{
			if (p0.PrintVisibility != ElementVisibility.Visible)
			{
				z0uek("dc_printvisibility", z0ZzZzzyk.z0eek(typeof(ElementVisibility), p0.PrintVisibility));
			}
			if (p0.AcceptTab)
			{
				z0yek("dc_accepttab", p0.AcceptTab);
			}
			if (p0.z0frk() != DCTableAlignment.Default)
			{
				z0uek("dc_alignment", z0ZzZzzyk.z0eek(typeof(DCTableAlignment), p0.z0frk()));
			}
			if (p0.z0mrk())
			{
				z0yek("dc_allowrebindingdatasource", p0.z0mrk());
			}
			if (!p0.AllowUserDeleteRow)
			{
				z0yek("dc_allowuserdeleterow", p0.AllowUserDeleteRow);
			}
			if (!p0.AllowUserInsertRow)
			{
				z0yek("dc_allowuserinsertrow", p0.AllowUserInsertRow);
			}
			if (!p0.AllowUserToResizeColumns)
			{
				z0yek("dc_allowusertoresizecolumns", p0.AllowUserToResizeColumns);
			}
			if (p0.z0xrk())
			{
				z0yek("dc_allowusertoresizeeveninformviewmode", p0.z0xrk());
			}
			if (!p0.AllowUserToResizeRows)
			{
				z0yek("dc_allowusertoresizerows", p0.AllowUserToResizeRows);
			}
			z0rek(p0.Attributes);
			if (p0.z0dt())
			{
				z0yek("dc_bringouttosave", p0.z0dt());
			}
			if (p0.z0gt())
			{
				z0yek("dc_canbereferenced", p0.z0gt());
			}
			if (p0.CompressOwnerLineSpacing)
			{
				z0yek("dc_compressownerlinespacing", p0.CompressOwnerLineSpacing);
			}
			if (p0.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0uek("dc_contentreadonly", z0ZzZzzyk.z0eek(typeof(ContentReadonlyState), p0.ContentReadonly));
			}
			if (p0.ContentReadonlyExpression != null && p0.ContentReadonlyExpression.Length > 0)
			{
				z0uek("dc_contentreadonlyexpression", p0.ContentReadonlyExpression);
			}
			if (p0.z0ht() != null && p0.z0ht().Length > 0)
			{
				z0uek("dc_dataname", p0.z0ht());
			}
			if (!p0.Deleteable)
			{
				z0yek("dc_deleteable", p0.Deleteable);
			}
			if (p0.EnablePermission != DCBooleanValue.Inherit)
			{
				z0uek("dc_enablepermission", z0ZzZzzyk.z0eek(typeof(DCBooleanValue), p0.EnablePermission));
			}
			z0yek("dc_enablevaluevalidate", p0.EnableValueValidate);
			if (!p0.z0mek())
			{
				z0yek("dc_holdwholeline", p0.z0mek());
			}
			if (p0.ID != null && p0.ID.Length > 0)
			{
				z0uek("id", p0.ID);
			}
			if (((XTextContainerElement)p0).z0htk())
			{
				z0yek("ircr", ((XTextContainerElement)p0).z0htk());
			}
			if (p0.LimitedInputChars != null && p0.LimitedInputChars.Length > 0)
			{
				z0uek("dc_limitedinputchars", p0.LimitedInputChars);
			}
			if (p0.PropertyExpressions != null && p0.PropertyExpressions.Count > 0)
			{
				z0uek("dc_propertyexpressions", ((z0ZzZzcuk)p0.PropertyExpressions).DCWriteString());
			}
			if (p0.z0wr() != MoveFocusHotKeys.None)
			{
				z0uek("rmfhk", z0ZzZzzyk.z0eek(typeof(MoveFocusHotKeys), p0.z0wr()));
			}
			if (p0.z0hrk() != TableSubfieldMode.None)
			{
				z0uek("dc_subfieldmode", z0ZzZzzyk.z0eek(typeof(TableSubfieldMode), p0.z0hrk()));
			}
			if (p0.z0prk() != 1)
			{
				z0yek("dc_subfieldnumber", p0.z0prk());
			}
			if (p0.ValidateStyle != null && !p0.ValidateStyle.IsEmpty)
			{
				string text = ((z0ZzZzcuk)p0.ValidateStyle).DCWriteString();
				text = text.Replace("\"", "'");
				z0uek("dc_validatestyle", text);
			}
			if (p0.ValueBinding != null)
			{
				z0uek("dc_valuebinding", ((z0ZzZzcuk)p0.ValueBinding).DCWriteString());
			}
			if (!p0.Visible)
			{
				z0yek("dc_visible", p0.Visible);
			}
			if (p0.VisibleExpression != null && p0.VisibleExpression.Length > 0)
			{
				z0uek("dc_visibleexpression", p0.VisibleExpression);
			}
		}
		else if (!z0irk)
		{
			z0rek(p0.Attributes);
		}
		if (!z0mek())
		{
			z0uek("width", z0oek(p0.Width));
		}
		if (!p0.z0yi() && p0.z0wtk() && !Options.DocumentOptions.SecurityOptions.ShowLogicDeletedContent)
		{
			Options.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = true;
			p0.z0jrk(p0: true);
			p0.z0ct();
			Options.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = false;
		}
		bool flag2 = false;
		z0rek(p0.z0qt());
		base.z0oek();
		if (p0.z0aek().z0jyk >= 0)
		{
			z0rek(p0, p0.z0jr());
			flag2 = true;
		}
		if (forPrint && p0.z0dy().z0xrk().Align == DocumentContentAlignment.Right)
		{
			z0yek("display", "contents");
		}
		if (!p0.Visible)
		{
			z0yek("display", "none");
		}
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		z0rek(z0ZzZzrzj2, p0);
		z0yek("border-collapse", "collapse");
		if (Options.FixHTMLTableLayout)
		{
			z0yek("table-layout", "fixed");
		}
		bool flag3 = z0ZzZzrzj2.z0oek();
		bool flag4 = z0ZzZzrzj2.z0iek();
		bool flag5 = z0ZzZzrzj2.z0tek();
		bool flag6 = z0ZzZzrzj2.z0uek();
		float num = Math.Min(1f, z0ZzZzrzj2.z0erk);
		Color color = (Options.ForPrint ? Color.Transparent : z0erk.NoneBorderColor);
		if ((flag3 || flag4 || flag5 || flag6) && (!flag3 || !flag4 || !flag5 || !flag6))
		{
			z0yek("left", flag3 ? z0ZzZzrzj2.z0nek : color, (int)num, z0ZzZzrzj2.z0guk);
			z0yek("top", flag4 ? z0ZzZzrzj2.z0myk : color, (int)num, z0ZzZzrzj2.z0guk);
			z0yek("right", flag5 ? z0ZzZzrzj2.z0grk : color, (int)num, z0ZzZzrzj2.z0guk);
			z0yek("bottom", flag6 ? z0ZzZzrzj2.z0trk : color, (int)num, z0ZzZzrzj2.z0guk);
		}
		((z0ZzZzfjh)this).z0zek();
		if (!p0.Visible)
		{
			p0.Visible = true;
			p0.z0uu(p0: false);
		}
		XTextElementList xTextElementList = p0.z0srk();
		if (z0mek())
		{
			XTextElementList p1 = null;
			XTextElementList p2 = null;
			p0.z0pek(out p1, out p2);
			int num2 = p0.z0srk().Count - 1;
			int num3 = 0;
			if (p2 != null && p2.Count > 0)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p2.z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
					num2 = Math.Min(xTextTableCellElement.z0xek(), num2);
					num3 = Math.Max(xTextTableCellElement.z0xek() + xTextTableCellElement.ColSpan - 1, num3);
				}
			}
			xTextElementList = new XTextElementList();
			for (int i = num2; i <= num3 && i < p0.z0srk().Count - 1; i++)
			{
				xTextElementList.z0hrk(p0.z0srk()[i]);
			}
		}
		XTextElement lastElement = p0.z0srk().LastElement;
		foreach (XTextTableColumnElement item in xTextElementList.z0xrk())
		{
			z0cek("col");
			float num4 = 0f;
			num4 = ((lastElement != item || !(p0.z0ji() is XTextTableCellElement)) ? z0tek(item.Width) : z0tek(item.Width));
			string text2 = null;
			text2 = ((!forPrint) ? base.z0uek(num4) : (num4.ToString("0.00") + "px"));
			z0uek("style", "width:" + text2);
			z0uek("width", text2);
			if (item.ID != null && item.ID.Length > 0)
			{
				z0uek("id", item.ID);
			}
			if (Options.z0srk)
			{
				z0rek(item.Attributes);
				if (item.ValueBinding != null)
				{
					z0uek("dc_valuebinding", ((z0ZzZzcuk)item.ValueBinding).DCWriteString());
				}
			}
			z0yrk();
		}
		float p3 = ((XTextElement)p0).z0zrk();
		float num5 = ((XTextElement)p0).z0ltk();
		XTextElementList xTextElementList2 = p0.z0stk();
		XTextTableRowElement xTextTableRowElement = null;
		XTextElementList p4 = null;
		XTextElementList xTextElementList3 = null;
		XTextElementList xTextElementList4 = null;
		bool flag7 = p0.z0qek() != null && p0.z0qek().z0fu() == PageContentPartyStyle.Body;
		if (z0mek())
		{
			xTextElementList3 = p0.z0zek();
			xTextElementList4 = xTextElementList3;
			flag7 = true;
			p0.z0pek(out p4, out xTextElementList4);
			if (xTextElementList4 != null && xTextElementList4.Count == xTextElementList3.Count)
			{
				int count = xTextElementList4.Count;
				bool flag8 = true;
				for (int j = 0; j < count; j++)
				{
					if (xTextElementList4[j] != xTextElementList3[j])
					{
						flag8 = false;
						break;
					}
				}
				if (flag8)
				{
					xTextElementList4 = xTextElementList3;
				}
			}
		}
		else if (!z0jrk.z0vek())
		{
			p4 = new XTextElementList();
			xTextElementList4 = new XTextElementList();
			XTextElementList xTextElementList5 = p0.z0stk();
			int count2 = xTextElementList5.Count;
			float num6 = (float)z0jrk.z0mek() - num5 + 1f;
			for (int k = 0; k < count2; k++)
			{
				XTextElement xTextElement = xTextElementList5[k];
				if (!xTextElement.z0cuk || !(xTextElement.z0xtk() > num6))
				{
					continue;
				}
				float num7 = (float)z0jrk.z0bek() - num5 - 2f;
				for (int l = k; l < count2; l++)
				{
					XTextElement xTextElement2 = xTextElementList5[l];
					if (xTextElement2.z0cuk)
					{
						if (xTextElement2.z0yt() > num7)
						{
							break;
						}
						p4.z0hrk(xTextElement2);
						((zzz.z0ZzZzkuk<XTextElement>)xTextElementList4).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElement2.z0be());
					}
				}
				break;
			}
		}
		else
		{
			p4 = p0.z0stk();
			xTextElementList4 = p0.z0zek();
			xTextElementList3 = xTextElementList4;
		}
		for (int num8 = xTextElementList4.Count - 1; num8 >= 0; num8--)
		{
			((XTextTableCellElement)xTextElementList4[num8]).z0rek(p0: false);
		}
		int num9 = z0yek().z0bek();
		XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)p4.LastElement;
		bool flag9 = z0yek().z0vek();
		bool flag10 = true;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p4.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				if (!((XTextTableRowElement)z0bpk.Current).HeaderStyle)
				{
					flag10 = false;
					break;
				}
			}
		}
		if (z0grk != 0 && flag10 && p4.Count < p0.z0stk().Count && Options.ForPrint && xTextTableRowElement2 != null)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement2.z0rek().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk.Current;
				if (!xTextTableCellElement2.z0bek())
				{
					((XTextElement)xTextTableCellElement2).z0xrk().BorderBottom = false;
				}
				else
				{
					((XTextElement)xTextTableCellElement2.z0hrk()).z0xrk().BorderBottom = false;
				}
			}
		}
		int num10 = ((xTextTableRowElement2 != null) ? p0.z0pek(xTextTableRowElement2) : 0);
		bool flag11 = Options.ViewStyle == (z0ZzZzlgh)2;
		z0ZzZzbdh p5 = z0yek().z0eek();
		Dictionary<XTextTableCellElement, int> dictionary = null;
		if (flag7 && flag11 && !flag9)
		{
			dictionary = new Dictionary<XTextTableCellElement, int>();
		}
		int count3 = p4.Count;
		z0tgj z0tgj = new z0tgj();
		z0tgj.z0uek = p3;
		z0tgj.z0tek = num5;
		z0tgj.z0rek = new List<z0pok>();
		for (int m = 0; m < count3; m++)
		{
			XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)p4[m];
			if (!xTextTableRowElement3.z0yi())
			{
				continue;
			}
			z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(p3, num5 + xTextTableRowElement3.z0yt(), xTextTableRowElement3.Width, (int)xTextTableRowElement3.Height);
			z0ZzZzbdh z0ZzZzbdh3 = z0ZzZzbdh2;
			int num11 = 0;
			if (!flag9)
			{
				z0ZzZzbdh3 = z0ZzZzbdh.z0tek(p5, z0ZzZzbdh2);
				if (z0ZzZzbdh3.z0nek() != z0ZzZzbdh2.z0nek())
				{
					num11 = 3;
				}
				if (z0ZzZzbdh3.z0iek() < 5f)
				{
					continue;
				}
			}
			if (xTextTableRowElement == null)
			{
				xTextTableRowElement = xTextTableRowElement3;
			}
			z0cek("tr");
			if (Options.z0srk)
			{
				if (xTextTableRowElement3.PrintVisibility != ElementVisibility.Visible)
				{
					z0uek("dc_printvisibility", z0ZzZzzyk.z0eek(typeof(ElementVisibility), xTextTableRowElement3.PrintVisibility));
				}
				if (xTextTableRowElement3.AcceptTab)
				{
					z0yek("dc_accepttab", xTextTableRowElement3.AcceptTab);
				}
				z0rek("dc_allowinsertrowdownusehotkey", xTextTableRowElement3.AllowInsertRowDownUseHotKey, DCInsertRowDownUseHotKeys.EnableOnlyForLastRow);
				z0rek("dc_allowusertoresizeheight", xTextTableRowElement3.AllowUserToResizeHeight, DCBooleanValue.Inherit);
				z0rek(xTextTableRowElement3.Attributes);
				if (xTextTableRowElement3.z0dt())
				{
					z0yek("dc_bringouttosave", xTextTableRowElement3.z0dt());
				}
				if (xTextTableRowElement3.z0gt())
				{
					z0yek("dc_canbereferenced", xTextTableRowElement3.z0gt());
				}
				if (!xTextTableRowElement3.CanSplitByPageLine)
				{
					z0yek("dc_cansplitbypageline", xTextTableRowElement3.CanSplitByPageLine);
				}
				if (xTextTableRowElement3.z0jrk() != 1)
				{
					z0yek("dc_clonemultiplebaseforbindingdatasource", xTextTableRowElement3.z0jrk());
				}
				if (xTextTableRowElement3.CloneType != TableRowCloneType.Default)
				{
					z0uek("dc_clonetype", z0ZzZzzyk.z0eek(typeof(TableRowCloneType), xTextTableRowElement3.CloneType));
				}
				if (xTextTableRowElement3.ContentReadonly != ContentReadonlyState.Inherit)
				{
					z0uek("dc_contentreadonly", z0ZzZzzyk.z0eek(typeof(ContentReadonlyState), xTextTableRowElement3.ContentReadonly));
				}
				z0iek("dc_contentreadonlyexpression", xTextTableRowElement3.ContentReadonlyExpression);
				z0iek("dc_dataname", xTextTableRowElement3.z0ht());
				if (!xTextTableRowElement3.Deleteable)
				{
					z0yek("dc_deleteable", xTextTableRowElement3.Deleteable);
				}
				if (xTextTableRowElement3.EnablePermission != DCBooleanValue.Inherit)
				{
					z0uek("dc_enablepermission", z0ZzZzzyk.z0eek(typeof(DCBooleanValue), xTextTableRowElement3.EnablePermission));
				}
				z0yek("dc_enablevaluevalidate", xTextTableRowElement3.EnableValueValidate);
				if (!xTextTableRowElement3.ExpendForDataBinding)
				{
					z0yek("dc_expendfordatabinding", xTextTableRowElement3.ExpendForDataBinding);
				}
				if (xTextTableRowElement3.z0yek())
				{
					z0yek("dc_generatebyvaluebingding", xTextTableRowElement3.z0yek());
				}
				if (xTextTableRowElement3.HeaderStyle)
				{
					z0yek("dc_headerstyle", xTextTableRowElement3.HeaderStyle);
				}
				z0iek("id", xTextTableRowElement3.ID);
				if (xTextTableRowElement3.z0htk())
				{
					z0yek("ircr", xTextTableRowElement3.z0htk());
				}
				z0iek("dc_limitedinputchars", xTextTableRowElement3.LimitedInputChars);
				if (xTextTableRowElement3.NewPage)
				{
					z0yek("dc_newpage", xTextTableRowElement3.NewPage);
				}
				if (!xTextTableRowElement3.PrintCellBackground)
				{
					z0yek("dc_printcellbackground", xTextTableRowElement3.PrintCellBackground);
				}
				if (!xTextTableRowElement3.PrintCellBorder)
				{
					z0yek("dc_printcellborder", xTextTableRowElement3.PrintCellBorder);
				}
				if (xTextTableRowElement3.PropertyExpressions != null && xTextTableRowElement3.PropertyExpressions.Count > 0)
				{
					z0uek("dc_propertyexpressions", ((z0ZzZzcuk)xTextTableRowElement3.PropertyExpressions).DCWriteString());
				}
				if (xTextTableRowElement3.z0wr() != MoveFocusHotKeys.None)
				{
					z0uek("rmfhk", zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0rek(xTextTableRowElement3.z0wr()));
				}
				if (xTextTableRowElement3.SpecifyHeight != 0f)
				{
					z0yek("dc_specifyheight", xTextTableRowElement3.SpecifyHeight);
				}
				if (xTextTableRowElement3.ValidateStyle != null && !xTextTableRowElement3.ValidateStyle.IsEmpty)
				{
					string text3 = xTextTableRowElement3.ValidateStyle.DCWriteString();
					text3 = text3.Replace("\"", "'");
					z0uek("dc_validatestyle", text3);
				}
				if (xTextTableRowElement3.ValueBinding != null)
				{
					z0uek("dc_valuebinding", xTextTableRowElement3.ValueBinding.DCWriteString());
					z0uek("datasourcename", xTextTableRowElement3.ValueBinding.DataSource);
				}
				if (!xTextTableRowElement3.Visible)
				{
					z0yek("dc_visible", xTextTableRowElement3.Visible);
				}
				z0iek("dc_visibleexpression", xTextTableRowElement3.VisibleExpression);
			}
			base.z0oek();
			if (!flag2 && forPrint && xTextTableRowElement3.z0aek().z0jyk >= 0)
			{
				z0yek("background-color", "yellow");
				z0rek(xTextTableRowElement3, xTextTableRowElement3.z0jr());
			}
			bool flag12 = false;
			float num12 = (z0tgj.z0yek = xTextTableRowElement3.z0cek());
			z0tgj.z0eek = num5 + xTextTableRowElement3.z0yt();
			if (num12 != 0f && xTextTableRowElement3.Height <= Math.Abs(num12))
			{
				flag12 = true;
			}
			else if (forPrint)
			{
				flag12 = true;
			}
			if (flag12)
			{
				if (forPrint)
				{
					float num13 = z0tek(z0ZzZzbdh3.z0iek());
					if (z0trk() == (z0ZzZzjok)6)
					{
						num13 = (float)Math.Round(num13);
					}
					z0yek("height", base.z0uek(num13));
				}
				else if (z0trk() == (z0ZzZzjok)5 && base.z0mek() == (z0ZzZztjh)1)
				{
					z0yek("height", z0iek(z0ZzZzbdh3.z0iek() + (float)num11 - 23f));
				}
				else if (z0trk() == (z0ZzZzjok)6 && z0ark_jiejie20260327142557() != 0)
				{
					((z0ZzZzfjh)this).z0zek();
					z0uek("height", z0iek(z0ZzZzbdh3.z0iek() + (float)num11 - 23f));
				}
				else
				{
					((z0ZzZzfjh)this).z0zek();
					z0uek("height", z0iek(z0ZzZzbdh3.z0iek() + (float)num11));
				}
			}
			if (z0drk())
			{
				((z0ZzZzfjh)this).z0zek();
			}
			XTextElementList xTextElementList6 = xTextTableRowElement3.z0rek();
			int count4 = xTextElementList6.Count;
			for (int n = 0; n < count4; n++)
			{
				XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextElementList6[n];
				if (z0brk && !xTextElementList4.Contains(xTextTableCellElement3))
				{
					continue;
				}
				if (xTextTableCellElement3.z0yi())
				{
					if (flag11)
					{
						int num14 = xTextTableCellElement3.z0iek();
						if (num14 > 1)
						{
							num14 = Math.Min(num14, num10 - xTextTableCellElement3.z0pek() + 1);
						}
						z0rek(xTextTableCellElement3, num14, z0tgj);
						if (dictionary != null)
						{
							dictionary[xTextTableCellElement3] = 1;
						}
					}
					else
					{
						z0rek(xTextTableCellElement3, xTextTableCellElement3.RowSpan, z0tgj);
						if (dictionary != null)
						{
							dictionary[xTextTableCellElement3] = 1;
						}
					}
					xTextTableCellElement3.z0rek(p0: true);
					continue;
				}
				if (xTextTableCellElement3.z0bek())
				{
					if (dictionary == null)
					{
						continue;
					}
					XTextTableCellElement xTextTableCellElement4 = xTextTableCellElement3.z0hrk();
					if (xTextTableCellElement4.z0krk() == xTextTableCellElement3.z0krk() || dictionary.ContainsKey(xTextTableCellElement4))
					{
						continue;
					}
					z0ZzZzbdh p6 = xTextTableCellElement4.z0qyk();
					if (!(z0ZzZzbdh.z0tek(p6, z0yek().z0eek()).z0iek() > 5f) || xTextTableCellElement4.RowSpan <= 1)
					{
						continue;
					}
					XTextTableRowElement xTextTableRowElement4 = xTextTableCellElement4.z0frk();
					int num15 = Math.Min(xTextTableCellElement4.z0iek(), xTextTableRowElement4.z0grk() - xTextTableRowElement3.z0grk() + 1);
					if (num15 <= 0)
					{
						num15 = 1;
					}
					int num16 = xTextTableRowElement3.z0grk();
					if (num16 < xTextTableRowElement4.z0grk())
					{
						for (int num17 = num16 + 1; num17 < xTextElementList2.Count; num17++)
						{
							XTextTableRowElement xTextTableRowElement5 = (XTextTableRowElement)xTextElementList2[num17];
							if (xTextTableRowElement5 == xTextTableRowElement4 || num5 + xTextTableRowElement5.z0yt() > (float)(num9 - 3))
							{
								num15 = num17 - num16 + 1;
								break;
							}
						}
					}
					dictionary[xTextTableCellElement4] = 1;
					z0rek(xTextTableCellElement4, num15, z0tgj);
					continue;
				}
				if (!xTextTableCellElement3.z0drk().Visible && xTextTableCellElement3.z0hrk() == null && xTextTableCellElement3.Visible)
				{
					if (dictionary != null)
					{
						dictionary[xTextTableCellElement3] = 1;
					}
					z0rek(xTextTableCellElement3, xTextTableCellElement3.z0iek(), z0tgj);
					continue;
				}
				XTextTableCellElement xTextTableCellElement5 = xTextTableCellElement3.z0hrk();
				if (xTextTableCellElement5 != null && xTextTableCellElement5.z0yi() && !xTextTableCellElement3.z0jrk())
				{
					xTextTableCellElement3.z0rek(p0: true);
					int num18 = 0;
					num18 = ((Options.ViewStyle != (z0ZzZzlgh)2) ? (xTextTableCellElement5.RowSpan - (xTextTableRowElement3.z0drk() - xTextTableCellElement5.z0pek())) : (xTextTableCellElement5.z0iek() - (xTextTableRowElement3.z0drk() - xTextTableCellElement5.z0pek())));
					if (dictionary != null)
					{
						dictionary[xTextTableCellElement3] = 1;
					}
					z0rek(xTextTableCellElement3, num18, z0tgj);
				}
			}
			((z0ZzZzfjh)this).z0xek();
		}
		z0tgj.z0rek.Clear();
		z0tgj = null;
		dictionary?.Clear();
		((z0ZzZzfjh)this).z0xek();
		if (flag)
		{
			((z0ZzZzfjh)this).z0xek();
		}
	}

	private void z0rek(XTextChartElement p0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["id"] = p0.ID;
		dictionary["name"] = p0.Name;
		dictionary["height"] = z0oek(p0.Height);
		dictionary["width"] = z0oek(p0.Width);
		if (Options.ForPrint)
		{
			z0eek(p0, dictionary);
			return;
		}
		z0cek("img");
		z0uek("dctype", "XTextChartElement");
		if (dictionary != null)
		{
			foreach (string key in dictionary.Keys)
			{
				z0uek(key, dictionary[key]);
			}
		}
		z0yrk();
	}

	public void z0rek(XTextElement p0)
	{
		z0eek(p0, null);
	}

	private void z0tek(XTextSignImageElement p0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string text = z0rrk();
		if (text != null && text.Length > 0)
		{
			dictionary["title"] = text;
		}
		dictionary["dc_signerrormessage"] = p0.SignErrorMessage;
		dictionary["dc_signmessage"] = p0.SignMessage;
		dictionary["dc_state"] = p0.SignState.ToString();
		dictionary["dc_imageinfrontoftext"] = ((p0.ZOrderStyle == ElementZOrderStyle.InFrontOfText) ? "true" : "false");
		dictionary["dc_useinnersignprovider"] = p0.UseInnerSignProvider.ToString();
		if (p0.DataForSelfCheck != null && p0.DataForSelfCheck.Length != 0)
		{
			dictionary["dc_dataforselfcheck"] = Convert.ToBase64String(p0.DataForSelfCheck);
		}
		z0eek(p0, dictionary);
	}

	public new z0ZzZzndh z0yek()
	{
		return z0jrk;
	}

	public void z0rek(string p0, z0ZzZzrzj p1, XTextElement p2, float p3, bool p4 = false, bool p5 = false, bool p6 = false)
	{
		XTextDocument xTextDocument = p2.z0jr();
		if (p3 != 0f)
		{
			p5 = false;
		}
		if (p1.z0gtk)
		{
			z0cek("sub");
			p5 = false;
		}
		else if (p1.z0euk)
		{
			z0cek("sup");
			p5 = false;
		}
		else
		{
			z0cek("span");
		}
		if (p2 is XTextLabelElement)
		{
			z0uek("dctype", p2.z0qrk());
			z0uek("id", p2.z0wyk());
		}
		else if (p2 is XTextStringElement)
		{
			XTextStringElement xTextStringElement = (XTextStringElement)p2;
			if (xTextStringElement.z0yi() && xTextStringElement.z0tek() != null)
			{
				z0rek(xTextStringElement.z0tek(), xTextStringElement.z0uek());
			}
		}
		z0yek(p2);
		if (Options.ForPrint && p2.z0brk() != null && p2.z0brk().AutoFixFontSizeMode != ContentAutoFixFontSizeMode.None)
		{
			string p7 = p1.z0wtk + "pt";
			z0uek("nowfontsize", p7);
		}
		DocumentComment documentComment = null;
		Color transparent = Color.Transparent;
		if (!z0irk)
		{
			if (p1.z0yrk != CharacterCircleStyles.None)
			{
				z0uek("dc_charactercircle", p1.z0yrk.ToString());
			}
			if (p1.z0auk > -1)
			{
				z0uek("dc_titlelevel", p1.z0auk.ToString());
			}
			if (p1.z0vyk >= 0)
			{
				z0uek("dctype", "DocumentComment");
				z0uek("refcommentindex", z0ZzZzqik.z0rek(p1.z0vyk));
				documentComment = xTextDocument.Comments.z0eek(p1.z0vyk);
				if (documentComment != null)
				{
					z0uek("title", documentComment.z0eek(xTextDocument) + Environment.NewLine + documentComment.z0nek());
				}
			}
			z0rek(p2.z0qt());
		}
		bool flag = false;
		if (p2.z0ji() is XTextInputFieldElement)
		{
			XTextInputFieldElement xTextInputFieldElement = p2.z0ji() as XTextInputFieldElement;
			XTextParagraphFlagElement xTextParagraphFlagElement = p2.z0dy();
			if (xTextInputFieldElement != null && xTextParagraphFlagElement != null && xTextParagraphFlagElement.z0aek().z0pyk > 0f && (!((XTextInputFieldElementBase)xTextInputFieldElement).z0yek() || (((XTextInputFieldElementBase)xTextInputFieldElement).z0yek() && xTextInputFieldElement.z0dtk() is XTextParagraphFlagElement)) && p2 is XTextStringElement && ((XTextStringElement)p2).z0tek().z0ke() is XTextParagraphFlagElement)
			{
				flag = true;
				p5 = false;
			}
		}
		if (p2.z0xrk().ProtectType != ContentProtectType.None)
		{
			z0uek("dc_protecttype", p2.z0xrk().ProtectType.ToString());
		}
		if (p5 && p1.z0ktk != null)
		{
			z0ltk++;
			z0lrk(p1.z0ktk);
			z0rek(p2, xTextDocument);
			if (p4 && p0.Length == 1 && p0[0] == '\u2002' && Options.ForPrint && !Options.DocumentOptions.ViewOptions.IgnoreFieldBorderWhenPrint && p3 == 0f)
			{
				string p8 = Options.DocumentOptions.ViewOptions.FieldBorderElementPixelWidth + "px";
				base.z0oek();
				z0yek("display", "inline-block");
				z0yek("width", p8);
				((z0ZzZzfjh)this).z0zek();
			}
			if (Options.ForPrint && p0 != null)
			{
				string[] array = p0.Split('，');
				string[] array2 = p0.Split('。');
				string[] array3 = p0.Split('：');
				string[] array4 = p0.Split('、');
				string[] array5 = p0.Split('（');
				string[] array6 = p0.Split('）');
				int num = array.Length + array2.Length + array3.Length + array4.Length + array5.Length + array6.Length - 6;
				if (num != 0)
				{
					base.z0oek();
					z0yek("letter-spacing", "-" + (double)Math.Abs(num) * 0.1);
					z0yek("display", "");
					((z0ZzZzfjh)this).z0zek();
				}
			}
		}
		else
		{
			base.z0oek();
			z0rek(p1, p2);
			if (p1.z0vyk >= 0 && documentComment != null)
			{
				z0yek("background-color", z0uek(z0ZzZzsfh.z0eek(transparent)));
			}
			if (Options.ForPrint && p2.z0jy() is XTextTableCellElement && p2.z0jy().z0uek() < 1f)
			{
				z0yek("zoom", p2.z0jy().z0uek().ToString());
			}
			z0yek(p1.z0pek, p0);
			if (p4 && p0.Length == 1 && p0[0] == '\u2002' && Options.ForPrint && !Options.DocumentOptions.ViewOptions.IgnoreFieldBorderWhenPrint && p3 == 0f)
			{
				string p9 = Options.DocumentOptions.ViewOptions.FieldBorderElementPixelWidth + "px";
				z0yek("display", "inline-block");
				z0yek("width", p9);
			}
			if (Options.ForPrint && (p1.z0euk || p1.z0gtk))
			{
				z0yek("font-size", "smaller");
			}
			if (p0.Length > 0 && z0ZzZzqik.z0tek(p0))
			{
				z0yek("word-break", "unset");
			}
			if (p1.z0yyk)
			{
				z0yek("text-decoration", "line-through");
			}
			if (flag)
			{
				z0yek("display", "inline-block");
			}
			if (Options.ForPrint && p0 != null)
			{
				string[] array7 = p0.Split('，');
				string[] array8 = p0.Split('。');
				string[] array9 = p0.Split('：');
				string[] array10 = p0.Split('、');
				string[] array11 = p0.Split('（');
				string[] array12 = p0.Split('）');
				int num2 = array7.Length + array8.Length + array9.Length + array10.Length + array11.Length + array12.Length - 6;
				if (num2 != 0)
				{
					z0yek("letter-spacing", "-" + (double)Math.Abs(num2) * 0.1);
					z0yek("display", "");
				}
			}
			if (z0rek(p2, xTextDocument))
			{
				z0vek("text-decoration");
			}
			if (p2 is XTextCheckBoxElementBase)
			{
				_ = ((XTextCheckBoxElementBase)p2).Multiline;
			}
			if (p3 > 0f)
			{
				z0yek("width", z0iek(p3));
				if (!p4 || p0.Length <= 0 || p0[0] == '\u2002')
				{
					z0yek("display", "inline-block");
				}
				if (p2 is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)p2;
					z0yek("text-align", xTextCheckBoxElementBase.CaptionAlign.ToString().ToLower());
					if (xTextCheckBoxElementBase.z0pek())
					{
						z0yek("white-space", "normal");
						z0yek("display", "inline-flex");
					}
				}
				else
				{
					if (z0vrk && !p4)
					{
						z0yek("vertical-align", "middle");
					}
					z0yek("text-align", p1.z0tuk.ToString());
					if (!p1.z0jtk)
					{
						z0yek("white-space", "nowrap");
						z0yek("word-break", "keep-all");
					}
				}
				z0yek("overflow", "hidden");
			}
			if (p2.z0ji() is XTextInputFieldElement xTextInputFieldElement2 && xTextInputFieldElement2.TextColor != Color.Transparent)
			{
				if (xTextInputFieldElement2.TextColor == Color.FromArgb(254, 254, 254))
				{
					z0yek("color", "transparent");
				}
				else
				{
					z0yek("color", z0uek(xTextInputFieldElement2.TextColor));
				}
			}
			if (p2 is XTextStringElement || p2 is XTextCharElement)
			{
				if (p1.z0xrk > 0f)
				{
					z0yek("padding-bottom", z0ZzZzrpk.z0eek(p1.z0xrk, GraphicsUnit.Document, GraphicsUnit.Pixel) + "px");
				}
				if (p1.z0quk > 0f)
				{
					z0yek("padding-top", z0ZzZzrpk.z0eek(p1.z0quk, GraphicsUnit.Document, GraphicsUnit.Pixel) + "px");
				}
			}
			string text = ((z0ZzZzfjh)this).z0zek();
			if (p5)
			{
				p1.z0ktk = text;
			}
		}
		z0rek(p0, p1);
		((z0ZzZzfjh)this).z0xek();
	}

	public new int z0uek()
	{
		return z0ark;
	}

	public static void z0rek(z0ZzZzrjh p0, XTextRadioBoxElement p1)
	{
		if (p1.CaptionFlowLayout)
		{
			p0.z0yek("dc_captionflowlayout", p1.CaptionFlowLayout);
		}
		if (!p1.Visible)
		{
			p0.z0yek("dc_visible", p1.Visible);
		}
		p0.z0yek("dc_height", z0ZzZzrpk.z0eek(p1.Height, GraphicsUnit.Document, GraphicsUnit.Pixel));
		p0.z0yek("dc_width", z0ZzZzrpk.z0eek(p1.Width, GraphicsUnit.Document, GraphicsUnit.Pixel));
		p0.z0rek("dc_printvisibility", p1.PrintVisibility, ElementVisibility.Visible);
		p0.z0rek("dc_printvisibilitywhenunchecked", p1.PrintVisibilityWhenUnchecked, PrintVisibilityModeWhenUnchecked.Visible);
		if (p1.PrintTextForChecked != null && p1.PrintTextForChecked.Length > 0)
		{
			p0.z0uek("dc_printtextforchecked", p1.PrintTextForChecked);
		}
		if (p1.PrintTextForUnChecked != null && p1.PrintTextForUnChecked.Length > 0)
		{
			p0.z0uek("dc_printtextforunchecked", p1.PrintTextForUnChecked);
		}
		p0.z0rek(p1.Attributes);
		if (p1.BringoutToSave)
		{
			p0.z0yek("dc_bringouttosave", p1.BringoutToSave);
		}
		if (p1.CanBeReferenced)
		{
			p0.z0yek("dc_canbereferenced", p1.CanBeReferenced);
		}
		if (p1.Caption != null && p1.Caption.Length > 0)
		{
			p0.z0uek("dc_caption", p1.Caption);
		}
		p0.z0rek("dc_captionalign", p1.CaptionAlign, StringAlignment.Center);
		if (!p1.CheckAlignLeft)
		{
			p0.z0yek("dc_checkalignleft", p1.CheckAlignLeft);
		}
		p0.z0rek("dc_checkboxvisibility", p1.CheckboxVisibility, RenderVisibility.All);
		p0.z0rek("dc_contentreadonly", p1.ContentReadonly, ContentReadonlyState.Inherit);
		p0.z0rek("dc_controlstyle", p1.z0oi(), CheckBoxControlStyle.RadioBox);
		if (p1.DataName != null && p1.DataName.Length > 0)
		{
			p0.z0uek("dc_dataname", p1.DataName);
		}
		if (!p1.Deleteable)
		{
			p0.z0yek("dc_deleteable", p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0yek("dc_enabled", p1.Enabled);
		}
		if (p1.EnableHighlight != EnableState.Enabled)
		{
			p0.z0uek("dc_enablehighlight", z0ZzZzzyk.z0eek(typeof(EnableState), p1.EnableHighlight));
		}
		if (((XTextObjectElement)p1).z0iek() != null)
		{
			p0.z0uek("dc_linkinfo", z0ZzZzmik.z0rek(((XTextObjectElement)p1).z0iek(), p1: true));
		}
		if (p1.Multiline)
		{
			p0.z0yek("dc_multiline", p1.Multiline);
		}
		if (p1.AutoHeightForMultiline)
		{
			p0.z0yek("dc_autoheightformultiline", p1.AutoHeightForMultiline);
		}
		if (p1.Name != null && p1.Name.Length > 0)
		{
			p0.z0uek("dc_name", p1.Name);
		}
		if (p1.PrintTextForChecked != null && p1.PrintTextForChecked.Length > 0)
		{
			p0.z0uek("dc_printtextforchecked", p1.PrintTextForChecked);
		}
		if (p1.PrintTextForUnChecked != null && p1.PrintTextForUnChecked.Length > 0)
		{
			p0.z0uek("dc_printtextforunchecked", p1.PrintTextForUnChecked);
		}
		if (p1.PropertyExpressions != null && p1.PropertyExpressions.Count > 0)
		{
			p0.z0uek("dc_propertyexpressions", ((z0ZzZzcuk)p1.PropertyExpressions).DCWriteString());
		}
		if (p1.Requried)
		{
			p0.z0yek("dc_requried", p1.Requried);
		}
		if (p1.StringTag != null && p1.StringTag.Length > 0)
		{
			p0.z0uek("dc_stringtag", p1.StringTag);
		}
		if (p1.ToolTip != null && p1.ToolTip.Length > 0)
		{
			p0.z0uek("dc_tooltip", p1.ToolTip);
		}
		if (p1.ValueBinding != null)
		{
			p0.z0uek("dc_valuebinding", ((z0ZzZzcuk)p1.ValueBinding).DCWriteString());
		}
		if (p1.ValueExpression != null && p1.ValueExpression.Length > 0)
		{
			p0.z0uek("dc_valueexpression", p1.ValueExpression);
		}
		if (p1.VisualStyle != CheckBoxVisualStyle.Default)
		{
			p0.z0uek("dc_visualstyle", z0ZzZzzyk.z0eek(typeof(CheckBoxVisualStyle), p1.VisualStyle));
		}
	}

	internal string z0rek(Color p0)
	{
		return "1px solid " + z0uek(p0);
	}

	public float z0tek(float p0)
	{
		if (p0 <= 0f)
		{
			return 0f;
		}
		float num = z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, GraphicsUnit.Pixel);
		if (num == 0f)
		{
			num = 1f;
		}
		return num;
	}

	public new bool z0iek()
	{
		return z0rrk;
	}

	private void z0rek(XTextPieElement p0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["id"] = p0.ID;
		dictionary["name"] = p0.Name;
		dictionary["height"] = z0oek(p0.Height);
		dictionary["width"] = z0oek(p0.Width);
		dictionary["dc_showlegend"] = ((p0.PieDocumentStyle != null && p0.PieDocumentStyle.z0vek() != null) ? p0.PieDocumentStyle.z0vek().z0eek().ToString()
			.ToLower() : "true");
		dictionary["dc_thickness"] = ((p0.PieDocumentStyle != null) ? p0.PieDocumentStyle.z0rek().ToString() : "60");
		if (Options.ForPrint)
		{
			z0eek(p0, dictionary);
			return;
		}
		z0cek("img");
		z0uek("dctype", "XTextPieElement");
		if (dictionary != null)
		{
			foreach (string key in dictionary.Keys)
			{
				z0uek(key, dictionary[key]);
			}
		}
		z0yrk();
	}

	public void z0rek(z0ZzZzbdh p0)
	{
		z0crk = p0;
	}

	private void z0rek(XTextMedicalExpressionFieldElement p0)
	{
		p0.InnerSerializeText = p0.Text;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string[] array = p0.Text.Split(',');
		if (array.Length != 0)
		{
			MedicalExpressionValueList medicalExpressionValueList = new MedicalExpressionValueList();
			for (int i = 1; i <= array.Length; i++)
			{
				string p1 = "Value" + i;
				string p2 = array[i - 1];
				medicalExpressionValueList.Add(new z0ZzZzjuk(p1, p2));
			}
			dictionary["dc_innerserializetext"] = medicalExpressionValueList.DCWriteString();
		}
		z0eek(p0, dictionary);
	}

	private void z0rek(XTextCustomShapeElement p0)
	{
		z0rek((XTextElement)p0);
	}

	public void z0tek(XTextDocument p0)
	{
		z0ZzZzwrj z0ZzZzwrj2 = z0rek();
		if (z0ZzZzwrj2 == null)
		{
			z0ZzZzwrj2 = p0.z0suk().z0tek();
		}
		z0ZzZzfpk z0ZzZzfpk2 = p0.PageSettings.z0trk();
		if (z0ZzZzwrj2 != p0.z0suk().z0tek() || z0ZzZzfpk2 == null || z0ZzZzfpk2.z0mek() == null || z0ZzZzfpk2.z0mek().Length <= 0)
		{
			return;
		}
		int num = z0uek(z0ZzZzwrj2.z0urk() - z0ZzZzwrj2.z0xek());
		float num2 = z0ZzZzfpk2.z0yek().GetHeight() * (float)z0ZzZzfpk2.z0mek().Length;
		if (!((double)num > (double)num2 * 0.8))
		{
			return;
		}
		z0cek("div");
		z0uek("style", "height:1px");
		z0cek("table");
		z0uek("border", "0");
		base.z0oek();
		z0yek("color", z0uek(z0ZzZzfpk2.z0eek()));
		z0yek("text-align", "center");
		z0yek("width", "100%");
		z0yek("vertical-align", "middle");
		z0ZzZzimk p1 = z0ZzZzfpk2.z0yek();
		z0yek(p1, z0ZzZzfpk2.z0mek());
		((z0ZzZzfjh)this).z0zek();
		int num3 = z0uek(p0.PageSettings.z0prk());
		int num4 = z0uek(z0ZzZzwrj2.z0rrk());
		int num5 = (num4 - num3) / 2;
		bool flag = z0ZzZzfpk2.z0mek() == "line:/" || z0ZzZzfpk2.z0mek() == "line:\\";
		float num6 = (flag ? num : (num / z0ZzZzfpk2.z0mek().Length));
		int num7 = (flag ? 1 : z0ZzZzfpk2.z0mek().Length);
		for (int i = 0; i < num7; i++)
		{
			z0cek("tr");
			base.z0oek();
			z0yek("height", num6 + "px");
			((z0ZzZzfjh)this).z0zek();
			z0cek("td");
			z0cek("div");
			z0uek("style", "height:" + num6 + "px;width:" + num3 + "px;overflow:hidden");
			if (flag)
			{
				string text = ((int)num6 / 2).ToString();
				int num8 = (int)Math.Sqrt(num3 * num3 + num * num);
				int num9 = 0;
				if (num8 > num4)
				{
					num9 = (num8 - num4) / 2 + num5;
				}
				else if (num8 > num3)
				{
					num9 = (num8 - num3) / 2;
				}
				string text2 = ((int)(Math.Atan((double)num / (double)num3) * 180.0 / Math.PI)).ToString();
				string text3 = ((z0ZzZzfpk2.z0mek() == "line:/") ? ("-" + text2) : text2);
				string p2 = "<span style='display:inline-block;position:relative;top:" + text + "px;transform:rotate(" + text3 + "deg);width:" + num8 + "px;height:0;border-bottom:1px solid #000;left:-" + num9 + "'></span>";
				z0uek(p2);
			}
			else
			{
				z0yek(z0ZzZzfpk2.z0mek()[i].ToString());
			}
			((z0ZzZzfjh)this).z0xek();
			((z0ZzZzfjh)this).z0xek();
			((z0ZzZzfjh)this).z0xek();
		}
		((z0ZzZzfjh)this).z0xek();
		((z0ZzZzfjh)this).z0xek();
	}

	private void z0rek(XTextShapeInputFieldElement p0)
	{
		if (p0.EditMode)
		{
			z0tek(p0);
		}
		else
		{
			z0rek((XTextElement)p0);
		}
	}

	public new void z0oek()
	{
		z0kw();
		if (Options.ContentEncoding != null)
		{
			z0yek(Options.ContentEncoding);
		}
		foreach (XTextDocument item in z0zek())
		{
			item.z0juk();
		}
		if (Options.ViewStyle == (z0ZzZzlgh)0)
		{
			z0vek();
		}
	}

	private void z0rek(XTextFieldBorderElement p0)
	{
		XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)p0.z0ji();
		XTextInputFieldElement xTextInputFieldElement = xTextInputFieldElementBase as XTextInputFieldElement;
		if (z0drk != null && xTextInputFieldElement.ID != null && xTextInputFieldElement.ID.Length > 0 && z0drk.Contains(xTextInputFieldElement.ID))
		{
			if (z0yrk == null)
			{
				z0yrk = new JsonArray();
			}
			JsonObject jsonObject = new JsonObject();
			jsonObject.Add("ID", xTextInputFieldElement.ID);
			jsonObject.Add("Type", ((XTextElement)xTextInputFieldElement).z0qrk());
			jsonObject.Add("Width", ((XTextFieldElementBase)xTextInputFieldElement).z0jrk().Width);
			jsonObject.Add("Height", ((XTextFieldElementBase)xTextInputFieldElement).z0jrk().Height);
			jsonObject.Add("OwnerSubDocID", (((XTextElement)xTextInputFieldElement).z0iek() != null) ? ((XTextElement)xTextInputFieldElement).z0iek().ID : null);
			jsonObject.Add("OwnerTableID", (xTextInputFieldElement.z0gr() != null) ? xTextInputFieldElement.z0gr().ID : null);
			jsonObject.Add("OwnerPageIndex", xTextInputFieldElement.z0jr().z0suk()[xTextInputFieldElement.z0je()].z0vek());
			jsonObject.Add("TopInOwnerPage", ((XTextFieldElementBase)xTextInputFieldElement).z0jrk().z0fuk());
			jsonObject.Add("LeftInOwnerPage", ((XTextFieldElementBase)xTextInputFieldElement).z0jrk().z0mrk());
			z0yrk.Add(jsonObject);
		}
		string labelText = xTextInputFieldElementBase.LabelText;
		string unitText = xTextInputFieldElementBase.UnitText;
		DocumentViewOptions documentViewOptions = ((Options.DocumentOptions != null) ? Options.DocumentOptions.ViewOptions : new DocumentViewOptions());
		bool flag = documentViewOptions.FieldBorderPrintVisibility == DCRenderVisibility.Visible || (documentViewOptions.FieldBorderPrintVisibility == DCRenderVisibility.Default && !documentViewOptions.IgnoreFieldBorderWhenPrint);
		bool flag2 = documentViewOptions.FieldBorderPrintVisibility == DCRenderVisibility.Hidden;
		if (Options.ForPrint)
		{
			float num = 0f;
			if (p0.Width > p0.z0tek())
			{
				num = p0.Width;
			}
			if (p0 == ((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk())
			{
				if (!(num > 6f) && (labelText == null || labelText.Length <= 0) && (xTextInputFieldElementBase.StartBorderText == null || xTextInputFieldElementBase.StartBorderText.Length <= 0))
				{
					return;
				}
				string text = string.Empty;
				string text2 = string.Empty;
				if (labelText != null && labelText.Length > 0)
				{
					text = labelText;
				}
				if (xTextInputFieldElementBase.StartBorderText != null && xTextInputFieldElementBase.StartBorderText.Length > 0)
				{
					text2 = xTextInputFieldElementBase.StartBorderText;
					if (!flag)
					{
						if (!flag2)
						{
							text2 = string.Empty;
						}
						else
						{
							string text3 = string.Empty;
							for (int i = 0; i < text2.Length; i++)
							{
								text3 += " ";
							}
							text2 = text3;
						}
					}
				}
				string p1 = text2 + text;
				DocumentContentStyle documentContentStyle = xTextInputFieldElementBase.z0aek().z0yek();
				documentContentStyle.BorderWidth = 0f;
				documentContentStyle.BackgroundColor = Color.Empty;
				z0rek(p1, documentContentStyle.z0eek_jiejie20260327142557(), xTextInputFieldElementBase, num, p4: true);
			}
			else
			{
				if (p0 != ((XTextFieldElementBase)xTextInputFieldElementBase).z0tek() || (!(num > 6f) && (unitText == null || unitText.Length <= 0) && (xTextInputFieldElementBase.EndBorderText == null || xTextInputFieldElementBase.EndBorderText.Length <= 0)))
				{
					return;
				}
				string text4 = string.Empty;
				string text5 = string.Empty;
				if (unitText != null && unitText.Length > 0)
				{
					text4 = unitText;
				}
				if (xTextInputFieldElementBase.EndBorderText != null && xTextInputFieldElementBase.EndBorderText.Length > 0)
				{
					text5 = xTextInputFieldElementBase.EndBorderText;
					if (!flag)
					{
						if (!flag2)
						{
							text5 = string.Empty;
						}
						else
						{
							string text6 = string.Empty;
							for (int j = 0; j < text5.Length; j++)
							{
								text6 += " ";
							}
							text5 = text6;
						}
					}
				}
				string p2 = text4 + text5;
				DocumentContentStyle documentContentStyle2 = xTextInputFieldElementBase.z0aek().z0yek();
				documentContentStyle2.BorderWidth = 0f;
				documentContentStyle2.BackgroundColor = Color.Empty;
				if (Options.ForPrint)
				{
					num = 0f;
				}
				z0rek(p2, documentContentStyle2.z0eek_jiejie20260327142557(), xTextInputFieldElementBase, num, p4: true);
			}
			return;
		}
		float num2 = 0f;
		if (p0.Width > p0.z0tek())
		{
			num2 = p0.Width;
		}
		if (p0 == ((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk() && labelText != null && (num2 > 6f || (labelText != null && labelText.Length > 0) || (xTextInputFieldElementBase.StartBorderText != null && xTextInputFieldElementBase.StartBorderText.Length > 0)))
		{
			string text7 = string.Empty;
			string text8 = string.Empty;
			if (labelText != null && labelText.Length > 0)
			{
				text7 = labelText;
			}
			if (xTextInputFieldElementBase.StartBorderText != null && xTextInputFieldElementBase.StartBorderText.Length > 0)
			{
				text8 = xTextInputFieldElementBase.StartBorderText;
				if ((Options.DocumentOptions != null && Options.DocumentOptions.ViewOptions.IgnoreFieldBorderWhenPrint) || Options.DocumentOptions == null)
				{
					text8 = string.Empty;
				}
			}
			string text9 = text8 + text7;
			if (string.IsNullOrEmpty(text9) && Options.DocumentOptions != null && !Options.DocumentOptions.ViewOptions.IgnoreFieldBorderWhenPrint)
			{
				text9 = " ";
			}
			DocumentContentStyle documentContentStyle3 = xTextInputFieldElementBase.z0aek().z0yek();
			documentContentStyle3.BorderWidth = 0f;
			documentContentStyle3.BackgroundColor = Color.Empty;
			z0rek(text9, documentContentStyle3.z0eek_jiejie20260327142557(), xTextInputFieldElementBase, num2, p4: true);
		}
		if (p0 != ((XTextFieldElementBase)xTextInputFieldElementBase).z0tek() || unitText == null || (!(num2 > 6f) && (unitText == null || unitText.Length <= 0) && (xTextInputFieldElementBase.EndBorderText == null || xTextInputFieldElementBase.EndBorderText.Length <= 0)))
		{
			return;
		}
		string text10 = string.Empty;
		string text11 = string.Empty;
		if (unitText != null && unitText.Length > 0)
		{
			text10 = unitText;
		}
		if (xTextInputFieldElementBase.EndBorderText != null && xTextInputFieldElementBase.EndBorderText.Length > 0)
		{
			text11 = xTextInputFieldElementBase.EndBorderText;
			if ((Options.DocumentOptions != null && Options.DocumentOptions.ViewOptions.IgnoreFieldBorderWhenPrint) || Options.DocumentOptions == null)
			{
				text11 = string.Empty;
			}
		}
		string text12 = text10 + text11;
		if (string.IsNullOrEmpty(text12) && Options.DocumentOptions != null && !Options.DocumentOptions.ViewOptions.IgnoreFieldBorderWhenPrint)
		{
			text12 = " ";
		}
		DocumentContentStyle documentContentStyle4 = xTextInputFieldElementBase.z0aek().z0yek();
		documentContentStyle4.BorderWidth = 0f;
		documentContentStyle4.BackgroundColor = Color.Empty;
		z0rek(text12, documentContentStyle4.z0eek_jiejie20260327142557(), xTextInputFieldElementBase, num2, p4: true);
	}

	private void z0rek(XTextBarcodeFieldElement p0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["id"] = p0.ID;
		dictionary["name"] = p0.Name;
		dictionary["text"] = p0.Text;
		dictionary["barcodestyle"] = Enum.GetName(p0.BarcodeStyle.GetType(), p0.BarcodeStyle);
		dictionary["textalignment"] = Enum.GetName(p0.TextAlignment.GetType(), p0.TextAlignment);
		z0eek(p0, dictionary);
	}

	private void z0rek(XTextSectionElement p0)
	{
		z0cek("div");
		z0uek("id", p0.ID);
		z0uek("modified", "false");
		if (!z0qrk.Contains(p0))
		{
			z0uek("dctype", p0.GetType().Name);
		}
		if (p0.z0aek().z0auk >= 0 && !z0qrk.Contains(p0))
		{
			z0uek("dc_titlelevel", p0.z0aek().z0auk.ToString());
		}
		base.z0oek();
		z0rek(p0.z0aek(), p0);
		if (p0.z0tyk() && p0.z0jr().z0hi().ShowLogicDeletedContent)
		{
			z0rek(p0, p0.z0jr());
		}
		if (!p0.Visible && !z0lw())
		{
			z0yek("display", "none");
		}
		((z0ZzZzfjh)this).z0zek();
		if (!p0.Visible && z0lw())
		{
			z0uek("style", "display:none");
		}
		z0rek(p0.z0qt());
		z0tek(p0);
		((z0ZzZzfjh)this).z0xek();
		if (!z0qrk.Contains(p0))
		{
			z0qrk.Add(p0);
		}
	}

	public static void z0rek(z0ZzZzrjh p0, XTextImageElement p1)
	{
		if (p1.z0mrk())
		{
			p0.z0yek("dc_enablerepeatedimage", p1.z0mrk());
			p0.z0yek("dc_valueindexofrepeatedimage", p1.z0cek());
		}
		p0.z0rek("dc_printvisibility", p1.PrintVisibility, ElementVisibility.Visible);
		if (p1.z0jrk())
		{
			p0.z0yek("dc_additionshapefixsize", p1.z0jrk());
		}
		p0.z0iek("alt", p1.z0tek());
		p0.z0rek(p1.Attributes);
		p0.z0rek("dc_contentreadonly", p1.ContentReadonly, ContentReadonlyState.Inherit);
		p0.z0iek("dc_customadditionshapecontent", p1.z0yrk());
		if (!p1.Deleteable)
		{
			p0.z0yek("dc_deleteable", p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0yek("dc_enabled", p1.Enabled);
		}
		if (!p1.EnableEditImageAdditionShape)
		{
			p0.z0yek("dc_enableeditimageadditionshape", p1.EnableEditImageAdditionShape);
		}
		if (p1.z0wrk())
		{
			p0.z0yek("dc_innerhasnoimage", p1.z0wrk());
		}
		p0.z0iek("dc_innernativeimagesource", p1.z0srk());
		if (((XTextObjectElement)p1).z0iek() != null)
		{
			p0.z0uek("dc_linkinfo", z0ZzZzmik.z0rek(((XTextObjectElement)p1).z0iek(), p1: true));
		}
		p0.z0iek("dc_name", p1.Name);
		if (p1.PropertyExpressions != null && p1.PropertyExpressions.Count > 0)
		{
			p0.z0uek("dc_propertyexpressions", ((z0ZzZzcuk)p1.PropertyExpressions).DCWriteString());
		}
		if (!p1.SaveContentInFile)
		{
			p0.z0yek("dc_savecontentinfile", p1.SaveContentInFile);
		}
		if (!p1.SmoothZoom)
		{
			p0.z0yek("dc_smoothzoom", p1.SmoothZoom);
		}
		p0.z0iek("dc_stringtag", p1.StringTag);
		p0.z0iek("title", p1.z0vrk());
		if (p1.z0rek() != Color.Transparent)
		{
			p0.z0uek("dc_transparentcolor", p0.z0uek(p1.z0rek()));
		}
		p0.z0rek("dc_valign", p1.VAlign, VerticalAlignStyle.Bottom);
		p0.z0iek("dc_valueexpression", p1.ValueExpression);
	}

	private void z0rek(string p0, z0ZzZzrzj p1, bool p2 = false)
	{
		if (Options.ForPrint && p0 != null)
		{
			string[] array = p0.Split('，');
			string[] array2 = p0.Split('。');
			string[] array3 = p0.Split('：');
			string[] array4 = p0.Split('、');
			string[] array5 = p0.Split('（');
			string[] array6 = p0.Split('）');
			int num = array.Length + array2.Length + array3.Length + array4.Length + array5.Length + array6.Length - 6;
			if (num != 0)
			{
				base.z0oek();
				z0yek("letter-spacing", "-" + (double)Math.Abs(num) * 0.1);
				z0yek("display", "");
				((z0ZzZzfjh)this).z0zek();
			}
		}
		bool flag = true;
		if (p0.Contains(' ') && !z0ZzZzlcj.z0rek(p1, '袁'))
		{
			flag = false;
		}
		int length = p0.Length;
		int num2 = 0;
		for (int i = 0; i < length; i++)
		{
			char c = p0[i];
			switch (c)
			{
			case '\t':
				z0zek("ensp");
				z0zek("ensp");
				continue;
			case '\u00a0':
				if (num2 < i)
				{
					z0yek(p0.Substring(num2, i - num2));
				}
				num2 = i + 1;
				z0zek("nbsp");
				continue;
			case '\u2002':
				if (num2 < i)
				{
					z0yek(p0.Substring(num2, i - num2));
				}
				num2 = i + 1;
				if (p1.z0tyk.ToLower().Contains("himalaya"))
				{
					z0zek("thinsp");
				}
				else
				{
					z0zek("ensp");
				}
				continue;
			case '\u2003':
				if (num2 < i)
				{
					z0yek(p0.Substring(num2, i - num2));
				}
				num2 = i + 1;
				z0zek("emsp");
				continue;
			case '\u2009':
				if (num2 < i)
				{
					z0yek(p0.Substring(num2, i - num2));
				}
				num2 = i + 1;
				z0zek("thinsp");
				continue;
			case '\u200d':
				if (num2 < i)
				{
					z0yek(p0.Substring(num2, i - num2));
				}
				num2 = i + 1;
				z0zek("zwj");
				continue;
			case '\u200c':
				if (num2 < i)
				{
					z0yek(p0.Substring(num2, i - num2));
				}
				num2 = i + 1;
				z0zek("zwnj");
				continue;
			case ' ':
				if (num2 < i)
				{
					z0yek(p0.Substring(num2, i - num2));
				}
				num2 = i + 1;
				if (flag)
				{
					z0zek("ensp");
				}
				else
				{
					z0zek("nbsp");
				}
				continue;
			}
			if (!XTextCharElement.z0rek(c))
			{
				if (num2 < i)
				{
					z0yek(p0.Substring(num2, i - num2));
				}
				num2 = i + 1;
				z0yek("!");
			}
		}
		if (num2 == 0)
		{
			z0yek(p0);
		}
		else if (num2 < length)
		{
			z0yek(p0.Substring(num2, length - num2));
		}
	}

	private void z0rek(XTextLabelElement p0)
	{
		string text = ((XTextLabelElementBase)p0).z0eek(p0.z0jr().z0cmk());
		if (text != null && text.Length > 0)
		{
			DocumentContentStyle documentContentStyle = p0.z0aek().z0yek();
			switch (p0.Alignment)
			{
			case DCContentAlignment.BottomCenter:
				documentContentStyle.Align = DocumentContentAlignment.Center;
				break;
			case DCContentAlignment.BottomLeft:
				documentContentStyle.Align = DocumentContentAlignment.Left;
				break;
			case DCContentAlignment.BottomRight:
				documentContentStyle.Align = DocumentContentAlignment.Right;
				break;
			case DCContentAlignment.MiddleCenter:
				documentContentStyle.Align = DocumentContentAlignment.Center;
				break;
			case DCContentAlignment.MiddleLeft:
				documentContentStyle.Align = DocumentContentAlignment.Left;
				break;
			case DCContentAlignment.MiddleRight:
				documentContentStyle.Align = DocumentContentAlignment.Right;
				break;
			case DCContentAlignment.TopCenter:
				documentContentStyle.Align = DocumentContentAlignment.Center;
				break;
			case DCContentAlignment.TopLeft:
				documentContentStyle.Align = DocumentContentAlignment.Left;
				break;
			case DCContentAlignment.TopRight:
				documentContentStyle.Align = DocumentContentAlignment.Right;
				break;
			}
			documentContentStyle.Multiline = p0.Multiline;
			z0rek(text, documentContentStyle.z0eek_jiejie20260327142557(), p0, p0.AutoSize ? 0f : p0.Width);
			documentContentStyle.Dispose();
		}
	}

	public new string z0yek(float p0)
	{
		return z0tek(p0).ToString("0.00") + "px";
	}

	private void z0tek(XTextContainerElement p0)
	{
		z0rek(p0);
	}

	public void z0rek(XAttributeList p0)
	{
		if (p0 != null && p0.Count > 0)
		{
			z0uek("dc_attributes", z0ZzZzhjh.z0eek(p0, p1: true));
		}
	}

	private bool z0rek(XTextParagraphFlagElement p0)
	{
		if (p0.z0ke() is XTextParagraphElement)
		{
			return true;
		}
		XTextElement xTextElement = p0.z0ke();
		while (!(xTextElement is XTextParagraphElement) && xTextElement != null)
		{
			if (xTextElement is XTextCharElement)
			{
				if (!z0ZzZzqik.z0uek(((XTextCharElement)xTextElement).z0bek))
				{
					return false;
				}
				xTextElement = xTextElement.z0ke();
				continue;
			}
			return false;
		}
		return true;
	}

	private void z0rek(XTextLineBreakElement p0)
	{
		z0cek("br");
		base.z0oek();
		z0rek(p0, p0.z0jr());
		((z0ZzZzfjh)this).z0zek();
		z0yrk();
	}

	public new int z0uek(float p0)
	{
		if (p0 <= 0f)
		{
			return 0;
		}
		double num = z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, GraphicsUnit.Pixel);
		num = Math.Round(num);
		if (num == 0.0)
		{
			num = 1.0;
		}
		return (int)num;
	}

	public override void z0kw()
	{
		z0nek();
		z0bek("ds");
		z0uek(Options.IndentHtmlCode);
		base.z0kw();
	}

	private void z0rek(XTextMediaElement p0)
	{
		z0cek("table");
		base.z0oek();
		z0yek("width", z0uek(p0.Width) + "px");
		z0yek("height", z0uek(p0.Height) + "px");
		z0yek("border", "1px solid black");
		z0yek("background-color", "#dddddd");
		((z0ZzZzfjh)this).z0zek();
		z0cek("tr");
		z0cek("td");
		z0uek("align", "center");
		z0uek("valign", "middle");
		z0yek(p0.FileName);
		((z0ZzZzfjh)this).z0xek();
		((z0ZzZzfjh)this).z0xek();
		((z0ZzZzfjh)this).z0xek();
	}

	private void z0rek(z0ZzZzevj p0)
	{
		if (p0 == null)
		{
			return;
		}
		string text = null;
		string text2 = null;
		if (p0.DataSource != null && p0.DataSource.Length > 0)
		{
			text = p0.DataSource;
		}
		if (p0.BindingPath != null && p0.BindingPath.Length > 0)
		{
			if (!p0.BindingPath.Contains("/") && !p0.BindingPath.Contains("\\"))
			{
				text2 = p0.BindingPath;
			}
			else
			{
				string[] array = p0.BindingPath.Split('/', '\\');
				text = array[0];
				text2 = array[1];
			}
		}
		if (text != null && text.Length > 0)
		{
			z0uek("DataSourceName", text);
		}
		if (text2 != null && text2.Length > 0)
		{
			z0uek("DataSourcePath", text2);
		}
	}

	public string z0rek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		return "data:image/png;base64," + Convert.ToBase64String(p0);
	}

	private void z0tek(XTextElement p0)
	{
		z0iek("id", p0.ID);
	}

	public void z0rek(bool p0)
	{
		z0brk = p0;
	}

	private void z0rek(XTextCheckBoxElementBase p0)
	{
		z0nrk = Color.Transparent;
		p0.z0aek();
		z0tek(p0);
	}

	public void z0yek(XTextElement p0)
	{
	}

	private void z0rek(XTextTableCellElement p0, int p1, z0tgj p2)
	{
		bool forPrint = Options.ForPrint;
		z0cek("td");
		if (!z0irk)
		{
			if (p0.ID != null && p0.ID.Length > 0)
			{
				z0uek("id", p0.ID);
			}
			else
			{
				z0uek("id", p0.z0wyk());
			}
			z0uek("cid", p0.z0oek());
			if (!p0.z0yi() && !p0.z0drk().Visible && !forPrint)
			{
				z0uek("invisiblecolumn", "true");
			}
		}
		if (!forPrint)
		{
			z0ZzZzzej z0ZzZzzej2 = p0.z0ju();
			if (z0ZzZzzej2 != null)
			{
				z0uek("dc_cellgridline", z0ZzZzzej2.DCWriteString());
			}
		}
		if (Options.ForPrint)
		{
			z0rek(p0.Attributes);
		}
		z0iek("title", p0.ToolTip);
		if (p1 > 1)
		{
			z0yek("dc_rowspan", p1);
			XTextTableRowElement xTextTableRowElement = p0.z0krk();
			XTextElementList xTextElementList = xTextTableRowElement.z0gr().z0stk();
			int num = xTextElementList.IndexOf(xTextTableRowElement);
			for (int i = 1; i <= p1 && num + i < xTextElementList.Count; i++)
			{
				xTextTableRowElement = xTextElementList[num + i] as XTextTableRowElement;
			}
			z0yek("rowspan", p1);
		}
		if (!z0irk)
		{
			z0rek(p0.ValueBinding);
		}
		XTextTableElement xTextTableElement = p0.z0gr();
		XTextDocument xTextDocument = p0.z0jr();
		if (p0.ColSpan > 1)
		{
			int num2 = 0;
			XTextElementList xTextElementList2 = xTextTableElement.z0srk();
			int num3 = Math.Min(xTextElementList2.Count, p0.z0xek() + p0.ColSpan);
			for (int j = p0.z0xek(); j < num3; j++)
			{
				if (!xTextElementList2[j].Visible)
				{
					num2++;
				}
			}
			if (p0.ColSpan - num2 > 1)
			{
				z0yek("colspan", p0.ColSpan - num2);
			}
		}
		z0pok z0pok = new z0pok();
		z0pok.z0bek = p0.z0buk;
		z0pok.z0yek = !p0.z0yi() && !p0.z0drk().Visible && forPrint;
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		z0pok.z0vek = z0ZzZzrzj2.z0xrk;
		if (z0pok.z0vek != 0f && p2.z0yek != 0f)
		{
			z0pok.z0vek = 0f;
		}
		base.z0uek(0);
		z0tek(p0: true);
		z0pok.z0krk = p0.z0yi();
		if (z0pok.z0krk)
		{
			z0pok.z0cek = z0ZzZzrzj2.z0htk;
			if (z0pok.z0cek)
			{
				z0pok.z0nek = true;
			}
			else
			{
				bool flag = p0.z0xek() == 0;
				bool flag2 = p0.z0xek() + p0.ColSpan == xTextTableElement.z0srk().Count;
				bool flag3 = p0.z0pek() == 0;
				bool flag4 = p0.z0pek() + p0.RowSpan == xTextTableElement.z0stk().Count;
				if (!z0ZzZzrzj2.z0oek())
				{
					XTextTableCellElement xTextTableCellElement = p0.z0ark();
					if ((xTextTableCellElement != null && xTextTableCellElement.z0aek().z0tek()) || (flag && xTextTableElement.z0aek().z0oek()))
					{
						z0pok.z0tek = true;
					}
					else
					{
						z0pok.z0tek = z0ZzZzrzj2.z0oek();
					}
				}
				if (!z0ZzZzrzj2.z0iek())
				{
					XTextTableCellElement xTextTableCellElement2 = p0.z0yek();
					if ((xTextTableCellElement2 != null && xTextTableCellElement2.z0aek().z0uek()) || (flag3 && xTextTableElement.z0aek().z0iek()))
					{
						z0pok.z0iek = true;
					}
					else
					{
						z0pok.z0iek = z0ZzZzrzj2.z0iek();
					}
				}
				if (!z0ZzZzrzj2.z0tek())
				{
					XTextTableCellElement xTextTableCellElement3 = p0.z0qrk();
					if ((xTextTableCellElement3 != null && xTextTableCellElement3.z0aek().z0oek()) || (flag2 && xTextTableElement.z0aek().z0tek()))
					{
						z0pok.z0zek = true;
					}
					else
					{
						z0pok.z0zek = z0ZzZzrzj2.z0tek();
					}
				}
				if (!z0ZzZzrzj2.z0uek())
				{
					XTextTableCellElement xTextTableCellElement4 = p0.z0grk();
					if ((xTextTableCellElement4 != null && xTextTableCellElement4.z0aek().z0iek()) || (flag4 && xTextTableElement.z0aek().z0uek()))
					{
						z0pok.z0mek = true;
					}
					else
					{
						z0pok.z0mek = z0ZzZzrzj2.z0uek();
					}
				}
				if (!z0pok.z0tek || !z0pok.z0iek || !z0pok.z0zek || !z0pok.z0mek)
				{
					z0pok.z0nek = false;
				}
			}
		}
		z0pok.z0rek = p0.SlantSplitLineStyle;
		XTextTableCellElement xTextTableCellElement5 = p0.z0qrk();
		if (xTextTableCellElement5 != null && xTextTableCellElement5.z0aek().z0erk != 0f && xTextTableCellElement5.z0aek().z0nek != Color.Black)
		{
			z0pok.z0xek = true;
		}
		XTextTableCellElement xTextTableCellElement6 = p0.z0grk();
		XTextTableRowElement xTextTableRowElement2 = p0.z0krk();
		if (xTextTableCellElement6 != null && xTextTableCellElement6.z0aek().z0erk != 0f && xTextTableCellElement6.z0aek().z0myk != Color.Black && xTextTableRowElement2.z0je() == xTextTableRowElement2.z0juk())
		{
			z0pok.z0pek = true;
			if (Options.ForPrint && xTextTableRowElement2.z0xw() != null && xTextTableRowElement2.z0je() != ((XTextTableRowElement)xTextTableRowElement2.z0xw()).z0je())
			{
				z0pok.z0pek = false;
			}
		}
		bool flag5 = false;
		if (p2.z0rek != null && z0lw())
		{
			for (int num4 = p2.z0rek.Count - 1; num4 >= 0; num4--)
			{
				z0pok z0pok2 = p2.z0rek[num4];
				if (z0pok2.z0eek(z0pok))
				{
					z0lrk(z0pok2.z0oek);
					base.z0uek(z0pok2.z0uek);
					z0tek(z0pok2.z0lrk);
					flag5 = true;
					z0pok = z0pok2;
					break;
				}
			}
		}
		if (!flag5)
		{
			base.z0oek();
			if (z0pok.z0yek)
			{
				z0yek("display", "none");
			}
			RenderVisibility tableCellBorderVisibility = z0erk.TableCellBorderVisibility;
			int num5 = 2;
			bool flag6 = ((uint)tableCellBorderVisibility & (uint)num5) == (uint)num5;
			bool flag7 = Options.ForPrint && flag6;
			bool flag8 = Options.ForPrint && p0.z0krk().PrintCellBorder;
			bool p3 = flag7 && z0pok.z0nek && flag8;
			if (z0pok.z0krk && flag7)
			{
				float num6 = z0ZzZzrpk.z0eek(z0ZzZzrzj2.z0erk, GraphicsUnit.Document, GraphicsUnit.Pixel);
				if (num6 <= 1f)
				{
					num6 = 1f;
				}
				if (z0pok.z0cek)
				{
					string p4 = z0yek((int)num6, z0ZzZzrzj2.z0nek, z0ZzZzrzj2.z0guk);
					z0yek("border", p4);
				}
				else
				{
					Color color = (Options.ForPrint ? Color.Transparent : z0erk.NoneBorderColor);
					if (!z0pok.z0tek && !z0pok.z0iek && !z0pok.z0zek && !z0pok.z0mek)
					{
						z0yek("border", z0rek(color));
					}
					else if (!z0pok.z0tek || !z0pok.z0iek || !z0pok.z0zek || !z0pok.z0mek)
					{
						z0yek("left", z0pok.z0tek ? z0ZzZzrzj2.z0nek : color, (int)num6, z0ZzZzrzj2.z0guk);
						z0yek("top", z0pok.z0iek ? z0ZzZzrzj2.z0myk : color, (int)num6, z0ZzZzrzj2.z0guk);
						z0yek("right", z0pok.z0zek ? z0ZzZzrzj2.z0grk : color, (int)num6, z0ZzZzrzj2.z0guk);
						z0yek("bottom", z0pok.z0mek ? z0ZzZzrzj2.z0trk : color, (int)num6, z0ZzZzrzj2.z0guk);
					}
				}
			}
			z0rek(z0ZzZzrzj2, p0, p3);
			z0tek(p0: false);
			if (z0pok.z0rek != RectangleSlantSplitStyle.None)
			{
				float p5 = z0ZzZzrpk.z0eek(p0.Height, GraphicsUnit.Document, GraphicsUnit.Pixel);
				float p6 = z0ZzZzrpk.z0eek(p0.Width, GraphicsUnit.Document, GraphicsUnit.Pixel);
				string p7 = z0pok.z0rek.ToString();
				string p8 = z0uek(p0.z0aek().z0rtk);
				if (Options.DocumentOptions != null && Options.DocumentOptions.ViewOptions.BothBlackWhenPrint && Options.ForPrint)
				{
					p8 = "black";
				}
				string p9 = z0ZzZzroj.z0eek(p7, p6, p5, p8);
				z0iek(p9, p1: false);
				z0yek("background-repeat", "round");
			}
			z0pok.z0oek = ((z0ZzZzfjh)this).z0zek();
			z0pok.z0uek = base.z0pek();
			z0pok.z0lrk = z0bek();
			if (p2.z0rek != null)
			{
				p2.z0rek.Add(z0pok);
			}
		}
		if (!Options.ForPrint)
		{
			z0yek(p0);
		}
		int num7 = base.z0pek();
		if (forPrint)
		{
			z0ZzZzndh p10 = z0ZzZzndh.z0eek(new z0ZzZzbdh(p2.z0uek + p0.z0it(), p2.z0eek, p0.Width, p0.Height));
			if (p0.RowSpan > 1)
			{
				p10 = z0ZzZzndh.z0yek(p0.z0qyk());
			}
			float num8 = p0.z0si();
			float num9 = 0f;
			if (!z0jrk.z0vek())
			{
				z0ZzZzndh z0ZzZzndh2 = z0ZzZzndh.z0tek(z0jrk, p10);
				if (Math.Abs(z0ZzZzndh2.z0oek() - p10.z0oek()) >= 2)
				{
					num8 = (float)z0ZzZzndh2.z0oek() - z0ZzZzrzj2.z0quk - z0pok.z0vek;
					num9 = 3.125f;
				}
			}
			bool flag9 = p0.z0fi();
			if (!flag9 && (p0.z0ju() != null || xTextDocument.z0wpk() != null))
			{
				flag9 = true;
			}
			if (flag9)
			{
				if (((XTextContentElement)p0).z0hrk() < num8 - 10f || p0.MirrorViewForCrossPage)
				{
					bool flag10 = false;
					if (z0hrk.ForPrint && p0.MirrorViewForCrossPage)
					{
						flag10 = p0.z0rek(z0rek(), delegate
						{
							z0rek(p0);
						}, null);
					}
					if (!flag10)
					{
						z0tek(p0);
					}
				}
				else if (num8 == p0.z0si() && num9 == 0f && base.z0pek() == 0)
				{
					z0rek(p0);
				}
				else
				{
					z0cek("div");
					float p11 = (float)Math.Ceiling(z0tek(num8 - num9) - (float)num7);
					if (!z0vrk || p0.GridLine == null || p0.z0cr() == VerticalAlignStyle.Top)
					{
						z0uek("style", "height:" + base.z0uek(p11));
					}
					z0rek(p0);
					((z0ZzZzfjh)this).z0xek();
				}
			}
		}
		else
		{
			z0ZzZzlgh viewStyle = z0hrk.ViewStyle;
			if (viewStyle == (z0ZzZzlgh)0 || viewStyle == (z0ZzZzlgh)1)
			{
				z0rek((XTextContainerElement)p0);
			}
			else
			{
				z0tek(p0);
			}
		}
		((z0ZzZzfjh)this).z0xek();
	}

	private void z0rek(float p0, Color p1, DashStyle p2, float p3)
	{
		z0cek("div");
		base.z0oek();
		z0yek("height", base.z0uek(p0));
		z0yek("border-bottom-color", z0uek(p1));
		z0yek("border-bottom-style", z0ZzZzfjh.z0yek(p2));
		z0yek("border-bottom-width", base.z0uek(p3));
		((z0ZzZzfjh)this).z0zek();
		((z0ZzZzfjh)this).z0xek();
	}

	static z0ZzZzrjh()
	{
		z0prk = Color.Black.ToArgb();
		z0urk = "&zwnj;";
		z0wrk = new XTextElementList();
		z0nrk = Color.Transparent;
	}

	private void z0rek(XTextElement p0, int p1 = 0)
	{
		if (p1 > 0)
		{
			z0ktk += p1;
			if (z0ktk < 100)
			{
				return;
			}
			z0ktk = 0;
		}
		int num = p0.z0je();
		if (num >= 0)
		{
			z0uek("dcopi", z0ZzZzqik.z0rek(num));
		}
	}

	private void z0rek(XTextCheckBoxElementBase p0, string p1)
	{
		string text = "iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAYAAABV7bNHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAFHGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDUgNzkuMTYzNDk5LCAyMDE4LzA4LzEzLTE2OjQwOjIyICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOmRjPSJodHRwOi8vcHVybC5vcmcvZGMvZWxlbWVudHMvMS4xLyIgeG1sbnM6cGhvdG9zaG9wPSJodHRwOi8vbnMuYWRvYmUuY29tL3Bob3Rvc2hvcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ0MgMjAxOSAoV2luZG93cykiIHhtcDpDcmVhdGVEYXRlPSIyMDE5LTA3LTE1VDE4OjM0OjE1KzA4OjAwIiB4bXA6TW9kaWZ5RGF0ZT0iMjAxOS0wNy0xNVQxODo0MjozNyswODowMCIgeG1wOk1ldGFkYXRhRGF0ZT0iMjAxOS0wNy0xNVQxODo0MjozNyswODowMCIgZGM6Zm9ybWF0PSJpbWFnZS9wbmciIHBob3Rvc2hvcDpDb2xvck1vZGU9IjMiIHBob3Rvc2hvcDpJQ0NQcm9maWxlPSJzUkdCIElFQzYxOTY2LTIuMSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo4MjgxODAzOS05M2I5LTY5NDgtYjA5ZC1mYzAyMjYxMzM1MzkiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6ODI4MTgwMzktOTNiOS02OTQ4LWIwOWQtZmMwMjI2MTMzNTM5IiB4bXBNTTpPcmlnaW5hbERvY3VtZW50SUQ9InhtcC5kaWQ6ODI4MTgwMzktOTNiOS02OTQ4LWIwOWQtZmMwMjI2MTMzNTM5Ij4gPHhtcE1NOkhpc3Rvcnk+IDxyZGY6U2VxPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0iY3JlYXRlZCIgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDo4MjgxODAzOS05M2I5LTY5NDgtYjA5ZC1mYzAyMjYxMzM1MzkiIHN0RXZ0OndoZW49IjIwMTktMDctMTVUMTg6MzQ6MTUrMDg6MDAiIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCBDQyAyMDE5IChXaW5kb3dzKSIvPiA8L3JkZjpTZXE+IDwveG1wTU06SGlzdG9yeT4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz7qA7ItAAAFAklEQVR42u2crU8cQRTA+QuKJv0DmiAr0Ji6M7VVmLqKlcVUYJoGCQkK0yZISBWmTXCbsySrsFgs9rq/yw6d25v3Zub243ZnEaO4vdv58b7nvdlZLBY7fa7Hx8d39/f3h3d3d59ubm4y1vn5+cXp6emv4+PjP6yTk5Pfl5eXP66urr7d3t5+ZvHM09PTXt/v28uPPDw8vGeTQMiyLC/XYsOVAxOofOdoAT0/P79hA2wEaWgIRYTFQsqQrtEAAkwlKYseV85vzufz2WABWWDynuGsgWpToloBg0HdMpg1ULxTG0a90cN4IrxO5MsXpaH9Wdqnr+XzR6wS8kHp3fZL27XLKjf2tpSCD6XKfCyN+xcWz/BsLCicQ++AMMIYx1CpKSHO2SAwANHA+O/yHaV0nFWwilDP1xsg4FQq5QVT2oNrNsTGuvAwSFnpJf8GgFrapk1ULtreVG7bKzFdgnGo+lEIKMxBbPzUqr3pG4wLFO/gk6aYcCA4PfDBwcZsC0zdTgUY9DxUkrwfQG89alXgkYYAx168kwaJf3iITfIaZDyAT6WGBKauchok/vGNAFWuXISDFxkqHMs87Ct2yRsCqEZZinPGAseGpEhSTlIdBchjlIshq5UWM2mQ2HMwIC0QxPiNDY5lMr5LkAgkgwDh/iTVGoorb7KqEMApRa4qgOsLLiS7M3Y4Jk6qou4gr1bX00NJesioxw7HLKoEgqqtRdkrD0qVQIinID32kqQI5+QEpEnPGL1WA6+2IkVez5Wi9Fgac+3aMyzWAEn5FvqaIhzNFtlq9hIYutQrFc+lLSENecn2lx+ibiuI2lnKcKzgcW3v5KEvgCTvlaJxFtRM9GaieqGbnC6kDggTInkz6kUQnEkF99Th+NIPKhqmrJFUUhq7yBJEQJKBTim12NQOUScSq4Ypxz9CVO0MGMUIekwVwxb6Cw6E8s6FGEFPwYPVPJnT1b8CUlz9EpBUe049xagvKRYSo+gmXRhjW2iLCxDaJZZYMVxTAVQdCzkL+RzRZlPNw3xxECHQK6D/R9TuQFFKNaYUSUuAyDJMLXrSyWrV0ufKJmbLDo6plzu0qqJaj56CHZLyMHOIaJqNsqmWXCX1Mh0f6pkYopc6IOkA0ZzT29V9V8pRpFz2kA4PYYFtXgEk1YUgPLVSq/PgUDl6TlKKtIYq59Gz5s1StEXSsTMMjHrFtL8kJUVK+8uyUK82UEnlj1SkiMAwVHpiW/CWY0ypxj3SiEJsE2cx5vMyrbFc6pcWxw+UWbBR2iPN7mizG9qsQ6ZBGlNJ1tNtv4huJA/pl+YHxwCJd5TSCRMU1g1z1DCLZ8R70OpGMKhJDnvT4ASNQ/EFnlmxYojVx6ohQR2HksYPogfqtO77oYUAxDnayIHWVd9oJFNrEzaQEOdtqRxgrCFfdW619ZFMW5IC5uQLItU+QXGGJ0XHdTixtzJscgq5F3gFRaegkBgLTBEwot79WLgjBAi5WGB5AQAhflNYRo2wMQHTzStRss9bdXI1hSeYVGHhZQDGhpEEc4JirqYgfuFvpAd8FkmJgWJPE24Kp5XLTXCV1fl+08tNiojrJoKuowhx471dj4Px6/AypeA1uOtxHEnhbBug8FAUu5qoU693mAHKMuR5V1BQpS7A9HrJGyLf0n1mOVDMJW9dQekdUD3YRLronGCjSBlSYOCZawKxJfyNz/BZpKQNoxu7/gFRHwKRvpVU4wAAAABJRU5ErkJggg==";
		string text2 = "iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAYAAABV7bNHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAFHGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDUgNzkuMTYzNDk5LCAyMDE4LzA4LzEzLTE2OjQwOjIyICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOmRjPSJodHRwOi8vcHVybC5vcmcvZGMvZWxlbWVudHMvMS4xLyIgeG1sbnM6cGhvdG9zaG9wPSJodHRwOi8vbnMuYWRvYmUuY29tL3Bob3Rvc2hvcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ0MgMjAxOSAoV2luZG93cykiIHhtcDpDcmVhdGVEYXRlPSIyMDE5LTA3LTE1VDE4OjMzOjU4KzA4OjAwIiB4bXA6TW9kaWZ5RGF0ZT0iMjAxOS0wNy0xNVQxODo0MzoxMSswODowMCIgeG1wOk1ldGFkYXRhRGF0ZT0iMjAxOS0wNy0xNVQxODo0MzoxMSswODowMCIgZGM6Zm9ybWF0PSJpbWFnZS9wbmciIHBob3Rvc2hvcDpDb2xvck1vZGU9IjMiIHBob3Rvc2hvcDpJQ0NQcm9maWxlPSJzUkdCIElFQzYxOTY2LTIuMSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo0NjRiNzRmYi1hODE5LTJhNDEtOTMwZS04NTJkNmQwOWYyNWIiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6NDY0Yjc0ZmItYTgxOS0yYTQxLTkzMGUtODUyZDZkMDlmMjViIiB4bXBNTTpPcmlnaW5hbERvY3VtZW50SUQ9InhtcC5kaWQ6NDY0Yjc0ZmItYTgxOS0yYTQxLTkzMGUtODUyZDZkMDlmMjViIj4gPHhtcE1NOkhpc3Rvcnk+IDxyZGY6U2VxPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0iY3JlYXRlZCIgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDo0NjRiNzRmYi1hODE5LTJhNDEtOTMwZS04NTJkNmQwOWYyNWIiIHN0RXZ0OndoZW49IjIwMTktMDctMTVUMTg6MzM6NTgrMDg6MDAiIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCBDQyAyMDE5IChXaW5kb3dzKSIvPiA8L3JkZjpTZXE+IDwveG1wTU06SGlzdG9yeT4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz50Cg5VAAAHT0lEQVR42tWcW0gkRxSGl7wEwpKwBAJ5CKwSVHAIRIlGMGYRWYUMa0BEWcSgaAhecAiK+rKy+qJIiAR1CEFRFFmhUQcUQSOIoIMxCBEJii6CeCEQMSreHqTT/zAt7dhV3VVdffHhPDljd31zbnXqnHoky/IjJ2Vvby9xbW3t2fz8/Mvx8fEApLu7O9jZ2TnU3Nz8O6S1tTXU19fXMTIy8mp6eroSgu8cHR197PT72v6Ai4uL97e2tlKwSEAIBAJhRWROCQMmoOJ/PlhAKhRoADTCAhAqLAiesby87H8wgAAmqimygxLGM+0AZQeYsMNwbAUlBAwcqstg7oHCO4lw6pa+jEjE4WMkxdG2KY62TPn+C4gC2adEt3jFdz2GKAv7SIlaXyqakK049yIIvoPvsoJCcHAcEJwwnKNZrVEgDmGBgAEQFpz/Y/wPRTsao7Aks5HPMUCAEzUpQzCKP/gJC8LC7Igw0DIlZ/rVBKiIb+IxOWZ/gyTOjMbYCUbH1F+YAQV3wJo/CfU3ToPRA4V3MNImlihnentgBAc+xi0wsX7KhEMPm9Ukww/Abg3MSkJE8gIcreCdaJDwg5vxSYYOGRHAyKS8BCbW5GiQ8MNbAhQN5UQ4iCJehaNxD/EUv2SYAlCdMinPeShwtJAomhRGdYAJkIFTlrxsVrSciQYJazYNiJYIwvnZsYDj4+MPNzY2Pj88PPzk5ubmHTueobiMWhIkJJKmACH8kUxLVCg/OTl5MjY2VlFTUxPKysr6JzExUY6Li7sjaWlpZ4WFhavBYPDV5ubmZ6IgRVMAXS1C1dIQEClqwe9YhbO6uvpVRUXFbCwMM5Kbm7szOjr6g4g8KZp1m4pqsXb6jKQ92FHzvtTOzk5iQ0PDGx4wsZKfn//3zMxMoRVIqBIQTO1eln3ni6RKIIjzas/k5GRJQkKCLAKOVvBOViCRtAjBSRcQTXt4o1Zvb+9r0WC0AnM9PT19Ijiq3dEiw8jFqz3t7e2/2AlHFb/fv3F1dfUeDySUY/TWDBb3AJH2W7BXnnDqBBxVqqqqJkX6Iq2Z3SaGeubFE7kWFxefOwlHFWgsDyTCNuR2tx/5EOq2BFVrZH0gVN4NQJCVlZWvOZPHe2vHPvQWECl6sTpnp00rVsrKyuY5zYwYzYjmBdvE6QLLwzIzM/91ExBkdna2gDVxJEUz1ItA0E8quLMWqNyGo4Z+UdsPVDTUsoblTWltbW3IC4Di4+Ply8tLprCPXQIREMlBs24tkpOTZS8AgkxNTb0U4YdQJyJWDVnyn4WFhW+8AgdSX1//hiOr1k0YiRk0S8VQkqTvvQSotLR0gfG8z0co7wSJGTRLBOvp6XntJUB5eXlvOSKZbqgXAqilpeU3LwFKSUm5EhHqI4BItWeWLQbSdS8B8vl8MmuoJ+VCxCyapQujq6ur3UuAsrOz91jgwFr0AMG6iCVWOK6HssWIleLi4j84joV0C/nIgANW92Fzc3PfeglQXV3duIg8CCmQEEA4svESoOHh4QDHEbV+okjaarBm0iUlJYteAXRwcPBUBCDsMtRatOXNan9/f6MX4BQUFPzFGsGiLX16uwl/pINDRLljf3//qRcADQwMNLDmQLSqIrUezVowg9a5CQeHi5ynG8RDRLWWExBRcsWvgSzWLUChUOg7UealdnxQz+OheqwPHBwc/NENOJWVlbMiDxDVc3qjYx+J59inra0t6LRpnZ2dfSDq8BDbL/jmO4BIdSHeI178ok7ASUpKktfX178Q2emhe3BIOXrm0qLr6+t3q6urJ+2Ek5GR8V84HM4R3VCle/RMi2Y8vkiVjo6On+2AU1RU9CdSC973Ih07g4FqXiztL1xapAqapXJycnZFwQF0m9pfIoV6agMVqfxhRYu0ITU1NZU7DWhqahra3d391GoDlVntYW3Bi4wxWYWE/kMc7gF4enr6mRGU8vLyOWw+WfdXrHkPaUSBtYlTEt3EiVoMWvOwOUYONTExUba0tPR8e3vbd35+LrR7n9ZYTuqXJo4fUGbBLPkjt4Tmd2izG7Sj5AANkpXBOI9128vMjeRm+qXxwIcACe9I2k6oSWGsY2YaZjEY8fa0uSEZpGkO1kaDY2ocCv/AYFZMstIibJdEGxKo41Ck8QPmgTpa973IFEDUQB1t5IDWVW9pJJPWJqxCgjq7ZXIAoxnypc6tCh/J1GqSiTl5CZmqk6BwhkfKjmPhmNUc7rFw5Egmr6CwFRQ0RgNGMjGibv9YuE4KYOZigcgFAEjxrcJSzQg+xsR0850s2Sha2XI1hUEySYWFKANgWDA0QT1BUa+mQP6Cv2F7gM9CU1igaKcJeeEIudwEoTJ6vm/1chOJ4boJU9dRmAnjjl2PA+cXLbi5egsMfA2rI3b0giWEUDdAIUKh2GXFnBy9wwygNI48bBcUmJIdYBy75E01PzhLAZoVBhT1kje7oDgOKDbZhHahcwILhZZBC1R46jWB8CX4Gz6Dz0JLRDhdVvkfOcxdM0UT96MAAAAASUVORK5CYII=";
		string text3 = "iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAYAAABV7bNHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAFHGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDUgNzkuMTYzNDk5LCAyMDE4LzA4LzEzLTE2OjQwOjIyICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOmRjPSJodHRwOi8vcHVybC5vcmcvZGMvZWxlbWVudHMvMS4xLyIgeG1sbnM6cGhvdG9zaG9wPSJodHRwOi8vbnMuYWRvYmUuY29tL3Bob3Rvc2hvcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ0MgMjAxOSAoV2luZG93cykiIHhtcDpDcmVhdGVEYXRlPSIyMDE5LTA3LTE1VDE4OjM1OjA4KzA4OjAwIiB4bXA6TW9kaWZ5RGF0ZT0iMjAxOS0wNy0xNVQxODo0MDoyNCswODowMCIgeG1wOk1ldGFkYXRhRGF0ZT0iMjAxOS0wNy0xNVQxODo0MDoyNCswODowMCIgZGM6Zm9ybWF0PSJpbWFnZS9wbmciIHBob3Rvc2hvcDpDb2xvck1vZGU9IjMiIHBob3Rvc2hvcDpJQ0NQcm9maWxlPSJzUkdCIElFQzYxOTY2LTIuMSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDphYmI2YTM5Yi03OTRjLTUzNDgtOGI1NC04YWZkMjFmOGIwYTgiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6YWJiNmEzOWItNzk0Yy01MzQ4LThiNTQtOGFmZDIxZjhiMGE4IiB4bXBNTTpPcmlnaW5hbERvY3VtZW50SUQ9InhtcC5kaWQ6YWJiNmEzOWItNzk0Yy01MzQ4LThiNTQtOGFmZDIxZjhiMGE4Ij4gPHhtcE1NOkhpc3Rvcnk+IDxyZGY6U2VxPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0iY3JlYXRlZCIgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDphYmI2YTM5Yi03OTRjLTUzNDgtOGI1NC04YWZkMjFmOGIwYTgiIHN0RXZ0OndoZW49IjIwMTktMDctMTVUMTg6MzU6MDgrMDg6MDAiIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCBDQyAyMDE5IChXaW5kb3dzKSIvPiA8L3JkZjpTZXE+IDwveG1wTU06SGlzdG9yeT4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz6TqFVgAAAAkElEQVR42u3csQkAIAxFwYycTRw5NpYKFoKCVzxIfUXKH5nZtC7GUZoGCBCgO0C/PuV9oKqKnwIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIE6BSQcRPzOPaDAAF6B0iLOtn0atr8v5gOAAAAAElFTkSuQmCC";
		string text4 = "iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAYAAABV7bNHAAAACXBIWXMAAAsTAAALEwEAmpwYAAAFFmlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDUgNzkuMTYzNDk5LCAyMDE4LzA4LzEzLTE2OjQwOjIyICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOmRjPSJodHRwOi8vcHVybC5vcmcvZGMvZWxlbWVudHMvMS4xLyIgeG1sbnM6cGhvdG9zaG9wPSJodHRwOi8vbnMuYWRvYmUuY29tL3Bob3Rvc2hvcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgQ0MgMjAxOSAoV2luZG93cykiIHhtcDpDcmVhdGVEYXRlPSIyMDE5LTA3LTE1VDE4OjM1KzA4OjAwIiB4bXA6TW9kaWZ5RGF0ZT0iMjAxOS0wNy0xNVQxODo0MTozNCswODowMCIgeG1wOk1ldGFkYXRhRGF0ZT0iMjAxOS0wNy0xNVQxODo0MTozNCswODowMCIgZGM6Zm9ybWF0PSJpbWFnZS9wbmciIHBob3Rvc2hvcDpDb2xvck1vZGU9IjMiIHBob3Rvc2hvcDpJQ0NQcm9maWxlPSJzUkdCIElFQzYxOTY2LTIuMSIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo5ZGEzMjhiYy1kYmRlLTcyNDctOTAxNy1mMWNkYWU3YTE2N2QiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6OWRhMzI4YmMtZGJkZS03MjQ3LTkwMTctZjFjZGFlN2ExNjdkIiB4bXBNTTpPcmlnaW5hbERvY3VtZW50SUQ9InhtcC5kaWQ6OWRhMzI4YmMtZGJkZS03MjQ3LTkwMTctZjFjZGFlN2ExNjdkIj4gPHhtcE1NOkhpc3Rvcnk+IDxyZGY6U2VxPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0iY3JlYXRlZCIgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDo5ZGEzMjhiYy1kYmRlLTcyNDctOTAxNy1mMWNkYWU3YTE2N2QiIHN0RXZ0OndoZW49IjIwMTktMDctMTVUMTg6MzUrMDg6MDAiIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCBDQyAyMDE5IChXaW5kb3dzKSIvPiA8L3JkZjpTZXE+IDwveG1wTU06SGlzdG9yeT4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz5GlJ7gAAACmUlEQVR42u2crW7DQAyA+xTjJaORxiuNdw8wFU8qDSkbKxwInoon5QE6Xmm4YLQkvC+RzlJSZWnucj++89UxsLaBSdEXf/adL8ksz/NCQh2z5pdaYjAEkAASQDSAplqUzQHVdT2bUgggASSABBBmnE6nx/P5/CCAFLFarb4Wi8XP8Xh8EkC92O12b/P5vPqLGn7C3wKoo1aWZb8NnDaq9Xr9qVNuMoBArR6ca+iUmwSgnlqqGFSOPSCFWkpIfeXYA9KppVOuhcQakKFaNwFZxD6DLNW6BvzPJBRzUQuybb/fv7Av0hhqsQWEpRZbQFhqsQSEqRY7QNhqsQOErRYrQCHUYgMolFpsAIVSKxggm3lvymoFAdSme1mWr6mq1d2pRwe0XC6/2xTebrfvKap1OByeSY59AEgv3avNZvMRQjlXtVxuGgogUEp1wZBVmJBiqYUGCIbdYxdscw6ViloogOCOdOrO6LrDF1JMtVAAQY2xvZOuHc4kUzHV8gakqztjkIqiyG0v1DRTsdTyAgR30xHOvw5nepEANLZaXoAGWroTJJMO53ozfNWiVOxmGaAr3lRqoRRp2PC5FE7TDkepVtR1kEuHo1YLdSVtsx4yfYCAWi30vRhAala53sUbsoBarWDzoGbxWCFkE6laQSeKrlsCn6zDViv4yBUKLlLxJlErykwascNFVyva0B4gIXW4qGpFPdXoLAOqe1GL5NgHs8OFVovsXMx1+xBbLdKDQ9+Nbgy1yE9WIQMoJoR39bYPdLhmW2GsFtbw/27e9rHY6DqNalm8LwaQxjocQJz8C3WaUW50tZJ9/GWgw5GolfTzQd1RLpVayT9ABUrBAI5KLXnrWQAJoDQBycdN5PM48v0gASSA0gEkoYgLgpicJWDsYP4AAAAASUVORK5CYII=";
		if (p0.PrintVisibility == ElementVisibility.None)
		{
			return;
		}
		z0cek("span");
		z0lrk("checkelementbox");
		if (!z0irk && p0.StringTag != null && p0.StringTag.Length > 0)
		{
			z0uek("dc_stringtag", p0.StringTag);
		}
		base.z0oek();
		z0ZzZzimk z0ZzZzimk2 = p0.z0aek().z0pek.Clone();
		z0ZzZzimk2.Name = "Wingdings";
		z0yek(z0ZzZzimk2, null);
		if (p0.z0aek().z0bek.A != 0)
		{
			if (p0.PrintVisibility == ElementVisibility.Hidden || (p0.PrintVisibilityWhenUnchecked != PrintVisibilityModeWhenUnchecked.Visible && !p0.Checked))
			{
				z0yek("color", z0uek(Color.Transparent));
			}
			else
			{
				z0yek("color", z0uek(p0.z0aek().z0bek));
			}
		}
		if (!z0rek(p0, p0.z0jr()) && p0.CheckedUserHistories != null && p0.CheckedUserHistories.Count > 0)
		{
			DocumentSecurityOptions documentSecurityOptions = p0.z0hi();
			if (documentSecurityOptions != null && documentSecurityOptions.ShowPermissionMark)
			{
				z0yek("border", "1px solid " + z0uek(Color.Red));
				z0yek("background-color", "yellow");
			}
		}
		((z0ZzZzfjh)this).z0zek();
		if (!z0irk)
		{
			z0rek(p0.z0qt());
		}
		p0.z0oi();
		char c = '\0';
		string text5 = null;
		if (p0.z0lrk() == CheckBoxVisualStyle.CheckBox || p0.z0lrk() == CheckBoxVisualStyle.SystemCheckBox)
		{
			if (p0.Checked)
			{
				c = '\uf0fe';
				text5 = text4;
			}
			else
			{
				c = '\uf06f';
				text5 = text3;
			}
		}
		else if (p0.Checked)
		{
			c = '\uf0a4';
			text5 = text2;
		}
		else
		{
			c = '\uf0a1';
			text5 = text;
		}
		if (!Options.PrintImgCheckBox)
		{
			base.z0yek(c);
		}
		else
		{
			z0cek("img");
			z0uek("src", "data:image/png;base64," + text5);
			z0uek("width", "16px");
			z0uek("height", "16px");
			z0yrk();
		}
		((z0ZzZzfjh)this).z0xek();
	}

	public void z0rek(z0ZzZzwrj p0)
	{
		z0krk = p0;
	}

	private void z0rek(XTextStringElement p0)
	{
		if (p0.z0ji() is XTextInputFieldElement && Options.ForPrint)
		{
			XTextInputFieldElement xTextInputFieldElement = p0.z0ji() as XTextInputFieldElement;
			if (z0drk != null && xTextInputFieldElement.ID != null && xTextInputFieldElement.ID.Length > 0 && z0drk.Contains(xTextInputFieldElement.ID))
			{
				if (z0yrk == null)
				{
					z0yrk = new JsonArray();
				}
				JsonObject jsonObject = new JsonObject();
				jsonObject.Add("ID", xTextInputFieldElement.ID);
				jsonObject.Add("Type", ((XTextElement)xTextInputFieldElement).z0qrk());
				jsonObject.Add("Width", ((XTextFieldElementBase)xTextInputFieldElement).z0jrk().Width);
				jsonObject.Add("Height", ((XTextFieldElementBase)xTextInputFieldElement).z0jrk().Height);
				jsonObject.Add("OwnerSubDocID", (((XTextElement)xTextInputFieldElement).z0iek() != null) ? ((XTextElement)xTextInputFieldElement).z0iek().ID : null);
				jsonObject.Add("OwnerTableID", (xTextInputFieldElement.z0gr() != null) ? xTextInputFieldElement.z0gr().ID : null);
				jsonObject.Add("OwnerPageIndex", xTextInputFieldElement.z0jr().z0suk()[xTextInputFieldElement.z0je()].z0vek());
				jsonObject.Add("TopInOwnerPage", ((XTextFieldElementBase)xTextInputFieldElement).z0jrk().z0fuk());
				jsonObject.Add("LeftInOwnerPage", ((XTextFieldElementBase)xTextInputFieldElement).z0jrk().z0mrk());
				z0yrk.Add(jsonObject);
			}
		}
		if (p0.z0mek() && p0.z0ji() is XTextInputFieldElement)
		{
			z0tek(p0);
			return;
		}
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		Color p1 = z0ZzZzrzj2.z0bek;
		float p2 = z0ZzZzrzj2.z0wtk;
		string z0tyk = z0ZzZzrzj2.z0tyk;
		bool flag = false;
		if (p0.z0ji() is XTextInputFieldElement)
		{
			XTextInputFieldElement xTextInputFieldElement2 = (XTextInputFieldElement)p0.z0ji();
			Color p3 = z0ZzZzrzj2.z0bek;
			p3 = xTextInputFieldElement2.z0eek(p3, z0ZzZzrzj2, p2: true);
			if (p3 != z0ZzZzrzj2.z0bek)
			{
				p1 = p3;
				flag = true;
			}
			if (z0vrk && p0.z0yek())
			{
				z0tyk = xTextInputFieldElement2.z0aek().z0tyk;
				p2 = xTextInputFieldElement2.z0aek().z0wtk;
				flag = true;
			}
		}
		string text = p0.z0rek(z0mek());
		float num = 0f;
		XTextContentElement xTextContentElement = p0.z0jy();
		if (p0.z0vek() && xTextContentElement is XTextDocumentContentElement && p0.z0iek() == ' ' && p0.z0rek() == ' ' && text.Trim().Length == 0)
		{
			float num2 = p0.z0tek().z0it();
			num = p0.z0bek().z0it() + p0.z0bek().Width - num2;
			if (num < 0f)
			{
				num = 0f;
			}
		}
		if (z0vrk && xTextContentElement != null && xTextContentElement.z0uek() < 1f)
		{
			p2 = z0ZzZzrzj2.z0wtk * xTextContentElement.z0uek();
			flag = true;
		}
		if (flag)
		{
			z0ZzZzrzj2 = new z0ZzZzrzj(z0ZzZzrzj2, z0tyk, p2, p1);
		}
		z0rek(text, z0ZzZzrzj2, p0, num, p4: false, !flag);
	}

	private void z0rek(XTextNewBarcodeElement p0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["id"] = p0.ID;
		dictionary["name"] = p0.Name;
		dictionary["text"] = p0.Text;
		dictionary["barcodestyle"] = Enum.GetName(p0.BarcodeStyle2.GetType(), p0.BarcodeStyle2);
		dictionary["textalignment"] = Enum.GetName(p0.TextAlignment.GetType(), p0.TextAlignment);
		z0eek(p0, dictionary);
	}

	private void z0rek(XTextPageInfoElement p0)
	{
		z0cek("label");
		z0rek(p0.GetType());
		z0rek((object)p0);
		if (!p0.Visible)
		{
			z0yek("dc_visible", p0.Visible);
		}
		base.z0oek();
		if (!p0.Visible)
		{
			z0yek("display", "none");
		}
		string text = p0.z0rek();
		if (p0.ValueType == PageInfoValueType.PageIndex && Options.ForPrint && Options.MultiDocument)
		{
			text = z0rek().z0vek().ToString();
		}
		XTextDocument xTextDocument = p0.z0jr();
		if (xTextDocument != null && xTextDocument.z0cpk())
		{
			int num = xTextDocument.z0suk().Count - 1;
			int num2 = z0tek() + 1;
			if (p0.FormatString == null || p0.FormatString.Length == 0)
			{
				if (p0.ValueType == PageInfoValueType.NumOfPages)
				{
					text = num.ToString();
				}
			}
			else
			{
				text = p0.FormatString.Replace("[%PageIndex%]", num2.ToString());
				text = text.Replace("[%NumOfPages%]", num.ToString());
			}
		}
		z0yek(p0.z0aek().z0pek, text);
		z0yek("color", z0uek(p0.z0aek().z0bek));
		((z0ZzZzfjh)this).z0zek();
		z0yek(text);
		((z0ZzZzfjh)this).z0xek();
	}

	private void z0rek(XTextInputFieldElement p0, string p1)
	{
		if (!p0.Visible)
		{
			return;
		}
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		z0cek("span");
		if (!z0irk)
		{
			z0tek((XTextElement)p0);
			if (p0.Name != null && p0.Name.Length > 0)
			{
				z0uek("name", p0.Name);
			}
			z0rek(p0.Attributes);
		}
		base.z0oek();
		z0rek(p0, p0.z0jr());
		if (p0.SpecifyWidth != 0f)
		{
			z0yek("width", z0iek(Math.Abs(p0.SpecifyWidth)));
			z0yek("display", "online-block");
			z0yek("white-space", "nowrap");
			switch (p0.Alignment)
			{
			case StringAlignment.Near:
				z0yek("text-align", "left");
				break;
			case StringAlignment.Center:
				z0yek("text-align", "center");
				break;
			case StringAlignment.Far:
				z0yek("text-align", "right");
				break;
			}
		}
		if (p0.TextColor.A > 0)
		{
			z0yek("color", z0uek(p0.TextColor));
		}
		z0rek(z0ZzZzrzj2, p0);
		z0yek(z0ZzZzrzj2.z0pek, null);
		DocumentViewOptions documentViewOptions = p0.z0iu();
		if (!documentViewOptions.IgnoreFieldBorderWhenPrint && (p0.StartBorderText == null || p0.StartBorderText.Length == 0) && (!z0ZzZzrzj2.z0rrk || z0ZzZzrzj2.z0erk == 0f || z0ZzZzrzj2.z0nek.A == 0))
		{
			z0yek("border-left", z0rek(Color.Transparent));
			z0yek("border-radius", "3px");
		}
		if (!documentViewOptions.IgnoreFieldBorderWhenPrint && (p0.EndBorderText == null || p0.EndBorderText.Length == 0) && (!z0ZzZzrzj2.z0etk || z0ZzZzrzj2.z0erk == 0f || z0ZzZzrzj2.z0grk.A == 0))
		{
			z0yek("border-right", z0rek(Color.Transparent));
			z0yek("border-radius", "3px");
		}
		((z0ZzZzfjh)this).z0zek();
		if (p0.StartBorderText != null && p0.StartBorderText.Length > 0)
		{
			z0cek("span");
			z0uek("style", "color:" + z0uek(((XTextFieldElementBase)p0).z0jrk().z0eek()));
			z0yek(p0.StartBorderText);
			((z0ZzZzfjh)this).z0xek();
		}
		if (p0.LabelText != null && p0.LabelText.Length > 0)
		{
			z0cek("span");
			z0yek(p0.LabelText);
			((z0ZzZzfjh)this).z0xek();
		}
		if (p0.z0be().Count == 0)
		{
			bool flag = false;
			string backgroundText = p0.BackgroundText;
			if (backgroundText != null && backgroundText.Length > 0)
			{
				if (p0.z0so())
				{
					z0cek("span");
					base.z0oek();
					z0yek("color", z0uek(((XTextFieldElementBase)p0).z0eek()));
					if (((XTextFieldElementBase)p0).z0drk() == DCBooleanValueHasDefault.True)
					{
						z0yek("font-style", "italic");
					}
					else if (((XTextFieldElementBase)p0).z0drk() == DCBooleanValueHasDefault.False)
					{
						z0yek("font-style", "normal");
					}
					((z0ZzZzfjh)this).z0zek();
					z0yek(backgroundText);
					((z0ZzZzfjh)this).z0xek();
					flag = true;
				}
				else if (documentViewOptions.PreserveBackgroundTextWhenPrint)
				{
					z0cek("span");
					z0uek("style", "color:transparent");
					z0yek(backgroundText);
					((z0ZzZzfjh)this).z0xek();
					flag = true;
				}
			}
			if (!flag && p0.SpecifyWidth != 0f)
			{
				base.z0yek('\u2002');
			}
		}
		else
		{
			z0tek(p0);
		}
		if (p0.UnitText != null && p0.UnitText.Length > 0)
		{
			z0cek("span");
			z0yek(p0.UnitText);
			((z0ZzZzfjh)this).z0xek();
		}
		if (p0.EndBorderText != null && p0.EndBorderText.Length > 0)
		{
			z0cek("span");
			z0uek("style", "color:" + z0uek(((XTextFieldElementBase)p0).z0tek().z0eek()));
			z0yek(p0.EndBorderText);
			((z0ZzZzfjh)this).z0xek();
		}
		((z0ZzZzfjh)this).z0xek();
	}

	public override bool z0lw()
	{
		return z0hrk.UseClassAttribute;
	}

	public void z0rek(XTextDocumentBodyElement p0)
	{
		z0nek();
		z0tek(p0);
	}

	public void z0uek(XTextElement p0)
	{
		if (z0drk != null && p0.ID != null && p0.ID.Length > 0 && z0drk.Contains(p0.ID))
		{
			if (z0yrk == null)
			{
				z0yrk = new JsonArray();
			}
			JsonObject jsonObject = new JsonObject();
			jsonObject.Add("ID", p0.ID);
			jsonObject.Add("Type", p0.z0qrk());
			jsonObject.Add("Width", p0.Width);
			jsonObject.Add("Height", p0.Height);
			jsonObject.Add("OwnerSubDocID", (p0.z0iek() != null) ? p0.z0iek().ID : null);
			jsonObject.Add("OwnerTableID", (p0.z0gr() != null) ? p0.z0gr().ID : null);
			jsonObject.Add("OwnerPageIndex", p0.z0jr().z0suk()[p0.z0je()].z0vek());
			jsonObject.Add("TopInOwnerPage", p0.z0fuk());
			jsonObject.Add("LeftInOwnerPage", p0.z0mrk());
			z0yrk.Add(jsonObject);
		}
		if (p0 is XTextStringElement)
		{
			z0rek((XTextStringElement)p0);
		}
		else if (p0 is XTextInputFieldElement)
		{
			z0rek((XTextInputFieldElement)p0, p0.ID);
		}
		else if (p0 is XTextCheckBoxElementBase)
		{
			z0rek((XTextCheckBoxElementBase)p0);
		}
		else if (p0 is XTextImageElement)
		{
			z0rek((XTextImageElement)p0);
		}
		else if (p0 is XTextTableElement)
		{
			z0rek((XTextTableElement)p0);
		}
		else if (p0 is z0ZzZzqjh)
		{
			z0rek((z0ZzZzqjh)p0);
		}
		else if (p0 is XTextMedicalExpressionFieldElement)
		{
			z0rek((XTextMedicalExpressionFieldElement)p0);
		}
		else if (p0 is XTextBarcodeFieldElement)
		{
			z0rek((XTextBarcodeFieldElement)p0);
		}
		else if (p0 is XTextNewMedicalExpressionElement)
		{
			z0rek((XTextNewMedicalExpressionElement)p0);
		}
		else if (p0 is XTextNewBarcodeElement)
		{
			z0rek((XTextNewBarcodeElement)p0);
		}
		else if (p0 is XTextTDBarcodeElement)
		{
			z0rek((XTextTDBarcodeElement)p0);
		}
		else if (p0 is XTextSectionElement)
		{
			z0rek((XTextSectionElement)p0);
		}
		else if (p0 is XTextFieldBorderElement)
		{
			z0rek((XTextFieldBorderElement)p0);
		}
		else if (p0 is XTextMediaElement)
		{
			z0rek((XTextMediaElement)p0);
		}
		else if (p0 is XTextDocumentBodyElement)
		{
			z0rek((XTextDocumentBodyElement)p0);
		}
		else if (p0 is XTextDocument)
		{
			XTextDocument xTextDocument = (XTextDocument)p0;
			xTextDocument.z0bik();
			z0yek(xTextDocument);
			xTextDocument.z0aok();
		}
		else if (p0 is XTextDirectoryFieldElement)
		{
			z0rek((XTextDirectoryFieldElement)p0);
		}
		else if (p0 is XTextCustomShapeElement)
		{
			z0rek((XTextCustomShapeElement)p0);
		}
		else if (p0 is XTextButtonElement)
		{
			z0rek((XTextButtonElement)p0);
		}
		else if (p0 is XTextHorizontalLineElement)
		{
			z0rek((XTextHorizontalLineElement)p0);
		}
		else if (p0 is XTextChartElement)
		{
			z0rek((XTextChartElement)p0);
		}
		else if (p0 is XTextPieElement)
		{
			z0rek((XTextPieElement)p0);
		}
		else if (p0 is XTextLabelElement)
		{
			z0rek((XTextLabelElement)p0);
		}
		else if (p0 is XTextPageBreakElement)
		{
			z0rek((XTextPageBreakElement)p0);
		}
		else if (p0 is XTextPageInfoElement)
		{
			z0rek((XTextPageInfoElement)p0);
		}
		else if (p0 is XTextParagraphElement)
		{
			z0rek((XTextParagraphElement)p0);
		}
		else if (p0 is XTextParagraphListItemElement)
		{
			z0rek((XTextParagraphListItemElement)p0);
		}
		else if (p0 is XTextLineBreakElement)
		{
			z0rek((XTextLineBreakElement)p0);
		}
		else if (p0 is XTextShapeInputFieldElement)
		{
			z0rek((XTextShapeInputFieldElement)p0);
		}
		else if (p0 is XTextDocumentHeaderElement || p0 is XTextDocumentFooterElement || p0 is XTextDocumentHeaderForFirstPageElement || p0 is XTextDocumentFooterForFirstPageElement)
		{
			z0tek((XTextContentElement)p0);
		}
		else if (p0 is XTextContentElement)
		{
			z0tek((XTextContentElement)p0);
		}
		else if (p0 is XTextControlHostElement)
		{
			z0rek((XTextControlHostElement)p0);
		}
		else if (p0 is XTextContainerElement)
		{
			z0tek((XTextContainerElement)p0);
		}
		else if (p0 is XTextSignImageElement)
		{
			z0tek((XTextSignImageElement)p0);
		}
	}

	private void z0rek(XTextDirectoryFieldElement p0)
	{
		p0.z0rek(p0: false);
		z0cek("div");
		z0tek((XTextElement)p0);
		z0rek(p0.GetType());
		z0rek((object)p0);
		base.z0oek();
		((z0ZzZzfjh)this).z0zek();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				if (z0bpk.Current is XTextLabelElement xTextLabelElement && xTextLabelElement.z0iek() != null)
				{
					z0cek("div");
					XTextDirectoryFieldElement.z0bjj z0bjj = (XTextDirectoryFieldElement.z0bjj)xTextLabelElement.z0uek();
					base.z0oek();
					z0yek("background-color", "#cccccc");
					z0yek("margin-left", Convert.ToString(z0bjj.z0eek() * 20) + "px");
					((z0ZzZzfjh)this).z0zek();
					z0cek("a");
					z0uek("href", xTextLabelElement.z0iek().Reference);
					z0uek("title", xTextLabelElement.z0iek().Title);
					base.z0oek();
					z0yek(p0.z0aek().z0pek, xTextLabelElement.z0iek().Title);
					((z0ZzZzfjh)this).z0zek();
					z0yek(xTextLabelElement.z0iek().Title);
					((z0ZzZzfjh)this).z0xek();
					((z0ZzZzfjh)this).z0xek();
				}
			}
		}
		((z0ZzZzfjh)this).z0xek();
	}

	private void z0rek(XTextHorizontalLineElement p0)
	{
		if (Options.ForPrint)
		{
			z0cek("hr");
		}
		else
		{
			z0cek("span");
		}
		z0rek(p0.GetType());
		z0tek(p0);
		z0rek((object)p0);
		if (p0.LineLengthInCM > 0f)
		{
			z0uek("width", z0ZzZzrpk.z0eek(p0.LineLengthInCM * 10f, GraphicsUnit.Millimeter, GraphicsUnit.Pixel) + "px");
		}
		else
		{
			z0uek("width", "100%");
		}
		string p1 = z0uek(p0.z0aek().z0bek);
		int num = z0rek(p0.LineSize);
		string text = null;
		text = p0.LineStyle switch
		{
			DashStyle.Dot => "dotted", 
			DashStyle.Dash => "dashed", 
			_ => "solid", 
		};
		base.z0oek();
		if (num > 0)
		{
			z0yek("border-top-width", num + "px");
		}
		z0yek("border-top-color", p1);
		z0yek("border-top-style", text);
		z0yek("border-bottom-style", "none");
		z0yek("border-left-style", "none");
		z0yek("border-right-style", "none");
		if (Options.ForPrint && p0.z0ptk() != null)
		{
			z0yek("height", z0uek(p0.z0ptk().z0ytk()) + "px");
			z0yek("margin-top", "8px");
			z0yek("margin-bottom", "-8px");
		}
		((z0ZzZzfjh)this).z0zek();
		z0yrk();
	}

	private bool z0rek(z0ZzZzzlh p0, bool p1)
	{
		z0ZzZzndh z0ZzZzndh2 = new z0ZzZzndh((int)p0.z0xtk() + 1, (int)p0.z0xrk() + 1, (int)p0.z0jyk_jiejie20260327142557() - 2, (int)p0.z0ytk() - 2);
		if (z0vrk && !p0.z0xek())
		{
			int num = z0jrk.z0bek() - z0ZzZzndh2.z0mek();
			if (num > 2 && (float)num < p0.z0ytk() * 0.4f)
			{
				return false;
			}
		}
		if (z0ZzZzndh2.z0mek() >= z0jrk.z0bek() - 4 || z0ZzZzndh2.z0bek() < z0jrk.z0mek() + 4)
		{
			return false;
		}
		if (!p1 && (z0ZzZzndh2.z0pek() > z0jrk.z0nek() || z0ZzZzndh2.z0nek() < z0jrk.z0pek()))
		{
			return false;
		}
		return true;
	}

	public static void z0rek(z0ZzZzrjh p0, XTextNewBarcodeElement p1)
	{
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0uek("dc_printvisibility", z0ZzZzzyk.z0eek(typeof(ElementVisibility), p1.PrintVisibility));
		}
		p0.z0rek(p1.Attributes);
		if (p1.BarcodeStyle2 != DCBarcodeStyle.Code128C)
		{
			p0.z0uek("dc_barcodestyle2", z0ZzZzzyk.z0eek(typeof(DCBarcodeStyle), p1.BarcodeStyle2));
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0uek("dc_contentreadonly", z0ZzZzzyk.z0eek(typeof(ContentReadonlyState), p1.ContentReadonly));
		}
		if (!p1.Deleteable)
		{
			p0.z0yek("dc_deleteable", p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0yek("dc_enabled", p1.Enabled);
		}
		if (p1.Height != 125f)
		{
			p0.z0yek("dc_height", p1.Height);
		}
		if (p1.ID != null && p1.ID.Length > 0)
		{
			p0.z0uek("id", p1.ID);
		}
		if (p1.z0iek() != null)
		{
			p0.z0uek("dc_linkinfo", z0ZzZzmik.z0rek(p1.z0iek(), p1: true));
		}
		if (p1.Name != null && p1.Name.Length > 0)
		{
			p0.z0uek("dc_name", p1.Name);
		}
		if (p1.PropertyExpressions != null && p1.PropertyExpressions.Count > 0)
		{
			p0.z0uek("dc_propertyexpressions", ((z0ZzZzcuk)p1.PropertyExpressions).DCWriteString());
		}
		if (!p1.ShowText)
		{
			p0.z0yek("dc_showtext", p1.ShowText);
		}
		if (p1.StrictMatchPageIndex)
		{
			p0.z0yek("dc_strictmatchpageindex", p1.StrictMatchPageIndex);
		}
		if (p1.StringTag != null && p1.StringTag.Length > 0)
		{
			p0.z0uek("dc_stringtag", p1.StringTag);
		}
		if (p1.TextAlignment != StringAlignment.Center)
		{
			p0.z0uek("dc_textalignment", z0ZzZzzyk.z0eek(typeof(StringAlignment), p1.TextAlignment));
		}
		if (p1.ValueBinding != null)
		{
			p0.z0uek("dc_valuebinding", ((z0ZzZzcuk)p1.ValueBinding).DCWriteString());
		}
		if (p1.ValueExpression != null && p1.ValueExpression.Length > 0)
		{
			p0.z0uek("dc_valueexpression", p1.ValueExpression);
		}
	}

	public void z0tek(int p0)
	{
		z0grk = p0;
	}

	private void z0tek(bool p0)
	{
		z0frk = p0;
	}

	public string z0iek(float p0)
	{
		if (p0 <= 0f)
		{
			return "0px";
		}
		float num = z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, GraphicsUnit.Pixel);
		if (num == 0f)
		{
			num = 1f;
		}
		return base.z0iek((int)num);
	}

	internal static string z0rek(string p0)
	{
		return p0 switch
		{
			"|0000|0|" => "*", 
			"#000000|1111|0.32|" => "#", 
			"#000000|0000|0.32|" => "$", 
			_ => p0, 
		};
	}

	private XTextElementList z0rek(XTextElementList p0, bool p1, bool p2)
	{
		int count = p0.Count;
		switch (count)
		{
		case 0:
			return z0wrk;
		case 1:
			if (!(p0[0] is XTextCharElement))
			{
				return p0;
			}
			break;
		}
		if (p1 && Options.DocumentOptions.BehaviorOptions.ParagraphFlagFollowTableOrSection && count == 2 && p0[0] is XTextContainerElement && p0[1] is XTextParagraphFlagElement)
		{
			return new XTextElementList(p0[0]);
		}
		XTextStringElement xTextStringElement = null;
		z0ZzZzgbj options = Options;
		if (!p1 && count < 20 && count > 1 && p0[count - 1] is XTextParagraphFlagElement && p0[0].z0ji() is XTextContentElement)
		{
			int z0buk = p0[0].z0buk;
			int num = count - 1;
			XTextParagraphFlagElement xTextParagraphFlagElement = p0[count - 1] as XTextParagraphFlagElement;
			if (xTextParagraphFlagElement != null)
			{
				num--;
			}
			bool flag = true;
			XTextContentElement xTextContentElement = (XTextContentElement)p0[0].z0ji();
			for (int num2 = num; num2 >= 0; num2--)
			{
				XTextElement xTextElement = p0[num2];
				if (!(xTextElement is XTextCharElement) || xTextElement.z0buk != z0buk || xTextElement.z0ji() != xTextContentElement)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				char[] array = new char[num + 1];
				for (int num3 = num; num3 >= 0; num3--)
				{
					array[num3] = ((XTextCharElement)p0[num3]).z0bek;
					if (XTextCharElement.z0tek((int)array[num3]))
					{
						List<char> list = new List<char>();
						for (num3 = num; num3 >= 0; num3--)
						{
							XTextCharElement xTextCharElement = (XTextCharElement)p0[num3];
							list.Add(xTextCharElement.CharValue);
							if (XTextCharElement.z0tek((int)xTextCharElement.CharValue))
							{
								list.Add((char)xTextCharElement.z0iek());
							}
						}
						array = list.ToArray();
						break;
					}
				}
				XTextStringElement xTextStringElement2 = new XTextStringElement();
				xTextStringElement2.Text = new string(array);
				xTextStringElement2.z0yek((XTextCharElement)p0[0]);
				xTextStringElement2.z0rek((XTextCharElement)p0[num]);
				xTextStringElement2.z0buk = z0buk;
				if (options.ForPrint)
				{
					xTextStringElement2.z0tek(p0: true);
				}
				xTextStringElement2.z0oek();
				if (xTextParagraphFlagElement != null)
				{
					xTextStringElement2.z0cek = xTextParagraphFlagElement;
					return new XTextElementList(new XTextElement[2] { xTextStringElement2, xTextParagraphFlagElement }, a: true);
				}
				XTextElementList xTextElementList = p0[0].z0jy().z0trk();
				int count2 = xTextElementList.Count;
				for (int i = xTextElementList.z0bek(xTextStringElement2.z0bek()) + 1; i < count2; i++)
				{
					if (xTextElementList[i] is XTextParagraphFlagElement)
					{
						xTextStringElement2.z0cek = (XTextParagraphFlagElement)xTextElementList[i];
						break;
					}
				}
				return new XTextElementList(xTextStringElement2);
			}
		}
		XTextElementList xTextElementList2 = new XTextElementList();
		List<XTextStringElement> list2 = new List<XTextStringElement>();
		bool flag2 = true;
		bool flag3 = options.ContentRenderMode != (z0ZzZzfbj)8;
		DCBackgroundTextOutputMode backgroundTextOutputMode = options.BackgroundTextOutputMode;
		bool enableEncryptView = options.EnableEncryptView;
		bool forPrint = options.ForPrint;
		for (int j = 0; j < count; j++)
		{
			XTextElement xTextElement2 = p0[j];
			if ((flag3 && ((xTextElement2.z0kik != null && !xTextElement2.z0kik.z0oek()) || ((xTextElement2 is XTextCharElement || xTextElement2 is XTextParagraphFlagElement || xTextElement2 is XTextObjectElement) && xTextElement2.z0ptk() == null))) || (p2 && xTextElement2.z0wtk()) || (p1 && !xTextElement2.z0de()))
			{
				continue;
			}
			if (xTextElement2 is XTextCharElement)
			{
				XTextCharElement xTextCharElement2 = (XTextCharElement)xTextElement2;
				string text = null;
				bool flag4 = false;
				XTextInputFieldElement xTextInputFieldElement = xTextCharElement2.z0ji() as XTextInputFieldElement;
				if (xTextInputFieldElement != null)
				{
					flag4 = ((XTextFieldElementBase)xTextInputFieldElement).z0rek((XTextElement)xTextCharElement2);
					if (flag4)
					{
						if (backgroundTextOutputMode == DCBackgroundTextOutputMode.None)
						{
							continue;
						}
						switch (backgroundTextOutputMode)
						{
						case DCBackgroundTextOutputMode.Whitespace:
							text = ((xTextCharElement2.z0bek <= 'Ā') ? " " : "  ");
							break;
						case DCBackgroundTextOutputMode.Underline:
							text = ((xTextCharElement2.z0bek <= 'Ā') ? "_" : "__");
							break;
						}
					}
					else if (enableEncryptView && xTextInputFieldElement.z0eek(xTextCharElement2) && Options.ForPrint)
					{
						text = "*";
					}
				}
				if (xTextStringElement != null && xTextStringElement.z0eek(xTextCharElement2) && xTextStringElement.z0iek(xTextCharElement2) && xTextStringElement.z0mek() == flag4)
				{
					if (text == null)
					{
						if (xTextCharElement2.z0tek() == 9)
						{
							XTextCharElement xTextCharElement3 = new XTextCharElement();
							XTextCharElement xTextCharElement4 = new XTextCharElement();
							XTextCharElement xTextCharElement5 = new XTextCharElement();
							XTextCharElement xTextCharElement6 = new XTextCharElement();
							char c = (xTextCharElement6.CharValue = ' ');
							char c3 = (xTextCharElement5.CharValue = c);
							char charValue = (xTextCharElement4.CharValue = c3);
							xTextCharElement3.CharValue = charValue;
							xTextStringElement.z0tek(xTextCharElement3);
							xTextStringElement.z0tek(xTextCharElement4);
							xTextStringElement.z0tek(xTextCharElement5);
							xTextStringElement.z0tek(xTextCharElement6);
						}
						else
						{
							xTextStringElement.z0tek(xTextCharElement2);
						}
					}
					else
					{
						xTextStringElement.z0eek(xTextCharElement2, text);
					}
				}
				else
				{
					xTextStringElement = new XTextStringElement();
					list2.Add(xTextStringElement);
					xTextStringElement.z0oek(xTextCharElement2);
					xTextStringElement.z0tek(forPrint);
					if (flag4 && xTextInputFieldElement != null)
					{
						xTextStringElement.z0buk = xTextInputFieldElement.z0buk;
					}
					xTextStringElement.z0eek(flag4);
					xTextElementList2.Add(xTextStringElement);
					if (text == null)
					{
						xTextStringElement.z0tek(xTextCharElement2);
					}
					else
					{
						xTextStringElement.z0eek(xTextCharElement2, text);
					}
				}
			}
			else
			{
				if (xTextElement2 is XTextContainerElement)
				{
					flag2 = false;
				}
				xTextStringElement = null;
				xTextElementList2.z0hrk(xTextElement2);
			}
		}
		if (list2.Count > 0)
		{
			XTextParagraphFlagElement xTextParagraphFlagElement2 = p0.LastElement as XTextParagraphFlagElement;
			if (xTextParagraphFlagElement2 == null)
			{
				xTextParagraphFlagElement2 = ((p0[0].z0jy() == null) ? p0[0].z0dy() : p0[0].z0jy().z0trk().z0oek(list2[list2.Count - 1].z0bek()));
			}
			foreach (XTextStringElement item in list2)
			{
				item.z0oek();
				item.z0cek = xTextParagraphFlagElement2;
			}
		}
		if (xTextElementList2.LastElement is XTextParagraphFlagElement && ((XTextParagraphFlagElement)xTextElementList2.LastElement).z0vek())
		{
			xTextElementList2.RemoveAt(xTextElementList2.Count - 1);
		}
		return xTextElementList2;
	}

	private new z0ZzZzvnj z0pek()
	{
		return Options;
	}

	z0ZzZzvnj z0ZzZzzhh.z0eek()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0pek
		return this.z0pek();
	}

	private void z0rek(XTextButtonElement p0)
	{
		z0cek("input");
		z0uek("type", "button");
		z0tek(p0);
		z0rek(p0.GetType());
		if (p0.PrintVisibility != ElementVisibility.Visible)
		{
			z0uek("dc_printvisibility", z0ZzZzzyk.z0eek(typeof(ElementVisibility), p0.PrintVisibility));
		}
		z0rek(p0.Attributes);
		if (p0.CommandName != null && p0.CommandName.Length > 0)
		{
			z0uek("dc_commandname", p0.CommandName);
		}
		if (p0.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0uek("dc_contentreadonly", z0ZzZzzyk.z0eek(typeof(ContentReadonlyState), p0.ContentReadonly));
		}
		if (!p0.Deleteable)
		{
			z0yek("dc_deleteable", p0.Deleteable);
		}
		if (!p0.Enabled)
		{
			z0yek("dc_enabled", p0.Enabled);
		}
		z0yek("dc_height", p0.Height);
		if (p0.ID != null && p0.ID.Length > 0)
		{
			z0uek("id", p0.ID);
		}
		if (p0.z0iek() != null)
		{
			z0uek("dc_linkinfo", z0ZzZzmik.z0rek(p0.z0iek(), p1: true));
		}
		if (p0.Name != null && p0.Name.Length > 0)
		{
			z0uek("dc_name", p0.Name);
		}
		if (p0.PropertyExpressions != null && p0.PropertyExpressions.Count > 0)
		{
			z0uek("dc_propertyexpressions", ((z0ZzZzcuk)p0.PropertyExpressions).DCWriteString());
		}
		if (p0.ScriptTextForClick != null && p0.ScriptTextForClick.Length > 0)
		{
			string scriptTextForClick = p0.ScriptTextForClick;
			z0uek("dc_scripttextforclick", scriptTextForClick);
			z0uek("onclick", scriptTextForClick);
		}
		if (p0.StringTag != null && p0.StringTag.Length > 0)
		{
			z0uek("dc_stringtag", p0.StringTag);
		}
		if (p0.Text != null && p0.Text.Length > 0)
		{
			z0uek("dc_text", p0.Text);
		}
		if (p0.ValueExpression != null && p0.ValueExpression.Length > 0)
		{
			z0uek("dc_valueexpression", p0.ValueExpression);
		}
		z0yek("dc_width", p0.Width);
		z0uek("value", p0.Text);
		if (p0.ToolTip != null && p0.ToolTip.Length > 0)
		{
			z0uek("title", p0.ToolTip);
		}
		string text = string.Empty;
		if (p0.Image != null)
		{
			p0.Image.FormatBase64String = false;
			p0.Image.ChangeImageFormat(z0ZzZzrdh.z0eek);
			string imageDataBase64String = p0.Image.ImageDataBase64String;
			text = text + "background-image:url('data:image/png;base64," + imageDataBase64String + "');";
		}
		text = text + "width:" + z0uek(p0.Width) + "px;height:" + z0uek(p0.Height) + "px";
		if (Options.ForPrint && p0.PrintVisibility == ElementVisibility.Hidden)
		{
			text += ";visibility:hidden";
		}
		if (z0ZzZzcij.z0rek != null && z0ZzZzcij.z0rek.z0rek != 0)
		{
			text = text + ";border-radius:" + z0ZzZzcij.z0rek.z0rek + "px";
		}
		z0uek("style", text);
		z0yrk();
	}

	public static bool z0rek(z0ZzZzrjh p0, object p1)
	{
		if (p1 is XTextImageElement)
		{
			z0rek(p0, (XTextImageElement)p1);
			return true;
		}
		if (p1 is XTextCheckBoxElement)
		{
			z0rek(p0, (XTextCheckBoxElement)p1);
			return true;
		}
		if (p1 is XTextRadioBoxElement)
		{
			z0rek(p0, (XTextRadioBoxElement)p1);
			return true;
		}
		if (p1 is XTextNewBarcodeElement)
		{
			z0rek(p0, (XTextNewBarcodeElement)p1);
			return true;
		}
		if (p1 is XTextTDBarcodeElement)
		{
			z0rek(p0, (XTextTDBarcodeElement)p1);
			return true;
		}
		return false;
	}

	private void z0yek(XTextDocument p0)
	{
		p0.z0qtk().RenderMode = DocumentRenderMode.Html;
		z0yek(p0.z0dik().Font.Value);
		z0tek((XTextContainerElement)p0);
	}

	public void z0eek(XTextElement p0, Dictionary<string, string> p1)
	{
		XTextDocument xTextDocument = p0.z0jr();
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		string text = null;
		if (p1 != null && p1.ContainsKey("src"))
		{
			text = p1["src"];
		}
		bool flag = false;
		if (p0 is XTextObjectElement && Options.ForPrint && ((XTextObjectElement)p0).ZOrderStyle == ElementZOrderStyle.InFrontOfText)
		{
			flag = true;
			z0cek("span");
			z0uek("style", "position:relative");
		}
		string text2 = null;
		string text3 = null;
		byte[] array = null;
		string text4 = null;
		if (text == null || text.Length == 0)
		{
			z0ZzZzpmk z0ZzZzpmk2 = null;
			if (p0 is XTextImageElement)
			{
				XTextImageElement xTextImageElement = (XTextImageElement)p0;
				array = z0ZzZzsfh.z0eek(xTextImageElement, z0tek());
				if (array == null)
				{
					z0ZzZzpmk2 = p0.z0ny();
					if (xTextImageElement.z0mrk() && xTextImageElement.z0jr().z0nmk().Count > 0)
					{
						z0ZzZzpmk2 = xTextImageElement.z0jr().z0nmk()[xTextImageElement.z0cek()];
					}
					if (xTextImageElement.z0rek().A != 0 && z0ZzZzpmk2.z0nek())
					{
						z0ZzZzpmk2.MakeTransparent(xTextImageElement.z0rek());
					}
				}
			}
			else
			{
				z0ZzZzpmk2 = p0.z0ny();
			}
			if (p0 is XTextSignImageElement)
			{
				XTextSignImageElement xTextSignImageElement = (XTextSignImageElement)p0;
				if (z0rek(xTextSignImageElement))
				{
					array = xTextSignImageElement.ImageData;
				}
				else if (xTextSignImageElement.HasImageContent())
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						z0ZzZzpmk2.z0eek(memoryStream, z0ZzZzrdh.z0eek);
						array = memoryStream.ToArray();
					}
					text4 = Convert.ToBase64String(xTextSignImageElement.ImageData);
				}
			}
			if (z0ZzZzpmk2 != null || array != null)
			{
				bool flag2 = false;
				if ((!xTextDocument.z0hi().ShowPermissionMark || z0ZzZzrzj2.z0jyk < 0) && !xTextDocument.z0hi().ShowPermissionMark && z0ZzZzrzj2.z0jyk >= 0)
				{
					return;
				}
				if (array == null)
				{
					MemoryStream memoryStream2 = new MemoryStream();
					if (z0ZzZzpmk2 != null && z0ZzZzpmk2.HasContent)
					{
						z0ZzZzpmk2.z0eek(memoryStream2, z0ZzZzrdh.z0eek);
					}
					memoryStream2.Close();
					array = memoryStream2.ToArray();
				}
				text2 = z0ZzZzcoj.z0tek(array);
				if (flag2)
				{
					z0ZzZzpmk2.Dispose();
				}
			}
		}
		if ((text == null || text.Length <= 0) && (text2 == null || text2.Length <= 0))
		{
			return;
		}
		z0cek("img");
		z0tek(p0);
		Type type = null;
		type = ((p0 is XTextMedicalExpressionFieldElement) ? typeof(XTextNewMedicalExpressionElement) : ((!(p0 is XTextBarcodeFieldElement)) ? p0.GetType() : typeof(XTextNewBarcodeElement)));
		z0rek(type);
		if (p0.z0xrk().CommentIndex >= 0)
		{
			DocumentComment documentComment = p0.z0jr().Comments.z0eek(p0.z0xrk().CommentIndex);
			if (documentComment != null)
			{
				z0uek("title", documentComment.z0eek(p0.z0jr()) + Environment.NewLine + documentComment.z0nek());
			}
		}
		bool flag3 = false;
		z0rek((object)p0);
		flag3 = true;
		if (p1 != null)
		{
			foreach (string key in p1.Keys)
			{
				z0uek(key, p1[key]);
			}
		}
		z0rek(p0.z0qt());
		base.z0oek();
		z0rek(p0, p0.z0jr());
		z0rek(z0ZzZzrzj2, p0);
		if (p0.z0aek().z0xyk == ContentLayoutAlign.Surroundings)
		{
			if (p0.z0aek().z0tuk == DocumentContentAlignment.Right)
			{
				z0yek("float", "right");
			}
			else
			{
				z0yek("float", "left");
			}
			z0uek("dc_surroundings", "true");
		}
		if (flag)
		{
			XTextObjectElement xTextObjectElement = (XTextObjectElement)p0;
			if (xTextObjectElement.ZOrderStyle == ElementZOrderStyle.InFrontOfText)
			{
				z0yek("position", "absolute");
				if (xTextObjectElement.OffsetX != 0f)
				{
					z0yek("left", base.z0uek(z0ZzZzrpk.z0eek(xTextObjectElement.OffsetX, GraphicsUnit.Document, GraphicsUnit.Pixel)));
				}
				if (xTextObjectElement.OffsetY != 0f)
				{
					z0yek("top", base.z0uek(z0ZzZzrpk.z0eek(xTextObjectElement.OffsetY, GraphicsUnit.Document, GraphicsUnit.Pixel)));
				}
			}
		}
		if (Options.ForPrint && p0.z0dy().z0aek().z0cyk == LineSpacingStyle.SpaceSpecify)
		{
			z0yek("transform", "translateY(-50%)");
			z0yek("position", "relative");
			z0yek("top", "50%");
			z0yek("vertical-align", "top");
		}
		((z0ZzZzfjh)this).z0zek();
		if (text4 != null && text4.Length > 0)
		{
			z0uek("dc_nativesrc", text4);
		}
		if (text2 != null && text2.Length > 0)
		{
			z0uek("src", text2);
		}
		else if (p1 == null || !p1.ContainsKey("src"))
		{
			z0uek("src", text);
		}
		if (text3 != null && text3.Length > 0)
		{
			z0uek("nativeimagedata", text3);
		}
		z0uek("width", base.z0iek(Convert.ToInt32(xTextDocument.z0grk(p0.Width))));
		z0uek("height", base.z0iek(Convert.ToInt32(xTextDocument.z0grk(p0.Height))));
		if (!flag3)
		{
			z0rek((object)p0);
		}
		z0yrk();
		if (flag)
		{
			((z0ZzZzfjh)this).z0xek();
		}
	}

	public z0ZzZzrjh()
	{
		base.z0yek(p0: true);
	}

	private void z0rek(XTextContentElement p0)
	{
		if (p0.z0zek() == null || p0.z0zek().Length == 0)
		{
			return;
		}
		XTextDocument xTextDocument = p0.z0jr();
		bool bothBlackWhenPrint = xTextDocument.z0vtk().ViewOptions.BothBlackWhenPrint;
		float num = ((XTextElement)p0).z0ltk();
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		float num2 = num + p0.Height - z0ZzZzrzj2.z0xrk;
		bool flag = z0jrk.z0vek();
		if (!flag)
		{
			num2 = Math.Min(z0jrk.z0bek(), num2);
		}
		z0ZzZzzej z0ZzZzzej2 = null;
		if (p0.z0rek_jiejie20260327142557<XTextDocumentBodyElement>() != null)
		{
			z0ZzZzzej2 = p0.z0ju();
			if (z0ZzZzzej2 == null || !z0ZzZzzej2.z0uek() || !z0ZzZzzej2.z0yek())
			{
				if (p0 is XTextDocumentBodyElement)
				{
					DocumentViewOptions documentViewOptions = p0.z0iu();
					if (documentViewOptions.PrintGridLine && documentViewOptions.ShowGridLine)
					{
						z0ZzZzzej2 = new z0ZzZzzej();
						z0ZzZzzej2.z0eek(p0: true);
						z0ZzZzzej2.z0rek(p0: true);
						z0ZzZzzej2.z0eek(bothBlackWhenPrint ? Color.Black : documentViewOptions.GridLineColor);
						z0ZzZzzej2.z0eek(documentViewOptions.GridLineStyle);
					}
				}
				else if (z0ZzZzzej2 == null && (z0ZzZzrzj2.z0atk == ContentGridLineType.Display || z0ZzZzrzj2.z0atk == ContentGridLineType.ExtentToBottom))
				{
					z0ZzZzzej2 = new z0ZzZzzej();
					z0ZzZzzej2.z0eek(p0: true);
					z0ZzZzzej2.z0rek(p0: true);
					z0ZzZzzej2.z0eek(bothBlackWhenPrint ? Color.Black : z0ZzZzrzj2.z0zrk);
					z0ZzZzzej2.z0eek(z0ZzZzrzj2.z0mek);
				}
			}
			if (z0ZzZzzej2 != null && (z0ZzZzzej2.z0zek() <= 0f || !z0ZzZzzej2.z0uek()))
			{
				z0ZzZzzej2 = null;
			}
			if (z0ZzZzzej2 != null && p0 is XTextTableCellElement)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)p0.z0ji();
				if (xTextTableRowElement != null && xTextTableRowElement.HeaderStyle)
				{
					z0ZzZzzej2 = null;
				}
			}
		}
		XTextParagraphFlagElement xTextParagraphFlagElement = null;
		if (((XTextContainerElement)p0).z0xek() == 1 && p0.z0be()[0] is XTextParagraphFlagElement)
		{
			xTextParagraphFlagElement = (XTextParagraphFlagElement)p0.z0be()[0];
		}
		bool flag2 = p0 is XTextTableCellElement;
		z0ZzZzzlh[] array = p0.z0zek();
		int num3 = array.Length;
		zzz.z0ZzZzkuk<z0ZzZzzlh> z0ZzZzkuk2 = ((array == null) ? new zzz.z0ZzZzkuk<z0ZzZzzlh>() : new zzz.z0ZzZzkuk<z0ZzZzzlh>(array, p1: false));
		float num4 = p0.z0si();
		if (!flag)
		{
			for (int i = 0; i < num3; i++)
			{
				z0ZzZzzlh p1 = array[i];
				if (z0rek(p1, flag2))
				{
					continue;
				}
				z0ZzZzkuk2 = ((i != 0) ? zzz.z0ZzZzkuk<z0ZzZzzlh>.z0jrk(array, 0, i) : new zzz.z0ZzZzkuk<z0ZzZzzlh>());
				for (int j = i + 1; j < num3; j++)
				{
					z0ZzZzzlh z0ZzZzzlh2 = array[j];
					if (z0ZzZzzlh2.z0zrk() > num4 - 5f)
					{
						break;
					}
					int num5 = z0jrk.z0mek();
					int num6 = z0jrk.z0bek();
					if (!flag2 || ((XTextTableCellElement)p0).MirrorViewForCrossPage || ((!(z0ZzZzzlh2.z0xrk() < (float)num5) || !(z0ZzZzzlh2.z0lrk() > (float)num5) || !(z0ZzZzzlh2.z0lrk() < (float)num6) || !(z0ZzZzzlh2.z0lrk() - (float)num5 < z0ZzZzzlh2.z0ytk() / 2f)) && (!(z0ZzZzzlh2.z0xrk() > (float)num5) || !(z0ZzZzzlh2.z0xrk() < (float)num6) || !(z0ZzZzzlh2.z0lrk() > (float)num6) || !(z0ZzZzzlh2.z0lrk() - (float)num6 > z0ZzZzzlh2.z0ytk() / 2f))))
					{
						if (z0rek(z0ZzZzzlh2, flag2))
						{
							z0ZzZzkuk2.Add(z0ZzZzzlh2);
						}
						else if (z0ZzZzzlh2.z0xrk() >= (float)z0jrk.z0bek())
						{
							break;
						}
					}
				}
				break;
			}
		}
		_ = z0ZzZzkuk2.Count;
		z0wpk z0wpk = null;
		if (!z0mrk.TryGetValue(p0, out z0wpk))
		{
			z0wpk = new z0wpk();
			z0mrk[p0] = z0wpk;
		}
		if (!Options.ForPrint)
		{
			z0wpk.z0nek = base.z0pek();
		}
		base.z0uek(0);
		bool flag3 = false;
		DCBackgroundTextOutputMode backgroundTextOutputMode = Options.BackgroundTextOutputMode;
		if (backgroundTextOutputMode == DCBackgroundTextOutputMode.Output || backgroundTextOutputMode == DCBackgroundTextOutputMode.Underline || backgroundTextOutputMode == DCBackgroundTextOutputMode.Whitespace)
		{
			flag3 = true;
		}
		string text = null;
		string text2 = null;
		if (z0ZzZzrzj2.z0ryk > 0f)
		{
			text = z0iek(z0ZzZzrzj2.z0ryk);
		}
		if (z0ZzZzrzj2.z0ptk > 0f)
		{
			text2 = z0iek(z0ZzZzrzj2.z0ptk);
		}
		z0ZzZzzlh z0ZzZzzlh3 = ((z0ZzZzkuk2.Count == 0) ? null : z0ZzZzkuk2[0]);
		if (z0ZzZzzej2 != null && (z0ZzZzzlh3 == null || z0ZzZzzlh3.z0zrk() > 0f))
		{
			float num7 = num2;
			if (z0ZzZzzlh3 != null)
			{
				num7 = num + z0ZzZzzlh3.z0zrk() - 2f;
			}
			else
			{
				z0ZzZzzlh z0ZzZzzlh4 = p0.z0zek()[0];
				num7 = ((z0ZzZzzlh4 == null || !(z0ZzZzzlh4.z0xrk() > num2)) ? (-1f) : num2);
			}
			float num8 = z0ZzZzzej2.z0zek();
			int p2 = z0rek(z0ZzZzzej2.z0oek());
			z0wpk.z0iek = num8;
			for (float num9 = Math.Max(num, z0jrk.z0mek()); num9 < num7 - 2f; num9 += num8)
			{
				if (flag || !(num9 < (float)(z0jrk.z0mek() - 1)))
				{
					int num10 = z0wpk.z0eek(this, z0wpk.z0iek, p2: true, p2, 0, p5: true);
					z0rek(num10, z0ZzZzzej2.z0iek(), z0ZzZzzej2.z0vek(), z0wpk.z0rek);
				}
			}
		}
		bool flag4 = false;
		int num11 = 0;
		foreach (z0ZzZzzlh item in z0ZzZzkuk2.z0xrk())
		{
			float num12 = item.z0ytk();
			XTextElementList xTextElementList = ((xTextParagraphFlagElement == null) ? z0rek(item, p1: false, p2: false) : item);
			int count = xTextElementList.Count;
			bool flag5 = item.LastElement is XTextParagraphFlagElement || item.LastElement is z0ZzZzfkh || item.LastElement is XTextLineBreakElement || item.z0rek()?[0] is XTextHorizontalLineElement;
			bool flag6 = (item.z0fyk() == null || item.z0fyk().LastElement is XTextParagraphFlagElement) && item.LastElement is XTextParagraphFlagElement;
			if (z0ZzZzzlh3 == item)
			{
				float num13 = z0tek(item.z0xrk() - Math.Max(num + z0wpk.z0vek + z0ZzZzrzj2.z0quk, z0jrk.z0mek()));
				if (num13 > 2f)
				{
					z0cek("div");
					if (!z0irk)
					{
						if (!flag5)
						{
							z0uek("ipp", "nll");
						}
						else
						{
							z0uek("ipp", "ll");
						}
					}
					string p3 = null;
					if (z0lw() && z0trk.TryGetValue(num13, out p3))
					{
						z0lrk(p3);
					}
					else
					{
						base.z0oek();
						if (!(p0 is XTextTableCellElement) || z0ZzZzkuk2.Count != 1 || z0ZzZzzej2 != null)
						{
							z0yek("height", num13 + "px");
						}
						z0yek("overflow", "hidden");
						p3 = ((z0ZzZzfjh)this).z0zek();
						if (z0lw())
						{
							z0trk.Add(num13, p3);
						}
					}
					((z0ZzZzfjh)this).z0xek();
				}
			}
			z0ZzZzrzj z0ZzZzrzj3 = item.z0grk().z0aek();
			bool flag7 = true;
			if (z0ZzZzzej2 != null && z0ZzZzzej2.z0uek() && z0ZzZzzej2.z0cek())
			{
				flag7 = true;
			}
			else if (item.z0jrk_jiejie20260327142557() || item.z0qtk() || item.z0rtk() || item[0] is XTextHorizontalLineElement)
			{
				flag7 = false;
			}
			if (!flag7)
			{
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current2 = z0bpk.Current;
						if (current2 is XTextParagraphFlagElement)
						{
							continue;
						}
						XTextTableElement xTextTableElement = current2 as XTextTableElement;
						bool flag8 = false;
						if (z0ZzZzrzj3.z0tuk != DocumentContentAlignment.Left || (xTextTableElement != null && xTextTableElement.z0frk() != DCTableAlignment.Default))
						{
							z0cek("div");
							flag8 = true;
							if (z0ZzZzrzj3.z0tuk == DocumentContentAlignment.Center || (xTextTableElement != null && xTextTableElement.z0frk() == DCTableAlignment.Center))
							{
								z0uek("align", "center");
							}
							else if (z0ZzZzrzj3.z0tuk == DocumentContentAlignment.Right || (xTextTableElement != null && xTextTableElement.z0frk() == DCTableAlignment.Right))
							{
								z0uek("align", "right");
							}
						}
						z0uek(current2);
						if (flag8)
						{
							((z0ZzZzfjh)this).z0xek();
						}
					}
				}
				continue;
			}
			base.z0uek(0);
			z0cek("div");
			if (!z0irk)
			{
				if (!flag5)
				{
					z0uek("ipp", "nll");
				}
				else
				{
					z0uek("ipp", "ll");
				}
			}
			base.z0oek();
			if (!(p0 is XTextTableCellElement) || z0ZzZzkuk2.Count != 1 || item.Count > 2 || !(item[0] is XTextLabelElement) || !((XTextLabelElement)item[0]).Multiline)
			{
				z0yek("white-space", "nowrap");
			}
			bool p4 = false;
			int num14 = 0;
			if (z0ZzZzzej2 != null && z0ZzZzzej2.z0uek() && z0ZzZzzej2.z0yek())
			{
				z0ZzZzzej2.z0eek(bothBlackWhenPrint ? Color.Black : z0ZzZzzej2.z0iek());
				num14 = z0uek(z0ZzZzzej2.z0oek());
				float num15 = num2 - item.z0lrk();
				if (p0 is XTextDocumentBodyElement || (double)num15 > (double)item.z0ytk() * 0.5)
				{
					bool flag9 = true;
					if (item.z0mtk())
					{
						flag9 = false;
					}
					if (flag9)
					{
						z0yek("border-bottom-color", z0uek(z0ZzZzzej2.z0iek()));
						z0yek("border-bottom-style", z0ZzZzfjh.z0yek(z0ZzZzzej2.z0vek()));
						z0yek("border-bottom-width", base.z0iek(num14));
						p4 = true;
					}
				}
			}
			if (text != null)
			{
				z0yek("padding-left", text);
			}
			if (text2 != null)
			{
				z0yek("padding-right", text2);
			}
			int num16 = z0uek(item.z0atk());
			if (z0ZzZzkuk2.Count == 1 && z0ZzZzrzj2.z0quk <= 0f)
			{
				num16 = 0;
			}
			if (item.Count == 1 && item[0] is XTextHorizontalLineElement)
			{
				num16 = Math.Max(2, num16);
			}
			if (num16 > 0)
			{
				if (z0ZzZzzlh3 == item)
				{
					z0yek("padding-top", base.z0iek(Math.Max(1, num16 - 3)));
					num16 = Math.Max(1, num16 - 3);
				}
				else
				{
					z0yek("padding-top", base.z0iek(num16));
				}
			}
			bool flag10 = false;
			for (int num17 = xTextElementList.Count - 1; num17 >= 0; num17--)
			{
				XTextElement xTextElement = xTextElementList[num17];
				if ((xTextElement is XTextNewMedicalExpressionElement || xTextElement is XTextImageElement) && num12 < xTextElement.Height)
				{
					if (item.z0grk().z0aek().z0cyk == LineSpacingStyle.SpaceSpecify)
					{
						if (!flag10)
						{
							z0yek("overflow", "hidden");
							flag10 = true;
						}
					}
					else
					{
						num12 = xTextElement.Height;
					}
				}
			}
			float num18 = -1f;
			if (!flag && item.z0xek())
			{
				num12 = z0ZzZzbdh.z0tek(item.z0krk(), z0jrk.z0eek()).z0iek();
				num18 = z0wpk.z0iek;
			}
			if (p0 is XTextDocumentBodyElement)
			{
				Math.Abs(item.z0xrk() - z0wpk.z0vek);
				_ = 10f;
			}
			int num19 = z0wpk.z0eek(this, num12, p4, num14, num16, z0ZzZzzej2 != null);
			if (num18 > 0f)
			{
				z0wpk.z0iek = num18;
			}
			if (!(p0 is XTextTableCellElement) || z0ZzZzkuk2.Count != 1 || z0ZzZzzej2 != null)
			{
				z0yek("height", base.z0iek(num19));
			}
			string text3 = null;
			if (flag5 || (item.z0rek() != null && item.z0rek().z0rtk()))
			{
				switch (z0ZzZzrzj3.z0tuk)
				{
				case DocumentContentAlignment.Left:
					z0yek("text-align", "left");
					break;
				case DocumentContentAlignment.Center:
					z0yek("text-align", "center");
					break;
				case DocumentContentAlignment.Right:
					z0yek("text-align", "right");
					break;
				}
			}
			else
			{
				switch (z0ZzZzrzj3.z0tuk)
				{
				case DocumentContentAlignment.Left:
					text3 = "leftline";
					break;
				case DocumentContentAlignment.Center:
					text3 = "centerline";
					break;
				case DocumentContentAlignment.Right:
					text3 = "rightline";
					break;
				case DocumentContentAlignment.Justify:
					text3 = "justifyline";
					break;
				case DocumentContentAlignment.Distribute:
					text3 = "distributeline";
					break;
				}
				if (!item.z0jrk_jiejie20260327142557() && !item.z0qtk() && (!(item[0] is XTextCheckBoxElementBase) || !((XTextCheckBoxElementBase)item[0]).Multiline) && (!flag2 || z0ZzZzrzj3.z0tuk == DocumentContentAlignment.Left || item.Count != 1 || !(item[0] is XTextCharElement)))
				{
					z0yek("text-align-last", "justify");
				}
				z0yek("white-space", "nowrap");
				if (item[0] is XTextCheckBoxElementBase && ((XTextCheckBoxElementBase)item[0]).Multiline)
				{
					z0yek("word-break", "normal");
				}
				else
				{
					z0yek("word-break", "keep-all");
				}
				if (!flag2 || z0ZzZzrzj3.z0tuk == DocumentContentAlignment.Left || item.Count != 1 || !(item[0] is XTextCharElement))
				{
					z0yek("text-align", "justify");
				}
				z0yek("text-justify", "inter-ideograph");
				z0yek("layout-grid", "char loose 10pt none");
				z0yek("justify-content", "inherit");
			}
			if (item.z0vek() != 0f)
			{
				z0yek("padding-left", z0oek(item.z0vek()));
			}
			_ = p0 is XTextDocumentContentElement;
			string text4 = null;
			if ((count == 1 && xTextElementList[0] is XTextStringElement) || (count == 2 && xTextElementList[0] is XTextStringElement && xTextElementList[1] is XTextParagraphFlagElement))
			{
				XTextStringElement xTextStringElement = (XTextStringElement)xTextElementList[0];
				if (xTextStringElement.z0uek() > 0 && xTextStringElement.z0ji() == p0)
				{
					string text5 = xTextStringElement.Text;
					if (!(xTextStringElement.z0ji() is XTextTableCellElement { AutoFixFontSizeMode: not ContentAutoFixFontSizeMode.None }))
					{
						z0ZzZzrzj z0ZzZzrzj4 = xTextStringElement.z0aek();
						if (z0ZzZzrzj4.z0ork == DCBooleanValue.Inherit)
						{
							if (!z0ZzZzrzj4.z0gtk && !z0ZzZzrzj4.z0euk && z0ZzZzrzj4.z0vyk < 0 && z0ZzZzrzj4.z0ark.A == 0 && !z0ZzZzrzj4.z0wrk && !z0ZzZzrzj4.z0duk && z0ZzZzrzj4.z0yrk == CharacterCircleStyles.None)
							{
								z0ZzZzrzj4.z0ork = DCBooleanValue.True;
							}
							else
							{
								z0ZzZzrzj4.z0ork = DCBooleanValue.False;
							}
						}
						if (z0ZzZzrzj4.z0ork == DCBooleanValue.True)
						{
							if (z0xrk)
							{
								z0yek("color", "black");
							}
							else if (z0ZzZzrzj4.z0bek.A != 0)
							{
								z0yek("color", z0uek(z0ZzZzrzj4.z0bek));
							}
							z0yek(z0ZzZzrzj4.z0pek, text5);
							if (z0ZzZzqik.z0tek(text5))
							{
								z0yek("word-break", "break-word");
							}
							if (z0rek(xTextStringElement, xTextDocument))
							{
								z0vek("text-decoration");
							}
							if (text5 != null)
							{
								string[] array2 = text5.Split('，');
								string[] array3 = text5.Split('。');
								string[] array4 = text5.Split('：');
								string[] array5 = text5.Split('、');
								string[] array6 = text5.Split('（');
								string[] array7 = text5.Split('）');
								int num20 = array2.Length + array3.Length + array4.Length + array5.Length + array6.Length + array7.Length - 6;
								if (num20 != 0)
								{
									z0yek("letter-spacing", "-" + (double)Math.Abs(num20) * 0.1);
									if (!flag5 && !flag6)
									{
										z0yek("text-align-last", "justify");
									}
								}
							}
							text4 = text5;
						}
					}
				}
			}
			if (flag4 && z0wpk != null && num11 > 0)
			{
				string p5 = "-" + num11 + "px";
				z0yek("margin-top", p5);
			}
			if (item.Count > 0 && item.Count <= 2 && item[0] is XTextImageElement && ((XTextImageElement)item[0]).ZOrderStyle != ElementZOrderStyle.Normal)
			{
				flag4 = true;
				num11 = num19;
			}
			else
			{
				flag4 = false;
				num11 = 0;
			}
			((z0ZzZzfjh)this).z0zek();
			if (text3 != null)
			{
				z0lrk(text3);
			}
			if (text4 != null)
			{
				if (Options.LogUserEditTrack && (xTextElementList[0].z0xrk().CreatorIndex != -1 || xTextElementList[0].z0xrk().DeleterIndex != -1))
				{
					z0ZzZzonj p6 = xTextElementList[0].z0qt();
					z0rek(p6);
				}
				z0rek(text4, xTextElementList[0].z0aek(), !flag5 && !flag6);
				((z0ZzZzfjh)this).z0xek();
				continue;
			}
			if (count == 1 && xTextElementList[0] is XTextParagraphFlagElement)
			{
				if (Options.LogUserEditTrack)
				{
					z0cek("span");
					base.z0oek();
					z0rek(xTextElementList[0], xTextDocument);
					((z0ZzZzfjh)this).z0zek();
					base.z0yek('\u2002');
					((z0ZzZzfjh)this).z0xek();
				}
			}
			else
			{
				XTextInputFieldElement xTextInputFieldElement = null;
				Stack<XTextInputFieldElement> stack = new Stack<XTextInputFieldElement>();
				for (int k = 0; k < count; k++)
				{
					XTextElement xTextElement2 = xTextElementList[k];
					if (xTextElement2 is XTextParagraphFlagElement)
					{
						continue;
					}
					if (xTextElement2.z0ji() is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement2 = (XTextInputFieldElement)xTextElement2.z0ji();
						if (xTextElement2 is XTextFieldBorderElement && xTextElement2 == ((XTextFieldElementBase)xTextInputFieldElement2).z0jrk() && xTextElement2 == xTextElementList[count - 1] && !((XTextInputFieldElementBase)xTextInputFieldElement2).z0yek())
						{
							continue;
						}
						if (stack.Count == 0 || xTextInputFieldElement2 != stack.Peek())
						{
							if (stack.Count > 0)
							{
								XTextInputFieldElement xTextInputFieldElement3 = stack.Peek();
								if (xTextInputFieldElement3.z0ji() == xTextInputFieldElement2.z0ji())
								{
									((z0ZzZzfjh)this).z0xek();
									stack.Pop();
								}
								else if (xTextInputFieldElement3.z0ji() == xTextInputFieldElement2)
								{
									((z0ZzZzfjh)this).z0xek();
									stack.Pop();
									z0uek(xTextElement2);
									continue;
								}
							}
							stack.Push(xTextInputFieldElement2);
							z0cek("span");
							if (!z0irk)
							{
								z0uek("id", xTextInputFieldElement2.ID);
								z0uek("dctype", xTextInputFieldElement2.GetType().Name);
								if (xTextInputFieldElement2.Attributes != null && xTextInputFieldElement2.Attributes.Count > 0)
								{
									z0rek(xTextInputFieldElement2.Attributes);
								}
							}
							base.z0oek();
							z0rek(xTextInputFieldElement2, xTextInputFieldElement2.z0jr());
							z0rek(xTextInputFieldElement2.z0aek(), xTextInputFieldElement2);
							z0yek(xTextInputFieldElement2.z0aek().z0pek, null);
							z0yek("color", z0uek(xTextInputFieldElement2.z0aek().z0bek));
							float num21 = ((XTextInputFieldElementBase)xTextInputFieldElement2).z0tek();
							if ((Math.Abs(num21) > 0f && !((XTextInputFieldElementBase)xTextInputFieldElement2).z0qrk()) || num21 < 0f)
							{
								if (xTextElement2 == ((XTextFieldElementBase)xTextInputFieldElement2).z0tek() && xTextInputFieldElement2.z0qr("已输出最小宽度"))
								{
									xTextInputFieldElement2.Attributes.z0rek("已输出最小宽度");
								}
								else if ((xTextElement2 == ((XTextFieldElementBase)xTextInputFieldElement2).z0jrk() || !xTextInputFieldElement2.z0qr("已输出最小宽度")) && !xTextInputFieldElement2.z0ork())
								{
									if (num21 < 0f)
									{
										float num22 = Math.Abs(num21);
										if (!(xTextInputFieldElement2.z0ji() is XTextTableCellElement) || !(num22 > xTextInputFieldElement2.z0ji().Width))
										{
											z0yek("width", z0iek(num22));
											z0yek("overflow", "hidden");
										}
									}
									else
									{
										z0yek("min-width", z0iek(Math.Abs(num21)));
									}
									xTextInputFieldElement2.z0dr("已输出最小宽度", "1");
								}
								z0yek("display", "inline-block");
								if (!(xTextInputFieldElement2.z0ji() is XTextTableCellElement) || ((XTextTableCellElement)xTextInputFieldElement2.z0ji()).z0cr() != VerticalAlignStyle.Middle)
								{
									z0yek("line-height", "1!important");
								}
								z0yek("text-align-last", "auto");
								switch (xTextInputFieldElement2.Alignment)
								{
								case StringAlignment.Near:
									z0yek("text-align", "left");
									break;
								case StringAlignment.Center:
									z0yek("text-align", "center");
									break;
								case StringAlignment.Far:
									z0yek("text-align", "right");
									break;
								}
							}
							string text6 = ((XTextInputFieldElementBase)xTextInputFieldElement2).z0jrk();
							string text7 = null;
							if (xTextInputFieldElement2.EndBorderText != null && xTextInputFieldElement2.EndBorderText.Length > 0)
							{
								text7 = xTextInputFieldElement2.EndBorderText;
								if ((Options.DocumentOptions != null && Options.DocumentOptions.ViewOptions.IgnoreFieldBorderWhenPrint) || Options.DocumentOptions == null)
								{
									text7 = null;
								}
							}
							string text8 = null;
							if (text6 != null && text7 != null)
							{
								text8 = text6 + text7;
							}
							if (text8 == null && xTextElement2 == ((XTextFieldElementBase)xTextInputFieldElement2).z0tek() && xTextInputFieldElement2.z0xw() is XTextParagraphFlagElement)
							{
								z0yek("display", "none");
							}
							string text9 = ((z0ZzZzfjh)this).z0zek();
							if (text9 != null && text9.Length > 0 && !Options.ForPrint)
							{
								z0uek("localclass", text9);
							}
						}
					}
					else if (stack.Count > 0)
					{
						while (stack.Count > 0 && xTextElement2.z0ji() != stack.Peek())
						{
							XTextInputFieldElement xTextInputFieldElement4 = stack.Pop();
							if (!xTextInputFieldElement4.z0crk() && (!flag3 || !((XTextInputFieldElementBase)xTextInputFieldElement4).z0ark()))
							{
								base.z0yek('\u2002');
							}
							((z0ZzZzfjh)this).z0xek();
						}
					}
					z0uek(xTextElement2);
				}
				if (stack.Count > 0)
				{
					while (stack.Count > 0)
					{
						XTextInputFieldElement xTextInputFieldElement5 = stack.Pop();
						if (!xTextInputFieldElement5.z0crk() && (!flag3 || !((XTextInputFieldElementBase)xTextInputFieldElement5).z0ark()))
						{
							base.z0yek('\u200c');
						}
						((z0ZzZzfjh)this).z0xek();
					}
				}
				if (xTextInputFieldElement != null)
				{
					((z0ZzZzfjh)this).z0xek();
				}
			}
			((z0ZzZzfjh)this).z0xek();
		}
		p0.z0erk();
		if (p0 is XTextDocumentBodyElement)
		{
			z0tek(p0.z0jr());
		}
		if (z0ZzZzzej2 == null || !z0ZzZzzej2.z0uek() || !z0ZzZzzej2.z0cek() || !(z0ZzZzzej2.z0zek() > 0f) || (z0ZzZzkuk2.Count != 0 && z0ZzZzkuk2.LastElement == null))
		{
			return;
		}
		z0ZzZzzlh z0ZzZzzlh5 = ((z0ZzZzkuk2.Count != 0) ? z0ZzZzkuk2.LastElement : null);
		if (p0 is XTextDocumentBodyElement)
		{
			if (!z0crk.z0bek())
			{
				num2 = Math.Max(num2, z0crk.z0nek());
			}
		}
		else if (p0.z0aek().z0mrk && p0.z0aek().z0wrk)
		{
			num2 -= 4f;
		}
		float num23 = num2;
		if (z0ZzZzzlh5 != null)
		{
			num23 = num2 - z0ZzZzzlh5.z0lrk();
		}
		float num24 = z0wpk.z0iek * 0.5f;
		num2 -= p0.z0cw();
		if (z0wpk.z0iek > 10f && num23 > num24)
		{
			if (p0 is XTextDocumentBodyElement)
			{
				num24 = -2f;
			}
			if (p0 is XTextTableCellElement && p0.z0cw() + z0wpk.z0vek < (float)z0yek().z0uek() - z0wpk.z0iek)
			{
				z0wpk.z0vek = (float)z0yek().z0uek() - p0.z0cw();
			}
			while (num2 - z0wpk.z0vek - z0wpk.z0iek > num24)
			{
				int num25 = z0wpk.z0eek(this, z0wpk.z0iek, p2: true, z0wpk.z0rek, 0, p5: true);
				z0rek(num25, z0ZzZzzej2.z0iek(), z0ZzZzzej2.z0vek(), z0ZzZzzej2.z0oek());
			}
			z0wpk.z0vek = num2;
		}
	}

	internal static string z0tek(string p0)
	{
		return p0 switch
		{
			"*" => "|0000|0|", 
			"#" => "#000000|1111|0.32|", 
			"$" => "#000000|0000|0.32|", 
			_ => p0, 
		};
	}

	public new void z0yek(bool p0)
	{
		z0rrk = p0;
	}

	public override void z0zq()
	{
		base.z0zq();
		if (z0drk != null)
		{
			z0drk.Clear();
			z0drk = null;
		}
		if (z0yrk != null)
		{
			z0yrk.Clear();
			z0yrk = null;
		}
		if (z0trk != null)
		{
			z0trk.Clear();
			z0trk = null;
		}
		if (z0lrk != null)
		{
			z0lrk.Clear();
			z0lrk = null;
		}
		z0krk = null;
		z0jtk = null;
		if (z0mrk != null)
		{
			z0mrk.Clear();
			z0mrk = null;
		}
		z0srk = null;
		z0hrk = null;
	}

	private void z0tek(XTextCheckBoxElementBase p0)
	{
		XTextCheckBoxElementBase.z0zjj z0zjj = p0.z0eek((z0ZzZzcxj)3);
		if (!z0zjj.z0tek)
		{
			return;
		}
		if (z0zjj.z0eek && p0.CheckAlignLeft)
		{
			z0rek(p0, p0.ID);
		}
		if (z0zjj.z0uek != null && z0zjj.z0uek.Length > 0)
		{
			if (p0.z0pek() && p0.AutoHeightForMultiline)
			{
				float p1 = p0.Width - p0.z0yek().z0rek();
				z0rek(z0zjj.z0uek, p0.z0aek(), p0, p1);
			}
			else
			{
				z0rek(z0zjj.z0uek, p0.z0aek(), p0, 0f);
			}
		}
		if (z0zjj.z0eek && !p0.CheckAlignLeft)
		{
			z0rek(p0, p0.ID);
		}
	}

	public static void z0rek(z0ZzZzrjh p0, XTextCheckBoxElement p1)
	{
		if (p1.CaptionFlowLayout)
		{
			p0.z0yek("dc_captionflowlayout", p1.CaptionFlowLayout);
		}
		if (!p1.Visible)
		{
			p0.z0yek("dc_visible", p1.Visible);
		}
		p0.z0yek("dc_height", z0ZzZzrpk.z0eek(p1.Height, GraphicsUnit.Document, GraphicsUnit.Pixel));
		p0.z0yek("dc_width", z0ZzZzrpk.z0eek(p1.Width, GraphicsUnit.Document, GraphicsUnit.Pixel));
		p0.z0rek("dc_printvisibility", p1.PrintVisibility, ElementVisibility.Visible);
		p0.z0rek("dc_printvisibilitywhenunchecked", p1.PrintVisibilityWhenUnchecked, PrintVisibilityModeWhenUnchecked.Visible);
		p0.z0iek("dc_printtextforchecked", p1.PrintTextForChecked);
		if (p1.PrintTextForUnChecked != null && p1.PrintTextForUnChecked.Length > 0)
		{
			p0.z0uek("dc_printtextforunchecked", p1.PrintTextForUnChecked);
		}
		p0.z0rek(p1.Attributes);
		if (p1.BringoutToSave)
		{
			p0.z0yek("dc_bringouttosave", p1.BringoutToSave);
		}
		if (p1.CanBeReferenced)
		{
			p0.z0yek("dc_canbereferenced", p1.CanBeReferenced);
		}
		if (p1.Caption != null && p1.Caption.Length > 0)
		{
			p0.z0uek("dc_caption", p1.Caption);
		}
		p0.z0rek("dc_captionalign", p1.CaptionAlign, StringAlignment.Center);
		if (!p1.CheckAlignLeft)
		{
			p0.z0yek("dc_checkalignleft", p1.CheckAlignLeft);
		}
		p0.z0rek("dc_checkboxvisibility", p1.CheckboxVisibility, RenderVisibility.All);
		p0.z0rek("dc_contentreadonly", p1.ContentReadonly, ContentReadonlyState.Inherit);
		p0.z0rek("dc_controlstyle", p1.z0oi(), CheckBoxControlStyle.CheckBox);
		if (!p1.Deleteable)
		{
			p0.z0yek("dc_deleteable", p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0yek("dc_enabled", p1.Enabled);
		}
		p0.z0rek("dc_enablehighlight", p1.EnableHighlight, EnableState.Enabled);
		if (((XTextObjectElement)p1).z0iek() != null)
		{
			p0.z0uek("dc_linkinfo", z0ZzZzmik.z0rek(((XTextObjectElement)p1).z0iek(), p1: true));
		}
		if (p1.Multiline)
		{
			p0.z0yek("dc_multiline", p1.Multiline);
		}
		if (p1.AutoHeightForMultiline)
		{
			p0.z0yek("dc_autoheightformultiline", p1.AutoHeightForMultiline);
		}
		if (p1.Name != null && p1.Name.Length > 0)
		{
			p0.z0uek("dc_name", p1.Name);
		}
		if (p1.PrintTextForChecked != null && p1.PrintTextForChecked.Length > 0)
		{
			p0.z0uek("dc_printtextforchecked", p1.PrintTextForChecked);
		}
		if (p1.PrintTextForUnChecked != null && p1.PrintTextForUnChecked.Length > 0)
		{
			p0.z0uek("dc_printtextforunchecked", p1.PrintTextForUnChecked);
		}
		if (p1.PropertyExpressions != null && p1.PropertyExpressions.Count > 0)
		{
			p0.z0uek("dc_propertyexpressions", ((z0ZzZzcuk)p1.PropertyExpressions).DCWriteString());
		}
		if (p1.Requried)
		{
			p0.z0yek("dc_requried", p1.Requried);
		}
		if (p1.StringTag != null && p1.StringTag.Length > 0)
		{
			p0.z0uek("dc_stringtag", p1.StringTag);
		}
		if (p1.ToolTip != null && p1.ToolTip.Length > 0)
		{
			p0.z0uek("dc_tooltip", p1.ToolTip);
		}
		if (p1.ValueBinding != null)
		{
			p0.z0uek("dc_valuebinding", ((z0ZzZzcuk)p1.ValueBinding).DCWriteString());
		}
		if (p1.ValueExpression != null && p1.ValueExpression.Length > 0)
		{
			p0.z0uek("dc_valueexpression", p1.ValueExpression);
		}
		p0.z0rek("dc_visualstyle", p1.VisualStyle, CheckBoxVisualStyle.Default);
	}

	private void z0rek(XTextParagraphListItemElement p0)
	{
		if (Options.ForPrint)
		{
			XTextParagraphListItemElement.z0jmk z0jmk = new XTextParagraphListItemElement.z0jmk(p0, p1: false, p2: false);
			if (z0jmk.z0tek != null && z0jmk.z0tek.Length > 0)
			{
				z0cek("span");
				base.z0oek();
				z0yek(z0jmk.z0uek, z0jmk.z0tek);
				z0yek("color", z0uek(z0jmk.z0rek));
				z0yek("display", "inline-block");
				z0yek("width", z0uek(p0.Width) + "px");
				z0yek("text-align", "left");
				((z0ZzZzfjh)this).z0zek();
				z0yek(z0jmk.z0tek);
				((z0ZzZzfjh)this).z0xek();
			}
		}
	}

	public string z0oek(float p0)
	{
		if (p0 <= 0f)
		{
			return "0px";
		}
		float num = z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, GraphicsUnit.Pixel);
		if (num == 0f)
		{
			num = 1f;
		}
		return base.z0uek(num);
	}

	public int z0rek(object p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		z0rek(this, p0);
		return 0;
	}

	private void z0rek(XTextPageBreakElement p0)
	{
		if (!z0iek() && !Options.ForPrint)
		{
			z0cek("input");
			z0uek("type", "button");
			z0rek(p0.GetType());
			z0uek("onclick", "DCDomTools.MoveCaretToEnd(this);this.focus();");
			z0rek(p0, p0.z0jr());
			z0uek("style", "width:100%;background-color:yellow;text-align:center;border-top:none;border-bottom:1px dashed black");
			z0uek("value", z0ZzZziok.z0cuk());
			z0yrk();
		}
	}

	public void z0rek(z0ZzZzndh p0)
	{
		z0jrk = p0;
	}

	public new bool z0mek()
	{
		return z0brk;
	}

	internal new void z0nek()
	{
		if (z0hrk == null)
		{
			z0hrk = new z0ZzZzgbj();
		}
		XTextDocument xTextDocument = z0cek();
		z0erk = xTextDocument.z0iu();
	}

	private new bool z0bek()
	{
		return z0frk;
	}

	public void z0tek(XTextContentElement p0)
	{
		if (z0vrk)
		{
			z0rek(p0);
		}
		else
		{
			if (!p0.z0wrk())
			{
				return;
			}
			z0ZzZzgbj options = Options;
			XTextElementList xTextElementList = p0.z0be();
			XTextParagraphFlagElement xTextParagraphFlagElement = xTextElementList.z0zek();
			bool flag = z0jrk.z0vek();
			XTextDocument xTextDocument = p0.z0jr();
			p0.z0erk();
			if (flag && !z0brk)
			{
				if (xTextParagraphFlagElement == null)
				{
					z0ZzZzzlh[] array = p0.z0zek();
					for (int num = array.Length - 1; num >= 0; num--)
					{
						array[num].z0oek(p0: true);
					}
				}
				else if (p0.z0zek() != null && p0.z0zek().Length != 0)
				{
					p0.z0zek()[0].z0oek(p0: true);
				}
			}
			else
			{
				z0ZzZzzlh[] array2 = p0.z0zek();
				foreach (z0ZzZzzlh z0ZzZzzlh2 in array2)
				{
					z0ZzZzzlh2.z0oek(p0: true);
					if (!flag && z0ZzZzndh.z0tek(z0jrk, z0ZzZzndh.z0eek(z0ZzZzzlh2.z0krk())).z0oek() < 5)
					{
						z0ZzZzzlh2.z0oek(p0: false);
					}
					if (z0ZzZzzlh2.z0oek() && z0brk && !z0ZzZzzlh2.z0ktk())
					{
						z0ZzZzzlh2.z0oek(p0: false);
					}
				}
			}
			bool flag2 = false;
			List<XTextParagraphFlagElement> list = null;
			zzz.z0ZzZzjik<XTextParagraphFlagElement, List<XTextElementList>> z0ZzZzjik2 = null;
			DocumentContentStyle documentContentStyle = xTextDocument.z0dik();
			ParagraphListStyle paragraphListStyle = documentContentStyle.ParagraphListStyle;
			XTextElement xTextElement = null;
			IList<XTextParagraphFlagElement> list2 = null;
			if (xTextParagraphFlagElement == null)
			{
				z0ZzZzjik2 = p0.z0eek(z0brk, options.ExcludeLogicDeleted, z0jrk, p3: false);
				list2 = z0ZzZzjik2.z0yek();
			}
			else
			{
				list2 = new XTextParagraphFlagElement[1] { xTextParagraphFlagElement };
			}
			foreach (XTextParagraphFlagElement item in list2)
			{
				List<XTextElementList> list3 = z0ZzZzjik2?.z0tek(item);
				if (!flag)
				{
					bool flag3 = item.z0zy(this);
					if (!flag3 && list3 != null)
					{
						foreach (XTextElementList item2 in list3)
						{
							if (item2 is z0ZzZzzlh)
							{
								if (((z0ZzZzzlh)item2).z0oek())
								{
									flag3 = true;
									break;
								}
								continue;
							}
							using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = item2.z0ltk();
							while (z0bpk.MoveNext())
							{
								if (z0bpk.Current.z0zy(this))
								{
									flag3 = true;
									break;
								}
							}
						}
					}
					if (!flag3)
					{
						continue;
					}
				}
				z0ZzZzrzj z0ZzZzrzj2 = item.z0aek();
				bool flag4 = false;
				if (false)
				{
					z0cek("p");
					if (list != null && list.Contains(item))
					{
						z0uek("fixforhtmldiv", "true");
					}
					flag4 = true;
					documentContentStyle = z0ZzZzrzj2.z0yek();
					documentContentStyle.ParagraphListStyle = ParagraphListStyle.None;
					paragraphListStyle = ParagraphListStyle.None;
				}
				else
				{
					bool flag5 = item.z0xrk().ParagraphListStyle != ParagraphListStyle.None && item.z0ke() is XTextInputFieldElement && (item.z0ke().z0ke() == null || item.z0ke().z0ke() is XTextParagraphFlagElement);
					if (flag5)
					{
						XTextInputFieldElement xTextInputFieldElement = item.z0ke() as XTextInputFieldElement;
						XTextElementList xTextElementList2 = xTextInputFieldElement.z0nek<XTextParagraphFlagElement>();
						if (xTextElementList2.Count == 0 || xTextElementList2[0].z0xrk().ParagraphListStyle == ParagraphListStyle.None)
						{
							flag5 = false;
						}
						else
						{
							xTextInputFieldElement.z0be().Add(item.z0lr(p0: true));
							item.z0xrk().ParagraphListStyle = ParagraphListStyle.None;
							documentContentStyle = z0ZzZzrzj2.z0yek();
							documentContentStyle.ParagraphListStyle = ParagraphListStyle.None;
							paragraphListStyle = ParagraphListStyle.None;
						}
					}
					if (paragraphListStyle != z0ZzZzrzj2.z0brk && !flag5)
					{
						if (documentContentStyle.ParagraphListStyle != ParagraphListStyle.None)
						{
							z0yrk();
						}
						documentContentStyle = z0ZzZzrzj2.z0jrk;
						paragraphListStyle = documentContentStyle.ParagraphListStyle;
						if (documentContentStyle.IsBulletedList)
						{
							z0cek("ul");
							z0uek("dcparagraphlistformat", documentContentStyle.ParagraphListStyle.ToString());
							z0uek("style", "padding-inline-start:24px");
							flag4 = true;
						}
						else if (documentContentStyle.IsListNumberStyle || documentContentStyle.ParagraphListStyle == ParagraphListStyle.ListNumberStyleArabic3)
						{
							z0cek("ol");
							z0uek("dcparagraphlistformat", documentContentStyle.ParagraphListStyle.ToString());
							z0uek("style", "padding-inline-start:24px");
							flag4 = true;
						}
					}
					if (paragraphListStyle != ParagraphListStyle.None)
					{
						z0cek("li");
						flag4 = true;
					}
					else
					{
						z0cek("p");
						if (list != null && list.Contains(item))
						{
							z0uek("fixforhtmldiv", "true");
						}
						flag4 = true;
					}
				}
				switch (z0ZzZzrzj2.z0tuk)
				{
				case DocumentContentAlignment.Left:
					z0uek("align", "left");
					break;
				case DocumentContentAlignment.Center:
					z0uek("align", "center");
					break;
				case DocumentContentAlignment.Right:
					z0uek("align", "right");
					break;
				case DocumentContentAlignment.Justify:
					z0uek("align", "justify");
					break;
				case DocumentContentAlignment.Distribute:
					z0uek("align", "justify");
					break;
				}
				if (z0ZzZzrzj2.z0hyk != 0f)
				{
					z0uek("dc_leftindent", z0ZzZzrzj2.z0hyk.ToString());
				}
				if (z0ZzZzrzj2.z0pyk != 0f)
				{
					z0uek("dc_firstlineindent", z0ZzZzrzj2.z0pyk.ToString());
				}
				bool flag6 = xTextParagraphFlagElement == null && xTextElementList.Count > 1 && z0rek(item);
				bool flag7 = true;
				if (flag6)
				{
					flag7 = false;
				}
				else if (z0ZzZzrzj2.z0tuk != DocumentContentAlignment.Left && !(p0 is XTextTableCellElement))
				{
					flag7 = false;
				}
				else if (paragraphListStyle != ParagraphListStyle.None && documentContentStyle.IsBulletedList)
				{
					flag7 = false;
				}
				if (flag7 && options.UseClassAttribute && z0ZzZzrzj2.z0drk != null)
				{
					z0zrk++;
					z0uek("class", z0ZzZzrzj2.z0drk);
				}
				else
				{
					base.z0oek();
					if (paragraphListStyle != ParagraphListStyle.None && documentContentStyle.IsBulletedList)
					{
						z0yek("list-style-type", "none");
					}
					z0rek(z0ZzZzrzj2, item, p2: false);
					if (z0ZzZzrzj2.z0pek != null)
					{
						z0yek(z0ZzZzrzj2.z0pek, null);
					}
					z0yek("word-wrap", "break-word");
					if (flag6)
					{
						z0yek("word-break", "break-word");
					}
					else
					{
						z0yek("word-break", "break-all");
					}
					if (Options.DocumentOptions != null && Options.DocumentOptions.BehaviorOptions != null && Options.DocumentOptions.BehaviorOptions.WordBreak == DCWordBreakStyle.BreakAll)
					{
						z0yek("word-break", "break-all");
					}
					if (z0trk() != (z0ZzZzjok)5 && z0trk() != (z0ZzZzjok)6)
					{
						z0trk();
						_ = 7;
					}
					if (options.KeepLineBreak && !(p0 is XTextTableCellElement) && (z0ZzZzrzj2.z0tuk == DocumentContentAlignment.Right || z0ZzZzrzj2.z0tuk == DocumentContentAlignment.Center))
					{
						z0yek("width", z0ZzZzrpk.z0eek(((XTextElement)p0).z0ork() + 4f, GraphicsUnit.Document, (z0ZzZzkpk)5));
					}
					string text = null;
					if (xTextParagraphFlagElement != null)
					{
						z0rek(item, xTextDocument);
						text = ((z0ZzZzfjh)this).z0zek();
					}
					else
					{
						text = ((z0ZzZzfjh)this).z0zek();
					}
					if (flag7 && text != null)
					{
						z0ZzZzrzj2.z0drk = text;
					}
				}
				if (xTextParagraphFlagElement != null)
				{
					z0uek("empty", "1");
				}
				else if (z0lw())
				{
					string text2 = null;
					z0ZzZzzej z0ZzZzzej2 = p0.z0ju();
					if (z0ZzZzzej2 != null && z0ZzZzzej2.z0uek() && z0ZzZzzej2.z0cek() && z0ZzZzzej2.z0zek() > 0f)
					{
						text2 = z0yek(z0ZzZzzej2.z0zek());
					}
					if (text2 != null && text2.Length > 0)
					{
						z0uek("style", "line-height:" + text2);
						z0uek("gridlineheight", text2);
					}
				}
				if (item.z0krk() >= 0)
				{
					z0cek("a");
					z0uek("name", "DCTopic_" + item.z0krk());
					z0yrk();
				}
				int num2 = 0;
				if (list3 == null)
				{
					if (p0 is XTextTableCellElement)
					{
						z0cek("br");
						z0uek("dcpf", "1");
						z0yrk();
					}
					else
					{
						z0uek("blank", "true");
						z0cek("br");
						z0uek("dcignore", "1");
						z0yrk();
					}
				}
				else
				{
					foreach (XTextElementList item3 in list3)
					{
						XTextElementList xTextElementList3 = z0rek(item3, z0brk, options.ExcludeLogicDeleted);
						if ((item3.Count == 1 && item3.LastElement is XTextParagraphFlagElement) || xTextElementList3.Count == 0)
						{
							if (p0 is XTextTableCellElement)
							{
								z0cek("br");
								z0uek("dcpf", "1");
								z0yrk();
							}
							else
							{
								z0uek(z0urk);
							}
						}
						int num3 = -1;
						if (xTextElement != null)
						{
							num3 = xTextElementList3.IndexOf(xTextElement);
							if (num3 < 0)
							{
								continue;
							}
							xTextElement = null;
						}
						bool flag8 = false;
						if (num2 > 0 && p0 is XTextDocumentContentElement && options.KeepLineBreak)
						{
							flag8 = true;
						}
						if (flag8)
						{
							z0cek("br");
							z0yrk();
						}
						num2++;
						int count = xTextElementList3.Count;
						for (int j = num3 + 1; j < count; j++)
						{
							XTextElement xTextElement2 = xTextElementList3[j];
							_ = xTextElement2 is XTextFieldBorderElement;
							z0uek(xTextElement2);
						}
						if (xTextElementList3 != item3)
						{
							xTextElementList3.z0vrk();
						}
					}
				}
				p0.z0erk();
				if (!flag4)
				{
					continue;
				}
				if (list3 != null && list3.Count > 0)
				{
					XTextElementList xTextElementList4 = list3[list3.Count - 1];
					if (xTextElementList4.Count >= 2 && xTextElementList4[xTextElementList4.Count - 2] is XTextLineBreakElement)
					{
						z0cek("br");
						z0uek("dcautogen", "1");
						z0yrk();
					}
				}
				((z0ZzZzfjh)this).z0xek();
			}
			if (flag2)
			{
				for (int num4 = p0.z0be().Count - 1; num4 >= 0; num4--)
				{
					if (p0.z0be()[num4] is z0ZzZzqjh)
					{
						p0.z0be().RemoveAt(num4);
					}
				}
			}
			if (paragraphListStyle != ParagraphListStyle.None)
			{
				z0yrk();
			}
		}
	}

	private void z0rek(XTextImageElement p0)
	{
		bool flag = p0.z0frk() == null || !p0.z0frk().HasContent;
		p0.z0rek((flag && !p0.z0mrk()) || (flag && p0.z0mrk() && p0.z0jr().z0nmk().Count == 0));
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string text = z0rrk();
		if (text != null && text.Length > 0)
		{
			dictionary["title"] = text;
		}
		switch (p0.VAlign)
		{
		case VerticalAlignStyle.Top:
			dictionary["align"] = "top";
			break;
		case VerticalAlignStyle.Middle:
			dictionary["align"] = "middle";
			break;
		case VerticalAlignStyle.Bottom:
			dictionary["align"] = "bottom";
			break;
		}
		if (!p0.SaveContentInFile && p0.z0mek() != null && p0.z0mek().Length > 0)
		{
			dictionary["src"] = p0.z0mek();
		}
		z0eek(p0, dictionary);
	}

	private new void z0vek()
	{
		Options.ForPrint = false;
		Options.KeepLineBreak = false;
		z0hw();
		z0cek("div");
		z0rek(z0ZzZzndh.z0cek);
		XTextDocument xTextDocument = z0cek();
		if (z0zek() != null && z0zek().Count > 0)
		{
			if (Options.OutputHeaderFooter && xTextDocument.z0pyk().z0fi() && xTextDocument.PageSettings.z0mek())
			{
				z0uek(xTextDocument.z0pyk());
				bool flag = xTextDocument.z0iu().ShowHeaderBottomLine;
				if (xTextDocument.z0ipk() != null && xTextDocument.z0ipk().ShowHeaderBottomLine != DCBooleanValue.Inherit)
				{
					flag = xTextDocument.z0ipk().ShowHeaderBottomLine == DCBooleanValue.True;
				}
				if (flag && ((XTextContainerElement)xTextDocument.z0pyk()).z0xek() >= 2)
				{
					z0cek("hr");
					float headerBottomLineWidth = xTextDocument.z0iu().HeaderBottomLineWidth;
					if (headerBottomLineWidth > 1f)
					{
						z0uek("size", headerBottomLineWidth.ToString());
					}
					z0yrk();
				}
			}
			if (z0mek())
			{
				XTextDocument xTextDocument2 = z0zek()[0];
				z0uek(xTextDocument2.z0jrk());
			}
			else
			{
				foreach (XTextDocument item in z0zek())
				{
					z0uek(item.z0xyk());
				}
			}
			if (Options.OutputHeaderFooter && xTextDocument.z0lik().z0fi() && xTextDocument.PageSettings.z0mek())
			{
				z0uek(xTextDocument.z0lik());
			}
		}
		z0yrk();
		((z0ZzZzfjh)this).z0iek();
	}

	private void z0tek(XTextStringElement p0)
	{
		XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p0.z0ji();
		z0cek("span");
		z0lrk("dcbgtxt");
		base.z0oek();
		if (Options.ForPrint && !xTextInputFieldElement.z0so())
		{
			z0yek("visibility", "hidden");
			if (xTextInputFieldElement.SpecifyWidth == 0f)
			{
				z0yek("display", "none");
			}
		}
		Color p1 = ((XTextFieldElementBase)xTextInputFieldElement).z0eek();
		if (p1.R == 254 && p1.G == 254 && p1.B == 254)
		{
			p1 = Color.Transparent;
		}
		z0yek("color", z0uek(p1));
		z0yek(p0.z0aek().z0pek, p0.Text);
		if (((XTextFieldElementBase)xTextInputFieldElement).z0drk() == DCBooleanValueHasDefault.True)
		{
			z0yek("font-style", "italic");
		}
		else if (((XTextFieldElementBase)xTextInputFieldElement).z0drk() == DCBooleanValueHasDefault.False)
		{
			z0yek("font-style", "normal");
		}
		((z0ZzZzfjh)this).z0zek();
		if (p0.Text != null)
		{
			string text = p0.Text;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (c == ' ')
				{
					z0zek("ensp");
				}
				else
				{
					z0yek(c.ToString());
				}
			}
		}
		((z0ZzZzfjh)this).z0xek();
	}

	public new XTextDocument z0cek()
	{
		if (z0srk == null && z0jtk != null)
		{
			return z0jtk.z0rek();
		}
		return z0srk;
	}

	public static void z0rek(z0ZzZzrjh p0, XTextTDBarcodeElement p1)
	{
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0uek("dc_printvisibility", z0ZzZzzyk.z0eek(typeof(ElementVisibility), p1.PrintVisibility));
		}
		p0.z0rek(p1.Attributes);
		if (p1.BarcodeType != DCTDBarcodeType.QR)
		{
			p0.z0uek("dc_barcodetype", z0ZzZzzyk.z0eek(typeof(DCTDBarcodeType), p1.BarcodeType));
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0uek("dc_contentreadonly", z0ZzZzzyk.z0eek(typeof(ContentReadonlyState), p1.ContentReadonly));
		}
		if (!p1.Deleteable)
		{
			p0.z0yek("dc_deleteable", p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0yek("dc_enabled", p1.Enabled);
		}
		if (p1.ErroeCorrectionLevel != DCTBErroeCorrectionLevelType.M)
		{
			p0.z0uek("dc_erroecorrectionlevel", z0ZzZzzyk.z0eek(typeof(DCTBErroeCorrectionLevelType), p1.ErroeCorrectionLevel));
		}
		p0.z0yek("dc_height", p1.Height);
		if (p1.ID != null && p1.ID.Length > 0)
		{
			p0.z0uek("id", p1.ID);
		}
		if (p1.z0iek() != null)
		{
			p0.z0uek("dc_linkinfo", z0ZzZzmik.z0rek(p1.z0iek(), p1: true));
		}
		if (p1.Name != null && p1.Name.Length > 0)
		{
			p0.z0uek("dc_name", p1.Name);
		}
		if (p1.PropertyExpressions != null && p1.PropertyExpressions.Count > 0)
		{
			p0.z0uek("dc_propertyexpressions", ((z0ZzZzcuk)p1.PropertyExpressions).DCWriteString());
		}
		if (p1.StrictMatchPageIndex)
		{
			p0.z0yek("dc_strictmatchpageindex", p1.StrictMatchPageIndex);
		}
		if (p1.StringTag != null && p1.StringTag.Length > 0)
		{
			p0.z0uek("dc_stringtag", p1.StringTag);
		}
		if (p1.VAlign != VerticalAlignStyle.Bottom)
		{
			p0.z0uek("dc_valign", z0ZzZzzyk.z0eek(typeof(VerticalAlignStyle), p1.VAlign));
		}
		if (p1.ValueBinding != null)
		{
			p0.z0uek("dc_valuebinding", ((z0ZzZzcuk)p1.ValueBinding).DCWriteString());
		}
		if (p1.ValueExpression != null && p1.ValueExpression.Length > 0)
		{
			p0.z0uek("dc_valueexpression", p1.ValueExpression);
		}
	}

	public new z0ZzZzbdh z0xek()
	{
		return z0crk;
	}

	public new z0ZzZzclh z0zek()
	{
		return z0jtk;
	}

	private void z0rek(XTextNewMedicalExpressionElement p0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["dc_innerserializetext"] = p0.Values.DCWriteString();
		dictionary["align"] = "middle";
		z0eek(p0, dictionary);
	}
}
