using System.Text;

namespace System.Xml;

internal static class XmlComplianceUtil
{
	public static string NonCDataNormalize(string P_0)
	{
		int length = P_0.Length;
		if (length <= 0)
		{
			return string.Empty;
		}
		int num = 0;
		StringBuilder stringBuilder = null;
		while (XmlCharType.IsWhiteSpace(P_0[num]))
		{
			num++;
			if (num == length)
			{
				return " ";
			}
		}
		int num2 = num;
		while (num2 < length)
		{
			if (!XmlCharType.IsWhiteSpace(P_0[num2]))
			{
				num2++;
				continue;
			}
			int i;
			for (i = num2 + 1; i < length && XmlCharType.IsWhiteSpace(P_0[i]); i++)
			{
			}
			if (i == length)
			{
				if (stringBuilder == null)
				{
					return P_0.Substring(num, num2 - num);
				}
				stringBuilder.Append(P_0, num, num2 - num);
				return stringBuilder.ToString();
			}
			if (i > num2 + 1 || P_0[num2] != ' ')
			{
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(length);
				}
				stringBuilder.Append(P_0, num, num2 - num);
				stringBuilder.Append(' ');
				num = i;
				num2 = i;
			}
			else
			{
				num2++;
			}
		}
		if (stringBuilder != null)
		{
			if (num < num2)
			{
				stringBuilder.Append(P_0, num, num2 - num);
			}
			return stringBuilder.ToString();
		}
		if (num > 0)
		{
			return P_0.Substring(num, length - num);
		}
		return P_0;
	}

	public static string CDataNormalize(string P_0)
	{
		int length = P_0.Length;
		if (length <= 0)
		{
			return string.Empty;
		}
		int num = 0;
		int num2 = 0;
		StringBuilder stringBuilder = null;
		while (num < length)
		{
			char c = P_0[num];
			switch (c)
			{
			default:
				num++;
				break;
			case '\t':
			case '\n':
			case '\r':
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(length);
				}
				if (num2 < num)
				{
					stringBuilder.Append(P_0, num2, num - num2);
				}
				stringBuilder.Append(' ');
				num = ((c != '\r' || num + 1 >= length || P_0[num + 1] != '\n') ? (num + 1) : (num + 2));
				num2 = num;
				break;
			}
		}
		if (stringBuilder == null)
		{
			return P_0;
		}
		if (num > num2)
		{
			stringBuilder.Append(P_0, num2, num - num2);
		}
		return stringBuilder.ToString();
	}
}
