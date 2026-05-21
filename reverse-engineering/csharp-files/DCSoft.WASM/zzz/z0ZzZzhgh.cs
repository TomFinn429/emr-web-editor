using System;
using System.IO;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzhgh : z0ZzZzphh
{
	private new static readonly Encoding z0eek = z0ZzZzqik.z0eek(936);

	public z0ZzZzhgh()
	{
		z0eek(Encoding.Default);
	}

	public override string z0js()
	{
		return z0ZzZzkfh.z0nek;
	}

	public override bool z0cd(Stream p0, XTextDocument p1, z0ZzZzohh p2)
	{
		return z0vd(new StreamWriter(p0, z0eek), p1, p2);
	}

	public override bool z0zd(Stream p0, XTextDocument p1, z0ZzZzohh p2)
	{
		return z0xd(new StreamReader(p0, z0eek), p1, p2);
	}

	public override string z0ls()
	{
		return ".rtf";
	}

	public override string z0ks()
	{
		return z0ZzZziok.z0zyk();
	}

	public override bool z0hs(XTextDocument p0)
	{
		return true;
	}

	public override bool z0xd(TextReader p0, XTextDocument p1, z0ZzZzohh p2)
	{
		z0ZzZzbhh z0ZzZzbhh2 = new z0ZzZzbhh();
		if (z0ZzZzbhh2 == null)
		{
			return false;
		}
		z0ZzZzbhh2.z0vs(p2.EnableDocumentSetting);
		z0ZzZzbhh2.z0cs(p2.ImportTemplateGenerateParagraph);
		z0ZzZzbhh2.z0bs(p0);
		z0ZzZzbhh2.z0ns_jiejie20260327142557(p1);
		return true;
	}

	public override z0ZzZzmhh z0bd()
	{
		return (z0ZzZzmhh)15;
	}

	public override bool z0vd(TextWriter p0, XTextDocument p1, z0ZzZzohh p2)
	{
		Encoding p3 = null;
		try
		{
			p3 = z0ZzZzqik.z0eek(p1.z0bu().EncodingCodePageForWriteRTF);
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh(ex.ToString());
		}
		z0ZzZzjgh z0ZzZzjgh2 = z0ZzZzuok.z0eek<z0ZzZzjgh>();
		if (z0ZzZzjgh2 == null)
		{
			return false;
		}
		z0ZzZzjgh2.z0rs(p0);
		z0ZzZzjgh2.z0es(p3);
		z0ZzZzjgh2.z0eek(p1);
		z0ZzZzjgh2.z0gs(p2.IncludeSelectionOnly);
		z0ZzZzjgh2.z0ds(!p1.z0hi().ShowLogicDeletedContent);
		z0ZzZzjgh2.z0us();
		return true;
	}
}
