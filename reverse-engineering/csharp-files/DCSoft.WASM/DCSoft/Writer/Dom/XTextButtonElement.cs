using System;
using System.ComponentModel;
using System.Diagnostics;
using DCSoft.WinForms;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Button:ID={ID} , Text={Text}")]
public class XTextButtonElement : XTextObjectElement, z0ZzZzlzj
{
	public delegate bool z0smk(XTextButtonElement button, z0ZzZzvxj args);

	private class z0ppk
	{
		private static readonly z0ZzZzrfh z0cek = new z0ZzZzrfh(new byte[630]
		{
			66, 77, 118, 2, 0, 0, 0, 0, 0, 0,
			54, 0, 0, 0, 40, 0, 0, 0, 10, 0,
			0, 0, 18, 0, 0, 0, 1, 0, 24, 0,
			0, 0, 0, 0, 64, 2, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 245, 217, 167, 245, 217, 167,
			245, 217, 167, 245, 217, 167, 245, 217, 167, 245,
			217, 167, 245, 217, 167, 245, 217, 167, 245, 217,
			167, 245, 217, 167, 0, 0, 246, 219, 169, 246,
			219, 169, 246, 219, 169, 246, 219, 169, 246, 219,
			169, 246, 219, 169, 246, 219, 169, 246, 219, 169,
			246, 219, 169, 246, 219, 169, 0, 0, 247, 220,
			172, 247, 220, 172, 247, 220, 172, 247, 220, 172,
			247, 220, 172, 247, 220, 172, 247, 220, 172, 247,
			220, 172, 247, 220, 172, 247, 220, 172, 0, 0,
			248, 222, 175, 248, 222, 175, 248, 222, 175, 248,
			222, 175, 248, 222, 175, 248, 222, 175, 248, 222,
			175, 248, 222, 175, 248, 222, 175, 248, 222, 175,
			0, 0, 249, 224, 178, 249, 224, 178, 249, 224,
			178, 249, 224, 178, 249, 224, 178, 249, 224, 178,
			249, 224, 178, 249, 224, 178, 249, 224, 178, 249,
			224, 178, 0, 0, 250, 226, 181, 250, 226, 181,
			250, 226, 181, 250, 226, 181, 250, 226, 181, 250,
			226, 181, 250, 226, 181, 250, 226, 181, 250, 226,
			181, 250, 226, 181, 0, 0, 251, 227, 185, 251,
			227, 185, 251, 227, 185, 251, 227, 185, 251, 227,
			185, 251, 227, 185, 251, 227, 185, 251, 227, 185,
			251, 227, 185, 251, 227, 185, 0, 0, 252, 229,
			188, 252, 229, 188, 252, 229, 188, 252, 229, 188,
			252, 229, 188, 252, 229, 188, 252, 229, 188, 252,
			229, 188, 252, 229, 188, 252, 229, 188, 0, 0,
			253, 230, 190, 253, 230, 190, 253, 230, 190, 253,
			230, 190, 253, 230, 190, 253, 230, 190, 253, 230,
			190, 253, 230, 190, 253, 230, 190, 253, 230, 190,
			0, 0, 252, 240, 217, 252, 240, 217, 252, 240,
			217, 252, 240, 217, 252, 240, 217, 252, 240, 217,
			252, 240, 217, 252, 240, 217, 252, 240, 217, 252,
			240, 217, 0, 0, 252, 241, 220, 252, 241, 220,
			252, 241, 220, 252, 241, 220, 252, 241, 220, 252,
			241, 220, 252, 241, 220, 252, 241, 220, 252, 241,
			220, 252, 241, 220, 0, 0, 252, 242, 222, 252,
			242, 222, 252, 242, 222, 252, 242, 222, 252, 242,
			222, 252, 242, 222, 252, 242, 222, 252, 242, 222,
			252, 242, 222, 252, 242, 222, 0, 0, 252, 243,
			225, 252, 243, 225, 252, 243, 225, 252, 243, 225,
			252, 243, 225, 252, 243, 225, 252, 243, 225, 252,
			243, 225, 252, 243, 225, 252, 243, 225, 0, 0,
			252, 244, 228, 252, 244, 228, 252, 244, 228, 252,
			244, 228, 252, 244, 228, 252, 244, 228, 252, 244,
			228, 252, 244, 228, 252, 244, 228, 252, 244, 228,
			0, 0, 253, 245, 230, 253, 245, 230, 253, 245,
			230, 253, 245, 230, 253, 245, 230, 253, 245, 230,
			253, 245, 230, 253, 245, 230, 253, 245, 230, 253,
			245, 230, 0, 0, 253, 246, 232, 253, 246, 232,
			253, 246, 232, 253, 246, 232, 253, 246, 232, 253,
			246, 232, 253, 246, 232, 253, 246, 232, 253, 246,
			232, 253, 246, 232, 0, 0, 253, 246, 234, 253,
			246, 234, 253, 246, 234, 253, 246, 234, 253, 246,
			234, 253, 246, 234, 253, 246, 234, 253, 246, 234,
			253, 246, 234, 253, 246, 234, 0, 0, 254, 253,
			250, 254, 253, 250, 254, 253, 250, 254, 253, 250,
			254, 253, 250, 254, 253, 250, 254, 253, 250, 254,
			253, 250, 254, 253, 250, 254, 253, 250, 0, 0
		});

		private z0ZzZzpmk z0xek;

		private Color z0zek = Color.Empty;

		private bool z0lrk;

		private z0ZzZzpmk z0krk;

		private Color z0jrk = z0ZzZzhsh.z0eek;

		private bool z0hrk = true;

		private static readonly z0ZzZzrfh z0grk = new z0ZzZzrfh(new byte[126]
		{
			66, 77, 126, 0, 0, 0, 0, 0, 0, 0,
			54, 0, 0, 0, 40, 0, 0, 0, 1, 0,
			0, 0, 18, 0, 0, 0, 1, 0, 24, 0,
			0, 0, 0, 0, 72, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 207, 207, 207, 0, 209, 209,
			209, 0, 210, 210, 210, 0, 212, 212, 212, 0,
			214, 214, 214, 0, 216, 216, 216, 0, 218, 218,
			218, 0, 219, 219, 219, 0, 221, 221, 221, 0,
			235, 235, 235, 0, 236, 236, 236, 0, 237, 237,
			237, 0, 239, 239, 239, 0, 240, 240, 240, 0,
			241, 241, 241, 0, 242, 242, 242, 0, 242, 242,
			242, 0, 252, 252, 252, 0
		});

		private z0mpk z0frk;

		private XTextButtonElement z0drk;

		private static readonly z0ZzZzrfh z0srk = new z0ZzZzrfh(new byte[630]
		{
			66, 77, 118, 2, 0, 0, 0, 0, 0, 0,
			54, 0, 0, 0, 40, 0, 0, 0, 10, 0,
			0, 0, 18, 0, 0, 0, 1, 0, 24, 0,
			0, 0, 0, 0, 64, 2, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 219, 179, 104, 219, 179, 104,
			219, 179, 104, 219, 179, 104, 219, 179, 104, 219,
			179, 104, 219, 179, 104, 219, 179, 104, 219, 179,
			104, 219, 179, 104, 0, 0, 221, 182, 109, 221,
			182, 109, 221, 182, 109, 221, 182, 109, 221, 182,
			109, 221, 182, 109, 221, 182, 109, 221, 182, 109,
			221, 182, 109, 221, 182, 109, 0, 0, 223, 185,
			114, 223, 185, 114, 223, 185, 114, 223, 185, 114,
			223, 185, 114, 223, 185, 114, 223, 185, 114, 223,
			185, 114, 223, 185, 114, 223, 185, 114, 0, 0,
			226, 189, 120, 226, 189, 120, 226, 189, 120, 226,
			189, 120, 226, 189, 120, 226, 189, 120, 226, 189,
			120, 226, 189, 120, 226, 189, 120, 226, 189, 120,
			0, 0, 229, 194, 127, 229, 194, 127, 229, 194,
			127, 229, 194, 127, 229, 194, 127, 229, 194, 127,
			229, 194, 127, 229, 194, 127, 229, 194, 127, 229,
			194, 127, 0, 0, 232, 198, 134, 232, 198, 134,
			232, 198, 134, 232, 198, 134, 232, 198, 134, 232,
			198, 134, 232, 198, 134, 232, 198, 134, 232, 198,
			134, 232, 198, 134, 0, 0, 235, 202, 140, 235,
			202, 140, 235, 202, 140, 235, 202, 140, 235, 202,
			140, 235, 202, 140, 235, 202, 140, 235, 202, 140,
			235, 202, 140, 235, 202, 140, 0, 0, 237, 206,
			147, 237, 206, 147, 237, 206, 147, 237, 206, 147,
			237, 206, 147, 237, 206, 147, 237, 206, 147, 237,
			206, 147, 237, 206, 147, 237, 206, 147, 0, 0,
			239, 209, 152, 239, 209, 152, 239, 209, 152, 239,
			209, 152, 239, 209, 152, 239, 209, 152, 239, 209,
			152, 239, 209, 152, 239, 209, 152, 239, 209, 152,
			0, 0, 246, 229, 196, 246, 229, 196, 246, 229,
			196, 246, 229, 196, 246, 229, 196, 246, 229, 196,
			246, 229, 196, 246, 229, 196, 246, 229, 196, 246,
			229, 196, 0, 0, 247, 231, 201, 247, 231, 201,
			247, 231, 201, 247, 231, 201, 247, 231, 201, 247,
			231, 201, 247, 231, 201, 247, 231, 201, 247, 231,
			201, 247, 231, 201, 0, 0, 248, 233, 206, 248,
			233, 206, 248, 233, 206, 248, 233, 206, 248, 233,
			206, 248, 233, 206, 248, 233, 206, 248, 233, 206,
			248, 233, 206, 248, 233, 206, 0, 0, 249, 236,
			211, 249, 236, 211, 249, 236, 211, 249, 236, 211,
			249, 236, 211, 249, 236, 211, 249, 236, 211, 249,
			236, 211, 249, 236, 211, 249, 236, 211, 0, 0,
			250, 238, 216, 250, 238, 216, 250, 238, 216, 250,
			238, 216, 250, 238, 216, 250, 238, 216, 250, 238,
			216, 250, 238, 216, 250, 238, 216, 250, 238, 216,
			0, 0, 250, 240, 221, 250, 240, 221, 250, 240,
			221, 250, 240, 221, 250, 240, 221, 250, 240, 221,
			250, 240, 221, 250, 240, 221, 250, 240, 221, 250,
			240, 221, 0, 0, 251, 242, 225, 251, 242, 225,
			251, 242, 225, 251, 242, 225, 251, 242, 225, 251,
			242, 225, 251, 242, 225, 251, 242, 225, 251, 242,
			225, 251, 242, 225, 0, 0, 252, 244, 229, 252,
			244, 229, 252, 244, 229, 252, 244, 229, 252, 244,
			229, 252, 244, 229, 252, 244, 229, 252, 244, 229,
			252, 244, 229, 252, 244, 229, 0, 0, 252, 244,
			229, 252, 244, 229, 252, 244, 229, 252, 244, 229,
			252, 244, 229, 252, 244, 229, 252, 244, 229, 252,
			244, 229, 252, 244, 229, 252, 244, 229, 0, 0
		});

		private string z0ark;

		private z0ZzZzbdh z0qrk = z0ZzZzbdh.z0xek;

		private z0ZzZzimk z0wrk = new z0ZzZzimk();

		private z0ZzZzpmk z0erk;

		public z0ZzZzpmk z0eek()
		{
			return z0xek;
		}

		public void z0eek(bool p0)
		{
			z0hrk = p0;
		}

		public string z0rek()
		{
			return z0ark;
		}

		public void z0eek(z0ZzZzjpk p0)
		{
			z0ZzZzpmk z0ZzZzpmk = null;
			if (z0pek() == z0mpk.z0eek)
			{
				z0ZzZzpmk = z0iek();
			}
			else if (z0pek() == z0mpk.z0tek)
			{
				z0ZzZzpmk = z0eek();
			}
			else if (z0pek() == z0mpk.z0rek)
			{
				z0ZzZzpmk = z0tek();
			}
			if (z0ZzZzpmk != null && z0ZzZzpmk.HasContent)
			{
				p0.z0eek(z0ZzZzpmk.Value, z0bek());
				return;
			}
			float num = z0ZzZzrpk.z0eek(5, GraphicsUnit.Pixel, p0.z0vek());
			if (z0vek().A == 0)
			{
				if (z0nek())
				{
					z0ZzZzrfh p1 = null;
					if (z0pek() == z0mpk.z0eek)
					{
						p1 = z0grk;
					}
					else if (z0pek() == z0mpk.z0tek)
					{
						p1 = z0srk;
					}
					else if (z0pek() == z0mpk.z0rek)
					{
						p1 = z0cek;
					}
					p0.z0rek(z0ZzZzjsh.z0eek, z0qrk);
					InterpolationMode p2 = p0.z0nek_jiejie20260327142557();
					z0ZzZzfdh p3 = p0.z0tek();
					p0.z0eek(InterpolationMode.NearestNeighbor);
					p0.z0eek((z0ZzZzfdh)3);
					p0.z0eek(p1, z0qrk);
					p0.z0eek((z0ZzZzfdh)4);
					p0.z0eek(p1, z0qrk);
					p0.z0eek(p2);
					p0.z0eek(p3);
				}
				else
				{
					p0.z0eek(z0ZzZzhsh.z0uek, z0qrk.z0oek(), z0qrk.z0pek(), z0qrk.z0uek(), z0qrk.z0iek(), num);
				}
			}
			else
			{
				p0.z0eek(z0vek(), z0qrk.z0oek(), z0qrk.z0pek(), z0qrk.z0uek(), z0qrk.z0iek(), num);
			}
			Color empty = Color.Empty;
			empty = ((!z0uek()) ? Color.FromArgb(112, 112, 112) : Color.FromArgb(60, 127, 177));
			if (z0yek().z0xrk().BorderWidth >= 0f)
			{
				using z0ZzZzudh p4 = new z0ZzZzudh(empty);
				p0.z0eek(p4, z0qrk, num);
			}
			if (!string.IsNullOrEmpty(z0rek()))
			{
				z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
				z0ZzZzlsh.z0rek(StringAlignment.Center);
				z0ZzZzlsh.z0eek(StringAlignment.Center);
				z0ZzZzbdh p5 = z0qrk;
				float num2 = z0ZzZzrpk.z0eek(4, GraphicsUnit.Pixel, p0.z0vek());
				p5.z0tek(num2, 0f);
				p5.z0tek(p5.z0uek() - num2 * 2f);
				z0ZzZzxdh z0ZzZzxdh = z0ZzZzlcj.z0rek(p0, z0rek(), z0oek(), 10000, z0ZzZzlsh);
				z0ZzZzxdh.z0rek(z0oek().z0eek(p0));
				p5.z0yek(Math.Min(z0ZzZzxdh.z0tek() + 8f, z0qrk.z0iek()));
				p5.z0rek(Math.Max(z0qrk.z0pek(), z0qrk.z0pek() + (z0qrk.z0iek() - z0ZzZzxdh.z0tek()) / 2f));
				p5.z0eek(Math.Max(z0qrk.z0oek(), z0qrk.z0oek() + (z0qrk.z0uek() - z0ZzZzxdh.z0rek()) / 2f));
				p5.z0tek(z0ZzZzxdh.z0rek() + 2f);
				if (z0ZzZzxdh.z0tek() > z0qrk.z0iek())
				{
					z0ZzZzlsh.z0eek(StringAlignment.Near);
				}
				else
				{
					z0ZzZzlsh.z0eek(StringAlignment.Center);
				}
				if (!z0nek())
				{
					p0.z0eek(z0rek(), z0oek(), Color.DarkGray, p5, z0ZzZzlsh);
				}
				else
				{
					p0.z0eek(z0rek(), z0oek(), z0mek(), p5, z0ZzZzlsh);
				}
				z0ZzZzlsh.Dispose();
			}
		}

		public void z0eek(z0ZzZzimk p0)
		{
			z0wrk = p0;
		}

		public void z0eek(z0ZzZzpmk p0)
		{
			z0erk = p0;
		}

		public void z0eek(Color p0)
		{
			z0jrk = p0;
		}

		public void z0eek(z0ZzZzbdh p0)
		{
			z0qrk = p0;
		}

		public z0ZzZzpmk z0tek()
		{
			return z0krk;
		}

		public XTextButtonElement z0yek()
		{
			return z0drk;
		}

		public bool z0uek()
		{
			return z0lrk;
		}

		public void z0rek(z0ZzZzpmk p0)
		{
			z0xek = p0;
		}

		public z0ZzZzpmk z0iek()
		{
			return z0erk;
		}

		public z0ZzZzimk z0oek()
		{
			return z0wrk;
		}

		public z0mpk z0pek()
		{
			return z0frk;
		}

		public Color z0mek()
		{
			return z0jrk;
		}

		public void z0eek(XTextButtonElement p0)
		{
			z0drk = p0;
		}

		public void z0tek(z0ZzZzpmk p0)
		{
			z0krk = p0;
		}

		public void z0eek(z0mpk p0)
		{
			z0frk = p0;
		}

		public bool z0nek()
		{
			return z0hrk;
		}

		public z0ZzZzbdh z0bek()
		{
			return z0qrk;
		}

		public void z0rek(Color p0)
		{
			z0zek = p0;
		}

		public z0ZzZzxdh z0rek(z0ZzZzjpk p0)
		{
			z0ZzZzxdh result = new z0ZzZzxdh(10f, 10f);
			bool flag = false;
			if (z0iek() != null && z0iek().HasContent)
			{
				z0ZzZzxdh z0ZzZzxdh = z0ZzZzrpk.z0eek(new z0ZzZzxdh(z0iek().Width, z0iek().Height), GraphicsUnit.Pixel, p0.z0vek());
				result.z0eek(z0ZzZzxdh.z0rek());
				result.z0rek(z0ZzZzxdh.z0tek());
				flag = true;
			}
			if (z0eek() != null && z0eek().HasContent)
			{
				z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzrpk.z0eek(new z0ZzZzxdh(z0eek().Width, z0eek().Height), GraphicsUnit.Pixel, p0.z0vek());
				result.z0eek(Math.Max(result.z0rek(), z0ZzZzxdh2.z0rek()));
				result.z0rek(Math.Max(result.z0tek(), z0ZzZzxdh2.z0tek()));
				flag = true;
			}
			if (z0tek() != null && z0tek().HasContent)
			{
				z0ZzZzxdh z0ZzZzxdh3 = z0ZzZzrpk.z0eek(new z0ZzZzxdh(z0tek().Width, z0tek().Height), GraphicsUnit.Pixel, p0.z0vek());
				result.z0eek(Math.Max(result.z0rek(), z0ZzZzxdh3.z0rek()));
				result.z0rek(Math.Max(result.z0tek(), z0ZzZzxdh3.z0tek()));
				flag = true;
			}
			if (!flag && !string.IsNullOrEmpty(z0rek()))
			{
				z0ZzZzxdh z0ZzZzxdh4 = z0ZzZzxdh.z0yek;
				z0ZzZzxdh4 = z0ZzZzlcj.z0rek(p0.z0oek(), z0rek(), z0oek(), 10000, z0ZzZzlsh.z0uek());
				float num = z0ZzZzxdh4.z0rek() + (float)z0ZzZzrpk.z0eek(10, GraphicsUnit.Pixel, p0.z0vek());
				result.z0eek(Math.Max(num, z0ZzZzxdh4.z0rek()));
				result.z0rek(z0ZzZzxdh4.z0tek() + (float)z0ZzZzrpk.z0eek(5, GraphicsUnit.Pixel, p0.z0vek()));
			}
			return result;
		}

		public Color z0vek()
		{
			return z0zek;
		}

		public void z0eek(string p0)
		{
			z0ark = p0;
		}
	}

	internal enum z0mpk
	{
		z0eek,
		z0rek,
		z0tek
	}

	private new string z0rek;

	private new bool z0tek;

	private new z0ZzZzpmk z0yek;

	[NonSerialized]
	[z0ZzZzuqh]
	internal new z0mpk z0uek;

	private new string z0iek;

	private new z0ZzZzpmk z0oek;

	private new string z0pek;

	public new static z0smk z0nek = null;

	private new z0ZzZzpmk z0bek;

	internal static bool z0vek_jiejie20260327142557 = true;

	private new bool z0cek;

	[DefaultValue(null)]
	[z0ZzZzyqh]
	public z0ZzZzpmk ImageForMouseOver
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	[z0ZzZzuqh]
	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	public override string FormulaValue
	{
		get
		{
			return Text;
		}
		set
		{
			Text = z0uek(value);
			z0jo();
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	[z0ZzZzyqh]
	public override string Text
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
			z0ktk();
		}
	}

	[DefaultValue(false)]
	[z0ZzZzyqh]
	public bool AutoSize
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzyqh]
	public z0ZzZzpmk ImageForDown
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

	[DefaultValue(null)]
	public string CommandName
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

	[z0ZzZzyqh]
	[DefaultValue(null)]
	public z0ZzZzpmk Image
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

	[DefaultValue(false)]
	[z0ZzZzyqh]
	public bool PrintAsText
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzyqh]
	public string ScriptTextForClick
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	public override bool z0mi()
	{
		if (z0jr() != null && z0bu().DesignMode)
		{
			return true;
		}
		return false;
	}

	private new z0ppk z0eek()
	{
		z0ppk z0ppk = new z0ppk();
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		z0ppk.z0eek(z0ZzZzrzj.z0pek);
		z0ppk.z0rek(z0ZzZzrzj.z0ark);
		z0ppk.z0eek(Text);
		z0ppk.z0eek(z0uek);
		z0ppk.z0eek(base.Enabled);
		z0ppk.z0eek(z0yek(z0ZzZzrzj.z0bek));
		z0ppk.z0eek(Image);
		z0ppk.z0rek(ImageForDown);
		z0ppk.z0tek(ImageForMouseOver);
		z0ppk.z0eek(this);
		return z0ppk;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0bek != null)
		{
			z0bek.Dispose();
			z0bek = null;
		}
		if (z0oek != null)
		{
			z0oek.Dispose();
			z0oek = null;
		}
		if (z0yek != null)
		{
			z0yek.Dispose();
			z0yek = null;
		}
	}

	public override void z0mu(DocumentEventArgs p0)
	{
		XTextDocument xTextDocument = z0jr();
		bool designMode = z0bu().DesignMode;
		switch (p0.Style)
		{
		case DocumentEventStyles.MouseDblClick:
			if (p0.Button == (z0ZzZzqeh)1 && designMode && xTextDocument != null && z0cu() != null)
			{
				z0cu().z0eek("ElementProperties", p1: true, this);
				return;
			}
			break;
		case DocumentEventStyles.MouseClick:
			if (p0.Button != (z0ZzZzqeh)1 || designMode)
			{
				break;
			}
			if (!base.Enabled)
			{
				p0.Handled = true;
				p0.CancelBubble = true;
				return;
			}
			if (z0vek_jiejie20260327142557)
			{
				z0qek().z0frk().z0oek(this);
			}
			p0.Handled = true;
			p0.CancelBubble = true;
			z0uek = z0mpk.z0rek;
			z0jo();
			if (xTextDocument != null && !string.IsNullOrEmpty(CommandName) && xTextDocument.z0qrk(CommandName) is EventHandler eventHandler)
			{
				eventHandler(this, EventArgs.Empty);
				p0.Handled = true;
				p0.CancelBubble = true;
				return;
			}
			if (z0cu() != null)
			{
				WriterButtonClickEventArgs e = new WriterButtonClickEventArgs(z0cu(), this);
				z0cu().z0bj("EventButtonClick", e);
				if (e.Handled)
				{
					e.Dispose();
					p0.Handled = true;
					p0.CancelBubble = true;
					return;
				}
				e.Dispose();
			}
			p0.Handled = true;
			p0.CancelBubble = true;
			return;
		case DocumentEventStyles.MouseDown:
			if (!designMode)
			{
				if (designMode)
				{
					p0.Cursor = z0ZzZzbwh.z0krk;
				}
				if (!base.Enabled)
				{
					p0.Handled = true;
					p0.CancelBubble = true;
				}
				else if (p0.Button == (z0ZzZzqeh)1)
				{
					z0uek = z0mpk.z0tek;
					z0jo();
					z0cu();
					base.z0mu(p0);
					p0.Handled = true;
					p0.CancelBubble = true;
				}
				return;
			}
			break;
		case DocumentEventStyles.MouseEnter:
			if (!designMode && !base.Enabled)
			{
				p0.Handled = true;
				p0.CancelBubble = true;
				return;
			}
			if (p0.Button == (z0ZzZzqeh)0)
			{
				z0uek = z0mpk.z0rek;
				z0jo();
				base.z0mu(p0);
				p0.Handled = true;
				p0.CancelBubble = true;
				return;
			}
			break;
		case DocumentEventStyles.MouseLeave:
			if (!designMode && !base.Enabled)
			{
				p0.Handled = true;
				p0.CancelBubble = true;
				return;
			}
			if (p0.Button == (z0ZzZzqeh)0)
			{
				z0uek = z0mpk.z0eek;
				z0jo();
				base.z0mu(p0);
				p0.Handled = true;
				p0.CancelBubble = true;
				return;
			}
			break;
		}
		base.z0mu(p0);
		if (!designMode)
		{
			p0.Cursor = z0ZzZzbwh.z0ark;
		}
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(z0iek);
		p0.z0eek(z0pek);
	}

	public XTextButtonElement()
	{
		Width = 199f;
		Height = 80f;
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		if (p0.z0tek())
		{
			p0.z0eek('[');
		}
		p0.z0eek(Text);
		if (p0.z0tek())
		{
			p0.z0eek(']');
		}
	}

	public override void z0et(ResizeableType p0)
	{
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		p0.z0eek(z0pek);
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		if (z0nek != null && z0nek(this, p0))
		{
			return;
		}
		if (PrintAsText && (p0.z0byk == (z0ZzZzcxj)3 || p0.z0byk == (z0ZzZzcxj)2))
		{
			if (Text != null && Text.Length > 0)
			{
				z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
				z0ZzZzlsh.z0rek(StringAlignment.Center);
				z0ZzZzlsh.z0eek(StringAlignment.Center);
				p0.z0gyk.z0eek(Text, z0aek().z0pek, z0yek(z0aek().z0bek), p0.z0gtk, z0ZzZzlsh);
			}
			return;
		}
		z0ppk z0ppk = z0eek();
		if (p0.z0byk != 0)
		{
			z0ppk.z0eek(z0mpk.z0eek);
		}
		z0ZzZzbdh z0ZzZzbdh = z0qyk();
		z0ppk.z0eek(new z0ZzZzbdh(z0ZzZzbdh.z0oek() + 1f, z0ZzZzbdh.z0pek() + 1f, z0ZzZzbdh.z0uek() - 4f, z0ZzZzbdh.z0iek() - 4f));
		if (z0ZzZzbdh.z0iek() < z0aek().z0ytk)
		{
			z0ppk.z0eek(new z0ZzZzbdh(z0ZzZzbdh.z0oek() + 1f, z0ZzZzbdh.z0pek() + 1f, z0ZzZzbdh.z0uek() - 2f, z0ZzZzbdh.z0iek()));
		}
		z0ppk.z0eek(p0.z0gyk);
	}

	public override string z0pe()
	{
		return "button";
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		if (AutoSize)
		{
			z0ZzZzxdh z0ZzZzxdh = z0eek(p0.z0gyk);
			Width = z0ZzZzxdh.z0rek();
			Height = z0ZzZzxdh.z0tek();
		}
		else
		{
			base.z0mr(p0);
		}
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextButtonElement xTextButtonElement = (XTextButtonElement)base.z0lr(p0);
		if (z0bek != null)
		{
			xTextButtonElement.z0bek = z0bek.Clone();
		}
		if (z0oek != null)
		{
			xTextButtonElement.z0oek = z0oek.Clone();
		}
		if (z0yek != null)
		{
			xTextButtonElement.z0yek = z0yek.Clone();
		}
		return xTextButtonElement;
	}

	public override string z0ge()
	{
		return "Button:" + ID;
	}

	public override z0ZzZzpmk z0ny()
	{
		if (Image != null && Image.HasContent)
		{
			return Image.Clone();
		}
		return base.z0ny();
	}

	public override ResizeableType z0wt()
	{
		if (AutoSize)
		{
			return ResizeableType.FixSize;
		}
		return ResizeableType.WidthAndHeight;
	}

	public z0ZzZzxdh z0eek(z0ZzZzjpk p0)
	{
		return z0eek().z0rek(p0);
	}
}
