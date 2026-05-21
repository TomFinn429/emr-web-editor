using System;
using System.IO;
using System.Text;

namespace zzz;

public class z0ZzZzbyj : IDisposable
{
	private TextWriter z0nek;

	private bool z0bek;

	private int z0vek;

	private static readonly string z0cek = "0123456789abcdef";

	private string z0xek = "   ";

	private Encoding z0zek = z0ZzZzltj.z0rik;

	private int z0lrk;

	private int z0krk;

	public void z0eek(string p0, bool p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("keyword");
		}
		if (!z0bek && (p0 == "par" || p0 == "pard"))
		{
			z0eek(Environment.NewLine);
		}
		if (z0bek && (p0 == "par" || p0 == "pard"))
		{
			z0tek();
		}
		if (p1)
		{
			z0eek("\\*\\");
		}
		else
		{
			z0eek("\\");
		}
		z0eek(p0);
	}

	private void z0eek()
	{
		if (z0bek)
		{
			for (int i = 0; i < z0krk; i++)
			{
				z0eek(z0xek);
			}
		}
	}

	public void z0rek()
	{
		if (z0nek != null)
		{
			z0nek.Flush();
		}
	}

	public void z0eek(Encoding p0)
	{
		z0zek = p0;
	}

	private void z0eek(string p0)
	{
		z0vek += p0.Length;
		z0nek.Write(p0);
	}

	public void z0rek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return;
		}
		z0tek("uc1");
		foreach (char c in p0)
		{
			if (c > '\u007f')
			{
				z0tek("u" + (short)c);
				z0yek(" ?");
			}
			else
			{
				z0rek(c);
			}
		}
	}

	public void z0tek(string p0)
	{
		z0eek(p0, p1: false);
	}

	private void z0eek(char p0)
	{
		z0vek++;
		z0nek.Write(p0);
	}

	private void z0rek(char p0)
	{
		if (p0 == '\t')
		{
			z0tek("tab");
			z0eek(' ');
			return;
		}
		if (p0 > ' ' && p0 < '\u007f')
		{
			if (p0 == '\\' || p0 == '{' || p0 == '}')
			{
				z0eek('\\');
			}
			z0eek(p0);
			return;
		}
		if (p0 < ' ')
		{
			z0eek("\\'");
			z0eek((byte)p0);
			return;
		}
		byte[] bytes = z0zek.GetBytes(p0.ToString());
		if (bytes.Length == 1 && bytes[0] == 63 && p0 != '?')
		{
			z0tek("u" + Convert.ToString(p0));
			z0yek(" ?");
			return;
		}
		for (int i = 0; i < bytes.Length; i++)
		{
			z0eek("\\'");
			z0eek(bytes[i]);
		}
	}

	public z0ZzZzbyj(TextWriter p0)
	{
		z0nek = p0;
	}

	private void z0tek()
	{
		if (z0bek && z0vek > 0)
		{
			z0eek(Environment.NewLine);
			z0lrk = z0vek;
			z0eek();
		}
	}

	public void z0yek()
	{
		if (z0krk > 0)
		{
			throw new Exception("Group Not Finished");
		}
		if (z0nek != null)
		{
			z0nek.Close();
			z0nek = null;
		}
	}

	public void z0yek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			z0eek(p0);
		}
	}

	public void Dispose()
	{
		z0yek();
	}

	public void z0eek(bool p0)
	{
		z0bek = p0;
	}

	public void z0uek()
	{
		z0krk--;
		if (z0krk < 0)
		{
			throw new Exception("GroupLevelError");
		}
		if (z0bek)
		{
			z0tek();
			z0eek("}");
		}
		else
		{
			z0eek("}");
		}
	}

	public void z0eek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return;
		}
		z0yek(" ");
		for (int i = 0; i < p0.Length; i++)
		{
			if (i % 32 == 0)
			{
				z0yek(Environment.NewLine);
				z0eek();
			}
			else if (i % 8 == 0)
			{
				z0yek(" ");
			}
			byte num = p0[i];
			int num2 = (num & 0xF0) >> 4;
			int num3 = num & 0xF;
			z0nek.Write(z0cek[num2]);
			z0nek.Write(z0cek[num3]);
			z0vek += 2;
		}
	}

	public void z0eek(byte p0)
	{
		int num = (p0 & 0xF0) >> 4;
		int num2 = p0 & 0xF;
		z0nek.Write(z0cek[num]);
		z0nek.Write(z0cek[num2]);
		z0vek += 2;
	}

	public void z0rek(string p0, bool p1)
	{
		if (p0 != null && p0.Length != 0)
		{
			if (p1)
			{
				z0eek(' ');
			}
			foreach (char p2 in p0)
			{
				z0rek(p2);
			}
		}
	}

	public int z0iek()
	{
		return z0krk;
	}

	public void z0oek()
	{
		if (z0bek)
		{
			z0tek();
			z0nek.Write("{");
		}
		else
		{
			z0nek.Write("{");
		}
		z0krk++;
	}

	public bool z0pek()
	{
		return z0bek;
	}

	public void z0uek(string p0)
	{
		if (p0 != null && p0.Length != 0)
		{
			z0rek(p0, p1: true);
		}
	}

	public Encoding z0mek()
	{
		return z0zek;
	}
}
