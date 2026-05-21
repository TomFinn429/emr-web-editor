namespace zzz;

internal class z0ZzZzdbk : z0ZzZzznk
{
	private new z0ZzZzgbk z0rek = new z0ZzZzgbk();

	internal void z0eek(z0ZzZzlck p0)
	{
		if (!z0rek.Contains((z0ZzZzhbk)p0))
		{
			z0rek.Add((z0ZzZzhbk)p0);
			p0.z0qqk(this);
		}
	}

	public override string z0vak()
	{
		return "form";
	}

	public override string z0cak()
	{
		return "form";
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0rek != null)
		{
			z0rek.Clear();
			z0rek = null;
		}
	}
}
