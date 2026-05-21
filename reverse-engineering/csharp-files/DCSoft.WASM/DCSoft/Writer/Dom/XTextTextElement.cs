using System.Text;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XString")]
public sealed class XTextTextElement : XTextElement
{
	private new string z0uek;

	private new int z0iek;

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	internal void z0eek()
	{
		if (z0iek > 0)
		{
			z0uek = z0ZzZzafh.z0uek(z0iek);
		}
	}

	public override string ToString()
	{
		return z0uek;
	}

	public int z0rek()
	{
		return 0;
	}

	public void z0eek(string p0)
	{
		z0uek = p0;
		if (p0 == null || p0.Length <= 0)
		{
			return;
		}
		int num = p0.IndexOf('\u2002');
		if (num < 0)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder(p0.Length);
		if (num > 0)
		{
			stringBuilder.Append(p0, 0, num);
		}
		stringBuilder.Append(' ');
		int length = p0.Length;
		for (int i = num + 1; i < length; i++)
		{
			char c = p0[i];
			if (c == '\u2002')
			{
				stringBuilder.Append(' ');
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		z0uek = stringBuilder.ToString();
	}

	public void z0eek(int p0)
	{
		z0iek = p0;
	}

	public XTextTextElement(string txt)
	{
		z0uek = txt;
	}

	public string z0tek()
	{
		return z0uek;
	}

	public void z0rek(int p0)
	{
		z0iek = p0;
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		p0.z0eek(z0uek);
	}

	public new int z0yek()
	{
		return z0iek;
	}

	public XTextTextElement()
	{
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(z0uek);
	}
}
