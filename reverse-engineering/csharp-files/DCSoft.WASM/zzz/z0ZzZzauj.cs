using System;

namespace zzz;

public class z0ZzZzauj : z0ZzZzhuj
{
	private new float z0iek;

	private new float z0oek;

	private new float z0pek;

	private new float z0mek;

	public override void z0nkk(z0ZzZztuj p0)
	{
		z0ZzZzpdh z0ZzZzpdh2 = z0tek();
		using z0ZzZzudh p1 = z0ZzZzdpk.z0eek(z0oek().BorderColor, z0oek().BorderWidth, z0oek().BorderStyle);
		p0.z0iek().z0eek(p1, z0ZzZzpdh2.z0rek() + z0eek(), z0ZzZzpdh2.z0tek() + z0uek(), z0ZzZzpdh2.z0rek() + z0yek(), z0ZzZzpdh2.z0tek() + z0rek());
	}

	public override z0ZzZzbdh z0vkk()
	{
		return new z0ZzZzbdh(Math.Min(z0eek(), z0yek()), Math.Min(z0uek(), z0rek()), Math.Abs(z0eek() - z0yek()), Math.Abs(z0uek() - z0rek()));
	}

	public void z0eek(float p0)
	{
		z0pek = p0;
	}

	public new float z0eek()
	{
		return z0mek;
	}

	public void z0rek(float p0)
	{
		z0mek = p0;
	}

	public override void z0mkk(float p0, float p1)
	{
		z0rek(z0eek() * p0);
		z0eek(z0uek() * p1);
		z0yek(z0yek() * p0);
		z0tek(z0rek() * p1);
	}

	public float z0rek()
	{
		return z0oek;
	}

	public override void z0bkk(z0ZzZzbdh p0)
	{
		if (z0eek() < z0yek())
		{
			z0rek(p0.z0oek());
			z0yek(p0.z0mek());
		}
		else
		{
			z0rek(p0.z0mek());
			z0yek(p0.z0oek());
		}
		if (z0uek() < z0rek())
		{
			z0eek(p0.z0pek());
			z0tek(p0.z0nek());
		}
		else
		{
			z0eek(p0.z0nek());
			z0tek(p0.z0pek());
		}
	}

	protected z0ZzZzpdh z0tek()
	{
		z0ZzZzpdh result = z0nek();
		z0ZzZzbdh z0ZzZzbdh2 = z0vkk();
		result.z0eek(result.z0rek() - z0ZzZzbdh2.z0oek());
		result.z0rek(result.z0tek() - z0ZzZzbdh2.z0pek());
		return result;
	}

	public new float z0yek()
	{
		return z0iek;
	}

	public void z0tek(float p0)
	{
		z0oek = p0;
	}

	public void z0yek(float p0)
	{
		z0iek = p0;
	}

	public new float z0uek()
	{
		return z0pek;
	}
}
