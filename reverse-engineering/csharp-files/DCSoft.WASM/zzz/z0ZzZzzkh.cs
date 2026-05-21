using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzzkh : z0ZzZzqfh
{
	private char z0tek = '}';

	private char z0yek = '{';

	public new char z0eek()
	{
		return z0yek;
	}

	protected override z0ZzZzvvj z0gw(XTextElement p0, XTextElement p1, bool p2)
	{
		if (p1 is XTextCharElement)
		{
			char c = ((XTextCharElement)p1).z0mek();
			if (char.IsLetterOrDigit(c))
			{
				return (z0ZzZzvvj)0;
			}
			if (p2 && c == z0yek)
			{
				return (z0ZzZzvvj)2;
			}
			if (!p2 && c == z0tek)
			{
				return (z0ZzZzvvj)2;
			}
			return (z0ZzZzvvj)3;
		}
		return (z0ZzZzvvj)3;
	}

	public void z0eek(char p0)
	{
		if (z0tek != p0)
		{
			z0tek = p0;
			base.z0eek();
		}
	}

	public void z0rek(char p0)
	{
		if (z0yek != p0)
		{
			z0yek = p0;
			base.z0eek();
		}
	}

	public new char z0rek()
	{
		return z0tek;
	}
}
