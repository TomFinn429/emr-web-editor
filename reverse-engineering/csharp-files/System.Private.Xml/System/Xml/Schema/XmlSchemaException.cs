using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Xml.Schema;

[Serializable]
[TypeForwardedFrom("System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class XmlSchemaException : SystemException
{
	private readonly string _res;

	private readonly string[] _args;

	private string _sourceUri;

	private int _lineNumber;

	private int _linePosition;

	private XmlSchemaObject _sourceSchemaObject;

	private readonly string _message;

	public override string Message => _message ?? base.Message;

	public override void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		base.GetObjectData(P_0, P_1);
		P_0.AddValue("res", _res);
		P_0.AddValue("args", _args);
		P_0.AddValue("sourceUri", _sourceUri);
		P_0.AddValue("lineNumber", _lineNumber);
		P_0.AddValue("linePosition", _linePosition);
		P_0.AddValue("version", "2.0");
	}

	public XmlSchemaException(string? P_0, Exception? P_1)
		: this(P_0, P_1, 0, 0)
	{
	}

	public XmlSchemaException(string? P_0, Exception? P_1, int P_2, int P_3)
		: this((P_0 == null) ? "Sch_DefaultException" : "Xml_UserException", new string[1] { P_0 }, P_1, null, P_2, P_3, null)
	{
	}

	internal XmlSchemaException(string P_0, string P_1)
		: this(P_0, new string[1] { P_1 }, null, null, 0, 0, null)
	{
	}

	internal XmlSchemaException(string P_0, string P_1, string P_2, int P_3, int P_4)
		: this(P_0, new string[1] { P_1 }, null, P_2, P_3, P_4, null)
	{
	}

	internal XmlSchemaException(string P_0, string[] P_1, Exception P_2, string P_3, int P_4, int P_5, XmlSchemaObject P_6)
		: base(CreateMessage(P_0, P_1), P_2)
	{
		base.HResult = -2146231999;
		_res = P_0;
		_args = P_1;
		_sourceUri = P_3;
		_lineNumber = P_4;
		_linePosition = P_5;
		_sourceSchemaObject = P_6;
	}

	internal static string CreateMessage(string P_0, string[] P_1)
	{
		try
		{
			if (P_1 == null)
			{
				return P_0;
			}
			return string.Format(P_0 ?? string.Empty, P_1);
		}
		catch (MissingManifestResourceException)
		{
			return "UNKNOWN(" + P_0 + ")";
		}
	}
}
