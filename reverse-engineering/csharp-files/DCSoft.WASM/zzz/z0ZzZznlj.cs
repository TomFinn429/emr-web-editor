using DCSystem_Drawing;

namespace zzz;

internal static class z0ZzZznlj
{
	internal static z0ZzZziwj z0eek(z0ZzZzbdh p0)
	{
		float num = p0.z0tek();
		float num2 = p0.z0yek();
		return new z0ZzZziwj(num, num2, p0.z0uek() + num, p0.z0iek() + num2);
	}

	internal static z0ZzZzmaj z0eek(Color p0)
	{
		return new z0ZzZzmaj(z0rek(p0));
	}

	internal static double[] z0rek(Color p0)
	{
		return new double[3]
		{
			(float)(int)p0.R / 255f,
			(float)(int)p0.G / 255f,
			(float)(int)p0.B / 255f
		};
	}
}
