namespace zzz;

internal class z0ZzZzgvk : z0ZzZzhbk
{
	private new string z0rek;

	public override string z0vak()
	{
		return "option";
	}

	public override string z0hqk()
	{
		return z0rek("value");
	}

	protected override bool z0gqk()
	{
		return true;
	}

	public override void z0kqk(string p0)
	{
		z0rek = p0;
	}

	public override string z0zak()
	{
		if (z0rek != null)
		{
			return z0rek;
		}
		return string.Empty;
	}

	public new bool z0eek()
	{
		return z0tek("selected");
	}

	public override void Dispose()
	{
		base.Dispose();
		z0rek = null;
	}

	public override string z0cak()
	{
		return "option";
	}
}
