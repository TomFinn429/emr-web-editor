namespace zzz;

internal class z0ZzZzyaj : z0ZzZzpqj
{
	private new readonly z0ZzZzywj z0eek;

	private readonly z0ZzZzywj z0tek;

	protected override z0ZzZzeaj z0pfk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = base.z0pfk(p0);
		z0ZzZzeaj2.Add("Coords", new object[4]
		{
			z0tek.z0eek(),
			z0tek.z0rek(),
			z0eek.z0eek(),
			z0eek.z0rek()
		});
		return z0ZzZzeaj2;
	}

	protected override int z0ofk()
	{
		return 2;
	}

	internal z0ZzZzyaj(z0ZzZzywj p0, z0ZzZzywj p1, zzz.z0ZzZzasj<z0ZzZzlqj> p2)
		: base(p2)
	{
		z0tek = p0;
		z0eek = p1;
	}
}
