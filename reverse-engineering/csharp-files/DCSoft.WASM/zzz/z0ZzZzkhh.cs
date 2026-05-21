using System;
using System.Text;

namespace zzz;

public class z0ZzZzkhh
{
	private static readonly string z0yek;

	private bool z0uek;

	private z0ZzZzhqh z0iek;

	protected Exception z0eek(object p0)
	{
		return z0eek(p0.GetType());
	}

	internal static string z0eek(long p0, string[] p1, long[] p2, string? p3)
	{
		if (p2.Length != p1.Length)
		{
			throw new InvalidOperationException("Invalid enum");
		}
		long num = p0;
		StringBuilder stringBuilder = new StringBuilder();
		int num2 = -1;
		for (int i = 0; i < p2.Length; i++)
		{
			if (p2[i] == 0L)
			{
				num2 = i;
				continue;
			}
			if (p0 == 0L)
			{
				break;
			}
			if ((p2[i] & num) == p2[i])
			{
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(p1[i]);
				p0 &= ~p2[i];
			}
		}
		if (p0 != 0L)
		{
			throw new InvalidOperationException("XmlUnknownConstant:" + num + ((p3 == null) ? "enum" : p3));
		}
		if (stringBuilder.Length == 0 && num2 >= 0)
		{
			stringBuilder.Append(p1[num2]);
		}
		return stringBuilder.ToString();
	}

	protected void z0eek(string p0, string p1)
	{
		if (p1 != null)
		{
			z0iek.z0eek(p0, p1);
		}
	}

	public z0ZzZzhqh z0eek()
	{
		return z0iek;
	}

	protected void z0eek(string p0, string? p1, object? p2, bool p3)
	{
		z0eek(p0, p1, p2, p3, null);
	}

	protected void z0rek()
	{
		if (z0iek.z0jf() == (z0ZzZznsh)0)
		{
			z0iek.z0ug();
		}
	}

	protected static byte[] z0eek(byte[] p0)
	{
		return p0;
	}

	protected void z0tek()
	{
	}

	protected void z0eek(string p0, string? p1, string? p2, object p3)
	{
		if (p2 != null && p3 == null)
		{
			z0iek.z0eek(p0, p1, p2);
		}
	}

	protected static string z0eek(char p0)
	{
		ushort num = p0;
		return num.ToString();
	}

	public static string z0eek(DateTime p0)
	{
		return p0.ToString("s") + z0yek;
	}

	protected void z0eek(string p0, string? p1, byte[]? p2, object p3)
	{
		if (p2 != null)
		{
			z0iek.z0tek(p0, p1);
			if (p2 != null && p2.Length != 0)
			{
				z0iek.z0yg(Convert.ToBase64String(p2));
			}
			z0iek.z0bg();
		}
	}

	protected Exception z0eek(Type p0)
	{
		return new InvalidOperationException("XmlUnxpectedType:" + p0.FullName);
	}

	protected void z0rek(object? p0)
	{
		z0iek.z0bg();
	}

	protected void z0rek(string? p0, string? p1)
	{
		if (p0 != null && p0.Length != 0)
		{
			z0eek(p0, p1, (object?)null, p3: false);
			z0iek.z0eek("nil", "true");
			z0iek.z0bg();
		}
	}

	protected void z0eek(string p0, string? p1, byte[]? p2)
	{
		if (p2 == null)
		{
			z0rek(p0, p1);
		}
		else
		{
			z0eek(p0, p1, p2, null);
		}
	}

	protected void z0eek(z0ZzZzeqh? p0, string p1, string? p2, bool p3, bool p4)
	{
		if (p0 == null)
		{
			if (p3)
			{
				z0rek(p1, p2);
			}
			return;
		}
		if (p4)
		{
			z0iek.z0tek(p1, p2);
		}
		p0.z0ib(z0iek);
		if (p4)
		{
			z0iek.z0bg();
		}
	}

	protected void z0eek(string p0, string? p1, string? p2)
	{
		if (p2 == null)
		{
			z0rek(p0, p1);
		}
		else
		{
			z0eek(p0, p1, p2, null);
		}
	}

	protected void z0rek(string p0, string? p1, byte[]? p2)
	{
		z0eek(p0, p1, p2, null);
	}

	protected void z0eek(string p0, string? p1, object? p2, bool p3, string p4)
	{
		z0iek.z0tek(p0, p1);
		if (z0uek)
		{
			z0uek = false;
			z0iek.z0eek("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
			z0iek.z0eek("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
		}
	}

	public void z0eek(z0ZzZzhqh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("w");
		}
		z0uek = true;
		z0iek = p0;
	}

	protected void z0rek(string p0, string? p1, string? p2)
	{
		z0eek(p0, p1, p2, null);
	}

	protected void z0eek(string p0)
	{
		z0iek.z0eek("xsi:type", p0);
	}

	static z0ZzZzkhh()
	{
		TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
		z0yek = "+" + utcOffset.Hours.ToString("00") + ":" + utcOffset.Minutes.ToString("00");
	}

	protected void z0rek(string? p0)
	{
		if (p0 != null)
		{
			z0iek.z0yg(p0);
		}
	}
}
