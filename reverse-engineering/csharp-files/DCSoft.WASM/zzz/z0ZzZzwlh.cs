using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzwlh : z0ZzZzxzj
{
	private new float z0eek;

	private new bool z0rek = true;

	private XTextTableColumnElement z0tek;

	private new float z0yek;

	public override void z0yo(z0ZzZzpgh p0)
	{
		z0tek.z0eek(z0eek, p1: false, z0rek);
	}

	public override void Dispose()
	{
		base.Dispose();
		z0tek = null;
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		z0tek.z0eek(z0yek, p1: false, z0rek);
	}

	public z0ZzZzwlh(XTextTableColumnElement p0, float p1, float p2, bool p3)
	{
		z0tek = p0;
		z0yek = p1;
		z0eek = p2;
		z0rek = p3;
	}
}
