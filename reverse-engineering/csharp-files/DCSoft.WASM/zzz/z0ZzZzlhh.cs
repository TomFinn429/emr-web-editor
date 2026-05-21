using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzlhh
{
	public class z0axk_jiejie20260327142557
	{
		public string z0eek;

		public string z0rek;

		public z0axk_jiejie20260327142557(string p0, string p1)
		{
			z0rek = p0;
			z0eek = p1;
		}
	}

	protected string z0mek;

	protected string z0nek;

	protected string z0bek;

	protected string z0vek;

	private z0ZzZzcah z0cek;

	protected string z0xek;

	protected string z0zek;

	protected bool z0eek()
	{
		if (!z0uek())
		{
			return false;
		}
		if (z0cek.z0ya())
		{
			z0cek.z0ia();
			return true;
		}
		z0cek.z0yek();
		while (z0cek.z0la() != (z0ZzZzbah)15)
		{
			z0eek(null, null);
		}
		z0tek();
		return true;
	}

	public void z0eek(z0ZzZzcah p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("r");
		}
		z0cek = p0;
		z0xek = p0.z0oa().z0nf("type");
		z0zek = p0.z0oa().z0nf("http://www.w3.org/2000/10/XMLSchema-instance");
		z0nek = p0.z0oa().z0nf("http://www.w3.org/1999/XMLSchema-instance");
		z0bek = p0.z0oa().z0nf("http://www.w3.org/2001/XMLSchema-instance");
		z0mek = p0.z0oa().z0nf("nil");
		z0vek = p0.z0oa().z0nf("null");
		z0gq();
	}

	protected string z0rek()
	{
		string text = z0cek.z0ba(z0xek, z0bek);
		if (text != null)
		{
			return z0cek.z0oa().z0nf(text);
		}
		return null;
	}

	private byte[] z0eek(bool p0)
	{
		List<byte[]> list = new List<byte[]>();
		int num = 1024;
		int num2 = -1;
		int num3 = 0;
		int num4 = 0;
		byte[] array = new byte[num];
		list.Add(array);
		while (num2 != 0)
		{
			if (num3 == array.Length)
			{
				num = Math.Min(num * 2, 65536);
				array = new byte[num];
				num3 = 0;
				list.Add(array);
			}
			if (p0)
			{
				num2 = z0cek.z0va(array, num3, array.Length - num3);
				num3 += num2;
				num4 += num2;
				continue;
			}
			throw new NotSupportedException("HEX");
		}
		byte[] array2 = new byte[num4];
		num3 = 0;
		foreach (byte[] item in list)
		{
			num = Math.Min(item.Length, num4);
			if (num > 0)
			{
				Buffer.BlockCopy(item, 0, array2, num3, num);
				num3 += num;
				num4 -= num;
			}
		}
		list.Clear();
		return array2;
	}

	protected void z0tek()
	{
		while (z0cek.z0la() == (z0ZzZzbah)13)
		{
			z0cek.z0ia();
		}
		if (z0cek.z0la() == (z0ZzZzbah)0)
		{
			z0cek.z0ia();
		}
		else
		{
			z0cek.z0rek();
		}
	}

	public void z0eek(ref int p0, ref int p1)
	{
	}

	protected virtual void z0hq()
	{
	}

	public z0ZzZzcah z0yek()
	{
		return z0cek;
	}

	protected byte[] z0rek(bool p0)
	{
		if (p0)
		{
			return null;
		}
		return z0eek(p0: true);
	}

	protected static char z0eek(string p0)
	{
		return z0ZzZzhah.z0tek(p0);
	}

	protected bool z0uek()
	{
		string text = z0cek.z0ba(z0mek, z0bek);
		if (text == null)
		{
			text = z0cek.z0ba(z0vek, z0bek);
		}
		if (text == null)
		{
			text = z0cek.z0ba(z0vek, z0zek);
			if (text == null)
			{
				text = z0cek.z0ba(z0vek, z0nek);
			}
		}
		if (text == null || !z0ZzZzhah.z0rek(text))
		{
			return false;
		}
		return true;
	}

	protected Exception z0rek(string p0)
	{
		throw new Exception("CreateInaccessibleConstructorException:" + p0);
	}

	public void z0iek()
	{
	}

	public Exception z0oek()
	{
		return new Exception("UnknowNode:" + z0cek.z0ma());
	}

	protected void z0eek(object p0, string p1)
	{
		z0ZzZzcah z0ZzZzcah2 = z0yek();
		if (z0ZzZzcah2.z0la() == (z0ZzZzbah)0 || z0ZzZzcah2.z0la() == (z0ZzZzbah)13)
		{
			z0ZzZzcah2.z0ua();
		}
		else if (z0ZzZzcah2.z0la() != (z0ZzZzbah)15 && z0ZzZzcah2.z0la() != (z0ZzZzbah)2)
		{
			z0ZzZzcah2.z0ia();
		}
	}

	protected static DateTime z0tek(string p0)
	{
		return z0ZzZzhah.z0yek(p0);
	}

	protected z0ZzZzeqh z0eek(z0ZzZzeqh p0)
	{
		return z0eek(p0, p1: false);
	}

	protected z0ZzZzeqh z0eek(z0ZzZzeqh p0, bool p1)
	{
		string text = null;
		string text2 = null;
		if (p1)
		{
			text = z0cek.z0ma();
			text2 = z0cek.z0zs();
			z0cek.z0ua();
			z0cek.z0da();
		}
		p0.z0ob(z0cek);
		if (p1)
		{
			while (z0cek.z0la() == (z0ZzZzbah)13)
			{
				z0cek.z0ia();
			}
			if (z0cek.z0la() == (z0ZzZzbah)0)
			{
				z0cek.z0ia();
			}
			if (z0cek.z0la() == (z0ZzZzbah)15 && z0cek.z0ma() == text && z0cek.z0zs() == text2)
			{
				z0yek().z0ua();
			}
		}
		return p0;
	}

	protected Exception z0yek(string p0)
	{
		throw new Exception("UnknowType:" + p0);
	}

	protected virtual void z0gq()
	{
	}

	protected string z0eek(string p0, bool p1)
	{
		string text = z0cek.z0ra();
		if (text != null && p1)
		{
			text = text.Trim();
		}
		if (p0 == null || p0.Length == 0)
		{
			return text;
		}
		return p0 + text;
	}

	protected int z0pek()
	{
		return 0;
	}

	protected Exception z0uek(string p0)
	{
		throw new Exception("CreateCtorHasSecurityException:" + p0);
	}
}
