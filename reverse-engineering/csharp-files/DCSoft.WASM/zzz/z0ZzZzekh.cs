using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzekh : List<z0ZzZzwkh>, ICloneable
{
	public z0ZzZzekh z0eek()
	{
		return (z0ZzZzekh)((ICloneable)this).Clone();
	}

	private object z0rek()
	{
		z0ZzZzekh z0ZzZzekh2 = new z0ZzZzekh();
		using List<z0ZzZzwkh>.Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzwkh current = enumerator.Current;
			z0ZzZzekh2.Add(current.z0eek());
		}
		return z0ZzZzekh2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek();
	}
}
