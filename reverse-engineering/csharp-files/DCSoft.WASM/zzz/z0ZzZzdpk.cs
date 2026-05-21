using System;
using System.Collections.Generic;
using DCSoft.Drawing;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public static class z0ZzZzdpk
{
	public static z0ZzZzudh z0eek(Color p0, float p1, DashStyle p2)
	{
		z0ZzZzudh obj = new z0ZzZzudh(p0, p1);
		obj.z0eek(p2);
		return obj;
	}

	public static z0ZzZzbdh[] z0eek(int p0, int p1, z0ZzZzbdh p2, z0ZzZzbdh p3)
	{
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh.z0tek(p2, p3);
		z0ZzZzpdh p4 = z0ZzZzbdh2.z0eek();
		z0ZzZzbdh2.z0eek(z0ZzZzbdh2.z0tek() - p2.z0tek());
		z0ZzZzbdh2.z0rek(z0ZzZzbdh2.z0yek() - p2.z0yek());
		z0ZzZzbdh z0ZzZzbdh3 = new z0ZzZzbdh(0f, 0f, p0, p1);
		z0ZzZzbdh z0ZzZzbdh4 = new z0ZzZzbdh((float)Math.Round(z0ZzZzbdh3.z0uek() * z0ZzZzbdh2.z0tek() / p2.z0uek(), 3), (float)Math.Round(z0ZzZzbdh3.z0iek() * z0ZzZzbdh2.z0yek() / p2.z0iek(), 3), (float)Math.Round(z0ZzZzbdh3.z0uek() * z0ZzZzbdh2.z0uek() / p2.z0uek(), 3), (float)Math.Round(z0ZzZzbdh3.z0iek() * z0ZzZzbdh2.z0iek() / p2.z0iek(), 3));
		z0ZzZzbdh2.z0eek(p4);
		if (z0ZzZzbdh4.z0oek() == 0f && z0ZzZzbdh4.z0pek() == 0f && z0ZzZzbdh4.z0uek() == (float)p0 && z0ZzZzbdh4.z0iek() == (float)p1)
		{
			return new z0ZzZzbdh[1] { z0ZzZzbdh2 };
		}
		return new z0ZzZzbdh[2] { z0ZzZzbdh2, z0ZzZzbdh4 };
	}

	public static Color z0eek(Color p0, float p1)
	{
		return new z0ZzZzypk(p0).z0eek(p1);
	}

	public static z0ZzZzpdh[] z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		z0ZzZzpdh[] array = new z0ZzZzpdh[5]
		{
			new z0ZzZzpdh(p1.z0oek(), p1.z0pek()),
			new z0ZzZzpdh(p1.z0mek(), p1.z0pek()),
			new z0ZzZzpdh(p1.z0mek(), p1.z0nek()),
			new z0ZzZzpdh(p1.z0oek(), p1.z0nek()),
			new z0ZzZzpdh(p1.z0oek(), p1.z0pek())
		};
		p0.z0eek(array);
		return array;
	}

	public static void z0eek(z0ZzZzjpk p0, TextUnderlineStyle p1, Color p2, float p3, float p4, float p5, float p6, float p7)
	{
		switch (p1)
		{
		case TextUnderlineStyle.Dash:
		{
			using z0ZzZzudh z0ZzZzudh7 = new z0ZzZzudh(p2);
			z0ZzZzudh7.z0eek(DashStyle.Dash);
			p0.z0eek(z0ZzZzudh7, p3, p4, p5, p6);
			break;
		}
		case TextUnderlineStyle.DashDot:
		{
			using z0ZzZzudh z0ZzZzudh6 = new z0ZzZzudh(p2);
			z0ZzZzudh6.z0eek(DashStyle.DashDot);
			p0.z0eek(z0ZzZzudh6, p3, p4, p5, p6);
			break;
		}
		case TextUnderlineStyle.DashDotDot:
		{
			using z0ZzZzudh z0ZzZzudh5 = new z0ZzZzudh(p2);
			z0ZzZzudh5.z0eek(DashStyle.DashDotDot);
			p0.z0eek(z0ZzZzudh5, p3, p4, p5, p6);
			break;
		}
		case TextUnderlineStyle.Dot:
		{
			using z0ZzZzudh z0ZzZzudh4 = new z0ZzZzudh(p2);
			z0ZzZzudh4.z0eek(DashStyle.Dot);
			p0.z0eek(z0ZzZzudh4, p3, p4, p5, p6);
			break;
		}
		case TextUnderlineStyle.Double:
		{
			using z0ZzZzudh p11 = new z0ZzZzudh(p2);
			p0.z0eek(p11, p3, p4, p5, p6);
			p0.z0eek(p11, p3, p4 + p7, p5, p6 + p7);
			break;
		}
		case TextUnderlineStyle.Single:
		{
			using z0ZzZzudh p10 = new z0ZzZzudh(p2);
			p0.z0eek(p10, p3, p4, p5, p6);
			break;
		}
		case TextUnderlineStyle.Thick:
		{
			using z0ZzZzudh z0ZzZzudh3 = new z0ZzZzudh(p2);
			z0ZzZzudh3.z0eek(z0ZzZzrpk.z0eek(2f, GraphicsUnit.Pixel, p0.z0vek()));
			p0.z0eek(z0ZzZzudh3, p3, p4, p5, p6);
			break;
		}
		case TextUnderlineStyle.Wavy:
		{
			List<z0ZzZzpdh> list3 = z0eek(p3, p4, p5, p6, p7);
			using z0ZzZzudh p9 = new z0ZzZzudh(p2);
			p0.z0eek(p9, list3.ToArray());
			break;
		}
		case TextUnderlineStyle.WavyDouble:
		{
			using z0ZzZzudh p8 = new z0ZzZzudh(p2);
			List<z0ZzZzpdh> list2 = z0eek(p3, p4, p5, p6, p7);
			p0.z0eek(p8, list2.ToArray());
			list2 = z0eek(p3, p4 + p7, p5, p6 + p7, p7);
			p0.z0eek(p8, list2.ToArray());
			break;
		}
		case TextUnderlineStyle.WavyHeavy:
		{
			List<z0ZzZzpdh> list = z0eek(p3, p4, p5, p6, p7);
			using z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(p2);
			z0ZzZzudh2.z0eek(z0ZzZzrpk.z0eek(2f, GraphicsUnit.Pixel, p0.z0vek()));
			p0.z0eek(z0ZzZzudh2, list.ToArray());
			break;
		}
		case TextUnderlineStyle.None:
			break;
		}
	}

	public static void z0eek(z0ZzZzjpk p0, z0ZzZzedh p1, z0ZzZzbdh p2, ContentAlignment p3)
	{
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzjmk.z0eek(p2, z0ZzZzrpk.z0eek(p1.z0iek(), GraphicsUnit.Pixel, p0.z0vek()), z0ZzZzrpk.z0eek(p1.z0yek(), GraphicsUnit.Pixel, p0.z0vek()), p3);
		InterpolationMode p4 = p0.z0nek_jiejie20260327142557();
		z0ZzZzfdh p5 = p0.z0tek();
		p0.z0eek(InterpolationMode.NearestNeighbor);
		p0.z0eek((z0ZzZzfdh)4);
		p0.z0eek(p1, (int)z0ZzZzbdh2.z0oek(), (int)z0ZzZzbdh2.z0pek());
		p0.z0eek(p4);
		p0.z0eek(p5);
	}

	public static z0ZzZzadh z0eek()
	{
		return new z0ZzZzadh();
	}

	public static void z0eek(z0ZzZzjpk p0, z0ZzZzedh p1, z0ZzZzbdh p2)
	{
		InterpolationMode p3 = p0.z0nek_jiejie20260327142557();
		z0ZzZzfdh p4 = p0.z0tek();
		p0.z0eek(InterpolationMode.NearestNeighbor);
		p0.z0eek((z0ZzZzfdh)4);
		p0.z0eek(p1, p2, new z0ZzZzbdh(0f, 0f, p1.z0iek(), p1.z0yek()), GraphicsUnit.Pixel);
		p0.z0eek(p3);
		p0.z0eek(p4);
	}

	private static List<z0ZzZzpdh> z0eek(float p0, float p1, float p2, float p3, float p4)
	{
		bool flag = false;
		List<z0ZzZzpdh> list = new List<z0ZzZzpdh>();
		if (p0 > p2)
		{
			float num = p2;
			p2 = p0;
			p0 = num;
		}
		if (p1 > p3)
		{
			float num2 = p3;
			p3 = p1;
			p1 = num2;
		}
		float num3 = Math.Abs(p4);
		if (p1 == p3)
		{
			if (Math.Abs(Math.IEEERemainder(p0, p4) / (double)p4) < 0.5)
			{
				flag = !flag;
			}
			for (float num4 = p0; num4 <= p2; num4 += num3)
			{
				flag = !flag;
				if (flag)
				{
					list.Add(new z0ZzZzpdh(num4, p1));
				}
				else
				{
					list.Add(new z0ZzZzpdh(num4, p1 + p4));
				}
			}
		}
		else if (p0 == p2)
		{
			for (float num5 = p1; num5 <= p3; num5 += num3)
			{
				flag = !flag;
				if (flag)
				{
					list.Add(new z0ZzZzpdh(p0, num5));
				}
				else
				{
					list.Add(new z0ZzZzpdh(p0 + p4, num5));
				}
			}
		}
		return list;
	}

	public static bool z0eek(z0ZzZzbdh p0, float p1, float p2, float p3, float p4)
	{
		if (p0.z0bek())
		{
			return true;
		}
		if (p1 == p3)
		{
			if (p1 < p0.z0oek() || p1 > p0.z0mek())
			{
				return false;
			}
			if (p2 > p4)
			{
				float num = p2;
				p4 = p2;
				p2 = num;
			}
			if (p2 > p0.z0nek() || p4 < p0.z0pek())
			{
				return false;
			}
		}
		else if (p2 == p4)
		{
			if (p2 < p0.z0pek() || p2 > p0.z0nek())
			{
				return false;
			}
			if (p1 > p3)
			{
				float num2 = p1;
				p1 = p3;
				p3 = num2;
			}
			if (p1 > p0.z0mek() || p3 < p0.z0oek())
			{
				return false;
			}
		}
		else
		{
			if (p1 > p3)
			{
				float num3 = p1;
				p1 = p3;
				p3 = num3;
			}
			if (p2 > p4)
			{
				float num4 = p2;
				p2 = p4;
				p4 = num4;
			}
			if (p1 < p0.z0mek() && p0.z0oek() < p3 && p2 < p0.z0nek())
			{
				p0.z0pek();
				return true;
			}
		}
		return true;
	}

	public static z0ZzZzbdh z0eek(z0ZzZzbdh p0, float p1, float p2, bool p3)
	{
		if (p0.z0uek() == 0f || p0.z0iek() == 0f || p1 == 0f || p2 == 0f)
		{
			return z0ZzZzbdh.z0xek;
		}
		if (p1 > p0.z0uek() || p2 > p0.z0iek())
		{
			if (p1 > p0.z0uek())
			{
				p2 = p0.z0iek() * p2 / p1;
				p1 = p0.z0uek();
			}
			if (p2 > p0.z0iek())
			{
				p1 = p0.z0uek() * p1 / p2;
				p2 = p0.z0iek();
			}
		}
		else if (p1 < p0.z0uek() && p2 < p0.z0iek() && p3)
		{
			if (p0.z0uek() / p0.z0iek() > p1 / p2)
			{
				p1 = p0.z0iek() * p1 / p2;
				p2 = p0.z0iek();
			}
			else
			{
				p2 = p0.z0uek() * p2 / p1;
				p1 = p0.z0uek();
			}
		}
		return new z0ZzZzbdh(p0.z0oek() + (p0.z0uek() - p1) / 2f, p0.z0pek() + (p0.z0iek() - p2) / 2f, p1, p2);
	}

	public static z0ZzZzbdh z0eek(z0ZzZzjpk p0, float p1, float p2, float p3, float p4)
	{
		GraphicsUnit graphicsUnit = p0.z0vek();
		double num = 96.0;
		double num2 = 96.0;
		switch (graphicsUnit)
		{
		case GraphicsUnit.Document:
			num = 300.0;
			num2 = 300.0;
			break;
		case GraphicsUnit.Inch:
			num = 1.0;
			num2 = 1.0;
			break;
		case GraphicsUnit.Millimeter:
			num = 25.4;
			num2 = 25.4;
			break;
		case GraphicsUnit.Point:
			num = 72.0;
			num2 = 72.0;
			break;
		}
		num /= 96.0;
		num2 /= 96.0;
		double num3 = Math.Ceiling((double)p1 / num) * num;
		double num4 = Math.Ceiling((double)p2 / num2) * num2;
		double num5 = Math.Ceiling((double)p3 / num) * num;
		double num6 = Math.Ceiling((double)p4 / num2) * num2;
		if (num3 > (double)p1)
		{
			num3 -= num;
			if (num5 < (double)p3)
			{
				num5 += num;
			}
			num5 += num;
		}
		if (num4 > (double)p2)
		{
			num4 = (double)p2 - num2;
			if (num6 < (double)p4)
			{
				num6 += num2;
			}
			num6 += num2;
		}
		return new z0ZzZzbdh((float)num3, (float)num4, (float)num5, (float)num6);
	}

	public static void z0eek(z0ZzZzjpk p0, z0ZzZzedh p1, int p2, int p3)
	{
		InterpolationMode p4 = p0.z0nek_jiejie20260327142557();
		z0ZzZzfdh p5 = p0.z0tek();
		p0.z0eek(InterpolationMode.NearestNeighbor);
		p0.z0eek((z0ZzZzfdh)4);
		p0.z0eek(p1, p2, p3);
		p0.z0eek(p4);
		p0.z0eek(p5);
	}

	public static bool z0eek(PageContentPartyStyle p0)
	{
		if (p0 != PageContentPartyStyle.Header && p0 != PageContentPartyStyle.Footer && p0 != PageContentPartyStyle.HeaderForFirstPage)
		{
			return p0 == PageContentPartyStyle.FooterForFirstPage;
		}
		return true;
	}

	public static void z0eek(z0ZzZzadh p0, string p1, z0ZzZzbdh p2)
	{
		if (p0 != null && p1 != null && p1.Length > 0)
		{
			z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
			p0.z0eek(p1, z0ZzZzimk.z0oek, z0ZzZzyfh.z0oek, p2, z0ZzZzlsh2);
		}
	}

	public static void z0eek(z0ZzZzlsh p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("format");
		}
		z0ZzZzksh z0ZzZzksh2 = p0.z0yek();
		z0ZzZzksh z0ZzZzksh3 = z0ZzZzksh2;
		z0ZzZzksh3 = ((!p1) ? (z0ZzZzksh2 | (z0ZzZzksh)4096) : (z0ZzZzksh2 & (z0ZzZzksh)(-4097)));
		if (z0ZzZzksh2 != z0ZzZzksh3)
		{
			p0.z0eek(z0ZzZzksh3);
		}
	}
}
