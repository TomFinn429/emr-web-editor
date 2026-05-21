using System;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzpuj
{
	[NonSerialized]
	private float z0uek;

	private int z0iek = 8;

	private z0ZzZznmk z0oek;

	private z0ZzZznmk z0pek;

	public z0ZzZzpuj()
	{
		z0pek = new z0ZzZznmk(Color.LightGray);
		z0oek = new z0ZzZznmk(Color.Gray, 1f, DashStyle.Dot);
	}

	public z0ZzZznmk z0eek()
	{
		return z0pek;
	}

	public void z0eek(z0ZzZznmk p0)
	{
		z0oek = p0;
	}

	public float z0rek()
	{
		return z0uek;
	}

	public void z0eek(int p0)
	{
		z0iek = p0;
	}

	public void z0rek(z0ZzZznmk p0)
	{
		z0pek = p0;
	}

	public void z0eek(float p0)
	{
		z0uek = p0;
	}

	public int z0tek()
	{
		return z0iek;
	}

	public z0ZzZznmk z0yek()
	{
		return z0oek;
	}
}
