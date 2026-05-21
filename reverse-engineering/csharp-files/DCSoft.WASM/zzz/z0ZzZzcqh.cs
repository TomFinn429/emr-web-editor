using System;
using System.Globalization;

namespace zzz;

internal struct z0ZzZzcqh
{
	internal z0ZzZznqh z0rek;

	internal int z0tek;

	internal string z0yek;

	internal bool z0uek;

	public z0ZzZzcqh(z0ZzZznqh p0)
	{
		z0rek = p0;
		z0uek = z0eek(p0);
		z0tek = -1;
		z0yek = null;
	}

	internal static bool z0eek(z0ZzZznqh p0)
	{
		if (p0 != (z0ZzZznqh)2)
		{
			return p0 == (z0ZzZznqh)3;
		}
		return true;
	}

	internal static string z0eek(z0ZzZzmqh p0, string p1, string p2)
	{
		if (!p2.EndsWith(Environment.NewLine, StringComparison.Ordinal))
		{
			p2 = p2.Trim();
			if (!z0ZzZzewh.z0eek(p2, '.'))
			{
				p2 += ".";
			}
			p2 += " ";
		}
		p2 += z0ZzZzewh.z0eek("Path '{0}'", CultureInfo.InvariantCulture, p1);
		if (p0 != null && p0.z0iq())
		{
			p2 += z0ZzZzewh.z0eek(", line {0}, position {1}", CultureInfo.InvariantCulture, p0.z0tq(), p0.z0rq());
		}
		p2 += ".";
		return p2;
	}
}
