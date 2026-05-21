using System;
using System.Collections.Generic;
using DCSoft.Writer.Dom;
using DCSoft.Writer.MedicalExpression;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZznjh
{
	private z0ZzZzimk z0mek = new z0ZzZzimk();

	private DCMedicalExpressionStyle z0nek = DCMedicalExpressionStyle.FourValues;

	private int z0bek = -1;

	private XTextNewMedicalExpressionElement z0vek;

	private static z0ZzZzlsh z0cek;

	private static z0ZzZzlsh z0xek;

	private Color z0zek = Color.Black;

	private bool z0lrk;

	private MedicalExpressionValueList z0krk = new MedicalExpressionValueList();

	private z0ZzZzxdh z0eek(string p0, z0ZzZzjpk p1)
	{
		z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzxdh.z0yek;
		z0ZzZzxdh2 = ((p0 != null && p0.Length != 0) ? ((z0pek() != DCMedicalExpressionStyle.DeciduousTeech && z0pek() != DCMedicalExpressionStyle.PermanentTeethBitmap) ? z0eek(p1, p0, z0tek(), 100000, z0rek()) : z0eek(p1, p0, z0tek(), 100000, z0yek())) : new z0ZzZzxdh(z0ZzZzrpk.z0eek(10, GraphicsUnit.Pixel, p1.z0vek()), z0eek(p1, z0tek())));
		z0ZzZzxdh2.z0rek(z0eek(p1, z0tek()) + (float)z0ZzZzrpk.z0eek(4, GraphicsUnit.Pixel, p1.z0vek()));
		return z0ZzZzxdh2;
	}

	public z0ZzZzxdh z0eek(z0ZzZzjpk p0)
	{
		return z0eek(p0, z0ZzZzbdh.z0xek, p2: true);
	}

	public void z0eek(Color p0)
	{
		z0zek = p0;
	}

	private z0ZzZzxdh z0eek(z0ZzZzjpk p0, string p1, z0ZzZzimk p2, int p3, z0ZzZzlsh p4)
	{
		return z0ZzZzlcj.z0rek(p0.z0oek(), p1, p2, p3, p4);
	}

	public void z0eek(bool p0)
	{
		z0lrk = p0;
	}

	public int z0eek()
	{
		return z0bek;
	}

	private float z0eek(string p0, z0ZzZzjpk p1, bool p2 = false)
	{
		float num = 0f;
		List<string> obj = (p2 ? z0rek(p0, "A,B,C,D,E") : z0eek(p0));
		int num2 = 0;
		foreach (string item in obj)
		{
			num = ((num2 % 2 != 0) ? (num + z0rek(item, p1).z0rek()) : (num + z0eek(item, p1).z0rek()));
			num2++;
		}
		return num;
	}

	private z0ZzZzimk z0rek(bool p0 = false)
	{
		float p1 = z0tek().Size / 2f;
		z0ZzZzimk z0ZzZzimk2 = new z0ZzZzimk(z0tek().Name, p1, FontStyle.Italic);
		if (p0)
		{
			z0ZzZzimk2.Italic = false;
			z0ZzZzimk2.Size = z0tek().Size * 2f / 3f;
		}
		return z0ZzZzimk2;
	}

	private z0ZzZzxdh z0rek(string p0, z0ZzZzjpk p1)
	{
		z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzxdh.z0yek;
		z0ZzZzimk obj = z0tek();
		z0ZzZzimk z0ZzZzimk2 = new z0ZzZzimk(p1: obj.Size * 3f / 4f, p0: obj.Name);
		z0ZzZzxdh2 = ((p0 != null && p0.Length != 0) ? z0eek(p1, p0, z0ZzZzimk2, 100000, z0yek()) : new z0ZzZzxdh(z0ZzZzrpk.z0eek(10, GraphicsUnit.Pixel, p1.z0vek()), p1.z0eek(z0ZzZzimk2)));
		z0ZzZzxdh2.z0rek(z0eek(p1, z0ZzZzimk2) + (float)z0ZzZzrpk.z0eek(4, GraphicsUnit.Pixel, p1.z0vek()));
		return z0ZzZzxdh2;
	}

	private z0ZzZzxdh z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, bool p2)
	{
		if (p0.z0cek() && p0.z0frk() is z0ZzZznej z0ZzZznej2)
		{
			z0ZzZznej2.z0uek();
		}
		float num = (float)z0ZzZzrpk.z0eek(1.0, GraphicsUnit.Pixel, p0.z0vek());
		if (z0pek() == DCMedicalExpressionStyle.FourValues)
		{
			z0ZzZzxdh z0ZzZzxdh2 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh z0ZzZzxdh3 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh z0ZzZzxdh4 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh z0ZzZzxdh5 = z0tek(z0iek().Value4, p0);
			z0ZzZzxdh result = z0ZzZzxdh.z0yek;
			result.z0eek(z0ZzZzxdh2.z0rek() + Math.Max(z0ZzZzxdh3.z0rek(), z0ZzZzxdh4.z0rek()) + z0ZzZzxdh5.z0rek());
			result.z0rek((z0ZzZzxdh3.z0tek() + z0ZzZzxdh4.z0tek()) * 1.1f);
			z0ZzZzxdh result2 = z0ZzZzxdh.z0yek;
			bool flag = false;
			bool flag2 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result2.z0eek(p1.z0uek());
				result2.z0rek(p1.z0iek());
				if (p1.z0uek() > result.z0rek() && p1.z0iek() > result.z0tek())
				{
					result2.z0eek(result.z0rek());
					result2.z0rek(result.z0tek());
					flag2 = false;
				}
				flag = true;
			}
			if (p2)
			{
				if ((result2.z0rek() < result.z0rek() || result2.z0tek() < result.z0tek()) && flag)
				{
					return result2;
				}
				return result;
			}
			object p3 = p0.z0bek();
			float num2 = 0f;
			float num3 = 0f;
			z0ZzZzbdh z0ZzZzbdh2;
			if (flag2)
			{
				z0ZzZzbdh2 = default(z0ZzZzbdh);
				z0ZzZzbdh2.z0tek(result.z0rek());
				z0ZzZzbdh2.z0yek(result.z0tek());
				if (result2.z0rek() > result.z0rek())
				{
					num2 = 1f;
					z0ZzZzpdh p4 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh2.z0eek(p4);
					z0ZzZzbdh2.z0tek(p1.z0uek());
				}
				else
				{
					num2 = result2.z0rek() / result.z0rek();
					z0ZzZzpdh p5 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh2.z0eek(p5);
				}
				if (result2.z0tek() > result.z0tek())
				{
					num3 = 1f;
					z0ZzZzpdh p6 = new z0ZzZzpdh(z0ZzZzbdh2.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result.z0tek()) / 2f);
					z0ZzZzbdh2.z0eek(p6);
				}
				else
				{
					num3 = result2.z0tek() / result.z0tek();
					z0ZzZzpdh p7 = new z0ZzZzpdh(z0ZzZzbdh2.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh2.z0eek(p7);
				}
			}
			else
			{
				z0ZzZzbdh2 = new z0ZzZzbdh(p1.z0oek(), p1.z0pek() + (p1.z0iek() - result.z0tek()) / 2f, p1.z0uek(), result.z0tek());
				num2 = 1f;
				num3 = 1f;
			}
			p0.z0rek(z0ZzZzbdh2.z0oek() * (1f - num2), z0ZzZzbdh2.z0pek() * (1f - num3));
			p0.z0eek(num2, num3);
			if (!string.IsNullOrEmpty(z0iek().Value1))
			{
				p0.z0eek(z0iek().Value1, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzxdh2.z0rek(), z0ZzZzbdh2.z0iek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh2.z0oek() + z0ZzZzxdh2.z0rek(), z0ZzZzbdh2.z0pek() + num * 2f, z0ZzZzbdh2.z0uek() - z0ZzZzxdh2.z0rek() - z0ZzZzxdh5.z0rek(), z0ZzZzxdh3.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh2.z0oek() + z0ZzZzxdh2.z0rek(), z0ZzZzbdh2.z0nek() - z0ZzZzxdh4.z0tek(), z0ZzZzbdh2.z0uek() - z0ZzZzxdh2.z0rek() - z0ZzZzxdh5.z0rek(), z0ZzZzxdh4.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value4))
			{
				p0.z0eek(z0iek().Value4, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh2.z0mek() - z0ZzZzxdh5.z0rek(), z0ZzZzbdh2.z0pek(), z0ZzZzxdh5.z0rek(), z0ZzZzbdh2.z0iek()), z0rek());
			}
			p0.z0tek(z0oek(), z0ZzZzbdh2.z0oek() + z0ZzZzxdh2.z0rek(), z0ZzZzbdh2.z0pek() + z0ZzZzbdh2.z0iek() / 2f, z0ZzZzbdh2.z0mek() - z0ZzZzxdh5.z0rek(), z0ZzZzbdh2.z0pek() + z0ZzZzbdh2.z0iek() / 2f);
			p0.z0eek(p3);
			if ((result2.z0rek() < result.z0rek() || result2.z0tek() < result.z0tek()) && flag)
			{
				return result2;
			}
			return result;
		}
		if (z0pek() == DCMedicalExpressionStyle.FourValues1 || z0pek() == DCMedicalExpressionStyle.FourValuesGeneral)
		{
			z0ZzZzxdh z0ZzZzxdh6 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh z0ZzZzxdh7 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh z0ZzZzxdh8 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh z0ZzZzxdh9 = z0tek(z0iek().Value4, p0);
			z0ZzZzxdh6.z0eek(z0ZzZzxdh6.z0rek() + 20f);
			z0ZzZzxdh8.z0eek(z0ZzZzxdh8.z0rek() + 20f);
			z0ZzZzxdh result3 = z0ZzZzxdh.z0yek;
			result3.z0eek(Math.Max(Math.Max(z0ZzZzxdh6.z0rek(), z0ZzZzxdh7.z0rek()), Math.Max(z0ZzZzxdh8.z0rek(), z0ZzZzxdh9.z0rek())) * 2.1f);
			result3.z0rek((z0ZzZzxdh6.z0tek() + z0ZzZzxdh8.z0tek()) * 1.1f);
			z0ZzZzxdh result4 = z0ZzZzxdh.z0yek;
			bool flag3 = false;
			bool flag4 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result4.z0eek(p1.z0uek());
				result4.z0rek(p1.z0iek());
				if (p1.z0uek() > result3.z0rek() && p1.z0iek() > result3.z0tek())
				{
					result4.z0eek(result3.z0rek());
					result4.z0rek(result3.z0tek());
					flag4 = false;
				}
				flag3 = true;
			}
			if (p2)
			{
				if ((result4.z0rek() < result3.z0rek() || result4.z0tek() < result3.z0tek()) && flag3)
				{
					return result4;
				}
				return result3;
			}
			object p8 = p0.z0bek();
			float num4 = 0f;
			float num5 = 0f;
			z0ZzZzbdh z0ZzZzbdh3;
			if (flag4)
			{
				z0ZzZzbdh3 = default(z0ZzZzbdh);
				z0ZzZzbdh3.z0tek(result3.z0rek());
				z0ZzZzbdh3.z0yek(result3.z0tek());
				if (result4.z0rek() > result3.z0rek())
				{
					num4 = 1f;
					z0ZzZzpdh p9 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result3.z0rek()) / 2f, 0f);
					z0ZzZzbdh3.z0eek(p9);
				}
				else
				{
					num4 = result4.z0rek() / result3.z0rek();
					z0ZzZzpdh p10 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh3.z0eek(p10);
				}
				if (result4.z0tek() > result3.z0tek())
				{
					num5 = 1f;
					z0ZzZzpdh p11 = new z0ZzZzpdh(z0ZzZzbdh3.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result3.z0tek()) / 2f);
					z0ZzZzbdh3.z0eek(p11);
				}
				else
				{
					num5 = result4.z0tek() / result3.z0tek();
					z0ZzZzpdh p12 = new z0ZzZzpdh(z0ZzZzbdh3.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh3.z0eek(p12);
				}
			}
			else
			{
				z0ZzZzbdh3 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result3.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result3.z0tek()) / 2f, result3.z0rek(), result3.z0tek());
				num4 = 1f;
				num5 = 1f;
			}
			p0.z0rek(z0ZzZzbdh3.z0oek() * (1f - num4), z0ZzZzbdh3.z0pek() * (1f - num5));
			p0.z0eek(num4, num5);
			StringAlignment p13 = z0rek().z0pek();
			if (!string.IsNullOrEmpty(z0iek().Value1))
			{
				z0rek().z0rek(StringAlignment.Near);
				p0.z0eek(z0iek().Value1, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh3.z0oek() + (z0ZzZzbdh3.z0uek() / 2f - z0ZzZzxdh6.z0rek()) / 2f, z0ZzZzbdh3.z0pek() + (z0ZzZzbdh3.z0iek() / 2f - z0ZzZzxdh6.z0tek()) / 2f, z0ZzZzxdh6.z0rek(), z0ZzZzxdh6.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				z0rek().z0rek(StringAlignment.Near);
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh3.z0oek() + z0ZzZzbdh3.z0uek() / 2f + (z0ZzZzbdh3.z0uek() / 2f - z0ZzZzxdh7.z0rek()) / 2f, z0ZzZzbdh3.z0pek() + (z0ZzZzbdh3.z0iek() / 2f - z0ZzZzxdh7.z0tek()) / 2f, z0ZzZzxdh7.z0rek(), z0ZzZzxdh7.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				z0rek().z0rek(StringAlignment.Near);
				p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh3.z0oek() + (z0ZzZzbdh3.z0uek() / 2f - z0ZzZzxdh8.z0rek()) / 2f, z0ZzZzbdh3.z0pek() + z0ZzZzbdh3.z0iek() / 2f + (z0ZzZzbdh3.z0iek() / 2f - z0ZzZzxdh8.z0tek()) / 2f, z0ZzZzxdh8.z0rek(), z0ZzZzxdh8.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value4))
			{
				z0rek().z0rek(StringAlignment.Near);
				p0.z0eek(z0iek().Value4, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh3.z0oek() + z0ZzZzbdh3.z0uek() / 2f + (z0ZzZzbdh3.z0uek() / 2f - z0ZzZzxdh9.z0rek()) / 2f, z0ZzZzbdh3.z0pek() + z0ZzZzbdh3.z0iek() / 2f + (z0ZzZzbdh3.z0iek() / 2f - z0ZzZzxdh9.z0tek()) / 2f, z0ZzZzxdh9.z0rek(), z0ZzZzxdh9.z0tek()), z0rek());
			}
			p0.z0tek(z0oek(), z0ZzZzbdh3.z0oek(), z0ZzZzbdh3.z0pek() + z0ZzZzbdh3.z0iek() / 2f, z0ZzZzbdh3.z0oek() + z0ZzZzbdh3.z0uek(), z0ZzZzbdh3.z0pek() + z0ZzZzbdh3.z0iek() / 2f);
			p0.z0tek(z0oek(), z0ZzZzbdh3.z0oek() + z0ZzZzbdh3.z0uek() / 2f, z0ZzZzbdh3.z0pek(), z0ZzZzbdh3.z0oek() + z0ZzZzbdh3.z0uek() / 2f, z0ZzZzbdh3.z0pek() + z0ZzZzbdh3.z0iek());
			p0.z0eek(p8);
			z0rek().z0rek(p13);
			if ((result4.z0rek() < result3.z0rek() || result4.z0tek() < result3.z0tek()) && flag3)
			{
				return result4;
			}
			return result3;
		}
		if (z0pek() == DCMedicalExpressionStyle.FourValues2)
		{
			z0ZzZzxdh z0ZzZzxdh10 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh z0ZzZzxdh11 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh z0ZzZzxdh12 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh z0ZzZzxdh13 = z0tek(z0iek().Value4, p0);
			z0ZzZzxdh10.z0eek(z0ZzZzxdh10.z0rek() + 30f);
			z0ZzZzxdh11.z0eek(z0ZzZzxdh11.z0rek() + 30f);
			z0ZzZzxdh12.z0eek(z0ZzZzxdh12.z0rek() + 30f);
			z0ZzZzxdh13.z0eek(z0ZzZzxdh13.z0rek() + 30f);
			z0ZzZzxdh result5 = z0ZzZzxdh.z0yek;
			result5.z0eek(Math.Max(Math.Max(z0ZzZzxdh10.z0rek(), z0ZzZzxdh12.z0rek()), Math.Max(z0ZzZzxdh11.z0rek(), z0ZzZzxdh13.z0rek())) * 3f);
			result5.z0rek((z0ZzZzxdh11.z0tek() + z0ZzZzxdh13.z0tek()) * 1.5f);
			z0ZzZzxdh result6 = z0ZzZzxdh.z0yek;
			bool flag5 = false;
			bool flag6 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result6.z0eek(p1.z0uek());
				result6.z0rek(p1.z0iek());
				if (p1.z0uek() > result5.z0rek() && p1.z0iek() > result5.z0tek())
				{
					result6.z0eek(result5.z0rek());
					result6.z0rek(result5.z0tek());
					flag6 = false;
				}
				flag5 = true;
			}
			if (p2)
			{
				if ((result6.z0rek() < result5.z0rek() || result6.z0tek() < result5.z0tek()) && flag5)
				{
					return result6;
				}
				return result5;
			}
			object p14 = p0.z0bek();
			float num6 = 0f;
			float num7 = 0f;
			z0ZzZzbdh z0ZzZzbdh4;
			if (flag6)
			{
				z0ZzZzbdh4 = default(z0ZzZzbdh);
				z0ZzZzbdh4.z0tek(result5.z0rek());
				z0ZzZzbdh4.z0yek(result5.z0tek());
				if (result6.z0rek() > result5.z0rek())
				{
					num6 = 1f;
					z0ZzZzpdh p15 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result5.z0rek()) / 2f, 0f);
					z0ZzZzbdh4.z0eek(p15);
				}
				else
				{
					num6 = result6.z0rek() / result5.z0rek();
					z0ZzZzpdh p16 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh4.z0eek(p16);
				}
				if (result6.z0tek() > result5.z0tek())
				{
					num7 = 1f;
					z0ZzZzpdh p17 = new z0ZzZzpdh(z0ZzZzbdh4.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result5.z0tek()) / 2f);
					z0ZzZzbdh4.z0eek(p17);
				}
				else
				{
					num7 = result6.z0tek() / result5.z0tek();
					z0ZzZzpdh p18 = new z0ZzZzpdh(z0ZzZzbdh4.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh4.z0eek(p18);
				}
			}
			else
			{
				z0ZzZzbdh4 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result5.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result5.z0tek()) / 2f, result5.z0rek(), result5.z0tek());
				num6 = 1f;
				num7 = 1f;
			}
			p0.z0rek(z0ZzZzbdh4.z0oek() * (1f - num6), z0ZzZzbdh4.z0pek() * (1f - num7));
			p0.z0eek(num6, num7);
			StringAlignment p19 = z0rek().z0pek();
			if (!string.IsNullOrEmpty(z0iek().Value1))
			{
				z0rek().z0rek(StringAlignment.Near);
				p0.z0eek(z0iek().Value1, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh4.z0oek() + (z0ZzZzbdh4.z0uek() / 2f - z0ZzZzxdh10.z0rek()) / 2f, z0ZzZzbdh4.z0pek() + z0ZzZzbdh4.z0iek() / 5f * 2f, z0ZzZzxdh10.z0rek(), z0ZzZzxdh10.z0tek()), z0rek());
				z0rek().z0rek(StringAlignment.Center);
			}
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				z0rek().z0rek(StringAlignment.Center);
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh4.z0oek() + (z0ZzZzbdh4.z0uek() - z0ZzZzxdh11.z0rek()) / 2f, z0ZzZzbdh4.z0pek() + 5f, z0ZzZzxdh11.z0rek(), z0ZzZzxdh11.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				z0rek().z0rek(StringAlignment.Far);
				p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh4.z0oek() + z0ZzZzbdh4.z0uek() / 2f + (z0ZzZzbdh4.z0uek() / 2f - z0ZzZzxdh12.z0rek()) / 2f, z0ZzZzbdh4.z0pek() + z0ZzZzbdh4.z0iek() / 5f * 2f, z0ZzZzxdh12.z0rek(), z0ZzZzxdh12.z0tek()), z0rek());
				z0rek().z0rek(StringAlignment.Center);
			}
			if (!string.IsNullOrEmpty(z0iek().Value4))
			{
				z0rek().z0rek(StringAlignment.Center);
				p0.z0eek(z0iek().Value4, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh4.z0oek() + (z0ZzZzbdh4.z0uek() - z0ZzZzxdh13.z0rek()) / 2f, z0ZzZzbdh4.z0pek() + z0ZzZzbdh4.z0iek() - z0ZzZzxdh13.z0tek(), z0ZzZzxdh13.z0rek(), z0ZzZzxdh13.z0tek()), z0rek());
			}
			p0.z0tek(z0oek(), z0ZzZzbdh4.z0oek(), z0ZzZzbdh4.z0pek(), z0ZzZzbdh4.z0oek() + z0ZzZzbdh4.z0uek(), z0ZzZzbdh4.z0pek() + z0ZzZzbdh4.z0iek());
			p0.z0tek(z0oek(), z0ZzZzbdh4.z0oek() + z0ZzZzbdh4.z0uek(), z0ZzZzbdh4.z0pek(), z0ZzZzbdh4.z0oek(), z0ZzZzbdh4.z0pek() + z0ZzZzbdh4.z0iek());
			p0.z0eek(p14);
			z0rek().z0rek(p19);
			if ((result6.z0rek() < result5.z0rek() || result6.z0tek() < result5.z0tek()) && flag5)
			{
				return result6;
			}
			return result5;
		}
		if (z0pek() == DCMedicalExpressionStyle.ThreeValues)
		{
			z0ZzZzxdh z0ZzZzxdh14 = z0tek(z0iek().Value1 + "/", p0);
			z0ZzZzxdh z0ZzZzxdh15 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh z0ZzZzxdh16 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh result7 = z0ZzZzxdh.z0yek;
			result7.z0eek(z0ZzZzxdh14.z0rek() + Math.Max(z0ZzZzxdh15.z0rek(), z0ZzZzxdh16.z0rek()));
			result7.z0rek((z0ZzZzxdh15.z0tek() + z0ZzZzxdh16.z0tek()) * 1.1f);
			z0ZzZzxdh result8 = z0ZzZzxdh.z0yek;
			bool flag7 = false;
			bool flag8 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result8.z0eek(p1.z0uek());
				result8.z0rek(p1.z0iek());
				if (p1.z0uek() > result7.z0rek() && p1.z0iek() > result7.z0tek())
				{
					result8.z0eek(result7.z0rek());
					result8.z0rek(result7.z0tek());
					flag8 = false;
				}
				flag7 = true;
			}
			if (p2)
			{
				if ((result8.z0rek() < result7.z0rek() || result8.z0tek() < result7.z0tek()) && flag7)
				{
					return result8;
				}
				return result7;
			}
			object p20 = p0.z0bek();
			float num8 = 0f;
			float num9 = 0f;
			z0ZzZzbdh z0ZzZzbdh5;
			if (flag8)
			{
				z0ZzZzbdh5 = default(z0ZzZzbdh);
				z0ZzZzbdh5.z0tek(result7.z0rek());
				z0ZzZzbdh5.z0yek(result7.z0tek());
				if (result8.z0rek() > result7.z0rek())
				{
					num8 = 1f;
					z0ZzZzpdh p21 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result7.z0rek()) / 2f, 0f);
					z0ZzZzbdh5.z0eek(p21);
				}
				else
				{
					num8 = result8.z0rek() / result7.z0rek();
					z0ZzZzpdh p22 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh5.z0eek(p22);
				}
				if (result8.z0tek() > result7.z0tek())
				{
					num9 = 1f;
					z0ZzZzpdh p23 = new z0ZzZzpdh(z0ZzZzbdh5.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result7.z0tek()) / 2f);
					z0ZzZzbdh5.z0eek(p23);
				}
				else
				{
					num9 = result8.z0tek() / result7.z0tek();
					z0ZzZzpdh p24 = new z0ZzZzpdh(z0ZzZzbdh5.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh5.z0eek(p24);
				}
			}
			else
			{
				z0ZzZzbdh5 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result7.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result7.z0tek()) / 2f, result7.z0rek(), result7.z0tek());
				num8 = 1f;
				num9 = 1f;
			}
			p0.z0rek(z0ZzZzbdh5.z0oek() * (1f - num8), z0ZzZzbdh5.z0pek() * (1f - num9));
			p0.z0eek(num8, num9);
			p0.z0eek(z0iek().Value1 + "/", z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh5.z0oek(), z0ZzZzbdh5.z0pek(), z0ZzZzxdh14.z0rek(), z0ZzZzbdh5.z0iek()), z0rek());
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh5.z0oek() + z0ZzZzxdh14.z0rek(), z0ZzZzbdh5.z0pek() + num * 2f, Math.Max(z0ZzZzxdh15.z0rek(), z0ZzZzxdh16.z0rek()), z0ZzZzxdh15.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh5.z0oek() + z0ZzZzxdh14.z0rek(), z0ZzZzbdh5.z0nek() - z0ZzZzxdh16.z0tek(), Math.Max(z0ZzZzxdh15.z0rek(), z0ZzZzxdh16.z0rek()), z0ZzZzxdh16.z0tek()), z0rek());
			}
			p0.z0tek(z0oek(), z0ZzZzbdh5.z0oek() + z0ZzZzxdh14.z0rek(), z0ZzZzbdh5.z0pek() + z0ZzZzbdh5.z0iek() / 2f, z0ZzZzbdh5.z0oek() + z0ZzZzxdh14.z0rek() + Math.Max(z0ZzZzxdh15.z0rek(), z0ZzZzxdh16.z0rek()), z0ZzZzbdh5.z0pek() + z0ZzZzbdh5.z0iek() / 2f);
			p0.z0eek(p20);
			if ((result8.z0rek() < result7.z0rek() || result8.z0tek() < result7.z0tek()) && flag7)
			{
				return result8;
			}
			return result7;
		}
		if (z0pek() == DCMedicalExpressionStyle.Pupil)
		{
			z0ZzZzxdh z0ZzZzxdh17 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh z0ZzZzxdh18 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh z0ZzZzxdh19 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh z0ZzZzxdh20 = z0tek(z0iek().Value4, p0);
			z0ZzZzxdh z0ZzZzxdh21 = z0tek(z0iek().Value5, p0);
			z0ZzZzxdh z0ZzZzxdh22 = z0tek(z0iek().Value6, p0);
			z0ZzZzxdh z0ZzZzxdh23 = z0tek(z0iek().Value7, p0);
			float num10 = Math.Max(Math.Max(z0ZzZzxdh17.z0rek(), z0ZzZzxdh18.z0rek()), z0ZzZzxdh19.z0rek()) + 30f;
			float num11 = Math.Max(Math.Max(z0ZzZzxdh21.z0rek(), z0ZzZzxdh22.z0rek()), z0ZzZzxdh23.z0rek()) + 30f;
			float num12;
			z0ZzZzxdh19.z0eek(num12 = num10);
			float p25;
			z0ZzZzxdh18.z0eek(p25 = num12);
			z0ZzZzxdh17.z0eek(p25);
			z0ZzZzxdh23.z0eek(num12 = num11);
			z0ZzZzxdh22.z0eek(p25 = num12);
			z0ZzZzxdh21.z0eek(p25);
			z0ZzZzxdh20.z0eek(z0ZzZzxdh20.z0rek() + 30f);
			z0ZzZzxdh result9 = z0ZzZzxdh.z0yek;
			float[] array = new float[7]
			{
				z0ZzZzxdh17.z0rek(),
				z0ZzZzxdh18.z0rek(),
				z0ZzZzxdh19.z0rek(),
				z0ZzZzxdh20.z0rek(),
				z0ZzZzxdh21.z0rek(),
				z0ZzZzxdh22.z0rek(),
				z0ZzZzxdh23.z0rek()
			};
			Array.Sort(array);
			result9.z0eek(array[array.Length - 1] * 3.01f);
			float[] array2 = new float[7]
			{
				z0ZzZzxdh17.z0tek(),
				z0ZzZzxdh18.z0tek(),
				z0ZzZzxdh19.z0tek(),
				z0ZzZzxdh20.z0tek(),
				z0ZzZzxdh21.z0tek(),
				z0ZzZzxdh22.z0tek(),
				z0ZzZzxdh23.z0tek()
			};
			Array.Sort(array2);
			result9.z0rek(array2[array.Length - 1] * 3.01f);
			z0ZzZzxdh result10 = z0ZzZzxdh.z0yek;
			bool flag9 = false;
			bool flag10 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result10.z0eek(p1.z0uek());
				result10.z0rek(p1.z0iek());
				if (p1.z0uek() > result9.z0rek() && p1.z0iek() > result9.z0tek())
				{
					result10.z0eek(result9.z0rek());
					result10.z0rek(result9.z0tek());
					flag10 = false;
				}
				flag9 = true;
			}
			if (p2)
			{
				if ((result10.z0rek() < result9.z0rek() || result10.z0tek() < result9.z0tek()) && flag9)
				{
					return result10;
				}
				return result9;
			}
			object p26 = p0.z0bek();
			float num13 = 0f;
			float num14 = 0f;
			z0ZzZzbdh z0ZzZzbdh6;
			if (flag10)
			{
				z0ZzZzbdh6 = default(z0ZzZzbdh);
				z0ZzZzbdh6.z0tek(result9.z0rek());
				z0ZzZzbdh6.z0yek(result9.z0tek());
				if (result10.z0rek() > result9.z0rek())
				{
					num13 = 1f;
					z0ZzZzpdh p27 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result9.z0rek()) / 2f, 0f);
					z0ZzZzbdh6.z0eek(p27);
				}
				else
				{
					num13 = result10.z0rek() / result9.z0rek();
					z0ZzZzpdh p28 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh6.z0eek(p28);
				}
				if (result10.z0tek() > result9.z0tek())
				{
					num14 = 1f;
					z0ZzZzpdh p29 = new z0ZzZzpdh(z0ZzZzbdh6.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result9.z0tek()) / 2f);
					z0ZzZzbdh6.z0eek(p29);
				}
				else
				{
					num14 = result10.z0tek() / result9.z0tek();
					z0ZzZzpdh p30 = new z0ZzZzpdh(z0ZzZzbdh6.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh6.z0eek(p30);
				}
			}
			else
			{
				z0ZzZzbdh6 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result9.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result9.z0tek()) / 2f, result9.z0rek(), result9.z0tek());
				num13 = 1f;
				num14 = 1f;
			}
			p0.z0rek(z0ZzZzbdh6.z0oek() * (1f - num13), z0ZzZzbdh6.z0pek() * (1f - num14));
			p0.z0eek(num13, num14);
			StringAlignment p31 = z0rek().z0pek();
			z0rek().z0rek(StringAlignment.Near);
			if (!string.IsNullOrEmpty(z0iek().Value1))
			{
				p0.z0eek(z0iek().Value1, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh6.z0oek(), z0ZzZzbdh6.z0pek(), Math.Max(Math.Max(z0ZzZzxdh17.z0rek(), z0ZzZzxdh19.z0rek()), z0ZzZzxdh22.z0rek()), z0ZzZzxdh17.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh6.z0oek() + Math.Max(Math.Max(z0ZzZzxdh17.z0rek(), z0ZzZzxdh19.z0rek()), z0ZzZzxdh22.z0rek()) + z0ZzZzxdh20.z0rek(), z0ZzZzbdh6.z0pek(), Math.Max(Math.Max(z0ZzZzxdh18.z0rek(), z0ZzZzxdh21.z0rek()), z0ZzZzxdh23.z0rek()), z0ZzZzxdh18.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh6.z0oek(), z0ZzZzbdh6.z0pek(), Math.Max(Math.Max(z0ZzZzxdh17.z0rek(), z0ZzZzxdh19.z0rek()), z0ZzZzxdh22.z0rek()), z0ZzZzbdh6.z0iek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value4))
			{
				p0.z0eek(z0iek().Value4, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh6.z0oek() + Math.Max(Math.Max(z0ZzZzxdh17.z0rek(), z0ZzZzxdh19.z0rek()), z0ZzZzxdh22.z0rek()), z0ZzZzbdh6.z0pek(), z0ZzZzxdh20.z0rek(), z0ZzZzbdh6.z0iek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value5))
			{
				p0.z0eek(z0iek().Value5, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh6.z0oek() + Math.Max(Math.Max(z0ZzZzxdh17.z0rek(), z0ZzZzxdh19.z0rek()), z0ZzZzxdh22.z0rek()) + z0ZzZzxdh20.z0rek(), z0ZzZzbdh6.z0pek(), Math.Max(Math.Max(z0ZzZzxdh18.z0rek(), z0ZzZzxdh21.z0rek()), z0ZzZzxdh23.z0rek()), z0ZzZzbdh6.z0iek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value6))
			{
				p0.z0eek(z0iek().Value6, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh6.z0oek(), z0ZzZzbdh6.z0nek() - z0ZzZzxdh22.z0tek(), Math.Max(Math.Max(z0ZzZzxdh17.z0rek(), z0ZzZzxdh19.z0rek()), z0ZzZzxdh22.z0rek()), z0ZzZzxdh22.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value7))
			{
				p0.z0eek(z0iek().Value7, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh6.z0oek() + z0ZzZzxdh20.z0rek() + Math.Max(Math.Max(z0ZzZzxdh18.z0rek(), z0ZzZzxdh21.z0rek()), z0ZzZzxdh23.z0rek()), z0ZzZzbdh6.z0nek() - z0ZzZzxdh23.z0tek(), Math.Max(Math.Max(z0ZzZzxdh18.z0rek(), z0ZzZzxdh21.z0rek()), z0ZzZzxdh23.z0rek()), z0ZzZzxdh23.z0tek()), z0rek());
			}
			p0.z0eek(p26);
			z0rek().z0rek(p31);
			if ((result10.z0rek() < result9.z0rek() || result10.z0tek() < result9.z0tek()) && flag9)
			{
				return result10;
			}
			return result9;
		}
		if (z0pek() == DCMedicalExpressionStyle.LightPositioning)
		{
			z0ZzZzxdh z0ZzZzxdh24 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh z0ZzZzxdh25 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh z0ZzZzxdh26 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh z0ZzZzxdh27 = z0tek(z0iek().Value4, p0);
			z0ZzZzxdh z0ZzZzxdh28 = z0tek(z0iek().Value5, p0);
			z0ZzZzxdh z0ZzZzxdh29 = z0tek(z0iek().Value6, p0);
			z0ZzZzxdh z0ZzZzxdh30 = z0tek(z0iek().Value7, p0);
			z0ZzZzxdh z0ZzZzxdh31 = z0tek(z0iek().Value8, p0);
			z0ZzZzxdh z0ZzZzxdh32 = z0tek(z0iek().Value9, p0);
			float num15 = Math.Max(Math.Max(z0ZzZzxdh24.z0rek(), z0ZzZzxdh27.z0rek()), z0ZzZzxdh30.z0rek()) + 15f;
			float num16 = Math.Max(Math.Max(z0ZzZzxdh25.z0rek(), z0ZzZzxdh28.z0rek()), z0ZzZzxdh31.z0rek()) + 15f;
			float num17 = Math.Max(Math.Max(z0ZzZzxdh26.z0rek(), z0ZzZzxdh29.z0rek()), z0ZzZzxdh32.z0rek());
			float num12;
			z0ZzZzxdh30.z0eek(num12 = num15);
			float p25;
			z0ZzZzxdh27.z0eek(p25 = num12);
			z0ZzZzxdh24.z0eek(p25);
			z0ZzZzxdh31.z0eek(num12 = num16);
			z0ZzZzxdh28.z0eek(p25 = num12);
			z0ZzZzxdh25.z0eek(p25);
			z0ZzZzxdh32.z0eek(num12 = num17);
			z0ZzZzxdh29.z0eek(p25 = num12);
			z0ZzZzxdh26.z0eek(p25);
			z0ZzZzxdh result11 = z0ZzZzxdh.z0yek;
			float[] array3 = new float[9]
			{
				z0ZzZzxdh24.z0rek(),
				z0ZzZzxdh25.z0rek(),
				z0ZzZzxdh26.z0rek(),
				z0ZzZzxdh27.z0rek(),
				z0ZzZzxdh28.z0rek(),
				z0ZzZzxdh29.z0rek(),
				z0ZzZzxdh30.z0rek(),
				z0ZzZzxdh31.z0rek(),
				z0ZzZzxdh32.z0rek()
			};
			Array.Sort(array3);
			result11.z0eek((z0ZzZzxdh24.z0rek() + z0ZzZzxdh25.z0rek() + z0ZzZzxdh26.z0rek()) * 1.1f);
			float[] array4 = new float[9]
			{
				z0ZzZzxdh24.z0tek(),
				z0ZzZzxdh25.z0tek(),
				z0ZzZzxdh26.z0tek(),
				z0ZzZzxdh27.z0tek(),
				z0ZzZzxdh28.z0tek(),
				z0ZzZzxdh29.z0tek(),
				z0ZzZzxdh30.z0tek(),
				z0ZzZzxdh31.z0tek(),
				z0ZzZzxdh32.z0tek()
			};
			Array.Sort(array4);
			result11.z0rek(array4[array3.Length - 1] * 3.01f);
			z0ZzZzxdh result12 = z0ZzZzxdh.z0yek;
			bool flag11 = false;
			bool flag12 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result12.z0eek(p1.z0uek());
				result12.z0rek(p1.z0iek());
				if (p1.z0uek() > result11.z0rek() && p1.z0iek() > result11.z0tek())
				{
					result12.z0eek(result11.z0rek());
					result12.z0rek(result11.z0tek());
					flag12 = false;
				}
				flag11 = true;
			}
			if (p2)
			{
				if ((result12.z0rek() < result11.z0rek() || result12.z0tek() < result11.z0tek()) && flag11)
				{
					return result12;
				}
				return result11;
			}
			object p32 = p0.z0bek();
			float num18 = 0f;
			float num19 = 0f;
			z0ZzZzbdh z0ZzZzbdh7;
			if (flag12)
			{
				z0ZzZzbdh7 = default(z0ZzZzbdh);
				z0ZzZzbdh7.z0tek(result11.z0rek());
				z0ZzZzbdh7.z0yek(result11.z0tek());
				if (result12.z0rek() > result11.z0rek())
				{
					num18 = 1f;
					z0ZzZzpdh p33 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result11.z0rek()) / 2f, 0f);
					z0ZzZzbdh7.z0eek(p33);
				}
				else
				{
					num18 = result12.z0rek() / result11.z0rek();
					z0ZzZzpdh p34 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh7.z0eek(p34);
				}
				if (result12.z0tek() > result11.z0tek())
				{
					num19 = 1f;
					z0ZzZzpdh p35 = new z0ZzZzpdh(z0ZzZzbdh7.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result11.z0tek()) / 2f);
					z0ZzZzbdh7.z0eek(p35);
				}
				else
				{
					num19 = result12.z0tek() / result11.z0tek();
					z0ZzZzpdh p36 = new z0ZzZzpdh(z0ZzZzbdh7.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh7.z0eek(p36);
				}
			}
			else
			{
				z0ZzZzbdh7 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result11.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result11.z0tek()) / 2f, result11.z0rek(), result11.z0tek());
				num18 = 1f;
				num19 = 1f;
			}
			p0.z0rek(z0ZzZzbdh7.z0oek() * (1f - num18), z0ZzZzbdh7.z0pek() * (1f - num19));
			p0.z0eek(num18, num19);
			StringAlignment p37 = z0rek().z0pek();
			z0rek().z0rek(StringAlignment.Near);
			if (!string.IsNullOrEmpty(z0iek().Value1))
			{
				p0.z0eek(z0iek().Value1, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh7.z0oek(), z0ZzZzbdh7.z0pek(), num15, z0ZzZzxdh24.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh7.z0oek() + num15, z0ZzZzbdh7.z0pek(), num16, z0ZzZzxdh25.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh7.z0oek() + num15 + num16, z0ZzZzbdh7.z0pek(), num17, z0ZzZzxdh26.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value4))
			{
				p0.z0eek(z0iek().Value4, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh7.z0oek(), z0ZzZzbdh7.z0pek(), num15, z0ZzZzbdh7.z0iek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value5))
			{
				p0.z0eek(z0iek().Value5, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh7.z0oek() + num15, z0ZzZzbdh7.z0pek(), num16, z0ZzZzbdh7.z0iek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value6))
			{
				p0.z0eek(z0iek().Value6, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh7.z0oek() + num15 + num16, z0ZzZzbdh7.z0pek(), num17, z0ZzZzbdh7.z0iek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value7))
			{
				p0.z0eek(z0iek().Value7, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh7.z0oek(), z0ZzZzbdh7.z0nek() - z0ZzZzxdh30.z0tek(), num15, z0ZzZzxdh30.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value8))
			{
				p0.z0eek(z0iek().Value8, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh7.z0oek() + num15, z0ZzZzbdh7.z0nek() - z0ZzZzxdh31.z0tek(), num16, z0ZzZzxdh31.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value9))
			{
				p0.z0eek(z0iek().Value9, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh7.z0oek() + num15 + num16, z0ZzZzbdh7.z0nek() - z0ZzZzxdh32.z0tek(), num17, z0ZzZzxdh32.z0tek()), z0rek());
			}
			p0.z0eek(p32);
			z0rek().z0rek(p37);
			if ((result12.z0rek() < result11.z0rek() || result12.z0tek() < result11.z0tek()) && flag11)
			{
				return result12;
			}
			return result11;
		}
		if (z0pek() == DCMedicalExpressionStyle.FetalHeart)
		{
			float num20 = z0tek("#", p0).z0rek();
			z0ZzZzxdh z0ZzZzxdh33 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh z0ZzZzxdh34 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh z0ZzZzxdh35 = z0tek(z0iek().Value5, p0);
			float num21 = Math.Max(z0ZzZzxdh33.z0rek(), Math.Max(z0ZzZzxdh34.z0rek(), z0ZzZzxdh35.z0rek()));
			float num22 = z0ZzZzxdh33.z0tek() + z0ZzZzxdh34.z0tek() + z0ZzZzxdh35.z0tek();
			z0ZzZzxdh z0ZzZzxdh36 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh z0ZzZzxdh37 = z0tek(z0iek().Value4, p0);
			z0ZzZzxdh z0ZzZzxdh38 = z0tek(z0iek().Value6, p0);
			float num23 = Math.Max(z0ZzZzxdh36.z0rek(), Math.Max(z0ZzZzxdh37.z0rek(), z0ZzZzxdh38.z0rek()));
			float num24 = z0ZzZzxdh36.z0tek() + z0ZzZzxdh37.z0tek() + z0ZzZzxdh38.z0tek();
			float num25 = 30f;
			float num26 = 30f;
			float num27 = 60f;
			z0ZzZzxdh result13 = z0ZzZzxdh.z0yek;
			result13.z0eek(num25 + num27 + num21 + num23 + num20 * 4f);
			result13.z0rek(Math.Max(num22, num24));
			z0ZzZzxdh result14 = z0ZzZzxdh.z0yek;
			bool flag13 = false;
			bool flag14 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result14.z0eek(p1.z0uek());
				result14.z0rek(p1.z0iek());
				if (p1.z0uek() > result13.z0rek() && p1.z0iek() > result13.z0tek())
				{
					result14.z0eek(result13.z0rek());
					result14.z0rek(result13.z0tek());
					flag14 = false;
				}
				flag13 = true;
			}
			if (p2)
			{
				if ((result14.z0rek() < result13.z0rek() || result14.z0tek() < result13.z0tek()) && flag13)
				{
					return result14;
				}
				return result13;
			}
			object p38 = p0.z0bek();
			float num28 = 0f;
			float num29 = 0f;
			z0ZzZzbdh z0ZzZzbdh8;
			if (flag14)
			{
				z0ZzZzbdh8 = default(z0ZzZzbdh);
				z0ZzZzbdh8.z0tek(result13.z0rek());
				z0ZzZzbdh8.z0yek(result13.z0tek());
				if (result14.z0rek() > result13.z0rek())
				{
					num28 = 1f;
					z0ZzZzpdh p39 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result13.z0rek()) / 2f, 0f);
					z0ZzZzbdh8.z0eek(p39);
				}
				else
				{
					num28 = result14.z0rek() / result13.z0rek();
					z0ZzZzpdh p40 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh8.z0eek(p40);
				}
				if (result14.z0tek() > result13.z0tek())
				{
					num29 = 1f;
					z0ZzZzpdh p41 = new z0ZzZzpdh(z0ZzZzbdh8.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result13.z0tek()) / 2f);
					z0ZzZzbdh8.z0eek(p41);
				}
				else
				{
					num29 = result14.z0tek() / result13.z0tek();
					z0ZzZzpdh p42 = new z0ZzZzpdh(z0ZzZzbdh8.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh8.z0eek(p42);
				}
			}
			else
			{
				z0ZzZzbdh8 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result13.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result13.z0tek()) / 2f, result13.z0rek(), result13.z0tek());
				num28 = 1f;
				num29 = 1f;
			}
			p0.z0rek(z0ZzZzbdh8.z0oek() * (1f - num28), z0ZzZzbdh8.z0pek() * (1f - num29));
			p0.z0eek(num28, num29);
			float num30 = z0ZzZzbdh8.z0pek() + z0ZzZzbdh8.z0iek() / 2f;
			float p43 = z0ZzZzbdh8.z0oek();
			float p44 = z0ZzZzbdh8.z0mek();
			float num31 = z0ZzZzbdh8.z0oek() + num25 + num20;
			float num32 = num31 + num21;
			float num33 = z0ZzZzbdh8.z0mek() - num26 - num20 - num23;
			float num34 = z0ZzZzbdh8.z0mek() - num26 - num20;
			using (z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(z0oek()))
			{
				z0ZzZzudh2.z0eek(z0ZzZzudh2.z0oek() * 4f);
				if (!string.IsNullOrEmpty(z0iek().Value3))
				{
					p0.z0eek(z0ZzZzudh2, p43, num30, num31 - num20, num30);
					p0.z0eek(z0ZzZzudh2, num32 + num20, num30, num33 - num20, num30);
				}
				else
				{
					p0.z0eek(z0ZzZzudh2, p43, num30, num33, num30);
				}
				if (!string.IsNullOrEmpty(z0iek().Value4))
				{
					p0.z0eek(z0ZzZzudh2, num34 + num20, num30, p44, num30);
				}
				else
				{
					p0.z0eek(z0ZzZzudh2, num33, num30, p44, num30);
				}
			}
			float num35 = num32 + (num33 - num32) / 2f;
			p0.z0tek(z0oek(), num35, z0ZzZzbdh8.z0pek(), num35, z0ZzZzbdh8.z0pek() + z0ZzZzbdh8.z0iek());
			if (!string.IsNullOrEmpty(z0iek().Value1))
			{
				p0.z0eek(z0iek().Value1, z0tek(), z0oek(), new z0ZzZzbdh(num31, z0ZzZzbdh8.z0pek(), num21, z0ZzZzxdh33.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(num33, z0ZzZzbdh8.z0pek(), num23, z0ZzZzxdh36.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(num31, z0ZzZzbdh8.z0pek() + z0ZzZzxdh33.z0tek(), num21, z0ZzZzxdh34.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value4))
			{
				p0.z0eek(z0iek().Value4, z0tek(), z0oek(), new z0ZzZzbdh(num33, z0ZzZzbdh8.z0pek() + z0ZzZzxdh36.z0tek(), num23, z0ZzZzxdh37.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value5))
			{
				p0.z0eek(z0iek().Value5, z0tek(), z0oek(), new z0ZzZzbdh(num31, z0ZzZzbdh8.z0pek() + z0ZzZzxdh33.z0tek() + z0ZzZzxdh34.z0tek(), num21, z0ZzZzxdh35.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value6))
			{
				p0.z0eek(z0iek().Value6, z0tek(), z0oek(), new z0ZzZzbdh(num33, z0ZzZzbdh8.z0pek() + z0ZzZzxdh36.z0tek() + z0ZzZzxdh37.z0tek(), num23, z0ZzZzxdh38.z0tek()), z0rek());
			}
			p0.z0eek(p38);
			if ((result14.z0rek() < result13.z0rek() || result14.z0tek() < result13.z0tek()) && flag13)
			{
				return result14;
			}
			return result13;
		}
		if (z0pek() == DCMedicalExpressionStyle.PermanentTeethBitmap)
		{
			string text = z0iek().Value1 + z0iek().Value2 + z0iek().Value3 + z0iek().Value4 + z0iek().Value5 + z0iek().Value6 + z0iek().Value7 + z0iek().Value8;
			string text2 = z0iek().Value9 + z0iek().Value10 + z0iek().Value11 + z0iek().Value12 + z0iek().Value13 + z0iek().Value14 + z0iek().Value15 + z0iek().Value16;
			string text3 = z0iek().Value17 + z0iek().Value18 + z0iek().Value19 + z0iek().Value20 + z0iek().Value21 + z0iek().Value22 + z0iek().Value23 + z0iek().Value24;
			string text4 = z0iek().Value25 + z0iek().Value26 + z0iek().Value27 + z0iek().Value28 + z0iek().Value29 + z0iek().Value30 + z0iek().Value31 + z0iek().Value32;
			float num36 = z0eek(text, p0, p2: false);
			float num37 = z0eek(text2, p0, p2: false);
			float num38 = z0eek(text3, p0, p2: false);
			float num39 = z0eek(text4, p0, p2: false);
			z0ZzZzxdh z0ZzZzxdh39 = z0eek("A", p0);
			z0ZzZzxdh z0ZzZzxdh40 = z0eek("A", p0);
			z0ZzZzxdh result15 = z0ZzZzxdh.z0yek;
			result15.z0eek(Math.Max(Math.Max(num36, num37), Math.Max(num38, num39)) * 2.2f);
			result15.z0rek((z0ZzZzxdh39.z0tek() + z0ZzZzxdh40.z0tek()) * 1.1f);
			z0ZzZzxdh result16 = z0ZzZzxdh.z0yek;
			bool flag15 = false;
			bool flag16 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result16.z0eek(p1.z0uek());
				result16.z0rek(p1.z0iek());
				if (p1.z0uek() > result15.z0rek() && p1.z0iek() > result15.z0tek())
				{
					result16.z0eek(result15.z0rek());
					result16.z0rek(result15.z0tek());
					flag16 = false;
				}
				flag15 = true;
			}
			if (p2)
			{
				if ((result16.z0rek() < result15.z0rek() || result16.z0tek() < result15.z0tek()) && flag15)
				{
					return result16;
				}
				return result15;
			}
			object p45 = p0.z0bek();
			float num40 = 0f;
			float num41 = 0f;
			z0ZzZzbdh z0ZzZzbdh9;
			if (flag16)
			{
				z0ZzZzbdh9 = default(z0ZzZzbdh);
				z0ZzZzbdh9.z0tek(result15.z0rek());
				z0ZzZzbdh9.z0yek(result15.z0tek());
				if (result16.z0rek() + 10f > result15.z0rek())
				{
					num40 = 1f;
					z0ZzZzpdh p46 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result15.z0rek()) / 2f, 0f);
					z0ZzZzbdh9.z0eek(p46);
				}
				else
				{
					num40 = result16.z0rek() / result15.z0rek();
					z0ZzZzpdh p47 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh9.z0eek(p47);
				}
				if (result16.z0tek() + 10f > result15.z0tek())
				{
					num41 = 1f;
					z0ZzZzpdh p48 = new z0ZzZzpdh(z0ZzZzbdh9.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result15.z0tek()) / 2f);
					z0ZzZzbdh9.z0eek(p48);
				}
				else
				{
					num41 = result16.z0tek() / result15.z0tek();
					z0ZzZzpdh p49 = new z0ZzZzpdh(z0ZzZzbdh9.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh9.z0eek(p49);
				}
			}
			else
			{
				z0ZzZzbdh9 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result15.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result15.z0tek()) / 2f, result15.z0rek(), result15.z0tek());
				num40 = 1f;
				num41 = 1f;
			}
			p0.z0rek(z0ZzZzbdh9.z0oek() * (1f - num40), z0ZzZzbdh9.z0pek() * (1f - num41));
			p0.z0eek(num40, num41);
			if (!string.IsNullOrEmpty(text))
			{
				List<string> list = z0eek(text);
				int num42 = 0;
				float num43 = 0f;
				foreach (string item in list)
				{
					num42++;
					if (num42 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh41 = z0eek(item, p0);
						p0.z0eek(item, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh9.z0oek() + (z0ZzZzbdh9.z0uek() / 2f - num36) / 2f + num43, z0ZzZzbdh9.z0pek() + (z0ZzZzbdh9.z0iek() / 2f - z0ZzZzxdh39.z0tek()) / 2f, z0ZzZzxdh41.z0rek(), z0ZzZzxdh41.z0tek()), z0yek());
						num43 += z0ZzZzxdh41.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh42 = z0rek(item, p0);
						p0.z0eek(item, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh9.z0oek() + (z0ZzZzbdh9.z0uek() / 2f - num36) / 2f + num43, z0ZzZzbdh9.z0pek() + (z0ZzZzbdh9.z0iek() / 2f - z0ZzZzxdh39.z0tek()) / 2f, z0ZzZzxdh42.z0rek(), z0ZzZzxdh42.z0tek()), z0yek());
						num43 += z0ZzZzxdh42.z0rek();
					}
				}
			}
			if (!string.IsNullOrEmpty(text2))
			{
				List<string> list2 = z0eek(text2);
				int num44 = 0;
				float num45 = 0f;
				foreach (string item2 in list2)
				{
					num44++;
					if (num44 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh43 = z0eek(item2, p0);
						p0.z0eek(item2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh9.z0oek() + z0ZzZzbdh9.z0uek() / 2f + (z0ZzZzbdh9.z0uek() / 2f - num37) / 2f + num45, z0ZzZzbdh9.z0pek() + (z0ZzZzbdh9.z0iek() / 2f - z0ZzZzxdh39.z0tek()) / 2f, z0ZzZzxdh43.z0rek(), z0ZzZzxdh43.z0tek()), z0yek());
						num45 += z0ZzZzxdh43.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh44 = z0rek(item2, p0);
						p0.z0eek(item2, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh9.z0oek() + z0ZzZzbdh9.z0uek() / 2f + (z0ZzZzbdh9.z0uek() / 2f - num37) / 2f + num45, z0ZzZzbdh9.z0pek() + (z0ZzZzbdh9.z0iek() / 2f - z0ZzZzxdh39.z0tek()) / 2f, z0ZzZzxdh44.z0rek(), z0ZzZzxdh44.z0tek()), z0yek());
						num45 += z0ZzZzxdh44.z0rek();
					}
				}
			}
			if (!string.IsNullOrEmpty(text3))
			{
				List<string> list3 = z0eek(text3);
				int num46 = 0;
				float num47 = 0f;
				foreach (string item3 in list3)
				{
					num46++;
					if (num46 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh45 = z0eek(item3, p0);
						p0.z0eek(item3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh9.z0oek() + (z0ZzZzbdh9.z0uek() / 2f - num38) / 2f + num47, z0ZzZzbdh9.z0pek() + z0ZzZzbdh9.z0iek() / 2f + (z0ZzZzbdh9.z0iek() / 2f - z0ZzZzxdh40.z0tek()) / 2f, z0ZzZzxdh45.z0rek(), z0ZzZzxdh45.z0tek()), z0yek());
						num47 += z0ZzZzxdh45.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh46 = z0rek(item3, p0);
						p0.z0eek(item3, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh9.z0oek() + (z0ZzZzbdh9.z0uek() / 2f - num38) / 2f + num47, z0ZzZzbdh9.z0pek() + z0ZzZzbdh9.z0iek() / 2f + (z0ZzZzbdh9.z0iek() / 2f - z0ZzZzxdh40.z0tek()) / 2f, z0ZzZzxdh46.z0rek(), z0ZzZzxdh46.z0tek()), z0yek());
						num47 += z0ZzZzxdh46.z0rek();
					}
				}
			}
			if (!string.IsNullOrEmpty(text4))
			{
				List<string> list4 = z0eek(text4);
				int num48 = 0;
				float num49 = 0f;
				foreach (string item4 in list4)
				{
					num48++;
					if (num48 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh47 = z0eek(item4, p0);
						p0.z0eek(item4, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh9.z0oek() + z0ZzZzbdh9.z0uek() / 2f + (z0ZzZzbdh9.z0uek() / 2f - num39) / 2f + num49, z0ZzZzbdh9.z0pek() + z0ZzZzbdh9.z0iek() / 2f + (z0ZzZzbdh9.z0iek() / 2f - z0ZzZzxdh40.z0tek()) / 2f, z0ZzZzxdh47.z0rek(), z0ZzZzxdh47.z0tek()), z0yek());
						num49 += z0ZzZzxdh47.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh48 = z0rek(item4, p0);
						p0.z0eek(item4, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh9.z0oek() + z0ZzZzbdh9.z0uek() / 2f + (z0ZzZzbdh9.z0uek() / 2f - num39) / 2f + num49, z0ZzZzbdh9.z0pek() + z0ZzZzbdh9.z0iek() / 2f + (z0ZzZzbdh9.z0iek() / 2f - z0ZzZzxdh40.z0tek()) / 2f, z0ZzZzxdh48.z0rek(), z0ZzZzxdh48.z0tek()), z0yek());
						num49 += z0ZzZzxdh48.z0rek();
					}
				}
			}
			p0.z0tek(z0oek(), z0ZzZzbdh9.z0oek(), z0ZzZzbdh9.z0pek() + z0ZzZzbdh9.z0iek() / 2f, z0ZzZzbdh9.z0oek() + z0ZzZzbdh9.z0uek(), z0ZzZzbdh9.z0pek() + z0ZzZzbdh9.z0iek() / 2f);
			p0.z0tek(z0oek(), z0ZzZzbdh9.z0oek() + z0ZzZzbdh9.z0uek() / 2f, z0ZzZzbdh9.z0pek(), z0ZzZzbdh9.z0oek() + z0ZzZzbdh9.z0uek() / 2f, z0ZzZzbdh9.z0pek() + z0ZzZzbdh9.z0iek());
			p0.z0eek(p45);
			if ((result16.z0rek() < result15.z0rek() || result16.z0tek() < result15.z0tek()) && flag15)
			{
				return result16;
			}
			return result15;
		}
		if (z0pek() == DCMedicalExpressionStyle.DeciduousTeech)
		{
			string text5 = z0iek().Value1 + z0iek().Value2 + z0iek().Value3 + z0iek().Value4 + z0iek().Value5;
			string text6 = z0iek().Value6 + z0iek().Value7 + z0iek().Value8 + z0iek().Value9 + z0iek().Value10;
			string text7 = z0iek().Value11 + z0iek().Value12 + z0iek().Value13 + z0iek().Value14 + z0iek().Value15;
			string text8 = z0iek().Value16 + z0iek().Value17 + z0iek().Value18 + z0iek().Value19 + z0iek().Value20;
			float num50 = z0eek(text5, p0, p2: false);
			float num51 = z0eek(text6, p0, p2: false);
			float num52 = z0eek(text7, p0, p2: false);
			float num53 = z0eek(text8, p0, p2: false);
			z0ZzZzxdh z0ZzZzxdh49 = z0eek("A", p0);
			z0ZzZzxdh z0ZzZzxdh50 = z0eek("A", p0);
			z0ZzZzxdh result17 = z0ZzZzxdh.z0yek;
			result17.z0eek(Math.Max(Math.Max(num50, num51), Math.Max(num52, num53)) * 2.2f);
			result17.z0rek((z0ZzZzxdh49.z0tek() + z0ZzZzxdh50.z0tek()) * 1.1f);
			z0ZzZzxdh result18 = z0ZzZzxdh.z0yek;
			bool flag17 = false;
			bool flag18 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result18.z0eek(p1.z0uek());
				result18.z0rek(p1.z0iek());
				if (p1.z0uek() > result17.z0rek() && p1.z0iek() > result17.z0tek())
				{
					result18.z0eek(result17.z0rek());
					result18.z0rek(result17.z0tek());
					flag18 = false;
				}
				flag17 = true;
			}
			if (p2)
			{
				if ((result18.z0rek() < result17.z0rek() || result18.z0tek() < result17.z0tek()) && flag17)
				{
					return result18;
				}
				return result17;
			}
			object p50 = p0.z0bek();
			float num54 = 0f;
			float num55 = 0f;
			z0ZzZzbdh z0ZzZzbdh10;
			if (flag18)
			{
				z0ZzZzbdh10 = default(z0ZzZzbdh);
				z0ZzZzbdh10.z0tek(result17.z0rek());
				z0ZzZzbdh10.z0yek(result17.z0tek());
				if (result18.z0rek() > result17.z0rek())
				{
					num54 = 1f;
					z0ZzZzpdh p51 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result17.z0rek()) / 2f, 0f);
					z0ZzZzbdh10.z0eek(p51);
				}
				else
				{
					num54 = result18.z0rek() / result17.z0rek();
					z0ZzZzpdh p52 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh10.z0eek(p52);
				}
				if (result18.z0tek() > result17.z0tek())
				{
					num55 = 1f;
					z0ZzZzpdh p53 = new z0ZzZzpdh(z0ZzZzbdh10.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result17.z0tek()) / 2f);
					z0ZzZzbdh10.z0eek(p53);
				}
				else
				{
					num55 = result18.z0tek() / result17.z0tek();
					z0ZzZzpdh p54 = new z0ZzZzpdh(z0ZzZzbdh10.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh10.z0eek(p54);
				}
			}
			else
			{
				z0ZzZzbdh10 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result17.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result17.z0tek()) / 2f, result17.z0rek(), result17.z0tek());
				num54 = 1f;
				num55 = 1f;
			}
			p0.z0rek(z0ZzZzbdh10.z0oek() * (1f - num54), z0ZzZzbdh10.z0pek() * (1f - num55));
			p0.z0eek(num54, num55);
			if (!string.IsNullOrEmpty(text5))
			{
				List<string> list5 = z0eek(text5);
				int num56 = 0;
				float num57 = 0f;
				foreach (string item5 in list5)
				{
					num56++;
					if (num56 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh51 = z0eek(item5, p0);
						p0.z0eek(item5, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh10.z0oek() + (z0ZzZzbdh10.z0uek() / 2f - num50) / 2f + num57, z0ZzZzbdh10.z0pek() + (z0ZzZzbdh10.z0iek() / 2f - z0ZzZzxdh49.z0tek()) / 2f, z0ZzZzxdh51.z0rek(), z0ZzZzxdh51.z0tek()), z0yek());
						num57 += z0ZzZzxdh51.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh52 = z0rek(item5, p0);
						p0.z0eek(item5, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh10.z0oek() + (z0ZzZzbdh10.z0uek() / 2f - num50) / 2f + num57, z0ZzZzbdh10.z0pek() + (z0ZzZzbdh10.z0iek() / 2f - z0ZzZzxdh49.z0tek()) / 2f, z0ZzZzxdh52.z0rek(), z0ZzZzxdh52.z0tek()), z0yek());
						num57 += z0ZzZzxdh52.z0rek();
					}
				}
			}
			if (!string.IsNullOrEmpty(text6))
			{
				List<string> list6 = z0eek(text6);
				int num58 = 0;
				float num59 = 0f;
				foreach (string item6 in list6)
				{
					num58++;
					if (num58 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh53 = z0eek(item6, p0);
						p0.z0eek(item6, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh10.z0oek() + z0ZzZzbdh10.z0uek() / 2f + (z0ZzZzbdh10.z0uek() / 2f - num51) / 2f + num59, z0ZzZzbdh10.z0pek() + (z0ZzZzbdh10.z0iek() / 2f - z0ZzZzxdh49.z0tek()) / 2f, z0ZzZzxdh53.z0rek(), z0ZzZzxdh53.z0tek()), z0yek());
						num59 += z0ZzZzxdh53.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh54 = z0rek(item6, p0);
						p0.z0eek(item6, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh10.z0oek() + z0ZzZzbdh10.z0uek() / 2f + (z0ZzZzbdh10.z0uek() / 2f - num51) / 2f + num59, z0ZzZzbdh10.z0pek() + (z0ZzZzbdh10.z0iek() / 2f - z0ZzZzxdh49.z0tek()) / 2f, z0ZzZzxdh54.z0rek(), z0ZzZzxdh54.z0tek()), z0yek());
						num59 += z0ZzZzxdh54.z0rek();
					}
				}
			}
			if (!string.IsNullOrEmpty(text7))
			{
				List<string> list7 = z0eek(text7);
				int num60 = 0;
				float num61 = 0f;
				foreach (string item7 in list7)
				{
					num60++;
					if (num60 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh55 = z0eek(item7, p0);
						p0.z0eek(item7, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh10.z0oek() + (z0ZzZzbdh10.z0uek() / 2f - num52) / 2f + num61, z0ZzZzbdh10.z0pek() + z0ZzZzbdh10.z0iek() / 2f + (z0ZzZzbdh10.z0iek() / 2f - z0ZzZzxdh50.z0tek()) / 2f, z0ZzZzxdh55.z0rek(), z0ZzZzxdh55.z0tek()), z0yek());
						num61 += z0ZzZzxdh55.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh56 = z0rek(item7, p0);
						p0.z0eek(item7, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh10.z0oek() + (z0ZzZzbdh10.z0uek() / 2f - num52) / 2f + num61, z0ZzZzbdh10.z0pek() + z0ZzZzbdh10.z0iek() / 2f + (z0ZzZzbdh10.z0iek() / 2f - z0ZzZzxdh50.z0tek()) / 2f, z0ZzZzxdh56.z0rek(), z0ZzZzxdh56.z0tek()), z0yek());
						num61 += z0ZzZzxdh56.z0rek();
					}
				}
			}
			if (!string.IsNullOrEmpty(text8))
			{
				List<string> list8 = z0eek(text8);
				int num62 = 0;
				float num63 = 0f;
				foreach (string item8 in list8)
				{
					num62++;
					if (num62 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh57 = z0eek(item8, p0);
						p0.z0eek(item8, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh10.z0oek() + z0ZzZzbdh10.z0uek() / 2f + (z0ZzZzbdh10.z0uek() / 2f - num53) / 2f + num63, z0ZzZzbdh10.z0pek() + z0ZzZzbdh10.z0iek() / 2f + (z0ZzZzbdh10.z0iek() / 2f - z0ZzZzxdh50.z0tek()) / 2f, z0ZzZzxdh57.z0rek(), z0ZzZzxdh57.z0tek()), z0yek());
						num63 += z0ZzZzxdh57.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh58 = z0rek(item8, p0);
						p0.z0eek(item8, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh10.z0oek() + z0ZzZzbdh10.z0uek() / 2f + (z0ZzZzbdh10.z0uek() / 2f - num53) / 2f + num63, z0ZzZzbdh10.z0pek() + z0ZzZzbdh10.z0iek() / 2f + (z0ZzZzbdh10.z0iek() / 2f - z0ZzZzxdh50.z0tek()) / 2f, z0ZzZzxdh58.z0rek(), z0ZzZzxdh58.z0tek()), z0yek());
						num63 += z0ZzZzxdh58.z0rek();
					}
				}
			}
			p0.z0tek(z0oek(), z0ZzZzbdh10.z0oek(), z0ZzZzbdh10.z0pek() + z0ZzZzbdh10.z0iek() / 2f, z0ZzZzbdh10.z0oek() + z0ZzZzbdh10.z0uek(), z0ZzZzbdh10.z0pek() + z0ZzZzbdh10.z0iek() / 2f);
			p0.z0tek(z0oek(), z0ZzZzbdh10.z0oek() + z0ZzZzbdh10.z0uek() / 2f, z0ZzZzbdh10.z0pek(), z0ZzZzbdh10.z0oek() + z0ZzZzbdh10.z0uek() / 2f, z0ZzZzbdh10.z0pek() + z0ZzZzbdh10.z0iek());
			p0.z0eek(p50);
			if ((result18.z0rek() < result17.z0rek() || result18.z0tek() < result17.z0tek()) && flag17)
			{
				return result18;
			}
			return result17;
		}
		if (z0pek() == DCMedicalExpressionStyle.PainIndex)
		{
			float num64 = 15f;
			float num65 = 50f;
			z0ZzZzxdh result19 = z0ZzZzxdh.z0yek;
			result19.z0eek(1600f);
			result19.z0rek(150f);
			z0ZzZzxdh result20 = z0ZzZzxdh.z0yek;
			bool flag19 = false;
			bool flag20 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result20.z0eek(p1.z0uek());
				result20.z0rek(p1.z0iek());
				if (p1.z0uek() > result19.z0rek() && p1.z0iek() > result19.z0tek())
				{
					result20.z0eek(result19.z0rek());
					result20.z0rek(result19.z0tek());
					flag20 = false;
				}
				flag19 = true;
			}
			if (p2)
			{
				if ((result20.z0rek() < result19.z0rek() || result20.z0tek() < result19.z0tek()) && flag19)
				{
					return result20;
				}
				return result19;
			}
			object p55 = p0.z0bek();
			float num66 = 0f;
			float num67 = 0f;
			z0ZzZzbdh z0ZzZzbdh11;
			if (flag20)
			{
				z0ZzZzbdh11 = default(z0ZzZzbdh);
				z0ZzZzbdh11.z0tek(result19.z0rek());
				z0ZzZzbdh11.z0yek(result19.z0tek());
				if (result20.z0rek() > result19.z0rek())
				{
					num66 = 1f;
					z0ZzZzpdh p56 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result19.z0rek()) / 2f, 0f);
					z0ZzZzbdh11.z0eek(p56);
				}
				else
				{
					num66 = result20.z0rek() / result19.z0rek();
					z0ZzZzpdh p57 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh11.z0eek(p57);
				}
				if (result20.z0tek() > result19.z0tek())
				{
					num67 = 1f;
					z0ZzZzpdh p58 = new z0ZzZzpdh(z0ZzZzbdh11.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result19.z0tek()) / 2f);
					z0ZzZzbdh11.z0eek(p58);
				}
				else
				{
					num67 = result20.z0tek() / result19.z0tek();
					z0ZzZzpdh p59 = new z0ZzZzpdh(z0ZzZzbdh11.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh11.z0eek(p59);
				}
			}
			else
			{
				z0ZzZzbdh11 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result19.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result19.z0tek()) / 2f, result19.z0rek(), result19.z0tek());
				num66 = 1f;
				num67 = 1f;
			}
			p0.z0rek(z0ZzZzbdh11.z0oek() * (1f - num66), z0ZzZzbdh11.z0pek() * (1f - num67));
			p0.z0eek(num66, num67);
			if (!string.IsNullOrEmpty(z0iek().Value1))
			{
				int num68 = 0;
				if (int.TryParse(z0iek().Value1, out num68))
				{
					p0.z0eek("▲", z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh11.z0oek(), z0ZzZzbdh11.z0pek() + 50f, 105f + num64 * (float)num68 * 2f, 50f), z0rek());
				}
			}
			string[] array5 = new string[11]
			{
				"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
				"10"
			};
			for (int i = 0; i < 11; i++)
			{
				p0.z0eek(array5[i], z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh11.z0oek(), z0ZzZzbdh11.z0pek() + 80f, 100f + num64 * 20f * (float)i, 70f), z0rek());
			}
			for (int j = 0; j <= 100; j++)
			{
				switch (j % 10)
				{
				case 0:
					p0.z0tek(z0oek(), z0ZzZzbdh11.z0oek() + num64 * (float)j + 50f, z0ZzZzbdh11.z0pek() + 20f, z0ZzZzbdh11.z0oek() + num64 * (float)j + 50f, z0ZzZzbdh11.z0pek() + 80f);
					break;
				case 1:
				case 2:
				case 3:
				case 4:
				case 6:
				case 7:
				case 8:
				case 9:
					p0.z0tek(z0oek(), z0ZzZzbdh11.z0oek() + num64 * (float)j + 50f, z0ZzZzbdh11.z0pek() + 35f, z0ZzZzbdh11.z0oek() + num64 * (float)j + 50f, z0ZzZzbdh11.z0pek() + 50f);
					break;
				case 5:
					p0.z0tek(z0oek(), z0ZzZzbdh11.z0oek() + num64 * (float)j + 50f, z0ZzZzbdh11.z0pek() + 20f, z0ZzZzbdh11.z0oek() + num64 * (float)j + 50f, z0ZzZzbdh11.z0pek() + 50f);
					break;
				}
			}
			p0.z0tek(z0oek(), z0ZzZzbdh11.z0oek() + 50f, z0ZzZzbdh11.z0pek() + num65, z0ZzZzbdh11.z0oek() + 1550f, z0ZzZzbdh11.z0pek() + num65);
			p0.z0eek(p55);
			if ((result20.z0rek() < result19.z0rek() || result20.z0tek() < result19.z0tek()) && flag19)
			{
				return result20;
			}
			return result19;
		}
		if (z0pek() == DCMedicalExpressionStyle.PDTeech)
		{
			z0ZzZzxdh z0ZzZzxdh59 = z0tek("#", p0);
			z0ZzZzxdh z0ZzZzxdh60 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh60.z0eek(z0ZzZzxdh60.z0rek() + z0ZzZzxdh59.z0rek());
			z0ZzZzxdh z0ZzZzxdh61 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh61.z0eek(z0ZzZzxdh60.z0rek() + z0ZzZzxdh59.z0rek());
			z0ZzZzxdh z0ZzZzxdh62 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh62.z0eek(z0ZzZzxdh60.z0rek() + z0ZzZzxdh59.z0rek());
			z0ZzZzxdh z0ZzZzxdh63 = z0tek(z0iek().Value4, p0);
			z0ZzZzxdh63.z0eek(z0ZzZzxdh60.z0rek() + z0ZzZzxdh59.z0rek());
			z0ZzZzxdh z0ZzZzxdh64 = z0tek(z0iek().Value5, p0);
			z0ZzZzxdh64.z0eek(z0ZzZzxdh60.z0rek() + z0ZzZzxdh59.z0rek());
			z0ZzZzxdh z0ZzZzxdh65 = z0tek(z0iek().Value6, p0);
			z0ZzZzxdh65.z0eek(z0ZzZzxdh60.z0rek() + z0ZzZzxdh59.z0rek());
			z0ZzZzxdh z0ZzZzxdh66 = z0tek(z0iek().Value7, p0);
			z0ZzZzxdh z0ZzZzxdh67 = z0tek(z0iek().Value8, p0);
			z0ZzZzxdh z0ZzZzxdh68 = z0tek(z0iek().Value9, p0);
			z0ZzZzxdh z0ZzZzxdh69 = z0tek(z0iek().Value10, p0);
			z0ZzZzxdh result21 = z0ZzZzxdh.z0yek;
			result21.z0eek(z0ZzZzxdh66.z0rek() + Math.Max(z0ZzZzxdh60.z0rek(), z0ZzZzxdh63.z0rek()) + Math.Max(z0ZzZzxdh61.z0rek(), z0ZzZzxdh64.z0rek()) + Math.Max(z0ZzZzxdh62.z0rek(), z0ZzZzxdh65.z0rek()) + Math.Max(z0ZzZzxdh67.z0rek(), Math.Max(z0ZzZzxdh68.z0rek(), z0ZzZzxdh69.z0rek())));
			result21.z0rek(Math.Max(z0ZzZzxdh67.z0tek() + z0ZzZzxdh68.z0tek() + z0ZzZzxdh69.z0tek(), (z0ZzZzxdh60.z0tek() + z0ZzZzxdh63.z0tek()) * 1.1f));
			z0ZzZzxdh result22 = z0ZzZzxdh.z0yek;
			bool flag21 = false;
			bool flag22 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result22.z0eek(p1.z0uek());
				result22.z0rek(p1.z0iek());
				if (p1.z0uek() > result21.z0rek() && p1.z0iek() > result21.z0tek())
				{
					result22.z0eek(result21.z0rek());
					result22.z0rek(result21.z0tek());
					flag22 = false;
				}
				flag21 = true;
			}
			if (p2)
			{
				if ((result22.z0rek() < result21.z0rek() || result22.z0tek() < result21.z0tek()) && flag21)
				{
					return result22;
				}
				return result21;
			}
			object p60 = p0.z0bek();
			float num69 = 0f;
			float num70 = 0f;
			z0ZzZzbdh z0ZzZzbdh12;
			if (flag22)
			{
				z0ZzZzbdh12 = default(z0ZzZzbdh);
				z0ZzZzbdh12.z0tek(result21.z0rek());
				z0ZzZzbdh12.z0yek(result21.z0tek());
				if (result22.z0rek() > result21.z0rek())
				{
					num69 = 1f;
					z0ZzZzpdh p61 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result21.z0rek()) / 2f, 0f);
					z0ZzZzbdh12.z0eek(p61);
				}
				else
				{
					num69 = result22.z0rek() / result21.z0rek();
					z0ZzZzpdh p62 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh12.z0eek(p62);
				}
				if (result22.z0tek() > result21.z0tek())
				{
					num70 = 1f;
					z0ZzZzpdh p63 = new z0ZzZzpdh(z0ZzZzbdh12.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result21.z0tek()) / 2f);
					z0ZzZzbdh12.z0eek(p63);
				}
				else
				{
					num70 = result22.z0tek() / result21.z0tek();
					z0ZzZzpdh p64 = new z0ZzZzpdh(z0ZzZzbdh12.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh12.z0eek(p64);
				}
			}
			else
			{
				z0ZzZzbdh12 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result21.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result21.z0tek()) / 2f, result21.z0rek(), result21.z0tek());
				num69 = 1f;
				num70 = 1f;
			}
			p0.z0rek(z0ZzZzbdh12.z0oek() * (1f - num69), z0ZzZzbdh12.z0pek() * (1f - num70));
			p0.z0eek(num69, num70);
			if (!string.IsNullOrEmpty(z0iek().Value7))
			{
				p0.z0eek(z0iek().Value7, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh12.z0oek(), z0ZzZzbdh12.z0pek() + (z0ZzZzbdh12.z0iek() - z0ZzZzxdh66.z0tek()) / 2f, z0ZzZzxdh66.z0rek(), z0ZzZzxdh66.z0tek()), z0rek());
			}
			float num71 = Math.Max(z0ZzZzxdh60.z0rek(), z0ZzZzxdh63.z0rek());
			if (!string.IsNullOrEmpty(z0iek().Value1))
			{
				p0.z0eek(z0iek().Value1, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek(), z0ZzZzbdh12.z0pek() + (z0ZzZzbdh12.z0iek() / 2f - z0ZzZzxdh60.z0tek()) / 2f, num71, z0ZzZzxdh60.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value4))
			{
				p0.z0eek(z0iek().Value4, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek(), z0ZzZzbdh12.z0pek() + z0ZzZzbdh12.z0iek() / 2f + (z0ZzZzbdh12.z0iek() / 2f - z0ZzZzxdh63.z0tek()) / 2f, num71, z0ZzZzxdh63.z0tek()), z0rek());
			}
			float num72 = Math.Max(z0ZzZzxdh61.z0rek(), z0ZzZzxdh64.z0rek());
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek() + num71, z0ZzZzbdh12.z0pek() + (z0ZzZzbdh12.z0iek() / 2f - z0ZzZzxdh61.z0tek()) / 2f, num72, z0ZzZzxdh61.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value5))
			{
				p0.z0eek(z0iek().Value5, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek() + num71, z0ZzZzbdh12.z0pek() + z0ZzZzbdh12.z0iek() / 2f + (z0ZzZzbdh12.z0iek() / 2f - z0ZzZzxdh64.z0tek()) / 2f, num72, z0ZzZzxdh64.z0tek()), z0rek());
			}
			float num73 = Math.Max(z0ZzZzxdh62.z0rek(), z0ZzZzxdh65.z0rek());
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek() + num71 + num72, z0ZzZzbdh12.z0pek() + (z0ZzZzbdh12.z0iek() / 2f - z0ZzZzxdh62.z0tek()) / 2f, num73, z0ZzZzxdh62.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value6))
			{
				p0.z0eek(z0iek().Value6, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek() + num71 + num72, z0ZzZzbdh12.z0pek() + z0ZzZzbdh12.z0iek() / 2f + (z0ZzZzbdh12.z0iek() / 2f - z0ZzZzxdh65.z0tek()) / 2f, num73, z0ZzZzxdh65.z0tek()), z0rek());
			}
			p0.z0tek(z0oek(), z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek(), z0ZzZzbdh12.z0pek() + z0ZzZzbdh12.z0iek() / 2f, z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek() + num71 + num72 + num73, z0ZzZzbdh12.z0pek() + z0ZzZzbdh12.z0iek() / 2f);
			p0.z0tek(z0oek(), z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek() + num71, z0ZzZzbdh12.z0pek(), z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek() + num71, z0ZzZzbdh12.z0pek() + z0ZzZzbdh12.z0iek());
			p0.z0tek(z0oek(), z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek() + num71 + num72, z0ZzZzbdh12.z0pek(), z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek() + num71 + num72, z0ZzZzbdh12.z0pek() + z0ZzZzbdh12.z0iek());
			if (!string.IsNullOrEmpty(z0iek().Value8))
			{
				p0.z0eek(z0iek().Value8, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh12.z0oek() + z0ZzZzxdh66.z0rek() + num71 + num72 + num73, z0ZzZzbdh12.z0pek() + (z0ZzZzbdh12.z0iek() - z0ZzZzxdh67.z0tek()) / 2f, z0ZzZzxdh67.z0rek(), z0ZzZzxdh67.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value9))
			{
				p0.z0eek(z0iek().Value9, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh12.z0oek() + z0ZzZzbdh12.z0uek() - z0ZzZzxdh68.z0rek(), z0ZzZzbdh12.z0pek(), z0ZzZzxdh68.z0rek(), z0ZzZzxdh68.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value10))
			{
				p0.z0eek(z0iek().Value10, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh12.z0oek() + z0ZzZzbdh12.z0uek() - z0ZzZzxdh69.z0rek(), z0ZzZzbdh12.z0nek() - z0ZzZzxdh69.z0tek(), z0ZzZzxdh69.z0rek(), z0ZzZzxdh69.z0tek()), z0rek());
			}
			p0.z0eek(p60);
			if ((result22.z0rek() < result21.z0rek() || result22.z0tek() < result21.z0tek()) && flag21)
			{
				return result22;
			}
			return result21;
		}
		if (z0pek() == DCMedicalExpressionStyle.DiseasedTeethBotton)
		{
			z0ZzZzxdh z0ZzZzxdh70 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh z0ZzZzxdh71 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh z0ZzZzxdh72 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh result23 = z0ZzZzxdh.z0yek;
			result23.z0eek(z0ZzZzxdh70.z0rek() + Math.Max(z0ZzZzxdh71.z0rek(), z0ZzZzxdh72.z0rek()));
			result23.z0rek((z0ZzZzxdh71.z0tek() + z0ZzZzxdh72.z0tek()) * 1.1f);
			z0ZzZzxdh result24 = z0ZzZzxdh.z0yek;
			bool flag23 = false;
			bool flag24 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result24.z0eek(p1.z0uek());
				result24.z0rek(p1.z0iek());
				if (p1.z0uek() > result23.z0rek() && p1.z0iek() > result23.z0tek())
				{
					result24.z0eek(result23.z0rek());
					result24.z0rek(result23.z0tek());
					flag24 = false;
				}
				flag23 = true;
			}
			if (p2)
			{
				if ((result24.z0rek() < result23.z0rek() || result24.z0tek() < result23.z0tek()) && flag23)
				{
					return result24;
				}
				return result23;
			}
			object p65 = p0.z0bek();
			float num74 = 0f;
			float num75 = 0f;
			z0ZzZzbdh z0ZzZzbdh13;
			if (flag24)
			{
				z0ZzZzbdh13 = default(z0ZzZzbdh);
				z0ZzZzbdh13.z0tek(result23.z0rek());
				z0ZzZzbdh13.z0yek(result23.z0tek());
				if (result24.z0rek() > result23.z0rek())
				{
					num74 = 1f;
					z0ZzZzpdh p66 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result23.z0rek()) / 2f, 0f);
					z0ZzZzbdh13.z0eek(p66);
				}
				else
				{
					num74 = result24.z0rek() / result23.z0rek();
					z0ZzZzpdh p67 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh13.z0eek(p67);
				}
				if (result24.z0tek() > result23.z0tek())
				{
					num75 = 1f;
					z0ZzZzpdh p68 = new z0ZzZzpdh(z0ZzZzbdh13.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result23.z0tek()) / 2f);
					z0ZzZzbdh13.z0eek(p68);
				}
				else
				{
					num75 = result24.z0tek() / result23.z0tek();
					z0ZzZzpdh p69 = new z0ZzZzpdh(z0ZzZzbdh13.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh13.z0eek(p69);
				}
			}
			else
			{
				z0ZzZzbdh13 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result23.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result23.z0tek()) / 2f, result23.z0rek(), result23.z0tek());
				num74 = 1f;
				num75 = 1f;
			}
			p0.z0rek(z0ZzZzbdh13.z0oek() * (1f - num74), z0ZzZzbdh13.z0pek() * (1f - num75));
			p0.z0eek(num74, num75);
			p0.z0eek(z0iek().Value1, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh13.z0oek(), z0ZzZzbdh13.z0pek(), z0ZzZzxdh70.z0rek(), z0ZzZzbdh13.z0iek()), z0rek());
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh13.z0oek() + z0ZzZzxdh70.z0rek(), z0ZzZzbdh13.z0pek() + num * 2f, Math.Max(z0ZzZzxdh71.z0rek(), z0ZzZzxdh72.z0rek()), z0ZzZzxdh71.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh13.z0oek() + z0ZzZzxdh70.z0rek(), z0ZzZzbdh13.z0nek() - z0ZzZzxdh72.z0tek(), Math.Max(z0ZzZzxdh71.z0rek(), z0ZzZzxdh72.z0rek()), z0ZzZzxdh72.z0tek()), z0rek());
			}
			p0.z0tek(z0oek(), z0ZzZzbdh13.z0oek() + z0ZzZzxdh70.z0rek(), z0ZzZzbdh13.z0pek() + z0ZzZzbdh13.z0iek() / 2f, z0ZzZzbdh13.z0oek() + z0ZzZzxdh70.z0rek() + Math.Max(z0ZzZzxdh71.z0rek(), z0ZzZzxdh72.z0rek()), z0ZzZzbdh13.z0pek() + z0ZzZzbdh13.z0iek() / 2f);
			p0.z0eek(p65);
			if ((result24.z0rek() < result23.z0rek() || result24.z0tek() < result23.z0tek()) && flag23)
			{
				return result24;
			}
			return result23;
		}
		if (z0pek() == DCMedicalExpressionStyle.DiseasedTeethTop)
		{
			bool flag25 = z0iek().z0eek("ValueX") == "1";
			z0ZzZzxdh z0ZzZzxdh73 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh z0ZzZzxdh74 = z0tek(z0iek().Value2 + z0iek().Value3, p0);
			z0ZzZzxdh z0ZzZzxdh75 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh z0ZzZzxdh76 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh result25 = z0ZzZzxdh.z0yek;
			result25.z0eek(Math.Max(z0ZzZzxdh73.z0rek(), z0ZzZzxdh74.z0rek()) * 1.5f);
			result25.z0rek(flag25 ? (z0ZzZzxdh74.z0tek() * 1.1f) : (z0ZzZzxdh73.z0tek() * 2.2f));
			z0ZzZzxdh result26 = z0ZzZzxdh.z0yek;
			bool flag26 = false;
			bool flag27 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result26.z0eek(p1.z0uek());
				result26.z0rek(p1.z0iek());
				if (p1.z0uek() > result25.z0rek() && p1.z0iek() > result25.z0tek())
				{
					result26.z0eek(result25.z0rek());
					result26.z0rek(result25.z0tek());
					flag27 = false;
				}
				flag26 = true;
			}
			if (p2)
			{
				if ((result26.z0rek() < result25.z0rek() || result26.z0tek() < result25.z0tek()) && flag26)
				{
					return result26;
				}
				return result25;
			}
			object p70 = p0.z0bek();
			float num76 = 0f;
			float num77 = 0f;
			z0ZzZzbdh z0ZzZzbdh14;
			if (flag27)
			{
				z0ZzZzbdh14 = default(z0ZzZzbdh);
				z0ZzZzbdh14.z0tek(result25.z0rek());
				z0ZzZzbdh14.z0yek(result25.z0tek());
				if (result26.z0rek() > result25.z0rek())
				{
					num76 = 1f;
					z0ZzZzpdh p71 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result25.z0rek()) / 2f, 0f);
					z0ZzZzbdh14.z0eek(p71);
				}
				else
				{
					num76 = result26.z0rek() / result25.z0rek();
					z0ZzZzpdh p72 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh14.z0eek(p72);
				}
				if (result26.z0tek() > result25.z0tek())
				{
					num77 = 1f;
					z0ZzZzpdh p73 = new z0ZzZzpdh(z0ZzZzbdh14.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result25.z0tek()) / 2f);
					z0ZzZzbdh14.z0eek(p73);
				}
				else
				{
					num77 = result26.z0tek() / result25.z0tek();
					z0ZzZzpdh p74 = new z0ZzZzpdh(z0ZzZzbdh14.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh14.z0eek(p74);
				}
			}
			else
			{
				z0ZzZzbdh14 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result25.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result25.z0tek()) / 2f, result25.z0rek(), result25.z0tek());
				num76 = 1f;
				num77 = 1f;
			}
			p0.z0rek(z0ZzZzbdh14.z0oek() * (1f - num76), z0ZzZzbdh14.z0pek() * (1f - num77));
			p0.z0eek(num76, num77);
			if (!flag25)
			{
				p0.z0eek(z0iek().Value1, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh14.z0oek() + (z0ZzZzbdh14.z0uek() - z0ZzZzxdh73.z0rek()) / 2f, z0ZzZzbdh14.z0pek(), z0ZzZzxdh73.z0rek(), z0ZzZzxdh73.z0tek()), z0rek());
			}
			p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh14.z0oek() + (z0ZzZzbdh14.z0uek() / 2f - z0ZzZzxdh76.z0rek()) / 2f, flag25 ? (z0ZzZzbdh14.z0pek() + (z0ZzZzbdh14.z0iek() - z0ZzZzxdh76.z0tek()) / 2f) : (z0ZzZzbdh14.z0pek() + z0ZzZzbdh14.z0iek() / 2f + (z0ZzZzbdh14.z0iek() / 2f - z0ZzZzxdh76.z0tek()) / 2f), z0ZzZzxdh76.z0rek(), z0ZzZzxdh76.z0tek()), z0rek());
			p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh14.z0oek() + z0ZzZzbdh14.z0uek() / 2f + (z0ZzZzbdh14.z0uek() / 2f - z0ZzZzxdh75.z0rek()) / 2f, flag25 ? (z0ZzZzbdh14.z0pek() + (z0ZzZzbdh14.z0iek() - z0ZzZzxdh75.z0tek()) / 2f) : (z0ZzZzbdh14.z0pek() + z0ZzZzbdh14.z0iek() / 2f + (z0ZzZzbdh14.z0iek() / 2f - z0ZzZzxdh75.z0tek()) / 2f), z0ZzZzxdh75.z0rek(), z0ZzZzxdh75.z0tek()), z0rek());
			if (!flag25)
			{
				p0.z0tek(z0oek(), z0ZzZzbdh14.z0oek(), z0ZzZzbdh14.z0pek(), z0ZzZzbdh14.z0oek() + z0ZzZzbdh14.z0uek() / 2f, z0ZzZzbdh14.z0pek() + z0ZzZzbdh14.z0iek() / 2f);
				p0.z0tek(z0oek(), z0ZzZzbdh14.z0oek() + z0ZzZzbdh14.z0uek() / 2f, z0ZzZzbdh14.z0pek() + z0ZzZzbdh14.z0iek() / 2f, z0ZzZzbdh14.z0mek(), z0ZzZzbdh14.z0pek());
			}
			p0.z0tek(z0oek(), z0ZzZzbdh14.z0oek() + z0ZzZzbdh14.z0uek() / 2f, flag25 ? z0ZzZzbdh14.z0pek() : (z0ZzZzbdh14.z0pek() + z0ZzZzbdh14.z0iek() / 2f), z0ZzZzbdh14.z0oek() + z0ZzZzbdh14.z0uek() / 2f, z0ZzZzbdh14.z0nek());
			p0.z0eek(p70);
			if ((result26.z0rek() < result25.z0rek() || result26.z0tek() < result25.z0tek()) && flag26)
			{
				return result26;
			}
			return result25;
		}
		if (z0pek() == DCMedicalExpressionStyle.Fraction)
		{
			z0ZzZzxdh z0ZzZzxdh77 = z0tek(z0iek().Value1 + " /", p0);
			z0ZzZzxdh z0ZzZzxdh78 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh result27 = z0ZzZzxdh.z0yek;
			result27.z0eek(z0ZzZzxdh77.z0rek() + z0ZzZzxdh78.z0rek());
			result27.z0rek(z0ZzZzxdh78.z0tek() * 1.1f);
			z0ZzZzxdh result28 = z0ZzZzxdh.z0yek;
			bool flag28 = false;
			bool flag29 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result28.z0eek(p1.z0uek());
				result28.z0rek(p1.z0iek());
				if (p1.z0uek() > result27.z0rek() && p1.z0iek() > result27.z0tek())
				{
					result28.z0eek(result27.z0rek());
					result28.z0rek(result27.z0tek());
					flag29 = false;
				}
				flag28 = true;
			}
			if (p2)
			{
				if ((result28.z0rek() < result27.z0rek() || result28.z0tek() < result27.z0tek()) && flag28)
				{
					return result28;
				}
				return result27;
			}
			object p75 = p0.z0bek();
			float num78 = 0f;
			float num79 = 0f;
			z0ZzZzbdh z0ZzZzbdh15;
			if (flag29)
			{
				z0ZzZzbdh15 = default(z0ZzZzbdh);
				z0ZzZzbdh15.z0tek(result27.z0rek());
				z0ZzZzbdh15.z0yek(result27.z0tek());
				if (result28.z0rek() > result27.z0rek())
				{
					num78 = 1f;
					z0ZzZzpdh p76 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result27.z0rek()) / 2f, 0f);
					z0ZzZzbdh15.z0eek(p76);
				}
				else
				{
					num78 = result28.z0rek() / result27.z0rek();
					z0ZzZzpdh p77 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh15.z0eek(p77);
				}
				if (result28.z0tek() > result27.z0tek())
				{
					num79 = 1f;
					z0ZzZzpdh p78 = new z0ZzZzpdh(z0ZzZzbdh15.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result27.z0tek()) / 2f);
					z0ZzZzbdh15.z0eek(p78);
				}
				else
				{
					num79 = result28.z0tek() / result27.z0tek();
					z0ZzZzpdh p79 = new z0ZzZzpdh(z0ZzZzbdh15.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh15.z0eek(p79);
				}
			}
			else
			{
				z0ZzZzbdh15 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result27.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result27.z0tek()) / 2f, result27.z0rek(), result27.z0tek());
				num78 = 1f;
				num79 = 1f;
			}
			p0.z0rek(z0ZzZzbdh15.z0oek() * (1f - num78), z0ZzZzbdh15.z0pek() * (1f - num79));
			p0.z0eek(num78, num79);
			p0.z0eek(z0iek().Value1 + " /", z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh15.z0oek(), z0ZzZzbdh15.z0pek(), z0ZzZzxdh77.z0rek(), z0ZzZzbdh15.z0iek()), z0rek());
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh15.z0oek() + z0ZzZzxdh77.z0rek(), z0ZzZzbdh15.z0pek() + num * 2f + 4f, z0ZzZzxdh78.z0rek(), z0ZzZzxdh78.z0tek()), z0rek());
			}
			p0.z0eek(p75);
			if ((result28.z0rek() < result27.z0rek() || result28.z0tek() < result27.z0tek()) && flag28)
			{
				return result28;
			}
			return result27;
		}
		if (z0pek() == DCMedicalExpressionStyle.StationaryBridgeTeeth)
		{
			string text9 = z0rek("1");
			string text10 = z0rek("2");
			string text11 = z0rek("3");
			string text12 = z0rek("4");
			z0ZzZzxdh z0ZzZzxdh79 = z0tek(text9, p0);
			z0ZzZzxdh z0ZzZzxdh80 = z0tek(text10, p0);
			z0ZzZzxdh z0ZzZzxdh81 = z0tek(text11, p0);
			z0ZzZzxdh z0ZzZzxdh82 = z0tek(text12, p0);
			z0ZzZzxdh result29 = z0ZzZzxdh.z0yek;
			result29.z0eek(Math.Max(Math.Max(z0ZzZzxdh79.z0rek(), z0ZzZzxdh80.z0rek()), Math.Max(z0ZzZzxdh81.z0rek(), z0ZzZzxdh82.z0rek())) * 2.1f);
			result29.z0rek((z0ZzZzxdh79.z0tek() + z0ZzZzxdh81.z0tek()) * 1.1f);
			z0ZzZzxdh result30 = z0ZzZzxdh.z0yek;
			bool flag30 = false;
			bool flag31 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result30.z0eek(p1.z0uek());
				result30.z0rek(p1.z0iek());
				if (p1.z0uek() > result29.z0rek() && p1.z0iek() > result29.z0tek())
				{
					result30.z0eek(result29.z0rek());
					result30.z0rek(result29.z0tek());
					flag31 = false;
				}
				flag30 = true;
			}
			if (p2)
			{
				if ((result30.z0rek() < result29.z0rek() || result30.z0tek() < result29.z0tek()) && flag30)
				{
					return result30;
				}
				return result29;
			}
			object p80 = p0.z0bek();
			float num80 = 0f;
			float num81 = 0f;
			z0ZzZzbdh z0ZzZzbdh16;
			if (flag31)
			{
				z0ZzZzbdh16 = default(z0ZzZzbdh);
				z0ZzZzbdh16.z0tek(result29.z0rek());
				z0ZzZzbdh16.z0yek(result29.z0tek());
				if (result30.z0rek() > result29.z0rek())
				{
					num80 = 1f;
					z0ZzZzpdh p81 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result29.z0rek()) / 2f, 0f);
					z0ZzZzbdh16.z0eek(p81);
				}
				else
				{
					num80 = result30.z0rek() / result29.z0rek();
					z0ZzZzpdh p82 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh16.z0eek(p82);
				}
				if (result30.z0tek() > result29.z0tek())
				{
					num81 = 1f;
					z0ZzZzpdh p83 = new z0ZzZzpdh(z0ZzZzbdh16.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result29.z0tek()) / 2f);
					z0ZzZzbdh16.z0eek(p83);
				}
				else
				{
					num81 = result30.z0tek() / result29.z0tek();
					z0ZzZzpdh p84 = new z0ZzZzpdh(z0ZzZzbdh16.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh16.z0eek(p84);
				}
			}
			else
			{
				z0ZzZzbdh16 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result29.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result29.z0tek()) / 2f, result29.z0rek(), result29.z0tek());
				num80 = 1f;
				num81 = 1f;
			}
			p0.z0rek(z0ZzZzbdh16.z0oek() * (1f - num80), z0ZzZzbdh16.z0pek() * (1f - num81));
			p0.z0eek(num80, num81);
			if (!string.IsNullOrEmpty(text9))
			{
				p0.z0eek(text9, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh16.z0oek() + (z0ZzZzbdh16.z0uek() / 2f - z0ZzZzxdh79.z0rek()) / 2f, z0ZzZzbdh16.z0pek() + (z0ZzZzbdh16.z0iek() / 2f - z0ZzZzxdh79.z0tek()) / 2f, z0ZzZzxdh79.z0rek(), z0ZzZzxdh79.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(text10))
			{
				p0.z0eek(text10, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh16.z0oek() + z0ZzZzbdh16.z0uek() / 2f + (z0ZzZzbdh16.z0uek() / 2f - z0ZzZzxdh80.z0rek()) / 2f, z0ZzZzbdh16.z0pek() + (z0ZzZzbdh16.z0iek() / 2f - z0ZzZzxdh80.z0tek()) / 2f, z0ZzZzxdh80.z0rek(), z0ZzZzxdh80.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(text11))
			{
				p0.z0eek(text11, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh16.z0oek() + (z0ZzZzbdh16.z0uek() / 2f - z0ZzZzxdh81.z0rek()) / 2f, z0ZzZzbdh16.z0pek() + z0ZzZzbdh16.z0iek() / 2f + (z0ZzZzbdh16.z0iek() / 2f - z0ZzZzxdh81.z0tek()) / 2f, z0ZzZzxdh81.z0rek(), z0ZzZzxdh81.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(text12))
			{
				p0.z0eek(text12, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh16.z0oek() + z0ZzZzbdh16.z0uek() / 2f + (z0ZzZzbdh16.z0uek() / 2f - z0ZzZzxdh82.z0rek()) / 2f, z0ZzZzbdh16.z0pek() + z0ZzZzbdh16.z0iek() / 2f + (z0ZzZzbdh16.z0iek() / 2f - z0ZzZzxdh82.z0tek()) / 2f, z0ZzZzxdh82.z0rek(), z0ZzZzxdh82.z0tek()), z0rek());
			}
			p0.z0tek(z0oek(), z0ZzZzbdh16.z0oek(), z0ZzZzbdh16.z0pek() + z0ZzZzbdh16.z0iek() / 2f, z0ZzZzbdh16.z0oek() + z0ZzZzbdh16.z0uek(), z0ZzZzbdh16.z0pek() + z0ZzZzbdh16.z0iek() / 2f);
			p0.z0tek(z0oek(), z0ZzZzbdh16.z0oek() + z0ZzZzbdh16.z0uek() / 2f, z0ZzZzbdh16.z0pek(), z0ZzZzbdh16.z0oek() + z0ZzZzbdh16.z0uek() / 2f, z0ZzZzbdh16.z0pek() + z0ZzZzbdh16.z0iek());
			p0.z0eek(p80);
			if ((result30.z0rek() < result29.z0rek() || result30.z0tek() < result29.z0tek()) && flag30)
			{
				return result30;
			}
			return result29;
		}
		if (z0pek() == DCMedicalExpressionStyle.ElectricPulpTestingTeeth)
		{
			string text13 = z0tek("1");
			string text14 = z0tek("2");
			string text15 = z0tek("3");
			string text16 = z0tek("4");
			string[] array6 = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
			string text17 = text13;
			string text18 = text14;
			string text19 = text15;
			string text20 = text16;
			float num82 = z0eek(text17, p0, p2: false);
			float num83 = z0eek(text18, p0, p2: false);
			float num84 = z0eek(text19, p0, p2: false);
			float num85 = z0eek(text20, p0, p2: false);
			z0ZzZzxdh z0ZzZzxdh83 = z0eek("A", p0);
			z0ZzZzxdh z0ZzZzxdh84 = z0eek("A", p0);
			z0ZzZzxdh result31 = z0ZzZzxdh.z0yek;
			result31.z0eek(Math.Max(Math.Max(num82, num83), Math.Max(num84, num85)) * 2.2f);
			result31.z0rek((z0ZzZzxdh83.z0tek() + z0ZzZzxdh84.z0tek()) * 1.1f);
			z0ZzZzxdh result32 = z0ZzZzxdh.z0yek;
			bool flag32 = false;
			bool flag33 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result32.z0eek(p1.z0uek());
				result32.z0rek(p1.z0iek());
				if (p1.z0uek() > result31.z0rek() && p1.z0iek() > result31.z0tek())
				{
					result32.z0eek(result31.z0rek());
					result32.z0rek(result31.z0tek());
					flag33 = false;
				}
				flag32 = true;
			}
			if (p2)
			{
				if ((result32.z0rek() < result31.z0rek() || result32.z0tek() < result31.z0tek()) && flag32)
				{
					return result32;
				}
				return result31;
			}
			object p85 = p0.z0bek();
			float num86 = 0f;
			float num87 = 0f;
			z0ZzZzbdh z0ZzZzbdh17;
			if (flag33)
			{
				z0ZzZzbdh17 = default(z0ZzZzbdh);
				z0ZzZzbdh17.z0tek(result31.z0rek());
				z0ZzZzbdh17.z0yek(result31.z0tek());
				if (result32.z0rek() > result31.z0rek())
				{
					num86 = 1f;
					z0ZzZzpdh p86 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result31.z0rek()) / 2f, 0f);
					z0ZzZzbdh17.z0eek(p86);
				}
				else
				{
					num86 = result32.z0rek() / result31.z0rek();
					z0ZzZzpdh p87 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh17.z0eek(p87);
				}
				if (result32.z0tek() > result31.z0tek())
				{
					num87 = 1f;
					z0ZzZzpdh p88 = new z0ZzZzpdh(z0ZzZzbdh17.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result31.z0tek()) / 2f);
					z0ZzZzbdh17.z0eek(p88);
				}
				else
				{
					num87 = result32.z0tek() / result31.z0tek();
					z0ZzZzpdh p89 = new z0ZzZzpdh(z0ZzZzbdh17.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh17.z0eek(p89);
				}
			}
			else
			{
				z0ZzZzbdh17 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result31.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result31.z0tek()) / 2f, result31.z0rek(), result31.z0tek());
				num86 = 1f;
				num87 = 1f;
			}
			p0.z0rek(z0ZzZzbdh17.z0oek() * (1f - num86), z0ZzZzbdh17.z0pek() * (1f - num87));
			p0.z0eek(num86, num87);
			if (!string.IsNullOrEmpty(text17))
			{
				List<string> list9 = z0eek(text17);
				int num88 = 0;
				float num89 = 0f;
				foreach (string item9 in list9)
				{
					num88++;
					if (num88 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh85 = z0eek(item9, p0);
						p0.z0eek(item9, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh17.z0oek() + (z0ZzZzbdh17.z0uek() / 2f - num82) / 2f + num89, z0ZzZzbdh17.z0pek() + (z0ZzZzbdh17.z0iek() / 2f - z0ZzZzxdh83.z0tek()) / 2f, z0ZzZzxdh85.z0rek(), z0ZzZzxdh85.z0tek()), z0yek());
						num89 += z0ZzZzxdh85.z0rek();
						continue;
					}
					string text21 = "";
					string text22 = item9;
					for (int k = 0; k < text22.Length; k++)
					{
						text21 += Array.IndexOf(array6, text22[k].ToString());
					}
					z0ZzZzxdh z0ZzZzxdh86 = z0rek(text21, p0);
					p0.z0eek(text21, z0rek(p0: true), z0oek(), new z0ZzZzbdh(z0ZzZzbdh17.z0oek() + (z0ZzZzbdh17.z0uek() / 2f - num82) / 2f + num89, z0ZzZzbdh17.z0pek() + (z0ZzZzbdh17.z0iek() / 2f - z0ZzZzxdh83.z0tek()) / 2f, z0ZzZzxdh86.z0rek(), z0ZzZzxdh86.z0tek()), z0yek());
					num89 += z0ZzZzxdh86.z0rek();
				}
			}
			if (!string.IsNullOrEmpty(text18))
			{
				List<string> list10 = z0eek(text18);
				int num90 = 0;
				float num91 = 0f;
				foreach (string item10 in list10)
				{
					num90++;
					if (num90 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh87 = z0eek(item10, p0);
						p0.z0eek(item10, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh17.z0oek() + z0ZzZzbdh17.z0uek() / 2f + (z0ZzZzbdh17.z0uek() / 2f - num83) / 2f + num91, z0ZzZzbdh17.z0pek() + (z0ZzZzbdh17.z0iek() / 2f - z0ZzZzxdh83.z0tek()) / 2f, z0ZzZzxdh87.z0rek(), z0ZzZzxdh87.z0tek()), z0yek());
						num91 += z0ZzZzxdh87.z0rek();
						continue;
					}
					string text23 = "";
					string text22 = item10;
					for (int k = 0; k < text22.Length; k++)
					{
						text23 += Array.IndexOf(array6, text22[k].ToString());
					}
					z0ZzZzxdh z0ZzZzxdh88 = z0rek(text23, p0);
					p0.z0eek(text23, z0rek(p0: true), z0oek(), new z0ZzZzbdh(z0ZzZzbdh17.z0oek() + z0ZzZzbdh17.z0uek() / 2f + (z0ZzZzbdh17.z0uek() / 2f - num83) / 2f + num91, z0ZzZzbdh17.z0pek() + (z0ZzZzbdh17.z0iek() / 2f - z0ZzZzxdh83.z0tek()) / 2f, z0ZzZzxdh88.z0rek(), z0ZzZzxdh88.z0tek()), z0yek());
					num91 += z0ZzZzxdh88.z0rek();
				}
			}
			if (!string.IsNullOrEmpty(text19))
			{
				List<string> list11 = z0eek(text19);
				int num92 = 0;
				float num93 = 0f;
				foreach (string item11 in list11)
				{
					num92++;
					if (num92 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh89 = z0eek(item11, p0);
						p0.z0eek(item11, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh17.z0oek() + (z0ZzZzbdh17.z0uek() / 2f - num84) / 2f + num93, z0ZzZzbdh17.z0pek() + z0ZzZzbdh17.z0iek() / 2f + (z0ZzZzbdh17.z0iek() / 2f - z0ZzZzxdh84.z0tek()) / 2f, z0ZzZzxdh89.z0rek(), z0ZzZzxdh89.z0tek()), z0yek());
						num93 += z0ZzZzxdh89.z0rek();
						continue;
					}
					string text24 = "";
					string text22 = item11;
					for (int k = 0; k < text22.Length; k++)
					{
						text24 += Array.IndexOf(array6, text22[k].ToString());
					}
					z0ZzZzxdh z0ZzZzxdh90 = z0rek(text24, p0);
					p0.z0eek(text24, z0rek(p0: true), z0oek(), new z0ZzZzbdh(z0ZzZzbdh17.z0oek() + (z0ZzZzbdh17.z0uek() / 2f - num84) / 2f + num93, z0ZzZzbdh17.z0pek() + z0ZzZzbdh17.z0iek() / 2f + (z0ZzZzbdh17.z0iek() / 2f - z0ZzZzxdh84.z0tek()) / 2f, z0ZzZzxdh90.z0rek(), z0ZzZzxdh90.z0tek()), z0yek());
					num93 += z0ZzZzxdh90.z0rek();
				}
			}
			if (!string.IsNullOrEmpty(text20))
			{
				List<string> list12 = z0eek(text20);
				int num94 = 0;
				float num95 = 0f;
				foreach (string item12 in list12)
				{
					num94++;
					if (num94 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh91 = z0eek(item12, p0);
						p0.z0eek(item12, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh17.z0oek() + z0ZzZzbdh17.z0uek() / 2f + (z0ZzZzbdh17.z0uek() / 2f - num85) / 2f + num95, z0ZzZzbdh17.z0pek() + z0ZzZzbdh17.z0iek() / 2f + (z0ZzZzbdh17.z0iek() / 2f - z0ZzZzxdh84.z0tek()) / 2f, z0ZzZzxdh91.z0rek(), z0ZzZzxdh91.z0tek()), z0yek());
						num95 += z0ZzZzxdh91.z0rek();
						continue;
					}
					string text25 = "";
					string text22 = item12;
					for (int k = 0; k < text22.Length; k++)
					{
						text25 += Array.IndexOf(array6, text22[k].ToString());
					}
					z0ZzZzxdh z0ZzZzxdh92 = z0rek(text25, p0);
					p0.z0eek(text25, z0rek(p0: true), z0oek(), new z0ZzZzbdh(z0ZzZzbdh17.z0oek() + z0ZzZzbdh17.z0uek() / 2f + (z0ZzZzbdh17.z0uek() / 2f - num85) / 2f + num95, z0ZzZzbdh17.z0pek() + z0ZzZzbdh17.z0iek() / 2f + (z0ZzZzbdh17.z0iek() / 2f - z0ZzZzxdh84.z0tek()) / 2f, z0ZzZzxdh92.z0rek(), z0ZzZzxdh92.z0tek()), z0yek());
					num95 += z0ZzZzxdh92.z0rek();
				}
			}
			p0.z0tek(z0oek(), z0ZzZzbdh17.z0oek(), z0ZzZzbdh17.z0pek() + z0ZzZzbdh17.z0iek() / 2f, z0ZzZzbdh17.z0oek() + z0ZzZzbdh17.z0uek(), z0ZzZzbdh17.z0pek() + z0ZzZzbdh17.z0iek() / 2f);
			p0.z0tek(z0oek(), z0ZzZzbdh17.z0oek() + z0ZzZzbdh17.z0uek() / 2f, z0ZzZzbdh17.z0pek(), z0ZzZzbdh17.z0oek() + z0ZzZzbdh17.z0uek() / 2f, z0ZzZzbdh17.z0pek() + z0ZzZzbdh17.z0iek());
			p0.z0eek(p85);
			if ((result32.z0rek() < result31.z0rek() || result32.z0tek() < result31.z0tek()) && flag32)
			{
				return result32;
			}
			return result31;
		}
		if (z0pek() == DCMedicalExpressionStyle.ThreeValues2)
		{
			z0ZzZzxdh z0ZzZzxdh93 = z0tek(z0iek().Value1 + "mm", p0);
			z0ZzZzxdh z0ZzZzxdh94 = z0tek(z0iek().Value2 + "mm", p0);
			z0ZzZzxdh z0ZzZzxdh95 = z0tek(z0iek().Value3 + "mm", p0);
			z0ZzZzxdh93.z0eek(z0ZzZzxdh93.z0rek() + 50f);
			z0ZzZzxdh95.z0eek(z0ZzZzxdh95.z0rek() + 50f);
			z0ZzZzxdh result33 = z0ZzZzxdh.z0yek;
			result33.z0eek((z0ZzZzxdh93.z0rek() + z0ZzZzxdh94.z0rek() + z0ZzZzxdh95.z0rek()) * 1.2f);
			result33.z0rek(z0ZzZzxdh94.z0tek() * 3f + z0ZzZzxdh95.z0tek());
			z0ZzZzxdh result34 = z0ZzZzxdh.z0yek;
			bool flag34 = false;
			bool flag35 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result34.z0eek(p1.z0uek());
				result34.z0rek(p1.z0iek());
				if (p1.z0uek() > result33.z0rek() && p1.z0iek() > result33.z0tek())
				{
					result34.z0eek(result33.z0rek());
					result34.z0rek(result33.z0tek());
					flag35 = false;
				}
				flag34 = true;
			}
			if (p2)
			{
				if ((result34.z0rek() < result33.z0rek() || result34.z0tek() < result33.z0tek()) && flag34)
				{
					return result34;
				}
				return result33;
			}
			object p90 = p0.z0bek();
			float num96 = 0f;
			float num97 = 0f;
			z0ZzZzbdh z0ZzZzbdh18;
			if (flag35)
			{
				z0ZzZzbdh18 = default(z0ZzZzbdh);
				z0ZzZzbdh18.z0tek(result33.z0rek());
				z0ZzZzbdh18.z0yek(result33.z0tek());
				if (result34.z0rek() > result33.z0rek())
				{
					num96 = 1f;
					z0ZzZzpdh p91 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result33.z0rek()) / 2f, 0f);
					z0ZzZzbdh18.z0eek(p91);
				}
				else
				{
					num96 = result34.z0rek() / result33.z0rek();
					z0ZzZzpdh p92 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh18.z0eek(p92);
				}
				if (result34.z0tek() > result33.z0tek())
				{
					num97 = 1f;
					z0ZzZzpdh p93 = new z0ZzZzpdh(z0ZzZzbdh18.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result33.z0tek()) / 2f);
					z0ZzZzbdh18.z0eek(p93);
				}
				else
				{
					num97 = result34.z0tek() / result33.z0tek();
					z0ZzZzpdh p94 = new z0ZzZzpdh(z0ZzZzbdh18.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh18.z0eek(p94);
				}
			}
			else
			{
				z0ZzZzbdh18 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result33.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result33.z0tek()) / 2f, result33.z0rek(), result33.z0tek());
				num96 = 1f;
				num97 = 1f;
			}
			p0.z0rek(z0ZzZzbdh18.z0oek() * (1f - num96), z0ZzZzbdh18.z0pek() * (1f - num97));
			p0.z0eek(num96, num97);
			p0.z0eek(z0iek().Value1 + "mm", z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh18.z0oek(), z0ZzZzbdh18.z0pek() + (z0ZzZzbdh18.z0iek() - z0ZzZzxdh93.z0tek()) / 2f, z0ZzZzxdh93.z0rek(), z0ZzZzxdh93.z0tek()), z0rek());
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				p0.z0eek(z0iek().Value2 + "mm", z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh18.z0oek() + (z0ZzZzbdh18.z0uek() - z0ZzZzxdh94.z0rek()) / 2f, z0ZzZzbdh18.z0pek() + num * 2f, z0ZzZzxdh94.z0rek(), z0ZzZzxdh94.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				p0.z0eek(z0iek().Value3 + "mm", z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh18.z0oek() + z0ZzZzbdh18.z0uek() - z0ZzZzxdh95.z0rek(), z0ZzZzbdh18.z0pek() + (z0ZzZzbdh18.z0iek() - z0ZzZzxdh95.z0tek()) / 2f, z0ZzZzxdh95.z0rek(), z0ZzZzxdh95.z0tek()), z0rek());
				z0rek().z0rek(StringAlignment.Center);
			}
			float num98 = z0ZzZzbdh18.z0oek() + z0ZzZzbdh18.z0uek() / 3f;
			float p95 = z0ZzZzbdh18.z0oek() + z0ZzZzbdh18.z0uek() / 3f * 2f;
			float num99 = z0ZzZzbdh18.z0pek() + z0ZzZzbdh18.z0iek() / 2f;
			p0.z0tek(z0oek(), z0ZzZzbdh18.z0oek(), z0ZzZzbdh18.z0pek(), num98, num99);
			p0.z0tek(z0oek(), z0ZzZzbdh18.z0oek(), z0ZzZzbdh18.z0nek(), num98, num99);
			p0.z0tek(z0oek(), z0ZzZzbdh18.z0oek() + z0ZzZzbdh18.z0uek(), z0ZzZzbdh18.z0pek(), p95, num99);
			p0.z0tek(z0oek(), z0ZzZzbdh18.z0oek() + z0ZzZzbdh18.z0uek(), z0ZzZzbdh18.z0nek(), p95, num99);
			p0.z0tek(z0oek(), num98, num99, p95, num99);
			p0.z0eek(p90);
			if ((result34.z0rek() < result33.z0rek() || result34.z0tek() < result33.z0tek()) && flag34)
			{
				return result34;
			}
			return result33;
		}
		if (z0pek() == DCMedicalExpressionStyle.StrabismusSymbol)
		{
			z0ZzZzxdh result35 = new z0ZzZzxdh(200f, 200f);
			z0ZzZzxdh result36 = z0ZzZzxdh.z0yek;
			bool flag36 = false;
			bool flag37 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result36.z0eek(p1.z0uek());
				result36.z0rek(p1.z0iek());
				if (p1.z0uek() > result35.z0rek() && p1.z0iek() > result35.z0tek())
				{
					result36.z0eek(result35.z0rek());
					result36.z0rek(result35.z0tek());
					flag37 = false;
				}
				flag36 = true;
			}
			if (p2)
			{
				if ((result36.z0rek() < result35.z0rek() || result36.z0tek() < result35.z0tek()) && flag36)
				{
					return result36;
				}
				return result35;
			}
			object p96 = p0.z0bek();
			float num100 = 0f;
			float num101 = 0f;
			z0ZzZzbdh z0ZzZzbdh19;
			if (flag37)
			{
				z0ZzZzbdh19 = default(z0ZzZzbdh);
				z0ZzZzbdh19.z0tek(result35.z0rek());
				z0ZzZzbdh19.z0yek(result35.z0tek());
				if (result36.z0rek() > result35.z0rek())
				{
					num100 = 1f;
					z0ZzZzpdh p97 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result35.z0rek()) / 2f, 0f);
					z0ZzZzbdh19.z0eek(p97);
				}
				else
				{
					num100 = result36.z0rek() / result35.z0rek();
					z0ZzZzpdh p98 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh19.z0eek(p98);
				}
				if (result36.z0tek() > result35.z0tek())
				{
					num101 = 1f;
					z0ZzZzpdh p99 = new z0ZzZzpdh(z0ZzZzbdh19.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result35.z0tek()) / 2f);
					z0ZzZzbdh19.z0eek(p99);
				}
				else
				{
					num101 = result36.z0tek() / result35.z0tek();
					z0ZzZzpdh p100 = new z0ZzZzpdh(z0ZzZzbdh19.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh19.z0eek(p100);
				}
			}
			else
			{
				z0ZzZzbdh19 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result35.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result35.z0tek()) / 2f, result35.z0rek(), result35.z0tek());
				num100 = 1f;
				num101 = 1f;
			}
			p0.z0rek(z0ZzZzbdh19.z0oek() * (1f - num100), z0ZzZzbdh19.z0pek() * (1f - num101));
			p0.z0eek(num100, num101);
			z0ZzZzxdh z0ZzZzxdh96 = new z0ZzZzxdh(44.67162f, 47.131336f);
			z0ZzZzbdh z0ZzZzbdh20 = z0ZzZzbdh19;
			using (z0ZzZzudh p101 = new z0ZzZzudh(Color.Black))
			{
				switch (z0iek().Value1)
				{
				case "L":
					p0.z0eek("L", z0tek(), z0oek(), z0ZzZzbdh20.z0oek(), z0ZzZzbdh20.z0nek() - z0ZzZzxdh96.z0tek());
					p0.z0eek(p101, new z0ZzZzodh((int)(z0ZzZzbdh20.z0oek() + z0ZzZzxdh96.z0rek()), (int)(z0ZzZzbdh20.z0nek() - z0ZzZzxdh96.z0tek())), new z0ZzZzodh((int)(z0ZzZzbdh20.z0mek() - z0ZzZzxdh96.z0rek()), (int)(z0ZzZzbdh20.z0pek() + z0ZzZzxdh96.z0tek())));
					break;
				case "R":
					p0.z0eek("R", z0tek(), z0oek(), z0ZzZzbdh20.z0mek() - z0ZzZzxdh96.z0rek(), z0ZzZzbdh20.z0nek() - z0ZzZzxdh96.z0tek());
					p0.z0eek(p101, new z0ZzZzodh((int)(z0ZzZzbdh20.z0oek() + z0ZzZzxdh96.z0rek()), (int)(z0ZzZzbdh20.z0pek() + z0ZzZzxdh96.z0tek())), new z0ZzZzodh((int)(z0ZzZzbdh20.z0mek() - z0ZzZzxdh96.z0rek()), (int)(z0ZzZzbdh20.z0nek() - z0ZzZzxdh96.z0tek())));
					break;
				case "LR":
					p0.z0eek("L", z0tek(), z0oek(), z0ZzZzbdh20.z0oek(), z0ZzZzbdh20.z0nek() - z0ZzZzxdh96.z0tek());
					p0.z0eek(p101, new z0ZzZzodh((int)(z0ZzZzbdh20.z0oek() + z0ZzZzxdh96.z0rek()), (int)(z0ZzZzbdh20.z0nek() - z0ZzZzxdh96.z0tek())), new z0ZzZzodh((int)(z0ZzZzbdh20.z0mek() - z0ZzZzxdh96.z0rek()), (int)(z0ZzZzbdh20.z0pek() + z0ZzZzxdh96.z0tek())));
					p0.z0eek("R", z0tek(), z0oek(), z0ZzZzbdh20.z0mek() - z0ZzZzxdh96.z0rek(), z0ZzZzbdh20.z0nek() - z0ZzZzxdh96.z0tek());
					p0.z0eek(p101, new z0ZzZzodh((int)(z0ZzZzbdh20.z0oek() + z0ZzZzxdh96.z0rek()), (int)(z0ZzZzbdh20.z0pek() + z0ZzZzxdh96.z0tek())), new z0ZzZzodh((int)(z0ZzZzbdh20.z0mek() - z0ZzZzxdh96.z0rek()), (int)(z0ZzZzbdh20.z0nek() - z0ZzZzxdh96.z0tek())));
					break;
				}
				p0.z0eek(z0ZzZzyfh.z0uek, new z0ZzZzbdh(z0ZzZzbdh20.z0oek() + z0ZzZzbdh20.z0uek() / 2f - z0ZzZzxdh96.z0rek() / 4f, z0ZzZzbdh20.z0pek() + z0ZzZzbdh20.z0iek() / 2f - z0ZzZzxdh96.z0tek() / 4f, z0ZzZzxdh96.z0rek() / 2f, z0ZzZzxdh96.z0tek() / 2f));
			}
			p0.z0eek(p96);
			if ((result36.z0rek() < result35.z0rek() || result36.z0tek() < result35.z0tek()) && flag36)
			{
				return result36;
			}
			return result35;
		}
		if (z0pek() == DCMedicalExpressionStyle.ManyValues)
		{
			bool flag38 = false;
			foreach (z0ZzZzjuk item13 in z0iek())
			{
				if (item13.Name != "ValueX" && !string.IsNullOrEmpty(item13.Value))
				{
					flag38 = true;
					break;
				}
			}
			if (!flag38)
			{
				z0ZzZzxdh z0ZzZzxdh97 = z0ZzZzxdh.z0yek;
				z0ZzZzxdh97 = (p1.z0bek() ? new z0ZzZzxdh(450f, 250f) : new z0ZzZzxdh(p1.z0uek(), p1.z0iek()));
				z0ZzZzbdh z0ZzZzbdh21 = default(z0ZzZzbdh);
				z0ZzZzbdh21.z0tek(z0ZzZzxdh97.z0rek());
				z0ZzZzbdh21.z0yek(z0ZzZzxdh97.z0tek());
				p0.z0tek(z0oek(), z0ZzZzbdh21.z0oek(), z0ZzZzbdh21.z0pek() + z0ZzZzbdh21.z0iek() / 2f, z0ZzZzbdh21.z0oek() + z0ZzZzbdh21.z0uek(), z0ZzZzbdh21.z0pek() + z0ZzZzbdh21.z0iek() / 2f);
				p0.z0tek(z0oek(), z0ZzZzbdh21.z0oek() + z0ZzZzbdh21.z0uek() / 2f, z0ZzZzbdh21.z0pek(), z0ZzZzbdh21.z0oek() + z0ZzZzbdh21.z0uek() / 2f, z0ZzZzbdh21.z0pek() + z0ZzZzbdh21.z0iek());
				return z0ZzZzxdh97;
			}
			string text26 = "";
			string text27 = "";
			string text28 = "";
			string text29 = "";
			string text30 = "";
			string text31 = "";
			string text32 = "";
			string text33 = "";
			string text34 = "";
			string text35 = "";
			string text36 = "";
			string text37 = "";
			for (int l = 1; l <= 8; l++)
			{
				string p102 = "Value" + l;
				text30 += z0iek().z0eek(p102);
			}
			for (int m = 11; m <= 15; m++)
			{
				string p103 = "Value" + m;
				text31 += z0iek().z0eek(p103);
			}
			for (int n = 21; n <= 25; n++)
			{
				string p104 = "Value" + n;
				text32 += z0iek().z0eek(p104);
			}
			for (int num102 = 31; num102 <= 38; num102++)
			{
				string p105 = "Value" + num102;
				text33 += z0iek().z0eek(p105);
			}
			for (int num103 = 41; num103 <= 48; num103++)
			{
				string p106 = "Value" + num103;
				text34 += z0iek().z0eek(p106);
			}
			for (int num104 = 51; num104 <= 55; num104++)
			{
				string p107 = "Value" + num104;
				text35 += z0iek().z0eek(p107);
			}
			for (int num105 = 61; num105 <= 65; num105++)
			{
				string p108 = "Value" + num105;
				text36 += z0iek().z0eek(p108);
			}
			for (int num106 = 71; num106 <= 78; num106++)
			{
				string p109 = "Value" + num106;
				text37 += z0iek().z0eek(p109);
			}
			text26 = ((text30.Length > 0 && text31.Length > 0) ? (text30 + Environment.NewLine + text31) : (text30 + text31));
			text27 = ((text34.Length > 0 && text35.Length > 0) ? (text34 + Environment.NewLine + text35) : (text34 + text35));
			text28 = ((text32.Length > 0 && text33.Length > 0) ? (text32 + Environment.NewLine + text33) : (text32 + text33));
			text29 = ((text36.Length > 0 && text37.Length > 0) ? (text36 + Environment.NewLine + text37) : (text36 + text37));
			z0ZzZzxdh z0ZzZzxdh98 = z0tek(text30, p0);
			z0ZzZzxdh z0ZzZzxdh99 = z0tek(text31, p0);
			z0ZzZzxdh z0ZzZzxdh100 = z0tek(text32, p0);
			z0ZzZzxdh z0ZzZzxdh101 = z0tek(text33, p0);
			z0ZzZzxdh z0ZzZzxdh102 = z0tek(text34, p0);
			z0ZzZzxdh z0ZzZzxdh103 = z0tek(text35, p0);
			z0ZzZzxdh z0ZzZzxdh104 = z0tek(text36, p0);
			z0ZzZzxdh z0ZzZzxdh105 = z0tek(text37, p0);
			z0ZzZzxdh z0ZzZzxdh106 = new z0ZzZzxdh(Math.Max(z0ZzZzxdh98.z0rek(), z0ZzZzxdh99.z0rek()), z0ZzZzxdh98.z0tek() + z0ZzZzxdh99.z0tek());
			z0ZzZzxdh z0ZzZzxdh107 = new z0ZzZzxdh(Math.Max(z0ZzZzxdh102.z0rek(), z0ZzZzxdh103.z0rek()), z0ZzZzxdh102.z0tek() + z0ZzZzxdh103.z0tek());
			z0ZzZzxdh z0ZzZzxdh108 = new z0ZzZzxdh(Math.Max(z0ZzZzxdh100.z0rek(), z0ZzZzxdh101.z0rek()), z0ZzZzxdh100.z0tek() + z0ZzZzxdh101.z0tek());
			z0ZzZzxdh z0ZzZzxdh109 = new z0ZzZzxdh(Math.Max(z0ZzZzxdh104.z0rek(), z0ZzZzxdh105.z0rek()), z0ZzZzxdh104.z0tek() + z0ZzZzxdh105.z0tek());
			z0ZzZzxdh result37 = z0ZzZzxdh.z0yek;
			result37.z0eek(Math.Max(Math.Max(z0ZzZzxdh106.z0rek(), z0ZzZzxdh107.z0rek()), Math.Max(z0ZzZzxdh108.z0rek(), z0ZzZzxdh109.z0rek())) * 2.1f);
			result37.z0rek((z0ZzZzxdh106.z0tek() + z0ZzZzxdh108.z0tek()) * 1.1f);
			z0ZzZzxdh result38 = z0ZzZzxdh.z0yek;
			bool flag39 = false;
			bool flag40 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result38.z0eek(p1.z0uek());
				result38.z0rek(p1.z0iek());
				if (p1.z0uek() > result37.z0rek() && p1.z0iek() > result37.z0tek())
				{
					result38.z0eek(result37.z0rek());
					result38.z0rek(result37.z0tek());
					flag40 = false;
				}
				flag39 = true;
			}
			if (p2)
			{
				if ((result38.z0rek() < result37.z0rek() || result38.z0tek() < result37.z0tek()) && flag39)
				{
					return result38;
				}
				return result37;
			}
			object p110 = p0.z0bek();
			float num107 = 0f;
			float num108 = 0f;
			z0ZzZzbdh z0ZzZzbdh22;
			if (flag40)
			{
				z0ZzZzbdh22 = default(z0ZzZzbdh);
				z0ZzZzbdh22.z0tek(result37.z0rek());
				z0ZzZzbdh22.z0yek(result37.z0tek());
				if (result38.z0rek() > result37.z0rek())
				{
					num107 = 1f;
					z0ZzZzpdh p111 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result37.z0rek()) / 2f, 0f);
					z0ZzZzbdh22.z0eek(p111);
				}
				else
				{
					num107 = result38.z0rek() / result37.z0rek();
					z0ZzZzpdh p112 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh22.z0eek(p112);
				}
				if (result38.z0tek() > result37.z0tek())
				{
					num108 = 1f;
					z0ZzZzpdh p113 = new z0ZzZzpdh(z0ZzZzbdh22.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result37.z0tek()) / 2f);
					z0ZzZzbdh22.z0eek(p113);
				}
				else
				{
					num108 = result38.z0tek() / result37.z0tek();
					z0ZzZzpdh p114 = new z0ZzZzpdh(z0ZzZzbdh22.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh22.z0eek(p114);
				}
			}
			else
			{
				z0ZzZzbdh22 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result37.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result37.z0tek()) / 2f, result37.z0rek(), result37.z0tek());
				num107 = 1f;
				num108 = 1f;
			}
			p0.z0rek(z0ZzZzbdh22.z0oek() * (1f - num107), z0ZzZzbdh22.z0pek() * (1f - num108));
			p0.z0eek(num107, num108);
			z0ZzZzbdh z0ZzZzbdh23 = z0ZzZzbdh.z0xek;
			if (!string.IsNullOrEmpty(text26))
			{
				z0rek().z0rek(StringAlignment.Far);
				z0ZzZzbdh23 = new z0ZzZzbdh(z0ZzZzbdh22.z0oek() + (z0ZzZzbdh22.z0uek() / 2f - z0ZzZzxdh106.z0rek()) / 2f, z0ZzZzbdh22.z0pek() + (z0ZzZzbdh22.z0iek() / 2f - z0ZzZzxdh106.z0tek()) / 2f, z0ZzZzxdh106.z0rek(), z0ZzZzxdh98.z0tek());
				p0.z0eek(text30, z0tek(), z0oek(), z0ZzZzbdh23, z0rek());
				z0ZzZzbdh23.z0rek(z0ZzZzbdh23.z0yek() + z0ZzZzxdh98.z0tek());
				p0.z0eek(text31, z0tek(), z0oek(), z0ZzZzbdh23, z0rek());
			}
			if (!string.IsNullOrEmpty(text27))
			{
				z0rek().z0rek(StringAlignment.Near);
				z0ZzZzbdh23 = new z0ZzZzbdh(z0ZzZzbdh22.z0oek() + z0ZzZzbdh22.z0uek() / 2f + (z0ZzZzbdh22.z0uek() / 2f - z0ZzZzxdh107.z0rek()) / 2f, z0ZzZzbdh22.z0pek() + (z0ZzZzbdh22.z0iek() / 2f - z0ZzZzxdh107.z0tek()) / 2f, z0ZzZzxdh107.z0rek(), z0ZzZzxdh102.z0tek());
				p0.z0eek(text34, z0tek(), z0oek(), z0ZzZzbdh23, z0rek());
				z0ZzZzbdh23.z0rek(z0ZzZzbdh23.z0yek() + z0ZzZzxdh102.z0tek());
				p0.z0eek(text35, z0tek(), z0oek(), z0ZzZzbdh23, z0rek());
			}
			if (!string.IsNullOrEmpty(text28))
			{
				z0rek().z0rek(StringAlignment.Far);
				z0ZzZzbdh23 = new z0ZzZzbdh(z0ZzZzbdh22.z0oek() + (z0ZzZzbdh22.z0uek() / 2f - z0ZzZzxdh108.z0rek()) / 2f, z0ZzZzbdh22.z0pek() + z0ZzZzbdh22.z0iek() / 2f + (z0ZzZzbdh22.z0iek() / 2f - z0ZzZzxdh108.z0tek()) / 2f, z0ZzZzxdh108.z0rek(), z0ZzZzxdh100.z0tek());
				p0.z0eek(text32, z0tek(), z0oek(), z0ZzZzbdh23, z0rek());
				z0ZzZzbdh23.z0rek(z0ZzZzbdh23.z0yek() + z0ZzZzxdh100.z0tek());
				p0.z0eek(text33, z0tek(), z0oek(), z0ZzZzbdh23, z0rek());
			}
			if (!string.IsNullOrEmpty(text29))
			{
				z0rek().z0rek(StringAlignment.Near);
				z0ZzZzbdh23 = new z0ZzZzbdh(z0ZzZzbdh22.z0oek() + z0ZzZzbdh22.z0uek() / 2f + (z0ZzZzbdh22.z0uek() / 2f - z0ZzZzxdh109.z0rek()) / 2f, z0ZzZzbdh22.z0pek() + z0ZzZzbdh22.z0iek() / 2f + (z0ZzZzbdh22.z0iek() / 2f - z0ZzZzxdh109.z0tek()) / 2f, z0ZzZzxdh109.z0rek(), z0ZzZzxdh104.z0tek());
				p0.z0eek(text36, z0tek(), z0oek(), z0ZzZzbdh23, z0rek());
				z0ZzZzbdh23.z0rek(z0ZzZzbdh23.z0yek() + z0ZzZzxdh104.z0tek());
				p0.z0eek(text37, z0tek(), z0oek(), z0ZzZzbdh23, z0rek());
			}
			p0.z0tek(z0oek(), z0ZzZzbdh22.z0oek(), z0ZzZzbdh22.z0pek() + z0ZzZzbdh22.z0iek() / 2f, z0ZzZzbdh22.z0oek() + z0ZzZzbdh22.z0uek(), z0ZzZzbdh22.z0pek() + z0ZzZzbdh22.z0iek() / 2f);
			p0.z0tek(z0oek(), z0ZzZzbdh22.z0oek() + z0ZzZzbdh22.z0uek() / 2f, z0ZzZzbdh22.z0pek(), z0ZzZzbdh22.z0oek() + z0ZzZzbdh22.z0uek() / 2f, z0ZzZzbdh22.z0pek() + z0ZzZzbdh22.z0iek());
			p0.z0eek(p110);
			if ((result38.z0rek() < result37.z0rek() || result38.z0tek() < result37.z0tek()) && flag39)
			{
				return result38;
			}
			return result37;
		}
		if (z0pek() == DCMedicalExpressionStyle.AdvancedTeech)
		{
			bool flag41 = false;
			foreach (z0ZzZzjuk item14 in z0iek())
			{
				if (item14.Name != "ValueX" && !string.IsNullOrEmpty(item14.Value))
				{
					flag41 = true;
					break;
				}
			}
			if (!flag41)
			{
				z0ZzZzxdh z0ZzZzxdh110 = z0ZzZzxdh.z0yek;
				z0ZzZzxdh110 = (p1.z0bek() ? new z0ZzZzxdh(450f, 250f) : new z0ZzZzxdh(p1.z0uek(), p1.z0iek()));
				z0ZzZzbdh z0ZzZzbdh24 = new z0ZzZzbdh(p1.z0eek(), p1.z0rek());
				z0ZzZzbdh24.z0tek(z0ZzZzxdh110.z0rek());
				z0ZzZzbdh24.z0yek(z0ZzZzxdh110.z0tek());
				if (!p2)
				{
					p0.z0tek(z0oek(), z0ZzZzbdh24.z0oek(), z0ZzZzbdh24.z0pek() + z0ZzZzbdh24.z0iek() / 2f, z0ZzZzbdh24.z0oek() + z0ZzZzbdh24.z0uek(), z0ZzZzbdh24.z0pek() + z0ZzZzbdh24.z0iek() / 2f);
					p0.z0tek(z0oek(), z0ZzZzbdh24.z0oek() + z0ZzZzbdh24.z0uek() / 2f, z0ZzZzbdh24.z0pek(), z0ZzZzbdh24.z0oek() + z0ZzZzbdh24.z0uek() / 2f, z0ZzZzbdh24.z0pek() + z0ZzZzbdh24.z0iek());
				}
				return z0ZzZzxdh110;
			}
			string text38 = z0eek(z0iek().Value1, "1");
			string text39 = z0eek(z0iek().Value1, "2");
			string text40 = z0eek(z0iek().Value1, "3");
			string text41 = z0eek(z0iek().Value1, "4");
			float num109 = z0eek(text38, p0, p2: true);
			float num110 = z0eek(text39, p0, p2: true);
			float num111 = z0eek(text40, p0, p2: true);
			float num112 = z0eek(text41, p0, p2: true);
			z0ZzZzxdh z0ZzZzxdh111 = z0eek("A", p0);
			z0ZzZzxdh z0ZzZzxdh112 = z0eek("A", p0);
			z0ZzZzxdh result39 = z0ZzZzxdh.z0yek;
			result39.z0eek(Math.Max(Math.Max(num109, num110), Math.Max(num111, num112)) * 2.2f);
			result39.z0rek((z0ZzZzxdh111.z0tek() + z0ZzZzxdh112.z0tek()) * 1.1f);
			z0ZzZzxdh result40 = z0ZzZzxdh.z0yek;
			bool flag42 = false;
			bool flag43 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result40.z0eek(p1.z0uek());
				result40.z0rek(p1.z0iek());
				if (p1.z0uek() > result39.z0rek() && p1.z0iek() > result39.z0tek())
				{
					result40.z0eek(result39.z0rek());
					result40.z0rek(result39.z0tek());
					flag43 = false;
				}
				flag42 = true;
			}
			if (p2)
			{
				if ((result40.z0rek() < result39.z0rek() || result40.z0tek() < result39.z0tek()) && flag42)
				{
					return result40;
				}
				return result39;
			}
			object p115 = p0.z0bek();
			float num113 = 0f;
			float num114 = 0f;
			z0ZzZzbdh z0ZzZzbdh25;
			if (flag43)
			{
				z0ZzZzbdh25 = default(z0ZzZzbdh);
				z0ZzZzbdh25.z0tek(result39.z0rek());
				z0ZzZzbdh25.z0yek(result39.z0tek());
				if (result40.z0rek() > result39.z0rek())
				{
					num113 = 1f;
					z0ZzZzpdh p116 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result39.z0rek()) / 2f, 0f);
					z0ZzZzbdh25.z0eek(p116);
				}
				else
				{
					num113 = result40.z0rek() / result39.z0rek();
					z0ZzZzpdh p117 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh25.z0eek(p117);
				}
				if (result40.z0tek() > result39.z0tek())
				{
					num114 = 1f;
					z0ZzZzpdh p118 = new z0ZzZzpdh(z0ZzZzbdh25.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result39.z0tek()) / 2f);
					z0ZzZzbdh25.z0eek(p118);
				}
				else
				{
					num114 = result40.z0tek() / result39.z0tek();
					z0ZzZzpdh p119 = new z0ZzZzpdh(z0ZzZzbdh25.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh25.z0eek(p119);
				}
			}
			else
			{
				z0ZzZzbdh25 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result39.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result39.z0tek()) / 2f, result39.z0rek(), result39.z0tek());
				num113 = 1f;
				num114 = 1f;
			}
			p0.z0rek(z0ZzZzbdh25.z0oek() * (1f - num113), z0ZzZzbdh25.z0pek() * (1f - num114));
			p0.z0eek(num113, num114);
			float num115 = 0f;
			float num116 = 0f;
			if (z0iek().Count > 0 && z0lrk)
			{
				if (string.IsNullOrEmpty(text38) && string.IsNullOrEmpty(text39))
				{
					num116 = -1f * (z0ZzZzbdh25.z0iek() / 2f - 20f * num114);
				}
				else if (string.IsNullOrEmpty(text40) && string.IsNullOrEmpty(text41))
				{
					num116 = z0ZzZzbdh25.z0iek() / 2f - 20f * num114;
				}
				if (string.IsNullOrEmpty(text38) && string.IsNullOrEmpty(text40))
				{
					num115 = -1f * (z0ZzZzbdh25.z0uek() / 2f - 20f * num113);
				}
				else if (string.IsNullOrEmpty(text39) && string.IsNullOrEmpty(text41))
				{
					num115 = z0ZzZzbdh25.z0uek() / 2f - 20f * num113;
				}
				p0.z0rek(num115, num116);
			}
			if (!string.IsNullOrEmpty(text38))
			{
				List<string> list13 = z0rek(text38, "A,B,C,D,E");
				int num117 = 0;
				float num118 = 0f;
				foreach (string item15 in list13)
				{
					num117++;
					if (num117 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh113 = z0eek(item15, p0);
						p0.z0eek(item15, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh25.z0oek() + (z0ZzZzbdh25.z0uek() / 2f - num109) / 2f + num118, z0ZzZzbdh25.z0pek() + (z0ZzZzbdh25.z0iek() / 2f - z0ZzZzxdh111.z0tek()) / 2f, z0ZzZzxdh113.z0rek(), z0ZzZzxdh113.z0tek()), z0yek());
						num118 += z0ZzZzxdh113.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh114 = z0rek(item15, p0);
						p0.z0eek(item15, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh25.z0oek() + (z0ZzZzbdh25.z0uek() / 2f - num109) / 2f + num118, z0ZzZzbdh25.z0pek() + (z0ZzZzbdh25.z0iek() / 2f - z0ZzZzxdh111.z0tek()) / 2f, z0ZzZzxdh114.z0rek(), z0ZzZzxdh114.z0tek()), z0yek());
						num118 += z0ZzZzxdh114.z0rek();
					}
				}
			}
			if (!string.IsNullOrEmpty(text39))
			{
				List<string> list14 = z0rek(text39, "A,B,C,D,E");
				int num119 = 0;
				float num120 = 0f;
				foreach (string item16 in list14)
				{
					num119++;
					if (num119 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh115 = z0eek(item16, p0);
						p0.z0eek(item16, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh25.z0oek() + z0ZzZzbdh25.z0uek() / 2f + (z0ZzZzbdh25.z0uek() / 2f - num110) / 2f + num120, z0ZzZzbdh25.z0pek() + (z0ZzZzbdh25.z0iek() / 2f - z0ZzZzxdh111.z0tek()) / 2f, z0ZzZzxdh115.z0rek(), z0ZzZzxdh115.z0tek()), z0yek());
						num120 += z0ZzZzxdh115.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh116 = z0rek(item16, p0);
						p0.z0eek(item16, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh25.z0oek() + z0ZzZzbdh25.z0uek() / 2f + (z0ZzZzbdh25.z0uek() / 2f - num110) / 2f + num120, z0ZzZzbdh25.z0pek() + (z0ZzZzbdh25.z0iek() / 2f - z0ZzZzxdh111.z0tek()) / 2f, z0ZzZzxdh116.z0rek(), z0ZzZzxdh116.z0tek()), z0yek());
						num120 += z0ZzZzxdh116.z0rek();
					}
				}
			}
			if (!string.IsNullOrEmpty(text40))
			{
				List<string> list15 = z0rek(text40, "A,B,C,D,E");
				int num121 = 0;
				float num122 = 0f;
				foreach (string item17 in list15)
				{
					num121++;
					if (num121 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh117 = z0eek(item17, p0);
						p0.z0eek(item17, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh25.z0oek() + (z0ZzZzbdh25.z0uek() / 2f - num111) / 2f + num122, z0ZzZzbdh25.z0pek() + z0ZzZzbdh25.z0iek() / 2f + (z0ZzZzbdh25.z0iek() / 2f - z0ZzZzxdh112.z0tek()) / 2f, z0ZzZzxdh117.z0rek(), z0ZzZzxdh117.z0tek()), z0yek());
						num122 += z0ZzZzxdh117.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh118 = z0rek(item17, p0);
						p0.z0eek(item17, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh25.z0oek() + (z0ZzZzbdh25.z0uek() / 2f - num111) / 2f + num122, z0ZzZzbdh25.z0pek() + z0ZzZzbdh25.z0iek() / 2f + (z0ZzZzbdh25.z0iek() / 2f - z0ZzZzxdh112.z0tek()) / 2f, z0ZzZzxdh118.z0rek(), z0ZzZzxdh118.z0tek()), z0yek());
						num122 += z0ZzZzxdh118.z0rek();
					}
				}
			}
			if (!string.IsNullOrEmpty(text41))
			{
				List<string> list16 = z0rek(text41, "A,B,C,D,E");
				int num123 = 0;
				float num124 = 0f;
				foreach (string item18 in list16)
				{
					num123++;
					if (num123 % 2 == 1)
					{
						z0ZzZzxdh z0ZzZzxdh119 = z0eek(item18, p0);
						p0.z0eek(item18, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh25.z0oek() + z0ZzZzbdh25.z0uek() / 2f + (z0ZzZzbdh25.z0uek() / 2f - num112) / 2f + num124, z0ZzZzbdh25.z0pek() + z0ZzZzbdh25.z0iek() / 2f + (z0ZzZzbdh25.z0iek() / 2f - z0ZzZzxdh112.z0tek()) / 2f, z0ZzZzxdh119.z0rek(), z0ZzZzxdh119.z0tek()), z0yek());
						num124 += z0ZzZzxdh119.z0rek();
					}
					else
					{
						z0ZzZzxdh z0ZzZzxdh120 = z0rek(item18, p0);
						p0.z0eek(item18, z0rek(p0: false), z0oek(), new z0ZzZzbdh(z0ZzZzbdh25.z0oek() + z0ZzZzbdh25.z0uek() / 2f + (z0ZzZzbdh25.z0uek() / 2f - num112) / 2f + num124, z0ZzZzbdh25.z0pek() + z0ZzZzbdh25.z0iek() / 2f + (z0ZzZzbdh25.z0iek() / 2f - z0ZzZzxdh112.z0tek()) / 2f, z0ZzZzxdh120.z0rek(), z0ZzZzxdh120.z0tek()), z0yek());
						num124 += z0ZzZzxdh120.z0rek();
					}
				}
			}
			p0.z0tek(z0oek(), z0ZzZzbdh25.z0oek() - num115, z0ZzZzbdh25.z0pek() + z0ZzZzbdh25.z0iek() / 2f, z0ZzZzbdh25.z0oek() + z0ZzZzbdh25.z0uek() - num115, z0ZzZzbdh25.z0pek() + z0ZzZzbdh25.z0iek() / 2f);
			p0.z0tek(z0oek(), z0ZzZzbdh25.z0oek() + z0ZzZzbdh25.z0uek() / 2f, z0ZzZzbdh25.z0pek() - num116, z0ZzZzbdh25.z0oek() + z0ZzZzbdh25.z0uek() / 2f, z0ZzZzbdh25.z0pek() + z0ZzZzbdh25.z0iek() - num116);
			p0.z0eek(p115);
			if ((result40.z0rek() < result39.z0rek() || result40.z0tek() < result39.z0tek()) && flag42)
			{
				return result40;
			}
			return result39;
		}
		if (z0pek() == DCMedicalExpressionStyle.FourValues4)
		{
			z0ZzZzxdh z0ZzZzxdh121 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh z0ZzZzxdh122 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh z0ZzZzxdh123 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh z0ZzZzxdh124 = z0tek(z0iek().Value4, p0);
			z0ZzZzxdh result41 = z0ZzZzxdh.z0yek;
			result41.z0eek(Math.Max(Math.Max(z0ZzZzxdh121.z0rek(), z0ZzZzxdh122.z0rek()), Math.Max(z0ZzZzxdh123.z0rek(), z0ZzZzxdh124.z0rek())) * 2.1f);
			result41.z0rek((z0ZzZzxdh121.z0tek() + z0ZzZzxdh123.z0tek()) * 1.1f);
			z0ZzZzxdh result42 = z0ZzZzxdh.z0yek;
			bool flag44 = false;
			bool flag45 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result42.z0eek(p1.z0uek());
				result42.z0rek(p1.z0iek());
				if (p1.z0uek() > result41.z0rek() && p1.z0iek() > result41.z0tek())
				{
					result42.z0eek(result41.z0rek());
					result42.z0rek(result41.z0tek());
					flag45 = false;
				}
				flag44 = true;
			}
			if (p2)
			{
				if ((result42.z0rek() < result41.z0rek() || result42.z0tek() < result41.z0tek()) && flag44)
				{
					return result42;
				}
				return result41;
			}
			object p120 = p0.z0bek();
			float num125 = 0f;
			float num126 = 0f;
			z0ZzZzbdh z0ZzZzbdh26;
			if (flag45)
			{
				z0ZzZzbdh26 = default(z0ZzZzbdh);
				z0ZzZzbdh26.z0tek(result41.z0rek());
				z0ZzZzbdh26.z0yek(result41.z0tek());
				if (result42.z0rek() > result41.z0rek())
				{
					num125 = 1f;
					z0ZzZzpdh p121 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result41.z0rek()) / 2f, 0f);
					z0ZzZzbdh26.z0eek(p121);
				}
				else
				{
					num125 = result42.z0rek() / result41.z0rek();
					z0ZzZzpdh p122 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh26.z0eek(p122);
				}
				if (result42.z0tek() > result41.z0tek())
				{
					num126 = 1f;
					z0ZzZzpdh p123 = new z0ZzZzpdh(z0ZzZzbdh26.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result41.z0tek()) / 2f);
					z0ZzZzbdh26.z0eek(p123);
				}
				else
				{
					num126 = result42.z0tek() / result41.z0tek();
					z0ZzZzpdh p124 = new z0ZzZzpdh(z0ZzZzbdh26.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh26.z0eek(p124);
				}
			}
			else
			{
				z0ZzZzbdh26 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result41.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result41.z0tek()) / 2f, result41.z0rek(), result41.z0tek());
				num125 = 1f;
				num126 = 1f;
			}
			p0.z0rek(z0ZzZzbdh26.z0oek() * (1f - num125), z0ZzZzbdh26.z0pek() * (1f - num126));
			p0.z0eek(num125, num126);
			if (!string.IsNullOrEmpty(z0iek().Value1))
			{
				p0.z0eek(z0iek().Value1, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh26.z0oek() + (z0ZzZzbdh26.z0uek() / 2f - z0ZzZzxdh121.z0rek()) - 5f, z0ZzZzbdh26.z0pek() + (z0ZzZzbdh26.z0iek() / 2f - z0ZzZzxdh121.z0tek()) / 2f, z0ZzZzxdh121.z0rek(), z0ZzZzxdh121.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value2))
			{
				p0.z0eek(z0iek().Value2, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh26.z0oek() + z0ZzZzbdh26.z0uek() / 2f + (z0ZzZzbdh26.z0uek() / 2f - z0ZzZzxdh122.z0rek()) / 2f + 5f, z0ZzZzbdh26.z0pek() + (z0ZzZzbdh26.z0iek() / 2f - z0ZzZzxdh122.z0tek()) / 2f, z0ZzZzxdh122.z0rek(), z0ZzZzxdh122.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value3))
			{
				p0.z0eek(z0iek().Value3, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh26.z0oek() + (z0ZzZzbdh26.z0uek() / 2f - z0ZzZzxdh123.z0rek()) - 5f, z0ZzZzbdh26.z0pek() + z0ZzZzbdh26.z0iek() / 2f + (z0ZzZzbdh26.z0iek() / 2f - z0ZzZzxdh123.z0tek()) / 2f, z0ZzZzxdh123.z0rek(), z0ZzZzxdh123.z0tek()), z0rek());
			}
			if (!string.IsNullOrEmpty(z0iek().Value4))
			{
				p0.z0eek(z0iek().Value4, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh26.z0oek() + z0ZzZzbdh26.z0uek() / 2f + (z0ZzZzbdh26.z0uek() / 2f - z0ZzZzxdh124.z0rek()) / 2f + 5f, z0ZzZzbdh26.z0pek() + z0ZzZzbdh26.z0iek() / 2f + (z0ZzZzbdh26.z0iek() / 2f - z0ZzZzxdh124.z0tek()) / 2f, z0ZzZzxdh124.z0rek(), z0ZzZzxdh124.z0tek()), z0rek());
			}
			p0.z0tek(z0oek(), z0ZzZzbdh26.z0oek() + z0ZzZzbdh26.z0uek() / 2f, z0ZzZzbdh26.z0pek() + z0ZzZzbdh26.z0iek() / 2f, z0ZzZzbdh26.z0oek() + z0ZzZzbdh26.z0uek(), z0ZzZzbdh26.z0pek() + z0ZzZzbdh26.z0iek() / 2f);
			p0.z0eek(p120);
			if ((result42.z0rek() < result41.z0rek() || result42.z0tek() < result41.z0tek()) && flag44)
			{
				return result42;
			}
			return result41;
		}
		if (z0pek() == DCMedicalExpressionStyle.FourValues5)
		{
			z0ZzZzxdh z0ZzZzxdh125 = z0tek(z0iek().Value1, p0);
			z0ZzZzxdh z0ZzZzxdh126 = z0tek(z0iek().Value2, p0);
			z0ZzZzxdh z0ZzZzxdh127 = z0tek(z0iek().Value3, p0);
			z0ZzZzxdh z0ZzZzxdh128 = z0tek(z0iek().Value4, p0);
			z0ZzZzxdh z0ZzZzxdh129 = z0tek("#", p0);
			z0ZzZzxdh result43 = z0ZzZzxdh.z0yek;
			result43.z0eek(z0ZzZzxdh125.z0rek() + z0ZzZzxdh126.z0rek() + z0ZzZzxdh127.z0rek() + z0ZzZzxdh128.z0rek() + z0ZzZzxdh129.z0rek() * 11f);
			result43.z0rek(z0ZzZzxdh125.z0tek() * 1.1f);
			z0ZzZzxdh result44 = z0ZzZzxdh.z0yek;
			bool flag46 = false;
			bool flag47 = true;
			if (p1.z0uek() > 0f && p1.z0iek() > 0f)
			{
				result44.z0eek(p1.z0uek());
				result44.z0rek(p1.z0iek());
				if (p1.z0uek() > result43.z0rek() && p1.z0iek() > result43.z0tek())
				{
					result44.z0eek(result43.z0rek());
					result44.z0rek(result43.z0tek());
					flag47 = false;
				}
				flag46 = true;
			}
			if (p2)
			{
				if ((result44.z0rek() < result43.z0rek() || result44.z0tek() < result43.z0tek()) && flag46)
				{
					return result44;
				}
				return result43;
			}
			object p125 = p0.z0bek();
			float num127 = 0f;
			float num128 = 0f;
			z0ZzZzbdh z0ZzZzbdh27;
			if (flag47)
			{
				z0ZzZzbdh27 = default(z0ZzZzbdh);
				z0ZzZzbdh27.z0tek(result43.z0rek());
				z0ZzZzbdh27.z0yek(result43.z0tek());
				if (result44.z0rek() > result43.z0rek())
				{
					num127 = 1f;
					z0ZzZzpdh p126 = new z0ZzZzpdh(p1.z0oek() + (p1.z0uek() - result43.z0rek()) / 2f, 0f);
					z0ZzZzbdh27.z0eek(p126);
				}
				else
				{
					num127 = result44.z0rek() / result43.z0rek();
					z0ZzZzpdh p127 = new z0ZzZzpdh(p1.z0oek(), 0f);
					z0ZzZzbdh27.z0eek(p127);
				}
				if (result44.z0tek() > result43.z0tek())
				{
					num128 = 1f;
					z0ZzZzpdh p128 = new z0ZzZzpdh(z0ZzZzbdh27.z0eek().z0rek(), p1.z0pek() + (p1.z0iek() - result43.z0tek()) / 2f);
					z0ZzZzbdh27.z0eek(p128);
				}
				else
				{
					num128 = result44.z0tek() / result43.z0tek();
					z0ZzZzpdh p129 = new z0ZzZzpdh(z0ZzZzbdh27.z0eek().z0rek(), p1.z0pek());
					z0ZzZzbdh27.z0eek(p129);
				}
			}
			else
			{
				z0ZzZzbdh27 = new z0ZzZzbdh(p1.z0oek() + (p1.z0uek() - result43.z0rek()) / 2f, p1.z0pek() + (p1.z0iek() - result43.z0tek()) / 2f, result43.z0rek(), result43.z0tek());
				num127 = 1f;
				num128 = 1f;
			}
			p0.z0rek(z0ZzZzbdh27.z0oek() * (1f - num127), z0ZzZzbdh27.z0pek() * (1f - num128));
			p0.z0eek(num127, num128);
			string text42 = ((z0iek() != null && z0iek().Value1 != null && z0iek().Value1.Length > 0) ? z0iek().Value1 : string.Empty);
			string text43 = ((z0iek() != null && z0iek().Value2 != null && z0iek().Value2.Length > 0) ? z0iek().Value2 : string.Empty);
			string text44 = ((z0iek() != null && z0iek().Value3 != null && z0iek().Value3.Length > 0) ? z0iek().Value3 : string.Empty);
			string text45 = ((z0iek() != null && z0iek().Value4 != null && z0iek().Value4.Length > 0) ? z0iek().Value4 : string.Empty);
			string p130 = " " + text42 + " - " + text43 + " - " + text44 + " - " + text45 + " ";
			p0.z0eek(p130, z0tek(), z0oek(), new z0ZzZzbdh(z0ZzZzbdh27.z0oek(), z0ZzZzbdh27.z0pek(), z0ZzZzbdh27.z0uek(), z0ZzZzbdh27.z0iek()), z0rek());
			p0.z0eek(p125);
			if ((result44.z0rek() < result43.z0rek() || result44.z0tek() < result43.z0tek()) && flag46)
			{
				return result44;
			}
			return result43;
		}
		return z0ZzZzxdh.z0yek;
	}

	public z0ZzZznjh()
	{
	}

	private z0ZzZzxdh z0tek(string p0, z0ZzZzjpk p1)
	{
		z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzxdh.z0yek;
		z0ZzZzxdh2 = ((p0 != null && p0.Length != 0) ? ((z0pek() != DCMedicalExpressionStyle.DeciduousTeech && z0pek() != DCMedicalExpressionStyle.PermanentTeethBitmap) ? z0eek(p1, p0, z0tek(), 100000, z0rek()) : z0eek(p1, p0, z0tek(), 100000, z0yek())) : new z0ZzZzxdh(z0ZzZzrpk.z0eek(10, GraphicsUnit.Pixel, p1.z0vek()), z0eek(p1, z0tek())));
		z0ZzZzxdh2.z0rek(z0eek(p1, z0tek()) + (float)z0ZzZzrpk.z0eek(4, GraphicsUnit.Pixel, p1.z0vek()));
		if (z0pek() == DCMedicalExpressionStyle.ManyValues)
		{
			z0ZzZzxdh2 = z0eek(p1, p0, z0tek(), 100000, z0rek());
		}
		return z0ZzZzxdh2;
	}

	private static z0ZzZzlsh z0rek()
	{
		if (z0xek == null)
		{
			z0xek = new z0ZzZzlsh();
			z0xek.z0rek(StringAlignment.Center);
			z0xek.z0eek(StringAlignment.Center);
			z0xek.z0eek((z0ZzZzksh)4096);
		}
		return z0xek;
	}

	public z0ZzZzimk z0tek()
	{
		return z0mek;
	}

	public z0ZzZznjh(XTextNewMedicalExpressionElement p0)
	{
		z0vek = p0;
	}

	private List<string> z0eek(string p0)
	{
		List<string> list = new List<string>();
		char[] array = p0.ToCharArray();
		int num = 0;
		string text = string.Empty;
		char[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			char c = array2[i];
			int num2 = c;
			if ((num2 > 60 && num2 < 100 && num < 100 && num > 60) || ((num2 < 60 || num2 > 100) && (num > 100 || num < 60)))
			{
				text += c;
			}
			else if (!string.IsNullOrEmpty(text))
			{
				list.Add(text);
				text = c.ToString();
			}
			num = num2;
		}
		list.Add(text);
		return list;
	}

	private float z0eek(z0ZzZzjpk p0, z0ZzZzimk p1)
	{
		return z0ZzZzlcj.z0rek(p0.z0oek(), p1);
	}

	private static z0ZzZzlsh z0yek()
	{
		if (z0cek == null)
		{
			z0cek = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
			z0cek.z0rek(StringAlignment.Center);
			z0cek.z0eek(StringAlignment.Center);
			z0cek.z0eek((z0ZzZzksh)4096);
		}
		return z0cek;
	}

	public void z0eek(MedicalExpressionValueList p0)
	{
		z0krk = p0;
	}

	public void z0eek(DCMedicalExpressionStyle p0)
	{
		z0nek = p0;
	}

	public void z0eek(z0ZzZzimk p0)
	{
		z0mek = p0;
	}

	public bool z0uek()
	{
		return z0lrk;
	}

	private string z0eek(string p0, string p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return string.Empty;
		}
		string[] array = p0.Split(',');
		List<string> list = new List<string>();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.StartsWith(p1))
			{
				list.Add(text.Substring(1));
			}
		}
		if (list.Count == 0)
		{
			return string.Empty;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string[] array3 = new string[6] { "", "U", "V", "W", "X", "Y" };
		foreach (string item in list)
		{
			string text2 = null;
			string text3 = string.Empty;
			if (item.Length == 2)
			{
				text2 = item[0].ToString();
				if (!list.Contains(text2))
				{
					int num = int.Parse(text2);
					string text4 = array3[num];
					if (list.Contains(text4))
					{
						text2 = text4;
					}
				}
				text3 = item[1].ToString();
			}
			else if (item.Length == 1)
			{
				text2 = item;
			}
			if (text2 == null)
			{
				continue;
			}
			if (!dictionary.ContainsKey(text2))
			{
				dictionary.Add(text2, text3);
				continue;
			}
			string text5 = dictionary[text2];
			if (text3.Length > 0 && !text5.Contains(text3))
			{
				text5 += text3;
				dictionary[text2] = text5;
			}
		}
		string text6 = string.Empty;
		switch (p1)
		{
		case "1":
		case "3":
		{
			for (int num2 = 9; num2 >= 1; num2--)
			{
				string text9 = num2.ToString();
				string text10 = null;
				if (dictionary.ContainsKey(text9))
				{
					text10 = dictionary[text9];
				}
				else
				{
					text9 = string.Empty;
				}
				if (num2 <= 5 && dictionary.ContainsKey(array3[num2]))
				{
					if (text10 == null)
					{
						text10 = dictionary[array3[num2]];
					}
					text9 = array3[num2] + text9;
				}
				if (text9.Length > 0)
				{
					text6 = text6 + text9 + text10;
				}
			}
			break;
		}
		case "2":
		case "4":
		{
			for (int j = 1; j <= 9; j++)
			{
				string text7 = j.ToString();
				string text8 = null;
				if (dictionary.ContainsKey(text7))
				{
					text8 = dictionary[text7];
				}
				else
				{
					text7 = string.Empty;
				}
				if (j <= 5 && dictionary.ContainsKey(array3[j]))
				{
					if (text8 == null)
					{
						text8 = dictionary[array3[j]];
					}
					text7 = array3[j] + text7;
				}
				if (text7.Length > 0)
				{
					text6 = text6 + text7 + text8;
				}
			}
			break;
		}
		}
		return text6;
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		z0eek(p0, p1, p2: false);
	}

	private string z0rek(string p0)
	{
		if (z0iek().Count == 0)
		{
			return null;
		}
		char[] array = z0iek().z0eek("Value" + p0).ToCharArray();
		if (p0 == "1" || p0 == "3")
		{
			Array.Reverse(array);
		}
		List<char> list = new List<char>();
		for (int i = 0; i < array.Length; i++)
		{
			switch (array[i])
			{
			case '+':
			{
				string text = (i + 1).ToString();
				list.Add(text[0]);
				continue;
			}
			case '-':
				list.Add('-');
				continue;
			}
			if (array[i] == 'A' || array[i] == 'B' || array[i] == 'C' || array[i] == 'D' || array[i] == 'E')
			{
				list.Add(array[i]);
			}
		}
		if (p0 == "1" || p0 == "3")
		{
			list.Reverse();
		}
		return new string(list.ToArray());
	}

	private List<string> z0rek(string p0, string p1 = "A,B,C,D,E")
	{
		List<string> list = new List<string>();
		char[] array = p0.ToCharArray();
		string text = string.Empty;
		bool flag = true;
		char[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			char c = array2[i];
			bool num = char.IsNumber(c) || c == 'U' || c == 'V' || c == 'W' || c == 'X' || c == 'Y';
			if (num != flag)
			{
				if (text.Length > 0)
				{
					list.Add(text);
				}
				text = c.ToString();
			}
			else
			{
				text += c;
			}
			flag = num;
		}
		if (text.Length > 0)
		{
			list.Add(text);
		}
		List<string> list2 = new List<string>();
		if (p1 == null || p1.Split(',').Length != 5)
		{
			p1 = "A,B,C,D,E";
		}
		string[] array3 = p1.Split(',');
		for (int j = 0; j < list.Count; j++)
		{
			string text2 = list[j];
			text2 = text2.Replace("U", array3[0]).Replace("V", array3[1]).Replace("W", array3[2])
				.Replace("X", array3[3])
				.Replace("Y", array3[4]);
			if (text2.Contains("Z"))
			{
				text2 = text2.Replace("Z", "") + "▲";
			}
			list2.Add(text2);
		}
		return list2;
	}

	public MedicalExpressionValueList z0iek()
	{
		if (z0krk == null)
		{
			z0krk = new MedicalExpressionValueList();
		}
		return z0krk;
	}

	public void z0eek(int p0)
	{
		z0bek = p0;
	}

	public Color z0oek()
	{
		return z0zek;
	}

	public DCMedicalExpressionStyle z0pek()
	{
		return z0nek;
	}

	private string z0tek(string p0)
	{
		string[] array = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
		string text = "";
		if (p0 == "1" || p0 == "3")
		{
			int num = int.Parse(p0);
			for (int num2 = 8; num2 >= 1; num2--)
			{
				string p1 = "Value" + num + num2;
				string text2 = z0iek().z0eek(p1);
				string text3 = "";
				if (text2 != null && text2.Length > 0)
				{
					string text4 = text2;
					for (int i = 0; i < text4.Length; i++)
					{
						char c = text4[i];
						if (c >= '0' && c <= '9')
						{
							int num3 = int.Parse(c.ToString());
							string text5 = array[num3];
							text3 += text5;
						}
					}
					text = text + num2 + text3;
				}
			}
			return text;
		}
		int num4 = int.Parse(p0);
		for (int j = 1; j <= 8; j++)
		{
			string p2 = "Value" + num4 + j;
			string text6 = z0iek().z0eek(p2);
			string text7 = "";
			if (text6 == null || text6.Length <= 0)
			{
				continue;
			}
			string text4 = text6;
			for (int i = 0; i < text4.Length; i++)
			{
				char c2 = text4[i];
				if (c2 >= '0' && c2 <= '9')
				{
					int num5 = int.Parse(c2.ToString());
					string text8 = array[num5];
					text7 += text8;
				}
			}
			text = text + j + text7;
		}
		return text;
	}
}
