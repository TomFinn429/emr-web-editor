using System.Collections;
using System.Text;

namespace zzz;

public static class z0ZzZzyck
{
	public static string z0eek(IEnumerable p0, string p1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string item in p0)
		{
			if (stringBuilder.Length > 0 && p1 != null)
			{
				stringBuilder.Append(p1);
			}
			stringBuilder.Append(item);
		}
		return stringBuilder.ToString();
	}
}
