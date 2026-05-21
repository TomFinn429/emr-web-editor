using System;

namespace zzz;

public class z0ZzZzcmk : z0ZzZzzmk
{
	private string z0uek;

	private z0ZzZzank z0iek = (z0ZzZzank)1;

	private double z0oek;

	private bool z0pek;

	public void z0eek(string p0)
	{
		z0uek = p0;
	}

	public new double z0eek()
	{
		return z0oek;
	}

	public new void z0eek(bool p0)
	{
		z0pek = p0;
	}

	public new z0ZzZzank z0rek()
	{
		return z0iek;
	}

	public z0ZzZzcmk()
	{
	}

	public z0ZzZzcmk(object p0, z0ZzZzank p1)
	{
		z0iek = p1;
		switch (p1)
		{
		case (z0ZzZzank)1:
			z0uek = (string)p0;
			break;
		case (z0ZzZzank)0:
			z0oek = (double)p0;
			break;
		case (z0ZzZzank)2:
			z0pek = (bool)p0;
			break;
		}
	}

	public override object z0pqk(z0ZzZzwnk p0)
	{
		if (z0rek() == (z0ZzZzank)1)
		{
			return z0uek;
		}
		if (z0rek() == (z0ZzZzank)0)
		{
			return z0oek;
		}
		if (z0rek() == (z0ZzZzank)2)
		{
			return z0pek;
		}
		if (z0rek() == (z0ZzZzank)3)
		{
			return null;
		}
		throw new NotSupportedException(z0rek().ToString());
	}

	public bool z0tek()
	{
		return z0pek;
	}

	public string z0yek()
	{
		return z0uek;
	}

	public override void Dispose()
	{
		z0uek = null;
	}

	public void z0eek(z0ZzZzank p0)
	{
		z0iek = p0;
	}

	public void z0eek(double p0)
	{
		z0oek = p0;
	}
}
