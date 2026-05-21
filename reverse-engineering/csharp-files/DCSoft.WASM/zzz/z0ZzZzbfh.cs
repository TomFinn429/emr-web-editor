using DCSystem_Drawing;

namespace zzz;

public sealed class z0ZzZzbfh
{
	private GraphicsUnit z0rek = GraphicsUnit.Document;

	private z0ZzZzbdh z0tek = z0ZzZzbdh.z0xek;

	private z0ZzZzjdh z0yek;

	public void z0eek(z0ZzZzadh p0)
	{
		p0.z0eek(z0rek);
		p0.z0eek(z0yek);
		p0.z0eek();
	}

	public z0ZzZzbfh(z0ZzZzadh p0)
	{
		z0rek = p0.z0jrk();
		z0tek = p0.z0nek_jiejie20260327142557();
		if (!p0.z0vek().z0iek())
		{
			z0yek = p0.z0vek().z0uek();
			if (z0yek.z0rek() != (float)(int)z0yek.z0rek())
			{
				ref z0ZzZzbdh reference = ref z0tek;
				reference.z0tek(reference.z0uek() + 1f);
			}
		}
	}
}
