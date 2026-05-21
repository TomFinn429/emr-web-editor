using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzkuj : z0ZzZzjuj
{
	private new bool z0tek = true;

	private new z0ZzZzpmk z0yek;

	public new z0ZzZzpmk z0eek()
	{
		return z0yek;
	}

	public new bool z0rek()
	{
		return z0tek;
	}

	public override void z0zkk(bool p0)
	{
		base.z0zkk(p0);
	}

	public override void z0sjk(z0ZzZzjpk p0)
	{
		if (z0rek() && z0eek() != null && z0eek().HasContent)
		{
			z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzrpk.z0eek(new z0ZzZzxdh(z0eek().Width, z0eek().Height), GraphicsUnit.Pixel, GraphicsUnit.Document);
			z0yek(z0ZzZzxdh2.z0rek());
			z0eek(z0ZzZzxdh2.z0tek());
		}
		base.z0sjk(p0);
	}

	public void z0eek(z0ZzZzpmk p0)
	{
		z0yek = p0;
	}

	public override bool z0xkk()
	{
		if (z0rek() && z0eek() != null && z0eek().HasContent)
		{
			return false;
		}
		return base.z0xkk();
	}

	public new void z0eek(bool p0)
	{
		z0tek = p0;
	}

	public override void z0fjk(z0ZzZztuj p0)
	{
		if (z0eek() != null && z0eek().HasContent)
		{
			z0ZzZzbdh z0ZzZzbdh2 = ((z0ZzZzhuj)this).z0uek();
			z0ZzZzbdh z0ZzZzbdh3 = z0ZzZzbdh.z0tek(z0ZzZzbdh2, p0.z0uek());
			if (!z0ZzZzbdh3.z0bek())
			{
				z0ZzZzbdh3.z0tek(z0ZzZzbdh3.z0uek() + 4f);
				z0ZzZzbdh3.z0yek(z0ZzZzbdh3.z0iek() + 4f);
				p0.z0iek().z0eek(z0eek(), z0ZzZzbdh2);
			}
		}
		base.z0fjk(p0);
	}
}
