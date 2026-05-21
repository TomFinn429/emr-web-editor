namespace System;

internal static class UncNameHelper
{
	public static string ParseCanonicalName(string P_0, int P_1, int P_2, ref bool P_3)
	{
		return System.DomainNameHelper.ParseCanonicalName(P_0, P_1, P_2, ref P_3);
	}

	public unsafe static bool IsValid(char* P_0, int P_1, ref int P_2, bool P_3)
	{
		int num = P_2;
		if (P_1 == num)
		{
			return false;
		}
		bool flag = false;
		int i;
		for (i = P_1; i < num; i++)
		{
			if (P_0[i] == '/' || P_0[i] == '\\' || (P_3 && (P_0[i] == ':' || P_0[i] == '?' || P_0[i] == '#')))
			{
				num = i;
				break;
			}
			if (P_0[i] == '.')
			{
				i++;
				break;
			}
			if (char.IsLetter(P_0[i]) || P_0[i] == '-' || P_0[i] == '_')
			{
				flag = true;
			}
			else if (!char.IsAsciiDigit(P_0[i]))
			{
				return false;
			}
		}
		if (!flag)
		{
			return false;
		}
		for (; i < num; i++)
		{
			if (P_0[i] == '/' || P_0[i] == '\\' || (P_3 && (P_0[i] == ':' || P_0[i] == '?' || P_0[i] == '#')))
			{
				num = i;
				break;
			}
			if (P_0[i] == '.')
			{
				if (!flag || (i - 1 >= P_1 && P_0[i - 1] == '.'))
				{
					return false;
				}
				flag = false;
				continue;
			}
			if (P_0[i] == '-' || P_0[i] == '_')
			{
				if (!flag)
				{
					return false;
				}
				continue;
			}
			if (char.IsLetter(P_0[i]) || char.IsAsciiDigit(P_0[i]))
			{
				if (!flag)
				{
					flag = true;
				}
				continue;
			}
			return false;
		}
		if (i - 1 >= P_1 && P_0[i - 1] == '.')
		{
			flag = true;
		}
		if (!flag)
		{
			return false;
		}
		P_2 = num;
		return true;
	}
}
