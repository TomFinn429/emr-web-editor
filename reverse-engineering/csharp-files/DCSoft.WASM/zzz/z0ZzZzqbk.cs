namespace zzz;

internal class z0ZzZzqbk : z0ZzZzznk
{
	internal override bool z0xak(string p0)
	{
		switch (p0)
		{
		case "title":
		{
			using (zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = z0tek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					if (z0bpk.Current is z0ZzZzbvk)
					{
						return false;
					}
				}
			}
			return true;
		}
		default:
			return p0 == "xml";
		case "meta":
		case "link":
		case "script":
		case "style":
		case "hta:application":
		case "#comment":
			return true;
		}
	}

	public override string z0vak()
	{
		return "head";
	}

	internal override bool z0fqk(z0ZzZznvk p0, string p1)
	{
		if (p1 == "head")
		{
			p0.z0eek('>');
			return true;
		}
		return false;
	}

	public override string z0cak()
	{
		return "head";
	}
}
