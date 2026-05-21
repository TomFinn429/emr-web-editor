using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Printing;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("<{DocInstanceIndex}>Document:{Title}")]
public sealed class XTextDocument : XTextContainerElement, z0ZzZzjrj
{
	private enum z0fmk
	{
		z0eek,
		z0rek,
		z0tek
	}

	private class z0vjj
	{
		public XTextElement z0eek;

		public XTextContentElement.z0lgj z0rek;

		public bool z0tek;
	}

	public delegate string z0mmk(string codeForThread, string code);

	internal class z0ipk
	{
		public bool z0eek;

		public Color z0rek = Color.Empty;

		public Color z0tek = Color.Empty;

		public bool z0yek;
	}

	internal class z0tok
	{
		private z0ZzZzuhh z0rek;

		private DocumentContentStyleContainer z0tek;

		private z0ZzZzwcj z0yek;

		private List<XTextElement>[] z0uek;

		public void z0eek(XTextDocument p0)
		{
			p0.z0obk = z0rek;
			p0.z0nzk = z0tek;
			p0.z0gck = z0yek;
			for (int num = z0uek.Length - 1; num >= 0; num--)
			{
				List<XTextElement> list = z0uek[num];
				if (list != null && list.Count > 0)
				{
					foreach (XTextElement item in list)
					{
						item.z0buk = num;
						item.z0ytk();
					}
					list.Clear();
				}
			}
			Array.Clear(z0uek);
			z0uek = null;
			z0rek = null;
			z0yek = null;
			z0tek = null;
		}

		private void z0eek(XTextContainerElement p0)
		{
			int num = p0.z0xek();
			if (num <= 0)
			{
				return;
			}
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0krk();
			for (int i = 0; i < num; i++)
			{
				XTextElement xTextElement = array[i];
				int z0buk = xTextElement.z0buk;
				if (z0buk >= 0 && z0buk < z0uek.Length)
				{
					z0uek[z0buk].Add(xTextElement);
				}
				if (xTextElement is XTextContainerElement)
				{
					z0eek((XTextContainerElement)xTextElement);
				}
			}
		}

		public z0tok(XTextDocument p0)
		{
			if (p0.z0nzk == null)
			{
				throw new NullReferenceException("doc._ContentStyles");
			}
			z0rek = p0.z0obk?.z0uek();
			z0tek = (DocumentContentStyleContainer)((z0ZzZzxok)p0.z0nzk).z0eek();
			z0yek = p0.z0gck?.z0uek();
			z0uek = new List<XTextElement>[z0tek.Styles.Count];
			for (int i = 0; i < z0uek.Length; i++)
			{
				z0uek[i] = new List<XTextElement>();
			}
			z0eek((XTextContainerElement)p0);
		}
	}

	[CompilerGenerated]
	private static class z0zik
	{
		public static Action<XTextContentElement, z0vjj> z0eek;
	}

	[CompilerGenerated]
	private new sealed class z0nyk
	{
		public static Action<XTextElement[]> z0rek;

		public static readonly z0nyk z0tek = new z0nyk();

		public static Action<XTextLabelElement> z0yek;

		public static z0ZzZzjcj z0uek;

		public static Action<XTextContentElement, bool> z0iek;

		internal int z0eek(object p0, object p1)
		{
			XTextElement xTextElement = (XTextElement)p0;
			XTextElement xTextElement2 = (XTextElement)p1;
			if (xTextElement.GetType() == xTextElement2.GetType() && xTextElement.z0pek() == xTextElement2.z0pek())
			{
				return 0;
			}
			return 1;
		}

		internal void z0eek(XTextElement[] p0)
		{
			Array.Clear(p0, 0, p0.Length);
		}

		internal void z0eek(XTextContentElement p0, bool p1)
		{
			p0.z0rrk();
		}

		internal void z0eek(XTextLabelElement p0)
		{
			if (p0.z0eek())
			{
				p0.z0jo();
			}
		}
	}

	[NonSerialized]
	internal bool z0vnk;

	private static readonly string z0cnk = typeof(XTextDocument).Assembly.GetName().Version.ToString();

	[NonSerialized]
	public z0ZzZzqkh EventElementValidating;

	[NonSerialized]
	private z0ZzZzerj z0xnk;

	[NonSerialized]
	private bool z0znk;

	[NonSerialized]
	[z0ZzZzuqh]
	public z0ZzZzdrj z0lbk;

	[NonSerialized]
	public EventHandler DocumentLoad;

	[NonSerialized]
	private z0ZzZzhkh z0kbk;

	internal bool z0jbk = true;

	[ThreadStatic]
	private static bool z0hbk = false;

	[NonSerialized]
	internal bool z0gbk;

	private static float z0fbk = 12f;

	[NonSerialized]
	internal bool z0dbk;

	[NonSerialized]
	private z0ZzZzhzj z0sbk;

	[NonSerialized]
	private z0ZzZzerj z0abk;

	[NonSerialized]
	[z0ZzZzuqh]
	public Dictionary<XTextElement, z0ZzZzpdh[]> z0qbk;

	internal static bool z0wbk = false;

	internal static string z0ebk = null;

	private bool z0rbk;

	private static readonly Type z0tbk = typeof(z0ZzZzvcj);

	[NonSerialized]
	private DocumentViewOptions z0ybk;

	[NonSerialized]
	internal z0ZzZzpkh z0ubk;

	[NonSerialized]
	private z0ZzZzmpj z0ibk;

	private z0ZzZzuhh z0obk;

	internal static bool z0pbk = false;

	private string z0mbk;

	[NonSerialized]
	private int z0nbk;

	[NonSerialized]
	internal Dictionary<string, XTextElement> z0bbk;

	[NonSerialized]
	internal z0ZzZzdcj z0vbk;

	[NonSerialized]
	internal Dictionary<XTextCharElement, z0ipk> z0cbk;

	[NonSerialized]
	private z0ZzZzdbj z0xbk_jiejie20260327142557;

	private DocumentInfo z0zbk;

	[NonSerialized]
	private int z0lvk;

	private string z0kvk;

	internal bool z0jvk;

	private int z0hvk;

	[NonSerialized]
	private z0ZzZzzcj z0gvk;

	[NonSerialized]
	public z0ZzZzyzj SelectionChanging;

	internal bool z0fvk;

	internal int z0dvk = -1;

	[NonSerialized]
	internal bool z0svk = true;

	[NonSerialized]
	private object z0avk;

	[NonSerialized]
	internal DocumentOptions z0qvk;

	[NonSerialized]
	internal List<XTextCharElement> z0wvk;

	private XPageSettings z0evk = new XPageSettings();

	private static z0ZzZzhvj z0rvk = null;

	[NonSerialized]
	[z0ZzZzuqh]
	public z0ZzZzdrj z0tvk;

	[NonSerialized]
	private z0ZzZzbdh z0yvk = z0ZzZzbdh.z0xek;

	[NonSerialized]
	private z0ZzZzvlh z0uvk;

	[NonSerialized]
	private List<byte[]> z0ivk;

	[NonSerialized]
	internal XTextElement z0ovk;

	internal static byte[] z0pvk = null;

	private MeasureMode z0mvk;

	[NonSerialized]
	private z0ZzZzwrj z0nvk;

	[NonSerialized]
	private z0ZzZzpxj z0bvk;

	[NonSerialized]
	private int z0vvk;

	private float z0cvk;

	internal static int z0xvk = 0;

	private static readonly string z0zvk = "xml";

	[NonSerialized]
	private z0ZzZzmxj z0lck;

	[NonSerialized]
	private bool z0kck;

	[NonSerialized]
	private z0ZzZzkcj z0jck;

	[NonSerialized]
	private DocumentBehaviorOptions z0hck;

	internal z0ZzZzwcj z0gck;

	[NonSerialized]
	private object z0fck;

	[NonSerialized]
	private z0ZzZznzj z0dck;

	internal bool z0sck;

	[NonSerialized]
	internal z0ZzZzxdh z0ack = z0ZzZzxdh.z0yek;

	[NonSerialized]
	private XTextElementList z0qck;

	internal bool z0wck;

	internal Dictionary<XTextElement, int> z0eck;

	[NonSerialized]
	private int z0rck = -1;

	internal static int z0tck = 0;

	[NonSerialized]
	private DateTime z0yck = z0ZzZzuyk.z0eek();

	[NonSerialized]
	public EventHandler DocumentContentChanged;

	private int z0uck;

	private static int z0ick = 0;

	internal static Action<XTextDocument> z0ock = null;

	[NonSerialized]
	private DocumentOptions z0pck;

	[NonSerialized]
	private object z0mck_jiejie20260327142557;

	[NonSerialized]
	private Dictionary<XTextTableRowElement, float> z0nck;

	private string z0bck;

	[NonSerialized]
	private DocumentSecurityOptions z0vck;

	[NonSerialized]
	private XTextElementList z0cck;

	[NonSerialized]
	internal XTextContainerElement z0xck;

	[NonSerialized]
	private int z0zck = -1;

	private float z0lxk;

	[NonSerialized]
	internal bool z0kxk;

	[NonSerialized]
	internal static float z0jxk = 0f;

	internal Action<z0ZzZzezj> z0hxk;

	[NonSerialized]
	private DocumentContentSourceTypes z0gxk = DocumentContentSourceTypes.None;

	internal static string z0fxk = null;

	[NonSerialized]
	private z0ZzZzlfh z0dxk;

	public EventHandler SelectionChanged;

	[NonSerialized]
	private z0ZzZzohh z0sxk;

	internal static bool z0axk = false;

	[NonSerialized]
	internal z0ZzZzzej z0qxk;

	[NonSerialized]
	[z0ZzZzuqh]
	public bool[] z0wxk;

	[NonSerialized]
	private XTextDocumentContentElement z0exk;

	internal static int z0rxk = 0;

	[NonSerialized]
	private z0ZzZzgcj z0txk;

	internal static bool z0yxk = false;

	private string z0uxk;

	[NonSerialized]
	private int z0ixk = z0flj++;

	[NonSerialized]
	private z0ZzZzlvj z0oxk;

	[NonSerialized]
	private List<XTextContentElement> z0pxk;

	[NonSerialized]
	private z0ZzZzkvj z0mxk;

	[NonSerialized]
	private bool z0nxk;

	[ThreadStatic]
	private static z0ZzZzadh z0bxk = null;

	[NonSerialized]
	private float z0vxk;

	[NonSerialized]
	internal bool z0cxk;

	[NonSerialized]
	private z0ZzZzvej z0xxk;

	[NonSerialized]
	public z0ZzZzpcj z0zxk;

	private z0ZzZzkvj z0lzk;

	internal XTextElementList z0kzk;

	[NonSerialized]
	internal bool z0jzk;

	private string z0hzk;

	[NonSerialized]
	public static z0mmk z0gzk = null;

	[NonSerialized]
	private z0ZzZzpjh z0fzk;

	internal static z0ZzZzxlh z0dzk = null;

	[ThreadStatic]
	internal static bool z0szk = false;

	[NonSerialized]
	internal z0ZzZzwcj z0azk = new z0ZzZzwcj();

	internal bool z0qzk = true;

	private RepeatedImageValueList z0wzk;

	[NonSerialized]
	private int z0ezk;

	private static readonly string z0rzk = "pdf";

	private bool z0tzk = true;

	[NonSerialized]
	private bool z0yzk;

	[NonSerialized]
	private XTextElement z0uzk;

	[NonSerialized]
	private z0ZzZzyxj z0izk;

	private string z0ozk;

	[NonSerialized]
	private PageViewMode z0pzk;

	internal bool z0mzk;

	internal DocumentContentStyleContainer z0nzk;

	[NonSerialized]
	private int z0bzk = -2147483648;

	[NonSerialized]
	private MemoryStream z0vzk;

	[NonSerialized]
	private XTextElement z0czk;

	[NonSerialized]
	private bool z0xzk;

	[NonSerialized]
	private z0ZzZzyrj z0zzk;

	[ThreadStatic]
	public static bool z0llj = false;

	[NonSerialized]
	private z0ZzZzczj z0klj;

	[NonSerialized]
	private DocumentEditOptions z0jlj;

	[NonSerialized]
	internal int z0hlj;

	[NonSerialized]
	private z0ZzZzygh z0glj;

	private static int z0flj = 0;

	[NonSerialized]
	internal z0ZzZzmcj z0dlj = new z0ZzZzmcj();

	private static readonly Type z0slj = typeof(z0ZzZzxcj);

	[NonSerialized]
	private float[] z0alj;

	[NonSerialized]
	private float z0qlj;

	public XPageSettings PageSettings
	{
		get
		{
			if (z0evk == null)
			{
				z0evk = new XPageSettings();
				z0krk(p0: false);
			}
			return z0evk;
		}
		set
		{
			z0evk = value;
			if (z0evk == null)
			{
				z0evk = new XPageSettings();
			}
			z0krk(p0: false);
		}
	}

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			DCDocumentTextOutputMode documentTextOutputMode = z0vtk().BehaviorOptions.DocumentTextOutputMode;
			if (documentTextOutputMode == DCDocumentTextOutputMode.Normal)
			{
				return z0xyk().z0trk().z0hrk();
			}
			StringBuilder stringBuilder = new StringBuilder();
			if ((documentTextOutputMode & DCDocumentTextOutputMode.IncludeHeader) == DCDocumentTextOutputMode.IncludeHeader && z0pyk().z0fi())
			{
				z0bek(z0pyk(), stringBuilder, documentTextOutputMode);
			}
			z0bek(z0xyk(), stringBuilder, documentTextOutputMode);
			if ((documentTextOutputMode & DCDocumentTextOutputMode.IncludeFooter) == DCDocumentTextOutputMode.IncludeFooter && z0lik().z0fi())
			{
				z0bek(z0lik(), stringBuilder, documentTextOutputMode);
			}
			return stringBuilder.ToString();
		}
		set
		{
			z0rpk();
			XTextElementList xTextElementList = z0bek(value, (DocumentContentStyle)null, (DocumentContentStyle)null);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				z0duk();
				z0xyk().z0be().Clear();
				((zzz.z0ZzZzkuk<XTextElement>)z0xyk().z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList);
				z0xyk().z0bek(p0: true);
			}
		}
	}

	[DefaultValue(null)]
	[z0ZzZzrqh("Comment", typeof(DocumentComment))]
	public z0ZzZzwcj Comments
	{
		get
		{
			if (z0gck == null)
			{
				z0gck = new z0ZzZzwcj();
			}
			return z0gck;
		}
		set
		{
			z0gck = value;
		}
	}

	internal new void z0bek()
	{
		if (z0itk() != null)
		{
			DocumentEventArgs e = new DocumentEventArgs(z0jr(), z0itk(), DocumentEventStyles.ControlGotFoucs);
			e.Cursor = null;
			z0bek(z0itk(), e);
		}
	}

	public new static bool z0vek()
	{
		return (z0tck & 8) == 8;
	}

	public void z0bek(z0ZzZzjpk p0, bool p1 = false)
	{
		z0nik();
		if (z0xu())
		{
			return;
		}
		z0bik();
		z0vek(p0);
		Width = PageSettings.z0drk();
		p0.z0eek(GraphicsUnit.Document);
		p0.z0eek((z0ZzZzfsh)4);
		z0ZzZzcxj p2 = (z0ZzZzcxj)0;
		if (z0qtk().Printing)
		{
			p2 = (z0ZzZzcxj)3;
		}
		z0ZzZzvxj z0ZzZzvxj = z0bek(p0, p2);
		z0gnk().z0eek(z0ZzZzvxj.z0gyk);
		if (p1)
		{
			z0ZzZzvxj.z0eek(p0: true);
		}
		else
		{
			z0zok().z0vek();
		}
		z0zok().z0eek(p0);
		float width = PageSettings.z0prk();
		foreach (XTextElement item in z0be().z0xrk())
		{
			item.Width = width;
		}
		z0mr(z0ZzZzvxj);
		z0krk(p0: false);
		if (!p1)
		{
			z0zok().z0vek();
		}
		z0aok();
	}

	public void z0bek(object p0, z0ZzZzwrj p1, bool p2, float p3, DocumentRenderMode p4, bool p5, z0ZzZzqbj.z0bnk p6)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("g");
		}
		if (!(p0 is z0ZzZzadh) && !(p0 is z0ZzZzjpk))
		{
			throw new NotSupportedException(p0.ToString());
		}
		z0ZzZzocj z0ZzZzocj = new z0ZzZzocj();
		if (p6 != null)
		{
			z0ZzZzocj.z0tek = p6.z0ylk();
		}
		if (p6 != null)
		{
			z0ZzZzocj.z0eek(p6.z0zlk());
		}
		z0ZzZzocj.z0eek(this);
		z0ZzZzocj.z0rek(p5);
		z0ZzZzocj.z0eek(p5);
		z0ZzZzocj.z0rek(Color.Transparent);
		z0ZzZzxpk z0ZzZzxpk = (z0ZzZzxpk)z0ZzZzxcj.z0eek(p0: false, p1.z0brk());
		if (!z0ZzZzxpk.z0yek)
		{
			z0ZzZzocj.z0eek(z0ZzZzxpk);
		}
		else
		{
			z0ZzZzocj.z0eek((z0ZzZzxpk)null);
		}
		z0ZzZzocj.z0eek(z0suk());
		switch (p4)
		{
		case DocumentRenderMode.PDF:
			z0ZzZzocj.z0eek((z0ZzZzxej)4);
			break;
		case DocumentRenderMode.Bitmap:
			z0ZzZzocj.z0eek((z0ZzZzxej)3);
			break;
		case DocumentRenderMode.Print:
			z0ZzZzocj.z0eek((z0ZzZzxej)1);
			break;
		default:
			z0ZzZzocj.z0eek((z0ZzZzxej)0);
			break;
		}
		z0ZzZzocj.z0eek(z0iu().PageMarginLineLength);
		z0ZzZzocj.z0rek(p3);
		z0ZzZzocj.z0eek(p3);
		if (p0 is z0ZzZzadh)
		{
			z0ZzZzocj.z0eek(p1, new z0ZzZzjpk((z0ZzZzadh)p0), p2);
		}
		else if (p0 is z0ZzZzjpk)
		{
			z0ZzZzocj.z0eek(p1, (z0ZzZzjpk)p0, p2);
		}
	}

	private void z0bek(object p0, EventArgs p1)
	{
		XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)((z0ZzZzezj)p1).z0drk();
		DocumentContentStyle documentContentStyle = xTextParagraphFlagElement.z0aek().z0yek();
		documentContentStyle.ParagraphOutlineLevel = -1;
		documentContentStyle.ParagraphMultiLevel = false;
		documentContentStyle.ParagraphListStyle = ParagraphListStyle.None;
		documentContentStyle.Font = z0dik().Font;
		documentContentStyle.LeftIndent = 0f;
		documentContentStyle.FirstLineIndent = 0f;
		documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
		documentContentStyle.LineSpacing = 1f;
		int styleIndex = z0gnk().GetStyleIndex(documentContentStyle);
		if (z0uik())
		{
			z0imk().z0eek(xTextParagraphFlagElement, ((XTextElement)xTextParagraphFlagElement).z0pek(), styleIndex);
		}
		xTextParagraphFlagElement.z0oek(styleIndex);
		xTextParagraphFlagElement.z0xi(p0: true);
		xTextParagraphFlagElement.z0hrk(p0: true);
		z0drk(p0: false);
	}

	public bool z0bek(XTextElement p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (!z0bu().EnableExpression)
		{
			return false;
		}
		for (XTextElement xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement.z0aek().z0jyk >= 0)
			{
				return false;
			}
			if (!xTextElement.z0yi())
			{
				return false;
			}
		}
		return true;
	}

	internal new void z0bek(bool p0)
	{
		z0tzk = p0;
	}

	public string z0bek(string p0)
	{
		return z0ki(p0)?.z0ztk();
	}

	public string z0bek(string p0, int p1, int p2)
	{
		return z0vek(p0, p1, p2)?.Text;
	}

	public void z0bek(z0ZzZzcah p0, string p1)
	{
		try
		{
			z0pok();
			z0bek(null, p0, p1, p3: false, XTextDocument.z0fmk.z0eek, null);
			z0ZzZzafh.z0uek("LoadFromXmlReader");
		}
		finally
		{
			z0smk();
		}
	}

	private void z0bek(XTextElement p0, DocumentEventArgs p1)
	{
		if (!z0xrk())
		{
			XTextElementList xTextElementList = new XTextElementList();
			XTextElement xTextElement = p0;
			while (xTextElement != null && xTextElement != this)
			{
				xTextElementList.Add(xTextElement);
				xTextElement = xTextElement.z0ji();
			}
			z0bek(xTextElementList, p1);
			if ((p1.Style == DocumentEventStyles.MouseDown || p1.Style == DocumentEventStyles.MouseMove || p1.Style == DocumentEventStyles.MouseUp || p1.Style == DocumentEventStyles.MouseClick || p1.Style == DocumentEventStyles.MouseDblClick || p1.Style == DocumentEventStyles.MouseEnter) && p1.Cursor == null)
			{
				p1.Cursor = p0.z0hrk();
			}
		}
	}

	public new void z0vek(bool p0)
	{
		if (z0yyk() != null)
		{
			z0wck = ((z0ZzZzqrj)base.z0uyk()).z0hrk();
		}
		z0yzk = false;
		z0nik();
		z0ZzZzdbj z0ZzZzdbj = z0yyk();
		z0ZzZzmcj z0ZzZzmcj = null;
		if (z0ZzZzdbj != null && z0ZzZzdbj.z0ryk())
		{
			z0ZzZzmcj = z0dlj;
			z0dlj = new z0ZzZzmcj();
			z0dlj.RenderMode = DocumentRenderMode.ReadPaint;
			z0dlj.Printing = true;
		}
		z0bek((z0ZzZzdbj)null);
		try
		{
			if (p0)
			{
				z0bek(p0: true, p1: false);
			}
			else
			{
				z0bek(p0: false, p1: true);
			}
			z0ZzZzwcj z0ZzZzwcj = z0gik();
			if (z0ZzZzwcj != null && z0ZzZzwcj.Count > 0)
			{
				foreach (DocumentComment item in z0ZzZzwcj)
				{
					item.z0oek(-1f);
					item.z0rek(-1f);
				}
			}
			using (z0ZzZzjpk p1 = z0ru())
			{
				z0bek(p1, p0);
				z0ct();
				z0zek(p0);
				z0bek(z0ZzZzdbj);
				z0ZzZzdbj?.z0tik()?.z0tb(p1, z0ZzZzdbj?.z0ypk());
			}
			z0bek((z0ZzZzzcj)3);
		}
		finally
		{
			if (z0ZzZzmcj != null)
			{
				z0dlj = z0ZzZzmcj;
			}
			z0bek(z0ZzZzdbj);
		}
	}

	public new z0ZzZzgcj z0cek()
	{
		if (z0txk == null)
		{
			z0txk = new z0ZzZzgcj();
		}
		return z0txk;
	}

	public void z0vek(string p0)
	{
		if (p0 == null || p0.IndexOf('<') < 0 || p0.IndexOf('>') < 0)
		{
			Text = p0;
			return;
		}
		StringReader p1 = new StringReader(p0);
		z0bek(p1, z0ZzZzkfh.z0ltk);
	}

	public void z0bek(TextWriter p0, string p1)
	{
		z0bek(p0, p1, p2: false, null);
	}

	public DocumentEventArgs createEvent(string type)
	{
		DocumentEventStyles style = DocumentEventStyles.MouseClick;
		if (type != null && type.Length > 0)
		{
			style = (DocumentEventStyles)Enum.Parse(typeof(DocumentEventStyles), type, true);
		}
		return new DocumentEventArgs(this, this, style);
	}

	public new void z0cek(string p0)
	{
		z0hzk = p0;
	}

	internal bool z0bek(XTextContainerElement p0)
	{
		if (XTextSectionElement.z0krk && XTextSectionElement.z0mek)
		{
			return false;
		}
		if (z0xck != null)
		{
			for (XTextContainerElement xTextContainerElement = z0xck; xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
			{
				if (xTextContainerElement == p0)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public z0ZzZzkkh z0bek(XTextElement p0, z0ZzZzjcj p1)
	{
		z0ZzZzplh z0ZzZzplh = p0.z0qek().z0frk();
		int num = z0ZzZzplh.IndexOf(p0);
		int num2 = num;
		int num3 = num;
		int num4 = num;
		while (num4 > 0 && p1(p0, z0ZzZzplh[num4]) == 0)
		{
			num2 = num4;
			num4--;
		}
		for (int i = num; i < z0ZzZzplh.Count && p1(p0, z0ZzZzplh[i]) == 0; i++)
		{
			num3 = i;
		}
		return new z0ZzZzkkh(z0jrk(), num2, num3 - num2 + 1);
	}

	public override void z0gi(ContentChangingEventArgs p0)
	{
		base.z0gi(p0);
		p0.Element = this;
		if (z0yyk() != null && !z0snk())
		{
			z0yyk().z0eek(p0);
		}
	}

	public new z0ZzZzpxj z0xek()
	{
		z0ZzZzpxj z0ZzZzpxj = null;
		if (z0yyk() != null)
		{
			z0ZzZzpxj = z0yyk().z0erk();
			if (z0ZzZzpxj != null)
			{
				return z0ZzZzpxj;
			}
		}
		if (z0bvk == null)
		{
			z0bvk = z0ZzZzuok.z0eek<z0ZzZzpxj>();
		}
		if (z0bvk == null)
		{
			return null;
		}
		z0bvk.z0yn(this);
		return z0bvk;
	}

	public new XTextElementList z0zek()
	{
		return z0qck;
	}

	public new object z0lrk()
	{
		return z0avk;
	}

	public new void z0krk()
	{
		z0zek(p0: false);
	}

	public bool z0vek(XTextElement p0)
	{
		return p0.z0qek().z0rek(p0);
	}

	public DocumentContentStyle CreateDocumentContentStyle()
	{
		return new DocumentContentStyle();
	}

	public new XTextDocumentContentElement z0jrk()
	{
		if (z0exk == null)
		{
			z0exk = z0xyk();
		}
		return z0exk;
	}

	public new static void z0hrk()
	{
		for (int i = 0; i < 100; i++)
		{
			z0ZzZzxcj.z0eek(p0: false, -1);
		}
	}

	public new void z0xek(string p0)
	{
		if (z0ipk() == null)
		{
			z0bek(new DocumentInfo());
		}
		z0ipk().z0vek(p0);
	}

	public override void Dispose()
	{
		try
		{
			z0nxk = true;
			base.Dispose();
			z0cik();
			if (z0wvk != null)
			{
				z0wvk.Clear();
				z0wvk = null;
			}
			if (z0evk != null)
			{
				z0evk.Dispose();
				z0evk = null;
			}
			if (z0wzk != null)
			{
				RepeatedImageValueList repeatedImageValueList = z0wzk;
				z0wzk = null;
				repeatedImageValueList.Dispose();
			}
			if (z0dck != null)
			{
				z0dck.z0rek();
				z0dck = null;
			}
			if (z0abk != null)
			{
				foreach (z0ZzZzwrj item in z0abk)
				{
					item.z0rek();
				}
				z0abk.Clear();
				z0abk = null;
			}
			if (z0nzk != null)
			{
				z0nzk.Dispose();
				z0nzk = null;
			}
			if (base.z0ntk != null)
			{
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = base.z0ntk.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						z0bpk.Current.Dispose();
					}
				}
				base.z0ntk.Clear();
				base.z0ntk = null;
			}
			if (z0izk != null)
			{
				z0izk.Dispose();
				z0izk = null;
			}
			if (z0ubk != null)
			{
				z0ubk.Dispose();
				z0ubk = null;
			}
			if (z0lck != null)
			{
				z0lck.Dispose();
				z0lck = null;
			}
			if (z0fzk != null)
			{
				z0fzk.Dispose();
				z0fzk = null;
			}
			if (z0klj != null)
			{
				z0klj.Dispose();
				z0klj = null;
			}
			if (z0obk != null)
			{
				foreach (z0ZzZzyhh item2 in z0obk)
				{
					item2.Dispose();
				}
				z0obk.Clear();
				z0obk = null;
			}
			if (z0ibk != null)
			{
				z0ibk.Dispose();
				z0ibk = null;
			}
			if (z0bbk != null)
			{
				z0bbk.Clear();
				z0bbk = null;
			}
			z0dxk = null;
			z0mbk = null;
			if (z0xxk != null)
			{
				z0xxk = null;
			}
			z0hck = null;
			z0jlj = null;
			z0pck = null;
			z0vck = null;
			z0ybk = null;
			if (z0jck != null)
			{
				z0jck.z0uek();
				z0jck = null;
			}
			if (z0gck != null)
			{
				z0gck.Dispose();
				z0gck = null;
			}
			if (z0azk != null)
			{
				z0azk.Dispose();
				z0azk = null;
			}
			z0exk = null;
			z0nvk = null;
			if (z0vbk != null)
			{
				z0vbk.z0yek();
				z0vbk = null;
			}
			if (z0cbk != null)
			{
				z0cbk.Clear();
				z0cbk = null;
			}
			z0xck = null;
			z0uzk = null;
			if (z0nck != null)
			{
				z0nck.Clear();
				z0nck = null;
			}
			z0sxk = null;
			z0avk = null;
			z0alj = null;
			z0ovk = null;
			z0duk();
			z0dlj = null;
			if (z0uvk != null)
			{
				z0uvk.Dispose();
				z0uvk = null;
			}
			z0lnk();
			z0qvk = null;
			z0dxk = null;
			z0jck = null;
			z0gck = null;
			z0txk = null;
			z0nzk = null;
			z0xbk_jiejie20260327142557 = null;
			z0ibk = null;
			z0xbk_jiejie20260327142557 = null;
			z0sbk = null;
			z0lck = null;
			if (z0izk != null)
			{
				z0izk.Dispose();
				z0izk = null;
			}
			z0exk = null;
			z0nvk = null;
			z0vbk = null;
			z0bvk = null;
			z0ubk = null;
			z0hzk = null;
			z0xnk = null;
			z0czk = null;
			z0zbk = null;
			z0mck_jiejie20260327142557 = null;
			z0mxk = null;
			z0glj = null;
			z0qbk = null;
			z0cck = null;
			z0qck = null;
			z0zzk = null;
			z0oxk = null;
			z0vzk = null;
			z0qvk = null;
			z0abk = null;
			z0evk = null;
			z0lzk = null;
			z0wzk = null;
			z0sxk = null;
			z0avk = null;
			z0alj = null;
			z0ovk = null;
			z0dlj = null;
			z0fzk = null;
			z0klj = null;
			z0obk = null;
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh("Document.Dispose:" + ex.ToString());
		}
	}

	internal float z0bek(XTextElement p0, bool p1)
	{
		float num = 0f;
		if (p0 is XTextTableCellElement || p0 is XTextTableRowElement || p0 is XTextTableElement || p0 is XTextSectionElement)
		{
			if (p1)
			{
				return p0.z0ltk();
			}
			return p0.z0ltk() + p0.Height + 1f;
		}
		XTextElement xTextElement = (p1 ? p0.z0ie() : p0.z0dek());
		if (p0 is XTextParagraphFlagElement)
		{
			xTextElement = p0;
		}
		z0ZzZzzlh z0ZzZzzlh = xTextElement.z0ptk();
		if (z0ZzZzzlh == null)
		{
			if (p1)
			{
				return xTextElement.z0ltk();
			}
			return xTextElement.z0ltk() + xTextElement.Height + 1f;
		}
		if (p1)
		{
			return z0ZzZzzlh.z0xrk();
		}
		return z0ZzZzzlh.z0xrk() + z0ZzZzzlh.z0ytk() + 1f;
	}

	public new string z0zek(string p0)
	{
		if (z0ki(p0) is XTextInputFieldElement xTextInputFieldElement)
		{
			return xTextInputFieldElement.InnerValue;
		}
		return null;
	}

	public override DocumentSecurityOptions z0hi()
	{
		if (z0vck == null)
		{
			return z0vtk().SecurityOptions;
		}
		return z0vck;
	}

	public override XTextContainerElement z0ji()
	{
		return null;
	}

	public new bool z0grk()
	{
		if (z0cuk().z0qrk() == 0)
		{
			XTextElement xTextElement = z0itk();
			if (xTextElement == null)
			{
				return false;
			}
			XTextTableCellElement xTextTableCellElement = xTextElement.z0brk();
			if (xTextTableCellElement != null && xTextTableCellElement.z0trk().IndexOf(xTextElement) == 0 && xTextTableCellElement.z0pek() == 0 && xTextTableCellElement.z0xek() == 0)
			{
				XTextTableElement xTextTableElement = xTextTableCellElement.z0gr();
				XTextContentElement xTextContentElement = xTextTableElement.z0jy();
				int num = xTextContentElement.z0trk().IndexOf(xTextTableElement);
				if (num == 0)
				{
					return true;
				}
				if (num > 0 && xTextContentElement.z0trk()[num - 1] is XTextFieldBorderElement && ((XTextFieldBorderElement)xTextContentElement.z0trk()[num - 1]).z0mek() == (z0ZzZzzvj)0)
				{
					return true;
				}
				XTextElement xTextElement2 = xTextContentElement.z0trk().z0pek(xTextTableElement);
				if (xTextElement2 is XTextTableElement || xTextElement2 is XTextTableElement)
				{
					return true;
				}
			}
		}
		return false;
	}

	public void z0bek(z0ZzZzzcj p0)
	{
		z0gvk = p0;
	}

	public new bool z0frk()
	{
		return z0kck;
	}

	internal new z0ZzZzhzj z0drk()
	{
		return z0sbk;
	}

	public new static string z0srk()
	{
		return z0cnk;
	}

	public void z0bek(DocumentContentStyle p0)
	{
		z0gnk().Default = p0;
	}

	internal override IList<XTextElement> z0xe()
	{
		return base.z0ntk;
	}

	internal XTextElementList z0eek(Dictionary<XTextElement, int> p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("newStyleIndexs");
		}
		z0ZzZzslh z0ZzZzslh = null;
		if (p1)
		{
			z0ZzZzslh = new z0ZzZzslh();
			z0ZzZzslh.z0eek(this);
			z0ZzZzslh.z0rek(p0: true);
		}
		z0gnk().Styles.z0eek(p0: false);
		List<z0ZzZzzlh> list = new List<z0ZzZzzlh>();
		Dictionary<XTextContentElement, XTextElementList> dictionary = new Dictionary<XTextContentElement, XTextElementList>();
		XTextElementList xTextElementList = new XTextElementList();
		XTextElementList xTextElementList2 = new XTextElementList();
		foreach (XTextParagraphFlagElement key in p0.Keys)
		{
			if (!z0xek().z0np(key))
			{
				continue;
			}
			XTextContentElement xTextContentElement = key.z0jy();
			z0ZzZzslh?.z0eek(key, ((XTextElement)key).z0pek(), p0[key]);
			key.z0oek(p0[key]);
			key.z0rek(p0: false);
			key.z0rrk();
			xTextElementList.Add(key);
			if (!xTextElementList2.Contains(key.z0ji()))
			{
				xTextElementList2.Add(key.z0ji());
			}
			if (!dictionary.ContainsKey(xTextContentElement))
			{
				dictionary[xTextContentElement] = new XTextElementList();
			}
			dictionary[xTextContentElement].Add(key.z0ie());
			dictionary[xTextContentElement].Add(key);
			if (1 == 0)
			{
				continue;
			}
			z0ZzZzzlh z0ZzZzzlh = key.z0ie().z0ptk();
			z0ZzZzzlh z0ZzZzzlh2 = key.z0ptk();
			if (z0ZzZzzlh != null && z0ZzZzzlh2 != null)
			{
				int num = xTextContentElement.z0zek().z0yek(z0ZzZzzlh2);
				for (int i = xTextContentElement.z0zek().z0yek(z0ZzZzzlh); i <= num; i++)
				{
					list.Add(xTextContentElement.z0zek()[i]);
					xTextContentElement.z0zek()[i].z0tek(p0: true);
				}
			}
		}
		if (dictionary.Count > 0)
		{
			if (p1 && z0ytk())
			{
				z0bek(z0ZzZzslh);
				z0nuk();
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					for (XTextContainerElement xTextContainerElement = (XTextContainerElement)z0bpk.Current; xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
					{
						xTextContainerElement.Modified = true;
					}
				}
			}
			Modified = true;
			z0onk().z0eek(this);
			bool flag = false;
			XTextDocumentContentElement xTextDocumentContentElement = null;
			foreach (XTextContentElement key2 in dictionary.Keys)
			{
				if (xTextDocumentContentElement == null)
				{
					xTextDocumentContentElement = key2.z0qek();
					xTextDocumentContentElement.z0rek(p0: false, p1: true);
				}
				key2.z0eek(dictionary[key2], p1: true, p2: false);
				if (key2.z0qek() == z0jrk())
				{
					flag = true;
				}
				ContentChangedEventArgs e = new ContentChangedEventArgs();
				e.Document = this;
				e.Element = key2;
				key2.z0zi(e);
			}
			if (z0yyk() != null)
			{
				z0yyk().z0vik();
			}
			if (flag)
			{
				if (base.z0uyk() != null)
				{
					base.z0uyk().z0hz();
				}
				OnSelectionChanged();
			}
		}
		z0gnk().Styles.z0eek(p0: true);
		return xTextElementList;
	}

	public new static bool z0ark()
	{
		return (z0tck & 0x80) == 128;
	}

	public override XTextElement z0ki(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		if (string.Compare(p0, z0ZzZzkfh.z0vrk, true) == 0)
		{
			return z0pyk();
		}
		if (string.Compare(p0, z0ZzZzkfh.z0urk, true) == 0)
		{
			return z0xyk();
		}
		if (string.Compare(p0, z0ZzZzkfh.z0nrk, true) == 0)
		{
			return z0lik();
		}
		return base.z0ki(p0);
	}

	public void z0bek(z0ZzZzmxj p0)
	{
		z0lck = p0;
	}

	public override void z0li()
	{
		z0we();
		base.z0uik = null;
		z0gbk = false;
		z0lyk();
		if (!z0jbk)
		{
			return;
		}
		z0bik();
		if (base.z0ntk == null)
		{
			base.z0ntk = new XTextElementList(this);
		}
		z0ZzZzcok z0ZzZzcok = z0gnk().Default;
		if (string.IsNullOrEmpty(z0ZzZzcok.FontName))
		{
			z0ZzZzcok.FontName = z0ZzZzimk.DefaultFontName;
		}
		z0fik();
		DocumentContentStyle documentContentStyle = new DocumentContentStyle();
		documentContentStyle.Align = DocumentContentAlignment.Center;
		z0dvk = z0gnk().GetStyleIndex(documentContentStyle);
		foreach (XTextDocumentContentElement item in z0be().z0xrk())
		{
			item.z0yek(this, this);
			item.z0li();
		}
		if (z0gck != null)
		{
			Comments.z0iek();
			foreach (DocumentComment comment in Comments)
			{
				comment.z0tek(this);
			}
		}
		z0gnk().z0eek(this);
		z0aok();
	}

	public new int z0qrk()
	{
		return z0mpk().z0hv(this);
	}

	public XTextCharElement z0bek(char p0, int p1)
	{
		if (p0 == '\n' || p0 == '\r')
		{
			return null;
		}
		if (p0 < ' ' && p0 != '\t')
		{
			return null;
		}
		return new XTextCharElement(p0, this, this, p1);
	}

	public new XTextTableElement z0wrk()
	{
		return (XTextTableElement)z0bek(typeof(XTextTableElement), p1: true);
	}

	public new string z0cek(bool p0)
	{
		z0ZzZzphh z0ZzZzphh = null;
		if (z0xmk() != null)
		{
			z0ZzZzphh = z0ZzZznhh.z0eek().z0eek(z0ZzZzkfh.z0uek);
		}
		if (z0ZzZzphh == null)
		{
			z0ZzZzphh = new z0ZzZzwgh();
		}
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);
		z0ZzZzohh p1 = new z0ZzZzohh
		{
			EnableDocumentSetting = true,
			IncludeSelectionOnly = false,
			Formated = p0
		};
		z0yik();
		XTextDocument xTextDocument = this;
		bool cloneSerialize = z0bu().CloneSerialize;
		if (cloneSerialize)
		{
			xTextDocument = (XTextDocument)z0lr(p0: true);
		}
		z0ZzZzuhh z0ZzZzuhh = xTextDocument.z0obk?.z0uek();
		xTextDocument.z0tu(z0ZzZzkfh.z0uek);
		xTextDocument.z0jrk(p0: true);
		z0ZzZzphh.z0vd(streamWriter, xTextDocument, p1);
		xTextDocument.z0xik();
		xTextDocument.z0bek((z0ZzZzkvj)null);
		if (cloneSerialize)
		{
			xTextDocument.Dispose();
		}
		else
		{
			xTextDocument.z0obk = z0ZzZzuhh;
		}
		streamWriter.Close();
		byte[] array = memoryStream.ToArray();
		return z0ZzZzzik.z0eek(Encoding.UTF8.GetString(array));
	}

	public new void z0xek(bool p0)
	{
		if (z0xu() || z0uzk == null)
		{
			return;
		}
		XTextElement xTextElement = z0uzk;
		z0uzk = null;
		if (xTextElement == this || xTextElement is XTextDocumentContentElement || (xTextElement.z0jy() is XTextDocumentContentElement && !(xTextElement is XTextContentElement)))
		{
			if (z0cu() == null)
			{
				z0vek(p0: false);
			}
			else
			{
				z0cu().z0yrk(p0: false);
			}
			return;
		}
		XTextDocumentContentElement xTextDocumentContentElement = xTextElement.z0qek();
		XTextElement p1 = null;
		XTextElement p2 = null;
		if (p0)
		{
			xTextDocumentContentElement.z0tek(ref p1, ref p2);
		}
		xTextElement.z0oe();
		if (p0)
		{
			bool flag = false;
			if (p1 != null)
			{
				int num = xTextDocumentContentElement.z0frk().z0bek(p1);
				if (num >= 0)
				{
					xTextDocumentContentElement.z0uek(num, 0);
					flag = true;
				}
			}
			if (!flag && p2 != null)
			{
				int num2 = xTextDocumentContentElement.z0frk().z0bek(p2);
				if (num2 >= 0)
				{
					xTextDocumentContentElement.z0uek(num2, 0);
					flag = true;
				}
			}
		}
		z0nbk = 0;
	}

	public new string z0lrk(string p0)
	{
		z0ipk().z0rek(z0jpk());
		StringWriter stringWriter = new StringWriter();
		z0bek(stringWriter, p0, p2: false, null);
		string result = stringWriter.ToString();
		stringWriter.Close();
		return result;
	}

	public override bool z0zu(XTextElement p0)
	{
		return false;
	}

	public bool z0bek(string p0, string p1)
	{
		return z0mpk().z0lv(this, p0, p1);
	}

	public z0ZzZzcdh z0bek(z0ZzZzcdh p0)
	{
		return z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, GraphicsUnit.Pixel);
	}

	public new string z0erk()
	{
		return z0mpk()?.z0fv(this);
	}

	private void z0bek(XTextElementList p0, int[] p1)
	{
		int num = p1.Length;
		for (int num2 = p0.Count - 1; num2 >= 0; num2--)
		{
			XTextElement xTextElement = p0[num2];
			int num3 = xTextElement.z0buk;
			if (num3 >= 0 && num3 < num)
			{
				int num4 = p1[num3];
				if (xTextElement.z0buk != num4)
				{
					if (z0eck != null)
					{
						z0eck[xTextElement] = xTextElement.z0buk;
					}
					xTextElement.z0oek(num4);
				}
				if (xTextElement is XTextFieldElementBase)
				{
					((XTextFieldElementBase)xTextElement).z0cek();
				}
			}
			else if (xTextElement.z0buk != -1)
			{
				if (z0eck != null)
				{
					z0eck[xTextElement] = xTextElement.z0buk;
				}
				xTextElement.z0oek(-1);
			}
			if (xTextElement is XTextContainerElement)
			{
				XTextElementList xTextElementList = ((XTextContainerElement)xTextElement).z0ntk;
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					z0bek(xTextElementList, p1);
				}
			}
		}
	}

	public void z0bek(DocumentContentSourceTypes p0)
	{
		z0gxk = p0;
	}

	public z0ZzZzcdh z0vek(z0ZzZzcdh p0)
	{
		return z0ZzZzrpk.z0eek(p0, GraphicsUnit.Pixel, GraphicsUnit.Document);
	}

	public new void z0rrk()
	{
		z0vek(p0: true, p1: true);
	}

	public new void z0krk(string p0)
	{
		if (p0 == null || p0.IndexOf('{') < 0 || p0.IndexOf('}') < 0)
		{
			Text = p0;
			return;
		}
		StringReader p1 = new StringReader(p0);
		z0bek(p1, z0ZzZzkfh.z0nek);
	}

	public int z0bek(z0ZzZzezj p0)
	{
		z0xck = null;
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (z0hxk != null)
		{
			Action<z0ZzZzezj> action = z0hxk;
			z0hxk = null;
			action(p0);
		}
		if (p0.z0xek() == null)
		{
			throw new ArgumentNullException("container");
		}
		p0.z0eek(0);
		if (p0.z0lrk() == 0 && (p0.z0yek() == null || p0.z0yek().Count == 0))
		{
			return 0;
		}
		if (p0.z0uek() < 0)
		{
			return 0;
		}
		if (p0.z0yek() != null && p0.z0yek().Count > 0)
		{
			p0.z0yek().z0nek(p0: false);
			z0ZzZzafh.z0yek(p0.z0yek(), p1: true, this, p0.z0xek(), p4: true);
		}
		z0qtk().RenderMode = DocumentRenderMode.Paint;
		XTextElement xTextElement = z0itk();
		XTextContentElement xTextContentElement = p0.z0xek().z0jy();
		if (p0.z0xek() is XTextSectionElement)
		{
			xTextContentElement = (XTextSectionElement)p0.z0xek();
		}
		if (xTextContentElement == null)
		{
			throw new ArgumentNullException("ContentElement");
		}
		float num = Environment.TickCount;
		XTextElementList xTextElementList = p0.z0xek().z0be();
		XTextElementList xTextElementList2 = new XTextElementList();
		XTextElementList xTextElementList3 = new XTextElementList();
		if (xTextElementList.Count > 0 && p0.z0uek() >= 0 && p0.z0uek() + p0.z0lrk() <= xTextElementList.Count && p0.z0lrk() > 0)
		{
			for (int i = 0; i < p0.z0lrk(); i++)
			{
				XTextElement xTextElement2 = xTextElementList[i + p0.z0uek()];
				if (!z0xek().z0cm(xTextElement2, p0.z0cek()))
				{
					if (xTextElement2 is XTextParagraphFlagElement && xTextElementList.LastElement == xTextElement2 && p0.z0xek() is XTextContentElement)
					{
						int num2 = p0.z0lrk();
						p0.z0rek(num2 - 1);
					}
					else
					{
						z0ZzZzhcj z0ZzZzhcj = z0xek().z0gn();
						if (z0ZzZzhcj != null)
						{
							if (z0ZzZzhcj.z0rek() == ContentProtectedReason.LogicDeleteAgain)
							{
								xTextElementList3.Add(xTextElementList[i + p0.z0uek()]);
								continue;
							}
							z0cek().Add(z0ZzZzhcj);
							return 0;
						}
					}
				}
				xTextElementList2.Add(xTextElementList[i + p0.z0uek()]);
				xTextElementList3.Add(xTextElementList[i + p0.z0uek()]);
			}
		}
		if (p0.z0yek() != null && p0.z0yek().Count > 0)
		{
			for (int num3 = p0.z0yek().Count - 1; num3 >= 0; num3--)
			{
				XTextElement p1 = p0.z0yek()[num3];
				if (!z0xek().z0fn(p0.z0xek(), p0.z0uek(), p1, p0.z0cek()))
				{
					if (!p0.z0jrk())
					{
						return 0;
					}
					p0.z0yek().RemoveAt(num3);
				}
			}
		}
		if (p0.z0lrk() == 0 && (p0.z0yek() == null || p0.z0yek().Count == 0))
		{
			return 0;
		}
		if (p0.z0xek().z0yrk() > 0)
		{
			int num4 = 0;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0xek().z0be().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					if (z0bpk.Current.z0aek().z0jyk < 0)
					{
						num4++;
					}
				}
			}
			if (p0.z0lrk() > 0)
			{
				num4 -= p0.z0lrk();
			}
			if (p0.z0yek() != null)
			{
				num4 += p0.z0yek().Count;
			}
			if (num4 > p0.z0xek().z0yrk())
			{
				p0.z0eek(0);
				return p0.z0krk();
			}
		}
		if (p0.z0nek())
		{
			p0.z0eek(p0.z0lrk());
			if (p0.z0yek() != null)
			{
				p0.z0eek(p0.z0krk() + p0.z0yek().Count);
			}
			return p0.z0krk();
		}
		int num5 = 0;
		XTextElement xTextElement3 = null;
		if (p0.z0frk() && z0dtk() == (z0ZzZzzcj)3)
		{
			XTextElement xTextElement4 = null;
			if (xTextElementList.Count == 0)
			{
				xTextElement4 = p0.z0xek().z0ie();
			}
			else if (p0.z0lrk() > 0)
			{
				xTextElement4 = xTextElementList3.z0grk();
			}
			else if (p0.z0uek() == xTextElementList.Count)
			{
				xTextElement4 = xTextElementList[p0.z0uek() - 1].z0ie();
			}
			else
			{
				XTextElement xTextElement5 = xTextElementList[p0.z0uek()];
				xTextElement4 = ((!(xTextElement5 is XTextParagraphFlagElement)) ? xTextElementList[p0.z0uek()].z0ie() : xTextElement5);
			}
			if (xTextElement4 == null || !xTextContentElement.z0trk().z0nek(xTextElement4))
			{
				xTextElement4 = p0.z0xek().z0ie();
			}
			if (xTextElement4 == null || !xTextContentElement.z0trk().z0nek(xTextElement4))
			{
				xTextElement4 = xTextContentElement.z0trk().SafeGet(0);
			}
			XTextElement xTextElement6 = null;
			xTextElement6 = ((xTextElementList.Count == 0) ? p0.z0xek().z0dek() : ((p0.z0lrk() > 0) ? xTextElementList3.z0lrk() : ((p0.z0uek() != xTextElementList.Count) ? xTextElementList[p0.z0uek()].z0dek() : xTextElementList[p0.z0uek() - 1].z0dek())));
			if (xTextElement6 == null || !xTextContentElement.z0trk().z0nek(xTextElement6))
			{
				xTextElement6 = p0.z0xek().z0dek();
			}
			xTextElement3 = xTextContentElement.z0trk().LastElement;
			if (xTextElement6 != null)
			{
				xTextElement3 = xTextContentElement.z0trk().z0xek(xTextElement6);
			}
			num5 = xTextContentElement.z0trk().z0vek(xTextElement4);
			if (num5 >= 0 && xTextContentElement.z0zek() != null && xTextContentElement.z0zek().Length != 0)
			{
				XTextElement xTextElement7 = xTextContentElement.z0trk().SafeGet(num5 - 1);
				int num6 = 0;
				int num7 = xTextContentElement.z0zek().Length - 1;
				if (xTextElement7 != null && xTextElement7.z0ptk() != null)
				{
					num6 = xTextContentElement.z0zek().z0yek(xTextElement7.z0ptk());
					if (xTextElement7.z0ptk().LastElement == xTextElement7)
					{
						num6++;
					}
				}
				int num8 = xTextContentElement.z0trk().IndexOf(xTextElement6);
				if (num8 >= 0)
				{
					xTextElement7 = xTextContentElement.z0trk().SafeGet(num8 + 1);
					if (xTextElement7 != null && xTextElement7.z0ptk() != null)
					{
						num7 = xTextContentElement.z0zek().z0yek(xTextElement7.z0ptk());
					}
				}
				for (int j = num6; j <= num7; j++)
				{
					if (j >= 0 && j <= xTextContentElement.z0zek().Length)
					{
						xTextContentElement.z0zek()[j].z0tek(p0: true);
					}
				}
			}
		}
		bool flag = true;
		XTextElementList xTextElementList4 = xTextElementList.z0mek(p0.z0uek(), p0.z0lrk());
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList4.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (!(current is XTextCharElement) && !(current is XTextParagraphFlagElement))
				{
					flag = false;
					break;
				}
			}
		}
		if (flag && p0.z0yek() != null)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0yek().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current2 = z0bpk.Current;
				if (!(current2 is XTextCharElement) && !(current2 is XTextParagraphFlagElement))
				{
					flag = false;
					break;
				}
			}
		}
		bool flag2 = false;
		if (xTextElementList4 != null && xTextElementList4.Count > 0)
		{
			flag2 = true;
		}
		if (p0.z0yek() != null && p0.z0yek().Count > 0)
		{
			flag2 = true;
		}
		if (flag2 && p0.z0iek())
		{
			ContentChangingEventArgs e = new ContentChangingEventArgs();
			e.Document = this;
			e.Element = p0.z0xek();
			e.ElementIndex = p0.z0uek();
			e.DeletingElements = xTextElementList4;
			e.InsertingElements = p0.z0yek();
			p0.z0xek().z0cek(e);
			if (e.Cancel)
			{
				return 0;
			}
		}
		DocumentSecurityOptions documentSecurityOptions = z0hi();
		z0gnk().Styles.z0eek(p0: false);
		bool flag3 = false;
		List<XTextElement> list = null;
		if (!p0.z0bek() && p0.z0xek().z0brk() && documentSecurityOptions.EnableLogicDelete)
		{
			for (int k = 0; k < p0.z0lrk(); k++)
			{
				XTextElement xTextElement8 = xTextElementList[p0.z0uek() + k];
				if (xTextElement8.z0aek().z0nrk == z0syk().z0yek())
				{
					if (list == null)
					{
						list = new List<XTextElement>();
					}
					list.Add(xTextElement8);
					continue;
				}
				flag3 = true;
				break;
			}
		}
		XTextDocumentContentElement xTextDocumentContentElement = p0.z0xek().z0qek();
		XTextElement xTextElement9 = xTextDocumentContentElement.z0oek().z0uek();
		XTextElement item = xTextDocumentContentElement.z0oek().z0iek();
		if (xTextElement9 == null)
		{
			xTextElement9 = xTextDocumentContentElement.z0frk().SafeGet(xTextDocumentContentElement.z0oek().z0lrk());
			item = xTextElement9;
		}
		List<int> list2 = z0gnk().z0rek();
		int num9 = 0;
		bool flag4 = true;
		if (p0.z0yek() != null && p0.z0yek().Count > 0)
		{
			foreach (XTextElement item2 in p0.z0yek().z0xrk())
			{
				if (item2 is XTextContainerElement)
				{
					flag4 = false;
					break;
				}
			}
		}
		if (p0.z0lrk() > 0)
		{
			if (list2 != null && list2.Count > 0)
			{
				for (int l = 0; l < p0.z0lrk(); l++)
				{
					if (list2 != null && list2.Contains(xTextElementList[p0.z0uek() + l].z0pek()) && !p0.z0nek())
					{
						z0jzk = true;
					}
				}
			}
			if (flag3)
			{
				if (list != null)
				{
					for (int m = 0; m < p0.z0lrk(); m++)
					{
						int num10 = m + p0.z0uek();
						XTextElement xTextElement10 = xTextElementList[num10];
						if (!list.Contains(xTextElement10))
						{
							z0bek(xTextElementList, num10, 1, p3: false, p4: true);
						}
					}
					foreach (XTextElement item3 in list)
					{
						xTextElementList.z0cek(item3);
					}
					list.Clear();
				}
				else
				{
					z0bek(xTextElementList, p0.z0uek(), p0.z0lrk(), p3: false, p4: true);
				}
				if (z0ZzZzafh.z0yek(xTextElementList, p0.z0uek(), p0.z0uek() + p0.z0lrk() - 1))
				{
					z0krk(p0: false);
				}
				xTextDocumentContentElement.z0rek(p0: true);
			}
			else if (p0.z0lrk() == xTextElementList.Count)
			{
				if (z0ZzZzafh.z0yek(xTextElementList, 0, xTextElementList.Count - 1))
				{
					z0krk(p0: false);
				}
				xTextElementList.Clear();
				xTextDocumentContentElement.z0rek(p0: true);
			}
			else
			{
				if (z0ZzZzafh.z0yek(xTextElementList, p0.z0uek(), p0.z0uek() + p0.z0lrk() - 1))
				{
					z0krk(p0: false);
				}
				xTextElementList.z0irk(p0.z0uek(), p0.z0lrk());
				xTextDocumentContentElement.z0rek(p0: true);
			}
			num9 += p0.z0lrk();
		}
		bool flag5 = z0xu();
		if (p0.z0yek() != null && p0.z0yek().Count > 0)
		{
			if (p0.z0bek())
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0yek().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current4 = z0bpk.Current;
					DocumentContentStyle documentContentStyle = current4.z0aek().z0yek();
					if (documentContentStyle.HasTitleLevel)
					{
						z0jzk = true;
					}
					documentContentStyle.CreatorIndex = -1;
					documentContentStyle.DeleterIndex = -1;
					current4.z0oek(z0gnk().GetStyleIndex(documentContentStyle));
				}
			}
			if (!flag5)
			{
				using z0ZzZzjpk p2 = z0ru();
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0yek().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current5 = z0bpk.Current;
					current5.z0yek(p0.z0xek());
					current5.z0yek(this);
					if (!(current5 is XTextCharElement) && !(current5 is XTextParagraphFlagElement))
					{
						current5.z0li();
						current5.z0rt(new ElementLoadEventArgs(current5, null));
					}
					if (current5 is XTextParagraphFlagElement)
					{
						xTextDocumentContentElement.z0rek(p0: true);
					}
					if (current5.z0ao())
					{
						z0ZzZzvxj z0ZzZzvxj = z0bek(p2, (z0ZzZzcxj)0);
						z0ZzZzvxj.z0hyk = current5;
						current5.z0mr(z0ZzZzvxj);
					}
					z0htk()?.z0co(current5);
				}
			}
			if (p0.z0yek().Count == 1)
			{
				xTextElementList.z0oek(p0.z0uek(), p0.z0yek().z0yek(0));
			}
			else
			{
				xTextElementList.z0yek(p0.z0uek(), p0.z0yek());
			}
			if (z0ZzZzafh.z0yek(p0.z0yek(), 0, p0.z0yek().Count - 1))
			{
				z0krk(p0: false);
			}
			z0qck = p0.z0yek().z0pek();
			if (!p0.z0bek() && p0.z0xek().z0brk())
			{
				z0bek(p0.z0yek(), 0, p0.z0yek().Count, p3: true, p4: false);
			}
			num9 += p0.z0yek().Count;
		}
		if (p0.z0hrk() && p0.z0xek() is XTextInputFieldElementBase)
		{
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)p0.z0xek();
			if (p0.z0grk() && z0uik())
			{
				z0imk().z0eek((z0ZzZzqlh)6, xTextInputFieldElementBase.InnerValue, p0.z0rek(), xTextInputFieldElementBase);
			}
			xTextInputFieldElementBase.InnerValue = p0.z0rek();
		}
		if (!flag)
		{
			p0.z0xek().z0we();
		}
		if (p0.z0xek() is XTextContentElement)
		{
			((XTextContentElement)p0.z0xek()).z0vek();
		}
		if (p0.z0tek() != null)
		{
			p0.z0tek()(this, p0);
			num9++;
		}
		if (num9 > 0)
		{
			((XTextElement)p0.z0xek()).z0rrk();
			p0.z0xek().z0ark(p0: false);
		}
		if (p0.z0grk() && z0uik())
		{
			if (flag3)
			{
				z0imk().z0eek(p0.z0xek(), p0.z0uek(), null, p0.z0yek());
			}
			else
			{
				z0imk().z0eek(p0.z0xek(), p0.z0uek(), xTextElementList2, p0.z0yek());
			}
		}
		Modified = true;
		if (p0.z0frk() && !flag5)
		{
			if (p0.z0yek() != null && p0.z0yek().Count > 0)
			{
				z0ZzZzafh.z0yek(p0.z0yek(), z0bek);
			}
			XTextContentElement.z0lgj z0lgj = new XTextContentElement.z0lgj();
			z0lgj.z0eek(num5);
			z0lgj.z0eek(p0: false);
			z0lgj.z0yek(p0: true);
			z0lgj.z0tek(p0: true);
			if (!documentSecurityOptions.ShowLogicDeletedContent && flag3 && p0.z0lrk() > 0)
			{
				z0lgj.z0eek(p0: true);
				z0lgj.z0yek(p0: false);
			}
			z0lgj.z0rek(flag);
			if (flag)
			{
				z0dbk = true;
			}
			else
			{
				z0dbk = false;
			}
			xTextContentElement.z0au(z0lgj);
			if (flag4)
			{
				z0xck = p0.z0xek();
			}
			try
			{
				XTextContainerElement.z0btk = false;
				xTextContentElement.z0wu(num5, (xTextElement3 == null) ? (-1) : xTextContentElement.z0trk().z0vek(xTextElement3), p2: false, p3: false);
			}
			finally
			{
				XTextContainerElement.z0btk = true;
				z0xck = null;
			}
			z0dbk = false;
			if (p0.z0lrk() > 0 && z0ank() != null && z0ank().z0gb(p0: true) && base.z0uyk() != null)
			{
				base.z0uyk().z0hz();
			}
			xTextDocumentContentElement.z0ark();
			try
			{
				XTextContainerElement.z0btk = false;
				if (base.z0uyk() != null)
				{
					base.z0uyk().z0jrk(p0: false);
				}
				if (p0.z0vek())
				{
					p0.z0xek().z0sr();
				}
				else if (p0.z0pek())
				{
					XTextElement xTextElement11 = null;
					if (p0.z0yek() != null && p0.z0yek().Count > 0)
					{
						xTextElement11 = p0.z0yek().z0lrk();
					}
					if (xTextElement11 != null && !(p0.z0xek() is XTextInputFieldElementBase { SpecifyWidth: <0f }))
					{
						xTextElement11.z0yek(p0: true, p1: true);
					}
					int num11 = xTextDocumentContentElement.z0frk().IndexOf(xTextElement9);
					int num12 = xTextDocumentContentElement.z0frk().IndexOf(item);
					if (num11 >= 0 && num12 >= 0)
					{
						xTextDocumentContentElement.z0frk().z0tek(num11, num12 - num11);
					}
					else if (num11 >= 0 && num12 < 0)
					{
						xTextDocumentContentElement.z0frk().z0tek(num11, 0);
					}
					else if (num11 < 0 && num12 >= 0)
					{
						xTextDocumentContentElement.z0frk().z0tek(num12, 0);
					}
					else if (num11 < 0 && num12 < 0 && xTextElement9.z0ji() == p0.z0xek())
					{
						p0.z0xek().z0sr();
					}
					else
					{
						xTextDocumentContentElement.z0frk().z0tek(xTextDocumentContentElement.z0oek().z0nek(), xTextDocumentContentElement.z0oek().z0qrk());
					}
				}
				else if (p0.z0zek() && xTextElement != null)
				{
					xTextDocumentContentElement.z0frk().z0uek(p0: true);
					xTextDocumentContentElement.z0frk().z0tek(p0: false);
					int num13 = xTextElement.z0jrk();
					if (xTextDocumentContentElement.z0frk().z0lrk(xTextElement) < 0)
					{
						num13--;
					}
					if (p0.z0yek() != null)
					{
						XTextElement xTextElement12 = p0.z0yek().z0lrk();
						if (xTextElement12 is XTextTableElement)
						{
							xTextElement12 = ((XTextTableElement)xTextElement12).z0nek(0, 0, p2: true).z0ie();
							if (xTextElement12 != null)
							{
								num13 = xTextElement12.z0jrk();
							}
						}
						else if (xTextElement12 is XTextSectionElement)
						{
							xTextElement12 = ((XTextSectionElement)xTextElement12).z0ie();
							num13 = xTextElement12.z0jrk();
						}
						else if (xTextElement12 != null && xTextDocumentContentElement.z0frk().z0iek(xTextElement12))
						{
							num13 = xTextElement12.z0jrk();
							if (!xTextElement12.z0oyk())
							{
								XTextElement xTextElement13 = xTextElement12.z0byk();
								num13 = ((xTextElement13 == null || xTextElement13.z0oyk()) ? (xTextElement12.z0jrk() + 1) : xTextElement13.z0jrk());
							}
						}
						xTextElement12?.z0yek(p0: true, p1: true);
					}
					bool p3 = false;
					if (p0.z0eek() == ContentChangedEventSource.UI && p0.z0lrk() == 0)
					{
						XTextElement xTextElement14 = xTextDocumentContentElement.z0frk().SafeGet(num13);
						if (xTextElement14 != null && z0ZzZzjzj.z0yek(xTextElement14))
						{
							p3 = true;
						}
					}
					xTextDocumentContentElement.z0frk().z0tek(num13, p3);
				}
			}
			finally
			{
				XTextContainerElement.z0btk = true;
				if (base.z0uyk() != null)
				{
					z0cu().z0ypk().z0jrk(p0: true);
				}
			}
		}
		int num14 = z0hlj;
		if (p0.z0iek() && !flag5)
		{
			ContentChangedEventArgs e2 = new ContentChangedEventArgs();
			e2.Document = this;
			e2.Element = p0.z0xek();
			e2.ElementIndex = p0.z0uek();
			e2.EventSource = p0.z0eek();
			if (p0.z0lrk() > 0)
			{
				e2.DeletedElements = xTextElementList4;
			}
			e2.InsertedElements = p0.z0yek();
			XTextInputFieldElement.z0erk = true;
			try
			{
				p0.z0xek().z0zi(e2);
			}
			finally
			{
				XTextInputFieldElement.z0erk = false;
			}
			if (p0.z0hrk() && p0.z0xek() is XTextInputFieldElementBase)
			{
				((XTextInputFieldElementBase)p0.z0xek()).InnerValue = p0.z0rek();
			}
		}
		if ((base.z0uyk() == null || !base.z0uyk().z0uuk()) && p0.z0oek_jiejie20260327142557() && z0apk() != null)
		{
			z0apk().z0vv(p0.z0xek());
		}
		if (z0hlj != num14 || z0pu_jiejie20260327142557().ValueValidateMode == DocumentValueValidateMode.Dynamic)
		{
			if (z0nyk())
			{
				z0jok();
			}
			else
			{
				z0mpk()?.z0av(this, p1: true);
			}
		}
		num = (float)Environment.TickCount - num;
		p0.z0eek(num);
		p0.z0eek(num9);
		return num9;
	}

	public bool z0vek(string p0, string p1)
	{
		if (z0ki(p0) is XTextInputFieldElement xTextInputFieldElement)
		{
			xTextInputFieldElement.InnerValue = p1;
			return true;
		}
		return false;
	}

	public new XTextElementList z0jrk(string p0)
	{
		return z0mok().z0eek(p0, typeof(XTextCheckBoxElement));
	}

	public new XTextFieldElementBase z0trk()
	{
		return (XTextFieldElementBase)z0bek(typeof(XTextFieldElementBase), p1: true);
	}

	public void z0bek(z0ZzZzgcj p0)
	{
		z0txk = p0;
	}

	public new z0ZzZzerj z0yrk()
	{
		if (z0xnk == null)
		{
			return z0suk();
		}
		return z0xnk;
	}

	private new DocumentContentStyle z0urk()
	{
		return null;
	}

	public new void z0hrk(string p0)
	{
	}

	public XTextElement z0bek(Type p0)
	{
		return z0bek(p0, p1: true);
	}

	public int z0bek(z0ZzZzzxj p0)
	{
		if (p0 == null)
		{
			return 0;
		}
		if (p0.z0rek() == null || p0.z0rek().Count == 0)
		{
			return 0;
		}
		XTextElement xTextElement = p0.z0tek();
		int num = 0;
		if (xTextElement == null)
		{
			xTextElement = z0itk();
		}
		bool flag = false;
		bool flag2 = p0.z0rek().Count == 1 && p0.z0rek()[0] is XTextParagraphFlagElement;
		if (flag2)
		{
			if (z0grk())
			{
				XTextTableElement xTextTableElement = xTextElement.z0brk().z0gr();
				XTextContainerElement xTextContainerElement = xTextTableElement.z0ji();
				if (!xTextContainerElement.z0sek())
				{
					z0ZzZzezj z0ZzZzezj = new z0ZzZzezj(xTextTableElement.z0ji(), xTextContainerElement.z0be().IndexOf(xTextTableElement), 0, p0.z0rek(), p4: true, p0.z0yek(), p6: true);
					z0ZzZzezj.z0yek(p0.z0oek());
					if (z0ZzZzezj.z0nek())
					{
						z0ZzZzezj.z0rek(p0: false);
					}
					int result = z0bek(z0ZzZzezj);
					if (p0.z0rek().Count > 0)
					{
						z0jrk().z0uek(p0.z0rek()[0].z0jrk(), 0);
					}
					return result;
				}
			}
			else if (z0eok())
			{
				XTextSectionElement xTextSectionElement = xTextElement.z0iek();
				XTextContainerElement xTextContainerElement2 = xTextSectionElement.z0ji();
				if (!xTextContainerElement2.z0sek())
				{
					z0ZzZzezj z0ZzZzezj2 = new z0ZzZzezj(xTextSectionElement.z0ji(), xTextContainerElement2.z0be().IndexOf(xTextSectionElement), 0, p0.z0rek(), p4: true, p0.z0yek(), p6: true);
					z0ZzZzezj2.z0yek(p0.z0oek());
					if (z0ZzZzezj2.z0nek())
					{
						z0ZzZzezj2.z0rek(p0: false);
					}
					int result2 = z0bek(z0ZzZzezj2);
					if (p0.z0rek().Count > 0 && !p0.z0oek())
					{
						z0jrk().z0uek(p0.z0rek()[0].z0jrk(), 0);
					}
					return result2;
				}
			}
		}
		XTextDocumentContentElement xTextDocumentContentElement = xTextElement.z0qek();
		z0xyk();
		XTextContainerElement p1 = null;
		int p2 = 0;
		xTextDocumentContentElement.z0frk().z0tek(xTextDocumentContentElement.z0frk().IndexOf(xTextElement), out p1, out p2, xTextDocumentContentElement.z0frk().z0frk());
		z0ZzZzezj z0ZzZzezj3 = new z0ZzZzezj(p1, p2 + num, 0, p0.z0rek(), p4: true, p0.z0yek(), p6: true);
		if (p0.z0uek())
		{
			z0ZzZzezj3.z0eek(ContentChangedEventSource.UI);
		}
		z0ZzZzezj3.z0yek(p0.z0oek());
		if (z0ZzZzezj3.z0nek())
		{
			z0ZzZzezj3.z0rek(p0: false);
		}
		if (flag2 && p1.z0be().SafeGet(p2) is XTextParagraphFlagElement xTextParagraphFlagElement && xTextParagraphFlagElement.z0aek().z0ttk >= 0 && z0xek().z0np(xTextParagraphFlagElement) && !z0bu().ContinueHeaderParagrahStyle)
		{
			z0ZzZzezj3.z0eek(xTextParagraphFlagElement);
			z0ZzZzezj3.z0eek(z0bek);
		}
		if (!flag)
		{
			_ = xTextElement is XTextCharElement;
		}
		if (p1 is XTextContentElement && p2 == p1.z0be().Count)
		{
			p2 = p1.z0be().Count - 1;
		}
		z0ZzZzezj3.z0tek(p2 + num);
		return z0bek(z0ZzZzezj3);
	}

	internal new z0ZzZzpjh z0irk()
	{
		if (z0fzk == null)
		{
			z0fzk = z0ZzZzuok.z0eek<z0ZzZzpjh>();
			if (z0fzk != null)
			{
				z0fzk.z0mb(this);
			}
		}
		return z0fzk;
	}

	public new bool z0cek(XTextElement p0)
	{
		int num = p0.z0buk;
		if (num < 0)
		{
			return true;
		}
		if (z0nzk != null && !z0nzk.z0eek(num, z0hi().ShowLogicDeletedContent))
		{
			return false;
		}
		return true;
	}

	private new int z0ork()
	{
		return 0;
	}

	public new void z0prk()
	{
		bool flag = false;
		z0nmk().z0eek(this);
		z0gnk().Styles.z0eek(p0: false);
		List<int> list = new List<int>();
		foreach (DocumentContentStyle item in z0gnk().Styles.z0xrk())
		{
			if (item.CommentIndex >= 0)
			{
				list.Add(item.CommentIndex);
			}
		}
		z0ZzZzwcj z0ZzZzwcj = z0gck;
		if (z0ZzZzwcj != null && z0ZzZzwcj.Count > 0)
		{
			for (int num = z0ZzZzwcj.Count - 1; num >= 0; num--)
			{
				if (!list.Contains(z0ZzZzwcj[num].z0tek()))
				{
					z0ZzZzwcj.RemoveAt(num);
					flag = true;
				}
			}
		}
		foreach (DocumentContentStyle item2 in z0gnk().Styles.z0xrk())
		{
			int commentIndex = item2.CommentIndex;
			if (commentIndex >= 0 && (z0ZzZzwcj == null || z0ZzZzwcj.z0eek(commentIndex) == null))
			{
				item2.CommentIndex = -1;
				flag = true;
			}
		}
		z0ZzZzzok styles = z0gnk().Styles;
		int count = styles.Count;
		int[] array = new int[count];
		z0vek(z0be(), array);
		for (int i = 0; i < count; i++)
		{
			DocumentContentStyle p = (DocumentContentStyle)styles[i];
			if (array[i] == 0)
			{
				flag = true;
				continue;
			}
			if (0 > 0)
			{
				flag = true;
			}
			if (z0ZzZzvik.z0eek(p) == 0)
			{
				flag = true;
				array[i] = 0;
			}
		}
		if (flag)
		{
			z0gnk().z0nn();
			DocumentContentStyle documentContentStyle3 = new DocumentContentStyle();
			documentContentStyle3.FontName = "嘿嘿，袁永福到此一游";
			int num2 = 0;
			for (int j = 0; j < count; j++)
			{
				if (array[j] == 0)
				{
					array[j] = -1;
				}
			}
			for (int k = 0; k < count; k++)
			{
				if (array[k] == -1)
				{
					num2++;
					array[k] = -1;
					styles[k].Dispose();
					styles[k] = documentContentStyle3;
					continue;
				}
				if (styles[k] == documentContentStyle3)
				{
					num2++;
					continue;
				}
				DocumentContentStyle documentContentStyle4 = (DocumentContentStyle)styles[k];
				if (documentContentStyle4 == documentContentStyle3)
				{
					continue;
				}
				array[k] = k - num2;
				for (int l = k + 1; l < count; l++)
				{
					if (styles[l] != documentContentStyle3 && documentContentStyle4.z0tek(styles[l]))
					{
						array[l] = array[k];
						styles[l].Dispose();
						styles[l] = documentContentStyle3;
					}
				}
			}
			z0bek(z0be(), array);
			for (int num3 = styles.Count - 1; num3 >= 0; num3--)
			{
				if (styles[num3] == documentContentStyle3)
				{
					styles.RemoveAt(num3);
				}
			}
			z0ZzZzwcj z0ZzZzwcj2 = z0gck;
			if (z0ZzZzwcj2 != null && z0ZzZzwcj2.Count > 0)
			{
				for (int num4 = z0ZzZzwcj2.Count - 1; num4 >= 0; num4--)
				{
					int num5 = z0ZzZzwcj2[num4].z0tek();
					bool flag2 = false;
					using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = z0gnk().Styles.z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							if (((DocumentContentStyle)z0bpk.Current).CommentIndex == num5)
							{
								flag2 = true;
								break;
							}
						}
					}
					if (!flag2)
					{
						z0ZzZzwcj2.RemoveAt(num4);
						flag = true;
					}
				}
			}
			if (z0ZzZzwcj2 != null && z0ZzZzwcj2.Count > 0)
			{
				foreach (DocumentContentStyle item3 in z0gnk().Styles.z0xrk())
				{
					int commentIndex2 = item3.CommentIndex;
					for (int m = 0; m < z0ZzZzwcj2.Count; m++)
					{
						if (z0ZzZzwcj2[m].z0tek() == commentIndex2)
						{
							item3.CommentIndex = m;
						}
					}
				}
				for (int n = 0; n < z0ZzZzwcj2.Count; n++)
				{
					z0ZzZzwcj2[n].z0eek(n);
				}
			}
			using (z0ZzZzjpk p2 = z0ru())
			{
				foreach (DocumentContentStyle item4 in styles.z0xrk())
				{
					item4.z0eek_jiejie20260327142557(p2);
				}
				((DocumentContentStyle)z0gnk().Default).z0eek_jiejie20260327142557(p2);
			}
			z0gnk().z0bn();
		}
		z0pmk();
	}

	public void z0bek(object p0)
	{
		DocumentPaintEventArgs e = (DocumentPaintEventArgs)p0;
		try
		{
			if (z0zxk != null)
			{
				z0zxk(this, e);
			}
		}
		catch (Exception ex)
		{
			e.GraphicsDrawString(ex.ToString(), new z0ZzZzimk(), Color.Red, 0f, 0f);
		}
		if (!z0xrk() && (e.ViewMode != PageViewMode.CompressPage || e.PageIndex <= 0) && (z0ZzZzxvj.z0eek || !z0ZzZzxcj.z0rek(e.PageIndex)))
		{
			z0ZzZzxpk z0ZzZzxpk = (z0ZzZzxpk)z0bek(base.z0uyk(), e.PageIndex);
			if (!z0ZzZzxpk.z0yek)
			{
				z0ZzZzxpk.z0cek = true;
			}
			z0ZzZzjpk z0ZzZzjpk = (z0ZzZzjpk)e.z0tek();
			object p1 = z0ZzZzjpk.z0bek();
			z0ZzZzjpk.z0rek();
			float num = z0ZzZzxpk.z0hrk;
			if (!e.PageClipRectangle.z0bek() && e.ViewMode == PageViewMode.Page)
			{
				z0ZzZzxpk.z0eek(z0ZzZzjpk, e.PageClipRectangle, p2: false, e.ClipRectangle);
			}
			else
			{
				z0ZzZzxpk.z0eek(z0ZzZzjpk, e.Bounds, p2: false, e.ClipRectangle);
			}
			z0ZzZzxpk.z0hrk = num;
			z0ZzZzxpk.z0cek = false;
			z0ZzZzjpk.z0eek(p1);
		}
	}

	public void z0xek(XTextElement p0)
	{
	}

	public new void z0mrk()
	{
		if (z0klj != null)
		{
			z0klj.z0bo();
		}
	}

	public int z0bek(XTextElementList p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			return 0;
		}
		if (z0bu().ValidateIDRepeatMode == DCValidateIDRepeatMode.None)
		{
			return 0;
		}
		int num = 0;
		foreach (XTextElement item in new z0ZzZzkxj(p0))
		{
			if (!string.IsNullOrEmpty(item.ID) && z0srk(item))
			{
				num++;
			}
		}
		return num;
	}

	public new string z0nrk()
	{
		return z0gyk().z0okk(this);
	}

	public new string z0brk()
	{
		return z0cek(p0: false);
	}

	public bool z0grk(string p0)
	{
		return z0ki(p0)?.z0yi() ?? false;
	}

	public bool z0cek(string p0, string p1)
	{
		if (z0ki(p0) is XTextInputFieldElement xTextInputFieldElement)
		{
			return xTextInputFieldElement.z0tek(p1);
		}
		return false;
	}

	public void z0bek(float p0)
	{
		z0lxk = p0;
	}

	public new z0ZzZzyrj z0vrk()
	{
		return z0zzk;
	}

	public void z0vek(object p0)
	{
		z0mck_jiejie20260327142557 = p0;
	}

	public void z0vek(XTextElementList p0)
	{
		z0cck = p0;
	}

	public z0ZzZzrzj GetParagraphStyle(XTextElement element)
	{
		if (element == null)
		{
			return ((DocumentContentStyle)z0gnk().Default).z0eek_jiejie20260327142557();
		}
		XTextParagraphFlagElement xTextParagraphFlagElement = z0jrk(element);
		if (xTextParagraphFlagElement == null)
		{
			return ((DocumentContentStyle)z0gnk().Default).z0eek_jiejie20260327142557();
		}
		return xTextParagraphFlagElement.z0aek();
	}

	internal void z0bek(XTextElementList p0, int p1, int p2, bool p3, bool p4)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elements");
		}
		if (p1 < 0 || p1 >= p0.Count)
		{
			throw new ArgumentOutOfRangeException("startIndex=" + p1);
		}
		if (p2 < 0 || p1 + p2 > p0.Count)
		{
			throw new ArgumentOutOfRangeException("length=" + p2);
		}
		int num = p1 + p2 - 1;
		for (int i = p1; i <= num; i++)
		{
			XTextElement xTextElement = p0[i];
			if (XTextDocumentContentElement.z0xrk && !(xTextElement is XTextCharElement))
			{
				XTextDocumentContentElement.z0xrk = false;
			}
			DocumentContentStyle documentContentStyle = xTextElement.z0aek().z0yek();
			documentContentStyle.z0eek(p0: false);
			if (p3)
			{
				documentContentStyle.CreatorIndex = z0syk().z0yek();
				if (xTextElement is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
					if (xTextContainerElement.z0crk())
					{
						xTextContainerElement.z0be().z0oek(delegate(object obj, ElementEnumerateEventArgs e)
						{
							e.Element.z0xrk().CreatorIndex = z0syk().z0yek();
							e.Element.z0ftk();
							if (e.Element is XTextFieldElementBase)
							{
								((XTextFieldElementBase)e.Element).z0vek();
							}
						}, p1: true, p2: true);
					}
				}
			}
			else
			{
				if (documentContentStyle.DeleterIndex >= 0)
				{
					continue;
				}
				documentContentStyle.DeleterIndex = z0syk().z0yek();
			}
			int styleIndex = z0gnk().GetStyleIndex(documentContentStyle);
			if (p4 && z0uik())
			{
				z0imk().z0eek(xTextElement, xTextElement.z0pek(), styleIndex);
			}
			xTextElement.z0oek(styleIndex);
			if (xTextElement is XTextFieldElementBase)
			{
				((XTextFieldElementBase)xTextElement).z0vek();
			}
		}
		if (z0ZzZzafh.z0yek(p0, p1, num))
		{
			z0krk(p0: false);
		}
	}

	public new static Version z0crk()
	{
		return typeof(XTextDocument).Assembly.GetName().Version;
	}

	public void z0bek(z0ZzZzerj p0)
	{
		z0xnk = p0;
	}

	internal new bool z0xrk()
	{
		if (z0dlj != null && (z0dlj.Printing || z0dlj.PrintPreviewing))
		{
			return true;
		}
		return false;
	}

	public void z0bek(z0ZzZzadh p0)
	{
		z0bek(new z0ZzZzjpk(p0), p1: false);
	}

	private void z0vek(XTextContainerElement p0)
	{
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			current.z0ruk = null;
			if (current is XTextContainerElement)
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)current;
				if (xTextContainerElement.z0crk())
				{
					z0vek(xTextContainerElement);
				}
			}
		}
	}

	public new string z0zrk()
	{
		if (!string.IsNullOrEmpty(z0ipk().z0mek()))
		{
			return z0ipk().z0mek();
		}
		if (!string.IsNullOrEmpty(z0amk()))
		{
			return z0amk();
		}
		return ID;
	}

	public new XTextElementList z0ltk()
	{
		XTextElementList xTextElementList = new XTextElementList();
		z0bek(this, xTextElementList);
		return xTextElementList;
	}

	private JumpPrintInfo z0vek(float p0)
	{
		return z0drk(p0);
	}

	JumpPrintInfo z0ZzZzjrj.z0eek(float p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0vek
		return this.z0vek(p0);
	}

	public void z0bek(bool p0, bool p1)
	{
		z0nik();
		if (z0xu())
		{
			return;
		}
		if (z0snk())
		{
			z0yok();
		}
		else
		{
			z0li();
		}
		z0kgj p2 = z0kgj.z0eek(this, p1: true);
		foreach (XTextDocumentContentElement item in z0be().z0xrk())
		{
			if (item is XTextDocumentBodyElement && XTextSectionElement.z0mek && XTextSectionElement.z0krk)
			{
				Span<XTextElement> span = item.z0be().z0urk();
				for (int num = span.Length - 1; num >= 0; num--)
				{
					if (span[num] is XTextSectionElement xTextSectionElement && xTextSectionElement.z0uek())
					{
						if (z0ock != null)
						{
							z0ock(this);
						}
						break;
					}
				}
			}
			item.z0rek(p0: true);
			item.z0ze(p2);
		}
		if (p1)
		{
			z0vpk();
		}
		XTextContentElement.z0lgj z0lgj = new XTextContentElement.z0lgj();
		z0lgj.z0tek(p0: false);
		z0lgj.z0eek(p0: false);
		if (!z0snk())
		{
			z0lgj.z0bek = true;
		}
		z0vjj z0vjj = new z0vjj();
		z0vjj.z0tek = p0;
		z0vjj.z0rek = z0lgj;
		z0ZzZzafh.z0eek(this, z0vjj, delegate(XTextContentElement xTextContentElement, z0vjj z0vjj2)
		{
			if (!XTextSectionElement.z0mek || (!((XTextElement)xTextContentElement).z0krk() && (!(xTextContentElement is XTextSectionElement) || !((XTextSectionElement)xTextContentElement).z0rek())))
			{
				xTextContentElement.z0au(z0vjj2.z0rek);
				if (z0vjj2.z0tek && xTextContentElement is XTextTableCellElement xTextTableCellElement)
				{
					xTextTableCellElement.Width = 0f;
					xTextTableCellElement.Height = 0f;
					XTextElement xTextElement = xTextTableCellElement.z0ji();
					if (xTextElement != null && xTextElement != z0vjj2.z0eek)
					{
						z0vjj2.z0eek = xTextElement;
						if (xTextElement is XTextTableElement)
						{
							((XTextTableElement)xTextElement).z0jyk = true;
						}
					}
				}
			}
		});
		if (p0)
		{
			foreach (XTextElement item2 in z0xyk().z0be().z0xrk())
			{
				if (item2 is XTextSectionElement)
				{
					((XTextSectionElement)item2).z0nek(p0: true);
				}
			}
		}
		if (z0htk() != null && !z0xu())
		{
			z0htk().z0sp();
		}
	}

	public new XTextInputFieldElement z0ktk()
	{
		return (XTextInputFieldElement)z0bek(typeof(XTextInputFieldElement), p1: true);
	}

	public bool z0bek(string p0, XTextElement p1)
	{
		if (p1 != null)
		{
			if (string.IsNullOrEmpty(p0))
			{
				p0 = p1.z0pe();
			}
			if (string.IsNullOrEmpty(p1.ID))
			{
				p1.ID = z0bek(p0, p1.GetType());
				return true;
			}
		}
		return false;
	}

	public new z0ZzZzmpj z0jtk()
	{
		if (z0ibk == null)
		{
			z0ibk = new z0ZzZzmpj(this);
		}
		return z0ibk;
	}

	public XTextElementList z0rek(Dictionary<XTextElement, int> p0, bool p1, bool p2, string p3)
	{
		bool flag = p3 != "ContentProtect";
		foreach (XTextElement key in p0.Keys)
		{
			key.z0yek(this);
			key.z0li();
		}
		Dictionary<XTextContentElement, XTextElementList> dictionary = new Dictionary<XTextContentElement, XTextElementList>();
		z0ZzZzslh z0ZzZzslh = null;
		if (p1)
		{
			z0ZzZzslh = new z0ZzZzslh();
			z0ZzZzslh.z0eek(this);
			z0ZzZzslh.z0rek(p0: false);
			z0ZzZzslh.z0eek(p2);
			z0ZzZzslh.z0eek(p3);
		}
		z0gnk().Styles.z0eek(p0: false);
		XTextElementList xTextElementList = new XTextElementList();
		List<XTextContainerElement> list = new List<XTextContainerElement>();
		List<XTextTableElement> list2 = new List<XTextTableElement>();
		List<XTextContentElement> list3 = new List<XTextContentElement>();
		List<int> list4 = z0gnk().z0rek();
		z0ZzZzbcj z0ZzZzbcj = (z0ZzZzbcj)255;
		z0ZzZzbcj = (flag ? (z0ZzZzbcj | (z0ZzZzbcj)64) : ((z0ZzZzbcj)z0ZzZzmpk.z0eek((int)z0ZzZzbcj, 64, p2: false)));
		using (z0ZzZzjpk p4 = z0ru())
		{
			z0gnk().z0eek(p4);
			z0ZzZzpxj z0ZzZzpxj = z0xek();
			z0ZzZzpxj.z0mp();
			try
			{
				foreach (XTextElement key2 in p0.Keys)
				{
					if ((!z0ZzZzafh.z0oek(p3) || !z0bu().PowerfulCommentCommand) && !z0ZzZzpxj.z0pm(key2, z0ZzZzbcj))
					{
						continue;
					}
					int num = p0[key2];
					XTextElement xTextElement = null;
					if (key2 is z0ZzZzkzj)
					{
						xTextElement = key2.z0ji();
					}
					else if (key2 is XTextCharElement && ((XTextCharElement)key2).z0oek())
					{
						xTextElement = key2.z0ji();
					}
					else if (key2 is z0ZzZzgkh)
					{
						xTextElement = ((z0ZzZzgkh)key2).z0rek();
					}
					if (xTextElement != null)
					{
						num = ((!p0.ContainsKey(xTextElement)) ? xTextElement.z0buk : p0[xTextElement]);
					}
					XTextContentElement xTextContentElement = key2.z0jy();
					z0ZzZzslh?.z0eek(key2, key2.z0pek(), num);
					if (key2 is XTextParagraphFlagElement)
					{
						XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)key2;
						xTextParagraphFlagElement.z0rek(p0: false);
						xTextParagraphFlagElement.z0rrk();
						if (p2 && xTextContentElement != null)
						{
							z0ZzZzzlh z0ZzZzzlh = xTextParagraphFlagElement.z0ie().z0ptk();
							z0ZzZzzlh z0ZzZzzlh2 = xTextParagraphFlagElement.z0ptk();
							if (z0ZzZzzlh != null && z0ZzZzzlh2 != null)
							{
								int num2 = xTextContentElement.z0zek().z0yek(z0ZzZzzlh2);
								int i = xTextContentElement.z0zek().z0yek(z0ZzZzzlh);
								if (i >= 0)
								{
									for (; i <= num2; i++)
									{
										xTextContentElement.z0zek()[i].z0tek(p0: true);
									}
								}
							}
						}
						if (xTextContentElement != null && !list3.Contains(xTextContentElement))
						{
							list3.Add(xTextContentElement);
						}
					}
					if (list4 != null && (list4.Contains(key2.z0pek()) || list4.Contains(num)))
					{
						z0jzk = true;
					}
					key2.z0iek(num);
					if (!list.Contains(key2.z0ji()))
					{
						XTextContainerElement xTextContainerElement = key2.z0ji();
						list.Add(xTextContainerElement);
						xTextContainerElement.z0yek(this);
						xTextContainerElement.z0li();
					}
					key2.z0lo();
					key2.z0rrk();
					if (p2 && xTextContentElement != null)
					{
						if (key2 is XTextContentElement)
						{
							((XTextContentElement)key2).z0eek(xTextContentElement.z0cr(), p1: false, p2: false);
						}
						key2.z0xi(p0: true);
					}
					xTextElementList.Add(key2);
					if (xTextContentElement != null && xTextContentElement.z0trk().z0zek(key2.z0ie()))
					{
						if (dictionary.ContainsKey(xTextContentElement))
						{
							dictionary[xTextContentElement].Add(key2.z0ie());
						}
						else
						{
							XTextElementList xTextElementList2 = new XTextElementList();
							xTextElementList2.Add(key2.z0ie());
							dictionary[xTextContentElement] = xTextElementList2;
						}
					}
					if (p2)
					{
						z0ZzZzvxj z0ZzZzvxj = z0bek(p4, (z0ZzZzcxj)0);
						z0ZzZzvxj.z0hyk = key2;
						key2.z0mr(z0ZzZzvxj);
					}
					if (key2 is XTextContentElement)
					{
						if (key2 is XTextTableCellElement)
						{
							XTextTableElement xTextTableElement = ((XTextTableCellElement)key2).z0gr();
							if (!list2.Contains(xTextTableElement))
							{
								list2.Add(xTextTableElement);
							}
						}
						else if (p2)
						{
							XTextContentElement xTextContentElement2 = (XTextContentElement)key2;
							z0ZzZzazj z0ZzZzazj = new z0ZzZzazj(null, null, xTextContentElement2.z0cr());
							xTextContentElement2.z0zt(z0ZzZzazj);
							z0ZzZzazj.z0tek();
						}
					}
					if (p2)
					{
						if (key2 is XTextObjectElement)
						{
							((XTextObjectElement)key2).z0cy();
						}
						else if (key2 is XTextShapeInputFieldElement)
						{
							((XTextShapeInputFieldElement)key2).z0eek();
						}
					}
				}
			}
			finally
			{
				z0ZzZzpxj.z0on();
			}
		}
		if (list2.Count > 0)
		{
			foreach (XTextTableElement item in list2)
			{
				item.z0jo();
				if (p2)
				{
					item.z0ct();
					item.z0jo();
				}
				XTextElementList xTextElementList3 = new XTextElementList();
				xTextElementList3.Add(item);
				dictionary[item.z0jy()] = xTextElementList3;
			}
		}
		if (list3.Count > 0)
		{
			list3[0].z0qek().z0rek(p0: false, p1: true);
		}
		if (dictionary.Count > 0)
		{
			if (p1)
			{
				if (z0uik())
				{
					z0bek(z0ZzZzslh);
				}
				else if (z0ytk())
				{
					z0bek(z0ZzZzslh);
					z0nuk();
				}
			}
			Modified = true;
			bool flag2 = false;
			if (p2)
			{
				foreach (XTextContentElement key3 in dictionary.Keys)
				{
					if (key3.z0ar(key3.z0jr(), p1: false))
					{
						key3.z0eek(dictionary[key3], p1: true, p2: true);
						if (key3.z0pek())
						{
							flag2 = true;
						}
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (XTextContainerElement item2 in list)
				{
					if (item2.z0ar(item2.z0jr(), p1: false))
					{
						for (XTextContainerElement xTextContainerElement2 = item2; xTextContainerElement2 != null; xTextContainerElement2 = xTextContainerElement2.z0ji())
						{
							xTextContainerElement2.Modified = true;
						}
						ContentChangedEventArgs e = new ContentChangedEventArgs();
						e.Document = this;
						e.Element = item2;
						e.OnlyStyleChanged = true;
						item2.z0zi(e);
					}
				}
			}
			OnDocumentContentChanged();
			if (flag2)
			{
				z0krk(p0: false);
				z0krk();
				if (z0yyk() != null)
				{
					z0yyk().z0fpk();
					z0yyk().z0vik();
					base.z0uyk().z0hz();
				}
			}
			else if (z0yyk() != null)
			{
				z0yyk().z0vik();
				base.z0uyk().z0hz();
			}
			OnSelectionChanged();
		}
		z0gnk().Styles.z0eek(p0: true);
		return xTextElementList;
	}

	public XTextDocument()
	{
		base.z0rik = this;
		base.z0uik = null;
		z0fik();
		z0klj = new z0ZzZzczj(this);
		z0gnk().Default.FontSize = z0fbk;
	}

	public new z0ZzZzmxj z0htk()
	{
		if (z0lck == null)
		{
			z0lck = z0ZzZzuok.z0eek<z0ZzZzmxj>();
			if (z0lck != null)
			{
				z0lck.z0kp(this);
			}
		}
		return z0lck;
	}

	public void z0cek(XTextElementList p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elements");
		}
		z0bek(p0, z0hi().EnablePermission, z0hi().EnablePermission);
	}

	public void z0xek(XTextElementList p0)
	{
		z0gyk().z0akk(this, p0);
	}

	private new z0ZzZzzlh z0gtk()
	{
		return null;
	}

	public void z0frk(string p0)
	{
		z0bck = p0;
	}

	public override bool z0xu()
	{
		if (z0xbk_jiejie20260327142557 != null)
		{
			return z0xbk_jiejie20260327142557.z0jyk();
		}
		return false;
	}

	public new string z0ftk()
	{
		return z0ozk;
	}

	internal void z0bek(DateTime p0)
	{
		z0yck = p0;
	}

	internal bool z0bek(float p0, float p1)
	{
		if (z0qlj > 0f && (double)Math.Abs(p0 - z0qlj) < (double)p1 * 0.7)
		{
			return false;
		}
		return true;
	}

	public void z0bek(PageViewMode p0)
	{
		z0pzk = p0;
	}

	private void z0bek(XTextElementList p0, DocumentEventArgs p1)
	{
		if (z0xrk())
		{
			return;
		}
		int x = p1.X;
		int y = p1.Y;
		p1.Handled = false;
		int num = 0;
		for (int i = 0; i < p0.Count; i++)
		{
			if (p0[i].z0aek().z0jyk >= 0)
			{
				num = i;
			}
		}
		for (int j = num; j < p0.Count; j++)
		{
			XTextElement xTextElement = p0[j];
			if ((p1.Style == DocumentEventStyles.MouseDown || p1.Style == DocumentEventStyles.MouseMove || p1.Style == DocumentEventStyles.MouseUp || p1.Style == DocumentEventStyles.MouseClick || p1.Style == DocumentEventStyles.MouseDblClick) && !(xTextElement is XTextFieldElementBase) && !(xTextElement is XTextCheckBoxElementBase.z0cok))
			{
				p1.z0grk = (int)((float)x - xTextElement.z0zrk());
				p1.z0oek = (int)((float)y - xTextElement.z0ltk());
				if (p1.X < 0 || (float)p1.X > xTextElement.Width || p1.Y < 0 || (float)p1.Y > xTextElement.Height)
				{
					continue;
				}
			}
			p1.Element = xTextElement;
			xTextElement.z0mu(p1);
			if (p1.Handled || p1.CancelBubble || !xTextElement.z0ar(this, p1: false))
			{
				break;
			}
		}
		p1.z0grk = x;
		p1.z0oek = y;
	}

	public new z0ZzZzzcj z0dtk()
	{
		return z0gvk;
	}

	public void z0bek(z0ZzZzbdh p0)
	{
		z0yvk = p0;
	}

	public new z0ZzZzylh z0stk()
	{
		return z0mpk()?.z0av(this, p1: false);
	}

	public bool z0vek(z0ZzZzgcj p0)
	{
		z0ZzZzgcj z0ZzZzgcj = p0;
		if (z0ZzZzgcj == null || z0ZzZzgcj.Count == 0)
		{
			z0ZzZzgcj = z0txk;
			z0txk = null;
		}
		if (z0ZzZzgcj == null || z0ZzZzgcj.Count == 0)
		{
			return false;
		}
		for (int num = z0ZzZzgcj.Count - 1; num >= 0; num--)
		{
			if (z0ZzZzgcj[num].z0eek() is XTextParagraphFlagElement && ((XTextParagraphFlagElement)z0ZzZzgcj[num].z0eek()).z0hrk())
			{
				z0ZzZzgcj.RemoveAt(num);
			}
		}
		if (z0ZzZzgcj != null && z0ZzZzgcj.Count > 0)
		{
			for (int num2 = z0ZzZzgcj.Count - 1; num2 >= 0; num2--)
			{
				XTextElement xTextElement = z0ZzZzgcj[num2].z0eek();
				if (xTextElement is XTextFieldBorderElement)
				{
					XTextElement p1 = xTextElement.z0ji();
					if (z0ZzZzgcj.z0eek(xTextElement.z0ji()) == null)
					{
						z0ZzZzgcj[num2].z0eek(p1);
					}
					else
					{
						z0ZzZzgcj.RemoveAt(num2);
					}
				}
				else if (xTextElement.z0ji() is XTextFieldElementBase && xTextElement is XTextCharElement && ((XTextFieldElementBase)xTextElement.z0ji()).z0eek(xTextElement))
				{
					XTextElement p2 = xTextElement.z0ji();
					if (z0ZzZzgcj.z0eek(xTextElement.z0ji()) == null)
					{
						z0ZzZzgcj[num2].z0eek(p2);
					}
					else
					{
						z0ZzZzgcj.RemoveAt(num2);
					}
				}
			}
			PromptProtectedContentMode promptProtectedContent = z0bu().PromptProtectedContent;
			if (promptProtectedContent == PromptProtectedContentMode.Flash)
			{
				if (z0yyk() != null)
				{
					XTextElementList xTextElementList = new XTextElementList();
					foreach (z0ZzZzhcj item in z0ZzZzgcj)
					{
						xTextElementList.Add(item.z0eek());
					}
					z0yyk().z0zj(xTextElementList, p1: true);
				}
				return true;
			}
			string text = null;
			string text2 = z0ZzZziok.z0puk();
			switch (promptProtectedContent)
			{
			case PromptProtectedContentMode.None:
				text = text2 + Environment.NewLine + z0ZzZzgcj[0].z0tek();
				break;
			case PromptProtectedContentMode.Simple:
				text = text2 + Environment.NewLine + z0ZzZzgcj[0].z0tek();
				break;
			case PromptProtectedContentMode.Details:
				text = text2 + Environment.NewLine + z0ZzZzgcj.z0eek();
				break;
			}
			if (z0yyk() != null)
			{
				PromptProtectedContentEventArgs e = new PromptProtectedContentEventArgs(z0yyk(), this, z0ZzZzgcj[0].z0eek(), text, promptProtectedContent);
				z0yyk().z0eek(e);
				if (e.Handled)
				{
					return true;
				}
			}
			switch (promptProtectedContent)
			{
			case PromptProtectedContentMode.Simple:
				z0ZzZzfpj.z0tek(z0yyk(), text);
				break;
			case PromptProtectedContentMode.Details:
				z0ZzZzfpj.z0tek(z0yyk(), text);
				break;
			}
			return true;
		}
		return false;
	}

	public void z0bek(z0ZzZzuhh p0)
	{
		z0obk = p0;
	}

	public new float[] z0atk()
	{
		return z0alj;
	}

	public new z0ZzZzmcj z0qtk()
	{
		return z0dlj;
	}

	public void z0bek(z0ZzZzmpj p0)
	{
		z0ibk = p0;
	}

	public void z0xek(string p0, string p1)
	{
		try
		{
			z0pok();
			z0bek(null, p0, p1, p3: false, XTextDocument.z0fmk.z0eek, null);
		}
		finally
		{
			z0smk();
		}
	}

	private new void z0zek(bool p0)
	{
		if (z0xzk)
		{
			z0ZzZzqok.z0rek.z0sh(string.Empty);
			throw new Exception(z0ZzZziok.z0vyk());
		}
		z0nik();
		if (!p0 && z0hbk)
		{
			return;
		}
		z0hbk = true;
		try
		{
			if (z0pxk != null && z0pxk.Count > 0)
			{
				foreach (XTextContentElement item in z0pxk)
				{
					item.z0crk();
				}
			}
			XTextDocumentBodyElement xTextDocumentBodyElement = z0xyk();
			List<XTextPageBreakElement> list = new List<XTextPageBreakElement>();
			List<XTextPageInfoElement> list2 = new List<XTextPageInfoElement>();
			z0iek(xTextDocumentBodyElement, list, list2);
			if (list.Count == 0)
			{
				list = null;
			}
			foreach (XTextDocumentContentElement item2 in z0be().z0xrk())
			{
				if (item2 != xTextDocumentBodyElement)
				{
					z0mek(item2, list2);
				}
				item2.z0nt(0f);
				z0ZzZzzlh[] array = item2.z0rrk().z0krk();
				for (int num = item2.z0rrk().Count - 1; num >= 0; num--)
				{
					array[num].z0guk = null;
				}
				array = ((XTextContentElement)item2).z0zek();
				if (array != null && array.Length != 0)
				{
					for (int num2 = ((XTextContentElement)item2).z0zek().Length - 1; num2 >= 0; num2--)
					{
						array[num2].z0guk = null;
					}
				}
			}
			z0ZzZzerj z0ZzZzerj = z0suk();
			XPageSettings pageSettings = PageSettings;
			z0ZzZzerj.Clear();
			z0nvk = null;
			if (base.z0uyk() != null)
			{
				base.z0uyk().z0eek((z0ZzZzwrj)null);
			}
			z0ZzZzerj.z0eek(0f);
			float num3 = z0abk.z0uek();
			z0nvk = null;
			if (z0yyk() != null)
			{
				z0bek(z0yyk().z0qtk());
			}
			if (z0alj != null && z0alj.Length != 0)
			{
				for (int i = 0; i < z0alj.Length; i++)
				{
					float num4 = z0alj[i];
					if (num4 > num3)
					{
						z0ZzZzwrj z0ZzZzwrj = new z0ZzZzwrj(this, pageSettings.z0wtk(), z0ZzZzerj, 0f, 0f);
						z0ZzZzwrj.z0yek(num4 - z0ZzZzwrj.z0irk());
						z0ZzZzwrj.z0eek(Height);
						num3 = z0ZzZzwrj.z0qrk();
						z0ZzZzerj.Add(z0ZzZzwrj);
						z0ZzZzwrj.z0lrk();
					}
				}
			}
			z0ZzZzszj z0ZzZzszj = new z0ZzZzszj();
			z0ZzZzszj.z0xek = pageSettings;
			z0ZzZzszj.z0wrk = pageSettings.z0mrk();
			z0ZzZzszj.z0qrk = 50f;
			z0ZzZzszj.z0eek(list);
			if (z0qxk != null && z0qxk.z0nek())
			{
				z0ZzZzszj.z0rrk = true;
			}
			if (z0ZzZzszj.z0wrk < z0ZzZzszj.z0qrk * 2f)
			{
				throw new Exception(z0ZzZziok.z0guk());
			}
			int num5 = (int)(((XTextElement)xTextDocumentBodyElement).z0ltk() + xTextDocumentBodyElement.Height);
			bool p1 = false;
			xTextDocumentBodyElement.z0rek();
			float num6 = -1f;
			XTextDocumentHeaderElement xTextDocumentHeaderElement = z0pyk();
			XTextDocumentFooterElement xTextDocumentFooterElement = z0lik();
			while (z0ZzZzerj.z0yek() < (float)num5)
			{
				if (list != null && list.Count > 0)
				{
					foreach (XTextPageBreakElement item3 in list)
					{
						for (XTextContainerElement xTextContainerElement = item3.z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
						{
							xTextContainerElement.z0frk(p0: false);
						}
					}
					foreach (XTextPageBreakElement item4 in list)
					{
						if (!item4.z0eek)
						{
							for (XTextContainerElement xTextContainerElement2 = item4.z0ji(); xTextContainerElement2 != null; xTextContainerElement2 = xTextContainerElement2.z0ji())
							{
								xTextContainerElement2.z0frk(p0: true);
							}
						}
					}
				}
				z0ZzZzwrj z0ZzZzwrj2 = new z0ZzZzwrj(this, pageSettings, z0ZzZzerj, 0f, 0f);
				z0ZzZzwrj2.z0yek(z0ZzZzerj.Count % 2 == 1);
				z0ZzZzwrj2.z0eek(pageSettings.z0htk_jiejie20260327142557());
				z0ZzZzwrj2.z0eek(p1);
				if (pageSettings.z0mek())
				{
					if (pageSettings.z0rrk())
					{
						if (z0ZzZzerj.Count == 0)
						{
							z0ZzZzwrj2.z0uek(z0cyk().Height);
							z0ZzZzwrj2.z0rek(z0guk().Height);
							z0ZzZzwrj2.z0tek(p0: true);
							num6 = -1f;
						}
						else if (z0ZzZzerj.Count == 1)
						{
							num6 = -1f;
							z0ZzZzwrj2.z0uek(xTextDocumentHeaderElement.Height);
							z0ZzZzwrj2.z0rek(xTextDocumentFooterElement.Height);
							z0ZzZzwrj2.z0tek(p0: false);
						}
						else
						{
							z0ZzZzwrj2.z0uek(xTextDocumentHeaderElement.Height);
							z0ZzZzwrj2.z0rek(xTextDocumentFooterElement.Height);
							z0ZzZzwrj2.z0tek(p0: false);
						}
					}
					else
					{
						z0ZzZzwrj2.z0uek(xTextDocumentHeaderElement.Height);
						z0ZzZzwrj2.z0rek(xTextDocumentFooterElement.Height);
						z0ZzZzwrj2.z0tek(p0: false);
					}
				}
				else
				{
					z0ZzZzwrj2.z0uek(0f);
					z0ZzZzwrj2.z0rek(0f);
				}
				if (num6 < 0f)
				{
					num6 = z0ZzZzwrj2.z0urk();
				}
				z0ZzZzwrj2.z0oek(num6);
				if (z0ZzZzszj.z0iek().Count > 0)
				{
					if (z0ZzZzerj.Count > 0)
					{
						XTextElement[] array2 = z0ZzZzerj.z0tek().z0uek();
						if (array2 != null && array2.Length == z0ZzZzszj.z0iek().Count)
						{
							bool flag = true;
							for (int num7 = array2.Length - 1; num7 >= 0; num7--)
							{
								if (array2[num7] != z0ZzZzszj.z0iek()[num7])
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								z0ZzZzwrj2.z0eek(array2);
							}
						}
					}
					if (z0ZzZzwrj2.z0uek() == null)
					{
						z0ZzZzwrj2.z0eek(z0ZzZzszj.z0iek().ToArray());
					}
					z0ZzZzncj.z0eek(z0ZzZzwrj2);
					float num8 = 0f;
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzszj.z0iek().z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
							num8 += xTextTableRowElement.Height;
						}
					}
					z0ZzZzwrj2.z0yek(z0ZzZzwrj2.z0xek() - num8);
					z0ZzZzszj.z0iek().Clear();
				}
				if (z0ZzZzwrj2.z0xek() < 50f)
				{
					break;
				}
				z0ZzZzwrj2.z0eek(Height);
				z0ZzZzszj.z0srk = z0xyk().z0rrk();
				z0ZzZzszj.z0urk = z0ZzZzerj.Count;
				z0ZzZzszj.z0ork = z0ZzZzwrj2.z0irk();
				z0ZzZzszj.z0grk = z0ZzZzwrj2.z0qrk();
				z0ZzZzszj.z0irk = z0nnk();
				z0ZzZzszj.z0vek = false;
				z0ZzZzszj.z0krk.Clear();
				z0ZzZzszj.z0iek().Clear();
				xTextDocumentBodyElement.z0eek(z0ZzZzszj);
				if (!z0ZzZzszj.z0rrk && z0ZzZzszj.z0krk != null && z0ZzZzszj.z0krk.Count > 0)
				{
					foreach (XTextTableCellElement item5 in z0ZzZzszj.z0krk)
					{
						if (item5.z0eek(z0ZzZzszj.z0oek()))
						{
							if (z0pxk == null)
							{
								z0pxk = new List<XTextContentElement>();
							}
							z0pxk.Add(item5);
						}
					}
				}
				if (z0ZzZzszj.z0tek().Count > 1)
				{
					for (int j = 0; j < z0ZzZzszj.z0tek().Count - 1; j++)
					{
						XTextContentElement xTextContentElement = null;
						XTextElement xTextElement = z0ZzZzszj.z0tek()[j];
						if (xTextElement is XTextContentElement)
						{
							xTextContentElement = (XTextContentElement)xTextElement;
						}
						else
						{
							xTextContentElement = xTextElement.z0jy();
						}
					}
				}
				if (z0ZzZzszj.z0pek() is XTextPageBreakElement)
				{
					z0ZzZzwrj2.z0ltk = true;
				}
				z0ZzZzszj.z0rek((XTextElement)null);
				z0ZzZzszj.z0tek().Clear();
				z0ZzZzwrj2.z0yek(z0ZzZzszj.z0oek() - z0ZzZzwrj2.z0irk());
				p1 = z0ZzZzszj.z0vek;
				if (!(z0ZzZzszj.z0pek() is XTextPageBreakElement) && z0ZzZzwrj2.z0xek() < z0ZzZzszj.z0qrk)
				{
					z0ZzZzwrj2.z0yek(z0ZzZzwrj2.z0jrk());
				}
				num3 = z0ZzZzwrj2.z0qrk();
				z0ZzZzerj.Add(z0ZzZzwrj2);
				if (z0ZzZzszj.z0hrk)
				{
					z0ZzZzerj.Add(z0ZzZzwrj2.z0pek());
					z0ZzZzszj.z0hrk = false;
				}
			}
			z0ZzZzszj.z0uek();
			z0ZzZzszj.Dispose();
			if (list != null)
			{
				list.Clear();
				list = null;
			}
			if (z0ZzZzerj.Count > 0)
			{
				xTextDocumentBodyElement.z0rek((z0ZzZzlkh)null);
				z0ZzZzerj.z0tek().z0yek(z0ZzZzerj.z0tek().z0xek() - (z0ZzZzerj.z0yek() - ((XTextElement)xTextDocumentBodyElement).z0ltk() - xTextDocumentBodyElement.Height));
			}
			z0krk(p0: true);
			if (z0ipk() != null)
			{
				z0ipk().z0yek(z0ZzZzerj.Count);
			}
			((XTextContentElement)xTextDocumentBodyElement).z0rrk();
			z0ZzZzafh.z0eek(xTextDocumentBodyElement, p1: true, delegate(XTextContentElement xTextContentElement2, bool flag3)
			{
				xTextContentElement2.z0rrk();
			});
			xTextDocumentBodyElement.z0rek((z0ZzZzlkh)null);
			if (list2 != null && list2.Count > 0)
			{
				using z0ZzZzjpk p2 = z0ru();
				z0ZzZzvxj z0ZzZzvxj = z0bek(p2, (z0ZzZzcxj)0);
				foreach (XTextPageInfoElement item6 in list2)
				{
					XTextPageInfoElement xTextPageInfoElement = (XTextPageInfoElement)(z0ZzZzvxj.z0hyk = item6);
					float width = xTextPageInfoElement.Width;
					xTextPageInfoElement.z0mr(z0ZzZzvxj);
					float num9 = xTextPageInfoElement.Width - width;
					if (num9 != 0f)
					{
						z0ZzZzzlh z0ZzZzzlh = xTextPageInfoElement.z0ptk();
						for (int num10 = z0ZzZzzlh.IndexOf(xTextPageInfoElement) + 1; num10 < z0ZzZzzlh.Count; num10++)
						{
							XTextElement xTextElement2 = z0ZzZzzlh[num10];
							xTextElement2.z0ot(xTextElement2.z0it() + num9);
						}
					}
				}
			}
			if (!z0qtk().Printing)
			{
				z0ZzZzqbj z0ZzZzqbj = base.z0uyk();
				bool flag2 = false;
				if (z0ZzZzqbj != null && z0ZzZzqbj.z0rrk() && z0lrk(p0: false) && z0ank() != null)
				{
					using z0ZzZzjpk p3 = z0ru();
					z0ank().z0tb(p3, base.z0uyk());
					flag2 = true;
				}
				if (!flag2 && z0ank() != null)
				{
					z0ank().z0jb(z0ZzZzqbj);
				}
			}
			z0xtk();
			z0qtk().Layouted = true;
		}
		finally
		{
			z0hbk = false;
		}
	}

	public void z0bek(ElementValidatingEventArgs p0)
	{
		if (p0.Handled)
		{
			return;
		}
		if (EventElementValidating != null)
		{
			EventElementValidating(this, p0);
			if (p0.Handled)
			{
				return;
			}
		}
		if (z0yyk() != null)
		{
			z0yyk().z0eek(p0);
		}
	}

	public new static string z0wtk()
	{
		byte[] array = Convert.FromBase64String("4r22uLKrvL6Ssrux");
		for (int i = 0; i < 12; i++)
		{
			array[i] = (byte)(array[i] ^ (211 + i));
		}
		Encoding.UTF8.GetString(array);
		if (z0pvk == null)
		{
			return null;
		}
		return Encoding.UTF8.GetString(z0pvk);
	}

	internal new bool z0lrk(bool p0 = false)
	{
		if (z0azk != null && z0azk.Count > 0)
		{
			return true;
		}
		if (z0gck != null && z0gck.Count > 0)
		{
			if (p0)
			{
				return z0gck.z0eek();
			}
			return true;
		}
		return false;
	}

	public new XTextElement z0etk()
	{
		return z0czk;
	}

	private void z0bek(object p0, ElementEnumerateEventArgs p1)
	{
		XTextElement element = p1.Element;
		if (element is XTextTableElement)
		{
			XTextTableElement xTextTableElement = (XTextTableElement)element;
			if (xTextTableElement.z0ptk() == null)
			{
				p1.Cancel = true;
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0zek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement obj = (XTextTableCellElement)z0bpk.Current;
					obj.Width = 0f;
					obj.Height = 0f;
				}
			}
			xTextTableElement.z0ct();
			p1.CancelChild = true;
		}
		else if (element is XTextSectionElement)
		{
			XTextSectionElement obj2 = (XTextSectionElement)element;
			if (obj2.z0ptk() == null)
			{
				p1.Cancel = true;
			}
			obj2.z0ct();
			p1.CancelChild = true;
		}
	}

	private new void z0rtk()
	{
		if (z0yyk() != null)
		{
			z0yyk().z0eek(EventArgs.Empty);
		}
		if (SelectionChanged != null)
		{
			SelectionChanged(this, EventArgs.Empty);
		}
	}

	public new XTextElementList z0ttk()
	{
		return z0nek<XTextImageElement>();
	}

	public new bool z0ytk()
	{
		if (z0xrk())
		{
			return false;
		}
		if (!z0bu().EnableLogUndo)
		{
			return false;
		}
		if (z0xu())
		{
			return false;
		}
		if (z0klj != null)
		{
			return z0klj.z0mo();
		}
		return false;
	}

	public string z0bek(string p0, bool p1)
	{
		return z0gyk().z0qkk(this, p0, p1);
	}

	public bool z0bek(string p0, int p1, int p2, string p3)
	{
		XTextTableCellElement xTextTableCellElement = z0vek(p0, p1, p2);
		if (xTextTableCellElement != null)
		{
			return z0vek(xTextTableCellElement, p3);
		}
		return false;
	}

	public new object z0utk()
	{
		return z0mck_jiejie20260327142557;
	}

	public override z0ZzZzdbj z0cu()
	{
		return z0xbk_jiejie20260327142557;
	}

	public XTextElement z0bek(float p0, float p1, bool p2)
	{
		XTextElement xTextElement = z0ryk().z0tek(p0, p1, p2);
		if (xTextElement is z0ZzZzgkh)
		{
			xTextElement = ((z0ZzZzgkh)xTextElement).z0rek();
		}
		if (xTextElement == null)
		{
			XTextElementList xTextElementList = z0unk().z0eek_jiejie20260327142557(z0jrk(), typeof(XTextTableElement));
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				for (int num = xTextElementList.Count - 1; num >= 0; num--)
				{
					XTextTableElement xTextTableElement = (XTextTableElement)xTextElementList[num];
					if (!((XTextElement)xTextTableElement).z0krk())
					{
						XTextTableCellElement xTextTableCellElement = xTextTableElement.z0pek(p0, p1);
						if (xTextTableCellElement != null)
						{
							return xTextTableCellElement;
						}
					}
				}
			}
		}
		if (xTextElement == null)
		{
			XTextElementList xTextElementList2 = z0unk().z0eek_jiejie20260327142557(z0jrk(), typeof(XTextSectionElement));
			if (xTextElementList2 != null && xTextElementList2.Count > 0)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextSectionElement xTextSectionElement = (XTextSectionElement)z0bpk.Current;
					if (!((XTextElement)xTextSectionElement).z0krk() && xTextSectionElement.z0yi() && !xTextSectionElement.z0rek() && xTextSectionElement.z0qyk().z0eek(p0, p1))
					{
						return xTextSectionElement;
					}
				}
			}
		}
		return xTextElement;
	}

	public new XTextElement z0itk()
	{
		return z0jrk()?.z0zek();
	}

	public new int z0otk()
	{
		return -1;
	}

	public bool z0vek(string p0, bool p1)
	{
		return z0ki(p0)?.z0or(p1, p1: false, p2: false) ?? false;
	}

	internal z0ZzZzbdh z0zek(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (p0 is XTextCharElement || p0 is XTextParagraphFlagElement || p0 is XTextFieldBorderElement)
		{
			z0ZzZzzlh z0ZzZzzlh = p0.z0ptk();
			if (z0ZzZzzlh != null)
			{
				return new z0ZzZzbdh(z0ZzZzzlh.z0xtk() + p0.z0it(), z0ZzZzzlh.z0xrk(), p0.Width + p0.z0pt(), z0ZzZzzlh.z0ytk());
			}
		}
		z0ZzZzbdh z0ZzZzbdh = p0.z0qyk();
		z0ZzZzbdh.z0tek(p0.z0lu() + p0.z0pt());
		if (p0 is XTextSignImageElement)
		{
			XTextContainerElement xTextContainerElement = ((XTextSignImageElement)p0).z0yek();
			if (xTextContainerElement != null)
			{
				z0ZzZzbdh p1 = z0zek(xTextContainerElement);
				z0ZzZzbdh = z0ZzZzbdh.z0yek(z0ZzZzbdh, p1);
			}
		}
		if (!(p0 is XTextCharElement) && !(p0 is XTextTableCellElement) && !(p0 is XTextParagraphFlagElement) && !(p0 is XTextFieldBorderElement) && !(p0 is XTextObjectElement) && base.z0uyk() != null)
		{
			z0ZzZzgxj z0ZzZzgxj = base.z0uyk().z0mrk();
			if (z0ZzZzgxj != null)
			{
				z0ZzZzhxj z0ZzZzhxj = z0ZzZzgxj.z0eek(p0);
				if (z0ZzZzhxj != null)
				{
					z0ZzZzbdh = z0ZzZzbdh.z0yek(z0ZzZzbdh, z0ZzZzhxj.z0yek());
				}
			}
		}
		if (p0.z0ci() == ElementZOrderStyle.Normal && p0.z0ptk() != null)
		{
			z0ZzZzbdh.z0rek(p0.z0ptk().z0xrk());
			if (p0.z0aek().z0xyk == ContentLayoutAlign.EmbedInText)
			{
				z0ZzZzbdh.z0yek(Math.Max(p0.z0ptk().z0ytk(), p0.Height));
				if (p0.Height > p0.z0ptk().z0ytk())
				{
					z0ZzZzbdh.z0rek(z0ZzZzbdh.z0yek() - (p0.Height - p0.z0ptk().z0ytk()));
					z0ZzZzbdh.z0yek(p0.Height);
				}
			}
		}
		if (p0.z0aek().z0xyk == ContentLayoutAlign.Surroundings)
		{
			z0ZzZzbdh.z0yek(Math.Max(z0ZzZzbdh.z0iek(), p0.z0yt() + p0.Height));
		}
		_ = p0 is XTextParagraphFlagElement;
		if (!(p0 is XTextCharElement))
		{
			XTextElement xTextElement = p0;
			if (p0 is XTextFieldBorderElement)
			{
				xTextElement = p0.z0ji();
			}
			if (!string.IsNullOrEmpty(xTextElement.z0iy()))
			{
				z0ZzZzmpj z0ZzZzmpj = z0jtk();
				z0ZzZzbdh p2 = z0ZzZzmpj.z0eek(xTextElement);
				if (!p2.z0bek())
				{
					z0ZzZzbdh = z0ZzZzbdh.z0yek(z0ZzZzbdh, p2);
				}
				else if (z0ZzZzmpj.z0tek(xTextElement))
				{
					z0ZzZzxdh z0ZzZzxdh = z0ZzZzmpj.z0eek(xTextElement.z0iy());
					z0ZzZzbdh.z0rek(z0ZzZzbdh.z0yek() - z0ZzZzxdh.z0tek());
					z0ZzZzbdh.z0yek(z0ZzZzbdh.z0iek() + z0ZzZzxdh.z0tek());
					z0ZzZzbdh.z0tek(Math.Max(z0ZzZzbdh.z0uek(), z0ZzZzxdh.z0rek()));
				}
			}
		}
		return z0ZzZzbdh;
	}

	public new bool z0ptk()
	{
		return z0rbk;
	}

	public new XTextParagraphFlagElement z0mtk()
	{
		return z0jrk().z0jrk();
	}

	internal void z0cek(float p0)
	{
		z0vxk = p0;
	}

	public float z0xek(float p0)
	{
		return z0ZzZzrpk.z0eek(p0, GraphicsUnit.Pixel, GraphicsUnit.Document);
	}

	public new void z0ntk()
	{
		z0txk = null;
	}

	internal new void z0btk()
	{
		foreach (z0ZzZzwrj item in z0suk())
		{
			item.z0ntk = z0ZzZzndh.z0cek;
		}
	}

	private void z0bek(XTextElement p0, XTextElement p1)
	{
		if (z0yyk() != null)
		{
			z0yyk().z0eek(p0, p1);
		}
	}

	public ElementType z0tek<ElementType>(XTextElement p0, bool p1, bool p2) where ElementType : XTextElement
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("startElement");
		}
		XTextContainerElement xTextContainerElement = p0.z0ji();
		if (xTextContainerElement != null && xTextContainerElement.z0crk())
		{
			int num = xTextContainerElement.z0be().IndexOf(p0);
			if (p2)
			{
				return z0oek<ElementType, ElementType>(xTextContainerElement.z0be(), num + 1, p1, p2);
			}
			return z0oek<ElementType, ElementType>(xTextContainerElement.z0be(), num, p1, p2);
		}
		return null;
	}

	public new DocumentOptions z0vtk()
	{
		if (z0xbk_jiejie20260327142557 != null && z0xbk_jiejie20260327142557.z0cuk() != null)
		{
			return z0xbk_jiejie20260327142557.z0cuk();
		}
		if (z0qvk == null)
		{
			z0qvk = new DocumentOptions();
		}
		return z0qvk;
	}

	public new DataSourceBindingDescriptionList z0ctk()
	{
		return z0gyk().z0ykk(this);
	}

	public XTextElementList z0bek(IEnumerable p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elements");
		}
		XTextElementList xTextElementList = new XTextElementList();
		XTextParagraphElement xTextParagraphElement = new XTextParagraphElement();
		xTextParagraphElement.z0bt(this);
		xTextParagraphElement.z0nu(this);
		xTextElementList.Add(xTextParagraphElement);
		XTextParagraphFlagElement xTextParagraphFlagElement = null;
		foreach (XTextElement item in p0)
		{
			if (item is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement2 = (XTextParagraphFlagElement)item;
				xTextParagraphElement.z0oek(((XTextElement)xTextParagraphFlagElement2).z0pek());
				((zzz.z0ZzZzkuk<XTextElement>)xTextParagraphElement.z0be()).z0pek(item);
				xTextParagraphElement = new XTextParagraphElement();
				xTextParagraphElement.z0bt(this);
				xTextParagraphElement.z0nu(this);
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)xTextParagraphElement);
			}
			else
			{
				((zzz.z0ZzZzkuk<XTextElement>)xTextParagraphElement.z0be()).z0pek(item);
			}
			if (xTextParagraphFlagElement == null)
			{
				xTextParagraphFlagElement = item.z0dy();
			}
		}
		for (int num = xTextElementList.Count - 1; num >= 0; num--)
		{
			XTextParagraphElement xTextParagraphElement2 = (XTextParagraphElement)xTextElementList[num];
			if (xTextParagraphElement2.z0be().Count == 0)
			{
				xTextElementList.RemoveAt(num);
			}
			else if (!(xTextParagraphElement2.z0be().LastElement is XTextParagraphFlagElement))
			{
				((zzz.z0ZzZzkuk<XTextElement>)xTextParagraphElement2.z0be()).z0pek((XTextElement)xTextParagraphFlagElement);
			}
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextParagraphElement obj = (XTextParagraphElement)z0bpk.Current;
			XTextElementList p1 = z0ZzZzafh.z0yek(obj.z0be(), p1: false);
			obj.z0be().Clear();
			((zzz.z0ZzZzkuk<XTextElement>)obj.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)p1);
		}
		return xTextElementList;
	}

	public new void z0xtk()
	{
		foreach (XTextElement item in z0be().z0xrk())
		{
			if (item is XTextDocumentBodyElement || !(item is XTextContainerElement) || ((XTextContainerElement)item).z0xek() <= 1)
			{
				continue;
			}
			item.z0be().z0rek(delegate(XTextLabelElement p0)
			{
				if (p0.z0eek())
				{
					p0.z0jo();
				}
			});
		}
	}

	public void z0drk(string p0)
	{
		z0mbk = p0;
	}

	public new bool z0ztk()
	{
		bool num = z0cek(this);
		if (num)
		{
			Modified = true;
			if (z0imk() != null)
			{
				z0imk().Clear();
			}
		}
		return num;
	}

	public override DocumentOptions z0vu()
	{
		if (z0pck == null)
		{
			return z0vtk();
		}
		return z0pck;
	}

	public new void z0krk(bool p0)
	{
		z0kck = p0;
	}

	internal new void z0lyk()
	{
		if (!z0dbk)
		{
			z0ubk = null;
		}
		if (z0lck != null)
		{
			z0lck.z0sp();
		}
		if (z0dck != null)
		{
			z0dck.z0tek();
		}
		if (z0izk != null)
		{
			z0izk.z0cv();
		}
	}

	public override DocumentBehaviorOptions z0bu()
	{
		if (z0hck == null)
		{
			return z0vtk().BehaviorOptions;
		}
		return z0hck;
	}

	public void z0bek(XTextDocumentContentElement p0)
	{
		if (z0exk != p0)
		{
			if (base.z0uyk() != null && base.z0uyk().z0mrk() != null)
			{
				z0yyk().z0ypk().z0mrk().z0uek();
			}
			z0exk = p0;
		}
	}

	internal void z0bek(bool p0, bool p1, z0ZzZzqbj p2)
	{
		bool flag = z0cxk;
		z0cxk = false;
		z0srk(p0: false);
		z0mok().z0eek();
		z0gnk().Styles.z0eek(p0: false);
		if (z0ZzZzaik.z0eek())
		{
			return;
		}
		bool debugMode = z0bu().DebugMode;
		if (debugMode)
		{
			z0ZzZzqok.z0rek.z0sh("RefreshDocument RefreshSize=" + p0 + " ExecuteLayout=" + p1);
		}
		object p3 = z0cuk().z0yrk();
		try
		{
			z0ZzZzdbj.z0bpk = true;
			z0vek(this);
			z0jbk = true;
			if (z0snk())
			{
				z0yok();
			}
			else
			{
				z0li();
			}
			XTextElementList xTextElementList = z0nek<XTextTableElement>();
			if (xTextElementList.Count > 0)
			{
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableElement xTextTableElement = (XTextTableElement)z0bpk.Current;
						if (xTextTableElement.z0cek(p0: true) > 0)
						{
							xTextTableElement.z0li();
						}
					}
				}
				xTextElementList.Clear();
			}
			xTextElementList = null;
			z0jbk = false;
			int tickCount = Environment.TickCount;
			XTextElement p4 = null;
			XTextElement p5 = null;
			z0jrk().z0rek(ref p4, ref p5);
			z0bek(p1, p1: true);
			if (p2 != null)
			{
				p2.z0eek(GraphicsUnit.Document);
				if (p2.z0rik)
				{
					bool modified = Modified;
					p2.z0zek(p0: false);
					Modified = modified;
				}
			}
			z0ZzZzjpk z0ZzZzjpk = null;
			z0ZzZzjpk = ((p2 != null) ? p2.z0nrk() : z0ru());
			using (z0ZzZzjpk)
			{
				if (p0)
				{
					ElementLoadEventArgs e = new ElementLoadEventArgs(this, null);
					e.UpdateValueBinding = false;
					z0rt(e);
					z0bek(z0ZzZzjpk, p1: false);
				}
				if (p1)
				{
					if (p2 != null)
					{
						z0suk().Clear();
						bool flag2 = false;
						if (z0mzk)
						{
							z0qrk(p0: false);
							flag2 = true;
						}
						z0ct();
						if (flag2)
						{
							z0qrk(p0: true);
						}
					}
					else
					{
						z0suk().Clear();
						z0ct();
					}
				}
				z0ZzZzwcj z0ZzZzwcj = z0gik();
				if (z0ZzZzwcj != null)
				{
					foreach (DocumentComment item in z0ZzZzwcj)
					{
						item.z0tek(0f);
						item.z0rek(0f);
					}
				}
				z0krk();
				p2?.z0sc();
				z0cuk().z0rek(p3);
				z0ryk().z0hrk();
				z0bek((z0ZzZzzcj)3);
				if (!z0tyk())
				{
					OnSelectionChanged();
					if (p2 != null)
					{
						p2.z0xek().z0uj(new WriterEventArgs(p2.z0xek(), this, this));
						p2.z0xek().z0nuk();
					}
				}
			}
			if (p2 != null)
			{
				p2.z0hz();
				if (!z0tyk() && p2.z0urk() != WriterControlExtViewMode.JumpPrint && p2.z0urk() != WriterControlExtViewMode.OffsetJumpPrint)
				{
					if (!z0jrk().z0oek().z0jrk())
					{
						z0jrk().z0rek(p4, p5);
					}
					p2.z0nek();
					p2.z0huk();
				}
			}
			if (flag)
			{
				bool p6 = z0mzk;
				try
				{
					z0qrk(p0: false);
					int num = z0vvk;
					z0hyk();
					if (num != z0vvk)
					{
						p2?.z0sc();
					}
				}
				catch (Exception ex)
				{
					z0ZzZzqok.z0rek.z0sh(ex.ToString());
				}
				finally
				{
					z0qrk(p6);
				}
			}
			tickCount = Math.Abs(Environment.TickCount - tickCount);
			if (debugMode)
			{
				z0ZzZzqok.z0rek.z0sh("RefrehDocument TimeSpan:" + tickCount);
			}
		}
		finally
		{
			z0ZzZzdbj.z0bpk = false;
			if (!z0tyk())
			{
				base.z0uyk()?.z0mrk()?.z0yek();
			}
			z0jbk = true;
		}
		z0ZzZzafh.z0uek("XTextDocument.InnerRefreshDocumentExt");
	}

	public bool z0zek(string p0, string p1)
	{
		XTextElement xTextElement = z0ki(p0);
		if (xTextElement != null)
		{
			return z0vek(xTextElement, p1);
		}
		return false;
	}

	public bool z0kyk()
	{
		if (z0snk())
		{
			return false;
		}
		if (z0cu() != null && !z0cu().z0jyk())
		{
			return true;
		}
		return false;
	}

	public new bool z0jyk()
	{
		if (z0txk != null)
		{
			return z0txk.Count > 0;
		}
		return false;
	}

	public new int z0hyk()
	{
		z0ubk = null;
		return z0rik()?.z0yw() ?? 0;
	}

	private new z0ZzZzxlh z0gyk()
	{
		if (z0dzk == null)
		{
			z0dzk = z0ZzZzuok.z0eek<z0ZzZzxlh>();
		}
		return z0dzk;
	}

	public new List<byte[]> z0fyk()
	{
		return z0ivk;
	}

	public void z0lrk(string p0, string p1)
	{
		if (string.IsNullOrEmpty(p1))
		{
			p1 = z0ZzZzafh.z0pek(p0);
		}
		z0ZzZzphh z0ZzZzphh = z0ZzZznhh.z0eek().z0eek(p1);
		if (z0ZzZzphh != null && z0ZzZzphh is z0ZzZzwgh && p0 != null)
		{
			int num = p0.IndexOf('<');
			if (num > 0)
			{
				p0 = p0.Substring(num);
			}
		}
		StringReader p2 = new StringReader(p0);
		try
		{
			z0pok();
			z0bek(null, p2, p1, p3: false, XTextDocument.z0fmk.z0eek, null);
		}
		finally
		{
			z0smk();
		}
	}

	public bool z0bek(XTextElementList p0, bool p1)
	{
		return z0gyk().z0wkk(this, p0, p1);
	}

	public JumpPrintInfo z0zek(float p0)
	{
		foreach (z0ZzZzwrj item in z0suk())
		{
			if (Math.Abs(item.z0irk() - p0) < 1f)
			{
				JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
				jumpPrintInfo.z0eek(p0);
				jumpPrintInfo.PageIndex = z0suk().IndexOf(item);
				jumpPrintInfo.Position = 0f;
				jumpPrintInfo.z0eek(item);
				return jumpPrintInfo;
			}
		}
		if (p0 > ((XTextElement)z0xyk()).z0ltk() + ((XTextContentElement)z0xyk()).z0hrk() - 1f)
		{
			return null;
		}
		z0ZzZzszj z0ZzZzszj = new z0ZzZzszj();
		z0ZzZzszj.z0grk = p0;
		z0ZzZzszj.z0ork = 0f;
		z0ZzZzszj.z0yrk = true;
		if (z0ZzZzszj.z0oek() > 0f)
		{
			JumpPrintInfo jumpPrintInfo2 = new JumpPrintInfo();
			jumpPrintInfo2.z0eek(p0);
			foreach (z0ZzZzwrj item2 in z0suk())
			{
				if (z0ZzZzszj.z0oek() >= item2.z0irk() && z0ZzZzszj.z0oek() < item2.z0qrk())
				{
					jumpPrintInfo2.PageIndex = z0suk().IndexOf(item2);
					jumpPrintInfo2.Position = (int)(z0ZzZzszj.z0oek() - item2.z0irk());
					jumpPrintInfo2.AbsPosition = z0ZzZzszj.z0oek();
				}
			}
			jumpPrintInfo2.z0eek(z0suk().z0rek(jumpPrintInfo2.PageIndex));
			return jumpPrintInfo2;
		}
		return null;
	}

	internal void z0bek(z0ZzZztzj p0)
	{
		if (z0iu().AdornTextVisibility == DCAdornTextVisibility.Actived)
		{
			for (XTextElement xTextElement = z0itk(); xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				if (z0jtk().z0rek(xTextElement))
				{
					z0krk(xTextElement);
				}
			}
		}
		if (z0yyk() != null)
		{
			z0yyk().z0eek(p0);
		}
		if (SelectionChanging != null)
		{
			SelectionChanging(this, p0);
		}
	}

	public new void z0jrk(bool p0)
	{
		DateTime p1 = z0jpk();
		z0ipk().z0rek(p1);
		if (!z0vtk().SecurityOptions.EnablePermission)
		{
			return;
		}
		if (z0syk().Count > 0)
		{
			z0ZzZzyhh z0ZzZzyhh = z0syk()[z0syk().Count - 1];
			if (z0ZzZzyhh.z0eek())
			{
				z0ZzZzyhh.z0tek(p1);
			}
		}
		if (p0)
		{
			z0ZzZzyhh z0ZzZzyhh2 = z0ZzZzyhh.z0oek();
			if (z0syk().Count > 0)
			{
				z0ZzZzyhh z0ZzZzyhh3 = z0syk()[z0syk().Count - 1];
				z0ZzZzyhh2.z0iek(z0ZzZzyhh3.z0uek());
				z0ZzZzyhh2.z0tek(z0ZzZzyhh3.z0zek());
				z0ZzZzyhh2.z0uek(z0ZzZzyhh3.z0yek());
				z0ZzZzyhh2.z0rek(z0ZzZzyhh3.z0tek());
				z0ZzZzyhh2.z0eek(z0ZzZzyhh3.z0rek());
				z0ZzZzyhh2.z0eek(z0ZzZzyhh3.z0mek());
				z0ZzZzyhh2.z0yek(z0ZzZzyhh3.z0bek());
				z0syk().Add(z0ZzZzyhh2);
			}
		}
	}

	private new XTextTableCellElement z0dyk()
	{
		return null;
	}

	public new z0ZzZzuhh z0syk()
	{
		if (z0obk == null)
		{
			z0obk = new z0ZzZzuhh();
		}
		return z0obk;
	}

	public override XTextDocument z0jr()
	{
		return this;
	}

	public new XTextSubDocumentElement z0ayk()
	{
		return (XTextSubDocumentElement)z0bek(typeof(XTextSubDocumentElement), p1: true);
	}

	public void z0lrk(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		z0cek(new XTextElementList(p0));
	}

	public override void z0nu(XTextContainerElement p0)
	{
	}

	private void z0bek(z0ZzZzkrj p0)
	{
		DocumentRenderMode renderMode = DocumentRenderMode.Paint;
		switch (p0.z0bek())
		{
		case (z0ZzZzxej)3:
			renderMode = DocumentRenderMode.Bitmap;
			break;
		case (z0ZzZzxej)1:
			renderMode = DocumentRenderMode.Print;
			break;
		case (z0ZzZzxej)2:
			renderMode = DocumentRenderMode.Print;
			break;
		case (z0ZzZzxej)0:
			renderMode = DocumentRenderMode.Paint;
			break;
		case (z0ZzZzxej)4:
			renderMode = DocumentRenderMode.PDF;
			break;
		}
		DocumentPaintEventArgs e = new DocumentPaintEventArgs(this, p0.z0mek(), p0.z0uek().z0eek(), renderMode);
		e.Bounds = p0.z0pek().z0eek();
		e.PageClipRectangle = p0.z0pek().z0eek();
		e.ViewBounds = p0.z0pek().z0eek();
		e.PageIndex = p0.z0yek();
		e.PageCount = z0suk().Count;
		e.Page = p0.z0cek();
		e.Element = this;
		e.ViewMode = p0.z0tek();
		z0bek(e);
	}

	void z0ZzZzjrj.z0eek(z0ZzZzkrj p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0bek
		this.z0bek(p0);
	}

	public void z0bek(int p0)
	{
		z0uck = p0;
	}

	private new XTextParagraphFlagElement z0qyk()
	{
		return null;
	}

	public new XTextElement z0wyk()
	{
		if (z0cuk().z0tek() == 1)
		{
			return z0cuk().z0grk()[0];
		}
		return null;
	}

	public new XTextElementList z0eyk()
	{
		XTextElementList xTextElementList = z0nek<XTextInputFieldElement>();
		for (int num = xTextElementList.Count - 1; num >= 0; num--)
		{
			if (!((XTextInputFieldElement)xTextElementList[num]).Modified)
			{
				xTextElementList.RemoveAt(num);
			}
		}
		return xTextElementList;
	}

	public bool z0krk(XTextElement p0)
	{
		if (!z0qzk)
		{
			return false;
		}
		if (z0snk() || z0sck)
		{
			return false;
		}
		z0ZzZzqbj z0ZzZzqbj = z0yyk()?.z0ypk();
		if (z0ZzZzqbj == null)
		{
			return false;
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (!z0yyk().z0jyk() && z0ZzZzqbj.z0zpk)
		{
			if (p0 == this)
			{
				z0ZzZzqbj.z0hz();
				return true;
			}
			if (p0.z0qek() != null)
			{
				z0ZzZzbdh p1 = z0zek(p0);
				z0yyk().z0eek(p1, p0.z0qek().z0fu());
				return true;
			}
		}
		return false;
	}

	public override void z0ct()
	{
		z0nik();
		if (z0xu())
		{
			return;
		}
		z0bik();
		z0wik();
		z0qxk = null;
		if (z0snk())
		{
			z0yok();
		}
		else
		{
			z0li();
		}
		if (z0abk != null)
		{
			z0abk.Clear();
		}
		z0qzk = false;
		XPageSettings pageSettings = PageSettings;
		try
		{
			XTextContentElement.z0dtk = new XTextElementList();
			z0yxk = true;
			z0eok_jiejie20260327142557.z0eek(this);
			XTextElement[] array = z0be().ToArray();
			XTextDocumentBodyElement xTextDocumentBodyElement = null;
			bool flag = pageSettings.z0rrk();
			XTextElement[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				XTextDocumentContentElement xTextDocumentContentElement = (XTextDocumentContentElement)array2[i];
				if ((!(xTextDocumentContentElement is XTextDocumentHeaderForFirstPageElement) && !(xTextDocumentContentElement is XTextDocumentFooterForFirstPageElement)) || flag)
				{
					if (xTextDocumentContentElement is XTextDocumentBodyElement)
					{
						xTextDocumentBodyElement = (XTextDocumentBodyElement)xTextDocumentContentElement;
					}
					else
					{
						xTextDocumentContentElement.z0ork();
					}
				}
			}
			if (xTextDocumentBodyElement != null)
			{
				z0qxk = z0bmk();
				z0ZzZzzej z0ZzZzzej = pageSettings?.z0dtk();
				if (z0ZzZzzej != null && z0ZzZzzej.z0uek())
				{
					z0ZzZzzej.z0eek(z0bek(pageSettings), GraphicsUnit.Document, 1f);
				}
				xTextDocumentBodyElement.z0ork();
			}
		}
		finally
		{
			z0yxk = false;
			XTextContentElement.z0dtk.z0vrk();
			XTextContentElement.z0dtk = null;
			zzz.z0ZzZzgik<XTextElement[]>.z0iek.z0eek(delegate(XTextElement[] p0)
			{
				Array.Clear(p0, 0, p0.Length);
			});
			zzz.z0ZzZzgik<z0ZzZzzlh[]>.z0iek.z0eek(null);
			z0eok_jiejie20260327142557.z0eek(null);
			z0qzk = true;
		}
		z0aok();
		XTextDocumentHeaderElement xTextDocumentHeaderElement = z0pyk();
		XTextDocumentFooterElement xTextDocumentFooterElement = z0lik();
		float num = xTextDocumentHeaderElement.Height + xTextDocumentFooterElement.Height - pageSettings.z0mrk() * 0.9f;
		if (num > 0f)
		{
			if (xTextDocumentHeaderElement.Height > num)
			{
				xTextDocumentHeaderElement.Height -= num;
			}
			else
			{
				xTextDocumentFooterElement.Height -= num;
			}
		}
	}

	public new z0ZzZzplh z0ryk()
	{
		return z0jrk().z0frk();
	}

	public void z0bek(z0ZzZzvej p0)
	{
		z0xxk = p0;
	}

	internal new bool z0tyk()
	{
		if (z0qtk().Printing)
		{
			return true;
		}
		if (z0cu() != null && (z0cu().z0rj() || z0cu().z0ryk()))
		{
			return true;
		}
		return false;
	}

	public void z0bek(EventArgs p0)
	{
		if (DocumentLoad != null)
		{
			DocumentLoad(this, p0);
		}
	}

	public new z0ZzZzdbj z0yyk()
	{
		return z0xbk_jiejie20260327142557;
	}

	public new int z0uyk()
	{
		int num = 0;
		if (z0wzk != null && z0wzk.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ttk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextImageElement xTextImageElement = (XTextImageElement)z0bpk.Current;
				if (xTextImageElement != null && xTextImageElement.z0irk())
				{
					num++;
				}
			}
		}
		return num;
	}

	public new DetectResultForValueBindingModifiedList z0iyk()
	{
		return z0mpk()?.z0dv(this);
	}

	public new XTextElementList z0oyk()
	{
		return z0nek<XTextFieldElementBase>();
	}

	public new bool z0hrk(bool p0)
	{
		bool flag = false;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ltk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				if (((XTextTableElement)z0bpk.Current).z0nek(p0: false))
				{
					flag = true;
				}
			}
		}
		if (flag && p0)
		{
			if (z0cu() != null)
			{
				z0cu().z0iyk();
			}
			else
			{
				z0oe();
			}
		}
		return flag;
	}

	private void z0bek(XTextDocumentContentElement p0, StringBuilder p1, DCDocumentTextOutputMode p2)
	{
		z0ygj z0ygj = new z0ygj(this);
		z0ygj.z0yek = (p2 & DCDocumentTextOutputMode.IncludeBackgroundText) == DCDocumentTextOutputMode.IncludeBackgroundText;
		z0ygj.z0oek = (p2 & DCDocumentTextOutputMode.IncludeHiddenText) == DCDocumentTextOutputMode.IncludeHiddenText;
		z0ygj.z0uek = (p2 & DCDocumentTextOutputMode.IncludeBorderText) == DCDocumentTextOutputMode.IncludeBorderText;
		z0ygj.z0pek = true;
		p0.z0bw_jiejie20260327142557(z0ygj);
		string text = z0ygj.ToString();
		if (text.Length <= 0)
		{
			return;
		}
		if (p1.Length <= Environment.NewLine.Length)
		{
			p1.Append(text);
			return;
		}
		if (p1.ToString(p1.Length - Environment.NewLine.Length, Environment.NewLine.Length) != Environment.NewLine)
		{
			p1.AppendLine();
		}
		p1.Append(text);
	}

	public new XTextDocumentHeaderElement z0pyk()
	{
		z0fik();
		return (XTextDocumentHeaderElement)z0be()[0];
	}

	public void z0vek(int p0)
	{
		base.z0qtk = p0;
	}

	public int z0myk()
	{
		return z0vvk;
	}

	private new bool z0nyk()
	{
		if (z0azk != null && z0azk.Count > 0)
		{
			foreach (DocumentComment item in z0azk)
			{
				if (item.z0xek() is z0ZzZztlh)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool z0bek(int p0, int p1)
	{
		if (p0 < 0)
		{
			throw new ArgumentException("startContentIndex=" + p0);
		}
		if (p1 < 0)
		{
			throw new ArgumentException("endContentIndex=" + p1);
		}
		if (p1 > p0)
		{
			return z0ryk().z0tek(p0, p1 - p0 + 1);
		}
		return z0ryk().z0tek(p0, p1 - p0 - 1);
	}

	public new z0ZzZzerj z0byk()
	{
		return z0suk();
	}

	public int z0zek(XTextElementList p0)
	{
		if (!z0bu().AutoFixElementIDWhenInsertElements)
		{
			return 0;
		}
		Dictionary<string, string> dictionary = null;
		z0ZzZzkxj z0ZzZzkxj = new z0ZzZzkxj(p0);
		z0ZzZzkxj.ExcludeParagraphFlag = true;
		z0ZzZzkxj.ExcludeCharElement = true;
		int num = 0;
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		foreach (XTextElement item in z0ZzZzkxj)
		{
			if ((!(item is XTextObjectElement) && !(item is XTextContainerElement)) || string.IsNullOrEmpty(item.ID))
			{
				continue;
			}
			if (dictionary == null)
			{
				dictionary = new Dictionary<string, string>();
				z0yek(this, dictionary);
			}
			string iD = item.ID;
			if (!dictionary.ContainsKey(iD))
			{
				continue;
			}
			for (int i = 1; i < 100; i++)
			{
				string text = iD + "_" + i;
				if (!dictionary.ContainsKey(text))
				{
					dictionary2[text] = iD;
					item.ID = text;
					dictionary[text] = null;
					num++;
					break;
				}
			}
		}
		z0ZzZzkxj.Dispose();
		if (dictionary2.Count > 0 && z0rik() != null)
		{
			z0rik().z0qw(p0, dictionary2);
		}
		return num;
	}

	public new int z0vyk()
	{
		return z0uck;
	}

	public new XTextDocumentHeaderForFirstPageElement z0cyk()
	{
		z0fik();
		return (XTextDocumentHeaderForFirstPageElement)z0be()[3];
	}

	public void z0bek(z0ZzZzjpk p0)
	{
		z0bek(p0, p1: false);
	}

	public new XTextDocumentBodyElement z0xyk()
	{
		z0fik();
		return (XTextDocumentBodyElement)z0be()[1];
	}

	public z0ZzZzrfh z0bek(int p0, bool p1)
	{
		return z0bek(p0, p1, 1f, DocumentRenderMode.Bitmap);
	}

	public new bool z0zyk()
	{
		return z0znk;
	}

	public bool z0bek(XTextContainerElement p0, string p1, string p2, bool p3)
	{
		return p0?.z0cek(p1, p2, p3) ?? false;
	}

	public void z0bek(z0ZzZzdbj p0)
	{
		z0xbk_jiejie20260327142557 = p0;
	}

	public object z0srk(string p0)
	{
		return z0gpk().z0rek(p0);
	}

	public void z0ark(string p0)
	{
		z0uxk = p0;
	}

	public new DateTime z0luk()
	{
		return z0ZzZzdbj.z0eek(z0yck);
	}

	private static void z0yek(XTextContainerElement p0, Dictionary<string, string> p1)
	{
		XTextElementList xTextElementList = p0.z0ntk;
		if (xTextElementList == null || xTextElementList.Count <= 0)
		{
			return;
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		for (int num = xTextElementList.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = array[num];
			if (xTextElement is XTextObjectElement || xTextElement is XTextContainerElement)
			{
				if (!string.IsNullOrEmpty(xTextElement.ID))
				{
					p1[xTextElement.ID] = null;
				}
				if (xTextElement is XTextContainerElement)
				{
					z0yek((XTextContainerElement)xTextElement, p1);
				}
			}
		}
	}

	public new bool z0kuk()
	{
		bool result = false;
		foreach (XTextElement item in new z0ZzZzkxj(z0xyk()))
		{
			if (item is XTextTableElement && ((XTextTableElement)item).z0atk())
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public object z0qrk(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		if (z0hmk().z0yek(p0))
		{
			return z0hmk().z0rek(p0);
		}
		if (z0gpk() != null)
		{
			return z0gpk().z0rek(p0);
		}
		return null;
	}

	public new void z0juk()
	{
		if (!z0frk() && !z0xu())
		{
			z0bek(p0: false, p1: true);
			z0opk();
			z0ct();
			z0krk();
			z0bek((z0ZzZzzcj)3);
		}
	}

	public new z0ZzZzbdh z0huk()
	{
		return z0yvk;
	}

	public new XTextDocumentFooterForFirstPageElement z0guk()
	{
		z0fik();
		return (XTextDocumentFooterForFirstPageElement)z0be()[4];
	}

	internal void z0bek(XTextElement p0, string p1)
	{
		if (z0yyk() != null)
		{
			z0yyk().z0ypk().z0tek(p0, p1);
		}
	}

	public void z0bek(TextReader p0, string p1, bool p2)
	{
		try
		{
			z0pok();
			z0bek(null, p0, p1, p2, XTextDocument.z0fmk.z0eek, null);
		}
		finally
		{
			z0smk();
		}
	}

	private new XTextElement z0fuk()
	{
		return null;
	}

	internal z0ZzZzrfh z0bek(bool p0, float p1, DocumentRenderMode p2 = DocumentRenderMode.Paint)
	{
		z0nik();
		z0juk();
		if (z0suk() == null || z0suk().Count == 0)
		{
			return null;
		}
		z0ZzZzwrj z0ZzZzwrj = z0suk()[0].z0zek();
		z0ZzZzwrj.z0eek(new z0ZzZzerj());
		z0ZzZzwrj.z0grk_jiejie20260327142557().Add(z0ZzZzwrj);
		XPageSettings xPageSettings = z0ZzZzwrj.z0trk().z0wtk();
		z0ZzZzwrj.z0eek(xPageSettings);
		xPageSettings.z0eek(PaperKind.Custom);
		if (xPageSettings.z0ork())
		{
			int p3 = xPageSettings.z0ntk();
			xPageSettings.z0oek(xPageSettings.z0jtk());
			xPageSettings.z0rek(p3);
		}
		xPageSettings.z0pek(p0: false);
		XTextDocumentContentElement xTextDocumentContentElement = (PageSettings.z0rrk() ? ((XTextDocumentContentElement)z0cyk()) : ((XTextDocumentContentElement)z0pyk()));
		XTextDocumentContentElement xTextDocumentContentElement2 = (PageSettings.z0rrk() ? ((XTextDocumentContentElement)z0guk()) : ((XTextDocumentContentElement)z0lik()));
		float num = Math.Max(xPageSettings.z0bek(), xPageSettings.z0atk() + xTextDocumentContentElement.Height);
		float num2 = Math.Max(xPageSettings.z0qtk(), xPageSettings.z0stk() + xTextDocumentContentElement2.Height);
		xPageSettings.z0oek(z0xyk().Height + num + num2);
		z0ZzZzwrj.z0yek(z0xyk().Height);
		z0ZzZzocj z0ZzZzocj = new z0ZzZzocj();
		z0ZzZzocj.z0eek(this);
		z0ZzZzocj.z0rek(p0: true);
		z0ZzZzocj.z0eek(p0: true);
		z0ZzZzocj.z0rek(Color.Transparent);
		z0ZzZzxpk z0ZzZzxpk = (z0ZzZzxpk)z0ZzZzxcj.z0eek(p0: false, 0);
		if (!z0ZzZzxpk.z0yek)
		{
			z0ZzZzocj.z0eek(z0ZzZzxpk);
		}
		else
		{
			z0ZzZzocj.z0eek((z0ZzZzxpk)null);
		}
		if (z0yyk() != null)
		{
			z0ZzZzocj.z0eek(z0yyk().z0kyk());
		}
		else
		{
			z0ZzZzocj.z0eek(Color.White);
		}
		z0ZzZzocj.z0eek(z0suk());
		switch (p2)
		{
		case DocumentRenderMode.PDF:
			z0ZzZzocj.z0eek((z0ZzZzxej)4);
			break;
		case DocumentRenderMode.Bitmap:
			z0ZzZzocj.z0eek((z0ZzZzxej)3);
			break;
		case DocumentRenderMode.Print:
			z0ZzZzocj.z0eek((z0ZzZzxej)1);
			break;
		default:
			z0ZzZzocj.z0eek((z0ZzZzxej)0);
			break;
		}
		z0ZzZzocj.z0rek(p1);
		z0ZzZzocj.z0eek(p1);
		z0ZzZzocj.z0eek(z0iu().PageMarginLineLength);
		z0ZzZzmcj z0ZzZzmcj = z0qtk();
		try
		{
			z0ZzZzmcj.GenerateLongBmp = true;
			z0ZzZzmcj.GenerateBmp = true;
			return z0ZzZzocj.z0eek(z0ZzZzwrj, p0);
		}
		finally
		{
			z0ZzZzmcj.GenerateLongBmp = false;
			z0ZzZzmcj.GenerateBmp = false;
		}
	}

	internal void z0bek(object p0, string p1, bool p2, string p3)
	{
		z0vek(p0, p1, p2, p3, null);
	}

	public new string z0grk(bool p0)
	{
		z0ZzZzphh z0ZzZzphh = null;
		if (z0xmk() != null)
		{
			z0ZzZzphh = z0ZzZznhh.z0eek().z0eek(z0ZzZzkfh.z0nek);
		}
		if (z0ZzZzphh == null)
		{
			z0ZzZzphh = z0ZzZznhh.z0eek().z0eek("rtf");
		}
		z0ZzZzohh z0ZzZzohh = new z0ZzZzohh();
		z0ZzZzohh.IncludeSelectionOnly = p0;
		StringWriter stringWriter = new StringWriter();
		XTextDocument xTextDocument = this;
		bool cloneSerialize = z0vtk().BehaviorOptions.CloneSerialize;
		if (cloneSerialize)
		{
			xTextDocument = (XTextDocument)z0lr(p0: true);
		}
		xTextDocument.z0tu(z0ZzZzkfh.z0nek);
		z0ZzZzphh.z0vd(stringWriter, xTextDocument, z0ZzZzohh);
		xTextDocument.z0xik();
		if (cloneSerialize)
		{
			xTextDocument.Dispose();
		}
		return stringWriter.ToString();
	}

	public new void z0duk()
	{
		z0xbk_jiejie20260327142557?.z0oj();
		z0we();
		z0cik();
		if (z0pxk != null)
		{
			z0pxk.Clear();
			z0pxk = null;
		}
		z0vnk = false;
		z0aok();
		z0hok();
		z0uzk = null;
		z0wxk = null;
		if (z0azk != null)
		{
			z0azk.z0yek();
			z0azk = null;
		}
		if (z0bvk != null)
		{
			z0bvk.z0zp();
		}
		z0zzk = null;
		z0qck = null;
		z0vbk = null;
		z0lyk();
		if (z0be() != null)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				((XTextDocumentContentElement)z0bpk.Current).z0qrk();
			}
		}
		z0dlj = new z0ZzZzmcj();
		z0lxk = 0f;
		z0cvk = 0f;
		z0jck = null;
		z0vzk = null;
		z0xek(-1);
		if (z0lck != null)
		{
			z0lck.z0sp();
		}
		z0xxk = null;
		if (z0ibk != null)
		{
			z0ibk.z0tek();
		}
		if (z0mxk != null)
		{
			z0mxk.Clear();
		}
		if (z0lzk != null)
		{
			z0lzk.Clear();
		}
		base.z0mrk();
		if (z0gck != null)
		{
			z0gck.Clear();
		}
		z0exk = null;
		z0alj = null;
		z0bek(DocumentContentSourceTypes.Unknown);
		z0bek(MeasureMode.Default);
		z0nvk = null;
		z0vbk = null;
		z0bek(new DocumentInfo());
		if (z0klj != null)
		{
			z0klj.Clear();
		}
		if (z0obk != null)
		{
			z0obk.Clear();
		}
		z0lnk();
		((XTextElement)this).z0prk();
		if (z0nzk != null)
		{
			z0nzk.Clear();
			z0nzk.Default.FontSize = XTextDocument.z0bpk();
		}
		z0vbk = null;
		if (base.z0ntk != null)
		{
			XTextElementList xTextElementList = new XTextElementList();
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)base.z0ntk);
			base.z0ntk.Clear();
			z0ZzZzkxj z0ZzZzkxj = new z0ZzZzkxj(xTextElementList);
			z0ZzZzkxj.ExcludeParagraphFlag = true;
			z0ZzZzkxj.ExcludeCharElement = true;
			foreach (XTextElement item in z0ZzZzkxj)
			{
				((IDisposable)item)?.Dispose();
			}
			z0ZzZzkxj.Dispose();
		}
		z0exk = null;
		z0lvk = 0;
		if (!z0nxk && !z0snk())
		{
			z0fck = new object();
			try
			{
				XTextDocumentBodyElement xTextDocumentBodyElement = z0xyk();
				xTextDocumentBodyElement.z0gu();
				xTextDocumentBodyElement.z0bek(p0: true);
				xTextDocumentBodyElement.z0irk();
				XTextDocumentHeaderElement xTextDocumentHeaderElement = z0pyk();
				xTextDocumentHeaderElement.z0gu();
				xTextDocumentHeaderElement.z0bek(p0: true);
				xTextDocumentHeaderElement.z0irk();
				XTextDocumentFooterElement xTextDocumentFooterElement = z0lik();
				xTextDocumentFooterElement.z0gu();
				xTextDocumentFooterElement.z0bek(p0: true);
				xTextDocumentFooterElement.z0irk();
				z0li();
			}
			finally
			{
				z0fck = null;
			}
		}
	}

	public void z0bek(byte[] p0, string p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("bs");
		}
		byte[] array = z0ZzZzmuk.z0rek(p0);
		if (array != null && array.Length != 0)
		{
			MemoryStream p2 = new MemoryStream(array);
			z0bek(p2, p1);
		}
	}

	public void z0bek(DocumentContentStyleContainer p0)
	{
		z0nzk = p0;
		if (z0nzk != null)
		{
			z0nzk.z0eek(this);
		}
	}

	[CompilerGenerated]
	internal static void z0bek(XTextContentElement p0, z0vjj p1)
	{
		if (XTextSectionElement.z0mek && (((XTextElement)p0).z0krk() || (p0 is XTextSectionElement && ((XTextSectionElement)p0).z0rek())))
		{
			return;
		}
		p0.z0au(p1.z0rek);
		if (!p1.z0tek || !(p0 is XTextTableCellElement xTextTableCellElement))
		{
			return;
		}
		xTextTableCellElement.Width = 0f;
		xTextTableCellElement.Height = 0f;
		XTextElement xTextElement = xTextTableCellElement.z0ji();
		if (xTextElement != null && xTextElement != p1.z0eek)
		{
			p1.z0eek = xTextElement;
			if (xTextElement is XTextTableElement)
			{
				((XTextTableElement)xTextElement).z0jyk = true;
			}
		}
	}

	private z0ZzZzphh z0bek(object p0, string p1)
	{
		z0ZzZzphh z0ZzZzphh = z0ZzZznhh.z0eek().z0eek(p1);
		if (p0 is z0ZzZzcah)
		{
			return z0ZzZzphh;
		}
		if (z0ZzZzphh != null)
		{
			if (p0 is string || p0 is Stream)
			{
				if ((z0ZzZzphh.z0bd() & (z0ZzZzmhh)1) != (z0ZzZzmhh)1)
				{
					z0ZzZzphh = null;
				}
			}
			else if (p0 is TextReader)
			{
				if ((z0ZzZzphh.z0bd() & (z0ZzZzmhh)4) != (z0ZzZzmhh)4)
				{
					z0ZzZzphh = null;
				}
			}
			else
			{
				z0ZzZzphh = null;
			}
		}
		if (z0ZzZzphh == null)
		{
			throw new NotSupportedException(p1.ToString());
		}
		return z0ZzZzphh;
	}

	public z0ZzZzerj z0suk()
	{
		if (z0abk == null)
		{
			z0abk = new z0ZzZzerj();
		}
		return z0abk;
	}

	private void z0auk()
	{
		int num = ((z0syk() != null) ? z0syk().Count : 0);
		using zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = z0gnk().Styles.z0ltk();
		while (z0bpk.MoveNext())
		{
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0bpk.Current;
			if (documentContentStyle.CreatorIndex >= 0 && documentContentStyle.CreatorIndex >= num)
			{
				documentContentStyle.CreatorIndex = num - 1;
			}
			if (documentContentStyle.DeleterIndex >= 0 && documentContentStyle.DeleterIndex >= num)
			{
				documentContentStyle.DeleterIndex = num - 1;
			}
		}
	}

	public void z0bek(MeasureMode p0)
	{
		if (z0mvk != p0)
		{
			z0mvk = p0;
		}
	}

	internal void z0bek(z0ZzZzpkh p0)
	{
		z0ubk = p0;
	}

	internal void z0quk()
	{
	}

	public XTextDocumentContentElement z0bek(PageContentPartyStyle p0)
	{
		return p0 switch
		{
			PageContentPartyStyle.Header => z0pyk(), 
			PageContentPartyStyle.Footer => z0lik(), 
			PageContentPartyStyle.HeaderForFirstPage => z0cyk(), 
			PageContentPartyStyle.FooterForFirstPage => z0guk(), 
			PageContentPartyStyle.Body => z0xyk(), 
			_ => z0xyk(), 
		};
	}

	public bool z0bek(JumpPrintInfo p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("info");
		}
		if (p0.Mode != JumpPrintMode.Normal)
		{
			return false;
		}
		bool result = false;
		if (p0.Position > 0f && p0.PageIndex < 0)
		{
			JumpPrintInfo jumpPrintInfo = z0drk(p0.Position);
			p0.PageIndex = jumpPrintInfo.PageIndex;
			p0.Position = jumpPrintInfo.Position;
			result = true;
		}
		if (p0.EndPosition > 0f && p0.EndPageIndex < 0)
		{
			JumpPrintInfo jumpPrintInfo2 = z0drk(p0.EndPosition);
			p0.EndPageIndex = jumpPrintInfo2.PageIndex;
			p0.EndPosition = jumpPrintInfo2.Position;
			result = true;
		}
		if (p0.z0tek() is XTextElement xTextElement && xTextElement.z0qek() == z0xyk())
		{
			float num = z0bek(xTextElement, p0.StartPositionMode == JumpPrintPositionMode.ElementTop);
			if (num > 0f)
			{
				JumpPrintInfo jumpPrintInfo3 = z0drk(num);
				if (jumpPrintInfo3 != null)
				{
					p0.z0eek(num);
					p0.PageIndex = jumpPrintInfo3.PageIndex;
					p0.Position = jumpPrintInfo3.Position;
					result = true;
				}
			}
		}
		if (p0.z0rek() is XTextElement xTextElement2 && xTextElement2.z0qek() == z0xyk())
		{
			float num2 = z0bek(xTextElement2, p0.EndPositionMode == JumpPrintPositionMode.ElementTop);
			if (num2 > 0f)
			{
				JumpPrintInfo jumpPrintInfo4 = z0drk(num2);
				if (jumpPrintInfo4 != null)
				{
					p0.z0rek(num2);
					p0.EndPageIndex = jumpPrintInfo4.PageIndex;
					p0.EndPosition = jumpPrintInfo4.Position;
					result = true;
				}
			}
		}
		return result;
	}

	public void z0wrk(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			z0rpk();
			return;
		}
		z0ZzZzphh z0ZzZzphh = null;
		if (z0xmk() != null)
		{
			z0ZzZzphh = z0ZzZznhh.z0eek().z0eek(z0ZzZzkfh.z0uek);
		}
		if (z0ZzZzphh == null)
		{
			z0ZzZzphh = new z0ZzZzwgh();
		}
		int num = p0.IndexOf('<');
		if (num > 0)
		{
			p0 = p0.Substring(num);
		}
		StringReader p1 = new StringReader(p0);
		z0bek(p1, z0ZzZzkfh.z0uek);
	}

	public string z0wuk()
	{
		return null;
	}

	internal new void z0euk()
	{
		if (z0lck != null)
		{
			z0lck.z0sp();
		}
		if (z0dck != null)
		{
			z0dck.z0tek();
		}
	}

	public void OnDocumentContentChanged()
	{
		if (z0xu())
		{
			return;
		}
		if (z0yyk() != null)
		{
			z0yyk().z0iek(p0: true);
		}
		z0puk();
		z0czk = null;
		if (z0puk())
		{
			if (z0yyk() != null)
			{
				z0yyk().z0tek(EventArgs.Empty);
				z0pnk();
			}
			if (DocumentContentChanged != null)
			{
				DocumentContentChanged(this, EventArgs.Empty);
			}
		}
	}

	public new int z0ruk()
	{
		int num = 0;
		XTextElementList xTextElementList = z0nek<XTextInputFieldElementBase>();
		if (xTextElementList.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)z0bpk.Current;
				if (xTextInputFieldElementBase.z0eo(p0: false))
				{
					num++;
					xTextInputFieldElementBase.z0jo();
					if (z0htk() != null)
					{
						z0htk().z0co(xTextInputFieldElementBase);
					}
				}
			}
		}
		if (num > 0 && z0yyk() != null)
		{
			z0yyk().z0grk(p0: false);
			base.z0uyk().z0hz();
		}
		return num;
	}

	public bool z0bek(XTextElement p0, XTextElement p1, DocumentComment p2)
	{
		if (p2 == null)
		{
			throw new ArgumentNullException("cmd");
		}
		z0ZzZzplh z0ZzZzplh = z0xyk().z0frk();
		int num = z0ZzZzplh.z0bek(p0);
		int num2 = z0ZzZzplh.z0bek(p1);
		if (num >= 0 && num2 < 0)
		{
			num2 = num;
		}
		else if (num < 0 && num2 >= 0)
		{
			num = num2;
		}
		else if (num < 0 && num2 < 0)
		{
			return false;
		}
		if (num > num2)
		{
			int num3 = num;
			num = num2;
			num2 = num3;
		}
		p2.z0tek(this);
		p2.z0otk = true;
		p2.z0eek(z0ZzZzplh[num]);
		p2.z0eek(z0ZzZzplh.z0mek(num, num2 - num + 1));
		if (z0azk == null)
		{
			z0azk = new z0ZzZzwcj();
		}
		z0azk.Add(p2);
		if (string.IsNullOrEmpty(p2.z0grk()))
		{
			p2.z0nek(z0ZzZziok.z0lyk());
		}
		return true;
	}

	public static string z0erk(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			p0 = p0.Trim();
			if (p0.StartsWith("http", StringComparison.OrdinalIgnoreCase))
			{
				string text = new Uri(p0).Host;
				if (text != null)
				{
					if (text.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
					{
						text = text.Substring(4);
					}
					z0fxk = text;
					return text;
				}
			}
		}
		return null;
	}

	public new string z0tuk()
	{
		return z0uxk;
	}

	public Hashtable z0yuk()
	{
		return z0mpk()?.z0kv(this);
	}

	internal void z0uuk()
	{
		if (z0itk() != null)
		{
			DocumentEventArgs e = new DocumentEventArgs(z0jr(), z0itk(), DocumentEventStyles.LostFocusExt);
			e.Cursor = null;
			z0bek(z0itk(), e);
		}
	}

	public int z0iuk()
	{
		return z0qrk();
	}

	public void z0bek(XTextElementList p0, bool p1, bool p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elements");
		}
		if (p0.Count == 0)
		{
			return;
		}
		if (p0.LastElement is XTextParagraphFlagElement)
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)p0.LastElement;
			if (xTextParagraphFlagElement.z0vek() && ((XTextElement)xTextParagraphFlagElement).z0pek() < 0)
			{
				p0.RemoveAt(p0.Count - 1);
			}
		}
		if (p0.Count == 0)
		{
			return;
		}
		if (!p1 && !p2)
		{
			z0ZzZzafh.z0uek(p0);
		}
		if (p0.Count == 0)
		{
			return;
		}
		XTextCheckBoxElementBase.z0eek(p0);
		Dictionary<int, DocumentContentStyle> dictionary = new Dictionary<int, DocumentContentStyle>();
		XTextDocument xTextDocument = p0[0].z0jr();
		if (xTextDocument == null)
		{
			xTextDocument = this;
		}
		else
		{
			xTextDocument.z0uyk();
		}
		z0ubk = null;
		z0ZzZzkxj z0ZzZzkxj = new z0ZzZzkxj(p0);
		z0ZzZzkxj.ExcludeCharElement = false;
		z0ZzZzkxj.ExcludeParagraphFlag = false;
		if (xTextDocument != this)
		{
			List<DocumentComment> list = new List<DocumentComment>();
			z0ZzZzuhh z0ZzZzuhh = new z0ZzZzuhh();
			xTextDocument.z0syk().z0rek();
			z0ZzZzwcj z0ZzZzwcj = xTextDocument.Comments;
			if (z0ZzZzwcj != null && z0ZzZzwcj.Count == 0)
			{
				z0ZzZzwcj = null;
			}
			z0ZzZzuhh z0ZzZzuhh2 = xTextDocument.z0syk();
			if (z0ZzZzuhh2 != null && z0ZzZzuhh2.Count == 0)
			{
				z0ZzZzuhh2 = null;
			}
			foreach (XTextElement item in z0ZzZzkxj)
			{
				if (!(item is XTextCharElement) && !(item is XTextParagraphFlagElement))
				{
					z0srk(item);
				}
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)xTextDocument.z0gnk().GetStyle(item.z0pek());
				dictionary[item.z0buk] = documentContentStyle;
				if (z0ZzZzwcj != null)
				{
					DocumentComment documentComment = z0ZzZzwcj.z0eek(documentContentStyle.CommentIndex);
					if (documentComment != null && !list.Contains(documentComment))
					{
						list.Add(documentComment);
					}
				}
				if (!p1 || z0ZzZzuhh2 == null)
				{
					continue;
				}
				z0ZzZzyhh z0ZzZzyhh = z0ZzZzuhh2.z0tek(documentContentStyle.CreatorIndex);
				if (z0ZzZzyhh != null)
				{
					if (!z0ZzZzuhh.Contains(z0ZzZzyhh))
					{
						z0ZzZzuhh.Add(z0ZzZzyhh);
					}
				}
				else
				{
					documentContentStyle.CreatorIndex = -1;
				}
				z0ZzZzyhh = z0ZzZzuhh2.z0tek(documentContentStyle.DeleterIndex);
				if (z0ZzZzyhh != null)
				{
					if (!z0ZzZzuhh.Contains(z0ZzZzyhh))
					{
						z0ZzZzuhh.Add(z0ZzZzyhh);
					}
				}
				else
				{
					documentContentStyle.DeleterIndex = -1;
				}
			}
			z0ZzZzuhh.z0pek();
			bool flag = false;
			int count = z0syk().Count;
			z0ZzZzkxj z0ZzZzkxj2 = new z0ZzZzkxj(this);
			z0ZzZzkxj2.ExcludeCharElement = false;
			z0ZzZzkxj2.ExcludeParagraphFlag = false;
			foreach (XTextElement item2 in z0ZzZzkxj2)
			{
				z0ZzZzrzj z0ZzZzrzj = item2.z0jyk();
				if (z0ZzZzrzj.z0nrk == count - 1)
				{
					flag = true;
					break;
				}
				if (z0ZzZzrzj.z0jyk == count - 1)
				{
					flag = true;
					break;
				}
			}
			z0ZzZzkxj2.Dispose();
			int num = count - 1;
			if (flag)
			{
				num = count;
			}
			if (num < 0)
			{
				num = 0;
			}
			Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
			for (int i = 0; i < z0ZzZzuhh.Count; i++)
			{
				dictionary2[z0ZzZzuhh[i].z0pek()] = i + num;
			}
			int num2 = Comments.z0tek() + 1;
			using (z0ZzZzjpk p3 = z0ru())
			{
				foreach (DocumentContentStyle value in dictionary.Values)
				{
					DocumentContentStyle documentContentStyle2 = (DocumentContentStyle)value.Clone();
					if (p1)
					{
						if (documentContentStyle2.CreatorIndex != -1 && dictionary2.ContainsKey(documentContentStyle2.CreatorIndex))
						{
							documentContentStyle2.CreatorIndex = dictionary2[documentContentStyle2.CreatorIndex];
						}
						if (documentContentStyle2.DeleterIndex != -1 && dictionary2.ContainsKey(documentContentStyle2.DeleterIndex))
						{
							documentContentStyle2.DeleterIndex = dictionary2[documentContentStyle2.DeleterIndex];
						}
					}
					else if (p2)
					{
						if (dictionary2.ContainsKey(documentContentStyle2.CreatorIndex))
						{
							documentContentStyle2.CreatorIndex = dictionary2[documentContentStyle2.CreatorIndex];
						}
						documentContentStyle2.DeleterIndex = -1;
					}
					else
					{
						documentContentStyle2.CreatorIndex = -1;
						documentContentStyle2.DeleterIndex = -1;
					}
					if (num2 > 0 && documentContentStyle2.CommentIndex != -1)
					{
						documentContentStyle2.CommentIndex += num2;
					}
					int styleIndex = (value.Index = z0gnk().GetStyleIndex(documentContentStyle2));
					((DocumentContentStyle)z0gnk().GetStyle(styleIndex)).z0eek_jiejie20260327142557(p3);
				}
			}
			foreach (DocumentComment item3 in list)
			{
				DocumentComment documentComment2 = item3.z0yek();
				documentComment2.z0eek(documentComment2.z0tek() + num2);
				Comments.Add(documentComment2);
			}
			if (p1)
			{
				z0ZzZzyhh z0ZzZzyhh2 = z0syk().z0eek();
				if (z0ZzZzyhh2 != null && !flag)
				{
					z0syk().Remove(z0ZzZzyhh2);
				}
				foreach (z0ZzZzyhh item4 in z0ZzZzuhh)
				{
					z0syk().Add(item4.z0lrk());
				}
				if (z0ZzZzyhh2 != null && !flag)
				{
					z0syk().Add(z0ZzZzyhh2);
				}
				z0syk().z0rek();
			}
			z0lvk = 0;
			foreach (XTextElement item5 in z0ZzZzkxj)
			{
				if (dictionary.ContainsKey(item5.z0pek()))
				{
					item5.z0oek(dictionary[item5.z0pek()].Index);
				}
				item5.z0yek(this);
			}
		}
		z0ZzZzkxj.Dispose();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current3 = z0bpk.Current;
				current3.z0yek(this);
				current3.z0xi(p0: true);
				current3.z0li();
			}
		}
		z0bek(p0);
		ElementLoadEventArgs e = new ElementLoadEventArgs(this, z0ZzZzkfh.z0uek);
		e.z0rek = true;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current4 = z0bpk.Current;
			if (current4 is XTextCharElement || current4 is XTextParagraphFlagElement)
			{
				current4.z0ftk();
				continue;
			}
			e.Element = current4;
			current4.z0rt(e);
		}
	}

	private z0ZzZzwxj z0ouk()
	{
		return null;
	}

	public new void z0cek(object p0)
	{
		z0avk = p0;
	}

	internal void z0bek(XTextTableRowElement p0, float p1)
	{
		if (z0nck != null)
		{
			z0nck[p0] = p1;
		}
	}

	public bool z0puk()
	{
		if (!z0vtk().BehaviorOptions.EnableContentChangedEventWhenLoadDocument && z0snk())
		{
			return false;
		}
		return true;
	}

	public void z0rrk(string p0)
	{
		z0ozk = p0;
	}

	public new z0ZzZzyhh z0muk()
	{
		return z0syk().z0eek();
	}

	public bool z0nuk()
	{
		if (z0xrk())
		{
			return false;
		}
		if (!z0bu().EnableLogUndo)
		{
			return false;
		}
		if (z0xu())
		{
			return false;
		}
		if (z0klj != null && z0klj.z0po())
		{
			if (base.z0uyk() != null)
			{
				base.z0uyk().z0xek("Undo");
				base.z0uyk().z0xek("Redo");
			}
			return true;
		}
		return false;
	}

	private XTextElementList z0bek(string p0, object p1, string p2, bool p3, z0fmk p4, XTextDocument p5)
	{
		z0cxk = false;
		z0vik();
		z0nik();
		new BeforeLoadDocumentEventArgs(p0, p1, p2, p5);
		z0vnk = false;
		z0qck = null;
		z0bek((z0ZzZzzcj)1);
		if (p5 != null)
		{
			z0xxk = null;
		}
		bool debugMode = z0vtk().BehaviorOptions.DebugMode;
		if (debugMode)
		{
			z0ZzZzqok.z0rek.z0sh(string.Format(z0ZzZziok.z0gtk(), p3 ? ("Fast " + p1.ToString()) : p1.ToString(), p2 ?? "xml"));
		}
		z0ZzZzphh z0ZzZzphh = z0bek(p1, p2);
		z0ZzZzohh p6 = new z0ZzZzohh
		{
			EnableDocumentSetting = true,
			WriterControl = z0yyk(),
			BasePath = z0uok(),
			FileName = z0amk(),
			FastMode = p3
		};
		XTextDocument xTextDocument = p5;
		if (xTextDocument == null)
		{
			xTextDocument = this;
		}
		xTextDocument.z0lxk = 0f;
		xTextDocument.z0cvk = 0f;
		xTextDocument.z0xxk = null;
		if (p4 == XTextDocument.z0fmk.z0rek || p4 == XTextDocument.z0fmk.z0tek)
		{
			xTextDocument = (XTextDocument)z0lr(p0: false);
		}
		else
		{
			p5?.z0bek(this, p1: false);
		}
		xTextDocument.z0yck = z0ZzZzuyk.z0eek();
		if (p1 is TextReader)
		{
			xTextDocument.z0tpk();
			z0ZzZzphh.z0xd((TextReader)p1, xTextDocument, p6);
			z0bek(DocumentContentSourceTypes.TextReader);
		}
		else if (p1 is z0ZzZzcah && z0ZzZzphh is z0ZzZzwgh)
		{
			z0ZzZzwgh obj = (z0ZzZzwgh)z0ZzZzphh;
			xTextDocument.z0tpk();
			obj.z0eek((z0ZzZzcah)p1, xTextDocument, p6);
			z0bek(DocumentContentSourceTypes.TextReader);
		}
		else if (p1 is Stream)
		{
			xTextDocument.z0tpk();
			z0ZzZzphh.z0zd((Stream)p1, xTextDocument, p6);
			z0bek(DocumentContentSourceTypes.Stream);
		}
		if (xTextDocument.z0bvk != null)
		{
			xTextDocument.z0bvk.z0jm();
		}
		xTextDocument.z0txk = null;
		z0yck = z0ZzZzuyk.z0eek();
		xTextDocument.z0yck = z0yck;
		xTextDocument.z0ozk = z0ZzZzphh.z0js();
		xTextDocument.z0auk();
		new WriterEventArgs(z0yyk(), xTextDocument, xTextDocument);
		if (!p3)
		{
			if (p1 is string)
			{
				xTextDocument.z0cek((string)p1);
			}
			ElementLoadEventArgs p7 = new ElementLoadEventArgs(xTextDocument, p2);
			xTextDocument.z0rt(p7);
			xTextDocument.Modified = false;
			if (xTextDocument.z0imk() != null)
			{
				xTextDocument.z0imk().Clear();
			}
		}
		if (debugMode)
		{
			z0ZzZzqok.z0rek.z0sh("Document loaded:" + xTextDocument.z0ipk().z0mek());
			z0ZzZzqok.z0rek.z0sh("File name      :" + xTextDocument.z0amk());
			z0ZzZzqok.z0rek.z0sh("Creation time  :" + z0ZzZzuyk.z0rek(xTextDocument.z0ipk().z0nrk()));
			z0ZzZzqok.z0rek.z0sh("Description    :" + xTextDocument.z0ipk().z0mrk());
		}
		base.z0qtk++;
		z0ozk = z0ZzZzphh.z0js();
		XTextElementList xTextElementList = xTextDocument.z0xyk().z0be();
		XTextCheckBoxElementBase.z0eek(xTextElementList);
		if (p4 == XTextDocument.z0fmk.z0rek || p4 == XTextDocument.z0fmk.z0tek)
		{
			xTextElementList = xTextDocument.z0xyk().z0be();
			z0cek(xTextElementList);
			if (p4 == XTextDocument.z0fmk.z0tek)
			{
				((zzz.z0ZzZzkuk<XTextElement>)z0xyk().z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList);
				z0xyk().z0li();
				z0xyk().z0bek(p0: false);
				if (!p3)
				{
					ElementLoadEventArgs p8 = new ElementLoadEventArgs(xTextDocument, p2);
					z0rt(p8);
					Modified = false;
					if (z0imk() != null)
					{
						z0imk().Clear();
					}
				}
			}
		}
		return xTextElementList;
	}

	public new int z0buk()
	{
		if (z0lvk == 0)
		{
			if (z0gck != null)
			{
				foreach (DocumentComment item in z0gck)
				{
					z0lvk = Math.Max(item.z0tek(), z0lvk);
				}
			}
			using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = z0gnk().Styles.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0bpk.Current;
					z0lvk = Math.Max(documentContentStyle.CommentIndex, z0lvk);
				}
			}
			z0lvk++;
		}
		return z0lvk++;
	}

	private void z0bek(XTextContainerElement p0, ElementLoadEventArgs p1, z0ZzZzqbj p2)
	{
	}

	public void z0bek(z0ZzZzkvj p0)
	{
		z0lzk = p0;
	}

	public string z0vuk()
	{
		return z0mpk()?.z0vb(this);
	}

	public new z0ZzZzhkh z0cuk()
	{
		return z0jrk().z0oek();
	}

	public new string z0xuk()
	{
		if (z0szk && !z0vtk().BehaviorOptions.SaveBodyTextToXml)
		{
			return null;
		}
		foreach (XTextElement item in z0be().z0xrk())
		{
			if (item is XTextDocumentBodyElement)
			{
				return item.Text;
			}
		}
		return string.Empty;
	}

	private new XTextContainerElement z0zuk()
	{
		return null;
	}

	public void z0bek(z0ZzZzogh p0)
	{
		if (z0klj != null && !z0xrk())
		{
			z0klj.Add(p0);
		}
	}

	public XTextParagraphFlagElement z0jrk(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (p0 is XTextParagraphFlagElement)
		{
			return (XTextParagraphFlagElement)p0;
		}
		XTextContentElement xTextContentElement = p0.z0jy();
		if (p0 is XTextSectionElement)
		{
			xTextContentElement = (XTextContentElement)p0.z0ji();
		}
		if (xTextContentElement != null)
		{
			int num = 0;
			XTextElementList xTextElementList = xTextContentElement.z0trk();
			if (p0 is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)p0;
				num = ((xTextFieldElementBase.z0jrk() == null) ? xTextElementList.IndexOf(p0) : xTextElementList.IndexOf(xTextFieldElementBase.z0jrk()));
			}
			else
			{
				num = xTextElementList.IndexOf(p0);
			}
			if (num < 0)
			{
				return xTextElementList.LastElement as XTextParagraphFlagElement;
			}
			for (; num < xTextElementList.Count; num++)
			{
				if (xTextElementList[num] is XTextParagraphFlagElement)
				{
					return (XTextParagraphFlagElement)xTextElementList[num];
				}
			}
		}
		return null;
	}

	public override void z0mu(DocumentEventArgs p0)
	{
		if (z0xrk())
		{
			return;
		}
		z0fck = null;
		z0bik();
		if (p0.Style == DocumentEventStyles.MouseClick)
		{
			z0kbk = null;
			z0bzk = -2147483648;
		}
		if (p0.Style == DocumentEventStyles.MouseDown)
		{
			if (p0.Button == (z0ZzZzqeh)1)
			{
				z0kbk = z0cuk();
				z0bzk = z0cuk().z0qrk();
			}
			if (base.z0uyk() != null)
			{
				((z0ZzZzqrj)base.z0uyk()).z0yek(p0: true);
			}
			XTextElement xTextElement = z0bek(p0.X, p0.Y, p2: true);
			if (xTextElement != null)
			{
				z0bek(xTextElement, p0);
				if (p0.Cursor == null)
				{
					p0.Cursor = xTextElement.z0hrk();
					if (p0.Cursor == null && (xTextElement.z0qek()?.z0oek()).z0rek(xTextElement))
					{
						p0.Cursor = z0ZzZzdbj.z0juk();
					}
				}
			}
		}
		else if (p0.Style == DocumentEventStyles.MouseMove)
		{
			if (p0.Button == (z0ZzZzqeh)0)
			{
				z0sbk = null;
			}
			if (z0sbk != null)
			{
				z0sbk.z0eek(p0.X);
				z0sbk.z0rek(p0.Y);
				z0sbk.z0eek(p0: true);
				z0ryk().z0uek(p0: false);
				z0ryk().z0tek((float)p0.X, (float)p0.Y);
				z0ryk().z0uek(p0: true);
				((z0ZzZzxnj)base.z0uyk()).z0tek(p0: false);
				z0yyk().z0vik();
				((z0ZzZzxnj)base.z0uyk()).z0tek(p0: true);
			}
			else if (p0.Button == (z0ZzZzqeh)0)
			{
				XTextElement xTextElement2 = (p0.StrictMatch ? z0bek(p0.X, p0.Y, p2: true) : null);
				if (xTextElement2 != z0czk)
				{
					XTextElementList xTextElementList = ((z0etk() == null) ? new XTextElementList() : z0ZzZzafh.z0iek(z0etk()));
					if (z0etk() != null)
					{
						xTextElementList.Insert(0, z0etk());
					}
					XTextElementList xTextElementList2 = ((xTextElement2 == null) ? new XTextElementList() : z0ZzZzafh.z0iek(xTextElement2));
					if (xTextElement2 != null)
					{
						xTextElementList2.Insert(0, xTextElement2);
					}
					else
					{
						xTextElementList2.Add(this);
					}
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextElement current = z0bpk.Current;
							if (!xTextElementList2.Contains(current))
							{
								DocumentEventArgs e = p0.z0eek();
								e.z0qrk = DocumentEventStyles.MouseLeave;
								e.Element = current;
								current.z0mu(e);
								if (e.Handled)
								{
									break;
								}
								continue;
							}
							break;
						}
					}
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextElement current2 = z0bpk.Current;
						if (!xTextElementList.Contains(current2))
						{
							DocumentEventArgs e2 = p0.z0eek();
							e2.z0qrk = DocumentEventStyles.MouseEnter;
							e2.Element = current2;
							current2.z0mu(e2);
							if (e2.Handled)
							{
								break;
							}
							continue;
						}
						break;
					}
				}
				if (xTextElement2 != z0czk)
				{
					XTextElement p1 = z0czk;
					z0hrk(xTextElement2);
					z0bek(p1, xTextElement2);
				}
				if (xTextElement2 == null)
				{
					xTextElement2 = z0bek(p0.X, p0.Y, p2: true);
				}
				if (xTextElement2 != null)
				{
					z0bek(xTextElement2, p0);
					if (p0.Cursor == null)
					{
						p0.Cursor = xTextElement2.z0hrk();
						if (p0.Cursor == null && (xTextElement2.z0qek()?.z0oek()).z0rek(xTextElement2))
						{
							p0.Cursor = z0ZzZzdbj.z0juk();
						}
					}
				}
			}
		}
		else if (p0.Style == DocumentEventStyles.MouseUp || p0.Style == DocumentEventStyles.MouseClick || p0.Style == DocumentEventStyles.MouseDblClick)
		{
			((z0ZzZzqrj)base.z0uyk()).z0yek(p0: false);
			if (z0sbk == null || !z0sbk.z0eek())
			{
				XTextElement xTextElement3 = z0bek(p0.X, p0.Y, p2: true);
				if (xTextElement3 != null)
				{
					z0bek(xTextElement3, p0);
					if (p0.Style == DocumentEventStyles.MouseClick)
					{
						z0kbk = null;
						z0bzk = -2147483648;
					}
					if (p0.Cursor == null)
					{
						p0.Cursor = xTextElement3.z0hrk();
					}
					if (xTextElement3 is XTextObjectElement)
					{
						z0cu().z0xj((XTextObjectElement)xTextElement3, p0);
					}
				}
			}
			z0sbk = null;
		}
		else if (p0.Style == DocumentEventStyles.MouseLeave)
		{
			if (z0etk() != null)
			{
				XTextElement p2 = z0etk();
				z0bek(z0etk(), p0);
				z0hrk((XTextElement)null);
				z0bek(p2, (XTextElement)null);
			}
		}
		else if (p0.Style == DocumentEventStyles.KeyDown)
		{
			XTextElement xTextElement4 = null;
			if (Math.Abs(z0cuk().z0qrk()) == 1)
			{
				xTextElement4 = z0cuk().z0grk()[0];
			}
			else
			{
				XTextContainerElement p3 = null;
				int p4 = 0;
				z0ryk().z0tek(out p3, out p4);
				xTextElement4 = p3;
			}
			z0bek(xTextElement4, p0);
		}
		else if (p0.Style == DocumentEventStyles.KeyPress)
		{
			XTextElement xTextElement5 = null;
			if (Math.Abs(z0cuk().z0qrk()) == 1)
			{
				xTextElement5 = z0cuk().z0grk()[0];
			}
			else
			{
				XTextContainerElement p5 = null;
				int p6 = 0;
				z0ryk().z0tek(out p5, out p6);
				xTextElement5 = p5;
			}
			z0bek(xTextElement5, p0);
		}
		else
		{
			base.z0mu(p0);
		}
		z0aok();
	}

	public XTextDocumentFooterElement z0lik()
	{
		z0fik();
		return (XTextDocumentFooterElement)z0be()[2];
	}

	public XTextElementList z0bek(string p0, DocumentContentStyle p1, DocumentContentStyle p2)
	{
		return z0bek(p0, p1, p2, z0hi().EnablePermission);
	}

	public new XTextDocument z0kik()
	{
		XTextDocument xTextDocument = (XTextDocument)z0lr(p0: false);
		xTextDocument.z0bek((DocumentContentStyleContainer)((z0ZzZzxok)z0gnk()).z0eek());
		xTextDocument.z0te(new XTextElementList());
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextDocumentBodyElement)
				{
					XTextElement element = current.z0lr(p0: false);
					xTextDocument.z0be().Add(element);
				}
				else
				{
					XTextElement element2 = current.z0lr(p0: true);
					xTextDocument.z0be().Add(element2);
				}
			}
		}
		xTextDocument.z0li();
		return xTextDocument;
	}

	private void z0bek(object p0, string p1, bool p2, string p3, Encoding p4)
	{
		z0nik();
		if (p0 == null)
		{
			throw new ArgumentNullException("output");
		}
		z0ZzZzphh z0ZzZzphh = z0ZzZznhh.z0eek().z0eek(p1);
		_ = z0ZzZzphh is z0ZzZzwgh;
		if (z0ZzZzphh != null)
		{
			if (p0 is string || p0 is Stream)
			{
				if ((z0ZzZzphh.z0bd() & (z0ZzZzmhh)2) != (z0ZzZzmhh)2)
				{
					z0ZzZzphh = null;
					throw new NotSupportedException(string.Format(z0ZzZziok.z0rok(), p1));
				}
			}
			else if (p0 is TextWriter)
			{
				if ((z0ZzZzphh.z0bd() & (z0ZzZzmhh)8) != (z0ZzZzmhh)8)
				{
					z0ZzZzphh = null;
					throw new NotSupportedException(string.Format(z0ZzZziok.z0lik(), p1));
				}
			}
			else
			{
				z0ZzZzphh = null;
			}
		}
		if (z0ZzZzphh == null)
		{
			throw new NotSupportedException(string.Format(z0ZzZziok.z0zrk(), p1));
		}
		if (string.IsNullOrEmpty(p1))
		{
			p1 = z0ZzZzphh.z0js();
		}
		z0ZzZzohh z0ZzZzohh = z0sxk;
		z0sxk = null;
		if (z0ZzZzohh == null)
		{
			z0ZzZzohh = new z0ZzZzohh();
		}
		if (string.IsNullOrEmpty(p3))
		{
			z0ZzZzohh.BasePath = z0uok();
			z0ZzZzohh.FileName = z0amk();
		}
		else
		{
			z0ZzZzohh.BasePath = z0ZzZzpik.z0eek(p3);
			z0ZzZzohh.FileName = p3;
		}
		z0ZzZzohh.EnableDocumentSetting = true;
		z0ZzZzohh.IncludeSelectionOnly = false;
		z0ZzZzohh.SerializeAttachFiles = true;
		z0ZzZzohh.FastMode = false;
		z0ZzZzohh.Formated = z0vtk().BehaviorOptions.OutputFormatedXMLSource;
		if (p4 != null)
		{
			z0ZzZzohh.ContentEncoding = p4;
		}
		string text = z0bck;
		DateTime[] array = null;
		if (z0obk != null && z0obk.Count > 0)
		{
			DateTime p5 = z0jpk();
			array = new DateTime[z0obk.Count];
			for (int num = array.Length - 1; num >= 0; num--)
			{
				z0ZzZzyhh z0ZzZzyhh = z0obk[num];
				if (z0ZzZzyhh != null)
				{
					array[num] = z0ZzZzyhh.z0xek();
					if (z0ZzZzyhh.z0eek())
					{
						z0ZzZzyhh.z0tek(p5);
					}
				}
			}
		}
		try
		{
			z0bck = null;
			if (z0ZzZzphh.z0sq(this))
			{
				z0tu(p1);
			}
			if (z0ZzZzphh.z0hs(this))
			{
				z0juk();
			}
			z0szk = true;
			if (!(p0 is string))
			{
				if (p0 is Stream)
				{
					z0ZzZzphh.z0cd((Stream)p0, this, z0ZzZzohh);
				}
				else if (p0 is TextWriter)
				{
					TextWriter textWriter = (TextWriter)p0;
					if (textWriter is StreamWriter)
					{
						StreamWriter streamWriter = (StreamWriter)textWriter;
						z0ZzZzohh.ContentEncoding = streamWriter.Encoding;
					}
					z0ZzZzphh.z0vd(textWriter, this, z0ZzZzohh);
				}
			}
			if (z0ZzZzphh.z0fq(this))
			{
				z0xik();
			}
		}
		finally
		{
			z0szk = false;
			z0bck = text;
			if (array != null && z0obk != null && z0obk.Count == array.Length)
			{
				for (int num2 = array.Length - 1; num2 >= 0; num2--)
				{
					if (z0obk[num2] != null)
					{
						z0obk[num2].z0tek(array[num2]);
					}
				}
			}
		}
		if (!p2)
		{
			Modified = false;
			z0rtk();
		}
	}

	public z0ZzZzvej z0jik()
	{
		return z0xxk;
	}

	public XTextElementList z0hik()
	{
		return z0xyk().z0nek<XTextSubDocumentElement>();
	}

	public XTextElementList z0trk(string p0)
	{
		return z0mok().z0eek(p0, typeof(XTextRadioBoxElement));
	}

	public z0ZzZzwcj z0gik()
	{
		if (z0azk == null || z0azk.Count == 0)
		{
			return z0gck;
		}
		if (z0gck == null || z0gck.Count == 0)
		{
			return z0azk;
		}
		z0ZzZzwcj z0ZzZzwcj = new z0ZzZzwcj();
		if (z0azk != null && z0azk.Count > 0)
		{
			z0ZzZzwcj.AddRange(z0azk);
		}
		if (z0gck != null && z0gck.Count > 0)
		{
			z0ZzZzwcj.AddRange(z0gck);
		}
		return z0ZzZzwcj;
	}

	private new void z0fik()
	{
		XTextElementList xTextElementList = z0be();
		if (xTextElementList.Count == 5 && xTextElementList.z0yek(0) is XTextDocumentHeaderElement && xTextElementList.z0yek(1) is XTextDocumentBodyElement && xTextElementList.z0yek(2) is XTextDocumentFooterElement && xTextElementList.z0yek(3) is XTextDocumentHeaderForFirstPageElement && xTextElementList.z0yek(4) is XTextDocumentFooterForFirstPageElement)
		{
			return;
		}
		if (xTextElementList.Count == 0)
		{
			xTextElementList.Capacity = 5;
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)new XTextDocumentHeaderElement());
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)new XTextDocumentBodyElement());
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)new XTextDocumentFooterElement());
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)new XTextDocumentHeaderForFirstPageElement());
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)new XTextDocumentFooterForFirstPageElement());
			foreach (XTextElement item in xTextElementList.z0xrk())
			{
				item.z0yek(this, this);
			}
			z0we();
			return;
		}
		XTextDocumentHeaderForFirstPageElement xTextDocumentHeaderForFirstPageElement = xTextElementList.z0srk<XTextDocumentHeaderForFirstPageElement>();
		if (xTextDocumentHeaderForFirstPageElement == null)
		{
			xTextDocumentHeaderForFirstPageElement = new XTextDocumentHeaderForFirstPageElement();
			xTextDocumentHeaderForFirstPageElement.z0yek(this, this);
		}
		XTextDocumentFooterForFirstPageElement xTextDocumentFooterForFirstPageElement = xTextElementList.z0srk<XTextDocumentFooterForFirstPageElement>();
		if (xTextDocumentFooterForFirstPageElement == null)
		{
			xTextDocumentFooterForFirstPageElement = new XTextDocumentFooterForFirstPageElement();
			xTextDocumentHeaderForFirstPageElement.z0yek(this, this);
		}
		XTextDocumentHeaderElement xTextDocumentHeaderElement = xTextElementList.z0srk<XTextDocumentHeaderElement>();
		if (xTextDocumentHeaderElement == null)
		{
			xTextDocumentHeaderElement = new XTextDocumentHeaderElement();
			xTextDocumentHeaderElement.z0yek(this, this);
		}
		XTextDocumentFooterElement xTextDocumentFooterElement = xTextElementList.z0srk<XTextDocumentFooterElement>();
		if (xTextDocumentFooterElement == null)
		{
			xTextDocumentFooterElement = new XTextDocumentFooterElement();
			xTextDocumentFooterElement.z0yek(this, this);
		}
		XTextDocumentBodyElement xTextDocumentBodyElement = xTextElementList.z0srk<XTextDocumentBodyElement>();
		if (xTextDocumentBodyElement == null)
		{
			xTextDocumentBodyElement = new XTextDocumentBodyElement();
			xTextDocumentBodyElement.z0yek(this, this);
		}
		foreach (XTextElement item2 in xTextElementList.z0xrk())
		{
			if (!(item2 is XTextDocumentContentElement))
			{
				xTextDocumentBodyElement.z0be().Add(item2);
			}
		}
		xTextElementList.z0zek(new XTextElement[5] { xTextDocumentHeaderElement, xTextDocumentBodyElement, xTextDocumentFooterElement, xTextDocumentHeaderForFirstPageElement, xTextDocumentFooterForFirstPageElement });
		z0we();
	}

	public void z0bek(float[] p0)
	{
		z0alj = p0;
	}

	public DocumentContentStyle z0dik()
	{
		return (DocumentContentStyle)z0gnk().Default;
	}

	public new XTextElementList z0sik()
	{
		return z0cck;
	}

	public new static int z0aik()
	{
		return z0ick;
	}

	internal void z0vek(object p0, string p1, bool p2, string p3, Encoding p4)
	{
		z0aok();
		bool flag = false;
		if (z0cok())
		{
			flag = true;
			z0vek(p0: false);
		}
		z0nik();
		if (string.Compare(p1, "xml", true) == 0)
		{
			z0yik();
		}
		_ = z0vtk().BehaviorOptions;
		if (!p2)
		{
			z0jrk(p0: true);
		}
		if (string.Compare(p1, "pdf", true) != 0 && string.Compare(p1, "ofd", true) != 0 && string.Compare(p1, "json", true) != 0)
		{
			z0xbk_jiejie20260327142557 = z0xbk_jiejie20260327142557;
			z0bek(p0, p1, p2, p3, p4);
			if (!p2)
			{
				Modified = false;
				z0rtk();
			}
			z0sxk = null;
			if (this != this)
			{
				Dispose();
			}
			else if (flag || z0cok())
			{
				z0vek(p0: true);
				if (z0cu() != null)
				{
					z0cu().z0fpk();
				}
			}
			return;
		}
		z0bek(p0, p1, p2, p3, p4);
		if (flag || z0cok())
		{
			z0vek(p0: true);
			if (z0cu() != null)
			{
				z0cu().z0fpk();
			}
		}
	}

	public void z0bek(z0ZzZzwrj p0)
	{
		z0nvk = p0;
	}

	public int z0yrk(string p0)
	{
		return z0mpk().z0qv(this, p0);
	}

	public void z0bek(Stream p0, string p1)
	{
		z0bek(p0, p1, p2: false);
	}

	public static void z0lrk(float p0)
	{
		z0fbk = p0;
	}

	public string z0qik()
	{
		return z0wrk(p0: false);
	}

	public new void z0wik()
	{
		z0vvk++;
	}

	private int z0eik()
	{
		return 0;
	}

	public override string z0ge()
	{
		return "Document:" + z0zrk();
	}

	public float z0krk(float p0)
	{
		return z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, GraphicsUnit.Pixel);
	}

	internal new z0ZzZzpkh z0rik()
	{
		if (z0ubk == null)
		{
			z0ubk = z0ZzZzuok.z0eek<z0ZzZzpkh>();
		}
		z0ubk.z0ow(this);
		return z0ubk;
	}

	internal void z0tik()
	{
		try
		{
			z0ZzZzwok z0ZzZzwok = new z0ZzZzwok(new int[4] { -1225129973, -1869045870, 1733649804, 726233211 });
			z0ZzZzpck z0ZzZzpck = (z0ZzZzpck)z0dnk();
			if (z0ZzZzpck != null && z0ZzZzpck.z0zek)
			{
				z0ZzZzdik.z0eek(z0ipk(), z0ZzZzwok.z0tek(), z0ZzZzafh.z0yek(z0ZzZzpck.z0drk) + ":" + z0ZzZzpck.z0ytk?.z0tek(), p3: false);
				return;
			}
			z0ZzZzwok z0ZzZzwok2 = new z0ZzZzwok(new int[6] { 718012436, 1663657041, 1481979769, -1430682711, -1347240516, -1548895319 });
			z0ZzZzdik.z0eek(z0ipk(), z0ZzZzwok.z0tek(), z0ZzZzwok2.z0tek(), p3: false);
		}
		catch (Exception ex)
		{
			z0ipk().z0nek(ex.Message);
		}
	}

	public void z0yik()
	{
	}

	public new void z0cek(int p0)
	{
	}

	public new bool z0uik()
	{
		if (z0xrk())
		{
			return false;
		}
		if (z0dtk() != (z0ZzZzzcj)3)
		{
			return false;
		}
		if (!z0bu().EnableLogUndo)
		{
			return false;
		}
		if (z0klj != null)
		{
			return z0klj.z0iek();
		}
		return false;
	}

	public float z0iik()
	{
		return z0lxk;
	}

	public override DocumentEditOptions z0pu_jiejie20260327142557()
	{
		if (z0jlj == null)
		{
			return z0vtk().EditOptions;
		}
		return z0jlj;
	}

	public PageContentPartyStyle z0oik()
	{
		if (z0exk == null || z0exk is XTextDocumentBodyElement)
		{
			return PageContentPartyStyle.Body;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0jrk();
		if (xTextDocumentContentElement is XTextDocumentBodyElement)
		{
			return PageContentPartyStyle.Body;
		}
		if (xTextDocumentContentElement is XTextDocumentHeaderElement)
		{
			return PageContentPartyStyle.Header;
		}
		if (xTextDocumentContentElement is XTextDocumentFooterElement)
		{
			return PageContentPartyStyle.Footer;
		}
		if (xTextDocumentContentElement is XTextDocumentHeaderForFirstPageElement)
		{
			return PageContentPartyStyle.HeaderForFirstPage;
		}
		if (xTextDocumentContentElement is XTextDocumentFooterForFirstPageElement)
		{
			return PageContentPartyStyle.FooterForFirstPage;
		}
		return PageContentPartyStyle.Body;
	}

	public void z0vek(bool p0, bool p1)
	{
		z0bek(p0, p1, null);
	}

	public XTextElementList z0pik()
	{
		XTextElementList xTextElementList = new XTextElementList();
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0xyk().z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			if (current is XTextSectionElement)
			{
				xTextElementList.Add(current);
			}
		}
		return xTextElementList;
	}

	internal z0ZzZzlvj z0mik()
	{
		if (z0oxk == null)
		{
			z0oxk = new z0ZzZzlvj();
		}
		return z0oxk;
	}

	public void z0nik()
	{
		if (z0nxk)
		{
			throw new ObjectDisposedException("dcwriter.document");
		}
	}

	public XTextTableCellElement z0vek(string p0, int p1, int p2)
	{
		XTextTableElement xTextTableElement = null;
		XTextElement xTextElement = z0xyk().z0dtk();
		return ((!(xTextElement is XTextTableElement) || !(xTextElement.ID == p0)) ? (z0ki(p0) as XTextTableElement) : ((XTextTableElement)xTextElement))?.z0nek(p1, p2, p2: false);
	}

	public override void z0oe()
	{
		if (!z0xu())
		{
			if (z0yyk() != null)
			{
				z0yyk().z0eek(p0: true, p1: true);
				return;
			}
			z0krk(p0: false);
			z0juk();
		}
	}

	public void z0bek(DocumentContentStyle p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("newStyle");
		}
		if (p1 && z0ytk())
		{
			z0bek(new z0ZzZzdlh(this, "DefaultStyle", z0dik().Clone(), p0));
			z0nuk();
		}
		z0gnk().Default = p0;
		Modified = true;
		if (z0yyk() != null)
		{
			z0yyk().z0iyk();
		}
	}

	public XTextElement z0bek(XTextElement p0, Type p1, bool p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("startElement");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("nextElementType");
		}
		XTextElement result = null;
		bool flag = false;
		z0ZzZzkxj z0ZzZzkxj = new z0ZzZzkxj(p0.z0qek());
		foreach (XTextElement item in z0ZzZzkxj)
		{
			if (!p2 && !item.z0yi())
			{
				z0ZzZzkxj.CancelChild();
			}
			else if (flag)
			{
				if (p1.IsInstanceOfType(item))
				{
					result = item;
					break;
				}
			}
			else if (item == p0)
			{
				flag = true;
			}
		}
		z0ZzZzkxj.Dispose();
		return result;
	}

	public void z0bik()
	{
		z0pck = z0vtk();
		z0hck = z0pck.BehaviorOptions;
		z0jlj = z0pck.EditOptions;
		z0vck = z0pck.SecurityOptions;
		z0ybk = z0pck.ViewOptions;
	}

	public void z0vik()
	{
		z0gbk = true;
	}

	internal void z0cik()
	{
		if (z0kzk == null)
		{
			return;
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0kzk.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				current.z0fr();
				current.Dispose();
			}
		}
		z0kzk.Clear();
		z0kzk = null;
	}

	public new void z0xik()
	{
		z0li();
	}

	public int z0zik()
	{
		if (z0npk() == null || z0yrk() == null)
		{
			return 0;
		}
		return Math.Max(0, z0yrk().IndexOf(z0npk()));
	}

	private new void z0frk(bool p0)
	{
		throw new NotSupportedException("EditorDelete");
	}

	public string z0bek(string p0, bool p1, bool p2, bool p3, bool p4)
	{
		return z0gyk().z0ukk(this, p0, p1, p2, p3, p4);
	}

	internal new void z0lok()
	{
		z0hlj++;
	}

	public new ET z0uek<ET>() where ET : XTextElement, new()
	{
		ET val = new ET();
		val.z0bt(this);
		return val;
	}

	public void z0bek(z0ZzZzvlh p0)
	{
		z0uvk = p0;
	}

	public void z0lrk(XTextElementList p0)
	{
		z0qck = null;
	}

	internal static object z0bek(object p0, int p1)
	{
		z0ZzZzxpk z0ZzZzxpk = (z0ZzZzxpk)z0ZzZzxcj.z0eek(p0: false, p1);
		if (p0 != null)
		{
			string text = ((z0ZzZzqbj)p0).z0vik;
			if (text != null && text.Length > 0)
			{
				z0ZzZzxpk.z0rek = new z0ZzZzwok(text);
			}
			else
			{
				z0ZzZzxpk.z0rek = null;
			}
		}
		if (!z0ZzZzxpk.z0iek)
		{
			z0ZzZzxpk.z0tek = z0ZzZzspk.z0eek(p0);
		}
		if (string.IsNullOrEmpty(z0ZzZzxpk.z0eek()))
		{
			return null;
		}
		return z0ZzZzxpk;
	}

	public int z0vek(XTextElementList p0, bool p1)
	{
		z0ZzZzzxj z0ZzZzzxj = new z0ZzZzzxj();
		z0ZzZzzxj.z0eek(p0);
		z0ZzZzzxj.z0tek(p1);
		return z0bek(z0ZzZzzxj);
	}

	public bool z0bek(string p0, string p1, string p2)
	{
		return z0ki(p0)?.z0dr(p1, p2) ?? false;
	}

	public XTextElementList z0bek(string p0, int p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		XTextElementList xTextElementList = new XTextElementList();
		int length = p0.Length;
		for (int i = 0; i < length; i++)
		{
			char p2 = p0[i];
			XTextCharElement xTextCharElement = z0bek(p2, p1);
			if (xTextCharElement != null)
			{
				xTextElementList.Add(xTextCharElement);
				if (XTextCharElement.z0tek((int)p2) && i < length - 1)
				{
					xTextCharElement.z0rek((ushort)p0[++i]);
				}
			}
		}
		return xTextElementList;
	}

	public static XTextDocument z0kok()
	{
		return new XTextDocument(2);
	}

	private z0ZzZzylh z0jok()
	{
		z0ZzZzylh z0ZzZzylh = z0mpk()?.z0av(this, p1: true);
		bool num = z0azk != null && z0azk.Count > 0;
		z0azk = new z0ZzZzwcj();
		z0bek(z0ZzZzylh, z0azk);
		bool flag = z0azk != null && z0azk.Count > 0;
		if ((num || flag) && z0cu() != null && z0ank() != null)
		{
			z0ank().Refreshview();
			z0cu().z0zx(p0: true);
			base.z0uyk().z0hz();
			z0cu().z0puk_jiejie20260327142557();
		}
		return z0ZzZzylh;
	}

	private void z0hok()
	{
		if (z0cbk != null)
		{
			z0cbk.Clear();
			z0cbk = null;
		}
	}

	public void z0hrk(XTextElement p0)
	{
		z0czk = p0;
		if (z0htk() != null)
		{
			z0htk().z0xo(null);
		}
	}

	public void z0cek(XTextElementList p0, bool p1)
	{
		z0bek(p0, p1, z0hi().EnablePermission);
	}

	public XTextElementList z0bek(string p0, DocumentContentStyle p1, DocumentContentStyle p2, bool p3)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return new XTextElementList();
		}
		bool flag = false;
		string text = p0;
		foreach (char c in text)
		{
			if (c == '\r' || c == '\n')
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			if (p1 != null)
			{
				p1 = (DocumentContentStyle)p1.CloneEnableDefaultValue();
			}
		}
		else
		{
			p1 = null;
		}
		if (p2 != null)
		{
			p2 = (DocumentContentStyle)p2.CloneEnableDefaultValue();
		}
		XTextElementList xTextElementList = new XTextElementList(p0.Length);
		if (p3)
		{
			if (p2 != null)
			{
				p2.CreatorIndex = z0syk().z0yek();
			}
			else
			{
				p2 = new DocumentContentStyle();
				p2.CreatorIndex = z0syk().z0yek();
			}
			if (p1 != null)
			{
				p1.CreatorIndex = z0syk().z0yek();
			}
			else
			{
				p1 = new DocumentContentStyle();
				p1.CreatorIndex = z0syk().z0yek();
			}
		}
		else
		{
			if (p2 != null && p2.CreatorIndex >= 0)
			{
				p2.z0rek();
			}
			if (p1 != null && p1.CreatorIndex >= 0)
			{
				p1.z0rek();
			}
		}
		if (p2 != null)
		{
			z0ZzZzvik.z0eek((z0ZzZzvik)p2, (z0ZzZzvik)null);
			z0ZzZzvik.z0eek(p2, z0gnk().Default);
		}
		if (p1 != null)
		{
			z0ZzZzvik.z0eek((z0ZzZzvik)p1, (z0ZzZzvik)null);
			z0ZzZzvik.z0eek(p1, z0gnk().Default);
		}
		int styleIndex = z0gnk().GetStyleIndex(p2);
		int styleIndex2 = z0gnk().GetStyleIndex(p1);
		if (p0.Contains('\n') && !p0.Contains('\r'))
		{
			p0 = p0.Replace('\n', '\r');
		}
		z0ZzZzjpk z0ZzZzjpk = null;
		if (!z0xu() && !z0snk())
		{
			z0ZzZzjpk = z0ru();
		}
		z0ZzZzvxj z0ZzZzvxj = null;
		if (z0ZzZzjpk != null)
		{
			z0ZzZzvxj = z0bek(z0ZzZzjpk, (z0ZzZzcxj)0);
		}
		try
		{
			bool parseCrLfAsLineBreakElement = z0bu().ParseCrLfAsLineBreakElement;
			p0 = p0.Replace("\r\n", "\r", StringComparison.OrdinalIgnoreCase).Replace('\n', '\r');
			int length = p0.Length;
			for (int j = 0; j < length; j++)
			{
				char c2 = p0[j];
				switch (c2)
				{
				case '\r':
				{
					if (parseCrLfAsLineBreakElement)
					{
						XTextLineBreakElement xTextLineBreakElement = new XTextLineBreakElement();
						xTextLineBreakElement.z0iek(this);
						if (z0ZzZzvxj != null)
						{
							xTextLineBreakElement.z0mr(z0ZzZzvxj);
						}
						xTextElementList.Add(xTextLineBreakElement);
						break;
					}
					XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
					xTextParagraphFlagElement.z0yek(this);
					xTextParagraphFlagElement.z0yek((XTextContainerElement)this);
					xTextParagraphFlagElement.z0oek(styleIndex2);
					if (z0ZzZzvxj != null)
					{
						xTextParagraphFlagElement.z0mr(z0ZzZzvxj);
					}
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)xTextParagraphFlagElement);
					break;
				}
				default:
				{
					XTextCharElement xTextCharElement = new XTextCharElement(c2, styleIndex);
					if (XTextCharElement.z0tek((int)c2) && j < length - 1)
					{
						xTextCharElement.z0rek((ushort)p0[++j]);
					}
					xTextCharElement.z0yek(this);
					xTextCharElement.z0yek((XTextContainerElement)this);
					if (z0ZzZzvxj != null)
					{
						xTextCharElement.z0mr(z0ZzZzvxj);
					}
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)xTextCharElement);
					break;
				}
				case '\n':
					break;
				}
			}
			return xTextElementList;
		}
		finally
		{
			z0ZzZzjpk?.Dispose();
		}
	}

	public XTextElement z0bek(Type p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (!typeof(XTextElement).IsAssignableFrom(p0))
		{
			throw new ArgumentException(p0.FullName);
		}
		if (z0itk() == null)
		{
			return null;
		}
		if (p1 && p0.IsInstanceOfType(z0itk()))
		{
			return z0itk();
		}
		XTextContainerElement p2 = null;
		if (z0itk() is XTextFieldBorderElement)
		{
			p2 = z0itk().z0ji();
		}
		else if (z0ryk() != null)
		{
			int p3 = 0;
			z0ryk().z0tek(out p2, out p3);
		}
		while (p2 != null)
		{
			if (p0.IsInstanceOfType(p2))
			{
				return p2;
			}
			p2 = p2.z0ji();
		}
		return null;
	}

	public string z0gok()
	{
		return z0grk(p0: false);
	}

	internal new void z0fok()
	{
		if (z0nck == null)
		{
			return;
		}
		Dictionary<XTextTableRowElement, float> dictionary = z0nck;
		z0nck = null;
		if (dictionary.Count <= 0 || z0cu() == null)
		{
			return;
		}
		foreach (KeyValuePair<XTextTableRowElement, float> item in dictionary)
		{
			WriterTableRowHeightChangedEventArgs p = new WriterTableRowHeightChangedEventArgs(z0cu(), this, item.Key, item.Value, item.Key.Height);
			z0cu().z0eek(p);
		}
		dictionary.Clear();
	}

	public new void z0xek(int p0)
	{
		z0rck = p0;
	}

	public string z0urk(string p0)
	{
		return z0mpk()?.z0jv(this, p0);
	}

	public XTextSectionElement z0dok()
	{
		return (XTextSectionElement)z0bek(typeof(XTextSectionElement), p1: true);
	}

	internal z0ZzZzlfh z0sok()
	{
		if (z0dxk != null)
		{
			return z0dxk;
		}
		if (base.z0uyk() != null)
		{
			return z0yyk().z0ntk();
		}
		return z0ZzZzlfh.z0uek();
	}

	public void z0aok()
	{
		z0pck = null;
		z0hck = null;
		z0jlj = null;
		z0vck = null;
		z0ybk = null;
	}

	internal XTextElement z0qok()
	{
		if (z0itk() == null)
		{
			return null;
		}
		XTextElement xTextElement = z0itk();
		XTextContentElement xTextContentElement = xTextElement.z0jy();
		if (z0jrk().z0oek().z0qrk() == 0)
		{
			XTextElement xTextElement2 = xTextContentElement.z0trk().z0pek(xTextElement);
			if (xTextElement is XTextParagraphFlagElement && xTextElement2 is XTextParagraphFlagElement)
			{
				return xTextElement;
			}
			if (xTextElement2 != null && !(xTextElement2 is XTextParagraphFlagElement) && !(xTextElement2 is XTextTableElement))
			{
				if (xTextElement2.z0ji() is XTextFieldElementBase)
				{
					if (((XTextFieldElementBase)xTextElement2.z0ji()).z0tek() == xTextElement2 && xTextElement is XTextParagraphFlagElement)
					{
						return xTextElement2;
					}
				}
				else
				{
					xTextElement = xTextElement2;
				}
			}
			return xTextElement;
		}
		return z0jrk().z0oek().z0grk()[0];
	}

	public int z0wok()
	{
		return z0ixk;
	}

	public void z0bek(RepeatedImageValueList p0)
	{
		z0wzk = p0;
	}

	public bool ClearTextHighlight()
	{
		bool result = false;
		if (z0cbk != null)
		{
			if (z0cbk.Count > 0)
			{
				z0jo();
				z0cbk.Clear();
				result = true;
			}
			z0cbk = null;
		}
		return result;
	}

	public new void z0drk(bool p0)
	{
		z0znk = p0;
	}

	public bool z0eok()
	{
		if (z0cuk().z0qrk() == 0)
		{
			XTextElement xTextElement = z0itk();
			if (xTextElement == null)
			{
				return false;
			}
			XTextSectionElement xTextSectionElement = xTextElement.z0iek();
			if (xTextSectionElement != null && xTextSectionElement.z0trk().IndexOf(xTextElement) == 0)
			{
				XTextContentElement xTextContentElement = xTextSectionElement.z0ji().z0jy();
				if (xTextContentElement.z0trk().IndexOf(xTextSectionElement) == 0)
				{
					return true;
				}
				XTextElement xTextElement2 = xTextContentElement.z0trk().z0pek(xTextSectionElement);
				if (xTextElement2 is XTextTableElement || xTextElement2 is XTextSectionElement)
				{
					return true;
				}
			}
		}
		return false;
	}

	[JSInvokable]
	public SearchStringResultList SetTextHighlight(string text, bool ignoreCase, Color foreColor, Color backColor, bool supportPrint, bool supportPDF)
	{
		if (string.IsNullOrEmpty(text))
		{
			throw new ArgumentNullException("text");
		}
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			throw new NullReferenceException("this.OwnerDocument");
		}
		SearchStringResultList searchStringResultList = SearchString(text, ignoreCase);
		if (searchStringResultList != null && searchStringResultList.Count > 0)
		{
			foreach (SearchStringResult item in searchStringResultList)
			{
				XTextElementList xTextElementList = item.ContainerElement.z0be();
				int num = xTextElementList.IndexOf(item.FirstElement);
				if (num >= 0)
				{
					for (int i = 0; i < item.ElementsLength; i++)
					{
						xTextDocument.SetCharElementHighlight((XTextCharElement)xTextElementList[num + i], foreColor, backColor, supportPrint, supportPDF);
					}
				}
			}
			xTextDocument.z0jo();
		}
		return searchStringResultList;
	}

	internal bool z0rok()
	{
		return z0tzk;
	}

	public void z0grk(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (z0snk())
		{
			return;
		}
		if (z0uzk == null)
		{
			z0uzk = p0;
			z0nbk = 1;
			return;
		}
		z0nbk++;
		if (z0uzk != p0 && !p0.z0zu(z0uzk))
		{
			z0uzk = z0ZzZzafh.z0iek(p0, z0uzk);
		}
	}

	public string z0tok()
	{
		if (z0ipk() == null)
		{
			return null;
		}
		return z0ipk().z0mek();
	}

	public void z0yok()
	{
		if (z0gbk)
		{
			z0li();
		}
	}

	private void z0vek(XTextElementList p0, int[] p1)
	{
		int num = p1.Length;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0).z0krk();
		for (int num2 = p0.Count - 1; num2 >= 0; num2--)
		{
			XTextElement xTextElement = array[num2];
			int num3 = xTextElement.z0buk;
			if (num3 >= 0 && num3 < num)
			{
				p1[num3]++;
			}
			if (xTextElement is XTextContainerElement)
			{
				XTextElementList xTextElementList = ((XTextContainerElement)xTextElement).z0ntk;
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					z0vek(xTextElementList, p1);
				}
			}
		}
	}

	public bool z0vek(string p0, string p1, string p2)
	{
		return z0ki(p0)?.z0dr(p1, p2) ?? false;
	}

	public string z0uok()
	{
		return z0mbk;
	}

	internal XTextTableElement z0iok()
	{
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = base.z0ntk.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				if (z0bpk.Current is XTextDocumentBodyElement xTextDocumentBodyElement)
				{
					XTextElementList xTextElementList = xTextDocumentBodyElement.z0be();
					if (xTextElementList != null)
					{
						_ = xTextElementList.Count;
						_ = 100;
					}
					if (xTextDocumentBodyElement.z0be().Count == 1 && xTextDocumentBodyElement.z0be()[0] is XTextTableElement result)
					{
						return result;
					}
				}
			}
		}
		return null;
	}

	public new void z0srk(bool p0)
	{
		z0yzk = p0;
	}

	public void z0irk(string p0)
	{
		z0kvk = p0;
	}

	public void z0bek(z0ZzZzimk p0)
	{
		z0dik().Font = p0;
	}

	public XTextElementList z0ook()
	{
		return z0nek<XTextInputFieldElement>();
	}

	internal void z0pok()
	{
		z0ezk++;
	}

	public void z0bek(Stream p0, string p1, bool p2)
	{
		try
		{
			z0pok();
			z0bek(null, p0, p1, p2, XTextDocument.z0fmk.z0eek, null);
		}
		finally
		{
			z0smk();
		}
	}

	public string z0bek(string p0, Type p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (string.IsNullOrEmpty(p0))
		{
			p0 = "e";
		}
		XTextElementList xTextElementList = z0me(p1);
		int num = xTextElementList.Count + 1;
		string text;
		bool flag;
		do
		{
			text = p0 + num;
			flag = false;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				if (string.Compare(z0bpk.Current.ID, text, true) == 0)
				{
					flag = true;
					num++;
					break;
				}
			}
		}
		while (flag);
		return text;
	}

	public bool z0frk(XTextElement p0)
	{
		XTextElementList xTextElementList = new XTextElementList();
		xTextElementList.Add(p0);
		return z0vek(xTextElementList, p1: true) > 0;
	}

	public bool z0drk(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (z0etk() == null)
		{
			return false;
		}
		for (XTextElement xTextElement = XTextCheckBoxElementBase.z0eek(z0etk()); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement == p0)
			{
				return true;
			}
		}
		return false;
	}

	internal void z0bek(z0ZzZzlfh p0)
	{
		z0dxk = p0;
	}

	public z0ZzZzkcj z0mok()
	{
		if (z0jck == null || z0jck.z0tek() != this)
		{
			z0jck = new z0ZzZzkcj(this);
		}
		return z0jck;
	}

	[JSInvokable]
	public SearchStringResultList SearchString(string text, bool ignoreCase = false, int maxResultCount = 0)
	{
		if (string.IsNullOrEmpty(text))
		{
			throw new ArgumentNullException("text");
		}
		z0li();
		if (((XTextContainerElement)this).z0crk())
		{
			z0ZzZzxxj z0ZzZzxxj = new z0ZzZzxxj(z0jr(), text, ignoreCase, maxResultCount);
			if (this != null)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk();
				while (z0bpk.MoveNext())
				{
					((XTextDocumentContentElement)z0bpk.Current).z0frk().z0tek(z0ZzZzxxj);
				}
			}
			else
			{
				z0qpk().z0frk().z0tek(z0ZzZzxxj);
			}
			if (z0ZzZzxxj.z0rek != null && z0ZzZzxxj.z0rek.Count > 0)
			{
				return z0ZzZzxxj.z0rek;
			}
		}
		return null;
	}

	internal void z0nok()
	{
		z0nck = new Dictionary<XTextTableRowElement, float>();
	}

	private DocumentContentStyle z0bok()
	{
		return null;
	}

	public int z0vok()
	{
		return z0rck;
	}

	public bool z0cok()
	{
		return z0yzk;
	}

	public void z0bek(DocumentOptions p0)
	{
		if (z0qvk != p0)
		{
			z0qvk = p0;
			z0aok();
		}
	}

	public override string ToString()
	{
		return "Document:" + z0ipk().z0mek();
	}

	public void z0bek(z0ZzZzdcj p0)
	{
		if (p0 == null && z0jvk)
		{
			z0jvk = false;
		}
		else
		{
			z0vbk = p0;
		}
	}

	public static bool z0xok()
	{
		return ((z0ZzZzpck)z0dnk()).z0wrk;
	}

	public float z0jrk(float p0)
	{
		if (p0 == 0f)
		{
			return 0f;
		}
		if (p0 == 1f)
		{
			return 1f;
		}
		return z0ZzZzrpk.z0eek(p0, GraphicsUnit.Pixel, GraphicsUnit.Document);
	}

	public z0ZzZzvlh z0zok()
	{
		if (z0nxk)
		{
			return null;
		}
		if (z0uvk == null)
		{
			z0uvk = new z0ZzZzvlh(this);
		}
		return z0uvk;
	}

	public override bool z0ou(XTextElement p0)
	{
		if (p0 is XTextDocumentContentElement)
		{
			return base.z0ou(p0);
		}
		return z0xyk().z0ou(p0);
	}

	public void z0hrk(float p0)
	{
		z0cvk = p0;
	}

	public static void z0lpk()
	{
		z0ZzZzpmk.z0oek();
	}

	private void z0bek(XTextContainerElement p0, XTextElementList p1)
	{
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			if (!(current is XTextContainerElement))
			{
				continue;
			}
			if (current is XTextTableElement)
			{
				((zzz.z0ZzZzkuk<XTextElement>)p1).z0pek(current);
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = ((XTextTableElement)current).z0stk().z0ltk();
				while (z0bpk2.MoveNext())
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk3 = ((XTextTableRowElement)z0bpk2.Current).z0rek().z0ltk();
					while (z0bpk3.MoveNext())
					{
						XTextTableCellElement p2 = (XTextTableCellElement)z0bpk3.Current;
						z0bek(p2, p1);
					}
				}
			}
			else
			{
				z0bek((XTextContainerElement)current, p1);
			}
		}
	}

	public new int z0ark(bool p0)
	{
		z0ZzZzrlh z0ZzZzrlh = new z0ZzZzrlh();
		z0ZzZzrlh.z0rek(p0);
		return z0mpk().z0xb(this, z0ZzZzrlh);
	}

	public override DocumentViewOptions z0iu()
	{
		if (z0ybk == null)
		{
			return z0vtk().ViewOptions;
		}
		return z0ybk;
	}

	public z0ZzZzygh z0kpk()
	{
		if (z0glj == null)
		{
			z0glj = new z0ZzZzygh();
		}
		return z0glj;
	}

	public DateTime z0jpk()
	{
		return z0ZzZzdbj.z0pik();
	}

	public XTextElement z0hpk()
	{
		return z0uzk;
	}

	public z0ZzZzkvj z0gpk()
	{
		if (z0lzk == null)
		{
			z0lzk = new z0ZzZzkvj();
		}
		return z0lzk;
	}

	public float z0bek(XPageSettings p0)
	{
		float num = p0.z0mrk();
		float height = z0pyk().Height;
		float num2 = p0.z0ztk();
		if (height > num2)
		{
			num -= height - num2;
		}
		float height2 = z0lik().Height;
		float num3 = p0.z0frk();
		if (height2 > num3)
		{
			num -= height2 - num3;
		}
		return num;
	}

	public JumpPrintInfo z0vek(XTextElement p0, XTextElement p1)
	{
		if (p0 != null && p0.z0qek() != z0xyk())
		{
			return null;
		}
		if (p1 != null && p1.z0qek() != z0xyk())
		{
			return null;
		}
		JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
		jumpPrintInfo.Enabled = false;
		if (p0 != null)
		{
			float num = 0f;
			if (p0 is XTextTableCellElement || p0 is XTextTableRowElement || p0 is XTextTableElement || p0 is XTextSectionElement)
			{
				num = p0.z0ltk();
			}
			else
			{
				XTextElement xTextElement = p0.z0ie();
				if (p0 is XTextParagraphFlagElement)
				{
					xTextElement = p0;
				}
				num = xTextElement.z0ptk()?.z0xrk() ?? xTextElement.z0ltk();
			}
			JumpPrintInfo jumpPrintInfo2 = z0drk(num);
			if (jumpPrintInfo2 != null)
			{
				jumpPrintInfo.z0eek(jumpPrintInfo2.NativePosition);
				jumpPrintInfo.PageIndex = jumpPrintInfo2.PageIndex;
				jumpPrintInfo.Position = jumpPrintInfo2.Position;
				jumpPrintInfo.Enabled = true;
			}
		}
		if (p1 != null)
		{
			float num2 = 0f;
			if (p1 is XTextTableCellElement || p1 is XTextTableRowElement || p1 is XTextTableElement || p1 is XTextSectionElement)
			{
				num2 = p1.z0ltk() + p1.Height + 1f;
			}
			else
			{
				XTextElement xTextElement2 = p1.z0ie();
				if (p1 is XTextParagraphFlagElement)
				{
					xTextElement2 = p1;
				}
				z0ZzZzzlh z0ZzZzzlh = xTextElement2.z0ptk();
				num2 = ((z0ZzZzzlh != null) ? (z0ZzZzzlh.z0xrk() + z0ZzZzzlh.z0ytk() + 1f) : (xTextElement2.z0ltk() + xTextElement2.Height + 1f));
			}
			JumpPrintInfo jumpPrintInfo3 = z0drk(num2);
			if (jumpPrintInfo3 != null)
			{
				jumpPrintInfo.z0rek(jumpPrintInfo3.NativePosition);
				jumpPrintInfo.EndPageIndex = jumpPrintInfo3.PageIndex;
				jumpPrintInfo.EndPosition = jumpPrintInfo3.Position;
			}
		}
		if (jumpPrintInfo.Enabled)
		{
			return jumpPrintInfo;
		}
		return null;
	}

	public override void z0uu(bool p0)
	{
		if (!p0)
		{
			ElementLoadEventArgs e = new ElementLoadEventArgs(this, null);
			e.UpdateValueBinding = false;
			z0rt(e);
		}
		if (z0yyk() == null || !z0yyk().z0jyk())
		{
			z0opk();
			z0ct();
			z0krk();
		}
	}

	public XTextElement z0ork(string p0)
	{
		Type controlType = z0ZzZzwnj.GetControlType(p0, typeof(XTextElement));
		if (controlType == null)
		{
			throw new ArgumentOutOfRangeException(p0);
		}
		return z0bek(controlType, p1: true);
	}

	public static void z0fpk()
	{
		z0lpk();
	}

	public string z0dpk()
	{
		return z0gyk().z0rkk(this);
	}

	private void z0iek(XTextContainerElement p0, List<XTextPageBreakElement> p1, List<XTextPageInfoElement> p2)
	{
		IList<XTextElement> list = p0.z0xe();
		if (list == null)
		{
			return;
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = list[i];
			if (xTextElement is XTextTableElement)
			{
				XTextTableElement obj = (XTextTableElement)xTextElement;
				obj.z0frk(p0: false);
				XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)obj.z0stk()).z0krk();
				int count2 = obj.z0stk().Count;
				for (int j = 0; j < count2; j++)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)array[j];
					if (!xTextTableRowElement.z0cuk)
					{
						continue;
					}
					xTextTableRowElement.z0tek(p0: false);
					xTextTableRowElement.z0frk(p0: false);
					XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement.z0rek()).z0krk();
					int count3 = xTextTableRowElement.z0rek().Count;
					for (int k = 0; k < count3; k++)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array2[k];
						if (xTextTableCellElement.z0yi())
						{
							xTextTableCellElement.z0frk(p0: false);
							z0iek(xTextTableCellElement, p1, p2);
						}
					}
				}
			}
			else if (xTextElement is XTextContainerElement)
			{
				if (xTextElement is XTextContentElement && xTextElement is XTextSectionElement)
				{
					((XTextSectionElement)xTextElement).z0rek(p0: false);
				}
				XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
				xTextContainerElement.z0frk(p0: false);
				if (xTextContainerElement.z0yi() && xTextContainerElement.z0crk())
				{
					z0iek(xTextContainerElement, p1, p2);
				}
			}
			else if (xTextElement is XTextPageBreakElement)
			{
				XTextPageBreakElement xTextPageBreakElement = (XTextPageBreakElement)xTextElement;
				xTextPageBreakElement.z0eek = false;
				if (xTextPageBreakElement.z0yi())
				{
					p1.Add(xTextPageBreakElement);
				}
			}
			else if (xTextElement is XTextPageInfoElement)
			{
				p2.Add((XTextPageInfoElement)xTextElement);
			}
		}
	}

	public float z0spk()
	{
		float num = ((XTextElement)z0xyk()).z0ork();
		if (num <= 0f)
		{
			num = PageSettings.z0prk();
		}
		return num;
	}

	public override void z0rr(ContentChangedEventArgs p0)
	{
		z0xek(-1);
		if (!p0.LoadingDocument)
		{
			Modified = true;
		}
		if (z0yyk() != null && !z0snk())
		{
			z0yyk().z0eek(p0);
		}
	}

	public bool z0srk(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (p0 is XTextCharElement)
		{
			return true;
		}
		DCValidateIDRepeatMode validateIDRepeatMode = z0bu().ValidateIDRepeatMode;
		if (validateIDRepeatMode == DCValidateIDRepeatMode.None)
		{
			return true;
		}
		string iD = p0.ID;
		if (string.IsNullOrEmpty(iD))
		{
			return true;
		}
		XTextElement xTextElement = z0cek(iD, p1: true);
		if (xTextElement != null && xTextElement != p0)
		{
			switch (validateIDRepeatMode)
			{
			case DCValidateIDRepeatMode.AutoFix:
				iD = iD + "_" + z0hvk;
				z0hvk++;
				p0.ID = iD;
				return true;
			case DCValidateIDRepeatMode.ThrowException:
				throw new InvalidOperationException(string.Format(z0ZzZziok.z0aok(), iD));
			case DCValidateIDRepeatMode.DetectOnly:
				return false;
			}
		}
		return true;
	}

	internal new void z0qrk(bool p0)
	{
		z0mzk = p0;
	}

	public z0ZzZzyxj z0apk()
	{
		if (z0izk == null)
		{
			z0izk = z0ZzZzuok.z0eek<z0ZzZzyxj>();
			if (z0izk != null)
			{
				z0izk.z0zv(this);
			}
		}
		return z0izk;
	}

	public int z0grk(float p0)
	{
		if (p0 == 0f)
		{
			return 0;
		}
		if (p0 == 1f)
		{
			return 1;
		}
		int num = (int)z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, GraphicsUnit.Pixel);
		if (num == 0 && (double)p0 >= 0.999)
		{
			return 1;
		}
		return num;
	}

	private XTextDocumentContentElement z0qpk()
	{
		return null;
	}

	internal z0ZzZzzej z0wpk()
	{
		return z0qxk;
	}

	internal void z0frk(float p0)
	{
		if (p0 > z0qlj)
		{
			z0qlj = p0;
		}
	}

	public z0ZzZzkkh z0epk()
	{
		return z0bek(z0itk(), delegate(object p0, object p1)
		{
			XTextElement xTextElement = (XTextElement)p0;
			XTextElement xTextElement2 = (XTextElement)p1;
			return (!(xTextElement.GetType() == xTextElement2.GetType()) || xTextElement.z0pek() != xTextElement2.z0pek()) ? 1 : 0;
		});
	}

	public void z0rpk()
	{
		z0xbk_jiejie20260327142557?.z0oj();
		z0vnk = false;
		z0bbk = null;
		z0aok();
		Modified = false;
		if (z0azk != null)
		{
			z0azk.z0yek();
			z0azk = null;
		}
		z0lyk();
		if (z0cbk != null)
		{
			z0cbk.Clear();
			z0cbk = null;
		}
		z0bek((z0ZzZzvej)null);
		z0bek(0f);
		z0cvk = 0f;
		PageSettings = new XPageSettings();
		z0bek(MeasureMode.Default);
		z0cek((string)null);
		z0rrk(null);
		z0gnk().Clear();
		z0gpk().Clear();
		z0erk(p0: false);
		z0ipk().z0tek(z0jpk());
		z0ipk().z0rek(z0ipk().z0nrk());
		z0ipk().z0mek(0);
		z0duk();
		if (!z0snk())
		{
			using (z0ZzZzjpk p = z0ru())
			{
				z0bek(p, p1: false);
			}
			z0ct();
			OnSelectionChanged();
			OnDocumentContentChanged();
		}
	}

	private void z0tpk()
	{
		int tickCount = Environment.TickCount;
		if (base.z0ntk != null)
		{
			foreach (XTextElement item in base.z0ntk.z0xrk())
			{
				item.Dispose();
			}
			base.z0ntk.Clear();
		}
		z0hok();
		if (z0wzk != null)
		{
			z0wzk.Clear();
			z0wzk = null;
		}
		if (z0nzk != null)
		{
			foreach (z0ZzZzcok item2 in z0nzk.Styles.z0xrk())
			{
				item2.Dispose();
			}
			z0nzk.Styles.Clear();
		}
		z0gck = null;
		z0czk = null;
		z0zzk = null;
		z0abk = null;
		z0evk = null;
		z0lzk = null;
		z0avk = null;
		if (z0dck != null)
		{
			z0dck.z0tek();
			z0dck = null;
		}
		z0obk = null;
		tickCount = Environment.TickCount - tickCount;
	}

	private int z0ypk()
	{
		return 0;
	}

	internal void z0bek(z0ZzZzhzj p0)
	{
		z0sbk = p0;
	}

	public static bool z0upk()
	{
		return (z0tck & 0x10) == 16;
	}

	public DocumentInfo z0ipk()
	{
		if (z0zbk == null)
		{
			z0zbk = new DocumentInfo();
		}
		return z0zbk;
	}

	public new string z0wrk(bool p0)
	{
		z0ZzZzphh z0ZzZzphh = null;
		if (z0xmk() != null)
		{
			z0ZzZzphh = z0ZzZznhh.z0eek().z0eek(z0ZzZzkfh.z0ltk);
		}
		if (z0ZzZzphh == null)
		{
			z0ZzZzphh = z0ZzZzdfh.z0rek().z0sd();
		}
		if (z0ZzZzphh == null)
		{
			return null;
		}
		z0ZzZzohh z0ZzZzohh = new z0ZzZzohh();
		z0ZzZzohh.IncludeSelectionOnly = p0;
		DocumentBehaviorOptions behaviorOptions = z0vtk().BehaviorOptions;
		z0ZzZzohh.Formated = behaviorOptions.OutputFormatedXMLSource;
		z0ZzZzohh.ForPrint = true;
		StringWriter stringWriter = new StringWriter();
		XTextDocument xTextDocument = this;
		if (behaviorOptions.CloneSerialize)
		{
			xTextDocument = (XTextDocument)z0lr(p0: true);
		}
		xTextDocument.z0tu(z0ZzZzkfh.z0ltk);
		z0ZzZzphh.z0vd(stringWriter, xTextDocument, z0ZzZzohh);
		xTextDocument.z0xik();
		if (behaviorOptions.CloneSerialize)
		{
			xTextDocument.Dispose();
		}
		return stringWriter.ToString();
	}

	public bool z0bek(z0ZzZzevj p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (!z0bu().EnableDataBinding)
		{
			return false;
		}
		if (p0.ProcessState == DCProcessStates.Never)
		{
			return false;
		}
		if (p0.IsEmptyBinding)
		{
			return false;
		}
		return true;
	}

	public string z0krk(string p0, string p1)
	{
		return z0ki(p0)?.z0zwk(p1);
	}

	internal void z0bek(XTextElement p0, int p1)
	{
		if (z0azk == null)
		{
			return;
		}
		foreach (DocumentComment item in z0azk)
		{
			if (!(item.z0xek() is z0ZzZztlh))
			{
				continue;
			}
			z0ZzZztlh z0ZzZztlh = (z0ZzZztlh)item.z0xek();
			if (z0ZzZztlh.z0yek() != p0)
			{
				continue;
			}
			if (p1 != 0 && z0ZzZztlh.z0rek() == p1)
			{
				break;
			}
			z0azk.Remove(item);
			if (z0ank() != null)
			{
				z0ank().Refreshview();
				if (z0cu() != null)
				{
					z0cu().z0zx(p0: true);
					base.z0uyk().z0hz();
				}
			}
			break;
		}
	}

	public void z0vek(TextWriter p0, string p1)
	{
		z0ipk().z0rek(z0jpk());
		z0bek(p0, p1, p2: false, null);
	}

	public void SetCharElementHighlight(XTextCharElement c, Color foreColor, Color backColor, bool supportPrint, bool supportPDF)
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		z0ipk z0ipk = new z0ipk();
		z0ipk.z0rek = foreColor;
		z0ipk.z0tek = backColor;
		z0ipk.z0eek = supportPDF;
		z0ipk.z0yek = supportPrint;
		if (z0cbk == null)
		{
			z0cbk = new Dictionary<XTextCharElement, z0ipk>();
		}
		z0cbk[c] = z0ipk;
	}

	public void z0opk()
	{
		if (z0xu())
		{
			return;
		}
		using z0ZzZzjpk p = z0ru();
		z0bek(p, p1: false);
	}

	internal float z0ppk()
	{
		return z0vxk;
	}

	public static z0ZzZzhvj z0mpk()
	{
		if (z0rvk == null)
		{
			z0rvk = z0ZzZzuok.z0eek<z0ZzZzhvj>();
		}
		return z0rvk;
	}

	public z0ZzZzwrj z0npk()
	{
		return z0nvk;
	}

	public void z0vek(Stream p0, string p1)
	{
		z0bek(p0, p1, p2: false, null);
	}

	public static float z0bpk()
	{
		return z0fbk;
	}

	internal void z0vpk()
	{
		z0ubk = null;
	}

	public bool z0cpk()
	{
		z0ZzZzzlh z0ZzZzzlh = ((XTextContentElement)z0xyk()).z0zek().z0uek();
		if (z0ZzZzzlh != null)
		{
			bool flag = true;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh).z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (!(current is XTextParagraphFlagElement))
					{
						if (!(current is XTextCharElement))
						{
							flag = false;
							break;
						}
						if (!char.IsWhiteSpace(((XTextCharElement)current).z0mek()))
						{
							flag = false;
							break;
						}
					}
				}
			}
			if (flag)
			{
				if (z0ZzZzzlh.z0xrk() - z0suk().z0tek().z0irk() > 10f)
				{
					return false;
				}
				XTextElement xTextElement = ((XTextElementList)z0xyk().z0frk()).z0pek(z0ZzZzzlh[0]);
				if (xTextElement != null && xTextElement.z0je() != z0ZzZzzlh[0].z0je())
				{
					XTextTableElement xTextTableElement = (XTextTableElement)xTextElement.z0yek(typeof(XTextTableElement), p1: false);
					if (xTextTableElement != null)
					{
						float num = ((XTextElement)xTextTableElement).z0ltk() + xTextTableElement.Height;
						z0ZzZzwrj z0ZzZzwrj = z0suk().z0tek();
						if (num > z0ZzZzwrj.z0irk() + 2f)
						{
							return false;
						}
					}
					return true;
				}
			}
		}
		return false;
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		if (!z0rok())
		{
			return;
		}
		base.z0uik = null;
		z0qtk().Layouted = false;
		z0gnk().Styles.z0eek(p0: false);
		if (z0gck != null)
		{
			z0gck.z0iek();
		}
		z0lvk = 0;
		DocumentOptions documentOptions = z0vtk();
		if (string.IsNullOrEmpty(z0gnk().Default.FontName))
		{
			z0gnk().Default.FontName = z0ZzZzimk.DefaultFontName;
		}
		if (z0gnk().Default.FontSize <= 0f)
		{
			z0gnk().Default.FontSize = 9f;
		}
		z0gnk().HandleAfterLoad();
		p0.Element = this;
		z0yok();
		base.z0rik = this;
		base.z0rt(p0);
		z0bek(z0xyk());
		z0prk();
		foreach (DocumentComment comment in Comments)
		{
			comment.z0rek(this);
		}
		z0vpk();
		z0bek(EventArgs.Empty);
		if (documentOptions.BehaviorOptions.EnableElementEvents && z0ZzZzxcj.z0eek(161))
		{
			z0ZzZzqbj z0ZzZzqbj = base.z0uyk();
			if (z0ZzZzqbj != null)
			{
				z0bek(this, p0, z0ZzZzqbj);
			}
		}
		z0gnk().Styles.z0eek(p0: true);
	}

	private void z0vek(z0ZzZzkrj p0)
	{
		z0ZzZzmcj z0ZzZzmcj = z0qtk();
		z0yvk = z0ZzZzbdh.z0xek;
		try
		{
			z0sck = true;
			if (z0lbk != null)
			{
				z0lbk(this, p0.z0zek());
			}
			z0bik();
			z0xek()?.z0mp();
			z0ZzZzvej z0ZzZzvej = null;
			if (p0.z0nek() != null)
			{
				z0ZzZzvej = p0.z0nek().BoundsSelection;
			}
			if (z0ZzZzvej == null)
			{
				z0ZzZzvej = z0jik();
			}
			if (z0bu().SpecifyDebugMode && z0ZzZzvej != null && z0ZzZzvej.z0rek() && z0ZzZzvej.Count > 0 && (p0.z0xek() == PageContentPartyStyle.Body || p0.z0xek() == PageContentPartyStyle.HeaderRows))
			{
				foreach (z0ZzZzcej item in z0ZzZzvej)
				{
					p0.z0mek().z0eek(z0ZzZzidh.z0yek, item.z0eek().z0oek(), item.z0eek().z0pek(), item.z0eek().z0uek(), item.z0eek().z0iek(), 0f);
				}
			}
			if (z0ZzZzmcj.Printing && !z0ZzZzmcj.PrintPreviewing)
			{
				if (p0.z0nek() != null && p0.z0nek().z0vek() == PrintRange.Selection && z0ZzZzdpk.z0eek(p0.z0xek()))
				{
					return;
				}
				if (z0ZzZzvej != null && z0ZzZzvej.z0rek())
				{
					if (z0ZzZzdpk.z0eek(p0.z0xek()))
					{
						return;
					}
					z0ZzZzbdh p1 = z0ZzZzbdh.z0tek(p0.z0uek().z0eek(), z0ZzZzvej.z0tek());
					if (p1.z0bek())
					{
						return;
					}
					p0.z0eek(z0ZzZzndh.z0yek(p1));
					z0ZzZzvdh z0ZzZzvdh = null;
					foreach (z0ZzZzcej item2 in z0ZzZzvej)
					{
						if (z0ZzZzvdh == null)
						{
							z0ZzZzvdh = new z0ZzZzvdh(item2.z0eek());
						}
						else
						{
							z0ZzZzvdh.z0eek(item2.z0eek());
						}
					}
					p0.z0mek().z0eek(z0ZzZzvdh);
				}
			}
			z0bek(p0.z0cek());
			XTextDocumentContentElement xTextDocumentContentElement = z0bek(p0.z0xek());
			if ((xTextDocumentContentElement != z0xyk() && !xTextDocumentContentElement.z0fi() && z0jrk() != xTextDocumentContentElement) || xTextDocumentContentElement == null || !xTextDocumentContentElement.Visible || (p0.z0bek() == (z0ZzZzxej)1 && (xTextDocumentContentElement.PrintVisibility == ElementVisibility.Hidden || xTextDocumentContentElement.PrintVisibility == ElementVisibility.None)))
			{
				return;
			}
			z0qlj = 0f;
			z0ZzZzcxj z0ZzZzcxj = (z0ZzZzcxj)0;
			z0ZzZzvxj z0ZzZzvxj = new z0ZzZzvxj(p3: (p0.z0bek() == (z0ZzZzxej)1) ? ((z0ZzZzcxj)3) : ((p0.z0bek() == (z0ZzZzxej)2) ? ((z0ZzZzcxj)2) : (z0tyk() ? ((z0ZzZzcxj)3) : ((z0ZzZzcxj)0))), p0: this, p1: p0.z0mek(), p2: p0.z0uek().z0eek());
			z0ZzZzvxj.z0eek(p0.z0tek());
			z0ZzZzvxj.z0eek(p0.z0xek());
			z0ZzZzvxj.z0eyk = xTextDocumentContentElement == z0jrk();
			z0ZzZzvxj.z0yrk = xTextDocumentContentElement.z0urk();
			z0ZzZzvxj.z0eek(xTextDocumentContentElement);
			z0ZzZzvxj.z0eek(p0.z0nek());
			DocumentViewOptions documentViewOptions = z0iu();
			z0ZzZzvxj.z0hyk = xTextDocumentContentElement;
			z0ZzZzvxj.z0luk = xTextDocumentContentElement.z0aek();
			z0ZzZzvxj.z0gyk.z0eek(documentViewOptions.TextRenderStyle);
			z0ZzZzvxj.z0gyk.z0eek(documentViewOptions.GraphicsSmoothingMode);
			z0ZzZzvxj.z0uek(p0.z0iek());
			z0ZzZzvxj.z0rek(p0.z0yek());
			z0ZzZzvxj.z0eek(z0suk().Count);
			z0ZzZzvxj.z0eek(p0.z0cek());
			JumpPrintInfo jumpPrintInfo = p0.z0nek()?.z0pek();
			if (jumpPrintInfo != null && jumpPrintInfo.HasValidateInfo)
			{
				z0ZzZzvxj.z0uek(p0: true);
				z0ZzZzqbj z0ZzZzqbj = base.z0uyk();
				if (z0ZzZzqbj != null && !z0ZzZzqbj.z0tok && jumpPrintInfo.Mode == JumpPrintMode.Normal && jumpPrintInfo.PageIndex == p0.z0yek() && p0.z0bek() == (z0ZzZzxej)1)
				{
					z0ZzZzvxj.z0tek(p0: false);
				}
			}
			z0ZzZzvxj.z0gyk.z0eek();
			z0ZzZzvxj.z0gtk = xTextDocumentContentElement.z0qyk();
			if (p0.z0bek() == (z0ZzZzxej)1 && base.z0uyk() != null)
			{
				z0ZzZzvxj.z0ztk = base.z0uyk().z0cok;
			}
			if (z0ZzZzvxj.z0duk != null && z0ZzZzbej.z0iek)
			{
				List<string> list = new List<string>();
				XTextCharElement xTextCharElement = new XTextCharElement();
				xTextCharElement.z0bt(this);
				xTextCharElement.z0oek(-1);
				list.Add(xTextCharElement.z0qt()?.z0yek());
				int count = z0gnk().Styles.Count;
				for (int i = 0; i < count; i++)
				{
					xTextCharElement.z0oek(i);
					list.Add(xTextCharElement.z0qt()?.z0yek());
				}
				xTextCharElement.Dispose();
				z0ZzZzvxj.z0duk.z0bhk(list.ToArray());
				list.Clear();
			}
			if (p0.z0bek() == (z0ZzZzxej)1 && (p0.z0xek() == PageContentPartyStyle.Body || p0.z0xek() == PageContentPartyStyle.HeaderRows) && z0ZzZzvej != null && z0ZzZzvej.z0yek())
			{
				foreach (z0ZzZzcej item3 in z0ZzZzvej)
				{
					z0ZzZzbdh p2 = z0ZzZzbdh.z0tek(p0.z0uek().z0eek(), item3.z0eek());
					if (!p2.z0bek())
					{
						z0ZzZzvxj.z0rek(p2);
						z0ZzZzvxj.z0gyk.z0eek(p2);
						xTextDocumentContentElement.z0vw(z0ZzZzvxj);
					}
				}
			}
			else
			{
				xTextDocumentContentElement.z0vw(z0ZzZzvxj);
			}
			if (z0jtk() != null && p0.z0bek() == (z0ZzZzxej)0 && documentViewOptions.AdornTextVisibility != DCAdornTextVisibility.Hidden && z0ZzZzvxj.z0eyk)
			{
				z0ZzZzvxj.z0gyk.z0rek();
				z0jtk().z0eek(z0ZzZzvxj);
			}
			if (p0.z0bek() != (z0ZzZzxej)1 && p0.z0bek() != (z0ZzZzxej)4 && base.z0uyk() != null && base.z0uyk().z0xok && !z0ZzZzmcj.GenerateBmp)
			{
				z0ZzZzvxj.z0rek(p0.z0uek().z0eek());
				base.z0uyk().z0mrk()?.z0eek(z0ZzZzvxj, xTextDocumentContentElement);
			}
			if ((xTextDocumentContentElement == z0pyk() || xTextDocumentContentElement == z0cyk()) && z0rnk() && xTextDocumentContentElement.z0frk().Count > 0 && documentViewOptions.HeaderBottomLineWidth > 0f)
			{
				float num = 1f;
				if (documentViewOptions.HeaderBottomLineWidth != 1f)
				{
					num = z0ZzZzjpk.z0eek(documentViewOptions.HeaderBottomLineWidth, GraphicsUnit.Pixel, p0.z0mek().z0vek());
				}
				using z0ZzZzudh p3 = new z0ZzZzudh(Color.Black, num);
				if (z0ZzZzvxj.z0duk != null)
				{
					z0ZzZzvxj.z0gyk.z0eek(p3, xTextDocumentContentElement.z0it(), xTextDocumentContentElement.z0xtk() + 1f, ((XTextElement)xTextDocumentContentElement).z0mek(), xTextDocumentContentElement.z0xtk() + 1f);
				}
				else
				{
					z0ZzZzvxj.z0gyk.z0eek(p3, xTextDocumentContentElement.z0it(), xTextDocumentContentElement.z0xtk() - num - 2f, ((XTextElement)xTextDocumentContentElement).z0mek(), xTextDocumentContentElement.z0xtk() - num - 2f);
				}
			}
			z0ZzZzfpk z0ZzZzfpk = PageSettings.z0trk();
			if (p0.z0xek() == PageContentPartyStyle.Body && z0ZzZzfpk != null && z0nnk() == PageViewMode.Page)
			{
				bool flag = true;
				if (z0ZzZzvej != null && z0ZzZzvej.z0rek())
				{
					flag = false;
				}
				JumpPrintInfo jumpPrintInfo2 = p0.z0nek()?.z0pek();
				if (jumpPrintInfo2 != null && jumpPrintInfo2.HasValidateInfo && jumpPrintInfo2.Mode != JumpPrintMode.Offset)
				{
					flag = false;
				}
				if (p0.z0nek() != null && p0.z0nek().z0vek() == PrintRange.Selection)
				{
					flag = false;
				}
				if (flag)
				{
					if (p0.z0cek() == z0suk().z0tek() && !z0cpk())
					{
						z0ZzZzbdh p4 = new z0ZzZzbdh(z0it(), z0iik() + xTextDocumentContentElement.z0xtk(), xTextDocumentContentElement.Width, p0.z0cek().z0urk() - p0.z0cek().z0xek());
						p0.z0mek().z0rek();
						z0ZzZzfpk.z0rek(p0.z0mek(), p4, z0ZzZzbdh.z0xek);
					}
					else if (p0.z0cek() != z0suk().z0tek())
					{
						z0ZzZzbdh p5 = new z0ZzZzbdh(z0it(), p0.z0cek().z0irk() + p0.z0cek().z0xek(), xTextDocumentContentElement.Width, p0.z0cek().z0urk() - p0.z0cek().z0xek());
						p0.z0mek().z0rek();
						z0ZzZzfpk.z0eek(p0.z0mek(), p5, z0ZzZzbdh.z0xek);
					}
				}
			}
			if (z0tvk != null)
			{
				z0tvk(this, p0.z0zek());
			}
			if (p0.z0tek() != PageViewMode.Page && p0.z0tek() != PageViewMode.CompressPage && !z0xrk() && (z0ZzZzxvj.z0eek || (!z0ZzZzxcj.z0rek(p0.z0yek()) && p0.z0xek() == PageContentPartyStyle.Body)))
			{
				z0ZzZzxpk z0ZzZzxpk = (z0ZzZzxpk)z0bek(base.z0uyk(), p0.z0yek());
				object p6 = p0.z0mek().z0bek();
				p0.z0mek().z0rek();
				if (!z0ZzZzxpk.z0yek)
				{
					z0ZzZzxpk.z0cek = true;
				}
				if (!p0.z0iek().z0bek())
				{
					z0ZzZzxpk.z0eek(z0ZzZzvxj.z0gyk, p0.z0iek(), p2: false, z0ZzZzvxj.z0nek());
				}
				else
				{
					z0ZzZzxpk.z0eek(z0ZzZzvxj.z0gyk, p0.z0pek().z0eek(), p2: false, z0ZzZzvxj.z0nek());
				}
				p0.z0mek().z0eek(p6);
			}
			z0ZzZzvxj.z0gyk.z0hrk();
		}
		finally
		{
			z0sck = false;
			z0aok();
			z0xek()?.z0on();
		}
	}

	void z0ZzZzjrj.z0rek(z0ZzZzkrj p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0vek
		this.z0vek(p0);
	}

	public DocumentContentStyle z0xpk()
	{
		XTextElement xTextElement = z0qok();
		if (xTextElement == null)
		{
			return (DocumentContentStyle)z0gnk().Default;
		}
		if (xTextElement is XTextCharElement && ((XTextCharElement)xTextElement).z0oek())
		{
			DocumentContentStyle obj = (DocumentContentStyle)xTextElement.z0aek().z0jrk.Clone();
			obj.z0eek_jiejie20260327142557("BackgroundColor");
			((z0ZzZzcok)obj).z0tek();
			return obj;
		}
		if (xTextElement is XTextFieldBorderElement)
		{
			DocumentContentStyle obj2 = (DocumentContentStyle)xTextElement.z0aek().z0jrk.Clone();
			obj2.z0eek_jiejie20260327142557("BackgroundColor");
			((z0ZzZzcok)obj2).z0tek();
			return obj2;
		}
		return xTextElement.z0aek().z0jrk;
	}

	private void z0vek(DocumentContentStyle p0)
	{
		throw new NotSupportedException("Document.Style");
	}

	internal void z0zpk()
	{
		if (z0pck == null)
		{
			z0bik();
		}
	}

	public void z0lmk()
	{
		z0ct();
	}

	internal XTextDocument(int v)
	{
		if (v == 1 || v != 2)
		{
			return;
		}
		base.z0rik = this;
		XTextElementList xTextElementList = z0be();
		xTextElementList.Capacity = 5;
		((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)new XTextDocumentHeaderElement());
		((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)new XTextDocumentBodyElement());
		((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)new XTextDocumentFooterElement());
		((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)new XTextDocumentHeaderForFirstPageElement());
		((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)new XTextDocumentFooterForFirstPageElement());
		z0nzk = new DocumentContentStyleContainer();
		z0nzk.Default.FontSize = z0fbk;
		DocumentContentStyle item = new DocumentContentStyle
		{
			Align = DocumentContentAlignment.Center,
			FontSize = z0fbk
		};
		z0nzk.Styles.Add(item);
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextDocumentContentElement xTextDocumentContentElement = (XTextDocumentContentElement)z0bpk.Current;
				xTextDocumentContentElement.z0rek(p0: false);
				xTextDocumentContentElement.z0yek(this, this);
				XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
				xTextParagraphFlagElement.z0rek(p0: true);
				xTextParagraphFlagElement.z0yek(this, xTextDocumentContentElement);
				((zzz.z0ZzZzkuk<XTextElement>)xTextDocumentContentElement.z0be()).z0pek((XTextElement)xTextParagraphFlagElement);
				if (xTextDocumentContentElement is XTextDocumentHeaderElement || xTextDocumentContentElement is XTextDocumentHeaderForFirstPageElement)
				{
					xTextParagraphFlagElement.z0oek(0);
				}
			}
		}
		z0klj = new z0ZzZzczj(this);
		z0zbk = new DocumentInfo();
		z0zbk.z0tek(z0jpk());
		z0zbk.z0rek(z0zbk.z0nrk());
		z0zbk.z0mek(0);
	}

	public int z0kmk()
	{
		return z0mpk().z0sv(this);
	}

	public void z0jrk(string p0, string p1)
	{
		z0gpk().z0eek(p0, p1);
	}

	private int z0bek(z0ZzZzylh p0, z0ZzZzwcj p1)
	{
		if (p0 == null || p0.Count == 0)
		{
			return 0;
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("cmds");
		}
		int result = 0;
		foreach (z0ZzZztlh item in p0)
		{
			if (item.z0yek() != null)
			{
				DocumentComment documentComment = new DocumentComment();
				documentComment.z0otk = true;
				documentComment.z0pek(item.z0uek());
				documentComment.z0rek((z0cu() == null) ? Color.Yellow : z0cu().z0ybk);
				documentComment.z0tek(this);
				documentComment.z0eek(item.z0yek().z0hy());
				documentComment.z0eek(item);
				if (string.IsNullOrEmpty(item.z0iek()))
				{
					documentComment.z0nek(z0ZzZziok.z0luk());
				}
				else
				{
					documentComment.z0nek(item.z0iek());
				}
				documentComment.z0eek(item.z0pek());
				item.z0eek(documentComment);
				p1.Add(documentComment);
			}
		}
		return result;
	}

	public ContentEffects SetDefaultFont(z0ZzZzimk font, Color color, bool raiseEvent)
	{
		bool flag = !z0gnk().Default.Font.z0eek(font);
		bool flag2 = z0gnk().Default.Color != color;
		if (flag)
		{
			z0gnk().Default.Font = font.Clone();
			using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = z0gnk().Styles.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0bpk.Current;
					if (documentContentStyle.Font.z0eek(font))
					{
						documentContentStyle.Font = font;
					}
				}
			}
			z0gnk().z0nn();
		}
		if (flag2)
		{
			z0gnk().Default.Color = color;
			z0gnk().z0nn();
		}
		if (z0vbk != null)
		{
			z0vbk.z0yek();
			z0vbk = null;
		}
		if ((flag || flag2) && raiseEvent && z0xyk().z0be().Count > 0)
		{
			OnDocumentContentChanged();
			OnSelectionChanged();
		}
		if (flag)
		{
			return ContentEffects.Layout;
		}
		if (flag2)
		{
			return ContentEffects.Display;
		}
		return ContentEffects.None;
	}

	public void z0bek(CopySourceInfo p0)
	{
	}

	private void z0vek(z0ZzZzjpk p0)
	{
		DocumentContentStyle documentContentStyle = z0dik();
		z0ack.z0rek(p0.z0eek(documentContentStyle.Font));
		z0ack.z0eek(z0xek(2f));
		z0jxk = z0xek(9f);
	}

	public void z0bek(DocumentInfo p0)
	{
		z0zbk = p0;
	}

	private z0ZzZzerj z0jmk()
	{
		return z0suk();
	}

	z0ZzZzerj z0ZzZzjrj.z0eek()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0jmk
		return this.z0jmk();
	}

	public z0ZzZzkvj z0hmk()
	{
		if (z0mxk == null)
		{
			z0mxk = new z0ZzZzkvj();
		}
		DateTime dateTime = z0jpk();
		z0mxk.z0eek("Page", z0cmk());
		z0mxk.z0eek("NumPages", z0suk().Count);
		z0mxk.z0eek("Author", (object)z0ipk().z0trk());
		z0mxk.z0eek("Title", (object)z0ipk().z0mek());
		z0mxk.z0eek("Date", dateTime.Date);
		z0mxk.z0eek("Time", dateTime.TimeOfDay);
		return z0mxk;
	}

	public static bool z0gmk()
	{
		return ((z0ZzZzpck)z0dnk()).z0jrk;
	}

	public void OnSelectionChanged()
	{
		if (z0snk() || z0xu())
		{
			return;
		}
		z0zck = z0cuk().z0urk();
		z0xek(-1);
		if (z0yyk() != null)
		{
			z0yyk().z0iek(p0: true);
			XTextContainerElement p = null;
			int p2 = 0;
			z0ryk().z0tek(out p, out p2);
			XTextElement p3 = null;
			while (p != null)
			{
				if (p is XTextTableElement)
				{
					z0ZzZzpxj z0ZzZzpxj = z0xek();
					if (z0ZzZzpxj != null && z0ZzZzpxj.z0np(p))
					{
						p3 = p;
						break;
					}
				}
				p = p.z0ji();
			}
			base.z0uyk().z0pek(p3);
		}
		for (XTextElement xTextElement = z0itk(); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			z0ZzZzmpj z0ZzZzmpj = z0jtk();
			if (z0ZzZzmpj != null && z0ZzZzmpj.z0tek(xTextElement))
			{
				z0krk(xTextElement);
			}
		}
		if (z0yyk() != null)
		{
			z0yyk().z0eek(EventArgs.Empty);
			if (base.z0uyk().z0ic())
			{
				base.z0uyk().z0ac();
			}
		}
		if (z0jrk() is XTextDocumentBodyElement && z0cuk().z0qrk() == 0)
		{
			z0btk();
		}
		if (SelectionChanged != null)
		{
			SelectionChanged(this, EventArgs.Empty);
		}
	}

	public void z0fmk()
	{
		Modified = false;
		z0bek((z0ZzZzvej)null);
		z0bek(0f);
		z0cvk = 0f;
		PageSettings = new XPageSettings();
		z0bek(MeasureMode.Default);
		z0cek((string)null);
		z0rrk(null);
		z0gnk().Clear();
		z0gpk().Clear();
		z0ipk().z0tek(z0jpk());
		z0ipk().z0rek(z0ipk().z0nrk());
		z0ipk().z0mek(0);
		z0duk();
	}

	public override XTextElementList z0yu(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		if (string.Compare(p0, z0ZzZzkfh.z0vrk, true) == 0)
		{
			return new XTextElementList(z0pyk());
		}
		if (string.Compare(p0, z0ZzZzkfh.z0urk, true) == 0)
		{
			return new XTextElementList(z0xyk());
		}
		if (string.Compare(p0, z0ZzZzkfh.z0nrk, true) == 0)
		{
			return new XTextElementList(z0lik());
		}
		return base.z0yu(p0);
	}

	public new void z0erk(bool p0)
	{
		z0rbk = p0;
	}

	[CompilerGenerated]
	private void z0vek(object p0, ElementEnumerateEventArgs p1)
	{
		p1.Element.z0xrk().CreatorIndex = z0syk().z0yek();
		p1.Element.z0ftk();
		if (p1.Element is XTextFieldElementBase)
		{
			((XTextFieldElementBase)p1.Element).z0vek();
		}
	}

	private bool z0cek(XTextContainerElement p0)
	{
		bool result = false;
		for (int num = p0.z0be().Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = p0.z0be()[num];
			z0ZzZzrzj z0ZzZzrzj = xTextElement.z0aek();
			if (z0ZzZzrzj.z0nrk < 0)
			{
				if (z0ZzZzrzj.z0jyk >= 0)
				{
					DocumentContentStyle documentContentStyle = xTextElement.z0aek().z0yek();
					documentContentStyle.DeleterIndex = -1;
					xTextElement.z0oek(z0gnk().GetStyleIndex(documentContentStyle));
					result = true;
				}
			}
			else if (z0ZzZzrzj.z0nrk >= 0 || z0ZzZzrzj.z0jyk >= 0)
			{
				p0.z0be().RemoveAt(num);
				result = true;
				continue;
			}
			if (xTextElement is XTextContainerElement && z0cek((XTextContainerElement)xTextElement))
			{
				result = true;
			}
		}
		return result;
	}

	public string z0dmk()
	{
		return z0cek(z0vtk().BehaviorOptions.OutputFormatedXMLSource);
	}

	public void z0bek(XTextSubDocumentElement p0)
	{
		z0gyk().z0ekk(this, p0);
	}

	[CompilerGenerated]
	internal static ElementType2 z0oek<ElementType, ElementType2>(XTextElementList p0, int p1, bool p2, bool p3) where ElementType : XTextElement where ElementType2 : XTextElement
	{
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0).z0krk();
		if (p3)
		{
			int count = p0.Count;
			for (int i = p1; i < count; i++)
			{
				XTextElement xTextElement = array[i];
				if (!p2 && !xTextElement.z0yi())
				{
					continue;
				}
				if (xTextElement is ElementType2)
				{
					return (ElementType2)xTextElement;
				}
				if (xTextElement is XTextContainerElement xTextContainerElement && xTextContainerElement.z0crk())
				{
					ElementType2 val = z0oek<ElementType, ElementType2>(xTextElement.z0be(), 0, p2, p3);
					if (val != null)
					{
						return val;
					}
				}
			}
			XTextContainerElement xTextContainerElement2 = p0[0].z0ji()?.z0ji();
			if (xTextContainerElement2 != null && xTextContainerElement2.z0crk())
			{
				int num = xTextContainerElement2.z0be().IndexOf(p0[0].z0ji());
				if (num >= 0)
				{
					ElementType2 val2 = z0oek<ElementType, ElementType2>(xTextContainerElement2.z0be(), num + 1, p2, p3);
					if (val2 != null)
					{
						return val2;
					}
				}
			}
		}
		else
		{
			for (int num2 = 0; num2 < p1; num2--)
			{
				XTextElement xTextElement2 = array[num2];
				if (p2 || xTextElement2.z0yi())
				{
					if (xTextElement2 is ElementType2)
					{
						return (ElementType2)xTextElement2;
					}
					if (xTextElement2 is XTextContainerElement xTextContainerElement3 && xTextContainerElement3.z0crk())
					{
						ElementType2 val3 = z0oek<ElementType, ElementType2>(xTextElement2.z0be(), xTextElement2.z0be().Count, p2, p3);
						if (val3 != null)
						{
							return val3;
						}
					}
				}
			}
			XTextContainerElement xTextContainerElement4 = p0[0].z0ji()?.z0ji();
			if (xTextContainerElement4 != null && xTextContainerElement4.z0crk())
			{
				int num3 = xTextContainerElement4.z0be().IndexOf(p0[0].z0ji());
				if (num3 >= 0)
				{
					ElementType2 val4 = z0oek<ElementType, ElementType2>(xTextContainerElement4.z0be(), num3, p2, p3);
					if (val4 != null)
					{
						return val4;
					}
				}
			}
		}
		return null;
	}

	public string z0hrk(string p0, string p1)
	{
		return z0ki(p0)?.z0zwk(p1);
	}

	internal void z0vek(z0ZzZzbdh p0)
	{
		if (!p0.z0bek())
		{
			if (z0yvk.z0bek())
			{
				z0yvk = p0;
			}
			else
			{
				z0yvk = z0ZzZzbdh.z0yek(z0yvk, p0);
			}
		}
	}

	public override XTextDocument z0ee_jiejie20260327142557(bool p0)
	{
		return (XTextDocument)z0lr(p0: true);
	}

	internal void z0smk()
	{
		z0ezk--;
		if (z0ezk < 0)
		{
			z0ezk = 0;
		}
	}

	public string z0amk()
	{
		return z0hzk;
	}

	internal void z0qmk()
	{
	}

	internal bool z0wmk()
	{
		if (z0azk != null)
		{
			return z0azk.Count > 0;
		}
		return false;
	}

	internal void z0emk()
	{
		int num = z0cuk().z0urk();
		if (num != z0zck)
		{
			z0zck = num;
			OnSelectionChanged();
		}
	}

	public void z0bek(z0ZzZzyrj p0)
	{
		z0zzk = p0;
	}

	internal static bool z0rmk()
	{
		return z0hbk;
	}

	public void z0vek(z0ZzZzerj p0)
	{
		z0abk = p0;
	}

	public override void z0tu(string p0)
	{
		if (string.Compare(p0, z0rzk, true) == 0 || string.Compare(p0, "ofd", true) == 0)
		{
			return;
		}
		z0tik();
		z0irk(z0srk());
		z0svk = false;
		if (!z0vtk().BehaviorOptions.SpecifyDebugMode)
		{
			z0prk();
		}
		z0gnk().Styles.z0eek();
		z0yok();
		if (!string.IsNullOrEmpty(p0) && string.Compare(p0, z0zvk, true) != 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				if (z0bpk.Current is XTextDocumentContentElement xTextDocumentContentElement)
				{
					xTextDocumentContentElement.z0rek(p0: true, p1: true);
				}
			}
		}
		if (!string.IsNullOrEmpty(p0) && string.Compare(p0, z0zvk, true) != 0)
		{
			return;
		}
		bool flag = PageSettings.z0ktk();
		foreach (XTextElement item in z0be().z0xrk())
		{
			if (flag || (!(item is XTextDocumentHeaderForFirstPageElement) && !(item is XTextDocumentFooterForFirstPageElement)))
			{
				item.z0tu(p0);
			}
		}
		XTextCheckBoxElementBase.z0eek(z0be(), this);
	}

	public CopySourceInfo z0tmk()
	{
		return null;
	}

	public z0ZzZzylh z0ymk()
	{
		z0ZzZzylh z0ZzZzylh = z0stk();
		bool num = z0azk != null && z0azk.Count > 0;
		z0azk = new z0ZzZzwcj();
		z0bek(z0ZzZzylh, z0azk);
		bool flag = z0azk != null && z0azk.Count > 0;
		if ((num || flag) && z0cu() != null && z0ank() != null)
		{
			z0ank().Refreshview();
			z0cu().z0zx(p0: true);
			base.z0uyk().z0hz();
			z0cu().z0puk_jiejie20260327142557();
		}
		return z0ZzZzylh;
	}

	public override z0ZzZzjpk z0ru()
	{
		if (z0bxk != null)
		{
			z0bxk.z0eek(new z0ZzZzjdh());
			z0ZzZzjpk z0ZzZzjpk = new z0ZzZzjpk(z0bxk);
			z0ZzZzjpk.z0eek(GraphicsUnit.Document);
			z0ZzZzjpk.z0eek(p0: false);
			return z0ZzZzjpk;
		}
		z0bxk = z0ZzZzdpk.z0eek();
		z0bxk.z0eek(GraphicsUnit.Document);
		z0ZzZzjpk z0ZzZzjpk2 = new z0ZzZzjpk(z0bxk);
		z0ZzZzjpk2.z0eek(p0: false);
		return z0ZzZzjpk2;
	}

	public float z0umk()
	{
		return z0cvk;
	}

	public string z0prk(string p0)
	{
		if (!(z0ki(p0) is XTextSubDocumentElement xTextSubDocumentElement))
		{
			return null;
		}
		return xTextSubDocumentElement.SaveDocumentToString(null);
	}

	public z0ZzZzczj z0imk()
	{
		if (z0xrk())
		{
			return null;
		}
		return z0klj;
	}

	public int z0omk()
	{
		return base.z0qtk;
	}

	public void z0grk(string p0, string p1)
	{
		byte[] array = Convert.FromBase64String(p0);
		if (string.IsNullOrEmpty(p1))
		{
			p1 = z0ZzZzafh.z0yek(array);
		}
		MemoryStream p2 = new MemoryStream(array);
		z0bek(p2, p1);
	}

	public void z0pek(List<byte[]> p0)
	{
		z0ivk = p0;
	}

	private bool z0pmk()
	{
		if (!z0bu().EnableCompressUserHistories)
		{
			return false;
		}
		z0gnk().Styles.z0eek(p0: false);
		bool[] array = new bool[z0syk().Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = false;
		}
		if (!z0syk().z0mek && z0syk().Count > 0)
		{
			array[z0syk().Count - 1] = true;
		}
		foreach (DocumentContentStyle item in z0gnk().Styles.z0xrk())
		{
			if (item.CreatorIndex >= 0 && item.CreatorIndex < array.Length)
			{
				array[item.CreatorIndex] = true;
			}
			if (item.DeleterIndex >= 0 && item.DeleterIndex < array.Length)
			{
				array[item.DeleterIndex] = true;
			}
		}
		bool result = false;
		for (int num = array.Length - 1; num >= 0; num--)
		{
			if (!array[num])
			{
				result = true;
				z0syk().RemoveAt(num);
				foreach (DocumentContentStyle item2 in z0gnk().Styles.z0xrk())
				{
					if (item2.CreatorIndex >= num)
					{
						item2.CreatorIndex--;
					}
					if (item2.DeleterIndex >= num)
					{
						item2.DeleterIndex--;
					}
				}
			}
		}
		return result;
	}

	public string z0mmk()
	{
		return z0kvk;
	}

	public void z0vek(z0ZzZzlfh p0)
	{
		z0dxk = p0;
	}

	public RepeatedImageValueList z0nmk()
	{
		if (z0wzk == null)
		{
			z0wzk = new RepeatedImageValueList();
		}
		return z0wzk;
	}

	private z0ZzZzzej z0bmk()
	{
		XPageSettings pageSettings = PageSettings;
		if (pageSettings != null && pageSettings.z0uek() && pageSettings.DocumentGridLine != null && pageSettings.DocumentGridLine.z0uek() && pageSettings.DocumentGridLine.z0mek() > 0 && z0ZzZzxcj.z0eek(33))
		{
			return pageSettings.DocumentGridLine;
		}
		return null;
	}

	public override bool z0de()
	{
		XTextDocumentContentElement xTextDocumentContentElement = z0jrk();
		if (xTextDocumentContentElement != null)
		{
			return xTextDocumentContentElement.z0oek().z0qrk() != 0;
		}
		return false;
	}

	public z0ZzZzimk z0vmk()
	{
		return z0dik().Font;
	}

	public int z0cmk()
	{
		if (z0npk() == null || z0suk() == null)
		{
			return 0;
		}
		return z0suk().IndexOf(z0npk());
	}

	public z0ZzZzlfh z0xmk()
	{
		if (z0dxk != null)
		{
			return z0dxk;
		}
		if (base.z0uyk() != null)
		{
			return z0yyk().z0pek();
		}
		return z0ZzZzlfh.z0iek();
	}

	public DateTime z0zmk()
	{
		return z0yck;
	}

	private void z0lnk()
	{
	}

	public override void z0bt(XTextDocument p0)
	{
	}

	private void z0mek(XTextContainerElement p0, List<XTextPageInfoElement> p1)
	{
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0krk();
		int count = p0.z0be().Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			if (xTextElement is XTextPageInfoElement)
			{
				if (xTextElement.z0cuk)
				{
					p1.Add((XTextPageInfoElement)xTextElement);
				}
			}
			else if (xTextElement is XTextContainerElement && xTextElement.z0yi())
			{
				z0mek((XTextContainerElement)xTextElement, p1);
			}
		}
	}

	public void z0bek(XTextDocument p0, bool p1, bool p2 = false)
	{
		z0we();
		z0ubk = null;
		if (z0azk != null)
		{
			z0azk.z0yek();
			z0azk = null;
		}
		z0exk = null;
		z0nvk = null;
		z0vbk = null;
		z0czk = null;
		if (p0 == null)
		{
			return;
		}
		if (p1)
		{
			if (p0.z0be() != null)
			{
				if (p2)
				{
					base.z0ntk = p0.z0be();
					p0.z0te(null);
				}
				else
				{
					z0be().Clear();
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						z0be().Add(current);
					}
				}
			}
			if (p0.z0gck != null)
			{
				if (p2)
				{
					z0gck = p0.z0gck;
					p0.z0gck = null;
				}
				else
				{
					z0gck = p0.z0gck.z0eek(p0: true);
				}
			}
			if (p0.z0nzk != null)
			{
				if (p2)
				{
					z0nzk = p0.z0nzk;
					p0.z0nzk = null;
				}
				else
				{
					z0nzk = (DocumentContentStyleContainer)((z0ZzZzxok)p0.z0nzk).z0eek();
					z0nzk.z0eek(this);
				}
			}
			if (p0.z0obk != null)
			{
				if (p2)
				{
					z0obk = p0.z0obk;
					p0.z0obk = null;
				}
				else
				{
					z0obk = p0.z0obk.z0uek();
				}
			}
			if (p0.z0wzk != null)
			{
				if (p2)
				{
					z0wzk = p0.z0wzk;
					p0.z0wzk = null;
				}
				else
				{
					z0wzk = p0.z0wzk.z0eek();
				}
			}
		}
		else
		{
			z0gck = null;
			z0obk = null;
		}
		if (p0.Attributes != null)
		{
			if (p2)
			{
				Attributes = p0.Attributes;
				p0.Attributes = null;
			}
			else
			{
				Attributes = p0.Attributes.z0eek();
			}
		}
		if (p0.z0lzk != null)
		{
			z0lzk = new z0ZzZzkvj();
			foreach (DocumentParameter item in p0.z0lzk)
			{
				if (!z0gpk().z0yek(item.z0eek()))
				{
					z0gpk().Add(item.z0oek());
				}
			}
		}
		z0erk(p0.z0ptk());
		z0cek(p0.z0amk());
		z0rrk(p0.z0ftk());
		z0xxk = null;
		z0lck = null;
		z0lvk = 0;
		z0vbk = null;
		z0exk = null;
		z0mxk = null;
		z0czk = null;
		z0bvk = null;
		z0vbk = null;
		z0xnk = null;
		z0sbk = null;
		z0krk(p0: false);
		z0abk = null;
		z0nvk = null;
		if (p0.z0ipk() != null)
		{
			if (p2)
			{
				z0zbk = p0.z0zbk;
				p0.z0zbk = null;
			}
			else
			{
				z0bek(p0.z0ipk().z0yek());
			}
		}
		if (p0.PageSettings != null)
		{
			if (p2)
			{
				z0evk = p0.z0evk;
				p0.z0evk = null;
			}
			else
			{
				z0evk = p0.z0evk.z0wtk();
			}
		}
		z0cvk = p0.z0cvk;
	}

	internal new DocumentComment z0zek(int p0)
	{
		if (z0azk != null && z0azk.Count > 0)
		{
			foreach (DocumentComment item in z0azk)
			{
				if (item.GetHashCode() == p0)
				{
					return item;
				}
			}
		}
		if (z0gck != null)
		{
			foreach (DocumentComment item2 in z0gck)
			{
				if (item2.GetHashCode() == p0)
				{
					return item2;
				}
			}
		}
		return null;
	}

	public DocumentContentSourceTypes z0knk()
	{
		return z0gxk;
	}

	public override bool z0eu()
	{
		bool result = z0ZzZzafh.z0yek((XTextContainerElement)this);
		foreach (DocumentContentStyle item in z0gnk().Styles.z0xrk())
		{
			if (item.z0pek())
			{
				result = true;
			}
		}
		if (z0obk != null && z0obk.Count > 0)
		{
			z0obk.Clear();
			result = true;
		}
		if (z0klj != null && z0klj.Count > 0)
		{
			z0klj.Clear();
		}
		return result;
	}

	public void z0jnk()
	{
		z0ZzZzzok styles = z0gnk().Styles;
		z0wxk = new bool[styles.Count];
		for (int i = 0; i < styles.Count; i++)
		{
			z0wxk[i] = ((DocumentContentStyle)styles[i]).DeleterIndex >= 0;
		}
	}

	public bool z0hnk()
	{
		return false;
	}

	public DocumentContentStyleContainer z0gnk()
	{
		if (z0nzk == null)
		{
			z0nzk = new DocumentContentStyleContainer();
			z0nzk.z0eek(this);
		}
		return z0nzk;
	}

	public MeasureMode z0fnk()
	{
		return z0mvk;
	}

	public z0ZzZzrfh z0bek(int p0, bool p1, float p2, DocumentRenderMode p3)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("pageIndex=" + p0);
		}
		z0juk();
		if (p0 >= z0suk().Count)
		{
			throw new ArgumentOutOfRangeException("pageIndex=" + p0);
		}
		z0ZzZzocj z0ZzZzocj = new z0ZzZzocj();
		z0ZzZzocj.z0eek(this);
		z0ZzZzocj.z0rek(p0: true);
		z0ZzZzocj.z0eek(p0: true);
		z0ZzZzocj.z0rek(Color.Transparent);
		z0ZzZzxpk z0ZzZzxpk = (z0ZzZzxpk)z0ZzZzxcj.z0eek(p0: false, p0);
		if (!z0ZzZzxpk.z0yek)
		{
			z0ZzZzocj.z0eek(z0ZzZzxpk);
		}
		else
		{
			z0ZzZzocj.z0eek((z0ZzZzxpk)null);
		}
		if (z0yyk() != null)
		{
			z0ZzZzocj.z0eek(z0yyk().z0kyk());
		}
		else
		{
			z0ZzZzocj.z0eek(Color.White);
		}
		z0ZzZzocj.z0eek(z0suk());
		z0ZzZzocj.z0eek(z0iu().PageMarginLineLength);
		z0ZzZzocj.z0rek(p2);
		z0ZzZzocj.z0eek(p2);
		z0qtk().GenerateBmp = true;
		switch (p3)
		{
		case DocumentRenderMode.PDF:
			z0ZzZzocj.z0eek((z0ZzZzxej)4);
			z0qtk().GenerateBmp = false;
			z0qtk().GenerateLongBmp = false;
			z0qtk().PrintPreviewing = true;
			break;
		case DocumentRenderMode.Bitmap:
			z0ZzZzocj.z0eek((z0ZzZzxej)3);
			break;
		case DocumentRenderMode.Print:
			z0ZzZzocj.z0eek((z0ZzZzxej)1);
			z0qtk().GenerateBmp = false;
			z0qtk().GenerateLongBmp = false;
			z0qtk().PrintPreviewing = true;
			break;
		default:
			z0ZzZzocj.z0eek((z0ZzZzxej)0);
			break;
		}
		try
		{
			return z0ZzZzocj.z0eek(p0, p1);
		}
		finally
		{
			z0qtk().GenerateBmp = false;
			z0qtk().PrintPreviewing = false;
		}
	}

	internal static object z0dnk()
	{
		return z0ZzZzxcj.z0rek();
	}

	public void z0bek(z0ZzZzkkh p0)
	{
		if (!z0qzk || z0snk() || p0 == null || z0yyk() == null || z0yyk().z0jyk())
		{
			return;
		}
		foreach (XTextElement item in p0)
		{
			z0krk(item);
		}
	}

	public void z0bek(z0ZzZzpxj p0)
	{
		z0bvk = p0;
	}

	public byte[] z0mrk(string p0)
	{
		z0ipk().z0rek(z0jpk());
		MemoryStream memoryStream = new MemoryStream();
		z0bek(memoryStream, p0, p2: false, null);
		byte[] result = memoryStream.ToArray();
		memoryStream.Close();
		memoryStream = null;
		return result;
	}

	public void z0krk(XTextElementList p0)
	{
		if (p0 != null && z0bu().RemoveLastParagraphFlagWhenInsertDocument && p0.LastElement is XTextParagraphFlagElement)
		{
			p0.RemoveAt(p0.Count - 1);
		}
	}

	public bool z0snk()
	{
		return z0ezk > 0;
	}

	internal z0ZzZzoxj z0ank()
	{
		return base.z0uyk()?.z0drk();
	}

	internal z0ZzZzvxj z0bek(z0ZzZzjpk p0, z0ZzZzcxj p1 = (z0ZzZzcxj)0)
	{
		return new z0ZzZzvxj(this, p0, z0ZzZzbdh.z0xek, p1);
	}

	public void z0bek(XTextSubDocumentElement p0, bool p1)
	{
		z0gyk().z0ikk(this, p0, p1);
	}

	public bool z0qnk()
	{
		z0nik();
		return z0mpk().z0wv_jiejie20260327142557(this);
	}

	internal void z0wnk()
	{
		if (z0itk() != null)
		{
			DocumentEventArgs e = new DocumentEventArgs(z0jr(), z0itk(), DocumentEventStyles.ControlLostFoucs);
			e.Cursor = null;
			z0bek(z0itk(), e);
		}
	}

	public string z0ark(XTextElement p0)
	{
		if (z0ubk != null)
		{
			return z0ubk.z0uw(p0);
		}
		return null;
	}

	internal bool z0vek(XTextDocumentContentElement p0)
	{
		if (z0exk == p0)
		{
			return true;
		}
		if (z0exk == null && p0 is XTextDocumentBodyElement)
		{
			return true;
		}
		return false;
	}

	internal z0ZzZzwcj z0enk()
	{
		if (z0azk == null)
		{
			z0azk = new z0ZzZzwcj();
		}
		return z0azk;
	}

	public bool z0rnk()
	{
		bool flag = true;
		if (z0ipk().ShowHeaderBottomLine == DCBooleanValue.True)
		{
			return true;
		}
		if (z0ipk().ShowHeaderBottomLine == DCBooleanValue.False)
		{
			return false;
		}
		return z0iu().ShowHeaderBottomLine;
	}

	public bool z0vek(XTextElement p0, string p1)
	{
		return z0gyk().z0tkk(this, p0, p1);
	}

	public bool z0bek(string p0, object p1)
	{
		z0gpk().z0eek(p0, p1);
		return true;
	}

	public void z0bek(TextReader p0, string p1)
	{
		try
		{
			z0pok();
			z0bek(null, p0, p1, p3: false, XTextDocument.z0fmk.z0eek, null);
		}
		finally
		{
			z0smk();
		}
	}

	public string z0tnk()
	{
		return z0bck;
	}

	public void z0ynk()
	{
		z0ZzZzkxj z0ZzZzkxj = new z0ZzZzkxj(this);
		z0ZzZzkxj.ExcludeParagraphFlag = false;
		z0ZzZzkxj.ExcludeCharElement = false;
		foreach (XTextElement item in z0ZzZzkxj)
		{
			if (z0ZzZzkxj.CurrentParent is XTextContainerElement)
			{
				item.z0nu((XTextContainerElement)z0ZzZzkxj.CurrentParent);
			}
			item.z0bt(this);
			if (item is XTextContentElement)
			{
				((XTextContentElement)item).z0bek(p0: false);
			}
			else if (item is XTextTableElement)
			{
				((XTextTableElement)item).z0krk();
			}
		}
		z0ZzZzkxj.Dispose();
	}

	internal void z0nek(XTextContainerElement p0, string p1, int p2, int p3, zzz.z0ZzZzkuk<XTextElement> p4)
	{
		if (string.IsNullOrEmpty(p1))
		{
			return;
		}
		if (p1.IndexOf('\n') >= 0)
		{
			p1 = p1.Replace("\r\n", "\r", StringComparison.OrdinalIgnoreCase).Replace('\n', '\r');
		}
		bool parseCrLfAsLineBreakElement = z0bu().ParseCrLfAsLineBreakElement;
		int length = p1.Length;
		XTextDocument document = p0.z0jr();
		for (int i = 0; i < length; i++)
		{
			char c = p1[i];
			if (c == '\r')
			{
				if (parseCrLfAsLineBreakElement)
				{
					XTextLineBreakElement xTextLineBreakElement = new XTextLineBreakElement();
					xTextLineBreakElement.z0oek(p2);
					xTextLineBreakElement.z0oek(p0);
					p4.z0pek(xTextLineBreakElement);
				}
				else
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
					xTextParagraphFlagElement.z0oek(p3);
					xTextParagraphFlagElement.z0oek(p0);
					p4.z0pek(xTextParagraphFlagElement);
				}
			}
			else
			{
				XTextCharElement xTextCharElement = new XTextCharElement(c, p0, document, p2);
				if (XTextCharElement.z0tek((int)c) && i < length - 1)
				{
					xTextCharElement.z0rek((ushort)p1[++i]);
				}
				p4.z0pek(xTextCharElement);
			}
		}
	}

	public new bool z0cek(XTextElement p0, XTextElement p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("startElement");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("endElement");
		}
		XTextDocumentContentElement xTextDocumentContentElement = p0.z0qek();
		if (xTextDocumentContentElement != p1.z0qek())
		{
			throw new ArgumentException("两个元素不属于同一个区域");
		}
		if (z0jrk() != xTextDocumentContentElement)
		{
			xTextDocumentContentElement.z0sr();
		}
		XTextElement xTextElement = p0.z0hy();
		XTextElement xTextElement2 = p1.z0hy();
		if (xTextElement == null || xTextElement2 == null)
		{
			xTextElement = p0.z0hy();
			xTextElement2 = p1.z0hy();
			return false;
		}
		if (xTextElement.z0jrk() > xTextElement2.z0jrk())
		{
			return xTextDocumentContentElement.z0frk().z0tek(xTextElement.z0jrk(), xTextElement2.z0jrk() - xTextElement.z0jrk() - 1);
		}
		return xTextDocumentContentElement.z0frk().z0tek(xTextElement.z0jrk(), xTextElement2.z0jrk() - xTextElement.z0jrk() + 1);
	}

	public z0ZzZznzj z0unk()
	{
		if (z0dck == null)
		{
			z0dck = new z0ZzZznzj();
		}
		return z0dck;
	}

	internal List<byte[]> z0ink()
	{
		XTextElementList xTextElementList = z0nek<XTextImageElement>();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			Dictionary<byte[], List<XTextImageElement>> dictionary = new Dictionary<byte[], List<XTextImageElement>>(new z0ZzZzwyk());
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextImageElement xTextImageElement = (XTextImageElement)z0bpk.Current;
					xTextImageElement.z0htk = -1;
					byte[] array = xTextImageElement.z0ork();
					if (array != null && array.Length != 0)
					{
						List<XTextImageElement> list = null;
						if (!dictionary.TryGetValue(array, out list))
						{
							list = (dictionary[array] = new List<XTextImageElement>());
						}
						list.Add(xTextImageElement);
					}
				}
			}
			List<byte[]> list3 = new List<byte[]>(dictionary.Keys);
			for (int num = list3.Count - 1; num >= 0; num--)
			{
				List<XTextImageElement> list4 = dictionary[list3[num]];
				if (list4.Count <= 1)
				{
					dictionary.Remove(list3[num]);
					list3.RemoveAt(num);
					list4.Clear();
				}
			}
			for (int num2 = list3.Count - 1; num2 >= 0; num2--)
			{
				List<XTextImageElement> list5 = dictionary[list3[num2]];
				foreach (XTextImageElement item in list5)
				{
					item.z0htk = num2;
				}
				list5.Clear();
			}
			dictionary.Clear();
			if (list3.Count > 0)
			{
				return list3;
			}
		}
		return null;
	}

	public z0ZzZzdcj z0onk()
	{
		if (z0vbk == null)
		{
			z0vbk = new z0ZzZzdcj();
			z0vbk.z0rek(this);
		}
		return z0vbk;
	}

	public void z0lrk(int p0)
	{
		if (p0 < 0 || p0 > z0suk().Count)
		{
			throw new ArgumentOutOfRangeException("value=" + p0);
		}
		z0bek(z0suk()[p0]);
	}

	internal void z0pnk()
	{
		if (z0jzk)
		{
			z0jzk = false;
			if (z0yyk() != null)
			{
				z0yyk().z0uj(new WriterEventArgs(z0yyk(), this, null));
			}
		}
	}

	public z0ZzZzovj z0mnk()
	{
		return z0ZzZzovj.z0iek;
	}

	public bool z0bek(string p0, int p1, string p2, string p3, bool p4)
	{
		if (z0ki(p0) is XTextTableElement xTextTableElement && p1 >= 0 && p1 < xTextTableElement.z0stk().Count)
		{
			return z0bek((XTextContainerElement)xTextTableElement.z0stk()[p1], p2, p3, p4);
		}
		return false;
	}

	public PageViewMode z0nnk()
	{
		if (z0tyk())
		{
			return PageViewMode.Page;
		}
		if (z0xbk_jiejie20260327142557 == null)
		{
			return z0pzk;
		}
		return ((z0ZzZzqrj)z0xbk_jiejie20260327142557.z0ypk()).z0cek();
	}

	public XTextTableCellElement z0bnk()
	{
		return (XTextTableCellElement)z0bek(typeof(XTextTableCellElement), p1: true);
	}

	public JumpPrintInfo z0drk(float p0)
	{
		if (p0 == 0f)
		{
			JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
			jumpPrintInfo.PageIndex = 0;
			jumpPrintInfo.EndPageIndex = 0;
			if (z0abk != null && z0abk.Count > 0)
			{
				jumpPrintInfo.z0eek(z0abk[0]);
			}
			return jumpPrintInfo;
		}
		foreach (z0ZzZzwrj item in z0suk())
		{
			if (Math.Abs(item.z0irk() - p0) < 1f)
			{
				JumpPrintInfo jumpPrintInfo2 = new JumpPrintInfo();
				jumpPrintInfo2.z0eek(p0);
				jumpPrintInfo2.PageIndex = z0suk().IndexOf(item);
				jumpPrintInfo2.Position = 0f;
				jumpPrintInfo2.z0eek(item);
				return jumpPrintInfo2;
			}
		}
		if (p0 > ((XTextElement)z0xyk()).z0ltk() + ((XTextContentElement)z0xyk()).z0hrk() - 1f)
		{
			return null;
		}
		z0ZzZzszj z0ZzZzszj = new z0ZzZzszj();
		z0ZzZzszj.z0grk = p0;
		z0ZzZzszj.z0ork = 0f;
		z0ZzZzszj.z0yrk = true;
		if (z0bu().SpecifyDebugMode)
		{
			z0ZzZzszj.z0yrk = false;
		}
		z0xyk().z0eek(z0ZzZzszj);
		if (z0ZzZzszj.z0oek() > 0f)
		{
			JumpPrintInfo jumpPrintInfo3 = new JumpPrintInfo();
			jumpPrintInfo3.z0eek(p0);
			foreach (z0ZzZzwrj item2 in z0suk())
			{
				if (z0ZzZzszj.z0oek() >= item2.z0irk() && z0ZzZzszj.z0oek() < item2.z0qrk())
				{
					jumpPrintInfo3.PageIndex = z0suk().IndexOf(item2);
					jumpPrintInfo3.Position = (int)(z0ZzZzszj.z0oek() - item2.z0irk());
					jumpPrintInfo3.AbsPosition = z0ZzZzszj.z0oek();
				}
			}
			jumpPrintInfo3.z0eek(z0suk().z0rek(jumpPrintInfo3.PageIndex));
			return jumpPrintInfo3;
		}
		return null;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextDocument xTextDocument = (XTextDocument)base.z0lr(p0);
		xTextDocument.z0kzk = null;
		xTextDocument.z0we();
		xTextDocument.z0ubk = null;
		xTextDocument.z0qrk(p0: false);
		xTextDocument.z0wck = false;
		xTextDocument.z0pxk = null;
		xTextDocument.z0wvk = null;
		xTextDocument.z0ixk = z0flj++;
		xTextDocument.z0azk = null;
		xTextDocument.z0yek(xTextDocument);
		xTextDocument.z0dck = null;
		xTextDocument.z0dck = null;
		xTextDocument.z0kck = false;
		xTextDocument.z0qck = null;
		xTextDocument.z0czk = null;
		xTextDocument.z0aok();
		xTextDocument.z0nck = null;
		xTextDocument.z0sbk = null;
		xTextDocument.z0ibk = null;
		xTextDocument.z0vzk = null;
		xTextDocument.z0wzk = null;
		xTextDocument.z0dlj = new z0ZzZzmcj();
		xTextDocument.z0jck = null;
		xTextDocument.z0izk = null;
		xTextDocument.z0fzk = null;
		xTextDocument.z0sbk = null;
		xTextDocument.z0xbk_jiejie20260327142557 = null;
		xTextDocument.z0klj = null;
		xTextDocument.z0xxk = null;
		xTextDocument.z0ibk = null;
		xTextDocument.z0lck = null;
		xTextDocument.z0ovk = null;
		xTextDocument.z0jck = null;
		xTextDocument.z0txk = null;
		xTextDocument.z0exk = null;
		xTextDocument.z0nvk = null;
		xTextDocument.z0vbk = null;
		xTextDocument.z0bvk = null;
		xTextDocument.z0ubk = null;
		xTextDocument.z0xnk = null;
		xTextDocument.z0czk = null;
		xTextDocument.z0glj = null;
		xTextDocument.z0qbk = null;
		xTextDocument.z0cck = null;
		xTextDocument.z0qck = null;
		xTextDocument.z0zzk = null;
		xTextDocument.z0oxk = null;
		xTextDocument.z0vzk = null;
		xTextDocument.z0abk = null;
		xTextDocument.z0alj = null;
		xTextDocument.z0lzk = null;
		xTextDocument.z0bek(this, p1: false);
		if (p0)
		{
			if (((XTextContainerElement)xTextDocument).z0crk())
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocument.z0be().z0ltk();
				while (z0bpk.MoveNext())
				{
					z0bpk.Current.z0bt(xTextDocument);
				}
			}
			if (z0gck != null)
			{
				xTextDocument.z0gck = z0gck.z0eek(p0);
			}
			xTextDocument.z0nzk = (DocumentContentStyleContainer)((z0ZzZzxok)z0gnk()).z0eek();
			if (z0obk != null)
			{
				xTextDocument.z0obk = z0obk.z0uek();
			}
			if (z0wzk != null && z0wzk.Count > 0)
			{
				xTextDocument.z0wzk = z0wzk.z0eek();
			}
			else
			{
				xTextDocument.z0wzk = null;
			}
		}
		else
		{
			xTextDocument.z0gck = null;
			xTextDocument.z0nzk = null;
			xTextDocument.z0obk = null;
		}
		xTextDocument.z0li();
		return xTextDocument;
	}
}
