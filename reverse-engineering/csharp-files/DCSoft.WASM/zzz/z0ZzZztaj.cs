using System.IO;
using System.Text;

namespace zzz;

internal class z0ZzZztaj
{
	private static readonly string z0yek = "rdf";

	private readonly StringBuilder z0uek = new StringBuilder();

	private static readonly string z0iek = "http://ns.adobe.com/pdf/1.3/";

	private static readonly string z0oek = "http://www.aiim.org/pdfa/ns/id/";

	private readonly z0ZzZzhqh z0pek;

	private static readonly string z0mek = "http://ns.adobe.com/xap/1.0/";

	internal z0ZzZztaj()
	{
		z0pek = new z0ZzZzhqh(new StringWriter(z0uek));
		z0pek.z0pg("xpacket", "begin=\"\" id=\"dcwriter5\"");
		z0pek.z0eek("x:xmpmeta");
		z0pek.z0eek("xmlns:x", "adobe:ns:meta/");
		z0pek.z0eek("rdf:RDF");
		z0pek.z0eek("xmlns:rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
		z0pek.z0eek("rdf:Description");
		z0pek.z0eek("rdf:about", string.Empty);
		z0pek.z0eek("xmlns:pdfaid", z0oek);
		z0pek.z0eek("xmlns:pdf", "http://ns.adobe.com/pdf/1.3/");
		z0pek.z0eek("xmlns:dc", "http://purl.org/dc/elements/1.1/");
		z0pek.z0eek("xmlns:xmp", z0mek);
	}

	internal void z0eek(int p0)
	{
		z0eek("pdfaid", "part", z0oek, p0.ToString());
		z0eek("pdfaid", "conformance", z0oek, "B");
	}

	internal void z0eek(string p0)
	{
		z0pek.z0eek(z0yek + ":" + p0);
	}

	internal void z0eek(string p0, string p1, bool p2, string p3)
	{
		if (p3 != null)
		{
			z0rek(p0);
			z0eek(p1);
			z0eek("li");
			if (p2)
			{
				z0pek.z0eek("xml:lang", "x-default");
			}
			z0pek.z0yg(p3);
			z0pek.z0bg();
			z0pek.z0bg();
			z0pek.z0bg();
		}
	}

	internal void z0eek(string p0, string p1)
	{
		z0eek("pdf", p0, z0iek, p1);
	}

	internal void z0rek(string p0, string p1)
	{
		z0eek("xmp", p0, z0mek, p1);
	}

	internal void z0eek()
	{
		z0pek.z0bg();
	}

	internal void z0rek(string p0)
	{
		z0pek.z0eek("dc:" + p0);
	}

	private void z0eek(string p0, string p1, string p2, string p3)
	{
		if (p3 != null)
		{
			z0pek.z0eek(p0 + ":" + p1);
			z0pek.z0yg(p3);
			z0pek.z0bg();
		}
	}

	internal void z0tek(string p0, string p1)
	{
		z0eek(p0);
		z0pek.z0yg(p1);
		z0pek.z0bg();
	}

	internal string z0tek(string p0)
	{
		z0pek.z0bg();
		if (!string.IsNullOrEmpty(p0))
		{
			z0pek.z0og(p0);
		}
		z0pek.z0bg();
		z0pek.z0bg();
		z0pek.z0pg("xpacket", "end=\"w\"");
		z0pek.z0lf();
		return z0uek.ToString();
	}
}
