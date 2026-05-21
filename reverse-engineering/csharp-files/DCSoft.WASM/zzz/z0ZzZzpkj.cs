using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzpkj : z0ZzZzykj
{
	private new readonly z0ZzZzdxk z0eek;

	protected override z0ZzZzuwj[] z0vsk_jiejie20260327142557()
	{
		double[] array = z0eek.z0rek();
		z0ZzZzuwj[] array2 = new z0ZzZzuwj[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = new z0ZzZzuwj(0.0, 1.0);
		}
		return array2;
	}

	internal z0ZzZzpkj(z0ZzZzdxk p0)
		: base(p0.z0rek())
	{
		z0eek = p0;
	}

	protected override zzz.z0ZzZzasj<z0ZzZzlqj> z0bsk(z0ZzZzugj p0)
	{
		Color[] array = z0eek.z0eek();
		double[] p1 = z0ZzZznlj.z0rek(array[0]);
		zzz.z0ZzZzasj<z0ZzZzlqj> z0ZzZzasj2 = new zzz.z0ZzZzasj<z0ZzZzlqj>(p0.z0uek());
		z0ZzZzuwj[] p2 = z0ZzZzykj.z0tek();
		z0ZzZzuwj[] p3 = z0ZzZzykj.z0rek();
		for (int i = 0; i < array.Length; i++)
		{
			double[] array2 = z0ZzZznlj.z0rek(array[i]);
			z0ZzZzasj2.Add(new z0ZzZzdqj(p1, array2, 1.0, p2, p3));
			p1 = array2;
		}
		return z0ZzZzasj2;
	}
}
