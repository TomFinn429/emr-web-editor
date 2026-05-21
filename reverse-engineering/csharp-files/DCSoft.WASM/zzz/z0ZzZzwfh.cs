using System.Text;

namespace zzz;

internal static class z0ZzZzwfh
{
	private static StringBuilder z0tek;

	public static StringBuilder z0eek(int p0 = 16)
	{
		if (p0 <= 360)
		{
			StringBuilder stringBuilder = z0tek;
			if (stringBuilder != null && p0 <= stringBuilder.Capacity)
			{
				z0tek = null;
				stringBuilder.Clear();
				return stringBuilder;
			}
		}
		return new StringBuilder(p0);
	}

	public static string z0eek(StringBuilder p0)
	{
		string result = p0.ToString();
		z0rek(p0);
		return result;
	}

	public static void z0rek(StringBuilder p0)
	{
		if (p0.Capacity <= 360)
		{
			z0tek = p0;
		}
	}
}
