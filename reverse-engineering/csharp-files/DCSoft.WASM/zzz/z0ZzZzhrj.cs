using System;
using System.Collections;
using DCSoft.Drawing;

namespace zzz;

public class z0ZzZzhrj : z0ZzZznpk
{
	protected new bool z0tek;

	private new readonly int z0yek = -1;

	protected z0ZzZzerj z0uek;

	internal new bool z0iek;

	public override z0ZzZzodh z0gwk(int p0, int p1)
	{
		if (z0tek)
		{
			z0ZzZzpdh z0ZzZzpdh2 = z0eek((float)p0, (float)p1);
			return new z0ZzZzodh((int)z0ZzZzpdh2.z0rek(), (int)z0ZzZzpdh2.z0tek());
		}
		return base.z0gwk(p0, p1);
	}

	public new bool z0eek()
	{
		return z0tek;
	}

	public new z0ZzZzpdh z0eek(float p0, float p1)
	{
		z0ZzZzsmk z0ZzZzsmk2 = null;
		z0ZzZzsmk z0ZzZzsmk3 = null;
		z0ZzZzsmk z0ZzZzsmk4 = null;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzsmk z0ZzZzsmk5 = (z0ZzZzsmk)enumerator.Current;
				if (z0ZzZzsmk5.z0oek())
				{
					z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzsmk5.z0mek();
					if (z0ZzZzbdh2.z0eek(p0, p1))
					{
						return z0ZzZzsmk5.z0bqk(p0, p1);
					}
					if (p1 >= z0ZzZzbdh2.z0pek() && p1 <= z0ZzZzbdh2.z0nek())
					{
						z0ZzZzsmk4 = z0ZzZzsmk5;
						break;
					}
					if (p1 < z0ZzZzbdh2.z0pek() && (z0ZzZzsmk3 == null || z0ZzZzbdh2.z0pek() < z0ZzZzsmk3.z0mek().z0pek()))
					{
						z0ZzZzsmk3 = z0ZzZzsmk5;
					}
					if (p1 > z0ZzZzbdh2.z0nek() && (z0ZzZzsmk2 == null || z0ZzZzbdh2.z0nek() > z0ZzZzsmk2.z0mek().z0nek()))
					{
						z0ZzZzsmk2 = z0ZzZzsmk5;
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		if (z0ZzZzsmk4 == null)
		{
			z0ZzZzsmk4 = ((z0ZzZzsmk2 == null) ? z0ZzZzsmk3 : z0ZzZzsmk2);
		}
		if (z0ZzZzsmk4 == null)
		{
			return z0ZzZzpdh.z0yek;
		}
		z0ZzZzpdh p2 = new z0ZzZzpdh(p0, p1);
		p2 = z0ZzZzjmk.z0eek(p2, z0ZzZzsmk4.z0mek());
		return ((z0ZzZzqmk)z0ZzZzsmk4).z0eek(p2);
	}

	public override z0ZzZzpdh z0xqk(float p0, float p1)
	{
		if (z0tek)
		{
			return z0rek(p0, p1);
		}
		return base.z0xqk(p0, p1);
	}

	public void z0eek(float p0, int p1, int p2, int p3)
	{
		float num = 0f;
		foreach (z0ZzZzwrj item in z0rek())
		{
			if (num < item.z0oek())
			{
				num = item.z0oek();
			}
		}
		num = (int)(num * p0);
		z0oek = z0ZzZzodh.z0yek;
		base.z0eek();
		z0ZzZzwrj z0ZzZzwrj2 = z0rek().z0rek(z0rek().Count / 2);
		if (z0ZzZzwrj2 != null && z0ZzZzwrj2.z0nrk())
		{
			z0pek.Capacity = z0rek().Count * 4;
		}
		else
		{
			z0pek.Capacity = z0rek().Count * 3;
		}
		float num2 = p1 + p3;
		foreach (z0ZzZzwrj item2 in z0rek())
		{
			z0ep(item2, num2, p0);
			z0ZzZzndh p4 = item2.z0erk();
			p4.z0rek((int)num2);
			item2.z0eek(p4);
			num2 = ((!z0iek) ? (num2 + item2.z0trk().z0qrk() * p0 + (float)p2) : (num2 + (float)item2.z0erk().z0oek() + 3f));
		}
	}

	public override z0ZzZzodh z0jwk(int p0, int p1)
	{
		if (z0tek)
		{
			z0ZzZzpdh z0ZzZzpdh2 = z0rek(p0, p1);
			return new z0ZzZzodh((int)z0ZzZzpdh2.z0rek(), (int)z0ZzZzpdh2.z0tek());
		}
		z0ZzZzodh result = z0ZzZzodh.z0yek;
		for (int num = z0yek() - 1; num >= 0; num--)
		{
			z0ZzZzsmk z0ZzZzsmk2 = z0rek(num);
			if (z0ZzZzsmk2.z0oek() && z0ZzZzsmk2.z0rek().z0eek(p0, p1))
			{
				return z0ZzZzsmk2.z0jwk(p0, p1);
			}
		}
		return result;
	}

	public void z0eek(bool p0)
	{
		z0tek = p0;
	}

	public void z0eek(z0ZzZzerj p0)
	{
		z0uek = p0;
	}

	public z0ZzZzpdh z0rek(float p0, float p1)
	{
		z0ZzZzsmk z0ZzZzsmk2 = null;
		z0ZzZzsmk z0ZzZzsmk3 = null;
		z0ZzZzsmk z0ZzZzsmk4 = null;
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzsmk z0ZzZzsmk5 = (z0ZzZzsmk)enumerator.Current;
				if (z0ZzZzsmk5.z0oek() && (z0yek < 0 || z0ZzZzsmk5.z0yek() == z0yek))
				{
					z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzsmk5.z0rek();
					if (z0ZzZzbdh2.z0eek(p0, p1))
					{
						return z0ZzZzsmk5.z0xqk(p0, p1);
					}
					if (p1 >= z0ZzZzbdh2.z0pek() && p1 < z0ZzZzbdh2.z0nek())
					{
						z0ZzZzsmk4 = z0ZzZzsmk5;
						break;
					}
					if (p1 < z0ZzZzbdh2.z0pek() && (z0ZzZzsmk3 == null || z0ZzZzbdh2.z0pek() < z0ZzZzsmk3.z0rek().z0pek()))
					{
						z0ZzZzsmk3 = z0ZzZzsmk5;
					}
					if (p1 > z0ZzZzbdh2.z0nek() && (z0ZzZzsmk2 == null || z0ZzZzbdh2.z0nek() > z0ZzZzsmk2.z0rek().z0nek()))
					{
						z0ZzZzsmk2 = z0ZzZzsmk5;
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		if (z0ZzZzsmk4 == null)
		{
			z0ZzZzsmk4 = ((z0ZzZzsmk2 == null) ? z0ZzZzsmk3 : z0ZzZzsmk2);
		}
		if (z0ZzZzsmk4 == null)
		{
			return z0ZzZzpdh.z0yek;
		}
		z0ZzZzpdh p2 = new z0ZzZzpdh(p0, p1);
		p2 = z0ZzZzjmk.z0eek(p2, z0ZzZzsmk4.z0rek());
		return ((z0ZzZzqmk)z0ZzZzsmk4).z0rek(p2);
	}

	public override bool z0hwk(int p0, int p1)
	{
		if (z0tek)
		{
			return true;
		}
		return base.z0hwk(p0, p1);
	}

	public new z0ZzZzerj z0rek()
	{
		return z0uek;
	}

	public virtual void z0ep(z0ZzZzwrj p0, float p1, float p2)
	{
	}

	public new z0ZzZzodh z0eek(int p0, int p1)
	{
		z0ZzZzodh result = z0ZzZzodh.z0yek;
		for (int num = z0yek() - 1; num >= 0; num--)
		{
			z0ZzZzsmk z0ZzZzsmk2 = z0rek(num);
			if (z0ZzZzsmk2.z0vek() == PageContentPartyStyle.Body && z0ZzZzsmk2.z0rek().z0eek(p0, p1))
			{
				return z0ZzZzsmk2.z0jwk(p0, p1);
			}
		}
		return result;
	}

	public override z0ZzZzpdh z0bqk(float p0, float p1)
	{
		if (z0tek)
		{
			return z0eek(p0, p1);
		}
		return base.z0bqk(p0, p1);
	}
}
