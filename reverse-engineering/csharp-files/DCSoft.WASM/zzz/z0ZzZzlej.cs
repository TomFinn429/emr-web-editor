namespace zzz;

internal class z0ZzZzlej : z0ZzZzrwj
{
	private readonly z0ZzZziwj z0iek;

	private readonly bool z0oek;

	private byte[] z0pek;

	private readonly double z0nek;

	private readonly z0ZzZzkej z0vek;

	private readonly double z0cek;

	private readonly z0ZzZzmsj z0zek;

	internal z0ZzZzlej(z0ZzZzjej p0, z0ZzZziwj p1, double p2, double p3, z0ZzZzugj p4)
		: this(p0, p1, p2, p3, p4: true, p4)
	{
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		return z0ZzZzraj.z0eek(z0vgk(p0), z0pek);
	}

	protected override z0ZzZzeaj z0vgk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = base.z0vgk(p0);
		z0ZzZzeaj2.Add("PaintType", z0oek ? 1 : 2);
		switch (z0vek)
		{
		case (z0ZzZzkej)0:
			z0ZzZzeaj2.Add("TilingType", 1);
			break;
		case (z0ZzZzkej)2:
			z0ZzZzeaj2.Add("TilingType", 3);
			break;
		case (z0ZzZzkej)1:
			z0ZzZzeaj2.Add("TilingType", 2);
			break;
		}
		z0ZzZzeaj2.Add("BBox", z0iek.z0uek());
		z0ZzZzeaj2.Add("XStep", z0cek);
		z0ZzZzeaj2.Add("YStep", z0nek);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Resources", z0zek);
		return z0ZzZzeaj2;
	}

	internal void z0eek(byte[] p0)
	{
		z0pek = p0;
	}

	protected override int z0bgk()
	{
		return 1;
	}

	internal new bool z0eek()
	{
		return z0oek;
	}

	internal new z0ZzZzmsj z0rek()
	{
		return z0zek;
	}

	internal z0ZzZzlej(z0ZzZzjej p0, z0ZzZziwj p1, double p2, double p3, bool p4, z0ZzZzugj p5)
		: base(p0)
	{
		z0iek = p1;
		z0cek = p2;
		z0nek = p3;
		z0oek = p4;
		z0vek = (z0ZzZzkej)1;
		z0zek = new z0ZzZzmsj(p5, p1: true);
	}
}
