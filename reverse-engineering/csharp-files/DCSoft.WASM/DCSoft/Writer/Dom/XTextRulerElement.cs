using System;
using System.ComponentModel;
using System.Diagnostics;
using DCSoft.WinForms;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Ruler:{Name}")]
[z0ZzZziqh("XTextRuler")]
public class XTextRulerElement : XTextObjectElement
{
	private new ResizeableType z0rek = ResizeableType.WidthAndHeight;

	private new int z0iek;

	private new string z0oek = "#0.00";

	private new bool z0pek;

	[NonSerialized]
	[z0ZzZzuqh]
	internal new bool z0bek;

	private new z0ZzZzimk z0vek;

	[NonSerialized]
	[z0ZzZzuqh]
	internal new float z0cek;

	private new z0ZzZzimk z0xek = new z0ZzZzimk();

	private new Color z0zek = Color.Black;

	private new int z0lrk = 10;

	private new float z0krk = 1300f;

	private new ScalePropertyList z0jrk;

	private new float z0hrk = 220f;

	private new z0ZzZzimk z0frk = new z0ZzZzimk();

	private new float z0drk;

	public z0ZzZzimk Font
	{
		get
		{
			return z0frk;
		}
		set
		{
			z0frk = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZztqh]
	public Color LineColor
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	[z0ZzZzuqh]
	public bool Crosswise
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZztqh]
	public override float Width
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	[z0ZzZztqh]
	[DefaultValue(null)]
	public int MinScale
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZztqh]
	public string Precision
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[z0ZzZztqh]
	[DefaultValue(null)]
	public int MaxScale
	{
		get
		{
			return z0lrk;
		}
		set
		{
			z0lrk = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZztqh]
	public override float Height
	{
		get
		{
			return z0hrk;
		}
		set
		{
			z0hrk = value;
		}
	}

	[z0ZzZztqh]
	[DefaultValue(null)]
	public float RulerValue
	{
		get
		{
			return z0drk;
		}
		set
		{
			z0drk = value;
		}
	}

	[z0ZzZzrqh("Scale", typeof(ScaleProperty))]
	[DefaultValue(null)]
	public ScalePropertyList Scales
	{
		get
		{
			if (z0jrk == null)
			{
				z0jrk = new ScalePropertyList();
			}
			return z0jrk;
		}
		set
		{
			z0jrk = value;
		}
	}

	public override ResizeableType z0wt()
	{
		if (z0yek())
		{
			return ResizeableType.FixSize;
		}
		return z0rek;
	}

	public override void z0et(ResizeableType p0)
	{
		z0rek = p0;
	}

	public override float z0ut()
	{
		return Width + z0pt();
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		Color red = Color.Red;
		base.z0vw(p0);
		Color p1 = z0aek().z0bek;
		z0ZzZzxdh z0ZzZzxdh = p0.z0eek("▲", z0xek);
		z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek(z0drk.ToString(), z0xek);
		z0ZzZzxdh z0ZzZzxdh3 = p0.z0eek("8", z0vek);
		float num = z0ZzZzxdh2.z0tek() + z0ZzZzxdh.z0tek() + z0ZzZzxdh3.z0tek() + 6f + 60f;
		float num2 = 10f + num;
		float num3 = (z0si() - num2) / 2f + 5f;
		int num4 = z0lrk - z0iek;
		float num5 = (float)((double)(z0ork() - 10f) / ((double)num4 + 0.8));
		float num6 = (float)(5.0 + 0.4 * (double)num5);
		float num7 = num3 + z0ZzZzxdh2.z0tek() + 10f + 2f;
		float num8 = num7 + 20f;
		float num9 = num7 + 50f + 2f;
		float num10 = num6 - z0ZzZzxdh3.z0rek() / 2f;
		float num11 = num9 + z0ZzZzxdh.z0tek() + 2f;
		float num12 = num3;
		float num13 = num12 + z0ZzZzxdh2.z0tek() + 2f;
		z0ZzZzudh z0ZzZzudh = new z0ZzZzudh(z0zek);
		z0ZzZzudh p2 = z0ZzZzidh.z0cek;
		if (z0eek())
		{
			float num14 = (float)((double)z0ork() * 0.9);
			for (int i = 0; i < Scales.Count; i++)
			{
				ScaleProperty scaleProperty = Scales[i];
				z0ZzZzudh.z0eek(6f);
				if (i > 0)
				{
					if (z0bek)
					{
						float num15 = (z0cek - (float)((double)z0ork() * 0.05) - z0dyk().z0tek()) / num14;
						if (num15 >= 0f && num15 <= 1f)
						{
							if (num15 <= Scales[i - 1].ScaleRate && num15 >= Scales[i].ScaleRate)
							{
								z0drk = float.Parse(((Scales[i - 1].Value - Scales[i].Value) * ((num15 - Scales[i].ScaleRate) / (Scales[i - 1].ScaleRate - Scales[i].ScaleRate)) + Scales[i].Value).ToString(z0oek));
								float num16 = (z0drk - Scales[i].Value) / (Scales[i - 1].Value - Scales[i].Value) * (Scales[i - 1].ScaleRate - Scales[i].ScaleRate) + Scales[i].ScaleRate;
								p0.z0gyk.z0eek("▲", z0xek, Color.Red, z0dyk().z0tek() + num16 * num14 + (float)((double)z0ork() * 0.05) - z0ZzZzxdh.z0rek() / 2f, z0dyk().z0yek() + num9 + z0ZzZzudh.z0oek());
								p0.z0gyk.z0eek(p2, z0dyk().z0tek() + num16 * num14 + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num13, z0dyk().z0tek() + num16 * num14 + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num13 + 60f);
								p0.z0gyk.z0eek(z0drk.ToString(), z0xek, red, z0dyk().z0tek() + num16 * num14 + (float)((double)z0ork() * 0.05) - p0.z0eek(z0drk.ToString(), z0xek).z0rek() / 2f, z0dyk().z0yek() + num12);
							}
							if (num15 <= Scales[i].ScaleRate && num15 >= Scales[i - 1].ScaleRate)
							{
								z0drk = float.Parse(((Scales[i].Value - Scales[i - 1].Value) * ((num15 - Scales[i - 1].ScaleRate) / (Scales[i].ScaleRate - Scales[i - 1].ScaleRate)) + Scales[i - 1].Value).ToString(z0oek));
								float num16 = (z0drk - Scales[i - 1].Value) / (Scales[i].Value - Scales[i - 1].Value) * (Scales[i].ScaleRate - Scales[i - 1].ScaleRate) + Scales[i - 1].ScaleRate;
								p0.z0gyk.z0eek("▲", z0xek, Color.Red, z0dyk().z0tek() + num16 * num14 + (float)((double)z0ork() * 0.05) - z0ZzZzxdh.z0rek() / 2f, z0dyk().z0yek() + num9 + z0ZzZzudh.z0oek());
								p0.z0gyk.z0eek(p2, z0dyk().z0tek() + num16 * num14 + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num13, z0dyk().z0tek() + num16 * num14 + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num13 + 60f);
								p0.z0gyk.z0eek(z0drk.ToString(), z0xek, red, z0dyk().z0tek() + num16 * scaleProperty.ScaleRate + (float)((double)z0ork() * 0.05) - p0.z0eek(z0drk.ToString(), z0xek).z0rek() / 2f, z0dyk().z0yek() + num12);
							}
						}
					}
					else
					{
						if (RulerValue <= Scales[i - 1].Value && RulerValue >= Scales[i].Value)
						{
							float num17 = (RulerValue - Scales[i - 1].Value) / (Scales[i].Value - Scales[i - 1].Value) * (Scales[i].ScaleRate - Scales[i - 1].ScaleRate) + Scales[i - 1].ScaleRate;
							p0.z0gyk.z0eek("▲", z0xek, Color.Red, z0dyk().z0tek() + num17 * num14 + (float)((double)z0ork() * 0.05) - z0ZzZzxdh.z0rek() / 2f, z0dyk().z0yek() + num9 + z0ZzZzudh.z0oek());
							p0.z0gyk.z0eek(RulerValue.ToString(), z0xek, red, z0dyk().z0tek() + num17 * num14 + (float)((double)z0ork() * 0.05) - p0.z0eek(RulerValue.ToString(), z0xek).z0rek() / 2f, z0dyk().z0yek() + num12);
							p0.z0gyk.z0eek(p2, z0dyk().z0tek() + num17 * num14 + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num13, z0dyk().z0tek() + num17 * num14 + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num13 + 60f);
						}
						if (RulerValue >= Scales[i - 1].Value && RulerValue <= Scales[i].Value)
						{
							float num18 = (RulerValue - Scales[i - 1].Value) / (Scales[i].Value - Scales[i - 1].Value) * (Scales[i].ScaleRate - Scales[i - 1].ScaleRate) + Scales[i - 1].ScaleRate;
							p0.z0gyk.z0eek("▲", z0xek, Color.Red, z0dyk().z0tek() + num18 * num14 + (float)((double)z0ork() * 0.05) - z0ZzZzxdh.z0rek() / 2f, z0dyk().z0yek() + num9 + z0ZzZzudh.z0oek());
							p0.z0gyk.z0eek(RulerValue.ToString(), z0xek, red, z0dyk().z0tek() + num18 * num14 + (float)((double)z0ork() * 0.05) - p0.z0eek(RulerValue.ToString(), z0xek).z0rek() / 2f, z0dyk().z0yek() + num12);
							p0.z0gyk.z0eek(p2, z0dyk().z0tek() + num18 * num14 + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num13, z0dyk().z0tek() + num18 * num14 + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num13 + 60f);
						}
					}
				}
				p0.z0gyk.z0eek(z0ZzZzudh, z0dyk().z0tek() + num14 * scaleProperty.ScaleRate + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num8, z0dyk().z0tek() + num14 * scaleProperty.ScaleRate + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num8 + 30f);
				p0.z0gyk.z0eek(Scales[i].Value.ToString(), z0xek, p1, z0dyk().z0tek() + num14 * scaleProperty.ScaleRate + (float)((double)z0ork() * 0.05) - p0.z0eek(Scales[i].Value.ToString(), z0xek).z0rek() / 2f, z0dyk().z0yek() + num11);
			}
			p0.z0gyk.z0eek(z0ZzZzudh, z0dyk().z0tek() + (float)((double)z0ork() * 0.05), z0dyk().z0yek() + num7 + 50f, z0dyk().z0tek() + (float)((double)z0ork() * 0.05) + num14, z0dyk().z0yek() + num7 + 50f);
			z0bek = false;
		}
		else
		{
			for (int j = 0; j <= num4; j++)
			{
				z0ZzZzudh.z0eek(6f);
				p0.z0gyk.z0eek(z0ZzZzudh, z0dyk().z0tek() + num6 + (float)j * num5, z0dyk().z0yek() + num8, z0dyk().z0tek() + num6 + (float)j * num5, z0dyk().z0yek() + num8 + 30f);
			}
			z0ZzZzudh.z0eek(6f);
			p0.z0gyk.z0eek(z0ZzZzudh, z0dyk().z0tek() + num6, z0dyk().z0yek() + num7 + 50f, z0dyk().z0tek() + num6 + num5 * (float)num4, z0dyk().z0yek() + num7 + 50f);
			float num19 = (z0drk - (float)z0iek) / (float)(z0lrk - z0iek);
			float num20 = num5 * (float)num4 * num19;
			float num21 = num6 + num20 - z0ZzZzxdh.z0rek() / 2f;
			if (z0bek)
			{
				float num22 = (float)z0iek + (float)(z0lrk - z0iek) * ((z0cek - num6 - z0dyk().z0tek()) / (num5 * (float)num4));
				float num23 = (float.Parse(num22.ToString(z0oek)) - (float)z0iek) / (float)(z0lrk - z0iek);
				if (num22 >= (float)z0iek && num22 <= (float)z0lrk)
				{
					p0.z0gyk.z0eek("▲", z0xek, red, z0dyk().z0tek() + num6 + num23 * num5 * (float)num4 - z0ZzZzxdh.z0rek() / 2f, z0dyk().z0yek() + num9 + z0ZzZzudh.z0oek());
					z0ZzZzudh.z0eek(6f);
					z0ZzZzudh.z0eek(red);
					p0.z0gyk.z0eek(z0ZzZzudh, z0dyk().z0tek() + num6 + num23 * num5 * (float)num4, z0dyk().z0yek() + num13, z0dyk().z0tek() + num6 + num23 * num5 * (float)num4, z0dyk().z0yek() + num13 + 60f);
					z0drk = float.Parse(num22.ToString(z0oek));
					p0.z0gyk.z0eek(z0drk.ToString(), z0xek, red, z0dyk().z0tek() + num6 + num23 * num5 * (float)num4 - p0.z0eek(z0drk.ToString(), z0xek).z0rek() / 2f, z0dyk().z0yek() + num12);
				}
			}
			else
			{
				p0.z0gyk.z0eek("▲", z0xek, red, z0dyk().z0tek() + num21, z0dyk().z0yek() + num9 + z0ZzZzudh.z0oek());
				float num24 = num6 + num20;
				float num25 = num6 + num20 - z0ZzZzxdh2.z0rek() / 2f;
				p0.z0gyk.z0eek(z0drk.ToString(), z0xek, red, z0dyk().z0tek() + num25, z0dyk().z0yek() + num12);
				z0ZzZzudh.z0eek(6f);
				z0ZzZzudh.z0eek(red);
				p0.z0gyk.z0eek(z0ZzZzudh, z0dyk().z0tek() + num24, z0dyk().z0yek() + num13, z0dyk().z0tek() + num24, z0dyk().z0yek() + num13 + 60f);
			}
			int num26 = 0;
			for (int k = z0iek; k <= z0lrk; k++)
			{
				p0.z0gyk.z0eek(k.ToString(), z0vek, p1, z0dyk().z0tek() + num10 + (float)num26 * num5, z0dyk().z0yek() + num11);
				num26++;
			}
			z0bek = false;
		}
		z0ZzZzudh.Dispose();
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		base.z0rt(p0);
		if (!z0eek())
		{
			if (MaxScale < MinScale)
			{
				MinScale = 0;
				MaxScale = 10;
			}
			else if (RulerValue < (float)MinScale || RulerValue > (float)MaxScale)
			{
				RulerValue = MinScale;
			}
		}
	}

	public XTextRulerElement()
	{
		z0vek = new z0ZzZzimk();
		z0xek = new z0ZzZzimk();
		z0xek.Bold = true;
		Crosswise = true;
	}

	internal new bool z0eek()
	{
		if (z0jrk != null)
		{
			return z0jrk.Count > 1;
		}
		return false;
	}
}
