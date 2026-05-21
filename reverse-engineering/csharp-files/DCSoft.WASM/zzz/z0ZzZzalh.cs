using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzalh : z0ZzZzxzj
{
	private new readonly int z0eek = -1;

	private new XTextElement z0rek;

	private readonly int z0tek = -1;

	public z0ZzZzalh(XTextElement p0, int p1, int p2)
	{
		z0rek = p0;
		z0tek = p1;
		z0eek = p2;
	}

	public override void z0yo(z0ZzZzpgh p0)
	{
		z0rek.z0oek(z0eek);
		z0eek().z0rek().Add(z0rek);
	}

	public override void Dispose()
	{
		base.Dispose();
		z0rek = null;
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		z0rek.z0oek(z0tek);
		z0eek().z0rek().Add(z0rek);
	}
}
