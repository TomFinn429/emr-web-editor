using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzvtk
{
	private float z0uek;

	private z0ZzZzbdh z0iek = z0ZzZzbdh.z0xek;

	private bool z0oek;

	public void z0eek(bool p0)
	{
		z0oek = p0;
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzudh p1, Color p2, Color p3)
	{
		using (z0ZzZzzdh p4 = new z0ZzZzzdh(p3))
		{
			p0.z0eek(p4, z0iek);
		}
		if (p1 != null)
		{
			p0.z0eek(p1, z0iek);
		}
		using z0ZzZznfh p5 = z0tek();
		if (z0eek())
		{
			using (z0ZzZzxfh z0ZzZzxfh2 = new z0ZzZzxfh(new z0ZzZzpdh(0f, z0iek.z0pek()), new z0ZzZzpdh(0f, z0iek.z0nek() + 1f), p2, p3))
			{
				z0ZzZzpfh z0ZzZzpfh2 = new z0ZzZzpfh();
				z0ZzZzpfh2.z0eek(new Color[3] { p3, p2, p3 });
				z0ZzZzpfh2.z0eek(new float[3] { 0f, 0.5f, 1f });
				z0ZzZzxfh2.z0eek(z0ZzZzpfh2);
				p0.z0eek(z0ZzZzxfh2, p5);
				p0.z0eek(p1, p5);
				return;
			}
		}
		using z0ZzZzxfh z0ZzZzxfh3 = new z0ZzZzxfh(new z0ZzZzpdh(z0iek.z0oek(), 0f), new z0ZzZzpdh(z0iek.z0mek() + 1f, 0f), p2, p3);
		z0ZzZzpfh z0ZzZzpfh3 = new z0ZzZzpfh();
		z0ZzZzpfh3.z0eek(new Color[3] { p3, p2, p3 });
		z0ZzZzpfh3.z0eek(new float[3] { 0f, 0.5f, 1f });
		z0ZzZzxfh3.z0eek(z0ZzZzpfh3);
		p0.z0eek(z0ZzZzxfh3, p5);
		p0.z0eek(p1, p5);
	}

	public bool z0eek()
	{
		return z0oek;
	}

	public z0ZzZzvtk(z0ZzZzbdh p0, float p1)
	{
		z0iek = p0;
		z0uek = p1;
	}

	public float z0rek()
	{
		return z0uek;
	}

	public z0ZzZznfh z0tek()
	{
		z0ZzZzbdh p = z0iek;
		z0ZzZznfh z0ZzZznfh2 = new z0ZzZznfh();
		if (z0eek())
		{
			z0ZzZznfh2.z0eek(p, 90f, 180f);
			z0ZzZznfh2.z0tek(p.z0oek() + p.z0uek() / 2f, p.z0pek(), p.z0oek() + p.z0uek() / 2f - z0rek(), p.z0pek());
			p.z0tek(0f - z0rek(), 0f);
			z0ZzZznfh2.z0eek(p, 270f, -180f);
			z0ZzZznfh2.z0rek();
			return z0ZzZznfh2;
		}
		z0ZzZznfh2.z0eek(p, 360f, 180f);
		z0ZzZznfh2.z0tek(p.z0oek(), p.z0pek() + p.z0iek() / 2f, p.z0oek(), p.z0pek() + p.z0iek() / 2f + z0rek());
		p.z0tek(0f, z0rek());
		z0ZzZznfh2.z0eek(p, 180f, -180f);
		z0ZzZznfh2.z0rek();
		return z0ZzZznfh2;
	}

	public z0ZzZzbdh z0yek()
	{
		if (z0eek())
		{
			return new z0ZzZzbdh(z0iek.z0oek() - z0uek, z0iek.z0pek(), z0iek.z0uek() + z0uek, z0iek.z0iek());
		}
		return new z0ZzZzbdh(z0iek.z0oek(), z0iek.z0pek(), z0iek.z0uek(), z0iek.z0iek() + z0uek);
	}

	public z0ZzZzvtk()
	{
	}
}
