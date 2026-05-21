namespace zzz;

internal class z0ZzZzuzk : z0ZzZznzk
{
	protected override void z0wak(z0ZzZzsgj p0)
	{
		z0ZzZziwj z0ZzZziwj2 = z0rek();
		z0ZzZzjej z0ZzZzjej2 = new z0ZzZzjej(-1.0, 0.0, 0.0, 1.0, z0ZzZziwj2.z0iek() * 2.0, 0.0);
		z0ZzZzjej z0ZzZzjej3 = new z0ZzZzjej(1.0, 0.0, 0.0, -1.0, 0.0, z0ZzZziwj2.z0mek() * 2.0);
		z0ZzZziwj z0ZzZziwj3 = z0eek();
		z0eek(p0, new z0ZzZziwj(z0ZzZziwj2.z0oek(), z0ZzZziwj2.z0yek(), z0ZzZziwj2.z0iek(), z0ZzZziwj2.z0mek()), new z0ZzZzjej());
		z0eek(p0, new z0ZzZziwj(z0ZzZziwj2.z0iek(), z0ZzZziwj2.z0yek(), z0ZzZziwj3.z0iek(), z0ZzZziwj2.z0mek()), z0ZzZzjej2);
		z0eek(p0, new z0ZzZziwj(z0ZzZziwj2.z0oek(), z0ZzZziwj2.z0mek(), z0ZzZziwj2.z0iek(), z0ZzZziwj3.z0mek()), z0ZzZzjej3);
		z0eek(p0, new z0ZzZziwj(z0ZzZziwj2.z0iek(), z0ZzZziwj2.z0mek(), z0ZzZziwj3.z0iek(), z0ZzZziwj3.z0mek()), z0ZzZzjej.z0rek(z0ZzZzjej3, z0ZzZzjej2));
	}

	internal z0ZzZzuzk(z0ZzZziwj p0, z0ZzZzmwj p1, z0ZzZzmwj p2, z0ZzZzjej p3, z0ZzZzjej p4)
		: base(p0, p1, p2, p3, new z0ZzZziwj(p0.z0oek(), p0.z0yek(), p0.z0eek() + p0.z0iek(), p0.z0mek() + p0.z0rek()), p4)
	{
	}
}
