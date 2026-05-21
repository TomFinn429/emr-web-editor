using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzzzj : z0ZzZzxzj
{
	private new bool z0eek;

	private new XTextElement z0rek;

	private bool z0tek;

	public override void Dispose()
	{
		base.Dispose();
		z0rek = null;
	}

	public z0ZzZzzzj(XTextElement p0, bool p1, bool p2)
	{
		z0rek = p0;
		z0tek = p1;
		z0eek = p2;
	}

	public override void z0yo(z0ZzZzpgh p0)
	{
		z0rek.z0or(z0eek, p1: false, p2: false);
		z0eek().z0rek().Add(z0rek);
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		z0rek.z0or(z0tek, p1: false, p2: false);
		z0eek().z0rek().Add(z0rek);
	}
}
