namespace zzz;

internal class z0ZzZzzsj : z0ZzZzlaj
{
	private new readonly bool z0eek;

	private new readonly z0ZzZziwj z0rek;

	internal override double z0xfk(int p0)
	{
		return z0rek().z0rek().z0uek() switch
		{
			(z0ZzZzvwj)1 => z0rek.z0mek() - (z0rek.z0rek() - z0rek().z0eek(p0)) / 2.0, 
			(z0ZzZzvwj)2 => z0rek.z0mek() - (z0rek.z0rek() - z0rek().z0eek(p0)), 
			_ => z0rek.z0mek(), 
		};
	}

	internal override void z0cfk()
	{
		if (z0eek)
		{
			z0eek().z0iek(z0rek);
		}
	}

	internal override double z0vfk(z0ZzZzzdj p0)
	{
		return z0rek().z0rek().z0tek() switch
		{
			(z0ZzZzvwj)1 => z0rek.z0oek() + (z0rek.z0eek() - z0rek().z0eek(p0)) / 2.0, 
			(z0ZzZzvwj)2 => z0rek.z0iek() - z0rek().z0eek(p0) - z0rek().z0tek(), 
			_ => z0rek.z0oek() + z0rek().z0eek(), 
		};
	}

	internal z0ZzZzzsj(z0ZzZzsgj p0, z0ZzZzcsj p1, z0ZzZziwj p2)
		: base(p0, p1)
	{
		z0rek = p2;
		z0eek = !z0ZzZzlxk.z0yek(z0rek().z0rek().z0eek(), (z0ZzZzxwj)8);
	}
}
