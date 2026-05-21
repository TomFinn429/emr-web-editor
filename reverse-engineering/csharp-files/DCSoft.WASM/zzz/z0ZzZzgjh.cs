using System;
using System.IO;
using System.Text;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzgjh : z0ZzZzphh
{
	public override z0ZzZzmhh z0bd()
	{
		return (z0ZzZzmhh)15;
	}

	public override string z0ks()
	{
		return z0ZzZziok.z0mek();
	}

	public override string z0ls()
	{
		return ".htm";
	}

	public override bool z0hs(XTextDocument p0)
	{
		return true;
	}

	public z0ZzZzgjh()
	{
		z0eek(Encoding.Default);
	}

	public override bool z0vd(TextWriter p0, XTextDocument p1, z0ZzZzohh p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("writer");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("document");
		}
		z0ZzZzrjh obj = new z0ZzZzrjh();
		obj.z0zek().Add(p1);
		obj.z0rek(p2.IncludeSelectionOnly);
		obj.Options.ViewStyle = (z0ZzZzlgh)0;
		obj.Options.BackgroundTextOutputMode = DCBackgroundTextOutputMode.Output;
		obj.Options.IndentHtmlCode = p1.z0vtk()?.BehaviorOptions.OutputFormatedXMLSource ?? false;
		obj.Options.ContentEncoding = p2.ContentEncoding;
		obj.Options.UseClassAttribute = false;
		obj.Options.ForPrint = p2.ForPrint;
		obj.z0oek();
		obj.z0yek(p0);
		return true;
	}

	public override bool z0zd(Stream p0, XTextDocument p1, z0ZzZzohh p2)
	{
		z0ZzZzkbk z0ZzZzkbk2 = new z0ZzZzkbk();
		z0ZzZzkbk2.z0yek(p2.BasePath);
		if (string.IsNullOrEmpty(z0ZzZzkbk2.z0mek()))
		{
			z0ZzZzkbk2.z0yek(p1.z0uok());
		}
		z0ZzZzkbk2.z0eek(p0);
		z0eek(z0ZzZzkbk2, p1);
		z0ZzZzkbk2.Dispose();
		return true;
	}

	private void z0eek(z0ZzZzkbk p0, XTextDocument p1)
	{
		p1.z0bek((z0ZzZzzcj)1);
		p1.z0fmk();
		p1.z0cek(p0.z0yek());
		p1.z0rrk(z0ZzZzkfh.z0ltk);
		p1.z0ipk().z0vek(p0.z0iek());
		p1.z0rpk();
		p1.z0pyk().z0be().Clear();
		p1.z0lik().z0be().Clear();
		p1.z0xyk().z0be().Clear();
		z0ZzZzjjh obj = new z0ZzZzjjh(p1, p0, null);
		obj.z0tek(p1, p0);
		obj.Dispose();
		p1.z0bek((z0ZzZzzcj)2);
		p1.z0li();
		p1.z0pyk().z0gu();
		p1.z0xyk().z0gu();
		p1.z0lik().z0gu();
	}

	public override bool z0cd(Stream p0, XTextDocument p1, z0ZzZzohh p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("document");
		}
		z0ZzZzrjh obj = new z0ZzZzrjh();
		obj.z0zek().Add(p1);
		obj.z0rek(p2.IncludeSelectionOnly);
		obj.Options.ViewStyle = (z0ZzZzlgh)0;
		obj.Options.BackgroundTextOutputMode = DCBackgroundTextOutputMode.Output;
		obj.Options.IndentHtmlCode = p1.z0vtk()?.BehaviorOptions.OutputFormatedXMLSource ?? false;
		obj.Options.UseClassAttribute = false;
		obj.Options.ContentEncoding = p2.ContentEncoding;
		obj.Options.ForPrint = true;
		obj.z0oek();
		obj.z0yek(p0);
		return true;
	}

	public override bool z0xd(TextReader p0, XTextDocument p1, z0ZzZzohh p2)
	{
		z0ZzZzkbk z0ZzZzkbk2 = new z0ZzZzkbk();
		z0ZzZzkbk2.z0yek(p2.BasePath);
		if (string.IsNullOrEmpty(z0ZzZzkbk2.z0mek()))
		{
			z0ZzZzkbk2.z0yek(p1.z0uok());
		}
		z0ZzZzkbk2.z0eek(p0);
		z0eek(z0ZzZzkbk2, p1);
		return true;
	}

	public override string z0js()
	{
		return z0ZzZzkfh.z0ltk;
	}
}
