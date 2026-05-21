using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzxlj
{
	private z0ZzZzvlj z0yek = new z0ZzZzvlj();

	private Stack<z0ZzZzvlj> z0uek = new Stack<z0ZzZzvlj>();

	internal void z0eek()
	{
		z0uek.Push(new z0ZzZzvlj(z0yek));
	}

	internal void z0rek()
	{
		if (z0uek.Count == 0)
		{
			z0yek = new z0ZzZzvlj();
		}
		else
		{
			z0yek = z0uek.Pop();
		}
	}

	internal z0ZzZzvlj z0tek()
	{
		return z0yek;
	}
}
