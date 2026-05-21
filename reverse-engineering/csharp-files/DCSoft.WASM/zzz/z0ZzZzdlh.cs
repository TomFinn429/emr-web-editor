using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzdlh : z0ZzZzxzj
{
	private new string z0eek;

	private new object z0rek;

	private object z0tek;

	private new XTextDocument z0yek;

	public override void z0yo(z0ZzZzpgh p0)
	{
		if (z0eek == "DefaultStyle")
		{
			z0yek.z0bek((DocumentContentStyle)z0rek, p1: false);
		}
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		if (z0eek == "DefaultStyle")
		{
			z0yek.z0bek((DocumentContentStyle)z0tek, p1: false);
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		z0yek = null;
		z0eek = null;
		z0tek = null;
		z0rek = null;
	}

	public z0ZzZzdlh(XTextDocument p0, string p1, object p2, object p3)
	{
		z0yek = p0;
		z0eek = p1;
		z0tek = p2;
		z0rek = p3;
	}
}
