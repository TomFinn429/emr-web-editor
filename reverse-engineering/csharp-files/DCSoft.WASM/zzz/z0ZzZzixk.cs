using System;
using DCSystem_Drawing;

namespace zzz;

internal static class z0ZzZzixk
{
	internal static readonly float z0pek;

	internal static float z0eek(float p0)
	{
		return p0;
	}

	internal static float z0eek(GraphicsUnit p0)
	{
		switch (p0)
		{
		case GraphicsUnit.Display:
			return 75f;
		case GraphicsUnit.Inch:
			return 1f;
		case GraphicsUnit.Document:
			return 300f;
		case GraphicsUnit.Millimeter:
			return 25.4f;
		case GraphicsUnit.World:
		case GraphicsUnit.Pixel:
			return 96f;
		case GraphicsUnit.Point:
			return 72f;
		default:
			throw new ArgumentException("unit");
		}
	}

	static z0ZzZzixk()
	{
		z0pek = 96f;
		using z0ZzZzrfh p = new z0ZzZzrfh(1, 1);
		using z0ZzZzadh z0ZzZzadh2 = z0ZzZzadh.z0eek(p);
		z0pek = z0ZzZzadh2.z0pek();
	}

	internal static float z0rek(GraphicsUnit p0)
	{
		switch (p0)
		{
		case GraphicsUnit.Display:
			return 75f;
		case GraphicsUnit.Inch:
			return 1f;
		case GraphicsUnit.Document:
			return 300f;
		case GraphicsUnit.Millimeter:
			return 25.4f;
		case GraphicsUnit.World:
		case GraphicsUnit.Pixel:
			return z0pek;
		case GraphicsUnit.Point:
			return 72f;
		default:
			throw new ArgumentException("unit");
		}
	}
}
