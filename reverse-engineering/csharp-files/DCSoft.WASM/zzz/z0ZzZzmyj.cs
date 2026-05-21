namespace zzz;

internal static class z0ZzZzmyj
{
	public static bool z0eek(z0ZzZzftj p0)
	{
		if (p0.z0uek().Count == 0)
		{
			return false;
		}
		if (p0.z0uek().Count == 1 && p0.z0uek()[0] is z0ZzZzitj && ((z0ZzZzitj)p0.z0uek()[0]).z0uek().Count == 0)
		{
			return false;
		}
		return true;
	}
}
