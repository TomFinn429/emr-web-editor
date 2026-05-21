namespace zzz;

internal class z0ZzZzsgh : z0ZzZzjhh
{
	private class z0igj : z0ZzZzahh
	{
		public new void z0eek(object p0)
		{
			z0rek();
			if (p0 == null)
			{
				z0rek(z0ZzZzsgh.z0eek, string.Empty);
				return;
			}
			z0tek();
			z0rek(z0ZzZzsgh.z0eek, string.Empty, (z0ZzZzluj)p0, p3: true, p4: false);
		}
	}

	private class z0ugj : z0ZzZzshh
	{
		public new object z0eek()
		{
			object result = null;
			((z0ZzZzlhh)this).z0yek().z0da();
			if (((z0ZzZzlhh)this).z0yek().z0la() == (z0ZzZzbah)1)
			{
				if (!(((z0ZzZzlhh)this).z0yek().z0ma() == z0ZzZzsgh.z0eek))
				{
					throw z0oek();
				}
				result = z0hrk(p0: true, p1: true);
			}
			else
			{
				z0eek(null, ((z0ZzZzlhh)this).z0yek().z0ma());
			}
			return result;
		}
	}

	private static readonly string z0eek = "ShapeDocument";

	public override bool z0za(z0ZzZzcah p0)
	{
		return p0.z0eek(z0eek, string.Empty);
	}

	protected override void z0xa(object p0, z0ZzZzkhh p1)
	{
		((z0igj)p1).z0eek(p0);
	}

	protected override object z0lq(z0ZzZzlhh p0)
	{
		return ((z0ugj)p0).z0eek();
	}

	protected override z0ZzZzlhh z0jq()
	{
		return new z0ugj();
	}

	protected override z0ZzZzkhh z0kq()
	{
		return new z0igj();
	}
}
