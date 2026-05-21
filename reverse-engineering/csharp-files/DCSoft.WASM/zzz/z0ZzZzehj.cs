using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzehj : z0ZzZzykj
{
	private new readonly z0ZzZzgxk z0eek;

	private new readonly Color[] z0rek;

	protected override z0ZzZzuwj[] z0vsk_jiejie20260327142557()
	{
		double[] array = z0eek.z0rek();
		z0ZzZzuwj[] array2 = new z0ZzZzuwj[array.Length];
		double p = 0.0;
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = new z0ZzZzuwj(p, array[i]);
			p = array[i];
		}
		return array2;
	}

	protected override zzz.z0ZzZzasj<z0ZzZzlqj> z0bsk(z0ZzZzugj p0)
	{
		double[] p1 = z0ZzZznlj.z0rek(z0rek[0]);
		double[] p2 = z0ZzZznlj.z0rek(z0rek[1]);
		z0ZzZzlqj item = new z0ZzZzdqj(p1, p2, 1.0, z0ZzZzykj.z0tek(), z0ZzZzykj.z0rek());
		double[] array = z0eek.z0eek();
		zzz.z0ZzZzasj<z0ZzZzlqj> z0ZzZzasj2 = new zzz.z0ZzZzasj<z0ZzZzlqj>(p0.z0uek());
		for (int i = 0; i < array.Length; i++)
		{
			z0ZzZzasj2.Add(item);
		}
		return z0ZzZzasj2;
	}

	internal z0ZzZzehj(Color[] p0, z0ZzZzgxk p1)
		: base(p1.z0eek())
	{
		z0rek = p0;
		z0eek = p1;
	}
}
