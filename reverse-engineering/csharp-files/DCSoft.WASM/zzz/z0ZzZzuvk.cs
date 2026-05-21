namespace zzz;

internal class z0ZzZzuvk : z0ZzZzznk
{
	private new z0ZzZzgbk z0rek = new z0ZzZzgbk();

	public override string z0cak()
	{
		return "table";
	}

	public new z0ZzZzgbk z0eek()
	{
		return z0rek;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0rek != null)
		{
			z0rek.z0zrk();
			z0rek = null;
		}
	}

	public override string z0vak()
	{
		return "table";
	}

	internal override bool z0xak(string p0)
	{
		switch (p0)
		{
		default:
			return p0 == "colgroup";
		case "tr":
		case "col":
		case "tbody":
			return true;
		}
	}

	public override void FixDom()
	{
		z0ZzZzgbk z0ZzZzgbk2 = new z0ZzZzgbk();
		z0ZzZzgbk z0ZzZzgbk3 = new z0ZzZzgbk();
		foreach (z0ZzZzhbk item in z0oqk().z0xrk())
		{
			if (item is z0ZzZzvvk)
			{
				z0ZzZzgbk2.Add(item);
			}
			else if (item is z0ZzZzivk)
			{
				foreach (z0ZzZzhbk item2 in ((z0ZzZzivk)item).z0oqk().z0xrk())
				{
					if (item2 is z0ZzZzvnk)
					{
						z0ZzZzgbk3.Add(item2);
					}
					else if (item2 is z0ZzZzvvk)
					{
						z0ZzZzgbk2.Add(item2);
					}
				}
			}
			else
			{
				if (!(item is z0ZzZzcnk))
				{
					continue;
				}
				foreach (z0ZzZzhbk item3 in ((z0ZzZzcnk)item).z0oqk().z0xrk())
				{
					if (item3 is z0ZzZzvnk)
					{
						z0ZzZzgbk3.Add(item3);
					}
				}
			}
		}
		foreach (z0ZzZzhbk item4 in z0rek.z0xrk())
		{
			if (item4 is z0ZzZzvnk)
			{
				z0ZzZzgbk3.Add(item4);
			}
		}
		z0tek = z0ZzZzgbk2;
		z0rek = z0ZzZzgbk3;
		foreach (z0ZzZzhbk item5 in z0oqk().z0xrk())
		{
			item5.FixDom();
		}
	}

	public override bool z0uqk(z0ZzZzhbk p0)
	{
		if (p0.z0cak() == "tr" || p0.z0cak() == "tbody" || p0.z0cak() == "colgroup")
		{
			z0tek.Add(p0);
		}
		else
		{
			z0rek.Add(p0);
		}
		p0.z0eek(z0lrk, this);
		return true;
	}
}
