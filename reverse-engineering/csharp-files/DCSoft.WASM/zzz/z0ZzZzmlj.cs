using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DCSoft;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal class z0ZzZzmlj : z0ZzZzygj
{
	[CompilerGenerated]
	private sealed class z0yik
	{
		public z0ZzZzjej z0rek;

		internal z0ZzZzywj z0eek(z0ZzZzpdh p0)
		{
			return z0rek.z0rek(p0.z0rek(), p0.z0tek());
		}
	}

	private readonly z0ZzZzxlj z0zek = new z0ZzZzxlj();

	private readonly z0ZzZzsgj z0lrk;

	private readonly z0ZzZzblj z0krk;

	private z0ZzZzjej z0jrk;

	private float z0hrk;

	private readonly IList<z0ZzZzfxk> z0frk = new List<z0ZzZzfxk>();

	private readonly z0ZzZzbaj z0drk;

	private z0ZzZzjej z0srk;

	private readonly z0ZzZzmsj z0ark;

	private float z0qrk;

	private readonly z0ZzZziwj z0wrk;

	private readonly z0ZzZzxsj z0erk;

	internal z0ZzZznjj z0rek()
	{
		return z0krk.z0tek();
	}

	internal z0ZzZzsgj z0tek()
	{
		return z0lrk;
	}

	private void z0rek(double p0)
	{
		z0ZzZzvlj z0ZzZzvlj2 = z0zek.z0tek();
		if (p0 != z0ZzZzvlj2.z0bek())
		{
			z0lrk.z0yek(p0);
			z0ZzZzvlj2.z0iek(p0);
		}
	}

	internal void z0rek(z0ZzZzbdh p0)
	{
		z0ZzZziwj z0ZzZziwj2 = z0tek(p0);
		if (!z0rek(new z0ZzZzylj(p0, z0ZzZziwj2)))
		{
			z0lrk.z0tek(z0ZzZziwj2);
		}
	}

	internal void z0rek(z0ZzZztfh p0)
	{
		z0ZzZzfxk z0ZzZzfxk2 = z0ZzZzolj.z0eek(p0);
		z0frk.Add(z0ZzZzfxk2);
		z0rek(z0ZzZzfxk2);
	}

	internal void z0yek()
	{
		z0zek.z0rek();
		z0lrk.z0tek();
	}

	internal z0ZzZzblj z0uek()
	{
		return z0krk;
	}

	internal void z0rek(float p0, float p1, float p2, float p3)
	{
		z0yek(new z0ZzZzpdh[2]
		{
			new z0ZzZzpdh(p0, p1),
			new z0ZzZzpdh(p2, p3)
		});
	}

	private void z0iek()
	{
		z0jrk = new z0ZzZzjej(72f / z0qrk, 0.0, 0.0, -72f / z0hrk, z0wrk.z0oek(), z0wrk.z0mek());
		z0srk = z0ZzZzjej.z0rek(z0jrk);
	}

	internal void z0rek(float p0, float p1)
	{
		z0qrk = p0;
		z0hrk = p1;
		z0iek();
	}

	internal z0ZzZzmlj(z0ZzZziwj p0, z0ZzZzmsj p1, z0ZzZzblj p2, float p3, float p4)
	{
		z0ark = p1;
		z0wrk = p0;
		z0rek(p3, p4);
		z0krk = p2;
		z0lrk = new z0ZzZzsgj(p1);
		z0erk = new z0ZzZzxsj(z0lrk);
		z0drk = p2.z0oek().z0yek().z0rek();
	}

	internal void z0rek(z0ZzZzpdh[] p0, byte[] p1, bool p2)
	{
		z0ZzZzjej z0rek = z0vek();
		z0lrk.z0eek(z0eek(p0, p1, (z0ZzZzpdh z0ZzZzpdh2) => z0rek.z0rek(z0ZzZzpdh2.z0rek(), z0ZzZzpdh2.z0tek())), p2);
	}

	internal z0ZzZziwj z0tek(z0ZzZzbdh p0)
	{
		z0ZzZzywj z0ZzZzywj2 = z0rek(new z0ZzZzpdh(Math.Min(p0.z0oek(), p0.z0mek()), Math.Max(p0.z0pek(), p0.z0nek())));
		z0ZzZzywj z0ZzZzywj3 = z0rek(new z0ZzZzpdh(Math.Max(p0.z0oek(), p0.z0mek()), Math.Min(p0.z0pek(), p0.z0nek())));
		return new z0ZzZziwj(z0ZzZzywj2.z0eek(), z0ZzZzywj2.z0rek(), z0ZzZzywj3.z0eek(), z0ZzZzywj3.z0rek());
	}

	internal void z0rek(z0ZzZzjej p0)
	{
		z0lrk.z0rek(z0ZzZzjej.z0rek(z0ZzZzjej.z0rek(z0srk, p0), z0jrk));
	}

	private void z0rek(z0ZzZzqxk p0, double p1)
	{
		z0ZzZzvlj z0ZzZzvlj2 = z0zek.z0tek();
		z0ZzZzvlj2.z0oek(p1);
		bool flag = p0.z0iek() == (z0ZzZzgdh)1;
		if (flag)
		{
			p1 *= 2.0;
		}
		z0ZzZzvlj2.z0uek(flag);
		z0rek(p1);
		z0ZzZzwzk z0ZzZzwzk2 = z0ZzZzikj.z0eek(p0.z0nek(), p1);
		z0ZzZzwzk z0ZzZzwzk3 = z0ZzZzikj.z0eek(p0.z0rek(), p1);
		z0ZzZzvlj2.z0iek(z0ZzZzwzk2);
		z0ZzZzvlj2.z0uek(z0ZzZzwzk3);
		p0.z0mek().z0bak(new z0ZzZzckj(this, z0ZzZzwzk2 != null || z0ZzZzwzk3 != null));
		if (p0.z0eek() != DashStyle.Solid)
		{
			float[] array = p0.z0tek();
			if (array != null)
			{
				int num = array.Length;
				double[] array2 = new double[num];
				if (p1 == 0.0)
				{
					for (int i = 0; i < num; i++)
					{
						array2[i] = z0tek(array[i]);
					}
				}
				else
				{
					for (int j = 0; j < num; j++)
					{
						array2[j] = (double)array[j] * p1;
					}
				}
				z0lrk.z0rek(z0ZzZzkwj.z0eek(array2, p0.z0yek() * p1));
			}
		}
		else if (z0ZzZzvlj2.z0nek() != DashStyle.Solid)
		{
			z0lrk.z0rek(z0ZzZzkwj.z0rek());
		}
		z0ZzZzvlj2.z0eek(p0.z0eek());
		DashCap dashCap = p0.z0pek();
		if (dashCap != z0ZzZzvlj2.z0xek())
		{
			if (dashCap == DashCap.Round)
			{
				z0lrk.z0rek((z0ZzZzxqj)1);
				z0ZzZzvlj2.z0rek((z0ZzZzldh)2);
			}
			else
			{
				z0lrk.z0rek((z0ZzZzxqj)0);
				z0ZzZzvlj2.z0rek((z0ZzZzldh)0);
			}
		}
		z0ZzZzvlj2.z0yek(p0.z0pek());
		switch (p0.z0uek())
		{
		case (z0ZzZzkdh)1:
			if (z0ZzZzvlj2.z0pek() != (z0ZzZzkdh)1)
			{
				z0lrk.z0rek((z0ZzZzlwj)2);
			}
			break;
		case (z0ZzZzkdh)2:
			if (z0ZzZzvlj2.z0pek() != (z0ZzZzkdh)2)
			{
				z0lrk.z0rek((z0ZzZzlwj)1);
			}
			break;
		default:
			if (z0ZzZzvlj2.z0pek() != (z0ZzZzkdh)0 && z0ZzZzvlj2.z0pek() != (z0ZzZzkdh)3)
			{
				z0lrk.z0rek((z0ZzZzlwj)0);
			}
			z0uek(p0.z0oek());
			break;
		}
		z0ZzZzvlj2.z0tek(p0.z0uek());
	}

	internal void z0rek(z0ZzZzfxk p0)
	{
		p0.z0bak(new z0ZzZzyzk(this));
	}

	private void z0rek(bool p0)
	{
		z0ZzZzvlj z0ZzZzvlj2 = z0zek.z0tek();
		double num = z0ZzZzvlj2.z0krk_jiejie20260327142557();
		z0rek((z0ZzZzvlj2.z0zek() && p0) ? (num * 2.0) : num);
	}

	internal z0ZzZzjej z0oek()
	{
		return z0ZzZzjej.z0rek(z0jrk, z0lrk.z0iek());
	}

	internal double z0tek(double p0)
	{
		return z0jrk.z0rek(p0, 0.0).z0eek();
	}

	private IList<z0ZzZzmqj> z0eek(z0ZzZzpdh[] p0, byte[] p1, DCFunc<z0ZzZzpdh, z0ZzZzywj> p2)
	{
		List<z0ZzZzmqj> list = new List<z0ZzZzmqj>();
		z0ZzZzmqj z0ZzZzmqj2 = null;
		for (int i = 0; i < p0.Length; i++)
		{
			z0ZzZzywj p3 = p2(p0[i]);
			switch (p1[i] & 3)
			{
			case 0:
				z0ZzZzmqj2 = new z0ZzZzmqj(p3);
				list.Add(z0ZzZzmqj2);
				break;
			case 1:
				if (z0ZzZzmqj2 == null)
				{
					return list;
				}
				z0ZzZzmqj2.z0eek(p3);
				break;
			case 3:
			{
				if (z0ZzZzmqj2 == null)
				{
					return list;
				}
				z0ZzZzywj p4 = p2(p0[++i]);
				z0ZzZzywj p5 = p2(p0[++i]);
				z0ZzZzmqj2.z0eek(p3, p4, p5);
				break;
			}
			}
			if ((p1[i] & 6) != 0)
			{
				z0ZzZzmqj2?.z0eek(p0: true);
			}
		}
		return list;
	}

	internal void z0rek(z0ZzZzshj p0)
	{
		z0ZzZzvlj z0ZzZzvlj2 = z0zek.z0tek();
		z0ZzZzvlj2.z0uek((z0ZzZztzk)null);
		if (p0.z0tek() == null)
		{
			double[] array = p0.z0rek();
			if (z0ZzZzvlj2.z0uek() == null || !z0rek(z0ZzZzvlj2.z0uek(), array))
			{
				z0ZzZzvlj2.z0uek(array);
				z0lrk.z0tek(p0);
			}
		}
		else
		{
			z0ZzZzvlj2.z0uek((double[])null);
			z0lrk.z0tek(p0);
		}
		z0yek(p0.z0eek());
	}

	private void z0rek(z0ZzZzbqj p0)
	{
		z0lrk.z0rek(p0);
	}

	private bool z0rek(z0ZzZzbjj p0)
	{
		z0ZzZztzk z0ZzZztzk2 = z0zek.z0tek().z0jrk();
		if (z0ZzZztzk2 != null)
		{
			if (z0ZzZztzk2.z0lak(this, p0))
			{
				return true;
			}
			z0rek(z0ZzZztzk2.z0usk(this));
		}
		return false;
	}

	private z0ZzZzywj[] z0rek(z0ZzZzpdh[] p0)
	{
		int num = p0.Length;
		z0ZzZzywj[] array = new z0ZzZzywj[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = z0rek(p0[i]);
		}
		return array;
	}

	internal void z0pek()
	{
		z0zek.z0eek();
		z0lrk.z0mek();
	}

	internal void z0tek(z0ZzZzshj p0)
	{
		z0ZzZzvlj z0ZzZzvlj2 = z0zek.z0tek();
		if (p0.z0eek() != z0ZzZzvlj2.z0vek() && z0drk != (z0ZzZzbaj)1)
		{
			z0rek(z0krk.z0pek().z0eek(p0.z0eek()));
			z0ZzZzvlj2.z0mek(p0.z0eek());
		}
		if (p0.z0tek() == null)
		{
			double[] array = p0.z0rek();
			if (z0ZzZzvlj2.z0cek() == null || !z0rek(z0ZzZzvlj2.z0cek(), array))
			{
				z0ZzZzvlj2.z0iek(array);
				z0lrk.z0rek(p0);
			}
		}
		else
		{
			z0lrk.z0rek(p0);
		}
	}

	internal void z0yek(double p0)
	{
		z0ZzZzvlj z0ZzZzvlj2 = z0zek.z0tek();
		if (p0 != z0ZzZzvlj2.z0oek() && z0drk != (z0ZzZzbaj)1)
		{
			z0rek(z0krk.z0yek().z0eek(p0));
			z0ZzZzvlj2.z0uek(p0);
		}
	}

	internal z0ZzZziwj z0mek()
	{
		return z0wrk;
	}

	private static bool z0tek(z0ZzZzpdh[] p0)
	{
		int num = p0.Length;
		if (num > 1)
		{
			z0ZzZzpdh p1 = p0[0];
			for (int i = 1; i < num; i++)
			{
				if (z0ZzZzpdh.z0rek(p0[i], p1))
				{
					return true;
				}
			}
		}
		return false;
	}

	private z0ZzZzywj z0rek(z0ZzZzpdh p0)
	{
		return z0jrk.z0rek(p0.z0rek(), p0.z0tek());
	}

	private bool z0rek(double[] p0, double[] p1)
	{
		if (p0.Length != p1.Length)
		{
			return false;
		}
		for (int i = 0; i < p0.Length; i++)
		{
			if (p0[i] != p1[i])
			{
				return false;
			}
		}
		return true;
	}

	private void z0nek()
	{
		z0ZzZztzk z0ZzZztzk2 = z0zek.z0tek().z0jrk();
		if (z0ZzZztzk2 != null)
		{
			z0rek(z0ZzZztzk2.z0usk(this));
		}
	}

	internal void z0rek(z0ZzZzqxk p0)
	{
		z0rek(p0, z0tek(p0.z0bek()));
	}

	internal z0ZzZzmhj z0bek()
	{
		return z0krk.z0eek();
	}

	protected override void z0ygk(bool p0)
	{
		if (!p0)
		{
			return;
		}
		z0lrk.Dispose();
		foreach (z0ZzZzfxk item in z0frk)
		{
			item.Dispose();
		}
		z0frk.Clear();
	}

	internal void z0yek(z0ZzZzbdh p0)
	{
		z0rek(p0: true);
		z0ZzZziwj p1 = z0tek(p0);
		if (z0zek.z0tek().z0zek())
		{
			z0lrk.z0mek();
			z0lrk.z0iek(p1);
			z0lrk.z0uek(p1);
			z0lrk.z0tek();
		}
		else
		{
			z0lrk.z0uek(p1);
		}
	}

	internal void z0rek(string[] p0, z0ZzZzddj p1, z0ZzZzbdh p2, z0ZzZzcwj p3, z0ZzZzbdh p4)
	{
		if (p0 != null && p0.Length != 0)
		{
			z0nek();
			IList<z0ZzZzzdj> list = new List<z0ZzZzzdj>(p0.Length);
			z0ZzZzkaj z0ZzZzkaj2 = new z0ZzZzkaj(p1.z0tek(), z0rek(p3, p1), p3.z0oek(), p0.Length > 1);
			foreach (string p5 in p0)
			{
				list.Add(z0ZzZzkaj2.z0rek(p5));
			}
			z0ZzZzbsj p6 = (p4.z0bek() ? new z0ZzZzbsj() : new z0ZzZzosj(z0tek(p4)));
			z0erk.z0rek(list, p1, z0tek(p2), p3, p4: true, p6);
		}
	}

	private z0ZzZzjej z0vek()
	{
		z0ZzZzjej p = z0ZzZzjej.z0rek(z0lrk.z0iek());
		return z0ZzZzjej.z0rek(z0jrk, p);
	}

	internal void z0rek(z0ZzZzudh p0)
	{
		using z0ZzZzqxk p1 = z0ZzZzolj.z0eek(p0);
		z0rek(p1);
	}

	internal void z0rek(Color p0, double p1)
	{
		using z0ZzZzqxk p2 = new z0ZzZzqxk(p0);
		z0rek(p2, p1);
	}

	internal z0ZzZzugj z0cek()
	{
		return z0krk.z0oek();
	}

	internal void z0yek(z0ZzZzpdh[] p0)
	{
		if (z0tek(p0))
		{
			z0rek(p0: false);
			z0ZzZzywj[] array = z0rek(p0);
			z0ZzZzvlj obj = z0zek.z0tek();
			z0ZzZzwzk z0ZzZzwzk2 = obj.z0lrk();
			if (z0ZzZzwzk2 != null)
			{
				z0ZzZzywj z0ZzZzywj2 = array[0];
				z0ZzZzywj z0ZzZzywj3 = array[1];
				array[0] = z0ZzZzwzk2.z0iak(z0ZzZzywj2, z0ZzZzywj3);
				z0ZzZzwzk2.z0uak(z0lrk, z0ZzZzywj2, z0ZzZzywj3);
			}
			z0ZzZzwzk z0ZzZzwzk3 = obj.z0iek();
			if (z0ZzZzwzk3 != null)
			{
				int num = array.Length - 1;
				z0ZzZzywj z0ZzZzywj4 = array[num];
				z0ZzZzywj z0ZzZzywj5 = array[num - 1];
				array[num] = z0ZzZzwzk3.z0iak(z0ZzZzywj4, z0ZzZzywj5);
				z0ZzZzwzk3.z0uak(z0lrk, z0ZzZzywj4, z0ZzZzywj5);
			}
			z0lrk.z0rek(array);
		}
	}

	internal byte[] z0xek()
	{
		return z0lrk.z0oek();
	}

	internal void z0rek(z0ZzZzohj p0, z0ZzZzbdh p1)
	{
		p0.z0wsk(z0lrk, z0tek(p1));
	}

	internal void z0uek(z0ZzZzbdh p0)
	{
		z0ZzZziwj z0ZzZziwj2 = z0tek(p0);
		if (!z0rek(new z0ZzZzyjj(p0, z0ZzZziwj2)))
		{
			z0lrk.z0oek(z0ZzZziwj2);
		}
	}

	internal void z0iek(z0ZzZzbdh p0)
	{
		z0rek(p0: true);
		z0ZzZziwj p1 = z0tek(p0);
		if (z0zek.z0tek().z0zek())
		{
			z0lrk.z0mek();
			z0lrk.z0mek(p1);
			z0lrk.z0rek(p1);
			z0lrk.z0tek();
		}
		else
		{
			z0lrk.z0rek(z0tek(p0));
		}
	}

	internal void z0uek(double p0)
	{
		if (z0zek.z0tek().z0mek() != p0)
		{
			z0lrk.z0rek(p0);
			z0zek.z0tek().z0pek(p0);
		}
	}

	private double z0rek(z0ZzZzcwj p0, z0ZzZzddj p1)
	{
		return z0tek(p0.z0yek()) / p1.z0eek() * 1000.0;
	}

	internal void z0rek(z0ZzZztzk p0)
	{
		z0zek.z0tek().z0uek(p0);
	}

	internal void z0oek(z0ZzZzbdh p0)
	{
		z0ZzZzjej z0ZzZzjej2 = z0vek();
		if ((z0ZzZzjej2.z0pek() == 0.0 && z0ZzZzjej2.z0oek() == 0.0) || (z0ZzZzjej2.z0yek() == 0.0 && z0ZzZzjej2.z0nek() == 0.0))
		{
			z0lrk.z0iek(new z0ZzZziwj(z0ZzZzjej2.z0rek(p0.z0oek(), p0.z0pek()), z0ZzZzjej2.z0rek(p0.z0mek(), p0.z0nek())));
			return;
		}
		double p1 = p0.z0oek();
		double p2 = p0.z0nek();
		double p3 = p0.z0pek();
		double p4 = p0.z0mek();
		z0ZzZzywj[] array = z0ZzZzjej2.z0eek(new z0ZzZzywj[4]
		{
			new z0ZzZzywj(p1, p3),
			new z0ZzZzywj(p1, p2),
			new z0ZzZzywj(p4, p2),
			new z0ZzZzywj(p4, p3)
		});
		z0ZzZzmqj z0ZzZzmqj2 = new z0ZzZzmqj(array[0]);
		for (int i = 1; i < 4; i++)
		{
			z0ZzZzmqj2.z0eek(array[i]);
		}
		z0ZzZzmqj2.z0eek(p0: true);
		z0lrk.z0tek(z0ZzZzmqj2);
	}
}
