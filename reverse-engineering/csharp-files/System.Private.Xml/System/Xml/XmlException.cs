using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Xml;

[Serializable]
[TypeForwardedFrom("System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class XmlException : SystemException
{
	private readonly string _res;

	private readonly string[] _args;

	private readonly int _lineNumber;

	private readonly int _linePosition;

	private readonly string _sourceUri;

	private readonly string _message;

	public int LineNumber => _lineNumber;

	public int LinePosition => _linePosition;

	public override string Message => _message ?? base.Message;

	internal string ResString => _res;

	public override void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		base.GetObjectData(P_0, P_1);
		P_0.AddValue("res", _res);
		P_0.AddValue("args", _args);
		P_0.AddValue("lineNumber", _lineNumber);
		P_0.AddValue("linePosition", _linePosition);
		P_0.AddValue("sourceUri", _sourceUri);
		P_0.AddValue("version", "2.0");
	}

	public XmlException(string? P_0)
		: this(P_0, (Exception?)null, 0, 0)
	{
	}

	public XmlException(string? P_0, Exception? P_1, int P_2, int P_3)
		: this(P_0, P_1, P_2, P_3, null)
	{
	}

	internal XmlException(string P_0, Exception P_1, int P_2, int P_3, string P_4)
		: base(FormatUserMessage(P_0, P_2, P_3), P_1)
	{
		base.HResult = -2146232000;
		_res = ((P_0 == null) ? "Xml_DefaultException" : "Xml_UserException");
		_args = new string[1] { P_0 };
		_sourceUri = P_4;
		_lineNumber = P_2;
		_linePosition = P_3;
	}

	internal XmlException(string P_0, string[] P_1)
		: this(P_0, P_1, null, 0, 0, null)
	{
	}

	internal XmlException(string P_0, string P_1)
		: this(P_0, new string[1] { P_1 }, null, 0, 0, null)
	{
	}

	internal XmlException(string P_0, string P_1, string P_2)
		: this(P_0, new string[1] { P_1 }, null, 0, 0, P_2)
	{
	}

	internal XmlException(string P_0, string P_1, int P_2, int P_3, string P_4)
		: this(P_0, new string[1] { P_1 }, null, P_2, P_3, P_4)
	{
	}

	internal XmlException(string P_0, string[] P_1, int P_2, int P_3)
		: this(P_0, P_1, null, P_2, P_3, null)
	{
	}

	internal XmlException(string P_0, string[] P_1, int P_2, int P_3, string P_4)
		: this(P_0, P_1, null, P_2, P_3, P_4)
	{
	}

	internal XmlException(string P_0, string[] P_1, Exception P_2, int P_3, int P_4)
		: this(P_0, P_1, P_2, P_3, P_4, null)
	{
	}

	internal XmlException(string P_0, string[] P_1, Exception P_2, int P_3, int P_4, string P_5)
		: base(CreateMessage(P_0, P_1, P_3, P_4), P_2)
	{
		base.HResult = -2146232000;
		_res = P_0;
		_args = P_1;
		_sourceUri = P_5;
		_lineNumber = P_3;
		_linePosition = P_4;
	}

	private static string FormatUserMessage(string P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return CreateMessage("Xml_DefaultException", null, P_1, P_2);
		}
		if (P_1 == 0 && P_2 == 0)
		{
			return P_0;
		}
		return CreateMessage("Xml_UserException", new string[1] { P_0 }, P_1, P_2);
	}

	private static string CreateMessage(string P_0, string[] P_1, int P_2, int P_3)
	{
		try
		{
			string text;
			if (P_1 != null)
			{
				object[] array = P_1;
				text = string.Format(P_0, array);
			}
			else
			{
				text = P_0;
			}
			string text2 = text;
			if (P_2 != 0)
			{
				string text3 = P_2.ToString(CultureInfo.InvariantCulture);
				string text4 = P_3.ToString(CultureInfo.InvariantCulture);
				object[] array = new string[3] { text2, text3, text4 };
				text2 = System.SR.Format("Xml_MessageWithErrorPosition", array);
			}
			return text2;
		}
		catch (MissingManifestResourceException)
		{
			return "UNKNOWN(" + P_0 + ")";
		}
	}

	internal static string[] BuildCharExceptionArgs(string P_0, int P_1)
	{
		return BuildCharExceptionArgs(P_0[P_1], (P_1 + 1 < P_0.Length) ? P_0[P_1 + 1] : '\0');
	}

	internal static string[] BuildCharExceptionArgs(char[] P_0, int P_1, int P_2)
	{
		return BuildCharExceptionArgs(P_0[P_2], (P_2 + 1 < P_1) ? P_0[P_2 + 1] : '\0');
	}

	internal static string[] BuildCharExceptionArgs(char P_0, char P_1)
	{
		string[] array = new string[2];
		if (XmlCharType.IsHighSurrogate(P_0) && P_1 != 0)
		{
			int num = XmlCharType.CombineSurrogateChar(P_1, P_0);
			string[] array2 = array;
			Span<char> span = stackalloc char[2] { P_0, P_1 };
			array2[0] = new string(span);
			array[1] = $"0x{num:X2}";
		}
		else
		{
			if (P_0 == '\0')
			{
				array[0] = ".";
			}
			else
			{
				array[0] = P_0.ToString();
			}
			array[1] = $"0x{P_0:X2}";
		}
		return array;
	}
}
