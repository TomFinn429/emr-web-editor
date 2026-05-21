using System;
using System.Collections;

namespace zzz;

internal sealed class z0ZzZzjij : z0ZzZzuij
{
	public z0ZzZzcdh z0eek(string p0, z0ZzZzmuj p1, int p2, int p3, Hashtable p4)
	{
		z0ZzZzcdh result = new z0ZzZzcdh(0, 0);
		if (p1 == z0ZzZzmuj.z0rek)
		{
			return result;
		}
		if (p1 == z0ZzZzmuj.z0tek)
		{
			return result;
		}
		if (p1 == z0ZzZzmuj.z0yek)
		{
			return new z0ZzZzrij().z0eek(p0, p1, p2, p3, p4);
		}
		throw new ArgumentException("No encoder available for format " + p1);
	}

	public z0ZzZzcdh z0eek(string p0, z0ZzZzmuj p1, int p2, int p3)
	{
		return z0eek(p0, p1, p2, p3, null);
	}

	public z0ZzZzbuj z0pkk(string p0, z0ZzZzmuj p1, int p2, int p3, Hashtable p4)
	{
		if (p1 == z0ZzZzmuj.z0yek)
		{
			return new z0ZzZzrij().z0pkk(p0, p1, p2, p3, p4);
		}
		throw new ArgumentException("No encoder available for format " + p1);
	}
}
