using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzihh : z0ZzZzcah
{
	public class z0nnk : IDisposable
	{
		private int z0oek;

		private int z0pek;

		public static Func<int, byte[]> z0mek;

		private bool z0nek;

		private int z0bek;

		private int[] z0vek;

		private int z0cek;

		public int z0eek()
		{
			return z0bek;
		}

		public int z0rek()
		{
			if (z0cek <= z0pek)
			{
				z0eek(z0cek - 1);
			}
			return z0vek[z0cek - z0pek - 1];
		}

		private void z0eek(int p0)
		{
			if (!z0nek && (p0 < z0pek || p0 >= z0pek + z0oek))
			{
				z0rek(p0);
			}
		}

		public int z0tek()
		{
			int num = z0cek - z0pek;
			if (num >= 0 && num < z0oek)
			{
				z0cek++;
				return z0vek[num];
			}
			if (z0rek(z0cek))
			{
				z0cek++;
				return z0vek[0];
			}
			return 0;
		}

		public void Dispose()
		{
			z0vek = null;
		}

		public z0nnk(int[] p0)
		{
			if (p0 != null)
			{
				z0vek = p0;
				z0oek = p0.Length;
			}
		}

		public void z0yek()
		{
			z0eek(0);
			z0cek = 0;
		}

		public int z0uek()
		{
			return z0cek;
		}

		public bool z0iek()
		{
			return z0cek < z0bek;
		}

		private bool z0rek(int p0)
		{
			if (z0nek)
			{
				return false;
			}
			if (z0mek != null)
			{
				byte[] array = z0mek(p0);
				if (array != null && array.Length != 0)
				{
					z0ZzZzqok.z0rek.z0sh("读取数据 LoadBuffer " + z0ZzZzmuk.z0eek(p0 * 4 + array.Length) + " ," + Convert.ToInt32((float)(p0 + array.Length / 4) * 100f / (float)z0bek) + "%");
					if (array.Length % 4 != 0)
					{
						throw new Exception("LoadBuffer:bs.Length= " + array.Length);
					}
					int num = array.Length / 4;
					if (z0vek.Length < num)
					{
						z0vek = new int[num];
					}
					Buffer.BlockCopy(array, 0, z0vek, 0, array.Length);
					z0pek = p0;
					z0oek = num;
					if (z0pek + z0oek == z0bek)
					{
						z0nek = true;
					}
					return true;
				}
				throw new InvalidOperationException("No data");
			}
			throw new InvalidOperationException("Read Int32Reader out of range");
		}

		public void z0tek(int p0)
		{
			z0eek(p0);
			z0cek = p0;
		}

		public void z0yek(int p0)
		{
			z0bek = p0;
			z0nek = z0vek.Length == p0;
		}
	}

	private class z0tmk
	{
		public z0umk z0eek;

		public int z0rek;

		public int z0tek;

		public int z0yek;

		public string z0uek;

		public string z0iek;
	}

	private enum z0umk
	{
		z0eek,
		z0rek,
		z0tek,
		z0yek,
		z0uek,
		z0iek
	}

	private int z0iek;

	private string[] z0oek = Array.Empty<string>();

	private z0tmk[] z0pek = z0yek();

	private int z0mek;

	private z0ZzZzbah z0nek = (z0ZzZzbah)1;

	public static Action z0bek;

	private z0tmk z0vek;

	private string z0cek;

	private int z0xek;

	private List<byte[]> z0zek;

	internal z0nnk z0lrk;

	private int z0jrk;

	private string z0hrk;

	public string[] z0grk;

	private z0ZzZzysh z0frk = new z0ZzZzysh();

	private byte[] z0drk;

	internal int[] z0srk;

	private string[] z0ark = Array.Empty<string>();

	public override int z0va(byte[] p0, int p1, int p2)
	{
		if (z0drk == null)
		{
			string text = z0qa_jiejie20260327142557();
			z0drk = Convert.FromBase64String(text);
			z0mek = 0;
		}
		if (z0drk != null)
		{
			if (z0mek >= z0drk.Length)
			{
				z0drk = null;
				z0mek = 0;
				return 0;
			}
			int num = Math.Min(p2, z0drk.Length - z0mek);
			if (num > 0)
			{
				Array.Copy(z0drk, z0mek, p0, p1, num);
				z0mek += num;
				return num;
			}
			z0drk = null;
		}
		return 0;
	}

	public override string z0ba(string p0, string p1)
	{
		for (int i = 0; i < z0iek; i++)
		{
			if (z0oek[i] == p0)
			{
				return z0ark[i];
			}
		}
		return null;
	}

	public override bool z0na_jiejie20260327142557(string p0)
	{
		throw new NotImplementedException();
	}

	public override string z0ma()
	{
		return z0hrk;
	}

	public override bool z0pa()
	{
		if (z0jrk < z0iek)
		{
			z0hrk = z0oek[z0jrk];
			z0cek = z0ark[z0jrk];
			z0jrk++;
			return true;
		}
		z0hrk = null;
		z0cek = null;
		return false;
	}

	public override z0ZzZziah z0oa()
	{
		return z0frk;
	}

	public override void z0ia()
	{
		if (z0vek != null && z0vek.z0tek > 0)
		{
			z0lrk.z0tek(z0vek.z0tek + 1);
			z0nek = (z0ZzZzbah)15;
			z0rek();
		}
	}

	public override string ToString()
	{
		return GetType().FullName;
	}

	public void z0eek()
	{
		if (z0srk == null || z0srk.Length == 0 || z0grk == null || z0grk.Length == 0)
		{
			return;
		}
		z0ZzZziah z0ZzZziah2 = z0oa();
		int[] array = z0srk;
		foreach (int num in array)
		{
			if (num >= 0 && num < z0grk.Length)
			{
				z0grk[num] = z0ZzZziah2.z0nf(z0grk[num]);
			}
		}
		z0srk = null;
	}

	public override bool z0ua()
	{
		if (z0nek == (z0ZzZzbah)15)
		{
			return z0rek();
		}
		if (z0vek != null)
		{
			switch (z0vek.z0eek)
			{
			case z0umk.z0rek:
				z0xek--;
				z0nek = (z0ZzZzbah)15;
				break;
			case z0umk.z0yek:
				return z0tek();
			case z0umk.z0tek:
				z0hrk = z0vek.z0uek;
				z0cek = z0vek.z0iek;
				z0nek = (z0ZzZzbah)15;
				break;
			case z0umk.z0uek:
				z0xek--;
				z0nek = (z0ZzZzbah)15;
				break;
			case z0umk.z0iek:
				return z0tek();
			}
		}
		return z0tek();
	}

	private new bool z0rek()
	{
		if (z0xek > 0)
		{
			z0xek--;
			if (z0xek > 0)
			{
				if (z0lrk.z0uek() < z0pek[z0xek - 1].z0tek)
				{
					return z0tek();
				}
				z0nek = (z0ZzZzbah)15;
			}
			return true;
		}
		throw new InvalidOperationException("No element");
	}

	public void z0eek(byte[] p0)
	{
		if (z0zek == null)
		{
			z0zek = new List<byte[]>();
		}
		z0zek.Add(p0);
	}

	public override bool z0ya()
	{
		if (z0vek != null && z0vek.z0eek != z0umk.z0rek)
		{
			return z0vek.z0eek == z0umk.z0uek;
		}
		return true;
	}

	public override bool z0ta()
	{
		return true;
	}

	public override string z0ra()
	{
		if (z0nek == (z0ZzZzbah)3)
		{
			string result = z0cek;
			z0nek = (z0ZzZzbah)15;
			z0rek();
			return result;
		}
		throw new NotSupportedException("ReadString");
	}

	public void z0eek(object p0)
	{
		string text = z0qa_jiejie20260327142557();
		if (text == null || text.Length <= 0)
		{
			return;
		}
		if (z0zek != null)
		{
			if (text.StartsWith("$BINARY_", StringComparison.Ordinal))
			{
				int num = 0;
				if (int.TryParse(text.Substring("$BINARY_".Length), out num) && num >= 0 && num < z0zek.Count && p0 is z0ZzZzpmk)
				{
					((z0ZzZzpmk)p0).ImageData = z0zek[num];
				}
			}
			else if (p0 is z0ZzZzpmk)
			{
				((z0ZzZzpmk)p0).ImageData = Convert.FromBase64String(text);
			}
		}
		else
		{
			((z0ZzZzpmk)p0).ImageData = Convert.FromBase64String(text);
		}
	}

	public override int z0ea()
	{
		throw new NotImplementedException();
	}

	public override string z0wa(string p0)
	{
		return string.Empty;
	}

	public override string z0qa_jiejie20260327142557()
	{
		switch (z0vek.z0eek)
		{
		case z0umk.z0tek:
		{
			string result2 = z0vek.z0iek;
			z0nek = (z0ZzZzbah)15;
			z0rek();
			return result2;
		}
		case z0umk.z0rek:
			z0rek();
			return null;
		case z0umk.z0uek:
			z0rek();
			return null;
		default:
			if (z0vek.z0rek == 1)
			{
				z0nnk z0nnk = z0lrk;
				if (z0nnk.z0tek() == 0)
				{
					string result = z0grk[z0nnk.z0tek()];
					z0rek();
					return result;
				}
				z0umk z0umk = (z0umk)z0nnk.z0rek();
				_ = 5;
				throw new NotSupportedException(z0umk.ToString());
			}
			throw new NotSupportedException(z0vek.z0uek + "#ReadElementString");
		}
	}

	public override string z0aa()
	{
		throw new NotImplementedException();
	}

	public z0ZzZzihh(int[] p0)
	{
		z0lrk = new z0nnk(p0);
	}

	public override void z0sa()
	{
		throw new NotImplementedException();
	}

	private new bool z0tek()
	{
		z0nnk z0nnk = z0lrk;
		if (!z0nnk.z0iek())
		{
			return false;
		}
		z0tmk z0tmk = z0pek[z0xek++];
		z0tmk.z0eek = (z0umk)z0nnk.z0tek();
		z0tmk.z0uek = (z0hrk = z0grk[z0nnk.z0tek()]);
		switch (z0tmk.z0eek)
		{
		case z0umk.z0eek:
			z0vek = z0tmk;
			z0hrk = "#text";
			z0cek = z0tmk.z0uek;
			z0tmk.z0tek = z0nnk.z0uek() - 1;
			z0nek = (z0ZzZzbah)3;
			return true;
		case z0umk.z0rek:
			z0iek = 0;
			z0tmk.z0tek = z0nnk.z0uek() - 1;
			break;
		case z0umk.z0tek:
			z0iek = 0;
			z0tmk.z0iek = z0grk[z0nnk.z0tek()];
			z0tmk.z0tek = z0nnk.z0uek() - 1;
			break;
		case z0umk.z0yek:
			z0iek = 0;
			z0tmk.z0rek = z0nnk.z0tek();
			z0tmk.z0tek = z0nnk.z0tek();
			z0tmk.z0yek = z0nnk.z0uek();
			break;
		case z0umk.z0uek:
		{
			int num2 = z0nnk.z0tek();
			z0eek(num2);
			for (int j = 0; j < num2; j++)
			{
				z0oek[j] = z0grk[z0nnk.z0tek()];
				z0ark[j] = z0grk[z0nnk.z0tek()];
			}
			z0jrk = 0;
			z0tmk.z0tek = z0nnk.z0uek() - 1;
			break;
		}
		case z0umk.z0iek:
		{
			int num = z0nnk.z0tek();
			z0eek(num);
			for (int i = 0; i < num; i++)
			{
				z0oek[i] = z0grk[z0nnk.z0tek()];
				z0ark[i] = z0grk[z0nnk.z0tek()];
			}
			z0jrk = 0;
			z0tmk.z0rek = z0nnk.z0tek();
			z0tmk.z0tek = z0nnk.z0tek();
			z0tmk.z0yek = z0nnk.z0uek();
			break;
		}
		default:
			throw new NotSupportedException(z0tmk.z0eek.ToString());
		}
		z0vek = z0tmk;
		z0nek = (z0ZzZzbah)1;
		return true;
	}

	public override z0ZzZzbah z0da()
	{
		if (z0vek == null)
		{
			z0tek();
		}
		return z0nek;
	}

	private new static z0tmk[] z0yek()
	{
		z0tmk[] array = new z0tmk[200];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new z0tmk();
		}
		return array;
	}

	private int[] z0rek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		int[] array = new int[p0.Length / 4];
		Buffer.BlockCopy(p0, 0, array, 0, p0.Length);
		return array;
	}

	public override string z0fa()
	{
		return z0cek;
	}

	public override bool z0ga()
	{
		throw new NotImplementedException();
	}

	public override void z0ha()
	{
		if (z0bek != null)
		{
			z0bek();
		}
		base.z0ha();
		if (z0lrk != null)
		{
			z0lrk.Dispose();
			z0lrk = null;
		}
		if (z0zek != null)
		{
			z0zek.Clear();
			z0zek = null;
		}
		z0oek = null;
		z0ark = null;
		z0pek = null;
		z0srk = null;
		z0frk = null;
		z0hrk = null;
		z0cek = null;
		if (z0grk != null)
		{
			Array.Clear(z0grk);
			z0grk = null;
		}
		z0vek = null;
		z0drk = null;
	}

	public override bool z0ja()
	{
		return false;
	}

	public override int z0ka()
	{
		return z0iek;
	}

	public override z0ZzZzbah z0la()
	{
		return z0nek;
	}

	private void z0eek(int p0)
	{
		if (z0iek != p0)
		{
			z0iek = p0;
			if (z0oek.Length < p0)
			{
				z0oek = new string[p0];
				z0ark = new string[p0];
			}
		}
	}

	public override string z0zs()
	{
		return string.Empty;
	}

	public override z0ZzZzish z0xs()
	{
		return (z0ZzZzish)1;
	}

	public void z0uek()
	{
		z0drk = null;
		z0mek = 0;
		z0vek = null;
		z0lrk.z0yek();
		z0hrk = null;
		z0cek = null;
		z0iek = 0;
		z0jrk = 0;
		z0oek = Array.Empty<string>();
		z0ark = Array.Empty<string>();
		z0xek = 0;
		z0nek = (z0ZzZzbah)1;
	}

	public void z0eek(z0ZzZzfah p0)
	{
		Stack<z0ZzZzoah> stack = new Stack<z0ZzZzoah>();
		Stack<int> stack2 = new Stack<int>();
		stack.Push(p0);
		stack2.Push(2147483647);
		z0nnk z0nnk = z0lrk;
		while (z0nnk.z0iek())
		{
			z0ZzZzoah z0ZzZzoah2 = stack.Peek();
			int num = stack2.Peek();
			if (z0nnk.z0uek() >= num)
			{
				stack.Pop();
				stack2.Pop();
				z0ZzZzoah2 = stack.Peek();
				num = stack2.Peek();
			}
			z0umk z0umk = (z0umk)z0nnk.z0tek();
			string p1 = z0grk[z0nnk.z0tek()];
			switch (z0umk)
			{
			case z0umk.z0eek:
				z0ZzZzoah2.z0if(p0.z0yek(p1));
				break;
			case z0umk.z0rek:
			{
				z0ZzZzsah z0ZzZzsah4 = p0.z0rek(p1);
				z0ZzZzsah4.z0eek(p0: true);
				z0ZzZzoah2.z0if(z0ZzZzsah4);
				break;
			}
			case z0umk.z0tek:
			{
				z0ZzZzsah z0ZzZzsah3 = p0.z0rek(p1);
				string p4 = z0grk[z0nnk.z0tek()];
				z0ZzZzsah3.z0if(p0.z0yek(p4));
				z0ZzZzoah2.z0if(z0ZzZzsah3);
				break;
			}
			case z0umk.z0yek:
			{
				z0ZzZzsah z0ZzZzsah6 = p0.z0rek(p1);
				z0ZzZzoah2.z0if(z0ZzZzsah6);
				z0nnk.z0tek();
				int num5 = z0nnk.z0tek();
				stack.Push(z0ZzZzsah6);
				stack2.Push(num5);
				break;
			}
			case z0umk.z0uek:
			{
				z0ZzZzsah z0ZzZzsah5 = p0.z0rek(p1);
				z0ZzZzoah2.z0if(z0ZzZzsah5);
				int num4 = z0nnk.z0tek();
				for (int j = 0; j < num4; j++)
				{
					string p5 = z0grk[z0nnk.z0tek()];
					string text = z0grk[z0nnk.z0tek()];
					z0ZzZzbsh z0ZzZzbsh3 = p0.z0uek(p5);
					z0ZzZzbsh3.z0oh(text);
					z0ZzZzsah5.z0sg().z0rek(z0ZzZzbsh3);
					z0ZzZzsah5.z0eek(p5, text);
				}
				break;
			}
			case z0umk.z0iek:
			{
				z0ZzZzsah z0ZzZzsah2 = p0.z0rek(p1);
				z0ZzZzoah2.z0if(z0ZzZzsah2);
				int num2 = z0nnk.z0tek();
				for (int i = 0; i < num2; i++)
				{
					string p2 = z0grk[z0nnk.z0tek()];
					string p3 = z0grk[z0nnk.z0tek()];
					z0ZzZzbsh z0ZzZzbsh2 = p0.z0uek(p2);
					z0ZzZzbsh2.z0oh(p3);
					z0ZzZzsah2.z0sg().z0rek(z0ZzZzbsh2);
				}
				z0nnk.z0tek();
				int num3 = z0nnk.z0tek();
				stack.Push(z0ZzZzsah2);
				stack2.Push(num3);
				break;
			}
			default:
				throw new NotSupportedException(z0umk.ToString());
			}
		}
	}
}
