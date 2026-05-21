namespace zzz;

internal class z0ZzZzraj : z0ZzZznsj, z0ZzZzlgj
{
	private readonly z0ZzZzeaj z0tek;

	private void z0eek(z0ZzZzpgj p0, int p1)
	{
		byte[] array = z0eek();
		z0tek["Length"] = array.Length;
		((z0ZzZzlgj)z0tek).z0nfk(p0, p1);
		p0.z0eek("stream\r\n");
		p0.z0eek(array);
		p0.z0eek("\r\nendstream");
	}

	void z0ZzZzlgj.z0nfk(z0ZzZzpgj p0, int p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		this.z0eek(p0, p1);
	}

	internal z0ZzZzraj(z0ZzZzeaj p0, byte[] p1)
		: base(p1)
	{
		z0tek = p0;
	}

	internal static z0ZzZzraj z0eek(z0ZzZzeaj p0, byte[] p1)
	{
		return new z0ZzZzkgj(p1).z0eek(p0);
	}
}
