using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzwej : z0ZzZzygj
{
	private class z0nxk
	{
		private z0ZzZzjdh z0rek;

		private z0ZzZzqej z0tek;

		private GraphicsUnit z0yek;

		public void z0eek(z0ZzZzwej p0)
		{
			p0.z0drk = z0yek;
			p0.z0lrk = z0rek;
			p0.z0srk = z0tek;
		}

		public z0nxk(z0ZzZzwej p0)
		{
			z0yek = p0.z0drk;
			if (p0.z0lrk != null)
			{
				z0rek = p0.z0lrk.z0uek();
			}
			if (p0.z0srk != null)
			{
				z0tek = p0.z0srk.z0ugk();
			}
		}
	}

	[CompilerGenerated]
	private sealed class z0xuk
	{
		public z0ZzZzbdh z0rek_jiejie20260327142557;

		public z0ZzZzwej z0tek;

		public z0ZzZzudh z0yek;

		internal void z0eek()
		{
			z0tek.z0jrk.z0rek(z0yek);
			z0tek.z0jrk.z0iek(z0rek_jiejie20260327142557);
		}
	}

	[CompilerGenerated]
	private sealed class z0hik
	{
		public z0ZzZzudh z0rek;

		public float z0tek;

		public float z0yek;

		public float z0uek;

		public float z0iek;

		public z0ZzZzwej z0oek;

		internal void z0eek()
		{
			z0oek.z0jrk.z0rek(z0rek);
			z0oek.z0jrk.z0rek(z0tek, z0yek, z0uek, z0iek);
		}
	}

	[CompilerGenerated]
	private sealed class z0fik
	{
		public z0ZzZzudh z0rek;

		public z0ZzZzpdh[] z0tek;

		public z0ZzZzwej z0yek;

		internal void z0eek()
		{
			z0yek.z0jrk.z0rek(z0rek);
			z0yek.z0jrk.z0yek(z0tek);
		}
	}

	[CompilerGenerated]
	private sealed class z0dik
	{
		public z0ZzZzudh z0rek;

		public z0ZzZzbdh z0tek;

		public z0ZzZzwej z0yek;

		internal void z0eek()
		{
			z0yek.z0jrk.z0rek(z0rek);
			z0yek.z0jrk.z0yek(z0tek);
		}
	}

	[CompilerGenerated]
	private sealed class z0aik
	{
		public z0ZzZztfh z0rek;

		public z0ZzZzbdh z0tek;

		public z0ZzZzwej z0yek;

		internal void z0eek()
		{
			z0yek.z0jrk.z0rek(z0rek);
			z0yek.z0jrk.z0rek(z0tek);
		}
	}

	[CompilerGenerated]
	private sealed class z0qik
	{
		public z0ZzZzbdh z0rek;

		public z0ZzZztfh z0tek;

		public z0ZzZzwej z0yek;

		internal void z0eek()
		{
			z0yek.z0jrk.z0rek(z0tek);
			z0yek.z0jrk.z0uek(z0rek);
		}
	}

	[CompilerGenerated]
	private sealed class z0wik
	{
		public z0ZzZzedh z0rek;

		public z0ZzZzbdh z0tek;

		public z0ZzZzwej z0yek;

		public byte[] z0uek;

		internal void z0eek()
		{
			z0yek.z0jrk.z0rek(z0yek.z0krk.z0eek(z0rek, z0uek), z0tek);
		}
	}

	private z0ZzZzjdh z0lrk = new z0ZzZzjdh();

	private z0ZzZzaej z0krk;

	private z0ZzZzmlj z0jrk;

	private readonly Stack<z0ZzZzjdh> z0hrk = new Stack<z0ZzZzjdh>();

	private z0ZzZzxdh z0frk = z0ZzZzxdh.z0yek;

	private GraphicsUnit z0drk = GraphicsUnit.Document;

	private z0ZzZzqej z0srk;

	[CompilerGenerated]
	private bool z0ark_jiejie20260327142557;

	private bool z0qrk;

	public void z0eek(z0ZzZzedh p0, z0ZzZzbdh p1, byte[] p2)
	{
		z0rek();
		z0eek(delegate
		{
			z0jrk.z0rek(z0krk.z0eek(p0, p2), p1);
		});
	}

	public z0ZzZzbdh z0eek()
	{
		if (z0srk == null)
		{
			return z0ZzZzbdh.z0xek;
		}
		return z0srk.z0ogk(z0lrk);
	}

	protected void z0rek()
	{
		if (z0jrk == null)
		{
			throw new Exception("The current page undefined");
		}
	}

	[CompilerGenerated]
	internal bool z0tek()
	{
		return z0ark_jiejie20260327142557;
	}

	internal virtual void z0eek(bool p0 = false)
	{
		if (z0jrk == null)
		{
			return;
		}
		z0nek();
		foreach (z0ZzZzjdh item in z0hrk)
		{
			item.Dispose();
		}
		z0hrk.Clear();
		if (!p0)
		{
			z0krk.z0eek(z0jrk);
		}
		z0jrk.Dispose();
		z0jrk = null;
	}

	internal void z0eek(z0ZzZzaok p0)
	{
		z0jrk.z0pek();
		if (z0srk != null)
		{
			z0srk.z0pgk(z0jrk);
		}
		if (!z0lrk.z0iek())
		{
			float[] array = z0lrk.z0yek();
			z0jrk.z0rek(new z0ZzZzjej(array[0], array[1], array[2], array[3], array[4], array[5]));
		}
		p0();
		z0jrk.z0yek();
	}

	internal virtual void z0tgk()
	{
		if (z0qrk)
		{
			return;
		}
		if (z0jrk != null)
		{
			foreach (z0ZzZzjdh item in z0hrk)
			{
				item.Dispose();
			}
			z0hrk.Clear();
			z0jrk.Dispose();
			z0jrk = null;
		}
		if (z0krk != null)
		{
			z0krk.z0tek();
			z0krk = null;
		}
		z0qrk = true;
	}

	internal void z0eek(float p0)
	{
		z0lrk.z0eek(p0);
	}

	[CompilerGenerated]
	internal void z0rek(bool p0)
	{
		z0ark_jiejie20260327142557 = p0;
	}

	public void z0eek(z0ZzZztfh p0, z0ZzZzbdh p1)
	{
		if (z0eek(p0))
		{
			z0rek();
			z0eek(delegate
			{
				z0jrk.z0rek(p0);
				z0jrk.z0uek(p1);
			});
		}
	}

	internal void z0yek()
	{
		z0hrk.Push(z0lrk.z0uek());
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzpdh[] p1)
	{
		if (z0eek(p0.z0mek()))
		{
			z0rek();
			z0eek(delegate
			{
				z0jrk.z0rek(p0);
				z0jrk.z0yek(p1);
			});
		}
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzbdh p1)
	{
		if (z0eek(p0.z0mek()))
		{
			z0rek();
			z0eek(delegate
			{
				z0jrk.z0rek(p0);
				z0jrk.z0yek(p1);
			});
		}
	}

	internal z0ZzZzmlj z0uek()
	{
		return z0jrk;
	}

	public void z0iek()
	{
		z0yek(p0: true);
		z0jrk = null;
		z0krk = null;
	}

	public void z0eek(z0ZzZzxdh p0, int p1)
	{
		z0eek(p0, p1, z0ZzZzixk.z0rek(GraphicsUnit.Document), p3: true);
	}

	public void z0rek(z0ZzZztfh p0, z0ZzZzbdh p1)
	{
		if (z0eek(p0))
		{
			z0rek();
			z0eek(delegate
			{
				z0jrk.z0rek(p0);
				z0jrk.z0rek(p1);
			});
		}
	}

	internal void z0eek(z0ZzZzxdh p0, int p1, float p2, bool p3)
	{
		z0eek(p0: false);
		if (z0tek())
		{
			z0krk.z0uek();
		}
		float num = z0ZzZzoxk.z0eek(14400f, z0ZzZzixk.z0rek(GraphicsUnit.Point), p2);
		p0 = new z0ZzZzxdh(Math.Min(num, p0.z0rek()), Math.Min(num, p0.z0tek()));
		z0jrk = z0krk.z0eek(p0, p1, p2, p3);
		z0eek(new z0ZzZzbdh(z0ZzZzpdh.z0yek, p0));
		z0frk = p0;
	}

	internal void z0tek(bool p0)
	{
		z0ZzZzjdh z0ZzZzjdh2 = (p0 ? z0hrk.Pop() : z0hrk.Peek());
		z0lrk.z0rek(z0ZzZzjdh2);
		if (p0)
		{
			z0ZzZzjdh2.Dispose();
		}
	}

	protected static void z0eek(string p0)
	{
		if (z0ZzZzxxk.z0eek())
		{
			throw new NotSupportedException(p0);
		}
	}

	public z0ZzZzjdh z0oek()
	{
		return z0lrk;
	}

	public void z0eek(z0ZzZzudh p0, float p1, float p2, float p3, float p4)
	{
		if (z0eek(p0.z0mek()))
		{
			z0rek();
			z0eek(delegate
			{
				z0jrk.z0rek(p0);
				z0jrk.z0rek(p1, p2, p3, p4);
			});
		}
	}

	protected static bool z0eek(z0ZzZztfh p0)
	{
		if (p0 is z0ZzZzzdh z0ZzZzzdh2)
		{
			return z0ZzZzzdh2.z0eek.A != 0;
		}
		return true;
	}

	public void z0pek()
	{
		if (z0krk != null)
		{
			z0krk.z0yek().z0eek(p0: true);
		}
	}

	internal void z0eek(float p0, float p1)
	{
		z0lrk.z0eek(p0, p1);
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		if (p0.z0bek())
		{
			z0srk = null;
		}
		else if (!(z0srk is z0ZzZzdej) || !z0ZzZzbdh.z0eek(((z0ZzZzdej)z0srk).z0eek, p0))
		{
			z0srk = z0ZzZzqej.z0eek(p0, z0lrk);
		}
	}

	public void z0eek(object p0)
	{
		if (p0 is z0nxk z0nxk)
		{
			z0nxk.z0eek(this);
		}
	}

	public object z0mek()
	{
		return new z0nxk(this);
	}

	internal void z0nek()
	{
		z0lrk.z0tek_jiejie20260327142557();
	}

	private void z0eek(GraphicsUnit p0)
	{
		if (z0srk == null)
		{
			return;
		}
		float num = z0ZzZzixk.z0eek(p0) / z0ZzZzixk.z0eek(z0drk);
		using z0ZzZzjdh z0ZzZzjdh2 = z0lrk.z0uek();
		using z0ZzZzjdh z0ZzZzjdh3 = new z0ZzZzjdh(num, 0f, 0f, num, 0f, 0f);
		z0ZzZzjdh3.z0rek(z0ZzZzjdh2);
		z0ZzZzjdh2.z0oek();
		z0ZzZzjdh3.z0rek(z0ZzZzjdh2);
		z0srk.z0igk(z0ZzZzjdh3);
	}

	internal void z0eek(z0ZzZzqej p0)
	{
		z0srk = p0;
	}

	internal void z0yek(bool p0 = false)
	{
		if (!z0qrk)
		{
			z0qrk = true;
			z0eek(p0);
			if (z0krk != null)
			{
				z0krk.z0eek(p0);
				z0krk.Dispose();
				z0krk = null;
			}
		}
	}

	protected z0ZzZzxdh z0bek()
	{
		return z0frk;
	}

	protected virtual bool z0vek()
	{
		return true;
	}

	public void z0rek(GraphicsUnit p0)
	{
		z0drk = p0;
		z0eek(z0drk);
		if (z0jrk != null)
		{
			float num = z0ZzZzixk.z0rek(z0drk);
			z0jrk.z0rek(num, num);
		}
	}

	internal z0ZzZzqej z0cek()
	{
		return z0srk;
	}

	internal z0ZzZzwej(z0ZzZzaej p0)
	{
		z0krk = p0;
	}

	public z0ZzZzaej z0xek()
	{
		return z0krk;
	}

	public void z0rek(z0ZzZzudh p0, z0ZzZzbdh p1)
	{
		if (z0eek(p0.z0mek()))
		{
			z0rek();
			z0eek(delegate
			{
				z0jrk.z0rek(p0);
				z0jrk.z0iek(p1);
			});
		}
	}

	protected override void z0ygk(bool p0)
	{
		if (p0 && z0krk != null)
		{
			z0yek(p0: false);
			z0lrk.Dispose();
		}
	}

	public GraphicsUnit z0zek()
	{
		return z0drk;
	}

	public void z0eek(z0ZzZztfh p0, float p1, float p2, float p3, float p4)
	{
		z0eek(p0, new z0ZzZzbdh(p1, p2, p3, p4));
	}

	public void z0eek(z0ZzZzjdh p0)
	{
		z0lrk = p0;
	}
}
