using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZztdj : z0ZzZzodj
{
	private new string z0yek;

	internal new static readonly string z0uek = "name";

	public new readonly List<z0ZzZzrdj> z0iek = new List<z0ZzZzrdj>();

	public readonly string z0oek;

	private string z0pek_jiejie20260327142557;

	public readonly FontStyle z0mek;

	private bool z0nek;

	private string z0bek;

	internal bool z0eek(string p0)
	{
		foreach (z0ZzZzrdj item in z0iek)
		{
			if (item.z0eek() == (z0ZzZzudj)3 && item.z0iek() == (z0ZzZzedj)1 && item.z0tek() == p0)
			{
				return true;
			}
		}
		return false;
	}

	internal new string z0eek()
	{
		if (z0pek_jiejie20260327142557 == null)
		{
			z0pek_jiejie20260327142557 = z0eek((z0ZzZzudj)1, (z0ZzZzxfj)0, (z0ZzZzadj)0, (z0ZzZzedj)6);
		}
		return z0pek_jiejie20260327142557;
	}

	internal new string z0rek()
	{
		if (z0bek == null)
		{
			z0bek = z0eek((z0ZzZzudj)1, (z0ZzZzxfj)0, (z0ZzZzadj)0, (z0ZzZzedj)1);
		}
		return z0bek;
	}

	internal new string z0tek()
	{
		if (z0yek == null)
		{
			z0yek = z0eek((z0ZzZzudj)3, (z0ZzZzxfj)1, (z0ZzZzadj)1033, (z0ZzZzedj)1);
		}
		return z0yek;
	}

	protected override void z0bfk()
	{
		base.z0bfk();
		if (!z0nek)
		{
			return;
		}
		z0ZzZzjgj z0ZzZzjgj2 = z0yek();
		z0ZzZzjgj2.z0eek((short)0);
		short num = (short)z0iek.Count;
		z0ZzZzjgj2.z0eek(num);
		z0ZzZzjgj2.z0eek((short)(6 + num * 12));
		short num2 = 0;
		foreach (z0ZzZzrdj item in z0iek)
		{
			z0ZzZzjgj2.z0eek((short)item.z0eek());
			z0ZzZzjgj2.z0eek((short)item.z0rek());
			z0ZzZzjgj2.z0eek((short)item.z0yek());
			z0ZzZzjgj2.z0eek((short)item.z0iek());
			byte[] array = item.z0uek();
			short num3 = (short)((array != null) ? array.Length : 0);
			z0ZzZzjgj2.z0eek(num3);
			z0ZzZzjgj2.z0eek(num2);
			num2 += num3;
		}
		foreach (z0ZzZzrdj item2 in z0iek)
		{
			if (item2.z0uek() != null)
			{
				z0ZzZzjgj2.z0eek(item2.z0uek());
			}
		}
	}

	private string z0eek(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzadj p2, z0ZzZzedj p3)
	{
		foreach (z0ZzZzrdj item in z0iek)
		{
			if (item.z0eek() == p0 && item.z0rek() == p1 && item.z0yek() == p2 && item.z0iek() == p3)
			{
				return item.z0tek();
			}
		}
		return string.Empty;
	}

	internal z0ZzZztdj(z0ZzZzjgj p0)
		: base(z0uek, p0)
	{
		z0ZzZzjgj z0ZzZzjgj2 = z0uek();
		if (z0ZzZzjgj2.z0mek() <= 6)
		{
			return;
		}
		z0ZzZzjgj2.z0yek();
		short num = z0ZzZzjgj2.z0yek();
		short p1 = z0ZzZzjgj2.z0yek();
		for (int i = 0; i < num; i++)
		{
			z0iek.Add(new z0ZzZzrdj(z0ZzZzjgj2, p1));
		}
		foreach (z0ZzZzrdj item in z0iek)
		{
			if (item.z0iek() == (z0ZzZzedj)2)
			{
				switch (item.z0tek())
				{
				case "Italic":
					z0mek = FontStyle.Italic;
					break;
				case "Bold":
					z0mek = FontStyle.Bold;
					break;
				case "Regular":
					z0mek = FontStyle.Regular;
					break;
				case "Oblique":
					z0mek = FontStyle.Italic;
					break;
				case "Bold Italic":
					z0mek = FontStyle.Bold | FontStyle.Italic;
					break;
				}
			}
			else if (item.z0iek() == (z0ZzZzedj)1 && (z0oek == null || item.z0yek() == (z0ZzZzadj)0 || item.z0yek() == (z0ZzZzadj)2052))
			{
				z0oek = item.z0tek();
			}
		}
	}

	protected override void z0ygk(bool p0)
	{
		base.z0ygk(p0);
		z0yek = null;
		z0bek = null;
		z0iek.Clear();
		z0pek_jiejie20260327142557 = null;
	}
}
