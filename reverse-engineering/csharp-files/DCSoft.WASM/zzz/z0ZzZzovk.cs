namespace zzz;

internal class z0ZzZzovk : z0ZzZzznk
{
	public override string z0cak()
	{
		return "td";
	}

	internal override bool z0fqk(z0ZzZznvk p0, string p1)
	{
		switch (p1)
		{
		case "tr":
		case "table":
		case "tbody":
			p0.z0rek('<');
			return true;
		default:
			return base.z0fqk(p0, p1);
		}
	}

	public override string z0vak()
	{
		return "td";
	}
}
