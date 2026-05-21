namespace System.Xml.Schema;

internal sealed class SchemaEntity : IDtdEntityInfo
{
	private readonly XmlQualifiedName _qname;

	private string _url;

	private string _pubid;

	private string _text;

	private XmlQualifiedName _ndata = XmlQualifiedName.Empty;

	private int _lineNumber;

	private int _linePosition;

	private readonly bool _isParameter;

	private bool _isExternal;

	private bool _parsingInProgress;

	private bool _isDeclaredInExternal;

	private string _baseURI;

	private string _declaredURI;

	string IDtdEntityInfo.Name => Name.Name;

	bool IDtdEntityInfo.IsExternal => IsExternal;

	bool IDtdEntityInfo.IsDeclaredInExternal => DeclaredInExternal;

	bool IDtdEntityInfo.IsUnparsedEntity => !NData.IsEmpty;

	bool IDtdEntityInfo.IsParameterEntity => _isParameter;

	string IDtdEntityInfo.BaseUriString => BaseURI;

	string IDtdEntityInfo.DeclaredUriString => DeclaredURI;

	string IDtdEntityInfo.SystemId => Url;

	string IDtdEntityInfo.PublicId => Pubid;

	string IDtdEntityInfo.Text => Text;

	int IDtdEntityInfo.LineNumber => Line;

	int IDtdEntityInfo.LinePosition => Pos;

	internal XmlQualifiedName Name => _qname;

	internal string Url
	{
		get
		{
			return _url;
		}
		set
		{
			_url = url;
			_isExternal = true;
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

	internal bool IsExternal
	{
		get
		{
			return _isExternal;
		}
		set
		{
			_isExternal = isExternal;
		}
	}

	internal bool DeclaredInExternal
	{
		get
		{
			return _isDeclaredInExternal;
		}
		set
		{
			_isDeclaredInExternal = isDeclaredInExternal;
		}
	}

	internal XmlQualifiedName NData
	{
		get
		{
			return _ndata;
		}
		set
		{
			_ndata = ndata;
		}
	}

	internal string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = text;
			_isExternal = false;
		}
	}

	internal int Line
	{
		get
		{
			return _lineNumber;
		}
		set
		{
			_lineNumber = lineNumber;
		}
	}

	internal int Pos
	{
		get
		{
			return _linePosition;
		}
		set
		{
			_linePosition = linePosition;
		}
	}

	internal string BaseURI
	{
		get
		{
			return _baseURI ?? string.Empty;
		}
		set
		{
			_baseURI = baseURI;
		}
	}

	internal bool ParsingInProgress
	{
		get
		{
			return _parsingInProgress;
		}
		set
		{
			_parsingInProgress = parsingInProgress;
		}
	}

	internal string DeclaredURI
	{
		get
		{
			return _declaredURI ?? string.Empty;
		}
		set
		{
			_declaredURI = declaredURI;
		}
	}

	internal SchemaEntity(XmlQualifiedName P_0, bool P_1)
	{
		_qname = P_0;
		_isParameter = P_1;
	}
}
