using System;
using System.Collections;

namespace zzz;

public class z0ZzZzhik : IEnumerable
{
	private class z0ick : IEnumerator
	{
		private readonly IList z0eek;

		private int z0rek;

		public object Current
		{
			get
			{
				if (z0rek >= 0 && z0rek < z0eek.Count)
				{
					return z0eek[z0rek];
				}
				throw new IndexOutOfRangeException("index:" + z0rek + ",count:" + z0eek.Count);
			}
		}

		public void Reset()
		{
			z0rek = z0eek.Count;
		}

		public bool MoveNext()
		{
			z0rek--;
			return z0rek >= 0;
		}

		public z0ick(IList p0)
		{
			z0eek = p0;
			z0rek = p0.Count;
		}
	}

	private readonly IList z0eek;

	public IEnumerator GetEnumerator()
	{
		return new z0ick(z0eek);
	}

	public z0ZzZzhik(IList p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("srcList");
		}
		z0eek = p0;
	}
}
