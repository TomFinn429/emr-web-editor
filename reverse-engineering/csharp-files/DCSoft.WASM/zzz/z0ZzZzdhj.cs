namespace zzz;

internal class z0ZzZzdhj : z0ZzZztzk
{
	private readonly z0ZzZzexk z0rek;

	internal z0ZzZzdhj(z0ZzZzexk p0)
	{
		z0rek = p0;
	}

	private void z0eek(z0ZzZzsgj p0, z0ZzZzohj p1, z0ZzZziwj p2, z0ZzZzjej p3)
	{
		z0ZzZzjej p4 = z0ZzZzjej.z0rek(new z0ZzZzjej(1.0, 0.0, 0.0, -1.0, 0.0, 1.0), new z0ZzZzjej(p2.z0eek(), 0.0, 0.0, p2.z0rek(), p2.z0oek(), p2.z0yek()));
		p4 = z0ZzZzjej.z0rek(p4, p3);
		p1.z0esk(p0, new z0ZzZziwj(0.0, 0.0, 1.0, 1.0), p4);
	}

	internal override z0ZzZzshj z0usk(z0ZzZzmlj p0)
	{
		z0ZzZzedh z0ZzZzedh2 = z0rek.z0eek();
		double num = z0ZzZzedh2.z0iek();
		double num2 = z0ZzZzedh2.z0yek();
		z0ZzZziwj z0ZzZziwj2 = new z0ZzZziwj(0.0, 0.0, num * 2.0, num2 * 2.0);
		z0ZzZzddh z0ZzZzddh2 = z0rek.z0rek();
		z0ZzZziwj p1 = p0.z0mek();
		z0ZzZzjej p2 = z0ZzZztzk.z0eek(p0, z0rek);
		double p3;
		double p4;
		if (z0ZzZzddh2 == (z0ZzZzddh)4)
		{
			z0ZzZziwj obj = z0ZzZzjej.z0rek(p2).z0rek(p1);
			p3 = obj.z0eek();
			p4 = obj.z0rek();
		}
		else
		{
			p3 = z0ZzZziwj2.z0eek();
			p4 = z0ZzZziwj2.z0rek();
		}
		z0ZzZzlej z0ZzZzlej2 = new z0ZzZzlej(p2, z0ZzZziwj2, p3, p4, p0.z0cek());
		z0ZzZzohj p5 = p0.z0bek().z0rek(z0ZzZzedh2);
		using z0ZzZzsgj z0ZzZzsgj2 = new z0ZzZzsgj(z0ZzZzlej2.z0rek());
		if (z0ZzZzddh2 == (z0ZzZzddh)4)
		{
			z0eek(z0ZzZzsgj2, p5, new z0ZzZziwj(0.0, 0.0, num, num2), z0ZzZzjej.z0mek());
		}
		else
		{
			z0ZzZzjej z0ZzZzjej2 = ((z0ZzZzddh2 != (z0ZzZzddh)1 && z0ZzZzddh2 != (z0ZzZzddh)3) ? new z0ZzZzjej() : new z0ZzZzjej(-1.0, 0.0, 0.0, 1.0, num * 3.0, 0.0));
			z0ZzZzjej z0ZzZzjej3 = ((z0ZzZzddh2 != (z0ZzZzddh)2 && z0ZzZzddh2 != (z0ZzZzddh)3) ? new z0ZzZzjej() : new z0ZzZzjej(1.0, 0.0, 0.0, -1.0, 0.0, num2 * 3.0));
			z0ZzZzjej p6 = z0ZzZzjej.z0rek(z0ZzZzjej2, z0ZzZzjej3);
			z0eek(z0ZzZzsgj2, p5, new z0ZzZziwj(0.0, 0.0, num, num2), z0ZzZzjej.z0mek());
			z0eek(z0ZzZzsgj2, p5, new z0ZzZziwj(num, 0.0, z0ZzZziwj2.z0eek(), num2), z0ZzZzjej2);
			z0eek(z0ZzZzsgj2, p5, new z0ZzZziwj(0.0, num2, num, z0ZzZziwj2.z0rek()), z0ZzZzjej3);
			z0eek(z0ZzZzsgj2, p5, new z0ZzZziwj(num, num2, z0ZzZziwj2.z0eek(), z0ZzZziwj2.z0rek()), p6);
		}
		z0ZzZzlej2.z0eek(z0ZzZzsgj2.z0oek());
		return new z0ZzZzshj(255, z0ZzZzlej2);
	}
}
