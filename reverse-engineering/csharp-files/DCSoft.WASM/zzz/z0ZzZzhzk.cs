using System;
using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzhzk : IDisposable
{
	protected class z0rgj : z0ZzZzgzk
	{
		internal z0rgj(z0ZzZzhzk p0)
			: base(p0)
		{
		}

		internal override bool z0mk(z0ZzZzkzk p0)
		{
			if (p0 == null)
			{
				throw new ArgumentNullException("word");
			}
			string p1 = base.z0eek.z0yek(p0);
			if (!z0eek(p1))
			{
				base.z0eek.z0uek(p1);
				return true;
			}
			return false;
		}

		internal override void z0nk(z0ZzZzkzk p0)
		{
		}

		private new bool z0eek(string p0)
		{
			if ((base.z0eek.z0pek().z0yek() & (z0ZzZzksh)4096) == 0)
			{
				return base.z0eek.z0yek(p0, base.z0eek.z0srk);
			}
			return !z0yek(base.z0eek.z0yek(p0), base.z0eek.z0srk);
		}

		internal override bool z0pk(z0ZzZzjzk p0)
		{
			return p0 != (z0ZzZzjzk)3;
		}

		internal override void z0ok(z0ZzZzkzk p0)
		{
			base.z0eek.z0drk = z0tek(p0, base.z0eek.z0drk);
			if (base.z0eek.z0drk != (z0ZzZzjzk)3)
			{
				base.z0eek.z0iek();
			}
		}

		protected new virtual bool z0eek(z0ZzZzkzk p0, z0ZzZzjzk p1)
		{
			if (p1 != 0 || p0.z0tek() != 0)
			{
				return p1 == (z0ZzZzjzk)1;
			}
			return true;
		}

		protected virtual bool z0rek(z0ZzZzkzk p0, z0ZzZzjzk p1)
		{
			if (p1 != 0 || p0.z0tek() <= 0)
			{
				return p1 == (z0ZzZzjzk)2;
			}
			return true;
		}

		private z0ZzZzjzk z0tek(z0ZzZzkzk p0, z0ZzZzjzk p1)
		{
			if (z0rek(p0, p1))
			{
				return (z0ZzZzjzk)1;
			}
			if (z0eek(p0, p1))
			{
				return (z0ZzZzjzk)3;
			}
			throw new z0ZzZzfzk();
		}
	}

	protected class z0egj : z0ZzZzgzk
	{
		private int z0rek;

		private string z0tek = string.Empty;

		internal override void z0nk(z0ZzZzkzk p0)
		{
		}

		private new void z0eek(char p0)
		{
			z0tek += p0;
			z0rek++;
		}

		internal override bool z0mk(z0ZzZzkzk p0)
		{
			if (p0 == null)
			{
				throw new ArgumentNullException("word");
			}
			char c = p0.z0rek()[z0rek];
			if (z0yek(base.z0eek.z0yek(z0tek + c), base.z0eek.z0srk))
			{
				z0eek(c);
			}
			else
			{
				if (string.IsNullOrEmpty(z0tek))
				{
					z0eek(c);
				}
				base.z0eek.z0jrk.Add(z0tek);
				z0tek = string.Empty;
			}
			if (z0rek < p0.z0rek().Length)
			{
				return false;
			}
			base.z0eek.z0uek(z0tek);
			return true;
		}

		internal override bool z0pk(z0ZzZzjzk p0)
		{
			return p0 == (z0ZzZzjzk)3;
		}

		internal z0egj(z0ZzZzhzk p0)
			: base(p0)
		{
		}

		internal override void z0ok(z0ZzZzkzk p0)
		{
		}
	}

	private z0ZzZzsdh z0nek;

	private bool z0bek;

	private GraphicsUnit z0vek_jiejie20260327142557;

	private z0ZzZzlsh z0xek;

	private z0ZzZzcxk z0zek;

	private z0ZzZzpej z0lrk;

	private int z0krk;

	private List<string> z0jrk = new List<string>();

	private float z0hrk;

	private z0ZzZznxk z0grk;

	private string z0frk = string.Empty;

	private z0ZzZzjzk z0drk;

	private float z0srk;

	private static bool z0yek(double p0, double p1)
	{
		return z0uek(p0, p1) <= 0;
	}

	internal static int z0uek(double p0, double p1)
	{
		double num = 0.01;
		if (double.IsNegativeInfinity(p0) && double.IsNegativeInfinity(p1))
		{
			return 0;
		}
		if (double.IsPositiveInfinity(p0) && double.IsPositiveInfinity(p1))
		{
			return 0;
		}
		double num2 = p0 - p1;
		if (Math.Abs(num2) <= num)
		{
			return 0;
		}
		if (num2 > 0.0)
		{
			return 1;
		}
		return -1;
	}

	private static float z0yek(string p0, z0ZzZzcxk p1, z0ZzZzsdh p2, z0ZzZzlsh p3, GraphicsUnit p4)
	{
		z0ZzZzxdh z0ZzZzxdh2 = p1.z0eek_jiejie20260327142557(p0, p2, 0f, p3, p4);
		float p5 = z0ZzZzxdh2.z0rek();
		float p6 = z0ZzZzxdh2.z0tek();
		z0ZzZzzxk.z0eek(p3, ref p5, ref p6);
		return p5;
	}

	internal string[] z0yek()
	{
		return z0jrk.ToArray();
	}

	private static float z0yek(string p0, z0ZzZzcxk p1, z0ZzZzpej p2, z0ZzZzlsh p3, GraphicsUnit p4)
	{
		z0ZzZzxdh z0ZzZzxdh2 = p1.z0eek_jiejie20260327142557(p0, p2, 0f, p3, p4);
		float p5 = z0ZzZzxdh2.z0rek();
		float p6 = z0ZzZzxdh2.z0tek();
		z0ZzZzzxk.z0eek(p3, ref p5, ref p6);
		return p5;
	}

	internal string z0yek(z0ZzZzkzk p0)
	{
		return z0drk switch
		{
			(z0ZzZzjzk)0 => p0.z0yek(), 
			(z0ZzZzjzk)1 => p0.z0rek(), 
			(z0ZzZzjzk)2 => z0frk + p0.z0yek(), 
			_ => throw new z0ZzZzfzk(), 
		};
	}

	private bool z0yek(string p0, float p1)
	{
		z0ZzZzxdh z0ZzZzxdh2 = ((z0nek == null) ? z0zek.z0eek_jiejie20260327142557(p0, z0lrk, p1, z0xek, z0vek_jiejie20260327142557) : z0zek.z0eek_jiejie20260327142557(p0, z0nek, p1, z0xek, z0vek_jiejie20260327142557));
		float p2 = z0ZzZzxdh2.z0rek();
		float p3 = z0ZzZzxdh2.z0tek();
		z0ZzZzzxk.z0eek(z0xek, ref p2, ref p3);
		float num = z0grk.z0eek(1);
		return (double)p3 > 1.5 * (double)num;
	}

	private float z0yek(string p0)
	{
		if (z0nek != null)
		{
			return z0yek(p0, z0zek, z0nek, z0xek, z0vek_jiejie20260327142557);
		}
		return z0yek(p0, z0zek, z0lrk, z0xek, z0vek_jiejie20260327142557);
	}

	internal z0ZzZzhzk(float p0, float p1, z0ZzZzpej p2, z0ZzZzlsh p3, GraphicsUnit p4, z0ZzZzcxk p5, int p6, bool p7)
	{
		z0bek = p7;
		z0srk = p0;
		z0hrk = p1;
		z0lrk = p2;
		z0xek = p3;
		z0vek_jiejie20260327142557 = p4;
		z0zek = p5;
		z0krk = p6;
		z0grk = z0ZzZznxk.z0eek(p2, p4);
	}

	internal bool z0eek(List<z0ZzZzkzk> p0, int p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("words");
		}
		if (z0yek(1))
		{
			if (p1 > 1)
			{
				return false;
			}
			return z0tek(p0);
		}
		return z0rek(p0);
	}

	protected internal virtual bool z0yek(int p0)
	{
		if (p0 <= 0)
		{
			throw new z0ZzZzfzk();
		}
		int p1 = z0krk + p0;
		float num = z0grk.z0eek(p1);
		float num2 = 0.75f * z0grk.z0eek(1);
		return num - num2 > z0oek();
	}

	internal void z0uek(string p0)
	{
		z0drk = (z0ZzZzjzk)2;
		z0frk = p0;
	}

	private bool z0rek(List<z0ZzZzkzk> p0)
	{
		z0ZzZzgzk z0ZzZzgzk2 = z0mek();
		foreach (z0ZzZzkzk item in p0)
		{
			while (!z0ZzZzgzk2.z0mk(item))
			{
				z0ZzZzgzk2.z0ok(item);
				if (z0uek())
				{
					z0ZzZzgzk2.z0nk(item);
					return true;
				}
				if (!z0ZzZzgzk2.z0pk(z0drk))
				{
					z0ZzZzgzk2 = z0mek();
				}
			}
			if (!z0ZzZzgzk2.z0pk(z0drk))
			{
				z0ZzZzgzk2 = z0mek();
			}
		}
		if (!string.IsNullOrEmpty(z0frk))
		{
			z0iek();
		}
		return true;
	}

	public void Dispose()
	{
		if (z0nek != null)
		{
			if (z0bek)
			{
				z0nek.Dispose();
			}
			z0nek = null;
		}
		if (z0xek != null)
		{
			if (z0bek)
			{
				z0xek.Dispose();
			}
			z0xek = null;
		}
	}

	private bool z0uek()
	{
		return z0yek(z0jrk.Count + 1);
	}

	internal void z0iek()
	{
		z0jrk.Add(z0frk);
		z0frk = string.Empty;
	}

	internal float z0oek()
	{
		return z0hrk;
	}

	internal z0ZzZzlsh z0pek()
	{
		return z0xek;
	}

	private bool z0tek(List<z0ZzZzkzk> p0)
	{
		z0ZzZzgzk z0ZzZzgzk2 = z0mek();
		foreach (z0ZzZzkzk item in p0)
		{
			if (!z0ZzZzgzk2.z0mk(item))
			{
				z0jrk.Clear();
				return false;
			}
		}
		if (!string.IsNullOrEmpty(z0frk))
		{
			z0iek();
		}
		return true;
	}

	internal virtual z0ZzZzgzk z0mek()
	{
		if (z0drk != (z0ZzZzjzk)3)
		{
			return new z0rgj(this);
		}
		return new z0egj(this);
	}
}
