namespace zzz;

internal static class z0ZzZziwh
{
	public static bool z0eek(char p0)
	{
		if ((p0 >= 'a' && p0 <= 'z') || (p0 >= 'A' && p0 <= 'Z') || (p0 >= '0' && p0 <= '9'))
		{
			return true;
		}
		switch (p0)
		{
		case '!':
		case '(':
		case ')':
		case '*':
		case '-':
		case '.':
		case '_':
			return true;
		default:
			return false;
		}
	}
}
