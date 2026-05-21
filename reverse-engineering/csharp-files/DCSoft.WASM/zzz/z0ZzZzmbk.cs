namespace zzz;

internal class z0ZzZzmbk : z0ZzZzhbk, z0ZzZzlck
{
	protected new z0ZzZzdbk z0rek;

	public override string z0hqk()
	{
		return z0rek("value");
	}

	public void z0qqk(z0ZzZzdbk p0)
	{
		z0rek = p0;
	}

	public z0ZzZzdbk z0aqk()
	{
		return z0rek;
	}

	public override string z0jqk()
	{
		if (z0eek() == "text")
		{
			return z0hqk();
		}
		return null;
	}

	public override string z0vak()
	{
		return "input";
	}

	public override string z0cak()
	{
		return "input";
	}

	public override void Dispose()
	{
		base.Dispose();
		z0rek = null;
	}

	public new virtual string z0eek()
	{
		return z0rek("type");
	}
}
