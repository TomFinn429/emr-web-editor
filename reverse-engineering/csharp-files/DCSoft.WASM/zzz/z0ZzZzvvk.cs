namespace zzz;

internal class z0ZzZzvvk : z0ZzZzznk
{
	public override string z0cak()
	{
		return "tr";
	}

	public override string z0vak()
	{
		return "tr";
	}

	internal override bool z0fqk(z0ZzZznvk p0, string p1)
	{
		if (p1 == "table" || p1 == "tbody")
		{
			p0.z0rek('<');
			return true;
		}
		return base.z0fqk(p0, p1);
	}

	internal override bool z0xak(string p0)
	{
		return p0 == "td";
	}
}
