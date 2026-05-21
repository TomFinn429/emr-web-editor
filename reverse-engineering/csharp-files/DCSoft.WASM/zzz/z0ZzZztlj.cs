using System;
using System.Collections.Generic;
using System.Security;
using DCSystem_Drawing;

namespace zzz;

internal static class z0ZzZztlj
{
	internal delegate z0ZzZzzfj z0upk(string fontName, FontStyle style, bool enabledCacheInMemory);

	private static readonly Dictionary<string, bool> z0rek = new Dictionary<string, bool>();

	internal static z0upk z0yek = null;

	[SecuritySafeCritical]
	public static z0ZzZzzfj z0eek(z0ZzZzpej p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("font");
		}
		if (z0yek != null)
		{
			return z0yek(p0.z0iek, p0.z0mek, enabledCacheInMemory: true);
		}
		throw new NotSupportedException("WASM.CreateFontFile");
	}

	private static bool z0eek(z0ZzZzpej p0, z0ZzZzzfj p1)
	{
		if (!p0.z0eek())
		{
			return false;
		}
		bool result = false;
		lock (z0rek)
		{
			if (z0rek.TryGetValue(p0.z0iek, out result))
			{
				return result;
			}
		}
		result = z0ZzZzzfj.z0uek(z0eek(new z0ZzZzpej(p0.z0iek, p0.z0bek)), p1);
		lock (z0rek)
		{
			z0rek[p0.z0iek] = result;
			return result;
		}
	}

	internal static z0ZzZzngj z0eek(z0ZzZzbhj p0, z0ZzZzpej p1, z0ZzZzvgj p2)
	{
		z0ZzZzzfj z0ZzZzzfj2 = z0eek(p1);
		if (z0ZzZzzfj2 == null)
		{
			throw new NotSupportedException(p1.z0iek);
		}
		z0ZzZzbfj p3 = new z0ZzZzldj(p1.z0iek, (z0ZzZziqj)p1.z0mek, z0ZzZzzfj2, z0eek(p1, z0ZzZzzfj2));
		if (p2 == (z0ZzZzvgj)0)
		{
			return new z0ZzZzngj(new z0ZzZzxgj(p0, p3, !z0ZzZzzfj2.z0iek()), p3, new z0ZzZzzgj(z0ZzZzzfj2, new z0ZzZzplj(p1)));
		}
		throw new InvalidOperationException("PDF font not Embedded");
	}
}
