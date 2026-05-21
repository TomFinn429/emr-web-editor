using System;
using System.Collections.Generic;
using System.ComponentModel;
using DCSoft.Chart;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzwtk
{
	private class z0qmk
	{
		public readonly z0ZzZzbdh z0eek = z0ZzZzbdh.z0xek;

		public readonly string z0rek;

		public z0qmk(string p0, float p1, float p2)
		{
			z0rek = p0;
			z0eek = new z0ZzZzbdh(p1, p2, 0f, 0f);
		}

		public z0qmk(string p0, z0ZzZzbdh p1)
		{
			z0rek = p0;
			z0eek = p1;
		}
	}

	private z0ZzZzetk z0cek = new z0ZzZzetk();

	private double z0xek = 100.0;

	private z0ZzZzbdh z0zek = z0ZzZzbdh.z0xek;

	private z0ZzZzbdh z0lrk = z0ZzZzbdh.z0xek;

	private bool z0krk;

	private z0ZzZzttk z0jrk = new z0ZzZzttk();

	private double z0hrk;

	private int z0grk;

	private double z0frk = 1.0;

	private z0ZzZzutk z0drk = new z0ZzZzutk();

	private z0ZzZzqtk z0srk = new z0ZzZzqtk();

	protected z0ZzZzttk z0ark = new z0ZzZzttk();

	private z0ZzZzotk z0qrk = new z0ZzZzotk();

	protected int z0wrk;

	private float z0erk;

	public z0ZzZzqtk z0eek()
	{
		return z0srk;
	}

	public float z0rek()
	{
		return z0lrk.z0pek();
	}

	public void z0eek(z0ZzZzotk p0)
	{
		z0qrk = p0;
	}

	[DefaultValue(0)]
	public int z0tek()
	{
		return z0wrk;
	}

	public z0ZzZzttk z0yek()
	{
		return z0ark;
	}

	private bool z0eek(z0ZzZzbdh p0, int p1, int p2)
	{
		if (p1 != -2147483648)
		{
			float num = p0.z0uek() / 300f;
			if ((float)p1 >= p0.z0oek() + num && (float)p1 <= p0.z0mek() - num)
			{
				return true;
			}
		}
		else if (p2 != -2147483648)
		{
			float num2 = p0.z0iek() / 300f;
			if ((float)p2 >= p0.z0pek() + num2 && (float)p2 <= p0.z0nek() - num2)
			{
				return true;
			}
		}
		return false;
	}

	public float z0uek()
	{
		return z0lrk.z0uek();
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		z0ZzZzbdh p2 = z0ZzZzbdh.z0xek;
		if (!p1.z0bek())
		{
			p2 = new z0ZzZzbdh(p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek());
		}
		z0cek.z0eek(p0, p1);
		using (z0ZzZzudh p3 = z0eek().z0xrk().z0yek())
		{
			z0cek.z0eek(p0, z0ZzZzbdh.z0xek, p3);
		}
		z0rek(p0, p1);
		if (z0eek().z0jrk().z0bek() && z0eek().z0jrk().z0zek())
		{
			z0eek().z0jrk().z0rek(p0, p1);
		}
		foreach (z0ZzZzstk item in z0eek().z0mek())
		{
			if (item.z0bek() && item.z0zek())
			{
				item.z0eek(p0, p1);
			}
		}
		if (z0eek().z0eek().z0bek() && z0eek().z0eek().z0zek())
		{
			z0eek().z0eek().z0rek(p0, p1);
		}
		if (z0nek() != null && z0nek().z0yek().z0eek())
		{
			z0nek().z0eek(p0, p1);
		}
		List<z0qmk> list = new List<z0qmk>();
		float num = z0eek().z0gtk().z0eek(p0) * 1.3f;
		if (z0eek().z0ftk())
		{
			foreach (z0ZzZzytk item2 in z0drk)
			{
				z0ZzZzbdh p4 = item2.z0vek();
				if (!item2.z0oek() || !(p4.z0uek() > 0f) || !(p4.z0iek() > 0f))
				{
					continue;
				}
				if (z0eek().z0bek())
				{
					z0cek.z0eek(p4, p0, z0eek(item2), p2, z0eek().z0cek(), p5: false);
				}
				else if (z0eek().z0dtk() == ChartViewStyle.Bar || z0eek().z0dtk() == ChartViewStyle.HorizBar)
				{
					z0cek.z0eek(p4, p0, z0eek(item2), p2, z0eek().z0vrk(), z0eek().z0dtk());
				}
				else
				{
					z0cek.z0eek(p4, p0, z0eek(item2), p2);
				}
				if (z0eek().z0grk().z0yek() && item2.z0bek() != null && item2.z0bek().Length > 0)
				{
					if (z0eek().z0prk())
					{
						list.Add(new z0qmk(item2.z0bek(), new z0ZzZzbdh(p4.z0oek(), p4.z0pek(), p4.z0uek(), p4.z0iek())));
					}
					else
					{
						list.Add(new z0qmk(item2.z0bek(), p4.z0oek(), p4.z0pek() - num - z0eek().z0uek()));
					}
				}
			}
		}
		else
		{
			for (int num2 = z0drk.Count - 1; num2 >= 0; num2--)
			{
				z0ZzZzytk z0ZzZzytk2 = z0drk[num2];
				z0ZzZzbdh p5 = z0ZzZzytk2.z0vek();
				if (z0ZzZzytk2.z0oek())
				{
					if (z0eek().z0bek())
					{
						z0cek.z0eek(p5, p0, z0eek(z0ZzZzytk2), p2, z0eek().z0cek(), p5: true);
					}
					else if (z0eek().z0dtk() == ChartViewStyle.Bar || z0eek().z0dtk() == ChartViewStyle.HorizBar)
					{
						z0cek.z0eek(p5, p0, z0eek(z0ZzZzytk2), p2, z0eek().z0vrk(), z0eek().z0dtk());
					}
					else
					{
						z0cek.z0eek(p5, p0, z0eek(z0ZzZzytk2), p2);
					}
					if (z0eek().z0grk().z0yek() && z0ZzZzytk2.z0bek() != null && z0ZzZzytk2.z0bek().Length > 0)
					{
						if (z0eek().z0prk())
						{
							list.Add(new z0qmk(z0ZzZzytk2.z0bek(), new z0ZzZzbdh(p5.z0oek(), p5.z0pek(), p5.z0uek(), p5.z0iek())));
						}
						else
						{
							list.Add(new z0qmk(z0ZzZzytk2.z0bek(), p5.z0mek() + z0eek().z0uek(), p5.z0pek() - (num - p5.z0iek()) / 2f));
						}
					}
				}
			}
		}
		z0ZzZzttk z0ZzZzttk2 = z0ark.z0eek();
		if (z0eek().z0prk() && z0eek().z0tek() == ChartStyleConsts.Line)
		{
			z0ZzZzttk2.Reverse();
		}
		foreach (z0ZzZzrtk item3 in z0ZzZzttk2)
		{
			if (item3.z0yrk != ChartStyleConsts.Line && item3.z0yrk != ChartStyleConsts.Point)
			{
				continue;
			}
			z0ZzZzudh p6 = item3.z0tek();
			z0ZzZzytk z0ZzZzytk3 = null;
			if (z0eek().z0ftk())
			{
				foreach (z0ZzZzytk item4 in item3.z0rek())
				{
					if (z0ZzZzytk3 != null)
					{
						z0ZzZzpdh z0ZzZzpdh2 = z0ZzZzytk3.z0nek();
						z0ZzZzpdh z0ZzZzpdh3 = item4.z0nek();
						if (!float.IsNaN(z0ZzZzpdh2.z0tek()) && !float.IsNaN(z0ZzZzpdh3.z0tek()))
						{
							if (z0eek().z0uek() == 0f)
							{
								if (z0eek().z0hrk())
								{
									z0ZzZzbdh z0ZzZzbdh2 = z0cek.z0eek();
									using z0ZzZznfh z0ZzZznfh2 = new z0ZzZznfh();
									z0ZzZznfh2.z0tek(new z0ZzZzpdh[5]
									{
										new z0ZzZzpdh(z0ZzZzpdh2.z0rek(), z0ZzZzbdh2.z0nek()),
										z0ZzZzpdh2,
										z0ZzZzpdh3,
										new z0ZzZzpdh(z0ZzZzpdh3.z0rek(), z0ZzZzbdh2.z0nek()),
										new z0ZzZzpdh(z0ZzZzpdh2.z0rek(), z0ZzZzbdh2.z0nek())
									});
									if (p2.z0bek() || p2.z0tek(z0ZzZznfh2.z0eek()))
									{
										using z0ZzZzzdh p7 = new z0ZzZzzdh(item3.z0mek());
										p0.z0eek(p7, z0ZzZznfh2);
									}
								}
								else if (item3.z0yrk == ChartStyleConsts.Line)
								{
									p0.z0eek(p6, z0ZzZzpdh2, z0ZzZzpdh3);
								}
							}
							else if (item3.z0yrk == ChartStyleConsts.Line)
							{
								z0cek.z0eek(z0ZzZzpdh2, z0ZzZzpdh3, p0, z0eek(item4));
							}
						}
					}
					z0eek(item4, p0, p1);
					if (item4.z0oek() && z0eek().z0grk().z0yek() && item4.z0bek() != null && item4.z0bek().Length > 0)
					{
						list.Add(new z0qmk(item4.z0bek(), item4.z0nek().z0rek() + z0lrk.z0oek(), item4.z0nek().z0tek() + z0lrk.z0pek() - num));
					}
					z0ZzZzytk3 = item4;
				}
				continue;
			}
			for (int num3 = item3.z0rek().Count - 1; num3 >= 0; num3--)
			{
				z0ZzZzytk z0ZzZzytk4 = item3.z0rek()[num3];
				if (z0ZzZzytk3 != null)
				{
					z0ZzZzpdh z0ZzZzpdh4 = z0ZzZzytk3.z0nek();
					z0ZzZzpdh4.z0eek(z0ZzZzpdh4.z0rek() + z0lrk.z0oek() + (float)z0eek().z0urk());
					z0ZzZzpdh4.z0rek(z0ZzZzpdh4.z0tek() + z0lrk.z0pek() + (float)z0eek().z0drk());
					z0ZzZzpdh z0ZzZzpdh5 = z0ZzZzytk4.z0nek();
					z0ZzZzpdh5.z0eek(z0ZzZzpdh5.z0rek() + z0lrk.z0oek() + (float)z0eek().z0urk());
					z0ZzZzpdh5.z0rek(z0ZzZzpdh5.z0tek() + z0lrk.z0pek() + (float)z0eek().z0drk());
					if (z0eek().z0uek() == 0f)
					{
						if (z0eek().z0hrk())
						{
							z0ZzZzbdh z0ZzZzbdh3 = z0cek.z0eek();
							using z0ZzZznfh z0ZzZznfh3 = new z0ZzZznfh();
							z0ZzZznfh3.z0tek(new z0ZzZzpdh[5]
							{
								new z0ZzZzpdh(z0ZzZzbdh3.z0oek(), z0ZzZzpdh4.z0tek()),
								z0ZzZzpdh4,
								z0ZzZzpdh5,
								new z0ZzZzpdh(z0ZzZzbdh3.z0oek(), z0ZzZzpdh5.z0tek()),
								new z0ZzZzpdh(z0ZzZzbdh3.z0oek(), z0ZzZzpdh4.z0tek())
							});
							if (p2.z0bek() || p2.z0tek(z0ZzZznfh3.z0eek()))
							{
								p0.z0eek(item3.z0mek(), z0ZzZznfh3);
							}
						}
						else if (item3.z0yrk == ChartStyleConsts.Line)
						{
							p0.z0eek(p6, z0ZzZzpdh4, z0ZzZzpdh5);
						}
					}
					else if (item3.z0yrk == ChartStyleConsts.Line)
					{
						z0cek.z0eek(z0ZzZzpdh4, z0ZzZzpdh5, p0, z0eek(z0ZzZzytk4));
					}
				}
				z0eek(z0ZzZzytk4, p0, p1);
				if (z0ZzZzytk4.z0oek() && z0eek().z0grk().z0yek() && z0ZzZzytk4.z0bek() != null && z0ZzZzytk4.z0bek().Length > 0)
				{
					list.Add(new z0qmk(z0ZzZzytk4.z0bek(), z0ZzZzytk4.z0nek().z0rek() + z0lrk.z0oek(), z0ZzZzytk4.z0nek().z0tek() + z0lrk.z0pek() - num / 2f));
				}
				z0ZzZzytk3 = z0ZzZzytk4;
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
		z0ZzZzlsh2.z0rek(StringAlignment.Center);
		z0ZzZzlsh2.z0eek(StringAlignment.Center);
		z0ZzZzlsh2.z0eek((z0ZzZzksh)4096);
		foreach (z0qmk item5 in list)
		{
			if (item5.z0eek.z0uek() == 0f)
			{
				z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek(item5.z0rek, z0eek().z0grk().z0iek().Value, 10000, z0ZzZzlsh2);
				z0ZzZzbdh z0ZzZzbdh4 = item5.z0eek;
				z0ZzZzbdh4.z0tek(z0ZzZzxdh2.z0rek());
				z0ZzZzbdh4.z0yek(num);
				if (z0ZzZzbdh4.z0pek() < z0zek.z0pek())
				{
					z0ZzZzbdh4.z0rek(z0zek.z0pek());
				}
				else if (z0ZzZzbdh4.z0nek() > z0zek.z0nek())
				{
					z0ZzZzbdh4.z0rek(z0zek.z0nek() - z0ZzZzbdh4.z0iek());
				}
				if (z0ZzZzbdh4.z0oek() < z0zek.z0oek())
				{
					z0ZzZzbdh4.z0eek(z0zek.z0oek());
				}
				else if (z0ZzZzbdh4.z0mek() > z0zek.z0mek())
				{
					z0ZzZzbdh4.z0eek(z0zek.z0mek() - z0ZzZzbdh4.z0uek());
				}
				if (z0eek().z0grk().z0eek().A != 0)
				{
					using z0ZzZzzdh p8 = new z0ZzZzzdh(z0eek().z0grk().z0eek());
					p0.z0rek(p8, z0ZzZzbdh4);
				}
				z0ZzZzlsh2.z0eek(StringAlignment.Far);
				p0.DrawString(item5.z0rek, z0eek().z0grk().z0iek().Value, z0ZzZzyfh.z0eek(z0eek().z0grk().z0oek()), z0ZzZzbdh4, z0ZzZzlsh2);
				if (z0eek().z0grk().z0rek().A != 0)
				{
					using z0ZzZzudh p9 = new z0ZzZzudh(z0eek().z0grk().z0rek());
					p0.z0eek(p9, z0ZzZzbdh4.z0oek(), z0ZzZzbdh4.z0pek(), z0ZzZzbdh4.z0uek(), z0ZzZzbdh4.z0iek(), 0f);
				}
			}
			else
			{
				z0ZzZzlsh2.z0eek(StringAlignment.Center);
				p0.DrawString(item5.z0rek, z0eek().z0grk().z0iek().Value, z0ZzZzyfh.z0uek, item5.z0eek, z0ZzZzlsh2);
			}
		}
	}

	public virtual string z0eek(double p0, string p1)
	{
		if (p1 == null || p1.Length == 0)
		{
			return p0.ToString();
		}
		int num = p1.IndexOf('{');
		if (num >= 0 && p1.IndexOf('}', num + 1) > 0)
		{
			try
			{
				return string.Format(p1, p0);
			}
			catch
			{
				return p0.ToString();
			}
		}
		return p0.ToString(p1);
	}

	public bool z0iek()
	{
		return z0krk;
	}

	public void z0eek(z0ZzZzjpk p0)
	{
		if (z0cek == null)
		{
			z0cek = new z0ZzZzetk();
		}
		if (z0eek() == null)
		{
			z0eek(new z0ZzZzqtk());
		}
		z0krk = false;
		z0cek.z0eek(z0eek().z0uek());
		z0cek.z0rek(z0eek().z0cek());
		z0cek.z0eek(z0eek().z0wrk());
		z0cek.z0eek(z0eek().z0qrk());
		float num = z0cek.z0uek();
		float num2 = z0cek.z0rek();
		z0zek = z0pek();
		z0zek.z0eek(z0zek.z0tek() + (float)z0eek().z0urk());
		z0zek.z0rek(z0zek.z0yek() + (float)z0eek().z0drk());
		z0zek.z0tek(z0zek.z0uek() - (float)z0eek().z0urk() - (float)z0eek().z0zek());
		z0zek.z0yek(z0zek.z0iek() - (float)z0eek().z0drk() - (float)z0eek().z0lrk());
		if (z0eek().z0jrk().z0bek())
		{
			z0eek().z0jrk().z0eek(new z0ZzZzbdh(z0zek.z0oek(), z0zek.z0pek(), z0zek.z0uek(), z0eek().z0jrk().z0drk()));
			ref z0ZzZzbdh reference = ref z0zek;
			reference.z0rek(reference.z0yek() + z0eek().z0jrk().z0drk());
			ref z0ZzZzbdh reference2 = ref z0zek;
			reference2.z0yek(reference2.z0iek() - z0eek().z0jrk().z0drk());
		}
		z0qrk.z0eek(z0eek().z0erk());
		if (z0nek() != null && z0nek().z0yek().z0eek())
		{
			z0nek().z0rek().Clear();
			foreach (z0ZzZzrtk item in z0yek())
			{
				item.z0ark = this;
				z0ZzZzmtk z0ZzZzmtk2 = new z0ZzZzmtk();
				z0ZzZzmtk2.z0eek(item.z0lrk());
				ChartStyleConsts chartStyleConsts = item.z0zek();
				if (chartStyleConsts == ChartStyleConsts.Default)
				{
					chartStyleConsts = z0eek().z0tek();
				}
				if (chartStyleConsts == ChartStyleConsts.Default)
				{
					chartStyleConsts = ChartStyleConsts.Bar;
				}
				item.z0yrk = chartStyleConsts;
				if (item.z0yrk == ChartStyleConsts.Bar)
				{
					z0ZzZzmtk2.z0eek(ShapeTypes.Rectangle);
				}
				else if (item.z0vek() != ShapeTypes.None)
				{
					z0ZzZzmtk2.z0eek(item.z0vek());
				}
				else
				{
					z0ZzZzmtk2.z0eek(ShapeTypes.Rectangle);
				}
				z0ZzZzmtk2.z0eek(item.z0mek());
				z0ZzZzmtk2.z0eek(item.z0uek());
				z0nek().z0rek().Add(z0ZzZzmtk2);
			}
			z0zek = z0nek().z0rek(p0, z0zek);
			z0nek().z0rek(p0);
		}
		foreach (z0ZzZzstk item2 in z0eek().z0mek())
		{
			if (item2.z0bek())
			{
				if (item2.z0xek())
				{
					item2.z0eek(new z0ZzZzbdh(z0zek.z0tek(), z0zek.z0yek(), item2.z0drk(), z0zek.z0iek()));
					ref z0ZzZzbdh reference3 = ref z0zek;
					reference3.z0eek(reference3.z0tek() + item2.z0drk());
					ref z0ZzZzbdh reference4 = ref z0zek;
					reference4.z0tek(reference4.z0uek() - item2.z0drk());
				}
				else
				{
					item2.z0eek(new z0ZzZzbdh(z0zek.z0tek() + z0zek.z0uek() - item2.z0drk(), z0zek.z0yek(), item2.z0drk(), z0zek.z0iek()));
					ref z0ZzZzbdh reference5 = ref z0zek;
					reference5.z0tek(reference5.z0uek() - item2.z0drk());
				}
			}
		}
		if (z0eek().z0eek().z0bek())
		{
			z0eek().z0eek().z0eek(new z0ZzZzbdh(z0zek.z0oek(), z0zek.z0nek() - z0eek().z0eek().z0drk(), z0zek.z0uek(), z0eek().z0eek().z0drk()));
			ref z0ZzZzbdh reference6 = ref z0zek;
			reference6.z0yek(reference6.z0iek() - z0eek().z0eek().z0drk());
		}
		foreach (z0ZzZzstk item3 in z0eek().z0mek())
		{
			if (item3.z0bek())
			{
				z0ZzZzbdh p1 = item3.z0tek();
				p1.z0yek(z0zek.z0iek());
				item3.z0eek(p1);
			}
		}
		z0zek.z0rek((int)(z0zek.z0yek() - num2));
		z0zek.z0tek(z0zek.z0uek() - (float)(int)Math.Abs(num));
		z0zek.z0yek(z0zek.z0iek() - (float)(int)Math.Abs(num2));
		z0cek.z0eek(z0zek);
		z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(z0zek.z0tek(), z0zek.z0yek(), z0zek.z0uek(), z0zek.z0iek());
		z0jrk.Clear();
		z0grk = 0;
		z0xek = z0ZzZzbok.z0rek;
		z0hrk = z0ZzZzbok.z0rek;
		foreach (z0ZzZzrtk item4 in z0yek())
		{
			item4.z0ark = this;
			foreach (z0ZzZzytk item5 in item4.z0rek())
			{
				item5.z0frk = z0ZzZzbok.z0rek;
				if (z0ZzZzbok.z0eek(z0xek) || z0xek < item5.z0eek())
				{
					z0xek = item5.z0eek();
				}
				if (z0ZzZzbok.z0eek(z0hrk) || z0hrk > item5.z0eek())
				{
					z0hrk = item5.z0eek();
				}
				item5.z0rrk = item4;
			}
			ChartStyleConsts chartStyleConsts2 = item4.z0zek();
			if (chartStyleConsts2 == ChartStyleConsts.Default)
			{
				chartStyleConsts2 = z0eek().z0tek();
			}
			if (chartStyleConsts2 == ChartStyleConsts.Default)
			{
				chartStyleConsts2 = ChartStyleConsts.Bar;
			}
			item4.z0yrk = chartStyleConsts2;
			if (z0grk < item4.z0rek().Count)
			{
				z0grk = item4.z0rek().Count;
			}
			if (chartStyleConsts2 == ChartStyleConsts.Bar)
			{
				z0jrk.Add(item4);
			}
		}
		if (z0eek().z0prk())
		{
			z0xek = z0ZzZzbok.z0rek;
			for (int i = 0; i < z0grk; i++)
			{
				double num3 = 0.0;
				double num4 = z0ZzZzbok.z0rek;
				foreach (z0ZzZzrtk item6 in z0yek())
				{
					if (item6.z0rek().Count > i)
					{
						item6.z0rek()[i].z0frk = num4;
						double num5 = item6.z0rek()[i].z0eek();
						if (z0ZzZzbok.z0eek(num4))
						{
							num4 = num5;
						}
						else if (!z0ZzZzbok.z0eek(num5))
						{
							num4 += num5;
						}
						if (!z0ZzZzbok.z0eek(num5))
						{
							num3 += num5;
						}
					}
				}
				if (z0ZzZzbok.z0eek(z0xek) || z0xek < num3)
				{
					z0xek = num3;
				}
			}
		}
		foreach (z0ZzZzstk item7 in z0eek().z0mek())
		{
			if (item7.z0oek() != RangeCalculateStyle.None)
			{
				if (z0ZzZzbok.z0eek(item7.z0rek()))
				{
					item7.z0yek(item7.z0cek());
				}
				else if (item7.z0oek() != RangeCalculateStyle.AutoMaxMinValue && item7.z0oek() != RangeCalculateStyle.AutoMaxValue)
				{
					item7.z0yek(item7.z0cek());
				}
				if (z0ZzZzbok.z0eek(item7.z0eek()))
				{
					item7.z0uek(item7.z0hrk());
				}
				else if (item7.z0oek() != RangeCalculateStyle.AutoMaxMinValue && item7.z0oek() != RangeCalculateStyle.AutoMinValue)
				{
					item7.z0uek(item7.z0hrk());
				}
				double num6 = 0.0;
				if (p0 != null && z0eek().z0ftk() && !z0eek().z0prk() && z0eek().z0grk().z0yek() && z0jrk.Count > 0)
				{
					double num7 = z0eek().z0grk().z0iek().z0eek(p0) + z0eek().z0uek();
					num6 = (item7.z0rek() - item7.z0eek()) * num7 / (double)z0zek.z0iek();
				}
				foreach (z0ZzZzrtk item8 in z0yek())
				{
					if (item8.z0yrk == ChartStyleConsts.Line || item8.z0yrk == ChartStyleConsts.Point)
					{
						num6 += (item7.z0rek() - item7.z0eek()) * (double)item8.z0nek() / (double)z0zek.z0iek();
						break;
					}
				}
				z0ZzZzfyk z0ZzZzfyk2 = new z0ZzZzfyk(item7.z0rek() + num6, item7.z0eek(), item7.z0oek());
				z0ZzZzfyk2.z0rek();
				item7.z0yek(z0ZzZzfyk2.z0eek());
				item7.z0uek(z0ZzZzfyk2.z0uek());
				item7.z0tek(z0ZzZzfyk2.z0tek());
			}
			else
			{
				item7.z0yek(item7.z0cek());
				item7.z0uek(item7.z0hrk());
				if (z0ZzZzbok.z0eek(item7.z0rek()))
				{
					item7.z0yek(100.0);
				}
				if (z0ZzZzbok.z0eek(item7.z0rek()))
				{
					item7.z0uek(0.0);
				}
			}
			if (z0eek().z0rrk())
			{
				item7.z0yek(100.0);
				item7.z0uek(0.0);
				item7.z0tek(10.0);
			}
		}
		z0drk.Clear();
		if (z0jrk.Count > 0)
		{
			for (int j = 0; j < z0grk; j++)
			{
				foreach (z0ZzZzrtk item9 in z0jrk)
				{
					if (j < item9.z0rek().Count)
					{
						z0drk.Add(item9.z0rek()[j]);
					}
				}
			}
		}
		if (z0eek().z0prk() && !z0eek().z0ftk())
		{
			z0drk.Reverse();
		}
		z0wrk = 0;
		if (z0jrk.Count > 0)
		{
			if (z0eek().z0prk())
			{
				z0wrk = z0eek().z0pek() + z0eek().z0ktk();
			}
			else
			{
				z0wrk = z0jrk.Count * (z0eek().z0pek() + z0eek().z0vek()) - z0eek().z0vek() + z0eek().z0ktk();
			}
		}
		else
		{
			z0wrk = z0eek().z0ktk();
		}
		z0erk = 0f;
		foreach (z0ZzZzrtk item10 in z0yek())
		{
			int num8 = z0jrk.IndexOf(item10);
			double num9 = 0.0;
			num9 = ((item10.z0yrk != ChartStyleConsts.Bar) ? ((double)(z0eek().z0ktk() / 2 + (z0wrk - z0eek().z0ktk()) / 2)) : ((double)(z0eek().z0ktk() / 2 + num8 * (z0eek().z0pek() + z0eek().z0vek()))));
			num9 = ((!z0eek().z0ftk()) ? (num9 + (double)z0ZzZzbdh2.z0pek()) : (num9 + (double)z0ZzZzbdh2.z0oek()));
			foreach (z0ZzZzytk item11 in item10.z0rek())
			{
				int num10 = item10.z0rek().IndexOf(item11);
				if (z0eek().z0prk() && item10.z0yrk == ChartStyleConsts.Bar)
				{
					num9 = z0eek().z0ktk() / 2 + num10 * (z0eek().z0pek() + z0eek().z0ktk());
				}
				double num11 = z0eek(item11.z0frk, item11);
				double num12 = z0eek(item11.z0eek(), item11);
				if (num12 + num11 > 1.0)
				{
					num12 = 1.0 - num11;
				}
				item11.z0eek(z0ZzZzbdh.z0xek);
				item11.z0eek(z0ZzZzpdh.z0yek);
				item11.z0eek(item10.z0yrk);
				if (item10.z0yrk == ChartStyleConsts.Bar)
				{
					if (z0eek().z0ftk())
					{
						item11.z0eek(new z0ZzZzbdh((float)num9, (float)((double)z0ZzZzbdh2.z0nek() - (double)z0ZzZzbdh2.z0iek() * (num12 + num11)), z0eek().z0pek(), (float)((double)z0ZzZzbdh2.z0iek() * num12)));
						if (z0erk < item11.z0vek().z0mek())
						{
							z0erk = item11.z0vek().z0mek();
						}
					}
					else
					{
						item11.z0eek(new z0ZzZzbdh((float)((double)z0ZzZzbdh2.z0oek() + (double)z0ZzZzbdh2.z0uek() * num11), (float)num9, (float)((double)z0ZzZzbdh2.z0uek() * num12), z0eek().z0pek()));
						if (z0erk < item11.z0vek().z0nek())
						{
							z0erk = item11.z0vek().z0nek();
						}
					}
					item11.z0eek(item10.z0pek());
					item11.z0eek(new z0ZzZznfh());
					item11.z0zek().z0eek(item11.z0vek());
				}
				else if (item10.z0yrk == ChartStyleConsts.Line || item10.z0yrk == ChartStyleConsts.Point)
				{
					if (z0ZzZzbok.z0eek(item11.z0eek()))
					{
						item11.z0eek(new z0ZzZzpdh(0f / 0f, 0f / 0f));
					}
					else if (z0eek().z0ftk())
					{
						item11.z0eek(new z0ZzZzpdh((float)num9, (float)((double)z0ZzZzbdh2.z0nek() - (double)z0ZzZzbdh2.z0iek() * (num12 + num11))));
						if (z0erk < item11.z0nek().z0rek())
						{
							z0erk = item11.z0nek().z0rek();
						}
					}
					else
					{
						item11.z0eek(new z0ZzZzpdh((float)((double)z0ZzZzbdh2.z0oek() + (double)z0ZzZzbdh2.z0uek() * (num12 + num11)), (float)num9));
						if (z0erk < item11.z0nek().z0tek())
						{
							z0erk = item11.z0nek().z0tek();
						}
					}
					item11.z0eek(item10.z0pek());
				}
				if (!z0eek().z0prk() || item10.z0yrk != ChartStyleConsts.Bar)
				{
					num9 = (int)(num9 + (double)z0tek());
				}
			}
		}
		z0erk += z0eek().z0ktk() / 2;
		if (z0eek().z0ftk())
		{
			z0erk -= z0ZzZzbdh2.z0oek();
		}
		else
		{
			z0erk -= z0ZzZzbdh2.z0pek();
		}
		z0frk = 1.0;
		switch (z0eek().z0ark())
		{
		case AxisCompressStyle.AutoSize:
			if (z0eek().z0ftk())
			{
				if (z0erk != z0ZzZzbdh2.z0uek())
				{
					z0frk = z0ZzZzbdh2.z0uek() / z0erk;
					z0erk = z0ZzZzbdh2.z0uek();
				}
			}
			else if (z0erk != z0ZzZzbdh2.z0iek())
			{
				z0frk = z0ZzZzbdh2.z0iek() / z0erk;
				z0erk = z0ZzZzbdh2.z0iek();
			}
			break;
		case AxisCompressStyle.AutoCompress:
			if (z0eek().z0ftk())
			{
				if (z0erk > z0ZzZzbdh2.z0uek())
				{
					z0frk = z0ZzZzbdh2.z0uek() / z0erk;
					z0erk = z0ZzZzbdh2.z0uek();
				}
			}
			else if (z0erk > z0ZzZzbdh2.z0iek())
			{
				z0frk = z0ZzZzbdh2.z0iek() / z0erk;
				z0erk = z0ZzZzbdh2.z0iek();
			}
			break;
		}
		if (z0frk != 1.0)
		{
			foreach (z0ZzZzrtk item12 in z0ark)
			{
				foreach (z0ZzZzytk item13 in item12.z0rek())
				{
					z0ZzZzbdh p2 = item13.z0vek();
					if (!p2.z0bek())
					{
						if (z0eek().z0ftk())
						{
							p2.z0eek((float)((double)z0ZzZzbdh2.z0oek() + (double)(p2.z0oek() - z0ZzZzbdh2.z0oek()) * z0frk));
							p2.z0tek((float)((double)p2.z0uek() * z0frk));
						}
						else
						{
							p2.z0rek((float)((double)z0ZzZzbdh2.z0pek() + (double)(p2.z0yek() - z0ZzZzbdh2.z0pek()) * z0frk));
							p2.z0yek((float)((double)p2.z0iek() * z0frk));
						}
						item13.z0eek(p2);
						continue;
					}
					z0ZzZzpdh p3 = item13.z0nek();
					if (!p3.z0eek())
					{
						if (z0eek().z0ftk())
						{
							p3.z0eek((float)((double)z0ZzZzbdh2.z0oek() + (double)(p3.z0rek() - z0ZzZzbdh2.z0oek()) * z0frk));
						}
						else
						{
							p3.z0rek((float)((double)z0ZzZzbdh2.z0pek() + (double)(p3.z0tek() - z0ZzZzbdh2.z0pek()) * z0frk));
						}
					}
					item13.z0eek(p3);
				}
			}
		}
		num = 0f;
		num2 = 0f - z0cek.z0rek();
		foreach (z0ZzZzrtk item14 in z0ark)
		{
			z0ZzZzytk z0ZzZzytk2 = null;
			foreach (z0ZzZzytk item15 in item14.z0rek())
			{
				item15.z0eek(num, num2);
				if (z0eek().z0jrk().z0jrk())
				{
					item15.z0eek(0f, z0eek().z0jrk().z0drk());
				}
				z0ZzZzytk2?.z0rek(item15.z0nek());
				z0ZzZzytk2 = item15;
			}
		}
	}

	private void z0eek(z0ZzZzjpk p0, string p1, double p2, Color p3, z0ZzZzbdh p4, int p5)
	{
		using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
		if (!z0eek().z0ftk())
		{
			z0ZzZzlsh2.z0rek(StringAlignment.Near);
		}
		else
		{
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
		}
		z0ZzZzlsh2.z0eek(StringAlignment.Center);
		z0ZzZzlsh2.z0eek((z0ZzZzksh)4096);
		if (z0eek().z0jtk())
		{
			z0ZzZzbdh p6 = new z0ZzZzbdh((float)p2, p4.z0nek(), p5, z0eek().z0zrk());
			z0ZzZzlsh2.z0rek(StringAlignment.Near);
			z0ZzZzlsh2.z0eek(z0eek().z0nrk());
			z0ZzZzksh z0ZzZzksh2 = z0ZzZzlsh2.z0yek();
			z0ZzZzlsh2.z0eek(z0ZzZzksh2 | (z0ZzZzksh)2);
			p0.z0eek(p1, z0eek().z0gtk(), p3, p6, z0ZzZzlsh2);
			z0ZzZzlsh2.z0eek(z0ZzZzksh2);
		}
		else
		{
			z0ZzZzbdh p7 = new z0ZzZzbdh((float)p2, p4.z0nek(), p5, z0eek().z0zrk());
			z0ZzZzlsh2.z0eek(z0eek().z0nrk());
			p0.z0eek(p1, z0eek().z0gtk(), p3, p7, z0ZzZzlsh2);
		}
	}

	public void z0eek(float p0)
	{
		z0lrk.z0tek(p0);
	}

	public float z0oek()
	{
		return z0lrk.z0iek();
	}

	public void z0rek(float p0)
	{
		z0lrk.z0yek(p0);
	}

	private void z0eek(z0ZzZzytk p0, z0ZzZzjpk p1, z0ZzZzbdh p2)
	{
		ShapeTypes shapeTypes = p0.z0rek();
		if (shapeTypes == ShapeTypes.None || p0.z0rrk == null)
		{
			return;
		}
		int num = p0.z0xek();
		if (num <= 0)
		{
			num = p0.z0rrk.z0nek();
		}
		if (shapeTypes == ShapeTypes.Default)
		{
			shapeTypes = p0.z0rrk.z0vek();
		}
		if (shapeTypes == ShapeTypes.Default || shapeTypes == ShapeTypes.None || num <= 0 || float.IsNaN(p0.z0nek().z0tek()))
		{
			return;
		}
		z0ZzZzndh p3 = new z0ZzZzndh((int)(p0.z0nek().z0rek() - (float)(num / 2)), (int)(p0.z0nek().z0tek() - (float)(num / 2)), num, num);
		p0.z0eek(new z0ZzZznfh());
		p0.z0zek().z0eek(p3);
		if (p2.z0bek() || p2.z0eek(p3))
		{
			z0ZzZzfmk z0ZzZzfmk2 = new z0ZzZzfmk();
			z0ZzZzfmk2.z0eek(new z0ZzZzbdh(p3.z0pek(), p3.z0mek(), p3.z0iek(), p3.z0oek()));
			z0ZzZzfmk2.z0eek(shapeTypes);
			if (p0.z0rrk.z0vek() == ShapeTypes.Cross || p0.z0rrk.z0vek() == ShapeTypes.XCross)
			{
				z0ZzZzfmk2.z0eek(p0.z0rrk.z0tek());
				z0ZzZzfmk2.z0eek(p1);
			}
			else
			{
				z0ZzZzfmk2.z0eek(p0.z0rrk.z0cek());
				z0ZzZzfmk2.z0tek(p1);
			}
		}
	}

	public z0ZzZzbdh z0pek()
	{
		return z0lrk;
	}

	public double z0mek()
	{
		return z0hrk;
	}

	public z0ZzZzotk z0nek()
	{
		return z0qrk;
	}

	public void z0eek(bool p0)
	{
		z0krk = p0;
	}

	private Color z0eek(z0ZzZzytk p0)
	{
		Color color = Color.Blue;
		if (p0 != null && p0.z0rrk != null)
		{
			if (p0.z0pek().A != 0)
			{
				color = p0.z0pek();
			}
			else if (p0.z0rrk != null)
			{
				color = p0.z0rrk.z0mek();
			}
		}
		if (p0.z0yek() == ChartStyleConsts.Bar && z0eek().z0ork() < 1.0 && z0eek().z0ork() >= 0.0)
		{
			color = Color.FromArgb((int)(255.0 * z0eek().z0ork()), color);
		}
		return color;
	}

	public void z0eek(z0ZzZzttk p0)
	{
		z0ark = p0;
	}

	public void z0tek(float p0)
	{
		z0lrk.z0rek(p0);
	}

	public virtual void z0rek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		if (z0eek() == null || z0eek().z0krk() <= 0)
		{
			return;
		}
		z0ZzZzbdh p2 = z0cek.z0eek();
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh.z0xek;
		if (!p1.z0bek())
		{
			z0ZzZzbdh2 = new z0ZzZzbdh(p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek());
		}
		using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
		z0ZzZzlsh2.z0rek(StringAlignment.Far);
		z0ZzZzlsh2.z0eek(StringAlignment.Center);
		z0ZzZzlsh2.z0eek((z0ZzZzksh)4096);
		using (z0ZzZzudh p3 = z0eek().z0ltk().z0yek())
		{
			using z0ZzZzzdh brush = new z0ZzZzzdh(z0eek().z0mrk());
			foreach (z0ZzZzstk item in z0eek().z0mek())
			{
				if (!item.z0bek())
				{
					continue;
				}
				double num = Math.Round(item.z0eek(), 4);
				double num2 = Math.Round(item.z0rek(), 4);
				double num3 = Math.Round(item.z0pek(), 4);
				for (double num4 = num; num4 <= num2; num4 += num3)
				{
					string text = null;
					if (item.z0mrk != null && item.z0mrk.Count > 0)
					{
						double num5 = Math.Round(num4 - num, 4);
						double num6 = Math.Round(num3, 4);
						int num7 = (int)Math.Round(num5 / num6, 0);
						if (num7 >= item.z0mrk.Count)
						{
							num7 %= item.z0mrk.Count;
						}
						text = item.z0mrk[num7];
					}
					else
					{
						text = z0eek(num4, z0eek().z0srk());
					}
					double p4 = (num4 - item.z0eek()) / (item.z0rek() - item.z0eek());
					if (z0eek().z0ftk())
					{
						int num8 = (int)z0cek.z0eek(p4, 1.0);
						if (text != null && text.Length > 0)
						{
							z0ZzZzlsh2.z0rek(z0eek().z0nek());
							z0ZzZzlsh2.z0eek(StringAlignment.Center);
							z0ZzZzbdh z0ZzZzbdh3 = new z0ZzZzbdh(item.z0tek().z0oek(), num8 - z0eek().z0zrk() / 2, item.z0drk(), z0eek().z0zrk());
							if (z0ZzZzbdh2.z0bek() || z0ZzZzbdh2.z0tek(z0ZzZzbdh3))
							{
								p0.DrawString(text, z0eek().z0gtk().Value, brush, z0ZzZzbdh3, z0ZzZzlsh2);
							}
						}
					}
					else
					{
						int num9 = (int)z0cek.z0rek(p4, 1.0);
						if (text != null && text.Length > 0)
						{
							double p5 = (num4 + item.z0pek()) / (item.z0rek() - item.z0eek());
							int num10 = (int)z0cek.z0rek(p5, 1.0);
							z0eek(p0, text, num9, z0eek().z0mrk(), p2, num10 - num9);
						}
					}
				}
			}
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
			if (z0eek().z0ftk())
			{
				for (int i = 0; i < z0grk; i++)
				{
					double num11 = (double)p2.z0oek() + ((double)z0eek().z0ktk() * 0.0 + (double)(z0wrk * i)) * z0frk;
					int num12 = (int)(new z0ZzZzbdh((float)num11, p2.z0nek(), (float)((double)z0wrk * z0frk), z0eek().z0zrk()).z0mek() + (float)z0srk.z0rek());
					if (z0eek(z0cek.z0eek(), num12, -2147483648))
					{
						z0cek.z0rek(num12, p0, p3);
					}
					string text2 = null;
					foreach (z0ZzZzrtk item2 in z0ark)
					{
						if (i < item2.z0rek().Count)
						{
							text2 = item2.z0rek()[i].z0iek();
							if (text2 != null && text2.Length > 0)
							{
								break;
							}
							text2 = null;
						}
					}
					if (text2 != null)
					{
						z0eek(p0, text2, num11, z0eek().z0mrk(), p2, (int)((double)z0wrk * z0frk));
					}
				}
			}
			else
			{
				for (int j = 0; j < z0grk; j++)
				{
					double num13 = (double)p2.z0pek() + ((double)z0eek().z0ktk() * 0.0 + (double)(z0wrk * j)) * z0frk;
					z0ZzZzbdh z0ZzZzbdh4 = new z0ZzZzbdh(p2.z0oek() - (float)z0eek().z0irk(), (float)num13, z0eek().z0irk(), (float)((double)z0wrk * z0frk));
					int num14 = (int)z0ZzZzbdh4.z0nek() + z0srk.z0frk();
					if (z0eek(z0cek.z0eek(), -2147483648, num14))
					{
						z0cek.z0eek(num14, p0, p3);
					}
					string text3 = null;
					foreach (z0ZzZzrtk item3 in z0yek())
					{
						if (j < item3.z0rek().Count)
						{
							text3 = item3.z0rek()[j].z0iek();
							if (text3 != null && text3.Length > 0)
							{
								break;
							}
							text3 = null;
						}
					}
					if (text3 != null)
					{
						z0ZzZzlsh2.z0rek(z0eek().z0nek());
						if (z0ZzZzbdh2.z0bek() || z0ZzZzbdh2.z0tek(z0ZzZzbdh4))
						{
							p0.DrawString(text3, z0eek().z0gtk().Value, brush, z0ZzZzbdh4, z0ZzZzlsh2);
						}
					}
				}
			}
		}
		using z0ZzZzudh z0ZzZzudh2 = z0eek().z0iek().z0yek();
		float num15 = 1f / (float)z0eek().z0krk();
		for (int k = 0; k < z0eek().z0krk() - 1; k++)
		{
			float num16 = (float)(k + 1) * num15;
			if (z0eek().z0ftk())
			{
				int num17 = (int)z0cek.z0eek(num16, 1.0) + z0srk.z0frk();
				if (z0eek().z0yek() != null)
				{
					int num18 = k;
					if (num18 >= z0eek().z0yek().z0tek().Count)
					{
						num18 %= z0eek().z0yek().z0tek().Count;
					}
					z0ZzZzudh2.z0eek(z0eek().z0yek().z0tek()[num18].Value);
				}
				if (z0eek(z0cek.z0eek(), -2147483648, num17))
				{
					z0cek.z0eek(num17, p0, z0ZzZzudh2);
				}
				continue;
			}
			int num19 = (int)z0cek.z0rek(num16, 1.0) + z0srk.z0rek();
			if (z0eek().z0yek() != null)
			{
				int num20 = k;
				if (num20 >= z0eek().z0yek().z0tek().Count)
				{
					num20 %= z0eek().z0yek().z0tek().Count;
				}
				z0ZzZzudh2.z0eek(z0eek().z0yek().z0tek()[num20].Value);
			}
			if (z0eek(z0cek.z0eek(), num19, -2147483648))
			{
				z0cek.z0rek(num19, p0, z0ZzZzudh2);
			}
		}
	}

	public float z0bek()
	{
		return z0lrk.z0oek();
	}

	private double z0eek(double p0, z0ZzZzytk p1)
	{
		z0ZzZzstk z0ZzZzstk2 = z0eek().z0mek().z0eek(p1.z0rrk.z0lrk());
		if (z0ZzZzstk2 == null)
		{
			if (z0eek().z0mek().Count <= 0)
			{
				z0ZzZzqok.z0rek.z0sh("没有找到与数据点对应的Y轴");
				return 0.0;
			}
			z0ZzZzstk2 = z0eek().z0mek()[0];
		}
		if (z0ZzZzbok.z0eek(p0))
		{
			return 0.0;
		}
		if (z0eek().z0rrk())
		{
			if (p1 == null)
			{
				return p0 / (z0ZzZzstk2.z0rek() - z0ZzZzstk2.z0eek());
			}
			double num = z0eek(p1.z0mek()).z0eek();
			return p0 / num;
		}
		if (z0ZzZzstk2.z0rek() <= z0ZzZzstk2.z0eek())
		{
			return 0.0;
		}
		double num2 = (p0 - z0ZzZzstk2.z0eek()) / (z0ZzZzstk2.z0rek() - z0ZzZzstk2.z0eek());
		if (num2 < 0.0)
		{
			num2 = 0.0;
		}
		if (num2 > 1.0)
		{
			num2 = 1.0;
		}
		return num2;
	}

	public z0ZzZzytk z0eek(float p0, float p1)
	{
		foreach (z0ZzZzrtk item in z0yek())
		{
			foreach (z0ZzZzytk item2 in item.z0rek())
			{
				if (item2.z0zek() != null && item2.z0zek().z0tek(p0, p1))
				{
					return item2;
				}
			}
		}
		return null;
	}

	public void z0eek(z0ZzZzqtk p0)
	{
		z0srk = p0;
	}

	public z0ZzZzutk z0eek(int p0)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("BarIndex 必须大于 0");
		}
		z0ZzZzutk z0ZzZzutk2 = new z0ZzZzutk();
		foreach (z0ZzZzrtk item in z0yek())
		{
			if (item.z0rek().Count > p0)
			{
				z0ZzZzutk2.Add(item.z0rek()[p0]);
			}
		}
		return z0ZzZzutk2;
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		z0lrk = p0;
	}

	public void z0yek(float p0)
	{
		z0lrk.z0eek(p0);
	}

	public double z0vek()
	{
		return z0xek;
	}
}
