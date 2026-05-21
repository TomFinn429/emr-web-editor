using System;
using DCSoft.Chart;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzlyk : IDisposable
{
	private z0ZzZzotk z0lrk = new z0ZzZzotk();

	private z0ZzZzjyk z0krk;

	private double z0jrk;

	public z0ZzZzjyk z0hrk;

	private z0ZzZzztk z0grk = new z0ZzZzztk();

	private z0ZzZzbdh z0frk = z0ZzZzbdh.z0xek;

	private z0ZzZzbdh z0drk = z0ZzZzbdh.z0xek;

	private bool z0srk;

	public z0ZzZzbdh z0eek()
	{
		return z0drk;
	}

	protected void z0eek(z0ZzZzjpk p0)
	{
		foreach (z0ZzZzkyk item in z0yek())
		{
			item.z0eek(p0);
		}
	}

	public float z0rek()
	{
		return z0eek().z0pek();
	}

	protected void z0rek(z0ZzZzjpk p0)
	{
		if (z0hrk == null || z0hrk.Count <= 0)
		{
			return;
		}
		z0ZzZzkyk z0ZzZzkyk2 = z0hrk[0];
		if (z0ZzZzkyk2.z0trk() > 90f && z0ZzZzkyk2.z0trk() <= 270f && z0ZzZzkyk2.z0trk() + z0ZzZzkyk2.z0pek() > 450f)
		{
			z0ZzZzkyk[] array = z0ZzZzkyk2.z0eek(0f);
			z0hrk[0] = array[0];
			if (array[1].z0pek() > 0f)
			{
				z0hrk.Add(array[1]);
			}
		}
		else if ((z0ZzZzkyk2.z0trk() > 270f && z0ZzZzkyk2.z0trk() + z0ZzZzkyk2.z0pek() > 450f) || (z0ZzZzkyk2.z0trk() < 90f && z0ZzZzkyk2.z0trk() + z0ZzZzkyk2.z0pek() > 270f))
		{
			z0ZzZzkyk[] array2 = z0ZzZzkyk2.z0eek(180f);
			z0hrk[0] = array2[1];
			if (array2[0].z0pek() > 0f)
			{
				z0hrk.Add(array2[0]);
			}
		}
		foreach (z0ZzZzkyk item in z0hrk)
		{
			item.z0tek(p0);
		}
	}

	public float z0tek()
	{
		return z0eek().z0uek();
	}

	public z0ZzZzjyk z0yek()
	{
		if (z0krk == null)
		{
			z0krk = new z0ZzZzjyk(this);
		}
		return z0krk;
	}

	public z0ZzZzcdh z0uek()
	{
		float num = 1f + z0bek();
		float num2 = z0xek().z0uek() / num;
		float num3 = z0xek().z0iek() / num - (float)z0oek().z0rek();
		return new z0ZzZzcdh((int)num2, (int)num3);
	}

	public z0ZzZzcdh z0iek()
	{
		float num = z0bek();
		float num2 = (float)z0uek().z0rek() * num;
		float num3 = (float)z0uek().z0tek() * num;
		return new z0ZzZzcdh((int)num2, (int)num3);
	}

	public void z0tek(z0ZzZzjpk p0)
	{
		if (z0xek().z0iek() <= (float)z0oek().z0rek())
		{
			return;
		}
		z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
		z0ZzZzlsh2.z0rek(StringAlignment.Center);
		z0ZzZzlsh2.z0eek(StringAlignment.Center);
		for (int i = 0; i < z0yek().Count; i++)
		{
			z0ZzZzkyk z0ZzZzkyk2 = z0yek()[i];
			if (z0ZzZzkyk2.z0pek() == 0f)
			{
				continue;
			}
			double num = z0eek(z0ZzZzkyk2);
			z0ZzZzndh z0ZzZzndh2 = z0ZzZzkyk2.z0rek_jiejie20260327142557();
			if (num > 0.0 && num < 180.0)
			{
				z0ZzZzndh2.z0rek(0, z0oek().z0rek());
			}
			z0ZzZzpdh p1 = z0ZzZzdyk.z0eek(z0ZzZzndh2, num);
			z0ZzZzpdh z0ZzZzpdh2 = z0eek(num, z0ZzZzndh2);
			if (z0ZzZzpdh.z0eek(z0ZzZzpdh2, z0ZzZzpdh.z0yek))
			{
				continue;
			}
			z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek(z0ZzZzkyk2.z0rrk(), z0oek().z0uek().z0eek(), 10000);
			float num2 = z0ZzZzxdh2.z0rek() + 5f;
			float num3 = z0ZzZzxdh2.z0tek() * 1.2f;
			z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(new z0ZzZzpdh(z0ZzZzpdh2.z0rek(), z0ZzZzpdh2.z0tek()), new z0ZzZzxdh(num2, num3));
			if (num >= 240.0 && num < 300.0)
			{
				z0ZzZzbdh2.z0tek((0f - num2) / 2f, 0f - num3);
			}
			else if (num >= 300.0 && num < 360.0)
			{
				z0ZzZzbdh2.z0tek(0f, (0f - num3) / 2f);
			}
			else if (num >= 0.0 && num < 60.0)
			{
				z0ZzZzbdh2.z0tek(0f, (0f - num3) / 2f);
			}
			else if (num >= 60.0 && num < 120.0)
			{
				z0ZzZzbdh2.z0tek((0f - num2) / 2f, 0f);
			}
			else if (num >= 120.0 && num < 240.0)
			{
				z0ZzZzbdh2.z0tek(0f - num2, (0f - num3) / 2f);
			}
			bool flag = false;
			if (z0ZzZzbdh2.z0oek() < z0eek().z0oek())
			{
				z0ZzZzbdh2.z0eek(z0eek().z0oek());
				flag = true;
			}
			if (z0ZzZzbdh2.z0mek() > z0eek().z0mek())
			{
				z0ZzZzbdh2.z0eek(z0ZzZzbdh2.z0tek() - (z0ZzZzbdh2.z0mek() - z0eek().z0mek()));
				flag = true;
			}
			if (flag && !z0ZzZzbdh2.z0rek(p1))
			{
				if (p1.z0tek() == z0ZzZzpdh2.z0tek())
				{
					if (z0ZzZzbdh2.z0mek() < p1.z0rek())
					{
						z0ZzZzpdh2.z0eek(z0ZzZzbdh2.z0mek());
					}
					else
					{
						z0ZzZzpdh2.z0eek(z0ZzZzbdh2.z0oek());
					}
				}
				else
				{
					float num4 = (z0ZzZzpdh2.z0tek() - p1.z0tek()) / (z0ZzZzpdh2.z0rek() - p1.z0rek());
					float num5 = p1.z0tek() - num4 * p1.z0rek();
					z0ZzZzpdh[] obj = new z0ZzZzpdh[4]
					{
						new z0ZzZzpdh((z0ZzZzbdh2.z0pek() - num5) / num4, z0ZzZzbdh2.z0pek()),
						new z0ZzZzpdh((z0ZzZzbdh2.z0nek() - num5) / num4, z0ZzZzbdh2.z0nek()),
						new z0ZzZzpdh(z0ZzZzbdh2.z0oek(), num4 * z0ZzZzbdh2.z0oek() + num5),
						new z0ZzZzpdh(z0ZzZzbdh2.z0mek(), num4 * z0ZzZzbdh2.z0mek() + num5)
					};
					z0ZzZzpdh z0ZzZzpdh3 = z0ZzZzpdh2;
					float num6 = 10000000f;
					z0ZzZzpdh[] array = obj;
					for (int j = 0; j < array.Length; j++)
					{
						z0ZzZzpdh z0ZzZzpdh4 = array[j];
						if (!(z0ZzZzpdh4.z0rek() < z0ZzZzbdh2.z0oek()) && !(z0ZzZzpdh4.z0rek() > z0ZzZzbdh2.z0mek()) && !(z0ZzZzpdh4.z0tek() < z0ZzZzbdh2.z0pek()) && !(z0ZzZzpdh4.z0tek() > z0ZzZzbdh2.z0nek()))
						{
							float num7 = (z0ZzZzpdh4.z0tek() - p1.z0tek()) * (z0ZzZzpdh4.z0tek() - p1.z0tek()) + (z0ZzZzpdh4.z0rek() - p1.z0rek()) * (z0ZzZzpdh4.z0rek() - p1.z0rek());
							if (num7 < num6)
							{
								num6 = num7;
								z0ZzZzpdh3 = z0ZzZzpdh4;
							}
						}
					}
					z0ZzZzpdh2 = z0ZzZzpdh3;
				}
			}
			p0.z0eek(z0oek().z0uek().z0oek(), z0ZzZzndh.z0tek(z0ZzZzbdh2));
			if (!z0ZzZzbdh2.z0rek(p1))
			{
				using z0ZzZzudh p2 = new z0ZzZzudh(z0ZzZzvok.z0eek(z0ZzZzkyk2.z0krk(), -0.3f), z0oek().z0uek().z0tek());
				p0.z0eek(p2, p1.z0rek(), p1.z0tek(), (int)z0ZzZzpdh2.z0rek(), (int)z0ZzZzpdh2.z0tek());
			}
			p0.z0rek(z0oek().z0uek().z0mek(), z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek());
			p0.z0eek(z0ZzZzkyk2.z0rrk(), z0oek().z0uek().z0eek(), z0oek().z0uek().z0rek(), z0ZzZzbdh2, z0ZzZzlsh2);
		}
	}

	public z0ZzZzztk z0oek()
	{
		return z0grk;
	}

	public void z0eek(float p0)
	{
		z0drk.z0eek(p0);
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		z0drk = p0;
	}

	protected virtual void z0pek()
	{
		try
		{
			z0eek(p0: false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public float z0mek()
	{
		return z0eek().z0oek();
	}

	public void z0yek(z0ZzZzjpk p0)
	{
		using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
		z0ZzZzlsh2.z0rek(StringAlignment.Near);
		z0ZzZzlsh2.z0eek(StringAlignment.Center);
		foreach (z0ZzZzkyk item in z0yek())
		{
			if (item.z0rrk() != null && item.z0rrk().Length > 0 && item.z0pek() > 0f)
			{
				z0ZzZzpdh z0ZzZzpdh2 = item.z0ork();
				p0.z0eek(item.z0rrk(), z0oek().z0uek().z0eek(), z0oek().z0uek().z0rek(), z0ZzZzpdh2.z0rek(), z0ZzZzpdh2.z0tek());
			}
		}
	}

	protected void z0uek(z0ZzZzjpk p0)
	{
		foreach (z0ZzZzkyk item in z0yek())
		{
			item.z0iek(p0);
		}
	}

	private void z0nek()
	{
		float num = z0oek().z0bek();
		foreach (z0ZzZzkyk item in z0yek())
		{
			if (z0cek() == 0.0)
			{
				item.z0tek(360 / z0yek().Count);
			}
			else
			{
				item.z0tek((float)(item.z0prk() / z0cek() * 360.0));
			}
			item.z0rek_jiejie20260327142557(num % 360f);
			num += item.z0xek();
		}
	}

	public float z0bek()
	{
		float num = 0f;
		foreach (z0ZzZzkyk item in z0yek())
		{
			if (item.z0jrk() > num)
			{
				num = item.z0jrk();
			}
		}
		return num;
	}

	public void z0rek(float p0)
	{
		z0drk.z0tek(p0);
	}

	public void z0iek(z0ZzZzjpk p0)
	{
		z0hrk = new z0ZzZzjyk(this);
		if (z0yek().Count <= 0)
		{
			return;
		}
		z0ZzZzbtk z0ZzZzbtk2 = z0oek().z0cek();
		for (int i = 0; i < z0yek().Count; i++)
		{
			z0yek()[i].z0eek(z0ZzZzbtk2.z0tek(i));
		}
		z0zek().z0eek(z0oek().z0vek());
		z0ZzZzbdh z0ZzZzbdh2 = z0eek();
		if (z0zek().z0yek().z0eek())
		{
			z0zek().z0rek().Clear();
			foreach (z0ZzZzkyk item in z0yek())
			{
				z0ZzZzmtk z0ZzZzmtk2 = new z0ZzZzmtk();
				z0ZzZzmtk2.z0eek(item.z0rrk());
				z0ZzZzmtk2.z0eek(item.z0krk());
				z0ZzZzmtk2.z0eek(ShapeTypes.Rectangle);
				z0zek().z0rek().Add(z0ZzZzmtk2);
			}
			z0ZzZzbdh2 = z0zek().z0rek(p0, z0ZzZzbdh2);
			z0zek().z0rek(p0);
		}
		if (z0oek().z0pek().z0bek())
		{
			z0ZzZzbdh2 = z0oek().z0pek().z0rek(z0ZzZzbdh2);
		}
		if (z0oek().z0lrk() > 0 && (float)z0oek().z0lrk() < z0ZzZzbdh2.z0iek())
		{
			z0ZzZzbdh2.z0rek(z0ZzZzbdh2.z0yek() + (z0ZzZzbdh2.z0iek() - (float)z0oek().z0lrk()) / 2f);
			z0ZzZzbdh2.z0yek(z0oek().z0lrk());
		}
		if (!z0oek().z0oek())
		{
			if (z0ZzZzbdh2.z0uek() > z0ZzZzbdh2.z0iek())
			{
				z0ZzZzbdh2.z0tek((z0ZzZzbdh2.z0uek() - z0ZzZzbdh2.z0iek()) / 2f, 0f);
				z0ZzZzbdh2.z0tek(z0ZzZzbdh2.z0iek());
			}
			else
			{
				z0ZzZzbdh2.z0tek(0f, (z0ZzZzbdh2.z0iek() - z0ZzZzbdh2.z0uek()) / 2f);
				z0ZzZzbdh2.z0yek(z0ZzZzbdh2.z0uek());
			}
		}
		if (z0oek().z0uek().Visible && z0oek().z0uek().z0pek() != PieLabelType.InLabel)
		{
			int num = (int)(p0.z0eek("XXX", z0oek().z0uek().z0eek()).z0tek() * 1.5f) + z0oek().z0uek().z0uek();
			z0ZzZzbdh2.z0tek(70f, num);
			z0ZzZzbdh2.z0tek(z0ZzZzbdh2.z0uek() - 140f);
			z0ZzZzbdh2.z0yek(z0ZzZzbdh2.z0iek() - (float)(num * 2));
		}
		z0rek(z0ZzZzbdh2);
		if (z0xek().z0uek() <= 0f || z0xek().z0iek() <= (float)z0oek().z0rek())
		{
			return;
		}
		z0nek();
		foreach (z0ZzZzkyk item2 in z0yek())
		{
			item2.z0uek();
			if (item2.z0pek() != 0f)
			{
				z0hrk.Add(item2);
			}
		}
		z0ZzZzgyk z0ZzZzgyk2 = new z0ZzZzgyk();
		z0hrk.Sort(z0ZzZzgyk2);
	}

	public void Dispose()
	{
		z0eek(p0: true);
		GC.SuppressFinalize(this);
	}

	public float z0vek()
	{
		return z0eek().z0iek();
	}

	public double z0cek()
	{
		z0jrk = 0.0;
		foreach (z0ZzZzkyk item in z0yek())
		{
			z0jrk += item.z0prk();
		}
		return z0jrk;
	}

	public void z0eek(z0ZzZzztk p0)
	{
		z0grk = p0;
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		if (z0yek().Count <= 0 || z0eek().z0uek() <= 0f || z0eek().z0iek() <= 0f)
		{
			return;
		}
		if (z0oek().z0pek().z0jrk() && z0oek().z0pek().z0zek())
		{
			z0oek().z0pek().z0rek(p0, p1);
		}
		if (z0zek().z0yek().z0eek())
		{
			z0zek().z0eek(p0, p1);
		}
		if (z0xek().z0uek() <= 0f || z0xek().z0iek() <= (float)z0oek().z0rek())
		{
			return;
		}
		z0uek(p0);
		if ((float)z0oek().z0rek() > 0f)
		{
			z0rek(p0);
		}
		z0eek(p0);
		if (z0oek().z0uek().Visible)
		{
			switch (z0oek().z0uek().z0pek())
			{
			case PieLabelType.InLabel:
				z0yek(p0);
				break;
			case PieLabelType.OutLabel:
				z0tek(p0);
				break;
			}
		}
	}

	public z0ZzZzbdh z0xek()
	{
		return z0frk;
	}

	public void z0eek(z0ZzZzotk p0)
	{
		z0lrk = p0;
	}

	protected virtual void z0eek(bool p0)
	{
		if (z0srk)
		{
			return;
		}
		if (p0)
		{
			foreach (z0ZzZzkyk item in z0yek())
			{
				item.Dispose();
			}
		}
		z0srk = true;
	}

	private double z0eek(z0ZzZzkyk p0)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 1.0;
		float num5 = p0.z0trk() + p0.z0pek() / 2f;
		float num6 = num5 % 90f;
		float num7 = (num5 + 360f) % 360f;
		num2 = (double)(num5 - num6) + 0.01;
		num3 = num2 + 89.98;
		num4 = (((!(num7 > 0f) || !(num7 <= 90f)) && (!(num7 > 180f) || !(num7 <= 270f))) ? (-1.0) : 1.0);
		num = ((p0.z0rek_jiejie20260327142557().z0iek() < p0.z0rek_jiejie20260327142557().z0oek()) ? ((double)p0.z0trk() + (double)p0.z0pek() / 2.0 - num4 * (double)p0.z0pek() / 2.0 * (1.0 - (double)p0.z0rek_jiejie20260327142557().z0iek() / (double)p0.z0rek_jiejie20260327142557().z0oek())) : ((double)p0.z0trk() + (double)p0.z0pek() / 2.0 + num4 * (double)p0.z0pek() / 2.0 * (1.0 - (double)p0.z0rek_jiejie20260327142557().z0oek() / (double)p0.z0rek_jiejie20260327142557().z0iek())));
		if (num > (double)(p0.z0trk() + p0.z0pek() * 3f / 4f))
		{
			num = p0.z0trk() + p0.z0pek() * 3f / 4f;
		}
		if (num < (double)(p0.z0trk() + p0.z0pek() / 4f))
		{
			num = p0.z0trk() + p0.z0pek() / 4f;
		}
		if (num > num3)
		{
			num = num3;
		}
		if (num < num2)
		{
			num = num2;
		}
		return num % 360.0;
	}

	public void z0tek(float p0)
	{
		z0drk.z0yek(p0);
	}

	public void z0rek(z0ZzZzbdh p0)
	{
		z0frk = p0;
	}

	public void z0yek(float p0)
	{
		z0drk.z0rek(p0);
	}

	public void z0eek(z0ZzZzjyk p0)
	{
		z0krk = p0;
	}

	public z0ZzZzotk z0zek()
	{
		return z0lrk;
	}

	private z0ZzZzpdh z0eek(double p0, z0ZzZzndh p1)
	{
		float num = p1.z0pek() + p1.z0iek() / 2;
		float num2 = p1.z0mek() + p1.z0oek() / 2;
		z0ZzZzpdh z0ZzZzpdh2 = z0ZzZzdyk.z0eek(p1, p0);
		z0ZzZzpdh result = z0ZzZzpdh.z0yek;
		if (z0ZzZzpdh2.z0tek() == num2)
		{
			result.z0rek(z0ZzZzpdh2.z0tek());
			result.z0eek(p1.z0nek() + z0oek().z0uek().z0uek());
			return z0ZzZzpdh.z0yek;
		}
		double num3 = (z0ZzZzpdh2.z0tek() - num2) / (z0ZzZzpdh2.z0rek() - num);
		double num4 = Math.Sqrt((z0ZzZzpdh2.z0tek() - num2) * (z0ZzZzpdh2.z0tek() - num2) + (z0ZzZzpdh2.z0rek() - num) * (z0ZzZzpdh2.z0rek() - num));
		if (p0 > 90.0 && p0 < 270.0)
		{
			result.z0eek((float)((double)num - Math.Sqrt(((double)z0oek().z0uek().z0uek() + num4) * ((double)z0oek().z0uek().z0uek() + num4) / (1.0 + num3 * num3))));
		}
		else
		{
			result.z0eek((float)((double)num + Math.Sqrt(((double)z0oek().z0uek().z0uek() + num4) * ((double)z0oek().z0uek().z0uek() + num4) / (1.0 + num3 * num3))));
		}
		result.z0rek((float)((double)num2 + num3 * (double)(result.z0rek() - num)));
		return result;
	}
}
