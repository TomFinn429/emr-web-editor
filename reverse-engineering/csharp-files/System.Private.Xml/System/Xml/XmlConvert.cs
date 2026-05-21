using System.Globalization;
using System.Xml.Schema;

namespace System.Xml;

public class XmlConvert
{
	internal static char[] crt = new char[3] { '\n', '\r', '\t' };

	internal static readonly char[] WhitespaceChars = new char[4] { ' ', '\t', '\n', '\r' };

	internal static byte[] FromBinHexString(string P_0, bool P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "s");
		return BinHexDecoder.Decode(P_0.AsSpan(), P_1);
	}

	internal static string ToBinHexString(byte[] P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "inArray");
		return BinHexEncoder.Encode(P_0, 0, P_0.Length);
	}

	public static string VerifyName(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		if (P_0.Length == 0)
		{
			throw new ArgumentNullException("name", "Xml_EmptyName");
		}
		int num = ValidateNames.ParseNameNoNamespaces(P_0, 0);
		if (num != P_0.Length)
		{
			throw CreateInvalidNameCharException(P_0, num, ExceptionType.XmlException);
		}
		return P_0;
	}

	internal static Exception TryVerifyName(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return new XmlException("Xml_EmptyName", string.Empty);
		}
		int num = ValidateNames.ParseNameNoNamespaces(P_0, 0);
		if (num != P_0.Length)
		{
			return new XmlException((num == 0) ? "Xml_BadStartNameChar" : "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(P_0, num));
		}
		return null;
	}

	internal static Exception TryVerifyNCName(string P_0)
	{
		int num = ValidateNames.ParseNCName(P_0);
		if (num == 0 || num != P_0.Length)
		{
			return ValidateNames.GetInvalidNameException(P_0, 0, num);
		}
		return null;
	}

	internal static Exception TryVerifyTOKEN(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (P_0.StartsWith(' ') || P_0.EndsWith(' ') || P_0.IndexOfAny(crt) >= 0 || P_0.Contains("  "))
		{
			return new XmlException("Sch_NotTokenString", P_0);
		}
		return null;
	}

	internal static Exception TryVerifyNMTOKEN(string P_0)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			return new XmlException("Xml_EmptyName", string.Empty);
		}
		int num = ValidateNames.ParseNmtokenNoNamespaces(P_0, 0);
		if (num != P_0.Length)
		{
			return new XmlException("Xml_BadNameChar", XmlException.BuildCharExceptionArgs(P_0, num));
		}
		return null;
	}

	internal static Exception TryVerifyNormalizedString(string P_0)
	{
		if (P_0.IndexOfAny(crt) != -1)
		{
			return new XmlSchemaException("Sch_NotNormalizedString", P_0);
		}
		return null;
	}

	public static string ToString(bool P_0)
	{
		if (!P_0)
		{
			return "false";
		}
		return "true";
	}

	public static string ToString(decimal P_0)
	{
		return P_0.ToString(null, NumberFormatInfo.InvariantInfo);
	}

	[CLSCompliant(false)]
	public static string ToString(sbyte P_0)
	{
		return P_0.ToString(null, CultureInfo.InvariantCulture);
	}

	public static string ToString(short P_0)
	{
		return P_0.ToString(null, CultureInfo.InvariantCulture);
	}

	public static string ToString(int P_0)
	{
		return P_0.ToString(null, CultureInfo.InvariantCulture);
	}

	public static string ToString(long P_0)
	{
		return P_0.ToString(null, CultureInfo.InvariantCulture);
	}

	public static string ToString(byte P_0)
	{
		return P_0.ToString(null, CultureInfo.InvariantCulture);
	}

	[CLSCompliant(false)]
	public static string ToString(ushort P_0)
	{
		return P_0.ToString(null, CultureInfo.InvariantCulture);
	}

	[CLSCompliant(false)]
	public static string ToString(uint P_0)
	{
		return P_0.ToString(null, CultureInfo.InvariantCulture);
	}

	[CLSCompliant(false)]
	public static string ToString(ulong P_0)
	{
		return P_0.ToString(null, CultureInfo.InvariantCulture);
	}

	public static string ToString(float P_0)
	{
		if (float.IsNegativeInfinity(P_0))
		{
			return "-INF";
		}
		if (float.IsPositiveInfinity(P_0))
		{
			return "INF";
		}
		if (IsNegativeZero(P_0))
		{
			return "-0";
		}
		return P_0.ToString("R", NumberFormatInfo.InvariantInfo);
	}

	public static string ToString(double P_0)
	{
		if (double.IsNegativeInfinity(P_0))
		{
			return "-INF";
		}
		if (double.IsPositiveInfinity(P_0))
		{
			return "INF";
		}
		if (IsNegativeZero(P_0))
		{
			return "-0";
		}
		return P_0.ToString("R", NumberFormatInfo.InvariantInfo);
	}

	public static bool ToBoolean(string P_0)
	{
		P_0 = TrimString(P_0);
		switch (P_0)
		{
		case "1":
		case "true":
			return true;
		case "0":
		case "false":
			return false;
		default:
			throw new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Boolean"));
		}
	}

	internal static Exception TryToBoolean(string P_0, out bool P_1)
	{
		P_0 = TrimString(P_0);
		switch (P_0)
		{
		case "0":
		case "false":
			P_1 = false;
			return null;
		case "1":
		case "true":
			P_1 = true;
			return null;
		default:
			P_1 = false;
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Boolean"));
		}
	}

	public static char ToChar(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "s");
		if (P_0.Length != 1)
		{
			throw new FormatException("XmlConvert_NotOneCharString");
		}
		return P_0[0];
	}

	internal static Exception TryToChar(string P_0, out char P_1)
	{
		if (!char.TryParse(P_0, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Char"));
		}
		return null;
	}

	public static decimal ToDecimal(string P_0)
	{
		return decimal.Parse(P_0, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo);
	}

	internal static Exception TryToDecimal(string P_0, out decimal P_1)
	{
		if (!decimal.TryParse(P_0, NumberStyles.Integer | NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Decimal"));
		}
		return null;
	}

	internal static decimal ToInteger(string P_0)
	{
		return decimal.Parse(P_0, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
	}

	internal static Exception TryToInteger(string P_0, out decimal P_1)
	{
		if (!decimal.TryParse(P_0, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Integer"));
		}
		return null;
	}

	internal static Exception TryToSByte(string P_0, out sbyte P_1)
	{
		if (!sbyte.TryParse(P_0, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "SByte"));
		}
		return null;
	}

	internal static Exception TryToInt16(string P_0, out short P_1)
	{
		if (!short.TryParse(P_0, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Int16"));
		}
		return null;
	}

	public static int ToInt32(string P_0)
	{
		return int.Parse(P_0, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
	}

	internal static Exception TryToInt32(string P_0, out int P_1)
	{
		if (!int.TryParse(P_0, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Int32"));
		}
		return null;
	}

	public static long ToInt64(string P_0)
	{
		return long.Parse(P_0, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
	}

	internal static Exception TryToInt64(string P_0, out long P_1)
	{
		if (!long.TryParse(P_0, NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Int64"));
		}
		return null;
	}

	internal static Exception TryToByte(string P_0, out byte P_1)
	{
		if (!byte.TryParse(P_0, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Byte"));
		}
		return null;
	}

	internal static Exception TryToUInt16(string P_0, out ushort P_1)
	{
		if (!ushort.TryParse(P_0, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "UInt16"));
		}
		return null;
	}

	internal static Exception TryToUInt32(string P_0, out uint P_1)
	{
		if (!uint.TryParse(P_0, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "UInt32"));
		}
		return null;
	}

	internal static Exception TryToUInt64(string P_0, out ulong P_1)
	{
		if (!ulong.TryParse(P_0, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "UInt64"));
		}
		return null;
	}

	public static float ToSingle(string P_0)
	{
		P_0 = TrimString(P_0);
		if (P_0 == "-INF")
		{
			return -1f / 0f;
		}
		if (P_0 == "INF")
		{
			return 1f / 0f;
		}
		float num = float.Parse(P_0, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, NumberFormatInfo.InvariantInfo);
		if (num == 0f && P_0[0] == '-')
		{
			return -0f;
		}
		return num;
	}

	internal static Exception TryToSingle(string P_0, out float P_1)
	{
		P_0 = TrimString(P_0);
		if (P_0 == "-INF")
		{
			P_1 = -1f / 0f;
			return null;
		}
		if (P_0 == "INF")
		{
			P_1 = 1f / 0f;
			return null;
		}
		if (!float.TryParse(P_0, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Single"));
		}
		if (P_1 == 0f && P_0[0] == '-')
		{
			P_1 = -0f;
		}
		return null;
	}

	public static double ToDouble(string P_0)
	{
		P_0 = TrimString(P_0);
		if (P_0 == "-INF")
		{
			return -1.0 / 0.0;
		}
		if (P_0 == "INF")
		{
			return 1.0 / 0.0;
		}
		double num = double.Parse(P_0, NumberStyles.Float, NumberFormatInfo.InvariantInfo);
		if (num == 0.0 && P_0[0] == '-')
		{
			return -0.0;
		}
		return num;
	}

	internal static Exception TryToDouble(string P_0, out double P_1)
	{
		P_0 = TrimString(P_0);
		if (P_0 == "-INF")
		{
			P_1 = -1.0 / 0.0;
			return null;
		}
		if (P_0 == "INF")
		{
			P_1 = 1.0 / 0.0;
			return null;
		}
		if (!double.TryParse(P_0, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Double"));
		}
		if (P_1 == 0.0 && P_0[0] == '-')
		{
			P_1 = -0.0;
		}
		return null;
	}

	internal static double ToXPathDouble(object P_0)
	{
		if (P_0 is string text)
		{
			string text2 = TrimString(text);
			if (text2.Length != 0 && text2[0] != '+' && double.TryParse(text2, NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out var result))
			{
				return result;
			}
			return 0.0 / 0.0;
		}
		if (P_0 is double)
		{
			return (double)P_0;
		}
		if (P_0 is bool)
		{
			if (!(bool)P_0)
			{
				return 0.0;
			}
			return 1.0;
		}
		try
		{
			return Convert.ToDouble(P_0, NumberFormatInfo.InvariantInfo);
		}
		catch (FormatException)
		{
		}
		catch (OverflowException)
		{
		}
		catch (ArgumentNullException)
		{
		}
		return 0.0 / 0.0;
	}

	internal static double XPathRound(double P_0)
	{
		double num = Math.Round(P_0);
		if (P_0 - num != 0.5)
		{
			return num;
		}
		return num + 1.0;
	}

	internal static Exception TryToTimeSpan(string P_0, out TimeSpan P_1)
	{
		XsdDuration xsdDuration;
		Exception ex = XsdDuration.TryParse(P_0, out xsdDuration);
		if (ex != null)
		{
			P_1 = TimeSpan.MinValue;
			return ex;
		}
		return xsdDuration.TryToTimeSpan(out P_1);
	}

	public static Guid ToGuid(string P_0)
	{
		return new Guid(P_0);
	}

	internal static Exception TryToGuid(string P_0, out Guid P_1)
	{
		Exception result = null;
		P_1 = Guid.Empty;
		try
		{
			P_1 = new Guid(P_0);
		}
		catch (ArgumentException)
		{
			result = new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Guid"));
		}
		catch (FormatException)
		{
			result = new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Guid"));
		}
		return result;
	}

	internal static Uri ToUri(string P_0)
	{
		if (!string.IsNullOrEmpty(P_0))
		{
			P_0 = TrimString(P_0);
			if (P_0.Length == 0 || P_0.IndexOf("##", StringComparison.Ordinal) != -1)
			{
				throw new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Uri"));
			}
		}
		if (!Uri.TryCreate(P_0, UriKind.RelativeOrAbsolute, out Uri result))
		{
			throw new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Uri"));
		}
		return result;
	}

	internal static Exception TryToUri(string P_0, out Uri P_1)
	{
		P_1 = null;
		if (P_0 != null && P_0.Length > 0)
		{
			P_0 = TrimString(P_0);
			if (P_0.Length == 0 || P_0.IndexOf("##", StringComparison.Ordinal) != -1)
			{
				return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Uri"));
			}
		}
		if (!Uri.TryCreate(P_0, UriKind.RelativeOrAbsolute, out P_1))
		{
			return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, "Uri"));
		}
		return null;
	}

	internal static bool StrEqual(char[] P_0, int P_1, int P_2, string P_3)
	{
		if (P_2 != P_3.Length)
		{
			return false;
		}
		int i;
		for (i = 0; i < P_2 && P_0[P_1 + i] == P_3[i]; i++)
		{
		}
		return i == P_2;
	}

	internal static string TrimString(string P_0)
	{
		return P_0.Trim(WhitespaceChars);
	}

	internal static string[] SplitString(string P_0)
	{
		return P_0.Split(WhitespaceChars, StringSplitOptions.RemoveEmptyEntries);
	}

	internal static bool IsNegativeZero(double P_0)
	{
		if (P_0 == 0.0 && BitConverter.DoubleToInt64Bits(P_0) == BitConverter.DoubleToInt64Bits(-0.0))
		{
			return true;
		}
		return false;
	}

	internal static Exception CreateException(string P_0, string[] P_1, ExceptionType P_2, int P_3, int P_4)
	{
		switch (P_2)
		{
		case ExceptionType.ArgumentException:
			return new ArgumentException(string.Format(P_0, P_1));
		default:
			return new XmlException(P_0, P_1, P_3, P_4);
		}
	}

	internal static Exception CreateInvalidNameCharException(string P_0, int P_1, ExceptionType P_2)
	{
		return CreateException((P_1 == 0) ? "Xml_BadStartNameChar" : "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(P_0, P_1), P_2, 0, P_1 + 1);
	}
}
