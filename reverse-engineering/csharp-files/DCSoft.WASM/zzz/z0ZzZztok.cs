using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZztok : IDisposable
{
	public class z0oxk
	{
		public float[] z0eek;

		public z0xpk z0rek;
	}

	public enum z0xpk
	{
		z0eek,
		z0rek,
		z0tek,
		z0yek,
		z0uek,
		z0iek_jiejie20260327142557,
		z0oek,
		z0pek,
		z0mek,
		z0nek,
		z0bek,
		z0vek
	}

	private List<z0oxk> z0oek = new List<z0oxk>();

	private bool z0pek = true;

	private float z0mek = -3.4028235E+38f;

	private float z0nek = -3.4028235E+38f;

	private float z0bek = -3.4028235E+38f;

	private float z0vek = -3.4028235E+38f;

	public void z0eek(z0ZzZzbdh p0)
	{
		z0rek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek());
	}

	public void z0eek(z0ZzZzpdh p0, z0ZzZzpdh p1)
	{
		z0tek(p0.z0rek(), p0.z0tek(), p1.z0rek(), p1.z0tek());
	}

	public void z0eek(float p0, float p1, float p2, float p3, float p4, float p5, float p6, float p7)
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0rek;
		z0oxk.z0eek = new float[8] { p0, p1, p2, p3, p4, p5, p6, p7 };
		z0rek(p0, p1);
		z0rek(p2, p3);
		z0rek(p4, p5);
		z0rek(p6, p7);
		z0oek.Add(z0oxk);
	}

	public void z0rek(z0ZzZzbdh p0)
	{
		z0eek(p0.z0tek(), p0.z0yek(), p0.z0uek(), p0.z0iek());
	}

	public void z0eek(float p0, float p1, float p2, float p3)
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0pek;
		z0oxk.z0eek = new float[4] { p0, p1, p2, p3 };
		z0oek.Add(z0oxk);
	}

	public void z0eek()
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0nek;
		z0oek.Add(z0oxk);
	}

	public void z0rek(float p0, float p1, float p2, float p3)
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0tek;
		z0oxk.z0eek = new float[4] { p0, p1, p2, p3 };
		z0oek.Add(z0oxk);
		z0rek(p0, p1);
		z0rek(p0 + p2, p1 + p3);
	}

	public bool z0eek(float p0, float p1)
	{
		z0ZzZznfh obj = z0uek();
		bool result = obj.z0tek(p0, p1);
		obj.Dispose();
		return result;
	}

	public void z0eek(z0ZzZzpdh[] p0)
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0oek;
		z0oxk.z0eek = new float[p0.Length * 2];
		for (int i = 0; i < p0.Length; i++)
		{
			z0oxk.z0eek[i * 2] = p0[i].z0rek();
			z0oxk.z0eek[i * 2 + 1] = p0[i].z0tek();
		}
		z0oek.Add(z0oxk);
	}

	public void z0eek(float p0, float p1, float p2, float p3, float p4, float p5)
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0eek;
		z0oxk.z0eek = new float[6] { p0, p1, p2, p3, p4, p5 };
		z0oek.Add(z0oxk);
		z0rek(p0, p1);
		z0rek(p0 + p2, p1 + p3);
	}

	public void z0rek()
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0mek;
		z0oek.Add(z0oxk);
	}

	public void z0rek(z0ZzZzpdh[] p0)
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0uek;
		z0oxk.z0eek = new float[p0.Length * 2];
		for (int i = 0; i < p0.Length; i++)
		{
			z0oxk.z0eek[i * 2] = p0[i].z0rek();
			z0oxk.z0eek[i * 2 + 1] = p0[i].z0tek();
		}
		z0oek.Add(z0oxk);
	}

	private void z0rek(float p0, float p1)
	{
		if (z0pek)
		{
			z0pek = false;
			z0nek = p0;
			z0vek = p1;
			z0bek = p0;
			z0mek = p1;
			return;
		}
		if (z0nek > p0)
		{
			z0nek = p0;
		}
		if (z0bek < p0)
		{
			z0bek = p0;
		}
		if (z0vek > p1)
		{
			z0vek = p1;
		}
		if (z0mek < p1)
		{
			z0mek = p1;
		}
	}

	public void z0eek(z0ZzZzjdh p0)
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0vek;
		z0oxk.z0eek = (float[])p0.z0yek().Clone();
		z0oek.Add(z0oxk);
	}

	public void z0tek()
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0bek;
		z0oek.Add(z0oxk);
	}

	public z0ZzZzbdh z0yek()
	{
		z0ZzZznfh obj = z0uek();
		z0ZzZzbdh result = obj.z0eek();
		obj.Dispose();
		return result;
	}

	public void Dispose()
	{
		if (z0oek == null)
		{
			return;
		}
		foreach (z0oxk item in z0oek)
		{
			item.z0eek = null;
		}
		z0oek.Clear();
		z0oek = null;
	}

	public z0ZzZznfh z0uek()
	{
		z0ZzZznfh z0ZzZznfh2 = new z0ZzZznfh();
		foreach (z0oxk item in z0oek)
		{
			float[] array = item.z0eek;
			switch (item.z0rek)
			{
			case z0xpk.z0eek:
				z0ZzZznfh2.z0eek(array[0], array[1], array[2], array[3], array[4], array[5]);
				break;
			case z0xpk.z0rek:
				z0ZzZznfh2.z0eek(array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7]);
				break;
			case z0xpk.z0tek:
				z0ZzZznfh2.z0rek(array[0], array[1], array[2], array[3]);
				break;
			case z0xpk.z0yek:
				z0ZzZznfh2.z0tek(array[0], array[1], array[2], array[3]);
				break;
			case z0xpk.z0uek:
			{
				z0ZzZzpdh[] array3 = new z0ZzZzpdh[array.Length / 2];
				for (int j = 0; j < array3.Length; j++)
				{
					array3[j] = new z0ZzZzpdh(array[j * 2], array[j * 2 + 1]);
				}
				z0ZzZznfh2.z0tek(array3);
				break;
			}
			case z0xpk.z0iek_jiejie20260327142557:
				z0ZzZznfh2.z0rek(array[0], array[1], array[2], array[3], array[4], array[5]);
				break;
			case z0xpk.z0pek:
				z0ZzZznfh2.z0eek(new z0ZzZzbdh(array[0], array[1], array[2], array[3]));
				break;
			case z0xpk.z0mek:
				z0ZzZznfh2.z0uek();
				break;
			case z0xpk.z0bek:
				z0ZzZznfh2.z0rek();
				break;
			case z0xpk.z0oek:
			{
				z0ZzZzpdh[] array2 = new z0ZzZzpdh[array.Length / 2];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = new z0ZzZzpdh(array[i * 2], array[i * 2 + 1]);
				}
				z0ZzZznfh2.z0eek(array2);
				break;
			}
			case z0xpk.z0vek:
			{
				z0ZzZzjdh z0ZzZzjdh2 = new z0ZzZzjdh(array[0], array[1], array[2], array[3], array[4], array[5]);
				z0ZzZznfh2.z0eek(z0ZzZzjdh2);
				z0ZzZzjdh2.Dispose();
				break;
			}
			}
		}
		return z0ZzZznfh2;
	}

	public void z0tek(float p0, float p1, float p2, float p3)
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0yek;
		z0oxk.z0eek = new float[4] { p0, p1, p2, p3 };
		z0oek.Add(z0oxk);
		z0rek(p0, p1);
		z0rek(p2, p3);
	}

	public void z0rek(float p0, float p1, float p2, float p3, float p4, float p5)
	{
		z0oxk z0oxk = new z0oxk();
		z0oxk.z0rek = z0xpk.z0iek_jiejie20260327142557;
		z0oxk.z0eek = new float[6] { p0, p1, p2, p3, p4, p5 };
		z0oek.Add(z0oxk);
	}

	public void z0eek(z0ZzZzbdh p0, float p1, float p2)
	{
		z0rek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek(), p1, p2);
	}

	public void z0rek(z0ZzZzbdh p0, float p1, float p2)
	{
		z0eek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek(), p1, p2);
	}

	public bool z0eek(z0ZzZzpdh p0)
	{
		z0ZzZznfh z0ZzZznfh2 = z0uek();
		bool result = z0ZzZznfh2.z0tek(p0.z0rek(), p0.z0tek());
		z0ZzZznfh2.Dispose();
		return result;
	}

	public List<z0oxk> z0iek()
	{
		return z0oek;
	}
}
