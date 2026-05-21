using DCSystem_Drawing;

namespace zzz;

internal static class z0ZzZzbxk
{
	internal static float z0eek(float p0, GraphicsUnit p1)
	{
		return p1 switch
		{
			GraphicsUnit.Document => z0eek(p0), 
			GraphicsUnit.Inch => z0tek(p0), 
			GraphicsUnit.Millimeter => z0rek(p0), 
			GraphicsUnit.Point => p0, 
			_ => p0, 
		};
	}

	private static float z0eek(float p0)
	{
		return p0 * 6f / 25f;
	}

	private static float z0rek(float p0)
	{
		return 72f * p0 / 25.4f;
	}

	private static float z0tek(float p0)
	{
		return p0 * 72f;
	}
}
