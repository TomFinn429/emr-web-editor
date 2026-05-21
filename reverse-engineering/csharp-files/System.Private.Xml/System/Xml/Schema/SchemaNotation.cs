namespace System.Xml.Schema;

internal sealed class SchemaNotation
{
	private readonly XmlQualifiedName _name;

	private string _systemLiteral;

	private string _pubid;

	internal XmlQualifiedName Name => _name;

	internal string SystemLiteral
	{
		get
		{
			return _systemLiteral;
		}
		set
		{
			_systemLiteral = systemLiteral;
		}
	}

	internal string Pubid
	{
		get
		{
			return _pubid;
		}
		set
		{
			_pubid = pubid;
		}
	}

	internal SchemaNotation(XmlQualifiedName P_0)
	{
		_name = P_0;
	}
}
