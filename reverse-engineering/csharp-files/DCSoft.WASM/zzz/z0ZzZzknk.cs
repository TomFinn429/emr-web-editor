namespace zzz;

public class z0ZzZzknk : z0ZzZzzmk
{
	private z0ZzZzlnk z0tek = new z0ZzZzlnk();

	private string z0yek;

	public new z0ZzZzlnk z0eek()
	{
		return z0tek;
	}

	public override void Dispose()
	{
		z0yek = null;
		if (z0tek != null)
		{
			z0tek.Clear();
			z0tek = null;
		}
	}

	public void z0eek(z0ZzZzlnk p0)
	{
		z0tek = p0;
	}

	public override object z0pqk(z0ZzZzwnk p0)
	{
		object[] array = null;
		if (z0tek != null && z0tek.Count > 0)
		{
			array = new object[z0tek.Count];
			for (int i = 0; i < z0tek.Count; i++)
			{
				object obj = z0tek[i].z0pqk(p0);
				if (obj is double && double.IsNaN((double)obj))
				{
					obj = 2147439148;
				}
				else if (obj is float && float.IsNaN((float)obj))
				{
					obj = 2147439148;
				}
				array[i] = obj;
			}
		}
		return p0.z0eek(z0rek(), array);
	}

	internal override void z0nqk(z0ZzZzzmk p0)
	{
		if (z0tek == null)
		{
			z0tek = new z0ZzZzlnk();
		}
		z0tek.Add(p0);
	}

	public override z0ZzZzzmk z0mqk()
	{
		z0ZzZzknk z0ZzZzknk2 = (z0ZzZzknk)MemberwiseClone();
		if (z0tek != null)
		{
			z0ZzZzknk2.z0tek = z0tek.z0eek();
		}
		return z0ZzZzknk2;
	}

	public new string z0rek()
	{
		return z0yek;
	}

	public void z0eek(string p0)
	{
		z0yek = p0;
	}
}
