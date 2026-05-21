using System.Collections.Generic;

namespace zzz;

internal abstract class z0ZzZzqgj
{
	private readonly IList<z0ZzZzaqj> z0rek;

	protected z0ZzZzqgj(IList<z0ZzZzaqj> p0)
	{
		z0rek = p0;
	}

	internal void z0eek(z0ZzZzeaj p0)
	{
		z0ZzZzdsj p1 = p0.z0tek_jiejie20260327142557();
		int count = z0rek.Count;
		switch (count)
		{
		case 1:
		{
			z0ZzZzaqj z0ZzZzaqj2 = z0rek[0];
			p0.Add("Filter", new z0ZzZzhwj(z0ZzZzaqj2.z0wfk()));
			p0.z0tek_jiejie20260327142557("DecodeParms", z0ZzZzaqj2.z0efk(p1));
			return;
		}
		case 0:
			return;
		}
		object[] array = new object[count];
		object[] array2 = new object[count];
		for (int i = 0; i < count; i++)
		{
			z0ZzZzaqj z0ZzZzaqj3 = z0rek[i];
			array[i] = new z0ZzZzhwj(z0ZzZzaqj3.z0wfk());
			array2[i] = z0ZzZzaqj3.z0efk(p1);
		}
		p0.Add("Filter", new z0ZzZzdaj(array));
		p0.Add("DecodeParms", new z0ZzZzdaj(array2));
	}

	internal abstract byte[] z0qsk();
}
