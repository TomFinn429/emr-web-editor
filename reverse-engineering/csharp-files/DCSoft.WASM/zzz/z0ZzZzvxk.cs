using System;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzvxk : z0ZzZzcxk
{
	public override z0ZzZzxdh z0nak(string p0, z0ZzZzpej p1, z0ZzZzxdh p2, z0ZzZzlsh p3, GraphicsUnit p4)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return default(z0ZzZzxdh);
		}
		z0eek_jiejie20260327142557().z0eek(p4);
		z0ZzZzxdh result = p1.z0eek(z0eek_jiejie20260327142557(), p0, p2, p3);
		string[] array = z0ZzZzlxk.z0rek(z0ZzZzzxk.z0eek(p0));
		if (array.Length == 1)
		{
			return result;
		}
		string[] array2 = array;
		foreach (string p5 in array2)
		{
			result.z0eek(Math.Max(result.z0rek(), p1.z0eek(z0eek_jiejie20260327142557(), p5, p2, p3).z0rek()));
		}
		return result;
	}

	public override z0ZzZzxdh z0mak(string p0, z0ZzZzsdh p1, z0ZzZzxdh p2, z0ZzZzlsh p3, GraphicsUnit p4)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return default(z0ZzZzxdh);
		}
		z0eek_jiejie20260327142557().z0eek(p4);
		z0ZzZzxdh result = z0eek_jiejie20260327142557().z0eek(p0, p1, p2, p3);
		string[] array = z0ZzZzlxk.z0rek(z0ZzZzzxk.z0eek(p0));
		if (array.Length == 1)
		{
			return result;
		}
		string[] array2 = array;
		foreach (string p5 in array2)
		{
			result.z0eek(Math.Max(result.z0rek(), z0eek_jiejie20260327142557().z0eek(p5, p1, p2, p3).z0rek()));
		}
		return result;
	}
}
