namespace System.Xml;

internal static class ValidateNames
{
	internal static int ParseNmtoken(string P_0, int P_1)
	{
		int i;
		for (i = P_1; i < P_0.Length && XmlCharType.IsNCNameSingleChar(P_0[i]); i++)
		{
		}
		return i - P_1;
	}

	internal static int ParseNmtokenNoNamespaces(string P_0, int P_1)
	{
		int i;
		for (i = P_1; i < P_0.Length && (XmlCharType.IsNameSingleChar(P_0[i]) || P_0[i] == ':'); i++)
		{
		}
		return i - P_1;
	}

	internal static int ParseNameNoNamespaces(string P_0, int P_1)
	{
		int i = P_1;
		if (i < P_0.Length)
		{
			if (!XmlCharType.IsStartNCNameSingleChar(P_0[i]) && P_0[i] != ':')
			{
				return 0;
			}
			for (i++; i < P_0.Length && (XmlCharType.IsNCNameSingleChar(P_0[i]) || P_0[i] == ':'); i++)
			{
			}
		}
		return i - P_1;
	}

	internal static int ParseNCName(string P_0, int P_1)
	{
		int i = P_1;
		if (i < P_0.Length)
		{
			if (!XmlCharType.IsStartNCNameSingleChar(P_0[i]))
			{
				return 0;
			}
			for (i++; i < P_0.Length && XmlCharType.IsNCNameSingleChar(P_0[i]); i++)
			{
			}
		}
		return i - P_1;
	}

	internal static int ParseNCName(string P_0)
	{
		return ParseNCName(P_0, 0);
	}

	internal static int ParseQName(string P_0, int P_1, out int P_2)
	{
		P_2 = 0;
		int num = ParseNCName(P_0, P_1);
		if (num != 0)
		{
			P_1 += num;
			if ((uint)P_1 < (uint)P_0.Length && P_0[P_1] == ':')
			{
				int num2 = ParseNCName(P_0, P_1 + 1);
				if (num2 != 0)
				{
					P_2 = P_1;
					num += num2 + 1;
				}
			}
		}
		return num;
	}

	internal static int ParseQNameThrow(string P_0)
	{
		int result;
		int num = ParseQName(P_0, 0, out result);
		if (num == 0 || num != P_0.Length)
		{
			ThrowInvalidName(P_0, 0, num);
		}
		return result;
	}

	internal static void ParseQNameThrow(string P_0, out string P_1, out string P_2)
	{
		int num = ParseQNameThrow(P_0);
		if (num != 0)
		{
			P_1 = P_0.Substring(0, num);
			P_2 = P_0.Substring(num + 1);
		}
		else
		{
			P_1 = "";
			P_2 = P_0;
		}
	}

	internal static void ThrowInvalidName(string P_0, int P_1, int P_2)
	{
		if (P_1 >= P_0.Length)
		{
			throw new XmlException(System.SR.Format("Xml_EmptyName", string.Empty));
		}
		if (XmlCharType.IsNCNameSingleChar(P_0[P_2]) && !XmlCharType.IsStartNCNameSingleChar(P_0[P_2]))
		{
			throw new XmlException("Xml_BadStartNameChar", XmlException.BuildCharExceptionArgs(P_0, P_2));
		}
		throw new XmlException("Xml_BadNameChar", XmlException.BuildCharExceptionArgs(P_0, P_2));
	}

	internal static Exception GetInvalidNameException(string P_0, int P_1, int P_2)
	{
		if (P_1 >= P_0.Length)
		{
			return new XmlException("Xml_EmptyName", string.Empty);
		}
		if (XmlCharType.IsNCNameSingleChar(P_0[P_2]) && !XmlCharType.IsStartNCNameSingleChar(P_0[P_2]))
		{
			return new XmlException("Xml_BadStartNameChar", XmlException.BuildCharExceptionArgs(P_0, P_2));
		}
		return new XmlException("Xml_BadNameChar", XmlException.BuildCharExceptionArgs(P_0, P_2));
	}
}
