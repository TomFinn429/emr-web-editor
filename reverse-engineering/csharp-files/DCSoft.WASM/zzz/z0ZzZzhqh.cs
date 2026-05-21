using System;
using System.IO;
using System.Text;

namespace zzz;

public class z0ZzZzhqh : z0ZzZzdqh
{
	internal interface z0xnk
	{
		void z0fkk(byte[] p0, int p1, int p2);
	}

	private struct z0nhj
	{
		internal string z0rek;

		internal z0ZzZzlqh z0tek;

		internal string z0yek;

		internal int z0uek;

		internal bool z0iek;

		internal void z0eek(int p0)
		{
			z0rek = null;
			z0tek = (z0ZzZzlqh)0;
			z0yek = null;
			z0uek = p0;
			z0iek = false;
		}
	}

	private enum z0whj
	{
		z0eek,
		z0rek,
		z0tek
	}

	private enum z0ehj
	{
		z0eek,
		z0rek,
		z0tek,
		z0yek,
		z0uek,
		z0iek,
		z0oek,
		z0pek,
		z0mek,
		z0nek
	}

	public enum z0vhj
	{
		z0eek,
		z0rek,
		z0tek,
		z0yek,
		z0uek,
		z0iek,
		z0oek,
		z0pek,
		z0mek,
		z0nek,
		z0bek,
		z0vek,
		z0cek_jiejie20260327142557,
		z0xek
	}

	private char z0bek;

	private bool z0vek;

	private StringBuilder z0cek;

	private char[] z0xek;

	private z0ehj z0zek;

	private int z0lrk;

	private z0nhj[] z0krk;

	private int z0jrk;

	private z0ehj[] z0hrk;

	private static readonly char[] z0grk = new char[40];

	private static int z0frk = 0;

	private z0whj z0drk;

	private readonly TextWriter z0srk;

	private z0vhj z0ark;

	private bool z0qrk;

	private static readonly char[] z0wrk = new char[3] { ' ', '/', '>' };

	private int z0erk;

	private readonly Encoding z0trk;

	private static char[] z0urk = null;

	private static readonly char[] z0irk = z0oek();

	private bool z0ork;

	private static readonly char[] z0prk = new char[2] { '<', '/' };

	private z0ZzZzesh z0mrk;

	private static readonly z0ehj[] z0nrk = new z0ehj[104]
	{
		z0ehj.z0mek,
		z0ehj.z0rek,
		z0ehj.z0tek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0pek,
		z0ehj.z0mek,
		z0ehj.z0tek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0rek,
		z0ehj.z0tek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0pek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0yek,
		z0ehj.z0yek,
		z0ehj.z0yek,
		z0ehj.z0yek,
		z0ehj.z0yek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0uek,
		z0ehj.z0uek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0yek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0rek,
		z0ehj.z0tek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0pek,
		z0ehj.z0mek,
		z0ehj.z0rek,
		z0ehj.z0tek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0pek
	};

	private static int z0brk = -2147483648;

	private readonly z0ZzZzjqh z0vrk;

	private char z0crk_jiejie20260327142557;

	private char[] z0xrk;

	private static readonly z0ehj[] z0zrk = new z0ehj[104]
	{
		z0ehj.z0rek,
		z0ehj.z0rek,
		z0ehj.z0tek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0pek,
		z0ehj.z0tek,
		z0ehj.z0tek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0rek,
		z0ehj.z0rek,
		z0ehj.z0tek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0pek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0pek,
		z0ehj.z0yek,
		z0ehj.z0yek,
		z0ehj.z0yek,
		z0ehj.z0yek,
		z0ehj.z0yek,
		z0ehj.z0yek,
		z0ehj.z0mek,
		z0ehj.z0yek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0oek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0uek,
		z0ehj.z0uek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0mek,
		z0ehj.z0yek,
		z0ehj.z0mek,
		z0ehj.z0pek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0pek,
		z0ehj.z0iek,
		z0ehj.z0iek,
		z0ehj.z0mek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0pek,
		z0ehj.z0rek,
		z0ehj.z0rek,
		z0ehj.z0tek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0pek,
		z0ehj.z0rek,
		z0ehj.z0rek,
		z0ehj.z0tek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0iek,
		z0ehj.z0uek,
		z0ehj.z0pek
	};

	private new void z0eek(bool p0)
	{
		z0vrk.z0rek(p0: false);
		z0vrk.z0rek();
		if (p0)
		{
			z0srk.Write(z0wrk);
		}
		else
		{
			z0srk.Write('>');
		}
	}

	public override void z0xg(char p0)
	{
		try
		{
			z0eek(z0vhj.z0nek);
			z0vrk.z0yek(p0);
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public new void z0eek(string p0, string p1)
	{
		z0ig(p0);
		z0yg(p1);
		z0cg();
	}

	public char z0eek()
	{
		return z0xrk[0];
	}

	private void z0rek()
	{
		if (z0qrk)
		{
			z0uek();
		}
		while (z0erk > 0)
		{
			z0bg();
		}
	}

	public override void z0lf()
	{
		z0srk.Flush();
	}

	public override void z0ig(string p0)
	{
		try
		{
			z0eek(z0vhj.z0pek);
			z0drk = z0whj.z0eek;
			z0vrk.z0rek(z0drk != z0whj.z0eek);
			z0srk.Write(p0);
			z0srk.Write('=');
			if (z0crk_jiejie20260327142557 != z0bek)
			{
				z0crk_jiejie20260327142557 = z0bek;
				z0vrk.z0tek(z0bek);
			}
			z0srk.Write(z0crk_jiejie20260327142557);
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public override void z0mg()
	{
		z0rek(p0: true);
	}

	public int z0tek()
	{
		return z0jrk;
	}

	public void z0eek(string p0, float p1)
	{
		int num = z0eek(z0grk, 0, p1, 10000);
		if (num > 0)
		{
			z0eek(p0, z0grk, num);
		}
	}

	public void z0rek(string p0, float p1)
	{
		z0ig(p0);
		z0yg(z0ZzZzhah.z0eek(p1));
		z0cg();
	}

	private void z0eek(int p0)
	{
		try
		{
			if (z0zek != z0ehj.z0eek)
			{
				throw new InvalidOperationException();
			}
			z0hrk = z0nrk;
			z0zek = z0ehj.z0rek;
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public void z0eek(char[] p0, int p1, int p2)
	{
		if (p0.Length == 0)
		{
			return;
		}
		try
		{
			z0eek(z0vhj.z0nek);
			if (z0cek != null)
			{
				z0cek.Append(p0, p1, p2);
				return;
			}
			if (!z0vrk.z0oek)
			{
				bool flag = true;
				for (int num = p1 + p2 - 1; num >= p1; num--)
				{
					if (!z0ZzZzzsh.z0tek(p0[num]))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					z0srk.Write(p0, p1, p2);
					return;
				}
			}
			z0vrk.z0eek(new string(p0, p1, p2));
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public override void z0cg()
	{
		try
		{
			z0eek(z0vhj.z0mek);
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public override void z0pg(string p0, string p1)
	{
		try
		{
			if (p1 != null && p1.Contains("?>"))
			{
				throw new ArgumentException();
			}
			if (string.Equals(p0, "xml", StringComparison.OrdinalIgnoreCase) && z0hrk == z0nrk)
			{
				throw new ArgumentException();
			}
			z0eek(z0vhj.z0eek);
			z0tek(p0, p1);
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public void z0eek(z0ZzZzesh p0)
	{
		z0mrk = p0;
		z0vek = p0 == (z0ZzZzesh)1;
	}

	public override void z0bg()
	{
		z0rek(p0: false);
	}

	public TextWriter z0yek()
	{
		return z0srk;
	}

	public override void z0vg()
	{
		try
		{
			z0rek();
			if (z0zek != z0ehj.z0pek)
			{
				_ = z0zek;
				_ = 9;
				throw new ArgumentException();
			}
			z0hrk = z0zrk;
			z0zek = z0ehj.z0eek;
			z0ark = z0vhj.z0xek;
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public void z0eek(string p0, bool p1)
	{
		z0ig(p0);
		z0yg(p1 ? "true" : "false");
		z0cg();
	}

	public override void z0hf(string p0, string p1, string p2)
	{
		try
		{
			z0eek(z0vhj.z0uek);
			z0mek();
			z0srk.Write('<');
			z0krk[z0erk].z0rek = p1;
			z0srk.Write(p1);
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	private void z0rek(bool p0)
	{
		try
		{
			if (z0erk <= 0)
			{
				throw new InvalidOperationException();
			}
			z0eek(p0 ? z0vhj.z0oek : z0vhj.z0iek);
			if (z0ark == z0vhj.z0oek)
			{
				if (z0vek)
				{
					z0tek(p0: true);
				}
				z0srk.Write(z0prk);
				z0srk.Write(z0krk[z0erk].z0rek);
				z0srk.Write('>');
			}
			int num = z0krk[z0erk].z0uek;
			z0lrk = num;
			z0erk--;
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public void z0eek(string p0, int p1)
	{
		z0ig(p0);
		int p2 = z0rek(z0grk, 0, p1);
		z0eek(z0grk, 0, p2);
		z0cg();
	}

	public void z0eek(string p0, string p1, int p2)
	{
		int p3 = z0rek(z0grk, 0, p2);
		z0eek(p0);
		z0eek(z0grk, 0, p3);
		z0bg();
	}

	public void z0eek(string p0, char[] p1, int p2)
	{
		z0ig(p0);
		z0eek(z0vhj.z0nek);
		if (z0cek != null)
		{
			z0cek.Append(p1, 0, p2);
		}
		else
		{
			z0srk.Write(p1, 0, p2);
		}
		z0cg();
	}

	public new void z0rek(string p0, string p1)
	{
		z0ig(p0);
		z0eek(z0vhj.z0nek);
		if (p1 != null && p1.Length > 0)
		{
			if (z0cek != null)
			{
				z0cek.Append(p1);
			}
			else
			{
				z0srk.Write(p1);
			}
		}
		z0cg();
	}

	private new void z0tek(string p0, string p1)
	{
		z0srk.Write("<?");
		z0rek(p0, p1: false);
		z0srk.Write(p0);
		z0srk.Write(' ');
		if (p1 != null)
		{
			z0vrk.z0yek(p1);
		}
		z0srk.Write("?>");
	}

	public override void z0zg(string p0)
	{
		try
		{
			z0eek(z0vhj.z0yek);
			if (p0 != null && p0.Contains("]]>"))
			{
				throw new ArgumentException();
			}
			z0srk.Write("<![CDATA[");
			if (p0 != null)
			{
				z0vrk.z0yek(p0);
			}
			z0srk.Write("]]>");
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public z0ZzZzhqh(TextWriter p0)
		: this()
	{
		z0srk = p0;
		if (p0 is StringWriter)
		{
			z0cek = ((StringWriter)p0).GetStringBuilder();
		}
		z0trk = p0.Encoding;
		z0vrk = new z0ZzZzjqh(p0);
		z0vrk.z0tek(z0bek);
	}

	public void z0eek(string p0, char[] p1, int p2, int p3)
	{
		z0hf(null, p0, null);
		if (p3 > 0)
		{
			z0eek(p1, p2, p3);
		}
		z0bg();
	}

	public void z0rek(int p0)
	{
		if (p0 < 0)
		{
			throw new ArgumentException();
		}
		z0jrk = p0;
	}

	public override void z0kf()
	{
		z0xek = null;
		z0cek = null;
		try
		{
			z0rek();
		}
		catch
		{
		}
		finally
		{
			z0zek = z0ehj.z0nek;
			z0srk.Dispose();
		}
	}

	public override void z0og(string p0)
	{
		try
		{
			z0eek(z0vhj.z0vek);
			z0vrk.z0yek(p0);
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public override z0ZzZznsh z0jf()
	{
		switch (z0zek)
		{
		case z0ehj.z0eek:
			return (z0ZzZznsh)0;
		case z0ehj.z0rek:
		case z0ehj.z0tek:
			return (z0ZzZznsh)1;
		case z0ehj.z0yek:
			return (z0ZzZznsh)2;
		case z0ehj.z0uek:
		case z0ehj.z0oek:
			return (z0ZzZznsh)3;
		case z0ehj.z0iek:
		case z0ehj.z0pek:
			return (z0ZzZznsh)4;
		case z0ehj.z0mek:
			return (z0ZzZznsh)6;
		case z0ehj.z0nek:
			return (z0ZzZznsh)5;
		default:
			return (z0ZzZznsh)6;
		}
	}

	public z0ZzZzhqh(Stream p0, Encoding p1)
		: this()
	{
		z0trk = p1;
		if (p1 != null)
		{
			z0srk = new StreamWriter(p0, p1);
		}
		else
		{
			z0srk = new StreamWriter(p0);
		}
		z0vrk = new z0ZzZzjqh(z0srk);
		z0vrk.z0tek(z0bek);
	}

	public override void z0yg(string p0)
	{
		try
		{
			if (!string.IsNullOrEmpty(p0))
			{
				z0eek(z0vhj.z0nek);
				z0vrk.z0eek(p0);
			}
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public static string z0eek(float p0)
	{
		int num = z0eek(z0grk, 0, p0, 10000);
		if (num > 0)
		{
			return new string(z0grk, 0, num);
		}
		return string.Empty;
	}

	private void z0uek()
	{
		z0qrk = false;
	}

	public void z0eek(string p0, byte[] p1)
	{
		z0hf(null, p0, null);
		z0eek(z0vhj.z0nek);
		if (p1 != null && p1.Length != 0)
		{
			if (z0srk is z0xnk)
			{
				((z0xnk)z0srk).z0fkk(p1, 0, p1.Length);
			}
			else
			{
				int num = (int)((double)p1.Length * 4.0 / 3.0) + 100;
				if (z0xek == null || z0xek.Length < num)
				{
					z0xek = new char[num];
				}
				int num2 = Convert.ToBase64CharArray(p1, 0, p1.Length, z0xek, 0);
				if (z0cek != null)
				{
					z0cek.Append(z0xek, 0, num2);
				}
				else
				{
					z0srk.Write(z0xek, 0, num2);
				}
			}
		}
		z0bg();
	}

	public static int z0eek(char[] p0, int p1, float p2, int p3)
	{
		int num = p0.Length;
		if (p1 >= num)
		{
			return p1;
		}
		if (p2 == 0f)
		{
			p0[p1++] = '0';
			return p1;
		}
		if (p2 == 1f)
		{
			p0[p1++] = '1';
			return p1;
		}
		if (p2 > 1E+16f || p2 < -1E+16f || float.IsNaN(p2))
		{
			string text = p2.ToString();
			int num2 = Math.Min(text.Length, num - p1);
			Array.Copy(text.ToCharArray(), 0, p0, p1, num2);
			return p1 + num2;
		}
		if (p2 < 0f)
		{
			p2 = 0f - p2;
			p0[p1++] = '-';
		}
		int num3 = p1;
		if (p3 <= 1)
		{
			p3 = 1000000;
		}
		int num4 = (int)Math.Truncate(p2);
		int num5 = (int)((p2 - (float)num4) * (float)p3);
		if (num4 == 0)
		{
			p0[num3++] = '0';
		}
		else if (num4 < 1000)
		{
			if (num4 >= 100)
			{
				int num6 = num4 % 10;
				p0[num3 + 2] = (char)(num6 + 48);
				num4 = (num4 - num6) / 10;
				num6 = num4 % 10;
				p0[num3 + 1] = (char)(num6 + 48);
				p0[num3] = (char)((num4 - num6) / 10 + 48);
				num3 += 3;
			}
			else if (num4 >= 10)
			{
				int num7 = num4 % 10;
				p0[num3 + 1] = (char)(num7 + 48);
				p0[num3] = (char)((num4 - num7) / 10 + 48);
				num3 += 2;
			}
			else
			{
				p0[num3++] = (char)(num4 + 48);
			}
		}
		else
		{
			int num8 = num3;
			while (num4 > 0)
			{
				int num9 = num4 % 10;
				p0[num3++] = (char)(num9 + 48);
				num4 = (num4 - num9) / 10;
			}
			if (num3 > num8 + 1)
			{
				Array.Reverse(p0, num8, num3 - num8);
			}
		}
		if (num5 > 0)
		{
			p0[num3++] = '.';
			int num10 = num3;
			while (p3 > 1)
			{
				int num11 = num5 % 10;
				p0[num3++] = (char)(num11 + 48);
				num5 = (num5 - num11) / 10;
				p3 /= 10;
			}
			if (num3 > num10 + 1)
			{
				Array.Reverse(p0, num10, num3 - num10);
				while (p0[num3 - 1] == '0')
				{
					num3--;
				}
			}
		}
		return num3;
	}

	public z0ZzZzesh z0iek()
	{
		return z0mrk;
	}

	public override void z0ng(string p0)
	{
		try
		{
			z0rek(p0, p1: false);
			z0eek(z0vhj.z0nek);
			z0vrk.z0tek(p0);
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public void z0eek(char p0)
	{
		if (p0 == ' ')
		{
			z0xrk = z0irk;
			return;
		}
		if (z0xrk == z0irk)
		{
			z0xrk = new char[64];
		}
		for (int i = 0; i < 64; i++)
		{
			z0xrk[i] = p0;
		}
	}

	public void z0eek(string p0, double p1)
	{
		z0ig(p0);
		z0yg(z0ZzZzhah.z0rek(p1));
		z0cg();
	}

	private static char[] z0oek()
	{
		char[] array = new char[64];
		Array.Fill(array, ' ');
		return array;
	}

	private void z0pek()
	{
		string p = z0vrk.z0tek();
		switch (z0drk)
		{
		case z0whj.z0tek:
			z0krk[z0erk].z0yek = p;
			break;
		case z0whj.z0rek:
			p = z0ZzZzhah.z0eek(p);
			if (p == "default")
			{
				z0krk[z0erk].z0tek = (z0ZzZzlqh)1;
				break;
			}
			if (p == "preserve")
			{
				z0krk[z0erk].z0tek = (z0ZzZzlqh)2;
				break;
			}
			throw new ArgumentException("InvalidXmlSpace:" + p);
		}
	}

	public void z0rek(char p0)
	{
		try
		{
			z0eek(z0vhj.z0nek);
			if (z0ZzZzzsh.z0tek(p0))
			{
				if (z0cek != null)
				{
					z0cek.Append(p0);
				}
				else
				{
					z0srk.Write(p0);
				}
			}
			else
			{
				z0vrk.z0eek(p0.ToString());
			}
		}
		catch
		{
			z0zek = z0ehj.z0mek;
			throw;
		}
	}

	public void z0rek(string p0, int p1)
	{
		if (p1 == z0brk && z0frk > 0)
		{
			z0eek(p0, z0urk, z0frk);
			return;
		}
		int num = z0rek(z0grk, 0, p1);
		if (num > 0)
		{
			z0brk = p1;
			z0frk = num;
			if (z0urk == null)
			{
				z0urk = (char[])z0grk.Clone();
			}
			else
			{
				Array.Copy(z0grk, z0urk, num);
			}
			z0eek(p0, z0grk, num);
		}
	}

	private z0ZzZzhqh()
	{
		z0ork = true;
		z0mrk = (z0ZzZzesh)0;
		z0jrk = 2;
		z0xrk = z0irk;
		z0lrk = -1;
		z0krk = new z0nhj[10];
		z0erk = 0;
		z0krk[z0erk].z0eek(-1);
		z0bek = '"';
		z0hrk = z0zrk;
		z0zek = z0ehj.z0eek;
		z0ark = z0vhj.z0xek;
	}

	public static int z0rek(char[] p0, int p1, int p2)
	{
		int num = p0.Length;
		if (p1 >= num)
		{
			return p1;
		}
		if (p2 == 0)
		{
			p0[p1++] = '0';
			return p1;
		}
		if (p2 == 1)
		{
			p0[p1++] = '1';
			return p1;
		}
		if (p2 < 0)
		{
			p2 = -p2;
			p0[p1++] = '-';
		}
		int num2 = p1;
		if (p2 < 1000)
		{
			if (p2 >= 100)
			{
				int num3 = p2 % 10;
				p0[num2 + 2] = (char)(num3 + 48);
				p2 = (p2 - num3) / 10;
				num3 = p2 % 10;
				p0[num2 + 1] = (char)(num3 + 48);
				p0[num2] = (char)((p2 - num3) / 10 + 48);
				num2 += 3;
			}
			else if (p2 >= 10)
			{
				int num4 = p2 % 10;
				p0[num2 + 1] = (char)(num4 + 48);
				p0[num2] = (char)((p2 - num4) / 10 + 48);
				num2 += 2;
			}
			else
			{
				p0[num2++] = (char)(p2 + 48);
			}
		}
		else
		{
			int num5 = num2;
			while (p2 > 0)
			{
				int num6 = p2 % 10;
				p0[num2++] = (char)(num6 + 48);
				p2 = (p2 - num6) / 10;
			}
			if (num2 > num5 + 1)
			{
				Array.Reverse(p0, num5, num2 - num5);
			}
		}
		return num2;
	}

	public void z0tek(string p0, int p1)
	{
		int num = z0rek(z0grk, 0, p1);
		if (num > 0)
		{
			z0eek(p0, z0grk, num);
		}
	}

	public void z0rek(string p0, byte[] p1)
	{
		z0ig(p0);
		z0eek(z0vhj.z0nek);
		if (p1 != null && p1.Length != 0)
		{
			string text = z0ZzZzpmk.z0eek(p1);
			if (z0cek != null)
			{
				z0cek.Append(text);
			}
			else
			{
				z0srk.Write(text);
			}
			int num = (int)((double)p1.Length * 4.0 / 3.0) + 100;
			if (z0xek == null || z0xek.Length < num)
			{
				z0xek = new char[num];
			}
			int num2 = Convert.ToBase64CharArray(p1, 0, p1.Length, z0xek, 0);
			if (z0cek != null)
			{
				z0cek.Append(z0xek, 0, num2);
			}
			else
			{
				z0srk.Write(z0xek, 0, num2);
			}
		}
		z0cg();
	}

	public override void z0ug()
	{
		z0eek(-1);
	}

	private void z0mek()
	{
		if (z0erk == z0krk.Length - 1)
		{
			z0nhj[] array = new z0nhj[z0krk.Length + 10];
			if (z0erk > 0)
			{
				Array.Copy(z0krk, array, z0erk + 1);
			}
			z0krk = array;
		}
		z0erk++;
		z0krk[z0erk].z0eek(z0lrk);
	}

	private void z0rek(string p0, bool p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentException();
		}
		int length = p0.Length;
		if (z0ork)
		{
			int num = -1;
			int num2 = z0ZzZzmsh.z0rek(p0);
			while (true)
			{
				if (num2 == length)
				{
					return;
				}
				if (p0[num2] != ':' || p1 || num != -1 || num2 <= 0 || num2 + 1 >= length)
				{
					break;
				}
				num = num2;
				num2++;
				num2 += z0ZzZzmsh.z0rek(p0, num2);
			}
		}
		else if (z0ZzZzmsh.z0eek(p0))
		{
			return;
		}
		throw new ArgumentException("Xml_InvalidNameChars:" + p0);
	}

	public void z0eek(string p0, int p1, bool p2 = false)
	{
		char[] array = z0grk;
		int num = z0rek(array, 0, p1);
		if (num > 0)
		{
			array[num++] = '.';
			array[num++] = '5';
			z0eek(p0, array, num);
		}
	}

	public void z0eek(z0vhj p0)
	{
		if (z0zek == z0ehj.z0nek)
		{
			throw new InvalidOperationException();
		}
		if (z0zek == z0ehj.z0mek)
		{
			throw new InvalidOperationException("WrongToken:" + p0.ToString() + "Error");
		}
		z0ehj z0ehj = z0hrk[(int)(((int)p0 << 3) + z0zek)];
		if (z0ehj == z0ehj.z0mek)
		{
			throw new InvalidOperationException("WrongToken:" + p0.ToString() + z0zek);
		}
		switch (p0)
		{
		case z0vhj.z0rek:
			if (z0vek && z0zek != z0ehj.z0eek)
			{
				z0tek(p0: false);
			}
			break;
		case z0vhj.z0eek:
		case z0vhj.z0tek:
		case z0vhj.z0yek:
		case z0vhj.z0uek:
			if (z0zek == z0ehj.z0uek)
			{
				z0nek();
				z0eek(p0: false);
			}
			else if (z0zek == z0ehj.z0yek)
			{
				z0eek(p0: false);
			}
			if (p0 == z0vhj.z0yek)
			{
				z0krk[z0erk].z0iek = true;
			}
			else if (z0vek && z0zek != z0ehj.z0eek)
			{
				z0tek(p0: false);
			}
			break;
		case z0vhj.z0iek:
		case z0vhj.z0oek:
			if (z0qrk)
			{
				z0uek();
			}
			if (z0zek == z0ehj.z0uek)
			{
				z0nek();
			}
			if (z0zek == z0ehj.z0iek)
			{
				p0 = z0vhj.z0oek;
			}
			else
			{
				z0eek(p0 == z0vhj.z0iek);
			}
			if (z0nrk == z0hrk && z0erk == 1)
			{
				z0ehj = z0ehj.z0pek;
			}
			break;
		case z0vhj.z0pek:
			if (z0qrk)
			{
				z0uek();
			}
			if (z0zek == z0ehj.z0uek)
			{
				z0nek();
				z0srk.Write(' ');
			}
			else if (z0zek == z0ehj.z0yek)
			{
				if (z0cek != null)
				{
					z0cek.Append(' ');
				}
				else
				{
					z0srk.Write(' ');
				}
			}
			break;
		case z0vhj.z0mek:
			if (z0qrk)
			{
				z0uek();
			}
			z0nek();
			break;
		case z0vhj.z0nek:
		case z0vhj.z0vek:
		case z0vhj.z0cek_jiejie20260327142557:
			if (z0qrk)
			{
				z0uek();
			}
			goto case z0vhj.z0bek;
		case z0vhj.z0bek:
			if (z0zek == z0ehj.z0yek && z0ark != z0vhj.z0nek)
			{
				z0eek(p0: false);
			}
			if (z0ehj == z0ehj.z0iek)
			{
				z0krk[z0erk].z0iek = true;
			}
			break;
		default:
			throw new InvalidOperationException();
		}
		z0zek = z0ehj;
		z0ark = p0;
	}

	private void z0nek()
	{
		if (z0drk != z0whj.z0eek)
		{
			z0pek();
		}
		z0vrk.z0rek();
		if (z0cek != null)
		{
			z0cek.Append(z0crk_jiejie20260327142557);
		}
		else
		{
			z0srk.Write(z0crk_jiejie20260327142557);
		}
	}

	private void z0tek(bool p0)
	{
		if (z0erk == 0)
		{
			if (!(z0srk is StringWriter stringWriter) || stringWriter.GetStringBuilder().Length != 0)
			{
				z0srk.WriteLine();
			}
		}
		else
		{
			if (z0krk[z0erk].z0iek)
			{
				return;
			}
			z0srk.WriteLine();
			int num = (p0 ? (z0erk - 1) : z0erk) * z0jrk;
			if (num <= z0xrk.Length)
			{
				z0srk.Write(z0xrk, 0, num);
				return;
			}
			while (num > 0)
			{
				z0srk.Write(z0xrk, 0, Math.Min(num, z0xrk.Length));
				num -= z0xrk.Length;
			}
		}
	}
}
