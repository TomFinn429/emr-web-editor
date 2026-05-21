using System;
using System.ComponentModel;
using System.IO;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzwmk : IDisposable
{
	private WatermarkType z0pek;

	private float z0nek;

	private bool z0bek;

	private Color z0vek = Color.White;

	public static readonly z0ZzZzadh z0cek = z0ZzZzadh.z0eek(new z0ZzZzrfh(1, 1));

	private int z0xek = 80;

	private bool z0zek = true;

	private string z0lrk;

	private z0ZzZzimk z0krk = new z0ZzZzimk();

	private float z0jrk = 1f;

	private bool z0hrk = true;

	private Color z0grk = Color.Black;

	private z0ZzZzpmk z0frk;

	[DefaultValue(true)]
	public bool PrintWatermark
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

	[z0ZzZzuqh]
	public Color Color
	{
		get
		{
			return z0grk;
		}
		set
		{
			z0grk = value;
		}
	}

	[DefaultValue(false)]
	public bool Repeat
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[z0ZzZzyqh]
	[DefaultValue(null)]
	public z0ZzZzpmk Image
	{
		get
		{
			return z0frk;
		}
		set
		{
			if (z0frk != value)
			{
				z0frk = value;
				z0uek();
			}
		}
	}

	[DefaultValue("black")]
	[z0ZzZzyqh]
	public string ColorValue
	{
		get
		{
			return z0ZzZzifh.z0eek(z0grk);
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				z0grk = Color.Black;
			}
			else
			{
				z0grk = z0ZzZzifh.z0eek(value);
			}
		}
	}

	[DefaultValue(1f)]
	public float DensityForRepeat
	{
		get
		{
			return z0jrk;
		}
		set
		{
			z0jrk = value;
		}
	}

	[DefaultValue(WatermarkType.None)]
	public WatermarkType Type
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

	[DefaultValue(true)]
	public bool ShowWatermark
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

	[DefaultValue(null)]
	public string Text
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

	[z0ZzZzyqh]
	[DefaultValue("white")]
	public string BackColorValue
	{
		get
		{
			return z0ZzZzifh.z0eek(z0vek);
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				z0vek = Color.White;
			}
			else
			{
				z0vek = z0ZzZzifh.z0eek(value);
			}
			z0uek();
		}
	}

	[DefaultValue(0f)]
	public float Angle
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	[DefaultValue(80)]
	public int Alpha
	{
		get
		{
			return z0xek;
		}
		set
		{
			if (value > 255)
			{
				value = 255;
			}
			if (value < 0)
			{
				value = 0;
			}
			z0xek = value;
		}
	}

	public z0ZzZzimk Font
	{
		get
		{
			if (z0krk == null)
			{
				z0krk = new z0ZzZzimk();
			}
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	[z0ZzZzuqh]
	public Color BackColor
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
			z0uek();
		}
	}

	private bool z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, z0ZzZzbdh p2)
	{
		bool result = false;
		p0.z0eek(p2);
		z0ZzZzbdh z0ZzZzbdh2 = p2;
		if (Angle != 0f)
		{
			z0ZzZzpdh z0ZzZzpdh2 = z0ZzZzjmk.z0rek(p2);
			float p3 = (float)Math.Sqrt(p2.z0uek() * p2.z0uek() + p2.z0iek() * p2.z0iek()) / 2f;
			float num = (float)(Math.Atan(p2.z0iek() / p2.z0uek()) * (180.0 / Math.PI));
			z0ZzZzpdh[] array = z0ZzZzjmk.z0eek(z0ZzZzpdh2, p2, (double)Angle * Math.PI / 180.0);
			z0ZzZzpdh[] array2 = z0ZzZzjmk.z0eek(p2);
			z0ZzZzpdh[] array3 = new z0ZzZzpdh[8];
			Array.Copy(array, array3, 4);
			Array.Copy(array2, 0, array3, 4, 4);
			z0ZzZzbdh2 = z0ZzZzjmk.z0eek(array3);
			z0eek(z0ZzZzpdh2, p3, Angle + 180f + num);
			p0.z0eek(Angle);
			z0ZzZzpdh[] array4 = new z0ZzZzpdh[1] { z0ZzZzpdh2 };
			p0.z0eek(array4);
			float num2 = array4[0].z0rek() - z0ZzZzpdh2.z0rek();
			float num3 = array4[0].z0tek() - z0ZzZzpdh2.z0tek();
			p0.z0rek(0f - num2, 0f - num3);
		}
		float num4 = z0yek();
		z0ZzZzrpk.z0eek(p0.z0vek(), GraphicsUnit.Pixel);
		if (Type == WatermarkType.Image)
		{
			z0ZzZzpmk image = Image;
			if (image != null && image.HasContent)
			{
				int num5 = z0ZzZzrpk.z0eek(image.Width, GraphicsUnit.Pixel, p0.z0vek());
				int num6 = z0ZzZzrpk.z0eek(image.Height, GraphicsUnit.Pixel, p0.z0vek());
				float num7 = 0f;
				for (float num8 = 0f; num8 < z0ZzZzbdh2.z0iek(); num8 += (float)num6 * num4)
				{
					for (float num9 = num7; num9 < z0ZzZzbdh2.z0uek(); num9 += (float)num5 * num4)
					{
						z0ZzZzbdh z0ZzZzbdh3 = new z0ZzZzbdh(num9 + z0ZzZzbdh2.z0tek() + ((float)num5 * num4 - (float)num5) / 2f, num8 + z0ZzZzbdh2.z0yek() + ((float)num6 * num4 - (float)num6) / 2f, num5, num6);
						z0ZzZzpdh[] p4 = z0ZzZzjmk.z0eek(z0ZzZzbdh3);
						p0.z0eek(p4);
						z0ZzZzbdh p5 = z0ZzZzjmk.z0eek(p4);
						if (p2.z0tek(p5))
						{
							result = true;
							p0.z0eek(image, z0ZzZzbdh3);
							using z0ZzZzzdh p6 = new z0ZzZzzdh(z0tek());
							p0.z0rek(p6, z0ZzZzbdh3);
						}
					}
					num7 += (float)(num5 / 3);
					if (num7 > 1f)
					{
						num7 -= (float)num5;
					}
				}
			}
		}
		else if (Type == WatermarkType.Text)
		{
			string text = Text;
			if (text != null && text.Length > 0)
			{
				z0ZzZzlsh z0ZzZzlsh2 = z0oek();
				z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek(text, Font, 10000, z0ZzZzlsh2);
				float num10 = 0f;
				Color p7 = Color.FromArgb(Alpha, Color);
				for (float num11 = 0f; num11 < z0ZzZzbdh2.z0iek(); num11 += z0ZzZzxdh2.z0tek() * num4)
				{
					for (float num12 = num10; num12 < z0ZzZzbdh2.z0uek(); num12 += z0ZzZzxdh2.z0rek() * num4)
					{
						z0ZzZzbdh z0ZzZzbdh4 = new z0ZzZzbdh(num12 + z0ZzZzbdh2.z0tek() + (z0ZzZzxdh2.z0rek() * num4 - z0ZzZzxdh2.z0rek()) / 2f, num11 + z0ZzZzbdh2.z0yek() + (z0ZzZzxdh2.z0tek() * num4 - z0ZzZzxdh2.z0tek()) / 2f, z0ZzZzxdh2.z0rek(), z0ZzZzxdh2.z0tek());
						z0ZzZzpdh[] p8 = z0ZzZzjmk.z0eek(z0ZzZzbdh4);
						p0.z0eek(p8);
						z0ZzZzbdh p9 = z0ZzZzjmk.z0eek(p8);
						if (p2.z0tek(p9))
						{
							result = true;
							p0.z0eek(text, Font, p7, z0ZzZzbdh4, z0ZzZzlsh2);
						}
					}
					num10 += z0ZzZzxdh2.z0rek() / 3f;
					if (num10 > 1f)
					{
						num10 -= z0ZzZzxdh2.z0rek();
					}
				}
				p0.z0eek(text, Font);
			}
		}
		if (Angle != 0f)
		{
			p0.z0zek();
		}
		p0.z0rek();
		return result;
	}

	private z0ZzZzpdh z0eek(z0ZzZzpdh p0, float p1, float p2)
	{
		float num = p0.z0rek();
		float num2 = p0.z0tek();
		p2 %= 360f;
		double num3 = Math.Tan((double)p2 * Math.PI / 180.0);
		double num4 = (double)p1 / Math.Sqrt(1.0 + num3 * num3);
		double num5 = num4 * num3;
		if (p2 > 90f && p2 < 270f)
		{
			return new z0ZzZzpdh(num - (float)num4, num2 - (float)num5);
		}
		return new z0ZzZzpdh(num + (float)num4, num2 + (float)num5);
	}

	public bool z0eek()
	{
		if (Type == WatermarkType.Text)
		{
			if (z0lrk != null)
			{
				return z0lrk.Trim().Length > 0;
			}
			return false;
		}
		return false;
	}

	public bool z0eek(z0ZzZzbdh p0, z0ZzZzjpk p1, z0ZzZzbdh p2)
	{
		if (p1 == null)
		{
			return false;
		}
		if (p0.z0uek() <= 0f || p0.z0iek() <= 0f)
		{
			return false;
		}
		if (!p0.z0tek(p2))
		{
			return false;
		}
		if (Type == WatermarkType.None)
		{
			return false;
		}
		if (Type == WatermarkType.Text)
		{
			if (!string.IsNullOrEmpty(Text))
			{
				if (Repeat)
				{
					z0eek(p1, p2, p0);
				}
				else
				{
					z0ZzZzxdh z0ZzZzxdh2 = p1.z0eek(Text, Font);
					float p3 = p0.z0oek() + p0.z0uek() / 2f - z0ZzZzxdh2.z0rek() / 2f;
					float p4 = p0.z0pek() + p0.z0iek() / 2f - z0ZzZzxdh2.z0tek() / 2f;
					z0eek(p1, p2, p3, p4);
				}
				return true;
			}
		}
		else if (Type == WatermarkType.Image)
		{
			z0ZzZzpmk image = Image;
			if (image != null && image.HasContent)
			{
				if (Repeat)
				{
					return z0eek(p1, p2, p0);
				}
				float num = (float)image.Width * 1f / (float)image.Height;
				z0ZzZzbdh p5 = p0;
				if (p0.z0uek() * 1f / p0.z0iek() > num)
				{
					p5.z0yek(p0.z0iek());
					p5.z0tek(p5.z0iek() * num);
					p5.z0eek(p0.z0tek() + (p0.z0uek() - p5.z0uek()) / 2f);
					p5.z0rek(p0.z0pek());
				}
				else
				{
					p5.z0tek(p0.z0uek());
					p5.z0yek(p5.z0uek() / num);
					p5.z0eek(p0.z0tek());
					p5.z0rek(p0.z0pek() + (p0.z0iek() - p5.z0iek()) / 2f);
				}
				if (p5.z0uek() > 1f && p5.z0iek() > 1f)
				{
					z0ZzZzbdh[] array = z0ZzZzdpk.z0eek(image.Width, image.Height, p5, p2);
					if (array != null)
					{
						z0ZzZzzdh z0ZzZzzdh2 = new z0ZzZzzdh(BackColor);
						z0ZzZzzdh z0ZzZzzdh3 = new z0ZzZzzdh(z0tek());
						if (array.Length == 1)
						{
							p1.z0rek(z0ZzZzzdh2, array[0]);
							p1.z0eek(image, array[0]);
							p1.z0rek(z0ZzZzzdh3, array[0]);
						}
						else
						{
							p1.z0rek(z0ZzZzzdh2, array[0]);
							p1.z0eek(image, array[0], array[1], GraphicsUnit.Pixel);
							p1.z0rek(z0ZzZzzdh3, array[0]);
						}
						z0ZzZzzdh2.Dispose();
						z0ZzZzzdh3.Dispose();
					}
					return true;
				}
			}
		}
		return false;
	}

	public bool z0rek()
	{
		if (Type == WatermarkType.None)
		{
			return false;
		}
		if (Type == WatermarkType.Text)
		{
			return !string.IsNullOrEmpty(Text);
		}
		if (Type == WatermarkType.Image)
		{
			if (z0frk != null)
			{
				return z0frk.HasContent;
			}
			return false;
		}
		return false;
	}

	public void Dispose()
	{
		z0uek();
	}

	private static string z0eek(string p0)
	{
		if (p0 == null)
		{
			return string.Empty;
		}
		return p0;
	}

	public void Clear()
	{
		z0xek = 80;
		z0nek = 0f;
		z0vek = Color.White;
		z0grk = Color.Black;
		z0krk = new z0ZzZzimk();
		z0frk = null;
		z0bek = false;
		z0uek();
		z0lrk = null;
		z0pek = WatermarkType.None;
	}

	public void z0eek(BinaryWriter p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("writer");
		}
		p0.Write(3242432);
		p0.Write((int)z0pek);
		p0.Write(z0eek(Font.Name));
		p0.Write(z0krk.Size);
		p0.Write((int)z0krk.Style);
		p0.Write(z0grk.ToArgb());
		p0.Write(z0vek.ToArgb());
		p0.Write(z0xek);
		p0.Write(z0eek(z0lrk));
		p0.Write(z0bek);
		p0.Write(z0jrk);
		if (z0frk != null && z0frk.HasContent)
		{
			byte[] imageData = z0frk.ImageData;
			p0.Write(imageData.Length);
			p0.Write(imageData);
		}
		else
		{
			p0.Write(0);
		}
		p0.Write(z0nek);
	}

	public Color z0tek()
	{
		return Color.FromArgb(220, BackColor);
	}

	public z0ZzZzwmk Clone()
	{
		z0ZzZzwmk z0ZzZzwmk2 = (z0ZzZzwmk)MemberwiseClone();
		if (z0frk != null)
		{
			z0ZzZzwmk2.z0frk = z0frk.Clone();
		}
		if (z0krk != null)
		{
			z0ZzZzwmk2.z0krk = z0krk.Clone();
		}
		return z0ZzZzwmk2;
	}

	private float z0yek()
	{
		float num = 1f;
		if ((double)DensityForRepeat > 0.1 && DensityForRepeat < 1f)
		{
			num = 1f / DensityForRepeat;
		}
		if (num > 4f)
		{
			num = 4f;
		}
		return num;
	}

	private bool z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, float p2, float p3)
	{
		z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek(Text, Font);
		z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(p2, p3, z0ZzZzxdh2.z0rek(), z0ZzZzxdh2.z0tek());
		z0ZzZzbdh z0ZzZzbdh3 = z0ZzZzbdh.z0xek;
		z0ZzZzpdh p4 = new z0ZzZzpdh(z0ZzZzbdh2.z0oek() + z0ZzZzbdh2.z0uek() / 2f, z0ZzZzbdh2.z0pek() + z0ZzZzbdh2.z0iek() / 2f);
		float p5 = (float)Math.Sqrt(z0ZzZzbdh2.z0uek() * z0ZzZzbdh2.z0uek() + z0ZzZzbdh2.z0iek() * z0ZzZzbdh2.z0iek()) / 2f;
		float num = (float)(Math.Atan(z0ZzZzbdh2.z0iek() / z0ZzZzbdh2.z0uek()) * (180.0 / Math.PI));
		z0ZzZzpdh z0ZzZzpdh2 = z0eek(p4, p5, Angle + 180f + num);
		z0ZzZzpdh z0ZzZzpdh3 = z0eek(p4, p5, Angle - num);
		z0ZzZzpdh z0ZzZzpdh4 = z0eek(p4, p5, Angle + num);
		z0ZzZzpdh z0ZzZzpdh5 = z0eek(p4, p5, Angle + 180f - num);
		z0ZzZznfh z0ZzZznfh2 = new z0ZzZznfh();
		z0ZzZznfh2.z0tek(new z0ZzZzpdh[4] { z0ZzZzpdh2, z0ZzZzpdh3, z0ZzZzpdh4, z0ZzZzpdh5 });
		if (z0ZzZznfh2.z0eek().z0tek(p1))
		{
			p0.z0rek(z0ZzZzpdh2.z0rek(), z0ZzZzpdh2.z0tek());
			p0.z0eek(Angle);
			p0.z0eek(Text, Font, Color.FromArgb(Alpha, Color), 0f, 0f);
			p0.z0zek();
			return true;
		}
		return false;
	}

	private void z0uek()
	{
	}

	public z0ZzZzwmk z0iek()
	{
		z0ZzZzwmk z0ZzZzwmk2 = (z0ZzZzwmk)MemberwiseClone();
		if (z0krk != null)
		{
			z0ZzZzwmk2.z0krk = z0krk.Clone();
		}
		return z0ZzZzwmk2;
	}

	private z0ZzZzlsh z0oek()
	{
		z0ZzZzlsh obj = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
		obj.z0rek(StringAlignment.Center);
		obj.z0eek(StringAlignment.Center);
		obj.z0eek((z0ZzZzksh)4096);
		return obj;
	}
}
