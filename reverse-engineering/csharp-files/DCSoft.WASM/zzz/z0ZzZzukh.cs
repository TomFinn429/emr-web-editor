using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzukh : List<z0ZzZzykh>, ICloneable
{
	private object z0eek()
	{
		z0ZzZzukh z0ZzZzukh2 = new z0ZzZzukh();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzykh current = enumerator.Current;
			z0ZzZzukh2.Add(current.z0oek());
		}
		return z0ZzZzukh2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	public z0ZzZzukh z0rek()
	{
		return (z0ZzZzukh)((ICloneable)this).Clone();
	}
}
