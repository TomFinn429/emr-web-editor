namespace zzz;

public class z0ZzZzhnk : z0ZzZzzmk
{
	private new z0ZzZzlnk z0rek = new z0ZzZzlnk();

	public override object z0pqk(z0ZzZzwnk p0)
	{
		if (z0eek() != null && z0eek().Count > 0)
		{
			return z0eek()[0].z0pqk(p0);
		}
		return null;
	}

	internal override void z0nqk(z0ZzZzzmk p0)
	{
		if (z0rek == null)
		{
			z0rek = new z0ZzZzlnk();
		}
		z0rek.Add(p0);
	}

	public override void Dispose()
	{
		if (z0rek == null)
		{
			return;
		}
		foreach (z0ZzZzzmk item in z0rek)
		{
			item.Dispose();
		}
		z0rek.Clear();
		z0rek = null;
	}

	public new z0ZzZzlnk z0eek()
	{
		return z0rek;
	}

	public override z0ZzZzzmk z0mqk()
	{
		z0ZzZzhnk z0ZzZzhnk2 = (z0ZzZzhnk)MemberwiseClone();
		if (z0rek != null)
		{
			z0ZzZzhnk2.z0rek = z0rek.z0eek();
		}
		return z0ZzZzhnk2;
	}
}
