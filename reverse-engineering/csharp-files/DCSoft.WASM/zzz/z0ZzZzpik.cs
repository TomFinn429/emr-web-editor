namespace zzz;

public static class z0ZzZzpik
{
	public static string z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		string text = p0;
		int num = p0.IndexOf("://");
		string text2 = null;
		if (num > 0)
		{
			text2 = p0.Substring(0, num + 3);
			p0 = p0.Substring(num + 3);
		}
		int num2 = p0.LastIndexOfAny(new char[2] { '\\', '/' });
		text = ((num2 <= 0) ? p0 : p0.Substring(0, num2));
		return text2 + text;
	}
}
