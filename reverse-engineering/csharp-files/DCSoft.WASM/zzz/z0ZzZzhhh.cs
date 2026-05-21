using System;
using System.IO;
using System.Text;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzhhh : z0ZzZzphh
{
	private new static readonly string z0rek = ".json";

	private static readonly string z0tek = "json";

	private static readonly z0ZzZzhhh z0yek = new z0ZzZzhhh();

	public override bool z0vd(TextWriter p0, XTextDocument p1, z0ZzZzohh p2)
	{
		bool flag = (p1.z0vtk().BehaviorOptions.AutoCreateInstanceInProperty = false);
		bool autoCreateInstanceInProperty = flag;
		if (DocumentBehaviorOptions.GlobalSpecifyDebugMode)
		{
			try
			{
				z0ZzZzghh.z0tek(p0, p1);
			}
			catch (Exception ex)
			{
				z0ZzZzqok.z0rek.z0dh(ex.ToString());
				throw ex;
			}
			finally
			{
				p1.z0vtk().BehaviorOptions.AutoCreateInstanceInProperty = autoCreateInstanceInProperty;
			}
		}
		else
		{
			try
			{
				z0ZzZzghh.z0tek(p0, p1);
			}
			finally
			{
				p1.z0vtk().BehaviorOptions.AutoCreateInstanceInProperty = autoCreateInstanceInProperty;
			}
		}
		p0.Flush();
		return true;
	}

	public override string z0ls()
	{
		return z0rek;
	}

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
				encoding = Encoding.GetEncoding(p0.z0vtk().BehaviorOptions.XMLContentEncodingName);
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
		return z0ZzZziok.z0dok();
	}

	public new static z0ZzZzhhh z0eek()
	{
		return z0yek;
	}

	public override bool z0sq(XTextDocument p0)
	{
		return false;
	}

	public override string z0js()
	{
		return z0tek;
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

	public override int z0dq()
	{
		return 2;
	}

	public override bool z0fq(XTextDocument p0)
	{
		return false;
	}

	public override bool z0xd(TextReader p0, XTextDocument p1, z0ZzZzohh p2)
	{
		p1.z0rpk();
		if (DocumentBehaviorOptions.GlobalSpecifyDebugMode)
		{
			try
			{
				XTextElementList.z0mek(p0: true);
				z0ZzZzghh.z0tek(p0, p1);
			}
			catch (Exception ex)
			{
				z0ZzZzqok.z0rek.z0sh(ex.ToString());
				throw ex;
			}
			finally
			{
				XTextElementList.z0mek(p0: false);
			}
		}
		else
		{
			try
			{
				XTextElementList.z0mek(p0: true);
				z0ZzZzghh.z0tek(p0, p1);
			}
			finally
			{
				XTextElementList.z0mek(p0: false);
			}
		}
		if (p1 == null)
		{
			return false;
		}
		if (p1.z0ipk().z0rek() == 0.5f)
		{
			p1.z0ipk().z0eek(1f);
		}
		return true;
	}

	public z0ZzZzhhh()
	{
		z0eek(null);
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
}
