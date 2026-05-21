using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzaxk : z0ZzZzrxk
{
	private static readonly z0ZzZzgxk z0uek = new z0ZzZzgxk(new double[1], new double[1] { 1.0 });

	private z0ZzZzbdh z0iek;

	private z0ZzZzgxk z0oek;

	private z0ZzZzdxk z0pek;

	private Color[] z0mek;

	internal new z0ZzZzgxk z0eek()
	{
		return z0oek;
	}

	internal void z0eek(z0ZzZzdxk p0)
	{
		z0oek = null;
		z0pek = p0;
	}

	internal void z0eek(z0ZzZzgxk p0)
	{
		z0oek = p0;
	}

	internal z0ZzZzaxk(z0ZzZzbdh p0, Color p1, Color p2)
		: base((z0ZzZzddh)0)
	{
		z0iek = p0;
		z0mek = new Color[2] { p1, p2 };
		z0oek = z0uek;
	}

	internal new Color[] z0rek()
	{
		return z0mek;
	}

	internal z0ZzZzdxk z0tek()
	{
		return z0pek;
	}

	internal z0ZzZzbdh z0yek()
	{
		return z0iek;
	}

	public override void z0bak(z0ZzZzyxk p0)
	{
		p0.z0tak(this);
	}
}
