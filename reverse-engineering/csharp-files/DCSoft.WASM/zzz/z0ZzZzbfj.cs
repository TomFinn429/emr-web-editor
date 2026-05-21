using System.Collections.Generic;
using System.Text;

namespace zzz;

internal abstract class z0ZzZzbfj : z0ZzZzygj
{
	private readonly string z0pek;

	private readonly z0ZzZzwdj z0mek;

	private readonly z0ZzZziqj z0nek;

	private readonly string z0bek;

	internal z0ZzZzwdj z0eek()
	{
		return z0mek;
	}

	internal abstract double z0gdk(int p0);

	internal bool z0rek()
	{
		return (z0nek & (z0ZzZziqj)8) != 0;
	}

	internal virtual string z0kdk()
	{
		return z0pek;
	}

	internal string z0tek()
	{
		return z0pek;
	}

	internal abstract byte[] z0jdk(IDictionary<int, string> p0);

	internal bool z0yek()
	{
		if (!(z0kdk() == "Symbol"))
		{
			return z0kdk() == "SymbolMT";
		}
		return true;
	}

	protected z0ZzZzbfj(string p0, z0ZzZziqj p1, z0ZzZzwdj p2)
	{
		z0bek = p0;
		z0nek = p1;
		z0mek = p2;
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in p0)
		{
			if (c != ' ' && c != '\r' && c != '\n')
			{
				stringBuilder.Append(c);
			}
		}
		string text = string.Empty;
		if (z0uek())
		{
			text += "Bold";
		}
		if (z0iek())
		{
			text += "Italic";
		}
		if (!string.IsNullOrEmpty(text))
		{
			stringBuilder.Append(",");
			stringBuilder.Append(text);
		}
		z0pek = stringBuilder.ToString();
	}

	internal bool z0uek()
	{
		return (z0nek & (z0ZzZziqj)1) != 0;
	}

	internal abstract bool z0ddk();

	internal bool z0iek()
	{
		return (z0nek & (z0ZzZziqj)2) != 0;
	}

	internal abstract bool z0fdk();

	internal abstract z0ZzZzvfj z0hdk();

	internal bool z0oek()
	{
		return (z0nek & (z0ZzZziqj)4) != 0;
	}
}
