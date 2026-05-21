using System;
using System.Collections.Generic;
using System.Text;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzlcj
{
	private class z0mok
	{
		public readonly float z0eek;

		public readonly char z0rek;

		public z0mok(char p0, float p1)
		{
			z0rek = p0;
			z0eek = p1;
		}
	}

	private class z0lmk
	{
		public char z0rek;

		public string z0tek;

		public char z0yek;

		public bool z0eek(char p0)
		{
			if (p0 >= z0rek)
			{
				return p0 <= z0yek;
			}
			return false;
		}
	}

	internal class z0uhj
	{
		private class z0ihj
		{
			public readonly string z0eek;

			public readonly GraphicsUnit z0rek;

			public readonly MeasureMode z0tek;

			public readonly GraphicsUnit z0yek;

			private readonly int z0uek;

			public readonly bool z0iek;

			public readonly FontStyle z0oek;

			public override bool Equals(object obj)
			{
				if (this == obj)
				{
					return true;
				}
				z0ihj z0ihj = (z0ihj)obj;
				if (z0eek == z0ihj.z0eek && z0oek == z0ihj.z0oek && z0rek == z0ihj.z0rek && z0tek == z0ihj.z0tek && z0iek == z0ihj.z0iek)
				{
					return z0yek == z0ihj.z0yek;
				}
				return false;
			}

			public z0ihj(string p0, FontStyle p1, GraphicsUnit p2, MeasureMode p3, bool p4, GraphicsUnit p5)
			{
				z0eek = p0;
				z0oek = p1;
				z0rek = p2;
				z0tek = p3;
				z0iek = p4;
				z0yek = p5;
				z0uek = (int)(p0.GetHashCode() + 1000 * (int)z0oek + 100 * (int)z0rek + 10 * (int)z0tek + z0yek);
			}

			public override int GetHashCode()
			{
				return z0uek;
			}
		}

		internal readonly string z0yek;

		internal const float z0uek = 10f;

		internal readonly float z0iek;

		[NonSerialized]
		private z0ZzZzsdh z0oek;

		private readonly float[] z0pek;

		private readonly Dictionary<char, float> z0mek = new Dictionary<char, float>();

		private readonly int[] z0nek;

		private readonly float z0bek;

		internal readonly float z0vek;

		private readonly z0ZzZzqpk z0cek;

		internal readonly float z0xek = 1f;

		[NonSerialized]
		private GraphicsUnit z0zek = GraphicsUnit.Document;

		[NonSerialized]
		private z0ZzZzpij z0lrk;

		private static readonly Dictionary<z0ihj, z0uhj> z0krk = new Dictionary<z0ihj, z0uhj>();

		private readonly float z0jrk;

		private readonly float[] z0hrk;

		internal readonly FontStyle z0grk;

		private readonly float z0frk = 1f;

		internal float z0eek(char p0)
		{
			if (z0ZzZzlcj.z0rek(p0))
			{
				return z0vek;
			}
			switch (p0)
			{
			case '\t':
			case ' ':
				return z0jrk;
			case '!':
			case '"':
			case '#':
			case '$':
			case '%':
			case '&':
			case '\'':
			case '(':
			case ')':
			case '*':
			case '+':
			case ',':
			case '-':
			case '.':
			case '/':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
			case ':':
			case ';':
			case '<':
			case '=':
			case '>':
			case '?':
			case '@':
			case 'A':
			case 'B':
			case 'C':
			case 'D':
			case 'E':
			case 'F':
			case 'G':
			case 'H':
			case 'I':
			case 'J':
			case 'K':
			case 'L':
			case 'M':
			case 'N':
			case 'O':
			case 'P':
			case 'Q':
			case 'R':
			case 'S':
			case 'T':
			case 'U':
			case 'V':
			case 'W':
			case 'X':
			case 'Y':
			case 'Z':
			case '[':
			case '\\':
			case ']':
			case '^':
			case '_':
			case '`':
			case 'a':
			case 'b':
			case 'c':
			case 'd':
			case 'e':
			case 'f':
			case 'g':
			case 'h':
			case 'i':
			case 'j':
			case 'k':
			case 'l':
			case 'm':
			case 'n':
			case 'o':
			case 'p':
			case 'q':
			case 'r':
			case 's':
			case 't':
			case 'u':
			case 'v':
			case 'w':
			case 'x':
			case 'y':
			case 'z':
			case '{':
			case '|':
			case '}':
			case '~':
				if (z0cek == (z0ZzZzqpk)1)
				{
					return z0bek * z0xek;
				}
				return z0hrk[(uint)p0] * z0xek;
			default:
				if (z0nek != null)
				{
					float num = z0rek(p0);
					if (num >= 0f)
					{
						return num;
					}
				}
				if (z0mek.Count > 0)
				{
					float result = 0f;
					if (z0mek.TryGetValue(p0, out result))
					{
						return result;
					}
				}
				return -1f;
			}
		}

		public static void z0eek()
		{
		}

		private float z0rek(char p0)
		{
			if (z0nek != null)
			{
				int num = z0eek(z0nek, p0);
				if (num >= 0)
				{
					return z0pek[num];
				}
			}
			return -1f;
		}

		internal void z0eek(char p0, float p1, float p2)
		{
			z0mek[p0] = p1;
		}

		internal static z0uhj z0eek(z0ZzZzumk p0, z0ZzZzadh p1, MeasureMode p2, bool p3)
		{
			z0uhj z0uhj = null;
			z0ihj z0ihj = new z0ihj(p0.z0pek, p0.z0mek, p0.z0iek, p2, p3, p1.z0jrk());
			if (!z0krk.TryGetValue(z0ihj, out z0uhj))
			{
				z0uhj = new z0uhj(z0ihj, p1);
				z0krk[z0ihj] = z0uhj;
			}
			return z0uhj;
		}

		public static int z0eek(int[] p0, int p1)
		{
			if (p0 != null && p0.Length != 0 && p0.Length % 2 == 0)
			{
				int num = 0;
				int num2 = p0.Length >> 1;
				while (num2 > num)
				{
					int num3 = num + num2 >> 1;
					if (num3 == num)
					{
						break;
					}
					int num4 = num3 << 1;
					if (p1 < p0[num4])
					{
						num2 = num3;
						continue;
					}
					if (p1 <= p0[num4 + 1])
					{
						return num3;
					}
					num = num3;
				}
			}
			return -1;
		}

		public bool z0eek(FontStyle p0)
		{
			if (z0lrk != null)
			{
				return z0lrk.z0eek(p0);
			}
			return false;
		}

		private float z0eek(z0ZzZzadh p0, char p1, z0ZzZzlsh p2)
		{
			return z0lrk.z0rek(p1, 10f, z0zek) * z0frk;
		}

		internal bool z0tek(char p0)
		{
			if (z0nek != null && z0eek(z0nek, p0) >= 0)
			{
				return true;
			}
			return false;
		}

		public void z0rek()
		{
		}

		private z0uhj(z0ihj p0, z0ZzZzadh p1)
		{
			z0yek = z0ZzZzimk.z0eek(p0.z0eek, p1: false);
			z0grk = p0.z0oek;
			z0cek = (z0ZzZzqpk)0;
			z0ZzZzlsh p2 = z0ZzZzlcj.z0vek;
			z0lrk = z0ZzZzpij.z0eek(z0yek, p0.z0oek, p0.z0rek);
			if (z0lrk == null)
			{
				string text = "系统不支持字体:" + z0yek + " " + p0.z0oek;
				z0ZzZzqok.z0rek.z0sh(text);
				throw new NotSupportedException(text);
			}
			if (p0.z0tek == MeasureMode.OldCompatibility)
			{
				p2 = z0ZzZzlsh.z0uek();
			}
			if ((z0grk & FontStyle.Bold) == FontStyle.Bold)
			{
				z0xek = z0lrk.z0trk;
			}
			z0zek = p1.z0jrk();
			float num = z0eek(p1, 'W', p2);
			float num2 = z0eek(p1, 'i', p2);
			if (num == num2)
			{
				if (num == 0f)
				{
					z0bek = -1f;
				}
				else
				{
					z0bek = num;
				}
				z0cek = (z0ZzZzqpk)1;
			}
			else
			{
				z0cek = (z0ZzZzqpk)0;
				z0hrk = new float[127];
				for (int i = 0; i < z0hrk.Length; i++)
				{
					z0hrk[i] = z0eek(p1, (char)i, p2);
				}
			}
			z0vek = z0eek(p1, '袁', p2);
			if (z0vek == 0f)
			{
				z0vek = -1f;
			}
			z0jrk = z0eek(p1, ' ', p2);
			if ((double)z0jrk < 0.1)
			{
				z0jrk = z0eek(p1, 'i', p2);
			}
			if (p0.z0tek == MeasureMode.Default || p0.z0tek == MeasureMode.RichTextBoxCompatibility)
			{
				if (p0.z0iek)
				{
					num = z0eek(p1, ' ', z0ZzZzlsh.z0rek());
					z0jrk = num * 0.57f;
				}
				else
				{
					num = z0eek(p1, ' ', p2);
					z0jrk = num;
				}
			}
			z0iek = z0lrk.z0rek(10f, p1.z0jrk());
			z0nek = z0lrk.z0eek();
			if (z0nek != null && z0nek.Length != 0)
			{
				z0pek = new float[z0nek.Length / 2];
				for (int j = 0; j < z0nek.Length; j += 2)
				{
					char p3 = (char)z0nek[j];
					z0pek[j / 2] = z0eek(p1, p3, p2);
				}
			}
			if (z0oek != null)
			{
				z0oek.Dispose();
				z0oek = null;
			}
			if (z0hrk == null)
			{
				_ = z0cek;
			}
		}
	}

	private static readonly Dictionary<char, float> z0uek;

	private GraphicsUnit z0iek = GraphicsUnit.Document;

	private static readonly string[] z0oek;

	public static bool z0pek;

	private bool z0nek;

	private static readonly string z0bek;

	private static readonly z0ZzZzlsh z0vek;

	private static string z0cek;

	internal static string z0xek;

	private readonly float z0zek = 5f;

	internal static List<string> z0lrk;

	private static readonly StringBuilder z0krk;

	private MeasureMode z0hrk;

	private static readonly List<z0mok> z0frk;

	private static readonly List<z0lmk> z0drk;

	private static bool z0rek(char p0)
	{
		if (p0 >= '一' && p0 <= '龥')
		{
			return true;
		}
		if (p0 < '\u007f')
		{
			return false;
		}
		if (z0bek.Contains(p0))
		{
			return true;
		}
		return false;
	}

	public static z0ZzZzxdh z0rek(z0ZzZzjpk p0, string p1, z0ZzZzimk p2, int p3, z0ZzZzlsh p4)
	{
		return z0rek(p0.z0vek(), p1, p2.Name, p2.Size, p2.Style, p3, p4);
	}

	public static z0ZzZzpij z0rek(z0ZzZzsdh p0)
	{
		z0ZzZzpij z0ZzZzpij2 = z0ZzZzpij.z0eek(z0rek(p0.z0pek()), p0.z0mek());
		if (z0ZzZzpij2 == null)
		{
			z0ZzZzpij2 = z0ZzZzpij.z0eek(z0cek, p0.z0mek());
		}
		return z0ZzZzpij2;
	}

	public static z0ZzZzbdh[] z0rek(GraphicsUnit p0, string p1, string p2, float p3, FontStyle p4, z0ZzZzbdh p5, z0ZzZzlsh p6, out string[] p7)
	{
		if (string.IsNullOrEmpty(p1))
		{
			p7 = null;
			return null;
		}
		z0ZzZzxdh p8 = z0ZzZzxdh.z0yek;
		List<float> list = new List<float>();
		p7 = z0eek(p0, p1, p2, p3, p4, p5.z0uek(), p6, out p8, list);
		float num = p5.z0pek();
		StringAlignment stringAlignment = p6?.z0pek() ?? StringAlignment.Near;
		switch (p6?.z0tek() ?? StringAlignment.Near)
		{
		case StringAlignment.Center:
			num = p5.z0pek() + (p5.z0iek() - p8.z0tek()) / 2f;
			break;
		case StringAlignment.Far:
			num = p5.z0nek() - p8.z0tek();
			break;
		}
		float num2 = p8.z0tek() / (float)p7.Length;
		z0ZzZzbdh[] array = new z0ZzZzbdh[p7.Length];
		for (int i = 0; i < p7.Length; i++)
		{
			switch (stringAlignment)
			{
			case StringAlignment.Far:
				array[i] = new z0ZzZzbdh(p5.z0mek() - list[i], num, list[i], num2);
				break;
			case StringAlignment.Center:
				array[i] = new z0ZzZzbdh(p5.z0oek() + (p5.z0uek() - list[i]) / 2f, num, list[i], num2);
				break;
			default:
				array[i] = new z0ZzZzbdh(p5.z0oek(), num, list[i], num2);
				break;
			}
			num += num2;
		}
		return array;
	}

	public static z0ZzZzxdh z0rek(GraphicsUnit p0, char p1, z0ZzZzsdh p2)
	{
		z0ZzZzpij z0ZzZzpij2 = z0rek(p2);
		if (z0ZzZzpij2 != null)
		{
			float num = z0ZzZzpij2.z0rek(p1, p2.z0yek(), p0);
			if (num == 0f && z0ZzZzpij2.z0tek())
			{
				string text = z0ZzZzljh.z0eek().z0eek(p1);
				if (string.IsNullOrEmpty(text))
				{
					text = z0ZzZzimk.DefaultFontName;
				}
				z0ZzZzpij z0ZzZzpij3 = z0ZzZzpij.z0eek(text, z0ZzZzpij2.z0jrk);
				if (z0ZzZzpij3 == null)
				{
					z0ZzZzpij3 = z0ZzZzpij.z0eek(z0cek, z0ZzZzpij2.z0jrk);
				}
				if (z0ZzZzpij3 != null)
				{
					num = z0ZzZzpij3.z0rek(p1, p2.z0yek(), p0);
				}
			}
			return new z0ZzZzxdh(num, z0ZzZzpij2.z0rek(p2.z0yek(), p0));
		}
		return z0ZzZzxdh.z0yek;
	}

	public MeasureMode z0rek()
	{
		return z0hrk;
	}

	public static z0ZzZzxdh z0rek(GraphicsUnit p0, string p1, string p2, float p3, FontStyle p4, float p5, z0ZzZzlsh p6)
	{
		p2 = z0rek(p2);
		bool p7 = p6 == null || (p6.z0yek() & (z0ZzZzksh)4096) != (z0ZzZzksh)4096;
		z0ZzZzpij z0ZzZzpij2 = z0ZzZzpij.z0eek(p2, p4);
		if (z0ZzZzpij2 == null)
		{
			z0ZzZzpij2 = z0ZzZzpij.z0eek(z0cek, p4);
		}
		if (z0ZzZzpij2 == null)
		{
			return z0ZzZzxdh.z0yek;
		}
		return z0rek(p0, p1, z0ZzZzpij2, p3, p4, p5, p7);
	}

	public void z0rek(bool p0)
	{
		z0nek = p0;
	}

	public static float z0rek(z0ZzZzadh p0, z0ZzZzimk p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("g");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("f");
		}
		return z0ZzZzpij.z0eek(z0rek(p1.Name), p1.Style).z0rek(p1.Size, p0.z0jrk());
	}

	public static float z0rek(GraphicsUnit p0, z0ZzZzimk p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("f");
		}
		return z0ZzZzpij.z0eek(z0rek(p1.Name), p1.Style).z0rek(p1.Size, p0);
	}

	private static string z0rek(string p0)
	{
		return z0ZzZzpij.z0rek(p0);
	}

	public float z0tek()
	{
		return z0zek;
	}

	public static string[] z0eek(GraphicsUnit p0, string p1, string p2, float p3, FontStyle p4, float p5, z0ZzZzlsh p6, out z0ZzZzxdh p7, List<float> p8)
	{
		z0ZzZzksh z0ZzZzksh2 = p6?.z0yek() ?? ((z0ZzZzksh)0);
		p7 = z0ZzZzxdh.z0yek;
		if (string.IsNullOrEmpty(p1))
		{
			return null;
		}
		if (XTextCharElement.z0rek(p1) && char.IsWhiteSpace(p1[0]))
		{
			return null;
		}
		z0ZzZzpij z0ZzZzpij2 = null;
		if (z0ZzZzksh2 != (z0ZzZzksh)4096 || p8 != null)
		{
			z0ZzZzpij2 = z0rek(p2, p4);
		}
		if (p5 > 0f && (z0ZzZzksh2 & (z0ZzZzksh)4096) != (z0ZzZzksh)4096)
		{
			bool flag = p1.Contains('\n');
			if (!flag && p5 > 0f)
			{
				flag = z0rek(p0, p1, z0ZzZzpij2, p3, p4).z0rek() > p5 && p1.Length > 1;
			}
			if (flag)
			{
				List<string> list = new List<string>();
				StringBuilder stringBuilder = z0krk;
				stringBuilder.Clear();
				int length = p1.Length;
				for (int i = 0; i < length; i++)
				{
					char c = p1[i];
					switch (c)
					{
					case '\n':
						if (stringBuilder.Length > 0)
						{
							list.Add(stringBuilder.ToString());
							stringBuilder.Clear();
						}
						list.Add("\n");
						continue;
					case '\r':
						continue;
					}
					if (char.IsLetterOrDigit(c) && c < '\u0080')
					{
						stringBuilder.Append(c);
						continue;
					}
					if (stringBuilder.Length > 0)
					{
						list.Add(stringBuilder.ToString());
						stringBuilder.Clear();
					}
					if (XTextCharElement.z0tek((int)c))
					{
						list.Add(p1.Substring(i, 2));
						i++;
					}
					else
					{
						list.Add(c.ToString());
					}
				}
				if (stringBuilder.Length > 0)
				{
					list.Add(stringBuilder.ToString());
					stringBuilder.Clear();
				}
				string text = "!),.:;?]}\u00a8·ˇˉ―‖’”…∶、。〃々〉》」』】〕〗！＂＇），．：；？］\uff40｜｝～￠";
				string text2 = "([{·‘“〈《「『【〔〖（．［｛￡￥";
				List<StringBuilder> list2 = new List<StringBuilder>();
				StringBuilder stringBuilder2 = new StringBuilder();
				list2.Add(stringBuilder2);
				float num = 0f;
				float num2 = 0f;
				for (int j = 0; j < list.Count; j++)
				{
					if (list2.Count > 10000)
					{
						break;
					}
					string text3 = list[j];
					if (text3 == "\n")
					{
						stringBuilder2 = new StringBuilder();
						list2.Add(stringBuilder2);
						p8?.Add(num);
						num = 0f;
						continue;
					}
					if (stringBuilder2.Length == 0 && text.Contains(text3[0]) && list2.Count > 0)
					{
						StringBuilder stringBuilder3 = list2[list2.Count - 1];
						if (stringBuilder3.Length > 3)
						{
							text3 = (list[j] = stringBuilder3[stringBuilder3.Length - 1] + text3);
							stringBuilder3.Remove(stringBuilder3.Length - 1, 1);
						}
					}
					float num3 = z0rek(p0, text3, z0ZzZzpij2, p3, p4).z0rek();
					if (num3 == 0f && text3 == " ")
					{
						num3 = z0ZzZzpij2.z0rek('i', p3, p0);
					}
					if (num + num3 > p5)
					{
						if ((double)num < (double)p5 * 0.3)
						{
							if (XTextCharElement.z0rek(text3))
							{
								stringBuilder2.Append(text3);
								j++;
							}
							else
							{
								float num4 = 0f;
								for (int k = 0; k < text3.Length; k++)
								{
									float num5;
									if (XTextCharElement.z0tek((int)text3[k]))
									{
										num5 = z0ZzZzpij2.z0eek(p3, p0);
										k++;
									}
									else
									{
										num5 = z0ZzZzpij2.z0rek(text3[k], p3, p0);
									}
									num4 += num5;
									if (num + num4 > p5)
									{
										if (k == 0)
										{
											k = 1;
										}
										stringBuilder2.Append(text3, 0, k);
										list[j] = text3.Substring(k);
										break;
									}
								}
							}
						}
						else if (stringBuilder2.Length > 3 && text2.Contains(stringBuilder2[stringBuilder2.Length - 1]))
						{
							stringBuilder2.Remove(stringBuilder2.Length - 1, 1);
							j--;
						}
						j--;
						stringBuilder2 = new StringBuilder();
						list2.Add(stringBuilder2);
						p8?.Add(num);
						num = 0f;
					}
					else
					{
						stringBuilder2.Append(text3);
						num += num3;
						if (num2 < num)
						{
							num2 = num;
						}
					}
				}
				if (list2[list2.Count - 1].Length == 0)
				{
					list2.RemoveAt(list2.Count - 1);
				}
				if (p8 != null && p8.Count < list2.Count)
				{
					p8.Add(num);
				}
				p7 = new z0ZzZzxdh(num2, (float)list2.Count * z0ZzZzpij2.z0rek(p3, p0));
				string[] array = new string[list2.Count];
				for (int l = 0; l < list2.Count; l++)
				{
					if (list2[l].Length == 0)
					{
						array[l] = string.Empty;
					}
					else
					{
						array[l] = list2[l].ToString();
					}
				}
				list2.Clear();
				return array;
			}
			p7 = z0rek(p0, p1, z0ZzZzpij2, p3, p4);
			p8?.Add(p7.z0rek());
		}
		else if (p8 != null)
		{
			p7 = z0rek(p0, p1, z0ZzZzpij2, p3, p4);
			p8.Add(p7.z0rek());
		}
		z0oek[0] = p1;
		return z0oek;
	}

	internal static bool z0rek(z0ZzZzrzj p0, char p1)
	{
		return p0.z0luk?.z0tek(p1) ?? true;
	}

	public void z0rek(MeasureMode p0)
	{
		z0hrk = p0;
	}

	public static z0ZzZzxdh z0rek(z0ZzZzadh p0, string p1, z0ZzZzrzj p2, float p3, z0ZzZzlsh p4)
	{
		if (p2 == null)
		{
			throw new ArgumentNullException("style");
		}
		return z0rek(p0.z0jrk(), p1, p2.z0tyk, p2.z0wtk, p2.z0prk, p3, p4);
	}

	public static z0ZzZzxdh z0rek(GraphicsUnit p0, string p1, z0ZzZzpij p2, float p3, FontStyle p4)
	{
		if (p2 == null)
		{
			throw new ArgumentNullException("info");
		}
		bool flag = p2.z0eek(p4);
		float p5 = p2.z0rek(p3, p0);
		float num = 0f;
		if (p1 != null && p1.Length > 0)
		{
			int length = p1.Length;
			for (int i = 0; i < length; i++)
			{
				char c = p1[i];
				float num2 = 0f;
				if (XTextCharElement.z0tek((int)c))
				{
					num2 = p2.z0eek(p3, p0);
					i++;
				}
				else
				{
					num2 = p2.z0rek(c, p3, p0);
				}
				if (num2 > 0f && flag)
				{
					if (c < '\u007f')
					{
						num2 *= 1.05f;
					}
				}
				else if (num2 == 0f && p2.z0tek())
				{
					string text = z0ZzZzljh.z0eek().z0eek(c);
					if (string.IsNullOrEmpty(text))
					{
						text = z0ZzZzimk.DefaultFontName;
					}
					z0ZzZzpij z0ZzZzpij2 = z0ZzZzpij.z0eek(text, p2.z0jrk);
					if (z0ZzZzpij2 == null)
					{
						z0ZzZzpij2 = z0ZzZzpij.z0eek(z0cek, p2.z0jrk);
					}
					if (z0ZzZzpij2 != null)
					{
						num2 = z0ZzZzpij2.z0rek(c, p3, p0);
						if (num2 > 0f && z0ZzZzpij2.z0eek(p4) && c < '\u007f')
						{
							num2 *= 1.05f;
						}
					}
				}
				num += num2;
			}
		}
		return new z0ZzZzxdh(num, p5);
	}

	public static z0ZzZzxdh z0rek(GraphicsUnit p0, string p1, z0ZzZzsdh p2)
	{
		return z0rek(p0, p1, z0rek(p2), p2);
	}

	public static void z0rek(char p0, float p1)
	{
		z0uek[p0] = p1;
	}

	public static float z0rek(GraphicsUnit p0, z0ZzZzsdh p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("f");
		}
		return z0ZzZzpij.z0eek(z0rek(p1.z0pek()), p1.z0mek()).z0rek(p1.z0yek(), p0);
	}

	public static z0ZzZzpij z0rek(string p0, FontStyle p1)
	{
		z0ZzZzpij z0ZzZzpij2 = z0ZzZzpij.z0eek(z0rek(p0), p1);
		if (z0ZzZzpij2 == null)
		{
			z0ZzZzpij2 = z0ZzZzpij.z0eek(z0cek, p1);
		}
		return z0ZzZzpij2;
	}

	public void z0rek(GraphicsUnit p0)
	{
		z0iek = p0;
	}

	public static void z0rek(char p0, char p1, string p2)
	{
		z0lmk z0lmk = new z0lmk();
		z0lmk.z0rek = p0;
		z0lmk.z0yek = p1;
		z0lmk.z0tek = p2;
		z0drk.Add(z0lmk);
	}

	public z0ZzZzxdh z0rek(char p0, z0ZzZzadh p1, GraphicsUnit p2, z0ZzZzrzj p3, float p4 = 1f)
	{
		if (p3 == null)
		{
			throw new ArgumentNullException("rs");
		}
		z0xek = null;
		float num = 0f;
		z0iek = p2;
		z0ZzZzumk z0ZzZzumk2 = p3.z0qtk;
		if (z0ZzZzumk2 == null || p4 != 1f)
		{
			z0ZzZzumk2 = new z0ZzZzumk(p3.z0vrk, p3.z0wtk * p4, p3.z0prk, GraphicsUnit.Point);
		}
		z0uhj z0uhj = p3.z0luk;
		if (z0uhj == null)
		{
			z0uhj = (p3.z0luk = z0uhj.z0eek(z0ZzZzumk2, p1, z0rek(), z0nek));
		}
		num = z0uhj.z0eek(p0);
		if (num <= 0f && z0ZzZzugh.z0eek(p0))
		{
			num = -1f;
		}
		if (num < 0f)
		{
			string text = z0tek(p0);
			if (text == null)
			{
				text = z0ZzZzimk.DefaultFontName;
			}
			if (text == z0uhj.z0yek)
			{
				if (!z0uek.TryGetValue(p0, out num))
				{
					num = z0uhj.z0vek;
					if (num < 0f)
					{
						num = z0uhj.z0eek('H');
					}
				}
			}
			else
			{
				if (text != null)
				{
					z0ZzZzumk2 = new z0ZzZzumk(text, p3.z0wtk, p3.z0prk, GraphicsUnit.Point);
					z0uhj z0uhj2 = z0uhj.z0eek(z0ZzZzumk2, p1, z0rek(), z0nek);
					if (z0uhj2 != null)
					{
						z0uhj = z0uhj2;
						z0xek = z0uhj2.z0yek;
						if (z0lrk == null)
						{
							z0lrk = new List<string>();
							z0lrk.Add(z0uhj2.z0yek);
						}
						else if (!z0lrk.Contains(z0uhj2.z0yek))
						{
							z0lrk.Add(z0uhj2.z0yek);
						}
					}
				}
				num = z0uhj.z0eek(p0);
				if (num < 0f && !z0uek.TryGetValue(p0, out num))
				{
					num = z0uhj.z0eek('H');
				}
				if (num > 0f && z0uhj.z0eek(p3.z0prk))
				{
					num *= 1.05f;
				}
			}
		}
		float num2 = p3.z0wtk * p4 / 10f;
		num *= num2;
		float p5 = z0uhj.z0iek * num2;
		return new z0ZzZzxdh(num, p5);
	}

	public static string z0tek(char p0)
	{
		foreach (z0lmk item in z0drk)
		{
			if (item.z0eek(p0))
			{
				return item.z0tek;
			}
		}
		return null;
	}

	public bool z0yek()
	{
		return z0nek;
	}

	private static bool z0yek(char p0)
	{
		if (p0 >= 'a' && p0 <= 'z')
		{
			return true;
		}
		if (p0 >= 'A' && p0 <= 'Z')
		{
			return true;
		}
		if (p0 >= '0')
		{
			return p0 <= '9';
		}
		return false;
	}

	public static z0ZzZzxdh z0rek(GraphicsUnit p0, string p1, z0ZzZzsdh p2, float p3, z0ZzZzlsh p4)
	{
		bool p5 = p4 == null || (p4.z0yek() & (z0ZzZzksh)4096) != (z0ZzZzksh)4096;
		z0ZzZzpij z0ZzZzpij2 = z0ZzZzpij.z0eek(z0rek(p2.z0pek()), p2.z0mek());
		if (z0ZzZzpij2 == null)
		{
			z0ZzZzpij2 = z0ZzZzpij.z0eek(z0cek, p2.z0mek());
		}
		return z0rek(p0, p1, z0ZzZzpij2, p2.z0yek(), p2.z0mek(), p3, p5);
	}

	public static z0ZzZzxdh z0rek(z0ZzZzadh p0, string p1, z0ZzZzimk p2, int p3, z0ZzZzlsh p4)
	{
		return z0rek(p0.z0jrk(), p1, p2.Name, p2.Size, p2.Style, p3, p4);
	}

	public static z0ZzZzxdh z0rek(GraphicsUnit p0, string p1, z0ZzZzpij p2, z0ZzZzsdh p3)
	{
		if (p2 == null)
		{
			throw new ArgumentNullException("info");
		}
		float num = p3.z0yek();
		bool flag = p2.z0eek(p3.z0mek());
		float p4 = p2.z0rek(num, p0);
		float num2 = 0f;
		if (p1 != null && p1.Length > 0)
		{
			int length = p1.Length;
			for (int i = 0; i < length; i++)
			{
				char c = p1[i];
				float num3;
				if (XTextCharElement.z0tek((int)c))
				{
					num3 = p2.z0eek(num, p0);
					i++;
				}
				else
				{
					num3 = p2.z0rek(c, num, p0);
				}
				if (num3 > 0f && flag)
				{
					if (c < '\u007f')
					{
						num3 *= 1.05f;
					}
				}
				else if (num3 == 0f && p2.z0tek())
				{
					string text = z0ZzZzljh.z0eek().z0eek(c);
					if (string.IsNullOrEmpty(text))
					{
						text = z0ZzZzimk.DefaultFontName;
					}
					z0ZzZzpij z0ZzZzpij2 = z0ZzZzpij.z0eek(text, p2.z0jrk);
					if (z0ZzZzpij2 == null)
					{
						z0ZzZzpij2 = z0ZzZzpij.z0eek(z0cek, p2.z0jrk);
					}
					if (z0ZzZzpij2 != null)
					{
						num3 = ((!XTextCharElement.z0tek((int)c)) ? z0ZzZzpij2.z0rek(c, num, p0) : z0ZzZzpij2.z0eek(num, p0));
						if (num3 > 0f && z0ZzZzpij2.z0eek(p3.z0mek()) && c < '\u007f')
						{
							num3 *= 1.05f;
						}
					}
				}
				num2 += num3;
			}
		}
		return new z0ZzZzxdh(num2, p4);
	}

	public static z0ZzZzxdh z0rek(GraphicsUnit p0, string p1, z0ZzZzpij p2, float p3, FontStyle p4, float p5, bool p6)
	{
		if (p2 == null)
		{
			throw new ArgumentNullException("info");
		}
		bool flag = p2.z0eek(p4);
		float num = p2.z0rek(p3, p0);
		float num2 = 0f;
		int num3 = 1;
		float num4 = 0f;
		if (p1 != null && p1.Length > 0)
		{
			int length = p1.Length;
			List<z0mok> list = z0frk;
			list.Clear();
			for (int i = 0; i < length; i++)
			{
				if (!XTextCharElement.z0tek((int)p1[i]))
				{
					continue;
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (i = 0; i < length; i++)
				{
					stringBuilder.Append(p1[i]);
					if (XTextCharElement.z0tek((int)p1[i]))
					{
						i++;
					}
				}
				p1 = stringBuilder.ToString();
				length = p1.Length;
				break;
			}
			for (int j = 0; j < length; j++)
			{
				float num5 = ((!XTextCharElement.z0tek((int)p1[j])) ? p2.z0rek(p1[j], p3, p0) : p2.z0eek(p3, p0));
				if (num5 > 0f && flag)
				{
					if (p1[j] < '\u007f')
					{
						num5 *= 1.05f;
					}
				}
				else if (num5 == 0f && p2.z0tek())
				{
					string text = z0ZzZzljh.z0eek().z0eek(p1[j]);
					if (string.IsNullOrEmpty(text))
					{
						text = z0ZzZzimk.DefaultFontName;
					}
					z0ZzZzpij z0ZzZzpij2 = z0ZzZzpij.z0eek(text, p2.z0jrk);
					if (z0ZzZzpij2 == null)
					{
						z0ZzZzpij2 = z0ZzZzpij.z0eek(z0cek, p2.z0jrk);
					}
					if (z0ZzZzpij2 != null)
					{
						num5 = z0ZzZzpij2.z0rek(p1[j], p3, p0);
						if (num5 > 0f && flag && p1[j] < '\u007f')
						{
							num5 *= 1.05f;
						}
					}
				}
				z0mok z0mok = new z0mok(p1[j], num5);
				if (num2 + num5 > p5 && p6)
				{
					if (z0yek(z0mok.z0rek))
					{
						int num6 = 0;
						int num7 = list.Count - 1;
						while (num7 >= 0 && z0yek(list[num7].z0rek))
						{
							num6 = num7;
							num7--;
						}
						if (num6 > 0)
						{
							for (int num8 = list.Count - 1; num8 >= num6; num8--)
							{
								num2 -= list[num8].z0eek;
							}
							if (num4 < num2)
							{
								num4 = num2;
							}
							j -= list.Count - num6;
							j--;
							list.Clear();
							num2 = 0f;
							num3++;
							continue;
						}
					}
					list.Clear();
					if (num4 < num2)
					{
						num4 = num2;
					}
					num2 = num5;
					list.Add(z0mok);
					num3++;
				}
				else
				{
					num2 += num5;
					list.Add(z0mok);
				}
			}
			list.Clear();
		}
		if (num3 == 1)
		{
			return new z0ZzZzxdh(num2, num);
		}
		return new z0ZzZzxdh(num4, num * (float)num3);
	}

	public static float z0rek(z0ZzZzjpk p0, z0ZzZzrzj p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("g");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("rs");
		}
		return z0ZzZzpij.z0eek(z0rek(p1.z0tyk), p1.z0prk).z0rek(p1.z0wtk, p0.z0vek());
	}

	static z0ZzZzlcj()
	{
		z0uek = new Dictionary<char, float>();
		z0krk = new StringBuilder();
		z0oek = new string[1];
		z0bek = "‘’“”；、，。？：＋（）\u3000－";
		z0cek = z0ZzZzimk.DefaultFontName;
		z0frk = new List<z0mok>();
		z0pek = true;
		z0vek = null;
		z0drk = new List<z0lmk>();
		z0lrk = null;
		z0xek = null;
		z0vek = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
	}
}
