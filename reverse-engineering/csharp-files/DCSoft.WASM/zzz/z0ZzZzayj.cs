using System.Text;

namespace zzz;

internal class z0ZzZzayj : z0ZzZzsyj
{
	protected new z0ZzZzqyj z0rek = new z0ZzZzqyj();

	public override int z0njk()
	{
		if (z0rek.Count > 0)
		{
			return z0rek[0].z0njk();
		}
		return 0;
	}

	public override void z0mjk(z0ZzZzbyj p0)
	{
		p0.z0oek();
		foreach (z0ZzZzsyj item in z0rek)
		{
			item.z0mjk(p0);
		}
		p0.z0uek();
	}

	public override void z0pjk(string p0)
	{
	}

	public z0ZzZzayj()
	{
		z0tek = (z0ZzZzwyj)5;
	}

	public new virtual string z0eek()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (z0ZzZzsyj item in z0rek)
		{
			if (item is z0ZzZzayj)
			{
				stringBuilder.Append(((z0ZzZzayj)item).z0eek());
			}
			if (item.z0eek() == (z0ZzZzwyj)4)
			{
				stringBuilder.Append(item.z0ijk());
			}
		}
		return stringBuilder.ToString();
	}

	public override bool z0ojk()
	{
		if (z0rek.Count > 0)
		{
			return z0rek[0].z0ojk();
		}
		return false;
	}

	public override string z0ijk()
	{
		if (z0rek.Count > 0)
		{
			return z0rek[0].z0ijk();
		}
		return null;
	}

	public override void z0ujk(bool p0)
	{
	}

	public override z0ZzZzqyj z0yjk()
	{
		return z0rek;
	}
}
