using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzokj : z0ZzZztkj
{
	internal z0ZzZzokj(z0ZzZzaxk p0, z0ZzZzjej p1)
		: base(p0, p1)
	{
	}

	protected override z0ZzZzykj z0zsk()
	{
		z0ZzZzdxk z0ZzZzdxk2 = base.z0eek().z0tek();
		Color[] array = z0ZzZzdxk2.z0eek();
		if (z0eek())
		{
			Color[] array2 = new Color[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				byte a = array[i].A;
				array2[i] = Color.FromArgb(a, a, a);
			}
			z0ZzZzdxk obj = new z0ZzZzdxk();
			obj.z0eek(array2);
			obj.z0eek(z0ZzZzdxk2.z0rek());
			return new z0ZzZzpkj(obj);
		}
		return null;
	}

	protected override z0ZzZzykj z0xsk()
	{
		return new z0ZzZzpkj(base.z0eek().z0tek());
	}

	internal override byte z0csk()
	{
		if (z0eek())
		{
			return 255;
		}
		return base.z0eek().z0tek().z0eek()[0].A;
	}

	private new bool z0eek()
	{
		Color[] array = base.z0eek().z0tek().z0eek();
		byte a = array[0].A;
		bool flag = false;
		for (int i = 1; i < array.Length; i++)
		{
			flag |= array[i].A != a;
		}
		return flag;
	}
}
