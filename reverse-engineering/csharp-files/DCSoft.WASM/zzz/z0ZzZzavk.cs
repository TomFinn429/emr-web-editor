namespace zzz;

internal class z0ZzZzavk : z0ZzZzhbk
{
	private new string z0eek;

	protected override bool z0gqk()
	{
		return true;
	}

	public override string z0zak()
	{
		return z0eek;
	}

	public override string z0vak()
	{
		return "script";
	}

	internal override bool z0dqk(z0ZzZznvk p0)
	{
		z0eek = p0.z0yek(z0vak());
		if (z0eek != null)
		{
			int num = z0eek.IndexOf("<!--");
			if (num >= 0)
			{
				z0eek = z0eek.Substring(num + 4);
			}
			num = z0eek.LastIndexOf("-->");
			if (num >= 0)
			{
				z0eek = z0eek.Substring(0, num);
			}
		}
		return true;
	}

	public override void z0kqk(string p0)
	{
		z0eek = p0;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0eek = null;
	}

	public override string z0cak()
	{
		return "script";
	}
}
