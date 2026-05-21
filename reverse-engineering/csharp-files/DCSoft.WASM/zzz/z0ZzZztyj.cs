using System.Text;

namespace zzz;

internal class z0ZzZztyj : z0ZzZzayj
{
	private new Encoding z0iek;

	protected new z0ZzZzzrj z0oek = new z0ZzZzzrj();

	private Encoding z0pek;

	protected z0ZzZzktj z0mek = new z0ZzZzktj();

	private Encoding z0nek;

	protected z0ZzZzztj z0bek = new z0ZzZzztj();

	public new z0ZzZzzrj z0eek()
	{
		return z0oek;
	}

	public new z0ZzZzktj z0rek()
	{
		return z0mek;
	}

	public override z0ZzZztyj z0tjk()
	{
		return this;
	}

	public new z0ZzZzztj z0tek()
	{
		return z0bek;
	}

	internal new Encoding z0yek()
	{
		if (z0nek != null)
		{
			return z0nek;
		}
		if (z0iek != null)
		{
			return z0iek;
		}
		return z0uek();
	}

	public override z0ZzZzayj z0rjk()
	{
		return null;
	}

	public override void z0ejk(z0ZzZzayj p0)
	{
	}

	public new Encoding z0uek()
	{
		if (z0pek == null)
		{
			z0ZzZzsyj z0ZzZzsyj2 = base.z0rek.z0eek("ansicpg");
			if (z0ZzZzsyj2 != null && z0ZzZzsyj2.z0ojk())
			{
				z0pek = z0ZzZzqik.z0eek(z0ZzZzsyj2.z0njk());
			}
		}
		if (z0pek == null)
		{
			z0pek = z0ZzZzltj.z0rik;
		}
		return z0pek;
	}

	public override void z0mjk(z0ZzZzbyj p0)
	{
		p0.z0eek(z0uek());
		base.z0mjk(p0);
	}

	public z0ZzZztyj()
	{
		((z0ZzZzsyj)this).z0rek = this;
		base.z0yek = null;
		z0oek.z0eek(p0: false);
	}

	public override void z0wjk(z0ZzZztyj p0)
	{
	}
}
