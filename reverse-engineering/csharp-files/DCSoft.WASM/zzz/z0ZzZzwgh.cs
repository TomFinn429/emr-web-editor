using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzwgh : z0ZzZzphh
{
	public delegate XTextDocument z0zpk(z0ZzZzcah reader, XTextDocument instance);

	private static readonly z0ZzZzwgh z0tek = new z0ZzZzwgh();

	private static readonly string z0yek = "XML";

	private static readonly string[] z0uek = new string[22]
	{
		"<Attributes />", "<Expressions />", "<XElements />", "<ValueBinding />", "<BorderElementColor />", "<EventExpressions />", "<LabelText />", "<PageTexts />", "<PropertyExpressions />", "<XElements xsi:nil=\"true\" />",
		"<LastSelectedListItems />", "<SourceName />", "<TextInList />", "<Group />", "<ListValueFormatString />", "<PageImages />", "<InnerValue />", "<Name />", "<FieldSettings />", "<StartBorderText />",
		"<EndBorderText />", "<Value />"
	};

	public static z0ZzZztyk z0iek = null;

	public static z0zpk z0oek = null;

	private static readonly string z0pek = ".xml";

	private Encoding z0eek(XTextDocument p0, z0ZzZzohh p1)
	{
		Encoding encoding = p1.ContentEncoding;
		if (encoding == null)
		{
			encoding = z0rek();
		}
		if (encoding == null && !string.IsNullOrEmpty(p0.z0vtk().BehaviorOptions.XMLContentEncodingName))
		{
			try
			{
				encoding = z0ZzZzqik.z0iek(p0.z0vtk().BehaviorOptions.XMLContentEncodingName);
			}
			catch (Exception ex)
			{
				z0ZzZzqok.z0rek.z0dh(ex.Message);
			}
		}
		if (encoding == null)
		{
			encoding = Encoding.UTF8;
		}
		return encoding;
	}

	public override z0ZzZzmhh z0bd()
	{
		return (z0ZzZzmhh)15;
	}

	public override string z0ks()
	{
		return z0ZzZziok.z0jtk();
	}

	public new static z0ZzZzwgh z0eek()
	{
		return z0tek;
	}

	public bool z0eek(z0ZzZzcah p0, XTextDocument p1, z0ZzZzohh p2)
	{
		XTextDocument xTextDocument = null;
		if (DocumentBehaviorOptions.GlobalSpecifyDebugMode)
		{
			try
			{
				XTextElementList.z0mek(p0: true);
				xTextDocument = z0oek(p0, null);
				z0rek(xTextDocument);
			}
			catch (Exception ex)
			{
				z0ZzZzqok.z0rek.z0dh(ex.ToString());
				throw ex;
			}
			finally
			{
				XTextImageElement.z0ftk = null;
				XTextElementList.z0mek(p0: false);
			}
		}
		else
		{
			try
			{
				XTextElementList.z0mek(p0: true);
				xTextDocument = z0oek(p0, null);
				z0rek(xTextDocument);
			}
			finally
			{
				XTextImageElement.z0ftk = null;
				XTextElementList.z0mek(p0: false);
			}
		}
		if (xTextDocument == null)
		{
			return false;
		}
		if (xTextDocument.z0ipk().z0rek() == 0.5f)
		{
			xTextDocument.z0ipk().z0eek(1f);
		}
		p1.z0bek(xTextDocument, p1: true, p2: true);
		xTextDocument.Dispose();
		xTextDocument = null;
		return true;
	}

	private void z0eek(XTextDocument p0)
	{
		if (p0.z0ptk())
		{
			XTextImageElement.z0ftk = new object();
			List<byte[]> p1 = p0.z0ink();
			p0.z0pek(p1);
		}
		else
		{
			p0.z0pek(null);
		}
	}

	public z0ZzZzwgh()
	{
		z0eek((Encoding)null);
	}

	public override int z0dq()
	{
		return -1;
	}

	public override bool z0hs(XTextDocument p0)
	{
		return false;
	}

	public override bool z0cd(Stream p0, XTextDocument p1, z0ZzZzohh p2)
	{
		Encoding encoding = z0eek(p1, p2);
		StreamWriter p3 = new StreamWriter(p0, encoding);
		return z0vd(p3, p1, p2);
	}

	public static bool z0eek(string p0)
	{
		if (p0 != null)
		{
			_ = p0.Length;
			_ = 0;
		}
		return false;
	}

	public override bool z0zd(Stream p0, XTextDocument p1, z0ZzZzohh p2)
	{
		if (p0 is z0ZzZziuk)
		{
			z0ZzZziuk z0ZzZziuk2 = (z0ZzZziuk)p0;
			Encoding p3 = z0eek(p1, p2);
			z0ZzZziuk2.Position += z0ZzZzpuk.z0eek(z0ZzZziuk2.z0eek(), (int)z0ZzZziuk2.Position, ref p3);
			if (p3 == null)
			{
				p3 = Encoding.UTF8;
			}
			StringReader p4 = new StringReader(p3.GetString(z0ZzZziuk2.z0eek(), (int)z0ZzZziuk2.Position, (int)(z0ZzZziuk2.Length - z0ZzZziuk2.Position)));
			return z0xd(p4, p1, p2);
		}
		StringReader p5 = new StringReader(new StreamReader(p0, z0eek(p1, p2), true).ReadToEnd());
		return z0xd(p5, p1, p2);
	}

	public override bool z0xd(TextReader p0, XTextDocument p1, z0ZzZzohh p2)
	{
		z0ZzZzcah z0ZzZzcah2 = null;
		if (z0ZzZzcah2 == null)
		{
			string p3 = p0.ReadToEnd();
			z0ZzZzcah2 = z0ZzZzhbj.JSProvider?.z0wlk(p3);
		}
		if (z0ZzZzcah2 == null)
		{
			throw new InvalidOperationException("创建XML读取器错误");
		}
		return z0eek(z0ZzZzcah2, p1, p2);
	}

	public override string z0ls()
	{
		return z0pek;
	}

	public override bool z0vd(TextWriter p0, XTextDocument p1, z0ZzZzohh p2)
	{
		z0ZzZzxuk z0ZzZzxuk2 = z0iek();
		bool compressXMLContent = p1.z0vtk().BehaviorOptions.CompressXMLContent;
		bool flag = p1.z0hnk();
		z0ZzZzhqh z0ZzZzhqh2 = null;
		StringWriter stringWriter = null;
		if (compressXMLContent || flag)
		{
			stringWriter = new StringWriter();
			z0ZzZzhqh2 = new z0ZzZzhqh(stringWriter);
			if (p2.Formated && !compressXMLContent)
			{
				z0ZzZzhqh2.z0eek((z0ZzZzesh)1);
				z0ZzZzhqh2.z0rek(3);
				z0ZzZzhqh2.z0eek(' ');
			}
			else
			{
				z0ZzZzhqh2.z0eek((z0ZzZzesh)0);
			}
		}
		else
		{
			z0ZzZzhqh2 = new z0ZzZzhqh(p0);
			if (p2.Formated)
			{
				z0ZzZzhqh2.z0eek((z0ZzZzesh)1);
				z0ZzZzhqh2.z0rek(3);
				z0ZzZzhqh2.z0eek(' ');
			}
			else
			{
				z0ZzZzhqh2.z0eek((z0ZzZzesh)0);
			}
		}
		bool flag2 = (p1.z0vtk().BehaviorOptions.AutoCreateInstanceInProperty = false);
		bool autoCreateInstanceInProperty = flag2;
		XTextDocument.z0szk = true;
		if (DocumentBehaviorOptions.GlobalSpecifyDebugMode)
		{
			try
			{
				z0eek(p1);
				z0ZzZzxuk2.z0qq(z0ZzZzhqh2, p1);
			}
			catch (Exception ex)
			{
				z0ZzZzqok.z0rek.z0dh(ex.ToString());
				throw ex;
			}
			finally
			{
				XTextDocument.z0szk = false;
				XTextImageElement.z0ftk = null;
				p1.z0pek(null);
				p1.z0vtk().BehaviorOptions.AutoCreateInstanceInProperty = autoCreateInstanceInProperty;
			}
		}
		else
		{
			try
			{
				z0eek(p1);
				z0ZzZzxuk2.z0qq(z0ZzZzhqh2, p1);
			}
			finally
			{
				XTextDocument.z0szk = false;
				XTextImageElement.z0ftk = null;
				p1.z0pek(null);
				p1.z0vtk().BehaviorOptions.AutoCreateInstanceInProperty = autoCreateInstanceInProperty;
			}
		}
		if (compressXMLContent || flag)
		{
			z0ZzZzhqh2.z0lf();
			z0ZzZzhqh2.z0kf();
			stringWriter.Close();
			StringBuilder stringBuilder = stringWriter.GetStringBuilder();
			string[] array = z0uek;
			foreach (string text in array)
			{
				stringBuilder.Replace(text, string.Empty);
			}
			string text2 = stringWriter.ToString();
			p0.Write(text2);
		}
		p0.Flush();
		return true;
	}

	public override string z0js()
	{
		return z0yek;
	}

	private void z0rek(XTextDocument p0)
	{
		XTextDocumentBodyElement xTextDocumentBodyElement = ((XTextContainerElement)p0).z0ntk?.z0srk<XTextDocumentBodyElement>();
		if (xTextDocumentBodyElement != null && xTextDocumentBodyElement.z0ntk != null && xTextDocumentBodyElement.z0ntk.Count > 0 && xTextDocumentBodyElement.z0ntk.Count < 100)
		{
			XTextElementList z0ntk = xTextDocumentBodyElement.z0ntk;
			for (int num = z0ntk.Count - 1; num >= 0; num--)
			{
				if (z0ntk[num] is XTextDocument)
				{
					XTextDocumentBodyElement xTextDocumentBodyElement2 = ((XTextContainerElement)(XTextDocument)z0ntk[num]).z0ntk?.z0srk<XTextDocumentBodyElement>();
					if (xTextDocumentBodyElement2 != null)
					{
						XTextSubDocumentElement xTextSubDocumentElement = new XTextSubDocumentElement();
						xTextSubDocumentElement.z0ntk = xTextDocumentBodyElement2.z0ntk;
						z0ntk[num] = xTextSubDocumentElement;
					}
				}
			}
		}
		if (!p0.z0ptk() || p0.z0fyk() == null || p0.z0fyk().Count <= 0)
		{
			return;
		}
		XTextImageElement.z0ftk = null;
		List<byte[]> list = p0.z0fyk();
		p0.z0pek(null);
		XTextElementList xTextElementList = p0.z0nek<XTextImageElement>();
		if (xTextElementList == null)
		{
			return;
		}
		foreach (XTextImageElement item in xTextElementList.z0xrk())
		{
			if (item.z0iek() >= 0 && item.z0iek() < list.Count)
			{
				item.z0rek(list[item.z0iek()]);
			}
			item.z0eek(-1);
		}
	}
}
