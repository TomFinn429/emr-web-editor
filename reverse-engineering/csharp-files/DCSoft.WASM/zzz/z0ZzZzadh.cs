using System;
using System.Collections.Generic;
using System.Text;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public sealed class z0ZzZzadh : IDisposable
{
	public delegate bool z0vnk();

	private struct z0lnk
	{
		public bool z0rek;

		private uint z0tek;

		private float z0yek;

		private float z0uek;

		private float z0iek;

		private float z0oek;

		private int z0pek;

		private int z0mek;

		public z0lnk()
		{
			z0tek = 0u;
			z0yek = 0f;
			z0uek = 0f;
			z0iek = 0f;
			z0oek = 0f;
			z0pek = 0;
			z0rek = false;
			z0mek = 0;
		}

		private z0lnk(z0ZzZzzdh p0, float p1, float p2, float p3, float p4, int p5)
		{
			z0rek = false;
			z0mek = 0;
			z0tek = p0.z0rek;
			z0yek = p1;
			z0uek = p2;
			z0iek = p1 + p3;
			z0oek = p4;
			z0pek = p5;
		}

		public void z0eek(z0ZzZzzdh p0, float p1, float p2, float p3, float p4, int p5)
		{
			z0tek = p0.z0rek;
			z0yek = p1;
			z0uek = p2;
			z0iek = p1 + p3;
			z0oek = p4;
			z0pek = p5;
			z0mek = 0;
		}

		public bool z0eek(z0ZzZzzdh p0, float p1, float p2, float p3, float p4)
		{
			if (z0uek == p2 && z0oek == p4 && p0.z0rek == z0tek)
			{
				float num = p1 - z0iek;
				if (-0.5f < num && num < 0.5f)
				{
					z0iek = p1 + p3;
					z0mek++;
					return true;
				}
			}
			return false;
		}

		public void z0eek(z0ZzZzadh p0)
		{
			if (z0mek > 0)
			{
				int num = p0.z0zrk.z0uek;
				p0.z0zrk.z0uek = z0pek;
				p0.z0zrk.z0eek((int)((z0iek - z0yek) * p0.z0ork * p0.z0xrk));
				p0.z0zrk.z0uek = num;
			}
		}
	}

	private class z0bck : z0rxk<byte[]>
	{
		private static readonly z0ZzZzwyk z0eek = new z0ZzZzwyk(p0: true);

		protected override void z0gh(z0ZzZzydh p0, byte[] p1, z0ZzZzadh p2)
		{
			if (z0ZzZzpuk.z0uek(p1))
			{
				p0.z0eek((byte)0);
			}
			else if (z0ZzZzpuk.z0yek(p1))
			{
				p0.z0eek((byte)1);
			}
			else if (z0ZzZzpuk.z0eek(p1))
			{
				p0.z0eek((byte)2);
			}
			else if (z0ZzZzpuk.z0tek(p1))
			{
				p0.z0eek((byte)3);
			}
			else
			{
				p0.z0eek((byte)4);
			}
			p0.z0eek(p1);
		}

		public override int GetHashCode(byte[] item)
		{
			return z0eek.GetHashCode(item);
		}

		protected override z0ZzZzqdh z0hh()
		{
			return (z0ZzZzqdh)29;
		}

		public override bool Equals(byte[] item1, byte[] item2)
		{
			return z0eek.Equals(item1, item2);
		}
	}

	private abstract class z0rxk<T> : IEqualityComparer<T>
	{
		protected T z0tek;

		protected short z0yek = -1;

		private Dictionary<T, short> z0uek;

		protected abstract z0ZzZzqdh z0hh();

		public void z0rek(z0ZzZzydh p0, z0ZzZzadh p1)
		{
			if (z0uek.Count > 0)
			{
				p0.z0eek(z0hh());
				T[] array = z0eek();
				p0.z0eek((short)array.Length);
				T[] array2 = array;
				foreach (T p2 in array2)
				{
					z0gh(p0, p2, p1);
				}
			}
		}

		protected abstract void z0gh(z0ZzZzydh p0, T p1, z0ZzZzadh p2);

		protected virtual T z0jh(T p0)
		{
			return p0;
		}

		private T[] z0eek()
		{
			if (z0uek.Count == 0)
			{
				return null;
			}
			T[] array = new T[z0uek.Count];
			foreach (KeyValuePair<T, short> item in z0uek)
			{
				array[item.Value] = item.Key;
			}
			return array;
		}

		protected z0rxk()
		{
			z0uek = new Dictionary<T, short>(this);
		}

		public virtual short z0qh(T p0)
		{
			short num = 0;
			if (!z0uek.TryGetValue(p0, out num))
			{
				num = (short)z0uek.Count;
				p0 = z0jh(p0);
				z0uek[p0] = num;
				z0tek = p0;
			}
			else
			{
				z0tek = p0;
			}
			z0yek = num;
			return num;
		}

		public abstract bool Equals(T item1, T item2);

		public abstract int GetHashCode(T item);

		public virtual void z0fh()
		{
			if (z0uek != null)
			{
				z0uek.Clear();
				z0uek = null;
			}
		}
	}

	private class z0kck : z0rxk<z0ZzZztfh>
	{
		protected override z0ZzZzqdh z0hh()
		{
			return (z0ZzZzqdh)30;
		}

		public short z0eek_jiejie20260327142557(Color p0)
		{
			if (z0tek is z0ZzZzzdh && ((z0ZzZzzdh)z0tek).z0rek == p0._value)
			{
				return z0yek;
			}
			return base.z0qh(new z0ZzZzzdh(p0));
		}

		public override int GetHashCode(z0ZzZztfh obj)
		{
			if (obj is z0ZzZzzdh)
			{
				return (int)((z0ZzZzzdh)obj).z0rek;
			}
			return obj.GetHashCode();
		}

		protected override void z0gh(z0ZzZzydh p0, z0ZzZztfh p1, z0ZzZzadh p2)
		{
			if (p1 is z0ZzZzzdh)
			{
				p0.z0eek(z0rek(((z0ZzZzzdh)p1).z0eek));
			}
			else if (p1 is z0ZzZzxfh)
			{
				z0ZzZzxfh z0ZzZzxfh2 = (z0ZzZzxfh)p1;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("*");
				if (!z0ZzZzxfh2.z0rek.z0eek() || !z0ZzZzxfh2.z0pek.z0eek())
				{
					z0eek_jiejie20260327142557(stringBuilder, z0ZzZzxfh2.z0rek.z0rek(), z0ZzZzxfh2.z0rek.z0tek(), z0ZzZzxfh2.z0pek.z0rek(), z0ZzZzxfh2.z0pek.z0tek(), p2);
				}
				else
				{
					switch (z0ZzZzxfh2.z0mek)
					{
					case (z0ZzZzzfh)3:
						z0eek_jiejie20260327142557(stringBuilder, z0ZzZzxfh2.z0tek.z0mek(), z0ZzZzxfh2.z0tek.z0pek(), z0ZzZzxfh2.z0tek.z0oek(), z0ZzZzxfh2.z0tek.z0nek(), p2);
						break;
					case (z0ZzZzzfh)2:
						z0eek_jiejie20260327142557(stringBuilder, z0ZzZzxfh2.z0tek.z0oek(), z0ZzZzxfh2.z0tek.z0pek(), z0ZzZzxfh2.z0tek.z0mek(), z0ZzZzxfh2.z0tek.z0nek(), p2);
						break;
					case (z0ZzZzzfh)0:
						z0eek_jiejie20260327142557(stringBuilder, z0ZzZzxfh2.z0tek.z0oek(), z0ZzZzxfh2.z0tek.z0pek(), z0ZzZzxfh2.z0tek.z0mek(), z0ZzZzxfh2.z0tek.z0pek(), p2);
						break;
					case (z0ZzZzzfh)1:
						z0eek_jiejie20260327142557(stringBuilder, z0ZzZzxfh2.z0tek.z0oek(), z0ZzZzxfh2.z0tek.z0pek(), z0ZzZzxfh2.z0tek.z0oek(), z0ZzZzxfh2.z0tek.z0nek(), p2);
						break;
					}
				}
				if (z0ZzZzxfh2.z0eek() == null || z0ZzZzxfh2.z0eek().z0tek())
				{
					stringBuilder.Append("$0$");
					stringBuilder.Append(z0rek(z0ZzZzxfh2.z0uek));
					stringBuilder.Append("$1");
					stringBuilder.Append(z0rek(z0ZzZzxfh2.z0iek));
				}
				else
				{
					Color[] array = z0ZzZzxfh2.z0eek().z0eek();
					float[] array2 = z0ZzZzxfh2.z0eek().z0rek();
					int num = Math.Min(array.Length, array2.Length);
					for (int i = 0; i < num; i++)
					{
						stringBuilder.Append('$');
						stringBuilder.Append(array2[i]);
						stringBuilder.Append('$');
						stringBuilder.Append(z0rek(array[i]));
					}
				}
				string p3 = stringBuilder.ToString();
				p0.z0eek(p3);
			}
			else
			{
				p0.z0eek("red");
			}
		}

		private static void z0eek_jiejie20260327142557(StringBuilder p0, float p1, float p2, float p3, float p4, z0ZzZzadh p5)
		{
			float num = p5.z0ork * p5.z0xrk;
			float num2 = p5.z0frk * p5.z0ork;
			float num3 = p5.z0erk * p5.z0ork;
			p0.Append('$');
			p0.Append(p1 * num + num2);
			p0.Append('$');
			p0.Append(p2 * num + num3);
			p0.Append('$');
			p0.Append(p3 * num + num2);
			p0.Append('$');
			p0.Append(p4 * num + num3);
		}

		public override bool Equals(z0ZzZztfh x, z0ZzZztfh y)
		{
			z0ZzZzzdh z0ZzZzzdh2 = x as z0ZzZzzdh;
			z0ZzZzzdh z0ZzZzzdh3 = y as z0ZzZzzdh;
			if (z0ZzZzzdh2 != null && z0ZzZzzdh3 != null)
			{
				return z0ZzZzzdh2.z0rek == z0ZzZzzdh3.z0rek;
			}
			return false;
		}

		public override short z0qh(z0ZzZztfh p0)
		{
			if (!(p0 is z0ZzZzzdh))
			{
				return base.z0qh(p0);
			}
			if (p0 == z0tek)
			{
				return z0yek;
			}
			if (z0tek != null && p0.z0jd(z0tek))
			{
				return z0yek;
			}
			return base.z0qh(p0);
		}

		private static string z0rek(Color p0)
		{
			if (p0.A == 255)
			{
				return z0ZzZzifh.z0eek(p0);
			}
			return "rgba(" + p0.R + "," + p0.G + "," + p0.B + "," + ((double)(int)p0.A / 255.0).ToString("0.00") + ")";
		}
	}

	private class z0zck : z0rxk<z0ZzZzudh>
	{
		public float z0eek = 1f;

		protected override z0ZzZzudh z0jh(z0ZzZzudh p0)
		{
			return p0.z0iek();
		}

		protected override z0ZzZzqdh z0hh()
		{
			return (z0ZzZzqdh)20;
		}

		public override bool Equals(z0ZzZzudh x, z0ZzZzudh y)
		{
			if (x.z0nek().ToArgb() == y.z0nek().ToArgb() && x.z0oek() == y.z0oek())
			{
				return x.z0tek() == y.z0tek();
			}
			return false;
		}

		public override int GetHashCode(z0ZzZzudh obj)
		{
			return obj.z0nek().ToArgb() + obj.z0oek().GetHashCode() + obj.z0tek().GetHashCode();
		}

		protected override void z0gh(z0ZzZzydh p0, z0ZzZzudh p1, z0ZzZzadh p2)
		{
			p0.z0eek(z0ZzZzifh.z0eek(p1.z0nek()));
			if (p1.z0oek() == 0f)
			{
				p0.z0eek((byte)0);
			}
			else if (p1.z0oek() == 1f)
			{
				p0.z0eek((byte)1);
			}
			else
			{
				byte p3 = (byte)Math.Ceiling(z0eek * p1.z0oek());
				p0.z0eek(p3);
			}
			p0.z0eek((byte)p1.z0tek());
		}

		public override short z0qh(z0ZzZzudh p0)
		{
			if (p0 != null && z0tek != null && p0.z0eek(z0tek))
			{
				return z0yek;
			}
			return base.z0qh(p0);
		}
	}

	private class z0dck : z0rxk<Color>
	{
		public override bool Equals(Color x, Color y)
		{
			return x.ToArgb() == y.ToArgb();
		}

		protected override z0ZzZzqdh z0hh()
		{
			return (z0ZzZzqdh)19;
		}

		protected override void z0gh(z0ZzZzydh p0, Color p1, z0ZzZzadh p2)
		{
			if (p1.A != 255)
			{
				p0.z0eek("argb(" + p1.R + "," + p1.G + "," + p1.B + "," + (double)(int)p1.A / 255.0 + ")");
			}
			else
			{
				p0.z0eek(z0ZzZzifh.z0eek(p1));
			}
		}

		public override int GetHashCode(Color obj)
		{
			return obj.ToArgb();
		}
	}

	private class z0nck : z0rxk<z0ZzZzsdh>
	{
		private StringBuilder z0eek = new StringBuilder();

		public new float z0rek = 1f;

		protected override void z0gh(z0ZzZzydh p0, z0ZzZzsdh p1, z0ZzZzadh p2)
		{
			if ((p1.z0mek() & FontStyle.Bold) == FontStyle.Bold)
			{
				z0eek.Append("bold ");
			}
			if ((p1.z0mek() & FontStyle.Italic) == FontStyle.Italic)
			{
				z0eek.Append("italic ");
			}
			if (p1.z0yek() > 0f)
			{
				float num = z0ZzZzrpk.z0eek(z0rek * p1.z0yek(), GraphicsUnit.Point, GraphicsUnit.Pixel);
				if ((double)Math.Abs(num - (float)(int)num) < 0.5)
				{
					z0eek.Append(z0ZzZzqik.z0rek((int)num)).Append("px ");
				}
				else
				{
					z0eek.Append(num.ToString("0.00")).Append("px ");
				}
			}
			if (string.IsNullOrEmpty(p1.z0pek()))
			{
				z0eek.Append("宋体");
			}
			else
			{
				z0eek.Append(p1.z0pek());
			}
			p0.z0eek(z0eek.ToString());
			z0eek.Clear();
		}

		public override int GetHashCode(z0ZzZzsdh obj)
		{
			return (int)(((obj.z0pek() != null) ? obj.z0pek().GetHashCode() : 0) + obj.z0yek().GetHashCode() + obj.z0mek());
		}

		protected override z0ZzZzqdh z0hh()
		{
			return (z0ZzZzqdh)18;
		}

		public override void z0fh()
		{
			z0eek = null;
			base.z0fh();
		}

		public override bool Equals(z0ZzZzsdh x, z0ZzZzsdh y)
		{
			if (x.z0pek() == y.z0pek() && x.z0yek() == y.z0yek())
			{
				return x.z0mek() == y.z0mek();
			}
			return false;
		}
	}

	private bool z0grk;

	private float z0frk;

	private z0ZzZzjdh z0drk = new z0ZzZzjdh();

	private bool z0ark;

	private static readonly float z0qrk = (float)Math.PI / 180f;

	private z0ZzZzfdh z0wrk;

	private float z0erk;

	private z0dck z0rrk = new z0dck();

	private z0ZzZztfh z0yrk;

	private InterpolationMode z0urk = InterpolationMode.High;

	internal z0ZzZzbdh z0irk = z0ZzZzbdh.z0xek;

	private float z0ork = 1f;

	private z0lnk z0prk = new z0lnk();

	private z0bck z0mrk = new z0bck();

	private bool z0nrk;

	private z0kck z0brk = new z0kck();

	private z0ZzZzfsh z0vrk = (z0ZzZzfsh)5;

	private SmoothingMode z0crk = SmoothingMode.HighQuality;

	private float z0xrk = 1f;

	private z0ZzZzydh z0zrk;

	public static z0vnk z0ltk = null;

	private z0zck z0ktk = new z0zck();

	private z0ZzZzsdh z0htk;

	private z0nck z0gtk = new z0nck();

	private z0ZzZzedh z0ftk;

	private GraphicsUnit z0dtk = GraphicsUnit.Pixel;

	public void z0eek(z0ZzZztfh p0, z0ZzZznfh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("brush");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("path");
		}
		short p2 = z0brk.z0qh(p0);
		z0zrk.z0eek((z0ZzZzqdh)37);
		z0zrk.z0eek(p2);
		z0zrk.z0eek(z0ork * z0xrk);
		z0zrk.z0eek(z0frk * z0ork);
		z0zrk.z0eek(z0erk * z0ork);
		z0zrk.z0eek(p1.z0yek());
	}

	public z0ZzZzbdh z0eek(float p0, float p1, float p2, float p3, float p4)
	{
		float num = z0frk + p0 * z0xrk;
		float num2 = z0erk + p1 * z0xrk;
		float num3 = p2 * z0xrk;
		float num4 = p3 * z0xrk;
		if (!z0drk.z0iek())
		{
			z0ZzZzpdh z0ZzZzpdh2 = z0drk.z0eek(num, num2, z0xrk);
			z0ZzZzpdh z0ZzZzpdh3 = z0drk.z0eek(num + num3, num2 + num4, z0xrk);
			return new z0ZzZzbdh(z0ZzZzpdh2.z0rek() * p4, z0ZzZzpdh2.z0tek() * p4, (z0ZzZzpdh3.z0rek() - z0ZzZzpdh2.z0rek()) * p4, (z0ZzZzpdh3.z0tek() - z0ZzZzpdh2.z0tek()) * p4);
		}
		return new z0ZzZzbdh(num * p4, num2 * p4, num3 * p4, num4 * p4);
	}

	public void z0eek(string p0, z0ZzZzsdh p1, z0ZzZztfh p2, float p3, float p4)
	{
		z0eek(p0, p1, p2, new z0ZzZzbdh(p3, p4, 0f, 0f), null);
	}

	public void z0eek(z0ZzZztfh p0, z0ZzZzndh p1)
	{
		z0eek(p0, p1.z0yek(), p1.z0uek(), p1.z0iek(), p1.z0oek(), 0f);
	}

	public void z0eek(float p0)
	{
		z0ork = p0;
		z0gtk.z0rek = p0;
	}

	public void z0eek(z0ZzZzfdh p0)
	{
		z0zek();
		z0wrk = p0;
	}

	public void z0eek()
	{
		z0irk = z0ZzZzbdh.z0xek;
		z0zrk.z0eek((z0ZzZzqdh)28);
	}

	public z0ZzZzbfh z0rek()
	{
		return new z0ZzZzbfh(this);
	}

	public void z0eek(Color p0)
	{
	}

	public void z0eek(z0ZzZzedh p0, float p1, float p2, float p3, float p4)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("image");
		}
		byte[] array = p0.z0gd();
		if (array != null && array.Length != 0)
		{
			short p5 = z0mrk.z0qh(array);
			z0zrk.z0eek((z0ZzZzqdh)22);
			z0zrk.z0eek(p5);
			z0rek(p1, p2, p3, p4);
		}
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzndh p1, float p2, float p3)
	{
		z0eek(p0, p1.z0yek(), p1.z0uek(), p1.z0iek(), p1.z0oek(), p2, p3);
	}

	public void z0tek()
	{
		z0nrk = false;
		if (z0prk.z0rek)
		{
			z0prk.z0eek(this);
			z0prk.z0rek = false;
		}
	}

	public void Dispose()
	{
		if (z0ftk is z0ZzZzrfh)
		{
			z0ZzZzydh z0ZzZzydh2 = new z0ZzZzydh();
			z0ZzZzydh2.z0eek((byte)133);
			z0ZzZzydh2.z0eek((short)z0ftk.z0iek());
			z0ZzZzydh2.z0eek((short)z0ftk.z0yek());
			byte[] p = z0eek(z0ZzZzydh2);
			z0ZzZzydh2.Dispose();
			((z0ZzZzrfh)z0ftk).z0tek(p);
		}
		z0grk = true;
		z0ftk = null;
		if (z0rrk != null)
		{
			z0rrk.z0fh();
			z0rrk = null;
		}
		if (z0gtk != null)
		{
			z0gtk.z0fh();
			z0gtk = null;
		}
		if (z0ktk != null)
		{
			z0ktk.z0fh();
			z0ktk = null;
		}
		if (z0mrk != null)
		{
			z0mrk.z0fh();
			z0mrk = null;
		}
		if (z0zrk != null)
		{
			z0zrk.Dispose();
			z0zrk = null;
		}
	}

	public z0ZzZzxdh z0eek(string p0, z0ZzZzsdh p1, int p2, z0ZzZzlsh p3)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return z0ZzZzxdh.z0yek;
		}
		if (p0.Length == 1)
		{
			return z0ZzZzlcj.z0rek(z0dtk, p0[0], p1);
		}
		z0ZzZzlcj.z0eek(z0jrk(), p0, p1.z0pek(), p1.z0yek(), p1.z0mek(), p2, p3, out var p4, null);
		if (p4.z0eek())
		{
			return z0ZzZzlcj.z0rek(z0dtk, p0, p1);
		}
		return p4;
	}

	public void z0rek(float p0)
	{
		z0zrk.z0eek((z0ZzZzqdh)25);
		z0zrk.z0eek((float)((double)p0 * Math.PI / 180.0));
		z0drk.z0eek(p0);
	}

	public void z0eek(z0ZzZztfh p0, z0ZzZzpdh[] p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("brush");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("points");
		}
		if (p1.Length != 0)
		{
			short p2 = z0brk.z0qh(p0);
			z0zrk.z0eek((z0ZzZzqdh)33);
			z0zrk.z0eek(p2);
			z0eek(p1);
		}
	}

	public void z0eek(z0ZzZzvdh p0)
	{
		throw new NotSupportedException();
	}

	private void z0eek(z0ZzZzbdh p0)
	{
		z0rek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek());
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzpdh[] p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("pen");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("points");
		}
		if (p1.Length != 0)
		{
			short p2 = z0ktk.z0qh(p0);
			z0zrk.z0eek((z0ZzZzqdh)31);
			z0zrk.z0eek(p2);
			z0eek(p1);
		}
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzbdh p1)
	{
		z0rek(p0, p1.z0tek(), p1.z0yek(), p1.z0uek(), p1.z0iek());
	}

	public void z0eek(z0ZzZzudh p0, float p1, float p2, float p3, float p4, float p5 = 0f)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("pen");
		}
		if (z0irk.z0bek() || (!(p1 + p3 < z0irk.z0oek()) && !(p1 > z0irk.z0mek()) && !(p2 + p4 < z0irk.z0pek()) && !(p2 > z0irk.z0nek())))
		{
			short p6 = z0ktk.z0qh(p0);
			if (p5 > 0f)
			{
				z0zrk.z0eek((z0ZzZzqdh)8);
				z0zrk.z0eek(p6);
				z0zrk.z0eek((short)(p5 * z0xrk));
				z0rek(p1, p2, p3, p4);
			}
			else
			{
				z0zrk.z0eek((z0ZzZzqdh)9);
				z0zrk.z0eek(p6);
				z0rek(p1, p2, p3, p4);
			}
		}
	}

	public void z0eek(float p0, float p1)
	{
		z0drk.z0eek(p0, p1);
		z0cek();
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZzndh p1)
	{
		z0eek(p0, p1.z0yek(), p1.z0uek(), p1.z0iek(), p1.z0oek());
	}

	public void z0eek(z0ZzZzudh p0, float p1, float p2, float p3, float p4, float p5, float p6)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("pen");
		}
		short p7 = z0ktk.z0qh(p0);
		z0zrk.z0eek((z0ZzZzqdh)35);
		z0zrk.z0eek(p7);
		z0rek(p1, p2, p3, p4);
		z0zrk.z0eek(z0eek(p5, p3, p4));
		z0zrk.z0eek(z0eek(p5 + p6, p3, p4));
	}

	public z0ZzZzfdh z0yek()
	{
		z0zek();
		return z0wrk;
	}

	private void z0eek(float p0, float p1, float p2, float p3)
	{
		if (z0ork == 1f)
		{
			z0zrk.z0eek(BitConverter.SingleToInt32Bits(z0frk + p0 * z0xrk), BitConverter.SingleToInt32Bits(z0erk + p1 * z0xrk), BitConverter.SingleToInt32Bits(p2 * z0xrk), BitConverter.SingleToInt32Bits(p3 * z0xrk));
		}
		else
		{
			z0zrk.z0eek(BitConverter.SingleToInt32Bits(z0ork * (z0frk + p0 * z0xrk)), BitConverter.SingleToInt32Bits(z0ork * (z0erk + p1 * z0xrk)), BitConverter.SingleToInt32Bits(z0ork * p2 * z0xrk), BitConverter.SingleToInt32Bits(z0ork * p3 * z0xrk));
		}
	}

	public float z0uek()
	{
		return z0ork;
	}

	public byte[] z0iek()
	{
		z0ZzZzydh z0ZzZzydh2 = new z0ZzZzydh(z0ZzZzydh.z0iek);
		byte[] result = z0eek(z0ZzZzydh2);
		z0ZzZzydh2.Dispose();
		return result;
	}

	public InterpolationMode z0oek()
	{
		z0zek();
		return z0urk;
	}

	public void z0eek(z0ZzZzedh p0, int p1, int p2, int p3, int p4)
	{
		z0eek(p0, (float)p1, (float)p2, (float)p3, (float)p4);
	}

	public void z0eek(z0ZzZztfh p0, float p1, float p2, float p3, float p4, float p5 = 0f)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("brush");
		}
		if (p5 > 0f)
		{
			if (z0nrk && z0prk.z0rek)
			{
				z0prk.z0eek(this);
				z0prk.z0rek = false;
			}
			short p6 = z0brk.z0qh(p0);
			z0zrk.z0eek((z0ZzZzqdh)43);
			z0zrk.z0eek(p6);
			z0zrk.z0eek((short)(p5 * z0xrk));
			z0rek(p1, p2, p3, p4);
			return;
		}
		if (z0nrk && p0 is z0ZzZzzdh && z0prk.z0rek)
		{
			if (z0prk.z0eek((z0ZzZzzdh)p0, p1, p2, p3, p4))
			{
				return;
			}
			z0prk.z0eek(this);
			z0prk.z0rek = false;
		}
		short p7 = z0brk.z0qh(p0);
		z0zrk.z0eek((z0ZzZzqdh)10);
		z0zrk.z0eek(p7);
		if (z0nrk && p0 is z0ZzZzzdh && !z0prk.z0rek)
		{
			z0prk.z0rek = true;
			z0prk.z0eek((z0ZzZzzdh)p0, p1, p2, p3, p4, z0tek(p1, p2, p3, p4));
		}
		else
		{
			z0rek(p1, p2, p3, p4);
		}
	}

	public void z0eek(z0ZzZztfh p0, float p1, float p2, float p3, float p4)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("brush");
		}
		z0zek();
		short p5 = z0brk.z0qh(p0);
		z0zrk.z0eek((z0ZzZzqdh)12);
		z0zrk.z0eek(p5);
		z0rek(p1, p2, p3, p4);
	}

	public void z0eek(SmoothingMode p0)
	{
		z0zek();
		z0crk = p0;
	}

	public void z0eek(z0ZzZzudh p0, float p1, float p2, float p3, float p4)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("pen");
		}
		short p5 = z0ktk.z0qh(p0);
		z0zrk.z0eek((z0ZzZzqdh)5);
		z0zrk.z0eek(p5);
		z0tek(p1, p2);
		z0tek(p3, p4);
	}

	public void z0eek(char p0, z0ZzZzsdh p1, Color p2, float p3, float p4, float p5)
	{
		if (z0yrk == null || !z0yrk.z0kd(p2))
		{
			short p6 = z0brk.z0eek_jiejie20260327142557(p2);
			z0yrk = new z0ZzZzzdh(p2);
			z0zrk.z0eek((z0ZzZzqdh)2);
			z0zrk.z0eek(p6);
		}
		z0eek(p1);
		z0zrk.z0eek((z0ZzZzqdh)7);
		z0zrk.z0eek(p0);
		if (p5 > 0f)
		{
			z0tek(p3, p4 + p5 * 0.74f);
		}
		else
		{
			z0tek(p3, p4 + p1.z0eek(z0dtk) * 0.74f);
		}
	}

	public void z0rek(z0ZzZzbdh p0)
	{
		z0irk = p0;
		z0zrk.z0eek((z0ZzZzqdh)27);
		z0rek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek());
	}

	public float z0pek()
	{
		return 96f;
	}

	public void z0eek(GraphicsUnit p0)
	{
		if (z0dtk != p0)
		{
			z0zek();
			z0dtk = p0;
			z0zrk.z0eek((z0ZzZzqdh)23);
			z0zrk.z0eek((byte)p0);
			switch (p0)
			{
			case GraphicsUnit.World:
				z0xrk = 1f;
				break;
			case GraphicsUnit.Display:
				z0xrk = 1f;
				break;
			case GraphicsUnit.Pixel:
				z0xrk = 1f;
				break;
			case GraphicsUnit.Point:
				z0xrk = 1.3333334f;
				break;
			case GraphicsUnit.Inch:
				z0xrk = 96f;
				break;
			case GraphicsUnit.Document:
				z0xrk = 0.32f;
				break;
			case GraphicsUnit.Millimeter:
				z0xrk = 3.7795274f;
				break;
			default:
				throw new Exception("不支持的单位:" + p0);
			}
		}
	}

	private void z0eek(z0ZzZzpdh[] p0)
	{
		z0zrk.z0eek((short)p0.Length);
		int num = p0.Length;
		for (int i = 0; i < num; i++)
		{
			z0tek(p0[i].z0rek(), p0[i].z0tek());
		}
	}

	public void z0eek(z0ZzZzfsh p0)
	{
		z0zek();
		z0vrk = p0;
	}

	public void z0eek(string p0, z0ZzZzsdh p1, z0ZzZztfh p2, float p3, float p4, z0ZzZzlsh p5)
	{
		z0eek(p0, p1, p2, new z0ZzZzbdh(p3, p4, 0f, 0f), p5);
	}

	public void z0mek()
	{
		z0zrk.z0eek((z0ZzZzqdh)14);
		z0ZzZzjdh z0ZzZzjdh2 = z0drk;
		z0zrk.z0eek(z0ZzZzjdh2.z0krk);
		z0zrk.z0eek(z0ZzZzjdh2.z0vek);
		z0zrk.z0eek(z0ZzZzjdh2.z0zek);
		z0zrk.z0eek(z0ZzZzjdh2.z0lrk);
		z0zrk.z0eek(z0frk * (1f - z0ZzZzjdh2.z0krk) * z0ork + z0ZzZzjdh2.z0cek * z0xrk * z0ork);
		z0zrk.z0eek(z0erk * (1f - z0ZzZzjdh2.z0lrk) * z0ork + z0ZzZzjdh2.z0xek * z0xrk * z0ork);
	}

	public void z0rek(float p0, float p1)
	{
		z0frk = p0;
		z0erk = p1;
	}

	public void z0rek(z0ZzZzudh p0, float p1, float p2, float p3, float p4)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("pen");
		}
		short p5 = z0ktk.z0qh(p0);
		z0zrk.z0eek((z0ZzZzqdh)11);
		z0zrk.z0eek(p5);
		z0rek(p1, p2, p3, p4);
	}

	public z0ZzZzxdh z0eek(string p0, z0ZzZzsdh p1, z0ZzZzxdh p2, z0ZzZzlsh p3)
	{
		return z0eek(p0, p1, (int)p2.z0rek(), p3);
	}

	public z0ZzZzbdh z0nek_jiejie20260327142557()
	{
		z0zek();
		return z0irk;
	}

	private void z0tek(float p0, float p1)
	{
		if (z0ork == 1f)
		{
			z0zrk.z0eek((int)Math.Round(z0frk + p0 * z0xrk), (int)Math.Round(z0erk + p1 * z0xrk));
		}
		else
		{
			z0zrk.z0eek((int)Math.Round(z0ork * (z0frk + p0 * z0xrk)), (int)Math.Round(z0ork * (z0erk + p1 * z0xrk)));
		}
	}

	public void z0bek()
	{
		z0nrk = true;
	}

	public z0ZzZzjdh z0vek()
	{
		z0zek();
		return z0drk;
	}

	public void z0eek(Color p0, float p1, float p2, float p3, float p4)
	{
		z0zrk.z0eek((z0ZzZzqdh)45);
		z0zrk.z0eek(z0ZzZzifh.z0eek(p0));
		z0eek(p1, p2, p3, p4);
	}

	private void z0eek(z0ZzZzsdh p0)
	{
		if (p0 == null || string.IsNullOrEmpty(p0.z0pek()))
		{
			short p1 = z0gtk.z0qh(z0ZzZzimk.z0oek);
			z0htk = null;
			z0zrk.z0eek((z0ZzZzqdh)1);
			z0zrk.z0eek(p1);
		}
		if (z0htk == null || !z0htk.z0eek(p0))
		{
			short p2 = z0gtk.z0qh(p0);
			z0zrk.z0eek((z0ZzZzqdh)1);
			z0zrk.z0eek(p2);
			z0htk = p0;
		}
	}

	public void z0eek(z0ZzZzbfh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("gstate");
		}
		z0zek();
		p0.z0eek(this);
	}

	public z0ZzZzxdh z0eek(string p0, z0ZzZzsdh p1)
	{
		return z0ZzZzlcj.z0rek(z0dtk, p0, p1, 100000f, null);
	}

	public override string ToString()
	{
		throw new Exception("不支持 ");
	}

	public void z0eek(z0ZzZzedh p0, int p1, int p2)
	{
		z0eek(p0, (float)p1, (float)p2);
	}

	public void z0eek(z0ZzZztfh p0, float p1, float p2, float p3, float p4, float p5, float p6)
	{
		z0zrk.z0eek((z0ZzZzqdh)34);
		short p7 = z0brk.z0qh(p0);
		z0zrk.z0eek(p7);
		z0rek(p1, p2, p3, p4);
		z0zrk.z0eek(z0eek(p5, p3, p4));
		z0zrk.z0eek(z0eek(p5 + p6, p3, p4));
	}

	private void z0eek(z0ZzZztfh p0)
	{
		if (p0 == null)
		{
			z0yrk = null;
			short p1 = z0brk.z0eek_jiejie20260327142557(Color.Black);
			z0zrk.z0eek((z0ZzZzqdh)2);
			z0zrk.z0eek(p1);
		}
		else if (z0yrk == null || !z0yrk.z0jd(p0))
		{
			short p2 = z0brk.z0qh(p0);
			z0yrk = p0;
			z0zrk.z0eek((z0ZzZzqdh)2);
			z0zrk.z0eek(p2);
		}
	}

	public void z0eek(z0ZzZzedh p0, z0ZzZzndh p1)
	{
		z0eek(p0, (float)p1.z0yek(), (float)p1.z0uek());
	}

	public void z0eek(z0ZzZzjdh p0)
	{
		z0zek();
		if (p0 == null)
		{
			if (!z0drk.z0iek())
			{
				z0drk.z0tek_jiejie20260327142557();
				z0cek();
			}
		}
		else if (!z0drk.z0eek(p0))
		{
			z0drk = p0;
			z0cek();
		}
	}

	public void z0yek(float p0, float p1)
	{
		if (p0 != 1f || p1 != 1f)
		{
			z0drk.z0rek(p0, p1);
			if (p0 != 1f || p1 != 1f)
			{
				z0mek();
			}
			else
			{
				z0cek();
			}
		}
	}

	public void z0eek(z0ZzZztfh p0, z0ZzZzbdh p1)
	{
		z0eek(p0, p1.z0tek(), p1.z0yek(), p1.z0uek(), p1.z0iek());
	}

	public byte[] z0eek(z0ZzZzydh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("strResult");
		}
		p0.z0eek((z0ZzZzqdh)13);
		p0.z0eek(20221031);
		if (z0rrk != null)
		{
			z0rrk.z0rek(p0, this);
		}
		if (z0gtk != null)
		{
			z0gtk.z0rek(p0, this);
		}
		if (z0ktk != null)
		{
			z0ktk.z0eek = z0ZzZzrpk.z0eek(z0uek(), z0jrk(), GraphicsUnit.Pixel);
			z0ktk.z0rek(p0, this);
		}
		if (z0brk != null)
		{
			z0brk.z0rek(p0, this);
		}
		if (z0mrk != null)
		{
			z0mrk.z0rek(p0, this);
		}
		p0.z0eek((z0ZzZzqdh)32);
		byte[] array = new byte[p0.z0rek() + z0zrk.z0rek() + 1];
		Buffer.BlockCopy(p0.z0nek, 0, array, 0, p0.z0rek());
		Buffer.BlockCopy(z0zrk.z0nek, 0, array, p0.z0rek(), z0zrk.z0rek());
		array[array.Length - 1] = 0;
		return array;
	}

	public void z0eek(z0ZzZzudh p0, int p1, int p2, int p3, int p4)
	{
		z0eek(p0, p1, p2, p3, p4, 0f);
	}

	public void z0eek(z0ZzZztfh p0, z0ZzZzvdh p1)
	{
	}

	public z0ZzZzadh()
	{
		z0zrk = new z0ZzZzydh();
		if (z0ltk != null)
		{
			z0ark = z0ltk();
		}
	}

	public void z0eek(z0ZzZzedh p0, float p1, float p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("image");
		}
		byte[] array = p0.z0gd();
		if (array == null || array.Length == 0)
		{
			return;
		}
		if ((z0ark || z0ZzZzqbj.z0oik) && p0.z0uek() >= 0)
		{
			if (z0ork == 1f || p0.z0iek() == 0 || p0.z0yek() == 0)
			{
				z0zrk.z0eek((z0ZzZzqdh)38);
				z0zrk.z0eek((short)p0.z0uek());
				z0tek(p1, p2);
			}
			else
			{
				z0zrk.z0eek((z0ZzZzqdh)39);
				z0zrk.z0eek((short)p0.z0uek());
				z0tek(p1, p2);
				z0zrk.z0eek((int)(z0ork * (float)p0.z0iek()), (int)(z0ork * (float)p0.z0yek()));
			}
			return;
		}
		short p3 = z0mrk.z0qh(array);
		if (z0ork == 1f || p0.z0iek() == 0 || p0.z0yek() == 0)
		{
			z0zrk.z0eek((z0ZzZzqdh)21);
			z0zrk.z0eek(p3);
			z0tek(p1, p2);
			return;
		}
		z0zrk.z0eek((z0ZzZzqdh)22);
		z0zrk.z0eek(p3);
		if (z0ZzZzqbj.z0oik)
		{
			z0zrk.z0eek((int)(z0ork * (float)p0.z0iek()), (int)(z0ork * (float)p0.z0yek()));
			z0tek(p1, p2);
		}
		else
		{
			z0tek(p1, p2);
			z0zrk.z0eek((int)(z0ork * (float)p0.z0iek()), (int)(z0ork * (float)p0.z0yek()));
		}
	}

	public void z0rek(z0ZzZzudh p0, z0ZzZzpdh[] p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("pen");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("points");
		}
	}

	public void z0eek(bool p0)
	{
		z0zrk.z0eek((z0ZzZzqdh)41);
		z0zrk.z0eek(p0);
	}

	private void z0cek()
	{
		z0zrk.z0eek((z0ZzZzqdh)14);
		z0ZzZzjdh z0ZzZzjdh2 = z0drk;
		float p = z0ZzZzjdh2.z0cek * z0xrk * z0ork;
		float p2 = z0ZzZzjdh2.z0xek * z0xrk * z0ork;
		z0zrk.z0eek(z0ZzZzjdh2.z0krk);
		z0zrk.z0eek(z0ZzZzjdh2.z0vek);
		z0zrk.z0eek(z0ZzZzjdh2.z0zek);
		z0zrk.z0eek(z0ZzZzjdh2.z0lrk);
		z0zrk.z0eek(p);
		z0zrk.z0eek(p2);
	}

	public void z0eek(string p0, z0ZzZzsdh p1, z0ZzZztfh p2, z0ZzZzbdh p3, z0ZzZzlsh p4)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return;
		}
		z0eek(p2);
		z0eek(p1);
		if (p3.z0uek() == 0f && p3.z0iek() == 0f && p0.Length == 1)
		{
			z0zrk.z0eek((z0ZzZzqdh)7);
			z0zrk.z0eek(p0[0]);
			float num = p1.z0eek(z0jrk());
			z0tek(p3.z0oek(), p3.z0pek() + num * 0.26f);
			if (p1.z0uek())
			{
				float num2 = z0eek(p0, p1).z0rek();
				float num3 = p3.z0pek() + num / 2f + num * 0.26f;
				z0eek(new z0ZzZzudh(p2, 1f), p3.z0oek(), num3, p3.z0oek() + num2, num3);
			}
			return;
		}
		if (p0.Length == 1 && (p4 == null || (p4.z0pek() == StringAlignment.Near && p4.z0tek() == StringAlignment.Near)))
		{
			z0zrk.z0eek((z0ZzZzqdh)7);
			z0zrk.z0eek(p0[0]);
			float num4 = p1.z0eek(this);
			z0tek(p3.z0oek(), p3.z0pek() + num4 * 1f);
			if (p1.z0uek())
			{
				float num5 = z0eek(p0, p1).z0rek();
				float num6 = p3.z0pek() + num4 / 2f + num4 * 0.3f;
				z0eek(new z0ZzZzudh(p2, 1f), p3.z0oek(), num6, p3.z0oek() + num5, num6);
			}
			return;
		}
		string[] array;
		if (p0.Length == 2 && XTextCharElement.z0tek((int)p0[0]) && XTextCharElement.z0rek((int)p0[1]))
		{
			array = new string[1] { p0 };
		}
		else
		{
			array = z0ZzZzlcj.z0eek(z0jrk(), p0, p1.z0pek(), p1.z0yek(), p1.z0mek(), p3.z0uek(), p4, out var _, null);
			if (array == null || array.Length == 0)
			{
				return;
			}
		}
		int num7 = array.Length;
		float num8 = p1.z0eek(this);
		float p6 = p3.z0pek();
		if (p3.z0iek() > 0f)
		{
			p3.z0tek(0f, num8 * 0.74f);
		}
		else
		{
			p3.z0tek(0f, num8 * 0.26f);
		}
		float num9 = p3.z0pek();
		if (p3.z0iek() > 0f)
		{
			if (p4.z0tek() == StringAlignment.Center)
			{
				num9 = p3.z0pek() + (p3.z0iek() - num8 * (float)num7) / 2f;
			}
			else if (p4.z0tek() == StringAlignment.Far)
			{
				num9 = p3.z0nek() - num8 * (float)num7;
			}
		}
		bool flag = false;
		float num10 = p3.z0uek();
		float num11 = 0f;
		if (num10 > 0f)
		{
			for (int i = 0; i < num7; i++)
			{
				string p7 = array[i];
				float num12 = z0ZzZzlcj.z0rek(z0dtk, p7, p1).z0rek();
				if (num12 > num11)
				{
					num11 = num12;
				}
			}
			if (p3.z0iek() > 0f && (num11 > num10 || num8 * (float)num7 > p3.z0iek()))
			{
				flag = true;
			}
		}
		if (flag)
		{
			z0ZzZzbdh p8 = new z0ZzZzbdh(p3.z0oek(), p6, p3.z0uek(), p3.z0iek());
			z0rek(p8);
		}
		for (int j = 0; j < num7; j++)
		{
			string p9 = array[j];
			float num13 = p3.z0oek();
			float num14 = 0f;
			num14 = ((num7 != 1 || !(num11 > 0f)) ? z0eek(p9, p1).z0rek() : num11);
			if (num10 > 0f)
			{
				if (p4.z0pek() == StringAlignment.Center)
				{
					num13 = p3.z0oek() + (num10 - num14) / 2f;
				}
				else if (p4.z0pek() == StringAlignment.Far)
				{
					num13 = p3.z0mek() - num14;
				}
			}
			z0zrk.z0eek((z0ZzZzqdh)6);
			z0zrk.z0eek(p9);
			z0tek(num13, num9);
			if (num10 > 0f)
			{
				z0zrk.z0eek((short)(num10 * z0xrk * z0ork));
			}
			else
			{
				z0zrk.z0eek((short)10000);
			}
			if (p1.z0uek())
			{
				float num15 = num9 - num8 * 0.24f;
				z0eek(new z0ZzZzudh(p2, 1f), num13, num15, num13 + num14, num15);
			}
			num9 += num8;
		}
		if (flag)
		{
			z0eek();
		}
	}

	public SmoothingMode z0xek()
	{
		z0zek();
		return z0crk;
	}

	protected void z0zek()
	{
		if (z0grk)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public static z0ZzZzadh z0eek(z0ZzZzedh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("image");
		}
		p0.z0rek();
		z0ZzZzadh obj = new z0ZzZzadh();
		obj.z0ftk = p0;
		obj.z0eek(z0ZzZzyfh.z0iek, 0f, 0f, p0.z0iek(), p0.z0yek(), 0f);
		return obj;
	}

	public z0ZzZzfsh z0lrk()
	{
		z0zek();
		return z0vrk;
	}

	public void z0krk()
	{
		z0eek((z0ZzZzjdh)null);
	}

	public void z0eek(z0ZzZzudh p0, z0ZzZznfh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("pen");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("path");
		}
		z0zrk.z0eek((z0ZzZzqdh)36);
		short p2 = z0ktk.z0qh(p0);
		z0zrk.z0eek(p2);
		z0zrk.z0eek(z0ork * z0xrk);
		z0zrk.z0eek(z0frk * z0ork);
		z0zrk.z0eek(z0erk * z0ork);
		z0zrk.z0eek(p1.z0yek());
	}

	public void z0rek(z0ZzZztfh p0, z0ZzZzbdh p1)
	{
		z0eek(p0, p1.z0tek(), p1.z0yek(), p1.z0uek(), p1.z0iek(), 0f);
	}

	public void z0eek(InterpolationMode p0)
	{
		z0zek();
		z0urk = p0;
	}

	public static float z0eek(float p0, float p1, float p2)
	{
		if (p1 == p2 || p0 % 90f == 0f)
		{
			return p0 * z0qrk;
		}
		p0 *= z0qrk;
		double num = Math.Tan(p0);
		double num2 = Math.Atan(num * (double)p1 / (double)p2) - Math.Atan(num);
		return (float)((double)p0 + num2);
	}

	public void z0eek(z0ZzZzedh p0, z0ZzZzbdh p1, z0ZzZzbdh p2, GraphicsUnit p3)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("image");
		}
		p1.z0uek();
		_ = 0f;
		byte[] array = p0.z0gd();
		if (array != null && array.Length != 0)
		{
			short p4 = z0mrk.z0qh(array);
			z0zrk.z0eek((z0ZzZzqdh)15);
			z0zrk.z0eek(p4);
			z0zrk.z0eek((short)p2.z0oek());
			z0zrk.z0eek((short)p2.z0pek());
			z0zrk.z0eek((short)p2.z0uek());
			z0zrk.z0eek((short)p2.z0iek());
			z0eek(p1);
		}
	}

	private void z0rek(float p0, float p1, float p2, float p3)
	{
		if (z0ork == 1f)
		{
			z0zrk.z0eek((int)Math.Round(z0frk + p0 * z0xrk), (int)Math.Round(z0erk + p1 * z0xrk), (int)(p2 * z0xrk), (int)(p3 * z0xrk));
		}
		else
		{
			z0zrk.z0eek((int)Math.Round(z0ork * (z0frk + p0 * z0xrk)), (int)Math.Round(z0ork * (z0erk + p1 * z0xrk)), (int)(z0ork * p2 * z0xrk), (int)(z0ork * p3 * z0xrk));
		}
	}

	public GraphicsUnit z0jrk()
	{
		return z0dtk;
	}

	private int z0tek(float p0, float p1, float p2, float p3)
	{
		int result = z0zrk.z0rek() + 8;
		if (z0ork == 1f)
		{
			z0zrk.z0eek((int)(z0frk + p0 * z0xrk), (int)(z0erk + p1 * z0xrk), (int)(p2 * z0xrk), (int)(p3 * z0xrk));
			return result;
		}
		z0zrk.z0eek((int)(z0ork * (z0frk + p0 * z0xrk)), (int)(z0ork * (z0erk + p1 * z0xrk)), (int)(z0ork * p2 * z0xrk), (int)(z0ork * p3 * z0xrk));
		return result;
	}
}
