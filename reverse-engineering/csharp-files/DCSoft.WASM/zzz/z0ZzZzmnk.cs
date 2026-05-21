namespace zzz;

internal class z0ZzZzmnk : z0ZzZzznk
{
	private new bool z0rek = true;

	internal override bool z0iqk(z0ZzZzhbk p0)
	{
		if (!z0eek() && p0 is z0ZzZzmvk)
		{
			z0ZzZzmvk z0ZzZzmvk2 = (z0ZzZzmvk)p0;
			if (string.IsNullOrEmpty(z0ZzZzmvk2.z0zak()) || z0ZzZzmvk2.z0zak().Trim().Length == 0)
			{
				return false;
			}
		}
		z0eek(p0: true);
		return base.z0iqk(p0);
	}

	public override string z0vak()
	{
		return "body";
	}

	public void z0eek(bool p0)
	{
		z0rek = p0;
	}

	internal override bool z0xak(string p0)
	{
		return true;
	}

	public new bool z0eek()
	{
		return z0rek;
	}

	public override string z0cak()
	{
		return "body";
	}
}
