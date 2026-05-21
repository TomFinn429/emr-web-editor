using System;
using System.Text;

namespace zzz;

public sealed class z0ZzZznfh : IDisposable
{
	private enum z0pxk
	{
		z0eek,
		z0rek,
		z0tek_jiejie20260327142557,
		z0yek,
		z0uek,
		z0iek,
		z0oek,
		z0pek,
		z0mek,
		z0nek,
		z0bek,
		z0vek,
		z0cek,
		z0xek
	}

	private float z0oek = -3.4028235E+38f;

	private float z0pek = -3.4028235E+38f;

	public static bool z0mek;

	private bool z0nek = true;

	private float z0bek = -3.4028235E+38f;

	public static bool z0vek;

	private float z0cek = -3.4028235E+38f;

	private float z0xek = -3.4028235E+38f;

	private float z0zek = -3.4028235E+38f;

	private StringBuilder z0lrk;

	public void z0eek(int p0, int p1, int p2, int p3, float p4, float p5)
	{
		z0eek((float)p0, (float)p1, (float)p2, (float)p3, p4, p5);
	}

	public void z0eek(z0ZzZzbdh p0, float p1, float p2)
	{
		z0eek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek(), p1, p2);
	}

	private void z0eek(float p0, float p1, float p2, float p3)
	{
		z0eek(p0, p1);
		z0eek(p0 + p2, p1 + p3);
		if (z0vek)
		{
			z0lrk.Append(p0);
			z0lrk.Append(' ');
			z0lrk.Append(p1);
			z0lrk.Append(' ');
			z0lrk.Append(p2);
			z0lrk.Append(' ');
			z0lrk.Append(p3);
		}
		else
		{
			z0lrk.Append(p0);
			z0lrk.Append(',');
			z0lrk.Append(p1);
			z0lrk.Append(',');
			z0lrk.Append(p2);
			z0lrk.Append(',');
			z0lrk.Append(p3);
		}
	}

	public void z0eek(z0ZzZzjdh p0)
	{
	}

	public void z0rek(int p0, int p1, int p2, int p3, float p4, float p5)
	{
		z0rek((float)p0, (float)p1, (float)p2, (float)p3, p4, p5);
	}

	public void z0eek(z0ZzZzpdh[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("points");
		}
		if (p0.Length == 1)
		{
			return;
		}
		StringBuilder stringBuilder = z0lrk;
		if (z0mek)
		{
			stringBuilder.Append(" M " + p0[0].z0rek() + "," + p0[0].z0tek());
			for (int i = 1; i < p0.Length; i++)
			{
				float p1 = p0[i].z0rek();
				float p2 = p0[i].z0tek();
				z0eek(p1, p2);
				stringBuilder.Append(" L " + p1 + "," + p2);
			}
			stringBuilder.Append(" L " + p0[0].z0rek() + "," + p0[0].z0tek());
		}
		else if (z0vek)
		{
			stringBuilder.Append(" M " + p0[0].z0rek() + " " + p0[0].z0tek());
			for (int j = 1; j < p0.Length; j++)
			{
				float p3 = p0[j].z0rek();
				float p4 = p0[j].z0tek();
				z0eek(p3, p4);
				stringBuilder.Append(" L " + p3 + " " + p4);
			}
			stringBuilder.Append(" L " + p0[0].z0rek() + " " + p0[0].z0tek());
		}
		else
		{
			z0eek(z0pxk.z0vek);
			stringBuilder.Append(',');
			z0rek(p0);
		}
	}

	private void z0eek(float p0, float p1)
	{
		if (z0nek)
		{
			z0nek = false;
			z0pek = p0;
			z0cek = p1;
			z0oek = p0;
			z0zek = p1;
			return;
		}
		if (z0pek > p0)
		{
			z0pek = p0;
		}
		if (z0oek < p0)
		{
			z0oek = p0;
		}
		if (z0cek > p1)
		{
			z0cek = p1;
		}
		if (z0zek < p1)
		{
			z0zek = p1;
		}
	}

	public void Dispose()
	{
	}

	public z0ZzZzbdh z0eek()
	{
		if (z0nek)
		{
			return z0ZzZzbdh.z0xek;
		}
		return new z0ZzZzbdh(z0pek, z0cek, z0oek - z0pek, z0zek - z0cek);
	}

	public void z0rek()
	{
	}

	public void z0eek(z0ZzZzndh p0)
	{
		StringBuilder stringBuilder = z0lrk;
		if (z0mek)
		{
			stringBuilder.Append("M " + p0.z0pek() + "," + p0.z0mek() + " h " + p0.z0iek() + " v " + p0.z0oek() + " h -" + p0.z0iek() + " v -" + p0.z0oek() + " L " + p0.z0pek() + "," + p0.z0mek());
			z0eek(p0.z0pek(), p0.z0mek());
			z0eek(p0.z0nek(), p0.z0bek());
		}
		else if (z0vek)
		{
			stringBuilder.Append(" M ").Append(p0.z0pek()).Append(' ')
				.Append(p0.z0mek())
				.Append(" L ")
				.Append(p0.z0nek())
				.Append(' ')
				.Append(p0.z0mek())
				.Append(" L ")
				.Append(p0.z0nek())
				.Append(' ')
				.Append(p0.z0bek())
				.Append(" L ")
				.Append(p0.z0pek())
				.Append(' ')
				.Append(p0.z0bek())
				.Append(" L ")
				.Append(p0.z0pek())
				.Append(' ')
				.Append(p0.z0mek());
			z0eek(p0.z0pek(), p0.z0mek());
			z0eek(p0.z0nek(), p0.z0bek());
		}
		else
		{
			z0eek(z0pxk.z0pek);
			z0lrk.Append(',');
			z0rek(p0);
		}
	}

	private void z0rek(float p0, float p1)
	{
		if (Math.Abs(p0 - z0bek) > 2f || Math.Abs(p1 - z0xek) > 2f)
		{
			if (z0vek)
			{
				z0lrk.Append(" M " + p0 + " " + p1);
			}
			else
			{
				z0lrk.Append(" M " + p0 + "," + p1);
			}
			z0bek = p0;
			z0xek = p1;
		}
	}

	private static float z0eek(float p0, float p1, float p2)
	{
		double num = (double)p2 * Math.Cos((double)p0 * Math.PI / 180.0);
		float num2 = (float)(Math.Atan2((double)p1 * Math.Sin((double)p0 * Math.PI / 180.0), num) * 180.0 / Math.PI);
		if (num2 < 0f)
		{
			return num2 + 360f;
		}
		return num2;
	}

	public void z0eek(float p0, float p1, float p2, float p3, float p4, float p5)
	{
		z0eek(p0, p1);
		z0eek(p0 + p2, p1 + p3);
		if (z0mek)
		{
			if (p5 % 360f == 0f)
			{
				z0rek(p0, p1, p2, p3);
				return;
			}
			object[] array = z0rek(z0bek, z0xek, p0, p1, p2, p3, p4, p5);
			if (array != null)
			{
				z0rek((float)array[0], (float)array[1]);
				z0lrk.Append(array[2]);
				z0bek = (float)array[3];
				z0xek = (float)array[4];
			}
		}
		else
		{
			z0eek(z0pxk.z0eek);
			z0lrk.Append(',');
			z0eek(p0, p1, p2, p3);
			z0lrk.Append(',');
			z0lrk.Append(z0ZzZzadh.z0eek(p4, p2, p3));
			z0lrk.Append(',');
			z0lrk.Append(z0ZzZzadh.z0eek(p4 + p5, p2, p3));
		}
	}

	public z0ZzZznfh()
	{
		z0lrk = new StringBuilder();
		if (!z0mek)
		{
			z0lrk.Append("[null");
		}
	}

	public string z0tek()
	{
		if (z0lrk.Length > 0)
		{
			return "S 0 0 " + z0lrk.ToString();
		}
		return string.Empty;
	}

	public bool z0tek(float p0, float p1)
	{
		return false;
	}

	private void z0rek(z0ZzZzpdh[] p0)
	{
		z0lrk.Append('[');
		for (int i = 0; i < p0.Length; i++)
		{
			if (i > 0)
			{
				z0lrk.Append(',');
			}
			z0ZzZzpdh z0ZzZzpdh2 = p0[i];
			z0eek(z0ZzZzpdh2.z0rek(), z0ZzZzpdh2.z0tek());
			z0lrk.Append(z0ZzZzpdh2.z0rek().ToString());
			z0lrk.Append(',');
			z0lrk.Append(z0ZzZzpdh2.z0tek().ToString());
		}
		z0lrk.Append(']');
	}

	public z0ZzZznfh(z0ZzZzpdh[] p0, byte[] p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("ps");
		}
		if (p1 == null || p1.Length == 0)
		{
			throw new ArgumentNullException("types");
		}
		if (p0.Length != p1.Length)
		{
			throw new ArgumentException("2个数值的长度不一致");
		}
		z0lrk = new StringBuilder();
		if (z0mek)
		{
			for (int i = 1; i < p0.Length; i++)
			{
				float p2 = p0[i].z0rek();
				float p3 = p0[i].z0tek();
				z0eek(p2, p3);
				z0ZzZzhdh z0ZzZzhdh2 = (z0ZzZzhdh)p1[i];
				if ((z0ZzZzhdh2 & (z0ZzZzhdh)1) == (z0ZzZzhdh)1)
				{
					if (z0lrk.Length == 0)
					{
						z0lrk.Append("M " + p0[i - 1].z0rek() + "," + p0[i - 1].z0tek());
					}
					z0lrk.Append(" L " + p2 + "," + p3);
					if ((z0ZzZzhdh2 & (z0ZzZzhdh)6) == (z0ZzZzhdh)6)
					{
						z0lrk.Append(" Z");
					}
				}
			}
			return;
		}
		if (z0vek)
		{
			for (int j = 1; j < p0.Length; j++)
			{
				float p4 = p0[j].z0rek();
				float p5 = p0[j].z0tek();
				z0eek(p4, p5);
				z0ZzZzhdh z0ZzZzhdh3 = (z0ZzZzhdh)p1[j];
				if ((z0ZzZzhdh3 & (z0ZzZzhdh)1) == (z0ZzZzhdh)1)
				{
					if (z0lrk.Length == 0)
					{
						z0lrk.Append("M " + p0[j - 1].z0rek() + " " + p0[j - 1].z0tek());
					}
					z0lrk.Append(" L " + p4 + " " + p5);
					if ((z0ZzZzhdh3 & (z0ZzZzhdh)6) == (z0ZzZzhdh)6)
					{
						z0lrk.Append(" C");
					}
				}
			}
			return;
		}
		z0lrk.Append("[null");
		for (int k = 0; k < p0.Length; k++)
		{
			float num = p0[k].z0rek();
			float num2 = p0[k].z0tek();
			z0ZzZzhdh z0ZzZzhdh4 = (z0ZzZzhdh)p1[k];
			if ((z0ZzZzhdh4 & (z0ZzZzhdh)1) != (z0ZzZzhdh)1)
			{
				continue;
			}
			if (k > 0)
			{
				z0tek(p0[k - 1].z0rek(), p0[k - 1].z0tek(), num, num2);
			}
			if ((z0ZzZzhdh4 & (z0ZzZzhdh)6) == (z0ZzZzhdh)6)
			{
				if (z0mek)
				{
					z0lrk.Append(" Z");
				}
				else
				{
					z0tek(num, num2, p0[0].z0rek(), p0[0].z0tek());
				}
			}
		}
	}

	private void z0eek(z0pxk p0)
	{
		z0lrk.Append(',');
		StringBuilder stringBuilder = z0lrk;
		int num = (int)p0;
		stringBuilder.Append(num.ToString());
	}

	public void z0tek(z0ZzZzpdh[] p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("points");
		}
		if (p0.Length == 0)
		{
			throw new ArgumentException(null, "points");
		}
		if (z0mek || z0vek)
		{
			z0rek(p0[0].z0rek(), p0[0].z0tek());
			for (int i = 1; i < p0.Length; i++)
			{
				float p1 = p0[i].z0rek();
				float p2 = p0[i].z0tek();
				z0eek(p1, p2);
				if (z0mek)
				{
					z0lrk.Append(" L " + p1 + "," + p2);
				}
				else
				{
					z0lrk.Append(" L " + p1 + " " + p2);
				}
			}
			z0bek = p0[p0.Length - 1].z0rek();
			z0xek = p0[p0.Length - 1].z0tek();
		}
		else
		{
			z0eek(z0pxk.z0iek);
			z0lrk.Append(',');
			z0rek(p0);
		}
	}

	public void z0rek(float p0, float p1, float p2, float p3, float p4, float p5)
	{
		z0eek(p0, p1);
		z0eek(p0 + p2, p1 + p3);
		StringBuilder stringBuilder = z0lrk;
		if (z0mek || z0vek)
		{
			if (p5 % 360f == 0f)
			{
				z0rek(p0, p1, p2, p3);
				return;
			}
			float num = p2 / 2f;
			float num2 = p3 / 2f;
			float num3 = p0 + num;
			float num4 = p1 + num2;
			float num5 = 360f - p4;
			float p6 = (float)((double)num3 + (double)num * Math.Cos((double)num5 * Math.PI / 180.0));
			float p7 = (float)((double)num4 + (double)num2 * Math.Sin((double)num5 * Math.PI / 180.0));
			float num6 = 0f - (p4 + p5);
			float num7 = (float)((double)num3 + (double)num * Math.Cos((double)num6 * Math.PI / 180.0));
			float num8 = (float)((double)num4 + (double)num2 * Math.Sin((double)num6 * Math.PI / 180.0));
			z0rek(num3, num4);
			stringBuilder.Append(" L " + p6 + " " + p7);
			z0rek(p6, p7);
			stringBuilder.Append(" A " + num + " " + num2 + " 0 ");
			if (z0mek)
			{
				if (Math.Abs(p5) > 180f)
				{
					stringBuilder.Append(" 1 ");
				}
				else
				{
					stringBuilder.Append(" 0 ");
				}
				stringBuilder.Append(" 0 " + num7 + " " + num8);
				stringBuilder.Append(" L " + num3 + " " + num4);
				stringBuilder.Append(" Z ");
			}
			else
			{
				int num9 = ((!(p5 % 360f <= 180f)) ? 1 : 0);
				stringBuilder.Append(" 0 ");
				stringBuilder.Append(num9);
				stringBuilder.Append(" 1 ");
				stringBuilder.Append(num7 + " " + num8);
				stringBuilder.Append(" L " + num3 + " " + num4);
				stringBuilder.Append(" C ");
			}
			z0bek = num3;
			z0xek = num4;
		}
		else
		{
			z0eek(z0pxk.z0oek);
			stringBuilder.Append(',');
			z0eek(p0, p1, p2, p3);
			stringBuilder.Append(',');
			stringBuilder.Append(z0ZzZzadh.z0eek(p4, p2, p3));
			stringBuilder.Append(',');
			stringBuilder.Append(z0ZzZzadh.z0eek(p4 + p5, p2, p3));
		}
	}

	private void z0rek(z0ZzZzndh p0)
	{
		z0eek(p0.z0pek(), p0.z0mek());
		z0eek(p0.z0nek(), p0.z0bek());
		if (z0vek)
		{
			z0lrk.Append(p0.z0pek());
			z0lrk.Append(' ');
			z0lrk.Append(p0.z0mek());
			z0lrk.Append(' ');
			z0lrk.Append(p0.z0iek());
			z0lrk.Append(' ');
			z0lrk.Append(p0.z0oek());
		}
		else
		{
			z0lrk.Append(p0.z0pek());
			z0lrk.Append(',');
			z0lrk.Append(p0.z0mek());
			z0lrk.Append(',');
			z0lrk.Append(p0.z0iek());
			z0lrk.Append(',');
			z0lrk.Append(p0.z0oek());
		}
	}

	public void z0eek(float p0, float p1, float p2, float p3, float p4, float p5, float p6, float p7)
	{
		z0eek(p0, p1);
		z0eek(p2, p3);
		z0eek(p4, p5);
		z0eek(p6, p7);
		if (z0mek)
		{
			z0rek(p0, p1);
			z0lrk.Append(" C " + p2 + "," + p3 + "," + p4 + "," + p5 + "," + p6 + "," + p7);
			z0bek = p6;
			z0xek = p7;
		}
		else
		{
			z0eek(z0pxk.z0rek);
			z0lrk.Append(',');
			z0lrk.Append(p0.ToString());
			z0lrk.Append(',');
			z0lrk.Append(p1.ToString());
			z0lrk.Append(',');
			z0lrk.Append(p2.ToString());
			z0lrk.Append(',');
			z0lrk.Append(p3.ToString());
			z0lrk.Append(',');
			z0lrk.Append(p4.ToString());
			z0lrk.Append(',');
			z0lrk.Append(p5.ToString());
			z0lrk.Append(',');
			z0lrk.Append(p6.ToString());
			z0lrk.Append(',');
			z0lrk.Append(p7.ToString());
		}
	}

	public string z0yek()
	{
		return z0lrk.ToString() + "]";
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		if (z0mek)
		{
			z0lrk.Append("M " + p0.z0oek() + "," + p0.z0pek() + " h " + p0.z0uek() + " v " + p0.z0iek() + " h -" + p0.z0uek() + " v -" + p0.z0iek() + " L " + p0.z0oek() + "," + p0.z0pek());
			z0eek(p0.z0oek(), p0.z0pek());
			z0eek(p0.z0mek(), p0.z0nek());
		}
		else if (z0vek)
		{
			z0lrk.Append(" M ").Append(p0.z0oek()).Append(' ')
				.Append(p0.z0pek())
				.Append(" L ")
				.Append(p0.z0mek())
				.Append(' ')
				.Append(p0.z0pek())
				.Append(" L ")
				.Append(p0.z0mek())
				.Append(' ')
				.Append(p0.z0nek())
				.Append(" L ")
				.Append(p0.z0oek())
				.Append(' ')
				.Append(p0.z0nek())
				.Append(" L ")
				.Append(p0.z0oek())
				.Append(' ')
				.Append(p0.z0pek());
			z0eek(p0.z0oek(), p0.z0pek());
			z0eek(p0.z0mek(), p0.z0nek());
		}
		else
		{
			z0eek(z0pxk.z0pek);
			z0lrk.Append(',');
			z0tek(p0);
		}
	}

	public void z0rek(z0ZzZzbdh p0)
	{
		z0rek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek());
	}

	public void z0uek()
	{
		if (z0mek)
		{
			z0lrk.Append(" Z");
		}
	}

	public void z0rek(float p0, float p1, float p2, float p3)
	{
		if (!z0mek)
		{
			z0eek(z0pxk.z0yek);
			z0lrk.Append(',');
			z0eek(p0, p1, p2, p3);
		}
	}

	public void z0eek(z0ZzZzndh p0, float p1, float p2)
	{
		z0eek((float)p0.z0pek(), (float)p0.z0mek(), (float)p0.z0iek(), (float)p0.z0oek(), p1, p2);
	}

	public string z0iek()
	{
		return z0lrk.ToString();
	}

	public static object[] z0rek(float p0, float p1, float p2, float p3, float p4, float p5, float p6, float p7)
	{
		if (p7 % 360f == 0f)
		{
			return null;
		}
		float num = z0eek(p6, p4, p5);
		float num2 = z0eek(p6 + p7, p4, p5);
		p6 = num;
		p7 = num2 - num;
		float num3 = p4 / 2f;
		float num4 = p5 / 2f;
		float num5 = p2 + num3;
		float num6 = p3 + num4;
		float num7 = (float)((double)num5 + (double)num3 * Math.Cos((double)p6 * Math.PI / 180.0));
		float num8 = (float)((double)num6 + (double)num4 * Math.Sin((double)p6 * Math.PI / 180.0));
		float num9 = p6 + p7;
		float num10 = (float)((double)num5 + (double)num3 * Math.Cos((double)num9 * Math.PI / 180.0));
		float num11 = (float)((double)num6 + (double)num4 * Math.Sin((double)num9 * Math.PI / 180.0));
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(" A " + num3 + " " + num4 + " 0 ");
		if (Math.Abs(p7) > 180f)
		{
			stringBuilder.Append(" 1 ");
		}
		else
		{
			stringBuilder.Append(" 0 ");
		}
		if (p7 < 0f)
		{
			stringBuilder.Append(" 0 ");
		}
		else
		{
			stringBuilder.Append(" 1 ");
		}
		stringBuilder.Append(num10 + " " + num11);
		return new object[5]
		{
			num7,
			num8,
			stringBuilder.ToString(),
			num10,
			num11
		};
	}

	public override string ToString()
	{
		return z0lrk.ToString() + "]";
	}

	private void z0tek(z0ZzZzbdh p0)
	{
		z0eek(p0.z0oek(), p0.z0pek());
		z0eek(p0.z0mek(), p0.z0nek());
		if (z0vek)
		{
			z0lrk.Append(p0.z0oek());
			z0lrk.Append(' ');
			z0lrk.Append(p0.z0pek());
			z0lrk.Append(' ');
			z0lrk.Append(p0.z0uek());
			z0lrk.Append(' ');
			z0lrk.Append(p0.z0iek());
		}
		else
		{
			z0lrk.Append(p0.z0oek());
			z0lrk.Append(',');
			z0lrk.Append(p0.z0pek());
			z0lrk.Append(',');
			z0lrk.Append(p0.z0uek());
			z0lrk.Append(',');
			z0lrk.Append(p0.z0iek());
		}
	}

	public void z0tek(float p0, float p1, float p2, float p3)
	{
		z0eek(p0, p1);
		z0eek(p2, p3);
		if (z0mek)
		{
			z0rek(p0, p1);
			z0lrk.Append(" L " + p2 + "," + p3);
			z0bek = p2;
			z0xek = p3;
			return;
		}
		if (z0vek)
		{
			z0rek(p0, p1);
			z0lrk.Append(" L " + p2 + " " + p3);
			z0bek = p2;
			z0xek = p3;
			return;
		}
		z0eek(z0pxk.z0uek);
		z0lrk.Append(",");
		z0lrk.Append(p0.ToString());
		z0lrk.Append(",");
		z0lrk.Append(p1.ToString());
		z0lrk.Append(",");
		z0lrk.Append(p2.ToString());
		z0lrk.Append(",");
		z0lrk.Append(p3.ToString());
	}
}
