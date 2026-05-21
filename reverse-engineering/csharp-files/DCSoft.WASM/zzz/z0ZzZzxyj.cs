namespace zzz;

public class z0ZzZzxyj : z0ZzZzeuj
{
	private new z0ZzZzguj z0rek = new z0ZzZzguj();

	public new virtual void z0eek()
	{
		foreach (z0ZzZzhuj item in z0djk())
		{
			item.z0kjk(this);
			if (item is z0ZzZzxyj)
			{
				((z0ZzZzxyj)item).z0eek();
			}
		}
	}

	public override void z0qjk(z0ZzZzguj p0)
	{
		z0rek = p0;
	}

	public override void Dispose()
	{
		foreach (z0ZzZzhuj item in z0djk())
		{
			item.Dispose();
		}
	}

	public override void z0ajk(z0ZzZzsuj p0)
	{
		base.z0ajk(p0);
		foreach (z0ZzZzhuj item in z0djk())
		{
			item.z0hjk(z0jjk());
			item.z0kjk(this);
			item.z0ajk(p0);
		}
	}

	public override void z0mkk(float p0, float p1)
	{
		base.z0mkk(p0, p1);
		foreach (z0ZzZzhuj item in z0djk())
		{
			item.z0mkk(p0, p1);
		}
	}

	public override void z0sjk(z0ZzZzjpk p0)
	{
		foreach (z0ZzZzhuj item in z0djk())
		{
			item.z0sjk(p0);
		}
	}

	private void z0eek(z0ZzZzguj p0)
	{
		foreach (z0ZzZzhuj item in z0djk())
		{
			p0.Add(item);
			if (item is z0ZzZzxyj)
			{
				((z0ZzZzxyj)item).z0eek(p0);
			}
		}
	}

	public override z0ZzZzguj z0djk()
	{
		return z0rek;
	}

	public override void z0fjk(z0ZzZztuj p0)
	{
		foreach (z0ZzZzhuj item in z0djk())
		{
			z0ZzZzbdh p1 = p0.z0uek();
			z0ZzZzbdh z0ZzZzbdh2 = item.z0uek();
			p1.z0tek(0f - z0ZzZzbdh2.z0oek(), 0f - z0ZzZzbdh2.z0pek());
			if (item.z0eek(p1))
			{
				z0ZzZztuj z0ZzZztuj2 = p0.z0oek();
				z0ZzZztuj2.z0eek(p1);
				item.z0nkk(z0ZzZztuj2);
			}
		}
	}

	public override z0ZzZzhuj z0gjk(bool p0)
	{
		z0ZzZzxyj z0ZzZzxyj2 = (z0ZzZzxyj)base.z0gjk(p0);
		z0ZzZzxyj2.z0rek = z0rek.z0eek();
		if (p0)
		{
			z0ZzZzxyj2.z0rek = new z0ZzZzguj();
			foreach (z0ZzZzhuj item in z0rek)
			{
				z0ZzZzxyj2.z0rek.Add(item.z0gjk(p0: true));
			}
		}
		return z0ZzZzxyj2;
	}

	public new virtual z0ZzZzguj z0eek(bool p0)
	{
		z0ZzZzguj z0ZzZzguj2 = new z0ZzZzguj();
		if (p0)
		{
			z0ZzZzguj2.Add(this);
		}
		z0eek(z0ZzZzguj2);
		return z0ZzZzguj2;
	}
}
