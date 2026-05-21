using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZznxk
{
	private float z0rek;

	private float z0tek;

	private float z0yek;

	private float z0uek;

	private float z0iek;

	internal z0ZzZznxk(z0ZzZzpej p0, GraphicsUnit p1)
	{
		z0iek = z0ZzZziej.z0rek(p0);
		z0uek = z0ZzZziej.z0eek(p0);
		z0yek = z0ZzZziej.z0tek(p0);
		z0tek = z0ZzZzixk.z0eek(p0.z0uek);
		z0rek = z0ZzZzixk.z0eek(p1);
	}

	internal static z0ZzZznxk z0eek(z0ZzZzpej p0, GraphicsUnit p1)
	{
		if (p0 == null)
		{
			return new z0ZzZznxk();
		}
		return new z0ZzZznxk(p0, p1);
	}

	internal float z0eek(int p0)
	{
		return z0ZzZzoxk.z0eek(z0yek * (float)(p0 - 1) + z0iek + z0uek, z0tek, z0rek);
	}

	internal z0ZzZznxk()
	{
	}
}
