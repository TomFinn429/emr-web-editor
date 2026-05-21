using System;
using System.Collections;

namespace zzz;

internal sealed class z0ZzZzqah : IEnumerator
{
	private readonly z0ZzZzaah z0eek;

	private int z0rek;

	private z0ZzZzoah z0tek;

	public object Current => z0tek;

	public void Reset()
	{
		z0tek = null;
		z0rek = z0eek.z0rek();
	}

	public z0ZzZzqah(z0ZzZzaah p0)
	{
		z0eek = p0;
		z0tek = null;
		z0rek = p0.z0rek();
	}

	public bool MoveNext()
	{
		if (z0eek.z0rek() != z0rek)
		{
			throw new InvalidOperationException();
		}
		z0tek = z0eek.z0eek(z0tek);
		return z0tek != null;
	}
}
