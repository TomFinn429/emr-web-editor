using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzmqj
{
	private readonly z0ZzZzywj z0yek;

	private bool z0uek;

	private readonly List<z0ZzZznqj> z0iek = new List<z0ZzZznqj>();

	internal IList<z0ZzZznqj> z0eek()
	{
		return z0iek;
	}

	internal bool z0rek()
	{
		return z0uek;
	}

	internal z0ZzZzmqj(z0ZzZzywj p0)
	{
		z0yek = p0;
	}

	internal void z0eek(z0ZzZzywj p0)
	{
		z0iek.Add(new z0ZzZzzqj(p0));
	}

	internal z0ZzZzywj z0tek()
	{
		return z0yek;
	}

	internal void z0eek(z0ZzZzywj p0, z0ZzZzywj p1, z0ZzZzywj p2)
	{
		z0iek.Add(new z0ZzZzuaj(p0, p1, p2));
	}

	internal void z0eek(bool p0)
	{
		z0uek = p0;
	}
}
