using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzcqj : z0ZzZzfej
{
	private readonly IList<z0ZzZzuwj> z0yek;

	private readonly int z0iek;

	private readonly int z0oek;

	private readonly z0ZzZzcqj z0mek;

	private readonly z0ZzZzkgj z0nek;

	private readonly z0ZzZznaj z0cek;

	private readonly int z0hrk;

	private readonly bool z0srk;

	private z0ZzZzcqj(int p0, int p1, z0ZzZznaj p2, int p3, z0ZzZzkgj p4)
	{
		z0iek = p0;
		z0oek = p1;
		z0cek = p2;
		z0hrk = p3;
		z0nek = p4;
	}

	protected override z0ZzZznsj z0lfk(z0ZzZzdsj p0)
	{
		return z0nek.z0eek(z0zgk(p0));
	}

	internal z0ZzZzcqj(int p0, int p1, z0ZzZznaj p2, int p3, IList<z0ZzZzuwj> p4, z0ZzZzkgj p5, z0ZzZzcqj p6)
		: this(p0, p1, p2, p3, p5)
	{
		z0mek = p6;
		z0yek = p4;
	}

	protected override z0ZzZzeaj z0zgk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = base.z0zgk(p0);
		z0ZzZzeaj2.z0yek("Subtype", "Image");
		z0ZzZzeaj2.Add("Width", z0iek);
		z0ZzZzeaj2.Add("Height", z0oek);
		if (z0cek != null)
		{
			z0ZzZzeaj2.Add("ColorSpace", z0cek.z0qfk(p0));
		}
		z0ZzZzeaj2.z0tek_jiejie20260327142557("BitsPerComponent", z0hrk, 0);
		z0ZzZzeaj2.Add("Decode", z0ZzZzuwj.z0eek(z0yek));
		z0ZzZzeaj2.Add("Interpolate", z0srk);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("SMask", z0mek);
		return z0ZzZzeaj2;
	}
}
