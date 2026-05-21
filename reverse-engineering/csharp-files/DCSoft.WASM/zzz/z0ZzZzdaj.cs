using System.Collections;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzdaj : zzz.z0ZzZzsaj<object>, IEnumerable<object>, IEnumerable
{
	private static IEnumerable<object> z0eek(IEnumerable p0)
	{
		IEnumerable enumerable = default(IEnumerable);
		foreach (object item in enumerable)
		{
			yield return item;
		}
	}

	internal z0ZzZzdaj(IEnumerable<object> p0)
		: base(p0)
	{
	}

	internal z0ZzZzdaj(IEnumerable p0)
		: base(z0eek(p0))
	{
	}

	private IEnumerator<object> z0eek()
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			yield return enumerator.Current;
		}
	}

	IEnumerator<object> IEnumerable<object>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	protected override void z0mfk(z0ZzZzpgj p0, object p1, int p2)
	{
		p0.z0eek(p1, p2);
	}
}
