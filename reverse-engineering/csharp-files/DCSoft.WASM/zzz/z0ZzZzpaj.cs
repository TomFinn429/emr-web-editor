namespace zzz;

internal class z0ZzZzpaj : z0ZzZzgej
{
	private new byte[] z0rek;

	protected internal override void z0bdk(z0ZzZzeaj p0)
	{
		z0ZzZzhej.z0eek(p0, z0rek);
	}

	protected override z0ZzZzeaj z0ksk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = base.z0ksk(p0);
		if (z0rek() == null)
		{
			z0ZzZzeaj2.Add("CIDToGIDMap", new z0ZzZzhwj("Identity"));
		}
		return z0ZzZzeaj2;
	}

	internal new byte[] z0eek()
	{
		return z0rek;
	}

	protected z0ZzZzpaj(string p0, z0ZzZzvaj p1)
		: base(p0, p1)
	{
	}

	internal void z0eek(byte[] p0)
	{
		z0rek = p0;
	}

	protected override string z0xdk()
	{
		return "CIDFontType2";
	}
}
