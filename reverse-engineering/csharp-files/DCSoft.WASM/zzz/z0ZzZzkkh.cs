using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using DCSoft.Writer.Dom;

namespace zzz;

[DebuggerDisplay("Index={StartIndex},Length={Length}")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DefaultMember("Item")]
public class z0ZzZzkkh : IEnumerable
{
	private class z0pjj : IEnumerator
	{
		private readonly z0ZzZzkkh z0eek;

		private int z0rek;

		private int z0tek = -1;

		private int z0yek;

		public object Current
		{
			get
			{
				if (z0yek != z0eek.z0krk)
				{
					throw new InvalidOperationException(" 列表内容已被修改 ");
				}
				if (z0tek >= 0 && z0tek <= z0rek)
				{
					return z0eek.z0mek[z0tek];
				}
				return null;
			}
		}

		public void Reset()
		{
			z0tek = z0eek.z0pek() - 1;
			z0yek = z0eek.z0krk;
			z0rek = Math.Min(z0eek.z0pek() + z0eek.z0iek(), z0eek.z0rek().Count - 1);
		}

		public z0pjj(z0ZzZzkkh p0)
		{
			z0eek = p0;
			Reset();
		}

		public bool MoveNext()
		{
			if (z0yek != z0eek.z0krk)
			{
				throw new InvalidOperationException("列表内容已被修改");
			}
			if (z0tek < z0rek)
			{
				z0tek++;
				return true;
			}
			return false;
		}
	}

	private XTextElementList z0mek;

	private XTextElement z0nek;

	private int z0bek;

	private XTextDocument z0vek;

	private XTextElement z0cek;

	private bool z0xek = true;

	public static int z0zek;

	private int z0lrk;

	private int z0krk;

	public void z0eek(XTextDocumentContentElement p0, XTextElement p1, XTextElement p2)
	{
		z0vek = p0.z0jr();
		z0mek = p0.z0frk();
		z0nek = p1;
		z0cek = p2;
		z0xek = true;
		z0krk++;
	}

	public z0ZzZzkkh(XTextDocument p0, XTextElementList p1, int p2, int p3)
	{
		z0vek = p0;
		z0mek = p1;
		z0bek = p2;
		z0lrk = p3;
		z0xek = true;
	}

	public override string ToString()
	{
		return "Index=" + z0pek() + ",Length=" + z0iek();
	}

	public XTextElement z0eek()
	{
		return z0nek;
	}

	public void z0eek(XTextDocument p0)
	{
		z0vek = p0;
		z0krk++;
	}

	public bool z0eek(XTextElement p0)
	{
		z0oek();
		if (z0vek != null && z0vek.z0bu().WeakMode)
		{
			int num = -1;
			if (z0mek.SafeGet(p0.z0jrk()) == p0)
			{
				num = p0.z0jrk();
			}
			else if (z0mek.SafeGet(p0.z0srk()) == p0)
			{
				num = p0.z0srk();
			}
			if (num < 0)
			{
				num = z0mek.z0erk(p0, z0bek, z0lrk);
			}
			if (num >= 0)
			{
				return true;
			}
		}
		else
		{
			try
			{
				int num2 = -1;
				if (z0mek.SafeGet(p0.z0jrk()) == p0)
				{
					num2 = p0.z0jrk();
				}
				else if (z0mek.SafeGet(p0.z0srk()) == p0)
				{
					num2 = p0.z0srk();
				}
				if (num2 < 0)
				{
					num2 = z0mek.z0erk(p0, z0bek, z0lrk);
				}
				if (num2 >= 0)
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	public IEnumerator GetEnumerator()
	{
		z0oek();
		return new z0pjj(this);
	}

	public XTextElementList z0rek()
	{
		return z0mek;
	}

	public void z0eek(XTextElementList p0)
	{
		z0mek = p0;
		z0xek = true;
		z0krk++;
	}

	public void z0rek(XTextElement p0)
	{
		z0cek = p0;
		z0xek = true;
		z0krk++;
	}

	public z0ZzZzkkh(XTextDocumentContentElement p0, XTextElement p1, XTextElement p2)
	{
		z0eek(p0, p1, p2);
	}

	public void z0eek(int p0)
	{
		z0bek = p0;
		z0xek = true;
		z0krk++;
	}

	public XTextDocument z0tek()
	{
		return z0vek;
	}

	internal void z0yek()
	{
		z0vek = null;
		z0mek = null;
		z0cek = null;
		z0nek = null;
	}

	public void z0tek(XTextElement p0)
	{
		z0nek = p0;
		z0xek = true;
		z0krk++;
	}

	public void z0eek(XTextDocumentContentElement p0, int p1, int p2)
	{
		z0vek = p0.z0jr();
		z0mek = p0.z0frk();
		z0bek = p1;
		z0lrk = p2;
		z0xek = true;
		z0krk++;
		_ = z0vek;
	}

	public XTextElement z0uek()
	{
		return z0cek;
	}

	public void z0rek(int p0)
	{
		z0lrk = p0;
		z0xek = true;
		z0krk++;
	}

	public z0ZzZzkkh()
	{
	}

	public XTextElement z0tek(int p0)
	{
		z0oek();
		return z0mek[z0bek + p0];
	}

	public int z0iek()
	{
		return z0lrk;
	}

	public bool z0yek(int p0)
	{
		z0oek();
		if (z0lrk == 0)
		{
			return false;
		}
		if (p0 >= z0bek)
		{
			return p0 < z0bek + z0lrk;
		}
		return false;
	}

	public void z0oek()
	{
		if (z0xek)
		{
			z0eek(p0: true);
		}
	}

	public static bool z0eek(z0ZzZzkkh p0, z0ZzZzkkh p1)
	{
		if (p0 == p1)
		{
			return true;
		}
		if (p0 == null || p1 == null)
		{
			return false;
		}
		if (p0.z0vek != p1.z0vek || p0.z0mek != p1.z0mek || p0.z0cek != p1.z0cek || p0.z0lrk != p1.z0lrk || p0.z0nek != p1.z0nek || p0.z0bek != p1.z0bek || p0.z0xek != p1.z0xek)
		{
			return false;
		}
		return true;
	}

	public bool z0eek(bool p0)
	{
		z0zek++;
		if (z0mek == null)
		{
			if (p0)
			{
				throw new ArgumentNullException("Elements");
			}
			return false;
		}
		if (z0nek != null && z0cek != null)
		{
			int num = z0ZzZzafh.z0yek(z0mek, z0nek);
			int num2 = z0ZzZzafh.z0yek(z0mek, z0cek);
			if (num < 0 || num2 < 0)
			{
				if (p0)
				{
					throw new IndexOutOfRangeException(z0bek.ToString());
				}
				return false;
			}
			if (num < num2)
			{
				z0bek = num;
				z0lrk = num2 - num + 1;
			}
			else
			{
				z0bek = num2;
				z0lrk = num - num2 + 1;
			}
		}
		else
		{
			if (z0nek == null != (z0cek == null))
			{
				if (p0)
				{
					throw new ArgumentException("StartElement vs EndElement");
				}
				return false;
			}
			if (z0lrk < 0)
			{
				z0bek += z0lrk;
				z0lrk = -z0lrk;
			}
			if (z0bek < 0 || z0bek >= z0mek.Count)
			{
				if (p0)
				{
					throw new ArgumentOutOfRangeException("StartIndex");
				}
				return false;
			}
			if (z0lrk < 0 || z0bek + z0lrk > z0mek.Count)
			{
				if (p0)
				{
					throw new ArgumentOutOfRangeException("Length");
				}
				return false;
			}
		}
		z0xek = false;
		return true;
	}

	public int z0pek()
	{
		return z0bek;
	}

	public z0ZzZzkkh(XTextDocumentContentElement p0, int p1, int p2)
	{
		z0eek(p0, p1, p2);
	}
}
