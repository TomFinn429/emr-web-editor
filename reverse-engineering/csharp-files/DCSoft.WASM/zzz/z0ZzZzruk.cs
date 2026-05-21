using System;
using System.Text;

namespace zzz;

public static class z0ZzZzruk
{
	public static string z0eek(Exception p0)
	{
		if (p0.InnerException == null)
		{
			return p0.Message;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (Exception ex = p0; ex != null; ex = ex.InnerException)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(">>");
			}
			stringBuilder.Append(ex.Message);
		}
		return stringBuilder.ToString();
	}

	static z0ZzZzruk()
	{
	}
}
