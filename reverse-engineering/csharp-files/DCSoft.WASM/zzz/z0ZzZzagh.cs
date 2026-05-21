using System.IO;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzagh : z0ZzZzphh
{
	public override string z0js()
	{
		return z0ZzZzkfh.z0mrk;
	}

	public override string z0ks()
	{
		return z0ZzZziok.z0fik();
	}

	public z0ZzZzagh()
	{
		z0eek(Encoding.Default);
	}

	public override string z0ls()
	{
		return ".txt";
	}

	public override bool z0zd(Stream p0, XTextDocument p1, z0ZzZzohh p2)
	{
		using (StreamReader streamReader = new StreamReader(p0, Encoding.Default, true))
		{
			string text = streamReader.ReadToEnd();
			p1.z0duk();
			p1.Text = text;
		}
		return true;
	}

	public override bool z0xd(TextReader p0, XTextDocument p1, z0ZzZzohh p2)
	{
		string text = p0.ReadToEnd();
		p1.z0duk();
		p1.Text = text;
		return true;
	}

	public override bool z0cd(Stream p0, XTextDocument p1, z0ZzZzohh p2)
	{
		using (StreamWriter streamWriter = new StreamWriter(p0, Encoding.Default))
		{
			string text = p1.Text;
			streamWriter.Write(text);
		}
		return true;
	}

	public override bool z0vd(TextWriter p0, XTextDocument p1, z0ZzZzohh p2)
	{
		p0.Write(p1.Text);
		return true;
	}

	public override z0ZzZzmhh z0bd()
	{
		return (z0ZzZzmhh)15;
	}
}
