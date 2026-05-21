using System;

namespace zzz;

internal abstract class z0ZzZznaj : z0ZzZzfsj
{
	internal static z0ZzZznaj z0eek(z0ZzZzdsj p0, object p1)
	{
		throw new NotSupportedException();
	}

	protected internal abstract object z0qfk(z0ZzZzdsj p0);

	internal abstract int z0afk();

	internal static z0ZzZznaj z0eek(string p0)
	{
		switch (p0)
		{
		case "DeviceGray":
		case "G":
			return new z0ZzZzjqj((z0ZzZzhqj)0);
		case "DeviceRGB":
		case "RGB":
			return new z0ZzZzjqj((z0ZzZzhqj)1);
		case "DeviceCMYK":
		case "CMYK":
			return new z0ZzZzjqj((z0ZzZzhqj)2);
		case "Pattern":
			return new z0ZzZztwj();
		default:
			return null;
		}
	}
}
