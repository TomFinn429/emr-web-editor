using System;
using System.Text;

namespace zzz;

public class z0ZzZzgah : z0ZzZztah
{
	private string z0yek;

	private new string z0oek;

	private string z0pek;

	public override string z0th()
	{
		return "xml";
	}

	public override z0ZzZzbah z0mh()
	{
		return (z0ZzZzbah)17;
	}

	public override string z0eg()
	{
		StringBuilder stringBuilder = z0ZzZzwfh.z0eek();
		stringBuilder.Append("version=\"");
		stringBuilder.Append(z0tek());
		stringBuilder.Append('"');
		if (z0rek().Length > 0)
		{
			stringBuilder.Append(" encoding=\"");
			stringBuilder.Append(z0rek());
			stringBuilder.Append('"');
		}
		if (z0eek().Length > 0)
		{
			stringBuilder.Append(" standalone=\"");
			stringBuilder.Append(z0eek());
			stringBuilder.Append('"');
		}
		return z0ZzZzwfh.z0eek(stringBuilder);
	}

	private new static bool z0eek(string p0)
	{
		if (p0.Length >= 3 && p0[0] == '1' && p0[1] == '.')
		{
			return z0ZzZzzsh.z0eek(p0, 2, p0.Length - 2);
		}
		return false;
	}

	public override void z0uh(z0ZzZzdqh p0)
	{
	}

	protected internal z0ZzZzgah(string p0, string p1, string p2, z0ZzZzfah p3)
		: base(p3)
	{
		if (!z0eek(p0))
		{
			throw new ArgumentException();
		}
		if (p2 != null && p2.Length > 0 && p2 != "yes" && p2 != "no")
		{
			throw new ArgumentException("standalone:" + p2);
		}
		z0tek(p1);
		z0oek = p2;
		z0rek(p0);
	}

	public new string z0eek()
	{
		return z0oek;
	}

	public override void z0rg(string p0)
	{
	}

	public new string z0rek()
	{
		return z0pek;
	}

	public override string z0ph()
	{
		return z0th();
	}

	public override void z0eh(z0ZzZzdqh p0)
	{
		p0.z0pg(z0th(), z0eg());
	}

	internal void z0rek(string p0)
	{
		z0yek = p0;
	}

	public override void z0oh(string p0)
	{
		z0rg(p0);
	}

	public void z0tek(string p0)
	{
		z0pek = ((p0 == null) ? string.Empty : p0);
	}

	public new string z0tek()
	{
		return z0yek;
	}

	public override string z0rh()
	{
		return z0eg();
	}
}
