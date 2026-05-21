using System.Runtime.CompilerServices;
using DCSystem_Drawing;

namespace zzz;

public sealed class z0ZzZzxfh : z0ZzZztfh
{
	public readonly z0ZzZzpdh z0rek = z0ZzZzpdh.z0yek;

	public readonly z0ZzZzbdh z0tek = z0ZzZzbdh.z0xek;

	[CompilerGenerated]
	private z0ZzZzpfh z0yek;

	public readonly Color z0uek = Color.Empty;

	public readonly Color z0iek = Color.Empty;

	public string z0oek;

	public readonly z0ZzZzpdh z0pek = z0ZzZzpdh.z0yek;

	public readonly z0ZzZzzfh z0mek;

	public z0ZzZzxfh(z0ZzZzbdh p0, Color p1, Color p2, z0ZzZzzfh p3)
	{
		z0tek = p0;
		z0rek = new z0ZzZzpdh(p0.z0oek(), p0.z0pek());
		z0pek = new z0ZzZzpdh(p0.z0mek(), p0.z0nek());
		z0uek = p1;
		z0iek = p2;
		z0mek = p3;
	}

	[CompilerGenerated]
	public void z0eek(z0ZzZzpfh p0)
	{
		z0yek = p0;
	}

	[CompilerGenerated]
	public z0ZzZzpfh z0eek()
	{
		return z0yek;
	}

	public z0ZzZzxfh(z0ZzZzndh p0, Color p1, Color p2, z0ZzZzzfh p3)
	{
		z0tek = p0.z0eek();
		z0rek = new z0ZzZzpdh(p0.z0pek(), p0.z0mek());
		z0pek = new z0ZzZzpdh(p0.z0nek(), p0.z0bek());
		z0uek = p1;
		z0iek = p2;
		z0mek = p3;
	}

	public override bool z0jd(z0ZzZztfh p0)
	{
		if (p0 is z0ZzZzxfh)
		{
			z0ZzZzxfh z0ZzZzxfh2 = (z0ZzZzxfh)p0;
			if (z0ZzZzpdh.z0eek(z0rek, z0ZzZzxfh2.z0rek) && z0ZzZzpdh.z0eek(z0pek, z0ZzZzxfh2.z0pek) && z0ZzZzbdh.z0eek(z0tek, z0ZzZzxfh2.z0tek) && z0uek == z0ZzZzxfh2.z0uek && z0iek == z0ZzZzxfh2.z0iek && z0mek == z0ZzZzxfh2.z0mek)
			{
				if (z0eek() == z0ZzZzxfh2.z0eek())
				{
					return true;
				}
				if (z0eek() != null && z0eek().z0eek(z0ZzZzxfh2.z0eek()))
				{
					return true;
				}
			}
		}
		return false;
	}

	public z0ZzZzxfh(z0ZzZzpdh p0, z0ZzZzpdh p1, Color p2, Color p3)
	{
		z0rek = p0;
		z0pek = p1;
		z0uek = p2;
		z0iek = p3;
	}
}
