using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzflh : z0ZzZzxzj
{
	private new Color z0eek = Color.Empty;

	private new Color z0rek = Color.Empty;

	private z0ZzZzdbj z0tek;

	private new z0ZzZzimk z0yek;

	private z0ZzZzimk z0uek;

	public z0ZzZzflh(z0ZzZzdbj p0, z0ZzZzimk p1, Color p2, z0ZzZzimk p3, Color p4)
	{
		z0tek = p0;
		z0uek = p1;
		z0eek = p2;
		z0yek = p3;
		z0rek = p4;
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		z0tek.z0eek(z0uek, z0eek, p2: true);
	}

	public override void z0yo(z0ZzZzpgh p0)
	{
		z0tek.z0eek(z0yek, z0rek, p2: true);
	}

	public override void Dispose()
	{
		base.Dispose();
		z0tek = null;
		z0uek = null;
		z0yek = null;
	}
}
