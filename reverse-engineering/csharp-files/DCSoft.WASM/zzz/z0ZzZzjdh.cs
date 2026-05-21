using System;

namespace zzz;

public sealed class z0ZzZzjdh : IDisposable
{
	internal float z0vek;

	internal float z0cek;

	internal float z0xek;

	internal float z0zek;

	internal float z0lrk = 1f;

	internal float z0krk = 1f;

	public string z0eek()
	{
		return "matrix(" + z0krk + " " + z0vek + " " + z0zek + " " + z0lrk + " " + z0cek + " " + z0xek + ")";
	}

	public bool z0eek(z0ZzZzjdh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("m");
		}
		if (p0 == this)
		{
			return true;
		}
		if (z0krk == p0.z0krk && z0vek == p0.z0vek && z0zek == p0.z0zek && z0lrk == p0.z0lrk && z0cek == p0.z0cek)
		{
			return z0xek == p0.z0xek;
		}
		return false;
	}

	public void z0eek(float p0, float p1)
	{
		z0cek += z0krk * p0 + z0zek * p1;
		z0xek += z0vek * p0 + z0lrk * p1;
	}

	public void z0rek(float p0, float p1)
	{
		if (p0 != 1f)
		{
			z0krk *= p0;
			z0vek *= p0;
		}
		if (p1 != 1f)
		{
			z0zek *= p1;
			z0lrk *= p1;
		}
	}

	public void z0rek(z0ZzZzjdh p0)
	{
	}

	public float z0rek()
	{
		return z0cek;
	}

	public void z0tek_jiejie20260327142557()
	{
		z0krk = 1f;
		z0vek = 0f;
		z0zek = 0f;
		z0lrk = 1f;
		z0cek = 0f;
		z0xek = 0f;
		z0pek();
	}

	public z0ZzZzjdh()
	{
	}

	public float[] z0yek()
	{
		return new float[6] { z0krk, z0vek, z0zek, z0lrk, z0cek, z0xek };
	}

	public z0ZzZzjdh(float p0, float p1, float p2, float p3, float p4, float p5)
	{
		z0krk = p0;
		z0vek = p1;
		z0zek = p2;
		z0lrk = p3;
		z0cek = p4;
		z0xek = p5;
	}

	public void z0eek(float p0)
	{
		float num = p0 * (float)Math.PI / 180f;
		float num2 = (float)Math.Cos(num);
		float num3 = (float)Math.Sin(num);
		float num4 = z0krk;
		float num5 = z0vek;
		float num6 = z0zek;
		float num7 = z0lrk;
		z0krk = num4 * num2 + num6 * num3;
		z0vek = num5 * num2 + num7 * num3;
		z0zek = num4 * (0f - num3) + num6 * num2;
		z0lrk = num5 * (0f - num3) + num7 * num2;
	}

	public z0ZzZzjdh z0uek()
	{
		return (z0ZzZzjdh)MemberwiseClone();
	}

	public bool z0iek()
	{
		if (z0krk == 1f && z0vek == 0f && z0zek == 0f && z0lrk == 1f && z0cek == 0f)
		{
			return z0xek == 0f;
		}
		return false;
	}

	public void z0oek()
	{
		z0cek = 0f - z0cek;
		z0xek = 0f - z0xek;
	}

	public z0ZzZzpdh z0eek(float p0, float p1, float p2)
	{
		return new z0ZzZzpdh(p0 * z0krk + p1 * z0zek + z0cek * p2, p0 * z0vek + p1 * z0lrk + z0xek * p2);
	}

	public void z0pek()
	{
	}

	public string z0mek()
	{
		return z0krk + " " + z0vek + " " + z0zek + " " + z0lrk + " " + z0cek + " " + z0xek;
	}

	public bool z0nek()
	{
		if (z0krk == 1f)
		{
			return z0lrk != 1f;
		}
		return true;
	}

	public z0ZzZzpdh z0tek_jiejie20260327142557(float p0, float p1)
	{
		return new z0ZzZzpdh(p0 * z0krk + p1 * z0zek + z0cek, p0 * z0vek + p1 * z0lrk + z0xek);
	}

	public void z0eek(z0ZzZzpdh[] p0)
	{
		for (int num = p0.Length - 1; num >= 0; num--)
		{
			float num2 = p0[num].z0rek();
			float num3 = p0[num].z0tek();
			float p1 = num2 * z0krk + num3 * z0zek + z0cek;
			float p2 = num2 * z0vek + num3 * z0lrk + z0xek;
			p0[num] = new z0ZzZzpdh(p1, p2);
		}
	}

	public float z0bek()
	{
		return z0xek;
	}

	public void Dispose()
	{
	}
}
