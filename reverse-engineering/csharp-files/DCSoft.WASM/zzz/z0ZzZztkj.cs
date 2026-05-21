namespace zzz;

internal abstract class z0ZzZztkj
{
	private readonly z0ZzZzjej z0tek;

	private readonly z0ZzZzaxk z0yek;

	internal abstract byte z0csk();

	protected z0ZzZzaxk z0eek()
	{
		return z0yek;
	}

	protected abstract z0ZzZzykj z0zsk();

	protected z0ZzZztkj(z0ZzZzaxk p0, z0ZzZzjej p1)
	{
		z0yek = p0;
		z0tek = p1;
	}

	protected z0ZzZzjej z0rek_jiejie20260327142557()
	{
		return z0tek;
	}

	protected abstract z0ZzZzykj z0xsk();

	internal virtual z0ZzZzrwj z0tsk(z0ZzZzmlj p0)
	{
		z0ZzZzugj z0ZzZzugj2 = p0.z0cek();
		z0ZzZziwj z0ZzZziwj2 = z0ZzZznlj.z0eek(z0yek.z0yek());
		z0ZzZzyaj p1 = z0xsk().z0eek(z0ZzZzugj2, z0ZzZziwj2);
		z0ZzZzyaj p2 = z0zsk()?.z0eek(z0ZzZzugj2, z0ZzZziwj2);
		return z0ZzZzpzk.z0eek(((z0ZzZzrxk)z0yek).z0rek(), z0tek, z0ZzZziwj2, p1, p2, z0ZzZzugj2, new z0ZzZzjej());
	}

	internal static z0ZzZztkj z0eek(z0ZzZzaxk p0, z0ZzZziwj p1, z0ZzZzjej p2)
	{
		if (p0.z0tek() == null)
		{
			return new z0ZzZzwhj(p0, p2);
		}
		return new z0ZzZzokj(p0, p2);
	}
}
