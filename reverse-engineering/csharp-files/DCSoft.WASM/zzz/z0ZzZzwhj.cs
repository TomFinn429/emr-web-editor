using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzwhj : z0ZzZztkj
{
	internal override z0ZzZzrwj z0tsk(z0ZzZzmlj p0)
	{
		z0ZzZzaxk z0ZzZzaxk2 = base.z0eek();
		if (!z0eek() && z0ZzZzaxk2.z0eek().z0eek().Length <= 1)
		{
			Color[] array = z0ZzZzaxk2.z0rek();
			z0ZzZziwj z0ZzZziwj2 = z0ZzZznlj.z0eek(z0ZzZzaxk2.z0yek());
			return z0ZzZzpzk.z0eek(((z0ZzZzrxk)z0ZzZzaxk2).z0rek(), z0rek_jiejie20260327142557(), z0ZzZziwj2, p0.z0rek().z0eek(array[0], array[1]), null, p0.z0cek(), new z0ZzZzjej(z0ZzZziwj2.z0eek(), 0.0, 0.0, 1.0, z0ZzZziwj2.z0oek(), z0ZzZziwj2.z0yek()));
		}
		return base.z0tsk(p0);
	}

	protected override z0ZzZzykj z0xsk()
	{
		return new z0ZzZzehj(base.z0eek().z0rek(), base.z0eek().z0eek());
	}

	internal override byte z0csk()
	{
		if (z0eek())
		{
			return 255;
		}
		return base.z0eek().z0rek()[0].A;
	}

	protected override z0ZzZzykj z0zsk()
	{
		Color[] array = base.z0eek().z0rek();
		if (z0eek())
		{
			Color[] array2 = new Color[2];
			for (int i = 0; i < 2; i++)
			{
				byte a = array[i].A;
				array2[i] = Color.FromArgb(a, a, a);
			}
			return new z0ZzZzehj(array2, base.z0eek().z0eek());
		}
		return null;
	}

	internal z0ZzZzwhj(z0ZzZzaxk p0, z0ZzZzjej p1)
		: base(p0, p1)
	{
	}

	private new bool z0eek()
	{
		Color[] array = base.z0eek().z0rek();
		return array[0].A != array[1].A;
	}
}
