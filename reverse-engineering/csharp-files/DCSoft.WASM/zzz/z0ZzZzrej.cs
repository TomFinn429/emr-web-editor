using System;
using System.IO;
using System.Runtime.CompilerServices;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzrej : z0ZzZzwej
{
	[CompilerGenerated]
	private sealed class z0xyk
	{
		public z0ZzZzzdh z0rek;

		public z0ZzZzddj z0tek;

		public z0ZzZzbdh z0yek;

		public z0ZzZzcxk z0uek;

		public z0ZzZztfh z0iek;

		public string z0oek;

		public z0ZzZzrej z0pek;

		public z0ZzZzpej z0mek;

		public string z0nek;

		internal void z0eek(z0ZzZzlsh p0)
		{
			z0luk z0luk = new z0luk
			{
				z0rek = this,
				z0tek = null
			};
			if (z0oek.Length == 1)
			{
				z0luk.z0tek = new string[1] { z0oek };
			}
			else
			{
				z0luk.z0tek = new z0ZzZzzxk(z0pek.z0zek(), z0uek).z0eek(z0nek, z0mek, z0yek.z0uek(), z0yek.z0iek(), p0);
			}
			if (z0luk.z0tek.Length != 0)
			{
				z0pek.z0uek.z0rek(z0rek(p0.z0pek()));
				z0pek.z0uek.z0eek(z0rek(p0.z0tek()));
				float num = 0f;
				z0pek.z0uek.z0eek(num);
				z0pek.z0uek.z0eek((p0.z0yek() & (z0ZzZzksh)1) != 0);
				z0pek.z0eek(z0luk.z0eek);
			}
		}
	}

	[CompilerGenerated]
	private sealed class z0luk
	{
		public z0xyk z0rek;

		public string[] z0tek;

		internal void z0eek()
		{
			z0ZzZzmlj z0ZzZzmlj2 = z0rek.z0pek.z0uek();
			z0ZzZzmlj2.z0rek(z0rek.z0iek);
			if (z0rek.z0tek.z0rek())
			{
				z0ZzZzmlj2.z0rek(z0rek.z0rek.z0eek, z0rek.z0tek.z0yek());
			}
			z0ZzZzmlj2.z0rek(z0tek, z0rek.z0tek, z0rek.z0yek, z0rek.z0pek.z0uek, z0rek.z0pek.z0eek());
		}
	}

	private new static z0ZzZzsdh z0yek;

	private new z0ZzZzcwj z0uek = (z0ZzZzcwj)z0ZzZzcwj.z0iek().z0rek();

	private static z0ZzZzvwj z0rek(StringAlignment p0)
	{
		return p0 switch
		{
			StringAlignment.Center => (z0ZzZzvwj)1, 
			StringAlignment.Far => (z0ZzZzvwj)2, 
			_ => (z0ZzZzvwj)0, 
		};
	}

	private static z0ZzZzlsh z0rek(z0ZzZzlsh p0)
	{
		if (p0 == null)
		{
			return z0ZzZzlsh.z0uek().z0eek();
		}
		z0ZzZzlsh z0ZzZzlsh2 = p0.z0eek();
		StringAlignment p1 = z0ZzZzlsh2.z0pek();
		StringAlignment p2 = z0ZzZzlsh2.z0tek();
		bool flag = (z0ZzZzlsh2.z0yek() & (z0ZzZzksh)2) != 0;
		bool num = (z0ZzZzlsh2.z0yek() & (z0ZzZzksh)1) != 0;
		if (flag)
		{
			z0ZzZzlsh2.z0rek(p2);
			z0ZzZzlsh2.z0eek(p1);
		}
		if (num)
		{
			z0ZzZzlsh2.z0rek(z0tek(z0ZzZzlsh2.z0pek()));
		}
		return z0ZzZzlsh2;
	}

	private void z0rek(float p0, float p1)
	{
		z0eek(0f - p0, 0f - p1);
		z0eek(90f);
		z0eek(p0, p1);
	}

	public new z0ZzZzcxk z0rek()
	{
		return new z0ZzZzvxk();
	}

	internal static void z0eek(z0ZzZzpej p0, z0ZzZzbdh p1, GraphicsUnit p2, z0ZzZzlsh p3, Action<z0ZzZzlsh> p4)
	{
		p4(p3);
	}

	private z0ZzZzqej z0rek(z0ZzZzbdh p0, z0ZzZzlsh p1)
	{
		return z0cek();
	}

	private static float z0rek(StringAlignment p0, z0ZzZzbdh p1)
	{
		return p0 switch
		{
			StringAlignment.Near => p1.z0pek(), 
			StringAlignment.Center => p1.z0pek() + p1.z0iek() / 2f, 
			StringAlignment.Far => p1.z0nek(), 
			_ => throw new ArgumentException(), 
		};
	}

	private static StringAlignment z0tek(StringAlignment p0)
	{
		return p0 switch
		{
			StringAlignment.Near => StringAlignment.Far, 
			StringAlignment.Far => StringAlignment.Near, 
			_ => p0, 
		};
	}

	public void z0rek(string p0, z0ZzZzpej p1, z0ZzZztfh p2, z0ZzZzbdh p3, z0ZzZzlsh p4, z0ZzZzcxk p5)
	{
		if (!z0ZzZzwej.z0eek(p2))
		{
			return;
		}
		base.z0rek();
		if (p0 == null)
		{
			throw new ArgumentNullException("s");
		}
		if (p0.Length == 0)
		{
			return;
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("font");
		}
		if (p2 == null)
		{
			throw new ArgumentNullException("brush");
		}
		z0ZzZzzdh z0rek = p2 as z0ZzZzzdh;
		if (z0rek == null)
		{
			throw new NotSupportedException("The brush must be solid");
		}
		if (z0rek.z0eek.A == 0 || p3.z0bek())
		{
			return;
		}
		using z0ZzZzlsh z0ZzZzlsh2 = z0ZzZzrej.z0rek(p4);
		bool flag = false;
		if (p1.z0uek != GraphicsUnit.Point)
		{
			p1 = new z0ZzZzpej(p1.z0iek, z0ZzZzbxk.z0eek(p1.z0bek, p1.z0uek), p1.z0mek);
			flag = true;
		}
		z0ZzZzksh z0ZzZzksh2 = z0ZzZzlsh2.z0yek();
		z0ZzZzqej p6 = this.z0rek(p3, z0ZzZzlsh2);
		try
		{
			z0cek();
			string z0nek = z0ZzZzrej.z0rek(p0, '\r');
			bool flag2 = (z0ZzZzksh2 & (z0ZzZzksh)2) != 0;
			if (flag2)
			{
				z0yek();
				this.z0rek(z0ZzZzrej.z0tek(z0ZzZzlsh2.z0pek(), p3), z0ZzZzrej.z0rek(z0ZzZzlsh2.z0tek(), p3));
			}
			try
			{
				z0ZzZzddj z0tek = z0xek().z0eek(p1);
				if (z0tek.z0tek().z0oek())
				{
					z0ZzZzwej.z0eek(p1.z0iek);
					z0nek = "NotSupportedFont";
					p1 = new z0ZzZzpej("Tahoma", p1.z0bek, p1.z0mek);
					flag = true;
					z0tek = z0xek().z0eek(p1);
				}
				if (z0tek.z0tek().z0eek(p0))
				{
					string[] array = z0ZzZzmej.z0tek;
					foreach (string text in array)
					{
						if (text != p1.z0iek)
						{
							z0ZzZzpej p7 = new z0ZzZzpej(text, p1.z0bek, p1.z0mek, p1.z0uek);
							z0ZzZzddj z0ZzZzddj2 = z0xek().z0eek(p7);
							if (z0ZzZzddj2 != null && z0ZzZzddj2.z0tek().z0eek(p0, 0, out var _) != 0)
							{
								z0tek = z0ZzZzddj2;
								p1 = new z0ZzZzpej(text, p1.z0bek, p1.z0mek);
								break;
							}
						}
					}
				}
				z0xyk CS_0024_003C_003E8__locals0;
				z0eek(p1, p3, z0zek(), z0ZzZzlsh2, delegate(z0ZzZzlsh z0ZzZzlsh3)
				{
					z0luk z0luk = new z0luk();
					z0luk.z0rek = CS_0024_003C_003E8__locals0;
					z0luk.z0tek = null;
					if (p0.Length == 1)
					{
						z0luk.z0tek = new string[1] { p0 };
					}
					else
					{
						z0luk.z0tek = new z0ZzZzzxk(z0zek(), p5).z0eek(z0nek, p1, p3.z0uek(), p3.z0iek(), z0ZzZzlsh3);
					}
					if (z0luk.z0tek.Length != 0)
					{
						z0uek.z0rek(z0ZzZzrej.z0rek(z0ZzZzlsh3.z0pek()));
						z0uek.z0eek(z0ZzZzrej.z0rek(z0ZzZzlsh3.z0tek()));
						float num = 0f;
						z0uek.z0eek(num);
						z0uek.z0eek((z0ZzZzlsh3.z0yek() & (z0ZzZzksh)1) != 0);
						z0eek(z0luk.z0eek);
					}
				});
			}
			finally
			{
				if (flag2)
				{
					base.z0nek();
					base.z0tek(p0: true);
				}
			}
		}
		finally
		{
			z0eek(p6);
			if (flag)
			{
				p1.Dispose();
			}
		}
	}

	internal override void z0tgk()
	{
		base.z0tgk();
		z0uek = null;
	}

	public z0ZzZzrej(Stream p0, z0ZzZzazk p1, bool p2)
		: base(new z0ZzZzaej(p0, p1, p2))
	{
	}

	private static string z0rek(string p0, char p1)
	{
		for (int num = p0.Length - 1; num >= 0; num--)
		{
			if (p0[num] == p1)
			{
				p0 = p0.Remove(num, 1);
			}
		}
		return p0;
	}

	public void z0rek(string p0, z0ZzZzsdh p1, z0ZzZztfh p2, z0ZzZzbdh p3, z0ZzZzlsh p4, z0ZzZzcxk p5)
	{
		z0rek(p0, new z0ZzZzpej(p1), p2, p3, p4, p5);
	}

	private static float z0tek(StringAlignment p0, z0ZzZzbdh p1)
	{
		return p0 switch
		{
			StringAlignment.Near => p1.z0oek(), 
			StringAlignment.Center => p1.z0oek() + p1.z0uek() / 2f, 
			StringAlignment.Far => p1.z0mek(), 
			_ => throw new ArgumentException(), 
		};
	}
}
