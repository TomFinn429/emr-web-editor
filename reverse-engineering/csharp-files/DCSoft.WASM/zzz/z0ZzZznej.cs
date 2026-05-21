using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZznej : z0ZzZzbej, IDisposable
{
	private class z0unk
	{
		public byte[] z0eek;

		public string z0rek;

		public string z0tek;

		public int z0yek;

		public string z0uek;

		public int z0iek;
	}

	private class z0yxk
	{
		internal class z0hxk
		{
			private int z0tek;

			private char[] z0yek = new char[200];

			public void z0eek(float p0, int p1)
			{
				z0tek = z0ZzZzhqh.z0eek(z0yek, z0tek, p0, p1);
			}

			public void z0eek()
			{
				z0tek = 0;
			}

			public void z0eek(char p0)
			{
				z0yek[z0tek++] = p0;
			}

			public string z0rek()
			{
				if (z0tek == 0)
				{
					return string.Empty;
				}
				return new string(z0yek, 0, z0tek);
			}
		}

		[ThreadStatic]
		private static z0hxk z0iek = new z0hxk();

		private z0ZzZznej z0oek;

		internal z0ZzZzhqh z0pek;

		public static readonly string z0mek = "http://www.ofdspec.org/2016";

		public static readonly string z0nek = "ofd";

		public void z0eek(string p0)
		{
			z0pek.z0eek("ofd:" + p0);
		}

		public void z0eek(z0ZzZzudh p0)
		{
			if (p0.z0oek() > 1f)
			{
				z0eek("LineWidth", p0.z0oek() * 0.07f / 2f);
			}
			if (p0.z0tek() != DashStyle.Solid)
			{
				if (p0.z0tek() == DashStyle.Dash)
				{
					z0rek("DashPattern", "60,30");
				}
				else if (p0.z0tek() == DashStyle.Dot || p0.z0tek() == DashStyle.DashDot || p0.z0tek() == DashStyle.DashDotDot)
				{
					z0rek("DashPattern", "30,30");
				}
			}
		}

		public void z0eek(string p0, string p1)
		{
			z0pek.z0eek("ofd:" + p0);
			z0pek.z0yg(p1);
			z0pek.z0bg();
		}

		public void z0eek(string p0, bool p1)
		{
			z0pek.z0eek(p0, p1 ? "true" : "false");
		}

		public void z0eek(Color p0)
		{
			z0eek("StrokeColor", p0);
		}

		public z0yxk(z0ZzZznej p0, MemoryStream p1, string p2)
		{
			z0oek = p0;
			z0pek = new z0ZzZzhqh(p1, Encoding.UTF8);
			z0pek.z0ug();
			z0pek.z0eek("ofd:" + p2);
			z0pek.z0eek("xmlns:ofd", z0mek);
		}

		public void z0eek()
		{
			z0pek.z0bg();
		}

		public void z0eek(string p0, float p1)
		{
			z0pek.z0eek(p0, p1);
		}

		public void z0eek(z0ZzZztfh p0, float p1)
		{
			if (p0 is z0ZzZzzdh)
			{
				z0eek("FillColor");
				Color color = ((z0ZzZzzdh)p0).z0eek;
				z0pek.z0eek("Type", "RGB");
				z0pek.z0eek("Value", z0ZzZzqik.z0rek(color.R) + " " + z0ZzZzqik.z0rek(color.G) + " " + z0ZzZzqik.z0rek(color.B));
				if (color.A != 255)
				{
					z0pek.z0eek("Alpha", z0ZzZzqik.z0rek(color.A));
				}
				z0eek();
				return;
			}
			if (p0 is z0ZzZzxfh z0ZzZzxfh2)
			{
				z0eek("FillColor");
				z0eek("AxialShd");
				z0ZzZzpdh z0ZzZzpdh2 = new z0ZzZzpdh(0f, 0f);
				z0ZzZzpdh z0ZzZzpdh3 = new z0ZzZzpdh(p1, 0f);
				switch (z0ZzZzxfh2.z0mek)
				{
				case (z0ZzZzzfh)1:
					z0ZzZzpdh3 = new z0ZzZzpdh(0f, p1);
					break;
				case (z0ZzZzzfh)3:
					z0ZzZzpdh2 = new z0ZzZzpdh(0f, p1);
					z0ZzZzpdh3 = new z0ZzZzpdh(p1, 0f);
					break;
				case (z0ZzZzzfh)2:
					z0ZzZzpdh2 = new z0ZzZzpdh(p1, 0f);
					z0ZzZzpdh3 = new z0ZzZzpdh(0f, p1);
					break;
				}
				z0rek("StartPoint", z0ZzZzpdh2.z0rek() + " " + z0ZzZzpdh2.z0tek());
				z0rek("EndPoint", z0ZzZzpdh3.z0rek() + " " + z0ZzZzpdh3.z0tek());
				z0ZzZzpfh z0ZzZzpfh2 = z0ZzZzxfh2.z0eek();
				if (z0ZzZzpfh2 != null && z0ZzZzpfh2.z0eek() != null && z0ZzZzpfh2.z0eek().Length != 0 && z0ZzZzpfh2.z0rek() != null && z0ZzZzpfh2.z0rek().Length == z0ZzZzpfh2.z0eek().Length)
				{
					for (int i = 0; i < z0ZzZzpfh2.z0eek().Length; i++)
					{
						z0eek("Segment");
						z0rek("Position", z0ZzZzpfh2.z0rek()[i].ToString());
						z0eek("Color", z0ZzZzpfh2.z0eek()[i]);
						z0eek();
					}
				}
				else
				{
					z0eek("Segment");
					z0rek("Position", "0");
					z0eek("Color", z0ZzZzxfh2.z0uek);
					z0eek();
					z0eek("Segment");
					z0rek("Position", "1");
					z0eek("Color", z0ZzZzxfh2.z0iek);
					z0eek();
				}
				z0eek();
				z0eek();
				return;
			}
			throw new NotSupportedException(p0.GetType().Name);
		}

		public void z0eek(z0ZzZzbdh p0)
		{
			if (z0iek == null)
			{
				z0iek = new z0hxk();
			}
			z0iek.z0eek();
			z0iek.z0eek(p0.z0oek(), 100000);
			z0iek.z0eek(' ');
			z0iek.z0eek(p0.z0pek(), 100000);
			z0iek.z0eek(' ');
			z0iek.z0eek(p0.z0uek(), 100000);
			z0iek.z0eek(' ');
			z0iek.z0eek(p0.z0iek(), 100000);
			string p1 = z0iek.z0rek();
			z0pek.z0eek("Boundary", p1);
		}

		public void z0eek(float p0, float p1, float p2, float p3, bool p4, bool p5)
		{
			z0eek("PathObject");
			z0uek();
			z0rek("Boundary", z0ZzZzqik.z0eek(p0, 10) + " " + z0ZzZzqik.z0eek(p1, 10) + " " + z0ZzZzqik.z0eek(p2, 10) + " " + z0ZzZzqik.z0eek(p3, 10));
			if (!p4)
			{
				z0rek("Stroke", "false");
			}
			if (p5)
			{
				z0rek("Fill", "true");
			}
		}

		public void z0rek()
		{
			string text = z0oek.z0iek();
			if (text != null && text.Length > 0)
			{
				z0rek("CTM", text);
			}
		}

		public void z0rek(string p0, string p1)
		{
			z0pek.z0eek(p0, p1);
		}

		public void z0tek()
		{
			if (z0pek == null)
			{
				throw new ObjectDisposedException("alread closed");
			}
			z0pek.z0bg();
			z0pek.z0vg();
			z0pek.z0kf();
			z0pek = null;
		}

		public void z0rek(string p0)
		{
			z0pek.z0yg(p0);
		}

		public void z0yek()
		{
			z0ZzZzbdh z0htk = z0oek.z0htk;
			if (z0htk.z0uek() > 0f && z0htk.z0iek() > 0f)
			{
				z0eek("Clips");
				z0eek("Clip");
				z0eek("Area");
				z0eek("Path");
				z0tek(z0sok.z0rek(z0htk.z0oek(), z0htk.z0pek(), z0htk.z0uek(), z0htk.z0iek()));
				z0eek();
				z0eek();
				z0eek();
				z0eek();
			}
		}

		public void z0eek(string p0, Color p1)
		{
			z0eek(p0);
			z0pek.z0eek("Type", "RGB");
			z0pek.z0eek("Value", z0ZzZzqik.z0rek(p1.R) + " " + z0ZzZzqik.z0rek(p1.G) + " " + z0ZzZzqik.z0rek(p1.B));
			if (p1.A != 255)
			{
				z0pek.z0eek("Alpha", z0ZzZzqik.z0rek(p1.A));
			}
			z0eek();
		}

		public void z0eek(string p0, int p1)
		{
			z0pek.z0eek(p0, z0ZzZzqik.z0rek(p1));
		}

		public void z0eek(DashStyle p0, float p1)
		{
			switch (p0)
			{
			case DashStyle.Dash:
				z0rek("DashPattern", p1 + " " + p1);
				break;
			case DashStyle.Dot:
			case DashStyle.DashDot:
			case DashStyle.DashDotDot:
				z0rek("DashPattern", p1 * 3f + " " + p1);
				break;
			}
		}

		public void z0tek(string p0)
		{
			if (p0 != null && p0.Length > 0)
			{
				z0eek("AbbreviatedData", p0);
			}
		}

		public void z0rek(Color p0)
		{
			z0eek("FillColor", p0);
		}

		public int z0uek()
		{
			int num = z0oek.z0eek();
			z0pek.z0eek("ID", z0ZzZzqik.z0rek(num));
			return num;
		}
	}

	private class z0txk
	{
		public GraphicsUnit z0eek = GraphicsUnit.Point;

		public z0ZzZzbdh z0rek = z0ZzZzbdh.z0xek;

		public z0ZzZzjdh z0tek;
	}

	private class z0enk
	{
		public FontStyle z0eek;

		public z0ZzZzbdh z0rek;

		public int z0tek;

		public float z0yek;

		public StringBuilder z0uek;

		public int z0iek;

		public bool z0oek;

		public string z0pek;
	}

	private class z0phj
	{
		public int z0eek;

		public string z0rek;

		public int z0tek;
	}

	private class z0hnk
	{
		public string z0tek;

		public int z0yek;

		public Dictionary<char, bool> z0uek = new Dictionary<char, bool>();

		public bool[] z0iek_jiejie20260327142557 = new bool[127];

		public void z0eek(string p0)
		{
			if (p0 == null || p0.Length <= 0)
			{
				return;
			}
			for (int num = p0.Length - 1; num >= 0; num--)
			{
				char c = p0[num];
				if (c < '\u007f')
				{
					z0iek_jiejie20260327142557[(uint)c] = true;
				}
				else
				{
					z0uek[c] = true;
				}
			}
		}

		public byte[] z0eek()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < z0iek_jiejie20260327142557.Length; i++)
			{
				if (z0iek_jiejie20260327142557[i])
				{
					stringBuilder.Append((char)i);
				}
			}
			foreach (char key in z0uek.Keys)
			{
				stringBuilder.Append(key);
			}
			string p = stringBuilder.ToString();
			return z0ZzZzmej.z0eek(z0tek, p);
		}

		public void z0rek()
		{
			z0iek_jiejie20260327142557 = null;
			if (z0uek != null)
			{
				z0uek.Clear();
			}
			z0uek = null;
			z0tek = null;
		}
	}

	public delegate z0ZzZzbdh[] z0ovk(GraphicsUnit pageUnit, string text, string fontName, float fontSize, FontStyle vStyle, z0ZzZzbdh bounds, z0ZzZzlsh format, out string[] lines);

	private class z0omk_jiejie20260327142557
	{
		public string z0eek;

		public List<int> z0rek;

		public z0omk_jiejie20260327142557[] z0tek;

		public XTextContainerElement z0yek;
	}

	private class z0sok
	{
		public static string z0eek(float p0, float p1, float p2, float p3, float p4, float p5)
		{
			StringBuilder stringBuilder = new StringBuilder();
			float num = p0 + p2 / 2f;
			float num2 = p1 + p3 / 2f;
			float num3 = p2 / 2f;
			float num4 = p3 / 2f;
			double num5 = (double)p4 * Math.PI / 180.0;
			double num6 = (double)p5 * Math.PI / 180.0;
			double num7 = (double)num + (double)num3 * Math.Cos(num5);
			double num8 = (double)num2 + (double)num4 * Math.Sin(num5);
			double num9 = (double)num + (double)num3 * Math.Cos(num6);
			double num10 = (double)num2 + (double)num4 * Math.Sin(num6);
			int num11 = ((!((p5 - p4) % 360f <= 180f)) ? 1 : 0);
			stringBuilder.Append("S 0 0 ");
			z0eek(stringBuilder, 'M');
			z0eek(stringBuilder, num);
			z0eek(stringBuilder, num2);
			z0eek(stringBuilder, 'L');
			z0eek(stringBuilder, (float)num7);
			z0eek(stringBuilder, (float)num8);
			z0eek(stringBuilder, 'A');
			z0eek(stringBuilder, num3);
			z0eek(stringBuilder, num4);
			stringBuilder.Append(" 0 ");
			z0eek(stringBuilder, num11);
			stringBuilder.Append(" 1 ");
			z0eek(stringBuilder, (float)num9);
			z0eek(stringBuilder, (float)num10);
			z0eek(stringBuilder, 'Z');
			return stringBuilder.ToString();
		}

		public static string z0eek(float p0, float p1, float p2, float p3, float p4, float p5, float p6, float p7)
		{
			StringBuilder stringBuilder = new StringBuilder();
			z0eek(stringBuilder, 'M');
			z0eek(stringBuilder, p0 - p4);
			z0eek(stringBuilder, p1 - p5);
			z0eek(stringBuilder, 'L');
			z0eek(stringBuilder, p2 - p4);
			z0eek(stringBuilder, p3 - p5);
			return stringBuilder.ToString();
		}

		public static void z0eek(StringBuilder p0, float p1, float p2, float p3, float p4, float p5)
		{
		}

		public static string z0eek(float p0, float p1, float p2, float p3)
		{
			float p4 = p2 / 2f;
			float num = p3 / 2f;
			float p5 = p0 + p2;
			float p6 = p1 + num;
			StringBuilder stringBuilder = new StringBuilder();
			z0eek(stringBuilder, 'M');
			z0eek(stringBuilder, p0);
			z0eek(stringBuilder, p6);
			z0eek(stringBuilder, 'A');
			z0eek(stringBuilder, p4);
			z0eek(stringBuilder, num);
			stringBuilder.Append(" 0 1 1 ");
			z0eek(stringBuilder, p5);
			z0eek(stringBuilder, p6);
			z0eek(stringBuilder, 'A');
			z0eek(stringBuilder, p4);
			z0eek(stringBuilder, num);
			stringBuilder.Append(" 0 1 1 ");
			z0eek(stringBuilder, p0);
			z0eek(stringBuilder, p6);
			z0eek(stringBuilder, 'C');
			return stringBuilder.ToString();
		}

		public static void z0eek(StringBuilder p0, float p1)
		{
			if (p0.Length > 0)
			{
				p0.Append(' ');
			}
			p0.Append(p1.ToString());
		}

		public static string z0rek(float p0, float p1, float p2, float p3)
		{
			StringBuilder stringBuilder = new StringBuilder();
			z0eek(stringBuilder, 'S');
			z0eek(stringBuilder, p0);
			z0eek(stringBuilder, p1);
			z0eek(stringBuilder, 'L');
			z0eek(stringBuilder, p0 + p2);
			z0eek(stringBuilder, p1);
			z0eek(stringBuilder, 'L');
			z0eek(stringBuilder, p0 + p2);
			z0eek(stringBuilder, p1 + p3);
			z0eek(stringBuilder, 'L');
			z0eek(stringBuilder, p0);
			z0eek(stringBuilder, p1 + p3);
			z0eek(stringBuilder, 'C');
			return stringBuilder.ToString();
		}

		public static void z0eek(StringBuilder p0, char p1)
		{
			if (p0.Length > 0)
			{
				p0.Append(' ');
			}
			p0.Append(p1);
		}

		public static string z0eek(z0ZzZzpdh[] p0, float p1, float p2, bool p3)
		{
			if (p0 == null || p0.Length <= 1)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			z0eek(stringBuilder, 'S');
			z0eek(stringBuilder, p0[0].z0rek() - p1);
			z0eek(stringBuilder, p0[1].z0tek() - p2);
			for (int i = 1; i < p0.Length; i++)
			{
				z0eek(stringBuilder, 'L');
				z0eek(stringBuilder, p0[i].z0rek() - p1);
				z0eek(stringBuilder, p0[i].z0tek() - p2);
			}
			if (p3)
			{
				z0eek(stringBuilder, 'C');
			}
			return stringBuilder.ToString();
		}

		public static string z0eek(z0ZzZztok p0, float p1, float p2, float p3, float p4)
		{
			StringBuilder stringBuilder = new StringBuilder();
			z0ZzZztok.z0oxk z0oxk = null;
			foreach (z0ZzZztok.z0oxk item in p0.z0iek())
			{
				float[] array = item.z0eek;
				switch (item.z0rek)
				{
				case z0ZzZztok.z0xpk.z0yek:
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(' ');
					}
					if (z0oxk == null || z0oxk.z0rek != z0ZzZztok.z0xpk.z0yek || z0oxk.z0eek[2] != array[0] || z0oxk.z0eek[3] != array[1])
					{
						stringBuilder.Append("M ");
						z0eek(stringBuilder, array[0] - p1);
						stringBuilder.Append(' ');
						z0eek(stringBuilder, array[1] - p2);
					}
					stringBuilder.Append("L ");
					z0eek(stringBuilder, array[2] - p1);
					stringBuilder.Append(' ');
					z0eek(stringBuilder, array[3] - p2);
					break;
				case z0ZzZztok.z0xpk.z0uek:
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(' ');
					}
					stringBuilder.Append("M ");
					z0eek(stringBuilder, array[0] - p1);
					stringBuilder.Append(' ');
					z0eek(stringBuilder, array[1] - p2);
					for (int i = 2; i < array.Length; i += 2)
					{
						stringBuilder.Append(" L");
						z0eek(stringBuilder, array[i] - p1);
						stringBuilder.Append(' ');
						z0eek(stringBuilder, array[i + 1] - p2);
					}
					break;
				}
				}
				z0oxk = item;
			}
			return stringBuilder.ToString();
		}
	}

	private z0yxk z0vek;

	private List<z0unk> z0cek;

	private bool z0xek = true;

	private z0ZzZzhqh z0zek;

	private Dictionary<XTextContainerElement, z0omk_jiejie20260327142557> z0lrk;

	private z0ZzZzjdh z0krk = new z0ZzZzjdh();

	private zzz.z0ZzZzkuk<char> z0jrk = new zzz.z0ZzZzkuk<char>();

	private string z0hrk;

	public static z0ZzZzpij z0grk = z0ZzZzpij.z0eek("宋体", FontStyle.Regular);

	[CompilerGenerated]
	private string z0frk;

	internal static bool z0drk = false;

	private z0yxk z0srk;

	private Dictionary<byte[], z0phj> z0ark;

	private List<z0ZzZzpej> z0qrk;

	private string[] z0wrk;

	private Color z0erk = Color.Black;

	public static z0ovk z0rrk = z0ZzZzlcj.z0rek;

	private string z0trk;

	private float z0yrk = 100f;

	private bool z0urk = true;

	private static int z0irk = 0;

	private float z0ork;

	private static Dictionary<DCStdImageKey, string> z0prk = null;

	private int z0mrk_jiejie20260327142557 = -1;

	private float z0nrk;

	private XTextElementList z0brk;

	private FontStyle z0vrk;

	private Stack<z0enk> z0crk;

	private float z0xrk = 1f;

	private float z0zrk;

	internal static bool z0ltk = false;

	private XTextElement z0ktk;

	internal static XAttributeList z0jtk = null;

	private z0ZzZzbdh z0htk = z0ZzZzbdh.z0xek;

	[CompilerGenerated]
	private string z0gtk;

	private static readonly int z0ftk_jiejie20260327142557 = Color.Black.ToArgb();

	private int z0dtk = -100;

	private List<int> z0stk = new List<int>();

	private GraphicsUnit z0atk = GraphicsUnit.Pixel;

	private int z0qtk = -1;

	public static bool z0wtk = true;

	private float z0etk;

	private string z0rtk;

	internal static string z0ttk = string.Empty;

	private static char[] z0ytk = new char[40];

	private z0omk_jiejie20260327142557 z0utk;

	private List<float> z0itk = new List<float>();

	private Dictionary<string, MemoryStream> z0otk = new Dictionary<string, MemoryStream>();

	private float z0ptk;

	private static int z0mtk = 1;

	private int z0ntk;

	private bool z0btk;

	internal static bool z0vtk = false;

	private Dictionary<string, z0hnk> z0ctk;

	private float z0xtk = 100f;

	private float z0ztk = 1f;

	private Stream z0lyk;

	internal static bool z0kyk = false;

	public override void z0rgk(z0ZzZztfh p0, float p1, float p2, float p3, float p4)
	{
		z0ZzZzbdh p5 = z0eek(p1, p2, p3, p4);
		if (z0zek != null)
		{
			if (z0ptk < p5.z0nek())
			{
				z0ptk = p5.z0nek();
			}
			string p6 = z0eek(p5);
			z0zek.z0eek("ellipse");
			z0zek.z0tek("cx", (int)(p5.z0tek() + p5.z0uek() / 2f));
			z0zek.z0tek("cy", (int)(p5.z0yek() + p5.z0iek() / 2f));
			z0zek.z0tek("rx", (int)(p5.z0uek() / 2f));
			z0zek.z0tek("ry", (int)(p5.z0iek() / 2f));
			z0eek(p6);
			z0eek(p0);
			z0zek.z0bg();
		}
		else
		{
			z0yxk z0yxk = z0srk;
			z0yxk.z0eek(p1, p2, p3, p4, p4: false, p5: true);
			z0yxk.z0eek(p0, p5.z0uek());
			z0yxk.z0yek();
			z0yxk.z0tek(z0sok.z0eek(p1, p2, p3, p4));
			z0yxk.z0eek();
		}
	}

	public override void z0egk(z0ZzZzudh p0, z0ZzZzpdh[] p1)
	{
		if (p1 == null || p1.Length < 2)
		{
			return;
		}
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		for (int i = 0; i < p1.Length; i++)
		{
			z0ZzZzpdh z0ZzZzpdh2 = (p1[i] = z0yek(p1[i].z0rek(), p1[i].z0tek()));
			if (i == 0 || num < z0ZzZzpdh2.z0rek())
			{
				num = z0ZzZzpdh2.z0rek();
			}
			if (i == 0 || num3 > z0ZzZzpdh2.z0rek())
			{
				num3 = z0ZzZzpdh2.z0rek();
			}
			if (i == 0 || num2 < z0ZzZzpdh2.z0tek())
			{
				num2 = z0ZzZzpdh2.z0tek();
			}
			if (i == 0 || num4 > z0ZzZzpdh2.z0tek())
			{
				num4 = z0ZzZzpdh2.z0tek();
			}
			if (z0ptk < num2)
			{
				z0ptk = num2;
			}
		}
		num3 -= 1f;
		num4 -= 1f;
		num += 2f;
		num2 += 2f;
		z0uek();
		if (z0zek != null)
		{
			z0zek.z0eek("path");
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("M ");
			stringBuilder.Append(z0ZzZzhqh.z0eek(p1[0].z0rek()));
			stringBuilder.Append(' ');
			stringBuilder.Append(z0ZzZzhqh.z0eek(p1[0].z0tek()));
			for (int j = 1; j < p1.Length; j++)
			{
				stringBuilder.Append(" L ");
				stringBuilder.Append(z0ZzZzhqh.z0eek(p1[j].z0rek()));
				stringBuilder.Append(' ');
				stringBuilder.Append(z0ZzZzhqh.z0eek(p1[j].z0tek()));
			}
			z0zek.z0eek("fill", "none");
			z0zek.z0eek("d", stringBuilder.ToString());
			z0eek(p0);
			z0zek.z0bg();
		}
		else
		{
			z0srk.z0eek(num3, num4, num - num3, num2 - num4, p4: true, p5: false);
			z0srk.z0eek(p0.z0nek());
			z0srk.z0tek(z0sok.z0eek(p1, num3, num4, p3: false));
			z0srk.z0eek();
		}
	}

	public override z0ZzZzjdh z0wgk()
	{
		z0rtk = null;
		return z0krk;
	}

	private void z0eek(z0ZzZztfh p0)
	{
		if (p0 is z0ZzZzzdh)
		{
			Color p1 = ((z0ZzZzzdh)p0).z0eek;
			if (p1.ToArgb() == z0ftk_jiejie20260327142557)
			{
				z0zek.z0eek("fill", "black");
				return;
			}
			if (p1.A == 255)
			{
				z0zek.z0eek("fill", z0ZzZzifh.z0eek(p1));
				return;
			}
			Color p2 = Color.FromArgb(p1.R, p1.G, p1.B);
			z0zek.z0eek("fill", z0ZzZzifh.z0eek(p2));
			z0zek.z0eek("fill-opacity", ((double)(int)p1.A / 255.0).ToString());
		}
		else if (p0 is z0ZzZzxfh)
		{
			z0ZzZzxfh z0ZzZzxfh2 = (z0ZzZzxfh)p0;
			if (z0ZzZzxfh2.z0oek == null)
			{
				throw new InvalidOperationException("未准备画刷");
			}
			z0zek.z0eek("fill", "url('#" + z0ZzZzxfh2.z0oek + "')");
		}
		else
		{
			if (!(p0 is z0ZzZzdsh))
			{
				throw new NotSupportedException(p0.ToString());
			}
			z0ZzZzdsh z0ZzZzdsh2 = (z0ZzZzdsh)p0;
			if (z0ZzZzdsh2.z0tek == null)
			{
				throw new InvalidOperationException("未准备画刷");
			}
			z0zek.z0eek("fill", "url('#" + z0ZzZzdsh2.z0tek + "')");
		}
	}

	public static z0ZzZznej z0eek(z0ZzZzhqh p0, XTextDocument p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("writer");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("document");
		}
		z0ZzZznej z0ZzZznej2 = new z0ZzZznej();
		z0ZzZznej2.z0xek = false;
		z0ZzZznej2.z0zek = p0;
		z0ZzZznej2.z0eek(p1.z0vmk());
		if (p1.PageSettings.z0jrk() != null && p1.PageSettings.z0jrk().z0eek())
		{
			z0ZzZznej2.z0eek(p1.PageSettings.z0jrk().Font);
		}
		if (p1.PageSettings.z0xek() != null)
		{
			z0ZzZznej2.z0eek(p1.PageSettings.z0xek().z0uek());
		}
		using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = p1.z0gnk().Styles.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0ZzZzcok current = z0bpk.Current;
				z0ZzZznej2.z0eek(current.Font);
			}
		}
		z0ZzZznej2.z0eek(new z0ZzZzimk("Wingdings", 10f));
		return z0ZzZznej2;
	}

	public void z0eek(float p0, float p1)
	{
		z0btk = true;
		if (z0ark != null)
		{
			z0ark.Clear();
			z0ark = null;
		}
		z0yrk = p0;
		z0xtk = p1;
		z0ptk = 0f;
		z0zek.z0eek("g");
		if (z0qrk != null && z0qrk.Count > 0)
		{
			z0zek.z0eek("style");
			StringBuilder stringBuilder = new StringBuilder();
			foreach (z0ZzZzpej item in z0qrk)
			{
				item.z0oek = "dcf_" + z0mtk++;
				stringBuilder.AppendLine("  ." + item.z0oek + "{" + z0eek(item.z0iek, item.z0bek, item.z0mek) + ";fill:black}");
			}
			List<string> list = new List<string>();
			if (z0vtk && !list.Contains("宋体"))
			{
				list.Add("宋体");
			}
			if (z0ttk.Length > 0)
			{
				string[] array = z0ttk.Split(',');
				foreach (string text in array)
				{
					if (text.Length > 0 && !list.Contains(text))
					{
						list.Add(text);
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (string item2 in list)
				{
					string text2 = "  @font-face{ font-family : '" + item2 + "'; src : local('" + item2 + "');}";
					stringBuilder.AppendLine(text2);
				}
			}
			if (z0kyk)
			{
				string text3 = "  svg *::selection {fill: blue;}";
				stringBuilder.AppendLine(text3);
				string text4 = "  svg *::-moz-selection {fill: blue;}";
				stringBuilder.AppendLine(text4);
				string text5 = "  svg *::-webkit-selection {fill: blue;}";
				stringBuilder.AppendLine(text5);
			}
			string text6 = "line{shape-rendering:auto;}";
			stringBuilder.AppendLine(text6);
			string text7 = "[user-select=none]{-webkit-user-select:none;-ms-user-select:none;-o-user-select:none;-moz-user-select:none;-khtml-user-select:none;user-select:none}";
			stringBuilder.AppendLine(text7);
			z0zek.z0yg(stringBuilder.ToString());
			z0zek.z0bg();
		}
		z0jrk.Clear();
		z0itk.Clear();
	}

	public override void z0qgk_jiejie20260327142557(z0ZzZzjdh p0)
	{
		z0krk = p0;
		z0rtk = null;
	}

	public override object z0agk()
	{
		return new z0txk
		{
			z0tek = z0krk.z0uek(),
			z0eek = z0atk,
			z0rek = z0htk
		};
	}

	public z0ZzZznej(Stream p0, bool p1 = false)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("outputStream");
		}
		z0lyk = p0;
		if (p1)
		{
			StreamWriter p2 = new StreamWriter(z0lyk, Encoding.UTF8);
			z0zek = new z0ZzZzhqh(p2);
			z0zek.z0ug();
			z0zek.z0eek("div");
		}
		else
		{
			z0vek = z0eek("OFD.xml", "OFD");
			z0vek.z0rek("DocType", "OFD");
			z0vek.z0rek("Version", "1.0");
		}
	}

	private z0ZzZzbdh z0eek(float p0, float p1, float p2, float p3)
	{
		z0ZzZzpdh z0ZzZzpdh2 = z0yek(p0, p1);
		return new z0ZzZzbdh(z0ZzZzpdh2.z0rek(), z0ZzZzpdh2.z0tek(), z0eek(p2 * z0xrk), z0eek(p3 * z0xrk));
	}

	public new void z0rek(float p0, float p1)
	{
		z0nrk = p0;
		z0zrk = p1;
	}

	public override void z0sgk(z0ZzZzbdh p0)
	{
		z0htk = z0eek(p0.z0tek(), p0.z0yek(), p0.z0uek(), p0.z0iek());
	}

	public int z0eek()
	{
		return z0ntk++;
	}

	public override void z0dgk(char p0, int p1, string p2, float p3, FontStyle p4, Color p5, float p6, float p7, float p8, object p9)
	{
		if (!z0ZzZzbej.z0iek)
		{
			p1 = z0dtk;
		}
		bool flag = p0 == ' ' || p0 == '\t' || XTextCharElement.z0tek(p0);
		if (flag && !z0ltk)
		{
			return;
		}
		if (flag || z0ZzZzzsh.z0tek(p0))
		{
			if (z0jrk.Count > 0 && (z0trk != p2 || z0etk != p3 || z0vrk != p4 || z0erk != p5 || z0ork != p7 || z0dtk != p1))
			{
				z0uek();
			}
			if (z0jrk.Count == 0)
			{
				z0trk = p2;
				z0etk = p3;
				z0vrk = p4;
				z0erk = p5;
				z0ork = p7;
				z0dtk = p1;
			}
			z0itk.Add(p6);
			if (flag && z0zek != null)
			{
				z0jrk.Add('&');
				z0jrk.Add('n');
				z0jrk.Add('b');
				z0jrk.Add('s');
				z0jrk.Add('p');
				z0jrk.Add(';');
			}
			else
			{
				z0jrk.Add(p0);
			}
			return;
		}
		z0uek();
		if (z0zek != null)
		{
			z0ZzZzodh z0ZzZzodh2 = z0tek(p6, p7);
			z0zek.z0eek("text");
			z0zek.z0tek("x", z0ZzZzodh2.z0rek());
			z0zek.z0rek("y", z0ZzZzodh2.z0tek());
			if ((float)z0ZzZzodh2.z0tek() > z0ptk)
			{
				z0ptk = z0ZzZzodh2.z0tek();
			}
			if (p8 > 0f)
			{
				float num = z0tek(p8);
				if (z0ptk < num + (float)z0ZzZzodh2.z0tek())
				{
					z0ptk = num + (float)z0ZzZzodh2.z0tek();
				}
			}
			else if (z0ptk < (float)z0ZzZzodh2.z0tek())
			{
				z0ptk += z0ZzZzodh2.z0tek();
			}
			bool flag2 = true;
			if (z0crk != null && z0crk.Count > 0)
			{
				z0enk z0enk = z0crk.Peek();
				if (z0enk.z0pek == p2 && z0enk.z0yek == p3 && z0enk.z0eek == p4 && p5.ToArgb() == z0ftk_jiejie20260327142557)
				{
					flag2 = false;
				}
			}
			if (flag2)
			{
				z0rek(p2, p3, p4, p5);
			}
			z0zek.z0rek(p0);
			z0yek(z0eek(p1));
			z0zek.z0bg();
			return;
		}
		z0ZzZzpij z0ZzZzpij2 = z0ZzZzpij.z0eek(p2, p4);
		if (z0ZzZzpij2 == null || !z0ZzZzpij2.z0eek(p0))
		{
			z0ZzZzpij2 = z0grk;
			if (z0ZzZzpij2 == null)
			{
				throw new InvalidOperationException("DefaultTrueTypeFont=null");
			}
			p2 = z0ZzZzpij2.z0wrk;
		}
		z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzpij2.z0eek(p0, p3, z0atk);
		z0ZzZzbdh p10 = z0eek(p6, p7, z0ZzZzxdh2.z0rek() + 3f, z0ZzZzxdh2.z0tek());
		string text = p0.ToString();
		z0srk.z0eek("TextObject");
		z0srk.z0uek();
		z0srk.z0eek("Font", z0rek(p2, text));
		p8 = ((p8 != 0f) ? z0tek(p8) : z0tek(z0ZzZzpij2.z0rek(p3, z0atk)));
		z0srk.z0eek("Size", p3 * 0.36f);
		z0srk.z0eek(p10);
		if ((p4 & FontStyle.Bold) == FontStyle.Bold)
		{
			z0srk.z0eek("Weight", 700);
		}
		if ((p4 & FontStyle.Italic) == FontStyle.Italic)
		{
			z0srk.z0eek("Italic", p1: true);
		}
		z0srk.z0rek("Stroke", "true");
		z0srk.z0rek(p5);
		z0srk.z0eek("TextCode");
		z0srk.z0rek("X", "0");
		if (z0ZzZzpij2.z0qrk > 0f && z0ZzZzpij2.z0bek > 0f)
		{
			z0srk.z0eek("Y", p8 * z0ZzZzpij2.z0qrk / z0ZzZzpij2.z0bek);
		}
		else
		{
			z0srk.z0eek("Y", p8 * 0.78f);
		}
		if (text.Length > 1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				float num2 = z0tek(z0ZzZzpij2.z0rek(text[i], p3, z0atk));
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(num2.ToString());
			}
			z0srk.z0rek("DeltaX", stringBuilder.ToString());
			stringBuilder = null;
		}
		z0srk.z0rek(text);
		z0srk.z0eek();
		z0srk.z0eek();
	}

	public new z0ZzZzbdh z0rek()
	{
		return z0htk;
	}

	private static float z0eek(float p0)
	{
		return (float)(int)(p0 * 100f) / 100f;
	}

	public override void z0fgk(z0ZzZzudh p0, float p1, float p2, float p3, float p4, float p5, float p6)
	{
		z0uek();
		z0shk(p1, p2, p3, p4);
		_ = z0zek;
	}

	private string z0eek(int p0)
	{
		if (z0wrk != null && z0wrk.Length != 0)
		{
			p0++;
			if (p0 < 0)
			{
				return z0wrk[0];
			}
			if (p0 >= z0wrk.Length)
			{
				return z0wrk[z0wrk.Length - 1];
			}
			return z0wrk[p0];
		}
		return null;
	}

	public override void Dispose()
	{
		if (z0lrk != null)
		{
			foreach (z0omk_jiejie20260327142557 value in z0lrk.Values)
			{
				value.z0yek = null;
				value.z0eek = null;
				value.z0tek = null;
			}
			z0lrk.Clear();
			z0lrk = null;
			z0utk = null;
		}
		if (z0wrk != null)
		{
			z0wrk = null;
		}
		if (z0itk != null)
		{
			z0itk.Clear();
			z0itk = null;
			z0jrk.Clear();
			z0jrk = null;
		}
		if (z0ark != null)
		{
			z0ark.Clear();
			z0ark = null;
		}
		if (z0crk != null)
		{
			z0crk.Clear();
			z0crk = null;
		}
		if (z0zek != null)
		{
			z0pek();
			if (z0xek)
			{
				z0zek.z0vg();
				z0zek.z0kf();
				z0zek = null;
			}
			if (z0qrk != null)
			{
				z0qrk.Clear();
				z0qrk = null;
			}
			return;
		}
		z0oek();
		z0vek.z0tek();
		z0vek = null;
		byte[] array = z0tek();
		if (z0otk != null)
		{
			foreach (MemoryStream value2 in z0otk.Values)
			{
				value2.Dispose();
			}
			z0otk.Clear();
		}
		z0otk = null;
		if (z0cek != null)
		{
			foreach (z0unk item in z0cek)
			{
				item.z0eek = null;
				item.z0uek = null;
				item.z0rek = null;
				item.z0tek = null;
			}
			z0cek.Clear();
		}
		if (z0ctk != null)
		{
			foreach (KeyValuePair<string, z0hnk> item2 in z0ctk)
			{
				item2.Value.z0rek();
			}
			z0ctk.Clear();
			z0ctk = null;
		}
		z0krk = null;
		if (z0lyk != null)
		{
			z0lyk.Write(array, 0, array.Length);
		}
	}

	private new byte[] z0tek()
	{
		return z0ZzZzloj.z0eek(z0otk);
	}

	public void z0eek(XTextContainerElement p0)
	{
		if (z0brk == null || z0brk.LastElement == p0 || z0brk.Count <= 0)
		{
			return;
		}
		if (z0brk.LastElement == p0.z0ji())
		{
			z0brk.z0hrk(p0);
		}
		else if (z0brk.LastElement.z0ji() == p0)
		{
			z0brk.RemoveAt(z0brk.Count - 1);
		}
		else
		{
			for (XTextContainerElement xTextContainerElement = p0; xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
			{
				z0brk.z0mek(xTextContainerElement);
				_ = 0;
			}
		}
		z0brk.z0mek(p0);
		_ = 0;
	}

	public new float z0yek()
	{
		return z0ztk;
	}

	public override void z0ggk(float p0)
	{
		z0krk.z0eek(p0);
		z0rtk = null;
	}

	public void z0eek(XTextDocumentContentElement p0)
	{
		if (z0brk != null)
		{
			z0brk.Clear();
			z0brk.Add(p0);
		}
	}

	public override void z0hgk(z0ZzZzudh p0, z0ZzZznfh p1)
	{
		z0uek();
		z0ZzZzjdh z0ZzZzjdh2 = z0krk.z0uek();
		if (z0xrk != 1f)
		{
			z0ZzZzjdh2.z0rek(z0xrk, z0xrk);
			z0ZzZzjdh2.z0cek *= z0xrk;
			z0ZzZzjdh2.z0xek *= z0xrk;
		}
		if (z0zek != null)
		{
			z0zek.z0eek("path");
			z0zek.z0eek("fill", "none");
			z0ZzZzudh z0ZzZzudh2 = p0.z0iek();
			if (z0ZzZzjdh2.z0krk > 0f)
			{
				z0ZzZzudh2.z0eek(z0ZzZzudh2.z0oek() / z0ZzZzjdh2.z0krk);
			}
			z0eek(z0ZzZzudh2);
			z0zek.z0eek("transform", z0ZzZzjdh2.z0eek());
			z0zek.z0eek("d", p1.z0iek());
			z0zek.z0bg();
		}
		else
		{
			z0yxk z0yxk = z0srk;
			z0ZzZzbdh z0ZzZzbdh2 = p1.z0eek();
			z0yxk.z0eek(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek(), p4: true, p5: false);
			if (!z0ZzZzjdh2.z0iek())
			{
				z0yxk.z0rek("CTM", z0ZzZzjdh2.z0mek());
			}
			z0yxk.z0eek(p0);
			z0yxk.z0tek(p1.z0tek());
			z0yxk.z0eek();
		}
	}

	public override void z0jgk(z0ZzZztfh p0, z0ZzZznfh p1)
	{
		z0ZzZzjdh z0ZzZzjdh2 = z0krk.z0uek();
		if (z0xrk != 1f)
		{
			z0ZzZzjdh2.z0rek(z0xrk, z0xrk);
			z0ZzZzjdh2.z0cek *= z0xrk;
			z0ZzZzjdh2.z0xek *= z0xrk;
		}
		if (z0zek != null)
		{
			z0rek(p0);
			z0zek.z0eek("path");
			z0eek(p0);
			z0zek.z0eek("transform", z0ZzZzjdh2.z0eek());
			z0zek.z0eek("d", p1.z0iek());
			z0zek.z0bg();
			return;
		}
		z0yxk z0yxk = z0srk;
		z0ZzZzbdh z0ZzZzbdh2 = p1.z0eek();
		z0yxk.z0eek(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek(), p4: false, p5: true);
		if (!z0ZzZzjdh2.z0iek())
		{
			z0yxk.z0rek("CTM", z0ZzZzjdh2.z0mek());
		}
		z0yxk.z0eek(p0, z0ZzZzbdh2.z0uek());
		z0yxk.z0tek(p1.z0tek());
		z0yxk.z0eek();
	}

	private z0yxk z0eek(string p0, string p1)
	{
		MemoryStream memoryStream = new MemoryStream();
		z0otk[p0] = memoryStream;
		return new z0yxk(this, memoryStream, p1);
	}

	public new void z0rek(float p0)
	{
		z0ztk = p0;
	}

	public override void z0kgk(z0ZzZztfh p0, float p1, float p2, float p3, float p4, float p5, float p6)
	{
		z0ZzZzbdh p7 = z0eek(p1, p2, p3, p4);
		if (z0ptk < p7.z0nek())
		{
			z0ptk = p7.z0nek();
		}
		if (z0zek != null)
		{
			z0rek(p0);
			if (p6 != 0f && p6 % 360f == 0f)
			{
				z0rgk(p0, p7.z0oek(), p7.z0pek(), p7.z0uek(), p7.z0iek());
				return;
			}
			object[] array = z0ZzZznfh.z0rek(-10000f, -10000f, p7.z0oek(), p7.z0pek(), p7.z0uek(), p7.z0iek(), p5, p6);
			if (array != null)
			{
				z0eek(p7);
				z0zek.z0eek("path");
				z0eek(p0);
				float num = p7.z0oek() + p7.z0uek() / 2f;
				float num2 = p7.z0pek() + p7.z0iek() / 2f;
				string p8 = "M " + num + " " + num2 + " L" + array[0]?.ToString() + " " + array[1]?.ToString() + " " + array[2]?.ToString() + " Z";
				z0zek.z0eek("d", p8);
				z0zek.z0bg();
			}
		}
		else if (p6 != 0f && p6 % 360f == 0f)
		{
			z0rgk(p0, p7.z0oek(), p7.z0pek(), p7.z0uek(), p7.z0iek());
		}
		else
		{
			z0srk.z0eek(p7.z0oek(), p7.z0pek(), p7.z0uek(), p7.z0iek(), p4: false, p5: true);
			z0srk.z0eek(p0, p7.z0uek());
			string p9 = z0sok.z0eek(0f, 0f, p7.z0uek(), p7.z0iek(), p5, p5 + p6);
			z0srk.z0tek(p9);
			z0srk.z0eek();
		}
	}

	public override void z0lgk(z0ZzZztfh p0, float p1, float p2, float p3, float p4, float p5)
	{
		if (z0zek != null)
		{
			z0ZzZzbdh p6 = z0eek(p1, p2, p3, p4);
			string p7 = z0eek(p6);
			z0zek.z0eek("rect");
			z0eek(p6.z0vek());
			if (p5 > 0f)
			{
				float num = z0tek(p5);
				if (num > 1f)
				{
					z0zek.z0eek("rx", num);
					z0zek.z0eek("ry", num);
				}
			}
			z0eek(p7);
			z0eek(p0);
			z0zek.z0bg();
		}
		else
		{
			z0ZzZzbdh z0ZzZzbdh2 = z0eek(p1, p2, p3, p4);
			z0srk.z0eek(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek(), p4: false, p5: true);
			z0srk.z0eek(p0, z0ZzZzbdh2.z0uek());
			z0srk.z0tek(z0sok.z0rek(0f, 0f, z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek()));
			z0srk.z0eek();
		}
	}

	public override void z0zhk(string p0, byte[] p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("name");
		}
		if (p1 == null || p1.Length == 0)
		{
			throw new ArgumentNullException("bs");
		}
		z0otk["Doc_" + z0qtk + "/" + p0] = new MemoryStream(p1);
	}

	public override void z0xhk(string p0, string p1, string p2, string p3, DateTime p4, DateTime p5, Dictionary<string, string> p6)
	{
		if (z0zek != null)
		{
			return;
		}
		z0oek();
		z0vek.z0eek("DocBody");
		z0vek.z0eek("DocInfo");
		if (p0 != null && p0.Length > 0)
		{
			z0vek.z0eek("DocID", p0);
		}
		if (p1 != null && p1.Length > 0)
		{
			z0vek.z0eek("Autor", p1);
		}
		if (p2 != null && p2.Length > 0)
		{
			z0vek.z0eek("Creator", p2);
		}
		if (p3 != null && p3.Length > 0)
		{
			z0vek.z0eek("Title", p2);
		}
		z0vek.z0eek("CreationDate", p4.ToString("yyyy-MM-dd HH:mm:ss"));
		z0vek.z0eek("ModDate", p5.ToString("yyyy-MM-dd HH:mm:ss"));
		if ((p6 != null && p6.Count > 0) || (z0jtk != null && z0jtk.Count > 0))
		{
			z0vek.z0eek("CustomDatas");
			if (p6 != null && p6.Count > 0)
			{
				foreach (KeyValuePair<string, string> item in p6)
				{
					z0vek.z0eek("CustomData");
					z0vek.z0rek("Name", item.Key);
					z0vek.z0rek(item.Value);
					z0vek.z0eek();
				}
			}
			if (z0jtk != null && z0jtk.Count > 0)
			{
				using (zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = z0jtk.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XAttribute current2 = z0bpk.Current;
						string p7 = (string.IsNullOrEmpty(current2.Name) ? "" : current2.Name);
						string p8 = (string.IsNullOrEmpty(current2.Value) ? "" : current2.Value);
						z0vek.z0eek("CustomData");
						z0vek.z0rek("Name", p7);
						z0vek.z0rek(p8);
						z0vek.z0eek();
					}
				}
				z0jtk.Clear();
				z0jtk = null;
			}
			z0vek.z0eek();
		}
		z0vek.z0eek();
		z0vek.z0eek("DocRoot");
		z0qtk++;
		z0vek.z0rek("Doc_" + z0qtk + "/Document.xml");
		z0vek.z0eek();
		z0vek.z0eek();
		z0mrk_jiejie20260327142557 = -1;
		z0urk = false;
	}

	private new int z0rek(string p0, string p1)
	{
		if (z0ctk == null)
		{
			z0ctk = new Dictionary<string, z0hnk>();
		}
		z0hnk z0hnk = null;
		if (!z0ctk.TryGetValue(p0.ToLower(), out z0hnk))
		{
			z0hnk = new z0hnk();
			z0hnk.z0tek = p0;
			z0hnk.z0yek = z0eek();
			z0ctk[p0.ToLower()] = z0hnk;
		}
		z0hnk.z0eek(p1);
		return z0hnk.z0yek;
	}

	private void z0eek(z0ZzZzndh p0)
	{
		z0zek.z0tek("x", p0.z0yek());
		z0zek.z0tek("y", p0.z0uek());
		z0zek.z0tek("width", p0.z0iek());
		z0zek.z0tek("height", p0.z0oek());
		if ((float)p0.z0bek() > z0ptk)
		{
			z0ptk = p0.z0bek();
		}
	}

	public override void z0chk(Color p0, float p1, float p2, float p3, float p4)
	{
		z0ZzZzbdh p5 = z0eek(p1, p2, p3, p4);
		if (z0zek != null)
		{
			string p6 = z0eek(p5);
			z0zek.z0eek("rect");
			z0zek.z0eek("x", p5.z0tek());
			z0zek.z0eek("y", p5.z0yek());
			z0zek.z0eek("width", p5.z0uek());
			z0zek.z0eek("height", p5.z0iek());
			if (p5.z0nek() > z0ptk)
			{
				z0ptk = p5.z0nek();
			}
			z0eek(p6);
			z0zek.z0rek("fill", z0ZzZzifh.z0eek(p0));
			z0zek.z0bg();
		}
		else
		{
			z0srk.z0eek(p5.z0oek(), p5.z0pek(), p5.z0uek(), p5.z0iek(), p4: false, p5: true);
			z0srk.z0eek(new z0ZzZzzdh(p0), p5.z0uek());
			z0srk.z0tek(z0sok.z0rek(0f, 0f, p5.z0uek(), p5.z0iek()));
			z0srk.z0eek();
		}
	}

	private string z0eek(string p0, float p1, FontStyle p2, Color p3)
	{
		if (z0qrk != null && z0qrk.Count > 0 && p3.IsBlack)
		{
			foreach (z0ZzZzpej item in z0qrk)
			{
				if (item.z0eek(p0, p1, p2))
				{
					return item.z0oek;
				}
			}
		}
		return null;
	}

	private void z0eek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			z0zek.z0eek("clip-path", "url(#" + p0 + ")");
		}
	}

	public override void z0vhk(GraphicsUnit p0)
	{
		z0atk = p0;
		if (z0zek == null)
		{
			switch (z0atk)
			{
			case GraphicsUnit.Document:
				z0xrk = 0.08466667f;
				break;
			case GraphicsUnit.Inch:
				z0xrk = 25.4f;
				break;
			case GraphicsUnit.Millimeter:
				z0xrk = 1f;
				break;
			case GraphicsUnit.Pixel:
				z0xrk = 0.26458335f;
				break;
			case GraphicsUnit.Point:
				z0xrk = 0.35277778f;
				break;
			default:
				throw new NotSupportedException(z0atk.ToString());
			}
		}
		else
		{
			switch (z0atk)
			{
			case GraphicsUnit.Document:
				z0xrk = 0.32f;
				break;
			case GraphicsUnit.Inch:
				z0xrk = 96f;
				break;
			case GraphicsUnit.Millimeter:
				z0xrk = 3.7795f;
				break;
			case GraphicsUnit.Pixel:
				z0xrk = 1f;
				break;
			case GraphicsUnit.Point:
				z0xrk = 1.3333333f;
				break;
			default:
				throw new NotSupportedException(z0atk.ToString());
			}
		}
	}

	public override void z0bhk(string[] p0)
	{
		z0wrk = p0;
	}

	private void z0eek(string p0, string p1, float p2, FontStyle p3, Color p4, float p5, float p6, float p7, float p8, z0ZzZzpij p9)
	{
		if (z0zek != null)
		{
			z0ZzZzbdh z0ZzZzbdh2 = z0eek(p5, p6, p7, p8);
			z0zek.z0eek("text");
			if (z0ptk < z0ZzZzbdh2.z0nek())
			{
				z0ptk = z0ZzZzbdh2.z0nek();
			}
			bool flag = z0krk.z0nek();
			if (p0.Contains(' ', StringComparison.Ordinal))
			{
				float num = z0krk.z0krk;
				if (num <= 0f)
				{
					num = 1f;
				}
				float num2 = z0krk.z0lrk;
				if (num2 <= 0f)
				{
					num2 = 1f;
				}
				int length = p0.Length;
				StringBuilder stringBuilder = new StringBuilder();
				float num3 = z0ZzZzbdh2.z0tek();
				StringBuilder stringBuilder2 = new StringBuilder();
				for (int i = 0; i < length; i++)
				{
					char c = p0[i];
					if (XTextCharElement.z0tek((int)c))
					{
						stringBuilder2.Append(c);
						stringBuilder2.Append(p0[i + 1]);
						i++;
						stringBuilder.Append(Math.Round(num3 / num));
						stringBuilder.Append(' ');
						num3 += p9.z0eek(p2, z0atk) * z0xrk;
					}
					else if (c == ' ' || XTextCharElement.z0tek(c))
					{
						num3 += p9.z0rek(c, p2, z0atk) * z0xrk;
					}
					else
					{
						stringBuilder2.Append(c);
						stringBuilder.Append(Math.Round(num3 / num));
						stringBuilder.Append(' ');
						num3 += p9.z0rek(c, p2, z0atk) * z0xrk;
					}
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Remove(stringBuilder.Length - 1, 1);
				}
				p0 = stringBuilder2.ToString();
				z0zek.z0rek("x", stringBuilder.ToString());
				z0zek.z0tek("y", (int)Math.Round(z0ZzZzbdh2.z0yek() / num2));
			}
			else
			{
				if (flag)
				{
					z0zek.z0tek("x", (int)(z0ZzZzbdh2.z0tek() / z0krk.z0krk));
					z0zek.z0tek("y", (int)Math.Round(z0ZzZzbdh2.z0yek() / z0krk.z0lrk));
				}
				else
				{
					z0zek.z0tek("x", (int)z0ZzZzbdh2.z0tek());
					z0zek.z0tek("y", (int)Math.Round(z0ZzZzbdh2.z0yek()));
				}
				if (!XTextCharElement.z0rek(p0))
				{
					z0zek.z0eek("textLength", z0ZzZzbdh2.z0uek());
				}
			}
			if (flag)
			{
				z0zek.z0rek("transform", "scale(" + z0krk.z0krk + " " + z0krk.z0lrk + ")");
			}
			bool flag2 = true;
			if (z0crk != null && z0crk.Count > 0)
			{
				z0enk z0enk = z0crk.Peek();
				if (z0enk.z0pek == p1 && z0enk.z0yek == p2 && z0enk.z0eek == p3 && p4.ToArgb() == z0ftk_jiejie20260327142557)
				{
					flag2 = false;
				}
			}
			if (flag2)
			{
				z0rek(p1, p2, p3, p4);
			}
			z0zek.z0yg(p0);
			z0zek.z0bg();
			return;
		}
		z0ZzZzbdh p10 = z0eek(p5, p6, p7, p8);
		z0srk.z0eek("TextObject");
		z0srk.z0uek();
		z0srk.z0eek("Font", z0rek(p1, p0));
		float num4 = z0tek(p9.z0rek(p2, z0atk));
		z0srk.z0eek("Size", p2 * 0.36f);
		z0srk.z0eek(p10);
		if ((p3 & FontStyle.Bold) == FontStyle.Bold)
		{
			z0srk.z0eek("Weight", 700);
		}
		if ((p3 & FontStyle.Italic) == FontStyle.Italic)
		{
			z0srk.z0eek("Italic", p1: true);
		}
		z0srk.z0rek("Stroke", "true");
		z0srk.z0rek(p4);
		z0srk.z0eek("TextCode");
		z0srk.z0rek("X", "0");
		if (p9.z0qrk > 0f && p9.z0bek > 0f)
		{
			z0srk.z0eek("Y", num4 * p9.z0qrk / p9.z0bek);
		}
		else
		{
			z0srk.z0eek("Y", num4 * 0.78f);
		}
		if (p0.Length > 1)
		{
			StringBuilder stringBuilder3 = new StringBuilder();
			for (int j = 0; j < p0.Length; j++)
			{
				float num5 = z0tek(p9.z0rek(p0[j], p2, z0atk));
				if (stringBuilder3.Length > 0)
				{
					stringBuilder3.Append(' ');
				}
				stringBuilder3.Append(num5);
			}
			z0srk.z0rek("DeltaX", stringBuilder3.ToString());
			stringBuilder3 = null;
		}
		z0srk.z0rek(p0);
		z0srk.z0eek();
		z0srk.z0eek();
	}

	[CompilerGenerated]
	public new void z0rek(string p0)
	{
		z0gtk = p0;
	}

	public void z0eek(z0ZzZzwmk p0)
	{
		if (p0 == null || !p0.z0rek() || z0zek == null)
		{
			return;
		}
		int num = (int)(z0yrk * z0xrk);
		int num2 = (int)(z0xtk * z0xrk);
		z0ZzZzsdh z0ZzZzsdh2 = ((p0.Font == null) ? z0ZzZzimk.z0oek : p0.Font.Value);
		if (p0.Repeat)
		{
			string text = "dcw_" + z0mtk++;
			z0zek.z0eek("pattern");
			z0zek.z0eek("iswatermark", "true");
			z0zek.z0eek("id", text);
			z0zek.z0eek("patternUnits", "userSpaceOnUse");
			float num3 = ((p0.DensityForRepeat > 0f) ? (1f / p0.DensityForRepeat) : 1f);
			if (p0.Type == WatermarkType.Text)
			{
				string p1 = text + "_txt";
				z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzlcj.z0rek(GraphicsUnit.Pixel, p0.Text, z0ZzZzsdh2);
				z0zek.z0eek("width", (z0ZzZzxdh2.z0rek() + 10f) * num3);
				z0zek.z0eek("height", z0ZzZzxdh2.z0tek() * 3f * num3);
				float num4 = (z0ZzZzxdh2.z0rek() * num3 - z0ZzZzxdh2.z0rek()) / 3f;
				float num5 = z0ZzZzxdh2.z0tek() * num3;
				z0zek.z0eek("text");
				z0zek.z0rek("id", p1);
				z0zek.z0eek("style", z0eek(z0ZzZzsdh2.z0pek(), z0ZzZzsdh2.z0yek(), z0ZzZzsdh2.z0mek()) + ";fill:" + z0ZzZzifh.z0eek(Color.FromArgb(p0.Alpha, p0.Color)));
				z0zek.z0eek("x", "0");
				z0zek.z0eek("y", "0");
				z0zek.z0eek("textLength", z0ZzZzxdh2.z0rek() + 10f);
				z0zek.z0yg(p0.Text);
				z0zek.z0bg();
				z0zek.z0eek("text");
				z0zek.z0rek("id", p1);
				z0zek.z0eek("style", z0eek(z0ZzZzsdh2.z0pek(), z0ZzZzsdh2.z0yek(), z0ZzZzsdh2.z0mek()) + ";fill:" + z0ZzZzifh.z0eek(Color.FromArgb(p0.Alpha, p0.Color)));
				z0zek.z0eek("x", num4);
				z0zek.z0eek("y", num5);
				z0zek.z0eek("textLength", z0ZzZzxdh2.z0rek() + 10f);
				z0zek.z0yg(p0.Text);
				z0zek.z0bg();
				z0zek.z0eek("text");
				z0zek.z0rek("id", p1);
				z0zek.z0eek("style", z0eek(z0ZzZzsdh2.z0pek(), z0ZzZzsdh2.z0yek(), z0ZzZzsdh2.z0mek()) + ";fill:" + z0ZzZzifh.z0eek(Color.FromArgb(p0.Alpha, p0.Color)));
				z0zek.z0eek("x", num4 * 2f);
				z0zek.z0eek("y", num5 * 2f);
				z0zek.z0eek("textLength", z0ZzZzxdh2.z0rek() + 10f);
				z0zek.z0yg(p0.Text);
				z0zek.z0bg();
			}
			else if (p0.Type == WatermarkType.Image)
			{
				z0ZzZzrfh z0ZzZzrfh2 = (z0ZzZzrfh)p0.Image.Value;
				z0zek.z0eek("width", (float)z0ZzZzrfh2.z0iek() * 1.5f);
				z0zek.z0eek("height", (float)(((z0ZzZzedh)z0ZzZzrfh2).z0yek() * 2) * num3);
				z0zek.z0eek("image");
				z0zek.z0rek("id", text + "_img");
				z0zek.z0eek("x", "0");
				z0zek.z0eek("y", "0");
				z0zek.z0eek("width", (float)z0ZzZzrfh2.z0iek());
				z0zek.z0eek("height", (float)((z0ZzZzedh)z0ZzZzrfh2).z0yek());
				z0zek.z0rek("href", z0ZzZzrfh2.z0eek());
				z0zek.z0bg();
				z0zek.z0eek("use");
				z0zek.z0rek("href", "#" + text + "_img");
				z0zek.z0eek("x", (float)(z0ZzZzrfh2.z0iek() / 2));
				z0zek.z0eek("y", (float)((z0ZzZzedh)z0ZzZzrfh2).z0yek() * num3);
				z0zek.z0bg();
				z0zek.z0eek("rect");
				z0zek.z0eek("x", "0");
				z0zek.z0eek("y", "0");
				z0zek.z0eek("width", (float)z0ZzZzrfh2.z0iek() * 1.5f + 1f);
				z0zek.z0eek("height", (float)(((z0ZzZzedh)z0ZzZzrfh2).z0yek() * 2) * num3 + 1f);
				z0zek.z0eek("stroke", "none");
				z0zek.z0eek("fill", z0ZzZzifh.z0eek(p0.z0tek()));
				z0zek.z0bg();
			}
			z0zek.z0bg();
			z0zek.z0eek("rect");
			z0zek.z0eek("x", "-50%");
			z0zek.z0eek("y", "-50%");
			if (p0.Angle != 0f)
			{
				z0zek.z0eek("transform", "rotate(" + p0.Angle + ",0,0)");
			}
			z0zek.z0eek("width", "200%");
			z0zek.z0eek("height", "200%");
			z0zek.z0eek("fill", "url(#" + text + ")");
			z0zek.z0eek("stroke", "none");
			z0zek.z0bg();
		}
		else if (p0.Type == WatermarkType.Text)
		{
			z0ZzZzxdh z0ZzZzxdh3 = z0ZzZzlcj.z0rek(GraphicsUnit.Pixel, p0.Text, z0ZzZzsdh2);
			z0zek.z0eek("text");
			z0zek.z0eek("iswatermark", "true");
			z0zek.z0eek("user-select", "none");
			z0zek.z0eek("style", z0eek(z0ZzZzsdh2.z0pek(), z0ZzZzsdh2.z0yek(), z0ZzZzsdh2.z0mek()) + ";fill:" + z0ZzZzifh.z0eek(Color.FromArgb(p0.Alpha, p0.Color)));
			z0zek.z0eek("x", ((float)num - z0ZzZzxdh3.z0rek()) / 2f);
			z0zek.z0eek("y", ((float)num2 - z0ZzZzxdh3.z0tek()) / 2f);
			z0zek.z0eek("textLength", z0ZzZzxdh3.z0rek() + 10f);
			if (p0.Angle != 0f)
			{
				z0zek.z0eek("transform", "rotate(" + p0.Angle + "," + num / 2 + "," + num2 / 2 + ")");
			}
			z0zek.z0yg(p0.Text);
			z0zek.z0bg();
		}
		else
		{
			z0ZzZzrfh z0ZzZzrfh3 = (z0ZzZzrfh)p0.Image.Value;
			z0zek.z0eek("image");
			z0zek.z0eek("iswatermark", "true");
			float num6 = Math.Min((float)num / (float)z0ZzZzrfh3.z0iek(), (float)num2 / (float)((z0ZzZzedh)z0ZzZzrfh3).z0yek());
			int num7 = (int)((float)z0ZzZzrfh3.z0iek() * num6) - 5;
			int num8 = (int)((float)((z0ZzZzedh)z0ZzZzrfh3).z0yek() * num6) - 5;
			z0zek.z0eek("x", (float)((num - num7) / 2));
			z0zek.z0eek("y", (float)((num2 - num8) / 2));
			z0zek.z0eek("width", (float)num7);
			z0zek.z0eek("height", (float)num8);
			z0zek.z0rek("href", z0ZzZzrfh3.z0eek());
			if (p0.Angle != 0f)
			{
				z0zek.z0eek("transform", "rotate(" + p0.Angle + "," + num / 2 + "," + num2 / 2 + ")");
			}
			z0zek.z0bg();
			z0zek.z0eek("rect");
			z0zek.z0eek("x", (float)((num - num7) / 2 - 2));
			z0zek.z0eek("y", (float)((num2 - num8) / 2 - 2));
			z0zek.z0eek("width", (float)(num7 + 4));
			z0zek.z0eek("height", (float)(num8 + 4));
			if (p0.Angle != 0f)
			{
				z0zek.z0eek("transform", "rotate(" + p0.Angle + "," + num / 2 + "," + num2 / 2 + ")");
			}
			z0zek.z0eek("stroke", "none");
			z0zek.z0eek("fill", z0ZzZzifh.z0eek(p0.z0tek()));
			z0zek.z0bg();
		}
	}

	public void z0eek(z0ZzZzimk p0)
	{
		if (p0 == null)
		{
			return;
		}
		z0ZzZzpej z0ZzZzpej2 = new z0ZzZzpej(p0.Name, p0.Size, p0.Style);
		if (z0qrk == null)
		{
			z0qrk = new List<z0ZzZzpej>();
		}
		foreach (z0ZzZzpej item in z0qrk)
		{
			if (item.z0eek(z0ZzZzpej2))
			{
				return;
			}
		}
		z0qrk.Add(z0ZzZzpej2);
	}

	private new z0ZzZzodh z0tek(float p0, float p1)
	{
		z0ZzZzpdh z0ZzZzpdh2 = z0krk.z0tek_jiejie20260327142557(p0 + z0nrk, p1 + z0zrk);
		return new z0ZzZzodh((int)Math.Round(z0ZzZzpdh2.z0rek() * z0xrk), (int)Math.Round(z0ZzZzpdh2.z0tek() * z0xrk));
	}

	private new z0ZzZzpdh z0yek(float p0, float p1)
	{
		z0ZzZzpdh result = z0krk.z0tek_jiejie20260327142557(p0 + z0nrk, p1 + z0zrk);
		result.z0eek(z0eek(result.z0rek() * z0xrk));
		result.z0rek(z0eek(result.z0tek() * z0xrk));
		return result;
	}

	private XTextElement z0eek(XTextCharElement p0)
	{
		if (z0lrk != null)
		{
			for (XTextContainerElement xTextContainerElement = p0.z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0uik)
			{
				if (z0lrk.ContainsKey(xTextContainerElement))
				{
					return xTextContainerElement;
				}
			}
		}
		return null;
	}

	private z0ZzZznej()
	{
	}

	public static z0ZzZzpdh z0eek(z0ZzZzbdh p0, float p1)
	{
		double num = p0.z0uek() / 2f;
		double num2 = p0.z0iek() / 2f;
		if (num <= 0.0 || num2 <= 0.0)
		{
			return new z0ZzZzpdh(p0.z0tek(), p0.z0yek());
		}
		double num3 = (double)p1 * Math.PI / 180.0;
		double num4 = Math.Sin(num3);
		double num5 = Math.Cos(num3);
		double num6 = num * num2 / Math.Sqrt(Math.Pow(num4 * num, 2.0) + Math.Pow(num5 * num2, 2.0));
		double num7 = num6 * num5;
		double num8 = num6 * num4;
		float p2 = (float)((double)p0.z0tek() + num + num7);
		float p3 = (float)((double)p0.z0yek() + num2 + num8);
		return new z0ZzZzpdh(p2, p3);
	}

	internal new void z0uek()
	{
		if (z0jrk == null || z0jrk.Count == 0)
		{
			return;
		}
		if (z0zek != null)
		{
			z0zek.z0eek("text");
			z0zek.z0ig("x");
			z0zek.z0eek(z0ZzZzhqh.z0vhj.z0nek);
			int count = z0itk.Count;
			TextWriter textWriter = z0zek.z0yek();
			for (int i = 0; i < count; i++)
			{
				int p = z0tek(z0itk[i], 0f).z0rek();
				int num = z0ZzZzhqh.z0rek(z0ytk, 0, p);
				if (i < count - 1)
				{
					z0ytk[num++] = ' ';
				}
				textWriter.Write(z0ytk, 0, num);
			}
			z0zek.z0cg();
			z0zek.z0rek("y", z0tek(0f, z0ork).z0tek());
			z0rek(z0trk, z0etk, z0vrk, z0erk);
			z0zek.z0eek(z0ZzZzhqh.z0vhj.z0nek);
			textWriter.Write(z0jrk.z0krk(), 0, z0jrk.Count);
			z0yek(z0eek(z0dtk));
			z0zek.z0bg();
		}
		else
		{
			string text = new string(z0jrk.z0krk(), 0, z0jrk.Count);
			FontStyle fontStyle = z0vrk;
			float num2 = z0etk;
			z0ZzZzpij z0ZzZzpij2 = z0ZzZzpij.z0eek(z0trk, fontStyle);
			z0tek(z0itk[0], z0ork);
			z0srk.z0eek("TextObject");
			int num3 = z0eek();
			z0srk.z0eek("ID", num3);
			z0srk.z0eek("Font", z0rek(z0ZzZzpij2.z0wrk, text));
			float num4 = z0ZzZzpij2.z0rek(z0etk, z0atk);
			z0ZzZzbdh p2 = z0eek(z0itk[0], z0ork, z0itk[z0itk.Count - 1] + num4, num4 + 10f);
			z0srk.z0eek(p2);
			z0srk.z0eek("Size", num2 * 0.36f);
			if ((fontStyle & FontStyle.Bold) == FontStyle.Bold)
			{
				z0srk.z0eek("Weight", 700);
			}
			if ((fontStyle & FontStyle.Italic) == FontStyle.Italic)
			{
				z0srk.z0eek("Italic", p1: true);
			}
			z0srk.z0rek("Stroke", "true");
			z0srk.z0rek(z0erk);
			z0srk.z0eek("TextCode");
			z0srk.z0rek("X", "0");
			num4 = z0tek(num4);
			if (z0ZzZzpij2.z0qrk > 0f && z0ZzZzpij2.z0bek > 0f)
			{
				z0srk.z0eek("Y", num4 * z0ZzZzpij2.z0qrk / z0ZzZzpij2.z0bek);
			}
			else
			{
				z0srk.z0eek("Y", num4 * 0.78f);
			}
			z0ZzZzhqh z0ZzZzhqh2 = z0srk.z0pek;
			int count2 = z0itk.Count;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			float num5 = z0itk[0];
			for (int j = 1; j < count2; j++)
			{
				float num6 = z0tek(z0itk[j] - num5);
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(num6);
				num5 = z0itk[j];
			}
			string p3 = stringBuilder.ToString();
			z0ZzZzhqh2.z0rek("DeltaX", p3);
			if (z0ktk != null && z0lrk != null)
			{
				for (XTextContainerElement xTextContainerElement = z0ktk.z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0uik)
				{
					if (z0lrk.TryGetValue(xTextContainerElement, out z0omk_jiejie20260327142557 z0omk_jiejie20260327142557))
					{
						if (z0omk_jiejie20260327142557.z0rek == null)
						{
							z0omk_jiejie20260327142557.z0rek = new List<int>();
						}
						z0omk_jiejie20260327142557.z0rek.Add(z0mrk_jiejie20260327142557);
						z0omk_jiejie20260327142557.z0rek.Add(num3);
					}
				}
			}
			stringBuilder.Clear();
			stringBuilder = null;
			z0ZzZzhqh2.z0yg(text);
			z0ZzZzhqh2.z0bg();
			z0ZzZzhqh2.z0bg();
		}
		z0jrk.Clear();
		z0itk.Clear();
		z0trk = null;
	}

	public static void z0eek(DCStdImageKey p0, string p1)
	{
		if (z0prk == null)
		{
			z0prk = new Dictionary<DCStdImageKey, string>();
		}
		z0prk[p0] = p1;
	}

	private void z0eek(z0ZzZzudh p0)
	{
		string p1 = z0ZzZzifh.z0eek(p0.z0nek());
		if (z0drk && p0.z0nek() == Color.White)
		{
			p1 = "none";
		}
		z0zek.z0eek("stroke", p1);
		if (p0.z0oek() > 1f)
		{
			double num = z0ZzZzrpk.z0rek((double)p0.z0oek(), GraphicsUnit.Document);
			if (num > 1.0)
			{
				z0zek.z0eek("stroke-width", num.ToString());
			}
		}
		switch (p0.z0tek())
		{
		case DashStyle.Dash:
			z0zek.z0eek("stroke-dasharray", "5,5");
			break;
		case DashStyle.DashDot:
			z0zek.z0eek("stroke-dasharray", "5,2");
			break;
		case DashStyle.DashDotDot:
			z0zek.z0eek("stroke-dasharray", "5,2,2");
			break;
		case DashStyle.Dot:
			z0zek.z0eek("stroke-dasharray", "2,2");
			break;
		}
	}

	private new void z0rek(string p0, float p1, FontStyle p2, Color p3)
	{
		bool flag = true;
		if (z0qrk != null && z0qrk.Count > 0)
		{
			foreach (z0ZzZzpej item in z0qrk)
			{
				if (item.z0eek(p0, p1, p2))
				{
					string p4 = item.z0oek;
					z0zek.z0rek("class", p4);
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			z0zek.z0rek("style", z0eek(p0, p1, p2) + ";fill:" + z0ZzZzifh.z0eek(p3));
		}
		else if (p3.ToArgb() != z0ftk_jiejie20260327142557)
		{
			z0zek.z0rek("style", "fill:" + z0ZzZzifh.z0eek(p3));
		}
	}

	private int z0eek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("bs");
		}
		if (z0cek == null)
		{
			z0cek = new List<z0unk>();
		}
		foreach (z0unk item in z0cek)
		{
			if (item.z0eek == p0)
			{
				return item.z0yek;
			}
		}
		int num = 0;
		for (int num2 = p0.Length - 1; num2 >= 0; num2--)
		{
			byte b = p0[num2];
			num = num + b + (b << 3);
		}
		foreach (z0unk item2 in z0cek)
		{
			if (item2.z0iek != num || item2.z0eek.Length != p0.Length)
			{
				continue;
			}
			bool flag = true;
			for (int num3 = p0.Length - 1; num3 >= 0; num3--)
			{
				if (p0[num3] != item2.z0eek[num3])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return item2.z0yek;
			}
		}
		z0unk z0unk = new z0unk();
		z0unk.z0yek = z0eek();
		z0unk.z0eek = p0;
		z0unk.z0iek = num;
		if (z0ZzZzpuk.z0tek(p0))
		{
			z0unk.z0uek = ".bmp";
			z0unk.z0rek = "BMP";
		}
		else if (z0ZzZzpuk.z0uek(p0))
		{
			z0unk.z0uek = ".jpg";
			z0unk.z0rek = "JPEG";
		}
		else if (z0ZzZzpuk.z0yek(p0))
		{
			z0unk.z0uek = ".png";
			z0unk.z0rek = "PNG";
		}
		else if (z0ZzZzpuk.z0eek(p0))
		{
			z0unk.z0uek = ".gif";
		}
		z0unk.z0uek = "image_" + z0unk.z0yek + z0unk.z0uek;
		z0unk.z0tek = "Image";
		z0cek.Add(z0unk);
		return z0unk.z0yek;
	}

	public override void z0nhk(z0ZzZzudh p0, float p1, float p2, float p3, float p4, float p5)
	{
		z0uek();
		if (z0zek != null)
		{
			z0ZzZzbdh p6 = z0eek(p1, p2, p3, p4);
			string p7 = z0eek(p6);
			z0zek.z0eek("rect");
			z0eek(p6.z0vek());
			if (p5 > 0f)
			{
				float num = z0tek(p5);
				if (num > 1f)
				{
					z0zek.z0eek("rx", num);
					z0zek.z0eek("ry", num);
				}
			}
			z0eek(p7);
			z0zek.z0eek("fill", "none");
			z0eek(p0);
			z0zek.z0bg();
		}
		else
		{
			z0ZzZzbdh z0ZzZzbdh2 = z0eek(p1, p2, p3, p4);
			z0srk.z0eek(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek(), p4: true, p5: false);
			z0srk.z0eek(p0);
			z0srk.z0eek(p0.z0nek());
			z0srk.z0tek(z0sok.z0rek(0f, 0f, z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek()));
			z0srk.z0eek();
		}
	}

	private string z0eek(z0ZzZzbdh p0)
	{
		if (!z0htk.z0bek() && !z0htk.z0eek(p0))
		{
			if (z0crk != null && z0crk.Count > 0)
			{
				z0enk z0enk = z0crk.Peek();
				if (z0enk.z0oek || z0ZzZzbdh.z0eek(z0enk.z0rek, z0htk))
				{
					return null;
				}
			}
			string text = "dccp_" + z0irk++;
			z0zek.z0eek("clippath");
			z0zek.z0eek("id", text);
			z0zek.z0eek("rect");
			z0ZzZzndh z0ZzZzndh2 = z0htk.z0vek();
			z0zek.z0tek("x", z0ZzZzndh2.z0pek() - 1);
			z0zek.z0tek("y", z0ZzZzndh2.z0mek() - 1);
			z0zek.z0tek("width", z0ZzZzndh2.z0iek() + 2);
			z0zek.z0tek("height", z0ZzZzndh2.z0oek() + 2);
			z0zek.z0bg();
			z0zek.z0bg();
			return text;
		}
		return null;
	}

	public override void z0mhk(string p0, z0ZzZzbdh p1, string p2, float p3, FontStyle p4, bool p5)
	{
		z0uek();
		if (z0zek != null)
		{
			if (z0crk == null)
			{
				z0crk = new Stack<z0enk>();
			}
			z0enk z0enk = new z0enk();
			if (!p1.z0bek())
			{
				z0enk.z0rek = z0eek(p1.z0oek() - 2f, p1.z0pek() - 2f, p1.z0uek() + 4f, p1.z0iek() + 7f);
				z0enk.z0oek = false;
			}
			else
			{
				z0enk.z0oek = true;
			}
			z0enk.z0pek = p2;
			z0enk.z0yek = p3;
			z0enk.z0eek = p4;
			if (z0zek.z0yek() is StringWriter)
			{
				z0zek.z0eek(z0ZzZzhqh.z0vhj.z0nek);
				z0enk.z0iek = (z0enk.z0uek = ((StringWriter)z0zek.z0yek()).GetStringBuilder()).Length;
			}
			string p6 = null;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				z0htk = z0enk.z0rek;
				p6 = z0eek(new z0ZzZzbdh(-10000f, -10000f, 1f, 1f));
			}
			z0zek.z0eek("g");
			if (p0 != null && p0.Length > 0)
			{
				z0zek.z0eek("id", p0);
			}
			if (p2 != null && p2.Length > 0)
			{
				z0rek(p2, p3, p4, Color.Black);
			}
			z0eek(p6);
			if (p5)
			{
				z0zek.z0rek("shape-rendering", "auto");
			}
			z0crk.Push(z0enk);
			if (z0enk.z0uek != null)
			{
				z0enk.z0tek = z0enk.z0uek.Length;
			}
		}
	}

	public new string z0iek()
	{
		if (z0rtk == null)
		{
			if (z0krk.z0iek())
			{
				z0rtk = string.Empty;
			}
			else
			{
				float[] array = z0krk.z0yek();
				z0rtk = array[0] + " " + array[1] + " " + array[2] + " " + array[3] + " " + array[4] + " " + array[5];
			}
		}
		if (z0rtk == string.Empty)
		{
			return null;
		}
		return z0rtk;
	}

	private void z0oek()
	{
		if (z0urk)
		{
			return;
		}
		z0mek();
		z0yxk z0yxk = z0eek("Doc_" + z0qtk + "/Document.xml", "Document");
		z0yxk.z0eek("CommonData");
		z0yxk.z0eek("MaxUnitID", z0ntk.ToString());
		z0yxk.z0eek("PageArea");
		z0yxk.z0eek("PhysicalBox", "0 0 " + z0yrk + " " + z0xtk);
		z0yxk.z0eek();
		if ((z0ctk != null && z0ctk.Count > 0) || (z0cek != null && z0cek.Count > 0))
		{
			z0yxk.z0eek("PublicRes", "PublicRes.xml");
			z0yxk z0yxk2 = z0eek("Doc_" + z0qtk + "/PublicRes.xml", "Res");
			z0yxk2.z0rek("BaseLoc", "Res");
			if (z0ctk != null && z0ctk.Count > 0)
			{
				z0yxk2.z0eek("Fonts");
				int num = 0;
				foreach (z0hnk value in z0ctk.Values)
				{
					num++;
					z0yxk2.z0eek("Font");
					z0yxk2.z0rek("ID", value.z0yek.ToString());
					byte[] array = null;
					if (z0wtk)
					{
						array = value.z0eek();
					}
					if (array != null && array.Length != 0)
					{
						z0yxk2.z0rek("FontName", "font_" + num);
						z0yxk2.z0rek("OriginalName", value.z0tek);
						string text = "font_" + num + ".ttf";
						z0otk["Doc_" + z0qtk + "/Res/" + text] = new MemoryStream(array);
						z0yxk2.z0eek("FontFile");
						z0yxk2.z0rek(text);
						z0yxk2.z0eek();
					}
					else
					{
						z0yxk2.z0rek("FontName", value.z0tek);
					}
					z0yxk2.z0eek();
				}
				z0yxk2.z0eek();
				z0ctk.Clear();
			}
			if (z0cek != null && z0cek.Count > 0)
			{
				z0yxk2.z0eek("MultiMedias");
				foreach (z0unk item in z0cek)
				{
					z0yxk2.z0eek("MultiMedia");
					z0yxk2.z0rek("ID", item.z0yek.ToString());
					z0yxk2.z0rek("Type", item.z0tek);
					if (item.z0rek != null && item.z0rek.Length > 0)
					{
						z0yxk2.z0rek("Format", item.z0rek);
					}
					z0yxk2.z0eek("MediaFile", item.z0uek);
					z0otk["Doc_" + z0qtk + "/Res/" + item.z0uek] = new MemoryStream(item.z0eek);
					z0yxk2.z0eek();
				}
				z0yxk2.z0eek();
				z0cek.Clear();
			}
			z0yxk2.z0tek();
		}
		z0yxk.z0eek();
		z0yxk.z0eek("Pages");
		for (int i = 0; i <= z0mrk_jiejie20260327142557; i++)
		{
			z0yxk.z0eek("Page");
			z0yxk.z0uek();
			z0yxk.z0rek("BaseLoc", "Pages/Page_" + i + "/Content.xml");
			z0yxk.z0eek();
		}
		z0yxk.z0eek();
		z0yxk.z0tek();
		z0mrk_jiejie20260327142557 = -1;
		z0cek = null;
		z0ctk = null;
		z0urk = true;
	}

	public override void z0phk(float p0, float p1)
	{
		z0mek();
		z0yrk = z0tek(p0);
		z0xtk = z0tek(p1);
		z0mrk_jiejie20260327142557++;
		z0stk.Add(z0eek());
		z0srk = z0eek("Doc_" + z0qtk + "/Pages/Page_" + z0mrk_jiejie20260327142557 + "/Content.xml", "Page");
		z0srk.z0eek("Area");
		z0srk.z0eek("PhysicalBox", "0 0 " + z0yrk + " " + z0xtk);
		z0srk.z0eek();
		z0srk.z0eek("Content");
		z0srk.z0eek("Layer");
		z0srk.z0uek();
	}

	public override GraphicsUnit z0ohk()
	{
		return z0atk;
	}

	public override void z0ihk(string p0, string p1, float p2, FontStyle p3, Color p4, z0ZzZzbdh p5, z0ZzZzlsh p6)
	{
		if (p0 == null || p0.Length == 0 || (p0.Length == 1 && p0[0] == ' '))
		{
			return;
		}
		z0uek();
		if (p6 == null)
		{
			p6 = z0ZzZzlsh.z0uek();
		}
		z0ZzZzpij z0ZzZzpij2 = z0ZzZzpij.z0eek(p1, p3);
		if (z0ZzZzpij2 == null || !z0ZzZzpij2.z0eek(p0))
		{
			z0ZzZzpij2 = z0grk;
			if (z0ZzZzpij2 == null)
			{
				throw new InvalidOperationException("DefaultTrueTypeFont=null");
			}
			p1 = z0ZzZzpij2.z0wrk;
		}
		if (XTextCharElement.z0rek(p0) && p6.z0pek() == StringAlignment.Near && p6.z0tek() == StringAlignment.Near)
		{
			z0eek(p0, p1, p2, p3, p4, p5.z0oek(), p5.z0pek(), p5.z0uek(), p5.z0iek(), z0ZzZzpij2);
			return;
		}
		if (z0rrk == null)
		{
			throw new NotSupportedException("OFD.EventLayoutString");
		}
		string[] lines = null;
		z0ZzZzbdh[] array = z0rrk(z0atk, p0, p1, p2, p3, p5, p6, out lines);
		if (array != null && array.Length != 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				z0ZzZzbdh z0ZzZzbdh2 = array[i];
				z0eek(lines[i], p1, p2, p3, p4, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek(), z0ZzZzpij2);
			}
		}
	}

	private void z0pek()
	{
		if (z0btk)
		{
			z0btk = false;
			z0zek.z0eek("rect");
			z0zek.z0eek("dctype", "contentheight");
			z0zek.z0eek("width", "0");
			z0zek.z0eek("height", "0");
			z0zek.z0eek("value", z0ptk.ToString());
			z0zek.z0bg();
			z0zek.z0bg();
		}
	}

	public override void z0uhk(z0ZzZzudh p0, float p1, float p2, float p3, float p4)
	{
		if (p1 == p3 && p2 == p4)
		{
			return;
		}
		z0uek();
		if (z0zek != null)
		{
			z0ZzZzodh z0ZzZzodh2 = z0tek(p1, p2);
			z0ZzZzodh z0ZzZzodh3 = z0tek(p3, p4);
			string p5 = null;
			if (!z0htk.z0bek())
			{
				float num;
				float num2;
				if (z0ZzZzodh2.z0rek() < z0ZzZzodh3.z0rek())
				{
					num = z0ZzZzodh2.z0rek();
					num2 = z0ZzZzodh3.z0rek();
				}
				else
				{
					num = z0ZzZzodh3.z0rek();
					num2 = z0ZzZzodh2.z0rek();
				}
				float num3;
				float num4;
				if (z0ZzZzodh2.z0tek() < z0ZzZzodh3.z0tek())
				{
					num3 = z0ZzZzodh2.z0tek();
					num4 = z0ZzZzodh3.z0tek();
				}
				else
				{
					num3 = z0ZzZzodh3.z0tek();
					num4 = z0ZzZzodh2.z0tek();
				}
				if (num < z0htk.z0oek() - 1f || num3 < z0htk.z0pek() - 1f || num2 > z0htk.z0mek() + 1f || num4 > z0htk.z0nek() + 1f)
				{
					p5 = z0eek(new z0ZzZzbdh(num, num3, num2 - num, num4 - num3));
				}
			}
			z0zek.z0eek("line");
			if (z0ZzZzodh2.z0rek() == z0ZzZzodh3.z0rek())
			{
				z0zek.z0eek("x1", z0ZzZzodh2.z0rek(), p2: false);
				z0zek.z0tek("y1", z0ZzZzodh2.z0tek());
				z0zek.z0eek("x2", z0ZzZzodh3.z0rek(), p2: false);
				z0zek.z0tek("y2", z0ZzZzodh3.z0tek());
			}
			else if (z0ZzZzodh2.z0tek() == z0ZzZzodh3.z0tek())
			{
				z0zek.z0tek("x1", z0ZzZzodh2.z0rek());
				z0zek.z0eek("y1", z0ZzZzodh2.z0tek(), p2: false);
				z0zek.z0tek("x2", z0ZzZzodh3.z0rek());
				z0zek.z0eek("y2", z0ZzZzodh3.z0tek(), p2: false);
			}
			else
			{
				z0zek.z0tek("x1", z0ZzZzodh2.z0rek());
				z0zek.z0tek("y1", z0ZzZzodh2.z0tek());
				z0zek.z0tek("x2", z0ZzZzodh3.z0rek());
				z0zek.z0tek("y2", z0ZzZzodh3.z0tek());
			}
			z0eek(p5);
			z0eek(p0);
			z0zek.z0bg();
			return;
		}
		float num5 = 0.1f;
		if (p0.z0oek() > 1f)
		{
			num5 = p0.z0oek() * 0.07f / 2f;
		}
		z0ZzZzpdh z0ZzZzpdh2 = z0yek(p1, p2);
		z0ZzZzpdh z0ZzZzpdh3 = z0yek(p3, p4);
		if (z0ptk < z0ZzZzpdh2.z0tek())
		{
			z0ptk = z0ZzZzpdh2.z0tek();
		}
		if (z0ptk < z0ZzZzpdh3.z0tek())
		{
			z0ptk = z0ZzZzpdh3.z0tek();
		}
		float num6 = ((z0ZzZzpdh2.z0rek() < z0ZzZzpdh3.z0rek()) ? z0ZzZzpdh2.z0rek() : z0ZzZzpdh3.z0rek());
		float num7 = ((z0ZzZzpdh2.z0tek() < z0ZzZzpdh3.z0tek()) ? z0ZzZzpdh2.z0tek() : z0ZzZzpdh3.z0tek());
		float num8 = Math.Abs(z0ZzZzpdh2.z0rek() - z0ZzZzpdh3.z0rek());
		float num9 = Math.Abs(z0ZzZzpdh2.z0tek() - z0ZzZzpdh3.z0tek());
		float num10 = Math.Max(2f, num5 * 2f);
		if (num8 < num10)
		{
			num6 -= num10 / 2f;
			num8 = num10;
		}
		if (num9 < num10)
		{
			num7 -= num10 / 2f;
			num9 = num10;
		}
		z0srk.z0eek(num6 - 1f, num7 - 1f, num8 + 2f, num9 + 2f, p4: true, p5: false);
		if (num5 > 0f)
		{
			z0srk.z0eek("LineWidth", num5);
		}
		z0srk.z0eek(p0.z0tek(), num5);
		z0srk.z0eek(p0.z0nek());
		StringBuilder stringBuilder = new StringBuilder();
		z0sok.z0eek(stringBuilder, 'M');
		float num11 = 0f;
		float num12 = 0f;
		if (p0.z0oek() > 3f)
		{
			if (p1 == p3)
			{
				num11 = num5;
			}
			else if (p2 == p4)
			{
				num12 = num5;
			}
		}
		z0sok.z0eek(stringBuilder, z0ZzZzpdh2.z0rek() - num6 + num11 + 1f);
		z0sok.z0eek(stringBuilder, z0ZzZzpdh2.z0tek() - num7 + num12 + 1f);
		z0sok.z0eek(stringBuilder, 'L');
		z0sok.z0eek(stringBuilder, z0ZzZzpdh3.z0rek() - num6 + num11 + 1f);
		z0sok.z0eek(stringBuilder, z0ZzZzpdh3.z0tek() - num7 + num12 + 1f);
		string p6 = stringBuilder.ToString();
		z0srk.z0tek(p6);
		z0srk.z0eek();
	}

	private new static z0ZzZzbdh z0rek(float p0, float p1, float p2, float p3)
	{
		float num;
		float num2;
		if (p0 < p2)
		{
			num = p0;
			num2 = p2 - p0;
		}
		else
		{
			num = p2;
			num2 = p0 - p2;
		}
		float num3;
		float num4;
		if (p1 < p3)
		{
			num3 = p1;
			num4 = p3 - p1;
		}
		else
		{
			num3 = p3;
			num4 = p1 - p3;
		}
		if (p0 == p2)
		{
			num -= 4f;
			num2 += 8f;
		}
		if (p1 == p3)
		{
			num3 -= 4f;
			num4 += 2f;
		}
		return new z0ZzZzbdh(num, num3, num2, num4);
	}

	public override void z0yhk(z0ZzZzudh p0, float p1, float p2, float p3, float p4)
	{
		z0uek();
		z0ZzZzbdh p5 = z0eek(p1, p2, p3, p4);
		if (z0zek != null)
		{
			if (z0ptk < p5.z0nek())
			{
				z0ptk = p5.z0nek();
			}
			string p6 = z0eek(p5);
			z0zek.z0eek("ellipse");
			z0zek.z0tek("cx", (int)(p5.z0tek() + p5.z0uek() / 2f));
			z0zek.z0tek("cy", (int)(p5.z0yek() + p5.z0iek() / 2f));
			z0zek.z0tek("rx", (int)(p5.z0uek() / 2f));
			z0zek.z0tek("ry", (int)(p5.z0iek() / 2f));
			z0eek(p6);
			z0eek(p0);
			z0zek.z0eek("fill", "none");
			z0zek.z0bg();
		}
		else
		{
			z0srk.z0eek(p5.z0oek(), p5.z0pek(), p5.z0uek(), p5.z0iek(), p4: true, p5: false);
			z0srk.z0eek(p0);
			z0srk.z0yek();
			z0srk.z0eek(p0.z0nek());
			z0srk.z0tek(z0sok.z0eek(p1, p2, p3, p4));
			z0srk.z0eek();
		}
	}

	private new float z0tek(float p0)
	{
		return z0eek(p0 * z0xrk);
	}

	private void z0mek()
	{
		if (z0srk != null)
		{
			z0srk.z0eek();
			z0srk.z0eek();
			z0srk.z0tek();
			z0srk = null;
		}
	}

	private static string z0eek(string p0, float p1, FontStyle p2)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("dominant-baseline:text-before-edge");
		if (p0 != null && p0.Length > 0)
		{
			stringBuilder.Append(";font-family:" + p0);
		}
		else
		{
			stringBuilder.Append(";font-family:" + z0ZzZzimk.DefaultFontName);
		}
		if (p1 > 0f)
		{
			stringBuilder.Append(";font-size:" + p1 + "pt");
		}
		if ((p2 & FontStyle.Italic) == FontStyle.Italic)
		{
			stringBuilder.Append(";font-style:italic");
		}
		else
		{
			stringBuilder.Append(";font-style:normal");
		}
		if ((p2 & FontStyle.Bold) == FontStyle.Bold)
		{
			stringBuilder.Append(";font-weight:bold");
		}
		else
		{
			stringBuilder.Append(";font-weight:normal");
		}
		return stringBuilder.ToString();
	}

	public override void z0thk()
	{
		z0uek();
		if (z0zek == null)
		{
			return;
		}
		z0enk z0enk = z0crk.Pop();
		z0htk = z0enk.z0rek;
		z0zek.z0bg();
		if (z0enk.z0uek != null)
		{
			if (z0enk.z0uek.Length - z0enk.z0tek < 5)
			{
				z0enk.z0uek.Remove(z0enk.z0iek, z0enk.z0uek.Length - z0enk.z0iek);
			}
			z0enk.z0uek = null;
		}
	}

	public override bool z0rhk()
	{
		return z0zek != null;
	}

	[CompilerGenerated]
	public new void z0tek(string p0)
	{
		z0frk = p0;
	}

	private new void z0yek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			((z0ZzZzdqh)z0zek).z0rek("title", p0);
		}
	}

	public override void z0ehk(object p0)
	{
		if (p0 is z0txk z0txk)
		{
			z0krk = z0txk.z0tek;
			z0atk = z0txk.z0eek;
			z0htk = z0txk.z0rek;
			z0rtk = null;
		}
	}

	private void z0eek(z0omk_jiejie20260327142557 p0, XTextContainerElement p1)
	{
		if (p1.z0xek() <= 0)
		{
			return;
		}
		z0ZzZzpoj z0ZzZzpoj2 = new z0ZzZzpoj();
		List<z0omk_jiejie20260327142557> list = null;
		foreach (XTextElement item in p1.z0be().z0xrk())
		{
			if (item is XTextFieldElementBase xTextFieldElementBase)
			{
				z0omk_jiejie20260327142557 z0omk_jiejie20260327142557 = new z0omk_jiejie20260327142557();
				z0lrk[xTextFieldElementBase] = z0omk_jiejie20260327142557;
				z0omk_jiejie20260327142557.z0yek = xTextFieldElementBase;
				z0omk_jiejie20260327142557.z0eek = z0ZzZzpoj2.z0rek(xTextFieldElementBase);
				if (list == null)
				{
					list = new List<z0omk_jiejie20260327142557>();
				}
				list.Add(z0omk_jiejie20260327142557);
				z0eek(z0omk_jiejie20260327142557, xTextFieldElementBase);
			}
			else if (item is XTextContainerElement p2)
			{
				z0eek(p0, p2);
			}
		}
		if (list != null)
		{
			p0.z0tek = list.ToArray();
			list.Clear();
			list = null;
		}
	}

	public new void z0rek(XTextContainerElement p0)
	{
		z0lrk = new Dictionary<XTextContainerElement, z0omk_jiejie20260327142557>();
		z0utk = new z0omk_jiejie20260327142557();
		z0utk.z0yek = p0;
		if (!(p0 is XTextDocument) && !(p0 is XTextDocumentContentElement))
		{
			z0utk.z0eek = new z0ZzZzpoj().z0rek(p0);
		}
		z0eek(z0utk, p0);
	}

	private new void z0rek(z0ZzZztfh p0)
	{
		if (z0zek == null)
		{
			return;
		}
		if (p0 is z0ZzZzxfh)
		{
			z0ZzZzxfh z0ZzZzxfh2 = (z0ZzZzxfh)p0;
			if (z0ZzZzxfh2.z0oek != null)
			{
				return;
			}
			z0ZzZzxfh2.z0oek = "dc_lb_" + z0mtk++;
			z0zek.z0eek("linearGradient");
			z0zek.z0eek("id", z0ZzZzxfh2.z0oek);
			switch (z0ZzZzxfh2.z0mek)
			{
			case (z0ZzZzzfh)1:
				z0zek.z0eek("gradientTransform", "rotate(90)");
				break;
			case (z0ZzZzzfh)3:
				z0zek.z0eek("gradientTransform", "rotate(45)");
				break;
			case (z0ZzZzzfh)2:
				z0zek.z0eek("gradientTransform", "rotate(-45)");
				break;
			}
			z0ZzZzpfh z0ZzZzpfh2 = z0ZzZzxfh2.z0eek();
			if (z0ZzZzpfh2 != null && z0ZzZzpfh2.z0eek() != null && z0ZzZzpfh2.z0eek().Length != 0 && z0ZzZzpfh2.z0rek() != null && z0ZzZzpfh2.z0rek().Length == z0ZzZzpfh2.z0eek().Length)
			{
				for (int i = 0; i < z0ZzZzpfh2.z0eek().Length; i++)
				{
					z0zek.z0eek("stop");
					z0zek.z0eek("stop-color", z0ZzZzifh.z0eek(z0ZzZzpfh2.z0eek()[i]));
					z0zek.z0eek("offset", Convert.ToString(z0ZzZzpfh2.z0rek()[i] * 100f) + "%");
					z0zek.z0bg();
				}
			}
			else
			{
				z0zek.z0eek("offset", "0%");
				z0zek.z0eek("stop-color", z0ZzZzifh.z0eek(z0ZzZzxfh2.z0uek));
				z0zek.z0bg();
				z0zek.z0eek("stop");
				z0zek.z0eek("offset", "100%");
				z0zek.z0eek("stop-color", z0ZzZzifh.z0eek(z0ZzZzxfh2.z0iek));
				z0zek.z0bg();
			}
			z0zek.z0bg();
		}
		else
		{
			if (!(p0 is z0ZzZzdsh))
			{
				return;
			}
			z0ZzZzdsh z0ZzZzdsh2 = (z0ZzZzdsh)p0;
			if (z0ZzZzdsh2.z0tek == null)
			{
				z0ZzZzdsh2.z0tek = "dc_tb_" + z0mtk++;
				z0zek.z0eek("pattern");
				z0zek.z0eek("id", z0ZzZzdsh2.z0tek);
				z0zek.z0eek("x", "0");
				z0zek.z0eek("y", "0");
				z0zek.z0eek("width", "0.1");
				z0zek.z0eek("height", "0.1");
				if (z0ZzZzdsh2.z0uek is z0ZzZzrfh z0ZzZzrfh2 && z0ZzZzrfh2.z0eek() != null && z0ZzZzrfh2.z0eek().Length != 0)
				{
					z0zek.z0eek("image");
					z0zek.z0eek("width", z0ZzZzrfh2.z0iek().ToString());
					z0zek.z0eek("height", ((z0ZzZzedh)z0ZzZzrfh2).z0yek().ToString());
					z0zek.z0eek("href", z0ZzZzrfh2.z0yek());
					z0zek.z0bg();
				}
				z0zek.z0bg();
			}
		}
	}

	public override void z0whk()
	{
		z0htk = z0ZzZzbdh.z0xek;
	}

	[CompilerGenerated]
	public string z0nek()
	{
		return z0frk;
	}

	public override void z0qhk(string p0)
	{
		z0hrk = p0;
	}

	public override void z0ahk(z0ZzZzedh p0, float p1, float p2, float p3, float p4, byte[] p5)
	{
		z0uek();
		if (p5 == null || p5.Length == 0)
		{
			if (p0 == null)
			{
				throw new ArgumentNullException("img");
			}
			if (p0 is z0ZzZzrfh)
			{
				p5 = ((z0ZzZzrfh)p0).z0eek();
			}
			else
			{
				MemoryStream memoryStream = new MemoryStream();
				p0.z0hd(memoryStream, z0ZzZzrdh.z0bek);
				p5 = memoryStream.ToArray();
			}
		}
		if (z0zek != null)
		{
			z0ZzZzndh p6 = z0shk(p1, p2, p3, p4);
			if (XTextDocument.z0axk && z0prk != null)
			{
				if (z0ark == null)
				{
					z0ark = new Dictionary<byte[], z0phj>(new z0ZzZzwyk());
				}
				if (!z0ark.ContainsKey(p5))
				{
					string text = null;
					if (z0prk.TryGetValue((DCStdImageKey)p0.z0uek(), out text) && text != null && text.Length > 0)
					{
						z0zek.z0eek("defs");
						z0zek.z0eek("g");
						string text2 = "dcsi" + z0mtk++;
						z0zek.z0rek("id", text2);
						z0phj z0phj = new z0phj();
						z0phj.z0rek = "#" + text2;
						z0phj.z0eek = 0;
						z0phj.z0tek = 0;
						z0ark[p5] = z0phj;
						z0zek.z0og(text);
						z0zek.z0bg();
						z0zek.z0bg();
					}
				}
			}
			if (XTextDocument.z0axk)
			{
				z0phj z0phj2 = null;
				if (z0ark != null && z0ark.TryGetValue(p5, out z0phj2))
				{
					z0zek.z0eek("use");
					z0zek.z0rek("href", z0phj2.z0rek);
					z0zek.z0tek("x", p6.z0pek() - z0phj2.z0eek);
					if (p6.z0mek() != z0phj2.z0tek)
					{
						z0zek.z0tek("y", p6.z0mek() - z0phj2.z0tek);
					}
					z0yek(z0hrk);
					z0zek.z0bg();
					XTextDocument.z0axk = false;
					return;
				}
			}
			z0zek.z0eek("image");
			z0eek(p6);
			if (XTextDocument.z0axk)
			{
				XTextDocument.z0axk = false;
				if (z0ark == null)
				{
					z0ark = new Dictionary<byte[], z0phj>(new z0ZzZzwyk());
				}
				string text3 = "dcsi" + z0mtk++;
				z0zek.z0rek("id", text3);
				z0phj z0phj3 = new z0phj();
				z0phj3.z0rek = "#" + text3;
				z0phj3.z0eek = p6.z0pek();
				z0phj3.z0tek = p6.z0mek();
				z0ark[p5] = z0phj3;
			}
			z0zek.z0rek("href", p5);
			z0zek.z0eek("decoding", "sync");
			if (p0 != null)
			{
				float num = (float)p0.z0iek() / (float)p0.z0yek();
				float num2 = p3 / p4;
				if ((double)Math.Abs(num - num2) > 0.01)
				{
					z0zek.z0eek("preserveAspectRatio", "none");
				}
			}
			z0yek(z0hrk);
			z0zek.z0bg();
		}
		else
		{
			z0ZzZzbdh p7 = z0eek(p1, p2, p3, p4);
			z0srk.z0eek("ImageObject");
			z0srk.z0uek();
			z0srk.z0rek("CTM", z0tek(p3) + " 0 0 " + z0tek(p4) + " 0 0");
			z0srk.z0eek(p7);
			int p8 = z0eek(p5);
			z0srk.z0eek("ResourceID", p8);
			z0srk.z0eek();
		}
	}

	public override z0ZzZzndh z0shk(float p0, float p1, float p2, float p3)
	{
		z0ZzZzpdh z0ZzZzpdh2 = z0yek(p0, p1);
		int num = (int)Math.Round(z0ZzZzpdh2.z0rek());
		int num2 = (int)Math.Round(z0ZzZzpdh2.z0tek());
		int num3 = (int)Math.Round(z0ZzZzpdh2.z0rek() + p2 * z0xrk);
		int num4 = (int)Math.Round(z0ZzZzpdh2.z0tek() + p3 * z0xrk);
		return new z0ZzZzndh(num, num2, num3 - num, num4 - num2);
	}

	public override void z0dhk(float p0, float p1)
	{
		z0krk.z0tek_jiejie20260327142557();
		z0krk.z0eek(p0, p1);
		z0rtk = null;
	}

	[CompilerGenerated]
	public string z0bek()
	{
		return z0gtk;
	}
}
