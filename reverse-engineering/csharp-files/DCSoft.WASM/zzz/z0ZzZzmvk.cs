namespace zzz;

internal class z0ZzZzmvk : z0ZzZzhbk
{
	private new string z0eek;

	private new string z0rek;

	public override void z0kqk(string p0)
	{
		z0eek = p0;
	}

	public override z0ZzZzevk z0lqk()
	{
		return null;
	}

	public override string z0cak()
	{
		return "#text";
	}

	public override string z0zak()
	{
		return z0eek;
	}

	public override string z0vak()
	{
		return "#text";
	}

	public override string z0jqk()
	{
		return z0eek;
	}

	public z0ZzZzmvk(string p0)
	{
		z0eek = p0;
		z0rek = p0;
	}

	internal override bool z0rqk(z0ZzZznvk p0)
	{
		z0eek = p0.z0tek();
		return true;
	}

	public z0ZzZzmvk()
	{
	}

	public override void Dispose()
	{
		base.Dispose();
		z0eek = null;
		z0rek = null;
	}
}
